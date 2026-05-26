Imports AVPLib.Communication.TerminalDriver
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum
Imports AVPSecsGemLib
Namespace Business
    Public Enum CORONACommands
        REQUEST_ALL_DATA
        ' SYSTEM # 1
        KEEP_ALIVE
        OVERRIDE_MODE
        ALARM_STATUS_READBACK
        EVENT_STATUS_READBACK
        MAINTENAINCE_MODE
        TARGET1_KWH_USAGE
        TARGET1_SET_KWH_USAGE
        TARGET2_KWH_USAGE
        TARGET2_SET_KWH_USAGE
        TARGET3_KWH_USAGE
        TARGET3_SET_KWH_USAGE
        TARGET4_KWH_USAGE
        TARGET4_SET_KWH_USAGE
        TARGET_SELECT_PROGRAM
        TARGET_SELECT_READBACK
        PLASMA_STATUS
        TARGET1_SHIELD_QUART
        TARGET1_SET_SHIELD_QUART
        TARGET2_SHIELD_QUART
        TARGET2_SET_SHIELD_QUART
        TARGET3_SHIELD_QUART
        TARGET3_SET_SHIELD_QUART
        TARGET4_SHIELD_QUART
        TARGET4_SET_SHIELD_QUART
        ' RECIPE_PROCESSING #2
        PROCESS_LOT_ID
        PROCESS_WAFER_ID
        PROCESS_RECIPE_NAME
        PROCESS_CONTROL_DEVICE
        'PROCESS_CONTROL_DEVICE_START
        'PROCESS_CONTROL_DEVICE_STOP
        'PROCESS_CONTROL_DEVICE_PAUSE
        'PROCESS_CONTROL_DEVICE_CONTINUE
        'PROCESS_CONTROL_DEVICE_END_STEP
        'PROCESS_CONTROL_DEVICE_ERROR
        'PROCESS_CONTROL_DEVICE_RESET_ERROR
        PROCESS_CONTROL_SEND_RUN_DATA_FILE_NAME
        PROCESS_CONTROL_GET_RUN_DATA_FILE_NAME
        COPYRECIPE_TO_PMFOLDER
        CHECK_RECIPE_TEMPLATE_VERSION
        SYN_COPY_RECIPE_TEMPLATE
        PROCESS_REMAINING_TIME
        PROCESS_ELAPSED_TIME
        PROCESS_CURRENT_STEP
        PROCESS_TOTAL_STEPS
        PROCESS_TOTAL_TIME
        WAFER_PROCESSING_STATUS_READBACK
        WAFER_DELETE
        WAFER_SLOT
        PROCESS_PRESSURE
        PROCESS_MODE
        PROCESS_REVOLUTION_COUNT
        CURRENT_AVP_TIME
        ' SEQUENCES # 3
        AUTO_PUMPDOWN_SEQ
        AUTO_VENT_SEQ
        PUMP_PURGE_SEQ
        MACHINE_PUMPPURGE_CURRENT_CYCLE
        IG_DEGAS_SEQ
        SHUTDOWN_POWER_SEQ

        RATE_OF_RISE_SEQ
        RATE_OF_RISE_INTERVAL_RECORDING
        RATE_OF_RISE_SAMPLE
        RATE_OF_RISE_FILENAME

        PUMPDOWN_CURVE_SEQ
        PUMPDOWN_CURVE_INTERVAL_RECORDING
        PUMPDOWN_CURVE_SAMPLE
        PUMPDOWN_CURVE_FILENAME

        INITIALIZE_MOTION ' SLOT NUMBER
        INITIALIZED_MOTION
        AUTO_POWER_SEQ

        ' GASSES # 4
        GAS1_SHUTOFF_VALVE
        GAS2_SHUTOFF_VALVE
        GAS3_SHUTOFF_VALVE
        GAS4_SHUTOFF_VALVE
        GAS5_SHUTOFF_VALVE

        GAS1_FLOWRATE_PROGRAM
        GAS2_FLOWRATE_PROGRAM
        GAS3_FLOWRATE_PROGRAM
        GAS4_FLOWRATE_PROGRAM
        GAS5_FLOWRATE_PROGRAM

        GAS1_FLOWRATE_READBACK
        GAS2_FLOWRATE_READBACK
        GAS3_FLOWRATE_READBACK
        GAS4_FLOWRATE_READBACK
        GAS5_FLOWRATE_READBACK

        GAS1_MFC_DEVICENET_STATUS_READBACK
        GAS2_MFC_DEVICENET_STATUS_READBACK
        GAS3_MFC_DEVICENET_STATUS_READBACK
        GAS4_MFC_DEVICENET_STATUS_READBACK
        GAS5_MFC_DEVICENET_STATUS_READBACK

        MAIN_DIST_VALVE
        SEC_DIST_VALVE

        ' VALVES  # 5			
        ROUGH_VALVE_STATUS
        VENT_VALVE_STATUS
        ISOLATION_VALVE_STATUS
        HIVAC_VALVE_STATUS
        FORELINE_VALVE_STATUS
        BARATRON_VALVE_STATUS

        ' PRESSURE # 6
        IG_PRESSURE
        IG_STATUS
        CG_PRESSURE
        CG_RELAY_STATUS
        CHAMBER_CG_ATM
        ENABLE_SET_CHAMBER_CG_ATM
        CHAMBER_CG_VAC
        ENABLE_SET_CHAMBER_CG_VAC
        SWITCH_IG_FILAMENT_PROGRAM
        SWITCH_IG_FILAMENT_READBACK
        ENABLE_IG_FILAMENT_READBACK


        FORELINE_CG_PRESSURE
        FORELINE_CG_RELAY_STATUS
        FORELINE_CG_ATM
        ENABLE_SET_FORELINE_CG_ATM


        BARATRON_PRESSURE

        MECHANICAL_PUMP_CG_PRESSURE
        MECHANICAL_PUMP_CG_RELAY_STATUS
        MECHANICAL_PUMP_STATUS
        MECHANICAL_PUMP_CG_ATM
        ENABLE_SET_MECHANICAL_PUMP_CG_ATM
        MECHANICAL_PUMP_COM_SERIAL
        MECHANICAL_PUMP_WAITTING_ON


        ' INTERLOCKS # 7
        CHAMBERINTERLOCK_SUBSTRATE_TABLE_WATER_STATUS
        CHAMBERINTERLOCK_AIR_PRESSURE_STATUS

        CHAMBERINTERLOCK_DOOR_CLOSED_STATUS
        CHAMBERINTERLOCK_LID_CLOSED_STATUS

        CHAMBERINTERLOCK_TARGET1_3_WATER_STATUS
        CHAMBERINTERLOCK_TARGET2_4_WATER_STATUS

        CHAMBERINTERLOCK_TARGET_MB_WATER_STATUS
        CHAMBERINTERLOCK_BIAS_MB_WATER_STATUS
        CHAMBERINTERLOCK_TURBO_WATER_STATUS
        CHAMBERINTERLOCK_PS_INTERLOCK_STATUS
        CHAMBERINTERLOCK_DEVICENET_COMM
        CHAMBERINTERLOCK_TARGET_PANELS

        ' MOTION # 8
        SUBSTRATE_GOTO_SLOT
        SUBSTRATE_CURRENT_STATION
        ROUND_SUBSTRATE_CURRENT_STATION
        SUBSTRATE_TABLE_ROTATE_HOME
        SUBSTRATE_TABLE_LIFT_HOME
        SUBSTRATE_TABLE_UP_DOWN_STATUS
        SUBSTRATE_LIFT_UP_DOWN_STATUS
        SUBSTRATE_TABLE_ROTATE_STATUS
        SUBSTRATE_TABLE_ROTATE_SPEED
        SUBSTRATE_TABLE_ROTATE_SPEED_READBACK
        SUBSTRATE_TABLE_ROTATE_POS_IN_UNIT_READBACK
        NUMBER_OF_UNIT_PER_REVOLUTION_READBACK
        SUBSTRATE_TABLE_CURRENT_POSITION_READBACK
        SUBSTRATE_TABLE_CURRENT_POSITION_PROGRAM
        IS_MOTIONINITIALIZED
        SUBSTRATE_TABLE_ROTATE_SEQUENCE_STATE
        TARGET1_SHUTTER_STATUS
        TARGET2_SHUTTER_STATUS
        TARGET3_SHUTTER_STATUS
        TARGET4_SHUTTER_STATUS
        SUBSTRATE_TABLE_UP_DOWN_MOVING
        MOTION_COMMUNICATION_STATUS

        ' TURBO_WATERPUMP # 9
        WATER_PUMP_T_READBACK
        WATER_PUMP_STATUS
        WATER_PUMP_REGEN_STATUS
        WATER_PUMP_STATE_STATUS
        WATER_PUMP_REGEN_HOUR_READBACK
        WATER_PUMP_REGEN_LIFETIME_READBACK
        WATER_PUMP_P_COMMANDS
        WATER_PUMP_P_COMMAND_READBACK
        WATER_PUMP_IS_COMMUNICATING
        TURBO_PUMP_ON_OFF
        TURBO_PUMP_ON_OFF_RB
        TURBO_PUMP_UPTOSPEED_RB
        TURBO_PUMP_RAMPING_PERCENT_RB

        ' VAT_VALVE #10
        VAT_VALVE_COMMUNICATION_STATUS
        VAT_VALVE_CONTROLLER_PRESSURE_PROGRAM
        VAT_VALVE_CONTROLLER_PRESSURE_READBACK
        VAT_VALVE_PERCENTAGE_PROGRAM
        VAT_VALVE_PERCENTAGE_READBACK
        VAT_VALVE_CONTROLLER_AUTO_ZERO
        VAT_VALVE_CONTROLLER_TEACH
        VAT_VALVE_CONTROLLER_SIZEADJUST

        ' MAGNATRON # 11
        TARGET1_MAGNATRON_ON_OFF
        TARGET1_MAGNATRON_ROTATE_STATUS
        TARGET2_MAGNATRON_ON_OFF
        TARGET2_MAGNATRON_ROTATE_STATUS
        TARGET3_MAGNATRON_ON_OFF
        TARGET3_MAGNATRON_ROTATE_STATUS
        TARGET4_MAGNATRON_ON_OFF
        TARGET4_MAGNATRON_ROTATE_STATUS

        ' RF_TARGET_PS # 12
        RF_TARGET_COMMUNICATION_STATUS
        RF_TARGET_POWER_READBACK
        RF_TARGET_POWER_PROGRAM
        RF_TARGET_REFLECTED_POWER_READBACK
        RF_TARGET_MB_VOLTAGE_READBACK
        RF_TARGET_MB_C1_PROGRAM
        RF_TARGET_MB_C1_READBACK
        RF_TARGET_MB_C2_PROGRAM
        RF_TARGET_MB_C2_READBACK
        RF_TARGET_MB_MATCH_MODE_PROGRAM
        RF_TARGET_MB_MATCH_MODE_READBACK
        RF_TARGET_MB_PRESET_PROGRAM
        RF_TARGET_MB_PRESET_READBACK
        RF_TARGET_MB_PRESET_STORE_PROGRAM
        RF_TARGET_MB_PRESET_RECALL_PROGRAM
        RF_TARGET_MB_MAG_ERROR_READBACK
        RF_TARGET_MB_PHASE_ERROR_READBACK
        RF_TARGET_ERROR_READBACK
        RF_TARGET_VOLTAGE_SP
        RF_TARGET_VOLTAGE_MIN
        RF_TARGET_VOLTAGE_MAX

        ' BIAS_PS # 13
        BIAS_COMMUNICATION_STATUS
        BIAS_POWER_READBACK
        BIAS_POWER_PROGRAM
        BIAS_REFLECTED_POWER_READBACK
        BIAS_MB_VOLTAGE_READBACK
        BIAS_MB_VOLTAGE_PROGRAM
        BIAS_MB_C1_PROGRAM
        BIAS_MB_C1_READBACK
        BIAS_MB_C2_PROGRAM
        BIAS_MB_C2_READBACK
        BIAS_MB_MATCH_MODE_PROGRAM
        BIAS_MB_MATCH_MODE_READBACK
        BIAS_MB_PRESET_PROGRAM
        BIAS_MB_PRESET_READBACK
        BIAS_MB_PRESET_STORE_PROGRAM
        BIAS_MB_PRESET_RECALL_PROGRAM
        BIAS_MB_MAG_ERROR_READBACK
        BIAS_MB_PHASE_ERROR_READBACK
        BIAS_ERROR_READBACK
        BIAS_POWER_CONTACT_ON_OFF_STATUS
        BIAS_PLASMA_STATUS
        BIAS_VOLTAGE_MIN
        BIAS_VOLTAGE_MAX

        ' DC_TARGET_PS # 14
        DC_TARGET_COMMUNICATION_STATUS
        DC_TARGET_POWER_READBACK
        DC_TARGET_POWER_PROGRAM
        DC_TARGET_VOLTAGE_READBACK
        DC_TARGET_CURRENT_READBACK

        DC_TARGET_PULSE_MODE_STATUS
        DC_TARGET_PULSE_FREQUENCY_PROGRAM
        DC_TARGET_PULSE_FREQUENCY_READBACK
        DC_TARGET_PULSE_WIDTH_PROGRAM
        DC_TARGET_PULSE_WIDTH_READBACK
        DC_TARGET_RAMP_TIME_PROGRAM
        DC_TARGET_RAMP_TIME_READBACK
        DC_TARGET_ARC_COUNTER_READBACK
        DC_TARGET_VOLTAGE_SP

        ' HEATER ZONE # 15
        HEATER_ZONE1_COMMUNICATION
        HEATER_ZONE2_COMMUNICATION
        HEATER_ZONE1_READBACK
        HEATER_ZONE1_PROGRAM
        HEATER_ZONE2_READBACK
        HEATER_ZONE2_PROGRAM
        HEATER_ZONE1_ONOFF_PROGRAM
        HEATER_ZONE1_ONOFF_READBACK
        HEATER_ZONE2_ONOFF_READBACK
        HEATER_ZONE2_ONOFF_PROGRAM
        HEATER_ZONE1_ALARM
        HEATER_ZONE2_ALARM

        'Injection Valve
        TARGET1_INJECTION_VALVE_STATUS
        TARGET2_INJECTION_VALVE_STATUS
        TARGET3_INJECTION_VALVE_STATUS
        TARGET4_INJECTION_VALVE_STATUS

        'FilMetricDevice_Installed
        FILMETRIC_MEASURE
        FILMETRIC_RECIPE_SP
        FILMETRIC_LISTRECIPE_RB
        FILMETRIC_THICKNESS
        FILMETRIC_GOTO_BASELINE
        FILMETRIC_GOTO_THICKNESS
        FILMETRIC_GOF

        '<!--Step Complete-->
        PROCESS_RECIPE_STEP_COMPLETE

        PROCESS_CYCLEATM_START
        IG_ISOLATION_VALVE_STATUS

        '<-- Clear All Alarm --> 
        CLEAR_ALL_ALARM_PROGRAM

        PROCESS_CURRENT_RECIPE_LOOP
    End Enum

    Public Class CoronaUtility
#Region "Public methods"
        Public Shared Function Check_Recipe_Template_Version(ByVal chamberName As String, ByVal data As String) As Boolean
            Return CoronaUtility.SendCommandWithDataToCorona(chamberName, CORONACommands.CHECK_RECIPE_TEMPLATE_VERSION.ToString(), data)
        End Function
        Public Shared Function DoSetSubstrate_Goto_Slot(ByVal val As String, ByVal EquipmentName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DoSetSubstrate_Goto_Slot")
            Return CoronaUtility.SendCommandWithDataToCorona(EquipmentName, CORONACommands.SUBSTRATE_GOTO_SLOT.ToString(), val)
            AVPLib.Log.coreLogger.Info("Leave DoSetSubstrate_Goto_Slot")
        End Function
        Public Shared Function DoSetSubstrate_Table_Up_Down_Status(ByVal val As String, ByVal EquipmentName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DoSetSubstrate_Table_Up_Down_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            Return CoronaUtility.SendCommandWithDataToCorona(EquipmentName, CORONACommands.SUBSTRATE_TABLE_UP_DOWN_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetSubstrate_Table_Up_Down_Status")
        End Function
        Public Shared Function DoSetSubstrate_Table_Lift_Home(ByVal val As String, ByVal EquipmentName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DoSetSubstrate_Goto_Home")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            Return CoronaUtility.SendCommandWithDataToCorona(EquipmentName, CORONACommands.SUBSTRATE_TABLE_LIFT_HOME.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetSubstrate_Goto_Home")
        End Function
        Public Shared Function DoSetSubstrate_Lift_Up_Down_Status(ByVal val As String, ByVal EquipmentName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DoSetSubstrate_Lift_Up_Down_Status")
            Dim strData As String = IIf(val = ConstEnum.STR_ON, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED)
            Return CoronaUtility.SendCommandWithDataToCorona(EquipmentName, CORONACommands.SUBSTRATE_LIFT_UP_DOWN_STATUS.ToString(), strData)
            AVPLib.Log.coreLogger.Info("Leave DoSetSubstrate_Lift_Up_Down_Status")
        End Function

        Public Shared Function Bias_Target_Auto(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_Auto")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_Auto")
            Select Case data
                Case STR_ON
                    Return SendCommandWithDataToCorona(chamberName, CORONACommands.BIAS_MB_MATCH_MODE_PROGRAM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    Return SendCommandWithDataToCorona(chamberName, CORONACommands.BIAS_MB_MATCH_MODE_PROGRAM.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select

        End Function
        Public Shared Function RF_Target_Auto(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_Auto")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_Auto")
            Select Case data
                Case STR_ON
                    Return SendCommandWithDataToCorona(chamberName, CORONACommands.RF_TARGET_MB_MATCH_MODE_PROGRAM.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    Return SendCommandWithDataToCorona(chamberName, CORONACommands.RF_TARGET_MB_MATCH_MODE_PROGRAM.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
        End Function
        Public Shared Function Bias_Target_Recall(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_Recall")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_Recall")
            Return SendCommandWithDataToCorona(chamberName, CORONACommands.BIAS_MB_PRESET_RECALL_PROGRAM.ToString(), data)
        End Function
        Public Shared Function RF_Target_Recall(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_Recall")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_Recall")
            Return SendCommandWithDataToCorona(chamberName, CORONACommands.RF_TARGET_MB_PRESET_RECALL_PROGRAM.ToString(), data)
        End Function
        Public Shared Function Bias_Target_Store(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_Store")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_Store")
            Return SendCommandWithDataToCorona(chamberName, CORONACommands.BIAS_MB_PRESET_STORE_PROGRAM.ToString(), data)
        End Function
        Public Shared Function RF_Target_Store(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_Store")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_Store")
            Return SendCommandWithDataToCorona(chamberName, CORONACommands.RF_TARGET_MB_PRESET_STORE_PROGRAM.ToString(), data)
        End Function
#Region "Diagnostic Dialog"
        Public Shared Function Stop_PumpDown_Curve(ByVal strChamber As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Stop_PumpDown_Curve")
            Return AVPLib.Business.CoronaUtility.SendCommandWithDataToCorona _
                   (strChamber, AVPLib.Business.CORONACommands.PUMPDOWN_CURVE_SEQ.ToString(), _
                     AVPLib.ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave Stop_PumpDown_Curve")
        End Function

        Public Shared Function Start_PumpDown_Curve(ByVal strChamber As String, ByVal strSampleTime As String, ByVal strTotalTime As String, ByVal strDescription As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Start_PumpDown_Curve")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(strChamber)
            If CoronaUtility.SendCommandWithDataToCorona(strChamber, _
                                                    CORONACommands.ISOLATION_VALVE_STATUS.ToString(), _
                                                    IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, _
                                                        ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If AVPLib.Business.CoronaUtility.SendCommandWithDataToCorona _
                  (strChamber, AVPLib.Business.CORONACommands.PUMPDOWN_CURVE_INTERVAL_RECORDING.ToString(), _
                   "Interval=" & strSampleTime & "#Period=" & strTotalTime & _
                   "#Desc=" & strDescription & "#") Then
                    Return AVPLib.Business.CoronaUtility.SendCommandWithDataToCorona _
                        (strChamber, AVPLib.Business.CORONACommands.PUMPDOWN_CURVE_SEQ.ToString(), _
                         AVPLib.ConfigurationValues.DEVICE_STATUS_OPEN)
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave Start_PumpDown_Curve")
            Return False
        End Function

        Public Shared Function Start_Rate_Of_Rise(ByVal strChamber As String, ByVal strSampleTime As String, ByVal strTotalTime As String, ByVal strDescription As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Start_Rate_Of_Rise")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(strChamber)
            If CoronaUtility.SendCommandWithDataToCorona(strChamber, _
                                                    CORONACommands.ISOLATION_VALVE_STATUS.ToString(), _
                                                    IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, _
                                                        ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If AVPLib.Business.CoronaUtility.SendCommandWithDataToCorona _
                      (strChamber, AVPLib.Business.CORONACommands.RATE_OF_RISE_INTERVAL_RECORDING.ToString(), _
                       "Interval=" & strSampleTime & "#Period=" & strTotalTime & _
                       "#Desc=" & strDescription & "#") Then
                    Return AVPLib.Business.CoronaUtility.SendCommandWithDataToCorona _
                        (strChamber, AVPLib.Business.CORONACommands.RATE_OF_RISE_SEQ.ToString(), _
                         AVPLib.ConfigurationValues.DEVICE_STATUS_OPEN)
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave Start_Rate_Of_Rise")
            Return False
        End Function

        Public Shared Function Stop_Rate_Of_Rise(ByVal strChamber As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Stop_Rate_Of_Rise")
            Return AVPLib.Business.CoronaUtility.SendCommandWithDataToCorona _
                    (strChamber, AVPLib.Business.CORONACommands.RATE_OF_RISE_SEQ.ToString(), _
                     AVPLib.ConfigurationValues.DEVICE_STATUS_CLOSED)
            AVPLib.Log.coreLogger.Info("Leave Stop_Rate_Of_Rise")
        End Function

#End Region

        Public Shared Function SendCommandWithDataToCorona(ByVal chamberName As String, ByVal commandName As String, ByVal commandData As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SendCommandWithDataToCorona")
            Try
                Dim commandCode As String = ContainerData.GetCoronaCmdCode(commandName)
                If Not String.IsNullOrEmpty(commandCode) Then
                    If Not String.IsNullOrEmpty(commandData) Then
                        commandCode = commandCode & ConstEnum.SEPARATOR_CMD_DATA & commandData
                    End If
                    AVPLib.Log.coreLogger.Info("Leave SendCommandWithDataToCorona")
                    Return Utils.SendCommandPMServer(chamberName, commandCode)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendCommandWithDataToCorona")
            Return False
        End Function

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-03-11</date>
        ''' </author>
        ''' <summary>
        ''' CopyDataFromIBE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'GAS_FLOWRATE_WARNING_TIME
        Public Shared Function SetWaferStatusToCorona(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SetWaferStatusToCorona")
            UpdateWaferID(chamberName)
            Try
                Select Case Integer.Parse(data)
                    Case ConstEnum.enumWaferStatus.eWaferNew
                        data = ConfigurationValues.DEVICE_STATUS_OPEN   '01'
                    Case ConstEnum.enumWaferStatus.eWaferExposed
                        data = ConfigurationValues.DEVICE_STATUS_STOPPED   '02'
                    Case ConstEnum.enumWaferStatus.eWaferComplete
                        data = ConfigurationValues.DEVICE_STATUS_ABORT      '03'
                    Case ConstEnum.enumWaferStatus.eWaferError
                        data = ConfigurationValues.DEVICE_STATUS_OTHER    '04'
                End Select
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.ToString)
            End Try

            AVPLib.Log.coreLogger.Info("Leave SetWaferStatusToCorona")
            Return SendCommandWithDataToCorona(chamberName, CORONACommands.WAFER_PROCESSING_STATUS_READBACK.ToString(), data)
        End Function

        ''' <author>
        '''    	<name> Hoai Ly </name>
        '''    	<date> 2015-12-28</date>
        ''' </author>
        ''' <summary>
        ''' SetWaferDeleteToCorona
        ''' </summary>
        Public Shared Function SetWaferDeleteToCorona(ByVal chamberName As String, ByVal slot As String) As Boolean
            Try
                Return SendCommandWithDataToCorona(chamberName, CORONACommands.WAFER_DELETE.ToString(), slot)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.ToString)
            End Try
        End Function

        ''' <author>
        '''    	<name> Hoai Ly </name>
        '''    	<date> 2015-12-28</date>
        ''' </author>
        ''' <summary>
        ''' SetWaferSlotToCorona
        ''' </summary>
        Public Shared Function SetWaferSlotToCorona(ByVal chamberName As String, ByVal slot As String) As Boolean
            Try
                Return SendCommandWithDataToCorona(chamberName, CORONACommands.WAFER_SLOT.ToString(), slot)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.ToString)
            End Try
        End Function

        Public Shared Sub UpdateWaferID(ByVal chamberName As String)
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrValues As New ArrayList()
                Dim strWaferID As String = String.Empty
                Dim m_objCoronaChamber As DataManagerment.CoronaChamber = DataManagerment.EquipmentManager.GetEquipment(chamberName)
                If (m_objCoronaChamber IsNot Nothing) Then
                    For index As Integer = 1 To m_objCoronaChamber.WaferCapacity
                        Dim objWaferInfo As AVPWaferInfo = Nothing
                        Dim gemWaferID As String = String.Empty

                        objWaferInfo = m_objCoronaChamber.GetWaferInfo(index)
                        If (objWaferInfo IsNot Nothing) Then
                            gemWaferID = Utils.GetGEMWaferID(objWaferInfo.WaferID)

                            If (strWaferID = String.Empty) Then
                                strWaferID = objWaferInfo.WaferID
                            Else
                                strWaferID &= ", " & objWaferInfo.WaferID
                            End If
                        End If

                        '0009198: [KhoiHa - 04/05/2016] 3. Able to determine which wafer in which slot (Slots in PM) via GEMS.
                        arrPropertyNames.Add("WaferID_Slot" & index)
                        arrValues.Add(gemWaferID)
                        '--------------------------------------------
                    Next
                    arrPropertyNames.Add("Process_Wafer_ID")
                    arrValues.Add(strWaferID)
                    DataManagerment.EquipmentManager.ChangeStatus(chamberName, arrPropertyNames, arrValues)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub
#End Region
    End Class
End Namespace

