<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSummary))
        Me.listreport = New System.Windows.Forms.ListBox
        Me.mtg2 = New MTGCComboBox
        Me.cbo4 = New System.Windows.Forms.ComboBox
        Me.cbo3 = New System.Windows.Forms.ComboBox
        Me.mtg3 = New MTGCComboBox
        Me.mtg1 = New MTGCComboBox
        Me.dtp1 = New System.Windows.Forms.DateTimePicker
        Me.cbo2 = New System.Windows.Forms.ComboBox
        Me.dtp2 = New System.Windows.Forms.DateTimePicker
        Me.txt1 = New System.Windows.Forms.TextBox
        Me.cbo1 = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.txt2 = New System.Windows.Forms.TextBox
        Me.lbl1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txt3 = New System.Windows.Forms.TextBox
        Me.lbl2 = New System.Windows.Forms.Label
        Me.lbl3 = New System.Windows.Forms.Label
        Me.txt4 = New System.Windows.Forms.TextBox
        Me.lbl4 = New System.Windows.Forms.Label
        Me.mtg4 = New MTGCComboBox
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.mtg5 = New MTGCComboBox
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lbl5 = New System.Windows.Forms.Label
        Me.mtg6 = New MTGCComboBox
        Me.lbl6 = New System.Windows.Forms.Label
        Me.grp1.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'listreport
        '
        Me.listreport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listreport.FormattingEnabled = True
        Me.listreport.Location = New System.Drawing.Point(12, 12)
        Me.listreport.Name = "listreport"
        Me.listreport.Size = New System.Drawing.Size(259, 264)
        Me.listreport.TabIndex = 1
        '
        'mtg2
        '
        Me.mtg2.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg2.ArrowColor = System.Drawing.Color.Black
        Me.mtg2.BindedControl = CType(resources.GetObject("mtg2.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.mtg2.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.mtg2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.mtg2.ColumnNum = 1
        Me.mtg2.ColumnWidth = "121"
        Me.mtg2.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg2.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.mtg2.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.mtg2.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.mtg2.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.mtg2.DisplayMember = "Text"
        Me.mtg2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.mtg2.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.mtg2.DropDownForeColor = System.Drawing.Color.Black
        Me.mtg2.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.mtg2.DropDownWidth = 141
        Me.mtg2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtg2.GridLineColor = System.Drawing.Color.DarkGray
        Me.mtg2.GridLineHorizontal = True
        Me.mtg2.GridLineVertical = True
        Me.mtg2.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.mtg2.Location = New System.Drawing.Point(105, 57)
        Me.mtg2.ManagingFastMouseMoving = True
        Me.mtg2.ManagingFastMouseMovingInterval = 30
        Me.mtg2.Name = "mtg2"
        Me.mtg2.SelectedItem = Nothing
        Me.mtg2.SelectedValue = Nothing
        Me.mtg2.Size = New System.Drawing.Size(147, 22)
        Me.mtg2.TabIndex = 17
        Me.mtg2.Visible = False
        '
        'cbo4
        '
        Me.cbo4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo4.FormattingEnabled = True
        Me.cbo4.Location = New System.Drawing.Point(105, 111)
        Me.cbo4.Name = "cbo4"
        Me.cbo4.Size = New System.Drawing.Size(147, 21)
        Me.cbo4.TabIndex = 11
        Me.cbo4.Visible = False
        '
        'cbo3
        '
        Me.cbo3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo3.FormattingEnabled = True
        Me.cbo3.Location = New System.Drawing.Point(105, 84)
        Me.cbo3.Name = "cbo3"
        Me.cbo3.Size = New System.Drawing.Size(147, 21)
        Me.cbo3.TabIndex = 9
        Me.cbo3.Visible = False
        '
        'mtg3
        '
        Me.mtg3.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg3.ArrowColor = System.Drawing.Color.Black
        Me.mtg3.BindedControl = CType(resources.GetObject("mtg3.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.mtg3.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.mtg3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.mtg3.ColumnNum = 1
        Me.mtg3.ColumnWidth = "121"
        Me.mtg3.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg3.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.mtg3.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.mtg3.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.mtg3.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.mtg3.DisplayMember = "Text"
        Me.mtg3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.mtg3.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.mtg3.DropDownForeColor = System.Drawing.Color.Black
        Me.mtg3.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.mtg3.DropDownWidth = 141
        Me.mtg3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtg3.GridLineColor = System.Drawing.Color.DarkGray
        Me.mtg3.GridLineHorizontal = True
        Me.mtg3.GridLineVertical = True
        Me.mtg3.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.mtg3.Location = New System.Drawing.Point(104, 82)
        Me.mtg3.ManagingFastMouseMoving = True
        Me.mtg3.ManagingFastMouseMovingInterval = 30
        Me.mtg3.Name = "mtg3"
        Me.mtg3.SelectedItem = Nothing
        Me.mtg3.SelectedValue = Nothing
        Me.mtg3.Size = New System.Drawing.Size(147, 22)
        Me.mtg3.TabIndex = 18
        Me.mtg3.Visible = False
        '
        'mtg1
        '
        Me.mtg1.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg1.ArrowColor = System.Drawing.Color.Black
        Me.mtg1.BindedControl = CType(resources.GetObject("mtg1.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.mtg1.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.mtg1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.mtg1.ColumnNum = 1
        Me.mtg1.ColumnWidth = "121"
        Me.mtg1.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg1.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.mtg1.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.mtg1.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.mtg1.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.mtg1.DisplayMember = "Text"
        Me.mtg1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.mtg1.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.mtg1.DropDownForeColor = System.Drawing.Color.Black
        Me.mtg1.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.mtg1.DropDownWidth = 141
        Me.mtg1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtg1.GridLineColor = System.Drawing.Color.DarkGray
        Me.mtg1.GridLineHorizontal = True
        Me.mtg1.GridLineVertical = True
        Me.mtg1.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.mtg1.Location = New System.Drawing.Point(105, 31)
        Me.mtg1.ManagingFastMouseMoving = True
        Me.mtg1.ManagingFastMouseMovingInterval = 30
        Me.mtg1.Name = "mtg1"
        Me.mtg1.SelectedItem = Nothing
        Me.mtg1.SelectedValue = Nothing
        Me.mtg1.Size = New System.Drawing.Size(147, 22)
        Me.mtg1.TabIndex = 14
        Me.mtg1.Visible = False
        '
        'dtp1
        '
        Me.dtp1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp1.CustomFormat = "MM-dd-yyyy"
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(105, 31)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(147, 20)
        Me.dtp1.TabIndex = 12
        Me.dtp1.Visible = False
        '
        'cbo2
        '
        Me.cbo2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo2.FormattingEnabled = True
        Me.cbo2.Location = New System.Drawing.Point(105, 57)
        Me.cbo2.Name = "cbo2"
        Me.cbo2.Size = New System.Drawing.Size(147, 21)
        Me.cbo2.TabIndex = 7
        Me.cbo2.Visible = False
        '
        'dtp2
        '
        Me.dtp2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp2.CustomFormat = "MM-dd-yyyy"
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(105, 58)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(147, 20)
        Me.dtp2.TabIndex = 13
        Me.dtp2.Visible = False
        '
        'txt1
        '
        Me.txt1.Location = New System.Drawing.Point(105, 30)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(147, 20)
        Me.txt1.TabIndex = 15
        Me.txt1.Visible = False
        '
        'cbo1
        '
        Me.cbo1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo1.FormattingEnabled = True
        Me.cbo1.Location = New System.Drawing.Point(105, 30)
        Me.cbo1.Name = "cbo1"
        Me.cbo1.Size = New System.Drawing.Size(147, 21)
        Me.cbo1.TabIndex = 5
        Me.cbo1.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Image = Global.Retails.My.Resources.Resources.print
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(104, 204)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 27)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Print"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txt2
        '
        Me.txt2.Location = New System.Drawing.Point(105, 57)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(147, 20)
        Me.txt2.TabIndex = 16
        Me.txt2.Visible = False
        '
        'lbl1
        '
        Me.lbl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(6, 33)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(39, 13)
        Me.lbl1.TabIndex = 4
        Me.lbl1.Text = "Label1"
        Me.lbl1.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.Image = Global.Retails.My.Resources.Resources.preview
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(184, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 27)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Preview"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt3
        '
        Me.txt3.Location = New System.Drawing.Point(105, 83)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(147, 20)
        Me.txt3.TabIndex = 16
        Me.txt3.Visible = False
        '
        'lbl2
        '
        Me.lbl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl2.AutoSize = True
        Me.lbl2.Location = New System.Drawing.Point(6, 60)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(39, 13)
        Me.lbl2.TabIndex = 6
        Me.lbl2.Text = "Label2"
        Me.lbl2.Visible = False
        '
        'lbl3
        '
        Me.lbl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl3.AutoSize = True
        Me.lbl3.Location = New System.Drawing.Point(6, 87)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(39, 13)
        Me.lbl3.TabIndex = 8
        Me.lbl3.Text = "Label3"
        Me.lbl3.Visible = False
        '
        'txt4
        '
        Me.txt4.Location = New System.Drawing.Point(105, 111)
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(147, 20)
        Me.txt4.TabIndex = 16
        Me.txt4.Visible = False
        '
        'lbl4
        '
        Me.lbl4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl4.AutoSize = True
        Me.lbl4.Location = New System.Drawing.Point(6, 114)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(39, 13)
        Me.lbl4.TabIndex = 10
        Me.lbl4.Text = "Label4"
        Me.lbl4.Visible = False
        '
        'mtg4
        '
        Me.mtg4.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg4.ArrowColor = System.Drawing.Color.Black
        Me.mtg4.BindedControl = CType(resources.GetObject("mtg4.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.mtg4.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.mtg4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.mtg4.ColumnNum = 1
        Me.mtg4.ColumnWidth = "121"
        Me.mtg4.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg4.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.mtg4.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.mtg4.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.mtg4.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.mtg4.DisplayMember = "Text"
        Me.mtg4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.mtg4.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.mtg4.DropDownForeColor = System.Drawing.Color.Black
        Me.mtg4.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.mtg4.DropDownWidth = 141
        Me.mtg4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtg4.GridLineColor = System.Drawing.Color.DarkGray
        Me.mtg4.GridLineHorizontal = True
        Me.mtg4.GridLineVertical = True
        Me.mtg4.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.mtg4.Location = New System.Drawing.Point(104, 111)
        Me.mtg4.ManagingFastMouseMoving = True
        Me.mtg4.ManagingFastMouseMovingInterval = 30
        Me.mtg4.Name = "mtg4"
        Me.mtg4.SelectedItem = Nothing
        Me.mtg4.SelectedValue = Nothing
        Me.mtg4.Size = New System.Drawing.Size(147, 22)
        Me.mtg4.TabIndex = 18
        Me.mtg4.Visible = False
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.lbl6)
        Me.grp1.Controls.Add(Me.mtg6)
        Me.grp1.Controls.Add(Me.lbl5)
        Me.grp1.Controls.Add(Me.mtg5)
        Me.grp1.Controls.Add(Me.mtg4)
        Me.grp1.Controls.Add(Me.lbl4)
        Me.grp1.Controls.Add(Me.txt4)
        Me.grp1.Controls.Add(Me.lbl3)
        Me.grp1.Controls.Add(Me.lbl2)
        Me.grp1.Controls.Add(Me.txt3)
        Me.grp1.Controls.Add(Me.Button1)
        Me.grp1.Controls.Add(Me.lbl1)
        Me.grp1.Controls.Add(Me.txt2)
        Me.grp1.Controls.Add(Me.Button2)
        Me.grp1.Controls.Add(Me.cbo1)
        Me.grp1.Controls.Add(Me.txt1)
        Me.grp1.Controls.Add(Me.dtp2)
        Me.grp1.Controls.Add(Me.cbo2)
        Me.grp1.Controls.Add(Me.dtp1)
        Me.grp1.Controls.Add(Me.mtg1)
        Me.grp1.Controls.Add(Me.mtg3)
        Me.grp1.Controls.Add(Me.cbo3)
        Me.grp1.Controls.Add(Me.cbo4)
        Me.grp1.Controls.Add(Me.mtg2)
        Me.grp1.Location = New System.Drawing.Point(287, 12)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(298, 264)
        Me.grp1.TabIndex = 6
        Me.grp1.TabStop = False
        '
        'mtg5
        '
        Me.mtg5.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg5.ArrowColor = System.Drawing.Color.Black
        Me.mtg5.BindedControl = CType(resources.GetObject("mtg5.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.mtg5.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.mtg5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.mtg5.ColumnNum = 1
        Me.mtg5.ColumnWidth = "121"
        Me.mtg5.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg5.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.mtg5.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.mtg5.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.mtg5.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.mtg5.DisplayMember = "Text"
        Me.mtg5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.mtg5.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.mtg5.DropDownForeColor = System.Drawing.Color.Black
        Me.mtg5.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.mtg5.DropDownWidth = 141
        Me.mtg5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtg5.GridLineColor = System.Drawing.Color.DarkGray
        Me.mtg5.GridLineHorizontal = True
        Me.mtg5.GridLineVertical = True
        Me.mtg5.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.mtg5.Location = New System.Drawing.Point(104, 139)
        Me.mtg5.ManagingFastMouseMoving = True
        Me.mtg5.ManagingFastMouseMovingInterval = 30
        Me.mtg5.Name = "mtg5"
        Me.mtg5.SelectedItem = Nothing
        Me.mtg5.SelectedValue = Nothing
        Me.mtg5.Size = New System.Drawing.Size(147, 22)
        Me.mtg5.TabIndex = 19
        Me.mtg5.Visible = False
        '
        'ErrorP
        '
        Me.ErrorP.ContainerControl = Me
        '
        'lbl5
        '
        Me.lbl5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl5.AutoSize = True
        Me.lbl5.Location = New System.Drawing.Point(6, 141)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(39, 13)
        Me.lbl5.TabIndex = 20
        Me.lbl5.Text = "Label4"
        Me.lbl5.Visible = False
        '
        'mtg6
        '
        Me.mtg6.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg6.ArrowColor = System.Drawing.Color.Black
        Me.mtg6.BindedControl = CType(resources.GetObject("mtg6.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.mtg6.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.mtg6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.mtg6.ColumnNum = 1
        Me.mtg6.ColumnWidth = "121"
        Me.mtg6.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.mtg6.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.mtg6.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.mtg6.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.mtg6.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.mtg6.DisplayMember = "Text"
        Me.mtg6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.mtg6.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.mtg6.DropDownForeColor = System.Drawing.Color.Black
        Me.mtg6.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.mtg6.DropDownWidth = 141
        Me.mtg6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtg6.GridLineColor = System.Drawing.Color.DarkGray
        Me.mtg6.GridLineHorizontal = True
        Me.mtg6.GridLineVertical = True
        Me.mtg6.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.mtg6.Location = New System.Drawing.Point(104, 167)
        Me.mtg6.ManagingFastMouseMoving = True
        Me.mtg6.ManagingFastMouseMovingInterval = 30
        Me.mtg6.Name = "mtg6"
        Me.mtg6.SelectedItem = Nothing
        Me.mtg6.SelectedValue = Nothing
        Me.mtg6.Size = New System.Drawing.Size(147, 22)
        Me.mtg6.TabIndex = 21
        Me.mtg6.Visible = False
        '
        'lbl6
        '
        Me.lbl6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl6.AutoSize = True
        Me.lbl6.Location = New System.Drawing.Point(6, 171)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Size = New System.Drawing.Size(39, 13)
        Me.lbl6.TabIndex = 22
        Me.lbl6.Text = "Label4"
        Me.lbl6.Visible = False
        '
        'frmSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 294)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.listreport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents listreport As System.Windows.Forms.ListBox
    Friend WithEvents mtg2 As MTGCComboBox
    Friend WithEvents cbo4 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo3 As System.Windows.Forms.ComboBox
    Friend WithEvents mtg3 As MTGCComboBox
    Friend WithEvents mtg1 As MTGCComboBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo2 As System.Windows.Forms.ComboBox
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents cbo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents txt4 As System.Windows.Forms.TextBox
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Friend WithEvents mtg4 As MTGCComboBox
    Friend WithEvents grp1 As System.Windows.Forms.GroupBox
    Friend WithEvents mtg5 As MTGCComboBox
    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents mtg6 As MTGCComboBox
    Friend WithEvents lbl5 As System.Windows.Forms.Label

End Class
