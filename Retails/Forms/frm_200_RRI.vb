Imports Retails.clsPublic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frm_200_RRI
#Region "Variable"
    Implements IBPSCommand
    Public bolFormState As clsPublic.FormState
    Dim ErrProvider As New ErrorProviderExtended
    Public Category, value As String
    Private rownum As Integer
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
        btnnext.Visible = isVergin
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

    Public Sub ProcessFormCommand(ByVal strCmd As String) Implements IBPSCommand.ProcessFormCommand

    End Sub
    Sub SaveRecord()

    End Sub
    Sub doCancel()
        ErrProvider.ClearAllErrorMessages()
        LockFields(True)
        ''grpList.Enabled = True

        Me.Close()

    End Sub
    Sub clear()
        txtsupplierid.Clear()
        txtsuppliername.Clear()
        txtsupplierAddress.Clear()
        txtsuppliertype.Clear()
    End Sub
    Sub fillcode(ByVal rowindex As Integer)
        With dgDetails
            .Item("colitemstock", rowindex).Value = DBLookUp("Select Quantity from tbl_100_RR_Temp where RRNo='" & txtRRNo.Text & "' and SpecificCode='" & .Item("colSpecificCode", rowindex).Value & "'", "Quantity")

        End With
    End Sub

    Sub selectRRNo()
        Try
            Dim arrParameterAndValue As ArrayList = New ArrayList
            arrParameterAndValue = FetchData(arrParameterAndValue, "Select RRDate,RefOrderNo,RRType,Reference from tbl_100_RR where RRNO='" & txtRRNo.Text & "'", CommandType.Text)

            If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                '-->indicate if the row is null
            Else
                txtrrdate.Text = FormatDateTime(arrParameterAndValue(0).ToString, DateFormat.ShortDate)
                txtreforderno.Text = arrParameterAndValue(1).ToString
                txtrrtype.Text = arrParameterAndValue(2).ToString
                txtrrreference.Text = arrParameterAndValue(3).ToString
            End If

            SQL = "SELECT     tbl_100_RR_Sub.SupplierID, tbl_000_Supplier.SupplierName, tbl_000_Supplier.Address, tbl_000_Supplier_Type.SupTypeName " & _
                    "FROM         tbl_100_RR_Sub INNER JOIN " & _
                      "tbl_000_Supplier ON tbl_100_RR_Sub.SupplierID = tbl_000_Supplier.SupplierID INNER JOIN " & _
                      "tbl_000_Supplier_Type ON tbl_000_Supplier.SupplierType = tbl_000_Supplier_Type.SupTypeID " & _
                "WHERE     (tbl_100_RR_Sub.RRNo = '" & txtRRNo.Text & "') " & _
                "GROUP BY tbl_100_RR_Sub.SupplierID, tbl_000_Supplier.SupplierName, tbl_000_Supplier.Address, tbl_000_Supplier_Type.SupTypeName"

            arrParameterAndValue.Clear()
            arrParameterAndValue = FetchData(arrParameterAndValue, SQL, CommandType.Text)
            If arrParameterAndValue Is Nothing Or arrParameterAndValue.Count = 0 Then
                ''
            Else


                If txtrrtype.Text = "PO" Or txtrrtype.Text = "JO" Then
                    clear()
                    txtsupplierid.Text = arrParameterAndValue(0).ToString
                    txtsuppliername.Text = arrParameterAndValue(1).ToString  ''get the supplier name
                    txtsupplierAddress.Text = arrParameterAndValue(2).ToString ''get the supplier address
                    txtsuppliertype.Text = arrParameterAndValue(3)
                    colSupplierId.Visible = False
                    colrefprno.Visible = False
                    FillDataGrid(dgDetails, "Get_RRI'" & txtrrtype.Text & "','" & txtRRNo.Text & "'", 4, 18) ''Fill the the field in datagrid dgdetails
                    For i = 0 To dgDetails.RowCount - 1
                        fillcode(i) ''fill the column Item Stock
                        dgDetails.Item("colitemstock", i).Value = FormatNumber(dgDetails.Item("colitemstock", i).Value, 2)
                    Next
                    ComputeAllRows() ''compute the amount
                ElseIf txtrrtype.Text = "Cash" Then
                    clear() ''Clear the Supplier Details if the RR Type is Cash
                    colSupplierId.Visible = True ''Show the Supplier Columns
                    colrefprno.Visible = True ''Show the PR Columns
                    FillDataGrid(dgDetails, "Get_RRI'" & txtrrtype.Text & "','" & txtRRNo.Text & "'", 2, 18) ''Fill the the field in datagrid dgdetails
                    For i = 0 To dgDetails.RowCount - 1
                        fillcode(i) ''fill the column Item Stock
                        dgDetails.Item("colitemstock", i).Value = FormatNumber(dgDetails.Item("colitemstock", i).Value, 2)
                    Next
                    ComputeAllRows() ''compute the amount
                    txtsupplierid.Text = arrParameterAndValue(0).ToString
                    txtsuppliername.Text = arrParameterAndValue(1).ToString  ''get the supplier name
                    txtsupplierAddress.Text = arrParameterAndValue(2).ToString ''get the supplier address
                    txtsuppliertype.Text = arrParameterAndValue(3)
                End If
            End If



            dgdetails2.Rows.Clear() ''Clear the dgdetails2
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
            txtTotalConverted.Text = FormatNumber(NZ(sum))
        End With
    End Sub
    Sub computewithdrawal()
        Dim sum As Double
        Dim totalQTY As Double
        With dgdetails2
            For i = 0 To .RowCount - 1
                sum = sum + NZ(.Item("colcovertedAmount", i).Value)
                totalQTY = totalQTY + NZ(.Item("colconvertedQTY", i).Value)

            Next
            txtwithdrawalamount.Text = FormatNumber(NZ(sum))
            txttotalQTY.Text = FormatNumber(totalQTY, 2)
        End With
    End Sub







#End Region

#Region "GUI"

    Private Sub frm_300_RRI_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        setUserRights(Me.Tag)
    End Sub

    Private Sub frm_300_RRI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me) 'Resize the  form 
        CenterControl(lblTitle, Me) 'center the title of the transaction

        ''Used to Next or Back data
        inc = 0
        isnext = False
        ActivateCommands(FormState.ViewState)
       
    End Sub

    Private Sub dgDetails_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgdetails2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        lblcountsub2.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub dgdetails2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        lblcountsub2.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub txtRRNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRRNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            selectRRNo()
        End If
    End Sub


    Private Sub dgDetails_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Try
            Select Case e.ColumnIndex
                Case 0
                    Dim ShowReport As New frm_200_ReportV
                    Dim cryRpt As New ReportDocument
                    With ShowReport
                        cryRpt.Load(Application.StartupPath & "\Reports\rpt_200_RRS.rpt")

                        With cryRpt
                            .Refresh()
                            .SetDataSource(FillReportForm("sp_rpt_RRS '" & txtRRNo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", "tbl_100_RR_Sub"))
                            .SetParameterValue("pre", CurrUser.USER_FULLNAME)
                        End With
                        .rpt_viewer.ReportSource = cryRpt
                        .Text = lblTitle.Text
                        .Show()
                    End With
                Case 1
                    Dim a As String
                    a = DBLookUp("Select * from tbl_100_WR_Sub where RRno='" & txtRRNo.Text & "'", "RRNo")
                    With dgDetails

                        If txtRRNo.Text = "" Then
                            MsgBox("Empty RR No.", MsgBoxStyle.Exclamation)
                            Exit Sub
                        ElseIf dgDetails.Item("colSpecificCode", e.RowIndex).Value = "" Then
                            MsgBox("Specific Code is empty!", MsgBoxStyle.Exclamation)
                            Exit Sub
                        Else
                            If txtRRNo.Text.Trim = a.Trim Then
                                FillDataGrid(dgdetails2, "Get_RRI_WithdrawalDetails'" & txtRRNo.Text & "','" & dgDetails.Item("colSpecificCode", e.RowIndex).Value & "'", 0, 19)
                                'dgdetails2.Item("colAccountabilityNo", e.RowIndex).Value = DBLookUp("Select ARno from tbl_100_AR_Sub where(WRno='" & dgdetails2.Item("colWrno", e.RowIndex).Value & "')", "ARNo")
                                computewithdrawal()
                            End If
                        End If
                    End With
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With frm_SearchTransNO
            .RRparent = Me
            .param1 = "RR"
            If Category <> String.Empty And value <> String.Empty Then
                .cboCategory.Text = Category
                .txtValue.Text = value
            Else
                .cboCategory.Text = String.Empty
                .txtValue.Text = String.Empty
            End If
            .ShowDialog()
            Call selectRRNo()
            rownum = inc
        End With
    End Sub

    Private Sub dgDetails_RowsAdded1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgDetails.RowsAdded
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgDetails_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgDetails.RowsRemoved
        lblCountSub.Text = CountGridRows(dgDetails)
    End Sub

    Private Sub dgdetails2_RowsAdded1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetails2.RowsAdded
        lblcountsub2.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub dgdetails2_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdetails2.RowsRemoved
        lblcountsub2.Text = CountGridRows(dgdetails2)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        If rownum <> 0 Then inc = rownum
        txtRRNo.Text = Navigation("sp_GetControlNo'" & "RR" & "','" & Category & "','" & value & "'", "tbl_100_RR", "RRNo", "Next")
        Call selectRRNo()
        dgdetails2.Rows.Clear()
        rownum = inc
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        If rownum <> 0 Then inc = rownum
        txtRRNo.Text = Navigation("sp_GetControlNo'" & "RR" & "','" & Category & "','" & value & "'", "tbl_100_RR", "RRNo", "Back")
        Call selectRRNo()
        dgdetails2.Rows.Clear()
        rownum = inc
    End Sub


#End Region


End Class