Imports System.Windows.Forms

Public Class frmUnit
#Region "Variable"

    Public trans As String
#End Region

#Region "Procedure"
    Sub newno()
        Select Case trans
            Case "PR"
                If isRecordExist("SELECT PRNo FROM tbl_100_PR WHERE PRNo='" & txtnew.Text & "'") Then
                    lblidexist.Show()
                ElseIf isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf txtnew.Text = "" Then
                    lblempty.Show()
                Else
                    frm_100_PR.txtPRNo.Text = txtnew.Text
                    Me.Close()
                    frm_100_PR.SaveRecord()
                End If

            Case "JR"
                If isRecordExist("SELECT PRNo FROM tbl_100_PR WHERE PRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtnew.Text & "'") Then
                    lblidexist.Show()
                ElseIf isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf txtnew.Text = "" Then
                    lblempty.Show()
                Else
                    frm_100_JR.txtJRNo.Text = txtnew.Text
                    Me.Close()
                    frm_100_JR.SaveRecord()
                End If
            Case "PO"
                If isRecordExist("SELECT PRNo FROM tbl_100_PR WHERE PRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtnew.Text & "'") Then
                    lblidexist.Show()
                ElseIf isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf txtnew.Text = "" Then
                    lblempty.Show()
                Else
                    frm_100_PO.txtPONo.Text = txtnew.Text
                    Me.Close()
                    frm_100_PO.SaveRecord()
                End If
            Case "JO"
                If isRecordExist("SELECT PRNo FROM tbl_100_PR WHERE PRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtnew.Text & "'") Then
                    lblidexist.Show()
                ElseIf isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf txtnew.Text = "" Then
                    lblempty.Show()
                Else
                    frm_100_JO.txtJONo.Text = txtnew.Text
                    Me.Close()
                    frm_100_JO.SaveRecord()
                End If
            Case "RR"
                If isRecordExist("SELECT PRNo FROM tbl_100_PR WHERE PRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtnew.Text & "'") Then
                    lblidexist.Show()
                ElseIf isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf txtnew.Text = "" Then
                    lblempty.Show()
                Else
                    frm_100_RR.txtRRNo.Text = txtnew.Text
                    Me.Close()
                    frm_100_RR.SaveRecord()
                End If
            Case "WR"
                If isRecordExist("SELECT PRNo FROM tbl_100_PR WHERE PRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select JONo from tbl_100_JO where JONo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select JRNo from tbl_100_JR where JRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select PONo from tbl_100_PO where PONo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select WRNo from tbl_100_WR where WRNo='" & txtnew.Text & "'") Then
                    lblidexist.Show()
                ElseIf isRecordExist("Select RRNo from tbl_100_RR where RRNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf isRecordExist("Select ARNo from tbl_100_AR where ARNo='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                ElseIf txtnew.Text = "" Then
                    lblempty.Show()
                Else
                    With frm_100_WR
                        .txtWRNo.Text = txtnew.Text
                        Me.Close()
                        .SaveVoidDetails()
                    End With
                End If

            Case "DR"
                If isRecordExist("Select DRNo from tbl_100_DR where DRNO='" & txtnew.Text & "'") Then
                    lblothertrans.Show()
                Else
                    With frm_100_DR
                        .txtDRCode.Text = txtnew.Text
                        Me.Close()
                        .SaveVoidRecord()
                    End With
                End If
        End Select
    End Sub

#End Region

#Region "GUI"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Timer1.Start()
        picload.Visible = True
        lblidexist.Hide()
        lblothertrans.Hide()
        lblempty.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frm_NewNo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtnew.Clear()
        txtnew.Focus()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Timer1.Interval = 2000 Then
            Timer1.Stop()
            picload.Visible = False
            newno()
        End If
    End Sub

#End Region

End Class
