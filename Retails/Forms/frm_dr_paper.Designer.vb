<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_dr_paper
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
        Me.cboapp = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdbtn2 = New System.Windows.Forms.RadioButton
        Me.rdbtn1 = New System.Windows.Forms.RadioButton
        Me.btnok = New System.Windows.Forms.Button
        Me.errorp = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.errorp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cboapp)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rdbtn2)
        Me.GroupBox1.Controls.Add(Me.rdbtn1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 75)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cboapp
        '
        Me.cboapp.Enabled = False
        Me.cboapp.FormattingEnabled = True
        Me.cboapp.Location = New System.Drawing.Point(75, 50)
        Me.cboapp.Name = "cboapp"
        Me.cboapp.Size = New System.Drawing.Size(160, 21)
        Me.cboapp.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Approved by"
        '
        'rdbtn2
        '
        Me.rdbtn2.AutoSize = True
        Me.rdbtn2.Location = New System.Drawing.Point(145, 19)
        Me.rdbtn2.Name = "rdbtn2"
        Me.rdbtn2.Size = New System.Drawing.Size(60, 17)
        Me.rdbtn2.TabIndex = 0
        Me.rdbtn2.TabStop = True
        Me.rdbtn2.Text = "Invoice"
        Me.rdbtn2.UseVisualStyleBackColor = True
        '
        'rdbtn1
        '
        Me.rdbtn1.AutoSize = True
        Me.rdbtn1.Location = New System.Drawing.Point(6, 19)
        Me.rdbtn1.Name = "rdbtn1"
        Me.rdbtn1.Size = New System.Drawing.Size(125, 17)
        Me.rdbtn1.TabIndex = 0
        Me.rdbtn1.TabStop = True
        Me.rdbtn1.Text = "Delivery Receipt(DR)"
        Me.rdbtn1.UseVisualStyleBackColor = True
        '
        'btnok
        '
        Me.btnok.Location = New System.Drawing.Point(172, 86)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(75, 23)
        Me.btnok.TabIndex = 1
        Me.btnok.Text = "Ok"
        Me.btnok.UseVisualStyleBackColor = True
        '
        'errorp
        '
        Me.errorp.ContainerControl = Me
        '
        'frm_dr_paper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 121)
        Me.Controls.Add(Me.btnok)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_dr_paper"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paper type"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.errorp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbtn2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbtn1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboapp As System.Windows.Forms.ComboBox
    Friend WithEvents errorp As System.Windows.Forms.ErrorProvider
End Class
