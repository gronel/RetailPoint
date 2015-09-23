Imports System.Data.SqlClient

Public Class clsPublic

    Public Enum FormState
        AddState = 0
        EditState = 1
        ViewState = 2
        LoadState = 3
    End Enum

    Public Overloads Shared Sub SelectDataGridViewRow(ByVal dg As DataGridView)
        If dg.RowCount <> -1 Then
            If _intDeletedRow < dg.RowCount Then
                dg.CurrentCell = dg.Item(dg.CurrentCell.ColumnIndex, _intDeletedRow)
            ElseIf _intDeletedRow = dg.RowCount Then
                dg.CurrentCell = dg.Item(dg.CurrentCell.ColumnIndex, _intDeletedRow - 1)
            End If
        End If
    End Sub

    Public Overloads Shared Sub SelectDataGridViewRow(ByVal dg As DataGridView, ByVal intCol As Integer, ByVal strSearch As String)
        Dim intcount As Integer = 0

        For Each Row As DataGridViewRow In dg.Rows
            If Row.Cells(intCol).Value = strSearch Then
                dg.CurrentCell = dg.Item(dg.CurrentCell.ColumnIndex, Row.Index)
                Exit For
                intcount += 1
            End If
        Next Row
    End Sub

    Public Shared Sub LoadDepartmentToMultiCombo(ByVal cboMultiCombo As MTGCComboBox)
        Try
            Dim sqlConn As New SqlConnection(cnString)
            Dim sqlReader As SqlDataReader
            Dim sqlCommand As New SqlCommand("SELECT DepartmentCode, DepartmentName FROM tbl_000_Department WHERE DepartmentLevel = 1 ORDER BY DepartmentName", sqlConn)
            Dim dtLoading As New DataTable("tbl_100_Department")

            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With cboMultiCombo
                .ColumnNum = 2
                .ColumnWidth = "100;250"
                .GridLineHorizontal = True
                .GridLineVertical = True
                ''.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(1) {"DepartmentCode", "DepartmentName"}
                .SourceDataTable = dtLoading
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try

    End Sub

    Public Shared Sub LoadEmployeeToMultiCombo(ByVal cboMultiCombo As MTGCComboBox)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim sqlCommand As New SqlCommand("Get_Employee'" & "SelectEmpWithPhoto" & "','" & "" & "'", sqlConn)
        Dim dtLoading As New DataTable("tbl_000_Employee")

        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With cboMultiCombo
            .ColumnNum = 2
            .ColumnWidth = "100;250"
            .GridLineHorizontal = True
            .GridLineVertical = True
            ''.SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(1) {"EmpID", "EmpName"}
            .SourceDataTable = dtLoading
        End With

    End Sub
    Public Shared Sub LoadEmployeeToAccountability(ByVal cboMultiCombo As MTGCComboBox)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim sqlCommand As New SqlCommand("Get_Employee'" & "Select Acc" & "','" & "" & "'", sqlConn)
        Dim dtLoading As New DataTable("tbl_000_Employee")

        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With cboMultiCombo
            .ColumnNum = 2
            .ColumnWidth = "100;250"
            .GridLineHorizontal = True
            .GridLineVertical = True
            ''.SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(1) {"EmpID", "EmpName"}
            .SourceDataTable = dtLoading
        End With

    End Sub

    Public Shared Sub LoadSectionToMultiCombo(ByVal cboMultiCombo As MTGCComboBox, ByVal DepartmentParent As String)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim sqlCommand As New SqlCommand("SELECT DepartmentCode, DepartmentName FROM tbl_000_Department WHERE DepartmentLevel = 2 AND DepartmentParent = '" & DepartmentParent & "' ORDER BY DepartmentName", sqlConn)
        Dim dtLoading As New DataTable("tbl_100_Department")

        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With cboMultiCombo
            .ColumnNum = 2
            .ColumnWidth = "100;250"
            .GridLineHorizontal = True
            .GridLineVertical = True
            ''.SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(1) {"DepartmentCode", "DepartmentName"}
            .SourceDataTable = dtLoading
            .SelectedIndex = -1
        End With

    End Sub

    Public Shared Sub LoadLineToMultiCombo(ByVal cboMultiCombo As MTGCComboBox, ByVal DepartmentParent As String)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim sqlCommand As New SqlCommand("SELECT DepartmentCode, DepartmentName FROM tbl_000_Department WHERE DepartmentLevel = 3 AND DepartmentParent = '" & DepartmentParent & "' ORDER BY DepartmentName", sqlConn)
        Dim dtLoading As New DataTable("tbl_100_Department")

        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With cboMultiCombo
            .ColumnNum = 2
            .ColumnWidth = "100;250"
            .GridLineHorizontal = True
            .GridLineVertical = True
            ''.SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(1) {"DepartmentCode", "DepartmentName"}
            .SourceDataTable = dtLoading
        End With

    End Sub
    Public Shared Sub LoadItemComboBox_DataTable(ByVal cbo As MTGCComboBox)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim sqlCommand As New SqlCommand("GetItemCodes", sqlConn)
        Dim dtLoading As New DataTable("tbl_000_Item")

        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With cbo
            .ColumnNum = 4
            .ColumnWidth = "60;200;200;200"
            .GridLineHorizontal = True
            .GridLineVertical = True
            ''.SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(3) {"ItemCode", "ItemName", "Category", "SubCategory"}
            .SourceDataTable = dtLoading
        End With
    End Sub

    Public Shared Sub LoadSupplierToMultiCombo(ByVal cboMultiCombo As MTGCComboBox)
        Try
            Dim sqlConn As New SqlConnection(cnString)
            Dim sqlReader As SqlDataReader
            Dim sqlCommand As New SqlCommand("GetSupplierForCombo", sqlConn)
            Dim dtLoading As New DataTable("tbl_000_Supplier")

            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With cboMultiCombo
                .ColumnNum = 4
                .ColumnWidth = "100;250;200;100"
                .GridLineHorizontal = True
                .GridLineVertical = True
                ''.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(3) {"SupplierID", "SupplierName", "Address", "SupTypeName"}
                .SourceDataTable = dtLoading
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try


    End Sub
    Public Shared Sub LoadCurrencyType(ByVal cboMultiCombo As MTGCComboBox)
        Try
            Dim sqlConn As New SqlConnection(cnString)
            Dim sqlReader As SqlDataReader
            Dim sqlCommand As New SqlCommand("Select * from tbl_000_Currency", sqlConn)
            Dim dtLoading As New DataTable("tbl_000_Currency")

            sqlConn.Open()
            sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            dtLoading.Load(sqlReader)

            With cboMultiCombo
                .ColumnNum = 2
                .ColumnWidth = "80;100"
                .GridLineHorizontal = True
                .GridLineVertical = True
                ''.SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
                .SourceDataString = New String(1) {"Currency", "Description"}
                .SourceDataTable = dtLoading
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try

    End Sub

    Public Shared Sub LoadCustomerToMultiCombo(ByVal cboMultiCombo As MTGCComboBox)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim dtLoading As New DataTable("tbl_000_Customer")
        Dim sqlCommand As New SqlCommand("SELECT     CustomerCode, CustomerName, Address " & _
                                         "FROM tbl_000_Customer WHERE(Status = 1) " & _
                                         "ORDER BY CustomerName", sqlConn)


        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With cboMultiCombo
            .ColumnNum = 3
            .ColumnWidth = "100;200;200"
            .GridLineHorizontal = True
            .GridLineVertical = True
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(2) {"CustomerCode", "CustomerName", "Address"}
            .SourceDataTable = dtLoading
        End With
    End Sub
    ''2011.09.06
    Public Shared Sub LoadORTypeToMultiCombo(ByVal cboMultiCombo As MTGCComboBox)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim dtLoading As New DataTable("tbl_OrderType")
        Dim sqlCommand As New SqlCommand("SELECT OrderTypeCode,OrderType " & _
                                         " FROM tbl_OrderType ORDER BY OrderTypeCode", sqlConn)

        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With cboMultiCombo
            .ColumnNum = 2
            .ColumnWidth = "100;200"
            .GridLineHorizontal = True
            .GridLineVertical = True
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(1) {"OrderTypeCode", "OrderType"}
            .SourceDataTable = dtLoading
        End With
    End Sub
    Public Shared Sub LoadEmp(ByVal cboMultiCombo As MTGCComboBox)
        Dim sqlConn As New SqlConnection(cnString)
        Dim sqlReader As SqlDataReader
        Dim sqlCommand As New SqlCommand("Get_Employee'" & "SelectEmp" & "','" & "" & "'", sqlConn)
        Dim dtLoading As New DataTable("tbl_000_Employee")

        sqlConn.Open()
        sqlReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
        dtLoading.Load(sqlReader)

        With cboMultiCombo
            .ColumnNum = 2
            .ColumnWidth = "180;90"
            .GridLineHorizontal = True
            .GridLineVertical = True
            ''.SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
            .SourceDataString = New String(1) {"EmpName", "EmpID"}
            .SourceDataTable = dtLoading
        End With

    End Sub



End Class
Public Class strArrays
    Implements IDisposable

#Region "strArrays variables"
    Private strFirstColumn As String
    Private strSecondColumn As String
    Private strThirdColumn As String
    Private strFourthColumn As String
    Private strFifthColumn As String
    Private strSixthColumn As String
    Private dtSqlDbTypes As SqlDbType
    Private arrArrayList1 As ArrayList
    Private arrArrayList2 As ArrayList
#End Region

#Region "strArrays setters/Getters"
    Public Property SqlDbTypes() As SqlDbType
        Get
            Return dtSqlDbTypes
        End Get
        Set(ByVal value As SqlDbType)
            dtSqlDbTypes = value
        End Set
    End Property

    Public Property firstColumn() As String
        Get
            Return strFirstColumn
        End Get
        Set(ByVal value As String)
            strFirstColumn = value
        End Set
    End Property

    Public Property secondColumn() As String
        Get
            Return strSecondColumn
        End Get
        Set(ByVal value As String)
            strSecondColumn = value
        End Set
    End Property

    Public Property thirdColumn() As String
        Get
            Return strThirdColumn
        End Get
        Set(ByVal value As String)
            strThirdColumn = value
        End Set
    End Property

    Public Property fourthColumn() As String
        Get
            Return strFourthColumn
        End Get
        Set(ByVal value As String)
            strFourthColumn = value
        End Set
    End Property

    Public Property fifthColumn() As String
        Get
            Return strFifthColumn
        End Get
        Set(ByVal value As String)
            strFifthColumn = value
        End Set
    End Property

    Public Property sixthColumn() As String
        Get
            Return strSixthColumn
        End Get
        Set(ByVal value As String)
            strSixthColumn = value
        End Set
    End Property

    Public Property ArrayList1() As ArrayList
        Get
            Return arrArrayList1
        End Get
        Set(ByVal value As ArrayList)
            arrArrayList1 = value
        End Set
    End Property

    Public Property ArrayList2() As ArrayList
        Get
            Return arrArrayList2
        End Get
        Set(ByVal value As ArrayList)
            arrArrayList2 = value
        End Set
    End Property
#End Region

#Region "Constructors"
    Public Sub New()

    End Sub

    Public Sub New(ByVal strFirst As String)
        strFirstColumn = strFirst
    End Sub

    Public Sub New(ByVal strFirst As String, ByVal strSecond As String)
        strFirstColumn = strFirst
        strSecondColumn = strSecond
    End Sub

    Public Sub New(ByVal arrList1 As ArrayList, ByVal arrList2 As ArrayList)
        arrArrayList1 = arrList1
        arrArrayList2 = arrList2
    End Sub

    Public Sub New(ByVal strFirst As String, ByVal arrList1 As ArrayList)
        strFirstColumn = strFirst
        arrArrayList1 = arrList1
    End Sub

    Public Sub New(ByRef srcSQLDataType As SqlDbType, ByVal strFirst As String)
        dtSqlDbTypes = srcSQLDataType
        strFirstColumn = strFirst
    End Sub

    Public Sub New(ByVal strFirst As String, ByVal strSecond As String, ByVal strThird As String)
        strFirstColumn = strFirst
        strSecondColumn = strSecond
        strThirdColumn = strThird
    End Sub

    Public Sub New(ByVal strFirst As String, ByVal strSecond As String, ByVal strThird As String, ByVal strFourth As String)
        strFirstColumn = strFirst
        strSecondColumn = strSecond
        strThirdColumn = strThird
        strFourthColumn = strFourth
    End Sub

    Public Sub New(ByVal strFirst As String, ByVal strSecond As String, ByVal strThird As String, ByVal strFourth As String, _
                   ByVal strFifth As String)
        strFirstColumn = strFirst
        strSecondColumn = strSecond
        strThirdColumn = strThird
        strFourthColumn = strFourth
        strFifthColumn = strFifth
    End Sub

    Public Sub New(ByVal strFirst As String, ByVal strSecond As String, ByVal strThird As String, ByVal strFourth As String, _
                   ByVal strFifth As String, ByVal strSixth As String)
        strFirstColumn = strFirst
        strSecondColumn = strSecond
        strThirdColumn = strThird
        strFourthColumn = strFourth
        strFifthColumn = strFifth
        strSixthColumn = strSixth
    End Sub

    Public Sub New(ByVal srcSQLDataType As SqlDbType, ByVal strFirst As String, ByVal strSecond As String)
        dtSqlDbTypes = srcSQLDataType
        strFirstColumn = strFirst
        strSecondColumn = strSecond
    End Sub

    Public Sub New(ByVal srcSQLDataType As SqlDbType, ByVal strFirst As String, ByVal strSecond As String, ByVal strThird As String)
        dtSqlDbTypes = srcSQLDataType
        strFirstColumn = strFirst
        strSecondColumn = strSecond
        strThirdColumn = strThird
    End Sub

    Public Sub New(ByVal srcSQLDataType As SqlDbType, ByVal strFirst As String, ByVal strSecond As String, ByVal strThird As String, ByVal strFourth As String)
        dtSqlDbTypes = srcSQLDataType
        strFirstColumn = strFirst
        strSecondColumn = strSecond
        strThirdColumn = strThird
        strFourthColumn = strFourth
    End Sub

#Region "IDisposable"
    ''' <summary>
    ''' To clean up the object after it is used.
    ''' </summary>
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#End Region
#End Region
End Class