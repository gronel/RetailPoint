Imports System.Data.SqlClient

Public Class frmSQLConfig

    Dim ConnectionString As String
    Dim intStep As Integer

    Private Sub FillServer()
        Try


            Cursor = Cursors.WaitCursor

            Dim SqlEnumerator As System.Data.Sql.SqlDataSourceEnumerator
            SqlEnumerator = System.Data.Sql.SqlDataSourceEnumerator.Instance
            Dim dTable As System.Data.DataTable
            dTable = SqlEnumerator.GetDataSources()

            Me.cboServer.Items.Clear()

            For Each row As DataRow In dTable.Rows
                Dim serverName As String = row(0).ToString
                Dim instanceName As String = row(1).ToString

                If String.IsNullOrEmpty(instanceName) Then
                    Me.cboServer.Items.Add(serverName)
                Else
                    Me.cboServer.Items.Add(serverName & "\" & instanceName)
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Fill Server Error")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Sub Filldatabase(ByVal srcComboBox As ComboBox, ByVal srcServerName As String)
        Try
            srcComboBox.Items.Clear()

            If cboServer.Text = "" Then

            ElseIf radSQL.Checked And txtUsername.Text = "" Then

            Else
                Cursor = Cursors.WaitCursor
                If radNT.Checked = True Then
                    ConnectionString = "Server=" & cboServer.Text & ";Database=master;Trusted_Connection=True;"
                Else
                    ConnectionString = "Server=" & cboServer.Text & ";Database=master;User ID=" & txtUsername.Text & ";Password=" & txtPassword.Text & ";Trusted_Connection=False;"
                End If

                Using sqlConn As New SqlConnection(ConnectionString)
                    sqlConn.Open()
                    Dim tblDatabases As DataTable = sqlConn.GetSchema("Databases")
                    sqlConn.Close()

                    For Each row As DataRow In tblDatabases.Rows
                        Dim strDatabaseName As [String] = row("database_name").ToString()
                        srcComboBox.Items.Add(strDatabaseName)
                    Next
                End Using
            End If
        Catch ex As Exception
            MsgBox("Error : Please contact your network administrator." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error")
        Finally
            Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboDatabase_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDatabase.Enter
        Filldatabase(cboDatabase, cboServer.Text)
    End Sub

    Sub GetConnectionString()
        If radNT.Checked = True Then
            ConnectionString = "Server=" & cboServer.Text & ";Database=" & cboDatabase.Text & ";Trusted_Connection=True;"
        Else
            ConnectionString = "Server=" & cboServer.Text & ";Database=" & cboDatabase.Text & ";User ID=" & txtUsername.Text & ";Password=" & txtPassword.Text & ";Trusted_Connection=False;"
        End If
    End Sub

    Private Sub btnTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConnection.Click
        Try
            If cboDatabase.Text = "" Or cboServer.Text = "" Then
                MsgBox("Test connection failed.", MsgBoxStyle.Exclamation, "Test Connection")
            ElseIf radSQL.Checked And txtUsername.Text = "" Then
                MsgBox("Test connection failed.", MsgBoxStyle.Exclamation, "Test Connection")
            Else

                GetConnectionString()
                Using sqlConn As New SqlConnection(ConnectionString)
                    sqlConn.Open()
                    sqlConn.Close()
                End Using

                MsgBox("Test connection succeded.", MsgBoxStyle.Information, "Test Connection")

            End If
        Catch ex As Exception
            MsgBox("Test connection failed.", MsgBoxStyle.Exclamation, "Test Connection")
        End Try

    End Sub

    Private Sub radNT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radNT.CheckedChanged
        If radNT.Checked = True Then
            txtUsername.Enabled = False
            txtPassword.Enabled = False
        Else
            txtUsername.Enabled = True
            txtPassword.Enabled = True
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        FillServer()
    End Sub

    Private Sub cboDatabase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDatabase.SelectedIndexChanged

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        LoginForm.Show()
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try

            GetConnectionString()

            cnString = ConnectionString
            dbServer = cboServer.Text
            dbName = cboDatabase.Text
            dbUser = txtUsername.Text
            dbPass = txtPassword.Text
            dbTrust = radNT.Checked.ToString

            Dim objIniFile As New cINIFile(currPath & "\config.ini")

            objIniFile.WriteString("Setting", "S", clsSecurity.psEncrypt(dbServer))
            objIniFile.WriteString("Setting", "D", clsSecurity.psEncrypt(dbName))
            objIniFile.WriteString("Setting", "U", clsSecurity.psEncrypt(dbUser))
            objIniFile.WriteString("Setting", "P", clsSecurity.psEncrypt(dbPass))
            objIniFile.WriteString("Setting", "T", clsSecurity.psEncrypt(dbTrust))
            objIniFile.WriteString("Setting", "C", clsSecurity.psEncrypt(cnString))

            objIniFile = Nothing

            LoginForm.Show()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub frmSQLConfig_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        LoginForm.Show()
    End Sub

    Private Sub frmSQLConfig_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboServer.Text = dbServer
        cboDatabase.Text = dbName
        txtUsername.Text = dbUser
        txtPassword.Text = ""   '' dbPass
        radNT.Checked = dbTrust
        radSQL.Checked = Not dbTrust
    End Sub
End Class