Imports System.Data.SqlClient
Public Class tmp_RR

    Private _RRNo As String
    Private _RRDate As String
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
    Public Property RRDate() As String
        Get
            Return _RRDate
        End Get
        Set(ByVal value As String)
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

    Public Function Save(ByVal dgSub As DataGridView) As Boolean
        Try
            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            Dim com As SqlCommand
            com = New SqlCommand("Save_tmp_RR", _Connection)

            RunQuery("DELETE from tmp_RR")
            RunQuery("DELETE  From tmp_RR_Sub")

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

          

            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
         
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com1 As New SqlCommand("Save_tmp_RR_Sub", _Connection, _Transaction)
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
                            .ExecuteNonQuery()

                        End With
                    End Using

                    'If RRType = "PO" Then
                    '    Dim GetPRNO As String = DBLookUp("Select PRNo from tbl_100_PO_sub where POno='" & RefOrderNo & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'", "PRNO")
                    '    RunQuery("Update tbl_100_PR set isLock='" & True & "' where PRNo='" & GetPRNO & "'")
                    'Else
                    '    RunQuery("Update tbl_100_PR set isLock='" & True & "' where PRNo='" & row.Cells("colJR_PR").Value & "'")
                    'End If


                End If
            Next


            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Function


        End Try
    End Function
End Class
