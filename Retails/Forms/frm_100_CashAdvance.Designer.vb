<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_100_CashAdvance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_100_CashAdvance))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.picLogo = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.dgList = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCANo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRequestor = New System.Windows.Forms.TextBox
        Me.dgSub = New System.Windows.Forms.DataGridView
        Me.colbtn = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblCountSub = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.grpList = New System.Windows.Forms.GroupBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblRecordCount = New System.Windows.Forms.Label
        Me.LabelCount = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbopurpose = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.cboDepartment = New MTGCComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtCADate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCANo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpList.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(202, 33)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "Cash Advance"
        '
        'dgList
        '
        Me.dgList.AllowUserToAddRows = False
        Me.dgList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgList.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCANo, Me.colEmpName, Me.colTotalAmount})
        Me.dgList.Location = New System.Drawing.Point(6, 20)
        Me.dgList.MultiSelect = False
        Me.dgList.Name = "dgList"
        Me.dgList.ReadOnly = True
        Me.dgList.RowHeadersVisible = False
        Me.dgList.RowHeadersWidth = 25
        Me.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgList.Size = New System.Drawing.Size(286, 345)
        Me.dgList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CA No."
        '
        'txtCANo
        '
        Me.txtCANo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCANo.Location = New System.Drawing.Point(102, 20)
        Me.txtCANo.MaxLength = 20
        Me.txtCANo.Name = "txtCANo"
        Me.txtCANo.Size = New System.Drawing.Size(100, 20)
        Me.txtCANo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Requestor"
        '
        'txtRequestor
        '
        Me.txtRequestor.BackColor = System.Drawing.Color.LightGray
        Me.txtRequestor.Location = New System.Drawing.Point(102, 46)
        Me.txtRequestor.Name = "txtRequestor"
        Me.txtRequestor.ReadOnly = True
        Me.txtRequestor.Size = New System.Drawing.Size(499, 20)
        Me.txtRequestor.TabIndex = 3
        '
        'dgSub
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgSub.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgSub.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSub.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgSub.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSub.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReferenceNo, Me.colbtn, Me.colAmount})
        Me.dgSub.Location = New System.Drawing.Point(6, 135)
        Me.dgSub.Name = "dgSub"
        Me.dgSub.RowHeadersWidth = 25
        Me.dgSub.Size = New System.Drawing.Size(614, 230)
        Me.dgSub.TabIndex = 1
        '
        'colbtn
        '
        Me.colbtn.HeaderText = ""
        Me.colbtn.Name = "colbtn"
        Me.colbtn.Text = ""
        Me.colbtn.Width = 30
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblCountSub)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(1, 366)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(142, 22)
        Me.Panel2.TabIndex = 4
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "No. of Records:"
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(948, 398)
        Me.SplitContainer1.SplitterDistance = 315
        Me.SplitContainer1.TabIndex = 32
        '
        'grpList
        '
        Me.grpList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpList.Controls.Add(Me.dgList)
        Me.grpList.Controls.Add(Me.Panel3)
        Me.grpList.Location = New System.Drawing.Point(12, 4)
        Me.grpList.Name = "grpList"
        Me.grpList.Size = New System.Drawing.Size(298, 392)
        Me.grpList.TabIndex = 2
        Me.grpList.TabStop = False
        Me.grpList.Text = "List: "
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbopurpose)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTotalAmount)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDepartment)
        Me.GroupBox1.Controls.Add(Me.cboDepartment)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtCADate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dgSub)
        Me.GroupBox1.Controls.Add(Me.txtCANo)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtRequestor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(626, 392)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Profile: "
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(448, 369)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 16)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "PHP"
        '
        'cbopurpose
        '
        Me.cbopurpose.FormattingEnabled = True
        Me.cbopurpose.Location = New System.Drawing.Point(102, 99)
        Me.cbopurpose.Name = "cbopurpose"
        Me.cbopurpose.Size = New System.Drawing.Size(499, 21)
        Me.cbopurpose.TabIndex = 56
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(334, 370)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Total Amount: "
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAmount.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.ForeColor = System.Drawing.Color.Red
        Me.txtTotalAmount.Location = New System.Drawing.Point(444, 367)
        Me.txtTotalAmount.MaxLength = 20
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(176, 22)
        Me.txtTotalAmount.TabIndex = 54
        Me.txtTotalAmount.Text = "0.00"
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Purpose"
        '
        'txtDepartment
        '
        Me.txtDepartment.BackColor = System.Drawing.Color.LightGray
        Me.txtDepartment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartment.Location = New System.Drawing.Point(201, 72)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.Size = New System.Drawing.Size(400, 21)
        Me.txtDepartment.TabIndex = 50
        Me.txtDepartment.TabStop = False
        '
        'cboDepartment
        '
        Me.cboDepartment.ArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboDepartment.ArrowColor = System.Drawing.Color.Black
        Me.cboDepartment.BindedControl = CType(resources.GetObject("cboDepartment.BindedControl"), MTGCComboBox.ControlloAssociato)
        Me.cboDepartment.BorderStyle = MTGCComboBox.TipiBordi.Fixed3D
        Me.cboDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartment.ColumnNum = 1
        Me.cboDepartment.ColumnWidth = "121"
        Me.cboDepartment.DisabledArrowBoxColor = System.Drawing.SystemColors.Control
        Me.cboDepartment.DisabledArrowColor = System.Drawing.Color.LightGray
        Me.cboDepartment.DisabledBackColor = System.Drawing.SystemColors.Control
        Me.cboDepartment.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboDepartment.DisabledForeColor = System.Drawing.SystemColors.GrayText
        Me.cboDepartment.DisplayMember = "Text"
        Me.cboDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDepartment.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.cboDepartment.DropDownForeColor = System.Drawing.Color.Black
        Me.cboDepartment.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        Me.cboDepartment.DropDownWidth = 141
        Me.cboDepartment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartment.GridLineColor = System.Drawing.Color.DarkGray
        Me.cboDepartment.GridLineHorizontal = True
        Me.cboDepartment.GridLineVertical = True
        Me.cboDepartment.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.cboDepartment.Location = New System.Drawing.Point(102, 71)
        Me.cboDepartment.ManagingFastMouseMoving = True
        Me.cboDepartment.ManagingFastMouseMovingInterval = 30
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.SelectedItem = Nothing
        Me.cboDepartment.SelectedValue = Nothing
        Me.cboDepartment.Size = New System.Drawing.Size(100, 22)
        Me.cboDepartment.TabIndex = 51
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Department"
        '
        'dtCADate
        '
        Me.dtCADate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtCADate.Location = New System.Drawing.Point(457, 20)
        Me.dtCADate.Name = "dtCADate"
        Me.dtCADate.Size = New System.Drawing.Size(103, 20)
        Me.dtCADate.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(421, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Date"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CANo"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CA No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Requestor"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Requestor"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn3.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ReferenceNo"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Reference No."
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Amount"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "n2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn5.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'colCANo
        '
        Me.colCANo.DataPropertyName = "CANo"
        Me.colCANo.HeaderText = "CA No."
        Me.colCANo.Name = "colCANo"
        Me.colCANo.ReadOnly = True
        Me.colCANo.Width = 70
        '
        'colEmpName
        '
        Me.colEmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colEmpName.DataPropertyName = "Requestor"
        Me.colEmpName.HeaderText = "Requestor"
        Me.colEmpName.MinimumWidth = 80
        Me.colEmpName.Name = "colEmpName"
        Me.colEmpName.ReadOnly = True
        '
        'colTotalAmount
        '
        Me.colTotalAmount.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.colTotalAmount.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTotalAmount.HeaderText = "Amount"
        Me.colTotalAmount.Name = "colTotalAmount"
        Me.colTotalAmount.ReadOnly = True
        Me.colTotalAmount.Width = 80
        '
        'colReferenceNo
        '
        Me.colReferenceNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colReferenceNo.DataPropertyName = "ReferenceNo"
        Me.colReferenceNo.HeaderText = "Reference No."
        Me.colReferenceNo.MinimumWidth = 100
        Me.colReferenceNo.Name = "colReferenceNo"
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "n2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.MinimumWidth = 100
        Me.colAmount.Name = "colAmount"
        Me.colAmount.Width = 150
        '
        'frm_100_CashAdvance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 445)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frm_100_CashAdvance"
        Me.Text = "frm_000_Category"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpList.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgList As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCANo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRequestor As System.Windows.Forms.TextBox
    Friend WithEvents dgSub As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCountSub As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grpList As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents LabelCount As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtCADate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents cboDepartment As MTGCComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents colCANo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents cbopurpose As System.Windows.Forms.ComboBox
    Friend WithEvents colReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colbtn As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
