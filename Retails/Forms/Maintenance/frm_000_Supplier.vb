Imports RetailPoint.clsPublic
Imports System.Data.SqlClient
Public Class frm_000_Supplier

#Region "variable"
    Implements IBPSCommand
    Implements IBPS_SEARCH
    Dim strDataGridSearchValue As String
    Dim SupplierCode As String
    Dim bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Dim BS As New BindingSource

#End Region

#Region "Procedure"
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

    Sub NewRecord()
        LockFields(False)
        grpList.Enabled = False
        ClearFields()
        txtSupplierCode.Text = tbl_000_Supplier.GenerateID
        txtSupplierName.Focus()
        txtSupplierCode.ReadOnly = True
        ActivateCommands(FormState.AddState)
    End Sub

    Sub EditRecord()
        LockFields(False)
        grpList.Enabled = False
        txtSupplierCode.ReadOnly = True
        ActivateCommands(FormState.EditState)
    End Sub

    Sub DeleteRecord()
        SupplierCode = dgList.Item("colSupplierCode", dgList.CurrentRow.Index).Value
        If grpProfile.Enabled Then
            If vbYes = MsgBox("Are you sure you want to delete this Supplier?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then

                RunQuery("Delete tbl_000_Supplier where SupplierID=" & SupplierCode)
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
            Case "Search"

        End Select

    End Sub

    Private Sub SearchRecord(ByVal strvalue As String)
        Try

            Dim strSQL As String

            strSQL = dgList.Columns(0).DataPropertyName & " LIKE '%" & strvalue & "%' or " & _
            dgList.Columns(1).DataPropertyName & " LIKE '%" & strvalue & "%'"

            Me.BS.RemoveFilter()

            Me.BS.Filter = strSQL

            dgList.DataSource = BS
            lblRecordCount.Text = dgList.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR [Search]")
        End Try
    End Sub
    Sub RefreshRecord()
        Try
            ActivateCommands(FormState.ViewState)


            MainForm.tsSearch.Clear()
            ''Call ClearFilter()
            Dim myconn As SqlConnection = New SqlConnection(cnString)
            Dim da As SqlDataAdapter = New SqlDataAdapter("GetSupplier", myconn)
            Dim ds As DataSet = New DataSet()
            ds.Clear()
            da.Fill(ds, "tbl_000_Supplier")
            BS.DataSource = ds.Tables(0)
            dgList.DataSource = BS
            lblRecordCount.Text = dgList.RowCount
            ActivateCommands(FormState.LoadState)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        LockFields(True)
        grpList.Enabled = True
        ActivateCommands(FormState.ViewState)
        ClearFields()
    End Sub

    Sub SetEditValue()

        Dim Supplier As New tbl_000_Supplier

        Try
            SupplierCode = dgList.Item("colSupplierCode", dgList.CurrentRow.Index).Value

            With Supplier
                .FetchRecord(SupplierCode)
                txtSupplierCode.Text = .SupplierID
                txtSupplierName.Text = .SupplierName
                txtAddress.Text = .Address
                txtTelNo.Text = .TelNo
                txtFaxNo.Text = .FaxNo
                txtCellNo.Text = .CellNo
                txtWebsite.Text = .Website
                dtDate.Text = .Accreditation
                cboSupType.SelectedValue = .SupplierType
                cboComCategory.SelectedValue = .ComCategory
                cboPayTerms.SelectedValue = .PayTerms
                txtCPName.Text = .CPName
                txtDesignation.Text = .Designation
                txtDepartment.Text = .Department
                txtEmail.Text = .Email
                txtremarks.Text = .Remarks
            End With

            LockFields(True)

            ActivateCommands(FormState.ViewState)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Supplier = Nothing
        End Try

    End Sub

    Sub ClearFields()
        Try
            SupplierCode = String.Empty
            txtSupplierCode.Text = String.Empty
            txtSupplierName.Text = String.Empty
            txtAddress.Text = String.Empty
            txtTelNo.Text = String.Empty
            txtFaxNo.Text = String.Empty
            txtCellNo.Text = String.Empty
            txtWebsite.Text = String.Empty
            txtCPName.Text = String.Empty
            txtDesignation.Text = String.Empty
            txtDepartment.Text = String.Empty
            txtEmail.Text = String.Empty
            txtremarks.Text = String.Empty
            dtDate.Text = Now
            cboSupType.SelectedValue = 1
            cboComCategory.SelectedValue = 1
            cboPayTerms.SelectedValue = 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Clear Fields")
        End Try
    End Sub

    Private Sub SaveRecord()

        Dim Supplier As New tbl_000_Supplier
        Dim strResult As Boolean
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then

                If bolFormState = FormState.AddState And isRecordExist("SELECT SupplierID FROM tbl_000_Supplier WHERE SupplierID='" & txtSupplierCode.Text.Trim & "'") Then
                    ''ErrProvider.SetError(txtSupplierCode, "Existing Supplier Code")
                    txtSupplierCode.Text = tbl_000_Supplier.GenerateID
                    SaveRecord()
                Else
                    ErrorProvider1.SetError(txtSupplierCode, "")
                    With Supplier
                        .SupplierID = txtSupplierCode.Text.Trim
                        .SupplierName = txtSupplierName.Text.Trim
                        .Address = txtAddress.Text.Trim
                        .TelNo = txtTelNo.Text.Trim
                        .FaxNo = txtFaxNo.Text.Trim
                        .CellNo = txtCellNo.Text.Trim
                        .Website = txtWebsite.Text.Trim
                        .Accreditation = CDate(dtDate.Text)
                        .SupplierType = cboSupType.SelectedValue
                        .ComCategory = cboComCategory.SelectedValue
                        .PayTerms = cboPayTerms.SelectedValue
                        .CPName = txtCPName.Text
                        .Designation = txtDesignation.Text
                        .Department = txtDepartment.Text
                        .Email = txtEmail.Text
                        .Remarks = txtremarks.Text
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
                        strDataGridSearchValue = SupplierCode
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
            Supplier = Nothing
        End Try

    End Sub

    Sub LockFields(ByVal bolValue As Boolean)
        Try
            txtSupplierCode.ReadOnly = bolValue
            txtSupplierName.ReadOnly = bolValue
            txtAddress.ReadOnly = bolValue
            txtTelNo.ReadOnly = bolValue
            txtFaxNo.ReadOnly = bolValue
            txtCellNo.ReadOnly = bolValue
            txtWebsite.ReadOnly = bolValue
            txtCPName.ReadOnly = bolValue
            txtDesignation.ReadOnly = bolValue
            txtDepartment.ReadOnly = bolValue
            txtEmail.ReadOnly = bolValue
            txtremarks.ReadOnly = bolValue
            dtDate.Enabled = Not bolValue
            cboSupType.Enabled = Not bolValue
            cboComCategory.Enabled = Not bolValue
            cboPayTerms.Enabled = Not bolValue


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
                    .tsSearch.Enabled = True
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


#End Region

#Region "GUI"
    Private Sub frm_000_Supplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        RefreshRecord()

        LockFields(True)

        With ErrProvider
            .Controls.Clear()
            .Controls.Add(txtSupplierCode, "Supplier Code")
            .Controls.Add(txtSupplierName, "Supplier Name")
            .Controls.Add(txtAddress, "Address")
            .Controls.Add(cboSupType, "Supplier Type")
            .Controls.Add(cboComCategory, "Category")
            .Controls.Add(cboPayTerms, "Payment Terms")

        End With

        FillCombobox(cboSupType, "SELECT SupTypeID, SupTypeName FROM tbl_000_Supplier_Type", "tbl_000_Supplier_Type", "SupTypeName", "SupTypeID")
        FillCombobox(cboComCategory, "SELECT ComCatID, ComCatName FROM tbl_000_Supplier_ComCategory", "tbl_000_Supplier_ComCategory", "ComCatName", "ComCatID")
        FillCombobox(cboPayTerms, "SELECT PayTermsID, PayTermsName FROM tbl_000_Supplier_PayTerms", "tbl_000_Supplier_PayTerms", "PayTermsName", "PayTermsID")

        ActivateCommands(FormState.LoadState)

    End Sub

    Private Sub dgList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellEnter
        SetEditValue()
    End Sub

    Private Sub frm_000_Supplier_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterControl(lblTitle, Me)
    End Sub

    Public Sub ProcessSearchData(ByVal str As String) Implements IBPS_SEARCH.ProcessSearchData
        Call SearchRecord(str)
    End Sub

#End Region

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
End Class