<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_100_ItemSelected
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_100_ItemSelected))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtitemName = New System.Windows.Forms.TextBox()
        Me.txtdescription = New System.Windows.Forms.TextBox()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bntOk = New System.Windows.Forms.Button()
        Me.lblinfo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Item Description:"
        '
        'txtitemName
        '
        Me.txtitemName.BackColor = System.Drawing.Color.MintCream
        Me.txtitemName.Location = New System.Drawing.Point(104, 43)
        Me.txtitemName.Name = "txtitemName"
        Me.txtitemName.ReadOnly = True
        Me.txtitemName.Size = New System.Drawing.Size(260, 20)
        Me.txtitemName.TabIndex = 2
        '
        'txtdescription
        '
        Me.txtdescription.BackColor = System.Drawing.Color.MintCream
        Me.txtdescription.Location = New System.Drawing.Point(104, 72)
        Me.txtdescription.Multiline = True
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.ReadOnly = True
        Me.txtdescription.Size = New System.Drawing.Size(260, 50)
        Me.txtdescription.TabIndex = 3
        '
        'txtqty
        '
        Me.txtqty.BackColor = System.Drawing.SystemColors.Window
        Me.txtqty.Location = New System.Drawing.Point(104, 128)
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(139, 20)
        Me.txtqty.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Quantity:"
        '
        'bntOk
        '
        Me.bntOk.Location = New System.Drawing.Point(158, 165)
        Me.bntOk.Name = "bntOk"
        Me.bntOk.Size = New System.Drawing.Size(75, 34)
        Me.bntOk.TabIndex = 1
        Me.bntOk.Text = "Done"
        Me.bntOk.UseVisualStyleBackColor = True
        '
        'lblinfo
        '
        Me.lblinfo.AutoSize = True
        Me.lblinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinfo.Location = New System.Drawing.Point(249, 131)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(45, 13)
        Me.lblinfo.TabIndex = 5
        Me.lblinfo.Text = "Label4"
        '
        'frm_100_ItemSelected
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.ClientSize = New System.Drawing.Size(392, 222)
        Me.Controls.Add(Me.lblinfo)
        Me.Controls.Add(Me.bntOk)
        Me.Controls.Add(Me.txtqty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtdescription)
        Me.Controls.Add(Me.txtitemName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_100_ItemSelected"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Selected"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtitemName As System.Windows.Forms.TextBox
    Friend WithEvents txtdescription As System.Windows.Forms.TextBox
    Friend WithEvents txtqty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents bntOk As System.Windows.Forms.Button
    Friend WithEvents lblinfo As System.Windows.Forms.Label
End Class
