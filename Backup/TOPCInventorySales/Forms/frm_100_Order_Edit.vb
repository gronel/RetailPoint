Imports System.Data.SqlClient
Imports TOPCInventorySales.clsPublic

Public Class frm_100_Order_Edit

#Region "Varible"
    Implements IBPSCommand
    Public myParent As frm_100_OrderList
    Public bolFormState As clsPublic.FormState
    Dim order As New tbl_100_Order
    Dim ErrProvider As New ErrorProviderExtended
    Public OrderCode As String
    Dim islist As New ArrayList
    Dim isfrmload As Boolean = True, islooping As Boolean = True
    Dim rates As Double
    Dim clsOrderEdit As New Order_Edit
    Dim dgGridTemp As DataGridView

    Private Enum state
        AddState = 0
        EditState = 1
    End Enum


#End Region

#Region "User Definition"

    Private Shared Sub LoadXrateToMultiCombo(ByVal Exrate As MTGCComboBox)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim dtLoading As New DataTable("tbl_000_ExchangeRate_Sub")
        Dim sqlCommand As New SqlCommand("SELECT     tbl_000_ExchangeRate_Sub.ExrateDetailedCode, tbl_Status.Description, tbl_000_ExchangeRate_Sub.ExrateValue " & _
                                         "FROM         tbl_000_ExchangeRate_Sub INNER JOIN " & _
                                         "tbl_000_ExchangeRate ON tbl_000_ExchangeRate_Sub.code = tbl_000_ExchangeRate.Exratecode INNER JOIN " & _
                                         "tbl_Status ON tbl_000_ExchangeRate.Currencyconversion = tbl_Status.StatusID", sqlConn)


        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With Exrate
            .ColumnNum = 3
            .ColumnWidth = "80;70;100"
            .GridLineHorizontal = True
            .GridLineVertical = True
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(2) {"ExrateDetailedCode", "Description", "ExrateValue"}
            .SourceDataTable = dtLoading
        End With
    End Sub


    Private Sub frm_100_Order_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        If bolFormState = FormState.EditState Then
            Call SetEditValue()
            Call ComputeRows()
            txtOrderCode.ReadOnly = True
            Call EnableFalseControl()
        Else
            txtOrderCode.ReadOnly = False
        End If
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_100_Order_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
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

    Sub ClearFields()
        txtOrderCode.Text = String.Empty
        cboOrderType.SelectedIndex = -1
        cboCustomerCode.SelectedIndex = -1
        dtOrderDate.Value = FormatDateTime(dtOrderDate.Text, DateFormat.ShortDate)
        cbocurrency.SelectedIndex = -1
        dgDetails.Rows.Clear()
        lblcurrency.Text = String.Empty
    End Sub

    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        ActivateCommands(FormState.LoadState)
        Me.Close()
    End Sub

    Private Sub SetEditValue()
        With order
            .FetchRecord(OrderCode)
            txtOrderCode.Text = .OrderCode
            cboOrderType.Text = .OrderType
            cboCustomerCode.SelectedValue = .CustomerCode
            dtOrderDate.Text = .OrderDate
            cbocurrency.SelectedValue = .ERSpecificCode
            cboexrate.SelectedValue = .Xrate
            cboxratetophp.SelectedValue = .XratePHP
            txtconvertedPHP.Text = NZ(.totalphp)
        End With
        Call FillAllDataGrid()
    End Sub

    Private Sub FillAllDataGrid()
        FillDataGrid(dgDetails, "GetOrder_Sub '" & txtOrderCode.Text.Trim & "'", 0, 21)
        lblRecordCount.Text = CountGridRows(dgDetails)

        dgGridTemp = dgDetails

        For i = 0 To dgDetails.RowCount - 1
            Call AddFields(i)
        Next
    End Sub

    Private Sub FillAllCombo()
        islooping = True
        LoadCustomerToMultiCombo(cboCustomerCode)
        LoadXrateToMultiCombo(cboexrate)
        LoadXrateToMultiCombo(cboxratetophp)
        islooping = False
    End Sub

    Private Sub FillCustomerName()
        If Not cboCustomerCode.SelectedValue Is Nothing Then
            txtCustomerName.Text = cboCustomerCode.SelectedItem.Col2
            txtPaymentTerms.Text = DBLookUp("GetCustomerPayTerms '" & cboCustomerCode.SelectedValue & "'", "PayTermsName")
        Else
            txtCustomerName.Text = String.Empty
            txtPaymentTerms.Text = String.Empty
        End If
    End Sub

    Private Sub SaveRecord()
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("SELECT OrderNo FROM tbl_100_Order WHERE OrderNo='" & txtOrderCode.Text & "'") Then
                    MsgBox("Product Code already exists.", MsgBoxStyle.Exclamation, "Prompt")
               
                Else

                    With clsOrderEdit
                        .OrderCode = txtOrderCode.Text.Trim
                        .OrderType = cboOrderType.Text
                        .CustomerCode = cboCustomerCode.SelectedValue
                        .OrderDate = dtOrderDate.Text
                        .ERSpecificCode = cbocurrency.Text
                        .TotalQuantity = NZ(txtTotalQuantity.Text)
                        .TotalAmount = NZ(txtTotalAmount.Text)
                        .ConvertedAmount = NZ(txtconvertedamount.Text)
                        .rate = rates
                        .Xrate = cboexrate.SelectedValue
                        .XratePHP = cboxratetophp.SelectedValue
                        .totalphp = txtconvertedPHP.Text
                        If MsgBox("Are you sure you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Prompt") = MsgBoxResult.No Then Exit Sub
                        _OpenTransaction()
                        _Result = .Save(bolFormState = FormState.EditState, dgDetails, dgGridTemp)
                        _CloseTransaction(_Result)

                        If _Result Then
                            If bolFormState = FormState.AddState Then
                                MsgBox("Save complete", MsgBoxStyle.Information, "Prompt")
                            Else
                                MsgBox("Update complete", MsgBoxStyle.Information, "Prompt")
                            End If
                            myParent.RefreshRecord("GetOrder'" & MainForm.tsSearch.Text & "'")
                            Me.Close()
                        End If
                    End With

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

#End Region

#Region "GUI"

    Private Sub frm_100_Order_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isfrmload = True
        Call ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        Call CenterControl(lblTitle, Me)
        Call FillAllCombo()
        LoadCurrencyType(cbocurrency)


        With ErrProvider
            .Controls.Clear()
            .Controls.Add(txtOrderCode, "Order Code")
            .Controls.Add(cboCustomerCode, "Customer Code")
            .Controls.Add(cbocurrency, "Cuurency Type")
            .Controls.Add(cboexrate, "Xrate jpy")
            .Controls.Add(cboxratetophp, "Xrate php")
            .Controls.Add(cboOrderType, "Order Type")
        End With

        isfrmload = False
    End Sub


#End Region


    Private Sub EnableFalseControl()
        For Each row As DataGridViewRow In dgDetails.Rows
            If row.IsNewRow = False Then
                If row.Cells("colLock").Value = "Lock" Then

                    row.Cells("colProductCode").ReadOnly = True
                    row.Cells("colTOC").ReadOnly = True
                    row.Cells("colQty").ReadOnly = True
                    row.Cells("colPacking").ReadOnly = True
                    row.Cells("colDeliveryDate").ReadOnly = True
                    row.Cells("colTOPDeliveryDate").ReadOnly = True
                    row.Cells("colQuantity").ReadOnly = True
                    row.Cells("colreconfirm").ReadOnly = True
                    row.Cells("colBtnAdd").ReadOnly = True


                    row.Cells("colProductCode").Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                    row.Cells("colTOC").Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                    row.Cells("colQty").Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                    row.Cells("colPacking").Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                    row.Cells("colDeliveryDate").Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                    row.Cells("colTOPDeliveryDate").Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                    row.Cells("colQuantity").Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                    row.Cells("colreconfirm").Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Transaction Mode Option
    ''' </summary>
    ''' <param name="isState"></param>
    ''' <remarks></remarks>
    Private Sub ControlTask(ByVal isState As state)
        Select Case isState
            Case state.AddState
                dgDetails.AllowUserToAddRows = True
                dgDetails.AllowUserToDeleteRows = True
                Call EnableFalseControl()
               

            Case state.EditState
                'Call EnableFalseControl()
                dgDetails.AllowUserToAddRows = False
                dgDetails.AllowUserToDeleteRows = False
                dgDetails.Item("colQuantity", dgDetails.CurrentRow.Index).Style.BackColor = Color.White
                dgDetails.Item("colQuantity", dgDetails.CurrentRow.Index).ReadOnly = False




        End Select

    End Sub

    Sub FillCode(ByVal rowindex As Integer)
        With dgDetails
            islist.Clear()
            islist = FetchData(islist, "GetOrder_CustomerProduct '" & cboCustomerCode.SelectedValue & "','" & .Item("colProductCode", rowindex).Value & "'", CommandType.Text)

            If islist.Count > 0 Then

                .Item("colproductno", rowindex).Value = islist(1).ToString
                .Item("colProductName", rowindex).Value = islist(2).ToString
                .Item("colUnit", rowindex).Value = islist(3).ToString
                .Item("colUnitPrice", rowindex).Value = islist(4)
                .Item("colPacking", rowindex).Value = "NO"
                .Item("colreconfirm", rowindex).Value = "Reconfirm"
                .Item("coldec", rowindex).Value = islist(5)
                .Item("colPriceID", rowindex).Value = islist(6)
                For i = 0 To dgDetails.RowCount - 1
                    .Item("colAdd", rowindex).Selected = False
                    .Item("colEdit", rowindex).Selected = False
                    Call CheckPacking(i)
                    dgDetails.Item("colReceivablePaymentDate", i).Value = ComputeReceivableDate(dgDetails.Item("colDeliveryDate", i).FormattedValue.ToString)
                Next
            End If

        End With
    End Sub

    Sub ComputeRows()
        With dgDetails
            Dim SumAmount, SumQty As Double
            Dim QTY As Double
            Dim ConvertedTotalAmount As Double
            Dim ConvertedTotalPHP As Double
            For Each row As DataGridViewRow In dgDetails.Rows
                If Not row.IsNewRow Then
                    QTY = row.Cells("colQuantity").Value
                    SumAmount += NZ(row.Cells("colQuantity").Value) * NZ(row.Cells("colUnitPrice").Value)
                    'SumAmount = SumAmount + row.Cells("colAmount").Value
                    SumQty = SumQty + QTY
                    ConvertedTotalAmount += (QTY * NZ(row.Cells("colUnitPrice").Value)) * NZ(txtxrate.Text)
                    ConvertedTotalPHP += (QTY * NZ(row.Cells("colUnitPrice").Value)) * NZ(txtxratephp.Text)
                    ''ConvertedTotalAmount = ConvertedTotalAmount + CDbl(NZ(row.Cells("colConverted").Value))
                    ''ConvertedTotalPHP += CDbl(row.Cells("colPHP").Value)
                End If
            Next

            txtTotalAmount.Text = FormatNumber(NZ(SumAmount))
            txtTotalQuantity.Text = FormatNumber(SumQty, 2)
            txtconvertedamount.Text = FormatNumber(NZ(ConvertedTotalAmount))
            txtconvertedPHP.Text = FormatNumber(ConvertedTotalPHP)
        End With
    End Sub

    Sub AddFields(ByVal rowindex As Integer)
        With dgDetails
            Dim _QTY As Double, _Unitprice As Double

            For Each row As DataGridViewRow In dgDetails.Rows
                If row.IsNewRow = False Then
                    row.Cells("colUnitPrice").Value = FormatNumber(NZ(row.Cells("colUnitPrice").Value), NZ(CInt(row.Cells("coldec").Value)))
                    _Unitprice = FormatNumber(NZ(row.Cells("colUnitPrice").Value), NZ(CInt(row.Cells("coldec").Value)))
                    If row.Cells("colQty").Value = Nothing Then Exit Sub
                    row.Cells("colQuantity").Value = ConvertToMoney(NZ(row.Cells("colQuantity").Value))

                    _QTY = row.Cells("colQuantity").Value

                    row.Cells("colAmount").Value = FormatNumber(_QTY * _Unitprice, 2)
                    row.Cells("colConverted").Value = FormatNumber((_QTY * _Unitprice) * rates, 2)
                    row.Cells("colPHP").Value = FormatNumber((_QTY * _Unitprice) * CDbl(NZ(txtxratephp.Text)))
                End If
            Next

        End With
    End Sub

    Function ComputeReceivableDate(ByVal varDate As DateTime) As DateTime
        Dim ReceivableDate As DateTime
        Try
            Dim PayTermsNoOfDays As Integer
            ''Dim enddate As DateTime
            PayTermsNoOfDays = DBLookUp("SELECT NoOfDays FROM tbl_000_Supplier_PayTerms WHERE PayTermsName = '" & txtPaymentTerms.Text & "'", "NoOfDays")

            ReceivableDate = varDate.AddDays(PayTermsNoOfDays)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            ComputeReceivableDate = Nothing
        Finally
            ComputeReceivableDate = ReceivableDate
        End Try
    End Function

    Private Sub CheckPacking(ByVal rowindex As Integer)

        Dim _packing As String = dgDetails.Item("colPacking", rowindex).Value
        Dim _QTY As Double
        ''check the packing status 

        Select Case _packing
            Case "YES"
                _QTY = IIf(dgDetails.Item("colQty", rowindex).Value.ToString = "N/A", 0, dgDetails.Item("colQty", rowindex).Value)
                dgDetails.Item("colQty", rowindex).Value = _QTY * 1
            Case "NO"
                dgDetails.Item("colQty", rowindex).Value = "N/A"

        End Select

        AddFields(rowindex)



    End Sub

    Private Sub cboCustomerCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerCode.SelectedIndexChanged
        FillCustomerName()
    End Sub


    Private Sub dgDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellValidated
        Select Case e.ColumnIndex
            Case colDeliveryDate.Index
                If Not dgDetails.Rows.Equals(dgDetails.NewRowIndex) Then
                    If dgDetails.Item("colDeliveryDate", e.RowIndex).FormattedValue <> "" And IsDate(dgDetails.Item("colDeliveryDate", e.RowIndex).EditedFormattedValue) Then
                        dgDetails.Item("colReceivablePaymentDate", e.RowIndex).Value = ComputeReceivableDate(dgDetails.Item("colDeliveryDate", e.RowIndex).FormattedValue.ToString)
                    End If
                End If
        End Select

        Call CheckPacking(e.RowIndex)
        Call AddFields(e.RowIndex)
        Call ComputeRows()
    End Sub

    Private Sub dgDetails_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgDetails.CellValidating


        Select Case e.ColumnIndex

            Case colDeliveryDate.Index
                If dgDetails.Item("colDeliveryDate", e.RowIndex).FormattedValue <> "" Then
                    If IsDate(dgDetails.Item("colDeliveryDate", e.RowIndex).EditedFormattedValue) = False Then
                        MsgBox("Please enter correct date.", MsgBoxStyle.Exclamation, "Invalid Date")
                        dgDetails.CancelEdit()
                    Else
                        dgDetails.Item("colReceivablePaymentDate", e.RowIndex).Value = ComputeReceivableDate(dgDetails.Item("colDeliveryDate", e.RowIndex).FormattedValue.ToString)
                    End If
                End If
            Case colTOPDeliveryDate.Index
                If dgDetails.Item("colTOPDeliveryDate", e.RowIndex).FormattedValue <> "" Then
                    If IsDate(dgDetails.Item("colTOPDeliveryDate", e.RowIndex).EditedFormattedValue) = False Then
                        MsgBox("Please enter correct date.", MsgBoxStyle.Exclamation, "Invalid Date")
                        dgDetails.CancelEdit()
                    End If
                End If



        End Select
    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        lblRecordCount.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        lblRecordCount.Text = CountGridRows(dgDetails)
    End Sub


    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Select Case e.ColumnIndex
            Case colAdd.Index
                ControlTask(state.AddState)
            Case colEdit.Index
                ControlTask(state.EditState)
            Case colBtnAdd.Index
                If dgDetails.Item("colLock", e.RowIndex).Value <> "Lock" Then
                    With frmSearchItems
                        .frm = "Order_Update"
                        .strCode = cboCustomerCode.SelectedValue
                        .Text = "Search Product(s)"
                        .dgSearchItems.Visible = False
                        .dgSearchProduct.Visible = True
                        .ShowControls(False)
                        .ShowDialog()
                    End With
                End If
            Case colreconfirm.Index
                With frm_100_Reconfirm
                    .OrderNo = Me.txtOrderCode.Text
                    .ProductCode = dgDetails.Item("colProductCode", e.RowIndex).Value
                    .mystate = FormState.ViewState

                    .ShowDialog()
                End With


        End Select
    End Sub




    Private Sub cbocurrency_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbocurrency.SelectedValueChanged
        lblcurrency.Text = cbocurrency.Text
    End Sub

    Private Sub cbocurrency_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbocurrency.Validated
        lblcurrency.Text = cbocurrency.Text
    End Sub

    Private Sub cboexrate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboexrate.Validated, cboexrate.Validated
        If Not cboexrate.SelectedValue Is Nothing Then
            rates = cboexrate.SelectedItem.Col3
            txtxrate.Text = rates
            For i = 0 To dgDetails.RowCount - 1
                Call AddFields(i)
            Next
            Call ComputeRows()
        Else
            rates = 0
        End If
    End Sub

    Private Sub cboexrate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboexrate.SelectedIndexChanged, cboexrate.SelectedIndexChanged
        If Not cboexrate.SelectedValue Is Nothing Then
            rates = cboexrate.SelectedItem.Col3
            txtxrate.Text = FormatNumber(NZ(rates), 2)
            For i = 0 To dgDetails.RowCount - 1
                Call AddFields(i)
            Next
            Call ComputeRows()
        Else
            rates = 0
        End If
    End Sub

    Private Sub cboxratetophp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxratetophp.SelectedIndexChanged
        If Not cboxratetophp.SelectedValue Is Nothing Then
            txtxratephp.Text = FormatNumber(NZ(cboxratetophp.SelectedItem.Col3), 2)

            For i = 0 To dgDetails.RowCount - 1
                Call AddFields(i)
            Next
            Call ComputeRows()
        Else
            txtxratephp.Text = String.Empty
        End If
    End Sub

    Private Sub cboxratetophp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxratetophp.Validated
        If Not cboxratetophp.SelectedValue Is Nothing Then
            txtxratephp.Text = cboxratetophp.SelectedItem.Col3

            For i = 0 To dgDetails.RowCount - 1
                Call AddFields(i)
            Next
            Call ComputeRows()
        Else
            txtxratephp.Text = String.Empty
        End If
    End Sub

    Private Sub txtTotalQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalQuantity.TextChanged

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub dgDetails_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgDetails.UserDeletingRow
        If isRecordExist("SELECT     tbl_100_DR_Sub.OrderNo, tbl_100_DR_Sub.ProductCode " & _
                            "FROM         tbl_100_DR_Sub INNER JOIN tbl_100_DR ON tbl_100_DR_Sub.DRNo = tbl_100_DR.DRNo " & _
                            "WHERE     (tbl_100_DR.Status <> N'CANCELLED') AND (tbl_100_DR_Sub.OrderNo = '" & txtOrderCode.Text & "') AND (tbl_100_DR_Sub.ProductCode = '" & dgDetails.Item("colProductCode", dgDetails.CurrentRow.Index).Value & "')") = False Then

            If MsgBox("Are you sure you want to Delete this product?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Prompt") = MsgBoxResult.Yes Then
                e.Cancel = False
                RunQuery("DELETE FROM tbl_100_Order_Sub WHERE     (OrderNo = '" & txtOrderCode.Text & "') AND (ProductCode = '" & dgDetails.Item("colProductCode", dgDetails.CurrentRow.Index).Value & "')")

            Else
                e.Cancel = True
            End If

        Else
            e.Cancel = True
        End If
        'If dgDetails.Item("colLock", dgDetails.CurrentRow.Index).Value = "Lock" Then
        '   
        'End If
    End Sub

    Private Sub dgDetails_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgDetails.UserDeletedRow

    End Sub
End Class