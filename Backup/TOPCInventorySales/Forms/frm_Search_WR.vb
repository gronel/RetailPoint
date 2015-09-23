Imports System.Data.SqlClient
Public Class frm_Search_WR

#Region "Procedure"

    Private Sub FillDataGridITEm(ByVal dgView As DataGridView, ByVal strSQL As String, ByVal colStart As Integer, ByVal colEnd As Integer)
        Dim intRow As Integer
        Dim i As Integer
        Dim intCol As Integer

        OpenDB()

        Dim cmdCust As New SqlCommand

        dgView.Rows.Clear()
        cmdCust.Connection = cn
        cmdCust.CommandText = strSQL
        Dim dr As SqlDataReader = cmdCust.ExecuteReader()


        While dr.Read()
            i = 0
            intRow = dgView.Rows.Add()
            For intCol = colStart To colEnd
                dgView.Item(intCol, intRow).Value = dr(i)
                i = i + 1
            Next
        End While
        dr.Close()
        cn.Close()

    End Sub


#End Region

    Sub filldata()
        FillDataGrid(dgdetailsWR, "GETRR_Item'" & cboCategory.SelectedIndex & "','" & txtValue.Text & "'", 1, 7)
        ' FillDataGridITEm(dgdetailsWR, "SAMPLE_RRTEMP", 1, 7)
        lblCountSub.Text = dgdetailsWR.RowCount
    End Sub

    Private Sub frm_Search_WR_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cboCategory.SelectedIndex = -1
        txtValue.Text = String.Empty

    End Sub
    Private Sub frm_Search_WR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmSearchItems.Icon
        filldata()
    End Sub

    Private Sub chckall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckall.CheckedChanged
        For i = 0 To dgdetailsWR.RowCount - 1
            If chckall.Checked = True Then
                dgdetailsWR.Item("colcheckWR", i).Value = 1 '' check all row if true
                dgdetailsWR.Item("colcheckWR", i).ReadOnly = True
            Else
                dgdetailsWR.Item("colcheckWR", i).Value = 0 ''uncheck all row if false
                dgdetailsWR.Item("colcheckWR", i).ReadOnly = False
            End If
        Next
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
            With frm_100_WR
                For i = 0 To dgdetailsWR.RowCount - 1
                    If dgdetailsWR.Item("colcheckWR", i).Value = 1 Then
                        'If CheckCodeFromDatagridView(.dgDetails, 0, dgdetailsWR.Item("colSpecificCodeWR", i).Value) Then
                        '    dgdetailsWR.Item("colcheckWR", i).Value = 0
                        '    MsgBox("Specific Code [" & dgdetailsWR.Item("colSpecificCodeWR", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                        '    Exit Sub
                        'End If
                        If dgdetailsWR.Item("colcheckWR", i).Value = 1 Then
                            .dgDetails.Rows.Add(dgdetailsWR.Item(1, i).Value, "", "", "", "", "", "", "", "", "", "", dgdetailsWR.Item(6, i).Value)

                        End If

                        .fillCode(.dgDetails.RowCount - 2)
                    End If
                Next
            End With
            chckall.Checked = False
            Me.Close()
        End If
    End Sub

    Private Sub dgdetailsWR_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetailsWR.CellContentClick

    End Sub

    Private Sub dgdetailsWR_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetailsWR.RowsAdded
        lblCountSub.Text = CountGridRows(dgdetailsWR)
    End Sub

    Private Sub dgdetailsWR_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetailsWR.RowsRemoved
        lblCountSub.Text = CountGridRows(dgdetailsWR)
    End Sub

    Private Sub txtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
        If cboCategory.SelectedIndex = -1 Then
        Else
            FillDataGrid(dgdetailsWR, "GETRR_Item'" & cboCategory.SelectedIndex & "','" & txtValue.Text & "'", 1, 7)
            lblCountSub.Text = dgdetailsWR.RowCount
        End If
    End Sub
End Class