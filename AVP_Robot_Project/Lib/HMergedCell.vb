Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Drawing.Drawing2D

Public Class HMergedCell
    Inherits DataGridViewTextBoxCell
#Region "Class Constants & Variables"
    Private m_nLeftColumn As Integer = 0
    Private m_nRightColumn As Integer = 0
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Column Index of the left-most cell to be merged.
    ''' This cell controls the merged text.
    ''' </summary>
    Public Property LeftColumn() As Integer
        Get
            Return m_nLeftColumn
        End Get
        Set(ByVal value As Integer)
            m_nLeftColumn = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Column Index of the right-most cell to be merged
    ''' </summary>
    Public Property RightColumn() As Integer
        Get
            Return m_nRightColumn
        End Get
        Set(ByVal value As Integer)
            m_nRightColumn = value
        End Set
    End Property
#End Region
#Region "Protected Methods"
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Column Index of the left-most cell to be merged.
    ''' This cell controls the merged text.
    ''' </summary>
    Protected Overloads Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal cellState As DataGridViewElementStates, ByVal value As Object, _
     ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
        Try
            Dim mergeindex As Integer = ColumnIndex - m_nLeftColumn
            Dim i As Integer = 0
            Dim nWidth As Integer = 0
            Dim nWidthLeft As Integer = 0
            Dim strText As String = String.Empty

            Dim pen As New Pen(Brushes.Black)

            ' Draw the background
            graphics.FillRectangle(New SolidBrush(SystemColors.Control), cellBounds)

            ' Draw the separator for rows
            graphics.DrawLine(New Pen(New SolidBrush(SystemColors.ControlDark)), cellBounds.Left, cellBounds.Bottom - 1, cellBounds.Right, cellBounds.Bottom - 1)

            ' Draw the right vertical line for the cell
            If ColumnIndex = m_nRightColumn Then
                graphics.DrawLine(New Pen(New SolidBrush(SystemColors.ControlDark)), cellBounds.Right - 1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom)
            End If

            ' Draw the text
            Dim rectDest As RectangleF = RectangleF.Empty
            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Near
            sf.LineAlignment = StringAlignment.Center
            sf.Trimming = StringTrimming.EllipsisCharacter

            ' Determine the total width of the merged cell
            nWidth = 0
            For i = m_nLeftColumn To m_nRightColumn
                nWidth += Me.OwningRow.Cells(i).Size.Width
            Next

            ' Determine the width before the current cell.
            nWidthLeft = 0
            For i = m_nLeftColumn To ColumnIndex - 1
                nWidthLeft += Me.OwningRow.Cells(i).Size.Width
            Next

            ' Retrieve the text to be displayed
            strText = "          " & Me.OwningRow.Cells(m_nLeftColumn).Value.ToString()

            rectDest = New RectangleF(0, cellBounds.Top, nWidth, cellBounds.Height)
            graphics.DrawString(strText, New Font("Arial", 10, FontStyle.Regular), Brushes.DarkBlue, rectDest, sf)
        Catch ex As Exception
            Trace.WriteLine(ex.ToString())
        End Try
    End Sub
#End Region
End Class
' class



