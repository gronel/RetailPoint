<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.imgOthers = New System.Windows.Forms.ImageList(Me.components)
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.mainStatus = New System.Windows.Forms.StatusStrip()
        Me.lblServer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.tsNew = New System.Windows.Forms.ToolStripButton()
        Me.tsEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.sepDelete = New System.Windows.Forms.ToolStripSeparator()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsCancel = New System.Windows.Forms.ToolStripButton()
        Me.sepSave = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.sepRefresh = New System.Windows.Forms.ToolStripSeparator()
        Me.tsCommands = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsFilterOn = New System.Windows.Forms.ToolStripButton()
        Me.tsFilterClear = New System.Windows.Forms.ToolStripButton()
        Me.tsPreview = New System.Windows.Forms.ToolStripButton()
        Me.tsPrint = New System.Windows.Forms.ToolStripButton()
        Me.sepPrint = New System.Windows.Forms.ToolStripSeparator()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.sepClose = New System.Windows.Forms.ToolStripSeparator()
        Me.tsLogOut = New System.Windows.Forms.ToolStripLabel()
        Me.tsUser = New System.Windows.Forms.ToolStripLabel()
        Me.tsLogged = New System.Windows.Forms.ToolStripLabel()
        Me.picDefault = New System.Windows.Forms.PictureBox()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.mainStatus.SuspendLayout()
        Me.tsCommands.SuspendLayout()
        CType(Me.picDefault, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgOthers
        '
        Me.imgOthers.ImageStream = CType(resources.GetObject("imgOthers.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgOthers.TransparentColor = System.Drawing.Color.Transparent
        Me.imgOthers.Images.SetKeyName(0, "audit.gif")
        Me.imgOthers.Images.SetKeyName(1, "Accounting.png")
        Me.imgOthers.Images.SetKeyName(2, "add.gif")
        Me.imgOthers.Images.SetKeyName(3, "add_reviewer.gif")
        Me.imgOthers.Images.SetKeyName(4, "Application.png")
        Me.imgOthers.Images.SetKeyName(5, "help")
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblStatus.Text = "Ready"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(818, 17)
        Me.ToolStripStatusLabel2.Spring = True
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel1.Text = "  "
        '
        'mainStatus
        '
        Me.mainStatus.BackColor = System.Drawing.SystemColors.Control
        Me.mainStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.ToolStripStatusLabel2, Me.lblServer, Me.ToolStripStatusLabel1})
        Me.mainStatus.Location = New System.Drawing.Point(0, 415)
        Me.mainStatus.Name = "mainStatus"
        Me.mainStatus.Size = New System.Drawing.Size(966, 22)
        Me.mainStatus.TabIndex = 5
        Me.mainStatus.Text = "StatusStrip1"
        '
        'lblServer
        '
        Me.lblServer.Image = Global.Retails.My.Resources.Resources.Computer1
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(81, 17)
        Me.lblServer.Text = "Connected"
        Me.lblServer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "setup")
        Me.imgList.Images.SetKeyName(1, "inquiry")
        Me.imgList.Images.SetKeyName(2, "customer")
        Me.imgList.Images.SetKeyName(3, "user")
        Me.imgList.Images.SetKeyName(4, "supplier")
        Me.imgList.Images.SetKeyName(5, "logout")
        Me.imgList.Images.SetKeyName(6, "help")
        Me.imgList.Images.SetKeyName(7, "Company")
        Me.imgList.Images.SetKeyName(8, "department")
        Me.imgList.Images.SetKeyName(9, "activities")
        Me.imgList.Images.SetKeyName(10, "utility")
        Me.imgList.Images.SetKeyName(11, "order")
        Me.imgList.Images.SetKeyName(12, "delivery")
        Me.imgList.Images.SetKeyName(13, "category")
        Me.imgList.Images.SetKeyName(14, "location")
        Me.imgList.Images.SetKeyName(15, "item")
        '
        'tsNew
        '
        Me.tsNew.AutoSize = False
        Me.tsNew.Enabled = False
        Me.tsNew.Image = Global.Retails.My.Resources.Resources.add
        Me.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNew.Name = "tsNew"
        Me.tsNew.Size = New System.Drawing.Size(50, 33)
        Me.tsNew.Text = "New"
        Me.tsNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsEdit
        '
        Me.tsEdit.AutoSize = False
        Me.tsEdit.Enabled = False
        Me.tsEdit.Image = Global.Retails.My.Resources.Resources.edit2
        Me.tsEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEdit.Name = "tsEdit"
        Me.tsEdit.Size = New System.Drawing.Size(50, 33)
        Me.tsEdit.Text = "Edit"
        Me.tsEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsDelete
        '
        Me.tsDelete.AutoSize = False
        Me.tsDelete.Enabled = False
        Me.tsDelete.Image = Global.Retails.My.Resources.Resources.BD14755_
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(50, 33)
        Me.tsDelete.Text = "Delete"
        Me.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'sepDelete
        '
        Me.sepDelete.Name = "sepDelete"
        Me.sepDelete.Size = New System.Drawing.Size(6, 38)
        '
        'tsSave
        '
        Me.tsSave.AutoSize = False
        Me.tsSave.Enabled = False
        Me.tsSave.Image = Global.Retails.My.Resources.Resources.save
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(50, 33)
        Me.tsSave.Text = "Save"
        Me.tsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsCancel
        '
        Me.tsCancel.AutoSize = False
        Me.tsCancel.Enabled = False
        Me.tsCancel.Image = Global.Retails.My.Resources.Resources.icon_quit
        Me.tsCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCancel.Name = "tsCancel"
        Me.tsCancel.Size = New System.Drawing.Size(50, 33)
        Me.tsCancel.Text = "Cancel"
        Me.tsCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'sepSave
        '
        Me.sepSave.Name = "sepSave"
        Me.sepSave.Size = New System.Drawing.Size(6, 38)
        '
        'tsRefresh
        '
        Me.tsRefresh.AutoSize = False
        Me.tsRefresh.Enabled = False
        Me.tsRefresh.Image = Global.Retails.My.Resources.Resources.Refresh
        Me.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefresh.Name = "tsRefresh"
        Me.tsRefresh.Size = New System.Drawing.Size(50, 33)
        Me.tsRefresh.Text = "Refresh"
        Me.tsRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'sepRefresh
        '
        Me.sepRefresh.Name = "sepRefresh"
        Me.sepRefresh.Size = New System.Drawing.Size(6, 38)
        '
        'tsCommands
        '
        Me.tsCommands.BackColor = System.Drawing.SystemColors.Control
        Me.tsCommands.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsNew, Me.tsEdit, Me.tsDelete, Me.sepDelete, Me.tsSave, Me.tsCancel, Me.sepSave, Me.tsRefresh, Me.ToolStripSeparator1, Me.tsSearch, Me.btnSearch, Me.ToolStripSeparator2, Me.tsFilterOn, Me.tsFilterClear, Me.sepRefresh, Me.tsPreview, Me.tsPrint, Me.sepPrint, Me.tsClose, Me.sepClose, Me.tsLogOut, Me.tsUser, Me.tsLogged})
        Me.tsCommands.Location = New System.Drawing.Point(0, 0)
        Me.tsCommands.Name = "tsCommands"
        Me.tsCommands.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsCommands.Size = New System.Drawing.Size(966, 38)
        Me.tsCommands.TabIndex = 8
        Me.tsCommands.Text = "s"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'tsSearch
        '
        Me.tsSearch.Enabled = False
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(100, 38)
        '
        'btnSearch
        '
        Me.btnSearch.Enabled = False
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(46, 35)
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'tsFilterOn
        '
        Me.tsFilterOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsFilterOn.Enabled = False
        Me.tsFilterOn.Image = Global.Retails.My.Resources.Resources.Filter
        Me.tsFilterOn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFilterOn.Name = "tsFilterOn"
        Me.tsFilterOn.Size = New System.Drawing.Size(23, 35)
        Me.tsFilterOn.Text = "Filter"
        Me.tsFilterOn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsFilterClear
        '
        Me.tsFilterClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsFilterClear.Enabled = False
        Me.tsFilterClear.Image = Global.Retails.My.Resources.Resources.FilterRemove
        Me.tsFilterClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFilterClear.Name = "tsFilterClear"
        Me.tsFilterClear.Size = New System.Drawing.Size(23, 35)
        Me.tsFilterClear.Text = "FilterClear"
        Me.tsFilterClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsPreview
        '
        Me.tsPreview.AutoSize = False
        Me.tsPreview.Enabled = False
        Me.tsPreview.Image = Global.Retails.My.Resources.Resources.report
        Me.tsPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPreview.Name = "tsPreview"
        Me.tsPreview.Size = New System.Drawing.Size(50, 33)
        Me.tsPreview.Text = "Preview"
        Me.tsPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsPrint
        '
        Me.tsPrint.AutoSize = False
        Me.tsPrint.Enabled = False
        Me.tsPrint.Image = Global.Retails.My.Resources.Resources.printer
        Me.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPrint.Name = "tsPrint"
        Me.tsPrint.Size = New System.Drawing.Size(50, 33)
        Me.tsPrint.Text = "Print"
        Me.tsPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'sepPrint
        '
        Me.sepPrint.Name = "sepPrint"
        Me.sepPrint.Size = New System.Drawing.Size(6, 38)
        '
        'tsClose
        '
        Me.tsClose.AutoSize = False
        Me.tsClose.Enabled = False
        Me.tsClose.Image = Global.Retails.My.Resources.Resources._error
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(50, 33)
        Me.tsClose.Text = "Close"
        Me.tsClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'sepClose
        '
        Me.sepClose.Name = "sepClose"
        Me.sepClose.Size = New System.Drawing.Size(6, 38)
        '
        'tsLogOut
        '
        Me.tsLogOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsLogOut.Image = CType(resources.GetObject("tsLogOut.Image"), System.Drawing.Image)
        Me.tsLogOut.IsLink = True
        Me.tsLogOut.Name = "tsLogOut"
        Me.tsLogOut.Size = New System.Drawing.Size(50, 35)
        Me.tsLogOut.Text = "Log Out"
        Me.tsLogOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsUser
        '
        Me.tsUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsUser.Image = CType(resources.GetObject("tsUser.Image"), System.Drawing.Image)
        Me.tsUser.IsLink = True
        Me.tsUser.Name = "tsUser"
        Me.tsUser.Size = New System.Drawing.Size(72, 35)
        Me.tsUser.Text = "My Account"
        Me.tsUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsLogged
        '
        Me.tsLogged.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsLogged.Name = "tsLogged"
        Me.tsLogged.Size = New System.Drawing.Size(77, 35)
        Me.tsLogged.Text = "Logged in as "
        Me.tsLogged.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'picDefault
        '
        Me.picDefault.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picDefault.Image = CType(resources.GetObject("picDefault.Image"), System.Drawing.Image)
        Me.picDefault.Location = New System.Drawing.Point(31, 48)
        Me.picDefault.Name = "picDefault"
        Me.picDefault.Size = New System.Drawing.Size(108, 106)
        Me.picDefault.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDefault.TabIndex = 17
        Me.picDefault.TabStop = False
        Me.picDefault.Visible = False
        '
        'picLogo
        '
        Me.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(145, 48)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(114, 106)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo.TabIndex = 19
        Me.picLogo.TabStop = False
        Me.picLogo.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(966, 437)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.picDefault)
        Me.Controls.Add(Me.tsCommands)
        Me.Controls.Add(Me.mainStatus)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "MainForm"
        Me.Text = "Retails Point"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mainStatus.ResumeLayout(False)
        Me.mainStatus.PerformLayout()
        Me.tsCommands.ResumeLayout(False)
        Me.tsCommands.PerformLayout()
        CType(Me.picDefault, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgOthers As System.Windows.Forms.ImageList
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblServer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mainStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents imgList As System.Windows.Forms.ImageList
    Friend WithEvents tsNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents sepDelete As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents sepSave As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents sepRefresh As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsCommands As System.Windows.Forms.ToolStrip
    Friend WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsLogOut As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsUser As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsLogged As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents sepPrint As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents picDefault As System.Windows.Forms.PictureBox
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sepClose As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsFilterOn As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsFilterClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
