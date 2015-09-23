Imports System.Data.SqlClient

Public Class tbl_000_Category
    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As String)
        FetchRecord(ID)
    End Sub

    Private _CategoryCode As String
    Public Property CategoryCode() As String
        Get
            Return _CategoryCode
        End Get
        Set(ByVal value As String)
            _CategoryCode = value
        End Set
    End Property

    Private _CategoryName As String
    Public Property CategoryName() As String
        Get
            Return _CategoryName
        End Get
        Set(ByVal value As String)
            _CategoryName = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean

        Try

            Dim strMSG As String
            Using com As New SqlCommand("SaveCategory", _Connection, _Transaction)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMSG = "Update Category"
                Else
                    strMSG = "Add New Category"
                End If

                com.Parameters.Add(New SqlParameter("@CategoryCode", CategoryCode))
                com.Parameters.Add(New SqlParameter("@CategoryName", CategoryName))
                com.ExecuteNonQuery()

            End Using

            Using com As New SqlCommand("DELETE FROM tbl_000_Category_Sub WHERE CategoryCode='" & CategoryCode & "'", _Connection, _Transaction)
                com.CommandType = CommandType.Text
                com.ExecuteNonQuery()
            End Using

            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com As New SqlCommand("SaveCategorySub", _Connection, _Transaction)
                        com.CommandType = CommandType.StoredProcedure

                        com.Parameters.Add(New SqlParameter("@CategoryCode", CategoryCode))
                        com.Parameters.Add(New SqlParameter("@SubCategoryCode", row.Cells("colSubCode").Value))
                        com.Parameters.Add(New SqlParameter("@SubCategoryName", row.Cells("colSubName").Value))
                        com.ExecuteNonQuery()

                    End Using
                End If
            Next

            Call SaveAuditTrail(strMSG, CategoryCode, True)

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Sub FetchRecord(ByVal strPK As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("GetCategory '" & strPK & "'", con)

        Try
            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                _CategoryCode = rdr("CategoryCode")
                _CategoryName = rdr("Categoryname")
            End While

            rdr.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally


        End Try

    End Sub

End Class
