Public Class frm_100_Return_Search_Item


    Public myParent As frm_100_Return

    Private Sub frm_100_PO_Search_Item_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Filter()
    End Sub


    Private Sub frm_100_PO_Search_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillGrid(dgList, "sproc_100_return_item '" & txtfind.Text & "'", "v_ItemMasterFile")
    End Sub

    Private Sub txtfind_KeyDown(sender As Object, e As KeyEventArgs) Handles txtfind.KeyDown
        FillGrid(dgList, "sproc_100_return_item '" & txtfind.Text & "'", "v_ItemMasterFile")
    End Sub

    Sub Filter()

        For Each row As DataGridViewRow In myParent.dgDetails.Rows
            For Each myRow As DataGridViewRow In dgList.Rows
                If row.Cells("colItemCode").Value = myRow.Cells("colItemCode").Value Then
                    dgList.Rows.Remove(myRow)
                End If
            Next
        Next

    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Dim newRow As Integer


        For Each row As DataGridViewRow In dgList.Rows
            If row.Cells("colSelect").Value = True Then
                With myParent.dgDetails
                    newRow = .Rows.Add
                    .Item("colItemId", newRow).Value = row.Cells("colItemId").Value
                    .Item("colItemCode", newRow).Value = row.Cells("colItemCode").Value
                    .Item("colItemName", newRow).Value = row.Cells("colItemName").Value
                    .Item("colDescription", newRow).Value = row.Cells("colDescription").Value
                    .Item("colBrand", newRow).Value = row.Cells("colBrand").Value
                    .Item("colCost", newRow).Value = row.Cells("colCost").Value
                    .Item("colUOM", newRow).Value = row.Cells("colUOM").Value

                End With
            End If
        Next

        Me.Dispose()
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        CheckAll(btnSelectAll.Text = "Select All")
    End Sub

    Sub CheckAll(ByVal bolValue As Boolean)
        Try


            For i = 0 To dgList.RowCount - 1
                dgList.Item("colSelect", i).Value = bolValue
            Next
            If bolValue = True Then
                btnSelectAll.Text = "Unselect All"
            Else
                btnSelectAll.Text = "Select All"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "[CheckAll]")
        End Try
    End Sub
End Class