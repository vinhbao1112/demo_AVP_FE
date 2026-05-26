Imports AVPLib.DataManagerment
Namespace Business
    ' Singleton object
    Public Class AVPCore
        Delegate Sub MessageDelegate(ByVal strMsg As String)

#Region "Avariables and Properties"
        Private m_stateMachineManager As AVPStateMachineManager = Nothing
        Private m_equipmentManager As EquipmentManager = Nothing
        Private m_JobManager As AVPJobManager = Nothing
        Private m_PauseEventManager As AVPPauseEventManager = Nothing
        Private Shared m_instance As AVPCore = Nothing
        Private m_safetyManager As AVPSafety = Nothing

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-2</date>
        ''' </author>
        ''' <summary>
        ''' Get the instant of this object
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Instance() As AVPCore
            If m_instance Is Nothing Then
                m_instance = New AVPCore()
            End If
            Return m_instance
        End Function
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02</date>
        ''' </author>
        ''' <summary>
        ''' Do not allow to create the object
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub New()

        End Sub
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Get state machine manager
        ''' </summary>
        ''' <remarks></remarks>
        Public Property StateMachineManager() As AVPStateMachineManager
            Get
                Return m_stateMachineManager
            End Get
            Set(ByVal value As AVPStateMachineManager)
                m_stateMachineManager = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Get state machine manager
        ''' </summary>
        ''' <remarks></remarks>
        Public Property EquipmentManager() As EquipmentManager
            Get
                Return m_equipmentManager
            End Get
            Set(ByVal value As EquipmentManager)
                m_equipmentManager = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Get job of manager
        ''' </summary>
        ''' <remarks></remarks>
        Public Property JobManager() As AVPJobManager
            Get
                Return m_JobManager
            End Get
            Set(ByVal value As AVPJobManager)
                m_JobManager = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Get job of manager
        ''' </summary>
        ''' <remarks></remarks>
        Public Property PauseEventManager() As AVPPauseEventManager
            Get
                Return m_PauseEventManager
            End Get
            Set(ByVal value As AVPPauseEventManager)
                m_PauseEventManager = value
            End Set
        End Property

#End Region
#Region "Shared method"
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Initialize AVP Core
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize()
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                AVPLib.Business.ControllerManager.Initialize()

#If AVP_PLATFORM = "CX" Then
                ' Init job manager, this is the 
                m_JobManager = New AVPJobManager()
                m_JobManager.Initialize()
#End If
                ' Init state machine manager
                m_stateMachineManager = New AVPStateMachineManager()
                m_stateMachineManager.Initialize()

                'Init safety mannager
                m_safetyManager = New AVPSafety()
                m_safetyManager.Initialize()

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Sub
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Initialize AVP Core
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub UnInitialize()
            AVPLib.Log.coreLogger.Info("Enter UnInitialize")
            Try
                If m_JobManager IsNot Nothing Then
                    m_JobManager.Dispose()
                End If

                If m_safetyManager IsNot Nothing Then
                    m_safetyManager.Dispose()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UnInitialize")
        End Sub

        Public Sub CleanUpBeforeExit(ByVal LogStatus As MessageDelegate)
            '-	If Turbo,  close turbo hivac/turn off IG / Turn off turbo /turn off foreline valve when exit CX5. 

            Dim strLoadLockA As String = ConstEnum.Equipments.LoadLockA.ToString()
            Dim strTransferModule As String = ConstEnum.Equipments.CassettesModule.ToString()

            Dim strLLAPumpPackage As String = ConstEnum.Equipments.LLAPumpPackage.ToString()
            Dim strTMPumpPackage As String = ConstEnum.Equipments.TMPumpPackage.ToString()

            Dim objLLA As LoadLock = DataManagerment.EquipmentManager.GetEquipment(strLoadLockA)

            ''' LoadLock A

            Try
                Dim objLLACtrl As LoadLockController = Business.ControllerManager.GetController(strLoadLockA)
                'Dim objLLATurboCtrl As TurboController = Business.ControllerManager.GetController(strLLAPumpPackage)
                Dim strLLAErrMsg As String = String.Empty
                Dim bLLAError As Boolean = False

                If objLLA IsNot Nothing AndAlso objLLA.IsIGInstalled Then
                    If LogStatus IsNot Nothing Then
                        LogStatus("  LoadLockA: Turn off IG")
                    End If

                    ' Turn off IG
                    strLLAErrMsg = LLCryoUtility.TurnOffIG(strLoadLockA)
                    If strLLAErrMsg <> String.Empty Then
                        bLLAError = True
                    End If
                End If

                ' Wait for IG off
                If Not bLLAError AndAlso objLLA IsNot Nothing AndAlso objLLA.IsIGInstalled Then
                    If Not Utils.WaitOnCondition(AddressOf objLLACtrl.IsLLIGOffCond,
                            VentPumdownLib.LLPumpdownConfig.IGOnOffTimeOut * 1000, Nothing) Then
                        bLLAError = True
                    End If
                End If

                ' Close Hivac
                If Not bLLAError Then
                    If LogStatus IsNot Nothing Then
                        LogStatus("  LoadLockA: Close Hivac Valve")
                    End If

                    strLLAErrMsg = LoadLockUtility.CloseLLHivac(strLoadLockA)
                    If strLLAErrMsg <> String.Empty Then
                        bLLAError = True
                    End If
                End If

                ' Wait for Hivac valve closed
                If Not bLLAError Then
                    If Not Utils.WaitOnCondition(AddressOf objLLACtrl.IsLLHiVacCloseCond, _
                            VentPumdownLib.LLPumpdownConfig.LLHivacOpenCloseTimeOut * 1000, Nothing) Then
                        bLLAError = True
                    End If
                End If

                ' Close foreline valve and turn off Turbo
                If (RobotConfigurationValues.LLA_TURBO_VISIBLE) Then
                    Dim objLLATurboCtrl As TurboController = Business.ControllerManager.GetController(strLLAPumpPackage)
                    ' Close foreline valve and turn off Turbo
                    If LogStatus IsNot Nothing Then
                        LogStatus("  LoadLockA: Turn off Turbo and Close Foreline Valve")
                    End If
                    If objLLATurboCtrl IsNot Nothing Then
                        objLLATurboCtrl.TurnOff()
                        LLCryoUtility.CloseLLTurboForeLineValve(strLoadLockA)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try


            ''' TM
            If RobotConfigurationValues.TMTURBO_VISIBLE OrElse RobotConfigurationValues.TMCRYO_VISIBLE Then
                Try
                    Dim objTMCtrl As TMController = Business.ControllerManager.GetController(strTransferModule)
                    Dim strTMErrMsg As String = String.Empty
                    Dim bTMError As Boolean = False

                    If LogStatus IsNot Nothing Then
                        LogStatus("  TransferModule: Turn off IG")
                    End If
                    ' Turn off IG
                    strTMErrMsg = TMCryoUtility.TurnOffIG(strTransferModule)
                    If strTMErrMsg <> String.Empty Then
                        bTMError = True
                    End If

                    ' Wait for IG off
                    If Not bTMError Then
                        If Not Utils.WaitOnCondition(AddressOf objTMCtrl.IsTMIGOffCond, _
                                VentPumdownLib.TMPumpdownConfig.IGOnOffTimeOut * 1000, Nothing) Then
                            bTMError = True
                        End If
                    End If

                    ' Close Hivac
                    If Not bTMError Then
                        If LogStatus IsNot Nothing Then
                            LogStatus("  TransferModule: Close Hivac Valve")
                        End If
                        strTMErrMsg = TMCryoUtility.CloseHiVacValve(strTransferModule)
                        If strTMErrMsg <> String.Empty Then
                            bTMError = True
                        End If
                    End If

                    '' Wait for Hivac valve closed
                    If Not bTMError Then
                        If Not Utils.WaitOnCondition(AddressOf objTMCtrl.IsTMHivacCloseCond, _
                                VentPumdownLib.TMPumpdownConfig.TMHivacOpenCloseTimeOut * 1000, Nothing) Then
                            bTMError = True
                        End If
                    End If

                    ' Turn Off Turbo and Foreline. 
                    If (RobotConfigurationValues.TMTURBO_VISIBLE) Then
                        Dim objTMTurboCtrl As TurboController = Business.ControllerManager.GetController(strTMPumpPackage)
                        ' Close foreline valve and turn off Turbo
                        If LogStatus IsNot Nothing Then
                            LogStatus("  TransferModule: Turn off Turbo and Close Foreline Valve")
                        End If
                        If objTMTurboCtrl IsNot Nothing Then
                            objTMTurboCtrl.TurnOff()
                        End If
                        TMCryoUtility.CloseTMTurboForeLineValve(strTransferModule)
                    End If

                    ' Close Mechanical Pump TM
                    Dim objMechanicalPump As RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(strTransferModule)
                    If (objMechanicalPump IsNot Nothing) Then
                        If LogStatus IsNot Nothing Then
                            LogStatus("  TransferModule: Close Mechanical Pump")
                        End If
                        TMCryoUtility.OpenCloseMechanicalPump(ConstEnum.Equipments.CassettesModule.ToString, objMechanicalPump.Name, False)
                    End If

                    ' Close Mechanical Pump LL
                    objMechanicalPump = DataManagerment.EquipmentManager.GetRoughPumpMachine(strLoadLockA)
                    If (objMechanicalPump IsNot Nothing) Then
                        If LogStatus IsNot Nothing Then
                            LogStatus("  LoadLockA: Close Mechanical Pump")
                        End If
                        TMCryoUtility.OpenCloseMechanicalPump(ConstEnum.Equipments.LoadLockA.ToString, objMechanicalPump.Name, False)
                    End If
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            End If
        End Sub

#End Region
    End Class
End Namespace
