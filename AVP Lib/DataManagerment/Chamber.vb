Imports System.Threading
Imports AVPLib.ConstEnum
Imports AVPLib.Business

Namespace DataManagerment
    Public Class Chamber
        Inherits Equipment

#Region "Class Constants & Variables"
        Protected m_ConnectionStatus As WorkingStatuses
        '<!-- Event Status-->
        Protected m_strEventText As String
        ''<!-- Status Message -->
        Protected m_strAlarmText As String

        Protected m_strRecipe As String
        Protected m_strRemainingTime As String
        Protected m_strElapsedTime As String
        Protected m_strStepTime As String
        Protected m_strProcessStep As String
        Protected m_dblStepCompleted As Double = 0
        Protected m_strCurrentRecipeLoop As String = String.Empty
        Protected m_enmPressureMode As EnumPressureMode = EnumPressureMode.CG
        Protected m_dblProcessPressure As Double
        Protected m_dblIG As Double
        Protected m_dblCG As Double
        Protected m_enmIGStatus As WorkingStatuses
        Protected m_enmEquipmentType As AVPLib.SystemModule.ModuleType

        '<!-- WaferStatus-->
        Protected m_RunProcessStatus As ConstEnum.enumProcessStatus = ConstEnum.enumProcessStatus.eStop
        Protected m_Initialize_Motion_readback As WorkingStatuses = WorkingStatuses.Off

        Public IsProcessRunning As Boolean = False
        Public IsAbortInProcess As Boolean = False
        Public IsPauseInProcess As Boolean = False
        Public IsAlarmReceivedDuringRunProcess As Boolean = False
        Public RunProcessResult As EnumRunProcessResult = EnumRunProcessResult.NotDefined

        Private m_intPMWaferCount As Integer = 0
        Private m_dblShields_Quart_KWH As Double = 0
        Private m_dblMaxKWH As Double = 0

        Protected m_RateOfRise_Status As WorkingStatuses
        Protected m_strRateOfRise_Sample As String
        Protected m_strRateOfRise_FileName As String
        Protected m_strRateOfRise_Interval As String

        Protected m_PumpDown_Curve_Status As WorkingStatuses
        Protected m_strPumpDown_Curve_Sample As String
        Protected m_strPumpDown_Curve_FileName As String
        Protected m_strPumpDown_Curve_Interval As String


        Private m_blnIsUseMaxLimit As Boolean = False

        Private m_strMaintenanceMode As String = String.Empty
        Private m_blnEditableIn_MaintenanceMode As Boolean = False
        Private m_StartCopyRecipeToPMFolder As String = String.Empty
        Private m_StartCopyRecipeTemplate As String = String.Empty
        Protected m_PumpPurgeCurrentCycle As String = String.Empty
        Protected m_OverridesModeStatus As WorkingStatuses
        Protected m_VentValveStatus As WorkingStatuses
        Protected m_RoughValveStatus As WorkingStatuses
        Protected m_ClampStatus As WorkingStatuses
        Protected m_FixtureClampStatus As WorkingStatuses
        Protected m_dblGasController_Gas1_Readback As Double
        Protected m_dblGasController_Gas2_Readback As Double
        Protected m_dblGasController_Gas3_Readback As Double
        Protected m_dblGasController_Gas4_Readback As Double
        Protected m_dblGasController_Gas5_Readback As Double
        Protected m_dblGasController_Gas1_Program As Double
        Protected m_dblGasController_Gas2_Program As Double
        Protected m_dblGasController_Gas3_Program As Double
        Protected m_dblGasController_Gas4_Program As Double
        Protected m_dblGasController_Gas5_Program As Double
        Protected m_Gas1ShutOffValveStatus As WorkingStatuses
        Protected m_Gas2ShutOffValveStatus As WorkingStatuses
        Protected m_Gas3ShutOffValveStatus As WorkingStatuses
        Protected m_Gas4ShutOffValveStatus As WorkingStatuses
        Protected m_Gas5ShutOffValveStatus As WorkingStatuses
        Protected m_Gas1SupplyValveStatus As WorkingStatuses
        Protected m_Gas2SupplyValveStatus As WorkingStatuses
        Protected m_Gas3SupplyValveStatus As WorkingStatuses
        Protected m_Gas4SupplyValveStatus As WorkingStatuses
        Protected m_Gas5SupplyValveStatus As WorkingStatuses
        Protected m_ForelineValveStatus As WorkingStatuses

        Protected m_enmPreviousOperationStatus As OperationStatuses
        Public m_IsSchedulerRunningInPM As Boolean = False

        Private m_strGEMModuleType As String
        Private m_strGEMModuleName As String = m_strName
        Private m_countingProcessTimeLocker As New Object
        Protected m_ListLoadLockWarmUp As New ArrayList

        Public Enum EnumRunProcessResult
            NotDefined = -1
            Starting = 0
            CouldNotStart = 1
            AbortedByUser
            AlarmHappennedDuringProcessing
            ProcessingCompleted
            Running ' PVD
            PausedByUser
            Aborting ' PVD
            Resuming ' PVD
        End Enum

#Region "Gas Controller"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property GasController_Gas1_Readback() As Double
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
        Public Overridable Property GasController_Gas2_Readback() As Double
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
        Public Overridable Property GasController_Gas3_Readback() As Double
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
        Public Overridable Property GasController_Gas4_Readback() As Double
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
        Public Overridable Property GasController_Gas5_Readback() As Double
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
        Public Overridable Property GasController_Gas1_Program() As Double
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
        Public Overridable Property GasController_Gas2_Program() As Double
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
        Public Overridable Property GasController_Gas3_Program() As Double
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
        Public Overridable Property GasController_Gas4_Program() As Double
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
        Public Overridable Property GasController_Gas5_Program() As Double
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
        ''' Get or Set ShutOff1 Valve Status
        ''' </summary>
        ''' <remarks></remarks>      
        Public Overridable Property Gas1ShutOffValveStatus() As WorkingStatuses
            Get
                Return m_Gas1ShutOffValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas1ShutOffValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1ShutOffValveStatus", VALUELib.ValueType.U1, value)
                CheckValueForLog("Gas1ShutOffValveStatus", m_Gas1ShutOffValveStatus, value)
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
        Public Overridable Property Gas2ShutOffValveStatus() As WorkingStatuses
            Get
                Return m_Gas2ShutOffValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas2ShutOffValveStatus                                           
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2ShutOffValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Gas2ShutOffValveStatus", m_Gas2ShutOffValveStatus, value)
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
        Public Overridable Property Gas3ShutOffValveStatus() As WorkingStatuses
            Get
                Return m_Gas3ShutOffValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas3ShutOffValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3ShutOffValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Gas3ShutOffValveStatus", m_Gas3ShutOffValveStatus, value)
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
        Public Overridable Property Gas4ShutOffValveStatus() As WorkingStatuses
            Get
                Return m_Gas4ShutOffValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas4ShutOffValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas4ShutOffValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Gas4ShutOffValveStatus", m_Gas4ShutOffValveStatus, value)
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
        Public Overridable Property Gas5ShutOffValveStatus() As WorkingStatuses
            Get
                Return m_Gas5ShutOffValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas5ShutOffValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas5ShutOffValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Gas5ShutOffValveStatus", m_Gas5ShutOffValveStatus, value)
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
        Public Overridable Property Gas1SupplyValveStatus() As WorkingStatuses
            Get
                Return m_Gas1SupplyValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas1SupplyValveStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas1SupplyValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Gas1SupplyValveStatus", m_Gas1SupplyValveStatus, value)
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
        Public Overridable Property Gas2SupplyValveStatus() As WorkingStatuses
            Get
                Return m_Gas2SupplyValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas2SupplyValveStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas2SupplyValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Gas2SupplyValveStatus", m_Gas2SupplyValveStatus, value)
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
        Public Overridable Property Gas3SupplyValveStatus() As WorkingStatuses
            Get
                Return m_Gas3SupplyValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas3SupplyValveStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas3SupplyValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Gas3SupplyValveStatus", m_Gas3SupplyValveStatus, value)
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
        Public Overridable Property Gas4SupplyValveStatus() As WorkingStatuses
            Get
                Return m_Gas4SupplyValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas4SupplyValveStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas4SupplyValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Gas4SupplyValveStatus", m_Gas4SupplyValveStatus, value)
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
        Public Overridable Property Gas5SupplyValveStatus() As WorkingStatuses
            Get
                Return m_Gas5SupplyValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.Gas5SupplyValveStatus 
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Gas5SupplyValveStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("Gas5SupplyValveStatus", m_Gas5SupplyValveStatus, value)
            End Set
        End Property
#End Region

        Public Property IsSchedulerRunningInPM() As Boolean
            Get
                Return m_IsSchedulerRunningInPM
            End Get
            Set(ByVal value As Boolean)
                CheckValueForLog("IsSchedulerRunningInPM", m_IsSchedulerRunningInPM, value, False)
            End Set
        End Property

        Protected m_WaferID As String
        Public Overridable Shadows Property WaferID() As String
            Get
                Return m_WaferID
            End Get
            Set(ByVal value As String)
                CheckValueForLog("WaferID", m_WaferID, value, False)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferID", VALUELib.ValueType.A, value.ToString())
            End Set
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-04-15 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Machine Vent
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property MachinePumpPurge_Current_Cycle() As String
            Get
                Return m_PumpPurgeCurrentCycle
            End Get
            Set(ByVal value As String)
                CheckValueForLog("MachinePumpPurge_Current_Cycle", m_PumpPurgeCurrentCycle, value)
            End Set
        End Property

        Public Overrides Property WaferStatus() As ConstEnum.enumWaferStatus
            Get
                Return m_WaferStatus
            End Get
            Set(ByVal value As ConstEnum.enumWaferStatus)
                CheckValueForLog("WaferStatus", m_WaferStatus, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "WaferStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Overridable Property EquipmentType() As AVPLib.SystemModule.ModuleType
            Get
                Return m_enmEquipmentType
            End Get
            Set(ByVal value As AVPLib.SystemModule.ModuleType)
                m_enmEquipmentType = value
                GEMModuleType = System.Enum.GetName(GetType(AVPLib.SystemModule.ModuleType), value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoai Ly </name>
        '''    	<date> 2015-06-10 </date>
        ''' </author>
        ''' <summary>
        ''' Get GEMModuleType
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GEMModuleType() As String
            Get
                Return m_strGEMModuleType
            End Get
            Set(ByVal value As String)
                m_strGEMModuleType = value
                Dim objModule As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.Name)
                Dim strname As String = value

                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ModuleType", VALUELib.ValueType.A, strname)
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoai Ly </name>
        '''    	<date> 2015-06-10 </date>
        ''' </author>
        ''' <summary>
        ''' Get GEMModuleName
        ''' </summary>
        ''' <remarks></remarks>
        Public Property GEMModuleName() As String
            Get
                Return m_strGEMModuleName
            End Get
            Set(ByVal value As String)
                m_strGEMModuleName = value

                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ModuleName", VALUELib.ValueType.A, m_strGEMModuleName)
            End Set
        End Property

        Public Overridable Property VentValveStatus() As WorkingStatuses
            Get
                Return m_VentValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Vent Valve Status", m_VentValveStatus, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "VentValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Overridable Property RoughValveStatus() As WorkingStatuses
            Get
                Return m_RoughValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                If (AVPLib.RobotConfigurationValues.SHARED_MP_WITH_PM AndAlso m_RoughValveStatus <> value) Then
                    Dim objRough As RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(Me.Name)
                    If (objRough IsNot Nothing) Then
                        'release rough pump 
                        If value = WorkingStatuses.Off Then
                            objRough.ReleaseRoughLineInUse(Me.Name)
                            'make rough pump opened
                        ElseIf (value = WorkingStatuses.On) Then
                            objRough.MakeRoughLineInUseNoWait(Me.Name)
                        End If
                    End If
                End If

                CheckValueForLog("Rough Valve Status", m_RoughValveStatus, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RoughValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Sub PreStartProcessing()
            m_RunProcessStatus = ConstEnum.enumProcessStatus.eStop
            IsAbortInProcess = False
            IsPauseInProcess = False
            IsAlarmReceivedDuringRunProcess = False
            RunProcessResult = EnumRunProcessResult.Starting
        End Sub

        Protected Overridable Function ChangeProcessState(ByVal newState As ConstEnum.enumProcessStatus) As Boolean
            m_RunProcessStatus = newState
            Return True
        End Function
#End Region

#Region "Properties"
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
                Utils.SaveLastExecution(Me.Name, m_LastExecution)
            End Set
        End Property

        Private m_Current_AVP_Time As String = String.Empty
        Public Property Current_AVP_Time() As String
            Get
                Return m_Current_AVP_Time
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Current_AVP_Time", m_Current_AVP_Time, value)
            End Set
        End Property

        ''rename this property from FixtureClampStatus
        Public Overridable Property ClampStatus() As WorkingStatuses
            Get
                Return m_FixtureClampStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Fixture Clamp Status", m_FixtureClampStatus, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FixtureClampStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Property OverridesModeStatus() As WorkingStatuses
            Get
                Return m_OverridesModeStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("OverridesModeStatus", m_OverridesModeStatus, value)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx.OverrideModeOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "OverrideModeOnOff", VALUELib.ValueType.U1, value)

            End Set
        End Property

        Public Property StartCopyRecipeToPMFolder() As String
            Get
                Return m_StartCopyRecipeToPMFolder
            End Get
            Set(ByVal value As String)
                m_StartCopyRecipeToPMFolder = value
                If m_StartCopyRecipeToPMFolder = ConfigurationValues.DEVICE_STATUS_OPEN Then '01
                    Dim PMController As Business.ChamberController = Business.ControllerManager.GetController(Me.Name)
                    PMController.CopyRecipeToPMFolder()
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Dy Do </name>
        '''    	<date> 2016-02-01</date>
        ''' </author>
        ''' <summary>
        ''' Start Copy Recipe Template Version
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StartCopyRecipeTemplate() As String
            Get
                Return m_StartCopyRecipeTemplate
            End Get
            Set(ByVal value As String)
                m_StartCopyRecipeTemplate = value
                If m_StartCopyRecipeTemplate = ConfigurationValues.DEVICE_STATUS_OPEN Then '01
                    Dim PMController As Business.ChamberController = Business.ControllerManager.GetController(Me.Name)
                    PMController.CopyRecipeTemplate()
                End If
            End Set
        End Property

        ''Truc Le: This property used for parse value from PM 
        Public Property MaintenanceMode() As String
            Get
                Return m_strMaintenanceMode
            End Get
            Set(ByVal value As String)
                Dim maintenaceModeValue As String = String.Empty

                If m_strMaintenanceMode <> value Then
                    m_strMaintenanceMode = value

                    Dim arr As Array = value.Split("#") ''1#1 or 0#1 or 1#0 or 0#0
                    If arr.Length = 2 Then
                        Dim PropertyNames As ArrayList = New ArrayList()
                        Dim ReplyValues As ArrayList = New ArrayList()
                        'check 
                        If arr(0).ToString() = ConfigurationValues.DEVICE_STATUS_OPEN Then ''01
                            ReplyValues.Add(DataManagerment.Equipment.ControlStatuses.MAINTENANCE)
                            ControlStatus = ControlStatuses.MAINTENANCE
                            m_blnEditableIn_MaintenanceMode = IIf(arr(1) = ConfigurationValues.DEVICE_STATUS_OPEN, True, False)
                        ElseIf arr(0).ToString() = ConfigurationValues.DEVICE_STATUS_CLOSED Then ''00
                            ReplyValues.Add(DataManagerment.Equipment.ControlStatuses.OFFLINE)
                            ControlStatus = ControlStatuses.OFFLINE
                            m_blnEditableIn_MaintenanceMode = True
                        End If
                        PropertyNames.Add("ControlStatus")
                        AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.Name, PropertyNames, ReplyValues)

                        maintenaceModeValue = arr(0)

                    Else '''incase PVD/IBE send wrong data -> return Offline
                        Dim PropertyNames As ArrayList = New ArrayList()
                        Dim ReplyValues As ArrayList = New ArrayList()
                        ReplyValues.Add(DataManagerment.Equipment.ControlStatuses.OFFLINE)
                        ControlStatus = ControlStatuses.OFFLINE
                        m_blnEditableIn_MaintenanceMode = True
                        PropertyNames.Add("ControlStatus")
                        AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.Name, PropertyNames, ReplyValues)

                        maintenaceModeValue = ConfigurationValues.DEVICE_STATUS_CLOSED
                    End If
                End If

                If Not String.IsNullOrEmpty(maintenaceModeValue) Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "MaintenanceMode", VALUELib.ValueType.A, maintenaceModeValue)
                End If
            End Set
        End Property

        Public ReadOnly Property EditableIn_MaintenanceMode() As Boolean
            Get
                Return m_blnEditableIn_MaintenanceMode
            End Get
        End Property

#Region "Graph"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set RateOfRise_Interval
        ''' </summary>
        ''' <remarks></remarks>
        Public Property PumpDown_Curve_Interval() As String
            Get
                Return m_strPumpDown_Curve_Interval
            End Get
            Set(ByVal value As String)
                CheckValueForLog("PumpDown Curve Interval", m_strPumpDown_Curve_Interval, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set RateOfRise_Interval
        ''' </summary>
        ''' <remarks></remarks>
        Public Property RateOfRise_Interval() As String
            Get
                Return m_strRateOfRise_Interval
            End Get
            Set(ByVal value As String)
                CheckValueForLog("RateOfRise Interval", m_strRateOfRise_Interval, value)
            End Set
        End Property
#End Region
#Region "Status,Connection and Alarm"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Event Message
        ''' </summary>
        ''' <remarks></remarks>
        Public Property EventMessage() As String
            Get
                Return m_strEventText
            End Get
            Set(ByVal value As String)
                'If m_strEventText <> value Then
                m_strEventText = value
                Dim strChamberName = Utils.chamberID2ChamberName(Me.Name)
                ' This is an event message.
                Utils.ShowStatusMessage(strChamberName + ": " + m_strEventText)
                'End If
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "EventMessage", VALUELib.ValueType.A, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-05-15 </date>
        ''' </author>
        ''' <summary>
        ''' CHEAT CODE SLEEP 2 MINUTES 
        ''' WAITING FOR CONNECTION STABLE
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SendSplitValveStatus_ToPM(ByVal value As Object)
            AVPLib.Log.coreLogger.Info("Enter SendToPVDSlitValveStatus")
            Try
                Thread.Sleep(5000)
                Dim PMIsoValveStatus As WorkingStatuses = Utils.GetChamberSlitValveStatus(Me.Name)
                Utils.SendSplitValveStatus_ToPM(Me.Name, PMIsoValveStatus)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Info("Enter SendToPVDSlitValveStatus")
            End Try
            AVPLib.Log.coreLogger.Info("Enter SendToPVDSlitValveStatus")
        End Sub

        Private Sub SendInformation_ToPM(ByVal value As Object)
            AVPLib.Log.coreLogger.Info("Enter SendInformation_ToPM")
            Try
                Dim objPMController As Business.ChamberController = Business.ControllerManager.GetController(Me.Name)
                If objPMController IsNot Nothing Then
                    Thread.Sleep(5000)
                    'send request data
                    If RobotConfigurationValues.SUPPORT_REQUEST_ALL_DATA_CHANGED AndAlso AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                        objPMController.SendRequestAllData()
                        Thread.Sleep(2000)
                        objPMController.DoCheckRecipeTemplateVersion()
                    End If

                    'send wafer status to PQL or PVD6P
                    If EquipmentType = SystemModule.ModuleType.PVD4 OrElse EquipmentType = SystemModule.ModuleType.PVD5T Then
                        objPMController.DoSetWaferStatus(String.Format("{0:00}", CType(WaferStatus, Integer)))
                    End If
                Else
                    AVPLib.Log.coreLogger.Info("Error in SendInformation_ToPM")
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error("SendInformation_ToPM:" & ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendInformation_ToPM")
        End Sub
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Conection Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ConnectionStatus() As WorkingStatuses
            Get
                Return m_ConnectionStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                If value = WorkingStatuses.On AndAlso value <> m_ConnectionStatus Then
                    ThreadPool.QueueUserWorkItem(AddressOf SendSplitValveStatus_ToPM, Nothing)
                    ThreadPool.QueueUserWorkItem(AddressOf SendInformation_ToPM, Nothing)
                End If

                m_ConnectionStatus = value
                'Update Secs/Gem variables by Hoa Nguyen
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CommunicationStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Status Message
        ''' </summary>
        ''' <remarks></remarks>
        Public Property StatusMessage() As String
            Get
                Return m_strAlarmText
            End Get
            Set(ByVal value As String)
                'If m_strAlarmText <> value Then
                m_strAlarmText = value
                ProcessReceivedAlarm(m_strAlarmText)
                'End If
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "StatusMessage", VALUELib.ValueType.A, value)
            End Set
        End Property

        Protected Overridable Sub ProcessReceivedAlarm(ByVal alarmContent As String)
            Dim strChamberName = Utils.chamberID2ChamberName(Me.Name)
            Dim strGemAlarmName = Utils.GemGetAlarmName(Me.Name)
            ' This is an alarm message.
            Utils.ThrowAlarm(strChamberName + ": " + alarmContent, strGemAlarmName)
        End Sub

        Protected Overridable Sub ProcessReceivedAlarmCX(ByVal alarmContent As String)
            Try
                Dim strChamberName = Utils.chamberID2ChamberName(Me.Name)
                Dim strGemAlarmName = Utils.GemGetAlarmName(Me.Name)
                Dim spaceFirstIdx = alarmContent.IndexOf(" "c)
                Dim spaceSecondIdx = alarmContent.IndexOf(" "c, spaceFirstIdx + 1)
                Dim strAlarmID As String = alarmContent.Substring(0, spaceFirstIdx + 1)
                Dim strAlarmLevel As String = alarmContent.Substring(spaceFirstIdx + 1, spaceSecondIdx - (spaceFirstIdx + 1))
                Dim nAlarmLevel As Int32 = 0
                Int32.TryParse(strAlarmLevel, nAlarmLevel)
                Dim alarmText As String = alarmContent.Substring(spaceSecondIdx + 1)
                alarmText = alarmText & " #" & strAlarmID
                ' Always log.
                If (nAlarmLevel > 0) Then

                    ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeWarning, strChamberName, alarmText)
                Else
                    If (IsProcessRunning) Then
                        IsAlarmReceivedDuringRunProcess = True
                    End If
                    ' This is an alarm message.
                    Utils.ThrowAlarm(strChamberName + ": " + alarmText, strGemAlarmName)

                    'Hoa Nguyen add #if platform
#If AVP_PLATFORM = "CX" Then
                    Dim info As String = strChamberName + ": " + alarmText
                    If (Me.GetWaferInfo() IsNot Nothing) Then
                        AddLotDatalog(ConstEnum.LoadLockA_STR, Me.GetWaferInfo().WaferID, info)
                    End If
#End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Private Sub AddLotDatalog(ByVal ToolName As String, ByVal waferID As String, ByVal Info As String)
            Try
                If (AVPLib.Business.AVPCore.Instance IsNot Nothing AndAlso _
                                AVPLib.Business.AVPCore.Instance().JobManager IsNot Nothing) Then
                    Dim avpProcessJob As AVPLib.Business.AVPProcessJob = _
                    AVPLib.Business.AVPCore.Instance().JobManager.GetProcessJob(waferID)
                    If (avpProcessJob IsNot Nothing AndAlso _
                    ToolName = avpProcessJob.AVPParentControlJob.LoadlockName) Then
                        Business.AVPLotDatalog.AddLotDatalog(ToolName, LogType.Alarm, _
                        Info, True)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Public Overridable Function IsShutterOpen() As Boolean
            Return True
        End Function

#End Region
#Region "Processing Wafer"
        Protected m_strProcessMonitor_DeviceStart_Readback As String
        Public Overridable Property ProcessMonitor_DeviceStart_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceStart_Readback
            End Get
            Set(ByVal value As String)
                Utils.UpdateSequenceRunningStatusText(Me.Name, RECIPE_PROCESS_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, STR_ON)
                CheckValueForLog("ProcessMonitor_DeviceStart_Readback", m_strProcessMonitor_DeviceStart_Readback, value, False)
                BeginCountingWaferProcessTime()
                ChangeProcessState(ConstEnum.enumProcessStatus.eStart)
                AVPLib.Utils.TurnOffSystem_Light(False, Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_DeviceStart_Readback", VALUELib.ValueType.A, value)
            End Set
        End Property

        Protected m_strProcessMonitor_DeviceStop_Readback As String
        Public Overridable Property ProcessMonitor_DeviceStop_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceStop_Readback
            End Get
            Set(ByVal value As String)
                Utils.UpdateSequenceRunningStatusText(Me.Name, RECIPE_PROCESS_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, STR_OFF)
                CheckValueForLog("ProcessMonitor_DeviceStop_Readback", m_strProcessMonitor_DeviceStop_Readback, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.eStop)
                EndCountingWaferProcessTime()
                AVPLib.Utils.TurnOffSystem_Light(True, Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_DeviceStop_Readback", VALUELib.ValueType.A, value)
            End Set
        End Property

        Protected m_strProcessMonitor_DevicePause_Readback As String
        Public Overridable Property ProcessMonitor_DevicePause_Readback() As String
            Get
                Return m_strProcessMonitor_DevicePause_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor_DevicePause_Readback", m_strProcessMonitor_DevicePause_Readback, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.ePause)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_DevicePause_Readback", VALUELib.ValueType.A, value)
            End Set
        End Property

        Protected m_strProcessMonitor_DeviceContinue_Readback As String
        Public Overridable Property ProcessMonitor_DeviceContinue_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceContinue_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor_DeviceContinue_Readback", m_strProcessMonitor_DeviceContinue_Readback, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.eContinue)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_DeviceContinue_Readback", VALUELib.ValueType.A, value)
            End Set
        End Property

        Protected m_strProcessMonitor_DeviceError_Readback As String
        Public Overridable Property ProcessMonitor_DeviceError_Readback() As String
            Get
                Return m_strProcessMonitor_DeviceError_Readback
            End Get
            Set(ByVal value As String)
                CheckValueForLog("ProcessMonitor_DeviceError_Readback", m_strProcessMonitor_DeviceError_Readback, value, False)
                ChangeProcessState(ConstEnum.enumProcessStatus.eError)
                AVPLib.Utils.TurnOffSystem_Light(True, Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessMonitor_DeviceError_Readback", VALUELib.ValueType.A, value)
            End Set
        End Property

#End Region
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-01-28</date>
        ''' </author>
        ''' <summary>
        ''' when job pause -> change chamber operation status to Error
        ''' when job resume -> roll back status to previous status
        ''' </summary>
        ''' <value></value>
        Public Property PreviousOperationStatus() As OperationStatuses
            Get
                Return m_enmPreviousOperationStatus
            End Get
            Set(ByVal value As OperationStatuses)
                m_enmPreviousOperationStatus = value
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
        Public Property IsUseMaxLimit() As Boolean
            Get
                Return m_blnIsUseMaxLimit
            End Get
            Set(ByVal value As Boolean)
                m_blnIsUseMaxLimit = value
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
                If IsUseMaxLimit Then
                    m_dblMaxKWH = value
                End If
            End Set
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-05-24 </date>
        ''' </author>
        ''' <summary>
        ''' Shields/Quart KWH
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Shields_Quart_KWH() As Double
            Get
                Return m_dblShields_Quart_KWH
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ShieldQuartz
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ShieldQuartz", VALUELib.ValueType.F4, value)

                m_dblShields_Quart_KWH = value
            End Set
        End Property

        Public Property PM_WaferCount() As Integer
            Get
                Return m_intPMWaferCount
            End Get
            Set(ByVal value As Integer)

                m_intPMWaferCount = m_intPMWaferCount + value

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.WaferCount
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CycleWaferCount", VALUELib.ValueType.F4, m_intPMWaferCount)
                ''save to StoreGui.xml
                AVPLib.ContainerData.SaveWaferCountForEQ(Me.Name, m_intPMWaferCount)
            End Set
        End Property

        Public Sub ResetWaferCount()
            m_intPMWaferCount = 0

            ' Update SECS/GEM variables by Dat Cao
            ' Var Name: PMX.WaferCount
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CycleWaferCount", VALUELib.ValueType.F4, m_intPMWaferCount)
            ContainerData.SaveWaferCountForEQ(Me.Name, m_intPMWaferCount)
        End Sub
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
        Public Overridable Property Initialize_Motion_readback() As WorkingStatuses
            Get
                Return m_Initialize_Motion_readback
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Initialize_Motion", m_Initialize_Motion_readback, value)
                ' Update SECS/GEM variables by Dat Vo
                ' Var Name: PMx. MotionInitializedOnStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "MotionInitializedOnStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Property RunProcessStatus() As ConstEnum.enumProcessStatus
            Get
                Return m_RunProcessStatus
            End Get
            Set(ByVal value As ConstEnum.enumProcessStatus)
                ChangeProcessState(value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current Recipe
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Recipe() As String
            Get
                Return m_strRecipe
            End Get
            Set(ByVal value As String)
                CheckValueForLog("Recipe", m_strRecipe, value)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ProcessRecipe
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessRecipe", VALUELib.ValueType.A, value)

            End Set
        End Property

        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2020-12-21</date>
        ''' </author>
        ''' <summary>
        ''' Get Warm Up
        ''' </summary>
        Private m_IsWarmUp As AVPLib.ConstEnum.RunningState = RunningState.NotDefined
        Public Property WarmUpState() As AVPLib.ConstEnum.RunningState
            Get
                Return m_IsWarmUp
            End Get
            Set(ByVal value As AVPLib.ConstEnum.RunningState)
                CheckValueForLog("IsWarmUp", m_IsWarmUp, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Vo Tan Dat </name>
        '''    	<date> 2012-05-12</date>
        ''' </author>
        ''' <summary>
        ''' Set ProcessRecipe SV for GEM
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub SetProcessRecipe(ByVal strNewProcessRecipe As String)
            CheckValueForLog("Recipe", m_strRecipe, strNewProcessRecipe)
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessRecipe", VALUELib.ValueType.A, strNewProcessRecipe)
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current RemainingTime
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RemainingTime() As String
            Get
                Return m_strRemainingTime
            End Get
            Set(ByVal value As String)
                CheckValueForLog("RemainingTime", m_strRemainingTime, value, False)

                Dim chamberConfig As SystemModule = Nothing
                chamberConfig = AVPLib.ContainerData.GetRobotConfig(Me.Name)
                If chamberConfig Is Nothing Then
                    Exit Property
                End If
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ProcessRemainingTime
                Dim lstString As String() = Split(value, "/")
                If lstString.Length = 2 Then
                    If IsNumeric(lstString(0)) Then ''IBE only
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessRemainingTime", VALUELib.ValueType.A, lstString(0))
                    End If
                Else
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessRemainingTime", VALUELib.ValueType.A, "0")
                End If

                If IsNumeric(lstString(1)) Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalStepTime", VALUELib.ValueType.A, lstString(1))
                Else
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalStepTime", VALUELib.ValueType.A, "0")
                End If

                If chamberConfig.IBE_Type = ConstEnum.AllChamberType.VEECO_IBE Or chamberConfig.Type = SystemModule.ModuleType.PVDA Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessRemainingTime", VALUELib.ValueType.A, value)
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-10-01</date>
        ''' </author>
        ''' <summary>
        ''' Get current ElapsedTime
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ElapsedTime() As String
            Get
                Return m_strElapsedTime
            End Get
            Set(ByVal value As String)

                ' Check and trigger "StepCompleted" event
                Dim strStepTime As String = value ' value in format StepTime/TotalStepTime
                Dim strStepTimeInProgress As String = String.Empty
                Dim strTotalStepTime As String = String.Empty
                If (strStepTime <> Nothing) AndAlso (strStepTime.Length > 0) Then
                    If strStepTime.IndexOf("/") >= 0 Then
                        strStepTimeInProgress = strStepTime.Substring(0, strStepTime.IndexOf("/"))
                        strTotalStepTime = strStepTime.Substring(strStepTime.IndexOf("/") + 1)
                    End If
                End If

                CheckValueForLog("ElapsedTime", m_strElapsedTime, value, False)
                Dim chamberConfig As SystemModule = Nothing
                chamberConfig = AVPLib.ContainerData.GetRobotConfig(Me.Name)
                If chamberConfig Is Nothing Then
                    Exit Property
                End If
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ProcessElapseTime
                If chamberConfig.IBE_Type = AllChamberType.VEECO_IBE Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessElapseTime", VALUELib.ValueType.A, value)
                Else
                    If IsNumeric(strStepTimeInProgress) Then
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessElapseTime", VALUELib.ValueType.A, strStepTimeInProgress)
                    Else
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessElapseTime", VALUELib.ValueType.A, "0")
                    End If
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current StepTime
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StepTime() As String
            Get
                Return m_strStepTime
            End Get
            Set(ByVal value As String)
                'IBE - PVD
                ' Check and trigger "StepCompleted" event
                Dim strStepTime As String = value ' value in format StepTime/TotalStepTime
                Dim strStepTimeInProgress As String = String.Empty
                Dim strTotalStepTime As String = String.Empty

                If (strStepTime <> Nothing) AndAlso (strStepTime.Length > 0) Then
                    If strStepTime.IndexOf("/") >= 0 Then
                        strStepTimeInProgress = strStepTime.Substring(0, strStepTime.IndexOf("/"))
                        strTotalStepTime = strStepTime.Substring(strStepTime.IndexOf("/") + 1)
                    End If
                End If

                Dim chamberConfig As SystemModule = Nothing
                chamberConfig = AVPLib.ContainerData.GetRobotConfig(Me.Name)
                If chamberConfig Is Nothing Then
                    Exit Property
                End If
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.StepTime
                ''if value is valid and chamber is PVD or AVP-IBE
                If (chamberConfig.IBE_Type = ConstEnum.AllChamberType.AVP_IBE OrElse
                    chamberConfig.Type = SystemModule.ModuleType.PVD4 OrElse
                    chamberConfig.Type = SystemModule.ModuleType.PVD5T OrElse
                    chamberConfig.Type = SystemModule.ModuleType.PVD) Then

                    If IsNumeric(strStepTimeInProgress) Then
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "StepTime", VALUELib.ValueType.A, strStepTimeInProgress)
                    Else
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "StepTime", VALUELib.ValueType.A, "0")
                    End If

                    If IsNumeric(strTotalStepTime) Then
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalStepTime", VALUELib.ValueType.A, strTotalStepTime)
                    Else
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalStepTime", VALUELib.ValueType.A, "0")
                    End If
                End If

                If chamberConfig.IBE_Type = ConstEnum.AllChamberType.VEECO_IBE Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "StepTime", VALUELib.ValueType.A, value)
                End If

                CheckValueForLog("StepTime", m_strStepTime, value, False)
            End Set
        End Property

        Public Property ProcessStep() As String
            Get
                Return m_strProcessStep
            End Get
            Set(ByVal value As String)

                CheckValueForLog("ProcessStep", m_strProcessStep, value, False)
                ''PVD
                Dim chamberConfig As SystemModule = Nothing
                chamberConfig = AVPLib.ContainerData.GetRobotConfig(Me.Name)
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ProcessCurrentStep
                Dim lstStep As String() = Split(value, "/")
                If lstStep.Length = 2 Then
                    If IsNumeric(lstStep(0)) Then
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessCurrentStep", VALUELib.ValueType.A, lstStep(0))
                    Else
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessCurrentStep", VALUELib.ValueType.A, "0")
                    End If

                    If IsNumeric(lstStep(1)) Then
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalProcessStep", VALUELib.ValueType.A, lstStep(1))
                    Else
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TotalProcessStep", VALUELib.ValueType.A, "0")
                    End If
                End If

                If chamberConfig IsNot Nothing AndAlso chamberConfig.IBE_Type = ConstEnum.AllChamberType.VEECO_IBE Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessCurrentStep", VALUELib.ValueType.A, value)
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Tran Cao Dua </name>
        '''    	<date> 2017-03-09</date>
        ''' </author>
        ''' <summary>
        ''' Step Complete.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StepCompleted() As Double
            Get
                Return m_dblStepCompleted
            End Get
            Set(ByVal value As Double)
                If (m_dblStepCompleted <> value) Then
                    If value > 0 Then
                        Business.AVPSecsGemLib.TriggerEvent(Me.Name, "StepCompleted")
                    End If
                    m_dblStepCompleted = value
                End If
            End Set
        End Property

        Public WriteOnly Property PressureMode() As EnumPressureMode
            Set(ByVal value As EnumPressureMode)
                m_enmPressureMode = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current IG equipment
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Property IG() As Double
            Get
                Return m_dblIG
            End Get
            Set(ByVal value As Double)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.IonGaugePressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "IG", VALUELib.ValueType.F4, value)

                CheckValueForLog("IG", m_dblIG, value, False)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current CG equipment
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
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.ConvectionGaugePressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CG", VALUELib.ValueType.F4, value)
                CheckValueForLog("CG", m_dblCG, value, False)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current IG status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IGStatus() As WorkingStatuses
            Get
                Return m_enmIGStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: PMX.IonGaugeStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "IGStatus", VALUELib.ValueType.U1, value)

                CheckValueForLog("IGStatus", m_enmIGStatus, value)
                UpdatePressureMode()
            End Set
        End Property

        Public Overridable Property ForelineValveStatus() As WorkingStatuses
            Get
                Return m_ForelineValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                CheckValueForLog("Foreline_Valve_Status", m_ForelineValveStatus, value)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ForelineValveStatus", VALUELib.ValueType.U1, value)
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
        Public Property ProcessPressure() As Double
            Get
                Return m_dblProcessPressure
            End Get
            Set(ByVal value As Double)
                CheckValueForLog("ProcessPressure", m_dblProcessPressure, value, False)
            End Set
        End Property

        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2019-04-10 </date>
        ''' </author>
        ''' <summary>
        ''' receive current recipe loop info 
        ''' with format = (current loop/total loop)
        ''' </summary>
        Public Property CurrentRecipeLoop() As String
            Get
                Return m_strCurrentRecipeLoop
            End Get
            Set(ByVal value As String)
                CheckValueForLog("CurrentRecipeLoop", m_strCurrentRecipeLoop, value)
            End Set
        End Property
#End Region

        Protected Sub UpdatePressureMode()
            If m_enmIGStatus = WorkingStatuses.On Then
                m_enmPressureMode = EnumPressureMode.IG
            Else
                m_enmPressureMode = EnumPressureMode.CG
            End If
        End Sub

        Protected Sub RaiseUpdatePressureEvent()
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("PressureMode")
                Dim values As ArrayList = New ArrayList()
                values.Add(m_enmPressureMode)

                Me.ChangeStatus(PropertyNames, values)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' UpdateWaferProcessTimeInRealTime
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Sub UpdateWaferProcessTimeInRealTime(ByVal strTotalTime As String)
            Try
                Dim listTime As String() = Split(strTotalTime, "/")
                If listTime.Length = 2 Then
                    If IsNumeric(listTime(0)) Then
                        Dim processTime As Double = Convert.ToDouble(listTime(0))
                        SyncLock m_countingProcessTimeLocker
                        For Each waferInfo As AVPWaferInfo In m_lstWaferInfo
                            If (waferInfo IsNot Nothing) AndAlso waferInfo.IsCountingWaferProcessTime Then
                                waferInfo.WaferProcessTime = waferInfo.PreWaferProcessTime + processTime
                            End If
                        Next
                        End SyncLock
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' BeginCountingWaferProcessTime
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Sub BeginCountingWaferProcessTime()
            Try
                If m_RunProcessStatus = enumProcessStatus.eStop Then
                    SyncLock m_countingProcessTimeLocker
                        ' Use double check process status.
                        If m_RunProcessStatus = enumProcessStatus.eStop Then
                            For Each waferItem As AVPWaferInfo In m_lstWaferInfo
                                If waferItem IsNot Nothing Then
                                    waferItem.BeginCountingWaferProcessTime()
                    End If
                Next
                        End If
                    End SyncLock
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>Hai Tran</author>
        ''' <date>2016-08-04</date>
        ''' <summary>
        ''' End counting wafer process time.
        '' </summary>
        Public Sub EndCountingWaferProcessTime()
            Try
                If m_RunProcessStatus = enumProcessStatus.eStop Then
                    SyncLock m_countingProcessTimeLocker
                        ' Use double check process status.
                        If m_RunProcessStatus = enumProcessStatus.eStop Then
                            For Each waferItem As AVPWaferInfo In m_lstWaferInfo
                                If waferItem IsNot Nothing Then
                                    waferItem.EndCountingWaferProcessTime()
                                End If
                            Next
                        End If
                    End SyncLock
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Public Function IsEquipmentFreeExceptSpecificIndex(ByVal idx As Integer) As Boolean
            Dim bRes = False
            Try
                If m_lstWaferInfo IsNot Nothing Then
                    For i As Integer = 0 To m_lstWaferInfo.Length - 1
                        If i + 1 = idx Then
                            Continue For
                        End If
                        If m_lstWaferInfo(i) IsNot Nothing AndAlso m_lstWaferInfo(i).WaferStatus <> enumWaferStatus.eWaferNone Then
                            Exit Try
                        End If
                    Next
                End If
                bRes = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bRes
        End Function

#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Change status Chamber
        ''' </summary>
        ''' <param name="PropertyNames"></param>
        ''' <param name="ReplyValues"></param>
        ''' <remarks></remarks>
        Public Overrides Sub ChangeStatus(ByVal PropertyNames As System.Collections.ArrayList, ByVal ReplyValues As System.Collections.ArrayList)
            AVPLib.Log.coreLogger.Info("Enter ChangeStatus")
            MyBase.ChangeStatus(PropertyNames, ReplyValues)
            ' Post Processing.
            If (PropertyNames.Count = 1) Then
                Dim propertyName As String = PropertyNames.Item(0)
                If (propertyName = ConstEnum.IG) Or (propertyName = ConstEnum.CG) Or (propertyName = ConstEnum.IGStatus) Then
                    RaiseUpdatePressureEvent()
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave ChangeStatus")
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
            Me.ControlStatus = ControlStatus
            Me.TransferSetPoint = TransferSetPoint
            Me.ConnectionStatus = ConnectionStatus
            Me.GEMModuleName = GEMModuleName
            Me.GEMModuleType = GEMModuleType
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CycleWaferCount", VALUELib.ValueType.F4, m_intPMWaferCount)
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, _
                   "ProcessModuleProcessingState", VALUELib.ValueType.U1, ConstEnum.ProcessModuleProcessingState.IDLE)
        End Sub
#End Region

        ''' CLEAR WAFER FLOW LOOP INFO
        Public Sub ClearLoopInfo()
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add("")
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("ChamberLoopInfo")
                Me.ChangeStatus(PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' CLEAR WAFER FLOW LOOP INFO
        Public Sub ChamberLoopInfo(ByVal CurrentLoopInfo As String)
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(CurrentLoopInfo)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("ChamberLoopInfo")
                Me.ChangeStatus(PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2020-12-21</date>
        ''' </author>
        ''' <summary>
        ''' Add Load Lock Warm Up
        ''' </summary>
        Public Sub AddLoadLockWarmUp(ByVal loadlock As String)
            Dim arr As ArrayList = New ArrayList
            Try
                If m_ListLoadLockWarmUp IsNot Nothing AndAlso Not m_ListLoadLockWarmUp.Contains(loadlock) Then
                    m_ListLoadLockWarmUp.Add(loadlock)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2020-12-21</date>
        ''' </author>
        ''' <summary>
        ''' Remove Load Lock Warm Up
        ''' </summary>
        Public Sub RemoveLoadLockWarmUp(ByVal loadlock As String)
            Dim arr As ArrayList = New ArrayList
            Try
                If m_ListLoadLockWarmUp IsNot Nothing AndAlso m_ListLoadLockWarmUp.Contains(loadlock) Then
                    m_ListLoadLockWarmUp.Remove(loadlock)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-25</date>
        ''' </author>
        ''' <summary>
        ''' Check data if changing
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Sub CheckValueForLog(ByVal strPropertyName As String, ByRef OldValue As Object, ByVal NewValue As Object, _
        Optional ByVal blnLogValue As Boolean = True)
            ' Dat N commented this code, it's not necessary any more.
            If OldValue <> NewValue Then
                OldValue = NewValue
                ' The log is too generic, it will not help user.
                If blnLogValue Then
                    AVPLib.Log.pmLogger.Debug(Utils.chamberID2ChamberName(Me.Name) + " " + strPropertyName + " changed with the new value: " + NewValue.ToString())
                    'ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeEvent, Utils.chamberID2ChamberName(Me.Name), strPropertyName + " changed with the new value: " + NewValue.ToString())
                End If
            End If
        End Sub

    End Class
End Namespace

