Imports System.Data.SqlClient
Imports Retails.clsPublic
Imports System.Runtime.InteropServices
Public Class frm_100_RRList


#Region "Variable"

    Implements IBPS_SEARCH
    Implements IBPSCommand
    Dim bolFormState As clsPublic.FormState

  
#End Region
#Region "Procedure"

#Region "Search function"



    Dim tableName As String = "tbl_100_RR"
    Dim strSQL As String
    Dim da As SqlDataAdapter
    Dim ds As New DataSet
    Dim dv As DataView
    Dim scrollVal As Integer = 0
    Dim pageSize As Integer = 50
    Dim recordCount As Long = 0
    Dim pageCount As Integer = 0
    Dim currentPage As Integer = 1
    Dim strFilter As String

    Enum Pagination
        FirstPage
        PrevPage
        NextPage
        LastPage
        SamePage
    End Enum

    Sub Navigate(ByVal navAt As Pagination)

        tsFirst.Enabled = False
        tsPrev.Enabled = False
        tsNext.Enabled = False
        tsLast.Enabled = False

        strFilter = String.Empty

        Select Case navAt

            Case Pagination.FirstPage
                ' First Page
                scrollVal = 0
                currentPage = 1
            Case Pagination.PrevPage
                ' Go to Previous Page
                scrollVal = scrollVal - pageSize
                currentPage = currentPage - 1
            Case Pagination.NextPage
                ' Go to Next Page
                scrollVal = scrollVal + pageSize
                currentPage = currentPage + 1
            Case Pagination.LastPage
                ' Go to Last Page
                scrollVal = (pageCount - 1) * pageSize
                currentPage = pageCount
        End Select

        tsFirst.Enabled = scrollVal > 0
        tsPrev.Enabled = scrollVal > 0
        tsNext.Enabled = (scrollVal + pageSize) < recordCount
        tsLast.Enabled = (scrollVal + pageSize) < recordCount

        ds.Clear()
        da.Fill(ds, scrollVal, pageSize, tableName)

        dv = New DataView(ds.Tables(tableName))

        dgList.DataSource = dv

        tsPage.Text = currentPage & " of " & pageCount
        tsRecordCount.Text = "Showing " & dgList.RowCount & " of " & recordCount & " records"

        MainForm.tsFilterClear.Enabled = False
        MainForm.tsFilterOn.Enabled = dgList.RowCount > 0
    End Sub

    Private Function StrPtr(ByVal obj As Object) As Integer
        Dim Handle As GCHandle = _
           GCHandle.Alloc(obj, GCHandleType.Pinned)
        Dim intReturn As Integer = _
           Handle.AddrOfPinnedObject.ToInt32
        Handle.Free()
        Return intReturn
    End Function

    Sub RefreshRecord(ByVal sql As String)

        Cursor = Cursors.WaitCursor

        strFilter = String.Empty

        strSQL = sql

        Dim connection As New SqlConnection(cnString)

        da = New SqlDataAdapter(strSQL, connection)
        ds = New DataSet()

        connection.Open()

        Dim dsCount As New DataSet
        Dim daCount As New SqlDataAdapter(strSQL, connection)

        dsCount.Clear()
        daCount.Fill(dsCount, "TableCount")
        recordCount = dsCount.Tables(0).Rows.Count

        If pageSize = 0 Then
            pageSize = recordCount
        End If

        pageCount = recordCount \ pageSize
        If recordCount Mod pageSize <> 0 Then
            pageCount = pageCount + 1
        End If

        currentPage = 1
        scrollVal = 0

        da.Fill(ds, scrollVal, pageSize, tableName)

        dv = New DataView(ds.Tables(tableName))

        tsFirst.Enabled = False
        tsPrev.Enabled = False
        tsNext.Enabled = ds.Tables(tableName).Rows.Count < recordCount
        tsLast.Enabled = ds.Tables(tableName).Rows.Count < recordCount

        dgList.DataSource = dv

        tsPage.Text = currentPage & " of " & pageCount
        tsRecordCount.Text = "Showing " & dgList.RowCount & " of " & recordCount & " records"

        MainForm.tsFilterClear.Enabled = False
        MainForm.tsFilterOn.Enabled = dgList.RowCount > 0

        Cursor = Cursors.Default
        connection.Close()
    End Sub

    Sub FilterOn()

        Dim sortColumn As String

        Dim newFilter As String = Me.dgList.Columns(Me.dgList.CurrentCell.ColumnIndex).DataPropertyName.ToString & "='" & Me.dgList.CurrentCell.Value & "'"

        If strFilter = String.Empty Then
            strFilter = newFilter
        Else
            strFilter = strFilter & " AND  " & newFilter
        End If

        If dgList.SortedColumn Is Nothing Then
            sortColumn = dgList.Columns(0).DataPropertyName
        Else
            sortColumn = dgList.SortedColumn.DataPropertyName
        End If

        dv = New DataView(ds.Tables(0), strFilter, sortColumn, DataViewRowState.CurrentRows)

        dgList.DataSource = dv

        tsRecordCount.Text = "Showing " & dgList.RowCount & " of " & recordCount & " records (filtered)"

        MainForm.tsFilterClear.Enabled = True

    End Sub

    Sub FilterClear()
        strFilter = String.Empty
        Navigate(Pagination.SamePage)

    End Sub

#End Region

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strCmd"></param>
    ''' <remarks></remarks>
    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                Call NewRecord()
            Case "Edit"
                Call EditRecord()
            Case "Delete"
                Call DeleteRecord()
            Case "Save"

            Case "Cancel"

            Case "Refresh"
                MainForm.tsSearch.Text = String.Empty
                Call RefreshRecord("sp_100_Get_RR_List '" & MainForm.tsSearch.Text & "'")
            Case "Search"
                Call RefreshRecord("sp_100_Get_RR_List '" & MainForm.tsSearch.Text & "'")
            Case "Filter"
                Call FilterOn()
            Case "FilterClear"
                Call FilterClear()
        End Select
    End Sub
    Private Function HasRecord(ByVal RRNO As String) As Boolean
        Dim isHaveRecord As Boolean = False
        '-->check if this PO no is used in RR transaction
        If isRecordExist("SELECT     tbl_100_WR_Sub.RRNo " & _
                         "FROM         tbl_100_WR_Sub INNER JOIN " & _
                         "tbl_100_WR ON tbl_100_WR_Sub.WRNo = tbl_100_WR.WRNo " & _
                         "WHERE     (tbl_100_WR.isStatus <> N'CANCELLED') AND (tbl_100_WR_Sub.RRNo = '" & RRNO & "')") Then
            isHaveRecord = True
        End If


        Return isHaveRecord

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteRecord()
        Dim control As String = dgList.Item(0, dgList.CurrentCell.RowIndex).Value
        If vbYes = MsgBox("Are you sure you want to delete this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then

            If HasRecord(control) = True Then
                MsgBox("Invalid to Delete this transaction is being used by other transaction", MsgBoxStyle.Exclamation, "Prompt")
                Exit Sub
            Else

                RunQuery("sp_Delete_Transaction 'RR','" & control & "'")
                Call SaveAuditTrail("Delete RR No. ", control)
                Call RefreshRecord("sp_100_Get_RR_List '" & MainForm.tsSearch.Text & "'")

            End If
        End If
    End Sub
    Public Sub DeleteProcedure()
        ''Variable for RR
        Dim _transNO As String = dgList.Item(0, dgList.CurrentRow.Index).Value
        Dim arrayParam As ArrayList = New ArrayList
        Dim RR_POno As String
        Dim RR_specificCode As String
        Dim RR_Quantity As Double

        ''Variable for PO
        Dim PO_pono As String
        Dim PO_SpecificCode As String
        Dim PO_Qty As Double
        Dim PO_RRQTy As Double
        Dim tmp_total_QTY As Double
        If dgList.Item(2, dgList.CurrentRow.Index).Value = "PO" Then

            ''Get RR
            SQL = "SELECT   tbl_100_RR.RRNo, tbl_100_RR.RefOrderNo, tbl_100_RR_Sub.SpecificCode, tbl_100_RR_Sub.ActualQTY " & _
                    "FROM         tbl_100_RR INNER JOIN " & _
                        "tbl_100_RR_Sub ON tbl_100_RR.RRNo = tbl_100_RR_Sub.RRNo WHERE     (tbl_100_RR.RRType = 'PO') and (tbl_100_RR.RRNo='" & _transNO & "')"

            arrayParam = FetchData(arrayParam, SQL, CommandType.Text)
            If arrayParam Is Nothing Or arrayParam.Count = 0 Then
                '' nothing to display
            Else
                RR_POno = arrayParam(1).ToString
                RR_specificCode = arrayParam(2).ToString
                RR_Quantity = arrayParam(3)
            End If

            arrayParam.Clear()

            ''Get PO
            SQL = "SELECT PONo, SpecificCode, ReqQty, RRQTY FROM tbl_100_PO_Sub  where Pono='" & RR_POno & "'"
            arrayParam = FetchData(arrayParam, SQL, CommandType.Text)
            If arrayParam Is Nothing Or arrayParam.Count = 0 Then
                '' nothing to display
            Else
                PO_pono = arrayParam(0).ToString
                PO_SpecificCode = arrayParam(1).ToString
                PO_Qty = arrayParam(2)
                PO_RRQTy = arrayParam(3)
            End If

            ''Get Total_RR Qty
            arrayParam.Clear()
            SQL = "SELECT     tbl_100_RR.RefOrderNo, tbl_100_RR_Sub.SpecificCode, SUM(tbl_100_RR_Sub.ActualQTY) AS TotalQuantity " & _
                "FROM tbl_100_RR_Sub INNER JOIN tbl_100_RR ON tbl_100_RR_Sub.RRNo = tbl_100_RR.RRNo " & _
                "GROUP BY tbl_100_RR.RefOrderNo, tbl_100_RR_Sub.SpecificCode " & _
                "HAVING (tbl_100_RR.RefOrderNo = '" & PO_pono & "') AND (tbl_100_RR_Sub.SpecificCode = '" & PO_SpecificCode & "')"
            arrayParam = FetchData(arrayParam, SQL, CommandType.Text)
            If arrayParam Is Nothing Or arrayParam.Count = 0 Then
                '' nothing to display
            Else
                tmp_total_QTY = arrayParam(2)
            End If

            PO_RRQTy = PO_RRQTy + RR_Quantity
            If PO_Qty < PO_RRQTy Then

                UpdateTrans("Update tbl_100_PO_Sub set RRQTY='" & PO_RRQTy & "', Status='" & isUndelivered & "' where POno='" & PO_pono & "' and SpecificCode='" & PO_SpecificCode & "'")
                UpdateTrans("Update tbl_000_Item_Sub set StackOH")
            ElseIf PO_Qty > tmp_total_QTY Then
                UpdateTrans("Update tbl_100_PO_Sub set RRQTY='" & PO_RRQTy & "', Status='" & isLacking & "' where POno='" & PO_pono & "' and SpecificCode='" & PO_SpecificCode & "'")
            End If

        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Sub NewRecord()
        With frm_100_RR
            .MdiParent = MainForm
            .myParent = Me
            .bolFormState = FormState.AddState
            .Show()
            .Focus()
        End With
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Sub EditRecord()
        With frm_100_RR
            .MdiParent = MainForm
            .myParent = Me
            .bolFormState = FormState.EditState
            .Show()
            .Focus()
        End With
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="frmState"></param>
    ''' <remarks></remarks>
    Sub ActivateCommands(ByVal frmState As clsPublic.FormState)
        bolFormState = frmState

        With MainForm
            Select Case frmState
                Case FormState.AddState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                    
                    .tsPrint.Enabled = False
                    .tsPrint.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
                Case FormState.EditState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                    
                    .tsPrint.Enabled = True
                    .tsPreview.Enabled = True
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
                Case FormState.ViewState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = True
                    .tsDelete.Enabled = True
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                    
                    .tsPrint.Enabled = False
                    .tsPreview.Enabled = False
                    .tsSearch.Enabled = True
                    .btnSearch.Enabled = True
                    .tsFilterOn.Enabled = True
                Case FormState.LoadState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                    
                    .tsPrint.Enabled = False
                    .tsPrint.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
            End Select

        End With
    End Sub

#End Region

#Region "GUI"
    Private Sub dgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellDoubleClick
        ''Call Filter()
    End Sub

    Private Sub dgList_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellEnter
        If dgList.RowCount > 0 Then
            ActivateCommands(FormState.ViewState)
        Else
            ActivateCommands(FormState.LoadState)
        End If

    End Sub

    Private Sub frm_100_RRList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control = True And e.KeyCode = Keys.N And MainForm.tsNew.Visible = True And MainForm.tsNew.Enabled = True Then
            ProcessFormCommand("New")
        ElseIf e.KeyCode = Keys.F2 And MainForm.tsEdit.Visible = True And MainForm.tsEdit.Enabled = True Then
            ProcessFormCommand("Edit")
        ElseIf e.Control And e.KeyCode = Keys.E And MainForm.tsEdit.Visible = True And MainForm.tsEdit.Enabled = True Then
            ProcessFormCommand("Edit")
        ElseIf e.Control = True And e.KeyCode = Keys.S And MainForm.tsSave.Visible = True And MainForm.tsSave.Enabled = True Then
            ProcessFormCommand("Save")
        ElseIf e.KeyCode = Keys.Escape And MainForm.tsCancel.Visible = True And MainForm.tsCancel.Enabled = True Then
            ProcessFormCommand("Cancel")
        End If
    End Sub

    Private Sub frm_100_RRList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        ActivateCommands(FormState.LoadState)
        Call RefreshRecord("sp_100_Get_RR_List '" & MainForm.tsSearch.Text & "'")
        Column4.HeaderCell.Style.BackColor = Color.Black
    End Sub

    Private Sub frm_100_RRList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterControl(lblTitle, Me)
    End Sub

    Public Sub ProcessSearchData(ByVal str As String) Implements IBPS_SEARCH.ProcessSearchData
        Call RefreshRecord("sp_100_Get_RR_List '" & MainForm.tsSearch.Text & "'")
    End Sub

    Private Sub tsPageSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPageSize.Click
        Dim intCanceled As Integer
        intCanceled = StrPtr(String.Empty)

        Dim strPageSize As String = InputBox("Enter number of records you want to show in every page.", "Page Size", pageSize)

        If StrPtr(strPageSize) <> intCanceled Then
            If strPageSize = 0 Or strPageSize = String.Empty Then
                pageSize = 0
            Else
                pageSize = strPageSize
            End If
            RefreshRecord(strSQL)

        End If
    End Sub

    Private Sub tsFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFirst.Click
        Navigate(Pagination.FirstPage)
    End Sub

    Private Sub tsPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPrev.Click
        Navigate(Pagination.PrevPage)
    End Sub

    Private Sub tsNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNext.Click
        Navigate(Pagination.NextPage)
    End Sub

    Private Sub tsLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLast.Click
        Navigate(Pagination.LastPage)
    End Sub

#End Region
End Class