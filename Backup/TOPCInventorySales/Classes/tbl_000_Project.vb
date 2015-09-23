Imports System.Data.SqlClient

Public Class tbl_000_Project

    Public Sub New()
    End Sub

    Private _ProjectID As Integer
    Public Property ProjectID() As Integer
        Get
            Return _ProjectID
        End Get
        Set(ByVal value As Integer)
            _ProjectID = value
        End Set
    End Property

    Private _ClientID As Integer
    Public Property ClientID() As Integer
        Get
            Return _ClientID
        End Get
        Set(ByVal value As Integer)
            _ClientID = value
        End Set
    End Property

    Private _ProjectName As String
    Public Property ProjectName() As String
        Get
            Return _ProjectName
        End Get
        Set(ByVal value As String)
            _ProjectName = value
        End Set
    End Property

    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Private _ProjectType As String
    Public Property ProjectType() As String
        Get
            Return _ProjectType
        End Get
        Set(ByVal value As String)
            _ProjectType = value
        End Set
    End Property

    Private _ProjectStatus As String
    Public Property ProjectStatus() As String
        Get
            Return _ProjectStatus
        End Get
        Set(ByVal value As String)
            _ProjectStatus = value
        End Set
    End Property

    Private _Languageuse As String
    Public Property Languageuse() As String
        Get
            Return _Languageuse
        End Get
        Set(ByVal value As String)
            _Languageuse = value
        End Set
    End Property

    Private _BackEnd As String
    Public Property BackEnd() As String
        Get
            Return _BackEnd
        End Get
        Set(ByVal value As String)
            _BackEnd = value
        End Set
    End Property

    Private _Startdate As String
    Public Property Startdate() As String
        Get
            Return _Startdate
        End Get
        Set(ByVal value As String)
            _Startdate = value
        End Set
    End Property

    Private _EndDate As String
    Public Property EndDate() As String
        Get
            Return _EndDate
        End Get
        Set(ByVal value As String)
            _EndDate = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean) As Boolean

        Try
            Dim strMSG As String

            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            Using com As New SqlCommand("SaveProject", _Connection)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMSG = "Updated"
                Else
                    strMSG = "Saved"
                End If

                com.Parameters.Add(New SqlParameter("@ProjectID", ProjectID))
                com.Parameters.Add(New SqlParameter("@ClientID", ClientID))
                com.Parameters.Add(New SqlParameter("@ProjectName", ProjectName))
                com.Parameters.Add(New SqlParameter("@Description", Description))
                com.Parameters.Add(New SqlParameter("@ProjectType", ProjectType))
                com.Parameters.Add(New SqlParameter("@ProjectStatus", ProjectStatus))
                com.Parameters.Add(New SqlParameter("@Languageuse", Languageuse))
                com.Parameters.Add(New SqlParameter("@BackEnd", BackEnd))
                com.Parameters.Add(New SqlParameter("@Startdate", Startdate))
                com.Parameters.Add(New SqlParameter("@EndDate", EndDate))

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


    Public Sub GetRecord(ByVal ID As Integer)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("GetProject " & ID & "", con)

        con.Open()
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While rdr.Read
            _ProjectID = rdr("ProjectID")
            _ClientID = rdr("ClientID")
            _ProjectName = rdr("ProjectName")
            _Description = rdr("ProjectDescription")
            _ProjectType = rdr("ProjectType")
            _ProjectStatus = rdr("ProjectStatus")
            _Languageuse = rdr("LanguageUse")
            _BackEnd = rdr("BackEnd")
            _Startdate = rdr("StartDate")
            _EndDate = rdr("EndDate")
        End While

        rdr.Close()



    End Sub


End Class
