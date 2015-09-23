Imports TOPCInventorySales.clsPublic
Imports System.Data.SqlClient
Public Class frm_100_CashAdvance

    Implements IBPSCommand
    Dim strDataGridSearchValue As String
    Dim CANo As String
    Dim UserID As Integer
    Dim bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
#Region "Search function"
    Dim bolFilter As Boolean
    Dim strFilter As String
    Dim strFilterHead As String
    Dim strFilterField As String
    Dim BS As New BindingSource
    Sub Filter()
        Try
            With dgList
                If .SelectedCells.Count = 0 Then Exit Sub
                strFilterField = .Columns(.CurrentCell.ColumnIndex).DataPropertyName
                strFilterHead = .Columns(.CurrentCell.ColumnIndex).HeaderText
                strFilter = strFilter & " AND " & strFilterField & "='" & .CurrentCell.Value & "' "
                bolFilter = True
            End With

            SearchRecord()
            dgList.ClearSelection()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR[Search]")
        End Try

    End Sub
    Private Sub SearchRecord()
        Try
            Dim myconn As SqlConnection = New SqlConnection(cnString)
            Dim da As SqlDataAdapter = New SqlDataAdapter("GetCA", myconn)
            Dim ds As DataSet = New DataSet()
            ds.Clear()
            da.Fill(ds, "tbl_100_CashAdvance")
            BS.DataSource = ds.Tables(0)

            Dim strSQL As String = "(CANo LIKE '%" & MainForm.tsSearch.Text & "%' OR Requestor LIKE'%" & MainForm.tsSearch.Text & "%')"
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
    Sub ClearFilter()
        strFilter = String.Empty
        bolFilter = False
        Call SearchRecord()
    End Sub
    ''' <summary>
    ''' Refresh all Records
    ''' </summary>
    ''' <remarks></remarks>
    Sub RefreshRecord()
        Try
            MainForm.tsSearch.Clear()
            Call ClearFilter()
            Dim myconn As SqlConnection = New SqlConnection(cnString)
            Dim da As SqlDataAdapter = New SqlDataAdapter("GetCA", myconn)
            Dim ds As DataSet = New DataSet()
            ds.Clear()
            da.Fill(ds, "tbl_100_CashAdvance")
            BS.DataSource = ds.Tables(0)
            dgList.DataSource = BS
            lblRecordCount.Text = dgList.RowCount
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
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

    
    Private Sub cboItemCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartment.SelectedIndexChanged
        FillTextBox()
    End Sub

    Private Sub cboItemCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartment.Validated
        FillTextBox()
    End Sub

    Sub FillTextBox()
        If Not cboDepartment.SelectedValue Is Nothing Then
            txtDepartment.Text = cboDepartment.SelectedItem.Col2
        Else
            txtDepartment.Text = String.Empty
        End If
    End Sub

    Private Sub frm_100_CashAdvance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        clsPublic.LoadDepartmentToMultiCombo(cboDepartment)
        RefreshRecord()

        LockFields(True)

        With ErrProvider
            .Controls.Add(txtCANo, "CA No.")
            .Controls.Add(txtDepartment, "Deparment")
            .Controls.Add(txtDepartment, "Deparment")
            .Controls.Add(cbopurpose, "Purpose")
        End With

        ActivateCommands(FormState.LoadState)
        FillCombobox(cbopurpose, "Select Purpose from tbl_100_CashAdvance", "tbl_100_CashAdvance", "Purpose", "Purpose")
    End Sub

    Private Sub dgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellDoubleClick
        Call Filter()
    End Sub

    Private Sub dgList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellEnter
        SetEditValue()
    End Sub


    Sub NewRecord()
        LockFields(False)
        ''grpList.Enabled = False
        ClearFields()
        txtCANo.Focus()
        ActivateCommands(FormState.AddState)
        UserID = CurrUser.USER_ID
        txtRequestor.Text = CurrUser.USER_FULLNAME
    End Sub

    Sub EditRecord()
        LockFields(False)
        ''grpList.Enabled = False
        ActivateCommands(FormState.EditState)
        txtCANo.ReadOnly = True
    End Sub

    Sub DeleteRecord()
        If isRecordExist("SELECT CANo FROM tbl_100_CashAdvance WHERE CANo='" & CANo & "'") Then

        ElseIf vbYes = MsgBox("Are you sure you want to delete this CashAdvance?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm Delete") Then
            _intDeletedRow = dgList.CurrentRow.Index
            _OpenTransaction()
            _Result = _DeleteRecord("tbl_100_CashAdvance", "WHERE CANo='" & CANo & "'")
            _CloseTransaction(_Result)
            If _Result Then
                RefreshRecord()
                doCancel()
                ClearFields()
                SelectDataGridViewRow(dgList)
            End If
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

    'Sub RefreshRecord()
    '    ActivateCommands(FormState.LoadState)
    '    FillGrid(dgList, "GetCA", "tbl_100_CashAdvance")
    '    lblRecordCount.Text = dgList.RowCount

    'End Sub



    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        LockFields(True)
        ''grpList.Enabled = True
        ActivateCommands(FormState.LoadState)
    End Sub

    Sub SetEditValue()

        Dim CA As New tbl_100_CA

        Try
            CANo = dgList.Item(0, dgList.CurrentRow.Index).Value

            With CA
                .FetchRecord(CANo)
                txtCANo.Text = .CANo
                txtRequestor.Text = .Requestor
                dtCADate.Value = .CADate
                cboDepartment.SelectedValue = .DepartmentCode
                cbopurpose.Text = .Purpose
            End With

            FillDataGrid(dgSub, "GetCASub '" & CANo & "'", 0, 2)

            LockFields(True)


            ActivateCommands(FormState.ViewState)
            ComputeTotalAmount()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CA = Nothing
        End Try
    End Sub

    Sub ClearFields()
        Try

            CANo = String.Empty
            txtCANo.Text = String.Empty
            txtRequestor.Text = String.Empty
            cbopurpose.Text = String.Empty
            cboDepartment.SelectedIndex = -1
            dgSub.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Clear Fields")
        End Try
    End Sub

    Private Sub SaveRecord()

        Dim CA As New tbl_100_CA
        Dim strResult As Boolean

        Try

            If ErrProvider.CheckAndShowSummaryErrorMessage = False Then

            ElseIf bolFormState = FormState.AddState And isRecordExist("SELECT CANo FROM tbl_100_CashAdvance WHERE CANo='" & txtCANo.Text.Trim & "'") Then
                MsgBox("CA No. already exist.", MsgBoxStyle.Exclamation, "Duplicate")
            ElseIf GridHasRows(dgSub) = False Then
                MsgBox("Please enter Cash Advance details.", MsgBoxStyle.Exclamation, "No details")
            ElseIf GridHasZeroValue(dgSub, 2) = False Then
                MsgBox("Detail amount must not be zero.", MsgBoxStyle.Exclamation, "Zero Amount")
            Else
                dgSub.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
                ComputeTotalAmount()

                With CA
                    .CANo = txtCANo.Text.Trim
                    .Requestor = txtRequestor.Text.Trim
                    .CADate = dtCADate.Text
                    .DepartmentCode = cboDepartment.SelectedValue
                    .Purpose = cbopurpose.Text.Trim
                    .TotalAmount = txtTotalAmount.Text

                    _OpenTransaction()
                    strResult = .Save(bolFormState = FormState.EditState, dgSub)
                    _CloseTransaction(strResult)
                End With

                If strResult Then
                    If bolFormState = FormState.EditState Then
                        MsgBox("Updated!", MsgBoxStyle.Information, "Updated")
                    Else
                        MsgBox("Saved!", MsgBoxStyle.Information, "Saved")
                    End If

                    strDataGridSearchValue = CANo
                    RefreshRecord()
                    SelectDataGridViewRow(dgList, 0, strDataGridSearchValue)
                    doCancel()
                    SetEditValue()
                End If


            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Save Record")
        Finally
            CA = Nothing
        End Try

    End Sub

    Sub LockFields(ByVal bolValue As Boolean)
        Try
            txtCANo.ReadOnly = bolValue
            'txtRequestor.ReadOnly = bolValue
            cboDepartment.Enabled = Not bolValue
            cbopurpose.Enabled = Not bolValue
            dgSub.Enabled = Not bolValue


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Lock Fields")
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
                    .tsVoid.Enabled = False
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
                    .tsVoid.Enabled = True
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
                    .tsVoid.Enabled = False
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
                    .tsVoid.Enabled = False
                    .tsPrint.Enabled = False
                    .tsPrint.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
            End Select

        End With
    End Sub

    Private Sub dgSub_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSub.CellValidated

        dgSub.Item("colAmount", e.RowIndex).Value = CDbl(NZ(dgSub.Item("colAmount", e.RowIndex).Value)) * 1
        ComputeTotalAmount()
    End Sub

    Private Sub dgSub_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgSub.CellValidating


        Select Case e.ColumnIndex
            Case 0
                If CheckCodeFromDatagridView(dgSub, 0, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                    MsgBox("Reference No. already in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                    e.Cancel = True
                End If
            Case 1
                If ValidateNumericDataGrid(dgSub, 1, e.RowIndex, False) = False Then
                    MsgBox("Please enter numeric value. ", MsgBoxStyle.Exclamation, "Invalid Entry")
                    e.Cancel = True
                End If

        End Select
        ''ComputeTotalAmount()
    End Sub

    Private Sub dgSub_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgSub.RowsAdded
        lblCountSub.Text = CountGridRows(dgSub)
        ''ComputeTotalAmount()
    End Sub

    Private Sub dgSub_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgSub.RowsRemoved
        lblCountSub.Text = CountGridRows(dgSub)
        ''ComputeTotalAmount()
    End Sub

    Private Sub frm_000_Category_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CenterControl(lblTitle, Me)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub ComputeTotalAmount()
        Dim TotalAmount As Double = 0

        Try


            For Each row As DataGridViewRow In dgSub.Rows
                If Not row.IsNewRow Then
                    TotalAmount = TotalAmount + Double.Parse(dgSub.Item(2, row.Index).Value.ToString)
                End If
            Next
            txtTotalAmount.Text = FormatNumber(TotalAmount, 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgSub_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSub.CellContentClick
        Select Case e.ColumnIndex
            Case 1
                frmSearchCash.meparent = Me

                frmSearchCash.ShowDialog()
                ComputeTotalAmount()
        End Select
    End Sub

    Private Sub dgList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgList.CellContentClick

    End Sub
End Class