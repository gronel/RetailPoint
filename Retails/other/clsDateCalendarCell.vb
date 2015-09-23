Public Class clsDateCalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "d"
        Me.Value = CDate(DateTime.Now.ToShortDateString & " 12:00 am") 'DateTime.Now
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As clsDateCalendarEditingControl = _
            CType(DataGridView.EditingControl, clsDateCalendarEditingControl)
        ctl.Value = CType(IIf(IsDBNull(Me.Value) = True, CDate(DateTime.Now.ToShortDateString & " 12:00 am"), Me.Value), DateTime)

    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(clsDateCalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return CDate(DateTime.Now.ToShortDateString & " 12:00 am")
        End Get
    End Property
End Class
