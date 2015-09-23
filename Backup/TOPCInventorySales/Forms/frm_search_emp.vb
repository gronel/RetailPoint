Public Class frm_search_emp

    Private Sub frm_search_emp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmSearchItems.Icon
        Me.cboCategory.Text = "All"
        Me.txtValue.Text = String.Empty
        Call FillDataGrid(dgdetails, "sp_Search_Employee'" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 6)

    End Sub

    Private Sub dgdetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                With frm_100_WR
                    .dgDetails.Item("colIDno", .dgDetails.CurrentRow.Index).Value = dgdetails.Item(1, dgdetails.CurrentRow.Index).Value
                    .dgDetails.Item("colName", .dgDetails.CurrentRow.Index).Value = dgdetails.Item(2, dgdetails.CurrentRow.Index).Value
                    Me.Close()
                End With
        End Select
    End Sub

    Private Sub dgdetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgdetails)
    End Sub

    Private Sub dgdetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgdetails)
    End Sub

    Private Sub txtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
      
        Call FillDataGrid(dgdetails, "sp_Search_Employee'" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 6)
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        If cboCategory.Text = "All" Then
            txtValue.Enabled = False
        Else
            txtValue.Enabled = True
        End If
    End Sub
End Class