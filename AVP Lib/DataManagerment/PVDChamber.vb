Imports System.Threading
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum
Imports AVPLib.Business

Namespace DataManagerment
    Public Class PVDChamber
        Inherits Chamber
#Region "Variables"
        Private m_OverrideMode_Status As WorkingStatuses
        '<Valve>
        Private m_MainGasValveStatus As WorkingStatuses
        Private m_HivacValveStatus As WorkingStatuses
        'Private m_RoughValveStatus As WorkingStatuses
        Private m_WaterValveStatus As WorkingStatuses
        'Private m_VentValveStatus As WorkingStatuses
        Private m_BaratronValveStatus As WorkingStatuses
        Private m_Turbo_IsolationValveStatus As WorkingStatuses
        Private m_AutoZeroVatValveStatus As WorkingStatuses
        '<Valve Gas>
        Private m_ShutOff1ValveStatus As WorkingStatuses
        Private m_ShutOff2ValveStatus As WorkingStatuses
        Private m_ShutOff3ValveStatus As WorkingStatuses
        Private m_ShutOff4ValveStatus As WorkingStatuses
        Private m_ShutOff5ValveStatus As WorkingStatuses
        Private m_Supply1ValveStatus As WorkingStatuses
        Private m_Supply2ValveStatus As WorkingStatuses
        Private m_Supply3ValveStatus As WorkingStatuses
        Private m_Supply4ValveStatus As WorkingStatuses
        Private m_Supply5ValveStatus As WorkingStatuses
        '<Gas Line>
        Private m_ShutOff_GasLine1_Status As WorkingStatuses
        Private m_ShutOff_GasLine2_Status As WorkingStatuses
        Private m_ShutOff_GasLine3_Status As WorkingStatuses
        Private m_ShutOff_GasLine4_Status As WorkingStatuses
        Private m_ShutOff_GasLine5_Status As WorkingStatuses
        Private m_Supply_GasLine1_Status As WorkingStatuses
        Private m_Supply_GasLine2_Status As WorkingStatuses
        Private m_Supply_GasLine3_Status As WorkingStatuses
        Private m_Supply_GasLine4_Status As WorkingStatuses
        Private m_Supply_GasLine5_Status As WorkingStatuses

        Private m_HivacValve_GasLine_Status As WorkingStatuses
        Private m_RoughValve_GasLine_Status As WorkingStatuses
        Private m_VentValve_GasLine_Status As WorkingStatuses
        Private m_BaratronValve_GasLine_Status As WorkingStatuses
        Private m_Turbo_IsolationValve_GasLine_Status As WorkingStatuses
        Private m_AutoZeroVatValve_GasLine_Status As WorkingStatuses
        '<Chamber Interlock>
        Private m_ChamberInterlocks_ChuckWaterStatus As WorkingStatuses
        Private m_ChamberInterlocks_TargetWaterStatus As WorkingStatuses
        Private m_ChamberInterlocks_LidWaterStatus As WorkingStatuses
        Private m_ChamberInterlocks_ChamPressStatus As WorkingStatuses
        Private m_ChamberInterlocks_ChamWaterStatus As WorkingStatuses
        Private m_ChamberInterlocks_RSRelayStatus As WorkingStatuses
        Private m_ChamberInterlocks_TurboWaterStatus As WorkingStatuses
        Private m_ChamberInterlocks_TurboForelineStatus As WorkingStatuses
        Private m_blnChamberInterlock_TableWaterStatus As WorkingStatuses
        Private m_blnChamberInterlock_LidSensorStatus As WorkingStatuses
        Private m_blnChamberInterlock_MatchWaterStatus As WorkingStatuses
        Private m_blnChamberInterlock_TargetMBWaterStatus As WorkingStatuses
        Private m_blnChamberInterlock_ClampWaterStatus As WorkingStatuses
        Private m_blnChamberInterlock_SubMBWaterStatus As WorkingStatuses
        '<Magnatron Panel>
        Private m_Magnatron_RotatingStatus As WorkingStatuses
        Private m_Magnatron_RotationStartStatus As WorkingStatuses
        '<RoughPump>
        Private m_PVDRoughPumpStatus As WorkingStatuses
        '<shutterValve>
        Private m_Shutter_ValveStatus As WorkingStatuses
        '<Chuck Control>
        Private m_ValveTarStatus As WorkingStatuses
        Private m_ShutterStatus As WorkingStatuses
        'WaferStatus Inherit Chamber Class
        'SlitValve Status Inherirt Chamber Class
        Private m_bicPlasmaIgniterStatus As WorkingStatuses
        '''====Chuck Position
        Private m_dblChuckPos_Readback As Double
        Private m_dblChuckPos_Program As Double
        Private m_ClampStatus_Program As WorkingStatuses
        Private m_ClampStatus_Readback As WorkingStatuses
        '<DC Target Power Supply>----------------------------------
        Private m_dblDCTargetPowerSupply_Power_Readback As Double
        Private m_dblDCTargetPowerSupply_Power_Program As Double
        Private m_dblDCTargetPowerSupply_Voltage_Readback As Double
        Private m_dblDCTargetPowerSupply_Voltage_Program As Double
        Private m_dblDCTargetPowerSupply_Current_Readback As Double
        Private m_dblDCTargetPowerSupply_Current_Program As Double
        Private m_dblDCTargetPowerSupply_DCPulse_Readback As Double
        Private m_DCTargetPowerSupply_MagnetronRotationStatus As WorkingStatuses
        Private m_DCTargetPowerSupply_DCPulseStatus As WorkingStatuses
        Private m_dblDCTargetPowerSupply_KWH_Readback As Double
        Private m_dblDCTargetPowerSupply_RampTime_Readback As Double
        Private m_dblDCTargetPowerSupply_RampTime_Program As Double
        Private m_DCTargetPowerSupply_CommunicationStatus As WorkingStatuses
        '<Bias Power Supply>--------------------------------------
        Private m_dblBiasPowerSupply_ForwardPower_Readback As Double
        Private m_dblBiasPowerSupply_ForwardPower_Program As Double
        Private m_dblBiasPowerSupply_ReflectedPower_Readback As Double
        Private m_dblBiasPowerSupply_Voltage_Readback As Double
        Private m_dblBiasPowerSupply_Voltage_Program As Double
        Private m_dblBiasPowerSupply_C1_Readback As Double
        Private m_dblBiasPowerSupply_C1_Program As Double
        Private m_dblBiasPowerSupply_C2_Readback As Double
        Private m_dblBiasPowerSupply_C2_Program As Double
        Private m_dblBiasPowerSupply_Match_Readback As Double
        Private m_dblBiasPowerSupply_Presets_Readback As Double
        Private m_dblBiasPowerSupply_Presets_Program As Double
        Private m_BiasPowerSupply_CommunicationStatus As WorkingStatuses
        Private m_BiasPowerSupply_AutoStatus As WorkingStatuses
        Private m_BiasPowerSupply_RecallStatus As WorkingStatuses
        Private m_BiasPowerSupply_StoreStatus As WorkingStatuses
        Private m_dBiasTargetPowerSupply_Mag As Double
        Private m_dBiasTargetPowerSupply_Phase As Double
        Private m_dBiasTargetPowerSupply_ErrorStatus As String
        Private m_dBiasPowerKWHReadback As Double
        Private m_dBiasPowerKWHProgram As Double
        '<Parallel Magnet>------------------------------------------
        Private m_dblParallelMagnet_Current_Readback As Double
        Private m_dblParallelMagnet_Current_Program As Double
        Private m_dblParallelMagnet_Duty_Program As Double
        Private m_dblParallelMagnet_Prequency_Program As Double
        Private m_dblParallelMagnet_Voltage_Readback As Double
        Private m_ParallelMagnetStatus As WorkingStatuses
        '<RF Target Power Supply>------------------------------------
        Private m_dblRFTargetPowerSupply_ForwardPower_Readback As Double
        Private m_dblRFTargetPowerSupply_ForwardPower_Program As Double
        Private m_dblRFTargetPowerSupply_ReflectedPower_Readback As Double
        Private m_dblRFTargetPowerSupply_Voltage_Readback As Double
        Private m_dblRFTargetPowerSupply_C1_Readback As Double
        Private m_dblRFTargetPowerSupply_C1_Program As Double
        Private m_dblRFTargetPowerSupply_C2_Readback As Double
        Private m_dblRFTargetPowerSupply_C2_Program As Double
        Private m_dblRFTargetPowerSupply_Match_Readback As Double
        Private m_dblRFTargetPowerSupply_Presets_Readback As Double
        Private m_dblRFTargetPowerSupply_Presets_Program As Double
        Private m_RFTargetPowerSupply_CommunicationStatus As WorkingStatuses
        Private m_RFTargetPowerSupply_AutoStatus As WorkingStatuses
        Private m_RFTargetPowerSupply_RecallStatus As WorkingStatuses
        Private m_RFTargetPowerSupply_StoreStatus As WorkingStatuses
        Private m_dblRFTargetPowerSupply_KWH_Readback As Double
        Private m_dRFTargetPowerSupply_Mag As Double
        Private m_dRFTargetPowerSupply_Phase As Double
        Private m_dRFTargetPowerSupply_ErrorStatus As String
        '<MG Information>
        Private m_dblMG_Information As Double
        '<CG Information>
        Private m_dblCG_Information As Double
        '''''----------------------------------------------------
        Private m_dblRoughLineCG_Readback As Double
        Private m_dblForeLineCG_Readback As Double
        '<CG Set Point>-----------------------------------------------
        Private m_dblBaratron_CG_Program As Double
        '<Vat Valve>---------------------------------------------
        Private m_VatValve_Teach_Program As WorkingStatuses
        Private m_VatValve_SizeAdj_Program As WorkingStatuses
        Private m_dblVatValve_Pressure_Program As Double
        Private m_dblVatValve_PressurePercent_Program As Double
        Private m_VatValve_CommunicationStatus As WorkingStatuses
        Private m_dblVatValve_Percentage As Double
        '<Cryo>------------------------------------------------
        Private m_dblCryo_T1_Readback As Double
        Private m_dblCryo_T2_Readback As Double
        Private m_Cryo_CommunicationStatus As WorkingStatuses
        Private m_dblCryo_RegenHour_Readback As Double
        Private m_dblCryo_LifeTimeHour_Readback As Double
        Private m_strCryo_P_Command As String
        '<Water Pump>
        Private m_dblWaterPump_T_Readback As Double
        Private m_WaterPump_Status As WorkingStatuses
        Private m_WaterPumpRegen_Status As WorkingStatuses
        Private m_WaterPumpState_Status As WorkingStatuses
        Private m_dblWaterPump_RegenHour As Double
        Private m_dblWaterPump_LifeTimeHour As Double
        'Turbo Pump
        Private m_Turbo_PumpStatus As WorkingStatuses
        '<Gas Controller>----------------------------------------
        Private m_dblGasController_Gas1_Readback As Double
        Private m_dblGasController_Gas2_Readback As Double
        Private m_dblGasController_Gas3_Readback As Double
        Private m_dblGasController_Gas4_Readback As Double
        Private m_dblGasController_Gas5_Readback As Double
        Private m_dblGasController_Gas1_Program As Double
        Private m_dblGasController_Gas2_Program As Double
        Private m_dblGasController_Gas3_Program As Double
        Private m_dblGasController_Gas4_Program As Double
        Private m_dblGasController_Gas5_Program As Double

        ''<Process Monitor>-------------------------------------
        Private m_strProcessMonitor_WaferID_Readback As String
        Private m_strProcessMonitor_ProcessTime_Readback As String
        Private m_strProcessMonitor_UserLevel_Readback As String
        Private m_strProcessMonitor_Status_Readback As String

        Private m_strProcessMonitor_DeviceResume_Readback As String = String.Empty
        Private m_strProcessMonitor_DeviceSendRecipeName_Readback As String = String.Empty
        Private m_strProcessMonitor_DeviceError_Readback As String = String.Empty
        Private m_strProcessMonitor_ResetError_Readback As String = String.Empty
        Private m_strProcessMonitor_DeviceStart_Readback As String = String.Empty
        Private m_strProcessMonitor_DeviceStop_Readback As String = String.Empty
        Private m_strProcessMonitor_DevicePause_Readback As String = String.Empty
        Private m_ProcessControl_GetRunDataFileName As WorkingStatuses = WorkingStatuses.Unknown
        ''''''''
        'Menu-----------------------------------------------------
        Private m_MachineIGDegasStatus As WorkingStatuses
        Private m_MachinePumpPurgeStatus As WorkingStatuses
        Private m_MachineVentStatus As WorkingStatuses
        Private m_MachinePumpDownStatus As WorkingStatuses
        Private m_MachineCryoOnStatus As WorkingStatuses
        Private m_MachineCryoRegnStatus As WorkingStatuses
        Private m_MachineFastRegen_Status As WorkingStatuses
        Private m_MachineShutDownPowerStatus As WorkingStatuses
        ''''''''''''''''''
        Private m_HivacValve_Status As WorkingStatuses
        '''''''''''''''''''''''''
        Private m_RoughLineInUseStatus As WorkingStatuses
      
        Private m_Plasma_Status As WorkingStatuses

        Private m_objLockOnStatus As New Object
        Private m_objChamberModule As SystemModule = Nothing

        Private m_dblTargetWarning_KWH_Readback As Double
        Private m_dblTargetLimit_KWH_Readback As Double
        Private m_strTargetMaterial As String
        Private m_blnShowWarningKWH As Boolean = False
        Private m_blnShowLimitKWH As Boolean = False

        'CycleATM
        Private m_strProcessCycleATMStart As String = String.Empty
#End Region

#Region "Valve Status"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Hivac Valve Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MainGasValveStatus() As WorkingStatuses
            Get
                Return m_MainGasValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Main Gas Valve Status", m_MainGasValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Hivac Valve Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property HivacValveStatus() As WorkingStatuses
            Get
                Return m_HivacValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.HivacValveStatus    
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "HivacValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Hivac Valve Status", m_HivacValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-04-18 </date>
        ''' </author>
        ''' <summary>
        ''' wait status change 
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Property RoughValveStatus() As WorkingStatuses
            Get
                Return m_RoughValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                'update rough machine status when change
                Dim objRough As RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(Me.Name)
                If (objRough IsNot Nothing) Then
                    If (value = WorkingStatuses.Off AndAlso m_RoughValveStatus = WorkingStatuses.On) Then
                        objRough.ReleaseRoughLineInUse(Me.Name)
                    ElseIf (value = WorkingStatuses.On AndAlso m_RoughValveStatus = WorkingStatuses.Off) Then
                        objRough.SetRoughLineInUse(Me.Name)
                    End If
                End If

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RoughValveStatus     
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RoughValveStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Rough Valve Status", m_RoughValveStatus, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Water Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property WaterValveStatus() As WorkingStatuses
            Get
                Return m_WaterValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Water Valve Status", m_WaterValveStatus, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Vent Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Property VentValveStatus() As WorkingStatuses
            Get
                Return m_VentValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.VentValveStatus  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "VentValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Vent Valve Status", m_VentValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BaratronValveStatus() As WorkingStatuses
            Get
                Return m_BaratronValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BaratronValveStatus  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BaratronValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Baratron Valve Status", m_BaratronValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Turbo_Slit valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Turbo_IsolationValveStatus() As WorkingStatuses
            Get
                Return m_Turbo_IsolationValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Turbo_Slit valve Status", m_Turbo_IsolationValveStatus, value)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ForelineValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ForelineValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Tar Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property TarValveStatus() As WorkingStatuses
            Get
                Return m_ValveTarStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Tar Valve Status", m_ValveTarStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Tar Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutterStatus() As WorkingStatuses
            Get
                Return m_ShutterStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ShutterStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ShutterStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Shutter Status", m_ShutterStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ShutOff1 Valve Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutOff1ValveStatus() As WorkingStatuses
            Get
                Return m_ShutOff1ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas1ShutOffValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1ShutOffValveStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("ShutOff1 Valve Status", m_ShutOff1ValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ShutOff2 Valve Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutOff2ValveStatus() As WorkingStatuses
            Get
                Return m_ShutOff2ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas2ShutOffValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2ShutOffValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("ShutOff2 Valve Status", m_ShutOff2ValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ShutOff3 ValveStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutOff3ValveStatus() As WorkingStatuses
            Get
                Return m_ShutOff3ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas3ShutOffValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3ShutOffValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("ShutOff3 Valve Status", m_ShutOff3ValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ShutOff4 ValveStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutOff4ValveStatus() As WorkingStatuses
            Get
                Return m_ShutOff4ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas4ShutOffValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas4ShutOffValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("ShutOff4 Valve Status", m_ShutOff4ValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ShutOff5 ValveStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutOff5ValveStatus() As WorkingStatuses
            Get
                Return m_ShutOff5ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas5ShutOffValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas5ShutOffValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("ShutOff5 Valve Status", m_ShutOff5ValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Supply1ValveStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Supply1ValveStatus() As WorkingStatuses
            Get
                Return m_Supply1ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas1SupplyValveStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1SupplyValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Supply1 Valve Status", m_Supply1ValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Supply2 Valve Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Supply2ValveStatus() As WorkingStatuses
            Get
                Return m_Supply2ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas2SupplyValveStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2SupplyValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Supply2 Valve Status", m_Supply2ValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Supply3ValveStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Supply3ValveStatus() As WorkingStatuses
            Get
                Return m_Supply3ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas3SupplyValveStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3SupplyValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Supply3 Valve Status", m_Supply3ValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Tar Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Supply4ValveStatus() As WorkingStatuses
            Get
                Return m_Supply4ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas4SupplyValveStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas4SupplyValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Supply4 Valve Status", m_Supply5ValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Tar Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Supply5ValveStatus() As WorkingStatuses
            Get
                Return m_Supply5ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas5SupplyValveStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas5SupplyValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Supply5 Valve Status", m_Supply5ValveStatus, value)
            End Set
        End Property
#End Region

#Region "Chamber Interlocks"
        ''Basic Interlock
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ChuckWaterStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_ChuckWaterStatus() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_ChuckWaterStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Interlocks.ChuckWater 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.ChuckWater", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao 
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_ChuckWaterStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "ChuckWaterInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_ChuckWaterStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "ChuckWaterInterlock", "Chuck Water Interlock Tripped")
                End If
                CheckValueForLog("ChamberInterlocks Chuck Water Status", m_ChamberInterlocks_ChuckWaterStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ChamberInterlocks_ChamPressStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_ChamPressStatus() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_ChamPressStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Interlocks.ChamberPressure  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.ChamberPressure", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_ChamPressStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "ChamberPressureInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_ChamPressStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "ChamberPressureInterlock", "Chamber Pressure Interlock Tripped")
                End If
                CheckValueForLog("Chamber Interlocks ChamPress Status", m_ChamberInterlocks_ChamPressStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ChamberInterlocks_ChamWaterStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_ChamWaterStatus() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_ChamWaterStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Interlocks.ChamberWater  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.ChamberWater", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao 
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_ChamWaterStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "ChamberWaterInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_ChamWaterStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "ChamberWaterInterlock", "Chamber Water Interlock Tripped")
                End If
                CheckValueForLog("Chamber Interlocks ChamWater Status", m_ChamberInterlocks_ChamWaterStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_ChamberInterlocks_RSRelayStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_PSRelayStatus() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_RSRelayStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Interlocks.PSRelay  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.PSRelay", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao 
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_RSRelayStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "PSInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_RSRelayStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "PSInterlock", "PS Relay Interlock Alarm")
                End If
                CheckValueForLog("Chamber Interlocks PSRelay Status", m_ChamberInterlocks_RSRelayStatus, value)
            End Set
        End Property
        ''end Basic Interlock
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ChamberInterlocks_LidWaterStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_TargetWaterStatus() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_TargetWaterStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Interlocks.TargetWater    
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.TargetWater", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_TargetWaterStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "TargetWaterInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_TargetWaterStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "TargetWaterInterlock", "Target Water Interlock Tripped")
                End If
                CheckValueForLog("Chamber Interlocks Target Water Status", m_ChamberInterlocks_TargetWaterStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ChamberInterlocks_PSWaterStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_LidWaterStatus() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_LidWaterStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Interlocks.LidWater    
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.LidWater", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao <<CHUALAM>>
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_LidWaterStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "LidWaterInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_LidWaterStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "LidWaterInterlock", "Lid Water Interlock Tripped")
                End If
                CheckValueForLog("Chamber Interlocks LidWater Status", m_ChamberInterlocks_LidWaterStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_ChamberInterlocks_RSRelayStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_TurboForelineStatus() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_TurboForelineStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Interlocks.TurboForeline   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.TurboForeline", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao 
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_TurboForelineStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "TurboForelineInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_TurboForelineStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "TurboForelineInterlock", "Turbo Foreline Interlock Tripped")
                End If
                CheckValueForLog("Chamber Interlocks Turbo Foreline Status", m_ChamberInterlocks_TurboForelineStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_ChamberInterlocks_RSRelayStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_TurboWaterStatus() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_TurboWaterStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Interlocks.ChamberWater  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.TurboWater", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao 
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_TurboForelineStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "TurboWaterInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_TurboForelineStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "TurboWaterInterlock", "Turbo Water Interlock Tripped")
                End If
                CheckValueForLog("Chamber Interlocks Turbo Water Status", m_ChamberInterlocks_TurboWaterStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_ChamberInterlocks_RSRelayStatus
        ''' </summary>
        ''' <remarks></remarks>
        'Public Property ChamberInterlocks_TableWaterStatus() As WorkingStatuses
        '    Get
        '        Return m_blnChamberInterlock_TableWaterStatus
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("Chamber Interlock Table Water Status", m_blnChamberInterlock_TableWaterStatus, value)
        '    End Set
        'End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_ChamberInterlocks_RSRelayStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_LidSensorStatus() As WorkingStatuses
            Get
                Return m_blnChamberInterlock_LidSensorStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Interlocks.LidSensor   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.LidSensor", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao <<CHUALAM>>
                If (value = WorkingStatuses.On AndAlso m_blnChamberInterlock_LidSensorStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "ChamberLidInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_blnChamberInterlock_LidSensorStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "ChamberLidInterlock", "Chamber Lid Interlock Tripped")
                End If
                CheckValueForLog("Chamber Interlock Chamber Lid Status", m_blnChamberInterlock_LidSensorStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_ChamberInterlocks_RSRelayStatus
        ''' </summary>
        ''' <remarks></remarks>
        'Public Property ChamberInterlocks_MatchWaterStatus() As WorkingStatuses
        '    Get
        '        Return m_blnChamberInterlock_MatchWaterStatus
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("Chamber Interlock Match Water Status", m_blnChamberInterlock_MatchWaterStatus, value)
        '    End Set
        'End Property
        ''new interlocks
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_ChamberInterlocks_RSRelayStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_TargetMBWaterStatus() As WorkingStatuses
            Get
                Return m_blnChamberInterlock_TargetMBWaterStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX. Interlocks.TargetMBWater   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.TargetMBWater", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao 
                If (value = WorkingStatuses.On AndAlso m_blnChamberInterlock_TargetMBWaterStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "TargetMBWaterInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_blnChamberInterlock_TargetMBWaterStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "TargetMBWaterInterlock", "Target MB Water Interlock Tripped")
                End If
                CheckValueForLog("Chamber Interlock Target MB Water Status", m_blnChamberInterlock_TargetMBWaterStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_ChamberInterlocks_RSRelayStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_ClampWaterStatus() As WorkingStatuses
            Get
                Return m_blnChamberInterlock_ClampWaterStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Interlocks.ClampWater 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.ClampWater", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao <<CHUALAM>>
                If (value = WorkingStatuses.On AndAlso m_blnChamberInterlock_ClampWaterStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "ClampWaterInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_blnChamberInterlock_ClampWaterStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "ClampWaterInterlock", "Clamp Water Interlock Tripped")
                End If
                CheckValueForLog("Chamber Interlock Clamp Water Status", m_blnChamberInterlock_ClampWaterStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_ChamberInterlocks_RSRelayStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_SubMBWaterStatus() As WorkingStatuses
            Get
                Return m_blnChamberInterlock_SubMBWaterStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX. Interlocks.SubMBWater  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.SubMBWater", VALUELib.ValueType.U1, value)
                'Alarm Set/Clear by Dat Cao <<CHUALAM>>
                If (value = WorkingStatuses.On AndAlso m_blnChamberInterlock_SubMBWaterStatus = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "SubMBWaterInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_blnChamberInterlock_SubMBWaterStatus = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "SubMBWaterInterlock", "Sub MB Water Interlock Tripped")
                End If
                CheckValueForLog("Chamber Interlock Sub MB Water Status", m_blnChamberInterlock_SubMBWaterStatus, value)
            End Set
        End Property

#End Region

#Region "DC Target Power Supply"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_Ramptime_Readback() As Double
            Get
                Return m_dblDCTargetPowerSupply_RampTime_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DCTargetPowerSupply Ramp Time Readback", m_dblDCTargetPowerSupply_RampTime_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_Ramptime_Program() As Double
            Get
                Return m_dblDCTargetPowerSupply_RampTime_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DCTargetPowerSupply Ramp Time Program", m_dblDCTargetPowerSupply_RampTime_Program, value, True)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_Power_Readback() As Double
            Get
                Return m_dblDCTargetPowerSupply_Power_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.DCTargetPS.PowerReadback 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DCTargetPS.PowerReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("DCTargetPowerSupply Power Readback", m_dblDCTargetPowerSupply_Power_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_Power_Program() As Double
            Get
                Return m_dblDCTargetPowerSupply_Power_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.DCTargetPS.PowerProgram  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DCTargetPS.PowerProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("DCTargetPowerSupply Power Program", m_dblDCTargetPowerSupply_Power_Program, value, True)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_Voltage_Readback() As Double
            Get
                Return m_dblDCTargetPowerSupply_Voltage_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.DCTargetPS.VoltageReadback  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DCTargetPS.VoltageReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("DCTargetPowerSupply Voltage Readback", m_dblDCTargetPowerSupply_Voltage_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_Voltage_Program() As Double
            Get
                Return m_dblDCTargetPowerSupply_Voltage_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DCTargetPowerSupply Voltage Program", m_dblDCTargetPowerSupply_Voltage_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_Current_Readback() As Double
            Get
                Return m_dblDCTargetPowerSupply_Current_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.DCTargetPS.VoltageReadback  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DCTargetPS.CurrentReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("DCTargetPowerSupply Current Readback", m_dblDCTargetPowerSupply_Current_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_Current_Program() As Double
            Get
                Return m_dblDCTargetPowerSupply_Current_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DCTargetPowerSupply Current Program", m_dblDCTargetPowerSupply_Current_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_DCPulse_Readback() As Double
            Get
                Return m_dblDCTargetPowerSupply_DCPulse_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DCTargetPowerSupply DCPulse Readback", m_dblDCTargetPowerSupply_DCPulse_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_MagnetronRotationStatus() As WorkingStatuses
            Get
                Return m_DCTargetPowerSupply_MagnetronRotationStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("DCTargetPowerSupply MagnetronRotation Status", m_DCTargetPowerSupply_MagnetronRotationStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set DC TargetPowerSupply Communication Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_CommunicationStatus() As WorkingStatuses
            Get
                Return m_DCTargetPowerSupply_CommunicationStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.DCTargetPS.CommunicationStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DCTargetPS.CommunicationStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("DCTargetPowerSupply Communication Status", m_DCTargetPowerSupply_CommunicationStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_DCPulseStatus() As WorkingStatuses
            Get
                Return m_DCTargetPowerSupply_DCPulseStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.DCTargetPS.PulseMode
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DCTargetPS.PulseMode", VALUELib.ValueType.A, value)

                CheckValueForLog("DCTargetPowerSupply DCPulse Status", m_DCTargetPowerSupply_DCPulseStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DCTargetPowerSupply_KWH_Readback() As Double
            Get
                Return m_dblDCTargetPowerSupply_KWH_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DCTargetPowerSupply_KWH_Readback", m_dblDCTargetPowerSupply_KWH_Readback, value, False)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.TargetKWH.Usage
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TargetKWH.Usage", VALUELib.ValueType.F4, value.ToString())

                ' Compare Warning Limit.
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If
                If (m_objChamberModule IsNot Nothing) Then
                    CheckingKWH(m_dblDCTargetPowerSupply_KWH_Readback)
                End If

            End Set
        End Property
       
#End Region

#Region "Bias Power Supply"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_ForwardPower_Readback() As Double
            Get
                Return m_dblBiasPowerSupply_ForwardPower_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.ForwardPowerReadback 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.ForwardPowerReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("BiasPowerSupply Forward Power Readback", m_dblBiasPowerSupply_ForwardPower_Readback, value, False)
            End Set
        End Property

        Public Property BiasPowerSupply_ForwardPower_Program() As Double
            Get
                Return m_dblBiasPowerSupply_ForwardPower_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.ForwardPowerProgram 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.ForwardPowerProgram", VALUELib.ValueType.F4, value)
                CheckValueForLog("BiasPowerSupply Forward Power Program", m_dblBiasPowerSupply_ForwardPower_Program, value)
            End Set
        End Property

        Public Property BiasPowerSupply_ReflectedPower_Readback() As Double
            Get
                Return m_dblBiasPowerSupply_ReflectedPower_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.ForwardPowerReadback 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.ReflectedPowerReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("BiasPowerSupply Reflected Power Readback", m_dblBiasPowerSupply_ReflectedPower_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_Voltage_Program() As Double
            Get
                Return m_dblBiasPowerSupply_Voltage_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BiasPowerSupply Voltage Program", m_dblBiasPowerSupply_Voltage_Program, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_Voltage_Readback() As Double
            Get
                Return m_dblBiasPowerSupply_Voltage_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.VoltageReadback 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.VoltageReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("BiasPowerSupply Voltage Readback", m_dblBiasPowerSupply_Voltage_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_C1_Readback() As Double
            Get
                Return m_dblBiasPowerSupply_C1_Readback
            End Get
            Set(ByVal value As Double)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.C1Readback 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.C1Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("BiasPowerSupply C1 Readback", m_dblBiasPowerSupply_C1_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_C1_Program() As Double
            Get
                Return m_dblBiasPowerSupply_C1_Program
            End Get
            Set(ByVal value As Double)


                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.C1Program 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.C1Program", VALUELib.ValueType.F4, value)

                CheckValueForLog("BiasPowerSupply C1 Program", m_dblBiasPowerSupply_C1_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_C2_Readback() As Double
            Get
                Return m_dblBiasPowerSupply_C2_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.C2Readback 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.C2Readback", VALUELib.ValueType.F4, value)

                CheckValueForLog("BiasPowerSupply C2 Readback", m_dblBiasPowerSupply_C2_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_C2_Program() As Double
            Get
                Return m_dblBiasPowerSupply_C2_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.C2Program 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.C2Program", VALUELib.ValueType.F4, value)

                CheckValueForLog("BiasPowerSupply C2 Program", m_dblBiasPowerSupply_C2_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_Match_Readback() As Double
            Get
                Return m_dblBiasPowerSupply_Match_Readback
            End Get
            Set(ByVal value As Double)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.MatchMode 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.MatchMode", VALUELib.ValueType.A, value)

                CheckValueForLog("BiasPowerSupply Match Readback", m_dblBiasPowerSupply_Match_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_Presets_Readback() As Double
            Get
                Return m_dblBiasPowerSupply_Presets_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.PresetReadback 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.PresetReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("BiasPowerSupply Presets Readback", m_dblBiasPowerSupply_Presets_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_Presets_Program() As Double
            Get
                Return m_dblBiasPowerSupply_Presets_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BiasPS.PresetProgram 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.PresetProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("BiasPowerSupply Preset Program", m_dblBiasPowerSupply_Presets_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Bias TargetPowerSupply Communication Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_CommunicationStatus() As WorkingStatuses
            Get
                Return m_BiasPowerSupply_CommunicationStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.DCTargetPS.CommunicationStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BiasPS.CommunicationStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("BiasPowerSupply Communication Status", m_BiasPowerSupply_CommunicationStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set button Auto Bias Power Supply
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_AutoStatus() As WorkingStatuses
            Get
                Return m_BiasPowerSupply_AutoStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("BiasPowerSupply Auto Status", m_BiasPowerSupply_AutoStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set button Auto Bias Power Supply
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_RecallStatus() As WorkingStatuses
            Get
                Return m_BiasPowerSupply_RecallStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("BiasPowerSupply Recall Status", m_BiasPowerSupply_RecallStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set button Auto Bias Power Supply
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasPowerSupply_StoreStatus() As WorkingStatuses
            Get
                Return m_BiasPowerSupply_StoreStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("BiasPowerSupply Store Status", m_BiasPowerSupply_StoreStatus, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2012-05-30 </date>
        ''' </author>
        ''' <summary>
        ''' Get or BiasTargetPowerSupply_Mag
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasTargetPowerSupply_Mag() As Double
            Get
                Return m_dBiasTargetPowerSupply_Mag
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Bias Target Power Supply Mag", m_dBiasTargetPowerSupply_Mag, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2012-05-30 </date>
        ''' </author>
        ''' <summary>
        ''' Get or BiasTargetPowerSupply_Phase
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasTargetPowerSupply_Phase() As Double
            Get
                Return m_dBiasTargetPowerSupply_Phase
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Bias Target Power Supply Phase", m_dBiasTargetPowerSupply_Phase, value)
            End Set
        End Property

        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2012-05-30 </date>
        ''' </author>
        ''' <summary>
        ''' Get or BiasTargetPowerSupply_ErrorStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BiasTargetPowerSupply_ErrorStatus() As String
            Get
                Return m_dBiasTargetPowerSupply_ErrorStatus
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Bias Target Power Supply ErrorStatus", m_dBiasTargetPowerSupply_ErrorStatus, value)
            End Set
        End Property

        Public Property BiasPowerKWHReadback() As Double
            Get
                Return m_dBiasPowerKWHReadback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BiasPowerKWHReadback", m_dBiasPowerKWHReadback, value, False)
                If Not System_Init_Indicator.IsMainFormInitialize Then
                    Exit Property
                End If
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.TargetKWH.Usage
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TargetKWH.Usage", VALUELib.ValueType.F4, value.ToString())

                ' Compare Warning Limit.
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If
                If (m_objChamberModule IsNot Nothing) Then
                    CheckingKWH(m_dBiasPowerKWHReadback)
                End If
            End Set
        End Property

        Public Property BiasPowerKWHProgram() As Double
            Get
                Return m_dBiasPowerKWHProgram
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Bias Target KWH Program", m_dBiasPowerKWHProgram, value)
            End Set
        End Property

#End Region

#Region "Parallel Magnet"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ParallelMagnet_Current_Readback() As Double
            Get
                Return m_dblParallelMagnet_Current_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ParallelMagnet.CurrentReadback   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ParallelMagnet.CurrentReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("ParallelMagnet Current Readback", m_dblParallelMagnet_Current_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ParallelMagnet_Current_Program() As Double
            Get
                Return m_dblParallelMagnet_Current_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ParallelMagnet.CurrentProgram   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ParallelMagnet.CurrentProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("ParallelMagnet Current Program", m_dblParallelMagnet_Current_Program, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ParallelMagnet_Duty_Program() As Double
            Get
                Return m_dblParallelMagnet_Duty_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ParallelMagnet.DutyProgram   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ParallelMagnet.DutyProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("ParallelMagnet Duty Program", m_dblParallelMagnet_Duty_Program, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ParallelMagnet_Frequency_Program() As Double
            Get
                Return m_dblParallelMagnet_Prequency_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ParallelMagnet.FrequencyProgram   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ParallelMagnet.FrequencyProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("ParallelMagnet Prequency Program", m_dblParallelMagnet_Prequency_Program, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ParallelMagnet_Voltage_Readback() As Double
            Get
                Return m_dblParallelMagnet_Voltage_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ParallelMagnet.VoltageReadback   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ParallelMagnet.VoltageReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("ParallelMagnet Voltage Readback", m_dblParallelMagnet_Voltage_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ParallelMagnetStatus() As Double
            Get
                Return m_ParallelMagnetStatus
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.DCTargetPS.ParallelMagnetOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ParallelMagnetOnOff", VALUELib.ValueType.U1, value)

                CheckValueForLog("ParallelMagnet Status", m_ParallelMagnetStatus, value, False)
            End Set
        End Property
#End Region

#Region "RF Target Power Supply"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_ForwardPower_Readback() As Double
            Get
                Return m_dblRFTargetPowerSupply_ForwardPower_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ForwardPowerReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.ForwardPowerReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("RFTargetPowerSupply Forward Power Readback", m_dblRFTargetPowerSupply_ForwardPower_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_ForwardPower_Program() As Double
            Get
                Return m_dblRFTargetPowerSupply_ForwardPower_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.DCTargetPS.CommunicationStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.ForwardPowerProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("RFTargetPowerSupply Forward Power Program", m_dblRFTargetPowerSupply_ForwardPower_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_ReflectedPower_Readback() As Double
            Get
                Return m_dblRFTargetPowerSupply_ReflectedPower_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RFTargetPS.ReflectedPowerReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.ReflectedPowerReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("RFTargetPowerSupply Reflected Power Readback", m_dblRFTargetPowerSupply_ReflectedPower_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_Voltage_Readback() As Double
            Get
                Return m_dblRFTargetPowerSupply_Voltage_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RFTargetPS.VoltageReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.VoltageReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("RFTargetPowerSupply Voltage Readback", m_dblRFTargetPowerSupply_Voltage_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_C1_Readback() As Double
            Get
                Return m_dblRFTargetPowerSupply_C1_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RFTargetPS.C1Readback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.C1Readback", VALUELib.ValueType.F4, value)

                CheckValueForLog("RFTargetPowerSupply C1 Readback", m_dblRFTargetPowerSupply_C1_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_C1_Program() As Double
            Get
                Return m_dblRFTargetPowerSupply_C1_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RFTargetPS.C1Program
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.C1Program", VALUELib.ValueType.F4, value)

                CheckValueForLog("RFTargetPowerSupply C1 Program", m_dblRFTargetPowerSupply_C1_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_C2_Readback() As Double
            Get
                Return m_dblRFTargetPowerSupply_C2_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RFTargetPS.C2Readback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.C2Readback", VALUELib.ValueType.F4, value)

                CheckValueForLog("RFTargetPowerSupply C2 Readback", m_dblRFTargetPowerSupply_C2_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_C2_Program() As Double
            Get
                Return m_dblRFTargetPowerSupply_C2_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RFTargetPS.C2Program
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.C2Program", VALUELib.ValueType.F4, value)

                CheckValueForLog("RFTargetPowerSupply C2 Program", m_dblRFTargetPowerSupply_C2_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_Match_Readback() As Double
            Get
                Return m_dblRFTargetPowerSupply_Match_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RFTargetPS.MatchMode 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.MatchMode", VALUELib.ValueType.A, value.ToString())

                CheckValueForLog("RFTargetPowerSupply Match Readback", m_dblRFTargetPowerSupply_Match_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_Presets_Readback() As Double
            Get
                Return m_dblRFTargetPowerSupply_Presets_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RFTargetPS.PresetReadback  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.PresetReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("RFTargetPowerSupply Presets Readback", m_dblRFTargetPowerSupply_Presets_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_Presets_Program() As Double
            Get
                Return m_dblRFTargetPowerSupply_Presets_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RFTargetPS.PresetProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.PresetProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("RFTargetPowerSupply Presets Program", m_dblRFTargetPowerSupply_Presets_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set RF TargetPowerSupply Communication Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_CommunicationStatus() As WorkingStatuses
            Get
                Return m_RFTargetPowerSupply_CommunicationStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.DCTargetPS.CommunicationStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTargetPS.CommunicationStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("RFTargetPowerSupply Communication Status", m_RFTargetPowerSupply_CommunicationStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set button Auto RFTarget Power Supply
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_AutoStatus() As WorkingStatuses
            Get
                Return m_RFTargetPowerSupply_AutoStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("RFTargetPowerSupply Auto Status", m_RFTargetPowerSupply_AutoStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set button Auto RFTarget Power Supply
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_RecallStatus() As WorkingStatuses
            Get
                Return m_RFTargetPowerSupply_RecallStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("RFTargetPowerSupply Recall Status", m_RFTargetPowerSupply_RecallStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set button Auto RFTarget Power Supply
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_StoreStatus() As WorkingStatuses
            Get
                Return m_RFTargetPowerSupply_StoreStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("RFTargetPowerSupply Store Status", m_RFTargetPowerSupply_StoreStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set button Auto RFTarget Power Supply
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_KWH_Readback() As Double
            Get
                Return m_dblRFTargetPowerSupply_KWH_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("RFTargetPowerSupply_KWH_Readback", m_dblRFTargetPowerSupply_KWH_Readback, value, False)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.TargetKWH.Usage
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TargetKWH.Usage", VALUELib.ValueType.F4, value.ToString())


                ' Compare Warning Limit.
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If
                If (m_objChamberModule IsNot Nothing) Then
                    CheckingKWH(m_dblRFTargetPowerSupply_KWH_Readback)
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2012-05-30 </date>
        ''' </author>
        ''' <summary>
        ''' Get or SetRFTargetPowerSupply_Mag
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_Mag() As Double
            Get
                Return m_dRFTargetPowerSupply_Mag
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("RF Target Power Supply Mag", m_dRFTargetPowerSupply_Mag, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2012-05-30 </date>
        ''' </author>
        ''' <summary>
        ''' Get or RFTargetPowerSupply_Phase
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_Phase() As Double
            Get
                Return m_dRFTargetPowerSupply_Phase
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("RF Target Power Supply Phase", m_dRFTargetPowerSupply_Phase, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2012-05-30 </date>
        ''' </author>
        ''' <summary>
        ''' Get or RFTargetPowerSupply_ErrorStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RFTargetPowerSupply_ErrorStatus() As String
            Get
                Return m_dRFTargetPowerSupply_ErrorStatus
            End Get
            Set(ByVal value As String)
                CheckValueForLog("RF Target Power Supply ErrorStatus", m_dRFTargetPowerSupply_ErrorStatus, value)
            End Set
        End Property


#End Region

#Region "CG & MG"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MG_Information() As Double
            Get
                Return m_dblMG_Information
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("MG", m_dblMG_Information, value, False)

                ' 
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ManometerPressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ManometerPressure", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CG_Information() As Double
            Get
                Return m_dblCG_Information
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Hoa Nguyen
                ' Var Name: PMX.RoughPumpPowerOnOff
                Dim sRoughPump As String = "_RoughPump_Max_Value"
                If CDbl(value) <= AVPLib.ContainerData.GetPressureConfig(Me.Name & sRoughPump) Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RoughPumpPowerOnOff", VALUELib.ValueType.U1, WorkingStatuses.On)
                Else
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RoughPumpPowerOnOff", VALUELib.ValueType.U1, WorkingStatuses.Off)
                End If

                CheckValueForLog("CG", m_dblCG_Information, value, False)
            End Set
        End Property
#End Region

#Region "Chuck Control"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Plasma_Status_Readback() As WorkingStatuses
            Get
                Return m_Plasma_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.PlasmaOnOff      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PlasmaOnOff", VALUELib.ValueType.U1, value)

                ' Trigger SECS/GEM Event by Dat Cao
                ' Var Name: PMX.PlasmaOn/PlasmaOff      
                If (value = WorkingStatuses.On And m_Plasma_Status <> WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.MySecsGemObj.TriggerEvent(Me.Name, "PlasmaOn")
                ElseIf (value = WorkingStatuses.Off And m_Plasma_Status <> WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.MySecsGemObj.TriggerEvent(Me.Name, "PlasmaOff")
                End If

                CheckValueForLog("Plasma Status Readback", m_Plasma_Status, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChuckPos_Readback() As Double
            Get
                Return m_dblChuckPos_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ChuckPositionReadback      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ChuckPositionReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("Chuck Pos Readback", m_dblChuckPos_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChuckPos_Program() As Double
            Get
                Return m_dblChuckPos_Program
            End Get
            Set(ByVal value As Double)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ChuckPositionProgram      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ChuckPositionProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("Chuck Pos Program", m_dblChuckPos_Program, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ClampStatus_Readback() As WorkingStatuses
            Get
                Return m_ClampStatus_Readback
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ClampStatus      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ClampStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Clamp Status Readback", m_ClampStatus_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ClampStatus_Program() As WorkingStatuses
            Get
                Return m_ClampStatus_Program
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Clamp Status Program", m_ClampStatus_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property PlasmaIgniterStatus() As WorkingStatuses
            Get
                Return m_bicPlasmaIgniterStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.PlasmaIgniterStatus     
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PlasmaIgniterStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Plasma Igniter Status", m_bicPlasmaIgniterStatus, value)
            End Set
        End Property
#End Region

#Region "CG Set Point"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Baratron_CG_Program() As Double
            Get
                Return m_dblBaratron_CG_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("CG Set Point", m_dblBaratron_CG_Program, value, False)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.BaratronPressure     
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BaratronPressure", VALUELib.ValueType.F4, value.ToString)

            End Set
        End Property
#End Region

#Region "Vat Valve controller"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property VatValve_SizeAdjust_Program() As WorkingStatuses
            Get
                Return m_VatValve_SizeAdj_Program
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("VatValve SizeAdjust Program", m_VatValve_SizeAdj_Program, value, True)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property VatValve_Teach_Program() As WorkingStatuses
            Get
                Return m_VatValve_Teach_Program
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("VatValve Teach Program", m_VatValve_Teach_Program, value, True)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property VatValve_Pressure_Program() As Double
            Get
                Return m_dblVatValve_Pressure_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("VatValve Pressure Program", m_dblVatValve_Pressure_Program, value, False)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.VatValve.Pressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "VatValve.Pressure", VALUELib.ValueType.F4, value.ToString)

            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property VatValve_PressurePercent_Program() As Double
            Get
                Return m_dblVatValve_PressurePercent_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("VatValve Pressure Percent Program", m_dblVatValve_PressurePercent_Program, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property VatValve_CommunicationStatus() As WorkingStatuses
            Get
                Return m_VatValve_CommunicationStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.VATCommunicationStatus    
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "VATCommunicationStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Vat Valve Communication Status", m_VatValve_CommunicationStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property VatValve_Percentage() As Double
            Get
                Return m_dblVatValve_Percentage
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Vat Valve Percentage", m_dblVatValve_Percentage, value, False)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.VatValve.Position
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "VatValve.Position", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

#End Region

#Region "Cryo"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Cryo_RegenHour_Readback() As Double
            Get
                Return m_dblCryo_RegenHour_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Cryo.RegenHour      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.RegenHour", VALUELib.ValueType.F4, value)

                CheckValueForLog("Cryo Regen Hour Readback", m_dblCryo_RegenHour_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Cryo_LifeTimeHour_Readback() As Double
            Get
                Return m_dblCryo_LifeTimeHour_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Cryo.LifeTimeHour      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.LifeTimeHour", VALUELib.ValueType.F4, value)

                CheckValueForLog("Cryo Life Time Hour Readback", m_dblCryo_LifeTimeHour_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Cryo_T1_Readback() As Double
            Get
                Return m_dblCryo_T1_Readback
            End Get
            Set(ByVal value As Double)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Cryo.FistTemperature      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.FistTemperature", VALUELib.ValueType.F4, value)

                CheckValueForLog("Cryo T1 Readback", m_dblCryo_T1_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Cryo_T2_Readback() As Double
            Get
                Return m_dblCryo_T2_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Cryo.SecondTemperature      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.SecondTemperature", VALUELib.ValueType.F4, value)

                CheckValueForLog("Cryo T2 Readback", m_dblCryo_T2_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Cryo_CommunicationStatus() As WorkingStatuses
            Get
                Return m_Cryo_CommunicationStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX. Cryo.CommunicationStatus   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.CommunicationStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Cryo Communication Status", m_Cryo_CommunicationStatus, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Cryo Extended Purge Time
        ''' </summary>
        ''' <remarks></remarks>
        
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Cryo Extended Purge Time
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Cryo_P_Command() As String
            Get
                Return m_strCryo_P_Command
            End Get
            Set(ByVal value As String)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX. Cryo.CommunicationStatus   
                '                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.CommunicationStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Cryo P Command", m_strCryo_P_Command, value)
            End Set
        End Property
#End Region

#Region "Water Pump"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property WaterPump_T_Readback() As Double
            Get
                Return m_dblWaterPump_T_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.WaterPumpTemperature  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaterPumpTemperature", VALUELib.ValueType.F4, value)

                CheckValueForLog("Water Pump T Readback", m_dblWaterPump_T_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property WaterPump_Status() As WorkingStatuses
            Get
                Return m_WaterPump_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.WaterPump.OnOff   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaterPump.OnOff", VALUELib.ValueType.U1, value)

                CheckValueForLog("Water Pump Status", m_WaterPump_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property WaterPump_RegenHour_Readback() As Double
            Get
                Return m_dblWaterPump_RegenHour
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.WaterPumpRegenHour  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaterPumpRegenHour", VALUELib.ValueType.F4, value)

                CheckValueForLog("Water Pump Regen Hour", m_dblWaterPump_RegenHour, value)
            End Set
        End Property

        Public Property WaterPump_LifeTimeHour_Readback() As Double
            Get
                Return m_dblWaterPump_LifeTimeHour
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.WaterPumpLifeTimeHour  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaterPumpLifeTimeHour", VALUELib.ValueType.F4, value)

                CheckValueForLog("Water Pump Life Time Hour", m_dblWaterPump_LifeTimeHour, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property WaterPumpRegen_Status() As WorkingStatuses
            Get
                Return m_WaterPumpRegen_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.WaterPump.RegenOnOff    
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaterPump.RegenOnOff", _
                        VALUELib.ValueType.U1, Utils.ConvertWorkingStatusValueForUpdateGEM(value))
                CheckValueForLog("Water Pump Regen Status", m_WaterPumpRegen_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property WaterPumpState_Status() As WorkingStatuses
            Get
                Return m_WaterPumpState_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.WaterPump.OnOff    
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaterPump.OnOff", VALUELib.ValueType.U1, value)

                CheckValueForLog("Water Pump State Status", m_WaterPumpState_Status, value)
            End Set
        End Property

#End Region

#Region "Turbo Pump"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Turbo_PumpStatus() As WorkingStatuses
            Get
                Return m_Turbo_PumpStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.TurboOnOff   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TurboOnOff", VALUELib.ValueType.U1, value)

                CheckValueForLog("Turbo Pump Status", m_Turbo_PumpStatus, value)
            End Set
        End Property
#End Region

#Region "Gas Controller"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GasController_Gas1_Readback() As Double
            Get
                Return m_dblGasController_Gas1_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas1ChannelReadback   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1ChannelReadback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas Controller Gas1 Readback", m_dblGasController_Gas1_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GasController_Gas2_Readback() As Double
            Get
                Return m_dblGasController_Gas2_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas2ChannelReadback   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2ChannelReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("Gas Controller Gas2 Readback", m_dblGasController_Gas2_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GasController_Gas3_Readback() As Double
            Get
                Return m_dblGasController_Gas3_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas3ChannelReadback   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3ChannelReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("Gas Controller Gas3 Readback", m_dblGasController_Gas3_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GasController_Gas4_Readback() As Double
            Get
                Return m_dblGasController_Gas4_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas4ChannelReadback   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas4ChannelReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("Gas Controller Gas4 Readback", m_dblGasController_Gas4_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GasController_Gas5_Readback() As Double
            Get
                Return m_dblGasController_Gas5_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas5ChannelReadback   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas5ChannelReadback", VALUELib.ValueType.F4, value)

                CheckValueForLog("Gas Controller Gas5 Readback", m_dblGasController_Gas5_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GasController_Gas1_Program() As Double
            Get
                Return m_dblGasController_Gas1_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas1ChannelProgram   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1ChannelProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("Gas Controller Gas1 Program", m_dblGasController_Gas1_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GasController_Gas2_Program() As Double
            Get
                Return m_dblGasController_Gas2_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas2ChannelProgram   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2ChannelProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("Gas Controller Gas2 Program", m_dblGasController_Gas2_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GasController_Gas3_Program() As Double
            Get
                Return m_dblGasController_Gas3_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas3ChannelProgram   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3ChannelProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("Gas Controller Gas3 Program", m_dblGasController_Gas3_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GasController_Gas4_Program() As Double
            Get
                Return m_dblGasController_Gas4_Program
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas4ChannelProgram   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas4ChannelProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("Gas Controller Gas4 Program", m_dblGasController_Gas4_Program, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GasController_Gas5_Program() As Double
            Get
                Return m_dblGasController_Gas5_Program
            End Get
            Set(ByVal value As Double)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas5ChannelProgram   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas5ChannelProgram", VALUELib.ValueType.F4, value)

                CheckValueForLog("Gas Controller Gas5 Program", m_dblGasController_Gas5_Program, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutOff_GasLine1_Status() As WorkingStatuses
            Get
                Return m_ShutOff_GasLine1_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ShutOff GasLine1 Status", m_ShutOff_GasLine1_Status, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutOff_GasLine2_Status() As WorkingStatuses
            Get
                Return m_ShutOff_GasLine2_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ShutOff GasLine2 Status", m_ShutOff_GasLine2_Status, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutOff_GasLine3_Status() As WorkingStatuses
            Get
                Return m_ShutOff_GasLine3_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ShutOff GasLine3 Status", m_ShutOff_GasLine3_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutOff_GasLine4_Status() As WorkingStatuses
            Get
                Return m_ShutOff_GasLine4_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ShutOff GasLine4 Status", m_ShutOff_GasLine4_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShutOff_GasLine5_Status() As WorkingStatuses
            Get
                Return m_ShutOff_GasLine5_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ShutOff GasLine5 Status", m_ShutOff_GasLine5_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Supply_GasLine1_Status() As WorkingStatuses
            Get
                Return m_Supply_GasLine1_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Supply GasLine1 Status", m_Supply_GasLine1_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Supply_GasLine2_Status() As WorkingStatuses
            Get
                Return m_Supply_GasLine2_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Supply GasLine2 Status", m_Supply_GasLine2_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Supply_GasLine3_Status() As WorkingStatuses
            Get
                Return m_Supply_GasLine3_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Supply GasLine3 Status", m_Supply_GasLine3_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Supply_GasLine4_Status() As WorkingStatuses
            Get
                Return m_Supply_GasLine4_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Supply GasLine4 Status", m_Supply_GasLine4_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Supply_GasLine5_Status() As WorkingStatuses
            Get
                Return m_Supply_GasLine5_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Supply GasLine5 Status", m_Supply_GasLine5_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property HivacValve_GasLine_Status() As WorkingStatuses
            Get
                Return m_HivacValve_GasLine_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Hivac Valve Status", m_HivacValve_GasLine_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RoughValve_GasLine_Status() As WorkingStatuses
            Get
                Return m_RoughValve_GasLine_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Rough Valve Status", m_RoughValve_GasLine_Status, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property VentValve_GasLine_Status() As WorkingStatuses
            Get
                Return m_VentValve_GasLine_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Vent Valve Status", m_VentValve_GasLine_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BaratronValve_GasLine_Status() As WorkingStatuses
            Get
                Return m_BaratronValve_GasLine_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Baratron Valve Status", m_BaratronValve_GasLine_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Turbo_IsolationValve_GasLine_Status() As WorkingStatuses
            Get
                Return m_Turbo_IsolationValve_GasLine_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Turbo Iso lationValve Status", m_Turbo_IsolationValve_GasLine_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AutoZeroVatValve_GasLine_Status() As WorkingStatuses
            Get
                Return m_AutoZeroVatValve_GasLine_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("AutoZero Vat Valve Status", m_AutoZeroVatValve_GasLine_Status, value)
            End Set
        End Property
#End Region

#Region "Process Monitor"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_WaferID_Readback() As String
            Get
                Return m_strProcessMonitor_WaferID_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor WaferID Readback", m_strProcessMonitor_WaferID_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_ProcessTime_Readback() As String
            Get
                Return m_strProcessMonitor_ProcessTime_Readback
            End Get
            Set(ByVal value As String)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ProcessTime  
                If String.IsNullOrEmpty(value) = False Then
                    Dim lstTime As String() = Split(value, "/")
                    If lstTime.Length = 2 Then
                        If IsNumeric(lstTime(0)) Then
                            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessTime", VALUELib.ValueType.A, lstTime(0))
                        Else
                            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessTime", VALUELib.ValueType.A, "0")
                        End If

                        If IsNumeric(lstTime(1)) Then
                            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalProcessTime", VALUELib.ValueType.A, lstTime(1))
                        Else
                            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalProcessTime", VALUELib.ValueType.A, "0")
                        End If
                    End If
                End If
                CheckValueForLog("ProcessMonitor ProcessTime Readback", m_strProcessMonitor_ProcessTime_Readback, value, False)
                UpdateWaferProcessTimeInRealTime(value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_UserLevel_Readback() As String
            Get
                Return m_strProcessMonitor_UserLevel_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor UserLevel Readback", m_strProcessMonitor_UserLevel_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_Status_Readback() As String
            Get
                Return m_strProcessMonitor_Status_Readback
            End Get
            Set(ByVal value As String)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ProcessModuleProcessingState 
                If (value = EnumChamberState.ERRORS.ToString()) Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, _
                    "ProcessModuleProcessingState", VALUELib.ValueType.U1, ProcessModuleProcessingState.PAUSED)

                    If (m_strProcessMonitor_Status_Readback <> EnumChamberState.ERRORS.ToString()) Then
                        Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessModuleStateChanged")
                    End If

                ElseIf (value = EnumChamberState.IDLE.ToString() OrElse value = EnumChamberState.WAITING_UNLOAD.ToString()) Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, _
                    "ProcessModuleProcessingState", VALUELib.ValueType.U1, ProcessModuleProcessingState.IDLE)

                    If ((m_strProcessMonitor_Status_Readback <> EnumChamberState.IDLE.ToString()) AndAlso _
                    (m_strProcessMonitor_Status_Readback <> EnumChamberState.WAITING_UNLOAD.ToString())) Then
                        Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessModuleStateChanged")
                    End If

                ElseIf (value = EnumChamberState.RUNNING.ToString()) Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, _
                    "ProcessModuleProcessingState", VALUELib.ValueType.U1, ProcessModuleProcessingState.PROCESSING)

                    If (m_strProcessMonitor_Status_Readback <> EnumChamberState.RUNNING.ToString()) Then
                        Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessModuleStateChanged")
                    End If

                End If

                CheckValueForLog("ProcessMonitor Status Readback", m_strProcessMonitor_Status_Readback, value, False)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_ResetError_Readback() As String
            Get
                Return m_strProcessMonitor_ResetError_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor Status Readback", m_strProcessMonitor_ResetError_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_DeviceStart_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceStart_Readback
            End Get
            Set(ByVal value As String)
                Utils.UpdateSequenceRunningStatusText(Me.Name, RECIPE_PROCESS_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, STR_ON)

                CheckValueForLog("ProcessMonitor DeviceStart Readback", m_strProcessMonitor_DeviceStart_Readback, value, False)
                BeginCountingWaferProcessTime()
                ChangeProcessState(ConstEnum.enumProcessStatus.eStart)
                AVPLib.Utils.TurnOffSystem_Light(False, Me.Name)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_DeviceStop_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceStop_Readback
            End Get
            Set(ByVal value As String)
                Utils.UpdateSequenceRunningStatusText(Me.Name, RECIPE_PROCESS_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, STR_OFF)

                CheckValueForLog("ProcessMonitor DeviceStop Readback", m_strProcessMonitor_DeviceStop_Readback, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.eStop)
                AVPLib.Utils.TurnOffSystem_Light(True, Me.Name)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_DevicePause_Readback() As String
            Get
                Return m_strProcessMonitor_DevicePause_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor DevicePause Readback", m_strProcessMonitor_DevicePause_Readback, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.ePause)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_DeviceResume_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceResume_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor DeviceResume Readback", m_strProcessMonitor_DeviceResume_Readback, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.eContinue)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_DeviceSendRecipeName_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceSendRecipeName_Readback
            End Get
            Set(ByVal value As String)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ProcessMonitor.RecipeName 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor.RecipeName", VALUELib.ValueType.A, value)

                CheckValueForLog("ProcessMonitor Device Send Recipe Name Readback", m_strProcessMonitor_DeviceSendRecipeName_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_DeviceError_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceError_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor Device Error Readback", m_strProcessMonitor_DeviceError_Readback, value, False)
                AVPLib.Utils.TurnOffSystem_Light(True, Me.Name)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessControl_GetRunDataFileName() As WorkingStatuses
            Get
                Return m_ProcessControl_GetRunDataFileName
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ProcessControl_GetRunDataFileName", m_ProcessControl_GetRunDataFileName, value, False)
            End Set
        End Property
#End Region

#Region "Menu Machine"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Machine Vent
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MachineIGDegas_Status() As WorkingStatuses
            Get
                Return m_MachineIGDegasStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                Utils.UpdateSequenceRunningStatusText(Me.Name, IG_DEGAS_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString())

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.IGDegasRunning      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "IGDegasRunning", VALUELib.ValueType.U1, value)

                CheckValueForLog("[menu] IG Degas", m_MachineIGDegasStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Machine Vent
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MachinePumpPurge_Status() As WorkingStatuses
            Get
                Return m_MachinePumpPurgeStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                Utils.UpdateSequenceRunningStatusText(Me.Name, PUMP_PURGE_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString())
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.PumpPurgeRunning       
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PumpPurgeRunning", VALUELib.ValueType.U1, value)

                CheckValueForLog("[menu] Pump Purge", m_MachinePumpPurgeStatus, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Machine Vent
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MachineFastRegen_Status() As WorkingStatuses
            Get
                Return m_MachineFastRegen_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: Cryo.FastRegenOnOff      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.FastRegenOnOff", VALUELib.ValueType.U1, value)

                CheckValueForLog("[menu] Fast Regen", m_MachineFastRegen_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Machine Vent
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MachineVent() As WorkingStatuses
            Get
                Return m_MachineVentStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                Utils.UpdateSequenceRunningStatusText(Me.Name, AUTO_VENT_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString())

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.AutoVentRunning      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "AutoVentRunning", VALUELib.ValueType.U1, value)

                CheckValueForLog("[menu] Vent", m_MachineVentStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MachinePumpDown() As WorkingStatuses
            Get
                Return m_MachinePumpDownStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                Utils.UpdateSequenceRunningStatusText(Me.Name, AUTO_PUMPDOWN_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString())

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.AutoPumpDownRunning      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "AutoPumpDownRunning", VALUELib.ValueType.U1, value)

                CheckValueForLog("[menu] Pump Down", m_MachinePumpDownStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MachineCryoOn() As WorkingStatuses
            Get
                Return m_MachineCryoOnStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Cryo.OnOff      
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.OnOff", VALUELib.ValueType.U1, value)

                CheckValueForLog("[menu] Cryo On", m_MachineCryoOnStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MachineCryoRegn() As WorkingStatuses
            Get
                Return m_MachineCryoRegnStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Cryo.RegenOnOff     
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.RegenOnOff", _
                        VALUELib.ValueType.U1, Utils.ConvertWorkingStatusValueForUpdateGEM(value))

                CheckValueForLog("[menu] Cryo Regn", m_MachineCryoRegnStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_MachineShutDownPowerStatus
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MachineShutDownPower() As WorkingStatuses
            Get
                Return m_MachineShutDownPowerStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("[menu] ShutDown Power Status", m_MachineShutDownPowerStatus, value)
                Utils.UpdateSequenceRunningStatusText(Me.Name, SHUTDOWN_POWER_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString())
            End Set
        End Property
#End Region

#Region "CG/IG"
        Private m_ATMChamberCGStatus As WorkingStatuses
        Public Property ATMChamberCGStatus() As WorkingStatuses
            Get
                Return m_ATMChamberCGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ATMChamberCGStatus", m_ATMChamberCGStatus, value, False)
            End Set
        End Property

        Private m_VACChamberCGStatus As WorkingStatuses
        Public Property VACChamberCGStatus() As WorkingStatuses
            Get
                Return m_VACChamberCGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("VACChamberCGStatus", m_VACChamberCGStatus, value, False)
            End Set
        End Property

        Private m_ATMForelineCGStatus As WorkingStatuses
        Public Property ATMForelineCGStatus() As WorkingStatuses
            Get
                Return m_ATMForelineCGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ATMForelineCGStatus", m_ATMForelineCGStatus, value, False)
            End Set
        End Property

        Private m_ATMRoughLineCGStatus As WorkingStatuses
        Public Property ATMRoughLineCGStatus() As WorkingStatuses
            Get
                Return m_ATMRoughLineCGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ATMRoughLineCGStatus", m_ATMRoughLineCGStatus, value, False)
            End Set
        End Property

        Private m_ATMMechanicalPumpCGStatus As WorkingStatuses
        Public Property ATMMechanicalPumpCGStatus() As WorkingStatuses
            Get
                Return m_ATMMechanicalPumpCGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ATMMechanicalPumpCGStatus", m_ATMMechanicalPumpCGStatus, value, False)
            End Set
        End Property
#End Region

#Region "Other"
        Public Overrides Function IsShutterOpen() As Boolean
            Return (Shutter_ValveStatus = WorkingStatuses.On)
        End Function
        Public Property OverrideMode_Status() As WorkingStatuses
            Get
                Return m_OverrideMode_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Magnetron.OverrideModeOnOff     
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "OverrideModeOnOff", VALUELib.ValueType.U1, value)

                CheckValueForLog("Override Mode Status", m_OverrideMode_Status, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set AutoZeroVatValve_Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AutoZeroVatValve_Status() As WorkingStatuses
            Get
                Return m_AutoZeroVatValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("AutoZero Vat Valve Status", m_AutoZeroVatValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Hivac Valve_Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property HivacValve_Status() As WorkingStatuses
            Get
                Return m_HivacValve_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.HivacValveStatus  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "HivacValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Hivac Valve Status", m_HivacValve_Status, value)
            End Set
        End Property
        '''   ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RoughLineCG_Readback() As Double
            Get
                Return m_dblRoughLineCG_Readback
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RoughlineCG   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RoughlineCG", VALUELib.ValueType.F4, value.ToString())

                CheckValueForLog("RoughLine CG Readback", m_dblRoughLineCG_Readback, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ForeLineCG_Readback() As Double
            Get
                Return m_dblForeLineCG_Readback
            End Get
            Set(ByVal value As Double)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ForelineCG   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ForelineCG", VALUELib.ValueType.F4, value.ToString())

                CheckValueForLog("ForeLine CG Readback", m_dblForeLineCG_Readback, value, False)
            End Set
        End Property
        'Magnatron
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Magnatron_RotatingStatus() As WorkingStatuses
            Get
                Return m_Magnatron_RotatingStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Magnetron.RotationStatus    
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Magnetron.RotationStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Magnatron Rotating Status", m_Magnatron_RotatingStatus, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or set Magnatron Rotation Start Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Magnatron_RotationStartStatus() As WorkingStatuses
            Get
                Return m_Magnatron_RotationStartStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Magnatron Rotation Start Status", m_Magnatron_RotationStartStatus, value)
            End Set
        End Property
        ''Rough Pump
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property PVDRoughPumpStatus() As WorkingStatuses
            Get
                Return m_PVDRoughPumpStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.RoughPumpPowerOnOff   
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RoughPumpPowerOnOff", VALUELib.ValueType.U1, value)

                CheckValueForLog("PVD Rough Pump Status", m_PVDRoughPumpStatus, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RoughLineInUseStatus() As WorkingStatuses
            Get
                Return m_RoughLineInUseStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_RoughLineInUseStatus = value
                Dim OuterObj As Business.ChamberController = Business.ControllerManager.GetController(Me.Name)
                Dim objPvdController As Business.PVDController = CType(OuterObj.Myself, Business.PVDController)
                If (WorkingStatuses.Off = m_RoughLineInUseStatus) Then
                    objPvdController.ReleaseRoughLineInUse()
                ElseIf (WorkingStatuses.On = m_RoughLineInUseStatus) Then
                    objPvdController.MakeRoughLineInUse(False)
                End If
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set DC TargetPowerSupply Communication Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Shutter_ValveStatus() As WorkingStatuses
            Get
                Return m_Shutter_ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Shutter Valve Status", m_Shutter_ValveStatus, value)
            End Set
        End Property

        Public Property TargetWarning_KWH_Readback() As Double
            Get
                Return m_dblTargetWarning_KWH_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("TargetWarning_KWH_Readback", m_dblTargetWarning_KWH_Readback, value, False)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.TargetKWH.Warning
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TargetKWH.Warning", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        Public Property TargetLimit_KWH_Readback() As Double
            Get
                Return m_dblTargetLimit_KWH_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("TargetLimit_KWH_Readback", m_dblTargetLimit_KWH_Readback, value, False)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.TargetKWH.Limit
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TargetKWH.Limit", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        Public Property TargetMaterial() As String
            Get
                Return m_strTargetMaterial
            End Get
            Set(ByVal value As String)
                m_strTargetMaterial = value
                If value Is Nothing Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TargetMaterial", VALUELib.ValueType.A, String.Empty)
                Else
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TargetMaterial", VALUELib.ValueType.A, value.ToString())
                End If

            End Set
        End Property

        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2017-10-11 </date>
        ''' </author>
        ''' <summary>
        ''' ProcessCycleATMStart
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessCycleATMStart() As String
            Get
                Return m_strProcessCycleATMStart
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessCycleATMStart", m_strProcessCycleATMStart, value, False)
            End Set
        End Property
#End Region

        Protected Overrides Function ChangeProcessState(ByVal newState As ConstEnum.enumProcessStatus) As Boolean
            SyncLock m_objLockOnStatus
                If (ConstEnum.enumProcessStatus.eStart = newState) Then
                    If (Not IsProcessRunning) Then
                        IsProcessRunning = True
                    End If

                    ' Trigger SECS/GEM Event by Dat Cao
                    ' Var Name: PMX.ProcessingStarted
                    If (m_RunProcessStatus = enumProcessStatus.eStop) Then
                        Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessingStarted")
                    End If

                    ' Trigger SECS/GEM Event by Dat Vo
                    ' Var Name: PMX.ProcessingResumed
                    If (m_RunProcessStatus = enumProcessStatus.ePause) Then
                        If (Not IsAbortInProcess) Then
                            Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessingResumed")
                        End If
                    End If

                    m_RunProcessStatus = ConstEnum.enumProcessStatus.eStart
                    RunProcessResult = EnumRunProcessResult.Running
                    Utils.SetPMStatus(EnumChamberState.RUNNING.ToString(), Me.Name) ' Update status to RUNNING
                    Return True
                End If
                If (ConstEnum.enumProcessStatus.eStop = newState) Then
                    If (m_RunProcessStatus = enumProcessStatus.ePause) OrElse (m_RunProcessStatus = enumProcessStatus.eStart) Then

                        ' Trigger SECS/GEM Event by Dat Cao
                        ' Var Name: PMX.ProcessCompleted
                        If (IsAbortInProcess) Then
                            Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessingAborted")
                        Else
                            Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessCompleted")
                        End If

                        IsProcessRunning = False
                        RunProcessResult = EnumRunProcessResult.ProcessingCompleted
                        Utils.SetPMStatus(EnumChamberState.WAITING_UNLOAD.ToString().Replace("_", " "), Me.Name) ' Update status to WAITING UNLOAD
                        Utils.SetPM_IncreaseWaferCount(Me.Name)
                    End If
                    If (RunProcessResult = EnumRunProcessResult.Starting) Then
                        If IsAlarmReceivedDuringRunProcess Then
                            IsProcessRunning = False
                            RunProcessResult = EnumRunProcessResult.CouldNotStart

                            ' Trigger SECS/GEM Event by Dat Cao
                            ' Var Name: PMX.ProcessingAborted
                            Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessingAborted")

                            Utils.SetPMStatus(EnumChamberState.ERRORS.ToString(), Me.Name) ' Update status to ERROR(s)
                        End If
                    End If
                    If (RunProcessResult = EnumRunProcessResult.Aborting) Then
                        IsProcessRunning = False
                        RunProcessResult = EnumRunProcessResult.AbortedByUser

                        ' Trigger SECS/GEM Event by Dat Cao
                        ' Var Name: PMX.ProcessingAborted
                        Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessingAborted")

                        Utils.SetPMStatus(EnumChamberState.ERRORS.ToString(), Me.Name) ' Update status to ERROR(s)
                    End If
                    If (RunProcessResult = EnumRunProcessResult.Resuming) Then
                        IsProcessRunning = False
                        RunProcessResult = EnumRunProcessResult.ProcessingCompleted

                        ' Trigger SECS/GEM Event by Dat Cao
                        ' Var Name: PMX.ProcessingAborted
                        Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessCompleted")

                        Utils.SetPMStatus(EnumChamberState.WAITING_UNLOAD.ToString(), Me.Name) ' Update status to WAITING UNLOAD
                    End If
                    ' Missed Event Happens'''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If (ConstEnum.enumProcessStatus.eStop = m_RunProcessStatus) AndAlso (EnumRunProcessResult.Running = RunProcessResult) Then
                        IsProcessRunning = False
                        RunProcessResult = EnumRunProcessResult.ProcessingCompleted

                        ' Trigger SECS/GEM Event by Dat Cao
                        ' Var Name: PMX.ProcessingAborted
                        Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessCompleted")

                        Utils.SetPMStatus(EnumChamberState.WAITING_UNLOAD.ToString().Replace("_", " "), Me.Name) ' Update status to WAITING UNLOAD
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If (m_RunProcessStatus <> ConstEnum.enumProcessStatus.eStop) Then
                        m_RunProcessStatus = ConstEnum.enumProcessStatus.eStop
                        IsProcessRunning = False
                    End If
                    Return True

                ElseIf (ConstEnum.enumProcessStatus.ePause = newState) Then

                    ' Trigger SECS/GEM Event by Dat Cao
                    ' Var Name: PMX.ProcessingPaused
                    If (m_RunProcessStatus <> enumProcessStatus.ePause) Then
                        Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessingPaused")
                    End If

                    m_RunProcessStatus = ConstEnum.enumProcessStatus.ePause
                    If IsPauseInProcess Then ' Paused by User
                        RunProcessResult = EnumRunProcessResult.PausedByUser
                    Else
                        RunProcessResult = EnumRunProcessResult.AlarmHappennedDuringProcessing
                        Utils.SetPMStatus(EnumChamberState.ERRORS.ToString(), Me.Name) ' Update status to ERROR(s)
                    End If
                    Return True
                End If
                Return False
            End SyncLock
        End Function

        Protected Overrides Sub ProcessReceivedAlarm(ByVal alarmContent As String)
            ProcessReceivedAlarmCX(alarmContent)
        End Sub

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
            Try
                MyBase.UpdateVariableForGemWhenInit()
                Me.Magnatron_RotatingStatus = Magnatron_RotatingStatus
                Me.ParallelMagnetStatus = ParallelMagnetStatus
                Me.HivacValveStatus = HivacValveStatus
                Me.MachineFastRegen_Status = MachineFastRegen_Status
                Me.ShutterStatus = ShutterStatus
                Me.Baratron_CG_Program = Baratron_CG_Program
                Me.ForeLineCG_Readback = ForeLineCG_Readback
                Me.TargetMaterial = TargetMaterial

                Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.Name)
                If objChamber IsNot Nothing Then
                    objChamber.Alarm_KWH = objChamber.Alarm_KWH
                    objChamber.Warning_KWH = objChamber.Warning_KWH
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub


        Private Sub CheckingKWH(ByVal KWH_Readback As Double)
            Try
                Dim newWarning_KWH As Double
                Dim newAlarm_KWH As Double
                If IsUseMaxLimit Then
                    newWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH - m_objChamberModule.Max_KWH_Source)
                    newAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH - m_objChamberModule.Max_KWH_Source)
                Else
                    newWarning_KWH = m_objChamberModule.Warning_KWH
                    newAlarm_KWH = m_objChamberModule.Alarm_KWH
                End If
                If (KWH_Readback < newAlarm_KWH) Then
                    m_blnShowLimitKWH = False
                End If
                If (KWH_Readback < newWarning_KWH) Then
                    m_blnShowWarningKWH = False
                End If
                ''if KWH > Limit -> show alarm
                If (KWH_Readback >= newAlarm_KWH) And m_blnShowLimitKWH = False Then
                    Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.Name) + ": " & _
                                                       String.Format("Target KWH Usage Is Over The Limit ({0})", _
                                                                   newAlarm_KWH))
                    m_blnShowLimitKWH = True
                    ''if KWH > Warning and not show Limit Alarm before -> show
                ElseIf (KWH_Readback >= newWarning_KWH) And m_blnShowWarningKWH = False And m_blnShowLimitKWH = False Then
                    Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.Name) + ": " & _
                           String.Format("Target KWH Usage Is Over The Warning ({0})", _
                                         newWarning_KWH))
                    m_blnShowWarningKWH = True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

#Region "Throw Alarm"
        Protected Sub ThrowAlarm(ByVal strMessage As String)
            Dim strGemAlarmName = Utils.GemGetAlarmName(Me.Name)
            Utils.ThrowAlarm(strMessage, strGemAlarmName)
        End Sub
#End Region
    End Class

End Namespace