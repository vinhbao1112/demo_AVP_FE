Namespace Driver
    Public Class DriverConst
#Region "LIBRARY CONSTANTS"

        '--------------------------
        ' connection flags
        '--------------------------
        Public Const SS_EX As Integer = &H1
        Public Const SS_P As Integer = &H2
        Public Const SS_ST As Integer = &H4
        Public Const SS_COS As Integer = &H8
        Public Const SS_CYC As Integer = &H10
        Public Const SS_AKS As Integer = &H20

        '--------------------------
        ' I/O data areas
        '--------------------------
        Public Const DNS_INPUT1 As Integer = 0
        Public Const DNS_OUTPUT1 As Integer = 1
        Public Const DNS_INPUT2 As Integer = 2
        Public Const DNS_OUTPUT2 As Integer = 3

        Public Const DNS_SCAN_EVENT As Integer = 1
        Public Const DNS_STATUS_EVENT As Integer = 0
        Public Const DNS_IO1_EVENT As Integer = 1
        Public Const DNS_IO2_EVENT As Integer = 2
        Public Const DNS_EXP_EVENT As Integer = 3
        Public Const DNS_EXP_REQ_EVENT As Integer = 3
        Public Const DNS_EXP_RES_EVENT As Integer = 4

        '--------------------------
        ' status flags
        '--------------------------
        Public Const DNS_EXP_MSG_RECEIVED As Integer = &H1
        Public Const DNS_EXP_MSG_TRUNCATED As Integer = &H2
        Public Const DNS_INPUT_DATA_UPDATE As Integer = &H1
        Public Const DNS_RECEIVE_IDLE As Integer = &H2
        Public Const DNS_SERVER_EXPLICIT_RECEIVED As Integer = &H1

#End Region

#Region "DEVICENET SOLENOID CONFIG"
        'at this time not use this field
        'used config
        Public Const LLA_Fast_Rough_Valve As UInt16 = 1
        Public Const LLA_Slow_Rough_Valve As UInt16 = 1
        Public Const LLA_Fast_Vent_Valve As UInt16 = 1
        Public Const LLA_Slow_Vent_Valve As UInt16 = 1
        Public Const LLA_Turbo_Foreline_Valve As UInt16 = 1
        Public Const LLA_Hivac_Valve As UInt16 = 1
        Public Const LLA_Isolation_Valve As UInt16 = 1

        Public Const TM_Rough_Valve As UInt16 = 1
        Public Const TM_Fast_Vent_Valve As UInt16 = 1
        Public Const TM_Turbo_Foreline_Valve As UInt16 = 1
        Public Const TM_Hivac_Valve As UInt16 = 1

        Public Const PM1_Isolation_Valve As UInt16 = 1
        Public Const PM2_Isolation_Valve As UInt16 = 1
        Public Const PM3_Isolation_Valve As UInt16 = 1

        Public Const Solenoid_Block_1_MacID As UInt16 = 1
        Public Const Solenoid_Block_2_MacID As UInt16 = 2
        Public Const Solenoid_Block_3_MacID As UInt16 = 3
#End Region

#Region "RSTI_ADAPTER"
        Public Const RSTI_ADAPTER_OUTPUT_DISCRETE_CHANNEL As String = "DO"
        Public Const RSTI_ADAPTER_INPUT_DISCRETE_CHANNEL As String = "DI"
        Public Const RSTI_ADAPTER_INPUT_ANALOG_CHANNEL As String = "AI"
        Public Const RSTI_ADAPTER_OUTPUT_ANALOG_CHANNEL As String = "AO"

        Public Const RSTI_CMD_ON_OFF As String = "WriteDiscreteDevie"
        Public Const RSTI_CMD_VALUE As String = "WriteAnalogDevie"
#End Region

#Region "DeviceName"
        Public Const RoughPumpMachine1_CG As String = "RoughPumpMachine1.CG"
        Public Const RoughPumpMachine2_CG As String = "RoughPumpMachine2.CG"

        Public Const LoadLockA_IonGauge As String = "LoadLockA.Ion"
        Public Const LoadLockA_CG As String = "LoadLockA.CG"
        Public Const CassettesModule_IonGauge As String = "CassettesModule.Ion"
        Public Const CassettesModule_CG As String = "CassettesModule.CG"

        Public Const LoadLockA_TurboForelineCG As String = "LoadLockA.TurboForelineCG"
        Public Const CassettesModule_TurboForelineCG As String = "CassettesModule.TurboForelineCG"

        Public Const CassettesModule_TurboForelineValve As String = "CassettesModule.TurboForelineValve"
        Public Const LoadLockA_TurboForelineValve As String = "LoadLockA.TurboForelineValve"

        Public Const LoadLockA_LLFastRough As String = "LoadLockA.LLFastRough"
        Public Const CassettesModule_Rough As String = "CassettesModule.Rough"
        Public Const LoadLockA_LLSlowRough As String = "LoadLockA.LLSlowRough"

        Public Const LoadLockA_LLFastVent As String = "LoadLockA.LLFastVent"
        Public Const CassettesModule_Vent As String = "CassettesModule.Vent"
        Public Const LoadLockA_LLSlowVent As String = "LoadLockA.LLSlowVent"

        Public Const LoadLockA_LLHiVac As String = "LoadLockA.LLHiVac"
        Public Const CassettesModule_TMHiVac As String = "CassettesModule.TMHiVac"

        Public Const CassettesModule_SplitValveLLA As String = "CassettesModule.SplitValveLLA"
        Public Const CassettesModule_SplitValvePM1 As String = "CassettesModule.SplitValvePM1"
        Public Const CassettesModule_SplitValvePM2 As String = "CassettesModule.SplitValvePM2"
        Public Const CassettesModule_SplitValvePM3 As String = "CassettesModule.SplitValvePM3"
        '<!-- Kepware Region-->
        Public Const CassettesModule_SensorLLAStatus As String = "CassettesModule.SensorLLAStatus"
        Public Const CassettesModule_SensorPM1Status As String = "CassettesModule.SensorPM1Status"
        Public Const CassettesModule_SensorPM2Status As String = "CassettesModule.SensorPM2Status"
        Public Const CassettesModule_SensorPM3Status As String = "CassettesModule.SensorPM3Status"
        '<!-- Serial Region-->
        Public Const LLAPumpPackage As String = "LLAPumpPackage"
        Public Const TMPumpPackage As String = "TMPumpPackage"
        
#End Region
    End Class
End Namespace
