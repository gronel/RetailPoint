Imports System.Net.Mail
Imports System.Data.SqlClient

Public Class clsSendEmail

    Public Shared Sub sendMail(ByVal recipient As String, ByVal subject As String, ByVal body As String)

        Try

            Dim con As New SqlConnection(cnString)
            Dim rdr As SqlDataReader
            Dim cmd As New SqlCommand("SELECT * FROM tblEMailSetup", con)

            Dim strFrom As String = String.Empty
            Dim strPass As String = String.Empty
            Dim intPort As Integer = 25
            Dim strHost As String = String.Empty

            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                strFrom = rdr("netUsername")
                strPass = rdr("netPassword")
                intPort = rdr("netPort")
                strHost = rdr("netHost")
            End While

            rdr.Close()

            con.Close()


            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()

            SmtpServer.Credentials = New  _
                    Net.NetworkCredential(strFrom, strPass)
            SmtpServer.Port = intPort
            SmtpServer.Host = strHost

            mail = New MailMessage()
            mail.From = New MailAddress(strFrom)
            mail.To.Add(recipient)
            mail.To.Add(strFrom)
            mail.Subject = "BPS Project Management System - " & subject
            mail.Body = body
          
            SmtpServer.Send(mail)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
