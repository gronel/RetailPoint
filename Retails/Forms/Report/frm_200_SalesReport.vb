Imports System.Data.SqlClient
Imports RetailPoint.clsPublic
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.IO.Directory

Public Class frm_200_SalesReport

#Region "Variable"

    Implements IBPSCommand
    Implements IBPS_SEARCH

    Dim second As Integer

    Dim bolFormState As clsPublic.FormState
    Public category, value As String
    Public rownum As Integer
    Public FillFindON As Boolean
    Public filterback As String
    Dim _bm As Bitmap
    Dim _imagePath As String
#End Region

#Region "Procedure"

#Region "Search function"



    Dim tableName As String = "tbl_000_ITEM"
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
    Private Function StrPtr(ByVal obj As Object) As Integer
        Dim Handle As GCHandle = _
           GCHandle.Alloc(obj, GCHandleType.Pinned)
        Dim intReturn As Integer = _
           Handle.AddrOfPinnedObject.ToInt32
        Handle.Free()
        Return intReturn
    End Function



    Public Sub ProcessSearchData(ByVal str As String) Implements IBPS_SEARCH.ProcessSearchData
        Call RefreshRecord("sproc_100_po_list'" & MainForm.tsSearch.Text & "'")
    End Sub
    Sub ViewFilterBack()
        Call RefreshRecord("sproc_100_po_list'" & MainForm.tsSearch.Text & "'")
        If FillFindON = True Then

            Dim sortColumn As String

            Dim newFilter As String = filterback

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

            FillFindON = True

        End If
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

        FillFindON = True
        filterback = newFilter
    End Sub

    Sub FilterClear()
        strFilter = String.Empty
        Navigate(Pagination.SamePage)
        FillFindON = False
    End Sub

#End Region

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                NewRecord()
            Case "Edit"
                EditRecord()
            Case "Delete"
                DeleteRecord()
            Case "Save"

            Case "Cancel"

            Case "Refresh"
                '  MainForm.tsSearch.Text = String.Empty

                ' Call RefreshRecord("sproc_100_po_list'" & MainForm.tsSearch.Text & "'")
            Case "Filter"
                Call FilterOn()
            Case "FilterClear"
                Call FilterClear()
        End Select
    End Sub



    Sub DeleteRecord()
        If vbYes = MsgBox("Are you sure you want to delete this Item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then

            RunQuery("Delete tbl_000_Item where ItemId=" & dgList.Item("colItemId", dgList.CurrentCell.RowIndex).Value)

            Call SaveAuditTrail("Delete item code", dgList.Item("colitemcode", dgList.CurrentCell.RowIndex).Value)
            Call RefreshRecord("sproc_100_po_list'" & MainForm.tsSearch.Text & "'")
            SelectDataGridViewRow(dgList)

        End If
    End Sub

    Sub NewRecord()
        'With frm_100_PO
        '    .MdiParent = MainForm
        '    .myParent = Me
        '    .bolFormState = FormState.AddState
        '    '.ShowDialog()
        '    .Show()
        '    .Focus()
        'End With
    End Sub

    Sub EditRecord()
        'With frm_100_PO
        '    .MdiParent = MainForm
        '    .myParent = Me
        '    .bolFormState = FormState.EditState
        '    '.ShowDialog()
        '    .Show()
        '    .Focus()
        'End With
    End Sub

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
                Case FormState.EditState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                Case FormState.ViewState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = True
                    .tsDelete.Enabled = True
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                    .tsFilterOn.Enabled = True
                    .tsSearch.Enabled = True
                Case FormState.LoadState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                    .tsSearch.Enabled = False
            End Select

        End With
    End Sub

#End Region

#Region "GUI"
    Private Sub frm_000_ItemList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_000_ItemList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Me.txtItemName.Focus()
        ' cboItemCode.Items.Clear()
        bolFormState = FormState.LoadState
        Timer1.Enabled = False
        Timer1.Stop()
    End Sub

    Private Sub frm_000_ItemList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        ElseIf e.KeyCode = Keys.Escape Then
            'frmDeleteItem.frmparent = Me
            'frmDeleteItem.ShowDialog()

            Me.Refresh()
        End If
    End Sub

    Private Sub frm_000_ItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        ' Call RefreshRecord("sproc_100_po_list'" & MainForm.tsSearch.Text & "'")
        ActivateCommands(FormState.ViewState)


    End Sub


    Private Sub frm_000_ItemList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterControl(lblTitle, Me)
    End Sub



    Private Sub dgList_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellEnter

        Try
            If dgList.RowCount > 0 Then
                ActivateCommands(FormState.ViewState)
            Else
                ActivateCommands(FormState.LoadState)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try


    End Sub


    Private Sub GetData()
        FillGrid(dgList, "sproc_200_SalesReportUnpost '" & dtfrom.Text & "','" & dtto.Text & "'", "tbl_100_SR")
    End Sub
#End Region




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

    Private Sub dgList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                With frm_200_SalesDetails
                    .sr_no = dgList.Item("colSRId", e.RowIndex).Value
                    .ShowDialog(Me)
                End With
            Case 1

                RunQuery("UPDATE tbl_100_SR SET IsPosted = 1,PostedId=" + CurrUser.USER_ID.ToString + " WHERE (SRId = " + dgList.Item("colSRId", e.RowIndex).Value + ")")
                btnpreview_Click(Me, Nothing)
        End Select

    End Sub

    Private Sub btnpreview_Click(sender As Object, e As EventArgs) Handles btnpreview.Click
        GetData()
        Timer1.Enabled = True
        Timer1.Start()
    End Sub


    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick

        GetData()

    End Sub
End Class