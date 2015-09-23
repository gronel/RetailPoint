Imports System.Data.SqlClient
Imports TOPCInventorySales.clsPublic
Public Class frm_POPUP
    Implements IBPSCommand
    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

    End Sub
    Sub record()
        'If Trans = "PR" Then
        FillDataGrid(dgdatails, "Get_POPUP'" & "PR" & "'", 0, 7)
        'ElseIf Trans = "JR" Then
        FillDataGrid(dgdetails3, "Get_POPUP'" & "JR" & "'", 0, 6)
        'ElseIf Trans = "RR-PR" Then
        FillDataGrid(dgdetails2, "Get_POPUP'" & "RR-PR" & "'", 0, 7)
        'ElseIf Trans = "RR-JR" Then
        FillDataGrid(dgdetails4, "Get_POPUP'" & "RR-JR" & "'", 0, 6)
        'ElseIf Trans = "PO" Then
        FillDataGrid(dgdetails5, "Get_POPUP'" & "PO" & "'", 0, 9)
        'ElseIf Trans = "JO" Then
        FillDataGrid(dgdetails6, "Get_POPUP'" & "JO" & "'", 0, 8)

        FillDataGrid(dgdetails7, "Get_POPUP'" & "PRstatus" & "'", 0, 7)

        FillDataGrid(dgdetails8, "Get_POPUP'" & "JRstatus" & "'", 0, 6)
        'End If
        Call hideTabpage()
        Call ValidatedDg()
    End Sub

    Private Sub ValidatedDg()
        Try
            ''PR to PO Datagrid validated
            For Each row As DataGridViewRow In dgdatails.Rows
                If row.IsNewRow = False Then
                    row.Cells("PRPO_Quantity").Value = FormatNumber(row.Cells("PRPO_Quantity").Value, CInt(row.Cells("PRPO_Dec").Value))
                End If
            Next

            ''PO Datagrid validated
            For Each row As DataGridViewRow In dgdetails5.Rows
                If row.IsNewRow = False Then
                    row.Cells("colPO_QTY").Value = FormatNumber(row.Cells("colPO_QTY").Value, CInt(row.Cells("colPO_Dec").Value))
                    row.Cells("colPO_QTYBal").Value = FormatNumber(row.Cells("colPO_QTYBal").Value, CInt(row.Cells("colPO_Dec").Value))
                End If
            Next

            'PR-RR Datagrid validated
            For Each row As DataGridViewRow In dgdetails2.Rows
                If row.IsNewRow = False Then
                    row.Cells("colPR_Qty").Value = FormatNumber(row.Cells("colPR_Qty").Value, CInt(row.Cells("colPR_Dec").Value))

                End If
            Next

            ''PR Status 
            For Each row As DataGridViewRow In dgdetails7.Rows
                If row.IsNewRow = False Then
                    row.Cells("colPRBal").Value = FormatNumber(row.Cells("colPRBal").Value, CInt(row.Cells("colPRDec").Value))

                End If
            Next


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub frm_POPUP_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
   
    End Sub

    Private Sub frm_POPUP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Space Then
            Me.Close()
        End If
    End Sub
    ''hide popup tab if the datagrid row is empty
    Sub hideTabpage()

        If dgdatails.RowCount = 0 Then
            Me.TabControl1.Controls.Remove(Me.TabPage1)
        End If
        If dgdetails2.RowCount = 0 Then
            Me.TabControl1.Controls.Remove(Me.TabPage2)
        End If
        If dgdetails3.RowCount = 0 Then
            Me.TabControl1.Controls.Remove(Me.TabPage3)
        End If
        If dgdetails4.RowCount = 0 Then
            Me.TabControl1.Controls.Remove(Me.TabPage4)
        End If
        If dgdetails5.RowCount = 0 Then
            Me.TabControl1.Controls.Remove(Me.TabPage5)
        End If
        If dgdetails6.RowCount = 0 Then
            Me.TabControl1.Controls.Remove(Me.TabPage6)
        End If
        If dgdetails7.RowCount = 0 Then
            Me.TabControl1.Controls.Remove(Me.TabPage7)
        End If
        If dgdetails8.RowCount = 0 Then
            Me.TabControl1.Controls.Remove(Me.TabPage8)
        End If


        'meclose()

    End Sub
  
    Private Sub frm_POPUP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call record()
      
        GroupBox2.Text = "Purchase Requisition item(s) that no RR record, based on PR Status"
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub dgdatails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdatails.CellValidated
        'dgdatails.Item("Column19", e.RowIndex).Value = FormatNumber(CInt(dgdatails.Item("Column19", e.RowIndex).Value), 0)
    End Sub
    Private Sub dgdatails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdatails.RowsAdded
        lbl1.Text = CountGridRows(dgdatails)
    End Sub

    Private Sub dgdatails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdatails.RowsRemoved
        lbl1.Text = CountGridRows(dgdatails)
    End Sub

    Private Sub dgdetails2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails2.CellContentClick

    End Sub

    Private Sub dgdetails2_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails2.CellValidated
        ' dgdetails2.Item("DataGridViewTextBoxColumn5", e.RowIndex).Value = FormatNumber(CInt(dgdetails2.Item("DataGridViewTextBoxColumn5", e.RowIndex).Value), 0)
    End Sub

    Private Sub dgdetails2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails2.RowsAdded
        lbl2.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub dgdetails2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails2.RowsRemoved
        lbl2.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub dgdetails3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails3.CellContentClick

    End Sub

    Private Sub dgdetails3_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails3.RowsAdded
        lbl3.Text = CountGridRows(dgdetails3)
    End Sub

    Private Sub dgdetails3_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails3.RowsRemoved
        lbl3.Text = CountGridRows(dgdetails3)
    End Sub

    Private Sub dgdetails4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails4.CellContentClick

    End Sub

    Private Sub dgdetails4_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails4.RowsAdded
        lbl4.Text = CountGridRows(dgdetails4)
    End Sub

    Private Sub dgdetails4_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails4.RowsRemoved
        lbl4.Text = CountGridRows(dgdetails4)
    End Sub

    Private Sub dgdetails5_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails5.CellContentClick

    End Sub

    Private Sub dgdetails5_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails5.CellValidated
        'dgdetails5.Item("Column7", e.RowIndex).Value = FormatNumber(CInt(dgdetails5.Item("Column7", e.RowIndex).Value), 0)
    End Sub

    Private Sub dgdetails5_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails5.RowsAdded
        lbl5.Text = CountGridRows(dgdetails5)
    End Sub

    Private Sub dgdetails5_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails5.RowsRemoved
        lbl5.Text = CountGridRows(dgdetails5)
    End Sub

    Private Sub dgdetails6_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails6.CellContentClick

    End Sub

    Private Sub dgdetails6_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails6.RowsAdded
        lbl6.Text = CountGridRows(dgdetails6)
    End Sub

    Private Sub dgdetails6_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails6.RowsRemoved
        lbl6.Text = CountGridRows(dgdetails6)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub dgdatails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdatails.CellContentClick

    End Sub

    Private Sub dgdetails7_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails7.CellContentClick

    End Sub

    Private Sub dgdetails7_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails7.RowsAdded
        Label1.Text = CountGridRows(dgdetails7)
    End Sub

    Private Sub dgdetails7_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails7.RowsRemoved
        Label1.Text = CountGridRows(dgdetails7)
    End Sub

    Private Sub dgdetails8_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails8.CellContentClick

    End Sub

    Private Sub dgdetails8_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails8.RowsAdded
        Label5.Text = CountGridRows(dgdetails8)
    End Sub

    Private Sub dgdetails8_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails8.RowsRemoved
        Label5.Text = CountGridRows(dgdetails8)
    End Sub
End Class