Public Class frmMyAccount

    Dim user As New tbl_000_User

    Private Sub frmMyAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''CenterForm(Me)
        With user
            .FetchRecord(CurrUser.USER_ID)
            txtEmpID.Text = .EmpID
            txtEmpName.Text = .EmpName
            picPhoto.Image = BytesToImage(.UserPic)
            CurrUser.USER_PASSWORD = .UserPassword
        End With
    End Sub

    Private Sub btnSavePass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePass.Click
        If clsSecurity.psEncrypt(txtOld.Text.Trim) <> CurrUser.USER_PASSWORD Then
            MsgBox("Password does not match.", MsgBoxStyle.Exclamation, "Change Password")
        ElseIf String.IsNullOrEmpty(txtNew.Text.Trim) Then
            MsgBox("Password must not be empty.", MsgBoxStyle.Exclamation, "Empty")
        ElseIf txtNew.Text.Trim <> txtVerify.Text.Trim Then
            MsgBox("Password does not match.", MsgBoxStyle.Exclamation, "Change Password")
        Else
            If _UpdateRecord("tbl_000_User", "UserPassword='" & clsSecurity.psEncrypt(txtNew.Text.Trim) & "'", "WHERE UserName='" & CurrUser.USER_NAME & "'") Then
                MsgBox("Password changed.")
            Else
                MsgBox("Not Saved")
            End If
        End If
    End Sub
End Class