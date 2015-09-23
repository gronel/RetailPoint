<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUnit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUnit))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.txtnew = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblidexist = New System.Windows.Forms.Label
        Me.lblothertrans = New System.Windows.Forms.Label
        Me.picload = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblempty = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.picload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(157, 58)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'txtnew
        '
        Me.txtnew.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnew.Location = New System.Drawing.Point(130, 11)
        Me.txtnew.Name = "txtnew"
        Me.txtnew.Size = New System.Drawing.Size(174, 20)
        Me.txtnew.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Type New Control No."
        '
        'lblidexist
        '
        Me.lblidexist.AutoSize = True
        Me.lblidexist.ForeColor = System.Drawing.Color.Red
        Me.lblidexist.Location = New System.Drawing.Point(109, 42)
        Me.lblidexist.Name = "lblidexist"
        Me.lblidexist.Size = New System.Drawing.Size(116, 13)
        Me.lblidexist.TabIndex = 3
        Me.lblidexist.Text = "The ID is already exists"
        Me.lblidexist.Visible = False
        '
        'lblothertrans
        '
        Me.lblothertrans.AutoSize = True
        Me.lblothertrans.ForeColor = System.Drawing.Color.Red
        Me.lblothertrans.Location = New System.Drawing.Point(46, 42)
        Me.lblothertrans.Name = "lblothertrans"
        Me.lblothertrans.Size = New System.Drawing.Size(228, 13)
        Me.lblothertrans.TabIndex = 4
        Me.lblothertrans.Text = "The ID you entered is used in other transaction"
        Me.lblothertrans.Visible = False
        '
        'picload
        '
        Me.picload.BackColor = System.Drawing.Color.Transparent
        Me.picload.Image = CType(resources.GetObject("picload.Image"), System.Drawing.Image)
        Me.picload.InitialImage = Nothing
        Me.picload.Location = New System.Drawing.Point(143, 36)
        Me.picload.Name = "picload"
        Me.picload.Size = New System.Drawing.Size(28, 20)
        Me.picload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picload.TabIndex = 6
        Me.picload.TabStop = False
        Me.picload.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'lblempty
        '
        Me.lblempty.AutoSize = True
        Me.lblempty.ForeColor = System.Drawing.Color.Red
        Me.lblempty.Location = New System.Drawing.Point(93, 41)
        Me.lblempty.Name = "lblempty"
        Me.lblempty.Size = New System.Drawing.Size(136, 13)
        Me.lblempty.TabIndex = 7
        Me.lblempty.Text = "New Control No. is required"
        Me.lblempty.Visible = False
        '
        'frmUnit
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(315, 99)
        Me.Controls.Add(Me.lblempty)
        Me.Controls.Add(Me.picload)
        Me.Controls.Add(Me.lblothertrans)
        Me.Controls.Add(Me.lblidexist)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtnew)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUnit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Type New Control No."
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.picload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txtnew As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblidexist As System.Windows.Forms.Label
    Friend WithEvents lblothertrans As System.Windows.Forms.Label
    Friend WithEvents picload As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblempty As System.Windows.Forms.Label

End Class
