Imports System
Imports System.Windows.Forms
Imports System.Reflection

Public Class ObjectFinder
    Public Shared Function CreateObjectInstance(ByVal objectName As String) As Object
        ' Creates and returns an instance of any object in the assembly by its type name.

        Dim obj As Object

        Try
            If objectName.LastIndexOf(".") = -1 Then
                'Appends the root namespace if not specified.
                objectName = [Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If

            obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)

        Catch ex As Exception
            obj = Nothing
        End Try
        Return obj

    End Function

    Public Shared Function CreateForm(ByVal formName As String) As Form
        ' Return the instance of the form by specifying its name.
        Return DirectCast(CreateObjectInstance(formName), Form)
    End Function

End Class