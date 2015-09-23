Imports Retails.clsPublic

Public Class frm_000_Currency

    Implements IBPSCommand

#Region "Class Variables"

    Dim WarehouseCode As String
    Dim objWarehouse As New tbl_000_Currency
    Dim bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended

#End Region

#Region "GUI Events"

    Private Sub frm_000_User_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        setUserRights(Me.Tag)
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_000_User_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control = True And e.KeyCode = Keys.N And MainForm.tsNew.Visible = True And MainForm.tsNew.Enabled = True Then
            ProcessFormCommand("New")
        ElseIf e.KeyCode = Keys.F2 And MainForm.tsEdit.Visible = True And MainForm.tsEdit.Enabled = True Then
            ProcessFormCommand("Edit")
        ElseIf e.Control And e.KeyCode = Keys.E And MainForm.tsEdit.Visible = True And MainForm.tsEdit.Enabled = True Then
            ProcessFormCommand("Edit")
        ElseIf e.Control = True And e.KeyCode = Keys.S And MainForm.tsSave.Visible = True And MainForm.tsSave.Enabled = True Then
            ProcessFormCommand("Save")
        ElseIf e.KeyCode = Keys.Escape And MainForm.tsCancel.Visible = True And MainForm.tsCancel.Enabled = True Then
            ProcessFormCommand("Cancel")
        End If
    End Sub

    Private Sub frm_000_Warehouse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        CenterControl(lblTitle, Me)

        RefreshRecord()

        ActivateCommands(FormState.ViewState)

    End Sub

    Private Sub dgList_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgList.CellValidating
        If dgList.CurrentCell.ColumnIndex = 1 Then
            If CheckCodeFromDatagridView(dgList, 1, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                dgList.CancelEdit()
                MsgBox("Currency name already exists in the list.", MsgBoxStyle.Exclamation, "Existing Warehouse")
            End If
        End If
    End Sub

    Private Sub dgList_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgList.DataBindingComplete
        If bolFormState <> FormState.EditState Then
            Try
                For intX As Integer = 0 To dgList.RowCount - 1
                    If Not ("").Equals(Me.dgList.Rows(intX).Cells(0).Value.ToString) Then
                        Me.dgList.Rows(intX).ReadOnly = True
                        Me.dgList.Rows(intX).DefaultCellStyle.BackColor = Color.LightBlue
                    End If
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub dgList_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgList.RowsAdded
        lblRecordCount.Text = dgList.RowCount
    End Sub

    Private Sub dgList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgList.RowsRemoved
        lblRecordCount.Text = dgList.RowCount
    End Sub

#End Region

#Region "User-defined Methods"

    Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                dgList.AllowUserToAddRows = True
                dgList.SelectionMode = DataGridViewSelectionMode.CellSelect
                dgList.Rows(dgList.RowCount - 1).Cells(1).Selected = True
                ActivateCommands(FormState.AddState)
            Case "Edit"
                ''If dgList.SelectedRows.Count = 0 Then
                For intX As Integer = 0 To dgList.RowCount - 1
                    Me.dgList.Rows(intX).ReadOnly = False
                    Me.dgList.Rows(intX).DefaultCellStyle.BackColor = Color.White
                Next
                ''Else
                ''    For Each tmpList As DataGridViewRow In dgList.SelectedRows
                ''        dgList.Rows(tmpList.Index).ReadOnly = False
                ''        dgList.Rows(tmpList.Index).DefaultCellStyle.BackColor = Color.White
                ''    Next
                ''End If
                dgList.SelectionMode = DataGridViewSelectionMode.CellSelect
                ActivateCommands(FormState.EditState)
            Case "Delete"
                If dgList.SelectedRows.Count = 0 Then
                    MsgBox("Please select row/s to be deleted.", MsgBoxStyle.Exclamation, "Delete")
                Else
                    If vbYes = MsgBox("Are you sure you want to delete this Warehouse?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
                        Dim strCriteria As String = ""
                        For Each tmpList As DataGridViewRow In dgList.SelectedRows
                            If strCriteria <> "" Then
                                strCriteria += ","
                            End If
                            strCriteria += "'" & dgList.Rows(tmpList.Index).Cells(0).Value.ToString & "'"
                        Next
                        _OpenTransaction()
                        _CloseTransaction(_DeleteRecord("tbl_000_Currency", "WHERE Currency in (" & strCriteria & ")"))
                        RefreshRecord()
                        doCancel()
                        ''ClearFields()
                    End If
                End If
            Case "Save"
                'dgList.Rows(dgList.RowCount - 1).Cells(1).Selected = True
                'dgList.CommitEdit(DataGridViewDataErrorContexts.Commit)
                If objWarehouse.UpdateWarehouseGrid() Then
                    doCancel()
                End If
            Case "Cancel"
                If vbYes = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm") Then
                    doCancel()
                End If
            Case "Refresh"
                RefreshRecord()
        End Select

    End Sub

    Sub RefreshRecord()
        'FillGrid(dgList, "GetWarehouse", "tbl_000_Warehouse")
        objWarehouse.FillWarehouseGrid(dgList)
        lblRecordCount.Text = dgList.RowCount
        dgList.AllowUserToAddRows = False
        dgList.AllowUserToDeleteRows = True
        dgList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        ActivateCommands(FormState.ViewState)
        RefreshRecord()
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

#End Region

End Class