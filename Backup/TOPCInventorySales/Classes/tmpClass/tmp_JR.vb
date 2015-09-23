Imports System.Data.SqlClient
Public Class tmp_JR
#Region "Variables"

    Private _JRNo As String
    Private _DepartmentCode As String
    Private _SectionCode As String
    Private _LineCode As String
    Private _SupplierID As String
    Private _SupplierType As String
    Private _DateRequested As String
    Private _DateNeeded As String
    Private _JORRSchedule As String
    Private _JRType As String
    Private _PreparedBy As String
    Private _RequestBy As String
    Private _CheckedBy As String
    Private _ApprovedBy As String
    Private _TotalAmount As Double
    Private _Remarks As String
    Private _Total As Double
    Private _CurrencyType As String
#End Region

#Region "Setters/Getters"
    Public Sub New()
    End Sub
    Public Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
        End Set
    End Property
    Public Property CurrencyType() As String
        Get
            Return _CurrencyType
        End Get
        Set(ByVal value As String)
            _CurrencyType = value
        End Set
    End Property
    Public Property JRNo() As String
        Get
            Return _JRNo
        End Get
        Set(ByVal value As String)
            _JRNo = value
        End Set
    End Property

    Public Property DepartmentCode() As String
        Get
            Return _DepartmentCode
        End Get
        Set(ByVal value As String)
            _DepartmentCode = value
        End Set
    End Property

    Public Property SectionCode() As String
        Get
            Return _SectionCode
        End Get
        Set(ByVal value As String)
            _SectionCode = value
        End Set
    End Property

    Public Property LineCode() As String
        Get
            Return _LineCode
        End Get
        Set(ByVal value As String)
            _LineCode = value
        End Set
    End Property

    Public Property SupplierID() As String
        Get
            Return _SupplierID
        End Get
        Set(ByVal value As String)
            _SupplierID = value
        End Set
    End Property

    Public Property SupplierType() As String
        Get
            Return _SupplierType
        End Get
        Set(ByVal value As String)
            _SupplierType = value
        End Set
    End Property

    Public Property DateRequested() As String
        Get
            Return _DateRequested
        End Get
        Set(ByVal value As String)
            _DateRequested = value
        End Set
    End Property

    Public Property DateNeeded() As String
        Get
            Return _DateNeeded
        End Get
        Set(ByVal value As String)
            _DateNeeded = value
        End Set
    End Property

    Public Property JORRSchedule() As String
        Get
            Return _JORRSchedule
        End Get
        Set(ByVal value As String)
            _JORRSchedule = value
        End Set
    End Property

    Public Property JRType() As String
        Get
            Return _JRType
        End Get
        Set(ByVal value As String)
            _JRType = value
        End Set
    End Property

    Public Property PreparedBy() As String
        Get
            Return _PreparedBy
        End Get
        Set(ByVal value As String)
            _PreparedBy = value
        End Set
    End Property

    Public Property RequestBy() As String
        Get
            Return _RequestBy
        End Get
        Set(ByVal value As String)
            _RequestBy = value
        End Set
    End Property

    Public Property CheckedBy() As String
        Get
            Return _CheckedBy
        End Get
        Set(ByVal value As String)
            _CheckedBy = value
        End Set
    End Property

    Public Property ApprovedBy() As String
        Get
            Return _ApprovedBy
        End Get
        Set(ByVal value As String)
            _ApprovedBy = value
        End Set
    End Property

    Public Property TotalAmount() As Double
        Get
            Return _TotalAmount
        End Get
        Set(ByVal value As Double)
            _TotalAmount = value
        End Set
    End Property

    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Private _Dec As String
    Public Property Dec() As Integer
        Get
            Return _Dec
        End Get
        Set(ByVal value As Integer)
            _Dec = value
        End Set
    End Property
#End Region

#Region "User define methods"
    Public Function Save(ByVal dgSub As DataGridView) As Boolean
        Try
            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            Dim com As SqlCommand
            com = New SqlCommand("Save_tmp_JR", _Connection)
            With com
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@JRNo", JRNo))
                .Parameters.Add(New SqlParameter("@DepartmentCode", DepartmentCode))
                .Parameters.Add(New SqlParameter("@SectionCode", SectionCode))
                .Parameters.Add(New SqlParameter("@LineCode", LineCode))
                .Parameters.Add(New SqlParameter("@SupplierID", SupplierID))
                .Parameters.Add(New SqlParameter("@SupplierType", SupplierType))
                .Parameters.Add(New SqlParameter("@DateRequested", DateRequested))
                .Parameters.Add(New SqlParameter("@DateNeeded", DateNeeded))
                .Parameters.Add(New SqlParameter("@JORRSchedule", JORRSchedule))
                .Parameters.Add(New SqlParameter("@JRType", JRType))
                .Parameters.Add(New SqlParameter("@PreparedBy", PreparedBy))
                .Parameters.Add(New SqlParameter("@RequestedBy", RequestBy))
                .Parameters.Add(New SqlParameter("@CheckedBy", CheckedBy))
                .Parameters.Add(New SqlParameter("@ApprovedBy", ApprovedBy))
                .Parameters.Add(New SqlParameter("@TotalAmount", TotalAmount))
                .Parameters.Add(New SqlParameter("@Remarks", Remarks))
                .Parameters.Add(New SqlParameter("@CurrencyType", CurrencyType))
                .Parameters.Add(New SqlParameter("@isStatus", isPlaced))
                .Parameters.Add(New SqlParameter("@isReason", isNull))
                .Parameters.Add(New SqlParameter("@Dec", Dec))
                .ExecuteNonQuery()
            End With


            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)

            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com1 As New SqlCommand("Save_tmp_JR_Sub", _Connection, _Transaction)
                        com1.CommandType = CommandType.StoredProcedure
                        com1.Parameters.Add(New SqlParameter("@JRNo", JRNo))
                        com1.Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                        com1.Parameters.Add(New SqlParameter("@ItemCode", row.Cells("colItemCode").Value))
                        com1.Parameters.Add(New SqlParameter("@KindOfService", row.Cells("colService").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                        com1.Parameters.Add(New SqlParameter("@ReqQty", CDbl(row.Cells("colReqQty").Value)))
                        com1.Parameters.Add(New SqlParameter("@ActualUnitPrice", CDbl(row.Cells("colActualPrice").Value)))
                        com1.Parameters.Add(New SqlParameter("@Amount", CDbl(row.Cells("colAmount").Value)))

                        com1.ExecuteNonQuery()
                    End Using
                End If
            Next




            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

#End Region
End Class
