Imports Retails.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_200_JRS


#Region "variable"


    Implements IBPSCommand
    Public bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Dim cctype As String
    Public category As String
    Public value As String
    Public rownum As Integer
#End Region

#Region "Procedure"

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

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
                    
                    .tsPrint.Enabled = False
                    .tsPreview.Enabled = False
                    .tsSearch.Enabled = False
                    .btnSearch.Enabled = False
                    .tsFilterOn.Enabled = False
                    .tsFilterClear.Enabled = False

            End Select

        End With
    End Sub

    Sub LockFields(ByVal bolValue As Boolean)
        Try
            ''txtEmpID.ReadOnly = bolValue
            ''txtEmpName.ReadOnly = bolValue
            ''txtUsername.ReadOnly = bolValue
            ''txtPassword.ReadOnly = bolValue
            ''cboGroup.Enabled = Not bolValue
            ''txtVerify.ReadOnly = bolValue
            ''chkIsActive.Enabled = Not bolValue
            ''dgRights.ReadOnly = bolValue
            ''colFormName.ReadOnly = True
            ''btnAdd.Enabled = Not bolValue
            ''btnRemove.Enabled = Not bolValue
            ''btnBrowse.Enabled = Not bolValue

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Lock Fields")
        End Try
    End Sub

    Sub EnterJR()
        Try
            txtdeptCode.Text = DBLookUp("Select * from tbl_100_Jr where JRno='" & txtJRNo.Text & "'", "DepartmentCode")
            txtDepartment.Text = DBLookUp("Select * from tbl_000_Department where DepartmentCode='" & txtdeptCode.Text & "'", "DepartmentName")
            txtsectioncode.Text = DBLookUp("Select * from tbl_100_Jr where JRno='" & txtJRNo.Text & "'", "SectionCode")
            txtSection.Text = DBLookUp("Select * from tbl_000_Department where DepartmentCode='" & txtsectioncode.Text & "'", "DepartmentName")
            txtlinecode.Text = DBLookUp("Select * from tbl_100_Jr where JRno='" & txtJRNo.Text & "'", "LineCode")
            txtLine.Text = DBLookUp("Select * from tbl_000_Department where DepartmentCode='" & txtlinecode.Text & "'", "DepartmentName")
            txtsuppliercode.Text = DBLookUp("Select * from tbl_100_Jr where JRno='" & txtJRNo.Text & "'", "Supplierid")
            txtSupplier.Text = DBLookUp("Select * from tbl_000_Supplier where supplierid='" & txtsuppliercode.Text & "'", "SupplierName")
            txtSupplierType.Text = DBLookUp("Select * from tbl_100_Jr where JRno='" & txtJRNo.Text & "'", "SupplierType")
            txtDateRequested.Text = DBLookUp("Select * from tbl_100_Jr where JRno='" & txtJRNo.Text & "'", "Daterequested")
            txtdateneeded.Text = DBLookUp("Select * from tbl_100_Jr where JRno='" & txtJRNo.Text & "'", "Dateneeded")
            txtjoschedule.Text = DBLookUp("Select * from tbl_100_Jr where JRno='" & txtJRNo.Text & "'", "JORRSchedule")
            txtjrtype.Text = DBLookUp("Select * from tbl_100_Jr where JRno='" & txtJRNo.Text & "'", "JRType")
            lblCtype.Text = DBLookUp("Select * from tbl_100_Jr where JRno='" & txtJRNo.Text & "'", "CurrencyType")
            lblcctype2.Text = lblCtype.Text

            FillDataGrid(dgDetails, "Get_JRS'" & txtJRNo.Text & "'", 2, 14)
            ComputeAllRows()

            dgdetails2.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Sub ComputeAllRows()
        Dim sum As Double
        With dgDetails
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colamount", i).Value)
            Next
            txtJRamount.Text = FormatNumber(NZ(sum))
        End With
    End Sub

    Sub ComputeAllRows2()
        Dim sum As Double
        With dgdetails2
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("ColAmount2", i).Value)
            Next
            txtRRamount.Text = FormatNumber(NZ(sum))
        End With
    End Sub

    Sub ComputeAllRowsQTY()
        Dim sum As Integer
        With dgdetails2
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colQty", i).Value)
            Next
            txtrrQTY.Text = sum
        End With
    End Sub

    Public Sub navigationButton(ByVal isvirgen As Boolean)
        btnback.Visible = isvirgen
        btnnext.Visible = isvirgen
    End Sub

#End Region

#Region "GUI"

    Private Sub frm_300_JRS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me) 'Resize the  form 
        CenterControl(lblTitle, Me) 'center the title of the transaction

        ''Used to Next or back the data 
        inc = 0
        isnext = False
        ActivateCommands(FormState.ViewState)
        
    End Sub

    Private Sub txtJRNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtJRNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call EnterJR()
            dgdetails2.Rows.Clear()
        End If
    End Sub


    Private Sub txtJRNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJRNo.TextChanged
        Call EnterJR()
        dgdetails2.Rows.Clear()
    End Sub

    Private Sub dgDetails_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick

        Try
            Select Case e.ColumnIndex
                Case 0
                    Dim ShowReport As New frm_200_ReportV
                    With ShowReport
                        Dim cryrpt As New ReportDocument
                        cryrpt.Load(Application.StartupPath & "\Reports\rpt_200_JRS.rpt")
                        With cryrpt

                            .SetDataSource(FillReportForm("sp_rpt_JRS '" & txtJRNo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "tbl_100_JR_Sub"))
                            .Subreports("rr").SetDataSource(FillReportForm("sp_rpt_JRS_RR '" & txtjrtype.Text & "','" & txtJRNo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "tbl_100_RR_Sub"))
                            .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                        End With
                        .rpt_viewer.ReportSource = cryrpt
                        .Show()
                        .Focus()
                        .Text = "Job Requisition Status Report " & txtJRNo.Text
                    End With
                Case 1
                    If txtjrtype.Text = "Cash" Then
                        FillDataGrid(dgdetails2, "Get_JRS_RR'" & "Cash" & "','" & txtJRNo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", 0, 12)
                        ComputeAllRows2()
                        ComputeAllRowsQTY()
                    Else
                        FillDataGrid(dgdetails2, "Get_JRS_RR'" & "JO" & "','" & txtJRNo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", 0, 12)
                        ComputeAllRows2()
                        ComputeAllRowsQTY()
                    End If


            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        Label16.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        Label16.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgdetails2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails2.RowsAdded
        Label10.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub dgdetails2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails2.RowsRemoved
        Label10.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frm_SearchTransNO
            .JRparent = Me
            .param1 = "JR"

            If category <> String.Empty And value <> String.Empty Then
                .cboCategory.Text = category
                .txtValue.Text = value
            Else
                .cboCategory.Text = String.Empty
                .txtValue.Text = String.Empty
            End If
            .ShowDialog()
            dgDetails.Rows.Clear()
            dgdetails2.Rows.Clear()
            Call EnterJR()
            rownum = inc

        End With
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        If rownum <> 0 Then inc = rownum
        txtJRNo.Text = Navigation("sp_GetControlNo'" & "JR" & "','" & category & "','" & value & "'", "tbl_100_JR", "control", "Next")
        Call EnterJR()
        dgdetails2.Rows.Clear()
        rownum = inc

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        If rownum <> 0 Then inc = rownum
        txtJRNo.Text = Navigation("sp_GetControlNo'" & "JR" & "','" & category & "','" & value & "'", "tbl_100_JR", "control", "Back")
        Call EnterJR()
        dgdetails2.Rows.Clear()
        rownum = inc
    End Sub
#End Region
End Class
