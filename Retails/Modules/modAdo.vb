Module modAdo
    'Public Const cnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Data Source=../data/data.mdb;Jet OLEDB:Database Password=jaypee"

    ''' <summary>
    ''' Connection String for SQL Connection
    ''' </summary>
    Public cnString As String '

    ''= "Data Source=" & dbServer & _
    ''                   ";Database=" & dbName & _
    ''                   ";Uid=" & dbUser & _
    ''                   ";Pwd=" & dbPass & ";"


    ''' <summary>
    ''' Connection String for ADODB Connection
    ''' </summary>
    Public strConn As String = ("Driver={SQL Server};Server=" & dbServer & _
                            ";Database=" & dbName & _
                            ";Uid=" & dbUser & _
                            ";Pwd=" & dbPass & ";")



End Module
