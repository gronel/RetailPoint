Imports System.Data.SqlClient
Public Class tbl_100_WR
    Public Sub New()
    End Sub
    Private _wrId As String
    Private _wrComments As String
    Private _wrTotalCost As Decimal
    Private _createdBy As String
    Private _createdDte As Date
    Private _isPosted As Boolean

    Public Property wrId() As String
        Get
            Return _wrId
        End Get
        Set(ByVal value As String)
            _wrId = value
        End Set
    End Property

    Public Property wrComments() As String
        Get
            Return _wrComments
        End Get
        Set(ByVal value As String)
            _wrComments = value
        End Set
    End Property

    Public Property wrTotalCost() As Decimal
        Get
            Return _wrTotalCost
        End Get
        Set(ByVal value As Decimal)
            _wrTotalCost = value
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

    Public Property isPosted() As Boolean
        Get
            Return _isPosted
        End Get
        Set(ByVal value As Boolean)
            _isPosted = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean
        Try
            Dim strMsg As String

            If isEdit Then
                strMsg = "Update WR"
            Else
                strMsg = "Add New WR"
            End If
            Using cmd As New SqlCommand("sproc_100_wr_master", _Connection, _Transaction)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@wrId", _wrId))
                    .Parameters.Add(New SqlParameter("@wrComments", _wrComments))
                    .Parameters.Add(New SqlParameter("@wrTotalCost", _wrTotalCost))
                    .Parameters.Add(New SqlParameter("@createdBy", _createdBy))
                    .Parameters.Add(New SqlParameter("@createdDte", _createdDte))
                    .Parameters.Add(New SqlParameter("@isPosted", _isPosted))
                    .ExecuteNonQuery()

                End With

            End Using

            Using com1 As New SqlCommand("DELETE FROM tbl_100_WR_Sub Where wrId='" & _wrId & "'", _Connection, _Transaction)
                com1.CommandType = CommandType.Text
                com1.ExecuteNonQuery()
            End Using
            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using cmd As New SqlCommand("sproc_100_wr_sub", _Connection, _Transaction)
                        With cmd
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@wrId", _wrId))
                            .Parameters.Add(New SqlParameter("@itemId", Integer.Parse(row.Cells("colItemId").Value)))
                            .Parameters.Add(New SqlParameter("@Qty", Integer.Parse(row.Cells("colQty").Value)))
                            .Parameters.Add(New SqlParameter("@Cost", Decimal.Parse(row.Cells("colCost").Value)))
                            .Parameters.Add(New SqlParameter("@Amount", Decimal.Parse(row.Cells("colAmount").Value)))
                            .Parameters.Add(New SqlParameter("@isPost", _isPosted))
                            .ExecuteNonQuery()

                        End With
                    End Using
                End If
            Next


            Call SaveAuditTrail(strMsg, _wrId, True)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub FetchRecord(ByVal drcode As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand(String.Format("select wrId, wrComments, wrTotalCost, createdBy, createdDte, isPosted " +
                                    "FROM   tbl_100_WR where (wrId='{0}')", drcode), con)

        Try

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                wrId = rdr("wrId")
                wrComments = rdr("wrComments")
                wrTotalCost = rdr("wrTotalCost")
             
            End While

            rdr.Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally
            con.Close()

        End Try

    End Sub

    Public Shared Function GenerateID() As String
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("SELECT MAX(convert(int,wrId)) as ID FROM tbl_100_WR ORDER BY ID", con)

        Try
            GenerateID = "0000001"
            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            If rdr.HasRows Then
                While rdr.Read
                    GenerateID = rdr("ID")
                End While
                GenerateID = Format(Long.Parse(GenerateID) + 1, "0000000")
            Else
                GenerateID = "0000001"
            End If


            rdr.Close()



        Catch ex As Exception
            ' MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
            Return "0000001"
        Finally


        End Try

    End Function

End Class
