Public Class frm_PopUP_WR

#Region "Procedure"
    Private Sub Record()
        FillGrid(dgDetails, "Get_POPUp_WR", "tbl_100_RR_Temp")
        lblCountSub.Text = dgDetails.RowCount
    End Sub

    ''set row colors if the quantity onhand equal to 0
    Private Sub Setcolors()

        With dgDetails
            For Each row As DataGridViewRow In dgDetails.Rows
                If row.IsNewRow = False Then
                    If row.Cells("colreqQty").Value = 0 Then
                        row.Cells("ColSpecificCode").Style.BackColor = Color.AliceBlue
                        row.Cells("Coldescription").Style.BackColor = Color.AliceBlue
                        row.Cells("Column1").Style.BackColor = Color.AliceBlue
                        row.Cells("colUnit").Style.BackColor = Color.AliceBlue
                        row.Cells("colstock").Style.BackColor = Color.AliceBlue
                        row.Cells("colreqQty").Style.BackColor = Color.AliceBlue
                    End If
                End If
            Next
        End With

    End Sub

#End Region

    Private Sub frm_PopUP_WR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Or e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frm_PopUP_WR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Record()
        If CountGridRows(dgDetails) = 0 Then
            Me.Close()
        Else
            Me.Show()
        End If
        Me.Icon = frm_POPUP.Icon

        Call Setcolors()
    End Sub

    Private Sub dgDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellValidated
        Call Setcolors()
    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick

    End Sub

    Private Sub dgDetails_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetails.Sorted
        Call Setcolors()
    End Sub
End Class