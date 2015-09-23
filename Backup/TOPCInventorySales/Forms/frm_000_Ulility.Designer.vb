<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_000_Ulility
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_000_Ulility))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tab1 = New System.Windows.Forms.TabPage
        Me.dgCatigory = New System.Windows.Forms.DataGridView
        Me.colCid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblcategory = New System.Windows.Forms.Label
        Me.LabelCount = New System.Windows.Forms.Label
        Me.tab2 = New System.Windows.Forms.TabPage
        Me.dgPayTerm = New System.Windows.Forms.DataGridView
        Me.colid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTermName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPayDays = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblPayterms = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tab3 = New System.Windows.Forms.TabPage
        Me.dgtransport = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.lbltransport = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tab4 = New System.Windows.Forms.TabPage
        Me.dgpaytermCust = New System.Windows.Forms.DataGridView
        Me.colCpayterm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCpaytermName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCnumDays = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tab5 = New System.Windows.Forms.TabPage
        Me.dginternal = New System.Windows.Forms.DataGridView
        Me.colSuppliercode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.lblinternalSupplier = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.picLogo = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1.SuspendLayout()
        Me.tab1.SuspendLayout()
        CType(Me.dgCatigory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.tab2.SuspendLayout()
        CType(Me.dgPayTerm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.tab3.SuspendLayout()
        CType(Me.dgtransport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.tab4.SuspendLayout()
        CType(Me.dgpaytermCust, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.tab5.SuspendLayout()
        CType(Me.dginternal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tab1)
        Me.TabControl1.Controls.Add(Me.tab2)
        Me.TabControl1.Controls.Add(Me.tab3)
        Me.TabControl1.Controls.Add(Me.tab4)
        Me.TabControl1.Controls.Add(Me.tab5)
        Me.TabControl1.Location = New System.Drawing.Point(12, 50)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(475, 273)
        Me.TabControl1.TabIndex = 0
        '
        'tab1
        '
        Me.tab1.Controls.Add(Me.dgCatigory)
        Me.tab1.Controls.Add(Me.Panel3)
        Me.tab1.Location = New System.Drawing.Point(4, 22)
        Me.tab1.Name = "tab1"
        Me.tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.tab1.Size = New System.Drawing.Size(467, 247)
        Me.tab1.TabIndex = 0
        Me.tab1.Text = "Company Category"
        Me.tab1.UseVisualStyleBackColor = True
        '
        'dgCatigory
        '
        Me.dgCatigory.AllowUserToResizeRows = False
        Me.dgCatigory.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgCatigory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCatigory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCid, Me.colCname})
        Me.dgCatigory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCatigory.Location = New System.Drawing.Point(3, 3)
        Me.dgCatigory.Name = "dgCatigory"
        Me.dgCatigory.Size = New System.Drawing.Size(461, 217)
        Me.dgCatigory.TabIndex = 12
        '
        'colCid
        '
        Me.colCid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCid.DataPropertyName = "ComCatID"
        Me.colCid.FillWeight = 98.47716!
        Me.colCid.HeaderText = "Company Category ID"
        Me.colCid.MinimumWidth = 100
        Me.colCid.Name = "colCid"
        '
        'colCname
        '
        Me.colCname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCname.DataPropertyName = "ComCatName"
        Me.colCname.FillWeight = 101.5228!
        Me.colCname.HeaderText = "Category Name"
        Me.colCname.MinimumWidth = 100
        Me.colCname.Name = "colCname"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblcategory)
        Me.Panel3.Controls.Add(Me.LabelCount)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 220)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(461, 24)
        Me.Panel3.TabIndex = 11
        '
        'lblcategory
        '
        Me.lblcategory.AutoSize = True
        Me.lblcategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblcategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.Location = New System.Drawing.Point(86, 4)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(16, 16)
        Me.lblcategory.TabIndex = 1
        Me.lblcategory.Text = "0"
        '
        'LabelCount
        '
        Me.LabelCount.AutoSize = True
        Me.LabelCount.Location = New System.Drawing.Point(4, 5)
        Me.LabelCount.Name = "LabelCount"
        Me.LabelCount.Size = New System.Drawing.Size(82, 13)
        Me.LabelCount.TabIndex = 1
        Me.LabelCount.Text = "No. of Records:"
        '
        'tab2
        '
        Me.tab2.Controls.Add(Me.dgPayTerm)
        Me.tab2.Controls.Add(Me.Panel2)
        Me.tab2.Location = New System.Drawing.Point(4, 22)
        Me.tab2.Name = "tab2"
        Me.tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.tab2.Size = New System.Drawing.Size(467, 247)
        Me.tab2.TabIndex = 1
        Me.tab2.Text = "Pay Terms"
        Me.tab2.UseVisualStyleBackColor = True
        '
        'dgPayTerm
        '
        Me.dgPayTerm.AllowUserToResizeRows = False
        Me.dgPayTerm.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgPayTerm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPayTerm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colid, Me.colTermName, Me.colPayDays})
        Me.dgPayTerm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPayTerm.Location = New System.Drawing.Point(3, 3)
        Me.dgPayTerm.Name = "dgPayTerm"
        Me.dgPayTerm.Size = New System.Drawing.Size(461, 217)
        Me.dgPayTerm.TabIndex = 11
        '
        'colid
        '
        Me.colid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colid.DataPropertyName = "PayTermsID"
        Me.colid.HeaderText = "Pay Term ID"
        Me.colid.Name = "colid"
        '
        'colTermName
        '
        Me.colTermName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTermName.DataPropertyName = "PayTermsName"
        Me.colTermName.HeaderText = "Pay Term Name"
        Me.colTermName.Name = "colTermName"
        '
        'colPayDays
        '
        Me.colPayDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPayDays.DataPropertyName = "NoOfDays"
        Me.colPayDays.HeaderText = "Number of Days"
        Me.colPayDays.Name = "colPayDays"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblPayterms)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 220)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(461, 24)
        Me.Panel2.TabIndex = 12
        '
        'lblPayterms
        '
        Me.lblPayterms.AutoSize = True
        Me.lblPayterms.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPayterms.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayterms.Location = New System.Drawing.Point(86, 4)
        Me.lblPayterms.Name = "lblPayterms"
        Me.lblPayterms.Size = New System.Drawing.Size(16, 16)
        Me.lblPayterms.TabIndex = 1
        Me.lblPayterms.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "No. of Records:"
        '
        'tab3
        '
        Me.tab3.Controls.Add(Me.dgtransport)
        Me.tab3.Controls.Add(Me.Panel4)
        Me.tab3.Location = New System.Drawing.Point(4, 22)
        Me.tab3.Name = "tab3"
        Me.tab3.Size = New System.Drawing.Size(467, 247)
        Me.tab3.TabIndex = 2
        Me.tab3.Text = "Transportation"
        Me.tab3.UseVisualStyleBackColor = True
        '
        'dgtransport
        '
        Me.dgtransport.AllowUserToResizeRows = False
        Me.dgtransport.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgtransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgtransport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgtransport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgtransport.Location = New System.Drawing.Point(0, 0)
        Me.dgtransport.Name = "dgtransport"
        Me.dgtransport.Size = New System.Drawing.Size(467, 223)
        Me.dgtransport.TabIndex = 16
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DeliveryID"
        Me.DataGridViewTextBoxColumn1.FillWeight = 98.47716!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Transport ID"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DeliveryBy"
        Me.DataGridViewTextBoxColumn2.FillWeight = 101.5228!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Transport By"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lbltransport)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 223)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(467, 24)
        Me.Panel4.TabIndex = 13
        '
        'lbltransport
        '
        Me.lbltransport.AutoSize = True
        Me.lbltransport.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltransport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransport.Location = New System.Drawing.Point(86, 4)
        Me.lbltransport.Name = "lbltransport"
        Me.lbltransport.Size = New System.Drawing.Size(16, 16)
        Me.lbltransport.TabIndex = 1
        Me.lbltransport.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "No. of Records:"
        '
        'tab4
        '
        Me.tab4.Controls.Add(Me.dgpaytermCust)
        Me.tab4.Controls.Add(Me.Panel5)
        Me.tab4.Location = New System.Drawing.Point(4, 22)
        Me.tab4.Name = "tab4"
        Me.tab4.Size = New System.Drawing.Size(467, 247)
        Me.tab4.TabIndex = 3
        Me.tab4.Text = "Pay Terms"
        Me.tab4.UseVisualStyleBackColor = True
        '
        'dgpaytermCust
        '
        Me.dgpaytermCust.AllowUserToResizeRows = False
        Me.dgpaytermCust.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgpaytermCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgpaytermCust.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCpayterm, Me.colCpaytermName, Me.colCnumDays})
        Me.dgpaytermCust.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgpaytermCust.Location = New System.Drawing.Point(0, 0)
        Me.dgpaytermCust.Name = "dgpaytermCust"
        Me.dgpaytermCust.Size = New System.Drawing.Size(467, 223)
        Me.dgpaytermCust.TabIndex = 14
        '
        'colCpayterm
        '
        Me.colCpayterm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCpayterm.DataPropertyName = "PayTermsID"
        Me.colCpayterm.HeaderText = "Pay Term ID"
        Me.colCpayterm.Name = "colCpayterm"
        '
        'colCpaytermName
        '
        Me.colCpaytermName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCpaytermName.DataPropertyName = "PayTermsName"
        Me.colCpaytermName.HeaderText = "Pay Term Name"
        Me.colCpaytermName.Name = "colCpaytermName"
        '
        'colCnumDays
        '
        Me.colCnumDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCnumDays.DataPropertyName = "NoOfDays"
        Me.colCnumDays.HeaderText = "Number of Days"
        Me.colCnumDays.Name = "colCnumDays"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 223)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(467, 24)
        Me.Panel5.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(86, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "No. of Records:"
        '
        'tab5
        '
        Me.tab5.Controls.Add(Me.dginternal)
        Me.tab5.Controls.Add(Me.Panel6)
        Me.tab5.Location = New System.Drawing.Point(4, 22)
        Me.tab5.Name = "tab5"
        Me.tab5.Padding = New System.Windows.Forms.Padding(3)
        Me.tab5.Size = New System.Drawing.Size(467, 247)
        Me.tab5.TabIndex = 4
        Me.tab5.Text = "Internal Product Supplier"
        Me.tab5.UseVisualStyleBackColor = True
        '
        'dginternal
        '
        Me.dginternal.AllowUserToResizeRows = False
        Me.dginternal.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dginternal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dginternal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSuppliercode, Me.colSupplierName})
        Me.dginternal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dginternal.Location = New System.Drawing.Point(3, 3)
        Me.dginternal.Name = "dginternal"
        Me.dginternal.Size = New System.Drawing.Size(461, 217)
        Me.dginternal.TabIndex = 15
        '
        'colSuppliercode
        '
        Me.colSuppliercode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSuppliercode.DataPropertyName = "inSupplierCode"
        Me.colSuppliercode.HeaderText = "Supplier Code"
        Me.colSuppliercode.Name = "colSuppliercode"
        '
        'colSupplierName
        '
        Me.colSupplierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSupplierName.DataPropertyName = "inSupplierName"
        Me.colSupplierName.HeaderText = "Supplier Name"
        Me.colSupplierName.Name = "colSupplierName"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblinternalSupplier)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(3, 220)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(461, 24)
        Me.Panel6.TabIndex = 14
        '
        'lblinternalSupplier
        '
        Me.lblinternalSupplier.AutoSize = True
        Me.lblinternalSupplier.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblinternalSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinternalSupplier.Location = New System.Drawing.Point(86, 4)
        Me.lblinternalSupplier.Name = "lblinternalSupplier"
        Me.lblinternalSupplier.Size = New System.Drawing.Size(16, 16)
        Me.lblinternalSupplier.TabIndex = 1
        Me.lblinternalSupplier.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "No. of Records:"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.AutoSize = False
        Me.ToolStripButton6.Enabled = False
        Me.ToolStripButton6.Image = Global.TOPCInventorySales.My.Resources.Resources.add
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(50, 33)
        Me.ToolStripButton6.Text = "New"
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.AutoSize = False
        Me.ToolStripButton7.Enabled = False
        Me.ToolStripButton7.Image = Global.TOPCInventorySales.My.Resources.Resources.edit2
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(50, 33)
        Me.ToolStripButton7.Text = "Edit"
        Me.ToolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 36)
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.AutoSize = False
        Me.ToolStripButton8.Enabled = False
        Me.ToolStripButton8.Image = Global.TOPCInventorySales.My.Resources.Resources.BD14755_
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(50, 33)
        Me.ToolStripButton8.Text = "Delete"
        Me.ToolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 36)
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.AutoSize = False
        Me.ToolStripButton9.Enabled = False
        Me.ToolStripButton9.Image = Global.TOPCInventorySales.My.Resources.Resources.save
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(50, 33)
        Me.ToolStripButton9.Text = "Save"
        Me.ToolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.AutoSize = False
        Me.ToolStripButton10.Enabled = False
        Me.ToolStripButton10.Image = Global.TOPCInventorySales.My.Resources.Resources.icon_quit
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(50, 33)
        Me.ToolStripButton10.Text = "Cancel"
        Me.ToolStripButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 36)
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.picLogo)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(499, 36)
        Me.Panel1.TabIndex = 30
        '
        'picLogo
        '
        Me.picLogo.Location = New System.Drawing.Point(0, 0)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(115, 36)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo.TabIndex = 8
        Me.picLogo.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTitle.Location = New System.Drawing.Point(216, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(97, 33)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Utility"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "No. of Records:"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PayTermsID"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Pay Term ID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "PayTermsName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Pay Term Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "NoOfDays"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Number of Days"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "DeliveryID"
        Me.DataGridViewTextBoxColumn6.FillWeight = 98.47716!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Transport ID"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "DeliveryBy"
        Me.DataGridViewTextBoxColumn7.FillWeight = 101.5228!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Transport By"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "PayTermsID"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Pay Term ID"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "PayTermsName"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Pay Term Name"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "NoOfDays"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Number of Days"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn11.HeaderText = "Supplier Code"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn12.HeaderText = "Supplier Name"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'frm_000_Ulility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 330)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_000_Ulility"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Utility"
        Me.TabControl1.ResumeLayout(False)
        Me.tab1.ResumeLayout(False)
        CType(Me.dgCatigory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tab2.ResumeLayout(False)
        CType(Me.dgPayTerm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tab3.ResumeLayout(False)
        CType(Me.dgtransport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.tab4.ResumeLayout(False)
        CType(Me.dgpaytermCust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.tab5.ResumeLayout(False)
        CType(Me.dginternal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tab1 As System.Windows.Forms.TabPage
    Friend WithEvents tab2 As System.Windows.Forms.TabPage
    Friend WithEvents tab3 As System.Windows.Forms.TabPage
    Friend WithEvents dgPayTerm As System.Windows.Forms.DataGridView
    Friend WithEvents dgCatigory As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents LabelCount As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblPayterms As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents colid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTermName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lbltransport As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgtransport As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tab4 As System.Windows.Forms.TabPage
    Friend WithEvents dgpaytermCust As System.Windows.Forms.DataGridView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents colCpayterm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCpaytermName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCnumDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tab5 As System.Windows.Forms.TabPage
    Friend WithEvents dginternal As System.Windows.Forms.DataGridView
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblinternalSupplier As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents colSuppliercode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
