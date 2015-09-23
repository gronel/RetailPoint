Imports System.Data.SqlClient
''' <summary>
''' For tbl_000_Product
''' </summary>
''' <remarks></remarks>
Public Class tbl_000_Product

    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As String)
        FetchRecord(ID)
    End Sub

    Private _ProductCode As String
    Public Property ProductCode() As String
        Get
            Return _ProductCode
        End Get
        Set(ByVal value As String)
            _ProductCode = value
        End Set
    End Property

    Private _PartNo As String
    Public Property PartNo() As String
        Get
            Return _PartNo
        End Get
        Set(ByVal value As String)
            _PartNo = value
        End Set
    End Property

    Private _ProductName As String
    Public Property ProductName() As String
        Get
            Return _ProductName
        End Get
        Set(ByVal value As String)
            _ProductName = value
        End Set
    End Property

    Private _ProductType As String
    Public Property ProductType() As String
        Get
            Return _ProductType
        End Get
        Set(ByVal value As String)
            _ProductType = value
        End Set
    End Property

    Private _MaterialType As String
    Public Property MaterialType() As String
        Get
            Return _MaterialType
        End Get
        Set(ByVal value As String)
            _MaterialType = value
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

    Private _IsStatus As Boolean
    Public Property IsStatus() As Boolean
        Get
            Return _IsStatus
        End Get
        Set(ByVal value As Boolean)
            _IsStatus = value
        End Set
    End Property

    Private _Usage As String

    Public Property Usage() As String
        Get
            Return _Usage
        End Get
        Set(ByVal value As String)
            _Usage = value
        End Set
    End Property

    Private _TOC As String
    Public Property TOC() As String
        Get
            Return _TOC
        End Get
        Set(ByVal value As String)
            _TOC = value
        End Set
    End Property

    Private _InternalSupplier As String
    Public Property InternalSupplier() As String
        Get
            Return _InternalSupplier
        End Get
        Set(ByVal value As String)
            _InternalSupplier = value
        End Set
    End Property

    Private _ProductModel As String
    Public Property ProductModel() As String
        Get
            Return _ProductModel
        End Get
        Set(ByVal value As String)
            _ProductModel = value
        End Set
    End Property
    Public Function Save(ByVal isEdit As Boolean, Optional ByVal dgGridSub As DataGridView = Nothing, _
                         Optional ByVal dgGridParts As DataGridView = Nothing, Optional ByVal dgGridMaterials As DataGridView = Nothing) As Boolean
        Try
            Dim strMsg As String
            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            Using com As New SqlCommand("SaveProduct", _Connection)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMsg = "Update Product"
                Else
                    strMsg = "Add New Product"
                End If
                With com
                    .Parameters.Add(New SqlParameter("@ProductCode", ProductCode))
                    .Parameters.Add(New SqlParameter("@PartNo", PartNo))
                    .Parameters.Add(New SqlParameter("@ProductName", ProductName))
                    .Parameters.Add(New SqlParameter("@ProductType", ProductType))
                    .Parameters.Add(New SqlParameter("@CustomerCode", CustomerCode))
                    .Parameters.Add(New SqlParameter("@IsStatus", IsStatus))
                    .Parameters.Add(New SqlParameter("@Usage", Usage))
                    .Parameters.Add(New SqlParameter("@InternalSupplierID", InternalSupplier))
                    .Parameters.Add(New SqlParameter("@ProductModel", ProductModel))

                    .ExecuteNonQuery()
                End With

            End Using

            ''save product sub
            If Not dgGridSub Is Nothing Then
                Using com As New SqlCommand("DELETE FROM tbl_000_Product_Sub WHERE ProductCode = '" & ProductCode & "'", _Connection, _Transaction)
                    com.CommandType = CommandType.Text
                    com.ExecuteNonQuery()
                End Using

                For Each row As DataGridViewRow In dgGridSub.Rows
                    If row.IsNewRow = False Then
                        Using com As New SqlCommand("SaveProductSub", _Connection)
                            com.CommandType = CommandType.StoredProcedure
                            com.Parameters.Add(New SqlParameter("@ProductCode", ProductCode))
                            com.Parameters.Add(New SqlParameter("@EffectiveDate", row.Cells("colEffectiveDate1").Value))
                            com.Parameters.Add(New SqlParameter("@CurrencyType", row.Cells("colCurrency").Value))
                            com.Parameters.Add(New SqlParameter("@UnitPrice", FormatNumber(CDbl(Replace(row.Cells("colUnitPrice").Value, ",", "")), CInt(row.Cells("coldec").Value))))
                            com.Parameters.Add(New SqlParameter("@Unit", row.Cells("colUnit").Value))
                            com.Parameters.Add(New SqlParameter("@isStatus", row.Cells("colStatus").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                            com.Parameters.Add(New SqlParameter("@dec", row.Cells("coldec").Value))
                            com.Parameters.Add(New SqlParameter("@priceID", NZ(row.Cells("colpriceID").Value)))
                            com.ExecuteNonQuery()
                        End Using
                    End If
                Next
            End If

            ''save product parts
            If Not dgGridParts Is Nothing Then
                Using com As New SqlCommand("DELETE FROM tbl_000_Product_Parts WHERE ProductCode = '" & ProductCode & "'", _Connection)
                    com.CommandType = CommandType.Text
                    com.ExecuteNonQuery()
                End Using

                For Each row As DataGridViewRow In dgGridParts.Rows
                    If Not row.IsNewRow Then
                        Using com As New SqlCommand("SaveProductPartsAndMaterials", _Connection)
                            com.CommandType = CommandType.StoredProcedure
                            com.Parameters.Add(New SqlParameter("@ProductCode", ProductCode))
                            com.Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colItemSpecificCode").Value))
                            com.Parameters.Add(New SqlParameter("@Currency", row.Cells("colmaterialCtype").Value))
                            com.Parameters.Add(New SqlParameter("@ActualUnitPrice", NZ(row.Cells("colPartsUnitPrice").Value)))
                            com.Parameters.Add(New SqlParameter("@Quantity", NZ(row.Cells("colQuantity").Value)))
                            com.Parameters.Add(New SqlParameter("@ExrateDescription", row.Cells("colCode").Value))
                            com.Parameters.Add(New SqlParameter("@ConvertUnitPrice", CDbl(NZ(row.Cells("colconprice").Value))))
                            com.ExecuteNonQuery()
                        End Using
                    End If
                Next
            End If

            Call SaveAuditTrail(strMsg, _ProductCode, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
            Return False
        Finally
            _Connection.Close()
        End Try
    End Function

    Public Sub FetchRecord(ByVal strProductCode As String)
        Dim con As New SqlConnection(cnString)
        Dim cmd As New SqlCommand("SELECT ProductCode,PartNo,ProductName,ProductType,Usage,CustomerCode,IsStatus ,InternalSupplierID ,ProductModel FROM tbl_000_Product WHERE ProductCode='" & strProductCode & "'", con)
        Dim myrdr As SqlDataReader

        Try
            con.Open()
            myrdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While myrdr.Read
                ProductCode = myrdr("ProductCode")
                PartNo = myrdr("PartNo")
                ProductName = myrdr("ProductName")
                ProductType = myrdr("ProductType")
                Usage = myrdr("Usage")
                CustomerCode = myrdr("CustomerCode")
                IsStatus = myrdr("IsStatus")
                InternalSupplier = myrdr("InternalSupplierID")
                ProductModel = myrdr("ProductModel")
            End While

            myrdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub

End Class


''' <summary>
''' For tbl_000_Selling
''' </summary>
''' <remarks></remarks>
Public Class tbl_000_Selling
    Private _SellingCode As String, _SellingDate As Date

    Public Property SellingCode() As String
        Get
            Return _SellingCode
        End Get
        Set(ByVal value As String)
            _SellingCode = value
        End Set
    End Property

    Public Property SellingDate() As Date
        Get
            Return _SellingDate
        End Get
        Set(ByVal value As Date)
            _SellingDate = value
        End Set
    End Property

#Region " Methods "

    Public Function Save(ByVal dgsub As DataGridView) As Boolean

        Try

            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            RunQuery("Delete from tbl_000_Product_Selling where SellingCode='" & SellingCode & "' and SellingDate='" & SellingDate & "'")
            For Each row As DataGridViewRow In dgsub.Rows
                If row.IsNewRow = False Then
                    Using com As New SqlCommand("Save_tbl_000_Selling", _Connection)
                        com.CommandType = CommandType.StoredProcedure
                        com.Parameters.Add(New SqlParameter("@SellingCode", SellingCode))
                        com.Parameters.Add(New SqlParameter("@SellingDate", SellingDate))
                        com.Parameters.Add(New SqlParameter("@SellingSpecificCode", row.Cells("colSellingSpecificcode").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                        com.Parameters.Add(New SqlParameter("@SellingQTY", CDbl(row.Cells("colSellingQTY").Value)))
                        com.Parameters.Add(New SqlParameter("@SellingUnit", row.Cells("ColSellingUnit").Value))
                        com.Parameters.Add(New SqlParameter("@SellingActPrice", CDbl(NZ(row.Cells("colsellingUnitPrice").Value))))
                        com.Parameters.Add(New SqlParameter("@SellingXratecode", row.Cells("colsellingExCode").Value))
                        com.Parameters.Add(New SqlParameter("@SellingConvertedPrice", CDbl(NZ(row.Cells("colsellingConUnitPrice").Value))))
                        com.Parameters.Add(New SqlParameter("@SellingCurrency", row.Cells("colsellingCtype").Value))
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


''' <summary>
''' For tbl_000_Product_Process
''' </summary>
''' <remarks></remarks>
Public Class tbl_000_Product_Process


#Region " Methods "

    Private _ProcessCode As String
    Private _ProcessDate As Date

    Public Property ProcessCode() As String
        Get
            Return _ProcessCode
        End Get
        Set(ByVal value As String)
            _ProcessCode = value
        End Set
    End Property

    Public Property ProcessDate() As Date
        Get
            Return _ProcessDate
        End Get
        Set(ByVal value As Date)
            _ProcessDate = value
        End Set
    End Property

    Public Function Save(ByVal dgsub As DataGridView) As Boolean

        Try

            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()
            RunQuery("Delete from tbl_000_Product_Process where ProcessCode='" & _ProcessCode & "' and ProcessDate='" & _ProcessDate & "'")
            For Each row As DataGridViewRow In dgsub.Rows
                If row.IsNewRow = False Then
                    Using com As New SqlCommand("Save_tbl_000_Product_Process", _Connection)
                        com.CommandType = CommandType.StoredProcedure
                        com.Parameters.Add(New SqlParameter("@ProcessCode", _ProcessCode))
                        com.Parameters.Add(New SqlParameter("@ProcessDate", _ProcessDate))
                        com.Parameters.Add(New SqlParameter("@ProcessDescription", row.Cells("colProcessDescription").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                        com.Parameters.Add(New SqlParameter("@ProcessCurrencyType", row.Cells("colProcessCurrency").Value))
                        com.Parameters.Add(New SqlParameter("@ProcessAmt", CDbl(row.Cells("colProcessAMT").Value)))
                        com.Parameters.Add(New SqlParameter("@ProcessXrate", row.Cells("colExrate").Value))
                        com.Parameters.Add(New SqlParameter("@ProcessConvertedAMT", CDbl(row.Cells("colProcessAmount").Value)))
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

    Public Sub FetchProcess(ByVal dgsub As DataGridView, ByVal dgsub2 As DataGridView, ByVal ProcessCode As String, ByVal ProcessDate As Date)
        ''Fitch part and componet
        FillDataGrid(dgsub2, "sp_Product_Fetch_Selling '" & ProcessCode & "','" & ProcessDate & "'", 0, 10)
        ''Fill Process
        FillDataGrid(dgsub, "SELECT     tbl_000_Product_Process.ProcessDescription, tbl_000_Product_Process.ProcessCurrencyType, tbl_000_Product_Process.ProcessAmt, " & _
                            "tbl_000_Product_Process.ProcessXrate, tbl_Status.Description, tbl_000_ExchangeRate_Sub.ExrateValue, " & _
                            "tbl_000_Product_Process.ProcessConvertedAMT " & _
                            "FROM         tbl_000_Product_Process INNER JOIN " & _
                            "tbl_000_ExchangeRate_Sub ON tbl_000_Product_Process.ProcessXrate = tbl_000_ExchangeRate_Sub.ExrateDetailedCode INNER JOIN " & _
                            "tbl_000_ExchangeRate ON tbl_000_ExchangeRate_Sub.code = tbl_000_ExchangeRate.Exratecode INNER JOIN " & _
                            "tbl_Status ON tbl_000_ExchangeRate.Currencyconversion = tbl_Status.StatusID " & _
                            "WHERE     (tbl_000_Product_Process.ProcessDate = '" & ProcessDate & "') AND (tbl_000_Product_Process.ProcessCode = '" & ProcessCode & "')", 0, 6)
    End Sub

#End Region




End Class



Public Class EditUnitPrice

    Implements IDisposable


    Private _unitprice As Double
    Private _dec As Integer
    Private _productcode As String
    Private _priceid As Integer

    
    Public Property productcode() As String
        Get
            Return _productcode
        End Get
        Set(ByVal value As String)
            _productcode = value
        End Set
    End Property

    Public Property priceid() As Integer
        Get
            Return _priceid
        End Get
        Set(ByVal value As Integer)
            _priceid = value
        End Set
    End Property

    Public Property unitprice() As Double
        Get
            Return _unitprice
        End Get
        Set(ByVal value As Double)
            _unitprice = value
        End Set
    End Property

    Public Property dec() As Integer
        Get
            Return _dec
        End Get
        Set(ByVal value As Integer)
            _dec = value
        End Set
    End Property

    Public Function SaveEditUnitPrice() As Boolean
        Try
            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            Using com As New SqlCommand("sp_updateProductUnitprice", _Connection)
                With com
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@unitprice", _unitprice))
                    .Parameters.Add(New SqlParameter("@priceID", _priceid))
                    .Parameters.Add(New SqlParameter("@productcode", _productcode))
                    .Parameters.Add(New SqlParameter("@dec", _dec))
                    .ExecuteNonQuery()
                End With
            End Using
            SaveAuditTrail("update unitprice from priceID " & _priceid, _productcode)
            SaveEditUnitPrice = True
        Catch ex As Exception
            SaveEditUnitPrice = False
            MsgBox("Error: SaveEditUnitPrice -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        Finally
            _Connection.Close()
        End Try
    End Function

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class