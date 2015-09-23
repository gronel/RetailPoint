<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_100_WRList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_100_WRList))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgList = New System.Windows.Forms.DataGridView
        Me.tsPagination = New System.Windows.Forms.ToolStrip
        Me.tsPageSize = New System.Windows.Forms.ToolStripButton
        Me.tsFirst = New System.Windows.Forms.ToolStripButton
        Me.tsPrev = New System.Windows.Forms.ToolStripButton
        Me.tsPage = New System.Windows.Forms.ToolStripLabel
        Me.tsNext = New System.Windows.Forms.ToolStripButton
        Me.tsLast = New System.Windows.Forms.ToolStripButton
        Me.tsRecordCount = New System.Windows.Forms.ToolStripLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.picLogo = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.colWRNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WithdrawalDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DepartmentCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SectionCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.coltotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsPagination.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colWRNo, Me.WithdrawalDate, Me.DepartmentCode, Me.SectionCode, Me.LineCode, Me.Column1, Me.coltotal})
        Me.dgList.Location = New System.Drawing.Point(15, 42)
        Me.dgList.MultiSelect = False
        Me.dgList.Name = "dgList"
        Me.dgList.ReadOnly = True
        Me.dgList.RowHeadersWidth = 25
        Me.dgList.Size = New System.Drawing.Size(832, 375)
        Me.dgList.TabIndex = 39
        '
        'tsPagination
        '
        Me.tsPagination.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsPagination.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPageSize, Me.tsFirst, Me.tsPrev, Me.tsPage, Me.tsNext, Me.tsLast, Me.tsRecordCount})
        Me.tsPagination.Location = New System.Drawing.Point(0, 420)
        Me.tsPagination.Name = "tsPagination"
        Me.tsPagination.Size = New System.Drawing.Size(859, 25)
        Me.tsPagination.TabIndex = 41
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
        Me.lblTitle.Location = New System.Drawing.Point(153, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(329, 33)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Withdrawal Report List"
        '
        'colWRNo
        '
        Me.colWRNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colWRNo.DataPropertyName = "WRNo"
        Me.colWRNo.HeaderText = "WR No."
        Me.colWRNo.MinimumWidth = 100
        Me.colWRNo.Name = "colWRNo"
        Me.colWRNo.ReadOnly = True
        Me.colWRNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'WithdrawalDate
        '
        Me.WithdrawalDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.WithdrawalDate.DataPropertyName = "WithdrawalDate"
        Me.WithdrawalDate.HeaderText = "Withdrawal Date"
        Me.WithdrawalDate.MinimumWidth = 100
        Me.WithdrawalDate.Name = "WithdrawalDate"
        Me.WithdrawalDate.ReadOnly = True
        Me.WithdrawalDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DepartmentCode
        '
        Me.DepartmentCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DepartmentCode.DataPropertyName = "DepartmentCode"
        Me.DepartmentCode.HeaderText = "Department Code"
        Me.DepartmentCode.MinimumWidth = 100
        Me.DepartmentCode.Name = "DepartmentCode"
        Me.DepartmentCode.ReadOnly = True
        Me.DepartmentCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SectionCode
        '
        Me.SectionCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SectionCode.DataPropertyName = "SectionCode"
        Me.SectionCode.HeaderText = "Section Code"
        Me.SectionCode.MinimumWidth = 100
        Me.SectionCode.Name = "SectionCode"
        Me.SectionCode.ReadOnly = True
        Me.SectionCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LineCode
        '
        Me.LineCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LineCode.DataPropertyName = "LineCode"
        Me.LineCode.HeaderText = "Line Code"
        Me.LineCode.MinimumWidth = 100
        Me.LineCode.Name = "LineCode"
        Me.LineCode.ReadOnly = True
        Me.LineCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.DataPropertyName = "ctype"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.PowderBlue
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.FillWeight = 40.0!
        Me.Column1.HeaderText = ""
        Me.Column1.MinimumWidth = 40
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'coltotal
        '
        Me.coltotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.coltotal.DataPropertyName = "total"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle3.NullValue = Nothing
        Me.coltotal.DefaultCellStyle = DataGridViewCellStyle3
        Me.coltotal.HeaderText = "Converted Total Amount"
        Me.coltotal.MinimumWidth = 100
        Me.coltotal.Name = "coltotal"
        Me.coltotal.ReadOnly = True
        Me.coltotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'frm_100_WRList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 445)
        Me.Controls.Add(Me.tsPagination)
        Me.Controls.Add(Me.dgList)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frm_100_WRList"
        Me.Text = "frm_000_Item"
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsPagination.ResumeLayout(False)
        Me.tsPagination.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents colWRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WithdrawalDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepartmentCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SectionCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coltotal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
