Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO

Module modProcedure

    Public Sub cleanTmpFolder()
        Dim tempfolderpath As String = currPath & "\tmpIMG"
        Try

            For Each fname As String In Directory.GetFiles(tempfolderpath)
                File.Delete(fname)
            Next


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Prompt")
        End Try
    End Sub
    
    ''' <summary>
    ''' Hide tab in Crystal report viewer
    ''' </summary>
    ''' <param name="crv"> viewer name</param>
    ''' <remarks></remarks>
    Public Sub HideTheTabControl(ByVal crv As CrystalDecisions.Windows.Forms.CrystalReportViewer)



        System.Diagnostics.Debug.Assert(crv.ReportSource IsNot Nothing, "you have to set the ReportSource first")



        For Each c1 As Control In crv.Controls

            If TypeOf c1 Is CrystalDecisions.Windows.Forms.PageView Then

                Dim pv As CrystalDecisions.Windows.Forms.PageView = DirectCast(c1, CrystalDecisions.Windows.Forms.PageView)

                For Each c2 As Control In pv.Controls

                    If TypeOf c2 Is TabControl Then

                        Dim tc As TabControl = DirectCast(c2, TabControl)

                        tc.ItemSize = New Size(0, 1)

                        tc.SizeMode = TabSizeMode.Fixed

                    End If

                Next

            End If

        Next

    End Sub






    Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Integer, ByVal ByValfRequest As Integer, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Integer
    Private Declare Function SQLInstallerError Lib "ODBCCP32.DLL" (ByVal iError As Integer, ByRef pfErrorCode As Integer, ByVal lpszErrorMsg As System.Text.StringBuilder, ByVal cbErrorMsgMax As Integer, ByRef pcbErrorMsg As Integer) As Integer

    Private Const ODBC_ADD_DSN As Short = 1 ' Add data source
    Private Const ODBC_ADD_SYS_DSN As Short = 4
    Private Const vbAPINull As Integer = 0 ' NULL Pointer

    Public Sub CreateSystemDSN()
        'create dsn programmatically
        Try


            Dim ReturnValue As Integer
            Dim Driver As String
            Dim Attributes As String

            'Set the driver to SQL Server because it is most common.
            Driver = "SQL Server"
            'Set the attributes delimited by null.
            'See driver documentation for a complete
            'list of supported attributes.
            Attributes = "SERVER=" & dbServer & Chr(0)
            Attributes = Attributes & "DESCRIPTION=" & dbName & Chr(0)
            Attributes = Attributes & "DSN=" & dbName & Chr(0)
            Attributes = Attributes & "DATABASE=" & dbName & Chr(0)
            'Attributes = Attributes & "Uid=" & Chr(0) & "pwd=" & Chr(0)
            'To show dialog, use Form1.Hwnd instead of vbAPINull.
            ReturnValue = SQLConfigDataSource(vbAPINull, ODBC_ADD_SYS_DSN, Driver, Attributes)
            If ReturnValue <> 0 Then
                'MsgBox("DSN Created")
            Else
                'MsgBox("ODBC Connection Failed")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillListView(ByRef lvList As ListView, ByRef myData As SqlDataReader)
        Dim itmListItem As ListViewItem

        Dim strValue As String

        Do While myData.Read
            strValue = myData.GetValue(1)
            itmListItem = New ListViewItem()
            strValue = IIf(myData.IsDBNull(0), "", myData.GetValue(0))
            itmListItem.Text = strValue
            For shtCntr = 1 To myData.FieldCount() - 1
                If myData.IsDBNull(shtCntr) Then
                    itmListItem.SubItems.Add("")
                Else
                    itmListItem.SubItems.Add(myData.GetValue(shtCntr))
                End If
            Next shtCntr

            lvList.Items.Add(itmListItem)

        Loop
    End Sub
    ''' <summary>
    ''' isert data from database to combobox
    ''' </summary>
    ''' <param name="cboCombo"></param>
    ''' <param name="sSQL"></param>
    ''' <param name="strTable"></param>
    ''' <param name="strDisplayMember"></param>
    ''' <param name="strValueMember"></param>
    ''' <remarks></remarks>
    Public Sub FillCombobox(ByVal cboCombo As ComboBox, ByVal sSQL As String, ByVal strTable As String, ByVal strDisplayMember As String, ByVal strValueMember As String)


        Try
            Dim myConn As SqlConnection = New SqlConnection(cnString)
            Dim da As SqlDataAdapter = New SqlDataAdapter(sSQL, myConn)
            Dim dt As DataTable = New DataTable(strTable)

            da.Fill(dt)
            cboCombo.DataSource = dt
            cboCombo.DisplayMember = strDisplayMember
            cboCombo.ValueMember = strValueMember

        Catch ex As Exception
            MsgBox("Error : FillCombobox " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    ''' <summary>
    ''' Get data from database and display to DatagridViewComboboxColumn
    ''' </summary>
    ''' <param name="cboCombo"></param>
    ''' <param name="sSQL"></param>
    ''' <param name="strTable"></param>
    ''' <param name="strDisplayMember"></param>
    ''' <param name="strValueMember"></param>
    ''' <remarks></remarks>
    Public Sub FillGridCombobox(ByVal cboCombo As DataGridViewComboBoxColumn, ByVal sSQL As String, ByVal strTable As String, ByVal strDisplayMember As String, ByVal strValueMember As String)


        Try
            OpenDB()

            Dim daCombo As SqlDataAdapter = New SqlDataAdapter(sSQL, cn)
            Dim dtCombo As New DataSet

            daCombo.Fill(dtCombo, strTable)

            cboCombo.DataSource = dtCombo.Tables(strTable).DefaultView
            cboCombo.DisplayMember = strDisplayMember
            cboCombo.ValueMember = strValueMember

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR [FillGridCombo]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            cn.Close()
        End Try
    End Sub
    Public Sub SelectFrmGrid(ByVal srcGrid As DataGridView, ByVal srcCMD As Button)
        Dim i As Integer
        Dim chkVal As Boolean

        chkVal = Not chkVal
        i = 0
        Do Until i = srcGrid.RowCount - 1
            srcGrid.Rows(i).Selected = chkVal
            i = i + 1
        Loop

        If chkVal = True Then
            srcCMD.Text = "Unselect"
        Else
            srcCMD.Text = "Select All"
        End If

    End Sub

    Public Sub DeleteFrmGrid(ByVal srcGrid As DataGridView)
        Try
            For Each row As DataGridViewRow In srcGrid.SelectedRows
                srcGrid.Rows.Remove(row)
            Next
        Catch ex As Exception

        End Try

    End Sub

    'Procedure used to highlight text when focus
    Public Sub HLText(ByRef sText As Object)
        On Error Resume Next
        With sText
            .SelStart = 0
            .SelLength = Len(sText.Text)
        End With
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sql">SQL string</param>
    ''' <param name="srcTable">src table</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FillReportForm(ByVal sql As String, ByVal srcTable As String)
        Dim con As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As DataTable
        Try
            con = New SqlConnection(cnString)
            da = New SqlDataAdapter(sql, con)
            dt = New DataTable(srcTable)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function
    Public Sub FillDataGridViewComboBoxColumn(ByVal srcComboBoxColumn As DataGridViewComboBoxColumn, _
                                                   ByVal srcSQL As String, ByVal srcTableName As String, _
                                                   ByVal srcDisplayMember As String, ByVal srcValueMember As String)
        Dim con As New SqlConnection(cnString)
        Try
            Dim daCombo As SqlDataAdapter = New SqlDataAdapter(srcSQL, con)
            Dim dsCombo As New DataSet
            daCombo.Fill(dsCombo, srcTableName)
            srcComboBoxColumn.DataSource = dsCombo.Tables(srcTableName).DefaultView
            srcComboBoxColumn.DisplayMember = srcDisplayMember
            srcComboBoxColumn.ValueMember = srcValueMember
            daCombo.Dispose()
            dsCombo.Dispose()
        Catch ex As Exception
            MsgBox("Error : FillDataGridViewComboBoxColumn in clsProcedures." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error")
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub



    ''' <summary>
    ''' Update Transaction
    ''' </summary>
    ''' <param name="str"></param>
    ''' <remarks></remarks>
    Public Sub UpdateTrans(ByVal str As String)
        Try
            _OpenTransaction()
            Using com As New SqlCommand(str, _Connection, _Transaction)
                com.CommandType = CommandType.Text
                com.ExecuteNonQuery()
            End Using
            _CloseTransaction(True)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    ''' <summary>
    ''' Run SQL Query
    ''' </summary>
    ''' <param name="str">Query String or Stored Procedure</param>
    ''' <remarks></remarks>
    Public Sub RunQuery(ByVal str As String)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Try
            con.ConnectionString = cnString
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            cmd.Connection = con
            cmd.CommandText = str
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            con.Close()
        End Try
    End Sub
   
 


    Public Sub GetCompany()
        Dim paramlist As New ArrayList

        paramlist = FetchData(paramlist, "Select * from tbl_000_Company", CommandType.Text)
        If paramlist.Count <> 0 Then
            CompanyName = paramlist(1).ToString
            CompanyAddress = paramlist(2).ToString
        End If
    End Sub

    ''' <summary>
    ''' Clears datagridview.
    ''' </summary>
    ''' <param name="srcDataGridView">The datagridview to be cleared.</param>
    ''' <remarks>Clears datagridview.</remarks>
    Public Sub ClearDatGridView(ByVal srcDataGridView As DataGridView)
        Try
            If srcDataGridView.DataSource IsNot Nothing Then
                If TypeOf srcDataGridView.DataSource Is DataTable Then
                    DirectCast(srcDataGridView.DataSource, DataTable).Clear()
                ElseIf TypeOf srcDataGridView.DataSource Is DataView Then
                    DirectCast(srcDataGridView.DataSource, DataView).Table.Clear()
                End If
            Else
                srcDataGridView.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox("Error : ClearDatGridView in Procedures." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub


    ''' <summary>
    ''' Check the item if Selected if Exist then the item will remove in the search box
    ''' </summary>
    ''' <param name="dgGrid">Target Datagridview</param>
    ''' <param name="myGrid">Source Datagridview</param>
    ''' <param name="colNameCode">Target Cell</param>
    ''' <param name="mycolNameCode">Source Cell</param>
    ''' <remarks></remarks>
    Public Sub FillItemsOrProducts(ByVal dgGrid As DataGridView, ByVal myGrid As DataGridView, ByVal colNameCode As String, ByVal mycolNameCode As String)

        For Each row As DataGridViewRow In dgGrid.Rows
            For Each myrow As DataGridViewRow In myGrid.Rows
                If myrow.Cells(mycolNameCode).Value = row.Cells(colNameCode).Value Then
                    myGrid.Rows.Remove(myrow)
                End If
            Next
        Next
    End Sub


End Module

