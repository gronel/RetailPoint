Imports Retails.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_100_WR
#Region "variable"
    Implements IBPSCommand
    Public myParent As frm_100_WRList
    Public bolFormState As clsPublic.FormState
    Public itemCode As String
    Public speficificCode As String
    Public WRcode As String
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
                ' SaveRecord()
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

    Sub AddFields(ByVal rowIndex As Integer)

        With dgDetails
            .Item("colAmount", rowIndex).Value = FormatNumber((NZ(.Item("colQty", rowIndex).Value)) * CDbl(NZ(.Item("colCost", rowIndex).Value)), dec)
        End With
    End Sub

    Sub SaveRecord(ByVal ispost As Boolean)
        Dim WR As New tbl_100_WR
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
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("Select poCode from tbl_100_PO where poCode='" & txtwrcode.Text & "'") Then
                    ErrProvider.SetError(txtwrcode, "PO Number already exists.")

                ElseIf CountGridRows(dgDetails) = 0 Then
                    MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf CountGridRows(dgDetails) = 0 Then
                    MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                    Exit Sub
                Else
                    If dgDetails.RowCount = 0 Then
                        MsgBox("Empty value")
                        Exit Sub
                    End If
                    'If HasRecord(txtPONo.Text) = True Then
                    '    MsgBox("Invalid to Delete this transaction is being used by other transaction", MsgBoxStyle.Exclamation, "Prompt")
                    '    Exit Sub
                    'End If


                    With WR
                        .wrId = txtwrcode.Text
                        .wrTotalCost = txtTotalAmount.Text
                        .createdBy = CurrUser.USER_FULLNAME
                        .createdDte = Date.Now
                        .wrComments = txtcomments.Text
                        .isPosted = ispost


                        If bolFormState = FormState.EditState Then
                            _OpenTransaction()
                            strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                            _CloseTransaction(strResult)
                            MsgBox("Updated Complete", MsgBoxStyle.Information, "Update")

                            Me.Close()

                            myParent.RefreshRecord("sproc_100_wr_list " & False & ",'" & MainForm.tsSearch.Text & "'")
                            myParent.RefreshRecord2("sproc_100_wr_list " & True & ",'" & MainForm.tsSearch.Text & "'")
                        Else

                            If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Prompt") = MsgBoxResult.Yes Then
                                _OpenTransaction()
                                strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                                _CloseTransaction(strResult)
                                Me.Close()
                                myParent.RefreshRecord("sproc_100_wr_list " & False & ",'" & MainForm.tsSearch.Text & "'")
                                myParent.RefreshRecord2("sproc_100_wr_list " & True & ",'" & MainForm.tsSearch.Text & "'")
                            End If
                        End If
                    End With
                End If
            End If
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
                    .tsSave.Enabled = False
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
                    .tsSave.Enabled = False
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

    

    Sub ComputeAllRows()
        Dim sum As Double
        With dgDetails
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colAmount", i).Value)
            Next
            txtTotalAmount.Text = String.Format("{0:N" + CStr(dec) + "}", (NZ(sum)))
        End With
    End Sub

    Sub SetEditValue()
        Dim WR As New tbl_100_WR
        With WR
            WRcode = myParent.dgList1.Item("colWRCode", myParent.dgList1.CurrentRow.Index).Value
            'PONo = myParent.dgList.Item(0, myParent.dgList.CurrentCell.Index).Value
            'PONo = myParent.dgList.CurrentCell.Value
            .FetchRecord(WRcode)
            txtwrcode.Text = WRcode
            txtcomments.Text = .wrComments

            txtTotalAmount.Text = FormatNumber(.wrTotalCost)

        End With
        '  FillGrid(dgDetails, String.Format("select  itemId, ItemCode, ItemName, ItemDescription, BrandType, drQty, UOM, drCost, drAmount from v_dr_item where (drCode='{0}')", DRcode), "v_dr_item")

        FillDataGrid(dgDetails, String.Format("select  itemId, ItemCode, ItemName, ItemDescription, BrandType, Qty, UOM, Cost, Amount from v_wr_item where (wrId='{0}')", WRcode), 1, 9)
        txtwrcode.Enabled = False

        For i = 0 To dgDetails.RowCount - 1
            AddFields(i)
        Next
        ComputeAllRows()
    End Sub

    Private Sub frm_100_PO_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        If bolFormState = FormState.EditState Then
            SetEditValue()
        Else
            txtwrcode.ReadOnly = True
            txtwrcode.Text = tbl_100_WR.GenerateID


        End If
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_100_PO_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            ' SaveRecord()
        End If
    End Sub


    Private Sub frm_100_PO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResizeForm(Me)
        CenterControl(lblTitle, Me) 'center the title of the transaction


        With ErrProvider 'Get the error or empty text
            .Controls.Clear()
            .Controls.Add(txtwrcode, "WR Code")
            .Controls.Add(txtcomments, "Comments")



        End With
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        frm_100_WR_Search_Item.myParent = Me
        frm_100_WR_Search_Item.ShowDialog()
    End Sub

    Private Sub dgDetails_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetails.CellValidated
        AddFields(e.RowIndex)
        ComputeAllRows()
    End Sub

    Private Sub dgDetails_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgDetails.CellValidating
        AddFields(e.RowIndex)
        ComputeAllRows()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For Each row As DataGridViewRow In dgDetails.Rows
            If row.Cells("colSelect").Value = True Then
                dgDetails.Rows.Remove(row)
            End If
        Next
        ComputeAllRows()
    End Sub

    Private Sub dgDetails_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgDetails)
        ComputeAllRows()
    End Sub

    Private Sub dgDetails_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgDetails)
        ComputeAllRows()
    End Sub




    Private Sub btnSavepost_Click(sender As Object, e As EventArgs) Handles btnSavepost.Click
        SaveRecord(True)
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        SaveRecord(False)
    End Sub
End Class