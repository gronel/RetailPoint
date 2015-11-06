Imports System.Data.SqlClient
Public Class tbl_100_Return

    Public Sub New()
    End Sub

    Private _returnId As String
    Private _returnDate As Date
    Private _comments As String
    Private _createdBy As String
    Private _createdDate As Date
    Private _isPosted As Boolean
    Private _tatalAmt As Decimal

    Public Property returnId() As String
        Get
            Return _returnId
        End Get
        Set(ByVal value As String)
            _returnId = value
        End Set
    End Property

    Public Property returnDate() As Date
        Get
            Return _returnDate
        End Get
        Set(ByVal value As Date)
            _returnDate = value
        End Set
    End Property

    Public Property comments() As String
        Get
            Return _comments
        End Get
        Set(ByVal value As String)
            _comments = value
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

    Public Property createdDate() As Date
        Get
            Return _createdDate
        End Get
        Set(ByVal value As Date)
            _createdDate = value
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

    Public Property tatalAmt() As Decimal
        Get
            Return _tatalAmt
        End Get
        Set(ByVal value As Decimal)
            _tatalAmt = value
        End Set
    End Property

    Private _action As Integer

    Public Property action() As Integer
        Get
            Return _action
        End Get
        Set(ByVal value As Integer)
            _action = value
        End Set
    End Property


    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean
        Try
            Dim strMsg As String

            If isEdit Then
                strMsg = "Update Return Transaction"
            Else
                strMsg = "Add New Return Transaction"
            End If
            Using cmd As New SqlCommand("sproc_100_return_master", _Connection, _Transaction)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@returnId", _returnId))
                    .Parameters.Add(New SqlParameter("@returnDate", _returnDate))
                    .Parameters.Add(New SqlParameter("@comments", _comments))
                    .Parameters.Add(New SqlParameter("@createdBy", _createdBy))
                    .Parameters.Add(New SqlParameter("@isPosted", CInt(_isPosted)))
                    .Parameters.Add(New SqlParameter("@tatalAmt", NZ(_tatalAmt)))
                    .Parameters.Add(New SqlParameter("@action", CInt(_action)))
                    .ExecuteNonQuery()
                End With
            End Using


            Using com1 As New SqlCommand("DELETE FROM tbl_100_Return_Sub Where returnId='" & _returnId & "'", _Connection, _Transaction)
                com1.CommandType = CommandType.Text
                com1.ExecuteNonQuery()
            End Using
            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using cmd As New SqlCommand("sproc_100_return_sub", _Connection, _Transaction)
                        With cmd
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@returnId", _returnId))
                            .Parameters.Add(New SqlParameter("@itemId", Integer.Parse(row.Cells("colItemId").Value)))
                            .Parameters.Add(New SqlParameter("@Qty", Integer.Parse(row.Cells("colQty").Value)))
                            .Parameters.Add(New SqlParameter("@UnitPrice", Decimal.Parse(row.Cells("colCost").Value)))
                            .Parameters.Add(New SqlParameter("@Amount", Decimal.Parse(row.Cells("colAmount").Value)))
                            .ExecuteNonQuery()

                        End With
                    End Using

                    'update stock on hand
                    If _isPosted = True And CInt(_action) = 0 Then
                        Using cmd As New SqlCommand("sproc_100_dr_post", _Connection, _Transaction)
                            With cmd
                                .CommandType = CommandType.StoredProcedure
                                .Parameters.Add(New SqlParameter("@itemId", Integer.Parse(row.Cells("colItemId").Value)))
                                .Parameters.Add(New SqlParameter("@qty", Integer.Parse(row.Cells("colQty").Value)))                           
                                .ExecuteNonQuery()

                            End With
                        End Using
                    End If

                End If
            Next


            Call SaveAuditTrail(strMsg, _returnId, True)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub FetchRecord(ByVal returnId As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand(String.Format("SELECT     returnId, returnDate, comments, createdBy, createdDate, isPosted, tatalAmt, action " +
                                    "FROM   tbl_100_Return where (returnId='{0}')", returnId), con)

        Try

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                returnId = rdr("returnId")
                returnDate = rdr("returnDate")
                comments = rdr("comments")
                tatalAmt = rdr("tatalAmt")
                action = rdr("action")
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
        Dim cmd As New SqlCommand("SELECT MAX(convert(int,returnId)) as ID FROM tbl_100_Return ORDER BY ID", con)

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
