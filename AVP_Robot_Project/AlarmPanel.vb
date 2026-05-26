Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Threading
Public Class AlarmPanel
#Region "Member Variables"
    Private Shared m_blnEndProgram As Boolean = False

    Private m_blnIsStopFlashing As Boolean = True
    Private m_Timer As System.Timers.Timer
    Private m_lblAlarmLabel As Label
    Private m_imgAlarm As Image = Nothing
    Private m_imgNormal As Image = Nothing
    Private m_blnAlarm As Boolean = False
#End Region

#Region "public property"
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
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-20</date>
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
            Return m_blnAlarm
        End Get
        Set(ByVal value As Boolean)
            Try
                m_blnAlarm = value
                If value Then
                    Me.BackgroundImage = AlarmImage
                Else
                    Me.BackgroundImage = NormalImage
                End If

            Catch ex As Exception
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-20</date>
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
            Return m_blnIsStopFlashing
        End Get
        Set(ByVal value As Boolean)
            m_blnIsStopFlashing = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the label which are used to show alarm text
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ManagedAlarmLabel() As Label
        Get
            Return m_lblAlarmLabel
        End Get
        Set(ByVal value As Label)
            m_lblAlarmLabel = value
        End Set
    End Property
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim satAlarmTimer As New StatusAlarm(Me)
            satAlarmTimer.Name = "tmrFlashAlarm"
            satAlarmTimer.ManagedAlarmLabel = m_lblAlarmLabel
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(satAlarmTimer)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Public Shared Method"

    ' This is the method to run when the timer is raised.
    Private Sub TimerEventProcessor(ByVal myObject As Object, _
    ByVal e As System.Timers.ElapsedEventArgs)
        If IsStopFlashing Then
            VisibleAlarm = False
        Else
            VisibleAlarm = Not VisibleAlarm
        End If
    End Sub

#End Region

#Region "Public Method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-20</date>
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
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-22</date>
    ''' </author>
    ''' <summary>
    ''' Stop flashing
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopAlarm()
        AVPLib.Log.guiLogger.Info("Enter StopAlarm")
        Try
            IsStopFlashing = True
            StatusManager.IsAlarm = False
            AVPRobotMain.ProcessAlarmMessage()
             SecGem_AlarmClear_CX()

            m_lblAlarmLabel.Text = String.Empty
            MessageManager.ClearAllAlarms(False)

            MessageManager.IsAlarm = True ' Get next alarm
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Main Screen] Clear Alarm")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave StopAlarm")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-22</date>
    ''' </author>
    ''' <summary>
    ''' End Program
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndProgram()
        Try
            m_blnEndProgram = True
            m_Timer.Close()
            m_Timer = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-23</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        Try
            If AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_009) Then
                ActiveForm()
            Else
                InactiveForm()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Private method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
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
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
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
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on this control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AlarmPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.StopAlarm()
    End Sub
#End Region
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-07-05</date>
    ''' </author>
    ''' <summary>
    ''' Clear one alarm-> check alarm existed-> clear secsgem alarm
    ''' </summary>
    ''' <param name="sAlarmText"> Text Alarm in GUI</param>
#Region "SECSGEM ALARM CLEAR"
    Private Sub SecGem_AlarmClear_CX()
        Try
            If (MessageManager.CheckConditionForClearAlarm()) Then
                AVPLib.Business.AVPSecsGemLib.SECSGEM_AlarmClearAll()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-19</date>
    ''' </author>
    ''' <summary>
    ''' Clear alarm when no alarm in queue.
    ''' </summary>
    ''' <param name="sAlarmText"> Text Alarm in GUI</param>
    'Private Sub SecGem_AlarmClear_SL()
    '    Try
    '        If (MessageManager.CheckConditionForClearAlarm()) Then
    '            AVPLib.Business.AVPSecsGemLib.SECSGEM_CommonAlarmCLEAR(AVPLib.ConstEnum.LOADER_STR & "." & "SLSystemAlarm")
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub

#End Region
End Class
