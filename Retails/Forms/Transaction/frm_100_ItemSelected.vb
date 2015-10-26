Public Class frm_100_ItemSelected

    Public myParent As frm_100_SalesScreen
    Dim ErrProvider As New ErrorProviderExtended
    Public ItemId As Integer
    Public ItemName As String
    Public ItemDescription As String
    Public UOM As String
    Public UnitPrice As Decimal
    Public StockOH As Integer
    Private hasError As Boolean

    Private Sub frm_100_ItemSelected_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtqty.Focus()
        lblinfo.Text = String.Empty
        txtitemName.Text = ItemName
        txtdescription.Text = ItemDescription
        hasError = False

        With ErrProvider 'Get the error or empty text
            .Controls.Clear()
            .Controls.Add(txtqty, "Item Quantity")

        End With
    End Sub

    Private Sub bntOk_Click(sender As Object, e As EventArgs) Handles bntOk.Click
        Dim newRow As Integer
        If ErrProvider.CheckAndShowSummaryErrorMessage Then

            With myparent.dgList2
                newRow = .Rows.Add
                .Item("colitemId2", newRow).Value = ItemId
                .Item("colItemName2", newRow).Value = txtitemName.Text
                .Item("colDescription2", newRow).Value = txtdescription.Text
                .Item("Qty", newRow).Value = txtqty.Text
                .Item("UOM", newRow).Value = UOM
                .Item("colUnitPrice2", newRow).Value = UnitPrice
                .Item("Subtotal", newRow).Value = UnitPrice * txtqty.Text

            End With
        End If
        myParent.ComputeAllRows()
        Me.Dispose()
    End Sub

    Private Sub txtqty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqty.KeyDown
        If e.KeyCode = Keys.Enter Then
            If hasError = False Then
                bntOk_Click(Me, Nothing)
            Else
                txtqty.Focus()

            End If




        End If
    End Sub

   
    Private Sub txtqty_KeyUp(sender As Object, e As KeyEventArgs) Handles txtqty.KeyUp
        If txtqty.Text <> "" Then
            If txtqty.Text > StockOH Then
                lblinfo.Text = "Out of Stock!"
                lblinfo.ForeColor = Color.Red
                hasError = True
            Else
                lblinfo.Text = "OK"
                lblinfo.ForeColor = Color.Green
                hasError = False
            End If
        Else
            lblinfo.Text = String.Empty
        End If



    End Sub
End Class