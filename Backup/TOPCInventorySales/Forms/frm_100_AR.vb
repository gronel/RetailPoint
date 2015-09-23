Imports TOPCInventorySales.clsPublic
Imports System.Data.SqlClient

Public Class frm_100_AR


#Region "Variable"
    Implements IBPSCommand
    Public bolFormState As clsPublic.FormState
    Public myParent As frm_100_ARList
    Public itemCode As String
    Public speficificCode As String
    Public ARNo As String
    Dim oldDepartment As String
    Dim oldSection As String
    Dim item As New tbl_000_Item
    Dim ErrProvider As New ErrorProviderExtended
    Dim cctype As String
    Public deptcode, sectioncode, linecode As String
    Dim paramList As ArrayList = New ArrayList




#End Region

#Region "Procedure"

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
        End Select
    End Sub


    Sub ClearFields()
        txtARNo.Text = String.Empty
        cboDepartment.Text = String.Empty
        cboSection.Text = String.Empty
        cboLine.Text = String.Empty
    End Sub

    Sub ClearAllHeader()
        cboDepartment.Text = String.Empty
        cboSection.Text = String.Empty
        cboLine.Text = String.Empty
        cboemployee.Text = String.Empty
        txtemployee.Text = String.Empty

        txtDepartment.Text = String.Empty
        txtSection.Text = String.Empty
        txtLine.Text = String.Empty

    End Sub
    Sub doCancel()
        RunQuery("Delete from tmp_Act_Employee where CompName='" & ComputerName & "'")
        ErrProvider.ClearAllErrorMessages()

        ''grpList.Enabled = True
        ActivateCommands(FormState.LoadState)
        Me.Close()
        frmMember.Close()
    End Sub

    Private Sub SaveRecord()
        Dim AR As New tbl_100_AR
        Dim strResult As Boolean
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtARNo.Text & "'") Then
                    ErrorProvider1.SetError(txtARNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtARNo.Text & "'") Then
                    ErrorProvider1.SetError(txtARNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtARNo.Text & "'") Then
                    ErrorProvider1.SetError(txtARNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtARNo.Text & "'") Then
                    ErrorProvider1.SetError(txtARNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtARNo.Text & "'") Then
                    ErrorProvider1.SetError(txtARNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtARNo.Text & "'") Then
                    ErrorProvider1.SetError(txtARNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtARNo.Text & "'") Then
                    ErrorProvider1.SetError(txtARNo, "This ID No. is already exists!")
                ElseIf CountGridRows(dgDetails) = 0 Then
                    MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                    Exit Sub
                Else
                    For Each row As DataGridViewRow In dgDetails.Rows
                        If row.IsNewRow = False Then
                            If row.Cells("colstatus").Value = "" Then
                                MsgBox("Empty Status!", MsgBoxStyle.Exclamation)
                                Exit Sub
                            End If

                        End If
                    Next
                End If
                With AR
                    .ARNo = txtARNo.Text
                    .ARDate = Ardate.Text
                    .Accountable = cboAccountable.Text
                    .UserID = cboemployee.Text
                    .DepartmentCode = cboDepartment.Text
                    .SectionCode = cboSection.Text
                    .LineCode = cboLine.Text
                    .Total = txtTotalAmount.Text
                    .cctype = cctype
                    _OpenTransaction()
                    strResult = .Save(bolFormState = FormState.EditState, dgDetails, dgSearchMembers)

                    _CloseTransaction(strResult)
                    If strResult Then
                        If bolFormState = FormState.EditState Then
                            MsgBox("Updated Complete!", MsgBoxStyle.Information, "Update")
                        Else
                            MsgBox("Saved Complete!", MsgBoxStyle.Information, "Save")
                        End If
                        Me.Close()
                        frmMember.Close()
                        myParent.RefreshRecord("sp_100_Get_AR_List '" & MainForm.tsSearch.Text & "'")
                    End If
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Save Record")
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

            Dim arrParameterAndValue As ArrayList = New ArrayList
            arrParameterAndValue = FetchData(arrParameterAndValue, "sp_100_AR_Get_AR_Fillcode'" & .Item(0, rowindex).Value & "','" & .Item(1, rowindex).Value & "'", CommandType.Text)

            If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                '-->indicate if the row is null
            Else

                .Item("colItemCode", rowindex).Value = arrParameterAndValue(0).ToString
                .Item("colTOCCode", rowindex).Value = arrParameterAndValue(1).ToString
                .Item("colDescription", rowindex).Value = arrParameterAndValue(2).ToString
                .Item("colBrandType", rowindex).Value = arrParameterAndValue(3).ToString
                .Item("colQty", rowindex).Value = arrParameterAndValue(4).ToString
                .Item("colUnit", rowindex).Value = arrParameterAndValue(5).ToString
                cctype = arrParameterAndValue(6).ToString

                .Item("Column1", rowindex).Value = cctype
                .Item("Column2", rowindex).Value = cctype
                .Item("Column3", rowindex).Value = "PHP"
                .Item("Column4", rowindex).Value = "PHP"

                .Item("colUnitPrice", rowindex).Value = arrParameterAndValue(7).ToString
                .Item("colCUnitPrice", rowindex).Value = arrParameterAndValue(8).ToString
                .Item("colDate", rowindex).Value = arrParameterAndValue(9).ToString
                .Item("ColIDNo", rowindex).Value = arrParameterAndValue(10).ToString
                .Item("colName", rowindex).Value = arrParameterAndValue(11).ToString

                For i = 0 To dgDetails.RowCount - 1
                    AddFields(i)
                Next
                ComputeAllRows()
            End If
        End With
    End Sub

    ''=====================
    ''Compute all rows
    ''=====================
    Sub ComputeAllRows()
        Dim sum, totalamount As Double

        With dgDetails
            For i = 0 To .RowCount - 1
                totalamount = .Item("colCAmount", i).Value
                sum = FormatNumber(sum + NZ(totalamount), 2)
            Next
            txtTotalAmount.Text = FormatNumber(NZ(sum))
        End With
    End Sub
    ''==========================
    ''Compute all total amount
    ''==========================
    Sub AddFields(ByVal rowIndex As Integer)
        Dim cprice, aprice, Camount, Aamount As Double
        With dgDetails


            cprice = Replace(.Item("colCUnitPrice", rowIndex).Value, "PHP", "")
            If cprice = Nothing Then Exit Sub
            aprice = Replace(.Item("colUnitPrice", rowIndex).Value, cctype, "")
            Camount = Replace(.Item("colCAmount", rowIndex).Value, "PHP", "")
            Aamount = Replace(.Item("colAmount", rowIndex).Value, cctype, "")


            .Item("colCAmount", rowIndex).Value = FormatNumber((CDbl(NZ(.Item("colQty", rowIndex).Value)) * CDbl(NZ(cprice))), 2)
            .Item("colAmount", rowIndex).Value = FormatNumber((NZ(.Item("colQty", rowIndex).Value)) * CDbl(NZ(aprice)), 2)

            If .Item("colstatus", rowIndex).Value = Nothing Or .Item("colstatus", rowIndex).Value = String.Empty Then
                Exit Sub
            End If
            If .Item("colstatus", rowIndex).Value = "Brand New" Then
                .Item("colRef", rowIndex).Value = "N/A"
                .Item("colRef", rowIndex).ReadOnly = True
            Else

                .Item("colRef", rowIndex).ReadOnly = False
            End If
        End With
    End Sub

    ''========================
    ''Set,edit and update 
    ''========================
    Sub SetEditValue()
      
        Dim AR As New tbl_100_AR
        ARNo = myParent.dgList.Item("colARNo", myParent.dgList.CurrentRow.Index).Value

        
        With AR
            .FetchWR(ARNo)
            txtARNo.Text = .ARNo
            Ardate.Text = .ARDate
            cboAccountable.Text = .Accountable
            cboemployee.Text = .UserID
            cboDepartment.Text = .DepartmentCode
            cboSection.Text = .SectionCode
            cboLine.Text = .LineCode

        End With
        FillDataGrid(dgDetails, "sp_100_AR_GetAR_Sub'" & ARNo & "'", 0, 21)
        Call loadcomponent()


        SQL = "SELECT     tbl_100_AR_Member.UserID,dbo.F_Get_EmployeeName(tbl_100_AR_Member.UserID) as Employeename, tbl_000_Employee.EmpStatus " & _
            "FROM         tbl_100_AR_Member INNER JOIN " & _
            "tbl_000_Employee ON tbl_100_AR_Member.UserID = tbl_000_Employee.EmpID " & _
            "WHERE     (tbl_100_AR_Member.ARNo = '" & ARNo & "') "


        FillDataGrid(dgSearchMembers, SQL, 0, 2)
        cctype = DBLookUp("Select CurrencyType from tbl_100_AR_Sub where ARNO='" & ARNo & "'", "CurrencyType")
        For i = 0 To dgDetails.RowCount - 1
            Call AddFields(i)
        Next
        txtARNo.Enabled = False
        ComputeAllRows()
    End Sub

    Sub FillSection()
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


    Sub FillLine()
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

    Sub FillLineTextBox()
        If Not cboLine.SelectedValue Is Nothing Then
            txtLine.Text = cboLine.SelectedItem.Col2

        Else
            txtLine.Text = String.Empty
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="param"></param>
    ''' <remarks></remarks>
    Sub ValidateRequirment(ByVal param As Integer)
        With ErrProvider
            ErrProvider.ClearAllErrorMessages()
            Select Case param
                Case 0
                    .Controls.Clear()
                    .Controls.Add(txtARNo, "WR Number")
                    .Controls.Add(txtemployee, "Employee")

                Case 1
                    .Controls.Clear()
                    .Controls.Add(txtARNo, "WR Number")
                    .Controls.Add(txtDepartment, "Department")

                Case 2
                    .Controls.Clear()
                    .Controls.Add(txtARNo, "WR Number")
                    .Controls.Add(txtDepartment, "Department")
                    .Controls.Add(txtSection, "Section")

                Case 3
                    .Controls.Clear()
                    .Controls.Add(txtARNo, "WR Number")
                    .Controls.Add(txtDepartment, "Department")
                    .Controls.Add(txtSection, "Section")
                    .Controls.Add(txtLine, "Line")

            End Select
        End With

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="item"></param>
    ''' <remarks></remarks>
    Sub ChoseAccountable(ByVal item As Integer)
        Try
            Select Case item

                Case 0
                    Call ClearAllHeader()
                    Call ValidateRequirment(item)
                    cboemployee.Enabled = True
                    cboDepartment.Enabled = False
                    cboSection.Enabled = False
                    cboLine.Enabled = False

                    cboemployee.Text = String.Empty
                    cboDepartment.Text = String.Empty
                    cboSection.Text = String.Empty
                    cboLine.Text = String.Empty

                    txtDepartment.Text = String.Empty
                    txtSection.Text = String.Empty
                    txtLine.Text = String.Empty

                    With ErrProvider
                        .Controls.Clear()
                        .Controls.Add(txtARNo, "WR Number")
                        .Controls.Add(txtemployee, "Employee")
                    End With
                Case 1
                    Call ClearAllHeader()
                    Call ValidateRequirment(item)
                    cboemployee.Enabled = False
                    cboDepartment.Enabled = True
                    cboSection.Enabled = False
                    cboLine.Enabled = False
                    cboemployee.Text = String.Empty
                    cboDepartment.Text = String.Empty
                    cboSection.Text = String.Empty
                    cboLine.Text = String.Empty
                Case 2
                    Call ClearAllHeader()
                    Call ValidateRequirment(item)
                    cboemployee.Enabled = False
                    cboDepartment.Enabled = True
                    cboSection.Enabled = True
                    cboLine.Enabled = False
                Case 3
                    Call ClearAllHeader()
                    Call ValidateRequirment(item)
                    cboemployee.Enabled = False
                    cboDepartment.Enabled = True
                    cboSection.Enabled = True
                    cboLine.Enabled = True

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub



    Private Sub loadcomponent()
        deptcode = Me.cboDepartment.Text
        sectioncode = Me.cboSection.Text
        linecode = Me.cboLine.Text
        dgSearchMembers.Rows.Clear()
        Dim param2 As String
        SQL = "SELECT EmpID,FirstName + ' ' + CASE WHEN MiddleName IS NULL THEN '' WHEN MiddleName = ' ' THEN '' ELSE SubString(MiddleName, 1, 1) + '. ' END + LastName + ' ' AS EmpName FROM tbl_000_Employee WHERE (IsActive = 1)"

        If sectioncode = String.Empty And linecode = String.Empty Then
            param2 = SQL + "and DepartmentCode='" & deptcode & "'"
            'FillDataGridViewComboBoxColumn(colID, param2, "tbl_000_Employee", "EmpID", "EmpID")
            FillMultiColumn(dgSearchMembers, colID, "200;150", 1, param2, "EmpID", "EmpID", CommandType.Text)
        ElseIf sectioncode <> String.Empty And linecode = String.Empty Then
            param2 = SQL + " and DepartmentCode='" & deptcode & "' and SectionCode='" & sectioncode & "'"
            'FillDataGridViewComboBoxColumn(colID, param2, "tbl_000_Employee", "EmpID", "EmpID")
            FillMultiColumn(dgSearchMembers, colID, "200;150", 1, param2, "EmpID", "EmpID", CommandType.Text)
        ElseIf sectioncode <> String.Empty And linecode <> String.Empty Then
            param2 = SQL + " and DepartmentCode='" & deptcode & "' and SectionCode='" & sectioncode & "' and linecode='" & linecode & "'"

            'FillDataGridViewComboBoxColumn(colID, param2, "tbl_000_Employee", "EmpID", "EmpID")
            FillMultiColumn(dgSearchMembers, colID, "200;150", 1, param2, "EmpID", "EmpID", CommandType.Text)
        End If


    End Sub

#End Region

#Region "GUI"
    Private Sub frm_100_AR_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        If bolFormState = FormState.EditState Then
            SetEditValue()
        ElseIf bolFormState = FormState.AddState Then
            cboAccountable.SelectedIndex = -1
        End If
        ActivateCommands(bolFormState)
    End Sub




  

    Private Sub dgDetails_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        On Error Resume Next
    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)

        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)

        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub frm_100_AR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        End If
    End Sub

    Private Sub frm_100_AR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ResizeForm(Me)
        CenterControl(lblTitle, Me)
        LoadDepartmentToMultiCombo(cboDepartment)
        LoadEmployeeToAccountability(cboemployee)
        ' FillDataGridViewComboBoxColumn(colWRNo, "Get_WRNO", "tbl_100_WR", "WRNo", "WRNo")
    End Sub

    Sub CheckQuantity()
        For i = 0 To dgDetails.RowCount - 1
            With dgDetails
                If .Item("colTQ", i).Value <= 0 Then
                    MsgBox("The Quantity you enter is bigger than actual quantity")
                End If
            End With
        Next
    End Sub



#End Region


    Private Sub btnselect_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    
   
    Private Sub cboAccountable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountable.SelectedIndexChanged
        Call ChoseAccountable(cboAccountable.SelectedIndex)
    End Sub

   
    Private Sub cboemployee_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboemployee.SelectedIndexChanged
        If Not cboemployee.SelectedValue Is Nothing Then
            txtemployee.Text = cboemployee.SelectedItem.Col2
            'Call Get_Department_from_Employee(cboemployee.Text)
        Else
            txtemployee.Text = String.Empty
        End If
    End Sub

    Private Sub cboDepartment_Enter1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartment.Enter
        oldDepartment = cboDepartment.Text
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartment.SelectedIndexChanged
        Call FillSection()
        Call loadcomponent()
    End Sub

    Private Sub cboDepartment_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartment.Validated
        Call FillSection()
    End Sub

    Private Sub cboSection_Enter1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSection.Enter
        oldSection = cboSection.Text
    End Sub

    Private Sub cboSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSection.SelectedIndexChanged
        Call FillLine()
        Call loadcomponent()
    End Sub

    Private Sub cboSection_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSection.Validated
        Call FillLine()
    End Sub

   
    Private Sub cboLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLine.SelectedIndexChanged
        Call FillLineTextBox()
        Call loadcomponent()
    End Sub

    Private Sub cboLine_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLine.Validated
        Call FillLineTextBox()
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Select Case e.ColumnIndex
            Case 2
                With frm_Searchitem
                    .frm = "AR"
                    .x = dgDetails.Item("colWRno", e.RowIndex).Value
                    .ShowDialog()
                End With
        End Select
    End Sub

    Private Sub dgDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellValidated
        AddFields(e.RowIndex)
        ComputeAllRows()
    End Sub

    Private Sub dgDetails_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgDetails.CellValidating
        Try
            Select Case e.ColumnIndex
                Case colSpecificCode.Index
                    'If CheckCodeFromDatagridView(dgDetails, 0, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                    '    dgDetails.CancelEdit()
                    '    MsgBox("Specific Code already exists in the list.", MsgBoxStyle.Exclamation, "Duplicate Code")
                    'Else
                    '    If bolFormState <> FormState.EditState Then
                    '        fillCode(e.RowIndex)
                    '    End If
                    'End If
                Case colQty.Index
                    If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                        MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                        e.Cancel = True

                    End If
                    'Case colUnitPrice.Index
                    '    If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                    '        MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                    '        e.Cancel = True

                    '    End If
                    'Case colAmount.Index
                    '    If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                    '        MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                    '        e.Cancel = True

                    '    End If
                    'Case colCUnitPrice.Index
                    '    If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                    '        MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                    '        e.Cancel = True

                    '    End If
                    'Case colCAmount.Index
                    '    If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                    '        MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                    '        e.Cancel = True

                    '    End If


            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub dgSearchMembers_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearchMembers.CellContentClick

    End Sub

    Private Sub dgSearchMembers_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearchMembers.CellValidated
        paramList.Clear()
        SQL = "SELECT FirstName + ' ' + CASE WHEN MiddleName IS NULL THEN '' WHEN MiddleName = ' ' THEN '' ELSE SubString(MiddleName, 1, 1) + '. ' END + LastName + ' ' AS EmpName,EmpStatus, IsActive FROM tbl_000_Employee WHERE (IsActive = 1)"
        SQL = SQL + "and empid='" & dgSearchMembers.Item("colID", e.RowIndex).Value & "'"
        paramList = FetchData(paramList, SQL, CommandType.Text)
        If paramList Is Nothing Or paramList.Count = 0 Then
            ''nothing to do
        Else
            dgSearchMembers.Item("colMemberName", e.RowIndex).Value = paramList(0).ToString
            dgSearchMembers.Item("colMemberStatus", e.RowIndex).Value = paramList(1).ToString
        End If
    End Sub

    Private Sub dgSearchMembers_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgSearchMembers.RowsAdded
        lblno.Text = CountGridRows(dgSearchMembers)
    End Sub

    Private Sub dgSearchMembers_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgSearchMembers.RowsRemoved
        lblno.Text = CountGridRows(dgSearchMembers)
    End Sub
End Class