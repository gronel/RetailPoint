Imports System.Data.SqlClient
Public Class tbl_100_PO
    Private _PONo As String
    Private _DateRequested As String
    Private _SupplierID As String
    Private _SupplierType As String
    Private _DeliveryDate As String
    Private _DeliveryBy As String
    Private _PaymentTerm As String
    Private _PayablePaymentDate As String
    Private _PreparedBy As String
    Private _CheckedBy As String
    Private _ApprovedBy As String
    Private _TotalAmount As Double
    Private _Remarks As String

    Private _Currenctype As String
    Public Sub New()

    End Sub
  
    Public Property CurrencyType() As String
        Get
            Return _Currenctype
        End Get
        Set(ByVal value As String)
            _Currenctype = value
        End Set
    End Property
    Public Property PONo() As String
        Get
            Return _PONo
        End Get
        Set(ByVal value As String)
            _PONo = value
        End Set
    End Property
    Public Property DateRequested() As String
        Get
            Return _DateRequested
        End Get
        Set(ByVal value As String)
            _DateRequested = value
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
    Public Property SupplierType() As String
        Get
            Return _SupplierType
        End Get
        Set(ByVal value As String)
            _SupplierType = value
        End Set
    End Property
    Public Property DeliveryDate() As String
        Get
            Return _DeliveryDate
        End Get
        Set(ByVal value As String)
            _DeliveryDate = value
        End Set
    End Property
    Public Property DeliveryBy() As String
        Get
            Return _DeliveryBy
        End Get
        Set(ByVal value As String)
            _DeliveryBy = value
        End Set
    End Property
    Public Property PaymentTerm() As String
        Get
            Return _PaymentTerm
        End Get
        Set(ByVal value As String)
            _PaymentTerm = value
        End Set
    End Property
    Public Property PayablePaymentDate() As String
        Get
            Return _PayablePaymentDate
        End Get
        Set(ByVal value As String)
            _PayablePaymentDate = value
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
    Public Property CheckedBy() As String
        Get
            Return _CheckedBy
        End Get
        Set(ByVal value As String)
            _CheckedBy = value
        End Set
    End Property
    Public Property ApprovedBy() As String
        Get
            Return _ApprovedBy
        End Get
        Set(ByVal value As String)
            _ApprovedBy = value
        End Set
    End Property
    Public Property TotalAmount() As Double
        Get
            Return _TotalAmount
        End Get
        Set(ByVal value As Double)
            _TotalAmount = value
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
    Private _dec As Integer
    Public Property Dec() As Integer
        Get
            Return _dec
        End Get
        Set(ByVal value As Integer)
            _dec = value
        End Set
    End Property
    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean
        Try
            Dim strMsg As String
            Dim com As SqlCommand
            com = New SqlCommand("SavePO", _Connection, _Transaction)
            If isEdit Then
                strMsg = "Update PO"
            Else
                strMsg = "Add New PO"
            End If
            With com
                .CommandType = CommandType.StoredProcedure       
                .Parameters.Add(New SqlParameter("@PONo", PONo))
                .Parameters.Add(New SqlParameter("@DateRequested", DateRequested))
                .Parameters.Add(New SqlParameter("@SupplierID", SupplierID))
                .Parameters.Add(New SqlParameter("@SupplierType", SupplierType))
                .Parameters.Add(New SqlParameter("@DeliveryDate", DeliveryDate))
                .Parameters.Add(New SqlParameter("@DeliveryBy", DeliveryBy))
                .Parameters.Add(New SqlParameter("@PaymentTerm", PaymentTerm))
                .Parameters.Add(New SqlParameter("@PayablePaymentDate", PayablePaymentDate))
                .Parameters.Add(New SqlParameter("@PreparedBy", PreparedBy))
                .Parameters.Add(New SqlParameter("@ApprovedBy", ApprovedBy))
                .Parameters.Add(New SqlParameter("@CheckedBy", CheckedBy))
                .Parameters.Add(New SqlParameter("@TotalAmount", TotalAmount))
                .Parameters.Add(New SqlParameter("@Remarks", Remarks))
                .Parameters.Add(New SqlParameter("@CurrencyType", CurrencyType))
                .Parameters.Add(New SqlParameter("@isStatus", isPlaced))
                .Parameters.Add(New SqlParameter("@isReason", isNull))
                .Parameters.Add(New SqlParameter("@Dec", Dec))
                .ExecuteNonQuery()
            End With
            Using com1 As New SqlCommand("DELETE FROM tbl_100_PO_Sub Where POno='" & PONo & "'", _Connection, _Transaction)
                com1.CommandType = CommandType.Text
                com1.ExecuteNonQuery()
            End Using
            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com1 As New SqlCommand("SavePO_Sub", _Connection, _Transaction)
                        With com1
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@PONo", PONo))
                            .Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                            .Parameters.Add(New SqlParameter("@PRNo", row.Cells("colPRNo").Value))
                            .Parameters.Add(New SqlParameter("@ReqQty", CDbl(row.Cells("colQty").Value)))
                            .Parameters.Add(New SqlParameter("@ActualUnitPrice", CDbl(row.Cells("colActualPrice").Value)))
                            .Parameters.Add(New SqlParameter("@Amount", CDbl(row.Cells("colAmount").Value)))
                            .Parameters.Add(New SqlParameter("@DeliveryDate", DeliveryDate))
                            .Parameters.Add(New SqlParameter("@Status", isPlaced))
                            .Parameters.Add(New SqlParameter("@RRQTY", CDbl(row.Cells("colQty").Value)))
                            .Parameters.Add(New SqlParameter("@QTYdec", CInt(row.Cells("coldec").Value)))
                            .ExecuteNonQuery()
                        End With
                    End Using
                    RunQuery("Update tbl_100_PR_Sub set Status='" & isPlaced & "' where PRNo='" & row.Cells("colPRNo").Value & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'")
                End If
            Next

            Call SaveAuditTrail(strMsg, PONo, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Sub FetchPO(ByVal PK As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        SQL = "SELECT     PONo, DateRequested, SupplierID, SupplierType, DeliveryDate, DeliveryBy, PaymentTerm, PayablePaymentDate, PreparedBy, CheckedBy, " & _
        "ApprovedBy, TotalAmount, Remarks, CurrencyType, isStatus, isReason, Dec, rec " & _
        "FROM tbl_100_PO WHERE     (PONo = '" & PK & "')"

        Dim com As New SqlCommand(SQL, con)
        Try
            con.Open()
            rdr = com.ExecuteReader(CommandBehavior.CloseConnection)
            While rdr.Read
                _PONo = rdr("PONo")
                _DateRequested = rdr("DateRequested")
                _SupplierID = rdr("SupplierID")
                _SupplierType = rdr("SupplierType")
                _DeliveryDate = rdr("DeliveryDate")
                _DeliveryBy = rdr("DeliveryBy")
                _PaymentTerm = rdr("PaymentTerm")
                _PayablePaymentDate = rdr("PayablePaymentDate")
                _PreparedBy = rdr("PreparedBy")
                _CheckedBy = rdr("CheckedBy")
                _ApprovedBy = rdr("ApprovedBy")
                _TotalAmount = rdr("TotalAmount")
                _Remarks = rdr("Remarks")
                _Currenctype = rdr("CurrencyType")
                _dec = rdr("Dec")
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
End Class





















