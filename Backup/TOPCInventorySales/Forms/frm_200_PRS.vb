Imports TOPCInventorySales.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_200_PRS

#Region "Variable"

    Implements IBPSCommand
    Public bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Dim CurrencyType As String
    Public category As String
    Public value As String
    Public rownum As Integer

#End Region

#Region "Procedure"
    Sub ActivateCommands(ByVal frmState As clsPublic.FormState)
        bolFormState = frmState

        With MainForm
            Select Case frmState

                Case FormState.ViewState
                    .tsNew.Enabled = False
                    .tsEdit.Enabled = False
                    .tsDelete.Enabled = False
                    .tsSave.Enabled = False
                    .tsCancel.Enabled = False
                    .tsRefresh.Enabled = False
                    .tsClose.Enabled = True
                    .tsVoid.Enabled = False
                    .tsPrint.Enabled = False
                    .tsPreview.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
                    .tsFilterOn.Enabled = False
                    .tsFilterClear.Enabled = False

            End Select

        End With
    End Sub

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

    End Sub
    Sub ComputeAllrowsAmount()
        Dim sum As Double
        With dgDetails
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colamount", i).Value)
            Next
            txtpramount.Text = FormatNumber(NZ(sum))
        End With
    End Sub

    Sub ComputeAllrowsAmount2()
        Dim sum As Double
        With Dgdetails2
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("ColAmount2", i).Value)
            Next
            txtrramount.Text = FormatNumber(NZ(sum))
        End With
    End Sub

    Sub ComputeAllRowsQuantity()
        Dim sum As Integer
        With Dgdetails2
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colQty", i).Value)
            Next
            txtrrQTY.Text = sum * 1

        End With
    End Sub

    Sub EnterPR()
        Try
            Dim paramarraylist As ArrayList = New ArrayList
            paramarraylist.Clear()
            paramarraylist = FetchData(paramarraylist, "sp_200_PRS'" & txtPRNo.Text & "'", CommandType.Text)
            If paramarraylist Is Nothing Or paramarraylist.Count = 0 Then
                ''nothing happen
            Else
                txtdeptCode.Text = paramarraylist(0).ToString
                txtDepartment.Text = paramarraylist(1).ToString
                txtsectioncode.Text = paramarraylist(2).ToString
                txtSection.Text = paramarraylist(3).ToString
                txtlinecode.Text = paramarraylist(4).ToString
                txtLine.Text = paramarraylist(5).ToString
                txtsuppliercode.Text = paramarraylist(6).ToString
                txtSupplier.Text = paramarraylist(7).ToString
                txtSupplierType.Text = paramarraylist(8).ToString
                txtdateRequested.Text = FormatDateTime(paramarraylist(9).ToString, DateFormat.ShortDate)
                txtdateneeded.Text = paramarraylist(10).ToString
                txtposchedule.Text = paramarraylist(11).ToString
                txtprtype.Text = paramarraylist(12).ToString
                lblCtype.Text = paramarraylist(13).ToString

            End If

            FillDataGrid(dgDetails, "Get_PRS '" & txtPRNo.Text & "'", 2, 14)
            ComputeAllrowsAmount()

            txtrramount.Clear()
            txtrrQTY.Clear()
            lblctype2.Text = String.Empty

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub navigationButton(ByVal isVergin As Boolean)
        btnback.Visible = isVergin
        btnNext.Visible = isVergin
    End Sub



#End Region


#Region "GUI"
    Private Sub frm_300_PRS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me) 'Resize the  form 
        CenterControl(lblTitle, Me) 'center the title of the transaction
        lblCtype.Text = String.Empty
        lblctype2.Text = String.Empty

        ''use to next back the data
        inc = 0
        isnext = False
        ActivateCommands(FormState.ViewState)
    End Sub

    Private Sub txtPRNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPRNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPRNo.Text = "" Then
                MsgBox("Empty PR No.", MsgBoxStyle.Exclamation)
                ClearTextbox(Me)
            Else
                Call EnterPR()
            End If

        End If
    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        Label16.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        Label16.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub Dgdetails2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        Label10.Text = CountGridRows(Dgdetails2)
    End Sub

    Private Sub Dgdetails2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        Label10.Text = CountGridRows(Dgdetails2)
    End Sub

    Private Sub dgDetails_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Dim cryRpt As New ReportDocument
        Try
            Select Case e.ColumnIndex
                Case 0
                    Dim ShowReport As New frm_200_ReportV
                    With ShowReport
                        cryRpt.Load(Application.StartupPath & "\reports\rpt_200_PRS.rpt")
                        With cryRpt
                            .SetDataSource(FillReportForm("sp_rpt_PRS'" & txtPRNo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "#tempPR"))
                            .Subreports("RR").SetDataSource(FillReportForm("sp_rpt_PRS_RR '" & txtprtype.Text & "', '" & txtPRNo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "#temp_RR"))
                            .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                        End With
                        .rpt_viewer.ReportSource = cryRpt
                        .Show()
                        .Focus()
                        .Text = "Purchase Requisition Status Report " & txtPRNo.Text
                    End With
                Case 1
                    If txtprtype.Text = "Cash" Then
                        FillDataGrid(Dgdetails2, "Get_PRS_RR '" & "Cash" & "','" & txtPRNo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", 0, 12)
                        ComputeAllrowsAmount2()
                        ComputeAllRowsQuantity()
                    ElseIf txtprtype.Text = "PO" Then
                        FillDataGrid(Dgdetails2, "Get_PRS_RR '" & "PO" & "','" & txtPRNo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", 0, 12)
                        ComputeAllrowsAmount2()
                        ComputeAllRowsQuantity()

                    End If
                    lblctype2.Text = lblCtype.Text
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgDetails_RowsAdded1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        Label16.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        Label16.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub Dgdetails2_RowsAdded1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgdetails2.RowsAdded
        Label10.Text = CountGridRows(Dgdetails2)
    End Sub

    Private Sub Dgdetails2_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles Dgdetails2.RowsRemoved
        Label10.Text = CountGridRows(Dgdetails2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frm_SearchTransNO
            .PRparent = Me
            .param1 = "PR"

            If category <> String.Empty And value <> String.Empty Then
                .cboCategory.Text = category
                .txtValue.Text = value
            Else
                .cboCategory.Text = String.Empty
                .txtValue.Text = String.Empty
            End If
            .ShowDialog()
            dgDetails.Rows.Clear()
            Dgdetails2.Rows.Clear()
            Call EnterPR()
            rownum = inc


        End With
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If rownum <> 0 Then inc = rownum
        txtPRNo.Text = Navigation("sp_GetControlNo'" & "PR" & "','" & category & "','" & value & "'", "tbl_100_PR", "Control", "Next")
        rownum = inc
        Call EnterPR()
        Dgdetails2.Rows.Clear()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        If rownum <> 0 Then inc = rownum
        txtPRNo.Text = Navigation("sp_GetControlNo'" & "PR" & "','" & category & "','" & value & "'", "tbl_100_PR", "Control", "Back")
        rownum = inc
        Call EnterPR()
        Dgdetails2.Rows.Clear()
    End Sub

    Private Sub txtPRNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRNo.TextChanged
        Call EnterPR()
        Dgdetails2.Rows.Clear()
    End Sub




#End Region


End Class