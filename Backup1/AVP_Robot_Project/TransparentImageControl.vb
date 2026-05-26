Public Class TransparentImageControl

#Region "Class Constants & Variables"
    Private m_imgImage As Image
    Private m_isStretch As Boolean = False ''default value - no affect to other relate controls
    Private m_imgSize As System.Drawing.Size = New System.Drawing.Size(140, 140) ''Default size for image
    Private m_strText As String = String.Empty
    Private m_TextColor As Color = Color.Wheat
    Private m_TextLocation As Point = New Point(0, 0)
    Private m_blnISChamberPic As Boolean = False
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Set it is Chamber 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsChamberPic() As Boolean
        Get
            Return m_blnISChamberPic
        End Get
        Set(ByVal value As Boolean)
            m_blnISChamberPic = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Text Location in control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TextLocation() As Point
        Get
            Return m_TextLocation
        End Get
        Set(ByVal value As Point)
            m_TextLocation = value
        End Set
    End Property
    Public Property TextInImage() As String
        Get
            Return m_strText
        End Get
        Set(ByVal value As String)
            If Not (m_strText = value) Then
                m_strText = value
                ' Me.Refresh()
            End If
        End Set
    End Property
    Public Property TextColor() As Color
        Get
            Return m_TextColor
        End Get
        Set(ByVal value As Color)
            m_TextColor = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Get or Set image for this transparent control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Image() As Image
        Get
            Return m_imgImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgImage = value
                Me.Refresh()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-20-04</date>
    ''' </author>
    ''' <summary>
    '''  Set Stretch image for this transparent control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsStretch() As Boolean
        Get
            Return m_isStretch
        End Get
        Set(ByVal value As Boolean)
            Try
                m_isStretch = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-20-04</date>
    ''' </author>
    ''' <summary>
    '''  Set size image for this transparent control
    ''' for chamber 1 and 5: Imagesize = (150, 90)
    ''' for chamber 2 and 4: Imagesize = default
    ''' for chamber 3: Imagesize=(104, 138)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageSize() As System.Drawing.Size
        Get
            Return m_imgSize
        End Get
        Set(ByVal value As System.Drawing.Size)
            Try
                m_imgSize = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

#End Region

#Region "Protected Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Paint image to screen
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            If (m_imgImage IsNot Nothing) Then
                If Me.m_isStretch Then
                    e.Graphics.DrawImage(m_imgImage, New Rectangle(10, 10, ImageSize.Width, ImageSize.Height), New Rectangle(0, 0, m_imgImage.Width, m_imgImage.Height), GraphicsUnit.Pixel)
                Else
                    e.Graphics.DrawImage(Me.Image, 0, 0, m_imgImage.Width, m_imgImage.Height)
                End If
                If String.IsNullOrEmpty(m_strText) = False And Not (IsChamberPic) Then
                    e.Graphics.DrawString(Me.TextInImage, Me.Font, New SolidBrush(TextColor), (m_imgImage.Width / 3) - m_imgImage.Width / 7 + 1, m_imgImage.Width / 3 - m_imgImage.Width / 7 + 3)
                ElseIf String.IsNullOrEmpty(m_strText) = False And IsChamberPic Then
                    e.Graphics.DrawString(Me.TextInImage, Me.Font, New SolidBrush(TextColor), Me.TextLocation.X, Me.TextLocation.Y)
                End If
            End If
           
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
