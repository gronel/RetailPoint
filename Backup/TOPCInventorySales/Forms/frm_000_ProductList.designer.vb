<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_000_ProductList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_000_ProductList))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.picLogo = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.dgList = New System.Windows.Forms.DataGridView
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
        Me.colProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProductType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colunitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.coldec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsPagination.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(278, 33)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Product Master File"
        '
        'dgList
        '
        Me.dgList.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgList.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colProductCode, Me.colPartNo, Me.colProductName, Me.colProductType, Me.Column4, Me.colCustomer, Me.Column3, Me.Column2, Me.colunitPrice, Me.Column1, Me.coldec})
        Me.dgList.Location = New System.Drawing.Point(13, 45)
        Me.dgList.MultiSelect = False
        Me.dgList.Name = "dgList"
        Me.dgList.ReadOnly = True
        Me.dgList.RowHeadersWidth = 25
        Me.dgList.Size = New System.Drawing.Size(832, 361)
        Me.dgList.TabIndex = 39
        '
        'tsPagination
        '
        Me.tsPagination.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsPagination.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPageSize, Me.tsFirst, Me.tsPrev, Me.tsPage, Me.tsNext, Me.tsLast, Me.tsRecordCount})
        Me.tsPagination.Location = New System.Drawing.Point(0, 420)
        Me.tsPagination.Name = "tsPagination"
        Me.tsPagination.Size = New System.Drawing.Size(859, 25)
        Me.tsPagination.TabIndex = 44
        Me.tsPagination.Text = "ToolStrip1"
        '
        'tsPageSize
        '
        Me.tsPageSize.Image = Global.TOPCInventorySales.My.Resources.Resources.Wrench
        Me.tsPageSize.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPageSize.Name = "tsPageSize"
        Me.tsPageSize.Size = New System.Drawing.Size(55, 22)
        Me.tsPageSize.Text = "Page:"
        '
        'tsFirst
        '
        Me.tsFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsFirst.Enabled = False
        Me.tsFirst.Image = Global.TOPCInventorySales.My.Resources.Resources.MoveFirst
        Me.tsFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFirst.Name = "tsFirst"
        Me.tsFirst.Size = New System.Drawing.Size(23, 22)
        Me.tsFirst.Text = "First Page"
        '
        'tsPrev
        '
        Me.tsPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsPrev.Enabled = False
        Me.tsPrev.Image = Global.TOPCInventorySales.My.Resources.Resources.MovePrevious
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
        Me.tsNext.Image = Global.TOPCInventorySales.My.Resources.Resources.MoveNext
        Me.tsNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNext.Name = "tsNext"
        Me.tsNext.Size = New System.Drawing.Size(23, 22)
        Me.tsNext.Text = "Next Page"
        '
        'tsLast
        '
        Me.tsLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsLast.Enabled = False
        Me.tsLast.Image = Global.TOPCInventorySales.My.Resources.Resources.MoveLast
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
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ProductCode"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Product Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ProductName"
        Me.DataGridViewTextBoxColumn2.FillWeight = 41.72036!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Product Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PartNo"
        Me.DataGridViewTextBoxColumn3.FillWeight = 41.72036!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Part Number"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn4.FillWeight = 41.72036!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Product Type"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "MaterialDesc"
        Me.DataGridViewTextBoxColumn5.FillWeight = 41.72036!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Material Type"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "CustomerName"
        Me.DataGridViewTextBoxColumn6.FillWeight = 40.0!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Customer"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn7.FillWeight = 41.72036!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Unit Price"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Status"
        Me.DataGridViewTextBoxColumn8.FillWeight = 41.72036!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Product Status"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "dec"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Column4"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'colProductCode
        '
        Me.colProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colProductCode.DataPropertyName = "ProductCode"
        Me.colProductCode.HeaderText = "Product Code"
        Me.colProductCode.Name = "colProductCode"
        Me.colProductCode.ReadOnly = True
        '
        'colPartNo
        '
        Me.colPartNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPartNo.DataPropertyName = "PartNo"
        Me.colPartNo.FillWeight = 41.72036!
        Me.colPartNo.HeaderText = "Part Number"
        Me.colPartNo.Name = "colPartNo"
        Me.colPartNo.ReadOnly = True
        '
        'colProductName
        '
        Me.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colProductName.DataPropertyName = "ProductName"
        Me.colProductName.FillWeight = 41.72036!
        Me.colProductName.HeaderText = "Product Name"
        Me.colProductName.Name = "colProductName"
        Me.colProductName.ReadOnly = True
        '
        'colProductType
        '
        Me.colProductType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colProductType.DataPropertyName = "ProductType"
        Me.colProductType.FillWeight = 41.72036!
        Me.colProductType.HeaderText = "Product Type"
        Me.colProductType.Name = "colProductType"
        Me.colProductType.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.DataPropertyName = "CustomerCode"
        Me.Column4.HeaderText = "Customer Code"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'colCustomer
        '
        Me.colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCustomer.DataPropertyName = "CustomerName"
        Me.colCustomer.FillWeight = 41.72036!
        Me.colCustomer.HeaderText = "Customer Name"
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.DataPropertyName = "inSupplierName"
        Me.Column3.HeaderText = "Internal Product Supplier"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.DataPropertyName = "CurrencyType"
        Me.Column2.FillWeight = 16.68814!
        Me.Column2.HeaderText = ""
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'colunitPrice
        '
        Me.colunitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colunitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colunitPrice.DefaultCellStyle = DataGridViewCellStyle2
        Me.colunitPrice.FillWeight = 41.72036!
        Me.colunitPrice.HeaderText = "Unit Price"
        Me.colunitPrice.Name = "colunitPrice"
        Me.colunitPrice.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.DataPropertyName = "Status"
        Me.Column1.FillWeight = 41.72036!
        Me.Column1.HeaderText = "Product Status"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'coldec
        '
        Me.coldec.DataPropertyName = "dec"
        Me.coldec.HeaderText = ""
        Me.coldec.Name = "coldec"
        Me.coldec.ReadOnly = True
        Me.coldec.Visible = False
        '
        'frm_000_ProductList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 445)
        Me.Controls.Add(Me.tsPagination)
        Me.Controls.Add(Me.dgList)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frm_000_ProductList"
        Me.Text = "frm_000_Item"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsPagination.ResumeLayout(False)
        Me.tsPagination.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgList As System.Windows.Forms.DataGridView
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsPagination As System.Windows.Forms.ToolStrip
    Friend WithEvents tsPageSize As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRecordCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProductType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustomer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colunitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coldec As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
