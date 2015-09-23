Imports System.Data.SqlClient

Public Class tbl_000_User

    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As String)
        FetchRecord(ID)
    End Sub

    Private _UserID As String
    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(ByVal value As String)
            _UserID = value
        End Set
    End Property

    Private _EmpID As String
    Public Property EmpID() As String
        Get
            Return _EmpID
        End Get
        Set(ByVal value As String)
            _EmpID = value
        End Set
    End Property

    Private _UserName As String
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Private _EmpName As String
    Public Property EmpName() As String
        Get
            Return _EmpName
        End Get
        Set(ByVal value As String)
            _EmpName = value
        End Set
    End Property

    Private _UserPassword As String
    Public Property UserPassword() As String
        Get
            Return _UserPassword
        End Get
        Set(ByVal value As String)
            _UserPassword = value
        End Set
    End Property

    Private _UserGroup As String
    Public Property UserGroup() As String
        Get
            Return _UserGroup
        End Get
        Set(ByVal value As String)
            _UserGroup = value
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

    Private _UserPic As Byte()
    Public Property UserPic() As Byte()
        Get
            Return _UserPic
        End Get
        Set(ByVal value As Byte())
            _UserPic = value
        End Set
    End Property

    Private _UserImage As Image
    Public Property UserImage() As Image
        Get
            Return _UserImage
        End Get
        Set(ByVal value As Image)
            _UserImage = value
        End Set
    End Property

    Public Function UpdatePassword() As Boolean
        Try
            Dim con As SqlConnection = New SqlConnection(cnString)
            If con.State = ConnectionState.Closed Then con.Open()

            Using com As New SqlCommand("UPDATE tbl_000_User SET UserPassword='" & UserPassword & "' WHERE UserID=" & UserID, con)
                com.CommandType = CommandType.Text
                com.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Save(ByVal isEdit As Boolean, Optional ByVal dgRigths As DataGridView = Nothing) As Boolean

        Try

            Dim strMSG As String
            Using com As New SqlCommand("SaveUser", _Connection, _Transaction)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMSG = "Update User"
                Else
                    strMSG = "Add New User"
                End If
                Dim a As New SqlParameter("@ID", SqlDbType.Int)
                com.Parameters.Add(a)
                a.Direction = ParameterDirection.Output



                com.Parameters.AddWithValue("@UserID", UserID)


                com.Parameters.Add(New SqlParameter("@EmpID", EmpID))
                com.Parameters.Add(New SqlParameter("@EmpName", EmpName))
                com.Parameters.Add(New SqlParameter("@UserName", UserName))
                com.Parameters.Add(New SqlParameter("@UserPassword", clsSecurity.psEncrypt(UserPassword)))
                com.Parameters.Add(New SqlParameter("@UserGroup", UserGroup))
                com.Parameters.Add(New SqlParameter("@isActive", isActive))
                com.ExecuteNonQuery()

                If isEdit = False Then UserID = com.Parameters("@ID").Value()




                'Dim rd As SqlDataReader

                'rd = com.ExecuteReader()
                'While rd.Read
                '    UserID = rd("userid")
                'End While
                'rd.Close()


            End Using


            If Not dgRigths Is Nothing Then

                Using com As New SqlCommand("DELETE FROM tbl_000_UserRights WHERE UserID=" & UserID, _Connection, _Transaction)
                    com.CommandType = CommandType.Text
                    com.ExecuteNonQuery()
                End Using

                For Each row As DataGridViewRow In dgRigths.Rows
                    Using com As New SqlCommand("SaveUserRights", _Connection, _Transaction)
                        com.CommandType = CommandType.StoredProcedure

                        com.Parameters.Add(New SqlParameter("@UserID", UserID))
                        com.Parameters.Add(New SqlParameter("@MenuID", row.Cells("colMenuID").Value))
                        com.Parameters.Add(New SqlParameter("@CanAdd", row.Cells("colCanAdd").Value))
                        com.Parameters.Add(New SqlParameter("@canEdit", row.Cells("colCanEdit").Value))
                        com.Parameters.Add(New SqlParameter("@canvoid", row.Cells("colCanVoid").Value))
                        com.Parameters.Add(New SqlParameter("@canDelete", row.Cells("colCanDelete").Value))
                        com.Parameters.Add(New SqlParameter("@canPreview", row.Cells("colCanView").Value))
                        com.Parameters.Add(New SqlParameter("@canPrint", row.Cells("colCanPrint").Value))

                        com.ExecuteNonQuery()

                    End Using
                Next
            End If

            Call SaveAuditTrail(strMSG, _UserID, True)

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Sub FetchRecord(ByVal strUserID As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("Get_Employee'" & "selectuser" & "','" & strUserID & "'", con)


        Try

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                _EmpID = rdr("EmpID")
                _EmpName = rdr("EmpName")
                _UserName = rdr("UserName")
                _UserPassword = clsSecurity.psDecrypt(rdr("UserPassword"))
                _UserGroup = rdr("UserGroup")
                _isActive = rdr("isActive")
                _UserPic = IIf(IsDBNull(rdr("EmpPhoto")), Nothing, rdr("EmpPhoto"))
            End While

            rdr.Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally


        End Try

    End Sub


End Class
