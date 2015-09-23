Public Class frmSearchItems

#Region "Variable"
    Public frm As String
    Public strCode As String

#End Region

#Region "User Difination"
    Sub FillSearchItem()

        If frm = "Order" Then
            FillDataGrid(dg3, "SELECT ProductCode,ProductName,PartNo " & _
                        " FROM tbl_000_Product WHERE CustomerCode = '" & strCode & "' and IsStatus=1", _
                        1, 3)

        ElseIf frm = "Order_Update" Then
            FillDataGrid(dg3, "SELECT ProductCode,ProductName,PartNo " & _
                        " FROM tbl_000_Product WHERE CustomerCode = '" & strCode & "' and IsStatus=1", _
                        1, 3)

        ElseIf frm = "Product" Then
            FillDataGrid(dgSearchItems, "GetSearchItemsForProduct'" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 4)
            lblCountSub.Text = dgSearchItems.RowCount

        Else
            FillDataGrid(dgSearchItems, "GetSearchItems'" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 5)
            lblCountSub.Text = dgSearchItems.RowCount
        End If
        FillSearchItemsOrProducts()
    End Sub

    Sub FillDataGridView()
        Dim count As Integer
        Try
            If frm = "PR" Then
                If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                    With frm_100_PR
                        For i = 0 To dgSearchItems.RowCount - 1
                            If dgSearchItems.Item("colCheckAdd", i).Value = 1 Then
                                If CheckCodeFromDatagridView(.dgDetails, 0, dgSearchItems.Item("colSpecificCode", i).Value) Then
                                    dgSearchItems.Item("colCheckAdd", i).Value = 0
                                    MsgBox("Specific Code [" & dgSearchItems.Item("colSpecificCode", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                                    Exit Sub
                                End If
                                .dgDetails.Rows.Add(dgSearchItems.Item("colSpecificCode", i).Value)
                                .fillCode(.dgDetails.RowCount - 2)
                            End If
                        Next
                    End With
                End If
            ElseIf frm = "JR" Then
                If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                    With frm_100_JR
                        For i = 0 To dgSearchItems.RowCount - 1
                            If dgSearchItems.Item("colCheckAdd", i).Value = 1 Then
                                If CheckCodeFromDatagridView(.dgDetails, 0, dgSearchItems.Item("colSpecificCode", i).Value) Then
                                    dgSearchItems.Item("colCheckAdd", i).Value = 0
                                    MsgBox("Specific Code [" & dgSearchItems.Item("colSpecificCode", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                                    Exit Sub
                                End If
                                .dgDetails.Rows.Add(dgSearchItems.Item("colSpecificCode", i).Value)
                                .fillCode(.dgDetails.RowCount - 2)
                            End If
                        Next
                    End With
                End If
            ElseIf frm = "Order" Then
                If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                    With frm_100_Order
                        For i = 0 To dg3.RowCount - 1
                            If dg3.Item("colcheck3", i).Value = 1 Then
                                If CheckCodeFromDatagridView(.dgDetails, 0, dg3.Item("colproductNo", i).Value) Then
                                    dg3.Item("colcheck3", i).Value = 0
                                    MsgBox("Product Code [" & dg3.Item("colproductNo", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                                    Exit Sub
                                End If
                                .dgDetails.Rows.Add(dg3.Item("colproductNo", i).Value)
                                .FillCode(.dgDetails.RowCount - 2)
                                .ComputeRows()
                            End If
                        Next
                    End With
                End If
            ElseIf frm = "Order_Update" Then
                If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                    With frm_100_Order_Edit
                        For i = 0 To dg3.RowCount - 1
                            If dg3.Item("colcheck3", i).Value = 1 Then
                                If CheckCodeFromDatagridView(.dgDetails, 0, dg3.Item("colproductNo", i).Value) Then
                                    dg3.Item("colcheck3", i).Value = 0
                                    MsgBox("Product Code [" & dg3.Item("colproductNo", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                                    Exit Sub
                                End If
                                .dgDetails.Rows.Add("Add", "Edit", dg3.Item("colproductNo", i).Value)
                                .FillCode(.dgDetails.RowCount - 2)
                                .ComputeRows()
                            End If
                        Next
                    End With
                End If
                ''2011.09.05
            ElseIf frm = "Product" Then
                If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                    With frm_000_Product
                        For i = 0 To dgSearchItems.RowCount - 1
                            If dgSearchItems.Item("colCheckAdd", i).Value = 1 Then
                                If CheckCodeFromDatagridView(.dgProductParts, 0, dgSearchItems.Item("colSpecificCode", i).Value) Then
                                    dgSearchItems.Item("colCheckAdd", i).Value = 0
                                    MsgBox("Specific Code [" & dgSearchItems.Item("colSpecificCode", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                                    Exit Sub
                                End If
                                .dgProductParts.Rows.Add(dgSearchItems.Item(2, i).Value)
                                .FillCode(.dgProductParts.RowCount - 2, frm)
                            End If
                        Next
                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:FillDataGridView -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    ''09.20.2011
    Sub FillSearchItemsOrProducts()

        Select Case frm
            Case "Product"
                FillItemsOrProducts(frm_000_Product.dgProductParts, dgSearchItems, "colItemSpecificCode", "colSpecificCode")
            Case "Material"
                FillItemsOrProducts(frm_000_Product.dgMaterial, dgSearchItems, "colSpecificCode", "colSpecificCode")
            Case "DR"
                FillItemsOrProducts(frm_100_DR.dgDetails, dgSearchProduct, "colProductCode", "colProductCode")
            Case "Order"
                FillItemsOrProducts(frm_100_Order.dgDetails, dgSearchProduct, "colproductcode", "colProductCode")
            Case "PR"
                FillItemsOrProducts(frm_100_PR.dgDetails, dgSearchItems, "colSpecificCode", "colSpecificCode")
                lblCountSub.Text = dgSearchItems.RowCount
            Case "JR"
                FillItemsOrProducts(frm_100_JR.dgDetails, dgSearchItems, "colSpecificCode", "colSpecificCode")
                lblCountSub.Text = dgSearchItems.RowCount
            Case "Order_Update"
                FillItemsOrProducts(frm_100_Order_Edit.dgDetails, dgSearchProduct, "colproductcode", "colProductCode")
        End Select
    End Sub
#End Region

#Region "GUI"
    Private Sub txtValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
        If cboCategory.Text = String.Empty Then
            ErrorProvider1.SetError(cboCategory, "Select category.")
        Else
            FillSearchItem()
        End If
    End Sub

   

    Private Sub frmSearchItems_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call FillSearchItemsOrProducts()
    End Sub

    Private Sub frmSearchItems_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GroupBox1.Dock = DockStyle.None
        ShowControls(True)
    End Sub

    Private Sub frmSearchItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub frmSearchItems_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If frm = "Order" Then
            dg3.Visible = True
            dgSearchProduct.Visible = False
            dgSearchItems.Visible = False
            GroupBox1.Dock = DockStyle.Fill

        ElseIf frm = "Order_Update" Then
            dg3.Visible = True
            dgSearchProduct.Visible = False
            dgSearchItems.Visible = False
            GroupBox1.Dock = DockStyle.Fill
        ElseIf frm = "DR" Then
            dg3.Visible = False
            dgSearchProduct.Visible = True
            dgSearchItems.Visible = False
        Else
            dgSearchProduct.Visible = False
            dgSearchItems.Visible = True
            dg3.Visible = False

        End If
        FillSearchItem()
    End Sub



    ''2011.09.06
    Public Sub ShowControls(ByVal bolValue As Boolean)
        Label1.Visible = bolValue
        Label2.Visible = bolValue
        txtValue.Visible = bolValue
        cboCategory.Visible = bolValue
    End Sub

    Private Sub dgSearchProduct_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        lblCountSub.Text = CountGridRows(dgSearchProduct)
    End Sub

    Private Sub dgSearchProduct_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        lblCountSub.Text = CountGridRows(dgSearchProduct)
    End Sub
   
    Private Sub chckall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckall.CheckedChanged
        ''2011.09.06
        If dgSearchProduct.Visible Then
            For Each row As DataGridViewRow In dgSearchProduct.Rows
                If chckall.Checked = True Then
                    row.Cells("colChkAdd").Value = 1
                    row.Cells("colChkAdd").ReadOnly = True
                Else
                    row.Cells("colChkAdd").Value = 0
                    row.Cells("colChkAdd").ReadOnly = False
                End If
            Next
            ''=========

        ElseIf dg3.Visible Then
            For Each row As DataGridViewRow In dg3.Rows
                If chckall.Checked = True Then
                    row.Cells("colcheck3").Value = 1
                    row.Cells("colcheck3").ReadOnly = True
                Else
                    row.Cells("colcheck3").Value = 0
                    row.Cells("colcheck3").ReadOnly = False
                End If
            Next

        Else
            For i = 0 To dgSearchItems.RowCount - 1
                If chckall.Checked = True Then
                    dgSearchItems.Item("colCheckAdd", i).Value = 1 '' check all row if true
                    dgSearchItems.Item("colCheckAdd", i).ReadOnly = True
                Else
                    dgSearchItems.Item("colCheckAdd", i).Value = 0 ''uncheck all row if false
                    dgSearchItems.Item("colCheckAdd", i).ReadOnly = False
                End If
            Next



        End If
    End Sub


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        FillDataGridView()
        chckall.Checked = False
        Me.Dispose()
    End Sub

    Private Sub dg3_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg3.RowsAdded
        lblCountSub.Text = CountGridRows(dg3)
    End Sub

    Private Sub dg3_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dg3.RowsRemoved
        lblCountSub.Text = CountGridRows(dg3)
    End Sub
#End Region

    
   
    Private Sub dgSearchItems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearchItems.CellContentClick

    End Sub
End Class