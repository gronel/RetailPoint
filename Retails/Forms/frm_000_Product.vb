Imports System.Data.SqlClient
Imports Retails.clsPublic

Public Class frm_000_Product
    'Implements IBPSCommand

#Region "Variable"
    Implements IBPSCommand

    Public myParent As frm_000_ProductList
    Public bolFormState As clsPublic.FormState

    Dim ErrProvider As New ErrorProviderExtended
    Public ProCode As String
    Private isStart As Boolean = True
    Dim product As New tbl_000_Product
    Dim clsSelling As New tbl_000_Selling
    Dim clsProcess As New tbl_000_Product_Process
    Dim dec As Integer
    Dim frmload As Boolean = False, islooping As Boolean = False
#End Region


#Region "Procedure and User Difination"

    Public Shared Sub LoadInternalSupplierToMultiCombo(ByVal cboMultiCombo As MTGCComboBox)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim dtLoading As New DataTable("tbl_000_InternalSupplier")
        Dim sqlCommand As New SqlCommand("SELECT inSupplierCode,inSupplierName " & _
                                         "FROM tbl_000_InternalSupplier ORDER BY inSupplierName", sqlConn)


        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With cboMultiCombo
            .ColumnNum = 2
            .ColumnWidth = "100;200"
            .GridLineHorizontal = True
            .GridLineVertical = True
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(1) {"inSupplierCode", "inSupplierName"}
            .SourceDataTable = dtLoading
        End With
    End Sub

    Private Sub GetGrandTotal()
        Dim sellingtotal As Double = txtsellingamount.Text
        Dim processtotal As Double = txtprocessAMT.Text
        txtgrandtotal.Text = FormatNumber(sellingtotal + processtotal, 2)

    End Sub

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                ''NewRecord()
            Case "Edit"
                ''EditRecord()
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
        End Select
    End Sub

    Private Sub computeAllSellingDetails()
        Dim sellingtotal As Double = 0
        Dim sellingQTY As Double = 0
        For Each row As DataGridViewRow In dgSellingDetails.Rows
            If row.IsNewRow = False Then
                sellingtotal += row.Cells("colsellingConAmount").Value
                sellingQTY += row.Cells("colSellingQTY").Value
            End If
        Next
        txtsellingamount.Text = FormatNumber(ConvertToMoney(sellingtotal), 2)
        txtSellingQTY.Text = ConvertToMoney(sellingQTY)
    End Sub

    Private Sub ADDProcessFields(ByVal rowindex As Integer)
        With dgprocess
            arrParametersAndValue.Clear()
            arrParametersAndValue = FetchData(arrParametersAndValue, "SELECT     tbl_Status.Description, tbl_000_ExchangeRate_Sub.ExrateValue " & _
                                                                  "FROM         tbl_000_ExchangeRate INNER JOIN " & _
                                                                  "tbl_000_ExchangeRate_Sub ON tbl_000_ExchangeRate.Exratecode = tbl_000_ExchangeRate_Sub.code INNER JOIN " & _
                                                                  "tbl_Status ON tbl_000_ExchangeRate.Currencyconversion = tbl_Status.StatusID " & _
                                                                 "WHERE     (tbl_000_ExchangeRate_Sub.ExrateDetailedCode = '" & .Item("colExrate", rowindex).Value & "')", CommandType.Text)

            If arrParametersAndValue.Count > 0 Then
                .Item("colProcessDes", rowindex).Value = arrParametersAndValue(0).ToString
                .Item("colProcessExRate", rowindex).Value = arrParametersAndValue(1)
            End If



            .Item("colProcessExRate", rowindex).Value = ConvertToMoney(NZ(.Item("colProcessExRate", rowindex).Value))

            .Item("colProcessAmount", rowindex).Value = Val(NZ(.Item("colProcessAMT", rowindex).Value)) * Val(NZ(.Item("colProcessExRate", rowindex).Value))

            .Item("colProcessAmount", rowindex).Value = ConvertToMoney(NZ(.Item("colProcessAmount", rowindex).Value))

            .Item("colProcessAMT", rowindex).Value = ConvertToMoney(NZ(.Item("colProcessAMT", rowindex).Value))

        End With
    End Sub

    Private Sub ADDSellingFields(ByVal rowIndex As Integer)
        With dgSellingDetails

            arrParametersAndValue.Clear()
            arrParametersAndValue = FetchData(arrParametersAndValue, "SELECT     tbl_Status.Description, tbl_000_ExchangeRate_Sub.ExrateValue " & _
                                                                  "FROM         tbl_000_ExchangeRate INNER JOIN " & _
                                                                  "tbl_000_ExchangeRate_Sub ON tbl_000_ExchangeRate.Exratecode = tbl_000_ExchangeRate_Sub.code INNER JOIN " & _
                                                                  "tbl_Status ON tbl_000_ExchangeRate.Currencyconversion = tbl_Status.StatusID " & _
                                                                  "WHERE     (tbl_000_ExchangeRate_Sub.ExrateDetailedCode = '" & .Item("colsellingExCode", rowIndex).Value & "')", CommandType.Text)

            If arrParametersAndValue.Count > 0 Then
                .Item("colsellingDescription", rowIndex).Value = arrParametersAndValue(0).ToString
                .Item("colselllingExrate", rowIndex).Value = arrParametersAndValue(1)
            End If


            If .Item("colsellingExCode", rowIndex).Value = String.Empty Or .Item("colsellingExCode", rowIndex).Value = Nothing Then
            Else


                .Item("colselllingExrate", rowIndex).Value = ConvertToMoney(NZ(.Item("colselllingExrate", rowIndex).Value))




                .Item("colsellingConUnitPrice", rowIndex).Value = FormatNumber(CDbl(NZ(.Item("colsellingUnitPrice", rowIndex).Value)) * CDbl(NZ(.Item("colselllingExrate", rowIndex).Value)), 2)
                .Item("colsellingConAmount", rowIndex).Value = FormatNumber(CDbl(NZ((.Item("colSellingQTY", rowIndex).Value)) * CDbl(NZ(.Item("colsellingConUnitPrice", rowIndex).Value))), 2)



            End If
            .Item("colsellingUnitPrice", rowIndex).Value = FormatNumber(ConvertToMoney(NZ(.Item("colsellingUnitPrice", rowIndex).Value)), 2)
            .Item("colSellingQTY", rowIndex).Value = FormatNumber(ConvertToMoney(NZ(.Item("colSellingQTY", rowIndex).Value)), 2)
            .Item("colsellingConUnitPrice", rowIndex).Value = FormatNumber(ConvertToMoney(NZ(.Item("colsellingConUnitPrice", rowIndex).Value)), 2)
            .Item("colsellingConAmount", rowIndex).Value = FormatNumber(ConvertToMoney(NZ(.Item("colsellingConAmount", rowIndex).Value)), 2)

        End With
    End Sub

    Private Sub clearall()
        txtProductCode.Clear()
        txtPartNo.Clear()
        txtProductName.Clear()
        cboProductType.Text = ""
        cboCustomer.Text = ""
        txtSellingQTY.Text = 0
        txtsellingamount.Text = 0
        txtprocessAMT.Text = 0
        chkIsActive.Checked = False
        dgPriceHistory.Rows.Clear()
        dgProductParts.Rows.Clear()
        dgSellingDetails.Rows.Clear()
        dgprocess.Rows.Clear()

        cboProcessDate.SelectedIndex = -1


        txtTotalAmount.Text = String.Empty


    End Sub
    ''fill all combobox
    Sub FillAllCombo()


        FillCombobox(cboProductType, "SELECT ProductType FROM tbl_000_Product GROUP BY ProductType " & _
                            " ORDER BY ProductType", "tbl_000_Product", "ProductType", "ProductType")

        FillCombobox(cboUsage, "SELECT Usage FROM tbl_000_Product " & _
                                "GROUP BY Usage ", "tbl_000_Product", "Usage", "Usage")

        ''customer
        LoadCustomerToMultiCombo(cboCustomer)

        ''Internal supplier
        LoadInternalSupplierToMultiCombo(cboInternalSupplier)

        ''datagrid combo for currency
        FillDataGridViewComboBoxColumn(colCurrency, "SELECT Currency FROM tbl_000_Currency ORDER BY " & _
                                       "Currency", "tbl_000_Currency", "Currency", "Currency")

        FillDataGridViewComboBoxColumn(coldec, "SELECT StatusID, Description, Usage FROM tbl_Status where Usage='dec' ORDER BY Description", "tbl_Status", "Description", "Description")
        ''datagrid combo for unit
        FillDataGridViewComboBoxColumn(colUnit, "SELECT Unit FROM tbl_Product_UOM ORDER BY dbo.AlphaNum(Unit)", _
                                       "tbl_UOM", "Unit", "Unit")
        ''datagrid combo for suppliercode
        FillDataGridViewComboBoxColumn(colSupplierID, "SELECT SupplierID FROM tbl_000_Supplier " & _
                                       " ORDER BY SupplierID", "tbl_000_Supplier", "SupplierID", _
                                       "SupplierID")


        FillDataGridViewComboBoxColumn(colCode, "SELECT     ExrateDetailedCode " & _
                                                "FROM         tbl_000_ExchangeRate_Sub", "tbl_000_ExchangeRate_Sub", "ExrateDetailedCode", "ExrateDetailedCode")


        FillDataGridViewComboBoxColumn(colExrate, "SELECT * " & _
                                              "FROM tbl_ConversionType", "tbl_ConversionType", "ConversionType", "ConversionType")



        FillDataGridViewComboBoxColumn(ColSellingUnit, "SELECT Unit FROM tbl_UOM", "tbl_UOM", "Unit", "Unit")


        FillDataGridViewComboBoxColumn(colProcessCurrency, "SELECT Currency FROM tbl_000_Currency ORDER BY " & _
                                      "Currency", "tbl_000_Currency", "Currency", "Currency")

        FillDataGridViewComboBoxColumn(colExrate, "SELECT * " & _
                                             "FROM tbl_ConversionType", "tbl_ConversionType", "ConversionType", "ConversionType")


        FillDataGridViewComboBoxColumn(colmaterialCtype, "SELECT Currency FROM tbl_000_Currency ORDER BY " & _
                                      "Currency", "tbl_000_Currency", "Currency", "Currency")

        FillDataGridViewComboBoxColumn(colsellingCtype, "SELECT Currency FROM tbl_000_Currency ORDER BY " & _
                                            "Currency", "tbl_000_Currency", "Currency", "Currency")


        FillDataGridViewComboBoxColumn(colsellingExCode, "SELECT     ExrateDetailedCode " & _
                                                        "FROM         tbl_000_ExchangeRate_Sub", "tbl_000_ExchangeRate_Sub", "ExrateDetailedCode", "ExrateDetailedCode")


        FillDataGridViewComboBoxColumn(colExrate, "SELECT     ExrateDetailedCode " & _
                                                  "FROM         tbl_000_ExchangeRate_Sub", "tbl_000_ExchangeRate_Sub", "ExrateDetailedCode", "ExrateDetailedCode")

        FillCombobox(cboProductModel, "SELECT distinct ProductModel FROM tbl_000_Product WHERE (IsStatus = 1) ORDER BY ProductModel", "tbl_000_Product", "ProductModel", "ProductModel")

        cboProductModel.SelectedIndex = -1
        cboProductType.SelectedIndex = -1

    End Sub

    Sub FillCustomerName()
        If Not cboCustomer.SelectedValue Is Nothing Then
            txtCustomerName.Text = cboCustomer.SelectedItem.Col2
        Else
            txtCustomerName.Text = String.Empty
        End If
    End Sub

    Private Sub SaveRecord()
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("SELECT ProductCode FROM tbl_000_Product WHERE ProductCode='" & txtProductCode.Text & "'") Then
                    MsgBox("Product Code already exists.", MsgBoxStyle.Exclamation, "Duplicate")


                Else

                    If lblprocess.Text <> 0 Then
                        If cboProcessDate.Text = String.Empty Then
                            MsgBox("Select Process Date First", MsgBoxStyle.Exclamation, "Prompt")
                            Exit Sub
                        End If
                    End If

                    ''1. -->Save Product Details
                    With product
                        .ProductCode = txtProductCode.Text.Trim
                        .PartNo = txtPartNo.Text
                        .ProductName = txtProductName.Text
                        .ProductType = cboProductType.Text
                        .CustomerCode = cboCustomer.SelectedValue
                        .IsStatus = chkIsActive.Checked
                        .Usage = cboUsage.Text
                        .InternalSupplier = cboInternalSupplier.Text
                        .ProductModel = cboProductModel.Text
                        _Result = .Save(bolFormState = FormState.EditState, dgPriceHistory, dgProductParts, dgMaterial)
                    End With

                    ''2. -->Save Selling Details
                    With clsSelling
                        .SellingCode = txtProductCode.Text.Trim
                        .SellingDate = IIf(cboProcessDate.Text = String.Empty, Now.Date, cboProcessDate.Text)
                        _Result = .Save(dgSellingDetails)
                    End With

                    ''3. -->Save Product Process
                    With clsProcess
                        .ProcessCode = txtProductCode.Text
                        .ProcessDate = IIf(cboProcessDate.Text = String.Empty, Now.Date, cboProcessDate.Text)
                        _Result = .Save(dgprocess)
                    End With

                    If _Result Then
                        If bolFormState = FormState.EditState Then
                            MsgBox("Update Complete", MsgBoxStyle.Information, "Prompt")
                        Else
                            MsgBox("Save Complete", MsgBoxStyle.Information, "Prompt")
                        End If

                        ClearFields()
                        myParent.RefreshRecord("GetProduct '" & MainForm.tsSearch.Text & "'")
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    Sub ClearFields()
        txtProductCode.Text = String.Empty
        txtPartNo.Text = String.Empty
        txtProductName.Text = String.Empty
        cboProductType.SelectedIndex = -1
        cboCustomer.SelectedIndex = -1
        dgMaterial.Rows.Clear()
        dgPriceHistory.Rows.Clear()
        dgProductParts.Rows.Clear()
        txtProductCode.Focus()
    End Sub

    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        Me.Close()
    End Sub

    

    Private Sub ReadOnlyrows()
        For Each row As DataGridViewRow In dgPriceHistory.Rows
            If row.IsNewRow = False Then
                row.Cells(1).ReadOnly = True
                row.Cells(2).ReadOnly = True
                row.Cells(3).ReadOnly = True
                row.Cells(4).ReadOnly = True
                row.Cells(5).ReadOnly = True
                row.Cells(1).Style.BackColor = Color.AliceBlue
                row.Cells(2).Style.BackColor = Color.AliceBlue
                row.Cells(3).Style.BackColor = Color.AliceBlue
                row.Cells(4).Style.BackColor = Color.AliceBlue
                row.Cells(5).Style.BackColor = Color.AliceBlue
            End If
        Next

    End Sub
    Private Sub SetEditValue()
        Try
            With product
                .FetchRecord(ProCode)
                txtProductCode.Text = .ProductCode
                txtPartNo.Text = .PartNo
                txtProductName.Text = .ProductName
                cboProductType.SelectedValue = .ProductType
                cboCustomer.Text = .CustomerCode
                chkIsActive.Checked = .IsStatus
                cboUsage.Text = .Usage
                cboInternalSupplier.Text = .InternalSupplier
                cboProductModel.Text = .ProductModel
                Call FillAllDataGrid()
                Call ReadOnlyrows()
                With dgProductParts
                    For Each row As DataGridViewRow In dgProductParts.Rows
                        If row.IsNewRow = False Then
                            row.Cells("colconprice").Value = CDbl(NZ(row.Cells("colPartsUnitPrice").Value)) * CDbl(NZ(row.Cells("colvalue").Value))
                            row.Cells("colAmount").Value = CDbl(NZ((row.Cells("colQuantity").Value)) * CDbl(NZ(row.Cells("colconprice").Value)))
                            row.Cells("colconprice").Value = ConvertToMoney(row.Cells("colconprice").Value)
                            row.Cells("colAmount").Value = ConvertToMoney(row.Cells("colAmount").Value)
                            row.Cells("colvalue").Value = ConvertToMoney(NZ(row.Cells("colvalue").Value))
                        End If
                    Next
                End With

            End With
        Catch ex As Exception
            MsgBox("Error:SetEditValue -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try

    End Sub

    Sub FillAllDataGrid()
        ''sub
        FillDataGrid(dgPriceHistory, "GetProductSub '" & txtProductCode.Text & "'", 1, 7)
        ValidatedPriceHistorey()

        ''parts
        FillDataGrid(dgProductParts, "GetProductPartsAndMaterials '" & txtProductCode.Text & "'", 0, 11)

        lblPriceHistoryCount.Text = dgPriceHistory.RowCount - 1
        lblPartsCount.Text = dgProductParts.RowCount - 1
        lblMaterialCount.Text = dgMaterial.RowCount - 1
    End Sub

    Sub FillCode(ByVal rowindex As Integer, ByVal which As String)
        Try
            Dim paramAray As ArrayList = New ArrayList
            paramAray.Clear()

            Select Case which
                Case "Product"
                    With dgProductParts

                        paramAray = FetchData(Nothing, "sp_GetProductDetails '" & .Item(0, rowindex).Value & "'", CommandType.Text)

                        .Item("colItemDescription", rowindex).Value = paramAray(1).ToString
                        .Item("colBrandLensType", rowindex).Value = paramAray(2).ToString
                        .Item("colPartsUnit", rowindex).Value = paramAray(3).ToString
                        .Item("colmaterialCtype", rowindex).Value = paramAray(5).ToString
                        .Item("colPartsUnitPrice", rowindex).Value = FormatNumber(paramAray(4), CInt(paramAray(6)))
                    End With

                Case "Material"
                    With dgMaterial
                        .Item("colMaterialItemDescription", rowindex).Value = DBLookUp("SELECT SpecificDescription FROM tbl_000_Item_Sub WHERE SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "SpecificDescription")
                        .Item("colMaterialBrandType", rowindex).Value = DBLookUp("SELECT BrandType FROM tbl_000_Item_Sub WHERE SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "BrandType")
                        .Item("colMaterialStatus", rowindex).Value = DBLookUp("SELECT isActive FROM tbl_000_Item_Sub WHERE SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "isActive")
                    End With
            End Select
        Catch ex As Exception
            MsgBox("Error:Fillcode -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try

    End Sub

    Sub AddFields(ByVal rowIndex As Integer)
        With dgProductParts

            If .Item("colCode", rowIndex).Value = String.Empty Or .Item("colCode", rowIndex).Value = Nothing Then
            Else
                arrParametersAndValue.Clear()
                arrParametersAndValue = FetchData(arrParametersAndValue, "SELECT     tbl_Status.Description, tbl_000_ExchangeRate_Sub.ExrateValue " & _
                                                                      "FROM         tbl_000_ExchangeRate INNER JOIN " & _
                                                                      "tbl_000_ExchangeRate_Sub ON tbl_000_ExchangeRate.Exratecode = tbl_000_ExchangeRate_Sub.code INNER JOIN " & _
                                                                      "tbl_Status ON tbl_000_ExchangeRate.Currencyconversion = tbl_Status.StatusID " & _
                                                                      "WHERE     (tbl_000_ExchangeRate_Sub.ExrateDetailedCode = '" & .Item("colCode", rowIndex).Value & "')", CommandType.Text)

                If arrParametersAndValue.Count > 0 Then
                    .Item("colmaterialExrateDescription", rowIndex).Value = arrParametersAndValue(0).ToString
                    .Item("colvalue", rowIndex).Value = arrParametersAndValue(1)
                End If
                '.Item("colmaterialExrateDescription", rowIndex).Value = DBLookUp("SELECT     TOP (1) tbl_000_ExchangeRate_Sub.Year " & _
                '                                            "FROM         tbl_000_ExchangeRate_Sub INNER JOIN " & _
                '                                            "tbl_ConversionType ON tbl_000_ExchangeRate_Sub.Cid = tbl_ConversionType.Cid " & _
                '                                            "WHERE     (tbl_ConversionType.ConversionType = '" & .Item("colCode", rowIndex).Value & "') " & _
                '                                            "ORDER BY tbl_000_ExchangeRate_Sub.Year DESC, tbl_000_ExchangeRate_Sub.rec DESC", "Year")
                '.Item("colvalue", rowIndex).Value = DBLookUp("SELECT     TOP (1) tbl_000_ExchangeRate_Sub.ExchangeRateValue " & _
                '                                             "FROM         tbl_000_ExchangeRate_Sub INNER JOIN " & _
                '                                             "tbl_ConversionType ON tbl_000_ExchangeRate_Sub.Cid = tbl_ConversionType.Cid " & _
                '                                             "WHERE     (tbl_ConversionType.ConversionType = '" & .Item("colCode", rowIndex).Value & "') " & _
                '                                             "ORDER BY tbl_000_ExchangeRate_Sub.Year DESC, tbl_000_ExchangeRate_Sub.rec DESC", "ExchangeRateValue")



                '.Item("Column1", rowIndex).Value = DBLookUp("SELECT     CurrencyFrom " & _
                '                                                  "FROM tbl_000_ExchangeRate " & _
                '                                                  "WHERE     (Currencyconversion ='" & .Item("colCode", rowIndex).Value & "')", "CurrencyFrom")
            End If

            .Item("colQuantity", rowIndex).Value = ConvertToMoney(NZ(.Item("colQuantity", rowIndex).Value))
            .Item("colvalue", rowIndex).Value = ConvertToMoney(NZ(.Item("colvalue", rowIndex).Value))


            .Item("colconprice", rowIndex).Value = CDbl(NZ(.Item("colPartsUnitPrice", rowIndex).Value)) * CDbl(NZ(.Item("colvalue", rowIndex).Value))
            .Item("colAmount", rowIndex).Value = CDbl(NZ((.Item("colQuantity", rowIndex).Value)) * CDbl(NZ(.Item("colconprice", rowIndex).Value)))

            .Item("colconprice", rowIndex).Value = ConvertToMoney(NZ(.Item("colconprice", rowIndex).Value))
            .Item("colAmount", rowIndex).Value = ConvertToMoney(NZ(.Item("colAmount", rowIndex).Value))
        End With
    End Sub

    Sub ComputeRows()
        Dim SumAmount, SumQty As Double

        With dgProductParts
            For Each row As DataGridViewRow In dgProductParts.Rows
                If Not row.IsNewRow Then
                    SumAmount = SumAmount + row.Cells("colAmount").Value
                    SumQty = SumQty + row.Cells("colQuantity").Value
                End If
            Next

            txtTotalAmount.Text = FormatNumber(NZ(SumAmount))
            txtTotalQuantity.Text = SumQty
        End With
    End Sub

    Private Sub isfrmload()
        islooping = True
        If isStart = True Then
            Call FillAllCombo()
            If bolFormState = FormState.EditState Then
                Call SetEditValue()
                Call ComputeRows()
                txtProductCode.ReadOnly = True

            Else

                txtProductCode.ReadOnly = False
                txtCustomerName.Text = String.Empty

            End If
            isStart = False

        End If
        ''Fill selling date and process date

        FillCombobox(cboProcessDate, "SELECT    convert(nvarchar(10),EffectiveDate,101) as EffectiveDate " & _
                             "FROM tbl_000_Product_Sub " & _
                             "WHERE     (Status = 1) AND (ProductCode = '" & txtProductCode.Text & "') " & _
                             "ORDER BY EffectiveDate", "tbl_000_Product_Sub", "EffectiveDate", "EffectiveDate")


        cboProcessDate.SelectedIndex = -1
        islooping = False
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

    Private Sub ValidatedPriceHistorey()
        Dim _unitprice As Double
        Dim _Dec As Integer

        For Each row As DataGridViewRow In dgPriceHistory.Rows
            If row.IsNewRow = False Then
                _unitprice = NZ(row.Cells("colUnitPrice").Value)
                _Dec = NZ(row.Cells("coldec").Value)
                row.Cells("colUnitPrice").Value = FormatNumber(_unitprice, _Dec)
            End If
        Next

    End Sub


    Private Sub FillSupplier()
        If Not cboInternalSupplier.SelectedValue Is Nothing Then
            txtsuppliername.Text = cboInternalSupplier.SelectedItem.Col2

        Else
            txtsuppliername.Text = String.Empty
        End If
    End Sub

#End Region

#Region "GUI"

    Private Sub frm_000_Product_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        If bolFormState = FormState.EditState Then
            ActivateCommands(FormState.EditState)
        Else
            ActivateCommands(FormState.AddState)
        End If
    End Sub


    Private Sub frm_000_CustomerList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.KeyCode = Keys.F3 Then
            frmActUnit.mysender = "Product"
            frmActUnit.ShowDialog()
        End If
    End Sub

    Private Sub frm_000_Product_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        frmload = True
        isStart = True
        With ErrProvider
            .Controls.Clear()
            .Controls.Add(txtProductCode, "Product Code")
            .Controls.Add(txtProductName, "Product Name")
            .Controls.Add(cboProductType, "Product Type")
            .Controls.Add(cboCustomer, "Customer")
        End With
        Me.TabControl1.SelectedIndex = 0
        Call clearall()
        Call isfrmload()
        frmload = False
        CenterControl(lblTitle, Me)
    End Sub

    Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        FillCustomerName()
    End Sub

    Private Sub dgProductParts_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProductParts.CellContentClick
        Select Case e.ColumnIndex
            Case 1
                With frmSearchItems
                    .frm = "Product"
                    .ShowDialog()
                End With
        End Select
    End Sub

    Private Sub dgProductParts_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProductParts.CellValidated
        AddFields(e.RowIndex)
        ComputeRows()
    End Sub

    Private Sub dgProductParts_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgProductParts.CellValidating
        Select Case e.ColumnIndex
            Case colQuantity.Index
                With dgProductParts

                    If ValidateNumericDataGrid(dgProductParts, e.ColumnIndex, e.RowIndex, False) = False Then
                        MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                        e.Cancel = True
                    End If
                End With
        End Select
    End Sub

    Private Sub dgPriceHistory_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs)
        Select Case e.ColumnIndex
            Case colEffectiveDate1.Index
                With dgPriceHistory
                    If .Item("colEffectiveDate1", e.RowIndex).FormattedValue <> "" Then
                        If IsDate(.Item("colEffectiveDate1", e.RowIndex).EditedFormattedValue) = False Then
                            MsgBox("Invalid Date!", MsgBoxStyle.Exclamation, "Invalid!")
                            dgPriceHistory.CancelEdit()
                        End If
                    End If
                End With

            Case colUnitPrice.Index
                With dgPriceHistory
                    If ValidateNumericDataGrid(dgPriceHistory, e.ColumnIndex, e.RowIndex, False) = False Then
                        MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                        e.Cancel = True
                    End If
                End With
        End Select
    End Sub

   

    Private Sub dgPriceHistory_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPriceHistory.CellValidated
        ValidatedPriceHistorey()
    End Sub

    Private Sub dgPriceHistory_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgPriceHistory.RowsAdded
        lblPriceHistoryCount.Text = CountGridRows(dgPriceHistory)
    End Sub

    Private Sub dgPriceHistory_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgPriceHistory.RowsRemoved
        lblPriceHistoryCount.Text = CountGridRows(dgPriceHistory)
    End Sub

    Private Sub dgProductParts_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgProductParts.RowsAdded
        lblPartsCount.Text = dgProductParts.RowCount - 1
    End Sub

    Private Sub dgProductParts_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgProductParts.RowsRemoved
        lblPartsCount.Text = dgProductParts.RowCount - 1
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call SaveRecord()
    End Sub

    Private Sub dgMaterial_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMaterial.CellContentClick
        Select Case e.ColumnIndex
            Case colBtnAdd.Index
                With frmSearchItems
                    .frm = "Material"
                    .ShowDialog()
                End With
        End Select
    End Sub

    Private Sub dgMaterial_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMaterial.CellValidated
        Select Case e.ColumnIndex
            Case colSupplierID.Index
                dgMaterial.Item("colSupplierName", e.RowIndex).Value = DBLookUp("SELECT SupplierName FROM tbl_000_Supplier WHERE " & _
                                                                             "SupplierID = '" & dgMaterial.Item("colSupplierID", e.RowIndex).Value & _
                                                                             "'", "SupplierName")
        End Select
    End Sub

    Private Sub dgMaterial_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgMaterial.RowsAdded
        lblMaterialCount.Text = dgMaterial.RowCount - 1
    End Sub

    Private Sub dgMaterial_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgMaterial.RowsRemoved
        lblMaterialCount.Text = dgMaterial.RowCount - 1
    End Sub

    Private Sub cboCustomer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedValueChanged
        If Not cboCustomer.SelectedValue Is Nothing Then
            txtCustomerName.Text = cboCustomer.SelectedItem.Col2
        Else
            txtCustomerName.Text = String.Empty
        End If
    End Sub

    Private Sub cboCustomer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.Validated
        If Not cboCustomer.SelectedValue Is Nothing Then
            txtCustomerName.Text = cboCustomer.SelectedItem.Col2
        Else
            txtCustomerName.Text = String.Empty
        End If
    End Sub

    Private Sub dgprocess_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        lblprocess.Text = CountGridRows(dgprocess)
    End Sub

    Private Sub dgprocess_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        lblprocess.Text = CountGridRows(dgprocess)
    End Sub

    Private Sub ComputeProcessAMT()
        Dim ProcessATM As Double = 0
        For Each row As DataGridViewRow In dgprocess.Rows
            If row.IsNewRow = False Then
                ProcessATM += row.Cells("colProcessAmount").Value
            End If
        Next
        txtprocessAMT.Text = ConvertToMoney(ProcessATM)
    End Sub

    Private Sub cboProcessDate_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProcessDate.SelectedValueChanged
        If Not frmload And Not islooping Then
            txtsellingamount.Text = 0
            txtSellingQTY.Text = 0
            txtprocessAMT.Text = 0
            clsProcess.FetchProcess(dgprocess, dgSellingDetails, txtProductCode.Text, cboProcessDate.Text)
            For i = 0 To dgSellingDetails.RowCount - 1
                Call ADDSellingFields(i)
            Next

            For i = 0 To dgprocess.RowCount - 1
                Call ADDProcessFields(i)
            Next

            Call computeAllSellingDetails()
            Call ComputeProcessAMT()
            Call GetGrandTotal()
        End If
    End Sub

    Private Sub dgSellingDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSellingDetails.CellValidated
        Call ADDSellingFields(e.RowIndex)
        Call computeAllSellingDetails()
        Call GetGrandTotal()
    End Sub

    Private Sub dgSellingDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgSellingDetails.RowsAdded
        lblcountrecord.Text = CountGridRows(dgSellingDetails)
    End Sub

    Private Sub dgSellingDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgSellingDetails.RowsRemoved
        lblcountrecord.Text = CountGridRows(dgSellingDetails)
    End Sub

    Private Sub dgprocess_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgprocess.CellValidated
        With dgprocess
            ADDProcessFields(e.RowIndex)

        End With
        Call ComputeProcessAMT()
        Call GetGrandTotal()
    End Sub

    Private Sub dgprocess_RowsAdded1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgprocess.RowsAdded
        lblprocess.Text = CountGridRows(dgprocess)
    End Sub

    Private Sub dgprocess_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgprocess.RowsRemoved
        lblprocess.Text = CountGridRows(dgprocess)
    End Sub

#End Region

    Private Sub Cs_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Cs.ItemClicked
        Select Case e.ClickedItem.Name
            Case "CS1"
                dec = 1
            Case "cs2"
                dec = 2
            Case "cs3"
                dec = 3
            Case "cs4"
                dec = 4
            Case "cs5"
                dec = 5
            Case "cs6"
                dec = 6
        End Select

        'dgPriceHistory.Item("coldec", dgPriceHistory.CurrentRow.Index).Value = dec
        dgPriceHistory.Item("colUnitPrice", dgPriceHistory.CurrentRow.Index).Value = FormatNumber(dgPriceHistory.Item("colUnitPrice", dgPriceHistory.CurrentRow.Index).Value, dec)

    End Sub


    Private Sub dgPriceHistory_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPriceHistory.CellValueChanged
        ValidatedPriceHistorey()
    End Sub

    Private Sub dgPriceHistory_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPriceHistory.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                With frm_000_EditUPrice
                    Dim priceid As String = dgPriceHistory.Item("colpriceID", dgPriceHistory.CurrentRow.Index).Value
                    If priceid <> String.Empty Then
                        ._productcode = txtProductCode.Text
                        ._Pricedid = priceid
                        .isload(0)
                        .ShowDialog()
                    End If

                End With
        End Select
    End Sub

    Private Sub dgPriceHistory_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPriceHistory.DataError
        On Error Resume Next
    End Sub


    Private Sub cboInternalSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInternalSupplier.SelectedIndexChanged
      FillSupplier()
    End Sub

    Private Sub cboInternalSupplier_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboInternalSupplier.Validated
        FillSupplier()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

   
End Class