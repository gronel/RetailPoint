Imports System.Data.SqlClient
Public Class tbl_100_PO
    Public Sub New()
    End Sub


    Private _poCode As String
    Private _poVendor As String
    Private _orderDte As Date
    Private _shippingDte As Date
    Private _closedDte As Date
    Private _totalCost As Decimal
    Private _status As String

    Public Property poCode() As String
        Get
            Return _poCode
        End Get
        Set(ByVal value As String)
            _poCode = value
        End Set
    End Property

    Public Property poVendor() As String
        Get
            Return _poVendor
        End Get
        Set(ByVal value As String)
            _poVendor = value
        End Set
    End Property

    Public Property orderDte() As Date
        Get
            Return _orderDte
        End Get
        Set(ByVal value As Date)
            _orderDte = value
        End Set
    End Property

    Public Property shippingDte() As Date
        Get
            Return _shippingDte
        End Get
        Set(ByVal value As Date)
            _shippingDte = value
        End Set
    End Property

    Public Property closedDte() As Date
        Get
            Return _closedDte
        End Get
        Set(ByVal value As Date)
            _closedDte = value
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

    Public Property status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property



    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean
        Try
            Dim strMsg As String

            If isEdit Then
                strMsg = "Update PO"
            Else
                strMsg = "Add New PO"
            End If

            Using cmd As New SqlCommand("sproc_100_po_master", _Connection, _Transaction)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@poCode", _poCode))
                    .Parameters.Add(New SqlParameter("@poVendor", _poVendor))
                    .Parameters.Add(New SqlParameter("@orderDte", _orderDte))
                    .Parameters.Add(New SqlParameter("@shippingDte", _shippingDte))
                    .Parameters.Add(New SqlParameter("@closedDte", _closedDte))
                    .Parameters.Add(New SqlParameter("@totalCost", NZ(_totalCost)))
                    .Parameters.Add(New SqlParameter("@status", _status))
                    .ExecuteNonQuery()

                End With
            End Using

            Using com1 As New SqlCommand("DELETE FROM tbl_100_PO_Sub Where poCode='" & _poCode & "'", _Connection, _Transaction)
                com1.CommandType = CommandType.Text
                com1.ExecuteNonQuery()
            End Using
            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)
            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using cmd As New SqlCommand("sproc_100_po_sub", _Connection, _Transaction)
                        With cmd
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@poCode", _poCode))
                            .Parameters.Add(New SqlParameter("@itemId", CInt(row.Cells("colItemId").Value)))
                            .Parameters.Add(New SqlParameter("@poQty", Integer.Parse(NZ(row.Cells("colQty").Value))))
                            .Parameters.Add(New SqlParameter("@poCost", Decimal.Parse(NZ(row.Cells("colCost").Value))))
                            .Parameters.Add(New SqlParameter("@poAmount", Decimal.Parse(NZ(row.Cells("colAmount").Value))))
                            .ExecuteNonQuery()
                        End With
                    End Using
                End If
            Next


            Call SaveAuditTrail(strMsg, _poCode, True)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub FetchRecord(ByVal pocode As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand(String.Format("SELECT     poCode, poVendor, orderDte, shippingDte, closedDte, totalCost, status " +
                                    "FROM   tbl_100_PO where (poCode='{0}')", pocode), con)

        Try

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                pocode = rdr("poCode")
                poVendor = rdr("poVendor")
                status = rdr("status")
                orderDte = rdr("orderDte")
                shippingDte = rdr("shippingDte")
                closedDte = rdr("closedDte")
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
