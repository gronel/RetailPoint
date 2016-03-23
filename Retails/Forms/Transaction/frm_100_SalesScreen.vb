Imports RetailPoint.clsPublic

Public Class frm_100_SalesScreen


#Region "Variable"

    Implements IBPSCommand

    Dim strDataGridSearchValue As String
    Dim UserID As Integer
    Dim bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Dim strName As String
    Dim ItemIdsub As Integer
    Private _UserPic As Byte()
    Private _EmpName As String

#End Region

    Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
        Select Case strCmd
            Case "New"
                '  NewRecord()
            Case "Edit"
                'EditRecord()
            Case "Delete"
                'DeleteRecord()
            Case "Save"
                ' SaveRecord()
            Case "Cancel"
                If vbYes = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirm") Then
                    doCancel()
                End If
            Case "Refresh"
                ' RefreshRecord()
        End Select

    End Sub

    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        ActivateCommands(FormState.LoadState)
        Me.Close()
    End Sub

    Sub ActivateCommands(ByVal frmState As clsPublic.FormState)
        bolFormState = frmState

        With MainForm
            Select Case frmState
                Case FormState.AddState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                Case FormState.EditState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = True
                    .tsCancel.Enabled = True
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = False
                Case FormState.ViewState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = True
                    .tsDelete.Enabled = True
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
                Case FormState.LoadState
                    .tsNew.Enabled = True
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = True
                    .tsClose.Enabled = True
            End Select

        End With
    End Sub

    Sub ComputeAllRows()
        Dim sum As Double
        With dgList2
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("Subtotal", i).Value)
            Next
            lblAmoutDue.Text = String.Format("{0:N2}", (NZ(sum)))
        End With
    End Sub

    Sub getItemDetails()

        Dim item As New tbl_000_Item

        Dim itemcode As String
        Try
            itemcode = dglist1.Item("colItemCode", dglist1.CurrentRow.Index).Value


            With item
                .FetchRecord(itemcode)
                ItemIdsub = .ItemId
                txtitemname.Text = .ItemName
                txtdescription.Text = .ItemDescription
                txtbrand.Text = .BrandType
                txtOh.Text = .StackOH
                txtUOM.Text = .UOM
                txtUnitPrice.Text = .SellingPrice

            End With
        Catch ex As Exception

        Finally

        End Try
    End Sub

    Sub Clear()
        txtSearch.Clear()
        lblAmoutDue.Text = "0.0"
        txtitemname.Clear()
        txtdescription.Clear()
        txtUOM.Clear()
        txtbrand.Clear()
        txtOh.Clear()
        txtUnitPrice.Clear()

   
        dgList2.Rows.Clear()
        txtSearch_KeyDown(Me, Nothing)
       
    End Sub

    Sub SaveRecord(ByVal cash As Decimal, ByVal change As Decimal)
        Dim SR As New tbl_100_SR
        'SQL = DBLookUp("Select PONo from tbl_100_PO_Sub where PONo='" & PONo & "' and ((Status='" & isDelivered & "') or (Status='" & isLacking & "')  or (Status='" & isExcess & "'))", "PONo")
        'If PONo = "" Then
        'Else
        '    If PONo = SQL Then
        '        MsgBox("Invalid to update is being used in other transaction", MsgBoxStyle.Exclamation)
        '        Exit Sub
        '    End If
        'End If



        Dim strResult As Boolean
        Try
            If ErrProvider.CheckAndShowSummaryErrorMessage Then
               If CountGridRows(dgList2) = 0 Then
                    MsgBox("Empty item(s)!", MsgBoxStyle.Exclamation)
                    Exit Sub

                Else
                    If dgList2.RowCount = 0 Then
                        MsgBox("Empty value")
                        Exit Sub
                    End If
                    'If HasRecord(txtPONo.Text) = True Then
                    '    MsgBox("Invalid to Delete this transaction is being used by other transaction", MsgBoxStyle.Exclamation, "Prompt")
                    '    Exit Sub
                    'End If


                    With SR
                        .SRId = tbl_100_SR.GenerateID
                        .Cash = cash
                        .TotalAmt = lblAmoutDue.Text
                        .Change = change
                        .Customer = String.Empty
                        .CreatedBy = CurrUser.USER_FULLNAME
                        .CreatedDte = Date.Now


                        If bolFormState = FormState.EditState Then
                            _OpenTransaction()
                            strResult = .Save(bolFormState = FormState.EditState, dgList2)
                            _CloseTransaction(strResult)
                            MsgBox("Updated Complete", MsgBoxStyle.Information, "RetailPoint")

                          
                        Else

                            _OpenTransaction()
                            strResult = .Save(bolFormState = FormState.EditState, dgList2)
                            _CloseTransaction(strResult)

                            MsgBox("Save Complete", MsgBoxStyle.Information, "RetailPoint")
                            Clear()
                        End If
                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub frm_100_SalesScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResizeForm(Me)
        picLogo.Image = MainForm.picLogo.Image
        FillDataGrid(dglist1, "sproc_100_salesItemList '" & txtSearch.Text & "'", 0, 7)
        getItemDetails()
        ActivateCommands(FormState.AddState)
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgList2.CellContentClick

    End Sub

  
    Private Sub frm_100_SalesScreen_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    ProcessTabKey(True)
        'ElseIf e.Control And e.KeyCode = Keys.S Then

        'End If
        If e.KeyCode = Keys.F2 Then
            txtSearch.Focus()
        ElseIf e.KeyCode = Keys.F3 Then
            dglist1.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            dgList2.Focus()
        ElseIf e.KeyCode = Keys.F5 Then
            btnPay_Click(Me, Nothing)
        End If


    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        'FillGrid(dglist1, "sproc_100_salesItemList '" & txtSearch.Text & "'", "v_ItemMasterFile")
        FillDataGrid(dglist1, "sproc_100_salesItemList '" & txtSearch.Text & "'", 0, 7)

        getItemDetails()
    End Sub


    Private Sub dglist1_KeyDown(sender As Object, e As KeyEventArgs) Handles dglist1.KeyDown

        If e.KeyCode = Keys.Enter Then
            frm_100_ItemSelected.myParent = Me
            frm_100_ItemSelected.ItemId = ItemIdsub
            frm_100_ItemSelected.ItemName = txtitemname.Text
            frm_100_ItemSelected.ItemDescription = txtdescription.Text
            frm_100_ItemSelected.UOM = txtUOM.Text
            frm_100_ItemSelected.UnitPrice = txtUnitPrice.Text
            frm_100_ItemSelected.StockOH = txtOh.Text
            frm_100_ItemSelected.BrandType = txtbrand.Text
            frm_100_ItemSelected.ShowDialog()
        End If
    End Sub

    Private Sub dglist1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dglist1.CellEnter
        getItemDetails()
    End Sub

    Private Sub dglist1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dglist1.CellContentClick

    End Sub

    Private Sub dglist1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dglist1.RowsAdded
        lblRecordCount.Text = CountGridRows(dglist1)

    End Sub

    Private Sub dglist1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dglist1.RowsRemoved
        lblRecordCount.Text = CountGridRows(dglist1)

    End Sub

    Private Sub dgList2_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgList2.RowsAdded
        lblcount.Text = CountGridRows(dgList2)
        ComputeAllRows()
    End Sub

    Private Sub dgList2_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgList2.RowsRemoved
        lblcount.Text = CountGridRows(dgList2)
        ComputeAllRows()
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        frm_100_SalesScreen_Pay.myParent = Me
        frm_100_SalesScreen_Pay.lblAmountDue.Text = lblAmoutDue.Text
        frm_100_SalesScreen_Pay.ShowDialog()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class