Imports System.Data.SqlClient

Public Class tbl_100_PR
#Region "Variables"
    Public strSQL As String
    Public myConn As SqlConnection = New SqlConnection(cnString)
    Public da As SqlDataAdapter = New SqlDataAdapter(strSQL, myConn)
    Public ds As New DataSet("ds")
    Public bind As New BindingSource
    Public view As New DataView


    Private _PRNo As String
    Private _DepartmentCode As String
    Private _SectionCode As String
    Private _LineCode As String
    Private _SupplierID As String
    Private _SupplierType As String
    Private _DateRequested As String
    Private _DateNeeded As String
    Private _PORRSchedule As String
    Private _PRType As String
    Private _PreparedBy As String
    Private _RequestBy As String
    Private _CheckedBy As String
    Private _ApprovedBy As String
    Private _TotalAmount As Double
    Private _Remarks As String

    Private _CurrencyType As String

#End Region

#Region "Setters/Getters"
    Public Sub New()
    End Sub

    Public Property CurrencyType() As String
        Get
            Return _CurrencyType
        End Get
        Set(ByVal value As String)
            _CurrencyType = value
        End Set
    End Property

    Public Property PRNo() As String
        Get
            Return _PRNo
        End Get
        Set(ByVal value As String)
            _PRNo = value
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

    Public Property PORRSchedule() As String
        Get
            Return _PORRSchedule
        End Get
        Set(ByVal value As String)
            _PORRSchedule = value
        End Set
    End Property

    Public Property PRType() As String
        Get
            Return _PRType
        End Get
        Set(ByVal value As String)
            _PRType = value
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
    Private _dec As String
    Public Property Dec() As Integer
        Get
            Return _dec
        End Get
        Set(ByVal value As Integer)
            _dec = value
        End Set
    End Property
#End Region

#Region "User define methods"
    Public Function Save(ByVal isEdit As Boolean, ByVal dgSub As DataGridView) As Boolean


        Try
            Dim strMsg As String
            Dim com As SqlCommand
            com = New SqlCommand("SavePR", _Connection, _Transaction)
            With com
                .CommandType = CommandType.StoredProcedure

                If isEdit Then
                    strMsg = "Update PR"
                Else
                    strMsg = "Add New PR"
                End If

                .Parameters.Add(New SqlParameter("@PRNo", PRNo))
                .Parameters.Add(New SqlParameter("@DepartmentCode", DepartmentCode))
                .Parameters.Add(New SqlParameter("@SectionCode", SectionCode))
                .Parameters.Add(New SqlParameter("@LineCode", LineCode))
                .Parameters.Add(New SqlParameter("@SupplierID", SupplierID))
                .Parameters.Add(New SqlParameter("@SupplierType", SupplierType))
                .Parameters.Add(New SqlParameter("@DateRequested", DateRequested))
                .Parameters.Add(New SqlParameter("@DateNeeded", DateNeeded))
                .Parameters.Add(New SqlParameter("@PORRSchedule", PORRSchedule))
                .Parameters.Add(New SqlParameter("@PRType", PRType))
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
                .Parameters.Add(New SqlParameter("@islock", False))
                .ExecuteNonQuery()
            End With

            Using com1 As New SqlCommand("DELETE FROM tbl_100_PR_Sub WHERE PRNo = '" & PRNo & "'", _Connection, _Transaction)
                com1.CommandType = CommandType.Text
                com1.ExecuteNonQuery()
            End Using



            dgSub.CommitEdit(DataGridViewDataErrorContexts.Commit)



            For Each row As DataGridViewRow In dgSub.Rows
                If row.IsNewRow = False Then
                    Using com1 As New SqlCommand("SavePR_Sub", _Connection, _Transaction)
                        com1.CommandType = CommandType.StoredProcedure
                        com1.Parameters.Add(New SqlParameter("@PRNo", PRNo))
                        com1.Parameters.Add(New SqlParameter("@SpecificCode", row.Cells("colSpecificCode").Value))
                        com1.Parameters.Add(New SqlParameter("@ItemCode", row.Cells("colItemCode").Value))
                        com1.Parameters.Add(New SqlParameter("@PurposeUse", row.Cells("colPurpose").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                        com1.Parameters.Add(New SqlParameter("@QtyDec", CInt(row.Cells("colDecQTY").Value)))
                        com1.Parameters.Add(New SqlParameter("@ReqQty", CDbl(row.Cells("colReqQty").Value)))
                        com1.Parameters.Add(New SqlParameter("@ActualUnitPrice", CDbl(row.Cells("colActualPrice").Value)))
                        com1.Parameters.Add(New SqlParameter("@Amount", CDbl(row.Cells("colAmount").Value)))
                        com1.Parameters.Add(New SqlParameter("@DateLastPurchased", row.Cells("colLastPurchased").GetEditedFormattedValue(row.Index, DataGridViewDataErrorContexts.Commit)))
                        com1.Parameters.Add(New SqlParameter("@Status", isPending))
                        com1.Parameters.Add(New SqlParameter("@RRQTy", CDbl(row.Cells("colReqQty").Value)))
                        com1.ExecuteNonQuery()


                        RunQuery("Update tbl_100_PO_Sub  set ReqQty='" & CDbl(row.Cells("colReqQty").Value) & "',ActualUnitPrice='" & CDbl(row.Cells("colActualPrice").Value) & "',Amount='" & CDbl(row.Cells("colAmount").Value) & "' where Prno='" & PRNo & "' and SpecificCode='" & row.Cells("colSpecificCode").Value & "'")
                    End Using
                End If
            Next



            Call SaveAuditTrail(strMsg, PRNo, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR PR")
            Return False
        End Try

    End Function

    Public Sub FetchPR(ByVal PK As String)
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim com As New SqlCommand("SELECT     PRNo, DepartmentCode, SectionCode, LineCode, SupplierID, SupplierType, DateRequested, DateNeeded, PORRSchedule, PRType, PreparedBy, " & _
                                "RequestedBy, CheckedBy, ApprovedBy, TotalAmount, Remarks, CurrencyType, Dec " & _
                                "FROM tbl_100_PR WHERE     (PRNo = '" & PK & "')", con)

        Try
            con.Open()
            rdr = com.ExecuteReader(CommandBehavior.CloseConnection)

            While rdr.Read
                _PRNo = rdr("PRNo")
                _DepartmentCode = rdr("DepartmentCode")
                _SectionCode = rdr("SectionCode")
                _LineCode = rdr("LineCode")
                _SupplierID = rdr("SupplierID")
                _SupplierType = rdr("SupplierType")
                _DateRequested = rdr("DateRequested")
                _DateNeeded = rdr("DateNeeded")
                _PORRSchedule = rdr("PORRSchedule")
                _PRType = rdr("PRType")
                _PreparedBy = rdr("PreparedBy")
                _RequestBy = rdr("RequestedBy")
                _CheckedBy = rdr("CheckedBy")
                _ApprovedBy = rdr("ApprovedBy")
                _TotalAmount = rdr("TotalAmount")
                _Remarks = rdr("Remarks")
                _CurrencyType = rdr("CurrencyType")
                _dec = rdr("Dec")
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub
#End Region


    Public Overloads Sub Fetch(ByVal srcList As DataGridView)
        Try

            strSQL = "GetPRList'" & "list" & "','" & isPlaced & "','" & "" & "'"
            da = New SqlDataAdapter(strSQL, myConn)
            ds.Clear()
            da.Fill(ds, "tbl_100_PR")
            view = New DataView(ds.Tables(0))
            bind.DataSource = view
            bind.RemoveFilter()
            'srcList.DataSource = bind
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Refresh Error")
        End Try

    End Sub

End Class
