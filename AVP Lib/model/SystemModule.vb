Imports AVPLib.ConstEnum
Public Class SystemModule
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ModuleType
        NONE = 0
        IBE = 1
        'RFPVD = 2
        'DCPVD = 3
        PVD = 2
        PVDA = 3
        LoadLock = 4
        Aligner = 5
        Robot = 6
        PVD4 = 7
        DeviceNetApp = 8
        PVD5T = 9
    End Enum
    Public Enum PowerSupplyType
        DC = 1
        RF = 2
        BIAS = 3
    End Enum
    Private m_MaxNumberOfSlot As Integer = 1
    Private m_IBEType As IBEType = IBEType.AVP_IBE
    Private m_type As ModuleType
    Private m_strName As String = String.Empty
    Private m_blnVisible As Boolean = False
    Private m_intStationLocation As Integer = 1
    Private m_strModuleName As String = String.Empty
    'GAS 1
    Private m_strGas1Name As String = String.Empty
    Private m_strGas1Type As String = String.Empty
    Private m_blGas1ShutoffPresent As Boolean = False
    Private m_blGas1SupplyPresent As String = False
    Private m_blnGas1Install As Boolean = True
    'GAS 2
    Private m_strGas2Name As String = String.Empty
    Private m_strGas2Type As String = String.Empty
    Private m_blGas2ShutoffPresent As Boolean = False
    Private m_blGas2SupplyPresent As String = False
    Private m_blnGas2Install As Boolean = True
    'GAS 3
    Private m_strGas3Name As String = String.Empty
    Private m_strGas3Type As String = String.Empty
    Private m_blGas3ShutoffPresent As Boolean = False
    Private m_blGas3SupplyPresent As String = False
    Private m_blnGas3Install As Boolean = True
    'GAS 4
    Private m_strGas4Name As String = String.Empty
    Private m_strGas4Type As String = String.Empty
    Private m_blGas4ShutoffPresent As Boolean = False
    Private m_blGas4SupplyPresent As String = False
    Private m_blnGas4Install As Boolean = True
    'GAS 5
    Private m_strGas5Name As String = String.Empty
    Private m_strGas5Type As String = String.Empty
    Private m_blGas5ShutoffPresent As Boolean = False
    Private m_blGas5SupplyPresent As String = False
    Private m_blnGas5Install As Boolean = True
    Private m_blnMGVisible As Boolean = False
    Private m_blnCGVisible As Boolean = False

    'GAS 5
    Private m_blnGasInjectionInstall As Boolean = False
    Private m_blnSupportMainSecondDistributionValves As Boolean = False
    'Power supply
    Private m_blnDCTargetPowerVisible As Boolean = False
    Private m_DCTargetPowerModel As Power_Supply_Model = Power_Supply_Model.ENI_1250
    Private m_RFTargetPowerModel As Power_Supply_Model = Power_Supply_Model.ENI_1250
    Private m_BiasPowerModel As Power_Supply_Model = Power_Supply_Model.ENI_1250
    Private m_blnRFTargetPowerVisible As Boolean = False
    Private m_blnBiasPowerVisible As Boolean = False
    Private m_blnMagnatronVisible As Boolean = False

    'Interlock
    Private m_blnChamberInterlock_TurboWaterVisible As Boolean = False
    Private m_blnChamberInterlock_TurboForelineVisible As Boolean = False
    Private m_blnChamberInterlock_TableWaterVisible As Boolean = False
    Private m_blnChamberInterlock_LidSensorVisible As Boolean = False
    Private m_blnChamberInterlock_MatchWaterVisible As Boolean = False
    Private m_blnChamberInterlock_TargetWaterVisible As Boolean = False
    Private m_blnChamberInterlock_LidWaterVisible As Boolean = False
    Private m_blnChamberInterlock_TargetMBWaterVisible As Boolean = False
    Private m_blnChamberInterlock_ClampWaterVisible As Boolean = False
    Private m_blnChamberInterlock_SubMBWaterVisible As Boolean = False
    Private m_blnWaterValveInstalled As Boolean = False
    Private m_blnMain_Gas_ShutOff_Valve_Installed As Boolean = False

    '
    Private m_blnIGIsoValveInstalled As Boolean = False
    'Spec GAS
    Private m_strPBNGasName As String = String.Empty
    Private m_strPBNGasType As String = String.Empty
    Private m_blPBNGasShutoffPresent As Boolean = False
    Private m_blPBNGasSupplyPresent As String = False
    Private m_blnPBNGasInstall As Boolean = True

    Private m_strFlowcoolGasName As String = String.Empty
    Private m_strFlowcoolGasType As String = String.Empty
    Private m_blFlowcoolGasShutoffPresent As Boolean = False
    Private m_blFlowcoolGasSupplyPresent As String = False
    Private m_blnFlowcoolGasInstall As Boolean = True


    Private m_blnParallelMagnetVisible As Boolean = False

    Private m_blnShutterVisible As Boolean = False

    Private m_blnFilament_Installed As Boolean = False
    Private m_blnClampInstalled As Boolean = False
    Private m_blnANCInstalled As Boolean = False
    Private m_dblLitter_Value As Double = 1
    Private m_IonGaugeFirmwareModel As Double = 1
    Private m_IonGaugeEmissionCurrent As Double = 1
    Private m_IonGaugeType As String = String.Empty
    Private m_Filament As Double = 1
    Private m_blnWaterPumpVisible As Boolean = False
    Private m_blnRegenParamSupport As Boolean = False
    Private m_blnTurboPumpVisible As Boolean = False
    Private m_blnTurboMPVisible As Boolean = True
    Private m_blnCryoVisible As Boolean = False
    Private m_blnChillerVisible As Boolean = False
    Private m_blnChillerModel As String = String.Empty
    Private m_blnVatValveControllerVisible As Boolean = False
    Private m_blnAutoZeroVatValveVisible As Boolean = False
    Private m_blnIsExtraInterlock As Boolean = False
    Private m_hstTargetPresetValue As Hashtable
    Private m_hstBiasPresetValue As Hashtable
    Private m_hstIBESourceValue As Hashtable
    Private m_dblAlarmKWH As Double = 0
    Private m_dblAlarmKWH1 As Double = 0
    Private m_dblAlarmKWH2 As Double = 0
    Private m_dblAlarmKWH3 As Double = 0
    Private m_dblAlarmKWH4 As Double = 0
    Private m_dblWarningKWH As Double = 0
    Private m_dblWarningKWH1 As Double = 0
    Private m_dblWarningKWH2 As Double = 0
    Private m_dblWarningKWH3 As Double = 0
    Private m_dblWarningKWH4 As Double = 0
    Private m_dblMaxKWH As Double = 0
    Private m_dblMaxKWH1 As Double = 0
    Private m_dblMaxKWH2 As Double = 0
    Private m_dblMaxKWH3 As Double = 0
    Private m_dblMaxKWH4 As Double = 0
    Private m_strTarget_Material As String = String.Empty
    Private m_strTarget_Material1 As String = String.Empty
    Private m_strTarget_Material2 As String = String.Empty
    Private m_strTarget_Material3 As String = String.Empty
    Private m_strTarget_Material4 As String = String.Empty
    Private m_blnPumpPurge As Boolean = False
    Private m_blnReal_Device_Enable As Boolean = False
    'Device Net'
    Private m_dblChuckatPumpDownPostion As Single = 1.4
    Private m_blnPM_DeviceNet As Boolean = False
    'Cryo, WaterPump installed
    Private m_blnWaterPumpInstalled As Boolean = False
    Private m_blnCryoInstalled As Boolean = False
    Private m_dblSL_ATM_Pressure As Double = 760
    Private m_dblSL_VAC_CG_Pressure As Double = 0.1
    Private m_dblEtch_Rate As Double = 1
    Private m_strGrid_SerialNumber As String = String.Empty
    Private m_strGrid_ID As String = String.Empty
    Private m_intGrid_RebuildLevel As Integer = 0
    '#03/09/2011 
    '#0001335: [SL_RFE_EndUser_Mar 1 ,2011]Source usage warning/and limit before and during process run. 
    '#Begin fix:
    Private m_SourceUsageTime As Double = 0
    Private m_SourceUsageTimeWarning As Double = 0
    Private m_SourceUsageTimeLimit As Double = 0
    '#End fix.

    '<2015-06-19: Hai Tran
    Private m_Max_KWH_ShieldsQuartz As Double = 0
    Private m_ShieldsQuartzWarning As Double = 0
    Private m_ShieldsQuartzLimit As Double = 0
    Private m_Max_KWH_ShieldsQuartz1 As Double = 0
    Private m_ShieldsQuartzWarning1 As Double = 0
    Private m_ShieldsQuartzLimit1 As Double = 0
    Private m_Max_KWH_ShieldsQuartz2 As Double = 0
    Private m_ShieldsQuartzWarning2 As Double = 0
    Private m_ShieldsQuartzLimit2 As Double = 0
    Private m_Max_KWH_ShieldsQuartz3 As Double = 0
    Private m_ShieldsQuartzWarning3 As Double = 0
    Private m_ShieldsQuartzLimit3 As Double = 0
    Private m_Max_KWH_ShieldsQuartz4 As Double = 0
    Private m_ShieldsQuartzWarning4 As Double = 0
    Private m_ShieldsQuartzLimit4 As Double = 0

    'IBE
    Private m_blnSourceMagnetVisible As Boolean = False
    Private m_blnSupportPBNBodyDischargeVoltage As Boolean = False
    Private m_blnTiltAngleReferenceAsLegacy As Boolean = False
    Private m_blnVerifyTiltSensorAtPosition As Boolean = False
    Private m_strVerifiedAngle As String = String.Empty
    Private m_dSystemInterlockGas1Minimum As Double = 0
    Private m_dSystemInterlockGas2Minimum As Double = 0
    Private m_dSystemInterlockGas3Minimum As Double = 0
    Private m_dSystemInterlockGas4Minimum As Double = 0
    Private m_blnInternalShutter_Installed As Boolean = False
    Private m_blnDiverterGasValveVisible As Boolean = False
    Private m_blnEndPointUnitVisible As Boolean = False
    Private m_blnChamberInterlock_FixtureWaterBugVisible As Boolean = False
    Private m_blnChamberInterlock_FixtureWaterVisible As Boolean = False
    Private m_blnShutterOnFixtureUsedByGalilVisible As Boolean = False
    Private m_blnChamberInterlock_SourceWaterVisible As Boolean = False
    Private m_blnChamberInterlock_PanelInterlockVisible As Boolean = False
    Private m_blnChamberInterlock_AirPressureVisible As Boolean = False
    Private m_blnChamberInterlock_ChamberPressureVisible As Boolean = False
    Private m_blnChamberInterlock_ForelinePressureVisible As Boolean = False
    Private m_blSupportTiltSweepMode As Boolean = False
    Private m_blFastTiltInstalled As Boolean = False
    Private m_blBackTilt_Installed As Boolean = False

    'TSD
    Private m_TargetToHomeDistance As Double = 0
    '>

    Private m_strTurboPumpModel As TurboPump_Model = TurboPump_Model.RSTi

#Region "Private Variable for Corona"
    Private m_blnShutter2Visible As Boolean = False
    Private m_blnShutter3Visible As Boolean = False
    Private m_blnShutter4Visible As Boolean = False
    Private m_blnShutter5Visible As Boolean = False

    Private m_blnTargetVisible As Boolean = False
    Private m_blnTarget2Visible As Boolean = False
    Private m_blnTarget3Visible As Boolean = False
    Private m_blnTarget4Visible As Boolean = False
    Private m_blnTarget5Visible As Boolean = False


    'Private m_blnInterlock_TurboWater_Visible As Boolean = False -> Same above m_blnChamberInterlock_TurboWaterVisible
    'Private m_blnInterlock_Matchbox1Water_Visible As Boolean = False -> Same above m_blnChamberInterlock_TargetMBWaterVisible
    Private m_blnInterlock_Matchbox2Water_Visible As Boolean = False
    Private m_blnInterlock_Target13Water_Visible As Boolean = False
    Private m_blnInterlock_Target24Water_Visible As Boolean = False
    Private m_blnInterlock_SubstrateTableWater_Visible As Boolean = False
    Private m_blnInterlock_AirPressure_Visible As Boolean = False
    Private m_blnInterlock_Target_Matchbox_Water_Visible As Boolean = False
    Private m_blnInterlock_Bias_Matchbox_Water_Visible As Boolean = False

    Private m_blnHeaterZone1Installed As Boolean = False
    Private m_blnHeaterZone2Installed As Boolean = False
    Private m_blnFilMetricDeviceInstalled As Boolean = False
    Private m_blnWaferLiftInstalled As Boolean = False
    Private m_blnChuckPositionTSDRef As Boolean = False
#End Region
    Public Structure PresetTable
        Public ID As String
        Public C1 As String
        Public C2 As String
    End Structure
    Public Structure IBESourceData
        Public Value As String
        Public Name As String
    End Structure
    Public Enum Power_Supply_Model
        ENI_1250
        ENI_2000
        MKS_3513
        ENI_RPG_50_100
        Seren_RLX01
        ENI_DCG_100
        ENI_RPG50
        ENI_RPG100
        ENI_DCG50
        ENI_DCG100
        SEREN_R2001
        SEREN_HR1001
        SEREN_HR3001
        SEREN_HR5001
        SEREN_R10001
        SEREN_ATS30
        OPC_RF_PowerSupply
        AE_PULSE_DC
        AE_CESAR_1330
        RSTi_RF_PowerSupply
    End Enum

    Public Enum TurboPump_Model
        RSTi
        Leybold
        Shimadzu
    End Enum

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2020-03-10 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set WhichModel of TurboPump
    ''' </summary>
    ''' <remarks></remarks>
    Public Property TurboPumpModel() As TurboPump_Model
        Get
            Return m_strTurboPumpModel
        End Get
        Set(ByVal value As TurboPump_Model)
            m_strTurboPumpModel = value
        End Set
    End Property
   
   'store Value from config File
    Public Property IBE_Type() As IBEType
        Get
            Return m_IBEType
        End Get
        Set(ByVal value As IBEType)
            m_IBEType = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Module Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ModuleName() As String
        Get
            Return m_strModuleName
        End Get
        Set(ByVal value As String)
            m_strModuleName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Type of PVD
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Real_Device_Enable() As Boolean
        Get
            Return m_blnReal_Device_Enable
        End Get
        Set(ByVal value As Boolean)
            m_blnReal_Device_Enable = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2010-1-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set PM is Device Net or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PVD_Chuck_At_PumpDown_Postion() As Single
        Get
            Return m_dblChuckatPumpDownPostion
        End Get
        Set(ByVal value As Single)
            m_dblChuckatPumpDownPostion = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-09 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set SL Autoload Unload Delay Time
    ''' </summary>
    ''' <remarks></remarks>
    Dim m_iSL_AutoLoad_Unload_Delay_Time As Integer = 0
    Public Property SL_AutoLoad_Unload_Delay_Time() As Integer
        Get
            Return m_iSL_AutoLoad_Unload_Delay_Time
        End Get
        Set(ByVal value As Integer)
            m_iSL_AutoLoad_Unload_Delay_Time = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2010-1-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set PM is Device Net or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PM_DeviceNet() As Boolean
        Get
            Return m_blnPM_DeviceNet
        End Get
        Set(ByVal value As Boolean)
            m_blnPM_DeviceNet = value
        End Set
    End Property
    '''' <author>
    ''''    	<name> Hoa Nguyen </name>
    ''''    	<date> 2010-1-12 </date>
    '''' </author>
    '''' <summary>
    '''' Get or Set Cryo installed or not
    '''' </summary>
    '''' <remarks></remarks>
    'Public Property CryoInstalled() As Boolean
    '    Get
    '        Return m_blnCryoInstalled
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_blnCryoInstalled = value
    '    End Set
    'End Property
    '''' <author>
    ''''    	<name> Hoa Nguyen </name>
    ''''    	<date> 2010-1-11 </date>
    '''' </author>
    '''' <summary>
    '''' Get or Set WP installed or not
    '''' </summary>
    '''' <remarks></remarks>
    'Public Property WaterPumpInstalled() As Boolean
    '    Get
    '        Return m_blnWaterPumpInstalled
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_blnWaterPumpInstalled = value
    '    End Set
    'End Property
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2010-1-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ATM Pressure
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SL_ATM_Pressure() As Double
        Get
            Return m_dblSL_ATM_Pressure
        End Get
        Set(ByVal value As Double)
            m_dblSL_ATM_Pressure = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-09 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Source Usage Current
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SourceUsageTime() As Double
        Get
            Return m_SourceUsageTime
        End Get
        Set(ByVal value As Double)
            m_SourceUsageTime = value
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
            ' Update SECS/GEM variables by Hoa Nguyen
            ' Var Name: PMx.SourceWarning
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), _
                                EMSERVICELib.VarType.SV, "SourceWarning", VALUELib.ValueType.F4, value)
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
            ' Update SECS/GEM variables by Hoa Nguyen
            ' Var Name: PMx.SourceLimit
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), _
                                EMSERVICELib.VarType.SV, "SourceLimit", VALUELib.ValueType.F4, value)
        End Set
    End Property

    Private m_fIdleThreshold As Double = 48 ' 48 hours
    Public Property IdleThreshold() As Double
        Get
            Return m_fIdleThreshold
        End Get
        Set(ByVal value As Double)
            m_fIdleThreshold = value
        End Set
    End Property

    Private m_strWarmUpRecipe As String = String.Empty
    Public Property WarmUpRecipe() As String
        Get
            Return m_strWarmUpRecipe
        End Get
        Set(ByVal value As String)
            m_strWarmUpRecipe = value
        End Set
    End Property

    Private m_LastExecution As Date = #1/1/1990 1:00:00 AM#
    Public Property LastExecution() As Date
        Get
            Return m_LastExecution
        End Get
        Set(ByVal value As Date)
            m_LastExecution = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2010-04-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Use Lot System ID
    ''' </summary>
    ''' <remarks></remarks>
    Private m_blnUseLotSystemID As Boolean = False
    Public Property UseLotSystemID() As Boolean
        Get
            Return m_blnUseLotSystemID
        End Get
        Set(ByVal value As Boolean)
            m_blnUseLotSystemID = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2010-06-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Logging Interval
    ''' </summary>
    ''' <remarks></remarks>
    Private m_iLoggingInterval As Integer = 1
    Public Property LoggingInterval() As Integer
        Get
            Return m_iLoggingInterval
        End Get
        Set(ByVal value As Integer)
            m_iLoggingInterval = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2010-04-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set System Warm Up
    ''' </summary>
    ''' <remarks></remarks>
    Private m_blnUseSystemWarmUp As Boolean = False
    Public Property UseSystemWarmUp() As Boolean
        Get
            Return m_blnUseSystemWarmUp
        End Get
        Set(ByVal value As Boolean)
            m_blnUseSystemWarmUp = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2010-1-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set VAC IG Pressure
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SL_VAC_CG_Pressure() As Double
        Get
            Return m_dblSL_VAC_CG_Pressure
        End Get
        Set(ByVal value As Double)
            m_dblSL_VAC_CG_Pressure = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Type of PVD
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Target_Material() As String
        Get
            Return m_strTarget_Material
        End Get
        Set(ByVal value As String)
            m_strTarget_Material = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target1_Material", VALUELib.ValueType.A, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-01-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Type of PVD/CORONA
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Target_Material1() As String
        Get
            Return m_strTarget_Material1
        End Get
        Set(ByVal value As String)
            m_strTarget_Material1 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target2_Material", VALUELib.ValueType.A, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-01-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Type of PVD/CORONA
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Target_Material2() As String
        Get
            Return m_strTarget_Material2
        End Get
        Set(ByVal value As String)
            m_strTarget_Material2 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target3_Material", VALUELib.ValueType.A, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-01-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Type of PVD/CORONA
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Target_Material3() As String
        Get
            Return m_strTarget_Material3
        End Get
        Set(ByVal value As String)
            m_strTarget_Material3 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target4_Material", VALUELib.ValueType.A, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2025-11-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Type of PVD5T
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Target_Material4() As String
        Get
            Return m_strTarget_Material4
        End Get
        Set(ByVal value As String)
            m_strTarget_Material4 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target5_Material", VALUELib.ValueType.A, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Max KWH
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PumpPurge() As Boolean
        Get
            Return m_blnPumpPurge
        End Get
        Set(ByVal value As Boolean)
            m_blnPumpPurge = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Max KWH
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Alarm_KWH() As Double
        Get
            Return m_dblAlarmKWH
        End Get
        Set(ByVal value As Double)
            m_dblAlarmKWH = value
            ' Update SECS/GEM variables by Hoa Nguyen
            ' Var Name: PMx.KWHLitmit
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), _
                                EMSERVICELib.VarType.SV, "Target1_KWH_Limit", VALUELib.ValueType.F4, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Max KWH
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Warning_KWH() As Double
        Get
            Return m_dblWarningKWH
        End Get
        Set(ByVal value As Double)
            m_dblWarningKWH = value
            ' Update SECS/GEM variables by Hoa Nguyen
            ' Var Name: PMx.KWHWarning
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target1_KWH_Warning", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-01-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Alarm KWH 1
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Alarm_KWH1() As Double
        Get
            Return m_dblAlarmKWH1
        End Get
        Set(ByVal value As Double)
            m_dblAlarmKWH1 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target2_KWH_Limit", VALUELib.ValueType.F4, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-01-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Alarm KWH 2
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Alarm_KWH2() As Double
        Get
            Return m_dblAlarmKWH2
        End Get
        Set(ByVal value As Double)
            m_dblAlarmKWH2 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target3_KWH_Limit", VALUELib.ValueType.F4, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-01-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Alarm KWH 3
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Alarm_KWH3() As Double
        Get
            Return m_dblAlarmKWH3
        End Get
        Set(ByVal value As Double)
            m_dblAlarmKWH3 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target4_KWH_Limit", VALUELib.ValueType.F4, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2025-11-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Alarm KWH 4
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Alarm_KWH4() As Double
        Get
            Return m_dblAlarmKWH4
        End Get
        Set(ByVal value As Double)
            m_dblAlarmKWH4 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target5_KWH_Limit", VALUELib.ValueType.F4, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-01-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Warning KWH 1
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Warning_KWH1() As Double
        Get
            Return m_dblWarningKWH1
        End Get
        Set(ByVal value As Double)
            m_dblWarningKWH1 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target2_KWH_Warning", VALUELib.ValueType.F4, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-01-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Warning KWH 2
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Warning_KWH2() As Double
        Get
            Return m_dblWarningKWH2
        End Get
        Set(ByVal value As Double)
            m_dblWarningKWH2 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target3_KWH_Warning", VALUELib.ValueType.F4, value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-01-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Warning KWH 3
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Warning_KWH3() As Double
        Get
            Return m_dblWarningKWH3
        End Get
        Set(ByVal value As Double)
            m_dblWarningKWH3 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target4_KWH_Warning", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2025-11-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Warning KWH 4
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Warning_KWH4() As Double
        Get
            Return m_dblWarningKWH4
        End Get
        Set(ByVal value As Double)
            m_dblWarningKWH4 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target5_KWH_Warning", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-12-25 </date>
    ''' </author>
    ''' <summary>
    ''' Max Number Of Slot = 1 - 8, only corona chamber
    ''' </summary>
    ''' <remarks></remarks>
    Public Property MaxNumberOfSlot() As Integer
        Get
            Return m_MaxNumberOfSlot
        End Get
        Set(ByVal value As Integer)
            m_MaxNumberOfSlot = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Max KWH
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Etch_Rate() As Double
        Get
            Return m_dblEtch_Rate
        End Get
        Set(ByVal value As Double)
            m_dblEtch_Rate = value
        End Set
    End Property


    ''' <author>
    '''    	<name>Tri Do</name>
    '''    	<date> 2013-11-129 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Grid Serial Number
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Grid_SerialNumber() As String
        Get
            Return m_strGrid_SerialNumber
        End Get
        Set(ByVal value As String)
            m_strGrid_SerialNumber = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Huy Nguyen</name>
    '''    	<date> 2013-12-03 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Grid ID
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Grid_ID() As String
        Get
            Return m_strGrid_ID
        End Get
        Set(ByVal value As String)
            m_strGrid_ID = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Huy Nguyen</name>
    '''    	<date> 2013-12-03 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Grid rebuild level
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Grid_RebuildLevel() As Integer
        Get
            Return m_intGrid_RebuildLevel
        End Get
        Set(ByVal value As Integer)
            m_intGrid_RebuildLevel = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Max KWH
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Max_KWH_Source() As Double
        Get
            Return m_dblMaxKWH
        End Get
        Set(ByVal value As Double)
            m_dblMaxKWH = value
        End Set
    End Property
    Public Property Max_KWH_Source1() As Double
        Get
            Return m_dblMaxKWH1
        End Get
        Set(ByVal value As Double)
            m_dblMaxKWH1 = value
        End Set
    End Property
    Public Property Max_KWH_Source2() As Double
        Get
            Return m_dblMaxKWH2
        End Get
        Set(ByVal value As Double)
            m_dblMaxKWH2 = value
        End Set
    End Property
    Public Property Max_KWH_Source3() As Double
        Get
            Return m_dblMaxKWH3
        End Get
        Set(ByVal value As Double)
            m_dblMaxKWH3 = value
        End Set
    End Property
    Public Property Max_KWH_Source4() As Double
        Get
            Return m_dblMaxKWH4
        End Get
        Set(ByVal value As Double)
            m_dblMaxKWH4 = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set TargetPresetValue
    ''' </summary>
    ''' <remarks></remarks>
    Public Property TargetPresetValue() As Hashtable
        Get
            If m_hstTargetPresetValue Is Nothing Then
                m_hstTargetPresetValue = New Hashtable()
            End If
            Return m_hstTargetPresetValue
        End Get
        Set(ByVal value As Hashtable)
            m_hstTargetPresetValue = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set TargetPresetValue
    ''' </summary>
    ''' <remarks></remarks>
    Public Property BiasPresetValue() As Hashtable
        Get
            If m_hstBiasPresetValue Is Nothing Then
                m_hstBiasPresetValue = New Hashtable
            End If
            Return m_hstBiasPresetValue
        End Get
        Set(ByVal value As Hashtable)
            m_hstBiasPresetValue = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set TargetPresetValue
    ''' </summary>
    ''' <remarks></remarks>
    Public Property IBESourceValue() As Hashtable
        Get
            If m_hstIBESourceValue Is Nothing Then
                m_hstIBESourceValue = New Hashtable
            End If
            Return m_hstIBESourceValue
        End Get
        Set(ByVal value As Hashtable)
            m_hstIBESourceValue = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Type of PVD
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Type() As ModuleType
        Get
            Return m_type
        End Get
        Set(ByVal value As ModuleType)
            m_type = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Name of PVD
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return m_strName
        End Get
        Set(ByVal value As String)
            m_strName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property IsVisible() As Boolean
        Get
            Return m_blnVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnVisible = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property StationLocation() As Integer
        Get
            Return m_intStationLocation
        End Get
        Set(ByVal value As Integer)
            m_intStationLocation = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas1Name() As String
        Get
            Return m_strGas1Name
        End Get
        Set(ByVal value As String)
            m_strGas1Name = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-06-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas1 Type
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas1Type() As String
        Get
            Return m_strGas1Type
        End Get
        Set(ByVal value As String)
            m_strGas1Type = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' Gas1 Shutoff valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas1ShutoffPresent() As Boolean
        Get
            Return m_blGas1ShutoffPresent
        End Get
        Set(ByVal value As Boolean)
            m_blGas1ShutoffPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' Gas1 Supply valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas1SupplyPresent() As Boolean
        Get
            Return m_blGas1SupplyPresent
        End Get
        Set(ByVal value As Boolean)
            m_blGas1SupplyPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas2Name() As String
        Get
            Return m_strGas2Name
        End Get
        Set(ByVal value As String)
            m_strGas2Name = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-06-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas2 Type
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas2Type() As String
        Get
            Return m_strGas2Type
        End Get
        Set(ByVal value As String)
            m_strGas2Type = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' gas2 Shutoff valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property gas2ShutoffPresent() As Boolean
        Get
            Return m_blGas2ShutoffPresent
        End Get
        Set(ByVal value As Boolean)
            m_blGas2ShutoffPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' Gas1 Supply valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas2SupplyPresent() As Boolean
        Get
            Return m_blGas2SupplyPresent
        End Get
        Set(ByVal value As Boolean)
            m_blGas2SupplyPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas3Name() As String
        Get
            Return m_strGas3Name
        End Get
        Set(ByVal value As String)
            m_strGas3Name = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-06-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas3 Type
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas3Type() As String
        Get
            Return m_strGas3Type
        End Get
        Set(ByVal value As String)
            m_strGas3Type = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' gas3 Shutoff valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property gas3ShutoffPresent() As Boolean
        Get
            Return m_blGas3ShutoffPresent
        End Get
        Set(ByVal value As Boolean)
            m_blGas3ShutoffPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' Gas1 Supply valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas3SupplyPresent() As Boolean
        Get
            Return m_blGas3SupplyPresent
        End Get
        Set(ByVal value As Boolean)
            m_blGas3SupplyPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas4Name() As String
        Get
            Return m_strGas4Name
        End Get
        Set(ByVal value As String)
            m_strGas4Name = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-06-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas4 Type
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas4Type() As String
        Get
            Return m_strGas4Type
        End Get
        Set(ByVal value As String)
            m_strGas4Type = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' gas4 Shutoff valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property gas4ShutoffPresent() As Boolean
        Get
            Return m_blGas4ShutoffPresent
        End Get
        Set(ByVal value As Boolean)
            m_blGas4ShutoffPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' Gas4 Supply valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas4SupplyPresent() As Boolean
        Get
            Return m_blGas4SupplyPresent
        End Get
        Set(ByVal value As Boolean)
            m_blGas4SupplyPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' gas5 Shutoff valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property gas5ShutoffPresent() As Boolean
        Get
            Return m_blGas5ShutoffPresent
        End Get
        Set(ByVal value As Boolean)
            m_blGas5ShutoffPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' Gas5 Supply valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas5SupplyPresent() As Boolean
        Get
            Return m_blGas5SupplyPresent
        End Get
        Set(ByVal value As Boolean)
            m_blGas5SupplyPresent = value
        End Set
    End Property


    Public Property Gas1Install() As Boolean
        Get
            Return m_blnGas1Install
        End Get
        Set(ByVal value As Boolean)
            m_blnGas1Install = value
        End Set
    End Property

    Public Property Gas2Install() As Boolean
        Get
            Return m_blnGas2Install
        End Get
        Set(ByVal value As Boolean)
            m_blnGas2Install = value
        End Set
    End Property

    Public Property Gas3Install() As Boolean
        Get
            Return m_blnGas3Install
        End Get
        Set(ByVal value As Boolean)
            m_blnGas3Install = value
        End Set
    End Property

    Public Property Gas4Install() As Boolean
        Get
            Return m_blnGas4Install
        End Get
        Set(ByVal value As Boolean)
            m_blnGas4Install = value
        End Set
    End Property

    Public Property Gas5Install() As Boolean
        Get
            Return m_blnGas5Install
        End Get
        Set(ByVal value As Boolean)
            m_blnGas5Install = value
        End Set
    End Property

    Public Property GasInjectionInstall() As Boolean
        Get
            Return m_blnGasInjectionInstall
        End Get
        Set(ByVal value As Boolean)
            m_blnGasInjectionInstall = value
        End Set
    End Property
    Public Property IsSupportMainSecondDistributionValves() As Boolean
        Get
            Return m_blnSupportMainSecondDistributionValves
        End Get
        Set(ByVal value As Boolean)
            m_blnSupportMainSecondDistributionValves = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-08-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set IGIsoValveInstalled
    ''' </summary>
    ''' <remarks></remarks>
    Public Property IGIsoValveInstalled() As Boolean
        Get
            Return m_blnIGIsoValveInstalled
        End Get
        Set(ByVal value As Boolean)
            m_blnIGIsoValveInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas5Name() As String
        Get
            Return m_strGas5Name
        End Get
        Set(ByVal value As String)
            m_strGas5Name = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-06-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5 Type
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas5Type() As String
        Get
            Return m_strGas5Type
        End Get
        Set(ByVal value As String)
            m_strGas5Type = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property MGVisible() As Boolean
        Get
            Return m_blnMGVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnMGVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property CGVisible() As Boolean
        Get
            Return m_blnCGVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnCGVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property DCTargetPowerVisible() As Boolean
        Get
            Return m_blnDCTargetPowerVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnDCTargetPowerVisible = value
        End Set
    End Property

    Public Property DCTargetPowerModel() As Power_Supply_Model
        Get
            Return m_DCTargetPowerModel
        End Get
        Set(ByVal value As Power_Supply_Model)
            m_DCTargetPowerModel = value
        End Set
    End Property

    Public Property RFTargetPowerVisible() As Boolean
        Get
            Return m_blnRFTargetPowerVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnRFTargetPowerVisible = value
        End Set
    End Property

    Public Property RFTargetPowerModel() As Power_Supply_Model
        Get
            Return m_RFTargetPowerModel
        End Get
        Set(ByVal value As Power_Supply_Model)
            m_RFTargetPowerModel = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property BiasPowerVisible() As Boolean
        Get
            Return m_blnBiasPowerVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnBiasPowerVisible = value
        End Set
    End Property

    Public Property BiasPowerModel() As Power_Supply_Model
        Get
            Return m_BiasPowerModel
        End Get
        Set(ByVal value As Power_Supply_Model)
            m_BiasPowerModel = value
        End Set
    End Property

    Private m_blnMPumpSerialVisible As Boolean = False
    Public Property MPumpSerialVisible() As Boolean
        Get
            Return m_blnMPumpSerialVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnMPumpSerialVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property MagnatronVisible() As Boolean
        Get
            Return m_blnMagnatronVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnMagnatronVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ChamberInterlock_TurboWaterVisible() As Boolean
        Get
            Return m_blnChamberInterlock_TurboWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_TurboWaterVisible = value
        End Set
    End Property

    Public Property ChamberInterlock_TurboForelineVisible() As Boolean
        Get
            Return m_blnChamberInterlock_TurboForelineVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_TurboForelineVisible = value
        End Set
    End Property

    'Public Property ChamberInterlock_TableWaterVisible() As Boolean
    '    Get
    '        Return m_blnChamberInterlock_TableWaterVisible
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_blnChamberInterlock_TableWaterVisible = value
    '    End Set
    'End Property

    Public Property ChamberInterlock_LidSensorVisible() As Boolean
        Get
            Return m_blnChamberInterlock_LidSensorVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_LidSensorVisible = value
        End Set
    End Property

    'Public Property ChamberInterlock_MatchWaterVisible() As Boolean
    '    Get
    '        Return m_blnChamberInterlock_MatchWaterVisible
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_blnChamberInterlock_MatchWaterVisible = value
    '    End Set
    'End Property

    Public Property ChamberInterlock_TargetWaterVisible() As Boolean
        Get
            Return m_blnChamberInterlock_TargetWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_TargetWaterVisible = value
        End Set
    End Property

    Public Property ChamberInterlock_LidWaterVisible() As Boolean
        Get
            Return m_blnChamberInterlock_LidWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_LidWaterVisible = value
        End Set
    End Property
    ''
    Public Property ChamberInterlock_TargetMBWaterVisible() As Boolean
        Get
            Return m_blnChamberInterlock_TargetMBWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_TargetMBWaterVisible = value
        End Set
    End Property

    Public Property ChamberInterlock_ClampWaterVisible() As Boolean
        Get
            Return m_blnChamberInterlock_ClampWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_ClampWaterVisible = value
        End Set
    End Property

    Public Property ChamberInterlock_SubMBWaterVisible() As Boolean
        Get
            Return m_blnChamberInterlock_SubMBWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_SubMBWaterVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ParallelMagnetVisible() As Boolean
        Get
            Return m_blnParallelMagnetVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnParallelMagnetVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Litter_Value() As Double
        Get
            Return m_dblLitter_Value
        End Get
        Set(ByVal value As Double)
            m_dblLitter_Value = value
        End Set
    End Property
    Public Property IonGaugeFirmwareModel() As Double
        Get
            Return m_IonGaugeFirmwareModel
        End Get
        Set(ByVal value As Double)
            m_IonGaugeFirmwareModel = value
        End Set
    End Property
    Public Property IonGaugeEmissionCurrent() As Double
        Get
            Return m_IonGaugeEmissionCurrent
        End Get
        Set(ByVal value As Double)
            m_IonGaugeEmissionCurrent = value
        End Set
    End Property
    Public Property IonGaugeType() As String
        Get
            Return m_IonGaugeType
        End Get
        Set(ByVal value As String)
            m_IonGaugeType = value
        End Set
    End Property
    Public Property Filament() As Double
        Get
            Return m_Filament
        End Get
        Set(ByVal value As Double)
            m_Filament = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Main_Gas_Valve_Installed() As Boolean
        Get
            Return m_blnMain_Gas_ShutOff_Valve_Installed
        End Get
        Set(ByVal value As Boolean)
            m_blnMain_Gas_ShutOff_Valve_Installed = value
        End Set
    End Property

    Public Property WaterValveInstalled() As Boolean
        Get
            Return m_blnWaterValveInstalled
        End Get
        Set(ByVal value As Boolean)
            m_blnWaterValveInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ClampInstalled() As Boolean
        Get
            Return m_blnClampInstalled
        End Get
        Set(ByVal value As Boolean)
            m_blnClampInstalled = value
        End Set
    End Property
   
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShutterVisible() As Boolean
        Get
            Return m_blnShutterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnShutterVisible = value
        End Set
    End Property

    Private m_blnFixtureShutterVisible As Boolean = False
    Public Property FixtureShutterVisible() As Boolean
        Get
            Return m_blnFixtureShutterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnFixtureShutterVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Filament_Installed() As Boolean
        Get
            Return m_blnFilament_Installed
        End Get
        Set(ByVal value As Boolean)
            m_blnFilament_Installed = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaterPumpVisible() As Boolean
        Get
            Return m_blnWaterPumpVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnWaterPumpVisible = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tinh Le</name>
    '''    	<date> 2021-11-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    Private m_blnIGFilamentVisible As Boolean = True
    Public Property IGFilamentVisible() As Boolean
        Get
            Return m_blnIGFilamentVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnIGFilamentVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2016-1-14 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property RegenParamSupport() As Boolean
        Get
            Return m_blnRegenParamSupport
        End Get
        Set(ByVal value As Boolean)
            m_blnRegenParamSupport = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property TurboPumpVisible() As Boolean
        Get
            Return m_blnTurboPumpVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTurboPumpVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property TurboMPVisible() As Boolean
        Get
            Return m_blnTurboMPVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTurboMPVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property CryoVisible() As Boolean
        Get
            Return m_blnCryoVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnCryoVisible = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property VatValveControllerVisible() As Boolean
        Get
            Return m_blnVatValveControllerVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnVatValveControllerVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property AutoZeroVatValveVisible() As Boolean
        Get
            Return m_blnAutoZeroVatValveVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnAutoZeroVatValveVisible = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-04-04 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set PBNGas Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PBNGasName() As String
        Get
            Return m_strPBNGasName
        End Get
        Set(ByVal value As String)
            m_strPBNGasName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-04-04 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set PBNGas Type
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PBNGasType() As String
        Get
            Return m_strPBNGasType
        End Get
        Set(ByVal value As String)
            m_strPBNGasType = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2021-10-11 </date>
    ''' </author>
    ''' <summary>
    ''' Gas1 Shutoff valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PBNGasShutoffPresent() As Boolean
        Get
            Return m_blPBNGasShutoffPresent
        End Get
        Set(ByVal value As Boolean)
            m_blPBNGasShutoffPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2021-10-11 </date>
    ''' </author>
    ''' <summary>
    ''' Gas1 Supply valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PBNGasSupplyPresent() As Boolean
        Get
            Return m_blPBNGasSupplyPresent
        End Get
        Set(ByVal value As Boolean)
            m_blPBNGasSupplyPresent = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2021-10-11 </date>
    ''' </author>
    ''' <summary>
    ''' Gas1 Supply valve is install 
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PBNGasInstall() As Boolean
        Get
            Return m_blnPBNGasInstall
        End Get
        Set(ByVal value As Boolean)
            m_blnPBNGasInstall = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-04-04 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set FlowcoolGas Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property FlowcoolGasName() As String
        Get
            Return m_strFlowcoolGasName
        End Get
        Set(ByVal value As String)
            m_strFlowcoolGasName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-04-04 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set FlowcoolGasType
    ''' </summary>
    ''' <remarks></remarks>
    Public Property FlowcoolGasType() As String
        Get
            Return m_strFlowcoolGasType
        End Get
        Set(ByVal value As String)
            m_strFlowcoolGasType = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2021-10-11 </date>
    ''' </author>
    ''' <summary>
    ''' Gas1 Shutoff valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property FlowcoolGasShutoffPresent() As Boolean
        Get
            Return m_blFlowcoolGasShutoffPresent
        End Get
        Set(ByVal value As Boolean)
            m_blFlowcoolGasShutoffPresent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2021-10-11 </date>
    ''' </author>
    ''' <summary>
    ''' Gas1 Supply valve Present
    ''' </summary>
    ''' <remarks></remarks>
    Public Property FlowcoolGasSupplyPresent() As Boolean
        Get
            Return m_blFlowcoolGasSupplyPresent
        End Get
        Set(ByVal value As Boolean)
            m_blFlowcoolGasSupplyPresent = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2021-10-11 </date>
    ''' </author>
    ''' <summary>
    ''' Gas1 Supply valve is install 
    ''' </summary>
    ''' <remarks></remarks>
    Public Property FlowcoolGasInstall() As Boolean
        Get
            Return m_blnFlowcoolGasInstall
        End Get
        Set(ByVal value As Boolean)
            m_blnFlowcoolGasInstall = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-03-13 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Max_KWH_ShieldsQuartz
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Max_KWH_ShieldsQuartz() As Double
        Get
            Return m_Max_KWH_ShieldsQuartz
        End Get
        Set(ByVal value As Double)
            m_Max_KWH_ShieldsQuartz = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-03-13 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ShieldsQuartzWarning
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShieldsQuartzWarning() As Double
        Get
            Return m_ShieldsQuartzWarning
        End Get
        Set(ByVal value As Double)
            m_ShieldsQuartzWarning = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target1_ShieldsQuartz_Warning", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-03-13 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ShieldsQuartzLimit
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShieldsQuartzLimit() As Double
        Get
            Return m_ShieldsQuartzLimit
        End Get
        Set(ByVal value As Double)
            m_ShieldsQuartzLimit = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target1_ShieldsQuartz_Limit", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Max_KWH_ShieldsQuartz Target 2
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Max_KWH_ShieldsQuartz1() As Double
        Get
            Return m_Max_KWH_ShieldsQuartz1
        End Get
        Set(ByVal value As Double)
            m_Max_KWH_ShieldsQuartz1 = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ShieldsQuartzWarning Target 2
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShieldsQuartzWarning1() As Double
        Get
            Return m_ShieldsQuartzWarning1
        End Get
        Set(ByVal value As Double)
            m_ShieldsQuartzWarning1 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target2_ShieldsQuartz_Warning", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ShieldsQuartzLimit Target 2
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShieldsQuartzLimit1() As Double
        Get
            Return m_ShieldsQuartzLimit1
        End Get
        Set(ByVal value As Double)
            m_ShieldsQuartzLimit1 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target2_ShieldsQuartz_Limit", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Max_KWH_ShieldsQuartz Target 3
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Max_KWH_ShieldsQuartz2() As Double
        Get
            Return m_Max_KWH_ShieldsQuartz2
        End Get
        Set(ByVal value As Double)
            m_Max_KWH_ShieldsQuartz2 = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ShieldsQuartzWarning Target 3
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShieldsQuartzWarning2() As Double
        Get
            Return m_ShieldsQuartzWarning2
        End Get
        Set(ByVal value As Double)
            m_ShieldsQuartzWarning2 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target3_ShieldsQuartz_Warning", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ShieldsQuartzLimit Target 3
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShieldsQuartzLimit2() As Double
        Get
            Return m_ShieldsQuartzLimit2
        End Get
        Set(ByVal value As Double)
            m_ShieldsQuartzLimit2 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target3_ShieldsQuartz_Limit", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Max_KWH_ShieldsQuartz Target 4
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Max_KWH_ShieldsQuartz3() As Double
        Get
            Return m_Max_KWH_ShieldsQuartz3
        End Get
        Set(ByVal value As Double)
            m_Max_KWH_ShieldsQuartz3 = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ShieldsQuartzWarning Target 4
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShieldsQuartzWarning3() As Double
        Get
            Return m_ShieldsQuartzWarning3
        End Get
        Set(ByVal value As Double)
            m_ShieldsQuartzWarning3 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target4_ShieldsQuartz_Warning", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ShieldsQuartzLimit Target 4
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShieldsQuartzLimit3() As Double
        Get
            Return m_ShieldsQuartzLimit3
        End Get
        Set(ByVal value As Double)
            m_ShieldsQuartzLimit3 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target4_ShieldsQuartz_Limit", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2025-11-14 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Max_KWH_ShieldsQuartz Target 5
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Max_KWH_ShieldsQuartz4() As Double
        Get
            Return m_Max_KWH_ShieldsQuartz4
        End Get
        Set(ByVal value As Double)
            m_Max_KWH_ShieldsQuartz4 = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2025-11-14 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ShieldsQuartzWarning Target 5
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShieldsQuartzWarning4() As Double
        Get
            Return m_ShieldsQuartzWarning4
        End Get
        Set(ByVal value As Double)
            m_ShieldsQuartzWarning4 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target5_ShieldsQuartz_Warning", VALUELib.ValueType.F4, value)
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2025-11-14 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ShieldsQuartzLimit Target 5
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShieldsQuartzLimit4() As Double
        Get
            Return m_ShieldsQuartzLimit4
        End Get
        Set(ByVal value As Double)
            m_ShieldsQuartzLimit4 = value
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.Utils.chamberName2ChamberID(Me.Name), EMSERVICELib.VarType.SV, "Target5_ShieldsQuartz_Limit", VALUELib.ValueType.F4, value)
        End Set
    End Property

#Region "IBE"

    ''' <author>
    '''    	<name>Dua Tran </name>
    '''    	<date> 2017-02-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set SystemInterlockGas1Minimum
    ''' </summary>
    Public Property SystemInterlockGas1Minimum() As Double
        Get
            Return m_dSystemInterlockGas1Minimum
        End Get
        Set(ByVal value As Double)
            m_dSystemInterlockGas1Minimum = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Dua Tran </name>
    '''    	<date> 2017-02-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set SystemInterlockGas2Minimum
    ''' </summary>
    Public Property SystemInterlockGas2Minimum() As Double
        Get
            Return m_dSystemInterlockGas2Minimum
        End Get
        Set(ByVal value As Double)
            m_dSystemInterlockGas2Minimum = value
        End Set
    End Property


    ''' <author>
    '''    	<name>Dua Tran </name>
    '''    	<date> 2017-02-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set SystemInterlockGas3Minimum
    ''' </summary>
    Public Property SystemInterlockGas3Minimum() As Double
        Get
            Return m_dSystemInterlockGas3Minimum
        End Get
        Set(ByVal value As Double)
            m_dSystemInterlockGas3Minimum = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Dua Tran </name>
    '''    	<date> 2017-02-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set SystemInterlockGas4Minimum
    ''' </summary>
    Public Property SystemInterlockGas4Minimum() As Double
        Get
            Return m_dSystemInterlockGas4Minimum
        End Get
        Set(ByVal value As Double)
            m_dSystemInterlockGas4Minimum = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do</name>
    '''    	<date> 2016-10-31 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ANCInstalled() As Boolean
        Get
            Return m_blnANCInstalled
        End Get
        Set(ByVal value As Boolean)
            m_blnANCInstalled = value
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2014-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Indicates Internal Shutter is installed
    ''' </summary>
    Public Property InternalShutterInstalled() As Boolean
        Get
            Return m_blnInternalShutter_Installed
        End Get
        Set(ByVal value As Boolean)
            m_blnInternalShutter_Installed = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2009-03-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set IGIsolation Valve Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property DiverterGasValveVisible() As Boolean
        Get
            Return m_blnDiverterGasValveVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnDiverterGasValveVisible = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2014-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ChillerVisible() As Boolean
        Get
            Return m_blnChillerVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChillerVisible = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2016-02-23 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set WhichModel of Chiller
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ChillerModel() As String
        Get
            Return m_blnChillerModel
        End Get
        Set(ByVal value As String)
            m_blnChillerModel = value
        End Set
    End Property

    ''' <name> Tri Do </name>
    ''' <date> 2014-05-08 </date>
    ''' <summary>
    ''' Get or Set EndPoint Unit Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property EndPointUnitVisible() As Boolean
        Get
            Return m_blnEndPointUnitVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnEndPointUnitVisible = value
        End Set
    End Property

    Public Property ChamberInterlock_FixtureWaterBugVisible() As Boolean
        Get
            Return m_blnChamberInterlock_FixtureWaterBugVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_FixtureWaterBugVisible = value
        End Set
    End Property

    Public Property ChamberInterlock_FixtureWaterVisible() As Boolean
        Get
            Return m_blnChamberInterlock_FixtureWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_FixtureWaterVisible = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do</name>
    '''    	<date> 2015-09-03 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible Galil
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShutterOnFixtureUsedByGalilVisible() As Boolean
        Get
            Return m_blnShutterOnFixtureUsedByGalilVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnShutterOnFixtureUsedByGalilVisible = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-07-31 </date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Property TiltAngleReferenceAsLegacy() As Boolean
        Get
            Return m_blnTiltAngleReferenceAsLegacy
        End Get
        Set(ByVal value As Boolean)
            m_blnTiltAngleReferenceAsLegacy = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-05-14 </date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Property VerifyTiltSensorAtPosition() As Boolean
        Get
            Return m_blnVerifyTiltSensorAtPosition
        End Get
        Set(ByVal value As Boolean)
            m_blnVerifyTiltSensorAtPosition = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-05-14 </date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Property VerifiedAngle() As String
        Get
            Return m_strVerifiedAngle
        End Get
        Set(ByVal value As String)
            m_strVerifiedAngle = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2016-07-20 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible Interlock
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ChamberInterlock_SourceWaterVisible() As Boolean
        Get
            Return m_blnChamberInterlock_SourceWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_SourceWaterVisible = value
        End Set
    End Property

    Public Property ChamberInterlock_PanelInterlockVisible() As Boolean
        Get
            Return m_blnChamberInterlock_PanelInterlockVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_PanelInterlockVisible = value
        End Set
    End Property

    Public Property ChamberInterlock_AirPressureVisible() As Boolean
        Get
            Return m_blnChamberInterlock_AirPressureVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_AirPressureVisible = value
        End Set
    End Property

    Public Property ChamberInterlock_ChamberPressureVisible() As Boolean
        Get
            Return m_blnChamberInterlock_ChamberPressureVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_ChamberPressureVisible = value
        End Set
    End Property

    Public Property ChamberInterlock_ForelinePressureVisible() As Boolean
        Get
            Return m_blnChamberInterlock_ForelinePressureVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamberInterlock_ForelinePressureVisible = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Dua Tran </name>
    '''    	<date> 2017-04-04 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Filt Sweep Mode
    ''' </summary>
    Public Property SupportTiltSweepMode() As Boolean
        Get
            Return m_blSupportTiltSweepMode
        End Get
        Set(ByVal value As Boolean)
            m_blSupportTiltSweepMode = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Dua Tran </name>
    '''    	<date> 2017-04-04 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Fast Tilt Installed
    ''' </summary>
    Public Property FastTiltInstalled() As Boolean
        Get
            Return m_blFastTiltInstalled
        End Get
        Set(ByVal value As Boolean)
            m_blFastTiltInstalled = value
        End Set
    End Property


    ''' <author>
    '''    	<name>Dua Tran </name>
    '''    	<date> 2017-05-24 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set BackTilt Installed
    ''' </summary>
    Public Property BackTiltInstalled() As Boolean
        Get
            Return m_blBackTilt_Installed
        End Get
        Set(ByVal value As Boolean)
            m_blBackTilt_Installed = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2018-09-06 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Source Magnet Visible
    ''' </summary>
    Public Property SourceMagnetVisible() As Boolean
        Get
            Return m_blnSourceMagnetVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnSourceMagnetVisible = value
        End Set
    End Property


#End Region

#Region "Property Corona config"
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Shutter2Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Shutter2Visible() As Boolean
        Get
            Return m_blnShutter2Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnShutter2Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Shutter3Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Shutter3Visible() As Boolean
        Get
            Return m_blnShutter3Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnShutter3Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Shutter4Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Shutter4Visible() As Boolean
        Get
            Return m_blnShutter4Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnShutter4Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Kiet Tran </name>
    '''	<date> 2025-11-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Shutter4Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Shutter5Visible() As Boolean
        Get
            Return m_blnShutter5Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnShutter5Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set TargetVisible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property TargetVisible() As Boolean
        Get
            Return m_blnTargetVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTargetVisible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Target2Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Target2Visible() As Boolean
        Get
            Return m_blnTarget2Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget2Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Target3Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Target3Visible() As Boolean
        Get
            Return m_blnTarget3Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget3Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Target4Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Target4Visible() As Boolean
        Get
            Return m_blnTarget4Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget4Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Kiet Tran </name>
    '''	<date> 2025-11-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Target4Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Target5Visible() As Boolean
        Get
            Return m_blnTarget5Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget5Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Interlock_Matchbox2Water_Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Interlock_Matchbox2Water_Visible() As Boolean
        Get
            Return m_blnInterlock_Matchbox2Water_Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnInterlock_Matchbox2Water_Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Interlock_Target13Water_Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Interlock_Target13Water_Visible() As Boolean
        Get
            Return m_blnInterlock_Target13Water_Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnInterlock_Target13Water_Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Interlock_Target24Water_Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Interlock_Target24Water_Visible() As Boolean
        Get
            Return m_blnInterlock_Target24Water_Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnInterlock_Target24Water_Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Interlock_SubstrateTableWater_Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Interlock_SubstrateTableWater_Visible() As Boolean
        Get
            Return m_blnInterlock_SubstrateTableWater_Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnInterlock_SubstrateTableWater_Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Dat Cao </name>
    '''	<date> 2012-12-26 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Interlock_AirPressure_Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Interlock_AirPressure_Visible() As Boolean
        Get
            Return m_blnInterlock_AirPressure_Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnInterlock_AirPressure_Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Buu Tran </name>
    '''	<date> 2013-02-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Interlock_AirPressure_Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Target_Matchbox_Water_Visible() As Boolean
        Get
            Return m_blnInterlock_Target_Matchbox_Water_Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnInterlock_Target_Matchbox_Water_Visible = value
        End Set
    End Property
    ''' <author>
    '''	<name> Buu Tran </name>
    '''	<date> 2013-02-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Interlock_AirPressure_Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Bias_Matchbox_Water_Visible() As Boolean
        Get
            Return m_blnInterlock_Bias_Matchbox_Water_Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnInterlock_Bias_Matchbox_Water_Visible = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2016-3-30 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible HeaterZone1Installed
    ''' </summary>
    ''' <remarks></remarks>
    Public Property HeaterZone1Installed() As Boolean
        Get
            Return m_blnHeaterZone1Installed
        End Get
        Set(ByVal value As Boolean)
            m_blnHeaterZone1Installed = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2016-3-30 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible HeaterZone2Installed
    ''' </summary>
    ''' <remarks></remarks>
    Public Property HeaterZone2Installed() As Boolean
        Get
            Return m_blnHeaterZone2Installed
        End Get
        Set(ByVal value As Boolean)
            m_blnHeaterZone2Installed = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-3-23 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible FilMetricDevice_Installed
    ''' </summary>
    ''' <remarks></remarks>
    Public Property FilMetricDevice_Installed() As Boolean
        Get
            Return m_blnFilMetricDeviceInstalled
        End Get
        Set(ByVal value As Boolean)
            m_blnFilMetricDeviceInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-04-04 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible FilMetricDevice_Installed
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferLiftInstalled() As Boolean
        Get
            Return m_blnWaferLiftInstalled
        End Get
        Set(ByVal value As Boolean)
            m_blnWaferLiftInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2018-12-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible Chuck_Position_TSD_Ref
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ChuckPositionTSDRef() As Boolean
        Get
            Return m_blnChuckPositionTSDRef
        End Get
        Set(ByVal value As Boolean)
            m_blnChuckPositionTSDRef = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2019-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Gets or Sets TargetToHomeDistance
    ''' </summary>
    ''' <remarks></remarks>
    Public Property TargetToHomeDistance() As Double
        Get
            Return m_TargetToHomeDistance
        End Get
        Set(ByVal value As Double)
            m_TargetToHomeDistance = value
        End Set
    End Property

#End Region
    Public Sub New()

    End Sub


#Region "Just for IBE"
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2016-03-24 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SupportPBNBodyDischargeVoltage() As Boolean
        Get
            Return m_blnSupportPBNBodyDischargeVoltage
        End Get
        Set(ByVal value As Boolean)
            m_blnSupportPBNBodyDischargeVoltage = value
        End Set
    End Property

#End Region

End Class
