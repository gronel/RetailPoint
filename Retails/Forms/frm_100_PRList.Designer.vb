<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_100_PRList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_100_PRList))
        Me.dgList = New System.Windows.Forms.DataGridView
        Me.colPRNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colReqDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDeptname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSectionName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLIneName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRequestor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSupplier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPOType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDateNeeded = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPlacementDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.picLogo = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.tsPagination = New System.Windows.Forms.ToolStrip
        Me.tsPageSize = New System.Windows.Forms.ToolStripButton
        Me.tsFirst = New System.Windows.Forms.ToolStripButton
        Me.tsPrev = New System.Windows.Forms.ToolStripButton
        Me.tsPage = New System.Windows.Forms.ToolStripLabel
        Me.tsNext = New System.Windows.Forms.ToolStripButton
        Me.tsLast = New System.Windows.Forms.ToolStripButton
        Me.tsRecordCount = New System.Windows.Forms.ToolStripLabel
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsPagination.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgList
        '
        Me.dgList.AllowUserToAddRows = False
        Me.dgList.AllowUserToDeleteRows = False
        Me.dgList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgList.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPRNo, Me.colReqDate, Me.colDeptname, Me.colSectionName, Me.colLIneName, Me.colRequestor, Me.colSupplier, Me.colPOType, Me.colDateNeeded, Me.colPlacementDate, Me.Column1, Me.colAmount})
        Me.dgList.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.dgList.Location = New System.Drawing.Point(15, 42)
        Me.dgList.Name = "dgList"
        Me.dgList.ReadOnly = True
        Me.dgList.RowHeadersWidth = 25
        Me.dgList.Size = New System.Drawing.Size(832, 370)
        Me.dgList.TabIndex = 39
        '
        'colPRNo
        '
        Me.colPRNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPRNo.DataPropertyName = "PRNo"
        Me.colPRNo.HeaderText = "PR No."
        Me.colPRNo.MinimumWidth = 100
        Me.colPRNo.Name = "colPRNo"
        Me.colPRNo.ReadOnly = True
        Me.colPRNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colReqDate
        '
        Me.colReqDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colReqDate.DataPropertyName = "DateRequested"
        Me.colReqDate.HeaderText = "Date Requested"
        Me.colReqDate.MinimumWidth = 100
        Me.colReqDate.Name = "colReqDate"
        Me.colReqDate.ReadOnly = True
        Me.colReqDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colDeptname
        '
        Me.colDeptname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDeptname.DataPropertyName = "DepartmentName"
        Me.colDeptname.HeaderText = "Department"
        Me.colDeptname.MinimumWidth = 100
        Me.colDeptname.Name = "colDeptname"
        Me.colDeptname.ReadOnly = True
        Me.colDeptname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colSectionName
        '
        Me.colSectionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSectionName.DataPropertyName = "SectionName"
        Me.colSectionName.HeaderText = "Section"
        Me.colSectionName.MinimumWidth = 100
        Me.colSectionName.Name = "colSectionName"
        Me.colSectionName.ReadOnly = True
        Me.colSectionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colLIneName
        '
        Me.colLIneName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colLIneName.DataPropertyName = "LineName"
        Me.colLIneName.HeaderText = "Line Name"
        Me.colLIneName.MinimumWidth = 100
        Me.colLIneName.Name = "colLIneName"
        Me.colLIneName.ReadOnly = True
        Me.colLIneName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colRequestor
        '
        Me.colRequestor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colRequestor.DataPropertyName = "RequestedBy"
        Me.colRequestor.HeaderText = "Requested By"
        Me.colRequestor.MinimumWidth = 100
        Me.colRequestor.Name = "colRequestor"
        Me.colRequestor.ReadOnly = True
        Me.colRequestor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colSupplier
        '
        Me.colSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSupplier.DataPropertyName = "SupplierName"
        Me.colSupplier.HeaderText = "Supplier"
        Me.colSupplier.MinimumWidth = 100
        Me.colSupplier.Name = "colSupplier"
        Me.colSupplier.ReadOnly = True
        Me.colSupplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colPOType
        '
        Me.colPOType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPOType.DataPropertyName = "PRType"
        Me.colPOType.HeaderText = "Type"
        Me.colPOType.MinimumWidth = 100
        Me.colPOType.Name = "colPOType"
        Me.colPOType.ReadOnly = True
        Me.colPOType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colDateNeeded
        '
        Me.colDateNeeded.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDateNeeded.DataPropertyName = "DateNeeded"
        Me.colDateNeeded.HeaderText = "Date Needed"
        Me.colDateNeeded.MinimumWidth = 100
        Me.colDateNeeded.Name = "colDateNeeded"
        Me.colDateNeeded.ReadOnly = True
        Me.colDateNeeded.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colPlacementDate
        '
        Me.colPlacementDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPlacementDate.DataPropertyName = "PORRSchedule"
        Me.colPlacementDate.HeaderText = "PO/RR Schedule"
        Me.colPlacementDate.MinimumWidth = 100
        Me.colPlacementDate.Name = "colPlacementDate"
        Me.colPlacementDate.ReadOnly = True
        Me.colPlacementDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.DataPropertyName = "CurrencyType"
        Me.Column1.FillWeight = 40.0!
        Me.Column1.HeaderText = ""
        Me.Column1.MinimumWidth = 40
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colAmount
        '
        Me.colAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAmount.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle2
        Me.colAmount.HeaderText = "Total Amount"
        Me.colAmount.MinimumWidth = 100
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
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
        Me.lblTitle.Location = New System.Drawing.Point(164, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(356, 33)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Purchase Requisition List"
        '
        'tsPagination
        '
        Me.tsPagination.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsPagination.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPageSize, Me.tsFirst, Me.tsPrev, Me.tsPage, Me.tsNext, Me.tsLast, Me.tsRecordCount})
        Me.tsPagination.Location = New System.Drawing.Point(0, 420)
        Me.tsPagination.Name = "tsPagination"
        Me.tsPagination.Size = New System.Drawing.Size(859, 25)
        Me.tsPagination.TabIndex = 42
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
        'frm_100_PRList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 445)
        Me.Controls.Add(Me.tsPagination)
        Me.Controls.Add(Me.dgList)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frm_100_PRList"
        Me.Text = "frm_000_Item"
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsPagination.ResumeLayout(False)
        Me.tsPagination.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgList As System.Windows.Forms.DataGridView
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents tsPagination As System.Windows.Forms.ToolStrip
    Friend WithEvents tsPageSize As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRecordCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents colPRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReqDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDeptname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSectionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLIneName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRequestor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSupplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPOType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDateNeeded As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPlacementDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
