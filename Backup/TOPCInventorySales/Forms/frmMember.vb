Imports TOPCInventorySales.clsPublic
Imports System.Data.SqlClient
Public Class frmMember
    Public ar As String
    Public bolFormState As clsPublic.FormState
    Dim userid, departmentid, SEctionID, lineid As String
    Dim oldDepartment As String
    Dim oldSection As String
    Dim paramList As ArrayList = New ArrayList
    Public deptcode, sectioncode, linecode As String
    Sub filldatagridview()
       
        RunQuery("Delete from tmp_Act_Employee where CompName='" & ComputerName & "'")
        'RunQuery("sp_Get_ACT_Employee'" & ComputerName & "','" & ar & "'")
      
        Dim paramarraylist As ArrayList = New ArrayList
        paramarraylist = FetchData(paramarraylist, "select DepartmentCode,SectionCode,LineCode from tmp_Act_Employee where ARNo='" & ar & "'", CommandType.Text)

        If paramarraylist Is Nothing Or paramarraylist.Count = 0 Then

            'With frm_100_AR
            '    deptcode = .cboDepartment.Text
            '    sectioncode = .cboSection.Text
            '    linecode = .cboLine.Text
            'End With


        Else
            deptcode = paramarraylist(0).ToString
            sectioncode = paramarraylist(1).ToString
            linecode = paramarraylist(2).ToString
        End If
       


        With frm_100_AR_
            If deptcode = .cboDepartment.Text And sectioncode = .cboSection.Text And linecode = .cboLine.Text Then
                Call loadcomponent()
                FillDataGrid(dgSearchMembers, "sp_100_AR_GetAR_Member '" & ar & "','" & ComputerName & "'", 0, 2)
                'lblno.Text = dgSearchMembers.RowCount

            Else
                deptcode = .cboDepartment.Text
                sectioncode = .cboSection.Text
                linecode = .cboLine.Text
                Call loadcomponent()
            End If
        End With



    End Sub



    Sub loadcomponent()
        dgSearchMembers.Rows.Clear()
        Dim param2 As String
        SQL = "SELECT FirstName + ' ' + CASE WHEN MiddleName IS NULL THEN '' WHEN MiddleName = ' ' THEN '' ELSE SubString(MiddleName, 1, 1) + '. ' END + LastName + ' ' AS EmpName,EmpID, IsActive FROM tbl_000_Employee WHERE (IsActive = 1)"

        If sectioncode = String.Empty And linecode = String.Empty Then
            param2 = SQL + "and DepartmentCode='" & deptcode & "'"
            FillDataGridViewComboBoxColumn(colID, param2, "tbl_000_Employee", "EmpID", "EmpID")

        ElseIf sectioncode <> String.Empty And linecode = String.Empty Then
            param2 = SQL + " and DepartmentCode='" & deptcode & "' and SectionCode='" & sectioncode & "'"
            FillDataGridViewComboBoxColumn(colID, param2, "tbl_000_Employee", "EmpID", "EmpID")

        ElseIf sectioncode <> String.Empty And linecode <> String.Empty Then
            param2 = SQL + " and DepartmentCode='" & deptcode & "' and SectionCode='" & sectioncode & "' and linecode='" & linecode & "'"

            FillDataGridViewComboBoxColumn(colID, param2, "tbl_000_Employee", "EmpID", "EmpID")
        End If


    End Sub

    Private Sub frmMember_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bolFormState = FormState.EditState Then
            Call filldatagridview()
        Else
            With frm_100_AR_
                deptcode = .cboDepartment.Text
                sectioncode = .cboSection.Text
                linecode = .cboLine.Text
                Call loadcomponent()
            End With


        End If




    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Try
            If MsgBox("Are you sure you want to add this item(s)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item") = MsgBoxResult.Yes Then
                With frm_100_AR_

                    For Each row As DataGridViewRow In dgSearchMembers.Rows
                        If row.IsNewRow = False Then
                            If row.Cells("colMemberName").Value = "" Then
                                MsgBox("Member name is required!", MsgBoxStyle.Exclamation)
                                Exit Sub
                            ElseIf row.Cells("colMemberStatus").Value = "" Then
                                MsgBox("Member status is required!", MsgBoxStyle.Exclamation)
                                Exit Sub
                            End If
                        End If
                    Next

                End With

                ' Call Save_ACT_Employee()
                Me.Close()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
   
 
    Private Sub dgSearchMembers_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearchMembers.CellValidated
        paramList.Clear()
        SQL = "SELECT FirstName + ' ' + CASE WHEN MiddleName IS NULL THEN '' WHEN MiddleName = ' ' THEN '' ELSE SubString(MiddleName, 1, 1) + '. ' END + LastName + ' ' AS EmpName,EmpStatus, IsActive FROM tbl_000_Employee WHERE (IsActive = 1)"
        SQL = SQL + "and empid='" & dgSearchMembers.Item("colID", e.RowIndex).Value & "'"
        paramList = FetchData(paramList, SQL, CommandType.Text)
        If paramList Is Nothing Or paramList.Count = 0 Then
            ''nothing to do
        Else
            dgSearchMembers.Item("colMemberName", e.RowIndex).Value = paramList(0).ToString
            dgSearchMembers.Item("colMemberStatus", e.RowIndex).Value = paramList(1).ToString
        End If
       
    End Sub

    Private Sub dgSearchMembers_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgSearchMembers.RowsAdded
        lblno.Text = CountGridRows(dgSearchMembers)
    End Sub

    Private Sub dgSearchMembers_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgSearchMembers.RowsRemoved
        lblno.Text = CountGridRows(dgSearchMembers)
    End Sub

  
End Class
