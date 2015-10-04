
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Text.RegularExpressions
Imports System.Net

Module modFunction

    Public cn As SqlConnection
    ''Public conn As ADODB.Connection

    ''Public Sub setADO()

    ''    conn = New ADODB.Connection
    ''    conn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
    ''    If conn.State = ConnectionState.Open Then conn.Close()
    ''    conn.Open(strConn)

    ''End Sub

    Public Function CheckConnection() As Boolean
        Try
            'RESET connection strings----
            ''cnString = "Data Source=" & dbServer & _
            ''        ";Database=" & dbName & _
            ''        ";Uid=" & dbUser & _
            ''        ";Pwd=" & dbPass & ";"

            ''strConn = ("Driver={SQL Server};Server=" & dbServer & _
            ''                ";Database=" & dbName & _
            ''                ";Uid=" & dbUser & _
            ''                ";Pwd=" & dbPass & ";")

            strConn = cnString
            '------------------------------

            CheckConnection = False
            cn = New SqlConnection(cnString)

            With cn
                .Open()
                If .State = ConnectionState.Open Then .Close()
                CheckConnection = True
            End With

        Catch ex As Exception

            MsgBox("Connection failed.. Please contact your administrator!" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error")
            CheckConnection = False
        End Try

    End Function

    Public Sub showImg(ByVal str As String, ByVal fieldname As String, ByVal img As PictureBox)
        Dim pic() As Byte
        Dim con As New SqlConnection(cnString)
        Dim rdr As SqlDataReader
        Dim cmd As New SqlCommand(str, con)
        Try
            con.Open()
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rdr.Read
                pic = IIf(IsDBNull(rdr(fieldname)), Nothing, rdr(fieldname))
                img.Image = BytesToImage(pic)
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        Finally
        End Try
    End Sub


    Public Sub OpenDB()
        'create connection
        Try
            cn = New SqlConnection

            With cn
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = cnString
                .Open()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR [OpenDB]")
        End Try

    End Sub

    ''' <summary>
    ''' Same as DBLookUp
    ''' </summary>
    ''' <param name="srcSQL"></param>
    ''' <param name="strField"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFieldValue(ByVal srcSQL As String, ByVal strField As String) As Double

        Try
            OpenDB()
            Dim cmd As SqlCommand = New SqlCommand(srcSQL, cn)
            'create data reader
            Dim rdr As SqlDataReader = cmd.ExecuteReader

            GetFieldValue = Nothing

            'loop through result set
            While (rdr.Read)
                GetFieldValue = NZ(rdr(strField).ToString())
            End While

            'close data reader
            rdr.Close()
        Catch e As Exception
            Console.WriteLine("Error Occurred:" & e.ToString)
            MsgBox(e.Message, MsgBoxStyle.Critical)
            GetFieldValue = Nothing
        Finally
            ' Close connection
            cn.Close()
        End Try
    End Function

    Public Function GetIndex(ByVal srcsql As String) As Long

        OpenDB()
        'create commands
        Dim cmd As SqlCommand = New SqlCommand(srcsql, cn)

        Try
            'create data reader
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            Dim intNextNo As Integer

            'loop through result set
            While (rdr.Read)
                intNextNo = rdr(0).ToString
            End While

            intNextNo = intNextNo + 1
            GetIndex = intNextNo

        Catch ex As SqlException
            Console.WriteLine("ERROR OCCURED: " & ex.Message)
        Finally
            ' Close connection
            cn.Close()
            Console.WriteLine("Connection closed.")
        End Try
    End Function

    'Function that will format return a generated id
    Public Function GenerateID(ByVal srcNo As String, ByVal src1stStr As String, ByVal src2ndStr As String) As String
        If Len(src2ndStr) <= Len(srcNo) Then
            GenerateID = src1stStr & srcNo
        Else
            GenerateID = src1stStr & Left(src2ndStr, Len(src2ndStr) - Len(srcNo)) & srcNo
        End If
    End Function

    'Function that will return a currency format
    ''Public Function toMoney(ByVal srcCurr As String) As String
    ''    toMoney = Format(IIf(Trim(srcCurr) = "", 0, CSng(srcCurr)), "#,##0.00")
    ''End Function

    ''' <summary>
    ''' Save or Update table in the database
    ''' </summary>
    ''' <param name="srcTbl"></param>
    ''' <param name="startField"></param>
    ''' <param name="endField"></param>
    ''' <param name="frmState"></param>
    ''' <param name="srcda"></param>
    ''' <param name="srcds"></param>
    ''' <remarks></remarks>
    Public Sub SaveUpdateRecord(ByVal srcTbl As String, ByVal startField As Integer, ByVal endField As Integer, ByVal frmState As Long, ByRef srcda As SqlDataAdapter, ByRef srcds As DataSet)
        Dim i As Integer
        Dim strTable As String

        If InStr(srcTbl, "00_") Then
            strTable = Split(srcTbl, "_")(2)
        Else
            strTable = Replace(srcTbl, "tbl", "")
        End If


        Try
            Dim dt As DataTable = srcds.Tables(srcTbl)

            If frmState = clsPublic.FormState.AddState Then
                ' add a row
                Dim newRow As DataRow

                newRow = dt.NewRow()
                newRow(0) = field_array(0)
                dt.Rows.Add(newRow)

                ''Call SaveAuditTrail("Add New " & strTable, field_array(0))
            Else
                dt.Rows(0)(0) = field_array(0)
                ''Call SaveAuditTrail("Update  " & strTable, field_array(0))
            End If

            i = 1
            With dt
                For startField = 1 To endField
                    .Rows(0)(startField) = field_array(i)
                    i = i + 1
                Next
                srcda.Update(srcds, srcTbl)
            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    ''' <summary>
    ''' Display record in the form
    ''' </summary>
    ''' <param name="startField"></param>
    ''' <param name="endField"></param>
    ''' <param name="myData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DisplayRecord(ByVal startField As Integer, ByVal endField As Integer, ByRef myData As SqlDataReader) As Boolean
        Dim i As Integer
        Try
            i = 0
            Do While myData.Read
                For startField = 0 To endField
                    field_array(i) = IIf(myData.IsDBNull(i), "", myData.GetValue(i))
                    i = i + 1
                Next
            Loop
        Catch ex As Exception
            Return False
        End Try

    End Function

    ''Public Function toNumber(ByVal srcCurrency As String, Optional ByRef RetZeroIfNegative As Boolean = False) As Double
    ''    Dim retValue As Double
    ''    If srcCurrency = "" Then
    ''        toNumber = 0
    ''    Else
    ''        If InStr(1, srcCurrency, ",") > 0 Then
    ''            retValue = Val(Replace(srcCurrency, ",", "", , , CompareMethod.Text))
    ''        Else
    ''            retValue = Val(srcCurrency)
    ''        End If
    ''        If RetZeroIfNegative = True Then
    ''            If retValue < 1 Then retValue = 0
    ''        End If
    ''        toNumber = retValue
    ''        retValue = 0
    ''    End If

    ''End Function


    ''' <summary>
    ''' Check if input is a number - add on keypress event
    ''' Usage: KeyChar=validatemoney(KeyChar,txtBoxName)
    ''' </summary>
    ''' <param name="intKey"></param>
    ''' <param name="txt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateMoney(ByVal intKey As Char, ByVal txt As Object) As Char
        Dim str As String
        Dim varKey As Integer

        varKey = Asc(intKey)

        If varKey = 46 Then
            str = Replace(txt.Text, txt.SelectedText, "")

            If InStr(str, ".") Then
                ValidateMoney = ""
            Else
                ValidateMoney = Chr(varKey)
            End If
        ElseIf (varKey < Keys.D0 Or varKey > Keys.D9) And varKey <> Keys.Back And varKey <> Keys.Delete Then
            ValidateMoney = ""

        Else
            ValidateMoney = Chr(varKey)

        End If
    End Function


    ''' <summary>
    ''' Replace string emptyp or null Value to 0
    ''' </summary>
    ''' <param name="val">string value or numeric</param>
    ''' <returns>return 0 if val is empty else numeric value</returns>
    ''' <remarks></remarks>
    Public Function NZ(ByVal val As String) As Double
        If val = "" Or Not IsNumeric(val) Then
            NZ = 0
        Else
            NZ = val
        End If
    End Function

    ''' <summary>
    ''' Count records from a table
    ''' </summary>
    ''' <param name="sSQL">sql string </param>
    ''' <returns>number of rows</returns>
    ''' <remarks></remarks>
    Public Function CountRows(ByVal sSQL As String)
        OpenDB()

        Dim cmdCount As SqlCommand = New SqlCommand(sSQL, cn)

        CountRows = cmdCount.ExecuteScalar()
    End Function

    ''' <summary>
    ''' Get data from a table
    ''' </summary>
    ''' <param name="sSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetData(ByVal sSQL As String)
        GetData = ""

        OpenDB()
        Dim sqlCmd As SqlCommand = New SqlCommand(sSQL, cn)
        Dim myData As SqlDataReader

        Try

            myData = sqlCmd.ExecuteReader

            Return myData

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Function

    ''' <summary>
    ''' Execute SQL Statements/Query
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecNonQuery(ByVal strSQL As String)

        cn = New SqlConnection

        Try
            With cn
                If .State = ConnectionState.Open Then .Close()

                .ConnectionString = cnString
                .Open()
            End With

            Dim cmd As SqlCommand = New SqlCommand(strSQL, cn)

            cmd.ExecuteNonQuery()

            Return True
        Catch ex As SqlException
            MsgBox(ex.Message)
            Return ex
        Finally
            cn.Close()
        End Try
    End Function

    ''Public Sub SaveGridData(ByVal srcGrid As DataGridView, ByVal srcSQL As String, ByVal srcFields As String(), ByVal srcColName As String(), ByVal colCnt As Integer, ByVal varPK As String)
    ''    Dim rs As ADODB.Recordset
    ''    Dim i, x As Integer
    ''    '<<---------added 2010.07.01-----
    ''    Dim rowCount As Integer

    ''    If srcGrid.AllowUserToAddRows Then
    ''        rowCount = srcGrid.RowCount - 1
    ''    Else
    ''        rowCount = srcGrid.RowCount
    ''    End If
    ''    If rowCount = -1 Then Exit Sub
    ''    '------------------------------>>

    ''    Call setADO()
    ''    rs = New ADODB.Recordset
    ''    With rs
    ''        .Open(srcSQL, conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

    ''        i = 0
    ''        Do Until i = rowCount
    ''            x = 0
    ''            .AddNew()
    ''            Do Until x = colCnt
    ''                If x = 0 Then
    ''                    .Fields(srcFields(x)).Value = varPK
    ''                Else
    ''                    .Fields(srcFields(x)).Value = srcGrid.Item(srcColName(x - 1), i).Value
    ''                End If
    ''                x = x + 1
    ''            Loop
    ''            i = i + 1
    ''            .Update()
    ''        Loop

    ''        .Close()
    ''    End With
    ''    rs = Nothing

    ''    conn.Close()

    ''End Sub

    ''' <summary>
    ''' Fill gridview from a table in the database
    ''' </summary>
    ''' <param name="srcGrid">Datagrid source</param>
    ''' <param name="srcSQL">Sql String</param>
    ''' <param name="scrTable">source table</param>
    ''' <remarks></remarks>
    Public Sub FillGrid(ByVal srcGrid As DataGridView, ByVal srcSQL As String, ByVal scrTable As String)

        Try
            Dim myConn As SqlConnection = New SqlConnection(cnString)
            Dim da As SqlDataAdapter = New SqlDataAdapter(srcSQL, myConn)
            Dim dt As DataTable = New DataTable(scrTable)

            da.Fill(dt)
            srcGrid.DataSource = dt
        Catch ex As Exception
            MsgBox("Error : FillGrid " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub



    ''' <summary>
    ''' Function used to change the yes/no value
    ''' </summary>
    ''' <param name="srcStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function changeYNValue(ByVal srcStr As String) As String
        changeYNValue = ""
        Select Case srcStr
            Case "Y" : changeYNValue = "1"
            Case "N" : changeYNValue = "0"
            Case "1" : changeYNValue = "Y"
            Case "0" : changeYNValue = "N"
        End Select
    End Function

    Public Sub mSkin(ByVal scrTree As TreeView, ByVal mOption As String)

        With scrTree

            Select Case mOption

                Case "vbYellow"
                    .BackColor = Color.LightGoldenrodYellow
                    .ForeColor = Color.Black

                Case "vbBlack"
                    .BackColor = Color.Black
                    .ForeColor = Color.LightGoldenrodYellow

                Case "vbBlue"
                    .BackColor = Color.SteelBlue
                    .ForeColor = Color.LightGoldenrodYellow
            End Select

        End With
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="srcUser"></param>
    ''' <param name="srcPassword"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getUser(ByVal srcUser As String, ByVal srcPassword As String) As Boolean

        srcPassword = clsSecurity.psEncrypt(srcPassword)
        Dim xConn As New SqlConnection

        xConn.ConnectionString = cnString
        xConn.Open()

        Dim xCommand As New SqlCommand(String.Format("SELECT UserID, EmpID, EmpName, UserName, UserPassword, UserGroup, isActive, UserPhoto FROM tbl_000_User WHERE (UserName = '{0}') and (UserPassword='{1}')", srcUser, srcPassword), xConn)

        Dim xReader As SqlDataReader

        xReader = xCommand.ExecuteReader

        getUser = False

        While xReader.Read
            If xReader("UserName").ToString = srcUser And xReader("UserPassword").ToString = srcPassword Then
                CurrUser.USER_ID = xReader("UserID").ToString
                CurrUser.USER_NAME = xReader("UserName").ToString
                CurrUser.USER_FULLNAME = xReader("EmpName").ToString
                CurrUser.USER_PASSWORD = xReader("UserPassword").ToString
                CurrUser.isActive = xReader("isActive")
                CurrUser.USER_PHOTO = IIf(IsDBNull(xReader("UserPhoto")), Nothing, xReader("UserPhoto"))


                If xReader("UserGroup").ToString = "Admin" Then
                    CurrUser.USER_ISADMIN = True
                Else
                    CurrUser.USER_ISADMIN = False
                End If

                'CurrUser.USER_PHOTO = IIf(IsDBNull(xReader("EmpPhoto")), Nothing, xReader("EmpPhoto"))

                getUser = True
            End If

        End While

        xConn.Close()

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="srcsql">SQL String</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function isRecordExist(ByVal srcsql As String) As Boolean
        Dim xConn As New SqlConnection

        xConn.ConnectionString = cnString
        xConn.Open()

        Dim xCommand As New SqlCommand(srcsql, xConn)
        Dim xReader As SqlDataReader

        xReader = xCommand.ExecuteReader

        If xReader.HasRows Then
            isRecordExist = True
        Else
            isRecordExist = False
        End If

        xConn.Close()

    End Function

    Public Function ifFileExist(ByVal fPath As String) As Boolean
        If System.IO.File.Exists(fPath) = True Then
            ifFileExist = True
        Else
            ifFileExist = False
        End If
    End Function

    Public Sub ClearFields(ByVal frm As Form)

        For Each ctrl As Control In frm.Controls
            If TypeOf ctrl Is ComboBox Then
                ctrl.Text = Nothing
            End If
            If TypeOf ctrl Is TextBox Then
                ctrl.Text = Nothing
            End If
        Next

    End Sub

    Public Sub setUserRights(ByVal frmName As String)

        Dim nConn As New SqlConnection
        Dim nSQL As String = "SetUserRights " & CurrUser.USER_ID & ", '" & frmName & "'"

        nConn = New SqlConnection

        With nConn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = cnString
            .Open()
        End With

        Dim cmdCust As New SqlCommand

        cmdCust.Connection = nConn
        cmdCust.CommandText = nSQL

        Dim dr As SqlDataReader = cmdCust.ExecuteReader()

        While dr.Read()
            With MainForm
                If dr("canAdd") = True Then
                    MainForm.tsNew.Visible = True
                Else
                    MainForm.tsNew.Visible = False
                End If

                If dr("canEdit") = True Then
                    MainForm.tsEdit.Visible = True
                Else
                    MainForm.tsEdit.Visible = False
                End If

              
                If dr("canDelete") = True Then
                    MainForm.tsDelete.Visible = True
                Else
                    MainForm.tsDelete.Visible = False
                End If

                If dr("canPreview") = True Then
                    .tsPreview.Visible = True
                Else
                    .tsPreview.Visible = False
                End If

                If dr("canPrint") = True Then
                    .tsPrint.Visible = True
                Else
                    .tsPrint.Visible = False
                End If

               

                '' separator after Delete
                If dr("canDelete") = True Then
                    .sepDelete.Visible = True
                Else
                    .sepDelete.Visible = False
                End If

                '' separator after Print
                If dr("canPrint") = True Or dr("canPreview") = True Then
                    .sepPrint.Visible = True
                Else
                    .sepPrint.Visible = False
                End If



            End With

        End While
        dr.Close()
        nConn.Close()

    End Sub

    ''' <summary>
    ''' Look up the value of a field in the table
    ''' </summary>
    ''' <param name="strSQL">SQL String</param>
    ''' <param name="fieldName">Field name</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DBLookUp(ByVal strSQL As String, ByVal fieldName As String) As String
        Dim nConn As New SqlConnection

        nConn = New SqlConnection

        With nConn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = cnString

            .Open()
        End With

        Dim cmdCust As New SqlCommand

        cmdCust.Connection = nConn
        cmdCust.CommandText = strSQL
        Dim dr As SqlDataReader = cmdCust.ExecuteReader()
        DBLookUp = ""
        While dr.Read()
            DBLookUp = IIf(IsDBNull(dr(fieldName)), String.Empty, dr(fieldName))
        End While
        dr.Close()
        nConn.Close()
    End Function





    ''' <summary>
    ''' Resize form
    ''' </summary>
    ''' <param name="frm">Form name </param>
    ''' <remarks></remarks>
    Public Sub ResizeForm(ByVal frm As Form)
        frm.Top = 0
        frm.Left = 0
        frm.Width = frm.Parent.DisplayRectangle.Width
        frm.Height = frm.Parent.DisplayRectangle.Height
        frm.BackColor = Color.PaleTurquoise
        frm.KeyPreview = True
    End Sub

    ''' <summary>
    ''' Fill GridView
    ''' </summary>
    ''' <param name="dgView">DatagridView</param>
    ''' <param name="strSQL">SQL String</param>
    ''' <param name="colStart">column start</param>
    ''' <param name="colEnd">column end</param>
    ''' <remarks></remarks>
    Public Sub FillDataGrid(ByVal dgView As DataGridView, ByVal strSQL As String, ByVal colStart As Integer, ByVal colEnd As Integer)

        Dim intRow As Integer
        Dim i As Integer
        Dim intCol As Integer

        OpenDB()

        Dim cmdCust As New SqlCommand

        dgView.Rows.Clear()
        cmdCust.Connection = cn
        cmdCust.CommandText = strSQL
        Dim dr As SqlDataReader = cmdCust.ExecuteReader()


        While dr.Read()
            i = 0
            intRow = dgView.Rows.Add()
            For intCol = colStart To colEnd
                dgView.Item(intCol, intRow).Value = dr(i)
                i = i + 1
            Next
        End While
        dr.Close()
        cn.Close()

    End Sub

    ''' <summary>
    ''' Remove selected rows or the current row from the datagridview
    ''' </summary>
    ''' <param name="dgView"></param>
    ''' <remarks></remarks>
    Public Sub RemoveFromDataGrid(ByVal dgView As DataGridView)
        ''Dim i As Integer
        Dim c As System.Windows.Forms.DataGridViewSelectedRowCollection

        c = dgView.SelectedRows

        If c.Count > 0 Then
            For Each row As DataGridViewRow In dgView.SelectedRows
                dgView.Rows.Remove(row)
            Next
        Else

            If Not dgView.CurrentRow Is Nothing Then dgView.Rows.Remove(dgView.CurrentRow)
        End If
    End Sub

    ''' <summary>
    ''' Count Datagridview rows
    ''' </summary>
    ''' <param name="dg"></param>
    ''' <remarks></remarks>
    Function getRecordCount(ByVal dg As DataGridView) As String
        getRecordCount = " - " & dg.RowCount & IIf(dg.RowCount <= 1, " RECORD SHOWN", " RECORDS SHOWN")
    End Function


    '// --add this code in CellValidating event of DatagridView	
    '//	
    '//If ValidateNumericDataGrid(dgSOA, 3, e.RowIndex, False) = False Then
    '//     MsgBox("Please enter numeric value. ", MsgBoxStyle.Exclamation, "Invalid Entry")
    '//     dgSOA.CancelEdit()
    '//End If
    ''' <summary>
    ''' Check if value enter in Datagridview is numeric
    ''' </summary>
    ''' <param name="dgDatagrid"></param>
    ''' <param name="intColumnIndex"></param>
    ''' <param name="intRowIndex"></param>
    ''' <param name="bolAllowNegative"></param>
    ''' <remarks></remarks>
    Public Function ValidateNumericDataGrid(ByVal dgDatagrid As System.Windows.Forms.DataGridView, ByVal intColumnIndex As Integer, ByVal intRowIndex As Integer, Optional ByVal bolAllowNegative As Boolean = True) As Boolean
        Dim dgValue As Object
        ValidateNumericDataGrid = True
        dgValue = dgDatagrid.Item(intColumnIndex, intRowIndex).EditedFormattedValue
        If Not dgValue Is Nothing Then
            If dgValue.ToString = "" Then
                ValidateNumericDataGrid = True
            ElseIf Not IsNumeric(dgValue) Then
                ValidateNumericDataGrid = False
            Else
                ValidateNumericDataGrid = True
                If bolAllowNegative = False Then
                    If dgValue < 0 Then
                        ValidateNumericDataGrid = False
                    End If
                End If
            End If
        End If
    End Function

    ''' <summary>
    ''' Get user's rights
    ''' </summary>
    ''' <param name="dgView"></param>
    ''' <param name="tsAdd"></param>
    ''' <param name="tsDelete"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUserRights(ByVal dgView As DataGridView, ByVal tsAdd As Boolean, ByVal tsDelete As Boolean) As Integer
        With dgView
            .AllowUserToAddRows = tsAdd
            .AllowUserToDeleteRows = tsDelete
            If tsAdd Then
                GetUserRights = .RowCount - 1
            Else
                GetUserRights = .RowCount
            End If
        End With
    End Function

    Public Enum LengthUnit
        Feet = 0
        Inches = 1
        Meter = 2
        Centimeter = 3
    End Enum

    ''' <summary>
    ''' Length Converter function
    ''' </summary>
    ''' <param name="ConvertFrom"></param>
    ''' <param name="ConvertTo"></param>
    ''' <remarks></remarks>
    Public Function LengthConvert(ByVal ConvertFrom As LengthUnit, ByVal ConvertTo As LengthUnit) As Double

        Dim dblValue As Double = 1

        If ConvertFrom = ConvertTo Then LengthConvert = dblValue
        ''FEET
        If ConvertFrom = LengthUnit.Feet And ConvertTo = LengthUnit.Inches Then
            LengthConvert = dblValue * 12
        ElseIf ConvertFrom = LengthUnit.Feet And ConvertTo = LengthUnit.Meter Then
            LengthConvert = dblValue * 0.3048
        ElseIf ConvertFrom = LengthUnit.Feet And ConvertTo = LengthUnit.Centimeter Then
            LengthConvert = dblValue * 30.48
        End If

        ''INCHES
        If ConvertFrom = LengthUnit.Inches And ConvertTo = LengthUnit.Feet Then
            LengthConvert = dblValue * 0.08333333
        ElseIf ConvertFrom = LengthUnit.Inches And ConvertTo = LengthUnit.Meter Then
            LengthConvert = dblValue * 0.0254
        ElseIf ConvertFrom = LengthUnit.Inches And ConvertTo = LengthUnit.Centimeter Then
            LengthConvert = dblValue * 2.54

            ''METER
        ElseIf ConvertFrom = LengthUnit.Meter And ConvertTo = LengthUnit.Centimeter Then
            LengthConvert = dblValue * 100
        ElseIf ConvertFrom = LengthUnit.Meter And ConvertTo = LengthUnit.Inches Then
            LengthConvert = dblValue * 39.370078740157481
        ElseIf ConvertFrom = LengthUnit.Meter And ConvertTo = LengthUnit.Feet Then
            LengthConvert = dblValue * 3.2808398950131235

            ''CENTIMETER
        ElseIf ConvertFrom = LengthUnit.Centimeter And ConvertTo = LengthUnit.Meter Then
            LengthConvert = dblValue * 0.01
        ElseIf ConvertFrom = LengthUnit.Centimeter And ConvertTo = LengthUnit.Inches Then
            LengthConvert = dblValue * 0.39370078740157483
        ElseIf ConvertFrom = LengthUnit.Centimeter And ConvertTo = LengthUnit.Feet Then
            LengthConvert = dblValue * 0.032808398950131233
        End If

    End Function

    ''' <summary>
    ''' Check if DataGridView has rows
    ''' </summary>
    ''' <param name="srcDataGridView"></param>
    ''' <remarks></remarks>
    Function GridHasRows(ByVal srcDataGridView As DataGridView) As Boolean
        If srcDataGridView.RowCount > 0 Then
            GridHasRows = True
        Else
            GridHasRows = False
        End If
    End Function



    ''' <summary>
    ''' Update the status strip to denote the current network connection status
    ''' </summary>
    ''' <param name="connected"></param>
    ''' <remarks></remarks>
    Public Sub SetConnectionStatus(ByVal connected As Boolean)
        ''With My.Forms.MainForm.lblServer
        ''    If (connected) Then
        ''        .Image = My.Resources.Computer1
        ''        .Text = "Connected"
        ''    Else
        ''        .Image = My.Resources.Computer2
        ''        .Text = "Disconnected"
        ''    End If
        ''End With
    End Sub

    ''' <summary>
    ''' Get the end of date
    ''' </summary>
    ''' <param name="intMonth"></param>
    ''' <param name="intYear"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEndOfDate(ByVal intMonth As Integer, ByVal intYear As Integer) As Date
        Dim DateA As String = intMonth & "/31/" & intYear
        Dim DateB As String = intMonth & "/30/" & intYear
        Dim DateC As String = intMonth & "/29/" & intYear
        Dim DateD As String = intMonth & "/28/" & intYear

        If IsDate(DateA) Then
            GetEndOfDate = DateA
        ElseIf IsDate(DateB) Then
            GetEndOfDate = DateB
        ElseIf IsDate(DateC) Then
            GetEndOfDate = DateC
        ElseIf IsDate(DateD) Then
            GetEndOfDate = DateD
        Else
            GetEndOfDate = String.Empty
        End If
    End Function
    ''' <summary>
    ''' Clear all Text in the current form
    ''' </summary>
    ''' <param name="frm"></param>
    ''' <remarks></remarks>
    Public Sub ClearTextbox(ByVal frm As Form)

        For Each Control In frm.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
        Next

    End Sub

    Public Sub ErrorMessage(ByVal errPro As ErrorProvider, ByVal ctl As Control)
        If String.IsNullOrEmpty(ctl.Text) Then
            errPro.SetError(ctl, "Required")
        Else
            errPro.SetError(ctl, "")
        End If
    End Sub

    Function CountCharacter(ByVal sText As String, ByVal sFind As String) As Long
        Dim count As Integer

        For i = 1 To Len(sText)
            If Mid$(sText, i, 1) = sFind Then count = count + 1
        Next

        CountCharacter = count
    End Function

    ''' <summary>
    ''' Center Control on the form
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <remarks></remarks>
    Public Sub CenterControl(ByVal ctrl As Control, ByVal frm As Form)
        ctrl.Left = (frm.Width - ctrl.Width) / 2
    End Sub

    ''' <summary>
    ''' Center the form
    ''' </summary>
    ''' <param name="frm"></param>
    ''' <remarks></remarks>

    Public Sub CenterForm(ByVal frm As Form, Optional ByVal isTop As Boolean = False)

        ''frm.Left = (My.Computer.Screen.WorkingArea.Width - frm.Width) / 2
        ''frm.Top = (frm.MdiParent.Height - frm.Height) / 4
        On Error Resume Next
        frm.Left = (frm.Parent.DisplayRectangle.Width - frm.Width) / 2
        If isTop Then
            frm.Top = 0
        Else
            frm.Top = (frm.Parent.DisplayRectangle.Height - frm.Height) / 2
        End If

    End Sub

    Public Function BrowsePhoto(ByVal pic As PictureBox) As String
        Try

            Dim dlg As New OpenFileDialog()
            dlg.Title = "Browse Photo"
            dlg.Filter = "All Picture Files)|*.jpg;*.bmp;*.jpeg;*.gif;*.png"
            Dim dlgRes As DialogResult = dlg.ShowDialog()

            'Ask user to select file.
            If dlgRes <> DialogResult.Cancel Then
                'Set image in picture box
                pic.ImageLocation = dlg.FileName

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "BrowsePhoto")
        End Try

    End Function

    ''' <summary>
    ''' Converts image into bytes.
    ''' </summary>
    ''' <param name="img">The image.</param>
    ''' <returns>An image from the bytes retrieved from the database.</returns>
    Public Function ImageToByte(ByVal img As Image) As Byte()
        Dim imgStream As MemoryStream = New MemoryStream()

        img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Png)

        imgStream.Close()
        Dim byteArray As Byte() = imgStream.ToArray()
        imgStream.Dispose()

        Return byteArray
    End Function

    ''' <summary>
    ''' Converts bytes into an image.
    ''' </summary>
    ''' <param name="imageByte">the bytes to be converted into image.</param>
    ''' <returns>An image from the bytes retrieved from the database.</returns>
    Public Function BytesToImage(ByVal imageByte As Byte()) As Image
        Dim theImage As Image = Nothing
        Try
            If Not imageByte Is Nothing Then
                imageByte = CType(imageByte, Byte())
                Dim stream As New MemoryStream(imageByte)
                Dim bmp As New Bitmap(stream)
                stream.Close()
                stream.Dispose()
                theImage = DirectCast(bmp, Image)
            Else
                theImage = Nothing
            End If

        Catch ex As Exception
            Throw
            MsgBox("Error : BytesToImage in clsFunctions." & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Error")
        Finally
            BytesToImage = theImage
        End Try
    End Function



    Public Sub SetStatusText(ByVal strStatusText As String)
        MainForm.lblStatus.Text = strStatusText
    End Sub

    ''' <summary>
    ''' Checks in the datagridview if the passed code is found.
    ''' </summary>
    ''' <param name="srcDataGridView">The datagridview to be checked.</param>
    ''' <param name="intCol">The column index to be checked.</param>
    ''' <param name="strCodeToCheck">The code to look for.</param>
    ''' <returns>Returns true if the passed code is found, else false.</returns>
    ''' <remarks></remarks>
    Public Function CheckCodeFromDatagridView(ByVal srcDataGridView As DataGridView, ByVal intCol As Integer, _
                                                     ByVal strCodeToCheck As String, Optional ByVal rowIndex As Integer = -1, _
                                                     Optional ByVal blnByValue As Boolean = True) As Boolean
        Dim blnResult As Boolean = False
        Try
            If blnByValue = True Then
                If rowIndex = -1 Then
                    For Each row As DataGridViewRow In srcDataGridView.Rows
                        If Not row.IsNewRow Then
                            If UCase(row.Cells(intCol).Value) = UCase(strCodeToCheck) Then
                                blnResult = True
                                Exit For
                            End If
                        End If
                    Next
                Else
                    For Each row As DataGridViewRow In srcDataGridView.Rows
                        If Not row.IsNewRow Then
                            If UCase(row.Cells(intCol).Value) = UCase(strCodeToCheck) And row.Index <> rowIndex Then
                                blnResult = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            Else
                If rowIndex = -1 Then
                    For Each row As DataGridViewRow In srcDataGridView.Rows
                        If Not row.IsNewRow Then
                            If UCase(row.Cells(intCol).EditedFormattedValue) = UCase(strCodeToCheck) Then
                                blnResult = True
                                Exit For
                            End If
                        End If
                    Next
                Else
                    For Each row As DataGridViewRow In srcDataGridView.Rows
                        If Not row.IsNewRow Then
                            If UCase(row.Cells(intCol).EditedFormattedValue) = UCase(strCodeToCheck) And row.Index <> rowIndex Then
                                blnResult = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw
            MsgBox("Error : CheckCodeFromDatagridView in clsFunctions." & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Error")
        Finally
            CheckCodeFromDatagridView = blnResult
        End Try
    End Function

    Public Function CountGridRows(ByVal dg As DataGridView) As Integer
        Try
            If dg.AllowUserToAddRows Then
                CountGridRows = dg.RowCount - 1
            Else
                CountGridRows = dg.RowCount
            End If
        Catch ex As Exception

        End Try
    End Function



    Public Function IsValidURL(ByVal url As String) As Boolean
        Dim is_valid As Boolean = False
        If url.ToLower().StartsWith("www.") Then url = _
            "http://" & url

        Dim web_response As HttpWebResponse = Nothing
        Try
            Dim web_request As HttpWebRequest = _
                HttpWebRequest.Create(url)
            web_response = _
                DirectCast(web_request.GetResponse(),  _
                HttpWebResponse)
            Return True
        Catch ex As Exception
            Return False
        Finally
            If Not (web_response Is Nothing) Then _
                web_response.Close()
        End Try
    End Function

    Public Function IsValidEmailFormat(ByVal email As String) As Boolean
        Dim pattern As String = "^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\." & _
        "(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$"
        Dim check As New Regex(pattern, RegexOptions.IgnorePatternWhitespace)
        Dim valid As Boolean = False
        If String.IsNullOrEmpty(email) Then
            valid = False
        Else
            valid = check.IsMatch(email)
        End If
        Return valid
    End Function

    ''' <summary>
    ''' Adds a child node to the srcNode.
    ''' </summary>
    ''' <param name="srcNode">The node to be added with child nodes.</param>
    ''' <param name="srcParentCode">The parent code of the current item to be added.</param>
    ''' <param name="srcChildCode">The code of the current item to be added.</param>
    ''' <param name="strDescription">The description of the current item to be added.</param>
    ''' <remarks></remarks>
    Public Sub AddNode(ByVal srcNode As TreeNode, ByVal srcParentCode As String, ByVal srcChildCode As String, _
                              ByVal strDescription As String, Optional ByVal imageIndex As Integer = 1)
        Try
            For Each parentNode As TreeNode In srcNode.Nodes
                If parentNode.Tag = srcParentCode Then
                    Dim childNode As New TreeNode(strDescription)
                    childNode.Tag = srcChildCode
                    childNode.ImageIndex = imageIndex
                    parentNode.Nodes.Add(childNode)
                Else
                    AddNode(parentNode, srcParentCode, srcChildCode, strDescription, imageIndex)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error : AddNode in clsProcedures." & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub


    Public Function GridHasZeroValue(ByVal dg As DataGridView, ByVal colIndex As Integer) As Boolean
        Try

            For Each row As DataGridViewRow In dg.Rows
                If row.Index <> dg.RowCount - 1 And dg(colIndex, row.Index).Value Is Nothing Then
                    Return False
                    Exit For
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function HasDuplicateCodes(ByVal srcDataGridView As DataGridView, ByVal intCol As Integer, _
                                             Optional ByVal inEdittedFormat As Boolean = False) As Boolean
        Dim blnResult As Boolean = False
        Try
            For intRow As Integer = 0 To (srcDataGridView.RowCount - 2)
                For intRow2 As Integer = (intRow + 1) To (srcDataGridView.RowCount - 2)
                    If inEdittedFormat = False Then
                        If srcDataGridView.Item(intCol, intRow).Value = srcDataGridView.Item(intCol, intRow2).Value Then
                            blnResult = True
                            Exit For
                        End If
                    Else
                        If srcDataGridView.Item(intCol, intRow).EditedFormattedValue = srcDataGridView.Item(intCol, intRow2).EditedFormattedValue Then
                            blnResult = True
                            Exit For
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            Throw
            MsgBox("Error : HasDuplicateCodes in clsFunctions." & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation, "Error")
        Finally
            HasDuplicateCodes = blnResult
        End Try
    End Function

    

    ''' <summary>
    ''' Count Data Row
    ''' </summary>
    ''' <param name="strCommand">SQL</param>
    ''' <returns>Return number of rows</returns>
    ''' <remarks>Used</remarks>
    Public Function CountDataRow(ByVal strCommand As String) As Integer
        Dim arrSource As New ArrayList
        Dim mycount As Integer
        Dim con As New SqlConnection(cnString)
        Try
            con.Open()
            Dim myCmd As SqlCommand = New SqlCommand(strCommand, con)
            Dim myReader As SqlDataReader = myCmd.ExecuteReader
            With myReader
                If .HasRows Then
                    While .Read
                        For introw As Integer = 0 To (.FieldCount - 1)
                            'arrSource.Add(myReader.Item(introw).ToString)
                            mycount += introw
                        Next
                    End While
                End If
                .Close()
            End With
            con.Close()
            Return mycount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strParameterAndValue"></param>
    ''' <param name="strCommand"></param>
    ''' <param name="srcCommandType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FetchData(ByVal strParameterAndValue As ArrayList, ByVal strCommand As String, _
                                     ByVal srcCommandType As CommandType) As ArrayList
        Dim blnIndependentlyUsed As Boolean = False
        Dim arrSource As New ArrayList
        Try
            Dim con As New SqlConnection(cnString)
            con.Open()
            Dim myCmd As SqlCommand = New SqlCommand(strCommand, con)
            If Not (strParameterAndValue Is Nothing) Then
                For Each theArray As clsEnumerations.strArrays In strParameterAndValue
                    myCmd.Parameters.Add(theArray.firstColumn, theArray.SqlDbTypes)
                    myCmd.Parameters(theArray.firstColumn).Value = theArray.secondColumn
                Next
            End If
            myCmd.CommandType = srcCommandType
            Dim myReader As SqlDataReader = myCmd.ExecuteReader
            With myReader
                If .HasRows Then
                    While .Read
                        For introw As Integer = 0 To (.FieldCount - 1)
                            arrSource.Add(myReader.Item(introw).ToString)
                        Next
                    End While
                End If
                .Close()
            End With
            con.Close()
        Catch ex As Exception
            Throw
        Finally
            FetchData = arrSource
            If blnIndependentlyUsed = True Then

            End If
        End Try
    End Function



    ''' <summary>
    ''' DataGridView Combobox Multicolumn
    ''' </summary>
    ''' <param name="srcDataGridView">DataGridView</param>
    ''' <param name="srcColumn">DataGridView Combobox src</param>
    ''' <param name="strColumnWidths"> Width of the column</param>
    ''' <param name="intColumnNumber">Number of column</param>
    ''' <param name="strCommand">SQL Commnad</param>
    ''' <param name="strDisplayMember">DisplayMember</param>
    ''' <param name="strValueMember">ValueMember</param>
    ''' <param name="srcCommandType">Commnad Type</param>
    ''' <param name="arrParameterAndValues">Parameters and Values</param>
    ''' <remarks></remarks>
    Public Sub FillMultiColumn(ByVal srcDataGridView As DataGridView, ByVal srcColumn As DataGridViewColumn, ByVal strColumnWidths As String, _
                                            ByVal intColumnNumber As Integer, ByVal strCommand As String, ByVal strDisplayMember As String, _
                                            ByVal strValueMember As String, Optional ByVal srcCommandType As CommandType = CommandType.Text, _
                                            Optional ByVal arrParameterAndValues As ArrayList = Nothing)

        Dim cn As New SqlConnection(cnString)


        Try
            Dim position As Integer = srcColumn.Index
            Dim myCmd As SqlCommand = New SqlCommand(strCommand, cn)
            myCmd.CommandType = srcCommandType


            Dim da As SqlDataAdapter = New SqlDataAdapter(myCmd)
            Dim ds As New DataSet
            da.Fill(ds, "temp")
            Dim dt As DataTable = ds.Tables("temp")
            Dim newColumn As New DataGridViewMultiColumnComboColumnDemo.DataGridViewMultiColumnComboColumn
            newColumn.CellTemplate = New DataGridViewMultiColumnComboColumnDemo.DataGridViewMultiColumnComboCell
            newColumn.Name = srcColumn.Name
            newColumn.AutoSizeMode = srcColumn.AutoSizeMode
            newColumn.HeaderText = srcColumn.HeaderText
            newColumn.Width = srcColumn.Width
            newColumn.DataSource = dt
            newColumn.DisplayMember = strDisplayMember
            newColumn.ValueMember = strValueMember
            srcDataGridView.Columns.Insert(position + 1, newColumn)
            srcDataGridView.Columns.Remove(srcColumn.Name)
            myCmd.Dispose()
        Catch ex As Exception
            MsgBox("Error : FillMultiColumn in clsProcedures." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error")
        Finally
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Fill Report
    ''' </summary>
    ''' <param name="sql"> Query string / StoredProcedure</param>
    ''' <param name="cmdType">commandType</param>
    ''' <param name="strParameterAndValue">Parameter Value</param>
    ''' <returns>Return Report</returns>
    ''' <remarks>Used</remarks>
    Public Function FillReport(ByVal sql As String, ByVal cmdType As CommandType, ByVal strParameterAndValue As ArrayList)
        Dim con As SqlConnection
        Dim da As SqlDataAdapter
        Dim myDT As New DataTable
        Dim mycmd As SqlCommand
        Try
            con = New SqlConnection(cnString)
            mycmd = New SqlCommand(sql, con)
            If Not (strParameterAndValue Is Nothing) Then
                For Each theArray As clsEnumerations.strArrays In strParameterAndValue
                    mycmd.Parameters.Add(theArray.firstColumn, theArray.SqlDbTypes)
                    mycmd.Parameters(theArray.firstColumn).Value = theArray.secondColumn
                Next
            End If
            mycmd.CommandType = cmdType
            da = New SqlDataAdapter(mycmd)
            da.Fill(myDT)
            Return myDT
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function


    Public inc As Integer
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim MaxRows As Integer
    Public isnext As Boolean = False
    Public dt As DataTable

    ''' <summary>
    ''' Navigation
    ''' </summary>
    ''' <param name="SQLstring">StoredProcedure / SQL string</param>
    ''' <param name="sourceTable">Table</param>
    ''' <param name="FieldString">Fieldname</param>
    ''' <param name="Binding">Next, Back First and Last</param>
    ''' <returns>Return Fieldname</returns>
    ''' <remarks>Used</remarks>
    Public Function Navigation(ByVal SQLstring As String, ByVal sourceTable As String, ByVal FieldString As String, ByVal Binding As String) As String

        Try
            Dim myconn As SqlConnection = New SqlConnection(cnString)
            Dim cmd As SqlCommand = New SqlCommand(SQLstring, myconn)
            Dim Field As String
            da.SelectCommand = cmd
            da.Fill(ds, sourceTable)

            dt = ds.Tables(sourceTable)

            MaxRows = dt.Rows.Count - 1
            Select Case Binding
                Case "Next"
                    If inc < MaxRows Then
                        If isnext = False Then
                            inc = 0
                            Field = ds.Tables(sourceTable).Rows(inc).Item(FieldString)
                        Else
                            inc = inc + 1
                            Field = ds.Tables(sourceTable).Rows(inc).Item(FieldString)
                        End If
                        isnext = True
                    Else
                        Field = ds.Tables(sourceTable).Rows(inc).Item(FieldString)
                    End If

                Case "Back"
                    If inc > 0 Then
                        inc = inc - 1
                        Field = ds.Tables(sourceTable).Rows(inc).Item(FieldString)
                    Else
                        'inc = MaxRows
                        'inc = inc - 1
                        Field = ds.Tables(sourceTable).Rows(inc).Item(FieldString)
                    End If

                Case "Last"
                    If inc <> MaxRows - 1 Then
                        inc = MaxRows - 1
                    End If
                    Field = ds.Tables(sourceTable).Rows(inc).Item(FieldString)
                Case "First"
                    inc = 0
                    Field = ds.Tables(sourceTable).Rows(inc).Item(FieldString)
            End Select

            dt.Reset()
            Return Field
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConvertToMoney(ByVal obj As String) As String
        Dim str As String
        str = obj
        If (str.IndexOf(".") <> -1) Then
            ConvertToMoney = obj
        Else
            ConvertToMoney = FormatNumber(CDbl(obj), 2)
        End If
    End Function

End Module
