Imports TOPCInventorySales.clsPublic
Imports System.Data.SqlClient

Public Class frm_200_ReportV

    Private Sub frm_200_ReportV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        ElseIf e.KeyCode = Keys.Control And e.KeyCode = Keys.P And MainForm.tsPrint.Enabled = True Then
            rpt_viewer.PrintReport()
        End If
    End Sub

    Private Sub frm_200_ReportV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CenterForm(Me)
    End Sub
End Class