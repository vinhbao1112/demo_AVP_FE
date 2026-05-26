Imports System.ComponentModel
Imports System.Windows.Forms
Imports AVPControls.AVPDataLib
Imports AVPControls.AVPGraphicsLib

<DefaultEvent("Click")> _
Public Class AVPStatusButton
    Inherits AVPStatusControlBase
    Public Shared DEFAULT_BUTTON_WIDTH As Integer = 120
    Public Shared DEFAULT_BUTTON_HEIGHT As Integer = 28
    Private Const MIN_BOUND_WIDTH As Integer = 32
    Private Const EDGE_MARGIN As Integer = 5

    Protected m_buttonSize As Size = New Size(DEFAULT_BUTTON_WIDTH, DEFAULT_BUTTON_HEIGHT)
    Protected m_isPressDown As Boolean
    Protected m_text As String
    Protected m_textAlign As ContentAlignment = ContentAlignment.MiddleCenter
    Protected m_image As Bitmap
    Protected m_imageAlign As ContentAlignment = ContentAlignment.MiddleLeft
    Protected m_textImageRelation As TextImageRelation = TextImageRelation.Overlay
    Private m_textBound As Rectangle
    Private m_imageBound As Rectangle
    Private m_textLines() As String

    ''' <summary>
    ''' Occurs when the text of this button changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shadows Event TextChanged As EventHandler


#Region "Properties"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets the text of button control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), ""), Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Overrides Property Text() As String
        Get
            Return m_text
        End Get
        Set(ByVal value As String)
            If m_text <> value Then
                m_text = value
                SetTextAndImageBounds()
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets the alignment of the text on the button control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(ContentAlignment), "MiddleCenter"), Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property TextAlign() As ContentAlignment
        Get
            Return m_textAlign
        End Get
        Set(ByVal value As ContentAlignment)
            If m_textAlign <> value Then
                m_textAlign = value
                SetTextAndImageBounds()
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets the image that is displayed on a button control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Bitmap), "Nothing")> _
    Public Property Image() As Bitmap
        Get
            Return m_image
        End Get
        Set(ByVal value As Bitmap)
            m_image = value
            SetTextAndImageBounds()
            UpdateView()
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets the alignment of the image on the button control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(ContentAlignment), "MiddleLeft")> _
    Public Property ImageAlign() As ContentAlignment
        Get
            Return m_imageAlign
        End Get
        Set(ByVal value As ContentAlignment)
            If m_imageAlign <> value Then
                m_imageAlign = value
                SetTextAndImageBounds()
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets the position of text and image relative to each other.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TextImageRelation() As TextImageRelation
        Get
            Return m_textImageRelation
        End Get
        Set(ByVal value As TextImageRelation)
            If m_textImageRelation <> value Then
                m_textImageRelation = value
                SetTextAndImageBounds()
                UpdateView()
            End If
        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Draw button image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Dim img As Bitmap = New Bitmap(m_buttonSize.Width, m_buttonSize.Height)
        img.SetResolution(96, 96)
        Try
            Using g As Graphics = Graphics.FromImage(img)
                Dim brush As SolidBrush = New SolidBrush(Me.BackColor)
                g.FillRectangle(brush, 0, 0, img.Width, img.Height)

                If m_isPressDown OrElse Not Me.Enabled Then
                    AVPGraphicsLib.DrawBorderDown(g)
                Else
                    AVPGraphicsLib.DrawBorder3D(g)
                End If

                ' Draw image
                DrawImage(g)

                ' Draw text
                DrawText(g)
            End Using
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        Return img
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Draw image of the button control.
    ''' </summary>
    ''' <param name="g"></param>
    ''' <remarks></remarks>
    Private Sub DrawImage(ByRef g As Graphics)
        If Me.m_image IsNot Nothing Then
            Dim w As Single
            Dim h As Single
            If Me.m_image.Width <= Me.m_imageBound.Width AndAlso Me.m_image.Height <= Me.m_imageBound.Height Then
                w = Me.m_image.Width
                h = Me.m_image.Height
            ElseIf Me.m_image.Width > Me.m_imageBound.Width AndAlso Me.m_image.Height > Me.m_imageBound.Height Then
                w = Me.m_imageBound.Width
                h = Me.m_image.Height * (w / Me.m_image.Width)
                If w > Me.m_imageBound.Width AndAlso h > Me.m_imageBound.Height Then
                    h = Me.m_imageBound.Height
                    w = Me.m_image.Width * (h / Me.m_image.Height)
                End If
            ElseIf Me.m_image.Width > Me.m_imageBound.Width Then
                w = Me.m_imageBound.Width
                h = Me.m_image.Height * (w / Me.m_image.Width)
            Else
                h = Me.m_imageBound.Height
                w = Me.m_image.Width * (h / Me.m_image.Height)
            End If

            Dim imageLocation As PointF = GetLocationForDraw(m_imageAlign, m_imageBound, w, h)
            g.DrawImage(m_image, imageLocation.X, imageLocation.Y, w, h)

        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Draw text of the button control.
    ''' </summary>
    ''' <param name="g"></param>
    ''' <remarks></remarks>
    Private Sub DrawText(ByRef g As Graphics)
        If Not String.IsNullOrEmpty(Me.m_text) Then
            Dim strFormat As StringFormat = New StringFormat(StringFormatFlags.DisplayFormatControl)
            strFormat.LineAlignment = StringAlignment.Center
            strFormat.Alignment = StringAlignment.Center

            Dim charsFitted As Integer
            Dim linesFilled As Integer
            Dim size As SizeF = g.MeasureString(Me.m_text, Me.Font, New SizeF(Me.m_textBound.Width, Me.m_textBound.Height), strFormat, charsFitted, linesFilled)
            Dim textLocation As PointF = GetLocationForDraw(m_textAlign, m_textBound, size.Width, size.Height)
            Dim color As Color = Me.ForeColor
            If Not Me.Enabled Then
                color = Drawing.Color.DimGray
            End If

            For index As Integer = 0 To linesFilled - 1
                Dim startIndex As Integer = Convert.ToInt32((m_text.Length / linesFilled) * index)

                Dim length As Integer = Convert.ToInt32(m_text.Length / linesFilled)
                If startIndex + length > m_text.Length Then
                    length = m_text.Length - startIndex
                End If
                Dim text As String = m_text.Substring(startIndex, length)
                g.DrawString(text, Me.Font, New SolidBrush(color), textLocation.X, textLocation.Y + index * (Me.Font.Size + 5))
            Next
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Gets lines of text to fitted in this control.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFittedText() As String()
        Dim linesText() As String = Nothing



        Return linesText
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Set bound of text and image on this button control.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTextAndImageBounds()
        If Me.m_image IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.m_text) Then
            Select Case Me.m_textImageRelation
                Case Windows.Forms.TextImageRelation.Overlay
                    m_textBound = New Rectangle(0, 0, Me.m_buttonSize.Width, Me.m_buttonSize.Height)
                    m_imageBound = New Rectangle(0, 0, Me.m_buttonSize.Width, Me.m_buttonSize.Height)
                Case Windows.Forms.TextImageRelation.ImageBeforeText
                    m_imageBound = New Rectangle(0, 0, MIN_BOUND_WIDTH, Me.m_buttonSize.Height)
                    m_textBound = New Rectangle(MIN_BOUND_WIDTH, 0, Me.m_buttonSize.Width - MIN_BOUND_WIDTH, Me.m_buttonSize.Height)
                Case Windows.Forms.TextImageRelation.TextBeforeImage
                    m_textBound = New Rectangle(0, 0, Me.m_buttonSize.Width - MIN_BOUND_WIDTH, Me.m_buttonSize.Height)
                    m_imageBound = New Rectangle(Me.m_buttonSize.Width - MIN_BOUND_WIDTH, 0, MIN_BOUND_WIDTH, Me.m_buttonSize.Height)
                Case Windows.Forms.TextImageRelation.ImageAboveText
                    Dim h As Integer = Convert.ToInt32(Me.m_buttonSize.Height / 2)
                    m_imageBound = New Rectangle(0, 0, Me.m_buttonSize.Width, h)
                    m_textBound = New Rectangle(0, h, Me.m_buttonSize.Width, h)
                Case Windows.Forms.TextImageRelation.TextAboveImage
                    Dim h As Integer = Convert.ToInt32(Me.m_buttonSize.Height / 2)
                    m_textBound = New Rectangle(0, 0, Me.m_buttonSize.Width, h)
                    m_imageBound = New Rectangle(0, h, Me.m_buttonSize.Width, h)
            End Select
        ElseIf Me.m_image Is Nothing Then
            m_imageBound = Nothing
            m_textBound = New Rectangle(0, 0, Me.m_buttonSize.Width, Me.m_buttonSize.Height)
        Else
            m_textBound = Nothing
            m_imageBound = New Rectangle(0, 0, Me.m_buttonSize.Width, Me.m_buttonSize.Height)
        End If

    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Gets location for draw image and text.
    ''' </summary>
    ''' <param name="alignment"></param>
    ''' <param name="bound"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetLocationForDraw(ByVal alignment As ContentAlignment, ByVal bound As Rectangle, ByVal width As Single, ByVal height As Single) As PointF
        Dim result As PointF
        Dim x As Single
        Dim y As Single
        Select Case alignment
            Case ContentAlignment.TopLeft
                x = EDGE_MARGIN
                y = EDGE_MARGIN
            Case ContentAlignment.MiddleLeft
                x = EDGE_MARGIN
                y = (bound.Height - height) / 2
            Case ContentAlignment.BottomLeft
                x = EDGE_MARGIN
                y = bound.Height - height - EDGE_MARGIN
            Case ContentAlignment.TopCenter
                x = (bound.Width - width) / 2
                y = EDGE_MARGIN
            Case ContentAlignment.MiddleCenter
                x = (bound.Width - width) / 2
                y = (bound.Height - height) / 2
            Case ContentAlignment.BottomCenter
                x = (bound.Width - width) / 2
                y = bound.Height - height - EDGE_MARGIN
            Case ContentAlignment.TopRight
                x = bound.Width - width - EDGE_MARGIN
                y = EDGE_MARGIN
            Case ContentAlignment.MiddleRight
                x = bound.Width - width - EDGE_MARGIN
                y = (bound.Height - height) / 2
            Case ContentAlignment.BottomRight
                x = bound.Width - width - EDGE_MARGIN
                y = bound.Height - height - EDGE_MARGIN
        End Select

        If m_isPressDown Then
            result = New PointF(bound.X + x, bound.Y + y + 1)
        Else
            result = New PointF(bound.X + x, bound.Y + y)
        End If

        Return result
    End Function
#End Region

#Region "Events"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Update image of control when back color changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPStatusButton_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackColorChanged
        Me.UpdateView()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Update image of control when control enable changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPStatusButton_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        Me.UpdateView()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Update image of control when font changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPStatusButton_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged
        Me.UpdateView()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Update image of control when fore color changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPStatusButton_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged
        Me.UpdateView()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Update bound of text on control when load.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPStatusButton_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetTextAndImageBounds()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Update down state image.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPStatusButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        m_isPressDown = True
        Me.UpdateView()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Update normal state image.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPStatusButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        m_isPressDown = False
        Me.UpdateView()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Restore size of control when rotation mode changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPStatusButton_RotationModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.RotationModeChanged
        If Me.RotationMode = AVPControls.AVPDataLib.AVPControlStyleModes.None Then
            Me.Size = m_buttonSize
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Size of button as the same with control size and do not allow change size when tranform mode not equal None.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPStatusButton_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Me.RotationMode = AVPControls.AVPDataLib.AVPControlStyleModes.None AndAlso Me.ScaleMode = AVPControls.AVPDataLib.AVPControlStyleModes.None Then
            m_buttonSize = New Size(Me.Width, Me.Height)
            SetTextAndImageBounds()
            Me.UpdateView()
        Else
            If Me.ControlImage IsNot Nothing Then
                Me.Size = Me.ControlImage.Size
            End If
        End If
    End Sub

#End Region

    Public Sub New()
        Me.DoubleBuffered = True

        Me.SuspendLayout()
        Me.ScaleMode = AVPControlStyleModes.None
        Me.RotationMode = AVPControlStyleModes.None

        Me.Width = DEFAULT_BUTTON_WIDTH
        Me.Height = DEFAULT_BUTTON_HEIGHT
        Me.BackgroundImageLayout = ImageLayout.None
        Me.Cursor = Cursors.Hand

        Me.ResumeLayout()
    End Sub
End Class
