Imports System.Data.SqlClient


Public Class tbl_000_Supplier

#Region "Class Variables, Class Getters/Setters"

    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As String)
        FetchRecord(ID)
    End Sub

    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    Private _SupplierID As String
    Public Property SupplierID() As String
        Get
            Return _SupplierID
        End Get
        Set(ByVal value As String)
            _SupplierID = value
        End Set
    End Property

    Private _SupplierName As String
    Public Property SupplierName() As String
        Get
            Return _SupplierName
        End Get
        Set(ByVal value As String)
            _SupplierName = value
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

    Private _FaxNo As String
    Public Property FaxNo() As String
        Get
            Return _FaxNo
        End Get
        Set(ByVal value As String)
            _FaxNo = value
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

    Private _Website As String
    Public Property Website() As String
        Get
            Return _Website
        End Get
        Set(ByVal value As String)
            _Website = value
        End Set
    End Property

    Private _Accreditation As Date
    Public Property Accreditation() As Date
        Get
            Return _Accreditation
        End Get
        Set(ByVal value As Date)
            _Accreditation = value
        End Set
    End Property

    Private _SupplierType As String
    Public Property SupplierType() As String
        Get
            Return _SupplierType
        End Get
        Set(ByVal value As String)
            _SupplierType = value
        End Set
    End Property

    Private _ComCategory As String
    Public Property ComCategory() As String
        Get
            Return _ComCategory
        End Get
        Set(ByVal value As String)
            _ComCategory = value
        End Set
    End Property

    Private _PayTerms As String
    Public Property PayTerms() As String
        Get
            Return _PayTerms
        End Get
        Set(ByVal value As String)
            _PayTerms = value
        End Set
    End Property

    Private _CPName As String
    Public Property CPName() As String
        Get
            Return _CPName
        End Get
        Set(ByVal value As String)
            _CPName = value
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

    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

#End Region

#Region "User-defined Methods"

    Public Function Save(ByVal isEdit As Boolean) As Boolean

        Try

            Dim strMSG As String
            Using com As New SqlCommand("SaveSupplier", _Connection, _Transaction)
                com.CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMSG = "Update Supplier"
                Else
                    strMSG = "Add New Supplier"
                End If

                com.Parameters.Add(New SqlParameter("@supplierID", SupplierID))
                com.Parameters.Add(New SqlParameter("@supplierName", SupplierName))
                com.Parameters.Add(New SqlParameter("@address", Address))
                com.Parameters.Add(New SqlParameter("@telNo", TelNo))
                com.Parameters.Add(New SqlParameter("@faxNo", FaxNo))
                com.Parameters.Add(New SqlParameter("@cellNo", CellNo))
                com.Parameters.Add(New SqlParameter("@website", Website))
                com.Parameters.Add(New SqlParameter("@acrdDate", Accreditation))
                com.Parameters.Add(New SqlParameter("@supplierType", SupplierType))
                com.Parameters.Add(New SqlParameter("@comCategory", ComCategory))
                com.Parameters.Add(New SqlParameter("@payTerms", PayTerms))
                com.Parameters.Add(New SqlParameter("@cpName", CPName))
                com.Parameters.Add(New SqlParameter("@designation", Designation))
                com.Parameters.Add(New SqlParameter("@department", Department))
                com.Parameters.Add(New SqlParameter("@email", Email))
                com.Parameters.Add(New SqlParameter("@Remarks", Remarks))
                com.ExecuteNonQuery()

            End Using

            Call SaveAuditTrail(strMSG, SupplierID, True)

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Sub FetchRecord(ByVal strPK As String)
        Dim paramList As New ArrayList
        SQL = "SELECT * FROM tbl_000_Supplier WHERE SupplierID='" & strPK & "'"

        paramList = FetchData(paramList, SQL, CommandType.Text)
        If paramList Is Nothing Or paramList.Count = 0 Then
        Else
            _SupplierID = paramList(0).ToString
            _SupplierName = paramList(1).ToString
            _Address = paramList(2).ToString
            _TelNo = paramList(3).ToString
            _FaxNo = paramList(4).ToString
            _CellNo = paramList(5).ToString
            _Website = paramList(6).ToString
            _Accreditation = paramList(7).ToString
            _SupplierType = paramList(8).ToString
            _ComCategory = paramList(9).ToString
            _PayTerms = paramList(10).ToString
            _CPName = paramList(11).ToString
            _Designation = paramList(12).ToString
            _Department = paramList(13).ToString
            _Email = paramList(14).ToString
            _Remarks = paramList(15).ToString
        End If
    End Sub


    Public Shared Function GenerateID() As String
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand("SELECT MAX(convert(int,SupplierID)) as ID FROM tbl_000_Supplier ORDER BY ID", con)

        Try
            GenerateID = "0000001"
            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            If rdr.HasRows Then
                While rdr.Read
                    GenerateID = rdr("ID")
                End While
                GenerateID = Format(Long.Parse(GenerateID) + 1, "0000000")
            Else
                GenerateID = "0000001"
            End If


            rdr.Close()



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
            Return "ERROR"
        Finally


        End Try

    End Function

    

#End Region

End Class
