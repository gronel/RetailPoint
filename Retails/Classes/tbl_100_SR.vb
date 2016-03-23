Imports System.Data.SqlClient
Public Class tbl_100_SR
    Public Sub New()
    End Sub

    Private _SRId As String
    Private _Customer As String
    Private _Cash As Decimal
    Private _TotalAmt As Decimal
    Private _Change As Decimal
    Private _CreatedBy As String
    Private _CreatedDte As Date

    Public Property SRId() As String
        Get
            Return _SRId
        End Get
        Set(ByVal value As String)
            _SRId = value
        End Set
    End Property

    Public Property Customer() As String
        Get
            Return _Customer
        End Get
        Set(ByVal value As String)
            _Customer = value
        End Set
    End Property

    Public Property Cash() As Decimal
        Get
            Return _Cash
        End Get
        Set(ByVal value As Decimal)
            _Cash = value
        End Set
    End Property

    Public Property TotalAmt() As Decimal
        Get
            Return _TotalAmt
        End Get
        Set(ByVal value As Decimal)
            _TotalAmt = value
        End Set
    End Property

    Public Property Change() As Decimal
        Get
            Return _Change
        End Get
        Set(ByVal value As Decimal)
            _Change = value
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

    Public Property CreatedDte() As Date
        Get
            Return _CreatedDte
        End Get
        Set(ByVal value As Date)
            _CreatedDte = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean
        Try
            Dim strMsg As String

            If isEdit Then
                strMsg = "Update Sales Receipt"
            Else
                strMsg = "Add New Sales Receipt"
            End If

            Using cmd As New SqlCommand("sproc_100_sr_master", _Connection, _Transaction)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@SRId", _SRId))
                    .Parameters.Add(New SqlParameter("@Customer", _Customer))
                    .Parameters.Add(New SqlParameter("@Cash", _Cash))
                    .Parameters.Add(New SqlParameter("@TotalAmt", _TotalAmt))
                    .Parameters.Add(New SqlParameter("@Change", _Change))
                    .Parameters.Add(New SqlParameter("@CreatedBy", _CreatedBy))
                    .Parameters.Add(New SqlParameter("@CreatedDte", _CreatedDte))

                    .ExecuteNonQuery()
                End With

            End Using

            Using com1 As New SqlCommand("DELETE FROM tbl_100_SR_Sub Where SRId='" & _SRId & "'", _Connection, _Transaction)
                com1.CommandType = CommandType.Text
                com1.ExecuteNonQuery()
            End Using
            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using cmd As New SqlCommand("sproc_100_sr_sub", _Connection, _Transaction)
                        With cmd
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@SRId", _SRId))
                            .Parameters.Add(New SqlParameter("@ItemID", CInt(row.Cells("colitemId2").Value)))
                            .Parameters.Add(New SqlParameter("@Qty", CInt(row.Cells("Qty").Value)))
                            .Parameters.Add(New SqlParameter("@Cost", Decimal.Parse(row.Cells("colUnitPrice2").Value)))
                            .Parameters.Add(New SqlParameter("@SubAmt", Decimal.Parse(row.Cells("Subtotal").Value)))
                            .ExecuteNonQuery()

                        End With
                    End Using
                End If
            Next


            Call SaveAuditTrail(strMsg, _SRId, True)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GenerateID() As String
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("SELECT MAX(convert(int,SRId)) as ID FROM tbl_100_SR ORDER BY ID", con)

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
