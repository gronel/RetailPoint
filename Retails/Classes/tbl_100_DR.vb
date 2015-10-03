Imports System.Data.SqlClient
Public Class tbl_100_DR
    Public Sub New()
    End Sub

    Private _drCode As String
    Private _pocode As String
    Private _vendor As String
    Private _drDate As Date
    Private _remarks As String
    Private _totalCost As Decimal
    Private _isPosted As Boolean
    Private _createdBy As String
    Private _createdDte As Date

    Public Property drCode() As String
        Get
            Return _drCode
        End Get
        Set(ByVal value As String)
            _drCode = value
        End Set
    End Property

    Public Property pocode() As String
        Get
            Return _pocode
        End Get
        Set(ByVal value As String)
            _pocode = value
        End Set
    End Property

    Public Property vendor() As String
        Get
            Return _vendor
        End Get
        Set(ByVal value As String)
            _vendor = value
        End Set
    End Property

    Public Property drDate() As Date
        Get
            Return _drDate
        End Get
        Set(ByVal value As Date)
            _drDate = value
        End Set
    End Property

    Public Property remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property

    Public Property totalCost() As Decimal
        Get
            Return _totalCost
        End Get
        Set(ByVal value As Decimal)
            _totalCost = value
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

    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean
        Try
            Dim strMsg As String

            If isEdit Then
                strMsg = "Update DR"
            Else
                strMsg = "Add New DR"
            End If

            Using cmd As New SqlCommand("sproc_100_dr_master", _Connection, _Transaction)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@drCode", _drCode))
                    .Parameters.Add(New SqlParameter("@pocode", _pocode))
                    .Parameters.Add(New SqlParameter("@vendor", _vendor))
                    .Parameters.Add(New SqlParameter("@drDate", _drDate))
                    .Parameters.Add(New SqlParameter("@remarks", _remarks))
                    .Parameters.Add(New SqlParameter("@totalCost", _totalCost))
                    .Parameters.Add(New SqlParameter("@isPosted", _isPosted))
                    .Parameters.Add(New SqlParameter("@createdBy", _createdBy))
                    .Parameters.Add(New SqlParameter("@createdDte", _createdDte))
                    .ExecuteNonQuery()
                End With

            End Using

            Using com1 As New SqlCommand("DELETE FROM tbl_100_DR_Sub Where drCode='" & _drCode & "'", _Connection, _Transaction)
                com1.CommandType = CommandType.Text
                com1.ExecuteNonQuery()
            End Using
            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using cmd As New SqlCommand("sproc_100_dr_sub", _Connection, _Transaction)
                        With cmd
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@drCode", _drCode))
                            .Parameters.Add(New SqlParameter("@itemId", Integer.Parse(row.Cells("colItemId").Value)))
                            .Parameters.Add(New SqlParameter("@drQty", Integer.Parse(row.Cells("colQty").Value)))
                            .Parameters.Add(New SqlParameter("@drCost", Decimal.Parse(row.Cells("colCost").Value)))
                            .Parameters.Add(New SqlParameter("@drAmount", Decimal.Parse(row.Cells("colAmount").Value)))
                            .Parameters.Add(New SqlParameter("@isPost", _isPosted))
                            .ExecuteNonQuery()
                        End With
                    End Using
                End If
            Next


            Call SaveAuditTrail(strMsg, _pocode, True)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
            Throw ex
        End Try
    End Function

    Public Sub FetchRecord(ByVal drcode As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand(String.Format("select drCode, pocode, vendor, drDate, remarks, totalCost, isPosted, createdBy, createdDte " +
                                    "FROM   tbl_100_DR where (drCode='{0}')", drcode), con)

        Try

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                drcode = rdr("drCode")
                pocode = rdr("pocode")
                vendor = rdr("vendor")
                drDate = rdr("drDate")
                remarks = rdr("remarks")
                totalCost = rdr("totalCost")


            End While

            rdr.Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally
            con.Close()

        End Try

    End Sub
End Class
