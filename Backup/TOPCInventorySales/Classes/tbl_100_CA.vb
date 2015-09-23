Imports System.Data.SqlClient

Public Class tbl_100_CA
    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As String)
        FetchRecord(ID)
    End Sub

    Private _CANo As String
    Public Property CANo() As String
        Get
            Return _CANo
        End Get
        Set(ByVal value As String)
            _CANo = value
        End Set
    End Property

    Private _CADate As Date
    Public Property CADate() As String
        Get
            Return _CADate
        End Get
        Set(ByVal value As String)
            _CADate = value
        End Set
    End Property

    Private _Requestor As String
    Public Property Requestor() As String
        Get
            Return _Requestor
        End Get
        Set(ByVal value As String)
            _Requestor = value
        End Set
    End Property

    Private _DepartmentCode As String
    Public Property DepartmentCode() As String
        Get
            Return _DepartmentCode
        End Get
        Set(ByVal value As String)
            _DepartmentCode = value
        End Set
    End Property

    Private _Purpose As String
    Public Property Purpose() As String
        Get
            Return _Purpose
        End Get
        Set(ByVal value As String)
            _Purpose = value
        End Set
    End Property

    Private _TotalAmount As Double
    Public Property TotalAmount() As Double
        Get
            Return _TotalAmount
        End Get
        Set(ByVal value As Double)
            _TotalAmount = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean

        Try

            Dim strMSG As String
            Using com As New SqlCommand("SaveCA", _Connection, _Transaction)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMSG = "Update Category"
                Else
                    strMSG = "Add New Category"
                End If

                com.Parameters.Add(New SqlParameter("@CANo", CANo))
                com.Parameters.Add(New SqlParameter("@CADate", CADate))
                com.Parameters.Add(New SqlParameter("@Requestor", Requestor))
                com.Parameters.Add(New SqlParameter("@DepartmentCode", DepartmentCode))
                com.Parameters.Add(New SqlParameter("@Purpose", Purpose))
                com.Parameters.Add(New SqlParameter("@TotalAmount", TotalAmount))
                com.ExecuteNonQuery()

            End Using

            Using com As New SqlCommand("DELETE FROM tbl_100_CashAdvance_Sub WHERE CANo='" & CANo & "'", _Connection, _Transaction)
                com.CommandType = CommandType.Text
                com.ExecuteNonQuery()
            End Using

            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com As New SqlCommand("SaveCASub", _Connection, _Transaction)
                        com.CommandType = CommandType.StoredProcedure

                        com.Parameters.Add(New SqlParameter("@CANo", CANo))
                        com.Parameters.Add(New SqlParameter("@CASubNo", CANo & Format(row.Index + 1, "00")))
                        com.Parameters.Add(New SqlParameter("@Referenceno", row.Cells("colReferenceNo").Value))
                        com.Parameters.Add(New SqlParameter("@Amount", Double.Parse(row.Cells("colAmount").Value.ToString)))
                        com.ExecuteNonQuery()

                    End Using
                    If row.Cells("colReferenceNo").Value = DBLookUp("Select * from tbl_100_PR where PRNo='" & row.Cells("colReferenceNo").Value & "'", "PRNo") Then
                        Using com1 As New SqlCommand("Update tbl_100_PR_Sub set status='" & isPlaced & "' where PRNo='" & row.Cells("colReferenceNo").Value & "'", _Connection, _Transaction)
                            com1.CommandType = CommandType.Text
                            com1.ExecuteNonQuery()
                        End Using
                    Else
                        Using com1 As New SqlCommand("Update tbl_100_JR_Sub set status='" & isPlaced & "' where JRNo='" & row.Cells("colReferenceNo").Value & "'", _Connection, _Transaction)
                            com1.CommandType = CommandType.Text
                            com1.ExecuteNonQuery()
                        End Using
                    End If
                End If
            Next

            Call SaveAuditTrail(strMSG, CANo, True)

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Sub FetchRecord(ByVal strPK As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("GetCA '" & strPK & "'", con)

        Try
            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                _CANo = rdr("CANo")
                _CADate = rdr("CADate")
                _Requestor = rdr("Requestor")
                _DepartmentCode = rdr("DepartmentCode")
                _Purpose = rdr("Purpose")
                _TotalAmount = rdr("TotalAmount")
            End While

            rdr.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally


        End Try

    End Sub

End Class
