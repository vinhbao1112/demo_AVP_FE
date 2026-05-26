Public Class ScreenMachine
#Region "Class Constants & Variables"
    Private m_imgOnImage As Image
    Private m_imgOffImage As Image
    Private m_imgUnknowImage As Image
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
            Me.LoadDefaultValvePicture()
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
    Public Property OnImage() As Image
        Get
            Return m_imgOnImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgOnImage = value
                Me.Size = m_imgOnImage.Size
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
    Public Property OffImage() As Image
        Get
            Return m_imgOffImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgOffImage = value
                Me.Size = m_imgOffImage.Size
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
    Public Property UnknowImage() As Image
        Get
            Return m_imgUnknowImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgUnknowImage = value
                Me.Size = m_imgUnknowImage.Size
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
#End Region

#Region "Private Methods"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Load valve picture
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadDefaultValvePicture()
        Try
            ' Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValveControl))
            'MyBase.OnImage = CType(resources.GetObject("GreenValve"), Image)
            'MyBase.OffImage = CType(resources.GetObject("RedValve"), Image)
          
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
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
            If (MyBase.Status = DisplayStatus.Off) Then
                If (m_imgOffImage IsNot Nothing) Then
                    Me.Size = m_imgOffImage.Size ''black 
                    e.Graphics.DrawImage(m_imgOffImage, 0, 0, m_imgOffImage.Width, m_imgOffImage.Height)
                End If
            ElseIf (MyBase.Status = DisplayStatus.On) Then
                If (m_imgUnknowImage IsNot Nothing) Then
                    Me.Size = m_imgUnknowImage.Size + m_imgUnknowImage.Size ''transparent
                    e.Graphics.DrawImage(m_imgUnknowImage, 0, 0, m_imgUnknowImage.Width, m_imgUnknowImage.Height)
                End If
            Else
                If (m_imgOnImage IsNot Nothing) Then
                    Me.Size = m_imgOnImage.Size + m_imgOnImage.Size ''yellow
                    e.Graphics.DrawImage(m_imgOnImage, 0, 0, m_imgOnImage.Width, m_imgOnImage.Height)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
End Class
