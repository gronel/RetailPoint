Imports System
Imports System.Data
Imports System.Data.SqlClient

Module _xDatabase

    Public _strMessage As String = String.Empty
    Public _Connection As New SqlConnection
    Public _Transaction As SqlTransaction
    Public _Result As Boolean

    Public Function _OpenTransaction() As Boolean


        Try
            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()
            _Transaction = _Connection.BeginTransaction
        Catch ex As Exception

        End Try

    End Function

    Public Function _CloseTransaction(ByVal _isCommit As Boolean) As Boolean

        Try

            If _isCommit Then
                _Transaction.Commit()
            Else
                _Transaction.Rollback()
            End If

        Catch ex As Exception
            _Transaction.Rollback()
        Finally
            If _Connection.State = ConnectionState.Open Then _Connection.Close()
        End Try

    End Function

    Public Function _DeleteRecord(ByVal strTBLName As String, ByVal strWhere As String) As Boolean

        Try
            Dim str As String = "DELETE FROM " & strTBLName & " " & strWhere

            Using cmd As New SqlCommand(str, _Connection, _Transaction)
                cmd.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try


    End Function

    Public Function _UpdateRecord(ByVal strTBLName As String, ByVal strSetValue As String, ByVal strWhere As String) As Boolean

        Dim conn As New SqlConnection(cnString)

        Try
            Dim str As String = "UPDATE " & strTBLName & " SET " & strSetValue & " " & strWhere
            conn.Open()

            Using cmd As New SqlCommand(str, conn)
                cmd.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
        End Try


    End Function



    ''' <summary>
    ''' Save to Audit Trail
    ''' </summary>
    ''' <param name="LogTransaction"></param>
    ''' <param name="LogTransNo"></param>
    ''' <param name="withTrans"></param>
    ''' <remarks></remarks>
    Public Sub SaveAuditTrail(ByVal LogTransaction As String, ByVal LogTransNo As String, Optional ByVal withTrans As Boolean = False)
        Dim str As String

        Try
            str = "_AuditTrail '" & LogTransaction & " " & LogTransNo & "','" & CurrUser.USER_NAME & "','" & ComputerName & "'"

            If withTrans Then
                Using cmd As New SqlCommand(str, _Connection, _Transaction)
                    cmd.ExecuteNonQuery()
                End Using
            Else
                _OpenTransaction()
                Using cmd As New SqlCommand(str, _Connection, _Transaction)
                    cmd.ExecuteNonQuery()
                End Using
                _CloseTransaction(True)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Module
