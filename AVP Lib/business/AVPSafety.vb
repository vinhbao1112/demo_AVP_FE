Imports AVPLib.DataManagerment
Imports AVPLib.ConstEnum
Imports System.IO
Imports System.Xml
Namespace Business
    Public Class AVPSafety
        Inherits SuspendableThread

        Protected Overrides Sub OnDoWork()
            AVPLib.Log.schedulerLogger.Info("Enter OnDoWork")
            AVPLib.Log.schedulerLogger.Debug("A THREAD FOR SAFETY MANAGER.")
            Try
                Const sleep_At_Startup As Integer = 20000
                If (SleepButAlertabletoTerminateRequest(sleep_At_Startup)) Then
                    Exit Sub
                End If

                ' LLA
                Dim objLLA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())

                Dim objLLAPumpPackageCtrl As Business.PumpPackageController = Nothing
                If RobotConfigurationValues.LLA_CRYO_VISIBLE OrElse RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                    objLLAPumpPackageCtrl = Business.ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString())
                End If
                Dim blLLACommOK As Boolean = False
                Dim blLLATurboOK As Boolean = False
                Dim blLLAVacSwitchOK As Boolean = False
                Dim blLLATurboCGRelayOK As Boolean = False
                Dim blLLARelayMPOK As Boolean = False


                Dim objLLAController As LoadLockController = ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString())
                ' TM
                Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())

                Dim objTMPumpPackageCtrl As Business.PumpPackageController = Nothing
                If RobotConfigurationValues.TMCRYO_VISIBLE OrElse RobotConfigurationValues.TMTURBO_VISIBLE Then
                    objTMPumpPackageCtrl = Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
                End If
                Dim blTMCommOK As Boolean = False
                Dim blTMTurboOK As Boolean = False
                Dim blTMVacSwitchOK As Boolean = False
                Dim blTMTurboCGRelayOK As Boolean = False
                Dim blTMRelayMPOK As Boolean = False

                Dim objTMController As TMController = ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString())
                Dim blShareRelayMPOK As Boolean = False

                ' MAIN LOOP.
                While (False = HasTerminateRequest())
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()

                    If (awokenByTerminate) Then
                        Exit While
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''                            LLA Safety Interlock During Process.                        '''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If (objLLA IsNot Nothing) AndAlso (objLLAPumpPackageCtrl IsNot Nothing) Then
                        Dim strError As String = String.Empty

                        ' Check turbo communication...
                        Dim bComCurrentStatus As Boolean = objLLAPumpPackageCtrl.IsCommunicationOK
                        If (blLLACommOK <> bComCurrentStatus) AndAlso (False = bComCurrentStatus) Then
                            strError = objLLAPumpPackageCtrl.DisplayName & " communication is disconnected."
                            AVPLib.Log.schedulerLogger.Error(strError)

                            'ThrowAlarm and Action safety Close hivac and off IG
                            If Not String.IsNullOrEmpty(strError) Then
                                LLAProcessSafetyInterlock(strError, False)
                                strError = String.Empty
                            End If
                        End If
                        blLLACommOK = bComCurrentStatus

                        'Check turbo up to speed
                        If String.IsNullOrEmpty(strError) Then
                            Dim strErrorMsg As String = String.Empty
                            Dim bTurboCurrentStatus As Boolean = objLLAPumpPackageCtrl.IsPumpPackageOK(strErrorMsg)
                            If (blLLATurboOK <> bTurboCurrentStatus) AndAlso (False = bTurboCurrentStatus) Then
                                strError = strErrorMsg
                            End If
                            blLLATurboOK = bTurboCurrentStatus
                            'turn off IG and reset error message
                            If Not String.IsNullOrEmpty(strError) Then
                                objLLAController.TurnOffIG(m_terminateEvent)
                                AVPLib.Log.avpLogger.Error(strError)
                                ' Reset error (error is processed).
                                strError = String.Empty
                            End If
                        End If

                        'Check CG relay LLA
                        If String.IsNullOrEmpty(strError) Then
                            Dim bLLACG As Boolean = (Not objLLAController.IsLLHiVacCloseCond() AndAlso objLLA.VacSwitchStatus <> Equipment.WorkingStatuses.On)
                            Dim bVacSwitchCurrent As Boolean = IIf(objLLAController.IsLLCGDisconnected() OrElse bLLACG, True, False)

                            If (blLLAVacSwitchOK <> bVacSwitchCurrent) AndAlso bVacSwitchCurrent Then
                                strError = String.Format(ContainerData.GetMessageText("VacSwitch_FB"), ConstEnum.LoadLockA_STR)
                                strError = IIf(objLLAController.IsLLCGDisconnected(), "LLA CG is disconnected.", strError)
                                'ThrowAlarm and Action safety Close hivac and off IG
                                If Not String.IsNullOrEmpty(strError) Then
                                    LLAProcessSafetyInterlock(strError, False)
                                    strError = String.Empty
                                End If
                            End If
                            blLLAVacSwitchOK = bVacSwitchCurrent
                        End If

                        'Check Turbo Foreline CG relay LLA
                        If (String.IsNullOrEmpty(strError)) Then
                            Dim blCurrentLLATurboCGRelay As Boolean = IIf(objLLAController.IsLLTurboForelineCGDisconnected() OrElse objLLA.TurboForelineCGRelay <> Equipment.WorkingStatuses.On, True, False)
                            If (blLLATurboCGRelayOK <> blCurrentLLATurboCGRelay AndAlso blCurrentLLATurboCGRelay AndAlso RobotConfigurationValues.LLA_TURBO_VISIBLE) Then
                                strError = String.Format(ContainerData.GetMessageText("TurboForelineCGRelay_FB"), ConstEnum.LoadLockA_STR)
                                strError = IIf(objLLAController.IsLLTurboForelineCGDisconnected(), "LLA Turbo Foreline CG is disconnected.", strError)
                                'ThrowAlarm and Action safety Close hivac and off IG
                                If Not String.IsNullOrEmpty(strError) Then
                                    LLAProcessSafetyInterlock(strError, True)
                                    strError = String.Empty
                                End If
                            End If
                            blLLATurboCGRelayOK = blCurrentLLATurboCGRelay
                        End If

                        'LLA Check communication and Relay MP
                        If (String.IsNullOrEmpty(strError)) Then
                            If objLLAController.NameLLMechanicalPump().ToUpper() <> objTMController.NameTMMechanicalPump().ToUpper() Then
                                Dim bLLAForline As Boolean = objLLAController.IsLLTurboForelineValveOpenCond() AndAlso objLLAController.IsTurboForelineCGRealyOnCond()
                                If bLLAForline Then
                                    Dim bLLAMPRelay As Boolean = objLLAController.IsLLFastRoughValveCloseCond() AndAlso objLLAController.IsLLSoftRoughValveCloseCond() AndAlso objLLAController.IsLLMechanicalPumpCGRelayOff()
                                    Dim blCurrentLLAMPCGRelay As Boolean = IIf(objLLAController.IsLLMechanicalPumpCGDisconnected() OrElse bLLAMPRelay, True, False)

                                    If (blLLARelayMPOK <> blCurrentLLAMPCGRelay AndAlso blCurrentLLAMPCGRelay) Then
                                        strError = String.Format(ContainerData.GetMessageText("MechanicalPumpCGRelay_FB"), ConstEnum.LoadLockA_STR)
                                        'objLLAController.ThrowAlarm(strError & " Close Foreline.")
                                    End If
                                    blLLARelayMPOK = blCurrentLLAMPCGRelay

                                    'Action Close Foreline and reset error message
                                    If Not String.IsNullOrEmpty(strError) Then
                                        objLLAController.CloseForelineValve(m_terminateEvent)
                                        AVPLib.Log.avpLogger.Error(strError)
                                        ' Reset error (error is processed).
                                        strError = String.Empty
                                    End If
                                End If
                            End If
                        End If

                        '' Not Is Rough Only Mode
                        If Not String.IsNullOrEmpty(strError) AndAlso Not objLLA.IsRoughOnlyMode Then
                            Dim objTurbo As Turbo = Nothing
                            If objLLA.IsTurboInstalled Then
                                objTurbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAPumpPackage.ToString)
                            End If

                            If (objLLA.IsHivacInstalled AndAlso objLLA.HiVacValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Or
                            (objTurbo IsNot Nothing AndAlso ((objTurbo.TurboStatus AndAlso objLLA.TurboForelineCGRelay = Equipment.WorkingStatuses.Off) OrElse
                            (objTurbo.TurboUptoSpeed AndAlso Not objLLA.IsHivacInstalled))) Or
                            (objLLA.IGStatus = DataManagerment.Equipment.WorkingStatuses.On) Then

                                If Not objLLA.IsHivacInstalled AndAlso objTurbo IsNot Nothing Then
                                    objLLAController.ThrowAlarm(strError & " Turn Off Turbo and Turn Off IG.")
                                    If (objLLAController IsNot Nothing) Then
                                        objLLAController.ProcessSafetyInterlock(True, m_terminateEvent)
                                    End If
                                Else
                                    objLLAController.ThrowAlarm(strError & " Close Hivac and Turn Off IG.")
                                    If (objLLAController IsNot Nothing) Then
                                        objLLAController.ProcessSafetyInterlock(False, m_terminateEvent)
                                    End If
                                End If

                            End If
                        End If
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''            TM Safety Interlock During Process.                       '''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If (objTM IsNot Nothing) AndAlso (objTMPumpPackageCtrl IsNot Nothing) Then
                        'Safety Turbo communication
                        Dim strError As String = String.Empty

                        'Check Turbo Communication
                        Dim bCurrentCommStatus As Boolean = objTMPumpPackageCtrl.IsCommunicationOK
                        If (blTMCommOK <> bCurrentCommStatus) AndAlso (False = bCurrentCommStatus) Then
                            strError = objTMPumpPackageCtrl.DisplayName & " Communication is disconnected."
                            AVPLib.Log.schedulerLogger.Error(strError)

                            'ThrowAlarm and Action Close Hivac and off IG
                            If Not String.IsNullOrEmpty(strError) Then
                                TMProcessSafetyInterlock(strError, False)
                                strError = String.Empty
                            End If
                        End If
                        blTMCommOK = bCurrentCommStatus

                        'Check turbo up to speed
                        If String.IsNullOrEmpty(strError) Then
                            Dim strErrorMsg As String = String.Empty
                            Dim bCurrentTurboStatus = objTMPumpPackageCtrl.IsPumpPackageOK(strErrorMsg)
                            If (blTMTurboOK <> bCurrentTurboStatus) AndAlso (False = bCurrentTurboStatus) Then
                                strError = strErrorMsg
                            End If
                            blTMTurboOK = bCurrentTurboStatus

                            'Turn Off IG and reset error message
                            If Not String.IsNullOrEmpty(strError) Then
                                objTMController.TurnOffIG(m_terminateEvent)
                                AVPLib.Log.avpLogger.Error(strError)
                                ' Reset error (error is processed).
                                strError = String.Empty
                            End If
                        End If

                        'Check Safety TM CG relay
                        If String.IsNullOrEmpty(strError) Then
                            Dim bTMCG As Boolean = (Not objTMController.IsTMHivacCloseCond() AndAlso objTM.VacSwitchStatus <> Equipment.WorkingStatuses.On)
                            Dim bCurrentVac As Boolean = IIf(objTMController.IsTMCGDisconnected() OrElse bTMCG, True, False)

                            If (blTMVacSwitchOK <> bCurrentVac) AndAlso bCurrentVac Then
                                strError = String.Format(ContainerData.GetMessageText("VacSwitch_FB"), AVPLib.ConstEnum.TM_STR)
                                strError = IIf(objTMController.IsTMCGDisconnected(), "TM CG is disconnected.", strError)

                                'ThrowAlarm and Action Close Hivac and off IG
                                If Not String.IsNullOrEmpty(strError) Then
                                    TMProcessSafetyInterlock(strError, False)
                                    strError = String.Empty
                                End If
                            End If
                            blTMVacSwitchOK = bCurrentVac
                        End If

                        'Check Safety turbo Foreline Relay
                        If (String.IsNullOrEmpty(strError)) Then
                            Dim blCurrentTMTurboCGRelay As Boolean = IIf(objTMController.IsTMTurboForelineCGDisconnected() OrElse objTM.TurboForelineCGRelay <> Equipment.WorkingStatuses.On, True, False)
                            If (blTMTurboCGRelayOK <> blCurrentTMTurboCGRelay AndAlso blCurrentTMTurboCGRelay AndAlso RobotConfigurationValues.TMTURBO_VISIBLE) Then
                                strError = String.Format(ContainerData.GetMessageText("TurboForelineCGRelay_FB"), ConstEnum.TM_STR)
                                strError = IIf(objTMController.IsTMTurboForelineCGDisconnected(), "TM Turbo Foreine CG is disconnected.", strError)
                                'ThrowAlarm and Action Close Hivac and off IG
                                If Not String.IsNullOrEmpty(strError) Then
                                    TMProcessSafetyInterlock(strError, True)
                                    strError = String.Empty
                                End If
                            End If
                            blTMTurboCGRelayOK = blCurrentTMTurboCGRelay
                        End If

                        'TM Check communication and Relay MP
                        If (String.IsNullOrEmpty(strError)) Then
                            'TM check MP when not share Pump
                            If objLLAController.NameLLMechanicalPump().ToUpper() <> objTMController.NameTMMechanicalPump().ToUpper() Then
                                Dim bTMMPRelay As Boolean = objTM.FastRoughValveStatus <> Equipment.WorkingStatuses.On AndAlso objTMController.IsTMMechanicalPumpCGRelayOff()
                                Dim blCurrentTMMPCGRelay As Boolean = IIf(objTMController.IsTMMechanicalPumpCGDisconnected() OrElse bTMMPRelay, True, False)

                                'is check rough <> open and CG relay off
                                If (blTMRelayMPOK <> blCurrentTMMPCGRelay AndAlso blCurrentTMMPCGRelay) Then
                                    strError = String.Format(ContainerData.GetMessageText("MechanicalPumpCGRelay_FB"), ConstEnum.TM_STR)
                                    'objTMController.ThrowAlarm(strError & " Close Foreline.")
                                End If
                                blTMRelayMPOK = blCurrentTMMPCGRelay

                                'Close Foreline and reset error message
                                If Not String.IsNullOrEmpty(strError) Then
                                    objTMController.CloseTMTurboForeline(m_terminateEvent)
                                    AVPLib.Log.avpLogger.Error(strError)
                                    ' Reset error (error is processed).
                                    strError = String.Empty
                                End If
                            End If

                        End If
                    End If

                    ' check MP when TM and Load Lock share Pump
                    If (objTM IsNot Nothing) AndAlso (objLLA IsNot Nothing) Then
                        Dim strError As String = String.Empty
                        If objLLAController.NameLLMechanicalPump().ToUpper() = objTMController.NameTMMechanicalPump().ToUpper() Then
                            'is LLA relay MP
                            Dim bLLAMPRelay As Boolean = objLLAController.IsLLFastRoughValveCloseCond() AndAlso objLLAController.IsLLSoftRoughValveCloseCond() AndAlso objLLAController.IsLLMechanicalPumpCGRelayOff()
                            Dim blCurrentLLAMPCGRelay As Boolean = IIf(objLLAController.IsLLMechanicalPumpCGDisconnected() OrElse bLLAMPRelay, True, False)

                            'is TM relay MP
                            Dim bTMMPRelay As Boolean = objTM.FastRoughValveStatus <> Equipment.WorkingStatuses.On AndAlso objTMController.IsTMMechanicalPumpCGRelayOff()
                            Dim blCurrentTMMPCGRelay As Boolean = IIf(objTMController.IsTMMechanicalPumpCGDisconnected() OrElse bTMMPRelay, True, False)
                            Dim blAllMPRelay As Boolean = blCurrentLLAMPCGRelay AndAlso blCurrentTMMPCGRelay

                            'is check rough <> open and CG relay off
                            If (blShareRelayMPOK <> blAllMPRelay AndAlso blAllMPRelay) Then
                                strError = String.Format(ContainerData.GetMessageText("MechanicalPumpCGRelay_FB"), objLLAController.NameLLMechanicalPump())
                                'objTMController.ThrowAlarm(strError & " Close Foreline.")
                            End If
                            blShareRelayMPOK = blAllMPRelay

                            'Close Foreline and reset error message
                            If Not String.IsNullOrEmpty(strError) Then
                                objTMController.CloseTMTurboForeline(m_terminateEvent)
                                objLLAController.CloseForelineValve(m_terminateEvent)
                                AVPLib.Log.avpLogger.Error(strError)
                                ' Reset error (error is processed).
                                strError = String.Empty
                            End If
                        End If
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Const Fine_Tune_Sleep_Time As Integer = 1000
                    If (SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time)) Then
                        Exit While
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.schedulerLogger.Debug("A THREAD FOR JOB MANAGER IS EXITING.")
            AVPLib.Log.coreLogger.Info("Leave OnDoWork")
        End Sub
        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2022-12-04</date>
        ''' </author>
        ''' <summary>
        ''' Initialize processing order
        ''' </summary>
        Public Sub Initialize()
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                ' Start processing.
                Start()

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Sub
        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2022-08-04</date>
        ''' </author>
        ''' <summary>
        ''' TM Process Safety Interlock
        ''' </summary>
        Private Sub TMProcessSafetyInterlock(ByVal strError As String, ByVal brelayForelineOff As Boolean)
            Try
                Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                Dim objTMController As TMController = ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString())
                If (RobotConfigurationValues.TM_HIVAC_INSTALLED) Then
                    'If (objTM.HiVacValveStatus = DataManagerment.Equipment.WorkingStatuses.On OrElse _
                    'objTM.IGStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    objTMController.ThrowAlarm(strError)
                    AVPLib.Log.avpLogger.Error(strError)
                    If (objTMController IsNot Nothing) Then
                        objTMController.ProcessSafetyInterlock(brelayForelineOff)
                    End If
                    'End If
                    'WHEN HIVAC ISNOT INSTALLED -> NOT USE IG
                    'ElseIf (objTM.IGStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    '    Utils.ThrowAlarm(strError & " Turn Off IG.")
                    '    If (objTMController IsNot Nothing) Then
                    '        objTMController.ProcessSafetyInterlock()
                    '    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2022-08-04</date>
        ''' </author>
        ''' <summary>
        ''' LLA Process Safety Interlock
        ''' </summary>
        Private Sub LLAProcessSafetyInterlock(ByVal strError As String, ByVal brelayForelineOff As Boolean)
            Try
                Dim objLLA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
                Dim objLLAController As LoadLockController = ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString())
                If (RobotConfigurationValues.LLA_HIVAC_INSTALLED) Then
                    If (objLLA.HiVacValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Or _
                        (objLLA.IGStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                        objLLAController.ThrowAlarm(strError)
                        AVPLib.Log.avpLogger.Error(strError)
                        If (objLLAController IsNot Nothing) Then
                            objLLAController.ProcessSafetyInterlock(brelayForelineOff, m_terminateEvent)
                            strError = String.Empty
                        End If
                    End If
                    'DO NOT CHECK IG WHEN HIVAC IS NOT INSTALLED
                    'ElseIf (objLLA.IGStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    '    Utils.ThrowAlarm(strError & " Turn Off IG.")
                    '    If (objLLAController IsNot Nothing) Then
                    '        objLLAController.ProcessSafetyInterlock(m_terminateEvent)
                    '    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            AVPLib.Log.coreLogger.Info("Enter Dispose")
            
            MyBase.Dispose(disposing)
            AVPLib.Log.coreLogger.Info("Leave Dispose")
        End Sub
    End Class
End Namespace

