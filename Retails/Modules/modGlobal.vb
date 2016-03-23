
Module modGlobal
    'Variable structure for user
    Public Structure USER_INFO
        Dim USER_ID As Integer
        Dim USER_NAME As String
        Dim USER_FULLNAME As String
        Dim USER_ISADMIN As Boolean
        Dim USER_PASSWORD As String
        Dim USER_PHOTO As Byte()
        Dim isActive As Boolean
        Dim User_Department As String


    End Structure

    Public Structure Company_Info
        Dim companyName As String
        Dim companyAddress As String

    End Structure





End Module
