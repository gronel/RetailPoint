Imports Retails.clsPublic

Public Class frm_000_ExchangeRate

    Implements IBPSCommand

    Dim ERCode As String
    Dim bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Dim isLooping As Boolean = True, formLoad As Boolean = True

    Private Sub frm_000_ExchangeRate_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        setUserRights(Me.Tag)
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_000_ExchangeRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frm_000_ExchangeRate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image

        Call FillCurrencyCombo()
       
        ActivateCommands(FormState.LoadState)
        LockFields(True)
        Call RefreshRecord()
    End Sub

    Private Sub NewRecord()
        'ClearFields()
        LockFields(False)
        bolFormState = FormState.AddState
        txtERCode.Focus()
        ActivateCommands(FormState.AddState)

    End Sub

    Private Sub EditRecord()
        LockFields(False)
        bolFormState = FormState.EditState
        txtERCode.ReadOnly = True
        ActivateCommands(FormState.EditState)
    End Sub

    Sub DeleteRecord()

        If vbYes = MsgBox("Are you sure you want to delete this Exchange Rate?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
            RunQuery("Delete from tbl_000_ExchangeRate_Sub where code='" & txtcode.Text & "'")
            RunQuery("Delete from tbl_000_ExchangeRate where Exratecode='" & txtcode.Text & "'")
            RefreshRecord()
            doCancel()
            ClearFields()

        End If
    End Sub

    Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                NewRecord()
            Case "Edit"
                EditRecord()
            Case "Delete"
                DeleteRecord()
            Case "Save"
                SaveRecord()
            Case "Cancel"
                If vbYes = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm") Then
                    doCancel()
                End If
            Case "Refresh"
                RefreshRecord()
        End Select

    End Sub

    Private Sub RefreshRecord()
        ActivateCommands(FormState.ViewState)
        FillDataGrid(dglist, "SELECT     tbl_000_ExchangeRate.Exratecode, tbl_Status.Description, tbl_Status.StatusID " & _
                             "FROM         tbl_000_ExchangeRate INNER JOIN " & _
                             "tbl_Status ON tbl_000_ExchangeRate.Currencyconversion = tbl_Status.StatusID", 0, 2)

        lblRecordCount.Text = dglist.RowCount

     

    End Sub

    Private Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        LockFields(True)
        dglist.Enabled = True
        ClearFields()
        ActivateCommands(FormState.ViewState)
    End Sub

    Private Sub SetEditValue()
        Dim ER As New tbl_000_ExchangeRate
        Try
            txtcode.Text = dglist.Item(0, dglist.CurrentRow.Index).Value
            cboratecode.SelectedValue = dglist.Item(2, dglist.CurrentRow.Index).Value
            txtERCode.Text = dglist.Item(1, dglist.CurrentRow.Index).Value



            FillDataGrid(dgExchangeRate, " SELECT     ExrateDetailedCode, ExrateValue " & _
                                         "FROM tbl_000_ExchangeRate_Sub  " & _
                                         "WHERE     (code = '" & txtcode.Text & "')    ", 0, 1)


            LockFields(True)

            For i = 0 To dgExchangeRate.RowCount - 1
                Call ADDfield(i)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ER = Nothing
        End Try

    End Sub

    Private Sub ClearFields()
        Try
            txtcode.Text = String.Empty
            ERCode = String.Empty
            txtERCode.Text = String.Empty
            cboCurrencyTo.SelectedIndex = -1
            dgExchangeRate.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Clear Fields")
        End Try
    End Sub

    Private Sub SaveRecord()
        Dim ER As New tbl_000_ExchangeRate
        Try
            ''If ErrProvider.CheckAndShowSummaryErrorMessage Then
            'If bolFormState = FormState.AddState And isRecordExist("SELECT CID FROM tbl_000_ExchangeRate WHERE CID = '" & txtERCode.Text.Trim & "'") Then
            '    MsgBox("Exchange Rate Code already exist.", MsgBoxStyle.Exclamation, "Duplicate")
            'ElseIf bolFormState = FormState.AddState And isRecordExist("SELECT CID FROM tbl_000_ExchangeRate WHERE CurrencyFrom='" & cboCurrencyFrom.SelectedValue & "' AND CurrencyTo='" & cboCurrencyTo.SelectedValue & "'") Then
            '    MsgBox("This currency exchange already exists.", MsgBoxStyle.Exclamation, "Duplicate")
            'Else

            dgExchangeRate.CommitEdit(DataGridViewDataErrorContexts.Commit)


            With ER
                .ExhangeRateCode = txtcode.Text
                .ExrateDescription = cboratecode.SelectedValue
                _OpenTransaction()
                _Result = .Save(bolFormState = FormState.EditState, dgExchangeRate)
                _CloseTransaction(_Result)
                If _Result = False Then Exit Sub
                If bolFormState = FormState.AddState Then
                    MsgBox("Save complete", MsgBoxStyle.Information, "Prompt")
                Else
                    MsgBox("Update complete", MsgBoxStyle.Information, "Prompt")
                End If

                RefreshRecord()
                ClearFields()
                LockFields(True)

            End With



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Save Record")
        Finally
            ER = Nothing
        End Try

    End Sub

    Private Sub LockFields(ByVal bolValue As Boolean)
        Try
            txtERCode.ReadOnly = bolValue
            cboCurrencyTo.Enabled = Not bolValue
            colYear.ReadOnly = bolValue
            colERValue.ReadOnly = bolValue
            txtcode.ReadOnly = bolValue

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Lock Fields")
        End Try
    End Sub

    Private Sub ActivateCommands(ByVal frmState As clsPublic.FormState)
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
                    cboratecode.Visible = True
                    txtERCode.Visible = False
                    dgExchangeRate.AllowUserToAddRows = True
                    dgExchangeRate.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                    dgExchangeRate.AllowUserToDeleteRows = True
                Case FormState.EditState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                    cboratecode.Visible = False
                    txtERCode.Visible = True
                    dgExchangeRate.AllowUserToAddRows = False
                    dgExchangeRate.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                    dgExchangeRate.AllowUserToDeleteRows = True
                Case FormState.ViewState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = True
                    .tsDelete.Enabled = True
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                    cboratecode.Visible = False
                    txtERCode.Visible = True
                    dgExchangeRate.AllowUserToAddRows = False
                    dgExchangeRate.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    dgExchangeRate.AllowUserToDeleteRows = False
                Case FormState.LoadState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                    cboratecode.Visible = False
                    txtERCode.Visible = True
                    dgExchangeRate.AllowUserToAddRows = False
                    dgExchangeRate.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    dgExchangeRate.AllowUserToDeleteRows = False
            End Select

        End With
    End Sub

    Private Sub frm_000_ExchangeRate_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterControl(lblTitle, Me)
    End Sub

    Private Sub FillCurrencyCombo()

        'FillCombobox(cboratecode, "Select Cid,ConversionType from tbl_ConversionType", "tbl_ConversionType", "ConversionType", "Cid")

        FillCombobox(cboratecode, "SELECT     StatusID, Description, Usage FROM tbl_Status WHERE     (Usage = N'conversiontype')", "tbl_Status", "Description", "StatusID")
        cboratecode.SelectedIndex = -1

    End Sub

    Private Sub dgList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dglist.CellClick
        SetEditValue()
    End Sub

    Private Sub dgExchangeRate_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgExchangeRate.CellValidated
        Call ADDfield(e.RowIndex)

    End Sub

    Private Sub dgList_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dglist.RowsAdded
        lblRecordCount.Text = dglist.RowCount
    End Sub

    Private Sub dgList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dglist.RowsRemoved
        lblRecordCount.Text = dglist.RowCount
    End Sub

    Private Sub cboratecode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboratecode.SelectedIndexChanged
        'If cboratecode.SelectedValue.ToString = "System.Data.DataRowView" Then Exit Sub
        'FillDataGrid(dgExchangeRate, "GetExchangeRate '" & cboratecode.SelectedValue & "'", 0, 1)
        'txtERCode.Text = cboratecode.Text
        'lblERCount.Text = dgExchangeRate.RowCount - 1
    End Sub

   

    Private Sub ADDfield(ByVal rowindex As Integer)
        With dgExchangeRate
            Dim uppervalue As String = .Item(0, rowindex).Value
            If uppervalue = Nothing Then Exit Sub

            Dim s As String = StrConv(dgExchangeRate.Rows(rowindex).Cells(0).Value.ToString, VbStrConv.Uppercase)
            dgExchangeRate.Rows(rowindex).Cells(0).Value = s
        End With
    End Sub


    Private Sub dgExchangeRate_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgExchangeRate.RowsAdded
        lblERCount.Text = CountGridRows(dgExchangeRate)
    End Sub

    Private Sub dgExchangeRate_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgExchangeRate.RowsRemoved
        lblERCount.Text = CountGridRows(dgExchangeRate)
    End Sub

  
End Class