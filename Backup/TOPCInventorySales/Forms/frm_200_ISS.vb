Imports TOPCInventorySales.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frm_200_ISS
    Implements IBPSCommand
    Public bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Public Category, Value As String
    Public rownum As Integer

    Public Sub navigationButton(ByVal isVergin As Boolean)
        btnback.Visible = isVergin
        btnNext.Visible = isVergin
    End Sub

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


    Public Sub SelectITEmcode()
        Try

            FillGrid(dgDetails, "Get_ISS'" & cboItemCode.Text & "'", "tbl_100_RR_Sub")
            dgdetails2.Rows.Clear()
            txtwramount.Text = 0.0
            txtwrQTY.Text = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Sub FillTextBox()
        If Not cboItemCode.SelectedValue Is Nothing Then
            txtItemName.Text = cboItemCode.SelectedItem.Col2
            txtCategory.Text = cboItemCode.SelectedItem.Col3
            txtSubCategory.Text = cboItemCode.SelectedItem.Col4
        Else
            txtItemName.Text = String.Empty
            txtCategory.Text = String.Empty
            txtSubCategory.Text = String.Empty
        End If
    End Sub

    Sub ComputeAllRows()
        Dim sum As Double
        With dgdetails2
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colcovertedAmount", i).Value)
            Next
            txtwramount.Text = FormatNumber(NZ(sum))
        End With
    End Sub

    Sub ComputeAllrowsQTY()
        Dim sum As Double
        With dgdetails2
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colconvertedQTY", i).Value)
            Next
            txtwrQTY.Text = FormatNumber(sum, 2)
        End With
    End Sub

    Private Sub frm_200_ISS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtItemName.Focus()
    End Sub


    Private Sub frm_300_ISS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me) 'Resize the  form 
        CenterControl(lblTitle, Me) 'center the title of the transaction
        LoadItemComboBox_DataTable(cboItemCode)

        ''used to next or back

        inc = 0
        isnext = False
        ActivateCommands(FormState.ViewState)
    End Sub

    Private Sub cboItemCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemCode.SelectedIndexChanged
        Call FillTextBox()

        Call SelectITEmcode()
       

    End Sub

    Private Sub dgDetails_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Try
            Select Case e.ColumnIndex
                Case 0
                    Dim ShowReport As New frm_200_ReportV
                    With ShowReport
                        Dim cryrpt As New ReportDocument
                        cryrpt.Load(Application.StartupPath & "\Reports\rpt_200_ISS.rpt")
                        cryrpt.Refresh()
                        cryrpt.SetDataSource(FillReportForm("sp_rpt_ISS '" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "tbl_000_Item_Sub"))
                        cryrpt.Subreports("rr").SetDataSource(FillReportForm("sp_rpt_ISS_RR '" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "tbl_100_RR_Sub"))
                        cryrpt.Subreports("wr").SetDataSource(FillReportForm("sp_rpt_ISS_WR '" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "','" & dgDetails.Item("colRRNo", e.RowIndex).Value & "'", "tbl_100_WR_Sub"))
                        cryrpt.SetParameterValue("pre", CurrUser.USER_FULLNAME)
                        .rpt_viewer.ReportSource = cryrpt
                        .Show()
                        .Focus()
                    End With
                Case 1

                    FillDataGrid(dgdetails2, "Get_ISS_WR'" & dgDetails.Item("colRRNo", e.RowIndex).Value & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", 0, 22)
                    Call ComputeAllRows()
                    Call ComputeAllrowsQTY()

                    For i = 0 To dgdetails2.RowCount - 1
                        Call ADDFields(i)
                    Next

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ADDFields(ByVal rowindex As Integer)
        With dgdetails2
            .Item("colconvertedQTY", rowindex).Value = ConvertToMoney(.Item("colconvertedQTY", rowindex).Value)
            .Item("colconvertedprice", rowindex).Value = ConvertToMoney(.Item("colconvertedprice", rowindex).Value)
            .Item("colcovertedAmount", rowindex).Value = ConvertToMoney(.Item("colcovertedAmount", rowindex).Value)
        End With
    End Sub

    Private Sub dgdetails2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails2.RowsAdded
        Label10.Text = CountGridRows(dgdetails2)

    End Sub

    Private Sub dgdetails2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails2.RowsRemoved
        Label10.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If rownum <> 0 Then inc = rownum
        cboItemCode.Text = Navigation("sp_SearchITem_for_ISS'" & Category & "','" & Value & "'", "tbl_000_ITem", "ItemCode", "Next")
        Call SelectITEmcode()
        dgdetails2.Rows.Clear()
        rownum = inc
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        If rownum <> 0 Then inc = rownum
        cboItemCode.Text = Navigation("sp_SearchITem_for_ISS'" & Category & "','" & Value & "'", "tbl_000_Item", "ItemCode", "Back")
        rownum = inc
        Call SelectITEmcode()
        dgdetails2.Rows.Clear()

    End Sub


    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frm_SearchTransNO
            .ISSparent = Me
            .param1 = "Item"

            If Category <> String.Empty And Value <> String.Empty Then
                .cboCategory.Text = Category
                .txtValue.Text = Value
            Else
                .cboCategory.Text = String.Empty
                .txtValue.Text = String.Empty
            End If
            .ShowDialog()
            Call SelectITEmcode()
            rownum = inc


        End With
    End Sub

    Private Sub dgdetails2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetails2.CellContentClick

    End Sub
End Class