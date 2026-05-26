Public Class CoronaWafer
    Inherits FiveStateControl

    Protected Overrides Sub Control_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        Dim string_format As New StringFormat
        string_format.Alignment = StringAlignment.Center
        string_format.LineAlignment = StringAlignment.Center
        string_format.FormatFlags = StringFormatFlags.DirectionRightToLeft
        If Me.Status = DisplayStatus.On Then
            g.DrawImage(m_imgOnImage, 0, 0, Me.Width, Me.Height)
            g.DrawString(Me.Text, Me.Font, New SolidBrush(ColorText_OnStatus), Me.m_TextLocation.X, Me.m_TextLocation.Y, string_format)
        ElseIf Me.Status = DisplayStatus.Off Then
            g.DrawImage(m_imgOffImage, 0, 0, Me.Width, Me.Height)
            g.DrawString(Me.Text, Me.Font, New SolidBrush(ColorText_OffStatus), Me.m_TextLocation.X, Me.m_TextLocation.Y, string_format)
        ElseIf Me.Status = DisplayStatus.Unknow Then
            g.DrawImage(m_imgUnknowImage, 0, 0, Me.Width, Me.Height)
            g.DrawString(Me.Text, Me.Font, New SolidBrush(ColorText_UnknowStatus), Me.m_TextLocation.X, Me.m_TextLocation.Y, string_format)
        ElseIf Me.Status = DisplayStatus.Error Then
            g.DrawImage(m_imgErrorImage, 0, 0, Me.Width, Me.Height)
            g.DrawString(Me.Text, Me.Font, New SolidBrush(ColorText_ErrorStatus), Me.m_TextLocation.X, Me.m_TextLocation.Y, string_format)
        ElseIf Me.Status = DisplayStatus.None Then
            g.DrawImage(m_imgNoneImage, 0, 0, Me.Width, Me.Height - 2)
        End If
    End Sub
End Class
