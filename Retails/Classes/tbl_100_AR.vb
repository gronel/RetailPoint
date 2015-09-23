Imports System.Data.SqlClient
Public Class tbl_100_AR
    Private _ARNo As String
    Private _Accountable As String
    Private _Userid As String
    Private _DepartmentCode As String
    Private _SectionCode As String
    Private _LineCode As String
    Private _Total As Double
    Private _CurrencyType As String
    Private _ARDate As DateTime

    Public Sub New()

    End Sub

    Public Property ARDate() As DateTime
        Get
            Return _ARDate
        End Get
        Set(ByVal value As DateTime)
            _ARDate = value
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
    Public Property CurrencyType() As String
        Get
            Return _CurrencyType
        End Get
        Set(ByVal value As String)
            _CurrencyType = value
        End Set
    End Property
    Public Property UserID() As String
        Get
            Return _Userid
        End Get
        Set(ByVal value As String)
            _Userid = value
        End Set
    End Property
    Public Property ARNo() As String
        Get
            Return _ARNo
        End Get
        Set(ByVal value As String)
            _ARNo = value
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

    Public Property Accountable() As String
        Get
            Return _Accountable
        End Get
        Set(ByVal value As String)
            _Accountable = value
        End Set
    End Property
    Private _cctype As String
    Public Property cctype() As String
        Get
            Return _cctype
        End Get
        Set(ByVal value As String)
            _cctype = value
        End Set
    End Property
    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView, ByVal dgsub2 As DataGridView) As Boolean
        Try
            Dim strMsg As String
            Dim com As SqlCommand
            com = New SqlCommand("SaveAR", _Connection, _Transaction)
            If isEdit Then
                strMsg = "Update AR"
            Else
                strMsg = "ADD New AR"
            End If
            With com
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@ARNo", ARNo))
                .Parameters.Add(New SqlParameter("@ARDate", _ARDate))
                .Parameters.Add(New SqlParameter("@Accountable", Accountable))
                .Parameters.Add(New SqlParameter("@UserID", UserID))
                .Parameters.Add(New SqlParameter("@DepartmentCode ", DepartmentCode))
                .Parameters.Add(New SqlParameter("@SectionCode", SectionCode))
                .Parameters.Add(New SqlParameter("@LineCode", LineCode))
                .Parameters.Add(New SqlParameter("@Total", Total))
                .ExecuteNonQuery()
            End With
            Using com1 As New SqlCommand("DELETE FROM tbl_100_AR_Sub WHERE ARNo='" & ARNo & "'", _Connection, _Transaction)
                com1.CommandType = CommandType.Text
                com1.ExecuteNonQuery()
            End Using
            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com1 As New SqlCommand("SaveAR_Sub", _Connection, _Transaction)
                        With com1
                            Dim Aunitprice As String
                            Dim Cunitprice As String
                            Aunitprice = Replace(row.Cells("colUnitPrice").Value, ",", "")
                            Cunitprice = Replace(row.Cells("colCUnitPrice").Value, ",", "")
                            Aunitprice = Replace(Aunitprice, cctype & "  ", "")
                            Cunitprice = Replace(Cunitprice, "PHP  ", "")
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@ARNo", ARNo))
                            .Parameters.Add(New SqlParameter("@WRNo", row.Cells("colWRNo").Value))
                            .Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                            .Parameters.Add(New SqlParameter("@TOCCode", row.Cells("colTOCCode").Value))
                            .Parameters.Add(New SqlParameter("@ItemCode", row.Cells("colItemCode").Value))
                            .Parameters.Add(New SqlParameter("@Quantity", Replace(row.Cells("colQty").Value, ",", "")))
                            .Parameters.Add(New SqlParameter("@Unit", row.Cells("colUnit").Value))
                            .Parameters.Add(New SqlParameter("@CurrencyType", cctype))
                            .Parameters.Add(New SqlParameter("@AUnitPrice", Aunitprice))
                            .Parameters.Add(New SqlParameter("@CUnitPrice", Cunitprice))
                            .Parameters.Add(New SqlParameter("@Date", row.Cells("colDate").Value))
                            .Parameters.Add(New SqlParameter("@UserID", row.Cells("ColIDNo").Value))
                            .Parameters.Add(New SqlParameter("@Status", row.Cells("colstatus").Value))
                            '.Parameters.Add(New SqlParameter("@RRNo", row.Cells("colName").Value))
                            .Parameters.Add(New SqlParameter("@Reference", row.Cells("colRef").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                            .ExecuteNonQuery()

                        End With
                    End Using

                    RunQuery("Update tbl_100_WR set isStatus='" & isPlaced & "'where WRNo='" & row.Cells("colWRNo").Value & "'")                
                    RunQuery("Update tbl_100_WR_Sub set isStatus='" & isDone & "' where WRNO='" & row.Cells("colWRNo").Value & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'")

                End If
            Next
            RunQuery("DELETE FROM tbl_100_AR_Member WHERE ARNo='" & ARNo & "'")

            For Each row As DataGridViewRow In dgsub2.Rows
                If row.IsNewRow = False Then
                    Using com2 As New SqlCommand("SaveAR_Member", _Connection, _Transaction)
                        With com2
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@ARNo", ARNo))
                            .Parameters.Add(New SqlParameter("@UserID", row.Cells(0).Value))
                            .ExecuteNonQuery()
                        End With
                    End Using
                    Call SaveAuditTrail("Save Accountable member Employee I.D " & row.Cells(0).Value, ARNo, True)
                End If
            Next



            Call SaveAuditTrail(strMsg, _ARNo, True)
            Return True
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Function

    
    Public Sub FetchWR(ByVal PK As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim com As New SqlCommand("Select * from tbl_100_AR where ARNo='" & PK & "'", con)
        Try
            con.Open()
            rdr = com.ExecuteReader(CommandBehavior.CloseConnection)
            While rdr.Read
                _ARNo = rdr("ARNo")
                _Accountable = rdr("Accountable")
                _Userid = rdr("UserID")
                _DepartmentCode = rdr("DepartmentCode")
                _SectionCode = rdr("SectionCode")
                _LineCode = rdr("LineCode")
                _ARDate = rdr("ARDate")
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub
End Class
