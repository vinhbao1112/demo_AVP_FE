Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Imports AVP.Network

Namespace Communication
    Public Class PMServerConnection
        Inherits Connection

#Region "Class Constants & Variables"
        Private m_strChamberId As String
        Private m_CommandsMap As Hashtable = Nothing
        Private m_PMConnection As AVPConnection = Nothing
        Private m_KeepAliveTimer As System.Timers.Timer = Nothing
        Private m_lConnectionStartTckCnt As Long = Environment.TickCount
        Private m_lLastPacketReceivedTickCount As Long = Environment.TickCount
#End Region

#Region "Properties"

        Private m_isKeepAliveMode As Boolean = True  ''->PVD/AVP_IBE, if false VEECO_IBE
        Public Property IsKeepAliveMode() As Boolean
            Get
                Return m_isKeepAliveMode
            End Get
            Set(ByVal value As Boolean)
                m_isKeepAliveMode = value
            End Set
        End Property
        Private m_ChamberType As AVPLib.SystemModule.ModuleType
        Public Property ChamberType() As SystemModule.ModuleType
            Get
                Return m_ChamberType
            End Get
            Set(ByVal value As SystemModule.ModuleType)
                m_ChamberType = value
            End Set
        End Property

        ''' <summary>
        ''' The chamber to whic this connection belongs.
        ''' </summary>
        Public Property EquipmentName() As String
            Get
                Return m_strChamberId
            End Get
            Set(ByVal value As String)
                m_strChamberId = value
            End Set
        End Property

#End Region

#Region "Constructor & destructor"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Initialize terminal connection
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal moduleType As SystemModule.ModuleType, ByVal strIpAddress As String, ByVal intPort As Integer)
            ' Create a connection.
            m_IPAddress = strIpAddress
            m_Port = intPort
            If moduleType = AVPLib.SystemModule.ModuleType.IBE Then
                m_CommandsMap = ContainerData.m_IBEMaintenanceCodeMap
                m_PMConnection = New AVPIBEConnection(m_IPAddress, m_Port, False)
                m_PMConnection.RestartAutomatically = False
                m_PMConnection.ResponseTerminators = New String() {vbCr}
                ChamberType = SystemModule.ModuleType.IBE
            ElseIf moduleType = AVPLib.SystemModule.ModuleType.PVD Then
                m_CommandsMap = ContainerData.m_PVDMaintenanceCodeMap
                m_PMConnection = New AVPPVDConnection(m_IPAddress, m_Port, False)
                m_PMConnection.RestartAutomatically = False
                m_PMConnection.ResponseTerminators = New String() {vbLf & vbCr}
                ChamberType = SystemModule.ModuleType.PVD
            ElseIf moduleType = AVPLib.SystemModule.ModuleType.PVD4 Then
                m_CommandsMap = ContainerData.m_CoronaMaintenanceCodeMap
                m_PMConnection = New AVPPVDConnection(m_IPAddress, m_Port, False)
                m_PMConnection.RestartAutomatically = False
                m_PMConnection.ResponseTerminators = New String() {vbCr}
                ChamberType = SystemModule.ModuleType.PVD4
            ElseIf moduleType = AVPLib.SystemModule.ModuleType.PVD5T Then
                m_CommandsMap = ContainerData.m_PVD5TMaintenanceCodeMap
                m_PMConnection = New AVPPVDConnection(m_IPAddress, m_Port, False)
                m_PMConnection.RestartAutomatically = False
                m_PMConnection.ResponseTerminators = New String() {vbCr}
                ChamberType = SystemModule.ModuleType.PVD5T
            ElseIf moduleType = SystemModule.ModuleType.DeviceNetApp Then
                m_CommandsMap = ContainerData.m_DeviceNetAppMaintenanceCodeMap
                m_PMConnection = New AVPPVDConnection(m_IPAddress, m_Port, False)
                m_PMConnection.RestartAutomatically = False
                m_PMConnection.ResponseTerminators = New String() {vbCr}
                ChamberType = SystemModule.ModuleType.DeviceNetApp
            End If
            AddHandler m_PMConnection.OnConnectionStateChanged, AddressOf ConnectionStateChanged
            AddHandler m_PMConnection.OnMessageArrived, AddressOf OnMessageArrived
            m_lConnectionStartTckCnt = Environment.TickCount
        End Sub
#End Region

#Region "Keep Alive"
        Public Function StartKeepAlive() As Boolean
            ' Lazy Initialization
            If m_KeepAliveTimer Is Nothing Then
                m_KeepAliveTimer = New System.Timers.Timer()
                m_KeepAliveTimer.Interval = 2000 ' 2 seconds as default
                AddHandler m_KeepAliveTimer.Elapsed, AddressOf KeepAliveTimer_Elapsed
            End If
            If Not m_KeepAliveTimer.Enabled Then
                m_KeepAliveTimer.Enabled = True
            End If
            Return True
        End Function

        Public Function StopKeepAlive() As Boolean
            If m_KeepAliveTimer IsNot Nothing Then
                If m_KeepAliveTimer.Enabled Then
                    m_KeepAliveTimer.Enabled = False
                End If
                ' Release the timer.
                m_KeepAliveTimer.Dispose()
                m_KeepAliveTimer = Nothing
            End If
            Return True
        End Function

        Private Sub KeepAliveTimer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
            ' Prevent re-entry
            m_KeepAliveTimer.Enabled = False

            Dim lCurrentTickCount As Long = Environment.TickCount

            ' Process
            If lCurrentTickCount >= m_lConnectionStartTckCnt Then
                If (lCurrentTickCount - m_lConnectionStartTckCnt > RobotConfigurationValues.DELAY_TIME_KEEPALIVE) Then ' Make sure system ready to send keep alive
                    If IsKeepAliveMode Then
                        ''For PVD, AVP-IBE
                        If (Not Me.SendKeepAliveMessage()) Then
                            m_PMConnection.ResetConnection()
                            Exit Sub
                        End If
                    Else
                        ''For VEECO-IBE
                        If (lCurrentTickCount >= m_lLastPacketReceivedTickCount) Then
                            If (lCurrentTickCount - m_lLastPacketReceivedTickCount > RobotConfigurationValues.CONNECTION_TIMEOUT) Then
                                'Timeout
                                m_PMConnection.ResetConnection()
                                Exit Sub
                            End If
                        Else
                            ''For TickCount jump from Int32.MaxValue to Int32.MinValue
                            m_lLastPacketReceivedTickCount = lCurrentTickCount
                        End If
                    End If
                End If
            Else
                ''For TickCount jump from Int32.MaxValue to Int32.MinValue
                m_lConnectionStartTckCnt = lCurrentTickCount
            End If

            ' Continue
            m_KeepAliveTimer.Enabled = True
        End Sub

#End Region

#Region "Pubic Method"

        Public Function SendKeepAliveMessage() As Boolean
            Dim strResponse As String = String.Empty
            Dim strMessage As String = String.Empty
            Dim Default_Keep_Alive_TimeOut As Int32 = RobotConfigurationValues.CONNECTION_TIMEOUT
            Const ACK As String = "ACK"
            Dim IsOK As Boolean = False

            If ChamberType = SystemModule.ModuleType.PVD Then
                strMessage = ContainerData.GetPVDCmdCode(Business.PVDCommands.KEEP_ALIVE.ToString())
            ElseIf ChamberType = SystemModule.ModuleType.IBE Then
                strMessage = ContainerData.GetIBECmdCode(Business.IBECommands.KEEP_ALIVE.ToString())
            ElseIf ChamberType = SystemModule.ModuleType.PVD4 Then
                strMessage = ContainerData.GetCoronaCmdCode(Business.CORONACommands.KEEP_ALIVE.ToString())
            ElseIf ChamberType = SystemModule.ModuleType.PVD5T Then
                strMessage = ContainerData.GetPVD5TCmdCode(Business.PVD5TCommands.KEEP_ALIVE.ToString())
            ElseIf ChamberType = SystemModule.ModuleType.DeviceNetApp Then
                ' Do not need to send keep alive message for DeviceNetApp
                Return True
            End If
            ' Try 3 times to determine if disconnected or not
            For I As Integer = 1 To 3
                If SendCommand(strMessage, strResponse, Default_Keep_Alive_TimeOut) Then
                    If String.IsNullOrEmpty(strResponse) Then
                        System.Threading.Thread.Sleep(1000) ' Sleep 1 second before do another retry
                        Continue For
                    End If
                    If strResponse.StartsWith(ACK) Then
                        IsOK = True
                        Exit For
                    End If
                End If
            Next

            Return IsOK
        End Function

        Public Function SendCommand(ByVal strMessage As String, ByRef strResponse As String, ByVal millisecondsTimeout As Int32) As Boolean
            Return m_PMConnection.SendMessage(strMessage & vbCr, strResponse, millisecondsTimeout)
        End Function

        Private Sub ConnectionStateChanged(ByVal connectionState As AVPConnection.SocketState)
            If (connectionState = AVPConnection.SocketState.Connecting) Or (connectionState = AVPConnection.SocketState.Disconnecting) Then
                ' Just skip those states.
                Return
            End If
            If (connectionState = AVPConnection.SocketState.Closed) Then
                If (m_CurrentState = States.Connected) Then
                    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("CommunicationError"), _
                             AVPLib.Utils.chamberID2ChamberName(m_strChamberId)), Utils.GemGetAlarmName(m_strChamberId))
                End If
                m_CurrentState = States.Disconnected
            ElseIf (connectionState = AVPConnection.SocketState.Connected) Then
                m_CurrentState = States.Connected
                ' Start KeepAlive
                If RobotConfigurationValues.CONNECTION_TIMEOUT > 0 Then
                    StartKeepAlive()
                End If
            End If
            ' Raise Event
            If (m_CurrentState = States.Disconnected) Then
                'Stop KeepAlive
                StopKeepAlive()
            End If
            '
            Dim Values As ArrayList = New ArrayList()
            Dim PropertyNames As New ArrayList
            PropertyNames.Add("ConnectionStatus")
            Values.Add(IIf(m_CurrentState = States.Connected, AVPLib.DataManagerment.Equipment.WorkingStatuses.On, AVPLib.DataManagerment.Equipment.WorkingStatuses.Off))
            DataManagerment.EquipmentManager.ChangeStatus(m_strChamberId, PropertyNames, Values)
        End Sub

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2010-3-22</date>
        ''' </author>
        ''' <summary>
        ''' Send a message
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Function SendMessageWithLog(ByVal Message As String) As Boolean
            AVPLib.Log.terminalServerLogger.Info(Utils.chamberID2ChamberName(Me.EquipmentName) & " Sent: " + Message)
            Return SendMessage(Message)
        End Function

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2010-3-22</date>
        ''' </author>
        ''' <summary>
        ''' Send a message
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Function SendMessageWithoutLog(ByVal Message As String) As Boolean
            Return SendMessage(Message)
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Send a message
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Overrides Function SendMessage(ByVal strMessage As String) As Boolean
            AVPLib.Log.terminalServerLogger.Info("Enter SendMessage")
            AVPLib.Log.terminalServerChamberLogger.Debug("-->CHAMBER=" + strMessage)
            Dim strResponse As String = String.Empty

            'Return m_PMConnection.SendMessage(strMessage & vbLf & vbCr, strResponse, 0)
            Return m_PMConnection.SendMessage(strMessage & vbCr, strResponse, 0)

            AVPLib.Log.terminalServerLogger.Info("Leave SendMessage")
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-01</date>
        ''' </author>
        ''' <summary>
        '''  Open connection
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Open() As Boolean
            AVPLib.Log.terminalServerLogger.Info("Enter Open")
            m_PMConnection.ResetConnection()
            Threading.Thread.Sleep(500)
            Return m_PMConnection.RestartConnection()
            AVPLib.Log.terminalServerLogger.Info("Leave Open")
        End Function

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Close connection
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Close() As Boolean
            AVPLib.Log.terminalServerLogger.Info("Enter Close")
            m_PMConnection.Dispose()
            AVPLib.Log.terminalServerLogger.Info("Leave Close")
            Return True
        End Function
#End Region

#Region "Private methods"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-01</date>
        ''' </author>
        ''' <summary>
        ''' On Data Received
        ''' </summary>
        ''' <param name="strData"></param>
        ''' <remarks></remarks>
        Private Sub OnMessageArrived(ByVal strData As String)
            AVPLib.Log.terminalServerLogger.Info("Enter OnDataReceived")
            AVPLib.Log.terminalServerChamberLogger.Debug("<--" + Me.EquipmentName + "=" + strData)
            m_lLastPacketReceivedTickCount = Environment.TickCount

            Dim isUseAVPCommandCode As Boolean = False
            'Corona, PQL, RIE
            If (ChamberType = SystemModule.ModuleType.PVD4 OrElse ChamberType = SystemModule.ModuleType.PVD5T) Then
                isUseAVPCommandCode = True
            End If

            Try
                'Parse Message
                Dim dbPMCommand As DBCommand = ContainerData.GetMaintenanceCmd(m_CommandsMap, strData, isUseAVPCommandCode)
                If dbPMCommand IsNot Nothing Then
                    Dim Value As Object = Utils.DecoderIBEMaintenance(dbPMCommand, strData, isUseAVPCommandCode)
                    Dim Values As ArrayList = New ArrayList()
                    If Not String.IsNullOrEmpty(dbPMCommand.PropertyName) Then
                        Dim PropertyNames As ArrayList = New ArrayList(dbPMCommand.PropertyName.Split(","c))
                        Dim i As Integer = 0
                        For i = 0 To (PropertyNames.Count - 1)
                            Values.Add(Value)
                        Next
                        DataManagerment.EquipmentManager.ChangeStatus(EquipmentName, PropertyNames, Values)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave OnDataReceived")
        End Sub
#End Region
    End Class
End Namespace
