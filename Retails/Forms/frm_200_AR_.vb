Imports System.Data.SqlClient
Imports Retails.clsPublic
Imports System.Runtime.InteropServices
Public Class frm_200_AR_



    Implements IBPSCommand
    Dim bolFormState As clsPublic.FormState



    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                'NewRecord()
            Case "Edit"
                'EditRecord()
            Case "Delete"

            Case "Save"

            Case "Cancel"

            Case "Refresh"
                'MainForm.tsSearch.Text = String.Empty
                'RefreshRecord("Get_RIL '" & MainForm.tsSearch.Text & "'")
            Case "Search"
                'RefreshRecord("Get_RIL '" & MainForm.tsSearch.Text & "'")
            Case "Filter"
                'Call FilterOn()
            Case "FilterClear"
                ' Call FilterClear()
        End Select
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="frmState"></param>
    ''' <remarks></remarks>
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
                    
                    .tsPrint.Enabled = False
                    .tsPrint.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
                Case FormState.EditState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                    
                    .tsPrint.Enabled = True
                    .tsPreview.Enabled = True
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
                Case FormState.ViewState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                    
                    .tsPrint.Enabled = False
                    .tsPreview.Enabled = False
                    .tsSearch.Enabled = True
                    .btnSearch.Enabled = True
                    .tsFilterOn.Enabled = True
                    .tsFilterClear.Enabled = False

            End Select

        End With
    End Sub

    Public Sub FillData(ByVal EmployeeNumber As String)
        FillDataGrid(dgDetails, "GET_AR '" & EmployeeNumber & "'", 0, 15)
    End Sub

    Private Sub FillCombo()

    End Sub

    Private Sub frm_200_AR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me) 'Resize the  form 
        CenterControl(lblTitle, Me) 'center the ti
        ActivateCommands(FormState.ViewState)
        Call FillCombo()
    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub txtempID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempID.TextChanged

    End Sub

    Private Sub txtempID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtempID.Validated
        txtempName.Text = DBLookUp("Select dbo.F_Get_EmployeeName('" & txtempID.Text & "')as Empname", "Empname")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frmGetEmployee
            .myparent = Me
            .ShowDialog()
        End With
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick

    End Sub
End Class