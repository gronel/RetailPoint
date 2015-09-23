Public Class frm_000_EditUPrice
#Region "Variable"
    Dim Apoint As Point = New Point(12, 12)
    Dim Bpoint As Point = New Point(4, 6)

    Dim Asize As Size = New Size(223, 162)
    Dim Bsize As Size = New Size(272, 357)

    Public _productcode As String
    Public _Pricedid As Integer
#End Region

#Region "User Defination"
    Private Sub loadaffectControl()
        Try
            FillDataGrid(dgdetailsOrder, "sp_Get_Affective_control 'Order','" & _productcode & "', '" & _Pricedid & "'", 0, 0)
            FillDataGrid(dgdetailsDR, "sp_Get_Affective_control 'DR','" & _productcode & "', '" & _Pricedid & "'", 0, 0)
        Catch ex As Exception
            MsgBox("Error: loadaffectControl -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub


    Private Sub save()
        Try
            Using cls As New EditUnitPrice()
                With cls
                    .productcode = _productcode
                    .priceid = _Pricedid
                    .unitprice = NZ(FormatNumber(txtunitprice.Text, NZ(cbodec.Text)))
                    .dec = NZ(cbodec.Text)
                    If .SaveEditUnitPrice() Then
                        MsgBox("Update Unitprice Complete!", MsgBoxStyle.Information, "Prompt")
                        Me.Close()
                    End If
                End With


            End Using

        Catch ex As Exception
            MsgBox("Error:Save -->" & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub


    Public Sub isload(ByVal ischage As Integer)
        Try
            Select Case ischage
                Case 0
                    Me.Text = "Edit Unit Price"
                    Me.Size = Asize
                    GroupBox1.Show()
                    GroupBox2.Hide()

                Case 1
                    Me.Text = "Transaction Affective"
                    Me.Size = Bsize
                    GroupBox1.Hide()
                    GroupBox2.Show()
            End Select
        Catch ex As Exception
            MsgBox("Error: isLoad --> " & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub

    Private Function checkMissing() As Boolean
        Try
            checkMissing = True
            If txtunitprice.Text = String.Empty Then
                ErrorProv.SetError(txtunitprice, "Input Unitprice!")
                checkMissing = False
            Else
                ErrorProv.SetError(txtunitprice, "")
            End If

            If cbodec.Text = String.Empty Then
                ErrorProv.SetError(cbodec, "Select Decimal Place!")
                checkMissing = False
            Else
                ErrorProv.SetError(cbodec, "")
            End If
        Catch ex As Exception
            MsgBox("Error:checkMissing --> " & ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Function


#End Region


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Call save()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If checkMissing() Then
            isload(1)
            Call loadaffectControl()
        End If
    End Sub

    Private Sub txtunitprice_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtunitprice.Validated
        If txtunitprice.Text = String.Empty Then
            ErrorProv.SetError(txtunitprice, "Input Unitprice!")

        Else
            ErrorProv.SetError(txtunitprice, "")
        End If
    End Sub

    Private Sub cbodec_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbodec.Validated
        If cbodec.Text = String.Empty Then
            ErrorProv.SetError(cbodec, "Select Decimal Place!")

        Else
            ErrorProv.SetError(cbodec, "")
        End If
    End Sub

    Private Sub frm_000_EditUPrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtunitprice.Text = String.Empty
        Me.cbodec.SelectedIndex = -1
    End Sub

    Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected

    End Sub
End Class