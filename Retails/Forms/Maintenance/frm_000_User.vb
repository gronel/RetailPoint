Imports RetailPoint.clsPublic
Imports System.Data.SqlClient
Public Class frm_000_User

#Region "Variable"

    Implements IBPSCommand

    Dim strDataGridSearchValue As String
    Dim UserID As Integer
    Dim bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Dim strName As String

    Private _UserPic As Byte()
    Private _EmpName As String

#End Region


#Region "User Defination"


    Public Function BrowsePhoto(ByVal pic As PictureBox) As String
        Try

            Dim dlg As New OpenFileDialog()
            dlg.Title = "Browse Photo"
            dlg.Filter = "All Picture Files)|*.jpg;*.bmp;*.jpeg;*.gif;*.png"
            Dim dlgRes As DialogResult = dlg.ShowDialog()

            'Ask user to select file.
            If dlgRes <> DialogResult.Cancel Then
                'Set image in picture box
                pic.ImageLocation = dlg.FileName

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "BrowsePhoto")
        End Try

    End Function
    Sub NewRecord()
        LockFields(False)
        grpList.Enabled = False
        ClearFields()

        ActivateCommands(FormState.AddState)
    End Sub

    Sub EditRecord()
        LockFields(False)
        grpList.Enabled = False
        ActivateCommands(FormState.EditState)
    End Sub

    Sub DeleteRecord()
        If vbYes = MsgBox("Are you sure you want to delete this bank?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
            _OpenTransaction()
            _Result = _DeleteRecord("tbl_000_User", "WHERE UserID=" & UserID & "")
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
        FillGrid(dgList, "SELECT UserID, EmpID, EmpName FROM tbl_000_User", "tbl_000_User")
        lblRecordCount.Text = dgList.RowCount

    End Sub

    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        LockFields(True)
        grpList.Enabled = True
        ActivateCommands(FormState.LoadState)
    End Sub

    Sub SetEditValue()

        Dim user As New tbl_000_User
        Dim tmpImage As Image = Nothing

        Try
            UserID = dgList.Item(0, dgList.CurrentRow.Index).Value


            With user
                .FetchRecord(UserID)
                txtuserId.Text = .EmpID
                txtEmpName.Text = .EmpName
                txtUsername.Text = .UserName
                txtPassword.Text = .UserPassword
                txtVerify.Text = .UserPassword
                cboGroup.Text = .UserGroup
                chkIsActive.Checked = .isActive
                picPhoto.Image = BytesToImage(.UserPic)
            End With

            FillDataGrid(dgRights, "GetUserRights " & UserID, 0, 6)

            LockFields(True)


            ActivateCommands(FormState.ViewState)


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            user = Nothing
        End Try
    End Sub

    Sub ClearFields()
        Try

            UserID = 0
            txtuserId.Text = String.Empty
            txtEmpName.Text = String.Empty
            txtUsername.Text = String.Empty
            txtPassword.Text = String.Empty
            txtVerify.Text = String.Empty
            cboGroup.SelectedIndex = -1
            chkIsActive.Checked = True
            picPhoto.Image = MainForm.picDefault.Image
            dgRights.Rows.Clear()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Clear Fields")
        End Try
    End Sub

    Private Sub SaveRecord()

        Dim user As New tbl_000_User
        Dim strResult As Boolean

        Try

            If ErrProvider.CheckAndShowSummaryErrorMessage Then

                If txtPassword.Text.Trim <> txtVerify.Text.Trim Then
                    MsgBox("Password does not match!", MsgBoxStyle.Exclamation, "Failed")
                ElseIf bolFormState = FormState.AddState And isRecordExist("SELECT EmpID FROM tbl_000_User WHERE EmpID='" & txtuserId.Text.Trim & "'") Then
                    MsgBox("Employee ID already exist.", MsgBoxStyle.Exclamation, "Duplicate")
                ElseIf bolFormState = FormState.AddState And isRecordExist("SELECT UserName FROM tbl_000_User WHERE UserName='" & txtUsername.Text.Trim & "'") Then
                    MsgBox("User Name already exist.", MsgBoxStyle.Exclamation, "Duplicate")
                ElseIf bolFormState = FormState.EditState And isRecordExist("SELECT EmpID FROM tbl_000_User WHERE EmpID='" & txtuserId.Text.Trim & "' AND UserID<>" & UserID) Then
                    MsgBox("Employee ID already exist.", MsgBoxStyle.Exclamation, "Duplicate")
                ElseIf bolFormState = FormState.EditState And isRecordExist("SELECT UserName FROM tbl_000_User WHERE UserName='" & txtUsername.Text.Trim & "' AND UserID<>" & UserID) Then
                    MsgBox("User Name already exist.", MsgBoxStyle.Exclamation, "Duplicate")
                ElseIf dgRights.RowCount = 0 Then
                    MsgBox("Please add user rights.", MsgBoxStyle.Exclamation, "No Rights")
                Else
                    dgRights.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)

                    With user
                        .UserID = UserID
                        .EmpID = txtuserId.Text.Trim
                        .EmpName = txtEmpName.Text.Trim
                        .UserName = txtUsername.Text.Trim
                        .UserGroup = cboGroup.Text.Trim
                        .UserPassword = txtPassword.Text.Trim
                        .isActive = chkIsActive.Checked
                        .UserPic = ImageToByte(picPhoto.Image)

                        _OpenTransaction()
                        strResult = .Save(bolFormState = FormState.EditState, dgRights)
                        _CloseTransaction(strResult)
                    End With

                    If strResult Then
                        If bolFormState = FormState.EditState Then
                            MsgBox("Updated!", MsgBoxStyle.Information, "Updated")
                        Else
                            MsgBox("Saved!", MsgBoxStyle.Information, "Saved")
                        End If

                        strDataGridSearchValue = UserID
                        RefreshRecord()
                        SelectDataGridViewRow(dgList, 0, strDataGridSearchValue)
                        doCancel()
                        SetEditValue()
                    End If


                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Save Record")
        Finally
            user = Nothing
        End Try

    End Sub

    Sub LockFields(ByVal bolValue As Boolean)
        Try


            txtuserId.Enabled = Not bolValue
            txtEmpName.ReadOnly = bolValue
            txtUsername.ReadOnly = bolValue
            txtPassword.ReadOnly = bolValue
            cboGroup.Enabled = Not bolValue
            txtVerify.ReadOnly = bolValue
            chkIsActive.Enabled = Not bolValue
            dgRights.ReadOnly = bolValue
            colFormName.ReadOnly = True
            btnAdd.Enabled = Not bolValue
            btnRemove.Enabled = Not bolValue
            btnBrowse.Enabled = Not bolValue


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

    Sub _checkFucntion(ByVal bolvalue As Boolean, ByVal str As String)

        With dgRights
            If .ReadOnly = False Then
                For i = 0 To .RowCount - 1
                    .Item(str, i).Value = bolvalue
                    txtuserId.Focus()

                Next
            End If
        End With

    End Sub

    

#End Region

#Region "GUI"

    Private Sub frm_000_User_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_000_User_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        picLogo.Image = MainForm.picLogo.Image
        RefreshRecord()

        LockFields(True)

        With ErrProvider
            .Controls.Add(txtuserId, "Employee ID")
            .Controls.Add(txtEmpName, "Employee Name")
            .Controls.Add(txtUsername, "User Name")
            .Controls.Add(cboGroup, "User Group")
            .Controls.Add(txtPassword, "Password")
            .Controls.Add(txtVerify, "Verify Password")
        End With

        ActivateCommands(FormState.LoadState)

        MainForm.tsSearch.Enabled = False
    End Sub

    Private Sub dgList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellEnter
        SetEditValue()
    End Sub


    Private Sub dgRights_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRights.CellContentClick
        Dim intCheckAll As Integer = dgRights.Columns("colCheckAll").Index
        Dim intUncheckAll As Integer = dgRights.Columns("colUnCheckAll").Index

        If e.ColumnIndex = intCheckAll Then
            CheckAll(True, e.RowIndex)
        ElseIf e.ColumnIndex = intUncheckAll Then
            CheckAll(False, e.RowIndex)
        End If

    End Sub

    Sub CheckAll(ByVal bolValue As Boolean, ByVal intRowIndex As Integer)

        With dgRights
            If .ReadOnly = False Then
                .Item("colCanAdd", intRowIndex).Value = bolValue
                .Item("colCanEdit", intRowIndex).Value = bolValue
                .Item("colCanDelete", intRowIndex).Value = bolValue
                .Item("colCanView", intRowIndex).Value = bolValue
                .Item("colCanPrint", intRowIndex).Value = bolValue
            End If

        End With
    End Sub
 
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

        ''For Each row As DataGridViewRow In dgRights.SelectedRows
        ''    dgRights.Rows.Remove(row)
        ''Next

        RemoveFromDataGrid(dgRights)


    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frm_000_UserRights.myParent = Me
        frm_000_UserRights.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BrowsePhoto(picPhoto)
    End Sub

    Private Sub dgRights_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgRights.RowsAdded

        lblCountSub.Text = CountGridRows(dgRights)
        btnRemove.Enabled = True

    End Sub

    Private Sub dgRights_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgRights.RowsRemoved
        lblCountSub.Text = CountGridRows(dgRights)
        If dgRights.RowCount > 0 Then
            btnRemove.Enabled = True
        Else
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub frm_000_User_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterControl(lblTitle, Me)
    End Sub


  

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub CkeckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkeckToolStripMenuItem.Click

        With dgRights
            If .SelectedCells.Count = 0 Then Exit Sub
            strName = .Columns(.CurrentCell.ColumnIndex).Name
            _checkFucntion(True, strName)
        End With

    End Sub

    Private Sub UncheckAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UncheckAllToolStripMenuItem.Click
        With dgRights
            If .SelectedCells.Count = 0 Then Exit Sub
            strName = .Columns(.CurrentCell.ColumnIndex).Name

            _checkFucntion(False, strName)

        End With
    End Sub

 

#End Region


    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Call BrowsePhoto(picPhoto)
    End Sub
End Class