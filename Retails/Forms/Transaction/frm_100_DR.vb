Imports RetailPoint.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_100_DR
#Region "variable"
    Implements IBPSCommand
    Public myParent As frm_100_DRList
    Public bolFormState As clsPublic.FormState
    Public itemCode As String
    Public speficificCode As String
    Public DRcode As String
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
        Dim DR As New tbl_100_DR
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
                If bolFormState = FormState.AddState And isRecordExist("Select poCode from tbl_100_PO where poCode='" & txtdrcode.Text & "'") Then
                    ErrProvider.SetError(txtdrcode, "PO Number already exists.")

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


                    With DR
                        .drCode = txtdrcode.Text
                        .vendor = cboVendor.SelectedValue
                        .drDate = dtepRD.Text
                        .totalCost = txtTotalAmount.Text
                        .createdBy = CurrUser.USER_FULLNAME
                        .createdDte = Date.Now
                        .remarks = txtremakrs.Text
                        .isPosted = ispost
                        .pocode = cboPoCode.SelectedValue


                        If bolFormState = FormState.EditState Then
                            _OpenTransaction()
                            strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                            _CloseTransaction(strResult)
                            MsgBox("Updated Complete", MsgBoxStyle.Information, "Update")

                            Me.Close()

                            myParent.RefreshRecord("sproc_100_dr_list " & False & ",'" & MainForm.tsSearch.Text & "'")
                            myParent.RefreshRecord2("sproc_100_dr_list " & True & ",'" & MainForm.tsSearch.Text & "'")
                        Else

                            If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Prompt") = MsgBoxResult.Yes Then
                                _OpenTransaction()
                                strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                                _CloseTransaction(strResult)
                                Me.Close()
                                myParent.RefreshRecord("sproc_100_dr_list " & False & ",'" & MainForm.tsSearch.Text & "'")
                                myParent.RefreshRecord2("sproc_100_dr_list " & True & ",'" & MainForm.tsSearch.Text & "'")
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

    Sub fillcombo()
        FillCombobox(cboVendor, "SELECT  SupplierID, SupplierName FROM  tbl_000_Supplier", "tbl_000_Location", "SupplierName", "SupplierID")
        FillCombobox(cboPoCode, "SELECT  poCode FROM  tbl_100_PO where (status='OPEN')", "tbl_100_PO", "poCode", "poCode")
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
        Dim DR As New tbl_100_DR
        With DR
            DRcode = myParent.dgList1.Item("colDRCode", myParent.dgList1.CurrentRow.Index).Value
            'PONo = myParent.dgList.Item(0, myParent.dgList.CurrentCell.Index).Value
            'PONo = myParent.dgList.CurrentCell.Value
            .FetchRecord(DRcode)
            txtdrcode.Text = DRcode
            txtremakrs.Text = .remarks
            cboVendor.SelectedValue = .vendor
            cboPoCode.Text = .pocode
            dtepRD.Text = .drDate
            txtTotalAmount.Text = FormatNumber(.totalCost)

        End With
        '  FillGrid(dgDetails, String.Format("select  itemId, ItemCode, ItemName, ItemDescription, BrandType, drQty, UOM, drCost, drAmount from v_dr_item where (drCode='{0}')", DRcode), "v_dr_item")

        FillDataGrid(dgDetails, String.Format("select  itemId, ItemCode, ItemName, ItemDescription, BrandType, drQty, UOM, drCost, drAmount from v_dr_item where (drCode='{0}')", DRcode), 0, 8)
        txtdrcode.Enabled = False

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
            cboVendor.SelectedIndex = -1
            cboPoCode.SelectedIndex = -1

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
        Call fillcombo()

        With ErrProvider 'Get the error or empty text
            .Controls.Clear()
            .Controls.Add(txtdrcode, "DR Code")
            .Controls.Add(cboVendor, "Vendor")
        End With
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        frm_100_DR_Search_Item.myParent = Me
        frm_100_DR_Search_Item.ShowDialog()
    End Sub

    Private Sub dgDetails_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetails.CellValidated
        AddFields(e.RowIndex)
        ComputeAllRows()
    End Sub

    Private Sub dgDetails_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgDetails.CellValidating
        AddFields(e.RowIndex)
        ComputeAllRows()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        RemoveFromDataGrid(dgDetails)
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

    Private Sub dgDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim intCheckAll As Integer = dgDetails.Columns("colSelect").Index

    End Sub
End Class