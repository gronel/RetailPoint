'Following class is inherited from basic ErrorProvider class
#Region "Error Provider Extended"
Public Class ErrorProviderExtended
    Inherits System.Windows.Forms.ErrorProvider
    Private _validationcontrols As New ValidationControlCollection
    Private _summarymessage As String = "Fill up required fields:" & Space(30)

    'This property will be used for displaying a summary message about all empty fields
    'Default value is "Please enter following mandatory fields,". You can set any other 
    'message using this property.
    Public Property SummaryMessage() As String
        Get
            Return _summarymessage
        End Get
        Set(ByVal Value As String)
            _summarymessage = Value
        End Set
    End Property

    'Controls property is of type ValidationControlCollection which is inherited from CollectionBase 
    'Controls holds all those objects which should be validated.
    Public Property Controls() As ValidationControlCollection
        Get
            Return _validationcontrols
        End Get
        Set(ByVal Value As ValidationControlCollection)
            _validationcontrols = Value
        End Set
    End Property

    'Following function returns true if all fields on form are entered.
    'If not all fields are entered, this function displays a message box which contains all those field names 
    'which are empty and returns FALSE.
    Public Function CheckAndShowSummaryErrorMessage() As Boolean
        If Controls.Count <= 0 Then
            Return True
        End If
        Dim i As Integer
        Dim msg As String = SummaryMessage + vbNewLine + vbNewLine
        Dim berrors As Boolean = False
        For i = 0 To Controls.Count - 1
            If Controls(i).Validate Then
                If Trim(Controls(i).ControlObj.text) = "" Then
                    msg &= " > " & Controls(i).DisplayName & vbNewLine
                    SetError(Controls(i).ControlObj, Controls(i).ErrorMessage)
                    berrors = True
                Else
                    SetError(Controls(i).ControlObj, "")
                End If
            Else
                SetError(Controls(i).ControlObj, "")
            End If
        Next
        If berrors Then
            System.Windows.Forms.MessageBox.Show(msg, "Missing Information", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function

    'Following function clears error messages from all controls.
    Public Sub ClearAllErrorMessages()
        Dim i As Integer
        For i = 0 To Controls.Count - 1
            SetError(Controls(i).ControlObj, "")
        Next
    End Sub

    'This function hooks validation event with all controls.
    Public Sub SetErrorEvents()
        Dim i As Integer
        For i = 0 To Controls.Count - 1
            AddHandler CType(Controls(i).ControlObj, System.Windows.Forms.Control).Validating, AddressOf Validation_Event
        Next
    End Sub

    'Following event is hooked for all controls, it sets an error message with the use of ErrorProvider.
    Private Sub Validation_Event(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Handles txtCompanyName.Validating
        If Controls(sender).Validate Then
            If Trim(sender.Text) = "" Then
                MyBase.SetError(sender, Controls(sender).ErrorMessage)
            Else
                MyBase.SetError(sender, "")
            End If
        End If
    End Sub
End Class
#End Region

'Following class is inherited from CollectionBase class. It is used for holding all Validation Controls.
'This class is collection of ValidationControl class objects.
'This class is used by ErrorProviderExtended class.
#Region "ValidationControlCollection"
Public Class ValidationControlCollection
    Inherits CollectionBase
    Default Public Property Item(ByVal ListIndex As Integer) As ValidationControl
        Get
            Return Me.List(ListIndex)
        End Get
        Set(ByVal Value As ValidationControl)
            Me.List(ListIndex) = Value
        End Set
    End Property


    Default Public Property Item(ByVal pControl As Object) As ValidationControl

        Get
            If IsNothing(pControl) Then Exit Property
            If GetIndex(pControl.Name) < 0 Then
                Return New ValidationControl
            End If
            Return Me.List(GetIndex(pControl.Name))
        End Get
        Set(ByVal Value As ValidationControl)
            If IsNothing(pControl) Then Exit Property
            If GetIndex(pControl.Name) < 0 Then
                Exit Property
            End If
            Me.List(GetIndex(pControl.Name)) = Value
        End Set
    End Property
    Function GetIndex(ByVal ControlName As String) As Integer
        Dim i As Integer
        For i = 0 To Count - 1
            If Item(i).ControlObj.name.toupper = ControlName.ToUpper Then
                Return i
            End If
        Next
        Return -1
    End Function

    Public Sub Add(ByRef pControl As Object, ByVal pDisplayName As String)
        If IsNothing(pControl) Then Exit Sub
        Dim obj As New ValidationControl
        obj.ControlObj = pControl
        obj.DisplayName = pDisplayName
        obj.ErrorMessage = pDisplayName + " is required"
        Me.List.Add(obj)
    End Sub

    Public Sub Add(ByRef pControl As Object, ByVal pDisplayName As String, ByVal pErrorMessage As String)
        If IsNothing(pControl) Then Exit Sub
        Dim obj As New ValidationControl
        obj.ControlObj = pControl
        obj.DisplayName = pDisplayName
        obj.ErrorMessage = pErrorMessage
        Me.List.Add(obj)
    End Sub
    Public Sub Add(ByRef pControl As Object)
        If IsNothing(pControl) Then Exit Sub
        Dim obj As New ValidationControl
        obj.ControlObj = pControl
        obj.DisplayName = pControl.Name
        obj.ErrorMessage = pControl.Name + " is required"
        Me.List.Add(obj)
    End Sub
    Public Sub Add(ByVal pControl As ValidationControl)
        If IsNothing(pControl) Then Exit Sub
        Me.List.Add(pControl)
    End Sub
    Public Sub Remove(ByVal pControl As Object)
        If IsNothing(pControl) Then Exit Sub
        Dim i As Integer = Me.GetIndex(pControl.Name)
        If i >= 0 Then
            Me.List.RemoveAt(i)
        End If
    End Sub
End Class
#End Region

'ValidationControl class is used to hold any control from windows form. 
'It holds any control in ControlObj property.
#Region "ValidationControl"
Public Class ValidationControl
    Private _control As Object
    Private _displayname As String
    Private _errormessage As String
    Private _validate As Boolean = True

    'Validate property decides weather control is to be validated. Default value is TRUE.
    Public Property Validate() As Boolean
        Get
            Return _validate
        End Get
        Set(ByVal Value As Boolean)
            _validate = Value
        End Set
    End Property

    'ControlObj is a control from windows form which is to be validated.
    'For example txtStudentName
    Public Property ControlObj() As Object
        Get
            Return _control
        End Get
        Set(ByVal Value As Object)
            _control = Value
        End Set
    End Property

    'DisplayName property is used for displaying summary message to user.
    'For example, for txtStudentName you can set 'Student Full Name' as field name.
    'This field name will be displayed in summary message.
    Public Property DisplayName() As String
        Get
            Return _displayname
        End Get
        Set(ByVal Value As String)
            _displayname = Value
        End Set
    End Property

    'ErrorMessage is also used for displaying summary message.
    'For example, you can enter 'Student Name is mandatory' as an error message.
    Public Property ErrorMessage() As String
        Get
            Return _errormessage
        End Get
        Set(ByVal Value As String)
            _errormessage = Value
        End Set
    End Property
End Class
#End Region

