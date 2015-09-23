Imports System.Windows.Forms
Imports System.Data.SqlClient


Public Class opendialog

#Region "Variable"
    Public Tname As String ''name of the transaction
    Public TID As String ''transaction ID

#End Region

#Region "Procedure"

    Sub canceled()

        Select Case Tname
            Case "PR"
                UpdateTrans("UPDATE tbl_100_PR SET isStatus='" & isCancelled & "',isReason='" & cboreason.Text & "' where PRno='" & TID & "'")
                frm_100_PR.enabled_tools()
                frm_100_PR.btncopy.Visible = True
                frm_100_PR.btncopy.Enabled = True
                frm_100_PR.btncopy.Focus()
            Case "JR"
                UpdateTrans("UPDATE tbl_100_JR SET isStatus='" & isCancelled & "',isReason='" & cboreason.Text & "' where JRno='" & TID & "'")
                frm_100_JR.enabled_tools()
                frm_100_JR.btncopy.Visible = True
                frm_100_JR.btncopy.Enabled = True
                frm_100_JR.btncopy.Focus()
            Case "PO"
                UpdateTrans("UPDATE tbl_100_PO SET isStatus='" & isCancelled & "',isReason='" & cboreason.Text & "' where POno='" & TID & "'")
                frm_100_PO.enabled_tools()
                frm_100_PO.btncopy.Visible = True
                frm_100_PO.btncopy.Enabled = True
                frm_100_PO.btncopy.Focus()
            Case "JO"
                UpdateTrans("UPDATE tbl_100_JO SET isStatus='" & isCancelled & "',isReason='" & cboreason.Text & "' where JOno='" & TID & "'")
                frm_100_JO.enabled_tools()
                frm_100_JO.btncopy.Visible = True
                frm_100_JO.btncopy.Enabled = True
                frm_100_JO.btncopy.Focus()
            Case "RR"
                UpdateTrans("UPDATE tbl_100_RR SET isStatus='" & isCancelled & "',isReason='" & cboreason.Text & "' where RRno='" & TID & "'")
                frm_100_RR.enabled_tools()
                frm_100_RR.btncopy.Visible = True
                frm_100_RR.btncopy.Enabled = True
                frm_100_RR.btncopy.Focus()

            Case "WR"
                UpdateTrans("UPDATE tbl_100_WR SET isStatus='" & isCancelled & "',isReason='" & cboreason.Text & "' where WRno='" & TID & "'")
                With frm_100_WR
                    .enabled_tools(True)
                    .btncopy.Visible = True
                    .btncopy.Enabled = True
                    .btncopy.Focus()
                End With
            Case "DR"
                UpdateTrans("UPDATE tbl_100_DR SET Status='" & isCancelled & "',isReason='" & cboreason.Text & "' where DRno='" & TID & "'")
                With frm_100_DR
                    .enabled_tools(False)
                    .btncopy.Visible = True
                    .btncopy.Enabled = True
                    .btncopy.Focus()
                End With
        End Select

    End Sub

#End Region

#Region "GUI"

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Timer1.Start()
        lblpassword.Visible = False
        picload.Visible = True
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Timer1.Interval = 2000 Then
            Timer1.Stop()
            picload.Visible = False
            If cboreason.Text = "" Then
                MsgBox("Reason is required", MsgBoxStyle.Exclamation, "Prompt")
                Exit Sub
            End If
            If getUser(isUsername, txtpassword.Text) = True Then
                MsgBox("Identification Canceled ", MsgBoxStyle.Information, "Prompt")
                Call canceled()
                Me.Close()
            Else
                lblpassword.Visible = True
            End If

        End If
    End Sub

    Private Sub opendialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpassword.Clear()
        Select Case Tname
            Case "PR"
                FillCombobox(cboreason, "Select isReason from tbl_100_PR where isReason!='NULL' Group by isReason", "tbl_100_PR", "isReason", "isReason")
            Case "JR"
                FillCombobox(cboreason, "Select isReason from tbl_100_JR where isReason!='NULL' Group by isReason", "tbl_100_JR", "isReason", "isReason")
            Case "PO"
                FillCombobox(cboreason, "Select isReason from tbl_100_PO where isReason!='NULL' Group by isReason", "tbl_100_PO", "isReason", "isReason")
            Case "JO"
                FillCombobox(cboreason, "Select isReason from tbl_100_JO where isReason!='NULL' Group by isReason", "tbl_100_JO", "isReason", "isReason")
        End Select
    End Sub

#End Region

End Class
