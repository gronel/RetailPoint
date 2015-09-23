Public Class clsTimeCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        Me.Style.Format = "t"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As clsTimeEditingControl = _
            CType(DataGridView.EditingControl, clsTimeEditingControl)
        ctl.Value = CType(IIf(IsDBNull(Me.Value) = True Or Me.Value Is Nothing, Now, Me.Value), DateTime)

    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(clsTimeEditingControl)
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
            Return DateTime.Now
        End Get
    End Property
End Class
