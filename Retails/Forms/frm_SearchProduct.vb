Public Class frm_SearchProduct
    Public Ordernum As String

#Region "Procedure"

#Region "Variable"
    Public customerId As String
   



#End Region

    Private Sub Fillcombo()
        Try
            FillCombobox(cboOrderno, "SELECT   distinct  tbl_100_Order.OrderNo " & _
                    "FROM         tbl_100_Order INNER JOIN " & _
                    "tbl_100_Order_Sub ON tbl_100_Order.OrderNo = tbl_100_Order_Sub.OrderNo " & _
                    "WHERE     (tbl_100_Order.CustomerCode = '" & customerId & "') AND (tbl_100_Order_Sub.isStatus = N'Processed')" & _
                    "ORDER BY tbl_100_Order.OrderNo", "tbl_100_Order", "OrderNo", "OrderNo")


            FillDataGrid(dgdetails, "GetProduct_Order '" & cboOrderno.Text & "'", 1, 9)
            Call Validatedrows()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Promp")
        End Try
    End Sub

    Private Sub Validatedrows()
        For Each row As DataGridViewRow In dgdetails.Rows
            If row.IsNewRow = False Then
                row.Cells("colQuantity").Value = FormatNumber(row.Cells("colQuantity").Value, 2)
                row.Cells("colorderbal").Value = FormatNumber(row.Cells("colorderbal").Value, 2)
            End If
        Next
    End Sub

    'Private Sub CheckProductSelected()
    '    FillItemsOrProducts(frm_100_DR.dgDetails, dgdetails, "colProductCode", "colProductCode")
    'End Sub


    Private Sub SelectItem()

        If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
            With frm_100_DR


                For i = 0 To dgdetails.RowCount - 1
                    If dgdetails.Item("colCheck", i).Value = 1 Then
                        'If CheckCodeFromDatagridView(.dgDetails, 2, dgdetails.Item("colProductCode", i).Value) And CheckCodeFromDatagridView(.dgDetails, 0, cboOrderno.Text) Then
                        '    dgdetails.Item("colCheck", i).Value = 0
                        '    MsgBox("Product Code [" & dgdetails.Item("colProductCode", i).Value & "] and [" & cboOrderno.Text & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                        '    Exit Sub
                        'End If
                        If dgdetails.Item("colCheck", i).Value = 1 Then
                            .dgDetails.Rows.Add(cboOrderno.Text, dgdetails.Item("colOrderType", i).Value, dgdetails.Item("colProductCode", i).Value)
                            .FillCode(.dgDetails.RowCount - 2, dgdetails.Item("colPriceID", i).Value)
                        End If

                    End If
                Next

                'For Each row As DataGridViewRow In dgdetails.Rows
                '    If row.IsNewRow = False Then
                '        If row.Cells("colCheck").Value = 1 Then
                '            If count = 0 Then
                '                .dgDetails.Item("colProductCode", .dgDetails.CurrentRow.Index).Value = row.Cells("colProductCode").Value
                '                .FillCode(.dgDetails.CurrentRow.Index)
                '            Else
                '                a = .dgDetails.Rows.Add(.dgDetails.Item("colOrderNo", .dgDetails.CurrentRow.Index).Value, "", row.Cells("colProductCode").Value)
                '                .FillCode(a)

                '            End If
                '            count += 1
                '        End If
                '    End If
                'Next

                checkall.Checked = False
                Me.Close()
            End With
        End If
    End Sub


    ''' <summary>
    ''' Check the item if Selected if Exist then the item will remove in the search box
    ''' </summary>
    ''' <param name="dgGrid">Target Datagridview</param>
    ''' <param name="myGrid">Source Datagridview</param>
    ''' <param name="ordername">Target Cell</param>
    ''' <param name="myordername">Source Cell</param>
    ''' <remarks></remarks>
    Private Sub FillItemsOrProducts(ByVal dgGrid As DataGridView, ByVal myGrid As DataGridView, ByVal ordername As String, ByVal myordername As String, ByVal productid As String, ByVal myproductid As String)
        Try
            For Each row As DataGridViewRow In dgGrid.Rows
                For Each myrow As DataGridViewRow In myGrid.Rows
                    If myrow.Cells(myordername).Value = row.Cells(ordername).Value And myrow.Cells(myproductid).Value = row.Cells(productid).Value Then
                        myGrid.Rows.Remove(myrow)
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox("ERROR: FillItemsOrProducts -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try


    End Sub

#End Region

#Region "GUI"

    Private Sub frm_SearchProduct_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        FillItemsOrProducts(frm_100_DR.dgDetails, dgdetails, "colOrderNo", "colOrderNum", "colProductCode", "colProductCode")
    End Sub
    Private Sub frm_SearchProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Fillcombo()

        For i = 0 To dgdetails.RowCount - 1
            With dgdetails
                .Item("colQuantity", i).Value = ConvertToMoney(.Item("colQuantity", i).Value)
                .Item("colorderbal", i).Value = ConvertToMoney(.Item("colorderbal", i).Value)
            End With
        Next
    End Sub

    Private Sub checkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkall.CheckedChanged
        For Each row As DataGridViewRow In dgdetails.Rows
            If checkall.Checked = True Then
                row.Cells("colCheck").Value = 1
                row.Cells("colCheck").ReadOnly = True
            Else
                row.Cells("colCheck").Value = 0
                row.Cells("colCheck").ReadOnly = False
            End If
        Next
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Call SelectItem()
    End Sub

    Private Sub dgdetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgdetails)
    End Sub

    Private Sub dgdetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgdetails)
    End Sub

    Private Sub cboOrderno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrderno.SelectedIndexChanged
        FillDataGrid(dgdetails, "GetProduct_Order '" & cboOrderno.Text & "'", 1, 9)
        FillItemsOrProducts(frm_100_DR.dgDetails, dgdetails, "colOrderNo", "colOrderNum", "colProductCode", "colProductCode")
        Call Validatedrows()
    End Sub

#End Region

End Class