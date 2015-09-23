<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SearchProduct
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SearchProduct))
        Me.btnOk = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblCountSub = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.checkall = New System.Windows.Forms.CheckBox
        Me.dgdetails = New System.Windows.Forms.DataGridView
        Me.cboOrderno = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colOrderNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colOrderType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPartName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUnit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colorderbal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPriceID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2.SuspendLayout()
        CType(Me.dgdetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Image = Global.TOPCInventorySales.My.Resources.Resources.server_ok
        Me.btnOk.Location = New System.Drawing.Point(666, 381)
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
        Me.checkall.Location = New System.Drawing.Point(570, 381)
        Me.checkall.Name = "checkall"
        Me.checkall.Size = New System.Drawing.Size(71, 17)
        Me.checkall.TabIndex = 79
        Me.checkall.Text = "Check All"
        Me.checkall.UseVisualStyleBackColor = True
        '
        'dgdetails
        '
        Me.dgdetails.AllowUserToAddRows = False
        Me.dgdetails.AllowUserToDeleteRows = False
        Me.dgdetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgdetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheck, Me.colOrderNum, Me.colOrderType, Me.colProductCode, Me.colPartNo, Me.colPartName, Me.colQuantity, Me.colUnit, Me.colorderbal, Me.colPriceID})
        Me.dgdetails.Location = New System.Drawing.Point(8, 39)
        Me.dgdetails.Name = "dgdetails"
        Me.dgdetails.RowHeadersVisible = False
        Me.dgdetails.RowHeadersWidth = 25
        Me.dgdetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdetails.Size = New System.Drawing.Size(727, 336)
        Me.dgdetails.TabIndex = 82
        '
        'cboOrderno
        '
        Me.cboOrderno.FormattingEnabled = True
        Me.cboOrderno.Location = New System.Drawing.Point(74, 12)
        Me.cboOrderno.Name = "cboOrderno"
        Me.cboOrderno.Size = New System.Drawing.Size(144, 21)
        Me.cboOrderno.TabIndex = 83
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Order No.:"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Order No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Order Type"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Product Code"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "Part No."
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.HeaderText = "Part Name"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn6.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn8.HeaderText = "Order Bal. Qty "
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "PriceID"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'colCheck
        '
        Me.colCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCheck.FalseValue = "0"
        Me.colCheck.FillWeight = 40.0!
        Me.colCheck.HeaderText = ""
        Me.colCheck.IndeterminateValue = "0"
        Me.colCheck.Name = "colCheck"
        Me.colCheck.TrueValue = "1"
        '
        'colOrderNum
        '
        Me.colOrderNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colOrderNum.HeaderText = "Order No"
        Me.colOrderNum.Name = "colOrderNum"
        Me.colOrderNum.ReadOnly = True
        Me.colOrderNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colOrderNum.Visible = False
        '
        'colOrderType
        '
        Me.colOrderType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colOrderType.HeaderText = "Order Type"
        Me.colOrderType.Name = "colOrderType"
        Me.colOrderType.ReadOnly = True
        Me.colOrderType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colProductCode
        '
        Me.colProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colProductCode.HeaderText = "Product Code"
        Me.colProductCode.Name = "colProductCode"
        Me.colProductCode.ReadOnly = True
        Me.colProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colPartNo
        '
        Me.colPartNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPartNo.HeaderText = "Part No."
        Me.colPartNo.Name = "colPartNo"
        Me.colPartNo.ReadOnly = True
        Me.colPartNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colPartName
        '
        Me.colPartName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPartName.HeaderText = "Part Name"
        Me.colPartName.Name = "colPartName"
        Me.colPartName.ReadOnly = True
        Me.colPartName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colQuantity
        '
        Me.colQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colQuantity.HeaderText = "Order Qty"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colUnit
        '
        Me.colUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colUnit.HeaderText = "Unit"
        Me.colUnit.Name = "colUnit"
        Me.colUnit.ReadOnly = True
        Me.colUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colorderbal
        '
        Me.colorderbal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colorderbal.DefaultCellStyle = DataGridViewCellStyle3
        Me.colorderbal.HeaderText = "Order Bal. Qty "
        Me.colorderbal.Name = "colorderbal"
        Me.colorderbal.ReadOnly = True
        '
        'colPriceID
        '
        Me.colPriceID.HeaderText = "PriceID"
        Me.colPriceID.Name = "colPriceID"
        Me.colPriceID.ReadOnly = True
        Me.colPriceID.Visible = False
        '
        'frm_SearchProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 412)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboOrderno)
        Me.Controls.Add(Me.checkall)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.dgdetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SearchProduct"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Product(s)"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgdetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCountSub As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents checkall As System.Windows.Forms.CheckBox
    Friend WithEvents dgdetails As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboOrderno As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colOrderNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colorderbal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPriceID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
