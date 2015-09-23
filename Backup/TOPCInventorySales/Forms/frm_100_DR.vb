Imports System.Data.SqlClient
Imports TOPCInventorySales.clsPublic
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frm_100_DR
    Implements IBPSCommand

#Region "Variable"
    Public myParent As frm_100_DRList
    Public bolFormState As clsPublic.FormState
    Dim DR As New tbl_100_DR
    Dim ErrProvider As New ErrorProviderExtended
    Public DRCode As String
    Dim _dec As Integer
#End Region


#Region "User Difination:"

    Public Function ORDERNO_LIST(ByVal strCommand As String) As String
        Dim arrSource As New ArrayList
        Dim Orderno As String
        Dim OrderNolist As String
        Dim con As New SqlConnection(cnString)
        Try
            con.Open()
            Dim myCmd As SqlCommand = New SqlCommand(strCommand, con)
            Dim myReader As SqlDataReader = myCmd.ExecuteReader
            With myReader
                If .HasRows Then
                    While .Read
                        For introw As Integer = 0 To (.FieldCount - 1)


                            Orderno += myReader.Item(introw).ToString & ","


                        Next

                    End While
                    OrderNolist = Orderno.Remove(Orderno.Length - 1)
                End If
                .Close()
            End With
            con.Close()
            Return OrderNolist
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Function

    Private Sub DeleteRows(ByVal DRno As String, ByVal Orderno As String, ByVal ProductCode As String, ByVal QTY As Double)
        RunQuery("sp_Order_RollBackQTY '" & Orderno & "','" & ProductCode & "'," & QTY)
        RunQuery("DELETE FROM tbl_100_DR_Sub WHERE     (DRNo = '" & txtDRCode.Text & "') AND (OrderNo = '" & Orderno & "') AND (ProductCode = '" & ProductCode & "')")
    End Sub

    Public Sub enabled_tools(ByVal islock As Boolean)
        txtDRCode.Enabled = islock
        dtDRDate.Enabled = islock
        cboCustomerCode.Enabled = islock
        cboDRType.Enabled = islock
        txtRemarks.Enabled = islock
        txtAddress.Enabled = islock
        txtDeliveredBy.Enabled = islock
    
        dgDetails.Enabled = islock
    End Sub

    Private Sub voidrecord()
        With opendialog
            .Tname = "DR"
            .TID = txtDRCode.Text
            .ShowDialog()
        End With

    End Sub
    Private Sub viewReport()

        With frm_dr_paper
            .DRNo = txtDRCode.Text
            .OrderNo = ORDERNO_LIST("SELECT     OrderNo FROM tbl_100_DR_Sub " & _
                "WHERE     (DRNo = '" & txtDRCode.Text & "') GROUP BY OrderNo")
            .ShowDialog()
        End With
        'Dim cryRpt As New ReportDocument
        'cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_DR_Report.rpt")
        'cryRpt.SetDataSource(FillReportForm("sp_rpt_DR '" & 0 & "','" & txtDRCode.Text & "'", "tbl_100_DR_Sub"))
        'cryRpt.SetParameterValue("orderno", ORDERNO_LIST("SELECT     OrderNo FROM tbl_100_DR_Sub " & _
        '                                    "WHERE     (DRNo = '" & txtDRCode.Text & "') GROUP BY OrderNo"))
        'frm_200_ReportV.rpt_viewer.ReportSource = cryRpt
        'frm_200_ReportV.Show()
        'frm_200_ReportV.Focus()
    End Sub

    Private Sub ViewTempReport()
        Try
            Dim tmpDR As New clstmp_DR
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("SELECT DRNo FROM tbl_100_DR WHERE DRNo='" & txtDRCode.Text & "'") Then
                    MsgBox("DR Code already exists.", MsgBoxStyle.Exclamation, "Duplicate")
                Else

                    If CheckIFQTYZERO() = False Then
                        MsgBox("There are quantity that 0 value", MsgBoxStyle.Exclamation, "Prompt")
                        Exit Sub
                    End If


                    With tmpDR
                        .DRNo = txtDRCode.Text.Trim
                        .DRDate = dtDRDate.Text
                        .CustomerCode = cboCustomerCode.SelectedValue
                        .DRType = cboDRType.SelectedValue
                        .Remarks = txtRemarks.Text
                        .ReceivablePaymentDate = CDate(txtReceivableDate.Text)
                        .TotalQuantity = txtTotalQuantity.Text
                        .TotalAmount = txtTotalAmount.Text
                        .DeliveredBy = CurrUser.USER_ID
                        _OpenTransaction()
                        _Result = .Save(bolFormState = FormState.EditState, dgDetails)
                        _CloseTransaction(_Result)

                    End With


                    Dim cryRpt As New ReportDocument
                    cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_DR_Report.rpt")
                    cryRpt.SetDataSource(FillReportForm("sp_rpt_DR '" & 1 & "','" & txtDRCode.Text & "'", "tbl_100_DR_Sub"))
                    frm_200_ReportV.rpt_viewer.ReportSource = cryRpt
                    frm_200_ReportV.Show()
                    frm_200_ReportV.Focus()



                    RunQuery("Delete from tmp_DR where DRNo='" & txtDRCode.Text & "'")
                    RunQuery("Delete from tmp_DR_Sub where DRNo='" & txtDRCode.Text & "'")


                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
        End Try
    End Sub

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "Void"
                voidrecord()
            Case "New"

            Case "Edit"

            Case "Delete"

            Case "Save"
                SaveRecord()
            Case "Cancel"
                If MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                    doCancel()
                End If
            Case "Refresh"
            Case "Preview"
                If bolFormState = FormState.EditState Then
                    viewReport()
                Else
                    'ViewTempReport()
                End If
            Case "Print"
                viewReport()

        End Select
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
                    .tsVoid.Enabled = False
                    .tsPrint.Enabled = False
                    .tsPrint.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
                    .tsPreview.Enabled = True
                Case FormState.EditState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                    .tsVoid.Enabled = True
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
                    .tsVoid.Enabled = False
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
                    .tsVoid.Enabled = False
                    .tsPrint.Enabled = False
                    .tsPrint.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
            End Select

        End With
    End Sub

    Private Sub sentmsg()
        SQL = DBLookUp("sp_GetSentAlert'" & "DR" & "','" & txtDRCode.Text & "'", "PackingStatus")
        If SQL = "YES" Then
            With frm_SendAlert
                FillDataGrid(.dg2, "sp_GetSentAlert'" & "DR" & "','" & txtDRCode.Text & "'", 0, 2)
                .frm = "DR"
                .ShowDialog()
            End With
        End If
    End Sub


    ''fill all combobox
    Private Sub FillAllCombo()
        LoadCustomerToMultiCombo(cboCustomerCode)

        FillCombobox(cboDRType, "Select Description,StatusID from tbl_Status where Usage='DR'", "tbl_Status", "Description", "StatusID")
        cboDRType.SelectedIndex = -1
    End Sub

    Private Sub FillCustomerName()
        If Not cboCustomerCode.SelectedValue Is Nothing Then
            txtCustomerName.Text = cboCustomerCode.SelectedItem.Col2
            txtAddress.Text = cboCustomerCode.SelectedItem.Col3
            txtPaymentTerm.Text = DBLookUp("GetCustomerPayTerms '" & cboCustomerCode.SelectedValue & "'", "PayTermsName")
            txtReceivableDate.Text = ComputeReceivableDate(dtDRDate.Text)
            If dgDetails.RowCount - 1 > 0 Then
                dgDetails.Rows.Clear()
                dgDetails.AllowUserToAddRows = True
            End If
            'SQL = "SELECT   distinct  tbl_100_Order.OrderNo " & _
            '        "FROM         tbl_100_Order INNER JOIN " & _
            '        "tbl_100_Order_Sub ON tbl_100_Order.OrderNo = tbl_100_Order_Sub.OrderNo " & _
            '        "WHERE     (tbl_100_Order.CustomerCode = '" & cboCustomerCode.Text & "') AND (tbl_100_Order_Sub.isStatus = N'Processed')" & _
            '        "ORDER BY tbl_100_Order.OrderNo"
            'FillDataGridViewComboBoxColumn(colOrderNo, SQL, "tbl_100_Order", "OrderNo", "OrderNo")
        Else
            txtCustomerName.Text = String.Empty
            txtPaymentTerm.Text = String.Empty
        End If
    End Sub

    Private Function CheckIFQTYZERO() As Boolean
        For Each row As DataGridViewRow In dgDetails.Rows
            If row.IsNewRow = False Then
                If row.Cells("colQuantity").Value = 0 Then
                    CheckIFQTYZERO = False
                Else
                    CheckIFQTYZERO = True
                End If
            End If
        Next
    End Function

    Private Function CheckQTYEditMode(ByVal dgsub As DataGridView) As Boolean
        Try
            Dim DRQTY, _qtybal, _actualQty As Double
            Dim _order, _product As String
            For Each row As DataGridViewRow In dgsub.Rows
                If row.IsNewRow = False Then
                    _order = row.Cells("colOrderNo").Value
                    _product = row.Cells("colProductCode").Value
                    _actualQty = row.Cells("colQuantity").Value

                    DRQTY = NZ(DBLookUp("SELECT SUM(tbl_100_DR_Sub.Quantity) AS QTY FROM tbl_100_DR_Sub INNER JOIN " & _
                              "tbl_100_DR ON tbl_100_DR_Sub.DRNo = tbl_100_DR.DRNo " & _
                                "WHERE     (tbl_100_DR_Sub.OrderNo = '" & _order & "') AND (tbl_100_DR_Sub.ProductCode = '" & _product & "') AND (tbl_100_DR.Status <> N'CANCELLED')", "QTY"))
                    _qtybal = DRQTY


                End If
            Next
        Catch ex As Exception
            MsgBox("Error: CheckQTYEditMode" & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Function

    Private Function CheckQTYBalance(ByVal dgsub As DataGridView) As Boolean
        Try
            CheckQTYBalance = False

            Dim orderno As String, productno As String, order_runBal As Double, actualBal As Double
            For Each row As DataGridViewRow In dgsub.Rows
                If row.IsNewRow = False Then

                    orderno = row.Cells("colOrderNo").Value
                    productno = row.Cells("colProductCode").Value
                    actualBal = NZ(row.Cells("colQuantity").Value)

                    ''Get the actual balance of the product
                    order_runBal = NZ(DBLookUp("SELECT runQTY FROM tbl_100_Order_Sub WHERE (OrderNo = '" & orderno & "') AND (ProductCode ='" & productno & "')", "runQTY"))

                    If actualBal > order_runBal Then
                        CheckQTYBalance = True
                    End If


                End If
            Next

        Catch ex As Exception
            MsgBox("Error: CheckQTYBalance" & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Function

    Private Sub SaveRecord()
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("SELECT DRNo FROM tbl_100_DR WHERE DRNo='" & txtDRCode.Text & "'") Then
                    MsgBox("DR Code already exists.", MsgBoxStyle.Exclamation, "Duplicate")
                Else
                    If CheckIFQTYZERO() = False Then
                        MsgBox("There are quantity that 0 value", MsgBoxStyle.Exclamation, "Prompt")
                        Exit Sub
                    End If


                    If bolFormState = FormState.AddState And CheckQTYBalance(dgDetails) Then
                        MsgBox("Quantity you type is biger than actual Quantity", MsgBoxStyle.Information, "Prompt")
                        Exit Sub
                    End If

                    '' start set value
                    With DR
                        .DRNo = txtDRCode.Text.Trim
                        .DRDate = dtDRDate.Text
                        .CustomerCode = cboCustomerCode.SelectedValue
                        .DRType = cboDRType.SelectedValue
                        .Remarks = txtRemarks.Text
                        .ReceivablePaymentDate = CDate(txtReceivableDate.Text)
                        .TotalQuantity = txtTotalQuantity.Text
                        .TotalAmount = txtTotalAmount.Text
                        .DeliveredBy = CurrUser.USER_ID
                        .DRcurrencyType = lblcurrency.Text

                        If bolFormState = FormState.EditState Then
                            _OpenTransaction()
                            _Result = .UpdateOrder(txtDRCode.Text, dgDetails, FormState.EditState)
                            _Result = .Save(bolFormState = FormState.EditState, dgDetails)
                            _CloseTransaction(_Result)
                            MsgBox("Updated Complete", MsgBoxStyle.Information, "Update")
                        Else

                            If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Prompt") = MsgBoxResult.Yes Then
                                _OpenTransaction()
                                _Result = .UpdateOrder(txtDRCode.Text, dgDetails, FormState.AddState)
                                _Result = .Save(bolFormState = FormState.EditState, dgDetails)
                                _CloseTransaction(_Result)
                            Else
                                Exit Sub
                            End If

                        End If
                        Me.Close()
                        myParent.RefreshRecord("sp_100_Get_DR_List'" & MainForm.tsSearch.Text & "'")
                    End With


                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
        End Try
    End Sub

    Sub ClearFields()
        txtDRCode.Text = String.Empty
        dtDRDate.Text = FormatDateTime(Now, DateFormat.ShortDate)
        cboCustomerCode.SelectedIndex = -1
        cboDRType.SelectedIndex = -1
        txtRemarks.Text = String.Empty
        txtReceivableDate.Text = String.Empty
        dgDetails.Rows.Clear()
    End Sub

    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        ActivateCommands(FormState.LoadState)
        Me.Close()
    End Sub

    Public Sub SaveVoidRecord()
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then


                '' start set value
                With DR
                    .DRNo = txtDRCode.Text.Trim
                    .DRDate = dtDRDate.Text
                    .CustomerCode = cboCustomerCode.SelectedValue
                    .DRType = cboDRType.SelectedValue
                    .Remarks = txtRemarks.Text
                    .ReceivablePaymentDate = CDate(txtReceivableDate.Text)
                    .TotalQuantity = txtTotalQuantity.Text
                    .TotalAmount = txtTotalAmount.Text
                    .DeliveredBy = CurrUser.USER_ID
                    .DRcurrencyType = lblcurrency.Text


                    _OpenTransaction()
                    _Result = .Save(bolFormState = FormState.EditState, dgDetails)
                    _CloseTransaction(_Result)
                    MsgBox("Save complete!", MsgBoxStyle.Information, "Prompt")

                    Me.Close()
                    myParent.RefreshRecord("sp_100_Get_DR_List'" & MainForm.tsSearch.Text & "'")
                End With



            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
        End Try
    End Sub

    Private Sub SetEditValue()
        With DR
            .FetchRecord(DRCode)
            txtDRCode.Text = .DRNo
            dtDRDate.Text = .DRDate
            cboCustomerCode.SelectedValue = .CustomerCode
            cboDRType.SelectedValue = .DRType
            txtRemarks.Text = .Remarks
            txtReceivableDate.Text = .ReceivablePaymentDate
            txtTotalAmount.Text = .TotalAmount
            txtTotalQuantity.Text = .TotalQuantity
            cbocurrency.SelectedValue = .DRcurrencyType
            lblcurrency.Text = .DRcurrencyType
            txtDeliveredBy.Text = DBLookUp("SELECT EmpName FROM tbl_000_User WHERE UserID = '" & .DeliveredBy & "'", "EmpName")
        End With
        'FillDataGridViewComboBoxColumn(colOrderNo, "SELECT OrderNo FROM tbl_100_DR_Sub WHERE DRNo = '" & txtDRCode.Text.Trim & "'", _
        '                                   "tbl_100_DR_Sub", "OrderNo", "OrderNo")
        FillAllDataGrid()
    End Sub

    Sub FillAllDataGrid()
        FillDataGrid(dgDetails, "GetDR_Sub '" & txtDRCode.Text.Trim & "'", 0, 10)
        lblRecordCount.Text = CountGridRows(dgDetails)

        For i = 0 To dgDetails.RowCount - 1
            Call AddFields(i)
        Next
    End Sub

    Sub FillCode(ByVal rowindex As Integer, Optional ByVal priceID As Integer = Nothing)
        With dgDetails
            arrParametersAndValue.Clear()
            arrParametersAndValue = FetchData(arrParametersAndValue, "sp_fillcode_DR '" & dgDetails.Item("colOrderNo", rowindex).Value & "','" & .Item("colProductCode", rowindex).Value & "'," & priceID, CommandType.Text)
            If arrParametersAndValue.Count > 0 Then
                .Item("colProductName", rowindex).Value = arrParametersAndValue(0).ToString
                .Item("colPartNo", rowindex).Value = arrParametersAndValue(1).ToString
                .Item("colUnitPrice", rowindex).Value = NZ(arrParametersAndValue(2))
                .Item("coldec", rowindex).Value = NZ(arrParametersAndValue(3))
                .Item("colPriceID", rowindex).Value = priceID

            End If
            dgDetails.Item("colOrderType", rowindex).Value = DBLookUp("SELECT OrderTypeCode FROM tbl_100_Order WHERE OrderNo = '" & dgDetails.Item("colOrderNo", rowindex).Value & "'", "OrderTypeCode")
        End With

        For i = 0 To dgDetails.RowCount - 1
            AddFields(i)
        Next

    End Sub


    Private Sub ComputeRows()
        Dim SumAmount, SumQty As Double
        Dim ActualAMT As Double
        With dgDetails
            'For Each row As DataGridViewRow In dgDetails.Rows
            '    If row.IsNewRow = False Then
            '        SumAmount = FormatNumber(SumAmount + row.Cells("colAmount").Value, 2)
            '        SumQty = SumQty + CDbl(NZ(row.Cells("colQuantity").Value))
            '    End If
            'Next
            ActualAMT = 0
            For Each row As DataGridViewRow In dgDetails.Rows
                If row.IsNewRow = False Then
                    ActualAMT += NZ(row.Cells("colQuantity").Value) * NZ(row.Cells("colUnitPrice").Value)
                    SumAmount = FormatNumber(SumAmount + row.Cells("colAmount").Value, 2)
                    SumQty = SumQty + CDbl(NZ(row.Cells("colQuantity").Value))
                End If
            Next
            txtTotalAmount.Text = FormatNumber(ActualAMT, 2)
            txtTotalQuantity.Text = FormatNumber(ConvertToMoney(SumQty), 2)
        End With
    End Sub

    Private Function CheckQTY(ByVal rowindex As Integer) As Boolean
        Dim orderno As String
        Dim productcode As String
        Dim ProductQTY As String
        Dim DRQTY As Double
        Try
            With dgDetails
                DRQTY = CDbl(NZ(.Item("colQuantity", rowindex).Value))
                orderno = .Item("colOrderNo", rowindex).Value
                productcode = .Item("colProductCode", rowindex).Value

                ProductQTY = CDbl(NZ(DBLookUp("Select runQTY from tbl_100_Order_Sub where OrderNo='" & orderno & "' and ProductCode='" & productcode & "'", "runQTY")))

                If ProductQTY < DRQTY Then
                    MsgBox("The Quantity you intered in bigger than actual Quantity", MsgBoxStyle.Exclamation, "Prompt")
                    .Item("colQuantity", rowindex).Value = 0
                    CheckQTY = False
                Else
                    CheckQTY = False
                End If

            End With
        Catch ex As Exception
            MsgBox("ERROR: " & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
            CheckQTY = False
        End Try

    End Function


    Sub AddFields(ByVal rowindex As Integer)

        With dgDetails
            Dim dec As Integer = NZ(.Item("coldec", rowindex).Value)
            .Item("colUnitPrice", rowindex).Value = FormatNumber(NZ(.Item("colUnitPrice", rowindex).Value), dec)
            .Item("colAmount", rowindex).Value = FormatNumber(CDbl(NZ(.Item("colQuantity", rowindex).Value)) * CDbl(NZ(.Item("colUnitPrice", rowindex).Value)), 2)
            .Item("colQuantity", rowindex).Value = FormatNumber(ConvertToMoney(CDbl(NZ(.Item("colQuantity", rowindex).Value))))
            _dec = dec
        End With


    End Sub

    Function ComputeReceivableDate(ByVal varDate As DateTime) As DateTime
        Dim ReceivableDate As DateTime
        Try
            Dim PayTermsNoOfDays As Integer

            PayTermsNoOfDays = DBLookUp("SELECT NoOfDays FROM tbl_000_Supplier_PayTerms WHERE PayTermsName = '" & txtPaymentTerm.Text & "'", "NoOfDays")


            ReceivableDate = varDate.AddDays(PayTermsNoOfDays)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            ComputeReceivableDate = Nothing
        Finally
            ComputeReceivableDate = GetEndOfDate(ReceivableDate.Month, ReceivableDate.Year)
        End Try
    End Function

#End Region

#Region "GUI"
    Private Sub frm_100_DR_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_100_DR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frm_100_DR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        CenterControl(lblTitle, Me)
        FillAllCombo()

        With ErrProvider
            .Controls.Clear()
            .Controls.Add(txtDRCode, "Enter DR Code!")
            .Controls.Add(cboCustomerCode, "Select Customer!")
            .Controls.Add(cboDRType, "Select DR Type!")
            .Controls.Add(cbocurrency, "Select Currency Type!")
        End With
        LoadCurrencyType(cbocurrency)
        If bolFormState = FormState.EditState Then
            Call SetEditValue()
            Call ComputeRows()
            txtDRCode.ReadOnly = True
        Else
            txtDRCode.ReadOnly = False
            txtDeliveredBy.Text = CurrUser.USER_FULLNAME
        End If
    End Sub

    Private Sub cboCustomerCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerCode.SelectedIndexChanged
        FillCustomerName()
    End Sub



    Private Sub dgDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellValidated
        dgDetails.Item("colOrderType", e.RowIndex).Value = DBLookUp("SELECT OrderTypeCode FROM tbl_100_Order WHERE OrderNo = '" & dgDetails.Item("colOrderNo", e.RowIndex).Value & "'", "OrderTypeCode")
        Call AddFields(e.RowIndex)
        Call ComputeRows()

    End Sub

    Private Sub dgDetails_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgDetails.CellValidating
        Select Case e.ColumnIndex
            Case colQuantity.Index
                If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                    MsgBox("Please enter a numeric value.", MsgBoxStyle.Exclamation)
                    dgDetails.CancelEdit()
                End If
            Case colOrderNo.Index
                If dgDetails.Item("colOrderNo", e.RowIndex).FormattedValue <> "" Then
                    'FillCode(e.RowIndex, "Order")
                End If
        End Select
    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        lblRecordCount.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        lblRecordCount.Text = CountGridRows(dgDetails)
    End Sub
    ''09.20.2011
    Private Sub dtDRDate_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtDRDate.CloseUp
        If cboCustomerCode.SelectedValue <> "" Then
            txtReceivableDate.Text = ComputeReceivableDate(CDate(dtDRDate.Text))
        End If
    End Sub
    ''09.20.2011
    Private Sub dtDRDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtDRDate.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                txtReceivableDate.Text = ComputeReceivableDate(CDate(dtDRDate.Text))
        End Select
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Select Case e.ColumnIndex
            Case colBtnAdd.Index
             
                If cboCustomerCode.Text = String.Empty Then
                    MsgBox("Select Customer.", MsgBoxStyle.Exclamation, "Prompt")
                Else
                    With frm_SearchProduct
                        .customerId = cboCustomerCode.Text
                        '.Ordernum = dgDetails.Item("colOrderNo", e.RowIndex).Value
                        .ShowDialog()
                    End With
                End If
        End Select
    End Sub
    Private Sub btncopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncopy.Click
        If MessageBox.Show("Are you sure you want to add the details in new identification code?", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            With frmUnit
                .trans = "DR"
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub cbocurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocurrency.SelectedIndexChanged
        lblcurrency.Text = cbocurrency.Text
    End Sub

    Private Sub dgDetails_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgDetails.UserDeletedRow
    
    End Sub

    Private Sub dgDetails_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgDetails.UserDeletingRow
        Try
            If bolFormState = FormState.EditState Then
                If MsgBox("Are you sure you want to delete this item?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Prompt") = MsgBoxResult.Yes Then
                    Dim Orderno As String = dgDetails.Item("colOrderNo", dgDetails.CurrentRow.Index).Value
                    Dim ProductCode As String = dgDetails.Item("colProductCode", dgDetails.CurrentRow.Index).Value
                    Dim QTY As Double = dgDetails.Item("colQuantity", dgDetails.CurrentRow.Index).Value
                    Call DeleteRows(txtDRCode.Text, Orderno, ProductCode, QTY)
                    e.Cancel = False
                Else
                    e.Cancel = True

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region



End Class