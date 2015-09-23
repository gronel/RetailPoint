<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_000_EditUPrice
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
        Me.components = New System.ComponentModel.Container
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbodec = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtunitprice = New System.Windows.Forms.TextBox
        Me.btnsave = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblcountTran = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgdetailsOrder = New System.Windows.Forms.DataGridView
        Me.colOrder = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgdetailsDR = New System.Windows.Forms.DataGridView
        Me.colDRNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgdetailsOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgdetailsDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbodec)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtunitprice)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 121)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cbodec
        '
        Me.cbodec.FormattingEnabled = True
        Me.cbodec.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.cbodec.Location = New System.Drawing.Point(68, 64)
        Me.cbodec.Name = "cbodec"
        Me.cbodec.Size = New System.Drawing.Size(100, 21)
        Me.cbodec.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Decimal:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Unit Price:"
        '
        'txtunitprice
        '
        Me.txtunitprice.Location = New System.Drawing.Point(68, 30)
        Me.txtunitprice.Name = "txtunitprice"
        Me.txtunitprice.Size = New System.Drawing.Size(100, 20)
        Me.txtunitprice.TabIndex = 1
        Me.txtunitprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(93, 90)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 0
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.btnOK)
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 313)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblcountTran)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(13, 280)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(142, 22)
        Me.Panel2.TabIndex = 42
        Me.Panel2.Visible = False
        '
        'lblcountTran
        '
        Me.lblcountTran.AutoSize = True
        Me.lblcountTran.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblcountTran.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcountTran.Location = New System.Drawing.Point(86, 4)
        Me.lblcountTran.Name = "lblcountTran"
        Me.lblcountTran.Size = New System.Drawing.Size(16, 16)
        Me.lblcountTran.TabIndex = 1
        Me.lblcountTran.Text = "0"
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
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(173, 284)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(246, 259)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgdetailsOrder)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(238, 233)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Order No."
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgdetailsOrder
        '
        Me.dgdetailsOrder.AllowUserToAddRows = False
        Me.dgdetailsOrder.AllowUserToDeleteRows = False
        Me.dgdetailsOrder.AllowUserToResizeRows = False
        Me.dgdetailsOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdetailsOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOrder})
        Me.dgdetailsOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdetailsOrder.Location = New System.Drawing.Point(3, 3)
        Me.dgdetailsOrder.Name = "dgdetailsOrder"
        Me.dgdetailsOrder.RowHeadersVisible = False
        Me.dgdetailsOrder.Size = New System.Drawing.Size(232, 227)
        Me.dgdetailsOrder.TabIndex = 0
        '
        'colOrder
        '
        Me.colOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colOrder.HeaderText = "Order No."
        Me.colOrder.Name = "colOrder"
        Me.colOrder.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgdetailsDR)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(238, 233)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DR No."
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgdetailsDR
        '
        Me.dgdetailsDR.AllowUserToAddRows = False
        Me.dgdetailsDR.AllowUserToDeleteRows = False
        Me.dgdetailsDR.AllowUserToResizeRows = False
        Me.dgdetailsDR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdetailsDR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDRNo})
        Me.dgdetailsDR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdetailsDR.Location = New System.Drawing.Point(3, 3)
        Me.dgdetailsDR.Name = "dgdetailsDR"
        Me.dgdetailsDR.RowHeadersVisible = False
        Me.dgdetailsDR.Size = New System.Drawing.Size(232, 227)
        Me.dgdetailsDR.TabIndex = 1
        '
        'colDRNo
        '
        Me.colDRNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDRNo.HeaderText = "DR No."
        Me.colDRNo.Name = "colDRNo"
        Me.colDRNo.ReadOnly = True
        '
        'ErrorProv
        '
        Me.ErrorProv.ContainerControl = Me
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Order No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "DR No."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'frm_000_EditUPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(266, 325)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_000_EditUPrice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_000_EditUPrice"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgdetailsOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgdetailsDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtunitprice As System.Windows.Forms.TextBox
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cbodec As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgdetailsOrder As System.Windows.Forms.DataGridView
    Friend WithEvents colOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgdetailsDR As System.Windows.Forms.DataGridView
    Friend WithEvents colDRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblcountTran As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
