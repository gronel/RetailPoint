<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Searchitem
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Searchitem))
        Me.dgSearchItems = New System.Windows.Forms.DataGridView
        Me.btnOk = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblCountSub = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.checkall = New System.Windows.Forms.CheckBox
        Me.cbocontrolnum = New System.Windows.Forms.ComboBox
        Me.lblcontrolnum = New System.Windows.Forms.Label
        Me.dgDetailsAR = New System.Windows.Forms.DataGridView
        Me.CheckAR = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSpecificCodeAR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCheckAdd = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colSpecificCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSpecificDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRRQTY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.coldec = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgSearchItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgDetailsAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgSearchItems
        '
        Me.dgSearchItems.AllowUserToAddRows = False
        Me.dgSearchItems.AllowUserToDeleteRows = False
        Me.dgSearchItems.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgSearchItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSearchItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSearchItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSearchItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheckAdd, Me.colSpecificCode, Me.colSpecificDescription, Me.Column1, Me.colRRQTY, Me.colAOM, Me.coldec})
        Me.dgSearchItems.Location = New System.Drawing.Point(8, 36)
        Me.dgSearchItems.Name = "dgSearchItems"
        Me.dgSearchItems.RowHeadersVisible = False
        Me.dgSearchItems.RowHeadersWidth = 25
        Me.dgSearchItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSearchItems.Size = New System.Drawing.Size(533, 339)
        Me.dgSearchItems.TabIndex = 1
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Image = Global.Retails.My.Resources.Resources.server_ok
        Me.btnOk.Location = New System.Drawing.Point(474, 381)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(65, 23)
        Me.btnOk.TabIndex = 75
        Me.btnOk.Text = "Ok"
        Me.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblCountSub)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Location = New System.Drawing.Point(8, 382)
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
        'checkall
        '
        Me.checkall.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.checkall.AutoSize = True
        Me.checkall.Location = New System.Drawing.Point(378, 381)
        Me.checkall.Name = "checkall"
        Me.checkall.Size = New System.Drawing.Size(71, 17)
        Me.checkall.TabIndex = 79
        Me.checkall.Text = "Check All"
        Me.checkall.UseVisualStyleBackColor = True
        '
        'cbocontrolnum
        '
        Me.cbocontrolnum.FormattingEnabled = True
        Me.cbocontrolnum.Location = New System.Drawing.Point(58, 9)
        Me.cbocontrolnum.Name = "cbocontrolnum"
        Me.cbocontrolnum.Size = New System.Drawing.Size(151, 21)
        Me.cbocontrolnum.TabIndex = 80
        '
        'lblcontrolnum
        '
        Me.lblcontrolnum.AutoSize = True
        Me.lblcontrolnum.Location = New System.Drawing.Point(12, 12)
        Me.lblcontrolnum.Name = "lblcontrolnum"
        Me.lblcontrolnum.Size = New System.Drawing.Size(35, 13)
        Me.lblcontrolnum.TabIndex = 81
        Me.lblcontrolnum.Text = "PR #:"
        '
        'dgDetailsAR
        '
        Me.dgDetailsAR.AllowUserToAddRows = False
        Me.dgDetailsAR.AllowUserToDeleteRows = False
        Me.dgDetailsAR.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgDetailsAR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgDetailsAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetailsAR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CheckAR, Me.colSpecificCodeAR, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.dgDetailsAR.Location = New System.Drawing.Point(8, 36)
        Me.dgDetailsAR.Name = "dgDetailsAR"
        Me.dgDetailsAR.RowHeadersVisible = False
        Me.dgDetailsAR.RowHeadersWidth = 25
        Me.dgDetailsAR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDetailsAR.Size = New System.Drawing.Size(533, 339)
        Me.dgDetailsAR.TabIndex = 82
        Me.dgDetailsAR.Visible = False
        '
        'CheckAR
        '
        Me.CheckAR.FalseValue = "0"
        Me.CheckAR.HeaderText = ""
        Me.CheckAR.IndeterminateValue = "0"
        Me.CheckAR.Name = "CheckAR"
        Me.CheckAR.TrueValue = "1"
        Me.CheckAR.Width = 30
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "SpecificCode"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Specific Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ItemCode"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Item Code"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "SpecificDescription"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 130
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Quantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.HeaderText = "QTY"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ActualUOM"
        Me.DataGridViewTextBoxColumn5.HeaderText = "UOM"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "SpecificCode"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Specific Code"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "SpecificDescription"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Item Specific Description"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 130
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "BrandType"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Brand/Lens Type "
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "n2"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn9.HeaderText = "QTY"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "ActualUOM"
        Me.DataGridViewTextBoxColumn10.HeaderText = "UOM"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn11.HeaderText = "Column2"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'colSpecificCodeAR
        '
        Me.colSpecificCodeAR.DataPropertyName = "SpecificCode"
        Me.colSpecificCodeAR.HeaderText = "Specific Code"
        Me.colSpecificCodeAR.Name = "colSpecificCodeAR"
        Me.colSpecificCodeAR.ReadOnly = True
        '
        'colCheckAdd
        '
        Me.colCheckAdd.FalseValue = "0"
        Me.colCheckAdd.HeaderText = ""
        Me.colCheckAdd.IndeterminateValue = "0"
        Me.colCheckAdd.Name = "colCheckAdd"
        Me.colCheckAdd.TrueValue = "1"
        Me.colCheckAdd.Width = 30
        '
        'colSpecificCode
        '
        Me.colSpecificCode.DataPropertyName = "SpecificCode"
        Me.colSpecificCode.HeaderText = "Specific Code"
        Me.colSpecificCode.Name = "colSpecificCode"
        Me.colSpecificCode.ReadOnly = True
        '
        'colSpecificDescription
        '
        Me.colSpecificDescription.DataPropertyName = "SpecificDescription"
        Me.colSpecificDescription.HeaderText = "Item Specific Description"
        Me.colSpecificDescription.Name = "colSpecificDescription"
        Me.colSpecificDescription.ReadOnly = True
        Me.colSpecificDescription.Width = 130
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "BrandType"
        Me.Column1.HeaderText = "Brand/Lens Type "
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'colRRQTY
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "n2"
        Me.colRRQTY.DefaultCellStyle = DataGridViewCellStyle2
        Me.colRRQTY.HeaderText = "QTY"
        Me.colRRQTY.Name = "colRRQTY"
        Me.colRRQTY.ReadOnly = True
        '
        'colAOM
        '
        Me.colAOM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAOM.DataPropertyName = "ActualUOM"
        Me.colAOM.HeaderText = "UOM"
        Me.colAOM.Name = "colAOM"
        Me.colAOM.ReadOnly = True
        '
        'coldec
        '
        Me.coldec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.coldec.HeaderText = "Column2"
        Me.coldec.Name = "coldec"
        Me.coldec.Visible = False
        '
        'frm_Searchitem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 412)
        Me.Controls.Add(Me.lblcontrolnum)
        Me.Controls.Add(Me.cbocontrolnum)
        Me.Controls.Add(Me.checkall)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.dgSearchItems)
        Me.Controls.Add(Me.dgDetailsAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Searchitem"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Item(s)"
        CType(Me.dgSearchItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgDetailsAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgSearchItems As System.Windows.Forms.DataGridView
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCountSub As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents checkall As System.Windows.Forms.CheckBox
    Friend WithEvents cbocontrolnum As System.Windows.Forms.ComboBox
    Friend WithEvents lblcontrolnum As System.Windows.Forms.Label
    Friend WithEvents dgDetailsAR As System.Windows.Forms.DataGridView
    Friend WithEvents CheckAR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colSpecificCodeAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheckAdd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colSpecificCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSpecificDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRRQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coldec As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
