Imports System.Data.SqlClient
Public Class tmp_PO
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
    Public Function Save(ByVal dgSub As DataGridView) As Boolean
        Try
            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            Dim com As SqlCommand
            com = New SqlCommand("Save_tmp_PO", _Connection)
           
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

            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com1 As New SqlCommand("Save_tmp_PO_Sub", _Connection, _Transaction)
                        With com1
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@PONo", PONo))
                            .Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                            .Parameters.Add(New SqlParameter("@PRNo", row.Cells("colPRNo").Value))
                            .Parameters.Add(New SqlParameter("@ReqQty", CDbl(row.Cells("colQty").Value)))
                            .Parameters.Add(New SqlParameter("@ActualUnitPrice", CDbl(row.Cells("colActualPrice").Value)))
                            .Parameters.Add(New SqlParameter("@Amount", CDbl(row.Cells("colAmount").Value)))
                            .ExecuteNonQuery()
                        End With
                    End Using

                End If
            Next


            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
