Imports Retails.clsPublic
Public Class frm_100_Payout

#Region "variable"
    Public myParent As frm_100_PayoutList
    Public bolFormState As clsPublic.FormState
    Dim payout As New tbl_100_PayOut
    Dim ErrProvider As New ErrorProviderExtended

    Public payoutId As Integer

#End Region

#Region "Procedure"

    Sub SaveRecord()
        Try
          
            If ErrProvider.CheckAndShowSummaryErrorMessage = False Then

       
            Else

                With payout
                    .Id = payoutId
                    .Purpose = txtcomment.Text
                    .Amount = txtamount.Text
                    .CreatedBy = txtprepared.Text
                    .CretedDte = Date.Today
                 
                    _OpenTransaction()
                    _Result = .Save(bolFormState = FormState.EditState)
                    _CloseTransaction(_Result)

                End With

                If _Result Then
                    MsgBox("Payout Successfully Saved", MsgBoxStyle.Information, "Prompt")
                    With myParent
                        If .FillFindON = True Then
                            .ViewFilterBack()
                        Else
                            .RefreshRecord("sproc_100_payout_list '" & MainForm.tsSearch.Text & "'")

                        End If
                    End With

                    Me.Close()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ClearFields()
        txtcomment.Text = String.Empty
        txtamount.Text = 0


        ''dgWarehouse.Rows.Clear()
    End Sub

    Sub SetEditValue()

        Try
            With payout
                .FetchRecord(payoutId)

                txtcomment.Text = .Purpose
                txtamount.Text = .Amount

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region

    Private Sub frm_100_Payout_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ErrProvider.ClearAllErrorMessages()
    End Sub

    Private Sub frm_100_Payout_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        ElseIf e.Control And e.KeyCode = Keys.S Then
            SaveRecord()
        End If
    End Sub

    Private Sub frm_100_Payout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ErrProvider
            .Controls.Clear()
            .Controls.Add(txtcomment, "Payout Comment")
            .Controls.Add(txtamount, "Payout Amount")   
        End With


        txtprepared.Text = CurrUser.USER_FULLNAME

        If bolFormState = clsPublic.FormState.AddState Then
            Call ClearFields()
            payoutId = 0
            Me.Text = "New Payout"
        Else
            Me.Text = "Update Payout"
            Call ClearFields()
         
            payoutId = myParent.dgList.Item("colId", myParent.dgList.CurrentRow.Index).Value
            Call SetEditValue()

        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call SaveRecord()
    End Sub

    Private Sub txtamount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtamount.KeyDown
        If Not IsNumeric(txtamount.Text) Then
            txtamount.Text = 0
        End If
       
    End Sub
End Class