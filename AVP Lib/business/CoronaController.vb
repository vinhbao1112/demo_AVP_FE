Imports System.Timers
Imports System.Threading
Imports AVPLib.DataManagerment
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum
Namespace Business
    Public Class CoronaController
        Inherits ControllerObject
        Implements IRecipeProcessing

#Region "Class Constants & Variables"
        Const STRING_TYPE1 As String = "^(\w+)\.(\w+) (.*)$"
        Const STRING_TYPE2 As String = "^(\w+)\.(\w+)$"
        Const STRING_TYPE3 As String = "^(\w+) (\w+)$"
        Const STRING_TYPE4 As String = "^(\w+)$"
        Const STRING_TYPE5 As String = "^(\w+)\.(\w+)\.(\w+) (.*)$"
        Private m_fSourceUsageWarningLimitSend As Double = 0
        Private m_fSourceUsageAlarmLimitSend As Double = 0
        Private m_bFirstTimeSend As Boolean = True
        Private m_fTargetMaxSourceUsageSend As Double = 0
        Private m_blnThrowAlarm_When_Online As Boolean = True

        Private m_objCoronaChamber As CoronaChamber = Nothing
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
        Private m_IsInitOrReconnectPulling = False
        Private m_ListCmdNeedToPullingAllTime As ArrayList = New ArrayList()

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
        Public Overrides Property EquipmentName() As String
            Get
                Return m_strEquipmentName
            End Get
            Set(ByVal value As String)
                m_strEquipmentName = value
            End Set
        End Property
#End Region

#Region "Constructors & Dispose"
        Public Sub New(ByVal EQName As String)
            m_tmrPullingTimer = New System.Timers.Timer()
            AddHandler m_tmrPullingTimer.Elapsed, AddressOf Pulling
            AddAllCmdNeedToPollingAllTime()
            m_IsInitOrReconnectPulling = True
            m_tmrPullingTimer.Interval = ContainerData.GetPolling(ConstEnum.IBE_POLLING_CMD).Interval ''read from config file
            m_tmrPullingTimer.Enabled = True 'Start pulling
            m_RoutineExecutor = New ChamberRoutineExecutor(EQName)
            Me.EquipmentName = EQName
            m_objCoronaChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
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
                Dim objCoronaChamber As CoronaChamber = EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objSystemModule As SystemModule = Nothing
                AVPLib.ContainerData.IsChamberVisible(objCoronaChamber.Name, objSystemModule)
                If objCoronaChamber IsNot Nothing Then
                    blResult = (objCoronaChamber.Chamberinterlock_Devicenet_Comm = Equipment.WorkingStatuses.On) _
                                And (objCoronaChamber.Chamberinterlock_Lid_Closed_Status = Equipment.WorkingStatuses.On) _
                                And (objCoronaChamber.Chamberinterlock_PS_Interlock_Status = Equipment.WorkingStatuses.On) _
                                And (objCoronaChamber.Chamberinterlock_Target_Panels = Equipment.WorkingStatuses.On) _
                                And (objCoronaChamber.CG_Relay_Status = Equipment.WorkingStatuses.On) _
                                And (objCoronaChamber.Foreline_CG_Relay_Status = Equipment.WorkingStatuses.On)
                    If objSystemModule.Interlock_AirPressure_Visible Then
                        blResult = blResult And (objCoronaChamber.Chamberinterlock_Air_Pressure_Status = Equipment.WorkingStatuses.On)
                    End If
                    If objSystemModule.Interlock_Target13Water_Visible Then
                        blResult = blResult And (objCoronaChamber.Chamberinterlock_Target1_3_Water_Status = Equipment.WorkingStatuses.On)
                    End If
                    If objSystemModule.Interlock_Target24Water_Visible Then
                        blResult = blResult And (objCoronaChamber.Chamberinterlock_Target2_4_Water_Status = Equipment.WorkingStatuses.On)
                    End If
                    If objSystemModule.ChamberInterlock_TurboWaterVisible Then
                        blResult = blResult And (objCoronaChamber.Chamberinterlock_Turbo_Water_Status = Equipment.WorkingStatuses.On)
                    End If
                    If objSystemModule.Bias_Matchbox_Water_Visible Then
                        blResult = blResult And (objCoronaChamber.Chamberinterlock_Bias_MB_Water_Status = Equipment.WorkingStatuses.On)
                    End If
                    If objSystemModule.Target_Matchbox_Water_Visible Then
                        blResult = blResult And (objCoronaChamber.Chamberinterlock_Target_MB_Water_Status = Equipment.WorkingStatuses.On)
                    End If
                    If objSystemModule.Interlock_SubstrateTableWater_Visible Then
                        blResult = blResult And (objCoronaChamber.Chamberinterlock_Substrate_Table_Water_Status = Equipment.WorkingStatuses.On)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            Return blResult
        End Function
        Private blHasSendWaferStatus As Boolean = False
        Public Sub Pulling(ByVal source As Object, ByVal e As ElapsedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter Pulling")
            Try
                m_tmrPullingTimer.Enabled = False
                ''Reconnect PM
                If (m_objCoronaChamber IsNot Nothing) AndAlso m_objCoronaChamber.ConnectionStatus <> Equipment.WorkingStatuses.On Then

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

                'DAT CAO ADD SEND TO CORONA CHAMBER WAFER STATUS WHEN INIT OR RECONNECT
                '[KHOI HA 08-03-2013]There is wafers presented when PM is disconnected.  But when PM reconnect, all wafers disappear
                If m_IsInitOrReconnectPulling OrElse Not blHasSendWaferStatus Then
                    m_IsInitOrReconnectPulling = False
                    blHasSendWaferStatus = DoSetWaferStatus(String.Format("{0:00}", CType(m_objCoronaChamber.WaferStatus, Integer)))

                    If m_objCoronaChamber.ListOfSlotWafer().Count > 0 Then
                        For Each mSlotWafer As Integer In m_objCoronaChamber.ListOfSlotWafer()
                            CoronaUtility.SetWaferSlotToCorona(Me.EquipmentName, mSlotWafer)
                        Next
                    End If

                    AVPLib.Log.avpLogger.Debug(Me.EquipmentName & " Reconnected, Send WaferStatus=" & m_objCoronaChamber.WaferStatus.ToString)
                End If

                m_tmrPullingTimer.Enabled = True 'continue pulling

                If m_objCoronaChamber.ControlStatus = DataManagerment.Equipment.ControlStatuses.ONLINE Then
                    ' System offline when one of Power Supply is off
                    Dim ChamberModule As AVPLib.SystemModule = Nothing
                    AVPLib.ContainerData.IsChamberVisible(Me.EquipmentName, ChamberModule)
                    If ChamberModule IsNot Nothing Then
                        If ChamberModule.BiasPowerVisible AndAlso m_objCoronaChamber.Bias_Communication_Status <> Equipment.WorkingStatuses.On Then
                            DoOffline()
                            Exit Sub
                        End If
                        If ChamberModule.RFTargetPowerVisible AndAlso m_objCoronaChamber.RF_Target_Communication_Status <> Equipment.WorkingStatuses.On Then
                            DoOffline()
                            Exit Sub
                        ElseIf Not ChamberModule.RFTargetPowerVisible AndAlso ChamberModule.DCTargetPowerVisible AndAlso m_objCoronaChamber.DC_Target_Communication_Status <> Equipment.WorkingStatuses.On Then
                            DoOffline()
                            Exit Sub
                        End If
                    End If
                    ' System offline when one of Interlocks is off
                    If Not IsAllInterlockOK() Then
                        DoOffline()
                    End If
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
        ''' ReConnect to CORONA
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
            'Send Recipe Template Version
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
            CoronaUtility.Check_Recipe_Template_Version(Me.EquipmentName, Utils.GetRecipeVersion(Me.EquipmentName))
            AVPLib.Log.coreLogger.Info("Leave DoCheckRecipeTemplateVersion")
        End Sub
        ''' <author>
        '''    	<name>Dat Cao </name>
        '''    	<date> 2012-12-21</date>
        ''' </author>
        ''' <summary>
        ''' Add all commands need to pulling all time.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub AddAllCmdNeedToPollingAllTime()
            AVPLib.Log.coreLogger.Error("Missing Add command want to polling")
        End Sub

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

        Private Sub DoSetOverride_Mode(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetOverride_Mode")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.OVERRIDE_MODE.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetOverride_Mode")
        End Sub
        'Private Sub DoSetMaintenaince_Mode(ByVal val As String)
        '    AVPLib.Log.coreLogger.Info("Enter DoSetMaintenaince_Mode")
        '    Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
        '    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.MAINTENAINCE_MODE.ToString(), strData)
        '    AVPLib.Log.coreLogger.Info("Leave DoSetMaintenaince_Mode")
        'End Sub
        Private Sub DoSetTargetX_Set_Kwh_Usage(ByVal index As Byte, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetTarget_Set_Kwh_Usage")
            Select Case index
                Case 1
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET1_SET_KWH_USAGE.ToString(), val)
                Case 2
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET2_SET_KWH_USAGE.ToString(), val)
                Case 3
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET3_SET_KWH_USAGE.ToString(), val)
                Case 4
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET4_SET_KWH_USAGE.ToString(), val)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoSetTarget_Set_Kwh_Usage")
        End Sub
        Private Sub DoSetTarget_MagnatronX_On_Off(ByVal index As Byte, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetTarget_Magnatron_On_Off")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            Select Case index
                Case 1
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET1_MAGNATRON_ON_OFF.ToString(), strData)
                Case 2
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET2_MAGNATRON_ON_OFF.ToString(), strData)
                Case 3
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET3_MAGNATRON_ON_OFF.ToString(), strData)
                Case 4
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET4_MAGNATRON_ON_OFF.ToString(), strData)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoSetTarget_Magnatron_On_Off")
        End Sub

        Private Sub DoSetTarget_Select_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetTarget_Select_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET_SELECT_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetTarget_Select_Program")
        End Sub
        Private Sub DoSetTargetX_Shutter_Status(ByVal index As Byte, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetTarget_Shutter_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            Select Case index
                Case 1
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET1_SHUTTER_STATUS.ToString(), strData)
                Case 2
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET2_SHUTTER_STATUS.ToString(), strData)
                Case 3
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET3_SHUTTER_STATUS.ToString(), strData)
                Case 4
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET4_SHUTTER_STATUS.ToString(), strData)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoSetTarget_Shutter_Status")
        End Sub
        Private Sub DoSetAuto_Pumpdown_Seq(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetAuto_Pumpdown_Seq")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If val = STR_ON Then
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.AUTO_PUMPDOWN_SEQ.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.AUTO_PUMPDOWN_SEQ.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoSetAuto_Pumpdown_Seq")
        End Sub
        Private Sub DoSetAuto_Vent_Seq(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetAuto_Vent_Seq")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If val = STR_ON Then
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.AUTO_VENT_SEQ.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.AUTO_VENT_SEQ.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoSetAuto_Vent_Seq")
        End Sub
        Private Sub DoSetPump_Purge_Seq(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetPump_Purge_Seq")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If val = STR_ON Then
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PUMP_PURGE_SEQ.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PUMP_PURGE_SEQ.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoSetPump_Purge_Seq")
        End Sub
        Private Sub DoSetIG_Degas_Seq(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetIG_Degas_Seq")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If val = STR_ON Then
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.IG_DEGAS_SEQ.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Else
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.IG_DEGAS_SEQ.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoSetIG_Degas_Seq")
        End Sub
        Private Sub DoSetShutdown_Power_Seq()
            AVPLib.Log.coreLogger.Info("Enter DoSetShutdown_Power_Seq")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.SHUTDOWN_POWER_SEQ.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetShutdown_Power_Seq")
        End Sub

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
                m_RoutineExecutor.Terminate()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopRecoverPressure")
        End Sub
        Private Sub DoRateOfRise()
            AVPLib.Log.coreLogger.Info("Enter DoSetRate_Of_Rise_Seq")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If CoronaUtility.Start_Rate_Of_Rise(Me.EquipmentName, _
                                       PDC_ROR_SampleTime.ToString(), PDC_ROR_WaitTime.ToString(), PDC_ROR_Description) Then
                    m_EventPumpDownAborted.Reset()
                Else
                    Me.ThrowAlarm("Failed to start Rate Of Rise for " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoSetRate_Of_Rise_Seq")
        End Sub
        Private Sub DoStopRateOfRise()
            AVPLib.Log.coreLogger.Info("Enter DoStopRateOfRise")
            If Not CoronaUtility.Stop_Rate_Of_Rise(Me.EquipmentName) Then
                Me.ThrowAlarm("Failed to set stop Rate of Rise for " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoStopRateOfRise")
        End Sub
        Private Sub DoPumpdownCurve()
            AVPLib.Log.coreLogger.Info("Enter DoSetPumpdown_Curve_Seq")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If CoronaUtility.Start_PumpDown_Curve(Me.EquipmentName, _
                                            PDC_ROR_SampleTime.ToString(), PDC_ROR_WaitTime.ToString(), PDC_ROR_Description) Then
                    m_EventPumpDownAborted.Reset()
                Else
                    Me.ThrowAlarm("Failed to start Pump Down Curve for " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoSetPumpdown_Curve_Seq")
        End Sub
        Private Sub DoStopPumpdownCurve()
            AVPLib.Log.coreLogger.Info("Enter DoStopPumpdownCurve")
            If CoronaUtility.Stop_PumpDown_Curve(Me.EquipmentName) Then
                m_EventPumpDownAborted.Set()
            Else
                Me.ThrowAlarm("Failed to set stop Pump Down Curve for " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoStopPumpdownCurve")
        End Sub
        Private Sub DoSetInitialize_Motion(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetInitialize_Motion ")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.INITIALIZE_MOTION.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetInitialize_Motion ")
        End Sub
        Private Sub DoSetAuto_Power_Seq(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetAuto_Power_Seq")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.AUTO_POWER_SEQ.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetAuto_Power_Seq")
        End Sub

        Private Sub DoSetChamberInterlock_PSRelay(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetChamberInterlock_PSRelay")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.CHAMBERINTERLOCK_PS_INTERLOCK_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetChamberInterlock_PSRelay")
        End Sub

        Private Sub DoSetGasX_Shutoff_Valve(ByVal iGasIndex As Byte, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetGas_Shutoff_Valve")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            Select Case iGasIndex
                Case 1
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.GAS1_SHUTOFF_VALVE.ToString(), strData)
                Case 2
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.GAS2_SHUTOFF_VALVE.ToString(), strData)
                Case 3
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.GAS3_SHUTOFF_VALVE.ToString(), strData)
                Case 4
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.GAS4_SHUTOFF_VALVE.ToString(), strData)
                Case 5
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.GAS5_SHUTOFF_VALVE.ToString(), strData)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoSetGas_Shutoff_Valve")
        End Sub
        Private Sub DoSetGasX_Flowrate_Program(ByVal index As Byte, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetGas_Flowrate_Program")
            Select Case index
                Case 1
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.GAS1_FLOWRATE_PROGRAM.ToString(), val)
                Case 2
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.GAS2_FLOWRATE_PROGRAM.ToString(), val)
                Case 3
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.GAS3_FLOWRATE_PROGRAM.ToString(), val)
                Case 4
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.GAS4_FLOWRATE_PROGRAM.ToString(), val)
                Case 5
                    CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.GAS5_FLOWRATE_PROGRAM.ToString(), val)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoSetGas_Flowrate_Program")
        End Sub
        Private Sub DoSetMain_Dist_Valve(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetMain_Dist_Valve")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.MAIN_DIST_VALVE.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetMain_Dist_Valve")
        End Sub
        Private Sub DoSetSec_Dist_Valve(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetSec_Dist_Valve")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.SEC_DIST_VALVE.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetSec_Dist_Valve")
        End Sub
        Private Sub DoSetRough_Valve_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetRough_Valve_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.ROUGH_VALVE_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetRough_Valve_Status")
        End Sub
        Private Sub DoSetVent_Valve_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetVent_Valve_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.VENT_VALVE_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetVent_Valve_Status")
        End Sub
        Private Sub DoSetIsolation_Valve_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetIsolation_Valve_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.ISOLATION_VALVE_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetIsolation_Valve_Status")
        End Sub
        Private Sub DoSetHivac_Valve_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetHivac_Valve_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.HIVAC_VALVE_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetHivac_Valve_Status")
        End Sub
        Private Sub DoSetForeline_Valve_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetForeline_Valve_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.FORELINE_VALVE_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetForeline_Valve_Status")
        End Sub
        Private Sub DoSetBaratron_Valve_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetBaratron_Valve_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.BARATRON_VALVE_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetBaratron_Valve_Status")
        End Sub
        Private Sub DoSetIG_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetIG_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.IG_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetIG_Status")
        End Sub
        Private Sub DoSetMechanical_Pump_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetMechanical_Pump_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.MECHANICAL_PUMP_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetMechanical_Pump_Status")
        End Sub
        Public Sub DoSetSubstrate_Goto_Slot(ByVal val As String)
            CoronaUtility.DoSetSubstrate_Goto_Slot(val, Me.EquipmentName)
        End Sub
        Public Sub DoSetSubstrate_Table_Up_Down_Status(ByVal val As String)
            CoronaUtility.DoSetSubstrate_Table_Up_Down_Status(val, Me.EquipmentName)
        End Sub
        Public Sub DoSetSubstrate_Lift_Up_Down_Status(ByVal val As String)
            CoronaUtility.DoSetSubstrate_Lift_Up_Down_Status(val, Me.EquipmentName)
        End Sub
        Private Sub DoSetSubstrate_Table_Lift_Home(ByVal val As String)
            CoronaUtility.DoSetSubstrate_Table_Lift_Home(val, Me.EquipmentName)
        End Sub
        Private Sub DoSetSubstrate_Table_Rotate_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetSubstrate_Table_Rotate_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.SUBSTRATE_TABLE_ROTATE_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetSubstrate_Table_Rotate_Status")
        End Sub
        Private Sub DoSetSubstrate_Table_Rotate_Speed(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetSubstrate_Table_Rotate_Status")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.SUBSTRATE_TABLE_ROTATE_SPEED.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetSubstrate_Table_Rotate_Status")
        End Sub
        Private Sub DoSetSubstrate_Table_Current_Position(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetSubstrate_Table_Current_Position")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.SUBSTRATE_TABLE_CURRENT_POSITION_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetSubstrate_Table_Current_Position")
        End Sub
        Private Sub DoSetWater_Pump_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetWater_Pump_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.WATER_PUMP_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetWater_Pump_Status")
        End Sub
        Private Sub DoSetWater_Pump_Regen_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetWater_Pump_Regen_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.WATER_PUMP_REGEN_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetWater_Pump_Regen_Status")
        End Sub
        Private Sub DoSetTurbo_Pump_On_Off(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetTurbo_Pump_On_Off")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TURBO_PUMP_ON_OFF.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetTurbo_Pump_On_Off")
        End Sub
        Private Sub DoSetVat_Valve_Controller_Pressure_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetVat_Valve_Controller_Pressure_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.VAT_VALVE_CONTROLLER_PRESSURE_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetVat_Valve_Controller_Pressure_Program")
        End Sub
        Private Sub DoSetVat_Valve_Percentage_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetVat_Valve_Percentage_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.VAT_VALVE_PERCENTAGE_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetVat_Valve_Percentage_Program")
        End Sub
        Private Sub DoSetVat_Valve_Controller_Auto_Zero(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetVat_Valve_Controller_Auto_Zero")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.VAT_VALVE_CONTROLLER_AUTO_ZERO.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetVat_Valve_Controller_Auto_Zero")
        End Sub
        Private Sub DoSetVat_Valve_Controller_Teach(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetVat_Valve_Controller_Teach")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.VAT_VALVE_CONTROLLER_TEACH.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetVat_Valve_Controller_Teach")
        End Sub
        Private Sub DoSetVat_Valve_Controller_Sizeadjust(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetVat_Valve_Controller_Sizeadjust")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.VAT_VALVE_CONTROLLER_SIZEADJUST.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetVat_Valve_Controller_Sizeadjust")
        End Sub
        Private Sub DoSetRF_Target_Power_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetRF_Target_Power_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.RF_TARGET_POWER_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetRF_Target_Power_Program")
        End Sub
        Private Sub DoSetRF_Target_MB_C1_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetRF_Target_MB_C1_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.RF_TARGET_MB_C1_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetRF_Target_MB_C1_Program")
        End Sub
        Private Sub DoSetRF_Target_MB_C2_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetRF_Target_MB_C2_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.RF_TARGET_MB_C2_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetRF_Target_MB_C2_Program")
        End Sub
        Private Sub DoSetRF_Target_MB_Match_Mode_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetRF_Target_MB_Match_Mode_Program")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.RF_TARGET_MB_MATCH_MODE_PROGRAM.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetRF_Target_MB_Match_Mode_Program")
        End Sub
        Private Sub DoSetRF_Target_MB_Preset_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetRF_Target_MB_Preset_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.RF_TARGET_MB_PRESET_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetRF_Target_MB_Preset_Program")
        End Sub
        Private Sub DoSetBias_Power_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetBias_Power_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.BIAS_POWER_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetBias_Power_Program")
        End Sub
        Private Sub DoSetBias_MB_Voltage_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetBias_MB_Voltage_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.BIAS_MB_VOLTAGE_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetBias_MB_Voltage_Program")
        End Sub
        Private Sub DoSetBias_Power_Contact_On_Off(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DosetBias_Power_Contact_On_Off")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.BIAS_POWER_CONTACT_ON_OFF_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DosetBias_Power_Contact_On_Off")
        End Sub
        Private Sub DoSetBias_MB_C1_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetBias_MB_C1_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.BIAS_MB_C1_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetBias_MB_C1_Program")
        End Sub
        Private Sub DoSetBias_MB_C2_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetBias_MB_C2_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.BIAS_MB_C2_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetBias_MB_C2_Program")
        End Sub
        Private Sub DoSetBias_MB_Match_Mode_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetBias_MB_Match_Mode_Program")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.BIAS_MB_MATCH_MODE_PROGRAM.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetBias_MB_Match_Mode_Program")
        End Sub
        Private Sub DoSetDC_Target_Power_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetDC_Target_Power_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.DC_TARGET_POWER_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetDC_Target_Power_Program")
        End Sub
        Private Sub DoSetBias_MB_Preset_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetBias_MB_Preset_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.BIAS_MB_PRESET_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetBias_MB_Preset_Program")
        End Sub

        Private Sub DoSetDC_Target_Pluse_Mode_Status(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetDC_Target_Pluse_Mode_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.DC_TARGET_PULSE_MODE_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetDC_Target_Pluse_Mode_Status")
        End Sub
        Private Sub DoSetDC_Target_Pulse_Frequency_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetDC_Target_Pulse_Frequency_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.DC_TARGET_PULSE_FREQUENCY_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetDC_Target_Pulse_Frequency_Program")
        End Sub
        Private Sub DoSetDC_Target_Pulse_Width_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetBias_MB_Preset_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.DC_TARGET_PULSE_WIDTH_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetBias_MB_Preset_Program")
        End Sub
        Private Sub DoSetDC_Target_Ramp_Time_Program(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetBias_MB_Preset_Program")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.DC_TARGET_RAMP_TIME_PROGRAM.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetBias_MB_Preset_Program")
        End Sub

        Private Sub DoBias_RFPowerSupply(ByVal PnlName As String, ByVal ctrlName As String, ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoBias_RFPowerSupply")
            Select Case ctrlName
                Case "Auto"
                    If PnlName = "BiasPowerSupply" Then
                        CoronaUtility.Bias_Target_Auto(Me.EquipmentName, value)
                    Else
                        CoronaUtility.RF_Target_Auto(Me.EquipmentName, value)
                    End If
                Case "Recall"
                    If PnlName = "BiasPowerSupply" Then
                        CoronaUtility.Bias_Target_Recall(Me.EquipmentName, value)
                    Else
                        CoronaUtility.RF_Target_Recall(Me.EquipmentName, value)
                    End If
                Case "Store"
                    If PnlName = "BiasPowerSupply" Then
                        CoronaUtility.Bias_Target_Store(Me.EquipmentName, value)
                    Else
                        CoronaUtility.RF_Target_Store(Me.EquipmentName, value)
                    End If
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoBias_RFPowerSupply")
        End Sub

        Private Sub SetHeaterZone1_SetPoint(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetHeaterZone1_SetPoint")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.HEATER_ZONE1_PROGRAM.ToString(), value)
            AVPLib.Log.coreLogger.Info("Leave SetHeaterZone1_SetPoint")
        End Sub
        Private Sub SetHeaterZone2_SetPoint(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetHeaterZone2_SetPoint")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.HEATER_ZONE2_PROGRAM.ToString(), value)
            AVPLib.Log.coreLogger.Info("Leave SetHeaterZone2_SetPoint")
        End Sub
        Private Sub SetHeaterZone1_OnOff(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetHeaterZone1_OnOff")
            Dim strData As String = IIf(value = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.HEATER_ZONE1_ONOFF_PROGRAM.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave SetHeaterZone1_OnOff")
        End Sub
        Private Sub SetHeaterZone2_OnOff(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetHeaterZone2_OnOff")
            Dim strData As String = IIf(value = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.HEATER_ZONE2_ONOFF_PROGRAM.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave SetHeaterZone2_OnOff")
        End Sub
        Private Sub SetMeasure_OnOff(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetMeasure_OnOff")
            Dim strData As String = IIf(value = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.FILMETRIC_MEASURE.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave SetMeasure_OnOff")
        End Sub
        Private Sub SetGotoThickness_OnOff(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetGotoThickness_OnOff")
            Dim strData As String = IIf(value = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.FILMETRIC_GOTO_THICKNESS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave SetGotoThickness_OnOff")
        End Sub
        Private Sub SetGotoBaseLine_OnOff(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetGotoBaseline_OnOff")
            Dim strData As String = IIf(value = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.FILMETRIC_GOTO_BASELINE.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave SetGotoBaseLine_OnOff")
        End Sub
        Private Sub SetMeasure_SetPoint(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetMeasure_SetPoint")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.FILMETRIC_THICKNESS.ToString(), value)
            AVPLib.Log.coreLogger.Info("Leave SetMeasure_SetPoint")
        End Sub
        Private Sub SetFilmetric_Recipe_SP(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetFilmetric_Recipe_SP")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.FILMETRIC_RECIPE_SP.ToString(), value)
            AVPLib.Log.coreLogger.Info("Leave SetFilmetric_Recipe_SP")
        End Sub

        ''' <author>Dung Pham</author>
        ''' <date>2018-12-05>/date>
        ''' <summary>
        ''' Set IG Filament1
        ''' </summary>
        ''' val: value of control
        Private Sub SetIGFilament1(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetIGFilament1")

            Try
                CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.SWITCH_IG_FILAMENT_PROGRAM.ToString(), 1)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave SetIGFilament1")
        End Sub

        ''' <author>Dung Pham</author>
        ''' <date>2018-12-05>/date>
        ''' <summary>
        ''' Set IG Filament2
        ''' </summary>
        ''' val: value of control
        Private Sub SetIGFilament2(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetIGFilament2")

            Try
                CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.SWITCH_IG_FILAMENT_PROGRAM.ToString(), 2)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave SetIGFilament2")
        End Sub

        ''<name> kiet Tran </name>
        ''<date> 2018-12-28</date>
        ''</author>
        ''<summary>
        ''</summary>
        Private Sub ClearAllAlarm(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter ClearAllAlarm")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.CLEAR_ALL_ALARM_PROGRAM.ToString(), 1)
            AVPLib.Log.coreLogger.Info("Leave ClearAllAlarm")
        End Sub

        ''' <author>Dung Pham</author>
        ''' <date>2020-08-12>/date>
        ''' <summary>
        ''' Send command open close IG Isolation Valve
        ''' </summary>
        ''' val: value of control
        Private Sub DoSetIGIsolation_Valve(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoSetIGIsolation_Valve")

            Try
                Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
                CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.IG_ISOLATION_VALVE_STATUS.ToString(), strData)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave DoSetIGIsolation_Valve")
        End Sub
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
                Dim strPnlName, strCtrlName, strVal As String
                strCtrlName = ""
                strVal = ""
                strPnlName = ""
                Me.ParseMessage(Message, strCtrlName, strPnlName, strVal)
                Select Case strCtrlName
                    Case "SendRequestAllData"
                        SendRequestAllData()
                        DoCheckRecipeTemplateVersion()
                    Case "Target1Switch", "Target2Switch", "Target3Switch", "Target4Switch"    'Target_Select_Program
                        DoSetTarget_Select_Program(strVal)
                    Case "btnReConnect"
                        DoReConnect(Me.EquipmentName)
                    Case STR_RECOVER_PRESSURE
                        RecoverPressure()
                    Case STR_STOP_RECOVER_PRESSURE
                        StopRecoverPressure()
                    Case STR_PUMP_DOWN_CURVE
                        DoPumpdownCurve()
                    Case STR_STOP_PUMP_DOWN_CURVE
                        DoStopPumpdownCurve()
                    Case STR_RATE_OF_RISE
                        DoRateOfRise()
                    Case STR_STOP_RATE_OF_RISE
                        DoStopRateOfRise()
                    Case "btnMesaValve"
                        DoSetIsolation_Valve_Status(strVal)
                    Case "btnHivacValve"
                        DoSetHivac_Valve_Status(strVal)
                    Case "btnWaterPumpOn", "btnWaterPumpOff"
                        DoSetWater_Pump_Status(strVal)
                    Case "btnWPRegenOn", "btnWPRegenOff"
                        DoSetWater_Pump_Regen_Status(strVal)
                    Case "TurboPump"
                        DoSetTurbo_Pump_On_Off(strVal)
                    Case "ACPower"
                        DoSetAuto_Power_Seq(strVal)
                    Case "Shutter1"
                        DoSetTargetX_Shutter_Status(1, strVal)
                    Case "Shutter2"
                        DoSetTargetX_Shutter_Status(2, strVal)
                    Case "Shutter3"
                        DoSetTargetX_Shutter_Status(3, strVal)
                    Case "Shutter4"
                        DoSetTargetX_Shutter_Status(4, strVal)
                    Case "OverrideMode"
                        DoSetOverride_Mode(strVal)
                        'Case "MaintenanceMode"
                        '    DoSetMaintenaince_Mode(strVal)
                    Case "Magnatron1"
                        DoSetTarget_MagnatronX_On_Off(1, strVal)
                    Case "Magnatron2"
                        DoSetTarget_MagnatronX_On_Off(2, strVal)
                    Case "Magnatron3"
                        DoSetTarget_MagnatronX_On_Off(3, strVal)
                    Case "Magnatron4"
                        DoSetTarget_MagnatronX_On_Off(4, strVal)
                    Case "Online", "btnOnline"
                        DoOnline(strVal)
                    Case "Offline"
                        DoOffline()
                    Case "AutoPumpDown"
                        DoSetAuto_Pumpdown_Seq(strVal)
                    Case "AutoVent"
                        DoSetAuto_Vent_Seq(strVal)
                    Case "PumpPurge"
                        DoSetPump_Purge_Seq(strVal)
                    Case "IGDegas"
                        DoSetIG_Degas_Seq(strVal)
                    Case "ShutdownPower"
                        DoSetShutdown_Power_Seq()
                    Case "PSRelay"
                        DoSetChamberInterlock_PSRelay(strVal)
                    Case "ShutoffGas1"
                        DoSetGasX_Shutoff_Valve(1, strVal)
                    Case "ShutoffGas2"
                        DoSetGasX_Shutoff_Valve(2, strVal)
                    Case "ShutoffGas3"
                        DoSetGasX_Shutoff_Valve(3, strVal)
                    Case "ShutoffGas4"
                        DoSetGasX_Shutoff_Valve(4, strVal)
                    Case "ShutoffGas5"
                        DoSetGasX_Shutoff_Valve(5, strVal)
                    Case "Gas1"
                        DoSetGasX_Flowrate_Program(1, strVal)
                    Case "Gas2"
                        DoSetGasX_Flowrate_Program(2, strVal)
                    Case "Gas3"
                        DoSetGasX_Flowrate_Program(3, strVal)
                    Case "Gas4"
                        DoSetGasX_Flowrate_Program(4, strVal)
                    Case "Gas5"
                        DoSetGasX_Flowrate_Program(5, strVal)
                    Case "MainDist"
                        DoSetMain_Dist_Valve(strVal)
                    Case "IGIsolationValve"
                        DoSetIGIsolation_Valve(strVal)
                    Case "SecDist"
                        DoSetSec_Dist_Valve(strVal)
                    Case "RoughValve"
                        DoSetRough_Valve_Status(strVal)
                    Case "VentValve"
                        DoSetVent_Valve_Status(strVal)
                    Case "ForelineValve"
                        DoSetForeline_Valve_Status(strVal)
                    Case "Baratron"
                        DoSetBaratron_Valve_Status(strVal)
                    Case "IGStatus"
                        DoSetIG_Status(strVal)
                    Case "btnPumpOn"
                        DoSetMechanical_Pump_Status(strVal)
                    Case "btnPumpOff"
                        DoSetMechanical_Pump_Status("Off")
                    Case "MechanicalPump"
                        DoSetMechanical_Pump_Status(strVal)
                    Case "GoToSlot"
                        DoSetSubstrate_Goto_Slot(strVal)
                    Case "TableHome"
                        DoSetSubstrate_Table_Lift_Home(strVal)
                    Case "TableUp"
                        DoSetSubstrate_Table_Up_Down_Status("On")
                    Case "TableDown"
                        DoSetSubstrate_Table_Up_Down_Status("Off")
                    Case "LiftUp"
                        DoSetSubstrate_Lift_Up_Down_Status("On")
                    Case "LiftDown"
                        DoSetSubstrate_Lift_Up_Down_Status("Off")
                    Case "Home"    'Initialize_Motion
                        DoSetInitialize_Motion(strVal)
                    Case "Rotate"
                        DoSetSubstrate_Table_Rotate_Status(strVal)
                    Case "RotateSpeed"
                        DoSetSubstrate_Table_Rotate_Speed(strVal)
                    Case "TableHeight"
                        DoSetSubstrate_Table_Current_Position(strVal)
                    Case "Pressure"
                        DoSetVat_Valve_Controller_Pressure_Program(strVal)
                    Case "PressurePercent"
                        DoSetVat_Valve_Percentage_Program(strVal)
                    Case "AutoZero"
                        DoSetVat_Valve_Controller_Auto_Zero(strVal)
                    Case "Teach"
                        DoSetVat_Valve_Controller_Teach(strVal)
                    Case "SizeAdjust"
                        DoSetVat_Valve_Controller_Sizeadjust(strVal)
                    Case "ForwardPower"
                        If strPnlName = "RFTargetPowerSupply" Then
                            DoSetRF_Target_Power_Program(strVal)
                        Else
                            DoSetBias_Power_Program(strVal)
                        End If
                    Case "Contact"
                        DoSetBias_Power_Contact_On_Off(strVal)
                    Case "DCForwardPower"
                        DoSetDC_Target_Power_Program(strVal)
                    Case "Voltage"
                        DoSetBias_MB_Voltage_Program(strVal)
                    Case "C1"
                        If strPnlName = "RFTargetPowerSupply" Then
                            DoSetRF_Target_MB_C1_Program(strVal)
                        Else
                            DoSetBias_MB_C1_Program(strVal)
                        End If
                    Case "C2"
                        If strPnlName = "RFTargetPowerSupply" Then
                            DoSetRF_Target_MB_C2_Program(strVal)
                        Else
                            DoSetBias_MB_C2_Program(strVal)
                        End If
                    Case "MatchMode"
                        If strPnlName = "RFTargetPowerSupply" Then
                            DoSetRF_Target_MB_Match_Mode_Program(strVal)
                        Else
                            DoSetBias_MB_Match_Mode_Program(strVal)
                        End If
                    Case "Auto", "Recall", "Store"
                        DoBias_RFPowerSupply(strPnlName, strCtrlName, strVal)
                    Case "PresetsRight"
                        If strPnlName = "RFTargetPowerSupply" Then
                            DoSetRF_Target_MB_Preset_Program(strVal)
                        Else
                            DoSetBias_MB_Preset_Program(strVal)
                        End If
                    Case "PulseFrequency"
                        DoSetDC_Target_Pulse_Frequency_Program(strVal)
                    Case "PulseWidth"
                        DoSetDC_Target_Pulse_Width_Program(strVal)
                    Case "RampTime"
                        DoSetDC_Target_Ramp_Time_Program(strVal)
                    Case "PulseMode"
                        DoSetDC_Target_Pluse_Mode_Status(strVal)
                    Case "Start", "Stop", "Resume", "Pause", "Abort", "EndCurrentStep"  'Process Recipe
                        SetProcessRecipe(strCtrlName, strVal)
                    Case SET_ATM_FORELINE_CG
                        DoSetATMForelineCG()
                    Case SET_ATM_ROUGHLINE_CG
                        DoSetATMRoughlineCG()
                    Case SET_ATM_PRESSURE_CG
                        DoSetATMPressureCG()
                    Case SET_VAC_PRESSURE_CG
                        DoSetVACPressureCG()
                    Case "txtRateOfRise"
                        SetCryoWP_Rate_Of_Rise(strVal)
                    Case "txtExtendedPurgeTime"
                        SetCryoWP_Extended_PurgeTime(strVal)
                    Case "txtPumpRestartDelay"
                        SetCryoWP_Pump_Restart_Delay(strVal)
                    Case "txtRepurgeCycles"
                        SetCryoWP_Repurge_Cycles(strVal)
                    Case "txtRoughToPressure"
                        SetCryoWP_Rough_To_Pressure(strVal)
                    Case "txtStartUpTemp"
                        SetCryoWP_Start_Up_Time(strVal)
                    Case "HeaterZone1SP"
                        SetHeaterZone1_SetPoint(strVal)
                    Case "HeaterZone2SP"
                        SetHeaterZone2_SetPoint(strVal)
                    Case "HeaterZone1Status"
                        SetHeaterZone1_OnOff(strVal)
                    Case "HeaterZone2Status"
                        SetHeaterZone2_OnOff(strVal)
                    Case SendProcessLotIDCmdMessage
                        SendProcessLotID()
                    Case SendProcessWaferIDCmdMessage
                        SendProcessWaferID()
                    Case "Measure"
                        SetMeasure_OnOff(strVal)
                    Case "GotoThickness"
                        SetGotoThickness_OnOff(strVal)
                    Case "GotoBaseLine"
                        SetGotoBaseLine_OnOff(strVal)
                    Case "txtMeasure"
                        SetMeasure_SetPoint(strVal)
                    Case "txtProcessRecipe"
                        SetFilmetric_Recipe_SP(strVal)
                    Case "btnIGFilament1"
                        SetIGFilament1(strVal)
                    Case "btnIGFilament2"
                        SetIGFilament2(strVal)
                    Case "ClearAllAlarm "
                        ClearAllAlarm(strVal)
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub
#Region "SetValueOfWaterPump"
        ''' <author>
        '''     <name> Dy Do </name>
        '''     <date> 2016-01-14 </date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        Private Sub SetCryoWP_Extended_PurgeTime(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryoWP_Extended_PurgeTime")
            Try
                Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                If objChamberConfig.TurboPumpVisible Then
                    SetWaterPump_Extended_PurgeTime(value)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetCryoWP_Extended_PurgeTime")
        End Sub

        Private Sub SetCryoWP_Pump_Restart_Delay(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryoWP_Pump_Restart_Delay")
            Try
                Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                If objChamberConfig.TurboPumpVisible Then
                    SetWaterPump_Pump_Restart_Delay(value)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetCryoWP_Pump_Restart_Delay")
        End Sub

        Private Sub SetCryoWP_Rate_Of_Rise(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryoWP_Rate_Of_Rise")
            Try
                Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                If objChamberConfig.TurboPumpVisible Then
                    SetWaterPump_Rate_Of_Rise(value)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetCryoWP_Rate_Of_Rise")
        End Sub

        Private Sub SetCryoWP_Repurge_Cycles(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryoWP_Repurge_Cycles")
            Try
                Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                If objChamberConfig.TurboPumpVisible Then
                    SetWaterPump_Repurge_Cycles(value)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetCryoWP_Repurge_Cycles")
        End Sub

        Private Sub SetCryoWP_Rough_To_Pressure(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryoWP_Rough_To_Pressure")
            Try
                Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                If objChamberConfig.TurboPumpVisible Then
                    SetWaterPump_Rough_To_Pressure(value)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetCryoWP_Rough_To_Pressure")
        End Sub

        Private Sub SetCryoWP_Start_Up_Time(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryoWP_Start_Up_Time")
            Try
                Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                If objChamberConfig.TurboPumpVisible Then
                    SetWaterPump_Start_Up_Time(value)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetCryoWP_Start_Up_Time")
        End Sub
        'WaterPump P Commands
        Private Sub SetWaterPump_Extended_PurgeTime(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetWaterPump_Extended_PurgeTime")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.WATER_PUMP_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_EXTENDED_PURGE_TIME & value)
            AVPLib.Log.coreLogger.Info("Leave SetWaterPump_Extended_PurgeTime")
        End Sub
        Private Sub SetWaterPump_Pump_Restart_Delay(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetWaterPump_Pump_Restart_Delay")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.WATER_PUMP_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_PUMP_RESTART_DELAY & value)
            AVPLib.Log.coreLogger.Info("Leave SetWaterPump_Pump_Restart_Delay")
        End Sub
        Private Sub SetWaterPump_Rate_Of_Rise(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetWaterPump_Rate_Of_Rise")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.WATER_PUMP_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_RATE_OF_RISE & value)
            AVPLib.Log.coreLogger.Info("Leave SetWaterPump_Rate_Of_Rise")
        End Sub
        Private Sub SetWaterPump_Repurge_Cycles(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetWaterPump_Repurge_Cycles")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.WATER_PUMP_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_REPURGE_CYCLES & value)
            AVPLib.Log.coreLogger.Info("Leave SetWaterPump_Repurge_Cycles")
        End Sub
        Private Sub SetWaterPump_Rough_To_Pressure(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetWaterPump_Rough_To_Pressure")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.WATER_PUMP_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_ROUGH_TO_PRESSURE & value)
            AVPLib.Log.coreLogger.Info("Leave SetWaterPump_Rough_To_Pressure")
        End Sub
        Private Sub SetWaterPump_Start_Up_Time(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetWaterPump_Start_Up_Time")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.WATER_PUMP_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_START_UP_TEMPERATURE & value)
            AVPLib.Log.coreLogger.Info("Leave SetWaterPump_Start_Up_Time")
        End Sub
#End Region
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

                ElseIf (Regex.IsMatch(Message, STRING_TYPE5)) Then
                    MatchResults = Regex.Match(Message, STRING_TYPE5)
                    strPnlName = MatchResults.Groups(1).Value
                    strCtrlName = MatchResults.Groups(3).Value
                    strVal = MatchResults.Groups(4).Value

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

                ElseIf (Message.Contains("ClearAllAlarm")) Then
                    strCtrlName = Message
                Else
                    AVPLib.Log.avpLogger.Error("Can not parse " & Message)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave parseMessage")
        End Sub

#End Region
        Public Sub SendRequestAllData() Implements IRecipeProcessing.SendRequestAllData
            AVPLib.Log.coreLogger.Info("Enter SendCommandToPM")
            If RobotConfigurationValues.SUPPORT_REQUEST_ALL_DATA_CHANGED Then
                CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.REQUEST_ALL_DATA.ToString, ConfigurationValues.DEVICE_STATUS_OPEN)
            End If
            AVPLib.Log.coreLogger.Info("Enter SendCommandToPM")
        End Sub

        ''<name> Dy Do </name>
        ''<date> 2016-01-27</date>
        ''</author>
        ''<summary>
        ''</summary>
        Public Sub SendResultOfCopyRecipeTemplate(ByVal blnResult As Boolean) Implements IRecipeProcessing.SendResultOfCopyRecipeTemplate
            AVPLib.Log.coreLogger.Info("Enter SendResultOfCopyRecipeTemplate")
            CoronaUtility.SendCommandWithDataToCorona(EquipmentName, CORONACommands.SYN_COPY_RECIPE_TEMPLATE.ToString(), _
                    IIf(blnResult, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave SendResultOfCopyRecipeTemplate")
        End Sub

#Region "Process Recipe"
        Public Sub Process_Reset_Error() Implements IRecipeProcessing.Process_Reset_Error
            AVPLib.Log.coreLogger.Info("Enter PROCESS_CONTROL_DEVICE_RESET_ERROR")
            Dim valueSend As Integer = ConstEnum.enumProcessStatus.eError
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PROCESS_CONTROL_DEVICE.ToString(), String.Format("{0:00}", valueSend))
            AVPLib.Log.coreLogger.Info("Leave PROCESS_CONTROL_DEVICE_RESET_ERROR")
        End Sub

        Public Function ResumeRecipe() As Boolean Implements IRecipeProcessing.ResumeRecipe
            AVPLib.Log.coreLogger.Info("Enter ResumeRecipe")
            Dim CoronaChamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            CoronaChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Running
            CoronaChamber.IsPauseInProcess = False
            Dim valueSend As Integer = ConstEnum.enumProcessStatus.eContinue
            Return CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PROCESS_CONTROL_DEVICE.ToString(), String.Format("{0:00}", valueSend))
            AVPLib.Log.coreLogger.Info("Leave ResumeRecipe")
        End Function

        Public Function SendToPM_CurrentAVPTime() As Boolean Implements IRecipeProcessing.SendToPM_CurrentAVPTime
            AVPLib.Log.coreLogger.Info("Enter SendToPM_CurrentAVPTime")
            Return CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.CURRENT_AVP_TIME.ToString(), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff"))
            AVPLib.Log.coreLogger.Info("Leave SendToPM_CurrentAVPTime")
        End Function

        Public Sub StartRecipe(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter StartRecipe")
            Dim PathFrom As String = String.Empty
            Dim PathTo As String = String.Empty
            Dim recipeName, chamberName As String
            Try
                'Save recipe name to attr of CORONAMaintenance
                Dim objCORONA As DataManagerment.CoronaChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)

                If (objCORONA IsNot Nothing AndAlso objCORONA.CurrentWaferCount >= objCORONA.WaferCapacity) Then
                    objCORONA.Recipe = val

                    recipeName = val.Substring(0, val.LastIndexOf("("))
                    chamberName = val.Substring(val.LastIndexOf("(") + 1)
                    chamberName = chamberName.Substring(0, chamberName.LastIndexOf(")"))
                    chamberName = Utils.chamberName2ChamberID(chamberName)
                    PathFrom = AVPLib.ContainerDAO.FPath_ChamberRecipe + "\" + chamberName + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")
                    Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(chamberName)
                    'PathTo = AVPLib.ContainerData.GetDirectoryPath("ProcessRecipe") + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")
                    PathTo = serverConfig.RecipeFolder + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")

                    StartRecipe(PathFrom, PathTo, True)
                Else
                    Utils.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) & " : Not enough wafers to run process recipe")
                    '''Get status from PM
                    SendRequestAllData()
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
        End Sub

        Function CopyRecipeFile(ByVal pathFrom As String, ByVal pathTo As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CopyRecipeFile")
            Dim bRet As Boolean = False
            Try
                Const kPrcExt As String = ".prc"
                pathFrom = System.IO.Path.ChangeExtension(pathFrom, kPrcExt)
                pathTo = System.IO.Path.ChangeExtension(pathTo, kPrcExt)
                If (AVPLib.Utils.CopyFile(pathFrom, pathTo)) Then
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
                    If System.IO.File.Exists(pathFrom) Then
                        bRet = AVPLib.Utils.CopyFile(pathFrom, pathTo)
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

                If (bSetRecipeNameAndStartCmd) Then
                    If SetRecipeName(pathTo) Then
                        StartSendDataRunFileName()
                        bRet = StartProcessing()
                    Else
                        Utils.ThrowAlarm("Failed to set Recipe Name for " + Utils.chamberID2ChamberName(EquipmentName))
                        Return False
                    End If
                End If
                bRet = True
                'If (bSetRecipeNameAndStartCmd) Then
                '    Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
                '    If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                '        Dim objPM As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
                '        If (objPM IsNot Nothing) AndAlso (objPM.GetWaferInfo(1) IsNot Nothing) Then
                '            If DoSetWaferStatus(String.Format("{0:00}", CType(objPM.WaferInfo.WaferStatus, Integer))) Then
                '                If SetRecipeName(pathTo) Then
                '                    StartSendDataRunFileName()
                '                    bRet = StartProcessing()
                '                Else
                '                    Utils.ThrowAlarmWithStopRuningAndNoWait("Failed to set Recipe Name for " + Utils.chamberID2ChamberName(EquipmentName))
                '                    bRet = False
                '                End If
                '            Else
                '                Me.ThrowAlarm("Failed to set wafer status for " + Utils.chamberID2ChamberName(EquipmentName))
                '                Return False
                '            End If
                '        Else
                '            Me.ThrowAlarm("Failed to get wafer status for " + Utils.chamberID2ChamberName(EquipmentName))
                '            Return False
                '        End If
                '    Else
                '        Me.ThrowAlarm("Failed to set Slit Valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
                '        Return False
                '    End If
                'Else
                '    Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentCouldNotCopyRecipe"), _
                '                            Utils.chamberID2ChamberName(Me.EquipmentName), pathFrom))

                'End If
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

            If obj.WaferInside = Equipment.WorkingStatuses.Off Then
                AVPLib.Log.avpLogger.Error("Wafer Information is nothing, then couldn't make Run Data File Name.")
                Return False
            Else
                Dim LLName As String = ConstEnum.LLA_STR
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

                Dim slotID As String = String.Empty
                Dim GEMWaferID As String = String.Empty
                Dim waferInfo As AVPWaferInfo = Nothing
                For index As Integer = 1 To obj.WaferCapacity
                    waferInfo = obj.GetWaferInfo(index)
                    If (waferInfo IsNot Nothing) Then
                        slotID = slotID & IIf(String.IsNullOrEmpty(slotID), "", "-") & waferInfo.SlotID
                        GEMWaferID = GEMWaferID & IIf(String.IsNullOrEmpty(GEMWaferID), "", "-") & Utils.GetGEMWaferID(waferInfo.WaferID)
                    End If
                Next

                'GEMWaferID#2010_09_24_01_48_45           LLA_12    PM2.xml
                'GEMWaferID#2010_09_24_03_24_21 KAJSDFLDS_LLA_1-2-3 PM2_2.xml
                'GEMWaferID#2010_09_24_03_24_21 KAJSDFLDS_LLA_1     PM2_2.xml
                filenameWaferRun = GEMWaferID & "#" & strFolderName & "\" & _
                   DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") & ConstEnum.DataRunFileNameSeparator & LLName & "_" & _
                       slotID & ConstEnum.DataRunFileNameSeparator & Utils.chamberID2ChamberName(Me.EquipmentName)
                If (Not Process_Control_Run_Data_File_Name(Me.EquipmentName, filenameWaferRun)) Then
                    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentCouldNotSendRunDatFile"), _
                                      Utils.chamberID2ChamberName(Me.EquipmentName), filenameWaferRun))
                Else
                    Return True
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave StartSendDataRun")
            Return False
        End Function

        Public Shared Function Process_Control_Run_Data_File_Name(ByVal chamberName As String, ByVal data As String) As Boolean
            Return CoronaUtility.SendCommandWithDataToCorona(chamberName, CORONACommands.PROCESS_CONTROL_SEND_RUN_DATA_FILE_NAME.ToString(), data)
        End Function

        Public Function StopRecipe() As Boolean Implements IRecipeProcessing.StopRecipe
            AVPLib.Log.coreLogger.Info("Enter StopRecipe")
            Dim ibeChamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            ibeChamber.IsAbortInProcess = True
            Dim valueSend As Integer = ConstEnum.enumProcessStatus.eStop
            Dim bResult As Boolean = CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PROCESS_CONTROL_DEVICE.ToString(), String.Format("{0:00}", valueSend))
            'Send reset error to clear command for start button to return to normal
            Thread.Sleep(1000)
            If bResult Then
                valueSend = ConstEnum.enumProcessStatus.eResetError
                bResult = CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PROCESS_CONTROL_DEVICE.ToString(), String.Format("{0:00}", valueSend))
            End If
            AVPLib.Log.coreLogger.Info("Leave StopRecipe")
            Return bResult
        End Function

        Public Function EndCurrentStepRecipe() As Boolean
            AVPLib.Log.coreLogger.Info("Enter EndCurrentStepRecipe")
            Dim ibeChamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            ibeChamber.IsAbortInProcess = True
            Dim valueSend As Integer = ConstEnum.enumProcessStatus.eEndStep
            Dim bResult As Boolean = CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PROCESS_CONTROL_DEVICE.ToString(), String.Format("{0:00}", valueSend))
            AVPLib.Log.coreLogger.Info("Leave EndCurrentStepRecipe")
            Return bResult
        End Function

        Public Function PauseRecipe() As Boolean Implements IRecipeProcessing.PauseRecipe
            AVPLib.Log.coreLogger.Info("Enter PauseRecipe")
            Dim CoronaChamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            CoronaChamber.IsPauseInProcess = True
            Dim valueSend As Integer = ConstEnum.enumProcessStatus.ePause
            Return CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PROCESS_CONTROL_DEVICE.ToString(), String.Format("{0:00}", valueSend))
            AVPLib.Log.coreLogger.Info("Leave PauseRecipe")
        End Function

        Public Function SetRecipeName(ByVal val As String) As Boolean Implements IRecipeProcessing.SetRecipeName
            AVPLib.Log.coreLogger.Info("Enter SendToProcessRecipeValue")
            val = Utils.GetFileName(val, True) ''cut file path and ext of file
            AVPLib.Log.coreLogger.Info("Leave SendToProcessRecipeValue")
            Return CoronaUtility.SendCommandWithDataToCorona(EquipmentName, CORONACommands.PROCESS_RECIPE_NAME.ToString(), val)
        End Function

        Public Function SetDataRunFileName(ByVal val As String) As Boolean Implements IRecipeProcessing.SetDataRunFileName
            Return Process_Control_Run_Data_File_Name(Me.EquipmentName, val)
        End Function

        Public Function SetIsoValveStatus(ByVal strVal As String) As Boolean Implements IRecipeProcessing.SetIsoValveStatus
            Return CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, _
                                                    CORONACommands.ISOLATION_VALVE_STATUS.ToString(), _
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
                Dim valueSend As Integer = ConstEnum.enumProcessStatus.eStart
                If (CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PROCESS_CONTROL_DEVICE.ToString(), String.Format("{0:00}", valueSend))) Then
                    chamber.IsProcessRunning = True
                    bResult = True
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
            Return bResult
        End Function

        Public Function StartProcessingCycleATM(ByVal val As String) As Boolean Implements IRecipeProcessing.StartProcessingCycleATM
            AVPLib.Log.coreLogger.Info("Enter StartProcessingCycleATM")
            Dim bResult As Boolean = False
            If (CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PROCESS_CYCLEATM_START.ToString(), val)) Then
                bResult = True
            End If
            AVPLib.Log.coreLogger.Info("Leave StartProcessingCycleATM")
            Return bResult
        End Function
#End Region

#Region "Online - Offline"
        Private Sub OnlineProc()
            AVPLib.Log.coreLogger.Info("Enter OnlineProc")
            Try
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : A NEW THREAD BORN FOR PROCESSING ONLINE.")

                'Online condition
                Dim objPVD4Chamber As CoronaChamber = EquipmentManager.GetEquipment(Me.EquipmentName)
                ''check maintenance mode
                If objPVD4Chamber.ControlStatus = Equipment.ControlStatuses.MAINTENANCE Then
                    If m_blnThrowAlarm_When_Online Then
                        Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": In Maintenance Mode" & GO_ONLINE_FAILED)
                    End If
                Else
                    Dim Online As Boolean = Me.CheckOnline()
                    Me.RaiseFinishOnline(Online)
                End If
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
                Dim objCoronaChamber As CoronaChamber = EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objModule As SystemModule = Nothing
                If objCoronaChamber IsNot Nothing Then
                    objModule = ContainerData.GetRobotConfig(objCoronaChamber.Name)
                End If



                'Check all Communication is on
                'Buu Tran add 01/04/2012
                If objModule.RFTargetPowerVisible Then
                    If (objCoronaChamber IsNot Nothing AndAlso objCoronaChamber.RF_Target_Communication_Status <> Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Utils.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": RF Target Power Supply is disconnected" & GO_ONLINE_FAILED)
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If

                If objModule.BiasPowerVisible Then
                    If (objCoronaChamber IsNot Nothing AndAlso objCoronaChamber.Bias_Communication_Status <> Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Utils.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": Bias Power Supply is disconnected" & GO_ONLINE_FAILED)
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If

                If objModule.DCTargetPowerVisible Then
                    If (objCoronaChamber IsNot Nothing AndAlso objCoronaChamber.DC_Target_Communication_Status <> Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Utils.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": DC Target Power Supply is disconnected" & GO_ONLINE_FAILED)
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If

                'If CORONA.  If process is running or pausing.  Check all interlock only.
                'Is All Interlock made?
                If Not IsAllInterlockOK() Then
                    If m_blnThrowAlarm_When_Online Then
                        Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": All Interlocks Are Not Made" & GO_ONLINE_FAILED)
                    End If
                    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                    Return False
                End If

                'If CORONA.  If no process is running or pausing, 

                'check all interlock turbo hivac open and IG on condition before allow it to goes online.
                'Buu Tran add 01/04/2012
                If Not (objCoronaChamber.IsPauseInProcess Or objCoronaChamber.IsProcessRunning) Then
                    If Not (objCoronaChamber.Hivac_Valve_Status = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": Turbo Hivac is not opened" & GO_ONLINE_FAILED)
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                    If Not (objCoronaChamber.IGStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": IG is not On" & GO_ONLINE_FAILED)
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If

                    If (objCoronaChamber.Turbo_Pump_On_Off_Rb <> DataManagerment.Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Utils.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": Turbo is not On" & GO_ONLINE_FAILED)
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If

                '[Khoi Ha 9/9/2013] System should not be allow to online when PMx home/updown/etc  is in unknown position
                'Tin Pham add 9/9/2013
                If (objCoronaChamber.Is_MotionInitalized = Equipment.WorkingStatuses.Off) Then
                    If m_blnThrowAlarm_When_Online Then
                        Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": Motion is in unknown position" & GO_ONLINE_FAILED)
                    End If
                    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                    Return False
                End If
                'End ----------------------------------------------------------------------------------------------------

                AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                Return True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckOnline")
            Return False
        End Function
#End Region

#Region "Sequence Processing"
        'CtrlName: Name of control, val: value of control
        Public Sub SetProcessRecipe(ByVal ctrlname As String, ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetProcessRecipe")
            Select Case ctrlname
                Case "Resume"
                    ResumeRecipe()
                Case "Start" 'button
                    Me.StartRecipe(Val)
                Case "Pause" 'button
                    PauseRecipe()
                Case "Stop" 'button
                    StopRecipe()
                Case "EndCurrentStep", "Abort"
                    EndCurrentStepRecipe()
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetProcessRecipe")
        End Sub

        'TODO:
        'ADD MORE SEQUENCE PROCESSING HERE
        'PDC/ROR/IGDEGAS...


        Public Sub CopyRecipeToPMFolder() Implements IRecipeProcessing.CopyRecipeToPMFolder

        End Sub
        Public Sub CopyRecipeTemplate() Implements IRecipeProcessing.CopyRecipeTemplate
            ''Implement in ChamberController
        End Sub
#End Region
#Region "Manula Action"
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
        ''' Send command to CORONA to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Public Function DoSetWaferStatus(ByVal strStatus As String) As Boolean Implements IRecipeProcessing.DoSetWaferStatus
            AVPLib.Log.coreLogger.Info("Enter DoSetWaferStatus")
            Return CoronaUtility.SetWaferStatusToCorona(Me.EquipmentName, strStatus)
            AVPLib.Log.coreLogger.Info("Leave DoSetWaferStatus")
        End Function
#End Region
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

#Region "Reset Quart/Usage"
        Public Sub DoResetShieldxKWH(ByVal TargetNumber As Integer, ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoResetShieldxKWH")
            Try
                'Send 4 command ShieldKWH to PVD4 core here
                Select Case TargetNumber
                    Case 1
                        If CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET1_SET_SHIELD_QUART.ToString(), value) = False Then
                            Me.ThrowAlarm("Failed to set/reset Target 1 Shield Quart value " + Utils.chamberID2ChamberName(EquipmentName))
                        End If
                    Case 2
                        If CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET2_SET_SHIELD_QUART.ToString(), value) = False Then
                            Me.ThrowAlarm("Failed to set/reset Target 2 Shield Quart value " + Utils.chamberID2ChamberName(EquipmentName))
                        End If
                    Case 3
                        If CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET3_SET_SHIELD_QUART.ToString(), value) = False Then
                            Me.ThrowAlarm("Failed to set/reset Target 3 Shield Quart value " + Utils.chamberID2ChamberName(EquipmentName))
                        End If
                    Case 4
                        If CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET4_SET_SHIELD_QUART.ToString(), value) = False Then
                            Me.ThrowAlarm("Failed to set/reset Target 4 Shield Quart value " + Utils.chamberID2ChamberName(EquipmentName))
                        End If
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoResetShieldxKWH")
        End Sub
#End Region

#Region "Reset Target"
        Public Sub DoResetTargetKWHx(ByVal TargetNumber As Integer, ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoResetTargetKWH")
            Try
                'Send 4 command SourceUsage to PVD4 core here
                Select Case TargetNumber
                    Case 1
                        If CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET1_SET_KWH_USAGE.ToString(), value) = False Then
                            Me.ThrowAlarm("Failed to set/reset Target 1 KWH value " + Utils.chamberID2ChamberName(EquipmentName))
                        End If
                    Case 2
                        If CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET2_SET_KWH_USAGE.ToString(), value) = False Then
                            Me.ThrowAlarm("Failed to set/reset Target 2 KWH value " + Utils.chamberID2ChamberName(EquipmentName))
                        End If
                    Case 3
                        If CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET3_SET_KWH_USAGE.ToString(), value) = False Then
                            Me.ThrowAlarm("Failed to set/reset Target 3 KWH value " + Utils.chamberID2ChamberName(EquipmentName))
                        End If
                    Case 4
                        If CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.TARGET4_SET_KWH_USAGE.ToString(), value) = False Then
                            Me.ThrowAlarm("Failed to set/reset Target 4 KWH value " + Utils.chamberID2ChamberName(EquipmentName))
                        End If
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoResetTargetKWH")
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
            Dim lstResult As New List(Of String)
            Try
                ' Get target power
                Dim strSelectTarget As String = "RFTargetPower"
                Dim objChamberConfig As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(strStationName)

                If objChamberConfig IsNot Nothing Then
                    If objChamberConfig.DCTargetPowerVisible Then
                        strSelectTarget = "DCTargetPower"
                    End If
                End If

                Dim XPATH_TARGET_SELECTOR As String = "Recipe/StepList/Step[SeqNo='" & "{0}" & "']/" & strSelectTarget + "/TargetSelection"

                'jump to sRecipeName to get Targetx
                Dim xmldoc As New Xml.XmlDocument
                xmldoc.Load(AVPLib.ContainerDAO.FPath_ChamberRecipe + "\" + Me.EquipmentName + "\" + strRecipeName & ".xml")

                If xmldoc Is Nothing Then
                    AVPLib.Log.avpLogger.Error("Error with file Recipe: " & strRecipeName)
                    'log error
                    Return Nothing
                End If

                'count step in recipe file
                Dim iMaxStep As Integer = xmldoc.SelectSingleNode("Recipe/StepList").ChildNodes.Count
                For j As Integer = 0 To iMaxStep - 1
                    'jump to each step and get Target
                    Dim xmlNode As Xml.XmlNode = xmldoc.SelectSingleNode(String.Format(XPATH_TARGET_SELECTOR, (j + 1).ToString()))
                    If xmlNode Is Nothing Then
                        Exit For
                    End If

                    'for each step in Recipe to collect Tx
                    Dim strTarget As String = xmlNode.InnerText
                    'Recipe/steplist/stepx/TargetControl/T1
                    ''strTarget=T1
                    If Not lstResult.Contains(strTarget) Then
                        lstResult.Add(strTarget)
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return lstResult
        End Function

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
                Dim objPVD4Chamber As CoronaChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objConfigChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                Dim currentShieldsQuartz As Double = 0

                If objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.PVD4 Then
                    ' Init variable
                    Dim m_fcurrentShieldsQuartz As Double
                    Dim m_fAlarmShieldsQuartz As Double
                    Dim m_fMaxShieldsQuartz As Double

                    ' Check each target is in recipe, if one of them is over limit, then continue
                    For Each sTarget As String In sTargetUsed
                        Select Case sTarget
                            Case "T1"
                                m_fcurrentShieldsQuartz = objPVD4Chamber.Target1_Shield_Quart
                                m_fAlarmShieldsQuartz = objConfigChamber.ShieldsQuartzLimit
                                m_fMaxShieldsQuartz = objConfigChamber.Max_KWH_ShieldsQuartz
                            Case "T2"
                                m_fcurrentShieldsQuartz = objPVD4Chamber.Target2_Shield_Quart
                                m_fAlarmShieldsQuartz = objConfigChamber.ShieldsQuartzLimit1
                                m_fMaxShieldsQuartz = objConfigChamber.Max_KWH_ShieldsQuartz1
                            Case "T3"
                                m_fcurrentShieldsQuartz = objPVD4Chamber.Target3_Shield_Quart
                                m_fAlarmShieldsQuartz = objConfigChamber.ShieldsQuartzLimit2
                                m_fMaxShieldsQuartz = objConfigChamber.Max_KWH_ShieldsQuartz2
                            Case "T4"
                                m_fcurrentShieldsQuartz = objPVD4Chamber.Target4_Shield_Quart
                                m_fAlarmShieldsQuartz = objConfigChamber.ShieldsQuartzLimit3
                                m_fMaxShieldsQuartz = objConfigChamber.Max_KWH_ShieldsQuartz3

                        End Select

                        If objPVD4Chamber.IsUseMaxLimit Then
                            If m_fcurrentShieldsQuartz >= Math.Abs(m_fAlarmShieldsQuartz - m_fMaxShieldsQuartz) Then
                                ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + "(" + sTarget + ")" + ", "
                                Exit For
                            End If
                        Else
                            If m_fcurrentShieldsQuartz >= m_fAlarmShieldsQuartz Then
                                ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + "(" + sTarget + ")" + ", "
                                Exit For
                            End If
                        End If
                    Next
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
            Dim ListOf_PMReachFaultLmt As String = String.Empty
            Try
                Dim objPVD4Chamber As CoronaChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objConfigChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                Dim currentShieldsQuartz As Double = 0

                If objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.PVD4 Then
                    ' Init variable
                    Dim m_fcurrentShieldsQuartz As Double
                    Dim m_fAlarmShieldsQuartz As Double
                    Dim m_fMaxShieldsQuartz As Double

                    ' Check each target is in recipe, if one of them is over limit, then continue
                    For Each sTarget As String In sTargetUsed
                        Select Case sTarget
                            Case "T1"
                                m_fcurrentShieldsQuartz = objPVD4Chamber.Target1_Shield_Quart
                                m_fAlarmShieldsQuartz = objConfigChamber.ShieldsQuartzWarning
                                m_fMaxShieldsQuartz = objConfigChamber.Max_KWH_ShieldsQuartz
                            Case "T2"
                                m_fcurrentShieldsQuartz = objPVD4Chamber.Target2_Shield_Quart
                                m_fAlarmShieldsQuartz = objConfigChamber.ShieldsQuartzWarning1
                                m_fMaxShieldsQuartz = objConfigChamber.Max_KWH_ShieldsQuartz1
                            Case "T3"
                                m_fcurrentShieldsQuartz = objPVD4Chamber.Target3_Shield_Quart
                                m_fAlarmShieldsQuartz = objConfigChamber.ShieldsQuartzWarning1
                                m_fMaxShieldsQuartz = objConfigChamber.Max_KWH_ShieldsQuartz2
                            Case "T4"
                                m_fcurrentShieldsQuartz = objPVD4Chamber.Target4_Shield_Quart
                                m_fAlarmShieldsQuartz = objConfigChamber.ShieldsQuartzWarning1
                                m_fMaxShieldsQuartz = objConfigChamber.Max_KWH_ShieldsQuartz3

                        End Select

                        If objPVD4Chamber.IsUseMaxLimit Then
                            If m_fcurrentShieldsQuartz >= Math.Abs(m_fAlarmShieldsQuartz - m_fMaxShieldsQuartz) Then
                                ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + "(" + sTarget + ")" + ", "
                                Exit For
                            End If
                        Else
                            If m_fcurrentShieldsQuartz >= m_fAlarmShieldsQuartz Then
                                ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(Me.EquipmentName) + "(" + sTarget + ")" + ", "
                                Exit For
                            End If
                        End If
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return ListOf_PMReachFaultLmt
        End Function

        ''' <author>Hai Tran</author>
        ''' <date>2016-06-17>/date>
        ''' <summary>
        ''' Send process Lot ID to PM
        ''' </summary>
        Public Overridable Function SendProcessLotID() As Boolean Implements IRecipeProcessing.SendProcessLotID
            AVPLib.Log.coreLogger.Info("Enter SendProcessLotID")
            Try
                Dim ObjPM As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                If ObjPM IsNot Nothing AndAlso ObjPM.GetWaferInfo() IsNot Nothing Then
                    Return CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PROCESS_LOT_ID.ToString(), Utils.GetLotIDFromWafer(ObjPM.GetWaferInfo().WaferID))
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendProcessLotID")
            Return False
        End Function

        ''' <author>Hai Tran</author>
        ''' <date>2016-06-17>/date>
        ''' <summary>
        ''' Send process Wafer ID to PM
        ''' </summary>
        Public Overridable Function SendProcessWaferID() As Boolean Implements IRecipeProcessing.SendProcessWaferID
            AVPLib.Log.coreLogger.Info("Enter SendProcessWaferID")
            Try
                Dim ObjPM As DataManagerment.CoronaChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                If ObjPM IsNot Nothing AndAlso Not String.IsNullOrEmpty(ObjPM.Process_Wafer_ID) Then
                    Return CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.PROCESS_WAFER_ID.ToString(), ObjPM.Process_Wafer_ID)
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendProcessWaferID")
            Return False
        End Function

        Public Function StartWarmUp() As Boolean Implements IRecipeProcessing.StartWarmUp
            Return True
        End Function

        Public Function CheckingKWHOverAlarmLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingKWHOverAlarmLimit
            Return True
        End Function

        Public Function CheckingKWHOverWarningLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingKWHOverWarningLimit
            Return True
        End Function

#Region "Set VAT/VAC"
        Private Sub DoSetATMForelineCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetATMForelineCG")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.FORELINE_CG_ATM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetATMForelineCG")
        End Sub


        Private Sub DoSetATMRoughlineCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetATMRoughlineCG")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.MECHANICAL_PUMP_CG_ATM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetATMRoughlineCG")
        End Sub

        Private Sub DoSetATMPressureCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetATMPressureCG")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.CHAMBER_CG_ATM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetATMPressureCG")
        End Sub

        Private Sub DoSetVACPressureCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetVACPressureCG")
            CoronaUtility.SendCommandWithDataToCorona(Me.EquipmentName, CORONACommands.CHAMBER_CG_VAC.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetVACPressureCG")
        End Sub

#End Region
    End Class
End Namespace


