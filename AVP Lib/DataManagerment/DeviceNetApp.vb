Namespace DataManagerment
    Public Class DeviceNetApp
        Inherits Equipment
#Region "Class Constants & Variables"
        Private m_blnDeviceNetBus As WorkingStatuses

        Private m_blnSolenoidBlock1Com As WorkingStatuses
        Private m_blnSolenoidBlock2Com As WorkingStatuses

        Private m_blnRoughPumpMachine1CGStatus As WorkingStatuses
        Private m_dblRoughPumpMachine1CGPressure As Double
        Private m_blnRoughPumpMachine1CGCom As WorkingStatuses

        Private m_blnRoughPumpMachine2CGStatus As WorkingStatuses
        Private m_dblRoughPumpMachine2CGPressure As Double
        Private m_blnRoughPumpMachine2CGCom As WorkingStatuses

        Private m_blnLoadLockAIGStatus As WorkingStatuses
        Private m_dblLoadLockAIGPressure As Double
        Private m_blnLoadLockAIonCom As WorkingStatuses
        Private m_blnLoadLockAIGFilament As Double

        Private m_blnLoadLockACGStatus As WorkingStatuses
        Private m_dblLoadLockACGPressure As Double
        Private m_blnLoadLockACGCom As WorkingStatuses

        Private m_blnCassettesModuleIGStatus As WorkingStatuses
        Private m_dblCassettesModuleIGPressure As Double
        Private m_blnCassettesModuleIonCom As WorkingStatuses
        Private m_blnCassettesModuleIGFilament As Double

        Private m_blnCassettesModuleCGStatus As WorkingStatuses
        Private m_dblCassettesModuleCGPressure As Double
        Private m_blnCassettesModuleCGCom As WorkingStatuses

        Private m_blnLoadLockATurboForelineCGStatus As WorkingStatuses
        Private m_dblLoadLockATurboForelineCGPressure As Double
        Private m_blnLoadLockATurboForelineCGCom As WorkingStatuses

        Private m_blnCassettesModuleTurboForelineCGStatus As WorkingStatuses
        Private m_dblCassettesModuleTurboForelineCGPressure As Double
        Private m_blnCassettesModuleTurboForelineCGCom As WorkingStatuses

        Private m_blnCassettesModuleTurboForelineValve As WorkingStatuses

        Private m_blnLoadLockATurboForelineValve As WorkingStatuses

        Private m_blnLoadLockALLFastRough As WorkingStatuses

        Private m_blnCassettesModuleRough As WorkingStatuses

        Private m_blnLoadLockALLSlowRough As WorkingStatuses

        Private m_blnLoadLockALLFastVent As WorkingStatuses

        Private m_blnCassettesModuleVent As WorkingStatuses

        Private m_blnLoadLockALLSlowVent As WorkingStatuses

        Private m_blnLoadLockALLHiVac As WorkingStatuses

        Private m_blnCassettesModuleTMHiVac As WorkingStatuses

        Private m_blnRSTiCom As WorkingStatuses

        Private m_blnCassettesModuleSplitValve1OpenStatus As WorkingStatuses
        Private m_blnCassettesModuleSplitValve1CloseStatus As WorkingStatuses
        Private m_blnCassettesModuleSplitValve2OpenStatus As WorkingStatuses
        Private m_blnCassettesModuleSplitValve2CloseStatus As WorkingStatuses
        Private m_blnCassettesModuleSplitValve3OpenStatus As WorkingStatuses
        Private m_blnCassettesModuleSplitValve3CloseStatus As WorkingStatuses
        Private m_blnCassettesModuleSplitValve4OpenStatus As WorkingStatuses
        Private m_blnCassettesModuleSplitValve4CloseStatus As WorkingStatuses
        Private m_blnCassettesModuleSensorLLAStatus As WorkingStatuses
        Private m_blnCassettesModuleSensorPM1Status As WorkingStatuses
        Private m_blnCassettesModuleSensorPM2Status As WorkingStatuses
        Private m_blnCassettesModuleSensorPM3Status As WorkingStatuses
        Private m_blnLoadLockAHiVacValveCloseStatus As WorkingStatuses
        Private m_blnLoadLockAHiVacValveOpenStatus As WorkingStatuses
        Private m_blnCassettesModuleHiVacValveCloseStatus As WorkingStatuses
        Private m_blnCassettesModuleHiVacValveOpenStatus As WorkingStatuses
        Private m_blnAlarmStatus As WorkingStatuses
        Private m_blnAlarmRedStatus As WorkingStatuses
        Private m_blnAlarmGreenStatus As WorkingStatuses
        Private m_blnAlarmOrangeStatus As WorkingStatuses
        Private m_blnAlarmBlueStatus As WorkingStatuses
        Private m_blnCassettesModuleRoughPump1Status As WorkingStatuses
        Private m_blnCassettesModuleRoughPump2Status As WorkingStatuses
        Private m_blnTMPumpPackageTurboStatus As WorkingStatuses
        Private m_blnLLAPumpPackageTurboStatus As WorkingStatuses
        Private m_blnCassettesModuleProcess_Complete_Chime As WorkingStatuses
        Private m_blnTMPumpPackageTurboUptoSpeed As WorkingStatuses
        Private m_blnLLAPumpPackageTurboUptoSpeed As WorkingStatuses

#End Region

#Region "Property"
        Public Property DeviceNetBus() As WorkingStatuses
            Get
                Return m_blnDeviceNetBus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnDeviceNetBus = value
            End Set
        End Property

        Public Property SolenoidBlock1Com() As WorkingStatuses
            Get
                Return m_blnSolenoidBlock1Com
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnSolenoidBlock1Com = value
            End Set
        End Property

        Public Property SolenoidBlock2Com() As WorkingStatuses
            Get
                Return m_blnSolenoidBlock2Com
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnSolenoidBlock2Com = value
            End Set
        End Property

        Public Property RSTiCom() As WorkingStatuses
            Get
                Return m_blnRSTiCom
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnRSTiCom = value
            End Set
        End Property

        Public Property RoughPumpMachine1CGStatus() As WorkingStatuses
            Get
                Return m_blnRoughPumpMachine1CGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnRoughPumpMachine1CGStatus = value
                AVPLib.Driver.DriverUtility.UpdateCGRelay("RoughPumpMachine1", m_blnRoughPumpMachine1CGStatus)
            End Set
        End Property

        Public Property RoughPumpMachine1CGPressure() As Double
            Get
                Return m_dblRoughPumpMachine1CGPressure
            End Get
            Set(ByVal value As Double)
                m_dblRoughPumpMachine1CGPressure = value
                AVPLib.Driver.DriverUtility.UpdateCGPressure("RoughPumpMachine1", m_dblRoughPumpMachine1CGPressure)
            End Set
        End Property

        Public Property RoughPumpMachine1CGCom() As WorkingStatuses
            Get
                Return m_blnRoughPumpMachine1CGCom
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnRoughPumpMachine1CGCom = value
                AVPLib.Driver.DriverUtility.UpdateCGCommunication("RoughPumpMachine1", m_blnRoughPumpMachine1CGCom)
            End Set
        End Property

        Public Property RoughPumpMachine2CGStatus() As WorkingStatuses
            Get
                Return m_blnRoughPumpMachine2CGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnRoughPumpMachine2CGStatus = value
                AVPLib.Driver.DriverUtility.UpdateCGRelay("RoughPumpMachine2", m_blnRoughPumpMachine2CGStatus)
            End Set
        End Property

        Public Property RoughPumpMachine2CGPressure() As Double
            Get
                Return m_dblRoughPumpMachine2CGPressure
            End Get
            Set(ByVal value As Double)
                m_dblRoughPumpMachine2CGPressure = value
                AVPLib.Driver.DriverUtility.UpdateCGPressure("RoughPumpMachine2", m_dblRoughPumpMachine2CGPressure)
            End Set
        End Property

        Public Property RoughPumpMachine2CGCom() As WorkingStatuses
            Get
                Return m_blnRoughPumpMachine2CGCom
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnRoughPumpMachine2CGCom = value
                AVPLib.Driver.DriverUtility.UpdateCGCommunication("RoughPumpMachine2", m_blnRoughPumpMachine2CGCom)
            End Set
        End Property

        Public Property LoadLockAIGStatus() As WorkingStatuses
            Get
                Return m_blnLoadLockAIGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockAIGStatus = value
                AVPLib.Driver.DriverUtility.UpdateIGStatus("LoadLockA", m_blnLoadLockAIGStatus)
            End Set
        End Property

        Public Property LoadLockAIGPressure() As Double
            Get
                Return m_dblLoadLockAIGPressure
            End Get
            Set(ByVal value As Double)
                m_dblLoadLockAIGPressure = value
                AVPLib.Driver.DriverUtility.UpdateIGPressure("LoadLockA", m_dblLoadLockAIGPressure)
            End Set
        End Property

        Public Property LoadLockAIonCom() As WorkingStatuses
            Get
                Return m_blnLoadLockAIonCom
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockAIonCom = value
                AVPLib.Driver.DriverUtility.UpdateIGCommunication("LoadLockA", m_blnLoadLockAIonCom)
            End Set
        End Property

        Public Property LoadLockAIGFilament() As Double
            Get
                Return m_blnLoadLockAIGFilament
            End Get
            Set(ByVal value As Double)
                m_blnLoadLockAIGFilament = value
                AVPLib.Driver.DriverUtility.UpdateSwitchIGFilament("LoadLockA", m_blnLoadLockAIGFilament)
            End Set
        End Property

        Public Property LoadLockACGStatus() As WorkingStatuses
            Get
                Return m_blnLoadLockACGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockACGStatus = value
                AVPLib.Driver.DriverUtility.UpdateCGRelay("LoadLockA", m_blnLoadLockACGStatus)
            End Set
        End Property

        Public Property LoadLockACGPressure() As Double
            Get
                Return m_dblLoadLockACGPressure
            End Get
            Set(ByVal value As Double)
                m_dblLoadLockACGPressure = value
                AVPLib.Driver.DriverUtility.UpdateCGPressure("LoadLockA", m_dblLoadLockACGPressure)
            End Set
        End Property

        Public Property LoadLockACGCom() As WorkingStatuses
            Get
                Return m_blnLoadLockACGCom
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockACGCom = value
                AVPLib.Driver.DriverUtility.UpdateCGCommunication("LoadLockA", m_blnLoadLockACGCom)
            End Set
        End Property

        Public Property CassettesModuleIGStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleIGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleIGStatus = value
                AVPLib.Driver.DriverUtility.UpdateIGStatus("CassettesModule", m_blnCassettesModuleIGStatus)
            End Set
        End Property

        Public Property CassettesModuleIGPressure() As Double
            Get
                Return m_dblCassettesModuleIGPressure
            End Get
            Set(ByVal value As Double)
                m_dblCassettesModuleIGPressure = value
                AVPLib.Driver.DriverUtility.UpdateIGPressure("CassettesModule", m_dblCassettesModuleIGPressure)
            End Set
        End Property

        Public Property CassettesModuleIonCom() As WorkingStatuses
            Get
                Return m_blnCassettesModuleIonCom
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleIonCom = value
                AVPLib.Driver.DriverUtility.UpdateIGCommunication("CassettesModule", m_blnCassettesModuleIonCom)
            End Set
        End Property

        Public Property CassettesModuleIGFilament() As Double
            Get
                Return m_blnCassettesModuleIGFilament
            End Get
            Set(ByVal value As Double)
                m_blnCassettesModuleIGFilament = value
                AVPLib.Driver.DriverUtility.UpdateSwitchIGFilament("CassettesModule", m_blnCassettesModuleIGFilament)
            End Set
        End Property

        Public Property CassettesModuleCGStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleCGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleCGStatus = value
                AVPLib.Driver.DriverUtility.UpdateCGRelay("CassettesModule", m_blnCassettesModuleCGStatus)
            End Set
        End Property

        Public Property CassettesModuleCGPressure() As Double
            Get
                Return m_dblCassettesModuleCGPressure
            End Get
            Set(ByVal value As Double)
                m_dblCassettesModuleCGPressure = value
                AVPLib.Driver.DriverUtility.UpdateCGPressure("CassettesModule", m_dblCassettesModuleCGPressure)
            End Set
        End Property

        Public Property CassettesModuleCGCom() As WorkingStatuses
            Get
                Return m_blnCassettesModuleCGCom
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleCGCom = value
                AVPLib.Driver.DriverUtility.UpdateCGCommunication("CassettesModule", m_blnCassettesModuleCGCom)
            End Set
        End Property

        Public Property LoadLockATurboForelineCGStatus() As WorkingStatuses
            Get
                Return m_blnLoadLockATurboForelineCGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockATurboForelineCGStatus = value
                AVPLib.Driver.DriverUtility.UpdateTurboForeLineCGRelay("LoadLockA", m_blnLoadLockATurboForelineCGStatus)
            End Set
        End Property

        Public Property LoadLockATurboForelineCGPressure() As Double
            Get
                Return m_dblLoadLockATurboForelineCGPressure
            End Get
            Set(ByVal value As Double)
                m_dblLoadLockATurboForelineCGPressure = value
                AVPLib.Driver.DriverUtility.UpdateTurboForeLineCGPressure("LoadLockA", m_dblLoadLockATurboForelineCGPressure)
            End Set
        End Property

        Public Property LoadLockATurboForelineCGCom() As WorkingStatuses
            Get
                Return m_blnLoadLockATurboForelineCGCom
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockATurboForelineCGCom = value
                AVPLib.Driver.DriverUtility.UpdateTurboForelineCG_Communication("LoadLockA", m_blnLoadLockATurboForelineCGCom)
            End Set
        End Property

        Public Property CassettesModuleTurboForelineCGStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleTurboForelineCGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleTurboForelineCGStatus = value
                AVPLib.Driver.DriverUtility.UpdateTurboForeLineCGRelay("CassettesModule", m_blnCassettesModuleTurboForelineCGStatus)
            End Set
        End Property

        Public Property CassettesModuleTurboForelineCGPressure() As Double
            Get
                Return m_dblCassettesModuleTurboForelineCGPressure
            End Get
            Set(ByVal value As Double)
                m_dblCassettesModuleTurboForelineCGPressure = value
                AVPLib.Driver.DriverUtility.UpdateTurboForeLineCGPressure("CassettesModule", m_dblCassettesModuleTurboForelineCGPressure)
            End Set
        End Property

        Public Property CassettesModuleTurboForelineCGCom() As WorkingStatuses
            Get
                Return m_blnCassettesModuleTurboForelineCGCom
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleTurboForelineCGCom = value
                AVPLib.Driver.DriverUtility.UpdateTurboForelineCG_Communication("CassettesModule", m_blnCassettesModuleTurboForelineCGCom)
            End Set
        End Property

        Public Property CassettesModuleTurboForelineValve() As WorkingStatuses
            Get
                Return m_blnCassettesModuleTurboForelineValve
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleTurboForelineValve = value
                AVPLib.Driver.DriverUtility.UpdateTurboForeLineValveStatus("CassettesModule", m_blnCassettesModuleTurboForelineValve)
            End Set
        End Property

        Public Property LoadLockATurboForelineValve() As WorkingStatuses
            Get
                Return m_blnLoadLockATurboForelineValve
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockATurboForelineValve = value
                AVPLib.Driver.DriverUtility.UpdateTurboForeLineValveStatus("LoadLockA", m_blnLoadLockATurboForelineValve)
            End Set
        End Property

        Public Property LoadLockALLFastRough() As WorkingStatuses
            Get
                Return m_blnLoadLockALLFastRough
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockALLFastRough = value
                AVPLib.Driver.DriverUtility.UpdateRoughValveStatus("LoadLockA.LLFastRough", "LoadLockA", m_blnLoadLockALLFastRough)
            End Set
        End Property

        Public Property CassettesModuleRough() As WorkingStatuses
            Get
                Return m_blnCassettesModuleRough
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleRough = value
                AVPLib.Driver.DriverUtility.UpdateRoughValveStatus("CassettesModule.Rough", "CassettesModule", m_blnCassettesModuleRough)
            End Set
        End Property

        Public Property LoadLockALLSlowRough() As WorkingStatuses
            Get
                Return m_blnLoadLockALLSlowRough
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockALLSlowRough = value
                AVPLib.Driver.DriverUtility.UpdateRoughValveStatus("LoadLockA.LLSlowRough", "LoadLockA", m_blnLoadLockALLSlowRough)
            End Set
        End Property

        Public Property LoadLockALLFastVent() As WorkingStatuses
            Get
                Return m_blnLoadLockALLFastVent
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockALLFastVent = value
                AVPLib.Driver.DriverUtility.UpdateVentValveStatus("LoadLockA.LLFastVent", "LoadLockA", m_blnLoadLockALLFastVent)
            End Set
        End Property

        Public Property CassettesModuleVent() As WorkingStatuses
            Get
                Return m_blnCassettesModuleVent
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleVent = value
                AVPLib.Driver.DriverUtility.UpdateVentValveStatus("CassettesModule.Vent", "CassettesModule", m_blnCassettesModuleVent)
            End Set
        End Property

        Public Property LoadLockALLSlowVent() As WorkingStatuses
            Get
                Return m_blnLoadLockALLSlowVent
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockALLSlowVent = value
                AVPLib.Driver.DriverUtility.UpdateVentValveStatus("LoadLockA.LLSlowVent", "LoadLockA", m_blnLoadLockALLSlowVent)
            End Set
        End Property

        Public Property CassettesModuleSplitValve1OpenStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSplitValve1OpenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSplitValve1OpenStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SplitValve1OpenStatus", m_blnCassettesModuleSplitValve1OpenStatus)
            End Set
        End Property

        Public Property CassettesModuleSplitValve1CloseStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSplitValve1CloseStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSplitValve1CloseStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SplitValve1CloseStatus", m_blnCassettesModuleSplitValve1CloseStatus)
            End Set
        End Property

        Public Property CassettesModuleSplitValve2OpenStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSplitValve2OpenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSplitValve2OpenStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SplitValve2OpenStatus", m_blnCassettesModuleSplitValve2OpenStatus)
            End Set
        End Property

        Public Property CassettesModuleSplitValve2CloseStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSplitValve2CloseStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSplitValve2CloseStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SplitValve2CloseStatus", m_blnCassettesModuleSplitValve2CloseStatus)
            End Set
        End Property

        Public Property CassettesModuleSplitValve3OpenStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSplitValve3OpenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSplitValve3OpenStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SplitValve3OpenStatus", m_blnCassettesModuleSplitValve3OpenStatus)
            End Set
        End Property

        Public Property CassettesModuleSplitValve3CloseStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSplitValve3CloseStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSplitValve3CloseStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SplitValve3CloseStatus", m_blnCassettesModuleSplitValve3CloseStatus)
            End Set
        End Property

        Public Property CassettesModuleSplitValve4OpenStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSplitValve4OpenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSplitValve4OpenStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SplitValve4OpenStatus", m_blnCassettesModuleSplitValve4OpenStatus)
            End Set
        End Property

        Public Property CassettesModuleSplitValve4CloseStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSplitValve4CloseStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSplitValve4CloseStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SplitValve4CloseStatus", m_blnCassettesModuleSplitValve4CloseStatus)
            End Set
        End Property

        Public Property CassettesModuleSensorLLAStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSensorLLAStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSensorLLAStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SensorLLAStatus", m_blnCassettesModuleSensorLLAStatus)
            End Set
        End Property

        Public Property CassettesModuleSensorPM1Status() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSensorPM1Status
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSensorPM1Status = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SensorPM1Status", m_blnCassettesModuleSensorPM1Status)
            End Set
        End Property

        Public Property CassettesModuleSensorPM2Status() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSensorPM2Status
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSensorPM2Status = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SensorPM2Status", m_blnCassettesModuleSensorPM2Status)
            End Set
        End Property

        Public Property CassettesModuleSensorPM3Status() As WorkingStatuses
            Get
                Return m_blnCassettesModuleSensorPM3Status
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleSensorPM3Status = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "SensorPM3Status", m_blnCassettesModuleSensorPM3Status)
            End Set
        End Property

        Public Property LoadLockAHiVacValveCloseStatus() As WorkingStatuses
            Get
                Return m_blnLoadLockAHiVacValveCloseStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockAHiVacValveCloseStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("LoadLockA", "HiVacValveCloseStatus", m_blnLoadLockAHiVacValveCloseStatus)
            End Set
        End Property

        Public Property LoadLockAHiVacValveOpenStatus() As WorkingStatuses
            Get
                Return m_blnLoadLockAHiVacValveOpenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLoadLockAHiVacValveOpenStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("LoadLockA", "HiVacValveOpenStatus", m_blnLoadLockAHiVacValveOpenStatus)
            End Set
        End Property

        Public Property CassettesModuleHiVacValveCloseStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleHiVacValveCloseStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleHiVacValveCloseStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "HiVacValveCloseStatus", m_blnCassettesModuleHiVacValveCloseStatus)
            End Set
        End Property

        Public Property CassettesModuleHiVacValveOpenStatus() As WorkingStatuses
            Get
                Return m_blnCassettesModuleHiVacValveOpenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleHiVacValveOpenStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "HiVacValveOpenStatus", m_blnCassettesModuleHiVacValveOpenStatus)
            End Set
        End Property

        Public Property AlarmStatus() As WorkingStatuses
            Get
                Return m_blnAlarmStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnAlarmStatus = value
            End Set
        End Property

        Public Property AlarmRedStatus() As WorkingStatuses
            Get
                Return m_blnAlarmRedStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnAlarmRedStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("Alarm", "RedStatus", m_blnAlarmRedStatus)
            End Set
        End Property

        Public Property AlarmGreenStatus() As WorkingStatuses
            Get
                Return m_blnAlarmGreenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnAlarmGreenStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("Alarm", "GreenStatus", m_blnAlarmGreenStatus)
            End Set
        End Property

        Public Property AlarmOrangeStatus() As WorkingStatuses
            Get
                Return m_blnAlarmOrangeStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnAlarmOrangeStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("Alarm", "OrangeStatus", m_blnAlarmOrangeStatus)
            End Set
        End Property

        Public Property AlarmBlueStatus() As WorkingStatuses
            Get
                Return m_blnAlarmBlueStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnAlarmBlueStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("Alarm", "BlueStatus", m_blnAlarmBlueStatus)
            End Set
        End Property

        Public Property CassettesModuleRoughPump1Status() As WorkingStatuses
            Get
                Return m_blnCassettesModuleRoughPump1Status
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleRoughPump1Status = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "RoughPump1Status", m_blnCassettesModuleRoughPump1Status)
            End Set
        End Property

        Public Property CassettesModuleRoughPump2Status() As WorkingStatuses
            Get
                Return m_blnCassettesModuleRoughPump2Status
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleRoughPump2Status = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "RoughPump2Status", m_blnCassettesModuleRoughPump2Status)
            End Set
        End Property

        Public Property TMPumpPackageTurboStatus() As WorkingStatuses
            Get
                Return m_blnTMPumpPackageTurboStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnTMPumpPackageTurboStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("TMPumpPackage", "TurboStatus", CBool(m_blnTMPumpPackageTurboStatus))
            End Set
        End Property

        Public Property LLAPumpPackageTurboStatus() As WorkingStatuses
            Get
                Return m_blnLLAPumpPackageTurboStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLLAPumpPackageTurboStatus = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("LLAPumpPackage", "TurboStatus", CBool(m_blnLLAPumpPackageTurboStatus))
            End Set
        End Property

        Public Property CassettesModuleProcess_Complete_Chime() As WorkingStatuses
            Get
                Return m_blnCassettesModuleProcess_Complete_Chime
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCassettesModuleProcess_Complete_Chime = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("CassettesModule", "Process_Complete_Chime", m_blnCassettesModuleProcess_Complete_Chime)
            End Set
        End Property

        Public Property TMPumpPackageTurboUptoSpeed() As WorkingStatuses
            Get
                Return m_blnTMPumpPackageTurboUptoSpeed
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnTMPumpPackageTurboUptoSpeed = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("TMPumpPackage", "TurboUptoSpeed", CBool(m_blnTMPumpPackageTurboUptoSpeed))
            End Set
        End Property

        Public Property LLAPumpPackageTurboUptoSpeed() As WorkingStatuses
            Get
                Return m_blnLLAPumpPackageTurboUptoSpeed
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnLLAPumpPackageTurboUptoSpeed = value
                AVPLib.Driver.DriverUtility.UpdateDataStatus("LLAPumpPackage", "TurboUptoSpeed", CBool(m_blnLLAPumpPackageTurboUptoSpeed))
            End Set
        End Property
#End Region

    End Class
End Namespace

