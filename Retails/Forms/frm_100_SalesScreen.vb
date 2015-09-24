Imports Retails.clsPublic
Public Class frm_100_SalesScreen


#Region "Variable"

    Implements IBPSCommand

    Dim strDataGridSearchValue As String
    Dim UserID As Integer
    Dim bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Dim strName As String

    Private _UserPic As Byte()
    Private _EmpName As String

#End Region

    Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                '  NewRecord()
            Case "Edit"
                'EditRecord()
            Case "Delete"
                'DeleteRecord()
            Case "Save"
                ' SaveRecord()
            Case "Cancel"
                If vbYes = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm") Then
                    doCancel()
                End If
            Case "Refresh"
                ' RefreshRecord()
        End Select

    End Sub

    Sub doCancel()
        'ErrProvider.ClearAllErrorMessages()
        'LockFields(True)
        'grpList.Enabled = True
        'ActivateCommands(FormState.LoadState)
    End Sub

    Sub ActivateCommands(ByVal frmState As clsPublic.FormState)
        bolFormState = frmState

        With MainForm
            Select Case frmState
                Case FormState.AddState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                Case FormState.EditState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                Case FormState.ViewState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = True
                    .tsDelete.Enabled = True
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                Case FormState.LoadState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
            End Select

        End With
    End Sub

    Private Sub frm_100_SalesScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class