
'*************************************************************************************************
' * 
' * FILE NAME:
' *      DataGridViewMultiColumnComboColumn.cs
' * 
' * AUTHOR:
' *      Issahar Gourfinkel, 
' *      gurfi@barak-online.net
' *      This code is Completely free. I will be happy if it will help somebody.     
' * 
' * DESCRIPTION:
' *      MultiColumnCombobox simulation for DataGridView cells controls.
' * 
' * 
' * 
' * DISCLAIMER OF WARRANTY:
' *      All of the code, information, instructions, and recommendations in this software component are 
' *      offered on a strictly "as is" basis. This material is offered as a free public resource, 
' *      without any warranty, expressed or implied.
' 


Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Namespace DataGridViewMultiColumnComboColumnDemo

    Public Class DataGridViewMultiColumnComboColumn
        Inherits DataGridViewComboBoxColumn

        Public Sub New()
            'Set the type used in the DataGridView
            Me.CellTemplate = New DataGridViewMultiColumnComboCell()
        End Sub
    End Class

    Public Class DataGridViewMultiColumnComboCell
        Inherits DataGridViewComboBoxCell

        Public Overrides ReadOnly Property EditType() As Type
            Get
                Return GetType(DataGridViewMultiColumnComboEditingControl)
            End Get
        End Property

        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
            Dim ctrl As DataGridViewMultiColumnComboEditingControl = TryCast(DataGridView.EditingControl, DataGridViewMultiColumnComboEditingControl)
            ctrl.ownerCell = Me
        End Sub
    End Class

    Public Class DataGridViewMultiColumnComboEditingControl
        Inherits DataGridViewComboBoxEditingControl
        '************************************************************************************************

        Const fixedAlignColumnSize As Integer = 100
        'TODO: change to be configurable for every column...
        Const lineWidth As Integer = 1
        'TODO: make this line width configurable
        Public ownerCell As DataGridViewMultiColumnComboCell = Nothing
        '************************************************************************************************

        Public Sub New()
            MyBase.New()
            Me.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.DropDownStyle = ComboBoxStyle.DropDownList
        End Sub
        '************************************************************************************************

        Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
            Dim rec As New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            Dim column As DataGridViewMultiColumnComboColumn = TryCast(ownerCell.OwningColumn, DataGridViewMultiColumnComboColumn)
            Dim valuesTbl As DataTable = TryCast(column.DataSource, DataTable)
            Dim joinByField As String = column.ValueMember
            Dim NormalText As New SolidBrush(System.Drawing.SystemColors.ControlText)

            'If there is an item
            If e.Index > -1 Then
                Dim currentRow As DataRowView = TryCast(Items(e.Index), DataRowView)
                If currentRow IsNot Nothing Then
                    Dim row As DataRow = currentRow.Row

                    Dim currentText As String = GetItemText(Items(e.Index))

                    'first redraw the normal while background
                    Dim normalBack As New SolidBrush(Color.White)
                    'TODO: fix to be system edit box background
                    e.Graphics.FillRectangle(normalBack, rec)
                    If DroppedDown AndAlso Not (Margin.Top = rec.Top) Then
                        Dim currentOffset As Integer = rec.Left

                        Dim HightlightedBack As New SolidBrush(System.Drawing.SystemColors.Highlight)
                        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                            'draw selected color background
                            e.Graphics.FillRectangle(HightlightedBack, rec)
                        End If

                        Dim addBorder As Boolean = False

                        Dim valueItem As Object
                        For Each dataRowItem As Object In row.ItemArray
                            valueItem = dataRowItem
                            Dim value As String = dataRowItem.ToString()
                            'TODO: support for different types!!!
                            If addBorder Then
                                'draw dividing line
                                'currentOffset ++; 
                                Dim gridBrush As New SolidBrush(Color.Gray)
                                'TODO: make the border color configurable
                                Dim linesNum As Long = lineWidth
                                While linesNum > 0
                                    linesNum -= 1
                                    Dim first As New Point(rec.Left + currentOffset, rec.Top)
                                    Dim last As New Point(rec.Left + currentOffset, rec.Bottom)
                                    e.Graphics.DrawLine(New Pen(gridBrush), first, last)
                                    currentOffset += 1
                                End While
                            Else
                                addBorder = True
                            End If

                            Dim extent As SizeF = e.Graphics.MeasureString(value, e.Font)
                            Dim width As Decimal = CDec(extent.Width)
                            'measure the string that we are goin to draw and cut it with wrapping if too large
                            Dim textRec As New Rectangle(currentOffset, rec.Y, CInt(Decimal.Ceiling(width)), rec.Height)

                            'now draw the relevant to this column value text
                            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                                'draw selected
                                Dim HightlightedText As New SolidBrush(System.Drawing.SystemColors.HighlightText)
                                'now redraw the backgrond it order to wrap the previous field if was too large
                                e.Graphics.FillRectangle(HightlightedBack, currentOffset, rec.Y, fixedAlignColumnSize, extent.Height)
                                'draw text as is 
                                e.Graphics.DrawString(value, e.Font, HightlightedText, textRec)
                            Else
                                'now redraw the backgrond it order to wrap the previous field if was too large
                                e.Graphics.FillRectangle(normalBack, currentOffset, rec.Y, fixedAlignColumnSize, extent.Height)
                                'draw text as is 
                                e.Graphics.DrawString(value, e.Font, NormalText, textRec)
                            End If
                            'advance the offset to the next position
                            currentOffset += fixedAlignColumnSize
                        Next
                    Else
                        'if happens when the combo is closed, draw single standard item view
                        e.Graphics.DrawString(currentText, e.Font, NormalText, rec)

                    End If
                End If
            End If
        End Sub
        '************************************************************************************************
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik, @toddanglin
'Facebook: facebook.com/telerik
'=======================================================
