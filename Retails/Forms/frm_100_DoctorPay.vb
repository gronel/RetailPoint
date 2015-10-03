Imports Retails.clsPublic
Public Class frm_100_DoctorPay

#Region "variable"
    Public myParent As frm_100_DoctorPayList

    Public bolFormState As clsPublic.FormState
    Dim payout As New tbl_100_DoctorsPay
    Dim ErrProvider As New ErrorProviderExtended

    Public docId As Integer

#End Region

#Region "Procedure"

    Sub SaveRecord()
        Try

            If ErrProvider.CheckAndShowSummaryErrorMessage = False Then


            Else

                With payout
                    .Id = docId
                    .patient = txtpatient.Text
                    .payable = txtpayable.Text
                    .remarks = txtremarks.Text
                    .createdBy = txtprepared.Text
                    .createdDte = Date.Today

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
                            .RefreshRecord("sproc_100_doctors_list '" & MainForm.tsSearch.Text & "'")

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
        txtpatient.Text = String.Empty
        txtpayable.Text = 0


        ''dgWarehouse.Rows.Clear()
    End Sub

    Sub SetEditValue()

        Try
            With payout
                .FetchRecord(docId)

                txtpatient.Text = .patient
                txtpayable.Text = NZ(.payable)
                txtremarks.Text = .remarks

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
            .Controls.Add(txtpatient, "Patient")
            .Controls.Add(txtpayable, "Payable")
        End With


        txtprepared.Text = CurrUser.USER_FULLNAME

        If bolFormState = clsPublic.FormState.AddState Then
            Call ClearFields()
            docId = 0
            Me.Text = "New Doctors Payment"
        Else
            Me.Text = "Update Doctors Payment"
            Call ClearFields()

            docId = myParent.dgList.Item("colId", myParent.dgList.CurrentRow.Index).Value
            Call SetEditValue()

        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call SaveRecord()
    End Sub

    Private Sub txtamount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpayable.KeyDown
        If Not IsNumeric(txtpayable.Text) Then
            txtpayable.Text = 0
        End If

    End Sub
End Class