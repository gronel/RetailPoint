Public Class frm_000_ImageLocation

    Private Sub Save()
        Try
            RunQuery("Delete from tbl_000_ImgPath")
            RunQuery("Insert into tbl_000_ImgPath(imgFolderPath)values('" & txtimagePath.Text & "')")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub Filldata()
        Try
            txtimagePath.Text = DBLookUp("Select imgFolderPath from tbl_000_ImgPath", "imgFolderPath")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub frm_000_ImageLocation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call Save()
    End Sub

    Private Sub frm_000_ImageLocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Filldata()
    End Sub

    Private Sub btnselectpath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnselectpath.Click
        FD_img.ShowDialog()
        If FD_img.SelectedPath <> String.Empty Then
            txtimagePath.Text = FD_img.SelectedPath
        End If
    End Sub
End Class