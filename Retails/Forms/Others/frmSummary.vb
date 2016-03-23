Imports System.Data.SqlClient
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

        Call clear()
    End Sub

    Private Sub control()
        Try
            islooping = True
            Call hidecontrols()
            Select Case strRpt


                Case "Inventory Report"

                    Select Case listreport.SelectedIndex

                        Case 0, 1, 2
                            grp1.Text = listreport.Text
                            hidecontrols()
                            lbl1.Show()
                            lbl1.Text = "Select Preview or Print to show the report"
                    End Select

                Case "Sales Report"
                    If listreport.SelectedIndex = 0 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl2.Show()
                        dtp1.Show()
                        dtp2.Show()
                        lbl1.Text = "From:"
                        lbl2.Text = "To:"
                    ElseIf listreport.SelectedIndex = 1 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl2.Show()
                        cbo1.Show()
                        cbo2.Show()
                        lbl1.Text = "Year:"
                        lbl2.Text = "Month:"
                        cbo2.DataSource = Nothing
                        cbo1.Items.Clear()
                        cbo2.Items.Clear()
                        FillYearStartToCurrent(cbo1)
                        FillMonthlyComboBox(cbo2)
                        cbo1.Text = Date.Now.Year
                    ElseIf listreport.SelectedIndex = 2 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()                      
                        cbo1.Show()
                        lbl1.Text = "Year:"
                        cbo1.Items.Clear()
                        FillYearStartToCurrent(cbo1)
                        cbo1.Text = Date.Now.Year
                    End If
                Case "My Sales"
                    If listreport.SelectedIndex = 0 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl2.Show()
                        lbl3.Show()
                        dtp1.Show()
                        dtp2.Show()
                        cbo3.Show()
                        lbl1.Text = "From:"
                        lbl2.Text = "To:"
                        lbl3.Text = "Casher:"
                        FillCombobox(cbo3, "SELECT UserID, EmpName FROM tbl_000_User WHERE (isActive = 1)", "tbl_000_User", "EmpName", "UserID")
                    End If
                Case "Sales Report per Customer"
                    If listreport.SelectedIndex = 0 Then
                        grp1.Text = listreport.Text
                        hidecontrols()
                        lbl1.Show()
                        lbl2.Show()
                        lbl3.Show()
                        dtp1.Show()
                        dtp2.Show()
                        cbo3.Show()
                        lbl1.Text = "From:"
                        lbl2.Text = "To:"
                        lbl3.Text = "Casher:"
                        FillCombobox(cbo3, "SELECT UserID, EmpName FROM tbl_000_User WHERE (isActive = 1)", "tbl_000_User", "EmpName", "UserID")
                    End If



            End Select
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try

    End Sub


    Private Sub AddListItem()

        With listreport.Items
            Select Case strRpt

                Case "Inventory Report"

                    .Add("Item Below Stock Level")
                    .Add("Fast Moving Item")
                    .Add("Fast Moving Item Below Stock Level")

                Case "Sales Report"
                    .Add("Sales Report Details")
                    .Add("Sales Report(per Day)")
                    .Add("Sales Report(per Month)")

                Case "My Sales"
                    .Add("Sales Report (Casher Posting)")
                Case "Sales Report per Customer"
                    .Add("Sales Report per Customer")
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
        Try

            Select Case strRpt
                Case "Inventory Report"
                    Select Case listreport.SelectedIndex
                        Case 0

                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_ItemBelowStockLevel.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("select * from dbo.v_ItemMasterFileBelowStockLevel", "v_ItemMasterFileBelowStockLevel"))
                                .SetParameterValue("company", CompanyInfo.companyName)
                                .SetParameterValue("address", CompanyInfo.companyAddress)
                                .SetParameterValue("prepared", CurrUser.USER_FULLNAME)
                                End With

                        Case 1
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_TopFastMovingItem.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("select * from v_TopFastMovingItem ORDER BY SalesQty DESC", "v_ItemMasterFileBelowStockLevel"))
                                .SetParameterValue("company", CompanyInfo.companyName)
                                .SetParameterValue("address", CompanyInfo.companyAddress)
                                .SetParameterValue("prepared", CurrUser.USER_FULLNAME)
                            End With

                        Case 2
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_TopFastMovingItemBelowStockLevel.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("select * from v_TopFastMovingItemBelowStockLevel ORDER BY ItemName, BrandType", "v_ItemMasterFileBelowStockLevel"))
                                .SetParameterValue("company", CompanyInfo.companyName)
                                .SetParameterValue("address", CompanyInfo.companyAddress)
                                .SetParameterValue("prepared", CurrUser.USER_FULLNAME)
                            End With

                    End Select
                    ''--->Payable Payment Schedule Report
                Case "Sales Report"
                    Select Case listreport.SelectedIndex

                        Case 0 ''--> sales report 


                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_SalesReport.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sproc_200_SalesReport'" & dtp1.Text & "','" & dtp2.Text & "'", "tbl_100_SR"))
                                .SetParameterValue("company", CompanyInfo.companyName)
                                .SetParameterValue("address", CompanyInfo.companyAddress)
                                .SetParameterValue("prepared", CurrUser.USER_FULLNAME)
                                .SetParameterValue("dtfrom", dtp1.Text)
                                .SetParameterValue("dtto", dtp2.Text)
                            End With

                        Case 1 ''--> sales report per day
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_SalesReportMonthlyPeriod.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sproc_200_SalesReportMonthlyPeriod'" & cbo1.Text & "','" & cbo2.SelectedValue & "'", "tbl_100_SR"))
                                .SetParameterValue("company", CompanyInfo.companyName)
                                .SetParameterValue("address", CompanyInfo.companyAddress)
                                .SetParameterValue("prepared", CurrUser.USER_FULLNAME)
                                .SetParameterValue("iyr", cbo1.Text)
                                .SetParameterValue("imonth", cbo2.Text)
                            End With
                        Case 2 ''sales report per month
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_SalesReportAnnual.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("select * from v_MonthlySales ORDER BY SalesYr, SalesMonthNo", "v_ItemMasterFileBelowStockLevel"))
                                .SetParameterValue("company", CompanyInfo.companyName)
                                .SetParameterValue("address", CompanyInfo.companyAddress)
                                .SetParameterValue("prepared", CurrUser.USER_FULLNAME)
                            End With
                    End Select
                Case "My Sales"
                    Select Case listreport.SelectedIndex

                        Case 0 ''--> sales report casher posting
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_SalesReportCasherPosting.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sproc_200_SalesReportCasherPosting'" & dtp1.Text & "','" & dtp2.Text & "', '" & cbo3.SelectedValue & "'", "tbl_100_SR"))
                                .SetParameterValue("company", CompanyInfo.companyName)
                                .SetParameterValue("address", CompanyInfo.companyAddress)
                                .SetParameterValue("prepared", CurrUser.USER_FULLNAME)
                                .SetParameterValue("dtfrom", dtp1.Text)
                                .SetParameterValue("dtto", dtp2.Text)
                            End With

                    End Select
                Case "Sales Report per Customer"
                    Select Case listreport.SelectedIndex

                        Case 0 ''--> sales report casher posting
                            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_SalesReportPerCustomer.rpt")
                            With cryRpt
                                .SetDataSource(FillReportForm("sproc_200_SalesReportCasherPostingPerCustomer'" & dtp1.Text & "','" & dtp2.Text & "', '" & cbo3.SelectedValue & "'", "tbl_100_SR"))
                                .SetParameterValue("company", CompanyInfo.companyName)
                                .SetParameterValue("address", CompanyInfo.companyAddress)
                                .SetParameterValue("prepared", CurrUser.USER_FULLNAME)
                                .SetParameterValue("dtfrom", dtp1.Text)
                                .SetParameterValue("dtto", dtp2.Text)
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call ViewReport(ReportMode.rptPrintMode)
    End Sub
#End Region




    
End Class
