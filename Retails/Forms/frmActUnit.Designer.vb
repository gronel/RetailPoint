<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActUnit
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgUnit = New System.Windows.Forms.DataGridView
        Me.colCname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnOk = New System.Windows.Forms.Button
        Me.lblcategory = New System.Windows.Forms.Label
        Me.LabelCount = New System.Windows.Forms.Label
        Me.dgrack = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgProductUnit = New System.Windows.Forms.DataGridView
        Me.colUnit = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgrack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgProductUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgUnit
        '
        Me.dgUnit.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgUnit.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgUnit.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUnit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCname})
        Me.dgUnit.Location = New System.Drawing.Point(8, 12)
        Me.dgUnit.Name = "dgUnit"
        Me.dgUnit.RowHeadersWidth = 30
        Me.dgUnit.Size = New System.Drawing.Size(223, 211)
        Me.dgUnit.TabIndex = 13
        '
        'colCname
        '
        Me.colCname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCname.DataPropertyName = "Unit"
        Me.colCname.FillWeight = 150.3749!
        Me.colCname.HeaderText = "Unit"
        Me.colCname.MinimumWidth = 100
        Me.colCname.Name = "colCname"
        '
        'btnOk
        '
        Me.btnOk.Image = Global.Retails.My.Resources.Resources.server_ok
        Me.btnOk.Location = New System.Drawing.Point(166, 229)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(65, 23)
        Me.btnOk.TabIndex = 76
        Me.btnOk.Text = "OK"
        Me.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lblcategory
        '
        Me.lblcategory.AutoSize = True
        Me.lblcategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblcategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.Location = New System.Drawing.Point(87, 228)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(16, 16)
        Me.lblcategory.TabIndex = 79
        Me.lblcategory.Text = "0"
        '
        'LabelCount
        '
        Me.LabelCount.AutoSize = True
        Me.LabelCount.Location = New System.Drawing.Point(5, 229)
        Me.LabelCount.Name = "LabelCount"
        Me.LabelCount.Size = New System.Drawing.Size(82, 13)
        Me.LabelCount.TabIndex = 78
        Me.LabelCount.Text = "No. of Records:"
        '
        'dgrack
        '
        Me.dgrack.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgrack.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgrack.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgrack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrack.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2})
        Me.dgrack.Location = New System.Drawing.Point(8, 12)
        Me.dgrack.Name = "dgrack"
        Me.dgrack.RowHeadersWidth = 30
        Me.dgrack.Size = New System.Drawing.Size(223, 210)
        Me.dgrack.TabIndex = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "RackNo"
        Me.DataGridViewTextBoxColumn2.FillWeight = 150.3749!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Rack No"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'dgProductUnit
        '
        Me.dgProductUnit.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgProductUnit.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgProductUnit.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgProductUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductUnit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colUnit})
        Me.dgProductUnit.Location = New System.Drawing.Point(8, 12)
        Me.dgProductUnit.Name = "dgProductUnit"
        Me.dgProductUnit.RowHeadersWidth = 30
        Me.dgProductUnit.Size = New System.Drawing.Size(223, 211)
        Me.dgProductUnit.TabIndex = 81
        '
        'colUnit
        '
        Me.colUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colUnit.DataPropertyName = "Unit"
        Me.colUnit.FillWeight = 150.3749!
        Me.colUnit.HeaderText = "Unit"
        Me.colUnit.MinimumWidth = 100
        Me.colUnit.Name = "colUnit"
        '
        'frmActUnit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(239, 264)
        Me.Controls.Add(Me.dgProductUnit)
        Me.Controls.Add(Me.lblcategory)
        Me.Controls.Add(Me.LabelCount)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.dgUnit)
        Me.Controls.Add(Me.dgrack)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActUnit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unit"
        CType(Me.dgUnit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgrack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgProductUnit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgUnit As System.Windows.Forms.DataGridView
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents LabelCount As System.Windows.Forms.Label
    Friend WithEvents dgrack As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgProductUnit As System.Windows.Forms.DataGridView
    Friend WithEvents colUnit As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
