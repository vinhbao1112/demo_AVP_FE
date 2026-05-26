Imports System.Timers
Namespace DataManagerment
    Public Class Alarm
        Inherits Equipment
#Region "Class Constants & Variables"
        Private m_intCode As Integer
        Private m_strAlarmText As String
        Private m_intAlarmServerity As Integer
        Private m_enmAlarmStatus As Object
        Private m_enmRedStatus As WorkingStatuses
        Private m_enmGreenStatus As WorkingStatuses
        Private m_enmOrangeStatus As WorkingStatuses
        Private m_enmBlueStatus As WorkingStatuses
        Private m_strSemiAutoMessage As String
        Private m_IdleTimer As System.Timers.Timer
        Private m_intNumberLightAlarm As Integer
        Private m_intNumberActiveLight As Integer
#End Region
#Region "Properties"
        ''' <author>
        '''    	<name> Huy Nguyen </name>
        '''    	<date> 2015-25-05</date>
        ''' </author>
        ''' <summary>
        ''' is four light alarm
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NumberLightAlarm() As Integer
            Get
                Return m_intNumberLightAlarm
            End Get
            Set(ByVal value As Integer)
                m_intNumberLightAlarm = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-04-07 </date>
        ''' </author>
        ''' <summary>
        ''' is number of active light
        ''' </summary>
        Public Property NumberActiveLight() As Integer
            Get
                Return m_intNumberActiveLight
            End Get
            Set(ByVal value As Integer)
                m_intNumberActiveLight = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current code alarm
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Code() As Integer
            Get
                Return m_intCode
            End Get
            Set(ByVal value As Integer)
                m_intCode = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current alarm text 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AlarmText() As String
            Get
                Return m_strAlarmText
            End Get
            Set(ByVal value As String)
                m_strAlarmText = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current alarm serverity
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AlarmServerity() As Integer
            Get
                Return m_intAlarmServerity
            End Get
            Set(ByVal value As Integer)
                m_intAlarmServerity = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' AlarmStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AlarmStatus() As Object
            Get
                Return m_enmAlarmStatus
            End Get
            Set(ByVal value As Object)
                m_enmAlarmStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2023-22-05</date>
        ''' </author>
        ''' <summary>
        ''' AlarmStatusIOtab
        ''' </summary>
        Private m_enmAlarmStatusIoTab As WorkingStatuses
        Public Property AlarmStatusIOtab() As WorkingStatuses
            Get
                Return m_enmAlarmStatusIoTab
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmAlarmStatusIoTab = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-05</date>
        ''' </author>
        ''' <summary>
        ''' RedStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RedStatus() As WorkingStatuses
            Get
                Return m_enmRedStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmRedStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-05</date>
        ''' </author>
        ''' <summary>
        ''' GreenStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GreenStatus() As WorkingStatuses
            Get
                Return m_enmGreenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmGreenStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-05</date>
        ''' </author>
        ''' <summary>
        ''' OrangeStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OrangeStatus() As WorkingStatuses
            Get
                Return m_enmOrangeStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmOrangeStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Huy Nguyen </name>
        '''    	<date> 2015-05-25</date>
        ''' </author>
        ''' <summary>
        ''' Blue status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BlueStatus() As WorkingStatuses
            Get
                Return m_enmBlueStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmBlueStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-15</date>
        ''' </author>
        ''' <summary>
        ''' Get or set SemiAutoMessage will be display on GUI
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SemiAutoMessage() As String
            Get
                Return m_strSemiAutoMessage
            End Get
            Set(ByVal value As String)
                m_strSemiAutoMessage = value
            End Set
        End Property
#End Region

#Region "Public method"
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-08</date>
        ''' </author>
        ''' <summary>
        ''' Init Timer for Idle Pooling
        ''' only use this function when Alarm light = RG mode
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub StartIdleTimer()
            If (m_IdleTimer Is Nothing) Then
                m_IdleTimer = New System.Timers.Timer()
                AddHandler m_IdleTimer.Elapsed, AddressOf FlashingIdleLight

                If AVPLib.RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = ConstEnum.TWOLIGHTALARM Then
                    m_IdleTimer.Interval = 1000 '1 seconds
                Else
                    m_IdleTimer.Interval = 2000 '2 seconds
                End If
            End If

            If (m_IdleTimer.Enabled = False) Then
                m_IdleTimer.Enabled = True
            End If
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-08</date>
        ''' </author>
        ''' <summary>
        ''' stop Timer for Idle Pooling
        ''' only use this function when Alarm light = RG mode
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub StopIdleTimer(Optional ByVal isRunning As Boolean = True)
            Try
                'stopped
                If (m_IdleTimer Is Nothing) Then
                    Exit Sub
                End If

                If (m_IdleTimer.Enabled = True) Then

                    'Remove the handler if the system is shutting down
                    If isRunning = False Then
                        RemoveHandler m_IdleTimer.Elapsed, AddressOf FlashingIdleLight
                    End If

                    m_IdleTimer.Enabled = False

                    'stop = green light = On
                    AVPLib.Utils.TurnRunning_GreenLightOn()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-08</date>
        ''' </author>
        ''' <summary>
        ''' stop Timer for Idle Pooling
        ''' only use this function when Alarm light = RG mode
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub FlashingIdleLight(ByVal source As Object, ByVal e As ElapsedEventArgs)
            m_IdleTimer.Enabled = False

            If (m_enmGreenStatus = WorkingStatuses.On) Then
                AVPLib.Utils.TurnRunning_GreenLightOnOff(True)
            ElseIf (m_enmGreenStatus = WorkingStatuses.Off) Then
                AVPLib.Utils.TurnRunning_GreenLightOnOff(False)
            End If

            m_IdleTimer.Enabled = True
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Change status Alarm
        ''' </summary>
        ''' <param name="PropertyNames"></param>
        ''' <param name="ReplyValues"></param>
        ''' <remarks></remarks>
        Public Overrides Sub ChangeStatus(ByVal PropertyNames As System.Collections.ArrayList, ByVal ReplyValues As System.Collections.ArrayList)
            AVPLib.Log.coreLogger.Info("Enter ChangeStatus")
            MyBase.ChangeStatus(PropertyNames, ReplyValues)
            AVPLib.Log.coreLogger.Info("Leave ChangeStatus")
        End Sub
#End Region
    End Class
End Namespace