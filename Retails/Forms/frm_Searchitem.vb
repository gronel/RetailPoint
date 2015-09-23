Public Class frm_Searchitem
#Region "Variable"
    Public frmparent As frm_100_PO
    Public frmjoparent As frm_100_JO
    Public x, frm, y, currencytype As String
    Public RR_order As String
#End Region
#Region "Procedure"
    ''' <summary>
    ''' Fill the Datagridview
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillSearchItem()
        If frm = "AR" Then
            dgDetailsAR.Visible = True
            dgSearchItems.Visible = False
        Else
            dgDetailsAR.Visible = False
            dgSearchItems.Visible = True
        End If
        Me.Text = "Search " + x + " Item(s)"
        Try
            If frm = "PO" Then
                Me.lblcontrolnum.Show()
                Me.cbocontrolnum.Show()
                Me.lblcontrolnum.Text = "PRNO"
                Me.colRRQTY.DataPropertyName = "ReqQTY"
                SQL = "SELECT tbl_100_PR.PRNo " + _
                      "FROM tbl_100_PR_Sub INNER JOIN " + _
                      "tbl_100_PR ON tbl_100_PR_Sub.PRNo = tbl_100_PR.PRNo " + _
                      "WHERE     (tbl_100_PR.PRType = 'PO') and (tbl_100_PR.SupplierID='" + frmparent.cbosupplier.Text + "') " + _
                      "and (tbl_100_PR.Currencytype='" + frmparent.cboCurrency.Text + "') and (tbl_100_PR_Sub.Status='" + isPending + "') GROUP BY tbl_100_PR.PRNo"
                '-->load data in combobox
                FillCombobox(cbocontrolnum, SQL, "tbl_100_PR_Sub", "PRNo", "PRNo")
                '-->load data in datagridview
                FillDataGrid(dgSearchItems, "sp_GetSearchItem'" & "SearchPR" & "','" & cbocontrolnum.SelectedValue & "','" & isPending & "'", 1, 6)

            ElseIf frm = "JO" Then
                Me.lblcontrolnum.Show()
                Me.cbocontrolnum.Show()
                Me.lblcontrolnum.Text = "JRNO"
                Me.colRRQTY.DataPropertyName = "ReqQTY"
                SQL = "SELECT tbl_100_JR.JRNo " + _
                      "FROM tbl_100_JR_Sub INNER JOIN " + _
                      "tbl_100_JR ON tbl_100_JR_Sub.JRNo = tbl_100_JR.JRNo " + _
                      "WHERE     (tbl_100_JR.JRType = 'JO') and (tbl_100_JR.SupplierID='" + frmjoparent.cbosupplier.Text + "') " + _
                      "and (tbl_100_JR.Currencytype='" + frmjoparent.cbocurrency.Text + "') and (tbl_100_JR_Sub.Status='" + isPending + "')GROUP BY tbl_100_JR.JRNo"
                '-->load data in combobox
                FillCombobox(cbocontrolnum, SQL, "tbl_100_JR_Sub", "JRNo", "JRNo")
                '-->load data in datagridview
                FillDataGrid(dgSearchItems, "sp_GetSearchItem'" & "SearchJR" & "','" & cbocontrolnum.SelectedValue & "','" & isPending & "'", 1, 5)

            ElseIf frm = "Cash" Then
                Me.lblcontrolnum.Hide()
                Me.cbocontrolnum.Hide()
                Me.colRRQTY.DataPropertyName = "RRQTY"
                '-->load data in datagridview
                FillDataGrid(dgSearchItems, "sp_GetSearchItem'" & "Get_PRItemAndJRItem" & "','" & x & "'", 1, 6)

            ElseIf frm = "NOtcash" Then
                Me.lblcontrolnum.Hide()
                Me.cbocontrolnum.Hide()
                Me.colRRQTY.Visible = True
                If y = "PO" Then
                    '-->load data in datagridview
                    FillDataGrid(dgSearchItems, "sp_GetSearchItem'" & "PO_Item_Sub" & "','" & x & "'", 1, 6)
                ElseIf y = "JO" Then
                    '-->load data in datagridview
                    FillDataGrid(dgSearchItems, "sp_GetSearchItem'" & "JO_Item_Sub" & "','" & x & "'", 1, 6)
                End If
            ElseIf frm = "AR" Then
                '-->load data in datagridview

                lblcontrolnum.Text = "WR #:"
                FillCombobox(cbocontrolnum, "Get_WRNO", "tbl_100_WR_Sub", "WRNo", "WRNo")
                FillCombobox(cbocontrolnum, "Get_WRNO", "tbl_100_WR_Sub", "WRNo", "WRNo")
                cbocontrolnum.SelectedIndex = -1

                'FillDataGrid(dgSearchItems, "sp_GetSearchItem'" & "Get_WR_SearchItem" & "','" & x & "'", 1, 5)
                FillGrid(dgDetailsAR, "sp_GetSearchItem'" & "Get_WR_SearchItem" & "','" & cbocontrolnum.Text & "'", "tbl_100_WR_sub")

            End If


            Call Validatedg(frm)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub


    Private Sub Validatedg(ByVal frm As String)
        Select Case frm
            Case "PO", "Cash", "NOtcash"
                For Each row As DataGridViewRow In dgSearchItems.Rows
                    If row.IsNewRow = False Then
                        row.Cells("colRRQTY").Value = FormatNumber(row.Cells("colRRQTY").Value, CInt(row.Cells("coldec").Value))
                    End If
                Next

        End Select



    End Sub

    ''' <summary>
    ''' Select need item
    ''' </summary>
    ''' <remarks></remarks>
    Sub ok()
        Dim c As Integer
        Try
            If frm = "PO" Then
                If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                    With frm_100_PO

                        For i = 0 To dgSearchItems.RowCount - 1
                            If dgSearchItems.Item("colCheckAdd", i).Value = 1 Then
                                If CheckCodeFromDatagridView(.dgDetails, 2, dgSearchItems.Item("colSpecificCode", i).Value) Then
                                    dgSearchItems.Item("colCheckAdd", i).Value = 0
                                    MsgBox("Specific Code [" & dgSearchItems.Item("colSpecificCode", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                                    Exit Sub
                                End If
                                If dgSearchItems.Item("colCheckAdd", i).Value = 1 Then
                                    .dgDetails.Rows.Add(cbocontrolnum.Text, dgSearchItems.Item("colSpecificCode", i).Value)
                                End If
                                .fillCode(.dgDetails.RowCount - 2)
                            End If
                        Next
                    End With
                    Me.Close()
                End If
            ElseIf frm = "JO" Then
                If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                    With frmjoparent
                        For i = 0 To dgSearchItems.RowCount - 1
                            If dgSearchItems.Item("colCheckAdd", i).Value = 1 Then
                                If CheckCodeFromDatagridView(.dgDetails, 1, dgSearchItems.Item("colSpecificCode", i).Value) Then
                                    dgSearchItems.Item("colCheckAdd", i).Value = 0
                                    MsgBox("Specific Code [" & dgSearchItems.Item("colSpecificCode", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                                    Exit Sub
                                End If
                                If dgSearchItems.Item("colCheckAdd", i).Value = 1 Then
                                    .dgDetails.Rows.Add(cbocontrolnum.Text, dgSearchItems.Item("colSpecificCode", i).Value)
                                End If
                                .fillCode(.dgDetails.RowCount - 2)
                            End If
                        Next
                    End With
                    Me.Close()
                End If
            ElseIf frm = "Cash" Then
                If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                    With frm_100_RR
                        Dim a As Integer
                        For i = 0 To dgSearchItems.RowCount - 1
                            If dgSearchItems.Item("colCheckAdd", i).Value = 1 Then
                                If CheckCodeFromDatagridView(.dgDetails, 3, dgSearchItems.Item("colSpecificCode", i).Value) Then
                                    dgSearchItems.Item("colCheckAdd", i).Value = 0
                                    MsgBox("Specific Code [" & dgSearchItems.Item("colSpecificCode", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                                    Exit Sub
                                End If
                                If dgSearchItems.Item("colCheckAdd", i).Value = 1 Then
                                    If c = 0 Then

                                        .dgDetails.Item("colSpecificCode", .dgDetails.CurrentCell.RowIndex).Value() = dgSearchItems.Item("colSpecificCode", i).Value

                                        If y = "Cash" Then

                                            .fillCode(.dgDetails.CurrentCell.RowIndex)

                                        Else
                                            ' .cboRefNo.SelectedValue = cbono.Text
                                            .fillCode(.dgDetails.CurrentCell.RowIndex)
                                        End If

                                    Else
                                        a = .dgDetails.Rows.Add("", "", "", "", dgSearchItems.Item("colSpecificCode", i).Value)
                                        If y = "PO" Or y = "JO" Then
                                            .fillCode(a)
                                        Else
                                            .fillCode(a)
                                        End If
                                    End If
                                    c = c + 1
                                End If
                            End If
                        Next
                    End With
                    Me.Close()
                End If
            ElseIf frm = "NOtcash" Then
                If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                    With frm_100_RR
                        For i = 0 To dgSearchItems.RowCount - 1
                            If dgSearchItems.Item("colCheckAdd", i).Value = 1 Then
                                If CheckCodeFromDatagridView(.dgDetails, 0, dgSearchItems.Item("colSpecificCode", i).Value) Then
                                    dgSearchItems.Item("colCheckAdd", i).Value = 0
                                    MsgBox("Specific Code [" & dgSearchItems.Item("colSpecificCode", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                                    Exit Sub
                                End If
                                .dgDetails.Rows.Add("", "", "", "", dgSearchItems.Item("colSpecificCode", i).Value)
                                .fillCode(.dgDetails.RowCount - 2)
                                Me.Close()
                            End If
                        Next
                    End With
                End If
            ElseIf frm = "AR" Then
                If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                    With frm_100_AR
                        For i = 0 To dgDetailsAR.RowCount - 1
                            If dgDetailsAR.Item("CheckAR", i).Value = 1 Then
                                If CheckCodeFromDatagridView(.dgDetails, 1, dgDetailsAR.Item("colSpecificCodeAR", i).Value) Then
                                    dgDetailsAR.Item("CheckAR", i).Value = 0
                                    MsgBox("Specific Code [" & dgDetailsAR.Item("colSpecificCodeAR", i).Value & "] already exists in the grid.", MsgBoxStyle.Exclamation, "Duplicate Code")
                                    Exit Sub
                                End If
                                If dgDetailsAR.Item("CheckAR", i).Value = 1 Then
                                    .dgDetails.Rows.Add(cbocontrolnum.Text, dgDetailsAR.Item("colSpecificCodeAR", i).Value)
                                End If
                                .fillCode(.dgDetails.RowCount - 2)
                              
                            End If
                        Next
                    End With
                    dgDetailsAR.Visible = False
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
    ''' <summary>
    ''' para kani inig select nimo sa item human ma delete cya kung mo balik ka 
    ''' </summary>
    ''' <param name="dgGrid">Datagridview na ako sublan</param>
    ''' <param name="myGrid">Datagridview na ako pilian</param>
    ''' <param name="colNameCode">Column sa datagridview na ako sudlan human ko mka pili</param>
    ''' <param name="mycolNameCode">Column sa datagridview na ako pilian </param>
    ''' <remarks></remarks>
    Sub FillItems(ByVal dgGrid As DataGridView, ByVal myGrid As DataGridView, ByVal colNameCode As String, ByVal mycolNameCode As String)
        For Each row As DataGridViewRow In dgGrid.Rows
            For Each myrow As DataGridViewRow In myGrid.Rows
                If myrow.Cells(mycolNameCode).Value = row.Cells(colNameCode).Value Then
                    myGrid.Rows.Remove(myrow)
                End If
            Next
        Next
    End Sub
    ''' <summary>
    ''' Conpare the item in Datagrid if exist then delete the row
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillSearchItemsOrProducts()

        Select Case frm
            Case "NOtcash"
                FillItems(frm_100_RR.dgDetails, dgSearchItems, "colSpecificCode", "colSpecificCode")
                'Case "AR"
                '    FillItems(frm_100_AR_.dgDetails, dgDetailsAR, "colSpecificCode", "colSpecificCodeAR")
                '    lblcontrolnum.Visible = True
                '    cbocontrolnum.Visible = True

            Case "Cash"
                FillItems(frm_100_RR.dgDetails, dgSearchItems, "colSpecificCode", "colSpecificCode")

                'Case "DR"
                '    FillItems(frm_100_DR.dgDetails, dgSearchProduct, "colProductCode", "colProductCode")
                'Case "Order"
                '    FillItems(frm_100_Order.dgDetails, dgSearchProduct, "colproductcode", "colProductCode")
        End Select
    End Sub
#End Region

#Region "GUI"
    Private Sub frm_Searchitem_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        FillSearchItemsOrProducts()
    End Sub

    Private Sub frm_Searchitem_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cbocontrolnum.Text = String.Empty
    End Sub


    Private Sub frm_Searchitem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call FillSearchItem()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Call ok()
        checkall.Checked = False
    End Sub
    Private Sub checkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkall.CheckedChanged
        If checkall.Checked = True Then
            For z = 0 To dgDetailsAR.RowCount - 1
                dgDetailsAR.Item(0, z).Value = 1
                dgDetailsAR.Item(0, z).ReadOnly = True
            Next
            For i = 0 To dgSearchItems.RowCount - 1
                dgSearchItems.Item("colCheckAdd", i).Value = 1
                dgSearchItems.Item("colCheckAdd", i).ReadOnly = True
            Next
        Else
            For i = 0 To dgSearchItems.RowCount - 1
                dgSearchItems.Item("colCheckAdd", i).Value = 0
                dgSearchItems.Item("colCheckAdd", i).ReadOnly = False
            Next
            For z = 0 To dgDetailsAR.RowCount - 1
                dgDetailsAR.Item(0, z).Value = 0
                dgDetailsAR.Item(0, z).ReadOnly = False
            Next
        End If
    End Sub
    Private Sub dgSearchItems_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgSearchItems.RowsAdded
        lblCountSub.Text = CountGridRows(dgSearchItems)
    End Sub
    Private Sub dgSearchItems_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgSearchItems.RowsRemoved
        lblCountSub.Text = CountGridRows(dgSearchItems)
    End Sub
    
    Private Sub cbocontrolnum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocontrolnum.SelectedIndexChanged
        Select Case frm
            Case "PO"
                If cbocontrolnum.Text = "System.Data.DataRowView" Then
                Else
                    FillDataGrid(dgSearchItems, "sp_GetSearchItem'" & "SearchPR" & "','" & cbocontrolnum.Text & "','" & isPending & "'", 1, 4)
                End If
            Case "JO"
                If cbocontrolnum.Text = "System.Data.DataRowView" Then
                Else
                    FillDataGrid(dgSearchItems, "sp_GetSearchItem'" & "SearchJR" & "','" & cbocontrolnum.Text & "','" & isPending & "'", 1, 4)
                End If
            Case "AR"
                If cbocontrolnum.Text = "System.Data.DataRowView" Then
                Else

                    FillGrid(dgDetailsAR, "sp_GetSearchItem'" & "Get_WR_SearchItem" & "','" & cbocontrolnum.Text & "'", "tbl_100_WR_sub")
                    Me.Text = "Search " + cbocontrolnum.Text + " Item(s)"
                End If
        End Select
    End Sub

    Private Sub dgDetailsAR_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetailsAR.RowsAdded
        lblCountSub.Text = CountGridRows(dgDetailsAR)
    End Sub

    Private Sub dgDetailsAR_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetailsAR.RowsRemoved
        lblCountSub.Text = CountGridRows(dgDetailsAR)
    End Sub

#End Region
End Class