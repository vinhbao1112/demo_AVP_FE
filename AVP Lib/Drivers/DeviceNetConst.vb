Namespace DeviceNet
    Public Class DeviceNetConst
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

        Public Const LLB_Fast_Rough_Valve As UInt16 = 1
        Public Const LLB_Slow_Rough_Valve As UInt16 = 1
        Public Const LLB_Fast_Vent_Valve As UInt16 = 1
        Public Const LLB_Slow_Vent_Valve As UInt16 = 1
        Public Const LLB_Turbo_Foreline_Valve As UInt16 = 1
        Public Const LLB_Hivac_Valve As UInt16 = 1
        Public Const LLB_Isolation_Valve As UInt16 = 1

        Public Const TM_Rough_Valve As UInt16 = 1
        Public Const TM_Fast_Vent_Valve As UInt16 = 1
        Public Const TM_Turbo_Foreline_Valve As UInt16 = 1
        Public Const TM_Hivac_Valve As UInt16 = 1

        Public Const PM1_Isolation_Valve As UInt16 = 1
        Public Const PM2_Isolation_Valve As UInt16 = 1
        Public Const PM3_Isolation_Valve As UInt16 = 1

        Public Const Solenoid_Block_1_MacID As UInt16 = 1
        Public Const Solenoid_Block_2_MacID As UInt16 = 2
#End Region
#Region "DeviceName"

#End Region
    End Class

End Namespace
