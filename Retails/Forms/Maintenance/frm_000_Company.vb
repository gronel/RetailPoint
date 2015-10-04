Public Class frm_000_Company

    Dim company As New tbl_000_Company
    Dim CompanyID As Integer = 1
    Dim errProvider As New ErrorProviderExtended

    Private Sub frm_000_Company_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        End If
    End Sub

    Private Sub frm_000_Company_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        With errProvider
            .Controls.Clear()
            .Controls.Add(txtCompanyName, "Company Name")
        End With
        SetEditField()
    End Sub

    Sub SetEditField()
        With company
            .FetchRecord(CompanyID)
            txtCompanyName.Text = .CompanyName
            txtAddress.Text = .Address
            txtPhone.Text = .Phone
            txtFax.Text = .Fax
            txtEmail.Text = .Email
            txtWebsite.Text = .Website
            If .Logo Is Nothing Then
                Me.picPhoto.Image = MainForm.picDefault.Image
            Else
                picPhoto.Image = BytesToImage(.Logo)
            End If

        End With
    End Sub

    Sub SaveRecord()
        If errProvider.CheckAndShowSummaryErrorMessage = False Then

        Else

            With company
                .CompanyName = txtCompanyName.Text
                .Address = txtAddress.Text
                .Phone = txtPhone.Text
                .Fax = txtFax.Text
                .Email = txtEmail.Text
                .Website = txtWebsite.Text
                .Logo = ImageToByte(picPhoto.Image)
                _Result = .Save(True)
            End With

            If _Result Then
                MsgBox("Saved!", MsgBoxStyle.Information, "Saved")
                Me.Dispose()
            End If

        End If

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveRecord()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        BrowsePhoto(picPhoto)
    End Sub
End Class