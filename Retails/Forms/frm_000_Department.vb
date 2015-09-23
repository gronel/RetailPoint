Imports Retails.clsPublic

Public Class frm_000_Department

    Implements IBPSCommand

    Dim department As New tbl_000_Department

    Dim strDataGridSearchValue As String
    Dim DepartmentCode As String
    Dim bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended

    Private Sub frm_000_Department_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_000_Department_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frm_000_Department_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        RefreshRecord()
        LockFields(True)
        FillCombobox(cboLevel, "SELECT DepartmentLevel, DepartmentLevelName FROM tbl_000_Department_Level", "tbl_000_Department_Level", "DepartmentLevelName", "DepartmentLevel")
        FillCombobox(cboParent, "SELECT DepartmentCode, DepartmentName FROM tbl_000_Department", "tbl_000_Department", "DepartmentName", "DepartmentCode")
        ParentLabel.Visible = False
        cboParent.Visible = False
        ActivateCommands(FormState.LoadState)
    End Sub

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
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

    Sub NewRecord()
        LockFields(False)
        ''grpList.Enabled = False
        tvwDepartment.Enabled = False
        ClearFields()
        txtCode.ReadOnly = False
        txtCode.Focus()
        ActivateCommands(FormState.AddState)
    End Sub

    Sub EditRecord()
        LockFields(False)
        ''grpList.Enabled = False
        tvwDepartment.Enabled = False
        ActivateCommands(FormState.EditState)
        txtCode.ReadOnly = True
    End Sub

    Sub DeleteRecord()
        ' If isRecordExist("SELECT CategoryCode FROM tbl_000_Item WHERE CategoryCode='" & DepartmentCode & "'") Then

        If vbYes = MsgBox("Are you sure you want to delete this Department?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
            ''_intDeletedRow = dgList.CurrentRow.Index
            _OpenTransaction()
            _Result = _DeleteRecord("tbl_000_Department", "WHERE DepartmentCode='" & DepartmentCode & "'")
            _CloseTransaction(_Result)

            If _Result Then
                RefreshRecord()
                doCancel()
                ClearFields()
                ''SelectDataGridViewRow(dgList)
            End If
        End If
    End Sub

    Sub SaveRecord()
        Try

            If ErrProvider.CheckAndShowSummaryErrorMessage = False Then

            ElseIf bolFormState = FormState.AddState And isRecordExist("SELECT DepartmentCode FROM tbl_000_Department WHERE DepartmentCode='" & txtCode.Text.Trim & "'") Then
                MsgBox("Category Code already exist.", MsgBoxStyle.Exclamation, "Duplicate")
            ElseIf cboLevel.SelectedValue Is Nothing Then
                'MsgBox("Please select Department Level.", MsgBoxStyle.Exclamation, "Save")
                ErrProvider.SetError(cboLevel, "Invalid")
                'ElseIf cboParent.SelectedValue Is Nothing Then
                '    'MsgBox("Please select Department Level.", MsgBoxStyle.Exclamation, "Save")
                '    ErrProvider.SetError(cboParent, "Invalid")
            Else
                
                With department
                    .DepartmentCode = txtCode.Text.Trim
                    .DepartmentName = txtName.Text.Trim
                    .DepartmentLevel = cboLevel.SelectedValue
                    '.DepartmentParent = IIf(cboParent.SelectedValue Is Nothing, "", cboParent.SelectedValue)
                    '.DepartmentParent = cboParent.SelectedValue
                    If cboLevel.SelectedValue = 1 Then
                        .DepartmentParent = ""
                    Else
                        .DepartmentParent = cboParent.SelectedValue
                    End If
                    _OpenTransaction()
                    _Result = .Save(bolFormState = FormState.EditState)
                    _CloseTransaction(_Result)
                End With

                If _Result Then
                    If bolFormState = FormState.EditState Then
                        MsgBox("Updated!", MsgBoxStyle.Information, "Updated")
                    Else
                        MsgBox("Saved!", MsgBoxStyle.Information, "Saved")
                    End If

                    strDataGridSearchValue = DepartmentCode
                    RefreshRecord()
                    ''SelectDataGridViewRow(dgList, 0, strDataGridSearchValue)
                    doCancel()
                    ClearFields()
                    ''SetEditValue()
                End If


            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Save Record")
        Finally

        End Try

    End Sub

    Sub SetEditValue()

        Try
            If Not tvwDepartment.SelectedNode Is Nothing Then
                DepartmentCode = tvwDepartment.SelectedNode.Tag

                With department
                    .FetchRecord(DepartmentCode)
                    txtCode.Text = .DepartmentCode
                    txtName.Text = .DepartmentName
                    cboLevel.SelectedValue = .DepartmentLevel
                    cboParent.SelectedValue = .DepartmentParent
                End With

                LockFields(True)
                ActivateCommands(FormState.ViewState)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        LockFields(True)
        ''grpList.Enabled = True
        tvwDepartment.Enabled = True
        ActivateCommands(FormState.LoadState)
    End Sub

    Sub LockFields(ByVal bolValue As Boolean)
        Try
            txtCode.ReadOnly = bolValue
            txtName.ReadOnly = bolValue
            cboLevel.Enabled = Not bolValue
            cboParent.Enabled = Not bolValue

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Lock Fields")
        End Try
    End Sub

    Sub ClearFields()
        Try

            DepartmentCode = String.Empty
            txtCode.Text = String.Empty
            txtName.Text = String.Empty
            cboLevel.SelectedIndex = -1
            cboParent.SelectedIndex = -1
            cboParent.Visible = False
            ParentLabel.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Clear Fields")
        End Try
    End Sub

    Sub RefreshRecord()
        department.LoadDepartmentTreeView(tvwDepartment)
        tvwDepartment.ExpandAll()
        ActivateCommands(FormState.LoadState)
        lblRecordCount.Text = department.count
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

    Private Sub frm_000_Department_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterControl(lblTitle, Me)
    End Sub

    Private Sub cboLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLevel.SelectedIndexChanged
        If cboLevel.SelectedIndex <> -1 Then
            If cboLevel.SelectedValue.ToString = "1" Then
                cboParent.Visible = False
                ParentLabel.Visible = False
                ''cboParent.Items.Clear()
                cboParent.Text = ""
            Else
                cboParent.Visible = True
                ParentLabel.Visible = True
                If cboLevel.SelectedValue.ToString <> "System.Data.DataRowView" Then
                    FillCombobox(cboParent, "SELECT DepartmentCode, DepartmentName FROM tbl_000_Department WHERE DepartmentLevel = '" _
                    & CDbl(cboLevel.SelectedValue.ToString) - 1 & "'", "tbl_000_Department", "DepartmentName", "DepartmentCode")
                End If
                cboParent.Text = ""
            End If
        End If
    End Sub

    Private Sub tvwDepartment_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwDepartment.AfterSelect
        SetEditValue()
    End Sub
End Class