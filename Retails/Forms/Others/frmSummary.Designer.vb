<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSummary
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSummary))
        Me.listreport = New System.Windows.Forms.ListBox()
        Me.cbo4 = New System.Windows.Forms.ComboBox()
        Me.cbo3 = New System.Windows.Forms.ComboBox()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.cbo2 = New System.Windows.Forms.ComboBox()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.txt1 = New System.Windows.Forms.TextBox()
        Me.cbo1 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txt2 = New System.Windows.Forms.TextBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt3 = New System.Windows.Forms.TextBox()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.txt4 = New System.Windows.Forms.TextBox()
        Me.lbl4 = New System.Windows.Forms.Label()
        Me.grp1 = New System.Windows.Forms.GroupBox()
        Me.lbl6 = New System.Windows.Forms.Label()
        Me.lbl5 = New System.Windows.Forms.Label()
        Me.ErrorP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grp1.SuspendLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'listreport
        '
        Me.listreport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listreport.FormattingEnabled = True
        Me.listreport.Location = New System.Drawing.Point(12, 12)
        Me.listreport.Name = "listreport"
        Me.listreport.Size = New System.Drawing.Size(259, 264)
        Me.listreport.TabIndex = 1
        '
        'cbo4
        '
        Me.cbo4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo4.FormattingEnabled = True
        Me.cbo4.Location = New System.Drawing.Point(105, 111)
        Me.cbo4.Name = "cbo4"
        Me.cbo4.Size = New System.Drawing.Size(147, 21)
        Me.cbo4.TabIndex = 11
        Me.cbo4.Visible = False
        '
        'cbo3
        '
        Me.cbo3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo3.FormattingEnabled = True
        Me.cbo3.Location = New System.Drawing.Point(105, 84)
        Me.cbo3.Name = "cbo3"
        Me.cbo3.Size = New System.Drawing.Size(147, 21)
        Me.cbo3.TabIndex = 9
        Me.cbo3.Visible = False
        '
        'dtp1
        '
        Me.dtp1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp1.CustomFormat = "MM/dd/yyyy"
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp1.Location = New System.Drawing.Point(105, 31)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(147, 20)
        Me.dtp1.TabIndex = 12
        Me.dtp1.Visible = False
        '
        'cbo2
        '
        Me.cbo2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo2.FormattingEnabled = True
        Me.cbo2.Location = New System.Drawing.Point(105, 57)
        Me.cbo2.Name = "cbo2"
        Me.cbo2.Size = New System.Drawing.Size(147, 21)
        Me.cbo2.TabIndex = 7
        Me.cbo2.Visible = False
        '
        'dtp2
        '
        Me.dtp2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp2.CustomFormat = "MM/dd/yyyy"
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp2.Location = New System.Drawing.Point(105, 58)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(147, 20)
        Me.dtp2.TabIndex = 13
        Me.dtp2.Visible = False
        '
        'txt1
        '
        Me.txt1.Location = New System.Drawing.Point(105, 30)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(147, 20)
        Me.txt1.TabIndex = 15
        Me.txt1.Visible = False
        '
        'cbo1
        '
        Me.cbo1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo1.FormattingEnabled = True
        Me.cbo1.Location = New System.Drawing.Point(105, 30)
        Me.cbo1.Name = "cbo1"
        Me.cbo1.Size = New System.Drawing.Size(147, 21)
        Me.cbo1.TabIndex = 5
        Me.cbo1.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Image = Global.RetailPoint.My.Resources.Resources.print
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(104, 204)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 27)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Print"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txt2
        '
        Me.txt2.Location = New System.Drawing.Point(105, 57)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(147, 20)
        Me.txt2.TabIndex = 16
        Me.txt2.Visible = False
        '
        'lbl1
        '
        Me.lbl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(6, 33)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(39, 13)
        Me.lbl1.TabIndex = 4
        Me.lbl1.Text = "Label1"
        Me.lbl1.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.Image = Global.RetailPoint.My.Resources.Resources.preview
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(184, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 27)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Preview"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt3
        '
        Me.txt3.Location = New System.Drawing.Point(105, 83)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(147, 20)
        Me.txt3.TabIndex = 16
        Me.txt3.Visible = False
        '
        'lbl2
        '
        Me.lbl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl2.AutoSize = True
        Me.lbl2.Location = New System.Drawing.Point(6, 60)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(39, 13)
        Me.lbl2.TabIndex = 6
        Me.lbl2.Text = "Label2"
        Me.lbl2.Visible = False
        '
        'lbl3
        '
        Me.lbl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl3.AutoSize = True
        Me.lbl3.Location = New System.Drawing.Point(6, 87)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(39, 13)
        Me.lbl3.TabIndex = 8
        Me.lbl3.Text = "Label3"
        Me.lbl3.Visible = False
        '
        'txt4
        '
        Me.txt4.Location = New System.Drawing.Point(105, 111)
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(147, 20)
        Me.txt4.TabIndex = 16
        Me.txt4.Visible = False
        '
        'lbl4
        '
        Me.lbl4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl4.AutoSize = True
        Me.lbl4.Location = New System.Drawing.Point(6, 114)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(39, 13)
        Me.lbl4.TabIndex = 10
        Me.lbl4.Text = "Label4"
        Me.lbl4.Visible = False
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.lbl6)
        Me.grp1.Controls.Add(Me.lbl5)
        Me.grp1.Controls.Add(Me.lbl4)
        Me.grp1.Controls.Add(Me.txt4)
        Me.grp1.Controls.Add(Me.lbl3)
        Me.grp1.Controls.Add(Me.lbl2)
        Me.grp1.Controls.Add(Me.txt3)
        Me.grp1.Controls.Add(Me.Button1)
        Me.grp1.Controls.Add(Me.lbl1)
        Me.grp1.Controls.Add(Me.txt2)
        Me.grp1.Controls.Add(Me.Button2)
        Me.grp1.Controls.Add(Me.cbo1)
        Me.grp1.Controls.Add(Me.txt1)
        Me.grp1.Controls.Add(Me.dtp2)
        Me.grp1.Controls.Add(Me.cbo2)
        Me.grp1.Controls.Add(Me.dtp1)
        Me.grp1.Controls.Add(Me.cbo3)
        Me.grp1.Controls.Add(Me.cbo4)
        Me.grp1.Location = New System.Drawing.Point(287, 12)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(298, 264)
        Me.grp1.TabIndex = 6
        Me.grp1.TabStop = False
        '
        'lbl6
        '
        Me.lbl6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl6.AutoSize = True
        Me.lbl6.Location = New System.Drawing.Point(6, 171)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Size = New System.Drawing.Size(39, 13)
        Me.lbl6.TabIndex = 22
        Me.lbl6.Text = "Label4"
        Me.lbl6.Visible = False
        '
        'lbl5
        '
        Me.lbl5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl5.AutoSize = True
        Me.lbl5.Location = New System.Drawing.Point(6, 141)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(39, 13)
        Me.lbl5.TabIndex = 20
        Me.lbl5.Text = "Label4"
        Me.lbl5.Visible = False
        '
        'ErrorP
        '
        Me.ErrorP.ContainerControl = Me
        '
        'frmSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 294)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.listreport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.ErrorP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents listreport As System.Windows.Forms.ListBox

    Friend WithEvents cbo4 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo3 As System.Windows.Forms.ComboBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo2 As System.Windows.Forms.ComboBox
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents cbo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents txt4 As System.Windows.Forms.TextBox
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Friend WithEvents grp1 As System.Windows.Forms.GroupBox

    Friend WithEvents ErrorP As System.Windows.Forms.ErrorProvider
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents lbl5 As System.Windows.Forms.Label

End Class
