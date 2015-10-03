Imports System.Data.SqlClient

Public Class tbl_100_DoctorsPay
    Private _Id As Integer
    Private _patient As String
    Private _payable As Decimal
    Private _remarks As String
    Private _createdBy As String
    Private _createdDte As Date
    Private _modifyBy As String
    Private _modifyDte As Date

    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property

    Public Property patient() As String
        Get
            Return _patient
        End Get
        Set(ByVal value As String)
            _patient = value
        End Set
    End Property

    Public Property payable() As Decimal
        Get
            Return _payable
        End Get
        Set(ByVal value As Decimal)
            _payable = value
        End Set
    End Property

    Public Property remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property

    Public Property createdBy() As String
        Get
            Return _createdBy
        End Get
        Set(ByVal value As String)
            _createdBy = value
        End Set
    End Property

    Public Property createdDte() As Date
        Get
            Return _createdDte
        End Get
        Set(ByVal value As Date)
            _createdDte = value
        End Set
    End Property

    Public Property modifyBy() As String
        Get
            Return _modifyBy
        End Get
        Set(ByVal value As String)
            _modifyBy = value
        End Set
    End Property

    Public Property modifyDte() As Date
        Get
            Return _modifyDte
        End Get
        Set(ByVal value As Date)
            _modifyDte = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean) As Boolean
        Try
            Dim strMSG As String

            If isEdit Then
                strMSG = "Update Doctors Pay"
            Else
                strMSG = "Add New Doctors Pay"
            End If
            Using cmd As New SqlCommand("sproc_100_doctors", _Connection, _Transaction)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@Id", _Id))
                    .Parameters.Add(New SqlParameter("@patient", _patient))
                    .Parameters.Add(New SqlParameter("@payable", _payable))
                    .Parameters.Add(New SqlParameter("@remarks", _remarks))
                    .Parameters.Add(New SqlParameter("@createdBy", _createdBy))
                    .Parameters.Add(New SqlParameter("@createdDte", _createdDte))
                    .Parameters.Add(New SqlParameter("@modifyBy", _createdBy))
                    .Parameters.Add(New SqlParameter("@modifyDte", _createdDte))
                    .ExecuteNonQuery()
                End With
            End Using
            Call SaveAuditTrail(strMSG, _Id, True)
            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub FetchRecord(ByVal Id As Integer)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand(String.Format("SELECT     Id, patient, payable, remarks, createdBy, createdDte, modifyBy, modifyDte " +
                                    "FROM         tbl_100_DoctorsPay where (Id={0})", Id), con)

        Try

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                Id = rdr("Id")
                patient = rdr("patient")
                payable = rdr("payable")
                remarks = rdr("remarks")
            End While

            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally
            con.Close()

        End Try
    End Sub

End Class
