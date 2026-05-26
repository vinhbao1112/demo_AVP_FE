Imports System.Threading
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum

Namespace DataManagerment
    Public Class PVD5TChamber
        Inherits CoronaChamber
        Public Sub New(ByVal strName As String, ByVal NumberOfSlot As Integer)
            MyBase.New(strName, NumberOfSlot)
        End Sub

#Region "Class Constants & Variables"
        Private m_Target5_Magnatron_On_Off As WorkingStatuses
        Private m_Target5_Magnatron_Rotate_Status As WorkingStatuses
        Private m_Target5_Set_Shields_Quart As Double
        Private m_Target5_Shields_Quart As Double
        Private m_Target5_Kwh_Usage As Double
        Private m_Target5_Set_Kwh_Usage As Double
        Private m_Target5_Shutter_Status As WorkingStatuses
        Private m_Chamberinterlock_Target1_Water_Status As WorkingStatuses
        Private m_Chamberinterlock_Target2_Water_Status As WorkingStatuses
        Private m_Chamberinterlock_Target3_Water_Status As WorkingStatuses
        Private m_Chamberinterlock_Target4_Water_Status As WorkingStatuses
        Private m_Chamberinterlock_Target5_Water_Status As WorkingStatuses
        Private m_Current_Shutter As String
        Private m_Home_Shutter_Status As WorkingStatuses
        Private m_Substrate_Goto_Shutter As Integer
        '<Cryo>------------------------------------------------
        Private m_dblCryo_T1_Readback As Double
        Private m_dblCryo_T2_Readback As Double
        Private m_Cryo_CommunicationStatus As WorkingStatuses
        Private m_dblCryo_RegenHour_Readback As Double
        Private m_dblCryo_LifeTimeHour_Readback As Double
        Private m_strCryo_P_Command As String
        Private m_Cryo_PowerOnOff As WorkingStatuses
        Private m_dblCryoRegenStatusText As String
        Private m_CryoRegenStatus As WorkingStatuses
        Private m_CryoFastRegenStatus As WorkingStatuses
        Private m_CryoRoughPumpInUsed As String

#End Region


#Region "Property"
        Public Property Target5_Magnatron_On_Off() As WorkingStatuses
            Get
                Return m_Target5_Magnatron_On_Off
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target5_Magnatron_On_Off", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target5_Magnatron_On_Off", m_Target5_Magnatron_On_Off, value, False)
            End Set
        End Property
        Public Property Target5_Magnatron_Rotate_Status() As WorkingStatuses
            Get
                Return m_Target5_Magnatron_Rotate_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target5_Magnatron_Rotate_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target5_Magnatron_Rotate_Status", m_Target5_Magnatron_Rotate_Status, value, False)
            End Set
        End Property
        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2025-18-11 </date>
        ''' </author>
        ''' <summary>
        ''' Set Shields/Quart KWH Target5
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Target5_Set_Shield_Quart() As Double
            Get
                Return m_Target5_Set_Shields_Quart
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target5_Set_Shield_Quart", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target5_Set_Shield_Quart", m_Target5_Set_Shields_Quart, value, False)
            End Set
        End Property

        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2025-11-134 </date>
        ''' </author>
        ''' <summary>
        ''' Shields/Quart KWH 5
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Target5_Shield_Quart() As Double
            Get
                Return m_Target5_Shields_Quart
            End Get
            Set(ByVal value As Double)
                ' Update SECS/GEM variables by Tin Pham
                ' Var Name: PMX.ShieldQuartz
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target5_Shield_Quart", VALUELib.ValueType.F4, value)
                m_Target5_Shields_Quart = value
            End Set
        End Property
        Public Property Target5_Kwh_Usage() As Double
            Get
                Return m_Target5_Kwh_Usage
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target5_KWH_Usage", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target5_Kwh_Usage", m_Target5_Kwh_Usage, value, False)
                If m_objChamberModule Is Nothing Then ' Lazy Initialization.
                    m_objChamberModule = ContainerData.GetRobotConfig(Me.Name)
                End If
                If (m_objChamberModule IsNot Nothing) Then
                    CheckingKWH(m_Target5_Kwh_Usage, 5)
                End If
            End Set
        End Property
        Public Property Target5_Set_Kwh_Usage() As Double
            Get
                Return m_Target5_Set_Kwh_Usage
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target5_Set_Kwh_Usage", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target5_Set_Kwh_Usage", m_Target5_Set_Kwh_Usage, value, False)
            End Set
        End Property

        Public Property Target5_Shutter_Status() As WorkingStatuses
            Get
                Return m_Target5_Shutter_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target5_Shutter_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Target5_Shutter_Status", m_Target5_Shutter_Status, value, False)
            End Set
        End Property

        Public Property Chamberinterlock_Target1_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Target1_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Target1_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Target1_Water_Status", m_Chamberinterlock_Target1_Water_Status, value, False)
            End Set
        End Property

        Public Property Chamberinterlock_Target2_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Target2_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Target2_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Target2_Water_Status", m_Chamberinterlock_Target2_Water_Status, value, False)
            End Set
        End Property

        Public Property Chamberinterlock_Target3_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Target3_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Target3_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Target3_Water_Status", m_Chamberinterlock_Target3_Water_Status, value, False)
            End Set
        End Property

        Public Property Chamberinterlock_Target4_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Target4_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Target4_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Target4_Water_Status", m_Chamberinterlock_Target4_Water_Status, value, False)
            End Set
        End Property

        Public Property Chamberinterlock_Target5_Water_Status() As WorkingStatuses
            Get
                Return m_Chamberinterlock_Target5_Water_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Chamberinterlock_Target5_Water_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Chamberinterlock_Target5_Water_Status", m_Chamberinterlock_Target5_Water_Status, value, False)
            End Set
        End Property
        Public Property Current_Shutter_ReadBack() As String
            Get
                Return m_Current_Shutter
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Current_Shutter_ReadBack", VALUELib.ValueType.A, value)
                CheckValueForLog("Current_Shutter_ReadBack", m_Current_Shutter, value, False)
            End Set
        End Property
        Public Property Home_Shutter_Status() As WorkingStatuses
            Get
                Return m_Home_Shutter_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Home_Shutter_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Home_Shutter_Status", m_Home_Shutter_Status, value, False)
            End Set
        End Property
        Public Property Substrate_Goto_Shutter() As Integer
            Get
                Return m_Substrate_Goto_Shutter
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Goto_Shutter", VALUELib.ValueType.F4, value)
                CheckValueForLog("Substrate_Goto_Shutter", m_Substrate_Goto_Shutter, value, False)
            End Set
        End Property

#Region "Rename GEM"
        Public Overrides Property Process_Current_Step() As String
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

                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Process_Step", VALUELib.ValueType.A, temp)
                Else
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Process_Step", VALUELib.ValueType.A, value)
                End If
            End Set
        End Property
        Public Overrides Property Process_Total_Steps() As String
            Get
                Return m_Process_Total_Steps
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Total_Step", VALUELib.ValueType.A, value)
                CheckValueForLog("Process_Total_Steps", m_Process_Total_Steps, value, False)
            End Set
        End Property
        Public Overrides Property Initialized_Motion() As WorkingStatuses
            Get
                Return m_Initialized_Motion
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Motion_Initalized_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Initialized_Motion", m_Initialized_Motion, value, False)
            End Set
        End Property
        Public Overrides Property Substrate_Lift_Up_Down_Status() As WorkingStatuses
            Get
                Return m_Substrate_Lift_Up_Down_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_WaferLift_UpDown_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Substrate_Lift_Up_Down_Status", m_Substrate_Lift_Up_Down_Status, value, False)
            End Set
        End Property
        Public Overrides Property Substrate_Table_Rotate_Home() As WorkingStatuses
            Get
                Return m_Substrate_Goto_Home
            End Get
            Set(ByVal value As WorkingStatuses)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Table_Rotation_Home", VALUELib.ValueType.U1, value)
                CheckValueForLog("Substrate_Goto_Home", m_Substrate_Goto_Home, value, False)
            End Set
        End Property
        Public Overrides Property Substrate_Table_Lift_Home() As WorkingStatuses
            Get
                Return m_Substrate_Table_Lift_Home
            End Get
            Set(ByVal value As WorkingStatuses)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Substrate_Table_UpDown_Home", VALUELib.ValueType.U1, value)
                CheckValueForLog("Substrate_Table_Lift_Home", m_Substrate_Table_Lift_Home, value, False)
            End Set
        End Property
        Public Overrides Property Water_Pump_T_Readback() As Double
            Get
                Return m_Water_Pump_T_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Water_Pump_Temperature_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Water_Pump_T_Readback", m_Water_Pump_T_Readback, value, False)
            End Set
        End Property
        Public Overrides Property Water_Pump_Regen_Hour_Readback() As Double
            Get
                Return m_Water_Pump_Regen_Hour_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Water_Pump_Regen_Hours_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Water_Pump_Regen_Hour_Readback", m_Water_Pump_Regen_Hour_Readback, value, False)
            End Set
        End Property
        Public Overrides Property Water_Pump_Regen_Lifetime_Readback() As Double
            Get
                Return m_Water_Pump_Regen_Lifetime_Readback
            End Get
            Set(ByVal value As Double)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Water_Pump_Lifetime_Hours_Readback", VALUELib.ValueType.F4, value)
                CheckValueForLog("Water_Pump_Regen_Lifetime_Readback", m_Water_Pump_Regen_Lifetime_Readback, value, False)
            End Set
        End Property
        Public Overrides Property Turbo_Pump_On_Off_Rb() As WorkingStatuses
            Get
                Return m_Turbo_Pump_On_Off_Rb
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Turbo_Pump_OnOff_Status", VALUELib.ValueType.U1, value)
                CheckValueForLog("Turbo_Pump_On_Off_Rb", m_Turbo_Pump_On_Off_Rb, value, False)
            End Set
        End Property
        Public Overrides Property Turbo_Pump_Uptospeed_Rb() As WorkingStatuses
            Get
                Return m_Turbo_Pump_Uptospeed_Rb
            End Get
            Set(ByVal value As WorkingStatuses)
                'TODO: Check GEM Variable Type and Value  
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Turbo_Pump_Ready_Readback", VALUELib.ValueType.U1, value)
                CheckValueForLog("Turbo_Pump_Uptospeed_Rb", m_Turbo_Pump_Uptospeed_Rb, value, False)
            End Set
        End Property
        Public Overrides Property RF_Target_MB_Mag_Error_Readback() As String
            Get
                Return m_RF_Target_MB_Mag_Error_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Mag_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("RF_Target_MB_Mag_Readback", m_RF_Target_MB_Mag_Error_Readback, value, False)
            End Set
        End Property
        Public Overrides Property RF_Target_MB_Phase_Error_Readback() As String
            Get
                Return m_RF_Target_MB_Phase_Error_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RF_Target_MB_Phase_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("RF_Target_MB_Phase_Readback", m_RF_Target_MB_Phase_Error_Readback, value, False)
            End Set
        End Property
        Public Overrides Property Bias_MB_Mag_Error_Readback() As String
            Get
                Return m_Bias_MB_Mag_Error_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Mag_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("Bias_MB_Mag_Readback", m_Bias_MB_Mag_Error_Readback, value, False)
            End Set
        End Property
        Public Overrides Property Bias_MB_Phase_Error_Readback() As String
            Get
                Return m_Bias_MB_Phase_Error_Readback
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Bias_MB_Phase_Readback", VALUELib.ValueType.A, value)
                CheckValueForLog("Bias_MB_Phase_Readback", m_Bias_MB_Phase_Error_Readback, value, False)
            End Set
        End Property
        Public Overrides Property Target_Select_Readback() As Integer
            Get
                Return m_Target_Select_Readback
            End Get
            Set(ByVal value As Integer)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target_Selection", VALUELib.ValueType.F4, value)
                CheckValueForLog("Target_Selection", m_Target_Select_Readback, value, False)
            End Set
        End Property

        Private m_Target5_Injection_ValveStatus As WorkingStatuses
        Public Property Target5_Injection_ValveStatus() As WorkingStatuses
            Get
                Return m_Target5_Injection_ValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Target5_Injection_ValveStatus", m_Target5_Injection_ValveStatus, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Target5_Injection_ValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property
        Public Overrides Property Process_Mode() As String
            Get
                Return m_Process_Mode
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                'Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessingMode", VALUELib.ValueType.F4, ChangeTypeUpdateGEM(value))
                CheckValueForLog("Process_Mode", m_Process_Mode, value, False)
            End Set
        End Property

        Public Overrides Property Process_Revolution_Count() As String
            Get
                Return m_Process_Revolution_Count
            End Get
            Set(ByVal value As String)
                'TODO: Check GEM Variable Type and Value 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessingMode", VALUELib.ValueType.A, value)
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
#Region "Cryo"
        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets the cryo regeneration hour readback value.
        ''' Updates SECS/GEM SV "Cryo.RegenHour" on set.
        ''' </summary>
        Public Property Cryo_RegenHour_Readback() As Double
            Get
                Return m_dblCryo_RegenHour_Readback
            End Get
            Set(ByVal value As Double)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.RegenHour", VALUELib.ValueType.F4, value)
                CheckValueForLog("Cryo Regen Hour Readback", m_dblCryo_RegenHour_Readback, value, False)
            End Set
        End Property

        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets the cryo lifetime hour readback value.
        ''' Updates SECS/GEM SV "Cryo.LifeTimeHour" on set.
        ''' </summary>
        Public Property Cryo_LifeTimeHour_Readback() As Double
            Get
                Return m_dblCryo_LifeTimeHour_Readback
            End Get
            Set(ByVal value As Double)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.LifeTimeHour", VALUELib.ValueType.F4, value)
                CheckValueForLog("Cryo Life Time Hour Readback", m_dblCryo_LifeTimeHour_Readback, value, False)
            End Set
        End Property

        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets the cryo first-stage temperature (T1) readback value.
        ''' Updates SECS/GEM SV "Cryo.FistTemperature" on set.
        ''' </summary>
        Public Property Cryo_T1_Readback() As Double
            Get
                Return m_dblCryo_T1_Readback
            End Get
            Set(ByVal value As Double)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.FistTemperature", VALUELib.ValueType.F4, value)
                CheckValueForLog("Cryo T1 Readback", m_dblCryo_T1_Readback, value, False)
            End Set
        End Property

        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets the cryo second-stage temperature (T2) readback value.
        ''' Updates SECS/GEM SV "Cryo.SecondTemperature" on set.
        ''' </summary>
        Public Property Cryo_T2_Readback() As Double
            Get
                Return m_dblCryo_T2_Readback
            End Get
            Set(ByVal value As Double)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.SecondTemperature", VALUELib.ValueType.F4, value)
                CheckValueForLog("Cryo T2 Readback", m_dblCryo_T2_Readback, value, False)
            End Set
        End Property

        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets the cryo communication status.
        ''' Updates SECS/GEM SV "Cryo.CommunicationStatus" on set.
        ''' </summary>
        Public Property Cryo_CommunicationStatus() As WorkingStatuses
            Get
                Return m_Cryo_CommunicationStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.CommunicationStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Cryo Communication Status", m_Cryo_CommunicationStatus, value)
            End Set
        End Property

        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets the cryo parameterized command string (e.g. extended purge time, pump restart delay).
        ''' </summary>
        Public Property Cryo_P_Command() As String
            Get
                Return m_strCryo_P_Command
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Cryo P Command", m_strCryo_P_Command, value)
            End Set
        End Property

        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets the cryo regeneration status text description.
        ''' </summary>
        Public Property CryoRegenStatusText() As String
            Get
                Return m_dblCryoRegenStatusText
            End Get
            Set(ByVal value As String)
                m_dblCryoRegenStatusText = value
            End Set
        End Property

        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets the cryo regeneration on/off status.
        ''' Updates SECS/GEM SV "Cryo.RegenOnOff" on set.
        ''' </summary>
        Public Property CryoRegenStatus() As WorkingStatuses
            Get
                Return m_CryoRegenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.RegenOnOff",
                VALUELib.ValueType.U1, Utils.ConvertWorkingStatusValueForUpdateGEM(value))
                CheckValueForLog("Cryo Regen Status", m_CryoRegenStatus, value)
            End Set
        End Property

        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets the cryo pump power on/off status.
        ''' Updates SECS/GEM SV "Cryo.OnOff" on set.
        ''' </summary>
        Public Property CryoPowerOnOff() As WorkingStatuses
            Get
                Return m_Cryo_PowerOnOff
            End Get
            Set(ByVal value As WorkingStatuses)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.OnOff", VALUELib.ValueType.U1, value)
                CheckValueForLog("Cryo Power On Off", m_Cryo_PowerOnOff, value)
            End Set
        End Property

        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets the cryo fast regeneration on/off status.
        ''' Updates SECS/GEM SV "Cryo.FastRegenOnOff" on set.
        ''' </summary>
        Public Property CryoFastRegenStatus() As WorkingStatuses
            Get
                Return m_CryoFastRegenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Cryo.FastRegenOnOff", VALUELib.ValueType.U1, value)
                CheckValueForLog("Cryo Fast Regen Status", m_CryoFastRegenStatus, value)
            End Set
        End Property

        ''' <author>
        '''     <name> Kiet Tran </name>
        '''     <date> 2026-05-12</date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets Cryo Rough Pump In Used
        ''' </summary>
        Public Property CryoRoughPumpInUsed() As String
            Get
                Return m_CryoRoughPumpInUsed
            End Get
            Set(ByVal value As String)
                If (m_CryoRoughPumpInUsed <> value) Then
                    m_CryoRoughPumpInUsed = value
                    If AVPLib.RobotConfigurationValues.SHARED_MP_WITH_PM Then
                        Dim objRough As RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(Me.Name)
                        If (objRough IsNot Nothing) Then
                            If String.IsNullOrEmpty(m_CryoRoughPumpInUsed) Then
                                objRough.ReleaseRoughLineInUse(Me.Name)
                            Else
                                objRough.SetRoughLineInUse(Me.Name, True)
                            End If
                        End If
                    End If
                End If
            End Set
        End Property
#End Region
#End Region

#End Region


#Region "KWH Limit Checking"

        ''' <author>
        '''    	<name> Duc Dang </name>
        '''    	<date> 2025-12-31</date>
        ''' </author>
        ''' <summary>
        ''' Checks if any target in the provided list has exceeded its KWH warning limit.
        ''' Returns True if any target usage is over warning threshold, False otherwise.
        ''' </summary>
        Public Overrides Function CheckingKWHOverWarningLimit(ByVal sTargetUsed As List(Of String)) As Boolean
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
                        Case "T5"
                            If IsUseMaxLimit Then
                                newTxWarning_KWH = Math.Abs(m_objChamberModule.Warning_KWH4 - m_objChamberModule.Max_KWH_Source4)
                            Else
                                newTxWarning_KWH = m_objChamberModule.Warning_KWH4
                            End If
                            mTargetKwhUsage = m_Target5_Kwh_Usage
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

        ''' <author>
        '''    	<name> Duc Dang </name>
        '''    	<date> 2025-12-31</date>
        ''' </author>
        ''' <summary>
        ''' Checks if any target in the provided list has exceeded its KWH alarm limit.
        ''' Returns True if any target usage is over alarm threshold, False otherwise.
        ''' </summary>
        Public Overrides Function CheckingKWHOverAlarmLimit(ByVal sTargetUsed As List(Of String)) As Boolean
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
                        Case "T5"
                            If IsUseMaxLimit Then
                                newTxAlarm_KWH = Math.Abs(m_objChamberModule.Alarm_KWH4 - m_objChamberModule.Max_KWH_Source4)
                            Else
                                newTxAlarm_KWH = m_objChamberModule.Alarm_KWH4
                            End If
                            mTargetKwhUsage = m_Target5_Kwh_Usage
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
#End Region

        ''' <author>
        '''     <name> Duc Dang </name>
        '''     <date> 2026-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Update Variable For Gem When Init
        ''' </summary>
        Public Overrides Sub UpdateVariableForGemWhenInit()
            MyBase.UpdateVariableForGemWhenInit()
            Cryo_CommunicationStatus = WorkingStatuses.Off
            CryoPowerOnOff = WorkingStatuses.Off
            CryoRegenStatus = WorkingStatuses.Off
            CryoFastRegenStatus = WorkingStatuses.Off
            Cryo_T1_Readback = 0
            Cryo_T2_Readback = 0
            Cryo_RegenHour_Readback = 0
            Cryo_LifeTimeHour_Readback = 0
        End Sub

    End Class
End Namespace

