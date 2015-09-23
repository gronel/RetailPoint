Imports TOPCInventorySales.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frm_100_JR
#Region "Variable"
    Implements IBPSCommand

    Public myParent As frm_100_JRList
    Public bolFormState As clsPublic.FormState

    Public itemCode As String
    Public speficificCode As String

    Dim JRNo As String
    Dim oldDepartment As String
    Dim oldSection As String
    Dim item As New tbl_000_Item
    Dim ErrProvider As New ErrorProviderExtended
#End Region
#Region "Procedure"
    Sub viewReport(ByVal category As String)


        cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_JR_Report.rpt")
        arrParametersAndValue.Clear()
        arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@category", category))
        arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@JRNo", txtJRNo.Text))
        cryRpt.SetDataSource(FillReport("sp_rpt_JR", CommandType.StoredProcedure, arrParametersAndValue))
        With frm_200_ReportV
            .rpt_viewer.ReportSource = cryRpt
            .Text = "Job Requisition"
            .Show()
            .Focus()
        End With
    End Sub

    'Sub loadcomponent()
    '    Dim param1 As String = " and (Designation='P&MCD Dept. Head' or Designation='General Manager' or Designation='President')"
    '    Dim param2 As String
    '    SQL = "SELECT FirstName + ' ' + CASE WHEN MiddleName IS NULL THEN '' WHEN MiddleName = ' ' THEN '' ELSE SubString(MiddleName, 1, 1) + '. ' END + LastName + ' ' AS EmpName, IsActive FROM tbl_000_Employee WHERE (IsActive = 1)"

    '    If cboSection.Text = String.Empty And cboLine.Text = String.Empty Then
    '        param2 = SQL + "and DepartmentCode='" & cboDepartment.Text & "'"
    '        param1 = SQL + param1
    '        FillCombobox(cborequested, param2, "tbl_000_Employee", "EmpName", "EmpName")
    '        FillCombobox(cboChecked, param2, "tbl_000_Employee", "EmpName", "EmpName")
    '        FillCombobox(cboApproved, param1, "tbl_000_Employee", "EmpName", "EmpName")
    '    ElseIf cboSection.Text <> String.Empty And cboLine.Text = String.Empty Then
    '        param2 = SQL + " and DepartmentCode='" & cboDepartment.Text & "' and SectionCode='" & cboSection.Text & "'"
    '        param1 = SQL + param1
    '        FillCombobox(cborequested, param2, "tbl_000_Employee", "EmpName", "EmpName")
    '        FillCombobox(cboChecked, param2, "tbl_000_Employee", "EmpName", "EmpName")
    '        FillCombobox(cboApproved, param1, "tbl_000_Employee", "EmpName", "EmpName")
    '    ElseIf cboSection.Text <> String.Empty And cboLine.Text <> String.Empty Then
    '        param2 = SQL + " and DepartmentCode='" & cboDepartment.Text & "' and SectionCode='" & cboSection.Text & "' and linecode='" & cboLine.Text & "'"
    '        param1 = SQL + param1
    '        FillCombobox(cborequested, param2, "tbl_000_Employee", "EmpName", "EmpName")
    '        FillCombobox(cboChecked, param2, "tbl_000_Employee", "EmpName", "EmpName")
    '        FillCombobox(cboApproved, param1, "tbl_000_Employee", "EmpName", "EmpName")
    '    End If

    '    cborequested.SelectedIndex = -1
    '    cboChecked.SelectedIndex = -1
    '    cboApproved.SelectedIndex = -1

    'End Sub

    Sub loadcomponent()
        Dim param1 As String = " and (Designation='Department Head' and DepartmentCode='P&MCD') or (Designation='General Manager' or Designation='President')"
        Dim param2 As String
        Dim param3 As String = "and "
        SQL = "SELECT FirstName + ' ' + CASE WHEN MiddleName IS NULL THEN '' WHEN MiddleName = ' ' THEN '' ELSE SubString(MiddleName, 1, 1) + '. ' END + LastName + ' ' AS EmpName, IsActive FROM tbl_000_Employee WHERE (IsActive = 1)"

        If cboSection.Text = String.Empty And cboLine.Text = String.Empty Then
            param2 = SQL + "and DepartmentCode='" & cboDepartment.Text & "'"
            param1 = SQL + param1
            param3 = SQL + "and DepartmentCode='" & cboDepartment.Text & "' and Designation='Department Head'"
            FillCombobox(cborequested, param2, "tbl_000_Employee", "EmpName", "EmpName")
            FillCombobox(cboChecked, param3, "tbl_000_Employee", "EmpName", "EmpName")
            FillCombobox(cboApproved, param1, "tbl_000_Employee", "EmpName", "EmpName")
        ElseIf cboSection.Text <> String.Empty And cboLine.Text = String.Empty Then
            param2 = SQL + " and DepartmentCode='" & cboDepartment.Text & "' and SectionCode='" & cboSection.Text & "'"
            param1 = SQL + param1
            FillCombobox(cborequested, param2, "tbl_000_Employee", "EmpName", "EmpName")
            'FillCombobox(cboChecked, param2, "tbl_000_Employee", "EmpName", "EmpName")
            FillCombobox(cboApproved, param1, "tbl_000_Employee", "EmpName", "EmpName")
        ElseIf cboSection.Text <> String.Empty And cboLine.Text <> String.Empty Then
            param2 = SQL + " and DepartmentCode='" & cboDepartment.Text & "' and SectionCode='" & cboSection.Text & "' and linecode='" & cboLine.Text & "'"
            param1 = SQL + param1
            FillCombobox(cborequested, param2, "tbl_000_Employee", "EmpName", "EmpName")
            'FillCombobox(cboChecked, param2, "tbl_000_Employee", "EmpName", "EmpName")
            FillCombobox(cboApproved, param1, "tbl_000_Employee", "EmpName", "EmpName")
        End If

        cborequested.Text = String.Empty
        cboChecked.Text = String.Empty
        cboApproved.Text = String.Empty

    End Sub

    Sub enabled_tools()
        txtDepartment.Enabled = False
        txtLine.Enabled = False
        txtPrepared.Enabled = False
        txtJRNo.Enabled = False
        txtRemarks.Enabled = False
        txtSection.Enabled = False
        txtSupplier.Enabled = False
        txtSupplierType.Enabled = False
        txtTotalAmount.Enabled = False
        cboLine.Enabled = False
        cboChecked.Enabled = False
        cboApproved.Enabled = False
        cboDepartment.Enabled = False
        cboPRType.Enabled = False
        cborequested.Enabled = False
        cboSection.Enabled = False
        cboSupplier.Enabled = False
        dgDetails.Enabled = False
    End Sub

    Private Function HasRecord(ByVal JRNO As String) As Boolean
        Dim isHaveRecord As Boolean = False
        '-->check if this JR no is used in JO transaction
        If isRecordExist("SELECT     tbl_100_JO_Sub.JRNo " & _
                         "FROM         tbl_100_JO INNER JOIN " & _
                         "tbl_100_JO_Sub ON tbl_100_JO.JONo = tbl_100_JO_Sub.JONo " & _
                         "WHERE     (tbl_100_JO.isStatus <> N'CANCELLED') AND (tbl_100_JO_Sub.JRNo ='" & JRNO & "')") Then
            isHaveRecord = True
        End If
        '--> check if this JR no is used in RR transaction
        If isRecordExist("SELECT     tbl_100_RR_Sub.PRJR_No " & _
                         "FROM         tbl_100_RR INNER JOIN " & _
                         "tbl_100_RR_Sub ON tbl_100_RR.RRNo = tbl_100_RR_Sub.RRNo " & _
                         "WHERE     (tbl_100_RR.isStatus <> N'CANCELLED') AND (tbl_100_RR_Sub.PRJR_No ='" & JRNO & "')") Then
            isHaveRecord = True
        End If

        Return isHaveRecord

    End Function

    Sub voidrecord()
        If HasRecord(txtJRNo.Text) = True Then
            MsgBox("Transaction cannot be void " & vbNewLine & "is being used in other transaction", MsgBoxStyle.Exclamation, "Prompt")
            Exit Sub
        End If
      
        With opendialog
            .Tname = "JR"
            .TID = JRNo
            .ShowDialog()
        End With



    End Sub
    Sub LockFields(ByVal bolValue As Boolean)
        Try


            ''txtEmpID.ReadOnly = bolValue
            ''txtEmpName.ReadOnly = bolValue
            ''txtUsername.ReadOnly = bolValue
            ''txtPassword.ReadOnly = bolValue
            ''cboGroup.Enabled = Not bolValue
            ''txtVerify.ReadOnly = bolValue
            ''chkIsActive.Enabled = Not bolValue
            ''dgRights.ReadOnly = bolValue
            ''colFormName.ReadOnly = True
            ''btnAdd.Enabled = Not bolValue
            ''btnRemove.Enabled = Not bolValue
            ''btnBrowse.Enabled = Not bolValue

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Lock Fields")
        End Try



    End Sub

    Sub ClearFields()
        txtJRNo.Text = String.Empty
        cboDepartment.Text = String.Empty
        cboSection.Text = String.Empty
        cboLine.Text = String.Empty
        cboSupplier.Text = String.Empty
        cboPRType.Text = String.Empty
        cboApproved.Text = String.Empty
        cborequested.Text = String.Empty
        cboChecked.Text = String.Empty
        txtRemarks.Text = String.Empty
    End Sub

    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        LockFields(True)
        ''grpList.Enabled = True
        ActivateCommands(FormState.LoadState)
        Me.Close()

    End Sub

    Sub SaveRecord()
        Dim JR As New tbl_100_JR

        SQL = DBLookUp("Select JRNo from tbl_100_JR_Sub where JRNO='" & JRNo & "' and ((Status='" & isDone & "') or (Status='" & isLacking & "') or (Status='" & isPlaced & "') or (Status='" & isExcess & "'))", "JRNo")
        If JRNo = "" Then
        Else
            If JRNo = SQL Then
                MsgBox("Invalid to update is being used in other transaction", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If



        Dim strResult As Boolean
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("SELECT JRNo FROM tbl_100_JR WHERE JRNo='" & txtJRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtJRNo, "JRNo is already exist!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtJRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtJRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtJRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtJRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtJRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtJRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
                ElseIf CheckActualPrice() Then
                    MsgBox("Invalid Actual Price.", MsgBoxStyle.Exclamation, "Actual Price")
                ElseIf CountGridRows(dgDetails) = 0 Then
                    MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf CountGridRows(dgDetails) = 0 Then
                    MsgBox("Empty Fields!", MsgBoxStyle.Exclamation)
                    Exit Sub
                Else
                    For Each rows As DataGridViewRow In dgDetails.Rows
                        If rows.IsNewRow = False Then
                            If rows.Cells("colReqQty").Value = 0 Then
                                MsgBox("Quantity is required!", MsgBoxStyle.Exclamation)
                                Exit Sub
                            End If
                        End If
                    Next

                    With JR
                        .JRNo = txtJRNo.Text
                        .DepartmentCode = cboDepartment.Text
                        .SectionCode = cboSection.Text
                        .LineCode = cboLine.Text
                        .SupplierID = cboSupplier.Text
                        .SupplierType = txtSupplierType.Text
                        .DateRequested = (dtDateRequested.Text)
                        .DateNeeded = (dtDateNeeded.Text)
                        .JORRSchedule = (dtPOSchedule.Text)
                        .JRType = cboPRType.Text
                        .PreparedBy = txtPrepared.Text
                        .RequestBy = cborequested.Text
                        .ApprovedBy = cboApproved.Text
                        .CheckedBy = cboChecked.Text
                        .TotalAmount = txtTotalAmount.Text
                        .Remarks = txtRemarks.Text
                        .Total = txtTotalAmount.Text
                        .CurrencyType = cboCurrency.Text
                        .Dec = cbodec.Text
                        If bolFormState = FormState.EditState Then
                            _OpenTransaction()
                            strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                            _CloseTransaction(strResult)
                            MsgBox("Updated Complete", MsgBoxStyle.Information, "Update")

                            Me.Close()
                            myParent.RefreshRecord("sp_100_Get_JR_List '" & MainForm.tsSearch.Text & "'")

                        Else
                            '    If MsgBox("Do you want to print?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Printing Prompt") = MsgBoxResult.Yes Then
                            '        _OpenTransaction()
                            '        strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                            '        _CloseTransaction(strResult)

                            '        viewReport()
                            '        frm_200_ReportV.rpt_viewer.PrintReport()

                            '        Me.Close()
                            '        myParent.RefreshRecord()
                            '        myParent.Focus()
                            'ElseIf MsgBoxResult.No Then
                            If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Prompt") = MsgBoxResult.Yes Then
                                _OpenTransaction()
                                strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                                _CloseTransaction(strResult)
                                Me.Close()
                                myParent.RefreshRecord("sp_100_Get_JR_List '" & MainForm.tsSearch.Text & "'")

                            Else
                                Me.Close()
                                myParent.RefreshRecord("sp_100_Get_JR_List '" & MainForm.tsSearch.Text & "'")

                            End If
                        End If
                        ' End If




                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Save Record")
        Finally
            JR = Nothing
        End Try
    End Sub

    Private Sub PreviewFromTemp()
        Dim cls As New tmp_JR
        If ErrProvider.CheckAndShowSummaryErrorMessage Then
            If bolFormState = FormState.AddState And isRecordExist("SELECT JRNo FROM tbl_100_JR WHERE JRNo='" & txtJRNo.Text & "'") Then
                ErrorProvider1.SetError(txtJRNo, "JRNo is already exist!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtJRNo.Text & "'") Then
                ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtJRNo.Text & "'") Then
                ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtJRNo.Text & "'") Then
                ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtJRNo.Text & "'") Then
                ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtJRNo.Text & "'") Then
                ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtJRNo.Text & "'") Then
                ErrorProvider1.SetError(txtJRNo, "This ID No. being used by another transaction!")
            ElseIf CheckActualPrice() Then
                MsgBox("Invalid Actual Price.", MsgBoxStyle.Exclamation, "Actual Price")
            ElseIf CountGridRows(dgDetails) = 0 Then
                MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                Exit Sub
            ElseIf CountGridRows(dgDetails) = 0 Then
                MsgBox("Empty Fields!", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                For Each rows As DataGridViewRow In dgDetails.Rows
                    If rows.IsNewRow = False Then
                        If rows.Cells("colReqQty").Value = 0 Then
                            MsgBox("Quantity is required!", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    End If
                Next


                With cls
                    .JRNo = txtJRNo.Text
                    .DepartmentCode = cboDepartment.Text
                    .SectionCode = cboSection.Text
                    .LineCode = cboLine.Text
                    .SupplierID = cboSupplier.Text
                    .SupplierType = txtSupplierType.Text
                    .DateRequested = (dtDateRequested.Text)
                    .DateNeeded = (dtDateNeeded.Text)
                    .JORRSchedule = (dtPOSchedule.Text)
                    .JRType = cboPRType.Text
                    .PreparedBy = txtPrepared.Text
                    .RequestBy = cborequested.Text
                    .ApprovedBy = cboApproved.Text
                    .CheckedBy = cboChecked.Text
                    .TotalAmount = txtTotalAmount.Text
                    .Remarks = txtRemarks.Text
                    .Total = txtTotalAmount.Text
                    .CurrencyType = cboCurrency.Text
                    .Dec = cbodec.Text
                    .Save(dgDetails)
                    Call viewReport("Temp")

                    RunQuery("Delete from tmp_JR")
                    RunQuery("Delete from tmp_JR_Sub")
                End With
            End If
        End If

    End Sub

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                ''NewRecord()
            Case "Edit"
                ''EditRecord()
            Case "Void"
                voidrecord()
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
            Case "Print"
              
                viewReport("JR")

            Case "Preview"
                If isRecordExist("Select JRNo from tbl_100_JR where JRNO='" & txtJRNo.Text & "'") Then
                    Call viewReport("JR")
                Else
                    Call PreviewFromTemp()
                End If


        End Select
    End Sub

    Sub FillSection()
        If Not cboDepartment.SelectedValue Is Nothing Then
            txtDepartment.Text = cboDepartment.SelectedItem.Col2
            
            Call loadcomponent()


        Else
            txtDepartment.Text = String.Empty
        End If
        If oldDepartment <> cboDepartment.Text Then
            cboSection.Text = String.Empty
            txtSection.Text = String.Empty
            cboLine.Text = String.Empty
            txtLine.Text = String.Empty
            LoadSectionToMultiCombo(cboSection, cboDepartment.Text)

        End If
    End Sub


    Sub FillLine()
        If Not cboSection.SelectedValue Is Nothing Then
            txtSection.Text = cboSection.SelectedItem.Col2
   
            Call loadcomponent()

        Else
            txtSection.Text = String.Empty
        End If
        If oldSection <> cboSection.Text Then
            cboLine.Text = String.Empty
            txtLine.Text = String.Empty
            LoadLineToMultiCombo(cboLine, cboSection.Text)
        End If
    End Sub

    Sub FillLineTextBox()
        If Not cboLine.SelectedValue Is Nothing Then
            txtLine.Text = cboLine.SelectedItem.Col2
         
            Call loadcomponent()

        Else
            txtLine.Text = String.Empty
        End If
    End Sub

    Sub FillSupplierTextBox()
        If Not cboSupplier.SelectedValue Is Nothing Then
            txtSupplier.Text = cboSupplier.SelectedItem.Col2
            txtSupplierType.Text = cboSupplier.SelectedItem.Col4
        Else
            txtSupplier.Text = String.Empty
            txtSupplierType.Text = String.Empty
        End If
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
                    .tsPreview.Enabled = True
                    .tsPrint.Enabled = False
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
                    .tsVoid.Enabled = True
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

    Public Sub fillCode(ByVal rowindex As Integer)
        With dgDetails
            If .Item("colSpecificCode", rowindex).Value = String.Empty Then
                Exit Sub
            End If
            Dim arrParameterAndValue As ArrayList = New ArrayList
            arrParameterAndValue = FetchData(arrParameterAndValue, "sp_FillDataGridViewCell'" & "JR" & "','" & .Item("colSpecificCode", rowindex).Value & "'", CommandType.Text)

            If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                '-->indicate if the row is null
            Else
                SQL = "SELECT     TOP (1) ActualUnitPrice " & _
                      "FROM tbl_100_RR_Sub " & _
                        "where SpecificCode ='" & .Item("colSpecificCode", rowindex).Value & "'" & _
                          "ORDER BY RRDate DESC"

                .Item("colItemCode", rowindex).Value = arrParameterAndValue(0).ToString
                .Item("colTOCCOde", rowindex).Value = arrParameterAndValue(1).ToString
                .Item("colDescription", rowindex).Value = arrParameterAndValue(2).ToString
                .Item("colBrandType", rowindex).Value = arrParameterAndValue(3).ToString
                .Item("colActualUnit", rowindex).Value = arrParameterAndValue(4).ToString
                .Item("colLastService", rowindex).Value = DBLookUp("Select top 1 RRDate from tbl_100_RR_Sub where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "RRDate")
                .Item("colReqQty", rowindex).Value = 0
                .Item("colActualPrice", rowindex).Value = CDbl(0.0)
                .Item("colActualPrice", rowindex).Value = FormatNumber(NZ(DBLookUp(SQL, "ActualUnitPrice")), CInt(NZ((cbodec.Text))))
            End If
        End With


    End Sub



    Sub ComputeAllRows()
        Dim sum As Double
        With dgDetails
            For i = 0 To .RowCount - 2
                sum = sum + NZ(.Item("colAmount", i).Value)
            Next

            txtTotalAmount.Text = String.Format("{0:N" + cbodec.Text + "}", (NZ(sum)))

        End With
    End Sub

    Sub AddFields(ByVal rowIndex As Integer)
        With dgDetails
            dgDetails.Item("colReqQty", rowIndex).Value = FormatNumber(CDbl(dgDetails.Item("colReqQty", rowIndex).Value), 0)
            dgDetails.Item("colActualPrice", rowIndex).Value = FormatNumber(CDbl(NZ(dgDetails("colActualPrice", rowIndex).Value)), Val(cbodec.Text))

            .Item("colAmount", rowIndex).Value = FormatNumber(CDbl(NZ(.Item("colReqQty", rowIndex).Value)) * CDbl(NZ(.Item("colActualPrice", rowIndex).Value)), Val(cbodec.Text))
        End With
    End Sub

    Private Function CheckActualPrice() As Boolean
        Dim blnResult As Boolean = False
        Try
            For Each row As DataGridViewRow In dgDetails.Rows
                If Not row.IsNewRow Then
                    If row.Cells("colActualPrice").Value = 0 Then
                        blnResult = True
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        Finally
            CheckActualPrice = blnResult
        End Try
    End Function

    Sub SetEditValue()
        Dim JR As New tbl_100_JR

        JRNo = myParent.dgList.Item("colJRNo", myParent.dgList.CurrentRow.Index).Value

        With JR
            .FetchPR(JRNo)
            txtJRNo.Text = .JRNo
            cboDepartment.SelectedValue = .DepartmentCode
            cboSection.SelectedValue = .SectionCode
            cboLine.SelectedValue = .LineCode
            cboSupplier.SelectedValue = .SupplierID
            txtSupplierType.Text = .SupplierType
            dtDateRequested.Text = .DateRequested
            dtDateNeeded.Text = .DateNeeded
            dtPOSchedule.Text = .JORRSchedule
            cboPRType.Text = .JRType
            Call loadcomponent()
            txtPrepared.Text = .PreparedBy
            cborequested.Text = .RequestBy
            cboChecked.Text = .CheckedBy
            cboApproved.Text = .ApprovedBy
            txtTotalAmount.Text = FormatNumber(.TotalAmount)
            txtRemarks.Text = .Remarks
            cboCurrency.Text = .CurrencyType
            cbodec.Text = .Dec
        End With

        FillDataGrid(dgDetails, "GetjR_Sub '" & JRNo & "'", 0, 11)
        txtJRNo.Enabled = False
        decc()
        lblcurrency.Text = cboCurrency.Text
    End Sub

    Sub decc()
        For i = 0 To dgDetails.RowCount - 1

            AddFields(i)
            ComputeAllRows()

        Next
    End Sub

#End Region

#Region "GUI"
    Private Sub frm_100_JR_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        If bolFormState = FormState.EditState Then
            SetEditValue()
        Else
            cboChecked.Text = ""
            cboApproved.Text = ""
            cborequested.Text = ""
        End If
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_100_JR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        End If
    End Sub

    Private Sub frm_100_JR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Me.Width = My.Computer.Screen.WorkingArea.Width - 100
        ResizeForm(Me)

        'Call POP_UP_MSG()

        With ErrProvider
            .Controls.Clear()
            .Controls.Add(cboCurrency, "Currency Type")
            .Controls.Add(txtJRNo, "JR Number")
            .Controls.Add(txtDepartment, "Department Code")
            .Controls.Add(txtSupplier, "Supplier ID")
            .Controls.Add(dtDateRequested, "Date Requested")
            .Controls.Add(dtDateNeeded, "Date Needed")
            .Controls.Add(cboPRType, "JR Type")
            .Controls.Add(dtPOSchedule, "JO Schedule")
            .Controls.Add(txtPrepared, "Prepared By")
            .Controls.Add(cborequested, "Requested By")
            .Controls.Add(cboChecked, "Checked By")
            .Controls.Add(cboApproved, "Approved By")
            .Controls.Add(cbodec, "Decimal Places")
        End With

        CenterControl(lblTitle, Me)
        LoadDepartmentToMultiCombo(cboDepartment)
        LoadSupplierToMultiCombo(cboSupplier)

        txtPrepared.Text = CurrUser.USER_FULLNAME


        LoadCurrencyType(cboCurrency)
    End Sub

    Private Sub cboPRType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRType.SelectedIndexChanged
        If cboPRType.Text = "Cash" Then
            lblPlacement.Text = "RR Placement Schedule"
        Else
            lblPlacement.Text = "JO Placement Schedule"
        End If
    End Sub

    Private Sub cboDepartment_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartment.Enter
        oldDepartment = cboDepartment.Text
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartment.SelectedIndexChanged
        Call FillSection()
    End Sub

    Private Sub cboDepartment_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartment.Validated
        If Not cboDepartment.SelectedValue Is Nothing Then
            txtDepartment.Text = cboDepartment.SelectedItem.Col2

        Else
            txtDepartment.Text = String.Empty
        End If
        If oldDepartment <> cboDepartment.Text Then
            cboSection.Text = String.Empty
            txtSection.Text = String.Empty
            cboLine.Text = String.Empty
            txtLine.Text = String.Empty
            LoadSectionToMultiCombo(cboSection, cboDepartment.Text)
        End If
    End Sub

    Private Sub cboSection_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSection.Enter
        oldSection = cboSection.Text
    End Sub

    Private Sub cboSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSection.SelectedIndexChanged
        FillLine()
    End Sub

    Private Sub cboSection_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSection.Validated
        If Not cboSection.SelectedValue Is Nothing Then
            txtSection.Text = cboSection.SelectedItem.Col2



        Else
            txtSection.Text = String.Empty
        End If
        If oldSection <> cboSection.Text Then
            cboLine.Text = String.Empty
            txtLine.Text = String.Empty
            LoadLineToMultiCombo(cboLine, cboSection.Text)
        End If
    End Sub

    Private Sub cboLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLine.SelectedIndexChanged
        FillLineTextBox()
    End Sub

    Private Sub cboLine_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLine.Validated
        If Not cboLine.SelectedValue Is Nothing Then
            txtLine.Text = cboLine.SelectedItem.Col2



        Else
            txtLine.Text = String.Empty
        End If
    End Sub

    Private Sub cboSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSupplier.SelectedIndexChanged
        FillSupplierTextBox()
    End Sub

    Private Sub cboSupplier_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSupplier.Validated
        FillSupplierTextBox()
    End Sub

    Private Sub dgDetails_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgDetails.CellValidating
        Try
            Select Case e.ColumnIndex
                Case colSpecificCode.Index
                    If CheckCodeFromDatagridView(dgDetails, 0, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                        dgDetails.CancelEdit()
                        MsgBox("Specific Code already exists in the list.", MsgBoxStyle.Exclamation, "Duplicate Code")
                    Else
                        If bolFormState <> FormState.EditState Then
                            fillCode(e.RowIndex)
                        End If
                    End If

                Case colActualPrice.Index
                    If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                        MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                        e.Cancel = True
                    End If

                Case colReqQty.Index
                    If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                        MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                        e.Cancel = True
                    End If

                Case colLastService.Index
                    If dgDetails.Item("colLastService", e.RowIndex).FormattedValue <> "" Then
                        If IsDate((dgDetails.Item("colLastService", e.RowIndex).EditedFormattedValue)) = False Then
                            MsgBox("Please enter correct date.", MsgBoxStyle.Exclamation, "Invalid Date")
                            dgDetails.CancelEdit()

                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Select Case e.ColumnIndex
            Case 1
                frmSearchItems.frm = "JR"
                frmSearchItems.ShowDialog()
        End Select
    End Sub

    Public Sub dgDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellValidated

        AddFields(e.RowIndex)
        ComputeAllRows()

    End Sub

    Private Sub btncopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncopy.Click
        With frmUnit
            .trans = "JR"
            .ShowDialog()
        End With
    End Sub

    Private Sub cbodec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbodec.SelectedIndexChanged
        decc()
    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurrency.SelectedIndexChanged
        lblcurrency.Text = cboCurrency.Text
    End Sub
#End Region
End Class