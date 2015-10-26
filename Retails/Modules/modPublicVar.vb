Imports RetailPoint.clsPublic
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing.Drawing2D
Imports System.Drawing
Module modPublicVar
   
    Public cryRpt As New ReportDocument
    Public arrParametersAndValue As ArrayList = New ArrayList

 
    ' changes, modification
    Public Const VersionChanges As String = "UPdate supplier"
    ' the date of new version
    Public Const VersionDate As String = "1.2015.10"
    ' this is the revision number,Ex. 2, "" if no revision
    Public Const Revision As String = "2"
    Public Const Version As String = "v." & VersionDate & " " & Revision

    ' index of row of datagrid to be deleted
    Public _intDeletedRow As Integer

    Public CurrUser As USER_INFO
    Public str_sql As String
    Public ListName As String



    Public field_array(100) As String
    Public tbl_Field() As String
    Public col_Field() As String

    Public currPath As String = Application.StartupPath
    Public HelpFilePath As String = Application.StartupPath & "\help.chm"

    Public dbServer As String   '= "bp-pmt\sqlexpress"
    Public dbName As String     '= "sigmasalesdb"
    Public dbUser As String     '= "sa"
    Public dbPass As String     '= "@123bps"
    Public dbTrust As Boolean   '= "@123bps"


    Public sCompanyName As String
    Public sDescription As String
    Public sAddress As String
    Public sTelNo1 As String
    Public sTelNo2 As String
    Public sFaxNo As String
    Public sTIN As String

    Public sCountDiscount As Integer
    Public hasCharge As Double

    Public sReportType As String
    Public sFilterBy As String
    Public sMonth As Integer
    Public sYear As Integer
    Public sForwardedBalance As Double
    Public sThirtyDays As Double
    Public sSixtyDays As Double
    Public sNinetyDays As Double
    Public sOneTwentyDays As Double
    Public sOneFiftyDays As Double
    Public strUpdates As String = String.Empty

    Public CompanyName As String
    Public CompanyAddress As String

    ''' <summary>
    ''' Computer name
    ''' </summary>
    ''' <remarks></remarks>
    Public ComputerName As String = My.Computer.Name

    Public frm As New Form
    ''======================
    ''STATUS VARIABLE
    ''======================
    Public SQL As String
    Public isNull As String = "Null"
    ''=========================
    ''IF PR TYPE IS CASH
    ''=========================
    Public isUnPlaced As String = "UN PLACED"
    Public isPlaced As String = "PLACED"
    Public isDone As String = "DONE"
    Public isUndone As String = "UNDONE"
    Public isPurchased As String = "PURCHASED"
    Public isPending As String = "PENDING"
    Public isCancelled As String = "CANCELLED"

    ''========================
    ''IF PR TYPE IS PO
    ''========================
    Public isUndelivered As String = "UNDELIVERED"
    Public isDelivered As String = "DELIVERED"
    Public isLacking As String = "LACKING"
    Public isExcess As String = "EXCESS"

    Public isnoUpdate As String = "noUpdate"

    Public isNotPurchased As String = "Not purchased"

    ''========================
    ''IF PR TYPE IS PO
    ''========================
    Public isProcessed As String = "Processed"
    Public isFinished As String = "Finished"

    ''========================
    ''FOR SUMMARY REPORT ONLY
    ''========================
    Public isReport As String
    Public isUsername As String
    Public isModule As String
    Public isFormControlNum As String
  
  

    Public isSale As Boolean

    Public connectionError As Boolean

    Public strVarImgPath As String


End Module
