Public Class frm_100_SalesScreen_Pay

    Public myParent As frm_100_SalesScreen

    Private Sub frm_100_SalesScreen_Pay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCash.Focus()
    End Sub

    Private Sub txtCash_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCash.KeyDown
        If txtCash.Text <> "" Then
            lblchange.Text = txtCash.Text - lblAmountDue.Text
        End If


    End Sub

    Private Sub frm_100_SalesScreen_Pay_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            bntOk_Click(Me, Nothing)
        End If
    End Sub

    Private Sub bntOk_Click(sender As Object, e As EventArgs) Handles bntOk.Click
        Try
            If txtCash.Text = String.Empty Then
                MessageBox.Show("Please Enter Cash.", "Required")
                Exit Sub
            End If

            myParent.SaveRecord(txtCash.Text, lblchange.Text)
            Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtCash_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCash.KeyUp
        If txtCash.Text <> "" Then
            lblchange.Text = txtCash.Text - lblAmountDue.Text
        End If
    End Sub
End Class