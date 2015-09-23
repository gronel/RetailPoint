Imports System.Data.SqlClient
Imports Retails.clsPublic
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSummary
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
    Dim frmload As Boolean = False, islooping As Boolean = False
#End Region

#Region "Procedure"

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

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

    Private Sub LoadCategory(ByVal mtg As MTGCComboBox)
        Try

            Dim sqlConn As New SqlConnection(cnString)
            Dim sqlReader As SqlDataReader
            Dim sqlCommand As New SqlCommand("SELECT CategoryCode, CategoryName FROM tbl_000_Category", sqlConn)
            Dim dtLoading As New DataTable("tbl_000_Category")

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
                .SourceDataString = New String(1) {"CategoryCode", "CategoryName"}
                .SourceDataTable = dtLoading
            End With
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub



    Private Sub control()
        Try
            islooping = True
            Call hidecontrols()
            Select Case strRpt


                Case "Payable Payment Schedule"

                    Select Case listreport.SelectedIndex

                        Case 0, 1, 2
                            grp1.Text = listreport.Text
                            lbl1.Show()
                            dtp1.Show()
                            dtp2.Show()
                            lbl2.Show()
                            lbl1.Text = "From:"
                            lbl2.Text = "To:"
                    End Select

                Case "Cash Advance Report"
                    If listreport.SelectedIndex = 0 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl1.Text = "Select Preview or Print to show the report"
                    ElseIf listreport.SelectedIndex = 1 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl2.Show()
                        dtp1.Show()
                        dtp2.Show()
                        lbl1.Text = "From"
                        lbl2.Text = "To"
                    End If


                Case "Receiving Report"
                    If listreport.SelectedIndex = 0 Then
                        grp1.Text = listreport.Text
                        lbl1.Show()
                        lbl2.Show()
                        lbl3.Show()
                        dtp1.Show()
                        dtp2.Show()
                        mtg5.Show()
                        mtg5.Location = pointC
                        lbl1.Text = "From:"
                        lbl2.Text = "To:"
                        lbl3.Text = "Supplier Code:"
                        LoadSupplierToMultiCombo(mtg5)
                    ElseIf listreport.SelectedIndex = 1 Then
                        grp1.Text = listreport.Text
                        lbl1.Show()
                        lbl2.Show()
                        lbl3.Show()
                        dtp1.Show()
                        dtp2.Show()
                        mtg4.Show()
                        lbl1.Text = "From:"
                        lbl2.Text = "To:"
                        lbl3.Text = "Specific Code:"
                        LoadSpecificCode(mtg4)
                        mtg4.Location = pointC
                    ElseIf listreport.SelectedIndex = 2 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl2.Show()
                        mtg1.Show()
                        lbl1.Text = "Select Supplier "
                        LoadSupplier(mtg1)
                    ElseIf listreport.SelectedIndex = 3 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        mtg1.Show()
                        lbl2.Show()
                        txt2.Show()
                        lbl1.Text = "Select Item No"
                        lbl2.Text = "Item Name"
                        LoadSpecificCode(mtg1)
                    ElseIf listreport.SelectedIndex = 4 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl2.Show()
                        dtp1.Show()
                        dtp2.Show()
                        lbl1.Text = "From"
                        lbl2.Text = "To"
                    ElseIf listreport.SelectedIndex = 5 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl2.Show()
                        dtp1.Show()
                        dtp2.Show()
                        lbl1.Text = "From"
                        lbl2.Text = "To"
                    ElseIf listreport.SelectedIndex = 6 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        cbo1.Show()
                        lbl1.Text = "Select RR Type:"
                        cbo1.Items.Clear()
                        cbo1.Items.AddRange(New Object() {"PO", "JO"})
                    ElseIf listreport.SelectedIndex = 7 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl1.Text = "Select Preview or Print to show the report"
                    End If
                    ''===========================
                    ''For WITHDRAWAL Report
                    ''===========================

                Case "Withdrawal Report"
                    Select Case listreport.SelectedIndex

                        Case 0, 2
                            grp1.Text = listreport.Text
                            lbl1.Show()
                            lbl2.Show()
                            lbl3.Show()
                            lbl4.Show()
                            lbl5.Show()
                            dtp1.Show()
                            dtp2.Show()
                            mtg3.Show()
                            mtg4.Show()
                            mtg5.Show()
                            lbl1.Text = "From:"
                            lbl2.Text = "To:"
                            lbl3.Text = "Department:"
                            lbl4.Text = "Section:"
                            lbl5.Text = "Line:"
                            LoadDepartmentToMultiCombo(mtg3)
                            mtg3.Location = pointC

                        Case 1
                            grp1.Text = listreport.Text
                            lbl1.Show()
                            lbl2.Show()
                            lbl3.Show()
                            dtp1.Show()
                            dtp2.Show()
                            mtg6.Show()
                            lbl1.Text = "From:"
                            lbl2.Text = "To:"
                            lbl3.Text = "Specific Code:"
                            LoadSpecificCode(mtg6)
                            mtg6.Location = pointC
                            'Case 2
                            '    grp1.Text = listreport.Text
                            '    lbl1.Show()
                            '    lbl2.Show()
                            '    lbl3.Show()
                            '    dtp1.Show()
                            '    dtp2.Show()
                            '    mtg4.Show()
                            '    lbl1.Text = "From:"
                            '    lbl2.Text = "To:"
                            '    lbl3.Text = "Department:"
                            '    LoadDepartmentToMultiCombo(mtg4)
                            '    mtg4.Location = pointC
                    End Select
                    mtg3.SelectedIndex = -1
                    ''===========================
                    ''For Accountability Report
                    ''===========================
                Case "Accountability Report"
                    Select Case listreport.SelectedIndex
                        Case 0
                            grp1.Text = listreport.Text
                            lbl1.Show()
                            dtp1.Show()
                            dtp2.Show()
                            lbl2.Show()
                            cbo3.Show()
                            lbl3.Show()
                            lbl1.Text = "From:"
                            lbl2.Text = "To:"
                            lbl3.Text = "Employee:"
                            LoadEmployee(cbo3)
                        Case 1

                    End Select

                    ''==================================Supplier=====================
                Case "Supplier MasterFile Report"

                    Select Case listreport.SelectedIndex
                        Case 0
                            grp1.Text = listreport.Text
                            hidecontrols()
                            lbl1.Show()
                            lbl2.Show()
                            cbo1.Show()
                            cbo1.Location = pointA
                            lbl1.Text = "Supplier Type:"
                            FillCombobox(cbo1, "SELECT     SupTypeID, SupTypeName " & _
                                              "FROM         tbl_000_Supplier_Type", "tbl_000_Supplier_Type", "SupTypeName", "SupTypeID")

                        Case 1
                            grp1.Text = listreport.Text
                            hidecontrols()
                            lbl1.Show()
                            lbl2.Show()
                            mtg1.Show()
                            lbl1.Text = "Select Supplier "
                            LoadSupplier(mtg1)

                    End Select

                    ''==================================Item=====================
                Case "Item MasterFile Report"
                    If listreport.SelectedIndex = 0 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl1.Text = "Category:"
                        mtg1.Show()
                        mtg1.Location = pointA
                        LoadCategory(mtg1)
                    ElseIf listreport.SelectedIndex = 1 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl1.Text = "Rack:"
                        cbo1.Show()
                        cbo1.Location = pointA
                        FillCombobox(cbo1, "SELECt RackNo FROM  tbl_000_Rack ORDER BY dbo.AlphaNum(rackno)", "tbl_000_rack", "RackNo", "RackNo")
                    ElseIf listreport.SelectedIndex = 2 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl1.Text = "Select Preview or Print to show the report"
                    ElseIf listreport.SelectedIndex = 3 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl1.Text = "Select Preview or Print to show the report"
                    End If
                Case "Inventory Report"
                    Select Case listreport.SelectedIndex
                        Case 0, 1, 2
                            grp1.Text = listreport.Text
                            lbl2.Show()
                            lbl1.Show()
                            lbl3.Show()
                            mtg3.Show()
                            cbo2.Show()
                            cbo1.Location = pointB
                            mtg3.Location = pointC
                            dtp1.Show()
                            lbl1.Text = "Prepared Date:"
                            lbl2.Text = "Category Code:"
                            lbl3.Text = "Specific Code:"
                            FillCombobox(cbo2, "Select * from tbl_000_Category ", "tbl_000_category", "CategoryName", "CategoryCode")
                            cbo2.SelectedIndex = -1

                    End Select
            End Select
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try

    End Sub

    ''' <summary>
    ''' Load Employee in report
    ''' </summary>
    ''' <param name="cbo">combobox</param>
    ''' <remarks></remarks>
    Private Sub LoadEmployee(ByVal cbo As ComboBox)
        SQL = "SELECT   EmpID,  dbo.F_Get_EmployeeName(EmpID) AS EmpName " & _
              "FROM tbl_000_Employee " & _
              "WHERE     (IsActive = 1)AND (EmpID <> N'00001') ORDER BY EmpName "
        FillCombobox(cbo, SQL, "tbl_000_Employee", "EmpName", "EmpID")
    End Sub

    Private Sub LoadSupplier(ByVal cboMultiCombo As MTGCComboBox)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim sqlCommand As New SqlCommand("GetSupplierForCombo", sqlConn)
        Dim dtLoading As New DataTable("tbl_000_Supplier")

        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With cboMultiCombo
            .ColumnNum = 2
            .ColumnWidth = "100;200"
            .GridLineHorizontal = True
            .GridLineVertical = True
            ''.SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(1) {"SupplierID", "SupplierName"}
            .SourceDataTable = dtLoading
        End With

    End Sub

    Private Sub AddListItem()

        With listreport.Items
            Select Case strRpt

                Case "Payable Payment Schedule"

                    .Add("Projected Payable PO and JO")
                    .Add("Actual Payable (RR)")

                Case "Receiving Report"
                    .Add("RR by Supplier")
                    .Add("RR by Item Specific Code")

                Case "Withdrawal Report"
                    .Add("Withdrawal by Department")
                    .Add("Withdrawal by Item Specific")
                    .Add("Annual Inventory/Withdrawal Reference")
                Case "Accountability Report"
                    .Add("Accountability Report by ID No.")

                Case "Inventory Report"
                    .Add("Inventory - Pre-checking")
                    .Add("Annual Pre-checking")
                    .Add("Inventory - Final") '--->Old {"Annual Countsheet Summary", "Monthly Outstanding Balance", "Monthly Inventory (Outstanding Balance)", "Annual Inventory Counsheet", "Inventory-Monthly-Final"})
                Case "Item MasterFile Report"
                    .Add("Item Master List by Category")
                    .Add("Item Master List by Rack")
                    .Add("TOC Code List")
                    .Add("Category Setup Report")   'Old List--->, "Summary of Item Name per Item Category and Item Sub-category", "Item Masterfile Details"

                Case "Cash Advance Report"
                    .Add("Summary/List of CA No. Used")
                    .Add("Summary of Cash Advance per Date")

                Case "Supplier MasterFile Report"
                    .Add("Supplier Master List")
                    .Add("List of Item per Supplier") 'Old List--->"Supplier Master List", "List of Item per Supplier", "Supplier Details"

            End Select
        End With
        islooping = False
    End Sub

    Private Sub mtg1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtg1.SelectedIndexChanged
        If strRpt = "Item MasterFile Report" And listreport.SelectedIndex = 2 Then
            LoadSubCatigoryComboBox(mtg2)
        Else
            If Not mtg1.SelectedValue Is Nothing Then
                txt2.Text = mtg1.SelectedItem.Col2
                FillSection()
            Else
                txt2.Text = String.Empty

            End If
        End If
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
        Try

            Select Case strRpt
                Case "Receiving Report"
                    Select Case listreport.SelectedIndex
                        Case 0
                        
                            If isRecordExist("sp_rpt_RR_By_Supplier '" & dtp1.Text & "','" & dtp2.Text & "','" & mtg5.Text & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_RR(by Supplier).rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_RR_By_Supplier '" & dtp1.Text & "','" & dtp2.Text & "','" & mtg5.Text & "'", "tbl_100_RR"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case 1
                            If isRecordExist("sp_rpt_RR_by_Item '" & dtp1.Text & "','" & dtp2.Text & "','" & mtg4.Text & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_RR(by Specific Code).rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_RR_by_Item '" & dtp1.Text & "','" & dtp2.Text & "','" & mtg4.Text & "'", "tbl_100_RR"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                    End Select
                    ''--->Payable Payment Schedule Report
                Case "Payable Payment Schedule"
                    Select Case listreport.SelectedIndex

                        Case 0 ''--> po payable report

                            If isRecordExist("sp_rpt_PO_Payble'" & dtp1.Text & "','" & dtp2.Text & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_PO_JO_Payable.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_PO_Payble'" & dtp1.Text & "','" & dtp2.Text & "'", "tbl_100_PO"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case 1 ''--> RR Actual payable
                            If isRecordExist("sp_rpt_RR_Payable '" & dtp1.Text & "','" & dtp2.Text & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If

                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_RR_Payable.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_RR_Payable '" & dtp1.Text & "','" & dtp2.Text & "'", "tbl_100_RR"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With
                    End Select

                    '--->Item master file
                Case "Item MasterFile Report"
                    Select Case listreport.SelectedIndex
                        Case 0
                            If isRecordExist("sp_rpt_Item_List '" & mtg1.Text & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If

                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_ItemMasterfile(Category).rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_Item_List '" & mtg1.Text & "'", "tbl_000_item"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case 1
                            If isRecordExist("sp_rpt_Item_Rack '" & cbo1.Text & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If

                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_ItemMasterfile(Rack).rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_Item_Rack '" & cbo1.Text & "'", "tbl_000_item"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With
                        Case 2

                            If isRecordExist("sp_rpt_TOCList") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If


                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_TOC_List.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_TOCList", "tbl_000_item"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With
                        Case 3

                            If isRecordExist("sp_rpt_Category_report") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If

                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_Category_Report.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_Category_report", "tbl_000_Category"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With
                    End Select


                Case "Cash Advance Report"
                    Select Case listreport.SelectedIndex

                        Case 0
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_CANo.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_CA_SelectAll'" & "all" & "','" & "" & "','" & "" & "'", ""))
                                .SetParameterValue("title", "List of CA No. Used")
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                                .SetParameterValue("to", "")
                            End With
                        Case 1
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_CANo.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_CA_SelectAll'" & "perdate" & "','" & dtp1.Text & "','" & dtp2.Text & "'", ""))
                                .SetParameterValue("title", "Summary of Cash Advance per Date")
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                                .SetParameterValue("to", dtp1.Text + " to " + dtp2.Text)
                            End With

                    End Select

                Case "Withdrawal Report"
                    Select Case listreport.SelectedIndex
                        Case 0 ''--> withdrawal report by  department
                            If mtg3.Text = String.Empty Then
                                ErrorP.SetError(mtg3, "Select Department!")
                                Exit Sub
                            Else
                                ErrorP.SetError(mtg3, "")
                            End If
                            If isRecordExist("sp_rpt_WithdrawalReportbyDep'" & dtp1.Text & "','" & dtp2.Text & "','" & mtg3.Text & "','" & mtg4.Text & "','" & mtg5.Text & "'") = False Then
                                MsgBox("NO DATA!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_WR(by Department) .rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_WithdrawalReportbyDep'" & dtp1.Text & "','" & dtp2.Text & "','" & mtg3.Text & "','" & mtg4.Text & "','" & mtg5.Text & "'", "tbl_100_WR"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case 1 ''--> withdrawal report by item
                            If mtg6.Text = String.Empty Then
                                ErrorP.SetError(mtg6, "Select Specific Code!")
                                Exit Sub
                            Else
                                ErrorP.SetError(mtg6, "")
                            End If
                            If isRecordExist("sp_rpt_WithdrawalReportbySpecific '" & dtp1.Text & "','" & dtp2.Text & "','" & mtg6.Text & "'") = False Then
                                MsgBox("NO DATA!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_WR(by Specific Code).rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_WithdrawalReportbySpecific '" & dtp1.Text & "','" & dtp2.Text & "','" & mtg6.Text & "'", "tbl_100_WR"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case 2 ''--> annual inventory by department
                            If mtg3.Text = String.Empty Then
                                ErrorP.SetError(mtg3, "Select Department!")
                                Exit Sub
                            Else
                                ErrorP.SetError(mtg3, "")
                            End If
                            If isRecordExist("sp_rpt_Annual_Inventory_Reference'" & dtp1.Text & "','" & dtp2.Text & "','" & mtg3.Text & "','" & mtg4.Text & "','" & mtg5.Text & "'") = False Then
                                MsgBox("NO DATA!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_WR(Annual_Inventory_Reference).rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_Annual_Inventory_Reference'" & dtp1.Text & "','" & dtp2.Text & "','" & mtg3.Text & "','" & mtg4.Text & "','" & mtg5.Text & "'", "tbl_100_WR"))
                                .SetParameterValue("d1", dtp1.Text)
                                .SetParameterValue("d2", dtp2.Text)
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                    End Select

                Case "Accountability Report"
                    Select Case listreport.SelectedIndex
                        Case 0
                            If cbo3.Text = String.Empty Then
                                ErrorP.SetError(cbo3, "Select Specific Code!")
                                Exit Sub
                            Else
                                ErrorP.SetError(cbo3, "")
                            End If
                            If isRecordExist("sp_rpt_Accountability_Report '" & dtp1.Text & "','" & dtp2.Text & "','" & cbo3.SelectedValue & "'") = False Then
                                MsgBox("NO DATA!", MsgBoxStyle.Exclamation, "Prompt")
                                Exit Sub
                            End If
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_AR_Report.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_Accountability_Report '" & dtp1.Text & "','" & dtp2.Text & "','" & cbo3.SelectedValue & "'", "tbl_100_AR"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With
                    End Select



                Case "Inventory Report"
                    Select Case listreport.SelectedIndex
                        Case 0 ''--> inventory precheking
                            If isRecordExist("sp_rpt_inventory_PreChecking '" & cbo2.SelectedValue & "','" & mtg3.Text & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Exclamation, "Prompt")
                                Exit Sub
                            End If

                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_Inventory-Prechecking.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_inventory_PreChecking '" & cbo2.SelectedValue & "','" & mtg3.Text & "'", "tbl_000_Item_Sub"))
                                .SetParameterValue("Company", CompanyName)
                                .SetParameterValue("CompanyAdd", CompanyAddress)
                                .SetParameterValue("Date", FormatDateTime(CDate(dtp1.Text), DateFormat.GeneralDate))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case 1 ''--> inventory annual pre checking
                            If isRecordExist("sp_rpt_inventory_PreChecking '" & cbo2.SelectedValue & "','" & mtg3.Text & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Exclamation, "Prompt")
                                Exit Sub
                            End If

                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_Inventory-Annual.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_inventory_PreChecking '" & cbo2.SelectedValue & "','" & mtg3.Text & "'", "tbl_000_Item_Sub"))
                                .SetParameterValue("Company", CompanyName)
                                .SetParameterValue("CompanyAdd", CompanyAddress)
                                .SetParameterValue("Date", FormatDateTime(CDate(dtp1.Text), DateFormat.GeneralDate))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With
                        Case 2 '--> inventory final


                            If isRecordExist("sp_rpt_InventoryFinal '" & cbo2.SelectedValue & "','" & mtg3.Text & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Exclamation, "Prompt")
                                Exit Sub
                            End If

                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_Inventory-Final.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_InventoryFinal '" & cbo2.SelectedValue & "','" & mtg3.Text & "'", "tbl_000_Item_Sub"))
                                .SetParameterValue("Company", CompanyName)
                                .SetParameterValue("CompanyAdd", CompanyAddress)
                                .SetParameterValue("Date", dtp1.Text)
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With
                    End Select


                    ''============================
                    ''Supplier MasterFile Report"
                    ''============================
                Case "Supplier MasterFile Report"

                    Select Case listreport.SelectedIndex
                        Case 0 ''--> supplier master list report
                            If isRecordExist("sp_rpt_SupplierMasterList '" & cbo1.SelectedValue & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If

                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_Supplier_MasterList.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_SupplierMasterList '" & cbo1.SelectedValue & "'", "tbl_000_Supplier"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case 1 ''--> supplier report by item
                            If isRecordExist("sp_rpt_SupplierMaster_ListofItem'" & mtg1.Text & "'") = False Then
                                MsgBox("NO DATA!!", MsgBoxStyle.Information, "Prompt")
                                Exit Sub
                            End If

                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_Supplier_Item.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_SupplierMaster_ListofItem'" & mtg1.Text & "'", "tbl_000_Supplier"))
                                .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                            End With

                        Case 2 ''--> supplier Details report
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_Supplier_Details.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sp_rpt_SupplierMaster'" & "Details" & "','" & "" & "'", "tbl_000_Supplier"))
                                .SetParameterValue("title", "Supplier Details")
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
            With frmReport
                .rpt_viewer.ReportSource = cryRpt
                If rptMode = ReportMode.rptWindowMode Then
                    .Text = listreport.Text
                    .Show()
                ElseIf rptMode = ReportMode.rptPrintMode Then
                    .rpt_viewer.PrintReport()
                End If
            End With
        Catch ex As Exception
            MsgBox("Error:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    Private Sub LoadSpecificCode(ByVal cboMultiCombo As MTGCComboBox)
        Try
            SQL = "SELECT     SpecificCode, SpecificDescription , BrandType " & _
                  "FROM tbl_000_Item_Sub " & _
                  "WHERE(isActive <> 0)"
            Dim sqlConn As New SqlConnection(cnString)
            Dim sqlReader As SqlDataReader
            Dim sqlCommand As New SqlCommand(SQL, sqlConn)
            Dim dtLoading As New DataTable("tbl_000_Item_Sub")

            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With cboMultiCombo
                .ColumnNum = 3
                .ColumnWidth = "100;150;150"
                .GridLineHorizontal = True
                .GridLineVertical = True
                '.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(2) {"SpecificCode", "SpecificDescription", "BrandType"}
                .SourceDataTable = dtLoading
            End With
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub


    Private Sub LoadSpecificCodeInventory(ByVal cboMultiCombo As MTGCComboBox, ByVal category As String)
        Try
            If category = String.Empty Then
                SQL = "SELECT     SpecificCode, SpecificDescription , BrandType " & _
                                  "FROM tbl_000_Item_Sub " & _
                                  "WHERE(isActive <> 0)"
            Else
                SQL = "SELECT     tbl_000_Item_Sub.SpecificCode, tbl_000_Item_Sub.SpecificDescription, tbl_000_Item_Sub.BrandType, tbl_000_Item.CategoryCode " & _
                      "FROM         tbl_000_Item_Sub INNER JOIN " & _
                      "tbl_000_Item ON tbl_000_Item_Sub.ItemCode = tbl_000_Item.ItemCode " & _
                      "WHERE     (tbl_000_Item_Sub.isActive <> 0) AND (tbl_000_Item.CategoryCode = '" & category & "')"
            End If

            Dim sqlConn As New SqlConnection(cnString)
            Dim sqlReader As SqlDataReader
            Dim sqlCommand As New SqlCommand(SQL, sqlConn)
            Dim dtLoading As New DataTable("tbl_000_Item_Sub")

            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With cboMultiCombo
                .ColumnNum = 3
                .ColumnWidth = "100;150;150"
                .GridLineHorizontal = True
                .GridLineVertical = True
                '.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(2) {"SpecificCode", "SpecificDescription", "BrandType"}
                .SourceDataTable = dtLoading
            End With
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    Private Sub LoadSubCatigoryComboBox(ByVal cboMultiCombo As MTGCComboBox)
        Try
            SQL = "GetCategorySub '" & mtg1.SelectedValue & "'"
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
                .SourceDataString = New String(1) {"SubCategoryCode", "SubCategoryName"}
                .SourceDataTable = dtLoading
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub FillSection()
    '    LoadSectionToMultiCombo(mtg2, mtg1.Text)
    'End Sub

    'Private Sub FillLine()
    '    LoadLineToMultiCombo(mtg3, mtg2.Text)
    'End Sub

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
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call ViewReport(ReportMode.rptWindowMode)
    End Sub

    Private Sub mtg2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtg2.SelectedIndexChanged
        If Not mtg2.SelectedValue Is Nothing Then
            FillLine()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call ViewReport(ReportMode.rptPrintMode)
    End Sub
#End Region



    Private Sub mtg4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtg4.SelectedIndexChanged
        Select Case strRpt
            Case "Withdrawal Report"
                Select Case listreport.SelectedIndex

                    Case 0, 2
                        fillLine()
                        mtg5.Text = String.Empty
                End Select
        End Select
    End Sub

    Private Sub mtg3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtg3.SelectedIndexChanged
        Select Case strRpt
            Case "Withdrawal Report"
                Select Case listreport.SelectedIndex

                    Case 0, 2
                        mtg4.Text = String.Empty
                        mtg5.Text = String.Empty
                        fillsection()

                End Select
        End Select
    End Sub

    Private Sub fillsection()
        LoadSectionToMultiCombo(mtg4, mtg3.Text)
    End Sub

    Private Sub fillLine()
        LoadLineToMultiCombo(mtg5, mtg4.Text)
    End Sub

    Private Sub cbo2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo2.SelectedIndexChanged
        If Not frmload And Not islooping Then
            Select Case strRpt
                Case "Inventory Report"
                    Select Case listreport.SelectedIndex
                        Case 0, 1, 2
                            LoadSpecificCodeInventory(mtg3, cbo2.SelectedValue)
                    End Select
            End Select
        End If

    End Sub

    Private Sub cbo2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo2.Validated
        Select Case strRpt
            Case "Inventory Report"
                Select Case listreport.SelectedIndex
                    Case 0, 1, 2

                        LoadSpecificCodeInventory(mtg3, cbo2.SelectedValue)
                        mtg3.SelectedIndex = -1
                End Select
        End Select
    End Sub
End Class
