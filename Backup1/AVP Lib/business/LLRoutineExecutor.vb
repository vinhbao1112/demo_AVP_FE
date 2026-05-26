Imports AVPLib.DataManagerment
Imports AVPLib.ConstEnum
Imports System.IO
Imports System.Xml

Namespace Business
    Public Class LLRoutineExecutor
        Inherits SuspendableThread

        Protected m_eActiveRoutine As RoutineType
        Protected m_strCurrentEQName As String
        Protected m_LLController As LoadLockController = Nothing
        Protected m_objLoadlock As LoadLock = Nothing
        Private m_iSampleTime As Int32 = 1 ' default interval : 1 second.
        Private m_iWaitTime As Int32 = 1  ' default recording time : 1 minute.
        Private m_strDescription As String = String.Empty

        Private m_lpdcStartTickCount As Long = Environment.TickCount
        Protected m_pdcTimer As System.Timers.Timer = Nothing
        Private m_HasRunTMPumpdown As Boolean = False
        Private m_HasRunLLPumpdown As Boolean = False
        Private m_pdcSampleCount As Integer = 0
        ' Event will be fired once 1 sample is collected
        Public Event OnDataCollect As DataCollectEvent

        Public Sub RaiseDataSample(ByVal Type As RoutineType, ByVal RemainingTimeSecsNo As Integer, ByVal SecsNo As Integer, ByVal Value As Double)
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrValues As New ArrayList()

                If Type = RoutineType.RateOfRise Then
                    arrPropertyNames.Add("RateOfRise_Sample")
                    arrValues.Add("RemainingTime=" & RemainingTimeSecsNo.ToString() & "#Time=" & SecsNo.ToString() & "#IG=" & Value.ToString() & "#") ''"Time=1#IG=1.000E-005#"
                ElseIf Type = RoutineType.PumpdownCurve Then
                    arrPropertyNames.Add("PumpDown_Curve_Sample")
                    arrValues.Add("RemainingTime=" & RemainingTimeSecsNo.ToString() & "#Time=" & SecsNo.ToString() & "#IG=" & Value.ToString() & "#") ''"Time=1#IG=1.000E-005#"
                ElseIf Type = RoutineType.RecoverPressure Then
                    arrPropertyNames.Add("Recover_Pressure_Sample")
                    arrValues.Add("RemainingTime=" & RemainingTimeSecsNo.ToString() & "#Time=" & SecsNo.ToString() & "#Pressure=" & Value.ToString() & "#") ''"Time=1#IG=1.000E-005#"
                End If
                EquipmentManager.ChangeStatus(m_strCurrentEQName, arrPropertyNames, arrValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        Public Sub RaiseCGDataSample(ByVal Type As RoutineType, ByVal RemainingTimeSecsNo As Integer, ByVal SecsNo As Integer, ByVal Value As Double)
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrValues As New ArrayList()

                If Type = RoutineType.RateOfRise Then
                    arrPropertyNames.Add("RateOfRise_Sample")
                    arrValues.Add("RemainingTime=" & RemainingTimeSecsNo.ToString() & "#Time=" & SecsNo.ToString() & "#CG=" & Value.ToString() & "#") ''"Time=1#IG=1.000E-005#"
                ElseIf Type = RoutineType.PumpdownCurve Then
                    arrPropertyNames.Add("PumpDown_Curve_Sample")
                    arrValues.Add("RemainingTime=" & RemainingTimeSecsNo.ToString() & "#Time=" & SecsNo.ToString() & "#CG=" & Value.ToString() & "#") ''"Time=1#IG=1.000E-005#"
                ElseIf Type = RoutineType.RecoverPressure Then
                    arrPropertyNames.Add("Recover_Pressure_Sample")
                    arrValues.Add("RemainingTime=" & RemainingTimeSecsNo.ToString() & "#Time=" & SecsNo.ToString() & "#Pressure=" & Value.ToString() & "#") ''"Time=1#IG=1.000E-005#"
                End If
                EquipmentManager.ChangeStatus(m_strCurrentEQName, arrPropertyNames, arrValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        Public Sub RaiseOnOffEvent(ByVal Type As RoutineType, ByVal OnOffEvent As Equipment.WorkingStatuses)
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrValues As New ArrayList()

                If Type = RoutineType.RateOfRise Then
                    arrPropertyNames.Add("RateOfRise_Status")
                ElseIf Type = RoutineType.PumpdownCurve Then
                    arrPropertyNames.Add("PumpDown_Curve_Status")
                ElseIf Type = RoutineType.IGDegas Then
                    arrPropertyNames.Add("IG_Degas_Status")
                ElseIf Type = RoutineType.RecoverPressure Then
                    arrPropertyNames.Add("Recover_Pressure_Status")
                End If
                arrValues.Add(OnOffEvent)
                EquipmentManager.ChangeStatus(m_strCurrentEQName, arrPropertyNames, arrValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Private Sub CreateFileName(ByVal type As RoutineType)
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrValues As New ArrayList()
                Dim dtPDC As DateTime = DateTime.Now
                Dim strPDCXmlFile As String = dtPDC.ToString("yy-MM-dd_HH_mm_ss") & ".xml"
                If type = RoutineType.RateOfRise Then
                    arrPropertyNames.Add("RateOfRise_FileName")
                ElseIf type = RoutineType.PumpdownCurve Then
                    arrPropertyNames.Add("PumpDown_Curve_FileName")
                ElseIf type = RoutineType.RecoverPressure Then
                    arrPropertyNames.Add("Recover_Pressure_FileName")
                End If
                arrValues.Add(strPDCXmlFile)
                EquipmentManager.ChangeStatus(m_strCurrentEQName, arrPropertyNames, arrValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Public Property SampleTime() As Integer
            Get
                Return m_iSampleTime
            End Get
            Set(ByVal value As Integer)
                m_iSampleTime = value
            End Set
        End Property

        Public Property WaitTime() As Integer
            Get
                Return m_iWaitTime
            End Get
            Set(ByVal value As Integer)
                m_iWaitTime = value
            End Set
        End Property


        Public Property Description() As String
            Get
                Return m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property


        Public Property ActiveRoutine() As RoutineType
            Get
                Return m_eActiveRoutine
            End Get

            Set(ByVal value As RoutineType)
                m_eActiveRoutine = value
            End Set
        End Property

        ' Constructor
        Public Sub New(ByVal LLCtr As LoadLockController)
            m_LLController = LLCtr
            m_strCurrentEQName = LLCtr.EquipmentName
            m_objLoadlock = DataManagerment.EquipmentManager.GetEquipment(m_strCurrentEQName)
        End Sub

        ' Run when calling Start Method
        Protected Overrides Sub OnDoWork()
            Try
                Dim strErrorMsg As String = String.Empty
                If (m_eActiveRoutine = RoutineType.RateOfRise) Then
                    If (m_LLController.CheckPressureCommunication(strErrorMsg)) Then
                        Me.RunRateOfRise()
                    Else
                        m_LLController.ThrowAlarm(strErrorMsg)
                        Me.m_terminateEvent.WaitOne(1000, True)
                    End If

                    RaiseOnOffEvent(RoutineType.RateOfRise, Equipment.WorkingStatuses.Off)
                ElseIf (m_eActiveRoutine = RoutineType.PumpdownCurve) Then

                    If (m_LLController.CheckPressureCommunication(strErrorMsg)) Then
                        If (Not RunPumpdownCurve()) Then
                            RaiseOnOffEvent(RoutineType.PumpdownCurve, Equipment.WorkingStatuses.Off)
                        End If
                    Else
                        Utils.ThrowAlarm(strErrorMsg)
                        Me.m_terminateEvent.WaitOne(1000, True)
                        RaiseOnOffEvent(RoutineType.PumpdownCurve, Equipment.WorkingStatuses.Off)
                    End If
                    'ElseIf (m_eActiveRoutine = RoutineType.RecoverPressure) Then
                    '    If (m_LLController.CheckPressureCommunication(strErrorMsg)) Then
                    '        Me.RunRecoverPresure()
                    '    Else
                    '        m_LLController.ThrowAlarm(strErrorMsg)
                    '        Me.m_terminateEvent.WaitOne(1000, True)
                    '    End If

                    '    RaiseOnOffEvent(RoutineType.RecoverPressure, Equipment.WorkingStatuses.Off)
                ElseIf (m_eActiveRoutine = RoutineType.IGDegas) Then

                    RaiseOnOffEvent(RoutineType.IGDegas, Equipment.WorkingStatuses.On)
                    If (m_LLController.CheckPressureCommunication(strErrorMsg)) Then
                        Me.RunIGDegas()
                    Else
                        m_LLController.ThrowAlarm(strErrorMsg)
                        Me.m_terminateEvent.WaitOne(1000, True)
                    End If
                    RaiseOnOffEvent(RoutineType.IGDegas, Equipment.WorkingStatuses.Off)
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
        End Sub

#Region "FLOW CONTROL"
        Private Function RunIGDegas() As Boolean
            Try
                Dim strErrMsg As String = String.Empty
                Dim strSequenceName = "[IG_DEGAS]"

                AVPLib.Log.coreLogger.Info("Enter RunIGDegas")
                'Is IG On? And Turbo Hivac Open or Cryo Hivac Open
                Utils.ShowStatusMessage(m_strCurrentEQName & " : Check IG status", strSequenceName)
                strErrMsg = Me.CheckLLIGIsOn()
                If strErrMsg <> String.Empty Then
                    m_LLController.ThrowAlarm(strErrMsg)
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_FAILED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If
                ' Check and exit
                If Me.HasTerminateRequest() Then
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_ABORTED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                ''Check Hivac Open
                Utils.ShowStatusMessage(m_strCurrentEQName & " : Check Hivac Open", strSequenceName)
                strErrMsg = Me.CheckLLHivacIsOpen()
                If strErrMsg <> String.Empty Then
                    m_LLController.ThrowAlarm(strErrMsg)
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_FAILED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                ' Check and exit
                If Me.HasTerminateRequest() Then
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_ABORTED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                'No Process is currently running?
                Utils.ShowStatusMessage(m_strCurrentEQName & " : Check any process is running", strSequenceName)
                strErrMsg = Me.CheckProcess_IsRunning()
                If strErrMsg <> String.Empty Then
                    m_LLController.ThrowAlarm(strErrMsg)
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_FAILED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                ' Check and exit
                If Me.HasTerminateRequest() Then
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_ABORTED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                'No PumpDown or Vent is running?
                Utils.ShowStatusMessage(m_strCurrentEQName & " : Check Vent/PumpDown is running", strSequenceName)
                strErrMsg = Me.CheckForPumpDownVent_IsRunning()
                If strErrMsg <> String.Empty Then
                    m_LLController.ThrowAlarm(strErrMsg)
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_FAILED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                ' Check and exit
                If Me.HasTerminateRequest() Then
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_ABORTED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                'Turn Degas On (Turn RO Off when RO On)
                Utils.ShowStatusMessage(m_strCurrentEQName & " : Turn Degas On", strSequenceName)
                strErrMsg = Me.TurnDegasOn()
                If strErrMsg <> String.Empty Then
                    m_LLController.ThrowAlarm(strErrMsg)
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_FAILED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                ' Check and exit
                If Me.HasTerminateRequest() Then
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_ABORTED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                'Wait 30s (IGDegas Time)
                Utils.ShowStatusMessage(m_strCurrentEQName & " : Wait for IGDegas Time", strSequenceName)
                Me.WaitForIGDegasTime()
                ' Check and exit
                If Me.HasTerminateRequest() Then
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_ABORTED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                'Turn Degas Off
                Utils.ShowStatusMessage(m_strCurrentEQName & " : Turn Degas Off", strSequenceName)
                strErrMsg = Me.TurnDegasOff()
                If strErrMsg <> String.Empty Then
                    m_LLController.ThrowAlarm(strErrMsg)
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_FAILED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If

                ' Check and exit
                If Me.HasTerminateRequest() Then
                    Utils.ShowStatusMessage(m_strCurrentEQName & IG_DEGAS_ABORTED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunIGDegas")
                    Return False
                End If
                'Complete
                Utils.ShowStatusMessage(m_strCurrentEQName & " : Complete IG Degas", strSequenceName)
                Return True
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
                Return False
            End Try
        End Function

        ' Run rate of rise routine
        Private Function RunRateOfRise() As Boolean
            AVPLib.Log.coreLogger.Info("Enter RunRateOfRise")
            Try
                Dim strErrMsg As String = ""
                Dim strSequenceName = "[RATE_OF_RISE]"

                If (RobotConfigurationValues.LLA_HIVAC_INSTALLED) Then

                    'Close Hivac Valve
                    Utils.ShowStatusMessage(m_strCurrentEQName & " close Hivac valve", strSequenceName)
                    strErrMsg = Me.CloseHivacValve()
                    If strErrMsg <> String.Empty Then
                        m_LLController.ThrowAlarm(strErrMsg)
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_FAILED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                        Return False
                    End If

                    ' Check and exit
                    If Me.HasTerminateRequest() Then
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_ABORTED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                        Return False
                    End If

                    ' Verify Hivac valve Closed
                    Utils.ShowStatusMessage(m_strCurrentEQName & " wait for Hivac valve closed", strSequenceName)
                    strErrMsg = Me.WaitForHivacClosed()
                    If strErrMsg <> String.Empty Then
                        m_LLController.ThrowAlarm(strErrMsg)
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_FAILED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                        Return False
                    End If

                    ' Check and exit
                    If Me.HasTerminateRequest() Then
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_ABORTED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                        Return False
                    End If

                    ' Turn On IG
                    Utils.ShowStatusMessage(m_strCurrentEQName & " turn On IG", strSequenceName)
                    strErrMsg = Me.TurnOnIG()
                    If strErrMsg <> String.Empty Then
                        m_LLController.ThrowAlarm(strErrMsg)
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_FAILED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                        Return False
                    End If

                    ' Check and exit
                    If Me.HasTerminateRequest() Then
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_ABORTED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                        Return False
                    End If

                    ' Verify IG On
                    Utils.ShowStatusMessage(m_strCurrentEQName & " wait for IG On", strSequenceName)
                    strErrMsg = Me.WaitForIGOn()

                    If strErrMsg <> String.Empty Then
                        'Retry Turn On IG
                        Utils.ShowStatusMessage("Retry Turn On IG.", strSequenceName)
                        strErrMsg = Me.TurnOnIG()

                        If strErrMsg <> String.Empty Then
                            m_LLController.ThrowAlarm(strErrMsg)
                            Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_FAILED, strSequenceName)
                            AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                            Return False
                        End If

                        ' Check and exit
                        If Me.HasTerminateRequest() Then
                            Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_ABORTED, strSequenceName)
                            AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                            Return False
                        End If

                        ' Verify IG On
                        Utils.ShowStatusMessage(m_strCurrentEQName & " wait for IG On", strSequenceName)
                        strErrMsg = Me.WaitForIGOn()

                        'If IG still not On ->Alarm
                        If strErrMsg <> String.Empty Then
                            m_LLController.ThrowAlarm(strErrMsg)
                            Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_FAILED, strSequenceName)
                            AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                            Return False
                        End If
                    End If

                    ' Check and exit
                    If Me.HasTerminateRequest() Then
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_ABORTED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                        Return False
                    End If

                ElseIf m_objLoadlock IsNot Nothing Then
                    ''Rough Only
                    'Close All Rough Valve
                    Utils.ShowStatusMessage(m_strCurrentEQName & " close Rough valves", strSequenceName)
                    strErrMsg = CloseLLRoughValves()
                    If strErrMsg <> String.Empty Then
                        m_LLController.ThrowAlarm(strErrMsg)
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_FAILED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                        Return False
                    End If

                End If

                ' Start Rate Of Rise
                Utils.ShowStatusMessage(m_strCurrentEQName & " start rate of rise", strSequenceName)
                If Not Me.StartRateOfRise() Then
                    If Me.HasTerminateRequest() Then
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_ABORTED, strSequenceName)
                    Else
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_FAILED, strSequenceName)
                    End If
                    AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                    Return False
                End If

                ' Check and exit
                If Me.HasTerminateRequest() Then
                    Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_ABORTED, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                    Return False
                End If

                If (m_objLoadlock IsNot Nothing AndAlso m_objLoadlock.IsIGInstalled) Then
                    ' Turn Off IG
                    Utils.ShowStatusMessage(m_strCurrentEQName & " turn off IG", strSequenceName)
                    strErrMsg = Me.TurnOffIG()
                    If strErrMsg <> String.Empty Then
                        m_LLController.ThrowAlarm(strErrMsg)
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_FAILED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                        Return False
                    End If

                    ' Check and exit
                    If Me.HasTerminateRequest() Then
                        Utils.ShowStatusMessage(m_strCurrentEQName & RATE_OF_RISE_ABORTED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave RunRateOfRise")
                        Return False
                    End If
                End If

                ' Start Pumpdown after finish
                Utils.ShowStatusMessage(m_strCurrentEQName & " start Pumpdown", strSequenceName)
                m_LLController.PumpDown()

                ' End Func
                Return True
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
                Return False
            End Try

        End Function

        ' Run pumpdown curve routine
        Private Function RunPumpdownCurve() As Boolean
            Try
                Dim strSequenceName = "[PUMP_DOWN_CURVE]"
                RaiseOnOffEvent(RoutineType.PumpdownCurve, Equipment.WorkingStatuses.On)

                '0001057: [ Khoi Ha- 06/25/2012] - When Users run Pump Down Curve while Hicvac valve of TM is closed(Turbo of TM is off).
                If (m_LLController IsNot Nothing AndAlso Not RobotConfigurationValues.LLA_HIVAC_INSTALLED AndAlso _
                   Not m_LLController.IsTMPumpPackageReady()) Then
                    Dim objTM As Business.TMController = ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString)

                    If (objTM IsNot Nothing) Then
                        If (Not objTM.IsPumpDownSeqRunning) Then
                            'start pump down
                            objTM.RaiseStartAutoPumpDown()
                            objTM.PumpDown()
                            m_HasRunTMPumpdown = True
                            'sleep for a while
                            If (m_terminateEvent.WaitOne(3000, True)) Then
                                objTM.EventStopThread.Set()
                                Utils.ShowStatusMessage(m_strCurrentEQName & PUMPDOWN_CURVE_ABORTED, strSequenceName)
                                RaiseOnOffEvent(RoutineType.PumpdownCurve, Equipment.WorkingStatuses.Off)
                                Return False
                            End If
                        End If

                        If (objTM.IsPumpDownSeqRunning) Then
                            'waiting for TM pump down completed with time out
                            Dim timeout As Integer = VentPumdownLib.TMPumpdownConfig.TMPumpDownComplete
                            If (WaitTMPumpdownCompleted(timeout, m_terminateEvent, objTM.EventStopThread)) Then
                                Return False
                            End If
                        End If

                        'check pump package again, if ok -> continue to PDC
                        If (Not m_LLController.IsTMPumpPackageReady()) Then
                            Utils.ShowStatusMessage(m_strCurrentEQName & PUMPDOWN_CURVE_FAILED, strSequenceName)
                            Return False
                        End If
                    End If
                End If

                ' Start Pumpdown sequence
                Me.StartPumpdownCurve()

                ' Check and Exit
                If Me.HasTerminateRequest() Then
                    StopLoadlockPumpdown()
                    Utils.ShowStatusMessage(m_strCurrentEQName & PUMPDOWN_CURVE_ABORTED, strSequenceName)
                    Return False
                End If

                ' Collect and Write File
                Me.StartPDCTimer()
                Return True
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
                Return False
            End Try
        End Function

        Private Sub StopLoadlockPumpdown()
            'if LL Pump down running -> stop LL PD
            'if TM Pump down running -> stop TM PD
            If (m_objLoadlock IsNot Nothing AndAlso m_objLoadlock.PumpDownStatus = Equipment.WorkingStatuses.On AndAlso m_HasRunLLPumpdown) Then
                m_LLController.StopAutoVentPumpdown()
                m_HasRunLLPumpdown = False
            End If
        End Sub
        Private Function WaitTMPumpdownCompleted(ByVal timeout As Integer, ByVal abortedEvent As System.Threading.ManualResetEvent, ByVal TMPumpdownAbortedEvent As System.Threading.ManualResetEvent) As Boolean
            Utils.WaitOnCondition(AddressOf IsTMPumpdownStopped, timeout, abortedEvent, TMPumpdownAbortedEvent)
        End Function
        Private Function IsTMPumpdownStopped() As Boolean
            Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
            Return (objTM.PumpDownStatus = DataManagerment.Equipment.WorkingStatuses.Off)
        End Function
        Protected Function RunRecoverPresure() As Boolean
            ' Start Recover Pressure           
            Dim span As New TimeSpan(0, WaitTime, 0)
            Dim rorStartTickCount As Int64 = Environment.TickCount
            Try
                'max sample count
                Dim maxLoopCount As Integer = (WaitTime * 60) / SampleTime
                'start with one sample
                Dim iLoopCount As Integer = 0

                RaiseOnOffEvent(RoutineType.RecoverPressure, Equipment.WorkingStatuses.On)
                CreateFileName(RoutineType.RecoverPressure)
                While Not HasTerminateRequest()
                    Dim tick As Integer = Environment.TickCount
                    ' Record Recover Samples to a file
                    Dim rorSpan As TimeSpan = TimeSpan.FromMilliseconds(Utils.GetTickCountDelta(rorStartTickCount))
                    Dim objLoadLock As DataManagerment.LoadLock = EquipmentManager.GetEquipment(Me.m_strCurrentEQName)
                    Dim dblPressure As Double = 0
                    If objLoadLock.IGStatus = Equipment.WorkingStatuses.On Then
                        dblPressure = objLoadLock.IG
                    Else
                        dblPressure = objLoadLock.CG
                    End If

                    'and notify to caller also.
                    Dim remainingTimeInSecs As Integer = (WaitTime * 60) - rorSpan.TotalSeconds
                    Me.RaiseDataSample(RoutineType.RecoverPressure, remainingTimeInSecs, rorSpan.TotalSeconds, dblPressure)

                    'increase loop count
                    iLoopCount += 1
                    If iLoopCount > maxLoopCount Then
                        AVPLib.Log.coreLogger.Debug("Done Recover Pressure Sampling, Sample time=" & span.TotalSeconds.ToString() & "Secs.")
                        Return True
                    End If

                    Dim delta As Integer = Utils.GetTickCountDelta(tick)
                    If Me.SleepButAlertabletoTerminateRequest(Me.SampleTime * 1000 - delta) Then
                        AVPLib.Log.coreLogger.Error("Error, in stopping mode")
                        Return False
                    End If

                End While
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
            Return False
        End Function
#End Region

#Region "ROUTINE CONTROL"
        Private Function CloseLLRoughValves() As String
            Dim strErrorMsg As String = String.Empty
            Try
                'close slow rough valve 
                If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED AndAlso m_objLoadlock.SlowRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    strErrorMsg = LLCryoUtility.CloseLLSlowRough(m_objLoadlock.Name)
                    If (strErrorMsg <> String.Empty) Then
                        Exit Try
                    End If
                End If

                'close fast rough valve
                If (m_objLoadlock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    strErrorMsg = LLCryoUtility.CloseLLFastRough(m_objLoadlock.Name)
                    If (strErrorMsg <> String.Empty) Then
                        Exit Try
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
            Return strErrorMsg
        End Function

        Private Sub WaitForIGDegasTime()
            Dim rorStartTickCount As Int64 = Environment.TickCount

            Dim intDeGas_WaitTime As Integer = RobotConfigurationValues.LLA_IGDEGAS_WAIT_TIME_IN_SECONDS

            Dim span As New TimeSpan(0, 0, intDeGas_WaitTime)
            Try
                While Not HasTerminateRequest()
                    If TimeSpan.FromMilliseconds(Utils.GetTickCountDelta(rorStartTickCount)) > span Then
                        AVPLib.Log.coreLogger.Debug("Done for waiting IG Degas Time.")
                        Exit While
                    End If
                    System.Threading.Thread.Sleep(100)
                End While
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
        End Sub

        Private Function CheckLLIGIsOn() As String
            Dim Msg As String = String.Empty
            If Not m_LLController.IsLLIGOnCond Then
                Msg = String.Format(ContainerData.GetMessageText("IGDidNotOn"), m_strCurrentEQName)
            End If
            Return Msg
        End Function

        Private Function CheckLLHivacIsOpen() As String
            Dim Msg As String = String.Empty
            Try
                If Not (m_LLController.IsLLHiVacOpenCond) Then
                    Msg = String.Format(ContainerData.GetMessageText("HivacValveDidNotOpen"), m_strCurrentEQName)
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
            Return Msg
        End Function

        Private Function TurnDegasOn() As String
            Return LLCryoUtility.TurnIGDegas_On(Me.m_strCurrentEQName)
        End Function

        Private Function TurnDegasOff() As String
            Return LLCryoUtility.TurnIGDegas_Off(Me.m_strCurrentEQName)
        End Function

        Private Function CheckForPumpDownVent_IsRunning() As String
            Dim msg As String = String.Empty
            Try
                If m_LLController.IsVentSeqRunning OrElse m_LLController.IsPumpDownSeqRunning Then
                    msg = String.Format(ContainerData.GetMessageText("VentPumpDownRunning"), m_strCurrentEQName)
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
           
            Return msg
        End Function

        Private Function CheckProcess_IsRunning() As String
            Dim msg As String = String.Empty
            Try
                Dim objLLElevator As AVPLib.DataManagerment.LLElevator = Nothing
                Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
                Dim objavpCtrlJob As AVPLib.Business.AVPControlJob = Nothing
                objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                objLLElevator = _
                  AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
                objavpCtrlJob = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockCtrl.CtrlJobId)

                If objavpCtrlJob IsNot Nothing Then
                    msg = String.Format(ContainerData.GetMessageText("Process_Running"), m_strCurrentEQName)
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
            Return msg
        End Function

        Private Function CloseHivacValve() As String
            Return LoadLockUtility.CloseLLHivac(Me.m_strCurrentEQName)
        End Function

        Private Function WaitForHivacClosed() As String
            Dim Msg As String = ""
            Try
                If Not Utils.WaitOnCondition(AddressOf m_LLController.IsLLHiVacCloseCond, VentPumdownLib.LLPumpdownConfig.LLHivacOpenCloseTimeOut * 1000, m_terminateEvent) Then
                    If Not m_terminateEvent.WaitOne(0, True) Then
                        Msg = String.Format(ContainerData.GetMessageText("LLHiVacWasNotClose"), Me.m_strCurrentEQName)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
            Return Msg
        End Function

        Private Function TurnOnIG() As String
            Return LLCryoUtility.TurnOnIG(Me.m_strCurrentEQName)
        End Function

        Private Function WaitForIGOn() As String
            Dim Msg As String = ""
            If Not Utils.WaitOnCondition(AddressOf m_LLController.IsLLIGOnCond, VentPumdownLib.LLPumpdownConfig.IGOnOffTimeOut * 1000, m_terminateEvent) Then
                If Not m_terminateEvent.WaitOne(0, True) Then
                    Msg = String.Format(ContainerData.GetMessageText("IGDidNotOn"), Me.m_strCurrentEQName)
                End If
            End If
            Return Msg
        End Function

        Private Function TurnOffIG() As String
            Return LLCryoUtility.TurnOffIG(Me.m_strCurrentEQName)
        End Function

        Private Sub StartPumpdownCurve()
            CreateFileName(RoutineType.PumpdownCurve)
            m_LLController.RaiseStartPumpDown()
            m_LLController.PumpDown()
            m_HasRunLLPumpdown = True
        End Sub

#End Region

#Region "RATE OF RISE"


        Private Function StartRateOfRise() As Boolean
            ' Start Rise Of Rise            
            Dim span As New TimeSpan(0, WaitTime, 0)

            Try
                'max sample count
                Dim maxLoopCount As Integer = (WaitTime * 60) / SampleTime
                'start with one sample
                Dim iLoopCount As Integer = 0

                RaiseOnOffEvent(RoutineType.RateOfRise, Equipment.WorkingStatuses.On)
                CreateFileName(RoutineType.RateOfRise)
                Dim objLoadLock As DataManagerment.LoadLock = EquipmentManager.GetEquipment(Me.m_strCurrentEQName)
                Dim rorStartTickCount As Int64 = Environment.TickCount

                While Not HasTerminateRequest()
                    Dim tick As Integer = Environment.TickCount
                    ' Record Rate Of Rise Samples to a file
                    Dim rorSpan As TimeSpan = TimeSpan.FromMilliseconds(Utils.GetTickCountDelta(rorStartTickCount))
                    Dim IonGaugePressure As Double = objLoadLock.Pressure

                    'and notify to caller also.
                    Dim remainingTimeInSecs As Integer = (WaitTime * 60) - rorSpan.TotalSeconds
                    If RobotConfigurationValues.LLA_HIVAC_INSTALLED Then
                        Me.RaiseDataSample(RoutineType.RateOfRise, remainingTimeInSecs, rorSpan.TotalSeconds, IonGaugePressure)
                    Else
                        Me.RaiseCGDataSample(RoutineType.RateOfRise, remainingTimeInSecs, rorSpan.TotalSeconds, IonGaugePressure)
                    End If

                    'increase loop count
                    iLoopCount += 1
                    If iLoopCount > maxLoopCount Then
                        AVPLib.Log.coreLogger.Debug("Done ROR Sampling, Sample time=" & span.TotalSeconds.ToString() & "Secs.")
                        Return True
                    End If

                    Dim delta As Integer = Utils.GetTickCountDelta(tick)
                    If Me.SleepButAlertabletoTerminateRequest(Me.SampleTime * 1000 - delta) Then
                        AVPLib.Log.coreLogger.Error("Error, in stopping mode")
                        Return False
                    End If

                End While
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
            Return False
        End Function

#End Region

#Region "PUMPDOWN CURVE"
        Private Function StartPDCTimer() As Boolean
            ' Lazy Initialization
            If m_pdcTimer Is Nothing Then
                m_pdcTimer = New System.Timers.Timer()
                m_pdcTimer.Interval = SampleTime * 1000
                AddHandler m_pdcTimer.Elapsed, AddressOf PDCTimer_Elapsed
            End If
            If Not m_pdcTimer.Enabled Then
                m_lpdcStartTickCount = Environment.TickCount
                m_pdcSampleCount = 0
                CollectSample()
                Return True
            End If
            Return False
        End Function

        Public Function StopPDCTimer() As Boolean
            Dim bResult As Boolean = False
            If m_pdcTimer IsNot Nothing Then
                If m_pdcTimer.Enabled Then
                    m_pdcTimer.Enabled = False
                    bResult = True
                End If
                ' Release the timer.
                m_pdcTimer.Dispose()
                m_pdcTimer = Nothing
            End If
            Return bResult
        End Function
        
        Public Sub StopPDC()
            Try
                StopPDCTimer()
                'if LL Pump down running -> stop LL PD
                'if TM Pump down running -> stop TM PD
                If (m_objLoadlock IsNot Nothing AndAlso m_objLoadlock.PumpDownStatus = Equipment.WorkingStatuses.On AndAlso m_HasRunLLPumpdown) Then
                    m_LLController.StopAutoVentPumpdown()
                End If
                Dim objTM As DataManagerment.CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                If (objTM IsNot Nothing AndAlso objTM.PumpDownStatus = DataManagerment.Equipment.WorkingStatuses.On AndAlso m_HasRunTMPumpdown) Then
                    Dim objTMController As TMController = Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString)
                    objTMController.StopPumpDown()
                End If

                m_HasRunTMPumpdown = False
                m_HasRunLLPumpdown = False
                '
                RaiseOnOffEvent(RoutineType.PumpdownCurve, Equipment.WorkingStatuses.Off)

                AVPLib.Log.coreLogger.Error("Stop LL PDC at:" & DateTime.Now.ToLongTimeString)

            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
        End Sub

        Private Sub StopPDCWhenCompleted()
            Try
                StopPDCTimer()

                RaiseOnOffEvent(RoutineType.PumpdownCurve, Equipment.WorkingStatuses.Off)

                AVPLib.Log.coreLogger.Error("Stop LL PDC at:" & DateTime.Now.ToLongTimeString)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
        End Sub

        Sub CollectSample()
            Try
                ' Prevent reentrancy.
                m_pdcTimer.Enabled = False
                ' Record Pump Down Curve Samples to a file
                Dim pdcSpan As TimeSpan = TimeSpan.FromMilliseconds(Utils.GetTickCountDelta(m_lpdcStartTickCount))
                Dim timerSpan As Double = pdcSpan.TotalMilliseconds - m_pdcSampleCount * SampleTime * 1000
                Dim objLoadLock As DataManagerment.LoadLock = EquipmentManager.GetEquipment(Me.m_strCurrentEQName)
                Dim IonGaugePressure As Double = 0
                If objLoadLock.IGStatus = Equipment.WorkingStatuses.On Then
                    IonGaugePressure = objLoadLock.IG
                Else
                    IonGaugePressure = objLoadLock.CG
                End If
                'and notify to caller also.
                Dim remainingTimeInSecs As Integer = (WaitTime * 60) - pdcSpan.TotalSeconds
                Me.RaiseDataSample(RoutineType.PumpdownCurve, remainingTimeInSecs, pdcSpan.TotalSeconds, IonGaugePressure)

                'increase sample count
                m_pdcSampleCount += 1
                '
                '
                Dim bIsEnded As Boolean = False
                Dim span As New TimeSpan(0, WaitTime, 0)
                If Me.HasTerminateRequest() Then
                    Me.StopPDC()
                    AVPLib.Log.coreLogger.Error("Error, in stopping mode")
                ElseIf GetMaxSampleCount(Me.WaitTime, Me.SampleTime) > m_pdcSampleCount Then
                    ' Reenable Elapsed Event happens.
                    m_pdcTimer.Interval = SampleTime * 1000 - timerSpan
                    m_pdcTimer.Enabled = True
                Else
                    ' Done PDC.
                    bIsEnded = True
                    AVPLib.Log.coreLogger.Debug("Done PDC Sampling, sample time=" & span.TotalSeconds.ToString() & "Secs.")
                End If

                If bIsEnded Then
                    ' Stop PDC Timer
                    Me.StopPDCWhenCompleted()
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
        End Sub

        Protected Sub PDCTimer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
            CollectSample()
        End Sub

        Private Function GetMaxSampleCount(ByVal iWaitTime As Integer, ByVal interval As Integer) As Integer
            Return (((iWaitTime * 60) / interval) + 1)
        End Function
#End Region

    End Class

    Public Class LLRecoverPressureRoutineExecutor
        Inherits LLRoutineExecutor

        ' Constructor
        Public Sub New(ByVal LLCtr As LoadLockController)
            MyBase.New(LLCtr)
        End Sub

        ' Run when calling Start Method
        Protected Overrides Sub OnDoWork()
            Try
                Dim strErrorMsg As String = String.Empty
                If (m_LLController.CheckPressureCommunication(strErrorMsg)) Then
                    Me.RunRecoverPresure()
                Else
                    m_LLController.ThrowAlarm(strErrorMsg)
                    Me.m_terminateEvent.WaitOne(1000, True)
                End If

                RaiseOnOffEvent(RoutineType.RecoverPressure, Equipment.WorkingStatuses.Off)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
        End Sub

    End Class

End Namespace
