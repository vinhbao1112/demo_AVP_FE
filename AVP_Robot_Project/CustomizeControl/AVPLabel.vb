Public Class AVPLabel

    Private m_iRotateAngle As Integer = 0
    Public Property RotateAngle() As Integer
        Get
            Return m_iRotateAngle
        End Get
        Set(ByVal value As Integer)
            m_iRotateAngle = value
        End Set
    End Property

    Private m_iTranslateTransformX As Integer = 0
    Public Property TranslateTransformX() As Integer
        Get
            Return m_iTranslateTransformX
        End Get
        Set(ByVal value As Integer)
            m_iTranslateTransformX = value
        End Set
    End Property

    Private m_iTranslateTransformY As Integer = 0
    Public Property TranslateTransformY() As Integer
        Get
            Return m_iTranslateTransformY
        End Get
        Set(ByVal value As Integer)
            m_iTranslateTransformY = value
        End Set
    End Property

    Private m_strText_In_Label As String = String.Empty
    Public Property Text_In_Label() As String
        Get
            Return m_strText_In_Label
        End Get
        Set(ByVal value As String)
            m_strText_In_Label = value
        End Set
    End Property

    Private m_isFontStyleDouble As Boolean = False
    Public Property IsFontStyleDouble() As Boolean
        Get
            Return m_isFontStyleDouble
        End Get
        Set(ByVal value As Boolean)
            m_isFontStyleDouble = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Create a new font object to be used by the DrawString method
        Dim NewFont As New Font(Me.Font.Name, Me.Font.Size, IIf(IsFontStyleDouble, FontStyle.Bold Or FontStyle.Italic, FontStyle.Bold), GraphicsUnit.Point)

        ' Get a handle to the graphics object of the label
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        g.TextContrast = 11
        ' Do the transformation
        g.TranslateTransform(TranslateTransformX, TranslateTransformY)
        g.RotateTransform(RotateAngle)

        ' Draw the text
        g.DrawString(m_strText_In_Label, NewFont, New SolidBrush(Me.ForeColor), 0, 0)

        ' Reset the transform so subsequent drawing wont be affected
        g.ResetTransform()
        MyBase.OnPaint(e)

        NewFont.Dispose()
    End Sub
End Class
