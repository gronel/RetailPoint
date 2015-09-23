<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchItems
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchItems))
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.chckall = New System.Windows.Forms.CheckBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.lblCountSub = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgSearchItems = New System.Windows.Forms.DataGridView
        Me.dg3 = New System.Windows.Forms.DataGridView
        Me.colcheck3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colproductNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgSearchProduct = New System.Windows.Forms.DataGridView
        Me.colChkAdd = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCheckAdd = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSpecificCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSpecificDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colActualUOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgSearchItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSearchProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Value"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(64, 32)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(137, 20)
        Me.txtValue.TabIndex = 11
        '
        'cboCategory
        '
        Me.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"Item Name", "Specific Code", "Item Specific Description", "Brand/Lens type"})
        Me.cboCategory.Location = New System.Drawing.Point(64, 12)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(137, 21)
        Me.cboCategory.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Category"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chckall)
        Me.Panel2.Controls.Add(Me.btnOk)
        Me.Panel2.Controls.Add(Me.lblCountSub)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 409)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(538, 30)
        Me.Panel2.TabIndex = 73
        '
        'chckall
        '
        Me.chckall.AutoSize = True
        Me.chckall.Location = New System.Drawing.Point(388, 8)
        Me.chckall.Name = "chckall"
        Me.chckall.Size = New System.Drawing.Size(70, 17)
        Me.chckall.TabIndex = 77
        Me.chckall.Text = "Check all"
        Me.chckall.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Image = Global.TOPCInventorySales.My.Resources.Resources.server_ok
        Me.btnOk.Location = New System.Drawing.Point(464, 4)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(65, 23)
        Me.btnOk.TabIndex = 76
        Me.btnOk.Text = "Ok"
        Me.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lblCountSub
        '
        Me.lblCountSub.AutoSize = True
        Me.lblCountSub.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCountSub.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountSub.Location = New System.Drawing.Point(86, 12)
        Me.lblCountSub.Name = "lblCountSub"
        Me.lblCountSub.Size = New System.Drawing.Size(16, 16)
        Me.lblCountSub.TabIndex = 1
        Me.lblCountSub.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "No. of Records:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgSearchItems)
        Me.GroupBox1.Controls.Add(Me.dg3)
        Me.GroupBox1.Controls.Add(Me.dgSearchProduct)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(526, 350)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        '
        'dgSearchItems
        '
        Me.dgSearchItems.AllowUserToAddRows = False
        Me.dgSearchItems.AllowUserToDeleteRows = False
        Me.dgSearchItems.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgSearchItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSearchItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSearchItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheckAdd, Me.Column1, Me.colSpecificCode, Me.colSpecificDescription, Me.Column2, Me.colActualUOM})
        Me.dgSearchItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSearchItems.Location = New System.Drawing.Point(3, 16)
        Me.dgSearchItems.Name = "dgSearchItems"
        Me.dgSearchItems.RowHeadersVisible = False
        Me.dgSearchItems.RowHeadersWidth = 25
        Me.dgSearchItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgSearchItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSearchItems.Size = New System.Drawing.Size(520, 331)
        Me.dgSearchItems.TabIndex = 0
        '
        'dg3
        '
        Me.dg3.AllowUserToAddRows = False
        Me.dg3.AllowUserToDeleteRows = False
        Me.dg3.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dg3.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dg3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colcheck3, Me.colproductNo, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.dg3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg3.Location = New System.Drawing.Point(3, 16)
        Me.dg3.Name = "dg3"
        Me.dg3.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg3.RowHeadersVisible = False
        Me.dg3.RowHeadersWidth = 25
        Me.dg3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg3.Size = New System.Drawing.Size(520, 331)
        Me.dg3.TabIndex = 2
        Me.dg3.Visible = False
        '
        'colcheck3
        '
        Me.colcheck3.FalseValue = "0"
        Me.colcheck3.HeaderText = ""
        Me.colcheck3.IndeterminateValue = "0"
        Me.colcheck3.Name = "colcheck3"
        Me.colcheck3.TrueValue = "1"
        Me.colcheck3.Width = 30
        '
        'colproductNo
        '
        Me.colproductNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colproductNo.DataPropertyName = "ProductCode"
        Me.colproductNo.HeaderText = "Product Code"
        Me.colproductNo.MinimumWidth = 100
        Me.colproductNo.Name = "colproductNo"
        Me.colproductNo.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ProductName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Product Name"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PartNo"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Part No."
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'dgSearchProduct
        '
        Me.dgSearchProduct.AllowUserToAddRows = False
        Me.dgSearchProduct.AllowUserToDeleteRows = False
        Me.dgSearchProduct.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgSearchProduct.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgSearchProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSearchProduct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colChkAdd, Me.colProductCode, Me.colProductName, Me.colPartNo, Me.colQty})
        Me.dgSearchProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSearchProduct.Location = New System.Drawing.Point(3, 16)
        Me.dgSearchProduct.Name = "dgSearchProduct"
        Me.dgSearchProduct.RowHeadersVisible = False
        Me.dgSearchProduct.RowHeadersWidth = 25
        Me.dgSearchProduct.Size = New System.Drawing.Size(520, 331)
        Me.dgSearchProduct.TabIndex = 1
        Me.dgSearchProduct.Visible = False
        '
        'colChkAdd
        '
        Me.colChkAdd.FalseValue = "0"
        Me.colChkAdd.HeaderText = ""
        Me.colChkAdd.IndeterminateValue = "0"
        Me.colChkAdd.Name = "colChkAdd"
        Me.colChkAdd.TrueValue = "1"
        Me.colChkAdd.Width = 30
        '
        'colProductCode
        '
        Me.colProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colProductCode.DataPropertyName = "ProductCode"
        Me.colProductCode.HeaderText = "Product Code"
        Me.colProductCode.MinimumWidth = 100
        Me.colProductCode.Name = "colProductCode"
        Me.colProductCode.ReadOnly = True
        '
        'colProductName
        '
        Me.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colProductName.DataPropertyName = "ProductName"
        Me.colProductName.HeaderText = "Product Name"
        Me.colProductName.MinimumWidth = 100
        Me.colProductName.Name = "colProductName"
        Me.colProductName.ReadOnly = True
        '
        'colPartNo
        '
        Me.colPartNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPartNo.DataPropertyName = "PartNo"
        Me.colPartNo.HeaderText = "Part No."
        Me.colPartNo.MinimumWidth = 100
        Me.colPartNo.Name = "colPartNo"
        Me.colPartNo.ReadOnly = True
        '
        'colQty
        '
        Me.colQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colQty.DataPropertyName = "Quantity"
        Me.colQty.HeaderText = "Quantity"
        Me.colQty.MinimumWidth = 100
        Me.colQty.Name = "colQty"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "BrandType"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Brand/Lens type"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ProductCode"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Product Code"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ProductName"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Product Name"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "PartNo"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Part No."
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "ProductCode"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Product Code"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "ProductName"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Product Name"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "PartNo"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Part No."
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'colCheckAdd
        '
        Me.colCheckAdd.FalseValue = "0"
        Me.colCheckAdd.HeaderText = ""
        Me.colCheckAdd.IndeterminateValue = "0"
        Me.colCheckAdd.Name = "colCheckAdd"
        Me.colCheckAdd.TrueValue = "1"
        Me.colCheckAdd.Width = 30
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "ItemName"
        Me.Column1.HeaderText = "Item Name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'colSpecificCode
        '
        Me.colSpecificCode.DataPropertyName = "SpecificCode"
        Me.colSpecificCode.HeaderText = "Specific Code"
        Me.colSpecificCode.Name = "colSpecificCode"
        Me.colSpecificCode.ReadOnly = True
        '
        'colSpecificDescription
        '
        Me.colSpecificDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSpecificDescription.DataPropertyName = "SpecificDescription"
        Me.colSpecificDescription.HeaderText = "Item Specific Description"
        Me.colSpecificDescription.Name = "colSpecificDescription"
        Me.colSpecificDescription.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.DataPropertyName = "BrandType"
        Me.Column2.HeaderText = "Brand/Lens type"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'colActualUOM
        '
        Me.colActualUOM.HeaderText = "Actual UoM"
        Me.colActualUOM.Name = "colActualUOM"
        Me.colActualUOM.ReadOnly = True
        '
        'frmSearchItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 439)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchItems"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Item(s)"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgSearchItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSearchProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCountSub As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents chckall As System.Windows.Forms.CheckBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgSearchItems As System.Windows.Forms.DataGridView
    Friend WithEvents dg3 As System.Windows.Forms.DataGridView
    Friend WithEvents dgSearchProduct As System.Windows.Forms.DataGridView
    Friend WithEvents colChkAdd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colcheck3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colproductNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheckAdd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSpecificCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSpecificDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActualUOM As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
