Imports TOPCInventorySales.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frm_100_WR
#Region "Variable"
    Implements IBPSCommand
    Public bolFormState As clsPublic.FormState
    Public myParent As frm_100_WRList
    Public itemCode As String
    Public speficificCode As String
    Public WRNo As String
    Dim JRNo As String
    Dim oldDepartment As String
    Dim oldSection As String
    Dim item As New tbl_000_Item
    Dim ErrProvider As New ErrorProviderExtended
    Dim totalQ As Double, total As Double
    Public SetResult As Boolean
    Dim WR As New tbl_100_WR
    Dim WRCheck As New clsWithdrawalOperation
#End Region

#Region "Procedure"



    Private Function CheckEmployee() As Boolean
        For Each row As DataGridViewRow In dgDetails.Rows
            If row.IsNewRow = False Then
                CheckEmployee = DBLookUp("select dbo.CheckEmployeeExist('" & row.Cells("colIDno").Value & "') as id", "id")
            End If
        Next

    End Function

    Private Sub DeleteRows(ByVal RRNO As String, ByVal SpecificCode As String, ByVal QTY As Double, ByVal ReceivingID As String)
        If isRecordExist("Select Wrno,RRNO,SpecificCode  from tbl_100_WR_Sub where WRNO='" & txtWRNo.Text & "' and RRNO='" & RRNO & "' and SpecificCode='" & SpecificCode & "'") = False Then
            Exit Sub
        Else
            Dim tmpRRQTY As Double = DBLookUp("Select Quantity from tbl_100_RR_Temp where RRNO='" & RRNO & "' and SpecificCode='" & SpecificCode & "'", "Quantity")
            Dim tmpItemStock As Double = DBLookUp("Select StackOH from tbl_000_item_Sub where SpecificCode='" & SpecificCode & "'", "StackOH")

            RunQuery("Update tbl_000_item_Sub set StackOH='" & (tmpItemStock + QTY) & "' where SpecificCode='" & SpecificCode & "'")
            RunQuery("Update tbl_100_RR_Temp set Quantity='" & (tmpRRQTY + QTY) & "'  where RRNO='" & RRNO & "' and SpecificCode='" & SpecificCode & "'")
            RunQuery("Delete from tbl_100_WR_Sub where SpecificCode='" & SpecificCode & "' and WRNO='" & txtWRNo.Text & "' and IDNo1='" & ReceivingID & "' and RRNO='" & RRNO & "'")
            Call SaveAuditTrail("Delete item Withdrawal" & SpecificCode, txtWRNo.Text)
        End If
    End Sub

    Private Sub viewReport()

        cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_WR_Report.rpt")
        'cryRpt.SetDataSource(FillReportForm("sp_rpt_WR'" & txtWRNo.Text & "'", "tbl_100_WR_Sub"))
        arrParametersAndValue.Clear()
        arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@WrNo", txtWRNo.Text))
        cryRpt.SetDataSource(FillReport("sp_rpt_WR", CommandType.StoredProcedure, arrParametersAndValue))
        With frm_200_ReportV
            .rpt_viewer.ReportSource = cryRpt
            .Text = "Withdrawal Requisition"
            .Show()
            .Focus()
        End With
    End Sub

    ''' <summary>
    ''' Direct Update you can
    ''' insert and upate Data
    ''' used DBLOOKUP to select Data
    ''' </summary>
    ''' <param name="QueryString">Query String</param>
    ''' <param name="srcCommandType">Command Type</param>
    ''' <remarks></remarks>
    Sub DirectUpdate(ByVal QueryString As String, ByVal srcCommandType As CommandType)
        _OpenTransaction()
        Using com As New SqlCommand(QueryString, _Connection, _Transaction)
            com.CommandType = srcCommandType
            com.ExecuteNonQuery()
        End Using
        _CloseTransaction(True)
    End Sub

    ''' <summary>
    ''' If edit mode then this item is not exist in current table
    ''' </summary>
    ''' <param name="rowindex"></param>
    ''' <remarks></remarks>
    Sub AddNewToEdit(ByVal rowindex As Integer)
        Dim arrParameterAndValue As ArrayList = New ArrayList
        Dim totalStackOH As Double
        Dim stockOH As String
        Dim RRQTY As String
        With dgDetails
            If .Item("colQty", rowindex).Value = Nothing Then
                Exit Sub
            End If
            stockOH = NZ(DBLookUp("Select StackOH from tbl_000_item_Sub where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "StackOH"))
            '--> Add mode

            totalQ = 0
            RRQTY = NZ(DBLookUp("Select Quantity from tbl_100_RR_temp where RRNO='" & .Item("colRRNo", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "Quantity"))
     


            totalQ = CDbl(.Item("colQty", rowindex).Value)
            total = CDbl(RRQTY) - CDbl(totalQ)

            Call DirectUpdate("Update  tbl_100_RR_Temp set Quantity='" & total _
                                         & "'where SpecificCode='" & .Item("colSpecificCode", rowindex).Value _
                                         & "' and RRNO='" & .Item("colRRNo", rowindex).Value & "'", CommandType.Text)
            Call DirectUpdate("Update tbl_100_RR set isStatus='" & isnoUpdate & "' where RRNo='" & .Item("colRRNo", rowindex).Value & "'", CommandType.Text)
            totalStackOH = CDbl(stockOH) - CDbl(.Item("colQty", rowindex).Value)
            Call DirectUpdate("Update tbl_000_Item_Sub set StackOH='" & totalStackOH & "'where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", CommandType.Text)
        End With
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetUpateTransaction()


        Dim totalStackOH As Double
        Dim stockOH As String
        Dim WRQTY As String
        Dim RRQTY As String
        totalQ = 0

        With dgDetails
            For rowindex = 0 To .RowCount - 1

                If .Item("colQty", rowindex).Value = Nothing Then Exit Sub

                stockOH = NZ(DBLookUp("Select StackOH from tbl_000_item_Sub where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "StackOH"))
                '--> Add mode
                If bolFormState = FormState.AddState Then

                    RRQTY = NZ(DBLookUp("Select Quantity from tbl_100_RR_Temp where RRNO='" & .Item("colRRNo", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "Quantity"))

                    totalQ = CDbl(.Item("colQty", rowindex).Value)

                    total = FormatNumber(CDbl(RRQTY) - CDbl(totalQ), 2)




                    Call DirectUpdate("Update  tbl_100_RR_Temp set Quantity='" & total _
                                                 & "'where SpecificCode='" & .Item("colSpecificCode", rowindex).Value _
                                                 & "' and RRNO='" & .Item("colRRNo", rowindex).Value & "'", CommandType.Text)
                    Call DirectUpdate("Update tbl_100_RR set isStatus='" & isnoUpdate & "' where RRNo='" & .Item("colRRNo", rowindex).Value & "'", CommandType.Text)

                    totalStackOH = FormatNumber(CDbl(stockOH) - CDbl(.Item("colQty", rowindex).Value), 2)

                    Call DirectUpdate("Update tbl_000_Item_Sub set StackOH='" & totalStackOH & "'where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", CommandType.Text)



                    '--> Edit mode
                ElseIf bolFormState = FormState.EditState Then
                    Dim CheckInWRSub As String

                    CheckInWRSub = DBLookUp("select SpecificCode from tbl_100_WR_sub where Wrno='" & txtWRNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "SpecificCode")

                    If CheckInWRSub = String.Empty Then
                        Call AddNewToEdit(rowindex)
                    Else

                        RRQTY = NZ(DBLookUp("Select Quantity  from tbl_100_RR_Temp where RRNO='" & .Item("colRRNo", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "Quantity"))

                        WRQTY = NZ(DBLookUp("Select Quantity from tbl_100_WR_Sub where WRNO='" & txtWRNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "' and RRNo='" & .Item("colRRNo", rowindex).Value & "' and IDNo1='" & .Item("colIDno", rowindex).Value & "'", "Quantity"))

                        RRQTY = Val(WRQTY) + Val(RRQTY)

                        RunQuery("Update tbl_100_RR_temp set Quantity='" & RRQTY & "' where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "' and RRNO='" & .Item("colRRNo", rowindex).Value & "'")

                        RRQTY = NZ(DBLookUp("Select Quantity  from tbl_100_RR_Temp where RRNO='" & .Item("colRRNo", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "Quantity"))

                        totalQ = CDbl(.Item("colQty", rowindex).Value)

                        total = FormatNumber(CDbl(RRQTY) - CDbl(totalQ), 2)

                        Call DirectUpdate("Update  tbl_100_RR_Temp set Quantity='" & total _
                                                    & "'where SpecificCode='" & .Item("colSpecificCode", rowindex).Value _
                                                    & "' and RRNO='" & .Item("colRRNo", rowindex).Value & "'", CommandType.Text)
                        'totalStackOH = CDbl(totalQ) - (CDbl(stockOH) + CDbl(WRQTY))
                        totalStackOH = FormatNumber((CDbl(stockOH) + CDbl(WRQTY)) - CDbl(.Item("colQty", rowindex).Value), 2)

                        Call DirectUpdate("Update tbl_100_RR set isStatus='" & isnoUpdate & "' where RRNo='" & .Item("colRRNo", rowindex).Value & "'", CommandType.Text)

                        If totalStackOH < 0 Then Exit Sub

                        Call DirectUpdate("Update tbl_000_Item_Sub set StackOH='" & totalStackOH & "'where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", CommandType.Text)

                    End If
                End If
            Next
        End With

    End Sub

    ''' <summary>
    ''' Process form command
    ''' </summary>
    ''' <param name="strCmd"></param>
    ''' <remarks></remarks>
    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                ''NewRecord()
            Case "Edit"
                ''EditRecord()
            Case "Void"
                Voidrecords()
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
                viewReport()
            Case "Print"
                viewReport()
                ' frm_200_ReportV.rpt_viewer.PrintReport()
        End Select
    End Sub

    Private Function HasRecord(ByVal ARNO As String) As Boolean
        Dim isHaveRecord As Boolean = False
        '-->check if this PO no is used in RR transaction
        If isRecordExist("SELECT     WRNo " & _
                         "FROM tbl_100_AR_Sub " & _
                         "WHERE     (Status <> N'CANCELLED') AND (WRNo = '" & ARNO & "')") Then
            isHaveRecord = True
        End If


        Return isHaveRecord

    End Function
    ''' <summary>
    ''' Void control number
    ''' </summary>
    ''' <remarks></remarks>
    Sub Voidrecords()
        If HasRecord(txtWRNo.Text) = True Then
            MsgBox("Invalid to Void is being used in other transaction", MsgBoxStyle.Exclamation, "Prompt")
            Exit Sub
        End If
       
        With opendialog
            .Tname = "WR"
            .TID = WRNo
            .ShowDialog()
        End With

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="en"></param>
    ''' <remarks></remarks>
    Sub enabled_tools(ByVal en As Boolean)
        txtWRNo.ReadOnly = en
        dtDateWedrawal.Enabled = Not en
        cboDepartment.Enabled = Not en
        cboSection.Enabled = Not en
        cboLine.Enabled = Not en
        txtDepartment.ReadOnly = en
        txtSection.ReadOnly = en
        txtLine.ReadOnly = en
        dgDetails.Enabled = Not en
    End Sub

    ''' <summary>
    ''' Clear all fields 
    ''' </summary>
    ''' <remarks></remarks>
    Sub ClearFields()
        txtWRNo.Text = String.Empty
        cboDepartment.Text = String.Empty
        cboSection.Text = String.Empty
        cboLine.Text = String.Empty

    End Sub

    ''' <summary>
    ''' 'Close the Form
    ''' </summary>
    ''' <remarks></remarks>
    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        'LockFields(True)
        ActivateCommands(FormState.LoadState)
        Me.Close()

    End Sub

    ''' <summary>
    ''' Sent Alert
    ''' </summary>
    ''' <remarks></remarks>
    Sub sentmsg()
        SQL = DBLookUp("sp_GetSentAlert'" & "WR" & "','" & txtWRNo.Text & "','" & ComputerName & "'", "RemarksWarning")

        If SQL = "Send Alert" Then
            With frm_SendAlert
                FillDataGrid(.dgdetails, "sp_GetSentAlert'" & "WR" & "','" & txtWRNo.Text & "','" & ComputerName & "'", 0, 3)
                .frm = "WR"
                .ShowDialog()
            End With
        Else
            SetResult = True
        End If
    End Sub

    ''--> Save Withdrawal Record
    Private Sub SaveRecord()


        SQL = DBLookUp("Select WRNo from tbl_100_WR where isStatus='" & isPlaced & "'", "WRNo")
        If WRNo = "" Then
        Else
            If WRNo = SQL Then
                MsgBox("Invalid to update is being used in other transaction", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If


        Dim strResult As Boolean
        Try


            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtWRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtWRNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtWRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtWRNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtWRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtWRNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtWRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtWRNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtWRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtWRNo, "This ID No. is already exists!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtWRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtWRNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtWRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtWRNo, "This ID No. is being used by another transaction!")
                ElseIf txtTotalAmount.Text = "" Then
                    MsgBox("Total Amount is required", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf CountGridRows(dgDetails) = 0 Then
                    MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                    Exit Sub
                Else
                    For i = 0 To dgDetails.RowCount - 1
                        With dgDetails
                            If .Item("colStatus", i).Value = "YES" Then
                                If .Item("colIDno", i).Value = "" Or .Item("colIDno2", i).Value = "" Then
                                    MsgBox("Enter the User id first", MsgBoxStyle.Exclamation, "Prompt")
                                    Exit Sub
                                ElseIf .Item("colRefNo", i).Value = "" Then
                                    MsgBox("Enter Accountability No.", MsgBoxStyle.Exclamation, "Prompt")
                                    Exit Sub
                                End If
                            End If

                            SQL = DBLookUp("SELECT  SubCategoryCode FROM tbl_000_Item where itemcode='" & .Item("colItemCode", i).Value & "'", "SubCategoryCode")
                            If SQL = "G" Then
                                If .Item("colLotNo", i).Value = "N/A" Or .Item("colLotNo", i).Value = "" Then
                                    MsgBox("Lot No. is requred" + vbNewLine + "Specific Code > " + .Item("colSpecificCode", i).Value, MsgBoxStyle.Exclamation, "Item Sub Category = Optical Glass Lens")
                                    Exit Sub
                                Else

                                End If


                            End If
                        End With
                    Next

                    If CheckEmployee() = False Then
                        MsgBox("The Received Employee ID is not exist in the system", MsgBoxStyle.Exclamation, "Prompt")
                        Exit Sub
                    End If

                    For Each row As DataGridViewRow In dgDetails.Rows
                        If row.IsNewRow = False Then

                            ''==================================
                            ''check the quantity equal to 0
                            ''==================================
                            If row.Cells("colQty").Value = 0 Then
                                MsgBox("Quantity is required!", MsgBoxStyle.Exclamation, "Prompt")
                                Exit Sub
                            End If
                            If row.Cells("colTQ").Value < 0 Then
                                MsgBox("Quantity you type is biger than actual Quantity", MsgBoxStyle.Exclamation, "Prompt")
                                Exit Sub
                            End If
                            If row.Cells("colIDno").Value = String.Empty Then
                                MsgBox("Select Received I.D No. ", MsgBoxStyle.Exclamation, "Prompt")
                                Exit Sub
                            End If
                            If row.Cells("colIDNo2").Value = String.Empty Then
                                MsgBox("Select Issued I.D No.", MsgBoxStyle.Exclamation, "Prompt")
                                Exit Sub
                            End If
                        End If
                    Next


                    Call CheckTheSentAlert()
                    Call sentmsg()
                    If SetResult = False Then Exit Sub



                    ''--------------------------------------------------------

                    If WRCheck.savetempwr(txtWRNo.Text, dgDetails, bolFormState) <> True Then
                        Exit Sub
                    End If

                    ''--------------------------------------------------------

                    With WR
                        .WRNo = txtWRNo.Text
                        .WedrawalDAte = dtDateWedrawal.Text
                        .DepartmentCode = cboDepartment.Text
                        .SectionCode = cboSection.Text
                        .LineCode = cboLine.Text
                        .Total = txtTotalAmount.Text

                        If bolFormState = FormState.EditState Then
                            If MsgBox("Do you want to Update?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Prompt") = MsgBoxResult.Yes Then
                                Call SetUpateTransaction()
                                _OpenTransaction()
                                strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                                _CloseTransaction(strResult)

                                MsgBox("Updated Complete", MsgBoxStyle.Information, "Prompt")

                                Me.Close()
                                myParent.RefreshRecord("sp_100_Get_WR_List '" & MainForm.tsSearch.Text & "'")

                            Else

                            End If

                        Else

                            If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Prompt") = MsgBoxResult.Yes Then
                                Call SetUpateTransaction()
                                _OpenTransaction()
                                strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                                _CloseTransaction(strResult)


                                Me.Close()
                                myParent.RefreshRecord("sp_100_Get_WR_List '" & MainForm.tsSearch.Text & "'")

                            Else


                            End If

                        End If
                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Save Record")
        End Try
    End Sub

    ''---> Save Void Withdrawal Details
    Public Sub SaveVoidDetails()
        Dim strResult As Boolean
        With WR
            .WRNo = txtWRNo.Text
            .WedrawalDAte = dtDateWedrawal.Text
            .DepartmentCode = cboDepartment.Text
            .SectionCode = cboSection.Text
            .LineCode = cboLine.Text
            .Total = txtTotalAmount.Text

            If bolFormState = FormState.EditState Then
                If MsgBox("Do you want to Update?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Prompt") = MsgBoxResult.Yes Then
                    _OpenTransaction()
                    strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                    _CloseTransaction(strResult)
                    MsgBox("Updated Complete", MsgBoxStyle.Information, "Prompt")
                    Me.Close()
                    myParent.RefreshRecord("sp_100_Get_WR_List '" & MainForm.tsSearch.Text & "'")
                End If

            Else
                If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Prompt") = MsgBoxResult.Yes Then
                    _OpenTransaction()
                    strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                    _CloseTransaction(strResult)
                    Me.Close()
                    myParent.RefreshRecord("sp_100_Get_WR_List '" & MainForm.tsSearch.Text & "'")
                End If
            End If
        End With
    End Sub
    ''' <summary>
    ''' Fill Section
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillSection()
        'Call FillDataGridViewComboBoxColumn(colIDno, "Get_Employee '" & "WO" & "','" & cboDepartment.Text & "','" & cboSection.Text & "','" & cboLine.Text & "'", "tbl_000_Employee", "EmpID", "EmpID")

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

    ''' <summary>
    ''' Fill line
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillLine()
        ' Call FillDataGridViewComboBoxColumn(colIDno, "Get_Employee '" & "WO" & "','" & cboDepartment.Text & "','" & cboSection.Text & "','" & cboLine.Text & "'", "tbl_000_Employee", "EmpID", "EmpID")

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
    ''' <summary>
    ''' Fill line textbox
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillLineTextBox()
        If Not cboLine.SelectedValue Is Nothing Then
            txtLine.Text = cboLine.SelectedItem.Col2
        Else
            txtLine.Text = String.Empty
        End If
    End Sub
    ''' <summary>
    ''' Active Commands in form
    ''' </summary>
    ''' <param name="frmState"></param>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Compute all total amount in datagridview row
    ''' </summary>
    ''' <remarks></remarks>
    Sub ComputeAllRows()
        Dim sum As Double
        With dgDetails
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colAmount", i).Value)
            Next
            txtTotalAmount.Text = FormatNumber(NZ(sum))
        End With
    End Sub
    ''' <summary>
    ''' Add fields
    ''' </summary>
    ''' <param name="rowIndex"></param>
    ''' <remarks></remarks>
    Sub AddFields(ByVal rowIndex As Integer)
        With dgDetails
            Try
                If .Item("colStatus", rowIndex).Value = "NO" Then
                    '.Item("colIDno", rowIndex).Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                    '.Item("colIDNo2", rowIndex).Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                    .Item("colRefNo", rowIndex).Style.BackColor = Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
                    '.Item("colIDno", rowIndex).ReadOnly = True
                    '.Item("colIDno2", rowIndex).ReadOnly = True
                    .Item("colRefNo", rowIndex).ReadOnly = True
                    '.Item("colIDno", rowIndex).Value = ""
                    '.Item("colIDno2", rowIndex).Value = ""
                    .Item("colRefNo", rowIndex).Value = "N/A"
                ElseIf .Item("colStatus", rowIndex).Value = "YES" Then
                    '.Item("colIDno", rowIndex).Style.BackColor = Color.White
                    '.Item("colIDNo2", rowIndex).Style.BackColor = Color.White
                    .Item("colRefNo", rowIndex).Style.BackColor = Color.White
                    .Item("colRefNo", rowIndex).ReadOnly = False
                    '.Item("colIDno", rowIndex).ReadOnly = False
                    '.Item("colIDno2", rowIndex).ReadOnly = False

                    If .Item("colRefNo", rowIndex).Value = "N/A" Then
                        .Item("colRefNo", rowIndex).Value = ""


                    End If

                End If
                If .Item("colIDno", rowIndex).Value = Nothing Then

                Else
                    .Item("colName", rowIndex).Value = DBLookUp("Get_Employee'" & "SelectEmployee" & "','" & .Item("colIDno", rowIndex).Value.ToString & "'", "EmpName")
                End If

                If .Item("colIDNo2", rowIndex).Value = Nothing Then

                Else
                    .Item("colName2", rowIndex).Value = DBLookUp("Get_Employee'" & "SelectEmployee" & "','" & .Item("colIDNo2", rowIndex).Value & "'", "EmpName")
                End If

                .Item("colTQ", rowIndex).Value = Val(.Item("ColQ", rowIndex).Value) - Val(.Item("colQty", rowIndex).Value)
                .Item("colAmount", rowIndex).Value = CDbl(NZ(.Item("colQty", rowIndex).Value)) * CDbl(NZ(.Item("colUnitPrice", rowIndex).Value))




            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

        End With
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
    ''' <summary>
    ''' Check the Quantity
    ''' </summary>
    ''' <remarks></remarks>
    Sub CheckQuantity()
        For i = 0 To dgDetails.RowCount - 1
            With dgDetails
                If .Item("colTQ", i).Value <= 0 Then
                    MsgBox("The Quantity you enter is bigger than actual quantity")
                End If
            End With
        Next
    End Sub

    ''' <summary>
    ''' Edit the Value in withdrawal
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetEditValue()
        Dim WR As New tbl_100_WR
        WRNo = myParent.dgList.Item("colWRNo", myParent.dgList.CurrentRow.Index).Value
        With WR
            .FetchWR(WRNo)
            txtWRNo.Text = .WRNo
            dtDateWedrawal.Text = .WedrawalDAte
            cboDepartment.SelectedValue = .DepartmentCode
            cboSection.SelectedValue = .SectionCode
            cboLine.SelectedValue = .LineCode

        End With

        FillDataGrid(dgDetails, "Get_WR_Sub'" & WRNo & "'", 0, 19)

        For i = 0 To dgDetails.RowCount - 1
            'dgDetails.Item("colOH", i).Value = DBLookUp("select StackOH from tbl_000_Item_Sub where SpecificCode='" & dgDetails.Item("colSpecificCode", i).Value & "'", "StackOH")
            AddFields(i)
            ComputeAllRows()
        Next
        txtWRNo.Enabled = False
    End Sub



    ''' <summary>
    ''' Fill Datagrid Cell
    ''' </summary>
    ''' <param name="rowindex"></param>
    ''' <remarks></remarks>
    Public Sub fillCode(ByVal rowindex As Integer)

        With dgDetails
            Dim arrParameterAndValue As ArrayList = New ArrayList
            arrParameterAndValue = FetchData(arrParameterAndValue, "GETRRItem'" & .Item("colSpecificCode", rowindex).Value & "'", CommandType.Text)

            If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                '-->indicate if the row is null
            Else
                .Item("colTOCCOde", rowindex).Value = arrParameterAndValue(1).ToString
                .Item("colItemCode", rowindex).Value = arrParameterAndValue(2).ToString
                .Item("colDescription", rowindex).Value = arrParameterAndValue(3).ToString
                .Item("colBrandType", rowindex).Value = arrParameterAndValue(4).ToString
                .Item("colUnit", rowindex).Value = arrParameterAndValue(5).ToString
                .Item("colLotNo", rowindex).Value = "N/A"
                .Item("colStatus", rowindex).Value = "NO"
                '.Item("colRRNo", rowindex).Value = DBLookUp("Get_RRNo'" & .Item("colSpecificCode", rowindex).Value & "'", "RRNo")
                .Item("colUnitPrice", rowindex).Value = FormatNumber(CDbl(arrParameterAndValue(6).ToString), 2)
                .Item("colAmount", rowindex).Value = CDbl(0)
                .Item("colQty", rowindex).Value = CDbl(0)
                .Item("ColQ", rowindex).Value = DBLookUp("Select Quantity from tbl_100_RR_Temp where RRNo='" & .Item("colRRNo", rowindex).Value & "'and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "Quantity")
            End If
            AddFields(rowindex)
        End With
    End Sub

    Sub CheckTheSentAlert()
        Try
            RunQuery("Delete from tmp_Wr where comp='" & ComputerName & "'")
            _OpenTransaction()
            For Each row As DataGridViewRow In dgDetails.Rows
                If row.IsNewRow = False Then
                    Using com As New SqlCommand("sp_Save_tmp_WR", _Connection, _Transaction)
                        com.CommandType = CommandType.StoredProcedure
                        With com
                            .Parameters.Add(New SqlParameter("@WRNO", txtWRNo.Text))
                            .Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                            .Parameters.Add(New SqlParameter("@Description", row.Cells("colDescription").Value))
                            .Parameters.Add(New SqlParameter("@RRNo", row.Cells("colRRNo").Value))
                            .Parameters.Add(New SqlParameter("@comp", ComputerName))
                            .ExecuteNonQuery()
                        End With


                    End Using
                End If
            Next
            _CloseTransaction(True)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try


    End Sub
#End Region

#Region "GUI"
    Private Sub frm_100_wr_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        If bolFormState = FormState.EditState Then
            SetEditValue()
        End If
        ActivateCommands(bolFormState)
    End Sub

    Private Sub cboDepartment_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartment.Enter
        oldDepartment = cboDepartment.Text
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartment.SelectedIndexChanged
        FillSection()
    End Sub

    Private Sub cboDepartment_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartment.Validated
        FillSection()
    End Sub

    Private Sub cboSection_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSection.Enter
        oldSection = cboSection.Text
    End Sub

    Private Sub cboSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSection.SelectedIndexChanged
        FillLine()
    End Sub

    Private Sub cboSection_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSection.Validated
        FillLine()
    End Sub

    Private Sub cboLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLine.SelectedIndexChanged
        FillLineTextBox()
    End Sub

    Private Sub cboLine_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLine.Validated
        FillLineTextBox()
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Select Case e.ColumnIndex
            Case 1

                frm_Search_WR.ShowDialog()
                AddFields(e.RowIndex)
            Case 14
                If txtWRNo.Text = String.Empty Then MsgBox("Enter the WR #. first!", MsgBoxStyle.Exclamation, "Missing") : Exit Sub
                frm_search_emp.ShowDialog()
        End Select
    End Sub

    Public Sub dgDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellValidated
        Try
            If dgDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing Then
            Else
                dgDetails.Item("colRefNo", e.RowIndex).Value = StrConv(dgDetails.Item("colRefNo", e.RowIndex).Value.ToString, VbStrConv.Uppercase) 'StrConv(dgDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString, VbStrConv.Uppercase)
                dgDetails.Item("colLotNo", e.RowIndex).Value = StrConv(dgDetails.Item("colLotNo", e.RowIndex).Value.ToString, VbStrConv.Uppercase) 'StrConv(dgDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString, VbStrConv.Uppercase)
            End If


            AddFields(e.RowIndex)
            ComputeAllRows()
            With dgDetails
                If .Item("colTQ", e.RowIndex).Value = Nothing Then
                Else
                    If .Item("colTQ", e.RowIndex).Value < 0 Then
                        MsgBox("Item " + .Item("colSpecificCode", e.RowIndex).Value + " have " + CType(.Item("colq", e.RowIndex).Value, String) + " Quantity", MsgBoxStyle.Exclamation)
                        .Item("colQty", e.RowIndex).Value = 0.0
                    End If
                End If
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgDetails_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgDetails.CellValidating
        Try
            Select Case e.ColumnIndex

                Case colQty.Index
                    If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                        MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                        e.Cancel = True
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

    Private Sub frm_100_wr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        End If
    End Sub

    Private Sub frm_100_wr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ResizeForm(Me)
        With ErrProvider
            .Controls.Clear()
            .Controls.Add(txtWRNo, "WR Number")
            .Controls.Add(txtDepartment, "Department Code")
        End With
        CenterControl(lblTitle, Me)
        LoadDepartmentToMultiCombo(cboDepartment)
        FillDataGridViewComboBoxColumn(colIDNo2, "Select EmpID from tbl_000_Employee where DepartmentCode='P&MCD'", "tbl_000_Employee", "EmpID", "EmpID")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_PopUP_WR.ShowDialog()
    End Sub

    Private Sub btncopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncopy.Click
        If MessageBox.Show("Are you sure you want to add the details in new identification code?", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            With frmUnit
                .trans = "WR"
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub dgDetails_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgDetails.UserDeletingRow
        Try
            If bolFormState = FormState.EditState Then
                If MsgBox("Are you sure you want to delete this item?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Prompt") = MsgBoxResult.Yes Then
                    Dim RRno As String = dgDetails.Item("colRRNo", dgDetails.CurrentRow.Index).Value
                    Dim Specificcode As String = dgDetails.Item("colSpecificCode", dgDetails.CurrentRow.Index).Value
                    Dim ReceivingID As String = dgDetails.Item("colIDno", dgDetails.CurrentRow.Index).Value
                    Dim QTY As Double = DBLookUp("Select Quantity from tbl_100_WR_Sub where Wrno='" & txtWRNo.Text & "' and SpecificCode='" & Specificcode & "' and RRno='" & RRno & "' and IDNo1='" & ReceivingID & "'", "Quantity")
                    Call DeleteRows(RRno, Specificcode, QTY, ReceivingID)
                End If
            End If
        Catch ex As Exception

        End Try



    End Sub


#End Region

End Class