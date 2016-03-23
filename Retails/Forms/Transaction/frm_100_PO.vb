Imports RetailPoint.clsPublic
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
                If isRecordExist("Select poCode from tbl_100_PO where poCode='" & txtPONo.Text & "'") Then
                    Call viewReport("PO")
                Else
                    MessageBox.Show("No Data", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information)


                End If

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
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("Select poCode from tbl_100_PO where poCode='" & txtPONo.Text & "'") Then
                    ErrProvider.SetError(txtPONo, "PO Number already exists.")
              
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


                    With PO
                        .poCode = txtPONo.Text
                        .poVendor = cboVendor.SelectedValue
                        .status = cboStatus.Text
                        .totalCost = txtTotalAmount.Text
                        .orderDte = dtepOD.Text
                        .shippingDte = dtepSD.Text
                        .closedDte = dtepCD.Text


                        If bolFormState = FormState.EditState Then
                            _OpenTransaction()
                            strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                            _CloseTransaction(strResult)
                            MsgBox("Updated Complete", MsgBoxStyle.Information, "Update")

                            Me.Close()
                            myParent.RefreshRecord("sproc_100_po_list'" & MainForm.tsSearch.Text & "'")

                        Else

                            If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Prompt") = MsgBoxResult.Yes Then
                                _OpenTransaction()
                                strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                                _CloseTransaction(strResult)
                                Me.Close()
                                myParent.RefreshRecord("sproc_100_po_list'" & MainForm.tsSearch.Text & "'")
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

    Sub fillcombo()
        FillCombobox(cboVendor, "SELECT  SupplierID, SupplierName FROM  tbl_000_Supplier", "tbl_000_Location", "SupplierName", "SupplierID")

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
        Dim PO As New tbl_100_PO
        With PO
            PONo = myParent.dgList.Item("colPoCode", myParent.dgList.CurrentRow.Index).Value
            'PONo = myParent.dgList.Item(0, myParent.dgList.CurrentCell.Index).Value
            'PONo = myParent.dgList.CurrentCell.Value
            .FetchRecord(PONo)
            txtPONo.Text = PONo
            cboStatus.Text = .status
            cboVendor.SelectedValue = .poVendor
            dtepCD.Text = .closedDte
            dtepOD.Text = .orderDte
            dtepSD.Text = .shippingDte
            txtTotalAmount.Text = FormatNumber(.totalCost)
          
        End With

        FillDataGrid(dgDetails, String.Format("select ItemId, ItemCode, ItemName, ItemDescription, BrandType, poQty, UOM, poCost, poAmount from v_po_item where (poCode='{0}')", PONo), 1, 9)
        txtPONo.Enabled = False

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


        End If
        ActivateCommands(bolFormState)
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
        Call fillcombo()

        With ErrProvider 'Get the error or empty text
            .Controls.Clear()
            .Controls.Add(txtPONo, "PO Code")
            .Controls.Add(cboVendor, "Vendor")
            .Controls.Add(cboStatus, "Po Status")
           

        End With
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        frm_100_PO_Search_Item.myParent = Me
        frm_100_PO_Search_Item.ShowDialog()
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
            dgDetails.Rows.Remove(row)
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

    Private Sub viewReport(ByVal category As String)

        cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_PO_Report.rpt")

        arrParametersAndValue.Clear()
        arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@poCode", txtPONo.Text))
        cryRpt.SetDataSource(FillReport("sproc_200_po", CommandType.StoredProcedure, arrParametersAndValue))
        cryRpt.SetParameterValue("prepared", CurrUser.USER_FULLNAME)
        With frm_200_ReportV
            .rpt_viewer.ReportSource = cryRpt
            .Text = "Purchase Order"
            .Show()
            .Focus()
        End With
    End Sub
End Class