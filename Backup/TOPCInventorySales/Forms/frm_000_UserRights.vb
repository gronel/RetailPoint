Public Class frm_000_UserRights

    Inherits System.Windows.Forms.Form

    Public myParent As frm_000_User

    Private Sub frm_000_UserRights_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        FilterRights()
    End Sub

    Private Sub frm_000_UserRights_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillGrid(dgRights, "GetSubMenus", "tblSubMenus")
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        CheckAll(btnSelectAll.Text = "Select All")
    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click

        Dim newRow As Integer

        For Each row As DataGridViewRow In dgRights.Rows
            If row.Cells("colSelect").Value = True Then
                With myParent.dgRights
                    newRow = .Rows.Add
                    .Item("colMenuID", newRow).Value = row.Cells("colMenuID").Value
                    .Item("colFormName", newRow).Value = row.Cells("colFormName").Value
                    .Item("colCanAdd", newRow).Value = True
                    .Item("colCanEdit", newRow).Value = True
                    .Item("colCanDelete", newRow).Value = True
                    .Item("colCanView", newRow).Value = True
                    .Item("colCanPrint", newRow).Value = True
                    .Item("colCanVoid", newRow).Value = True

                End With
            End If
        Next

        Me.Dispose()
    End Sub


    Sub CheckAll(ByVal bolValue As Boolean)
        Try


            For i = 0 To dgRights.RowCount - 1
                dgRights.Item("colSelect", i).Value = bolValue
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

    Sub FilterRights()

        For Each row As DataGridViewRow In myParent.dgRights.Rows
            For Each myRow As DataGridViewRow In dgRights.Rows
                If row.Cells("colMenuID").Value = myRow.Cells("colMenuID").Value Then
                    dgRights.Rows.Remove(myRow)
                End If
            Next
        Next

    End Sub


End Class