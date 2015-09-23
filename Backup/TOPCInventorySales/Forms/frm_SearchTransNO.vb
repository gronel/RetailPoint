Public Class frm_SearchTransNO
#Region "variable"

    Public param1 As String
    Public PRparent As frm_200_PRS
    Public JRparent As frm_200_JRS
    Public POparent As frm_200_POS
    Public JOparent As frm_200_JOS
    Public RRparent As frm_200_RRI
    Public ISSparent As frm_200_ISS
    Public ItemList As frm_000_ItemList
    Public OrderInquery As frm_200_OSI
    Public ProductInquery As frm_200_PSI

    Dim ptA As Point = New Point(60, 12)
    Dim ptb As Point = New Point(60, 32)

#End Region

#Region "Procedure"

    Private Sub HideControls()
        Select Case param1

            Case "PR", "JR", "PO", "JO", "RR", "Item", "ItemList"

                Label1.Text = "Category:"
                Label2.Text = "Values:"
                Label1.Show()
                Label2.Show()
                cboCategory.Show()
                txtValue.Location = ptb
                btnPicbox.Show()
            Case "Order", "Product"

                Label1.Text = "Search:"
                Label2.Visible = False
                btnPicbox.Visible = False
                cboCategory.Hide()
                txtValue.Location = ptA


        End Select


    End Sub

    ''' <summary>
    ''' Fill Datagridview
    ''' </summary>
    ''' <remarks></remarks>
    Sub filldetails()
        Me.cboCategory.Items.Clear()

        Call HideControls()

        Select Case param1
            Case "PR"
                Me.Text = "Search and select PR Control no."
                Me.dgSearchcontrol.Show()
                Me.dg2.Hide()
                Me.dgProduct.Hide()
                Me.dgOrder.Hide()
                Me.cboCategory.Items.AddRange(New Object() {"Control no.", "Date Requested", "Department", "Supplier", "Specific Code"})
                FillDataGrid(dgSearchcontrol, "sp_GetControlNo'" & "PR" & "','" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 4)
                lblCountSub.Text = dgSearchcontrol.RowCount
            Case "JR"
                Me.Text = "Search and select JR Control no."
                Me.dgSearchcontrol.Show()
                Me.dg2.Hide()
                Me.dgProduct.Hide()
                Me.dgOrder.Hide()
                Me.cboCategory.Items.AddRange(New Object() {"Control no.", "Date Requested", "Department", "Supplier", "Specific Code"})
                FillDataGrid(dgSearchcontrol, "sp_GetControlNo'" & "JR" & "','" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 4)
                lblCountSub.Text = dgSearchcontrol.RowCount
            Case "PO"
                Me.Text = "Search and select PO Control no."
                Me.dgSearchcontrol.Hide()
                Me.dg2.Show()
                Me.dgProduct.Hide()
                Me.dgOrder.Hide()
                Me.colcontrol2.HeaderText = "Control #"
                Me.DataGridViewTextBoxColumn2.HeaderText = "PO Date"
                Me.DataGridViewTextBoxColumn3.HeaderText = "Delivery Date"
                Me.DataGridViewTextBoxColumn4.HeaderText = "Supplier Name"
                Me.cboCategory.Items.AddRange(New Object() {"Control no.", "PO Date", "Delivery Date", "Supplier", "Specific Code", "Status"})
                FillDataGrid(dg2, "sp_GetControlNo'" & "PO" & "','" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 4)
                lblCountSub.Text = dg2.RowCount
            Case "JO"
                Me.Text = "Search and select JO Control no."
                Me.dgSearchcontrol.Hide()
                Me.dg2.Show()
                Me.dgProduct.Hide()
                Me.dgOrder.Hide()
                Me.colcontrol2.HeaderText = "Control #"
                Me.DataGridViewTextBoxColumn2.HeaderText = "JO Date"
                Me.DataGridViewTextBoxColumn3.HeaderText = "Delivery Date"
                Me.DataGridViewTextBoxColumn4.HeaderText = "Supplier Name"
                Me.cboCategory.Items.AddRange(New Object() {"Control no.", "JO Date", "Delivery Date", "Supplier", "Specific Code", "Status"})
                FillDataGrid(dg2, "sp_GetControlNo'" & "JO" & "','" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 4)
                lblCountSub.Text = dg2.RowCount
            Case "RR"
                Me.Text = "Search and select RR Control no."
                Me.dgSearchcontrol.Hide()
                Me.dg2.Show()
                Me.dgProduct.Hide()
                Me.dgOrder.Hide()
                Me.colcontrol2.HeaderText = "Control #"
                Me.DataGridViewTextBoxColumn2.HeaderText = "RR Date"
                Me.DataGridViewTextBoxColumn3.HeaderText = "RR Type"
                Me.DataGridViewTextBoxColumn4.HeaderText = "Reference"
                Me.cboCategory.Items.AddRange(New Object() {"Control no.", "Date", "RR Type", "Reference"})
                FillDataGrid(dg2, "sp_GetControlNo'" & "RR" & "','" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 4)
                lblCountSub.Text = dg2.RowCount
            Case "Item"
                Me.Text = "Search and select Item code"
                Me.dgSearchcontrol.Hide()
                Me.dg2.Show()
                Me.dgProduct.Hide()
                Me.dgOrder.Hide()
                Me.colcontrol2.HeaderText = "Item Code"
                Me.DataGridViewTextBoxColumn2.HeaderText = "Item Name"
                Me.DataGridViewTextBoxColumn3.HeaderText = "Category"
                Me.DataGridViewTextBoxColumn4.HeaderText = "Sub Category"
                Me.cboCategory.Items.AddRange(New Object() {"Item Code", "Item Name", "Category", "Sub Category"})
                FillDataGrid(dg2, "sp_SearchITem_for_ISS'" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 4)
                lblCountSub.Text = dg2.RowCount
            Case "ItemList"
                Me.Text = "Search and select Item code"
                Me.dgSearchcontrol.Hide()
                Me.dg2.Show()
                Me.dgProduct.Hide()
                Me.dgOrder.Hide()
                Me.colcontrol2.HeaderText = "Item Code"
                Me.DataGridViewTextBoxColumn2.HeaderText = "Item Name"
                Me.DataGridViewTextBoxColumn3.HeaderText = "Category"
                Me.DataGridViewTextBoxColumn4.HeaderText = "Sub Category"
                Me.cboCategory.Items.AddRange(New Object() {"Item Code", "Item Name", "Category", "Sub Category"})
                FillDataGrid(dg2, "sp_SearchITem_for_ISS'" & cboCategory.Text & "','" & txtValue.Text & "'", 1, 4)
                lblCountSub.Text = dg2.RowCount
            Case "Order"
                Me.Text = "Search Order Details"
                Me.dgSearchcontrol.Hide()
                Me.dg2.Hide()
                Me.dgProduct.Hide()
                Me.dgOrder.Show()  
                FillDataGrid(dgOrder, "sp_SearchProductInquery 2,'" & txtValue.Text & "'", 1, 4)

            Case "Product"
                Me.Text = "Search Order Details"
                Me.dgSearchcontrol.Hide()
                Me.dg2.Hide()
                Me.dgProduct.Show()
                Me.dgOrder.Hide()
                FillDataGrid(dgProduct, "sp_SearchProductInquery 1,'" & txtValue.Text & "'", 1, 5)
        End Select
    End Sub

#End Region


#Region "GUI"

    Private Sub frm_SearchTransNO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmSearchItems.Icon
        Call filldetails()
        ErrorProvider1.Clear()
    End Sub

    Private Sub txtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged

        If cboCategory.Text = String.Empty Then
            ErrorProvider1.SetError(cboCategory, "Category")
        Else
            Call filldetails()
        End If

        Select Case param1
            Case "Order", "Product"
                Call filldetails()
        End Select

    End Sub

    Private Sub dgSearchcontrol_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearchcontrol.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                Select Case param1
                    Case "PR"
                        PRparent.txtPRNo.Text = dgSearchcontrol.Item("colTransNo", dgSearchcontrol.CurrentRow.Index).Value
                        PRparent.EnterPR()
                        PRparent.category = cboCategory.Text
                        PRparent.value = txtValue.Text

                        If lblCountSub.Text = 0 Or lblCountSub.Text = 1 Then
                            PRparent.navigationButton(False)
                        Else
                            PRparent.navigationButton(True)
                            inc = dgSearchcontrol.Item(0, dgSearchcontrol.CurrentRow.Index).RowIndex
                            isnext = True

                        End If
                        Me.Close()
                    Case "JR"
                        JRparent.txtJRNo.Text = dgSearchcontrol.Item("colTransNo", dgSearchcontrol.CurrentRow.Index).Value
                        JRparent.EnterJR()
                        JRparent.category = cboCategory.Text
                        JRparent.value = txtValue.Text

                        If lblCountSub.Text = 0 Or lblCountSub.Text = 1 Then
                            JRparent.navigationButton(False)
                        Else
                            JRparent.navigationButton(True)
                            inc = dgSearchcontrol.Item(0, dgSearchcontrol.CurrentRow.Index).RowIndex
                            isnext = True
                        End If
                        Me.Close()

                End Select

                isFormControlNum = param1
        End Select
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        If cboCategory.SelectedValue = "" Then
            txtValue.Clear()
        End If
    End Sub

    Private Sub dg2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                Select Case param1
                    Case "PO"
                        POparent.txtPONo.Text = dg2.Item("colcontrol2", dg2.CurrentRow.Index).Value
                        POparent.POEnter()
                        POparent.category = cboCategory.Text
                        POparent.value = txtValue.Text

                        If lblCountSub.Text = 0 Or lblCountSub.Text = 1 Then
                            POparent.navigationButton(False)
                        Else
                            POparent.navigationButton(True)
                            inc = dg2.Item(0, dg2.CurrentRow.Index).RowIndex
                            isnext = True
                        End If
                        Me.Close()
                    Case "JO"
                        JOparent.txtJONo.Text = dg2.Item("colcontrol2", dg2.CurrentRow.Index).Value
                        JOparent.JOEnter()
                        JOparent.category = cboCategory.Text
                        JOparent.value = txtValue.Text

                        If lblCountSub.Text = 0 Or lblCountSub.Text = 1 Then
                            JOparent.navigationButton(False)
                        Else
                            JOparent.navigationButton(True)
                            inc = dg2.Item(0, dg2.CurrentRow.Index).RowIndex
                            isnext = True
                        End If
                        Me.Close()
                    Case "RR"
                        RRparent.txtRRNo.Text = dg2.Item("colcontrol2", dg2.CurrentRow.Index).Value
                        RRparent.selectRRNo()
                        RRparent.Category = cboCategory.Text
                        RRparent.value = txtValue.Text

                        If lblCountSub.Text = 0 Or lblCountSub.Text = 1 Then
                            RRparent.navigationButton(False)
                        Else
                            RRparent.navigationButton(True)
                            inc = dg2.Item(0, dg2.CurrentRow.Index).RowIndex
                            isnext = True
                        End If
                        Me.Close()

                    Case "Item"
                        ISSparent.cboItemCode.Text = dg2.Item("colcontrol2", dg2.CurrentRow.Index).Value
                        ISSparent.SelectITEmcode()
                        ISSparent.Category = cboCategory.Text
                        ISSparent.Value = txtValue.Text

                        If lblCountSub.Text = 0 Or lblCountSub.Text = 1 Then
                            ISSparent.navigationButton(False)
                        Else
                            ISSparent.navigationButton(True)
                            inc = dg2.Item(0, dg2.CurrentRow.Index).RowIndex
                            isnext = True
                        End If
                        Me.Close()
                    Case "ItemList"
                        With ItemList
                            .cboItemCode.Text = dg2.Item("colcontrol2", dg2.CurrentRow.Index).Value
                            .RefreshRecord("GetItemSub '" & .cboItemCode.Text & "'")
                            .category = cboCategory.Text
                            .value = txtValue.Text

                            If lblCountSub.Text = 0 Or lblCountSub.Text = 1 Then
                                .navigationButton(False)
                            Else
                                .navigationButton(True)
                                inc = dg2.Item(0, dg2.CurrentRow.Index).RowIndex
                                isnext = True
                            End If
                            Me.Close()
                        End With


                End Select
                isFormControlNum = param1
        End Select
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPicbox.Click
        cboCategory.Text = String.Empty
        txtValue.Text = String.Empty
        Call filldetails()
        ErrorProvider1.Clear()
    End Sub

    Private Sub dgOrder_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgOrder.RowsAdded
        lblCountSub.Text = CountGridRows(dgOrder)
    End Sub

    Private Sub dgOrder_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgOrder.RowsRemoved
        lblCountSub.Text = CountGridRows(dgOrder)
    End Sub
#End Region

    Private Sub dgProduct_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrder.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                With OrderInquery
                    .txtorderno.Text = dgOrder.SelectedRows(0).Cells(1).Value
                    .FetchMainDetails()
                    .category = cboCategory.Text
                    .value = txtValue.Text

                    If lblCountSub.Text = 0 Or lblCountSub.Text = 1 Then
                        .navigationButton(False)
                    Else
                        .navigationButton(True)
                        inc = dgOrder.Item(0, dgOrder.CurrentRow.Index).RowIndex
                        isnext = True
                    End If
                    Me.Close()
                End With

        End Select
    End Sub


    Private Sub dgProduct_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProduct.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                With ProductInquery
                    .txtProductCode.Text = dgProduct.SelectedRows(0).Cells(1).Value
                    .FillMainDetails()
                    .category = cboCategory.Text
                    .value = txtValue.Text

                    If lblCountSub.Text = 0 Or lblCountSub.Text = 1 Then
                        .navigationButton(False)
                    Else
                        .navigationButton(True)
                        inc = dgProduct.Item(0, dgProduct.CurrentRow.Index).RowIndex
                        isnext = True
                    End If
                    Me.Close()
                End With
        End Select
    End Sub

    Private Sub dgProduct_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgProduct.RowsAdded
        lblCountSub.Text = CountGridRows(dgProduct)
    End Sub

    Private Sub dgProduct_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgProduct.RowsRemoved
        lblCountSub.Text = CountGridRows(dgProduct)
    End Sub
End Class