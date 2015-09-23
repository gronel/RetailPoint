<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_100_JR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_100_JR))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cborequested = New System.Windows.Forms.ComboBox
        Me.cboApproved = New System.Windows.Forms.ComboBox
        Me.cboChecked = New System.Windows.Forms.ComboBox
        Me.cbodec = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboCurrency = New MTGCComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.btncopy = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblcurrency = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblCountSub = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.dgDetails = New System.Windows.Forms.DataGridView
        Me.colSpecificCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBtnAdd = New System.Windows.Forms.DataGridViewButtonColumn
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTOCCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBrandType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colService = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colReqQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colActualUnit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colActualPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLastService = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPrepared = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSupplier = New System.Windows.Forms.TextBox
        Me.cboSupplier = New MTGCComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblPlacement = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboPRType = New System.Windows.Forms.ComboBox
        Me.dtPOSchedule = New System.Windows.Forms.DateTimePicker
        Me.dtDateNeeded = New System.Windows.Forms.DateTimePicker
        Me.dtDateRequested = New System.Windows.Forms.DateTimePicker
        Me.txtSupplierType = New System.Windows.Forms.TextBox
        Me.txtLine = New System.Windows.Forms.TextBox
        Me.cboLine = New MTGCComboBox
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.txtSection = New System.Windows.Forms.TextBox
        Me.cboDepartment = New MTGCComboBox
        Me.cboSection = New MTGCComboBox
        Me.txtJRNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblTitle = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cborequested)
        Me.GroupBox1.Controls.Add(Me.cboApproved)
        Me.GroupBox1.Controls.Add(Me.cboChecked)
        Me.GroupBox1.Controls.Add(Me.cbodec)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cboCurrency)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.btncopy)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtPrepared)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtSupplier)
        Me.GroupBox1.Controls.Add(Me.cboSupplier)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblPlacement)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboPRType)
        Me.GroupBox1.Controls.Add(Me.dtPOSchedule)
        Me.GroupBox1.Controls.Add(Me.dtDateNeeded)
        Me.GroupBox1.Controls.Add(Me.dtDateRequested)
        Me.GroupBox1.Controls.Add(Me.txtSupplierType)
        Me.GroupBox1.Controls.Add(Me.txtLine)
        Me.GroupBox1.Controls.Add(Me.cboLine)
        Me.GroupBox1.Controls.Add(Me.txtDepartment)
        Me.GroupBox1.Controls.Add(Me.txtSection)
        Me.GroupBox1.Controls.Add(Me.cboDepartment)
        Me.GroupBox1.Controls.Add(Me.cboSection)
        Me.GroupBox1.Controls.Add(Me.txtJRNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1018, 423)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cborequested
        '
        Me.cborequested.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cborequested.FormattingEnabled = True
        Me.cborequested.Location = New System.Drawing.Point(86, 393)
        Me.cborequested.Name = "cborequested"
        Me.cborequested.Size = New System.Drawing.Size(193, 21)
        Me.cborequested.TabIndex = 115
        '
        'cboApproved
        '
        Me.cboApproved.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboApproved.FormattingEnabled = True
        Me.cboApproved.Location = New System.Drawing.Point(804, 392)
        Me.cboApproved.Name = "cboApproved"
        Me.cboApproved.Size = New System.Drawing.Size(193, 21)
        Me.cboApproved.TabIndex = 114
        '
        'cboChecked
        '
        Me.cboChecked.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboChecked.FormattingEnabled = True
        Me.cboChecked.Location = New System.Drawing.Point(804, 364)
        Me.cboChecked.Name = "cboChecked"
        Me.cboChecked.Size = New System.Drawing.Size(193, 21)
        Me.cboChecked.TabIndex = 113
        '
        'cbodec
        '
        Me.cbodec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbodec.FormattingEnabled = True
        Me.cbodec.Items.AddRange(New Object() {"2", "3", "4", "5", "6"})
        Me.cbodec.Location = New System.Drawing.Point(897, 107)
        Me.cbodec.Name = "cbodec"
        Me.cbodec.Size = New System.Drawing.Size(100, 21)
        Me.cbodec.TabIndex = 112
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(811, 108)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 13)
        Me.Label17.TabIndex = 108
        Me.Label17.Text = "Decimal Places"
        '
        'cboCurrency
        '
        Me.cboCurrency.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCurrency.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCurrency.ArrowColor = System.Drawing.Color.Black
        Me.cboCurrency.BindedControl = CType(resources.GetObject("cboCurrency.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboCurrency.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.cboCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCurrency.ColumnNum = 1
        Me.cboCurrency.ColumnWidth = "121"
        Me.cboCurrency.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboCurrency.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboCurrency.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboCurrency.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboCurrency.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboCurrency.DisplayMember = "Text"
        Me.cboCurrency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboCurrency.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboCurrency.DropDownForeColor = System.Drawing.Color.Black
        Me.cboCurrency.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboCurrency.DropDownWidth = 141
        Me.cboCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCurrency.GridLineColor = System.Drawing.Color.DarkGray
        Me.cboCurrency.GridLineHorizontal = True
        Me.cboCurrency.GridLineVertical = True
        Me.cboCurrency.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboCurrency.Location = New System.Drawing.Point(897, 86)
        Me.cboCurrency.ManagingFastMouseMoving = True
        Me.cboCurrency.ManagingFastMouseMovingInterval = 30
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.SelectedItem = Nothing
        Me.cboCurrency.SelectedValue = Nothing
        Me.cboCurrency.Size = New System.Drawing.Size(100, 22)
        Me.cboCurrency.TabIndex = 106
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(813, 92)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 13)
        Me.Label18.TabIndex = 105
        Me.Label18.Text = "Currency Type"
        '
        'btncopy
        '
        Me.btncopy.Location = New System.Drawing.Point(194, 9)
        Me.btncopy.Name = "btncopy"
        Me.btncopy.Size = New System.Drawing.Size(56, 23)
        Me.btncopy.TabIndex = 103
        Me.btncopy.Text = "Copy"
        Me.btncopy.UseVisualStyleBackColor = True
        Me.btncopy.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 337)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemarks.Location = New System.Drawing.Point(86, 334)
        Me.txtRemarks.MaxLength = 100
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(911, 20)
        Me.txtRemarks.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(731, 393)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 84
        Me.Label13.Text = "Approved by"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(734, 372)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 13)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "Checked by"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblcurrency)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtTotalAmount)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.dgDetails)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(997, 184)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Details"
        '
        'lblcurrency
        '
        Me.lblcurrency.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcurrency.AutoSize = True
        Me.lblcurrency.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblcurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcurrency.ForeColor = System.Drawing.Color.Red
        Me.lblcurrency.Location = New System.Drawing.Point(796, 158)
        Me.lblcurrency.Name = "lblcurrency"
        Me.lblcurrency.Size = New System.Drawing.Size(0, 16)
        Me.lblcurrency.TabIndex = 87
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(684, 157)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 16)
        Me.Label15.TabIndex = 74
        Me.Label15.Text = "Total Amount: "
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAmount.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.ForeColor = System.Drawing.Color.Red
        Me.txtTotalAmount.Location = New System.Drawing.Point(794, 154)
        Me.txtTotalAmount.MaxLength = 20
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(193, 22)
        Me.txtTotalAmount.TabIndex = 73
        Me.txtTotalAmount.TabStop = False
        Me.txtTotalAmount.Text = "0.00"
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblCountSub)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Location = New System.Drawing.Point(6, 153)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(142, 22)
        Me.Panel2.TabIndex = 72
        '
        'lblCountSub
        '
        Me.lblCountSub.AutoSize = True
        Me.lblCountSub.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCountSub.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountSub.Location = New System.Drawing.Point(86, 4)
        Me.lblCountSub.Name = "lblCountSub"
        Me.lblCountSub.Size = New System.Drawing.Size(16, 16)
        Me.lblCountSub.TabIndex = 1
        Me.lblCountSub.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "No. of Records:"
        '
        'dgDetails
        '
        Me.dgDetails.AllowUserToResizeRows = False
        Me.dgDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDetails.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSpecificCode, Me.colBtnAdd, Me.colItemCode, Me.colTOCCode, Me.colDescription, Me.colBrandType, Me.colService, Me.colReqQty, Me.colActualUnit, Me.colActualPrice, Me.colAmount, Me.colLastService})
        Me.dgDetails.Location = New System.Drawing.Point(11, 19)
        Me.dgDetails.MultiSelect = False
        Me.dgDetails.Name = "dgDetails"
        Me.dgDetails.RowHeadersWidth = 25
        Me.dgDetails.Size = New System.Drawing.Size(976, 133)
        Me.dgDetails.TabIndex = 9
        '
        'colSpecificCode
        '
        Me.colSpecificCode.HeaderText = "Specific Item Code"
        Me.colSpecificCode.MinimumWidth = 100
        Me.colSpecificCode.Name = "colSpecificCode"
        Me.colSpecificCode.Width = 120
        '
        'colBtnAdd
        '
        Me.colBtnAdd.HeaderText = ""
        Me.colBtnAdd.Name = "colBtnAdd"
        Me.colBtnAdd.Text = "..."
        Me.colBtnAdd.UseColumnTextForButtonValue = True
        Me.colBtnAdd.Width = 25
        '
        'colItemCode
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle1
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.MinimumWidth = 100
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Visible = False
        '
        'colTOCCode
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colTOCCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTOCCode.HeaderText = "TOC Code"
        Me.colTOCCode.MinimumWidth = 100
        Me.colTOCCode.Name = "colTOCCode"
        Me.colTOCCode.ReadOnly = True
        '
        'colDescription
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colDescription.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDescription.HeaderText = "Item Specific Description"
        Me.colDescription.MinimumWidth = 120
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Width = 120
        '
        'colBrandType
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colBrandType.DefaultCellStyle = DataGridViewCellStyle4
        Me.colBrandType.HeaderText = "Brand/Lens Type"
        Me.colBrandType.MinimumWidth = 130
        Me.colBrandType.Name = "colBrandType"
        Me.colBrandType.ReadOnly = True
        Me.colBrandType.Width = 130
        '
        'colService
        '
        Me.colService.HeaderText = "Kind of Service"
        Me.colService.MinimumWidth = 100
        Me.colService.Name = "colService"
        '
        'colReqQty
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colReqQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.colReqQty.HeaderText = "Requested Quantity"
        Me.colReqQty.MinimumWidth = 100
        Me.colReqQty.Name = "colReqQty"
        '
        'colActualUnit
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colActualUnit.DefaultCellStyle = DataGridViewCellStyle6
        Me.colActualUnit.HeaderText = "Actual Unit"
        Me.colActualUnit.MinimumWidth = 100
        Me.colActualUnit.Name = "colActualUnit"
        Me.colActualUnit.ReadOnly = True
        '
        'colActualPrice
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0.00"
        Me.colActualPrice.DefaultCellStyle = DataGridViewCellStyle7
        Me.colActualPrice.HeaderText = "Actual Unit Price"
        Me.colActualPrice.MinimumWidth = 100
        Me.colActualPrice.Name = "colActualPrice"
        '
        'colAmount
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0.00"
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle8
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.MinimumWidth = 100
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        '
        'colLastService
        '
        Me.colLastService.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colLastService.DefaultCellStyle = DataGridViewCellStyle9
        Me.colLastService.HeaderText = "Date of Last Service"
        Me.colLastService.MinimumWidth = 100
        Me.colLastService.Name = "colLastService"
        Me.colLastService.ReadOnly = True
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 393)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Requested by"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 372)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "Prepared by"
        '
        'txtPrepared
        '
        Me.txtPrepared.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPrepared.BackColor = System.Drawing.Color.LightGray
        Me.txtPrepared.Location = New System.Drawing.Point(86, 369)
        Me.txtPrepared.Name = "txtPrepared"
        Me.txtPrepared.ReadOnly = True
        Me.txtPrepared.Size = New System.Drawing.Size(193, 20)
        Me.txtPrepared.TabIndex = 72
        Me.txtPrepared.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 95)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "Supplier"
        '
        'txtSupplier
        '
        Me.txtSupplier.BackColor = System.Drawing.Color.LightGray
        Me.txtSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplier.Location = New System.Drawing.Point(193, 92)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(214, 21)
        Me.txtSupplier.TabIndex = 68
        Me.txtSupplier.TabStop = False
        '
        'cboSupplier
        '
        Me.cboSupplier.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSupplier.ArrowColor = System.Drawing.Color.Black
        Me.cboSupplier.BindedControl = CType(resources.GetObject("cboSupplier.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboSupplier.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.cboSupplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSupplier.ColumnNum = 1
        Me.cboSupplier.ColumnWidth = "121"
        Me.cboSupplier.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboSupplier.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboSupplier.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboSupplier.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboSupplier.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboSupplier.DisplayMember = "Text"
        Me.cboSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSupplier.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboSupplier.DropDownForeColor = System.Drawing.Color.Black
        Me.cboSupplier.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboSupplier.DropDownWidth = 141
        Me.cboSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSupplier.GridLineColor = System.Drawing.Color.DarkGray
        Me.cboSupplier.GridLineHorizontal = True
        Me.cboSupplier.GridLineVertical = True
        Me.cboSupplier.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboSupplier.Location = New System.Drawing.Point(94, 92)
        Me.cboSupplier.ManagingFastMouseMoving = True
        Me.cboSupplier.ManagingFastMouseMovingInterval = 30
        Me.cboSupplier.Name = "cboSupplier"
        Me.cboSupplier.SelectedItem = Nothing
        Me.cboSupplier.SelectedValue = Nothing
        Me.cboSupplier.Size = New System.Drawing.Size(100, 22)
        Me.cboSupplier.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(830, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Type of JR"
        '
        'lblPlacement
        '
        Me.lblPlacement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPlacement.AutoSize = True
        Me.lblPlacement.Location = New System.Drawing.Point(768, 74)
        Me.lblPlacement.Name = "lblPlacement"
        Me.lblPlacement.Size = New System.Drawing.Size(121, 13)
        Me.lblPlacement.TabIndex = 66
        Me.lblPlacement.Text = "JO Placement Schedule"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(820, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Date Needed"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(806, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Date Requested"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(425, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Supplier Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Line"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Section"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Department"
        '
        'cboPRType
        '
        Me.cboPRType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPRType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRType.FormattingEnabled = True
        Me.cboPRType.Items.AddRange(New Object() {"Cash", "JO"})
        Me.cboPRType.Location = New System.Drawing.Point(897, 49)
        Me.cboPRType.Name = "cboPRType"
        Me.cboPRType.Size = New System.Drawing.Size(100, 21)
        Me.cboPRType.TabIndex = 7
        '
        'dtPOSchedule
        '
        Me.dtPOSchedule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPOSchedule.CustomFormat = "MM-dd-yyyy"
        Me.dtPOSchedule.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPOSchedule.Location = New System.Drawing.Point(897, 68)
        Me.dtPOSchedule.Name = "dtPOSchedule"
        Me.dtPOSchedule.Size = New System.Drawing.Size(100, 20)
        Me.dtPOSchedule.TabIndex = 8
        '
        'dtDateNeeded
        '
        Me.dtDateNeeded.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtDateNeeded.CustomFormat = "MM-dd-yyyy"
        Me.dtDateNeeded.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDateNeeded.Location = New System.Drawing.Point(897, 30)
        Me.dtDateNeeded.Name = "dtDateNeeded"
        Me.dtDateNeeded.Size = New System.Drawing.Size(100, 20)
        Me.dtDateNeeded.TabIndex = 6
        '
        'dtDateRequested
        '
        Me.dtDateRequested.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtDateRequested.CustomFormat = "MM-dd-yyyy"
        Me.dtDateRequested.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDateRequested.Location = New System.Drawing.Point(897, 11)
        Me.dtDateRequested.Name = "dtDateRequested"
        Me.dtDateRequested.Size = New System.Drawing.Size(100, 20)
        Me.dtDateRequested.TabIndex = 5
        '
        'txtSupplierType
        '
        Me.txtSupplierType.BackColor = System.Drawing.Color.LightGray
        Me.txtSupplierType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierType.Location = New System.Drawing.Point(503, 92)
        Me.txtSupplierType.Name = "txtSupplierType"
        Me.txtSupplierType.ReadOnly = True
        Me.txtSupplierType.Size = New System.Drawing.Size(100, 21)
        Me.txtSupplierType.TabIndex = 55
        Me.txtSupplierType.TabStop = False
        '
        'txtLine
        '
        Me.txtLine.BackColor = System.Drawing.Color.LightGray
        Me.txtLine.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLine.Location = New System.Drawing.Point(193, 72)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.ReadOnly = True
        Me.txtLine.Size = New System.Drawing.Size(214, 21)
        Me.txtLine.TabIndex = 53
        Me.txtLine.TabStop = False
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
        Me.cboLine.Location = New System.Drawing.Point(94, 72)
        Me.cboLine.ManagingFastMouseMoving = True
        Me.cboLine.ManagingFastMouseMovingInterval = 30
        Me.cboLine.Name = "cboLine"
        Me.cboLine.SelectedItem = Nothing
        Me.cboLine.SelectedValue = Nothing
        Me.cboLine.Size = New System.Drawing.Size(100, 22)
        Me.cboLine.TabIndex = 3
        '
        'txtDepartment
        '
        Me.txtDepartment.BackColor = System.Drawing.Color.LightGray
        Me.txtDepartment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartment.Location = New System.Drawing.Point(193, 32)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.Size = New System.Drawing.Size(214, 21)
        Me.txtDepartment.TabIndex = 49
        Me.txtDepartment.TabStop = False
        '
        'txtSection
        '
        Me.txtSection.BackColor = System.Drawing.Color.LightGray
        Me.txtSection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSection.Location = New System.Drawing.Point(193, 52)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.ReadOnly = True
        Me.txtSection.Size = New System.Drawing.Size(214, 21)
        Me.txtSection.TabIndex = 50
        Me.txtSection.TabStop = False
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
        Me.cboDepartment.Location = New System.Drawing.Point(94, 32)
        Me.cboDepartment.ManagingFastMouseMoving = True
        Me.cboDepartment.ManagingFastMouseMovingInterval = 30
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.SelectedItem = Nothing
        Me.cboDepartment.SelectedValue = Nothing
        Me.cboDepartment.Size = New System.Drawing.Size(100, 22)
        Me.cboDepartment.TabIndex = 1
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
        Me.cboSection.Location = New System.Drawing.Point(94, 52)
        Me.cboSection.ManagingFastMouseMoving = True
        Me.cboSection.ManagingFastMouseMovingInterval = 30
        Me.cboSection.Name = "cboSection"
        Me.cboSection.SelectedItem = Nothing
        Me.cboSection.SelectedValue = Nothing
        Me.cboSection.Size = New System.Drawing.Size(100, 22)
        Me.cboSection.TabIndex = 2
        '
        'txtJRNo
        '
        Me.txtJRNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJRNo.Location = New System.Drawing.Point(94, 13)
        Me.txtJRNo.Name = "txtJRNo"
        Me.txtJRNo.Size = New System.Drawing.Size(100, 20)
        Me.txtJRNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "JR No."
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1065, 36)
        Me.Panel1.TabIndex = 64
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(224, 33)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Job Requisition"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frm_100_JR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 477)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frm_100_JR"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Requisition"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtJRNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLine As System.Windows.Forms.TextBox
    Friend WithEvents cboLine As MTGCComboBox
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents txtSection As System.Windows.Forms.TextBox
    Friend WithEvents cboDepartment As MTGCComboBox
    Friend WithEvents cboSection As MTGCComboBox
    Friend WithEvents txtSupplierType As System.Windows.Forms.TextBox
    Friend WithEvents dtPOSchedule As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtDateNeeded As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtDateRequested As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboPRType As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPlacement As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents cboSupplier As MTGCComboBox
    Friend WithEvents dgDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCountSub As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblcurrency As System.Windows.Forms.Label
    Friend WithEvents txtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents btncopy As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboCurrency As MTGCComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbodec As System.Windows.Forms.ComboBox
    Friend WithEvents cboApproved As System.Windows.Forms.ComboBox
    Friend WithEvents cboChecked As System.Windows.Forms.ComboBox
    Friend WithEvents cborequested As System.Windows.Forms.ComboBox
    Friend WithEvents colSpecificCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBtnAdd As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTOCCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBrandType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colService As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReqQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActualUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActualPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLastService As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
