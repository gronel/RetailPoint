<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_000_UserRights
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_000_UserRights))
        Me.dgRights = New System.Windows.Forms.DataGridView()
        Me.colMenuID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colFormName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        CType(Me.dgRights, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgRights
        '
        Me.dgRights.AllowUserToAddRows = False
        Me.dgRights.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgRights.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgRights.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgRights.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgRights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgRights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRights.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMenuID, Me.colSelect, Me.colFormName})
        Me.dgRights.Location = New System.Drawing.Point(12, 12)
        Me.dgRights.MultiSelect = False
        Me.dgRights.Name = "dgRights"
        Me.dgRights.RowHeadersVisible = False
        Me.dgRights.RowHeadersWidth = 25
        Me.dgRights.Size = New System.Drawing.Size(502, 268)
        Me.dgRights.TabIndex = 2
        '
        'colMenuID
        '
        Me.colMenuID.DataPropertyName = "MenuID"
        Me.colMenuID.HeaderText = "MenuID"
        Me.colMenuID.Name = "colMenuID"
        Me.colMenuID.ReadOnly = True
        Me.colMenuID.Visible = False
        '
        'colSelect
        '
        Me.colSelect.HeaderText = ""
        Me.colSelect.Name = "colSelect"
        Me.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSelect.Width = 40
        '
        'colFormName
        '
        Me.colFormName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFormName.DataPropertyName = "FormName"
        Me.colFormName.HeaderText = "Entry/Report"
        Me.colFormName.MinimumWidth = 100
        Me.colFormName.Name = "colFormName"
        Me.colFormName.ReadOnly = True
        '
        'btnDone
        '
        Me.btnDone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDone.Image = CType(resources.GetObject("btnDone.Image"), System.Drawing.Image)
        Me.btnDone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDone.Location = New System.Drawing.Point(440, 286)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(74, 24)
        Me.btnDone.TabIndex = 3
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSelectAll.Location = New System.Drawing.Point(12, 286)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(71, 24)
        Me.btnSelectAll.TabIndex = 4
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'frm_000_UserRights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.ClientSize = New System.Drawing.Size(526, 322)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.dgRights)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_000_UserRights"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Rights"
        CType(Me.dgRights, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgRights As System.Windows.Forms.DataGridView
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents colMenuID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colFormName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
