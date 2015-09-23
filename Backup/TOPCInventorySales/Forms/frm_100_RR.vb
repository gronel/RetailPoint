Imports TOPCInventorySales.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_100_RR

#Region "Variable"
    Implements IBPSCommand
    Public bolFormState As clsPublic.FormState
    Public myParent As frm_100_RRList
    Dim ErrProvider As New ErrorProviderExtended
    Dim term As Integer = 0
    Dim RRNo As String
    Dim a As String 'it hold the supplier type value
    Dim b As String ' it hold the payment term id value
    Dim time As String 'it hold the time
    Dim dec As Integer
    Public pr, jr As String
    Public Prno As String
    Public JRno As String
    Dim totalQ As String
    Dim stockOH As String

    Dim clsRRCumpute As New ComputeRR

#End Region

#Region "Difination"

    Public Function REF_PRNO_LIST(ByVal strCommand As String) As String
        Dim arrSource As New ArrayList
        Dim PRLIST As String
        Dim PRlist2 As String
        Dim con As New SqlConnection(cnString)
        Try
            con.Open()
            Dim myCmd As SqlCommand = New SqlCommand(strCommand, con)
            Dim myReader As SqlDataReader = myCmd.ExecuteReader
            With myReader
                If .HasRows Then
                    While .Read
                        For introw As Integer = 0 To (.FieldCount - 1)

                            If introw = 1 Then
                                PRLIST += myReader.Item(introw).ToString & ","
                            End If

                        Next

                    End While
                    PRlist2 = PRLIST.Remove(PRLIST.Length - 1)
                End If
                .Close()
            End With
            con.Close()
            Return PRlist2
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Function


    ''' <summary>
    ''' View Report
    ''' </summary>
    ''' <remarks></remarks>
    Sub viewReport(ByVal category As String)
        Dim mycount As Integer
        If cborrtype.Text = "Cash" Then
            mycount = 0
            mycount = CountDataRow("sp_Get_Ref_PRNO '" & txtRRNo.Text & "'")

            If mycount = 1 Then
                cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_RR_Report.rpt")
                arrParametersAndValue.Clear()
                arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@category", category))
                arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@RRNo", txtRRNo.Text))
                cryRpt.SetDataSource(FillReport("sp_rpt_RR", CommandType.StoredProcedure, arrParametersAndValue))

            ElseIf mycount > 1 Then

                cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_RR_Report_2.rpt")
                arrParametersAndValue.Clear()
                arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@category", category))
                arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@RRNo", txtRRNo.Text))
                cryRpt.SetDataSource(FillReport("sp_rpt_RR_2", CommandType.StoredProcedure, arrParametersAndValue))
                cryRpt.SetParameterValue("RefPRNo", REF_PRNO_LIST("sp_Get_Ref_PRNO '" & txtRRNo.Text & "'"))
            ElseIf mycount = 0 Then
                cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_RR_Report.rpt")
                arrParametersAndValue.Clear()
                arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@category", category))
                arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@RRNo", txtRRNo.Text))
                cryRpt.SetDataSource(FillReport("sp_rpt_RR", CommandType.StoredProcedure, arrParametersAndValue))

            End If
        Else
            cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_RR_Report.rpt")
            arrParametersAndValue.Clear()
            arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@category", category))
            arrParametersAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@RRNo", txtRRNo.Text))
            cryRpt.SetDataSource(FillReport("sp_rpt_RR", CommandType.StoredProcedure, arrParametersAndValue))
        End If



        With frm_200_ReportV
            .rpt_viewer.ReportSource = cryRpt
            .Text = "Receiving Report"
            .Show()
            .Focus()
        End With
    End Sub
    ''' <summary>
    ''' Clear
    ''' </summary>
    ''' <remarks></remarks>
    Sub clear()
        txtsupplierid.Clear()
        txtsuppliername.Clear()
        txtsupplierAddress.Clear()
        txtpaymentterm.Clear()
        txtsuppliertype.Clear()
        cborrtype.SelectedIndex = -1
        term = 0
    End Sub

    Private Sub PreviewFromTemp()
        Dim cls As New tmp_RR
        If ErrProvider.CheckAndShowSummaryErrorMessage Then
            If bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtRRNo.Text & "'") Then
                ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtRRNo.Text & "'") Then
                ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtRRNo.Text & "'") Then
                ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtRRNo.Text & "'") Then
                ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtRRNo.Text & "'") Then
                ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtRRNo.Text & "'") Then
                ErrorProvider1.SetError(txtRRNo, "This ID No. is already exists!")
            ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtRRNo.Text & "'") Then
                ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")

            ElseIf CountGridRows(dgDetails) = 0 Then
                MsgBox("Empty Item(s)!", MsgBoxStyle.Exclamation)
                Exit Sub
            ElseIf txtrate.Text = String.Empty Or txtrate.Text = 0 Then
                MsgBox("Exchange rate is required", MsgBoxStyle.Exclamation, "Prompt")
            Else
                For Each row As DataGridViewRow In dgDetails.Rows
                    If row.IsNewRow = False Then
                        If row.Cells("colQuantity").Value = 0 Then
                            MsgBox("Actual Quantity is required!", MsgBoxStyle.Exclamation, "Prompt")
                            Exit Sub
                        ElseIf row.Cells("colQty").Value = 0 Then
                            MsgBox("Converted Quantity is required!", MsgBoxStyle.Exclamation, "Prompt")
                            Exit Sub
                        ElseIf row.Cells("colunitprice2").Value = 0 Then
                            MsgBox("Converted Price is required!", MsgBoxStyle.Exclamation, "Prompt")
                            Exit Sub
                        End If

                    End If
                Next

                With cls
                    .RRNo = txtRRNo.Text
                    .RRDate = dtpRRDate.Text
                    .RefOrderNo = cboRefNo.Text
                    .RRType = cborrtype.Text
                    .Reference = txtReference.Text
                    .SupplierID = txtsupplierid.Text
                    .PayDueDate = txtpayduedate.Text
                    .ExchangeRate = txtrate.Text
                    .Remarks = txtRemarks.Text
                    .PreparedBy = txtPrepared.Text
                    .ReceivedBy = cboreceived.Text
                    .CurrencyType = cbocurrency.Text
                    .ActualTotal = txtTotalActual.Text
                    .ConvertedTotal = txtTotalConverted.Text
                    .dec = dec
                    .Save(dgDetails)
                End With

                Call viewReport("Temp")

                RunQuery("Delete from tmp_RR")
                RunQuery("Delete from tmp_RR_Sub")
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
                viewReport("RR")

            Case "Preview"

                Call PreviewFromTemp()


        End Select
    End Sub
    ''' <summary>
    ''' cancel the transaction number 
    ''' </summary>
    ''' <remarks></remarks>
    Sub voidrecord()

        If HasRecord(txtRRNo.Text) = True Then
            MsgBox("Transaction cannot be void " & vbNewLine & "is being used in other transaction", MsgBoxStyle.Exclamation, "Prompt")
            Exit Sub
        End If

        With opendialog
            .Tname = "RR"
            .TID = RRNo
            .ShowDialog()
        End With

    End Sub
    ''' <summary>
    ''' Enable all tolls after void the transaction number
    ''' </summary>
    ''' <remarks></remarks>
    Sub enabled_tools()
        txtRRNo.Enabled = False
        dtpRRDate.Enabled = False
        cbocurrency.Enabled = False
        cboRefNo.Enabled = False
        cborrtype.Enabled = False
        txtReference.Enabled = False
        txtpayduedate.Enabled = False
        txtrate.Enabled = False
        dgDetails.Enabled = False
        txtRemarks.Enabled = False
        txtPrepared.Enabled = False
        cboreceived.Enabled = False
    End Sub
    ''' <summary>
    ''' get and set status
    ''' </summary>
    ''' <param name="istype">RR type[cash,PO,JO]</param>
    ''' <param name="rowindex">Datagridview row number</param>
    ''' <remarks></remarks>
    Sub UpdateStatus(ByVal istype As String, ByVal isStatus As String, ByVal rowindex As Integer, ByVal value As Double)

        With dgDetails
            Select Case istype
                Case "Cash"
                    Select Case isStatus
                        Case "CashExcess"
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set Status='" & isExcess & "' where (PRNo='" & .Item("colJR_PR", rowindex).Value & "') and (SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set Status='" & isExcess & "' where (JRNo='" & .Item("colJR_PR", rowindex).Value & "') and (SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            '-->Update transaction balance
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set RRQTY='" & FormatNumber(value, CInt(NZ(.Item("coldec", rowindex).Value))) & "' where (PRNo='" & .Item("colJR_PR", rowindex).Value & "') and ( SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set RRQTY='" & FormatNumber(value, CInt(NZ(.Item("coldec", rowindex).Value))) & "' where (JRNo='" & .Item("colJR_PR", rowindex).Value & "') and (SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                        Case "CashLacking"
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set Status='" & isLacking & "' where (PRNo='" & .Item("colJR_PR", rowindex).Value & "') and ( SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set Status='" & isLacking & "' where (JRNo='" & .Item("colJR_PR", rowindex).Value & "') and (SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using

                            '-->Update transaction balance

                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set RRQTY='" & FormatNumber(value, CInt(NZ(.Item("coldec", rowindex).Value))) & "' where (PRNo='" & .Item("colJR_PR", rowindex).Value & "') and ( SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set RRQTY='" & FormatNumber(value, CInt(NZ(.Item("coldec", rowindex).Value))) & "' where (JRNo='" & .Item("colJR_PR", rowindex).Value & "') and (SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                        Case "CashDelivered"
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set Status='" & isPurchased & "' where (PRNo='" & .Item("colJR_PR", rowindex).Value & "') and (SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set Status='" & isDone & "' where (JRNo='" & .Item("colJR_PR", rowindex).Value & "') and (SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            '-->Update Transaction balance
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set RRQTY='" & FormatNumber(value, CInt(NZ(.Item("coldec", rowindex).Value))) & "' where (PRNo='" & .Item("colJR_PR", rowindex).Value & "') and ( SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set RRQTY='" & FormatNumber(value, CInt(NZ(.Item("coldec", rowindex).Value))) & "' where (JRNo='" & .Item("colJR_PR", rowindex).Value & "') and (SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "')", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                    End Select
                Case "PO"
                    Prno = DBLookUp("Select PRNO from tbl_100_PO_sub where PONo='" & cboRefNo.Text & "'and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "PRNo")
                    Select Case isStatus
                        Case "POExcess"
                            Using com1 As New SqlCommand("Update tbl_100_PO_Sub set Status='" & isExcess & "' where PONo='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set Status='" & isExcess & "' where Prno='" & Prno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set RRQTY='" & value & "' where Prno='" & Prno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_PO_Sub set RRQTY='" & value & "' where Pono='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                        Case "POLacking"
                            Using com1 As New SqlCommand("Update tbl_100_PO_Sub set Status='" & isLacking & "' where PONo='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set Status='" & isLacking & "' where Prno='" & Prno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using

                            Using com1 As New SqlCommand("Update tbl_100_PO_Sub set RRQTY='" & value & "' where Pono='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set RRQTY='" & value & "' where Prno='" & Prno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                        Case "PODelivered"
                            Using com1 As New SqlCommand("Update tbl_100_PO_Sub set Status='" & isDelivered & "' where PONo='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set Status='" & isDelivered & "' where Prno='" & Prno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_PR_Sub set RRQTY='" & value & "' where Prno='" & Prno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_PO_Sub set RRQTY ='" & value & "' where PONO='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using


                    End Select
                Case "JO"
                    JRno = DBLookUp("Select JRNO from tbl_100_JO_sub where JONo='" & cboRefNo.Text & "'and  SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "JRNo")
                    Select Case isStatus

                        Case "JOExcess"
                            Using com1 As New SqlCommand("Update tbl_100_JO_Sub set Status='" & isExcess & "' where JONo='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            ''-->update JR status
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set Status='" & isExcess & "' where Jrno='" & JRno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            ''-->update running qty 
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set RRQTY='" & value & "' where Jrno='" & JRno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JO_Sub set RRQTY ='" & value & "' where JONO='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                        Case "JOLacking"
                            Using com1 As New SqlCommand("Update tbl_100_JO_Sub set Status='" & isLacking & "' where JONo='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set Status='" & isLacking & "' where Jrno='" & JRno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using

                            Using com1 As New SqlCommand("Update tbl_100_JO_Sub set RRQTY='" & value & "' where Jono='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set RRQTY='" & value & "' where Jrno='" & JRno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                        Case "JODone"
                            Using com1 As New SqlCommand("Update tbl_100_JO_Sub set Status='" & isDone & "' where JONo='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set Status='" & isDone & "' where Jrno='" & JRno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JR_Sub set RRQTY='" & value & "' where Jrno='" & JRno & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                            Using com1 As New SqlCommand("Update tbl_100_JO_Sub set RRQTY ='" & value & "' where JONO='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", _Connection, _Transaction)
                                com1.CommandType = CommandType.Text
                                com1.ExecuteNonQuery()
                            End Using
                    End Select
            End Select
        End With

    End Sub
    ''' <summary>
    ''' Update Stock on hand
    ''' </summary>
    ''' <param name="rowindex">Datagridview row</param>
    ''' <param name="mood">ADD/EDIT</param>
    ''' <remarks>Yes</remarks>
    Sub UpdateStockOH(ByVal rowindex As Integer, ByVal mood As String, ByVal QTY As Double)
        With dgDetails
            Select Case mood
                Case "Add"
                    ''--> update stack on hand
                    Using com1 As New SqlCommand("Update tbl_000_Item_Sub set StackOH=" & Replace(FormatNumber(.Item("colTOH", rowindex).Value, CInt(NZ(.Item("coldec", rowindex).Value))), ",", "") & " where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "' ", _Connection, _Transaction)
                        com1.CommandType = CommandType.Text
                        com1.ExecuteNonQuery()
                    End Using
                Case "Edit"
                    Using com1 As New SqlCommand("Update tbl_000_Item_Sub set StackOH=" & 0 & " where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "' ", _Connection, _Transaction)
                        com1.CommandType = CommandType.Text
                        com1.ExecuteNonQuery()
                    End Using

                    Using com1 As New SqlCommand("Update tbl_000_Item_Sub set StackOH=" & QTY & " where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "' ", _Connection, _Transaction)
                        com1.CommandType = CommandType.Text
                        com1.ExecuteNonQuery()
                    End Using

            End Select


        End With
    End Sub

    Sub ComputingDetails()
        _OpenTransaction()
        With dgDetails
            For rowindex = 0 To dgDetails.RowCount - 1


                Dim RRqt As Double
                Dim TempQTy As Double
                Dim totalRRQTY As Double
                If .Item("colRRQTY", rowindex).Value = "" Or .Item("colRRQTY", rowindex).Value = Nothing Then
                    '-->nothing to happen
                Else
                    stockOH = .Item("colOH", rowindex).Value

                    '----------------'
                    '                '
                    '   FOR CASH     '
                    '----------------'
                    If cborrtype.Text = "Cash" Then
                        Dim reqpr, reqjr As String
                        Dim transQty As Double
                        reqpr = NZ(DBLookUp("Select ReqQty from tbl_100_PR_Sub where Prno='" & .Item("colJR_PR", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ReqQty"))
                        reqjr = NZ(DBLookUp("Select ReqQty from tbl_100_JR_Sub where Jrno='" & .Item("colJR_PR", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ReqQty"))


                        transQty = CDbl(reqpr) + CDbl(reqjr)

                        '-->update state
                        If bolFormState = FormState.EditState Then
                            Dim totalQTY As String = "SELECT     PRJR_No, SpecificCode, RRNo, SUM(ActualQTY) AS Quantity " & _
                                                     "FROM tbl_100_RR_Sub  " & _
                                                     "GROUP BY PRJR_No, SpecificCode, RRNo " & _
                                                    "HAVING      (RRNo <> '" & txtRRNo.Text & "') AND (SpecificCode ='" & .Item("colSpecificCode", rowindex).Value & "') and PRJR_No='" & .Item("colJR_PR", rowindex).Value & "'"

                            Dim arrParameterAndValue As ArrayList = New ArrayList
                            arrParameterAndValue = FetchData(arrParameterAndValue, totalQTY, CommandType.Text)
                            If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                                '-->indicate if the row is null
                            Else
                                totalQ = arrParameterAndValue(3).ToString
                            End If


                            If totalQ = String.Empty Then totalQ = "0"


                            TempQTy = CDbl(totalQ) + CDbl(.Item("colQuantity", rowindex).Value)
                            If TempQTy < transQty Then
                                totalRRQTY = FormatNumber(transQty - TempQTy, 2)
                                Call UpdateStatus("Cash", "CashLacking", rowindex, totalRRQTY)
                            ElseIf TempQTy > transQty Then
                                Call UpdateStatus("Cash", "CashExcess", rowindex, 0)
                            ElseIf TempQTy = transQty Then
                                Call UpdateStatus("Cash", "CashDelivered", rowindex, 0)
                            End If

                            Dim totalStackOH As Double
                            Dim rrqty As String = DBLookUp("Select ActualQTY from tbl_100_RR_Sub where RRNO='" & txtRRNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ActualQTY")
                            totalStackOH = FormatNumber((CDbl(stockOH) - CDbl(rrqty)) + TempQTy, 2)
                            Call UpdateStockOH(rowindex, "Edit", TempQTy)
                            'Added State
                        ElseIf bolFormState = FormState.AddState Then
                            If CDbl(NZ(.Item("colQuantity", rowindex).Value)) > CDbl(NZ(.Item("colRRQTY", rowindex).Value)) Then
                                Call UpdateStatus("Cash", "CashExcess", rowindex, 0)
                            ElseIf CDbl(NZ(.Item("colQuantity", rowindex).Value)) < CDbl(NZ(.Item("colRRQTY", rowindex).Value)) Then
                                RRqt = FormatNumber(CDbl(NZ(.Item("colRRQTY", rowindex).Value)) - CDbl(NZ(.Item("colQuantity", rowindex).Value)), 2)
                                Call UpdateStatus("Cash", "CashLacking", rowindex, RRqt)
                            ElseIf CDbl(NZ(.Item("colQuantity", rowindex).Value)) = CDbl(NZ(.Item("colRRQTY", rowindex).Value)) Then
                                Call UpdateStatus("Cash", "CashDelivered", rowindex, 0)
                            End If
                            Call UpdateStockOH(rowindex, "Add", 0)
                        End If




                        '-----------------------'
                        '     FOR PO            '
                        '                       '
                        '-----------------------'
                    ElseIf cborrtype.Text = "PO" Then

                        Dim POQTY As String = DBLookUp("Select ReqQty from tbl_100_PO_Sub where PONO='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ReqQty")


                        If bolFormState = FormState.AddState Then
                            If CDbl(NZ(.Item("colQuantity", rowindex).Value)) > CDbl(NZ(.Item("colRRQTY", rowindex).Value)) Then
                                'for excess
                                Call UpdateStatus("PO", "POExcess", rowindex, 0)
                            ElseIf CDbl(NZ(.Item("colQuantity", rowindex).Value)) < CDbl(NZ(.Item("colRRQTY", rowindex).Value)) Then
                                'for lacking
                                RRqt = FormatNumber(CDbl(NZ(.Item("colRRQTY", rowindex).Value)) - CDbl(NZ(.Item("colQuantity", rowindex).Value)), 2)
                                Call UpdateStatus("PO", "POLacking", rowindex, RRqt)
                            ElseIf CDbl(NZ(.Item("colQuantity", rowindex).Value)) = CDbl(NZ(.Item("colRRQTY", rowindex).Value)) Then
                                'for Delivered
                                Call UpdateStatus("PO", "PODelivered", rowindex, 0)
                            End If
                            Call UpdateStockOH(rowindex, "Add", 0)

                        ElseIf bolFormState = FormState.EditState Then

                            Dim totalQTY As String = "SELECT     tbl_100_RR.RRNo, tbl_100_RR.RefOrderNo, tbl_100_RR_Sub.SpecificCode, SUM(tbl_100_RR_Sub.ActualQTY) AS Quantity " & _
                                                    "FROM         tbl_100_RR INNER JOIN " & _
                                                   "tbl_100_RR_Sub ON tbl_100_RR.RRNo = tbl_100_RR_Sub.RRNo " & _
                                                    "GROUP BY tbl_100_RR.RRNo, tbl_100_RR.RefOrderNo, tbl_100_RR_Sub.SpecificCode " & _
                                                    "HAVING      (tbl_100_RR.RRNo <> '" & txtRRNo.Text & "') and (SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "') and (RefOrderNo='" & cboRefNo.Text & "') "

                            Dim arrParameterAndValue As ArrayList = New ArrayList
                            arrParameterAndValue = FetchData(arrParameterAndValue, totalQTY, CommandType.Text)
                            If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                                totalQ = "0"
                            Else
                                totalQ = NZ(arrParameterAndValue(3).ToString)
                            End If

                            TempQTy = CDbl(totalQ) + CDbl(.Item("colQuantity", rowindex).Value)
                            If CDbl(TempQTy) < CDbl(POQTY) Then
                                totalRRQTY = CDbl(POQTY) - TempQTy
                                Call UpdateStatus("PO", "POLacking", rowindex, totalRRQTY)
                            ElseIf CDbl(TempQTy) > CDbl(POQTY) Then
                                Call UpdateStatus("PO", "POExcess", rowindex, 0)
                            ElseIf CDbl(TempQTy) = CDbl(POQTY) Then
                                Call UpdateStatus("PO", "PODelivered", rowindex, 0)
                            End If
                            Dim totalStackOH As Double
                            Dim rrqty As String = DBLookUp("Select ActualQTY from tbl_100_RR_Sub where RRNO='" & txtRRNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ActualQTY")
                            If rrqty = String.Empty Then
                                rrqty = "0"
                            End If
                            totalStackOH = (CDbl(stockOH) - CDbl(rrqty)) + TempQTy
                            Call UpdateStockOH(rowindex, "Edit", TempQTy)
                        End If

                        '-----------------------'
                        '     FOR JO           '
                        '                       '
                        '-----------------------'
                    ElseIf cborrtype.Text = "JO" Then
                        Dim JOQTY As String = DBLookUp("Select ReqQty from tbl_100_JO_Sub where JOno='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ReqQTy")
                        If bolFormState = FormState.AddState Then
                            If CDbl(NZ(.Item("colQuantity", rowindex).Value)) > CDbl(NZ(.Item("colRRQTY", rowindex).Value)) Then
                                'for excess
                                Call UpdateStatus("JO", "JOExcess", rowindex, 0)
                            ElseIf CDbl(NZ(.Item("colQuantity", rowindex).Value)) < CDbl(NZ(.Item("colRRQTY", rowindex).Value)) Then
                                'for lacking
                                RRqt = FormatNumber(CDbl(NZ(.Item("colRRQTY", rowindex).Value)) - CDbl(NZ(.Item("colQuantity", rowindex).Value)), 2)
                                Call UpdateStatus("JO", "JOLacking", rowindex, RRqt)
                            ElseIf CDbl(NZ(.Item("colQuantity", rowindex).Value)) = CDbl(NZ(.Item("colRRQTY", rowindex).Value)) Then
                                'for Delivered
                                Call UpdateStatus("JO", "JODone", rowindex, 0)
                            End If
                            Call UpdateStockOH(rowindex, "Add", 0)

                        ElseIf bolFormState = FormState.EditState Then
                            Dim totalQTY As String = "SELECT     tbl_100_RR.RRNo, tbl_100_RR.RefOrderNo, tbl_100_RR_Sub.SpecificCode, SUM(tbl_100_RR_Sub.ActualQTY) AS Quantity " & _
                                                    "FROM         tbl_100_RR INNER JOIN " & _
                                                   "tbl_100_RR_Sub ON tbl_100_RR.RRNo = tbl_100_RR_Sub.RRNo " & _
                                                    "GROUP BY tbl_100_RR.RRNo, tbl_100_RR.RefOrderNo, tbl_100_RR_Sub.SpecificCode " & _
                                                    "HAVING      (tbl_100_RR.RRNo <> '" & txtRRNo.Text & "') and (SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "') and (RefOrderNo='" & cboRefNo.Text & "') "

                            Dim arrParameterAndValue As ArrayList = New ArrayList
                            arrParameterAndValue = FetchData(arrParameterAndValue, totalQTY, CommandType.Text)
                            If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                                '-->indicate if the row is null
                            Else
                                totalQ = arrParameterAndValue(3).ToString
                            End If
                            If totalQ = String.Empty Then
                                totalQ = "0"
                            End If

                            TempQTy = CDbl(totalQ) + CDbl(.Item("colQuantity", rowindex).Value)
                            If CDbl(TempQTy) < CDbl(JOQTY) Then
                                totalRRQTY = CDbl(JOQTY) - TempQTy
                                Call UpdateStatus("JO", "JOLacking", rowindex, totalRRQTY)
                            ElseIf CDbl(TempQTy) > CDbl(JOQTY) Then
                                Call UpdateStatus("JO", "JOExcess", rowindex, 0)
                            ElseIf CDbl(TempQTy) = CDbl(JOQTY) Then
                                Call UpdateStatus("JO", "JODone", rowindex, 0)
                            End If

                            Dim totalStackOH As Double
                            Dim rrqty As String = DBLookUp("Select ActualQTY from tbl_100_RR_Sub where RRNO='" & txtRRNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ActualQTY")
                            totalStackOH = (CDbl(stockOH) - CDbl(rrqty)) + TempQTy
                            Call UpdateStockOH(rowindex, "Edit", TempQTy)
                        End If
                    End If
                End If
            Next

        End With
        _CloseTransaction(True)
    End Sub

    Private Function HasRecord(ByVal RRNO As String) As Boolean
        Dim isHaveRecord As Boolean = False
        '-->check if this PO no is used in RR transaction
        If isRecordExist("SELECT     tbl_100_WR_Sub.RRNo " & _
                         "FROM         tbl_100_WR_Sub INNER JOIN " & _
                         "tbl_100_WR ON tbl_100_WR_Sub.WRNo = tbl_100_WR.WRNo " & _
                         "WHERE     (tbl_100_WR.isStatus <> N'CANCELLED') AND (tbl_100_WR_Sub.RRNo = '" & RRNO & "')") Then
            isHaveRecord = True
        End If


        Return isHaveRecord

    End Function

    ''Save Records
    Public Sub SaveRecord()
        Dim RR As New tbl_100_RR
        Dim strResult As Boolean
     
        If HasRecord(txtRRNo.Text) = True Then
            MsgBox("Invalid to update is being used in other transaction", MsgBoxStyle.Exclamation, "Prompt")
            Exit Sub
        End If


        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
                If bolFormState = FormState.AddState And isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtRRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtRRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select PRNo from tbl_100_PR where PRNo='" & txtRRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtRRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtRRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtRRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtRRNo, "This ID No. is already exists!")
                ElseIf bolFormState = FormState.AddState And isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtRRNo.Text & "'") Then
                    ErrorProvider1.SetError(txtRRNo, "This ID No. is being used by another transaction!")

                ElseIf CountGridRows(dgDetails) = 0 Then
                    MsgBox("Empty Item(s)!", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf txtrate.Text = String.Empty Or txtrate.Text = 0 Then
                    MsgBox("Exchange rate is required", MsgBoxStyle.Exclamation, "Prompt")
                Else
                

                    With RR
                        .RRNo = txtRRNo.Text
                        .RRDate = dtpRRDate.Text
                        .RefOrderNo = cboRefNo.Text
                        .RRType = cborrtype.Text
                        .Reference = txtReference.Text
                        .SupplierID = txtsupplierid.Text
                        .PayDueDate = txtpayduedate.Text
                        .ExchangeRate = txtrate.Text
                        .Remarks = txtRemarks.Text
                        .PreparedBy = txtPrepared.Text
                        .ReceivedBy = cboreceived.Text
                        .CurrencyType = cbocurrency.Text
                        .ActualTotal = txtTotalActual.Text
                        .ConvertedTotal = txtTotalConverted.Text
                        .dec = dec

                        If bolFormState = FormState.EditState Then
                            _OpenTransaction()
                            strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                            _CloseTransaction(strResult)
                            Call ComputingDetails()

                            MsgBox("Updated Complete", MsgBoxStyle.Information, "Prompt")
                        Else
                            If MsgBox("Do you want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Prompt") = MsgBoxResult.Yes Then
                                _OpenTransaction()
                                strResult = .Save(bolFormState = FormState.EditState, dgDetails)
                                _CloseTransaction(strResult)
                                Call ComputingDetails()

                            Else
                                Exit Sub
                            End If

                        End If

                        Me.Close()
                        Call myParent.RefreshRecord("sp_100_Get_RR_List '" & MainForm.tsSearch.Text & "'")

                    End With
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Prompt")
        End Try
    End Sub

    Private Sub ComputeRRNow()
        With clsRRCumpute
            .RRNO = txtRRNo.Text
            .RefOrderNO = cboRefNo.Text
            ._ComputeDetails(dgDetails, bolFormState, cborrtype.Text)
        End With
    End Sub
    ''' <summary>
    ''' Close Form
    ''' </summary>
    ''' <remarks></remarks>
    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        ActivateCommands(FormState.LoadState)
        Me.Close()
    End Sub

    ''' <summary>
    ''' Activate Command in main form
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


    ''' <summary>
    ''' Set Edit value in selected control number
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetEditValue()
        Dim RR As New tbl_100_RR
        With RR
            RRNo = myParent.dgList.Item("RRNo", myParent.dgList.CurrentRow.Index).Value
            .FetchRR(RRNo)
            txtRRNo.Text = .RRNo
            dtpRRDate.Text = .RRDate
            cbocurrency.Text = .CurrencyType
            txtrate.Text = .ExchangeRate
            cborrtype.Text = .RRType
            txtReference.Text = .Reference
            cboreceived.Text = .ReceivedBy
            txtRemarks.Text = .Remarks
            dec = .dec
            If cborrtype.Text = "Cash" Then
                SQL = "Select PRJR_No from tbl_100_RR_Sub where(RRNo='" & .RRNo & "')"
                FillDataGridViewComboBoxColumn(colJR_PR, SQL, "Tbl_100_RR_Sub", "PRJR_No", "PRJR_No")


            Else
                SQL = "Select RefOrderNo from tbl_100_RR where RRNo='" & .RRNo & "'"
                FillCombobox(cboRefNo, SQL, "tbl_100_RR", "RefOrderNo", "RefOrderNo")
                cboRefNo.SelectedValue = .RefOrderNo
            End If
        End With


        FillDataGrid(dgDetails, "GetRR_Sub'" & RRNo & "'", 0, 19)

        Call isBal(cborrtype.Text)

        For i = 0 To dgDetails.RowCount - 1

            If cborrtype.Text = "PO" Then
                dgDetails.Item("colOH", i).Value = DBLookUp("Select StackOH from tbl_000_ITem_sub where SpecificCode='" & dgDetails.Item("colSpecificCode", i).Value & "'", "StackOH")
                Call HideColumn()
            ElseIf cborrtype.Text = "JO" Then
                dgDetails.Item("colOH", i).Value = DBLookUp("Select StackOH from tbl_000_ITem_sub where SpecificCode='" & dgDetails.Item("colSpecificCode", i).Value & "'", "StackOH")
                Call HideColumn()
            ElseIf cborrtype.Text = "Cash" Then
                Dim pr, jr As String
                pr = DBLookUp("Select * from tbl_100_PR_Sub where PRno='" & dgDetails.Item("colJR_PR", i).Value & "'", "PRNo")
                jr = DBLookUp("Select * from tbl_100_JR_Sub where JRNo='" & dgDetails.Item("colJR_PR", i).Value & "'", "JRNo")
                If dgDetails.Item("colJR_PR", i).Value = pr Then
                    dgDetails.Item("QTY", i).Value = DBLookUp("Select reqQTY from tbl_100_PR_Sub where PRNo='" & dgDetails.Item("colJR_PR", i).Value & "' and SpecificCode='" & dgDetails.Item("colSpecificCode", i).Value & "'", "ReqQTY")
                    Call HideColumn()
                ElseIf dgDetails.Item("colJR_PR", i).Value = jr Then
                    dgDetails.Item("QTY", i).Value = DBLookUp("Select reqQTY from tbl_100_JR_Sub where JRNo='" & dgDetails.Item("colJR_PR", i).Value & "' and SpecificCode='" & dgDetails.Item("colSpecificCode", i).Value & "'", "ReqQTY")
                    Call HideColumn()
                End If
            Else
                txtsupplierid.Text = ""
            End If

            Call AddFields(i)

        Next
        ComputeAllRows()
        txtRRNo.Enabled = False
    End Sub


    Sub AddFields(ByVal rowIndex As Integer)
        Try
            With dgDetails



                Dim ActAmount As Double

                Dim ACTPrice As Double = NZ(.Item("colUnitPrice", rowIndex).Value)
                Dim ActQTY As Double = NZ(.Item("colQuantity", rowIndex).Value)
                ActAmount = ActQTY * ACTPrice
                .Item("colAmount", rowIndex).Value = ActAmount 'FormatNumber(CDbl(NZ(.Item("colQuantity", rowIndex).Value)) * CDbl(NZ(.Item("colUnitPrice", rowIndex).Value)), dec)
                .Item("colQuantity", rowIndex).Value = FormatNumber(NZ(.Item("colQuantity", rowIndex).Value), CInt(NZ(.Item("coldec", rowIndex).Value)))
                .Item("colUnitPrice", rowIndex).Value = ACTPrice ' FormatNumber(CDbl(NZ(dgDetails.Item("colUnitPrice", rowIndex).Value)), dec)


                If NZ(.Item("colQty", rowIndex).Value) <> 0 Then

                    .Item("colQty", rowIndex).Value = FormatNumber(NZ(.Item("colQty", rowIndex).Value), CInt(NZ(.Item("coldec", rowIndex).Value)))

                    If .Item("colUnit", rowIndex).Value = .Item("colunit2", rowIndex).Value Then

                        .Item("colUnitPrice2", rowIndex).Value = FormatNumber(CDbl(NZ(.Item("colUnitPrice", rowIndex).Value)) * CDbl(NZ((txtrate.Text))), 2)
                        .Item("colamount2", rowIndex).Value = CDbl(.Item("colunitprice2", rowIndex).Value) * CDbl(.Item("colQty", rowIndex).Value)

                    Else

                        .Item("colUnitPrice2", rowIndex).Value = FormatNumber(GetConvertedPrice(rowIndex), 2)

                    End If

                    .Item("colAmount2", rowIndex).Value = FormatNumber(GetConvetedAmount(rowIndex), 2)

                    .Item("colTOH", rowIndex).Value = CDbl(NZ(.Item("colOH", rowIndex).Value)) + CDbl(NZ(.Item("colQty", rowIndex).Value))
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try

    End Sub


    ''' <summary>
    ''' Get conveted price
    ''' </summary>
    ''' <param name="rowindex">datagrid row</param>
    ''' <returns>Converted Price</returns>
    ''' <remarks>Used</remarks>
    Private Function GetConvertedPrice(ByVal rowindex As Integer)
        Dim convertedPrice As Double
        Dim actualPrice As Double = NZ(dgDetails.Item("colUnitPrice", rowindex).Value)
        Dim actualQTY As Double = NZ(dgDetails.Item("colQuantity", rowindex).Value)
        Dim convertedQTY As Double = NZ(dgDetails.Item("colQty", rowindex).Value)
        Dim xrate As Double = NZ(txtrate.Text)
        Dim cprice, cqty As Double
        cprice = NZ(actualPrice * xrate)
        cqty = NZ(convertedQTY / actualQTY)

        If xrate = 0.0 Or convertedQTY = 0.0 Then
        Else
            convertedPrice = cprice / cqty
        End If


        Return convertedPrice
    End Function

    ''' <summary>
    ''' Get Converted Amount
    ''' </summary>
    ''' <param name="rowindex">Datagrid row</param>
    ''' <returns>Conveted Amount</returns>
    ''' <remarks>Used</remarks>
    Private Function GetConvetedAmount(ByVal rowindex As Integer)
        Dim actualPrice As Double = NZ(dgDetails.Item("colUnitPrice", rowindex).Value)
        Dim actualQTY As Double = NZ(dgDetails.Item("colQuantity", rowindex).Value)
        Dim ConvertedQTY As Double = NZ(dgDetails.Item("colQty", rowindex).Value)
        Dim ConvertedPrice As Double = NZ(dgDetails.Item("colunitprice2", rowindex).Value)
        Dim ConvertedAmount As Double
        Dim cprice, cqty As Double

        Dim xrate As Double = NZ(txtrate.Text)
        cprice = NZ(actualPrice * xrate)
        cqty = NZ(ConvertedQTY / actualQTY)
        ConvertedPrice = cprice / cqty

        If xrate = 0.0 Or ConvertedQTY = 0.0 Then
        Else
            ConvertedAmount = ConvertedQTY * ConvertedPrice
        End If

        Return ConvertedAmount
    End Function


    ''' <summary>
    ''' Compute all rows in DatagridView
    ''' </summary>
    ''' <remarks></remarks>
    Sub ComputeAllRows()
        Dim sum, sum2 As Double
        With dgDetails
            For i = 0 To .RowCount - 2
                sum = sum + NZ(.Item("colAmount2", i).Value)
            Next
            txtTotalConverted.Text = FormatNumber(NZ(sum))
            With dgDetails
                For x = 0 To .RowCount - 2
                    sum2 = sum2 + NZ(.Item("colAmount", x).Value)
                Next
                txtTotalActual.Text = FormatNumber(NZ(sum2), dec)

            End With
        End With
    End Sub
    ''' <summary>
    ''' Hide column in datagrid view if the rr type is po or jo
    ''' </summary>
    ''' <remarks></remarks>
    Sub HideColumn()
        If cborrtype.Text = "PO" Or cborrtype.Text = "JO" Then
            colJR_PR.Visible = False
        ElseIf cborrtype.Text = "Cash" Then
            colJR_PR.Visible = True
        End If
    End Sub
    ''' <summary>
    ''' Get the running balance 
    ''' </summary>
    ''' <param name="istype"> RR type [Cash,PO,JO]</param>
    ''' <remarks></remarks>
    Sub isBal(ByVal istype As String)
        Dim pr, jr As String
        With dgDetails
            For rowindex = 0 To dgDetails.RowCount - 1
                Select Case istype
                    Case "PO"
                        .Item("colRRQTY", rowindex).Value = DBLookUp("Select RRQTY from tbl_100_PO_Sub where PONO='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "RRQTY")
                    Case "JO"
                        .Item("colRRQTY", rowindex).Value = DBLookUp("Select RRQTY from tbl_100_JO_Sub where JONO='" & cboRefNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "RRQTY")
                    Case "Cash"
                        pr = DBLookUp("Select PRNO from tbl_100_PR where PRNo='" & .Item("colJR_PR", rowindex).Value & "'", "PRNO")
                        jr = DBLookUp("Select JRNO from tbl_100_JR where JRNo='" & .Item("colJR_PR", rowindex).Value & "'", "JRNO")

                        If .Item("colJR_PR", rowindex).Value = pr Then
                            .Item("colRRQTY", rowindex).Value = DBLookUp("Select RRQTY from tbl_100_PR_Sub where PRNO='" & .Item("colJR_PR", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "RRQTY")
                        ElseIf .Item("colJR_PR", rowindex).Value = jr Then
                            .Item("colRRQTY", rowindex).Value = DBLookUp("Select RRQTY from tbl_100_JR_Sub where JRNO='" & .Item("colJR_PR", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "RRQTY")
                        End If
                End Select
            Next
        End With
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="rowindex"></param>
    ''' <remarks></remarks>
    Public Sub fillCode(ByVal rowindex As Integer)
        Dim arrParameterAndValue As ArrayList = New ArrayList
        arrParameterAndValue.Clear()

        With dgDetails
            Dim suppliertermsid As String
            If cborrtype.Text = "Cash" Then
                arrParameterAndValue.Clear()
                .Item("colJR_PR", rowindex).Value = frm_Searchitem.x
                arrParameterAndValue = FetchData(arrParameterAndValue, "sp_GetSearchItem'" & "Get_PRItemAndJRItem" & "','" & .Item("colJR_PR", rowindex).Value & "'", CommandType.Text)
                If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                    '-->indicate if the row is null
                Else


                    .Item("colSupplierId", rowindex).Value = arrParameterAndValue(6).ToString
                    .Item("ColSupplierName", rowindex).Value = arrParameterAndValue(7).ToString
                    .Item("coldec", rowindex).Value = arrParameterAndValue(5)
                End If



                arrParameterAndValue.Clear()
                arrParameterAndValue = FetchData(arrParameterAndValue, "sp_GetSearchItem'" & "Get_SpecificCodeDetails" & "','" & .Item("colSpecificCode", rowindex).Value & "'", CommandType.Text)
                If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                    '-->indicate if the row is null
                Else
                    .Item("colTocCode", rowindex).Value = arrParameterAndValue(1).ToString
                    .Item("colItemId", rowindex).Value = arrParameterAndValue(0).ToString
                    .Item("colDescription", rowindex).Value = arrParameterAndValue(2).ToString
                    .Item("colBrand", rowindex).Value = arrParameterAndValue(3).ToString
                    .Item("colUnit", rowindex).Value = arrParameterAndValue(4).ToString
                    .Item("colunit2", rowindex).Value = arrParameterAndValue(5).ToString
                End If


                .Item("colRemarksWarning", rowindex).Value = "NO send Alert"
                .Item("colQuantity", rowindex).Value = CDbl(0)
                .Item("colQty", rowindex).Value = CDbl(0)

                .Item("colunitprice2", rowindex).Value = CDbl(0.0)
                pr = DBLookUp("Select * from tbl_100_PR_Sub where PRno='" & .Item("colJR_PR", rowindex).Value & "'", "PRNo")
                jr = DBLookUp("Select * from tbl_100_JR_Sub where JRNo='" & .Item("colJR_PR", rowindex).Value & "'", "JRNo")
                suppliertermsid = DBLookUp("Select payterms from tbl_000_Supplier where supplierid ='" & .Item("colSupplierId", rowindex).Value & "'", "payterms")
                .Item("colterm", rowindex).Value = DBLookUp("Select PayTermsName from tbl_000_Supplier_PayTerms where PayTermsID='" & suppliertermsid & "'", "PayTermsName")

                'function to clear
                If .Item("colJR_PR", rowindex).Value = pr Then
                    .Item("QTY", rowindex).Value = DBLookUp("Select ReqQTY from tbl_100_PR_Sub Where PRNo='" & .Item("colJR_PR", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ReqQTY")
                    .Item("colUnitPrice", rowindex).Value = DBLookUp("Select ActualUnitPrice from tbl_100_PR_Sub Where PRNo='" & .Item("colJR_PR", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ActualUnitPrice")
                    .Item("colRRQTY", rowindex).Value = DBLookUp("Select RRQTY from tbl_100_PR_Sub Where PRNo='" & .Item("colJR_PR", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "RRQTY")
                    dec = IIf(DBLookUp("Select Dec from tbl_100_PR where PRNo='" & .Item("colJR_PR", rowindex).Value & "'", "Dec") = String.Empty, 0, DBLookUp("Select Dec from tbl_100_PR where PRNo='" & .Item("colJR_PR", rowindex).Value & "'", "Dec"))
                ElseIf .Item("colJR_PR", rowindex).Value = jr Then
                    .Item("QTY", rowindex).Value = DBLookUp("Select ReqQTY from tbl_100_JR_Sub Where JRNo='" & .Item("colJR_PR", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ReqQTY")
                    .Item("colUnitPrice", rowindex).Value = DBLookUp("Select ActualUnitPrice from tbl_100_JR_Sub Where JRNo='" & .Item("colJR_PR", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "ActualUnitPrice")
                    .Item("colRRQTY", rowindex).Value = DBLookUp("Select RRQTY from tbl_100_JR_Sub Where JRNo='" & .Item("colJR_PR", rowindex).Value & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "RRQTY")
                    dec = DBLookUp("Select Dec from tbl_100_JR where JRNo='" & .Item("colJR_PR", rowindex).Value & "'", "Dec")
                End If


                AddFields(rowindex)
                '-->Fill datagridview cell if the rr type is po
            ElseIf cborrtype.Text = "PO" Then
                arrParameterAndValue.Clear()
                arrParameterAndValue = FetchData(arrParameterAndValue, "sp_FillDataGridViewCell'" & "RR-PO" & "','" & cboRefNo.Text & "','" & .Item("colSpecificCode", rowindex).Value & "'", CommandType.Text)

                If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                    '-->indicate if the row is null
                Else
                    .Item("colJR_PR", rowindex).Value = "isnull"
                    .Item("colSupplierId", rowindex).Value = arrParameterAndValue(0).ToString
                    .Item("ColSupplierName", rowindex).Value = arrParameterAndValue(1).ToString
                    .Item("colterm", rowindex).Value = arrParameterAndValue(2).ToString
                    .Item("colTocCode", rowindex).Value = arrParameterAndValue(3).ToString
                    .Item("colItemId", rowindex).Value = arrParameterAndValue(4).ToString
                    .Item("colDescription", rowindex).Value = arrParameterAndValue(5).ToString
                    .Item("colBrand", rowindex).Value = arrParameterAndValue(6).ToString
                    .Item("colRemarksWarning", rowindex).Value = "NO send Alert"
                    .Item("colQuantity", rowindex).Value = CInt(0)
                    .Item("colQty", rowindex).Value = CInt(0)
                    .Item("colUnit", rowindex).Value = arrParameterAndValue(7).ToString
                    .Item("colUnitPrice", rowindex).Value = arrParameterAndValue(8).ToString
                    .Item("colunit2", rowindex).Value = arrParameterAndValue(13).ToString
                    .Item("colunitprice2", rowindex).Value = CDbl(0.0)
                    .Item("QTY", rowindex).Value = arrParameterAndValue(9).ToString
                    .Item("colRRQTY", rowindex).Value = arrParameterAndValue(10).ToString
                    .Item("coldec", rowindex).Value = arrParameterAndValue(14)


                    dec = arrParameterAndValue(11).ToString
                    .Item("colOH", rowindex).Value = arrParameterAndValue(12).ToString
                    AddFields(rowindex)
                End If
                '-->Fill datagridview cell if the rr type is jo
            ElseIf cborrtype.Text = "JO" Then

                arrParameterAndValue = FetchData(arrParameterAndValue, "sp_FillDataGridViewCell'" & "RR-JO" & "','" & cboRefNo.Text & "','" & .Item("colSpecificCode", rowindex).Value & "'", CommandType.Text)

                If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                    '-->indicate if the row is null
                Else
                    .Item("colJR_PR", rowindex).Value = "isnull"
                    .Item("colSupplierId", rowindex).Value = arrParameterAndValue(0).ToString
                    .Item("ColSupplierName", rowindex).Value = arrParameterAndValue(1).ToString
                    .Item("colterm", rowindex).Value = arrParameterAndValue(2).ToString
                    .Item("colTocCode", rowindex).Value = arrParameterAndValue(3).ToString
                    .Item("colItemId", rowindex).Value = arrParameterAndValue(4).ToString
                    .Item("colDescription", rowindex).Value = arrParameterAndValue(5).ToString
                    .Item("colBrand", rowindex).Value = arrParameterAndValue(6).ToString
                    .Item("colRemarksWarning", rowindex).Value = "NO send Alert"
                    .Item("colQuantity", rowindex).Value = CInt(0)
                    .Item("colQty", rowindex).Value = CInt(0)
                    .Item("colUnit", rowindex).Value = arrParameterAndValue(7).ToString
                    .Item("colUnitPrice", rowindex).Value = arrParameterAndValue(8).ToString
                    .Item("colunit2", rowindex).Value = arrParameterAndValue(7).ToString
                    .Item("colunitprice2", rowindex).Value = CDbl(0.0)
                    .Item("QTY", rowindex).Value = arrParameterAndValue(9).ToString
                    .Item("colRRQTY", rowindex).Value = arrParameterAndValue(10).ToString
                    dec = arrParameterAndValue(11).ToString
                    .Item("colOH", rowindex).Value = arrParameterAndValue(12).ToString
                    AddFields(rowindex)
                End If
            End If
            .Item("colOH", rowindex).Value = DBLookUp("select StackOH from tbl_000_Item_Sub where SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "StackOH")
            .Item("colTOH", rowindex).Value = 0
        End With
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Sub keyREF()
        Try
            Dim arrParameterAndValue As ArrayList = New ArrayList
            Dim POType, JOType As String
            Dim paytermday As String
            POType = DBLookUp("Select * from tbl_100_PO where PONo='" & cboRefNo.Text & "'", "PONo")
            JOType = DBLookUp("Select * from tbl_100_JO where JONo='" & cboRefNo.Text & "'", "JONo")
            If POType <> "" Then
                cborrtype.Text = "PO"
                arrParameterAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@PONo", cboRefNo.Text))
                arrParameterAndValue = FetchData(arrParameterAndValue, "SELECT     tbl_100_PO.PONo, tbl_100_PO.SupplierID, tbl_000_Supplier_PayTerms.NoOfDays " & _
                                                                        " FROM tbl_100_PO INNER JOIN " & _
                                                                        "tbl_000_Supplier ON tbl_100_PO.SupplierID = tbl_000_Supplier.SupplierID INNER JOIN " & _
                                                                        "tbl_000_Supplier_PayTerms ON tbl_000_Supplier.PayTerms = tbl_000_Supplier_PayTerms.PayTermsID " & _
                                                                        "Where  tbl_100_PO.PONo=@PONo", CommandType.Text)
                If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                    txtsupplierid.Text = String.Empty
                Else
                    txtsupplierid.Text = arrParameterAndValue(1).ToString
                    paytermday = arrParameterAndValue(2).ToString
                    txtpayduedate.Text = FormatDateTime(dtpRRDate.Value.AddDays(CInt(paytermday)), DateFormat.ShortDate)

                End If
            ElseIf JOType <> "" Then
                cborrtype.Text = "JO"
                arrParameterAndValue.Add(New clsEnumerations.strArrays(SqlDbType.NVarChar, "@JONo", cboRefNo.Text))
                arrParameterAndValue = FetchData(arrParameterAndValue, "SELECT     tbl_100_JO.JONo, tbl_100_JO.SupplierID, tbl_000_Supplier_PayTerms.NoOfDays " & _
                                                                        " FROM tbl_100_JO INNER JOIN " & _
                                                                        "tbl_000_Supplier ON tbl_100_JO.SupplierID = tbl_000_Supplier.SupplierID INNER JOIN " & _
                                                                        "tbl_000_Supplier_PayTerms ON tbl_000_Supplier.PayTerms = tbl_000_Supplier_PayTerms.PayTermsID " & _
                                                                        "Where  tbl_100_JO.JONo=@JONo", CommandType.Text)
                If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                    txtsupplierid.Text = String.Empty
                Else
                    txtsupplierid.Text = arrParameterAndValue(1).ToString
                    paytermday = arrParameterAndValue(2).ToString
                    txtpayduedate.Text = FormatDateTime(dtpRRDate.Value.AddDays(CInt(paytermday)), DateFormat.ShortDate)

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region

#Region "GUI"

    Private Sub frm_100_RR_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
        If bolFormState = FormState.EditState Then
            SetEditValue()
        Else
            cboreceived.Text = ""
        End If
        ActivateCommands(bolFormState)
    End Sub

    Private Sub frm_100_RR_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        dgDetails.Rows.Clear()
    End Sub

    Private Sub frm_100_RR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        End If
    End Sub

    Private Sub frm_100_RR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me) 'Resize the  form 
        CenterControl(lblTitle, Me) 'center the title of the transaction
        txtPrepared.Text = CurrUser.USER_FULLNAME
        With ErrProvider 'Get the error or empty text
            .Controls.Clear()
            .Controls.Add(txtRRNo, "RR Number")
            .Controls.Add(dtpRRDate, "RR Date")
            .Controls.Add(txtPrepared, "Prepared")
            .Controls.Add(cboreceived, "Received")
        End With
        time = dtpRRDate.Value

        LoadCurrencyType(cbocurrency)
        SQL = "SELECT FirstName + ' ' + CASE WHEN MiddleName IS NULL THEN '' WHEN MiddleName = ' ' THEN '' ELSE SubString(MiddleName, 1, 1) + '. ' END + LastName + ' ' AS EmpName, IsActive FROM tbl_000_Employee WHERE (IsActive = 1)"
        SQL = SQL + " and DepartmentCode='P&MCD'"
        FillCombobox(cboreceived, SQL, "tbl_000_Employee", "EmpName", "EmpName")

    End Sub

    Private Sub dgDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellValidated
        Call AddFields(e.RowIndex)
        Call ComputeAllRows()
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Select Case e.ColumnIndex
            Case 5
                With frm_Searchitem
                    If cbocurrency.Text = String.Empty Or cborrtype.Text = String.Empty Then
                        MsgBox("-->Please input Currency type" & vbNewLine & "-->Please input RR type", MsgBoxStyle.Exclamation, "Missing")
                    End If
                    If cborrtype.Text = "Cash" Then
                        If dgDetails.Item("colJR_PR", e.RowIndex).Value = "" Then
                            MsgBox("Enter first the PR or JR code.", MsgBoxStyle.Exclamation)
                        Else
                            .frm = "Cash"
                            .currencytype = cbocurrency.Text
                            .y = cborrtype.Text
                            .x = dgDetails.Item("colJR_PR", e.RowIndex).Value
                            .ShowDialog()
                        End If
                    ElseIf cborrtype.Text = "PO" Or cborrtype.Text = "JO" Then
                        .frm = "NOtcash"
                        .currencytype = cbocurrency.Text
                        .y = cborrtype.Text
                        .x = cboRefNo.Text
                        .ShowDialog()
                    End If
                End With
        End Select
    End Sub

    Private Sub dgDetails_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgDetails.CellValidating
        Select Case e.ColumnIndex
            Case colSpecificCode.Index
                If CheckCodeFromDatagridView(dgDetails, 3, e.FormattedValue.ToString, e.RowIndex, False) = True Then
                    dgDetails.CancelEdit()
                    MsgBox("Specific Code already exists in the list.", MsgBoxStyle.Exclamation, "Duplicate Code")
                Else
                    If bolFormState <> FormState.EditState Then
                        fillCode(e.RowIndex)
                        For i = 0 To dgDetails.RowCount - 1
                            AddFields(i)
                        Next
                        ComputeAllRows()
                    End If
                End If
            Case colQuantity.Index
                If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                    MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                    e.Cancel = True
                End If
            Case colQty.Index
                If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                    MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                    e.Cancel = True
                End If
            Case colunitprice2.Index
                If ValidateNumericDataGrid(dgDetails, e.ColumnIndex, e.RowIndex, False) = False Then
                    MsgBox("Please enter numeric value.", MsgBoxStyle.Exclamation, "Invalid entry")
                    e.Cancel = True
                End If
        End Select



    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub cboRefNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRefNo.SelectedIndexChanged
        keyREF()
        dgDetails.Rows.Clear()
    End Sub
    Private Sub dgDetails_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDetails.DataError
        On Error Resume Next
    End Sub

    Private Sub cbocurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocurrency.SelectedIndexChanged
        If cbocurrency.Text = "" Then
            cboRefNo.Text = ""
        Else
            lblAcurrency.Text = cbocurrency.Text
            txtrate.Text = 0
        End If

    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        e.KeyChar = ValidateMoney(e.KeyChar, txtrate)
    End Sub


    Private Sub txtrate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrate.TextChanged
        'e.KeyChar = ValidateMoney(e.KeyChar, txtrate)

        For i = 0 To dgDetails.RowCount - 2
            AddFields(i)
            ComputeAllRows()
        Next

    End Sub

    Private Sub btncopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncopy.Click
        If MessageBox.Show("Are you sure you want to add the details in new identification code?", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            With frmUnit
                .trans = "RR"
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub dtpRRDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRRDate.ValueChanged
        keyREF()
    End Sub


    Private Sub cborrtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cborrtype.SelectedIndexChanged
        If cborrtype.Text = "Cash" Then
            cboRefNo.Enabled = False
            Call HideColumn()
            FillDataGridViewComboBoxColumn(colJR_PR, "GetPRNo_and_JRNo '" & cbocurrency.Text & "'", "#temp", "orders", "orders")
        Else
            Select Case cborrtype.Text
                Case "PO"
                    FillCombobox(cboRefNo, "GetJONo_and_PONo '" & "GetJoAndPO" & "','" & cbocurrency.Text & "',PO", "#tempPO", "orders", "orders")
                Case "JO"
                    FillCombobox(cboRefNo, "GetJONo_and_PONo '" & "GetJoAndPO" & "','" & cbocurrency.Text & "',JO", "#tempJO", "orders", "orders")
            End Select
            cboRefNo.SelectedIndex = -1
            cboRefNo.Enabled = True
            Call HideColumn()
        End If
    End Sub
#End Region

End Class