Imports System.Threading
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum

Namespace DataManagerment
    Public Class CoronaChamber
        Inherits Chamber

#Region "Class Constants & Variables"
        Public Const TARGET_MODE_RF As String = "01"
        Public Const TARGET_MODE_DC As String = "02"

        Private m_Override_Mode As WorkingStatuses
        Private m_Alarm_Status_Readback As WorkingStatuses
        Private m_Event_Status_Readback As WorkingStatuses
        Private m_Maintenaince_Mode As WorkingStatuses
        Protected m_Target1_Kwh_Usage As Double
        Private m_Target1_Set_Kwh_Usage As Double
        Protected m_Target2_Kwh_Usage As Double
        Private m_Target2_Set_Kwh_Usage As Double
        Protected m_Target3_Kwh_Usage As Double
        Private m_Target3_Set_Kwh_Usage As Double
        Protected m_Target4_Kwh_Usage As Double
        Private m_Target4_Set_Kwh_Usage As Double
        Private m_Target_Select_Program As Integer
        Protected m_Target_Select_Readback As Integer
        Private m_Plasma_Status As Integer
        Private m_Last_Wafer_In As String
        Private m_Last_Wafer_Out As String
        Private m_Process_Wafer_ID As String
        Private m_WaferID_Slot1 As String
        Private m_WaferID_Slot2 As String
        Private m_WaferID_Slot3 As String
        Private m_WaferID_Slot4 As String
        Private m_WaferID_Slot5 As String
        Private m_WaferID_Slot6 As String
        Private m_WaferID_Slot7 As String
        Private m_WaferID_Slot8 As String
        Private m_Process_Recipe_Name As String
        Private m_Process_Control_Device_Start As String
        Private m_Process_Control_Device_Stop As String
        Private m_Process_Control_Device_Pause As String
        Private m_Process_Control_Device_Continue As String
        Private m_Process_Control_Device_End_Step As String
        Private m_Process_Control_Device_Error As String
        Private m_Process_Control_Device_Reset_Error As String
        Private m_Process_Control_Send_Run_Data_File_Name As String
        Private m_Process_Control_Get_Run_Data_File_Name As String
        Private m_Process_Pressure As Double
        Private m_Copyrecipe_To_Pmfolder As Boolean
        Private m_Process_Remaining_Time As String
        Private m_Process_Elapsed_Time As String
        Protected m_Process_Current_Step As String
        Protected m_Process_Total_Steps As String
        Private m_Process_Total_Time As String
        Private m_Wafer_Processing_Status_Readback As Integer
        Private m_Auto_Pumpdown_Seq As WorkingStatuses
        Private m_Auto_Vent_Seq As WorkingStatuses
        Private m_Pump_Purge_Seq As WorkingStatuses
        Private m_IG_Degas_Seq As WorkingStatuses
        Private m_Shutdown_Power_Seq As WorkingStatuses
        Private m_Rate_Of_Rise_Seq As WorkingStatuses
        Private m_Rate_Of_Rise_Interval_Recording As Double
        Private m_Rate_Of_Rise_Sample As Double
        Private m_Rate_Of_Rise_Filename As String
        Private m_Pumpdown_Curve_Seq As WorkingStatuses
        Private m_Pumpdown_Curve_Interval_Recording As Double
        Private m_Initialize_Motion As WorkingStatuses
        Protected m_Initialized_Motion As WorkingStatuses
        Private m_Auto_Power_Seq As WorkingStatuses
        Private m_Gas1_Shutoff_Valve As WorkingStatuses
        Private m_Gas2_Shutoff_Valve As WorkingStatuses
        Private m_Gas3_Shutoff_Valve As WorkingStatuses
        Private m_Gas4_Shutoff_Valve As WorkingStatuses
        Private m_Gas5_Shutoff_Valve As WorkingStatuses
        Private m_Gas1_Flowrate_Readback As Double
        Private m_Gas2_Flowrate_Readback As Double
        Private m_Gas3_Flowrate_Readback As Double
        Private m_Gas4_Flowrate_Readback As Double
        Private m_Gas5_Flowrate_Readback As Double
        Private m_Gas1_Flowrate_Program As Double
        Private m_Gas2_Flowrate_Program As Double
        Private m_Gas3_Flowrate_Program As Double
        Private m_Gas4_Flowrate_Program As Double
        Private m_Gas5_Flowrate_Program As Double
        Private m_Main_Dist_Valve As WorkingStatuses
        Private m_Sec_Dist_Valve As WorkingStatuses
        'Private m_Rough_Valve_Status As WorkingStatuses
        'Private m_Vent_Valve_Status As WorkingStatuses
        Private m_Isolation_Valve_Status As WorkingStatuses
        Private m_Hivac_Valve_Status As WorkingStatuses
        'Private m_Foreline_Valve_Status As WorkingStatuses
        Private m_Baratron_Valve_Status As WorkingStatuses
        Private m_IG_Pressure As Double
        Private m_IG_Status As WorkingStatuses
        Private m_SwitchIGFilament As String
        Private m_EnableIGFilament As Integer
        Private m_CG_Pressure As Double
        Private m_CG_Relay_Status As WorkingStatuses
        Private m_Foreline_CG_Pressure As Double
        Private m_Foreline_CG_Relay_Status As WorkingStatuses
        Private m_Baratron_Pressure As Double
        Private m_Mechanical_Pump_CG_Pressure As Double
        Private m_Mechanical_Pump_CG_Relay_Status As WorkingStatuses
        Private m_Mechanical_Pump_Status As WorkingStatuses
        Private m_Chamberinterlock_Substrate_Table_Water_Status As WorkingStatuses
        Private m_Chamberinterlock_Air_Pressure_Status As WorkingStatuses
        Private m_Chamberinterlock_Door_Closed_Status As WorkingStatuses
        Private m_Chamberinterlock_Lid_Closed_Status As WorkingStatuses
        Private m_Chamberinterlock_Target1_3_Water_Status As WorkingStatuses
        Private m_Chamberinterlock_Target2_4_Water_Status As WorkingStatuses
        Private m_Chamberinterlock_Target_MB_Water_Status As WorkingStatuses
        Private m_Chamberinterlock_Bias_MB_Water_Status As WorkingStatuses
        Private m_Chamberinterlock_Turbo_Water_Status As WorkingStatuses
        Private m_Chamberinterlock_Ps_Interlock_Status As WorkingStatuses
        Private m_Chamberinterlock_Devicenet_Comm As WorkingStatuses
        Private m_Chamberinterlock_Target_Panels As WorkingStatuses
        Private m_Substrate_Goto_Slot As Integer
        Private m_Substrate_Current_Station As Integer
        Private m_Round_Substrate_Current_Station As Integer
        Protected m_Substrate_Goto_Home As WorkingStatuses
        Protected m_Substrate_Table_Lift_Home As WorkingStatuses
        Private m_Substrate_Table_Up_Down_Status As WorkingStatuses
        Protected m_Substrate_Lift_Up_Down_Status As WorkingStatuses
        Private m_Substrate_Table_Rotate_Status As WorkingStatuses
        Private m_Substrate_Table_Rotate_Speed As Double
        Private m_Substrate_Table_Rotate_Speed_Readback As Double
        Private m_Substrate_Table_Rotate_Pos_In_Unit_Readback As Double
        Private m_Number_Of_Unit_Per_Revolution_Readback As Double
        Private m_Substrate_Table_Current_Position_Program As Integer
        Private m_Substrate_Table_Current_Position_Readback As Integer
        Private m_Is_MotionInitalized As WorkingStatuses
        Private m_Substrate_Table_Rotate_Sequence_State As WorkingStatuses
        Private m_Target1_Shutter_Status As WorkingStatuses
        Private m_Target2_Shutter_Status As WorkingStatuses
        Private m_Target3_Shutter_Status As WorkingStatuses
        Private m_Target4_Shutter_Status As WorkingStatuses
        Private m_Substrate_Table_Up_Down_Moving As WorkingStatuses
        Protected m_Water_Pump_T_Readback As Double
        Private m_Water_Pump_Status As WorkingStatuses
        Private m_Water_Pump_Regen_Status As WorkingStatuses
        Private m_Water_Pump_State_Status As WorkingStatuses
        Protected m_Water_Pump_Regen_Hour_Readback As Double
        Protected m_Water_Pump_Regen_Lifetime_Readback As Double
        Private m_Water_Pump_P_Command_Readback As String
        Private m_Water_Pump_Is_Communicating As WorkingStatuses
        Private m_Turbo_Pump_On_Off As WorkingStatuses
        Protected m_Turbo_Pump_On_Off_Rb As WorkingStatuses
        Protected m_Turbo_Pump_Uptospeed_Rb As WorkingStatuses
        Private m_Turbo_Pump_Ramping_Percent_Rb As Double
        Private m_Vat_Valve_Communication_Status As WorkingStatuses
        Private m_Vat_Valve_Controller_Pressure_Program As Double
        Private m_Vat_Valve_Controller_Pressure_Readback As Double
        Private m_Vat_Valve_Percentage_Program As Double
        Private m_Vat_Valve_Percentage_Readback As Double
        Private m_Vat_Valve_Controller_Auto_Zero As WorkingStatuses
        Private m_Vat_Valve_Controller_Teach As WorkingStatuses
        Private m_Vat_Valve_Controller_Sizeadjust As WorkingStatuses
        Private m_Target1_Magnatron_On_Off As WorkingStatuses
        Private m_Target1_Magnatron_Rotate_Status As WorkingStatuses
        Private m_Target2_Magnatron_On_Off As WorkingStatuses
        Private m_Target2_Magnatron_Rotate_Status As WorkingStatuses
        Private m_Target3_Magnatron_On_Off As WorkingStatuses
        Private m_Target3_Magnatron_Rotate_Status As WorkingStatuses
        Private m_Target4_Magnatron_On_Off As WorkingStatuses
        Private m_Target4_Magnatron_Rotate_Status As WorkingStatuses
        Private m_RF_Target_Communication_Status As WorkingStatuses
        Private m_RF_Target_Power_Readback As Double
        Private m_RF_Target_Power_Program As Double
        Private m_RF_Target_Reflected_Power_Readback As Double
        Private m_RF_Target_MB_Voltage_Readback As Double
        Private m_RF_Target_MB_C1_Program As Double
        Private m_RF_Target_MB_C1_Readback As Double
        Private m_RF_Target_MB_C2_Program As Double
        Private m_RF_Target_MB_C2_Readback As Double
        Private m_RF_Target_MB_Match_Mode_Program As Double
        Private m_RF_Target_MB_Match_Mode_Readback As Double
        Private m_RF_Target_Voltage_SP As Double
        Private m_Bias_Communication_Status As WorkingStatuses
        Private m_Bias_Power_Contact_On_Off As WorkingStatuses
        Private m_Bias_Plasma_Status As WorkingStatuses
        Private m_Bias_Power_Readback As Double
        Private m_Bias_Power_Program As Double
        Private m_Bias_Reflected_Power_Readback As Double
        Private m_Bias_MB_Voltage_Readback As Double
        Private m_Bias_MB_Voltage_Program As Double
        Private m_Bias_MB_C1_Program As Double
        Private m_Bias_MB_C1_Readback As Double
        Private m_Bias_MB_C2_Program As Double
        Private m_Bias_MB_C2_Readback As Double
        Private m_Bias_MB_Match_Mode_Program As Double
        Private m_Bias_MB_Match_Mode_Readback As Double
        Private m_DC_Target_Communication_Status As WorkingStatuses
        Private m_DC_Target_Power_Readback As Double
        Private m_DC_Target_Power_Program As Double
        Private m_DC_Target_Voltage_Readback As Double
        Private m_DC_Target_Current_Readback As Double
        Private m_DC_Target_Pluse_Mode_Status As WorkingStatuses
        Private m_DC_Target_Pulse_Frequency_Program As Double
        Private m_DC_Target_Pulse_Frequency_Readback As Double
        Private m_DC_Target_Pulse_Width_Program As Double
        Private m_DC_Target_Pulse_Width_Readback As Double
        Private m_DC_Target_Ramp_Time_Program As Double
        Private m_DC_Target_Ramp_Time_Readback As Double
        Private m_DC_Target_Arc_Counter_Readback As Double
        Private m_DC_Target_Voltage_SP As Double
        Private m_blnStateMachineCompleted As Boolean = False
        Protected m_objChamberModule As SystemModule = Nothing
        Private m_blnShowWarningKWH As Boolean = False
        Private m_blnShowLimitKWH As Boolean = False
        Private m_blnIsAutoPumpdownRunning As Boolean = False
        Private m_RF_Target_MB_Preset_Program As Integer
        Private m_RF_Target_MB_Preset_Readback As Integer
        Private m_RF_Target_MB_Preset_Store_Program As WorkingStatuses
        Private m_RF_Target_MB_Preset_Recall_Program As WorkingStatuses
        Protected m_RF_Target_MB_Mag_Error_Readback As String
        Protected m_RF_Target_MB_Phase_Error_Readback As String
        Private m_RF_Target_Error_Readback As String

        Private m_Bias_MB_Preset_Program As Integer
        Private m_Bias_MB_Preset_Readback As Integer
        Private m_Bias_MB_Preset_Store_Program As WorkingStatuses
        Private m_Bias_MB_Preset_Recall_Program As WorkingStatuses
        Protected m_Bias_MB_Mag_Error_Readback As String
        Protected m_Bias_MB_Phase_Error_Readback As String
        Private m_Bias_Error_Readback As String
        Private m_IsFullWaferSlot As Boolean = False
        Private m_strProcessMonitor_Status_Readback As String

        '2013-01-18 Tin Pham added
        Private m_Target1_Set_Shields_Quart As Double
        Private m_Target1_Shields_Quart As Double
        Private m_Target2_Set_Shields_Quart As Double
        Private m_Target2_Shields_Quart As Double
        Private m_Target3_Set_Shields_Quart As Double
        Private m_Target3_Shields_Quart As Double
        Private m_Target4_Set_Shields_Quart As Double
        Private m_Target4_Shields_Quart As Double
        Protected m_Process_Mode As String
        Protected m_Process_Revolution_Count As String
        Private m_Target_Mode As String
#End Region
#Region "Property"
        ''' <summary>
        ''' Waiting MP ON
        ''' </summary>
        ''' <remarks></remarks>
        Protected m_strWaitingMPON As String = String.Empty
        Public Property WaitingMPON() As String
            Get
                Return m_strWaitingMPON
            End Get
            Set(ByVal value As String)
                m_strWaitingMPON = value

                If RobotConfigurationValues.SHARED_MP_WITH_PM Then
                    UpdateRoughPumpToTM(Equipments.RoughPumpMachine1, "WaitingMPOnMessager", value)
                End If
            End Set
        End Property
        Public ReadOnly Property IsFullWaferSlot() As Boolean
            Get
                Return m_IsFullWaferSlot
            End Get
        End Property

        Public Property Override_Mode() As WorkingStatuses
            Get
                Return m_Override_Mode
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "OverridesModeStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Override_Mode", m_Override_Mode, value, False)
            End Set
        End Property
        Public Property Target1_Kwh_Usage() As Double
            Get
                Return m_Target1_Kwh_Usage
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target1_KWH_Usage", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target1_Kwh_Usage", m_Target1_Kwh_Usage, value, False)
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If
                If (m_objChamberModule IsNot Nothing) Then
                    CheckingKWH(m_Target1_Kwh_Usage, 1)
                End If
            End Set
        End Property
        Public Property Target1_Set_Kwh_Usage() As Double
            Get
                Return m_Target1_Set_Kwh_Usage
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target1_Set_Kwh_Usage", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target1_Set_Kwh_Usage", m_Target1_Set_Kwh_Usage, value, False)
            End Set
        End Property
        Public Property Target2_Kwh_Usage() As Double
            Get
                Return m_Target2_Kwh_Usage
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target2_KWH_Usage", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target2_Kwh_Usage", m_Target2_Kwh_Usage, value, False)
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If
                If (m_objChamberModule IsNot Nothing) Then
                    CheckingKWH(m_Target2_Kwh_Usage, 2)
                End If
            End Set
        End Property
        Public Property Target2_Set_Kwh_Usage() As Double
            Get
                Return m_Target2_Set_Kwh_Usage
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target2_Set_Kwh_Usage", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target2_Set_Kwh_Usage", m_Target2_Set_Kwh_Usage, value, False)
            End Set
        End Property
        Public Property Target3_Kwh_Usage() As Double
            Get
                Return m_Target3_Kwh_Usage
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target3_KWH_Usage", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target3_Kwh_Usage", m_Target3_Kwh_Usage, value, False)
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If
                If (m_objChamberModule IsNot Nothing) Then
                    CheckingKWH(m_Target3_Kwh_Usage, 3)
                End If
            End Set
        End Property
        Public Property Target3_Set_Kwh_Usage() As Double
            Get
                Return m_Target3_Set_Kwh_Usage
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target3_Set_Kwh_Usage", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target3_Set_Kwh_Usage", m_Target3_Set_Kwh_Usage, value, False)
            End Set
        End Property
        Public Property Target4_Kwh_Usage() As Double
            Get
                Return m_Target4_Kwh_Usage
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target4_KWH_Usage", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target4_Kwh_Usage", m_Target4_Kwh_Usage, value, False)
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If
                If (m_objChamberModule IsNot Nothing) Then
                    CheckingKWH(m_Target4_Kwh_Usage, 4)
                End If
            End Set
        End Property
        Public Property Target4_Set_Kwh_Usage() As Double
            Get
                Return m_Target4_Set_Kwh_Usage
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target4_Set_Kwh_Usage", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target4_Set_Kwh_Usage", m_Target4_Set_Kwh_Usage, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-02-26 </date>
        ''' </author>
        ''' <summary>
        ''' Set Shields/Quart KWH Target1
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Target1_Set_Shield_Quart() As Double
            Get
                Return m_Target1_Set_Shields_Quart
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target1_Set_Shield_Quart", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target1_Set_Shield_Quart", m_Target1_Set_Shields_Quart, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-02-26 </date>
        ''' </author>
        ''' <summary>
        ''' Set Shields/Quart KWH Target2
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Target2_Set_Shield_Quart() As Double
            Get
                Return m_Target2_Set_Shields_Quart
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target2_Set_Shield_Quart", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target2_Set_Shield_Quart", m_Target2_Set_Shields_Quart, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-02-26 </date>
        ''' </author>
        ''' <summary>
        ''' Set Shields/Quart KWH Target3
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Target3_Set_Shield_Quart() As Double
            Get
                Return m_Target3_Set_Shields_Quart
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target3_Set_Shield_Quart", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target3_Set_Shield_Quart", m_Target3_Set_Shields_Quart, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-02-26 </date>
        ''' </author>
        ''' <summary>
        ''' Set Shields/Quart KWH Target4
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Target4_Set_Shield_Quart() As Double
            Get
                Return m_Target4_Set_Shields_Quart
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target4_Set_Shield_Quart", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target4_Set_Shield_Quart", m_Target4_Set_Shields_Quart, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-01-18 </date>
        ''' </author>
        ''' <summary>
        ''' Shields/Quart KWH 1
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Target1_Shield_Quart() As Double
            Get
                Return m_Target1_Shields_Quart
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Tin Pham
                ' Var Name: PMX.ShieldQuartz
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target1_Shield_Quart", VALUELib.ValueType.F4, value)

                m_Target1_Shields_Quart = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-01-18 </date>
        ''' </author>
        ''' <summary>
        ''' Shields/Quart KWH 2
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Target2_Shield_Quart() As Double
            Get
                Return m_Target2_Shields_Quart
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Tin Pham
                ' Var Name: PMX.ShieldQuartz
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target2_Shield_Quart", VALUELib.ValueType.F4, value)

                m_Target2_Shields_Quart = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-01-18 </date>
        ''' </author>
        ''' <summary>
        ''' Shields/Quart KWH 3
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Target3_Shield_Quart() As Double
            Get
                Return m_Target3_Shields_Quart
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Tin Pham
                ' Var Name: PMX.ShieldQuartz
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target3_Shield_Quart", VALUELib.ValueType.F4, value)

                m_Target3_Shields_Quart = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-01-18 </date>
        ''' </author>
        ''' <summary>
        ''' Shields/Quart KWH 3
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Target4_Shield_Quart() As Double
            Get
                Return m_Target4_Shields_Quart
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Tin Pham
                ' Var Name: PMX.ShieldQuartz
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target4_Shield_Quart", VALUELib.ValueType.F4, value)

                m_Target4_Shields_Quart = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2013-01-18 </date>
        ''' </author>
        ''' <summary>
        ''' RF_Target_Voltage_Min_Readback
        ''' </summary>
        Private m_RFTarget_Voltage_Min As Double = 0
        Public Property RF_Target_Voltage_Min_Readback() As Double
            Get
                Return m_RFTarget_Voltage_Min
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Tin Pham
                ' Var Name: PMX.ShieldQuartz
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTarget_Voltage_Min", VALUELib.ValueType.F4, value)

                m_RFTarget_Voltage_Min = value
            End Set
        End Property

        Private m_RFTarget_Voltage_Max As Double = 0
        Public Property RF_Target_Voltage_Max_Readback() As Double
            Get
                Return m_RFTarget_Voltage_Max
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Tin Pham
                ' Var Name: PMX.ShieldQuartz
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RFTarget_Voltage_Max", VALUELib.ValueType.F4, value)

                m_RFTarget_Voltage_Max = value
            End Set
        End Property
        Public Property Target_Select_Program() As Integer
            Get
                Return m_Target_Select_Program
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target_Select_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target_Select_Program", m_Target_Select_Program, value, False)
            End Set
        End Property

        Public Overridable Property Target_Select_Readback() As Integer
            Get
                Return m_Target_Select_Readback
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target_Select_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target_Select_Readback", m_Target_Select_Readback, value, False)
            End Set
        End Property
        Public Property Plasma_Status() As Integer
            Get
                Return m_Plasma_Status
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Plasma_Status", VALUELib.ValueType.F4, value)
                ' Trigger SECS/GEM Event by Dat Cao
                ' Var Name: PMX.PlasmaOn/PlasmaOff      
                If m_Plasma_Status <> value Then
                    If (value < 5 AndAlso value > 0) Then
                        Business.AVPSecsGemLib.MySecsGemObj.TriggerEvent(Me.Name, "PlasmaOn")
                    ElseIf value = 0 Then
                        Business.AVPSecsGemLib.MySecsGemObj.TriggerEvent(Me.Name, "PlasmaOff")
                    Else
                        AVPLib.Log.avpLogger.Error("Error Plasma Status: " & value.ToString() & " in: " & Me.Name)
                    End If
                End If

                CheckValueForLog("Target_Select_Readback", m_Plasma_Status, value, False)
            End Set
        End Property

        Public Property Last_Wafer_In() As String
            Get
                Return m_Last_Wafer_In
            End Get
            Set(ByVal value As String)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Last_Wafer_In", VALUELib.ValueType.A, value)
                CheckValueForLog("Last_Wafer_In", m_Last_Wafer_In, value, False)
            End Set
        End Property

        Public Property Last_Wafer_Out() As String
            Get
                Return m_Last_Wafer_Out
            End Get
            Set(ByVal value As String)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Last_Wafer_Out", VALUELib.ValueType.A, value)
                CheckValueForLog("Last_Wafer_Out", m_Last_Wafer_Out, value, False)
            End Set
        End Property

        Public Property Process_Wafer_ID() As String
            Get
                Return m_Process_Wafer_ID
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferID", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Wafer_ID", m_Process_Wafer_ID, value, False)
            End Set
        End Property

        Public Property WaferID_Slot1() As String
            Get
                Return m_WaferID_Slot1
            End Get
            Set(ByVal value As String)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferID_Slot1", VALUELib.ValueType.A, value)
                CheckValueForLog("WaferID_Slot1", m_WaferID_Slot1, value, False)
            End Set
        End Property

        Public Property WaferID_Slot2() As String
            Get
                Return m_WaferID_Slot2
            End Get
            Set(ByVal value As String)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferID_Slot2", VALUELib.ValueType.A, value)
                CheckValueForLog("WaferID_Slot2", m_WaferID_Slot2, value, False)
            End Set
        End Property

        Public Property WaferID_Slot3() As String
            Get
                Return m_WaferID_Slot3
            End Get
            Set(ByVal value As String)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferID_Slot3", VALUELib.ValueType.A, value)
                CheckValueForLog("WaferID_Slot3", m_WaferID_Slot3, value, False)
            End Set
        End Property

        Public Property WaferID_Slot4() As String
            Get
                Return m_WaferID_Slot4
            End Get
            Set(ByVal value As String)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferID_Slot4", VALUELib.ValueType.A, value)
                CheckValueForLog("WaferID_Slot4", m_WaferID_Slot4, value, False)
            End Set
        End Property

        Public Property WaferID_Slot5() As String
            Get
                Return m_WaferID_Slot5
            End Get
            Set(ByVal value As String)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferID_Slot5", VALUELib.ValueType.A, value)
                CheckValueForLog("WaferID_Slot5", m_WaferID_Slot5, value, False)
            End Set
        End Property

        Public Property WaferID_Slot6() As String
            Get
                Return m_WaferID_Slot6
            End Get
            Set(ByVal value As String)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferID_Slot6", VALUELib.ValueType.A, value)
                CheckValueForLog("WaferID_Slot6", m_WaferID_Slot6, value, False)
            End Set
        End Property

        Public Property WaferID_Slot7() As String
            Get
                Return m_WaferID_Slot7
            End Get
            Set(ByVal value As String)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferID_Slot7", VALUELib.ValueType.A, value)
                CheckValueForLog("WaferID_Slot7", m_WaferID_Slot7, value, False)
            End Set
        End Property

        Public Property WaferID_Slot8() As String
            Get
                Return m_WaferID_Slot8
            End Get
            Set(ByVal value As String)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferID_Slot8", VALUELib.ValueType.A, value)
                CheckValueForLog("WaferID_Slot8", m_WaferID_Slot8, value, False)
            End Set
        End Property

        Public Property Process_Recipe_Name() As String
            Get
                Return m_Process_Recipe_Name
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Recipe", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Recipe_Name", m_Process_Recipe_Name, value, False)
            End Set
        End Property

        Public Overridable Property Process_Mode() As String
            Get
                Return m_Process_Mode
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessingMode", VALUELib.ValueType.F4, ChangeTypeUpdateGEM(value))
                CheckValueForLog("Process_Mode", m_Process_Mode, value, False)
            End Set
        End Property

        Public Overridable Property Process_Revolution_Count() As String
            Get
                Return m_Process_Revolution_Count
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Process_Revolution_Count", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Revolution_Count", m_Process_Revolution_Count, value, False)

                If Process_Mode = ConstEnum.PROCESS_MODE_REVOLUTION AndAlso String.IsNullOrEmpty(value) = False Then
                    Dim strimvalue As String() = Split(value, "Rev: ")
                    If strimvalue.Length = 2 Then
                        Dim lstTime As String() = Split(strimvalue(1), "/")
                        If lstTime.Length = 2 Then
                            Dim fvalue As Double = 0
                            If Double.TryParse(lstTime(0), fvalue) Then
                                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RevolutionCount", VALUELib.ValueType.F4, fvalue)
                            Else
                                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RevolutionCount", VALUELib.ValueType.F4, 0)
                            End If

                            If Double.TryParse(lstTime(1), fvalue) Then
                                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalRevolutionCount", VALUELib.ValueType.F4, fvalue)
                            Else
                                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalRevolutionCount", VALUELib.ValueType.F4, 0)
                            End If
                        End If
                    End If
                End If
            End Set
        End Property

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

                CheckValueForLog("ProcessMonitor_Status_Readback", m_strProcessMonitor_Status_Readback, value, False)
            End Set
        End Property

        Public Property Process_Control_Device_Start() As String
            Get
                Return m_Process_Control_Device_Start
            End Get
            Set(ByVal value As String)
                SequenceRunningStatusText(Me.Name, RECIPE_PROCESS_SEQ_NAME, WorkingStatuses.On)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_DeviceStart_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Control_Device_Start", m_Process_Control_Device_Start, value, False)
                BeginCountingWaferProcessTime()
                AVPLib.Utils.TurnOffSystem_Light(False, Me.Name)
                ChangeProcessState(ConstEnum.enumProcessStatus.eStart)
            End Set
        End Property
        Public Property Process_Control_Device_Stop() As String
            Get
                Return m_Process_Control_Device_Stop
            End Get
            Set(ByVal value As String)
                SequenceRunningStatusText(Me.Name, RECIPE_PROCESS_SEQ_NAME, WorkingStatuses.Off)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_DeviceStop_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Control_Device_Stop", m_Process_Control_Device_Stop, value, False)
                AVPLib.Utils.TurnOffSystem_Light(True, Me.Name)
                ChangeProcessState(ConstEnum.enumProcessStatus.eStop)
            End Set
        End Property
        Public Property Process_Control_Device_Pause() As String
            Get
                Return m_Process_Control_Device_Pause
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_DevicePause_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Control_Device_Pause", m_Process_Control_Device_Pause, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.ePause)
            End Set
        End Property
        Public Property Process_Control_Device_Continue() As String
            Get
                Return m_Process_Control_Device_Continue
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_DeviceContinue_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Control_Device_Continue", m_Process_Control_Device_Continue, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.eContinue)
            End Set
        End Property
        Public Property Process_Control_Device_End_Step() As String
            Get
                Return m_Process_Control_Device_End_Step
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Process_Control_Device_End_Step", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Control_Device_End_Step", m_Process_Control_Device_End_Step, value, False)
            End Set
        End Property
        Public Property Process_Control_Device_Error() As String
            Get
                Return m_Process_Control_Device_Error
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_DeviceError_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Control_Device_Error", m_Process_Control_Device_Error, value, False)
                AVPLib.Utils.TurnOffSystem_Light(True, Me.Name)
                ChangeProcessState(ConstEnum.enumProcessStatus.eError)
            End Set
        End Property
        Public Property Process_Control_Device_Reset_Error() As String
            Get
                Return m_Process_Control_Device_Reset_Error
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Process_Control_Device_Reset_Error", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Control_Device_Reset_Error", m_Process_Control_Device_Reset_Error, value, False)
            End Set
        End Property
        Public WriteOnly Property RecipeProcessingStatus() As String
            Set(ByVal value As String)
                Dim iValue As Integer = -1
                If (Integer.TryParse(value, iValue)) Then
                    Dim PropertyNames As ArrayList = New ArrayList()
                    Dim values As ArrayList = New ArrayList()
                    Select Case iValue
                        Case ConstEnum.enumProcessStatus.eError
                            PropertyNames.Add("Process_Control_Device_Error")
                        Case ConstEnum.enumProcessStatus.eStop
                            PropertyNames.Add("Process_Control_Device_Stop")
                        Case ConstEnum.enumProcessStatus.eStart
                            PropertyNames.Add("Process_Control_Device_Start")
                        Case ConstEnum.enumProcessStatus.ePause
                            PropertyNames.Add("Process_Control_Device_Pause")
                        Case ConstEnum.enumProcessStatus.eResetError
                            PropertyNames.Add("Process_Control_Device_Reset_Error")
                        Case ConstEnum.enumProcessStatus.eEndStep
                            PropertyNames.Add("Process_Control_Device_End_Step")
                        Case ConstEnum.enumProcessStatus.eContinue
                            PropertyNames.Add("Process_Control_Device_Continue")
                    End Select
                    values.Add(value)
                    Me.ChangeStatus(PropertyNames, values)
                End If
            End Set
        End Property

        Public Property Process_Control_Send_Run_Data_File_Name() As String
            Get
                Return m_Process_Control_Send_Run_Data_File_Name
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Process_Control_Send_Run_Data_File_Name", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Control_Send_Run_Data_File_Name", m_Process_Control_Send_Run_Data_File_Name, value, False)
            End Set
        End Property
        Public Property Process_Control_Get_Run_Data_File_Name() As WorkingStatuses
            Get
                Return m_Process_Control_Get_Run_Data_File_Name
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Process_Control_Get_Run_Data_File_Name", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Control_Get_Run_Data_File_Name", m_Process_Control_Get_Run_Data_File_Name, value, False)
            End Set
        End Property
        Public Property Copyrecipe_To_Pmfolder() As String
            Get
                Return m_Copyrecipe_To_Pmfolder
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Copyrecipe_To_Pmfolder", VALUELib.ValueType.A, value)
                CheckValueForLog("Copyrecipe_To_Pmfolder", m_Copyrecipe_To_Pmfolder, value, False)
            End Set
        End Property
        Public Property Process_Remaining_Time() As String
            Get
                Return m_Process_Remaining_Time
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RemainingTime", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Remaining_Time", m_Process_Remaining_Time, value, False)
                MyBase.RemainingTime = value
            End Set
        End Property
        Public Property Process_Elapsed_Time() As String
            Get
                Return m_Process_Elapsed_Time
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ElapsedTime", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Elapsed_Time", m_Process_Elapsed_Time, value, False)
                MyBase.ElapsedTime = value
                MyBase.StepTime = value
            End Set
        End Property
        Public Property Process_Total_Time() As String
            Get
                Return m_Process_Total_Time
            End Get
            Set(ByVal value As String)
                ''TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Process_Total_Time", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Total_Time", m_Process_Total_Time, value, False)
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

                UpdateWaferProcessTimeInRealTime(value)
            End Set
        End Property
        Public Overridable Property Process_Current_Step() As String
            Get
                Return m_Process_Current_Step
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Process_Current_Step", m_Process_Current_Step, value, False)

                ' Update SECS/GEM variables by Hai Tran
                ' Var Name: PMX.ProcessMonitor_ProcessStep
                Dim iValue As Integer
                If Integer.TryParse(value, iValue) Then
                    iValue += 1
                    Dim temp As String = iValue.ToString()

                    If Not String.IsNullOrEmpty(CurrentRecipeLoop) Then
                        temp = iValue.ToString() & CurrentRecipeLoop
                    End If

                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_ProcessStep", VALUELib.ValueType.A, temp)
                Else
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_ProcessStep", VALUELib.ValueType.A, value)
                End If
            End Set
        End Property
        Public Overridable Property Process_Total_Steps() As String
            Get
                Return m_Process_Total_Steps
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_TotalStep", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Total_Steps", m_Process_Total_Steps, value, False)
            End Set
        End Property
        Public Property Wafer_Processing_Status_Readback() As Integer
            Get
                Return m_Wafer_Processing_Status_Readback
            End Get
            Set(ByVal value As Integer)
                'Need to review this property with wafer processing status
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Wafer_Processing_Status_Readback", m_Wafer_Processing_Status_Readback, value, False)
            End Set
        End Property
        Public Property Auto_Pumpdown_Seq_Status() As WorkingStatuses
            Get
                Return m_Auto_Pumpdown_Seq
            End Get
            Set(ByVal value As WorkingStatuses)
                SequenceRunningStatusText(Me.Name, AUTO_PUMPDOWN_SEQ_NAME, value)

                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "AutoPumpDownStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Auto_Pumpdown_Seq", m_Auto_Pumpdown_Seq, value, False)
            End Set
        End Property
        Public Property Auto_Vent_Seq_Status() As WorkingStatuses
            Get
                Return m_Auto_Vent_Seq
            End Get
            Set(ByVal value As WorkingStatuses)
                SequenceRunningStatusText(Me.Name, AUTO_VENT_SEQ_NAME, value)

                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "AutoVentStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Auto_Vent_Seq", m_Auto_Vent_Seq, value, False)
            End Set
        End Property
        Public Property Pump_Purge_Seq_Status() As WorkingStatuses
            Get
                Return m_Pump_Purge_Seq
            End Get
            Set(ByVal value As WorkingStatuses)
                SequenceRunningStatusText(Me.Name, PUMP_PURGE_SEQ_NAME, value)

                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "AutoPumpPurgeStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Pump_Purge_Seq", m_Pump_Purge_Seq, value, False)
            End Set
        End Property
        Public Property IG_Degas_Seq_Status() As WorkingStatuses
            Get
                Return m_IG_Degas_Seq
            End Get
            Set(ByVal value As WorkingStatuses)
                SequenceRunningStatusText(Me.Name, IG_DEGAS_SEQ_NAME, value)

                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "IGDegasStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("IG_Degas_Seq", m_IG_Degas_Seq, value, False)
            End Set
        End Property
        Public Property Shutdown_Power_Seq_Status() As WorkingStatuses
            Get
                Return m_Shutdown_Power_Seq
            End Get
            Set(ByVal value As WorkingStatuses)
                SequenceRunningStatusText(Me.Name, SHUTDOWN_POWER_SEQ_NAME, value)

                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "MachineShutDownPowerStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Shutdown_Power_Seq", m_Shutdown_Power_Seq, value, False)
            End Set
        End Property

        Public Property Initialize_Motion() As WorkingStatuses
            Get
                Return m_Initialize_Motion
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Initialize_Motion", VALUELib.ValueType.U1, value)
                CheckValueForLog("Initialize_Motion", m_Initialize_Motion, value, False)
            End Set
        End Property
        Public Overridable Property Initialized_Motion() As WorkingStatuses
            Get
                Return m_Initialized_Motion
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Initialized_Motion", VALUELib.ValueType.U1, value)
                CheckValueForLog("Initialized_Motion", m_Initialized_Motion, value, False)
            End Set
        End Property
        Public Property Auto_Power_Seq() As WorkingStatuses
            Get
                Return m_Auto_Power_Seq
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                CheckValueForLog("Auto_Power_Seq", m_Auto_Power_Seq, value, False)
            End Set
        End Property
        Public Property Gas1_Shutoff_Valve() As WorkingStatuses
            Get
                Return m_Gas1_Shutoff_Valve
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1ShutOffValveStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Gas1_Shutoff_Valve", m_Gas1_Shutoff_Valve, value, False)
            End Set
        End Property
        Public Property Gas2_Shutoff_Valve() As WorkingStatuses
            Get
                Return m_Gas2_Shutoff_Valve
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2ShutOffValveStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Gas2_Shutoff_Valve", m_Gas2_Shutoff_Valve, value, False)
            End Set
        End Property
        Public Property Gas3_Shutoff_Valve() As WorkingStatuses
            Get
                Return m_Gas3_Shutoff_Valve
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3ShutOffValveStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Gas3_Shutoff_Valve", m_Gas3_Shutoff_Valve, value, False)
            End Set
        End Property
        Public Property Gas4_Shutoff_Valve() As WorkingStatuses
            Get
                Return m_Gas4_Shutoff_Valve
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas4ShutOffValveStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Gas4_Shutoff_Valve", m_Gas4_Shutoff_Valve, value, False)
            End Set
        End Property
        Public Property Gas5_Shutoff_Valve() As WorkingStatuses
            Get
                Return m_Gas5_Shutoff_Valve
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas5ShutOffValveStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Gas5_Shutoff_Valve", m_Gas5_Shutoff_Valve, value, False)
            End Set
        End Property
        Public Property Gas1_Flowrate_Readback() As Double
            Get
                Return m_Gas1_Flowrate_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GasController_Gas1_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas1_Flowrate_Readback", m_Gas1_Flowrate_Readback, value, False)
            End Set
        End Property
        Public Property Gas2_Flowrate_Readback() As Double
            Get
                Return m_Gas2_Flowrate_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GasController_Gas2_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas2_Flowrate_Readback", m_Gas2_Flowrate_Readback, value, False)
            End Set
        End Property
        Public Property Gas3_Flowrate_Readback() As Double
            Get
                Return m_Gas3_Flowrate_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GasController_Gas3_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas3_Flowrate_Readback", m_Gas3_Flowrate_Readback, value, False)
            End Set
        End Property
        Public Property Gas4_Flowrate_Readback() As Double
            Get
                Return m_Gas4_Flowrate_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GasController_Gas4_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas4_Flowrate_Readback", m_Gas4_Flowrate_Readback, value, False)
            End Set
        End Property
        Public Property Gas5_Flowrate_Readback() As Double
            Get
                Return m_Gas5_Flowrate_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GasController_Gas5_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas5_Flowrate_Readback", m_Gas5_Flowrate_Readback, value, False)
            End Set
        End Property
        Public Property Gas1_Flowrate_Program() As Double
            Get
                Return m_Gas1_Flowrate_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GasController_Gas1_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas1_Flowrate_Program", m_Gas1_Flowrate_Program, value, False)
            End Set
        End Property
        Public Property Gas2_Flowrate_Program() As Double
            Get
                Return m_Gas2_Flowrate_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GasController_Gas2_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas2_Flowrate_Program", m_Gas2_Flowrate_Program, value, False)
            End Set
        End Property
        Public Property Gas3_Flowrate_Program() As Double
            Get
                Return m_Gas3_Flowrate_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GasController_Gas3_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas3_Flowrate_Program", m_Gas3_Flowrate_Program, value, False)
            End Set
        End Property
        Public Property Gas4_Flowrate_Program() As Double
            Get
                Return m_Gas4_Flowrate_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GasController_Gas4_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas4_Flowrate_Program", m_Gas4_Flowrate_Program, value, False)
            End Set
        End Property
        Public Property Gas5_Flowrate_Program() As Double
            Get
                Return m_Gas5_Flowrate_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "GasController_Gas5_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Gas5_Flowrate_Program", m_Gas5_Flowrate_Program, value, False)
            End Set
        End Property
        Public Property Main_Dist_Valve() As WorkingStatuses
            Get
                Return m_Main_Dist_Valve
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Main_Dist_Valve", VALUELib.ValueType.U1, value)
                CheckValueForLog("Main_Dist_Valve", m_Main_Dist_Valve, value, False)
            End Set
        End Property
        Public Property Sec_Dist_Valve() As WorkingStatuses
            Get
                Return m_Sec_Dist_Valve
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Sec_Dist_Valve", VALUELib.ValueType.U1, value)
                CheckValueForLog("Sec_Dist_Valve", m_Sec_Dist_Valve, value, False)
            End Set
        End Property

        ''' <author>
        '''   	<name>Dung Pham</name>
        '''   	<date>2020-02-05</date>
        ''' </author>
        ''' <summary>
        ''' Gas1MFCDevinetStatus
        ''' </summary>
        Private m_Gas1MFCDevinetStatus As WorkingStatuses = WorkingStatuses.On
        Public Property Gas1MFCDevinetStatus() As WorkingStatuses
            Get
                Return m_Gas1MFCDevinetStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_Gas1MFCDevinetStatus = value
                CheckValueForLog("Gas1MFCDevinetStatus", m_Gas1MFCDevinetStatus, value)
            End Set
        End Property

        ''' <author>
        '''   	<name>Dung Pham</name>
        '''   	<date>2020-02-05</date>
        ''' </author>
        ''' <summary>
        ''' Gas2MFCDevinetStatus
        ''' </summary>
        Private m_Gas2MFCDevinetStatus As WorkingStatuses = WorkingStatuses.On
        Public Property Gas2MFCDevinetStatus() As WorkingStatuses
            Get
                Return m_Gas2MFCDevinetStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_Gas2MFCDevinetStatus = value
                CheckValueForLog("Gas2MFCDevinetStatus", m_Gas2MFCDevinetStatus, value)
            End Set
        End Property

        ''' <author>
        '''   	<name>Dung Pham</name>
        '''   	<date>2020-02-05</date>
        ''' </author>
        ''' <summary>
        ''' Gas3MFCDevinetStatus
        ''' </summary>
        Private m_Gas3MFCDevinetStatus As WorkingStatuses = WorkingStatuses.On
        Public Property Gas3MFCDevinetStatus() As WorkingStatuses
            Get
                Return m_Gas3MFCDevinetStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_Gas3MFCDevinetStatus = value
                CheckValueForLog("Gas3MFCDevinetStatus", m_Gas3MFCDevinetStatus, value)
            End Set
        End Property

        ''' <author>
        '''   	<name>Dung Pham</name>
        '''   	<date>2020-02-05</date>
        ''' </author>
        ''' <summary>
        ''' Gas4MFCDevinetStatus
        ''' </summary>
        Private m_Gas4MFCDevinetStatus As WorkingStatuses = WorkingStatuses.On
        Public Property Gas4MFCDevinetStatus() As WorkingStatuses
            Get
                Return m_Gas4MFCDevinetStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_Gas4MFCDevinetStatus = value
                CheckValueForLog("Gas4MFCDevinetStatus", m_Gas4MFCDevinetStatus, value)
            End Set
        End Property

        ''' <author>
        '''   	<name>Dung Pham</name>
        '''   	<date>2020-02-05</date>
        ''' </author>
        ''' <summary>
        ''' Gas5MFCDevinetStatus
        ''' </summary>
        Private m_Gas5MFCDevinetStatus As WorkingStatuses = WorkingStatuses.On
        Public Property Gas5MFCDevinetStatus() As WorkingStatuses
            Get
                Return m_Gas5MFCDevinetStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_Gas5MFCDevinetStatus = value
                CheckValueForLog("Gas5MFCDevinetStatus", m_Gas5MFCDevinetStatus, value)
            End Set
        End Property

        Public Property Isolation_Valve_Status() As WorkingStatuses
            Get
                Return m_Isolation_Valve_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Isolation_Valve_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Isolation_Valve_Status", m_Isolation_Valve_Status, value, False)
            End Set
        End Property
        Public Property Hivac_Valve_Status() As WorkingStatuses
            Get
                Return m_Hivac_Valve_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "HivacValveStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Hivac_Valve_Status", m_Hivac_Valve_Status, value, False)
            End Set
        End Property
        Public Property Baratron_Valve_Status() As WorkingStatuses
            Get
                Return m_Baratron_Valve_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BaratronValveStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Baratron_Valve_Status", m_Baratron_Valve_Status, value, False)
            End Set
        End Property
        Public Overridable Property CG_Relay_Status() As WorkingStatuses
            Get
                Return m_CG_Relay_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CG_Relay_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("CG_Relay_Status", m_CG_Relay_Status, value, False)
            End Set
        End Property
        Public Property Foreline_CG_Pressure() As Double
            Get
                Return m_Foreline_CG_Pressure
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Foreline_CG_Pressure", VALUELib.ValueType.F4, value)
                CheckValueForLog("Foreline_CG_Pressure", m_Foreline_CG_Pressure, value, False)
            End Set
        End Property
        Public Property Foreline_CG_Relay_Status() As WorkingStatuses
            Get
                Return m_Foreline_CG_Relay_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Foreline_CG_Relay_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Foreline_CG_Relay_Status", m_Foreline_CG_Relay_Status, value, False)
            End Set
        End Property
        Public Property Baratron_Pressure() As Double
            Get
                Return m_Baratron_Pressure
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "BaratronPressure", VALUELib.ValueType.F4, value)
                CheckValueForLog("Baratron_Pressure", m_Baratron_Pressure, value, False)
            End Set
        End Property
        Public Property Mechanical_Pump_CG_Pressure() As Double
            Get
                Return m_Mechanical_Pump_CG_Pressure
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Mechanical_Pump_CG_Pressure", VALUELib.ValueType.F4, value)
                CheckValueForLog("Mechanical_Pump_CG_Pressure", m_Mechanical_Pump_CG_Pressure, value, False)

                If RobotConfigurationValues.SHARED_MP_WITH_PM Then
                    UpdateRoughPumpToTM(Equipments.RoughPumpMachine1, "CG", value)
                End If
            End Set
        End Property
        Public Property Mechanical_Pump_CG_Relay_Status() As WorkingStatuses
            Get
                Return m_Mechanical_Pump_CG_Relay_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Mechanical_Pump_CG_Relay_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Mechanical_Pump_CG_Relay_Status", m_Mechanical_Pump_CG_Relay_Status, value, False)

                If RobotConfigurationValues.SHARED_MP_WITH_PM Then
                    UpdateRoughPumpToTM(Equipments.RoughPumpMachine1, "VacSwitchStatus", value)
                End If
            End Set
        End Property
        Public Overridable Property Mechanical_Pump_Status() As WorkingStatuses
            Get
                Return m_Mechanical_Pump_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Mechanical_Pump_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Mechanical_Pump_Status", m_Mechanical_Pump_Status, value, False)

                If RobotConfigurationValues.SHARED_MP_WITH_PM Then
                    UpdateRoughPumpToTM(Equipments.CassettesModule, "RoughPump1Status", value)
                End If
            End Set
        End Property

        Private m_Mechanical_Pump_Serial_Communication_Status As WorkingStatuses
        Public Property MPump_Serial_Communication_Status() As WorkingStatuses
            Get
                Return m_Mechanical_Pump_Serial_Communication_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "MPump_Serial_Communication_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("MPump_Serial_Communication_Status", m_Mechanical_Pump_Serial_Communication_Status, value, False)
            End Set
        End Property

        Public Property Chamberinterlock_Substrate_Table_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Substrate_Table_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Substrate_Table_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Substrate_Table_Water_Status", m_Chamberinterlock_Substrate_Table_Water_Status, value, False)
            End Set
        End Property
        Public Property Chamberinterlock_Air_Pressure_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Air_Pressure_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Air_Pressure_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Air_Pressure_Status", m_Chamberinterlock_Air_Pressure_Status, value, False)
            End Set
        End Property
        Public Property Chamberinterlock_Door_Closed_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Door_Closed_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Door_Closed_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Door_Closed_Status", m_Chamberinterlock_Door_Closed_Status, value, False)
            End Set
        End Property
        Public Property Chamberinterlock_Lid_Closed_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Lid_Closed_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Lid_Closed_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Lid_Closed_Status", m_Chamberinterlock_Lid_Closed_Status, value, False)
            End Set
        End Property
        Public Property Chamberinterlock_Target1_3_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Target1_3_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Target1_3_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Target1_Water_Status", m_Chamberinterlock_Target1_3_Water_Status, value, False)
            End Set
        End Property
        Public Property Chamberinterlock_Target2_4_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Target2_4_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Target2_4_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Target2_Water_Status", m_Chamberinterlock_Target2_4_Water_Status, value, False)
            End Set
        End Property

        Public Property Chamberinterlock_Target_MB_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Target_MB_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Target_MB_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Matchbox1_Water_Status", m_Chamberinterlock_Target_MB_Water_Status, value, False)
            End Set
        End Property
        Public Property Chamberinterlock_Bias_MB_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Bias_MB_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Bias_MB_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Matchbox2_Water_Status", m_Chamberinterlock_Bias_MB_Water_Status, value, False)
            End Set
        End Property
        Public Property Chamberinterlock_Turbo_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Turbo_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Turbo_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Turbo_Water_Status", m_Chamberinterlock_Turbo_Water_Status, value, False)
            End Set
        End Property

        Public Property Chamberinterlock_PS_Interlock_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Ps_Interlock_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_PS_Interlock_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_PS_Interlock_Status", m_Chamberinterlock_Ps_Interlock_Status, value, False)
            End Set
        End Property
        Public Property Chamberinterlock_Devicenet_Comm() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Devicenet_Comm
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Devicenet_Comm", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Devicenet_Comm", m_Chamberinterlock_Devicenet_Comm, value, False)
            End Set
        End Property
        Public Property Chamberinterlock_Target_Panels() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Target_Panels
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Target_Panels", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Target_Panels", m_Chamberinterlock_Target_Panels, value, False)
            End Set
        End Property
        Private m_Motion_Communication_Status As WorkingStatuses
        Public Property Motion_Communication_Status() As WorkingStatuses
            Get
                Return m_Motion_Communication_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Motion_Communication_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Galil_Motion_Communication_Status", m_Motion_Communication_Status, value, False)
            End Set
        End Property
        Public Property Substrate_Goto_Slot() As Integer
            Get
                Return m_Substrate_Goto_Slot
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Goto_Slot", VALUELib.ValueType.F4, value)
                CheckValueForLog("Substrate_Goto_Slot", m_Substrate_Goto_Slot, value, False)
            End Set
        End Property
        Public Property Substrate_Current_Station() As Integer
            Get
                Return m_Substrate_Current_Station
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Current_Station", VALUELib.ValueType.F4, value)
                CheckValueForLog("Substrate_Current_Station", m_Substrate_Current_Station, value, False)
            End Set
        End Property

        Public Property Round_Substrate_Current_Station() As Integer
            Get
                Return m_Round_Substrate_Current_Station
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Round_Substrate_Current_Station", VALUELib.ValueType.F4, value)
                CheckValueForLog("Round_Substrate_Current_Station", m_Round_Substrate_Current_Station, value, False)
            End Set
        End Property

        Public Overridable Property Substrate_Table_Rotate_Home() As WorkingStatuses
            Get
                Return m_Substrate_Goto_Home
            End Get
            Set(ByVal value As WorkingStatuses)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Goto_Home", VALUELib.ValueType.U1, value)
                CheckValueForLog("Substrate_Goto_Home", m_Substrate_Goto_Home, value, False)
            End Set
        End Property
        Public Overridable Property Substrate_Table_Lift_Home() As WorkingStatuses
            Get
                Return m_Substrate_Table_Lift_Home
            End Get
            Set(ByVal value As WorkingStatuses)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Table_Lift_Home", VALUELib.ValueType.U1, value)
                CheckValueForLog("Substrate_Table_Lift_Home", m_Substrate_Table_Lift_Home, value, False)
            End Set
        End Property
        Public Property Substrate_Table_Up_Down_Status() As WorkingStatuses
            Get
                Return m_Substrate_Table_Up_Down_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Table_Up_Down_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Substrate_Table_Up_Down_Status", m_Substrate_Table_Up_Down_Status, value, False)
            End Set
        End Property
        Public Property Is_MotionInitalized() As WorkingStatuses
            Get
                Return m_Is_MotionInitalized
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Is_MotionInitalized", m_Is_MotionInitalized, value, False)
            End Set
        End Property


        ''' <author>
        '''   	<name>Dung Pham</name>
        '''   	<date> 2018-12-07</date>
        ''' </author>
        ''' <summary>
        ''' Enabel IGFilament.
        ''' </summary>
        Public Property EnableIGFilament() As Integer
            Get
                Return m_EnableIGFilament
            End Get
            Set(ByVal value As Integer)
                m_EnableIGFilament = value
                CheckValueForLog("EnableIGFilament", m_EnableIGFilament, value)
            End Set
        End Property

        ''' <author>
        '''   	<name>Dung Pham</name>
        '''   	<date> 2018-12-07</date>
        ''' </author>
        ''' <summary>
        ''' Switch IG Filament.
        ''' </summary>
        Public Property SwitchIGFilament() As String
            Get
                Return m_SwitchIGFilament
            End Get
            Set(ByVal value As String)
                m_SwitchIGFilament = value
                CheckValueForLog("SwitchIGFilament", m_SwitchIGFilament, value)
            End Set
        End Property

        Public Property Substrate_Table_Rotate_Sequence_State() As WorkingStatuses
            Get
                Return m_Substrate_Table_Rotate_Sequence_State
            End Get
            Set(ByVal value As WorkingStatuses)
                If value <> m_Substrate_Table_Rotate_Sequence_State Then
                    AVPLib.Log.avpLogger.Error("Substrate_Table_Rotate_Sequence_State: " & value.ToString())
                End If
                CheckValueForLog("Substrate_Table_Rotate_Sequence_State", m_Substrate_Table_Rotate_Sequence_State, value, False)
            End Set
        End Property

        Public Overridable Property Substrate_Lift_Up_Down_Status() As WorkingStatuses
            Get
                Return m_Substrate_Lift_Up_Down_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Lift_Up_Down_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Substrate_Lift_Up_Down_Status", m_Substrate_Lift_Up_Down_Status, value, False)
            End Set
        End Property
        Public Property Substrate_Table_Rotate_Speed() As Double
            Get
                Return m_Substrate_Table_Rotate_Speed
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Table_Rotate_Speed_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Substrate_Table_Rotate_Speed", m_Substrate_Table_Rotate_Speed, value, False)
            End Set
        End Property
        Public Property Substrate_Table_Rotate_Speed_Readback() As Double
            Get
                Return m_Substrate_Table_Rotate_Speed_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Table_Rotate_Speed_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Substrate_Table_Rotate_Speed_Readback", m_Substrate_Table_Rotate_Speed_Readback, value, False)
            End Set
        End Property
        Public Property Substrate_Table_Rotate_Pos_In_Unit_Readback() As Double
            Get
                Return m_Substrate_Table_Rotate_Pos_In_Unit_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Substrate_Table_Rotate_Pos_In_Unit_Readback", m_Substrate_Table_Rotate_Pos_In_Unit_Readback, value, False)
            End Set
        End Property
        Public Property Number_Of_Unit_Per_Revolution_Readback() As Double
            Get
                Return m_Number_Of_Unit_Per_Revolution_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Number_Of_Unit_Per_Revolution_Readback", m_Number_Of_Unit_Per_Revolution_Readback, value, False)
            End Set
        End Property
        Public Property Substrate_Table_Rotate_Status() As WorkingStatuses
            Get
                Return m_Substrate_Table_Rotate_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Table_Rotate_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Substrate_Table_Rotate_Status", m_Substrate_Table_Rotate_Status, value, False)
            End Set
        End Property
        Public Property Substrate_Table_Current_Position_Program() As Double
            Get
                Return m_Substrate_Table_Current_Position_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Table_Position_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Substrate_Table_Current_Position_Program", m_Substrate_Table_Current_Position_Program, value, False)
            End Set
        End Property
        Public Property Substrate_Table_Current_Position_Readback() As Double
            Get
                Return m_Substrate_Table_Current_Position_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Table_Position_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Substrate_Table_Current_Position_Readback", m_Substrate_Table_Current_Position_Readback, value, False)
            End Set
        End Property
        Public Property Target1_Shutter_Status() As WorkingStatuses
            Get
                Return m_Target1_Shutter_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target1_Shutter_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target1_Shutter_Status", m_Target1_Shutter_Status, value, False)
            End Set
        End Property
        Public Property Target2_Shutter_Status() As WorkingStatuses
            Get
                Return m_Target2_Shutter_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target2_Shutter_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target2_Shutter_Status", m_Target2_Shutter_Status, value, False)
            End Set
        End Property
        Public Property Target3_Shutter_Status() As WorkingStatuses
            Get
                Return m_Target3_Shutter_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target3_Shutter_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target3_Shutter_Status", m_Target3_Shutter_Status, value, False)
            End Set
        End Property
        Public Property Target4_Shutter_Status() As WorkingStatuses
            Get
                Return m_Target4_Shutter_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target4_Shutter_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target4_Shutter_Status", m_Target4_Shutter_Status, value, False)
            End Set
        End Property
        Public Property Substrate_Table_Up_Down_Moving() As WorkingStatuses
            Get
                Return m_Substrate_Table_Up_Down_Moving
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Substrate_Table_Up_Down_Moving", m_Substrate_Table_Up_Down_Moving, value, False)
            End Set
        End Property
        Public Overridable Property Water_Pump_T_Readback() As Double
            Get
                Return m_Water_Pump_T_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Water_Pump_T_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Water_Pump_T_Readback", m_Water_Pump_T_Readback, value, False)
            End Set
        End Property
        Public Property Water_Pump_Status() As WorkingStatuses
            Get
                Return m_Water_Pump_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Water_Pump_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Water_Pump_Status", m_Water_Pump_Status, value, False)
            End Set
        End Property
        Public Property Water_Pump_Regen_Status() As WorkingStatuses
            Get
                Return m_Water_Pump_Regen_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Water_Pump_Regen_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Water_Pump_Regen_Status", m_Water_Pump_Regen_Status, value, False)
            End Set
        End Property
        Public Property Water_Pump_State_Status() As WorkingStatuses
            Get
                Return m_Water_Pump_State_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Water_Pump_State_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Water_Pump_State_Status", m_Water_Pump_State_Status, value, False)
            End Set
        End Property
        Public Overridable Property Water_Pump_Regen_Hour_Readback() As Double
            Get
                Return m_Water_Pump_Regen_Hour_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Water_Pump_Regen_Hour_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Water_Pump_Regen_Hour_Readback", m_Water_Pump_Regen_Hour_Readback, value, False)
            End Set
        End Property
        Public Overridable Property Water_Pump_Regen_Lifetime_Readback() As Double
            Get
                Return m_Water_Pump_Regen_Lifetime_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Water_Pump_Regen_LifeTimeHour_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Water_Pump_Regen_Lifetime_Readback", m_Water_Pump_Regen_Lifetime_Readback, value, False)
            End Set
        End Property
        Public Property Water_Pump_P_Command_Readback() As String
            Get
                Return m_Water_Pump_P_Command_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                CheckValueForLog("Water_Pump_P_Command_Readback", m_Water_Pump_P_Command_Readback, value, False)
            End Set
        End Property
        Public Property Water_Pump_Is_Communicating() As WorkingStatuses
            Get
                Return m_Water_Pump_Is_Communicating
            End Get
            Set(ByVal value As WorkingStatuses)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Water_Pump_Is_Communicating", VALUELib.ValueType.U1, value)
                CheckValueForLog("Water_Pump_Is_Communicating", m_Turbo_Pump_On_Off, value, False)
            End Set
        End Property
        Public Property Turbo_Pump_On_Off() As WorkingStatuses
            Get
                Return m_Turbo_Pump_On_Off
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Turbo_Pump_On_Off", VALUELib.ValueType.U1, value)
                CheckValueForLog("Turbo_Pump_On_Off", m_Turbo_Pump_On_Off, value, False)
            End Set
        End Property
        Public Overridable Property Turbo_Pump_On_Off_Rb() As WorkingStatuses
            Get
                Return m_Turbo_Pump_On_Off_Rb
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Turbo_Pump_On_Off_Readback", VALUELib.ValueType.U1, value)
                CheckValueForLog("Turbo_Pump_On_Off_Rb", m_Turbo_Pump_On_Off_Rb, value, False)
            End Set
        End Property
        Public Overridable Property Turbo_Pump_Uptospeed_Rb() As WorkingStatuses
            Get
                Return m_Turbo_Pump_Uptospeed_Rb
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Turbo_Pump_Uptospeed_Rb", VALUELib.ValueType.U1, value)
                CheckValueForLog("Turbo_Pump_Uptospeed_Rb", m_Turbo_Pump_Uptospeed_Rb, value, False)
            End Set
        End Property

        Public Property Turbo_Pump_Ramping_Percent_Rb() As Double
            Get
                Return m_Turbo_Pump_Ramping_Percent_Rb
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value
                CheckValueForLog("Turbo_Pump_Ramping_Percent_Rb", m_Turbo_Pump_Ramping_Percent_Rb, value, False)
            End Set
        End Property

        Public Property Vat_Valve_Communication_Status() As WorkingStatuses
            Get
                Return m_Vat_Valve_Communication_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Vat_Valve_Communication_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Vat_Valve_Communication_Status", m_Vat_Valve_Communication_Status, value, False)
            End Set
        End Property
        Public Property Vat_Valve_Controller_Pressure_Program() As Double
            Get
                Return m_Vat_Valve_Controller_Pressure_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Vat_Valve_Controller_Pressure_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Vat_Valve_Controller_Pressure_Program", m_Vat_Valve_Controller_Pressure_Program, value, False)
            End Set
        End Property
        Public Property Vat_Valve_Controller_Pressure_Readback() As Double
            Get
                Return m_Vat_Valve_Controller_Pressure_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Vat_Valve_Controller_Pressure_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Vat_Valve_Controller_Pressure_Readback", m_Vat_Valve_Controller_Pressure_Readback, value, False)
            End Set
        End Property
        Public Property Vat_Valve_Percentage_Program() As Double
            Get
                Return m_Vat_Valve_Percentage_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Vat_Valve_Percentage_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Vat_Valve_Percentage_Program", m_Vat_Valve_Percentage_Program, value, False)
            End Set
        End Property
        Public Property Vat_Valve_Percentage_Readback() As Double
            Get
                Return m_Vat_Valve_Percentage_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Vat_Valve_Percentage_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Vat_Valve_Percentage_Readback", m_Vat_Valve_Percentage_Readback, value, False)
            End Set
        End Property
        Public Property Vat_Valve_Controller_Auto_Zero() As WorkingStatuses
            Get
                Return m_Vat_Valve_Controller_Auto_Zero
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Vat_Valve_Controller_Auto_Zero", VALUELib.ValueType.U1, value)
                CheckValueForLog("Vat_Valve_Controller_Auto_Zero", m_Vat_Valve_Controller_Auto_Zero, value, False)
            End Set
        End Property
        Public Property Vat_Valve_Controller_Teach() As WorkingStatuses
            Get
                Return m_Vat_Valve_Controller_Teach
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Vat_Valve_Controller_Teach", VALUELib.ValueType.U1, value)
                CheckValueForLog("Vat_Valve_Controller_Teach", m_Vat_Valve_Controller_Teach, value, False)
            End Set
        End Property
        Public Property Vat_Valve_Controller_Sizeadjust() As WorkingStatuses
            Get
                Return m_Vat_Valve_Controller_Sizeadjust
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Vat_Valve_Controller_Sizeadjust", VALUELib.ValueType.U1, value)
                CheckValueForLog("Vat_Valve_Controller_Sizeadjust", m_Vat_Valve_Controller_Sizeadjust, value, False)
            End Set
        End Property
        Public Property Target1_Magnatron_On_Off() As WorkingStatuses
            Get
                Return m_Target1_Magnatron_On_Off
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target1_Magnatron_On_Off", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target1_Magnatron_On_Off", m_Target1_Magnatron_On_Off, value, False)
            End Set
        End Property
        Public Property Target1_Magnatron_Rotate_Status() As WorkingStatuses
            Get
                Return m_Target1_Magnatron_Rotate_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target1_Magnatron_Rotate_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target1_Magnatron_Rotate_Status", m_Target1_Magnatron_Rotate_Status, value, False)
            End Set
        End Property
        Public Property Target2_Magnatron_On_Off() As WorkingStatuses
            Get
                Return m_Target2_Magnatron_On_Off
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target2_Magnatron_On_Off", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target2_Magnatron_On_Off", m_Target2_Magnatron_On_Off, value, False)
            End Set
        End Property
        Public Property Target2_Magnatron_Rotate_Status() As WorkingStatuses
            Get
                Return m_Target2_Magnatron_Rotate_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target2_Magnatron_Rotate_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target2_Magnatron_Rotate_Status", m_Target2_Magnatron_Rotate_Status, value, False)
            End Set
        End Property
        Public Property Target3_Magnatron_On_Off() As WorkingStatuses
            Get
                Return m_Target3_Magnatron_On_Off
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target3_Magnatron_On_Off", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target3_Magnatron_On_Off", m_Target3_Magnatron_On_Off, value, False)
            End Set
        End Property
        Public Property Target3_Magnatron_Rotate_Status() As WorkingStatuses
            Get
                Return m_Target3_Magnatron_Rotate_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target3_Magnatron_Rotate_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target3_Magnatron_Rotate_Status", m_Target3_Magnatron_Rotate_Status, value, False)
            End Set
        End Property
        Public Property Target4_Magnatron_On_Off() As WorkingStatuses
            Get
                Return m_Target4_Magnatron_On_Off
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target4_Magnatron_On_Off", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target4_Magnatron_On_Off", m_Target4_Magnatron_On_Off, value, False)
            End Set
        End Property
        Public Property Target4_Magnatron_Rotate_Status() As WorkingStatuses
            Get
                Return m_Target4_Magnatron_Rotate_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target4_Magnatron_Rotate_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target4_Magnatron_Rotate_Status", m_Target4_Magnatron_Rotate_Status, value, False)
            End Set
        End Property
        Public Property RF_Target_Communication_Status() As WorkingStatuses
            Get
                Return m_RF_Target_Communication_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_Communication_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("RF_Target_Communication_Status", m_RF_Target_Communication_Status, value, False)
            End Set
        End Property
        Public Property RF_Target_Power_Readback() As Double
            Get
                Return m_RF_Target_Power_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_Power_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_Power_Readback", m_RF_Target_Power_Readback, value, False)
            End Set
        End Property
        Public Property RF_Target_Power_Program() As Double
            Get
                Return m_RF_Target_Power_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_Power_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_Power_Program", m_RF_Target_Power_Program, value, False)
            End Set
        End Property
        Public Property RF_Target_Reflected_Power_Readback() As Double
            Get
                Return m_RF_Target_Reflected_Power_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_Reflected_Power_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_Reflected_Power_Readback", m_RF_Target_Reflected_Power_Readback, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_Voltage_Readback() As Double
            Get
                Return m_RF_Target_MB_Voltage_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Voltage_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_MB_Voltage_Readback", m_RF_Target_MB_Voltage_Readback, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_C1_Program() As Double
            Get
                Return m_RF_Target_MB_C1_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_C1_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_MB_C1_Program", m_RF_Target_MB_C1_Program, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_C1_Readback() As Double
            Get
                Return m_RF_Target_MB_C1_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_C1_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_MB_C1_Readback", m_RF_Target_MB_C1_Readback, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_C2_Program() As Double
            Get
                Return m_RF_Target_MB_C2_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_C2_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_MB_C2_Program", m_RF_Target_MB_C2_Program, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_C2_Readback() As Double
            Get
                Return m_RF_Target_MB_C2_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_C2_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_MB_C2_Readback", m_RF_Target_MB_C2_Readback, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_Match_Mode_Program() As WorkingStatuses
            Get
                Return m_RF_Target_MB_Match_Mode_Program
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Match_Mode_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_MB_Match_Mode_Program", m_RF_Target_MB_Match_Mode_Program, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_Match_Mode_Readback() As WorkingStatuses
            Get
                Return m_RF_Target_MB_Match_Mode_Readback
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Match_Mode_Readback", VALUELib.ValueType.U1, value)
                CheckValueForLog("RF_Target_MB_Match_Mode_Readback", m_RF_Target_MB_Match_Mode_Readback, value, False)
            End Set
        End Property
        Public Property RF_Target_Voltage_SP() As Double
            Get
                Return m_RF_Target_Voltage_SP
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                CheckValueForLog("RF_Target_Voltage_SP", m_RF_Target_Voltage_SP, value, False)
            End Set
        End Property
        Public Property Bias_Communication_Status() As WorkingStatuses
            Get
                Return m_Bias_Communication_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_Communication_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Bias_Communication_Status", m_Bias_Communication_Status, value, False)
            End Set
        End Property
        Public Property Bias_Power_Contact_On_Off() As WorkingStatuses
            Get
                Return m_Bias_Power_Contact_On_Off
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_Power_Contact_On_Off", VALUELib.ValueType.U1, value)
                CheckValueForLog("Bias_Power_Contact_On_Off", m_Bias_Power_Contact_On_Off, value, False)
            End Set
        End Property
        Public Property Bias_Plasma_Status() As WorkingStatuses
            Get
                Return m_Bias_Plasma_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_Plasma_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Bias_Plasma_Status", m_Bias_Plasma_Status, value, False)
            End Set
        End Property
        Public Property Bias_Power_Readback() As Double
            Get
                Return m_Bias_Power_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_Power_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_Power_Readback", m_Bias_Power_Readback, value, False)
            End Set
        End Property
        Public Property Bias_Power_Program() As Double
            Get
                Return m_Bias_Power_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_Power_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_Power_Program", m_Bias_Power_Program, value, False)
            End Set
        End Property
        Public Property Bias_Reflected_Power_Readback() As Double
            Get
                Return m_Bias_Reflected_Power_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_Reflected_Power_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_Reflected_Power_Readback", m_Bias_Reflected_Power_Readback, value, False)
            End Set
        End Property
        Public Property Bias_MB_Voltage_Program() As Double
            Get
                Return m_Bias_MB_Voltage_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Voltage_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_MB_Voltage_Program", m_Bias_MB_Voltage_Program, value, False)
            End Set
        End Property
        Public Property Bias_MB_Voltage_Readback() As Double
            Get
                Return m_Bias_MB_Voltage_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Voltage_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_MB_Voltage_Readback", m_Bias_MB_Voltage_Readback, value, False)
            End Set
        End Property
        Public Property Bias_MB_C1_Program() As Double
            Get
                Return m_Bias_MB_C1_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_C1_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_MB_C1_Program", m_Bias_MB_C1_Program, value, False)
            End Set
        End Property
        Public Property Bias_MB_C1_Readback() As Double
            Get
                Return m_Bias_MB_C1_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_C1_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_MB_C1_Readback", m_Bias_MB_C1_Readback, value, False)
            End Set
        End Property
        Public Property Bias_MB_C2_Program() As Double
            Get
                Return m_Bias_MB_C2_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_C2_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_MB_C2_Program", m_Bias_MB_C2_Program, value, False)
            End Set
        End Property
        Public Property Bias_MB_C2_Readback() As Double
            Get
                Return m_Bias_MB_C2_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_C2_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_MB_C2_Readback", m_Bias_MB_C2_Readback, value, False)
            End Set
        End Property
        Public Property Bias_MB_Match_Mode_Program() As WorkingStatuses
            Get
                Return m_Bias_MB_Match_Mode_Program
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Match_Mode_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_MB_Match_Mode_Program", m_Bias_MB_Match_Mode_Program, value, False)
            End Set
        End Property
        Public Property Bias_MB_Match_Mode_Readback() As WorkingStatuses
            Get
                Return m_Bias_MB_Match_Mode_Readback
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Match_Mode_Readback", VALUELib.ValueType.U1, value)
                CheckValueForLog("Bias_MB_Match_Mode_Readback", m_Bias_MB_Match_Mode_Readback, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_Preset_Program() As Integer
            Get
                Return m_RF_Target_MB_Preset_Program
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Preset_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_MB_Preset_Program", m_RF_Target_MB_Preset_Program, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_Preset_Readback() As Integer
            Get
                Return m_RF_Target_MB_Preset_Readback
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Preset_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("RF_Target_MB_Preset_Readback", m_RF_Target_MB_Preset_Readback, value, False)
            End Set
        End Property
        Public Property Bias_MB_Preset_Program() As Integer
            Get
                Return m_Bias_MB_Preset_Program
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Preset_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_MB_Preset_Program", m_Bias_MB_Preset_Program, value, False)
            End Set
        End Property
        Public Property Bias_MB_Preset_Readback() As Integer
            Get
                Return m_Bias_MB_Preset_Readback
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Preset_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_MB_Preset_Readback", m_Bias_MB_Preset_Readback, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_Preset_Store_Program() As WorkingStatuses
            Get
                Return m_RF_Target_MB_Preset_Store_Program
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Preset_Store_Program", VALUELib.ValueType.U1, value)
                CheckValueForLog("RF_Target_MB_Preset_Store_Program", m_RF_Target_MB_Preset_Store_Program, value, False)
            End Set
        End Property
        Public Property RF_Target_MB_Preset_Recall_Program() As WorkingStatuses
            Get
                Return m_RF_Target_MB_Preset_Recall_Program
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Preset_Recall_Program", VALUELib.ValueType.U1, value)
                CheckValueForLog("RF_Target_MB_Preset_Recall_Program", m_RF_Target_MB_Preset_Recall_Program, value, False)
            End Set
        End Property
        Public Overridable Property RF_Target_MB_Mag_Error_Readback() As String
            Get
                Return m_RF_Target_MB_Mag_Error_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Mag_Error_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("RF_Target_MB_Mag_Error_Readback", m_RF_Target_MB_Mag_Error_Readback, value, False)
            End Set
        End Property
        Public Overridable Property RF_Target_MB_Phase_Error_Readback() As String
            Get
                Return m_RF_Target_MB_Phase_Error_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Phase_Error_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("RF_Target_MB_Phase_Error_Readback", m_RF_Target_MB_Phase_Error_Readback, value, False)
            End Set
        End Property
        Public Property RF_Target_Error_Readback() As String
            Get
                Return m_RF_Target_Error_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_Error_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("RF_Target_Error_Readback", m_RF_Target_Error_Readback, value, False)
            End Set
        End Property
        Public Property Bias_MB_Preset_Store_Program() As WorkingStatuses
            Get
                Return m_Bias_MB_Preset_Store_Program
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Preset_Store_Program", VALUELib.ValueType.U1, value)
                CheckValueForLog("Bias_MB_Preset_Store_Program", m_Bias_MB_Preset_Store_Program, value, False)
            End Set
        End Property
        Public Property Bias_MB_Preset_Recall_Program() As WorkingStatuses
            Get
                Return m_Bias_MB_Preset_Recall_Program
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Preset_Recall_Program", VALUELib.ValueType.U1, value)
                CheckValueForLog("Bias_MB_Preset_Recall_Program", m_Bias_MB_Preset_Recall_Program, value, False)
            End Set
        End Property
        Public Overridable Property Bias_MB_Mag_Error_Readback() As String
            Get
                Return m_Bias_MB_Mag_Error_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Mag_Error_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("Bias_MB_Mag_Error_Readback", m_Bias_MB_Mag_Error_Readback, value, False)
            End Set
        End Property
        Public Overridable Property Bias_MB_Phase_Error_Readback() As String
            Get
                Return m_Bias_MB_Phase_Error_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Phase_Error_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("Bias_MB_Phase_Error_Readback", m_Bias_MB_Phase_Error_Readback, value, False)
            End Set
        End Property
        Public Property Bias_Error_Readback() As String
            Get
                Return m_Bias_Error_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_Error_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("Bias_Error_Readback", m_Bias_Error_Readback, value, False)
            End Set
        End Property

        Private m_Bias_Voltage_Min_Readback As Double = 0
        Public Property Bias_Voltage_Min_Readback() As Double
            Get
                Return m_Bias_Voltage_Min_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_Voltage_Min", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_Voltage_Min_Readback", m_Bias_Voltage_Min_Readback, value, False)
            End Set
        End Property
        Private m_Bias_Voltage_Max_Readback As Double = 0
        Public Property Bias_Voltage_Max_Readback() As Double
            Get
                Return m_Bias_Voltage_Max_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_Voltage_Max", VALUELib.ValueType.F4, value)
                CheckValueForLog("Bias_Voltage_Max_Readback", m_Bias_Voltage_Max_Readback, value, False)
            End Set
        End Property
        Public Property DC_Target_Communication_Status() As WorkingStatuses
            Get
                Return m_DC_Target_Communication_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Communication_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("DC_Target_Communication_Status", m_DC_Target_Communication_Status, value, False)
            End Set
        End Property
        Public Property DC_Target_Power_Readback() As Double
            Get
                Return m_DC_Target_Power_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Power_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("DC_Target_Power_Readback", m_DC_Target_Power_Readback, value, False)
            End Set
        End Property
        Public Property DC_Target_Power_Program() As Double
            Get
                Return m_DC_Target_Power_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Power_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("DC_Target_Power_Program", m_DC_Target_Power_Program, value, False)
            End Set
        End Property
        Public Property DC_Target_Voltage_Readback() As Double
            Get
                Return m_DC_Target_Voltage_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Voltage_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("DC_Target_Voltage_Readback", m_DC_Target_Voltage_Readback, value, False)
            End Set
        End Property
        Public Property DC_Target_Current_Readback() As Double
            Get
                Return m_DC_Target_Current_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Current_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("DC_Target_Current_Readback", m_DC_Target_Current_Readback, value, False)
            End Set
        End Property
        Public Property DC_Target_Pluse_Mode_Status() As WorkingStatuses
            Get
                Return m_DC_Target_Pluse_Mode_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Pluse_Mode_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("DC_Target_Pluse_Mode_Status", m_DC_Target_Pluse_Mode_Status, value, False)
            End Set
        End Property
        Public Property DC_Target_Pulse_Frequency_Program() As Double
            Get
                Return m_DC_Target_Pulse_Frequency_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Pulse_Frequency_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("DC_Target_Pulse_Frequency_Program", m_DC_Target_Pulse_Frequency_Program, value, False)
            End Set
        End Property
        Public Property DC_Target_Pulse_Frequency_Readback() As Double
            Get
                Return m_DC_Target_Pulse_Frequency_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Pulse_Frequency_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("DC_Target_Pulse_Frequency_Readback", m_DC_Target_Pulse_Frequency_Readback, value, False)
            End Set
        End Property
        Public Property DC_Target_Pulse_Width_Program() As Double
            Get
                Return m_DC_Target_Pulse_Width_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Pulse_Width_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("DC_Target_Pulse_Width_Program", m_DC_Target_Pulse_Width_Program, value, False)
            End Set
        End Property
        Public Property DC_Target_Pulse_Width_Readback() As Double
            Get
                Return m_DC_Target_Pulse_Width_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Pulse_Width_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("DC_Target_Pulse_Width_Readback", m_DC_Target_Pulse_Width_Readback, value, False)
            End Set
        End Property
        Public Property DC_Target_Ramp_Time_Program() As Double
            Get
                Return m_DC_Target_Ramp_Time_Program
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Ramp_Time_Program", VALUELib.ValueType.F4, value)
                CheckValueForLog("DC_Target_Ramp_Time_Program", m_DC_Target_Ramp_Time_Program, value, False)
            End Set
        End Property
        Public Property DC_Target_Ramp_Time_Readback() As Double
            Get
                Return m_DC_Target_Ramp_Time_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "DC_Target_Ramp_Time_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("DC_Target_Ramp_Time_Readback", m_DC_Target_Ramp_Time_Readback, value, False)
            End Set
        End Property
        Public Property DC_Target_Voltage_SP() As Double
            Get
                Return m_DC_Target_Voltage_SP
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("m_DC_Target_Voltage_SP", m_DC_Target_Voltage_SP, value, False)
            End Set
        End Property
        Public Property DC_Target_Arc_Counter_Readback() As Double
            Get
                Return m_DC_Target_Arc_Counter_Readback
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("DC_Target_Arc_Conuter_Readback", m_DC_Target_Arc_Counter_Readback, value, False)
            End Set
        End Property

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


        Private m_ATMMechanicalPumpCGStatus As WorkingStatuses
        Public Property ATMMechanicalPumpCGStatus() As WorkingStatuses
            Get
                Return m_ATMMechanicalPumpCGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("ATMMechanicalPumpCGStatus", m_ATMMechanicalPumpCGStatus, value, False)
            End Set
        End Property

        ''' <author>
        '''    	<name> Dy Do </name>
        '''    	<date> 2015-06-03 </date>
        ''' </author>
        ''' <summary>
        ''' Set InjectionValve Open/Close
        ''' </summary>
        ''' <remarks></remarks>
        Private m_Target1_Injection_ValveStatus As WorkingStatuses
        Public Property Target1_Injection_ValveStatus() As WorkingStatuses
            Get
                Return m_Target1_Injection_ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Target1_Injection_ValveStatus", m_Target1_Injection_ValveStatus, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target1_Injection_ValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Private m_Target2_Injection_ValveStatus As WorkingStatuses
        Public Property Target2_Injection_ValveStatus() As WorkingStatuses
            Get
                Return m_Target2_Injection_ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Target2_Injection_ValveStatus", m_Target2_Injection_ValveStatus, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target2_Injection_ValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Private m_Target3_Injection_ValveStatus As WorkingStatuses
        Public Property Target3_Injection_ValveStatus() As WorkingStatuses
            Get
                Return m_Target3_Injection_ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Target3_Injection_ValveStatus", m_Target3_Injection_ValveStatus, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target3_Injection_ValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Private m_Target4_Injection_ValveStatus As WorkingStatuses
        Public Property Target4_Injection_ValveStatus() As WorkingStatuses
            Get
                Return m_Target4_Injection_ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Target4_Injection_ValveStatus", m_Target4_Injection_ValveStatus, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target4_Injection_ValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Private m_HeaterZone1_Communication_Status As WorkingStatuses
        Public Property HeaterZone1_Communication_Status() As WorkingStatuses
            Get
                Return m_HeaterZone1_Communication_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("HeaterZone1_Communication_Status", m_HeaterZone1_Communication_Status, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "HeaterZone1_Communication_Status", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Private m_HeaterZone2_Communication_Status As WorkingStatuses
        Public Property HeaterZone2_Communication_Status() As WorkingStatuses
            Get
                Return m_HeaterZone2_Communication_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("HeaterZone2_Communication_Status", m_HeaterZone2_Communication_Status, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "HeaterZone2_Communication_Status", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Private m_Heater_Zone1_RB As Double
        Public Property Heater_Zone1_RB() As Double
            Get
                Return m_Heater_Zone1_RB
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Heater_Zone1_RB", m_Heater_Zone1_RB, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Heater_Zone1_RB", VALUELib.ValueType.F4, value)
            End Set
        End Property

        Private m_Heater_Zone2_RB As Double
        Public Property Heater_Zone2_RB() As Double
            Get
                Return m_Heater_Zone2_RB
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Heater_Zone2_RB", m_Heater_Zone2_RB, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Heater_Zone2_RB", VALUELib.ValueType.F4, value)
            End Set
        End Property

        Private m_Heater_Zone1_SP As Double
        Public Property Heater_Zone1_SP() As Double
            Get
                Return m_Heater_Zone1_SP
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Heater_Zone1_SP", m_Heater_Zone1_SP, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Heater_Zone1_SP", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        Private m_Heater_Zone2_SP As Double
        Public Property Heater_Zone2_SP() As Double
            Get
                Return m_Heater_Zone2_SP
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Heater_Zone2_SP", m_Heater_Zone2_SP, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Heater_Zone2_SP", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property

        Private m_Heater1_OnOff_SP As WorkingStatuses
        Public Property Heater1_OnOff_SP() As WorkingStatuses
            Get
                Return m_Heater1_OnOff_SP
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Heater1_OnOff_SP", m_Heater1_OnOff_SP, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Heater1_OnOff_SP", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Private m_Heater2_OnOff_SP As WorkingStatuses
        Public Property Heater2_OnOff_SP() As WorkingStatuses
            Get
                Return m_Heater2_OnOff_SP
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Heater2_OnOff_SP", m_Heater2_OnOff_SP, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Heater2_OnOff_SP", VALUELib.ValueType.U2, value)
            End Set
        End Property

        Private m_Heater1_OnOff_RB As WorkingStatuses
        Public Property Heater1_OnOff_RB() As WorkingStatuses
            Get
                Return m_Heater1_OnOff_RB
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Heater1_OnOff_RB", m_Heater1_OnOff_RB, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Heater1_OnOff_RB", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Private m_Heater2_OnOff_RB As WorkingStatuses
        Public Property Heater2_OnOff_RB() As WorkingStatuses
            Get
                Return m_Heater2_OnOff_RB
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Heater2_OnOff_RB", m_Heater2_OnOff_RB, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Heater2_OnOff_RB", VALUELib.ValueType.U2, value)
            End Set
        End Property

        Private m_Heater1_Alarm As String
        Public Property Heater1_Alarm() As String
            Get
                Return m_Heater1_Alarm
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Heater1_Alarm", m_Heater1_Alarm, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Heater1_Alarm", VALUELib.ValueType.A, value)
            End Set
        End Property

        Private m_Heater2_Alarm As String
        Public Property Heater2_Alarm() As String
            Get
                Return m_Heater2_Alarm
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Heater2_Alarm", m_Heater2_Alarm, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Heater2_Alarm", VALUELib.ValueType.A, value)
            End Set
        End Property

        Private m_Goodness_Of_Fit As Double
        Public Property Goodness_Of_Fit() As Double
            Get
                Return m_Goodness_Of_Fit
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("Goodness_Of_Fit", m_Goodness_Of_Fit, value, False)
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-08-12 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set IGIsolation Valve Visible
        ''' </summary>
        ''' <remarks></remarks>
        Private m_IG_Isolation_ValveStatus As WorkingStatuses
        Public Property IG_Isolation_ValveStatus() As WorkingStatuses
            Get
                Return m_IG_Isolation_ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("IG_Isolation_ValveStatus", m_IG_Isolation_ValveStatus, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "IG_Isolation_ValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <summary>
        ''' Target Mode
        ''' - 01: RF
        ''' - 02: DC
        ''' </summary>
        ''' <returns></returns>
        Public Property Target_Mode As String
            Get
                Return m_Target_Mode
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Target_Mode", m_Target_Mode, value, False)
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
        ''' Last Execution
        ''' </summary>
        ''' <remarks></remarks>
        Protected m_LastExecution As Date = Date.Now
        Public Property LastExecution() As Date
            Get
                Return m_LastExecution
            End Get
            Set(ByVal value As Date)
                m_LastExecution = value
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
                    Utils.SetPM_IncreaseWaferCount(Me.Name, Me.NumberOfWafer)
                    If m_blnStateMachineCompleted = False Then
                        m_blnStateMachineCompleted = True
                        If (Not IsAlarmReceivedDuringRunProcess) AndAlso (WaferStatus = enumWaferStatus.eWaferComplete) Then
                            ' Wafer processing is completed successfully, capture the last execution time.
                            LastExecution = Date.Now
                        End If
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
                '''Call finish Data Logging for WaferRun
                Utils.FinishDataLogging(Me.Name)
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
            Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.Name)
            If objChamber IsNot Nothing Then
                objChamber.Alarm_KWH = objChamber.Alarm_KWH
                objChamber.Alarm_KWH1 = objChamber.Alarm_KWH1
                objChamber.Alarm_KWH2 = objChamber.Alarm_KWH2
                objChamber.Alarm_KWH3 = objChamber.Alarm_KWH3
                objChamber.Alarm_KWH4 = objChamber.Alarm_KWH4
                objChamber.Warning_KWH = objChamber.Warning_KWH
                objChamber.Warning_KWH1 = objChamber.Warning_KWH1
                objChamber.Warning_KWH2 = objChamber.Warning_KWH2
                objChamber.Warning_KWH3 = objChamber.Warning_KWH3
                objChamber.Warning_KWH4 = objChamber.Warning_KWH4
                objChamber.Target_Material = objChamber.Target_Material
                objChamber.Target_Material1 = objChamber.Target_Material1
                objChamber.Target_Material2 = objChamber.Target_Material2
                objChamber.Target_Material3 = objChamber.Target_Material3
                objChamber.Target_Material4 = objChamber.Target_Material4
                objChamber.ShieldsQuartzLimit = objChamber.ShieldsQuartzLimit
                objChamber.ShieldsQuartzLimit1 = objChamber.ShieldsQuartzLimit1
                objChamber.ShieldsQuartzLimit2 = objChamber.ShieldsQuartzLimit2
                objChamber.ShieldsQuartzLimit3 = objChamber.ShieldsQuartzLimit3
                objChamber.ShieldsQuartzLimit4 = objChamber.ShieldsQuartzLimit4
                objChamber.ShieldsQuartzWarning = objChamber.ShieldsQuartzWarning
                objChamber.ShieldsQuartzWarning1 = objChamber.ShieldsQuartzWarning1
                objChamber.ShieldsQuartzWarning2 = objChamber.ShieldsQuartzWarning2
                objChamber.ShieldsQuartzWarning3 = objChamber.ShieldsQuartzWarning3
                objChamber.ShieldsQuartzWarning4 = objChamber.ShieldsQuartzWarning4
            End If
            Water_Pump_Regen_Lifetime_Readback = Water_Pump_Regen_Lifetime_Readback
            AVPLib.Log.avpLogger.Error("Need add more Gem Variable when system initialize")
        End Sub

        Protected Sub CheckingKWH(ByVal KWH_Readback As Double, ByVal index As Integer)
            Try

                If m_RunProcessStatus = ConstEnum.enumProcessStatus.eStart Then
                    Dim newWarning_KWH As Double
                    Dim newAlarm_KWH As Double

                    Dim lstTarget As List(Of String) = Nothing
                    Dim objChamberController As AVPLib.Business.ChamberController = AVPLib.Business.ControllerManager.GetController(Me.Name)

                    If objChamberController IsNot Nothing Then
                        lstTarget = objChamberController.GetAllTargetBaseOnRecipe(Me.Process_Recipe_Name, Me.Name)
                    End If
                    If (lstTarget Is Nothing) OrElse (lstTarget IsNot Nothing AndAlso (Not lstTarget.Contains(index.ToString()))) Then
                        Return
                    End If

                    Select Case index
                        Case 1
                            If IsUseMaxLimit Then
                                newWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH - m_objChamberModule.Max_KWH_Source)
                                newAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH - m_objChamberModule.Max_KWH_Source)
                            Else
                                newWarning_KWH = m_objChamberModule.Warning_KWH
                                newAlarm_KWH = m_objChamberModule.Alarm_KWH
                            End If
                        Case 2
                            If IsUseMaxLimit Then
                                newWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH1 - m_objChamberModule.Max_KWH_Source)
                                newAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH1 - m_objChamberModule.Max_KWH_Source)
                            Else
                                newWarning_KWH = m_objChamberModule.Warning_KWH1
                                newAlarm_KWH = m_objChamberModule.Alarm_KWH1
                            End If
                        Case 3
                            If IsUseMaxLimit Then
                                newWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH2 - m_objChamberModule.Max_KWH_Source)
                                newAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH2 - m_objChamberModule.Max_KWH_Source)
                            Else
                                newWarning_KWH = m_objChamberModule.Warning_KWH2
                                newAlarm_KWH = m_objChamberModule.Alarm_KWH2
                            End If
                        Case 4
                            If IsUseMaxLimit Then
                                newWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH3 - m_objChamberModule.Max_KWH_Source)
                                newAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH3 - m_objChamberModule.Max_KWH_Source)
                            Else
                                newWarning_KWH = m_objChamberModule.Warning_KWH3
                                newAlarm_KWH = m_objChamberModule.Alarm_KWH3
                            End If
                        Case 5
                            If IsUseMaxLimit Then
                                newWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH4 - m_objChamberModule.Max_KWH_Source)
                                newAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH4 - m_objChamberModule.Max_KWH_Source)
                            Else
                                newWarning_KWH = m_objChamberModule.Warning_KWH4
                                newAlarm_KWH = m_objChamberModule.Alarm_KWH4
                            End If
                    End Select

                    If (KWH_Readback < newAlarm_KWH) Then
                        m_blnShowLimitKWH = False
                    End If
                    If (KWH_Readback < newWarning_KWH) Then
                        m_blnShowWarningKWH = False
                    End If
                    ''if KWH > Limit -> show alarm
                    If (KWH_Readback >= newAlarm_KWH) And m_blnShowLimitKWH = False Then
                        Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.Name) + ": " &
                                                           String.Format("Target KWH Usage" & index.ToString() & " Is Over The Limit ({0})",
                                                                       newAlarm_KWH))
                        m_blnShowLimitKWH = True
                        ''if KWH > Warning and not show Limit Alarm before -> show
                    ElseIf (KWH_Readback >= newWarning_KWH) And m_blnShowWarningKWH = False And m_blnShowLimitKWH = False Then
                        Me.ThrowAlarm(Utils.chamberID2ChamberName(Me.Name) + ": " &
                               String.Format("Target KWH Usage" & index.ToString() & " Is Over The Warning ({0})",
                                             newWarning_KWH))
                        m_blnShowWarningKWH = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Public Overridable Function CheckingKWHOverWarningLimit(ByVal sTargetUsed As List(Of String)) As Boolean
            Dim checkTx As Boolean = False
            Try
                ' Init chamber module
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If

                ' Init variable
                Dim newTxWarning_KWH As Double
                Dim mTargetKwhUsage As Double

                ' Check KWH of each target 
                For Each sTarget As String In sTargetUsed
                    Select Case sTarget
                        Case "T1"
                            If IsUseMaxLimit Then
                                newTxWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH - m_objChamberModule.Max_KWH_Source)
                            Else
                                newTxWarning_KWH = m_objChamberModule.Warning_KWH
                            End If
                            mTargetKwhUsage = m_Target1_Kwh_Usage
                        Case "T2"
                            If IsUseMaxLimit Then
                                newTxWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH1 - m_objChamberModule.Max_KWH_Source1)
                            Else
                                newTxWarning_KWH = m_objChamberModule.Warning_KWH1
                            End If
                            mTargetKwhUsage = m_Target2_Kwh_Usage
                        Case "T3"
                            If IsUseMaxLimit Then
                                newTxWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH2 - m_objChamberModule.Max_KWH_Source2)
                            Else
                                newTxWarning_KWH = m_objChamberModule.Warning_KWH2
                            End If
                            mTargetKwhUsage = m_Target3_Kwh_Usage
                        Case "T4"
                            If IsUseMaxLimit Then
                                newTxWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH3 - m_objChamberModule.Max_KWH_Source3)
                            Else
                                newTxWarning_KWH = m_objChamberModule.Warning_KWH3
                            End If
                            mTargetKwhUsage = m_Target4_Kwh_Usage
                    End Select

                    ' Check kwh
                    If mTargetKwhUsage > newTxWarning_KWH Then
                        checkTx = True
                        Exit For
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return checkTx
        End Function

        ''<name> Vy Nguyen </name>
        ''<date> 2014-04-14</date>
        ''</author>
        '' Re-write function
        ''<summary>
        ''' 0004787: [KhoiHa 03/22/2014]If user run a scheduler with recipe only using T2/T3/T4. 
        ''' With picture below, user should be allow to run since this schedule is not using T1.
        ''</summary>
        Public Overridable Function CheckingKWHOverAlarmLimit(ByVal sTargetUsed As List(Of String)) As Boolean
            Dim checkTx As Boolean = False
            Try
                ' Init chamber module
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If

                ' Init variable
                Dim newTxAlarm_KWH As Double
                Dim mTargetKwhUsage As Double

                ' Check KWH of each target 
                For Each sTarget As String In sTargetUsed
                    Select Case sTarget
                        Case "T1"
                            If IsUseMaxLimit Then
                                newTxAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH - m_objChamberModule.Max_KWH_Source)
                            Else
                                newTxAlarm_KWH = m_objChamberModule.Alarm_KWH
                            End If
                            mTargetKwhUsage = m_Target1_Kwh_Usage
                        Case "T2"
                            If IsUseMaxLimit Then
                                newTxAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH1 - m_objChamberModule.Max_KWH_Source1)
                            Else
                                newTxAlarm_KWH = m_objChamberModule.Alarm_KWH1
                            End If
                            mTargetKwhUsage = m_Target2_Kwh_Usage
                        Case "T3"
                            If IsUseMaxLimit Then
                                newTxAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH2 - m_objChamberModule.Max_KWH_Source2)
                            Else
                                newTxAlarm_KWH = m_objChamberModule.Alarm_KWH2
                            End If
                            mTargetKwhUsage = m_Target3_Kwh_Usage
                        Case "T4"
                            If IsUseMaxLimit Then
                                newTxAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH3 - m_objChamberModule.Max_KWH_Source3)
                            Else
                                newTxAlarm_KWH = m_objChamberModule.Alarm_KWH3
                            End If
                            mTargetKwhUsage = m_Target4_Kwh_Usage
                    End Select

                    ' Check kwh
                    If mTargetKwhUsage > newTxAlarm_KWH Then
                        checkTx = True
                        Exit For
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return checkTx
        End Function
#Region "Public Function"
        ''' <author>
        '''    	<name> TODO ADD NAME </name>
        '''    	<date> TODO ADD DATE </date>
        ''' </author>
        ''' <summary>
        ''' update wafer status to GUI
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub UpdateWaferStatus()
            Dim waferInfoRS As AVPWaferInfo = Nothing
            Try
                If (m_lstWaferInfo IsNot Nothing) Then
                    For Each Item As AVPWaferInfo In m_lstWaferInfo
                        'TODO: raise wafer info to GUI
                    Next
                Else
                    AVPLib.Log.avpLogger.Error("Missing initialize max wafer slot for " & Me.Name)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
#End Region
#Region "Throw Alarm"
        Protected Sub ThrowAlarm(ByVal strMessage As String)
            Dim strGemAlarmName = Utils.GemGetAlarmName(Me.Name)
            Utils.ThrowAlarm(strMessage, strGemAlarmName)
        End Sub
#End Region
        Public SubStrateGotoSlotWaitTimeInMiliseconds As Integer = 180000
        Public SubStrateGoUpDownWaitTimeInMiliseconds As Integer = 30000
        Public TableLiftHomeWaitTimeInMiliseconds As Integer = 120000
        Public MotionInitializedWaitTimeInMiliseconds As Integer = 150000
        Public ProcessRecipeStartedWaitTimeInMiliseconds As Integer = 1800000 '30min

        Public Function IsSubStrateTableStopMoving() As Boolean
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateTableStopMoving")
            Dim blResult As Boolean = False
            Try
                blResult = (Substrate_Table_Rotate_Status = WorkingStatuses.Off)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateTableStopMoving")
        End Function

        Public Function IsSubStrateTableMoving() As Boolean
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateTableMoving")
            Dim blResult As Boolean = False
            Try
                blResult = (Substrate_Table_Rotate_Status <> WorkingStatuses.Off)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateTableMoving")
        End Function

        Public Function IsSubStrateTableAtPosition(ByVal sSlotID As String) As Boolean
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateTableAtPosition")
            Dim blResult As Boolean = False
            Try
                Dim iSlotID As Integer = 0
                Integer.TryParse(sSlotID, iSlotID)
                blResult = (Substrate_Current_Station = iSlotID)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateTableAtPosition")
        End Function
        Public Function IsSubStrateTableAtPositionAndStopMoving(ByVal sSlotID As String) As Boolean
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateTableAtPosition")
            Dim blResult As Boolean = False
            Try
                blResult = IsSubStrateTableAtPosition(sSlotID) And IsSubStrateTableStopMoving()
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateTableAtPosition")
        End Function
        Public Function IsSubStrateLiftAtUpPosition() As Boolean
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateLiftAtUpPosition")
            Dim blResult As Boolean = False
            Try
                blResult = (SetSubStrateLiftUpDownStatus(WorkingStatuses.On))
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateLiftAtUpPosition")
        End Function
        Public Function IsTableLiftHome() As Boolean
            AVPLib.Log.coreLogger.Info("Leave IsTableLiftHome")
            Dim blResult As Boolean = False
            Try
                blResult = (Substrate_Table_Lift_Home = WorkingStatuses.On)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
            AVPLib.Log.coreLogger.Info("Leave IsTableLiftHome")
        End Function
        Public Function IsMotionStop() As Boolean
            AVPLib.Log.coreLogger.Info("Leave IsMotionStop")
            Dim blResult As Boolean = False
            Try
                blResult = (Initialized_Motion <> WorkingStatuses.Unknown)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
            AVPLib.Log.coreLogger.Info("Leave IsMotionStop")
        End Function
        Public Function IsSubStrateLiftAtDownPosition() As Boolean
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateLiftAtDownPosition")
            Dim blResult As Boolean = False
            Try
                blResult = (SetSubStrateLiftUpDownStatus(WorkingStatuses.Off))
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateLiftAtDownPosition")
        End Function
        Public Function IsProcessRecipeStarted() As Boolean
            AVPLib.Log.coreLogger.Info("Leave IsProcessRecipeStarted")
            Dim blResult As Boolean = False
            Try
                blResult = ((RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Starting) _
                            Or (RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Running) _
                            Or (RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Aborting) _
                            Or (RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Resuming))
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
            AVPLib.Log.coreLogger.Info("Leave IsProcessRecipeStarted")
        End Function

        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2017-04-05</date>
        ''' </author>
        ''' <summary>
        ''' Set SubstrateLift up or down status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetSubStrateLiftUpDownStatus(ByVal args As WorkingStatuses) As Boolean
            AVPLib.Log.coreLogger.Info("Leave SetSubStrateLiftUpDownStatus")
            Dim blResult As Boolean = False
            Try
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If

                If (m_objChamberModule IsNot Nothing) AndAlso m_objChamberModule.WaferLiftInstalled = False Then
                    Return True
                Else
                    Return IIf(Substrate_Lift_Up_Down_Status = args, True, False)
                End If

            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
            AVPLib.Log.coreLogger.Info("Leave IsSubStrateLiftAtDownPosition")
        End Function
        ''' <author>
        '''    	<name>Tinh Le</name>
        '''    	<date> 2023-12-10</date>
        ''' </author>
        ''' <summary>
        ''' Set SubstrateLift up or down status
        ''' </summary>
        Private Function ChangeTypeUpdateGEM(ByVal strValue As String) As Int32
            Dim blResult As Int32 = 4
            Select Case strValue
                Case ConstEnum.PROCESS_MODE_TIME
                    blResult = 0
                Case ConstEnum.PROCESS_MODE_REVOLUTION
                    blResult = 1
                Case ConstEnum.PROCESS_MODE_STATIC
                    blResult = 2
                Case ConstEnum.PROCESS_MODE_THICHNESS
                    blResult = 3
            End Select
            Return blResult
        End Function

        Public Sub New(ByVal strName As String, ByVal NumberOfSlot As Integer)
            Me.Name = strName
            ReDim Preserve m_lstWaferInfo(NumberOfSlot - 1)
        End Sub

        ''' <author>
        '''    	<name>Kiet Tran</name>
        '''    	<date> 2026-05-05</date>
        ''' </author>
        ''' <summary>
        ''' Set SubstrateLift up or down status
        ''' </summary>
        Private Shared Sub UpdateRoughPumpToTM(ByVal equipment As Equipments, ByVal prop As String, ByVal value As Object)
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrPropertyValues As New ArrayList()

                arrPropertyNames.Add(prop)
                arrPropertyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(equipment.ToString(), arrPropertyNames, arrPropertyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
    End Class
End Namespace

