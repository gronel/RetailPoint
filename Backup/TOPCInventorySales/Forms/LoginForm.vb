Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Public Class LoginForm

#Region "User Difination"


    Private Sub DeleteTmp()
        Try
            Dim path As String = currPath & "\tmpIMG"
            If Directory.Exists(path) Then
                System.IO.Directory.Delete(path, True)
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub CreateTmp()

        Call DeleteTmp()
        Dim path As String = currPath & "\tmpIMG"
        If File.Exists(path) Then
        Else
            System.IO.Directory.CreateDirectory(path)
        End If

    End Sub

    Private Sub CheckNewVersion()
        If HasNewVersion() = True Then
            If MsgBox("Your system is not updated" & vbNewLine & "Do you want to update?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Prompt") = MsgBoxResult.Ok Then
                Dim thread1 As New System.Threading.Thread(AddressOf RunUpdate)
                thread1.Priority = Threading.ThreadPriority.Normal
                thread1.Start()
                'Call RunUpdate()

                Exit Sub
            Else
                Me.Close()
            End If
        End If
    End Sub

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
        Dim isSales As String
        Dim isInventory As String
        Try

            If CheckConnection() = False Then Exit Sub

            Cursor = Cursors.WaitCursor
            If getUser(UsernameTextBox.Text, PasswordTextBox.Text) = True Then
                isUsername = UsernameTextBox.Text
                If CurrUser.isActive = True Then
                    isSales = DBLookUp("sp_ModuleName'" & "Sales" & "','" & UsernameTextBox.Text & "'", "ModuleName")
                    isInventory = DBLookUp("sp_ModuleName'" & "Warehouse" & "','" & UsernameTextBox.Text & "'", "ModuleName")

                    If r1.Checked = True Then

                        isSale = False

                        If isInventory = "Warehouse" Then
                            MainForm.gotoX = 0 ''ready goto Sales
                            isModule = "Warehouse"
                            If isSales = "Sales" Then
                                MainForm.tsGoto.Visible = True
                                MainForm.sepClose.Visible = True
                            Else
                                MainForm.tsGoto.Visible = False
                                MainForm.sepClose.Visible = False
                            End If

                        Else
                            MsgBox("Your are not allow to access this transaction", MsgBoxStyle.Exclamation, "Prompt")
                            Exit Sub
                        End If



                    ElseIf r2.Checked = True Then

                        isSale = True

                        If isSales = "Sales" Then
                            MainForm.gotoX = 1 ''Ready goto Warehouse
                            isModule = "Sales"
                            If isInventory = "Warehouse" Then
                                MainForm.tsGoto.Visible = True
                                MainForm.sepClose.Visible = True
                            Else
                                MainForm.tsGoto.Visible = False
                                MainForm.sepClose.Visible = False
                            End If
                        Else
                            MsgBox("Your are not allow to access this transaction", MsgBoxStyle.Exclamation, "Prompt")
                            Exit Sub
                        End If


                    End If



                    Call UpdateTransactionStatus()

                    MainForm.Show()

                    frmPic.picPhoto.Image = BytesToImage(CurrUser.USER_PHOTO)
                    MainForm.AddMenu()
                    MainForm.tsUser.Text = CurrUser.USER_NAME
                    MainForm.tsCommands.Visible = True
                    frmPic.MdiParent = MainForm
                    frmPic.Show()
                    If r1.Checked = True Then
                        If CurrUser.User_Department = "P&MCD" Then
                            popup("Promt")
                        End If
                    End If

                    Call GetCompany()
                    Me.Close()
                    GC.Collect()
                    Call SaveAuditTrail("User Log In", Version)

                    MainForm.Focus()

                    Dim t As New System.Threading.Thread(AddressOf treadCry)
                    t.Start()

                    Dim thread2 As New System.Threading.Thread(AddressOf CreateTmp)
                    thread2.Start()
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
        If r1.Checked = True Then
            Me.Text = "TOPC - Warehouse System"
        Else
            Me.Text = "TOPC - Sales System"
        End If


        Call HasNewVersion()
        If connectionError = True Then frmSQLConfig.Show() : Me.Close() : Exit Sub
        Call CheckNewVersion()
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

    Private Sub FlowLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub r1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r1.CheckedChanged
        Me.Text = "TOPC - Warehouse System"
    End Sub

    Private Sub r2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r2.CheckedChanged
        Me.Text = "TOPC - Sales System"
    End Sub
#End Region
End Class
