Imports System.Data.SqlClient
Imports Retails.clsPublic
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.IO.Directory

Public Class frm_000_ItemList

#Region "Variable"

    Implements IBPSCommand
    Implements IBPS_SEARCH


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



    Dim tableName As String = "tbl_000_ITEM_Sub"
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

    Public Sub ProcessSearchData(ByVal str As String) Implements IBPS_SEARCH.ProcessSearchData
        Call RefreshRecord("GetItemSub'" & MainForm.tsSearch.Text & "'")
    End Sub
    Sub ViewFilterBack()
        Call RefreshRecord("GetItemSub '" & cboItemCode.Text & "'")
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




    Public Sub navigationButton(ByVal isVergin As Boolean)
        btnback.Visible = isVergin
        btnNext.Visible = isVergin
    End Sub

    Sub LoadComboBox_DataTable()
        Try
            Dim sqlConn As New SqlConnection(cnString)
            Dim sqlReader As SqlDataReader
            Dim sqlCommand As New SqlCommand("GetItemCodes", sqlConn)
            Dim dtLoading As New DataTable("tbl_000_Item")

            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With cboItemCode
                .ColumnNum = 4
                .ColumnWidth = "100;200;200;200"
                .GridLineHorizontal = True
                .GridLineVertical = True
                ''.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(3) {"ItemCode", "ItemName", "Category", "SubCategory"}
                .SourceDataTable = dtLoading
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR item")
        End Try

    End Sub

    Sub FillTextBox()
        Try
            If Not cboItemCode.SelectedValue Is Nothing Then
                txtItemName.Text = cboItemCode.SelectedItem.Col2
                txtCategory.Text = cboItemCode.SelectedItem.Col3
                txtSubCategory.Text = cboItemCode.SelectedItem.Col4
            Else
                txtItemName.Text = String.Empty
                txtCategory.Text = String.Empty
                txtSubCategory.Text = String.Empty
            End If
            Call RefreshRecord("GetItemSub '" & cboItemCode.Text & "'")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try

    End Sub

    'Sub RefreshRecord()
    '    ''LoadComboBox_DataTable()
    '    ActivateCommands(FormState.LoadState)
    '    FillDataGrid(dgList, "GetItemSub '" & cboItemCode.Text & "'", 0, 9)


    'End Sub

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

                RefreshRecord("GetItemSub '" & cboItemCode.Text & "'")
            Case "Filter"
                Call FilterOn()
            Case "FilterClear"
                Call FilterClear()
        End Select
    End Sub

    Private Function GetImg(ByVal path As String) As Image
        Dim bm As Bitmap
        Dim currentpath As String = currPath & "\tmpIMG\" & dgList.Item(1, dgList.CurrentRow.Index).Value & ".png"
        Try
            If File.Exists(currentpath) Then
                If File.Exists(currentpath) Then
                    bm = New Bitmap(currentpath)
                    GetImg = bm
                End If

            Else
                If File.Exists(path) Then
                    bm = New Bitmap(path)
                    bm.Save(currPath & "\tmpIMG\" & dgList.Item(1, dgList.CurrentRow.Index).Value & ".png", _
                                   System.Drawing.Imaging.ImageFormat.Png)

                    bm = New Bitmap(currentpath)
                    GetImg = bm
                Else
                    GetImg = PictureBox1.Image
                End If



            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Function

    Sub DeleteRecord()
        If vbYes = MsgBox("Are you sure you want to delete this Item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then

            RunQuery("Delete tbl_000_Item_Sub where SpecificCode='" & dgList.Item(1, dgList.CurrentCell.RowIndex).Value & "' ")

            Call SaveAuditTrail("Delete Specific item code", dgList.Item(1, dgList.CurrentCell.RowIndex).Value)
            RefreshRecord("GetItemSub '" & cboItemCode.Text & "'")
            SelectDataGridViewRow(dgList)

        End If
    End Sub

    Sub NewRecord()
        With frm_000_Item
            .myParent = Me
            .bolFormState = FormState.AddState
            .ShowDialog()
        End With
    End Sub

    Sub EditRecord()
        With frm_000_Item
            .myParent = Me
            .bolFormState = FormState.EditState
            ._Picbox = New Bitmap(picPhoto.Image)
            .ShowDialog()
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
        Me.txtItemName.Focus()
        cboItemCode.Items.Clear()
        bolFormState = FormState.LoadState

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
            frmDeleteItem.frmparent = Me
            frmDeleteItem.ShowDialog()
            LoadComboBox_DataTable()
            Me.Refresh()
        End If
    End Sub

    Private Sub frm_000_ItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        LoadComboBox_DataTable()
        cboItemCode.Text = String.Empty
        picPhoto.Image = MainForm.picLogo.Image

        txtItemName.Focus()
        ActivateCommands(FormState.LoadState)

        Call RefreshRecord("GetItemSub '" & cboItemCode.Text & "'")
        inc = 0
        isnext = False

    End Sub

    Private Sub cboItemCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemCode.SelectedIndexChanged
        Call FillTextBox()
    End Sub

    Private Sub cboItemCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItemCode.Validated
        Call FillTextBox()
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

            _imagePath = strVarImgPath & dgList.Item(1, dgList.CurrentRow.Index).Value & ".png"

            picPhoto.Image = GetImg(_imagePath)


           
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try


    End Sub

    Private Sub SearchITemName()
        FillDataGrid(dgList, "sp_000_Get_ItemFromMasterFile '" & "itemname" & "','" & txtItemName.Text & "'", 0, 8)

        txtCategory.Text = String.Empty
        txtSubCategory.Text = String.Empty
        cboItemCode.SelectedIndex = -1
    End Sub

    Private Sub SearchCategory()
        FillDataGrid(dgList, "sp_000_Get_ItemFromMasterFile '" & "Category" & "','" & txtCategory.Text & "'", 0, 8)

        txtItemName.Text = String.Empty
        txtSubCategory.Text = String.Empty
        cboItemCode.SelectedIndex = -1
    End Sub

    Private Sub SearchSubCategory()
        FillDataGrid(dgList, "sp_000_Get_ItemFromMasterFile '" & "Sub-Category" & "','" & txtSubCategory.Text & "'", 0, 8)

        txtItemName.Text = String.Empty
        txtCategory.Text = String.Empty
        cboItemCode.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call SearchITemName()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call SearchCategory()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call SearchSubCategory()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        With frmPicFrame
            .Picbox1.Image = picPhoto.Image
            .ShowDialog()
        End With

    End Sub

#End Region




    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frm_SearchTransNO
            .ItemList = Me
            .param1 = "ItemList"

            If category <> String.Empty And value <> String.Empty Then
                .cboCategory.Text = category
                .txtValue.Text = value
            Else
                .cboCategory.Text = String.Empty
                .txtValue.Text = String.Empty
            End If
            .ShowDialog()
            Call RefreshRecord("GetItemSub '" & cboItemCode.Text & "'")
            rownum = inc


        End With
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If rownum <> 0 Then inc = rownum
        cboItemCode.Text = Navigation("sp_SearchITem_for_ISS'" & category & "','" & value & "'", "tbl_000_ITem", "ItemCode", "Next")
        Call RefreshRecord("GetItemSub '" & cboItemCode.Text & "'")
        rownum = inc
    End Sub

    Private Sub btnback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        If rownum <> 0 Then inc = rownum
        cboItemCode.Text = Navigation("sp_SearchITem_for_ISS'" & category & "','" & value & "'", "tbl_000_Item", "ItemCode", "Back")
        rownum = inc
        Call RefreshRecord("GetItemSub '" & cboItemCode.Text & "'")


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

    Private Sub dgList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellContentClick

    End Sub
End Class