Imports System.ComponentModel

Public Class FlashingLabel
#Region "Constructor"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Visible = False
        m_timer = New System.Timers.Timer
        m_timer.Interval = m_iInterval
        m_timer.Enabled = False
        m_timer.SynchronizingObject = Me
        AddHandler m_timer.Elapsed, AddressOf FlashingLabel
        ' Add any initialization after the InitializeComponent() call.
    End Sub
#End Region

#Region "Properties and Variables"
    Private m_timer As System.Timers.Timer
    Private m_externalTimer As System.Timers.Timer
    Private m_isFlashing As Boolean
    Private m_iInterval As Integer = 100
    Private m_blnFlashLabel As Boolean
    Private m_color1 As Color = Color.Yellow
    Private m_color2 As Color = Color.Yellow

    <DefaultValue(100)> _
    Public Property FlashingInterval() As Integer
        Get
            Return m_iInterval
        End Get
        Set(ByVal value As Integer)
            m_iInterval = value
        End Set
    End Property

    Public Property Color1() As Color
        Get
            Return m_color1
        End Get
        Set(ByVal value As Color)
            m_color1 = value
        End Set
    End Property

    Public Property Color2() As Color
        Get
            Return m_color2
        End Get
        Set(ByVal value As Color)
            m_color2 = value
        End Set
    End Property

    <DefaultValue(False)> _
    Private Property FlashLabel() As Boolean
        Get
            Return m_blnFlashLabel
        End Get
        Set(ByVal value As Boolean)
            m_blnFlashLabel = value
            If m_blnFlashLabel Then
                Me.ForeColor = Color1
            Else
                Me.ForeColor = Color2
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2019-05-10</date>
    ''' <summary>
    ''' Gets or sets external timer.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DefaultValue(GetType(System.Timers.Timer), "Nothing")> _
    Public Property ExternalTimer() As System.Timers.Timer
        Get
            Return m_externalTimer
        End Get
        Set(ByVal value As System.Timers.Timer)
            RemoveTimerEvent(m_externalTimer)

            m_externalTimer = value

            If value IsNot Nothing Then
                m_timer.Enabled = False
            End If
        End Set
    End Property

#End Region

#Region "Sub and Methods"
    Private Sub FlashingLabel(ByVal source As Object, ByVal e As Timers.ElapsedEventArgs)
        Try
            FlashLabel = Not FlashLabel
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub StartFlashing()
        If m_externalTimer IsNot Nothing Then
            If Not m_isFlashing Then
                m_isFlashing = True
                AddTimerEvent(m_externalTimer)
                Me.Visible = True
            End If
            Return
        End If

        If m_timer.Enabled = False Then
            m_isFlashing = True
            m_timer.Enabled = True
            m_timer.Interval = m_iInterval
            m_timer.Start()
            Me.Visible = True
            Me.BringToFront()
        End If
    End Sub

    Public Sub StopFlashing()
        If m_externalTimer IsNot Nothing Then
            FlashLabel = False
            m_isFlashing = False
            RemoveTimerEvent(m_externalTimer)
            Me.Visible = False
            Return
        End If

        m_isFlashing = False
        m_timer.Enabled = False
        m_timer.Stop()
        Me.Visible = False
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2019-05-10</date>
    ''' <summary>
    ''' Remove timer event.
    ''' </summary>
    ''' <param name="timer"></param>
    ''' <remarks></remarks>
    Private Sub RemoveTimerEvent(ByRef timer As System.Timers.Timer)
        If timer IsNot Nothing Then
            RemoveHandler timer.Elapsed, AddressOf FlashingLabel
        End If
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2019-05-10</date>
    ''' <summary>
    ''' Add timer event.
    ''' </summary>
    ''' <param name="timer"></param>
    ''' <remarks></remarks>
    Protected Sub AddTimerEvent(ByRef timer As System.Timers.Timer)
        If timer IsNot Nothing Then
            AddHandler timer.Elapsed, AddressOf FlashingLabel
        End If
    End Sub

    ''' <author>
    '''     <name>Dy Do</name>
    '''     <date>2018-05-10</date>
    ''' </author>
    ''' <summary>
    ''' Restart Flashing
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Restart()
        ' Check if is not animating.
        If Not Me.m_isFlashing Then
            Return
        End If
        ' Stop timer.
        Me.StopFlashing()
        ' Restart timer.
        Me.StartFlashing()
    End Sub
#End Region
End Class
