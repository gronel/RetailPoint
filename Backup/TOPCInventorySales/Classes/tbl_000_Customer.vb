Imports System.Data.SqlClient

Public Class tbl_000_Customer

    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As String)
        FetchRecord(ID)
    End Sub

    Private _CustomerCode As String
    Public Property CustomerCode() As String
        Get
            Return _CustomerCode
        End Get
        Set(ByVal value As String)
            _CustomerCode = value
        End Set
    End Property

    Private _CustomerName As String
    Public Property CustomerName() As String
        Get
            Return _CustomerName
        End Get
        Set(ByVal value As String)
            _CustomerName = value
        End Set
    End Property

    Private _Address As String
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property

    Private _TelNo As String
    Public Property TelNo() As String
        Get
            Return _TelNo
        End Get
        Set(ByVal value As String)
            _TelNo = value
        End Set
    End Property

    Private _Website As String
    Public Property Website() As String
        Get
            Return _Website
        End Get
        Set(ByVal value As String)
            _Website = value
        End Set
    End Property

    Private _ContactPerson As String
    Public Property ContactPerson() As String
        Get
            Return _ContactPerson
        End Get
        Set(ByVal value As String)
            _ContactPerson = value
        End Set
    End Property

    Private _Designation As String
    Public Property Designation() As String
        Get
            Return _Designation
        End Get
        Set(ByVal value As String)
            _Designation = value
        End Set
    End Property

    Private _Department As String
    Public Property Department() As String
        Get
            Return _Department
        End Get
        Set(ByVal value As String)
            _Department = value
        End Set
    End Property

    Private _CellNo As String
    Public Property CellNo() As String
        Get
            Return _CellNo
        End Get
        Set(ByVal value As String)
            _CellNo = value
        End Set
    End Property

    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Private _AccreditationDate As DateTime
    Public Property AccreditationDate() As DateTime
        Get
            Return _AccreditationDate
        End Get
        Set(ByVal value As DateTime)
            _AccreditationDate = value
        End Set
    End Property

    Private _PaymentTerms As String
    Public Property PaymentTerms() As String
        Get
            Return _PaymentTerms
        End Get
        Set(ByVal value As String)
            _PaymentTerms = value
        End Set
    End Property

    Private _isStatus As Boolean
    Public Property IsStatus() As Boolean
        Get
            Return _isStatus
        End Get
        Set(ByVal value As Boolean)
            _isStatus = value
        End Set
    End Property

    Private _fax As String
    Public Property Fax() As String
        Get
            Return _fax
        End Get
        Set(ByVal value As String)
            _fax = value
        End Set
    End Property

    Public Function Save(ByVal isEdit As Boolean) As Boolean
        Try
            Dim strMsg As String
            Using com As New SqlCommand("SaveCustomer", _Connection, _Transaction)
                com.CommandType = CommandType.StoredProcedure

                If isEdit = True Then
                    strMsg = "Update Customer"
                Else
                    strMsg = "Add New Customer"
                End If

                com.Parameters.Add(New SqlParameter("@CustomerCode", CustomerCode))
                com.Parameters.Add(New SqlParameter("@CustomerName", CustomerName))
                com.Parameters.Add(New SqlParameter("@Address", Address))
                com.Parameters.Add(New SqlParameter("@TelNo", TelNo))
                com.Parameters.Add(New SqlParameter("@Website", Website))
                com.Parameters.Add(New SqlParameter("@ContactPerson", ContactPerson))
                com.Parameters.Add(New SqlParameter("@Designation", Designation))
                com.Parameters.Add(New SqlParameter("@Department", Department))
                com.Parameters.Add(New SqlParameter("@CellNo", CellNo))
                com.Parameters.Add(New SqlParameter("@Email", Email))
                com.Parameters.Add(New SqlParameter("@AccreditationDate", AccreditationDate))
                com.Parameters.Add(New SqlParameter("@PaymentTerms", PaymentTerms))
                com.Parameters.Add(New SqlParameter("@IsStatus", IsStatus))
                com.Parameters.Add(New SqlParameter("@Fax", Fax))
                com.ExecuteNonQuery()
            End Using

            Call SaveAuditTrail(strMsg, _CustomerCode, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
            Return False
        End Try
    End Function


    Public Sub FetchRecord(ByVal strCode As String)
        Dim con As New SqlConnection(cnString)
        Dim com As New SqlCommand("Select * from tbl_000_Customer where CustomerCode= '" & strCode & "'", con)
        Dim myrdr As SqlDataReader

        Try
            con.Open()
            myrdr = com.ExecuteReader(CommandBehavior.CloseConnection)

            While myrdr.Read
                CustomerCode = myrdr("CustomerCode")
                CustomerName = myrdr("CustomerName")
                Address = myrdr("Address")
                Website = myrdr("Website")
                ContactPerson = myrdr("ContactPerson")
                Designation = myrdr("Designation")
                Email = myrdr("Email")
                Department = myrdr("Department")
                TelNo = myrdr("TelNo")
                CellNo = myrdr("CellNo")
                AccreditationDate = myrdr("AccreditationDate")
                PaymentTerms = myrdr("PaymentTerms")
                IsStatus = myrdr("Status")
                Fax = myrdr("Fax").ToString
            End While

            myrdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub

End Class
