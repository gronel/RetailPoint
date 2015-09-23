<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Search_WR
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
        Me.dgdetailsWR = New System.Windows.Forms.DataGridView
        Me.colcheckWR = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colSpecificCodeWR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chckall = New System.Windows.Forms.CheckBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblCountSub = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgdetailsWR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdetailsWR
        '
        Me.dgdetailsWR.AllowUserToAddRows = False
        Me.dgdetailsWR.AllowUserToDeleteRows = False
        Me.dgdetailsWR.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgdetailsWR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdetailsWR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdetailsWR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdetailsWR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colcheckWR, Me.colSpecificCodeWR, Me.DataGridViewTextBoxColumn6, Me.Column2, Me.Column1, Me.DataGridViewTextBoxColumn7, Me.Column3, Me.Column4})
        Me.dgdetailsWR.Location = New System.Drawing.Point(8, 44)
        Me.dgdetailsWR.Name = "dgdetailsWR"
        Me.dgdetailsWR.RowHeadersVisible = False
        Me.dgdetailsWR.RowHeadersWidth = 25
        Me.dgdetailsWR.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgdetailsWR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdetailsWR.Size = New System.Drawing.Size(785, 353)
        Me.dgdetailsWR.TabIndex = 4
        '
        'colcheckWR
        '
        Me.colcheckWR.FalseValue = "0"
        Me.colcheckWR.HeaderText = ""
        Me.colcheckWR.IndeterminateValue = "0"
        Me.colcheckWR.Name = "colcheckWR"
        Me.colcheckWR.TrueValue = "1"
        Me.colcheckWR.Width = 30
        '
        'colSpecificCodeWR
        '
        Me.colSpecificCodeWR.DataPropertyName = "SpecificCode"
        Me.colSpecificCodeWR.HeaderText = "Specific Code"
        Me.colSpecificCodeWR.Name = "colSpecificCodeWR"
        Me.colSpecificCodeWR.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "SpecificDescription"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Item Specific Description"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 190
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "BrandType"
        Me.Column2.HeaderText = "Brand/Lens Type"
        Me.Column2.Name = "Column2"
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Quantity"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "n2"
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "Total QTY BAL"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 120
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "InventoryUOM"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Converted Unit"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "RRNo"
        Me.Column3.HeaderText = "RR No. "
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "RRDate"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "RR Date "
        Me.Column4.Name = "Column4"
        '
        'chckall
        '
        Me.chckall.AutoSize = True
        Me.chckall.Location = New System.Drawing.Point(652, 410)
        Me.chckall.Name = "chckall"
        Me.chckall.Size = New System.Drawing.Size(70, 17)
        Me.chckall.TabIndex = 78
        Me.chckall.Text = "Check all"
        Me.chckall.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Image = Global.Retails.My.Resources.Resources.server_ok
        Me.btnOk.Location = New System.Drawing.Point(728, 404)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(65, 23)
        Me.btnOk.TabIndex = 77
        Me.btnOk.Text = "Ok"
        Me.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblCountSub)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Location = New System.Drawing.Point(12, 405)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(142, 22)
        Me.Panel2.TabIndex = 76
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Value"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(63, 21)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(137, 20)
        Me.txtValue.TabIndex = 81
        '
        'cboCategory
        '
        Me.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"Specific Code", "Item Specific Description", "Brand/Lens", "UOM", "RR #.", "RR Date"})
        Me.cboCategory.Location = New System.Drawing.Point(63, 1)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(137, 21)
        Me.cboCategory.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Category"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_Search_WR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 439)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chckall)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgdetailsWR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Search_WR"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Item(s)"
        CType(Me.dgdetailsWR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdetailsWR As System.Windows.Forms.DataGridView
    Friend WithEvents chckall As System.Windows.Forms.CheckBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCountSub As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents colcheckWR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colSpecificCodeWR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
