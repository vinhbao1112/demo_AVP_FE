Public Class QuestionMarkControl
    Private m_strPausedJobId As String = String.Empty

#Region "Protected Properties"
    Public Property PausedJobID() As String
        Get
            Return m_strPausedJobId
        End Get
        Set(ByVal value As String)
            m_strPausedJobId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' CreateParams overrides property of base class to support transparent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 32
            Return cp
        End Get
    End Property
#End Region

#Region "Protected Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Don't paint background, only draw background image
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            If (Me.BackgroundImage IsNot Nothing) Then
                e.Graphics.DrawImage(Me.BackgroundImage, 0, 0, Me.BackgroundImage.Width, Me.BackgroundImage.Height)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-08-05 </date>
    ''' </author>
    ''' <summary>
    ''' Overrides paint event
    ''' </summary>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            If Not IsChamberPic Then
                If IsStretch Then
                    e.Graphics.DrawImage(Image, 0, 0, Me.Width, Me.Height)
                Else
                    e.Graphics.DrawImage(Image, 0, 0, ImageSize.Width, ImageSize.Height)
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
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.Opaque, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
