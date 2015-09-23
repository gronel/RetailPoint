Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports TOPCInventorySales.clsPublic
Public Class frm_200_PSI
#Region "Variable"
    Implements IBPSCommand
    Public bolFormState As clsPublic.FormState
    Dim _ProductCode, _Orderno As String

    Public category As String
    Public value As String
    Public rownum As Integer

 

#End Region

#Region "Procedure"

    Public Sub navigationButton(ByVal isvergin)
        btnback.Visible = isvergin
        btnnext.Visible = isvergin
    End Sub

    Private Sub Cleartxt()
        txttotalQTY.Text = 0
        txttotalAMT.Text = 0
        txttotalJPY.Text = 0
        txttotalPHP.Text = 0
    End Sub

    Private Sub FillTotal()
        Dim _totalQTY As Double
        Dim _totalActual As Double
        Dim _totalJPY As Double
        Dim _totalPHP As Double

        For Each row As DataGridViewRow In DgDeliveryDetails.Rows
            If row.IsNewRow = False Then
                _totalQTY += CDbl(row.Cells("colDRQTY").Value)
                _totalActual += CDbl(row.Cells("colDRAMT").Value)
                _totalJPY += CDbl(row.Cells("colDRJPY").Value)
                _totalPHP += CDbl(row.Cells("colDRPHP").Value)
                lblcurrency.Text = row.Cells("colDRCtype").Value
            End If
        Next

        txttotalQTY.Text = FormatNumber(_totalQTY, 2)
        txttotalAMT.Text = FormatNumber(_totalActual, 2)
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

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

    End Sub

    Private Sub validatedFields()
        For Each row As DataGridViewRow In DgOrderDetails.Rows
            If row.IsNewRow = False Then
                row.Cells("colorderunitprice").Value = FormatNumber(row.Cells("colorderunitprice").Value, CInt(row.Cells("colProductdec").Value))
            End If
        Next
    End Sub

    Public Sub FillMainDetails()
        arrParametersAndValue.Clear()
        _ProductCode = txtProductCode.Text
        arrParametersAndValue = FetchData(arrParametersAndValue, "sp_200_PSI 'GetMain','" & _ProductCode & "'", CommandType.Text)

        If arrParametersAndValue.Count > 0 Then
            txtPartno.Text = arrParametersAndValue(1).ToString
            'txtToccode.Text = arrParametersAndValue(2).ToString
            txtProductName.Text = arrParametersAndValue(2).ToString
            txtProductType.Text = arrParametersAndValue(3).ToString
            txtCustomer.Text = arrParametersAndValue(4).ToString
            txtcustomerAdd.Text = arrParametersAndValue(5).ToString
            txtPaymentTerm.Text = arrParametersAndValue(6).ToString
            txtStatus.Text = arrParametersAndValue(7)
            txtusage.Text = arrParametersAndValue(8).ToString
            txtinternalsupplier.Text = arrParametersAndValue(9).ToString
            txtproductmodel.Text = arrParametersAndValue(10).ToString
        End If

        FillDataGrid(DgOrderDetails, "sp_200_PSI 'GetMainDetails','" & _ProductCode & "'", 0, 16)
        ClearDatGridView(DgDeliveryDetails)
        Cleartxt()
        validatedFields()
    End Sub

#End Region
    Private Sub frm_200_OSI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me) 'Resize the  form 
        CenterControl(lblTitle, Me) 'cent
        ActivateCommands(FormState.ViewState)
    End Sub


    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub txtPRNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            FillMainDetails()
        End If
    End Sub

    Private Sub txtProductCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductCode.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frm_SearchTransNO
            .ProductInquery = Me
            .param1 = "Product"
            If category <> String.Empty And value <> String.Empty Then
                .cboCategory.Text = category
                .txtValue.Text = value
            Else
                .cboCategory.Text = String.Empty
                .txtValue.Text = String.Empty
            End If
            .ShowDialog()
            DgOrderDetails.Rows.Clear()
            DgDeliveryDetails.Rows.Clear()
            Call FillMainDetails()
            rownum = inc
        End With
    End Sub

    Private Sub btnback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        If rownum <> 0 Then inc = rownum
        txtProductCode.Text = Navigation("sp_SearchProductInquery 1,'" & value & "'", "tbl_000_Product", "ProductCode", "Back")
        Call FillMainDetails()
        DgDeliveryDetails.Rows.Clear()
        rownum = inc
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If rownum <> 0 Then inc = rownum
        txtProductCode.Text = Navigation("sp_SearchProductInquery 1,'" & value & "'", "tbl_000_Product", "ProductCode", "Next")
        Call FillMainDetails()
        DgDeliveryDetails.Rows.Clear()
        rownum = inc
    End Sub

    Private Sub DgOrderDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgOrderDetails.CellContentClick
        Select Case e.ColumnIndex
            Case 0
                Dim ShowReport As New frm_200_ReportV
                With ShowReport
                    cryRpt.Load(Application.StartupPath & "\reports\rpt_200_PSI.rpt")
                    With cryRpt
                        .SetDataSource(FillReportForm("sp_rpt_PSI'" & txtProductCode.Text & "','" & DgOrderDetails.Item("colorderNo", e.RowIndex).Value & "'", "tbl_000_Product"))
                        .Subreports("DR").SetDataSource(FillReportForm("sp_rpt_PSI_DR '" & txtProductCode.Text & "','" & DgOrderDetails.Item("colorderNo", e.RowIndex).Value & "'", "tbl_000_Product"))
                        .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                    End With
                    .rpt_viewer.ReportSource = cryRpt
                    .Show()
                    .Focus()
                    .Text = "Product Status Inquery "
                End With
            Case 1
                _Orderno = DgOrderDetails.SelectedRows(0).Cells(2).Value
                FillDataGrid(DgDeliveryDetails, "sp_200_PSI 'GetDRDetails','" & txtProductCode.Text & "','" & _Orderno & "'", 0, 14)
                FillTotal()
        End Select
    End Sub

    Private Sub DgOrderDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgOrderDetails.RowsAdded
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
End Class