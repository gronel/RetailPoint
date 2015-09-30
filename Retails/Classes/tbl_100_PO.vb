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

    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean
        Try
            Dim strMsg As String

            If isEdit Then
                strMsg = "Update PO"
            Else
                strMsg = "Add New PO"
            End If

            Using cmd As New SqlCommand("sp_savetbl_100_PO", _Connection, _Transaction)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@poCode", _poCode))
                    .Parameters.Add(New SqlParameter("@poVendor", _poVendor))
                    .Parameters.Add(New SqlParameter("@orderDte", _orderDte))
                    .Parameters.Add(New SqlParameter("@shippingDte", _shippingDte))
                    .Parameters.Add(New SqlParameter("@closedDte", _closedDte))
                    .Parameters.Add(New SqlParameter("@totalCost", _totalCost))
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
                    Using cmd As New SqlCommand("sp_savetbl_100_PO_Sub", _Connection, _Transaction)
                        With cmd
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@poCode", _poCode))
                            .Parameters.Add(New SqlParameter("@itemId", row.Cells("colSpecificCode").Value))
                            .Parameters.Add(New SqlParameter("@poQty", row.Cells("colSpecificCode").Value))
                            .Parameters.Add(New SqlParameter("@poCost", row.Cells("colSpecificCode").Value))
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
End Class
