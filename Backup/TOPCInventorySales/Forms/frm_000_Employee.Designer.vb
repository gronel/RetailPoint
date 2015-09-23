<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_000_Employee
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_000_Employee))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboDepartment = New MTGCComboBox
        Me.cboLine = New MTGCComboBox
        Me.cboSection = New MTGCComboBox
        Me.cboEmpStatus = New System.Windows.Forms.ComboBox
        Me.cboDesignation = New System.Windows.Forms.ComboBox
        Me.txtmname = New System.Windows.Forms.TextBox
        Me.txtlname = New System.Windows.Forms.TextBox
        Me.txtfname = New System.Windows.Forms.TextBox
        Me.txtEmpID = New System.Windows.Forms.TextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.picPhoto = New System.Windows.Forms.PictureBox
        Me.chkIsActive = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cboDepartment)
        Me.GroupBox1.Controls.Add(Me.cboLine)
        Me.GroupBox1.Controls.Add(Me.cboSection)
        Me.GroupBox1.Controls.Add(Me.cboEmpStatus)
        Me.GroupBox1.Controls.Add(Me.cboDesignation)
        Me.GroupBox1.Controls.Add(Me.txtmname)
        Me.GroupBox1.Controls.Add(Me.txtlname)
        Me.GroupBox1.Controls.Add(Me.txtfname)
        Me.GroupBox1.Controls.Add(Me.txtEmpID)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.picPhoto)
        Me.GroupBox1.Controls.Add(Me.chkIsActive)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(585, 280)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Profile"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 228)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Line Code*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Department Code*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 201)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Section Code*"
        '
        'cboDepartment
        '
        Me.cboDepartment.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboDepartment.ArrowColor = System.Drawing.Color.Black
        Me.cboDepartment.BindedControl = CType(resources.GetObject("cboDepartment.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboDepartment.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.cboDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartment.ColumnNum = 1
        Me.cboDepartment.ColumnWidth = "121"
        Me.cboDepartment.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboDepartment.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboDepartment.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboDepartment.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboDepartment.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboDepartment.DisplayMember = "Text"
        Me.cboDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDepartment.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboDepartment.DropDownForeColor = System.Drawing.Color.Black
        Me.cboDepartment.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboDepartment.DropDownWidth = 141
        Me.cboDepartment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartment.GridLineColor = System.Drawing.Color.DarkGray
        Me.cboDepartment.GridLineHorizontal = True
        Me.cboDepartment.GridLineVertical = True
        Me.cboDepartment.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboDepartment.Location = New System.Drawing.Point(119, 164)
        Me.cboDepartment.ManagingFastMouseMoving = True
        Me.cboDepartment.ManagingFastMouseMovingInterval = 30
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.SelectedItem = Nothing
        Me.cboDepartment.SelectedValue = Nothing
        Me.cboDepartment.Size = New System.Drawing.Size(228, 22)
        Me.cboDepartment.TabIndex = 93
        '
        'cboLine
        '
        Me.cboLine.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboLine.ArrowColor = System.Drawing.Color.Black
        Me.cboLine.BindedControl = CType(resources.GetObject("cboLine.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboLine.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.cboLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboLine.ColumnNum = 1
        Me.cboLine.ColumnWidth = "121"
        Me.cboLine.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboLine.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboLine.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboLine.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboLine.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboLine.DisplayMember = "Text"
        Me.cboLine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboLine.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboLine.DropDownForeColor = System.Drawing.Color.Black
        Me.cboLine.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboLine.DropDownWidth = 141
        Me.cboLine.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLine.GridLineColor = System.Drawing.Color.DarkGray
        Me.cboLine.GridLineHorizontal = True
        Me.cboLine.GridLineVertical = True
        Me.cboLine.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboLine.Location = New System.Drawing.Point(118, 219)
        Me.cboLine.ManagingFastMouseMoving = True
        Me.cboLine.ManagingFastMouseMovingInterval = 30
        Me.cboLine.Name = "cboLine"
        Me.cboLine.SelectedItem = Nothing
        Me.cboLine.SelectedValue = Nothing
        Me.cboLine.Size = New System.Drawing.Size(228, 22)
        Me.cboLine.TabIndex = 64
        '
        'cboSection
        '
        Me.cboSection.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSection.ArrowColor = System.Drawing.Color.Black
        Me.cboSection.BindedControl = CType(resources.GetObject("cboSection.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboSection.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.cboSection.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSection.ColumnNum = 1
        Me.cboSection.ColumnWidth = "121"
        Me.cboSection.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSection.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSection.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSection.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSection.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSection.DisplayMember = "Text"
        Me.cboSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSection.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSection.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSection.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSection.DropDownWidth = 141
        Me.cboSection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSection.GridLineColor = System.Drawing.Color.DarkGray
        Me.cboSection.GridLineHorizontal = True
        Me.cboSection.GridLineVertical = True
        Me.cboSection.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSection.Location = New System.Drawing.Point(118, 192)
        Me.cboSection.ManagingFastMouseMoving = True
        Me.cboSection.ManagingFastMouseMovingInterval = 30
        Me.cboSection.Name = "cboSection"
        Me.cboSection.SelectedItem = Nothing
        Me.cboSection.SelectedValue = Nothing
        Me.cboSection.Size = New System.Drawing.Size(228, 22)
        Me.cboSection.TabIndex = 63
        '
        'cboEmpStatus
        '
        Me.cboEmpStatus.FormattingEnabled = True
        Me.cboEmpStatus.Location = New System.Drawing.Point(120, 137)
        Me.cboEmpStatus.Name = "cboEmpStatus"
        Me.cboEmpStatus.Size = New System.Drawing.Size(226, 21)
        Me.cboEmpStatus.TabIndex = 92
        '
        'cboDesignation
        '
        Me.cboDesignation.FormattingEnabled = True
        Me.cboDesignation.Location = New System.Drawing.Point(120, 111)
        Me.cboDesignation.Name = "cboDesignation"
        Me.cboDesignation.Size = New System.Drawing.Size(226, 21)
        Me.cboDesignation.TabIndex = 91
        '
        'txtmname
        '
        Me.txtmname.Location = New System.Drawing.Point(119, 87)
        Me.txtmname.Name = "txtmname"
        Me.txtmname.Size = New System.Drawing.Size(227, 20)
        Me.txtmname.TabIndex = 90
        '
        'txtlname
        '
        Me.txtlname.Location = New System.Drawing.Point(119, 61)
        Me.txtlname.Name = "txtlname"
        Me.txtlname.Size = New System.Drawing.Size(228, 20)
        Me.txtlname.TabIndex = 89
        '
        'txtfname
        '
        Me.txtfname.Location = New System.Drawing.Point(118, 36)
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(228, 20)
        Me.txtfname.TabIndex = 88
        '
        'txtEmpID
        '
        Me.txtEmpID.Location = New System.Drawing.Point(118, 12)
        Me.txtEmpID.Name = "txtEmpID"
        Me.txtEmpID.Size = New System.Drawing.Size(120, 20)
        Me.txtEmpID.TabIndex = 87
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(493, 241)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 28)
        Me.btnSave.TabIndex = 84
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBrowse.Location = New System.Drawing.Point(439, 139)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(129, 22)
        Me.btnBrowse.TabIndex = 83
        Me.btnBrowse.Text = "Browse Photo"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'picPhoto
        '
        Me.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPhoto.Location = New System.Drawing.Point(439, 16)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(129, 122)
        Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPhoto.TabIndex = 82
        Me.picPhoto.TabStop = False
        '
        'chkIsActive
        '
        Me.chkIsActive.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Location = New System.Drawing.Point(21, 257)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(56, 17)
        Me.chkIsActive.TabIndex = 80
        Me.chkIsActive.Text = "Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "EmpStatus*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Designation*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Middle Name*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Last Name*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "First Name*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Emp. ID*"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frm_000_Employee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 303)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_000_Employee"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents picPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents cboEmpStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboDesignation As System.Windows.Forms.ComboBox
    Friend WithEvents txtmname As System.Windows.Forms.TextBox
    Friend WithEvents txtlname As System.Windows.Forms.TextBox
    Friend WithEvents txtfname As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboDepartment As MTGCComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboLine As MTGCComboBox
    Friend WithEvents cboSection As MTGCComboBox
End Class
