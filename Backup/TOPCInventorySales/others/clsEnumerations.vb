Public Class clsEnumerations
    ''' <summary>
    ''' Logged-in user information.
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure UserInfo
        Dim UserID As String
        Dim UserName As String
        Dim UserPassword As String
        Dim UserIsAdmin As Integer
        Dim UserAllowConfi As Integer
        Dim UserLocation As String
        Dim UserCompany As String
    End Structure

    ''' <summary>
    ''' The current state of the form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum FormState
        adStateAddMode = 0
        adStateEditMode = 1
        adStateViewMode = 2
        adStateDeleteMode = 3
        adStateUploadMode = 4
    End Enum

    ''' <summary>
    ''' The company information.
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure CompanyInfo
        Dim CompanyTradeName As String
        Dim CompanyAddress As String
        Dim CompanyTelephone As String
        Dim CompanyFax As String
        Dim CompanyTIN As String
        Dim UploadLocation As String
        Dim CompanyPictureLocation As String
    End Structure

    ''' <summary>
    ''' Enumerates the days of the week.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum myDays
        Sunday = 1
        Monday = 2
        Tuesday = 3
        Wednesday = 4
        Thursdday = 5
        Friday = 6
        Saturday = 7
    End Enum

    ''' <summary>
    ''' Enumerates how the number of holidays will be counted.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum CountNumberOfHolidaysBy
        byYear = 0
        byPaySchedule = 1
    End Enum

    ''' <summary>
    ''' Enumerates the format type.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum FormatType
        PercentFormat = 0
        DecimalFormat = 1
        MoneyFormat = 2
        RemoveCommaSeparateFormat = 3
        RemoveApostrophe = 4
        RemoveNumbers = 5
        RemoveSpecialCharacters = 6
        BooleanToInteger = 7
    End Enum

    ''' <summary>
    ''' Enumerates the report mode.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ReportMode
        rptWindowMode = 0
        rptPrintMode = 1
    End Enum

    ''' <summary>
    ''' Enumerates the report type.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ReportType
        Employee = 0
        Payroll = 1
    End Enum

    ''' <summary>
    ''' Enumerates the transaction type.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum TransactionType
        Add = 0
        Update = 1
        Delete = 2
    End Enum

    Public Structure strArrays
#Region "strArrays variables"
        Private strFirstColumn As String
        Private strSecondColumn As String
        Private strThirdColumn As String
        Private strFourthColumn As String
        Private dtSqlDbTypes As SqlDbType
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

        Protected Overloads Overrides Sub Finalize()
            Me.Finalize()
        End Sub
#End Region

#Region "Constructors"
        Public Sub New(ByVal strFirst As String)
            strFirstColumn = strFirst
        End Sub

        Public Sub New(ByVal strFirst As String, ByVal strSecond As String)
            strFirstColumn = strFirst
            strSecondColumn = strSecond
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
#End Region
    End Structure

    Protected Overloads Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub 'Finalize
End Class
