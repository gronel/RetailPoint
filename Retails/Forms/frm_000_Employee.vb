Imports Retails.clsPublic
Public Class frm_000_Employee

#Region "Variable"
    Public myparent As frm_000_Employee_List
    Public bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Dim oldDepartment As String
    Dim oldSection As String
    Public empid As String

#End Region

#Region "Procedure"

    Sub SetEditValue()

        Dim user As New tbl_000_Employee
        Dim tmpImage As Image = Nothing

        Try
            empid = myparent.dgList.Item(0, myparent.dgList.CurrentRow.Index).Value


            With user
                .FetchRecord(empid)
                txtEmpID.Text = .EmpID
                txtfname.Text = .FirstName
                txtlname.Text = .LastName
                txtmname.Text = .MiddleName
                cboDesignation.Text = .Designation
                cboEmpStatus.Text = .EmpStatus
                chkIsActive.Checked = .ISActive
                picPhoto.Image = BytesToImage(.EmpPic)

                cboDepartment.Text = .DepartmentCode
                cboSection.Text = .SectionCode
                cboLine.Text = .LineCode


            End With
            txtEmpID.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            user = Nothing
        End Try
    End Sub

    Sub clear()
        txtEmpID.Clear()
        txtfname.Clear()
        txtlname.Clear()
        txtmname.Clear()
        cboDesignation.Text = ""
        cboEmpStatus.Text = ""
        chkIsActive.Checked = True
        picPhoto.Image = MainForm.picDefault.Image
    End Sub

    Sub FillSection()
        If Not cboDepartment.SelectedValue Is Nothing Then

        Else

        End If
        If oldDepartment <> cboDepartment.Text Then
            cboSection.Text = String.Empty

            cboLine.Text = String.Empty

            LoadSectionToMultiCombo(cboSection, cboDepartment.Text)
        End If
    End Sub


    Sub FillLine()
        If Not cboSection.SelectedValue Is Nothing Then

        Else

        End If
        If oldSection <> cboSection.Text Then
            cboLine.Text = String.Empty

            LoadLineToMultiCombo(cboLine, cboSection.Text)
        End If
    End Sub

    Sub FillLineTextBox()
        If Not cboLine.SelectedValue Is Nothing Then

        Else

        End If
    End Sub


    Private Sub SaveRecord()

        Dim user As New tbl_000_Employee
        Dim strResult As Boolean

        Try

            If ErrProvider.CheckAndShowSummaryErrorMessage Then

                If bolFormState = FormState.AddState And isRecordExist("SELECT Empid FROM tbl_000_Employee WHERE empid='" & txtEmpID.Text & "'") Then
                    ErrorProvider1.SetError(txtEmpID, "EmpID is already exist!")
                ElseIf cboDepartment.Text = String.Empty Then
                    MsgBox("Department is required", MsgBoxStyle.Exclamation, "Prompt")
                Else


                    With user
                        .EmpID = txtEmpID.Text
                        .FirstName = txtfname.Text
                        .LastName = txtlname.Text
                        .MiddleName = txtmname.Text
                        .Designation = cboDesignation.Text
                        .EmpStatus = cboEmpStatus.Text
                        .ISActive = chkIsActive.Checked
                        .EmpPic = ImageToByte(picPhoto.Image)
                        .DepartmentCode = cboDepartment.Text
                        .SectionCode = cboSection.Text
                        .LineCode = cboLine.Text
                        _OpenTransaction()
                        strResult = .Save(bolFormState = FormState.EditState)
                        _CloseTransaction(strResult)
                    End With

                    If strResult Then
                        If bolFormState = FormState.EditState Then
                            MsgBox("Updated!", MsgBoxStyle.Information, "Updated")
                        Else
                            MsgBox("Saved!", MsgBoxStyle.Information, "Saved")
                        End If
                        myparent.RefreshRecord()
                        Me.Close()

                    End If


                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Save Record")
        Finally
            user = Nothing
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

    Private Sub frm_000_Employee_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        If bolFormState = FormState.EditState Then
            SetEditValue()

        Else
            txtEmpID.Enabled = True
            cboDesignation.Text = ""
            cboEmpStatus.Text = ""
        End If
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_000_Employee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
            'ElseIf e.Control = True And e.KeyCode = Keys.S And MainForm.tsSave.Visible = True And MainForm.tsSave.Enabled = True Then
            '    ProcessFormCommand("Save")
        End If
    End Sub

    Private Sub frm_000_Employee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ErrProvider 'Get the error or empty text
            .Controls.Clear()
            .Controls.Add(txtEmpID, "Employee ID")
            .Controls.Add(txtfname, "First Name")
            .Controls.Add(txtlname, "Last Name")
            .Controls.Add(cboDesignation, "Designation")
            .Controls.Add(cboEmpStatus, "Emp status")

        End With
        FillCombobox(cboDesignation, "Select Designation from tbl_000_Employee where IsActive = 1 group by Designation", "tbl_000_Employee", "Designation", "Designation")
        FillCombobox(cboEmpStatus, "Select EmpStatus from tbl_000_Employee where IsActive = 1 group by EmpStatus", "tbl_000_Employee", "EmpStatus", "EmpStatus")
        LoadDepartmentToMultiCombo(cboDepartment)
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Call BrowsePhoto(picPhoto)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Call SaveRecord()
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartment.SelectedIndexChanged
        Call FillSection()
    End Sub

    Private Sub cboSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSection.SelectedIndexChanged
        Call FillLine()
    End Sub

    Private Sub cboDepartment_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartment.Validated
        Call FillSection()
    End Sub

    Private Sub cboSection_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSection.Validated
        Call FillLine()
    End Sub

    Private Sub cboLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLine.SelectedIndexChanged
        Call FillLineTextBox()
    End Sub

    Private Sub cboLine_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLine.Validated
        Call FillLineTextBox()
    End Sub
#End Region


End Class