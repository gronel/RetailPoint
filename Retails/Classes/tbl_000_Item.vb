Imports System.Data.SqlClient
Imports System.IO
Public Class tbl_000_Item


#Region "Property"

    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As String, ByVal subID As String)
        FetchRecord(ID, subID)
    End Sub

    Private _ItemCode As String
    Public Property ItemCode() As String
        Get
            Return _ItemCode
        End Get
        Set(ByVal value As String)
            _ItemCode = value
        End Set
    End Property

    Private _ItemName As String
    Public Property ItemName() As String
        Get
            Return _ItemName
        End Get
        Set(ByVal value As String)
            _ItemName = value
        End Set
    End Property

    Private _CategoryCode As String
    Public Property CategoryCode() As String
        Get
            Return _CategoryCode
        End Get
        Set(ByVal value As String)
            _CategoryCode = value
        End Set
    End Property

    Private _SubCategoryCode As String
    Public Property SubCategoryCode() As String
        Get
            Return _SubCategoryCode
        End Get
        Set(ByVal value As String)
            _SubCategoryCode = value
        End Set
    End Property

    Private _SpecificCode As String
    Public Property SpecificCode() As String
        Get
            Return _SpecificCode
        End Get
        Set(ByVal value As String)
            _SpecificCode = value
        End Set
    End Property

    Private _TOCCode As String
    Public Property TOCCode() As String
        Get
            Return _TOCCode
        End Get
        Set(ByVal value As String)
            _TOCCode = value
        End Set
    End Property

    Private _SpecificDescription As String
    Public Property SpecificDescription() As String
        Get
            Return _SpecificDescription
        End Get
        Set(ByVal value As String)
            _SpecificDescription = value
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

    Private _BrandType As String
    Public Property BrandType() As String
        Get
            Return _BrandType
        End Get
        Set(ByVal value As String)
            _BrandType = value
        End Set
    End Property

    Private _ProductCode As String
    Public Property ProductCode() As String
        Get
            Return _ProductCode
        End Get
        Set(ByVal value As String)
            _ProductCode = value
        End Set
    End Property

    Private _ActualUOM As String
    Public Property ActualUOM() As String
        Get
            Return _ActualUOM
        End Get
        Set(ByVal value As String)
            _ActualUOM = value
        End Set
    End Property

    Private _InventoryUOM As String
    Public Property InventoryUOM() As String
        Get
            Return _InventoryUOM
        End Get
        Set(ByVal value As String)
            _InventoryUOM = value
        End Set
    End Property

    Private _RackNo As String
    Public Property RackNo() As String
        Get
            Return _RackNo
        End Get
        Set(ByVal value As String)
            _RackNo = value
        End Set
    End Property

    Private _WHCode As Integer
    Public Property WHCode() As Integer
        Get
            Return _WHCode
        End Get
        Set(ByVal value As Integer)
            _WHCode = value
        End Set
    End Property

    Private _StockLevelQTY As Double
    Public Property StockLevelQTY() As Double
        Get
            Return _StockLevelQTY
        End Get
        Set(ByVal value As Double)
            _StockLevelQTY = value
        End Set
    End Property

    Private _isActive As Boolean
    Public Property isActive() As Boolean
        Get
            Return _isActive
        End Get
        Set(ByVal value As Boolean)
            _isActive = value
        End Set
    End Property

    Private _ItemPhoto As Image
    Public Property ItemPhoto() As Image
        Get
            Return _ItemPhoto
        End Get
        Set(ByVal value As Image)
            _ItemPhoto = value
        End Set
    End Property

    Private _PhotoByte As Byte()
    Public Property PhotoByte() As Byte()
        Get
            Return _PhotoByte
        End Get
        Set(ByVal value As Byte())
            _PhotoByte = value
        End Set
    End Property

    Private _isDefault As Boolean
    Public Property isDefault() As Boolean
        Get
            Return _isDefault
        End Get
        Set(ByVal value As Boolean)
            _isDefault = value
        End Set
    End Property

    

#End Region
#Region "UserDifination"

    Private Sub CopyIMG(ByVal SpecificCode As String, ByVal picbox As PictureBox)

        Try
            File.Delete(strVarImgPath & SpecificCode & ".png")
            Dim bm As Bitmap = picbox.Image
            bm.Save(strVarImgPath & SpecificCode & ".png", System.Drawing.Imaging.ImageFormat.Png)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")

        End Try
    End Sub

    Public Function Save(ByVal isEdit As Boolean, ByVal picbox As PictureBox, Optional ByVal dgWarehouse As DataGridView = Nothing) As Boolean

        Try

            Dim strMSG As String
            Using com As New SqlCommand("SaveItem", _Connection, _Transaction)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMSG = "Update Item"
                Else
                    strMSG = "Add New Item"
                End If

                com.Parameters.Add(New SqlParameter("@itemcode", ItemCode))
                com.Parameters.Add(New SqlParameter("@itemname", ItemName))
                com.Parameters.Add(New SqlParameter("@categoryCode", CategoryCode))
                com.Parameters.Add(New SqlParameter("@SubCategoryCode", SubCategoryCode))
                com.Parameters.Add(New SqlParameter("@specificcode", SpecificCode))
                com.Parameters.Add(New SqlParameter("@toccode", TOCCode))
                com.Parameters.Add(New SqlParameter("@specificdescription", SpecificDescription))
                com.Parameters.Add(New SqlParameter("@usage", Usage))
                com.Parameters.Add(New SqlParameter("@brandtype", BrandType))
                com.Parameters.Add(New SqlParameter("@productcode", ProductCode))
                com.Parameters.Add(New SqlParameter("@actualUOM", ActualUOM))
                com.Parameters.Add(New SqlParameter("@inventoryUOM", InventoryUOM))
                com.Parameters.Add(New SqlParameter("@stocklevelQTY", StockLevelQTY))
                com.Parameters.Add(New SqlParameter("@isActive", isActive))
                com.Parameters.Add(New SqlParameter("@RackNo", RackNo))
                com.Parameters.Add(New SqlParameter("@WHCode", WHCode))
                com.Parameters.Add(New SqlParameter("@StackOH", "0"))
                com.Parameters.Add(New SqlParameter("@isDefault", isDefault))
                com.ExecuteNonQuery()

            End Using


            Call SaveAuditTrail(strMSG, _SpecificCode, True)
            Call CopyIMG(SpecificCode, picbox)

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Sub FetchRecord(ByVal strItemCode As String, ByVal strSpecificCode As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("GetItem '" & strItemCode & "', '" & strSpecificCode & "'", con)

        Try

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                ItemCode = rdr("ItemCode")
                CategoryCode = rdr("CategoryCode")
                SubCategoryCode = rdr("SubCategoryCode")
                SpecificCode = rdr("SpecificCode")
                TOCCode = rdr("TOCCode")
                SpecificDescription = rdr("SpecificDescription")
                Usage = rdr("Usage")
                BrandType = rdr("BrandType")
                ProductCode = rdr("ProductCode")
                ActualUOM = rdr("ActualUOM")
                InventoryUOM = rdr("InventoryUOM")
                StockLevelQTY = rdr("StockLevelQTY")
                isActive = rdr("isActive")
                RackNo = rdr("RackNo")
                isDefault = rdr("isDefault")
            End While

            rdr.Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally
            con.Close()

        End Try

    End Sub


#End Region


End Class
