Public Class frm_200_SalesDetails

    Public sr_no As String
    Private Sub frm_200_SalesDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillGrid(dgList, "select ItemName, ItemDescription, BrandType, Qty, Cost, SubAmt from v_sr_item where SRId='" + sr_no + "'", "v_sr_item")

    End Sub

    Sub ComputeAllRows()
        Dim sum As Double
        With dgList
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item(5, i).Value)
            Next
            lbltotalAmt.Text = String.Format("{0:N2}", (NZ(sum)))
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub lbltotalAmt_Click(sender As Object, e As EventArgs) Handles lbltotalAmt.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub dgList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgList.CellContentClick

    End Sub

    Private Sub dgList_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgList.RowsAdded
        ComputeAllRows()
    End Sub

    Private Sub dgList_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgList.RowsRemoved
        ComputeAllRows()
    End Sub
End Class