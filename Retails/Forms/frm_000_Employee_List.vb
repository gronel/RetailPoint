Imports System.Data.SqlClient
Imports Retails.clsPublic
Public Class frm_000_Employee_List

#Region "Variable"
    Implements IBPSCommand
    Implements IBPS_SEARCH
    Dim BS As New BindingSource
    Dim bolFilter As Boolean
    Dim strFilter As String
    Dim bolFormState As clsPublic.FormState

#End Region

#Region "Procedure"
    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                Call NewRecord()
            Case "Edit"
                Call EditRecord()
            Case "Delete"
                Call DeleteRecord()
            Case "Save"

            Case "Cancel"

            Case "Refresh"
                MainForm.tsSearch.Text = String.Empty
                Call RefreshRecord()
            Case "Search"
                Call SearchRecord(MainForm.tsSearch.Text)
        End Select
    End Sub


    Sub DeleteRecord()
        If vbYes = MsgBox("Are you sure you want to delete this bank?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
            _OpenTransaction()
            _Result = _DeleteRecord("tbl_000_Employee", "WHERE EmpID=" & dgList.Item(0, dgList.CurrentRow.Index).Value & "")
            _CloseTransaction(_Result)
            If _Result Then
                RefreshRecord()
            End If
        End If
    End Sub

    Sub NewRecord()
        With frm_000_Employee
            .myparent = Me
            .bolFormState = FormState.AddState
            .clear()
            .ShowDialog()
            ActivateCommands(FormState.ViewState)
            .Focus()
        End With
    End Sub

    Sub EditRecord()
        With frm_000_Employee


            .myparent = Me
            .bolFormState = FormState.EditState
            .ShowDialog()
            ActivateCommands(FormState.ViewState)
            .Focus()

        End With
    End Sub

    Private Sub SearchRecord(ByVal strvalue As String)
        Try
            Dim strSQL As String

            strSQL = dgList.Columns(0).DataPropertyName & " LIKE '%" & strvalue & "%' or " & _
                     dgList.Columns(1).DataPropertyName & " LIKE '%" & strvalue & "%' or  " & _
                     dgList.Columns(2).DataPropertyName & " LIKE '%" & strvalue & "%' or  " & _
                     dgList.Columns(3).DataPropertyName & " LIKE '%" & strvalue & "%' or  " & _
                     dgList.Columns(4).DataPropertyName & " LIKE '%" & strvalue & "%' or  " & _
                     dgList.Columns(5).DataPropertyName & " LIKE '%" & strvalue & "%' or " & _
                     dgList.Columns(6).DataPropertyName & " LIKE '%" & strvalue & "%' or " & _
                     dgList.Columns(7).DataPropertyName & " LIKE '%" & strvalue & "%' or " & _
                     dgList.Columns(8).DataPropertyName & " like '%" & strvalue & "%'"
            Me.BS.RemoveFilter()
            If bolFilter Then
                Me.BS.Filter = strSQL & strFilter
            Else
                Me.BS.Filter = strSQL
            End If
            dgList.DataSource = BS
            lblRecordCount.Text = dgList.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR [Search]")
        End Try
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
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = True
                    .tsDelete.Enabled = True
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                    
                    .tsPrint.Enabled = False
                    .tsPreview.Enabled = False
                    .tsSearch.Enabled = True
                    .btnSearch.Enabled = True
                Case FormState.LoadState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                    
                    .tsPrint.Enabled = False
                    .tsPrint.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
            End Select

        End With
    End Sub

    Sub RefreshRecord()

        Try
            ''Call ClearFilter()
            Dim myconn As SqlConnection = New SqlConnection(cnString)
            Dim da As SqlDataAdapter = New SqlDataAdapter("Get_Employee'" & "list" & "'", myconn)
            Dim ds As DataSet = New DataSet()
            ds.Clear()
            da.Fill(ds, "tbl_000_Employee")
            BS.DataSource = ds.Tables(0)
            dgList.DataSource = BS
            lblRecordCount.Text = dgList.RowCount
            ActivateCommands(FormState.LoadState)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub

#End Region



#Region "GUI"
    Private Sub frm_000_Employee_List_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_000_Employee_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        picPhoto.Image = MainForm.picLogo.Image
        ActivateCommands(FormState.LoadState)
        CenterControl(lblTitle, Me)
        RefreshRecord()

    End Sub



    Private Sub dgList_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellEnter
        If dgList.RowCount > 0 Then
            ActivateCommands(FormState.ViewState)
        Else
            ActivateCommands(FormState.LoadState)
        End If
        showImg("Select EmpPhoto from tbl_000_Employee where EmpID='" & dgList.Item("Column1", dgList.CurrentRow.Index).Value & "'", "EmpPhoto", picPhoto)
    End Sub


    Public Sub ProcessSearchData(ByVal str As String) Implements IBPS_SEARCH.ProcessSearchData
        Call SearchRecord(str)
    End Sub
#End Region




End Class