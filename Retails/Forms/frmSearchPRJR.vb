Public Class frmSearchPRJR

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Dgdetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearchItems.CellContentClick

    End Sub

    Private Sub Dgdetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgSearchItems.RowsAdded
        lblCountSub.Text = CountGridRows(dgSearchItems)
    End Sub

    Private Sub Dgdetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgSearchItems.RowsRemoved
        lblCountSub.Text = CountGridRows(dgSearchItems)
    End Sub

    Private Sub checkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkall.CheckedChanged
        If checkall.Checked = True Then
            For i = 0 To dgSearchItems.RowCount - 1
                dgSearchItems.Item("colCheckAdd", i).Value = 1
                dgSearchItems.Item("colCheckAdd", i).ReadOnly = True
            Next
        Else
            For i = 0 To dgSearchItems.RowCount - 1
                dgSearchItems.Item("colCheckAdd", i).Value = 0
                dgSearchItems.Item("colCheckAdd", i).ReadOnly = False
            Next
        End If
    End Sub
End Class