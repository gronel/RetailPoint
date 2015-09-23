Imports TOPCInventorySales.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_200_POS
#Region "variable"

    Implements IBPSCommand
    Public bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
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

    Public Sub navigationButton(ByVal isvergin)
        btnback.Visible = isvergin
        btnnext.Visible = isvergin
    End Sub

    Sub ComputeAllRows()
        Dim sum As Double
        With dgDetails
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colamount", i).Value)
            Next
            txtpoamount.Text = FormatNumber(NZ(sum))
        End With
    End Sub

    Sub ComputeAllrowsAmount2()
        Dim sum As Double
        With dgdetails2
            For i = 0 To dgdetails2.RowCount - 1
                sum = sum + NZ(.Item("ColAmount2", i).Value)
            Next
            txtrramount.Text = FormatNumber(NZ(sum))
        End With
    End Sub

    Sub CopmputeAllrowsQty2()
        Dim sum As Integer
        With dgdetails2
            For i = 0 To .RowCount - 1
                sum += NZ(.Item("colQty", i).Value)
            Next
            txtrrqty.Text = FormatNumber(sum, 2)
        End With
    End Sub

    Sub POEnter()
        Try
            Dim paramList As ArrayList = New ArrayList
            paramList.Clear()
            paramList = FetchData(paramList, "sp_200_POS'" & txtPONo.Text & "'", CommandType.Text)
            If paramList Is Nothing Or paramList.Count = 0 Then
                ''do nothing
            Else
                txtdate.Text = FormatDateTime(paramList(0).ToString, DateFormat.ShortDate)
                txtsupplierid.Text = paramList(1).ToString
                txtsuppliername.Text = paramList(2).ToString
                txtaddress.Text = paramList(3).ToString
                txtSupplierType.Text = paramList(4).ToString
                txtdeliveryDate.Text = paramList(5).ToString
                txtdeliveryby.Text = paramList(6).ToString
                txtterm.Text = paramList(7).ToString
                txtpaydate.Text = paramList(8).ToString
                lblctype.Text = paramList(9).ToString
            End If

            txtrramount.Text = String.Empty
            txtrrqty.Text = String.Empty
            lblctype2.Text = String.Empty
            dgdetails2.Rows.Clear()

            FillDataGrid(dgDetails, "Get_POS '" & txtPONo.Text & "'", 2, 15)

            ComputeAllRows()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frm_300_POS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me) 'Resize the  form 
        CenterControl(lblTitle, Me) 'center the title of the transaction
        lblctype.Text = String.Empty
        lblctype2.Text = String.Empty

        ''use to next back the data
        inc = 0
        isnext = False
        ActivateCommands(FormState.ViewState)
    
    End Sub

    Private Sub txtPONo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPONo.KeyDown
        If e.KeyCode = Keys.Enter Then
            POEnter()
        End If
    End Sub

#End Region

#Region "GUI"
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
        Dim cryRpt As New ReportDocument
        Try
            Select Case e.ColumnIndex
                Case 0
                    Dim ShowReport As New frm_200_ReportV
                    With ShowReport
                        cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_POS.rpt")

                        With cryRpt
                            .Refresh()
                            .SetDataSource(FillReportForm("sp_rpt_POS'" & txtPONo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "tbl_100_PO_Sub"))
                            .Subreports("rr").SetDataSource(FillReportForm("sp_rpt_POS_RR'" & txtPONo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "tbl_100_RR_Sub"))
                            .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                        End With
                        .rpt_viewer.ReportSource = cryRpt
                        .Show()
                    End With
                Case 1
                    FillDataGrid(dgdetails2, "Get_POS_RR '" & txtPONo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", 0, 13)
                    ComputeAllrowsAmount2()
                    CopmputeAllrowsQty2()
                    lblctype2.Text = lblctype.Text
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

    Private Sub dgdetails2_RowsAdded1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails2.RowsAdded
        Label10.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub dgdetails2_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails2.RowsRemoved
        Label10.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        With frm_SearchTransNO
            .POparent = Me
            .param1 = "PO"
            If value <> String.Empty Then

                .txtValue.Text = value
            Else

                .txtValue.Text = String.Empty
            End If
            .ShowDialog()
            dgDetails.Rows.Clear()
            dgdetails2.Rows.Clear()
            Call POEnter()
            rownum = inc
        End With
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        If rownum <> 0 Then inc = rownum
        txtPONo.Text = Navigation("sp_GetControlNo'" & "PO" & "','" & category & "','" & value & "'", "tbl_100_PR", "Control", "Next")
        Call POEnter()
        dgdetails2.Rows.Clear()
        rownum = inc
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        If rownum <> 0 Then inc = rownum
        txtPONo.Text = Navigation("sp_GetControlNo'" & "PO" & "','" & category & "','" & value & "'", "tbl_100_PR", "Control", "Back")
        Call POEnter()
        dgdetails2.Rows.Clear()
        rownum = inc
    End Sub


#End Region


End Class