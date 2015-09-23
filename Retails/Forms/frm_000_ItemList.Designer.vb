<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_000_ItemList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_000_ItemList))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cboItemCode = New MTGCComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtItemName = New System.Windows.Forms.TextBox
        Me.txtCategory = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSubCategory = New System.Windows.Forms.TextBox
        Me.dgList = New System.Windows.Forms.DataGridView
        Me.colitemname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSpecificCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTOCCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBrandType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUsage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colActualUOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colConvertedUOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colStockLevel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.picPhoto = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.picLogo = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnback = New System.Windows.Forms.Button
        Me.tsPagination = New System.Windows.Forms.ToolStrip
        Me.tsPageSize = New System.Windows.Forms.ToolStripButton
        Me.tsFirst = New System.Windows.Forms.ToolStripButton
        Me.tsPrev = New System.Windows.Forms.ToolStripButton
        Me.tsPage = New System.Windows.Forms.ToolStripLabel
        Me.tsNext = New System.Windows.Forms.ToolStripButton
        Me.tsLast = New System.Windows.Forms.ToolStripButton
        Me.tsRecordCount = New System.Windows.Forms.ToolStripLabel
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsPagination.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.cboItemCode.Location = New System.Drawing.Point(112, 51)
        Me.cboItemCode.ManagingFastMouseMoving = True
        Me.cboItemCode.ManagingFastMouseMovingInterval = 30
        Me.cboItemCode.Name = "cboItemCode"
        Me.cboItemCode.SelectedItem = Nothing
        Me.cboItemCode.SelectedValue = Nothing
        Me.cboItemCode.Size = New System.Drawing.Size(101, 22)
        Me.cboItemCode.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Item Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Item Name"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.White
        Me.txtItemName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(112, 72)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(371, 21)
        Me.txtItemName.TabIndex = 32
        '
        'txtCategory
        '
        Me.txtCategory.BackColor = System.Drawing.Color.White
        Me.txtCategory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory.Location = New System.Drawing.Point(112, 92)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(371, 21)
        Me.txtCategory.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Item Category"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Item Sub Category"
        '
        'txtSubCategory
        '
        Me.txtSubCategory.BackColor = System.Drawing.Color.White
        Me.txtSubCategory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubCategory.Location = New System.Drawing.Point(112, 112)
        Me.txtSubCategory.Name = "txtSubCategory"
        Me.txtSubCategory.Size = New System.Drawing.Size(371, 21)
        Me.txtSubCategory.TabIndex = 37
        '
        'dgList
        '
        Me.dgList.AllowUserToAddRows = False
        Me.dgList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgList.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colitemname, Me.colSpecificCode, Me.colDescription, Me.colTOCCode, Me.colBrandType, Me.colUsage, Me.colActualUOM, Me.colConvertedUOM, Me.colStockLevel, Me.Column1})
        Me.dgList.Location = New System.Drawing.Point(15, 156)
        Me.dgList.MultiSelect = False
        Me.dgList.Name = "dgList"
        Me.dgList.ReadOnly = True
        Me.dgList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgList.RowHeadersWidth = 25
        Me.dgList.Size = New System.Drawing.Size(832, 295)
        Me.dgList.TabIndex = 39
        '
        'colitemname
        '
        Me.colitemname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colitemname.DataPropertyName = "ItemName"
        Me.colitemname.HeaderText = "Item Name"
        Me.colitemname.MinimumWidth = 100
        Me.colitemname.Name = "colitemname"
        Me.colitemname.ReadOnly = True
        '
        'colSpecificCode
        '
        Me.colSpecificCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSpecificCode.DataPropertyName = "SpecificCode"
        Me.colSpecificCode.HeaderText = "Specific Code"
        Me.colSpecificCode.MinimumWidth = 100
        Me.colSpecificCode.Name = "colSpecificCode"
        Me.colSpecificCode.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescription.DataPropertyName = "SpecificDescription"
        Me.colDescription.HeaderText = "Item Specific Description"
        Me.colDescription.MinimumWidth = 100
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        '
        'colTOCCode
        '
        Me.colTOCCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTOCCode.DataPropertyName = "TOCCode"
        Me.colTOCCode.HeaderText = "TOC Code"
        Me.colTOCCode.MinimumWidth = 100
        Me.colTOCCode.Name = "colTOCCode"
        Me.colTOCCode.ReadOnly = True
        '
        'colBrandType
        '
        Me.colBrandType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colBrandType.DataPropertyName = "BrandType"
        Me.colBrandType.HeaderText = "Brand/Lens Type"
        Me.colBrandType.MinimumWidth = 100
        Me.colBrandType.Name = "colBrandType"
        Me.colBrandType.ReadOnly = True
        '
        'colUsage
        '
        Me.colUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colUsage.DataPropertyName = "Usage"
        Me.colUsage.HeaderText = "Usage"
        Me.colUsage.MinimumWidth = 100
        Me.colUsage.Name = "colUsage"
        Me.colUsage.ReadOnly = True
        '
        'colActualUOM
        '
        Me.colActualUOM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colActualUOM.DataPropertyName = "ActualUOM"
        Me.colActualUOM.HeaderText = "Actual UoM"
        Me.colActualUOM.MinimumWidth = 100
        Me.colActualUOM.Name = "colActualUOM"
        Me.colActualUOM.ReadOnly = True
        '
        'colConvertedUOM
        '
        Me.colConvertedUOM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colConvertedUOM.DataPropertyName = "InventoryUOM"
        Me.colConvertedUOM.HeaderText = "Converted UoM"
        Me.colConvertedUOM.MinimumWidth = 100
        Me.colConvertedUOM.Name = "colConvertedUOM"
        Me.colConvertedUOM.ReadOnly = True
        '
        'colStockLevel
        '
        Me.colStockLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colStockLevel.DataPropertyName = "StockLevelQty"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colStockLevel.DefaultCellStyle = DataGridViewCellStyle2
        Me.colStockLevel.FillWeight = 60.0!
        Me.colStockLevel.HeaderText = "Stock Level"
        Me.colStockLevel.MinimumWidth = 75
        Me.colStockLevel.Name = "colStockLevel"
        Me.colStockLevel.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.DataPropertyName = "RackNo"
        Me.Column1.HeaderText = "Rack No"
        Me.Column1.MinimumWidth = 100
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(746, 140)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(78, 13)
        Me.LinkLabel1.TabIndex = 73
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Show in Large "
        '
        'picPhoto
        '
        Me.picPhoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPhoto.Location = New System.Drawing.Point(718, 42)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(129, 96)
        Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPhoto.TabIndex = 69
        Me.picPhoto.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.picLogo)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(859, 36)
        Me.Panel1.TabIndex = 30
        '
        'picLogo
        '
        Me.picLogo.Location = New System.Drawing.Point(0, 0)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(115, 36)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo.TabIndex = 9
        Me.picLogo.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTitle.Location = New System.Drawing.Point(245, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(238, 33)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Item Master File"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(219, 47)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 23)
        Me.Button1.TabIndex = 170
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(307, 47)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(26, 23)
        Me.btnNext.TabIndex = 168
        Me.btnNext.Text = ">"
        Me.btnNext.UseVisualStyleBackColor = True
        Me.btnNext.Visible = False
        '
        'btnback
        '
        Me.btnback.Location = New System.Drawing.Point(277, 47)
        Me.btnback.Name = "btnback"
        Me.btnback.Size = New System.Drawing.Size(28, 23)
        Me.btnback.TabIndex = 169
        Me.btnback.Text = "<"
        Me.btnback.UseVisualStyleBackColor = True
        Me.btnback.Visible = False
        '
        'tsPagination
        '
        Me.tsPagination.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsPagination.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPageSize, Me.tsFirst, Me.tsPrev, Me.tsPage, Me.tsNext, Me.tsLast, Me.tsRecordCount})
        Me.tsPagination.Location = New System.Drawing.Point(0, 466)
        Me.tsPagination.Name = "tsPagination"
        Me.tsPagination.Size = New System.Drawing.Size(859, 25)
        Me.tsPagination.TabIndex = 171
        Me.tsPagination.Text = "ToolStrip1"
        '
        'tsPageSize
        '
        Me.tsPageSize.Image = Global.Retails.My.Resources.Resources.Wrench
        Me.tsPageSize.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPageSize.Name = "tsPageSize"
        Me.tsPageSize.Size = New System.Drawing.Size(55, 22)
        Me.tsPageSize.Text = "Page:"
        '
        'tsFirst
        '
        Me.tsFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsFirst.Enabled = False
        Me.tsFirst.Image = Global.Retails.My.Resources.Resources.MoveFirst
        Me.tsFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFirst.Name = "tsFirst"
        Me.tsFirst.Size = New System.Drawing.Size(23, 22)
        Me.tsFirst.Text = "First Page"
        '
        'tsPrev
        '
        Me.tsPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsPrev.Enabled = False
        Me.tsPrev.Image = Global.Retails.My.Resources.Resources.MovePrevious
        Me.tsPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPrev.Name = "tsPrev"
        Me.tsPrev.Size = New System.Drawing.Size(23, 22)
        Me.tsPrev.Text = "Previous"
        '
        'tsPage
        '
        Me.tsPage.BackColor = System.Drawing.Color.White
        Me.tsPage.Name = "tsPage"
        Me.tsPage.Size = New System.Drawing.Size(35, 22)
        Me.tsPage.Text = "1 of 1"
        '
        'tsNext
        '
        Me.tsNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsNext.Enabled = False
        Me.tsNext.Image = Global.Retails.My.Resources.Resources.MoveNext
        Me.tsNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNext.Name = "tsNext"
        Me.tsNext.Size = New System.Drawing.Size(23, 22)
        Me.tsNext.Text = "Next Page"
        '
        'tsLast
        '
        Me.tsLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsLast.Enabled = False
        Me.tsLast.Image = Global.Retails.My.Resources.Resources.MoveLast
        Me.tsLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLast.Name = "tsLast"
        Me.tsLast.Size = New System.Drawing.Size(23, 22)
        Me.tsLast.Text = "Last Page"
        '
        'tsRecordCount
        '
        Me.tsRecordCount.Name = "tsRecordCount"
        Me.tsRecordCount.Size = New System.Drawing.Size(78, 22)
        Me.tsRecordCount.Text = "Showing 0 of 0"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ItemName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Item Name"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "SpecificCode"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Specific Code"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "SpecificDescription"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Item Specific Description"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "TOCCode"
        Me.DataGridViewTextBoxColumn4.HeaderText = "TOC Code"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "BrandType"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Brand/Lens Type"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Usage"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Usage"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ActualUOM"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Actual UoM"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "InventoryUOM"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Converted UoM"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "StockLevelQty"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn9.FillWeight = 60.0!
        Me.DataGridViewTextBoxColumn9.HeaderText = "Stock Level"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 75
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "RackNo"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Rack No"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(537, 47)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(129, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 172
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'frm_000_ItemList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 491)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.tsPagination)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnback)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.picPhoto)
        Me.Controls.Add(Me.dgList)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSubCategory)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboItemCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frm_000_ItemList"
        Me.Text = "frm_000_Item"
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsPagination.ResumeLayout(False)
        Me.tsPagination.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboItemCode As MTGCComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSubCategory As System.Windows.Forms.TextBox
    Friend WithEvents dgList As System.Windows.Forms.DataGridView
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents picPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnback As System.Windows.Forms.Button
    Friend WithEvents tsPagination As System.Windows.Forms.ToolStrip
    Friend WithEvents tsPageSize As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRecordCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents colitemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSpecificCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTOCCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBrandType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActualUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConvertedUOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStockLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
