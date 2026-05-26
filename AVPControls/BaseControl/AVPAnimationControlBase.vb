Imports System.ComponentModel

Public Class AVPAnimationControlBase
    Private m_animateTimer As System.Timers.Timer
    Private m_externalTimer As System.Timers.Timer
    Private m_isAnimating As Boolean
    'Private m_animateStatusLocker As New Object
    'Private m_updateAnimationLocker As New Object
    Private m_animationInterval As Integer = 300
    Private m_isAnimationContinue As Boolean
    Private Delegate Sub EventUpdateAnimation()
    ''' <summary>
    ''' Occurs when animation is started.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event AnimationStarted As EventHandler
    ''' <summary>
    ''' Occurs when animation is starting.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event AnimationStarting As EventHandler
    ''' <summary>
    ''' Occurs when animation is stoped.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event AnimationStoped As EventHandler

#Region "Animation Properties"
    <Category("Animation")> _
    Protected Property IsAnimating() As Boolean
        Get
            'SyncLock m_animateStatusLocker
            Return m_isAnimating
            'End SyncLock
        End Get
        Set(ByVal value As Boolean)
            'SyncLock m_animateStatusLocker
            m_isAnimating = value
            'End SyncLock
        End Set
    End Property

    ''' <summary>
    ''' Get or set the value indicates the interval of timer for animation.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Integer), "300"), Category("AVP Animation")> _
    Public Property AnimationInterval() As Integer
        Get
            Return m_animationInterval
        End Get
        Set(ByVal value As Integer)
            If m_animationInterval <> value AndAlso value > 0 Then
                m_animationInterval = value
                m_animateTimer.Interval = m_animationInterval
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicating whether the animation should be continue after timer is started.
    ''' </summary>
    ''' <value>true: The animation timer only stoped when IsStopAnimation condition were meet.
    ''' false: The animation timer will be enabled again when update view is finished.
    ''' </value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False"), Category("AVP Animation"), Description("Get or set a value indicating whether the animation should be continue after timer is started.")> _
    Public Property IsAnimationContinue() As Boolean
        Get
            Return m_isAnimationContinue
        End Get
        Set(ByVal value As Boolean)
            If m_isAnimationContinue <> value Then
                m_isAnimationContinue = value
            End If
        End Set
    End Property

    Protected Property AnimationTimer() As System.Timers.Timer
        Get
            Return m_animateTimer
        End Get
        Set(ByVal value As System.Timers.Timer)
            Me.ReleaseTimer(Me.m_animateTimer)

            m_animateTimer = value

            Me.AddTimerEvent(Me.m_animateTimer)

            Me.EnableTimer(Me.IsAnimating)
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-25</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets external timer for animation.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(System.Timers.Timer), "Nothing")> _
    Public Property ExternalTimer() As System.Timers.Timer
        Get
            Return m_externalTimer
        End Get
        Set(ByVal value As System.Timers.Timer)
            Try
                Me.RemoveTimerEvent(Me.m_externalTimer)

                m_externalTimer = value

                Dim animated As Boolean = Me.IsAnimating
                If animated Then
                    Me.StopAnimation()
                End If

                Me.AddTimerEvent(m_externalTimer)

                If animated Then
                    Me.StartAnimation()
                End If
            Catch ex As Exception
                Logger.Error(ex.ToString())
            End Try
        End Set
    End Property
#End Region

#Region "Animation Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Start animatiom
    ''' </summary>
    Protected Sub StartAnimation()
        If Not IsAnimating AndAlso IsStartAnimation() Then
            OnAnimationStarting(EventArgs.Empty)
            IsAnimating = Me.EnableTimer(True)
            OnAnimationStarted(EventArgs.Empty)
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Stop animation
    ''' </summary>
    Protected Sub StopAnimation()
        IsAnimating = Me.EnableTimer(False)
        OnAnimationStoped(EventArgs.Empty)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-28</date>
    ''' </author>
    ''' <summary>
    ''' Restart animation
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub RestartAnimation()
        ' Check if is not animating.
        If Not Me.IsAnimating Then
            Return
        End If
        ' Stop timer.
        Me.StopAnimation()
        ' Restart timer.
        Me.StartAnimation()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Update view when animation
    ''' </summary>
    Private Sub UpdateAnimation()
        If IsStopAnimation() Then
            StopAnimation()
        Else
            UpdateAnimatingView()
            If Not IsAnimationContinue Then
                If IsAnimating Then
                    Me.EnableTimer(True)
                End If
            End If
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Timer to update animation
    ''' </summary>
    Private Sub AnimationTimer_Tick(ByVal source As Object, ByVal e As Timers.ElapsedEventArgs)
        If Me.m_externalTimer IsNot Nothing AndAlso Not Me.IsAnimating Then
            Return
        End If

        If Not IsAnimationContinue Then
            Me.EnableTimer(False)
        End If

        If Me.InvokeRequired Then
            Dim deleUpdate As EventUpdateAnimation = New EventUpdateAnimation(AddressOf UpdateAnimation)
            Me.BeginInvoke(deleUpdate)
        Else
            UpdateAnimation()
        End If
    End Sub

#End Region

#Region "Animation Overridable Methods"
    ' Hai Tran (2015-09-07): Function use for check condition for stopping animation
    Protected Overridable Function IsStopAnimation() As Boolean
        Return True
    End Function

    ' Hai Tran (2015-09-07): Function use for check condition for starting animation
    Protected Overridable Function IsStartAnimation() As Boolean
        Return True
    End Function

    ' Hai Tran (2015-09-07): Methods use for update data when animation
    Protected Overridable Sub UpdateAnimatingView()

    End Sub
#End Region

#Region "Events"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_animateTimer = New System.Timers.Timer(m_animationInterval)
        m_animateTimer.Enabled = False
        AddTimerEvent(Me.m_animateTimer)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Raise the AnimationStarted event.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnAnimationStarted(ByVal e As EventArgs)
        RaiseEvent AnimationStarted(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Raise the AnimationStarting event.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnAnimationStarting(ByVal e As EventArgs)
        RaiseEvent AnimationStarting(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Raise the AnimationStoped event.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnAnimationStoped(ByVal e As EventArgs)
        RaiseEvent AnimationStoped(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-16</date>
    ''' </author>
    ''' <summary>
    ''' Clean up and stop timer
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub MemoryCleanup()
        Try
            MyBase.MemoryCleanup()

            Me.ReleaseTimer(Me.m_animateTimer)

            Me.RemoveTimerEvent(Me.m_externalTimer)

        Catch ex As Exception
            ' Ignore any errors.
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-25</date>
    ''' </author>
    ''' <summary>
    ''' Release timer.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ReleaseTimer(ByRef timer As System.Timers.Timer)
        If timer IsNot Nothing Then
            timer.Enabled = False
            timer.Dispose()
            timer = Nothing
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-25</date>
    ''' </author>
    ''' <summary>
    ''' Add event of animation timer.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddTimerEvent(ByRef timer As System.Timers.Timer)
        If timer IsNot Nothing Then
            AddHandler timer.Elapsed, AddressOf AnimationTimer_Tick
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-25</date>
    ''' </author>
    ''' <summary>
    ''' Remove event of animation timer.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub RemoveTimerEvent(ByRef timer As System.Timers.Timer)
        If timer IsNot Nothing Then
            RemoveHandler timer.Elapsed, AddressOf AnimationTimer_Tick
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-25</date>
    ''' </author>
    ''' <summary>
    ''' Enable/Disable timer for animating.
    ''' </summary>
    ''' <param name="enabled"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function EnableTimer(ByVal enabled As Boolean) As Boolean
        Try
            If m_externalTimer IsNot Nothing Then
                If m_animateTimer IsNot Nothing Then
                    m_animateTimer.Enabled = False
                End If
            ElseIf m_animateTimer IsNot Nothing Then
                m_animateTimer.Enabled = enabled
            Else
                Return False
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return enabled
    End Function

#End Region

End Class
