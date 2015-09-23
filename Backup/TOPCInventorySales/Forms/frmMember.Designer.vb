<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMember
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.dgSearchMembers = New System.Windows.Forms.DataGridView
        Me.colID = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMemberStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblno = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgSearchMembers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnOk)
        Me.GroupBox3.Controls.Add(Me.dgSearchMembers)
        Me.GroupBox3.Controls.Add(Me.Panel3)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(369, 277)
        Me.GroupBox3.TabIndex = 69
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Accountable Member Details"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Image = Global.TOPCInventorySales.My.Resources.Resources.server_ok
        Me.btnOk.Location = New System.Drawing.Point(288, 249)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(65, 23)
        Me.btnOk.TabIndex = 76
        Me.btnOk.Text = "Ok"
        Me.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'dgSearchMembers
        '
        Me.dgSearchMembers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSearchMembers.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgSearchMembers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgSearchMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSearchMembers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colMemberName, Me.colMemberStatus})
        Me.dgSearchMembers.Location = New System.Drawing.Point(13, 14)
        Me.dgSearchMembers.MultiSelect = False
        Me.dgSearchMembers.Name = "dgSearchMembers"
        Me.dgSearchMembers.RowHeadersWidth = 25
        Me.dgSearchMembers.Size = New System.Drawing.Size(341, 229)
        Me.dgSearchMembers.TabIndex = 9
        '
        'colID
        '
        Me.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colID.DataPropertyName = "UserID"
        Me.colID.HeaderText = "User ID."
        Me.colID.MinimumWidth = 100
        Me.colID.Name = "colID"
        Me.colID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colMemberName
        '
        Me.colMemberName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colMemberName.DataPropertyName = "EmpName"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colMemberName.DefaultCellStyle = DataGridViewCellStyle1
        Me.colMemberName.HeaderText = "Accountable Member/Name"
        Me.colMemberName.MinimumWidth = 100
        Me.colMemberName.Name = "colMemberName"
        Me.colMemberName.ReadOnly = True
        '
        'colMemberStatus
        '
        Me.colMemberStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colMemberStatus.DefaultCellStyle = DataGridViewCellStyle2
        Me.colMemberStatus.HeaderText = "Employee Status"
        Me.colMemberStatus.MinimumWidth = 100
        Me.colMemberStatus.Name = "colMemberStatus"
        Me.colMemberStatus.ReadOnly = True
        Me.colMemberStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.lblno)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Location = New System.Drawing.Point(13, 249)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(142, 22)
        Me.Panel3.TabIndex = 72
        '
        'lblno
        '
        Me.lblno.AutoSize = True
        Me.lblno.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblno.Location = New System.Drawing.Point(86, 4)
        Me.lblno.Name = "lblno"
        Me.lblno.Size = New System.Drawing.Size(16, 16)
        Me.lblno.TabIndex = 1
        Me.lblno.Text = "0"
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
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "UserID"
        Me.DataGridViewComboBoxColumn1.HeaderText = "User ID."
        Me.DataGridViewComboBoxColumn1.MinimumWidth = 100
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmMember
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 312)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMember"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Member(s)"
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgSearchMembers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgSearchMembers As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblno As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents colID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
