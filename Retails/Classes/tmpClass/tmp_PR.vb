Imports System.Data.SqlClient
Public Class tmp_PR
#Region " Private variables "

    Private _PRNo As String
    Private _DepartmentCode As String
    Private _SectionCode As String
    Private _LineCode As String
    Private _SupplierID As String
    Private _SupplierType As String
    Private _DateRequested As Date
    Private _DateNeeded As String
    Private _PORRSchedule As String
    Private _PRType As String
    Private _PreparedBy As String
    Private _RequestedBy As String
    Private _CheckedBy As String
    Private _ApprovedBy As String
    Private _TotalAmount As Double
    Private _Remarks As String
    Private _CurrencyType As String
    Private _isStatus As String
    Private _isReason As String
    Private _Dec As Integer
    Private _isLock As Boolean

#End Region

#Region " Properties "

    Public Property PRNo() As String
        Get
            Return _PRNo
        End Get
        Set(ByVal Value As String)
            _PRNo = Value
        End Set
    End Property

    Public Property DepartmentCode() As String
        Get
            Return _DepartmentCode
        End Get
        Set(ByVal Value As String)
            _DepartmentCode = Value
        End Set
    End Property

    Public Property SectionCode() As String
        Get
            Return _SectionCode
        End Get
        Set(ByVal Value As String)
            _SectionCode = Value
        End Set
    End Property

    Public Property LineCode() As String
        Get
            Return _LineCode
        End Get
        Set(ByVal Value As String)
            _LineCode = Value
        End Set
    End Property

    Public Property SupplierID() As String
        Get
            Return _SupplierID
        End Get
        Set(ByVal Value As String)
            _SupplierID = Value
        End Set
    End Property

    Public Property SupplierType() As String
        Get
            Return _SupplierType
        End Get
        Set(ByVal Value As String)
            _SupplierType = Value
        End Set
    End Property

    Public Property DateRequested() As Date
        Get
            Return _DateRequested
        End Get
        Set(ByVal Value As Date)
            _DateRequested = Value
        End Set
    End Property

    Public Property DateNeeded() As String
        Get
            Return _DateNeeded
        End Get
        Set(ByVal Value As String)
            _DateNeeded = Value
        End Set
    End Property

    Public Property PORRSchedule() As String
        Get
            Return _PORRSchedule
        End Get
        Set(ByVal Value As String)
            _PORRSchedule = Value
        End Set
    End Property

    Public Property PRType() As String
        Get
            Return _PRType
        End Get
        Set(ByVal Value As String)
            _PRType = Value
        End Set
    End Property

    Public Property PreparedBy() As String
        Get
            Return _PreparedBy
        End Get
        Set(ByVal Value As String)
            _PreparedBy = Value
        End Set
    End Property

    Public Property RequestedBy() As String
        Get
            Return _RequestedBy
        End Get
        Set(ByVal Value As String)
            _RequestedBy = Value
        End Set
    End Property

    Public Property CheckedBy() As String
        Get
            Return _CheckedBy
        End Get
        Set(ByVal Value As String)
            _CheckedBy = Value
        End Set
    End Property

    Public Property ApprovedBy() As String
        Get
            Return _ApprovedBy
        End Get
        Set(ByVal Value As String)
            _ApprovedBy = Value
        End Set
    End Property

    Public Property TotalAmount() As Double
        Get
            Return _TotalAmount
        End Get
        Set(ByVal Value As Double)
            _TotalAmount = Value
        End Set
    End Property

    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal Value As String)
            _Remarks = Value
        End Set
    End Property

    Public Property CurrencyType() As String
        Get
            Return _CurrencyType
        End Get
        Set(ByVal Value As String)
            _CurrencyType = Value
        End Set
    End Property

    Public Property isStatus() As String
        Get
            Return _isStatus
        End Get
        Set(ByVal Value As String)
            _isStatus = Value
        End Set
    End Property

    Public Property isReason() As String
        Get
            Return _isReason
        End Get
        Set(ByVal Value As String)
            _isReason = Value
        End Set
    End Property

    Public Property Dec() As Integer
        Get
            Return _Dec
        End Get
        Set(ByVal Value As Integer)
            _Dec = Value
        End Set
    End Property

    Public Property isLock() As Boolean
        Get
            Return _isLock
        End Get
        Set(ByVal Value As Boolean)
            _isLock = Value
        End Set
    End Property


#End Region

#Region " Methods "

    Public Function Save(ByVal dgsub As DataGridView) As Boolean

        Try

            _Connection = New SqlConnection(cnString)
            If _Connection.State = ConnectionState.Closed Then _Connection.Open()

            RunQuery("Delete from tmp_PR")
            RunQuery("Delete from tmp_PR_Sub")


            Using com As New SqlCommand("Save_tmp_PR", _Connection)
                com.CommandType = CommandType.StoredProcedure
                com.Parameters.Add(New SqlParameter("@PRNo", PRNo))
                com.Parameters.Add(New SqlParameter("@DepartmentCode", DepartmentCode))
                com.Parameters.Add(New SqlParameter("@SectionCode", SectionCode))
                com.Parameters.Add(New SqlParameter("@LineCode", LineCode))
                com.Parameters.Add(New SqlParameter("@SupplierID", SupplierID))
                com.Parameters.Add(New SqlParameter("@SupplierType", SupplierType))
                com.Parameters.Add(New SqlParameter("@DateRequested", DateRequested))
                com.Parameters.Add(New SqlParameter("@DateNeeded", DateNeeded))
                com.Parameters.Add(New SqlParameter("@PORRSchedule", PORRSchedule))
                com.Parameters.Add(New SqlParameter("@PRType", PRType))
                com.Parameters.Add(New SqlParameter("@PreparedBy", PreparedBy))
                com.Parameters.Add(New SqlParameter("@RequestedBy", RequestedBy))
                com.Parameters.Add(New SqlParameter("@CheckedBy", CheckedBy))
                com.Parameters.Add(New SqlParameter("@ApprovedBy", ApprovedBy))
                com.Parameters.Add(New SqlParameter("@TotalAmount", TotalAmount))
                com.Parameters.Add(New SqlParameter("@Remarks", Remarks))
                com.Parameters.Add(New SqlParameter("@CurrencyType", CurrencyType))
                'com.Parameters.Add(New SqlParameter("@isStatus", isStatus))
                'com.Parameters.Add(New SqlParameter("@isReason", isReason))
                com.Parameters.Add(New SqlParameter("@Dec", Dec))
                com.Parameters.Add(New SqlParameter("@isLock", isLock))
                com.ExecuteNonQuery()

            End Using

            For Each row As DataGridViewRow In dgsub.Rows
                If row.IsNewRow = False Then
                    Using com1 As New SqlCommand("Save_tmp_PR_Sub", _Connection, _Transaction)
                        com1.CommandType = CommandType.StoredProcedure
                        com1.Parameters.Add(New SqlParameter("@PRNo", PRNo))
                        com1.Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                        com1.Parameters.Add(New SqlParameter("@ItemCode", row.Cells("colItemCode").Value))
                        com1.Parameters.Add(New SqlParameter("@PurposeUse", row.Cells("colPurpose").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                        com1.Parameters.Add(New SqlParameter("@ReqQty", CDbl(row.Cells("colReqQty").Value)))
                        com1.Parameters.Add(New SqlParameter("@ActualUnitPrice", CDbl(row.Cells("colActualPrice").Value)))
                        com1.Parameters.Add(New SqlParameter("@Amount", CDbl(row.Cells("colAmount").Value)))
                        com1.Parameters.Add(New SqlParameter("@DateLastPurchased", row.Cells("colLastPurchased").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                        com1.Parameters.Add(New SqlParameter("@Status", isPending))
                        com1.Parameters.Add(New SqlParameter("@RRQTy", CDbl(row.Cells("colReqQty").Value)))
                        com1.ExecuteNonQuery()
                    End Using
                End If
            Next


            Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Prompt")
            Return False
        Finally
            _Connection.Close()
        End Try

    End Function

#End Region
End Class
