<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_200_RIL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_200_RIL))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
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
        Me.colRRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRRDAte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRRTYpe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSupplier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsPagination.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(816, 36)
        Me.Panel1.TabIndex = 67
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
        Me.lblTitle.Size = New System.Drawing.Size(277, 33)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Receiving Item List"
        '
        'dgList
        '
        Me.dgList.AllowUserToAddRows = False
        Me.dgList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgList.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRRNO, Me.colRRDAte, Me.colRRTYpe, Me.Column13, Me.colSupplier, Me.Column1, Me.Column4, Me.Column5, Me.Column19, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column15, Me.Column2, Me.Column16, Me.Column10, Me.Column11, Me.Column12, Me.Column17, Me.Column3, Me.Column18, Me.Column14})
        Me.dgList.Location = New System.Drawing.Point(6, 42)
        Me.dgList.Name = "dgList"
        Me.dgList.RowHeadersWidth = 25
        Me.dgList.Size = New System.Drawing.Size(800, 441)
        Me.dgList.TabIndex = 68
        '
        'tsPagination
        '
        Me.tsPagination.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsPagination.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPageSize, Me.tsFirst, Me.tsPrev, Me.tsPage, Me.tsNext, Me.tsLast, Me.tsRecordCount})
        Me.tsPagination.Location = New System.Drawing.Point(0, 491)
        Me.tsPagination.Name = "tsPagination"
        Me.tsPagination.Size = New System.Drawing.Size(814, 25)
        Me.tsPagination.TabIndex = 69
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
        'colRRNO
        '
        Me.colRRNO.DataPropertyName = "RRNo"
        Me.colRRNO.HeaderText = "RR #"
        Me.colRRNO.Name = "colRRNO"
        Me.colRRNO.ReadOnly = True
        '
        'colRRDAte
        '
        Me.colRRDAte.DataPropertyName = "RRDate"
        Me.colRRDAte.HeaderText = "RR Date"
        Me.colRRDAte.Name = "colRRDAte"
        Me.colRRDAte.ReadOnly = True
        '
        'colRRTYpe
        '
        Me.colRRTYpe.DataPropertyName = "RRType"
        Me.colRRTYpe.HeaderText = "RR Type"
        Me.colRRTYpe.Name = "colRRTYpe"
        Me.colRRTYpe.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.DataPropertyName = "SupplierID"
        Me.Column13.HeaderText = "Supplier Code"
        Me.Column13.Name = "Column13"
        '
        'colSupplier
        '
        Me.colSupplier.DataPropertyName = "SupplierName"
        Me.colSupplier.HeaderText = "Supplier Name"
        Me.colSupplier.Name = "colSupplier"
        Me.colSupplier.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "SupTypeName"
        Me.Column1.HeaderText = "Supplier Type"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "SpecificCode"
        Me.Column4.HeaderText = "Item Specific Code"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "TOCCode"
        Me.Column5.HeaderText = "TOC Code"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column19
        '
        Me.Column19.DataPropertyName = "ItemName"
        Me.Column19.HeaderText = "Item Name"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "SpecificDescription"
        Me.Column6.HeaderText = "Item Specific Description"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "BrandType"
        Me.Column7.HeaderText = "Brand / Lens Type"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "ActualQTY"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column8.HeaderText = "Actual Quantity"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "ActualUnit"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column9.HeaderText = "Actual Unit"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.DataPropertyName = "c1"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Column15.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column15.HeaderText = ""
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Width = 40
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "ActualUnitPrice"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column2.HeaderText = "Actual Unit Price"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.DataPropertyName = "c2"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Column16.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column16.HeaderText = ""
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 40
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "ActualAmount"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column10.HeaderText = "Actual Total Amount"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.DataPropertyName = "ConvertedQTY"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column11.HeaderText = "Converted Quantity"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.DataPropertyName = "ConvertedUnit"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.PowderBlue
        Me.Column12.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column12.HeaderText = "Converted Unit"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column17
        '
        Me.Column17.DataPropertyName = "c3"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.PowderBlue
        Me.Column17.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column17.HeaderText = ""
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 40
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "ConvertedPrice"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle11.NullValue = Nothing
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle11
        Me.Column3.HeaderText = "Converted Unit Price"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column18
        '
        Me.Column18.DataPropertyName = "c4"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.PowderBlue
        Me.Column18.DefaultCellStyle = DataGridViewCellStyle12
        Me.Column18.HeaderText = ""
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Width = 40
        '
        'Column14
        '
        Me.Column14.DataPropertyName = "ConvertedAmount"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle13.NullValue = Nothing
        Me.Column14.DefaultCellStyle = DataGridViewCellStyle13
        Me.Column14.HeaderText = "Converted Total Amount"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'frm_200_RIL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 516)
        Me.Controls.Add(Me.tsPagination)
        Me.Controls.Add(Me.dgList)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_200_RIL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receiving Item List"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsPagination.ResumeLayout(False)
        Me.tsPagination.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgList As System.Windows.Forms.DataGridView
    Friend WithEvents tsPagination As System.Windows.Forms.ToolStrip
    Friend WithEvents tsPageSize As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRecordCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents colRRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRRDAte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRRTYpe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSupplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
