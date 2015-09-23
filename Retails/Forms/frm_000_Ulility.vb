Imports Retails.clsPublic
Public Class frm_000_Ulility
    Implements IBPSCommand
#Region "Class Variables"

    Dim utility As String
    Dim clsutility As New clsUtility
    Dim bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended

#End Region
  

    Private Sub dgCatigory_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCatigory.CellEnter
        If bolFormState = FormState.EditState Then
            lblcategory.Focus()
        End If
    End Sub

    Private Sub dgCatigory_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgCatigory.CellValidating
        If dgCatigory.CurrentCell.ColumnIndex = 1 Then
            If CheckCodeFromDatagridView(dgCatigory, 1, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                dgCatigory.CancelEdit()
                MsgBox("Category name already exists in the list.", MsgBoxStyle.Exclamation, "Existing Warehouse")
            End If
        End If
    End Sub

    Private Sub dgCatigory_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgCatigory.DataBindingComplete
        If bolFormState <> FormState.EditState Then
            Try
                For intX As Integer = 0 To dgCatigory.RowCount - 1
                    If Not ("").Equals(Me.dgCatigory.Rows(intX).Cells(0).Value.ToString) Then
                        Me.dgCatigory.Rows(intX).ReadOnly = True
                        Me.dgCatigory.Rows(intX).DefaultCellStyle.BackColor = Color.LightBlue
                    End If
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub dgCatigory_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgCatigory.RowsAdded
        lblcategory.Text = CountGridRows(dgCatigory)
    End Sub

    Private Sub dgCatigory_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgCatigory.RowsRemoved
        lblcategory.Text = CountGridRows(dgCatigory)
    End Sub

    Private Sub HideRecored()
        Me.TabControl1.Controls.Remove(Me.tab1)
        Me.TabControl1.Controls.Remove(Me.tab2)
        Me.TabControl1.Controls.Remove(Me.tab3)
        Me.TabControl1.Controls.Remove(Me.tab4)
        Me.TabControl1.Controls.Remove(Me.tab5)
        If isSale = True Then

            Me.TabControl1.Controls.Add(Me.tab4)
            Me.TabControl1.Controls.Add(Me.tab5)
        ElseIf isSale = False Then
            Me.TabControl1.Controls.Add(Me.tab1)
            Me.TabControl1.Controls.Add(Me.tab2)
            Me.TabControl1.Controls.Add(Me.tab3)
          
        End If

    End Sub

    Private Sub frm_000_Ulility_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_000_Ulility_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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


    Private Sub frm_000_Ulility_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        CenterControl(lblTitle, Me)

        HideRecored()
        RefreshRecord()
        ActivateCommands(FormState.ViewState)

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
    Sub RefreshRecord()
        ''Record in Company Category
        clsutility.FillCompanyCategory(dgCatigory)
        lblcategory.Text = dgCatigory.RowCount
        dgCatigory.AllowUserToAddRows = False
        dgCatigory.AllowUserToDeleteRows = True
        dgCatigory.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ''Record in Payment Terms
        clsutility.FillPayTerm(dgPayTerm)
        lblPayterms.Text = dgPayTerm.RowCount
        dgPayTerm.AllowUserToAddRows = False
        dgPayTerm.AllowUserToDeleteRows = True
        dgPayTerm.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ''Record in Transportation
        clsutility.FillTransport(dgtransport)
        lbltransport.Text = dgtransport.RowCount
        dgtransport.AllowUserToAddRows = False
        dgtransport.AllowUserToDeleteRows = True
        dgtransport.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        ''Record in Customer Payment Terms
        clsutility.FillCustPayTerm(dgpaytermCust)
        Label5.Text = dgpaytermCust.RowCount
        dgpaytermCust.AllowUserToAddRows = False
        dgpaytermCust.AllowUserToDeleteRows = True
        dgpaytermCust.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ''Record in Internal Suplier
        clsutility.FillInternalSupplier(dginternal)
        dginternal.AllowUserToAddRows = False
        dginternal.AllowUserToDeleteRows = True
        dginternal.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        ActivateCommands(FormState.ViewState)
        RefreshRecord()
    End Sub

    Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

        Select Case strCmd

            Case "New"
                Select Case isSale

                    Case True
                        ''For Payment Terms
                        dgpaytermCust.AllowUserToAddRows = True
                        dgpaytermCust.SelectionMode = DataGridViewSelectionMode.CellSelect
                        dgpaytermCust.Rows(dgpaytermCust.RowCount - 1).Cells(1).Selected = True

                        ''For Internal Supplier
                        dginternal.AllowUserToAddRows = True
                        dginternal.SelectionMode = DataGridViewSelectionMode.CellSelect
                        dginternal.Rows(dginternal.RowCount - 1).Cells(1).Selected = True

                    Case False
                        ''For Company Category
                        dgCatigory.AllowUserToAddRows = True
                        dgCatigory.SelectionMode = DataGridViewSelectionMode.CellSelect
                        dgCatigory.Rows(dgCatigory.RowCount - 1).Cells(1).Selected = True


                        ''For Payment Terms
                        dgPayTerm.AllowUserToAddRows = True
                        dgPayTerm.SelectionMode = DataGridViewSelectionMode.CellSelect
                        dgPayTerm.Rows(dgPayTerm.RowCount - 1).Cells(1).Selected = True


                        ''For transfortation Terms
                        dgtransport.AllowUserToAddRows = True
                        dgtransport.SelectionMode = DataGridViewSelectionMode.CellSelect
                        dgtransport.Rows(dgtransport.RowCount - 1).Cells(1).Selected = True
                End Select

                ActivateCommands(FormState.AddState)
            Case "Edit"
                Select Case isSale

                    Case True
                        ''For customer payment Terms
                        For intX As Integer = 0 To dgpaytermCust.RowCount - 1
                            Me.dgpaytermCust.Rows(intX).ReadOnly = False
                            Me.dgpaytermCust.Rows(intX).DefaultCellStyle.BackColor = Color.White
                        Next
                        dgpaytermCust.SelectionMode = DataGridViewSelectionMode.CellSelect

                        ''For Internal Supplier
                        For intX As Integer = 0 To dginternal.RowCount - 1
                            Me.dginternal.Rows(intX).ReadOnly = False
                            Me.dginternal.Rows(intX).DefaultCellStyle.BackColor = Color.White
                        Next
                        dginternal.SelectionMode = DataGridViewSelectionMode.CellSelect


                    Case False
                        ''For Company Category
                        For intX As Integer = 0 To dgCatigory.RowCount - 1
                            Me.dgCatigory.Rows(intX).ReadOnly = False
                            Me.dgCatigory.Rows(intX).DefaultCellStyle.BackColor = Color.White
                        Next

                        dgCatigory.SelectionMode = DataGridViewSelectionMode.CellSelect

                        ''For payment Terms
                        For intX As Integer = 0 To dgPayTerm.RowCount - 1
                            Me.dgPayTerm.Rows(intX).ReadOnly = False
                            Me.dgPayTerm.Rows(intX).DefaultCellStyle.BackColor = Color.White
                        Next

                        dgPayTerm.SelectionMode = DataGridViewSelectionMode.CellSelect

                        ''For Transportation
                        For intX As Integer = 0 To dgtransport.RowCount - 1
                            Me.dgtransport.Rows(intX).ReadOnly = False
                            Me.dgtransport.Rows(intX).DefaultCellStyle.BackColor = Color.White
                        Next

                        dgtransport.SelectionMode = DataGridViewSelectionMode.CellSelect

                End Select

                ActivateCommands(FormState.EditState)
            Case "Delete"
                Select Case isSale
                    Case True

                        If TabControl1.SelectedIndex.ToString = 0 Then


                            If dgpaytermCust.SelectedRows.Count = 0 Then
                                MsgBox("Please select row/s to be deleted.", MsgBoxStyle.Exclamation, "Delete")
                            Else
                                If vbYes = MsgBox("Are you sure you want to delete this Payment Terms?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
                                    Dim strCriteria As String = ""
                                    For Each tmpList As DataGridViewRow In dgpaytermCust.SelectedRows
                                        If strCriteria <> "" Then
                                            strCriteria += ","
                                        End If
                                        strCriteria += "'" & dgpaytermCust.Rows(tmpList.Index).Cells(0).Value.ToString & "'"
                                    Next
                                    _OpenTransaction()
                                    _CloseTransaction(_DeleteRecord("tbl_000_Customer_PayTerms", "WHERE PayTermsID in (" & strCriteria & ")"))
                                    RefreshRecord()
                                    doCancel()
                                    ''ClearFields()
                                End If
                            End If

                        ElseIf TabControl1.SelectedIndex.ToString = 1 Then

                            If dginternal.SelectedRows.Count = 0 Then
                                MsgBox("Please select row/s to be deleted.", MsgBoxStyle.Exclamation, "Delete")
                            Else
                                If vbYes = MsgBox("Are you sure you want to delete this Payment Terms?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
                                    Dim strCriteria As String = ""
                                    For Each tmpList As DataGridViewRow In dginternal.SelectedRows
                                        If strCriteria <> "" Then
                                            strCriteria += ","
                                        End If
                                        strCriteria += "'" & dginternal.Rows(tmpList.Index).Cells(0).Value.ToString & "'"
                                    Next
                                    _OpenTransaction()
                                    _CloseTransaction(_DeleteRecord("tbl_000_InternalSupplier", "WHERE inSupplierCode in (" & strCriteria & ")"))
                                    RefreshRecord()
                                    doCancel()
                                    ''ClearFields()
                                End If
                            End If

                        End If

                    Case False

                        If TabControl1.SelectedIndex.ToString = 0 Then
                            If dgCatigory.SelectedRows.Count = 0 Then
                                MsgBox("Please select row/s to be deleted.", MsgBoxStyle.Exclamation, "Delete")
                            Else
                                If vbYes = MsgBox("Are you sure you want to delete this Category Name?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
                                    Dim strCriteria As String = ""
                                    For Each tmpList As DataGridViewRow In dgCatigory.SelectedRows
                                        If strCriteria <> "" Then
                                            strCriteria += ","
                                        End If
                                        strCriteria += "'" & dgCatigory.Rows(tmpList.Index).Cells(0).Value.ToString & "'"
                                    Next
                                    _OpenTransaction()
                                    _CloseTransaction(_DeleteRecord("tbl_000_Supplier_ComCategory", "WHERE ComCatID in (" & strCriteria & ")"))
                                    RefreshRecord()
                                    doCancel()
                                    ''ClearFields()
                                End If
                            End If
                        ElseIf TabControl1.SelectedIndex.ToString = 1 Then
                            If dgPayTerm.SelectedRows.Count = 0 Then
                                MsgBox("Please select row/s to be deleted.", MsgBoxStyle.Exclamation, "Delete")
                            Else
                                If vbYes = MsgBox("Are you sure you want to delete this Payment Terms?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
                                    Dim strCriteria As String = ""
                                    For Each tmpList As DataGridViewRow In dgPayTerm.SelectedRows
                                        If strCriteria <> "" Then
                                            strCriteria += ","
                                        End If
                                        strCriteria += "'" & dgPayTerm.Rows(tmpList.Index).Cells(0).Value.ToString & "'"
                                    Next
                                    _OpenTransaction()
                                    _CloseTransaction(_DeleteRecord("tbl_000_Supplier_PayTerms", "WHERE PayTermsID in (" & strCriteria & ")"))
                                    RefreshRecord()
                                    doCancel()
                                    ''ClearFields()
                                End If
                            End If
                        ElseIf TabControl1.SelectedIndex.ToString = 2 Then
                            If dgtransport.SelectedRows.Count = 0 Then
                                MsgBox("Please select row/s to be deleted.", MsgBoxStyle.Exclamation, "Delete")
                            Else
                                If vbYes = MsgBox("Are you sure you want to delete this Payment Terms?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
                                    Dim strCriteria As String = ""
                                    For Each tmpList As DataGridViewRow In dgtransport.SelectedRows
                                        If strCriteria <> "" Then
                                            strCriteria += ","
                                        End If
                                        strCriteria += "'" & dgtransport.Rows(tmpList.Index).Cells(0).Value.ToString & "'"
                                    Next
                                    _OpenTransaction()
                                    _CloseTransaction(_DeleteRecord("tbl_000_Transport", "WHERE DeliveryID in (" & strCriteria & ")"))
                                    RefreshRecord()
                                    doCancel()
                                    ''ClearFields()
                                End If
                            End If
                        End If

                End Select
            Case "Save"
                Select Case isSale

                    Case True
                        'If clsutility.SaveCustomerPayterm(dgpaytermCust) = True Then

                        '    doCancel()
                        'End If
                        dginternal.CommitEdit(DataGridViewDataErrorContexts.Commit)
                        dgpaytermCust.CommitEdit(DataGridViewDataErrorContexts.Commit)
                        If clsutility.UpdateSalesUtility = True Then

                            doCancel()
                        End If
                    Case False
                        If clsutility.UpdateUtility Then
                            doCancel()
                        End If
                End Select



            Case "Cancel"
                If vbYes = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm") Then
                    doCancel()
                End If
            Case "Refresh"
                RefreshRecord()
        End Select

    End Sub

    Private Sub dgPayTerm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPayTerm.CellContentClick

    End Sub

    Private Sub dgPayTerm_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPayTerm.CellEnter
        If bolFormState = FormState.EditState Then
            lblPayterms.Focus()
        End If
    End Sub

    Private Sub dgPayTerm_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgPayTerm.CellValidating
        If dgPayTerm.CurrentCell.ColumnIndex = 1 Then
            If CheckCodeFromDatagridView(dgPayTerm, 1, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                dgPayTerm.CancelEdit()
                MsgBox("Category name already exists in the list.", MsgBoxStyle.Exclamation, "Existing Warehouse")
            End If
        End If
    End Sub

    Private Sub dgPayTerm_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgPayTerm.DataBindingComplete
        If bolFormState <> FormState.EditState Then
            Try
                For intX As Integer = 0 To dgPayTerm.RowCount - 1
                    If Not ("").Equals(Me.dgPayTerm.Rows(intX).Cells(0).Value.ToString) Then
                        Me.dgPayTerm.Rows(intX).ReadOnly = True
                        Me.dgPayTerm.Rows(intX).DefaultCellStyle.BackColor = Color.LightBlue
                    End If
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub dgPayTerm_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgPayTerm.RowsAdded
        lblPayterms.Text = CountGridRows(dgPayTerm)
    End Sub

    Private Sub dgPayTerm_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgPayTerm.RowsRemoved
        lblPayterms.Text = CountGridRows(dgPayTerm)
    End Sub

    Private Sub dgtransport_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        lbltransport.Text = CountGridRows(dgtransport)

    End Sub

    Private Sub dgtransport_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgtransport.CellEnter
        If bolFormState = FormState.EditState Then
            lbltransport.Focus()
        End If
    End Sub

    Private Sub dgtransport_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgtransport.CellValidating
        If dgtransport.CurrentCell.ColumnIndex = 1 Then
            If CheckCodeFromDatagridView(dgtransport, 1, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                dgtransport.CancelEdit()
                MsgBox("Category name already exists in the list.", MsgBoxStyle.Exclamation, "Existing Warehouse")
            End If
        End If
    End Sub

    Private Sub dgtransport_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgtransport.DataBindingComplete
        If bolFormState <> FormState.EditState Then
            Try
                For intX As Integer = 0 To dgtransport.RowCount - 1
                    If Not ("").Equals(Me.dgtransport.Rows(intX).Cells(0).Value.ToString) Then
                        Me.dgtransport.Rows(intX).ReadOnly = True
                        Me.dgtransport.Rows(intX).DefaultCellStyle.BackColor = Color.LightBlue
                    End If
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

  

    Private Sub dgtransport_RowsAdded1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgtransport.RowsAdded
        lbltransport.Text = CountGridRows(dgtransport)
    End Sub

    Private Sub dgtransport_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgtransport.RowsRemoved
        lbltransport.Text = CountGridRows(dgtransport)
    End Sub

  

    Private Sub dgpaytermCust_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgpaytermCust.CellContentClick

    End Sub

    Private Sub dgpaytermCust_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgpaytermCust.CellValidating
        If dgpaytermCust.CurrentCell.ColumnIndex = 1 Then
            If CheckCodeFromDatagridView(dgpaytermCust, 1, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                dgpaytermCust.CancelEdit()
                MsgBox("Category name already exists in the list.", MsgBoxStyle.Exclamation, "Existing Warehouse")
            End If
        End If
    End Sub

    Private Sub dgpaytermCust_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgpaytermCust.DataBindingComplete
        If bolFormState <> FormState.EditState Then
            Try
                For intX As Integer = 0 To dgpaytermCust.RowCount - 1
                    If Not ("").Equals(Me.dgpaytermCust.Rows(intX).Cells(0).Value.ToString) Then
                        Me.dgpaytermCust.Rows(intX).ReadOnly = True
                        Me.dgpaytermCust.Rows(intX).DefaultCellStyle.BackColor = Color.LightBlue
                    End If
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub dgpaytermCust_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgpaytermCust.Enter
        If bolFormState = FormState.EditState Then
            Label5.Focus()
        End If
    End Sub

    Private Sub dgpaytermCust_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgpaytermCust.RowsAdded
        Label5.Text = CountGridRows(dgpaytermCust)
    End Sub

    Private Sub dgpaytermCust_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgpaytermCust.RowsRemoved
        Label5.Text = CountGridRows(dgpaytermCust)
    End Sub

    Private Sub dginternal_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dginternal.RowsAdded
        lblinternalSupplier.Text = CountGridRows(dginternal)
    End Sub

    Private Sub dginternal_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dginternal.RowsRemoved
        lblinternalSupplier.Text = CountGridRows(dginternal)
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If bolFormState = FormState.ViewState Then

        ElseIf bolFormState <> FormState.ViewState Then
            e.Cancel = True
        End If
    End Sub

    Private Sub dginternal_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dginternal.CellEnter
        If bolFormState = FormState.EditState Then
            lblinternalSupplier.Focus()
        End If
    End Sub

    Private Sub dginternal_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dginternal.CellValidating
        If dginternal.CurrentCell.ColumnIndex = 1 Then
            If CheckCodeFromDatagridView(dgpaytermCust, 1, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                dginternal.CancelEdit()
                MsgBox("Supplier ID already exists in the list.", MsgBoxStyle.Exclamation, "Existing Warehouse")
            End If
        End If
    End Sub

    Private Sub dginternal_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dginternal.DataBindingComplete
        If bolFormState <> FormState.EditState Then
            Try
                For intX As Integer = 0 To dginternal.RowCount - 1
                    If Not ("").Equals(Me.dginternal.Rows(intX).Cells(0).Value.ToString) Then
                        Me.dginternal.Rows(intX).ReadOnly = True
                        Me.dginternal.Rows(intX).DefaultCellStyle.BackColor = Color.LightBlue
                    End If
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub dginternal_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dginternal.Enter
        If bolFormState = FormState.EditState Then
            lblinternalSupplier.Focus()
        End If
    End Sub
End Class