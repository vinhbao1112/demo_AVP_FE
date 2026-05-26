Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Public Class AVPTabControl
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
    Private Sub AVPTabControl_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        'Firstly we'll define some parameters.
        Dim CurrentTab As TabPage = Me.TabPages(e.Index)
        Dim ItemRect As Rectangle = Me.GetTabRect(e.Index)

        ' ItemRect.Width = CurrentTab.Text.Length

        Dim FillBrush As New Drawing2D.LinearGradientBrush(ItemRect, Color.CornflowerBlue, Color.Gainsboro, Drawing2D.LinearGradientMode.Vertical)
        Dim TextBrush As New Drawing2D.LinearGradientBrush(ItemRect, Color.Gainsboro, Color.WhiteSmoke, Drawing2D.LinearGradientMode.Vertical)
        Dim sf As New StringFormat
        'sf.Alignment = StringAlignment.Center
        'sf.LineAlignment = StringAlignment.Center

        'If we are currently painting the Selected TabItem we'll 
        'change the brush colors and inflate the rectangle.
        If CBool(e.State And DrawItemState.Selected) Then
            TextBrush = New Drawing2D.LinearGradientBrush(ItemRect, Color.CornflowerBlue, Color.Gainsboro, Drawing2D.LinearGradientMode.Vertical)
            FillBrush = New Drawing2D.LinearGradientBrush(ItemRect, Color.Gainsboro, Color.WhiteSmoke, Drawing2D.LinearGradientMode.Vertical)
            ItemRect.Inflate(2, 2)
        End If

        'Set up rotation for left and right aligned tabs
        If Me.Alignment = TabAlignment.Left Or Me.Alignment = TabAlignment.Right Then
            Dim RotateAngle As Single = 90
            If Me.Alignment = TabAlignment.Left Then RotateAngle = 270
            Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
            e.Graphics.TranslateTransform(cp.X, cp.Y)
            e.Graphics.RotateTransform(RotateAngle)
            ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
        End If

        'Next we'll paint the TabItem with our Fill Brush
        e.Graphics.FillPath(FillBrush, GetRoundRect(ItemRect.X, ItemRect.Y, ItemRect.Width, ItemRect.Height, 4))

        'Now draw the text.
        'e.Graphics.DrawString(CurrentTab.Text, e.Font, Brushes.DarkBlue, RectangleF.op_Implicit(ItemRect), sf)
        ItemRect.Width += CurrentTab.Text.Length
        e.Graphics.DrawString(CurrentTab.Text, e.Font, Brushes.DarkBlue, RectangleF.op_Implicit(ItemRect), sf)

        'Reset any Graphics rotation
        e.Graphics.ResetTransform()

        'Finally, we should Dispose of our brushes.
        FillBrush.Dispose()
        TextBrush.Dispose()

    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        MyBase.New()
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Cursor = Cursors.Hand
    End Sub
End Class
