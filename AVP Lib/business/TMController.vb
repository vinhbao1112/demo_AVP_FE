Imports System.Threading
Imports AVPLib.DataManagerment
Imports AVPLib.ConstEnum

Namespace Business
    Public Class TMController
        Inherits ControllerObject

#Region "Class Constants & Variables"
        Private trdAutoVent As Thread
        Private trdPumpDown As Thread
        Private trdMechanicalPump1 As Thread
        Private trdMechanicalPump2 As Thread
        Private trdToolOnline As Thread
        Private m_IsShowAlarmWhenOnline As Boolean

        Private m_blnIsVentRunning As Boolean = False
        Private m_blnIsPumpDownRunning As Boolean = False

        Private m_EventStopThread As ManualResetEvent = New ManualResetEvent(False)
        Private m_blnOpenTMFastRough As Boolean = False
        Private m_blnOpenTMVent As Boolean = False
        Private m_blnOpenTMHivac As Boolean = False
        Private m_blnOpenTMTurboForeline As Boolean = False
        Private m_blnTurnOnTurbo As Boolean = False

        Private m_RoutineExecutor As TMRoutineExecutor = Nothing
        Private m_RecoverPressureRoutineExecutor As TMRecoverPressureRoutineExecutor = Nothing
        Private m_hashTableIsoValveThread As Hashtable = Nothing

        Private m_strPumpDownFailed As String = ". PumpDown failed "
        Private m_objTransferModule As DataManagerment.CassettesModule = Nothing
        Private m_CGMultiFactor As Double = 0.8
#End Region

#Region "Public methods"
        Public ReadOnly Property EventStopThread() As ManualResetEvent
            Get
                Return m_EventStopThread
            End Get
        End Property
        Public ReadOnly Property IsVentSeqRunning() As Boolean
            Get
                Return m_blnIsVentRunning
            End Get
        End Property

        Public ReadOnly Property IsPumpDownSeqRunning() As Boolean
            Get
                Return m_blnIsPumpDownRunning
            End Get
        End Property

        Public ReadOnly Property CurrentRoutineExecutor() As TMRoutineExecutor
            Get
                Return m_RoutineExecutor
            End Get
        End Property

        Public ReadOnly Property CurrentRecoverPressureRoutineExecutor() As TMRecoverPressureRoutineExecutor
            Get
                Return m_RecoverPressureRoutineExecutor
            End Get
        End Property

        Public ReadOnly Property ObjectPumpPackage() As PumpPackageController
            Get
                Return Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
            End Get
        End Property

        Public ReadOnly Property ObjectRoughPumpMachine() As DataManagerment.RoughPumpMachine
            Get
                Return CType(DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName), DataManagerment.RoughPumpMachine)
            End Get
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-01</date>
        ''' </author>
        ''' <summary>
        ''' Do something when Init
        ''' at this time we need turn off IG when Initialize
        ''' add more here when customer request
        ''' </summary>
        ''' <remarks></remarks>
        Public Function Initialize() As Boolean
            Dim blResult As Boolean = False
            Try
                Dim strErrorMsg As String = String.Empty
                strErrorMsg = TMCryoUtility.TurnOffIG(Me.EquipmentName)

                If strErrorMsg <> String.Empty Then
                    blResult = False
                Else
                    blResult = True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-01-10</date>
        ''' </author>
        ''' <summary>
        ''' Process Alarm
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ProcessAlarm()
            AVPLib.Log.coreLogger.Info("Enter ProcessAlarm")
            Try
                m_EventStopThread.Set()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ProcessAlarm")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-29</date>
        ''' </author>
        ''' <summary>
        ''' Dispose
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Dispose()
            AVPLib.Log.coreLogger.Info("Enter Dispose")
            Try
                m_EventStopThread.Set()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Dispose")
        End Sub

        ''' <author>
        '''    	<name> Vo Tan Dat </name>
        '''    	<date> 2010-09-08</date>
        ''' </author>
        ''' <summary>
        ''' Dispose
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RateOfRise()
            AVPLib.Log.coreLogger.Info("Enter RateOfRise")
            Try
                m_RoutineExecutor.ActiveRoutine = RoutineType.RateOfRise
                Dim objTMPumpPackageCtrl As PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
                If objTMPumpPackageCtrl IsNot Nothing AndAlso (objTMPumpPackageCtrl.DisplayName = ConstEnum.Equipments.TMCryo.ToString()) Then
                    Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(objTMPumpPackageCtrl.EquipmentName.ToString())
                    If objCryo IsNot Nothing AndAlso objCryo.RegenStatus = Equipment.WorkingStatuses.On Then
                        ThrowAlarm("Can Not Start TM " & m_RoutineExecutor.ActiveRoutine.ToString() & " Because Cryo Is Regening.")
                        m_RoutineExecutor.RaiseOnOffEvent(m_RoutineExecutor.ActiveRoutine, Equipment.WorkingStatuses.Off)
                        StopRateOfRise()
                        Exit Try
                    End If
                End If

                m_RoutineExecutor.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RateOfRise")
        End Sub
        'Truc Le
        Public Overrides Sub RecoverPressure()
            AVPLib.Log.coreLogger.Info("Enter RecoverPressure")
            Try
                m_RecoverPressureRoutineExecutor.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RecoverPressure")
        End Sub

        Public Overrides Sub StopRecoverPressure()
            AVPLib.Log.coreLogger.Info("Enter StopRecoverPressure")
            Try
                m_RecoverPressureRoutineExecutor.Terminate()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopRecoverPressure")
        End Sub
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2010-09-08</date>
        ''' </author>
        ''' <summary>
        ''' Dispose
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub DoIGDegas()
            AVPLib.Log.coreLogger.Info("Enter DoIGDegas")
            Try
                m_RoutineExecutor.ActiveRoutine = RoutineType.IGDegas
                m_RoutineExecutor.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoIGDegas")
        End Sub

        ''' <author>
        ''' <name>Hoai Ly</name>
        ''' <date> 2015-05-11</date>
        ''' </author>
        ''' <summary>
        ''' StopIGDegas
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StopIGDegas()
            AVPLib.Log.coreLogger.Info("Enter StopIGDegas")
            Try
                m_RoutineExecutor.Terminate()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopIGDegas")
        End Sub

        ''' <author>
        '''    	<name> Vo Tan Dat </name>
        '''    	<date> 2010-09-08</date>
        ''' </author>
        ''' <summary>
        ''' Dispose
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StopRateOfRise()
            AVPLib.Log.coreLogger.Info("Enter StopRateOfRise")
            Try
                m_RoutineExecutor.Terminate()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopRateOfRise")
        End Sub

        ''' <author>
        '''    	<name> Vo Tan Dat </name>
        '''    	<date> 2010-09-08</date>
        ''' </author>
        ''' <summary>
        ''' Dispose
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PumpdownCurve()
            AVPLib.Log.coreLogger.Info("Enter PumpdownCurve")
            Try
                m_RoutineExecutor.ActiveRoutine = RoutineType.PumpdownCurve
                Dim objTMPumpPackageCtrl As PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
                If objTMPumpPackageCtrl IsNot Nothing AndAlso (objTMPumpPackageCtrl.DisplayName = ConstEnum.Equipments.TMCryo.ToString()) Then
                    Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(objTMPumpPackageCtrl.EquipmentName.ToString())
                    If objCryo IsNot Nothing AndAlso objCryo.RegenStatus = Equipment.WorkingStatuses.On Then
                        ThrowAlarm("Can Not Start TM " & m_RoutineExecutor.ActiveRoutine.ToString() & " Because Cryo Is Regening.")
                        StopPumpdownCurve()
                        Exit Try
                    End If
                End If

                m_RoutineExecutor.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave PumpdownCurve")
        End Sub

        ''' <author>
        '''    	<name> Vo Tan Dat </name>
        '''    	<date> 2010-09-08</date>
        ''' </author>
        ''' <summary>
        ''' Dispose
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StopPumpdownCurve()
            AVPLib.Log.coreLogger.Info("Enter StopPumpdownCurve")
            Try
                m_RoutineExecutor.Terminate()
                m_RoutineExecutor.StopPDC()
                ' RemoveHandler m_RoutineExecutor.OnDataCollect, AddressOf ???
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopPumpdownCurve")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do task ControllerManager
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Overrides Sub DoTask(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter DoTask")
            Dim strErrMsg As String = String.Empty

            Try
                Select Case Message
                    Case "OverideModeStatus On"
                        TurnOnOffProtectedMode(True)
                    Case "OverideModeStatus Off"
                        TurnOnOffProtectedMode(False)
                    Case "IGDegas On"
                        '''Action item for IGDegas
                        DoIGDegas()
                    Case "IGDegas Off"
                        StopIGDegas()
                    Case "Vent On"
                        'Check the result here and raise the Message if need
                        strErrMsg = TMCryoUtility.OpenVentValve(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "Vent Off"
                        'Check the result here and raise the Message if need
                        strErrMsg = TMCryoUtility.CloseVentValve(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "Rough On"
                        'Check the result here and raise the Message if need
                        strErrMsg = TMCryoUtility.OpenRoughValve(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                            Dim objRough As DataManagerment.RoughPumpMachine =
                            DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)

                            'release Rough when Open Failed
                            If (objRough IsNot Nothing) Then
                                objRough.ReleaseRoughLineInUse(Me.EquipmentName, True)
                            End If

                        End If
                    Case "Rough Off"
                        'Check the result here and raise the Message if need
                        strErrMsg = TMCryoUtility.CloseRoughValve(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "Ion On"
                        'Check the result here and raise the Message if need
                        strErrMsg = SafetyTurnIGOnOff(True)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "Ion Off"
                        ' Check the result here and raise the Message if need
                        strErrMsg = SafetyTurnIGOnOff(False)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "IGFilament1"
                        'Check the result here and raise the Message if need
                        strErrMsg = SafetySwitchIGFilament1()
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "IGFilament2"
                        'Check the result here and raise the Message if need
                        strErrMsg = SafetySwitchIGFilament2()
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case ConstEnum.SETATMCONVERTRON
                        strErrMsg = TMCryoUtility.SetConvertionGaugePressure(Me.EquipmentName, ConstEnum.DEVICENET_SET_ATM)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case ConstEnum.SETVACCONVERTRON
                        strErrMsg = TMCryoUtility.SetConvertionGaugePressure(Me.EquipmentName, ConstEnum.DEVICENET_SET_VAC)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case ConstEnum.SETATMFORELINECG
                        strErrMsg = TMCryoUtility.SetTurboForelineCGPressure(Me.EquipmentName, ConstEnum.DEVICENET_SET_ATM)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "SetATMMechanicalPump2CG"
                        strErrMsg = TMCryoUtility.SetMechanicalPumpCGPressure(ConstEnum.Equipments.RoughPumpMachine2.ToString, ConstEnum.DEVICENET_SET_ATM)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "SetATMMechanicalPump1CG"
                        strErrMsg = TMCryoUtility.SetMechanicalPumpCGPressure(ConstEnum.Equipments.RoughPumpMachine1.ToString, ConstEnum.DEVICENET_SET_ATM)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "TMHiVac On"
                        strErrMsg = TMCryoUtility.OpenHiVacValve(Me.EquipmentName, IIf(m_objTransferModule.OverideModeStatus = Equipment.WorkingStatuses.On, False, True))
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        Else
                            'wait for TM/LLx Hivac On
                            If Utils.WaitOnCondition(AddressOf IsTMHivacOpenCond, VentPumdownLib.TMPumpdownConfig.TMHivacOpenCloseTimeOut * 1000, Nothing) Then
                                If Me.m_objTransferModule.VacSwitchStatus = Equipment.WorkingStatuses.On Then
                                    ' Turn On IG also.
                                    strErrMsg = TMCryoUtility.TurnOnIG(Me.EquipmentName)
                                    If strErrMsg <> String.Empty Then
                                        Me.ThrowAlarm(strErrMsg)
                                    End If
                                End If
                            End If
                        End If
                    Case "TMHiVac Off"
                        strErrMsg = TMCryoUtility.CloseHiVacValve(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        Else
                            ' IG is closed automatically when TM Hivac is closed.
                            strErrMsg = TMCryoUtility.TurnOffIG(Me.EquipmentName)
                            If strErrMsg <> String.Empty Then
                                Me.ThrowAlarm(strErrMsg)
                            End If
                        End If
                    Case "TurboForeLineValve On"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = TMCryoUtility.OpenTMTurboForeLineValve(Me.EquipmentName, IIf(m_objTransferModule.OverideModeStatus = Equipment.WorkingStatuses.On, False, True), True)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "TurboForeLineValve Off"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = TMCryoUtility.CloseTMTurboForeLineValve(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "Turbo On"
                        Dim objTurboController As TurboController = DirectCast(ObjectPumpPackage, TurboController)
                        If objTurboController IsNot Nothing Then
                            objTurboController.TurnOnOff(True, m_objTransferModule.TurboForelineCGRelay)
                        End If
                    Case "Turbo Off"
                        Dim objTurboController As TurboController = DirectCast(ObjectPumpPackage, TurboController)
                        If objTurboController IsNot Nothing Then
                            objTurboController.TurnOnOff(False, m_objTransferModule.TurboForelineCGRelay)
                        End If
                    Case "Online_NoAlarm", "Online_NoAlarm False"
                        m_IsShowAlarmWhenOnline = False
                        Me.Online()
                    Case "Online"
                        m_IsShowAlarmWhenOnline = True
                        Me.Online()
                    Case "Offline", "Offline False"
                        Me.Offline()
                    Case STR_RECOVER_PRESSURE
                        RecoverPressure()
                    Case STR_STOP_RECOVER_PRESSURE
                        StopRecoverPressure()
                    Case STR_RATE_OF_RISE
                        RateOfRise()
                    Case STR_STOP_RATE_OF_RISE
                        StopRateOfRise()
                    Case STR_PUMP_DOWN_CURVE
                        PumpdownCurve()
                    Case STR_STOP_PUMP_DOWN_CURVE
                        StopPumpdownCurve()
                    Case "AutoVent"
                        Me.AutoVent()
                    Case "StopAutoVent"
                        StopAutoVent()
                    Case "PumpDown"
                        Me.PumpDown()
                    Case "StopPumpDown"
                        StopPumpDown()
                    Case ConstEnum.ChangeSlitValvePM1On, ConstEnum.ChangeSlitValvePM2On, ConstEnum.ChangeSlitValvePM3On,
                         ConstEnum.ChangeSlitValveLLAOn

                        With m_objTransferModule
                            If .OverideModeStatus = Equipment.WorkingStatuses.Off Then
                                If (Message = ConstEnum.ChangeSlitValveLLAOn) Then
                                    strErrMsg = ChamberUtility.IsLLRoughValveClosed(ConstEnum.Equipments.LoadLockA.ToString)
                                End If

                                If strErrMsg <> String.Empty Then
                                    Me.ThrowAlarm(strErrMsg)
                                    Exit Select
                                End If
                            End If
                        End With

                        Dim strSplitValveNo As String() = Message.Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)
                        strErrMsg = ChamberUtility.OpenCloseSlitValve(Me.EquipmentName, True, strSplitValveNo(0))
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                            Exit Try
                        End If
                        '[KhoiHa- 05/20/2014]ALL system running kepware or devicenet or other platform. 
                        'When user or sequence open/close isolation valve and failed, we must put both open/close RO to false. 
                        'This will prevent isolation valve open or close upon hardware is repair. We will confirm this in the next meeting.
                        UnknownIsolationValveIfOpenCloseFailed(strSplitValveNo(0), True)

                    Case ConstEnum.ChangeSlitValvePM1Off, ConstEnum.ChangeSlitValvePM2Off, ConstEnum.ChangeSlitValvePM3Off,
                         ConstEnum.ChangeSlitValveLLAOff

                        SafetyCloseIsolationValve(Message)

                    Case "RoughPumpControl On"
                        TurnOnMechanicalPump1()
                    Case "RoughPumpControl Off"
                        SafetyTurnOffMechanicalPump(ConstEnum.Equipments.RoughPumpMachine1.ToString)
                    Case "RoughPumpControl2 On"
                        TurnOnMechanical2Pump()
                    Case "RoughPumpControl2 Off"
                        SafetyTurnOffMechanicalPump(ConstEnum.Equipments.RoughPumpMachine2.ToString)

                    Case "Turn_Process_Complete_Chime On"
                        If (Not TMCryoUtility.Turn_Process_Complete_Chime(True)) Then
                            Me.ThrowAlarm("Failed to turn on Process Complete Chime.")
                        End If
                    Case "Turn_Process_Complete_Chime Off"
                        If (Not TMCryoUtility.Turn_Process_Complete_Chime(False)) Then
                            Me.ThrowAlarm("Failed to turn off Process Complete Chime.")
                        End If
                    Case "CancelMove"
                        CancelMove()
                    Case Else
                        If Message.StartsWith("ReleaseRoughPump1InUse") Then
                            Dim objRough As RoughPumpMachine = EquipmentManager.GetEquipment(Equipments.RoughPumpMachine1.ToString())
                            If (objRough IsNot Nothing) Then
                                objRough.ReleaseRoughLineInUse()
                            End If
                        ElseIf Message.StartsWith("ReleaseRoughPump2InUse") Then
                            Dim objRough As RoughPumpMachine = EquipmentManager.GetEquipment(Equipments.RoughPumpMachine2.ToString())
                            If (objRough IsNot Nothing) Then
                                objRough.ReleaseRoughLineInUse()
                            End If
                        ElseIf Message.StartsWith("SetTMCGTripPoint") Then
                            Dim strValue As String = Utils.ParseValue(Message)
                            strErrMsg = ChamberUtility.SetCGTripPoint(Me.EquipmentName, String.Format(SET_TRIP_POINT & " " & strValue))
                            If strErrMsg <> String.Empty Then
                                Me.ThrowAlarm(strErrMsg)
                            End If
                        ElseIf Message.StartsWith("SetTMTurboCGTripPoint") Then
                            Dim strValue As String = Utils.ParseValue(Message)
                            strErrMsg = ChamberUtility.SetTurboCGTripPoint(Me.EquipmentName, String.Format(SET_TRIP_POINT & " " & strValue))
                            If strErrMsg <> String.Empty Then
                                Me.ThrowAlarm(strErrMsg)
                            End If
                        ElseIf Message.StartsWith("SetMPCGTripPoint") Then
                            Dim strValue As String = Utils.ParseValue(Message)
                            strErrMsg = TMCryoUtility.SetMechanicalPumpCGTripPoint(String.Format(SET_TRIP_POINT & " " & strValue))
                            If strErrMsg <> String.Empty Then
                                Me.ThrowAlarm(strErrMsg)
                            End If
                        End If

                        If AVPLib.RobotConfigurationValues.TMWATERPUM_VISIBLE AndAlso m_htbChildController.Contains("TMWaterPump") Then
                            Dim ctlWaterPump As WaterPumpController = CType(m_htbChildController.Item("TMWaterPump"), WaterPumpController)
                            If Message.IndexOf("WaterPump") > -1 Then
                                ctlWaterPump.DoTask(Message)
                            End If
                        End If
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub
        Public Sub TurnOnMechanicalPump1()
            AVPLib.Log.coreLogger.Info("Enter TurnOnMechanicalPump1")
            Try
                trdMechanicalPump1 = New Thread(AddressOf TurnOnMechanicalPump1Proc)
                m_EventStopThread.Reset()
                trdMechanicalPump1.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOnMechanicalPump1")
        End Sub
        Private Sub TurnOnMechanicalPump1Proc()
            AVPLib.Log.coreLogger.Info("Enter TurnOnMechanicalPump1Proc")
            Try
                Dim mechanicalpump As Boolean = Me.SafetyTurnOnMechanicalPump(Equipments.RoughPumpMachine1.ToString)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOnMechanicalPump1Proc")
        End Sub

        Public Sub TurnOnMechanical2Pump()
            AVPLib.Log.coreLogger.Info("Enter TurnOnMechanical2Pump")
            Try
                trdMechanicalPump2 = New Thread(AddressOf TurnOnMechanicalPump2Proc)
                m_EventStopThread.Reset()
                trdMechanicalPump2.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOnMechanical2Pump")
        End Sub
        Private Sub TurnOnMechanicalPump2Proc()
            AVPLib.Log.coreLogger.Info("Enter TurnOnMechanica2Pump1Proc")
            Try
                Dim mechanicalpump As Boolean = Me.SafetyTurnOnMechanicalPump(Equipments.RoughPumpMachine2.ToString)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOnMechanica2Pump1Proc")
        End Sub
        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2023-04-19</date>
        ''' </author>
        ''' <summary>
        ''' SafetyTurnOnOffMechanicalPump1
        ''' </summary>
        Private Function SafetyTurnOnMechanicalPump(ByVal strRoughPumpName As String) As Boolean
            Try
                Dim strErrMsg As String = String.Empty
                Dim bOverideMode As Boolean = IIf(m_objTransferModule.OverideModeStatus = Equipment.WorkingStatuses.On, False, True)
                strErrMsg = TMCryoUtility.OpenCloseMechanicalPump(Me.EquipmentName, strRoughPumpName, True, bOverideMode)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg)
                    Return False
                End If

                'Mechanical pump serial
                'wait for serial MP connect
                strErrMsg = WaitMechanicalPumpSerialTurnOn(strRoughPumpName, m_EventStopThread)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg)
                    Return False
                End If

                ' turn on mechanical pump
                strErrMsg = TMCryoUtility.TurnOnMechanicalPumpSerial(strRoughPumpName)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg)
                    Return False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return True
        End Function
        Private Function SafetyTurnOffMechanicalPump(ByVal strRoughPumpName As String) As Boolean
            Try
                Dim strErrMsg As String = String.Empty
                Dim bOverideMode As Boolean = IIf(m_objTransferModule.OverideModeStatus = Equipment.WorkingStatuses.On, False, True)

                m_EventStopThread.Set()

                strErrMsg = TMCryoUtility.OpenCloseMechanicalPump(Me.EquipmentName, strRoughPumpName, False, bOverideMode)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg)
                    Return False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return True
        End Function
        Private Function WaitMechanicalPumpSerialTurnOn(ByVal strRoughPumpName As String, ByVal abortedEvent As Threading.ManualResetEvent) As String
            Dim strErrMsg As String = String.Empty
            Try
                If strRoughPumpName = Equipments.RoughPumpMachine1.ToString AndAlso RobotConfigurationValues.MPUMP1_SERIAL_VISIBLE OrElse
                                            strRoughPumpName = Equipments.RoughPumpMachine2.ToString AndAlso RobotConfigurationValues.MPUMP2_SERIAL_VISIBLE Then
                    ' show waiting MP
                    Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetEquipment(strRoughPumpName)
                    roughpumpMachine.WaitingMPOn = ConstEnum.STR_WaitingMPOn
                    'wait for serial MP connect
                    Utils.ShowStatusMessage("Wait For Mechanical Pump Connected " & ConstEnum.MPCommunicationTimeOut & "s Timeout")
                    If Not Utils.WaitOnCondition(AddressOf TMCryoUtility.IsMPumpCommunicationCond, (ConstEnum.MPCommunicationTimeOut * 1000), abortedEvent, strRoughPumpName) Then
                        roughpumpMachine.WaitingMPOn = String.Empty
                        If abortedEvent.WaitOne(0, True) Then
                            strErrMsg = "User Abort Turn On Mechanical Pump."
                            Return strErrMsg
                        End If
                        strErrMsg = "Failed To Wait For Mechanical Pump Connected."
                        Return strErrMsg
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return strErrMsg
        End Function
        Private Sub SafetyCloseIsolationValve(ByVal message As String)
            Try
                Dim strErrorMsg As String = String.Empty
                Dim strSplitValveNo As String() = message.Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)

                'override mode = true
                If (m_objTransferModule IsNot Nothing AndAlso m_objTransferModule.OverideModeStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    strErrorMsg = ChamberUtility.OpenCloseSlitValve(Me.EquipmentName, False, strSplitValveNo(0))
                Else 'override mode = false
                    Dim objRobot As Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString)
                    If (objRobot IsNot Nothing) Then
                        If (objRobot.IsCommunicating) Then
                            Dim checkRobotRetract As Boolean = objRobot.IsRetracted AndAlso objRobot.IsReallyRetracted
                            If checkRobotRetract = False Then
                                Dim strCurrentStation As String = GetStationOfSlitValve(message)
                                If (objRobot.CurrentPosition = Positions.Original OrElse
                                objRobot.CurrentPosition = Positions.Unknown OrElse
                                IsRobotAtStation(message)) Then
                                    strErrorMsg = String.Format(ContainerData.GetMessageText("RobotWasNotRetract"), strCurrentStation)
                                Else
                                    strErrorMsg = ChamberUtility.OpenCloseSlitValve(Me.EquipmentName, False, strSplitValveNo(0))
                                End If
                            Else
                                strErrorMsg = ChamberUtility.OpenCloseSlitValve(Me.EquipmentName, False, strSplitValveNo(0))
                            End If
                        Else
                            strErrorMsg = String.Format(ContainerData.GetMessageText("EquipmentDisconnect"), objRobot.Name)
                        End If
                    End If
                End If

                'TODO: Check the result here and raise the Alarm if need
                If strErrorMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrorMsg)
                    Exit Try
                End If

                '[KhoiHa- 05/20/2014]ALL system running kepware or devicenet or other platform. 
                'When user or sequence open/close isolation valve and failed, we must put both open/close RO to false. 
                'This will prevent isolation valve open or close upon hardware is repair. We will confirm this in the next meeting.
                UnknownIsolationValveIfOpenCloseFailed(strSplitValveNo(0), False)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-05-21</date>
        ''' </author>
        ''' <summary>

        ''' [KhoiHa- 05/20/2014]ALL system running kepware or devicenet or other platform. 
        ''' When user or sequence open/close isolation valve and failed, we must put both open/close RO to false. 
        ''' This will prevent isolation valve open or close upon hardware is repair. We will confirm this in the next meeting.

        ''' UnknownIsolationValveIfOpenCloseFailed
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub UnknownIsolationValveIfOpenCloseFailed(ByVal strSplitValveName As String, ByVal isOpen As Boolean)
            Try
                Dim tmIsoValveThread As TMIsolationValveThread = m_hashTableIsoValveThread.Item(strSplitValveName)
                If tmIsoValveThread IsNot Nothing Then
                    tmIsoValveThread.SplitValveName = strSplitValveName
                    tmIsoValveThread.IsOpen = isOpen

                    If Not tmIsoValveThread.IsStoping() Then
                        tmIsoValveThread.TerminateAndWait()
                    End If
                    tmIsoValveThread.Start()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Private Function IsRobotAtStation(ByVal SlitValveName As String) As Boolean
            Dim blResult As Boolean = False
            Try
                Dim objRobot As Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString)
                If (objRobot Is Nothing) Then
                    Return True
                End If

                Select Case SlitValveName
                    Case ConstEnum.ChangeSlitValvePM1Off
                        If (objRobot.CurrentPosition = ConstEnum.Positions.Chamber1 OrElse
                                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber1_Extract OrElse
                                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber1_Wafer_Extract OrElse
                                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber1_Wafer) Then
                            blResult = True
                        End If
                    Case ConstEnum.ChangeSlitValvePM2Off
                        If (objRobot.CurrentPosition = ConstEnum.Positions.Chamber2 OrElse
                                                                objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber2_Extract OrElse
                                                                objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber2_Wafer_Extract OrElse
                                                                objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber2_Wafer) Then
                            blResult = True
                        End If
                    Case ConstEnum.ChangeSlitValvePM3Off
                        If (objRobot.CurrentPosition = ConstEnum.Positions.Chamber3 OrElse
                                                                objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber3_Extract OrElse
                                                                objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber3_Wafer_Extract OrElse
                                                                objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber3_Wafer) Then
                            blResult = True
                        End If
                    Case ConstEnum.ChangeSlitValveLLAOff
                        If (objRobot.CurrentPosition = ConstEnum.Positions.LoadLockA OrElse
                            objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_LLA_Extract OrElse
                            objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_LLA_Wafer_Extract OrElse
                            objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_LLA_Wafer) Then
                            blResult = True
                        End If
                    Case Else

                End Select

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Private Function GetStationOfSlitValve(ByVal slitValveName) As String
            Dim strStationName As String = String.Empty
            Try
                Select Case slitValveName
                    Case ConstEnum.ChangeSlitValvePM1Off
                        strStationName = Utils.chamberID2ChamberName(ConstEnum.Equipments.Chamber1.ToString())
                    Case ConstEnum.ChangeSlitValvePM2Off
                        strStationName = Utils.chamberID2ChamberName(ConstEnum.Equipments.Chamber2.ToString())
                    Case ConstEnum.ChangeSlitValvePM3Off
                        strStationName = Utils.chamberID2ChamberName(ConstEnum.Equipments.Chamber3.ToString())
                    Case ConstEnum.ChangeSlitValveLLAOff
                        strStationName = ConstEnum.Equipments.LoadLockA.ToString()
                    Case Else
                End Select

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return strStationName
        End Function


#Region "Online"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Online
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Online()
            AVPLib.Log.coreLogger.Info("Enter Online")
            Try
                trdToolOnline = New Thread(AddressOf OnlineProc)
                m_EventStopThread.Reset()
                trdToolOnline.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Online")
        End Sub

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-05-27</date>
        ''' </author>
        ''' <summary>
        ''' Offline
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Offline()
            AVPLib.Log.coreLogger.Info("Enter Offline")
            Try
                Dim Online As Boolean = False
                Me.RaiseFinishOnline(Online)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Offline")
        End Sub

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Thread Online
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub OnlineProc()
            AVPLib.Log.coreLogger.Info("Enter OnlineProc")
            Try
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : A NEW THREAD BORN FOR PROCESSING ONLINE.")

                Dim strErrorMsg As String = String.Empty
                If (CheckPressureCommunication(strErrorMsg)) Then
                    Dim Online As Boolean = Me.CheckOnline()
                    Me.RaiseFinishOnline(Online)
                Else
                    Me.ThrowAlarm(strErrorMsg)
                    Me.m_EventStopThread.WaitOne(1000, True)
                    Me.RaiseFinishOnline(False)
                End If

                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : THE THREAD PROCESSING ONLINE IS OVER.")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OnlineProc")
        End Sub

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-05</date>
        ''' </author>
        ''' <summary>
        ''' LLBOnline
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CheckOnline() As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckOnline")
            Try
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Transfer Module is available...") ''Tin.Tran changed status message
                Dim transferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                'Is Hivac Valve Open
                If m_EventStopThread.WaitOne(0, True) Then
                    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                    Utils.ShowStatusMessage(TM_OFFLINE)
                    Return False
                End If

                'hivac installed -> check TM hivac status
                If RobotConfigurationValues.TM_HIVAC_INSTALLED AndAlso
                (Not transferModule.HiVacValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    If m_IsShowAlarmWhenOnline Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("HivacValveDidNotOpen"), AVPLib.ConstEnum.TM_STR) & GO_ONLINE_FAILED)
                    End If
                    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                    Utils.ShowStatusMessage(TM_OFFLINE)
                    Return False
                End If
                'Is IG On
                If m_EventStopThread.WaitOne(0, True) Then
                    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                    Utils.ShowStatusMessage(TM_OFFLINE)
                    Return False
                End If
                If Not transferModule.IGStatus = DataManagerment.Equipment.WorkingStatuses.On Then
                    If (m_IsShowAlarmWhenOnline) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("IGDidNotOn"), AVPLib.ConstEnum.TM_STR) & GO_ONLINE_FAILED)
                    End If
                    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                    Utils.ShowStatusMessage(TM_OFFLINE)
                    Return False
                End If
                'Is Base Pressure Reach?
                If m_EventStopThread.WaitOne(0, True) Then
                    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                    Utils.ShowStatusMessage(TM_OFFLINE)
                    Return False
                End If
                Dim Pressure As Double = ContainerData.GetPressureConfig(Me.EquipmentName)
                ' Base Pressure Reach means <= a base value.
                If Not (transferModule.Pressure <= Pressure) Then
                    If (m_IsShowAlarmWhenOnline) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("BasePressureDidNotReach"), AVPLib.ConstEnum.TM_STR) & GO_ONLINE_FAILED)
                    End If
                    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                    Utils.ShowStatusMessage(TM_OFFLINE)
                    Return False
                End If
                AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                Utils.ShowStatusMessage("Transfer Module is available")
                Return True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckOnline")
            Return False
        End Function
#End Region

#Region "Auto Vent"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' AutoVent
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub StopAutoVent()
            AVPLib.Log.coreLogger.Info("Enter StopAutoVent")
            m_EventStopThread.Set()
            AVPLib.Log.coreLogger.Info("Leave StopAutoVent")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' AutoVent
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub AutoVent()
            AVPLib.Log.coreLogger.Info("Enter AutoVent")

            trdAutoVent = New Thread(AddressOf AutoVentProc)
            m_EventStopThread.Reset()
            trdAutoVent.Start()


            AVPLib.Log.coreLogger.Info("Leave AutoVent")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Thread AutoVent
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub AutoVentProc()
            AVPLib.Log.coreLogger.Info("Enter AutoVentProc")
            Try
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : A NEW THREAD BORN FOR PROCESSING AUTO VENT.")

                Dim strErrorMsg As String = String.Empty
                If (CheckPressureCommunication(strErrorMsg)) Then
                    If Utils.CheckRateOfRaiseIsRunning(Me.EquipmentName, STR_SEQUENCE_AUTO_VENT) Then
                        Dim AutoVent As Boolean = Me.CheckAutoVent(STR_SEQUENCE_AUTO_VENT)
                    End If
                Else
                    Me.ThrowAlarm(strErrorMsg, ConstEnum.GEM_ALARM_SUB_VENT_FAILED)
                    m_EventStopThread.WaitOne(1000, True)
                End If

                Me.RaiseFinishAutoVent()
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : A NEW THREAD BORN FOR PROCESSING AUTO VENT IS OVER.")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave AutoVentProc")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Raise Finish AutoVent
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub RaiseFinishAutoVent()
            AVPLib.Log.coreLogger.Info("Enter RaiseFinishAutoVent")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()

                ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("AutoVentStatus")

                m_blnIsVentRunning = False
                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseFinishAutoVent")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-05</date>
        ''' </author>
        ''' <summary>
        ''' LLAAutoVent
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CheckAutoVent(ByVal strSequenceName As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter CheckAutoVent")

            Try
                Dim strCheckAutoVentFailed As String = ". Auto Vent failed "
                Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim strErrMsg As String = String.Empty
                Dim strGemSubVentAlarmName As String = AVPLib.ConstEnum.GEM_ALARM_SUB_VENT_FAILED
                Dim blnCloseAllValve As Boolean = False
                Dim Milliseconds As Integer = 0

                m_blnIsVentRunning = True
                Dim strEquipmentName As String = "TM"
                Utils.ShowStatusMessage(" Transfer Module is venting...", strSequenceName)
                If objTransferModule Is Nothing Then
                    AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
                    Return False
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''    
                ' Should close Fast Rough Valve when start Venting.
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If objTransferModule.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On Then
                    If Not StepCloseTMRoughValve(strErrMsg, True, TM_VENT_ABORTED, m_EventStopThread, strSequenceName) Then
                        GoTo Exit_FUNCTION
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close All Slit valve.
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseAllIsolationValve(strErrMsg, True, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Turn off TM IG and Wait for IG off
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOffTMIG_Wait4IGOff(strErrMsg, True, TM_VENT_ABORTED, m_EventStopThread, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Close TM HiVac valve and Wait Hivac Close
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseTMHivac_Wait4HivacClose(strErrMsg, True, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Wait 2s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = Integer.Parse(VentPumdownLib.TMVentConfig.TMDelay2s)
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Wait 2s", strSequenceName)
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open TM Fast Vent(valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenTMFastVent(strErrMsg) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait until TM CG > 760 torr.  Max wait 5 min.
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = VentPumdownLib.TMVentConfig.TMVentTimeOut * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting TM CG reach " & VentPumdownLib.TMVentConfig.TMVentPressure.ToString & " Torr with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                If Not Utils.WaitOnCondition(AddressOf IsTMCGReachAtmosphericPressureCond, AddressOf IsTMCGDisconnected, Milliseconds, m_EventStopThread) Then
                    If Not m_EventStopThread.WaitOne(0, True) Then
                        If (IsTMCGDisconnected()) Then
                            strErrMsg = (Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED)
                        Else
                            'Me.ThrowAlarm(ConstEnum.TM_STR + String.Format(" TM CG <= {0} Torr.  Max wait {1} minutes.", VentPumdownLib.TMVentConfig.TMVentPressure, TimeSpan.FromMilliseconds(Milliseconds).Minutes) & strCheckAutoVentFailed, strGemSubVentAlarmName)
                            Me.ThrowAlarm(String.Format("Failed to wait for CG Pressure reach {0} Torr. Auto Vent failed!", VentPumdownLib.TMVentConfig.TMVentPressure))
                        End If

                    End If
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                'Dat Cao add sleep func, continue to vent for another 10s.
                'Thread.Sleep(VentPumdownLib.TMVentConfig.TMVent_Delay_Time)
                Milliseconds = VentPumdownLib.TMVentConfig.TMVent_Delay_Time * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Continue to vent. Wait for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                Utils.ShowStatusMessage("Transfer Module: Venting completed", strSequenceName)
                Me.CloseActiveVent()
                AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
                Return True

Exit_FUNCTION:

                If blnCloseAllValve Then
                    CloseActiveVent()
                End If

                If (m_EventStopThread.WaitOne(0, True)) Then
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ":" & VENT_ABORTED, strSequenceName)
                Else
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg & strCheckAutoVentFailed, strGemSubVentAlarmName)
                        Utils.ShowStatusMessage(TM_VENT_FAILED, strSequenceName)
                    End If
                End If

                AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
                Return False
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Utils.ShowStatusMessage(TM_VENT_FAILED, strSequenceName)
            AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
            Return False
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-02-05</date>
        ''' </author>
        ''' <summary>
        ''' Close Active Vent
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CloseActiveVent()
            Dim transferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Dim strErrMsg As String = String.Empty
            AVPLib.Log.seqLogger.Info("Enter CloseActiveVent")
            Dim strGemSubVentAlarmName As String = AVPLib.ConstEnum.GEM_ALARM_SUB_VENT_FAILED

            If Me.m_blnOpenTMVent Then

                'TODO: Check the result here and raise the Alarm if need
                strErrMsg = TMCryoUtility.CloseVentValve(ConstEnum.Equipments.CassettesModule.ToString())
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg, strGemSubVentAlarmName)
                    AVPLib.Log.seqLogger.Info("Leave CloseActiveVent")
                    Exit Sub
                End If

                Me.m_blnOpenTMVent = False

                ''Van Le remove
                'Wait 2 sec. 
                'Threading.Thread.Sleep(VentPumdownLib.TMVentConfig.TMDelay2s)

                'If Not transferModule.FastVentValveStatus = DataManagerment.Equipment.WorkingStatuses.Off Then
                '    'Utils.ThrowAlarm(Me.EquipmentName + " Verify TM Fast Vent valve was not Off")
                '    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLFastVentWasNotClose"), AVPLib.ConstEnum.TM_STR))
                'Else
                '    Me.m_blnOpenTMVent = False
                'End If

            End If
            AVPLib.Log.seqLogger.Info("Leave CloseActiveVent")
        End Sub

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' Close Active Vent
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCheckTMWaterPump(ByVal objTMWPController As WaterPumpController, ByRef strErrMsg As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCheckTMWaterPump")
            Try
                If objTMWPController.IsTMWaterPumpTLessThanTConfig() Then
                    strErrMsg = String.Format(ContainerData.GetMessageText("TMWPIsLessThanTConfig"), AVPLib.ConstEnum.TM_WATER_PUMP_T_CONFIG)
                    AVPLib.Log.seqLogger.Info("Leave StepCheckTMWaterPump")
                    Return False
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''    
                ' Check TM water pump is on.
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If objTMWPController.IsTMWaterPumpOn() Then
                    strErrMsg = String.Format(ContainerData.GetMessageText("TMWPIsOn"))
                    AVPLib.Log.seqLogger.Info("Leave StepCheckTMWaterPump")
                    Return False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCheckTMWaterPump")
            Return True
        End Function
#End Region

#Region "Pump Down"
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2014-03-03</date>
        ''' </author>
        ''' <summary>
        ''' StopPumpDown
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StopPumpDownAndPDCSequencesIfCan()
            AVPLib.Log.coreLogger.Info("Enter StopPumpDownAndPDCSequencesIfCan")
            Try


                If (m_objTransferModule IsNot Nothing AndAlso (m_objTransferModule.PumpDown_Curve_Status = Equipment.WorkingStatuses.On)) Then
                    Me.StopPumpdownCurve()
                Else
                    If (m_blnIsPumpDownRunning) Then
                        Me.StopPumpDown()
                    End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave StopPumpDownAndPDCSequencesIfCan")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' StopPumpDown
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StopPumpDown()
            AVPLib.Log.coreLogger.Info("Enter StopPumpDown")
            RaiseFinishPumpDown()
            m_EventStopThread.Set()
            AVPLib.Log.coreLogger.Info("Leave StopPumpDown")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' PumpDown
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PumpDown()
            AVPLib.Log.coreLogger.Info("Enter PumpDown")
            Try
                Dim objTMPumpPackageCtrl As PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
                If objTMPumpPackageCtrl IsNot Nothing AndAlso (objTMPumpPackageCtrl.DisplayName = ConstEnum.Equipments.TMCryo.ToString()) Then
                    Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(objTMPumpPackageCtrl.EquipmentName.ToString())
                    If objCryo IsNot Nothing AndAlso objCryo.RegenStatus = Equipment.WorkingStatuses.On Then
                        ThrowAlarm("Can Not Start TM PumpDown Because Cryo Is Regening.")
                        StopPumpDown()
                        Exit Try
                    End If
                End If

                trdPumpDown = New Thread(AddressOf PumpDownProc)
                m_EventStopThread.Reset()
                trdPumpDown.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave PumpDown")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Thread PumpDown
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub PumpDownProc()
            AVPLib.Log.coreLogger.Info("Enter PumpDownProc")
            Try
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : A NEW THREAD BORN FOR PROCESSING AUTO PUMPDOWN.")
                RaiseStartPumpDown()
                Dim PumpDown As Boolean = Me.CheckPumpDown()
                RaiseFinishPumpDown()
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : THE THREAD PROCESSING AUTO PUMPDOWN IS OVER.")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave PumpDownProc")
        End Sub
        Private Sub RaiseStartPumpDown()
            AVPLib.Log.coreLogger.Info("Enter RaiseStartPumpDown")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()

                ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.On)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("PumpDownStatus")

                m_blnIsPumpDownRunning = False
                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseStartPumpDown")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' RaiseFinishPumpDown
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub RaiseFinishPumpDown()
            AVPLib.Log.coreLogger.Info("Enter RaiseFinishPumpDown")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()

                ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("PumpDownStatus")

                m_blnIsPumpDownRunning = False
                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseFinishPumpDown")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-28</date>
        ''' </author>
        ''' <summary>
        ''' RaiseStart auto PumpDown
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RaiseStartAutoPumpDown()
            AVPLib.Log.coreLogger.Info("Enter RaiseFinishPumpDown")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()

                ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.On)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("PumpDownStatus")

                m_blnIsPumpDownRunning = True
                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseFinishPumpDown")
        End Sub
        Public Function IsTMHivacCloseCond() As Boolean
            If (RobotConfigurationValues.TM_HIVAC_INSTALLED) Then
                Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Return (Equipment.WorkingStatuses.Off = objTransferModule.HiVacValveStatus)
            Else 'alway return true if hivac isnot installed
                Return True
            End If
        End Function

        Public Function IsTurboOnCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            If objTransferModule Is Nothing Then
                Return False
                'loadlock hivac installed
            ElseIf (objTransferModule IsNot Nothing AndAlso RobotConfigurationValues.TMTURBO_VISIBLE) Then
                Dim objPumppackage As Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.TMPumpPackage.ToString)
                Return objPumppackage.TurboStatus
            Else ' loadlock hivac is not installed 
                Return True
            End If
        End Function

        ''' <author>
        '''    	<name> Dua Tran  </name>
        '''    	<date> 2017-04-14</date>
        ''' </author>
        ''' <summary>
        ''' Condion turbo off
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsTurboOffCond() As Boolean
            Dim blResult As Boolean = False
            Try
                Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                If objTransferModule Is Nothing Then
                    Return False
                    'loadlock hivac installed
                ElseIf (objTransferModule IsNot Nothing AndAlso RobotConfigurationValues.TMTURBO_VISIBLE) Then
                    Dim objPumppackage As Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.TMPumpPackage.ToString)
                    Return objPumppackage.TurboStatus = False
                Else ' loadlock hivac is not installed 
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function

        Public Function IsTMHivacOpenCond() As Boolean
            If (RobotConfigurationValues.TM_HIVAC_INSTALLED) Then
                Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Return (Equipment.WorkingStatuses.On = objTransferModule.HiVacValveStatus)
            Else 'alway return true if hivac isnot installed
                Return True
            End If
        End Function

        Public Function IsTMIGOnCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (Equipment.WorkingStatuses.On = objTransferModule.IGStatus)
        End Function

        Public Function IsTMIGOffCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (Equipment.WorkingStatuses.Off = objTransferModule.IGStatus)
        End Function

        Public Function IsTMIGFilament1Cond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (objTransferModule.SwitchIGFilament = 1)
        End Function

        Public Function IsTMIGFilament2Cond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (objTransferModule.SwitchIGFilament = 2)
        End Function

        Public Function IsTMRoughValveCloseCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (Equipment.WorkingStatuses.Off = objTransferModule.FastRoughValveStatus)
        End Function

        Public Function IsTMRoughValveOpenCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (Equipment.WorkingStatuses.On = objTransferModule.FastRoughValveStatus)
        End Function

        Private Function IsTMVentValveCloseCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (Equipment.WorkingStatuses.Off = objTransferModule.FastVentValveStatus)
        End Function

        Public Function IsTMVentValveOpenCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (Equipment.WorkingStatuses.On = objTransferModule.FastVentValveStatus)
        End Function

        Public Function IsTMTurboForelineValveOpenCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (Equipment.WorkingStatuses.On = objTransferModule.TurboForeLineValveStatus)
        End Function

        Public Function IsTMTurboForelineValveCloseCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (Equipment.WorkingStatuses.Off = objTransferModule.TurboForeLineValveStatus)
        End Function

        Private Function IsTMCGReachCrossOverPressureAndCGRelayOnCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (objTransferModule.CG <= VentPumdownLib.TMPumpdownConfig.TMRoughPressure) And (Equipment.WorkingStatuses.On = objTransferModule.VacSwitchStatus)
        End Function
        'TM CG Disconnect
        Public Function IsTMCGDisconnected() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (objTransferModule.CG_Communication = Equipment.WorkingStatuses.Off)
        End Function
        'TM IG Disconnect
        Public Function IsTMIGDisconnected() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (objTransferModule.IG_Communication = Equipment.WorkingStatuses.Off)
        End Function
        'TM Forline Disconnect
        Public Function IsTMTurboForelineCGDisconnected() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (objTransferModule.TurboForelineCG_Communication = Equipment.WorkingStatuses.Off)
        End Function

        Private Function IsTurboForelineCGRealyOnCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (Equipment.WorkingStatuses.On = objTransferModule.TurboForelineCGRelay)
        End Function
        'TM MP Disconnect
        Public Function IsTMMechanicalPumpCGDisconnected() As Boolean
            Dim objMechanicalPump As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)
            If (objMechanicalPump IsNot Nothing AndAlso objMechanicalPump.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                Return True
            End If
        End Function
        'TM MP CG Relay On
        Public Function IsTMMechanicalPumpCGReachCrossOverPressureAndCGRelayOnCond() As Boolean
            Dim objMechanicalPump As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)

            If (objMechanicalPump IsNot Nothing) Then
                Return (objMechanicalPump.VacSwitchStatus = Equipment.WorkingStatuses.On AndAlso objMechanicalPump.CG <= VentPumdownLib.TMPumpdownConfig.TMMechanicalPumpOnPressure)
            End If
            Return False
        End Function
        'TM MP CG Relay Off
        Public Function IsTMMechanicalPumpCGRelayOff() As Boolean
            Dim objMechanicalPump As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)

            If (objMechanicalPump IsNot Nothing) Then
                Return (objMechanicalPump.VacSwitchStatus = Equipment.WorkingStatuses.Off AndAlso objMechanicalPump.CG >= VentPumdownLib.TMPumpdownConfig.TMMechanicalPumpOnPressure)
            End If
            Return False
        End Function
        'TM MP status On
        Public Function IsTMMechanicalPumpOnCond() As Boolean
            Dim bStatusMechnical As Boolean = False
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Dim objMechanicalPump As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)

            If (objMechanicalPump IsNot Nothing) Then
                If (objMechanicalPump.Name = ConstEnum.Equipments.RoughPumpMachine1.ToString) Then
                    bStatusMechnical = IIf(objTransferModule.RoughPump1Status = Equipment.WorkingStatuses.On, True, False)

                ElseIf (objMechanicalPump.Name = ConstEnum.Equipments.RoughPumpMachine2.ToString) Then
                    bStatusMechnical = IIf(objTransferModule.RoughPump2Status = Equipment.WorkingStatuses.On, True, False)
                End If
            End If
            Return bStatusMechnical
        End Function
        'TM MP name
        Public Function NameTMMechanicalPump() As String
            Dim strNameMP As String = String.Empty
            Dim objMechanicalPump As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)

            If (objMechanicalPump IsNot Nothing) Then
                strNameMP = objMechanicalPump.Name
            End If
            Return strNameMP
        End Function
        'TM MP On
        Public Function IsTMMechanicalPumpOn() As Boolean
            Return (IsTMMechanicalPumpCGDisconnected() = False AndAlso IsTMMechanicalPumpCGReachCrossOverPressureAndCGRelayOnCond() AndAlso IsTMMechanicalPumpOnCond())
        End Function

        Public Function CheckPressureCommunication(Optional ByRef ErrorMsg As String = "") As Boolean
            Dim blResult As Boolean = False
            Try
                If (RobotConfigurationValues.TM_HIVAC_INSTALLED AndAlso IsTMIGDisconnected()) Then
                    ErrorMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & IG_DISCONNECTED
                    Exit Try
                End If

                If (IsTMCGDisconnected()) Then
                    ErrorMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED
                    Exit Try
                End If

                If (RobotConfigurationValues.TMTURBO_VISIBLE AndAlso IsTMTurboForelineCGDisconnected()) Then
                    ErrorMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & ": Turbo Foreline CG is disconnected."
                    Exit Try
                End If

                If (IsTMMechanicalPumpCGDisconnected()) Then
                    ErrorMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & MECHANICAL_PUMP_CG_DISCONNECTED
                    Exit Try
                End If

                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Private Function IsLLPumpDownRunning() As Boolean
            Dim objLLAController As LoadLockController = ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString())
            Dim bResult As Boolean = True
            If objLLAController IsNot Nothing AndAlso objLLAController.IsPumpDownSeqRunning Then
                bResult = False
            End If
            'If objLLAController IsNot Nothing AndAlso objLLBController IsNot Nothing Then
            '    Return objLLAController.IsPumpDownSeqRunning And objLLBController.IsPumpDownSeqRunning
            'Else
            'End If
            Return bResult
        End Function

        Public Function IsTMCGReachAtmosphericPressureCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (objTransferModule.CG >= VentPumdownLib.TMVentConfig.TMVentPressure) And (Equipment.WorkingStatuses.Off = objTransferModule.VacSwitchStatus)
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-12-5</date>
        ''' </author>
        ''' <summary>
        ''' Check TM Reach cross over and CG relay on and pumppackage ok
        ''' </summary>
        ''' <remarks></remarks>
        Private Function IsOK_2OpenHivacCond(ByRef strErrMsg) As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            If ObjectPumpPackage IsNot Nothing Then
                Return IsTMCGReachCrossOverPressureAndCGRelayOnCond() And ObjectPumpPackage.IsPumpPackageOK(strErrMsg)
            End If
            Return False
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2013-12-3</date>
        ''' </author>
        ''' <summary>
        ''' if (CG*0.9) < Cross Over SP,  hivac is allow to open without alarm
        ''' </summary>
        ''' <remarks></remarks>
        Private Function IsCGPressureOK2OpenHivacCond(ByRef strErrMsg) As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            If ObjectPumpPackage IsNot Nothing Then
                Return ((objTransferModule.CG * m_CGMultiFactor) <= VentPumdownLib.TMPumpdownConfig.TMRoughPressure) And ObjectPumpPackage.IsPumpPackageOK(strErrMsg)
            End If
            Return False
        End Function

        Private Function IsTurboTurnOnCond() As Boolean
            Dim strErrMsg As String = String.Empty
            If ObjectPumpPackage IsNot Nothing Then
                Return ObjectPumpPackage.IsPumpPackageOK(strErrMsg)
            End If
            Return False
        End Function

        Public Sub ProcessSafetyInterlock(ByVal brelayForelineOff As Boolean)
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            ' Offline if it's Online.
            If objTransferModule.ControlStatus = Equipment.ControlStatuses.ONLINE Then
                RaiseFinishOnline(False)
            End If
            '
            Dim strErrMsg As String = String.Empty
            'CG relay or disconnect of Foreline
            If brelayForelineOff Then
                'close foreline valve
                If (objTransferModule.TurboForeLineValveStatus <> Equipment.WorkingStatuses.Off) Then
                    strErrMsg = TMCryoUtility.CloseTMTurboForeLineValve(Me.EquipmentName)
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg)
                    End If
                End If

                'turn off turbo
                Dim objTurboController As TurboController = ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString)
                If objTurboController IsNot Nothing AndAlso objTurboController.TurnOff() Then

                    If Not Utils.WaitOnCondition(AddressOf IsTurboOffCond, VentPumdownLib.TMPumpdownConfig.TMTurnOffTurboTimeOut * 1000, Nothing) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLTurboWasNotOff"), Me.EquipmentName))
                    End If
                End If
            End If

            'DO NOT INSTALL HIVAC -> NOT HAVE IG
            If (RobotConfigurationValues.TM_HIVAC_INSTALLED AndAlso objTransferModule.IGStatus <> Equipment.WorkingStatuses.Off) Then
                strErrMsg = TMCryoUtility.TurnOffIG(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg)
                Else
                    'Verify IG is Off
                    If Not Utils.WaitOnCondition(AddressOf IsTMIGOffCond,
                                                  VentPumdownLib.TMPumpdownConfig.IGOnOffTimeOut * 1000,
                                                  Nothing) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("TMIGWasNotOff"),
                                             AVPLib.ConstEnum.TM_STR))
                    End If
                End If
            End If

            'close hivac
            If (RobotConfigurationValues.TM_HIVAC_INSTALLED AndAlso objTransferModule.HiVacValveStatus <> Equipment.WorkingStatuses.Off) Then
                strErrMsg = TMCryoUtility.CloseHiVacValve(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg)
                Else
                    If Not Utils.WaitOnCondition(AddressOf IsTMHivacCloseCond, VentPumdownLib.TMPumpdownConfig.TMHivacOpenCloseTimeOut * 1000, Nothing) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("HivacValveDidNotClose"), AVPLib.ConstEnum.TM_STR))
                    End If
                End If
            End If


        End Sub

        ''' <author>Hai Tran</author>
        ''' <date>2017-05-09</date>
        ''' <summary>
        ''' Turn Off TM IG.
        ''' </summary>
        Public Sub TurnOffIG(ByVal terminateEvent As ManualResetEvent)
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)

            If (RobotConfigurationValues.TM_HIVAC_INSTALLED AndAlso objTransferModule.IGStatus <> Equipment.WorkingStatuses.Off) Then
                Dim strErrMsg As String = TMCryoUtility.TurnOffIG(Me.EquipmentName)

                If Not String.IsNullOrEmpty(strErrMsg) Then
                    Me.ThrowAlarm(strErrMsg)
                Else
                    'Verify IG is Off
                    If Not Utils.WaitOnCondition(AddressOf IsTMIGOffCond,
                                                  VentPumdownLib.TMPumpdownConfig.IGOnOffTimeOut * 1000,
                                                  terminateEvent) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("TMIGWasNotOff"),
                                             AVPLib.ConstEnum.TM_STR))
                    End If
                End If
            End If
        End Sub
        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2022-08-02</date>
        ''' </author>
        ''' <summary>
        ''' Close Foreline Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CloseTMTurboForeline(ByVal terminateEvent As ManualResetEvent)
            Try
                'send to device
                Dim strErrMsg As String = TMCryoUtility.CloseTMTurboForeLineValve(Me.EquipmentName)
                If Not String.IsNullOrEmpty(strErrMsg) Then
                    Me.ThrowAlarm(strErrMsg)
                    Exit Try
                End If

                'wait for device reply
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMTurboForelineOpenCloseTimeOut * 1000
                If Not WaitForTMTurboForelineValveClosed(Milliseconds, terminateEvent) Then
                    Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("TMForelineWasNotClose"), AVPLib.ConstEnum.TM_STR))
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-05</date>
        ''' </author>
        ''' <summary>
        ''' PumpDownSequence
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CheckPumpDown() As Boolean

            AVPLib.Log.coreLogger.Info("Enter CheckPumpDown")
            Try
                Dim strErrorMsg As String = String.Empty
                Dim strSequenceName = "[AUTO_PUMP_DOWN]"
                If (CheckPressureCommunication(strErrorMsg)) Then
                    If RobotConfigurationValues.TMCRYO_VISIBLE Then
                        Return PumpDownWithCryo(STR_SEQUENCE_AUTO_PUMPDOWN)
                    ElseIf RobotConfigurationValues.TMTURBO_VISIBLE Then
                        Return PumpDownWithTurbo(STR_SEQUENCE_AUTO_PUMPDOWN)
                    End If
                Else
                    Me.ThrowAlarm(strErrorMsg, ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    Me.m_EventStopThread.WaitOne(1000, True)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())

            End Try

            AVPLib.Log.coreLogger.Info("Leave CheckPumpDown")
            Return False
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-12-05</date>
        ''' </author>
        ''' <summary>
        ''' PumpDownSequence
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function PumpDownWithCryo(ByVal strSequenceName As String) As Boolean

            AVPLib.Log.seqLogger.Info("Enter PumpDownWithCryo")

            'Dim objRoughPumpMachine As DataManagerment.RoughPumpMachine = _
            '    CType(DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName), DataManagerment.RoughPumpMachine)

            Try
                Dim objTransferModule As DataManagerment.CassettesModule =
                                         DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim strErrMsg As String = String.Empty
                Dim blnCloseAllValve As Boolean = False
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMPumdown_Delay_Time * 1000
                '
                m_blnIsPumpDownRunning = True
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Pumpdown...", strSequenceName) ''Tin.Tran changed Status message 25/06/2012
                If ObjectRoughPumpMachine Is Nothing Then
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                    Return False
                End If

                'wait for make pumpdown highest priority 
                Dim timeout As Integer = VentPumdownLib.LLPumpdownConfig.LLPumpDownComplete * 1000
                If (ObjectRoughPumpMachine IsNot Nothing) AndAlso (Not ObjectRoughPumpMachine.WaitForMakePumpdownHighestPriority(Me.EquipmentName, m_EventStopThread, timeout)) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'STEP: Wait for Rough Pump PM Close if TM shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If RobotConfigurationValues.SHARED_MP_WITH_PM AndAlso
                    Not Utils.WaitForRoughtPMClose(TRANSFERMODULE_STR, strSequenceName, m_EventStopThread, VentPumdownLib.LLPumpdownConfig.RoughPumpPMTimeOut, strErrMsg, ObjectRoughPumpMachine) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'STEP: Close TM Vent(valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseTMVentValve(strErrMsg, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close TM Rough(valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseTMRoughValve(strErrMsg, False, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn On MP
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOnMechanicalPump(TM_PUMPDOWN_ABORTED, strErrMsg, m_EventStopThread, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close All Slit valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseAllIsolationValve(strErrMsg, False, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Is TM CG Reach Cross Over Pressure And Relay Is On
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If IsOK_2OpenHivacCond(strErrMsg) Then
                    GoTo POST_PUMP_DOWN
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim blIsHasCloseLLARoughValve As Boolean = False
                If Not Utils.CloseAllOtherRoughValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim blIsHasCloseLLAForelineValve As Boolean = False
                If Not Utils.CloseAllOtherForelineRoughValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn off TM IG
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOffTMIG_Wait4IGOff(strErrMsg, False, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close TM HiVac valve()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseTMHivac_Wait4HivacClose(strErrMsg, False, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait if LLx PumpDown Running
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCheckOtherRoughInUse(strErrMsg) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close LLx Rough Valve if LLx turbo not installed
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseLLRoughValve(strErrMsg, False, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Make Rough Line In Use And Check TM Mechanical Pump CG < 0.1 Torr.
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If ObjectRoughPumpMachine IsNot Nothing Then
                    If Not StepWaitMPPressure(strErrMsg, strSequenceName) Then
                        GoTo EXIT_FUNCTION
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close LL Foreline Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim bCloseLLForelineValve As Boolean = False

                Dim objLoadLock As LoadLockController = ControllerManager.GetController(LoadLockA_STR)
                If ObjectRoughPumpMachine.IsUsed(LoadLockA_STR) Then
                    ''check LLA
                    If objLoadLock IsNot Nothing Then
                        Dim blLLTurboInstall As Boolean = RobotConfigurationValues.LLA_TURBO_VISIBLE

                        If blLLTurboInstall AndAlso objLoadLock.IsLLTurboForelineValveOpenCond Then
                            If Not objLoadLock.StepCloseLLTurboForelineValve(strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                                blnCloseAllValve = True
                                GoTo EXIT_FUNCTION
                            End If
                            bCloseLLForelineValve = True
                        End If
                    End If
                End If

                If bCloseLLForelineValve Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Wait 5s
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Or_Close_Foreline
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                    If m_EventStopThread.WaitOne(Milliseconds, True) Then
                        blnCloseAllValve = True
                        GoTo EXIT_FUNCTION
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open TM Fast Rough(valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenTMRoughValve(strErrMsg, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait for CG <Cross over press and CG relay On. Max 15mins
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepWaitFastRoughPressure(strErrMsg, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                'Dat Cao add sleep func, continue to rough for another 10s.
                'Thread.Sleep(VentPumdownLib.TMPumpdownConfig.TMPumdown_Delay_Time)
                Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumdown_Delay_Time * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Continue to rough. Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName) ''Tin.Tran changed Status Message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    Me.CloseActivePumpDown()
                    Utils.ShowStatusMessage(TM_PUMPDOWN_ABORTED, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                    Return False
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close TM Fast Rough(valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseTMRoughValve(strErrMsg, False, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                'If bCloseLLForelineValve Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 5s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Or_Close_Foreline
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open LL Foreline Valve 
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                    Dim objPumppackage As Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAPumpPackage.ToString)
                    If (objPumppackage IsNot Nothing) AndAlso (objPumppackage.TurboUptoSpeed = True) Then
                        If objLoadLock IsNot Nothing AndAlso Not objLoadLock.StepOpenLLTurboForelineValve(strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                            blnCloseAllValve = True
                            GoTo EXIT_FUNCTION
                        End If
                    End If
                End If
                'End If

                ' TM Cryo Pressure < 15K ?
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(TM_PUMPDOWN_ABORTED, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                    Return False
                End If
                If Not IsCGPressureOK2OpenHivacCond(strErrMsg) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If
POST_PUMP_DOWN:
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open TM HiVacValve.
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenTMHivac(strErrMsg, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                blIsHasCloseLLARoughValve = (blIsHasCloseLLARoughValve And (Not IsLLARoughOnlyMode()))
                If Not Utils.OpenAllOtherRoughValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, False) Then
                    If (Not String.IsNullOrEmpty(strErrMsg)) Then
                        Me.ThrowAlarm(strErrMsg, ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not Utils.OpenAllOtherForelineValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, False) Then
                    If (Not String.IsNullOrEmpty(strErrMsg)) Then
                        Me.ThrowAlarm(strErrMsg, ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    End If
                End If

                ' Wait for 3s before make pumpdown low priority
                m_EventStopThread.WaitOne(3000, True)

                'Make pumpdown low priority
                If ObjectRoughPumpMachine IsNot Nothing Then
                    ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 15s
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Thread.Sleep(VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Hivac)
                Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Hivac
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName) ''Tin.Tran changed Status message 25/06/12
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    Me.CloseActivePumpDown()
                    Utils.ShowStatusMessage(TM_PUMPDOWN_ABORTED, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                    Return False
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait for CG Relay On
                'Thread.Sleep(VentPumdownLib.TMPumpdownConfig.IGOnDelay)
                'Turn on IG
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOnTMIG(strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = False
                    GoTo EXIT_FUNCTION
                End If
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Pumpdown completed", strSequenceName) ''Tin.Tran changed Status message 25/06/2012
                AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                Return True
EXIT_FUNCTION:
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                blIsHasCloseLLARoughValve = (blIsHasCloseLLARoughValve And (Not IsLLARoughOnlyMode()))
                Utils.OpenAllOtherRoughValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, False)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Utils.OpenAllOtherForelineValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, False)

                If (m_EventStopThread.WaitOne(0, True)) Then
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": " & PUMPDOWN_ABORTED, strSequenceName)
                Else
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        Utils.ShowStatusMessage(TM_PUMPDOWN_FAILED, strSequenceName)
                    End If
                End If

                If blnCloseAllValve Then
                    CloseActivePumpDown()
                End If
                AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                Return False
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If ObjectRoughPumpMachine IsNot Nothing Then
                    ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                    ObjectRoughPumpMachine.ReleaseRoughLineInUse(Me.EquipmentName)
                End If
            End Try
            Utils.ShowStatusMessage(TM_PUMPDOWN_FAILED, strSequenceName)
            AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
            Return False
        End Function
        Public Function IsLoadlockKeepOpenRoughValve() As Boolean
            Dim blResult As Boolean = False
            Dim objOtherLoadlock As LoadLock = Nothing

            Try
                objOtherLoadlock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)

                'ONLY ONE LL INSTALLED
                'ROUGH VALVE IS OPENED
                'HIVAC ISNOT INSTALLED
                If (objOtherLoadlock IsNot Nothing AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED = False _
                AndAlso (objOtherLoadlock.IsRoughInstalled AndAlso objOtherLoadlock.FastRoughValveStatus = Equipment.WorkingStatuses.On)) Then
                    blResult = True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-07-12</date>
        ''' </author>
        ''' <summary>
        ''' Close other Rough Valves
        ''' Only use this function when other rough valve is opened by other loadlock pump down with rough only
        ''' when pump down finished, rough valve is keep open
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseLLRoughValves(ByRef strErrMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCloseOtherRoughValves")
            Dim blResult As Boolean = True
            Dim strLoadlockName As String = String.Empty
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ":" & PUMPDOWN_ABORTED, strSequenceName)
                    Exit Try
                End If

                strLoadlockName = ConstEnum.Equipments.LoadLockA.ToString

                If (strLoadlockName <> String.Empty) Then
                    strErrMsg = LLCryoUtility.CloseLLFastRough(strLoadlockName)
                    If (strErrMsg = String.Empty) Then
                        blResult = True
                    Else
                        blResult = False
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.seqLogger.Info("Leave StepCloseOtherRoughValves")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-12-05</date>
        ''' </author>
        ''' <summary>
        ''' PumpDownSequence
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function PumpDownWithTurbo(ByVal strSequenceName As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter PumpDownWithTurbo")

            Dim objTMController As Business.TMController =
                    CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
            Try
                m_blnIsPumpDownRunning = True
                Dim blIsHasCloseLLRoughValve As Boolean = False
                Dim blnCloseAllValve As Boolean = False
                Dim objTransferModule As DataManagerment.CassettesModule =
                                DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim blLLTurboInstall As Boolean = False

                Dim strErrMsg As String = String.Empty
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Or_Close_Foreline

                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Pumpdown...", strSequenceName) ''Tin.Tran changed Status message 25/06/2012
                If ObjectRoughPumpMachine Is Nothing Then
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithTurbo")
                    Return False
                End If

                'wait for make pumpdown highest priority 
                Dim timeout As Integer = VentPumdownLib.LLPumpdownConfig.LLPumpDownComplete * 1000
                If (ObjectRoughPumpMachine IsNot Nothing) AndAlso (Not ObjectRoughPumpMachine.WaitForMakePumpdownHighestPriority(Me.EquipmentName, m_EventStopThread, timeout)) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'STEP: Wait for Rough Pump PM Close if TM shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If RobotConfigurationValues.SHARED_MP_WITH_PM AndAlso
                    Not Utils.WaitForRoughtPMClose(TRANSFERMODULE_STR, strSequenceName, m_EventStopThread, VentPumdownLib.LLPumpdownConfig.RoughPumpPMTimeOut, strErrMsg, ObjectRoughPumpMachine) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'STEP: Close TM Vent(valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseTMVentValve(strErrMsg, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close TM Rough(valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseTMRoughValve(strErrMsg, False, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn On MP
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOnMechanicalPump(TM_PUMPDOWN_ABORTED, strErrMsg, m_EventStopThread, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close All Slit valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseAllIsolationValve(strErrMsg, False, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Is TM CG Reach Cross Over Pressure And Relay Is On 
                'And Turbo is up to speed and foreline valve open
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If IsOK_2OpenHivacCond(strErrMsg) Then
                    GoTo POST_PUMP_DOWN
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim blIsHasCloseLLARoughValve As Boolean = False
                If Not Utils.CloseAllOtherRoughValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim blIsHasCloseLLAForelineValve As Boolean = False
                If Not Utils.CloseAllOtherForelineRoughValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn off TM IG
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOffTMIG_Wait4IGOff(strErrMsg, False, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close TM HiVac valve()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseTMHivac_Wait4HivacClose(strErrMsg, False, strSequenceName) Then
                    GoTo EXIT_FUNCTION
                End If

                'check other pump down finished and keep open rough
                If (IsLoadlockKeepOpenRoughValve()) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close LLx Rough Valve 
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepCloseLLRoughValve(strErrMsg, False, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                        GoTo EXIT_FUNCTION
                    Else
                        blIsHasCloseLLRoughValve = True
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Check LLx Turbo installed
                ''if No: Wait Pump Down Running -> Close Rough Valve->Wait MP#1 Pressure
                ''if Yes: Wait MP#2 Pressure
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim objLoadLock As LoadLockController = ControllerManager.GetController(LoadLockA_STR)
                ''check LLA
                Dim bCloseLLForelineValve As Boolean = False

                If objLoadLock IsNot Nothing Then
                    blLLTurboInstall = RobotConfigurationValues.LLA_TURBO_VISIBLE
                    If Not StepCheckingLLxTurboInstalled(strErrMsg, TM_PUMPDOWN_ABORTED,
                                                     m_EventStopThread, objLoadLock, blLLTurboInstall, strSequenceName) Then
                        GoTo EXIT_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close LL Foreline Valve
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If ObjectRoughPumpMachine.IsUsed(LoadLockA_STR) Then
                        If blLLTurboInstall AndAlso objLoadLock.IsLLTurboForelineValveOpenCond Then
                            If Not objLoadLock.StepCloseLLTurboForelineValve(strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                                blnCloseAllValve = True
                                GoTo EXIT_FUNCTION
                            End If
                            bCloseLLForelineValve = True
                        End If
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 5s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Or_Close_Foreline
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open TM Foreline Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenTMTurboForeline(strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                ' Wait foreline cg relay on
                If Not WaitForelineCGRelayOn(strErrMsg, m_EventStopThread) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn on Turbo and Wait for up to speed signal. Timout = 15mins
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '######waiting for Mr Dung Turn on Turbo#######################

                If Not StepTMTurboInit(strErrMsg, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close TM Foreline Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseTMTurboForeline(strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 5s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Or_Close_Foreline
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName) ''Tin.Tran changed Status message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If
                'Thread.Sleep(VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Close_Foreline)

                '17-08-2012	TM autopump down.  If TM pressure is < cross over,  skip open rough valve step.
                If Not (IsTMCGReachCrossOverPressureAndCGRelayOnCond()) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Open TM Fast Rough(valve)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepOpenTMRoughValve(strErrMsg, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo EXIT_FUNCTION
                    End If

                    'Wait until TM CG <.150 torr. Max wait 5 mins -> change to 20 mins
                    If Not StepWaitFastRoughPressure(strErrMsg, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo EXIT_FUNCTION
                    End If

                    'Dat Cao add sleep func, continue to rough for another 10s.
                    'Thread.Sleep(VentPumdownLib.TMPumpdownConfig.TMPumdown_Delay_Time)
                    Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumdown_Delay_Time * 1000
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Continue to pumpdown. Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName) ''Tin.Tran changed Status message 25/06/2012
                    If m_EventStopThread.WaitOne(Milliseconds, True) Then
                        blnCloseAllValve = True
                        GoTo EXIT_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close TM Fast Rough(valve)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepCloseTMRoughValve(strErrMsg, False, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo EXIT_FUNCTION
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'CG  Cross over pressure
                'CG relay on
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If m_EventStopThread.WaitOne(0, True) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                If Not ((objTransferModule.CG * m_CGMultiFactor) <= VentPumdownLib.TMPumpdownConfig.TMRoughPressure) Then
                    strErrMsg = String.Format("TM: CG >= {0} Torr.", VentPumdownLib.TMPumpdownConfig.TMRoughPressure)
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turbo is up to speed
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not IsTurboTurnOnCond() Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Wait 5s
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Or_Close_Foreline
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                    If m_EventStopThread.WaitOne(Milliseconds, True) Then
                        blnCloseAllValve = True
                        GoTo EXIT_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Open TM Foreline Valve
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepOpenTMTurboForeline(strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo EXIT_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Wait foreline cg relay on
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not WaitForelineCGRelayOn(strErrMsg, m_EventStopThread) Then
                        blnCloseAllValve = True
                        GoTo EXIT_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Turn on Turbo and Wait for up to speed signal. Timout = 15mins
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepTMTurboInit(strErrMsg, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo EXIT_FUNCTION
                    End If
                End If

POST_PUMP_DOWN:

                'check other pump down finished and keep open rough
                If (IsLoadlockKeepOpenRoughValve()) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close LLx Rough Valve 
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepCloseLLRoughValve(strErrMsg, False, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                        GoTo EXIT_FUNCTION
                    Else
                        blIsHasCloseLLRoughValve = True
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 5s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Or_Close_Foreline
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open foreline valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenTMTurboForeline(strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                If objLoadLock IsNot Nothing Then ' AndAlso bCloseLLForelineValve Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Open LL Foreline Valve 
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If objLoadLock.IsTurboOnCond() Then
                        'wait(5S)
                        If m_EventStopThread.WaitOne(5000, True) Then
                            Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": " & PUMPDOWN_ABORTED, strSequenceName)
                            GoTo EXIT_FUNCTION
                        End If
                        If RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                            Dim objPumppackage As Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAPumpPackage.ToString)
                            If (objPumppackage IsNot Nothing) AndAlso (objPumppackage.TurboUptoSpeed = True) Then
                                If Not objLoadLock.StepOpenLLTurboForelineValve(strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                                    blnCloseAllValve = False
                                End If
                            End If
                        End If
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 5s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Or_Close_Foreline
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open TM HiVacValve.
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenTMHivac(strErrMsg, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo EXIT_FUNCTION
                End If

                'do not Open Rough valve because has Open TM Foreline in above step
                'do not wait and open close TM IG because will be wait and Open IG at next step
                StepOpenOtherValveWhenPumpdownCompeted(strErrMsg, False, False, strSequenceName)
                If (strErrMsg <> String.Empty) Then
                    'alarm but not stop sequence
                    'pump down is completed
                    Me.ThrowAlarm(strErrMsg, ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                blIsHasCloseLLAForelineValve = (blIsHasCloseLLAForelineValve And (Not IsLLARoughOnlyMode()))
                If Not Utils.OpenAllOtherForelineValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, False) Then
                    If (Not String.IsNullOrEmpty(strErrMsg)) Then
                        Me.ThrowAlarm(strErrMsg, ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 15s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = VentPumdownLib.TMPumpdownConfig.TMPumpDown_Wait_After_Open_Hivac
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)   ''Tin.Tran changed Status message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = False
                    GoTo EXIT_FUNCTION
                End If

                'Wait for CG Relay On
                'Thread.Sleep(VentPumdownLib.TMPumpdownConfig.IGOnDelay)
                'Turn on IG
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If (IsTMHivacOpenCond()) Then
                    If Not StepTurnOnTMIG(strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                        blnCloseAllValve = False
                        GoTo EXIT_FUNCTION
                    End If
                End If

                'Make pumpdown low priority
                If ObjectRoughPumpMachine IsNot Nothing Then
                    ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                End If

                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Pumpdown completed", strSequenceName)  ''Tin.Tran changed Status message 25/06/2012
                AVPLib.Log.seqLogger.Info("Leave PumpDownWithTurbo")
                Return True
EXIT_FUNCTION:
                'if pressure of LL is OK - > open isolation valve
                ' is not OK then Open Rough valve if has Close Rough valve at step above
                StepOpenOtherValveWhenPumpdownCompeted(strErrMsg, blIsHasCloseLLRoughValve And m_blnOpenTMTurboForeline, True, strSequenceName)
                If (strErrMsg <> String.Empty) Then
                    Me.ThrowAlarm(strErrMsg, ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                blIsHasCloseLLARoughValve = (blIsHasCloseLLARoughValve And (Not IsLLARoughOnlyMode()) And (Not m_blnOpenTMTurboForeline))
                Utils.OpenAllOtherRoughValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, False)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Utils.OpenAllOtherForelineValve(Me.EquipmentName, strErrMsg, TM_PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, False)

                If (m_EventStopThread.WaitOne(0, True)) Then
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status message 25/06/2012
                Else
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        Utils.ShowStatusMessage(TM_PUMPDOWN_FAILED, strSequenceName)
                    End If
                End If

                If blnCloseAllValve Then
                    CloseActivePumpDown()
                End If

                AVPLib.Log.seqLogger.Info("Leave PumpDownWithTurbo")
                Return False
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If ObjectPumpPackage IsNot Nothing Then
                    ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                    ObjectRoughPumpMachine.ReleaseRoughLineInUse(Me.EquipmentName)
                End If
            End Try
            Utils.ShowStatusMessage(TM_PUMPDOWN_FAILED, strSequenceName)
            AVPLib.Log.seqLogger.Info("Leave PumpDownWithTurbo")
            Return False
        End Function

        ''' <author>Tinh Le</author>
        ''' <date>2021-25-10</date>
        ''' <summary>
        ''' Wait Foreline CG Relay
        ''' </summary>
        ''' <remarks></remarks>
        Private Function WaitForelineCGRelayOn(ByRef strErrMsg As String, ByVal abortedEvent As Threading.ManualResetEvent) As Boolean
            AVPLib.Log.seqLogger.Info("Enter WaitForelineCGRelayOn")
            Try
                If abortedEvent.WaitOne(0, True) Then
                    Utils.ShowStatusMessage("TM: " & PUMPDOWN_ABORTED)
                    AVPLib.Log.seqLogger.Info("Leave WaitForelineCGRelayOn")
                    Return False
                End If

                Dim Milliseconds As Int32 = 5 * 60 * 1000
                Utils.ShowStatusMessage("TM wait for Foreline CG Relay on with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s")
                If Not Utils.WaitOnCondition(AddressOf IsTurboForelineCGRealyOnCond, Milliseconds, abortedEvent) Then
                    If Not abortedEvent.WaitOne(0, True) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("TurboForelineCGRelay_FB"), Me.EquipmentName)
                    End If
                    AVPLib.Log.seqLogger.Info("Leave WaitForelineCGRelayOn")
                    Return False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            AVPLib.Log.seqLogger.Info("Leave WaitForelineCGRelayOn")
            Return True
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-07-12</date>
        ''' </author>
        ''' <summary>
        ''' Close other Rough Valves
        ''' Only use this function when other rough valve is opened by other loadlock pump down with rough only
        ''' when pump down finished, rough valve is keep open
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenOtherLLFastRoughValves(ByRef strErrMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenOtherFastRoughValves")
            Dim blResult As Boolean = False
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(Me.EquipmentName & PUMPDOWN_ABORTED, strSequenceName)
                    Exit Try
                End If

                Dim strOtherLoadlock As String = String.Empty
                strOtherLoadlock = ConstEnum.Equipments.LoadLockA.ToString

                If (strOtherLoadlock <> String.Empty) Then
                    strErrMsg = LLCryoUtility.OpenLLFastRoughNoSafety(strOtherLoadlock)
                    If (strErrMsg = String.Empty) Then
                        blResult = True
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.seqLogger.Info("Leave StepOpenOtherFastRoughValves")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-07-12</date>
        ''' </author>
        ''' <summary>
        '''	Cxx with 1 loadlock( 1 mechanical pump for load lock and TM).
        '''when user click auto pumpdown LLx while TM auto pumpdown is running,
        '''then just wait(do nothing) until TM auto pumpdown is Finished.

        ''' Close other Rough Valves
        ''' Only use this function when other rough valve is opened by other loadlock pump down with rough only
        ''' when pump down finished, rough valve is keep open
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenOtherValveWhenPumpdownCompeted(ByRef strErrMsg As String,
                                                               ByVal isHasCloseLLRoughValve As Boolean,
                                                               ByVal isNeedOpenCloseTMIG As Boolean,
                                                               Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenOtherValveWhenPumpdownCompeted")
            Dim blResult As Boolean = False
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(Me.EquipmentName & PUMPDOWN_ABORTED, strSequenceName)
                    Exit Try
                End If

                Dim objLLController As LoadLockController = Nothing
                Dim objLoadlock As LoadLock = Nothing

                objLLController = ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString)
                objLoadlock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)

                If (objLLController IsNot Nothing) Then
                    If (objLoadlock IsNot Nothing AndAlso
                    objLoadlock.PumpDownStatus = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        blResult = Not objLLController.IsNeedPumpdownWhenLoadWithRoughOnly(m_EventStopThread, strErrMsg, isNeedOpenCloseTMIG, isHasCloseLLRoughValve)
                    Else
                        'do nothing
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.seqLogger.Info("Leave StepOpenOtherValveWhenPumpdownCompeted")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-02-05</date>
        ''' </author>
        ''' <summary>
        ''' Close Active Rough
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CloseActivePumpDown()
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            AVPLib.Log.seqLogger.Info("Enter CloseActivePumpDown")
            Dim strGemSubPumpDownAlarmName As String = AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED
            Dim objRoughPumpMachine As DataManagerment.RoughPumpMachine =
            EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)

            Dim strErrMsg As String = String.Empty
            If m_blnOpenTMFastRough Then
                strErrMsg = TMCryoUtility.CloseRoughValve(Me.EquipmentName)

                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg, strGemSubPumpDownAlarmName)
                    AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                    Exit Sub
                Else
                    'Release Rough Line
                    If objRoughPumpMachine IsNot Nothing Then
                        ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                        objRoughPumpMachine.ReleaseRoughLineInUse(EquipmentName)
                    End If
                    m_blnOpenTMFastRough = False
                End If
            End If

            'If m_blnOpenTMHivac Then
            '    'send close hivac
            '    strErrMsg = TMCryoUtility.CloseHiVacValve(Me.EquipmentName)

            '    'send failed
            '    If strErrMsg <> String.Empty Then
            '        Me.ThrowAlarm(strErrMsg, strGemSubPumpDownAlarmName)
            '        AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
            '        Exit Sub
            '    End If

            '    'wait for reply
            '    If Not Utils.WaitOnCondition(AddressOf IsTMHivacCloseCond, VentPumdownLib.TMPumpdownConfig.TMHivacOpenCloseTimeOut * 1000, m_EventStopThread) Then
            '        'if failed
            '        If (Not m_EventStopThread.WaitOne(0, True)) Then
            '            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("HivacValveDidNotClose"), AVPLib.ConstEnum.TM_STR), strGemSubPumpDownAlarmName)
            '            AVPLib.Log.coreLogger.Info("Leave CloseActivePumpDown")
            '            Exit Sub
            '        End If
            '    End If

            '    Me.m_blnOpenTMHivac = False
            'End If

            If IsTMIGOnCond() Then
                strErrMsg = TMCryoUtility.TurnOffIG(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg, strGemSubPumpDownAlarmName)
                    AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                    Exit Sub
                End If
                'Verify IG is Off
                If Not Utils.WaitOnCondition(AddressOf IsTMIGOffCond,
                                              VentPumdownLib.TMPumpdownConfig.IGOnOffTimeOut * 1000,
                                              Nothing) Then
                    If (Not m_EventStopThread.WaitOne(0, True)) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("TMIGWasNotOff"),
                                                                 AVPLib.ConstEnum.TM_STR), strGemSubPumpDownAlarmName)
                        AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                        Exit Sub
                    End If
                End If
            End If

            If m_blnOpenTMTurboForeline Then
                'send close valve
                strErrMsg = TMCryoUtility.CloseTMTurboForeLineValve(Me.EquipmentName)
                'send failed
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg, strGemSubPumpDownAlarmName)
                    AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                    Exit Sub
                Else
                    Me.m_blnOpenTMTurboForeline = False
                End If
            End If

            If RobotConfigurationValues.TMTURBO_VISIBLE Then
                Dim objTMTurboCtrl As TurboController = Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
                If objTMTurboCtrl IsNot Nothing AndAlso m_blnTurnOnTurbo Then

                    If Not objTMTurboCtrl.TurnOff() Then
                        Me.ThrowAlarm(TRANSFERMODULE_STR & ": Turn off Turbo failed.", strGemSubPumpDownAlarmName) ''Tin.Tran changed Status message 25/06/2012
                        AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                        Exit Sub
                    End If
                    Me.m_blnTurnOnTurbo = False
                End If
            End If
            AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
        End Sub

#End Region


#Region "Functions for sequence"
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Close Foreline Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseTMTurboForeline(ByRef strErrMsg As String,
                                                ByVal strStatusMsg As String,
                                                ByVal abortedEvent As Threading.ManualResetEvent,
                                                Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCloseTMForeline")
            Dim blResult As Boolean = False
            Try
                'check abort event
                If abortedEvent.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg)
                    Exit Try
                End If

                'send to device
                strErrMsg = TMCryoUtility.CloseTMTurboForeLineValve(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Exit Try
                End If

                'wait for device reply
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMTurboForelineOpenCloseTimeOut * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Wait for turbo foreline valve close with timeout " &
                                            TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", strSequenceName)
                If WaitForTMTurboForelineValveClosed(Milliseconds, abortedEvent) Then
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Turbo Foreline valve is closed.", strSequenceName)
                    m_blnOpenTMTurboForeline = False
                    blResult = True
                Else
                    strErrMsg = String.Format(ContainerData.GetMessageText("TMForelineWasNotClose"), AVPLib.ConstEnum.TM_STR)
                    m_blnOpenTMTurboForeline = True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCloseTMForeline")
            Return blResult
        End Function

        Public Function StepCheckingLLxTurboInstalled(ByRef strErrMsg As String,
                                                      ByVal strStatusMsg As String,
                                                      ByVal abortedEvent As Threading.ManualResetEvent,
                                                      ByVal objLoadLockCtrl As LoadLockController,
                                                      ByVal blnLLTurboInstalled As Boolean,
                                                      Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.coreLogger.Info("Enter StepCheckingLLxTurboInstalled")

            If abortedEvent.WaitOne(0, True) Then
                Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                AVPLib.Log.seqLogger.Info("Leave StepCheckingLLxTurboInstalled")
                Return False
            End If
            '''''''''''check LL Turbo Installed ?
            If blnLLTurboInstalled = False Then
                ''if LL Turbo not installed
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait if LL Pump Down is Running . Timeout 10mins
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCheckOtherRoughInUse(strErrMsg) Then
                    AVPLib.Log.seqLogger.Info("Leave StepCheckingLLxTurboInstalled")
                    Return False
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close LL Rough Valve
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If (objLoadLockCtrl IsNot Nothing AndAlso ObjectRoughPumpMachine.IsUsed(objLoadLockCtrl.EquipmentName)) Then
                    If Not objLoadLockCtrl.Close_LLx_Rough_Valve(strStatusMsg, strErrMsg, False, abortedEvent) Then
                        AVPLib.Log.seqLogger.Info("Leave StepCheckingLLxTurboInstalled")
                        Return False
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait if MP#1 Pressure < MP#1 on Pressure . Timeout 5mins
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepWaitMPPressure(strErrMsg, strSequenceName) Then
                    AVPLib.Log.seqLogger.Info("Leave StepCheckingLLxTurboInstalled")
                    Return False
                End If
            Else
                'if LL Turbo installed
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait if MP#2 Pressure < MP#2 on Pressure . Timeout 5mins
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepWaitMPPressure(strErrMsg, strSequenceName) Then
                    AVPLib.Log.seqLogger.Info("Leave StepCheckingLLxTurboInstalled")
                    Return False
                End If
            End If

            AVPLib.Log.seqLogger.Info("Leave StepCheckingLLxTurboInstalled")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Open Foreline Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenTMTurboForeline(ByRef strErrMsg As String,
                                                ByVal strStatusMsg As String,
                                                ByVal abortedEvent As Threading.ManualResetEvent,
                                                Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCloseTMForeline")
            Dim blResult As Boolean = False
            Try
                If abortedEvent.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg)
                    Exit Try
                End If

                strErrMsg = TMCryoUtility.OpenTMTurboForeLineValve(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Exit Try
                End If

                'Wating for Rough Open
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMRoughValveOpenCloseTimeOut * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Wait for Turbo Foreline valve open with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", strSequenceName)
                If WaitForTMTurboForelineValveOpened(Milliseconds, m_EventStopThread) Then
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Turbo Foreline valve is opened", strSequenceName)
                    m_blnOpenTMTurboForeline = True
                    blResult = True ' only one case = success
                Else
                    strErrMsg = AVPLib.ConstEnum.TM_STR & ": failed to open Turbo Foreline valve."
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCloseTMForeline")
            Return blResult
        End Function

        Public Function StepCloseLLRoughValve(ByRef strErrMsg As String,
                                              ByVal bln_True4Vent_False4PumpDown As Boolean,
                                              ByVal strStatusMsg As String,
                                              ByVal abortedEvent As Threading.ManualResetEvent,
                                              Optional ByVal strSequenceName As String = "") As Boolean

            AVPLib.Log.seqLogger.Info("Enter StepCloseLLRoughValve")
            Try
                Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing

                If abortedEvent.WaitOne(0, True) Then
                    'Utils.ShowStatusMessage(IIf(bln_True4Vent_False4PumpDown, TM_VENT_FAILED, TM_PUMPDOWN_FAILED))
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave StepCloseLLRoughValve")
                    Return False
                End If

                ''if turbo not installed -> close Rough Valve
                If RobotConfigurationValues.LLA_TURBO_VISIBLE = False Then
                    objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                    If objLoadLockCtrl IsNot Nothing Then
                        If Not objLoadLockCtrl.Close_LLx_Rough_Valve(strStatusMsg, strErrMsg, False, abortedEvent) Then
                            AVPLib.Log.seqLogger.Info("Leave StepCloseLLRoughValve")
                            Return False
                        End If
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCloseLLRoughValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-21</date>
        ''' </author>
        ''' <summary>
        ''' Wait for TM Rough valve closed
        ''' </summary>
        ''' <remarks></remarks>
        Private Function WaitForTMRoughValveClosed(ByVal timeout As Integer, ByVal manualEvent As ManualResetEvent) As Boolean
            Dim blResult As Boolean = False
            Try
                blResult = Utils.WaitOnCondition(AddressOf IsTMRoughValveCloseCond, timeout, manualEvent)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-21</date>
        ''' </author>
        ''' <summary>
        ''' Wait for TM Rough valve Opened
        ''' </summary>
        ''' <remarks></remarks>
        Private Function WaitForTMRoughValveOpened(ByVal timeout As Integer, ByVal manualEvent As ManualResetEvent) As Boolean
            Dim blResult As Boolean = False
            Try
                blResult = Utils.WaitOnCondition(AddressOf IsTMRoughValveOpenCond, timeout, manualEvent)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2021-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Wait for TM MP Turn On
        ''' </summary>
        Private Function WaitForTMMechanicalPumpOn(ByVal timeout As Integer, ByVal manualEvent As ManualResetEvent) As Boolean
            Dim blResult As Boolean = False
            Try
                blResult = Utils.WaitOnCondition(AddressOf IsTMMechanicalPumpOn, timeout, manualEvent)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-21</date>
        ''' </author>
        ''' <summary>
        ''' Wait for TM vent valve closed
        ''' </summary>
        ''' <remarks></remarks>
        Private Function WaitForTMVentValveClosed(ByVal timeout As Integer, ByVal manualEvent As ManualResetEvent) As Boolean
            Dim blResult As Boolean = False
            Try
                blResult = Utils.WaitOnCondition(AddressOf IsTMVentValveCloseCond, timeout, manualEvent)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-21</date>
        ''' </author>
        ''' <summary>
        ''' Wait for TM vent valve opened
        ''' </summary>
        ''' <remarks></remarks>
        Private Function WaitForTMVentValveOpened(ByVal timeout As Integer, ByVal manualEvent As ManualResetEvent) As Boolean
            Dim blResult As Boolean = False
            Try
                blResult = Utils.WaitOnCondition(AddressOf IsTMVentValveOpenCond, timeout, manualEvent)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-21</date>
        ''' </author>
        ''' <summary>
        ''' Wait for TM TurboForeline valve closed
        ''' </summary>
        ''' <remarks></remarks>
        Private Function WaitForTMTurboForelineValveClosed(ByVal timeout As Integer, ByVal manualEvent As ManualResetEvent) As Boolean
            Dim blResult As Boolean = False
            Try
                blResult = Utils.WaitOnCondition(AddressOf IsTMTurboForelineValveCloseCond, timeout, manualEvent)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-21</date>
        ''' </author>
        ''' <summary>
        ''' Wait for TM TurboForeline valve opened
        ''' </summary>
        ''' <remarks></remarks>
        Private Function WaitForTMTurboForelineValveOpened(ByVal timeout As Integer, ByVal manualEvent As ManualResetEvent) As Boolean
            Dim blResult As Boolean = False
            Try
                blResult = Utils.WaitOnCondition(AddressOf IsTMTurboForelineValveOpenCond, timeout, manualEvent)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Close Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseTMRoughValve(ByRef strErrMsg As String,
                                              ByVal bln_True4Vent_False4PumpDown As Boolean,
                                              ByVal strStatusMsg As String,
                                              ByVal abortedEvent As Threading.ManualResetEvent,
                                              Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCloseTMRoughValve")
            Dim blResult As Boolean = False
            Try
                If abortedEvent.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                    Exit Try
                End If

                'send to device 
                strErrMsg = TMCryoUtility.CloseRoughValve(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Exit Try
                End If

                'wait for device reply
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMRoughValveOpenCloseTimeOut * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Wait for rough valve close with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s",
                                        IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                If (WaitForTMRoughValveClosed(Milliseconds, abortedEvent)) Then
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Rough valve is closed.", IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                    m_blnOpenTMFastRough = False
                    blResult = True
                Else
                    m_blnOpenTMFastRough = True
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Failed to close Rough valve.", IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.seqLogger.Info("Leave StepCloseTMRoughValve")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-14</date>
        ''' </author>
        ''' <summary>
        ''' Turn on mechanical pump
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepTurnOnMechanicalPump(ByVal strStatusMsg As String,
                                                 ByRef strErrMsg As String,
                                                 ByVal abortedEvent As Threading.ManualResetEvent,
                                                 Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepTurnOnMechanicalPump")
            Try
                If abortedEvent.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave StepTurnOnMechanicalPump")
                    Return False
                End If
                If Not IsTMMechanicalPumpOn() Then
                    If Not RobotConfigurationValues.SHARED_MP_WITH_PM Then
                        Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Turn on Mechanical Pump.", strSequenceName)
                        Dim objMechanicalPump As RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)

                        If (objMechanicalPump IsNot Nothing) Then
                            strErrMsg = TMCryoUtility.OpenCloseMechanicalPump(ConstEnum.Equipments.CassettesModule.ToString, objMechanicalPump.Name, True)
                            If strErrMsg <> String.Empty Then
                                Return False
                            End If
                            'wait for serial MP connect
                            strErrMsg = WaitMechanicalPumpSerialTurnOn(objMechanicalPump.Name, abortedEvent)
                            If strErrMsg <> String.Empty Then
                                Return False
                            End If

                            ' turn on mechanical pump
                            strErrMsg = TMCryoUtility.TurnOnMechanicalPumpSerial(objMechanicalPump.Name)
                            If strErrMsg <> String.Empty Then
                                Return False
                            End If
                        End If
                    End If

                    If strErrMsg <> String.Empty Then
                        AVPLib.Log.seqLogger.Info("Leave StepTurnOnMechanicalPump")
                        Return False
                    Else
                        Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Wait 30s after Turn on Mechanical Pump.")
                        If abortedEvent.WaitOne(30000, True) Then
                            Utils.ShowStatusMessage(strStatusMsg)
                            AVPLib.Log.coreLogger.Info("Leave StepTurnOnMechanicalPump")
                            Return False
                            Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Mechanical Pump is Opened.", strSequenceName)
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepTurnOnMechanicalPump")
            Return True
        End Function
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Open Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenTMRoughValve(ByRef strErrMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenTMRoughValve")
            Dim blResult As Boolean = False
            Try
                'check abort event
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(TM_PUMPDOWN_ABORTED, strSequenceName)
                    Exit Try
                End If

                ''Make rough line in use
                Dim expectedMPPressure As Double = VentPumdownLib.TMPumpdownConfig.TMMechanicalPumpOnPressure
                'Dim TMCrossOverPressure As Double = VentPumdownLib.TMPumpdownConfig.TMRoughPressure
                If ObjectRoughPumpMachine IsNot Nothing Then

                    If (ObjectRoughPumpMachine.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        strErrMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & MECHANICAL_PUMP_CG_DISCONNECTED
                        Return False
                    End If

                    Dim waitTimeout As Int64 = VentPumdownLib.TMPumpdownConfig.TMMakeRoughLineInUseTimeOut * 1000
                    If ObjectRoughPumpMachine.MakeRoughLineInUse(Me.EquipmentName, expectedMPPressure, m_EventStopThread, waitTimeout) Then
                        ' Send a warning event here, make user noticeable.
                        ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeWarning, AVPLib.ConstEnum.TM_STR,
                                                    "Rough Line now is used by " & AVPLib.ConstEnum.TM_STR)

                        'Open TM Rough
                        strErrMsg = TMCryoUtility.OpenRoughValve(Me.EquipmentName, False)
                        'Open Failed
                        If strErrMsg <> String.Empty Then
                            Exit Try
                        End If

                        'Wating for Rough Open
                        Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMRoughValveOpenCloseTimeOut * 1000
                        Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Wait for rough valve open with timeout " &
                                                TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", strSequenceName)
                        If WaitForTMRoughValveOpened(Milliseconds, m_EventStopThread) Then
                            Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Rough valve is opened.", strSequenceName)
                            m_blnOpenTMFastRough = True
                            blResult = True ' only one case = success
                        Else
                            strErrMsg = String.Format(ContainerData.GetMessageText("RoughValveWasNotOpened"), AVPLib.ConstEnum.TM_STR)
                        End If
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepOpenTMRoughValve")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-12-1</date>
        ''' </author>
        ''' <summary>
        ''' Close all Slit valve/ Slit valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseAllIsolationValve(ByRef strErrMsg As String,
                                                    ByVal bln_True4Vent_False4PumpDown As Boolean,
                                                    Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCloseAllIsolationValve")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(IIf(bln_True4Vent_False4PumpDown, TM_VENT_ABORTED, TM_PUMPDOWN_ABORTED), IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                    AVPLib.Log.seqLogger.Info("Leave StepCloseAllIsolationValve")
                    Return False
                End If
                '''''''''''''''''''''''''''''''''''
                Dim Millisecond As Int32 = VentPumdownLib.TMPumpdownConfig.TMMesaValvesOpenCloseTimeOut * 1000
                If bln_True4Vent_False4PumpDown Then
                    Millisecond = VentPumdownLib.TMVentConfig.TMMesaValvesOpenCloseTimeOut * 1000
                End If
                ' This method has already checked Robot Arm retracted.
                strErrMsg = TMCryoUtility.CloseAllSlitValve(Millisecond, m_EventStopThread)

                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave StepCloseAllIsolationValve")
                    Return False
                Else
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": All slit valves are closed", IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))  ''Tin.Tran changed Status message 25/06/2012
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCloseAllIsolationValve")
            Return True
        End Function


        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-12-1</date>
        ''' </author>
        ''' <summary>
        ''' Turn off TM IG
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepTurnOffTMIG_Wait4IGOff(ByRef strErrMsg As String,
                                                   ByVal bln_True4Vent_False4PumpDown As Boolean,
                                                   ByVal strStatusMsg As String,
                                                   ByVal abortedEvent As Threading.ManualResetEvent,
                                                   Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepTurnOffTMIG")
            Try
                If abortedEvent.WaitOne(0, True) Then
                    AVPLib.Log.seqLogger.Info("Leave StepTurnOffTMIG")
                    Utils.ShowStatusMessage(strStatusMsg, IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName)) 'EQName4UserReading & PUMPDOWN_FAILED
                    Return False
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''
                strErrMsg = TMCryoUtility.TurnOffIG(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave StepTurnOffTMIG")
                    Return False
                End If

                'Verify IG is Off
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.IGOnOffTimeOut * 1000
                If bln_True4Vent_False4PumpDown Then
                    Milliseconds = VentPumdownLib.TMVentConfig.IGOnOffTimeOut * 1000
                End If
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for IG Off with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s",
                                        IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))  '' Tin.Tran changed Status message 25/06/2012
                If Not Utils.WaitOnCondition(AddressOf IsTMIGOffCond, Milliseconds, abortedEvent) Then
                    If Not abortedEvent.WaitOne(0, True) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("TMIGWasNotOff"), AVPLib.ConstEnum.TM_STR)
                    End If
                    AVPLib.Log.seqLogger.Info("Leave StepTurnOffTMIG")
                    Return False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepTurnOffTMIG")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-12-1</date>
        ''' </author>
        ''' <summary>
        ''' Turn on TM IG
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepTurnOnTMIG(ByRef strErrMsg As String,
                                        ByVal strStatusMsg As String,
                                        ByVal abortedEvent As Threading.ManualResetEvent,
                                        Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepTurnOnTMIG")
            Try
                If abortedEvent.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave StepTurnOnTMIG")
                    Return False
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''
                strErrMsg = TMCryoUtility.TurnOnIG(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave StepTurnOnTMIG")
                    Return False
                End If
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.IGOnOffTimeOut * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for IG On with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName) ''Tin.Tran changed Status message 25/06/2012
                If Not Utils.WaitOnCondition(AddressOf IsTMIGOnCond, Milliseconds, abortedEvent) Then
                    'Retry Turn On IG.
                    Utils.ShowStatusMessage("Retry Turn On IG.", strSequenceName)
                    strErrMsg = TMCryoUtility.TurnOnIG(Me.EquipmentName)

                    If strErrMsg <> String.Empty Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("IGWasNotOn"), AVPLib.ConstEnum.TM_STR)
                        AVPLib.Log.coreLogger.Info("Leave StepTurnOnTMIG")
                        Return False
                    Else
                        Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Turning IG On...", strSequenceName)
                    End If

                    'If IG still not On -> Alarm.
                    If Not Utils.WaitOnCondition(AddressOf IsTMIGOnCond, VentPumdownLib.TMPumpdownConfig.IGOnOffTimeOut * 1000, m_EventStopThread) Then
                        If Not m_EventStopThread.WaitOne(0, True) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("IGWasNotOn"), AVPLib.ConstEnum.TM_STR)
                        End If

                        Utils.ShowStatusMessage(TM_PUMPDOWN_FAILED & " - Wait for closing valves...", strSequenceName)
                        Me.CloseActivePumpDown()
                        Utils.ShowStatusMessage(TM_PUMPDOWN_FAILED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave StepTurnOnTMIG")
                        Return False
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepTurnOnTMIG")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Close Hivac Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseTMHivac_Wait4HivacClose(ByRef strErrMsg As String,
                                            ByVal bln_True4Vent_False4PumpDown As Boolean,
                                            Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCloseTMHivac")
            Dim blResult As Boolean = False
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(IIf(bln_True4Vent_False4PumpDown, TM_VENT_ABORTED, TM_PUMPDOWN_ABORTED),
                    IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                    Exit Try
                End If

                strErrMsg = TMCryoUtility.CloseHiVacValve(Me.EquipmentName)

                'Close failed
                If strErrMsg <> String.Empty Then
                    Exit Try
                End If

                'waiting for hivac closed
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMHivacOpenCloseTimeOut * 1000
                If bln_True4Vent_False4PumpDown Then
                    Milliseconds = VentPumdownLib.TMVentConfig.TMHivacOpenCloseTimeOut * 1000
                End If

                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for Hivac valve close with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s",
                                        IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))  ''Tin.Tran changed Status message 25/06/2012
                If Not Utils.WaitOnCondition(AddressOf IsTMHivacCloseCond, Milliseconds, m_EventStopThread) Then
                    m_blnOpenTMHivac = True
                    If Not m_EventStopThread.WaitOne(0, True) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("HivacValveDidNotClose"), AVPLib.ConstEnum.TM_STR)
                        Exit Try
                    Else
                        Utils.ShowStatusMessage(IIf(bln_True4Vent_False4PumpDown, TM_VENT_ABORTED, TM_PUMPDOWN_ABORTED),
                        IIf(bln_True4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                        Exit Try
                    End If
                End If

                m_blnOpenTMHivac = False
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCloseTMHivac")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Open Hivac Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenTMHivac(ByRef strErrMsg As String,
                                        Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenTMHivac")
            Dim blResult As Boolean = False
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(TM_PUMPDOWN_ABORTED, strSequenceName)
                    Exit Try
                End If
                ''''''''''''''''''''''''''''''''''''''''
                strErrMsg = TMCryoUtility.OpenHiVacValve(Me.EquipmentName, True, m_CGMultiFactor)

                'error when open hivac
                If strErrMsg <> String.Empty Then
                    Exit Try
                End If

                'waiting for device reply
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMHivacOpenCloseTimeOut * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for Hivac valve open with timeout " &
                                            TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status message 25/06/2012
                If Not Utils.WaitOnCondition(AddressOf IsTMHivacOpenCond, Milliseconds, m_EventStopThread) Then
                    'User abort
                    m_blnOpenTMHivac = False
                    If m_EventStopThread.WaitOne(0, True) Then
                        Utils.ShowStatusMessage(TM_PUMPDOWN_ABORTED, strSequenceName)
                        Exit Try
                    Else ' failed to open hivac
                        strErrMsg = String.Format(ContainerData.GetMessageText("HivacValveDidNotOpen"), AVPLib.ConstEnum.TM_STR)
                        Exit Try
                    End If
                End If

                m_blnOpenTMHivac = True
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepOpenTMHivac")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Open TM Fast Vent
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenTMFastVent(ByRef strErrMsg As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenTMFastVent")
            Dim blResult As Boolean = False
            Try
                'check abort event
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ":" & TM_VENT_ABORTED, STR_SEQUENCE_AUTO_VENT)
                    Exit Try
                End If

                ' send request to device
                strErrMsg = TMCryoUtility.OpenVentValve(ConstEnum.Equipments.CassettesModule.ToString())
                If strErrMsg <> String.Empty Then
                    Exit Try
                Else
                    m_blnOpenTMVent = True
                End If

                'wait for device reply 
                Dim Milliseconds As Int32 = VentPumdownLib.TMVentConfig.TMVentValveOpenCloseTimeOut * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Wait for vent valve open with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", STR_SEQUENCE_AUTO_VENT)
                If WaitForTMVentValveOpened(Milliseconds, m_EventStopThread) Then
                    blResult = True
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Vent valve is opened.", STR_SEQUENCE_AUTO_VENT)
                Else
                    strErrMsg = String.Format(ContainerData.GetMessageText("LLFastVentWasNotOpen"), AVPLib.ConstEnum.TM_STR)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepOpenTMFastVent")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Close TM Vent Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseTMVentValve(ByRef strErrMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCloseTMVentValve")
            Dim blResult As Boolean = False
            Try
                'check abort event
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(TM_PUMPDOWN_ABORTED, strSequenceName)
                    Exit Try
                End If

                'send to device

                strErrMsg = TMCryoUtility.CloseVentValve(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Exit Try
                End If

                'wait for device reply
                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMRoughValveOpenCloseTimeOut * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Wait for vent valve close with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", strSequenceName)
                If WaitForTMVentValveClosed(Milliseconds, m_EventStopThread) Then
                    blResult = True
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Vent valve closed", strSequenceName)
                Else
                    strErrMsg = String.Format(ContainerData.GetMessageText("VentValveWasNotClosed"), AVPLib.ConstEnum.TM_STR)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCloseTMVentValve")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Close TM Vent Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepWaitMPPressure(ByRef strErrMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepWaitMPPressure")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(TM_PUMPDOWN_ABORTED, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave StepWaitMPPressure")
                    Return False
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim expectedMPPressure As Double = VentPumdownLib.TMPumpdownConfig.TMMechanicalPumpOnPressure
                'Dim TMCrossOverPressure As Double = VentPumdownLib.TMPumpdownConfig.TMRoughPressure
                If ObjectRoughPumpMachine IsNot Nothing Then
                    Dim waitTimeout As Int64 = VentPumdownLib.TMPumpdownConfig.TMMakeRoughLineInUseTimeOut * 1000
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for Mechanical Pump reach " & expectedMPPressure & "torr. Wait for 300s", strSequenceName)   ''Tin.Tran changed Status message 25/06/2012
                    If Not ObjectRoughPumpMachine.WaitMPPressure(expectedMPPressure, m_EventStopThread) Then

                        If (ObjectRoughPumpMachine.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                            strErrMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & MECHANICAL_PUMP_CG_DISCONNECTED
                        Else
                            strErrMsg = String.Format("TM: Mechanical Pump CG RB was not less than {0} Torr", expectedMPPressure)
                        End If

                        AVPLib.Log.seqLogger.Info("Leave StepWaitMPPressure")
                        Return False
                    End If
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for Mechanical Pump pressure [True]", strSequenceName)  ''Tin.Tran changed Status message 25/06/2012
                Else
                    AVPLib.Log.seqLogger.Info("Leave StepWaitMPPressure")
                    Return False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepWaitMPPressure")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Close TM Vent Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepWaitFastRoughPressure(ByRef strErrMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepWaitFastRoughPressure")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(TM_PUMPDOWN_ABORTED, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave StepWaitFastRoughPressure")
                    Return False
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim Milliseconds As Integer = VentPumdownLib.TMPumpdownConfig.TMRoughTimeOut * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for TM CG reach Cross Over pressure with time out " &
                                        TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName) ''Tin.Tran changed Status message 25/06/2012

                If Not Utils.WaitOnCondition(AddressOf IsTMCGReachCrossOverPressureAndCGRelayOnCond, AddressOf IsTMCGDisconnected, Milliseconds, m_EventStopThread) Then
                    If Not m_EventStopThread.WaitOne(0, True) Then
                        If (IsTMCGDisconnected()) Then
                            strErrMsg = (Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED)
                        Else
                            strErrMsg = String.Format("TM: CG >= {0} Torr. Max wait {1} mins.",
                            VentPumdownLib.TMPumpdownConfig.TMRoughPressure, TimeSpan.FromMilliseconds(Milliseconds).Minutes)
                        End If
                    End If
                    AVPLib.Log.seqLogger.Info("Leave StepWaitFastRoughPressure")
                    Return False
                Else
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for TM CG reach Cross Over pressure [True]", strSequenceName)    ''Tin.Tran changed Status message 25/06/2012
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepWaitFastRoughPressure")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Close TM Vent Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCheckOtherRoughInUse(ByRef strErrMsg As String) As Boolean
            AVPLib.Log.seqLogger.Info("Leave StepWaitFastRoughPressure")
            Dim bResult As Boolean = False
            Try
                ''not implement
                Dim Milliseconds As Double = VentPumdownLib.TMPumpdownConfig.TMMakeRoughLineInUseTimeOut * 1000

                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for other Rough Valve closed with timeout " &
                                            TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s") ''Tin.Tran changed Status message 25/06/2012
                If (Not ObjectRoughPumpMachine.WaitForRoughFree(Me.EquipmentName, m_EventStopThread, Milliseconds)) Then

                    If Not m_EventStopThread.WaitOne(0, True) Then
                        strErrMsg = "Failed to wait for other Rough closed"
                    End If
                    AVPLib.Log.seqLogger.Info("Leave StepWaitFastRoughPressure")
                Else
                    'Pass anything
                    bResult = True
                    Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for other Rough Valve closed " & "[" & bResult & "]")   ''Tin.Tran changed Status message 25/06/2012
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepWaitFastRoughPressure")
            Return bResult
        End Function
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Close TM Vent Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepTMTurboInit(ByRef strErrMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepTMTurboInit")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(TM_PUMPDOWN_ABORTED, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave StepTMTurboInit")
                    Return False
                End If
                '''''''''''''''''''''''''''''''''''''''''''''
                If ObjectPumpPackage IsNot Nothing Then
                    If ObjectPumpPackage.StartPumpPackage(True) Then
                        Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Turn on Turbo", strSequenceName) ''Tin.Tran changed Status message 25/06/2012
                    Else
                        strErrMsg = String.Format(ContainerData.GetMessageText("TurboWasNotOn"), AVPLib.ConstEnum.TM_STR)
                        AVPLib.Log.seqLogger.Info("Leave StepTMTurboInit")
                        Return False
                    End If
                End If

                Dim Milliseconds As Int32 = VentPumdownLib.TMPumpdownConfig.TMTurnOnTurboTimeOut * 1000
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for Turbo is up to speed with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName) ''Tin.Tran changed Status message 25/06/2012
                If Not Utils.WaitOnCondition(AddressOf IsTurboTurnOnCond, Milliseconds, m_EventStopThread) Then
                    If Not m_EventStopThread.WaitOne(0, True) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("TurboWasNotOn"), AVPLib.ConstEnum.TM_STR)
                    End If
                    m_blnTurnOnTurbo = True
                    AVPLib.Log.seqLogger.Info("Leave StepTMTurboInit")
                    Return False
                End If
                Utils.ShowStatusMessage(TRANSFERMODULE_STR & ": Waiting for Turbo up to speed [True]", strSequenceName) ''Tin.Tran changed Status message 25/06/2012
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepTMTurboInit")
            Return True
        End Function
#End Region

        Public Function IsStationOnline(ByVal Source As String, Optional ByRef strErrorMsg As String = "") As Boolean
            Dim blResult As Boolean = False
            Try
                Dim enmEqquipmentControlStatus As Equipment.ControlStatuses = Equipment.ControlStatuses.OFFLINE
                Dim objSource As Equipment = Nothing
                objSource = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Source)

                Dim objTM As Equipment = Nothing
                objTM = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())

                'check TM online
                If objTM IsNot Nothing AndAlso objTM.ControlStatus = Equipment.ControlStatuses.OFFLINE Then
                    strErrorMsg = String.Format(AVPLib.ContainerData.GetMessageText("CheckOnlineChamber_Error"),
                                             AVPLib.Utils.chamberID2ChamberName(ConstEnum.Equipments.CassettesModule.ToString()))
                    Exit Try
                End If

                'check source online
                If (objSource IsNot Nothing AndAlso objSource.ControlStatus = Equipment.ControlStatuses.OFFLINE) Then
                    strErrorMsg = String.Format(AVPLib.ContainerData.GetMessageText("CheckOnlineChamber_Error"),
                                             AVPLib.Utils.chamberID2ChamberName(Source))
                    Exit Try
                End If

                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Public Function CheckCG10DifferenceFromStation(ByVal Source As String,
                                                        ByVal bCheckSetPointTransferPresssure As Boolean,
                                                        ByVal bCycleInATMMode As Boolean, ByRef strCGPressureError As String,
                                                        Optional ByVal isTransferWafer As Boolean = True,
                                                        Optional ByRef blnEQOffline As Boolean = False) As Boolean

            AVPLib.Log.coreLogger.Info("Enter CheckCG10DifferenceFromStation")
            If RobotConfigurationValues.DEBUGMODE = True Then
                AVPLib.Log.coreLogger.Info("Leave CheckCG10DifferenceFromStation")
                Return True
            End If

            '------------------------------------------------------------------------------------------------
            'CHECK TM/LL IG/CG COMMUNICATION
            If (IsTMCGDisconnected()) Then
                strCGPressureError = Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED
                Return False
            End If

            If (IsTMIGDisconnected()) Then
                strCGPressureError = Utils.chamberID2ChamberName(Me.EquipmentName) & IG_DISCONNECTED
                Return False
            End If

            If Source.Contains(ConstEnum.Equipments.LoadLockA.ToString()) Then
                Dim objLoadlock As LoadLockController = ControllerManager.GetController(Source)
                If (objLoadlock IsNot Nothing AndAlso objLoadlock.IsLLCGDisconnected) Then
                    strCGPressureError = Utils.chamberID2ChamberName(Source) & CG_DISCONNECTED
                    Return False
                End If

                If (objLoadlock IsNot Nothing AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED AndAlso objLoadlock.IsLLIGDisconnected) Then
                    strCGPressureError = Utils.chamberID2ChamberName(Source) & IG_DISCONNECTED
                    Return False
                End If
            End If
            '------------------------------------------------------------------------------------------------

            '-	LLx (rough only)  If LLx pressure is lower than LLx cross over  
            '   and TM pressure is lower than TM cross over pressure and  both side CG relay is on 
            '   then open Slit valve between TM and LLx should be allow without the 10% restriction.  
            If Source.Contains(ConstEnum.Equipments.LoadLockA.ToString()) AndAlso Not NeedCheckCGDifference_In_RoughOnly(Source) Then
                Return True
            End If

            'Check to see if it run in the ATM mode
            If bCycleInATMMode Then
                Return CheckCG10DifferenceIn_ATM_Mode_FromStation(Source, bCheckSetPointTransferPresssure)
            End If

            Dim blnResult As Boolean = False
            Dim enmEqquipmentControlStatus As Equipment.ControlStatuses = Equipment.ControlStatuses.OFFLINE
            Dim eqmEquiment As Equipment = Nothing
            eqmEquiment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Source)
            Dim eqmEquimentTM As Equipment = Nothing
            eqmEquimentTM = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            Dim transfermodule As CassettesModule = CType(eqmEquimentTM, CassettesModule)
            Try
                If transfermodule.KepWareServerDisConnected AndAlso AVPLib.RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                    strCGPressureError = String.Format(ContainerData.GetMessageText("EquipmentDisconnect"), "TM PLC")
                    Return False
                End If
                If (Source.StartsWith(ConstEnum.Chamber)) Then
                    Dim objChamber As Chamber = CType(eqmEquiment, Chamber)
                    If (objChamber.ConnectionStatus <> Equipment.WorkingStatuses.On) Then
                        strCGPressureError = String.Format(ContainerData.GetMessageText("EquipmentDisconnect"),
                                        AVPLib.Utils.chamberID2ChamberName(Source))
                        Return False
                    End If
                End If

                'if Running Scheduler
                If bCheckSetPointTransferPresssure = True Then
                    enmEqquipmentControlStatus = transfermodule.ControlStatus
                    If enmEqquipmentControlStatus = Equipment.ControlStatuses.OFFLINE Then
                        If isTransferWafer Then
                            strCGPressureError = String.Format(AVPLib.ContainerData.GetMessageText(ConstEnum.CANNOT_TRANSFER_WAFER), ConstEnum.TM_STR)
                        Else
                            strCGPressureError = AVPLib.ContainerData.GetMessageText("CheckOnlineTM_Error")
                        End If

                        Return False
                    End If
                    If Source.Contains(ConstEnum.Equipments.LoadLockA.ToString()) Then
                        Dim ll As LoadLock = CType(eqmEquiment, LoadLock)
                        enmEqquipmentControlStatus = ll.ControlStatus
                    Else
                        Dim chamber As Chamber = CType(eqmEquiment, Chamber)
                        enmEqquipmentControlStatus = chamber.ControlStatus
                    End If
                    If enmEqquipmentControlStatus = Equipment.ControlStatuses.OFFLINE Then
                        If isTransferWafer Then
                            Me.ThrowAlarm(String.Format(AVPLib.ContainerData.GetMessageText(ConstEnum.CANNOT_TRANSFER_WAFER),
                                                                    AVPLib.Utils.chamberID2ChamberName(Source)))
                        Else
                            Me.ThrowAlarm(String.Format(AVPLib.ContainerData.GetMessageText("CheckOnlineChamber_Error"),
                                        AVPLib.Utils.chamberID2ChamberName(Source)))
                        End If
                        blnEQOffline = True
                        'when offline then return false
                        Return False
                    End If
                End If

                Dim objTransferModule As DataManagerment.CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                ' TM
                Dim TMIonGaugeStatus As Boolean = IIf(objTransferModule.IGStatus = Equipment.WorkingStatuses.On, True, False)
                Dim TMIonGaugePressure As Single = objTransferModule.IG
                Dim TMConvectronGaugePressure As Single = objTransferModule.CG
                'LLA, Chamber1, Chamber2, Chamber3, Chamber4, Chamber5
                Dim LLorChamberIonGaugeStatus As Boolean = False
                Dim LLorChamberIonGaugePressure As Single = 0.0
                Dim LLOrChamberConvectronGaugePressure As Single = 0.0

                Dim eqmEquipment As Equipment = EquipmentManager.GetEquipment(Source)
                If (eqmEquipment.Name.IndexOf(ConstEnum.Chamber) >= 0) Then
                    Dim objChamber As Chamber = CType(eqmEquipment, Chamber)
                    LLorChamberIonGaugeStatus = IIf(objChamber.IGStatus = Equipment.WorkingStatuses.On, True, False)
                    LLorChamberIonGaugePressure = objChamber.IG
                    LLOrChamberConvectronGaugePressure = objChamber.CG
                Else
                    Dim objLoadlLock As LoadLock = CType(eqmEquipment, LoadLock)
                    LLorChamberIonGaugeStatus = IIf(objLoadlLock.IGStatus = Equipment.WorkingStatuses.On, True, False)
                    LLorChamberIonGaugePressure = objLoadlLock.IG
                    LLOrChamberConvectronGaugePressure = objLoadlLock.CG
                End If
                Dim TMTransferSetPointPressure As Single = ContainerData.GetTransferSetPointPressureForStation(objTransferModule.Name, 0.1)
                Dim LLOrChamberTransferSetPointPressure As Single = ContainerData.GetTransferSetPointPressureForStation(eqmEquipment.Name, 0.1)
                blnResult = CheckDiff(TMIonGaugeStatus, TMIonGaugePressure, TMConvectronGaugePressure,
                                        LLorChamberIonGaugeStatus, LLorChamberIonGaugePressure, LLOrChamberConvectronGaugePressure,
                                       objTransferModule.PressureDifferentialPercent / 100,
                                        bCheckSetPointTransferPresssure, TMTransferSetPointPressure, LLOrChamberTransferSetPointPressure)
                If Not blnResult Then
                    strCGPressureError = "Pressure differential between TM and " & Utils.chamberID2ChamberName(Source)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckCG10DifferenceFromStation")
            Return blnResult
        End Function
        Public Function CheckCG10DifferenceFromStationForLoad(ByVal Source As String, ByRef strCGPressureError As String) As Boolean

            AVPLib.Log.coreLogger.Info("Enter CheckCG10DifferenceFromStation")
            If RobotConfigurationValues.DEBUGMODE = True Then
                AVPLib.Log.coreLogger.Info("Leave CheckCG10DifferenceFromStation")
                Return True
            End If

            Dim blnResult As Boolean = False
            Dim enmEqquipmentControlStatus As Equipment.ControlStatuses = Equipment.ControlStatuses.OFFLINE
            Dim eqmEquiment As Equipment = Nothing
            eqmEquiment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Source)
            Dim eqmEquimentTM As Equipment = Nothing
            eqmEquimentTM = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            Dim transfermodule As CassettesModule = CType(eqmEquimentTM, CassettesModule)
            Try
                If transfermodule.KepWareServerDisConnected AndAlso AVPLib.RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                    Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentDisconnect"), "TM PLC"))
                    Return False
                End If
                If (Source.StartsWith(ConstEnum.Chamber)) Then
                    Dim objChamber As Chamber = CType(eqmEquiment, Chamber)
                    If (objChamber.ConnectionStatus <> Equipment.WorkingStatuses.On) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentDisconnect"),
                                        AVPLib.Utils.chamberID2ChamberName(Source)))
                        Return False
                    End If
                End If

                Dim objTransferModule As DataManagerment.CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                ' TM
                Dim TMIonGaugeStatus As Boolean = IIf(objTransferModule.IGStatus = Equipment.WorkingStatuses.On, True, False)
                Dim TMIonGaugePressure As Single = objTransferModule.IG
                Dim TMConvectronGaugePressure As Single = objTransferModule.CG
                'LLA, Chamber1, Chamber2, Chamber3, Chamber4, Chamber5
                Dim LLorChamberIonGaugeStatus As Boolean = False
                Dim LLorChamberIonGaugePressure As Single = 0.0
                Dim LLOrChamberConvectronGaugePressure As Single = 0.0

                Dim eqmEquipment As Equipment = EquipmentManager.GetEquipment(Source)
                If (eqmEquipment.Name.IndexOf(ConstEnum.Chamber) >= 0) Then
                    Dim objChamber As Chamber = CType(eqmEquipment, Chamber)
                    LLorChamberIonGaugeStatus = IIf(objChamber.IGStatus = Equipment.WorkingStatuses.On, True, False)
                    LLorChamberIonGaugePressure = objChamber.IG
                    LLOrChamberConvectronGaugePressure = objChamber.CG
                Else
                    Dim objLoadlLock As LoadLock = CType(eqmEquipment, LoadLock)
                    LLorChamberIonGaugeStatus = IIf(objLoadlLock.IGStatus = Equipment.WorkingStatuses.On, True, False)
                    LLorChamberIonGaugePressure = objLoadlLock.IG
                    LLOrChamberConvectronGaugePressure = objLoadlLock.CG
                End If
                Dim TMTransferSetPointPressure As Single = ContainerData.GetTransferSetPointPressureForStation(objTransferModule.Name, 0.1)
                Dim LLOrChamberTransferSetPointPressure As Single = ContainerData.GetTransferSetPointPressureForStation(eqmEquipment.Name, 0.1)
                blnResult = CheckDiff(TMIonGaugeStatus, TMIonGaugePressure, TMConvectronGaugePressure,
                                        LLorChamberIonGaugeStatus, LLorChamberIonGaugePressure, LLOrChamberConvectronGaugePressure,
                                       objTransferModule.PressureDifferentialPercent / 100,
                                        False, TMTransferSetPointPressure, LLOrChamberTransferSetPointPressure)
                If Not blnResult Then
                    strCGPressureError = "Pressure differential between TM and " & Utils.chamberID2ChamberName(Source)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckCG10DifferenceFromStation")
            Return blnResult
        End Function

        Public Function CheckCG10DifferenceIn_ATM_Mode_FromStation(ByVal Source As String, ByVal bCheckSetPointTransferPresssure As Boolean) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckCG10DifferenceIn_ATM_Mode_FromStation")
            If RobotConfigurationValues.DEBUGMODE = True Then
                AVPLib.Log.coreLogger.Info("Leave CheckCG10DifferenceIn_ATM_Mode_FromStation")
                Return True
            End If
            Dim eqmEquiment As Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Source)

            '-	LLx (rough only)  If LLx pressure is lower than LLx cross over  
            '   and TM pressure is lower than TM cross over pressure and  both side CG relay is on 
            '   then open Slit valve between TM and LLx should be allow without the 10% restriction.  
            If (eqmEquiment.Name.Contains("Loadlock") AndAlso Not NeedCheckCGDifference_In_RoughOnly(eqmEquiment.Name)) Then
                Return True
            End If

            Dim objTransferModule As DataManagerment.CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            Try ''check connection exist
                If objTransferModule.KepWareServerDisConnected AndAlso AVPLib.RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                    Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentDisconnect"), "TM PLC"))
                    Return False
                End If
                If (Source.StartsWith(ConstEnum.Chamber)) Then
                    Dim objChamber As Chamber = CType(eqmEquiment, Chamber)
                    If (objChamber.ConnectionStatus <> Equipment.WorkingStatuses.On) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentDisconnect"),
                                         AVPLib.Utils.chamberID2ChamberName(Source)))
                        Return False
                    End If
                End If
                '''ready to check
                Dim whatDiff As Single = 0.3
                Dim TMPressure As Single = 720
                Dim LLorChamberPressure As Single = 720
                ' TM
                TMPressure = IIf(objTransferModule.IGStatus = Equipment.WorkingStatuses.On, objTransferModule.IG, objTransferModule.CG)

                Dim eqmEquipment As Equipment = EquipmentManager.GetEquipment(Source)
                If (eqmEquipment.Name.IndexOf(ConstEnum.Chamber) >= 0) Then
                    Dim objChamber As Chamber = CType(eqmEquipment, Chamber)
                    LLorChamberPressure = IIf(objChamber.IGStatus = Equipment.WorkingStatuses.On, objChamber.IG, objChamber.CG)
                Else
                    Dim objLoadlLock As LoadLock = CType(eqmEquipment, LoadLock)
                    LLorChamberPressure = IIf(objLoadlLock.IGStatus = Equipment.WorkingStatuses.On, objLoadlLock.IG, objLoadlLock.CG)
                End If

                Dim PressureDiff As Single = Math.Abs(TMPressure - LLorChamberPressure)
                Dim Max As Single = Math.Max(TMPressure, LLorChamberPressure)

                If (PressureDiff / Max) > whatDiff Then
                    ' Pressure is too high.
                    Return False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckCG10DifferenceIn_ATM_Mode_FromStation")
            Return True
        End Function

        ' whatDiff = 10% = 0.1
        ' TMTransferSetPoint = 0.1, this value is configurable.
        ' LLATransferSetPoint = LLBTransferSetPoint = 0.1, those values are configurable.
        ' PMTransferSetPoint = 0.1, this value is configurable.
        Public Function CheckDiff(
        ByVal TMIonGaugeStatus As Boolean, ByVal TMIonGaugePressure As Single, ByVal TMConvectronGaugePressure As Single,
        ByVal LLorChamberIonGaugeStatus As Boolean, ByVal LLorChamberIonGaugePressure As Single, ByVal LLOrChamberConvectronGaugePressure As Single,
        ByVal whatDiff As Single, ByVal bCheckSetPointTransferPresssure As Boolean, ByVal TMTransferSetPointPressure As Single, ByVal LLOrChamberTransferSetPointPressure As Single) As Boolean

            Const ATMPressure As Single = 720
            Const PressureForRelayOn As Single = 0.08

            ' All IG On
            If TMIonGaugeStatus AndAlso LLorChamberIonGaugeStatus Then
                Return True
            End If

            ' All is at ATM.
            If TMConvectronGaugePressure > ATMPressure AndAlso LLOrChamberConvectronGaugePressure > ATMPressure Then
                Return True
            End If

            Dim isTMPressureReachRelayOn As Boolean = (TMConvectronGaugePressure <= PressureForRelayOn)
            Dim isLLorChamberReachRelayOn As Boolean = (LLOrChamberConvectronGaugePressure <= PressureForRelayOn)

            ' All relay On
            If isTMPressureReachRelayOn AndAlso isLLorChamberReachRelayOn Then
                Return True
            End If

            ' One of relay is On
            If isTMPressureReachRelayOn OrElse isLLorChamberReachRelayOn Then
                Return False
            End If

            ' Check pressure difference
            Dim pressureDiff As Single = Math.Abs(TMConvectronGaugePressure - LLOrChamberConvectronGaugePressure)
            Dim pressureMax As Single = Math.Max(TMConvectronGaugePressure, LLOrChamberConvectronGaugePressure)

            If (pressureDiff / pressureMax) > whatDiff Then
                Return False
            End If

            Return True
        End Function

        Public Function NeedCheckCGDifference_In_RoughOnly(ByVal sLoadlockName As String) As Boolean
            Dim blResult As Boolean = True
            Try
                Dim objLoadlock As LoadLock = EquipmentManager.GetEquipment(sLoadlockName)
                Dim objTM As CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)

                If (objLoadlock IsNot Nothing AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED = False) Then
                    If (objLoadlock.VacSwitchStatus = Equipment.WorkingStatuses.On AndAlso
                    objTM.VacSwitchStatus = Equipment.WorkingStatuses.On AndAlso
                    objLoadlock.CG <= objLoadlock.FastRoughPressureSetPoint AndAlso
                    objTM.CG <= VentPumdownLib.TMPumpdownConfig.TMRoughPressure) Then
                        Return False
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function

        Public Function IsOK_2OpenPMSlitValve(ByVal ChamberName As String) As Boolean
            Dim objchamber As Chamber = EquipmentManager.GetEquipment(ChamberName)
            If objchamber.IsProcessRunning Then
                Return False
            End If
            Dim objSysModule As SystemModule = ContainerData.GetRobotConfig(ChamberName)
            If objSysModule.Type = SystemModule.ModuleType.PVD AndAlso
                CType(objchamber, PVDChamber).Plasma_Status_Readback = Equipment.WorkingStatuses.On Then
                Return False
            End If
            Return True
        End Function
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> June 15 2009 </date>
        ''' </author>
        ''' <summary>
        ''' Check the condition to open the TM IsolationValve
        ''' true if meet the condition 
        ''' </summary>
        ''' <remarks></remarks>
        ''' strEquipmentName is the name of equipment will be compared the difference ex(LoadLock, or Chamber)
        Public Function CheckCondition2OpenTMIsolationValve(ByVal strEquipmentName As String, ByVal bCycleInATMMode As Boolean, Optional ByRef strErrorMsg As String = "") As Boolean
            AVPLib.Log.coreLogger.Info("Enter checkCondition2OpenTMIsolationValve")
            Dim blRet As Boolean = False
            'Check CG of TM and related equipment no differ 10%
            Dim strPressureError As String = String.Empty
            blRet = CheckCG10DifferenceFromStation(strEquipmentName, False, bCycleInATMMode, strPressureError, False)
            If String.IsNullOrEmpty(strPressureError) = False Then
                Me.ThrowAlarm(strPressureError)
            End If
            AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenTMIsolationValve" + blRet.ToString())
            strErrorMsg = strPressureError
            Return blRet
        End Function
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2012-06-01</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        Public Sub TurnOnOffProtectedMode(ByVal isTurnOn As Boolean)
            AVPLib.Log.avpLogger.Debug("Leave TurnOnOffProtectedMode")
            Try
                Dim objTransferModule As DataManagerment.CassettesModule =
                            EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                Dim objLLA As DataManagerment.LoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())

                If (objLLA IsNot Nothing) Then
                    objLLA.OverideModeStatus = IIf(isTurnOn, Equipment.WorkingStatuses.On, Equipment.WorkingStatuses.Off)
                End If

                If (objTransferModule IsNot Nothing) Then
                    If (isTurnOn) Then
                        objTransferModule.OverideModeStatus = Equipment.WorkingStatuses.On
                    Else
                        objTransferModule.OverideModeStatus = Equipment.WorkingStatuses.Off
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.avpLogger.Debug("Leave TurnOnOffProtectedMode")
        End Sub

        ''' <author>
        '''    	<name>Kiet Tran</name>
        '''    	<date> 2026-04-23 </date>
        ''' </author>
        ''' <summary>
        ''' Check if LLA is rough only mode
        ''' </summary>
        Private Shared Function IsLLARoughOnlyMode() As Boolean

            AVPLib.Log.seqLogger.Info("Enter IsLLARoughOnlyMode")
            Dim result As Boolean = False

            Try
                Dim objectLoadLock As DataManagerment.LoadLock = EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                If objectLoadLock IsNot Nothing AndAlso objectLoadLock.IsRoughOnlyMode() Then
                    result = True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.seqLogger.Info("Leave IsLLARoughOnlyMode")
            Return result
        End Function
#End Region

#Region "private methods"
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2014-08-27</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <remarks></remarks>
        Private Function SafetyTurnIGOnOff(ByVal bOn As Boolean) As String
            AVPLib.Log.coreLogger.Info("Enter SafetyTurnIGOnOff")
            Dim strError As String = String.Empty
            Try
                With m_objTransferModule
                    If .OverideModeStatus <> Equipment.WorkingStatuses.On AndAlso bOn Then
                        If .HiVacValveStatus <> Equipment.WorkingStatuses.On Then
                            strError = "Hivac Is Not Open."
                        ElseIf m_objTransferModule.CG_Communication <> Equipment.WorkingStatuses.On Then
                            strError = "CG is disconnected."
                        ElseIf .VacSwitchStatus <> Equipment.WorkingStatuses.On Then
                            strError = "CG Relay Is Not On"
                        End If

                        'Exit function
                        If Not String.IsNullOrEmpty(strError) Then
                            Return strError
                        End If
                    End If
                End With

                If bOn Then
                    strError = TMCryoUtility.TurnOnIG(Me.EquipmentName)
                Else
                    strError = TMCryoUtility.TurnOffIG(Me.EquipmentName)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SafetyTurnIGOnOff")
            Return strError
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-07-07 </date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        Public Function SafetySwitchIGFilament1() As String
            AVPLib.Log.coreLogger.Info("Enter SafetySwitchIGFilament1")
            Dim strError As String = String.Empty
            Dim isTurnOn As Boolean = False
            Try
                ''Check and turn off IG.
                If m_objTransferModule.IGStatus = Equipment.WorkingStatuses.On Then
                    isTurnOn = True
                    strError = SafetyTurnIGOnOff(False)
                    If String.IsNullOrEmpty(strError) AndAlso Not Utils.WaitOnCondition(AddressOf IsTMIGOffCond, 10000, m_EventStopThread) Then
                        strError = "Failed to turn off TM IG"
                    End If

                End If

                ''Switcht IGFilement1
                If String.IsNullOrEmpty(strError) Then
                    strError = TMCryoUtility.SwitchIGFilament1()
                End If

                ''Wait IGFilement1
                If String.IsNullOrEmpty(strError) AndAlso m_objTransferModule.IGStatus = Equipment.WorkingStatuses.Off Then
                    m_EventStopThread.Reset()

                    If Not Utils.WaitOnCondition(AddressOf IsTMIGFilament1Cond, 10000, m_EventStopThread) Then
                        strError = "Failed to switch TM IG Filament 1"
                    End If

                End If

                ''Turn on IG
                If String.IsNullOrEmpty(strError) AndAlso isTurnOn Then
                    strError = SafetyTurnIGOnOff(True)
                    m_EventStopThread.Reset()

                    If String.IsNullOrEmpty(strError) AndAlso Not Utils.WaitOnCondition(AddressOf IsTMIGOnCond, 30000, m_EventStopThread) Then
                        strError = "Failed to turn on TM IG"
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SafetySwitchIGFilament1")
            Return strError
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-07-07 </date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        Public Function SafetySwitchIGFilament2() As String
            AVPLib.Log.coreLogger.Info("Enter SafetySwitchIGFilament2")
            Dim strError As String = String.Empty
            Dim isTurnOn As Boolean = False
            Try
                ''Check and turn off IG.
                If m_objTransferModule.IGStatus = Equipment.WorkingStatuses.On Then
                    isTurnOn = True
                    strError = SafetyTurnIGOnOff(False)
                    If String.IsNullOrEmpty(strError) AndAlso Not Utils.WaitOnCondition(AddressOf IsTMIGOffCond, 10000, m_EventStopThread) Then
                        strError = "Failed to turn off TM IG"
                    End If
                End If

                ''Switcht IGFilement2
                If String.IsNullOrEmpty(strError) Then
                    strError = TMCryoUtility.SwitchIGFilament2()
                End If

                ''Wait IGFilement2
                If String.IsNullOrEmpty(strError) AndAlso m_objTransferModule.IGStatus = Equipment.WorkingStatuses.Off Then
                    m_EventStopThread.Reset()

                    If Not Utils.WaitOnCondition(AddressOf IsTMIGFilament2Cond, 10000, m_EventStopThread) Then
                        strError = "Failed to switch TM IG Filament 2"
                    End If

                End If

                ''Turn on IG
                If String.IsNullOrEmpty(strError) AndAlso isTurnOn Then
                    strError = SafetyTurnIGOnOff(True)
                    m_EventStopThread.Reset()

                    If String.IsNullOrEmpty(strError) AndAlso Not Utils.WaitOnCondition(AddressOf IsTMIGOnCond, 30000, m_EventStopThread) Then
                        strError = "Failed to turn on TM IG"
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SafetySwitchIGFilament2")
            Return strError
        End Function

        ''' <author>Hai Tran</author>
        ''' <date>2016-03-24</date>
        ''' <summary>
        ''' Cancel manual transfer.
        ''' </summary>
        Private Sub CancelMove()
            AVPLib.Log.avpLogger.Debug("Enter CancelMove")
            Try
                Dim avpProcessJob As AVPLib.Business.AVPProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJobRunning()
                If avpProcessJob IsNot Nothing AndAlso Not avpProcessJob.IsAutoTransfer Then
                    If avpProcessJob.IsRunning Then
                        avpProcessJob.IsCancelMove = True
                    Else
                        avpProcessJob.OnAbortJob()
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.avpLogger.Debug("Leave CancelMove")
        End Sub
#End Region

        Public Sub New()
            ' Routine Runner
            m_RoutineExecutor = New TMRoutineExecutor(Me)
            m_RecoverPressureRoutineExecutor = New TMRecoverPressureRoutineExecutor(Me)
            m_objTransferModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())

            m_hashTableIsoValveThread = New Hashtable()
            m_hashTableIsoValveThread.Add(ConstEnum.SPLIT_VALVE_LLA, New TMIsolationValveThread(Me))
            m_hashTableIsoValveThread.Add(ConstEnum.SPLIT_VALVE_PM1, New TMIsolationValveThread(Me))
            m_hashTableIsoValveThread.Add(ConstEnum.SPLIT_VALVE_PM2, New TMIsolationValveThread(Me))
            m_hashTableIsoValveThread.Add(ConstEnum.SPLIT_VALVE_PM3, New TMIsolationValveThread(Me))
        End Sub

#Region "ThrowAlarm"
        Public Sub ThrowAlarm(ByVal strMessage As String, Optional ByVal strAlarmSubName As String = "")
            Dim strSubName As String = strAlarmSubName
            If String.IsNullOrEmpty(strSubName) Then
                strSubName = AVPLib.ConstEnum.GEM_ALARM_SUB_COMMON_ALARM
            End If
            Dim strGemAlarmName = Utils.GemGetAlarmName(Me.EquipmentName, strSubName)
            Utils.ThrowAlarm(strMessage, strGemAlarmName)
        End Sub
#End Region
    End Class
End Namespace