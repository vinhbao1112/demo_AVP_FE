Imports System.Threading
Imports AVPLib.Business
Imports AVPLib.Business.ChamberController
Imports AVPLib.ConstEnum
Namespace DataManagerment
    Public Class CassettesModule
        Inherits Equipment
#Region "Class Constants & Variables"
        Private m_dblPressureDifferential As Double ''10%, 20%...
        Private m_strCoreMessageBox As String
        Private m_strRoughPump1InUse As String
        Private m_strRoughPump2InUse As String
        Private m_strManualTransferStatus As String
        Private m_dblPressure As Double
        Private m_dblIG As Double
        Private m_dblCG As Double

        'support detect device net communication
        Protected m_IG_Communication As WorkingStatuses = WorkingStatuses.On
        Protected m_CG_Communication As WorkingStatuses = WorkingStatuses.On
        Protected m_PressureError As String
        Protected m_TurboForelineCG_Communication As WorkingStatuses = WorkingStatuses.On

        Private m_enmIGStatus As WorkingStatuses
        Private m_SwitchIGFilament As Integer
        Private m_enmFastRoughValveStatus As WorkingStatuses
        Private m_enmFastVentValveStatus As WorkingStatuses
        Private m_enmHiVacValveStatus As WorkingStatuses
        Private m_enmHiVacValveOpenStatus As WorkingStatuses = WorkingStatuses.Unknown
        Private m_enmHiVacValveCloseStatus As WorkingStatuses = WorkingStatuses.Unknown

        Private m_enmControlStatus As ControlStatuses
        Private m_enmAutoVentStatus As WorkingStatuses
        Private m_enmPumpDownStatus As WorkingStatuses
        Private m_enmIG_Degas_Status As WorkingStatuses
        Private m_enmVacSwitchStatus As WorkingStatuses

        Private m_SlitValveLLAStatus As WorkingStatuses = WorkingStatuses.Unknown
        Private m_SlitValveLLAOpenStatus As WorkingStatuses = WorkingStatuses.Unknown
        Private m_SlitValveLLACloseStatus As WorkingStatuses = WorkingStatuses.Unknown

        Private m_SlitValvePM1Status As WorkingStatuses = WorkingStatuses.Unknown
        Private m_SlitValvePM1OpenStatus As WorkingStatuses = WorkingStatuses.Unknown
        Private m_SlitValvePM1CloseStatus As WorkingStatuses = WorkingStatuses.Unknown

        Private m_SlitValvePM2Status As WorkingStatuses = WorkingStatuses.Unknown
        Private m_SlitValvePM2OpenStatus As WorkingStatuses = WorkingStatuses.Unknown
        Private m_SlitValvePM2CloseStatus As WorkingStatuses = WorkingStatuses.Unknown

        Private m_SlitValvePM3Status As WorkingStatuses = WorkingStatuses.Unknown
        Private m_SlitValvePM3OpenStatus As WorkingStatuses = WorkingStatuses.Unknown
        Private m_SlitValvePM3CloseStatus As WorkingStatuses = WorkingStatuses.Unknown

        ' Lock objects cho từng split valve group - tránh deadlock
        Private m_lockSplitValve1 As New Object()
        Private m_lockSplitValve2 As New Object()
        Private m_lockSplitValve3 As New Object()
        Private m_lockSplitValve4 As New Object()
        Private m_lockHiVacValve As New Object()

        Protected m_enmSensorLLAStatus As WorkingStatuses
        Protected m_enmSensorPM1Status As WorkingStatuses
        Protected m_enmSensorPM2Status As WorkingStatuses
        Protected m_enmSensorPM3Status As WorkingStatuses
        Private m_enmRPRelayIndicatorStatus As WorkingStatuses

        Private m_RateOfRise_Status As WorkingStatuses
        Private m_strRateOfRise_Sample As String
        Private m_strRateOfRise_FileName As String

        Private m_PumpDown_Curve_Status As WorkingStatuses
        Private m_strPumpDown_Curve_Sample As String
        Private m_strPumpDown_Curve_FileName As String
        Private m_RoughPump1Status As WorkingStatuses
        Private m_RoughPump2Status As WorkingStatuses
        Private m_enmOverideModeStatus As WorkingStatuses
        Private m_iLifeTimeWafer As Integer
        Private m_iWaferCount As Integer
        Private m_enmTurboValveStatus As WorkingStatuses = WorkingStatuses.Off
        Private m_dblTurboForelineCG As Double
        Private m_enmTurboForeLineCGRelay As WorkingStatuses = WorkingStatuses.Unknown
        Private m_Process_Complete_Chime As WorkingStatuses = WorkingStatuses.Unknown
        Private m_strCassetteFinish As String = String.Empty

        Protected m_blKepWareServerDisConnected As Boolean = True

        Public Property KepWareServerDisConnected() As Boolean
            Get
                Return m_blKepWareServerDisConnected
            End Get
            Set(ByVal value As Boolean)
                m_blKepWareServerDisConnected = value
            End Set
        End Property

        Public Property Process_Complete_Chime() As WorkingStatuses
            Get
                Return m_Process_Complete_Chime
            End Get
            Set(ByVal value As WorkingStatuses)
                m_Process_Complete_Chime = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-05-15</date>
        ''' </author>
        ''' <summary>
        ''' ONLY USED FOR SET TO IBE PVD SLITVALVE STATUS
        ''' DO NOT USED ANYWHERE
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Structure ChamberSlitValveMsg
            Dim SlitValveName As String
            Dim Value As WorkingStatuses
        End Structure
        Private Sub SendSplitValveStatus_ToPM(ByVal value As Object)
            AVPLib.Log.coreLogger.Info("Enter SendToPVDSlitValveStatus")
            Try
                Dim ChamberSlitValveValue As ChamberSlitValveMsg = CType(value, ChamberSlitValveMsg)
                Utils.SendSplitValveStatus_ToPM(ChamberSlitValveValue.SlitValveName, ChamberSlitValveValue.Value)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Info("Enter SendToPVDSlitValveStatus")
            End Try
            AVPLib.Log.coreLogger.Info("Enter SendToPVDSlitValveStatus")
        End Sub
#End Region

#Region "Property"
        'Function UpdateCGRelay(ByVal value As WorkingStatuses) As Boolean

        '    Dim PropertyNames As ArrayList = New ArrayList()
        '    PropertyNames.Add("VacSwitchStatus")

        '    Dim ReplyValues As ArrayList = New ArrayList()
        '    ReplyValues.Add(value)

        '    AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
        'End Function

        Function UpdatePressureError(ByVal sDeviceName As String, ByVal value As Double) As Boolean

            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(value)

            Dim PropertyNames As ArrayList = New ArrayList()

            Select Case sDeviceName
                Case "IG"
                    PropertyNames.Add("IGPressureError")
                Case "CG"
                    PropertyNames.Add("CGPressureError")
                Case "TurboForelineCG"
                    PropertyNames.Add("TurboForelineCGError")
            End Select

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
        End Function
        Function UpdateTurboCGPressureError() As Boolean

            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add("Error")

            Dim PropertyNames As ArrayList = New ArrayList()

            PropertyNames.Add("TurboForelineCGError")

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
        End Function
        Public Property IG_Communication() As WorkingStatuses
            Get
                Return m_IG_Communication
            End Get
            Set(ByVal value As WorkingStatuses)
                m_IG_Communication = value

                'Need change to Off when commit
                If (m_IG_Communication = WorkingStatuses.Off) Then

                    IGStatus = WorkingStatuses.Off
                    m_dblIG = -1.0
                    UpdatePressureError("IG", m_dblIG)
                End If

            End Set
        End Property
        Public Property CG_Communication() As WorkingStatuses
            Get
                Return m_CG_Communication
            End Get
            Set(ByVal value As WorkingStatuses)
                m_CG_Communication = value

                'Need change to Off when commit
                If (m_CG_Communication = WorkingStatuses.Off) Then
                    m_dblCG = -1.0
                    UpdatePressureError("CG", m_dblCG)
                    ''0005537: [KhoiHa- 08/21/2014][VCO19]When TM CG device is disconnected, shutdown system and restart application, 
                    ''TM relay pressure still shows ON. Re-check this case in LL and PM
                    'UpdateCGRelay(value)
                End If
            End Set
        End Property

        Public Property PressureError() As String
            Get
                Return m_PressureError
            End Get
            Set(ByVal value As String)
                m_PressureError = value
            End Set
        End Property

        Public Property TurboForelineCG_Communication() As WorkingStatuses
            Get
                Return m_TurboForelineCG_Communication
            End Get
            Set(ByVal value As WorkingStatuses)
                m_TurboForelineCG_Communication = value

                'Need change to Off when commit
                If (m_TurboForelineCG_Communication = WorkingStatuses.Off) Then
                    m_dblTurboForelineCG = -1.0
                    UpdateTurboCGPressureError()
                    'Dim objTMController As Business.TMController = Business.ControllerManager.GetController(Me.Name)
                    'If objTMController IsNot Nothing Then
                    '    objTMController.ThrowAlarm("TM Turbo Forline CG is disconnected.")
                    'End If
                    'DoActionTurboForlineCGOff()
                End If

            End Set
        End Property

        Public Sub DoActionTurboForlineCGOff()
            If (RobotConfigurationValues.TMTURBO_VISIBLE) Then
                Business.TMCryoUtility.TurnOffIG(Me.Name)
                Business.TMCryoUtility.CloseTMTurboForeLineValve(Me.Name)
                Business.TMCryoUtility.CloseHiVacValve(Me.Name)
                Dim objTMTurboCtrl As Business.TurboController = Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
                If objTMTurboCtrl IsNot Nothing Then
                    objTMTurboCtrl.TurnOff()
                End If
            End If
        End Sub

        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PressureDifferentialPercent() As Double '''10%, 20%...
            Get
                Return m_dblPressureDifferential
            End Get
            Set(ByVal value As Double)
                m_dblPressureDifferential = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OverideModeStatus() As WorkingStatuses
            Get
                Return m_enmOverideModeStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmOverideModeStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: OverideModeOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "OverideModeOnOff", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LifeTimeWafer() As Integer
            Get
                Return m_iLifeTimeWafer
            End Get
            Set(ByVal value As Integer)
                m_iLifeTimeWafer = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: OverideModeOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "LifeTimeWafer", VALUELib.ValueType.F4, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WaferCount() As Integer
            Get
                Return m_iWaferCount
            End Get
            Set(ByVal value As Integer)
                m_iWaferCount = value
            End Set
        End Property

        Public Property CoreMessageBox() As String
            Get
                Return m_strCoreMessageBox
            End Get
            Set(ByVal value As String)
                m_strCoreMessageBox = value
            End Set
        End Property

        Public Property ManualTransferStatus() As String
            Get
                Return m_strManualTransferStatus
            End Get
            Set(ByVal value As String)
                m_strManualTransferStatus = value
            End Set
        End Property

        Public Property RoughPump1Status() As WorkingStatuses
            Get
                Return m_RoughPump1Status
            End Get
            Set(ByVal value As WorkingStatuses)
                m_RoughPump1Status = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: RoughPumpPowerOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "RoughPump1PowerOnOff", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Property RoughPump2Status() As WorkingStatuses
            Get
                Return m_RoughPump2Status
            End Get
            Set(ByVal value As WorkingStatuses)
                m_RoughPump2Status = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: RoughPumpPowerOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "RoughPump2PowerOnOff", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Property RoughPumpMachine1InUse() As String
            Get
                Return m_strRoughPump1InUse
            End Get
            Set(ByVal value As String)
                m_strRoughPump1InUse = value
                UpdateRoughPumpMachineInUseToChamber(m_strRoughPump1InUse)
            End Set
        End Property

        Public Property RoughPumpMachine2InUse() As String
            Get
                Return m_strRoughPump2InUse
            End Get
            Set(ByVal value As String)
                m_strRoughPump2InUse = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2010-1-22</date>
        ''' </author>
        ''' <summary>
        ''' Get current sensor status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SensorLLAStatus() As WorkingStatuses
            Get
                Return m_enmSensorLLAStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmSensorLLAStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Sensor1Status
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Sensor1Status", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2010-1-22</date>
        ''' </author>
        ''' <summary>
        ''' Get current sensor status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SensorPM1Status() As WorkingStatuses
            Get
                Return m_enmSensorPM1Status
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmSensorPM1Status = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Sensor2Status
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Sensor2Status", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2010-1-22</date>
        ''' </author>
        ''' <summary>
        ''' Get current sensor status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SensorPM2Status() As WorkingStatuses
            Get
                Return m_enmSensorPM2Status
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmSensorPM2Status = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Sensor3Status
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Sensor3Status", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2010-1-22</date>
        ''' </author>
        ''' <summary>
        ''' Get current sensor status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SensorPM3Status() As WorkingStatuses
            Get
                Return m_enmSensorPM3Status
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmSensorPM3Status = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Sensor4Status
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Sensor4Status", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''    	<name>Truc Le</name>
        '''    	<date> 2010-1-22</date>
        ''' </author>
        ''' <summary>
        ''' Get current sensor status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RPump_RelayIndicatorStatus() As WorkingStatuses
            Get
                Return m_enmRPRelayIndicatorStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmRPRelayIndicatorStatus = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc</name>
        '''    	<date> 2009-01-21</date>
        ''' </author>
        ''' <summary>
        ''' Get current SlitValve1Status-->LLA
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SplitValve1Status() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve1
                    Return GetSplitValve1StatusInternal()
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve1
                    m_SlitValveLLAStatus = value
                    ' Update SECS/GEM variables by Truc Le
                    ' Var Name: IsolationValveStatus
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.LoadLockA_STR, EMSERVICELib.VarType.SV, "IsolationValveStatus", VALUELib.ValueType.U1, value)
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or set SplitValve1OpenStatus
        ''' </summary>
        ''' <value></value>
        Public Property SplitValve1OpenStatus() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve1
                    Return m_SlitValveLLAOpenStatus
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve1
                    If m_SlitValveLLAOpenStatus <> value Then
                        m_SlitValveLLAOpenStatus = value
                        Dim currentStatus As WorkingStatuses = GetSplitValve1StatusInternal()
                        Utils.ChangeStatusForFor2Channel(Me.Name, "SplitValve1Status", currentStatus)
                    End If
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or set SplitValve1CloseStatus
        ''' </summary>
        ''' <value></value>
        Public Property SplitValve1CloseStatus() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve1
                    Return m_SlitValveLLACloseStatus
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve1
                    If m_SlitValveLLACloseStatus <> value Then
                        m_SlitValveLLACloseStatus = value
                        Dim currentStatus As WorkingStatuses = GetSplitValve1StatusInternal()
                        Utils.ChangeStatusForFor2Channel(Me.Name, "SplitValve1Status", currentStatus)
                    End If
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc</name>
        '''    	<date> 2009-01-21</date>
        ''' </author>
        ''' <summary>
        ''' Get current SlitValve2Status--Chamber 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SplitValve2Status() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve2
                    Return GetSplitValve2StatusInternal()
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve2
                    If m_SlitValvePM1Status <> value Then
                        m_SlitValvePM1Status = value
                        Dim slitvalveValue As ChamberSlitValveMsg
                        slitvalveValue.SlitValveName = ConstEnum.Equipments.Chamber1.ToString()
                        slitvalveValue.Value = value
                        ThreadPool.QueueUserWorkItem(AddressOf SendSplitValveStatus_ToPM, slitvalveValue)
                    End If
                    ' Update SECS/GEM variables by Truc Le
                    ' Var Name: IsolationValveStatus
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.Equipments.Chamber1.ToString(), EMSERVICELib.VarType.SV, "IsolationValveStatus", VALUELib.ValueType.U1, value)
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or set SplitValve2OpenStatus
        ''' </summary>
        ''' <value></value>
        Public Property SplitValve2OpenStatus() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve2
                    Return m_SlitValvePM1OpenStatus
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve2
                    If m_SlitValvePM1OpenStatus <> value Then
                        m_SlitValvePM1OpenStatus = value
                        Dim currentStatus As WorkingStatuses = GetSplitValve2StatusInternal()
                        Utils.ChangeStatusForFor2Channel(Me.Name, "SplitValve2Status", currentStatus)
                    End If
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or set SplitValve2CloseStatus
        ''' </summary>
        ''' <value></value>
        Public Property SplitValve2CloseStatus() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve2
                    Return m_SlitValvePM1CloseStatus
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve2
                    If m_SlitValvePM1CloseStatus <> value Then
                        m_SlitValvePM1CloseStatus = value
                        Dim currentStatus As WorkingStatuses = GetSplitValve2StatusInternal()
                        Utils.ChangeStatusForFor2Channel(Me.Name, "SplitValve2Status", currentStatus)
                    End If
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc</name>
        '''    	<date> 2009-01-21</date>
        ''' </author>
        ''' <summary>
        ''' Get current SlitValve3Status-->Chamber 2
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SplitValve3Status() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve3
                    Return GetSplitValve3StatusInternal()
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve3
                    If m_SlitValvePM2Status <> value Then
                        m_SlitValvePM2Status = value
                        Dim slitvalveValue As ChamberSlitValveMsg
                        slitvalveValue.SlitValveName = ConstEnum.Equipments.Chamber2.ToString()
                        slitvalveValue.Value = value
                        ThreadPool.QueueUserWorkItem(AddressOf SendSplitValveStatus_ToPM, slitvalveValue)
                    End If
                    ' Update SECS/GEM variables by Truc Le
                    ' Var Name: IsolationValveStatus
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.Equipments.Chamber2.ToString(), EMSERVICELib.VarType.SV, "IsolationValveStatus", VALUELib.ValueType.U1, value)
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or set SplitValve3OpenStatus
        ''' </summary>
        ''' <value></value>
        Public Property SplitValve3OpenStatus() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve3
                    Return m_SlitValvePM2OpenStatus
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve3
                    If m_SlitValvePM2OpenStatus <> value Then
                        m_SlitValvePM2OpenStatus = value
                        Dim currentStatus As WorkingStatuses = GetSplitValve3StatusInternal()
                        Utils.ChangeStatusForFor2Channel(Me.Name, "SplitValve3Status", currentStatus)
                    End If
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or set SplitValve3CloseStatus
        ''' </summary>
        ''' <value></value>
        Public Property SplitValve3CloseStatus() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve3
                    Return m_SlitValvePM2CloseStatus
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve3
                    If m_SlitValvePM2CloseStatus <> value Then
                        m_SlitValvePM2CloseStatus = value
                        Dim currentStatus As WorkingStatuses = GetSplitValve3StatusInternal()
                        Utils.ChangeStatusForFor2Channel(Me.Name, "SplitValve3Status", currentStatus)
                    End If
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc</name>
        '''    	<date> 2009-01-21</date>
        ''' </author>
        ''' <summary>
        ''' Get current SlitValve4Status-->chamber 3
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SplitValve4Status() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve4
                    Return GetSplitValve4StatusInternal()
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve4
                    If m_SlitValvePM3Status <> value Then
                        m_SlitValvePM3Status = value
                        Dim slitvalveValue As ChamberSlitValveMsg
                        slitvalveValue.SlitValveName = ConstEnum.Equipments.Chamber3.ToString()
                        slitvalveValue.Value = value
                        ThreadPool.QueueUserWorkItem(AddressOf SendSplitValveStatus_ToPM, slitvalveValue)
                    End If
                    ' Update SECS/GEM variables by Truc Le
                    ' Var Name: IsolationValveStatus
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.Equipments.Chamber3.ToString(), EMSERVICELib.VarType.SV, "IsolationValveStatus", VALUELib.ValueType.U1, value)
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or set SplitValve4OpenStatus
        ''' </summary>
        ''' <value></value>
        Public Property SplitValve4OpenStatus() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve4
                    Return m_SlitValvePM3OpenStatus
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve4
                    If m_SlitValvePM3OpenStatus <> value Then
                        m_SlitValvePM3OpenStatus = value
                        Dim currentStatus As WorkingStatuses = GetSplitValve4StatusInternal()
                        Utils.ChangeStatusForFor2Channel(Me.Name, "SplitValve4Status", currentStatus)
                    End If
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or set SplitValve4CloseStatus
        ''' </summary>
        ''' <value></value>
        Public Property SplitValve4CloseStatus() As WorkingStatuses
            Get
                SyncLock m_lockSplitValve4
                    Return m_SlitValvePM3CloseStatus
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockSplitValve4
                    If m_SlitValvePM3CloseStatus <> value Then
                        m_SlitValvePM3CloseStatus = value
                        Dim currentStatus As WorkingStatuses = GetSplitValve4StatusInternal()
                        Utils.ChangeStatusForFor2Channel(Me.Name, "SplitValve4Status", currentStatus)
                    End If
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current VacSwitchStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property VacSwitchStatus() As WorkingStatuses
            Get
                Return m_enmVacSwitchStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmVacSwitchStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current pressure TransferModule
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Pressure() As Double
            Get
                Return m_dblPressure
            End Get
            Set(ByVal value As Double)
                m_dblPressure = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: TMPressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV,
                "TMPressure", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current IG TransferModule
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IG() As Double
            Get
                Return m_dblIG
            End Get
            Set(ByVal value As Double)
                m_dblIG = value
                UpdatePressure()
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current CG TransferModule
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CG() As Double
            Get
                Return m_dblCG
            End Get
            Set(ByVal value As Double)
                'dat cao 2011-03-22
                'check CG condition 
                'when CG < e-3 then whow only e-3
                If value < 0.001 Then
                    value = 0.001
                End If
                m_dblCG = value
                UpdatePressure()
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current IGStatus TransferModule
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IGStatus() As WorkingStatuses
            Get
                Return m_enmIGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmIGStatus = value
                UpdatePressure()
            End Set
        End Property

        Private m_RevisionNoValues As String
        Public Property RevisionNoValues() As String
            Get
                Return m_RevisionNoValues
            End Get
            Set(ByVal value As String)
                m_RevisionNoValues = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-07-05 </date>
        ''' </author>
        Public Property SwitchIGFilament() As Integer
            Get
                Return m_SwitchIGFilament
            End Get
            Set(ByVal value As Integer)
                If m_SwitchIGFilament <> value Then
                    m_SwitchIGFilament = value
                    AVPLib.ContainerData.SetConfigFilament(Me.Name, value)
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get FastRoughValveStatus TransferModule
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FastRoughValveStatus() As WorkingStatuses
            Get
                Return m_enmFastRoughValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                If (m_enmFastRoughValveStatus <> value) Then

                    m_enmFastRoughValveStatus = value

                    Dim objRoughPump As DataManagerment.RoughPumpMachine =
                    CType(DataManagerment.EquipmentManager.GetRoughPumpMachine(
                    ConstEnum.Equipments.CassettesModule.ToString()),
                    DataManagerment.RoughPumpMachine)

                    If (objRoughPump IsNot Nothing) Then
                        If (value = WorkingStatuses.On) Then
                            objRoughPump.SetRoughLineInUse(Me.Name)
                        Else
                            objRoughPump.ReleaseRoughLineInUse(Me.Name)
                        End If
                    End If

                End If

                ' Update SECS/GEM variables by Truc Le
                ' Var Name: FastRoughValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "FastRoughValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current FastVentValveStatus TransferModule
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FastVentValveStatus() As WorkingStatuses
            Get
                Return m_enmFastVentValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmFastVentValveStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: FastVentValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "FastVentValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current HiVacValveStatus TransferModule
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property HiVacValveStatus() As WorkingStatuses
            Get
                SyncLock m_lockHiVacValve
                    Return GetHiVacValveStatusInternal()
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockHiVacValve
                    m_enmHiVacValveStatus = value
                    ' Update SECS/GEM variables by Truc Le
                    ' Var Name: HivacValveStatus
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "HivacValveStatus", VALUELib.ValueType.U1, value)
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-17</date>
        ''' </author>
        ''' <summary>
        ''' Get or ser HiVacValveOpenStatus
        ''' </summary>
        Public Property HiVacValveOpenStatus() As WorkingStatuses
            Get
                SyncLock m_lockHiVacValve
                    Return m_enmHiVacValveOpenStatus
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockHiVacValve
                    If m_enmHiVacValveOpenStatus <> value Then
                        m_enmHiVacValveOpenStatus = value
                        Dim currentStatus As WorkingStatuses = GetHiVacValveStatusInternal()
                        Utils.ChangeStatusForFor2Channel(Me.Name, "HiVacValveStatus", currentStatus)
                    End If
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-17</date>
        ''' </author>
        ''' <summary>
        ''' Get or set HiVacValveCloseStatus
        ''' </summary>
        Public Property HiVacValveCloseStatus() As WorkingStatuses
            Get
                SyncLock m_lockHiVacValve
                    Return m_enmHiVacValveCloseStatus
                End SyncLock
            End Get
            Set(ByVal value As WorkingStatuses)
                SyncLock m_lockHiVacValve
                    If m_enmHiVacValveCloseStatus <> value Then
                        m_enmHiVacValveCloseStatus = value
                        Dim currentStatus As WorkingStatuses = GetHiVacValveStatusInternal()
                        Utils.ChangeStatusForFor2Channel(Me.Name, "HiVacValveStatus", currentStatus)
                    End If
                End SyncLock
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' AutoVentStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AutoVentStatus() As WorkingStatuses
            Get
                Return m_enmAutoVentStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                If (m_enmAutoVentStatus <> value) Then
                    Utils.UpdateSequenceRunningStatusText(Me.Name, AUTO_VENT_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)
                End If

                m_enmAutoVentStatus = value

                ' Update SECS/GEM variables by Truc Le
                ' Var Name: AutoVentRunning
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "AutoVentRunning", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' PumpDownStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PumpDownStatus() As WorkingStatuses
            Get
                Return m_enmPumpDownStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                If (m_enmPumpDownStatus <> value) Then
                    Utils.UpdateSequenceRunningStatusText(Me.Name, AUTO_PUMPDOWN_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)
                End If

                m_enmPumpDownStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: AutoPumpdownRunning
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "AutoPumpdownRunning", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Truc Le</name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' PumpDownStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IG_Degas_Status() As WorkingStatuses
            Get
                Return m_enmIG_Degas_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                If (m_enmIG_Degas_Status <> value) Then
                    Utils.UpdateSequenceRunningStatusText(Me.Name, IG_DEGAS_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)
                End If

                m_enmIG_Degas_Status = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: IG_Degas_Status
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "IGDegasRunning", VALUELib.ValueType.U1, IIf(value = WorkingStatuses.On, 1, 0))
            End Set
        End Property

        Public Property TurboForeLineValveStatus() As WorkingStatuses
            Get
                Return m_enmTurboValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                If (m_enmTurboValveStatus <> value) Then
                    ' Update SECS/GEM variables by Dat Cao
                    ' Var Name: SlowRoughValveStatus
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Turbo.ForelineStatus", VALUELib.ValueType.U1, value)
                End If

                m_enmTurboValveStatus = value
            End Set
        End Property

        Public Property TurboForelineCG() As Double
            Get
                Return m_dblTurboForelineCG
            End Get
            Set(ByVal value As Double)
                m_dblTurboForelineCG = value
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: SlowRoughValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Turbo.ForelineCGPressure", VALUELib.ValueType.F4, value)
            End Set
        End Property

        Public Property TurboForelineCGRelay() As WorkingStatuses
            Get
                Return m_enmTurboForeLineCGRelay
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmTurboForeLineCGRelay = value
            End Set
        End Property

        Public Property CassetteFinish() As String
            Get
                Return m_strCassetteFinish
            End Get
            Set(ByVal value As String)
                m_strCassetteFinish = value
            End Set
        End Property

        '''' <author>
        ''''    	<name>Van Le</name>
        ''''    	<date> 2014-09-04</date>
        '''' </author>
        '''' <summary>
        '''' IsSafetySetATM
        '''' </summary>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Public Function IsSafetySetATM() As Boolean
        '    Try
        '        Dim minValue As Single = ATM_VALUE - ATM_VALUE * TOLERANCE
        '        Dim maxValue As Single = ATM_VALUE + ATM_VALUE * TOLERANCE
        '        If minValue <= CG AndAlso CG <= maxValue Then
        '            Return True
        '        End If
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    Return False
        'End Function

        '''' <author>
        ''''    	<name>Van Le</name>
        ''''    	<date> 2014-09-04</date>
        '''' </author>
        '''' <summary>
        '''' IsSafetySetATM
        '''' </summary>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Public Function IsSafetySetVAC() As Boolean
        '    Try
        '        If VacSwitchStatus = WorkingStatuses.On _
        '            AndAlso HiVacValveStatus = WorkingStatuses.On _
        '            AndAlso IGStatus = WorkingStatuses.On Then

        '            Return True
        '        End If

        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    Return False
        'End Function

        '''' <author>
        ''''    	<name>Van Le</name>
        ''''    	<date> 2014-08-22</date>
        '''' </author>
        '''' <summary>
        '''' IsSafetySetATM
        '''' </summary>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Public Function IsSafetySetTurboForelineATM() As Boolean
        '    Try
        '        Dim minValue As Single = ATM_VALUE - ATM_VALUE * TOLERANCE
        '        Dim maxValue As Single = ATM_VALUE + ATM_VALUE * TOLERANCE
        '        If minValue <= TurboForelineCG AndAlso TurboForelineCG <= maxValue Then
        '            Return True
        '        End If
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    Return False
        'End Function

#End Region

#Region "Public method"
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
        ''' Change status TMCryo
        ''' </summary>
        ''' <param name="PropertyNames"></param>
        ''' <param name="ReplyValues"></param>
        ''' <remarks></remarks>
        Public Overrides Sub ChangeStatus(ByVal PropertyNames As System.Collections.ArrayList, ByVal ReplyValues As System.Collections.ArrayList)
            AVPLib.Log.coreLogger.Info("Enter ChangeStatus")
            MyBase.ChangeStatus(PropertyNames, ReplyValues)
            AVPLib.Log.coreLogger.Info("Leave ChangeStatus")
        End Sub
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2010-1-22</date>
        ''' </author>
        ''' <summary>
        ''' OpenChamber1ChangeSlitValve
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSensorStatus(ByVal Equipment As String) As WorkingStatuses
            AVPLib.Log.coreLogger.Info("Enter GetSensorStatus")
            Dim strErrMsg As String = String.Empty

            Try
                If Not AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED Then
                    Return WorkingStatuses.Off
                End If

                Select Case Equipment
                    Case ConstEnum.Equipments.Chamber1.ToString()
                        Return SensorPM1Status
                    Case ConstEnum.Equipments.Chamber2.ToString()
                        Return SensorPM2Status
                    Case ConstEnum.Equipments.Chamber3.ToString()
                        Return SensorPM3Status
                    Case ConstEnum.Equipments.LoadLockA.ToString()
                        Return SensorLLAStatus
                    Case ConstEnum.Equipments.Aligner.ToString()
                        If RobotConfigurationValues.ALINER_VISIBLE Then
                            If (RobotConfigurationValues.ALIGNER_AT_STATION = 1) Then
                                Return SensorLLAStatus
                            End If
                        Else
                            AVPLib.Log.avpLogger.Error("Can not get the sensor status for this equipment")
                        End If

                    Case Else
                        AVPLib.Log.avpLogger.Error("Can not get the sensor status for this equipment")
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave GetSensorStatus")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-08-10</date>
        ''' </author>
        ''' <summary>
        ''' Update Variables For Gem When Init
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Sub UpdateVariableForGemWhenInit()
            Me.SplitValve1Status = SplitValve1Status
            Me.SplitValve2Status = SplitValve2Status
            Me.SplitValve3Status = SplitValve3Status
            Me.SplitValve4Status = SplitValve4Status
            Me.SensorLLAStatus = SensorLLAStatus
            Me.SensorPM1Status = SensorPM1Status
            Me.SensorPM2Status = SensorPM2Status
            Me.SensorPM3Status = SensorPM3Status
            If AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Then
                Me.SensorLLAStatus = WorkingStatuses.Off
                Me.SensorPM1Status = WorkingStatuses.Off
                Me.SensorPM2Status = WorkingStatuses.Off
                Me.SensorPM3Status = WorkingStatuses.Off
            End If
            Me.FastRoughValveStatus = FastRoughValveStatus
            Me.FastVentValveStatus = FastVentValveStatus
            Me.IG_Degas_Status = IG_Degas_Status
            Me.PumpDownStatus = PumpDown_Curve_Status
            Me.AutoVentStatus = AutoVentStatus
            Me.ControlStatus = ControlStatus
            Me.HiVacValveStatus = HiVacValveStatus
            Me.OverideModeStatus = OverideModeStatus
            Me.RoughPump1Status = RoughPump1Status
            Me.Pressure = Pressure
            Me.WaferCount = WaferCount
            Me.LifeTimeWafer = LifeTimeWafer
            Me.TurboForeLineValveStatus = TurboForeLineValveStatus
            Me.TurboForelineCG = TurboForelineCG
        End Sub
#End Region

#Region "Function Support"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Update Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UpdatePressure()
            AVPLib.Log.coreLogger.Info("Enter UpdatePressure")
            Try
                If Me.IGStatus = WorkingStatuses.On Then
                    Me.Pressure = Me.IG
                Else
                    Me.Pressure = Me.CG
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdatePressure")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> June 15 2009 </date>
        ''' </author>
        ''' <summary>
        ''' Check the condition to open the TM IG
        ''' true if meet the condition 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function checkCondition2OpenTMIG() As String
            AVPLib.Log.coreLogger.Info("Enter checkCondition2OpenTMIG")
            Dim strRet As String = String.Empty
            Dim objTMPumpPackageCtrl As Business.PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
            ' Is TM HiVac valve open

            If (RobotConfigurationValues.TM_HIVAC_INSTALLED AndAlso
            Me.HiVacValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                ' is TM Cryo T2 < 20k (configurable value in Pressure Config file)
                Dim strErrorMsg As String = String.Empty
                If (objTMPumpPackageCtrl IsNot Nothing) AndAlso (Not objTMPumpPackageCtrl.IsPumpPackageOK(strErrorMsg)) Then
                    'TODO: Review error message
                    strRet = strErrorMsg
                End If
            ElseIf (Not RobotConfigurationValues.TM_HIVAC_INSTALLED) Then
                'not check anything
                strRet = String.Empty
            Else '''hivac Valve is Off
                strRet = String.Format(ContainerData.GetMessageText("HivacValveDidNotOpen"), AVPLib.ConstEnum.TM_STR)
            End If
            AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenTMIG" + strRet.ToString())
            Return strRet
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> June 15 2009 </date>
        ''' </author>
        ''' <summary>
        ''' Check the condition to open the TM HiVac
        ''' true if meet the condition 
        ''' </summary>
        ''' <summary>
        ''' Dat Cao add condition: check all Slit valve is closed
        ''' return Empty if success
        ''' return Error String if Error -> Alam
        ''' </summary>
        ''' <remarks></remarks>
        Public Function checkCondition2OpenTMHiVac(Optional ByVal dbCGMultiFactor As Double = 1) As String
            AVPLib.Log.coreLogger.Info("Enter checkCondition2OpenTMHiVac")
            Dim strRet As String = String.Empty

            If (RobotConfigurationValues.TMTURBO_VISIBLE) Then
                Dim objTMTurbo As DataManagerment.Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.TMPumpPackage.ToString)
                If Not (objTMTurbo IsNot Nothing AndAlso objTMTurbo.TurboStatus AndAlso objTMTurbo.TurboUptoSpeed) Then
                    Return "Cannot open hivac valve, TM Turbo is not On"
                End If
            End If

            If (FastVentValveStatus = WorkingStatuses.On) Then
                Return "Cannot open hivac valve, TM Vent Valve is open"
                AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenTMHiVac" + strRet.ToString())
            End If

            If FastRoughValveStatus = WorkingStatuses.On Then
                Return "Cannot open hivac valve, TM Rough Valve is open"
            End If

            'check All iscolation valve condition 
            'success strRet = empty
            'error strRet != empty
            ' Hai Tran (2015-11-24): Remove this interlock (refer 0008478)

            Dim TMCG As Double = 0
            TMCG = VentPumdownLib.TMPumpdownConfig.TMRoughPressure '''get TMRoughPressure in SystemConfig.xml

            ' IS CG Relay On (check the new tag, WTM_VacSwitch_FB = 1)
            If Me.VacSwitchStatus = WorkingStatuses.On Then

                If (Me.CG_Communication = WorkingStatuses.Off) Then
                    Return "Cannot open hivac valve, TM CG Device is disconnected."
                End If

                ' IS TM CG < .02 (configurable value)
                If (Me.CG * dbCGMultiFactor) < TMCG Then
                    strRet = String.Empty
                Else '''CG>0.02
                    strRet = "Cannot open hivac valve, " & String.Format(ContainerData.GetMessageText("CGSmallerThan"), AVPLib.ConstEnum.TM_STR, "<" & " " & TMCG.ToString())
                End If
            Else '''vac switch is off
                strRet = "Cannot open hivac valve, " & String.Format(ContainerData.GetMessageText("VacSwitch_FB"), AVPLib.ConstEnum.TM_STR)
            End If

            AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenTMHiVac" + strRet.ToString())
            Return strRet
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> June 15 2011 </date>
        ''' </author>
        ''' <summary>
        ''' Check the Open/Close Slit valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function Check_PMx_IsolationValve(ByVal Chamber As String, ByVal blnIsClosed As Boolean) As String
            Dim strResult As String = String.Empty
            Try
                Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                If objTransferModule Is Nothing Then
                    Return strResult
                End If
                Dim objChamber As DataManagerment.Chamber = Nothing
                Select Case Chamber
                    Case Equipments.Chamber1.ToString()
                        objChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                        If objChamber Is Nothing Then
                            AVPLib.Log.avpLogger.Error("Can't get obj Chamber1")
                            Return strResult
                        End If
                        If blnIsClosed Then
                            strResult = IIf(objTransferModule.SplitValve2Status = DataManagerment.Equipment.WorkingStatuses.Off,
                                            String.Empty, "Slit valve is not closed")
                        Else
                            strResult = IIf(objTransferModule.SplitValve2Status = DataManagerment.Equipment.WorkingStatuses.On,
                                            String.Empty, "Slit valve is not opened")
                        End If

                    Case Equipments.Chamber2.ToString()
                        objChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
                        If objChamber Is Nothing Then
                            AVPLib.Log.avpLogger.Error("Can't get obj Chamber2")
                            Return strResult
                        End If
                        If blnIsClosed Then
                            strResult = IIf(objTransferModule.SplitValve3Status = DataManagerment.Equipment.WorkingStatuses.Off,
                                            String.Empty, "Slit valve is not closed")
                        Else
                            strResult = IIf(objTransferModule.SplitValve3Status = DataManagerment.Equipment.WorkingStatuses.On,
                                            String.Empty, "Slit valve is not opened")
                        End If

                    Case Equipments.Chamber3.ToString()
                        objChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
                        If objChamber Is Nothing Then
                            AVPLib.Log.avpLogger.Error("Can't get obj Chamber3")
                            Return strResult
                        End If
                        If blnIsClosed Then
                            strResult = IIf(objTransferModule.SplitValve4Status = DataManagerment.Equipment.WorkingStatuses.Off, String.Empty, "Slit valve is not closed")
                        Else
                            strResult = IIf(objTransferModule.SplitValve4Status = DataManagerment.Equipment.WorkingStatuses.On, String.Empty, "Slit valve is not opened")
                        End If
                    Case Else
                        AVPLib.Log.avpLogger.Error("Can't get obj Chamber")
                        Return strResult

                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return strResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 3 14 2011 </date>
        ''' </author>
        ''' <summary>
        ''' Check the Open/Close Slit valve
        ''' <Tin Tran 28/06/2012/> Add function to check equipments are installed or not
        ''' If not, don't need to check Isolation Valve.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function isClosedAllIsolationValve(ByRef strRet As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Check Closed all Slit valve")
            Dim blRs As Boolean = True
            Dim loadLockA As DataManagerment.LoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
            Dim Chamber1 As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString()), DataManagerment.Chamber)
            Dim Chamber2 As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString()), DataManagerment.Chamber)
            Dim Chamber3 As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString()), DataManagerment.Chamber)
            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)

            ' is All isolation LLA valve closed
            If TM.SplitValve1Status <> WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(ConstEnum.LL_ISOLATION_VALVE_WAS_NOT_CLOSE), ConstEnum.LLA_STR)
                blRs = False
                GoTo ENDFUNC
            End If

            ' is All isolation TM valve closed
            'Chamber 1
            If TM.SplitValve2Status <> WorkingStatuses.Off AndAlso
            AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
                strRet = (String.Format(ContainerData.GetMessageText(ConstEnum.MESA_VALVES), ConstEnum.MESA_VALVE & AVPLib.RobotConfigurationValues.CHAMBER1_NAME))
                blRs = False
                GoTo ENDFUNC
            End If

            'chamber 2
            If TM.SplitValve3Status <> WorkingStatuses.Off AndAlso
            AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
                strRet = (String.Format(ContainerData.GetMessageText(ConstEnum.MESA_VALVES), ConstEnum.MESA_VALVE & AVPLib.RobotConfigurationValues.CHAMBER2_NAME))
                blRs = False
                GoTo ENDFUNC
            End If

            'chamber 3
            If TM.SplitValve4Status <> WorkingStatuses.Off AndAlso
            AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
                strRet = (String.Format(ContainerData.GetMessageText(ConstEnum.MESA_VALVES), ConstEnum.MESA_VALVE & AVPLib.RobotConfigurationValues.CHAMBER3_NAME))
                blRs = False
                GoTo ENDFUNC
            End If
            strRet = String.Empty
ENDFUNC:
            AVPLib.Log.coreLogger.Info("Enter Check Closed all Slit valve" + strRet)
            Return blRs
        End Function

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> June 15 2009 </date>
        ''' </author>
        ''' <summary>
        ''' Check the condition to open the TM Rough
        ''' true if meet the condition 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function checkCondition2OpenTMRough() As String
            AVPLib.Log.coreLogger.Info("Enter checkCondition2OpenTMRough")
            Dim strRet As String = String.Empty

            If (RobotConfigurationValues.DEBUGMODE) Then
                Return strRet
            End If

            Dim loadLockA As DataManagerment.LoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
            Dim Chamber1 As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString()), DataManagerment.Chamber)
            Dim Chamber2 As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString()), DataManagerment.Chamber)
            Dim Chamber3 As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString()), DataManagerment.Chamber)
            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)

            ' Is TM Hivac Valve closed?
            If RobotConfigurationValues.TM_HIVAC_INSTALLED AndAlso
            Me.HiVacValveStatus <> WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(ConstEnum.HIVAC_VALVE_DID_NOT_CLOSE), AVPLib.ConstEnum.TM_STR)
                GoTo ENDFUNC
            End If

            ' IS TM IG off?
            If Me.IGStatus <> WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(ConstEnum.TM_IG_WAS_NOT_OFF), AVPLib.ConstEnum.TM_STR)
                GoTo ENDFUNC
            End If

            ' is All isolation LLA valve closed
            If TM.SplitValve1Status <> WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(ConstEnum.LL_ISOLATION_VALVE_WAS_NOT_CLOSE), ConstEnum.LLA_STR)
                GoTo ENDFUNC
            End If

            ' is All isolation TM valve closed
            'Chamber 1
            If TM.SplitValve2Status <> WorkingStatuses.Off AndAlso
            AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
                strRet = (String.Format(ContainerData.GetMessageText(ConstEnum.MESA_VALVES), ConstEnum.MESA_VALVE & AVPLib.RobotConfigurationValues.CHAMBER1_NAME))
                GoTo ENDFUNC
            End If

            'chamber 2
            If TM.SplitValve3Status <> WorkingStatuses.Off AndAlso
            AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
                strRet = (String.Format(ContainerData.GetMessageText(ConstEnum.MESA_VALVES), ConstEnum.MESA_VALVE & AVPLib.RobotConfigurationValues.CHAMBER2_NAME))
                GoTo ENDFUNC
            End If

            'chamber 3
            If TM.SplitValve4Status <> WorkingStatuses.Off AndAlso
            AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
                strRet = (String.Format(ContainerData.GetMessageText(ConstEnum.MESA_VALVES), ConstEnum.MESA_VALVE & AVPLib.RobotConfigurationValues.CHAMBER3_NAME))
                GoTo ENDFUNC
            End If

            ' Is all TM Vent valves closed 
            If Me.FastVentValveStatus <> DataManagerment.Equipment.WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(ConstEnum.TM_VENT_VALVES_WAS_NOT_CLOSE), ConstEnum.TM_STR)
                GoTo ENDFUNC
            End If

            ' is all TM rough valves closed?
            If Me.FastRoughValveStatus <> DataManagerment.Equipment.WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(ConstEnum.TM_ROUGH_VAVLES_WAS_NOT_CLOSE), ConstEnum.TM_STR)
                GoTo ENDFUNC
            End If

            ' Check auto vent sequence is running
            If Me.AutoVentStatus = WorkingStatuses.On Then
                strRet = ConstEnum.TM_STR & " " & ConstEnum.AUTO_VENT_RUNNING
                GoTo ENDFUNC
            End If

            ''[Tin Vu 6-6-2012]
            ''Check all forline valve
            ''When FL-valve of LLx is open, users are not allowed to open any slow/fast rough valves of both LLA
            ''Begin fix

            Dim objRoughPump As DataManagerment.RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(Me.Name)
            If (objRoughPump IsNot Nothing) Then
                If (objRoughPump.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                    Dim objLL As LoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)
                    If (objLL IsNot Nothing AndAlso
                        RobotConfigurationValues.LLA_TURBO_VISIBLE AndAlso
                        objLL.TurboForeLineValveStatus = WorkingStatuses.On) Then
                        strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Foreline valve of " & LLA_STR)
                        GoTo ENDFUNC
                    End If
                End If
                If (objRoughPump.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                    Dim objLL As CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                    If (objLL IsNot Nothing AndAlso
                        RobotConfigurationValues.TMTURBO_VISIBLE AndAlso
                        objLL.TurboForeLineValveStatus = WorkingStatuses.On) Then
                        strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Foreline valve of " & AVPLib.Utils.chamberID2ChamberName(objLL.Name))
                        GoTo ENDFUNC
                    End If
                End If

                '0009760: Foreline/rough valve should not be allow to open when TM's pump is not on and pressure is not reach.
                Dim PumpStatus As WorkingStatuses = IIf(objRoughPump.Name = ConstEnum.Equipments.RoughPumpMachine1.ToString, RoughPump1Status, RoughPump2Status)
                If Not PumpStatus = WorkingStatuses.On Then
                    strRet = MECHANICAL_PUMP_NOT_ON
                    GoTo ENDFUNC
                End If
            End If

            ''End fix

            strRet = String.Empty
ENDFUNC:
            AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenTMRough" + strRet)
            Return strRet
        End Function
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> June 15 2009 </date>
        ''' </author>
        ''' <summary>
        ''' Check the condition to open the TM Vent
        ''' true if meet the condition 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function checkCondition2OpenTMVent() As String
            AVPLib.Log.coreLogger.Info("Enter checkCondition2OpenTMVent")
            Dim strRet As String = String.Empty

            If (RobotConfigurationValues.DEBUGMODE) Then
                Return strRet
            End If

            Dim loadLockA As DataManagerment.LoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
            Dim Chamber1 As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString()), DataManagerment.Chamber)
            Dim Chamber2 As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString()), DataManagerment.Chamber)
            Dim Chamber3 As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString()), DataManagerment.Chamber)
            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            'is TM hivac valve closed?
            If RobotConfigurationValues.TM_HIVAC_INSTALLED AndAlso Me.HiVacValveStatus <> WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(ConstEnum.HIVAC_VALVE_DID_NOT_CLOSE), ConstEnum.TM_STR)
                GoTo ENDFUNC
            End If
            'is TM IG Off?
            If Me.IGStatus <> WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(ConstEnum.TM_IG_WAS_NOT_OFF), ConstEnum.TM_STR)
                GoTo ENDFUNC
            End If

            'is Slit valves closed? : TM and LL
            'is Isolation LLA valve closed
            If TM.SplitValve1Status <> DataManagerment.Equipment.WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(ConstEnum.LL_ISOLATION_VALVE_WAS_NOT_CLOSE), ConstEnum.LLA_STR)
                GoTo ENDFUNC
            End If

            'chamber 1
            If TM.SplitValve2Status <> WorkingStatuses.Off AndAlso
            AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
                strRet = (String.Format(ContainerData.GetMessageText(ConstEnum.MESA_VALVES), ConstEnum.MESA_VALVE & AVPLib.RobotConfigurationValues.CHAMBER1_NAME))
                GoTo ENDFUNC
            End If

            'chamber 2
            If TM.SplitValve3Status <> WorkingStatuses.Off AndAlso
            AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
                strRet = (String.Format(ContainerData.GetMessageText(ConstEnum.MESA_VALVES), ConstEnum.MESA_VALVE & AVPLib.RobotConfigurationValues.CHAMBER2_NAME))
                GoTo ENDFUNC
            End If

            'chamber 3
            If TM.SplitValve4Status <> WorkingStatuses.Off AndAlso
            AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
                strRet = (String.Format(ContainerData.GetMessageText(ConstEnum.MESA_VALVES), ConstEnum.MESA_VALVE & AVPLib.RobotConfigurationValues.CHAMBER3_NAME))
                GoTo ENDFUNC
            End If

            'Is TM Rough valve closed?
            If Me.FastRoughValveStatus <> DataManagerment.Equipment.WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(ConstEnum.TM_ROUGH_VAVLES_WAS_NOT_CLOSE), ConstEnum.TM_STR)
                GoTo ENDFUNC
            End If

            ' Check LL PumpDown sequence running
            If Me.PumpDownStatus = WorkingStatuses.On Then
                strRet = ConstEnum.TM_STR & " " & ConstEnum.AUTO_PUMPDOWN_RUNNING
                GoTo ENDFUNC
            End If

            strRet = String.Empty
ENDFUNC:
            AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenTMIG" + strRet)
            Return strRet
        End Function


        ''' <author>
        '''    	<name>Van Le</name>
        '''    	<date> 2014-09-04</date>
        ''' </author>
        ''' <summary>
        ''' IsSafetySetATM
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsSafetySetATM() As Boolean
            Try
                Dim minValue As Single = ATM_VALUE - ATM_VALUE * TOLERANCE
                '' 0008782: [KhoiHa - 12/02/2015] Set CG ATM. Currently set CG ATM is only allow plus/minus 10% from ATM. Button should be enable when pressure > (minus 20%) from ATM.
                'Dim maxValue As Single = ATM_VALUE + ATM_VALUE * TOLERANCE
                If minValue <= CG Then 'AndAlso CG <= maxValue Then
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return False
        End Function

        ''' <author>
        '''    	<name>Van Le</name>
        '''    	<date> 2014-09-04</date>
        ''' </author>
        ''' <summary>
        ''' IsSafetySetATM
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsSafetySetVAC() As Boolean
            Try
                If VacSwitchStatus = WorkingStatuses.On _
                    AndAlso HiVacValveStatus = WorkingStatuses.On _
                    AndAlso IGStatus = WorkingStatuses.On Then

                    Return True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return False
        End Function

        ''' <author>
        '''    	<name>Van Le</name>
        '''    	<date> 2014-08-22</date>
        ''' </author>
        ''' <summary>
        ''' IsSafetySetATM
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsSafetySetTurboForelineATM() As Boolean
            Try
                Dim minValue As Single = ATM_VALUE - ATM_VALUE * TOLERANCE
                '' 0008782: [KhoiHa - 12/02/2015] Set CG ATM. Currently set CG ATM is only allow plus/minus 10% from ATM. Button should be enable when pressure > (minus 20%) from ATM.
                'Dim maxValue As Single = ATM_VALUE + ATM_VALUE * TOLERANCE
                If minValue <= TurboForelineCG Then ' AndAlso TurboForelineCG <= maxValue Then
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return False
        End Function

        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2026-05-11 </date>
        ''' </author>
        ''' <summary>
        ''' Update Rough Pump Machine In Use by TM/LL To Chamber
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub UpdateRoughPumpMachineInUseToChamber(ByVal value As String)
            If AVPLib.RobotConfigurationValues.SHARED_MP_WITH_PM Then
                Dim intMaxOfPM As Integer = 3 'default for CX4
                Dim objRoughPump As RoughPumpMachine =
                        CType(EquipmentManager.GetRoughPumpMachine(Equipments.CassettesModule.ToString()), RoughPumpMachine)

                If objRoughPump Is Nothing Then
                    AVPLib.Log.avpLogger.Error("Can't get RoughPumpMachine")
                    Return
                End If

                For i As Integer = 1 To intMaxOfPM
                    Dim strName As String = ConstEnum.Chamber & i.ToString()

                    Dim chamberController As Business.ChamberController = Business.ControllerManager.GetController(strName)
                    If objRoughPump.IsUsed(strName) AndAlso chamberController IsNot Nothing AndAlso
                        chamberController.Myself.GetType().Name = ControllerType.PVD5TController.ToString() Then

                        Dim objController As Business.PVD5TController = CType(chamberController.Myself, Business.PVD5TController)
                        If objController IsNot Nothing Then
                            objController.DoSetRough_Pump_In_Use(value & "$")
                        End If
                    End If
                Next
            End If
        End Sub

        ''' <summary>
        ''' Internal method to compute SplitValve1Status - MUST be called within SyncLock m_lockSplitValve1
        ''' </summary>
        Private Function GetSplitValve1StatusInternal() As WorkingStatuses
            If m_SlitValveLLAOpenStatus = WorkingStatuses.On AndAlso m_SlitValveLLACloseStatus = WorkingStatuses.Off Then
                Return WorkingStatuses.On
            ElseIf m_SlitValveLLACloseStatus = WorkingStatuses.On AndAlso m_SlitValveLLAOpenStatus = WorkingStatuses.Off Then
                Return WorkingStatuses.Off
            Else
                Return WorkingStatuses.Unknown
            End If
        End Function

        ''' <summary>
        ''' Internal method to compute SplitValve2Status - MUST be called within SyncLock m_lockSplitValve2
        ''' </summary>
        Private Function GetSplitValve2StatusInternal() As WorkingStatuses
            If m_SlitValvePM1OpenStatus = WorkingStatuses.On AndAlso m_SlitValvePM1CloseStatus = WorkingStatuses.Off Then
                Return WorkingStatuses.On
            ElseIf m_SlitValvePM1CloseStatus = WorkingStatuses.On AndAlso m_SlitValvePM1OpenStatus = WorkingStatuses.Off Then
                Return WorkingStatuses.Off
            Else
                Return WorkingStatuses.Unknown
            End If
        End Function

        ''' <summary>
        ''' Internal method to compute SplitValve3Status - MUST be called within SyncLock m_lockSplitValve3
        ''' </summary>
        Private Function GetSplitValve3StatusInternal() As WorkingStatuses
            If m_SlitValvePM2OpenStatus = WorkingStatuses.On AndAlso m_SlitValvePM2CloseStatus = WorkingStatuses.Off Then
                Return WorkingStatuses.On
            ElseIf m_SlitValvePM2CloseStatus = WorkingStatuses.On AndAlso m_SlitValvePM2OpenStatus = WorkingStatuses.Off Then
                Return WorkingStatuses.Off
            Else
                Return WorkingStatuses.Unknown
            End If
        End Function

        ''' <summary>
        ''' Internal method to compute SplitValve4Status - MUST be called within SyncLock m_lockSplitValve4
        ''' </summary>
        Private Function GetSplitValve4StatusInternal() As WorkingStatuses
            If m_SlitValvePM3OpenStatus = WorkingStatuses.On AndAlso m_SlitValvePM3CloseStatus = WorkingStatuses.Off Then
                Return WorkingStatuses.On
            ElseIf m_SlitValvePM3CloseStatus = WorkingStatuses.On AndAlso m_SlitValvePM3OpenStatus = WorkingStatuses.Off Then
                Return WorkingStatuses.Off
            Else
                Return WorkingStatuses.Unknown
            End If
        End Function

        ''' <summary>
        ''' Internal method to compute HiVacValveStatus - MUST be called within SyncLock m_lockHiVacValve
        ''' </summary>
        Private Function GetHiVacValveStatusInternal() As WorkingStatuses
            If m_enmHiVacValveOpenStatus = WorkingStatuses.On AndAlso m_enmHiVacValveCloseStatus = WorkingStatuses.Off Then
                Return WorkingStatuses.On
            ElseIf m_enmHiVacValveCloseStatus = WorkingStatuses.On AndAlso m_enmHiVacValveOpenStatus = WorkingStatuses.Off Then
                Return WorkingStatuses.Off
            Else
                Return WorkingStatuses.Unknown
            End If
        End Function
#End Region
    End Class
End Namespace