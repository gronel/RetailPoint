Imports TOPCInventorySales.clsPublic

Public Class frm_000_Category

    Implements IBPSCommand

    Dim strDataGridSearchValue As String
    Dim CategoryCode As String
    Dim bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended

    Private Sub frm_000_User_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        setUserRights(Me.Tag)
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_000_User_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frm_000_Client_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.image


        RefreshRecord()

        LockFields(True)

        With ErrProvider
            .Controls.Add(txtCategoryCode, "Category Code")
            .Controls.Add(txtCategoryName, "Category Name")
        End With

        ActivateCommands(FormState.LoadState)

    End Sub

    Private Sub dgList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellEnter
        SetEditValue()
    End Sub


    Sub NewRecord()
        LockFields(False)
        ''grpList.Enabled = False
        ClearFields()
        txtCategoryCode.Focus()
        ActivateCommands(FormState.AddState)
    End Sub

    Sub EditRecord()
        LockFields(False)
        ''grpList.Enabled = False
        ActivateCommands(FormState.EditState)
        txtCategoryCode.ReadOnly = True
    End Sub

    Sub DeleteRecord()
        If isRecordExist("SELECT CategoryCode FROM tbl_000_Item WHERE CategoryCode='" & CategoryCode & "'") Then

        ElseIf vbYes = MsgBox("Are you sure you want to delete this Category?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
            _intDeletedRow = dgList.CurrentRow.Index
            _OpenTransaction()
            _Result = _DeleteRecord("tbl_000_Category", "WHERE CategoryCode='" & CategoryCode & "'")
            _CloseTransaction(_Result)
            If _Result Then
                RefreshRecord()
                doCancel()
                ClearFields()
                SelectDataGridViewRow(dgList)
            End If
        End If
    End Sub

    Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                NewRecord()
            Case "Edit"
                EditRecord()
            Case "Delete"
                DeleteRecord()
            Case "Save"
                SaveRecord()
            Case "Cancel"
                If vbYes = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm") Then
                    doCancel()
                End If
            Case "Refresh"
                RefreshRecord()
        End Select

    End Sub

    Sub RefreshRecord()
        ActivateCommands(FormState.LoadState)
        FillGrid(dgList, "GetCategory", "tbl_000_Category")
        lblRecordCount.Text = dgList.RowCount

    End Sub



    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        LockFields(True)
        ''grpList.Enabled = True
        ActivateCommands(FormState.LoadState)
    End Sub

    Sub SetEditValue()

        Dim category As New tbl_000_Category

        Try
            CategoryCode = dgList.Item(0, dgList.CurrentRow.Index).Value

            With category
                .FetchRecord(CategoryCode)
                txtCategoryCode.Text = .CategoryCode
                txtCategoryName.Text = .CategoryName
            End With

            FillDataGrid(dgSub, "GetCategorySub " & CategoryCode, 0, 1)

            LockFields(True)


            ActivateCommands(FormState.ViewState)


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            category = Nothing
        End Try
    End Sub

    Sub ClearFields()
        Try

            CategoryCode = String.Empty
            txtCategoryCode.Text = String.Empty
            txtCategoryName.Text = String.Empty
            dgSub.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Clear Fields")
        End Try
    End Sub

    Private Sub SaveRecord()

        Dim category As New tbl_000_Category
        Dim strResult As Boolean

        Try

            If ErrProvider.CheckAndShowSummaryErrorMessage = False Then

            ElseIf bolFormState = FormState.AddState And isRecordExist("SELECT CategoryCode FROM tbl_000_Category WHERE CategoryCode='" & txtCategoryCode.Text.Trim & "'") Then
                MsgBox("Category Code already exist.", MsgBoxStyle.Exclamation, "Duplicate")
            Else
                dgSub.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)

                With category
                    .CategoryCode = txtCategoryCode.Text.Trim
                    .CategoryName = txtCategoryName.Text.Trim

                    _OpenTransaction()
                    strResult = .Save(bolFormState = FormState.EditState, dgSub)
                    _CloseTransaction(strResult)
                End With

                If strResult Then
                    If bolFormState = FormState.EditState Then
                        MsgBox("Updated!", MsgBoxStyle.Information, "Updated")
                    Else
                        MsgBox("Saved!", MsgBoxStyle.Information, "Saved")
                    End If

                    strDataGridSearchValue = CategoryCode
                    RefreshRecord()
                    SelectDataGridViewRow(dgList, 0, strDataGridSearchValue)
                    doCancel()
                    SetEditValue()
                End If


            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Save Record")
        Finally
            category = Nothing
        End Try

    End Sub

    Sub LockFields(ByVal bolValue As Boolean)
        Try
            txtCategoryCode.ReadOnly = bolValue
            txtCategoryName.ReadOnly = bolValue
            dgSub.ReadOnly = bolValue

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Lock Fields")
        End Try
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
                Case FormState.LoadState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
            End Select

        End With
    End Sub
   
    Private Sub dgSub_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSub.CellValidated
        If dgSub.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "" Then
        Else
            Dim s As String = StrConv(dgSub.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString, VbStrConv.Uppercase)
            dgSub.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = s
        End If

    End Sub

    Private Sub dgSub_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgSub.CellValidating
        Select Case e.ColumnIndex
            Case 0
                If CheckCodeFromDatagridView(dgSub, 0, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                    MsgBox("Sub Category Code is already in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub dgSub_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSub.CellValueChanged
       
    End Sub

    Private Sub dgSub_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgSub.RowsAdded
        lblCountSub.Text = CountGridRows(dgSub)
    End Sub

    Private Sub dgSub_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgSub.RowsRemoved
        lblCountSub.Text = CountGridRows(dgSub)
    End Sub

    Private Sub frm_000_Category_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterControl(lblTitle, Me)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

   

    Private Sub dgList_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellValidated
        ''Convert all Lower case into Upper case value
        If dgList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "" Then ''set if the cell is empty then no convert
        Else
            Dim s As String = StrConv(dgList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString, VbStrConv.Uppercase) ''set the cell if not empty then convert all lower case into upper case
            dgList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = s
        End If

    End Sub
End Class