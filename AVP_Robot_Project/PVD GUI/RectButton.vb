Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class RectButton
    Inherits Button
    Private m_Top_Color As Color = Color.RoyalBlue
    Private m_Bottom_Color As Color = Color.WhiteSmoke
    Private m_TextColor As Color = Color.Black
    Private m_BorderColor As Color = Color.Black
    ' default values
    Private m_blnActive As Boolean = Me.Enabled
    Private m_State As _States = _States.Normal

    Private Enum _States
        Normal
        MouseOver
        Clicked
    End Enum

    Public Property Top_Color() As Color
        Get
            Return m_Top_Color
        End Get
        Set(ByVal value As Color)
            m_Top_Color = value
            Me.Invalidate()
        End Set
    End Property

    Public Property Bottom_Color() As Color
        Get
            Return m_Bottom_Color
        End Get
        Set(ByVal value As Color)
            m_Bottom_Color = value
            Me.Invalidate()
        End Set
    End Property

    Public Property TextColor() As Color
        Get
            Return m_TextColor
        End Get
        Set(ByVal value As Color)
            m_TextColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderColor() As Color
        Get
            Return m_BorderColor
        End Get
        Set(ByVal value As Color)
            m_BorderColor = value
            Me.Invalidate()
        End Set
    End Property

    'Set the styles so we can control the painting
    Public Sub New()
        InitializeComponent()
        Me.Cursor = Cursors.Hand
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or _
                    ControlStyles.UserPaint Or _
                    ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    'Paint the button
    Protected Overrides Sub OnPaint(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        Dim brush As LinearGradientBrush
        Dim mode As LinearGradientMode = LinearGradientMode.Vertical
        'First set the region
        If Me.Region Is Nothing Then
            'setRegion()
        End If

        'Get the points that correspond to our hex shape
        'These are the same points used to create the region

        brush = New LinearGradientBrush(Me.ClientRectangle, m_Top_Color, m_Bottom_Color, mode)
        'Create a GraphicsPath
        Dim sf As New StringFormat

        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        sf.Trimming = StringTrimming.Word

        Dim rc As New RectangleConverter
        Dim brushText As New System.Drawing.SolidBrush(TextColor)
        Dim fontNormal As New Font(Me.Font.FontFamily, Me.Font.Size)
        Dim fontBold As New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)

        If m_blnActive Then
            Select Case m_State
                Case _States.Normal
                    'Draw the background of the button
                    pevent.Graphics.DrawPath(New Pen(BorderColor, 2), Me.GetRoundRect(Me.ClientRectangle.X, Me.ClientRectangle.Y, Me.ClientRectangle.Width, Me.ClientRectangle.Height, 5))
                    pevent.Graphics.FillPath(brush, Me.GetRoundRect(Me.ClientRectangle.X + 1, Me.ClientRectangle.Y + 1, Me.ClientRectangle.Width - 2, Me.ClientRectangle.Height - 2, 5))
                    'Draw the text for the button  
                    pevent.Graphics.DrawString(Me.Text, fontNormal, brushText, Me.ClientRectangle, sf)
                Case _States.MouseOver
                    'Draw the background of the button
                    pevent.Graphics.DrawPath(New Pen(BorderColor, 2), Me.GetRoundRect(Me.ClientRectangle.X, Me.ClientRectangle.Y, Me.ClientRectangle.Width, Me.ClientRectangle.Height, 5))
                    pevent.Graphics.FillPath(brush, Me.GetRoundRect(Me.ClientRectangle.X + 1, Me.ClientRectangle.Y + 1, Me.ClientRectangle.Width - 2, Me.ClientRectangle.Height - 2, 5))
                    'Draw the text for the button  
                    pevent.Graphics.DrawString(Me.Text, fontBold, brushText, Me.ClientRectangle, sf)
                Case _States.Clicked
                    'Draw the background of the button
                    pevent.Graphics.DrawPath(New Pen(BorderColor, 2), Me.GetRoundRect(Me.ClientRectangle.X, Me.ClientRectangle.Y, Me.ClientRectangle.Width, Me.ClientRectangle.Height, 5))
                    pevent.Graphics.FillPath(brush, Me.GetRoundRect(Me.ClientRectangle.X + 1, Me.ClientRectangle.Y + 1, Me.ClientRectangle.Width - 2, Me.ClientRectangle.Height - 2, 5))

                    'Draw the text for the button  
                    pevent.Graphics.DrawString(Me.Text, fontNormal, brushText, Me.ClientRectangle, sf)
            End Select
        Else
            pevent.Graphics.DrawPath(New Pen(BorderColor, 2), Me.GetRoundRect(Me.ClientRectangle.X, Me.ClientRectangle.Y, Me.ClientRectangle.Width, Me.ClientRectangle.Height, 5))
            pevent.Graphics.FillPath(brush, Me.GetRoundRect(Me.ClientRectangle.X + 1, Me.ClientRectangle.Y + 1, Me.ClientRectangle.Width - 2, Me.ClientRectangle.Height - 2, 5))
            'Draw the text for the button  
            pevent.Graphics.DrawString(Me.Text, fontNormal, brushText, Me.ClientRectangle, sf)
        End If

    End Sub

    'When the button is resized, it makes sure the button is a square in shape and sets the new region
    Protected Overrides Sub onresize(ByVal e As System.EventArgs)
        setRegion()
    End Sub

    'Sets the button's region. Disposing of any existing region
    Private Sub setRegion()

        'Get the button's current region, if any
        Dim tmpRegion As Region = Me.Region

        'Set the button's new region
        Me.Region = getRegion()

        'Dispose of the old region
        If tmpRegion IsNot Nothing Then
            tmpRegion.Dispose()
        End If
    End Sub

    'Creates a Region object from a GraphicsPath
    Private Function getRegion() As Region
        Dim rgn As Region = Nothing

        Using gp As GraphicsPath = GetRoundRect(0, 0, Me.Width, Me.Height, 5)
            rgn = New Region(gp)
        End Using

        Return rgn
    End Function

    Private Function getRegion(ByVal gp As GraphicsPath) As Region
        Return New Region(gp)
    End Function

    Public Function GetRoundRect(ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single, _
ByVal radius As Single) As GraphicsPath
        Dim gp As New GraphicsPath()
        gp.AddLine(x + radius, y, x + width - (radius * 2), y)
        ' Line
        gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90)
        ' Corner
        gp.AddLine(x + width, y + radius, x + width, y + height)
        ' Line
        gp.AddLine(x + width, y + height, x + radius, y + height)
        ' Corner
        gp.AddLine(x, y + height, x, y + radius)
        ' Line
        gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
        ' Corner
        gp.CloseFigure()
        Return gp
    End Function
    Protected Overloads Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        If m_blnActive Then
            m_State = _States.Normal
            Me.Invalidate()
            MyBase.OnMouseLeave(e)
        End If
    End Sub

    Protected Overloads Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        If m_blnActive Then
            m_State = _States.MouseOver
            Me.Invalidate()
            MyBase.OnMouseEnter(e)
        End If
    End Sub

    Protected Overloads Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If m_blnActive Then
            m_State = _States.MouseOver
            Me.Invalidate()
            MyBase.OnMouseUp(e)
        End If
    End Sub

    Protected Overloads Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If m_blnActive Then
            m_State = _States.Clicked
            Me.Invalidate()
            MyBase.OnMouseDown(e)
        End If
    End Sub

End Class
