Imports System.Data.SqlClient
''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class tbl_100_Order
#Region "Variable"
    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As String)
        FetchRecord(ID)
    End Sub

    Private _OrderCode As String
    Public Property OrderCode() As String
        Get
            Return _OrderCode
        End Get
        Set(ByVal value As String)
            _OrderCode = value
        End Set
    End Property

    Private _OrderType As String
    Public Property OrderType() As String
        Get
            Return _OrderType
        End Get
        Set(ByVal value As String)
            _OrderType = value
        End Set
    End Property

    Private _CustomerCode As String
    Public Property CustomerCode() As String
        Get
            Return _CustomerCode
        End Get
        Set(ByVal value As String)
            _CustomerCode = value
        End Set
    End Property

    Private _OrderDate As DateTime
    Public Property OrderDate() As DateTime
        Get
            Return _OrderDate
        End Get
        Set(ByVal value As DateTime)
            _OrderDate = value
        End Set
    End Property

    Private _ERSpecificCode As String
    Public Property ERSpecificCode() As String
        Get
            Return _ERSpecificCode
        End Get
        Set(ByVal value As String)
            _ERSpecificCode = value
        End Set
    End Property

    Private _TotalQuantity As Integer
    Public Property TotalQuantity() As Integer
        Get
            Return _TotalQuantity
        End Get
        Set(ByVal value As Integer)
            _TotalQuantity = value
        End Set
    End Property

    Private _TotalAmount As Double
    Public Property TotalAmount() As Double
        Get
            Return _TotalAmount
        End Get
        Set(ByVal value As Double)
            _TotalAmount = value
        End Set
    End Property

    Private _rate As Double
    Public Property rate() As Double
        Get
            Return _rate
        End Get
        Set(ByVal value As Double)
            _rate = value
        End Set
    End Property

    Private _ConvertedAmount As Double
    Public Property ConvertedAmount() As Double
        Get
            Return _ConvertedAmount
        End Get
        Set(ByVal value As Double)
            _ConvertedAmount = value
        End Set
    End Property

    Private _Xrate As String
    Public Property Xrate() As String
        Get
            Return _Xrate
        End Get
        Set(ByVal value As String)
            _Xrate = value
        End Set
    End Property

    Private _xratephp As String
    Public Property XratePHP() As String
        Get
            Return _xratephp
        End Get
        Set(ByVal value As String)
            _xratephp = value
        End Set
    End Property

    Private _totalPhp As Double
    Public Property totalphp() As Double
        Get
            Return _totalPhp
        End Get
        Set(ByVal value As Double)
            _totalPhp = value
        End Set
    End Property

#End Region

#Region "Method"
    Public Function Save(ByVal isEdit As Boolean, Optional ByVal dgGrid As DataGridView = Nothing) As Boolean
        Try
            Dim strMsg As String
            Using com As New SqlCommand("SaveOrder", _Connection, _Transaction)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMsg = "Update Order"
                Else
                    strMsg = "Add New Order"
                End If

                com.Parameters.Add(New SqlParameter("@OrderCode", OrderCode))
                com.Parameters.Add(New SqlParameter("@OrderType", OrderType))
                com.Parameters.Add(New SqlParameter("@CustomerCode", CustomerCode))
                com.Parameters.Add(New SqlParameter("@OrderDate", OrderDate))
                com.Parameters.Add(New SqlParameter("@OrderCurrencyType", ERSpecificCode))
                com.Parameters.Add(New SqlParameter("@TotalQty", Replace(TotalQuantity, ",", "")))
                com.Parameters.Add(New SqlParameter("@TotalAmount", TotalAmount))
                com.Parameters.Add(New SqlParameter("@Status", isUndone))
                com.Parameters.Add(New SqlParameter("@TotalConvertedAmount", CDbl(NZ(_ConvertedAmount))))
                com.Parameters.Add(New SqlParameter("@Xrate", _Xrate))
                com.Parameters.Add(New SqlParameter("@xratePHP", _xratephp))
                com.Parameters.Add(New SqlParameter("@TotalPHP", _totalPhp))

                com.ExecuteNonQuery()
            End Using


            RunQuery("DELETE FROM tbl_100_Order_Sub WHERE OrderNo = '" & OrderCode & "'")

            For Each row As DataGridViewRow In dgGrid.Rows
                If row.IsNewRow = False Then
                    Using com As New SqlCommand("SaveOrder_Sub", _Connection, _Transaction)
                        com.CommandType = CommandType.StoredProcedure
                        com.Parameters.Add(New SqlParameter("@OrderNo", OrderCode))
                        com.Parameters.Add(New SqlParameter("@ProductTOCcode", row.Cells("colTOC").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                        com.Parameters.Add(New SqlParameter("@ProductCode", row.Cells("colProductCode").Value))
                        com.Parameters.Add(New SqlParameter("@PackingStatus", row.Cells("colPacking").Value))
                        com.Parameters.Add(New SqlParameter("@QuantityBox", row.Cells("colQty").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                        com.Parameters.Add(New SqlParameter("@Quantity", CDbl(row.Cells("colQuantity").Value)))
                        com.Parameters.Add(New SqlParameter("@UnitPrice", CDbl(row.Cells("colUnitPrice").Value)))
                        com.Parameters.Add(New SqlParameter("@Amount", CDbl(row.Cells("colAmount").Value)))
                        com.Parameters.Add(New SqlParameter("@DeliveryDate", row.Cells("colDeliveryDate").Value))
                        com.Parameters.Add(New SqlParameter("@TOPDeliveryDate", row.Cells("colTOPDeliveryDate").Value))
                        com.Parameters.Add(New SqlParameter("@ReceivablePaymentDate", row.Cells("colReceivablePaymentDate").Value))
                        com.Parameters.Add(New SqlParameter("@runQTY", CDbl(row.Cells("colQuantity").Value)))
                        com.Parameters.Add(New SqlParameter("@isStatus", isProcessed))
                        com.Parameters.Add(New SqlParameter("@convertedAmount", CDbl(NZ(row.Cells("colconverted").Value))))
                        com.Parameters.Add(New SqlParameter("@convertedAmountphp", CDbl(NZ(row.Cells("colPHP").Value))))
                        com.Parameters.Add(New SqlParameter("@dec", CInt(row.Cells("coldec").Value)))
                        com.Parameters.Add(New SqlParameter("@priceID", NZ(row.Cells("colpriceID").Value)))
                        com.ExecuteNonQuery()
                    End Using
                End If
            Next


            Call SaveAuditTrail(strMsg, _OrderCode, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
            Return False
        End Try
    End Function

    Public Sub FetchRecord(ByVal strCode As String)
        Dim con As New SqlConnection(cnString)
        Dim com As New SqlCommand("select * from  tbl_100_Order where OrderNo='" & strCode & "'", con)
        Dim rdr As SqlDataReader

        Try
            con.Open()
            rdr = com.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                OrderCode = rdr("OrderNo")
                OrderType = rdr("OrderTypeCode")
                CustomerCode = rdr("CustomerCode")
                OrderDate = rdr("OrderDate")
                ERSpecificCode = rdr("OrderCurrencyType")
                _Xrate = rdr("Xrate")
                _xratephp = rdr("xratePHP")
                _totalPhp = rdr("TotalPHP")
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
        End Try
    End Sub

#End Region

End Class


''' <summary>
''' Confirmation product Delivery date
''' </summary>
''' <remarks></remarks>
Public Class tbl_100_ConfirmDateDetails

#Region "Variable"
    Private _orderno As String
    Private _productcode As String
#End Region

#Region "Property"
    Public Property Orderno() As String
        Get
            Return _orderno
        End Get
        Set(ByVal value As String)
            _orderno = value
        End Set
    End Property

    Public Property ProductCode() As String
        Get
            Return _productcode
        End Get
        Set(ByVal value As String)
            _productcode = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Function Save(ByVal dgsub As DataGridView) As Boolean

        Try

            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            RunQuery("Delete from tbl_100_ConfirmDateDetails where OrderNo='" & _orderno & "' and ProductCode='" & _productcode & "'")

            For Each row As DataGridViewRow In dgsub.Rows
                If row.IsNewRow = False Then
                    Using cmd As New SqlCommand()
                        With cmd
                            SQL = "INSERT INTO tbl_100_ConfirmDateDetails " & _
                                  "(OrderNo, ProductCode, confDate, confQTY, Remarks) " & _
                                  "VALUES     ('" & _orderno & "','" & _productcode & "','" & row.Cells(0).Value & "','" & row.Cells(1).Value & "','" & row.Cells(2).Value & "')"

                            .Connection = _Connection
                            .CommandType = CommandType.Text
                            .CommandText = SQL
                            .ExecuteNonQuery()
                        End With

                    End Using
                End If
            Next

            Return True
        Catch ex As Exception
            Return False
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        Finally
            _Connection.Close()
        End Try

    End Function

#End Region
End Class



Public Class Order_Edit




#Region "Variable"
    Public Sub New()
    End Sub

    Private _OrderCode As String
    Public Property OrderCode() As String
        Get
            Return _OrderCode
        End Get
        Set(ByVal value As String)
            _OrderCode = value
        End Set
    End Property

    Private _OrderType As String
    Public Property OrderType() As String
        Get
            Return _OrderType
        End Get
        Set(ByVal value As String)
            _OrderType = value
        End Set
    End Property

    Private _CustomerCode As String
    Public Property CustomerCode() As String
        Get
            Return _CustomerCode
        End Get
        Set(ByVal value As String)
            _CustomerCode = value
        End Set
    End Property

    Private _OrderDate As DateTime
    Public Property OrderDate() As DateTime
        Get
            Return _OrderDate
        End Get
        Set(ByVal value As DateTime)
            _OrderDate = value
        End Set
    End Property

    Private _ERSpecificCode As String
    Public Property ERSpecificCode() As String
        Get
            Return _ERSpecificCode
        End Get
        Set(ByVal value As String)
            _ERSpecificCode = value
        End Set
    End Property

    Private _TotalQuantity As Integer
    Public Property TotalQuantity() As Integer
        Get
            Return _TotalQuantity
        End Get
        Set(ByVal value As Integer)
            _TotalQuantity = value
        End Set
    End Property

    Private _TotalAmount As Double
    Public Property TotalAmount() As Double
        Get
            Return _TotalAmount
        End Get
        Set(ByVal value As Double)
            _TotalAmount = value
        End Set
    End Property

    Private _rate As Double
    Public Property rate() As Double
        Get
            Return _rate
        End Get
        Set(ByVal value As Double)
            _rate = value
        End Set
    End Property

    Private _ConvertedAmount As Double
    Public Property ConvertedAmount() As Double
        Get
            Return _ConvertedAmount
        End Get
        Set(ByVal value As Double)
            _ConvertedAmount = value
        End Set
    End Property

    Private _Xrate As String
    Public Property Xrate() As String
        Get
            Return _Xrate
        End Get
        Set(ByVal value As String)
            _Xrate = value
        End Set
    End Property

    Private _xratephp As String
    Public Property XratePHP() As String
        Get
            Return _xratephp
        End Get
        Set(ByVal value As String)
            _xratephp = value
        End Set
    End Property

    Private _totalPhp As Double
    Public Property totalphp() As Double
        Get
            Return _totalPhp
        End Get
        Set(ByVal value As Double)
            _totalPhp = value
        End Set
    End Property

#End Region

#Region "Method"
    Public Function Save(ByVal isEdit As Boolean, Optional ByVal dgGrid As DataGridView = Nothing, Optional ByVal dgTemp As DataGridView = Nothing) As Boolean
        Try
            Dim strMsg As String
            Using com As New SqlCommand("SaveOrder", _Connection, _Transaction)
                com.CommandType = CommandType.StoredProcedure
                If isEdit Then
                    strMsg = "Update Order"
                Else
                    strMsg = "Add New Order"
                End If
                com.Parameters.Add(New SqlParameter("@OrderCode", OrderCode))
                com.Parameters.Add(New SqlParameter("@OrderType", OrderType))
                com.Parameters.Add(New SqlParameter("@CustomerCode", CustomerCode))
                com.Parameters.Add(New SqlParameter("@OrderDate", OrderDate))
                com.Parameters.Add(New SqlParameter("@OrderCurrencyType", ERSpecificCode))
                com.Parameters.Add(New SqlParameter("@TotalQty", Replace(TotalQuantity, ",", "")))
                com.Parameters.Add(New SqlParameter("@TotalAmount", TotalAmount))
                com.Parameters.Add(New SqlParameter("@Status", isUndone))
                com.Parameters.Add(New SqlParameter("@TotalConvertedAmount", CDbl(NZ(_ConvertedAmount))))
                com.Parameters.Add(New SqlParameter("@Xrate", _Xrate))
                com.Parameters.Add(New SqlParameter("@xratePHP", _xratephp))
                com.Parameters.Add(New SqlParameter("@TotalPHP", _totalPhp))
                com.ExecuteNonQuery()
            End Using
            'RunQuery("DELETE FROM tbl_100_Order_Sub WHERE OrderNo = '" & OrderCode & "'")

            For Each row As DataGridViewRow In dgGrid.Rows
                If row.IsNewRow = False Then
                    If row.Cells("colLock").Value = "Lock" Then
                        Using com As New SqlCommand("sp_Update_Order", _Connection, _Transaction)
                            com.CommandType = CommandType.StoredProcedure
                            com.Parameters.Add(New SqlParameter("@OrderNo", OrderCode))
                            com.Parameters.Add(New SqlParameter("@ProductCode", row.Cells("colProductCode").Value))
                            com.Parameters.Add(New SqlParameter("@Quantity", CDbl(row.Cells("colQuantity").Value)))
                            com.Parameters.Add(New SqlParameter("@UserID", CurrUser.USER_NAME))
                            com.Parameters.Add(New SqlParameter("@Computer", ComputerName))
                            com.Parameters.Add(New SqlParameter("@Amount", CDbl(row.Cells("colAmount").Value)))
                            com.Parameters.Add(New SqlParameter("@convertedAmount", CDbl(NZ(row.Cells("colconverted").Value))))
                            com.Parameters.Add(New SqlParameter("@convertedAmountphp", CDbl(NZ(row.Cells("colPHP").Value))))
                            com.Parameters.Add(New SqlParameter("@priceID", CInt(NZ(row.Cells("colpriceID").Value))))
                            com.ExecuteNonQuery()
                        End Using
                    Else
                        Using com As New SqlCommand("SaveOrder_Sub", _Connection, _Transaction)
                            com.CommandType = CommandType.StoredProcedure
                            com.Parameters.Add(New SqlParameter("@OrderNo", OrderCode))
                            com.Parameters.Add(New SqlParameter("@ProductTOCcode", row.Cells("colTOC").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                            com.Parameters.Add(New SqlParameter("@ProductCode", row.Cells("colProductCode").Value))
                            com.Parameters.Add(New SqlParameter("@PackingStatus", row.Cells("colPacking").Value))
                            com.Parameters.Add(New SqlParameter("@QuantityBox", row.Cells("colQty").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                            com.Parameters.Add(New SqlParameter("@Quantity", CDbl(row.Cells("colQuantity").Value)))
                            com.Parameters.Add(New SqlParameter("@UnitPrice", CDbl(row.Cells("colUnitPrice").Value)))
                            com.Parameters.Add(New SqlParameter("@Amount", CDbl(row.Cells("colAmount").Value)))
                            com.Parameters.Add(New SqlParameter("@DeliveryDate", row.Cells("colDeliveryDate").Value))
                            com.Parameters.Add(New SqlParameter("@TOPDeliveryDate", row.Cells("colTOPDeliveryDate").Value))
                            com.Parameters.Add(New SqlParameter("@ReceivablePaymentDate", row.Cells("colReceivablePaymentDate").Value))
                            com.Parameters.Add(New SqlParameter("@runQTY", CDbl(row.Cells("colQuantity").Value)))
                            com.Parameters.Add(New SqlParameter("@isStatus", isProcessed))
                            com.Parameters.Add(New SqlParameter("@convertedAmount", CDbl(NZ(row.Cells("colconverted").Value))))
                            com.Parameters.Add(New SqlParameter("@convertedAmountphp", CDbl(NZ(row.Cells("colPHP").Value))))
                            com.Parameters.Add(New SqlParameter("@dec", CInt(row.Cells("coldec").Value)))
                            com.Parameters.Add(New SqlParameter("@priceID", NZ(row.Cells("colpriceID").Value)))
                            com.ExecuteNonQuery()
                        End Using
                    End If

                End If
            Next
            Return True

            RunQuery("sp_Recompute_Sales")
            RunQuery("UPDATE tbl_100_Order_Sub SET isStatus='Finished' WHERE runQTY=0 AND OrderNo='" & OrderCode & "'")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
            Return False
        End Try
    End Function

   

#End Region


End Class