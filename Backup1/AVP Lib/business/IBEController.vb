Imports System.Timers
Imports System.Threading
Imports AVPLib.DataManagerment
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum
Namespace Business
    Public Class IBEController
        Inherits ControllerObject
        Implements IRecipeProcessing

#Region "Class Constants & Variables"
        Const STRING_TYPE1 As String = "^(\w+)\.(\w+) (.*)$"
        Const STRING_TYPE2 As String = "^(\w+)\.(\w+)$"
        Const STRING_TYPE3 As String = "^(\w+) (\w+)$"
        Const STRING_TYPE4 As String = "^(\w+)$"
        Const STRING_TYPE5 As String = "^(\w+) (.*)$"
        Private m_fSourceUsageWarningLimitSend As Double = 0
        Private m_fSourceUsageAlarmLimitSend As Double = 0
        Private m_bFirstTimeSend As Boolean = True
        Private m_fTargetMaxSourceUsageSend As Double = 0
        Private m_blnThrowAlarm_When_Online As Boolean = True
        Private m_eIBEType As IBEType = IBEType.AVP_IBE
#End Region

#Region "Properties"
        Private trdToolOnline As Thread
        Private m_EventStopThread As ManualResetEvent = New ManualResetEvent(False)
        Private m_EventPumpDownAborted As ManualResetEvent = New ManualResetEvent(False)
        Private m_tmrPullingTimer As System.Timers.Timer
        Private m_blnIsSending As Boolean
        Dim m_pollIsDone As ManualResetEvent = New ManualResetEvent(False)
        Private m_queRequestMessages As Queue = New Queue()
        Private m_lLastReconnectTickCount As Long = 0
        Private m_iReconnectTimes As Integer = 0
        Protected m_RoutineExecutor As ChamberRoutineExecutor = Nothing
        '#04/07/2011 
        '#0001517: [SL_Build 21_Apr 7,2011]Pbn body and pbn discharge RB is not updating. 
        '#Begin fix: Create 2 variable:
        '# - m_IsInitOrReconnectPulling: + True: Pulling all commands stored in initialize config
        '#                               + False: Pulling commands in m_ListCmdNeedToPullingAllTime
        Private m_IsInitOrReconnectPulling = False
        Private m_ListCmdNeedToPullingAllTime As ArrayList = New ArrayList()
        '# End fix.

        Public Property PullingInterval() As Integer
            Get
                Return m_tmrPullingTimer.Interval
            End Get
            Set(ByVal value As Integer)
                Dim blnIsStart = m_tmrPullingTimer.Enabled
                m_tmrPullingTimer.Enabled = False
                m_tmrPullingTimer.Interval = value
                If (blnIsStart) Then
                    m_tmrPullingTimer.Enabled = True
                End If
            End Set
        End Property

        Public ReadOnly Property CurrentRoutineExecutor() As ChamberRoutineExecutor
            Get
                Return m_RoutineExecutor
            End Get
        End Property
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22</date>
        ''' </author>
        ''' <summary>
        ''' Override EquipmentName
        ''' </summary>
        Public Overrides Property EquipmentName() As String
            Get
                Return m_strEquipmentName
            End Get
            Set(ByVal value As String)
                m_strEquipmentName = value
                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(m_strEquipmentName)

                If serverConfig.Type = IBEType.AVP_IBE.ToString() Then
                    m_eIBEType = IBEType.AVP_IBE
                ElseIf serverConfig.Type = IBEType.VEECO_IBE.ToString() Then
                    m_eIBEType = IBEType.VEECO_IBE
                Else
                    m_eIBEType = ConstEnum.IBEType.UNDEFINED
                End If
            End Set
        End Property

        Public Property MyIBEType() As IBEType
            Get
                Return m_eIBEType
            End Get
            Set(ByVal value As IBEType)
                m_eIBEType = value
            End Set
        End Property
        Private ReadOnly Property IBE_Equipment() As IBEChamber
            Get
                Return EquipmentManager.GetEquipment(Me.EquipmentName)
            End Get
        End Property

        Private ReadOnly Property IBEConfig() As SystemModule
            Get
                Return AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
            End Get
        End Property
#End Region

#Region "Constructors & Dispose"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Initialize IBEController
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal EQName As String)
            m_tmrPullingTimer = New System.Timers.Timer()
            AddHandler m_tmrPullingTimer.Elapsed, AddressOf Pulling
            AddAllCmdNeedToPollingAllTime()
            m_IsInitOrReconnectPulling = True
            m_tmrPullingTimer.Interval = ContainerData.GetPolling(ConstEnum.IBE_POLLING_CMD).Interval ''read from config file
            m_tmrPullingTimer.Enabled = True 'Start pulling
            m_RoutineExecutor = New ChamberRoutineExecutor(EQName)
            Me.EquipmentName = EQName
        End Sub

        Public Overrides Sub Dispose()
            AVPLib.Log.coreLogger.Info("Enter Dispose")
            Try
                m_EventStopThread.Set()
                m_EventPumpDownAborted.Set()

                m_tmrPullingTimer.Enabled = False
                RemoveHandler m_tmrPullingTimer.Elapsed, AddressOf Pulling
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Dispose")

        End Sub
#End Region

#Region "Helper Functions"
        'Truc Le add
        Public Sub SendRequestAllData() Implements IRecipeProcessing.SendRequestAllData
            AVPLib.Log.coreLogger.Info("Enter SendRequestAllData")
            If RobotConfigurationValues.SUPPORT_IBE_UPDATE_WHEN_DATA_CHANGED Then
                AVPLib.Log.avpLogger.Debug("Send Request Data to IBE: " & Me.EquipmentName)
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.REQUEST_ALL_DATA.ToString, ConfigurationValues.DEVICE_STATUS_OPEN)
            End If
            AVPLib.Log.coreLogger.Info("Enter SendRequestAllData")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-07-31</date>
        ''' </author>
        ''' <summary>
        ''' Monitor All interlock of this chamber
        ''' if all interlock is not make -> go offline
        ''' </summary>
        ''' <remarks></remarks>
        Private Function IsAllInterlockOK() As Boolean
            Dim blResult As Boolean = False
            Try
                If IBE_Equipment IsNot Nothing Then
                    With IBE_Equipment
                        blResult = (.ChamberInterlocks_FixtureWater_Status = Equipment.WorkingStatuses.On) _
                                                     AndAlso (Not IBEConfig.ChamberInterlock_FixtureWaterBugVisible OrElse .ChamberInterlocks_FixtureWaterBug_Status = Equipment.WorkingStatuses.On) _
                                                     AndAlso (.ChamberInterlocks_SourceWater_Status = Equipment.WorkingStatuses.On) _
                                                     AndAlso (.ChamberInterlocks_PanelInterlock_Status = Equipment.WorkingStatuses.On) _
                                                     AndAlso (.ChamberInterlocks_ChamberPress_Status = Equipment.WorkingStatuses.On) _
                                                     AndAlso (.ChamberInterlocks_Foreline_Status = Equipment.WorkingStatuses.On) _
                                                     AndAlso (.ChamberInterlocks_AirPressure_Status = Equipment.WorkingStatuses.On) _
                                                     AndAlso (.ChamberInterlocks_TurboWater_Status = Equipment.WorkingStatuses.On) _
                                                     AndAlso (.ACPower_readback = Equipment.WorkingStatuses.On)
                    End With
                End If
                
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function

        Public Sub Pulling(ByVal source As Object, ByVal e As ElapsedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter Pulling")
            Try
                m_tmrPullingTimer.Enabled = False
                ''Reconnect PM
                Dim ObjPM As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                If (ObjPM IsNot Nothing) AndAlso ObjPM.ConnectionStatus <> Equipment.WorkingStatuses.On Then

                    If (m_lLastReconnectTickCount = 0) Then
                        m_lLastReconnectTickCount = Environment.TickCount
                    Else
                        If ((Environment.TickCount - m_lLastReconnectTickCount) > 3 * 1000) Then ' 3s to reconnect

                            If (m_iReconnectTimes <= ConstEnum.PM_RECONNECT_TRY_TIME) Then ' 3 Times
                                ' Reconnect
                                DoReConnect(Me.EquipmentName)

                                ' Reset Tick Count
                                m_lLastReconnectTickCount = 0

                                ' Increase Reconnect Times
                                m_iReconnectTimes = m_iReconnectTimes + 1
                            End If ' End 3 Times

                        End If ' End 3s to reconnect
                    End If ' End start count time
                Else
                    m_iReconnectTimes = 0
                    m_lLastReconnectTickCount = 0
                End If
                '''''
                Dim ListInitCmds As ArrayList = ContainerData.GetInitConfig(ConstEnum.STR_IBE)
                Dim blnResult As Boolean = True
                '#04/07/2011 
                '#0001517: [SL_Build 21_Apr 7,2011]Pbn body and pbn discharge RB is not updating. 
                '#Begin fix:
                '#----Unoffical code. Need to check again.
                If m_IsInitOrReconnectPulling Then
                    m_IsInitOrReconnectPulling = False
                    For Each IBECmds As String In ListInitCmds
                        If blnResult Then
                            blnResult = Utils.SendCommandPMServer(EquipmentName, IBECmds, True)
                        Else
                            Exit For
                        End If
                    Next
                End If
                ' Update Source Usage Warning/Alarm Limit
                Dim objChamber As SystemModule = IBEConfig ' AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                If (objChamber IsNot Nothing) Then

                    If (m_bFirstTimeSend) Then ' First Time => Sync value
                        m_fSourceUsageWarningLimitSend = objChamber.SourceUsageTimeWarning
                        m_fSourceUsageAlarmLimitSend = objChamber.SourceUsageTimeLimit
                        m_bFirstTimeSend = False
                    Else
                        ' Send Target KWH Warning Limit if changed
                        If (m_fSourceUsageWarningLimitSend <> objChamber.SourceUsageTimeWarning) Then
                            Dim bRes As Boolean = IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, _
                                                                                      IBECommands.SOURCE_USAGE_WARNING.ToString(), _
                                                                                      objChamber.SourceUsageTimeWarning.ToString())
                            If (bRes) Then
                                m_fSourceUsageWarningLimitSend = objChamber.SourceUsageTimeWarning
                            End If
                        End If

                        ' Send Target KWH Alarm Limit if changed
                        If (m_fSourceUsageAlarmLimitSend <> objChamber.SourceUsageTimeLimit) Then
                            Dim bRes As Boolean = IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, _
                                                                                      IBECommands.SOURCE_USAGE_LIMIT.ToString(), _
                                                                                      objChamber.SourceUsageTimeLimit.ToString())
                            If (bRes) Then
                                m_fSourceUsageAlarmLimitSend = objChamber.SourceUsageTimeLimit
                            End If
                        End If

                        ' Send Max Source Usage  if changed
                        If (m_fTargetMaxSourceUsageSend <> objChamber.Max_KWH_Source) AndAlso ObjPM.IsUseMaxLimit Then
                            '''Update to EQ and SECSGEM
                            Dim objEQ As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Utils.chamberName2ChamberID(objChamber.Name))
                            If objEQ IsNot Nothing Then
                                CType(objEQ, AVPLib.DataManagerment.IBEChamber).Max_KWH_Source = objChamber.Max_KWH_Source
                            End If
                            '''''''''
                            Dim bRes As Boolean = IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, _
                                                                                      IBECommands.MAX_SOURCE_USAGE.ToString(), _
                                                                                      objChamber.Max_KWH_Source.ToString())
                            If (bRes) Then
                                m_fTargetMaxSourceUsageSend = objChamber.Max_KWH_Source
                            End If
                        End If

                    End If
                End If

                ' For VEECO IBE
                If MyIBEType = IBEType.VEECO_IBE Then
                    For Each IBECmds As String In m_ListCmdNeedToPullingAllTime
                        If blnResult Then
                            blnResult = Utils.SendCommandPMServer(EquipmentName, IBECmds, True)
                        Else
                            Exit For
                        End If
                    Next
                End If
                m_tmrPullingTimer.Enabled = True 'Continue Pulling
                '#End fix

                ' -	CXX.  If PMx is online and one of the interlock is off,  need to take PMx to offline.
                If (ObjPM.ControlStatus = DataManagerment.Equipment.ControlStatuses.ONLINE AndAlso IsAllInterlockOK() = False) Then
                    DoOffline()
                    AVPLib.Log.avpLogger.Error("IBEDoOffline-ChamberInterlocks_FixtureWater_Status:" + IBE_Equipment.ChamberInterlocks_FixtureWater_Status.ToString())
                    AVPLib.Log.avpLogger.Error("IBEDoOffline-ChamberInterlock_FixtureWaterBugVisible:" + IBEConfig.ChamberInterlock_FixtureWaterBugVisible.ToString())
                    AVPLib.Log.avpLogger.Error("IBEDoOffline-ChamberInterlocks_FixtureWaterBug_Status:" + IBE_Equipment.ChamberInterlocks_FixtureWaterBug_Status.ToString())
                    AVPLib.Log.avpLogger.Error("IBEDoOffline-ChamberInterlocks_SourceWater_Status:" + IBE_Equipment.ChamberInterlocks_SourceWater_Status.ToString())
                    AVPLib.Log.avpLogger.Error("IBEDoOffline-ChamberInterlocks_PanelInterlock_Status:" + IBE_Equipment.ChamberInterlocks_PanelInterlock_Status.ToString())
                    AVPLib.Log.avpLogger.Error("IBEDoOffline-ChamberInterlocks_ChamberPress_Status:" + IBE_Equipment.ChamberInterlocks_ChamberPress_Status.ToString())
                    AVPLib.Log.avpLogger.Error("IBEDoOffline-ChamberInterlocks_Foreline_Status:" + IBE_Equipment.ChamberInterlocks_Foreline_Status.ToString())
                    AVPLib.Log.avpLogger.Error("IBEDoOffline-ChamberInterlocks_AirPressure_Status:" + IBE_Equipment.ChamberInterlocks_AirPressure_Status.ToString())
                    AVPLib.Log.avpLogger.Error("IBEDoOffline-ChamberInterlocks_TurboWater_Status:" + IBE_Equipment.ChamberInterlocks_TurboWater_Status.ToString())
                    AVPLib.Log.avpLogger.Error("IBEDoOffline-ACPower_readback:" + IBE_Equipment.ACPower_readback.ToString())
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Pulling")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-10-08</date>
        ''' </author>
        ''' <summary>
        ''' ReConnect to IBE
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub DoReConnect(ByVal ChamberName As String)
            AVPLib.Log.coreLogger.Info("Enter DoReConnect")
            Dim Connection As Communication.PMServerConnection = CType(Communication.ConnectionManager.GetConnection(ChamberName), Communication.PMServerConnection)
            If Connection IsNot Nothing Then
                Dim blnSuccess As Boolean = Connection.Open()
                If blnSuccess Then
                    m_IsInitOrReconnectPulling = True
                End If
                m_tmrPullingTimer.Enabled = blnSuccess
            Else
                AVPLib.Log.coreLogger.Error("CAN NOT GET THE " + ChamberName + " CONNECTION OBJECT")
            End If

            AVPLib.Log.coreLogger.Info("Leave DoReConnect")
        End Sub
        ''' <author>
        '''    	<name> Dy Do </name>
        '''    	<date> 2016-02-02</date>
        ''' </author>
        ''' <summary>
        ''' Do Check Recipe Template Version
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub DoCheckRecipeTemplateVersion() Implements IRecipeProcessing.DoCheckRecipeTemplateVersion
            AVPLib.Log.coreLogger.Info("Enter DoCheckRecipeTemplateVersion")
            'Send Recipe Template Version
            IBEUtility.Check_Recipe_Template_Version(Me.EquipmentName, Utils.GetRecipeVersion(Me.EquipmentName))
            AVPLib.Log.coreLogger.Info("Leave DoCheckRecipeTemplateVersion")
        End Sub
        ''' <author>
        '''    	<name>Hoa Nguyen </name>
        '''    	<date> 2011-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Add all commands need to pulling all time.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub AddAllCmdNeedToPollingAllTime()
            m_ListCmdNeedToPullingAllTime.Add("05,01,17,01,02,?") 'PBN Body
            m_ListCmdNeedToPullingAllTime.Add("05,01,18,01,02,?") 'PBN Disch
            m_ListCmdNeedToPullingAllTime.Add("05,01,19,01,02,?") 'K Factor
            m_ListCmdNeedToPullingAllTime.Add("03,01,10,01,04,?")  'Flowcool He Gas 
            m_ListCmdNeedToPullingAllTime.Add("05,01,08,01,04,?")  'Gas 1 
            m_ListCmdNeedToPullingAllTime.Add("05,01,08,02,04,?")  'Gas 2 
        End Sub

#Region "Valve"
        Private Sub SetIsolationValveStatus(ByVal strValOnOffUnknown As String)
            AVPLib.Log.coreLogger.Info("Enter SetIsolationValveStatus")
            Select Case strValOnOffUnknown
                Case STR_OFF
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, _
                                                        IBECommands.ISOLATION_VALVE.ToString(), _
                                                        ConfigurationValues.DEVICE_STATUS_CLOSED)
                Case Else
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, _
                                                        IBECommands.ISOLATION_VALVE.ToString(), _
                                                        ConfigurationValues.DEVICE_STATUS_OPEN)
            End Select

            AVPLib.Log.coreLogger.Info("Leave SetIsolationValveStatus")
        End Sub

        '' bOpen: value of Valve, True or false
        Private Sub ChangeValve(ByVal bCmd As IBECommands, ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeValve")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, bCmd.ToString(), _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeValve")
        End Sub
        '' bOpen: value of Valve, True or false
        Private Sub ChangeWaterPumpValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeWaterPumpValve")
            IBEUtility.Turbo_Pump_Water_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeWaterPumpValve")
        End Sub
        Private Sub ChangeCryoPumpValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeCryoPumpValve")
            IBEUtility.Cryo_Pump_Gate_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeCryoPumpValve")
        End Sub
        Private Sub ChangeForelineValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeForelineValve")
            IBEUtility.Foreline_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeForelineValve")
        End Sub

        Private Sub ChangeHiVacValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeHiVacValve")
            IBEUtility.Turbo_Pump_Gate_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeHiVacValve")
        End Sub

        Private Sub ChangeRoughValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeRoughValve")
            IBEUtility.Rough_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeRoughValve")
        End Sub

        Private Sub ChangeVentValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeVentValve")
            IBEUtility.Vent_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeVentValve")
        End Sub
        Private Sub ChangeScreenMachine(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeRoughValve")
            IBEUtility.Shutter_Position(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeRoughValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeArgonSupplyValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeArgonValve")
            IBEUtility.Gas_Supply_Argon_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeArgonValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>Modify from Oxygen Valve
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangePBNSupplyValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangePBNSupplyValve")
            IBEUtility.Gas_Supply_PBN_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangePBNSupplyValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeArgonValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeArgonValve")
            IBEUtility.Gas_ShutOff_Argon_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeArgonValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>Modify from Oxygen Valve
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangePBNValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangePBNValve")
            IBEUtility.Gas_Shutoff_PBN_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangePBNValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeFlowCoolHeValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeFlowCoolHeValve")
            IBEUtility.Flowcool_Mfc_Shutoff_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeFlowCoolHeValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeFlowCoolHeSupplyValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeFlowCoolHeValve")
            IBEUtility.Flowcool_Mfc_Supply_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeFlowCoolHeValve")
        End Sub

        Private Sub ChangeBaratronValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeBaratronValve")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.BARATRON_VALVE.ToString(), _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeBaratronValve")
        End Sub
#End Region

#Region "Utilities"
        Private Sub DoUpdateRebuildLevel(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter DoUpdateRebuildLevel")
            Try
                If IBE_Equipment IsNot Nothing Then
                    'save to data chamber
                    IBE_Equipment.GridRebuildLevel = Val
                End If

                'save to config
                AVPLib.Utils.SaveGridInfo(Val, Me.EquipmentName, PM_TAG_CONFIG.Grid_RebuildLevel.ToString())
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoUpdateRebuildLevel")
        End Sub

        Private Sub DoUpdateGridID(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter DoUpdateGridID")
            Try
                  If IBE_Equipment IsNot Nothing Then
                    'save to data chamber
                    IBE_Equipment.GridID = Val
                End If

                'save to config
                AVPLib.Utils.SaveGridInfo(Val, Me.EquipmentName, PM_TAG_CONFIG.Grid_ID.ToString())
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoUpdateGridID")
        End Sub

        Private Sub DoUpdateGridSerialNumber(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter DoUpdateGridSerialNumber")
            Try
                If IBE_Equipment IsNot Nothing Then
                    'save to data chamber
                    IBE_Equipment.GridSerialNumber = Val
                End If

                'save to config
                AVPLib.Utils.SaveGridInfo(Val, Me.EquipmentName, PM_TAG_CONFIG.Grid_SerialNumber.ToString())
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoUpdateGridSerialNumber")
        End Sub

        Private Sub DoRateOfRiseForSL(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoRateOfRise")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then


                If val = STR_ON Then
                    '#07/07/2011 
                    '#-	Don’t support Rate Of Rise as Vecco.
                    '#Begin fix:
                    'Dim objIBE As IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                    If MyIBEType = IBEType.AVP_IBE Then
                        ' Default for Interval = 5s, Period = 5min, Desc = SL ROR for AVP_IBE.
                        AVPLib.Business.IBEUtility.SendCommandWithDataToIBE _
                          (Me.EquipmentName, AVPLib.Business.IBECommands.RATE_OF_RISE_INTERVAL_RECORDING.ToString(), _
                           "Interval= " & IBE_Equipment.RateOfRise_Interval & "#Period=" & IBE_Equipment.RateOfRise_Sample & "#Desc=SL ROR#")
                    End If
                    'End fix.

                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.RATE_OF_RISE_STATUS.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.RATE_OF_RISE_STATUS.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Else
                Utils.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If

            AVPLib.Log.coreLogger.Info("Leave DoRateOfRise")
        End Sub

        Private Sub DoPumpdownCurveForSL(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoPumpdownCurve")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then


                If val = STR_ON Then
                    '#07/07/2011 
                    '#-	Don’t support PumpdownCurve as Vecco.
                    '#Begin fix:
                    Dim objIBE As IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                    If MyIBEType = IBEType.AVP_IBE Then
                        ' Default for Interval = 5s, Period = 5min, Desc = SL PDC for AVP_IBE.
                        AVPLib.Business.IBEUtility.SendCommandWithDataToIBE _
                          (Me.EquipmentName, AVPLib.Business.IBECommands.PUMPDOWN_CURVE_INTERVAL_RECORDING.ToString(), _
                           "Interval= " & objIBE.PumpDown_Curve_Interval & "#Period=" & objIBE.PumpDown_Curve_Sample & "#Desc=SL PDC#")
                    End If
                    'End fix.

                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PUMPDOWN_CURVE_STATUS.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PUMPDOWN_CURVE_STATUS.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Else
                Utils.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If

            AVPLib.Log.coreLogger.Info("Leave DoPumpdownCurve")
        End Sub

        Public Sub DoResetSourceUsage(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoResetSourceUsage")
            Dim strChamberID = Me.EquipmentName
            Dim chamber As AVPLib.SystemModule = CType(AVPLib.ContainerData.GetRobotConfig(strChamberID), AVPLib.SystemModule)
            Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(strChamberID)

            ''If PM is AVP-IBE, send command to IBE. Otherwise, just set the source usage value to zero.
            If chamber.PM_DeviceNet Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SOURCE_USAGE_RESET.ToString(), value)
            Else
                objIBE.SourceUsageTimeCurrent = 0
                ' update GUI
                Dim PropertyNames As ArrayList = New ArrayList()
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(objIBE.SourceUsageTimeCurrent)
                PropertyNames.Add("SourceUsageTimeCurrent")
                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(strChamberID, PropertyNames, ReplyValues)
            End If

            AVPLib.Log.coreLogger.Info("Leave DoResetSourceUsage")
        End Sub

        Public Sub DoSetPBNMinutes(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetPBNMinutes")
            Dim strChamberID = Me.EquipmentName
            Dim chamber As AVPLib.SystemModule = CType(AVPLib.ContainerData.GetRobotConfig(strChamberID), AVPLib.SystemModule)
            Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(strChamberID)

            ''If PM is AVP-IBE, send command to IBE. Otherwise, just set the PBN Minutes value to zero.
            If chamber.PM_DeviceNet Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PBN_TIMESET.ToString(), value)
            Else
                objIBE.PBNTimeCurrent = 0
                ' update GUI
                Dim PropertyNames As ArrayList = New ArrayList()
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(objIBE.PBNTimeCurrent)
                PropertyNames.Add("PBNTimeCurrent")
                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(strChamberID, PropertyNames, ReplyValues)
            End If

            AVPLib.Log.coreLogger.Info("Leave DoSetPBNMinutes")
        End Sub

        Private Sub DoPumpPurge(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoPumpPurge")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then


                If val = STR_ON Then
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PUMP_PURGE.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PUMP_PURGE.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Else
                Utils.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoPumpPurge")
        End Sub

        Private Sub DoIGDegas(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoPumpPurge")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then

                If val = STR_ON Then
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.ION_GAUGE_DEGAS.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.ION_GAUGE_DEGAS.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Else
                Utils.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If

            AVPLib.Log.coreLogger.Info("Leave DoPumpPurge")
        End Sub


#End Region

#Region "Chiller"
        ' Chiller
        Private Sub DoSetChillerProcessTemperatureMax(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetChillerProcessTemperatureMax")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CHILLER_PROCESS_TEMPERATURE_MAX.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave DoSetChillerProcessTemperatureMax")
        End Sub

        Private Sub DoSetChillerVentTemperatureMax(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetChillerVentTemperatureMax")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CHILLER_VENT_TEMPERATURE_MAX.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave DoSetChillerVentTemperatureMax")
        End Sub

        Private Sub DoSetChillerVentTemperatureMin(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetChillerVentTemperatureMin")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CHILLER_VENT_TEMPERATURE_MIN.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave DoSetChillerVentTemperatureMin")
        End Sub

        Private Sub DoSetChillerProcessTemperatureMin(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetChillerProcessTemperatureMin")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CHILLER_PROCESS_TEMPERATURE_MIN.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave DoSetChillerProcessTemperatureMin")
        End Sub
        ''
#End Region

#Region "Gas Controller"
        '' val: value of control
        Private Sub SetGasValue(ByVal bCmd As IBECommands, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetGasValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, bCmd.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave SetGasValue")
        End Sub
        '' val: value of control
        Private Sub SetArgOnValue(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetArgOnValue")
            IBEUtility.Gas_Target_Argon_Flowrate(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetArgOnValue")
        End Sub
        '' val: value of control
        Private Sub SetPBNValue(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetPBNValue")
            IBEUtility.Gas_Target_PBN_Flowrate(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetPBNValue")
        End Sub
        '' val: value of control
        Private Sub SetFlowCoolHeValue(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetFlowCoolHeValue")
            IBEUtility.Flowcool_Mfc_Target_Flowrate(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetFlowCoolHeValue")
        End Sub
#End Region

#Region "BACenterControl"
        '' val: value of control
        Private Sub SetCGValue(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetCG2Value")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PIRANI_CHAMBER_ROUGH_PRESSURE.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave SetCG2Value")
        End Sub

        Private Sub DoOpenIG()
            AVPLib.Log.coreLogger.Info("Enter DoOpenIG")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, _
                       IBECommands.ION_GAUGE_STATUS.ToString(), _
                       ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoOpenIG")
        End Sub
        Private Sub DoCloseIG()
            AVPLib.Log.coreLogger.Info("Enter DoCloseIG")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, _
                       IBECommands.ION_GAUGE_STATUS.ToString(), _
                       ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave DoCloseIG")
        End Sub
        '' val: value of control
        Public Sub ChangeIG(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeIG")
            If val = "Close" Then
                DoCloseIG()
            Else
                DoOpenIG()
            End If
            AVPLib.Log.coreLogger.Info("Leave ChangeIG")
        End Sub
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2014-08-21</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoTurnIGOnOff(ByVal data As String)
            AVPLib.Log.coreLogger.Info("Enter DoTurnIGOnOff")
            If data = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.TURN_IG_ON_OFF.ToString(), _
                ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.TURN_IG_ON_OFF.ToString(), _
                ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoTurnIGOnOff")
        End Sub
#End Region

#Region "Power Supply"
        '' val: value of control
        Private Sub SetForwardPowerValue(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetForwardPowerValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.INCIDENT_RF_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave SetForwardPowerValue")
        End Sub
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-08-31 </date>
        ''' </author>
        ''' <summary>
        ''' value of control : ReflectedPowerRight
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub SetReflectedPowerValue(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetReflectedPowerValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.REFLECTED_RF_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave SetReflectedPowerValue")
        End Sub
#End Region

#Region "Beam Power Supply"
        '' val: value of control
        Private Sub SetBeamVoltageValue(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBeamVoltageValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.BEAM_VOLTAGE_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave SetBeamVoltageValue")
        End Sub
        '' val: value of control
        Private Sub SetBeamPowerValue(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBeamPowerValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.BEAM_POWER_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave SetBeamPowerValue")
        End Sub

#End Region

#Region "Suppressor Power Supply"
        '' val: value of control
        Private Sub SetSuppVoltageValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetSuppVoltageValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SUPP_VOLTAGE_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetSuppVoltageValue")
        End Sub
        '' val: value of control
        Private Sub SetSuppPowerValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetSuppPowerValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SUPP_POWER_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetSuppPowerValue")
        End Sub
#End Region

#Region "Body Power Supply"
        '' val: value of control
        Private Sub SetBodyCurrentValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBodyCurrentValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.BODY_CURRENT_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetBodyCurrentValue")
        End Sub
        '' val: value of control
        Private Sub SetBodyVoltageValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBodyVoltageValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.BODY_VOLTAGE_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetBodyVoltageValue")
        End Sub
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-08-31 </date>
        ''' </author>
        ''' <summary>
        ''' value of control : SetBeamCurrentValue
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub SetBeamCurrentValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBeamCurrentValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.BEAM_CURRENT_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetBeamCurrentValue")
        End Sub
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-08-31 </date>
        ''' </author>
        ''' <summary>
        ''' value of control : SetBeamCurrentValue
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub SetSuppressorCurrentValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetSuppressorCurrentValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SUPP_CURRENT_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetSuppressorCurrentValue")
        End Sub
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-08-31 </date>
        ''' </author>
        ''' <summary>
        ''' value of control : SetBodyKFactorValue
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub SetBodyKFactorValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBodyKFactorValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.K_FACTOR_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetBodyKFactorValue")
        End Sub
#End Region

#Region "Discharge Power Supply"
        '' val: value of control
        Private Sub SetDiscCurrentValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetDiscCurrentValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.DISC_CURRENT_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetDiscCurrentValue")
        End Sub
        '' val: value of control
        Private Sub SetDiscVoltageValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetDiscVoltageValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.DISC_VOLTAGE_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetDiscVoltageValue")
        End Sub

#End Region

#Region "Process Recipe"
        Public Sub Process_Reset_Error() Implements IRecipeProcessing.Process_Reset_Error
            AVPLib.Log.coreLogger.Info("Enter PROCESS_CONTROL_DEVICE_RESET_ERROR")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PROCESS_CONTROL_DEVICE_RESET_ERROR.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave PROCESS_CONTROL_DEVICE_RESET_ERROR")
        End Sub

        Public Function ResumeRecipe() As Boolean Implements IRecipeProcessing.ResumeRecipe
            AVPLib.Log.coreLogger.Info("Enter ResumeRecipe")
            Return IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PROCESS_CONTROL_DEVICE_CONTINUE.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave ResumeRecipe")
        End Function

        Public Function SendToPM_CurrentAVPTime() As Boolean Implements IRecipeProcessing.SendToPM_CurrentAVPTime
            AVPLib.Log.coreLogger.Info("Enter SendToPM_CurrentAVPTime")
            Return IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CURRENT_AVP_TIME.ToString(), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff"))
            AVPLib.Log.coreLogger.Info("Leave SendToPM_CurrentAVPTime")
        End Function

        Public Sub StartRecipe_CX(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter StartRecipe")
            Dim PathFrom As String = String.Empty
            Dim PathTo As String = String.Empty
            Dim recipeName, chamberName As String

            'Save recipe name to attr of IBEMaintenance
            Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            objIBE.Recipe = val

            Try
                recipeName = val.Substring(0, val.LastIndexOf("("))
                chamberName = val.Substring(val.LastIndexOf("(") + 1)
                chamberName = chamberName.Substring(0, chamberName.LastIndexOf(")"))
                chamberName = Utils.chamberName2ChamberID(chamberName)
                If (Utils.IsIBEChamber_ANYIBE(chamberName)) Then
                    PathFrom = AVPLib.ContainerDAO.FPath_ChamberRecipe + "\" + RobotConfigurationValues.ANY_IBE_CHAMBER + "\" + _
                                                        AVPLib.Utils.GetFileName(recipeName, "xml")
                Else
                    PathFrom = AVPLib.ContainerDAO.FPath_ChamberRecipe + "\" + chamberName + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")

                End If

                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(chamberName)
                'PathTo = AVPLib.ContainerData.GetDirectoryPath("ProcessRecipe") + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")
                PathTo = serverConfig.RecipeFolder + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")

                StartRecipe(PathFrom, PathTo, True)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
        End Sub
        Public Function StartWarmUp() As Boolean Implements IRecipeProcessing.StartWarmUp
            AVPLib.Log.coreLogger.Info("Enter StartRecipe")
            Dim PathFrom As String = String.Empty
            Dim PathTo As String = String.Empty
            Dim recipeName As String
            Dim bRet As Boolean = False

            recipeName = Utils.GetRecipeWarmUp(Me.EquipmentName).Trim(" ")

            'Save recipe name to attr of IBEMaintenance
            Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            objIBE.Recipe = recipeName

            Try
                If (Utils.IsIBEChamber_ANYIBE(Me.EquipmentName)) Then
                    PathFrom = AVPLib.ContainerDAO.FPath_ChamberRecipe + "\" + RobotConfigurationValues.ANY_IBE_CHAMBER + "\" + _
                                                        AVPLib.Utils.GetFileName(recipeName, "xml")
                Else
                    PathFrom = AVPLib.ContainerDAO.FPath_ChamberRecipe + "\" + Me.EquipmentName + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")

                End If

                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(Me.EquipmentName)
                'PathTo = AVPLib.ContainerData.GetDirectoryPath("ProcessRecipe") + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")
                PathTo = serverConfig.RecipeFolder + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")

                IBEUtility.SetWaferStatusToIBE(Me.EquipmentName, ConstEnum.enumWaferStatus.eWaferNew)

                bRet = StartRecipe(PathFrom, PathTo, True)
                If bRet Then
                    objIBE.WarmUpState = RunningState.Running
                Else
                    objIBE.WarmUpState = RunningState.Error
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
            Return bRet
        End Function

        Public Function StartRecipe_SL(ByVal val As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter StartRecipe")
            Dim PathFrom As String = String.Empty
            Dim PathTo As String = String.Empty
            Dim recipeName, chamberName As String

            'Save recipe name to attr of IBEMaintenance
            Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
            objIBE.Recipe = val
            '#06/11/2011 
            '#- Need to logs what recipe user ran
            '#Begin fix
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                            "[Main Screen]" & " - User ran recipe: " & val)
            '#End fix.
            Try
                recipeName = val
                chamberName = AVPLib.ConstEnum.Equipments.Chamber1.ToString()

                PathFrom = AVPLib.ContainerDAO.FPath_ChamberRecipe + "\" + chamberName + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")

                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(chamberName)
                PathTo = serverConfig.RecipeFolder + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")
                Return StartRecipe(PathFrom, PathTo, True)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
            Return False
        End Function

        Function CopyRecipeFile(ByVal pathFrom As String, ByVal pathTo As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CopyRecipeFile")
            Dim bRet As Boolean = False
            Try
                Const kPrcExt As String = ".prc"
                pathFrom = System.IO.Path.ChangeExtension(pathFrom, kPrcExt)
                pathTo = System.IO.Path.ChangeExtension(pathTo, kPrcExt)
                If (AVPLib.Utils.CopyFile(pathFrom, pathTo)) Then
                    CopyStepFile(pathFrom, pathTo)
                    bRet = True
                Else
                    'Utils.ThrowAlarm("Couldn't find the recipe: " & pathFrom)
                    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentCouldNotCopyRecipe"), _
                                       Utils.chamberID2ChamberName(Me.EquipmentName), "'" & Utils.GetFileName(pathFrom, True) & "'"))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CopyRecipeFile")
            Return bRet
        End Function

        Public Function StartRecipe(ByVal pathFrom As String, ByVal pathTo As String, ByVal bSetRecipeNameAndStartCmd As Boolean) As Boolean Implements IRecipeProcessing.StartRecipe
            AVPLib.Log.coreLogger.Info("Enter StartRecipe")
            Dim bRet As Boolean = False
            Try
                Dim errorMessage As String = String.Empty

                Try
                    Dim strNewPath As String = ChangeRecipeXMLFormat(pathFrom)

                    If System.IO.File.Exists(strNewPath) Then
                        bRet = AVPLib.Utils.CopyFile(strNewPath, pathTo)
                    Else
                        errorMessage = String.Format(ContainerData.GetMessageText("EquipmentRecipeIsNotExist"), Utils.GetFileName(pathFrom, True))
                    End If
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try

                If bRet = False Then
                    If String.IsNullOrEmpty(errorMessage) Then
                        errorMessage = String.Format(ContainerData.GetMessageText("EquipmentCouldNotCopyRecipe"), _
                                                     Utils.GetFileName(pathFrom, True), Utils.chamberID2ChamberName(Me.EquipmentName))
                    End If

                    Utils.ThrowAlarm(errorMessage)
                    '''Get status from PM
                    SendRequestAllData()
                    Return False
                End If

                'AVP IBE ONLY SEND RECIPE NAME
                'SET RECIPE NAME
                'AND START SEND DATA RUN FILE NAME
                If (MyIBEType = IBEType.AVP_IBE) Then
                    If (bSetRecipeNameAndStartCmd) Then
                        If SetRecipeName(pathTo) Then
                            StartSendDataRunFileName()
                            bRet = StartProcessing()
                        Else
                            Utils.ThrowAlarm("Failed to set Recipe Name for " + Utils.chamberID2ChamberName(EquipmentName))
                            Return False
                        End If
                    End If
                Else
                    'VEECO IBE SEND .PRC AND STEP FILE 
                    Const kPrcExt As String = ".Prc" '".prc"
                    pathFrom = System.IO.Path.ChangeExtension(pathFrom, kPrcExt)
                    pathTo = System.IO.Path.ChangeExtension(pathTo, kPrcExt)

                    If (AVPLib.Utils.CopyFile(pathFrom, pathTo)) Then
                        CopyStepFile(pathFrom, pathTo)
                    Else
                        Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentCouldNotCopyRecipe"), _
                                         Utils.chamberID2ChamberName(Me.EquipmentName), "'" & Utils.GetFileName(pathFrom, True) & "'"))
                        Return False
                    End If

                    If (bSetRecipeNameAndStartCmd) Then
                        If SetRecipeName(pathTo) Then
                            bRet = StartProcessing()
                        Else
                            Utils.ThrowAlarm("Failed to set Recipe Name for " + Utils.chamberID2ChamberName(EquipmentName))
                            Return False
                        End If
                    End If
                End If


                bRet = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
            Return bRet
        End Function

        Public Function StartSendDataRunFileName() As Boolean
            AVPLib.Log.coreLogger.Info("Enter StartSendDataRun")
            Dim obj As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Dim filenameWaferRun As String = String.Empty
            Dim waferInfo As AVPWaferInfo = obj.WaferInfo
            If waferInfo Is Nothing Then
                AVPLib.Log.avpLogger.Error("Wafer Information is nothing, then couldn't make Run Data File Name.")
                Return False
            Else
                Dim LLName As String = String.Empty
                If waferInfo.WaferID.Contains("A") Then
                    LLName = ConstEnum.LLA_STR
                End If
                Dim strFolderName As String = DateTime.Now.ToString("yyyy_MM_dd")
                Dim strFolderPath As String = ContainerDAO.FPath_RunDataOfWafer & "\" & strFolderName

                If Not System.IO.Directory.Exists(strFolderPath) Then
                    Try
                        System.IO.Directory.CreateDirectory(strFolderPath)
                    Catch ex As IO.IOException
                        Utils.ThrowAlarm("Failed to created folder for Wafer Run:" & strFolderPath)
                        Return False
                    End Try
                End If

                'GEMWaferID#2010_09_24_01_48_45           LLA_12    PM2.xml
                filenameWaferRun = Utils.GetGEMWaferID(waferInfo.WaferID) & "#" & strFolderName & "\" & _
                   DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") & ConstEnum.DataRunFileNameSeparator & LLName & "_" & _
                       waferInfo.SlotID & ConstEnum.DataRunFileNameSeparator & Utils.chamberID2ChamberName(Me.EquipmentName)
                If (Not IBEUtility.Process_Control_Run_Data_File_Name(Me.EquipmentName, filenameWaferRun)) Then
                    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentCouldNotSendRunDatFile"), _
                                      Utils.chamberID2ChamberName(Me.EquipmentName), filenameWaferRun))
                Else
                    Return True
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave StartSendDataRun")
            Return False
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-28</date>
        ''' </author>
        ''' <summary>
        ''' Copy Step File from source master file to Destination master file
        ''' pathFrom: Source master file
        ''' pathTo: Destination master file
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CopyStepFile(ByVal pathFrom As String, ByVal pathTo As String)
            AVPLib.Log.coreLogger.Info("Enter CopyStepFile")
            Try
                Dim line As String = String.Empty
                Dim newPathFile As String = String.Empty
                newPathFile = pathTo.Replace(AVPLib.Utils.GetFileName(pathTo, False), "") ''remove project file name of new path
                Dim oldPathFile As String = String.Empty
                oldPathFile = pathFrom.Replace(AVPLib.Utils.GetFileName(pathFrom, False), "") ''remove project file name of old path

                Const strStpExt As String = ".Stp" '".stp"

                Using sr As System.IO.StreamReader = New System.IO.StreamReader(pathFrom)
                    Do
                        line = sr.ReadLine()
                        If line IsNot Nothing Then
                            If line.Contains("Step_") Then
                                Dim StepName As String = line.Substring(line.IndexOf("=") + 1)
                                StepName = StepName & strStpExt
                                AVPLib.Utils.CopyFile(oldPathFile & StepName, newPathFile & StepName)
                            End If
                        End If
                    Loop Until line Is Nothing
                End Using
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                'Utils.ThrowAlarm("Can not copy files to this path: " & pathTo)
                Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentCouldNotCopyFile"), pathTo))
            End Try
            AVPLib.Log.coreLogger.Info("Leave CopyStepFile")
        End Sub

        Public Function StopRecipe() As Boolean Implements IRecipeProcessing.StopRecipe
            AVPLib.Log.coreLogger.Info("Enter StopRecipe")
            Dim ibeChamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            ibeChamber.IsAbortInProcess = True
            Dim bResult As Boolean = IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PROCESS_CONTROL_DEVICE_STOP.ToString(), String.Empty)
            'Send reset error to clear command for start button to return to normal
            Thread.Sleep(1000)
            If bResult Then
                bResult = IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PROCESS_CONTROL_DEVICE_RESET_ERROR.ToString(), String.Empty)
            End If
            AVPLib.Log.coreLogger.Info("Leave StopRecipe")
            Return bResult
        End Function

        Public Function EndCurrentStepRecipe() As Boolean
            AVPLib.Log.coreLogger.Info("Enter EndCurrentStepRecipe")
            Dim ibeChamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            ibeChamber.IsAbortInProcess = True
            Dim bResult As Boolean = IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PROCESS_CONTROL_DEVICE_END_STEP.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave EndCurrentStepRecipe")
            Return bResult
        End Function

        Public Function PauseRecipe() As Boolean Implements IRecipeProcessing.PauseRecipe
            AVPLib.Log.coreLogger.Info("Enter PauseRecipe")
            Return IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PROCESS_CONTROL_DEVICE_PAUSE.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave PauseRecipe")
        End Function

        Public Function SetRecipeName(ByVal val As String) As Boolean Implements IRecipeProcessing.SetRecipeName
            AVPLib.Log.coreLogger.Info("Enter SendToProcessRecipeValue")
            val = Utils.GetFileName(val, True) ''cut file path and ext of file
            AVPLib.Log.coreLogger.Info("Leave SendToProcessRecipeValue")
            Return IBEUtility.Process_Control_Name(Me.EquipmentName, val)
        End Function

        Public Function SetDataRunFileName(ByVal val As String) As Boolean Implements IRecipeProcessing.SetDataRunFileName
            Return IBEUtility.Process_Control_Run_Data_File_Name(Me.EquipmentName, val)
        End Function

        Public Function SetIsoValveStatus(ByVal strVal As String) As Boolean Implements IRecipeProcessing.SetIsoValveStatus
            Return IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, _
                                                    IBECommands.ISOLATION_VALVE.ToString(), _
                                                    strVal)
        End Function

        Public Function StartProcessing() As Boolean Implements IRecipeProcessing.StartProcessing
            AVPLib.Log.coreLogger.Info("Enter StartRecipe")
            Dim bResult As Boolean = False
            Dim chamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            chamber.PreStartProcessing()
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                SendToPM_CurrentAVPTime()
                If (IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PROCESS_CONTROL_DEVICE_START.ToString(), String.Empty)) Then
                    chamber.IsProcessRunning = True
                    bResult = True
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
            Return bResult
        End Function

        Public Function StartProcessingCycleATM(ByVal val As String) As Boolean Implements IRecipeProcessing.StartProcessingCycleATM
            AVPLib.Log.coreLogger.Info("Enter StartRecipe")
            Dim bResult As Boolean = False
            If (IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PROCESS_CYCLEATM_START.ToString(), val)) Then
                bResult = True
            End If
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
            Return bResult
        End Function

        ''<name> Dy Do </name>
        ''<date> 2016-01-27</date>
        ''</author>
        ''<summary>
        ''</summary>
        Public Sub SendResultOfCopyRecipeTemplate(ByVal blnResult As Boolean) Implements IRecipeProcessing.SendResultOfCopyRecipeTemplate
            AVPLib.Log.coreLogger.Info("Enter SendResultOfCopyRecipeTemplate")
            IBEUtility.SendCommandWithDataToIBE(EquipmentName, IBECommands.COPYRECIPE_TEMPLATE.ToString(), _
                    IIf(blnResult, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave SendResultOfCopyRecipeTemplate")
        End Sub
#End Region

#Region "Chamber Interlock"
        ' Chamber Interlock is readonly.
        'Private Sub ChangeChamberInterFixtureWater(ByVal bOpen As String)
        '    IBEUtility.SendCommandWithDataToIBE(IBECommands.CHAMBER_INTER_FIXTURE_WATER_READBACK.ToString(), IIf(bOpen, STRING_VALVE_ON, STRING_VALVE_OFF))
        'End Sub
        'Private Sub ChangeChamberInterSourceWater(ByVal bOpen As String)
        '    IBEUtility.SendCommandWithDataToIBE(IBECommands.CHAMBER_INTER_SOURCE_WATER_READBACK.ToString(), IIf(bOpen, STRING_VALVE_ON, STRING_VALVE_OFF))
        'End Sub
        'Private Sub ChangeChamberInterTargetWater(ByVal bOpen As String)
        '    IBEUtility.SendCommandWithDataToIBE(IBECommands.CHAMBER_INTER_TARGET_WATER_READBACK.ToString(), IIf(bOpen, STRING_VALVE_ON, STRING_VALVE_OFF))
        'End Sub
        'Private Sub ChangeChamberInterPress(ByVal bOpen As String)
        '    IBEUtility.SendCommandWithDataToIBE(IBECommands.CHAMBER_INTER_PRESS_READBACK.ToString(), IIf(bOpen, STRING_VALVE_ON, STRING_VALVE_OFF))
        'End Sub
        'Private Sub ChangeChamberInterForeline(ByVal bOpen As String)
        '    IBEUtility.SendCommandWithDataToIBE(IBECommands.CHAMBER_INTER_FORELINE_READBACK.ToString(), IIf(bOpen, STRING_VALVE_ON, STRING_VALVE_OFF))
        'End Sub
        'Private Sub ChangeChamberInterMagnetWater(ByVal bOpen As String)
        '    IBEUtility.SendCommandWithDataToIBE(IBECommands.CHAMBER_INTER_MAGNET_WATER_READBACK.ToString(), IIf(bOpen, STRING_VALVE_ON, STRING_VALVE_OFF))
        'End Sub

        'Private Sub ChangeChamberInterTurboWater(ByVal bOpen As String)
        '    IBEUtility.SendCommandWithDataToIBE(IBECommands.CHAMBER_INTER_TURBO_WATER_READBACK.ToString(), IIf(bOpen, STRING_VALVE_ON, STRING_VALVE_OFF))
        'End Sub
#End Region

#Region "Fixture Control"
#Region "Fixture"
        Private Sub DoFixtureClampOn()
            AVPLib.Log.coreLogger.Info("Enter DoFixtureClamp")
            IBEUtility.Fixture_Clamp(Me.EquipmentName, ConfigurationValues.DEVICE_CLAMP_UP)
            AVPLib.Log.coreLogger.Info("Leave DoFixtureClamp")
        End Sub

        Private Sub DoFixtureUnClamp()
            AVPLib.Log.coreLogger.Info("Enter DoFixtureUnClamp")
            IBEUtility.Fixture_Clamp(Me.EquipmentName, ConfigurationValues.DEVICE_CLAMP_DOWN)
            AVPLib.Log.coreLogger.Info("Leave DoFixtureUnClamp")
        End Sub

        Private Sub DoFixtureHomeTiltAxis()
            AVPLib.Log.coreLogger.Info("Enter DoFixtureHomeTiltAxis")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_HOME_TILT_AXIS.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave DoFixtureHomeTiltAxis")
        End Sub

        Private Sub DoFixtureHomeRotationAxis()
            AVPLib.Log.coreLogger.Info("Enter DoFixtureHomeRotationAxis")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_HOME_ROTATION_AXIS.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave DoFixtureHomeRotationAxis")
        End Sub

        Private Sub DoFixtureStartRotationAxis()
            AVPLib.Log.coreLogger.Info("Enter DoFixtureStartRotationAxis")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_START_ROTATION_AXIS.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave DoFixtureStartRotationAxis")
        End Sub

        Private Sub DoFixtureHomeAllAxis()
            AVPLib.Log.coreLogger.Info("Enter DoFixtureHomeAllAxis")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_HOME_ALL_AXIS.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave DoFixtureHomeAllAxis")
        End Sub

        Private Sub DoFixtureStopAllAxis()
            AVPLib.Log.coreLogger.Info("Enter DoFixtureStopAllAxis")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_STOP_ALL_AXIS.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave DoFixtureStopAllAxis")
        End Sub

        Private Sub DoFixtureOpenShutter(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoFixtureOpenShutter")
            Dim iBEMaintenance As IBEChamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            If value.ToString() = STR_ON Then
                value = ConfigurationValues.DEVICE_STATUS_OPEN
            Else
                value = ConfigurationValues.DEVICE_STATUS_CLOSED
            End If
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SHUTTER_POSITION.ToString(), value)
            AVPLib.Log.coreLogger.Info("Leave DoFixtureOpenShutter")
        End Sub

        Private Sub DoFixtureOpenWaterValve()
            AVPLib.Log.coreLogger.Info("Enter DoFixtureOpenWaterValve")
            Dim iBEMaintenance As IBEChamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_WATER_VALVE.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave DoFixtureOpenWaterValve")
        End Sub

        Private Sub DoFixtureOpenFlowCool()
            AVPLib.Log.coreLogger.Info("Enter DoFixtureOpenFlowCool")
            Dim iBEMaintenance As IBEChamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_FLOWCOOL_PUMP_POWER.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave DoFixtureOpenFlowCool")
        End Sub

        Private Sub DoMotionInitialize(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter DoMotionInitialize")
            If Val = STR_ON Then
                IBEUtility.Initialize_Motion(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.Initialize_Motion(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoMotionInitialize")
        End Sub

#End Region
        '' val: value of control
        Private Sub SetTiltAngleValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetTiltAngleValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_TILT_ANGLE.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetTiltAngleValue")
        End Sub
        '' val: value of control
        Private Sub SetStaticRotationAngle(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetTiltAngleValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_STATIC_ROTATION_ANGLE.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetTiltAngleValue")
        End Sub
        '' val: value of control
        Private Sub SetRotationStartAngle(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetSweepRotation")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_ROTATION_START_ANGLE.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetSweepRotation")
        End Sub
        '' val: value of control
        Private Sub SetRotationEndAngle(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetSweepRotationLast")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_ROTATION_END_ANGLE.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetSweepRotationLast")
        End Sub
        '' val: value of control
        Private Sub SetContinuousRotationRPM(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetContinuousRotationRPM")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_CONTINUOUS_ROTATION_RPM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetContinuousRotationRPM")
        End Sub
        '' val: value of control
        Private Sub SetRotationModeValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetRotationModeValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_ROTATION_MODE.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetRotationModeValue")
        End Sub
        '' val: value of control
        Private Sub SetStartRotationAxis(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetStartRotationAxis")
            If Val = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_START_ROTATION_AXIS.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            ElseIf Val = STR_OFF Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_START_ROTATION_AXIS.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            Else 'Home'
                SetHomeRotationAxis(ConfigurationValues.DEVICE_STATUS_STOPPED) 'Val = 02'
            End If
            AVPLib.Log.coreLogger.Info("Leave SetStartRotationAxis")
        End Sub
        '' val: value of control
        Private Sub SetHomeRotationAxis(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetHomeRotationAxis")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_START_ROTATION_AXIS.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetHomeRotationAxis")
        End Sub
        '' val: value of control
        Private Sub SetCoolingWater(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetCoolingWater")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_WATER_VALVE.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetCoolingWater")
        End Sub
        '' val: value of control
        Private Sub SetPumpPower(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetPumpPower")
            If Val = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_FLOWCOOL_PUMP_POWER.ToString(), _
                ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_FLOWCOOL_PUMP_POWER.ToString(), _
                ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave SetPumpPower")
        End Sub
        '' val: value of control
        Private Sub SetUnProtected(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetUnProtected")
            If Val = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_UNPROTECTED.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_UNPROTECTED.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                AVPLib.Log.coreLogger.Info("Leave SetUnProtected")
            End If
        End Sub

        '' val: value of control
        Private Sub SetTiltSweepValue(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetTiltSweepValue")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_SWEEP_TILT_ANGLE.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetTiltSweepValue")
        End Sub

        '' val: value of control
        Private Sub SetTiltSweepStartAngle(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetTiltSweepStartAngle")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_SWEEP_TILT_START_ANGLE.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetTiltSweepStartAngle")
        End Sub

        '' val: value of control
        Private Sub SetTiltSweepEndAngle(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetTiltSweepEndAngle")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_SWEEP_TILT_END_ANGEL.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetTiltSweepEndAngle")
        End Sub

        '' val: value of control
        Private Sub SetIGFilament1(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetIGFilament1")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SWITCH_IG_FILAMENT_PROGRAM.ToString(), 1)
            AVPLib.Log.coreLogger.Info("Leave SetIGFilament1")
        End Sub

        '' val: value of control
        Private Sub SetIGFilament2(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetIGFilament2")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SWITCH_IG_FILAMENT_PROGRAM.ToString(), 2)
            AVPLib.Log.coreLogger.Info("Leave SetIGFilament2")
        End Sub

        '' val: value of control
        Private Sub SetSourceEMCurrent(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetSourceEMCurrent")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SOURCE_EM_CURRENT_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetSourceEMCurrent")
        End Sub

        '' val: value of control
        Private Sub SetSourceEMCurrentBeamParam(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetSourceEMCurrentBeamParam")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SOURCE_EM_CURRENT_AUTO_BEAM_PROGRAM.ToString(), Val)
            AVPLib.Log.coreLogger.Info("Leave SetSourceEMCurrentBeamParam")
        End Sub

        Private Sub ClearAllAlarm(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter ClearAllAlarm")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CLEAR_ALL_ALARM_PROGRAM.ToString(), 1)
            AVPLib.Log.coreLogger.Info("Leave ClearAllAlarm")
        End Sub
#End Region

#Region "Menu On Machine"
        Private Sub DoOffline()
            AVPLib.Log.coreLogger.Info("Enter DoOffline")
            m_EventStopThread.Set()
            Me.RaiseFinishOnline(False)
            AVPLib.Log.coreLogger.Info("Leave DoOffline")
        End Sub
        Private Sub DoOnline(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoOnline")
            Try
                If Not String.IsNullOrEmpty(strVal) Then
                    Boolean.TryParse(strVal, m_blnThrowAlarm_When_Online)
                End If
                trdToolOnline = New Thread(AddressOf OnlineProc)
                m_EventStopThread.Reset()
                trdToolOnline.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoOnline")
        End Sub
        'strVal = On/Off
        Private Sub DoAutoPumpDown(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoAutoPumpDown")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then

                If strVal = STR_ON Then
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.AUTO_PUMP_DOWN.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.AUTO_PUMP_DOWN.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoAutoPumpDown")
        End Sub
        'strVal = On/Off
        Private Sub DoAutoVent(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoAutoVent")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then

                If strVal = STR_ON Then
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.AUTO_VENT.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.AUTO_VENT.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoAutoVent")
        End Sub
        'strVal = On/Off
        Private Sub DoCryoPower(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoCryoPower")
            If strVal = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_POWER.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_POWER.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoCryoPower")
        End Sub
        'strVal = On/Off
        Private Sub DoCryoRegenValve(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoCryoRegenValve")
            If strVal = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_REGEN_VALVE.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_REGEN_VALVE.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoCryoRegenValve")
        End Sub
        'strVal = On/Off
        Private Sub DoCryoPurgeValve(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoCryoPurgeValve")
            If strVal = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_PURGE_VALVE.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_PURGE_VALVE.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoCryoPurgeValve")
        End Sub
        'strVal = On/Off
        Private Sub DoCryoAutoRegen(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoCryoAutoRegen")
            If strVal = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_AUTO_REGEN.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_AUTO_REGEN.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoCryoAutoRegen")
        End Sub
        'strVal = On/Off
        Private Sub DoCryoAutoPowerDown(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoCryoAutoPowerDown")
            If strVal = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_AUTO_POWER_DOWN.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_AUTO_POWER_DOWN.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoCryoAutoPowerDown")
        End Sub
        'strVal = On/Off
        Private Sub DoWaterPump(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoWaterPump")
            If strVal = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_POWER.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_POWER.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoWaterPump")
        End Sub
        'strVal = On/Off
        Private Sub DoWaterPumpRegen(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoWaterPumpRegen")
            If strVal = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.WATER_PUMP_REGEN.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.WATER_PUMP_REGEN.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoWaterPumpRegen")
        End Sub

        Private Sub DoSetATMForelineCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetATMForelineCG")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FORELINE_CG_ATM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetATMForelineCG")
        End Sub

        Private Sub DoSetVACForelineCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetVACForelineCG")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FORELINE_CG_VAC.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetVACForelineCG")
        End Sub

        Private Sub DoSetATMRoughPumpCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetATMRoughPumpCG")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.ROUGH_PUMP_CG_ATM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetATMRoughPumpCG")
        End Sub

        Private Sub DoSetVACRoughPumpCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetVACRoughPumpCG")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.ROUGH_PUMP_CG_VAC.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetVACRoughPumpCG")
        End Sub

        Private Sub DoSetATMPressureCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetATMPressureCG")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PRESSURE_CG_ATM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetATMPressureCG")
        End Sub

        Private Sub DoSetVACPressureCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetVACPressureCG")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.PRESSURE_CG_VAC.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetVACPressureCG")
        End Sub

        Private Sub SetCryo_Extended_PurgeTime(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Extended_PurgeTime")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_EXTENDED_PURGE_TIME & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Extended_PurgeTime")
        End Sub
        Private Sub SetCryo_Pump_Restart_Delay(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Pump_Restart_Delay")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_PUMP_RESTART_DELAY & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Pump_Restart_Delay")
        End Sub
        Private Sub SetCryo_Rate_Of_Rise(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Rate_Of_Rise")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_RATE_OF_RISE & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Rate_Of_Rise")
        End Sub
        Private Sub SetCryo_Repurge_Cycles(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Repurge_Cycles")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_REPURGE_CYCLES & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Repurge_Cycles")
        End Sub
        Private Sub SetCryo_Rough_To_Pressure(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Rough_To_Pressure")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_ROUGH_TO_PRESSURE & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Rough_To_Pressure")
        End Sub
        Private Sub SetCryo_Start_Up_Time(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Start_Up_Time")
            IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_START_UP_TEMPERATURE & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Start_Up_Time")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-04</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoRoughPump(ByVal data As String)
            AVPLib.Log.coreLogger.Info("Enter DoOpenRoughPump")
            If data = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.ROUGH_PUMP_POWER.ToString(), _
                ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.ROUGH_PUMP_POWER.ToString(), _
                ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoOpenRoughPump")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-04</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoTurboPump(ByVal data As String)
            AVPLib.Log.coreLogger.Info("Enter DoOpenTurboPump")
            If data = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.TURBO_PUMP_POWER.ToString(), _
                ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.TURBO_PUMP_POWER.ToString(), _
                ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoOpenTurboPump")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-04</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoFixtureFlowCool(ByVal data As String)
            AVPLib.Log.coreLogger.Info("Enter DoFixtureFlowCool")
            If data = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_FLOWCOOL_PUMP_POWER.ToString(), _
                ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_FLOWCOOL_PUMP_POWER.ToString(), _
                ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoFixtureFlowCool")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-04</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoFixtureWaterValve(ByVal data As String)
            AVPLib.Log.coreLogger.Info("Enter DoFixtureWaterValve")
            If data = STR_ON Then
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_WATER_VALVE.ToString(), _
                ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_WATER_VALVE.ToString(), _
                ConfigurationValues.DEVICE_STATUS_CLOSED)
            End If
            AVPLib.Log.coreLogger.Info("Leave DoFixtureWaterValve")
        End Sub
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-09-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Public Function DoSetWaferStatus(ByVal strStatus As String) As Boolean Implements IRecipeProcessing.DoSetWaferStatus
            AVPLib.Log.coreLogger.Info("Enter DoSetWaferStatus")

            If MyIBEType = IBEType.AVP_IBE Then
                Dim blnResult As Boolean = False
                blnResult = IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.WAFER_IN_FIXTURE.ToString(), strStatus)
                If blnResult = False Then
                    Return False
                End If
                If strStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNone.ToString() Then ''if clear Wafer, 
                    Return True
                End If
                Return IBEUtility.SetWaferStatusToIBE(Me.EquipmentName, strStatus)
            ElseIf MyIBEType = IBEType.VEECO_IBE Then
                'DungN
                Return IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.WAFER_IN_FIXTURE.ToString(), strStatus)
            End If

            AVPLib.Log.coreLogger.Info("Leave DoSetWaferStatus")
        End Function

        ''<name> Le Hieu Truc </name>
        ''<date> 2008-02-20</date>
        ''</author>
        ''<summary>
        ''Message can be 5 type:
        ''1.PowerSupply.ForwardPower1 Value_of_Textbox
        ''2.ChamberInterlock.ChamberPress On
        ''3.ProcessRecipe.Start
        ''4.ValveVent On
        ''5.OnClamp
        ''' DoTaskIBE: PnlName: Panel Name; CtrlName: Control Name; Val: Action or Value
        Public Sub ParseMessage(ByVal Message As String, ByRef strCtrlName As String, ByRef strPnlName As String, ByRef strVal As String)
            AVPLib.Log.coreLogger.Info("Enter parseMessage")
            Try

                Dim MatchResults As Match
                If (Regex.IsMatch(Message, STRING_TYPE1)) Then
                    ''1.PowerSupply.ForwardPower1 Value_of_Textbox
                    ''2.ChamberInterlock.ChamberPress On
                    MatchResults = Regex.Match(Message, STRING_TYPE1)
                    strPnlName = MatchResults.Groups(1).Value
                    strCtrlName = MatchResults.Groups(2).Value
                    strVal = MatchResults.Groups(3).Value

                ElseIf (Regex.IsMatch(Message, STRING_TYPE2)) Then
                    ''3.ProcessRecipe.Start
                    MatchResults = Regex.Match(Message, STRING_TYPE2)
                    strPnlName = MatchResults.Groups(1).Value
                    strCtrlName = MatchResults.Groups(2).Value

                ElseIf (Regex.IsMatch(Message, STRING_TYPE3)) Then
                    ''4.ValveVent On
                    MatchResults = Regex.Match(Message, STRING_TYPE3)
                    strCtrlName = MatchResults.Groups(1).Value
                    strVal = MatchResults.Groups(2).Value
                ElseIf (Regex.IsMatch(Message, STRING_TYPE4)) Then
                    ''5.OnClamp
                    MatchResults = Regex.Match(Message, STRING_TYPE4)
                    strCtrlName = MatchResults.Groups(1).Value
                ElseIf (Regex.IsMatch(Message, STRING_TYPE5)) Then
                    MatchResults = Regex.Match(Message, STRING_TYPE5)
                    strCtrlName = MatchResults.Groups(1).Value
                    strVal = MatchResults.Groups(2).Value
                Else
                    AVPLib.Log.avpLogger.Error("Can not parse " & Message)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave parseMessage")
        End Sub
#End Region

#Region "Power Status Panel"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-08</date>
        ''' </author>
        ''' <summary>
        ''' send comand to IBE from Power button on Power Panel
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub DoPowerPanel(ByVal ctrlName As String, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoPowerPanel")
            Dim bOpen As Boolean = False
            If (val = STR_ON) Then
                bOpen = True
            End If
            Select Case ctrlName
                Case "SourceManualPower"
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SOURCE_MANUAL_AUTO_POWER.ToString(), _
                       ConfigurationValues.DEVICE_STATUS_CLOSED)
                Case "SourceAutoPower"
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SOURCE_MANUAL_AUTO_POWER.ToString(), _
                       ConfigurationValues.DEVICE_STATUS_OPEN)
                Case "ACPower"
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SOURCE_AC_POWER.ToString(), _
                       IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED))
                Case "GridPower"
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SOURCE_GRID_POWER.ToString(), _
                       IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED))
                Case "RFPower"
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SOURCE_RF_POWER.ToString(), _
                       IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED))
                Case "PBNPower"
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SOURCE_PBN_POWER.ToString(), _
                       IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED))
                Case "NeurPower"
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SOURCE_NEUR_POWER.ToString(), _
                       IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED))
                Case "AutoBeam"
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.AUTO_BEAM.ToString(), _
                       IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED))
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoPowerPanel")
        End Sub
#End Region

#Region "PumpDown_RateOfRise"
        Public Overrides Sub RecoverPressure()
            AVPLib.Log.coreLogger.Info("Enter RecoverPressure")
            Try
                m_RoutineExecutor.ActiveRoutine = ConstEnum.RoutineType.RecoverPressure
                m_RoutineExecutor.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RecoverPressure")
        End Sub

        Public Overrides Sub StopRecoverPressure()
            AVPLib.Log.coreLogger.Info("Enter StopRecoverPressure")
            Try
                With m_RoutineExecutor
                    .SampleTime = 0
                    .WaitTime = 0
                    .Description = String.Empty
                End With
                m_RoutineExecutor.Terminate()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopRecoverPressure")
        End Sub

        Private Sub DoRateOfRise()
            AVPLib.Log.coreLogger.Info("Enter DoRateOfRise")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                '#07/07/2011 
                '#-	Don’t support Rate Of Rise as Vecco.
                '#Begin fix:
                If MyIBEType = IBEType.AVP_IBE Then
                    If IBEUtility.Start_Rate_Of_Rise(Me.EquipmentName, _
                                                                           PDC_ROR_SampleTime.ToString(), PDC_ROR_WaitTime.ToString(), PDC_ROR_Description) Then
                        m_EventPumpDownAborted.Reset()
                    Else
                        Me.ThrowAlarm("Failed to start Rate Of Rise for " + Utils.chamberID2ChamberName(EquipmentName))
                    End If
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoRateOfRise")
        End Sub

        Private Sub DoStopRateOfRise()
            AVPLib.Log.coreLogger.Info("Enter DoStopRateOfRise")
            If Not IBEUtility.Stop_Rate_Of_Rise(Me.EquipmentName) Then
                Me.ThrowAlarm("Failed to set stop Rate of Rise for " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoStopRateOfRise")
        End Sub

        Private Sub DoPumpdownCurve()
            AVPLib.Log.coreLogger.Info("Enter DoPumpdownCurve")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If IBEUtility.Start_PumpDown_Curve(Me.EquipmentName, _
                                                                       PDC_ROR_SampleTime.ToString(), PDC_ROR_WaitTime.ToString(), PDC_ROR_Description) Then
                    m_EventPumpDownAborted.Reset()
                Else
                    Me.ThrowAlarm("Failed to start Pump Down Curve for " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoPumpdownCurve")
        End Sub

        Private Sub DoStopPumpdownCurve()
            AVPLib.Log.coreLogger.Info("Enter DoStopPumpdownCurve")
            If IBEUtility.Stop_PumpDown_Curve(Me.EquipmentName) Then
                m_EventPumpDownAborted.Set()
            Else
                Me.ThrowAlarm("Failed to set stop Pump Down Curve for " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoStopPumpdownCurve")
        End Sub
#End Region

#Region "Reset Quart/Usage"
        Public Sub DoResetQuartz(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoResetQuartz")
            Try
                If IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.QUART_KWH.ToString(), value) = False Then
                    Me.ThrowAlarm("Failed to reset Quart value " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoResetQuartz")
        End Sub
#End Region
#Region "DoSourceUsageCoverFixtureShield"
        Public Sub DoSourceUsageCoverFixtureShield(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoSourceUsageCoverFixtureShield")
            Try
                If IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.COVER_FIXTURE_SHIELD_USAGE.ToString(), value) = False Then
                    Me.ThrowAlarm("Failed to DoSourceUsageCoverFixtureShield " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoSourceUsageCoverFixtureShield")
        End Sub
#End Region
#Region "DoWaferClampUsage"
        Public Sub DoWaferClampUsage(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoWaferClampUsage")
            Try
                If IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.WAFER_CLAMP_USAGE.ToString(), value) = False Then
                    Me.ThrowAlarm("Failed to DoWaferClampUsage " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoWaferClampUsage")
        End Sub
#End Region

#Region "DoTopFixtureShieldUsage"
        Public Sub DoTopFixtureShieldUsage(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoTopFixtureShieldUsage")
            Try
                If IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.TOP_FIXTURE_SHIELD_USAGE.ToString(), value) = False Then
                    Me.ThrowAlarm("Failed DoTopFixtureShieldUsage " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTopFixtureShieldUsage")
        End Sub
#End Region
#Region "DoShutterUsage"
        Public Sub DoShutterUsage(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoShutterUsage")
            Try
                If IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.SHUTTER_USAGE.ToString(), value) = False Then
                    Me.ThrowAlarm("Failed to DoShutterUsage " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoShutterUsage")
        End Sub
#End Region

#Region "DoLinearSourceUsage"
        Public Sub DoLinearSourceUsage(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoLinearSourceUsage")
            Try
                If IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.LINER_SOURCE_USAGE_READBACK.ToString(), value) = False Then
                    Me.ThrowAlarm("Failed DoLinearSourceUsage " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoLinearSourceUsage")
        End Sub
#End Region
#Region "DoCryoUsage"
        Public Sub DoCryoUsage(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoCryoUsage")
            Try
                If IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CRYO_USAGE_READBACK.ToString(), value) = False Then
                    Me.ThrowAlarm("Failed DoCryoUsage " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoCryoUsage")
        End Sub
#End Region
#Region "DoSetFixtureRotationMotorUsage"
        Public Sub DoSetFixtureRotationMotorUsage(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetFixtureRotationMotorUsage")
            Try
                If IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.FIXTURE_ROTATION_MOTOR_USAGE.ToString(), value) = False Then
                    Me.ThrowAlarm("Failed DoSetFixtureRotationMotorUsage " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoSetFixtureRotationMotorUsage")
        End Sub
#End Region
#Region "DoSetWaterJournal"
        Public Sub DoSetWaterJournal(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetWaterJournal")
            Try
                If IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.WATER_JOURNAL.ToString(), value) = False Then
                    Me.ThrowAlarm("Failed DoSetWaterJournal " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoSetWaterJournal")
        End Sub
#End Region

#End Region

#Region "Public methods"
        ''<name> Le Hieu Truc </name>
        ''<date> 2008-02-20</date>
        ''</author>
        ''<summary>
        ''' DoTask: convert message to command to send to Simulator
        Public Overrides Sub DoTask(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter DoTask")
            Try
                'Dim strMess As String()
                Dim strPnlName, strCtrlName, strVal As String
                strCtrlName = ""
                strVal = ""
                strPnlName = ""
                Me.ParseMessage(Message, strCtrlName, strPnlName, strVal)
                Select Case strCtrlName
                    Case SET_ATM_FORELINE_CG
                        DoSetATMForelineCG()
                    Case SET_VAC_FORELINE_CG
                        DoSetVACForelineCG()

                    Case SET_ATM_ROUGHPUMP_CG
                        DoSetATMRoughPumpCG()
                    Case SET_VAC_ROUGHPUMP_CG
                        DoSetVACRoughPumpCG()

                    Case SET_ATM_PRESSURE_CG
                        DoSetATMPressureCG()
                    Case SET_VAC_PRESSURE_CG
                        DoSetVACPressureCG()
                    Case TURN_IG_ON_OFF
                        DoTurnIGOnOff(strVal)

                    Case "UpdateGridSerialNumber"
                        DoUpdateGridSerialNumber(strVal)
                    Case "UpdateGridID"
                        DoUpdateGridID(strVal)
                    Case "RebuildLevel"
                        DoUpdateRebuildLevel(strVal)
                    Case "SendRequestAllData"
                        SendRequestAllData()
                        DoCheckRecipeTemplateVersion()
                    Case "btnReConnect"
                        DoReConnect(Me.EquipmentName)
                        ''<Menu On Machine>
                    Case "Offline"
                        DoOffline()
                    Case "Online"
                        DoOnline(strVal)
                    Case "AutoPumpDown"
                        DoAutoPumpDown(strVal)
                    Case "AutoVent"
                        DoAutoVent(strVal)
                    Case "OpenRoughPumpPower"
                        DoRoughPump(strVal)
                    Case "OpenTurboPumpPower"
                        DoTurboPump(strVal)

                        'Chiller
                    Case CHILLER_PROCESS_TEMPERATURE_MAX
                        DoSetChillerProcessTemperatureMax(strVal)
                    Case CHILLER_VENT_TEMPERATURE_MAX
                        DoSetChillerVentTemperatureMax(strVal)
                    Case CHILLER_VENT_TEMPERATURE_MIN
                        DoSetChillerVentTemperatureMin(strVal)
                    Case CHILLER_PROCESS_TEMPERATURE_MIN
                        DoSetChillerProcessTemperatureMin(strVal)
                    Case "ChillerOnOff"
                        DoChillerOnOff(strVal)
                    Case "ChillerTempSP"
                        SetChillerTempSP(strVal)
                        ''Cryo
                    Case "CryoPower"
                        DoCryoPower(strVal)
                    Case "CryoRegenValve"
                        DoCryoRegenValve(strVal)
                    Case "CryoPurgeValve"
                        DoCryoPurgeValve(strVal)
                    Case "CryoAutoRegen"
                        DoCryoAutoRegen(strVal)
                    Case "CryoAutoPowerDown"
                        DoCryoAutoPowerDown(strVal)
                    Case "txtRateOfRise"
                        SetCryo_Rate_Of_Rise(strVal)
                    Case "txtExtendedPurgeTime"
                        SetCryo_Extended_PurgeTime(strVal)
                    Case "txtPumpRestartDelay"
                        SetCryo_Pump_Restart_Delay(strVal)
                    Case "txtRepurgeCycles"
                        SetCryo_Repurge_Cycles(strVal)
                    Case "txtRoughToPressure"
                        SetCryo_Rough_To_Pressure(strVal)
                    Case "txtStartUpTemp"
                        SetCryo_Start_Up_Time(strVal)
                        ''Water Pump
                    Case "WaterPump"
                        DoWaterPump(strVal)
                    Case "WaterPumpRegen"
                        DoWaterPumpRegen(strVal)

                    Case "FixtureWaterValveStatus"
                        DoFixtureWaterValve(strVal)
                    Case "FixtureFlowCoolPumpStatus"
                        DoFixtureFlowCool(strVal)
                    Case "ACPower", "GridPower", "RFPower", "PBNPower", "AutoBeam", "NeurPower", "SourceManualPower", "SourceAutoPower"
                        DoPowerPanel(strCtrlName, strVal)
                    Case "ValveForeline", "HiVacValve", "ScreenMachine", "ValveArgon", "ValvePBN", _
                          "ValveFlowCoolHe", "ValveBaratron", "ValveWaterPump", "ValveSupplyArgon", "ValveSupplyPBN", _
                          "ValveCryoPump", "ValveSupplyFlowCool", _
                          "Gas1ShutOffValve", "Gas2ShutOffValve", "Gas3ShutOffValve", "Gas4ShutOffValve", "Gas5ShutOffValve", _
                          "Gas1SupplyValve", "Gas2SupplyValve", "Gas3SupplyValve", "Gas4SupplyValve", "Gas5SupplyValve", _
                          "ValveFixtureWater", "ValveDiverter", "ValveIGIsolation"
                        ChangeValve(strCtrlName, strVal)

                    Case "ValveRough", "ValveVent"
                        'Before open Valve Rough and Valve vent -> send the Slit valve status to equipment
                        Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
                        If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                            ChangeValve(strCtrlName, strVal)
                        Else
                            Utils.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
                        End If

                    Case "IsolationValve"
                        SetIsolationValveStatus(strVal)
                        ''for Fixture Rotation in Single Loader
                    Case "Rotation"
                        DoRotationFixture(strVal)
                    Case "TiltAngle"
                        SetTiltAngleValue(strVal)
                    Case "RotationEnd"
                        SetRotationEndAngle(strVal)
                    Case "RotationMode"
                        SetRotationMode(strVal)

                        ''for Fixture Rotation in old IBE
                    Case "FixtureHomeTiltAxis", "FixtureClampStatus", "FixtureHomeRotationAxis", _
                         "FixtureStartRotationAxis", "FixtureHomeAllAxis", "FixtureStopAllAxis", _
                         "FixtureOpenShutter", "FixtureCloseShutter", "FixturePumpPower", "FixtureCoolingWater", "FixtureUnProtected"
                        DoMnuFixture(strCtrlName, strVal)
                    Case "Start", "Stop", "Resume", "Pause", "Abort", "EndCurrentStep"  'Process Recipe
                        SetProcessRecipe(strCtrlName, strVal)
                        'Case "FixtureWater", "SourceWater", "Target", "ChamberPress", "Foreline", "MagnetWater", "TurboWater"
                        '    SetChamberInterLock(strCtrlName, strVal)
                    Case "ForwardPowerRight", "ReflectedPower", "ReflectedPowerRight"
                        SetPowerSupply(strCtrlName, strVal)
                    Case "PowerRight"
                        SetPower(strPnlName, strVal) '- PnlName: BeamPowerSupply, SuppressorPowerSupply      
                    Case "VoltageRight"
                        SetVoltage(strPnlName, strVal) '- PnlName: BeamPowerSupply, SuppressorPowerSupply,DischargePowerSupply, BodyPowerSupply
                    Case "CurrentRight"
                        SetCurrentRight(strPnlName, strVal) '- PnlName: DischargePowerSupply, BodyPowerSupply , BeamPowerSupply, SuppressorPowerSupply
                    Case "KFactorRight"
                        SetKFactorRight(strPnlName, strVal) '- PnlName: DischargePowerSupply, BodyPowerSupply , BeamPowerSupply, SuppressorPowerSupply
                    Case "CG2", "OpenIG", "CloseIG"
                        SetBACenterControl(strCtrlName, strVal)
                    Case "ContinuousTiltAngle", "StaticTiltAngle", "SweepTiltAngle", "ContinuousRotation", _
                         "StaticRotation", "SweepRotation", "SweepRotationLast", "StaticRotationLast", _
                         "ContinuousRotationLast"
                        SetFixtureControl(strCtrlName, strVal)
                    Case "ArgonLeft", "ArgonRight", "PBNLeft", "PBNGasRight", "PBNGasRight_Source", "FlowCoolHeLeft", "FlowCoolHeRight", _
                           "Gas1Right", "Gas2Right", "Gas1Right_Source", "Gas2Right_Source", "Gas3Right_Source", "Gas3Right", "Gas4Right", "Gas4Right_Source", "Gas5Right"
                        SetGasController(strCtrlName, strVal)
                    Case "MotionInitialize"
                        DoMotionInitialize(strVal)
                        'Case "RaiseOfRise"
                        '    DoRaiseOfRise(strVal)
                    Case "ResetSourceUsage"
                        DoResetSourceUsage("0")
                    Case "SetSourceUsage"
                        DoResetSourceUsage(strVal)
                    Case "SetPBNMinutes"
                        DoSetPBNMinutes(strVal)
                    Case "txtShieldQuartSP", "DoResetQuartz"
                        DoResetQuartz(strVal)
                    Case "txtCoverFixtureShieldUsageSP"
                        DoSourceUsageCoverFixtureShield(strVal)
                    Case "txtWaferClampUsageSP"
                        DoWaferClampUsage(strVal)
                    Case "txtTopFixtureShieldUsageSP"
                        DoTopFixtureShieldUsage(strVal)
                    Case "txtShutterUsageSP"
                        DoShutterUsage(strVal)
                    Case "txtLinerSP"
                        DoLinearSourceUsage(strVal)
                    Case "txtCryoUsageSP"
                        DoCryoUsage(strVal)
                    Case "txtFixtureRotationMotorUsageSP"
                        DoSetFixtureRotationMotorUsage(strVal)
                    Case "txtWaterJournalSP"
                        DoSetWaterJournal(strVal)
                    Case "IGDegas"
                        DoIGDegas(strVal)
                    Case "PumpPurge"
                        DoPumpPurge(strVal)

                    Case STR_RECOVER_PRESSURE
                        RecoverPressure()
                    Case STR_STOP_RECOVER_PRESSURE
                        StopRecoverPressure()
                    Case STR_RATE_OF_RISE
                        DoRateOfRise()
                    Case STR_STOP_RATE_OF_RISE
                        DoStopRateOfRise()
                    Case STR_PUMP_DOWN_CURVE
                        DoPumpdownCurve()
                    Case STR_STOP_PUMP_DOWN_CURVE
                        DoStopPumpdownCurve()
                    Case SendProcessLotIDCmdMessage
                        SendProcessLotID()
                    Case SendProcessWaferIDCmdMessage
                        SendProcessWaferID()
                    Case "TiltSweep"
                        SetTiltSweepValue(strVal)
                    Case "TiltSweepRight"
                        SetTiltSweepStartAngle(strVal)
                    Case "TiltEnd"
                        SetTiltSweepEndAngle(strVal)
                    Case "btnIGFilament1"
                        SetIGFilament1(strVal)
                    Case "btnIGFilament2"
                        SetIGFilament2(strVal)
                    Case "txtSourceEMCurrentRight"
                        SetSourceEMCurrent(strVal)
                    Case "txtSourceEMCurrentRight_SourceTab"
                        SetSourceEMCurrentBeamParam(strVal)

                    Case "ClearAllAlarm"
                        ClearAllAlarm(strVal)
                End Select
                ' Change IG Status from TransferChamber
                If (Message = ConstEnum.IonOn) Then
                    ChangeIG(ConstEnum.Open)
                ElseIf (Message = ConstEnum.IonOff) Then
                    ChangeIG(ConstEnum.Close)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub

        ''CtrlName: Name of control, val: value of control
        Public Sub ChangeValve(ByVal ctrlName As String, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeValve")
            Dim eIBECommand As IBECommands
            Dim bOpen As Boolean = False
            If (val = STR_ON) Then
                bOpen = True
            End If
            Select Case ctrlName
                Case "ValveWaterPump"
                    'ChangeWaterPumpValve(bOpen)
                    eIBECommand = IBECommands.TURBO_PUMP_POWER
                Case "ValveSupplyPBN"
                    'ChangePBNSupplyValve(bOpen)
                    eIBECommand = IBECommands.PBN_GAS_SUPPLY_VALVE
                Case "ValveCryoPump"
                    'ChangeCryoPumpValve(bOpen)
                    eIBECommand = IBECommands.CRYO_PUMP_GATE_VALVE
                Case "ValveSupplyFlowCool"
                    'ChangeFlowCoolHeSupplyValve(bOpen)
                    eIBECommand = IBECommands.FLOWCOOL_MFC_SUPPLY_VALVE
                Case "ValveForeline"
                    'ChangeForelineValve(bOpen)
                    eIBECommand = IBECommands.FORELINE_VALVE
                Case "HiVacValve"
                    'ChangeHiVacValve(bOpen)
                    Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
                    SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN))
                    eIBECommand = IBECommands.TURBO_PUMP_GATE_VALVE
                Case "ScreenMachine"
                    'ChangeScreenMachine(bOpen)
                    eIBECommand = IBECommands.SHUTTER_POSITION
                Case "ValveRough"
                    'ChangeRoughValve(bOpen)
                    eIBECommand = IBECommands.ROUGH_VALVE
                Case "ValvePBN"
                    'ChangePBNValve(bOpen)
                    eIBECommand = IBECommands.PBN_GAS_SHUTOFF_VALVE
                Case "ValveFlowCoolHe"
                    'ChangeFlowCoolHeValve(bOpen)
                    eIBECommand = IBECommands.FLOWCOOL_MFC_SHUTOFF_VALVE
                Case "ValveBaratron"
                    'ChangeBaratronValve(bOpen)
                    eIBECommand = IBECommands.BARATRON_VALVE
                Case "ValveVent"
                    'ChangeVentValve(bOpen)
                    eIBECommand = IBECommands.VENT_VALVE
                Case "ValveIGIsolation"
                    eIBECommand = IBECommands.IGISOLATION_VALVE
                Case "ValveDiverter"
                    eIBECommand = IBECommands.GASDIVERTER_VALVE
                Case "Gas1ShutOffValve"
                    eIBECommand = IBECommands.GAS1_SHUTOFF_VALVE
                Case "Gas2ShutOffValve"
                    eIBECommand = IBECommands.GAS2_SHUTOFF_VALVE
                Case "Gas3ShutOffValve"
                    eIBECommand = IBECommands.GAS3_SHUTOFF_VALVE
                Case "Gas4ShutOffValve"
                    eIBECommand = IBECommands.GAS4_SHUTOFF_VALVE
                Case "Gas5ShutOffValve"
                    eIBECommand = IBECommands.GAS5_SHUTOFF_VALVE
                Case "Gas1SupplyValve"
                    eIBECommand = IBECommands.GAS1_SUPPLY_VALVE
                Case "Gas2SupplyValve"
                    eIBECommand = IBECommands.GAS2_SUPPLY_VALVE
                Case "Gas3SupplyValve"
                    eIBECommand = IBECommands.GAS3_SUPPLY_VALVE
                Case "Gas4SupplyValve"
                    eIBECommand = IBECommands.GAS4_SUPPLY_VALVE
                Case "Gas5SupplyValve"
                    eIBECommand = IBECommands.GAS5_SUPPLY_VALVE
                Case "ValveFixtureWater"
                    eIBECommand = IBECommands.FIXTURE_WATER_VALVE
                Case "IsolationValve"
                    eIBECommand = IBECommands.ISOLATION_VALVE
            End Select
            ChangeValve(eIBECommand, bOpen)
            AVPLib.Log.coreLogger.Info("Leave ChangeValve")
        End Sub

        ''CtrlName: Name of control
        Public Sub DoMnuFixture(ByVal ctrlname As String, ByVal strval As String)
            AVPLib.Log.coreLogger.Info("Enter DoMnuFixture")
            Select Case ctrlname
                Case "FixtureHomeTiltAxis"

                Case "FixtureStartRotationAxis"
                    SetStartRotationAxis(strval)
                Case "FixturePumpPower"
                    SetPumpPower(strval)
                Case "FixtureCoolingWater"
                    SetCoolingWater(strval)
                Case "FixtureUnProtected"
                    SetUnProtected(strval)
                Case "FixtureClampStatus"
                    If strval = STR_ONCLAMP Then
                        DoFixtureClampOn()
                    Else
                        DoFixtureUnClamp()
                    End If
                Case "FixtureHomeAllAxis"
                    DoFixtureHomeAllAxis()
                Case "FixtureHomeRotationAxis"
                    SetHomeRotationAxis(strval)
                Case "RotationMode"
                    SetRotationModeValue(strval)
                Case "FixtureStopAllAxis"
                    DoFixtureStopAllAxis()
                Case "FixtureOpenShutter"
                    DoFixtureOpenShutter(strval)
                Case "FixtureHomeTiltAxis"
                    SetTiltAngleValue(strval)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoMnuFixture")
        End Sub

        ''CtrlName: Name of control, val: value of control
        Public Sub SetGasController(ByVal ctrlName As String, ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetGasController")
            Dim eIBECommand As IBECommands

            Select Case ctrlName
                Case "ArgonRight"
                    eIBECommand = IBECommands.GAS_TARGET_FLOWRATE_A_PROGRAM
                Case "PBNGasRight"
                    eIBECommand = IBECommands.PBN_GAS_FLOWRATE_PROGRAM
                Case "PBNGasRight_Source"
                    eIBECommand = IBECommands.AUTOBEAM_PBN_GAS_FLOWRATE_PROGRAM
                Case "FlowCoolHeRight"
                    eIBECommand = IBECommands.FLOWCOOL_MFC_TARGET_FLOWRATE
                Case "Gas1Right"
                    eIBECommand = IBECommands.GAS1_FLOWRATE_PROGRAM
                Case "Gas1Right_Source"
                    eIBECommand = IBECommands.AUTOBEAM_GAS1_FLOWRATE_PROGRAM
                Case "Gas2Right"
                    eIBECommand = IBECommands.GAS2_FLOWRATE_PROGRAM
                Case "Gas2Right_Source"
                    eIBECommand = IBECommands.AUTOBEAM_GAS2_FLOWRATE_PROGRAM

                Case "Gas3Right"
                    eIBECommand = IBECommands.GAS3_FLOWRATE_PROGRAM
                Case "Gas3Right_Source"
                    eIBECommand = IBECommands.AUTOBEAM_GAS3_FLOWRATE_PROGRAM
                Case "Gas4Right"
                    eIBECommand = IBECommands.GAS4_FLOWRATE_PROGRAM
                Case "Gas4Right_Source"
                    eIBECommand = IBECommands.AUTOBEAM_GAS4_FLOWRATE_PROGRAM
                Case "Gas5Right"
                    eIBECommand = IBECommands.GAS5_FLOWRATE_PROGRAM
            End Select
            SetGasValue(eIBECommand, Val)
            AVPLib.Log.coreLogger.Info("Leave SetGasController")
        End Sub

        ''CtrlName: Name of control, val: value of control
        Public Sub SetBACenterControl(ByVal CtrlName As String, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBACenterControl")
            Select Case CtrlName
                Case "CG2"
                    SetCGValue(val)
                Case "OpenIG"
                    ChangeIG("Open")
                Case "CloseIG"
                    ChangeIG("Close")
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetBACenterControl")
        End Sub

        ''CtrlName: Name of control, val: value of control
        Public Sub SetPowerSupply(ByVal ctrlname As String, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetPowerSupply")
            Select Case ctrlname
                Case "ForwardPowerRight"
                    SetForwardPowerValue(val)
                Case "ReflectedPowerRight"
                    SetReflectedPowerValue(val)
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetPowerSupply")
        End Sub

        ''CtrlName: Name of control, val: value of control
        Public Sub SetCurrentRight(ByVal PnlName As String, ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetCurrentRight")
            Select Case PnlName
                Case "DischargePowerSupply"
                    SetDiscCurrentValue(Val)
                Case "BodyPowerSupply"
                    SetBodyCurrentValue(Val)
                Case "BeamPowerSupply"
                    SetBeamCurrentValue(Val)
                Case "SuppressorPowerSupply"
                    SetSuppressorCurrentValue(Val)
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetCurrentRight")
        End Sub

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-09-01</date>
        ''' </author>
        ''' <summary>
        ''' CtrlName: Name of control, val: value of control
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Sub SetKFactorRight(ByVal PnlName As String, ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetCurrentRight")
            Select Case PnlName
                Case "BodyPowerSupply"
                    SetBodyKFactorValue(Val)
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetCurrentRight")
        End Sub

        ''CtrlName: Name of control, val: value of control
        Public Sub SetVoltage(ByVal PnlName As String, ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetVoltageRight")
            Select Case PnlName
                Case "BeamPowerSupply"
                    SetBeamVoltageValue(Val)
                Case "SuppressorPowerSupply"
                    SetSuppVoltageValue(Val)
                Case "DischargePowerSupply"
                    SetDiscVoltageValue(Val)
                Case "BodyPowerSupply"
                    SetBodyVoltageValue(Val)
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetVoltageRight")
        End Sub

        ''CtrlName: Name of control, val: value of control
        Public Sub SetPower(ByVal PnlName As String, ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetPowerRight")
            Select Case PnlName
                Case "BeamPowerSupply"
                    SetBeamPowerValue(Val)
                Case "SuppressorPowerSupply"
                    SetSuppPowerValue(Val)
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetPowerRight")
        End Sub

        'CtrlName: Name of control, val: value of control
        Public Sub SetProcessRecipe(ByVal ctrlname As String, ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetProcessRecipe")
            Select Case ctrlname
                Case "Resume"
                    ResumeRecipe()
                Case "Start" 'button
                    Me.StartRecipe_CX(Val)
                Case "Pause" 'button
                    PauseRecipe()
                Case "Stop" 'button
                    StopRecipe()
                Case "EndCurrentStep", "Abort" 'EndCurrentStep for SL, Abort for CX
                    EndCurrentStepRecipe()
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetProcessRecipe")
        End Sub
        ''this function must be reviewed when CX platform was installed -> Single Loader did change a lot
        ''CtrlName: Name of control, val: value of control
        Public Sub SetFixtureControl(ByVal ctrlName As String, ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetFixtureControl")
            Select Case ctrlName
                Case "StaticTiltAngle", "SweepTiltAngle", "ContinuousTiltAngle"
                    SetTiltAngleValue(Val)
                Case "ContinuousRotation"
                    SetContinuousRotationRPM(Val)
                Case "StaticRotation"   'rotation angle program
                    SetStaticRotationAngle(Val)
                Case "SweepRotation"    'rotation start 
                    SetRotationStartAngle(Val)
                    'Case "RotationMode"
                    '    SetRotationModeValue(Val)
                Case "ContinuousRotationLast"
                    SetContinuousRotationRPM(Val)
                    'Case "StaticRotationLast"
                    '    SetStaticRotationAngle(Val)
                Case "SweepRotationLast"      'rotation end
                    SetRotationEndAngle(Val)
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetFixtureControl")
        End Sub
        ''this function use in Single Loader with a new textbox (not system textbox like CX)
        Private Sub DoRotationFixture(ByVal strval As String)
            AVPLib.Log.coreLogger.Info("Enter DoRotationFixture")
            Const STR_SWEEP As String = "Sweep "
            Const STR_STATIC As String = "Static "
            Const STR_CONTINUOUS As String = "Continuous "
            Try
                If strval.Contains(STR_SWEEP) Then
                    strval = strval.Replace(STR_SWEEP, "")
                    SetRotationStartAngle(strval) ''rotation start
                ElseIf strval.Contains(STR_CONTINUOUS) Then
                    strval = strval.Replace(STR_CONTINUOUS, "")
                    SetContinuousRotationRPM(strval)
                ElseIf strval.Contains(STR_STATIC) Then
                    strval = strval.Replace(STR_STATIC, "")
                    SetStaticRotationAngle(strval)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoRotationFixture")
        End Sub

        Private Sub SetRotationMode(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter SetRotationMode")
            Try
                Select Case strVal
                    Case STR_OFF
                        SetRotationModeValue(ConfigurationValues.DEVICE_STATUS_CLOSED) '00
                    Case "Sweep"
                        SetRotationModeValue(ConfigurationValues.DEVICE_STATUS_OTHER) '04
                    Case "Static"
                        SetRotationModeValue(ConfigurationValues.DEVICE_STATUS_ABORT) '03
                    Case "Continuous"
                        SetRotationModeValue(ConfigurationValues.DEVICE_STATUS_OPEN) '01
                    Case "Home"
                        SetRotationModeValue(ConfigurationValues.DEVICE_STATUS_STOPPED) '02
                End Select

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Enter SetRotationMode")
        End Sub

#End Region

#Region "Support convert xml recipe format from VEECO to AVP_IBE"
        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Convert xml recipe format to similar with AVP_IBE xml type.
        ''' </summary>
        Public Function ChangeRecipeXMLFormat(ByVal strPath As String) As String
            AVPLib.Log.coreLogger.Info("Enter ChangeRecipeFile")
            Dim strReturnPath As String = strPath

            Try
                Dim ChamberDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument()
                Const STR_PROCESS_ENDS_BY As String = "Process_Ends_By"
                Const STR_FIXTURE_ROTATE_CONTINUOUS As String = "Fixture_Rotate_Continious"
                Const STR_FIXTURE_ROTATE_SWEEP As String = "Fixture_Rotate_Sweep"
                Const STR_FIXTURE_ROTATE_STATIC As String = "Fixture_Rotate_Static"
                Const STR_FIXTURE_ROTATE_HOME As String = "Fixture_Rotate_Home"
                Const STR_USE_ETCH_RATE_CORRECTION As String = "UseEtchRateCorrection"
                Const STR_ETCH_TIME_HOUR As String = "Etch_Time_Hour"
                Const STR_ETCH_TIME_MINUTE As String = "Etch_Time_Min"
                Const STR_ETCH_TIME_SECOND As String = "Etch_Time_Sec"
                Const STR_ETCH_TIME_MILISECOND As String = "Etch_Time_MilliSec"
                Dim nodeNameNew As String = String.Empty
                Dim nodeValueNew As String = String.Empty
                Dim dEtchRate As Double = 1
                Dim dEtchValueTemp As Double = 0
                ChamberDoc.Load(strPath)
                Dim xmlListNode As Xml.XmlNodeList = ChamberDoc.SelectNodes("/Recipe/StepList/Step")
                For Each xmlNode As Xml.XmlNode In xmlListNode
                    For Each xmlParameterNode As Xml.XmlNode In xmlNode.ChildNodes
                        If xmlParameterNode.ChildNodes.Count > 0 Then
                            Dim iFlag As Integer = 0
                            Dim iCheckRotationMode As Integer = 0

                            For i As Integer = xmlParameterNode.ChildNodes.Count - 1 To 0 Step -1
                                Dim xmlNodeValue As Xml.XmlNode = xmlParameterNode.ChildNodes(i)
                                nodeNameNew = xmlNodeValue.Name
                                nodeValueNew = xmlNodeValue.InnerText
                                Dim xmlNodeParent As Xml.XmlNode = xmlNodeValue.ParentNode

                                Select Case xmlNodeValue.Name
                                    Case STR_PROCESS_ENDS_BY
                                        'If xmlNodeValue.InnerText = "1" Then
                                        '    nodeValueNew = "Time"
                                        'Else
                                        '    nodeValueNew = "Endpoint"
                                        'End If
                                        'xmlNodeParent.RemoveChild(xmlNodeValue)
                                        'Dim ParameterNode As System.Xml.XmlNode = ChamberDoc.CreateElement(nodeNameNew)
                                        'ParameterNode.InnerText = nodeValueNew
                                        'xmlNodeParent.AppendChild(ParameterNode)
                                    Case STR_ETCH_TIME_HOUR, STR_ETCH_TIME_MINUTE, STR_ETCH_TIME_SECOND, STR_ETCH_TIME_MILISECOND
                                        Dim xmlNodeUseEtchRate As Xml.XmlNode = xmlParameterNode.SelectSingleNode(STR_USE_ETCH_RATE_CORRECTION)
                                        If xmlNodeUseEtchRate IsNot Nothing AndAlso xmlNodeUseEtchRate.InnerText.ToUpper = "TRUE" Then
                                            Dim ObjPM As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                                            If ObjPM IsNot Nothing Then
                                                dEtchRate = ObjPM.Etch_Rate
                                            End If
                                            Double.TryParse(xmlNodeValue.InnerText, dEtchValueTemp)
                                            nodeValueNew = (dEtchValueTemp * dEtchRate).ToString()
                                            xmlNodeValue.InnerText = nodeValueNew
                                        End If
                                    Case "K", "Value_1", "Value_2", "Value_3", "Value_4", "Value_5"
                                        'nodeNameNew = ChangeNodeValueName(nodeNameNew)
                                        'xmlNodeParent.RemoveChild(xmlNodeValue)
                                        'Dim ParameterNode As System.Xml.XmlNode = ChamberDoc.CreateElement(nodeNameNew)
                                        'ParameterNode.InnerText = nodeValueNew
                                        'xmlNodeParent.AppendChild(ParameterNode)
                                    Case STR_FIXTURE_ROTATE_CONTINUOUS, STR_FIXTURE_ROTATE_SWEEP, _
                                         STR_FIXTURE_ROTATE_STATIC, STR_FIXTURE_ROTATE_HOME
                                        'If xmlNodeValue.InnerText = "True" Then
                                        '    nodeValueNew = xmlNodeValue.Name.Substring(xmlNodeValue.Name.LastIndexOf("_") + 1, _
                                        '            xmlNodeValue.Name.Length - xmlNodeValue.Name.LastIndexOf("_") - 1)

                                        '    'Smell code here. Because template file recipe is mistake here
                                        '    If nodeValueNew = "Continious" Then
                                        '        nodeValueNew = "Continuous"
                                        '    End If

                                        '    iFlag = iFlag + 1
                                        'End If
                                        'iCheckRotationMode += 1
                                        'If iCheckRotationMode = 3 AndAlso iFlag < 1 Then
                                        '    nodeValueNew = "Home"
                                        '    iFlag = 1
                                        'End If
                                        'xmlNodeParent.RemoveChild(xmlNodeValue)
                                End Select

                                'If iFlag = 1 Then
                                '    nodeNameNew = STR_FIXTURE_ROTATE_NODE_NAME
                                '    iFlag = iFlag + 10
                                '    Dim ParameterNode As System.Xml.XmlNode = ChamberDoc.CreateElement(nodeNameNew)
                                '    ParameterNode.InnerText = nodeValueNew
                                '    xmlNodeParent.AppendChild(ParameterNode)
                                'End If
                            Next
                        End If
                    Next
                Next
                Dim strNewPath As String = strPath.Substring(0, strPath.LastIndexOf("\")) & "\Temp"
                Dim fileName As String = Utils.GetFileName(strPath, False)

                If IO.Directory.Exists(strNewPath) Then
                    IO.Directory.Delete(strNewPath, True)
                End If
                IO.Directory.CreateDirectory(strNewPath)

                ChamberDoc.Save(strNewPath & "\" & fileName)
                strReturnPath = strNewPath & "\" & fileName
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ChangeRecipeFile")
            Return strReturnPath
        End Function

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Change Node Value Name
        ''' </summary>
        Private Function ChangeNodeValueName(ByVal strNodeName As String)
            Dim strValueReturn As String = strNodeName
            Select Case strNodeName
                Case "K"
                    strValueReturn = "K_Factor"
                Case "Value_1"
                    strValueReturn = "Gas1"
                Case "Value_2"
                    strValueReturn = "Gas2"
                Case "Value_3"
                    strValueReturn = "Gas3"
                Case "Value_4"
                    strValueReturn = "Gas4"
                Case "Value_5"
                    strValueReturn = "Gas5"
            End Select
            Return strValueReturn
        End Function
#End Region

        Private Sub OnlineProc()
            AVPLib.Log.coreLogger.Info("Enter OnlineProc")
            Try
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : A NEW THREAD BORN FOR PROCESSING ONLINE.")
                Dim Online As Boolean = Me.CheckOnline()
                Me.RaiseFinishOnline(Online)
                ''reset flag
                m_blnThrowAlarm_When_Online = True
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : THE THREAD PROCESSING ONLINE IS OVER.")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OnlineProc")
        End Sub

        Private Function CheckOnline() As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckOnline")
            Try
                'Online condition
                Dim objIBE As IBEChamber = IBE_Equipment
                Dim objChamberConfig As SystemModule = IBEConfig
                ''check nothing first
                If objIBE Is Nothing OrElse objChamberConfig Is Nothing Then
                    Return False
                End If
                With objIBE
                    '0001024: [Khoi Ha - 06/21/2012] - 
                    'IBE. Need to turn on AC power before checking for RF powersupplies communication. CXX/SL, system sho
                    If (objIBE.ACPower_readback <> Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Utils.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": AC Power is not On" & GO_ONLINE_FAILED)
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If

                    'If IBE.  If process is running or pausing.  Check all interlock only.
                    'Is All Interlock made?
                    If Not ((.ChamberInterlocks_FixtureWater_Status = Equipment.WorkingStatuses.On) _
                            AndAlso (Not objChamberConfig.ChamberInterlock_FixtureWaterBugVisible OrElse .ChamberInterlocks_FixtureWaterBug_Status = Equipment.WorkingStatuses.On) _
                             AndAlso (.ChamberInterlocks_SourceWater_Status = Equipment.WorkingStatuses.On) _
                             AndAlso (.ChamberInterlocks_PanelInterlock_Status = Equipment.WorkingStatuses.On) _
                             AndAlso (.ChamberInterlocks_ChamberPress_Status = Equipment.WorkingStatuses.On) _
                             AndAlso (.ChamberInterlocks_Foreline_Status = Equipment.WorkingStatuses.On) _
                             AndAlso (.ChamberInterlocks_AirPressure_Status = Equipment.WorkingStatuses.On) _
                             AndAlso (.ChamberInterlocks_TurboWater_Status = Equipment.WorkingStatuses.On)) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": All Interlocks Are Not Made" & GO_ONLINE_FAILED)
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                    'If IBE.  If no process is running or pausing, 
                    'check all interlock turbo hivac open and IG on condition before allow it to goes online.
                    If Not (.IsPauseInProcess OrElse .IsProcessRunning) Then
                        If Not (.HiVacValveStatus = Equipment.WorkingStatuses.On) Then
                            If m_blnThrowAlarm_When_Online Then
                                Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": Turbo Hivac is not opened" & GO_ONLINE_FAILED)
                            End If
                            AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                            Return False
                        End If
                        If Not (.IGStatus = Equipment.WorkingStatuses.On) Then
                            If m_blnThrowAlarm_When_Online Then
                                Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": IG is not On" & GO_ONLINE_FAILED)
                            End If
                            AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                            Return False
                        End If

                        If (.TurboPowerStatus <> DataManagerment.Equipment.WorkingStatuses.On) Then
                            If m_blnThrowAlarm_When_Online Then
                                Utils.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": Turbo is not On" & GO_ONLINE_FAILED)
                            End If
                            AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                            Return False
                        End If
                    End If
                End With

                AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                Return True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckOnline")
            Return False
        End Function

        Public Sub CopyRecipeToPMFolder() Implements IRecipeProcessing.CopyRecipeToPMFolder

        End Sub
        Public Sub CopyRecipeTemplate() Implements IRecipeProcessing.CopyRecipeTemplate
            ''Implement in ChamberController
        End Sub

#Region "Throw Alarm"
        Public Sub ThrowAlarm(ByVal strMessage As String, Optional ByVal strAlarmSubName As String = "")
            Dim strSubName As String = strAlarmSubName
            If String.IsNullOrEmpty(strSubName) Then
                strSubName = AVPLib.ConstEnum.GEM_ALARM_SUB_COMMON_ALARM
            End If
            Dim strGemAlarmName = Utils.GemGetAlarmName(Me.EquipmentName, strAlarmSubName)
            Utils.ThrowAlarm(strMessage, strGemAlarmName)
        End Sub
#End Region

        ''<name> Truc Le </name>
        ''<date> 2014-04-14</date>
        ''</author>
        ''<summary>
        ''' 0004787: [KhoiHa 03/22/2014]If user run a scheduler with recipe only using T2/T3/T4. 
        ''' With picture below, user should be allow to run since this schedule is not using T1.
        ''</summary>
        Public Function GetAllTargetBaseOnRecipe(ByVal strRecipeName As String, ByVal strStationName As String) As System.Collections.Generic.List(Of String) Implements IRecipeProcessing.GetAllTargetBaseOnRecipe
            Return Nothing
        End Function

        ''<name> Vy Nguyen </name>
        ''<date> 2014-04-14</date>
        ''</author>
        ''<summary>
        ''' 0004787: [KhoiHa 03/22/2014]If user run a scheduler with recipe only using T2/T3/T4. 
        ''' With picture below, user should be allow to run since this schedule is not using T1.
        ''</summary>
        Public Function CheckingKWHOverAlarmLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingKWHOverAlarmLimit
            Dim ListOf_PMReachFaultLmt As String = String.Empty
            Try
                Dim objIBEChamber As IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objConfigChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)

                If objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.IBE Then
                    Dim currentSource As Double = objIBEChamber.SourceUsageTimeCurrent
                    If objIBEChamber.IsUseMaxLimit Then
                        If currentSource >= Math.Abs(objConfigChamber.SourceUsageTimeLimit - objConfigChamber.Max_KWH_Source) Then
                            ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + ", "
                        End If
                    ElseIf currentSource >= objConfigChamber.SourceUsageTimeLimit Then
                        ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + ", "
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return ListOf_PMReachFaultLmt
        End Function

        ''<name> Vy Nguyen </name>
        ''<date> 2014-04-14</date>
        ''</author>
        ''<summary>
        ''' 0004787: [KhoiHa 03/22/2014]If user run a scheduler with recipe only using T2/T3/T4. 
        ''' With picture below, user should be allow to run since this schedule is not using T1.
        ''</summary>
        Public Function CheckingKWHOverWarningLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingKWHOverWarningLimit
            Dim ListOf_PMReachWarningLmt As String = String.Empty
            Try
                Dim objIBEChamber As IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objConfigChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                Dim objPm As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)

                If objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.IBE Then
                    Dim currentSource As Double = objIBEChamber.SourceUsageTimeCurrent

                    If (objPm IsNot Nothing) AndAlso objPm.IsUseMaxLimit Then
                        Dim dblSourceWarning As Double = Math.Abs(objConfigChamber.SourceUsageTimeWarning - objConfigChamber.Max_KWH_Source)
                        If currentSource >= dblSourceWarning Then
                            ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + ", "
                        End If
                    ElseIf currentSource >= objConfigChamber.SourceUsageTimeWarning Then
                        ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + ", "
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return ListOf_PMReachWarningLmt
        End Function

        ''' <author>
        '''    	<name> Vy Nguyen </name>
        '''    	<date> 2014-09-8</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoChillerOnOff(ByVal data As String)
            AVPLib.Log.coreLogger.Info("Enter DoChillerOnOff")
            Try
                If data = STR_ON Then
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CHILLER_ON_OFF.ToString(), _
                    ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CHILLER_ON_OFF.ToString(), _
                    ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoChillerOnOff")
        End Sub

        ''' <author>
        '''    	<name> Vy Nguyen </name>
        '''    	<date> 2014-09-8</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetChillerTempSP(ByVal strValue As String)
            AVPLib.Log.coreLogger.Info("Enter SetChillerTempSP")
            Try
                IBEUtility.SendCommandWithDataToIBE(Me.EquipmentName, IBECommands.CHILLER_TEMP_SP.ToString(), strValue)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetChillerTempSP")
        End Sub

        ''' <author>
        '''     <name> Hai Tran </name>
        '''     <date> 2015-06-19 </date>
        ''' </author>
        ''' <summary>
        ''' CheckingShieldsQuartzOverAlarmLimit
        ''' </summary>
        Public Function CheckingShieldsQuartzOverAlarmLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingShieldsQuartzOverAlarmLimit
            Dim ListOf_PMReachFaultLmt As String = String.Empty
            Try
                Dim objIBEChamber As IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objConfigChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)

                If objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.IBE Then
                    Dim currentShieldsQuartz As Double = objIBEChamber.Shields_Quart_KWH
                    If objIBEChamber.IsUseMaxLimit Then
                        If currentShieldsQuartz >= Math.Abs(objConfigChamber.ShieldsQuartzLimit - objConfigChamber.Max_KWH_ShieldsQuartz) Then
                            ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + ", "
                        End If
                    ElseIf currentShieldsQuartz >= objConfigChamber.ShieldsQuartzLimit Then
                        ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + ", "
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return ListOf_PMReachFaultLmt
        End Function

        ''' <author>
        '''     <name> Hai Tran </name>
        '''     <date> 2015-06-19 </date>
        ''' </author>
        ''' <summary>
        ''' CheckingShieldsQuartzOverWarningLimit
        ''' </summary>
        Public Function CheckingShieldsQuartzOverWarningLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingShieldsQuartzOverWarningLimit
            Dim ListOf_PMReachWarningLmt As String = String.Empty
            Try
                Dim objIBEChamber As IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objConfigChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                Dim objPm As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)

                If objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.IBE Then
                    Dim currentShieldsQuartz As Double = objIBEChamber.Shields_Quart_KWH

                    If (objPm IsNot Nothing) AndAlso objPm.IsUseMaxLimit Then
                        Dim dblSourceWarning As Double = Math.Abs(objConfigChamber.ShieldsQuartzWarning - objConfigChamber.Max_KWH_ShieldsQuartz)
                        If currentShieldsQuartz >= dblSourceWarning Then
                            ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + ", "
                        End If
                    ElseIf currentShieldsQuartz >= objConfigChamber.ShieldsQuartzWarning Then
                        ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + ", "
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return ListOf_PMReachWarningLmt
        End Function

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2016-06-20</date>
        ''' </author>
        ''' <summary>
        ''' Send WaferID to PM.
        ''' </summary>
        Public Overridable Function SendProcessWaferID() As Boolean Implements IRecipeProcessing.SendProcessWaferID
            AVPLib.Log.coreLogger.Info("Enter SendProcessWaferID")
            Try
                Dim ObjPM As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                If ObjPM IsNot Nothing AndAlso ObjPM.WaferInfo IsNot Nothing Then
                    Return IBEUtility.Process_Wafer_Id(Me.EquipmentName, ObjPM.WaferInfo.WaferID)
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendProcessWaferID")
            Return False
        End Function

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2016-06-20</date>
        ''' </author>
        ''' <summary>
        ''' Send LotID to PM.
        ''' </summary>
        Public Overridable Function SendProcessLotID() As Boolean Implements IRecipeProcessing.SendProcessLotID
            AVPLib.Log.coreLogger.Info("Enter SendProcessLotID")
            Try
                Dim ObjPM As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                If ObjPM IsNot Nothing AndAlso ObjPM.WaferInfo IsNot Nothing Then
                    Return IBEUtility.Process_Lot_Id(Me.EquipmentName, Utils.GetLotIDFromWafer(ObjPM.WaferInfo.WaferID))
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendProcessLotID")
            Return False
        End Function

    End Class
End Namespace

