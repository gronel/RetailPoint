Imports System.Data.SqlClient
Imports Retails.clsPublic
Public Class tbl_100_RR
    Private _RRNo As String
    Private _RRDate As DateTime
    Private _RefOrderNo As String
    Private _RRType As String
    Private _Reference As String
    Private _SupplierID As String
    Private _PayDueDate As String
    Private _ExchangeRate As String
    Private _Remarks As String
    Private _PreparedBy As String
    Private _ReceivedBy As String
    Private _Currenctytype As String
    Private _ActualTotal As Double
    Private _ConvertedTotal As Double
    Private _Dec As Integer

    Public Sub New()

    End Sub
    Public Property dec() As Integer
        Get
            Return _Dec
        End Get
        Set(ByVal value As Integer)
            _Dec = value
        End Set
    End Property
    Public Property RRNo() As String
        Get
            Return _RRNo
        End Get
        Set(ByVal value As String)
            _RRNo = value
        End Set
    End Property
    Public Property RRDate() As DateTime
        Get
            Return _RRDate
        End Get
        Set(ByVal value As DateTime)
            _RRDate = value
        End Set
    End Property
    Public Property RefOrderNo() As String
        Get
            Return _RefOrderNo
        End Get
        Set(ByVal value As String)
            _RefOrderNo = value
        End Set
    End Property
    Public Property RRType() As String
        Get
            Return _RRType
        End Get
        Set(ByVal value As String)
            _RRType = value
        End Set
    End Property
    Public Property Reference() As String
        Get
            Return _Reference
        End Get
        Set(ByVal value As String)
            _Reference = value
        End Set
    End Property
    Public Property SupplierID() As String
        Get
            Return _SupplierID
        End Get
        Set(ByVal value As String)
            _SupplierID = value
        End Set
    End Property

    Public Property PayDueDate() As String
        Get
            Return _PayDueDate
        End Get
        Set(ByVal value As String)
            _PayDueDate = value
        End Set
    End Property
    Public Property ExchangeRate() As String
        Get
            Return _ExchangeRate
        End Get
        Set(ByVal value As String)
            _ExchangeRate = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Public Property PreparedBy() As String
        Get
            Return _PreparedBy
        End Get
        Set(ByVal value As String)
            _PreparedBy = value
        End Set
    End Property
    Public Property ReceivedBy() As String
        Get
            Return _ReceivedBy
        End Get
        Set(ByVal value As String)
            _ReceivedBy = value
        End Set
    End Property
    Public Property CurrencyType() As String
        Get
            Return _Currenctytype
        End Get
        Set(ByVal value As String)
            _Currenctytype = value
        End Set
    End Property
    Public Property ActualTotal() As Double
        Get
            Return _ActualTotal
        End Get
        Set(ByVal value As Double)
            _ActualTotal = value
        End Set
    End Property
    Public Property ConvertedTotal() As Double
        Get
            Return _ConvertedTotal
        End Get
        Set(ByVal value As Double)
            _ConvertedTotal = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean
        Try
            Dim strMsg As String
            Dim com As SqlCommand
            com = New SqlCommand("SaveRR", _Connection, _Transaction)
            If isEdit Then
                strMsg = "Update RR"
            Else
                strMsg = "Add New RR"
            End If
            With com
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@RRNo", RRNo))
                .Parameters.Add(New SqlParameter("@RRDate", RRDate))
                .Parameters.Add(New SqlParameter("@RefOrderNo", RefOrderNo))
                .Parameters.Add(New SqlParameter("@RRType", RRType))
                .Parameters.Add(New SqlParameter("@Reference", Reference))
                .Parameters.Add(New SqlParameter("@PayDueDate", PayDueDate))
                .Parameters.Add(New SqlParameter("@ExchangeRate", ExchangeRate))
                .Parameters.Add(New SqlParameter("@Remarks", Remarks))
                .Parameters.Add(New SqlParameter("@PreparedBy", PreparedBy))
                .Parameters.Add(New SqlParameter("@ReceivedBy", ReceivedBy))
                .Parameters.Add(New SqlParameter("@CurrencyType", CurrencyType))
                .Parameters.Add(New SqlParameter("@ActualTotal", ActualTotal))
                .Parameters.Add(New SqlParameter("@ConvertedTotal", ConvertedTotal))
                .Parameters.Add(New SqlParameter("@isStatus", isPlaced))
                .Parameters.Add(New SqlParameter("@isReason", isNull))
                .Parameters.Add(New SqlParameter("@dec", dec))
                .ExecuteNonQuery()
            End With
          
            RunQuery("DELETE  FROM tbl_100_RR_Sub Where RRno='" & RRNo & "'")
            RunQuery("DELETE  FROM tbl_100_RR_Temp Where RRno='" & RRNo & "'")

            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com2 As New SqlCommand("SaveRR_TEMP", _Connection, _Transaction)
                        With com2
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@RRNo", RRNo))
                            If RRType = "Cash" Then
                                .Parameters.Add(New SqlParameter("@PRJR_No", row.Cells("colJR_PR").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                            Else
                                .Parameters.Add(New SqlParameter("@PRJR_No", isNull))
                            End If

                            .Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                            .Parameters.Add(New SqlParameter("@ItemCode", row.Cells("colItemId").Value))
                            .Parameters.Add(New SqlParameter("@Quantity", CDbl(row.Cells("colQty").Value)))
                            .Parameters.Add(New SqlParameter("@Price", CDbl(row.Cells("colunitprice2").Value)))
                            .Parameters.Add(New SqlParameter("@RRDate", Now.Date))
                            .ExecuteNonQuery()

                        End With
                    End Using
                End If
          
            Next
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com1 As New SqlCommand("SaveRR_Sub", _Connection, _Transaction)
                        With com1
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@RRNo", RRNo))
                            If RRType = "Cash" Then
                                .Parameters.Add(New SqlParameter("@PRJR_No", row.Cells("colJR_PR").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                            Else
                                .Parameters.Add(New SqlParameter("@PRJR_No", isNull))
                            End If
                            .Parameters.Add(New SqlParameter("@SupplierID", row.Cells("colSupplierId").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                            .Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                            .Parameters.Add(New SqlParameter("@ItemCode", row.Cells("colItemId").Value))
                            .Parameters.Add(New SqlParameter("@TocCode", row.Cells("colTocCode").Value))
                            .Parameters.Add(New SqlParameter("@RemarksWarning", row.Cells("colRemarksWarning").Value))
                            .Parameters.Add(New SqlParameter("@ActualQTY", CDbl(row.Cells("colQuantity").Value)))
                            .Parameters.Add(New SqlParameter("@ActualUnit", row.Cells("colUnit").Value))
                            .Parameters.Add(New SqlParameter("@ActualUnitPrice", CDbl(row.Cells("colUnitPrice").Value)))
                            .Parameters.Add(New SqlParameter("@ActualAmount", CDbl(row.Cells("colamount").Value)))
                            .Parameters.Add(New SqlParameter("@ConvertedQTY", CDbl(row.Cells("colQty").Value)))
                            .Parameters.Add(New SqlParameter("@ConvertedUnit", row.Cells("colunit2").Value))
                            .Parameters.Add(New SqlParameter("@ConvertedPrice", CDbl(row.Cells("colunitprice2").Value)))
                            .Parameters.Add(New SqlParameter("@ConvertedAmount", CDbl(row.Cells("colamount2").Value)))
                            .Parameters.Add(New SqlParameter("@dec", CInt(row.Cells("coldec").Value)))
                            .Parameters.Add(New SqlParameter("@date", RRDate))
                            .ExecuteNonQuery()

                        End With
                    End Using

                    If RRType = "PO" Then
                        Dim GetPRNO As String = DBLookUp("Select PRNo from tbl_100_PO_sub where POno='" & RefOrderNo & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'", "PRNO")
                        RunQuery("Update tbl_100_PR set isLock='" & True & "' where PRNo='" & GetPRNO & "'")
                    Else
                        RunQuery("Update tbl_100_PR set isLock='" & True & "' where PRNo='" & row.Cells("colJR_PR").Value & "'")
                    End If


                End If
            Next
            Call SaveAuditTrail(strMsg, RRNo, True)
            ''=================
            ''END SAVE
            ''=================

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Function


        End Try
    End Function
    Public Sub FetchRR(ByVal PK As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim com As New SqlCommand("Select * from tbl_100_RR where RRNo='" & PK & "'", con)
        Try
            con.Open()
            rdr = com.ExecuteReader(CommandBehavior.CloseConnection)
            While rdr.Read
                _RRNo = rdr("RRNo")
                _RRDate = rdr("RRDate")
                _RefOrderNo = rdr("RefOrderNo")
                _RRType = rdr("RRType")
                _Reference = rdr("Reference")
                _PayDueDate = rdr("PayDueDate")
                _ExchangeRate = rdr("ExchangeRate")
                _Remarks = rdr("Remarks")
                _PreparedBy = rdr("PreparedBy")
                _ReceivedBy = rdr("ReceivedBy")
                _Currenctytype = rdr("CurrencyType")
                _Dec = rdr("Dec")
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class


''' <summary>
''' Compute RR Details
''' </summary>
''' <remarks></remarks>
Public Class ComputeRR

    Dim stockOH As Double
    Dim ReqQTY_PR, ReqQTY_JR As Double
    Dim TransQTY As Double
    Dim PRNO, JRNO As String
    Dim RRQTY, totalQ, TempQTy As Double


    Private _RRNO As String
    Private _RefOrderNO As String

    Public Property RRNO() As String
        Get
            Return _RRNO
        End Get
        Set(ByVal value As String)
            _RRNO = value
        End Set
    End Property

    Public Property RefOrderNO() As String
        Get
            Return _RefOrderNO
        End Get
        Set(ByVal value As String)
            _RefOrderNO = value
        End Set
    End Property


    Public Sub _ComputeDetails(ByVal dgsub As DataGridView, ByVal isbolstate As FormState, ByVal RRType As String)
        For Each row As DataGridViewRow In dgsub.Rows
            If row.IsNewRow = False Then

                ''1. Get first the stock on hand
                stockOH = CDbl(NZ(row.Cells("colOH").Value))

                ''2. Find the RR type
                Select Case RRType

                    Case "Cash"
                        ''Get  PR or JR QTY
                        ''if the ReqQTY_PR =0 then the transaction if going to JR else if ReqQTY_JR=0 then the transaction is going to PR
                        ReqQTY_PR = CDbl(NZ(DBLookUp("Select ReqQty from tbl_100_PR_Sub where Prno='" & row.Cells("colJR_PR").Value & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'", "ReqQty")))
                        ReqQTY_JR = CDbl(NZ(DBLookUp("Select ReqQty from tbl_100_JR_Sub where Jrno='" & row.Cells("colJR_PR").Value & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'", "ReqQty")))

                        TransQTY = CDbl(ReqQTY_PR) + CDbl(ReqQTY_JR)

                        ''3. Fint what transaction is geting with
                        Select Case isbolstate

                            Case FormState.AddState
                                If CDbl(NZ(row.Cells("colQuantity").Value)) > CDbl(NZ(row.Cells("colRRQTY").Value)) Then
                                    Call UpdateStatus("Cash", "CashExcess", row.Cells("colJR_PR").Value, row.Cells("colSpecificCode").Value, 0)
                                ElseIf CDbl(NZ(row.Cells("colQuantity").Value)) < CDbl(NZ(row.Cells("colRRQTY").Value)) Then
                                    RRQTY = Val(CDbl(NZ(row.Cells("colRRQTY").Value))) - Val(CDbl(NZ(row.Cells("colQuantity").Value)))
                                    Call UpdateStatus("Cash", "CashLacking", row.Cells("colJR_PR").Value, row.Cells("colSpecificCode").Value, RRQTY)
                                ElseIf CDbl(NZ(row.Cells("colQuantity").Value)) = CDbl(NZ(row.Cells("colRRQTY").Value)) Then
                                    Call UpdateStatus("Cash", "CashDelivered", row.Cells("colJR_PR").Value, row.Cells("colSpecificCode").Value, 0)
                                End If

                                ''4. Final update Item Quantity Stock ON hand
                                Call UpdateStockOH(row.Cells("colSpecificCode").Value, row.Cells("colTOH").Value, "Add", 0)
                        End Select

                    Case "PO"


                        Dim POQTY As String = DBLookUp("Select ReqQty from tbl_100_PO_Sub where PONO='" & RefOrderNO & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'", "ReqQty")

                        Select Case isbolstate
                            Case FormState.AddState

                                If CDbl(NZ(row.Cells("colQuantity").Value)) > CDbl(NZ(row.Cells("colRRQTY").Value)) Then
                                    'for excess
                                    Call UpdateStatus("PO", "POExcess", RefOrderNO, row.Cells("colSpecificCode").Value, 0)
                                ElseIf CDbl(NZ(row.Cells("colQuantity").Value)) < CDbl(NZ(row.Cells("colRRQTY").Value)) Then
                                    'for lacking
                                    RRQTY = Val(CDbl(NZ(row.Cells("colRRQTY").Value))) - Val(CDbl(NZ(row.Cells("colQuantity").Value)))
                                    Call UpdateStatus("PO", "POLacking", RefOrderNO, row.Cells("colSpecificCode").Value, RRQTY)
                                ElseIf CInt(NZ(row.Cells("colQuantity").Value)) = CDbl(NZ(row.Cells("colRRQTY").Value)) Then
                                    'for Delivered
                                    Call UpdateStatus("PO", "PODelivered", RefOrderNO, row.Cells("colSpecificCode").Value, 0)
                                End If
                                ''4. Final update Item Quantity Stock ON hand
                                Call UpdateStockOH(row.Cells("colSpecificCode").Value, row.Cells("colTOH").Value, isbolstate, 0)

                            Case FormState.EditState
                                SQL = "SELECT     tbl_100_RR.RRNo, tbl_100_RR.RefOrderNo, tbl_100_RR_Sub.SpecificCode, SUM(tbl_100_RR_Sub.ActualQTY) AS Quantity " & _
                                      "FROM         tbl_100_RR INNER JOIN " & _
                                      "tbl_100_RR_Sub ON tbl_100_RR.RRNo = tbl_100_RR_Sub.RRNo " & _
                                      "GROUP BY tbl_100_RR.RRNo, tbl_100_RR.RefOrderNo, tbl_100_RR_Sub.SpecificCode " & _
                                      "HAVING      (tbl_100_RR.RRNo <> '" & RRNO & "') and (SpecificCode='" & row.Cells("colSpecificCode").Value & "') and (RefOrderNo='" & RefOrderNO & "') "

                                Dim arrParameterAndValue As ArrayList = New ArrayList
                                arrParameterAndValue = FetchData(arrParameterAndValue, SQL, CommandType.Text)
                                If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                                    totalQ = 0
                                Else
                                    totalQ = NZ(arrParameterAndValue(3).ToString)
                                End If
                          
                                TempQTy = CDbl(totalQ) + CDbl(row.Cells("colQuantity").Value)
                                If CInt(TempQTy) < CInt(POQTY) Then
                                    RRQTY = CDbl(POQTY) - TempQTy
                                    Call UpdateStatus("PO", "POLacking", RefOrderNO, row.Cells("colSpecificCode").Value, RRQTY)
                                ElseIf CInt(TempQTy) > CInt(POQTY) Then
                                    Call UpdateStatus("PO", "POExcess", RefOrderNO, row.Cells("colSpecificCode").Value, 0)
                                ElseIf CInt(TempQTy) = CInt(POQTY) Then
                                    Call UpdateStatus("PO", "PODelivered", RefOrderNO, row.Cells("colSpecificCode").Value, 0)
                                End If

                                RRQTY = CDbl(NZ(DBLookUp("Select ActualQTY from tbl_100_RR_Sub where RRNO='" & RRNO & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'", "ActualQTY")))
                             
                                Call UpdateStockOH(row.Cells("colSpecificCode").Value, row.Cells("colTOH").Value, isbolstate, TempQTy)
                        End Select

                End Select

            End If
        Next
    End Sub

    Private Sub UpdateStockOH(ByVal ItemSpecificCode As String, ByVal OH As Double, ByVal isbolstate As FormState, ByVal QTY As Double)

        Select Case isbolstate
            Case FormState.AddState

                RunQuery("Update tbl_000_Item_Sub set StackOH='" & OH & "'where SpecificCode='" & ItemSpecificCode & "' ")

            Case FormState.EditState

                RunQuery("Update tbl_000_Item_Sub set StackOH='" & QTY & "'where SpecificCode='" & ItemSpecificCode & "' ")

        End Select



    End Sub


    Private Sub UpdateStatus(ByVal istype As String, ByVal isStatus As String, ByVal controlno As String, ByVal ItemSpecificCode As String, ByVal value As Double)

        Select Case istype
            Case "Cash"
                Select Case isStatus
                    Case "CashExcess"
                        ''update Status
                        RunQuery("Update tbl_100_PR_Sub set Status='" & isExcess & "' where (PRNo='" & controlno & "') and (SpecificCode='" & ItemSpecificCode & "')")

                        RunQuery("Update tbl_100_JR_Sub set Status='" & isExcess & "' where (JRNo='" & controlno & "') and (SpecificCode='" & ItemSpecificCode & "')")

                        '-->Update transaction balance
                        RunQuery("Update tbl_100_PR_Sub set RRQTY='" & value & "' where (PRNo='" & controlno & "') and ( SpecificCode='" & ItemSpecificCode & "')")

                        RunQuery("Update tbl_100_JR_Sub set RRQTY='" & value & "' where (JRNo='" & controlno & "') and (SpecificCode='" & ItemSpecificCode & "')")

                    Case "CashLacking"

                        ''update status
                        RunQuery("Update tbl_100_PR_Sub set Status='" & isLacking & "' where (PRNo='" & controlno & "') and ( SpecificCode='" & ItemSpecificCode & "')")

                        RunQuery("Update tbl_100_JR_Sub set Status='" & isLacking & "' where (JRNo='" & controlno & "') and (SpecificCode='" & ItemSpecificCode & "')")

                        ''update Quantity
                        RunQuery("Update tbl_100_PR_Sub set RRQTY='" & value & "' where (PRNo='" & controlno & "') and ( SpecificCode='" & ItemSpecificCode & "')")

                        RunQuery("Update tbl_100_JR_Sub set RRQTY='" & value & "' where (JRNo='" & controlno & "') and (SpecificCode='" & ItemSpecificCode & "')")

                    Case "CashDelivered"
                        ''update status
                        RunQuery("Update tbl_100_PR_Sub set Status='" & isPurchased & "' where (PRNo='" & controlno & "') and (SpecificCode='" & ItemSpecificCode & "')")

                        RunQuery("Update tbl_100_JR_Sub set Status='" & isDone & "' where (JRNo='" & controlno & "') and (SpecificCode='" & ItemSpecificCode & "')")

                        ''update Quantity
                        RunQuery("Update tbl_100_PR_Sub set RRQTY='" & value & "' where (PRNo='" & controlno & "') and ( SpecificCode='" & ItemSpecificCode & "')")

                        RunQuery("Update tbl_100_JR_Sub set RRQTY='" & value & "' where (JRNo='" & controlno & "') and (SpecificCode='" & ItemSpecificCode & "')")

                End Select
            Case "PO"
                PRNO = DBLookUp("Select PRNO from tbl_100_PO_sub where PONo='" & _RefOrderNO & "'and SpecificCode='" & ItemSpecificCode & "'", "PRNo")
                Select Case isStatus
                    Case "POExcess"
                        ''update PO
                        RunQuery("Update tbl_100_PO_Sub set Status='" & isExcess & "' ,RRQTY='" & value & "' where PONo='" & _RefOrderNO & "' and SpecificCode='" & ItemSpecificCode & "'")
                        ''update PR
                        RunQuery("Update tbl_100_PR_Sub set Status='" & isExcess & "',RRQTY='" & value & "' where Prno='" & PRNO & "' and SpecificCode='" & ItemSpecificCode & "'")


                    Case "POLacking"
                        RunQuery("Update tbl_100_PO_Sub set Status='" & isLacking & "' ,RRQTY='" & value & "' where PONo='" & _RefOrderNO & "' and SpecificCode='" & ItemSpecificCode & "'")
                        ''update PR
                        RunQuery("Update tbl_100_PR_Sub set Status='" & isLacking & "',RRQTY='" & value & "' where Prno='" & PRNO & "' and SpecificCode='" & ItemSpecificCode & "'")
                    Case "PODelivered"
                        RunQuery("Update tbl_100_PO_Sub set Status='" & isDelivered & "' ,RRQTY='" & value & "' where PONo='" & _RefOrderNO & "' and SpecificCode='" & ItemSpecificCode & "'")
                        ''update PR
                        RunQuery("Update tbl_100_PR_Sub set Status='" & isDelivered & "',RRQTY='" & value & "' where Prno='" & PRNO & "' and SpecificCode='" & ItemSpecificCode & "'")


                End Select
            Case "JO"
                JRNO = DBLookUp("Select JRNO from tbl_100_JO_sub where JONo='" & _RefOrderNO & "'and  SpecificCode='" & ItemSpecificCode & "'", "JRNo")
                Select Case isStatus

                    Case "JOExcess"
                        RunQuery("Update tbl_100_JO_Sub set Status='" & isExcess & "' where JONo='" & _RefOrderNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                        ''-->update JR status
                        RunQuery("Update tbl_100_JR_Sub set Status='" & isExcess & "' where Jrno='" & JRNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                        ''-->update running qty 
                        RunQuery("Update tbl_100_JR_Sub set RRQTY='" & value & "' where Jrno='" & JRNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                        RunQuery("Update tbl_100_JO_Sub set RRQTY ='" & value & "' where JONO='" & _RefOrderNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                    Case "JOLacking"
                        ''update status
                        RunQuery("Update tbl_100_JO_Sub set Status='" & isLacking & "' where JONo='" & _RefOrderNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                        RunQuery("Update tbl_100_JR_Sub set Status='" & isLacking & "' where Jrno='" & JRNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                        ''update Quantity
                        RunQuery("Update tbl_100_JO_Sub set RRQTY='" & value & "' where Jono='" & _RefOrderNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                        RunQuery("Update tbl_100_JR_Sub set RRQTY='" & value & "' where Jrno='" & JRNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                    Case "JODone"
                        ''update status
                        RunQuery("Update tbl_100_JO_Sub set Status='" & isDone & "' where JONo='" & _RefOrderNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                        RunQuery("Update tbl_100_JR_Sub set Status='" & isDone & "' where Jrno='" & JRNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                        ''update Quantity
                        RunQuery("Update tbl_100_JR_Sub set RRQTY='" & value & "' where Jrno='" & JRNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                        RunQuery("Update tbl_100_JO_Sub set RRQTY ='" & value & "' where JONO='" & _RefOrderNO & "' and SpecificCode='" & ItemSpecificCode & "'")

                End Select
        End Select


    End Sub
End Class
