Imports Retails.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_200_JOS

#Region "variable"
    Implements IBPSCommand
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
                    
                    .tsPrint.Enabled = False
                    .tsPreview.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
                    .tsFilterOn.Enabled = False
                    .tsFilterClear.Enabled = False

            End Select

        End With
    End Sub

    Public Sub navigationButton(ByVal isVergin As Boolean)
        btnback.Visible = isVergin
        btnNext.Visible = isVergin
    End Sub


    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

    End Sub
    Public bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Dim cctype As String

    Sub ComputeAllRows()
        Dim sum As Double
        With dgDetails
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colamount", i).Value)
            Next
            txtJOAmount.Text = FormatNumber(NZ(sum))
        End With
    End Sub

    Sub ComputeAllRows2()
        Dim sum As Double
        With dgdetails2
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("ColAmount2", i).Value)
            Next
            txttotalRR.Text = FormatNumber(NZ(sum))
        End With
    End Sub

    Sub ComputeAllRowsQuantity()
        Dim sum As Double
        With dgdetails2
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colQty", i).Value)
            Next
            txttotalwithdrawalquantity.Text = sum
        End With
    End Sub

    Sub JOEnter()
        Dim JOArray As ArrayList = New ArrayList
        JOArray.Clear()
        Try
            JOArray = FetchData(JOArray, "sp_200_JOS'" & txtJONo.Text & "'", CommandType.Text)

            If JOArray Is Nothing Or JOArray.Count = 0 Then
                ''Nothing to display

            Else

                txtdate.Text = FormatDateTime(JOArray(0).ToString, DateFormat.ShortDate)
                txtsupplierid.Text = JOArray(1).ToString
                txtsuppliername.Text = JOArray(2).ToString
                txtaddress.Text = JOArray(3).ToString
                txtSupplierType.Text = JOArray(4).ToString
                txtterm.Text = JOArray(5).ToString
                txtDeliveryDate.Text = JOArray(6).ToString
                txtpaydate.Text = JOArray(7).ToString
                cctype = JOArray(8).ToString
                lblctype.Text = cctype
                lblctype2.Text = String.Empty
            End If


            FillDataGrid(dgDetails, "Get_JOS'" & txtJONo.Text & "'", 2, 15)

            ComputeAllRows()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region

#Region "GUI"

    Private Sub frm_300_JOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me) 'Resize the  form 
        CenterControl(lblTitle, Me) 'center the title of the transaction

        ''used to next or back the data
        inc = 0
        isnext = False
        ActivateCommands(FormState.ViewState)
      
    End Sub

    Private Sub txtJONo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtJONo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call JOEnter()
            dgdetails2.Rows.Clear()
        End If
    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        Label16.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        Label16.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgdetails2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        Label10.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub dgdetails2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        Label10.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub dgDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Try
            Select Case e.ColumnIndex
                Case 0
                    Dim ShowReport As New frm_200_ReportV
                    Dim cryRpt As New ReportDocument
                    With ShowReport
                        cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_JOS.rpt")

                        With cryRpt
                            .Refresh()
                            .SetDataSource(FillReportForm("sp_rpt_JOS '" & txtJONo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "#tempJO"))
                            .Subreports("rr").SetDataSource(FillReportForm("sp_rpt_JOS_RR '" & txtJONo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "#tempRR"))
                            .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                        End With
                        .rpt_viewer.ReportSource = cryRpt
                        .Show()
                    End With
                Case 1
                    With dgDetails
                        If txtJONo.Text = "" Then
                            MsgBox("Empy JO No.!", MsgBoxStyle.Exclamation)
                            Exit Sub
                        Else
                            FillDataGrid(dgdetails2, "Get_JOS_RR'" & txtJONo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", 0, 12)
                            lblctype2.Text = "PHP"
                            ComputeAllRows2()
                            ComputeAllRowsQuantity()
                        End If
                    End With

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



    Private Sub dgdetails2_RowsAdded1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails2.RowsAdded
        Label10.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub dgdetails2_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails2.RowsRemoved
        Label10.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub dgDetails_RowsAdded1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        Label16.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        Label16.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If rownum <> 0 Then inc = rownum
        txtJONo.Text = Navigation("sp_GetControlNo'" & "JO" & "','" & category & "','" & value & "'", "tbl_100_JO", "control", "Next")
        Call JOEnter()
        dgdetails2.Rows.Clear()
        rownum = inc
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        If rownum <> 0 Then inc = rownum
        txtJONo.Text = Navigation("sp_GetControlNo'" & "JO" & "','" & category & "','" & value & "'", "tbl_100_JO", "control", "Back")
        Call JOEnter()
        dgdetails2.Rows.Clear()
        rownum = inc
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        With frm_SearchTransNO
            .JOparent = Me
            .param1 = "JO"
            If category <> String.Empty And value <> String.Empty Then
                .cboCategory.Text = category
                .txtValue.Text = value
            Else
                .cboCategory.Text = String.Empty
                .txtValue.Text = String.Empty
            End If
            .ShowDialog()
            Call JOEnter()
            rownum = inc
            dgdetails2.Rows.Clear()
        End With
    End Sub

    Private Sub txtJONo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJONo.TextChanged
        Call JOEnter()
    End Sub

   
#End Region


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
