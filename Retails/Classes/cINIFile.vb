Public Class cINIFile
    ' API functions
    Private Declare Ansi Function GetPrivateProfileString _
    Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
    (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpDefault As String, _
    ByVal lpReturnedString As System.Text.StringBuilder, _
    ByVal nSize As Integer, ByVal lpFileName As String) _
    As Integer
    Private Declare Ansi Function WritePrivateProfileString _
    Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
    (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpString As String, _
    ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileInt _
    Lib "kernel32.dll" Alias "GetPrivateProfileIntA" _
    (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal nDefault As Integer, _
    ByVal lpFileName As String) As Integer
    Private Declare Ansi Function FlushPrivateProfileString _
    Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
    (ByVal lpApplicationName As Integer, _
    ByVal lpKeyName As Integer, ByVal lpString As Integer, _
    ByVal lpFileName As String) As Integer
    Dim strFilename As String

    ' filename
    Public Sub New(ByVal Filename As String)
        strFilename = Filename
    End Sub

    Public Function GetString(ByVal Section As String, ByVal Key As String, ByVal [Default] As String) As String
        ' Returns a string from your INI file
        Dim intCharCount As Integer
        Dim objResult As New System.Text.StringBuilder(256)
        intCharCount = GetPrivateProfileString(Section, Key, _
        [Default], objResult, objResult.Capacity, strFilename)
        GetString = ""
        If intCharCount > 0 Then
            GetString = Left(objResult.ToString, intCharCount)
        End If
    End Function

    Public Function GetInteger(ByVal Section As String, ByVal Key As String, ByVal [Default] As Integer) As Integer
        ' Returns an integer from your INI file
        Return GetPrivateProfileInt(Section, Key, _
        [Default], strFilename)
    End Function

    Public Sub WriteString(ByVal Section As String, ByVal Key As String, ByVal Value As String)
        ' Writes a string to your INI file
        WritePrivateProfileString(Section, Key, Value, strFilename)
        Flush()
    End Sub

    Public Sub WriteInteger(ByVal Section As String, ByVal Key As String, ByVal Value As Integer)
        ' Writes an integer to your INI file
        WriteString(Section, Key, CStr(Value))
        Flush()
    End Sub

    Private Sub Flush()
        ' Stores all the cached changes to your INI file
        FlushPrivateProfileString(0, 0, 0, strFilename)
    End Sub
End Class
