Imports System.Data.SqlClient

Public Class tbl_100_Issue

    Public Sub New()
    End Sub

    Private _IssueID As Integer
    Public Property IssueID() As Integer
        Get
            Return _IssueID
        End Get
        Set(ByVal value As Integer)
            _IssueID = value
        End Set
    End Property

    Private _ProjectID As Integer
    Public Property ProjectID() As Integer
        Get
            Return _ProjectID
        End Get
        Set(ByVal value As Integer)
            _ProjectID = value
        End Set
    End Property

    Private _Tracker As String
    Public Property Tracker() As String
        Get
            Return _Tracker
        End Get
        Set(ByVal value As String)
            _Tracker = value
        End Set
    End Property

    Private _Subject As String
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property

    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Private _Status As String
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    Private _Priority As String
    Public Property Priority() As String
        Get
            Return _Priority
        End Get
        Set(ByVal value As String)
            _Priority = value
        End Set
    End Property

    Private _Assignee As String
    Public Property Assignee() As String
        Get
            Return _Assignee
        End Get
        Set(ByVal value As String)
            _Assignee = value
        End Set
    End Property

    Private _RequestedBy As String
    Public Property RequestedBy() As String
        Get
            Return _RequestedBy
        End Get
        Set(ByVal value As String)
            _RequestedBy = value
        End Set
    End Property

    Private _AcceptedBy As String
    Public Property AcceptedBy() As String
        Get
            Return _AcceptedBy
        End Get
        Set(ByVal value As String)
            _AcceptedBy = value
        End Set
    End Property

    Private _Startdate As Date
    Public Property Startdate() As String
        Get
            Return _Startdate
        End Get
        Set(ByVal value As String)
            _Startdate = value
        End Set
    End Property

    Private _Duedate As Date
    Public Property Duedate() As String
        Get
            Return _Duedate
        End Get
        Set(ByVal value As String)
            _Duedate = value
        End Set
    End Property

    Private _PercentDone As String
    Public Property PercentDone() As String
        Get
            Return _PercentDone
        End Get
        Set(ByVal value As String)
            _PercentDone = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean) As Boolean

        Try
            Dim strMSG As String

            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            Using com As New SqlCommand("SaveIssue", _Connection)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMSG = "Updated"
                Else
                    strMSG = "Saved"
                End If

                com.Parameters.Add(New SqlParameter("@IssueID", IssueID))
                com.Parameters.Add(New SqlParameter("@ProjectID", ProjectID))
                com.Parameters.Add(New SqlParameter("@IssueTracker", Tracker))
                com.Parameters.Add(New SqlParameter("@IssueStatus", Status))
                com.Parameters.Add(New SqlParameter("@IssueSubject", Subject))
                com.Parameters.Add(New SqlParameter("@IssueDescription", Description))
                com.Parameters.Add(New SqlParameter("@IssuePriority", Priority))
                com.Parameters.Add(New SqlParameter("@Assignee", Assignee))
                com.Parameters.Add(New SqlParameter("@Requestedby", RequestedBy))
                com.Parameters.Add(New SqlParameter("@Acceptedby", AcceptedBy))
                com.Parameters.Add(New SqlParameter("@Startdate", Startdate))
                com.Parameters.Add(New SqlParameter("@Duedate", Duedate))
                com.Parameters.Add(New SqlParameter("@Percentdone", PercentDone))


                com.ExecuteNonQuery()

            End Using

            ''Call SaveAuditTrail(strMSG, _UserID, True)

            Return True

        Catch ex As Exception
            Return False
        Finally
            _Connection.Close()
        End Try

    End Function


    Public Sub GetRecord(ByVal ID As Integer)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("GetIssue " & ID & "", con)

        con.Open()
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While rdr.Read
            IssueID = rdr("IssueID")
            ProjectID = rdr("ProjectID")
            Tracker = rdr("IssueTracker")
            Status = rdr("IssueStatus")
            Subject = rdr("IssueSubject")
            Description = rdr("IssueDescription")
            Priority = rdr("IssuePriority")
            Assignee = rdr("Assignee")
            RequestedBy = rdr("Requestedby")
            AcceptedBy = rdr("Acceptedby")
            Startdate = rdr("Startdate")
            Duedate = rdr("Duedate")
            PercentDone = rdr("Percentdone")
        End While

        rdr.Close()



    End Sub


End Class
