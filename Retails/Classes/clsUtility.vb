Imports System.Data.SqlClient
Public Class clsUtility
    Dim myCon As SqlConnection = New SqlConnection(cnString)
#Region "Class Variables and Declarations"
    ''For Company Category Only

    Dim cda As SqlDataAdapter = New SqlDataAdapter("Select * from tbl_000_Supplier_ComCategory", myCon)
    Dim ccb As SqlCommandBuilder = New SqlCommandBuilder(cda)
    Dim cds As DataSet = New DataSet()

    ''For supplier Payment Term Only
    Dim pda As SqlDataAdapter = New SqlDataAdapter("Select PayTermsID, PayTermsName, NoOfDays from tbl_000_Supplier_PayTerms", myCon)
    Dim pcb As SqlCommandBuilder = New SqlCommandBuilder(pda)
    Dim pds As DataSet = New DataSet()

    ''For Transportation Only
    Dim tda As SqlDataAdapter = New SqlDataAdapter("Select * from  tbl_000_Transport", myCon)
    Dim tcb As SqlCommandBuilder = New SqlCommandBuilder(tda)
    Dim tds As DataSet = New DataSet()

    ''For supplier Payment Term Only
    Dim ccda As SqlDataAdapter = New SqlDataAdapter("Select PayTermsID, PayTermsName, NoOfDays from tbl_000_Customer_PayTerms", myCon)
    Dim cccb As SqlCommandBuilder = New SqlCommandBuilder(ccda)
    Dim ccds As DataSet = New DataSet()

    ''For Internal Product supplier only
    Dim ida As SqlDataAdapter = New SqlDataAdapter("Select * from tbl_000_InternalSupplier", myCon)
    Dim icb As SqlCommandBuilder = New SqlCommandBuilder(ida)
    Dim ids As DataSet = New DataSet
   
#End Region

#Region "User-defined Methods"

    Public Sub FillInternalSupplier(ByVal srclist As DataGridView)
        ids.Clear()
        ida.Fill(ids, "tbl_000_InternalSupplier")
        srclist.DataSource = ids.Tables(0)
    End Sub

    ''Pa display sa Datagribview
    Public Sub FillCompanyCategory(ByVal srcList As DataGridView)
        cds.Clear()
        cda.Fill(cds, "tbl_000_Supplier_ComCategory")
        srcList.DataSource = cds.Tables(0)
    End Sub

    Public Sub FillPayTerm(ByVal dg As DataGridView)
        pds.Clear()
        pda.Fill(pds, "tbl_000_Supplier_PayTerms")
        dg.DataSource = pds.Tables(0)
    End Sub

    Public Sub FillTransport(ByVal dg As DataGridView)
        tds.Clear()
        tda.Fill(tds, "tbl_000_Transport")
        dg.DataSource = tds.Tables(0)
    End Sub

    Public Sub FillCustPayTerm(ByVal dg As DataGridView)
        ccds.Clear()
        ccda.Fill(ccds, "tbl_000_Customer_PayTerms")
        dg.DataSource = ccds.Tables(0)
    End Sub


    ''pag add or update sa table
    Public Function UpdateUtility() As Boolean
        Try

            cda.Update(cds, "tbl_000_Supplier_ComCategory")
            pda.Update(pds, "tbl_000_Supplier_PayTerms")
            tda.Update(tds, "tbl_000_Transport")

            ''ccda.Update(ccds, "tbl_000_Customer_PayTerms")

            MsgBox("Successfully Saved", MsgBoxStyle.Information, "Prompt")


            Return True
        Catch ex As Exception
            MsgBox("Saving unsuccessful" & "   " & ex.Message, MsgBoxStyle.Exclamation, "Error")
            Return False
        End Try
    End Function


    Public Function UpdateSalesUtility() As Boolean
        Try
            ccda.Update(ccds, "tbl_000_Customer_PayTerms")

            ida.Update(ids, "tbl_000_InternalSupplier")

            Return True
        Catch ex As Exception
            MsgBox("Saving Unsuccessful " & ex.Message, MsgBoxStyle.Exclamation, "Error")
            Return False
        End Try
    End Function

    Public Function SaveCustomerPayterm(ByVal dg As DataGridView) As Boolean
        Dim con As New SqlConnection(cnString)
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
                con.Open()
            Else
                con.Open()
            End If

            RunQuery("Delete from tbl_000_Customer_PayTerms")

            For Each row As DataGridViewRow In dg.Rows
                If row.IsNewRow = False Then
                    Using com As New SqlCommand("sp_SaveCustomerPayterms", con)
                        With com
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@PayTermsID", row.Cells("colCpayterm").Value))
                            .Parameters.Add(New SqlParameter("@PayTermsName", row.Cells("colCpaytermName").Value))
                            .Parameters.Add(New SqlParameter("@NoOfDays", CInt(row.Cells("colCnumDays").Value)))
                            .ExecuteNonQuery()
                        End With
                    End Using
                End If
            Next
            SaveCustomerPayterm = True
            MsgBox("Successfully Saved", MsgBoxStyle.Information, "Prompt")
        Catch ex As Exception
            SaveCustomerPayterm = False
            MsgBox("Saving unsuccessful" & "   " & ex.Message, MsgBoxStyle.Exclamation, "Error")
        Finally
            con.Close()
        End Try

    End Function





#End Region



End Class
