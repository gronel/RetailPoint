Imports System.Data.SqlClient
Imports TOPCInventorySales.clsPublic
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frm_300_SalesReport
#Region "Varible"
    Implements IBPSCommand
    Dim ErrProvider As New ErrorProviderExtended
    Public trans As String
    Public strRpt As String
    Dim strcom As String

    Dim pointA As Point = New Point(105, 30)
    Dim pointB As Point = New Point(105, 57)
    Dim pointC As Point = New Point(105, 83)
    Dim pointD As Point = New Point(104, 111)
    Dim pointE As Point = New Point(104, 139)
    Dim pointF As Point = New Point(104, 167)

    Dim frmload As Boolean = False, islooping As Boolean = False

    Dim file_rptName As String
    Dim strSQL As String
#End Region

#Region "Procedure"

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

    End Sub

    Private Enum ControlCategory
        DaterangeCustomer = 0
        DaterangeCustomerCurrency = 1
        DatePreparedCustomer = 3
        Customer_ProductStatus = 4
        InternalSupplier_ProductStatus = 5
        DateRageCustomerInternalSupProduct = 6
        CustomerProductDaterangeCurrencytype = 7
    End Enum


    Private Sub ShowControl(ByVal what As ControlCategory)
        Call hidecontrols()
        Select Case what

            Case ControlCategory.CustomerProductDaterangeCurrencytype
                islooping = True
                lbl1.Show()
                lbl2.Show()
                lbl3.Show()
                lbl4.Show()
                lbl5.Show()
                cbo1.Show()
                mtg1.Show()
                dtp1.Show()
                dtp2.Show()
                cbo2.Show()

                lbl1.Text = "Customer:"
                lbl2.Text = "Product Code:"
                lbl3.Text = "From:"
                lbl4.Text = "TO:"
                lbl5.Text = "Currencty:"
                FillCustomer(cbo1)
                LoadMTGProductCode(mtg1)
                FillCurrencty(cbo2)

                cbo1.Location = pointA
                mtg1.Location = pointB
                dtp1.Location = pointC
                dtp2.Location = pointD
                cbo2.Location = pointE
                islooping = False
            Case ControlCategory.DateRageCustomerInternalSupProduct

                cbo1.Show()
                cbo2.Show()
                cbo3.Show()
                lbl1.Show()
                lbl2.Show()
                lbl3.Show()
                lbl4.Show()
                lbl5.Show()
                dtp1.Show()
                dtp2.Show()
                lbl1.Text = "Supplier:"
                lbl2.Text = "Customer:"
                lbl3.Text = "Product Type:"
                lbl4.Text = "From:"
                lbl5.Text = "To:"
                FillInternalSupplier(cbo1)
                FillCustomer(cbo2)
                FillProductType(cbo3)
                cbo1.Location = pointA
                cbo2.Location = pointB
                cbo3.Location = pointC
                dtp1.Location = pointD
                dtp2.Location = pointE

            Case ControlCategory.DaterangeCustomerCurrency

                lbl3.Show()
                lbl1.Show()
                lbl4.Show()
                dtp1.Show()
                dtp2.Show()
                lbl2.Show()
                cbo2.Show()
                lbl1.Text = "Customer:"
                lbl2.Text = "From:"
                lbl3.Text = "To;"
                lbl4.Text = "Currency Type:"
                cbo1.Show()
                FillCustomer(cbo1)
                FillCurrencyType(cbo2)
                cbo1.Location = pointA
                dtp1.Location = pointB
                dtp2.Location = pointC
                cbo2.Location = pointD

            Case ControlCategory.DaterangeCustomer

                lbl3.Show()
                lbl1.Show()
                dtp1.Show()
                dtp2.Show()
                lbl2.Show()
                lbl1.Text = "Customer:"
                lbl2.Text = "From:"
                lbl3.Text = "To;"
                cbo1.Show()
                FillCustomer(cbo1)
                cbo1.Location = pointA
                dtp1.Location = pointB
                dtp2.Location = pointC

            Case ControlCategory.DatePreparedCustomer

                lbl1.Show()
                lbl2.Show()
                cbo2.Show()
                dtp1.Show()
                lbl1.Text = "Prepared Date:"
                lbl2.Text = "Cutomer:"
                FillCustomer(cbo2)
                cbo1.Location = pointA

            Case ControlCategory.Customer_ProductStatus

                lbl1.Show()
                lbl2.Show()
                cbo1.Show()
                cbo2.Show()
                lbl1.Text = "Customer:"
                lbl2.Text = "Product Status:"
                FillCustomer(cbo1)
                FillProductStatus(cbo2)
                cbo1.Location = pointA
                cbo2.Location = pointB

            Case ControlCategory.InternalSupplier_ProductStatus

                lbl1.Show()
                lbl2.Show()
                cbo1.Show()
                cbo2.Show()
                lbl1.Text = "Supplier:"
                lbl2.Text = "Product Status:"
                FillInternalSupplier(cbo1)
                FillProductStatus(cbo2)
                cbo1.Location = pointA
                cbo2.Location = pointB

        End Select
    End Sub


    Private Sub clearCbo()
        cbo1.SelectedIndex = -1
        cbo2.SelectedIndex = -1
        cbo3.SelectedIndex = -1
        cbo4.SelectedIndex = -1
    End Sub

    Private Sub clear()
        lbl1.Text = ""
        lbl2.Text = ""
        lbl3.Text = ""
        lbl4.Text = ""
        lbl5.Text = ""
        lbl6.Text = ""

        cbo1.SelectedIndex = -1
        cbo2.SelectedIndex = -1
        cbo3.SelectedIndex = -1
        cbo4.SelectedIndex = -1



        txt1.Clear()
        txt2.Clear()
        txt3.Clear()
        txt4.Clear()

        mtg1.Text = ""
        mtg2.Text = ""
        mtg3.Text = ""
        mtg4.Text = ""
        mtg5.Text = ""

        mtg1.Items.Clear()
        mtg2.Items.Clear()
        mtg3.Items.Clear()
        mtg4.Items.Clear()
        mtg5.Items.Clear()
        mtg6.Items.clear()

    End Sub

    Private Sub hidecontrols()
        lbl1.Hide()
        lbl2.Hide()
        lbl3.Hide()
        lbl4.Hide()
        lbl5.Hide()
        lbl6.Hide()
        cbo1.Hide()
        cbo2.Hide()
        cbo3.Hide()
        cbo4.Hide()
        dtp1.Hide()
        dtp2.Hide()
        txt1.Hide()
        txt2.Hide()
        txt3.Hide()
        txt4.Hide()
        mtg1.Hide()
        mtg2.Hide()
        mtg3.Hide()
        mtg4.Hide()
        mtg5.Hide()
        mtg6.Hide()
        Call clear()
    End Sub


    Private Sub FillCurrencty(ByVal cbo As ComboBox)
        Try
            SQL = "SELECT Currency FROM tbl_000_Currency"
            FillCombobox(cbo, SQL, "tbl_000_Customer", "Currency", "Currency")
            cbo.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("ERROR:FillCurrencty -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub


    Private Sub LoadMTGProductCode(ByVal cboMultiCombo As MTGCComboBox)
        Try
            SQL = "SELECT     ProductCode, ProductName FROM tbl_000_Product " & _
"WHERE     (CustomerCode LIKE '%' + '" & cbo1.SelectedValue & "' + '%')"
            Dim sqlConn As New SqlConnection(cnString)
            Dim sqlReader As SqlDataReader
            Dim sqlCommand As New SqlCommand(SQL, sqlConn)
            Dim dtLoading As New DataTable(SQL)

            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With cboMultiCombo
                .ColumnNum = 2
                .ColumnWidth = "100;150"
                .GridLineHorizontal = True
                .GridLineVertical = True
                ''.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(1) {"ProductCode", "ProductName"}
                .SourceDataTable = dtLoading
            End With
        Catch ex As Exception
            MsgBox("ERROR:LoadMTGProductCode -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    Private Sub LoadCategory(ByVal mtg As MTGCComboBox)
        Try

            Dim sqlConn As New SqlConnection(cnString)
            Dim sqlReader As SqlDataReader
            Dim sqlCommand As New SqlCommand("SELECT     CustomerCode, CustomerName " & _
                                             "FROM tbl_000_Customer WHERE     (Status = 1)", sqlConn)
            Dim dtLoading As New DataTable("tbl_000_Customer")

            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With mtg
                .ColumnNum = 2
                .ColumnWidth = "100;250"
                .GridLineHorizontal = True
                .GridLineVertical = True
                '.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(1) {"CustomerCode", "CustomerName"}
                .SourceDataTable = dtLoading
            End With
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    Private Sub FillCustomer(ByVal cbo As ComboBox)
        Try
            SQL = "SELECT     CustomerCode, CustomerName " & _
                                             "FROM tbl_000_Customer WHERE     (Status = 1)"
            FillCombobox(cbo, SQL, "tbl_000_Customer", "CustomerName", "CustomerCode")
            cbo.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("ERROR: FillCustomer -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub


    Private Sub FillProductType(ByVal cbo As ComboBox)
        Try
            FillCombobox(cbo, "SELECT ProductType FROM tbl_000_Product GROUP BY ProductType " & _
                         " ORDER BY ProductType", "tbl_000_Product", "ProductType", "ProductType")
            cbo.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("ERROR: FillProductType -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    Private Sub FillInternalSupplier(ByVal cbo As ComboBox)
        Try
            SQL = "SELECT     inSupplierCode, inSupplierName " & _
                        "FROM         tbl_000_InternalSupplier"
            FillCombobox(cbo, SQL, "tbl_000_InternalSupplier", "inSupplierName", "inSupplierCode")
            cbo.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("ERROR:FillInternalSupplier -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    Private Sub FillProductStatus(ByVal cbo As ComboBox)
        Try

            If cbo.Items.Count > 0 Then
                cbo.Items.Clear()
            End If

            cbo.Items.Add("ACTIVE")
            cbo.Items.Add("INACTIVE")

        Catch ex As Exception
            MsgBox("ERROR: FillProductStatus -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    Private Sub FillCurrencyType(ByVal cbo As ComboBox)
        Try
            SQL = "Select Currency from tbl_000_Currency"
            FillCombobox(cbo, SQL, "tbl_000_Currency", "Currency", "Currency")
            cbo.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("ERROR:FillCurrencyType -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    Private Sub control()
        Try
            islooping = True
            Call hidecontrols()
            Select Case strRpt

                Case "Sales Outstanding Balances"
                    Select Case listreport.Text
                        Case "TOPC Sales Delivery Schedule(s) ", "TOPC Sales Outstanding Balance", "TOPC Sales Outstanding Balance by Order", "TOPC Sales Outstanding Balance by Product"
                            grp1.Text = listreport.Text
                            ShowControl(ControlCategory.DatePreparedCustomer)
                    End Select


                Case "Sales Inventory"

                    Select Case listreport.Text

                        Case "Monthly Inventory Checking"
                            grp1.Text = listreport.Text
                            ShowControl(ControlCategory.DaterangeCustomer)
                        Case "Monthly Inventory Reference"
                            grp1.Text = listreport.Text
                            ShowControl(ControlCategory.DateRageCustomerInternalSupProduct)
                        Case "Product Order History"
                            grp1.Text = listreport.Text
                            ShowControl(ControlCategory.CustomerProductDaterangeCurrencytype)

                    End Select

                Case "TOPC Sales Report"
                    Select Case listreport.Text

                        Case "TOPC Sales by Product", "TOPC Sales by Order", "TOPC Sales by DR/Invoice", "Invoice Report Summary"
                            grp1.Text = listreport.Text
                            ShowControl(ControlCategory.DaterangeCustomerCurrency)
                        Case "TOPC Daily Sales", "TOPC Daily Sales Summary"
                            grp1.Text = listreport.Text
                            ShowControl(ControlCategory.DaterangeCustomer)
                     
                    End Select

                Case "Master File Report"
                    Select Case listreport.Text

                        Case "Product List by Customer"
                            grp1.Text = listreport.Text
                            ShowControl(ControlCategory.Customer_ProductStatus)

                        Case "Product List by Internal Supplier"
                            grp1.Text = listreport.Text
                            ShowControl(ControlCategory.InternalSupplier_ProductStatus)
                    End Select

            End Select
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try

    End Sub



    Private Sub AddListItem()

        With listreport.Items
            Select Case strRpt

                Case "Sales Outstanding Balances"

                    .Add("TOPC Sales Delivery Schedule(s) ")
                    .Add("TOPC Sales Outstanding Balance")
                    .Add("TOPC Sales Outstanding Balance by Order")
                    .Add("TOPC Sales Outstanding Balance by Product")

                Case "Sales Inventory"

                    .Add("Monthly Inventory Checking")
                    .Add("Monthly Inventory Reference")
                    .Add("Product Order History")

                Case "TOPC Sales Report"

                    .Add("TOPC Sales by Product")
                    .Add("TOPC Sales by Order")
                    .Add("TOPC Sales by DR/Invoice")
                    .Add("TOPC Daily Sales")
                    .Add("TOPC Daily Sales Summary")
                    .Add("Invoice Report Summary")

                Case "Master File Report"

                    .Add("Product List by Customer")
                    .Add("Product List by Internal Supplier")


            End Select
        End With
        islooping = False
    End Sub

    
    ''Enumerations
    Public Enum ReportMode
        rptWindowMode = 0
        rptPrintMode = 1
    End Enum

    ''' <summary>
    ''' View Report
    ''' </summary>
    ''' <param name="rptMode">rptWindowMode / rptPrintMode</param>
    ''' <remarks></remarks>
    Private Sub ViewReport(ByVal rptMode As ReportMode)
        Dim frmReport As New frm_200_ReportV
        Dim mycmd As New SqlCommand
        Dim mycon As SqlConnection
        Try

        

            '--> Report Type
            Select Case strRpt

                Case "Sales Inventory", "Sales Outstanding Balances"

                    '--> Listbox value
                    Select Case listreport.Text


                        Case "TOPC Sales Outstanding Balance by Product"
                            ''1. set report file name
                            file_rptName = "rpt_Product_OutstandingBalancebyProduct.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_outstandingBalancebyProduct '" & cbo2.SelectedValue & "', '" & dtp1.Text & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .Refresh()
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                      

                        Case "TOPC Sales Delivery Schedule(s) "
                            ''1. set report file name
                            file_rptName = "rpt_Product_Delivery_Sched.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_Product_Delivery_Sched '" & dtp1.Text & "', '" & cbo2.SelectedValue & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case "TOPC Sales Outstanding Balance"
                            ''1. set report file name
                            file_rptName = "rpt_Product_OutstandingBalance.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_Product_Outstanding_Bal '" & dtp1.Text & "', '" & cbo2.SelectedValue & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case "TOPC Sales Outstanding Balance by Order"
                            ''1. set report file name
                            file_rptName = "rpt_Product_OutstandingBalancebyOrder.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_Product_Outstanding_Bal '" & dtp1.Text & "', '" & cbo2.SelectedValue & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case "Monthly Inventory Checking"

                            ''1. set report file name
                            file_rptName = "rpt_Sales_MIC.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_sales_MIC '" & dtp1.Text & "','" & dtp2.Text & "','" & cbo1.SelectedValue & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case "Monthly Inventory Reference"

                            ''1. set report file name
                            file_rptName = "rpt_Sales_MIR.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_sales_MIR '" & dtp1.Text & "','" & dtp2.Text & "','" & cbo2.SelectedValue & "','" & cbo1.SelectedValue & "','" & cbo3.Text & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case "Product Order History"

                            ''1. set report file name
                            file_rptName = "rpt_Product_OrderHistory.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_productorder_history '" & cbo1.SelectedValue & "','" & mtg1.SelectedText & "','" & dtp1.Text & "','" & dtp2.Text & "','" & cbo2.SelectedValue & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With


                    End Select

                Case "TOPC Sales Report"
                    '--> Listbox value
                    Select Case listreport.Text

                        Case "Invoice Report Summary"
                            ''1. set report file name
                            file_rptName = "rpt_TOPC_Invoice_Summary.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_Invoice '" & cbo1.SelectedValue & "', '" & dtp1.Text & "','" & dtp2.Text & "','" & cbo2.Text & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case "TOPC Sales by Product"

                            ''1. set report file name
                            file_rptName = "rpt_Sales_TOPC_product.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_sales_TOPC_Product '" & dtp1.Text & "','" & dtp2.Text & "','" & cbo1.SelectedValue & "','" & cbo2.SelectedValue & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case "TOPC Sales by Order"

                            ''1. set report file name
                            file_rptName = "rpt_Sales_TOPC_order.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_sales_TOPC_Order '" & dtp1.Text & "','" & dtp2.Text & "','" & cbo1.SelectedValue & "','" & cbo2.SelectedValue & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case "TOPC Sales by DR/Invoice"

                            ''1. set report file name
                            file_rptName = "rpt_Sales_TOPC_DR_Invoice.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_sales_TOPC_DR_INVOICE '" & dtp1.Text & "','" & dtp2.Text & "','" & cbo1.SelectedValue & "','" & cbo2.SelectedValue & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With
                        Case "TOPC Daily Sales"

                            ''1. set report file name
                            file_rptName = "rpt_Sales_TOPC_DAILY_SALES.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_Sales_Daily_Sales '" & dtp1.Text & "','" & dtp2.Text & "','" & cbo1.SelectedValue & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case "TOPC Daily Sales Summary"

                            ''1. set report file name
                            file_rptName = "rpt_Sales_TOPC_DAILY_SALES_Summary.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_Sales_Daily_Sales '" & dtp1.Text & "','" & dtp2.Text & "','" & cbo1.SelectedValue & "'"

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                    End Select

                Case "Master File Report"

                    Select Case listreport.Text

                        Case "Product List by Customer"

                            ''1. set report file name
                            file_rptName = "rpt_Sales_Customer_Product.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_Sales_Customer_Product '" & cbo1.SelectedValue & "','" & cbo2.Text & "'," & 1

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case "Product List by Internal Supplier"

                            ''1. set report file name
                            file_rptName = "rpt_Sales_Internal_Product.rpt"

                            ''2. set sql query or storedprocedure
                            strSQL = "sp_rpt_Sales_Customer_Product '" & cbo1.SelectedValue & "','" & cbo2.Text & "'," & 2

                            ''3. set 1 and 2 in designation report file
                            With cryRpt
                                .Load(Application.StartupPath & "\Reports\" & file_rptName)
                                .SetDataSource(FillReportForm(strSQL, "tbl_000_Product"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With
                    End Select








            End Select



            ''=========================================
            ''Open Viewer and show the selected report
            ''=========================================
            If listreport.Text = "" Then
                MsgBox("Select Report first", MsgBoxStyle.Exclamation, "Prompt")
                Exit Sub
            End If

            If isRecordExist(strSQL) = False Then
                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                Exit Sub
            End If


            With frmReport

                .rpt_viewer.ReportSource = cryRpt
                If rptMode = ReportMode.rptWindowMode Then
                    .Text = listreport.Text
                    HideTheTabControl(.rpt_viewer)
                    .Show()
                ElseIf rptMode = ReportMode.rptPrintMode Then
                    .rpt_viewer.PrintReport()
                End If
            End With
        Catch ex As Exception
            MsgBox("Error:ViewReport -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

 

#End Region


#Region "GUI"

    Private Sub lst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listreport.SelectedIndexChanged
        Call control()
    End Sub

    Private Sub frmSummary_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MainForm.closeme()
    End Sub

    Private Sub frmSummary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub frmSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmload = True
        CenterForm(Me)
        Me.Text = isReport
        strRpt = isReport
        Call AddListItem()
        frmload = False
        listreport.SelectedIndex = 0
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call ViewReport(ReportMode.rptWindowMode)
    End Sub

   

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call ViewReport(ReportMode.rptPrintMode)
    End Sub

    Private Sub cbo1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo1.SelectedValueChanged
        If Not islooping And Not frmload Then
            LoadMTGProductCode(mtg1)
        End If

    End Sub

#End Region
End Class
