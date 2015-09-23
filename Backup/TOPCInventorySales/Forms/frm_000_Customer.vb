Imports TOPCInventorySales.clsPublic

Public Class frm_000_Customer
#Region "Variable"

    Public myParent As frm_000_CustomerList
    Public bolFormState As clsPublic.FormState
    Public customerCode As String
    Public customer As New tbl_000_Customer
    Dim ErrProvider As New ErrorProviderExtended

#End Region

#Region "Procedure"

    Private Sub ClearFields()
        txtfaxno.Text = String.Empty
        txtCustomerCode.Text = String.Empty
        txtCustomerName.Text = String.Empty
        txtAddress.Text = String.Empty
        txtWebsite.Text = String.Empty
        txtDesignation.Text = String.Empty
        txtDepartment.Text = String.Empty
        txtEmail.Text = String.Empty
        txtTelNo.Text = String.Empty
        txtCellNo.Text = String.Empty
        txtContactPerson.Text = String.Empty
        cboPaymentTerms.SelectedIndex = -1

        dtAccreditationDate.Text = FormatDateTime(dtAccreditationDate.Text, DateFormat.ShortDate)
        ClearDatGridView(dgProduct)
    End Sub

    Sub FillPaymentTerms()
        FillCombobox(cboPaymentTerms, "SELECT PayTermsID,PayTermsName FROM " & _
                     " tbl_000_Customer_PayTerms ORDER BY PayTermsName", "tbl_000_Customer_PayTerms", _
                     "PayTermsName", "PayTermsID")
    End Sub

    Private Sub SaveRecord()
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("SELECT CustomerCode FROM tbl_000_Customer WHERE CustomerCode='" & txtCustomerCode.Text.Trim & "'") Then
                    MsgBox("Customer Code already exist.", MsgBoxStyle.Exclamation, "Duplicate")
                ElseIf bolFormState = FormState.AddState And isRecordExist("SELECT CustomerName FROM tbl_000_Customer WHERE CustomerName='" & txtCustomerName.Text.Trim & "'") Then
                    MsgBox("Customer Name already exist.", MsgBoxStyle.Exclamation, "Duplicate")

                Else
                    With customer
                        .CustomerCode = txtCustomerCode.Text
                        .CustomerName = txtCustomerName.Text
                        .Address = txtAddress.Text
                        .Website = txtWebsite.Text
                        .ContactPerson = txtContactPerson.Text
                        .Designation = txtDesignation.Text
                        .Email = txtEmail.Text
                        .Department = txtDepartment.Text
                        .TelNo = txtTelNo.Text
                        .CellNo = txtCellNo.Text
                        .AccreditationDate = dtAccreditationDate.Text
                        .PaymentTerms = cboPaymentTerms.SelectedValue
                        .IsStatus = chkIsActive.Checked
                        .Fax = txtfaxno.Text
                        _OpenTransaction()
                        _Result = .Save(bolFormState = clsPublic.FormState.EditState)
                        _CloseTransaction(_Result)
                    End With

                    If _Result Then

                        If bolFormState = FormState.EditState Then
                            MsgBox("Update Complete", MsgBoxStyle.Information, "Prompt")
                        Else
                            MsgBox("Save Complete", MsgBoxStyle.Information, "Prompt")
                        End If

                        ClearFields()
                        myParent.RefreshRecord("GetCustomer'" & MainForm.tsSearch.Text & "'")
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
        End Try
    End Sub

    Private Sub SetEditValue()
        Try
            With customer
                .FetchRecord(customerCode)
                txtCustomerCode.Text = .CustomerCode
                txtCustomerName.Text = .CustomerName
                txtAddress.Text = .Address
                txtContactPerson.Text = .ContactPerson
                txtDesignation.Text = .Designation
                txtWebsite.Text = .Website
                txtEmail.Text = .Email
                txtDepartment.Text = .Department
                txtTelNo.Text = .TelNo
                txtCellNo.Text = .CellNo
                dtAccreditationDate.Text = .AccreditationDate
                cboPaymentTerms.SelectedValue = .PaymentTerms
                chkIsActive.Checked = .IsStatus
                txtfaxno.Text = .Fax
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub

    Private Sub numrows()
        'For i As Integer = 0 To dgProduct.Rows.Count - 1
        '    dgProduct.Rows(i).HeaderCell.Value = i.ToString()
        'Next i
    End Sub

    Private Sub ValidateRow()
        For Each row As DataGridViewRow In dgProduct.Rows
            If row.IsNewRow = False Then
                row.Cells("colUnitPrice").Value = FormatNumber(row.Cells("colUnitPrice").Value, CInt(row.Cells("coldec").Value))
            End If
        Next
    End Sub

#End Region

#Region "Gui"
    Private Sub frm_000_Customer_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bolFormState = FormState.AddState Then
            txtCustomerCode.Focus()
        Else
            txtCustomerName.Focus()
        End If
    End Sub

    Private Sub frm_000_Customer_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ErrProvider.ClearAllErrorMessages()
    End Sub

    Private Sub frm_000_Customer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frm_000_Customer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CenterForm(Me)
        Call ClearFields()
        With ErrProvider
            .Controls.Clear()
            .Controls.Add(txtCustomerCode, "Customer Code")
            .Controls.Add(txtCustomerName, "Company Name")
            .Controls.Add(txtAddress, "Address")
            .Controls.Add(txtContactPerson, "Contact Person")
            .Controls.Add(cboPaymentTerms, "Payment Terms")
        End With



        Call FillCustomerProduct()
        Call FillPaymentTerms()
        If bolFormState = FormState.AddState Then
            Call ClearFields()
            txtCustomerCode.ReadOnly = False
        Else
            SetEditValue()
            txtCustomerCode.ReadOnly = True
        End If
        Call numrows()
        Call ValidateRow()
    End Sub

    Private Sub FillCustomerProduct()
        FillDataGrid(dgProduct, "GetCustomer_Product '" & customerCode & "'", 0, 9)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveRecord()
    End Sub

#End Region



    

    
    Private Sub dgProduct_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgProduct.RowsAdded
        numrows()
    End Sub

    Private Sub dgProduct_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgProduct.RowsRemoved
        numrows()
    End Sub
End Class