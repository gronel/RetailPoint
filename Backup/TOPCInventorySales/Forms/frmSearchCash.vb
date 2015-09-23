Public Class frmSearchCash
    Inherits System.Windows.Forms.Form
    Dim dec As Integer
    Public meparent As frm_100_CashAdvance

#Region "Procedure"

    Sub FilterRights()

        For Each row As DataGridViewRow In meparent.dgSub.Rows
            For Each myRow As DataGridViewRow In dgSub.Rows
                If row.Cells("colReferenceNo").Value = myRow.Cells("colCtrl").Value Then
                    dgSub.Rows.Remove(myRow)
                End If
            Next
        Next

    End Sub

#End Region

#Region "GUI Method"

    Private Sub frmSearchCash_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call FilterRights()
    End Sub

    Private Sub frmSearchCash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frm_Searchitem.Icon
        FillGrid(dgSub, "sp_GetSearchItem'" & "Get_CA" & "'", "#temp")
    End Sub

    Sub selectall(ByVal chk As Integer)
        For i = 0 To dgSub.RowCount - 1
            dgSub.Item("colChkAdd", i).Value = chk
            dgSub.Item("colChkAdd", i).ReadOnly = chk
        Next
    End Sub

    Private Sub checkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkall.CheckedChanged
        If checkall.Checked = True Then
            selectall(1)
        Else
            selectall(0)
        End If
    End Sub

    Private Sub dgcash_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgSub.RowsAdded
        lblCountSub.Text = CountGridRows(dgSub)
    End Sub

    Private Sub dgcash_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgSub.RowsRemoved
        lblCountSub.Text = CountGridRows(dgSub)
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim newRow As Integer

        For Each row As DataGridViewRow In dgSub.Rows
            If row.Cells("colChkAdd").Value = 1 Then

                With meparent.dgSub
                    newRow = .Rows.Add
                    .Item("colReferenceNo", newRow).Value = row.Cells("colCtrl").Value
                    .Item("colAmount", newRow).Value = row.Cells("ColConverted").Value
                End With
            End If

        Next

        Me.Dispose()
    End Sub

#End Region

  
End Class