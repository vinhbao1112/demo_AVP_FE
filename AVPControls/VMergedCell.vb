Public Class VMergedCell
    Inherits DataGridViewTextBoxCell

    Public Const STR_INACTIVE As String = "INACTIVE"
    Private m_AboveRow As Integer = 0
    Private m_BelowRow As Integer = 0

    Public Property AboveRow() As Integer
        Get
            Return m_AboveRow
        End Get
        Set(ByVal value As Integer)
            m_AboveRow = value
        End Set
    End Property

    Public Property BelowRow() As Integer
        Get
            Return m_BelowRow
        End Get
        Set(ByVal value As Integer)
            m_BelowRow = value
        End Set
    End Property

    ''' <author>
    '''     <name>Dy Do</name>
    '''     <date>2018-08-23</date>
    ''' </author>
    ''' <summary>
    '''  First Column Index of the Row-most cell to be merged
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal cellState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
        Try
            Dim i As Integer = 0
            Dim nHeight As Integer = 0
            Dim strText As String = String.Empty
            Dim rectDest As Rectangle = Rectangle.Empty
            Dim sf As StringFormat = New StringFormat()
            sf.Alignment = StringAlignment.Near
            sf.LineAlignment = StringAlignment.Center
            sf.Trimming = StringTrimming.EllipsisCharacter
            For i = m_AboveRow To m_BelowRow - 1
                nHeight += Me.OwningRow.Cells(0).Size.Height
            Next
            rectDest = New Rectangle(cellBounds.X, cellBounds.Y - (cellBounds.Height * (rowIndex - m_AboveRow)), cellBounds.Width, nHeight)
            graphics.FillRectangle(New SolidBrush(Color.White), rectDest)
            strText = "     " + Me.OwningRow.Cells(0).Value.ToString()
            If strText.Contains(STR_INACTIVE) Then
                graphics.DrawImage(My.Resources.Resources.Sensor_Error_Border, rectDest.X + 5, rectDest.Y + rectDest.Height / 2.0F - 7, 13, 13)
            Else
                graphics.DrawImage(My.Resources.Resources.Sensor_On_Border, rectDest.X + 5, rectDest.Y + rectDest.Height / 2.0F - 7, 13, 13)
            End If
            Dim str_MacID As String() = strText.Split("-")
            graphics.DrawString(str_MacID(0), New Font("Arial", 13, FontStyle.Regular), Brushes.Black, rectDest, sf)
            ControlPaint.DrawBorder(graphics, rectDest, Color.FromArgb(160, 160, 160), 0, ButtonBorderStyle.Solid, Color.FromArgb(160, 160, 160), 0, ButtonBorderStyle.Solid, Color.FromArgb(160, 160, 160), 1, ButtonBorderStyle.Solid, Color.FromArgb(160, 160, 160), 1, ButtonBorderStyle.Solid)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub
End Class


