<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_200_ReportV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_200_ReportV))
        Me.rpt_viewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rpt_viewer
        '
        Me.rpt_viewer.ActiveViewIndex = -1
        Me.rpt_viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rpt_viewer.DisplayGroupTree = False
        Me.rpt_viewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt_viewer.EnableDrillDown = False
        Me.rpt_viewer.Location = New System.Drawing.Point(0, 0)
        Me.rpt_viewer.Name = "rpt_viewer"
        Me.rpt_viewer.SelectionFormula = ""
        Me.rpt_viewer.ShowRefreshButton = False
        Me.rpt_viewer.Size = New System.Drawing.Size(1028, 477)
        Me.rpt_viewer.TabIndex = 0
        Me.rpt_viewer.ViewTimeSelectionFormula = ""
        '
        'frm_200_ReportV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 477)
        Me.Controls.Add(Me.rpt_viewer)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frm_200_ReportV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt_viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
