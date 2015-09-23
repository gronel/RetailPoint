Imports System.Data.SqlClient
Public Class tbl_000_Employee
    Private _empid As String
    Public Property EmpID() As String
        Get
            Return _empid
        End Get
        Set(ByVal value As String)
            _empid = value
        End Set
    End Property
    Private _Fname As String
    Public Property FirstName() As String
        Get
            Return _Fname
        End Get
        Set(ByVal value As String)
            _Fname = value
        End Set
    End Property
    Private _Lname As String
    Public Property LastName() As String
        Get
            Return _Lname
        End Get
        Set(ByVal value As String)
            _Lname = value
        End Set
    End Property
    Private _Mname As String
    Public Property MiddleName() As String
        Get
            Return _Mname
        End Get
        Set(ByVal value As String)
            _Mname = value
        End Set
    End Property
    Private _Designation As String
    Public Property Designation() As String
        Get
            Return _Designation
        End Get
        Set(ByVal value As String)
            _Designation = value
        End Set
    End Property
    Private _EmpStatus As String
    Public Property EmpStatus() As String
        Get
            Return _EmpStatus
        End Get
        Set(ByVal value As String)
            _EmpStatus = value
        End Set
    End Property
    Private _isActive As Boolean
    Public Property ISActive() As Boolean
        Get
            Return _isActive
        End Get
        Set(ByVal value As Boolean)
            _isActive = value
        End Set
    End Property
    Private _empPic() As Byte
    Public Property EmpPic() As Byte()
        Get
            Return _empPic
        End Get
        Set(ByVal value As Byte())
            _empPic = value
        End Set
    End Property
    Private _depcode As String
    Public Property DepartmentCode() As String
        Get
            Return _depcode
        End Get
        Set(ByVal value As String)
            _depcode = value
        End Set
    End Property
    Private _SectionCode As String
    Public Property SectionCode() As String
        Get
            Return _SectionCode
        End Get
        Set(ByVal value As String)
            _SectionCode = value
        End Set
    End Property
    Private _LineCode As String
    Public Property LineCode() As String
        Get
            Return _LineCode
        End Get
        Set(ByVal value As String)
            _LineCode = value
        End Set
    End Property
    Private _EmpImage As Image
    Public Property EmpImage() As Image
        Get
            Return _EmpImage
        End Get
        Set(ByVal value As Image)
            _EmpImage = value
        End Set
    End Property
    Public Function Save(ByVal isEdit As Boolean) As Boolean
        Try

            Dim strMSG As String
            Using com As New SqlCommand("sp_Save_Employee", _Connection, _Transaction)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMSG = "Update User"
                Else
                    strMSG = "Add New User"
                End If

                com.Parameters.Add(New SqlParameter("@EmpID", EmpID))
                com.Parameters.Add(New SqlParameter("@FirstName", FirstName))
                com.Parameters.Add(New SqlParameter("@LastName", LastName))
                com.Parameters.Add(New SqlParameter("@MiddleName", MiddleName))
                com.Parameters.Add(New SqlParameter("@Designation", Designation))
                com.Parameters.Add(New SqlParameter("@EmpStatus", EmpStatus))
                com.Parameters.Add(New SqlParameter("@IsActive", ISActive))
                com.Parameters.Add(New SqlParameter("@EmpPhoto", EmpPic()))
                com.Parameters.Add(New SqlParameter("@DepartmentCode", DepartmentCode))
                com.Parameters.Add(New SqlParameter("@LineCode", LineCode))
                com.Parameters.Add(New SqlParameter("@SectionCode", SectionCode))

                com.ExecuteNonQuery()
                Call SaveAuditTrail(strMSG, _empid, True)
            End Using
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Save Employee")
            Return False
        End Try
    End Function
    Public Sub FetchRecord(ByVal strUserID As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("Get_Employee'" & "select" & "','" & strUserID & "'", con)


        Try

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                _EmpID = rdr("EmpID")
                _Fname = rdr("FirstName")
                _Lname = rdr("LastName")
                _Mname = rdr("MiddleName")
                _Designation = rdr("Designation")
                _EmpStatus = rdr("EmpStatus")
                _isActive = rdr("IsActive")
                _empPic = IIf(IsDBNull(rdr("EmpPhoto")), Nothing, rdr("EmpPhoto"))
                _depcode = rdr("DepartmentCode")
                _LineCode = rdr("LineCode")
                _SectionCode = rdr("SectionCode")
            End While

            rdr.Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally


        End Try

    End Sub
End Class
