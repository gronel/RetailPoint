Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_dr_paper

    Public DRNo As String, OrderNo As String
    Dim cryRpt As New ReportDocument
#Region "Method"

    Sub fillcode(ByVal cbo As ComboBox)
        FillCombobox(cbo, "SELECT    ( FirstName + ' ' + CASE WHEN MiddleName IS NULL THEN '' WHEN MiddleName = ' ' THEN '' ELSE SubString(MiddleName, 1, 1) " & _
                     " + '. ' END + LastName + ' ' )AS EmpName ,Designation FROM tbl_000_Employee " & _
"WHERE     (IsActive = 1) AND (Designation IN ('President', 'General Manager'))", "tbl_000_Employee", "EmpName", "Designation")
    End Sub

    Sub viewreport(ByVal _drno As String, ByVal _orderlist As String)
        Try
            If rdbtn1.Checked = True Then

                cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_DR_Report.rpt")
                cryRpt.Refresh()
                cryRpt.SetDataSource(FillReportForm("sp_rpt_DR '" & 0 & "','" & _drno & "'", "tbl_100_DR_Sub"))
                cryRpt.SetParameterValue("orderno", _orderlist)
            ElseIf rdbtn2.Checked = True Then
                If cboapp.Text = String.Empty Then errorp.SetError(cboapp, "Approved") : Exit Sub
                cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_DR_invoice_paper.rpt")
                cryRpt.Refresh()
                cryRpt.SetDataSource(FillReportForm("sp_rpt_DR '" & 0 & "','" & _drno & "'", "tbl_100_DR_Sub"))
                cryRpt.SetParameterValue("orderno", _orderlist)
                cryRpt.SetParameterValue("president", cboapp.Text)
                cryRpt.SetParameterValue("designation", cboapp.SelectedValue)
            End If


            '' fill datasource of the report


            With frm_200_ReportV
                .rpt_viewer.ReportSource = cryRpt
                HideTheTabControl(.rpt_viewer)
                .Show()
                .Focus()
            End With

        Catch ex As Exception
            MsgBox("Error: viewreport -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

#End Region

    Private Sub frm_dr_paper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call fillcode(cboapp)
        Me.rdbtn1.Checked = True
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        viewreport(DRNo, OrderNo)

    End Sub

    Private Sub rdbtn2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtn2.CheckedChanged
        cboapp.Enabled = True

    End Sub

    Private Sub rdbtn1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtn1.CheckedChanged
        cboapp.Enabled = False
        cboapp.SelectedIndex = -1
    End Sub
End Class