Imports System.Data.SqlClient
Public Class tbl_100_PayOut
    Public Sub New()
    End Sub

    Private _Id As Integer
    Private _Purpose As String
    Private _Amount As Decimal
    Private _isPosted As Boolean
    Private _CreatedBy As String
    Private _CretedDte As Date

    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property

    Public Property Purpose() As String
        Get
            Return _Purpose
        End Get
        Set(ByVal value As String)
            _Purpose = value
        End Set
    End Property

    Public Property Amount() As Decimal
        Get
            Return _Amount
        End Get
        Set(ByVal value As Decimal)
            _Amount = value
        End Set
    End Property

    Public Property isPosted() As Boolean
        Get
            Return _isPosted
        End Get
        Set(ByVal value As Boolean)
            _isPosted = value
        End Set
    End Property

    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = value
        End Set
    End Property

    Public Property CretedDte() As Date
        Get
            Return _CretedDte
        End Get
        Set(ByVal value As Date)
            _CretedDte = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean) As Boolean
        Try
            Dim strMSG As String

            If isEdit Then
                strMSG = "Update Payout"
            Else
                strMSG = "Add New Payout"
            End If

            Using cmd As New SqlCommand("sproc_100_payout", _Connection, _Transaction)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@Id", _Id))
                    .Parameters.Add(New SqlParameter("@Purpose", _Purpose))
                    .Parameters.Add(New SqlParameter("@Amount", _Amount))
                    .Parameters.Add(New SqlParameter("@CreatedBy", _CreatedBy))
                    .Parameters.Add(New SqlParameter("@CretedDte", _CretedDte))
                    .Parameters.Add(New SqlParameter("@ModifyBy", _CreatedBy))
                    .Parameters.Add(New SqlParameter("@ModifyDte", _CretedDte))
                    .ExecuteNonQuery()
                End With
                Call SaveAuditTrail(strMSG, _Id, True)
                Return True


            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub FetchRecord(ByVal payoutId As Integer)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand(String.Format("	SELECT     Id, Purpose, Amount, CreatedBy, CretedDte " +
                                    "FROM         tbl_100_PayOut where (Id={0})", payoutId), con)

        Try

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                Id = rdr("Id")
                Purpose = rdr("Purpose")
                Amount = rdr("Amount")
            End While

            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally
            con.Close()

        End Try
    End Sub
End Class
