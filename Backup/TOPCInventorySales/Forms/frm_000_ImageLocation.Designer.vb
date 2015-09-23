<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_000_ImageLocation
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
        Me.txtimagePath = New System.Windows.Forms.TextBox
        Me.btnselectpath = New System.Windows.Forms.Button
        Me.FD_img = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'txtimagePath
        '
        Me.txtimagePath.Location = New System.Drawing.Point(12, 12)
        Me.txtimagePath.Name = "txtimagePath"
        Me.txtimagePath.Size = New System.Drawing.Size(304, 20)
        Me.txtimagePath.TabIndex = 0
        '
        'btnselectpath
        '
        Me.btnselectpath.Location = New System.Drawing.Point(322, 9)
        Me.btnselectpath.Name = "btnselectpath"
        Me.btnselectpath.Size = New System.Drawing.Size(28, 24)
        Me.btnselectpath.TabIndex = 1
        Me.btnselectpath.Text = "..."
        Me.btnselectpath.UseVisualStyleBackColor = True
        '
        'FD_img
        '
        Me.FD_img.Description = "select image path"
        '
        'frm_000_ImageLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 45)
        Me.Controls.Add(Me.btnselectpath)
        Me.Controls.Add(Me.txtimagePath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_000_ImageLocation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Folder Path"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtimagePath As System.Windows.Forms.TextBox
    Friend WithEvents btnselectpath As System.Windows.Forms.Button
    Friend WithEvents FD_img As System.Windows.Forms.FolderBrowserDialog
End Class
