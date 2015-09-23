Dim shell, systempath

set shell = WScript.CreateObject( "WScript.Shell" )

systempath = shell.ExpandEnvironmentStrings("%SystemRoot%")

shell.Run Chr(34) & systempath & "\system32\msiexec.exe" & Chr(34) & "  /x{0E9BA106-7E05-47E0-B30C-46316845D32C}"

WScript.Quit