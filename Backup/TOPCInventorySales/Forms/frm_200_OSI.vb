Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports TOPCInventorySales.clsPublic
Public Class frm_200_OSI
    
#Region "Variable"
    
    Implements IBPSCommand



    Public bolFormState As clsPublic.FormState

    Dim _OrderNo As String
    Dim _ProductCode As String
    Dim cryRpt As New ReportDocument
    Public category As String
    Public value As String
    Public rownum As Integer

#End Region

#Region "Procedure"

    Sub addDRfields()
        For Each row As DataGridViewRow In DgDeliveryDetails.Rows
            If row.IsNewRow = False Then
                row.Cells("colDRUnitPrice").Value = FormatNumber(row.Cells("colDRUnitPrice").Value, NZ(row.Cells("colDRdec").Value))
            End If
        Next
    End Sub

    Sub Addfiels()
        For Each row As DataGridViewRow In DgOrderDetails.Rows
            If row.IsNewRow = False Then
                row.Cells("colunitPrice").Value = FormatNumber(row.Cells("colunitPrice").Value, NZ(row.Cells("coldec").Value))
                row.Cells("Column23").Value = NZ(row.Cells("Column7").Value) * NZ(txtXratePHP.Text)
                row.Cells("Column4").Value = FormatNumber(row.Cells("Column4").Value, 2)
            End If
        Next
    End Sub

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand
  
    End Sub


    Private Sub Clear(ByVal category As Integer)

        Select Case category
            Case 0
               

            Case 1
                ClearDatGridView(DgDeliveryDetails)
                txttotalAmount.Text = String.Empty
                txttotalJPY.Text = String.Empty
                txttotalPHP.Text = String.Empty
                txttotalqty.Text = String.Empty

        End Select
    End Sub

    Private Sub FillTotal()
        Dim _totalQTY, _totalAMT, _totalJPY, _totalPHP As Double
        For Each row As DataGridViewRow In DgDeliveryDetails.Rows

            If row.IsNewRow = False Then

                _totalQTY += CDbl(row.Cells("colDRQTY").Value)
                _totalAMT += CDbl(row.Cells("colDRAMT").Value)
                _totalJPY += CDbl(row.Cells("colDRAMTJPY").Value)
                _totalPHP += CDbl(row.Cells("colDRPHP").Value)

            End If

        Next

        txttotalqty.Text = FormatNumber(_totalQTY, 2)
        txttotalAmount.Text = FormatNumber(_totalAMT, 2)
        txttotalJPY.Text = FormatNumber(_totalJPY, 2)
        txttotalPHP.Text = FormatNumber(_totalPHP, 2)

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

    Public Sub FetchMainDetails()

        _OrderNo = txtorderno.Text
        If _OrderNo = String.Empty Then Exit Sub
        arrParametersAndValue.Clear()
        arrParametersAndValue = FetchData(arrParametersAndValue, "sp_200_OSI 'mainDetails','" & _OrderNo & "'", CommandType.Text)

        If arrParametersAndValue.Count > 0 Then
            txtOrderType.Text = arrParametersAndValue(1).ToString
            txtOrderDate.Text = FormatDateTime(CDate(arrParametersAndValue(2)), DateFormat.ShortDate)
            txtXrateJPY.Text = FormatNumber(arrParametersAndValue(3), 2)
            txtXratePHP.Text = FormatNumber(arrParametersAndValue(4), 2)
            txtcustomer.Text = arrParametersAndValue(5).ToString & " - " & arrParametersAndValue(6).ToString
            txtaddress.Text = arrParametersAndValue(7).ToString
            txtPaymentterm.Text = arrParametersAndValue(8).ToString
            lblActualCtype.Text = arrParametersAndValue(9).ToString
        End If

        FillDataGrid(DgOrderDetails, "sp_200_OSI 'OrderDetails','" & _OrderNo & "'", 0, 17)

        Addfiels()
    End Sub

    Public Sub navigationButton(ByVal isvergin)
        btnback.Visible = isvergin
        btnNext.Visible = isvergin
    End Sub

#End Region

#Region "GUI"

    Private Sub frm_200_OSI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me) 'Resize the  form 
        CenterControl(lblTitle, Me) 'cent
        ActivateCommands(FormState.ViewState)
    End Sub

    Private Sub txtorderno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtorderno.KeyDown
        If e.KeyCode = Keys.Enter Then
            FetchMainDetails()
        End If
    End Sub


    Private Sub DgOrderDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgOrderDetails.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                Dim ShowReport As New frm_200_ReportV
                With ShowReport
                    cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_OSI.rpt")

                    If isRecordExist("sp_rpt_OIS'" & txtorderno.Text & "','" & DgOrderDetails.Item(2, e.RowIndex).Value & "'") = False Then
                        MsgBox("NO DATA!", MsgBoxStyle.Information, "Prompt")
                        Exit Sub
                    End If

                    With cryRpt
                        .Refresh()
                        .SetDataSource(FillReportForm("sp_rpt_OIS'" & txtorderno.Text & "','" & DgOrderDetails.Item(2, e.RowIndex).Value & "'", "tbl_100_Order_Sub"))
                        '.Subreports("rr").SetDataSource(FillReportForm("sp_rpt_POS_RR'" & txtPONo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "tbl_100_RR_Sub"))
                        .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                    End With
                    .rpt_viewer.ReportSource = cryRpt
                    .Show()
                End With
            Case 1
                Clear(1)
                _ProductCode = DgOrderDetails.Item(2, DgOrderDetails.CurrentRow.Index).Value
                FillDataGrid(DgDeliveryDetails, "sp_200_OSI 'DRDetails','" & _OrderNo & "','" & _ProductCode & "'", 0, 15)
                FillTotal()
                addDRfields()
        End Select
    End Sub

    Private Sub DgOrderDetails_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgOrderDetails.RowsAdded
        lblOrderDetails.Text = CountGridRows(DgOrderDetails)
    End Sub

    Private Sub DgOrderDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgOrderDetails.RowsRemoved
        lblOrderDetails.Text = CountGridRows(DgOrderDetails)
    End Sub

    Private Sub DgDeliveryDetails_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgDeliveryDetails.RowsAdded
        lblDeliveryDetails.Text = CountGridRows(DgDeliveryDetails)
    End Sub

    Private Sub DgDeliveryDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgDeliveryDetails.RowsRemoved
        lblDeliveryDetails.Text = CountGridRows(DgDeliveryDetails)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frm_SearchTransNO
            .OrderInquery = Me
            .param1 = "Order"
            If value <> String.Empty Then

                .txtValue.Text = value
            Else

                .txtValue.Text = String.Empty
            End If
            .ShowDialog()
            DgOrderDetails.Rows.Clear()
            DgDeliveryDetails.Rows.Clear()
            Call FetchMainDetails()
            rownum = inc
        End With
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If rownum <> 0 Then inc = rownum
        txtorderno.Text = Navigation("sp_SearchProductInquery 2,'" & value & "'", "tbl_100_Order", "OrderNo", "Next")
        Call FetchMainDetails()
        DgDeliveryDetails.Rows.Clear()
        rownum = inc
    End Sub

    Private Sub btnback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        If rownum <> 0 Then inc = rownum
        txtorderno.Text = Navigation("sp_SearchProductInquery 2,'" & value & "'", "tbl_100_Order", "OrderNo", "Back")
        Call FetchMainDetails()
        DgDeliveryDetails.Rows.Clear()
        rownum = inc
    End Sub


#End Region

  
End Class


