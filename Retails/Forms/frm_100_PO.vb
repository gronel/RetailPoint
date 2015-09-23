Imports Retails.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frm_100_PO
#Region "variable"
    Implements IBPSCommand
    Public myParent As frm_100_POList
    Public bolFormState As clsPublic.FormState
    Public itemCode As String
    Public speficificCode As String
    Public PONo As String
    Dim oldDepartment As String
    Dim oldSection As String
    Dim ErrProvider As New ErrorProviderExtended
    Public rowindex As Integer
    Public x As String
    Dim dec As Integer
#End Region
#Region " user difinition"
    Sub viewReport(ByVal category As String)

        cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_PO_Report.rpt")

        arrParametersAndValue.Clear()
        arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@category", category))
        arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@PONo", txtPONo.Text))
        cryRpt.SetDataSource(FillReport("sp_rpt_PO", CommandType.StoredProcedure, arrParametersAndValue))
        With frm_200_ReportV
            .rpt_viewer.ReportSource = cryRpt
            .Text = "Purchase Order"
            .Show()
            .Focus()
        End With
    End Sub


    Private Sub PreviewFromTemp()
        Dim cls As New tmp_PO
        If ErrProvider.CheckAndShowSummaryErrorMessage Then
            If bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtPONo.Text & "'") Then
                ErrorProvider1.SetError(txtPONo, "PO Number already exists.")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtPONo.Text & "'") Then
                ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtPONo.Text & "'") Then
                ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtPONo.Text & "'") Then
                ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtPONo.Text & "'") Then
                ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtPONo.Text & "'") Then
                ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtPONo.Text & "'") Then
                ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
                'ElseIf CheckActualPrice() Then
                '    MsgBox("Invalid Unit Price.", MsgBoxStyle.Exclamation, "Unit Price")
            ElseIf CountGridRows(dgDetails) = 0 Then
                MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                Exit Sub
            ElseIf CountGridRows(dgDetails) = 0 Then
                MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                If dgDetails.RowCount = 0 Then
                    MsgBox("Empty value")
                    Exit Sub
                End If


                With cls
                    .PONo = txtPONo.Text
                    .DateRequested = dtDateneed.Text
                    .SupplierID = cbosupplier.Text
                    .SupplierType = txtSupplierType.Text
                    .DeliveryDate = dtDateDelivery.Text
                    .DeliveryBy = cboDeliveryBy.Text
                    .PaymentTerm = txtterm.Text
                    .PayablePaymentDate = txtpaydate.Text
                    .PreparedBy = txtPrepared.Text
                    .CheckedBy = txtchecked.Text
                    .ApprovedBy = cboApproved.Text
                    .TotalAmount = txtTotalAmount.Text
                    .Remarks = txtRemarks.Text
                    .CurrencyType = cboCurrency.Text
                    .Dec = dec
                    .Save(dgDetails)
                    Call viewReport("Temp")

                    RunQuery("Delete from tmp_PO")
                    RunQuery("Delete from tmp_PO_Sub")
                End With
            End If
        End If

    End Sub

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
            Case "Preview"
                If isRecordExist("Select PONo from tbl_100_PO where PONO='" & txtPONo.Text & "'") Then
                    Call viewReport("PO")
                Else
                    Call PreviewFromTemp()
                End If

            Case "Print"
                viewReport("PO")
                '  frm_200_ReportV.rpt_viewer.PrintReport()
        End Select
    End Sub

    Sub voidrecord()
        If HasRecord(txtPONo.Text) = True Then
            MsgBox("Transaction cannot be void " & vbNewLine & "is being used in other transaction", MsgBoxStyle.Exclamation, "Prompt")
            Exit Sub
        End If

        With opendialog
            .Tname = "PO"
            .TID = PONo
            .ShowDialog()
        End With

    End Sub

    Public Sub enabled_tools()
        txtPONo.Enabled = False
        dtDateneed.Enabled = False
        cbosupplier.Enabled = False
        txtsupplier.Enabled = False
        txtSupplierType.Enabled = False
        txtaddress.Enabled = False
        cboCurrency.Enabled = False
        dtDateDelivery.Enabled = False
        cboDeliveryBy.Enabled = False
        txtterm.Enabled = False
        txtpaydate.Enabled = False
        txtRemarks.Enabled = False
        txtPrepared.Enabled = False

        cboApproved.Enabled = False
        dgDetails.Enabled = False
    End Sub


    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()

        ''grpList.Enabled = True
        ActivateCommands(FormState.LoadState)
        Me.Close()

    End Sub
    Private Sub frm_100_PO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        If bolFormState = FormState.EditState Then
            SetEditValue()
        Else
            cboApproved.Text = ""


        End If
        ActivateCommands(bolFormState)
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
                    .tsPreview.Enabled = True
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
    Sub InsertValues()
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
    ''' Method for Saving and update
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetEditValue()
        Dim PO As New tbl_100_PO
        With PO
            'PONo = myParent.dgList.Item("PONo", myParent.dgList.CurrentRow.Index).Value
            ''PONo = myParent.dgList.Item(0, myParent.dgList.CurrentCell.Index).Value
            'PONo = myParent.dgList.CurrentCell.Value
            .FetchPO(PONo)
            txtPONo.Text = .PONo
            dtDateneed.Text = .DateRequested
            cbosupplier.Text = .SupplierID
            dtDateDelivery.Text = .DeliveryDate
            cboDeliveryBy.SelectedValue = .DeliveryBy
            txtchecked.Text = .CheckedBy
            cboApproved.Text = .ApprovedBy
            txtTotalAmount.Text = FormatNumber(.TotalAmount)
            txtRemarks.Text = .Remarks
            cboCurrency.Text = .CurrencyType
            dec = .Dec
        End With
        FillDataGrid(dgDetails, "SELECT     PO_sub.PRNo, tbl_Specificcode.SpecificCode, '' AS Expr1, tbl_Specificcode.TOCCode, tbl_Specificcode.SpecificDescription, " & _
                              "tbl_Specificcode.BrandType, PO_sub.ReqQty, tbl_Specificcode.ActualUOM, PO_sub.ActualUnitPrice, " & _
                              "PO_sub.ReqQty * PO_sub.ActualUnitPrice AS Amount, PR_sub.QtyDec " & _
                              "FROM         tbl_000_Item_Sub AS tbl_Specificcode INNER JOIN " & _
                              "tbl_100_PO_Sub AS PO_sub ON tbl_Specificcode.SpecificCode = PO_sub.SpecificCode INNER JOIN " & _
                              "tbl_100_PR_Sub AS PR_sub ON PO_sub.SpecificCode = PR_sub.SpecificCode AND PO_sub.PRNo = PR_sub.PRNo WHERE     (PO_sub.PONo ='" & PONo & "')", 0, 10)
        txtPONo.Enabled = False
        lblCurrency.Text = cboCurrency.Text
        For i = 0 To dgDetails.RowCount - 1
            AddFields(i)
        Next
        ComputeAllRows()
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
            i = i.AddDays(b)
            txtpaydate.Text = i.Date
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
    '''method fill the cell in selected rows
    ''' </summary>
    ''' <param name="rowindex"></param>
    ''' <remarks></remarks>
    Public Sub fillCode(ByVal rowindex As Integer)
        With dgDetails
            Dim arrParameterAndValue As ArrayList = New ArrayList
            arrParameterAndValue = FetchData(arrParameterAndValue, "sp_FillDataGridViewCell'" & "PO" & "','" & .Item("colSpecificCode", rowindex).Value & "','" & .Item("colPRNo", rowindex).Value & "'", CommandType.Text)

            If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                '-->indicate if the row is null
            Else

                .Item("colTOCCode", rowindex).Value = arrParameterAndValue(1).ToString
                .Item("colDescription", rowindex).Value = arrParameterAndValue(2).ToString
                .Item("colBrandType", rowindex).Value = arrParameterAndValue(3).ToString

                .Item("colQty", rowindex).Value = arrParameterAndValue(5).ToString
                .Item("colUnit", rowindex).Value = arrParameterAndValue(6).ToString
                .Item("colActualPrice", rowindex).Value = arrParameterAndValue(7).ToString
                .Item("coldec", rowindex).Value = arrParameterAndValue(9).ToString
                If .Item("colPRNo", rowindex).Value <> String.Empty Then
                    dec = arrParameterAndValue(8).ToString
                End If
            End If

            ' lblCurrency.Text = DBLookUp("select CurrencyType from tbl_100_PR where PRNo='" & .Item("colPRNo", 0).Value & "'", "CurrencyType")
            AddFields(rowindex)

        End With
    End Sub
    Sub SelectCurrency()
        SQL = "SELECT tbl_100_PR.PRNo " + _
                         "FROM tbl_100_PR_Sub INNER JOIN " + _
                         "tbl_100_PR ON tbl_100_PR_Sub.PRNo = tbl_100_PR.PRNo " + _
                         "WHERE     (tbl_100_PR.PRType = 'PO') and (tbl_100_PR.SupplierID='" + cbosupplier.Text + "') " + _
                         "and (tbl_100_PR.Currencytype='" + cboCurrency.Text + "') and (tbl_100_PR_Sub.Status='" + isPending + "') GROUP BY tbl_100_PR.PRNo"

        dgDetails.Rows.Clear()
        ' FillDataGridViewComboBoxColumn(colPRNo, SQL, "tbl_100_PR", "PRNo", "PRNo")
    End Sub

    ''' <summary>
    ''' method adding the cell of Quantity and Price
    ''' or set the  formatnumber
    ''' </summary>
    ''' <param name="rowIndex"></param>
    ''' <remarks></remarks>
    Sub AddFields(ByVal rowIndex As Integer)

        With dgDetails

            .Item("colQty", rowIndex).Value = FormatNumber(CDbl(NZ(.Item("colQty", rowIndex).Value)), CInt(.Item("coldec", rowIndex).Value))
            .Item("colActualPrice", rowIndex).Value = FormatNumber(CDbl(NZ(.Item("colActualPrice", rowIndex).Value)), dec)

            .Item("colAmount", rowIndex).Value = FormatNumber((NZ(.Item("colQty", rowIndex).Value)) * CDbl(NZ(.Item("colActualPrice", rowIndex).Value)), dec)
        End With
    End Sub
    ''' <summary>
    ''' method compute the column
    ''' </summary>
    ''' <remarks></remarks>
    Sub ComputeAllRows()
        Dim sum As Double
        With dgDetails
            For i = 0 To .RowCount - 2
                sum = sum + NZ(.Item("colAmount", i).Value)
            Next
            txtTotalAmount.Text = String.Format("{0:N" + CStr(dec) + "}", (NZ(sum)))
        End With
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

    Private Function HasRecord(ByVal PONO As String) As Boolean
        Dim isHaveRecord As Boolean = False
        '-->check if this PO no is used in RR transaction
        PONO = txtPONo.Text
        If isRecordExist("SELECT     RefOrderNo " & _
                         "FROM  tbl_100_RR  " & _
                         "WHERE     (isStatus <> N'CANCELLED') AND (RefOrderNo = '" & PONO & "')") Then
            isHaveRecord = True
        End If


        Return isHaveRecord

    End Function

    ''' <summary>
    ''' method for saving the record to the database
    ''' </summary>
    ''' <remarks></remarks>
    Sub SaveRecord()
        Dim PO As New tbl_100_PO
        'SQL = DBLookUp("Select PONo from tbl_100_PO_Sub where PONo='" & PONo & "' and ((Status='" & isDelivered & "') or (Status='" & isLacking & "')  or (Status='" & isExcess & "'))", "PONo")
        'If PONo = "" Then
        'Else
        '    If PONo = SQL Then
        '        MsgBox("Invalid to update is being used in other transaction", MsgBoxStyle.Exclamation)
        '        Exit Sub
        '    End If
        'End If



        Dim strResult As Boolean
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtPONo.Text & "'") Then
                    ErrorProvider1.SetError(txtPONo, "PO Number already exists.")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtPONo.Text & "'") Then
                    ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtPONo.Text & "'") Then
                    ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtPONo.Text & "'") Then
                    ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtPONo.Text & "'") Then
                    ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtPONo.Text & "'") Then
                    ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtPONo.Text & "'") Then
                    ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")

                ElseIf CountGridRows(dgDetails) = 0 Then
                    MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf CountGridRows(dgDetails) = 0 Then
                    MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                    Exit Sub
                Else
                    If dgDetails.RowCount = 0 Then
                        MsgBox("Empty value")
                        Exit Sub
                    End If
                    If HasRecord(txtPONo.Text) = True Then
                        MsgBox("Invalid to Delete this transaction is being used by other transaction", MsgBoxStyle.Exclamation, "Prompt")
                        Exit Sub
                    End If


                    With PO
                        .PONo = txtPONo.Text
                        .DateRequested = dtDateneed.Text
                        .SupplierID = cbosupplier.Text
                        .SupplierType = txtSupplierType.Text
                        .DeliveryDate = dtDateDelivery.Text
                        .DeliveryBy = cboDeliveryBy.Text
                        .PaymentTerm = txtterm.Text
                        .PayablePaymentDate = txtpaydate.Text
                        .PreparedBy = txtPrepared.Text
                        .CheckedBy = txtchecked.Text
                        .ApprovedBy = cboApproved.Text
                        .TotalAmount = txtTotalAmount.Text
                        .Remarks = txtRemarks.Text
                        .CurrencyType = cboCurrency.Text
                        .Dec = dec
                        If bolFormState = FormState.EditState Then
                            _OpenTransaction()
                            strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                            _CloseTransaction(strResult)
                            MsgBox("Updated Complete", MsgBoxStyle.Information, "Update")

                            Me.Close()
                            myParent.RefreshRecord("sp_100_Get_PO_List'" & MainForm.tsSearch.Text & "'")

                        Else

                            If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Prompt") = MsgBoxResult.Yes Then
                                _OpenTransaction()
                                strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                                _CloseTransaction(strResult)
                                Me.Close()
                                myParent.RefreshRecord("sp_100_Get_PO_List'" & MainForm.tsSearch.Text & "'")
                            End If
                        End If
                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

#End Region
#Region "GUI Method"

    Private Sub frm_100_PO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        End If
    End Sub

    Private Sub frm_100_PO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ResizeForm(Me) 'Resize the  form 
        ''Call POP_UP_MSG()
        CenterControl(lblTitle, Me) 'center the title of the transaction

        Call InsertValues()
        With ErrProvider 'Get the error or empty text
            .Controls.Clear()
            .Controls.Add(cboCurrency, "Currency Type")
            .Controls.Add(txtPONo, "PO Number")
            .Controls.Add(cbosupplier, "Supplier")
            .Controls.Add(txtsupplier, "Supplier Name")
            .Controls.Add(txtaddress, "Supplier Address")
            .Controls.Add(txtSupplierType, "Supplier Type")
            .Controls.Add(cboDeliveryBy, "Delivery By")

            .Controls.Add(cboApproved, "Approved by")
            .Controls.Add(txtterm, "Term")
            .Controls.Add(txtpaydate, "Payable Date")
            .Controls.Add(txtPrepared, "Prepared By")

        End With
        LoadSupplierToMultiCombo(cbosupplier) ''Add item of Selected Supplier
        txtPrepared.Text = CurrUser.USER_FULLNAME ''fill the  text prepared by
        FillCombobox(cboDeliveryBy, "Select * From tbl_000_Transport", "tbl_000_Transport", "DeliveryBy", "DeliveryBy") '' add collection in combobox delivery using query string
        LoadCurrencyType(cboCurrency)
    End Sub

    Private Sub cbosupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbosupplier.SelectedIndexChanged
        FillSection()
        FillTerm()
        SelectCurrency()
    End Sub

    Private Sub dgDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellValidated
        AddFields(e.RowIndex)
        ComputeAllRows()

    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgDetails)
        ComputeAllRows()

    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgDetails)
        ComputeAllRows()

    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Select Case e.ColumnIndex
            Case 2
                If cbosupplier.Text = String.Empty Or cboCurrency.Text = String.Empty Then
                    MsgBox("-->Supplier is Required" & vbNewLine & "-->Currency Type is Required", MsgBoxStyle.Exclamation, "Empty")
                    Exit Sub
                End If
                With frm_Searchitem
                    .frm = "PO" '' set the value in search box
                    .frmparent = Me
                    frm_Searchitem.ShowDialog() '' open the search box for pr
                    For i = 0 To dgDetails.RowCount - 1
                        AddFields(i)
                    Next
                    ComputeAllRows()
                End With
        End Select
    End Sub

    Private Sub dgDetails_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgDetails.CellValidating
        Try
            Select Case e.ColumnIndex
                Case colSpecificCode.Index
                    If CheckCodeFromDatagridView(dgDetails, 2, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                        dgDetails.CancelEdit()
                        MsgBox("Specific Code already exists in the list.", MsgBoxStyle.Exclamation, "Duplicate Code")
                    Else
                        If bolFormState <> FormState.EditState Then
                            fillCode(e.RowIndex)
                            For i = 0 To dgDetails.RowCount - 1
                                AddFields(i)
                            Next
                            ComputeAllRows()
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub dgDetails_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDetails.DataError
        On Error Resume Next
    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SelectCurrency()
        lblCurrency.Text = cboCurrency.Text
    End Sub
    Private Sub dtDateDelivery_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDateDelivery.ValueChanged
        FillTerm()
    End Sub
    Private Sub cboCurrency_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurrency.SelectedIndexChanged
        SelectCurrency()
        lblCurrency.Text = cboCurrency.Text
    End Sub

    Private Sub btncopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncopy.Click
        If MessageBox.Show("Are you sure you want to add the details in new identification code?", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            With frmUnit
                .trans = "PO"
                .ShowDialog()
            End With
        End If
    End Sub

#End Region
End Class