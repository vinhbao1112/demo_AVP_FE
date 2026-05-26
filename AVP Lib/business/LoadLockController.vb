Imports System.Threading
Imports AVPLib.DataManagerment
Imports AVPLib.ConstEnum
Namespace Business
    Public Class LoadLockController
        Inherits ControllerObject
#Region "Class Constants & Variables"
        Private trdAutoVent As Thread
        Private trdPumpDown As Thread
        Private trdToolOnline As Thread
        Private m_isShowAlarmWhenOnline As Boolean = False
        Private trdUnLoadAfterProcessingCompleted As Thread

        Private trdLoad As Thread
        Private trdUnLoad As Thread
        Private m_EventStopThread As ManualResetEvent = New ManualResetEvent(False)
        Private m_strLotID As String
        Private m_strSequenceID As String
        Private m_strCtrlJobId As String

        Private m_blnOpenSlowVent As Boolean = False
        Private m_blnOpenFastVent As Boolean = False
        Private m_blnOpenSlowRough As Boolean = False
        Private m_blnOpenFastRough As Boolean = False
        Private m_blnOpenHivac As Boolean = False
        Private m_RoutineExecutor As LLRoutineExecutor = Nothing
        Private m_RecoverPressureRoutineExecutor As LLRecoverPressureRoutineExecutor = Nothing
        Private m_blnOpenForeline As Boolean = False
        Private m_blnTurnOnTurbo As Boolean = False

        Private m_blnIsVentRunning As Boolean = False
        Private m_blnIsPumpDownRunning As Boolean = False
        'Add new Properties 05-05-2015 Nguyen Dy
        Private m_blnIsLoadSeqRunning As Boolean = False
        Private m_blnIsUnloadSeqRunning As Boolean = False
        ''''''
        Private m_strEQName4User As String = String.Empty
        Private m_strPumpDownFailed As String = ". PumpDown failed "
        Protected m_objLoadLock As DataManagerment.LoadLock = Nothing
        Private m_IsPumpdownConpleted As Boolean = False
        Private m_IsVentCompleted As Boolean = False
        Private m_TimerMonitorManualDoorOpenWhenVent As System.Timers.Timer = Nothing
        Private m_HasStopAutoVentPumpdownByMonitorManualDoorTimer As Boolean = False
        Private m_CGMultiFactor As Double = 0.7
#End Region

#Region "Property"
        Public ReadOnly Property IsReadyToMap() As Boolean
            Get
                If (Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString) Then
                    Return LLAMonitorCGPressureThread.ReadyToMap
                End If
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

        Public ReadOnly Property IsLoadSeqRunning() As Boolean
            Get
                Return m_blnIsLoadSeqRunning
            End Get
        End Property

        Public ReadOnly Property IsUnloadSeqRunning() As Boolean
            Get
                Return m_blnIsUnloadSeqRunning
            End Get
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current LotID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LotID() As String
            Get
                Return m_strLotID
            End Get
            Set(ByVal value As String)
                m_strLotID = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current SequenceID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SequenceID() As String
            Get
                Return m_strSequenceID
            End Get
            Set(ByVal value As String)
                m_strSequenceID = value
            End Set
        End Property

        Public ReadOnly Property CtrlJobId() As String
            Get
                Return m_strCtrlJobId
            End Get
        End Property

        Public ReadOnly Property ObjectLoadLock() As DataManagerment.LoadLock
            Get
                Return EquipmentManager.GetEquipment(Me.EquipmentName)
            End Get
        End Property

        Public ReadOnly Property EQName4UserReading() As String
            Get
                Return m_strEQName4User
            End Get
        End Property

        Public ReadOnly Property ObjectRoughPumpMachine() As DataManagerment.RoughPumpMachine
            Get
                Return CType(DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName), _
                                                                                DataManagerment.RoughPumpMachine)
            End Get
        End Property

#End Region

#Region "Constructor & Destructor"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Initialize load lock controler
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal LoadLockName As String)
            Try
                EquipmentName = LoadLockName
                ' Routine Runner
                m_RoutineExecutor = New LLRoutineExecutor(Me)
                m_RecoverPressureRoutineExecutor = New LLRecoverPressureRoutineExecutor(Me)

                If LoadLockName = LoadLockA_STR Then
                    m_strEQName4User = ONLINELOADLOCKA
                End If
                m_objLoadLock = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

#End Region

#Region "Public methods"
        Public ReadOnly Property CurrentRoutineExecutor() As LLRoutineExecutor
            Get
                Return m_RoutineExecutor
            End Get
        End Property

        Public ReadOnly Property CurrentRecoverPressureRoutineExecutor() As LLRecoverPressureRoutineExecutor
            Get
                Return m_RecoverPressureRoutineExecutor
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
                If (ObjectLoadLock IsNot Nothing AndAlso ObjectLoadLock.IsIGInstalled) Then
                    Dim strErrMsg As String = LLCryoUtility.TurnOffIG(Me.EquipmentName)
                    If strErrMsg <> String.Empty Then
                        blResult = False
                    Else
                        blResult = True
                    End If
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
                'Finish LLElevator
                Dim ctlElevator As LLElevatorController = CType(m_htbChildController.Item("LLElevator"), LLElevatorController)
                ctlElevator.Abort()
                'Set OpertionStatus is Ready to finishProcesstion.
                Dim objElevator As ControllerObject = Me.ChildController.Item("LLElevator")
                Dim Elevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(objElevator.EquipmentName)
                Elevator.Abort()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Dispose")
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
                Dim objLLPumpPackageCtrl As PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString())

                If objLLPumpPackageCtrl IsNot Nothing AndAlso objLLPumpPackageCtrl.DisplayName = ConstEnum.Equipments.LLACryo.ToString() Then
                    Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(objLLPumpPackageCtrl.EquipmentName.ToString())
                    If objCryo IsNot Nothing AndAlso objCryo.RegenStatus = Equipment.WorkingStatuses.On Then
                        ThrowAlarm("Can Not Start " & Me.EquipmentName & " " & m_RoutineExecutor.ActiveRoutine.ToString() & " Because Cryo Is Regening.")
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
                ' RemoveHandler m_RoutineExecutor.OnDataCollect, AddressOf ???
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopRateOfRise")
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
                Dim objLLPumpPackageCtrl As PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString())

                If objLLPumpPackageCtrl IsNot Nothing AndAlso objLLPumpPackageCtrl.DisplayName = ConstEnum.Equipments.LLACryo.ToString() Then
                    Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(objLLPumpPackageCtrl.EquipmentName.ToString())
                    If objCryo IsNot Nothing AndAlso objCryo.RegenStatus = Equipment.WorkingStatuses.On Then
                        ThrowAlarm("Can Not Start " & Me.EquipmentName & " " & m_RoutineExecutor.ActiveRoutine.ToString() & " Because Cryo Is Regening.")
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
            AVPLib.Log.coreLogger.Info("Enter StopRateOfRise")
            Try
                m_RoutineExecutor.Terminate()
                m_RoutineExecutor.StopPDC()
                ' RemoveHandler m_RoutineExecutor.OnDataCollect, AddressOf ???
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopRateOfRise")
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

            AVPLib.Log.coreLogger.Warn("Task = " & Message)
            Dim strErrMsg As String = String.Empty

            Dim ctlElevator As LLElevatorController = CType(m_htbChildController.Item("LLElevator"), LLElevatorController)
            Try
                Select Case Message
                    Case "IGDegas On"
                        '''Action item for IGDegas
                        DoIGDegas()
                    Case "IGDegas Off"
                        StopIGDegas()
                    Case "Load"
                        Load()
                    Case "Unload"
                        UnLoad()
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
                    Case "Pause"
                        Pause()
                    Case "Stop"
                        [Stop]()
                    Case "Resume"
                        [Resume]()
                    Case "Abort True"
                        Abort(True)
                    Case "Abort False"
                        Abort(False)
                    Case "Online_NoAlarm"
                        m_isShowAlarmWhenOnline = False
                        Me.Online()
                    Case "Online"
                        m_isShowAlarmWhenOnline = True
                        Me.Online()
                    Case "Offline"
                        Me.Offline()
                    Case "AutoVent"
                        Me.AutoVent()
                    Case "StopAutoVent"
                        Me.StopAutoVentPumpdown()
                    Case "PumpDown"
                        Me.PumpDown()
                    Case "StopPumpDown"
                        Me.StopAutoVentPumpdown()
                    Case "StopLoad"
                        Me.StopLoad()
                    Case "StopUnLoad"
                        Me.StopUnLoad()
                    Case "LLSlowVent On"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = LLCryoUtility.OpenLLSlowVent(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "LLSlowVent Off"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = LLCryoUtility.CloseLLSlowVent(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "LLFastVent On"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = LLCryoUtility.OpenLLFastVent(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "LLFastVent Off"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = LLCryoUtility.CloseLLFastVent(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "LLSlowRough On"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = LLCryoUtility.OpenLLSlowRough(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "LLSlowRough Off"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = LLCryoUtility.CloseLLSlowRough(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "LLFastRough On"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = LLCryoUtility.OpenLLFastRough(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "LLFastRough Off"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = LLCryoUtility.CloseLLFastRough(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "LLHiVac On"
                        strErrMsg = LoadLockUtility.OpenLLHivac(Me.EquipmentName, IIf(m_objLoadLock.OverideModeStatus = Equipment.WorkingStatuses.On, False, True))
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        Else
                            'wait for TM/LLx Hivac On
                            If Utils.WaitOnCondition(AddressOf IsLLHiVacOpenCond, VentPumdownLib.LLPumpdownConfig.LLHivacOpenCloseTimeOut * 1000, Nothing) Then
                                If (m_objLoadLock.VacSwitchStatus = Equipment.WorkingStatuses.On) Then
                                    strErrMsg = LLCryoUtility.TurnOnIG(Me.EquipmentName)
                                    If strErrMsg <> String.Empty Then
                                        Me.ThrowAlarm(strErrMsg)
                                    End If
                                End If
                            End If
                        End If
                    Case "LLHiVac Off"
                        strErrMsg = LoadLockUtility.CloseLLHivac(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        Else
                            ' IG is closed automatically when LL Hivac is closed.
                            strErrMsg = LLCryoUtility.TurnOffIG(Me.EquipmentName)
                            If strErrMsg <> String.Empty Then
                                Me.ThrowAlarm(strErrMsg)
                            End If
                        End If
                    Case "Ion On"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = SafetyTurnIGOnOff(True)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "Ion Off"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = SafetyTurnIGOnOff(False)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "IGFilament1"
                        'Check the result here and raise the Alarm if need
                        strErrMsg = SafetySwitchIGFilament1()
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "IGFilament2"
                        'Check the result here and raise the Alarm if need
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
                    Case "TurboForeLineValve On"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = LLCryoUtility.OpenLLTurboForeLineValve(Me.EquipmentName, IIf(m_objLoadLock.OverideModeStatus = Equipment.WorkingStatuses.On, False, True), True)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "TurboForeLineValve Off"
                        'TODO: Check the result here and raise the Alarm if need
                        strErrMsg = LLCryoUtility.CloseLLTurboForeLineValve(Me.EquipmentName)
                        If strErrMsg <> String.Empty Then
                            Me.ThrowAlarm(strErrMsg)
                        End If
                    Case "Turbo On"
                        Dim objPumpPackageCtrl As TurboController = DirectCast(GetObjPumpPackageCtrl(), TurboController)
                        If objPumpPackageCtrl IsNot Nothing Then
                            objPumpPackageCtrl.TurnOnOff(True, ObjectLoadLock.TurboForelineCGRelay)
                        End If
                    Case "Turbo Off"
                        Dim objPumpPackageCtrl As TurboController = DirectCast(GetObjPumpPackageCtrl(), TurboController)
                        If objPumpPackageCtrl IsNot Nothing Then
                            objPumpPackageCtrl.TurnOnOff(False, ObjectLoadLock.TurboForelineCGRelay)
                        End If
                    Case Else
                        If Message.StartsWith("StartScheduler") Then
                            Dim strValue As String = Utils.ParseValue(Message)
                            If (Not String.IsNullOrEmpty(strValue)) Then
                                Dim charSeparators() As Char = {","c}
                                Dim pos As Integer = strValue.IndexOf(charSeparators)
                                If pos > 0 Then
                                    m_strLotID = strValue.Substring(0, pos)
                                    m_strSequenceID = strValue.Substring(pos + 1)
                                    Me.Start()
                                End If
                            End If
                        ElseIf Message.StartsWith("Elevator.") Then
                            ctlElevator.DoTask(Message)
                        ElseIf (Message.IndexOf("GoToSlot") > -1) Then
                            ctlElevator.DoTask(Message)
                        ElseIf Message.StartsWith("SetCGTripPoint") Then
                            Dim strValue As String = Utils.ParseValue(Message)
                            strErrMsg = ChamberUtility.SetCGTripPoint(Me.EquipmentName, String.Format(SET_TRIP_POINT & " " & strValue))
                            If strErrMsg <> String.Empty Then
                                Me.ThrowAlarm(strErrMsg)
                            End If
                        ElseIf Message.StartsWith("SetTurboCGTripPoint") Then
                            Dim strValue As String = Utils.ParseValue(Message)
                            strErrMsg = ChamberUtility.SetTurboCGTripPoint(Me.EquipmentName, String.Format(SET_TRIP_POINT & " " & strValue))
                            If strErrMsg <> String.Empty Then
                                Me.ThrowAlarm(strErrMsg)
                            End If
                        End If
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub
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
                Dim Online As Boolean = Me.CheckOnline()
                Me.RaiseFinishOnline(Online)
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
        ''' LLAOnline
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckOnline() As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckOnline")
            Dim strEquipmentName As String = String.Empty
            Try
                Dim loadLock As DataManagerment.LoadLock = EquipmentManager.GetEquipment(Me.EquipmentName)
                If loadLock.Name = LoadLockA_STR Then
                    strEquipmentName = ONLINELOADLOCKA
                End If
                Utils.ShowStatusMessage(strEquipmentName & " is available...")
                'REMOVE "HIVAC MUST BE OPEN" AND "IG ON" CONDITION WHEN BRINGING LLA/LLB ONLINE-==================
                'THE REASON,  LLA/LLB IS VENTED AND LLA/LLB OFFLINE, WE CANNOT BRING IT BACK ONLINE UNLESS WE PUMP DOWN LLA/LLB OR DO LOAD. 
                'Is Hivac Valve Open
                'If m_EventStopThread.WaitOne(0, True) Then
                '    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                '    Utils.ShowStatusMessage(strEquipmentName & LOADLOCK_OFFLINE)
                '    Return False
                'End If
                'If Not loadLock.HiVacValveStatus = DataManagerment.Equipment.WorkingStatuses.On Then
                '    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("HivacValveDidNotOpen"), Me.EquipmentName))
                '    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                '    Utils.ShowStatusMessage(strEquipmentName & LOADLOCK_OFFLINE)
                '    Return False
                'End If
                ''Is IG On
                'If m_EventStopThread.WaitOne(0, True) Then
                '    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                '    Utils.ShowStatusMessage(strEquipmentName & LOADLOCK_OFFLINE)
                '    Return False
                'End If
                'If Not loadLock.IGStatus = DataManagerment.Equipment.WorkingStatuses.On Then
                '    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("IGDidNotOn"), Me.EquipmentName))
                '    Utils.ShowStatusMessage(strEquipmentName & LOADLOCK_OFFLINE)
                '    Return False
                'End If
                '================================================================
                'Is Base Pressure Reach?
                'If m_EventStopThread.WaitOne(0, True) Then
                '    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                '    Utils.ShowStatusMessage(strEquipmentName & LOADLOCK_OFFLINE)
                '    Return False
                'End If
                'Dim Pressure As Double = ContainerData.GetPressureConfig(Me.EquipmentName)
                '' Base Pressure Reach means <= a base value. 
                'If Not (loadLock.Pressure <= Pressure) Then
                '    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("BasePressureDidNotReach"), Me.EquipmentName))
                '    AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                '    Utils.ShowStatusMessage(strEquipmentName & LOADLOCK_OFFLINE)
                '    Return False
                'End If
                Utils.ShowStatusMessage(strEquipmentName & " is available")
                Return True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckOnline")
            Return False
        End Function
#End Region

#Region "AutoVent"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' StopAutoVent
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StopAutoVentPumpdown()
            AVPLib.Log.coreLogger.Info("Enter StopAutoVent")
            Try
                RaiseFinishPumpDown()
                m_EventStopThread.Set()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
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
        Public Sub AutoVent()
            AVPLib.Log.coreLogger.Info("Enter AutoVent")
            Try
                RaiseStartAutoVent()
                trdAutoVent = New Thread(AddressOf AutoVentProc)
                m_EventStopThread.Reset()
                trdAutoVent.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
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

                'ChangeLoadUnloadStatus(False, True)
                'ChangeLoadUnloadStatus(False, False)

                Dim strErrorMsg As String = String.Empty
                Dim AutoVent As Boolean = False
                If (CheckPressureCommunication(strErrorMsg)) Then
                    If Utils.CheckRateOfRaiseIsRunning(Me.EquipmentName, STR_SEQUENCE_AUTO_VENT) Then

                        AutoVent = Me.CheckAutoVent()

                        If AutoVent = False Then
                            ''Update GEM
                            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                                          VALUELib.ValueType.U1, ConstEnum.LoadLockState.ERROR)
                        Else
                            ''Update GEM
                            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                                          VALUELib.ValueType.U1, ConstEnum.LoadLockState.IDLE)

                        End If
                    End If
                Else
                    Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_VENT_FAILED)
                    m_EventStopThread.WaitOne(1000, True)
                End If

                Me.RaiseFinishAutoVent()

                ChangeLoadUnloadStatus(True, True)
                ChangeLoadUnloadStatus(True, False)
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : THE THREAD PROCESSING AUTO VENT IS OVER.")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave AutoVentProc")
        End Sub
        ''' <author>
        '''    	<name>Tinh Le</name>
        '''    	<date> 2022-09-12</date>
        ''' </author>
        ''' <summary>
        ''' Run Auto Vent After Processing Completed
        ''' </summary>
        Public Sub RunAutoVentAfterProcessingCompleted()
            AVPLib.Log.coreLogger.Info("Enter RunAutoVentAfterProcessingCompleted")
            Try
                m_EventStopThread.Reset()
                Thread.Sleep(200)
                trdUnLoadAfterProcessingCompleted = New Thread(AddressOf AutoVentAfterProcessingCompletedProc)
                trdUnLoadAfterProcessingCompleted.Start()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RunAutoVentAfterProcessingCompleted")
        End Sub
        ''' <author>
        '''    	<name>Tinh Le</name>
        '''    	<date> 2022-09-12</date>
        ''' </author>
        ''' <summary>
        ''' Support autovent when processing completed
        ''' delay x minute and start auto unload
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub AutoVentAfterProcessingCompletedProc()
            AVPLib.Log.coreLogger.Info("Enter RunAutoVent")
            Try
                Dim delayTimeInMiliseconds As Integer = 5000 'default = 5s
                Dim delayTimeInMinute As Single = 0.0F
                Single.TryParse(AVPLib.ContainerDAO.DelayTimeAfterProcessComplete, delayTimeInMinute)
                delayTimeInMiliseconds = delayTimeInMinute * 60 * 1000

                'config < default
                If (delayTimeInMiliseconds < 5000) Then
                    delayTimeInMiliseconds = 5000
                End If

                'Has terminal request
                If (m_EventStopThread.WaitOne(delayTimeInMiliseconds, True)) Then
                    AVPLib.Log.avpLogger.Error("Abort Auto Vent after processing completed")
                    Exit Sub
                Else
                    AVPLib.Log.avpLogger.Error("Start Auto Vent after processing completed")
                    UnLoad()
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RunAutoVent")
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
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-07-04</date>
        ''' </author>
        ''' <summary>
        ''' Raise Finish AutoVent
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub RaiseStartAutoVent()
            AVPLib.Log.coreLogger.Info("Enter RaiseFinishAutoVent")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()

                ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.On)

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
        ''' Load Lock AutoVent
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckAutoVent() As Boolean
            AVPLib.Log.seqLogger.Info("Enter CheckAutoVent")
            Try
                Dim hasStartMonitorManualDoor As Boolean = False
                Dim strCheckAutoVentFailed As String = ". Auto Vent failed "
                Dim ctlRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objTM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)

                Dim blnCloseAllValve As Boolean = False
                Dim Milliseconds As Integer = 0
                Dim strErrMsg As String = String.Empty
                m_blnIsVentRunning = True
                Utils.ShowStatusMessage(EQName4UserReading & " is venting...", STR_SEQUENCE_AUTO_VENT)

                ''Update GEM
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                              VALUELib.ValueType.U1, ConstEnum.LoadLockState.VENTING)


                '-	LLx autovent.  If LLx door is open during autovent,  vent sequence should be completed assume this is manual door.
                Dim serverConfig As Server = Nothing
                If Me.EquipmentName = AVPLib.ConstEnum.LoadLockA_STR Then
                    serverConfig = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ConstEnum.Equipments.LLAElevator.ToString())
                End If
                If serverConfig.IsManualDoorElevator Then

                    Dim objLLElevator As LLElevator = Nothing
                    If Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString() Then
                        objLLElevator = EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                    End If

                    If (objLLElevator IsNot Nothing AndAlso objLLElevator.DCStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                        Utils.ShowStatusMessage(EQName4UserReading & " vent completed", STR_SEQUENCE_AUTO_VENT)
                        AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
                        Return True
                    Else
                        StartMonitorManualDoorOpen()
                        hasStartMonitorManualDoor = True
                    End If
                End If


                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Should close Slow Rough Valve and Fast Rough Valve when start Venting.
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not Close_LLx_Rough_Valve(EQName4UserReading & VENT_ABORTED, strErrMsg, True, m_EventStopThread) Then
                    GoTo Exit_FUNCTION
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''LL Slit valve Open/Unknow?
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCheckLLxIsolationValveClose(strErrMsg, strCheckAutoVentFailed, EQName4UserReading & VENT_ABORTED, STR_SEQUENCE_AUTO_VENT) Then
                    GoTo Exit_FUNCTION
                End If

                If (RobotConfigurationValues.LLA_HIVAC_INSTALLED) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Turn off LL IG - Wait for IG Off
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepTurnOffLLIG_WaitIGOff(strErrMsg, True) Then
                        GoTo Exit_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close LL HiVac Valve()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepCloseLLHivacValve_Wait4LLHivacClose(strErrMsg, True) Then
                        GoTo Exit_FUNCTION
                    End If

                    'wait 2s
                    Milliseconds = Integer.Parse(VentPumdownLib.LLVentConfig.LLSleep2s)
                    Utils.ShowStatusMessage(EQName4UserReading & ": Wait 2s", STR_SEQUENCE_AUTO_VENT)
                    If m_EventStopThread.WaitOne(Milliseconds, True) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If
                End If

                If (RobotConfigurationValues.LL_SLOW_VENT_INSTALLED) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Check LL Soft VentPressure
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not IsLLCGReachSlowVentPressureSetPointCond() Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ' Open LL Soft Vent(valve)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not StepOpenLLSlowVentValve(EQName4UserReading & VENT_ABORTED, strErrMsg) Then
                            blnCloseAllValve = True
                            GoTo Exit_FUNCTION
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'Wait until LL CG > 150 torr. Max wait 3 mins.
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Milliseconds = ObjectLoadLock.SlowVentTimeout * 1000
                        Dim SlowVentPressureSetPoint As Double = ObjectLoadLock.SlowVentPressureSetPoint
                        Utils.ShowStatusMessage(EQName4UserReading & ": Wait LL CG reach " & SlowVentPressureSetPoint.ToString() & _
                                                "torr. Timeout is " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", STR_SEQUENCE_AUTO_VENT)
                        If Not Utils.WaitOnCondition(AddressOf IsLLCGReachSlowVentPressureSetPointCond, AddressOf IsLLCGDisconnected, Milliseconds, m_EventStopThread) Then
                            If Not m_EventStopThread.WaitOne(0, True) Then
                                If (IsLLCGDisconnected()) Then
                                    strErrMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED
                                Else
                                    Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentWaitLLCGSmaller"), Me.EquipmentName, "<", _
                                    SlowVentPressureSetPoint, TimeSpan.FromMilliseconds(Milliseconds).Minutes) & strCheckAutoVentFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_VENT_FAILED)
                                End If
                            End If
                            blnCloseAllValve = True
                            GoTo Exit_FUNCTION
                        Else
                            Utils.ShowStatusMessage(EQName4UserReading & ": Check CG completed", STR_SEQUENCE_AUTO_VENT)
                        End If
                    End If
                    
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Open LL Fast Vent valve.
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenLLFastVentValve_Wait4LLFastVentOpen(EQName4UserReading & VENT_ABORTED, strErrMsg) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Wait until LL CG > 760 torr.  Max wait 5 min.
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = ObjectLoadLock.FastVentTimeout * 1000
                Dim FastVentPressureSetPoint As Double = ObjectLoadLock.FastVentPressureSetPoint
                Utils.ShowStatusMessage(EQName4UserReading & ": Wait LL CG reach Fast Vent Pressure with timeout " & _
                                            TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", STR_SEQUENCE_AUTO_VENT)
                If Not Utils.WaitOnCondition(AddressOf IsLLCGReachFastVentPressureSetPointCond, AddressOf IsLLCGDisconnected, Milliseconds, m_EventStopThread) Then
                    If Not m_EventStopThread.WaitOne(0, True) Then
                        If (IsLLCGDisconnected()) Then
                            strErrMsg = (Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED)
                        Else
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentWaitLLCGSmaller"), Me.EquipmentName, "<", _
                                                        FastVentPressureSetPoint, TimeSpan.FromMilliseconds(Milliseconds).Minutes) & strCheckAutoVentFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_VENT_FAILED)
                        End If
                    End If
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                'Dat Cao add sleep func, continue to vent for another 10s.
                'Thread.Sleep(VentPumdownLib.LLVentConfig.LLVent_Delay_Time)
                Milliseconds = VentPumdownLib.LLVentConfig.LLVent_Delay_Time * 1000
                Utils.ShowStatusMessage(EQName4UserReading & ": Continue to vent. Wait for " & TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", STR_SEQUENCE_AUTO_VENT)
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    CloseActiveVent()
                    'has abort by timer monitor -> return true
                    If (m_HasStopAutoVentPumpdownByMonitorManualDoorTimer) Then
                        AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
                        m_HasStopAutoVentPumpdownByMonitorManualDoorTimer = False
                        Return True
                    Else ' nomal case
                        Utils.ShowStatusMessage(EQName4UserReading & VENT_ABORTED, STR_SEQUENCE_AUTO_VENT)
                        AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
                        Return False
                    End If
                End If

                '0001027: [Khoi Ha - 06/21/2012] - If LLx is autodoor, open door after �autovent after process� complete
                If Not serverConfig.IsManualDoorElevator Then
                    Dim ctlElevator As LLElevatorController = CType(m_htbChildController.Item("LLElevator"), LLElevatorController)
                    ctlElevator.Open()
                End If

                Utils.ShowStatusMessage(EQName4UserReading & ": Vent completed", STR_SEQUENCE_AUTO_VENT)
                Me.CloseActiveVent()
                AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
                Return True
                '
Exit_FUNCTION:

                If (m_EventStopThread.WaitOne(0, True)) Then

                    'has abort by timer monitor -> return true
                    If (m_HasStopAutoVentPumpdownByMonitorManualDoorTimer) Then
                        AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
                        m_HasStopAutoVentPumpdownByMonitorManualDoorTimer = False

                        If blnCloseAllValve Then
                            Me.CloseActiveVent()
                        End If

                        'default auto vent = success
                        Return True

                    Else ' nomal case
                        Utils.ShowStatusMessage(EQName4UserReading & VENT_ABORTED, STR_SEQUENCE_AUTO_VENT)
                    End If

                Else
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg & strCheckAutoVentFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_VENT_FAILED)
                        Utils.ShowStatusMessage(EQName4UserReading & VENT_FAILED, STR_SEQUENCE_AUTO_VENT)
                    End If
                End If

                If blnCloseAllValve Then
                    Me.CloseActiveVent()
                End If
                AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
                Return False
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Utils.ShowStatusMessage(EQName4UserReading & VENT_FAILED, STR_SEQUENCE_AUTO_VENT)
            AVPLib.Log.seqLogger.Info("Leave CheckAutoVent")
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
            AVPLib.Log.seqLogger.Info("Enter CloseActiveVent")
            Dim loadLock As DataManagerment.LoadLock = EquipmentManager.GetEquipment(Me.EquipmentName)
            Dim strErrMsg As String = String.Empty

            If Me.m_blnOpenFastVent Then
                'TODO: Check the result here and raise the Alarm if need
                strErrMsg = LLCryoUtility.CloseLLFastVent(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_VENT_FAILED)
                    AVPLib.Log.seqLogger.Info("Leave CloseActiveVent")
                    Exit Sub
                End If
            End If

            If (RobotConfigurationValues.LL_SLOW_VENT_INSTALLED) Then
                If Me.m_blnOpenSlowVent Then
                    'TODO: Check the result here and raise the Alarm if need
                    strErrMsg = LLCryoUtility.CloseLLSlowVent(Me.EquipmentName)
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_VENT_FAILED)
                        AVPLib.Log.seqLogger.Info("Leave CloseActiveVent")
                        Exit Sub
                    End If
                End If
            End If
            AVPLib.Log.seqLogger.Info("Leave CloseActiveVent")
        End Sub


#End Region

#Region "Pump Down"
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
                Dim objLLPumpPackageCtrl As PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString())

                If objLLPumpPackageCtrl IsNot Nothing AndAlso objLLPumpPackageCtrl.DisplayName = ConstEnum.Equipments.LLACryo.ToString() Then
                    Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(objLLPumpPackageCtrl.EquipmentName.ToString())
                    If objCryo IsNot Nothing AndAlso objCryo.RegenStatus = Equipment.WorkingStatuses.On Then
                        ThrowAlarm("Can Not Start " & Me.EquipmentName & " PumpDown Because Cryo Is Regening.")
                        StopAutoVentPumpdown()
                        Exit Try
                    End If
                End If

                trdPumpDown = New Thread(AddressOf PumpDownProc)
                Me.m_EventStopThread.Reset()
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
                Dim PumpDown As Boolean = False
                Dim strErrorMsg As String = String.Empty
                If (CheckPressureCommunication(strErrorMsg)) Then
                    RaiseStartPumpDown()
                    PumpDown = Me.CheckPumpDown()

                    If PumpDown = False Then
                        ''Update GEM
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                                      VALUELib.ValueType.U1, ConstEnum.LoadLockState.ERROR)
                    Else
                        ''Update GEM
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                                      VALUELib.ValueType.U1, ConstEnum.LoadLockState.READY)
                    End If
                Else
                    Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    m_EventStopThread.WaitOne(1000, True)
                End If

                Me.RaiseFinishPumpDown()
                StopMonitorCGPressure()
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : THE THREAD PROCESSING AUTO PUMPDOWN IS OVER.")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave PumpDownProc")
        End Sub
        Private Sub StopMonitorCGPressure()
            If (Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString) Then
                LLAMonitorCGPressureThread.StopMonitorCGPressure()
            End If
        End Sub
        Private Sub StartMonitorCGPressure()
            If (Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString) Then
                LLAMonitorCGPressureThread.StartMonitorCGPressure(Me.EquipmentName)
            End If
        End Sub

        Private Sub StartMonitorManualDoorOpen()
            Try
                If (m_TimerMonitorManualDoorOpenWhenVent Is Nothing) Then
                    m_TimerMonitorManualDoorOpenWhenVent = New System.Timers.Timer
                    m_TimerMonitorManualDoorOpenWhenVent.Interval = 500
                End If

                m_TimerMonitorManualDoorOpenWhenVent.Enabled = True
                AddHandler m_TimerMonitorManualDoorOpenWhenVent.Elapsed, AddressOf MonitorManualDoorOpen

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        Private Sub MonitorManualDoorOpen(ByVal source As Object, ByVal e As Timers.ElapsedEventArgs)
            Try
                If (ObjectLoadLock IsNot Nothing AndAlso ObjectLoadLock.AutoVentStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    Dim objLLElevator As LLElevator = Nothing
                    If Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString() Then
                        objLLElevator = EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                    End If

                    If (objLLElevator IsNot Nothing AndAlso objLLElevator.DCStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                        m_HasStopAutoVentPumpdownByMonitorManualDoorTimer = True
                        StopAutoVentPumpdown()
                        StopMonitorManualDoorOpen()
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        Private Sub StopMonitorManualDoorOpen()
            Try
                If (m_TimerMonitorManualDoorOpenWhenVent IsNot Nothing) Then
                    m_TimerMonitorManualDoorOpenWhenVent.Enabled = False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
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

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseFinishPumpDown")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-30</date>
        ''' </author>
        ''' <summary>
        ''' Raise start PumpDown event to gui
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RaiseStartPumpDown()
            AVPLib.Log.coreLogger.Info("Enter RaiseStartPumpDown")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()

                ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.On)

                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("PumpDownStatus")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseStartPumpDown")
        End Sub
        Private Function CloseRoughVentValves(ByVal waitTimeInMilliseconds As Integer, ByVal abortedEvent As Threading.ManualResetEvent) As String
            Const ErrAborted As String = "Close Rough and Vent Valves is aborted."
            ' Dim strEquipmentName As String = String.Empty
            Dim strErrMsg As String = String.Empty

            If m_EventStopThread.WaitOne(0, True) Then
                strErrMsg = ErrAborted
                Return strErrMsg
            End If

            strErrMsg = LLCryoUtility.CloseLLFastRough(Me.EquipmentName)
            If strErrMsg <> String.Empty Then
                Return strErrMsg
            End If

            strErrMsg = LLCryoUtility.CloseLLFastVent(Me.EquipmentName)
            If strErrMsg <> String.Empty Then
                Return strErrMsg
            End If

            strErrMsg = LLCryoUtility.CloseLLSlowRough(Me.EquipmentName)
            If strErrMsg <> String.Empty Then
                Return strErrMsg
            End If

            strErrMsg = LLCryoUtility.CloseLLSlowVent(Me.EquipmentName)
            If strErrMsg <> String.Empty Then
                Return strErrMsg
            End If

            Dim span As Int64 = waitTimeInMilliseconds
            Dim start As Int64 = Environment.TickCount
            While (Environment.TickCount - start <= span)
                If abortedEvent.WaitOne(0, False) Then
                    Return ErrAborted
                End If
                ' Check Condition.
                Dim IsFastRoughValveClose As Boolean = True
                Dim IsSlowRoughValveClose As Boolean = True
                Dim IsSlowVentValveClose As Boolean = True
                Dim IsFastVentValveClose As Boolean = True
                ' Verify the LL Fast Rough is OFF
                IsFastRoughValveClose = (ObjectLoadLock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.Off)
                ' Verify the LL Fast Vent is OFF
                IsFastVentValveClose = (ObjectLoadLock.FastVentValveStatus = DataManagerment.Equipment.WorkingStatuses.Off)
                ' Verify the LL Slow Rough is OFF
                IsSlowRoughValveClose = (ObjectLoadLock.SlowRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.Off)
                ' Verify the LL Slow Vent is OFF
                IsSlowVentValveClose = (ObjectLoadLock.SlowVentValveStatus = DataManagerment.Equipment.WorkingStatuses.Off)

                If (Not IsFastRoughValveClose) Then
                    strErrMsg = "Close LL Fast Rough Failed."
                ElseIf (Not IsFastVentValveClose) Then
                    strErrMsg = "Close LL Fast Vent Failed."
                ElseIf (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED AndAlso Not IsSlowRoughValveClose) Then
                    strErrMsg = "Close LL Slow Rough Failed."
                ElseIf (RobotConfigurationValues.LL_SLOW_VENT_INSTALLED AndAlso Not IsSlowVentValveClose) Then
                    strErrMsg = "Close LL Slow Vent Failed."
                Else
                    ' It's ok.
                    Return String.Empty
                End If
            End While

            Return strErrMsg
        End Function

        Private Function IsLLIsoValveCloseCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            If (ObjectLoadLock.Name = Equipments.LoadLockA.ToString()) Then
                Return (objTransferModule.SplitValve1Status = Equipment.WorkingStatuses.Off)
            End If
            Return False
        End Function

        Private Function IsLLIsoValveOpenCond() As Boolean
            Dim objTransferModule As DataManagerment.CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            If (ObjectLoadLock.Name = Equipments.LoadLockA.ToString()) Then
                Return (objTransferModule.SplitValve1Status = Equipment.WorkingStatuses.On)
            End If
            Return False
        End Function

        Public Function IsLLIGOnCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.IGStatus = DataManagerment.Equipment.WorkingStatuses.On)
            End If
        End Function

        Public Function IsLLIGOffCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.IGStatus = DataManagerment.Equipment.WorkingStatuses.Off)
            End If
        End Function

        Public Function IsLLIGFilament1Cond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.SwitchIGFilament = 1)
            End If
        End Function

        Public Function IsLLIGFilament2Cond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.SwitchIGFilament = 2)
            End If
        End Function

        Public Function IsLLHiVacOpenCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
                'loadlock hivac installed
            ElseIf (ObjectLoadLock IsNot Nothing AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED) Then
                Return (ObjectLoadLock.HiVacValveStatus = DataManagerment.Equipment.WorkingStatuses.On)
            Else ' loadlock hivac is not installed 
                Return True
            End If
        End Function
        Public Function IsTurboOnCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
                'loadlock hivac installed
            ElseIf (ObjectLoadLock IsNot Nothing AndAlso RobotConfigurationValues.LLA_TURBO_VISIBLE) Then
                Dim objPumppackage As Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAPumpPackage.ToString)
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
                If ObjectLoadLock Is Nothing Then
                    Return False
                    'loadlock hivac installed
                ElseIf (ObjectLoadLock IsNot Nothing AndAlso RobotConfigurationValues.LLA_TURBO_VISIBLE) Then
                    Dim objPumppackage As Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAPumpPackage.ToString)
                    Return objPumppackage.TurboStatus = False
                Else ' loadlock hivac is not installed
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function

        Public Function IsLLHiVacCloseCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
                'loadlock hivac installed
            ElseIf (ObjectLoadLock IsNot Nothing AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED) Then
                Return (ObjectLoadLock.HiVacValveStatus = DataManagerment.Equipment.WorkingStatuses.Off)
            Else ' loadlock hivac is not installed 
                Return True
            End If
        End Function
        Private Function IsLLSoftRoughValveOpenCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.SlowRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On)
            End If
        End Function

        Public Function IsLLSoftRoughValveCloseCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.SlowRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.Off)
            End If
        End Function

        Private Function IsLLFastRoughValveOpenCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On)
            End If
        End Function

        Public Function IsLLFastRoughValveCloseCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.Off)
            End If
        End Function

        Public Function IsLLSoftVentValveOpenCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.SlowVentValveStatus = DataManagerment.Equipment.WorkingStatuses.On)
            End If
        End Function

        Private Function IsLLSoftVentValveCloseCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.SlowVentValveStatus = DataManagerment.Equipment.WorkingStatuses.Off)
            End If
        End Function

        Public Function IsLLFastVentValveOpenCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.FastVentValveStatus = DataManagerment.Equipment.WorkingStatuses.On)
            End If
        End Function

        Public Function IsLLTurboForelineValveOpenCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.TurboForeLineValveStatus = DataManagerment.Equipment.WorkingStatuses.On)
            End If
        End Function

        Public Function IsLLTurboForelineValveCloseCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.TurboForeLineValveStatus = DataManagerment.Equipment.WorkingStatuses.Off)
            End If
        End Function

        Public Function IsLLCGReachFastVentPressureSetPointCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.CG >= ObjectLoadLock.FastVentPressureSetPoint)
            End If
        End Function

        Public Function IsLLCGReachFastVentPressureSetPointCondToOpenDoor() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.CG >= ObjectLoadLock.FastVentPressureSetPoint * 0.98)
            End If
        End Function

        Private Function IsLLCGReachSlowVentPressureSetPointCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.CG >= ObjectLoadLock.SlowVentPressureSetPoint)
            End If
        End Function

        Private Function IsLLPumpPackageOK() As Boolean
            Try
                Dim objLLPumpPackageCtrl As PumpPackageController = GetObjPumpPackageCtrl()
                Dim strErrorMsg As String = String.Empty
                If objLLPumpPackageCtrl IsNot Nothing Then
                    If objLLPumpPackageCtrl.IsPumpPackageOK(strErrorMsg) Then
                        Return True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return False
        End Function

        Private Function GetObjPumpPackageCtrl() As PumpPackageController
            Dim objLLPumpPackageCtrl As PumpPackageController = Nothing
            Dim strCryoEqpName As String = String.Empty
            Try
                If Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString() Then
                    If RobotConfigurationValues.LLA_CRYO_VISIBLE Or RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                        strCryoEqpName = ConstEnum.Equipments.LLAPumpPackage.ToString()
                    Else
                        Return objLLPumpPackageCtrl
                    End If
                End If
                objLLPumpPackageCtrl = Business.ControllerManager.GetController(strCryoEqpName)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return objLLPumpPackageCtrl
        End Function
        Public Function IsOtherLoadlockKeepOpenRoughValve() As Boolean
            Dim blResult As Boolean = False

            Dim objOtherLoadlock As LoadLock = Nothing

            objOtherLoadlock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)

            If (objOtherLoadlock IsNot Nothing AndAlso (objOtherLoadlock.FastRoughValveStatus = Equipment.WorkingStatuses.On)) Then
                blResult = True
            End If

            Return blResult
        End Function
        '[Khoi Ha 03-05-2013]
        'LL autovent after process completed.   After process complete and before autovent sequence takes place,  
        'there is a 5s windows where �Start�/�Load�/�Unload� button is available for user to click on.   
        'This might cause some problems if user click on load/start while system is trying to autovent.
        Public Function IsUnloadSegRunning() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.UnloadStatus = DataManagerment.Equipment.WorkingStatuses.On)
            End If
        End Function
        Public Function IsLLCGDisconnected() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off)
            End If
        End Function
        Public Function IsLLIGDisconnected() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.IG_Communication = DataManagerment.Equipment.WorkingStatuses.Off)
            End If
        End Function
        Public Function IsLLTurboForelineCGDisconnected() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.TurboForelineCG_Communication = DataManagerment.Equipment.WorkingStatuses.Off)
            End If
        End Function
        'LL MP Disconnect
        Public Function IsLLMechanicalPumpCGDisconnected() As Boolean
            Dim objMechanicalPump As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)
            If (objMechanicalPump IsNot Nothing AndAlso objMechanicalPump.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                Return True
            Else
                Return False
            End If
        End Function

        'LL MP CG Relay On
        Public Function IsLLMechanicalPumpCGReachCrossOverPressureAndCGRelayOnCond() As Boolean
            Dim objMechanicalPump As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)

            If (objMechanicalPump IsNot Nothing) Then
                Return (objMechanicalPump.VacSwitchStatus = Equipment.WorkingStatuses.On AndAlso objMechanicalPump.CG <= VentPumdownLib.TMPumpdownConfig.TMMechanicalPumpOnPressure)
            End If
            Return False
        End Function
        Public Function IsLLMechanicalPumpCGRelayOff() As Boolean
            Dim objMechanicalPump As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)

            If (objMechanicalPump IsNot Nothing) Then
                Return (objMechanicalPump.VacSwitchStatus = Equipment.WorkingStatuses.Off AndAlso objMechanicalPump.CG >= VentPumdownLib.TMPumpdownConfig.TMMechanicalPumpOnPressure)
            End If
            Return False
        End Function
        'LL MP status On
        Public Function IsLLMechanicalPumpOnCond() As Boolean
            Dim bStatusMechnical As Boolean = False
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
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
        'LL MP status On
        Public Function NameLLMechanicalPump() As String
            Dim strNameMechnical As String = String.Empty
            Dim objMechanicalPump As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)

            If (objMechanicalPump IsNot Nothing) Then
                strNameMechnical = objMechanicalPump.Name
            End If
            Return strNameMechnical
        End Function
        'TM MP On
        Public Function IsLLMechanicalPumpOn() As Boolean
            Return (IsLLMechanicalPumpCGDisconnected() = False AndAlso IsLLMechanicalPumpCGReachCrossOverPressureAndCGRelayOnCond() AndAlso IsLLMechanicalPumpOnCond())
        End Function
        Public Function CheckPressureCommunication(Optional ByRef ErrorMsg As String = "") As Boolean
            Dim blResult As Boolean = False
            Try
                If (RobotConfigurationValues.LLA_HIVAC_INSTALLED AndAlso IsLLIGDisconnected()) Then
                    ErrorMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & IG_DISCONNECTED
                    Exit Try
                End If

                If (IsLLCGDisconnected()) Then
                    ErrorMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED
                    Exit Try
                End If

                If (RobotConfigurationValues.LLA_TURBO_VISIBLE AndAlso IsLLTurboForelineCGDisconnected()) Then
                    ErrorMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & TURBOFORELINE_CG_DISCONNECTED
                    Exit Try
                End If

                If (IsLLMechanicalPumpCGDisconnected()) Then
                    ErrorMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & MECHANICAL_PUMP_CG_DISCONNECTED
                    Exit Try
                End If

                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function

        Private Function IsLLCGReachCrossOverPressureAndCGRelayOnCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.CG <= ObjectLoadLock.FastRoughPressureSetPoint) And (ObjectLoadLock.VacSwitchStatus = Equipment.WorkingStatuses.On)
            End If
        End Function
        Public Function IsTurboForelineCGRealyOnCond() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.TurboForelineCGRelay = DataManagerment.Equipment.WorkingStatuses.On)
            End If
        End Function
        Private Function IsOk2OpenHiVacCond() As Boolean
            Return (IsLLCGReachCrossOverPressureAndCGRelayOnCond() And IsLLPumpPackageOK())
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2013-12-3</date>
        ''' </author>
        ''' <summary>
        ''' if (CG*0.9) < Cross Over SP,  hivac is allow to open without alarm
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function IsCGPressureOk2OpenHiVacCond() As Boolean
            Return (((ObjectLoadLock.CG * m_CGMultiFactor) <= ObjectLoadLock.FastRoughPressureSetPoint) And IsLLPumpPackageOK())
        End Function

        Private Function IsLLCGReachSoftRoughPressureSetPoint() As Boolean
            If ObjectLoadLock Is Nothing Then
                Return False
            Else
                Return (ObjectLoadLock.CG <= ObjectLoadLock.SlowRoughPressureSetPoint)
            End If
        End Function

        Public Sub ProcessSafetyInterlock(ByVal brelayForelineOff As Boolean, ByVal terminateEvent As ManualResetEvent)
            If ObjectLoadLock Is Nothing Then
                Exit Sub
            End If
            ' Offline if it's Online.
            If ObjectLoadLock.ControlStatus = Equipment.ControlStatuses.ONLINE Then
                RaiseFinishOnline(False)
            End If

            Dim strErrMsg As String = String.Empty
            'CG relay or disconnect of Foreline
            If brelayForelineOff Then
                'close Foreline valve
                If (ObjectLoadLock.TurboForeLineValveStatus <> Equipment.WorkingStatuses.Off) Then
                    strErrMsg = LLCryoUtility.CloseLLTurboForeLineValve(Me.EquipmentName)
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg)
                    End If
                End If

                Dim objTurboController As TurboController = ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString)
                'turn off turbo
                If objTurboController IsNot Nothing AndAlso (objTurboController.TurnOff) Then
                    If Not Utils.WaitOnCondition(AddressOf IsTurboOffCond, VentPumdownLib.LLPumpdownConfig.LLTurnOffTurboTimeOut * 1000, terminateEvent) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLTurboWasNotOff"), Me.EquipmentName))
                    End If
                End If
            End If
           
            'turn off IG
            If (ObjectLoadLock.IsIGInstalled AndAlso ObjectLoadLock.IGStatus <> Equipment.WorkingStatuses.Off) Then
                strErrMsg = LLCryoUtility.TurnOffIG(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                Else
                    If Not Utils.WaitOnCondition(AddressOf IsLLIGOffCond, VentPumdownLib.LLPumpdownConfig.IGOnOffTimeOut * 1000, terminateEvent) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLIGWasNotOff"), Me.EquipmentName), AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    End If
                End If
            End If
            'Close Hivac
            If (RobotConfigurationValues.LLA_HIVAC_INSTALLED AndAlso ObjectLoadLock.HiVacValveStatus <> Equipment.WorkingStatuses.Off) Then
                strErrMsg = LoadLockUtility.CloseLLHivac(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg)
                Else
                    If Not Utils.WaitOnCondition(AddressOf IsLLHiVacCloseCond, VentPumdownLib.LLPumpdownConfig.LLHivacOpenCloseTimeOut * 1000, terminateEvent) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLHiVacWasNotClose"), Me.EquipmentName))
                    End If
                End If
            End If
        End Sub

        ''' <author>Hai Tran</author>
        ''' <date>2017-05-09</date>
        ''' <summary>
        ''' Turn Off LL IG.
        ''' </summary>
        Public Sub TurnOffIG(ByVal terminateEvent As ManualResetEvent)
            If ObjectLoadLock Is Nothing Then
                Exit Sub
            End If

            If (ObjectLoadLock.IsIGInstalled AndAlso ObjectLoadLock.IGStatus <> Equipment.WorkingStatuses.Off) Then
                Dim strErrMsg As String = LLCryoUtility.TurnOffIG(Me.EquipmentName)

                If Not String.IsNullOrEmpty(strErrMsg) Then
                    Me.ThrowAlarm(strErrMsg, Me.EquipmentName)
                Else
                    If Not Utils.WaitOnCondition(AddressOf IsLLIGOffCond, VentPumdownLib.LLPumpdownConfig.IGOnOffTimeOut * 1000, terminateEvent) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLIGWasNotOff"), Me.EquipmentName))
                    End If
                End If
            End If

        End Sub

        ''' <author>Tinh Le</author>
        ''' <date>2022-08-02</date>
        ''' <summary>
        ''' Close Foreline valve
        ''' </summary>
        Public Sub CloseForelineValve(ByVal terminateEvent As ManualResetEvent)
            If ObjectLoadLock Is Nothing Then
                Exit Sub
            End If

            If (ObjectLoadLock.TurboForeLineValveStatus <> Equipment.WorkingStatuses.Off) Then
                Dim strErrMsg As String = LLCryoUtility.CloseLLTurboForeLineValve(Me.EquipmentName)

                If Not String.IsNullOrEmpty(strErrMsg) Then
                    Me.ThrowAlarm(strErrMsg, Me.EquipmentName)
                Else
                    If Not Utils.WaitOnCondition(AddressOf IsLLTurboForelineValveCloseCond, VentPumdownLib.LLPumpdownConfig.LLOpenCloseForlineTimeOut * 1000, terminateEvent) Then
                        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLForelineWasNotClose"), Me.EquipmentName))
                    End If
                End If
            End If

        End Sub

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-05</date>
        ''' </author>
        ''' <summary>
        ''' Check PumpDown
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckPumpDown() As Boolean
            AVPLib.Log.seqLogger.Info("Enter CheckPumpDown")
            Dim bResult As Boolean = False
            m_IsPumpdownConpleted = False
            Try
                m_blnIsPumpDownRunning = True
                ''Update GEM
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                              VALUELib.ValueType.U1, ConstEnum.LoadLockState.SETUP)

                If EQName4UserReading = ONLINELOADLOCKA AndAlso RobotConfigurationValues.LLA_CRYO_VISIBLE Then
                    bResult = PumpDownWithCryo(STR_SEQUENCE_AUTO_PUMPDOWN)
                ElseIf EQName4UserReading = ONLINELOADLOCKA AndAlso RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                    bResult = PumpDownWithTurbo(STR_SEQUENCE_AUTO_PUMPDOWN)
                Else
                    bResult = PumpDownWithRoughOnly(STR_SEQUENCE_AUTO_PUMPDOWN)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            m_blnIsPumpDownRunning = False
            m_IsPumpdownConpleted = bResult
            AVPLib.Log.seqLogger.Info("Leave CheckPumpDown")
            Return bResult
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-02-05</date>
        ''' </author>
        ''' <summary>
        ''' Close Active Rough
        ''' PumpDown with Rough Only set blIsNeddTurnOffLLIG = False
        ''' </summary>
        ''' <remarks></remarks>
        ''' <modifiers>Van Le</modifiers>
        Private Sub CloseActivePumpDown(Optional ByVal blIsNeedTurnOffLLIG As Boolean = True)
            'Dim loadLock As DataManagerment.LoadLock = EquipmentManager.GetEquipment(Me.EquipmentName)
            AVPLib.Log.seqLogger.Info("Enter CloseActivePumpDown")
            Dim strErrMsg As String = String.Empty
            Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
            Dim objRoughPumpMachine As DataManagerment.RoughPumpMachine = _
                CType(DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName), DataManagerment.RoughPumpMachine)
            '''checking obj exit
            If ObjectLoadLock Is Nothing Then
                Exit Sub
            End If

            '''ready to go
            If Me.m_blnOpenFastRough Then
                'TODO: Check the result here and raise the Alarm if need
                strErrMsg = LLCryoUtility.CloseLLFastRough(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                    Exit Sub
                End If
                Me.m_blnOpenFastRough = False

                ''Van Le remove
                'Wait 2 sec.
                'Threading.Thread.Sleep(VentPumdownLib.LLVentConfig.LLSleep2s)

                'If Not ObjectLoadLock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.Off Then
                '    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLFastRoughWasNotClose"), Me.EquipmentName))
                'Else
                '    Me.m_blnOpenFastRough = False
                'End If

            End If

            ''
            If Me.m_blnOpenSlowRough Then
                If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                    'TODO: Check the result here and raise the Alarm if need
                    strErrMsg = LLCryoUtility.CloseLLSlowRough(Me.EquipmentName)
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                        Exit Sub
                    End If
                    Me.m_blnOpenSlowRough = False
                End If
            End If
            ''Release Rough Line In Use ASAP
            If objRoughPumpMachine IsNot Nothing Then
                objRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                objRoughPumpMachine.ReleaseRoughLineInUse(Me.EquipmentName)
            End If

            'If Me.m_blnOpenHivac Then
            '    If ObjectLoadLock.HiVacValveStatus = DataManagerment.Equipment.WorkingStatuses.Off Then

            '    End If
            '    strErrMsg = LoadLockUtility.CloseLLHivac(Me.EquipmentName)
            '    If strErrMsg <> String.Empty Then
            '        Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
            '        AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
            '        Exit Sub
            '    End If
            '    If Not Utils.WaitOnCondition(AddressOf IsLLHiVacCloseCond, VentPumdownLib.LLPumpdownConfig.LLHivacOpenCloseTimeOut * 1000, m_EventStopThread) Then
            '        Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLHiVacWasNotClose"), Me.EquipmentName), AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
            '        AVPLib.Log.coreLogger.Info("Leave CloseActivePumpDown")
            '        Exit Sub
            '    End If
            '    Me.m_blnOpenHivac = False
            'End If

            If Me.m_blnOpenForeline Then
                strErrMsg = LLCryoUtility.CloseLLTurboForeLineValve(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                    Exit Sub
                End If
                Me.m_blnOpenForeline = False
            End If

            If blIsNeedTurnOffLLIG Then
                If IsLLIGOnCond() Then
                    strErrMsg = LLCryoUtility.TurnOffIG(Me.EquipmentName)
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                        Exit Sub
                    End If
                    If Not Utils.WaitOnCondition(AddressOf IsLLIGOffCond, VentPumdownLib.LLPumpdownConfig.IGOnOffTimeOut * 1000, m_EventStopThread) Then
                        If (Not m_EventStopThread.WaitOne(0, True)) Then
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLIGWasNotOff"), Me.EquipmentName), AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                            AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                            Exit Sub
                        End If
                    End If
                End If
            End If
            If EQName4UserReading = ONLINELOADLOCKA AndAlso RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                Dim strTurboPackage As String = ConstEnum.Equipments.LLAPumpPackage.ToString
                Dim objTurboController As TurboController = ControllerManager.GetController(strTurboPackage)

                If objTurboController IsNot Nothing AndAlso m_blnTurnOnTurbo Then
                    If Not objTurboController.TurnOff() Then
                        Me.ThrowAlarm(Me.EquipmentName & " turn off Turbo failed.", AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")
                        Exit Sub
                    End If
                    Me.m_blnTurnOnTurbo = False
                End If
            End If
            AVPLib.Log.seqLogger.Info("Leave CloseActivePumpDown")

        End Sub

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Check PumpDown
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PumpDownWithCryo(ByVal strSequenceName As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter PumpDownWithCryo")

            Dim objTMController As Business.TMController =
                    CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
            Dim objRoughPumpMachine As DataManagerment.RoughPumpMachine =
                                CType(DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName),
                                                                                DataManagerment.RoughPumpMachine)
            Try
                Dim ctlElevator As ControllerObject = Me.ChildController.Item("LLElevator")
                Dim objLLElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ctlElevator.EquipmentName)
                Dim ctlRobot As RobotController =
                                            CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim blnCloseAllValve As Boolean = False
                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Delay_Time * 1000

                Dim objLoadLock As DataManagerment.LoadLock = EquipmentManager.GetEquipment(Me.EquipmentName)
                Dim objTransferModule As DataManagerment.CassettesModule =
                                                    EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                Dim strErrMsg As String = String.Empty

                Utils.ShowStatusMessage(EQName4UserReading & ": Pumpdown...", strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                If (objRoughPumpMachine Is Nothing) Or (objLLElevator Is Nothing) Or (objRobot Is Nothing) Then
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                    Return False
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Is LL Door Closed -> Alarm
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not (StepCheckLoadlockDoor(strErrMsg)) Then
                    Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                    Return False
                End If
                ' End of step

                StartMonitorManualDoorOpen()

                'wait for make pumpdown highest priority 
                Dim timeout As Integer = VentPumdownLib.LLPumpdownConfig.LLPumpDownComplete * 1000
                If (ObjectRoughPumpMachine IsNot Nothing) AndAlso (Not ObjectRoughPumpMachine.WaitForMakePumpdownHighestPriority(Me.EquipmentName, m_EventStopThread, timeout)) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'STEP: Wait for Rough Pump PM Close if TM shared rough pump with LL
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If RobotConfigurationValues.SHARED_MP_WITH_PM AndAlso
                    Not Utils.WaitForRoughtPMClose(EQName4UserReading & PUMPDOWN_ABORTED, strSequenceName, m_EventStopThread, VentPumdownLib.LLPumpdownConfig.RoughPumpPMTimeOut, strErrMsg, ObjectRoughPumpMachine) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close LL Fast & Soft Rough & Vent(Valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseRoughVentValves(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn On MP
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOnMechanicalPump(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, m_EventStopThread, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Verify LL Slit valve is closed
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCheckLLxIsolationValveClose(strErrMsg, m_strPumpDownFailed, EQName4UserReading & PUMPDOWN_ABORTED, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                'check CG device is disconnected
                'exit sequence
                If (IsLLCGDisconnected()) Then
                    strErrMsg = (Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED)
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''Verify CG < Cross Over Pressure and CG Relay On and Cryo <20k
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If IsOk2OpenHiVacCond() Then
                    GoTo OPEN_HIVAC_STEP
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim blIsHasCloseLLARoughValve As Boolean = False
                Dim blIsHasCloseTMRoughValve As Boolean = False
                If Not Utils.CloseAllOtherRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, blIsHasCloseTMRoughValve) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim blIsHasCloseLLAForelineValve As Boolean = False
                Dim blIsHasCloseTMForelineValve As Boolean = False
                If Not Utils.CloseAllOtherForelineRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, blIsHasCloseTMForelineValve) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn off LL IG
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOffLLIG_WaitIGOff(strErrMsg, False, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close LL HiVac Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseLLHivacValve_Wait4LLHivacClose(strErrMsg, False, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait if other LL or TM PumpDown Running. Timeout = 10mins
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCheckOtherRoughInUse(strErrMsg, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Make Rough Line In Use And Check TM Mechanical Pump CG < 0.1 Torr.
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepWaitMPPressure(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close TM Foreline Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim bCloseTMForelineValve As Boolean = False

                If ObjectRoughPumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString()) Then
                    ''check TM
                    If objTMController IsNot Nothing Then
                        Dim blTMTurboInstall As Boolean = RobotConfigurationValues.TMTURBO_VISIBLE

                        If blTMTurboInstall AndAlso objTMController.IsTMTurboForelineValveOpenCond Then
                            If Not objTMController.StepCloseTMTurboForeline(strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                                blnCloseAllValve = True
                                GoTo Exit_FUNCTION
                            End If
                            bCloseTMForelineValve = True
                        End If
                    End If
                End If

                If bCloseTMForelineValve Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Wait 5s
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves
                    Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                    If m_EventStopThread.WaitOne(Milliseconds, True) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Check Soft Rough Pressure
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not IsLLCGReachSoftRoughPressureSetPoint() Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Open LL Soft Rough(Valve)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepOpenLLSlowRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Wait until LL CG <= 350 torr. Max wait 2 min. -> alarm
                    If Not StepWaitSlowRoughPressure(strSequenceName) Then
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close LL Soft Rough(Valve)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepCloseLLSlowRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, False, m_EventStopThread, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If
                    m_blnOpenSlowRough = False
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open LL Fast Rough Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenLLFastRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait until LL CG < .15 torr. Max wait 15 min.
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepWaitFastRoughPressure(strSequenceName) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If
                ' End of step

                'Dat Cao add sleep func, continue to rough for another 10s.
                'Thread.Sleep(VentPumdownLib.LLPumpdownConfig.LLPumpDown_Delay_Time)
                Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Delay_Time * 1000
                Utils.ShowStatusMessage(EQName4UserReading & ": Continue to rough. Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close LL Fast Rough(Valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseLLFastRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, False, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If
                m_blnOpenFastRough = False

                'If bCloseTMForelineValve Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 5s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open TM Foreline Valve 
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If RobotConfigurationValues.TMTURBO_VISIBLE Then
                    Dim objPumppackage As Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.TMPumpPackage.ToString)
                    If (objPumppackage IsNot Nothing) AndAlso (objPumppackage.TurboUptoSpeed = True) Then
                        If objTMController IsNot Nothing AndAlso Not objTMController.StepOpenTMTurboForeline(strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                            blnCloseAllValve = True
                            GoTo Exit_FUNCTION
                        End If
                    End If
                End If
                'End If

                ' End of step
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Cryo T2 < 15K ? -> alarm
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If m_EventStopThread.WaitOne(0, True) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                If Not IsLLPumpPackageOK() Then
                    Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("T2LoadLockCryoLessThan15K"),
                                     Me.EquipmentName, "<", ObjectLoadLock.CryoColdTemp) & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If
                ' End of step
OPEN_HIVAC_STEP:

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Open LL HiVac Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If Not StepOpenLLHivacValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not Utils.OpenAllOtherRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, blIsHasCloseTMRoughValve) Then
                    If Not String.IsNullOrEmpty(strErrMsg) Then
                        Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not Utils.OpenAllOtherForelineValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, blIsHasCloseTMForelineValve) Then
                    If Not String.IsNullOrEmpty(strErrMsg) Then
                        Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    End If
                End If

                ' Wait for 3s before make pumpdown low priority
                m_EventStopThread.WaitOne(3000, True)

                'Make pumpdown low priority
                If ObjectRoughPumpMachine IsNot Nothing Then
                    ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                End If

                ' End of step
                'Wait for CG Relay ON
                'Thread.Sleep(VentPumdownLib.LLPumpdownConfig.IGOnDelay)
                If m_EventStopThread.WaitOne(VentPumdownLib.LLPumpdownConfig.IGOnDelay * 1000, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                'Turn on LL IG
                If Not StepTurnOnLLIG(strErrMsg, strSequenceName) Then
                    blnCloseAllValve = False
                    GoTo Exit_FUNCTION
                End If

                Utils.ShowStatusMessage(EQName4UserReading & ": Pumpdown completed.", strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                Return True
Exit_FUNCTION:

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Utils.OpenAllOtherRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, blIsHasCloseTMRoughValve)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Utils.OpenAllOtherForelineValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, blIsHasCloseTMForelineValve)

                If blnCloseAllValve Then
                    CloseActivePumpDown()
                End If


                If (m_EventStopThread.WaitOne(0, True)) Then
                    If (m_HasStopAutoVentPumpdownByMonitorManualDoorTimer) Then
                        m_HasStopAutoVentPumpdownByMonitorManualDoorTimer = False
                        strErrMsg = String.Format(ContainerData.GetMessageText("DoorWasNotClose"), Me.EquipmentName)
                        Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                        Return False
                    Else
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                    End If
                Else
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                    End If
                End If

                AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                Return False
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If objRoughPumpMachine IsNot Nothing Then
                    ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                    objRoughPumpMachine.ReleaseRoughLineInUse(Me.EquipmentName)
                End If
            End Try
            AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
            Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
            Return False
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Check PumpDown
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PumpDownWithTurbo(ByVal strSequenceName As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter PumpDownWithTurbo")

            Dim objTMController As Business.TMController =
                    CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
            Try
                Dim blnCloseAllValve As Boolean = False
                Dim ctlElevator As ControllerObject = Me.ChildController.Item("LLElevator")
                Dim objLLElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ctlElevator.EquipmentName)
                '
                Dim objTransferModule As DataManagerment.CassettesModule =
                                                    EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                Dim strErrMsg As String = String.Empty
                Dim objOtherLLController As LoadLockController = Nothing
                Dim blnOtherLLForlineValveClose As Boolean = False
                Dim blnOtherLLSlowRoughValveClose As Boolean = False
                Dim blnOtherLLFastRoughValveClose As Boolean = False
                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves

                'If Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString() Then
                '    objOtherLLController = ControllerManager.GetController(ConstEnum.Equipments.LoadLockB.ToString())
                'Else
                '    objOtherLLController = ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString())
                'End If

                Utils.ShowStatusMessage(EQName4UserReading & ": Pumpdown...", strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                If ObjectRoughPumpMachine Is Nothing Then
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithTurbo")
                    Return False
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Is LL Door Closed -> Alarm
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not (StepCheckLoadlockDoor(strErrMsg)) Then
                    Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                    Return False
                End If
                ' End of step

                StartMonitorManualDoorOpen()

                'wait for make pumpdown highest priority 
                Dim timeout As Integer = VentPumdownLib.LLPumpdownConfig.LLPumpDownComplete * 1000
                If (ObjectRoughPumpMachine IsNot Nothing) AndAlso (Not ObjectRoughPumpMachine.WaitForMakePumpdownHighestPriority(Me.EquipmentName, m_EventStopThread, timeout)) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'STEP: Wait for Rough Pump PM Close if TM shared rough pump with LL
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If RobotConfigurationValues.SHARED_MP_WITH_PM AndAlso
                    Not Utils.WaitForRoughtPMClose(EQName4UserReading & PUMPDOWN_ABORTED, strSequenceName, m_EventStopThread, VentPumdownLib.LLPumpdownConfig.RoughPumpPMTimeOut, strErrMsg, ObjectRoughPumpMachine) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close LL Fast & Soft Rough & Vent(Valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseRoughVentValves(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn On MP
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOnMechanicalPump(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, m_EventStopThread, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Verify LL Slit valve is closed
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCheckLLxIsolationValveClose(strErrMsg, m_strPumpDownFailed, EQName4UserReading & PUMPDOWN_ABORTED, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                'check CG device is disconnected
                'exit sequence
                If (IsLLCGDisconnected()) Then
                    strErrMsg = (Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED)
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Verify CG < Cross over pressure and CG relay on and turn on turbo is up to speed and foreline valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If IsOk2OpenHiVacCond() And IsLLTurboForelineValveOpenCond() Then
                    GoTo OPEN_HIVAC_STEP
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim blIsHasCloseLLARoughValve As Boolean = False
                Dim blIsHasCloseTMRoughValve As Boolean = False
                If Not Utils.CloseAllOtherRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, blIsHasCloseTMRoughValve) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim blIsHasCloseLLAForelineValve As Boolean = False
                Dim blIsHasCloseTMForelineValve As Boolean = False
                If Not Utils.CloseAllOtherForelineRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, blIsHasCloseTMForelineValve) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn off LL IG
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOffLLIG_WaitIGOff(strErrMsg, False, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close LL HiVac Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseLLHivacValve_Wait4LLHivacClose(strErrMsg, False, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Check if other LL PumpDown running. Timeout = 10mins
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCheckOtherRoughInUse(strErrMsg, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait MP#2 Pressure < MP#2 on Pressure. Timeout = 5mins
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepWaitMPPressure(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                If objOtherLLController IsNot Nothing Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close Other LL Foreline Valve
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If objOtherLLController.IsLLTurboForelineValveOpenCond Then
                        If Not objOtherLLController.StepCloseLLTurboForelineValve(strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                            GoTo Exit_FUNCTION
                        End If
                        blnOtherLLForlineValveClose = True
                    End If
                    m_blnOpenForeline = False

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close Other LL Slow Rough Valve
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not objOtherLLController.StepCloseLLSlowRoughValve(EQName4UserReading & PUMPDOWN_ABORTED,
                                                                            strErrMsg, False, m_EventStopThread, strSequenceName) Then
                        GoTo Exit_FUNCTION
                    End If
                    m_blnOpenSlowRough = False

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close Other LL Fast Rough Valve
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not objOtherLLController.StepCloseLLFastRoughValve(EQName4UserReading & PUMPDOWN_ABORTED,
                                                           strErrMsg, False, m_EventStopThread, strSequenceName) Then
                        GoTo Exit_FUNCTION
                    End If
                    m_blnOpenFastRough = False
                End If

                Dim bCloseTMForelineValve As Boolean = False

                If objTMController IsNot Nothing AndAlso
                    ObjectRoughPumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString()) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close TM Foreline Valve
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim blTMTurboInstall = RobotConfigurationValues.TMTURBO_VISIBLE

                    If blTMTurboInstall AndAlso objTMController.IsTMTurboForelineValveOpenCond Then
                        If Not objTMController.StepCloseTMTurboForeline(strErrMsg, EQName4UserReading & ": " & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                            blnCloseAllValve = True
                            GoTo Exit_FUNCTION
                        End If
                        bCloseTMForelineValve = True
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close TM Rough Valve
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not objTMController.StepCloseTMRoughValve(strErrMsg, False, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                        GoTo Exit_FUNCTION
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 5s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Thread.Sleep(VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves)
                Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open Foreline Valve 
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenLLTurboForelineValve(strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait foreline cg relay on
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not WaitForelineCGRelayOn(strErrMsg, m_EventStopThread) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn on Turbo and wait for up to speed signal. Timeout = 20mins
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepLLTurnOnTurbo(strErrMsg, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close Foreline Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseLLTurboForelineValve(strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If
                m_blnOpenForeline = False


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 5s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                    GoTo Exit_FUNCTION
                End If

                '[KHOI HA - 01-04-2013] LL autopump down.   Skip roughing when CG pressure < cross over pressure.
                If Not (IsLLCGReachCrossOverPressureAndCGRelayOnCond()) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Check Soft Rough pressure
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not IsLLCGReachSoftRoughPressureSetPoint() Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'Open LL Soft Rough(Valve)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not StepOpenLLSlowRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                            blnCloseAllValve = True
                            GoTo Exit_FUNCTION
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'Wait until LL CG <= 350 torr. Max wait 2 min. -> alarm
                        If Not StepWaitSlowRoughPressure(strSequenceName) Then
                            Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                            blnCloseAllValve = True
                            GoTo Exit_FUNCTION
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'Close LL Soft Rough(Valve)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not StepCloseLLSlowRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, False, m_EventStopThread, strSequenceName) Then
                            blnCloseAllValve = True
                            GoTo Exit_FUNCTION
                        End If
                        m_blnOpenSlowRough = False
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Open LL Fast Rough Valve
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepOpenLLFastRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Wait until LL CG < .15 torr. Max wait 15 min. 
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepWaitFastRoughPressure(strSequenceName) Then
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If

                    'Dat Cao add sleep func, continue to rough for another 10s.
                    'Thread.Sleep(VentPumdownLib.LLPumpdownConfig.LLPumpDown_Delay_Time)
                    Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Delay_Time * 1000
                    Utils.ShowStatusMessage(EQName4UserReading & ": Continue to rough. Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                    If m_EventStopThread.WaitOne(Milliseconds, True) Then
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                        GoTo Exit_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close LL Fast Rough(Valve)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepCloseLLFastRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, False, m_EventStopThread, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If
                    m_blnOpenFastRough = False
                End If

                'check CG device is disconnected
                'exit sequence
                If (IsLLCGDisconnected()) Then
                    strErrMsg = (Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED)
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turbo is up to speed 
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not IsLLPumpPackageOK() Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Wait 5s
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves
                    Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                    If m_EventStopThread.WaitOne(VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves, True) Then
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)
                        GoTo Exit_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Open Foreline Valve 
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepOpenLLTurboForelineValve(strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Wait foreline cg relay on
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not WaitForelineCGRelayOn(strErrMsg, m_EventStopThread) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Turn on Turbo and wait for up to speed signal. Timeout = 20mins
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepLLTurnOnTurbo(strErrMsg, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'CG < Cross over pressure 
                'CG relay is ON
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not IsLLCGReachCrossOverPressureAndCGRelayOnCond() Then
                    strErrMsg = String.Format(ContainerData.GetMessageText("LLCGSmaller"), Me.EquipmentName, "<", ObjectLoadLock.FastRoughPressureSetPoint)
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

OPEN_HIVAC_STEP:

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 5s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                If m_EventStopThread.WaitOne(VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open ForlineValve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenLLTurboForelineValve(strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not Utils.OpenAllOtherForelineValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, blIsHasCloseTMForelineValve) Then
                    If Not String.IsNullOrEmpty(strErrMsg) Then
                        Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open other ll Foreline Valve if we close in previous step
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If objOtherLLController IsNot Nothing _
                        AndAlso objOtherLLController.IsLLTurboForelineValveCloseCond() _
                        AndAlso blnOtherLLForlineValveClose Then
                    If Not objOtherLLController.StepOpenLLTurboForelineValve(strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                        blnCloseAllValve = False
                        GoTo Exit_FUNCTION
                    End If
                End If

                If objTMController IsNot Nothing Then ' AndAlso bCloseTMForelineValve Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Open TM Foreline Valve if we close in previous step
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If objTMController.IsTurboOnCond Then
                        'wait(5S)
                        If m_EventStopThread.WaitOne(5000, True) Then
                            Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)
                            GoTo Exit_FUNCTION
                        End If

                        If RobotConfigurationValues.TMTURBO_VISIBLE Then
                            Dim objPumppackage As Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.TMPumpPackage.ToString)
                            If (objPumppackage IsNot Nothing) AndAlso (objPumppackage.TurboUptoSpeed = True) Then
                                If Not objTMController.StepOpenTMTurboForeline(strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                                    blnCloseAllValve = False
                                End If
                            End If
                        End If
                    End If
                End If

                'Make pumpdown low priority
                If ObjectRoughPumpMachine IsNot Nothing Then
                    ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Open LL HiVac Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenLLHivacValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                ' End of step
                'Wait 15s
                'Thread.Sleep(VentPumdownLib.LLPumpdownConfig.IGOnDelay)
                Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Open_Hivac
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                    GoTo Exit_FUNCTION
                End If


                'Turn on LL IG
                If Not StepTurnOnLLIG(strErrMsg, strSequenceName) Then
                    blnCloseAllValve = False
                    GoTo Exit_FUNCTION
                End If

                Utils.ShowStatusMessage(EQName4UserReading & ": Pumpdown completed.", strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                AVPLib.Log.seqLogger.Info("Leave PumpDownWithTurbo")
                Return True
Exit_FUNCTION:
                If blnCloseAllValve Then
                    CloseActivePumpDown()
                ElseIf (m_EventStopThread.WaitOne(0, True)) Then
                    CloseActivePumpDown(False)
                End If

                If (m_EventStopThread.WaitOne(0, True)) Then

                    If (m_HasStopAutoVentPumpdownByMonitorManualDoorTimer) Then
                        m_HasStopAutoVentPumpdownByMonitorManualDoorTimer = False
                        strErrMsg = String.Format(ContainerData.GetMessageText("DoorWasNotClose"), Me.EquipmentName)
                        Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                    Else
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)
                    End If

                Else
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                    End If
                End If

                AVPLib.Log.seqLogger.Info("Leave PumpDownWithTurbo")
                Return False
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If ObjectRoughPumpMachine IsNot Nothing Then
                    ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                    ObjectRoughPumpMachine.ReleaseRoughLineInUse(Me.EquipmentName)
                End If
            End Try
            AVPLib.Log.seqLogger.Info("Leave PumpDownWithTurbo")
            Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
            Return False
        End Function
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Check PumpDown
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PumpDownWithRoughOnly(ByVal strSequenceName As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter PumpDownWithRoughOnly")

            Dim objTMController As Business.TMController =
                    CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
            Try
                Dim blnCloseAllValve As Boolean = False

                Dim ctlElevator As ControllerObject = Me.ChildController.Item("LLElevator")
                Dim objLLElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ctlElevator.EquipmentName)
                Dim objTransferModule As DataManagerment.CassettesModule =
                                                    EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                Dim strErrMsg As String = String.Empty
                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves

                Utils.ShowStatusMessage(EQName4UserReading & ": Pumpdown...", strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012

                If (objTMController Is Nothing) Or (objLLElevator Is Nothing) Or (ObjectRoughPumpMachine Is Nothing) Then
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithRoughOnly")
                    Return False
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Is LL Door Closed -> Alarm
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not (StepCheckLoadlockDoor(strErrMsg)) Then
                    Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithCryo")
                    Return False
                End If
                ' End of step

                StartMonitorManualDoorOpen()

                'wait for make pumpdown highest priority 
                Dim timeout As Integer = VentPumdownLib.LLPumpdownConfig.LLPumpDownComplete * 1000
                If (ObjectRoughPumpMachine IsNot Nothing) AndAlso
                    (Not ObjectRoughPumpMachine.WaitForMakePumpdownHighestPriority(Me.EquipmentName, m_EventStopThread, timeout)) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'STEP: Wait for Rough Pump PM Close if TM shared rough pump with LL
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If RobotConfigurationValues.SHARED_MP_WITH_PM AndAlso
                    Not Utils.WaitForRoughtPMClose(EQName4UserReading, strSequenceName, m_EventStopThread, VentPumdownLib.LLPumpdownConfig.RoughPumpPMTimeOut, strErrMsg, ObjectRoughPumpMachine) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close LL Fast & Soft Rough & Vent(Valve)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseRoughVentValves(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Turn On MP
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepTurnOnMechanicalPump(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, m_EventStopThread, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Verify LL Slit valve is closed
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCheckLLxIsolationValveClose(strErrMsg, m_strPumpDownFailed, EQName4UserReading & PUMPDOWN_ABORTED, strSequenceName) Then
                    GoTo Exit_FUNCTION
                End If

                'exit when cg is error
                If (IsLLCGDisconnected()) Then
                    strErrMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Verify CG < Cross over pressure and CG relay on and cryo < 20k
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If IsLLCGReachCrossOverPressureAndCGRelayOnCond() Then
                    GoTo TM_AND_OPEN_HIVAC_LL
                End If
                'If IsOk2OpenHiVacCond() Then
                '    GoTo TM_AND_OPEN_HIVAC_LL
                'End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim blIsHasCloseLLARoughValve As Boolean = False
                Dim blIsHasCloseTMRoughValve As Boolean = False
                If Not Utils.CloseAllOtherRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, blIsHasCloseTMRoughValve) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Close all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim blIsHasCloseLLAForelineValve As Boolean = False
                Dim blIsHasCloseTMForelineValve As Boolean = False
                If Not Utils.CloseAllOtherForelineRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, blIsHasCloseTMForelineValve) Then
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait if other LL or TM PumpDown Running. Timeout = 10mins
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCheckOtherRoughInUse(strErrMsg, strSequenceName) Then
                    'Thread.Sleep(VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_Other_PumpDown)
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait if MP#1 Pressure < MP#1 on Pressure. Timeout = 5mins
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If ObjectRoughPumpMachine IsNot Nothing Then
                    If Not StepWaitMPPressure(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                        GoTo Exit_FUNCTION
                    End If
                Else
                    AVPLib.Log.coreLogger.Info("Leave PumpDownWithRoughOnly")
                    Return False
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait 5s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Thread.Sleep(VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves)
                Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves
                Utils.ShowStatusMessage(EQName4UserReading & ": Wait " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Check Soft Rough Pressure
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not IsLLCGReachSoftRoughPressureSetPoint() Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Open LL Soft Rough(Valve)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepOpenLLSlowRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Wait until LL CG <= 350 torr. Max wait 2 min. -> alarm
                    If Not StepWaitSlowRoughPressure(strSequenceName) Then
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close LL Soft Rough(Valve)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepCloseLLSlowRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, False, m_EventStopThread, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If
                    m_blnOpenSlowRough = False

                    'Dat Cao add sleep func, wait 5s after close soft rough.5s
                    If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                        Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Close_LL_TM_Valves
                        Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for " & Milliseconds / 1000 & "s", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                        If m_EventStopThread.WaitOne(Milliseconds, True) Then
                            blnCloseAllValve = True
                            GoTo Exit_FUNCTION
                        End If
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open LL Fast Rough Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenLLFastRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Wait until LL CG < .15 torr. Max wait 15 min.
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepWaitFastRoughPressure(strSequenceName) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                'Dat Cao add sleep func, continue to rough for another 10s.
                'Thread.Sleep(VentPumdownLib.LLPumpdownConfig.LLPumpDown_Delay_Time)
                Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Delay_Time * 1000
                Utils.ShowStatusMessage(EQName4UserReading & ": Continue to rough. Wait for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

TM_AND_OPEN_HIVAC_LL:

                'Check Turbo or Cryo ready -> continue
                'not ready do not close rough valve go to complete
                If (Not IsTMPumpPackageReady()) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Open LL Fast Rough Valve
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'StepOpenLLFastRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg)
                    Utils.ShowStatusMessage(EQName4UserReading & ": Open LL Fast Rough Valve.", strSequenceName)
                    strErrMsg = LLCryoUtility.OpenLLFastRoughNoSafety(Me.EquipmentName)
                    If (strErrMsg <> String.Empty) Then
                        Me.ThrowAlarm(Me.EquipmentName & " Failed to open fast Rough valve.", AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Open all other rough valve if they shared rough pump with TM
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not Utils.OpenAllOtherRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, blIsHasCloseTMRoughValve) Then
                        If Not String.IsNullOrEmpty(strErrMsg) Then
                            Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        End If
                    End If

                    ' Wait for 3s before make pumpdown low priority
                    Utils.ShowStatusMessage(EQName4UserReading & ": Wait 3s.", strSequenceName)
                    m_EventStopThread.WaitOne(3000, True)

                    'Make pumpdown low priority
                    If ObjectRoughPumpMachine IsNot Nothing Then
                        ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                    End If

                    Utils.ShowStatusMessage(EQName4UserReading & ": Pumpdown completed", strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave PumpDownWithRoughOnly")
                    Return True
                Else
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Close LL Fast Rough(Valve)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not StepCloseLLFastRoughValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, False, m_EventStopThread, strSequenceName) Then
                        blnCloseAllValve = True
                        GoTo Exit_FUNCTION
                    End If
                    m_blnOpenFastRough = False
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not Utils.OpenAllOtherRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, blIsHasCloseTMRoughValve) Then
                    If Not String.IsNullOrEmpty(strErrMsg) Then
                        Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not Utils.OpenAllOtherForelineValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, blIsHasCloseTMForelineValve) Then
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
                ' Turn off TM IG
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not objTMController.StepTurnOffTMIG_Wait4IGOff(strErrMsg, False,
                                        EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Open LL HiVac Valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepOpenLLIsolationValveValve(EQName4UserReading & PUMPDOWN_ABORTED, strErrMsg, m_EventStopThread, strSequenceName) Then
                    blnCloseAllValve = True
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Wait 30s
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Thread.Sleep(VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Open_TM_TurboForeline)
                Milliseconds = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Open_TM_TurboForeline
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for " & TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                If m_EventStopThread.WaitOne(Milliseconds, True) Then
                    blnCloseAllValve = False
                    GoTo Exit_FUNCTION
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Turn on TM IG
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not objTMController.StepTurnOnTMIG(strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, strSequenceName) Then
                    'blnCloseAllValve = False
                    'GoTo Exit_FUNCTION
                    'Do Nothing
                    'Go to Complete Sequence
                    If (strErrMsg <> String.Empty) Then
                        Me.ThrowAlarm(strErrMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                    End If
                End If

                Utils.ShowStatusMessage(EQName4UserReading & ": Pumpdown completed.", strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                AVPLib.Log.seqLogger.Info("Leave PumpDownWithRoughOnly")
                Return True
Exit_FUNCTION:
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other rough valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Utils.OpenAllOtherRoughValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLARoughValve, blIsHasCloseTMRoughValve)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Open all other foreline valve if they shared rough pump with TM
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Utils.OpenAllOtherForelineValve(Me.EquipmentName, strErrMsg, EQName4UserReading & PUMPDOWN_ABORTED, m_EventStopThread, blIsHasCloseLLAForelineValve, blIsHasCloseTMForelineValve)

                If blnCloseAllValve Then
                    CloseActivePumpDown(False)
                End If

                If (m_EventStopThread.WaitOne(0, True)) Then

                    If (m_HasStopAutoVentPumpdownByMonitorManualDoorTimer) Then
                        m_HasStopAutoVentPumpdownByMonitorManualDoorTimer = False
                        strErrMsg = String.Format(ContainerData.GetMessageText("DoorWasNotClose"), Me.EquipmentName)
                        Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                    Else
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                    End If

                Else
                    If strErrMsg <> String.Empty Then
                        Me.ThrowAlarm(strErrMsg & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName) ''Tin.Tran changed Status Message 25/06/2012
                    End If
                End If

                AVPLib.Log.seqLogger.Info("Leave PumpDownWithRoughOnly")
                Return False

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                'Make pumpdown low priority
                If ObjectRoughPumpMachine IsNot Nothing Then
                    ObjectRoughPumpMachine.MakePumpdownPriority(Me.EquipmentName, False)
                End If
            End Try
            AVPLib.Log.seqLogger.Info("Leave PumpDownWithRoughOnly")
            Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_FAILED, strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
            Return False
        End Function


#End Region

#Region "Functions for sequence"
        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2021-10-25</date>
        ''' </author>
        ''' <summary>
        ''' Wait Foreline CG Relay
        ''' </summary>
        ''' <remarks></remarks>
        Private Function WaitForelineCGRelayOn(ByRef strErrMsg As String, ByVal abortedEvent As Threading.ManualResetEvent) As Boolean
            AVPLib.Log.seqLogger.Info("Enter WaitForelineCGRelayOn")
            Try
                If abortedEvent.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED)
                    AVPLib.Log.seqLogger.Info("Leave WaitForelineCGRelayOn")
                    Return False
                End If

                Dim Milliseconds As Int32 = 5 * 60 * 1000
                Utils.ShowStatusMessage(EQName4UserReading & " wait for Foreline CG Relay on with timeout " & _
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
        Private Function StepCheckLLxIsolationValveClose(ByRef strErrMsg As String, _
                                                            ByVal strAlarmMsgWhenFailed As String, _
                ByVal strStatusMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCheckLLxIsolationValveClose")

            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave StepCheckLLxIsolationValveClose")
                    Return False
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''Is LLx Slit valve Close
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not IsLLIsoValveCloseCond() Then
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''checking robot retracted if Llx Slit valve is Opened
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not CheckingRobotRetracted(strAlarmMsgWhenFailed, strStatusMsg, strErrMsg) Then
                        AVPLib.Log.seqLogger.Info("Leave StepCheckLLxIsolationValveClose")
                        Return False
                    End If
                Else
                    '''LLx Slit valve is Closed
                    AVPLib.Log.seqLogger.Info("Leave StepCheckLLxIsolationValveClose")
                    Return True
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Close LL Slit valve
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not StepCloseLLIsolationValve(strStatusMsg, strErrMsg, True, m_EventStopThread) Then
                    AVPLib.Log.seqLogger.Info("Leave StepCheckLLxIsolationValveClose")
                    Return False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try


            AVPLib.Log.seqLogger.Info("Leave StepCheckLLxIsolationValveClose")
            Return True
        End Function
        Private Function IsRobotAtLoadlockPosition(ByVal objRobot As DataManagerment.Robot) As Boolean
            Dim blResult As Boolean = False
            Try
                If (Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString AndAlso _
                objRobot IsNot Nothing AndAlso _
                (objRobot.CurrentPosition = ConstEnum.Positions.LoadLockA OrElse _
                objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_LLA_Extract OrElse _
                objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_LLA_Wafer_Extract OrElse _
                objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_LLA_Wafer)) Then
                    blResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Private Function CheckingRobotRetracted(ByVal strAlarmMsgWhenFailed As String, _
                                             ByVal strStatusMsg As String, ByRef strErrorMsg As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter CheckingRobotRetracted")

            Dim ctlRobot As RobotController = _
                                            CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

            Try
                If ctlRobot IsNot Nothing AndAlso objRobot IsNot Nothing Then
                    If (IsRobotAtLoadlockPosition(objRobot)) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        objRobot.IsRetracted = False
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ' Is Robot Retracted? -> alarm
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If m_EventStopThread.WaitOne(0, True) Then
                            AVPLib.Log.seqLogger.Info("Leave CheckingRobotRetracted")
                            Return False
                        End If

                        ctlRobot.GetRetractedStatus()
                        If m_EventStopThread.WaitOne(200, True) Then
                            AVPLib.Log.seqLogger.Info("Leave CheckingRobotRetracted")
                            Return False
                        End If

                        If (Not objRobot.IsRetracted) Then
                            strErrorMsg = String.Format(ContainerData.GetMessageText("RobotWasNotRetract"), Me.EquipmentName) & _
                                                    strAlarmMsgWhenFailed
                            AVPLib.Log.seqLogger.Info("Leave CheckingRobotRetracted")
                            Return False

                        Else
                            Utils.ShowStatusMessage(EQName4UserReading & " is retracted")
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.seqLogger.Info("Leave CheckingRobotRetracted")
            Return True

        End Function

        Public Function Close_LLx_Rough_Valve(ByVal strStatusMsg As String, ByRef strErrMsg As String,
                                              ByVal blnTrue4Vent_False4PumpDown As Boolean, ByVal abortedEvent As Threading.ManualResetEvent,
                                              Optional ByRef isHasCloseLLRoughValve As Boolean = False) As Boolean
            If ObjectLoadLock.FastRoughValveStatus = Equipment.WorkingStatuses.On Then
                If Not StepCloseLLFastRoughValve(strStatusMsg, strErrMsg, blnTrue4Vent_False4PumpDown, abortedEvent) Then
                    Return False
                End If
                isHasCloseLLRoughValve = True
            End If
            If RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED AndAlso ObjectLoadLock.SlowRoughValveStatus = Equipment.WorkingStatuses.On Then
                If Not StepCloseLLSlowRoughValve(strStatusMsg, strErrMsg, blnTrue4Vent_False4PumpDown, abortedEvent) Then
                    Return False
                End If
                isHasCloseLLRoughValve = True
            End If
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Wait MP#x Pressure < MP#x on Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepWaitMPPressure(ByVal strStatusMsg As String,
                                           ByRef strErrMsg As String,
                                           Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepWaitMPPressure")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave StepWaitMPPressure")
                    Return False
                End If
                Dim expectedMPPressure As Double = VentPumdownLib.LLPumpdownConfig.TMMechanicalPumpOnPressure
                'Dim LLCrossOverPressure As Double = ObjectLoadLock.FastRoughPressureSetPoint
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for Mechanical Pump pressure reach " &
                        expectedMPPressure & " torr. Wait for 300s", strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                If ObjectRoughPumpMachine IsNot Nothing Then
                    Dim waitTimeOut As Int64 = VentPumdownLib.LLPumpdownConfig.LLMakeRoughLineInUseTimeOut * 1000
                    If Not ObjectRoughPumpMachine.WaitMPPressure(expectedMPPressure, m_EventStopThread) Then

                        If (ObjectRoughPumpMachine.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                            strErrMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & MECHANICAL_PUMP_CG_DISCONNECTED
                        Else
                            strErrMsg = String.Format(ContainerData.GetMessageText("TMMechanicalPumpGreaterEqual"),
                            Me.EquipmentName, expectedMPPressure)
                        End If

                        AVPLib.Log.seqLogger.Info("Leave StepWaitMPPressure")
                        Return False
                    End If
                Else
                    AVPLib.Log.seqLogger.Info("Leave StepWaitMPPressure")
                    Return False
                End If
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for Mechanical Pump pressure [True] ", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepWaitMPPressure")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Wait MP#x Pressure < MP#x on Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepWaitFastRoughPressure(Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepWaitFastRoughPressure")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                    AVPLib.Log.seqLogger.Info("Leave StepWaitFastRoughPressure")
                    Return False
                End If

                Dim Milliseconds As Double = ObjectLoadLock.FastRoughPressureTimeOut * 1000
                Dim LLFastRoughPressureSetPoint As Double = ObjectLoadLock.FastRoughPressureSetPoint
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for LL CG reach Cross over pressure and CG relay on with timeout " &
                            TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s.", strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                If Not Utils.WaitOnCondition(AddressOf IsLLCGReachCrossOverPressureAndCGRelayOnCond, AddressOf IsLLCGDisconnected, Milliseconds, m_EventStopThread) Then
                    If Not m_EventStopThread.WaitOne(0, True) Then
                        If (IsLLCGDisconnected()) Then
                            Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        Else
                            Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("LLCGSmaller"), Me.EquipmentName, "<",
                            LLFastRoughPressureSetPoint, TimeSpan.FromMilliseconds(Milliseconds).Minutes) & m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        End If
                    End If
                    AVPLib.Log.seqLogger.Info("Leave StepWaitFastRoughPressure")
                    Return False
                Else
                    Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for LL CG reach Cross over pressure and CG relay on [True]", strSequenceName)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepWaitFastRoughPressure")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Wait MP#x Pressure < MP#x on Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepWaitSlowRoughPressure(Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepWaitSlowRoughPressure")
            Try
                If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                    If m_EventStopThread.WaitOne(0, True) Then
                        Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                        AVPLib.Log.seqLogger.Info("Leave StepWaitSlowRoughPressure")
                        Return False
                    End If

                    Dim Milliseconds As Integer = ObjectLoadLock.SlowRoughPressureTimeOut * 1000
                    Dim LLSlowRoughPressureSetPoint As Double = ObjectLoadLock.SlowRoughPressureSetPoint
                    Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for LL CG reach Soft Rough press with timeout " &
                                TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                    If Not Utils.WaitOnCondition(AddressOf IsLLCGReachSoftRoughPressureSetPoint, AddressOf IsLLCGDisconnected, Milliseconds, m_EventStopThread) Then
                        If Not m_EventStopThread.WaitOne(0, True) Then
                            If (IsLLCGDisconnected()) Then
                                Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                            Else
                                Me.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentWaitLLCGSmaller"),
                                Me.EquipmentName, "<", LLSlowRoughPressureSetPoint, TimeSpan.FromMilliseconds(Milliseconds).Minutes) &
                                m_strPumpDownFailed, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                            End If
                        End If
                        AVPLib.Log.seqLogger.Info("Leave StepWaitSlowRoughPressure")
                        Return False
                    Else
                        Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for LL CG reach Soft Rough pressure [True]", strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepWaitSlowRoughPressure")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Close Rough Vent Valves
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseRoughVentValves(ByVal strStatusMsg As String, ByRef strErrMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCloseRoughVentValves")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave StepCloseRoughVentValves")
                    Return False
                End If
                Utils.ShowStatusMessage(EQName4UserReading & ": Close Rough and Vent valves.", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                strErrMsg = CloseRoughVentValves(VentPumdownLib.LLPumpdownConfig.LLRoughValveOpenCloseTimeOut * 1000, m_EventStopThread)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave StepCloseRoughVentValves")
                    Return False
                Else
                    Utils.ShowStatusMessage(EQName4UserReading & ": Rough and Vent valves are closed.", strSequenceName) ''Tin.Tran changed Status Message 25/06/2012
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCloseRoughVentValves")
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
        Public Function StepCloseOtherRoughValves(ByRef strErrMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCloseOtherRoughValves")
            Dim blResult As Boolean = False
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(Me.EquipmentName & PUMPDOWN_ABORTED, strSequenceName)
                    Exit Try
                End If
                Utils.ShowStatusMessage(EQName4UserReading & ": Close Other Rough valves.", strSequenceName)

                Dim strOtherLoadlock As String = String.Empty
                'If (Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString AndAlso RobotConfigurationValues.LOADLOCKB_VISIBLE) Then
                '    strOtherLoadlock = ConstEnum.Equipments.LoadLockB.ToString
                'ElseIf (Me.EquipmentName = ConstEnum.Equipments.LoadLockB.ToString AndAlso RobotConfigurationValues.LOADLOCKA_VISIBLE) Then
                '    strOtherLoadlock = ConstEnum.Equipments.LoadLockA.ToString
                'End If

                If (strOtherLoadlock <> String.Empty) Then
                    strErrMsg = LLCryoUtility.CloseLLFastRough(strOtherLoadlock)
                    If (strErrMsg = String.Empty) Then
                        blResult = True
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.seqLogger.Info("Leave StepCloseOtherRoughValves")
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
        Public Function StepOpenOtherFastRoughValves(ByRef strErrMsg As String, Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenOtherFastRoughValves")
            Dim blResult As Boolean = False
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(Me.EquipmentName & PUMPDOWN_ABORTED, strSequenceName)
                    Exit Try
                End If
                Utils.ShowStatusMessage(EQName4UserReading & ": Open Other Rough valves.", strSequenceName)

                Dim strOtherLoadlock As String = String.Empty
                'If (Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString AndAlso RobotConfigurationValues.LOADLOCKB_VISIBLE) Then
                '    strOtherLoadlock = ConstEnum.Equipments.LoadLockB.ToString
                'ElseIf (Me.EquipmentName = ConstEnum.Equipments.LoadLockB.ToString AndAlso RobotConfigurationValues.LOADLOCKA_VISIBLE) Then
                '    strOtherLoadlock = ConstEnum.Equipments.LoadLockA.ToString
                'End If

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
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                    AVPLib.Log.coreLogger.Info("Leave StepTurnOnMechanicalPump")
                    Return False
                End If

                If Not IsLLMechanicalPumpOn() Then
                    If Not RobotConfigurationValues.SHARED_MP_WITH_PM Then
                        Utils.ShowStatusMessage(EQName4UserReading & ": Turn on Mechanical Pump.", strSequenceName)

                        Dim objMechanicalPump As RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)
                        If (objMechanicalPump IsNot Nothing) Then
                            strErrMsg = TMCryoUtility.OpenCloseMechanicalPump(ConstEnum.Equipments.CassettesModule.ToString, ObjectRoughPumpMachine.Name, True)
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
                        Dim iWaitTime As Integer = 30 ''30s
                        If Utils.NeedMechenicalPumpWaitAfterTurnOn(Me.EquipmentName, iWaitTime) Then
                            ' Wait for 30s after turn on MP
                            Utils.ShowStatusMessage(EQName4UserReading & ": Wait 30s after Turn on Mechanical Pump.")
                            If m_EventStopThread.WaitOne(iWaitTime * 1000, True) Then
                                Utils.ShowStatusMessage(strStatusMsg)
                                AVPLib.Log.coreLogger.Info("Leave StepTurnOnMechanicalPump")
                                Return False
                            End If
                            Utils.ShowStatusMessage(EQName4UserReading & ": Mechanical Pump is Opened.", strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepTurnOnMechanicalPump")
            Return True
        End Function
        Private Function WaitMechanicalPumpSerialTurnOn(ByVal strRoughPumpName As String, ByVal abortedEvent As Threading.ManualResetEvent) As String
            Dim strErrMsg As String = String.Empty
            Try
                If strRoughPumpName = Equipments.RoughPumpMachine1.ToString AndAlso RobotConfigurationValues.MPUMP1_SERIAL_VISIBLE OrElse _
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
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Open Slow Rough Valves
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenLLSlowRoughValve(ByVal strStatusMsg As String,
                                                    ByRef strErrMsg As String,
                                                    Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenLLSlowRoughValve")
            Try
                If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                    If m_EventStopThread.WaitOne(0, True) Then
                        Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                        AVPLib.Log.seqLogger.Info("Leave StepOpenLLSlowRoughValve")
                        Return False
                    End If

                    ''Make rough line in use
                    Dim expectedMPPressure As Double = VentPumdownLib.LLPumpdownConfig.TMMechanicalPumpOnPressure
                    'Dim LLCrossOverPressure As Double = ObjectLoadLock.FastRoughPressureSetPoint
                    If ObjectRoughPumpMachine IsNot Nothing Then

                        If (ObjectRoughPumpMachine.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                            strErrMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & MECHANICAL_PUMP_CG_DISCONNECTED
                            Return False
                        End If

                        Dim waitTimeOut As Int64 = VentPumdownLib.LLPumpdownConfig.LLMakeRoughLineInUseTimeOut * 1000
                        If ObjectRoughPumpMachine.MakeRoughLineInUse(Me.EquipmentName, expectedMPPressure, m_EventStopThread, waitTimeOut) Then

                            AVPLib.Log.coreLogger.Debug("Rough Line now is used by " & Me.EquipmentName)
                            ' Send a warning event here, make user noticeable.
                            ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeWarning, Utils.chamberID2ChamberName(Me.EquipmentName), "Rough Line now is used by " &
                                                            Me.EquipmentName)

                            'KHOI HA, check loadlock door before open LL rough valve
                            If Not (IsLLdoorClosed()) Then
                                strErrMsg = String.Format(ContainerData.GetMessageText("DoorWasNotClose"), Me.EquipmentName)
                                Return False
                            End If

                            Utils.ShowStatusMessage(EQName4UserReading & ": Open Slow Rough.", strSequenceName)
                            ''Open LL Slow Rough
                            strErrMsg = LLCryoUtility.OpenLLSlowRough(Me.EquipmentName, False)

                            'Open Failed
                            If strErrMsg <> String.Empty Then
                                AVPLib.Log.seqLogger.Info("Leave StepOpenLLSlowRoughValve")
                                Return False
                            End If

                            'Waiting for Reply
                            Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLRoughValveOpenCloseTimeOut * 1000
                            If Not Utils.WaitOnCondition(AddressOf IsLLSoftRoughValveOpenCond, Milliseconds, m_EventStopThread) Then
                                If Not m_EventStopThread.WaitOne(0, True) Then
                                    strErrMsg = String.Format(ContainerData.GetMessageText("LLSlowRoughWasNotOpen"), Me.EquipmentName)
                                End If

                                AVPLib.Log.seqLogger.Info("Leave StepOpenLLSlowRoughValve")
                                Return False
                            Else
                                AVPLib.Log.seqLogger.Info("Leave StepOpenLLSlowRoughValve")
                                m_blnOpenSlowRough = True
                                Return True
                            End If

                        Else ' failed to wait for free Rough Pump
                            strErrMsg = String.Format(ContainerData.GetMessageText("FailedGetRoughLinePumpDown"), Me.EquipmentName)
                            Return False
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepOpenLLSlowRoughValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Open Fast Rough Valves
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenLLFastRoughValve(ByVal strStatusMsg As String,
                                                    ByRef strErrMsg As String,
                                                    Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenLLFastRoughValve")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave StepOpenLLFastRoughValve")
                    Return False
                End If

                ''Make rough line in use
                Dim expectedMPPressure As Double = VentPumdownLib.LLPumpdownConfig.TMMechanicalPumpOnPressure
                'Dim LLCrossOverPressure As Double = ObjectLoadLock.FastRoughPressureSetPoint
                If ObjectRoughPumpMachine IsNot Nothing Then

                    If (ObjectRoughPumpMachine.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        strErrMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & MECHANICAL_PUMP_CG_DISCONNECTED
                        Return False
                    End If

                    Dim waitTimeOut As Int64 = VentPumdownLib.LLPumpdownConfig.LLMakeRoughLineInUseTimeOut * 1000
                    If ObjectRoughPumpMachine.MakeRoughLineInUse(Me.EquipmentName, expectedMPPressure, m_EventStopThread, waitTimeOut) Then

                        ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeWarning, Utils.chamberID2ChamberName(Me.EquipmentName), "Rough Line now is used by " &
                                                        Me.EquipmentName)

                        'KHOI HA, check loadlock door before open LL rough valve
                        If Not (IsLLdoorClosed()) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("DoorWasNotClose"), Me.EquipmentName)
                            Return False
                        End If

                        Utils.ShowStatusMessage(EQName4UserReading & ": Open Fast Rough valve.", strSequenceName)

                        'Open Rough Valve
                        strErrMsg = LLCryoUtility.OpenLLFastRough(Me.EquipmentName, False)

                        'Open Failed
                        If strErrMsg <> String.Empty Then
                            AVPLib.Log.seqLogger.Info("Leave StepOpenLLFastRoughValve")
                            Return False
                        End If

                        Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLRoughValveOpenCloseTimeOut * 1000
                        Utils.ShowStatusMessage(EQName4UserReading & " wait for fast rough is open with timeout " &
                                                TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", strSequenceName)

                        'Waiting for Reply
                        If Not Utils.WaitOnCondition(AddressOf IsLLFastRoughValveOpenCond, Milliseconds, m_EventStopThread) Then
                            If Not m_EventStopThread.WaitOne(0, True) Then
                                strErrMsg = String.Format(ContainerData.GetMessageText("LLFastRoughWasNotOpen"), Me.EquipmentName)
                            End If

                            AVPLib.Log.seqLogger.Info("Leave StepOpenLLFastRoughValve")
                            Return False
                        Else
                            AVPLib.Log.seqLogger.Info("Leave StepOpenLLFastRoughValve")
                            m_blnOpenFastRough = True
                            Return True
                        End If

                    Else 'failed to wait free rough pump
                        strErrMsg = String.Format(ContainerData.GetMessageText("FailedGetRoughLinePumpDown"), Me.EquipmentName)
                        Return False
                    End If
                End If


            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepOpenLLFastRoughValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Open LL Hivac Valves
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenLLHivacValve(ByVal strStatusMsg As String, ByRef strErrMsg As String,
                                                    Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenLLHivacValve")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave StepOpenLLHivacValve")
                    Return False
                End If

                strErrMsg = LoadLockUtility.OpenLLHivac(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave StepOpenLLHivacValve")
                    Return False
                Else
                    m_blnOpenHivac = True
                End If

                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLHivacOpenCloseTimeOut * 1000
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for hivac open with timeout " &
                                            TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                If Not Utils.WaitOnCondition(AddressOf IsLLHiVacOpenCond, Milliseconds, m_EventStopThread) Then
                    If Not m_EventStopThread.WaitOne(0, True) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("DidNotOpenValve"), Me.EquipmentName) + " (HiVac)"
                    End If
                    AVPLib.Log.seqLogger.Info("Leave StepOpenLLHivacValve")
                    Return False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepOpenLLHivacValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-22</date>
        ''' </author>
        ''' <summary>
        ''' Open Slit valve 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenLLIsolationValveValve(ByVal strStatusMsg As String, ByRef strErrMsg As String, ByVal abortEvent As ManualResetEvent, _
        Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenLLIsolationValveValve")
            Dim blResult As Boolean = False
            Try
                If abortEvent.WaitOne(0, True) Then
                    Exit Try
                End If
                If (Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString) Then
                    strErrMsg = ChamberUtility.OpenCloseSlitValve(ConstEnum.Equipments.CassettesModule.ToString, True, "SplitValveLLA")
                End If

                If strErrMsg <> String.Empty Then
                    Exit Try
                End If

                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLMesaValveOpenCloseTimeOut * 1000
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for LL Isolation is opened with timeout " & _
                                            TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                If Not Utils.WaitOnCondition(AddressOf IsLLIsoValveOpenCond, Milliseconds, abortEvent) Then
                    If Not abortEvent.WaitOne(0, True) Then
                        ChamberUtility.UnknownSlitValve(Me.EquipmentName)
                        strErrMsg = Me.EquipmentName & " Failed to open Slit valve."
                    End If
                    Exit Try
                End If

                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
            AVPLib.Log.seqLogger.Info("Leave StepOpenLLIsolationValveValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Turn on IG
        ''' </summary>Truc Le modified
        ''' <remarks></remarks>
        Public Function StepTurnOnLLIG(ByRef strErrMsg As String,
                                       Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepTurnOnIG")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave StepTurnOnIG")
                    Return False
                End If
                ''''''''''''''''''''''''''''''''''''''''
                strErrMsg = LLCryoUtility.TurnOnIG(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave StepTurnOnIG")
                    Return False
                End If

                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.IGOnOffTimeOut * 1000
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for IG is on with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                If Not Utils.WaitOnCondition(AddressOf IsLLIGOnCond, Milliseconds, m_EventStopThread) Then
                    'Retry Turn On IG.
                    Utils.ShowStatusMessage(EQName4UserReading & ": Retry Turn On IG.", strSequenceName)
                    strErrMsg = LLCryoUtility.TurnOnIG(Me.EquipmentName)

                    If strErrMsg <> String.Empty Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("IGWasNotOn"), Me.EquipmentName)
                        AVPLib.Log.coreLogger.Info("Leave StepTurnOnIG")
                        Return False
                    Else
                        Utils.ShowStatusMessage(EQName4UserReading & ": Turning IG On", strSequenceName)
                    End If

                    'If IG still not On -> Alarm
                    If Not Utils.WaitOnCondition(AddressOf IsLLIGOnCond, VentPumdownLib.LLPumpdownConfig.IGOnOffTimeOut * 1000, m_EventStopThread) Then
                        If Not m_EventStopThread.WaitOne(0, True) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("IGWasNotOn"), Me.EquipmentName)
                        End If

                        Utils.ShowStatusMessage(EQName4UserReading & ":" & PUMPDOWN_FAILED & " - wait for closing valves...", strSequenceName)
                        Me.CloseActivePumpDown()
                        Utils.ShowStatusMessage(EQName4UserReading & ":" & PUMPDOWN_FAILED, strSequenceName)
                        AVPLib.Log.coreLogger.Info("Leave StepTurnOnIG")
                        Return False
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepTurnOnIG")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-29</date>
        ''' </author>
        ''' <summary>
        ''' Turn on IG
        ''' </summary>Truc Le modified
        ''' <remarks></remarks>
        Public Function StepLLTurnOnTurbo(ByRef strErrMsg As String,
                                          Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepLLTurnOnTurbo")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": " & PUMPDOWN_ABORTED, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                    AVPLib.Log.seqLogger.Info("Leave StepLLTurnOnTurbo")
                    Return False
                End If
                ''''''''''''''''''''''''''''''''''''''''
                Dim objLLPumpPackageCtrl As PumpPackageController = GetObjPumpPackageCtrl()
                If objLLPumpPackageCtrl IsNot Nothing Then
                    If objLLPumpPackageCtrl.StartPumpPackage(True) Then
                        Utils.ShowStatusMessage(EQName4UserReading & ": Turn on Turbo", strSequenceName)
                    Else
                        strErrMsg = String.Format(ContainerData.GetMessageText("TurboWasNotOn"), Me.EquipmentName)
                        AVPLib.Log.seqLogger.Info("Leave StepLLTurnOnTurbo")
                        Return False
                    End If

                    Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLPumpPackageTimeOut * 1000
                    Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for turbo up to speed with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s.", strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                    If Not Utils.WaitOnCondition(AddressOf IsLLPumpPackageOK, Milliseconds, m_EventStopThread) Then
                        If Not m_EventStopThread.WaitOne(0, True) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("TurboWasNotUpToSpeed"), Me.EquipmentName)
                        End If
                        m_blnTurnOnTurbo = True
                        AVPLib.Log.seqLogger.Info("Leave StepLLTurnOnTurbo")
                        Return False
                    End If
                    Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for turbo up to speed [True]", strSequenceName)  ''Tin.Tran changed Status Message 25/06/2012
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepLLTurnOnTurbo")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Close LL Foreline Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseLLTurboForelineValve(ByRef strErrMsg As String,
                                                      ByVal strStatusMsg As String,
                                                      ByVal abortedEvent As Threading.ManualResetEvent,
                                                      Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCloseLLForelineValve")
            Try
                If abortedEvent.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                    AVPLib.Log.seqLogger.Info("Leave StepOpenLLForelineValve")
                    Return False
                End If
                ''''''''''''''''''''''''''''''''''''''''''
                Utils.ShowStatusMessage(EQName4UserReading & ": Close Turbo Foreline valve", strSequenceName)    ''Tin.Tran changed Status Message 25/06/2012
                strErrMsg = LLCryoUtility.CloseLLTurboForeLineValve(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave StepCloseLLForelineValve")
                    Return False
                End If

                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLOpenCloseForlineTimeOut * 1000
                Utils.ShowStatusMessage(EQName4UserReading & ": Wait for turbo foreline valve close with timeout " &
                                            TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", strSequenceName)
                If Not Utils.WaitOnCondition(AddressOf IsLLTurboForelineValveCloseCond, Milliseconds, abortedEvent) Then
                    If Not abortedEvent.WaitOne(0, True) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("LLForelineWasNotClose"), Me.EquipmentName)
                    End If
                    AVPLib.Log.seqLogger.Info("Leave StepCloseLLForelineValve")
                    Return False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCloseLLForelineValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Open LL Foreline Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenLLTurboForelineValve(ByRef strErrMsg As String,
                                                     ByVal strStatusMsg As String,
                                                     ByVal abortedEvent As Threading.ManualResetEvent,
                                                     Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepOpenLLForelineValve")
            Try
                If abortedEvent.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                    AVPLib.Log.seqLogger.Info("Leave StepOpenLLForelineValve")
                    Return False
                End If

                Utils.ShowStatusMessage(EQName4UserReading & ": Open turbo foreline valve.", strSequenceName) ''Tin.Tran changed Status Message 25/06/2012
                strErrMsg = LLCryoUtility.OpenLLTurboForeLineValve(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave StepOpenLLForelineValve")
                    Return False
                End If

                'Van Le
                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLOpenCloseForlineTimeOut * 1000
                Utils.ShowStatusMessage(EQName4UserReading & ": Wait for turbo foreline valve open with timeout " &
                                        TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", strSequenceName)
                If Not Utils.WaitOnCondition(AddressOf IsLLTurboForelineValveOpenCond, Milliseconds, abortedEvent) Then
                    If Not abortedEvent.WaitOne(0, True) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("LLForelineWasNotOpen"), Me.EquipmentName)
                    End If
                    m_blnOpenForeline = True
                    AVPLib.Log.seqLogger.Info("Leave StepOpenLLForelineValve")
                    Return False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepOpenLLForelineValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-26</date>
        ''' </author>
        ''' <summary>
        ''' Check TM Turbo Ready = On + Upto speed
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsTMPumpPackageReady() As Boolean
            AVPLib.Log.seqLogger.Info("Enter IsTMTurboReady")
            Try

                Dim strErrMsg As String = String.Empty
                Dim objTMController As TMController = ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString)
                If (objTMController IsNot Nothing) Then
                    Return objTMController.IsTMHivacOpenCond AndAlso objTMController.ObjectPumpPackage.IsPumpPackageOK(strErrMsg)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave IsTMTurboReady")
            Return False
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Check TM Turbo Only
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCheckTMCryoOnly(ByVal objTMController As TMController, ByRef strErrMsg As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCheckTMCryoOnly")
            Try
                If Not objTMController.IsTMHivacOpenCond() Then
                    strErrMsg = String.Format(ContainerData.GetMessageText("HivacValveDidNotOpen"), AVPLib.ConstEnum.TM_STR)
                    AVPLib.Log.seqLogger.Info("Leave StepCheckTMCryoOnly")
                    Return False
                End If

                If Not objTMController.ObjectPumpPackage.IsPumpPackageOK(strErrMsg) Then
                    'strErrMsg = String.Format(ContainerData.GetMessageText("T2LoadLockCryoLessThan20K"), _
                    '                 Me.EquipmentName, "<", ObjectLoadLock.CryoColdTemp)
                    AVPLib.Log.seqLogger.Info("Leave StepCheckTMCryoOnly")
                    Return False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCheckTMCryoOnly")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Check If other LL PumpDown running
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCheckOtherRoughInUse(ByRef strErrMsg As String,
                                                    Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter StepCheckOtherLLPumpDown")
            Dim bResult As Boolean = False
            Try
                Dim Milliseconds As Integer = VentPumdownLib.LLPumpdownConfig.LLMakeRoughLineInUseTimeOut * 1000

                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for other Rough Valve closed with timeout " &
                                                TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName) ''Tin.Tran changed Status Message 25/06/2012
                If (Not ObjectRoughPumpMachine.WaitForRoughFree(Me.EquipmentName, m_EventStopThread, Milliseconds)) Then

                    If Not m_EventStopThread.WaitOne(0, True) Then
                        strErrMsg = "Failed to wait for other Rough closed"
                    End If
                Else
                    'Pass anything
                    bResult = True
                    Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for other Rough Valve closed " & "[" & bResult & "]", strSequenceName)   ''Tin.Tran changed Status Message 25/06/2012
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave StepCheckOtherLLPumpDown")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-11-30</date>
        ''' </author>
        ''' <summary>
        ''' Check If other LL PumpDown running
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsOtherPumpDownStopCond() As Boolean
            AVPLib.Log.seqLogger.Info("Enter IsOtherLLPumpDownRunningCond")
            Dim blnResult As Boolean = True
            Try
                Dim objLLController As LoadLockController = Nothing
                Dim objTMController As TMController = ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString())
                'If Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString() Then
                '    objLLController = ControllerManager.GetController(ConstEnum.Equipments.LoadLockB.ToString())
                'Else
                '    objLLController = ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString())
                'End If

                If objLLController IsNot Nothing AndAlso objLLController.IsPumpDownSeqRunning Then
                    blnResult = False
                End If
                If objTMController IsNot Nothing AndAlso objTMController.IsPumpDownSeqRunning Then
                    blnResult = False
                End If


            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave IsOtherLLPumpDownRunningCond")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-28-11</date>
        ''' </author>
        ''' <summary>
        ''' Close LL Fast Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseLLFastRoughValve(ByVal strStatusMsg As String,
                                                  ByRef strErrMsg As String,
                                                  ByVal blnTrue4Vent_False4PumpDown As Boolean,
                                                  ByVal abortedEvent As Threading.ManualResetEvent,
                                                  Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter CloseFastRoughValve")
            Try
                If abortedEvent.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, IIf(blnTrue4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                    AVPLib.Log.seqLogger.Info("Leave StepCloseLLFastRoughValve")
                    Return False
                End If
                Utils.ShowStatusMessage(EQName4UserReading & ": Close Fast Rough Valve.", IIf(blnTrue4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))   ''Tin.Tran changed Status Message 25/06/2012

                strErrMsg = LLCryoUtility.CloseLLFastRough(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave CloseFastRoughValve")
                    Return False
                End If


                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLRoughValveOpenCloseTimeOut * 1000
                If blnTrue4Vent_False4PumpDown Then
                    Milliseconds = VentPumdownLib.LLVentConfig.LLVentValveOpenCloseTimeout * 1000
                End If

                Utils.ShowStatusMessage(EQName4UserReading & ": Wait for Fast Rough Valve close with timeout " &
                    TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", IIf(blnTrue4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                If Not Utils.WaitOnCondition(AddressOf IsLLFastRoughValveCloseCond, Milliseconds, abortedEvent) Then
                    If Not abortedEvent.WaitOne(0, True) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("LLFastRoughWasNotClose"), Me.EquipmentName)
                    End If
                    AVPLib.Log.seqLogger.Info("Leave CloseFastRoughValve")
                    Return False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave CloseFastRoughValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-28-11</date>
        ''' </author>
        ''' <summary>
        ''' Close LL Slow Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseLLSlowRoughValve(ByVal strStatusMsg As String,
                                                  ByRef strErrMsg As String,
                                                  ByVal blnTrue4Vent_False4PumpDown As Boolean,
                                                  ByVal abortedEvent As Threading.ManualResetEvent,
                                                  Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter CloseSlowRoughValve")
            Try
                If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                    If abortedEvent.WaitOne(0, True) Then
                        Utils.ShowStatusMessage(strStatusMsg, IIf(blnTrue4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                        AVPLib.Log.seqLogger.Info("Leave StepCloseLLSlowRoughValve")
                        Return False
                    End If
                    Utils.ShowStatusMessage(EQName4UserReading & ": Close Slow Rough Valve.", IIf(blnTrue4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))

                    strErrMsg = LLCryoUtility.CloseLLSlowRough(Me.EquipmentName)
                    If strErrMsg <> String.Empty Then
                        AVPLib.Log.seqLogger.Info("Leave CloseSlowRoughValve")
                        Return False
                    End If

                    Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLRoughValveOpenCloseTimeOut * 1000
                    If blnTrue4Vent_False4PumpDown Then
                        Milliseconds = VentPumdownLib.LLVentConfig.LLVentValveOpenCloseTimeout * 1000
                    End If

                    Utils.ShowStatusMessage(EQName4UserReading & ": Wait for Slow Rough Valve close with timeout " &
                                       TimeSpan.FromMilliseconds(Milliseconds).Seconds & "s", IIf(blnTrue4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                    If Not Utils.WaitOnCondition(AddressOf IsLLSoftRoughValveCloseCond, Milliseconds, abortedEvent) Then
                        If Not abortedEvent.WaitOne(0, True) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("LLSlowRoughWasNotClose"), Me.EquipmentName)
                        End If
                        AVPLib.Log.seqLogger.Info("Leave CloseFastRoughValve")
                        Return False
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.seqLogger.Info("Leave CloseSlowRoughValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-28-11</date>
        ''' </author>
        ''' <summary>
        ''' Close LL Slit valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseLLIsolationValve(ByVal strStatusMsg As String, ByRef strErrMsg As String, ByVal blnTrue4Vent_False4PumpDown As Boolean, ByVal abortEvent As ManualResetEvent, _
         Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter CloseLLIsolationValve")
            Try
                If abortEvent.WaitOne(0, True) Then
                    AVPLib.Log.coreLogger.Info("Leave CheckAutoVent")
                    Utils.ShowStatusMessage(strStatusMsg, strSequenceName)
                    AVPLib.Log.seqLogger.Info("Leave CloseLLIsolationValve")
                    Return False
                End If
                '''''
                strErrMsg = ChamberUtility.OpenCloseSlitValve(Me.EquipmentName, False)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave CloseLLIsolationValve")
                    Return False
                End If
                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLMesaValveOpenCloseTimeOut * 1000
                If blnTrue4Vent_False4PumpDown Then
                    Milliseconds = VentPumdownLib.LLVentConfig.LLMesaValveOpenCloseTimeOut * 1000
                End If
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for LL Slit valve closed with timeout " & _
                                        TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s", strSequenceName)
                If Not Utils.WaitOnCondition(AddressOf IsLLIsoValveCloseCond, Milliseconds, abortEvent) Then
                    If Not abortEvent.WaitOne(0, True) Then
                        ChamberUtility.UnknownSlitValve(Me.EquipmentName)
                        strErrMsg = String.Format(ContainerData.GetMessageText("LLIsolationValveWasNotClose"), Me.EquipmentName)
                    End If
                    AVPLib.Log.seqLogger.Info("Leave CloseLLIsolationValve")
                    Return False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave CloseLLIsolationValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-28-11</date>
        ''' </author>
        ''' <summary>
        ''' Turn off LLx IG
        ''' blVentPumpDown : True use timeout for vent
        '''                  False use timeout for pumpdown
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepTurnOffLLIG_WaitIGOff(ByRef strErrMsg As String,
                                                    ByVal blnTrue4Vent_False4PumpDown As Boolean,
                                                    Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter TurnOffLLIG")
            strErrMsg = String.Empty
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & IIf(blnTrue4Vent_False4PumpDown, VENT_ABORTED, PUMPDOWN_ABORTED), IIf(blnTrue4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                    AVPLib.Log.seqLogger.Info("Leave StepTurnOffLLIG")
                    Return False
                End If
                '''''''''''''''''''''''
                strErrMsg = LLCryoUtility.TurnOffIG(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave TurnOffLLIG")
                    Return False
                End If

                '''wait and check;
                Dim Milliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.IGOnOffTimeOut * 1000
                If blnTrue4Vent_False4PumpDown Then
                    Milliseconds = VentPumdownLib.LLVentConfig.IGOnOffTimeOut * 1000
                End If
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for IG close with timeout " &
                                            TimeSpan.FromMilliseconds(Milliseconds).TotalSeconds & "s",
                                            IIf(blnTrue4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                If Not Utils.WaitOnCondition(AddressOf IsLLIGOffCond, Milliseconds, m_EventStopThread) Then
                    If Not m_EventStopThread.WaitOne(0, True) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("LLIGWasNotOff"), Me.EquipmentName)
                    End If
                    AVPLib.Log.seqLogger.Info("Leave TurnOffLLIG")
                    Return False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave TurnOffLLIG")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-28-11</date>
        ''' </author>
        ''' <summary>
        ''' Close LL Hivac Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseLLHivacValve_Wait4LLHivacClose(ByRef strErrMsg As String,
                                                                ByVal blnTrue4Vent_False4PumpDown As Boolean,
                                                                Optional ByVal strSequenceName As String = "") As Boolean
            AVPLib.Log.seqLogger.Info("Enter CloseLLHivacValve")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(EQName4UserReading & IIf(blnTrue4Vent_False4PumpDown, VENT_ABORTED, PUMPDOWN_ABORTED), IIf(blnTrue4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                    AVPLib.Log.coreLogger.Info("Leave CheckAutoVent")
                    Return False
                End If
                ''send close LL Hivac
                strErrMsg = LoadLockUtility.CloseLLHivac(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave CloseLLHivacValve")
                    Return False
                End If

                ''Wait for LL Hivac Close
                Dim Miliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLHivacOpenCloseTimeOut * 1000
                If blnTrue4Vent_False4PumpDown Then
                    Miliseconds = VentPumdownLib.LLVentConfig.LLHivacOpenCloseTimeout * 1000
                End If
                Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for hivac close with timeout " &
                            TimeSpan.FromMilliseconds(Miliseconds).Seconds & "s", IIf(blnTrue4Vent_False4PumpDown, STR_SEQUENCE_AUTO_VENT, strSequenceName))
                If Not Utils.WaitOnCondition(AddressOf IsLLHiVacCloseCond, Miliseconds, m_EventStopThread) Then
                    If Not m_EventStopThread.WaitOne(0, True) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("LLHiVacWasNotClose"), Me.EquipmentName)
                    End If
                    AVPLib.Log.seqLogger.Info("Leave CloseLLHivacValve")
                    Return False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave CloseLLHivacValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-28-11</date>
        ''' </author>
        ''' <summary>
        ''' Open/Close LL Slow Vent Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepCloseLLSlowVentValve(ByRef strErrMsg As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter CloseLLSlowVentValve")
            Try
                If (RobotConfigurationValues.LL_SLOW_VENT_INSTALLED) Then
                    Utils.ShowStatusMessage(EQName4UserReading & ": Close slow vent valve.", STR_SEQUENCE_AUTO_VENT) ''Tin.Tran changed Status Message 25/06/2012
                    strErrMsg = LLCryoUtility.CloseLLSlowVent(Me.EquipmentName)
                    If strErrMsg <> String.Empty Then
                        AVPLib.Log.seqLogger.Info("Leave CloseLLSlowVentValve")
                        Return False
                    End If

                    ''Wait for LL Hivac Close
                    Dim Miliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLVentValveOpenCloseTimeOut * 1000
                    
                    Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for slow vent close with timeout " & _
                                TimeSpan.FromMilliseconds(Miliseconds).Seconds & "s", STR_SEQUENCE_AUTO_VENT)
                    If Not Utils.WaitOnCondition(AddressOf IsLLSoftVentValveOpenCond, Miliseconds, m_EventStopThread) Then
                        If Not m_EventStopThread.WaitOne(0, True) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("LLSlowVentWasNotClose"), Me.EquipmentName)
                        End If
                        AVPLib.Log.seqLogger.Info("Leave CloseLLHivacValve")
                        Return False
                    End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave CloseLLSlowVentValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-28-11</date>
        ''' </author>
        ''' <summary>
        ''' Open/Close LL Slow Vent Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenLLSlowVentValve(ByVal strStatusMsg As String, ByRef strErrMsg As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter OpenLLSlowVentValve")
            Try
                If (RobotConfigurationValues.LL_SLOW_VENT_INSTALLED) Then
                    If m_EventStopThread.WaitOne(0, True) Then
                        Utils.ShowStatusMessage(strStatusMsg, STR_SEQUENCE_AUTO_VENT)
                        AVPLib.Log.coreLogger.Info("Leave StepOpenLLSlowVentValve")
                        Return False
                    End If
                    ''send CMD
                    Utils.ShowStatusMessage(EQName4UserReading & ": Open slow vent valve open.", STR_SEQUENCE_AUTO_VENT) ''Tin.Tran changed Status Message 25/06/2012
                    strErrMsg = LLCryoUtility.OpenLLSlowVent(Me.EquipmentName)
                    If strErrMsg <> String.Empty Then
                        AVPLib.Log.seqLogger.Info("Leave OpenLLSlowVentValve")
                        Return False
                    End If

                    ''Wait for LL Hivac Close
                    Dim Miliseconds As Int32 = VentPumdownLib.LLPumpdownConfig.LLVentValveOpenCloseTimeOut * 1000

                    Utils.ShowStatusMessage(EQName4UserReading & ": Waiting for slow vent close with timeout " & _
                                TimeSpan.FromMilliseconds(Miliseconds).Seconds & "s", STR_SEQUENCE_AUTO_VENT)
                    If Not Utils.WaitOnCondition(AddressOf IsLLSoftVentValveOpenCond, Miliseconds, m_EventStopThread) Then
                        If Not m_EventStopThread.WaitOne(0, True) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("LLSlowVentWasNotClose"), Me.EquipmentName)
                        End If
                        AVPLib.Log.seqLogger.Info("Leave CloseLLHivacValve")
                        Return False
                    End If
                    m_blnOpenSlowVent = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave OpenLLSlowVentValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2011-28-11</date>
        ''' </author>
        ''' <summary>
        ''' Open LL Fast Vent Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StepOpenLLFastVentValve_Wait4LLFastVentOpen(ByVal strStatusMsg As String, ByRef strErrMsg As String) As Boolean
            AVPLib.Log.seqLogger.Info("Enter OpenLLFastVentValve")
            Try
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(strStatusMsg, STR_SEQUENCE_AUTO_VENT)
                    AVPLib.Log.seqLogger.Info("Leave OpenLLFastVentValve")
                    Return False
                End If

                Utils.ShowStatusMessage(EQName4UserReading & ": Open Fast Vent valve.", STR_SEQUENCE_AUTO_VENT)  ''Tin.Tran changed Status Message 25/06/2012
                ''''''''''''''Open LL Fast Vent
                strErrMsg = LLCryoUtility.OpenLLFastVent(Me.EquipmentName)
                If strErrMsg <> String.Empty Then
                    AVPLib.Log.seqLogger.Info("Leave OpenLLFastVentValve")
                    Return False
                Else
                    m_blnOpenFastVent = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.seqLogger.Info("Leave OpenLLFastVentValve")
            Return True
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2014-08-27</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <remarks></remarks>
        Public Function SafetyTurnIGOnOff(ByVal bOn As Boolean) As String
            AVPLib.Log.coreLogger.Info("Enter SafetyTurnIGOnOff")
            Dim strError As String = String.Empty
            Try
                If m_objLoadLock.OverideModeStatus <> Equipment.WorkingStatuses.On AndAlso bOn Then
                    If m_objLoadLock.HiVacValveStatus <> Equipment.WorkingStatuses.On Then
                        strError = "Hivac Is Not Open."
                    ElseIf m_objLoadLock.CG_Communication <> Equipment.WorkingStatuses.On Then
                        strError = "CG is disconnected."
                    ElseIf m_objLoadLock.VacSwitchStatus <> Equipment.WorkingStatuses.On Then
                        strError = "CG Relay Is Not On"
                    End If

                    If Not String.IsNullOrEmpty(strError) Then
                        Return strError
                    End If
                End If

                If bOn Then
                    strError = LLCryoUtility.TurnOnIG(Me.EquipmentName)
                Else
                    strError = LLCryoUtility.TurnOffIG(Me.EquipmentName)
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
                If m_objLoadLock.IGStatus = Equipment.WorkingStatuses.On Then
                    isTurnOn = True
                    strError = SafetyTurnIGOnOff(False)
                    If String.IsNullOrEmpty(strError) AndAlso Not Utils.WaitOnCondition(AddressOf IsLLIGOffCond, 10000, m_EventStopThread) Then
                        strError = "Failed to turn off " & Me.EquipmentName & " IG"
                    End If
                End If

                ''Switcht IGFilement1
                If String.IsNullOrEmpty(strError) Then
                    strError = LLCryoUtility.SwitchIGFilament1(Me.EquipmentName)
                End If

                ''Wait IGFilement1
                If String.IsNullOrEmpty(strError) AndAlso m_objLoadLock.IGStatus = Equipment.WorkingStatuses.Off Then
                    m_EventStopThread.Reset()

                    If Not Utils.WaitOnCondition(AddressOf IsLLIGFilament1Cond, 10000, m_EventStopThread) Then
                        strError = "Failed to switch " & Me.EquipmentName & " IG Filament 1"
                    End If

                End If

                ''Turn on IG
                If String.IsNullOrEmpty(strError) AndAlso isTurnOn Then
                    strError = SafetyTurnIGOnOff(True)
                    m_EventStopThread.Reset()

                    If String.IsNullOrEmpty(strError) AndAlso Not Utils.WaitOnCondition(AddressOf IsLLIGOnCond, 30000, m_EventStopThread) Then
                        strError = "Failed to turn on " & Me.EquipmentName & " IG"
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
                If m_objLoadLock.IGStatus = Equipment.WorkingStatuses.On Then
                    isTurnOn = True
                    strError = SafetyTurnIGOnOff(False)
                    If String.IsNullOrEmpty(strError) AndAlso Not Utils.WaitOnCondition(AddressOf IsLLIGOffCond, 10000, m_EventStopThread) Then
                        strError = "Failed to turn off " & Me.EquipmentName & " IG"
                    End If
                End If

                ''Switcht IGFilement2
                If String.IsNullOrEmpty(strError) Then
                    strError = LLCryoUtility.SwitchIGFilament2(Me.EquipmentName)
                End If

                ''Wait IGFilement2
                If String.IsNullOrEmpty(strError) AndAlso m_objLoadLock.IGStatus = Equipment.WorkingStatuses.Off Then
                    m_EventStopThread.Reset()

                    If Not Utils.WaitOnCondition(AddressOf IsLLIGFilament2Cond, 10000, m_EventStopThread) Then
                        strError = "Failed to switch " & Me.EquipmentName & " IG Filament 2"
                    End If

                End If

                ''Turn on IG
                If String.IsNullOrEmpty(strError) AndAlso isTurnOn Then
                    strError = SafetyTurnIGOnOff(True)
                    m_EventStopThread.Reset()

                    If String.IsNullOrEmpty(strError) AndAlso Not Utils.WaitOnCondition(AddressOf IsLLIGOnCond, 30000, m_EventStopThread) Then
                        strError = "Failed to turn on " & Me.EquipmentName & " IG"
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SafetySwitchIGFilament2")
            Return strError
        End Function

#End Region

#Region "Load"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Load
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Load()
            AVPLib.Log.coreLogger.Info("Enter Load")
            Try
                Dim strErrorMsg As String = String.Empty
                If (CheckPressureCommunication(strErrorMsg)) Then
                    trdLoad = New Thread(AddressOf LoadProc)
                    Me.m_EventStopThread.Reset()
                    trdLoad.Start()
                Else
                    Me.ThrowAlarm(strErrorMsg)
                    Me.m_EventStopThread.WaitOne(1000, True)
                    RaiseFinishLoad(False)

                    'Enable button Clear all wafer
                    EnableButtonClearAllWaferAfterLoad_Unload()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Load")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-28</date>
        ''' </author>
        ''' <summary>
        ''' Map Thread
        ''' </summary>
        ''' <remarks></remarks>
        Private Function DoMapWhenPumpdownReady() As Boolean
            AVPLib.Log.coreLogger.Info("Enter Map")

            Dim blResult As Boolean = False
            Try
                Dim ctlElevator As LLElevatorController = CType(m_htbChildController.Item("LLElevator"), LLElevatorController)
                ''Update GEM
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                              VALUELib.ValueType.U1, ConstEnum.LoadLockState.READY)
                If m_EventStopThread.WaitOne(0, True) Then
                    RaiseFinishLoad(False)
                    AVPLib.Log.coreLogger.Info("Leave LoadProc")
                    Exit Try
                End If
                blResult = ctlElevator.Map()
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[LogLoad]- DoMapWhenPumpdownReady " & blResult)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return blResult
            AVPLib.Log.coreLogger.Info("Leave Map")
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-28</date>
        ''' </author>
        ''' <summary>
        ''' Map Thread
        ''' </summary>
        ''' <remarks></remarks>
        Private Function IsReadyToMapWhenPumpdown() As Boolean
            Return (IsReadyToMap Or ObjectLoadLock.PumpDownStatus = DataManagerment.Equipment.WorkingStatuses.Off)
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-28</date>
        ''' </author>
        ''' <summary>
        ''' Stop wait pumpdown when ready or pumpdown completed <failed>
        ''' </summary>
        ''' <remarks></remarks>
        Private Function IsPumpdownCompleted() As Boolean
            Return (m_objLoadLock.PumpDownStatus = DataManagerment.Equipment.WorkingStatuses.Off)
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-28</date>
        ''' </author>
        ''' <summary>
        ''' Stop wait pumpdown when ready or pumpdown completed <failed>
        ''' </summary>
        ''' <remarks></remarks>
        Private Function IsOtherPumpdownCompleted() As Boolean
            Dim blResult As Boolean = False
            Try
                Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Me.EquipmentName)
                If (roughpumpMachine IsNot Nothing) Then
                    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                        Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                        If (objTM IsNot Nothing AndAlso objTM.PumpDownStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            blResult = False
                            Exit Try
                        End If
                    End If

                    'If (Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString AndAlso RobotConfigurationValues.LOADLOCKB_VISIBLE) Then
                    '    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockB.ToString)) Then
                    '        Dim objLoadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockB.ToString)
                    '        If (objLoadlock IsNot Nothing AndAlso objLoadlock.PumpDownStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    '            blResult = False
                    '            Exit Try
                    '        End If
                    '    End If

                    'ElseIf (Me.EquipmentName = ConstEnum.Equipments.LoadLockB.ToString AndAlso RobotConfigurationValues.LOADLOCKA_VISIBLE) Then
                    'If (roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                    '    Dim objLoadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)
                    '    If (objLoadlock IsNot Nothing AndAlso objLoadlock.PumpDownStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    '        blResult = False
                    '        Exit Try
                    '    End If
                    'End If
                    'End If
                End If

                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-28</date>
        ''' </author>
        ''' <summary>
        ''' waiting for ready to map or pump down completed
        ''' </summary>
        ''' <remarks></remarks>
        Private Function WaitForReadyToMap() As Boolean

            Dim blResult As Boolean = False

            Dim timeout As Integer = VentPumdownLib.LLPumpdownConfig.LLPumpDownComplete
            blResult = Utils.WaitOnCondition(AddressOf IsReadyToMapWhenPumpdown, timeout, m_EventStopThread)

            ' return failed when pump down complete but not ready to map
            blResult = IsReadyToMap

            Return blResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-28</date>
        ''' </author>
        ''' <summary>
        ''' Map Thread
        ''' </summary>
        ''' <remarks></remarks>
        Private Function WaitForPumpdownCompleted() As Boolean
            Dim blResult As Boolean = False

            Dim timeout As Integer = VentPumdownLib.LLPumpdownConfig.LLPumpDownComplete
            blResult = Utils.WaitOnCondition(AddressOf IsPumpdownCompleted, timeout, m_EventStopThread)

            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-28</date>
        ''' </author>
        ''' <summary>
        ''' Map Thread
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StopLoad()
            AVPLib.Log.coreLogger.Info("Enter StopLoad")
            m_EventStopThread.Set()
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                          VALUELib.ValueType.U1, ConstEnum.LoadLockState.IDLE)

            AVPLib.Log.coreLogger.Info("Leave StopLoad")
        End Sub

        Private Function StepCheckLoadlockDoor(Optional ByRef strErrorMsg As String = "") As Boolean
            Dim blResult As Boolean = False
            Try
                Dim serverConfig As Server = Nothing
                Dim objLLElevator As DataManagerment.LLElevator = Nothing
                Dim objLLElevatorController As LLElevatorController = Nothing
                If Me.EquipmentName = AVPLib.ConstEnum.LoadLockA_STR Then
                    serverConfig = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ConstEnum.Equipments.LLAElevator.ToString())
                    objLLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString)
                    objLLElevatorController = CType(m_htbChildController.Item("LLElevator"), LLElevatorController)
                End If

                If serverConfig.IsManualDoorElevator Then
                    'only check and alarm
                    If (Not objLLElevator.DCStatus = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        strErrorMsg = String.Format(ContainerData.GetMessageText("DoorWasNotClose"), Me.EquipmentName)
                        Exit Try
                    Else
                        blResult = True
                    End If
                Else
                    If (objLLElevatorController IsNot Nothing) Then
                        blResult = objLLElevatorController.Close()
                        If (blResult = False) Then
                            strErrorMsg = Me.EquipmentName & " Failed to close Loadlock Door."
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Private Function IsLLdoorClosed() As Boolean
            Dim blResult As Boolean = False
            Try
                blResult = LLCryoUtility.IsLLdoorClosed(Me.EquipmentName)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Thread LoadP
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadProc()
            AVPLib.Log.coreLogger.Info("Enter LoadProc")
            Try
                m_blnIsLoadSeqRunning = True
                m_objLoadLock.LoadStatus = DataManagerment.Equipment.WorkingStatuses.On
                Dim strErrorMsg As String = String.Empty
                Dim AUTO_LOAD_ABORT_BY_USER As String = " Auto Load Abort by user"
                Dim AUTO_LOAD_FAILED As String = " Auto Load Failed."
                Dim AUTO_LOAD_COMPLETED As String = " Auto Load Completed."
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : A NEW THREAD BORN FOR PROCESSING AUTO LOAD.")
                Dim ctlElevator As LLElevatorController = CType(m_htbChildController.Item("LLElevator"), LLElevatorController)
                If m_EventStopThread.WaitOne(0, True) Then
                    Utils.ShowStatusMessage(Me.EquipmentName & AUTO_LOAD_ABORT_BY_USER)
                    RaiseFinishLoad(False)
                    AVPLib.Log.coreLogger.Info("Leave LoadProc")
                    Return
                End If

                Dim check As Boolean = False
                Dim serverConfig As Server = Nothing
                If Me.EquipmentName = AVPLib.ConstEnum.LoadLockA_STR Then
                    serverConfig = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ConstEnum.Equipments.LLAElevator.ToString())
                End If

                'Check if wafer is slide out
                check = (Not ctlElevator.HasWaferSlideOut())

                If check Then
                    If serverConfig.IsManualDoorElevator Then
                        'We assume that the result is ok
                        check = True
                    Else
                        check = ctlElevator.Close()
                    End If
                End If
                
                If (check) Then
                    'reset variable
                    check = False
                    'Transfer from LLX to locationX with LLX isolation is already open.   
                    'Need to check for robot communication and retracted before moving to SlotX.   
                    'This condition also apply during scheduler run.  
                    Dim objRobot As Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString)
                    If (objRobot IsNot Nothing) Then
                        If Utils.IsLLSlitValveOpen(Me.EquipmentName) Then 'slit valve open
                            If (objRobot.IsCommunicating = False) Then 'robot is disconnected->alarm
                                Me.ThrowAlarm("Robot Communication is off.")
                            Else
                                If Not (objRobot.IsRetracted) Then 'robot is not retracted->alarm
                                    If Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString() AndAlso _
                             (objRobot.CurrentPosition = Positions.Arm_At_LLA_Wafer_Extract OrElse _
                             objRobot.CurrentPosition = Positions.Arm_At_LLA_Extract) Then ''check robot is extend at LLA
                                        Me.ThrowAlarm("Robot is not retracted.")
                                    Else
                                        check = True
                                    End If
                                Else
                                    check = True
                                End If
                            End If
                        Else
                            check = True
                        End If
                    End If
                End If

                If (check) Then
                    If m_EventStopThread.WaitOne(0, True) Then
                        RaiseFinishLoad(False)
                        EnableButtonClearAllWaferAfterLoad_Unload()
                        Utils.ShowStatusMessage(Me.EquipmentName & AUTO_LOAD_ABORT_BY_USER)
                        AVPLib.Log.coreLogger.Info("Leave LoadProc")
                        Return
                    End If

                    ' if we has cassette present, then do map
                    Dim elevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ctlElevator.EquipmentName)

                    'check condition to start pump down
                    'if not need do pumpdown -> do some action and return true
                    'has an error when do some action -> return false and Error message <> empty
                    If (IsNeedPumpdownWhenLoadWithRoughOnly(m_EventStopThread, strErrorMsg, True)) Then
                        RaiseStartPumpDown()
                        StartMonitorCGPressure()
                        PumpDown()

                        'sleep for a while
                        If m_EventStopThread.WaitOne(1000, True) Then
                            RaiseFinishLoad(False)
                            EnableButtonClearAllWaferAfterLoad_Unload()
                            StopMonitorCGPressure()
                            Utils.ShowStatusMessage(Me.EquipmentName & AUTO_LOAD_ABORT_BY_USER)
                            AVPLib.Log.coreLogger.Info("Leave LoadProc")
                            Return
                        End If
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[LogLoad]- Load check Door " & elevator.CPStatus.ToString())
                        If (elevator IsNot Nothing) AndAlso (elevator.CPStatus = Equipment.WorkingStatuses.On) Then
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[LogLoad]- WaitForReadyToMap " & WaitForReadyToMap())
                            If (WaitForReadyToMap()) Then
                                check = DoMapWhenPumpdownReady()
                            Else
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[LogLoad]- WaitForReadyToMap false")
                                check = False
                            End If
                        End If

                        WaitForPumpdownCompleted()
                        check = m_IsPumpdownConpleted
                    Else
                        If (strErrorMsg <> String.Empty) Then
                            check = False
                        Else
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[LogLoad]- Load check Door 2" & elevator.CPStatus.ToString())
                            If (elevator IsNot Nothing) AndAlso (elevator.CPStatus = Equipment.WorkingStatuses.On) Then
                                Utils.ShowStatusMessage(Me.EquipmentName & " Map is starting")
                                check = DoMapWhenPumpdownReady()
                            End If
                        End If
                    End If

                    If m_EventStopThread.WaitOne(0, True) Then
                        RaiseFinishLoad(False)
                        EnableButtonClearAllWaferAfterLoad_Unload()
                        StopMonitorCGPressure()
                        Utils.ShowStatusMessage(Me.EquipmentName & AUTO_LOAD_ABORT_BY_USER)
                        AVPLib.Log.coreLogger.Info("Leave LoadProc")
                        Return
                    Else
                        If (check) Then
                            Utils.ShowStatusMessage(Me.EquipmentName & AUTO_LOAD_COMPLETED)
                        Else
                            Utils.ShowStatusMessage(Me.EquipmentName & AUTO_LOAD_FAILED)
                        End If
                    End If
                End If

                RaiseFinishLoad(check)

                'Enable button Clear all wafer
                EnableButtonClearAllWaferAfterLoad_Unload()
                StopMonitorCGPressure()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : THE THREAD PROCESSING AUTO LOAD IS OVER.")
            AVPLib.Log.coreLogger.Info("Leave LoadProc")
        End Sub
        
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-28-08</date>
        ''' </author>
        ''' <summary>
        ''' This function used to Rough Only configuration
        ''' (CG pressure < Cross over pressure) = LL had pumpdown
        ''' in this case we have two option
        ''' + Turbo Ready: Close Rough valve, Open Isolation valve
        ''' + Turbo Not Ready: Open Rough valve
        '''   
        ''' This function called by LL Controller and TM Controller
        ''' + LLController: paramater = EventAbort,ErrorMsg,False
        ''' + TMController: paramater = EventAbort,ErrorMsg,True/False
        ''' + TMHasCloseRoughValve = True -> Open Rough Valve if it's closed
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsNeedPumpdownWhenLoadWithRoughOnly(ByVal abortEvent As ManualResetEvent, ByRef strErrorMsg As String, ByVal isNeedOpenCloseTMIG As Boolean, Optional ByVal NeedOpenLLRoughValve As Boolean = True) As Boolean
            Dim AUTO_LOAD_ABORT_BY_USER As String = " Auto Load Abort by user"
            Dim blResult As Boolean = True
            Dim objTMController As TMController = ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString)
            Dim strErrorPressure As String = String.Empty
            Try
                If ObjectLoadLock IsNot Nothing AndAlso ObjectLoadLock.IsRoughOnlyMode() Then

                    If (IsLLCGDisconnected()) Then
                        strErrorMsg = Utils.chamberID2ChamberName(Me.EquipmentName) & CG_DISCONNECTED
                        Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                        Exit Try
                    End If

                    If (IsLLCGReachCrossOverPressureAndCGRelayOnCond()) Then
                        blResult = False
                        If (IsTMPumpPackageReady()) Then
                            Dim objLoadlock As LoadLock = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)

                            'Close Rough
                            If (objLoadlock IsNot Nothing AndAlso objLoadlock.FastRoughValveStatus = Equipment.WorkingStatuses.On) Then
                                strErrorMsg = LLCryoUtility.CloseLLFastRough(Me.EquipmentName)
                            End If
                            If (strErrorMsg <> String.Empty) Then
                                Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                                Exit Try
                            End If

                            If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                                If (objLoadlock IsNot Nothing AndAlso objLoadlock.SlowRoughValveStatus = Equipment.WorkingStatuses.On) Then
                                    strErrorMsg = LLCryoUtility.CloseLLSlowRough(Me.EquipmentName)
                                End If
                                If (strErrorMsg <> String.Empty) Then
                                    Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                                    Exit Try
                                End If
                            End If

                            If (objTMController.CheckCG10DifferenceFromStationForLoad(Me.EquipmentName, strErrorPressure)) Then
                                'Open Slit valve
                                If (Not IsLLIsoValveOpenCond()) Then
                                    StepOpenLLIsolationValveValve(EQName4UserReading & AUTO_LOAD_ABORT_BY_USER, strErrorMsg, abortEvent)
                                End If

                                If (strErrorMsg <> String.Empty) Then
                                    Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                                    Exit Try
                                End If
                            ElseIf (Not IsLLIsoValveOpenCond()) Then
                                If (isNeedOpenCloseTMIG) Then
                                    'Turn Off IG
                                    If (objTMController.IsTMIGOnCond) Then
                                        objTMController.StepTurnOffTMIG_Wait4IGOff(strErrorMsg, True, Me.EquipmentName & AUTO_LOAD_ABORT_BY_USER, abortEvent)
                                    End If

                                    If (strErrorMsg <> String.Empty) Then
                                        Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                                        Exit Try
                                    End If
                                End If

                                'Open Slit valve
                                If (Not IsLLIsoValveOpenCond()) Then
                                    StepOpenLLIsolationValveValve(EQName4UserReading & AUTO_LOAD_ABORT_BY_USER, strErrorMsg, abortEvent)
                                End If

                                If (strErrorMsg <> String.Empty) Then
                                    Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                                    Exit Try
                                End If

                                If (isNeedOpenCloseTMIG) Then
                                    'wait 30s
                                    Dim imilliseconds As Integer = VentPumdownLib.LLPumpdownConfig.LLPumpDown_Wait_After_Open_TM_TurboForeline
                                    Utils.ShowStatusMessage("Wait " & TimeSpan.FromMilliseconds(imilliseconds).TotalSeconds & "s")
                                    Utils.Wait(imilliseconds, abortEvent)

                                    'Turn On IG
                                    If (objTMController.IsTMIGOffCond) Then
                                        objTMController.StepTurnOnTMIG(strErrorMsg, Me.EquipmentName & AUTO_LOAD_ABORT_BY_USER, abortEvent)
                                    End If

                                    If (strErrorMsg <> String.Empty) Then
                                        Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                                        Exit Try
                                    End If
                                End If
                            End If
                        ElseIf (NeedOpenLLRoughValve) Then

                            Dim objLoadlock As LoadLock = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)

                            'Close Slit valve
                            If (Not IsLLIsoValveCloseCond()) Then
                                StepCloseLLIsolationValve(EQName4UserReading & AUTO_LOAD_ABORT_BY_USER, strErrorMsg, False, abortEvent)
                            End If
                            If (strErrorMsg <> String.Empty) Then
                                Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                                Exit Try
                            End If

                            'Open Rough
                            If (objLoadlock IsNot Nothing AndAlso objLoadlock.FastRoughValveStatus = Equipment.WorkingStatuses.Off) Then
                                strErrorMsg = LLCryoUtility.OpenLLFastRough(Me.EquipmentName, False, False)
                            End If
                            If (strErrorMsg <> String.Empty) Then
                                Me.ThrowAlarm(strErrorMsg, AVPLib.ConstEnum.GEM_ALARM_SUB_PUMPDOWN_FAILED)
                                Exit Try
                            End If
                        End If
                        'Else 'CG Not reach cross over pressure and CG Relay is not On
                        ' do nothing
                        'TMPumpdwon first, it will be close LL Rough valve 
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Raise Finish Load
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub RaiseFinishLoad(ByVal check As Boolean)
            AVPLib.Log.coreLogger.Info("Enter RaiseFinishLoad")
            Try
                m_blnIsLoadSeqRunning = False
                Dim ReplyValues As ArrayList = New ArrayList()

                If check Then
                    ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)

                    '0000575: [KhoiHa 23-03-2012] - Logs need to show source as LoadLockA or LoadlockB. Text �Load scheduler�...
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, Utils.chamberID2ChamberName(Me.EquipmentName), _
                                                                   "[Main Screen] " + " Load completed.")
                Else
                    ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
                End If

                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("LoadStatus")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseFinishLoad")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' -	CX5/CXX.  �Clear all wafer� button should not be available when LLx is loading/unloading.   
        '''This is a very dangerous situation since loading/unload require cassette movement where it could damage 
        '''the robot arms since these two sequence does not check for safety condition of other sequence�   
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub EnableButtonClearAllWaferAfterLoad_Unload()
            AVPLib.Log.coreLogger.Info("Enter EnableButtonClearAllWaferAfterLoad_Unload")
            Try
                If (Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString) Then
                    'If (RobotConfigurationValues.LOADLOCKB_VISIBLE) Then
                    '    Dim objLLB As DataManagerment.LoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockB.ToString)
                    '    If (objLLB.LoadStatus = DataManagerment.Equipment.WorkingStatuses.Off AndAlso _
                    '        objLLB.UnloadStatus = DataManagerment.Equipment.WorkingStatuses.Off) Then
                    '        AVPLib.Utils.EnableDisableClearAllWaferButton(AVPLib.ConstEnum.STR_ON)
                    '    End If
                    'Else
                    AVPLib.Utils.EnableDisableClearAllWaferButton(AVPLib.ConstEnum.STR_ON)
                    'End If
                    'ElseIf (Me.EquipmentName = ConstEnum.Equipments.LoadLockB.ToString) Then
                    'If (RobotConfigurationValues.LOADLOCKA_VISIBLE) Then
                    '    Dim objLLA As DataManagerment.LoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)
                    '    If (objLLA.LoadStatus = DataManagerment.Equipment.WorkingStatuses.Off AndAlso _
                    '        objLLA.UnloadStatus = DataManagerment.Equipment.WorkingStatuses.Off) Then
                    '        AVPLib.Utils.EnableDisableClearAllWaferButton(AVPLib.ConstEnum.STR_ON)
                    '    End If
                    'Else
                    '    AVPLib.Utils.EnableDisableClearAllWaferButton(AVPLib.ConstEnum.STR_ON)
                    'End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave EnableButtonClearAllWaferAfterLoad_Unload")
        End Sub
#End Region

#Region "Unload"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' UnLoad
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub UnLoad()
            AVPLib.Log.coreLogger.Info("Enter UnLoad")
            Try
                Dim strErrorMsg As String = String.Empty
                If (CheckPressureCommunication(strErrorMsg)) Then
                    RaiseStartUnLoad()
                    trdUnLoad = New Thread(AddressOf UnLoadProc)
                    Me.m_EventStopThread.Reset()
                    trdUnLoad.Start()
                Else
                    Me.ThrowAlarm(strErrorMsg)

                    RaiseFinishUnLoad(False)
                    'Enable button Clear All Wafer after Unload
                    EnableButtonClearAllWaferAfterLoad_Unload()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UnLoad")
        End Sub

        Public Sub StopUnLoad()
            AVPLib.Log.coreLogger.Info("Enter StopLoad")
            m_EventStopThread.Set()
            ''update gem
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                          VALUELib.ValueType.U1, ConstEnum.LoadLockState.IDLE)
            AVPLib.Log.coreLogger.Info("Leave StopLoad")
        End Sub

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Thread UnLoad
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UnLoadProc()
            AVPLib.Log.coreLogger.Info("Enter UnLoadProc")
            Try
                m_blnIsUnloadSeqRunning = True
                AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : A NEW THREAD BORN FOR PROCESSING AUTO UNLOAD.")
                Dim ctlElevator As LLElevatorController = CType(m_htbChildController.Item("LLElevator"), LLElevatorController)
                If m_EventStopThread.WaitOne(0, True) Then
                    RaiseFinishUnLoad(False)
                    AVPLib.Log.coreLogger.Info("Leave UnLoadProc")
                    Return
                End If
                'Dat Cao Change "12" to num of slot on loadlock------------------------
                Dim num_of_slot As String = "12"
                If (Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString()) Then
                    num_of_slot = RobotConfigurationValues.SLOT_NUM_LLA
                End If
                Dim check As Boolean = Utils.CheckRateOfRaiseIsRunning(Me.EquipmentName, STR_SEQUENCE_UNLOAD)

                'Transfer from LLX to locationX with LLX isolation is already open.   
                'Need to check for robot communication and retracted before moving to SlotX.   
                'This condition also apply during scheduler run.  
                If check Then
                    check = False
                    Dim objRobot As Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString)
                    If (objRobot IsNot Nothing) Then
                        If Utils.IsLLSlitValveOpen(Me.EquipmentName) Then 'slit valve open
                            If (objRobot.IsCommunicating = False) Then ' robot disconnect->Alarm
                                Me.ThrowAlarm("Robot Communication is off.")
                            Else
                                If Not (objRobot.IsRetracted) Then 'robot is not retracted->Alarm
                                    If Me.EquipmentName = ConstEnum.Equipments.LoadLockA.ToString() AndAlso _
                                    (objRobot.CurrentPosition = Positions.Arm_At_LLA_Wafer_Extract OrElse _
                                    objRobot.CurrentPosition = Positions.Arm_At_LLA_Extract) Then ''check robot is extend at LLA
                                        Me.ThrowAlarm("Robot is not retracted.")
                                    Else
                                        check = True
                                    End If
                                Else
                                    check = True
                                End If
                            End If
                        Else
                            check = True
                        End If
                    End If
                End If

                'after check communication and retract status -> goto slot
                If (check) Then
                    check = ctlElevator.WaitReadyAndGotoSlot(num_of_slot)
                End If

                If check Then
                    If m_EventStopThread.WaitOne(0, True) Then
                        RaiseFinishUnLoad(False)
                        EnableButtonClearAllWaferAfterLoad_Unload()
                        AVPLib.Log.coreLogger.Info("Leave UnLoadProc")
                        Return
                    End If

                    RaiseStartAutoVent()
                    check = Me.CheckAutoVent()
                    RaiseFinishAutoVent()

                    If check Then
                        ''Update GEM
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                                      VALUELib.ValueType.U1, ConstEnum.LoadLockState.IDLE)

                        If m_EventStopThread.WaitOne(0, True) Then
                            RaiseFinishUnLoad(False)
                            EnableButtonClearAllWaferAfterLoad_Unload()
                            AVPLib.Log.coreLogger.Info("Leave UnLoadProc")
                            Return
                        End If

                        Dim serverConfig As Server = Nothing
                        If Me.EquipmentName = AVPLib.ConstEnum.LoadLockA_STR Then
                            serverConfig = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ConstEnum.Equipments.LLAElevator.ToString())
                        End If

                        If serverConfig.IsManualDoorElevator Then
                            'We assume that the 
                            check = ctlElevator.Open(True)
                        Else
                            check = ctlElevator.Open(False)
                        End If
                    Else
                        ''Update GEM
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                                      VALUELib.ValueType.U1, ConstEnum.LoadLockState.ERROR)

                    End If
                End If
                RaiseFinishUnLoad(check)

                'Enable button Clear All Wafer after Unload
                EnableButtonClearAllWaferAfterLoad_Unload()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Debug(Me.EquipmentName & " : THE THREAD PROCESSING AUTO UNLOAD IS OVER")
            AVPLib.Log.coreLogger.Info("Leave UnLoad")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Raise Finish UnLoad
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub RaiseFinishUnLoad(ByVal check As Boolean)
            AVPLib.Log.coreLogger.Info("Enter RaiseFinishUnLoad")
            Try
                m_blnIsUnloadSeqRunning = False
                Dim ReplyValues As ArrayList = New ArrayList()
                If check Then

                    ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
                    '''''''''''''''
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                                  VALUELib.ValueType.U1, ConstEnum.LoadLockState.IDLE)

                    '0000575: [KhoiHa 23-03-2012] - Logs need to show source as LoadLockA or LoadlockB. Text �Load scheduler�...
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, Utils.chamberID2ChamberName(Me.EquipmentName), _
                                                                   "[Main Screen] " + " Unload completed.")
                Else
                    ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
                    ''''''''''''''''''''''''''''''''''''
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                                  VALUELib.ValueType.U1, ConstEnum.LoadLockState.ERROR)

                End If

                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("UnloadStatus")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseFinishUnLoad")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-08</date>
        ''' </author>
        ''' <summary>
        ''' Raise Finish UnLoad
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub RaiseStartUnLoad()
            AVPLib.Log.coreLogger.Info("Enter RaiseFinishUnLoad")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()

                ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.On)
                ''''''''''''''''''''''''''''''''''''
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.EquipmentName, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                              VALUELib.ValueType.U1, ConstEnum.LoadLockState.VENTING)

                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("UnloadStatus")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseFinishUnLoad")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-06-20</date>
        ''' </author>
        ''' <summary>
        ''' Users set up (check)Auto vent down when processing completed
        ''' When the processing completed its venting down but THE load button is still enable ,
        ''' then Users can freely load LLx when its venting .So when The Processing completed and 
        ''' the venting action is in process should DISABLE LOAD/UNLOAD button as well Reported by Tin vu
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ChangeLoadUnloadStatus(ByVal IsOn As Boolean, ByVal IsLoadStatus As Boolean)
            AVPLib.Log.coreLogger.Info("Enter ChangeLoadStatus")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()

                If IsOn Then
                    Dim ctlElevator As ControllerObject = Me.ChildController.Item("LLElevator")
                    Dim LLElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ctlElevator.EquipmentName)
                    ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.On)
                Else
                    ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
                End If

                Dim PropertyNames As ArrayList = New ArrayList()
                If (IsLoadStatus) Then
                    PropertyNames.Add("AutoVentButtonLoadStatus")
                Else
                    PropertyNames.Add("AutoVentButtonUnLoadStatus")
                End If
                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ChangeLoadStatus")
        End Sub
#End Region

#Region "Another"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do Serial Command RobotController
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Public Overrides Sub DoSerialCommand(ByVal Command As String)
            AVPLib.Log.coreLogger.Info("Enter DoSerialCommand")
            Try
                Dim intPos As Integer = Command.IndexOf("Elevator")
                If (intPos >= 0) Then
                    Dim ctlElevator As LLElevatorController = CType(m_htbChildController.Item("LLElevator"), LLElevatorController)
                    ctlElevator.DoSerialCommand(Command)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoSerialCommand")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Start LoadLockController
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Start()
            AVPLib.Log.coreLogger.Info("Enter Start")
            If String.IsNullOrEmpty(m_strSequenceID) Then
                AVPLib.Log.avpLogger.Error("Failed to start Ctrl Job beause sequence is Null.")
            End If
            Try
                'If ObjectLoadLock Is Nothing Then
                '    AVPLib.Log.avpLogger.Error("Object is not set")
                '    Exit Try
                'End If
                ''ObjectLoadLock.StartStatus = Equipment.ProcessStatuses.PAUSE
                'Create the control Job
                m_strCtrlJobId = AVPLib.Business.AVPCore.Instance().JobManager().CreateControlJob(Me.EquipmentName, m_strLotID, m_strSequenceID)
                'Start the processing
                AVPLib.Business.AVPCore.Instance().JobManager().CJCommand(m_strCtrlJobId, ConstEnum.CJ_CMDS.CJ_CMD_START)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Start")
        End Sub

        Public Sub [Stop]()
            AVPLib.Log.coreLogger.Info("Enter [Stop]")
            Try
                If ObjectLoadLock Is Nothing Then
                    AVPLib.Log.avpLogger.Error("Object is not set")
                    Exit Try
                End If
                ObjectLoadLock.StartStatus = Equipment.ProcessStatuses.START
                AVPLib.Business.AVPCore.Instance().JobManager().CJCommand(m_strCtrlJobId, ConstEnum.CJ_CMDS.CJ_CMD_STOP)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave [Stop]")
        End Sub



        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Pause LoadLockController
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Pause()
            AVPLib.Log.coreLogger.Info("Enter Pause")
            Try
                If ObjectLoadLock Is Nothing Then
                    AVPLib.Log.avpLogger.Error("Object is not set")
                    Exit Try
                End If
                ObjectLoadLock.StartStatus = Equipment.ProcessStatuses.RESUME
                AVPLib.Business.AVPCore.Instance().JobManager().CJCommand(m_strCtrlJobId, ConstEnum.CJ_CMDS.CJ_CMD_PAUSE)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Pause")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Resume LoadLockController
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub [Resume]()
            AVPLib.Log.coreLogger.Info("Enter [Resume]")
            Try
                If ObjectLoadLock Is Nothing Then
                    AVPLib.Log.avpLogger.Error("Object is not set")
                    Exit Try
                End If
                ObjectLoadLock.StartStatus = Equipment.ProcessStatuses.PAUSE
                AVPLib.Business.AVPCore.Instance().JobManager().CJCommand(m_strCtrlJobId, ConstEnum.CJ_CMDS.CJ_CMD_RESUME)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave [Resume]")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Abort LoadLockController
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Abort(ByVal bReturnAllWafers As Boolean)
            AVPLib.Log.coreLogger.Info("Enter Abort")

            AVPLib.Log.coreLogger.Warn("Aborting ...")

            Try
                AVPLib.Business.AVPCore.Instance().JobManager().CJCommand(m_strCtrlJobId, ConstEnum.CJ_CMDS.CJ_CMD_ABORT, bReturnAllWafers.ToString())
                ''Raise to GEM ProcessingAbort : Truc Le
                AVPLib.Business.AVPSecsGemLib.TriggerEvent(Me.EquipmentName, "ProcessingAborted")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Public Sub ForceAbort()
            AVPLib.Log.coreLogger.Info("Enter ForceAbort")
            Try
                If Not String.IsNullOrEmpty(m_strCtrlJobId) Then
                    AVPLib.Business.AVPCore.Instance().JobManager().CJCommand(m_strCtrlJobId, ConstEnum.CJ_CMDS.CJ_CMD_FORCE_ABORT)
                    ''Raise to GEM ProcessingAbort : Truc Le
                    AVPLib.Business.AVPSecsGemLib.TriggerEvent(Me.EquipmentName, "ProcessingAborted")
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ForceAbort")
        End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Reset Wafer Count
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ResetWaferCount()
            AVPLib.Log.coreLogger.Info("Enter ResetWaferCount")
            Try
                ObjectLoadLock.ResetWaferCount()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ResetWaferCount")
        End Sub

#End Region
#End Region

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
        
        Private Class LLAMonitorCGPressureThread
            Inherits SuspendableThread
            Private Shared objLoadlock As LoadLock = Nothing
            Private Shared m_ReadyToMap As Boolean = False
            Public Sub New()
                MyBase.New()
            End Sub
            Public Shared ReadOnly Property ReadyToMap()
                Get
                    Return m_ReadyToMap
                End Get
            End Property
            Protected Overrides Sub OnDoWork()
                Try
                    m_ReadyToMap = False
                    While False = HasTerminateRequest()

                        Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                        If (awokenByTerminate) Then
                            Exit While
                        End If

                        If (objLoadlock IsNot Nothing AndAlso objLoadlock.CG <= VentPumdownLib.LLPumpdownConfig.LLMappingPressure) Then
                            m_ReadyToMap = True
                            Exit While
                        End If

                        ' Sleep for a while, then resume checking.
                        If IsStoping(500) Then
                            Return
                        End If
                    End While
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Error(ex.Message)
                End Try
            End Sub

            Private Shared m_MonitorCGPressureThread As LLAMonitorCGPressureThread = Nothing
            ''' <summary>
            ''' Start Safety Interlock Loop
            ''' </summary>
            ''' <returns></returns>
            Public Shared Sub StartMonitorCGPressure(ByVal EquipmentName As String)
                objLoadlock = DataManagerment.EquipmentManager.GetEquipment(EquipmentName)
                ' Lazy Initialization
                If m_MonitorCGPressureThread Is Nothing Then
                    m_MonitorCGPressureThread = New LLAMonitorCGPressureThread()
                End If
                m_MonitorCGPressureThread.Start()
            End Sub
            ''' <summary>
            ''' Stop Safety Interlock Loop
            ''' </summary>
            ''' <returns></returns>
            Public Shared Sub StopMonitorCGPressure()
                If m_MonitorCGPressureThread IsNot Nothing Then
                    m_MonitorCGPressureThread.TerminateAndWait()
                    m_MonitorCGPressureThread.Dispose()
                End If
            End Sub
        End Class
    End Class
End Namespace

