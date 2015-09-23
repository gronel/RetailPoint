<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_100_Reconfirm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_100_Reconfirm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsAdd = New System.Windows.Forms.ToolStripButton
        Me.tsEdit = New System.Windows.Forms.ToolStripButton
        Me.tsDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton
        Me.tsSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.tsSave = New System.Windows.Forms.ToolStripButton
        Me.tsCancel = New System.Windows.Forms.ToolStripButton
        Me.dgdetails = New System.Windows.Forms.DataGridView
        Me.colDate = New Retails.clsDateCalendarColumn
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tsMenu.SuspendLayout()
        CType(Me.dgdetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAdd, Me.tsEdit, Me.tsDelete, Me.ToolStripSeparator1, Me.tsRefresh, Me.tsSeparator, Me.tsSave, Me.tsCancel})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(586, 25)
        Me.tsMenu.TabIndex = 25
        Me.tsMenu.Text = "ToolStrip1"
        '
        'tsAdd
        '
        Me.tsAdd.Image = CType(resources.GetObject("tsAdd.Image"), System.Drawing.Image)
        Me.tsAdd.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsAdd.Name = "tsAdd"
        Me.tsAdd.Size = New System.Drawing.Size(46, 22)
        Me.tsAdd.Tag = "isAdd"
        Me.tsAdd.Text = "&Add"
        '
        'tsEdit
        '
        Me.tsEdit.Image = CType(resources.GetObject("tsEdit.Image"), System.Drawing.Image)
        Me.tsEdit.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsEdit.Name = "tsEdit"
        Me.tsEdit.Size = New System.Drawing.Size(45, 22)
        Me.tsEdit.Tag = "isEdit"
        Me.tsEdit.Text = "&Edit"
        '
        'tsDelete
        '
        Me.tsDelete.Image = CType(resources.GetObject("tsDelete.Image"), System.Drawing.Image)
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(58, 22)
        Me.tsDelete.Tag = "isDelete"
        Me.tsDelete.Text = "&Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsRefresh
        '
        Me.tsRefresh.Image = CType(resources.GetObject("tsRefresh.Image"), System.Drawing.Image)
        Me.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefresh.Name = "tsRefresh"
        Me.tsRefresh.Size = New System.Drawing.Size(65, 22)
        Me.tsRefresh.Text = "&Refresh"
        '
        'tsSeparator
        '
        Me.tsSeparator.Name = "tsSeparator"
        Me.tsSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'tsSave
        '
        Me.tsSave.Image = CType(resources.GetObject("tsSave.Image"), System.Drawing.Image)
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(51, 22)
        Me.tsSave.Text = "&Save"
        '
        'tsCancel
        '
        Me.tsCancel.Image = CType(resources.GetObject("tsCancel.Image"), System.Drawing.Image)
        Me.tsCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCancel.Name = "tsCancel"
        Me.tsCancel.Size = New System.Drawing.Size(59, 22)
        Me.tsCancel.Text = "&Cancel"
        '
        'dgdetails
        '
        Me.dgdetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgdetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdetails.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDate, Me.colQuantity, Me.colRemarks})
        Me.dgdetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdetails.Location = New System.Drawing.Point(0, 25)
        Me.dgdetails.Name = "dgdetails"
        Me.dgdetails.RowHeadersVisible = False
        Me.dgdetails.Size = New System.Drawing.Size(586, 293)
        Me.dgdetails.TabIndex = 26
        '
        'colDate
        '
        Me.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDate.HeaderText = "Confirmation Date"
        Me.colDate.Name = "colDate"
        '
        'colQuantity
        '
        Me.colQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colQuantity.HeaderText = "Target Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colRemarks
        '
        Me.colRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'frm_100_Reconfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 318)
        Me.Controls.Add(Me.dgdetails)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_100_Reconfirm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirmation"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        CType(Me.dgdetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgdetails As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colDate As Retails.clsDateCalendarColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
