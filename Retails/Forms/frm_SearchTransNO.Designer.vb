<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SearchTransNO
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgSearchcontrol = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.colTransNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSupplier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblCountSub = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dg2 = New System.Windows.Forms.DataGridView
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.colcontrol2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnPicbox = New System.Windows.Forms.PictureBox
        Me.dgOrder = New System.Windows.Forms.DataGridView
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgProduct = New System.Windows.Forms.DataGridView
        Me.DataGridViewButtonColumn3 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgSearchcontrol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPicbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Value"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(60, 32)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(137, 20)
        Me.txtValue.TabIndex = 15
        '
        'cboCategory
        '
        Me.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(60, 12)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(137, 21)
        Me.cboCategory.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Category"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgSearchcontrol
        '
        Me.dgSearchcontrol.AllowUserToAddRows = False
        Me.dgSearchcontrol.AllowUserToDeleteRows = False
        Me.dgSearchcontrol.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgSearchcontrol.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSearchcontrol.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSearchcontrol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSearchcontrol.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.colTransNo, Me.colDate, Me.colDepartment, Me.colSupplier})
        Me.dgSearchcontrol.Location = New System.Drawing.Point(10, 58)
        Me.dgSearchcontrol.Name = "dgSearchcontrol"
        Me.dgSearchcontrol.RowHeadersVisible = False
        Me.dgSearchcontrol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSearchcontrol.Size = New System.Drawing.Size(493, 326)
        Me.dgSearchcontrol.TabIndex = 17
        '
        'Column1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.NullValue = "Select"
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.FillWeight = 40.0!
        Me.Column1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Column1.HeaderText = ""
        Me.Column1.MinimumWidth = 40
        Me.Column1.Name = "Column1"
        Me.Column1.Text = "select"
        Me.Column1.Width = 40
        '
        'colTransNo
        '
        Me.colTransNo.DataPropertyName = "Control"
        Me.colTransNo.HeaderText = "Control No."
        Me.colTransNo.Name = "colTransNo"
        Me.colTransNo.ReadOnly = True
        '
        'colDate
        '
        Me.colDate.DataPropertyName = "Date"
        DataGridViewCellStyle3.Format = "d"
        Me.colDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDate.HeaderText = "Date Requested"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        '
        'colDepartment
        '
        Me.colDepartment.DataPropertyName = "DepartmentName"
        Me.colDepartment.HeaderText = "Department"
        Me.colDepartment.Name = "colDepartment"
        Me.colDepartment.ReadOnly = True
        '
        'colSupplier
        '
        Me.colSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSupplier.DataPropertyName = "SupplierName"
        Me.colSupplier.HeaderText = "Supplier"
        Me.colSupplier.MinimumWidth = 100
        Me.colSupplier.Name = "colSupplier"
        Me.colSupplier.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblCountSub)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Location = New System.Drawing.Point(8, 386)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(142, 22)
        Me.Panel2.TabIndex = 74
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
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'dg2
        '
        Me.dg2.AllowUserToAddRows = False
        Me.dg2.AllowUserToDeleteRows = False
        Me.dg2.AllowUserToResizeRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dg2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dg2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewButtonColumn1, Me.colcontrol2, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dg2.Location = New System.Drawing.Point(10, 58)
        Me.dg2.Name = "dg2"
        Me.dg2.RowHeadersVisible = False
        Me.dg2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg2.Size = New System.Drawing.Size(493, 326)
        Me.dg2.TabIndex = 75
        '
        'DataGridViewButtonColumn1
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.NullValue = "Select"
        Me.DataGridViewButtonColumn1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewButtonColumn1.FillWeight = 40.0!
        Me.DataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DataGridViewButtonColumn1.HeaderText = ""
        Me.DataGridViewButtonColumn1.MinimumWidth = 40
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.Text = "select"
        Me.DataGridViewButtonColumn1.Width = 40
        '
        'colcontrol2
        '
        Me.colcontrol2.DataPropertyName = "Control"
        Me.colcontrol2.HeaderText = "Control No."
        Me.colcontrol2.Name = "colcontrol2"
        Me.colcontrol2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Date"
        DataGridViewCellStyle10.Format = "d"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn2.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DeliveryDate"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Delivery Date"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "SupplierName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Supplier"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'btnPicbox
        '
        Me.btnPicbox.BackColor = System.Drawing.Color.Transparent
        Me.btnPicbox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPicbox.Image = Global.Retails.My.Resources.Resources.Refresh
        Me.btnPicbox.Location = New System.Drawing.Point(199, 32)
        Me.btnPicbox.Name = "btnPicbox"
        Me.btnPicbox.Size = New System.Drawing.Size(25, 21)
        Me.btnPicbox.TabIndex = 76
        Me.btnPicbox.TabStop = False
        '
        'dgOrder
        '
        Me.dgOrder.AllowUserToAddRows = False
        Me.dgOrder.AllowUserToDeleteRows = False
        Me.dgOrder.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgOrder.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewButtonColumn2, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.dgOrder.Location = New System.Drawing.Point(10, 58)
        Me.dgOrder.Name = "dgOrder"
        Me.dgOrder.RowHeadersVisible = False
        Me.dgOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOrder.Size = New System.Drawing.Size(493, 326)
        Me.dgOrder.TabIndex = 77
        '
        'DataGridViewButtonColumn2
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.NullValue = "Select"
        Me.DataGridViewButtonColumn2.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewButtonColumn2.FillWeight = 40.0!
        Me.DataGridViewButtonColumn2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DataGridViewButtonColumn2.HeaderText = ""
        Me.DataGridViewButtonColumn2.MinimumWidth = 40
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.Text = "select"
        Me.DataGridViewButtonColumn2.Width = 40
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Order NO."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Order Date"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Order Type"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.HeaderText = "Customer Name"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'dgProduct
        '
        Me.dgProduct.AllowUserToAddRows = False
        Me.dgProduct.AllowUserToDeleteRows = False
        Me.dgProduct.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgProduct.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgProduct.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProduct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewButtonColumn3, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.Column2})
        Me.dgProduct.Location = New System.Drawing.Point(9, 58)
        Me.dgProduct.Name = "dgProduct"
        Me.dgProduct.RowHeadersVisible = False
        Me.dgProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProduct.Size = New System.Drawing.Size(493, 326)
        Me.dgProduct.TabIndex = 78
        '
        'DataGridViewButtonColumn3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.NullValue = "Select"
        Me.DataGridViewButtonColumn3.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewButtonColumn3.FillWeight = 40.0!
        Me.DataGridViewButtonColumn3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DataGridViewButtonColumn3.HeaderText = ""
        Me.DataGridViewButtonColumn3.MinimumWidth = 40
        Me.DataGridViewButtonColumn3.Name = "DataGridViewButtonColumn3"
        Me.DataGridViewButtonColumn3.Text = "select"
        Me.DataGridViewButtonColumn3.Width = 40
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Product Code"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Product No."
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Product Name"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Product Type"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Customer"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'frm_SearchTransNO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 409)
        Me.Controls.Add(Me.dgProduct)
        Me.Controls.Add(Me.dgOrder)
        Me.Controls.Add(Me.btnPicbox)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg2)
        Me.Controls.Add(Me.dgSearchcontrol)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_SearchTransNO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgSearchcontrol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPicbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgSearchcontrol As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCountSub As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents dg2 As System.Windows.Forms.DataGridView
    Friend WithEvents btnPicbox As System.Windows.Forms.PictureBox
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colcontrol2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colTransNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDepartment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSupplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgOrder As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewButtonColumn2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgProduct As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewButtonColumn3 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
