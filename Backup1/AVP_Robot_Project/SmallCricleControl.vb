Public Class SmallCircleControl
#Region "Class Constants & Variables"
    Private m_imgDefaultImage As Image
    Private m_imgHomeImage As Image
    Private m_imgErrorImage As Image
    Private m_imgMovingImage As Image
#End Region
#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Create defaulf valve
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
#Region "Properties"
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Get or set image of On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DefaultImage() As Image
        Get
            Return m_imgDefaultImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgDefaultImage = value
                Me.Size = m_imgDefaultImage.Size
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Get or set image of Off Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HomeImage() As Image
        Get
            Return m_imgHomeImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgHomeImage = value
                Me.Size = m_imgHomeImage.Size
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Get or set image of Off Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MovingImage() As Image
        Get
            Return m_imgMovingImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgMovingImage = value
                Me.Size = m_imgMovingImage.Size
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Get or set image of Off Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ErrorImage() As Image
        Get
            Return m_imgErrorImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgErrorImage = value
                Me.Size = m_imgErrorImage.Size
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
#End Region

#Region "Private Methods"
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Paint image to screen
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            If (MyBase.Status = DisplayStatus.Default) Then
                If (m_imgDefaultImage IsNot Nothing) Then
                    Me.Size = m_imgDefaultImage.Size ''black 
                    e.Graphics.DrawImage(m_imgDefaultImage, 0, 0, m_imgDefaultImage.Width, m_imgDefaultImage.Height)
                End If
            ElseIf (MyBase.Status = DisplayStatus.Home) Then
                If (m_imgHomeImage IsNot Nothing) Then
                    Me.Size = m_imgHomeImage.Size + m_imgHomeImage.Size ''transparent
                    e.Graphics.DrawImage(m_imgHomeImage, 0, 0, m_imgHomeImage.Width, m_imgHomeImage.Height)
                End If
            ElseIf (MyBase.Status = DisplayStatus.Moving) Then
                If (m_imgMovingImage IsNot Nothing) Then
                    Me.Size = m_imgMovingImage.Size + m_imgMovingImage.Size ''transparent
                    e.Graphics.DrawImage(m_imgMovingImage, 0, 0, m_imgMovingImage.Width, m_imgMovingImage.Height)
                End If
            Else
                If (m_imgErrorImage IsNot Nothing) Then
                    Me.Size = m_imgErrorImage.Size + m_imgErrorImage.Size ''yellow
                    e.Graphics.DrawImage(m_imgErrorImage, 0, 0, m_imgErrorImage.Width, m_imgErrorImage.Height)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
End Class
