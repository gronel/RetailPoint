Imports System.Data.SqlClient
Imports Retails.clsPublic
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class MainForm

#Region "Variable"
    Dim iUserAccessMode As Integer
    Dim sQry As String
    Dim mnMenu As MenuStrip
    Public gotoX As Integer
    Dim srcCry As New ReportDocument
#End Region

#Region "Procedure"
    Sub AddMenu()

        Dim i As Integer = 0
        Dim Conn As New SqlConnection(cnString)
        Dim comm As New SqlCommand("GetUserMainMenu '" & CurrUser.USER_ID & "'", Conn)
        Dim mnRd As SqlDataReader

        Conn.Open()
        mnRd = comm.ExecuteReader(CommandBehavior.CloseConnection)

        If mnRd.HasRows Then

            mnMenu = New MenuStrip

            While mnRd.Read
                mnMenu.Items.Add(mnRd("MenuText").ToString, imgList.Images(mnRd("ImageName")))
                mnMenu.Items(i).Tag = mnRd("MenuID")


                Me.Controls.Add(mnMenu)
                i = i + 1
            End While

        End If

        mnRd.Close()




        mnMenu.Items.Add("Help", imgOthers.Images("helpx"))
        mnMenu.Items(i).Tag = "767"
        Me.Controls.Add(mnMenu)

        For Each mamenu As ToolStripMenuItem In mnMenu.Items
            AddSub(CInt(mamenu.Tag), mamenu)
        Next
    End Sub

    Sub AddSub(ByVal ParentMenuID As Integer, ByVal sender As Object)

        Dim cms As New ContextMenuStrip()

        Dim sMenu() As String
        Dim sForm() As String
        Dim sImage() As String
        Dim iMenuID() As Integer
        Dim Conn As New SqlConnection(cnString)
        Dim comm As New SqlCommand("GetUserSubMenu  '" & ParentMenuID & "','" & CurrUser.USER_ID & "'", Conn)
        Dim sMenuRD As SqlClient.SqlDataReader

        Conn.Open()

        sMenuRD = comm.ExecuteReader(CommandBehavior.CloseConnection)

        ReDim Preserve sMenu(0)
        ReDim Preserve sForm(0)
        ReDim Preserve sImage(0)
        ReDim Preserve iMenuID(0)

        Dim i As Integer
        If sMenuRD.HasRows Then
            ReDim Preserve sMenu(0)
            i = 0
            While sMenuRD.Read()
                ReDim Preserve sMenu(i)
                ReDim Preserve sForm(i)
                ReDim Preserve sImage(i)
                ReDim Preserve iMenuID(i)
                sMenu(i) = sMenuRD("MenuText")
                sForm(i) = sMenuRD("FormName")
                sImage(i) = sMenuRD("ImageName").ToString
                iMenuID(i) = sMenuRD("MenuID")
                i = i + 1
            End While
        End If
        sMenuRD.Close()

        i = 0

        For Each sMn As String In sMenu
            If Not sMn Is Nothing Then
                cms.Items.Add(sMn, imgList.Images(sImage(i)), _
                    New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = sForm(i)
            End If
            i = i + 1
        Next


        'add Separator and Image path menu
        If CurrUser.USER_ISADMIN = True Then
            If ParentMenuID = 1 Then
                cms.Items.Add("-", Nothing, New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = "-"
                cms.Items.Add("Image Link " & CurrUser.USER_NAME & "...", imgList.Images("img"), New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = "Image Link"
            End If
        End If


        ' add Separator and Log Out Sub Menu
        If ParentMenuID = 1 Then
            cms.Items.Add("-", Nothing, New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = "-"
            cms.Items.Add("Log &Out " & CurrUser.USER_NAME & "...", imgList.Images("logout"), New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = "Logout"
        End If
        ' add Separator and Exit Sub Menu
        If ParentMenuID = 1 Then
            cms.Items.Add("-", Nothing, New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = "-"
            cms.Items.Add("E&xit System", Nothing, New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = "Exit"
        End If

        If ParentMenuID = 766 Then
            cms.Items.Add("&Options", imgList.Images("utility"), New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = "Options"

        End If
        ' add Help Sub Menu
        If ParentMenuID = 767 Then
            cms.Items.Add("&Contents", imgList.Images("help"), New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = "Contents"
            cms.Items.Add("-", Nothing, New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = "-"
            cms.Items.Add("&About", Nothing, New System.EventHandler(AddressOf SelectedChildMenu_OnClick)).Tag = "About"
        End If

        Dim tsi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        tsi.DropDown = cms


    End Sub

    Private Sub SetImageLocation()
        frm_000_ImageLocation.ShowDialog()
    End Sub

    Sub SelectChildMenu(ByVal sender As Object)
        Dim frmName As String = ""
        Dim frmtxtname As String
        Try

            frmName = sender.tag()
            frmtxtname = sender.ToString

            If isFormOpen(frmName) And frmName <> "frmSummary" And frmName <> "frm_POPUP" And frmName <> "frm_200_ReportV" _
            And frmName <> "frm_300_SalesReport" Then
                'And frmName <> "Received Item List" And frmName <> "Withdrawn Item List" _
                '            And frmName <> "frm_200_PRS" And frmName <> "frm_200_JRS" And frmName <> "frm_200_POS" And frmName <> "frm_200_JOS" _
                '            And frmName <> "frm_200_RRI" And frmName <> "frm_200_ISS" Then
                ' do nothing

            ElseIf frmName = "Logout" Then
                LogOutUser()
            ElseIf frmName = "Exit" Then
                Application.Exit()
            ElseIf frmName = "Image Link" Then
                Call SetImageLocation()
            ElseIf frmName = "Options" Then
                MsgBox("wala pa")
            ElseIf frmName = "About" Then
                frmAbout.ShowDialog()
            ElseIf frmName = "frm_000_Company" Then
                frm_000_Company.ShowDialog()
            ElseIf frmName = "frmReport" Then
                'frm_200_ReportV.Text = sender.ToString
                'frm_200_ReportV.Show()

            Else
                frm = ObjectFinder.CreateForm(frmName)

                If frm Is Nothing Then
                    ''MsgBox("Could not find form.", MsgBoxStyle.Exclamation, "Invalid Form")
                Else

                    isReport = sender.ToString

                    With frm
                        .Tag = frmName
                        .MdiParent = Me
                        .StartPosition = FormStartPosition.CenterParent
                        .Show()

                    End With
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="frmName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isFormOpen(ByVal frmName As String) As Boolean
        For Each f As Form In Application.OpenForms
            ' open already so just bring it to the front 
            If f.Tag = frmName Then
                f.BringToFront()
                isFormOpen = True
                Exit For
            End If
        Next
    End Function

    Sub closeme()
        Dim frm As Form = ActiveMdiChild

        Try
            If MdiChildren.Count = 2 Then
                tsClose.Enabled = False

          
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub

    ''' <summary>
    ''' Check popup form if popup data is empty then popup is disable else popup will enable after login
    ''' </summary>
    ''' <remarks></remarks>
  
    Sub runToEnableFalse()
        tsNew.Enabled = False
        tsEdit.Enabled = False
        tsDelete.Enabled = False
        tsSave.Enabled = False
        tsCancel.Enabled = False
        tsRefresh.Enabled = False
        btnSearch.Enabled = False
    End Sub

    Sub LoadForm()
        Dim company As New tbl_000_Company

        Try

            Me.Text = "Retails Point" & " " & Version
            tsCommands.Visible = False

            With company
                .FetchRecord(1)
                picLogo.Image = BytesToImage(.Logo)
            End With



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Load Error")
        End Try
    End Sub

    Sub LogOutUser()
        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Log out") = MsgBoxResult.Yes Then
            For Each frm As Form In Me.MdiChildren
                frm.Close()
                frm.Dispose()
            Next
            With Me
                .tsCommands.Visible = False
                .mnMenu.Dispose()     
                LoginForm.Dispose()
                LoginForm.Show()
                Me.Dispose()

            End With
        End If
    End Sub

    Sub CloseChildForm()
        Dim frm As Form = ActiveMdiChild

        Try

            Call runToEnableFalse()
            If Not frm Is Nothing And frm.Name <> "frmPic" Then

                frm.Close()
                frm.Dispose()
                GC.Collect()

               
            End If
            If MdiChildren.Count < 2 Then
                tsClose.Enabled = False


                tsNew.Enabled = False
                tsEdit.Enabled = False
                tsDelete.Enabled = False
                tsRefresh.Enabled = False
                tsSearch.Enabled = False
                tsFilterOn.Enabled = False
            End If

        Catch ex As Exception


        End Try
    End Sub

    Private Sub CleantxtSearchAria(ByVal button As String)

        If button <> "Search" Or button <> "Filter" Then
            tsSearch.Clear()
        End If

    End Sub

    Private Sub ActionFile(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
        If e.ChangeType = WatcherChangeTypes.Created Then
            'If a new file has been created then action the file by moving it to the correct directory
            'Check that the file is an asf file
            If e.Name.Contains(".asf") Then

                'Get the directory structure for the new file so that we can move it to the correct place
                Dim strDir As String = currPath & "\tmpIMG"
                If strDir <> "" Then

                    If Not Directory.Exists(strDir) Then
                        Directory.CreateDirectory(strDir)
                    End If

                    File.Move(e.FullPath, strDir & "\" & e.Name)
                Else 'A directory for this file has not been created so delete the capture
                    File.Delete(e.FullPath)

                End If

            End If

        End If
    End Sub

    
#End Region

#Region "GUI"
    Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Application.Exit()
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure you want to exit? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit " & Me.Text) = MsgBoxResult.No Then

            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LoadForm()


    End Sub

    Private Sub SelectedChildMenu_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Call SelectChildMenu(sender)
    End Sub

    Private Sub tsClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsClose.Click
        Call CloseChildForm()
    End Sub

    Private Sub tsCommands_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tsCommands.ItemClicked
        Try

            'Call CleantxtSearchAria(e.ClickedItem.ToString)

            If Not Me.ActiveMdiChild Is Nothing Then
                DirectCast(Me.ActiveMdiChild, IBPSCommand).ProcessFormCommand(e.ClickedItem.Text)
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub


    Private Sub tsUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsUser.Click
        frmMyAccount.ShowDialog()

    End Sub

    Private Sub tsLogOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLogOut.Click
        Call LogOutUser()

    End Sub

   
    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If frmPic.Visible Then
            frmPic.Top = 0
            frmPic.Left = frmPic.Parent.DisplayRectangle.Width - frmPic.Width
        End If

        For Each f As Form In Me.MdiChildren
            If f.Name <> "frmPic" And f.Name <> "frmSummary" And f.Name <> "frm_POPUP" And f.Name <> "frm_300_SalesReport" Then
                ResizeForm(f)
            End If
        Next
    End Sub

    Private Sub tsSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsSearch.TextChanged
        Try
            If Not Me.ActiveMdiChild Is Nothing Then
                DirectCast(Me.ActiveMdiChild, IBPS_SEARCH).ProcessSearchData(tsSearch.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub
#End Region

    
End Class



