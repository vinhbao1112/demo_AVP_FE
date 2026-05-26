Imports AVPControls

Public Class ImageBinaryStatusControl
#Region "Class Constants & Variables"
    Private m_imgOnImage As Image
    Private m_imgOffImage As Image
    Private m_imgUnknownImage As Image
    Protected m_strText As String = String.Empty
    Private m_ColorOn As Color
    Private m_ColorOff As Color
    Private m_ColorUnknown As Color
    Private m_TextLocIsFix As Boolean = True
    Private m_TextLoc As Point = New Point(0, 0)
    Public ParentStatusObj As StatusObject = Nothing
    Private m_TypeOfChamberSupport As TypeOfAVPChamber = TypeOfAVPChamber.IBE
    Public Event StatusChange(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2010-05-19</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Color and Text of CG in Rough Pump Control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TextLocation() As Point
        Get
            Return m_TextLoc
        End Get
        Set(ByVal value As Point)
            m_TextLoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2010-05-19</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Color and Text of CG in Rough Pump Control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TextLocIsFix() As Boolean
        Get
            Return m_TextLocIsFix
        End Get
        Set(ByVal value As Boolean)
            m_TextLocIsFix = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2010-05-19</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Color and Text of CG in Rough Pump Control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OnState_ColorText() As Color
        Get
            Return m_ColorOn
        End Get
        Set(ByVal value As Color)
            m_ColorOn = value
        End Set
    End Property
    Public Property OffState_ColorText() As Color
        Get
            Return m_ColorOff
        End Get
        Set(ByVal value As Color)
            m_ColorOff = value
        End Set
    End Property
    Public Property UnknownState_ColorText() As Color
        Get
            Return m_ColorUnknown
        End Get
        Set(ByVal value As Color)
            m_ColorUnknown = value
        End Set
    End Property
    Public Overridable Property TextValue() As String
        Get
            Return m_strText
        End Get
        Set(ByVal value As String)
            m_strText = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
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
                If value IsNot Nothing Then
                    m_imgOnImage = value
                    Me.Size = m_imgOnImage.Size
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
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
                If value IsNot Nothing Then
                    m_imgOffImage = value
                    Me.Size = m_imgOffImage.Size
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    Public Property UnknownImage() As Image
        Get
            Return m_imgUnknownImage
        End Get
        Set(ByVal value As Image)
            Try
                If value IsNot Nothing Then
                    m_imgUnknownImage = value
                    Me.Size = m_imgUnknownImage.Size
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    Public Property TypeOfChamberSupport() As TypeOfAVPChamber
        Get
            Return m_TypeOfChamberSupport
        End Get
        Set(ByVal value As TypeOfAVPChamber)
            m_TypeOfChamberSupport = value
        End Set
    End Property

    Public Overrides Property Status() As DisplayStatus
        Get
            Return MyBase.Status
        End Get
        Set(ByVal value As DisplayStatus)
            Try
                MyBase.Status = value
                RaiseEvent StatusChange(Me, Nothing)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

        End Set
    End Property

#End Region

#Region "Protected Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
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
                    e.Graphics.DrawImage(m_imgOffImage, 0, 0, m_imgOffImage.Width, m_imgOffImage.Height)
                End If
            ElseIf (MyBase.Status = DisplayStatus.On) Then
                If (m_imgOnImage IsNot Nothing) Then
                    e.Graphics.DrawImage(m_imgOnImage, 0, 0, m_imgOnImage.Width, m_imgOnImage.Height)
                End If
            Else
                If (m_imgUnknownImage IsNot Nothing) Then
                    e.Graphics.DrawImage(m_imgUnknownImage, 0, 0, m_imgUnknownImage.Width, m_imgUnknownImage.Height)
                End If
            End If
            If String.IsNullOrEmpty(Me.TextValue) = False And Me.TextLocIsFix Then
                'draw string for CG in RoughPump on Cassettes Panel
                e.Graphics.DrawString(TextValue, Me.Font, New System.Drawing.SolidBrush(Color.DarkBlue), Me.Width / 2 - 35, Me.Height / 3 + 8)
            ElseIf String.IsNullOrEmpty(Me.TextValue) = False Then
                Try
                    Dim color As Color
                    If TextValue = AVPLib.ConstEnum.STR_ERROR Then
                        color = Drawing.Color.Red
                    ElseIf MyBase.Status = DisplayStatus.Off Then
                        color = OffState_ColorText
                    ElseIf MyBase.Status = DisplayStatus.On Then
                        color = OnState_ColorText
                    ElseIf MyBase.Status = DisplayStatus.Unknown Then
                        color = UnknownState_ColorText
                    End If

                    e.Graphics.DrawString(TextValue, Me.Font, New System.Drawing.SolidBrush(color), Me.TextLocation)
                Catch ex As Exception
                    e.Graphics.DrawString(TextValue, Me.Font, New System.Drawing.SolidBrush(Color.DarkBlue), Me.TextLocation)
                End Try
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
        Me.SetStyle(ControlStyles.Opaque, False)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
