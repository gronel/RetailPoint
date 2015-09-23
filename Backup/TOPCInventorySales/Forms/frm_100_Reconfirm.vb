Imports TOPCInventorySales.clsPublic
Public Class frm_100_Reconfirm
#Region "Variable"
    Public mystate As FormState
    Public OrderNo As String
    Public CustomerNo As String
    Public ProductCode As String
#End Region

#Region "Procedure"
    Private Sub EnableControls()
        Try
            If mystate = FormState.ViewState Then
                dgdetails.AllowUserToAddRows = False
                tsAdd.Enabled = True
                tsEdit.Enabled = True
                tsDelete.Enabled = True
                tsRefresh.Enabled = True
                tsSeparator.Visible = False
                tsSave.Visible = False
                tsCancel.Visible = False
                dgdetails.ReadOnly = True
                dgdetails.AllowUserToDeleteRows = False
                Me.Text = "Confirmation"
                dgdetails.AllowUserToAddRows = False
                dgdetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Else

                tsAdd.Enabled = False
                tsEdit.Enabled = False
                tsDelete.Enabled = False
                tsSeparator.Visible = True
                tsRefresh.Enabled = False
                tsSave.Visible = True
                tsCancel.Visible = True
                dgdetails.ReadOnly = False

                If mystate = FormState.AddState Then
                    Me.Text = "Confirmation - Add"
                    'For Each row As DataGridViewRow In dgdetails.Rows
                    '    row.ReadOnly = True
                    'Next
                    dgdetails.AllowUserToAddRows = True
                    dgdetails.AllowUserToDeleteRows = True
                    dgdetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                ElseIf mystate = FormState.EditState Then
                    Me.Text = "Confirmation - Edit"
                    dgdetails.AllowUserToDeleteRows = True
                    'For Each row As DataGridViewRow In dgdetails.Rows
                    '    row.ReadOnly = True
                    'Next
                    dgdetails.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                End If
            End If



        Catch ex As Exception
            MsgBox("Error : EnableControls in " & Me.Name & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub RefreshRecord()
        FillDataGrid(dgdetails, "SELECT     confDate, confQTY,Remarks " & _
                              "FROM tbl_100_ConfirmDateDetails " & _
                              "WHERE     (OrderNo = '" & OrderNo & "') AND (ProductCode = '" & ProductCode & "') ORDER BY rec", 0, 2)

    End Sub

    Private Function Addrecord() As Boolean
        Dim RunQTY As Double



        '' 1. --> check the transaction if exist or not
        SQL = "Select OrderNO,ProductCode from tbl_100_Order_Sub where (OrderNo Like '" & OrderNo & "') AND (ProductCode Like '" & ProductCode & "')"
        If isRecordExist(SQL) = False Then
            MsgBox("This Transaction is not Exist", MsgBoxStyle.Information, "Prompt") : Exit Function
        End If

        '' 2.--> Add the latest running quantity of this product and customize the date after

        SQL = "SELECT runQTY FROM tbl_100_Order_Sub " & _
                         " WHERE     (OrderNo = '" & OrderNo & "') AND (ProductCode = '" & ProductCode & "')"

        RunQTY = NZ(DBLookUp(SQL, "runQTY"))


        '' 4.--> Add the latest running quantity of this product and customize the date after
        If RunQTY = 0 Then
            MsgBox("Product is Delivered", MsgBoxStyle.Information, "Prompt") : Exit Function : Addrecord = False
     
        Else
            dgdetails.Rows.Add(Now.Date, RunQTY.ToString)
            Addrecord = True
        End If



    End Function

    Private Sub Save()
        Dim clsconfirn As New tbl_100_ConfirmDateDetails

        With clsconfirn
            .Orderno = OrderNo
            .ProductCode = ProductCode
            If .Save(dgdetails) Then

                If mystate = FormState.AddState Then
                    MsgBox("New Confirmations Date Save Complete", MsgBoxStyle.Information, "Prompt")
                Else
                    MsgBox("Updated Confirmations Date Save Complete", MsgBoxStyle.Information, "Prompt")
                End If
            End If


        End With

    End Sub

    Private Sub Delete(ByVal dt As Date)
        RunQuery("Delete from tbl_100_ConfirmDateDetails where OrderNo='" & OrderNo & "' and ProductCode='" & ProductCode & "' and confDate='" & dt & "'")
    End Sub

#End Region


    Private Sub frm_100_Reconfirm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call EnableControls()
        Call RefreshRecord()
    End Sub


    Private Sub tsMenu_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tsMenu.ItemClicked
        Select Case e.ClickedItem.Name
            Case "tsAdd"
                mystate = FormState.AddState
                If Addrecord() = True Then
                    Call EnableControls()
                End If
            Case "tsEdit"
                mystate = FormState.EditState
                Call EnableControls()
            Case "tsDelete"
                Call Delete(dgdetails.Item(0, dgdetails.CurrentRow.Index).Value)
                Call EnableControls()
            Case "tsCancel"
                mystate = FormState.ViewState
                Call EnableControls()
                Call RefreshRecord()
            Case "tsSave"
                Call Save()
                mystate = FormState.ViewState
                Call EnableControls()
            Case "tsRefresh"
                Call RefreshRecord()
        End Select
    End Sub

End Class