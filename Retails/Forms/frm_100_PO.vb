Imports Retails.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_100_PO
#Region "variable"
    Implements IBPSCommand
    Public myParent As frm_100_POList
    Public bolFormState As clsPublic.FormState
    Public itemCode As String
    Public speficificCode As String
    Public PONo As String
    Dim oldDepartment As String
    Dim oldSection As String
    Dim ErrProvider As New ErrorProviderExtended
    Public rowindex As Integer
    Public x As String
    Dim dec As Integer
#End Region

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                ''NewRecord()
            Case "Edit"
                ''EditRecord()
           
            Case "Delete"
                ''DeleteRecord()
            Case "Save"
                SaveRecord()
            Case "Cancel"
                If vbYes = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm") Then
                    doCancel()
                End If
            Case "Refresh"
                ''RefreshRecord()
            Case "Preview"
                'If isRecordExist("Select PONo from tbl_100_PO where PONO='" & txtPONo.Text & "'") Then
                '    Call viewReport("PO")
                'Else
                '    Call PreviewFromTemp()
                'End If

            Case "Print"
                'viewReport("PO")
                '  frm_200_ReportV.rpt_viewer.PrintReport()
        End Select
    End Sub

    Sub SaveRecord()
        Dim PO As New tbl_100_PO
        'SQL = DBLookUp("Select PONo from tbl_100_PO_Sub where PONo='" & PONo & "' and ((Status='" & isDelivered & "') or (Status='" & isLacking & "')  or (Status='" & isExcess & "'))", "PONo")
        'If PONo = "" Then
        'Else
        '    If PONo = SQL Then
        '        MsgBox("Invalid to update is being used in other transaction", MsgBoxStyle.Exclamation)
        '        Exit Sub
        '    End If
        'End If



        Dim strResult As Boolean
        Try
            'If ErrProvider.CheckAndShowSummaryErrorMessage Then
            '    If bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtPONo.Text & "'") Then
            '        ErrorProvider1.SetError(txtPONo, "PO Number already exists.")
            '    ElseIf bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtPONo.Text & "'") Then
            '        ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
            '    ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtPONo.Text & "'") Then
            '        ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
            '    ElseIf bolFormState = FormState.AddState And isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtPONo.Text & "'") Then
            '        ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
            '    ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtPONo.Text & "'") Then
            '        ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
            '    ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtPONo.Text & "'") Then
            '        ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")
            '    ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtPONo.Text & "'") Then
            '        ErrorProvider1.SetError(txtPONo, "This ID No. is being used by another transaction!")

            '    ElseIf CountGridRows(dgDetails) = 0 Then
            '        MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
            '        Exit Sub
            '    ElseIf CountGridRows(dgDetails) = 0 Then
            '        MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
            '        Exit Sub
            '    Else
            '        If dgDetails.RowCount = 0 Then
            '            MsgBox("Empty value")
            '            Exit Sub
            '        End If
            '        If HasRecord(txtPONo.Text) = True Then
            '            MsgBox("Invalid to Delete this transaction is being used by other transaction", MsgBoxStyle.Exclamation, "Prompt")
            '            Exit Sub
            '        End If


            '        With PO
            '            .PONo = txtPONo.Text
            '            .DateRequested = dtDateneed.Text
            '            .SupplierID = cbosupplier.Text
            '            .SupplierType = txtSupplierType.Text
            '            .DeliveryDate = dtDateDelivery.Text
            '            .DeliveryBy = cboDeliveryBy.Text
            '            .PaymentTerm = txtterm.Text
            '            .PayablePaymentDate = txtpaydate.Text
            '            .PreparedBy = txtPrepared.Text
            '            .CheckedBy = txtchecked.Text
            '            .ApprovedBy = cboApproved.Text
            '            .TotalAmount = txtTotalAmount.Text
            '            .Remarks = txtRemarks.Text
            '            .CurrencyType = cboCurrency.Text
            '            .Dec = dec
            '            If bolFormState = FormState.EditState Then
            '                _OpenTransaction()
            '                strResult = .Save(bolFormState = FormState.EditState, dgDetails)
            '                _CloseTransaction(strResult)
            '                MsgBox("Updated Complete", MsgBoxStyle.Information, "Update")

            '                Me.Close()
            '                myParent.RefreshRecord("sp_100_Get_PO_List'" & MainForm.tsSearch.Text & "'")

            '            Else

            '                If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Prompt") = MsgBoxResult.Yes Then
            '                    _OpenTransaction()
            '                    strResult = .Save(bolFormState = FormState.EditState, dgDetails)
            '                    _CloseTransaction(strResult)
            '                    Me.Close()
            '                    myParent.RefreshRecord("sp_100_Get_PO_List'" & MainForm.tsSearch.Text & "'")
            '                End If
            '            End If
            '        End With
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()

        ''grpList.Enabled = True
        ActivateCommands(FormState.LoadState)
        Me.Close()

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
                    .tsPreview.Enabled = True
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
                    .tsFilterClear.Enabled = False
                    .tsFilterOn.Enabled = False
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
                    .tsFilterClear.Enabled = False
                    .tsFilterOn.Enabled = False
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

    Private Sub frm_100_PO_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        End If
    End Sub


    Private Sub frm_100_PO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResizeForm(Me)
        CenterControl(lblTitle, Me) 'center the title of the transaction

    End Sub
End Class