<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_000_Item
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_000_Item))
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSubCategory = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCategory = New System.Windows.Forms.TextBox
        Me.txtItemName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboItemCode = New MTGCComboBox
        Me.cboCategory = New MTGCComboBox
        Me.cboSubCategory = New MTGCComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTOCCode = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtUsage = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtProductCode = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtBrandType = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboActualUOM = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboInventoryUOM = New System.Windows.Forms.ComboBox
        Me.txtStockLevelQTY = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkIsActive = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chckDefault = New System.Windows.Forms.CheckBox
        Me.cboRack = New System.Windows.Forms.ComboBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboWarehouse = New System.Windows.Forms.ComboBox
        Me.txtSpecificCode = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.picPhoto = New System.Windows.Forms.PictureBox
        Me.txtdefault = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(630, 372)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 28)
        Me.btnSave.TabIndex = 62
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Item Sub Category"
        '
        'txtSubCategory
        '
        Me.txtSubCategory.BackColor = System.Drawing.Color.AliceBlue
        Me.txtSubCategory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubCategory.Location = New System.Drawing.Point(221, 156)
        Me.txtSubCategory.Name = "txtSubCategory"
        Me.txtSubCategory.ReadOnly = True
        Me.txtSubCategory.Size = New System.Drawing.Size(303, 21)
        Me.txtSubCategory.TabIndex = 45
        Me.txtSubCategory.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Item Category"
        '
        'txtCategory
        '
        Me.txtCategory.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCategory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory.Location = New System.Drawing.Point(221, 129)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.ReadOnly = True
        Me.txtCategory.Size = New System.Drawing.Size(303, 21)
        Me.txtCategory.TabIndex = 43
        Me.txtCategory.TabStop = False
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.White
        Me.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(115, 102)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(409, 21)
        Me.txtItemName.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Item Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Item Code"
        '
        'cboItemCode
        '
        Me.cboItemCode.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItemCode.ArrowColor = System.Drawing.Color.Black
        Me.cboItemCode.BindedControl = CType(resources.GetObject("cboItemCode.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboItemCode.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.cboItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboItemCode.ColumnNum = 1
        Me.cboItemCode.ColumnWidth = "121"
        Me.cboItemCode.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboItemCode.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboItemCode.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboItemCode.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboItemCode.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboItemCode.DisplayMember = "Text"
        Me.cboItemCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboItemCode.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboItemCode.DropDownForeColor = System.Drawing.Color.Black
        Me.cboItemCode.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboItemCode.DropDownWidth = 141
        Me.cboItemCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboItemCode.GridLineColor = System.Drawing.Color.DarkGray
        Me.cboItemCode.GridLineHorizontal = True
        Me.cboItemCode.GridLineVertical = True
        Me.cboItemCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboItemCode.Location = New System.Drawing.Point(115, 19)
        Me.cboItemCode.ManagingFastMouseMoving = True
        Me.cboItemCode.ManagingFastMouseMovingInterval = 30
        Me.cboItemCode.MaxLength = 9
        Me.cboItemCode.Name = "cboItemCode"
        Me.cboItemCode.SelectedItem = Nothing
        Me.cboItemCode.SelectedValue = Nothing
        Me.cboItemCode.Size = New System.Drawing.Size(107, 22)
        Me.cboItemCode.TabIndex = 39
        '
        'cboCategory
        '
        Me.cboCategory.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCategory.ArrowColor = System.Drawing.Color.Black
        Me.cboCategory.BackColor = System.Drawing.Color.White
        Me.cboCategory.BindedControl = CType(resources.GetObject("cboCategory.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboCategory.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.cboCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCategory.ColumnNum = 1
        Me.cboCategory.ColumnWidth = "121"
        Me.cboCategory.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCategory.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboCategory.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboCategory.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboCategory.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboCategory.DisplayMember = "Text"
        Me.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboCategory.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboCategory.DropDownForeColor = System.Drawing.Color.Black
        Me.cboCategory.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboCategory.DropDownWidth = 141
        Me.cboCategory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.GridLineColor = System.Drawing.Color.DarkGray
        Me.cboCategory.GridLineHorizontal = True
        Me.cboCategory.GridLineVertical = True
        Me.cboCategory.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboCategory.Location = New System.Drawing.Point(115, 129)
        Me.cboCategory.ManagingFastMouseMoving = True
        Me.cboCategory.ManagingFastMouseMovingInterval = 30
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.SelectedItem = Nothing
        Me.cboCategory.SelectedValue = Nothing
        Me.cboCategory.Size = New System.Drawing.Size(107, 22)
        Me.cboCategory.TabIndex = 47
        '
        'cboSubCategory
        '
        Me.cboSubCategory.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSubCategory.ArrowColor = System.Drawing.Color.Black
        Me.cboSubCategory.BackColor = System.Drawing.Color.White
        Me.cboSubCategory.BindedControl = CType(resources.GetObject("cboSubCategory.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboSubCategory.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.cboSubCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSubCategory.ColumnNum = 1
        Me.cboSubCategory.ColumnWidth = "121"
        Me.cboSubCategory.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSubCategory.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSubCategory.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSubCategory.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSubCategory.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSubCategory.DisplayMember = "Text"
        Me.cboSubCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSubCategory.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSubCategory.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSubCategory.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSubCategory.DropDownWidth = 141
        Me.cboSubCategory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSubCategory.GridLineColor = System.Drawing.Color.DarkGray
        Me.cboSubCategory.GridLineHorizontal = True
        Me.cboSubCategory.GridLineVertical = True
        Me.cboSubCategory.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSubCategory.Location = New System.Drawing.Point(115, 156)
        Me.cboSubCategory.ManagingFastMouseMoving = True
        Me.cboSubCategory.ManagingFastMouseMovingInterval = 30
        Me.cboSubCategory.Name = "cboSubCategory"
        Me.cboSubCategory.SelectedItem = Nothing
        Me.cboSubCategory.SelectedValue = Nothing
        Me.cboSubCategory.Size = New System.Drawing.Size(107, 22)
        Me.cboSubCategory.TabIndex = 48
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Specific Code"
        '
        'txtTOCCode
        '
        Me.txtTOCCode.BackColor = System.Drawing.Color.White
        Me.txtTOCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTOCCode.Location = New System.Drawing.Point(115, 75)
        Me.txtTOCCode.Name = "txtTOCCode"
        Me.txtTOCCode.Size = New System.Drawing.Size(107, 21)
        Me.txtTOCCode.TabIndex = 52
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Specific Description"
        '
        'txtUsage
        '
        Me.txtUsage.BackColor = System.Drawing.Color.White
        Me.txtUsage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsage.Location = New System.Drawing.Point(115, 252)
        Me.txtUsage.Name = "txtUsage"
        Me.txtUsage.Size = New System.Drawing.Size(409, 21)
        Me.txtUsage.TabIndex = 53
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(71, 259)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Usage"
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(115, 183)
        Me.txtDescription.MaxLength = 500
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(409, 36)
        Me.txtDescription.TabIndex = 51
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(52, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "TOC Code"
        '
        'txtProductCode
        '
        Me.txtProductCode.BackColor = System.Drawing.Color.White
        Me.txtProductCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductCode.Location = New System.Drawing.Point(115, 279)
        Me.txtProductCode.MaxLength = 20
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(100, 21)
        Me.txtProductCode.TabIndex = 55
        Me.txtProductCode.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 286)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Product Code"
        Me.Label9.Visible = False
        '
        'txtBrandType
        '
        Me.txtBrandType.BackColor = System.Drawing.Color.White
        Me.txtBrandType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBrandType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrandType.Location = New System.Drawing.Point(115, 226)
        Me.txtBrandType.MaxLength = 50
        Me.txtBrandType.Name = "txtBrandType"
        Me.txtBrandType.Size = New System.Drawing.Size(409, 21)
        Me.txtBrandType.TabIndex = 54
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 233)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Brand/Lens Type"
        '
        'cboActualUOM
        '
        Me.cboActualUOM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboActualUOM.FormattingEnabled = True
        Me.cboActualUOM.Location = New System.Drawing.Point(424, 279)
        Me.cboActualUOM.MaxLength = 10
        Me.cboActualUOM.Name = "cboActualUOM"
        Me.cboActualUOM.Size = New System.Drawing.Size(100, 21)
        Me.cboActualUOM.TabIndex = 56
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(353, 286)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Actual UOM"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(334, 313)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 13)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Converted UOM"
        '
        'cboInventoryUOM
        '
        Me.cboInventoryUOM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInventoryUOM.FormattingEnabled = True
        Me.cboInventoryUOM.Location = New System.Drawing.Point(424, 306)
        Me.cboInventoryUOM.MaxLength = 10
        Me.cboInventoryUOM.Name = "cboInventoryUOM"
        Me.cboInventoryUOM.Size = New System.Drawing.Size(100, 21)
        Me.cboInventoryUOM.TabIndex = 57
        '
        'txtStockLevelQTY
        '
        Me.txtStockLevelQTY.BackColor = System.Drawing.Color.White
        Me.txtStockLevelQTY.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockLevelQTY.Location = New System.Drawing.Point(115, 279)
        Me.txtStockLevelQTY.MaxLength = 10
        Me.txtStockLevelQTY.Name = "txtStockLevelQTY"
        Me.txtStockLevelQTY.Size = New System.Drawing.Size(100, 21)
        Me.txtStockLevelQTY.TabIndex = 58
        Me.txtStockLevelQTY.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 286)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 13)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "Stock Level Qty."
        '
        'chkIsActive
        '
        Me.chkIsActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Location = New System.Drawing.Point(8, 372)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(56, 17)
        Me.chkIsActive.TabIndex = 59
        Me.chkIsActive.Text = "Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chckDefault)
        Me.GroupBox1.Controls.Add(Me.cboRack)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cboWarehouse)
        Me.GroupBox1.Controls.Add(Me.txtSpecificCode)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.picPhoto)
        Me.GroupBox1.Controls.Add(Me.txtItemName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtCategory)
        Me.GroupBox1.Controls.Add(Me.cboInventoryUOM)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtSubCategory)
        Me.GroupBox1.Controls.Add(Me.cboActualUOM)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboCategory)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cboSubCategory)
        Me.GroupBox1.Controls.Add(Me.txtBrandType)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtUsage)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTOCCode)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboItemCode)
        Me.GroupBox1.Controls.Add(Me.txtdefault)
        Me.GroupBox1.Controls.Add(Me.txtStockLevelQTY)
        Me.GroupBox1.Controls.Add(Me.txtProductCode)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(697, 365)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        '
        'chckDefault
        '
        Me.chckDefault.AutoSize = True
        Me.chckDefault.Checked = True
        Me.chckDefault.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chckDefault.Location = New System.Drawing.Point(224, 282)
        Me.chckDefault.Name = "chckDefault"
        Me.chckDefault.Size = New System.Drawing.Size(60, 17)
        Me.chckDefault.TabIndex = 77
        Me.chckDefault.Text = "Default"
        Me.chckDefault.UseVisualStyleBackColor = True
        '
        'cboRack
        '
        Me.cboRack.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRack.FormattingEnabled = True
        Me.cboRack.Location = New System.Drawing.Point(115, 305)
        Me.cboRack.MaxLength = 10
        Me.cboRack.Name = "cboRack"
        Me.cboRack.Size = New System.Drawing.Size(100, 21)
        Me.cboRack.TabIndex = 76
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(221, 306)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(42, 23)
        Me.Button3.TabIndex = 75
        Me.Button3.Text = "Add"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(527, 304)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(42, 23)
        Me.Button2.TabIndex = 74
        Me.Button2.Text = "Add"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(527, 277)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(42, 23)
        Me.Button1.TabIndex = 73
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(56, 309)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Rack No."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(356, 336)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "Warehouse"
        '
        'cboWarehouse
        '
        Me.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWarehouse.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboWarehouse.FormattingEnabled = True
        Me.cboWarehouse.Location = New System.Drawing.Point(424, 333)
        Me.cboWarehouse.MaxLength = 10
        Me.cboWarehouse.Name = "cboWarehouse"
        Me.cboWarehouse.Size = New System.Drawing.Size(100, 21)
        Me.cboWarehouse.TabIndex = 69
        '
        'txtSpecificCode
        '
        Me.txtSpecificCode.Location = New System.Drawing.Point(115, 47)
        Me.txtSpecificCode.MaxLength = 14
        Me.txtSpecificCode.Name = "txtSpecificCode"
        Me.txtSpecificCode.Size = New System.Drawing.Size(107, 20)
        Me.txtSpecificCode.TabIndex = 49
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBrowse.Location = New System.Drawing.Point(543, 170)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(129, 22)
        Me.btnBrowse.TabIndex = 61
        Me.btnBrowse.Text = "Browse Photo"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'picPhoto
        '
        Me.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPhoto.Location = New System.Drawing.Point(543, 47)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(129, 122)
        Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPhoto.TabIndex = 68
        Me.picPhoto.TabStop = False
        '
        'txtdefault
        '
        Me.txtdefault.BackColor = System.Drawing.Color.AliceBlue
        Me.txtdefault.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdefault.Location = New System.Drawing.Point(115, 279)
        Me.txtdefault.MaxLength = 10
        Me.txtdefault.Name = "txtdefault"
        Me.txtdefault.Size = New System.Drawing.Size(100, 21)
        Me.txtdefault.TabIndex = 78
        Me.txtdefault.Text = "N/A"
        '
        'frm_000_Item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(714, 412)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.chkIsActive)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_000_Item"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Entry Form"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSubCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboItemCode As MTGCComboBox
    Friend WithEvents cboCategory As MTGCComboBox
    Friend WithEvents cboSubCategory As MTGCComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTOCCode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUsage As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBrandType As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboActualUOM As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboInventoryUOM As System.Windows.Forms.ComboBox
    Friend WithEvents txtStockLevelQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents picPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents txtSpecificCode As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboWarehouse As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cboRack As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chckDefault As System.Windows.Forms.CheckBox
    Friend WithEvents txtdefault As System.Windows.Forms.TextBox
End Class
