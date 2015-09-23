<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_search_emp
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblCountSub = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgdetails = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.colProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgdetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblCountSub)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Location = New System.Drawing.Point(5, 406)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(142, 22)
        Me.Panel2.TabIndex = 81
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgdetails)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(651, 366)
        Me.GroupBox1.TabIndex = 80
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employee List"
        '
        'dgdetails
        '
        Me.dgdetails.AllowUserToAddRows = False
        Me.dgdetails.AllowUserToDeleteRows = False
        Me.dgdetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgdetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.colProductCode, Me.colProductName, Me.colPartNo, Me.colQty, Me.Column2, Me.Column3})
        Me.dgdetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdetails.Location = New System.Drawing.Point(3, 16)
        Me.dgdetails.Name = "dgdetails"
        Me.dgdetails.RowHeadersVisible = False
        Me.dgdetails.RowHeadersWidth = 25
        Me.dgdetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdetails.Size = New System.Drawing.Size(645, 347)
        Me.dgdetails.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Text = "..."
        Me.Column1.Width = 30
        '
        'colProductCode
        '
        Me.colProductCode.HeaderText = "Employee ID"
        Me.colProductCode.Name = "colProductCode"
        Me.colProductCode.ReadOnly = True
        '
        'colProductName
        '
        Me.colProductName.HeaderText = "Employee Name"
        Me.colProductName.Name = "colProductName"
        Me.colProductName.ReadOnly = True
        Me.colProductName.Width = 110
        '
        'colPartNo
        '
        Me.colPartNo.HeaderText = "Designation"
        Me.colPartNo.Name = "colPartNo"
        Me.colPartNo.ReadOnly = True
        '
        'colQty
        '
        Me.colQty.HeaderText = "Dept. Code"
        Me.colQty.Name = "colQty"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Section Code"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Line Code"
        Me.Column3.Name = "Column3"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(220, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Value"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValue
        '
        Me.txtValue.Enabled = False
        Me.txtValue.Location = New System.Drawing.Point(275, 8)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(137, 20)
        Me.txtValue.TabIndex = 78
        '
        'cboCategory
        '
        Me.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"All", "Employee ID", "Employee Name", "Designation", "Dept Code", "Section Code", "Line Code"})
        Me.cboCategory.Location = New System.Drawing.Point(63, 8)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(137, 21)
        Me.cboCategory.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Category"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_search_emp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 437)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_search_emp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Employee"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgdetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCountSub As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgdetails As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
