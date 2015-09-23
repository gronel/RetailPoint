Imports System.Data.SqlClient
Public Class tbl_000_ExchangeRate

    Private _ExchangeRateCode As String
    Private _ExrateDescription As String

    Public Property ExhangeRateCode() As String
        Get
            Return _ExchangeRateCode
        End Get
        Set(ByVal value As String)
            _ExchangeRateCode = value
        End Set
    End Property

    Public Property ExrateDescription() As String
        Get
            Return _ExrateDescription
        End Get
        Set(ByVal value As String)
            _ExrateDescription = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean, Optional ByVal dgGrid As DataGridView = Nothing) As Boolean
        Dim con As New SqlConnection(cnString)
        Try
            Dim strMsg As String

            If isEdit = True Then
                strMsg = "Update Exrate Code " & _ExchangeRateCode
            Else
                strMsg = "Add Exrate Code " & _ExchangeRateCode
            End If


            ''0 clean frist the data
            RunQuery("Delete from tbl_000_ExchangeRate_Sub where code='" & _ExchangeRateCode & "'")
            RunQuery("Delete from tbl_000_ExchangeRate where Exratecode='" & _ExchangeRateCode & "'")


            ''1. save main Details
            Using cmd As New SqlCommand("SaveExchangeRate", _Connection, _Transaction)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@What", 0))
                    .Parameters.Add(New SqlParameter("@Exratecode", _ExchangeRateCode))
                    .Parameters.Add(New SqlParameter("@Currencyconversion  ", _ExrateDescription))
                    .ExecuteNonQuery()
                End With
            End Using

            ''2. save sub details
            For Each row As DataGridViewRow In dgGrid.Rows
                If row.IsNewRow = False Then
                    Using cmd As New SqlCommand("SaveExchangeRate", _Connection, _Transaction)
                        With cmd
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@What", 1))
                            .Parameters.Add(New SqlParameter("@Exratecode", _ExchangeRateCode))
                            .Parameters.Add(New SqlParameter("@ExrateDetailedCode ", row.Cells(0).Value))
                            .Parameters.Add(New SqlParameter("@ExrateValue", CDbl(row.Cells(1).Value)))
                            .ExecuteNonQuery()
                        End With
                    End Using
                End If
            Next


            Call SaveAuditTrail(strMsg, _ExchangeRateCode, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
            Return False
        Finally
            con.Close()
        End Try
    End Function

    'Public Sub FetchRecord(ByVal strCode As String)
    '    SQL = "SELECT     tbl_ConversionType.Cid, tbl_ConversionType.ConversionType, tbl_000_ExchangeRate.CurrencyFrom, tbl_000_ExchangeRate.CurrencyTo " & _
    '          "FROM         tbl_000_ExchangeRate INNER JOIN " & _
    '          "tbl_ConversionType ON tbl_000_ExchangeRate.Cid = tbl_ConversionType.Cid " & _
    '          "WHERE     (tbl_ConversionType.Cid = '" & strCode & "')"
    '    Dim con As New SqlConnection(cnString)
    '    Dim com As New SqlCommand(SQL, con)
    '    Dim rdr As SqlDataReader

    '    Try
    '        con.Open()
    '        rdr = com.ExecuteReader(CommandBehavior.CloseConnection)

    '        While rdr.Read
    '            Cid = rdr("Cid")
    '            ExchangeRateCode = rdr("ConversionType")
    '            CurrencyFrom = rdr("CurrencyFrom")
    '            CurrencyTo = rdr("CurrencyTo")
    '        End While

    '        rdr.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR!")
    '    End Try
    'End Sub
End Class
