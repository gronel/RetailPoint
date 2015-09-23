Imports System.Windows.Forms

Public Class frm_SendAlert
    Public frm As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        frm_100_WR.SetResult = True
        Me.Close()
    End Sub

   

    Private Sub frm_SendAlert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case frm
            Case "WR"
                dgdetails.Visible = True
                dg2.Visible = False
            Case "DR"
                dgdetails.Visible = False
                dg2.Visible = True
        End Select
    End Sub

    Private Sub dg2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick

    End Sub

    Private Sub dg2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg2.RowsAdded
        lblCountSub.Text = CountGridRows(dg2)
    End Sub

    Private Sub dg2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dg2.RowsRemoved
        lblCountSub.Text = CountGridRows(dg2)
    End Sub

    Private Sub dgdetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails.CellContentClick

    End Sub

    Private Sub dgdetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgdetails)
    End Sub

    Private Sub dgdetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgdetails)
    End Sub

   
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        frm_100_WR.SetResult = False
        Me.Close()
    End Sub
End Class
