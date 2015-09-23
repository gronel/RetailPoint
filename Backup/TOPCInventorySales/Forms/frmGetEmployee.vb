Public Class frmGetEmployee
    Public myparent As frm_200_AR_
    Sub fillcode()
        FillDataGrid(dglist, "GetEmployeeACT '" & txtValue.Text & "'", 1, 3)
    End Sub
    Private Sub frmGetEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmSearchItems.Icon
        Call fillcode()
    End Sub

    Private Sub dglist_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dglist.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                myparent.txtempID.Text = dglist.Item(1, dglist.CurrentRow.Index).Value
                myparent.txtempName.Text = dglist.Item(2, dglist.CurrentRow.Index).Value
                myparent.txtStatus.Text = dglist.Item(3, dglist.CurrentRow.Index).Value
                myparent.FillData(dglist.Item(1, dglist.CurrentRow.Index).Value)
                Me.Close()
        End Select
    End Sub

    Private Sub txtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
        Call fillcode()
    End Sub

    Private Sub dglist_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dglist.RowsAdded
        lblCountSub.Text = CountGridRows(dglist)
    End Sub

    Private Sub dglist_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dglist.RowsRemoved
        lblCountSub.Text = CountGridRows(dglist)
    End Sub
End Class