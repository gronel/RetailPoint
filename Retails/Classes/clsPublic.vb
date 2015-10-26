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
            If Row.Cells(intCol).Value.ToString() = strSearch Then
                dg.CurrentCell = dg.Item(dg.CurrentCell.ColumnIndex, Row.Index)
                Exit For
                intcount += 1
            End If
        Next Row
    End Sub

 

  
    ''2011.09.06
   


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