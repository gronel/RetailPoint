Public Class frmPic
    Implements IBPSCommand

    Private Sub frmPic_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = Me.Parent.DisplayRectangle.Width - Me.Width
    End Sub

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

    End Sub
End Class