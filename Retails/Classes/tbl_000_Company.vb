Imports System.Data.SqlClient

Public Class tbl_000_Company

    Public Sub New()
    End Sub

    Private _CompanyID As Integer
    Public Property CompanyID() As Integer
        Get
            Return _CompanyID
        End Get
        Set(ByVal value As Integer)
            _CompanyID = value
        End Set
    End Property

    Private _CompanyName As String
    Public Property CompanyName() As String
        Get
            Return _CompanyName
        End Get
        Set(ByVal value As String)
            _CompanyName = value
        End Set
    End Property

    Private _Address As String
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property

    Private _Phone As String
    Public Property Phone() As String
        Get
            Return _Phone
        End Get
        Set(ByVal value As String)
            _Phone = value
        End Set
    End Property

    Private _Fax As String
    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            _Fax = value
        End Set
    End Property

    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Private _Website As String
    Public Property Website() As String
        Get
            Return _Website
        End Get
        Set(ByVal value As String)
            _Website = value
        End Set
    End Property

    Private _Logo As Byte()
    Public Property Logo() As Byte()
        Get
            Return _Logo
        End Get
        Set(ByVal value As Byte())
            _Logo = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean) As Boolean

        Try
            Dim strMSG As String

            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            Using com As New SqlCommand("sproc_000_company", _Connection)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMSG = "Updated"
                Else
                    strMSG = "Saved"
                End If

                com.Parameters.Add(New SqlParameter("@companyid", CompanyID))
                com.Parameters.Add(New SqlParameter("@companyname", CompanyName))
                com.Parameters.Add(New SqlParameter("@address", Address))
                com.Parameters.Add(New SqlParameter("@phone", Phone))
                com.Parameters.Add(New SqlParameter("@fax", Fax))
                com.Parameters.Add(New SqlParameter("@email", Email))
                com.Parameters.Add(New SqlParameter("@website", Website))
                com.Parameters.Add(New SqlParameter("@logo", Logo))
                com.ExecuteNonQuery()

            End Using

            ''Call SaveAuditTrail(strMSG, _UserID, True)

            Return True

        Catch ex As Exception
            Return False
        Finally
            _Connection.Close()
        End Try

    End Function


    Public Sub FetchRecord(ByVal ID As Integer)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("GetCompany " & ID & "", con)

        con.Open()
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While rdr.Read
            _CompanyID = rdr("CompanyID")
            _CompanyName = rdr("CompanyName")
            _Address = rdr("Address")
            _Phone = rdr("Phone")
            _Fax = rdr("Fax")
            _Email = rdr("Email")
            _Website = rdr("Website")
            _Logo = rdr("Logo")
        End While

        rdr.Close()



    End Sub


End Class
