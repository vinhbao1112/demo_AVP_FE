Imports System.Threading
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum

Namespace DataManagerment
    Public Class IBEChamber
        Inherits Chamber

#Region "Class Constants & Variables"
        Private m_ACPower_readback As WorkingStatuses
        Private m_RFPower_readback As WorkingStatuses
        Private m_PBNPower_readback As WorkingStatuses
        Private m_GridPower_readback As WorkingStatuses
        Private m_NeurPower_readback As WorkingStatuses
        Private m_SourceManual_Auto_readback As WorkingStatuses
        Private m_Wafer_InFixture_Readback As WorkingStatuses
        Private m_Baratron_CG_ReadBack As Double
        Private m_Flowcool_Gas_readback As WorkingStatuses
        Private m_Process_Gas_Readback As WorkingStatuses
        Private m_Ion_Beam_Readback As WorkingStatuses
        Private m_PBN_OK_Readback As WorkingStatuses
        Private m_RFPowerSupply_ReflectedPower_Program As Double
        Private m_BeamPowerSupply_Current_Program As Double
        Private m_SuppressorPowerSupply_Current_Program As Double
        Private m_BodyPowerSupply_KFactor_Program As Double
        Private m_BodyPowerSupply_KFactor_Readback As Double
        Private m_ANC_Probe_Voltage_Readback As Double
        Private m_ChamberInterlocks_PanelInterlock_Status As WorkingStatuses
        Private m_ChamberInterlocks_AirPressure_Status As WorkingStatuses
        Private m_ChamberInterlocks_FixtureRotation_Status As WorkingStatuses

        Private m_Cryo_Pump_TempertureT1 As Double
        Private m_Cryo_Pump_TempertureT2 As Double
        Private m_dblEtchRate As Double = 1
        Private m_strGridSerialNumber As String
        Private m_strGridID As String
        Private m_intGridRebuildLevel As Integer
        Private m_Ramping_Percent_Turbo As String = String.Empty

        '<!-- RFPowerSupply-->
        Private m_RFPowerSupply_ForwardPower_Readback As Double
        Private m_RFPowerSupply_ReflectedPower As Double
        Private m_RFPowerSupply_Voltage As Double
        Private m_RFPowerSupply_ForwardPower_Program As Double

        '<!-- BeamPowerSupply-->
        Private m_BeamPowerSupply_Current_Readback As Double
        Private m_BeamPowerSupply_Voltage_Readback As Double
        Private m_BeamPowerSupply_Voltage_Program As Double
        Private m_BeamPowerSupply_AutoBeam As WorkingStatuses

        '<!-- SuppressorPowerSupply-->
        Private m_SuppressorPowerSupply_Current As Double
        Private m_SuppressorPowerSupply_Power_Readback As Double
        Private m_SuppressorPowerSupply_Voltage_Readback As Double
        Private m_SuppressorPowerSupply_Power_Program As Double
        Private m_SuppressorPowerSupply_Voltage_Program As Double

        '<!-- DischargePowerSupply-->
        Private m_DischargePowerSupply_Current_Readback As Double
        Private m_DischargePowerSupply_Voltage_Readback As Double
        Private m_DischargePowerSupply_Current_Program As Double
        Private m_DischargePowerSupply_Voltage_Program As Double

        '<!-- BodyPowerSupply-->
        Private m_BodyPowerSupply_Current_Readback As Double
        Private m_BodyPowerSupply_Voltage_Readback As Double
        Private m_BodyPowerSupply_Current_Program As Double
        Private m_BodyPowerSupply_Voltage_Program As Double

        '<!-- CGCFLCG-->
        Private m_CGCFLCG_Information As Double
        Private m_EnableForelineCGATM As WorkingStatuses
        Private m_SwitchIGFilament As Double
        Private m_EnableIGFilament As String = "1"

        '<!-- CGCRLCG-->
        Private m_CGCRLCG_Information As Double
        Private m_EnableRoughCGATM As WorkingStatuses
        '<!-- CGCMG-->
        Private m_CGCMG_Information As Double
        Private m_MPCG_RelayIndicatorStatus As WorkingStatuses
        Private m_MP_Communicating As WorkingStatuses = WorkingStatuses.On
        Private m_TurboForeline_Communicating As WorkingStatuses = WorkingStatuses.On
        Private m_EnablePressureCGATM As WorkingStatuses
        Private m_EnablePressureCGVAC As WorkingStatuses
        '<!-- BaCenterControl-->
        Private m_dblBaratron As Double

        Private m_Baratron_CG_Program As Double

        '<!-- Fixture-->
        Private m_FixtureFlowCoolPumpStatus As WorkingStatuses
        Private m_FixtureWaterValveStatus As WorkingStatuses
        Private m_FixtureTiltHomeStatus As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        Private m_FixtureRotationHomeStatus As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        Private m_FixtureErrorStatus As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        Private m_FixtureRotationErrorStatus As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        Private m_strFixture_Rotation_Mode_Readback As String
        Private m_FixtureRotationMovingStatus As WorkingStatuses
        Private m_strFixture_Encoder_Error_Status_Readback As String
        Private m_strShutterDirection As String

        '-------------------This code below seems redundant---
        Private m_FixtureHomeAllAxis As WorkingStatuses
        Private m_FixtureHomeRotationAxis As WorkingStatuses
        Private m_FixtureHomeTiltAxis As WorkingStatuses
        Private m_FixtureStartRotationAxis As WorkingStatuses
        Private m_FixtureStopAllAxis As WorkingStatuses
        Private m_FixtureUnClamp As WorkingStatuses
        '-----------------------------------------------------
        '<!-- Menu Status -->
        Private m_PumpDownStatus As WorkingStatuses
        Private m_VentStatus As WorkingStatuses
        Private m_CryoPumpStatus As WorkingStatuses
        Private m_TurboPumpStatus As WorkingStatuses
        Private m_RoughPumpStatus As WorkingStatuses
        Private m_CryoPumpRegenStatus As WorkingStatuses
        Private m_CryoAutoRegenStatus As WorkingStatuses
        Private m_PumpPurgeStatus As WorkingStatuses
        Private m_IGDegasStatus As WorkingStatuses

        Private m_strCryo_P_Command As String
        'Fixture Control
        '<!-- FixtureControlSweep-->
        Private m_SweepFixture_Rotation_Start_Readback As Double
        Private m_SweepFixture_Rotation_Start_Program As Double
        Private m_SweepFixture_Rotation_End_Program As Double

        Private m_FixtureControlSweep_Tilt_Status As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        Private m_FixtureControlSweep_Rotation_Status As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        Private m_FixtureControlSweep_Error_Status As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE

        '<!-- FixtureControlStatic-->
        Private m_StaticFixture_Rotation_Readback As Double
        Private m_StaticFixture_Rotation_Program As Double
        Private m_FixtureControlStatic_Tilt_Status As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        Private m_FixtureControlStatic_Rotation_Status As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        Private m_FixtureControlStatic_Error_Status As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE

        '<!-- FixtureControlContinuous-->
        Private m_ContinuousFixture_Rotation_Readback As Double
        Private m_ContinuousFixture_Rotation_Program As Double
        Private m_FixtureControlContinuous_Tilt_Status As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        Private m_FixtureControlContinuous_Rotation_Status As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        Private m_FixtureControlContinuous_Error_Status As DEVICE_STATUS = DEVICE_STATUS.STATUS_INACTIVE
        ''
        Private m_Home_Tilt_Readback As WorkingStatuses
        Private m_Home_Rotation_Readback As WorkingStatuses
        Private m_Start_Rotation_Readback As WorkingStatuses
        Private m_Fixture_Initialize_Motion_Readback As WorkingStatuses
        Private m_Initializing_Motion_readback As WorkingStatuses
        Private m_Fixture_TiltAngle_Readback As Double
        Private m_Fixture_TiltAngle_Program As Double
        Private m_TiltAtAngleSensor As WorkingStatuses
        Private m_Fixture_TiltStartAngle_Program As Double
        Private m_Fixture_TiltEndAngle_Program As Double
        Private m_Fixture_Tilt_Mode As Double
        Private m_Fixture_Tilt_Sweeping As WorkingStatuses

        Private m_Fixture_Cooling_Water_Readback As Double
        Private m_Fixture_Unprotected_Readback As WorkingStatuses
        '<!-- GasController-->
        Private m_GasController_Argon_Readback As Double
        'Private m_GasController_Gas1_Readback As Double
        'Private m_GasController_Gas2_Readback As Double
        'Private m_GasController_Gas3_Readback As Double
        'Private m_GasController_Gas4_Readback As Double
        'Private m_GasController_Gas5_Readback As Double

        Private m_GasController_FlowCoolHe_Readback As Double
        Private m_GasController_PBN_Readback As Double

        Private m_GasController_Argon_Program As Double
        'Private m_GasController_Gas1_Program As Double
        'Private m_GasController_Gas2_Program As Double
        'Private m_GasController_Gas3_Program As Double
        'Private m_GasController_Gas4_Program As Double
        'Private m_GasController_Gas5_Program As Double


        Private m_GasController_FlowCoolHe_Program As Double
        Private m_GasController_PBN_Program As Double

        '<!-- ProcessMonitor-->
        Private m_ProcessMonitor_FixtureAngle As Double
        Private m_ProcessMonitor_FixtureRotation As Double
        Private m_ProcessMonitor_ProcessStep As String = String.Empty
        Private m_ProcessMonitor_TotalStep As String
        Private m_ProcessMonitor_ProcessTime As String
        Private m_strProcessMonitor_Status_Readback As String
        Private m_EPDRecipe As String = String.Empty

        Private m_ProcessControl_GetRunDataFileName As WorkingStatuses = WorkingStatuses.Unknown

        '<!-- Chamber3Panel_Valve-->
        Private m_ArgonValveStatus As WorkingStatuses
        'Private m_Gas1ValveStatus As WorkingStatuses
        'Private m_Gas2ValveStatus As WorkingStatuses
        'Private m_Gas3ValveStatus As WorkingStatuses
        'Private m_Gas4ValveStatus As WorkingStatuses
        'Private m_Gas5ValveStatus As WorkingStatuses


        Private m_BaratronValveStatus As WorkingStatuses
        Private m_FlowCoolHeValveStatus As WorkingStatuses
        Private m_FlowCoolGasStatus As WorkingStatuses
        Private m_ForelineValveStatus As WorkingStatuses
        Private m_PBNValveStatus As WorkingStatuses


        Private m_HivacValveStatus As WorkingStatuses
        ''new feature
        Private m_TurboPowerStatus As WorkingStatuses
        Private m_SupplyArgonStatus As WorkingStatuses
        'Private m_SupplyGas1Status As WorkingStatuses
        'Private m_SupplyGas2Status As WorkingStatuses
        'Private m_SupplyGas3Status As WorkingStatuses
        'Private m_SupplyGas4Status As WorkingStatuses
        'Private m_SupplyGas5Status As WorkingStatuses


        Private m_SupplyOxygenStatus As WorkingStatuses
        Private m_SupplyFlowCoolHeStatus As WorkingStatuses
        Private m_CryoPumpGateStatus As WorkingStatuses
        Private m_ShutterPositionStatus As WorkingStatuses
        Private m_SupplyPBNStatus As WorkingStatuses
        Private m_InternalShutterStatus As WorkingStatuses
        Private m_InternalShutterOffStatus As WorkingStatuses
        '<!-- ChamberInterlocks-->
        Private m_ChamberInterlocks_ChamberPress As WorkingStatuses
        Private m_ChamberInterlocks_FixtureWater As WorkingStatuses
        Private m_ChamberInterlocks_FixtureWaterBug As WorkingStatuses
        Private m_ChamberInterlocks_Foreline As WorkingStatuses
        Private m_ChamberInterlocks_MagnetWater As WorkingStatuses
        Private m_ChamberInterlocks_SourceWater As WorkingStatuses
        Private m_ChamberInterlocks_Target As WorkingStatuses
        Private m_ChamberInterlocks_TurboWater As WorkingStatuses

        '<!-- Machine tool,  old system have not 3 items such as: Cryo On, Cryo Regen, Cryo Hivac-->
        Private m_MachineOnline As WorkingStatuses
        Private m_MachinePumbDown As WorkingStatuses
        Private m_MachineVent As WorkingStatuses
        Private m_CryoCommmunicateStateReadBack As WorkingStatuses
        Private m_CryoLastFullRegenReadBack As Double
        Private m_CryoElapsedTimeReadBack As Double

        '<!-- Source Usage-->
        Private m_SourceUsageTimeCurrent As Double = 0
        Private m_SourceUsageTimeWarning As Double = 0
        Private m_SourceUsageTimeLimit As Double = 0
        Private m_PBNTimeCurrent As Double = 0
        Public m_lLastTickCountCalculateSourceMinutes As Int64 = Environment.TickCount
        '<!-- Run recipe-->
        '     Private m_strProcessMonitor_DeviceStart_Readback As String = String.Empty
        '      Private m_strProcessMonitor_DeviceStop_Readback As String = String.Empty
        '       Private m_strProcessMonitor_DevicePause_Readback As String = String.Empty
        'Private m_strProcessMonitor_DeviceContinue_Readback As String = String.Empty
        '        Private m_strProcessMonitor_DeviceError_Readback As String = String.Empty
        Private m_blnStateMachineCompleted As Boolean = False
        ''
        Private m_objChamberModule As SystemModule = Nothing
        Private m_blnShowWarningKWH As Boolean = False
        Private m_blnShowLimitKWH As Boolean = False
        Private m_blnIsAutoPumpdownRunning As Boolean = False

        ' Chiller
        Private m_ChillerCommunication As WorkingStatuses = WorkingStatuses.Unknown
        Private m_dChillerTemperatureReadback As Double = 0
        Private m_ChillerFlowRateReadBack As Double = 0
        Private m_dChillerTemperatureSP As Double = 0
        Private m_dChillerStateReadback As WorkingStatuses
        Private m_dChillerProcessTemperatureMax As Double = 0
        Private m_dChillerVentTemperatureMax As Double = 0
        Private m_dChillerVentTemperatureMin As Double = 0
        Private m_dChillerProcessTemperatureMin As Double = 0

        ' Usage counter
        Private m_CoverFixtureShieldUsageReadback As Double = 0
        Private m_WaferClampUsageReadback As Double = 0
        Private m_TopFixtureShieldUsageReadback As Double = 0
        Private m_ShutterUsageReadback As Double = 0
        Private m_LinerSourceUsageReadback As Double = 0
        Private m_CryoUsageReadback As Double = 0
        Private m_FixtureRotationMotorUsageReadback As Double = 0
        Private m_WaterJournalReadback As Double = 0

        '' Source EM
        Private m_dSourceEMCurrentRB As Double = 0
        Private m_dSourceEMCurrentSP As Double = 0
        Private m_dSourceEMVoltageRB As Double = 0
        Private m_SourceEMCommunicationStatus As WorkingStatuses = WorkingStatuses.Unknown

        ' Hidden
        Private m_strHiddenName As String = String.Empty
        Private m_strHiddenData As String = String.Empty
        Private m_strHidenParams As String = String.Empty
        Private m_strHidenEnvironment As String = String.Empty
        Private Const DATA_SEPARATOR As Char = Chr(9)
        Private Const VERTICAL_TAB As Char = Chr(11)
        Private Const CARRIAGE_RETURN As Char = Chr(13)
        Private Const MAX_HIDDEN_DATA As Integer = 100

        Private m_IGIsolationValveStatus As WorkingStatuses
        Private m_DiverterValveStatus As WorkingStatuses
#End Region

#Region "Properties"
        ''' <author>
        '''   	<name> Dy Do </name>
        '''   	<date> 2019-03-05</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set IGIsolation Valve Status.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property IGIsolationValveStatus() As WorkingStatuses
            Get
                Return m_IGIsolationValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("IGIsolation Valve Status", m_IGIsolationValveStatus, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "IGIsolationValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Dy Do </name>
        '''   	<date> 2019-03-05</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set Diverter Valve Status.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DiverterValveStatus() As WorkingStatuses
            Get
                Return m_DiverterValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Diverter Valve Status", m_DiverterValveStatus, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DiverterValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Property Etch_Rate() As Double
            Get
                Return m_dblEtchRate
            End Get
            Set(ByVal value As Double)
                m_dblEtchRate = value
            End Set
        End Property

        Public Overrides Property IG() As Double
            Get
                Return MyBase.IG
            End Get
            Set(ByVal value As Double)
                MyBase.IG = value
                If value > 0 Then
                    IGStatus = WorkingStatuses.On

                    ' Update SECS/GEM variables by Dat Vo
                    ' Var Name: PMx.ChamberPressure
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ChamberPressure", VALUELib.ValueType.F4, value.ToString())
                Else
                    IGStatus = WorkingStatuses.Off
                End If

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.IonGaugeStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "IonGaugeStatus", VALUELib.ValueType.U1, IGStatus)

            End Set
        End Property

        Public Property IsAutoPumpdownRunning() As Boolean
            Get
                Return m_blnIsAutoPumpdownRunning
            End Get
            Set(ByVal value As Boolean)
                m_blnIsAutoPumpdownRunning = value
            End Set
        End Property

        Public Property ShutterDirection() As String
            Get
                Return m_strShutterDirection
            End Get
            Set(ByVal value As String)
                m_strShutterDirection = value
            End Set
        End Property

        Public Property GridSerialNumber() As String
            Get
                Return m_strGridSerialNumber
            End Get
            Set(ByVal value As String)
                m_strGridSerialNumber = value
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GridSerialNumber", VALUELib.ValueType.A, value)
            End Set
        End Property

        Public Property GridID() As String
            Get
                Return m_strGridID
            End Get
            Set(ByVal value As String)
                m_strGridID = value
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GridID", VALUELib.ValueType.A, value)
            End Set
        End Property

        Public Property GridRebuildLevel() As Integer
            Get
                Return m_intGridRebuildLevel
            End Get
            Set(ByVal value As Integer)
                m_intGridRebuildLevel = value
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GridRebuildLevel", VALUELib.ValueType.F4, value)
            End Set
        End Property

#Region "Chiller"
        ''' <author>
        '''   	<name> Dy Do </name>
        '''   	<date> 2016-02-23</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set ChillerTemperatureReadback.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChillerFlowRateReadBack() As Double
            Get
                Return m_ChillerFlowRateReadBack
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ChillerFlowRateReadBack", m_ChillerFlowRateReadBack, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ChillerFlowRateRB", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property
        ''' <author>
        '''   	<name> Hoa Nguyen </name>
        '''   	<date> 2012-03-27</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set ChillerTemperatureReadback.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChillerTemperatureReadback() As Double
            Get
                Return m_dChillerTemperatureReadback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ChillerTemperatureReadback", m_dChillerTemperatureReadback, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ChillerTemperatureRB", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''   	<name> Hoa Nguyen </name>
        '''   	<date> 2012-03-27</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set ChillerTemperatureSP.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChillerTemperatureSP() As Double
            Get
                Return m_dChillerTemperatureSP
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ChillerTemperatureSP", m_dChillerTemperatureSP, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ChillerTemperatureSP", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''   	<name> Hoa Nguyen </name>
        '''   	<date> 2012-03-27</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set ChillerStateReadback.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChillerStateReadback() As Double
            Get
                Return m_dChillerStateReadback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ChillerStateReadback", m_dChillerStateReadback, value)
            End Set
        End Property

        ''' <author>
        '''   	<name>Tri Do</name>
        '''   	<date>2014-09-16</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set ChillerCommunication.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChillerCommunication() As WorkingStatuses
            Get
                Return m_ChillerCommunication
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ChillerCommunication", m_ChillerCommunication, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Hoa Nguyen </name>
        '''   	<date> 2012-03-27</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set ChillerProcessTemperatureMax.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChillerProcessTemperatureMax() As Double
            Get
                Return m_dChillerProcessTemperatureMax
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ChillerProcessTemperatureMax", m_dChillerProcessTemperatureMax, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Hoa Nguyen </name>
        '''   	<date> 2012-03-27</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set ChillerVentTemperatureMax.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChillerVentTemperatureMax() As Double
            Get
                Return m_dChillerVentTemperatureMax
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ChillerVentTemperatureMax", m_dChillerVentTemperatureMax, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Hoa Nguyen </name>
        '''   	<date> 2012-03-27</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set ChillerVentTemperatureMin.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChillerVentTemperatureMin() As Double
            Get
                Return m_dChillerVentTemperatureMin
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ChillerVentTemperatureMin", m_dChillerVentTemperatureMin, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Hoa Nguyen </name>
        '''   	<date> 2012-03-27</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set ChillerProcessTemperatureMin.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ChillerProcessTemperatureMin() As Double
            Get
                Return m_dChillerProcessTemperatureMin
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ChillerProcessTemperatureMin", m_dChillerProcessTemperatureMin, value)
            End Set
        End Property
#End Region


#Region "RFPowerSupply"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get RFPowerSupply_ForwardPower.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RFPowerSupply_ForwardPower_Readback() As Double
            Get
                Return m_RFPowerSupply_ForwardPower_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("RFPowerSupply_ForwardPower", m_RFPowerSupply_ForwardPower_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RFPowerPS.PowerReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFPowerPS.PowerReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get RFPowerSupply_ReflectedPower.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RFPowerSupply_ReflectedPower() As Double
            Get
                Return m_RFPowerSupply_ReflectedPower
            End Get
            Set(ByVal value As Double)
                CheckValueForLog(RFPowerSupply_ReflectedPower, m_RFPowerSupply_ReflectedPower, value)
                ' Update SECS/GEM variables by Hoa Nguyen
                ' Var Name: PMx.RFReflectedReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFReflectedReadback", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' RFPowerSupply_Voltage
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RFPowerSupply_Voltage() As Double
            Get
                Return m_RFPowerSupply_Voltage
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("RFPowerSupply_Voltage", m_RFPowerSupply_Voltage, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set RFPowerSupply_ForwardPower.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RFPowerSupply_ForwardPower_Program() As Double
            Get
                Return m_RFPowerSupply_ForwardPower_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("RFPowerSupply_ForwardPower", m_RFPowerSupply_ForwardPower_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RFPowerPS.PowerProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFPowerPS.PowerProgram", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
#End Region

#Region "BeamPowerSupply"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get the current value of Beam Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BeamPowerSupply_Current_Readback() As Double
            Get
                Return m_BeamPowerSupply_Current_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BeamPowerSupply_Current", m_BeamPowerSupply_Current_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.BeamPS.CurrentReadback --convert A->mA
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BeamPS.CurrentReadback", VALUELib.ValueType.F4, (value).ToString())
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BeamPS.CurrentReadbackMiliAmp", VALUELib.ValueType.F4, (value * 1000).ToString())
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Voltage of Beam Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BeamPowerSupply_Voltage_Readback() As Double
            Get
                Return m_BeamPowerSupply_Voltage_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BeamPowerSupply_Voltage", m_BeamPowerSupply_Voltage_Readback, value)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.BeamPS.VoltageReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BeamPS.VoltageReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set Voltage of Beam Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BeamPowerSupply_Voltage_Program() As Double
            Get
                Return m_BeamPowerSupply_Voltage_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BeamPowerSupply_Voltage", m_BeamPowerSupply_Voltage_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.BeamPS.VoltageProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BeamPS.VoltageProgram", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-09-016</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BeamPowerSupply_AutoBeam() As WorkingStatuses
            Get
                Return m_BeamPowerSupply_AutoBeam
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("BeamPowerSupply_AutoBeam", m_BeamPowerSupply_AutoBeam, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.AutoBeamRunningStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "AutoBeamRunningStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property

#End Region

#Region "SuppressorPowerSupply"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get SuppressorPowerSupply_Current.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SuppressorPowerSupply_Current_Readback() As Double
            Get
                Return m_SuppressorPowerSupply_Current
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SuppressorPowerSupply_Current", m_SuppressorPowerSupply_Current, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.SuppressorPS.CurrentReadback--Convert A->mA
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SuppressorPS.CurrentReadback", VALUELib.ValueType.F4, (value).ToString())
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SuppressorPS.CurrentReadbackMiliAmp", VALUELib.ValueType.F4, (value * 1000).ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get SuppressorPowerSupply_Power.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SuppressorPowerSupply_Power_Readback() As Double
            Get
                Return m_SuppressorPowerSupply_Power_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SuppressorPowerSupply_Power", m_SuppressorPowerSupply_Power_Readback, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get SuppressorPowerSupply_Voltage.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SuppressorPowerSupply_Voltage_Readback() As Double
            Get
                Return m_SuppressorPowerSupply_Voltage_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SuppressorPowerSupply_Voltage", m_SuppressorPowerSupply_Voltage_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.SuppressorPS.VoltageReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SuppressorPS.VoltageReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set SuppressorPowerSupply_Power.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SuppressorPowerSupply_Power_Program() As Double
            Get
                Return m_SuppressorPowerSupply_Power_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SuppressorPowerSupply_Power", m_SuppressorPowerSupply_Power_Program, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set SuppressorPowerSupply_Voltage.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SuppressorPowerSupply_Voltage_Program() As Double
            Get
                Return m_SuppressorPowerSupply_Voltage_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SuppressorPowerSupply_Voltage", m_SuppressorPowerSupply_Voltage_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.SuppressorPS.VoltageProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SuppressorPS.VoltageProgram", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

#End Region

#Region "DischargePowerSupply"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get the current value of Discharge Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DischargePowerSupply_Current_Readback() As Double
            Get
                Return m_DischargePowerSupply_Current_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DischargePowerSupply_Current", m_DischargePowerSupply_Current_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PBNDisch
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PBNDischargeCurrent", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Voltage of Discharge Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DischargePowerSupply_Voltage_Readback() As Double
            Get
                Return m_DischargePowerSupply_Voltage_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DischargePowerSupply_Voltage", m_DischargePowerSupply_Voltage_Readback, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PBNDischargeVoltage", VALUELib.ValueType.F4, (value).ToString())
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set the current value of Discharge Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DischargePowerSupply_Current_Program() As Double
            Get
                Return m_DischargePowerSupply_Current_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DischargePowerSupply_Current", m_DischargePowerSupply_Current_Program, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set Voltage of Discharge Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DischargePowerSupply_Voltage_Program() As Double
            Get
                Return m_DischargePowerSupply_Voltage_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DischargePowerSupply_Voltage", m_DischargePowerSupply_Voltage_Program, value)
            End Set
        End Property

#End Region

#Region "BodyPowerSupply"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get the current value of Body Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BodyPowerSupply_Current_Readback() As Double
            Get
                Return m_BodyPowerSupply_Current_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BodyPowerSupply_Current", m_BodyPowerSupply_Current_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PBNBody--convert A->mA
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PBNBodyCurrent", VALUELib.ValueType.F4, (value).ToString())

            End Set
        End Property

        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the Flowcool_Gas_readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Flowcool_Gas_readback() As WorkingStatuses
            Get
                Return m_Flowcool_Gas_readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Flowcool_Gas", m_Flowcool_Gas_readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.FlowCoolGasOnStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FlowCoolGasOnStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the Process_Gas_Readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Process_Gas_Readback() As WorkingStatuses
            Get
                Return m_Process_Gas_Readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Process_Gas", m_Process_Gas_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.ProcessGasOnStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessGasOnStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the Ion_Beam_Readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Ion_Beam_Readback() As WorkingStatuses
            Get
                Return m_Ion_Beam_Readback
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Trigger SECS/GEM Event by Dat Cao
                ' Var Name: PMX.PlasmaOn/PlasmaOff      
                If (value = WorkingStatuses.On And m_Ion_Beam_Readback <> WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.MySecsGemObj.TriggerEvent(Me.Name, "PlasmaOn")
                ElseIf (value = WorkingStatuses.Off And m_Ion_Beam_Readback <> WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.MySecsGemObj.TriggerEvent(Me.Name, "PlasmaOff")
                End If

                CheckValueForLog("Ion_Beam", m_Ion_Beam_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.IonBeamOnStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "IonBeamOnStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the PBN_OK_Readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PBN_OK_Readback() As WorkingStatuses
            Get
                Return m_PBN_OK_Readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("PBN_OK", m_PBN_OK_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PBNOnStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PBNOnStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the RFPowerSupply_ReflectedPower_Program
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RFPowerSupply_ReflectedPower_Program() As Double
            Get
                Return m_RFPowerSupply_ReflectedPower_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("RFPowerSupply_ReflectedPower", m_RFPowerSupply_ReflectedPower_Program, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the BeamPowerSupply_Current_Program
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BeamPowerSupply_Current_Program() As Double
            Get
                Return m_BeamPowerSupply_Current_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BeamPowerSupply_Current", m_BeamPowerSupply_Current_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.BeamPS.CurrentProgram-->convert A->mA
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BeamPS.CurrentProgram", VALUELib.ValueType.F4, (value).ToString())
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BeamPS.CurrentProgramMiliAmp", VALUELib.ValueType.F4, (value * 1000).ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the SuppressorPowerSupply_Current_Program
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SuppressorPowerSupply_Current_Program() As Double
            Get
                Return m_SuppressorPowerSupply_Current_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SuppressorPowerSupply_Current", m_SuppressorPowerSupply_Current_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.SuppressorPS.CurrentProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SuppressorPS.CurrentProgram", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the Wafer_InFixture_Readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Wafer_InFixture_Readback() As WorkingStatuses
            Get
                Return m_Wafer_InFixture_Readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Wafer_InFixture", m_Wafer_InFixture_Readback, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the BodyPowerSupply_KFactor_Program
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BodyPowerSupply_KFactor_Program() As Double
            Get
                Return m_BodyPowerSupply_KFactor_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BodyPowerSupply_KFactor", m_BodyPowerSupply_KFactor_Program, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the BodyPowerSupply_KFactor_Readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BodyPowerSupply_KFactor_Readback() As Double
            Get
                Return m_BodyPowerSupply_KFactor_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BodyPowerSupply_KFactor", m_BodyPowerSupply_KFactor_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.KFactorReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "KFactorReadback", VALUELib.ValueType.F4, value.ToString())

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.KFactorProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "KFactorProgram", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''   	<name> Dy Do </name>
        '''   	<date> 2015-10-31</date>
        ''' </author>
        ''' <summary>
        ''' Get the ANC_Probe_Voltage_Readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ANC_Probe_Voltage_Readback() As Double
            Get
                Return m_ANC_Probe_Voltage_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ANC_Probe_Voltage_Readback", m_ANC_Probe_Voltage_Readback, value)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.KFactorReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ANCProbeVoltageReadback", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property


        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the ChamberInterlocks_PanelInterlock_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_PanelInterlock_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_PanelInterlock_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Interlocks.PanelInterlock
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.PanelInterlock", VALUELib.ValueType.U1, value)

                'Alarm Set/Clear by Dat Cao
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_PanelInterlock_Status = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "PanelInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_PanelInterlock_Status = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "PanelInterlock", "Panel Interlock Alarm")
                End If

                CheckValueForLog("ChamberInterlocks_PanelInterlock", m_ChamberInterlocks_PanelInterlock_Status, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the ChamberInterlocks_AirPressure_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_AirPressure_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_AirPressure_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Interlocks.AirPressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.AirPressure", VALUELib.ValueType.U1, value)

                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_AirPressure_Status = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "AirPressureInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_AirPressure_Status = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "AirPressureInterlock", "Air Pressure Interlock Tripped")
                End If

                CheckValueForLog("ChamberInterlocks_AirPressure", m_ChamberInterlocks_AirPressure_Status, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the ChamberInterlocks_FixtureRotation_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_FixtureRotation_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_FixtureRotation_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ChamberInterlocks_FixtureRotation", m_ChamberInterlocks_FixtureRotation_Status, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RotatingStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotatingStatus", VALUELib.ValueType.U1, value)

                'Alarm Set/Clear by Dat Cao
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_FixtureRotation_Status = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "FixtureRotationInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_FixtureRotation_Status = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "FixtureRotationInterlock", "Fixture Rotation Interlock Tripped")
                End If
            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the Cryo_Pump_Temperture
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Cryo_Pump_Temperture_T1() As Double
            Get
                Return m_Cryo_Pump_TempertureT1
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Cryo_Pump_Temperture_T1", m_Cryo_Pump_TempertureT1, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Cryo.SecondTemperature
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.SecondTemperature", VALUELib.ValueType.F4, value.ToString())
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaterPumpTemperature", VALUELib.ValueType.F4, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the Cryo_Pump_Temperture
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Cryo_Pump_Temperture_T2() As Double
            Get
                Return m_Cryo_Pump_TempertureT2
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Cryo_Pump_Temperture", m_Cryo_Pump_TempertureT2, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Cryo.SecondTemperature
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.SecondTemperature", VALUELib.ValueType.F4, value.ToString())
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaterPumpTemperature", VALUELib.ValueType.F4, value)

            End Set
        End Property

        ''' <author>
        '''   	<name> Dua Tran </name>
        '''   	<date> 2018-12-06</date>
        ''' </author>
        ''' <summary>
        ''' RampingPercentTurbo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RampingPercentTurbo() As String
            Get
                Return m_Ramping_Percent_Turbo
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Ramping_Percent_Turbo", m_Ramping_Percent_Turbo, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Voltage of Body Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BodyPowerSupply_Voltage_Readback() As Double
            Get
                Return m_BodyPowerSupply_Voltage_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BodyPowerSupply_Voltage", m_BodyPowerSupply_Voltage_Readback, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PBNBodyVoltage", VALUELib.ValueType.F4, (value).ToString())
            End Set
        End Property

        ''' <author>
        '''  	<name> Cao Anh Kiet </name>
        '''  	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set the current value of Body Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BodyPowerSupply_Current_Program() As Double
            Get
                Return m_BodyPowerSupply_Current_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BodyPowerSupply_Current", m_BodyPowerSupply_Current_Program, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set Voltage of Body Power Supply.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BodyPowerSupply_Voltage_Program() As Double
            Get
                Return m_BodyPowerSupply_Voltage_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("BodyPowerSupply_Voltage", m_BodyPowerSupply_Voltage_Program, value)
            End Set
        End Property
#End Region

#Region "CGCFLCG"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' CGCFLCG_Information.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CGCFLCG_Information() As Double
            Get
                Return m_CGCFLCG_Information
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("CGCFLCG_Information", m_CGCFLCG_Information, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.ForelinePiraniPressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ForelinePiraniPressure", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

        ''' <author>
        '''   	<name>Van Le</name>
        '''   	<date> 2014-08-22</date>
        ''' </author>
        ''' <summary>
        ''' EnableForelineCGATM.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EnableForelineCGATM() As WorkingStatuses
            Get
                Return m_EnableForelineCGATM
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("EnableForelineCGATM", m_EnableForelineCGATM, value)

            End Set
        End Property

#End Region

#Region "CGCRLCG"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' CGCRLCG_Information.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CGCRLCG_Information() As Double
            Get
                Return m_CGCRLCG_Information
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("CGCRLCG_Information", m_CGCRLCG_Information, value)

                If (IGStatus <> WorkingStatuses.On) Then
                    ' Update SECS/GEM variables by Dat Vo
                    ' Var Name: PMx.ChamberPressure
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ChamberPressure", VALUELib.ValueType.F4, value.ToString())
                End If

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RoughPiraniPressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RoughPiraniPressure", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
#End Region

#Region "CGCMG"
        ''' <author>
        '''    	<name>Truc Le</name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MPCG_RelayIndicatorStatus() As WorkingStatuses
            Get
                Return m_MPCG_RelayIndicatorStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_MPCG_RelayIndicatorStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name>Truc Le</name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get or set status connect/disconnect of MachanicalPump
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MP_Communicating() As WorkingStatuses
            Get
                Return m_MP_Communicating
            End Get
            Set(ByVal value As WorkingStatuses)
                m_MP_Communicating = value
            End Set
        End Property

        ''' <author>
        '''    	<name>Truc Le</name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get or set status connect/disconnect of TurboForeline
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TurboForeline_Communicating() As WorkingStatuses
            Get
                Return m_TurboForeline_Communicating
            End Get
            Set(ByVal value As WorkingStatuses)
                m_TurboForeline_Communicating = value
            End Set
        End Property

        ''' <author>
        '''   	<name>Van Le</name>
        '''   	<date> 2014-08-22</date>
        ''' </author>
        ''' <summary>
        ''' EnableRoughCGATM.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EnableRoughCGATM() As WorkingStatuses
            Get
                Return m_EnableRoughCGATM
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("EnableRoughCGATM", m_EnableRoughCGATM, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' CGCMG_Information.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CGCMG_Information() As Double
            Get
                Return m_CGCMG_Information
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("CGCMG_Information", m_CGCMG_Information, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.ManometerPressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ManometerPressure", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

        ''' <author>
        '''   	<name>Tinh Le</name>
        '''   	<date>2021-11-03</date>
        ''' </author>
        ''' <summary>
        ''' CGCMG_Communicating.
        ''' </summary>
        Private m_CGCMG_Communicating As WorkingStatuses = WorkingStatuses.On
        Public Property CGCMG_Communicating() As WorkingStatuses
            Get
                Return m_CGCMG_Communicating
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("CGCMG_Communicating", m_CGCMG_Communicating, value)
            End Set
        End Property
        ''' <author>
        '''   	<name>Van Le</name>
        '''   	<date> 2014-08-22</date>
        ''' </author>
        ''' <summary>
        ''' EnablePressureCGATM.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EnablePressureCGATM() As WorkingStatuses
            Get
                Return m_EnablePressureCGATM
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("EnablePressureCGATM", m_EnablePressureCGATM, value)

            End Set
        End Property


        ''' <author>
        '''   	<name>Van Le</name>
        '''   	<date> 2014-08-22</date>
        ''' </author>
        ''' <summary>
        ''' EnablePressureCGVAC.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EnablePressureCGVAC() As WorkingStatuses
            Get
                Return m_EnablePressureCGVAC
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("EnablePressureCGVAC", m_EnablePressureCGVAC, value)

            End Set
        End Property


        ''' <author>
        '''   	<name>Dua Tran</name>
        '''   	<date> 2017-08-25</date>
        ''' </author>
        ''' <summary>
        ''' SwitchIGFilament.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SwitchIGFilament() As Double
            Get
                Return m_SwitchIGFilament
            End Get
            Set(ByVal value As Double)
                m_SwitchIGFilament = value
                CheckValueForLog("SwitchIGFilament", m_SwitchIGFilament, value)

            End Set
        End Property


        ''' <author>
        '''   	<name>Dua Tran</name>
        '''   	<date> 2017-08-25</date>
        ''' </author>
        ''' <summary>
        ''' Enabel IGFilament.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EnableIGFilament() As String
            Get
                Return m_EnableIGFilament
            End Get
            Set(ByVal value As String)
                m_EnableIGFilament = value
                CheckValueForLog("m_EnableIGFilament", m_EnableIGFilament, value)

            End Set
        End Property

#End Region

#Region "Baratron Control"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Baratron Readback.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Baratron_ReadBack() As Double
            Get
                Return m_dblBaratron
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Baratron", m_dblBaratron, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set CG of IBE Chamber.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Baratron_CG_Program() As Double
            Get
                Return m_Baratron_CG_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Baratron_CG", m_Baratron_CG_Program, value)
            End Set
        End Property
#End Region

#Region "Fixure in Sweep Mode"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Rotation  in Sweep Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SweepFixture_Rotation_Start_Readback() As Double
            Get
                Return m_SweepFixture_Rotation_Start_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SweepFixture_Rotation_Start_Readback", m_SweepFixture_Rotation_Start_Readback, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Rotation  in Sweep Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SweepFixture_Rotation_Start_Program() As Double
            Get
                Return m_SweepFixture_Rotation_Start_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SweepFixture_Rotation_Start_Program", m_SweepFixture_Rotation_Start_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RotationSweepStartAngle
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotationSweepStartAngle", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set Rotation  in Sweep Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SweepFixture_Rotation_End_Program() As Double
            Get
                Return m_SweepFixture_Rotation_End_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SweepFixture_Rotation_End_Program", m_SweepFixture_Rotation_End_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RotationSweepEndAngle
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotationSweepEndAngle", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Tilt Angle Status in Sweep Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SweepFixture_Tilt_Status() As DEVICE_STATUS
            Get
                Return m_FixtureControlSweep_Tilt_Status
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("SweepFixture_TiltAngleStatus", m_FixtureControlSweep_Tilt_Status, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Tilt Rotation Status in Sweep Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SweepFixture_Rotation_Status() As DEVICE_STATUS
            Get
                Return m_FixtureControlSweep_Rotation_Status
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("SweepFixture_TiltRotationStatus", m_FixtureControlSweep_Rotation_Status, value)
            End Set
        End Property
#End Region

#Region "Fixure in Static Mode"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Rotation in Static Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StaticFixture_Rotation_Readback() As Double
            Get
                Return m_StaticFixture_Rotation_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("StaticFixture_Rotation_Readback", m_StaticFixture_Rotation_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RotationStaticAngleReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotationCurrentAngle", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''  	<name> Cao Anh Kiet </name>
        '''  	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Tilt Angle in Static Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StaticFixture_Rotation_Program() As Double
            Get
                Return m_StaticFixture_Rotation_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("StaticFixture_Rotation_Program", m_StaticFixture_Rotation_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RotationStaticAngleProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotationStaticAngle", VALUELib.ValueType.F4, value.ToString())
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotationStaticAngleReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Tilt Angle Status in Static Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>StaticFixture_Tilt_Status
        Public Property StaticFixture_Tilt_Status() As DEVICE_STATUS
            Get
                Return m_FixtureControlStatic_Tilt_Status
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("StaticFixture_TiltAngleStatus", m_FixtureControlStatic_Tilt_Status, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Tilt Rotation Status in Static Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StaticFixture_Rotation_Status() As DEVICE_STATUS
            Get
                Return m_FixtureControlStatic_Rotation_Status
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("StaticFixture_TiltRotationStatus", m_FixtureControlStatic_Rotation_Status, value)
            End Set
        End Property
#End Region

#Region "Fixure in Continuous Mode"
        'Truc Le add
        Public Property FixtureEncoderErrorStatus() As String
            Get
                Return m_strFixture_Encoder_Error_Status_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Fixture_Encoder_Error_Status_Readback", m_strFixture_Encoder_Error_Status_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Fixture_Encoder_Error_Status_Readback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FixtureEncoderError", VALUELib.ValueType.F4, Integer.Parse(value))

            End Set
        End Property
        ''' <author>
        '''  	<name> Huy Nguyen </name>
        '''  	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Rotation in Continuous Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ContinuousFixture_Rotation_Readback() As Double
            Get
                Return m_ContinuousFixture_Rotation_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ContinuousFixture_Rotation_Readback", m_ContinuousFixture_Rotation_Readback, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotationContinuousSpeedReadback", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property
        ''' <author>
        '''  	<name> Cao Anh Kiet </name>
        '''  	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get Tilt Angle in Continuous Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ContinuousFixture_Rotation_Program() As Double
            Get
                Return m_ContinuousFixture_Rotation_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ContinuousFixture_Rotation_Program", m_ContinuousFixture_Rotation_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RotationContinuousSpeed
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotationContinuousSpeed", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Status of Tilt Angle in Continuous Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ContinuousFixture_Tilt_Status() As DEVICE_STATUS
            Get
                Return m_FixtureControlContinuous_Tilt_Status
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("ContinuousFixture_TiltAngleStatus", m_FixtureControlContinuous_Tilt_Status, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Status of Tilt Rotation in Continuous Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ContinuousFixture_Rotation_Status() As DEVICE_STATUS
            Get
                Return m_FixtureControlContinuous_Rotation_Status
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("ContinuousFixture_TiltRotationStatus", m_FixtureControlContinuous_Rotation_Status, value)
            End Set
        End Property

#End Region

#Region "Fixture Status"
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set Rotation in Continuous Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Fixture_TiltAngle_Readback() As Double
            Get
                Return m_Fixture_TiltAngle_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Fixture_TiltAngle_Readback", m_Fixture_TiltAngle_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.TiltAngleReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TiltAngleReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set Rotation in Continuous Fixture mode.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Fixture_Cooling_Water_Readback() As Double
            Get
                Return m_Fixture_Cooling_Water_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Fixture_Cooling_Water_Readback", m_Fixture_Cooling_Water_Readback, value)
            End Set
        End Property

        Public Property Fixture_Unprotected_Readback() As WorkingStatuses
            Get
                Return m_Fixture_Unprotected_Readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Fixture_Unprotected_Readback", m_Fixture_Unprotected_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.OverrideModeOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "OverrideModeOnOff", VALUELib.ValueType.U1, value)

            End Set
        End Property

        Public Property Fixture_Rotation_Mode_Readback() As String
            Get
                Return m_strFixture_Rotation_Mode_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Fixture_Rotation_Mode_Readback", m_strFixture_Rotation_Mode_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Fixture_Rotation_Mode_Readback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotationMode", VALUELib.ValueType.A, value)

            End Set
        End Property


        Public Property Fixture_TiltAngle_Program() As Double
            Get
                Return m_Fixture_TiltAngle_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Fixture_TiltAngle_Program", m_Fixture_TiltAngle_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.TiltAngleProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TiltAngleProgram", VALUELib.ValueType.F4, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TiltAngleReadback", VALUELib.ValueType.F4, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Dua Tran </name>
        '''   	<date> 2017-04-12</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Fixture_TiltStartAngle_Program() As Double
            Get
                Return m_Fixture_TiltStartAngle_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("m_Fixture_TiltStartAngle_Program", m_Fixture_TiltStartAngle_Program, value)

                ' Update SECS/GEM variables by Dua Tran
                ' Var Name: PMx.TiltSweepStartAngel
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FixtureTiltStartAngleProgram", VALUELib.ValueType.F4, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Dua Tran </name>
        '''   	<date> 2017-04-12</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Fixture_TiltEndAngle_Program() As Double
            Get
                Return m_Fixture_TiltEndAngle_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("m_Fixture_TiltEndAngle_Program", m_Fixture_TiltEndAngle_Program, value)

                ' Update SECS/GEM variables by Dua Tran
                ' Var Name: PMx.TiltSweepEndAngel
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FixtureTiltEndAngleProgram", VALUELib.ValueType.F4, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Dua Tran </name>
        '''   	<date> 2017-04-17</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Fixture_Tilt_Mode() As Double
            Get
                Return m_Fixture_Tilt_Mode
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("m_Fixture_Tilt_Mode", m_Fixture_Tilt_Mode, value)

                ' Update SECS/GEM variables by Dua Tran
                ' Var Name: PMx.m_FixtureTiltMode
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FixtureTiltMode", VALUELib.ValueType.F4, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Dua Tran </name>
        '''   	<date> 2017-04-19</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Fixture_Tilt_Sweeping() As WorkingStatuses
            Get
                Return m_Fixture_Tilt_Sweeping
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("m_Fixture_Tilt_Sweeping", m_Fixture_Tilt_Sweeping, value)
            End Set
        End Property

        Public Property TiltAtAngleSensor() As WorkingStatuses
            Get
                Return m_TiltAtAngleSensor
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("TiltSensorStatus", m_TiltAtAngleSensor, value)

                ' Update SECS/GEM variables by Tin Pham
                ' Var Name: PMx.TiltSensorStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TiltSensorStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property

        Public Property Fixture_Home_Tilt_Readback() As WorkingStatuses
            Get
                Return m_Home_Tilt_Readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Fixture_Home_Tilt_Readback", m_Home_Tilt_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.TiltAngleProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TiltAngleProgram", VALUELib.ValueType.A, value.ToString())

            End Set
        End Property

        Public Property Fixture_Home_Rotation_Readback() As WorkingStatuses
            Get
                Return m_Home_Rotation_Readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Fixture_Home_Rotation_Readback", m_Home_Rotation_Readback, value)
            End Set
        End Property

        Public Property Fixture_Start_Rotation_Readback() As WorkingStatuses
            Get
                Return m_Start_Rotation_Readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Fixture_Start_Rotation_Readback", m_Start_Rotation_Readback, value)
            End Set
        End Property

        Public Property Fixture_Initialize_Motion_Readback() As WorkingStatuses
            Get
                Return m_Fixture_Initialize_Motion_Readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Fixture_Initialize_Motion_Readback", m_Fixture_Initialize_Motion_Readback, value)
            End Set
        End Property

        ''' <author>
        '''   	<name> Tran Ngoc Khiet </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the Initialize_Motion_readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Initializing_Motion_readback() As WorkingStatuses
            Get
                Return m_Initializing_Motion_readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Initialize_Motion", m_Initializing_Motion_readback, value)
            End Set
        End Property

#End Region

#Region "GasController"
        ''' <author>
        '''  	<name> Cao Anh Kiet </name>
        '''  	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get GasController_Argon.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GasController_Argon_Readback() As Double
            Get
                Return m_GasController_Argon_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("GasController_Argon", m_GasController_Argon_Readback, value)
            End Set
        End Property
        'Public Property GasController_Gas1_Readback() As Double
        '    Get
        '        Return m_GasController_Gas1_Readback
        '    End Get
        '    Set(ByVal value As Double)
        '        CheckValueForLog("GasController_Gas1", m_GasController_Gas1_Readback, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas1ChannelReadback
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1ChannelReadback", VALUELib.ValueType.F4, value.ToString())

        '    End Set
        'End Property
        'Public Property GasController_Gas2_Readback() As Double
        '    Get
        '        Return m_GasController_Gas2_Readback
        '    End Get
        '    Set(ByVal value As Double)
        '        CheckValueForLog("GasController_Gas2", m_GasController_Gas2_Readback, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas2ChannelReadback
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2ChannelReadback", VALUELib.ValueType.F4, value.ToString())

        '    End Set
        'End Property
        'Public Property GasController_Gas3_Readback() As Double
        '    Get
        '        Return m_GasController_Gas3_Readback
        '    End Get
        '    Set(ByVal value As Double)
        '        CheckValueForLog("GasController_Gas3", m_GasController_Gas3_Readback, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas3ChannelReadback
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3ChannelReadback", VALUELib.ValueType.F4, value.ToString())

        '    End Set
        'End Property
        'Public Property GasController_Gas4_Readback() As Double
        '    Get
        '        Return m_GasController_Gas4_Readback
        '    End Get
        '    Set(ByVal value As Double)
        '        CheckValueForLog("GasController_Gas4", m_GasController_Gas4_Readback, value)
        '    End Set
        'End Property
        'Public Property GasController_Gas5_Readback() As Double
        '    Get
        '        Return m_GasController_Gas5_Readback
        '    End Get
        '    Set(ByVal value As Double)
        '        CheckValueForLog("GasController_Gas5", m_GasController_Gas5_Readback, value)
        '    End Set
        'End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get GasController_FlowCoolHe.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GasController_FlowCoolHe_Readback() As Double
            Get
                Return m_GasController_FlowCoolHe_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("GasController_FlowCoolHe", m_GasController_FlowCoolHe_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.FlowCoolGasChannelReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FlowCoolGasChannelReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get GasController_Oxygen.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GasController_PBN_Readback() As Double
            Get
                Return m_GasController_PBN_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("GasController_PBN", m_GasController_PBN_Readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PBNGasChannelReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PBNGasChannelReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set GasController_Argon.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GasController_Argon_Program() As Double
            Get
                Return m_GasController_Argon_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("GasController_Argon", m_GasController_Argon_Program, value)
            End Set
        End Property
        'Public Property GasController_Gas1_Program() As Double
        '    Get
        '        Return m_GasController_Gas1_Program
        '    End Get
        '    Set(ByVal value As Double)
        '        CheckValueForLog("GasController_Gas1", m_GasController_Gas1_Program, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas1ChannelProgram
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1ChannelProgram", VALUELib.ValueType.F4, value.ToString())

        '    End Set
        'End Property
        'Public Property GasController_Gas2_Program() As Double
        '    Get
        '        Return m_GasController_Gas2_Program
        '    End Get
        '    Set(ByVal value As Double)
        '        CheckValueForLog("GasController_Gas2", m_GasController_Gas2_Program, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas2ChannelProgram
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2ChannelProgram", VALUELib.ValueType.F4, value.ToString())

        '    End Set
        'End Property
        'Public Property GasController_Gas3_Program() As Double
        '    Get
        '        Return m_GasController_Gas3_Program
        '    End Get
        '    Set(ByVal value As Double)
        '        CheckValueForLog("GasController_Gas3", m_GasController_Gas3_Program, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas3ChannelProgram
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3ChannelProgram", VALUELib.ValueType.F4, value.ToString())

        '    End Set
        'End Property
        'Public Property GasController_Gas4_Program() As Double
        '    Get
        '        Return m_GasController_Gas4_Program
        '    End Get
        '    Set(ByVal value As Double)
        '        CheckValueForLog("GasController_Gas4", m_GasController_Gas4_Program, value)
        '    End Set
        'End Property
        'Public Property GasController_Gas5_Program() As Double
        '    Get
        '        Return m_GasController_Gas5_Program
        '    End Get
        '    Set(ByVal value As Double)
        '        CheckValueForLog("GasController_Gas5", m_GasController_Gas5_Program, value)
        '    End Set
        'End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set GasController_FlowCoolHe.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GasController_FlowCoolHe_Program() As Double
            Get
                Return m_GasController_FlowCoolHe_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("GasController_FlowCoolHe", m_GasController_FlowCoolHe_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.FlowCoolGasChannelProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FlowCoolGasChannelProgram", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Set GasController_Oxygen.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GasController_PBN_Program() As Double
            Get
                Return m_GasController_PBN_Program
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("GasController_PBN", m_GasController_PBN_Program, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PBNGasChannelProgram
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PBNGasChannelProgram", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property
#End Region

#Region "ProcessMonitor"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ProcessMonitor_FixtureAngle
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_FixtureAngle() As Double
            Get
                Return m_ProcessMonitor_FixtureAngle
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ProcessMonitor_FixtureAngle", m_ProcessMonitor_FixtureAngle, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ProcessMonitor_FixtureRotation
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_FixtureRotation() As Double
            Get
                Return m_ProcessMonitor_FixtureRotation
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ProcessMonitor_FixtureRotation", m_ProcessMonitor_FixtureRotation, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ProcessMonitor_ProcessStep
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_ProcessStep() As String
            Get
                Return m_ProcessMonitor_ProcessStep
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor_ProcessStep", m_ProcessMonitor_ProcessStep, value)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ProcessCurrentStep
                Dim iValue As Integer = -1
                Integer.TryParse(value, iValue)
                iValue += 1
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessCurrentStep", VALUELib.ValueType.A, iValue.ToString())
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-10-01</date>
        ''' </author>
        ''' <summary>
        ''' ProcessMonitor_TotalStep
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_TotalStep() As String
            Get
                Return m_ProcessMonitor_TotalStep
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor_ProcessStep", m_ProcessMonitor_TotalStep, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalProcessStep", VALUELib.ValueType.A, value)
            End Set
        End Property

        Public Property EPDRecipe() As String
            Get
                Return m_EPDRecipe
            End Get
            Set(ByVal value As String)
                CheckValueForLog("EPDRecipe", m_EPDRecipe, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "EPDRecipe", VALUELib.ValueType.A, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-10-01</date>
        ''' </author>
        ''' <summary>
        ''' ProcessMonitor_ProcessTime
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ProcessMonitor_ProcessTime() As String
            Get
                Return m_ProcessMonitor_ProcessTime
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor_ProcessTime", m_ProcessMonitor_ProcessTime, value)
                UpdateWaferProcessTimeInRealTime(value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-03-29 </date>
        ''' </author>
        ''' <summary>
        ''' Process status
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
        Public Property ProcessControl_GetRunDataFileName() As WorkingStatuses
            Get
                Return m_ProcessControl_GetRunDataFileName
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ProcessControl_GetRunDataFileName", m_ProcessControl_GetRunDataFileName, value, False)
            End Set
        End Property
#End Region

#Region "IBE Valves"
        ''' <author>
        '''  	<name> Cao Anh Kiet </name>
        '''  	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Argon Valve Status.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TurboPowerStatus() As WorkingStatuses
            Get
                Return m_TurboPowerStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ValveWaterPumpStatus", m_TurboPowerStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.TurboOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TurboOnOff", VALUELib.ValueType.U1, value)

            End Set
        End Property
        Public Property ValveSupplyArgonStatus() As WorkingStatuses
            Get
                Return m_SupplyArgonStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ValveSupplyArgonStatus", m_SupplyArgonStatus, value)
            End Set
        End Property
        'Public Property Gas1SupplyValveStatus() As WorkingStatuses
        '    Get
        '        Return m_SupplyGas1Status
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("ValveSupplyGas1Status", m_SupplyGas1Status, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas1SupplyValveStatus
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1SupplyValveStatus", VALUELib.ValueType.U1, value)

        '    End Set
        'End Property
        'Public Property Gas2SupplyValveStatus() As WorkingStatuses
        '    Get
        '        Return m_SupplyGas2Status
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("ValveSupplyGas2Status", m_SupplyGas2Status, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas2SupplyValveStatus
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2SupplyValveStatus", VALUELib.ValueType.U1, value)

        '    End Set
        'End Property
        'Public Property Gas3SupplyValveStatus() As WorkingStatuses
        '    Get
        '        Return m_SupplyGas3Status
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("ValveSupplyGas3Status", m_SupplyGas3Status, value)

        ' Update SECS/GEM variables by Dat Vo
        '        Var(Name) : PMx.Gas3SupplyValveStatus()
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3SupplyValveStatus", VALUELib.ValueType.U1, value)

        '    End Set
        'End Property
        'Public Property Gas4SupplyValveStatus() As WorkingStatuses
        '    Get
        '        Return m_SupplyGas4Status
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("ValveSupplyGas4Status", m_SupplyGas4Status, value)
        '    End Set
        'End Property
        'Public Property Gas5SupplyValveStatus() As WorkingStatuses
        '    Get
        '        Return m_SupplyGas5Status
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("ValveSupplyGas5Status", m_SupplyGas5Status, value)
        '    End Set
        'End Property
        Public Property ValveSupplyOxygenStatus() As WorkingStatuses
            Get
                Return m_SupplyOxygenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ValveSupplyOxygenStatus", m_SupplyOxygenStatus, value)
            End Set
        End Property
        Public Property ValveSupplyFlowCoolHeStatus() As WorkingStatuses
            Get
                Return m_SupplyFlowCoolHeStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ValveSupplyFlowCoolHeStatus", m_SupplyFlowCoolHeStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.FlowCoolSupplyValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FlowCoolSupplyValveStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
        Public Property ValveCryoPumpGateStatus() As WorkingStatuses
            Get
                Return m_CryoPumpGateStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ValveCryoPumpGateStatus", m_CryoPumpGateStatus, value)
                ' Update SECS/GEM variables by Hoa Nguyen
                ' Var Name: PMx.ValveCryoPumpGateStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CryoHivacValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property
        Public Property ValveSupplyPBNStatus() As WorkingStatuses
            Get
                Return m_SupplyPBNStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ValveSupplyPBNStatus", m_SupplyPBNStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PBNGasValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PBNGasValveStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''  	<name> Cao Anh Kiet </name>
        '''  	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Argon Valve Status.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ArgonValveStatus() As WorkingStatuses
            Get
                Return m_ArgonValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ArgonValveStatus", m_ArgonValveStatus, value)
            End Set
        End Property
        'Public Property Gas1ShutOffValveStatus() As WorkingStatuses
        '    Get
        '        Return m_Gas1ValveStatus
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("Gas1ValveStatus", m_Gas1ValveStatus, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas1ShutOffValveStatus
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1ShutOffValveStatus", VALUELib.ValueType.U1, value)

        '    End Set
        'End Property
        'Public Property Gas2ShutOffValveStatus() As WorkingStatuses
        '    Get
        '        Return m_Gas2ValveStatus
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("Gas2ValveStatus", m_Gas2ValveStatus, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas2ShutOffValveStatus
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2ShutOffValveStatus", VALUELib.ValueType.U1, value)

        '    End Set
        'End Property
        'Public Property Gas3ShutOffValveStatus() As WorkingStatuses
        '    Get
        '        Return m_Gas3ValveStatus
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("Gas3ValveStatus", m_Gas3ValveStatus, value)

        '        ' Update SECS/GEM variables by Dat Vo
        '        ' Var Name: PMx.Gas3ShutOffValveStatus
        '        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3ShutOffValveStatus", VALUELib.ValueType.U1, value)

        '    End Set
        'End Property
        'Public Property Gas4ShutOffValveStatus() As WorkingStatuses
        '    Get
        '        Return m_Gas4ValveStatus
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("Gas4ValveStatus", m_Gas4ValveStatus, value)
        '    End Set
        'End Property
        'Public Property Gas5ShutOffValveStatus() As WorkingStatuses
        '    Get
        '        Return m_Gas5ValveStatus
        '    End Get
        '    Set(ByVal value As WorkingStatuses)
        '        CheckValueForLog("Gas5ValveStatus", m_Gas5ValveStatus, value)
        '    End Set
        'End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Baratron Valve Status.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BaratronValveStatus() As WorkingStatuses
            Get
                Return m_BaratronValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("BaratronValveStatus", m_BaratronValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' FlowCoolHe Valve Status.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FlowCoolHeValveStatus() As WorkingStatuses
            Get
                Return m_FlowCoolHeValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FlowCoolHeValveStatus", m_FlowCoolHeValveStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.FlowCoolShutOffValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FlowCoolShutOffValveStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Dy Do </name>
        '''   	<date> 2015-08-11</date>
        ''' </author>
        ''' <summary>
        ''' FlowCoolGas Status.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FlowCoolGasOnStatus() As WorkingStatuses
            Get
                Return m_FlowCoolGasStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FlowCoolGasOnStatus", m_FlowCoolGasStatus, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FlowCoolGasOnStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property

        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Foreline Valve Status.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ForelineValveStatus() As WorkingStatuses
            Get
                Return m_ForelineValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ForelineValveStatus", m_ForelineValveStatus, value)
            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Oxygen Valve Status.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PBNValveStatus() As WorkingStatuses
            Get
                Return m_PBNValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("PBNValveStatus", m_PBNValveStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PBNGasValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PBNGasValveStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Cao Anh Kiet </name>
        '''   	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Hivac Valve Status.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property HiVacValveStatus() As WorkingStatuses
            Get
                Return m_HivacValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("HiVacValveStatus", m_HivacValveStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.TurboHivacValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TurboHivacValveStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
#End Region

#Region "ChamberInterlocks"

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ChamberInterlocks_FixtureWater_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_FixtureWater_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_FixtureWater
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Interlocks.FixtureWater
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.FixtureWater", VALUELib.ValueType.U1, value)

                'Alarm Set/Clear by Dat Cao
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_FixtureWater = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "FixtureWaterInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_FixtureWater = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "FixtureWaterInterlock", "Fixture Water Interlock Tripped")
                End If

                CheckValueForLog("ChamberInterlocks_FixtureWater", m_ChamberInterlocks_FixtureWater, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ChamberInterlocks_FixtureWaterBug_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_FixtureWaterBug_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_FixtureWaterBug
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Interlocks.FixtureWater
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.FixtureWaterBug", VALUELib.ValueType.U1, value)

                'Alarm Set/Clear by Dat Cao
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_FixtureWaterBug = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "FixtureWaterBugInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_FixtureWaterBug = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "FixtureWaterBugInterlock", "Fixture Water Bug Interlock Tripped")
                End If

                CheckValueForLog("ChamberInterlocks_FixtureWaterBug", m_ChamberInterlocks_FixtureWaterBug, value)
            End Set
        End Property


        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ChamberInterlocks_ChamberPress_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_ChamberPress_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_ChamberPress
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Interlocks.ChamberPressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.ChamberPressure", VALUELib.ValueType.U1, value)

                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_ChamberPress = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "ChamberPressureInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_ChamberPress = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "ChamberPressureInterlock", "Chamber Pressure Interlock Tripped")
                End If

                CheckValueForLog("ChamberInterlocks_ChamberPress", m_ChamberInterlocks_ChamberPress, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ChamberInterlocks_Foreline_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_Foreline_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_Foreline
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Interlocks.TurboForeline
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.TurboForeline", VALUELib.ValueType.U1, value)

                'Alarm Set/Clear by Dat Cao
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_Foreline = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "ForelinePressureInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_Foreline = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "ForelinePressureInterlock", "Foreline Pressure Interlock Tripped")
                End If

                CheckValueForLog("ChamberInterlocks_Foreline", m_ChamberInterlocks_Foreline, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ChamberInterlocks_SourceWater_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_SourceWater_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_SourceWater
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Interlocks.Source
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.Source", VALUELib.ValueType.U1, value)

                'Alarm Set/Clear by Dat Cao
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_SourceWater = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "SourceInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_SourceWater = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "SourceInterlock", "Source Interlock trip")
                End If
                CheckValueForLog("ChamberInterlocks_SourceWater", m_ChamberInterlocks_SourceWater, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ChamberInterlocks_MagnetWater_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_MagnetWater_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_MagnetWater
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ChamberInterlocks_MagnetWater", m_ChamberInterlocks_MagnetWater, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ChamberInterlocks_Target_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_Target_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_Target
            End Get
            Set(ByVal value As WorkingStatuses)

                'Alarm Set/Clear by Dat Cao <<CHUALAM>>
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_Target = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "ChamberPressureInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_Target = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "ChamberPressureInterlock", "Chamber Pressure Interlock Tripped")
                End If

                CheckValueForLog("ChamberInterlocks_Target", m_ChamberInterlocks_Target, value)

            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ChamberInterlocks_TurboWater_Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChamberInterlocks_TurboWater_Status() As WorkingStatuses
            Get
                Return m_ChamberInterlocks_TurboWater
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Interlocks.TurboWater
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Interlocks.TurboWater", VALUELib.ValueType.U1, value)

                'Alarm Set/Clear by Dat Cao
                If (value = WorkingStatuses.On AndAlso m_ChamberInterlocks_TurboWater = WorkingStatuses.Off) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmCLEAR(Me.Name, "TurboWaterInterlock")
                ElseIf (value = WorkingStatuses.Off AndAlso m_ChamberInterlocks_TurboWater = WorkingStatuses.On) Then
                    Business.AVPSecsGemLib.SECSGEM_AlarmSET(Me.Name, "TurboWaterInterlock", "Turbo Water Interlock Tripped")
                End If

                CheckValueForLog("ChamberInterlocks_TurboWater", m_ChamberInterlocks_TurboWater, value)
            End Set
        End Property

#End Region

#Region "Fixture Tool"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FixtureFlowCoolPumpStatus() As WorkingStatuses
            Get
                Return m_FixtureFlowCoolPumpStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FixtureFlowCoolPumpStatus", m_FixtureFlowCoolPumpStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.FlowCoolPumpPowerOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FlowCoolPumpPowerOnOff", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FixtureWaterValveStatus() As WorkingStatuses
            Get
                Return m_FixtureWaterValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FixtureWaterValveStatus", m_FixtureWaterValveStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.FixtureWaferValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FixtureWaferValveStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''     <name>Nguyen Dy</name>
        '''     <date>2014-12-10</date>
        ''' </author>
        ''' <summary>
        ''' Internal Shutter Status
        ''' </summary>
        Public Property CryoCommmunicateStateReadBackStatus() As WorkingStatuses
            Get
                Return m_CryoCommmunicateStateReadBack
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("CryoCommmunicateStateReadBackStatus", m_CryoCommmunicateStateReadBack, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.InternalShutterStatus
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, _
                '               "InternalShutterStatus", VALUELib.ValueType.U1, _
                '              IIf(value = WorkingStatuses.Other, WorkingStatuses.Unknown, value))  'revert data to 02

            End Set
        End Property

        ''' <author>
        '''     <name>Hoai Ly</name>
        '''     <date>2015-01-11</date>
        ''' </author>
        ''' <summary>
        ''' Cryo Last Full Regen ReadBack
        ''' </summary>
        Public Property CryoLastFullRegenReadBack() As Double
            Get
                Return m_CryoLastFullRegenReadBack
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("CryoLastFullRegenReadBack", m_CryoLastFullRegenReadBack, value)
                'Update SECS/GEM variables by Hoai Ly
                'Var(Name) : PMx.CryoLastFullRegenReadBack()
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, _
                               "Cryo.RegenHour", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''     <name>Hoai Ly</name>
        '''     <date>2015-01-11</date>
        ''' </author>
        ''' <summary>
        ''' Cryo Elapsed Time ReadBack
        ''' </summary>
        Public Property CryoElapsedTimeReadBack() As Double
            Get
                Return m_CryoElapsedTimeReadBack
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("CryoElapsedTimeReadBack", m_CryoElapsedTimeReadBack, value)
                'Update SECS/GEM variables by Hoai Ly
                'Var(Name) : PMx.CryoElapsedTimeReadBack()
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, _
                               "Cryo.LifeTimeHour", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2014-11-20</date>
        ''' </author>
        ''' <summary>
        ''' Internal Shutter Status
        ''' </summary>
        Public Property InternalShutterStatus() As WorkingStatuses
            Get
                Return m_InternalShutterStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("InternalShutterStatus", m_InternalShutterStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.InternalShutterStatus
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, _
                '               "InternalShutterStatus", VALUELib.ValueType.U1, _
                '              IIf(value = WorkingStatuses.Other, WorkingStatuses.Unknown, value))  'revert data to 02

            End Set
        End Property
        ''' <author>
        '''     <name>Nguyen Dy</name>
        '''     <date>2014-12-04</date>
        ''' </author>
        ''' <summary>
        ''' Internal Shutter Off Status
        ''' </summary>
        Public Property InternalShutterOffStatus() As WorkingStatuses
            Get
                Return m_InternalShutterOffStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("InternalShutterOffStatus", m_InternalShutterOffStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.InternalShutterStatus
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, _
                '               "InternalShutterStatus", VALUELib.ValueType.U1, _
                '              IIf(value = WorkingStatuses.Other, WorkingStatuses.Unknown, value))  'revert data to 02

            End Set
        End Property


        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-09</date>
        ''' </author>
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShutterPositionStatus() As WorkingStatuses
            Get
                Return m_ShutterPositionStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ShutterPositionStatus", m_ShutterPositionStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.ShutterStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, _
                               "ShutterStatus", VALUELib.ValueType.U1, _
                              IIf(value = WorkingStatuses.Other, WorkingStatuses.Unknown, value))  'revert data to 02

            End Set
        End Property
        ''' <author>
        '''  	<name> Cao Anh Kiet </name>
        '''  	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Fixture OnClamp.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FixtureClampStatus() As WorkingStatuses
            Get
                Return m_FixtureClampStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FixtureClampStatus", m_FixtureClampStatus, value) ''value=On->clamp Up, value=off-> clamp down

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.ClampStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ClampStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' FixtureHomeAllAxis
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FixtureHomeAllAxis() As WorkingStatuses
            Get
                Return m_FixtureHomeAllAxis
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FixtureHomeAllAxis", m_FixtureHomeAllAxis, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' FixtureHomeRotationAxis
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FixtureHomeRotationAxis() As WorkingStatuses
            Get
                Return m_FixtureHomeRotationAxis
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FixtureHomeRotationAxis", m_FixtureHomeRotationAxis, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' FixtureHomeTiltAxis
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FixtureHomeTiltAxis() As WorkingStatuses
            Get
                Return m_FixtureHomeTiltAxis
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FixtureHomeTiltAxis", m_FixtureHomeTiltAxis, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' FixtureStartRotationAxis
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FixtureStartRotationAxis() As WorkingStatuses
            Get
                Return m_FixtureStartRotationAxis
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FixtureStartRotationAxis", m_FixtureStartRotationAxis, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' FixtureStopAllAxis
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FixtureStopAllAxis() As WorkingStatuses
            Get
                Return m_FixtureStopAllAxis
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FixtureStopAllAxis", m_FixtureStopAllAxis, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' FixtureUnClamp
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FixtureUnClamp() As WorkingStatuses
            Get
                Return m_FixtureUnClamp
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("FixtureUnClamp", m_FixtureUnClamp, value)
            End Set
        End Property
        ''' <summary>
        ''' FixtureTiltStatus
        ''' </summary>
        Public Property FixtureTiltHomeStatus() As DEVICE_STATUS
            Get
                Return m_FixtureTiltHomeStatus
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("FixtureTiltHomeStatus", m_FixtureTiltHomeStatus, value)
                CheckValueForLog("FixtureControlSweep_TiltAngle", m_FixtureControlSweep_Tilt_Status, value)
                CheckValueForLog("FixtureControlStatic_TiltAngleStatus", m_FixtureControlStatic_Tilt_Status, value)
                CheckValueForLog("FixtureControlContinuous_TiltAngleStatus", m_FixtureControlContinuous_Tilt_Status, value)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.TiltHomeStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TiltHomeStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <summary>
        ''' FixtureRotationStatus
        ''' </summary>
        Public Property FixtureRotationHomeStatus() As DEVICE_STATUS
            Get
                Return m_FixtureRotationHomeStatus
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("FixtureRotationHomeStatus", m_FixtureRotationHomeStatus, value)
                CheckValueForLog("FixtureControlSweep_TiltRotation_Status", m_FixtureControlSweep_Rotation_Status, value)
                CheckValueForLog("FixtureControlStatic_TiltRotationStatus", m_FixtureControlStatic_Rotation_Status, value)
                CheckValueForLog("FixtureControlContinuous_TiltRotationStatus", m_FixtureControlContinuous_Rotation_Status, value)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RotationHomeStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotationHomeStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <summary>
        ''' FixtureRotationStatus
        ''' </summary>
        Public Property FixtureRotationMovingStatus() As DEVICE_STATUS
            Get
                Return m_FixtureRotationMovingStatus
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("m_FixtureRotationMovingStatus", m_FixtureRotationMovingStatus, value)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RotatingStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RotatingStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <summary>
        ''' FixtureErrorStatus
        ''' </summary>
        Public Property FixtureErrorStatus() As DEVICE_STATUS
            Get
                Return m_FixtureErrorStatus
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("FixtureErrorStatus", m_FixtureErrorStatus, value)
                CheckValueForLog("FixtureControlSweep_TiltRotation_Status", m_FixtureControlSweep_Error_Status, value)
                CheckValueForLog("FixtureControlStatic_TiltRotationStatus", m_FixtureControlStatic_Error_Status, value)
                CheckValueForLog("FixtureControlContinuous_TiltRotationStatus", m_FixtureControlContinuous_Error_Status, value)
            End Set
        End Property

        ''' <summary>
        ''' FixtureErrorStatus
        ''' </summary>
        Public Property FixtureRotationErrorStatus() As DEVICE_STATUS
            Get
                Return m_FixtureRotationErrorStatus
            End Get
            Set(ByVal value As DEVICE_STATUS)
                CheckValueForLog("FixtureRotationErrorStatus", m_FixtureRotationErrorStatus, value)
            End Set
        End Property
#End Region

#Region "Machine Tool, old system have not 3 items such as: Cryo On, Cryo Regen, Cryo Hivac"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' MachineOnline
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MachineOnline() As WorkingStatuses
            Get
                Return m_MachineOnline
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("MachineOnline", m_MachineOnline, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' MachinePumbDown
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MachinePumbDown() As WorkingStatuses
            Get
                Return m_MachinePumbDown
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("MachinePumbDown", m_MachinePumbDown, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' MachineVent
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MachineVent() As WorkingStatuses
            Get
                Return m_MachineVent
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("MachineVent", m_MachineVent, value)
            End Set
        End Property
#End Region

#Region "Power Panel"
        ''' <author>
        '''   	<name> Le Hieu Truc </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the ACPower_readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACPower_readback() As WorkingStatuses
            Get
                Return m_ACPower_readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ACPower", m_ACPower_readback, value)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PowerPanel.ACPowerOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PowerPanel.ACPowerOnOff", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Le Hieu Truc </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the RFPower_readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RFPower_readback() As WorkingStatuses
            Get
                Return m_RFPower_readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("RFPower", m_RFPower_readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PowerPanel.RFPowerOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PowerPanel.RFPowerOnOff", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Le Hieu Truc </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the GridPower_readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GridPower_readback() As WorkingStatuses
            Get
                Return m_GridPower_readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("GridPower", m_GridPower_readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PowerPanel.GridPowerOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PowerPanel.GridPowerOnOff", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Le Hieu Truc </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the PBNPower_readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PBNPower_readback() As WorkingStatuses
            Get
                Return m_PBNPower_readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("PBNPower", m_PBNPower_readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PowerPanel.PBNPowerOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PowerPanel.PBNPowerOnOff", VALUELib.ValueType.U1, value)

            End Set
        End Property

        ''' <author>
        '''   	<name> Le Hieu Truc </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the NEURPower_readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NeurPower_readback() As WorkingStatuses
            Get
                Return m_NeurPower_readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("PBNPower", m_NeurPower_readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PowerPanel.PBNPowerOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PowerPanel.PBNPowerOnOff", VALUELib.ValueType.U1, value)

            End Set
        End Property
        ''' <author>
        '''   	<name> Le Hieu Truc </name>
        '''   	<date> 2009-09-07</date>
        ''' </author>
        ''' <summary>
        ''' Get the NEURPower_readback
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SourceManual_Auto_readback() As WorkingStatuses
            Get
                Return m_SourceManual_Auto_readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("SourceManual_Auto_readback", m_SourceManual_Auto_readback, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.SourceAutoManualStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SourceAutoManualStatus", VALUELib.ValueType.U1, value)

            End Set
        End Property
#End Region

#Region "Menu Status"
        Public Property PumpDownStatus() As WorkingStatuses
            Get
                Return m_PumpDownStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                Utils.UpdateSequenceRunningStatusText(Me.Name, AUTO_PUMPDOWN_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)

                CheckValueForLog("PumpDownStatus", m_PumpDownStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.AutoPumpDownRunning
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "AutoPumpDownRunning", VALUELib.ValueType.U1, value)

            End Set
        End Property
        Public Property VentStatus() As WorkingStatuses
            Get
                Return m_VentStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                Utils.UpdateSequenceRunningStatusText(Me.Name, AUTO_VENT_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)

                CheckValueForLog("VentStatus", m_VentStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.AutoVentRunning
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "AutoVentRunning", VALUELib.ValueType.U1, value)

            End Set
        End Property
        Public Property CryoPumpStatus() As WorkingStatuses
            Get
                Return m_CryoPumpStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("CryoPumpStatus", m_CryoPumpStatus, value)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Cryo.OnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.OnOff", VALUELib.ValueType.U1, value)

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

        Public Property TurboPumpStatus() As WorkingStatuses
            Get
                Return m_TurboPumpStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("TurboPumpStatus", m_TurboPumpStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.TurboOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TurboOnOff", VALUELib.ValueType.U1, value)

            End Set
        End Property

        Public Property RoughPumpStatus() As WorkingStatuses
            Get
                Return m_RoughPumpStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("RoughPumpStatus", m_RoughPumpStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.RoughPumpPowerOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RoughPumpPowerOnOff", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Property CryoPumpRegenStatus() As WorkingStatuses
            Get
                Return m_CryoPumpRegenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("CryoPumpRegenStatus", m_CryoPumpRegenStatus, value)
            End Set
        End Property

        Public Property CryoAutoRegenStatus() As WorkingStatuses
            Get
                Return m_CryoAutoRegenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("CryoAutoRegenStatus", m_CryoAutoRegenStatus, value)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.Cryo.RegenOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.RegenOnOff", _
                    VALUELib.ValueType.U1, Utils.ConvertWorkingStatusValueForUpdateGEM(value))
            End Set
        End Property

        Public Overrides Property RateOfRise_Status() As WorkingStatuses
            Get
                Return m_RateOfRise_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                Utils.UpdateSequenceRunningStatusText(Me.Name, RATE_OF_RISE_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)

                Dim oldStatus As WorkingStatuses = m_RateOfRise_Status
                CheckValueForLog("RateOfRise_Status", m_RateOfRise_Status, value)

            End Set
        End Property

        Public Overrides Property PumpDown_Curve_Status() As WorkingStatuses
            Get
                Return m_PumpDown_Curve_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                Utils.UpdateSequenceRunningStatusText(Me.Name, PUMPDOWN_CURVE_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)

                Dim oldStatus As WorkingStatuses = m_PumpDown_Curve_Status
                CheckValueForLog("PumpDown_Curve_Status", m_PumpDown_Curve_Status, value)

            End Set
        End Property

        Public Property PumpPurgeStatus() As WorkingStatuses
            Get
                Return m_PumpPurgeStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("PumpPurgeStatus", m_PumpPurgeStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.PumpPurgeRunning
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PumpPurgeRunning", VALUELib.ValueType.U1, value)

            End Set
        End Property

        Public Property IGDegasStatus() As WorkingStatuses
            Get
                Return m_IGDegasStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                Utils.UpdateSequenceRunningStatusText(Me.Name, IG_DEGAS_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)

                CheckValueForLog("IGDegasStatus", m_IGDegasStatus, value)

                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.IGDegasRunning
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "IGDegasRunning", VALUELib.ValueType.U1, value)

            End Set
        End Property
#End Region

#Region "Source Usage"
        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-03-09 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Source Usage Current
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SourceUsageTimeCurrent() As Double
            Get
                Return m_SourceUsageTimeCurrent
            End Get
            Set(ByVal value As Double)
                Single.TryParse(value, m_SourceUsageTimeCurrent)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.SourceUsage
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SourceUsage", VALUELib.ValueType.F4, value.ToString())
                '#05/24/2011 
                '#-	AVP.  No warning/alarm when PM2(IBE)  source minutes is at warning/alarm level
                '#Begin fix---Hoa Nguyen
                ' Compare Warning Limit.
                CheckingSourceUsage(m_SourceUsageTimeCurrent)
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-03-09 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Source Usage Warning
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SourceUsageTimeWarning() As Double
            Get
                Return m_SourceUsageTimeWarning
            End Get
            Set(ByVal value As Double)
                m_SourceUsageTimeWarning = value
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.SourceWarning
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SourceWarning", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-03-09 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Source Usage Limit
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SourceUsageTimeLimit() As Double
            Get
                Return m_SourceUsageTimeLimit
            End Get
            Set(ByVal value As Double)
                m_SourceUsageTimeLimit = value
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.SourceLimit
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SourceLimit", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-09-06 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set PBN Time Current
        ''' </summary>
        ''' <remarks></remarks>
        Public Property PBNTimeCurrent() As Double
            Get
                Return m_PBNTimeCurrent
            End Get
            Set(ByVal value As Double)
                Single.TryParse(value, m_PBNTimeCurrent)

                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PBNMinutes", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2015-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the usage time of fixture cover shield.
        ''' </summary>
        Public Property CoverFixtureShieldUsageReadback() As Double
            Get
                Return m_CoverFixtureShieldUsageReadback
            End Get
            Set(ByVal value As Double)
                m_CoverFixtureShieldUsageReadback = value

                ' Update SECS/GEM variables by Hai Tran
                ' Var Name: PMx.CoverFixtureShieldUsageReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CoverFixtureShieldUsageReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2015-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the usage time of wafer clamp.
        ''' </summary>
        Public Property WaferClampUsageReadback() As Double
            Get
                Return m_WaferClampUsageReadback
            End Get
            Set(ByVal value As Double)
                m_WaferClampUsageReadback = value

                ' Update SECS/GEM variables by Hai Tran
                ' Var Name: PMx.WaferClampUsageReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferClampUsageReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2015-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the usage time of grid source shield.
        ''' </summary>
        Public Property TopFixtureShieldUsageReadback() As Double
            Get
                Return m_TopFixtureShieldUsageReadback
            End Get
            Set(ByVal value As Double)
                m_TopFixtureShieldUsageReadback = value

                ' Update SECS/GEM variables by Hai Tran
                ' Var Name: PMx.TopFixtureShieldUsageReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GridSourceReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2015-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the usage time of shutter (SourceUsageAfterPM).
        ''' </summary>
        Public Property ShutterUsageReadback() As Double
            Get
                Return m_ShutterUsageReadback
            End Get
            Set(ByVal value As Double)
                m_ShutterUsageReadback = value

                ' Update SECS/GEM variables by Hai Tran
                ' Var Name: PMx.ShutterUsageReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SourceUsageAfterPMReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2015-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the usage time of Liner Source.
        ''' </summary>
        Public Property LinerSourceUsageReadback() As Double
            Get
                Return m_LinerSourceUsageReadback
            End Get
            Set(ByVal value As Double)
                m_LinerSourceUsageReadback = value

                ' Update SECS/GEM variables by Hai Tran
                ' Var Name: PMx.LinerSourceUsageReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "LinerSourceReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2015-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the usage time of Cryo.
        ''' </summary>
        Public Property CryoUsageReadback() As Double
            Get
                Return m_CryoUsageReadback
            End Get
            Set(ByVal value As Double)
                m_CryoUsageReadback = value

                ' Update SECS/GEM variables by Hai Tran
                ' Var Name: PMx.CryoUsageReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CryoUsageReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2015-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the usage time of FixtureRotationMotor.
        ''' </summary>
        Public Property FixtureRotationMotorUsageReadback() As Double
            Get
                Return m_FixtureRotationMotorUsageReadback
            End Get
            Set(ByVal value As Double)
                m_FixtureRotationMotorUsageReadback = value

                ' Update SECS/GEM variables by Hai Tran
                ' Var Name: PMx.FixtureRotationMotorUsageReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FixtureRotationMotorUsageReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2015-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the usage time of WaterJournal.
        ''' </summary>
        Public Property WaterJournalReadback() As Double
            Get
                Return m_WaterJournalReadback
            End Get
            Set(ByVal value As Double)
                m_WaterJournalReadback = value

                ' Update SECS/GEM variables by Hai Tran
                ' Var Name: PMx.WaterJournalReadback
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaterJournalReadback", VALUELib.ValueType.F4, value.ToString())

            End Set
        End Property

#End Region

#Region "System Warm Up"

        ''' <summary>
        ''' Idle Threshold
        ''' </summary>
        ''' <remarks></remarks>
        Protected m_fIdleThreshold As Single = 48
        Public Property IdleThreshold() As Single
            Get
                Return m_fIdleThreshold
            End Get
            Set(ByVal value As Single)
                m_fIdleThreshold = value
            End Set
        End Property

        ''' <summary>
        ''' Warm Up Recipe
        ''' </summary>
        ''' <remarks></remarks>
        Protected m_strWarmUpRecipe As String = String.Empty
        Public Property WarmUpRecipe() As String
            Get
                Return m_strWarmUpRecipe
            End Get
            Set(ByVal value As String)
                m_strWarmUpRecipe = value
            End Set
        End Property

        ''' <summary>
        ''' Warm Up Recipe
        ''' </summary>
        ''' <remarks></remarks>
        Protected m_bIsWarmingUp As Boolean = False
        Public Property IsWarmingUp() As Boolean
            Get
                Return m_bIsWarmingUp
            End Get
            Set(ByVal value As Boolean)
                m_bIsWarmingUp = value
            End Set
        End Property

        ''' <summary>
        ''' Warm Up Flag. Indicate that warm up recipe has run
        ''' </summary>
        ''' <remarks></remarks>
        Protected m_bWarmingUpFlag As Boolean = False
        Public Property WarmingUpFlag() As Boolean
            Get
                Return m_bWarmingUpFlag
            End Get
            Set(ByVal value As Boolean)
                m_bWarmingUpFlag = value
            End Set
        End Property

#End Region

#Region "Run recipe"
        Public Overrides Property ProcessMonitor_DeviceStart_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceStart_Readback
            End Get
            Set(ByVal value As String)

                Utils.UpdateSequenceRunningStatusText(Me.Name, RECIPE_PROCESS_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, STR_ON)

                CheckValueForLog("ProcessMonitor DeviceStart Readback", m_strProcessMonitor_DeviceStart_Readback, value, False)
                AVPLib.Utils.TurnOffSystem_Light(False, Me.Name)
                BeginCountingWaferProcessTime()
                ChangeProcessState(ConstEnum.enumProcessStatus.eStart)
            End Set
        End Property

        Public Overrides Property ProcessMonitor_DeviceStop_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceStop_Readback
            End Get
            Set(ByVal value As String)
                Utils.UpdateSequenceRunningStatusText(Me.Name, RECIPE_PROCESS_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, STR_OFF)

                CheckValueForLog("ProcessMonitor DeviceStop Readback", m_strProcessMonitor_DeviceStop_Readback, value, False)
                AVPLib.Utils.TurnOffSystem_Light(True, Me.Name)
                ChangeProcessState(ConstEnum.enumProcessStatus.eStop)
                EndCountingWaferProcessTime()
                IsWarmingUp = False
            End Set
        End Property

        Public Overrides Property ProcessMonitor_DevicePause_Readback() As String
            Get
                Return m_strProcessMonitor_DevicePause_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor DevicePause Readback", m_strProcessMonitor_DevicePause_Readback, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.ePause)
            End Set
        End Property

        Public Property ProcessMonitor_DeviceResume_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceContinue_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor DeviceResume Readback", m_strProcessMonitor_DeviceContinue_Readback, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.eContinue)
            End Set
        End Property

        Public Overrides Property ProcessMonitor_DeviceError_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceError_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor DeviceError Readback", m_strProcessMonitor_DeviceError_Readback, value, False)
                AVPLib.Utils.TurnOffSystem_Light(True, Me.Name)
                ChangeProcessState(ConstEnum.enumProcessStatus.eError)
                IsWarmingUp = False
            End Set
        End Property

#End Region

#Region "Source EM"
        ''' <author>
        '''   	<name> Hoai Ly </name>
        '''   	<date> 2018-08-21</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set SourceEMCurrentRB.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SourceEMCurrentRB() As Double
            Get
                Return m_dSourceEMCurrentRB
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SourceEMCurrentRB", m_dSourceEMCurrentRB, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Source_EM_Current_RB", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''   	<name> Hoai Ly </name>
        '''   	<date> 2018-08-21</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set SourceEMCurrentSP.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SourceEMCurrentSP() As Double
            Get
                Return m_dSourceEMCurrentSP
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SourceEMCurrentSP", m_dSourceEMCurrentSP, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Source_EM_Current_SP", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''   	<name> Hoai Ly </name>
        '''   	<date> 2018-08-21</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set SourceEMVoltageRB.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SourceEMVoltageRB() As Double
            Get
                Return m_dSourceEMVoltageRB
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("SourceEMVoltageRB", m_dSourceEMVoltageRB, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Source_EM_Voltage_RB", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        ''' <author>
        '''   	<name> Hoai Ly </name>
        '''   	<date> 2018-08-21</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set SourceEMCommunicationStatus.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SourceEMCommunicationStatus() As WorkingStatuses
            Get
                Return m_SourceEMCommunicationStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("SourceEMCommunicationStatus", m_SourceEMCommunicationStatus, value)
            End Set
        End Property

#End Region

#Region "Hidden"
        ''' <author>
        '''   	<name> Tinh Le </name>
        '''   	<date> 2020-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set HiddenName.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property HiddenName() As String
            Get
                Return m_strHiddenName
            End Get
            Set(ByVal value As String)
                CheckValueForLog("HiddenName", m_strHiddenName, value)
                UpdateHiddenSecsGem(value, True, "ScanName")
            End Set
        End Property

        ''' <author>
        '''   	<name> Tinh Le </name>
        '''   	<date> 2020-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set HiddenData.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property HiddenData() As String
            Get
                Return m_strHiddenData
            End Get
            Set(ByVal value As String)
                CheckValueForLog("HiddenData", m_strHiddenData, value)
                UpdateHiddenSecsGem(value, False, "ScanData")
            End Set
        End Property

        ''' <author>
        '''   	<name> Tinh Le </name>
        '''   	<date> 2020-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set HidenParams.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property HidenParams() As String
            Get
                Return m_strHidenParams
            End Get
            Set(ByVal value As String)
                CheckValueForLog("HidenParams", m_strHidenParams, value)
                Dim scanParams As String = value.Replace(VERTICAL_TAB, CARRIAGE_RETURN)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ScanParams", VALUELib.ValueType.A, scanParams)
            End Set
        End Property

        ''' <author>
        '''   	<name> Tinh Le </name>
        '''   	<date> 2020-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set HidenEnvironment.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property HidenEnvironment() As String
            Get
                Return m_strHidenEnvironment
            End Get
            Set(ByVal value As String)
                CheckValueForLog("HidenEnvironment", m_strHidenEnvironment, value)
                Dim scanEnvironment As String = value.Replace(VERTICAL_TAB, CARRIAGE_RETURN)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ScanEnvironment", VALUELib.ValueType.A, scanEnvironment)
            End Set
        End Property

#End Region

#End Region
        ''' <author>
        '''   	<name> Tinh Le </name>
        '''   	<date> 2020-11-03</date>
        ''' </author>
        ''' <summary>
        ''' UpdateHiddenSecsGem
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UpdateHiddenSecsGem(ByVal data As String, ByVal isName As Boolean, ByVal variableName As String)
            Try
                Dim num As Integer = 0
                Dim maxData As Integer = MAX_HIDDEN_DATA
                Dim strData As String = String.Empty
                Dim arrData As Array = data.Split(DATA_SEPARATOR)

                If Not isName Then
                    maxData = MAX_HIDDEN_DATA + 2
                End If

                For i As Integer = 0 To maxData - 1
                    strData = String.Empty
                    If i < arrData.Length Then
                        strData = arrData(i).ToString()
                    End If
                    If Not isName Then
                        If i = 0 Then
                            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CycleTime", VALUELib.ValueType.A, strData)
                            Continue For
                        ElseIf i = 1 Then
                            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CycleTimeMilisecond", VALUELib.ValueType.A, strData)
                            Continue For
                        End If
                    End If
                    num += 1
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, variableName & num.ToString("#000"), VALUELib.ValueType.A, strData)
                Next

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Public Overrides Function IsShutterOpen() As Boolean
            Return (m_ShutterPositionStatus = WorkingStatuses.On)
        End Function

        Protected Overrides Function ChangeProcessState(ByVal newState As ConstEnum.enumProcessStatus) As Boolean
            AVPLib.Log.schedulerLogger.Debug(Me.Name & ": current process status = " & m_RunProcessStatus.ToString() & " and new state = " & newState.ToString())
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
                m_blnStateMachineCompleted = False
                RunProcessResult = EnumRunProcessResult.Running
                Utils.SetPMStatus(EnumChamberState.RUNNING.ToString(), Me.Name) ' Update status to RUNNING
                Return True
            End If
            If (ConstEnum.enumProcessStatus.eStop = newState) Then
                If (m_RunProcessStatus = ConstEnum.enumProcessStatus.ePause) OrElse (m_RunProcessStatus = ConstEnum.enumProcessStatus.eStart) Then

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
                    If m_blnStateMachineCompleted = False Then
                        If (WaferStatus <> enumWaferStatus.eWaferError) Then
                            ' Wafer processing is completed successfully, capture the last execution time.
                            LastExecution = Date.Now
                            m_blnStateMachineCompleted = True
                        End If
                    End If

                    If WarmUpState = RunningState.Running Then
                        WarmUpState = RunningState.Complete
                    End If
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
                    If WarmUpState = RunningState.Running Then
                        WarmUpState = RunningState.Error
                    End If
                End If
                If (RunProcessResult = EnumRunProcessResult.Resuming) Then
                    IsProcessRunning = False
                    RunProcessResult = EnumRunProcessResult.ProcessingCompleted

                    ' Trigger SECS/GEM Event by Dat Cao
                    ' Var Name: PMX.ProcessingAborted
                    Business.AVPSecsGemLib.TriggerEvent(Me.Name, "ProcessCompleted")
                    'Utils.SetPMStatus(EnumChamberState.WAITING_UNLOAD.ToString(), Me.Name) ' Update status to WAITING UNLOAD
                End If
                ' Missed Event Happens'''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If (ConstEnum.enumProcessStatus.eStop = m_RunProcessStatus) AndAlso (EnumRunProcessResult.Running = RunProcessResult) Then
                    IsProcessRunning = False
                    RunProcessResult = EnumRunProcessResult.ProcessingCompleted
                    If m_blnStateMachineCompleted = False Then
                        m_blnStateMachineCompleted = True
                        LastExecution = Date.Now
                    End If

                    If WarmUpState = RunningState.Running Then
                        WarmUpState = RunningState.Complete
                    End If
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
                If WarmUpState = RunningState.Running Then
                    WarmUpState = RunningState.Error
                End If
                Return True
            End If
            Return False
        End Function

        Protected Overrides Sub ProcessReceivedAlarm(ByVal alarmContent As String)
            ProcessReceivedAlarmCX(alarmContent)
        End Sub

        Protected Function CopyRateOfRiseData(ByVal strDestFilename As String) As Boolean
            Try
                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ConstEnum.Equipments.Chamber1.ToString)
                Dim extension As String = IO.Path.GetExtension(serverConfig.RateOfRiseFilename)
                Dim pathFrom As String = serverConfig.RateOfRiseFolder + "\" + serverConfig.RateOfRiseFilename
                Dim pathTo As String = AVPLib.ContainerDAO.FPath_GraphData_RateOfRise_SL & "\" & strDestFilename & IIf(String.IsNullOrEmpty(extension), String.Empty, extension)
                If Not IO.File.Exists(pathFrom) Then
                    Me.ThrowAlarm("[ROR] Failed to copy ROR data file to local directory: Source file does not exist.")
                    Return False
                End If
                If Not (Utils.CopyFile(pathFrom, pathTo)) Then
                    Me.ThrowAlarm("[ROR] Failed to copy ROR data file to local directory.")
                    Return False
                End If
                Utils.ShowStatusMessage("Rate of Rise data file copying completed successfully")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            Return True
        End Function

        Protected Function CopyPumpdownCurveData(ByVal strDestFilename As String) As Boolean
            Try
                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ConstEnum.Equipments.Chamber1.ToString)
                Dim extension As String = IO.Path.GetExtension(serverConfig.PumpdownCurveFilename)
                Dim pathFrom As String = serverConfig.PumpdownCurveFolder + "\" + serverConfig.PumpdownCurveFilename
                Dim pathTo As String = AVPLib.ContainerDAO.FPath_GraphData_PumpdownCurve_SL & "\" & strDestFilename & IIf(String.IsNullOrEmpty(extension), String.Empty, extension)
                If Not IO.File.Exists(pathFrom) Then
                    Me.ThrowAlarm("[PDC] Failed to copy PDC data file to local directory: Source file does not exist.")
                    Return False
                End If
                If Not (Utils.CopyFile(pathFrom, pathTo)) Then
                    Me.ThrowAlarm("[PDC] Failed to copy PDC data file to local directory.")
                    Return False
                End If
                Utils.ShowStatusMessage("Pumpdown Curve data file copying completed successfully")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            Return True
        End Function

        Public Function CopyDataRun(ByVal strDestFilename As String) As Boolean
            Try
                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ConstEnum.Equipments.Chamber1.ToString)

                Dim extension As String = IO.Path.GetExtension(serverConfig.DataRunFilename)
                Dim pathFrom As String = serverConfig.DataRunFolder + "\" + serverConfig.DataRunFilename
                ''Call finish Data Logging for WaferRun
                Utils.FinishDataLogging(Me.Name)

                'Check condition to copy data run. Just copy with VEECO_IBE not AVP_IBE.
                If serverConfig.Type = AllChamberType.VEECO_IBE.ToString() Then
                    '#03/10/2011 
                    '#0001337: [SL_RFE_EndUser_Mar 1, 2011]Data Output storage location is configurable so that customer can specify
                    '#their network as storage location rather than local hard drive. This is place under system->setup 
                    '#so user can store local or specify path.
                    '#Begin fix:
                    Dim pathTo As String = AVPLib.ContainerDAO.FPath_DataRunFolderConfigByUser & "\" & strDestFilename & IIf(String.IsNullOrEmpty(extension), String.Empty, extension)
                    '#End fix.
                    If Not IO.File.Exists(pathFrom) Then
                        Me.ThrowAlarm("[Wafer Processing] Failed to copy data file to local directory: Source file does not exist.")
                        Return False
                    End If

                    Try
                        IO.File.Delete(pathTo)
                    Catch
                        'force delete, do not need to check the result
                    End Try

                    If Not (Utils.CopyFile(pathFrom, pathTo)) Then
                        'Check if the file already exist after copy
                        If Not (IO.File.Exists(pathTo)) Then
                            Me.ThrowAlarm("[Wafer Processing] Failed to copy data file to local directory.")
                            Return False
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            Return True
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
            MyBase.UpdateVariableForGemWhenInit()
            Me.Fixture_Rotation_Mode_Readback = Fixture_Rotation_Mode_Readback
            Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.Name)
            objChamber.SourceUsageTimeWarning = objChamber.SourceUsageTimeWarning
            objChamber.SourceUsageTimeLimit = objChamber.SourceUsageTimeLimit
            Me.GridSerialNumber = objChamber.Grid_SerialNumber
            Me.GridID = objChamber.Grid_ID
            Me.GridRebuildLevel = objChamber.Grid_RebuildLevel
            Me.IdleThreshold = m_fIdleThreshold
        End Sub

        Private Sub CheckingSourceUsage(ByVal SourceUsage As Double)
            Try
                Dim newWarning_SourceUsage As Double
                Dim newAlarm_SourceUsage As Double
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If
                If (m_objChamberModule Is Nothing) Then
                    Exit Sub
                End If

                If IsUseMaxLimit Then
                    newWarning_SourceUsage = Math.Abs(m_objChamberModule.SourceUsageTimeWarning - m_objChamberModule.Max_KWH_Source)
                    newAlarm_SourceUsage = Math.Abs(m_objChamberModule.SourceUsageTimeLimit - m_objChamberModule.Max_KWH_Source)
                Else
                    newWarning_SourceUsage = m_objChamberModule.SourceUsageTimeWarning
                    newAlarm_SourceUsage = m_objChamberModule.SourceUsageTimeLimit
                End If
                If (SourceUsageTimeCurrent < newWarning_SourceUsage) Then
                    m_blnShowWarningKWH = False
                End If
                If (SourceUsageTimeCurrent < newAlarm_SourceUsage) Then
                    m_blnShowLimitKWH = False
                End If
                ''if source > Limit -> show Alarm
                If (SourceUsageTimeCurrent >= newAlarm_SourceUsage) And m_blnShowLimitKWH = False Then
                    Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.Name) + ": " & _
                                                      String.Format("Source Usage Is Over The Limit ({0})", _
                                                      newAlarm_SourceUsage))
                    m_blnShowLimitKWH = True
                    ''if source > Warning and not show alarm Over Limit before
                ElseIf (SourceUsageTimeCurrent >= newWarning_SourceUsage) And m_blnShowWarningKWH = False And m_blnShowLimitKWH = False Then
                    Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.Name) + ": " & _
                                  String.Format("Source Usage Is Over The Warning ({0})", _
                                  newWarning_SourceUsage))
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
