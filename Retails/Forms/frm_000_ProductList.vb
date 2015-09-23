Imports System.Data.SqlClient
Imports Retails.clsPublic
Imports System.Runtime.InteropServices

Public Class frm_000_ProductList


#Region "Variable"
    Implements IBPSCommand
    Implements IBPS_SEARCH
    Dim bolFormState As clsPublic.FormState
    Dim bolFilter As Boolean
    Dim strFilter As String
    Dim strFilterHead As String
    Dim strFilterField As String
    Dim BS As New BindingSource


#End Region


#Region "Procedure"


#Region "Search function"



    Dim tableName As String = "tbl_000_Product"
    Dim strSQL As String
    Dim da As SqlDataAdapter
    Dim ds As New DataSet
    Dim dv As DataView
    Dim scrollVal As Integer = 0
    Dim pageSize As Integer = 50
    Dim recordCount As Long = 0
    Dim pageCount As Integer = 0
    Dim currentPage As Integer = 1


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


    Sub RefreshRecord(ByVal sql As String, Optional ByVal inStart As Integer = Nothing, Optional ByVal inEnd As Integer = Nothing)

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

        'Call Addfields()

        Cursor = Cursors.Default
        connection.Close()
        validatevalue()
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

    Private Sub Paging()

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
                MainForm.tsSearch.Text = String.Empty
                RefreshRecord("GetProduct '" & MainForm.tsSearch.Text & "'")
            Case "Search"

        End Select
    End Sub


    Private Sub validatevalue()

        For Each row As DataGridViewRow In dgList.Rows
            If row.IsNewRow = False Then

                row.Cells("colunitprice").Value = FormatNumber(NZ(row.Cells("colunitprice").Value), CInt(row.Cells("coldec").Value))

            End If
        Next
    End Sub

    Sub DeleteRecord()
        Dim productcode As String = dgList.Item(0, dgList.CurrentRow.Index).Value
        If vbYes = MsgBox("Are you sure you want to delete this Product?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then

            RunQuery("Delete from tbl_000_Product where  ProductCode='" & productcode & "'")
            RefreshRecord("GetProduct '" & MainForm.tsSearch.Text & "'")


        End If
    End Sub

    Sub NewRecord()
        With frm_000_Product
            .MdiParent = MainForm
            .myParent = Me
            .bolFormState = FormState.AddState
            .Show()
            .Focus()
        End With
    End Sub

    Sub EditRecord()
        With frm_000_Product
            .ProCode = dgList.Item(0, dgList.CurrentRow.Index).Value
            .MdiParent = MainForm
            .myParent = Me
            .bolFormState = FormState.EditState
            .Show()
            .Focus()
        End With
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

    Private Sub frm_000_ProductList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_000_ProductList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Public Sub Addfields()
        For Each row As DataGridViewRow In dgList.Rows
            If row.IsNewRow = False Then
                row.Cells("colunitPrice").Value = FormatNumber(row.Cells("colunitPrice").Value, CInt(row.Cells("coldec").Value))
            End If
        Next

    End Sub
    Private Sub frm_000_ProductList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        CenterControl(lblTitle, Me)
        ActivateCommands(FormState.LoadState)
        RefreshRecord("GetProduct '" & MainForm.tsSearch.Text & "'")

    End Sub

    Private Sub dgList_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellEnter
        If dgList.RowCount > 0 Then
            ActivateCommands(FormState.ViewState)
        Else
            ActivateCommands(FormState.LoadState)
        End If
    End Sub

    Public Sub ProcessSearchData(ByVal str As String) Implements IBPS_SEARCH.ProcessSearchData
        RefreshRecord("GetProduct '" & str & "'")
    End Sub


    Private Sub tsPagination_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tsPagination.ItemClicked
        Select Case e.ClickedItem.ToString

            Case "Page:"
                Call Paging()
            Case "First Page"
                Call Navigate(Pagination.FirstPage)
            Case "Previous"
                Call Navigate(Pagination.PrevPage)
            Case "Next Page"
                Call Navigate(Pagination.NextPage)
            Case "Last Page"
                Call Navigate(Pagination.LastPage)

        End Select
    End Sub

    Private Sub dgList_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellValidated
        validatevalue()
    End Sub

#End Region


    Private Sub dgList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellContentClick

    End Sub
End Class