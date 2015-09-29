Imports System.Data.SqlClient

Public Class tbl_000_Department

    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As String)
        FetchRecord(ID)
    End Sub

    Private _DepartmentCode As String
    Public Property DepartmentCode() As String
        Get
            Return _DepartmentCode
        End Get
        Set(ByVal value As String)
            _DepartmentCode = value
        End Set
    End Property

    Private _DepartmentName As String
    Public Property DepartmentName() As String
        Get
            Return _DepartmentName
        End Get
        Set(ByVal value As String)
            _DepartmentName = value
        End Set
    End Property

    Private _DepartmentParent As String
    Public Property DepartmentParent() As String
        Get
            Return _DepartmentParent
        End Get
        Set(ByVal value As String)
            _DepartmentParent = value
        End Set
    End Property

    Private _DepartmentLevel As Integer
    Public Property DepartmentLevel() As Integer
        Get
            Return _DepartmentLevel
        End Get
        Set(ByVal value As Integer)
            _DepartmentLevel = value
        End Set
    End Property

    Private _count As Long
    Public Property count() As Long
        Get
            Return _count
        End Get
        Set(ByVal value As Long)
            _count = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean) As Boolean

        Try

            Dim strMSG As String
            Using com As New SqlCommand("sproc_100_department", _Connection, _Transaction)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMSG = "Update Category"
                Else
                    strMSG = "Add New Category"
                End If

                com.Parameters.Add(New SqlParameter("@DepartmentCode", DepartmentCode))
                com.Parameters.Add(New SqlParameter("@DepartmentName", DepartmentName))
                com.Parameters.Add(New SqlParameter("@DepartmentLevel", DepartmentLevel))
                com.Parameters.Add(New SqlParameter("@DepartmentParent", DepartmentParent))

                com.ExecuteNonQuery()

            End Using

            Call SaveAuditTrail(strMSG, DepartmentCode, True)

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Sub FetchRecord(ByVal strPK As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("SELECT * FROM tbl_000_Department WHERE DepartmentCode = '" & strPK & "'", con)

        Try
            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                _DepartmentCode = rdr("DepartmentCode")
                _DepartmentName = rdr("DepartmentName")
                _DepartmentLevel = rdr("DepartmentLevel")
                _DepartmentParent = rdr("DepartmentParent")
            End While

            rdr.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally
            con.Close()

        End Try

    End Sub

    Public Sub LoadDepartmentTreeView(ByVal srcTreeView As TreeView)

        Dim sqlConn As New SqlConnection(cnString)

        Try
            sqlConn.Open()
            Dim myCmd As SqlCommand = New SqlCommand("SELECT * FROM tbl_000_Department ORDER BY DepartmentLevel,DepartmentName", sqlConn)
            myCmd.CommandType = CommandType.Text
            Dim myReader As SqlDataReader = myCmd.ExecuteReader(CommandBehavior.CloseConnection)
            Dim strParentCode As String = Nothing

            _count = 0
            With srcTreeView
                .BeginUpdate()
                .Nodes.Clear()
                While myReader.Read()
                    strParentCode = IIf(String.IsNullOrEmpty(myReader("DepartmentParent").ToString), "", myReader("DepartmentParent"))
                    If String.IsNullOrEmpty(strParentCode) Then
                        'for the root department
                        Dim rootNode As New TreeNode(myReader("DepartmentName"))
                        rootNode.Tag = myReader("DepartmentCode")
                        rootNode.ImageIndex = 1
                        .Nodes.Add(rootNode)
                    Else
                        For Each selectedNode As TreeNode In .Nodes
                            If selectedNode.Tag = strParentCode Then
                                Dim childNode As New TreeNode(myReader("DepartmentName"))
                                childNode.Tag = myReader("DepartmentCode")
                                childNode.ImageIndex = 1
                                selectedNode.Nodes.Add(childNode)
                            Else
                                AddNode(selectedNode, strParentCode, myReader("DepartmentCode"), myReader("DepartmentName"))
                            End If
                        Next
                    End If
                    _count = _count + 1
                End While
                .EndUpdate()
            End With
            myReader.Close()
            myCmd.Dispose()
        Catch ex As Exception
            Throw
        Finally
            sqlConn.Close()
            sqlConn.Dispose()
        End Try
    End Sub



End Class
