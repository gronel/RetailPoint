Imports System.Data.SqlClient
Imports System.IO
Public Class tbl_000_Item
    Public Sub New()
    End Sub

	Private _ItemId As Integer
    Private _ItemCode As String
    Private _ItemName As String
    Private _ItemDescription As String
    Private _LocationId As Integer
    Private _ItemCategoryId As Integer
    Private _BrandType As String
    Private _UOM As String
    Private _StockLevelQTY As Integer
    Private _StackOH As Decimal
    Private _isActive As Boolean
    Private _ItemImg As Byte()
    Private _CreateBy As String
    Private _CreateDte As Date
    Private _CostPrice As Decimal
    Private _SellingPrice As Decimal
    Private _ModifyBy As String
    Private _ModifyDte As Date
    Private _IsConverted As Boolean
    Public Property IsConverted() As Boolean
        Get
            Return _IsConverted
        End Get
        Set(ByVal value As Boolean)
            _IsConverted = value
        End Set
    End Property


    Public Property ItemId() As Integer
        Get
            Return _ItemId
        End Get
        Set(ByVal value As Integer)
            _ItemId = value
        End Set
    End Property

    Public Property ItemCode() As String
        Get
            Return _ItemCode
        End Get
        Set(ByVal value As String)
            _ItemCode = value
        End Set
    End Property

    Public Property ItemName() As String
        Get
            Return _ItemName
        End Get
        Set(ByVal value As String)
            _ItemName = value
        End Set
    End Property

    Public Property ItemDescription() As String
        Get
            Return _ItemDescription
        End Get
        Set(ByVal value As String)
            _ItemDescription = value
        End Set
    End Property

    Public Property LocationId() As Integer
        Get
            Return _LocationId
        End Get
        Set(ByVal value As Integer)
            _LocationId = value
        End Set
    End Property

    Public Property ItemCategoryId() As Integer
        Get
            Return _ItemCategoryId
        End Get
        Set(ByVal value As Integer)
            _ItemCategoryId = value
        End Set
    End Property

    Public Property BrandType() As String
        Get
            Return _BrandType
        End Get
        Set(ByVal value As String)
            _BrandType = value
        End Set
    End Property

    Public Property UOM() As String
        Get
            Return _UOM
        End Get
        Set(ByVal value As String)
            _UOM = value
        End Set
    End Property

    Public Property StockLevelQTY() As Integer
        Get
            Return _StockLevelQTY
        End Get
        Set(ByVal value As Integer)
            _StockLevelQTY = value
        End Set
    End Property

    Public Property StackOH() As Decimal
        Get
            Return _StackOH
        End Get
        Set(ByVal value As Decimal)
            _StackOH = value
        End Set
    End Property

    Public Property isActive() As Boolean
        Get
            Return _isActive
        End Get
        Set(ByVal value As Boolean)
            _isActive = value
        End Set
    End Property

    Public Property ItemImg() As Byte()
        Get
            Return _ItemImg
        End Get
        Set(ByVal value As Byte())
            _ItemImg = value
        End Set
    End Property

    Public Property CreateBy() As String
        Get
            Return _CreateBy
        End Get
        Set(ByVal value As String)
            _CreateBy = value
        End Set
    End Property

    Public Property CreateDte() As Date
        Get
            Return _CreateDte
        End Get
        Set(ByVal value As Date)
            _CreateDte = value
        End Set
    End Property
    Public Property CostPrice() As Decimal
        Get
            Return _CostPrice
        End Get
        Set(ByVal value As Decimal)
            _CostPrice = value
        End Set
    End Property

    Public Property SellingPrice() As Decimal
        Get
            Return _SellingPrice
        End Get
        Set(ByVal value As Decimal)
            _SellingPrice = value
        End Set
    End Property

    Public Property ModifyBy() As String
        Get
            Return _ModifyBy
        End Get
        Set(ByVal value As String)
            _ModifyBy = value
        End Set
    End Property

    Public Property ModifyDte() As Date
        Get
            Return _ModifyDte
        End Get
        Set(ByVal value As Date)
            _ModifyDte = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean) As Boolean
        Try
            Dim strMSG As String

            If isEdit Then
                strMSG = "Update Item"
            Else
                strMSG = "Add New Item"
            End If

            Using cmd As New SqlCommand("sproc_000_item", _Connection, _Transaction)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@ItemId", _ItemId))
                    .Parameters.Add(New SqlParameter("@ItemCode", _ItemCode))
                    .Parameters.Add(New SqlParameter("@ItemName", _ItemName))
                    .Parameters.Add(New SqlParameter("@ItemDescription", _ItemDescription))
                    .Parameters.Add(New SqlParameter("@LocationId", _LocationId))
                    .Parameters.Add(New SqlParameter("@ItemCategoryId", _ItemCategoryId))
                    .Parameters.Add(New SqlParameter("@BrandType", _BrandType))
                    .Parameters.Add(New SqlParameter("@UOM", _UOM))
                    .Parameters.Add(New SqlParameter("@StockLevelQTY", _StockLevelQTY))
                    .Parameters.Add(New SqlParameter("@StackOH", _StackOH))
                    .Parameters.Add(New SqlParameter("@isActive", _isActive))
                    .Parameters.Add(New SqlParameter("@ItemImg", _ItemImg))
                    .Parameters.Add(New SqlParameter("@CreateBy", _CreateBy))
                    .Parameters.Add(New SqlParameter("@CreateDte", _CreateDte))
                    .Parameters.Add(New SqlParameter("@CostPrice", _CostPrice))
                    .Parameters.Add(New SqlParameter("@SellingPrice", _SellingPrice))
                    .Parameters.Add(New SqlParameter("@ModifyBy", _CreateBy))
                    .Parameters.Add(New SqlParameter("@ModifyDte", _CreateDte))
                    .Parameters.Add(New SqlParameter("@IsConverted", _IsConverted))

                    .ExecuteNonQuery()

                    Return True
                    Call SaveAuditTrail(strMSG, _ItemCode, True)
                End With
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try


    End Function
    Public Sub FetchRecord(ByVal strItemCode As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand(String.Format("SELECT     ItemId, ItemCode, ItemName, ItemDescription, LocationId, ItemCategoryId, BrandType, UOM, StockLevelQTY, StackOH, isActive, ItemImg, IsConverted, CostPrice, SellingPrice " +
                                    "FROM         tbl_000_Item where (ItemCode='{0}')", strItemCode), con)

        Try

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                ItemId = rdr("ItemId")
                ItemCode = rdr("ItemCode")
                ItemName = rdr("ItemName")
                ItemDescription = rdr("ItemDescription")
                LocationId = rdr("LocationId")
                ItemCategoryId = rdr("ItemCategoryId")
                BrandType = rdr("BrandType")
                UOM = rdr("UOM")
                StockLevelQTY = rdr("StockLevelQTY")
                StackOH = rdr("StackOH")
                isActive = rdr("isActive")
                ItemImg = rdr("ItemImg")
                CostPrice = NZ(rdr("CostPrice"))
                SellingPrice = NZ(rdr("SellingPrice"))
                IsConverted = rdr("IsConverted")
            End While

            rdr.Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally
            con.Close()

        End Try

    End Sub





End Class
