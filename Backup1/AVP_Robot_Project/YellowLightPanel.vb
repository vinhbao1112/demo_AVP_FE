Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Threading
Imports AVPLib.ConstEnum

Public Class YellowLightPanel
#Region "Member Variables"
    Private Shared m_blnEndProgram As Boolean = False
    Private m_blnAlarm As Boolean = False
    Private m_blnIsStopFlashing As Boolean = True
    Private m_Timer As System.Timers.Timer
    Private m_lockObj As New Object
    Private m_imgAlarm As Image = Nothing
    Private m_imgNormal As Image = Nothing
    Private m_LightPanelType As LightPanel = LightPanel.GreenLight
    Public Event eShowAlarmLight(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event eStopAlarmLight(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Enum LightPanel
        RedLight
        GreenLight
        YellowLight
        BlueLight
    End Enum
#End Region

#Region "public property"
    Public Property LightPanelType() As LightPanel
        Get
            Return m_LightPanelType
        End Get
        Set(ByVal value As LightPanel)
            m_LightPanelType = value
        End Set
    End Property

    Public Property AlarmImage() As Image
        Get
            Return m_imgAlarm
        End Get
        Set(ByVal value As Image)
            m_imgAlarm = value
        End Set
    End Property
    Public Property NormalImage() As Image
        Get
            Return m_imgNormal
        End Get
        Set(ByVal value As Image)
            m_imgNormal = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' Set visible and Invisible alarm image
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property VisibleAlarm() As Boolean
        Get
            Return m_blnAlarm 'labAlarm.Visible
        End Get
        Set(ByVal value As Boolean)
            Try
                m_blnAlarm = value
                If value Then
                    Me.BackgroundImage = AlarmImage
                    RaiseEvent eShowAlarmLight(Me, Nothing)
                Else
                    Me.BackgroundImage = NormalImage
                    RaiseEvent eStopAlarmLight(Me, Nothing)
                End If
                
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' Get or set flashing
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property IsStopFlashing() As Boolean
        Get
            SyncLock m_lockObj
                Return m_blnIsStopFlashing
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            SyncLock m_lockObj
                m_blnIsStopFlashing = value
            End SyncLock
        End Set
    End Property
#End Region

#Region "Public Method"
    ' This is the method to run when the timer is raised.
    Private Sub TimerEventProcessor(ByVal myObject As Object, _
    ByVal e As System.Timers.ElapsedEventArgs)
        If IsStopFlashing Then
            VisibleAlarm = False
        Else
            VisibleAlarm = Not VisibleAlarm
        End If
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' Start flashing
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartAlarm()
        Try
            If (m_Timer Is Nothing) Then
                m_Timer = New System.Timers.Timer(300)
                AddHandler m_Timer.Elapsed, AddressOf TimerEventProcessor
                m_Timer.SynchronizingObject = Me
                m_Timer.Start()
            End If
            If Not (m_Timer.Enabled) Then
                m_Timer.Start()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' Stop flashing
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopAlarm()
        Try
            ''set bit to Kepware
            If LightPanelType = LightPanel.GreenLight Then
                ''if Running Light is flashing -> don't let user do anything
                Exit Try
            ElseIf LightPanelType = LightPanel.YellowLight Then
                AVPLib.Utils.TurnIdle_YellowLightOnOff(True)
            ElseIf LightPanelType = LightPanel.RedLight Then
                'AVPLib.Utils.TurnAlarm_RedLight2Off(True)
            End If

            IsStopFlashing = True
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "Clear Alarm")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' End Program
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndProgram()
        Try
            m_blnEndProgram = True
            If (m_Timer IsNot Nothing) Then
                m_Timer.Close()
                m_Timer = Nothing
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        Try
            '#03/07/2011 
            '#[Sl_Build 12_Feb 16, 2011]User account should be similar to avp/pvd request
            '#Begin fix:
            If AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_010) Then
                ActiveForm()
            Else
                InactiveForm()
            End If
            '#End fix.
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Private method"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.Enabled = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            Me.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on this control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AlarmPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click, labAlarm.Click
        Me.StopAlarm()
    End Sub
    
#End Region
End Class
