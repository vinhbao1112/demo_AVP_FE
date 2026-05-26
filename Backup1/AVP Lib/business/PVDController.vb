Imports System.Timers
Imports System.Threading
Imports AVPLib.DataManagerment
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum
Namespace Business
    Public Class PVDController
        Inherits ControllerObject
        Implements IRecipeProcessing
#Region "Class Constants & Variables"
        Const STRING_TYPE1 As String = "^(\w+)\.(\w+) (.*)$"
        Const STRING_TYPE2 As String = "^(\w+)\.(\w+)$"
        Const STRING_TYPE3 As String = "^(\w+) (\w+)$"
        Const STRING_TYPE4 As String = "^(\w+)$"
        Private m_tmrPullingTimer As System.Timers.Timer

        Private m_fTargetKWHWarningLimitSend As Double = 0
        Private m_fTargetKWHAlarmLimitSend As Double = 0
        Private m_fTargetMaxKWHSend As Double = 0
        Private m_bFirstTimeSend As Boolean = True

        Const ExpectedMechanicalPumpPressureWhenPumpDown As Double = 0.1 ' 0.1 Torr
        Private m_lLastReconnectTickCount As Long = 0
        Private m_iReconnectTimes As Integer = 0
        Private m_blnThrowAlarm_When_Online As Boolean = True
        Protected m_RoutineExecutor As ChamberRoutineExecutor = Nothing
#End Region

#Region "Properties"
        Private trdToolOnline As Thread
        Private m_EventStopThread As ManualResetEvent = New ManualResetEvent(False)
        ' Abort Pumpdown Event.
        Private m_EventPumpDownAborted As ManualResetEvent = New ManualResetEvent(False)

        Public ReadOnly Property CurrentRoutineExecutor() As ChamberRoutineExecutor
            Get
                Return m_RoutineExecutor
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
            m_tmrPullingTimer.Enabled = True
            AddHandler m_tmrPullingTimer.Elapsed, AddressOf Pulling
            m_tmrPullingTimer.Interval = ContainerData.GetPolling(ConstEnum.PVD_POLLING_STATUS_REPORT).Interval ''read from config file
            m_RoutineExecutor = New ChamberRoutineExecutor(EQName)
            Me.EquipmentName = EQName
        End Sub

        Public Overrides Sub Dispose()
            AVPLib.Log.coreLogger.Info("Enter Dispose")
            Try
                m_EventStopThread.Set()
                m_EventPumpDownAborted.Close()
                m_tmrPullingTimer.Enabled = False
                RemoveHandler m_tmrPullingTimer.Elapsed, AddressOf Pulling
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Dispose")
        End Sub
#End Region

#Region "Helper Functions"
#Region "Reset Quart/Usage"
        Public Sub DoResetShieldKWH(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoResetShieldKWH")
            Try
                If PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.SHIELD_KWH_PROGRAM.ToString(), value) = False Then
                    Me.ThrowAlarm("Failed to reset Shield value " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoResetShieldKWH")
        End Sub

        Public Sub DoResetTargetKWH(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoResetTargetKWH")
            Try
                Dim chamberType As PVDType = AVPLib.ContainerData.ChamberPVDType(Me.EquipmentName)
                If chamberType = PVDType.DCPVD Then
                    If PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.RESET_DC_TARGET_KWH.ToString(), value) = False Then
                        Me.ThrowAlarm("Failed to set/reset Target KWH value " + Utils.chamberID2ChamberName(EquipmentName))
                    End If
                ElseIf chamberType = PVDType.RFPVD Then
                    If PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.RESET_RF_TARGET_KWH.ToString(), value) = False Then
                        Me.ThrowAlarm("Failed to set/reset Target KWH value " + Utils.chamberID2ChamberName(EquipmentName))
                    End If
                Else
                    'if DC/RF Target PowerSupply is not install, send Bias KWH to PM
                    If PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.BIAS_POWER_KWH_PROGRAM.ToString(), value) = False Then
                        Me.ThrowAlarm("Failed to set/reset Target KWH value " + Utils.chamberID2ChamberName(EquipmentName))
                    End If
                    'AVPLib.Log.avpLogger.Debug("Reset Target KWH with No DC - RF PVD")
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoResetTargetKWH")
        End Sub
#End Region
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-01-21</date>
        ''' </author>
        ''' <summary>
        ''' GetDataBaseOnSlitValve: Parse to Data base on SlitValve status
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub GetDataBaseOnSlitValve(ByVal Status As AVPLib.DataManagerment.Equipment.WorkingStatuses, ByRef strData As String)
            AVPLib.Log.coreLogger.Info("Enter GetDataBaseOnSlitValve")
            If Status = Equipment.WorkingStatuses.On Then
                strData = ConfigurationValues.DEVICE_STATUS_OPEN
            ElseIf Status = Equipment.WorkingStatuses.Off Then
                strData = ConfigurationValues.DEVICE_STATUS_CLOSED
            Else ''error or unknown
                strData = ConfigurationValues.DEVICE_STATUS_OTHER
            End If
            AVPLib.Log.coreLogger.Info("Leave GetDataBaseOnSlitValve")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-01-21</date>
        ''' </author>
        ''' <summary>
        ''' Pulling: send slitvalve and roughpump status to PVD
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Pulling(ByVal source As Object, ByVal e As ElapsedEventArgs)

            ' Prevent re-entry
            m_tmrPullingTimer.Enabled = False
            AVPLib.Log.coreLogger.Info("Enter Pulling")
            Try

                Dim objRoughPumpMachine As DataManagerment.RoughPumpMachine = CType(DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.RoughPumpMachine1.ToString()), DataManagerment.RoughPumpMachine)
                If (objRoughPumpMachine IsNot Nothing) Then

                    PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, _
                    PVDCommands.TM_ROUGH_LINE_CONVECTRON_GAUGE.ToString(), _
                    objRoughPumpMachine.CG.ToString(), False)

                    ' Update SECS/GEM variables by Dat Cao
                    ' Var Name: PMX.MechanicalPumpPressure
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "MechanicalPumpPressure", VALUELib.ValueType.F4, objRoughPumpMachine.CG.ToString())

                End If
                
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

                ' Update KWH Warning/Alarm Limit
                Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                If (objChamber IsNot Nothing) Then

                    If (m_bFirstTimeSend) Then ' First Time => Sync value
                        m_fTargetKWHWarningLimitSend = objChamber.Warning_KWH
                        m_fTargetKWHAlarmLimitSend = objChamber.Alarm_KWH
                        If objChamber.Max_KWH_Source > 0 Then
                            m_fTargetMaxKWHSend = objChamber.Max_KWH_Source
                        End If
                        '''Update to EQ and SECSGEM
                        Dim objEQ As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Utils.chamberName2ChamberID(objChamber.Name))
                        If objEQ IsNot Nothing Then
                            CType(objEQ, AVPLib.DataManagerment.PVDChamber).TargetLimit_KWH_Readback = objChamber.Alarm_KWH
                            CType(objEQ, AVPLib.DataManagerment.PVDChamber).TargetWarning_KWH_Readback = objChamber.Warning_KWH
                            CType(objEQ, AVPLib.DataManagerment.PVDChamber).Max_KWH_Source = objChamber.Max_KWH_Source
                        End If
                        m_bFirstTimeSend = False
                    Else
                        ' Send Target KWH Warning Limit if changed
                        If (m_fTargetKWHWarningLimitSend <> objChamber.Warning_KWH) Then
                            '''Update to EQ and SECSGEM
                            Dim objEQ As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Utils.chamberName2ChamberID(objChamber.Name))
                            If objEQ IsNot Nothing Then
                                CType(objEQ, AVPLib.DataManagerment.PVDChamber).TargetWarning_KWH_Readback = objChamber.Warning_KWH
                            End If
                            ''''''''''
                            Dim bRes As Boolean = PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, _
                                                                                      PVDCommands.TARGET_KWH_WARNING_LIMIT.ToString(), _
                                                                                      objChamber.Warning_KWH.ToString(), False)
                            If (bRes) Then
                                m_fTargetKWHWarningLimitSend = objChamber.Warning_KWH
                            End If
                        End If

                        ' Send Target KWH Alarm Limit if changed
                        If (m_fTargetKWHAlarmLimitSend <> objChamber.Alarm_KWH) Then
                            '''Update to EQ and SECSGEM
                            Dim objEQ As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Utils.chamberName2ChamberID(objChamber.Name))
                            If objEQ IsNot Nothing Then
                                CType(objEQ, AVPLib.DataManagerment.PVDChamber).TargetLimit_KWH_Readback = objChamber.Alarm_KWH
                            End If
                            '''''''''
                            Dim bRes As Boolean = PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, _
                                                                                      PVDCommands.TARGET_KWH_ALARM_LIMIT.ToString(), _
                                                                                      objChamber.Alarm_KWH.ToString(), False)
                            If (bRes) Then
                                m_fTargetKWHAlarmLimitSend = objChamber.Alarm_KWH
                            End If
                        End If

                        ' Send Max KWH  if changed
                        If (m_fTargetMaxKWHSend <> objChamber.Max_KWH_Source) AndAlso ObjPM.IsUseMaxLimit Then
                            '''Update to EQ and SECSGEM
                            Dim objEQ As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Utils.chamberName2ChamberID(objChamber.Name))
                            If objEQ IsNot Nothing Then
                                CType(objEQ, AVPLib.DataManagerment.PVDChamber).Max_KWH_Source = objChamber.Max_KWH_Source
                            End If
                            '''''''''
                            Dim bRes As Boolean = PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, _
                                                                                      PVDCommands.MAX_USAGE_KWH.ToString(), _
                                                                                      objChamber.Max_KWH_Source.ToString(), False)
                            If (bRes) Then
                                m_fTargetMaxKWHSend = objChamber.Max_KWH_Source
                            End If
                        End If

                    End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            ' Continue
            m_tmrPullingTimer.Enabled = True
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
            Dim Connection As Communication.PMServerConnection = _
                        CType(Communication.ConnectionManager.GetConnection(ChamberName), Communication.PMServerConnection)
            If Connection IsNot Nothing Then
                Connection.Open()
            Else
                AVPLib.Log.coreLogger.Error("CAN NOT GET THE " + ChamberName + " CONNECTION OBJECT")
            End If
            AVPLib.Log.coreLogger.Info("Leave DoReConnect")
        End Sub
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

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoClamp_UnClamp(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoWaterPump")
            Select Case val
                Case STR_ON
                    PVDUtility.Clamp_UnClamp_Status(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.Clamp_UnClamp_Status(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoWaterPump")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoOverrideMode(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoOverrideMode")
            Select Case val
                Case STR_ON
                    PVDUtility.SetOverrideMode(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.SetOverrideMode(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoOverrideMode")
        End Sub

#Region "Set VAT/VAC"
        Private Sub DoSetATMForelineCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetATMForelineCG")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.FORELINE_CG_ATM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetATMForelineCG")
        End Sub

        Private Sub DoSetVACForelineCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetVACForelineCG")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.FORELINE_CG_VAC.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetVACForelineCG")
        End Sub

        Private Sub DoSetATMRoughlineCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetATMRoughlineCG")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.ROUGHLINE_CG_ATM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetATMRoughlineCG")
        End Sub

        Private Sub DoSetVACRoughlineCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetVACRoughlineCG")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.ROUGHLINE_CG_VAC.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetVACRoughlineCG")
        End Sub

        Private Sub DoSetATMPressureCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetATMPressureCG")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.PRESSURE_CG_ATM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetATMPressureCG")
        End Sub

        Private Sub DoSetVACPressureCG()
            AVPLib.Log.coreLogger.Info("Enter DoSetVACPressureCG")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.PRESSURE_CG_VAC.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoSetVACPressureCG")
        End Sub

#End Region
#Region "Valve"
        ''CtrlName: Name of control, val: value of control
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub ChangeValve(ByVal ctrlName As String, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeValve")
            Dim bOpen As Boolean = False
            If (val = STR_ON) Then
                bOpen = True
            End If
            Select Case ctrlName
                Case "ValveMainGas"
                    ChangeMainGasValve(bOpen)
                Case "ValveBaratron"
                    ChangeBaratronValve(bOpen)
                Case "ValveVent"
                    ChangeVentValve(bOpen)
                Case "ValveTurbo_Isolation"
                    ChangeTurboIsolationValve(bOpen)
                Case "ValveWater"
                    ChangeWaterValve(bOpen)
                Case "ValveRough"
                    ChangeRoughValve(bOpen)
                Case "ValveShutOff1"
                    ChangeShutOff1Valve(bOpen)
                Case "ValveShutOff2"
                    ChangeShutOff2Valve(bOpen)
                Case "ValveShutOff3"
                    ChangeShutOff3Valve(bOpen)
                Case "ValveShutOff4"
                    ChangeShutOff4Valve(bOpen)
                Case "ValveShutOff5"
                    ChangeShutOff5Valve(bOpen)
                Case "ValveSupply5"
                    ChangeSupply5Valve(bOpen)
                Case "ValveSupply4"
                    ChangeSupply4Valve(bOpen)
                Case "ValveSupply3"
                    ChangeSupply3Valve(bOpen)
                Case "ValveSupply2"
                    ChangeSupply2Valve(bOpen)
                Case "ValveSupply1"
                    ChangeSupply1Valve(bOpen)
            End Select
            AVPLib.Log.coreLogger.Info("Leave ChangeValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeWaterValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeWaterValve")
            PVDUtility.Water_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeWaterValve")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-07</date>
        ''' </author>
        ''' <summary>
        ''' Call Open/Close Rough Valve by Manual
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeRoughValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeRoughValve")

            If bOpen Then
                'query rough line by manual
                MakeRoughLineInUse(True)
            Else
                PVDUtility.Rough_Valve(Me.EquipmentName, _
                            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            End If
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
        Private Sub ChangeVentValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeVentValve")
            PVDUtility.Vent_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeVentValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeTurboIsolationValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeTurboIsolationValve")
            PVDUtility.Turbo_Isolation_Valve(Me.EquipmentName, _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeTurboIsolationValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeBaratronValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeBaratronValve")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.BARATRON_VALVE_STATUS.ToString(), _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeBaratronValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeMainGasValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeMainGasValve")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MAIN_GAS_VALVE_STATUS.ToString(), _
            IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeMainGasValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangePlasmaIgniterValve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangePlasmaIgniterValve")
            PVDUtility.Plasma_Igniter_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangePlasmaIgniterValve")
        End Sub
        '  SHUTOFF1_VALVE
        Private Sub ChangeShutOff1Valve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeShutOff1Valve")
            PVDUtility.ShutOff1_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeShutOff1Valve")
        End Sub
        '  SHUTOFF2_VALVE
        Private Sub ChangeShutOff2Valve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeShutOff2Valve")
            PVDUtility.ShutOff2_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeShutOff2Valve")
        End Sub
        '  SHUTOFF3_VALVE
        Private Sub ChangeShutOff3Valve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeShutOff3Valve")
            PVDUtility.ShutOff3_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeShutOff3Valve")
        End Sub
        '  SHUTOFF4_VALVE
        Private Sub ChangeShutOff4Valve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeShutOff4Valve")
            PVDUtility.ShutOff4_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeShutOff4Valve")
        End Sub
        '  SHUTOFF5_VALVE
        Private Sub ChangeShutOff5Valve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeShutOff5Valve")
            PVDUtility.ShutOff5_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeShutOff5Valve")
        End Sub
        '  SUPPLY5_VALVE
        Private Sub ChangeSupply5Valve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeSupply5Valve")
            PVDUtility.Supply5_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeSupply5Valve")
        End Sub
        '  SUPPLY4_VALVE
        Private Sub ChangeSupply4Valve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeSupply4Valve")
            PVDUtility.Supply4_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeSupply4Valve")
        End Sub
        '  SUPPLY3_VALVE
        Private Sub ChangeSupply3Valve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeSupply3Valve")
            PVDUtility.Supply3_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeSupply3Valve")
        End Sub
        '  SUPPLY2_VALVE
        Private Sub ChangeSupply2Valve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeSupply2Valve")
            PVDUtility.Supply2_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeSupply2Valve")
        End Sub
        '  SUPPLY1_VALVE
        Private Sub ChangeSupply1Valve(ByVal bOpen As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeSupply1Valve")
            PVDUtility.Supply1_Valve(Me.EquipmentName, IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, _
                                            ConfigurationValues.DEVICE_STATUS_CLOSED))
            AVPLib.Log.coreLogger.Info("Leave ChangeSupply1Valve")
        End Sub
#End Region

#Region "Bias Power Supply"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoBias_RFPowerSupply(ByVal PnlName As String, ByVal ctrlName As String, ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter DoBias_RFPowerSupply")
            Select Case ctrlName
                Case "btnAuto"
                    If PnlName = "BiasPowerSupply" Then
                        PVDUtility.Bias_Target_Auto(Me.EquipmentName, value)
                    Else
                        PVDUtility.RF_Target_Auto(Me.EquipmentName, value)
                    End If
                Case "btnRecall"
                    If PnlName = "BiasPowerSupply" Then
                        PVDUtility.Bias_Target_Recall(Me.EquipmentName, value)
                    Else
                        PVDUtility.RF_Target_Recall(Me.EquipmentName, value)
                    End If
                Case "btnStore"
                    If PnlName = "BiasPowerSupply" Then
                        PVDUtility.Bias_Target_Store(Me.EquipmentName, value)
                    Else
                        PVDUtility.RF_Target_Store(Me.EquipmentName, value)
                    End If
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoBias_RFPowerSupply")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeBias_RFPowerSupply(ByVal PnlName As String, ByVal ctrlName As String, ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeBias_RFPowerSupply")
            Select Case ctrlName
                Case "txtVoltageRight"
                    PVDUtility.Bias_Voltage_Program(Me.EquipmentName, value)
                Case "txtForwardPowerRight"
                    If PnlName = "BiasPowerSupply" Then
                        PVDUtility.Bias_Target_Forward_Power_Program(Me.EquipmentName, value)
                    Else
                        PVDUtility.RF_Target_Forward_Power_Program(Me.EquipmentName, value)
                    End If
                Case "txtC1Right"
                    If PnlName = "BiasPowerSupply" Then
                        PVDUtility.Bias_Target_C1_Program(Me.EquipmentName, value)
                    Else
                        PVDUtility.RF_Target_C1_Program(Me.EquipmentName, value)
                    End If
                Case "txtC2Right"
                    If PnlName = "BiasPowerSupply" Then
                        PVDUtility.Bias_Target_C2_Program(Me.EquipmentName, value)
                    Else
                        PVDUtility.RF_Target_C2_Program(Me.EquipmentName, value)
                    End If
                Case "txtPresetsRight"
                    If PnlName = "BiasPowerSupply" Then
                        PVDUtility.Bias_Target_Presets_Program(Me.EquipmentName, value)
                    Else
                        PVDUtility.RF_Target_Presets_Program(Me.EquipmentName, value)
                    End If
            End Select
            AVPLib.Log.coreLogger.Info("Leave ChangeBias_RFPowerSupply")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetBias_ForwardPower(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBias_ForwardPower")
            PVDUtility.Bias_Target_Forward_Power_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetBias_ForwardPower")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetBias_C1(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBias_C1")
            PVDUtility.Bias_Target_C1_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetBias_C1")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetBias_C2(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBias_C2")
            PVDUtility.Bias_Target_C2_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetBias_C2")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeBias_Auto(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeBias_Auto")
            PVDUtility.Bias_Target_Auto(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave ChangeBias_Auto")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeBias_Presets(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeBias_Presets")
            PVDUtility.Bias_Target_Presets_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave ChangeBias_Presets")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeBias_Recall(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeBias_Recall")
            PVDUtility.Bias_Target_Recall(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave ChangeBias_Recall")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeBias_Store(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeBias_Store")
            PVDUtility.Bias_Target_Store(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave ChangeBias_Store")
        End Sub

#End Region

#Region "RF Power Supply"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Private Sub SetRF_ForwardPower(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetRF_ForwardPower")
            PVDUtility.RF_Target_Forward_Power_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetRF_ForwardPower")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Private Sub SetRF_C1(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetRF_C1")
            PVDUtility.RF_Target_C1_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetRF_C1")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Private Sub SetRF_C2(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetRF_C2")
            PVDUtility.RF_Target_C2_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetRF_C2")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Private Sub ChangeRF_Auto(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeRF_Auto")
            PVDUtility.RF_Target_Auto(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave ChangeRF_Auto")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Private Sub ChangeRF_Presets(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeRF_Presets")
            PVDUtility.RF_Target_Presets_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave ChangeRF_Presets")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Private Sub ChangeRF_Recall(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeRF_Recall")
            PVDUtility.RF_Target_Recall(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave ChangeRF_Recall")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Private Sub ChangeRF_Store(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeRF_Store")
            PVDUtility.RF_Target_Store(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave ChangeRF_Store")
        End Sub

#End Region

#Region "DC Power Supply"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeDCPowerSupply(ByVal strCtrlName As String, ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeDCPowerSupply")
            Select Case strCtrlName
                Case "txtRampTimeRight"
                    PVDUtility.DC_RampTime_Program(Me.EquipmentName, strVal)
                Case "txtTargetPowerRight"
                    PVDUtility.DC_Target_Power_Program(Me.EquipmentName, strVal)
                Case "txtTargetVoltageRight"
                    PVDUtility.DC_Target_Voltage_Program(Me.EquipmentName, strVal)
                Case "txtTargetCurrentRight"
                    PVDUtility.DC_Target_Current_Program(Me.EquipmentName, strVal)
                Case "bicDCPulse"
                    If strVal = STR_ON Then
                        PVDUtility.DC_Target_DCPulse_Program(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                    ElseIf strVal = STR_OFF Then
                        PVDUtility.DC_Target_DCPulse_Program(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
                    End If
            End Select
            AVPLib.Log.coreLogger.Info("Leave ChangeDCPowerSupply")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetDC_Power(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetDC_Power")
            PVDUtility.DC_Target_Power_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetDC_Power")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetDC_Voltage(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetDC_Voltage")
            PVDUtility.DC_Target_Voltage_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetDC_Voltage")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetDC_Current(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetDC_Current")
            PVDUtility.DC_Target_Current_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetDC_Current")
        End Sub
#End Region

#Region "Gas Controller"
        ''CtrlName: Name of control, val: value of control
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub SetGasController(ByVal ctrlName As String, ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetGasController")
            Select Case ctrlName
                Case "txtGas1Right"
                    PVDUtility.Gas_Controller_Gas1_Program(Me.EquipmentName, Val)
                Case "txtGas2Right"
                    PVDUtility.Gas_Controller_Gas2_Program(Me.EquipmentName, Val)
                Case "txtGas3Right"
                    PVDUtility.Gas_Controller_Gas3_Program(Me.EquipmentName, Val)
                Case "txtGas4Right"
                    PVDUtility.Gas_Controller_Gas4_Program(Me.EquipmentName, Val)
                Case "txtGas5Right"
                    PVDUtility.Gas_Controller_Gas5_Program(Me.EquipmentName, Val)
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetGasController")
        End Sub
        '' val: value of control
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetGas1(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetGas1")
            PVDUtility.Gas_Controller_Gas1_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetGas1")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetGas2(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetGas2")
            PVDUtility.Gas_Controller_Gas2_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetGas2")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetGas3(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetGas3")
            PVDUtility.Gas_Controller_Gas3_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetGas3")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetGas4(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetGas4")
            PVDUtility.Gas_Controller_Gas4_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetGas4")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetGas5(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetGas5")
            PVDUtility.Gas_Controller_Gas5_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetGas5")
        End Sub
#End Region

#Region "BACenterControl"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub SetBACenterControl(ByVal CtrlName As String, ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetBACenterControl")
            Select Case CtrlName
                Case "txtCG2"
                    PVDUtility.Baratron_CG_Program(Me.EquipmentName, val)
                Case "bigcgIG"
                    If val = STR_ON Then
                        ChangeIG("Open")
                    ElseIf val = STR_OFF Then
                        ChangeIG("Close")
                    End If
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetBACenterControl")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetBaratron_CGValue(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter SetCGValue")
            PVDUtility.Baratron_CG_Program(Me.EquipmentName, val)
            AVPLib.Log.coreLogger.Info("Leave SetCGValue")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoOpenIG()
            AVPLib.Log.coreLogger.Info("Enter DoOpenIG")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, _
                       PVDCommands.BARATRON_IG_STATUS.ToString(), _
                       ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoOpenIG")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoCloseIG()
            AVPLib.Log.coreLogger.Info("Enter DoCloseIG")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, _
                       PVDCommands.BARATRON_IG_STATUS.ToString(), _
                       ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave DoCloseIG")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub ChangeIG(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeIG")
            If val = "Close" Then
                DoCloseIG()
            Else
                DoOpenIG()
            End If
            AVPLib.Log.coreLogger.Info("Leave ChangeIG")
        End Sub
#End Region

#Region "Process Recipe"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Public Sub Process_Reset_Error() Implements IRecipeProcessing.Process_Reset_Error
            AVPLib.Log.coreLogger.Info("Enter PROCESS_CONTROL_DEVICE_RESET_ERROR")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.PROCESS_CONTROL_DEVICE_RESET_ERROR.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave PROCESS_CONTROL_DEVICE_RESET_ERROR")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Public Function ResumeRecipe() As Boolean Implements IRecipeProcessing.ResumeRecipe
            AVPLib.Log.coreLogger.Info("Enter ResumeRecipe")
            Dim pvdChamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            pvdChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Running
            pvdChamber.IsPauseInProcess = False
            Return PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.PROCESS_CONTROL_DEVICE_CONTINUE.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave ResumeRecipe")
        End Function

        Public Function SendToPM_CurrentAVPTime() As Boolean Implements IRecipeProcessing.SendToPM_CurrentAVPTime
            AVPLib.Log.coreLogger.Info("Enter SendToPM_CurrentAVPTime")
            Return PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CURRENT_AVP_TIME.ToString(), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff"))
            AVPLib.Log.coreLogger.Info("Leave SendToPM_CurrentAVPTime")
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Private Sub StartRecipe(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter StartRecipe")
            Dim PathFrom As String = String.Empty
            Dim PathTo As String = String.Empty
            Dim recipeName, chamberName As String
            Try
                recipeName = val.Substring(0, val.LastIndexOf("("))
                chamberName = val.Substring(val.LastIndexOf("(") + 1)
                chamberName = chamberName.Substring(0, chamberName.LastIndexOf(")"))
                chamberName = Utils.chamberName2ChamberID(chamberName)

                PathFrom = AVPLib.ContainerDAO.FPath_ChamberRecipe + "\" + chamberName + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")
                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(chamberName)
                PathTo = serverConfig.RecipeFolder + "\" + AVPLib.Utils.GetFileName(recipeName, "xml")

                StartRecipe(PathFrom, PathTo, True)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
        End Sub

        Public Function StartSendDataRunFileName() As Boolean
            AVPLib.Log.coreLogger.Info("Enter StartSendDataRun")
            Dim obj As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Dim filenameWaferRun As String = String.Empty
            Dim waferInfo As AVPWaferInfo = obj.GetWaferInfo()
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
                        Me.ThrowAlarm("Failed to created folder for Wafer Run:" & strFolderPath)
                        Return False
                    End Try
                End If

                'GEMWaferID#2010_09_24_01_48_45           LLA_12    PM2.xml
                filenameWaferRun = Utils.GetGEMWaferID(waferInfo.WaferID) & "#" & strFolderName & "\" & _
                   DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") & ConstEnum.DataRunFileNameSeparator & LLName & "_" & _
                       waferInfo.SlotID & ConstEnum.DataRunFileNameSeparator & Utils.chamberID2ChamberName(Me.EquipmentName)
                If (Not PVDUtility.Process_Control_Run_Data_File_Name(Me.EquipmentName, filenameWaferRun)) Then
                    Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentCouldNotSendRunDatFile"), _
                                      Utils.chamberID2ChamberName(Me.EquipmentName), filenameWaferRun))
                Else
                    Return True
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave StartSendDataRun")
            Return False
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

                If bRet Then
                    PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, _
                               PVDCommands.PROCESS_CONTROL_DEVICE_RESET_ERROR.ToString(), String.Empty) ''send X,07,01,01,01,02,04
                    If (bSetRecipeNameAndStartCmd) Then
                        Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
                        If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                            Dim objPM As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
                            If (objPM IsNot Nothing) AndAlso (objPM.GetWaferInfo() IsNot Nothing) Then
                                If DoSetWaferStatus(String.Format("{0:00}", CType(objPM.GetWaferInfo().WaferStatus, Integer))) Then
                                    If SetRecipeName(pathTo) Then
                                        StartSendDataRunFileName()
                                        If Not StartProcessing() Then
                                            Me.ThrowAlarm("Failed to send START command for " + Utils.chamberID2ChamberName(EquipmentName))
                                            Return False
                                        End If
                                    Else
                                        Me.ThrowAlarm("Failed to set Recipe Name for " + Utils.chamberID2ChamberName(EquipmentName))
                                        Return False
                                    End If
                                Else
                                    Me.ThrowAlarm("Failed to set wafer status for " + Utils.chamberID2ChamberName(EquipmentName))
                                    Return False
                                End If
                            Else
                                Me.ThrowAlarm("Failed to set wafer status for " + Utils.chamberID2ChamberName(EquipmentName))
                                Return False
                            End If
                        Else
                            Me.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
                            Return False
                        End If
                    End If
                    bRet = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bRet
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
        End Function

        Public Function StopRecipe() As Boolean Implements IRecipeProcessing.StopRecipe
            AVPLib.Log.coreLogger.Info("Enter StopRecipe")
            Dim pvdChamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            pvdChamber.IsAbortInProcess = True
            Dim bResult As Boolean = PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.PROCESS_CONTROL_DEVICE_STOP.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave StopRecipe")
            Return bResult
        End Function

        Public Function AbortCurrentStep() As Boolean
            AVPLib.Log.coreLogger.Info("Enter AbortCurrentStep")
            Dim pvdChamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            Dim bResult As Boolean = PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.PROCESS_CONTROL_DEVICE_ABORT.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave AbortCurrentStep")
            Return bResult
        End Function

        Public Function PauseRecipe() As Boolean Implements IRecipeProcessing.PauseRecipe
            AVPLib.Log.coreLogger.Info("Enter PauseRecipe")
            Dim pvdChamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            pvdChamber.IsPauseInProcess = True
            Return PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.PROCESS_CONTROL_DEVICE_PAUSE.ToString(), String.Empty)
            AVPLib.Log.coreLogger.Info("Leave PauseRecipe")
        End Function

        Public Function SetRecipeName(ByVal val As String) As Boolean Implements IRecipeProcessing.SetRecipeName
            AVPLib.Log.coreLogger.Info("Enter SendToProcessRecipeValue")
            val = Utils.GetFileName(val, True) ''cut file path and ext of file
            AVPLib.Log.coreLogger.Info("Leave SendToProcessRecipeValue")
            Return PVDUtility.Process_Control_Name(Me.EquipmentName, val)
        End Function

        Public Function SetDataRunFileName(ByVal val As String) As Boolean Implements IRecipeProcessing.SetDataRunFileName
            Return PVDUtility.Process_Control_Run_Data_File_Name(Me.EquipmentName, val)
        End Function

        Public Function SetIsoValveStatus(ByVal strOnOff As String) As Boolean Implements IRecipeProcessing.SetIsoValveStatus
            Return PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, _
                                                    PVDCommands.SPLITVALVE_STATUS.ToString(), _
                                                    strOnOff, False)
        End Function

        Public Function StartProcessing() As Boolean Implements IRecipeProcessing.StartProcessing
            AVPLib.Log.coreLogger.Info("Enter StartRecipe")
            Dim bResult As Boolean = False
            Dim chamber As Chamber = EquipmentManager.GetEquipment(Me.EquipmentName)
            chamber.PreStartProcessing()
            SendToPM_CurrentAVPTime()
            If (PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.PROCESS_CONTROL_DEVICE_START.ToString(), String.Empty)) Then
                chamber.IsProcessRunning = True
                bResult = True
            End If
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2018-02-1</date>
        ''' </author>
        ''' <summary>
        '''Start Processing Cycle ATM
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Public Function StartProcessingCycleATM(ByVal val As String) As Boolean Implements IRecipeProcessing.StartProcessingCycleATM
            AVPLib.Log.coreLogger.Info("Enter StartRecipe")
            Dim bResult As Boolean = False
            ' Send Start
            If (PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.PROCESS_CYCLEATM_START.ToString(), val)) Then
                bResult = True
            End If
            AVPLib.Log.coreLogger.Info("Leave StartRecipe")
            Return bResult
        End Function
#End Region

#Region "Chamber Interlock"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoChamberInterlock(ByVal strctrlname As String, ByVal strval As String)
            AVPLib.Log.coreLogger.Info("Enter DoChamberInterlock")
            Select Case strval
                Case STR_ON
                    PVDUtility.Chamber_Interlock_PSRelay(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.Chamber_Interlock_PSRelay(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoChamberInterlock")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangePSRelay(ByVal bOpen As String)
            AVPLib.Log.coreLogger.Info("Enter ChangePSRelay")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CHAMBERINTERLOCK_PSRELAY_STATUS.ToString(), _
                  IIf(bOpen, STR_ON, STR_OFF))
            AVPLib.Log.coreLogger.Info("Enter ChangePSRelay")
        End Sub

#End Region

#Region "Menu On Machine"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoMachineShutDownPower(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoMachineShutDownPower")
            DoPowerOff()
            AVPLib.Log.coreLogger.Info("Leave DoMachineShutDownPower")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoMachineOnline(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoMachineOnline")
            Select Case val
                Case STR_ON
                    DoOnline()
                Case STR_OFF
                    DoOffline()
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoMachineOnline")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoMachinePumpDown(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoMachinePumpDown")
            Select Case val
                Case STR_ON
                    DoPumpDown()
                Case STR_OFF
                    DoStopPumpDown()
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoMachinePumpDown")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoMachineVent(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoMachineVent")
            Select Case val
                Case STR_ON
                    DoVent()
                Case STR_OFF
                    DoStopVent()
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoMachineVent")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoMachineIGDegas(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoMachineIGDegas")
            Select Case val
                Case STR_ON
                    DoIGDegas()
                Case STR_OFF
                    DoStopIGDegas()
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoMachineIGDegas")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoMachinePumpPurge(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoMachinePumpPurge")
            Select Case val
                Case STR_ON
                    DoPumpPurge()
                Case STR_OFF
                    DoStopPumpPurge()
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoMachinePumpPurge")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2011-02-18</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoMachineFastRegen(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoMachineFastRegen")
            Select Case val
                Case STR_ON
                    DoFastRegen()
                Case STR_OFF
                    DoStopFastRegen()
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoMachineFastRegen")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoTurnWaterPump(ByVal strval As String)
            AVPLib.Log.coreLogger.Info("Enter DoTurnWaterPump")
            If strval = STR_ON Then
                DoTurnWaterPumpOn()
            Else
                DoTurnWaterPumpOff()
            End If
            AVPLib.Log.coreLogger.Info("Enter DoTurnWaterPump")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoMachineCryoOn(ByVal strval As String)
            AVPLib.Log.coreLogger.Info("Enter DoTurnCryo")
            If strval = STR_ON Then
                DoCryoOn()
            Else
                DoCryoOff()
            End If
            AVPLib.Log.coreLogger.Info("Enter DoTurnCryo")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoTurnWaterPump_Regen(ByVal strval As String)
            AVPLib.Log.coreLogger.Info("Enter DoTurnCryo")
            If strval = STR_ON Then
                DoTurnWaterPump_RegenOn()
            Else
                DoTurnWaterPump_RegenOff()
            End If
            AVPLib.Log.coreLogger.Info("Enter DoTurnCryo")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoMachineCryoRegen(ByVal strval As String)
            AVPLib.Log.coreLogger.Info("Enter DoTurnCryo")
            If strval = STR_ON Then
                DoCryoRegenOn()
            Else
                DoCryoRegenOff()
            End If
            AVPLib.Log.coreLogger.Info("Enter DoTurnCryo")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-07</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub MakeRoughLineInUseManual(ByVal state As Object)
            AVPLib.Log.coreLogger.Info("Enter MakeRoughLineInUseManual")
            Try
                Dim objRoughPump As DataManagerment.RoughPumpMachine = _
                            CType(DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName), DataManagerment.RoughPumpMachine)

                If (objRoughPump Is Nothing) Then
                    AVPLib.Log.coreLogger.Error("Rough Pump Do not settup")
                Else
                    'IF HAVE ANY ROUGH VALVE OPENED 
                    'SHOW MESSAGE BOX NOT ACCEPT OPEN VALVE
                    'SEND OFF TO PVD
                    'IF CONDITION OPEN VALVE OK, MAKE ROUGH LINE IN USED
                    'SEND REQUEST OPEN TO PVD
                    If (Not objRoughPump.CheckOpenValveCondition(Me.EquipmentName)) Then
                        Dim strErrMsg As String = ConstEnum.STR_ROUGH_PUMP_IN_USE & objRoughPump.GetEquipmentIsUsing()
                        Me.ThrowAlarm(strErrMsg)
                        'Send Status to PVD
                        PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, _
                        PVDCommands.ROUGH_LINE_IN_USE_QUERY.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
                    ElseIf (objRoughPump.MakeRoughLineInUseNoWait(Me.EquipmentName)) Then
                        'Send Status to PVD
                        PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, _
                        PVDCommands.ROUGH_LINE_IN_USE_QUERY.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            AVPLib.Log.coreLogger.Info("Leave MakeRoughLineInUseHelper")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-07</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SequenceMakeRoughLineInUse(ByVal state As Object)
            AVPLib.Log.coreLogger.Info("Enter SequenceMakeRoughLineInUse")
            Try
                Dim objRoughPump As DataManagerment.RoughPumpMachine = _
                            CType(DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName), DataManagerment.RoughPumpMachine)

                If (objRoughPump Is Nothing) Then
                    AVPLib.Log.coreLogger.Error("Rough Pump Do not settup")
                Else

                    If (objRoughPump.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) & MECHANICAL_PUMP_CG_DISCONNECTED)
                        Exit Try
                    End If

                    If (objRoughPump.MakeRoughLineInUse(Me.EquipmentName, _
                            ExpectedMechanicalPumpPressureWhenPumpDown, _
                            m_EventPumpDownAborted)) Then
                        AVPLib.Log.coreLogger.Debug("Rough Line now is used by " & Utils.chamberID2ChamberName(Me.EquipmentName))
                        ' Send a warning event here, make user noticeable.
                        ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeWarning, Utils.chamberID2ChamberName(Me.EquipmentName), "Rough Line now is used by " & Utils.chamberID2ChamberName(Me.EquipmentName))

                        If Not PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.ROUGH_LINE_IN_USE_QUERY.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN) Then
                            Me.ThrowAlarm("Failed to notify , " + Utils.chamberID2ChamberName(EquipmentName) & " that it's now using the rough pump line.")
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            AVPLib.Log.coreLogger.Info("Leave SequenceMakeRoughLineInUse")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-07</date>
        ''' </author>
        ''' <summary>
        ''' Release Rough Pump by Manual
        ''' Release All Rough Line
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ReleaseRoughLineInUse(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoRoughLineInUse")
            If (STR_OFF = val) Then
                Dim objRoughPump As DataManagerment.RoughPumpMachine = _
                CType(DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName), DataManagerment.RoughPumpMachine)
                If objRoughPump IsNot Nothing AndAlso objRoughPump.ReleaseRoughLineInUse() Then
                    Me.ThrowAlarm("Release Rough Pump Failed.")
                Else
                    Me.ThrowAlarm("Release Rough Pump Successfull.")
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave DoRoughLineInUse")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-07</date>
        ''' </author>
        ''' <summary>
        ''' Make Request Rough Line
        ''' Manual by GUI Action
        ''' or Call by Sequence from PVD
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub MakeRoughLineInUse(ByVal IsManual As Boolean)
            If (IsManual) Then
                ThreadPool.QueueUserWorkItem(AddressOf MakeRoughLineInUseManual, Nothing)
            Else
                ThreadPool.QueueUserWorkItem(AddressOf SequenceMakeRoughLineInUse, Nothing)
            End If
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-07</date>
        ''' </author>
        ''' <summary>
        ''' Release All Rough line and Rough Pump
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ReleaseRoughLineInUse() As Boolean
            Dim objRoughPump As DataManagerment.RoughPumpMachine = _
            CType(DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName), DataManagerment.RoughPumpMachine)
            If objRoughPump.ReleaseRoughLineInUse(Me.EquipmentName) Then
                Return True
            Else
                Return False
            End If
        End Function
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
            AVPLib.Log.coreLogger.Info("Enter DoRateOfRise")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If PVDUtility.Start_Rate_Of_Rise(Me.EquipmentName, _
                                                                       PDC_ROR_SampleTime.ToString(), PDC_ROR_WaitTime.ToString(), PDC_ROR_Description) Then
                    m_EventPumpDownAborted.Reset()
                Else
                    Me.ThrowAlarm("Failed to start Rate Of Rise for " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoRateOfRise")
        End Sub

        Private Sub DoStopRateOfRise()
            AVPLib.Log.coreLogger.Info("Enter DoStopRateOfRise")
            If Not PVDUtility.Stop_Rate_Of_Rise(Me.EquipmentName) Then
                Me.ThrowAlarm("Failed to set stop Rate of Rise for " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoStopRateOfRise")
        End Sub

        Private Sub DoPumpdownCurve()
            AVPLib.Log.coreLogger.Info("Enter DoPumpdownCurve")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If PVDUtility.Start_PumpDown_Curve(Me.EquipmentName, _
                                                                       PDC_ROR_SampleTime.ToString(), PDC_ROR_WaitTime.ToString(), PDC_ROR_Description) Then
                    m_EventPumpDownAborted.Reset()
                Else
                    Me.ThrowAlarm("Failed to start Pump Down Curve for " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoPumpdownCurve")
        End Sub

        Private Sub DoStopPumpdownCurve()
            AVPLib.Log.coreLogger.Info("Enter DoStopPumpdownCurve")
            If PVDUtility.Stop_PumpDown_Curve(Me.EquipmentName) Then
                m_EventPumpDownAborted.Set()
            Else
                Me.ThrowAlarm("Failed to set stop Pump Down Curve for " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoStopPumpdownCurve")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoPumpDown()
            AVPLib.Log.coreLogger.Info("Enter DoPumpDown")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If (PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_PUMPDOWN.ToString(), _
                                                  ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                    m_EventPumpDownAborted.Reset()
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoPumpDown")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoStopPumpDown()
            AVPLib.Log.coreLogger.Info("Enter DoStopPumpDown")
            If (PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_PUMPDOWN.ToString(), _
                                                    ConfigurationValues.DEVICE_STATUS_CLOSED)) Then
                m_EventPumpDownAborted.Set()
            End If
            AVPLib.Log.coreLogger.Info("Leave DoStopPumpDown")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoVent()
            AVPLib.Log.coreLogger.Info("Enter DoVent")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_VENT.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                Me.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoVent")
        End Sub

        Private Sub DoIGDegas()
            AVPLib.Log.coreLogger.Info("Enter DoIGDegas")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_IGDEGAS.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            Else
                Me.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoIGDegas")
        End Sub

        Private Sub DoStopIGDegas()
            AVPLib.Log.coreLogger.Info("Enter DoStopIGDegas")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_IGDEGAS.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave DoStopIGDegas")
        End Sub

        Private Sub DoPumpPurge()
            AVPLib.Log.coreLogger.Info("Enter DoPumpPurge")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_PUMPPURGE.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN) Then
                    m_EventPumpDownAborted.Reset()
                Else
                    Me.ThrowAlarm("Failed to start Pump Purge for " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoPumpPurge")
        End Sub

        Private Sub DoStopPumpPurge()
            AVPLib.Log.coreLogger.Info("Enter DoStopPumpPurge")
            If Not PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_PUMPPURGE.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED) Then
                Me.ThrowAlarm("Failed to stop Pump Purge for " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoStopPumpPurge")
        End Sub

        Private Sub DoFastRegen()
            AVPLib.Log.coreLogger.Info("Enter DoFastRegen")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            If SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                'CMD Fast Regen is the same Cryo Regen, but value send to IBE is 02
                If PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CRYO_REGEN.ToString(), ConfigurationValues.DEVICE_STATUS_STOPPED) Then
                    m_EventPumpDownAborted.Reset()
                Else
                    Me.ThrowAlarm("Failed to start Fast Regen for " + Utils.chamberID2ChamberName(EquipmentName))
                End If
            Else
                Me.ThrowAlarm("Failed to set Slit valve Status for, " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoFastRegen")
        End Sub

        Private Sub DoStopFastRegen()
            AVPLib.Log.coreLogger.Info("Enter DoStopFastRegen")
            If Not PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_FAST_REGEN.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED) Then
                Me.ThrowAlarm("Failed to stop Fast Regen for " + Utils.chamberID2ChamberName(EquipmentName))
            End If
            AVPLib.Log.coreLogger.Info("Leave DoStopFastRegen")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoStopVent()
            AVPLib.Log.coreLogger.Info("Enter DoStopVent")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_VENT.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave DoStopVent")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoCryoOff()
            AVPLib.Log.coreLogger.Info("Enter DoCryoOff")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_CRYO_ON.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave DoCryoOff")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoCryoOn()
            AVPLib.Log.coreLogger.Info("Enter DoCryoOn")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_CRYO_ON.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoCryoOn")
        End Sub

        Private Sub SetCryo_Extended_PurgeTime(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Extended_PurgeTime")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_EXTENDED_PURGE_TIME & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Extended_PurgeTime")
        End Sub
        Private Sub SetCryo_Pump_Restart_Delay(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Pump_Restart_Delay")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_PUMP_RESTART_DELAY & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Pump_Restart_Delay")
        End Sub
        Private Sub SetCryo_Rate_Of_Rise(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Rate_Of_Rise")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_RATE_OF_RISE & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Rate_Of_Rise")
        End Sub
        Private Sub SetCryo_Repurge_Cycles(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Repurge_Cycles")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_REPURGE_CYCLES & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Repurge_Cycles")
        End Sub
        Private Sub SetCryo_Rough_To_Pressure(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Rough_To_Pressure")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_ROUGH_TO_PRESSURE & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Rough_To_Pressure")
        End Sub
        Private Sub SetCryo_Start_Up_Time(ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter SetCryo_Start_Up_Time")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CRYO_P_COMMANDS.ToString(), ConstEnum.REGEN_PARAM_ID_START_UP_TEMPERATURE & value)
            AVPLib.Log.coreLogger.Info("Leave SetCryo_Start_Up_Time")
        End Sub

        Private Sub ClearAllAlarm(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter ClearAllAlarm")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CLEAR_ALL_ALARM_PROGRAM.ToString(), 1)
            AVPLib.Log.coreLogger.Info("Leave ClearAllAlarm")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoTurnWaterPumpOff()
            AVPLib.Log.coreLogger.Info("Enter DoWaterPumpOff")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.WATER_PUMP_STATE_STATUS.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave DoWaterPumpOff")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoTurnWaterPumpOn()
            AVPLib.Log.coreLogger.Info("Enter DoWaterPumpOn")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.WATER_PUMP_STATE_STATUS.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoWaterPumpOn")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoTurnWaterPump_RegenOn()
            AVPLib.Log.coreLogger.Info("Enter DoTurnWaterPump_RegenOn")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.WATER_PUMP_REGEN_STATUS.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoTurnWaterPump_RegenOn")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoTurnWaterPump_RegenOff()
            AVPLib.Log.coreLogger.Info("Enter DoTurnWaterPump_RegenOff")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.WATER_PUMP_REGEN_STATUS.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave DoTurnWaterPump_RegenOff")
        End Sub

        Private Sub DoOnline_Offline(ByVal strVal As String)
            AVPLib.Log.coreLogger.Info("Enter DoOnline_Offline")
            If strVal.Contains("#") Then
                'STR_ON & "#" & blnThrowAlarm.ToString()
                Dim arrVal As Array = strVal.Split("#")
                strVal = arrVal(0)
                Boolean.TryParse(arrVal(1), m_blnThrowAlarm_When_Online)
            End If
            Select Case strVal
                Case STR_ON
                    DoOnline()
                Case STR_OFF
                    DoOffline()
            End Select
            AVPLib.Log.coreLogger.Info("Enter DoOnline_Offline")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoOffline()
            AVPLib.Log.coreLogger.Info("Enter DoOffline")
            m_EventStopThread.Set()
            Me.RaiseFinishOnline(False)
            AVPLib.Log.coreLogger.Info("Leave DoOffline")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoOnline()
            AVPLib.Log.coreLogger.Info("Enter DoOnline")
            Try
                trdToolOnline = New Thread(AddressOf OnlineProc)
                m_EventStopThread.Reset()
                trdToolOnline.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoOnline")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoPowerOff()
            AVPLib.Log.coreLogger.Info("Enter DoPowerOff")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MACHINE_SHUTDOWN_POWER.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave DoPowerOff")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoCryoRegenOn()
            AVPLib.Log.coreLogger.Info("Enter DoCryoRegenOn")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CRYO_REGEN.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            AVPLib.Log.coreLogger.Info("Leave DoCryoRegenOn")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoCryoRegenOff()
            AVPLib.Log.coreLogger.Info("Enter DoCryoRegenOff")
            PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.CRYO_REGEN.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave DoCryoRegenOff")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoCryoRegen(ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter DoCryoRegen")
            Select Case Val
                Case STR_ON
                    DoCryoRegenOn()
                Case STR_OFF
                    DoCryoRegenOff()
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoCryoRegen")
        End Sub
#End Region

#Region "Function Support"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Send command to IBE to set the wafer status
        ''' </summary>
        ''' data: = On,Off
        ''' <remarks></remarks>
        Public Function DoSetWaferStatus(ByVal strStatus As String) As Boolean Implements IRecipeProcessing.DoSetWaferStatus
            AVPLib.Log.coreLogger.Info("Enter DoSetWaferStatus")
            Return PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.WAFER_STATUS.ToString(), strStatus)
            AVPLib.Log.coreLogger.Info("Leave DoSetWaferStatus")
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoWaterPump(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoWaterPump")
            Select Case val
                Case STR_ON
                    PVDUtility.Water_Pump_Status(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.Water_Pump_Status(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoWaterPump")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoTurboPump(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoTurboPump")
            Select Case val
                Case STR_ON
                    PVDUtility.Turbo_Pump_Status(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.Turbo_Pump_Status(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoTurboPump")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoRotationStart(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoRotationStart")
            Select Case val
                Case STR_ON
                    PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MAGNATRON_ROTATION_START.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.MAGNATRON_ROTATION_START.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoRotationStart")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoZeroVatValve(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoZeroVatValve")
            Select Case val
                Case STR_ON
                    PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.AUTO_ZERO_VAT_VALVE_STATUS.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.AUTO_ZERO_VAT_VALVE_STATUS.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoZeroVatValve")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoHivacValve(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoCryoRegen")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN))
            Select Case val
                Case STR_ON
                    PVDUtility.Hivac_Valve(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.Hivac_Valve(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoCryoRegen")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeVatValveController(ByVal CtrlName As String, ByVal strval As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeVatValveController")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(Me.EquipmentName)
            Select Case CtrlName
                Case "txtPressure"
                    SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN))
                    PVDUtility.Vat_Valve_Controller_Pressure(Me.EquipmentName, strval)
                Case "txtPressure_Percent"
                    SetIsoValveStatus(IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, ConfigurationValues.DEVICE_STATUS_OPEN))
                    PVDUtility.Vat_Valve_Controller_Pressure_Percent(Me.EquipmentName, strval)
            End Select
            AVPLib.Log.coreLogger.Info("Leave ChangeVatValveController")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeChuckPos(ByVal CtrlName As String, ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeChuckPos")
            Select Case CtrlName
                Case "txtPos1"
                    PVDUtility.Chuck_Pos1(Me.EquipmentName, value)
                Case "txtPos2"
                    PVDUtility.Chuck_Pos2(Me.EquipmentName, value)
            End Select
            AVPLib.Log.coreLogger.Info("Leave ChangeChuckPos")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub ChangeParallelMagnet(ByVal strCtrlname As String, ByVal strval As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeParallelMagnet")
            Select Case strCtrlname
                Case "txtCurrentRight"
                    PVDUtility.Parallel_Current_Program(Me.EquipmentName, strval)
                Case "txtDutyRight"
                    PVDUtility.Parallel_Duty_Program(Me.EquipmentName, strval)
                Case "txtFrequencyRight"
                    PVDUtility.Parallel_Frequency_Program(Me.EquipmentName, strval)
                Case "btnStatus"
                    If strval = STR_ON Then
                        PVDUtility.Parallel_Status_Program(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                    ElseIf strval = STR_OFF Then
                        PVDUtility.Parallel_Status_Program(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
                    End If
            End Select
            AVPLib.Log.coreLogger.Info("Enter ChangeParallelMagnet")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoPlasmaIgniter(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoPlasmaIgniter")
            Select Case val
                Case STR_ON
                    PVDUtility.Plasma_Igniter_Valve(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.Plasma_Igniter_Valve(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoPlasmaIgniter")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoShutter(ByVal val As String)
            AVPLib.Log.coreLogger.Info("Enter DoShutter")
            Select Case val
                Case STR_ON
                    PVDUtility.Shutter_Valve(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.Shutter_Valve(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoShutter")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub SetProcessRecipe(ByVal ctrlname As String, ByVal Val As String)
            AVPLib.Log.coreLogger.Info("Enter SetProcessRecipe")
            Select Case ctrlname
                Case "Resume"
                    ResumeRecipe()
                Case "Pause" 'button
                    PauseRecipe()
                Case "Stop" 'button
                    StopRecipe()
                Case "Abort"
                    AbortCurrentStep()
                Case Else 'button
                    Me.StartRecipe(Val)
            End Select
            AVPLib.Log.coreLogger.Info("Leave SetProcessRecipe")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoTeach_VatValveController()
            AVPLib.Log.coreLogger.Info("Enter DoTeach_VatValveController")
            PVDUtility.Vat_Valve_Controller_Teach(Me.EquipmentName, ConfigurationValues.DEVICE_TEACH_VALUE)
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-16</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub DoSizeAdjust_VatValveController(ByVal data As String)
            AVPLib.Log.coreLogger.Info("Enter DoSizeAdjust_VatValveController")
            Select Case data
                Case STR_ON
                    PVDUtility.Vat_Valve_Controller_SizeAdjust(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    PVDUtility.Vat_Valve_Controller_SizeAdjust(Me.EquipmentName, ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
            AVPLib.Log.coreLogger.Info("Enter DoSizeAdjust_VatValveController")
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

                    Case SET_ATM_ROUGHLINE_CG
                        DoSetATMRoughlineCG()
                    Case SET_VAC_ROUGHLINE_CG
                        DoSetVACRoughlineCG()

                    Case SET_ATM_PRESSURE_CG
                        DoSetATMPressureCG()
                    Case SET_VAC_PRESSURE_CG
                        DoSetVACPressureCG()
                    Case "SendRequestAllData"
                        SendRequestAllData()
                    Case "btnOverrideMode"
                        DoOverrideMode(strVal)
                    Case "btnClamp"
                        DoClamp_UnClamp(strVal)
                    Case "btnStart", "btnPause", "btnAbort"  'Process Recipe
                        SetProcessRecipe(strCtrlName, strVal)
                    Case "btnReConnect"
                        DoReConnect(Me.EquipmentName)
                        ''<------Pop Up Menu------>
                    Case "btnOnline", "btnOffline"
                        DoOnline_Offline(strVal)
                    Case "btnAutoPumpDown"
                        DoMachinePumpDown(strVal)
                    Case "btnAutoVent"
                        DoMachineVent(strVal)
                    Case "btnIGDegas"
                        DoMachineIGDegas(strVal)
                    Case "btnCryoOn", "btnCryoOff"
                        DoMachineCryoOn(strVal)
                    Case "btnAutoRegenOn", "btnAutoRegenOff"
                        DoMachineCryoRegen(strVal)
                    Case "btnShutDownPower"
                        DoMachineShutDownPower(strVal)
                    Case "btnFastRegen"
                        DoMachineFastRegen(strVal)
                    Case "btnWaterPumpOn", "btnWaterPumpOff", "btnWaterPumpOnOff"
                        DoTurnWaterPump(strVal)
                    Case "btnPumpPurge"
                        DoMachinePumpPurge(strVal)
                    Case "btnWPRegenOn", "btnWPRegenOff"
                        DoTurnWaterPump_Regen(strVal)
                        ''<----Pop Up Menu----->
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

                        ''''''''''''''''''''''''''''''''''''''''''
                    Case "ValveBaratron", "ValveVent", "ValveTurbo_Isolation", "ValveRough", "ValveWater", _
                          "ValveShutOff1", "ValveShutOff2", "ValveShutOff3", "ValveShutOff4", "ValveShutOff5", _
                          "ValveSupply5", "ValveSupply4", "ValveSupply3", "ValveSupply2", "ValveSupply1", "ValveMainGas"
                        ChangeValve(strCtrlName, strVal)
                    Case "Start", "Stop", "Resume", "Pause", "Abort" 'Process Recipe
                        SetProcessRecipe(strCtrlName, strVal)
                        '<Bias Power Supply & RF Power Supply>
                    Case "txtForwardPowerRight", "txtC1Right", "txtC2Right", "txtPresetsRight", "txtVoltageRight"
                        ChangeBias_RFPowerSupply(strPnlName, strCtrlName, strVal)

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

                    Case "btnAuto", "btnRecall", "btnStore"
                        DoBias_RFPowerSupply(strPnlName, strCtrlName, strVal)
                        '<DC Power Supply>
                    Case "txtTargetPowerRight", "txtTargetVoltageRight", "txtTargetCurrentRight", "bicDCPulse", "txtRampTimeRight"
                        ChangeDCPowerSupply(strCtrlName, strVal)
                        '<Gas Controller>
                    Case "txtGas1Right", "txtGas2Right", "txtGas3Right", "txtGas4Right", "txtGas5Right"
                        SetGasController(strCtrlName, strVal)
                        '<Parallel Magnet>
                    Case "txtCurrentRight", "txtDutyRight", "txtFrequencyRight", "btnStatus"
                        ChangeParallelMagnet(strCtrlName, strVal)
                        '<Chamber Interlock>
                    Case "btnPSRelay"
                        DoChamberInterlock(strCtrlName, strVal)
                        '<Baratron>
                    Case "txtCG2", "bigcgIG"
                        SetBACenterControl(strCtrlName, strVal)
                        '<Chuck Pos>
                    Case "txtPos1", "txtPos2"
                        ChangeChuckPos(strCtrlName, strVal)
                    Case "btnHivacValve"
                        DoHivacValve(strVal)
                    Case "btnShutter"
                        DoShutter(strVal)
                    Case "bicPlasmaIgniter"
                        DoPlasmaIgniter(strVal)
                        'Vat Valve Controller
                    Case "txtPressure", "txtPressure_Percent"
                        ChangeVatValveController(strCtrlName, strVal)
                        'Cryo Control
                    Case "btnRegen"
                        DoCryoRegen(strVal)
                    Case "bicWaterPump"
                        DoWaterPump(strVal)
                    Case "bicTurboPump"
                        DoTurboPump(strVal)
                    Case "btnRotationStart"
                        DoRotationStart(strVal)
                    Case "btnAutoZero"
                        DoZeroVatValve(strVal)
                    Case "btnTeach"
                        DoTeach_VatValveController()
                    Case "btnSizeAdjust"
                        DoSizeAdjust_VatValveController(strVal)
                    Case "ReleaseRoughLineInUse"
                        ReleaseRoughLineInUse(strVal)
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

#End Region
        Public Sub SendRequestAllData() Implements IRecipeProcessing.SendRequestAllData
            AVPLib.Log.coreLogger.Info("Enter SendCommandToPM")
            If RobotConfigurationValues.SUPPORT_PVD_UPDATE_WHEN_DATA_CHANGED Then
                PVDUtility.SendCommandWithDataToPVD(Me.EquipmentName, PVDCommands.REQUEST_ALL_DATA.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
            End If
            AVPLib.Log.coreLogger.Info("Enter SendCommandToPM")
        End Sub
        ''<name> Dy Do </name>
        ''<date> 2016-02-24</date>
        ''</author>
        ''<summary>
        ''</summary>
        Public Sub SendResultOfCopyRecipeTemplate(ByVal blnResult As Boolean) Implements IRecipeProcessing.SendResultOfCopyRecipeTemplate
            '''To Do Later
        End Sub

#Region "Online Sequence"
       
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
                Dim PVDMaintenance As PVDChamber = EquipmentManager.GetEquipment(Me.EquipmentName)
                'If PVD.  If process is running or pausing.  Check all interlock only.
                'Is All Interlock made?
                If m_EventStopThread.WaitOne(0, True) Then
                    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                    Return False
                End If
                'is All interlock Made?
                Dim chambermodule As AVPLib.SystemModule = Nothing
                AVPLib.ContainerData.IsChamberVisible(Me.EquipmentName, chambermodule)
                If chambermodule.ChamberInterlock_LidSensorVisible Then
                    If Not (PVDMaintenance.ChamberInterlocks_LidSensorStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentAllInterlocksAreNotMade"), _
                                                    Utils.chamberID2ChamberName(Me.EquipmentName), "(Chamber Lid)"))
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If
                If chambermodule.ChamberInterlock_LidWaterVisible Then
                    If Not (PVDMaintenance.ChamberInterlocks_LidWaterStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentAllInterlocksAreNotMade"), _
                                                                            Utils.chamberID2ChamberName(Me.EquipmentName), "(Lid Water)"))
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If
                If chambermodule.ChamberInterlock_TargetWaterVisible Then
                    If Not (PVDMaintenance.ChamberInterlocks_TargetWaterStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentAllInterlocksAreNotMade"), _
                                                    Utils.chamberID2ChamberName(Me.EquipmentName), "(Target Water)"))
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If
                If chambermodule.ChamberInterlock_TurboForelineVisible Then
                    If Not (PVDMaintenance.ChamberInterlocks_TurboForelineStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentAllInterlocksAreNotMade"), _
                                                    Utils.chamberID2ChamberName(Me.EquipmentName), "(Turbo Foreline)"))
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If
                If chambermodule.ChamberInterlock_TurboWaterVisible Then
                    If Not (PVDMaintenance.ChamberInterlocks_TurboWaterStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentAllInterlocksAreNotMade"), _
                                                    Utils.chamberID2ChamberName(Me.EquipmentName), "(Turbo Water)"))
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If
                'new interlocks
                If chambermodule.ChamberInterlock_TargetMBWaterVisible Then
                    If Not (PVDMaintenance.ChamberInterlocks_TargetMBWaterStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentAllInterlocksAreNotMade"), _
                                                    Utils.chamberID2ChamberName(Me.EquipmentName), "(Target MB Water)"))
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If
                If chambermodule.ChamberInterlock_ClampWaterVisible Then
                    If Not (PVDMaintenance.ChamberInterlocks_ClampWaterStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentAllInterlocksAreNotMade"), _
                                                    Utils.chamberID2ChamberName(Me.EquipmentName), "(Clamp Water)"))
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If
                If chambermodule.ChamberInterlock_SubMBWaterVisible Then
                    If Not (PVDMaintenance.ChamberInterlocks_SubMBWaterStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentAllInterlocksAreNotMade"), _
                                                    Utils.chamberID2ChamberName(Me.EquipmentName), "(Sub MB Water)"))
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If
                ''basic interlock check
                If Not ((PVDMaintenance.ChamberInterlocks_ChamPressStatus = Equipment.WorkingStatuses.On) _
                         And (PVDMaintenance.ChamberInterlocks_ChamWaterStatus = Equipment.WorkingStatuses.On) _
                         And (PVDMaintenance.ChamberInterlocks_ChuckWaterStatus = Equipment.WorkingStatuses.On) _
                         And (PVDMaintenance.ChamberInterlocks_PSRelayStatus = Equipment.WorkingStatuses.On)) Then
                    If m_blnThrowAlarm_When_Online Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentAllInterlocksAreNotMade"), _
                                                    Utils.chamberID2ChamberName(Me.EquipmentName), "(Basic Check)"))
                    End If
                    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                    Return False
                End If

                'If PVD.  If no process is running or pausing, check all interlock, VAT open and IG on.
                If Not (PVDMaintenance.IsPauseInProcess Or PVDMaintenance.IsProcessRunning) Then
                    If Not (PVDMaintenance.HivacValveStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": VAT valve is not opened" & GO_ONLINE_FAILED)
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                    If Not (PVDMaintenance.IGStatus = Equipment.WorkingStatuses.On) Then
                        If m_blnThrowAlarm_When_Online Then
                            Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) + ": IG is not On" & GO_ONLINE_FAILED)
                        End If
                        AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                        Return False
                    End If
                End If

                ' Done.
                AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                Return True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckOnline")
            Return False
        End Function
#End Region
        Public Sub DoCheckRecipeTemplateVersion() Implements IRecipeProcessing.DoCheckRecipeTemplateVersion
            ''Implement in Chamber
        End Sub
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
                Dim objPVDChamber As PVDChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objConfigChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                Dim currentShieldsQuartz As Double = 0

                If objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.PVD AndAlso _
                                (objConfigChamber.RFTargetPowerVisible OrElse objConfigChamber.DCTargetPowerVisible OrElse objConfigChamber.BiasPowerVisible) Then
                    currentShieldsQuartz = objPVDChamber.Shields_Quart_KWH

                    If objPVDChamber.IsUseMaxLimit Then
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
                Dim objPVDChamber As PVDChamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objConfigChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.EquipmentName)
                Dim objPm As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim currentShieldsQuartz As Double = 0

                If objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.PVD AndAlso _
                                    (objConfigChamber.RFTargetPowerVisible OrElse objConfigChamber.DCTargetPowerVisible OrElse objConfigChamber.BiasPowerVisible) Then
                    currentShieldsQuartz = objPVDChamber.Shields_Quart_KWH

                    If (objPm IsNot Nothing) AndAlso objPm.IsUseMaxLimit Then
                        Dim dblWarningKWH As Double = Math.Abs(objConfigChamber.ShieldsQuartzWarning - objConfigChamber.Max_KWH_ShieldsQuartz)
                        If currentShieldsQuartz >= dblWarningKWH Then
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

        Public Function CheckingKWHOverAlarmLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingKWHOverAlarmLimit
            Return True
        End Function

        Public Function CheckingKWHOverWarningLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingKWHOverWarningLimit
            Return True
        End Function

        Public Overridable Function SendProcessLotID() As Boolean Implements IRecipeProcessing.SendProcessLotID
            Return True
        End Function

        Public Overridable Function SendProcessWaferID() As Boolean Implements IRecipeProcessing.SendProcessWaferID
            Return True
        End Function

        Public Function StartWarmUp() As Boolean Implements IRecipeProcessing.StartWarmUp
            Return True
        End Function
    End Class
End Namespace

