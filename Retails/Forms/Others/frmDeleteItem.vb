Public Class frmDeleteItem
    Dim ErrProvider As New ErrorProviderExtended
    Public frmparent As frm_000_ItemList
    Sub enablebtn()
        If txtitemcode.Text = "" Or txtcategory.Text = "" Or txtsubcategory.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If vbYes = MsgBox("Are you sure you want to Delete this item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Prompt") Then
            _OpenTransaction()
            _Result = _DeleteRecord("tbl_000_Item", "WHERE ItemCode='" & txtitemcode.Text & "' AND CategoryCode='" & txtcategory.Text & "' and SubCategoryCode='" & txtsubcategory.Text & "'")
            _CloseTransaction(_Result)
            ' frmparent.RefreshRecord("GetItemSub '" & frmparent.cboItemCode.Text & "'")
            frmparent.Refresh()
            Me.Close()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmDeleteItem_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        txtitemcode.Clear()
        txtcategory.Clear()
        txtsubcategory.Clear()
    End Sub

    Private Sub frmDeleteItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        End If
    End Sub

    Private Sub frmDeleteItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ErrProvider
            .Controls.Clear()
            .Controls.Add(txtitemcode, "Item Code")
            .Controls.Add(txtcategory, "Item Code")
            .Controls.Add(txtsubcategory, "Item Code")
        End With
    End Sub

    Private Sub txtitemcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtitemcode.TextChanged
        enablebtn()
    End Sub

    Private Sub txtcategory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcategory.TextChanged
        enablebtn()
    End Sub

    Private Sub txtsubcategory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsubcategory.TextChanged
        enablebtn()
    End Sub
End Class