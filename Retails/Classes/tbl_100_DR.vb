Imports System.Data.SqlClient
Imports Retails.clsPublic
Public Class tbl_100_DR

#Region " Private variables "

    Private _DRNo As String
    Private _DRDate As Date
    Private _CustomerCode As String
    Private _DRType As String
    Private _Remarks As String
    Private _ReceivablePaymentDate As Date
    Private _TotalQuantity As Integer
    Private _TotalAmount As Double
    Private _DeliveredBy As String
    Private _DRcurrencytype As String
#End Region

#Region " Properties "

    Public Property DRcurrencyType() As String
        Get
            Return _DRcurrencytype
        End Get
        Set(ByVal value As String)
            _DRcurrencytype = value
        End Set
    End Property

    Public Property DRNo() As String
        Get
            Return _DRNo
        End Get
        Set(ByVal Value As String)
            _DRNo = Value
        End Set
    End Property

    Public Property DRDate() As Date
        Get
            Return _DRDate
        End Get
        Set(ByVal Value As Date)
            _DRDate = Value
        End Set
    End Property

    Public Property CustomerCode() As String
        Get
            Return _CustomerCode
        End Get
        Set(ByVal Value As String)
            _CustomerCode = Value
        End Set
    End Property

    Public Property DRType() As String
        Get
            Return _DRType
        End Get
        Set(ByVal Value As String)
            _DRType = Value
        End Set
    End Property

    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal Value As String)
            _Remarks = Value
        End Set
    End Property

    Public Property ReceivablePaymentDate() As Date
        Get
            Return _ReceivablePaymentDate
        End Get
        Set(ByVal Value As Date)
            _ReceivablePaymentDate = Value
        End Set
    End Property

    Public Property TotalQuantity() As Integer
        Get
            Return _TotalQuantity
        End Get
        Set(ByVal Value As Integer)
            _TotalQuantity = Value
        End Set
    End Property

    Public Property TotalAmount() As Double
        Get
            Return _TotalAmount
        End Get
        Set(ByVal Value As Double)
            _TotalAmount = Value
        End Set
    End Property

    Public Property DeliveredBy() As String
        Get
            Return _DeliveredBy
        End Get
        Set(ByVal Value As String)
            _DeliveredBy = Value
        End Set
    End Property


#End Region

#Region " Methods "

    Public Function Save(ByVal mystate As FormState, ByVal dgsub As DataGridView) As Boolean

        Try

            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            ''--> Save DR mainDetails
            Using com As New SqlCommand("Save_tbl_100_DR", _Connection)
                com.CommandType = CommandType.StoredProcedure
                com.Parameters.Add(New SqlParameter("@DRNo", DRNo))
                com.Parameters.Add(New SqlParameter("@DRDate", DRDate))
                com.Parameters.Add(New SqlParameter("@CustomerCode", CustomerCode))
                com.Parameters.Add(New SqlParameter("@DRType", DRType))
                com.Parameters.Add(New SqlParameter("@Remarks", Remarks))
                com.Parameters.Add(New SqlParameter("@ReceivablePaymentDate", ReceivablePaymentDate))
                com.Parameters.Add(New SqlParameter("@TotalQuantity", TotalQuantity))
                com.Parameters.Add(New SqlParameter("@TotalAmount", TotalAmount))
                com.Parameters.Add(New SqlParameter("@DeliveredBy", DeliveredBy))
                com.Parameters.Add(New SqlParameter("@DRcurrencytype", DRcurrencyType))
                com.Parameters.Add(New SqlParameter("@Status", isPlaced))
                com.ExecuteNonQuery()
            End Using

            RunQuery("Delete from tbl_100_DR_Sub where DRNo='" & DRNo & "'")

            ''--> Save DR Sub Details
            For Each row As DataGridViewRow In dgsub.Rows
                If row.IsNewRow = False Then
                    Using com As New SqlCommand("Save_tbl_100_DR_Sub", _Connection)
                        com.CommandType = CommandType.StoredProcedure
                        com.Parameters.Add(New SqlParameter("@DRNo", DRNo))
                        com.Parameters.Add(New SqlParameter("@OrderNo", row.Cells("colOrderNo").Value))
                        com.Parameters.Add(New SqlParameter("@ProductCode", row.Cells("colProductCode").Value))
                        com.Parameters.Add(New SqlParameter("@Quantity", CDbl(row.Cells("colQuantity").Value)))
                        com.Parameters.Add(New SqlParameter("@UnitPrice", CDbl(row.Cells("colUnitPrice").Value)))
                        com.Parameters.Add(New SqlParameter("@Amount", CDbl(row.Cells("colAmount").Value)))
                        com.Parameters.Add(New SqlParameter("@dec", NZ(row.Cells("coldec").Value)))
                        com.Parameters.Add(New SqlParameter("@priceid", NZ(row.Cells("colPriceID").Value)))
                        com.ExecuteNonQuery()
                    End Using
                End If
            Next

            Return True


            Call SaveAuditTrail("Save", DRNo, True)
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
            Return False

        Finally

            RunQuery("sp_Recompute_Sales")
            _Connection.Close()
        End Try

    End Function

#End Region

    Public Sub FetchRecord(ByVal strCode As String)
        Dim con As New SqlConnection(cnString)
        Dim com As New SqlCommand("Select * from tbl_100_DR where DRno='" & strCode & "'", con)
        Dim rdr As SqlDataReader

        Try
            con.Open()
            rdr = com.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                DRNo = rdr("DRNo")
                DRDate = rdr("DRDate")
                CustomerCode = rdr("CustomerCode")
                DRType = rdr("DRType")
                Remarks = rdr("Remarks")
                ReceivablePaymentDate = rdr("ReceivablePaymentDate")
                TotalQuantity = rdr("TotalQuantity")
                TotalAmount = rdr("TotalAmount")
                DeliveredBy = rdr("DeliveredBy")
                DRcurrencyType = rdr("DRcurrencytype")
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
        Finally
            con.Close()
        End Try
    End Sub

    Public Function UpdateOrder(ByVal DRNO As String, ByVal dgGrid As DataGridView, ByVal bolstate As FormState) As Boolean
        Dim runQTY As Double
        Dim OrderQTY As Double
        Dim TempTotalQTY As Double
        Dim TempDRQTY As Double
        Dim tempOrderQTY As Double
        Try
            For Each row As DataGridViewRow In dgGrid.Rows
                If row.IsNewRow = False Then

                    Select Case bolstate
                        Case FormState.AddState
                            TempDRQTY = CDbl(NZ(DBLookUp("SELECT     SUM(Quantity) AS Quantity " & _
                                                                  "FROM tbl_100_DR_Sub " & _
                                                                  "WHERE     (OrderNo = '" & row.Cells("colOrderNo").Value & "') AND (ProductCode = '" & row.Cells("colProductCode").Value & "')", "Quantity")))

                            OrderQTY = CDbl(NZ(DBLookUp("Select Quantity from tbl_100_Order_Sub where OrderNo='" & row.Cells("colOrderNo").Value & "' and ProductCode='" & row.Cells("colProductCode").Value & "'", "Quantity")))
                            runQTY = CDbl(NZ(DBLookUp("Select runQTY from tbl_100_Order_Sub where OrderNo='" & row.Cells("colOrderNo").Value & "' and ProductCode='" & row.Cells("colProductCode").Value & "'", "runQTY")))
                            TempTotalQTY = FormatNumber(runQTY - Val(row.Cells("colQuantity").Value), 2)

                            RunQuery("UPdate tbl_100_Order_Sub set RunQTY='" & TempTotalQTY & "' where OrderNo='" & row.Cells("colOrderNo").Value & "' and ProductCode='" & row.Cells("colProductCode").Value & "'")

                            TempDRQTY = FormatNumber(TempDRQTY + CDbl(NZ(row.Cells("colQuantity").Value)), 2)

                            If OrderQTY = TempDRQTY Then
                                RunQuery("UPdate  tbl_100_Order_Sub set isStatus='" & isFinished & "' where OrderNo='" & row.Cells("colOrderNo").Value & "' and ProductCode='" & row.Cells("colProductCode").Value & "'")
                            Else
                                RunQuery("UPdate  tbl_100_Order_Sub set isStatus='" & isProcessed & "' where OrderNo='" & row.Cells("colOrderNo").Value & "' and ProductCode='" & row.Cells("colProductCode").Value & "'")
                            End If

                        Case FormState.EditState
                            Dim checkInProduct As String
                            '1.check if the product is exist in DR table
                            checkInProduct = DBLookUp("SELECT     tbl_100_DR_Sub.ProductCode " & _
                            "FROM tbl_100_DR INNER JOIN tbl_100_DR_Sub ON tbl_100_DR.DRNo = tbl_100_DR_Sub.DRNo " & _
                            "WHERE     (tbl_100_DR.Status <> N'CANCELLED') AND (tbl_100_DR_Sub.ProductCode = '" & row.Cells("colProductCode").Value & "') AND (tbl_100_DR_Sub.OrderNo = '" & row.Cells("colOrderNo").Value & "') and (tbl_100_DR.DRNo = '" & DRNO & "')", "ProductCode")

                            If checkInProduct = String.Empty Then
                                newEdit(row.Cells("colQuantity").Value, row.Cells("colOrderNo").Value, row.Cells("colProductCode").Value)
                            Else

                                '1. select original Quantity of the product
                                OrderQTY = CDbl(NZ(DBLookUp("Select Quantity from tbl_100_Order_Sub where OrderNo='" & row.Cells("colOrderNo").Value & "' and ProductCode='" & row.Cells("colProductCode").Value & "'", "Quantity")))
                                '2. Get the running balance of the product
                                tempOrderQTY = CDbl(NZ(DBLookUp("Select runQTY from tbl_100_Order_Sub where OrderNo='" & row.Cells("colOrderNo").Value & "' and ProductCode='" & row.Cells("colProductCode").Value & "'", "runQTY")))
                                '3. Get the Quantity of the DR transaction in specific Product
                                TempDRQTY = CDbl(NZ(DBLookUp("SELECT     SUM(tbl_100_DR_Sub.Quantity) AS Quantity " & _
                                                                "FROM         tbl_100_DR_Sub INNER JOIN " & _
                                                                "tbl_100_DR ON tbl_100_DR_Sub.DRNo = tbl_100_DR.DRNo " & _
                                                                "WHERE     (tbl_100_DR.Status <> N'CANCELLED') and " & _
                                                             "   (tbl_100_DR_Sub.OrderNo = '" & row.Cells("colOrderNo").Value & "') AND (tbl_100_DR_Sub.ProductCode = '" & row.Cells("colProductCode").Value & "') AND (tbl_100_DR_Sub.DRNo = '" & DRNO & "')", "Quantity")))

                                tempOrderQTY = tempOrderQTY + TempDRQTY
                                TempTotalQTY = tempOrderQTY - Val(row.Cells("colQuantity").Value)
                                RunQuery("UPdate tbl_100_Order_Sub set RunQTY='" & TempTotalQTY & "' where OrderNo='" & row.Cells("colOrderNo").Value & "' and ProductCode='" & row.Cells("colProductCode").Value & "'")

                              
                                If TempTotalQTY = 0 Then
                                    RunQuery("UPdate  tbl_100_Order_Sub set isStatus='" & isFinished & "' where OrderNo='" & row.Cells("colOrderNo").Value & "' and ProductCode='" & row.Cells("colProductCode").Value & "'")
                                Else
                                    RunQuery("UPdate  tbl_100_Order_Sub set isStatus='" & isProcessed & "' where OrderNo='" & row.Cells("colOrderNo").Value & "' and ProductCode='" & row.Cells("colProductCode").Value & "'")
                                End If
                            End If
                    End Select

                    RunQuery("Update tbl_100_Order set Status='" & isnoUpdate & "' where OrderNO='" & row.Cells("colOrderNo").Value & "'")

                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
            Return False

        End Try
    End Function


    Private Sub newEdit(ByVal isQTY As Double, ByVal isOrderNo As String, ByVal isProductCode As String)
        Dim runQTY As Double
        Dim OrderQTY As Double
        Dim TempTotalQTY As Double
        Dim TempDRQTY As Double

        TempDRQTY = CDbl(NZ(DBLookUp("SELECT     SUM(Quantity) AS Quantity " & _
                                                                  "FROM tbl_100_DR_Sub " & _
                                                                  "WHERE     (OrderNo = '" & isOrderNo & "') AND (ProductCode = '" & isProductCode & "')", "Quantity")))

        OrderQTY = CDbl(NZ(DBLookUp("Select Quantity from tbl_100_Order_Sub where OrderNo='" & isOrderNo & "' and ProductCode='" & isProductCode & "'", "Quantity")))
        runQTY = CDbl(NZ(DBLookUp("Select runQTY from tbl_100_Order_Sub where OrderNo='" & isOrderNo & "' and ProductCode='" & isProductCode & "'", "runQTY")))
        TempTotalQTY = FormatNumber(runQTY - Val(isQTY), 2)

        RunQuery("UPdate tbl_100_Order_Sub set RunQTY='" & TempTotalQTY & "' where OrderNo='" & isOrderNo & "' and ProductCode='" & isProductCode & "'")

        TempDRQTY = FormatNumber(TempDRQTY + CDbl(NZ(isQTY)), 2)

        If OrderQTY = TempDRQTY Then
            RunQuery("UPdate  tbl_100_Order_Sub set isStatus='" & isFinished & "' where OrderNo='" & isOrderNo & "' and ProductCode='" & isProductCode & "'")
        Else
            RunQuery("UPdate  tbl_100_Order_Sub set isStatus='" & isProcessed & "' where OrderNo='" & isOrderNo & "' and ProductCode='" & isProductCode & "'")
        End If

    End Sub
End Class


Public Class clstmp_DR

#Region " Private variables "

    Private _DRNo As String
    Private _DRDate As Date
    Private _CustomerCode As String
    Private _DRType As String
    Private _Remarks As String
    Private _ReceivablePaymentDate As Date
    Private _TotalQuantity As Integer
    Private _TotalAmount As Double
    Private _DeliveredBy As String

#End Region

#Region " Properties "

    Public Property DRNo() As String
        Get
            Return _DRNo
        End Get
        Set(ByVal Value As String)
            _DRNo = Value
        End Set
    End Property

    Public Property DRDate() As Date
        Get
            Return _DRDate
        End Get
        Set(ByVal Value As Date)
            _DRDate = Value
        End Set
    End Property

    Public Property CustomerCode() As String
        Get
            Return _CustomerCode
        End Get
        Set(ByVal Value As String)
            _CustomerCode = Value
        End Set
    End Property

    Public Property DRType() As String
        Get
            Return _DRType
        End Get
        Set(ByVal Value As String)
            _DRType = Value
        End Set
    End Property

    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal Value As String)
            _Remarks = Value
        End Set
    End Property

    Public Property ReceivablePaymentDate() As Date
        Get
            Return _ReceivablePaymentDate
        End Get
        Set(ByVal Value As Date)
            _ReceivablePaymentDate = Value
        End Set
    End Property

    Public Property TotalQuantity() As Integer
        Get
            Return _TotalQuantity
        End Get
        Set(ByVal Value As Integer)
            _TotalQuantity = Value
        End Set
    End Property

    Public Property TotalAmount() As Double
        Get
            Return _TotalAmount
        End Get
        Set(ByVal Value As Double)
            _TotalAmount = Value
        End Set
    End Property

    Public Property DeliveredBy() As String
        Get
            Return _DeliveredBy
        End Get
        Set(ByVal Value As String)
            _DeliveredBy = Value
        End Set
    End Property


#End Region

#Region " Methods "

    Public Function Save(ByVal mystate As FormState, ByVal dgsub As DataGridView) As Boolean

        Try



            RunQuery("Delete from tmp_DR where DRNo='" & DRNo & "'")
            RunQuery("Delete from tmp_DR_Sub where DRNo='" & DRNo & "'")

            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            ''--> Save DR mainDetails
            Using com As New SqlCommand("sp_Save_DR_temp", _Connection)
                com.CommandType = CommandType.StoredProcedure
                com.Parameters.Add(New SqlParameter("@DRNo", DRNo))
                com.Parameters.Add(New SqlParameter("@DRDate", DRDate))
                com.Parameters.Add(New SqlParameter("@CustomerCode", CustomerCode))
                com.Parameters.Add(New SqlParameter("@DRType", DRType))
                com.Parameters.Add(New SqlParameter("@Remarks", Remarks))
                com.Parameters.Add(New SqlParameter("@ReceivablePaymentDate", ReceivablePaymentDate))
                com.Parameters.Add(New SqlParameter("@TotalQuantity", TotalQuantity))
                com.Parameters.Add(New SqlParameter("@TotalAmount", TotalAmount))
                com.Parameters.Add(New SqlParameter("@DeliveredBy", DeliveredBy))
                com.ExecuteNonQuery()
            End Using

            RunQuery("Delete from tbl_100_DR_Sub where DRNo='" & DRNo & "'")

            ''--> Save DR Sub Details
            For Each row As DataGridViewRow In dgsub.Rows
                If row.IsNewRow = False Then
                    Using com As New SqlCommand("sp_Save_DRSub_Temp", _Connection)
                        com.CommandType = CommandType.StoredProcedure
                        com.Parameters.Add(New SqlParameter("@DRNo", DRNo))
                        com.Parameters.Add(New SqlParameter("@OrderNo", row.Cells("colOrderNo").Value))
                        com.Parameters.Add(New SqlParameter("@ProductCode", row.Cells("colProductCode").Value))
                        com.Parameters.Add(New SqlParameter("@Quantity", CDbl(row.Cells("colQuantity").Value)))
                        com.Parameters.Add(New SqlParameter("@UnitPrice", CDbl(row.Cells("colUnitPrice").Value)))
                        com.Parameters.Add(New SqlParameter("@Amount", CDbl(row.Cells("colAmount").Value)))
                        com.Parameters.Add(New SqlParameter("@dec", NZ(row.Cells("coldec").Value)))
                        com.ExecuteNonQuery()
                    End Using
                End If
            Next









            Return True
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
            Return False

        Finally
            _Connection.Close()
        End Try

    End Function

#End Region
End Class