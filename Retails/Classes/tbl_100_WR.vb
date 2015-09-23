Imports System.Data.SqlClient
Imports Retails.clsPublic

''' <summary>
''' Save to main Withdrawal table
''' </summary>
''' <remarks></remarks>
Public Class tbl_100_WR
    Private _WRNo As String
    Private _WedrawalDate As String
    Private _DepartmentCode As String
    Private _SectionCode As String
    Private _LineCode As String
    Private _Total As Double

    Public Sub New()

    End Sub
    Public Property WRNo() As String
        Get
            Return _WRNo
        End Get
        Set(ByVal value As String)
            _WRNo = value
        End Set
    End Property
    Public Property WedrawalDAte() As String
        Get
            Return _WedrawalDate
        End Get
        Set(ByVal value As String)
            _WedrawalDate = value
        End Set
    End Property
    Public Property DepartmentCode() As String
        Get
            Return _DepartmentCode
        End Get
        Set(ByVal value As String)
            _DepartmentCode = value
        End Set
    End Property
    Public Property SectionCode() As String
        Get
            Return _SectionCode
        End Get
        Set(ByVal value As String)
            _SectionCode = value
        End Set
    End Property
    Public Property LineCode() As String
        Get
            Return _LineCode
        End Get
        Set(ByVal value As String)
            _LineCode = value
        End Set
    End Property
    Public Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean
        Try
            Dim strMsg As String
            Dim com As SqlCommand
            com = New SqlCommand("SaveWR", _Connection, _Transaction)
            If isEdit Then
                strMsg = "Update WR"
            Else
                strMsg = "ADD New WR"
            End If
            With com
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@WRno", WRNo))
                .Parameters.Add(New SqlParameter("@WedrawalDate", WedrawalDAte))
                .Parameters.Add(New SqlParameter("@DepartmentCode ", DepartmentCode))
                .Parameters.Add(New SqlParameter("@SectionCode", SectionCode))
                .Parameters.Add(New SqlParameter("@LineCode", LineCode))
                .Parameters.Add(New SqlParameter("@Total", Total))
                .Parameters.Add(New SqlParameter("@isStatus", isUnPlaced))
                .Parameters.Add(New SqlParameter("@isReason", isNull))

                .ExecuteNonQuery()
            End With
            Using com1 As New SqlCommand("DELETE FROM tbl_100_WR_Sub WHERE WRNo='" & WRNo & "'", _Connection, _Transaction)
                com1.CommandType = CommandType.Text
                com1.ExecuteNonQuery()
            End Using
            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com1 As New SqlCommand("SaveWR_Sub", _Connection, _Transaction)
                        With com1
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@WRNo", WRNo))
                            .Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                            .Parameters.Add(New SqlParameter("@TOCCode", row.Cells("colTOCCode").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                            .Parameters.Add(New SqlParameter("@ItemCode", row.Cells("colItemCode").Value))
                            .Parameters.Add(New SqlParameter("@Quantity", Replace(row.Cells("colQty").Value, ",", "")))
                            .Parameters.Add(New SqlParameter("@UnitPrice", Replace(row.Cells("colUnitPrice").Value, ",", "")))
                            .Parameters.Add(New SqlParameter("@TotalAmount", row.Cells("colAmount").Value))
                            .Parameters.Add(New SqlParameter("@RRNo", row.Cells("colRRNo").Value))
                            .Parameters.Add(New SqlParameter("@LotNo", row.Cells("colLotNo").Value))
                            .Parameters.Add(New SqlParameter("@Status", row.Cells("colStatus").Value))
                            .Parameters.Add(New SqlParameter("@RefNo", row.Cells("colRefNo").Value))
                            .Parameters.Add(New SqlParameter("@IDNo1", row.Cells("colIDno").Value))
                            .Parameters.Add(New SqlParameter("@Name1", row.Cells("colName").Value))
                            .Parameters.Add(New SqlParameter("@IDNo2", row.Cells("colIDNo2").Value))
                            .Parameters.Add(New SqlParameter("@Name2", row.Cells("colName2").Value))
                            .Parameters.Add(New SqlParameter("@Qty", Replace(row.Cells("ColQ").Value, ",", "")))
                            .Parameters.Add(New SqlParameter("@Tqty", Replace(row.Cells("ColTQ").Value, ",", "")))
                            .Parameters.Add(New SqlParameter("@isStatus", isPlaced))
                            .ExecuteNonQuery()
                        End With
                    End Using

                End If
            Next
            Call SaveAuditTrail(strMsg, _WRNo, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
  


    Public Sub FetchWR(ByVal PK As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim com As New SqlCommand("GetWR_ITEM'" & PK & "'", con)
        Try
            con.Open()
            rdr = com.ExecuteReader(CommandBehavior.CloseConnection)
            While rdr.Read
                _WRNo = rdr("WRNo")
                _WedrawalDate = rdr("WithdrawalDate")
                _DepartmentCode = rdr("DepartmentCode")
                _SectionCode = rdr("SectionCode")
                _LineCode = rdr("LineCode")
                _Total = rdr("Total")

            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    
End Class


''' <summary>
''' Check WR before Save
''' </summary>
''' <remarks></remarks>

Public Class clsWithdrawalOperation

#Region "Variable"

    Dim RRQTY As Double
    Dim WRQTY As Double
    Dim Total As Double
    Dim totalStackOH As Double
    Dim stockOH, totalQTY As Double
    Dim con As New SqlConnection(cnString)


    Dim _SpecificCode, _RRNO As String

#End Region

#Region "Function / Procedure"
    ''' <summary>
    ''' Check the Withdrawal Quantity before to Save
    ''' </summary>
    ''' <param name="controlnum">Withdrawal control number</param>
    ''' <param name="dgsub">datagridview</param>
    ''' <param name="mystate">form State</param>
    ''' <returns>Return True if the Quantity is not exist</returns>
    ''' <remarks>Used</remarks>
    Public Function savetempwr(ByVal controlnum As String, ByVal dgsub As DataGridView, ByVal mystate As FormState) As Boolean


        Dim WRQTY As String
        Dim RRQTY As String



        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        RunQuery("delete from tmp_Withdrawal where userid='" & CurrUser.USER_NAME & "'")
        Try

            Select Case mystate
                ''--> check if the New Withdrawal
                Case FormState.AddState

                    For Each row As DataGridViewRow In dgsub.Rows
                        If row.IsNewRow = False Then
                            Using cmd As New SqlCommand("Save_tmp_Withdrawal", con)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.Add(New SqlParameter("@WRno", controlnum))
                                cmd.Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                                cmd.Parameters.Add(New SqlParameter("@Quantity", Replace(row.Cells("colQty").Value, ",", "")))
                                cmd.Parameters.Add(New SqlParameter("@userid", CurrUser.USER_NAME))
                                cmd.Parameters.Add(New SqlParameter("@rrno", row.Cells("colRRNo").Value))
                                cmd.ExecuteNonQuery()
                            End Using
                        End If
                    Next

                    If isRecordExist("sp_WR_check '" & CurrUser.USER_NAME & "','false'") = True Then
                        savetempwr = False
                        MsgBox("Check your Quantity first", MsgBoxStyle.Exclamation, "Prompt")

                    Else
                        savetempwr = True
                    End If




                    ''--> check modify withdrawal
                Case FormState.EditState

                    For Each row As DataGridViewRow In dgsub.Rows
                        If row.IsNewRow = False Then

                            RRQTY = NZ(DBLookUp("Select Quantity  from tbl_100_RR_Temp where RRNO='" & row.Cells("colRRNo").Value & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'", "Quantity"))

                            WRQTY = NZ(DBLookUp("Select Quantity from tbl_100_WR_Sub where WRNO='" & controlnum & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "' and RRNo='" & row.Cells("colRRNo").Value & "' and IDNo1='" & row.Cells("colIDno").Value & "'", "Quantity"))

                            RRQTY = Val(WRQTY) + Val(RRQTY)

                            Total = RRQTY - Replace(row.Cells("colQty").Value, ",", "")

                            If Total < 0 Then

                                savetempwr = False
                                MsgBox("Check your Quantity first", MsgBoxStyle.Exclamation, "Prompt")
                                Exit Function
                            Else
                                savetempwr = True
                            End If

                        End If
                    Next

            End Select

        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        Finally
            con.Close()
        End Try

    End Function

    ''' <summary>
    ''' append / update transaction detail 
    ''' before to save
    ''' </summary>
    ''' <param name="controlnum">Withdrawal control number</param>
    ''' <param name="dgsub">Datagridview</param>
    ''' <param name="mystate">FormState</param>
    ''' <remarks></remarks>
    Public Sub Check_WR_Operation(ByVal controlnum As String, ByVal dgsub As DataGridView, ByVal mystate As FormState)

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If




        Try
            For Each row As DataGridViewRow In dgsub.Rows
                If row.IsNewRow = False Then

                    _SpecificCode = row.Cells("colSpecificCode").Value
                    _RRNO = row.Cells("colRRNo").Value


                    ''--> Get the stock on hand
                    stockOH = NZ(DBLookUp("Select StackOH from tbl_000_item_Sub where SpecificCode='" & row.Cells("colSpecificCode").Value & "'", "StackOH"))

                    Select Case mystate

                        Case FormState.AddState

                            RRQTY = NZ(DBLookUp("Select Quantity from tbl_100_RR_Temp where RRNO='" & row.Cells("colRRNo").Value & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'", "Quantity"))

                            totalQTY = CDbl(row.Cells("colQty").Value)

                            Total = CDbl(RRQTY) - CDbl(totalQTY)


                            Call RunQuery("Update  tbl_100_RR_Temp set Quantity='" & Total _
                                               & "'where SpecificCode='" & row.Cells("colSpecificCode").Value _
                                               & "' and RRNO='" & row.Cells("colRRNo").Value & "'")
                            Call RunQuery("Update tbl_100_RR set isStatus='" & isnoUpdate & "' where RRNo='" & row.Cells("colRRNo").Value & "'")

                            totalStackOH = CDbl(stockOH) - CDbl(row.Cells("colQty").Value)

                            Call RunQuery("Update tbl_000_Item_Sub set StackOH='" & totalStackOH & "'where SpecificCode='" & row.Cells("colSpecificCode").Value & "'")



                        Case FormState.EditState

                    End Select

                End If
            Next

        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        Finally
            con.Close()
        End Try
    End Sub


#End Region






End Class

























