<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_000_ExchangeRate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_000_ExchangeRate))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.picLogo = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblRecordCount = New System.Windows.Forms.Label
        Me.LabelCount = New System.Windows.Forms.Label
        Me.dglist = New System.Windows.Forms.DataGridView
        Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colExRateDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colconversioncode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtERCode = New System.Windows.Forms.TextBox
        Me.grpProfile = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtcode = New System.Windows.Forms.TextBox
        Me.cboratecode = New System.Windows.Forms.ComboBox
        Me.dgExchangeRate = New System.Windows.Forms.DataGridView
        Me.cboCurrencyTo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblERCount = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.grpList = New System.Windows.Forms.GroupBox
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colERValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dglist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpProfile.SuspendLayout()
        CType(Me.dgExchangeRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpList.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(960, 36)
        Me.Panel1.TabIndex = 29
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
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTitle.Location = New System.Drawing.Point(316, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(302, 33)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Exchange Rate Setup"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.lblRecordCount)
        Me.Panel3.Controls.Add(Me.LabelCount)
        Me.Panel3.Location = New System.Drawing.Point(1, 366)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(142, 22)
        Me.Panel3.TabIndex = 0
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRecordCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCount.Location = New System.Drawing.Point(86, 4)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(16, 16)
        Me.lblRecordCount.TabIndex = 1
        Me.lblRecordCount.Text = "0"
        '
        'LabelCount
        '
        Me.LabelCount.AutoSize = True
        Me.LabelCount.Location = New System.Drawing.Point(4, 5)
        Me.LabelCount.Name = "LabelCount"
        Me.LabelCount.Size = New System.Drawing.Size(82, 13)
        Me.LabelCount.TabIndex = 1
        Me.LabelCount.Text = "No. of Records:"
        '
        'dglist
        '
        Me.dglist.AllowUserToAddRows = False
        Me.dglist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dglist.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dglist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dglist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCode, Me.colExRateDescription, Me.colconversioncode})
        Me.dglist.Location = New System.Drawing.Point(6, 20)
        Me.dglist.MultiSelect = False
        Me.dglist.Name = "dglist"
        Me.dglist.ReadOnly = True
        Me.dglist.RowHeadersWidth = 25
        Me.dglist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dglist.Size = New System.Drawing.Size(442, 345)
        Me.dglist.TabIndex = 0
        '
        'colCode
        '
        Me.colCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCode.HeaderText = "CODE"
        Me.colCode.Name = "colCode"
        Me.colCode.ReadOnly = True
        '
        'colExRateDescription
        '
        Me.colExRateDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colExRateDescription.HeaderText = "ExRate Description"
        Me.colExRateDescription.Name = "colExRateDescription"
        Me.colExRateDescription.ReadOnly = True
        '
        'colconversioncode
        '
        Me.colconversioncode.HeaderText = "Column1"
        Me.colconversioncode.Name = "colconversioncode"
        Me.colconversioncode.ReadOnly = True
        Me.colconversioncode.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Exchange Rate Description:"
        '
        'txtERCode
        '
        Me.txtERCode.Location = New System.Drawing.Point(151, 48)
        Me.txtERCode.Name = "txtERCode"
        Me.txtERCode.Size = New System.Drawing.Size(185, 20)
        Me.txtERCode.TabIndex = 1
        '
        'grpProfile
        '
        Me.grpProfile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProfile.Controls.Add(Me.Label2)
        Me.grpProfile.Controls.Add(Me.txtcode)
        Me.grpProfile.Controls.Add(Me.cboratecode)
        Me.grpProfile.Controls.Add(Me.dgExchangeRate)
        Me.grpProfile.Controls.Add(Me.cboCurrencyTo)
        Me.grpProfile.Controls.Add(Me.Label5)
        Me.grpProfile.Controls.Add(Me.Panel2)
        Me.grpProfile.Controls.Add(Me.txtERCode)
        Me.grpProfile.Controls.Add(Me.Label1)
        Me.grpProfile.Location = New System.Drawing.Point(3, 4)
        Me.grpProfile.Name = "grpProfile"
        Me.grpProfile.Size = New System.Drawing.Size(470, 392)
        Me.grpProfile.TabIndex = 31
        Me.grpProfile.TabStop = False
        Me.grpProfile.Text = "Profile:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Code:"
        '
        'txtcode
        '
        Me.txtcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcode.Location = New System.Drawing.Point(151, 19)
        Me.txtcode.MaxLength = 2
        Me.txtcode.Name = "txtcode"
        Me.txtcode.Size = New System.Drawing.Size(185, 20)
        Me.txtcode.TabIndex = 10
        '
        'cboratecode
        '
        Me.cboratecode.FormattingEnabled = True
        Me.cboratecode.Location = New System.Drawing.Point(151, 47)
        Me.cboratecode.Name = "cboratecode"
        Me.cboratecode.Size = New System.Drawing.Size(185, 21)
        Me.cboratecode.TabIndex = 9
        '
        'dgExchangeRate
        '
        Me.dgExchangeRate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgExchangeRate.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgExchangeRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgExchangeRate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colYear, Me.colERValue})
        Me.dgExchangeRate.Location = New System.Drawing.Point(6, 74)
        Me.dgExchangeRate.Name = "dgExchangeRate"
        Me.dgExchangeRate.RowHeadersWidth = 25
        Me.dgExchangeRate.Size = New System.Drawing.Size(458, 291)
        Me.dgExchangeRate.TabIndex = 8
        '
        'cboCurrencyTo
        '
        Me.cboCurrencyTo.FormattingEnabled = True
        Me.cboCurrencyTo.Location = New System.Drawing.Point(525, 15)
        Me.cboCurrencyTo.Name = "cboCurrencyTo"
        Me.cboCurrencyTo.Size = New System.Drawing.Size(78, 21)
        Me.cboCurrencyTo.TabIndex = 7
        Me.cboCurrencyTo.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(502, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "To"
        Me.Label5.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblERCount)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(6, 366)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(142, 22)
        Me.Panel2.TabIndex = 5
        '
        'lblERCount
        '
        Me.lblERCount.AutoSize = True
        Me.lblERCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblERCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblERCount.Location = New System.Drawing.Point(86, 4)
        Me.lblERCount.Name = "lblERCount"
        Me.lblERCount.Size = New System.Drawing.Size(16, 16)
        Me.lblERCount.TabIndex = 1
        Me.lblERCount.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "No. of Records:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 42)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpProfile)
        Me.SplitContainer1.Size = New System.Drawing.Size(948, 398)
        Me.SplitContainer1.SplitterDistance = 471
        Me.SplitContainer1.TabIndex = 32
        '
        'grpList
        '
        Me.grpList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpList.Controls.Add(Me.dglist)
        Me.grpList.Controls.Add(Me.Panel3)
        Me.grpList.Location = New System.Drawing.Point(12, 4)
        Me.grpList.Name = "grpList"
        Me.grpList.Size = New System.Drawing.Size(454, 392)
        Me.grpList.TabIndex = 1
        Me.grpList.TabStop = False
        Me.grpList.Text = "List:"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ConversionType"
        Me.DataGridViewTextBoxColumn2.FillWeight = 77.55102!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Currency From"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "YR"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.FillWeight = 122.449!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Currency To"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Value"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.FillWeight = 122.449!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Specific Code"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn5.HeaderText = "Year"
        Me.DataGridViewTextBoxColumn5.MaxInputLength = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn6.HeaderText = "Exchange Rate Value"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 150
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn7.HeaderText = "Exchange Rate Value"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 150
        '
        'colYear
        '
        Me.colYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colYear.DefaultCellStyle = DataGridViewCellStyle1
        Me.colYear.HeaderText = "DETAILED CODE "
        Me.colYear.MaxInputLength = 7
        Me.colYear.Name = "colYear"
        Me.colYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colERValue
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.colERValue.DefaultCellStyle = DataGridViewCellStyle2
        Me.colERValue.HeaderText = "Exchange Rate Value"
        Me.colERValue.Name = "colERValue"
        Me.colERValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'frm_000_ExchangeRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 445)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frm_000_ExchangeRate"
        Me.Text = "frm_000_Supplier"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dglist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpProfile.ResumeLayout(False)
        Me.grpProfile.PerformLayout()
        CType(Me.dgExchangeRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents LabelCount As System.Windows.Forms.Label
    Friend WithEvents dglist As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtERCode As System.Windows.Forms.TextBox
    Friend WithEvents grpProfile As System.Windows.Forms.GroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grpList As System.Windows.Forms.GroupBox
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblERCount As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgExchangeRate As System.Windows.Forms.DataGridView
    Friend WithEvents cboCurrencyTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboratecode As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcode As System.Windows.Forms.TextBox
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExRateDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colconversioncode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colERValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
