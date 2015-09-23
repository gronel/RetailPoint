Imports Retails.clsPublic
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_100_JO
#Region "Variable"
    Implements IBPSCommand
    Public myparent As frm_100_JOList
    Public bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Dim JONo As String
    Dim Dec As Integer
#End Region
#Region "Procedure"
    ''' <summary>
    ''' View Report
    ''' </summary>
    ''' <remarks></remarks>
    Sub viewReport(ByVal category As String)

        cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_JO_Report.rpt")
        arrParametersAndValue.Clear()
        arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@Category", category))
        arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@JONo", txtJONo.Text))
        cryRpt.SetDataSource(FillReport("sp_rpt_JO", CommandType.StoredProcedure, arrParametersAndValue))
        With frm_200_ReportV
            .rpt_viewer.ReportSource = cryRpt
            .Text = "Job Order"
            .Show()
            .Focus()
        End With
    End Sub
    ''' <summary>
    ''' Insert Employee name into combobox
    ''' </summary>
    ''' <remarks></remarks>
    Sub InsetValues()
        ''variable
        Dim param1, param2 As String
        SQL = "SELECT FirstName + ' ' + CASE WHEN MiddleName IS NULL THEN '' WHEN MiddleName = ' ' THEN '' ELSE SubString(MiddleName, 1, 1) + '. ' END + LastName + ' ' AS EmpName, IsActive FROM tbl_000_Employee WHERE (IsActive = 1)"

        ''Get value from database
        param1 = SQL + " and Designation='Department Head' and DepartmentCode='P&MCD'"
        param2 = SQL + " and (Designation='General Manager' or Designation='President')"

        ''Set a value from database to controls
        FillCombobox(cboApproved, param2, "tbl_000_Employee", "EmpName", "EmpName")
        txtchecked.Text = DBLookUp(param1, "EmpName")
    End Sub
    ''' <summary>
    ''' method fill the cell in selected rows
    ''' </summary>
    ''' <param name="rowindex"></param>
    ''' <remarks></remarks>
    Public Sub fillCode(ByVal rowindex As Integer)
        With dgDetails
            Dim arrParameterAndValue As ArrayList = New ArrayList
            arrParameterAndValue = FetchData(arrParameterAndValue, "sp_FillDataGridViewCell'" & "JO" & "','" & .Item("colSpecificCode", rowindex).Value & "','" & .Item("colJRNo", rowindex).Value & "'", CommandType.Text)

            If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                '-->indicate if the row is null
            Else
                .Item("colItemCode", rowindex).Value = arrParameterAndValue(0).ToString
                .Item("colTOCCode", rowindex).Value = arrParameterAndValue(1).ToString
                .Item("colDescription", rowindex).Value = arrParameterAndValue(2).ToString
                .Item("colBrandType", rowindex).Value = arrParameterAndValue(3).ToString
                .Item("colService", rowindex).Value = arrParameterAndValue(4).ToString
                .Item("colQty", rowindex).Value = arrParameterAndValue(5).ToString
                .Item("colActualUnit", rowindex).Value = arrParameterAndValue(6).ToString
                .Item("colActualPrice", rowindex).Value = arrParameterAndValue(7).ToString
                .Item("colAmount", rowindex).Value = arrParameterAndValue(8).ToString
                If .Item("colJRNo", rowindex).Value <> String.Empty Then
                    Dec = DBLookUp("Select Dec from tbl_100_JR where JRNo='" & .Item("colJRNo", rowindex).Value & "'", "Dec")
                End If
            End If
            AddFields(rowindex)
        End With
    End Sub


    Private Sub PreviewFromTemp()
        Dim cls As New tmp_JO
        If ErrProvider.CheckAndShowSummaryErrorMessage Then
            If bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtJONo.Text & "'") Then
                ErrorProvider1.SetError(txtJONo, "JO Number already exists.")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtJONo.Text & "'") Then
                ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtJONo.Text & "'") Then
                ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtJONo.Text & "'") Then
                ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtJONo.Text & "'") Then
                ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtJONo.Text & "'") Then
                ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtJONo.Text & "'") Then
                ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
            ElseIf CheckActualPrice() Then
                MsgBox("Invalid Unit Price.", MsgBoxStyle.Exclamation, "Unit Price")
            Else

                With cls
                    .JONo = txtJONo.Text
                    .DateRequested = dtDateneed.Text
                    .SupplierID = cbosupplier.Text
                    .SupplierType = txtSupplierType.Text
                    .DeliveryDate = dtDateDelivery.Text
                    .DeliveryBy = cboDeliveryBy.Text
                    .PaymentTerm = txtterm.Text
                    .PayablePaymentDate = txtpaydate.Text
                    .PreparedBy = txtprepared.Text
                    .CheckedBy = txtchecked.Text
                    .ApprovedBy = cboApproved.Text
                    .TotalAmount = txtTotalAmount.Text
                    .Remarks = txtRemarks.Text
                    .CurrencyType = cbocurrency.Text
                    .Dec = Dec
                    .Save(dgDetails)
                    Call viewReport("Temp")

                    RunQuery("Delete from tmp_JO")
                    RunQuery("Delete from tmp_JO_Sub")
                End With
            End If
        End If

    End Sub

    ''' <summary>
    ''' Form Command
    ''' </summary>
    ''' <param name="strCmd"></param>
    ''' <remarks></remarks>
    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                ''NewRecord()
            Case "Edit"
                ''EditRecord()
            Case "Void"
                voidrecord()
            Case "Delete"
                ''DeleteRecord()
            Case "Save"
                SaveRecord()
            Case "Cancel"
                If vbYes = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm") Then
                    doCancel()
                End If
            Case "Refresh"
                ''RefreshRecord()
            Case "Print"
                viewReport("JO")
                frm_200_ReportV.rpt_viewer.PrintReport()
            Case "Preview"
                If isRecordExist("Select JONo from tbl_100_JO where JONO='" & txtJONo.Text & "'") Then
                    Call viewReport("JO")
                Else
                    Call PreviewFromTemp()
                End If

        End Select
    End Sub
    ''' <summary>
    ''' Void Record
    ''' </summary>
    ''' <remarks></remarks>
    Sub voidrecord()
        If HasRecord(txtJONo.Text) = True Then
            MsgBox("Transaction cannot be void " & vbNewLine & "is being used in other transaction", MsgBoxStyle.Exclamation, "Prompt")
            Exit Sub
        End If

        With opendialog
            .Tname = "JO"
            .TID = JONo
            .ShowDialog()
        End With

    End Sub
    ''' <summary>
    ''' enable tools
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub enabled_tools()
        txtJONo.Enabled = False
        dtDateneed.Enabled = False
        cbosupplier.Enabled = False
        txtsupplier.Enabled = False
        txtSupplierType.Enabled = False
        txtaddress.Enabled = False
        cbocurrency.Enabled = False
        dtDateDelivery.Enabled = False
        cboDeliveryBy.Enabled = False
        txtterm.Enabled = False
        txtpaydate.Enabled = False
        txtRemarks.Enabled = False
        txtprepared.Enabled = False
        txtchecked.Enabled = False
        cboApproved.Enabled = False
        dgDetails.Enabled = False
    End Sub
    Sub LockFields(ByVal bolValue As Boolean)
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Lock Fields")
        End Try



    End Sub
    ''' <summary>
    ''' Cancel the Transaction
    ''' </summary>
    ''' <remarks></remarks>
    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        LockFields(True)
        ActivateCommands(FormState.LoadState)
        Me.Close()

    End Sub
    ''' <summary>
    ''' Method for Saving and update to database
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetEditValue()
        Try

            Dim JO As New tbl_100_JO
            With JO
                JONo = myparent.dgList.Item("JONo", myparent.dgList.CurrentRow.Index).Value
                .FetchJO(JONo)
                txtJONo.Text = .JONo
                cbosupplier.Text = .SupplierID
                dtDateDelivery.Text = .DeliveryDate
                cboDeliveryBy.Text = .DeliveryBy
                txtchecked.Text = .CheckedBy
                cboApproved.Text = .ApprovedBy
                txtTotalAmount.Text = FormatNumber(.TotalAmount)
                txtRemarks.Text = .Remarks
                cbocurrency.SelectedValue = .CurrencyType
                Dec = .Dec

            End With
            FillDataGrid(dgDetails, "GetJO_Sub '" & JONo & "'", 0, 11)
            For i = 0 To dgDetails.RowCount - 1
                AddFields(i)
            Next
            txtJONo.Enabled = False
            lblcurrency.Text = cbocurrency.Text

            ComputeAllRows()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' method Check the price of selected items
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckActualPrice() As Boolean
        Dim blnResult As Boolean = False
        Try
            For Each row As DataGridViewRow In dgDetails.Rows
                If Not row.IsNewRow Then
                    If row.Cells("colActualPrice").Value = 0 Then
                        blnResult = True
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        Finally
            CheckActualPrice = blnResult
        End Try
    End Function

    Private Function HasRecord(ByVal JONO As String) As Boolean
        Dim isHaveRecord As Boolean = False
        '-->check if this PO no is used in RR transaction
        If isRecordExist("SELECT     RefOrderNo " & _
                         "FROM  tbl_100_RR  " & _
                         "WHERE     (isStatus <> N'CANCELLED') AND (RefOrderNo = '" & JONO & "')") Then
            isHaveRecord = True
        End If


        Return isHaveRecord

    End Function

    ''' <summary>
    ''' Save Record to Database
    ''' </summary>
    ''' <remarks></remarks>
    Sub SaveRecord()
        Dim JO As New tbl_100_JO
        Dim strResult As Boolean
        'SQL = DBLookUp("Select JONo from tbl_100_JO_Sub where JONo='" & JONo & "' and ((Status='" & isDone & "') or (Status='" & isLacking & "')  or (Status='" & isExcess & "'))", "JONo")
        'If JONo = "" Then
        'Else
        '    If JONo = SQL Then
        '        MsgBox("Transaction cannot be update " & vbNewLine & "is being used in other transaction", MsgBoxStyle.Exclamation, "Prompt")
        '        Exit Sub
        '    End If
        'End If

        If HasRecord(txtJONo.Text) = True Then
            MsgBox("Invalid to Delete this transaction is being used by other transaction", MsgBoxStyle.Exclamation, "Prompt")
            Exit Sub
        End If
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtJONo.Text & "'") Then
                    ErrorProvider1.SetError(txtJONo, "JO Number already exists.")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtJONo.Text & "'") Then
                    ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtJONo.Text & "'") Then
                    ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtJONo.Text & "'") Then
                    ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtJONo.Text & "'") Then
                    ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtJONo.Text & "'") Then
                    ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtJONo.Text & "'") Then
                    ErrorProvider1.SetError(txtJONo, "This id is being used by another transaction!")
                ElseIf CheckActualPrice() Then
                    MsgBox("Invalid Unit Price.", MsgBoxStyle.Exclamation, "Unit Price")
                Else

                    With JO
                        .JONo = txtJONo.Text
                        .DateRequested = dtDateneed.Text
                        .SupplierID = cbosupplier.Text
                        .SupplierType = txtSupplierType.Text
                        .DeliveryDate = dtDateDelivery.Text
                        .DeliveryBy = cboDeliveryBy.Text
                        .PaymentTerm = txtterm.Text
                        .PayablePaymentDate = txtpaydate.Text
                        .PreparedBy = txtprepared.Text
                        .CheckedBy = txtchecked.Text
                        .ApprovedBy = cboApproved.Text
                        .TotalAmount = txtTotalAmount.Text
                        .Remarks = txtRemarks.Text
                        .CurrencyType = cbocurrency.Text
                        .Dec = Dec
                        If bolFormState = FormState.EditState Then
                            _OpenTransaction()
                            strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                            _CloseTransaction(strResult)
                            MsgBox("Updated Complete", MsgBoxStyle.Information, "Update")

                            Me.Close()
                            myparent.RefreshRecord("sp_100_Get_JO_List '" & MainForm.tsSearch.Text & "'")

                        Else
                            'If MsgBox("Do you want to print?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Printing Prompt") = MsgBoxResult.Yes Then
                            '    _OpenTransaction()
                            '    strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                            '    _CloseTransaction(strResult)

                            '    viewReport()
                            '    frm_200_ReportV.rpt_viewer.PrintReport()

                            '    Me.Close()
                            '    myparent.RefreshRecord()
                            '    myparent.Focus()
                            'ElseIf MsgBoxResult.No Then
                            If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Prompt") = MsgBoxResult.Yes Then
                                _OpenTransaction()
                                strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                                _CloseTransaction(strResult)
                                Me.Close()
                                myparent.RefreshRecord("sp_100_Get_JO_List '" & MainForm.tsSearch.Text & "'")

                            Else
                                Me.Close()
                                myparent.RefreshRecord("sp_100_Get_JO_List '" & MainForm.tsSearch.Text & "'")

                            End If
                        End If
                        'End If
                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
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
                    
                    .tsPreview.Enabled = True
                    .tsPrint.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
                    .tsFilterClear.Enabled = False
                    .tsFilterOn.Enabled = False
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
                    .tsFilterClear.Enabled = False
                    .tsFilterOn.Enabled = False
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
    ''' <summary>
    ''' method to fill the Supplier name, address and type
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillSection()
        If Not cbosupplier.SelectedValue Is Nothing Then
            txtsupplier.Text = cbosupplier.SelectedItem.Col2
            txtaddress.Text = cbosupplier.SelectedItem.Col3
            txtSupplierType.Text = cbosupplier.SelectedItem.Col4
        Else
            txtsupplier.Text = String.Empty
            txtaddress.Text = String.Empty
            txtSupplierType.Text = String.Empty
        End If
    End Sub
    ''' <summary>
    ''' Method to  Fill the term and extended the payable date 
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillTerm()
        Try

            Dim termname As String
            termname = DBLookUp("select * from tbl_000_Supplier where SupplierID='" & cbosupplier.Text & "'", "Payterms")
            txtterm.Text = DBLookUp("select * from tbl_000_Supplier_PayTerms where PayTermsID='" & termname & "'", "PayTermsName")
            Dim b As String = DBLookUp("select * from tbl_000_Supplier_PayTerms where PayTermsID='" & termname & "'", "NoOfDays")
            Dim i As Date = dtDateDelivery.Text
            i = dtDateDelivery.Text
            i = i.AddDays(Val(b))

            txtpaydate.Text = i.Date
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' method adding the cell of Quantity and Price
    ''' Or Set the format number
    ''' </summary>
    ''' <param name="rowIndex"></param>
    ''' <remarks></remarks>
    Sub AddFields(ByVal rowIndex As Integer)
        With dgDetails
            .Item("colQty", rowIndex).Value = FormatNumber(CDbl(NZ(.Item("colQty", rowIndex).Value)), 0)
            .Item("colActualPrice", rowIndex).Value = FormatNumber(CDbl(NZ(.Item("colActualPrice", rowIndex).Value)), Dec)

            .Item("colAmount", rowIndex).Value = FormatNumber((NZ(.Item("colQty", rowIndex).Value)) * CDbl(NZ(.Item("colActualPrice", rowIndex).Value)), Dec)
        End With
    End Sub
    ''' <summary>
    ''' Compute all row
    ''' </summary>
    ''' <remarks></remarks>
    Sub ComputeAllRows()
        Dim sum As Double
        With dgDetails
            For i = 0 To .RowCount - 2
                sum = sum + NZ(.Item("colAmount", i).Value)
            Next
            txtTotalAmount.Text = String.Format("{0:N" + CStr(Dec) + "}", (NZ(sum)))
        End With
    End Sub

#End Region
#Region "GUI"
    Private Sub frm_100_JO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        If bolFormState = FormState.EditState Then
            SetEditValue()
        Else
            cboApproved.Text = ""


        End If
        ActivateCommands(bolFormState)
    End Sub
    Private Sub frm_100_JO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        End If
    End Sub
    ''' <summary>
    ''' JO Form Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_100_JO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me)
        'Call POP_UP_MSG()

        CenterControl(lblTitle, Me) 'center the title of the transaction
        FillCombobox(cboDeliveryBy, "Select DeliveryBy from tbl_000_transport", "tbl_000_transport", "DeliveryBy", "DeliveryBy")
        cboDeliveryBy.SelectedIndex = -1
        LoadSupplierToMultiCombo(cbosupplier) 'Add item of Selected Supplier
        txtprepared.Text = CurrUser.USER_FULLNAME
        LoadCurrencyType(cbocurrency)
        With ErrProvider 'Get the error or empty text
            .Controls.Clear()
            .Controls.Add(txtJONo, "JO Number")
            .Controls.Add(cbosupplier, "Supplier")
            .Controls.Add(txtsupplier, "Supplier Name")
            .Controls.Add(txtaddress, "Supplier Address")
            .Controls.Add(txtSupplierType, "Supplier Type")
            .Controls.Add(cboDeliveryBy, "Delivery By")
            .Controls.Add(cboApproved, "Approved by")
            .Controls.Add(txtterm, "Term")
            .Controls.Add(txtpaydate, "Payable Date")
            .Controls.Add(txtprepared, "Prepared By")
        End With

        Call InsetValues()
    End Sub

    Private Sub cbosupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbosupplier.SelectedIndexChanged
        FillSection()
        FillTerm()

        dgDetails.Rows.Clear()
    End Sub
    Private Sub dgDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellValidated
        AddFields(e.RowIndex)
        ComputeAllRows()
    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Select Case e.ColumnIndex
            Case 2
                If cbosupplier.Text = String.Empty Or cbocurrency.Text = String.Empty Then
                    MsgBox("-->Supplier is Required" & vbNewLine & "-->Currency Type is Required", MsgBoxStyle.Exclamation, "Empty")
                    Exit Sub
                End If
                With frm_Searchitem
                    .x = dgDetails.Item("colJRNo", e.RowIndex).Value
                    .frm = "JO"
                    .frmjoparent = Me
                    .ShowDialog()
                    ComputeAllRows()
                End With

        End Select
    End Sub
    Private Sub dgDetails_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDetails.DataError
        On Error Resume Next
    End Sub
    Private Sub dtDateDelivery_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDateDelivery.ValueChanged
        FillTerm()
    End Sub
    Private Sub cbocurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocurrency.SelectedIndexChanged
        FillSection()
        FillTerm()
        dgDetails.Rows.Clear()
        lblcurrency.Text = cbocurrency.Text
    End Sub
    Private Sub btncopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncopy.Click
        If MessageBox.Show("Are you sure you want to add the details in new identification code?", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            With frmUnit
                .trans = "JO"
                .ShowDialog()
            End With
        End If
    End Sub
#End Region

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class