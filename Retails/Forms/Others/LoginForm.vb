Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Public Class LoginForm

#Region "User Difination"

  
    Private Function intINI() As Boolean

        Try

            Dim objIniFile As New cINIFile(currPath & "\config.ini")
            objIniFile = New cINIFile(currPath & "\config.ini")
            dbServer = clsSecurity.psDecrypt(objIniFile.GetString("Setting", "S", ""))
            dbName = clsSecurity.psDecrypt(objIniFile.GetString("Setting", "D", ""))
            dbUser = clsSecurity.psDecrypt(objIniFile.GetString("Setting", "U", ""))
            dbPass = clsSecurity.psDecrypt(objIniFile.GetString("Setting", "P", ""))
            dbTrust = clsSecurity.psDecrypt(objIniFile.GetString("Setting", "T", "True"))
            cnString = clsSecurity.psDecrypt(objIniFile.GetString("Setting", "C", ""))
            'create DSN
            ''Call CreateSystemDSN()
            objIniFile = Nothing
            Return True
        Catch ex As Exception
            MsgBox("Not Connection!", MsgBoxStyle.Exclamation, "Connection ERROR")
            btnSettings_LinkClicked(Nothing, Nothing)
            Return False
        End Try


    End Function


    Sub RunUpdate()
        Shell(Application.StartupPath & "\Update.exe", AppWinStyle.NormalFocus)

        ' Shell(Application.StartupPath & "\Update.bat", AppWinStyle.NormalFocus)

        Application.Exit()
        'Shell(Application.StartupPath & "\UPv1.exe", AppWinStyle.NormalFocus)
    End Sub
#End Region

#Region "GUI"
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
       
        Try

            If CheckConnection() = False Then Exit Sub

            Cursor = Cursors.WaitCursor
            If getUser(UsernameTextBox.Text, PasswordTextBox.Text) = True Then
                isUsername = UsernameTextBox.Text
                If CurrUser.isActive = True Then
                 
                    MainForm.Show()

                    frmPic.picPhoto.Image = BytesToImage(CurrUser.USER_PHOTO)
                    MainForm.AddMenu()
                    MainForm.tsUser.Text = CurrUser.USER_NAME
                    MainForm.tsCommands.Visible = True
                    frmPic.MdiParent = MainForm
                    frmPic.Show()
                   

                    Call GetCompany()
                    Me.Close()
                    GC.Collect()
                    Call SaveAuditTrail("User Log In", Version)

                    MainForm.Focus()

                Else
                    MsgBox("User is not active, please contact your administrator.", MsgBoxStyle.Exclamation, "Security")
                End If

            Else
                MsgBox("Please enter a valid user name and password!", MsgBoxStyle.Exclamation, "Security")
                UsernameTextBox.Text = String.Empty
                PasswordTextBox.Text = String.Empty
                UsernameTextBox.Focus()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        If MsgBox("Are you sure you want to exit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit") = vbYes Then
            Application.Exit()
        End If
    End Sub



    Private Sub LoginForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Application.Exit()
        End If
    End Sub


    Private Sub LoginForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If intINI() = False Then Exit Sub

        lblVersion.Text = Version

        If connectionError = True Then frmSQLConfig.Show() : Me.Close() : Exit Sub

    End Sub

    Private Sub LoginForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Focus()
    End Sub

    Private Sub btnSettings_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnSettings.LinkClicked
        frmSQLConfig.Show()
        Me.Close()
    End Sub

    Private Sub UsernameTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.GotFocus
        UsernameTextBox.SelectAll()
    End Sub

    Private Sub PasswordTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PasswordTextBox.GotFocus
        PasswordTextBox.SelectAll()
    End Sub


#End Region
End Class
