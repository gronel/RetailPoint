Imports System.Data.SqlClient

Public Class tbl_000_Location

#Region "Class Variables and Declarations"

    Dim myConn As SqlConnection = New SqlConnection(cnString)
    Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT Id, location, description FROM tbl_000_Location ORDER BY location", myConn)
    Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet()

#End Region

#Region "User-defined Methods"

    Public Sub FillWarehouseGrid(ByVal srcList As DataGridView)
        ds.Clear()
        da.Fill(ds, "tbl_000_Location")
        srcList.DataSource = ds.Tables(0)
    End Sub

    Public Function UpdateWarehouseGrid() As Boolean
        Try

            da.Update(ds, "tbl_000_Location")
            MsgBox("Successfully Saved", MsgBoxStyle.Information, "Larehouse")
            Return True
        Catch ex As Exception
            MsgBox("Saving unsuccessful" & "   " & ex.Message, MsgBoxStyle.Exclamation, "Error")
            Return False
        End Try
    End Function

#End Region

End Class
