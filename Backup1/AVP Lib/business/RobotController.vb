Imports System.Timers
Imports AVPLib.DataManagerment
Imports AVPLib.ConstEnum
Imports System.Threading
Imports AVPLib.Business.AVPProcessJob
Imports AVPLib.Communication.TerminalDriver
Namespace Business
    Public Class RobotController
        Inherits ControllerObject
#Region "Class Constants & Variables"
        Private m_tmrLinkTest As System.Timers.Timer
        Private enmPosition As Positions = Nothing
        Private next_enmPosition As Positions = Nothing
        Private next_next_enmPosition As Positions = Nothing
        Private previous_enmPosition As Positions = Nothing
        Const LL_OPERATION_ERR As String = "LoadLock operation has Errors"
        Const LL_CASSET_IS_NOT_PRESENT As String = "Casset is not present"
        Const CHECK_SENSOR_FAILED_BEFORE_PICK As String = "Check wafer sensor failed before pick"
        Const CHECK_SENSOR_FAILED_AFTER_PICK As String = "Check wafer sensor failed after pick"
        Const CHECK_SENSOR_FAILED_BEFORE_PLACE As String = "Check wafer sensor failed before place"
        Const CHECK_SENSOR_FAILED_AFTER_PLACE As String = "Check wafer sensor failed after place"
        Const ROBOT_OPERATION_ERR As String = "Robot operation has errors"
        Private m_IsInitializeFinished As Boolean = False
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        '''<Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-03</Date>
        '''		<Description> Fix bugs </Description>
        ''' </Modifier>
        '''</Modifiers>        
        ''' <summary>
        ''' Timer LLCryoController
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LinkTestInterval() As Integer
            Get
                Return m_tmrLinkTest.Interval
            End Get
            Set(ByVal value As Integer)
                Dim blnIsStart = m_tmrLinkTest.Enabled
                m_tmrLinkTest.Enabled = False
                m_tmrLinkTest.Interval = value
                If (blnIsStart) Then
                    m_tmrLinkTest.Enabled = True
                End If
            End Set
        End Property
#End Region

#Region "Constructors & Dispose"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        '''<Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-03</Date>
        '''		<Description> Fix bugs </Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Contructor
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            m_tmrLinkTest = New System.Timers.Timer
            AddHandler m_tmrLinkTest.Elapsed, AddressOf SendLinkTest
            m_tmrLinkTest.Interval = 2000
        End Sub
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2011-12-13 </date>
        ''' </author>
        ''' <summary>
        ''' Dispose Aligner Object
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Dispose()
            AVPLib.Log.coreLogger.Info("Enter Dispose")
            Try
                m_tmrLinkTest.Enabled = False
                RemoveHandler m_tmrLinkTest.Elapsed, AddressOf SendLinkTest
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Dispose")
        End Sub
#End Region

#Region "set robot config"
        ''' <author>
        '''     <name>Tinh Le</name>
        '''     <date> 2020-11-10 </date>
        ''' </author>
        ''' <summary>
        ''' Set Robot config.
        ''' </summary>
        Public Sub SetRobotConfig()
            Try
                Dim rRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
                If rRobot IsNot Nothing Then

                    ' Request station config.
                    For Each val As String In rRobot.RobotSystemSetup.Values

                        'sent command to device
                        Dim strErrMsg As String
                        strErrMsg = RobotUtility.ArmStationVELACC(Me.EquipmentName, val)

                        If strErrMsg = Boolean.FalseString Then
                            Utils.ShowStatusMessage("Sent Robot config failed")
                        End If
                    Next
                    AVPLib.DataManagerment.EquipmentManager.ChangeStatus(AVPLib.ConstEnum.Equipments.Robot.ToString(), "ApplyRobotStatus", STR_Apply)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''     <name>Tinh Le</name>
        '''     <date> 2020-11-10 </date>
        ''' </author>
        ''' <summary>
        ''' Set ACC or VEL when start application.
        ''' </summary>
        Public Sub SetAccVelConfig()
            Try
                AVPLib.DataManagerment.EquipmentManager.LoadRobotStoreGui()
                Dim rRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
                If rRobot IsNot Nothing Then
                    Dim cmd As String = String.Empty
                    Dim strErrMsg As String
                    Dim hasRobotconfig As Boolean = False

                    'sent command to device HACC when HaveConfigHACC = true
                    If Boolean.TryParse(rRobot.HaveConfigHACC, hasRobotconfig) AndAlso hasRobotconfig Then
                        'R_HACC and T_HACC and Z_HACC != 0
                        If Not String.IsNullOrEmpty(rRobot.R_HACC) AndAlso Not String.IsNullOrEmpty(rRobot.T_HACC) _
                            AndAlso Not String.IsNullOrEmpty(rRobot.Z_HACC) Then
                            cmd = SetACCandVELParameters(STR_HACC, rRobot.R_HACC, rRobot.T_HACC, rRobot.Z_HACC)
                            strErrMsg = RobotUtility.ArmStationVELACC(Me.EquipmentName, cmd)

                            If strErrMsg = Boolean.FalseString Then
                                Utils.ShowStatusMessage("Sent Robot HACC config failed")
                            End If
                        End If
                    End If

                    'sent command to device PACC when HaveConfigPACC = true
                    If Boolean.TryParse(rRobot.HaveConfigPACC, hasRobotconfig) AndAlso hasRobotconfig Then
                        'R_PACC and T_PACC and Z_PACC != 0
                        If Not String.IsNullOrEmpty(rRobot.R_PACC) AndAlso Not String.IsNullOrEmpty(rRobot.T_PACC) _
                                            AndAlso Not String.IsNullOrEmpty(rRobot.Z_PACC) Then
                            cmd = SetACCandVELParameters(STR_PACC, rRobot.R_PACC, rRobot.T_PACC, rRobot.Z_PACC)
                            strErrMsg = RobotUtility.ArmStationVELACC(Me.EquipmentName, cmd)

                            If strErrMsg = Boolean.FalseString Then
                                Utils.ShowStatusMessage("Sent Robot PACC config failed")
                            End If
                        End If
                    End If

                    'sent command to device WACC
                    If Boolean.TryParse(rRobot.HaveConfigWACC, hasRobotconfig) AndAlso hasRobotconfig Then
                        'R_WACC and T_WACC and Z_WACC != 0
                        If Not String.IsNullOrEmpty(rRobot.R_WACC) AndAlso Not String.IsNullOrEmpty(rRobot.T_WACC) _
                        AndAlso Not String.IsNullOrEmpty(rRobot.Z_WACC) Then
                            cmd = SetACCandVELParameters(STR_WACC, rRobot.R_WACC, rRobot.T_WACC, rRobot.Z_WACC)
                            strErrMsg = RobotUtility.ArmStationVELACC(Me.EquipmentName, cmd)

                            If strErrMsg = Boolean.FalseString Then
                                Utils.ShowStatusMessage("Sent Robot WACC config failed")
                            End If
                        End If
                    End If

                    'sent command to device HVEL
                    If Boolean.TryParse(rRobot.HaveConfigHVEL, hasRobotconfig) AndAlso hasRobotconfig Then
                        'R_HVEL and T_HVEL and Z_HVEL != 0
                        If Not String.IsNullOrEmpty(rRobot.R_HVEL) AndAlso Not String.IsNullOrEmpty(rRobot.T_HVEL) _
                        AndAlso Not String.IsNullOrEmpty(rRobot.Z_HVEL) Then
                            cmd = SetACCandVELParameters(STR_HVEL, rRobot.R_HVEL, rRobot.T_HVEL, rRobot.Z_HVEL)
                            strErrMsg = RobotUtility.ArmStationVELACC(Me.EquipmentName, cmd)

                            If strErrMsg = Boolean.FalseString Then
                                Utils.ShowStatusMessage("Sent Robot HVEL config failed")
                            End If
                        End If
                    End If


                    'sent command to device PVEL
                    If Boolean.TryParse(rRobot.HaveConfigPVEL, hasRobotconfig) AndAlso hasRobotconfig Then
                        'R_PVEL and T_PVEL and Z_PVEL != 0
                        If Not String.IsNullOrEmpty(rRobot.R_PVEL) AndAlso Not String.IsNullOrEmpty(rRobot.T_PVEL) _
                        AndAlso Not String.IsNullOrEmpty(rRobot.Z_PVEL) Then
                            cmd = SetACCandVELParameters(STR_PVEL, rRobot.R_PVEL, rRobot.T_PVEL, rRobot.Z_PVEL)
                            strErrMsg = RobotUtility.ArmStationVELACC(Me.EquipmentName, cmd)

                            If strErrMsg = Boolean.FalseString Then
                                Utils.ShowStatusMessage("Sent Robot HVEL config failed")
                            End If
                        End If
                    End If

                    'sent command to device WVEL
                    If Boolean.TryParse(rRobot.HaveConfigWVEL, hasRobotconfig) AndAlso hasRobotconfig Then
                        'R_WVEL and T_WVEL and Z_WVEL != 0
                        If Not String.IsNullOrEmpty(rRobot.R_WVEL) AndAlso Not String.IsNullOrEmpty(rRobot.T_WVEL) _
                        AndAlso Not String.IsNullOrEmpty(rRobot.Z_HVEL) Then
                            cmd = SetACCandVELParameters(STR_WVEL, rRobot.R_WVEL, rRobot.T_WVEL, rRobot.Z_WVEL)
                            strErrMsg = RobotUtility.ArmStationVELACC(Me.EquipmentName, cmd)

                            If strErrMsg = Boolean.FalseString Then
                                Utils.ShowStatusMessage("Sent Robot HVEL config failed")
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''     <name>Tinh Le</name>
        '''     <date> 2020-11-10 </date>
        ''' </author>
        ''' <summary>
        ''' Set ACC and VEL Parameters
        ''' </summary>
        Public Function SetACCandVELParameters(ByVal typeName As String, ByVal str_R As String, ByVal str_T As String, ByVal str_Z As String) As String
            AVPLib.Log.coreLogger.Info("Enter SetACCandVELParameters")
            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
            Dim strCommand As String = ""
            Select Case typeName
                Case "HACC"
                    strCommand = String.Concat(New String() {"SET HACC R ", str_R, " T ", str_T, " Z ", str_Z})
                Case "PACC"
                    strCommand = String.Concat(New String() {"SET PACC R ", str_R, " T ", str_T, " Z ", str_Z})
                Case "WACC"
                    strCommand = String.Concat(New String() {"SET WACC R ", str_R, " T ", str_T, " Z ", str_Z})
                Case "HVEL"
                    strCommand = String.Concat(New String() {"SET HVEL R ", str_R, " T ", str_T, " Z ", str_Z})
                Case "PVEL"
                    strCommand = String.Concat(New String() {"SET PVEL R ", str_R, " T ", str_T, " Z ", str_Z})
                Case "WVEL"
                    strCommand = String.Concat(New String() {"SET WVEL R ", str_R, " T ", str_T, " Z ", str_Z})
            End Select
            Return strCommand
        End Function
#End Region

#Region "Public method"
        Public Function IsInitFinished() As Boolean
            Return m_IsInitializeFinished
        End Function
        Public Sub InitializeProc()
            ThreadPool.QueueUserWorkItem(AddressOf Initialize, Nothing)
        End Sub
        Public Overrides Sub ReconnectHandle(ByVal obj As Object, ByVal e As ReconnectEventArgs)
            'Re-Init if need
            If e.EquipName = m_strEquipmentName Then
                'm_IsInitializeFinished = False
                ' Always pulling
                IsDoingReConnect = True
                m_tmrLinkTest.Enabled = False 'Start pulling
                ReInitializeProc()
            End If
        End Sub

        Public Sub ReInitializeProc()
            ThreadPool.QueueUserWorkItem(AddressOf ReInitialize, Nothing)
        End Sub

        Private Sub ReInitialize(ByVal state As Object)
            RobotUtility.ResendInitParam(m_strEquipmentName)
            'm_IsInitializeFinished = True
            ' Always pulling
            IsDoingReConnect = False
            m_tmrLinkTest.Enabled = True 'Start pulling

            ' Request robot info
            Me.RequestRobotInfo()
        End Sub
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-05 </date>
        ''' </author>
        ''' <summary>
        ''' Inititialize Robot
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Initialize(ByVal state As Object)
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                Dim bGoHome As Boolean = False
                Dim bGoToFirstStation As Boolean = False
                If (RobotUtility.Initialize(EquipmentName, bGoHome, bGoToFirstStation)) Then
                    'If bGoHome Then
                    '    RaiseHome()
                    'End If
                    'If bGoToFirstStation Then
                    '    MoveRobotHandAtFirstSensorPos()
                    'End If
                Else
                    Dim arrPropertyNames As New ArrayList()
                    arrPropertyNames.Add("OperationStatus")
                    arrPropertyNames.Add("ErrorMessage")

                    Dim arrValues As New ArrayList()
                    arrValues.Add(Equipment.OperationStatuses.ERROR)
                    arrValues.Add(Utils.GetMessageError("ErrInit"))
                    EquipmentManager.ChangeStatus(EquipmentName, arrPropertyNames, arrValues)
                End If

                m_IsInitializeFinished = True
                ' Always pulling
                m_tmrLinkTest.Enabled = True 'Start pulling

                'sent config
                Me.SetAccVelConfig()

                ' Request robot info
                Me.RequestRobotInfo()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do tasks of robot
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Overrides Sub DoTask(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter DoTask")
            Select Case Message
                Case "ArmUp"
                    ArmUp()
                Case "ArmDown"
                    ArmDown()
                Case "ArmRetract"
                    ArmRetract()
                Case "ArmExtend"
                    ArmExtend()
                Case "Home"
                    Home()
                    ActionCMDSent = True
                Case "TurnOnWaferSensorChecking"
                    RobotUtility.TurnOnWaferSensorChecking(Me.EquipmentName)
                Case "TurnOffWaferSensorChecking"
                    RobotUtility.TurnOffWaferSensorChecking(Me.EquipmentName)
                Case "GotoStation1"
                    RobotUtility.GoToNStation(Me.EquipmentName, RobotConfigurationValues.LLA_STATION_NO)
                Case "GotoStation2"
                    RobotUtility.GoToNStation(Me.EquipmentName, RobotConfigurationValues.PM1_STATION_NO)
                Case "GotoStation3"
                    RobotUtility.GoToNStation(Me.EquipmentName, RobotConfigurationValues.PM2_STATION_NO)
                Case "GotoStation4"
                    RobotUtility.GoToNStation(Me.EquipmentName, RobotConfigurationValues.PM3_STATION_NO)
                Case "GotoStation8"
                    RobotUtility.GoToNStation(Me.EquipmentName, RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO)
                Case "GotoStation9"
                    RobotUtility.GoToNStation(Me.EquipmentName, RobotConfigurationValues.ALIGNER_STATION_NO)
                Case "RequestInfo"
                    Me.RequestRobotInfo()
                Case "SetConfigRobot"
                    Me.SetRobotConfig()
                Case Else
                    If (Message.IndexOf("Pick") >= 0) Then
                        Dim strStation As String = Utils.ParseValue(Message)
                        If (Not String.IsNullOrEmpty(strStation)) Then
                            ManualPickFromStation(EquipmentName, strStation)
                        End If
                    ElseIf (Message.IndexOf("Place") >= 0) Then
                        Dim strStation As String = Utils.ParseValue(Message)
                        If (Not String.IsNullOrEmpty(strStation)) Then
                            ManualPlaceToStation(EquipmentName, strStation)
                        End If
                    End If
            End Select
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-09-04</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Private Sub ManualPickFromStation(ByVal EquipmentName As String, ByVal strStation As String)
            Try
                Dim SlotID As Integer = 1
                If (RobotUtility.PickWaferFromStation(EquipmentName, strStation)) Then
                    Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())

                    Dim stationName As String = GetStationName(strStation)
                    If (stationName.Contains("LoadLock")) Then
                        Dim objLLElevator As LLElevator = Nothing
                        If (stationName = ConstEnum.Equipments.LoadLockA.ToString) Then
                            objLLElevator = EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
                        End If

                        If (objLLElevator IsNot Nothing) Then
                            stationName = stationName & ",Slot" & objLLElevator.CurrentSlot.ToString
                            If (objLLElevator.ListOfWaferInfo(objLLElevator.CurrentSlot - 1) IsNot Nothing) Then
                                objRobot.SetWaferInfo(objLLElevator.ListOfWaferInfo(objLLElevator.CurrentSlot - 1))
                                objLLElevator.ListOfWaferInfo(objLLElevator.CurrentSlot - 1) = Nothing
                            End If
                        End If
                    ElseIf (stationName.Contains("Chamber")) Then

                        Dim objEquipment As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(stationName)

                        If (objEquipment.EquipmentType = SystemModule.ModuleType.PVD4) Then
                            SlotID = CType(objEquipment, DataManagerment.CoronaChamber).Substrate_Current_Station
                        ElseIf objEquipment.EquipmentType = SystemModule.ModuleType.PVD5T Then
                            SlotID = CType(objEquipment, DataManagerment.PVD5TChamber).Substrate_Current_Station
                        End If

                        If (objEquipment.GetWaferInfo(SlotID) IsNot Nothing) Then
                            objRobot.SetWaferInfo(objEquipment.GetWaferInfo(SlotID))
                            objEquipment.SetWaferInfo(Nothing, SlotID)
                        End If
                    Else

                        Dim objEquipment As Equipment = DataManagerment.EquipmentManager.GetEquipment(stationName)
                        If (objEquipment.GetWaferInfo() IsNot Nothing) Then
                            objRobot.SetWaferInfo(objEquipment.GetWaferInfo())
                            objEquipment.SetWaferInfo()
                        End If
                    End If

                    If (objRobot.GetWaferInfo() IsNot Nothing) Then
                        ControllerManager.SetWaferInsideSrc_Dst(stationName, Equipments.Robot.ToString(), objRobot.GetWaferInfo(), SlotID, 1)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-09-04</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Private Sub ManualPlaceToStation(ByVal EquipmentName As String, ByVal strStation As String)
            Try
                Dim slotID As Integer = 1
                If (RobotUtility.PlaceWaferToStation(EquipmentName, strStation)) Then
                    Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())

                    Dim stationName As String = GetStationName(strStation)
                    Dim waferInfo As AVPWaferInfo = objRobot.GetWaferInfo()

                    If (stationName.Contains("LoadLock")) Then
                        Dim objLLElevator As LLElevator = Nothing
                        If (stationName = ConstEnum.Equipments.LoadLockA.ToString) Then
                            objLLElevator = EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
                        End If

                        If (objLLElevator IsNot Nothing) Then
                            stationName = stationName & ",Slot" & objLLElevator.CurrentSlot.ToString
                            If (waferInfo IsNot Nothing) Then
                                objLLElevator.ListOfWaferInfo(objLLElevator.CurrentSlot - 1) = waferInfo
                                objRobot.SetWaferInfo()
                            End If
                        End If
                    ElseIf (stationName.Contains("Chamber")) Then
                        Dim objEquipment As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(stationName)

                        If (objEquipment.EquipmentType = SystemModule.ModuleType.PVD4) Then
                            slotID = CType(objEquipment, DataManagerment.CoronaChamber).Substrate_Current_Station
                        ElseIf objEquipment.EquipmentType = SystemModule.ModuleType.PVD5T Then
                            slotID = CType(objEquipment, DataManagerment.PVD5TChamber).Substrate_Current_Station
                        End If

                        If (waferInfo IsNot Nothing) Then
                            objEquipment.SetWaferInfo(objRobot.GetWaferInfo(1), slotID)
                            objRobot.SetWaferInfo()
                        End If
                    Else
                        Dim objEquipment As Equipment = DataManagerment.EquipmentManager.GetEquipment(stationName)
                        If (waferInfo IsNot Nothing) Then
                            objEquipment.SetWaferInfo(objRobot.GetWaferInfo())
                            objRobot.SetWaferInfo()
                        End If
                    End If

                    If (waferInfo IsNot Nothing) Then
                        ControllerManager.SetWaferInsideSrc_Dst(Equipments.Robot.ToString(), stationName, waferInfo, 1, slotID)
                    End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        Public Sub BringTMOffline_PopupSensorFailed()
            Dim objTMController As TMController = ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString())
            objTMController.DoTask("Offline")
            ' Utils.Create_Core_MessageBox("Checking Wafer Sensor failed! TM will be offline" & Chr(13) & "You can transfer wafer manually. After sensor checking is ok, please bring TM online back")
        End Sub

        'Dat Cao 
        'Cannot delete a wafer on robot arm when robot communication is disconnected.   
        'If user try to delete the wafer on robot arm while communication is disconnected,  
        'wafer remain on robot arm and user unable to click on that wafer again.  
        'Once robot is communicate again,  wafer on robot arm automatically delete and everything is back to normal.  
        'In this case,  we just have to delete the wafer status without sending any command to robot since it is already disconnected.
        Public Sub SendCMDDelete_Create_Wafer(ByVal IsDeleteWafer As Boolean)
            AVPLib.Log.coreLogger.Info("Enter DoSerialCommand")
            Try
                Dim objRobot As Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString)
                If (objRobot IsNot Nothing AndAlso objRobot.IsCommunicating) Then
                    If RobotConfigurationValues.ROBOT_VERSION_CONFIG <= ROBOT_VERSION_7_1 Then ''check sensor by software
                        Exit Sub
                    End If
                    '''if Robot Version = 7.2
                    If IsDeleteWafer = False Then
                        RobotUtility.CreateRobotWafer(EquipmentName)
                    Else
                        RobotUtility.DeleteRobotWafer(EquipmentName)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoSerialCommand")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do Serial Command RobotController
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Public Overrides Sub DoSerialCommand(ByVal Command As String)
            AVPLib.Log.coreLogger.Info("Enter DoSerialCommand")
            Try
                RobotUtility.DoSerialCommand(Command)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoSerialCommand")
        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        '''  Link test
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SendLinkTest(ByVal source As Object, ByVal e As ElapsedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter SendLinkTest")
            Try
                m_tmrLinkTest.Enabled = False
                If RobotUtility.CheckComunicationAlive(EquipmentName) Then
                    RobotUtility.GetRobotPositionStatus(EquipmentName) 'stn
                    RobotUtility.GetRetractedStatus(EquipmentName)  ' abs
                End If
                m_tmrLinkTest.Enabled = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendLinkTest")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-09-04</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Public Function GetStationName(ByVal Station As String) As String
            AVPLib.Log.coreLogger.Info("Enter GetStationName")
            Dim strResult As String = String.Empty

            Select Case Station
                Case RobotConfigurationValues.PM1_STATION_NO
                    strResult = Equipments.Chamber1.ToString
                Case RobotConfigurationValues.PM2_STATION_NO
                    strResult = Equipments.Chamber2.ToString
                Case RobotConfigurationValues.PM3_STATION_NO
                    strResult = Equipments.Chamber3.ToString
                Case RobotConfigurationValues.LLA_STATION_NO
                    strResult = Equipments.LoadLockA.ToString
                Case RobotConfigurationValues.ALIGNER_STATION_NO
                    strResult = Equipments.Aligner.ToString
                Case RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO
                    strResult = Equipments.Aligner.ToString
            End Select

            Return strResult
            AVPLib.Log.coreLogger.Info("Enter GetStationName")
        End Function
        Public Sub GotoNStation(ByVal Station As String)
            AVPLib.Log.coreLogger.Info("Enter GotoNStation")
            Select Case Station
                Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                    RobotUtility.GoToNStation(EquipmentName, Equipments.Chamber1)
                Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                    RobotUtility.GoToNStation(EquipmentName, Equipments.Chamber2)
                Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                    RobotUtility.GoToNStation(EquipmentName, Equipments.Chamber3)
                Case AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
                    RobotUtility.GoToNStation(EquipmentName, Equipments.LoadLockA)
                Case AVPLib.ConstEnum.Equipments.Aligner.ToString()
                    RobotUtility.GoToNStation(EquipmentName, Equipments.Aligner)
            End Select
            AVPLib.Log.coreLogger.Info("Enter GotoNStation")
        End Sub

        Public Function CheckSensorOn_Off_AtStationN(ByVal station As String, ByVal IsCheckOn As Boolean) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckSensorAtStationN")
            If RobotConfigurationValues.DEBUGMODE = True Then
                Return True
            End If
            If RobotConfigurationValues.DISABLE_SENSOR_CHECKING Then
                Return True
            End If
            'wait for sensor....
            Return WaitForSensorOnOff(IsCheckOn, station)
            AVPLib.Log.coreLogger.Info("Enter CheckSensorAtStationN")
        End Function

        Private Function WaitForSensorOnOff(ByVal IsOn As Boolean, ByVal sStation As String) As Boolean
            Dim timeout As Integer = RobotConfigurationValues.SYSTEM_WAIT_FOR_CHECK_SENSOR_IN_SECONDS * 1000
            Return Utils.WaitOnCondition(AddressOf IsSensorOnOffCond, timeout, Nothing, IsOn, sStation)
        End Function

        Private Function IsSensorOnOffCond(ByVal ParamArray arg() As Object) As Boolean

            Dim blResult As Boolean = False

            Try
                'check length of array parameter
                If (arg.Length < 2) Then
                    Exit Try
                End If

                'get parameter
                Dim IsOn As Boolean = arg(0)
                Dim sStation As String = arg(1)

                Dim TransferModuleObj As DataManagerment.CassettesModule =
                CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)

                If (IsOn) Then
                    blResult = (TransferModuleObj.GetSensorStatus(sStation) = Equipment.WorkingStatuses.On)
                Else
                    blResult = (TransferModuleObj.GetSensorStatus(sStation) = Equipment.WorkingStatuses.Off)
                End If

            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try

            Return blResult
        End Function

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-14</date>
        ''' </author>
        ''' <summary>
        ''' PickWafer From Station
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PickWaferFromStation(ByVal Source As String, ByVal blnIsAutoTransfer As Boolean, ByVal blnIsReturnWafer As Boolean,
        Optional ByVal bCheckSensor As Boolean = True) As String
            AVPLib.Log.coreLogger.Info("Enter PickWaferFromStation")
            Try
                Dim nStationLocation As Integer = -1

                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                ' Not have wafer inside robot

                objRobot.SetWaferInfo()
                'MoveHandToPosition(previous_enmPosition)

                If ContainerData.GetStationLocation(Source, nStationLocation) Then
                    'There is station 9, Station ID might be wrong 
                    If Source = ConstEnum.Equipments.Aligner.ToString() AndAlso Not blnIsReturnWafer Then
                        ' If the pick is from Aligner, we migh need to change the station No
                        Dim Aligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                        nStationLocation = Aligner.PickStation
                    End If

                    AVPLib.Log.avpLogger.Debug("Pick Align at station: " & nStationLocation)

                    'Pick from Chamber, LL, Aligner, Robot Arm
                    ' If We are picking from Loadlock make sure LoadLock Cassette is present.
                    If Source = Equipments.LoadLockA.ToString() Then
                        Dim objLLElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                        If objLLElevator IsNot Nothing AndAlso Not (objLLElevator.CPStatus = Equipment.WorkingStatuses.On) Then
                            AVPLib.Log.coreLogger.Info("Leave PickWaferFromStation")
                            Return LL_CASSET_IS_NOT_PRESENT
                        End If
                    End If
                    Dim check As Boolean = True

                    ''check sensor by software
                    If bCheckSensor Then
                        Dim result As String = CheckSensorBeforePick(Source, blnIsAutoTransfer, blnIsReturnWafer)
                        If result <> String.Empty Then
                            Return result
                        End If
                    End If

                    AVPLib.Log.schedulerLogger.Debug("PICK WAFER FROM STATION - " & Source & " : POS=" & nStationLocation)
                    check = RobotUtility.PickWaferFromStation(Me.EquipmentName, nStationLocation)
                    If (Not check) Then
                        AVPLib.Log.coreLogger.Info("Leave PickWaferFromStation")
                        If blnIsAutoTransfer Or blnIsReturnWafer Then
                            BringTMOffline_PopupSensorFailed()
                        End If
                        Return "Robot action pick failed"
                    End If
                    If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                        ' Failed to Pick.
                        AVPLib.Log.coreLogger.Info("Leave PickWaferFromStation")
                        If blnIsAutoTransfer Or blnIsReturnWafer Then
                            BringTMOffline_PopupSensorFailed()
                        End If
                        Return ROBOT_OPERATION_ERR
                    End If
                    'MoveHandToPosition(enmPosition)
                    'query sensor status
                    If RobotConfigurationValues.ROBOT_VERSION_CONFIG <= ROBOT_VERSION_7_1 Then ''check sensor by software
                        AVPLib.Log.schedulerLogger.Debug("CHECK WAFER SENSOR AT ROBOT ARM " & nStationLocation)
                        ' Dim TMObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                        'check = TMObj.GetSensorStatus(Source) = Equipment.WorkingStatuses.On
                        check = CheckSensorOn_Off_AtStationN(Source, True)
                        If Not check And RobotConfigurationValues.DEBUGMODE = False Then
                            If blnIsAutoTransfer Or blnIsReturnWafer Then
                                BringTMOffline_PopupSensorFailed()
                            End If
                            AVPLib.Log.coreLogger.Info("Leave PlaceWaferToStation")
                            Return CHECK_SENSOR_FAILED_AFTER_PICK
                        End If
                    End If
                    MovePVDChuckToPumpDownPosition(Source)

                    AVPLib.Log.coreLogger.Info("Leave PickWaferFromStation")
                    Return String.Empty
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return "Get Station Error"
            AVPLib.Log.coreLogger.Info("Leave PickWaferFromStation")
        End Function


        ''' <author>
        '''    	<name>Tinh Le</name>
        '''    	<date>2019-06-14</date>
        ''' </author>
        ''' <summary>
        ''' CheckSensorBeforePick
        ''' </summary>
        Public Function CheckSensorBeforePick(ByVal Source As String, ByVal blnIsAutoTransfer As Boolean, ByVal blnIsReturnWafer As Boolean) As String
            AVPLib.Log.coreLogger.Info("Enter CheckSensorBeforePick")
            Try
                Dim nStationLocation As Integer = -1
                Dim check As Boolean = True

                If ContainerData.GetStationLocation(Source, nStationLocation) Then
                    If RobotConfigurationValues.ROBOT_VERSION_CONFIG <= ROBOT_VERSION_7_1 Then ''check sensor by software
                        ''Modify rules before Pick/Place 
                        AVPLib.Log.schedulerLogger.Debug("GO TO NStation Before Pick :" & nStationLocation)
                        check = RobotUtility.GoToNStation(Me.EquipmentName, nStationLocation)
                        If check = False Then
                            AVPLib.Log.coreLogger.Info("Leave CheckSensorBeforePick")
                            Return "Robot can not go to station: " & nStationLocation
                        End If
                        AVPLib.Log.schedulerLogger.Debug("Check Sensor at NStation Before Pick :" & nStationLocation)
                        check = CheckSensorOn_Off_AtStationN(Source, False)
                        If check = False Then
                            AVPLib.Log.coreLogger.Info("Leave CheckSensorBeforePick")
                            If blnIsAutoTransfer Or blnIsReturnWafer Then
                                BringTMOffline_PopupSensorFailed()
                            End If
                            Return CHECK_SENSOR_FAILED_BEFORE_PICK
                        End If
                        ''End Modify
                    End If
                    AVPLib.Log.coreLogger.Info("Leave CheckSensorBeforePick")
                    Return String.Empty
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return "Get Station Error"
            AVPLib.Log.coreLogger.Info("Leave CheckSensorBeforePick")
        End Function

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2011-2-16</date>
        ''' </author>
        ''' <summary>
        ''' After pick up wafer, move chuck to pump down position
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function MovePVDChuckToPumpDownPosition(ByVal Source As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter MovePVDChuckToPumpDownPosition: " + Source)
            Try
                If (Source.IndexOf(ChamberID) >= 0) Then
                    Dim srcChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Source)

                    'if this is PVD then move chuck to pumpdown position
                    If srcChamber IsNot Nothing AndAlso srcChamber.EquipmentType = SystemModule.ModuleType.PVD Then
                        Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                        Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(pvdChamber.Name)
                        Dim fChuckatPumpDownPosition As Single = chamberConfig.PVD_Chuck_At_PumpDown_Postion
                        PVDUtility.Chuck_Pos2(Source, fChuckatPumpDownPosition.ToString())
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave MovePVDChuckToPumpDownPosition")
            Return False
        End Function

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-14</date>
        ''' </author>
        ''' <summary>
        ''' PlaceWafer To Station
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PlaceWaferToStation(ByVal Source As String, ByVal blnIsAutoTransfer As Boolean, ByVal blnIsReturnWafer As Boolean) As String
            AVPLib.Log.coreLogger.Info("Enter PlaceWaferToStation")
            Try
                Dim nStationLocation As Integer = -1

                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                If ContainerData.GetStationLocation(Source, nStationLocation) Then
                    'Pick from Chamber, LL, Aligner, Robot Arm
                    ' If We are placing into Loadlock make sure LoadLock Cassette is present.
                    If Source = Equipments.LoadLockA.ToString() Then
                        Dim objLLElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                        If Not (objLLElevator.CPStatus = Equipment.WorkingStatuses.On) Then
                            AVPLib.Log.coreLogger.Info("Leave PickWaferFromStation")
                            Return "LoadLock Cassette is not present"
                        End If
                    End If
                    Dim check As Boolean = True
                    If RobotConfigurationValues.ROBOT_VERSION_CONFIG <= ROBOT_VERSION_7_1 Then
                        ''Modify rules before Pick/Place 
                        AVPLib.Log.schedulerLogger.Debug("GO TO NStation Before Place :" & nStationLocation)
                        check = RobotUtility.GoToNStation(Me.EquipmentName, nStationLocation)
                        If Not check Then
                            AVPLib.Log.coreLogger.Info("Leave PlaceWaferToStation")
                            Return "Robot can not go to station: " & nStationLocation
                        End If
                        AVPLib.Log.schedulerLogger.Debug("Check Sensor at NStation Before Place :" & nStationLocation)
                        check = CheckSensorOn_Off_AtStationN(Source, True)
                        If Not check Then
                            AVPLib.Log.coreLogger.Info("Leave PickWaferFromStation")
                            If blnIsAutoTransfer Or blnIsReturnWafer Then
                                BringTMOffline_PopupSensorFailed()
                            End If
                            Return CHECK_SENSOR_FAILED_BEFORE_PLACE
                        End If
                        ''End Modify
                    End If

                    AVPLib.Log.schedulerLogger.Debug("PLACE WAFER TO STATION - " & Source & " : POS=" & nStationLocation)
                    check = RobotUtility.PlaceWaferToStation(Me.EquipmentName, nStationLocation)
                    If (Not check) Then
                        AVPLib.Log.coreLogger.Info("Leave PlaceWaferToStation")
                        If blnIsAutoTransfer Or blnIsReturnWafer Then
                            BringTMOffline_PopupSensorFailed()
                        End If
                        Return "Robot action place failed"
                    End If
                    If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                        ' Failed to PLACE.
                        AVPLib.Log.coreLogger.Info("Leave PlaceWaferToStation")
                        If blnIsAutoTransfer Or blnIsReturnWafer Then
                            BringTMOffline_PopupSensorFailed()
                        End If
                        Return ROBOT_OPERATION_ERR
                    End If
                    '''''
                    'Check Sensor by software
                    If RobotConfigurationValues.ROBOT_VERSION_CONFIG <= ROBOT_VERSION_7_1 Then ''check sensor by software
                        AVPLib.Log.schedulerLogger.Debug("CHECK WAFER SENSOR AT ROBOT ARM " & nStationLocation)
                        '  Dim TMObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                        check = CheckSensorOn_Off_AtStationN(Source, False)
                        'check = TMObj.GetSensorStatus(Source) = Equipment.WorkingStatuses.Off
                        If Not check And RobotConfigurationValues.DEBUGMODE = False Then
                            If blnIsAutoTransfer Or blnIsReturnWafer Then
                                BringTMOffline_PopupSensorFailed()
                            End If
                            AVPLib.Log.coreLogger.Info("Leave PlaceWaferToStation")
                            Return CHECK_SENSOR_FAILED_AFTER_PLACE
                        End If
                    End If
                    AVPLib.Log.coreLogger.Info("Leave PlaceWaferToStation")
                    Return String.Empty
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave PlaceWaferToStation")
            Return "Get Station Error"
        End Function

        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2026-02-23</date>
        ''' </author>
        ''' <summary>
        ''' Move Robot to LoadLock
        ''' </summary>
        ''' <param name="blnIsAutoTransfer"></param>
        ''' <param name="blnIsReturnWafer"></param>
        ''' <returns></returns>

        Public Function MoveRobotToLoadLock(ByVal blnIsAutoTransfer As Boolean, ByVal blnIsReturnWafer As Boolean) As String
            AVPLib.Log.coreLogger.Info("Enter MoveRobotToLoadLock")
            Dim strMsg = String.Empty
            Try
                Dim check As Boolean = True
                Dim nLLAStation = RobotConfigurationValues.LLA_STATION_NO
                AVPLib.Log.schedulerLogger.Debug("GO TO NStation :" & nLLAStation)
                check = RobotUtility.GoToNStation(Me.EquipmentName, nLLAStation)
                If Not check Then
                    AVPLib.Log.coreLogger.Info("Leave MoveRobotToLoadLock")
                    Return "Robot can not go to station: " & nLLAStation
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave MoveRobotToLoadLock")
            Return strMsg
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-17</date>
        ''' </author>
        ''' <summary>
        ''' Reset to Home
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Home() As Boolean
            AVPLib.Log.coreLogger.Info("Enter Home")
            Try

                Dim check As Boolean = RobotUtility.Home(EquipmentName)
                If (Not check) Then
                    AVPLib.Log.coreLogger.Info("Leave Home")
                    Return False
                End If
                '  Me.RaiseHome()
                check = RobotUtility.GoToFirstStation(EquipmentName)
                If (Not check) Then
                    AVPLib.Log.coreLogger.Info("Leave Home")
                    Return False
                End If
                ' Me.MoveRobotHandAtFirstSensorPos()
                AVPLib.Log.coreLogger.Info("Leave Home")
                Return True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Home")
            Return False
        End Function
#Region "Up-Down-Extend-Retract"
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2010-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ArmUp
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ArmUp()
            AVPLib.Log.coreLogger.Info("Enter ArmUp")
            Try
                Dim strErrMsg As String
                strErrMsg = RobotUtility.ArmUp(Me.EquipmentName)
                If strErrMsg = Boolean.FalseString Then
                    Utils.ShowStatusMessage("Moving arm up failed")
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ArmUp")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2010-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ArmDown
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ArmDown()
            AVPLib.Log.coreLogger.Info("Enter ArmDown")
            Try
                Dim strErrMsg As String
                strErrMsg = RobotUtility.ArmDown(Me.EquipmentName)
                If strErrMsg = Boolean.FalseString Then
                    Utils.ShowStatusMessage("Moving arm down failed")
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ArmDown")
        End Sub
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2010-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ArmRetract
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ArmRetract()
            AVPLib.Log.coreLogger.Info("Enter ArmRetract")
            Try
                Dim strErrMsg As String
                strErrMsg = RobotUtility.ArmRetract(Me.EquipmentName)
                If strErrMsg = Boolean.FalseString Then
                    Utils.ShowStatusMessage("Moving arm retract failed")
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ArmRetract")
        End Sub
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2010-12-03</date>
        ''' </author>
        ''' <summary>
        ''' ArmExtend
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ArmExtend()
            AVPLib.Log.coreLogger.Info("Enter ArmExtend")
            Try
                Dim strErrMsg As String
                strErrMsg = RobotUtility.ArmExtend(Me.EquipmentName)
                If strErrMsg = Boolean.FalseString Then
                    Utils.ShowStatusMessage("Moving arm extend failed")
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ArmExtend")
        End Sub
#End Region
        '''' <author>
        ''''    	<name> Cao Anh Kiet </name>
        ''''    	<date> 2009-01-17</date>
        '''' </author>
        '''' <summary>
        '''' Raise Home
        '''' </summary>
        '''' <remarks></remarks>
        'Public Sub RaiseHome()
        '    AVPLib.Log.coreLogger.Info("Enter RaiseHome")
        '    Try
        '        Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

        '        If objRobot.WaferInside = Equipment.WorkingStatuses.On Then
        '            'MoveHandToPosition(Positions.Robot_Wafer)
        '        Else
        '            'MoveHandToPosition(Positions.Original)
        '        End If
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    AVPLib.Log.coreLogger.Info("Leave RaiseHome")
        'End Sub

        'Public Sub MoveRobotHandAtFirstSensorPos()
        '    AVPLib.Log.coreLogger.Info("Enter MoveRobotHandAtFirstSensorPos")
        '    Try
        '        Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

        '        If objRobot.WaferInside = Equipment.WorkingStatuses.On Then
        '            'MoveHandToPosition(Positions.Arm_At_LLA_Wafer)
        '        Else
        '            'MoveHandToPosition(Positions.LoadLockA)
        '        End If
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    AVPLib.Log.coreLogger.Info("Leave MoveRobotHandAtFirstSensorPos")
        'End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-15 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Send message to get information of retracted status of robot
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetRetractedStatus() As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetRetractedStatus")
            Try
                Return RobotUtility.GetRobotPositionStatus(Me.EquipmentName)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRetractedStatus")
        End Function
#End Region

        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Set parameters for a station ( teach robot ).
        ''' </summary>
        ''' <remarks>
        ' How to call this method:
        ' stationCode = Get ("DeltaPickStation") from configuration file.
        ' objAligner.Wafer_Rstation
        ' objAligner.Wafer_Tstation
        ' objRobot.ReqAlStn_Z
        ' objRobot.ReqLOWER
        ' objRobot.ReqNSLOTS
        ' objRobot.ReqPITCH</remarks>
        Public Function SetStationParameters(ByVal StationCode As String, ByVal Wafer_Rstation As String, ByVal Wafer_Tstation As String, ByVal AlStn_Z As String, ByVal LOWER As String, ByVal NSLOTS As String, ByVal PITCH As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SetStationParameters")
            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
            Dim strCommand As String = String.Concat(New String() {"SET STN ", StationCode, " R ", Wafer_Rstation, " T ", Wafer_Tstation, " Z ", AlStn_Z, " LOWER ", LOWER, " NSLOTS ", NSLOTS, " PITCH ", PITCH})
            ' Send this command to Robot.
            AVPLib.Log.schedulerLogger.Debug("ROBOT: SetStationParameters = " & strCommand)
            If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                AVPLib.Log.coreLogger.Info("Leave SetStationParameters")
                Return False
            End If
            If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                ' Failed to make SET STN for Robot.
                AVPLib.Log.coreLogger.Info("Leave SetStationParameters")
                Return False
            End If
            Return True
        End Function

        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Request station information.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overloads Function RequestStnAll(ByVal StationName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestStnAll")
            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
            Dim stationCode As Integer = -1
            If (Not ContainerData.GetStationLocation(StationName, stationCode)) Then
                ' "Failed to get StationCode for StationName = " & StationName
                AVPLib.Log.coreLogger.Info("Leave RequestStnAll")
                Return False
            End If
            AVPLib.Log.schedulerLogger.Debug("SEND: RQ STN 9 ALL. StationName=" & StationName & ", StationPos=" & stationCode)
            Dim strCommand As String = ("RQ STN " & stationCode.ToString() & " ALL")
            ' Send this command to Robot.
            ' This command runs in a RobotTransaction, and if it succeeds, those properties set:
            'If (strResultArray.Length = 8) Then
            '   objRobot.ReqAlStn_R = strResultArray(2)
            '   objRobot.ReqAlStn_Traw = strResultArray(3)
            '   objRobot.ReqAlStn_Z = strResultArray(4)
            '   objRobot.ReqLOWER = strResultArray(5)
            '   objRobot.ReqNSLOTS = strResultArray(6)
            '   objRobot.ReqPITCH = strResultArray(7)
            'End If
            ' And of course, those properties exist in Robot class.

            If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                AVPLib.Log.coreLogger.Info("Leave RequestStnAll")
                Return False
            End If

            If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                ' Failed to make RQ STN for Robot.
                AVPLib.Log.coreLogger.Info("Leave RequestStnAll")
                Return False
            End If

            Return True
        End Function

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Request station information.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overloads Function RequestStnAll(ByVal stationCode As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestStnAll")
            Dim result As Boolean
            Try
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                If (Not stationCode >= 0) Then
                    Exit Try
                End If

                Dim strCommand As String = "RQ STN " & stationCode.ToString() & " ALL"

                If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                    Exit Try
                End If

                If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    Exit Try
                End If

                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave RequestStnAll")
            Return result
        End Function

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Request robot version.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function RequestVersion() As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestVersion")
            Dim result As Boolean
            Try
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim strCommand As String = "RQ RVSN"

                If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                    Exit Try
                End If

                If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    Exit Try
                End If
                If objRobot IsNot Nothing Then
                    AVPLib.Utils.SaveToRevisionConfigFile(objRobot.RevisionNoValues, AVPLib.ConstEnum.Equipments.Robot.ToString())
                End If
                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave RequestVersion")
            Return result
        End Function

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-18 </date>
        ''' </author>
        ''' <summary>
        ''' Request robot version.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function RequestAppNumber() As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestAppNumber")
            Dim result As Boolean
            Try
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim strCommand As String = "RQ ROBOT APPLIC"

                If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                    Exit Try
                End If

                If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    Exit Try
                End If

                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave RequestAppNumber")
            Return result
        End Function

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Request robot home accelerate.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function RequestHaccAll() As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestHaccAll")
            Dim result As Boolean
            Try
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim strCommand As String = "RQ HACC ALL"

                If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                    Exit Try
                End If

                If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    Exit Try
                End If

                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave RequestHaccAll")
            Return result
        End Function

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Request robot accelerate when no wafers on the pan.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function RequestPaccAll() As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestPaccAll")
            Dim result As Boolean
            Try
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim strCommand As String = "RQ PACC ALL"

                If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                    Exit Try
                End If

                If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    Exit Try
                End If

                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave RequestPaccAll")
            Return result
        End Function

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Request robot accelerate when wafers on the pan.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function RequestWaccAll() As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestWaccAll")
            Dim result As Boolean
            Try
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim strCommand As String = "RQ WACC ALL"

                If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                    Exit Try
                End If

                If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    Exit Try
                End If

                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave RequestWaccAll")
            Return result
        End Function

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Request robot velocity when homing.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function RequestHvelAll() As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestHvelAll")
            Dim result As Boolean
            Try
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim strCommand As String = "RQ HVEL ALL"

                If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                    Exit Try
                End If

                If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    Exit Try
                End If

                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave RequestHvelAll")
            Return result
        End Function

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Request robot velocity when no wafers on the pan.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function RequestPvelAll() As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestPvelAll")
            Dim result As Boolean
            Try
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim strCommand As String = "RQ PVEL ALL"

                If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                    Exit Try
                End If

                If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    Exit Try
                End If

                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave RequestPvelAll")
            Return result
        End Function

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Request robot velocity when wafers on the pan.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function RequestWvelAll() As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestWvelAll")
            Dim result As Boolean
            Try
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim strCommand As String = "RQ WVEL ALL"

                If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                    Exit Try
                End If

                If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    Exit Try
                End If

                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave RequestWvelAll")
            Return result
        End Function

        ''' <author>
        '''     <name> Hai Tran </name>
        '''     <date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Get Robot config info.
        ''' </summary>
        Public Sub RequestRobotInfo()
            Try
                Dim rRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
                If rRobot IsNot Nothing Then
                    rRobot.RobotConfigValues.Clear()

                    ' Request station config.
                    For stn As Integer = 1 To 10
                        If stn = 5 OrElse stn = 6 OrElse stn = 7 Then
                            Continue For
                        End If
                        Me.RequestStnAll(stn)
                    Next

                    'Request accelerate config.
                    '> Home acceleration.
                    Me.RequestHaccAll()

                    '> No wafers on the pan acceleration.
                    Me.RequestPaccAll()

                    '> Wafers on the pan acceleration.
                    Me.RequestWaccAll()

                    'Request velocity config.
                    '> Home velocity.
                    Me.RequestHvelAll()

                    '> No wafers on the pan velocity.
                    Me.RequestPvelAll()

                    '> Wafers on the pan velocity.
                    Me.RequestWvelAll()

                    '> Request robot application number
                    Me.RequestAppNumber()

                    '> Request version (this must be in last request)
                    Me.RequestVersion()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>Hai Tran</author>
        ''' <date>2016-03-24</date>
        ''' <summary>
        ''' Immediately halts all robot motion operations.
        ''' </summary>
        Public Function HaltAllMotions() As Boolean
            AVPLib.Log.coreLogger.Info("Enter HaltAllMotions")
            Dim result As Boolean
            Try
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim strCommand As String = "HALT"

                If Not RobotUtility.ExecuteCommand(EquipmentName, strCommand) Then
                    Exit Try
                End If

                If (objRobot.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    Exit Try
                End If

                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave HaltAllMotions")
            Return result
        End Function

        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2021-12-08 </date>
        ''' </author>
        ''' <summary>
        ''' Set store.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function SetStore(ByVal StationName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SetStore")
            Dim result As Boolean
            Try
                'sent command to device
                Dim strErrMsg As String
                Dim stationCode As Integer = -1
                If (Not ContainerData.GetStationLocation(StationName, stationCode)) Then
                    ' "Failed to get StationCode for StationName = " & StationName
                    AVPLib.Log.coreLogger.Info("Leave SetStore")
                    Return False
                End If
                strErrMsg = RobotUtility.ArmStationVELACC(Me.EquipmentName, String.Format("STORE STN {0} ALL", stationCode))

                If strErrMsg = Boolean.FalseString Then
                    Utils.ShowStatusMessage("Sent Set Store config failed")
                End If

                result = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave RequestWvelAll")
            Return result
        End Function

    End Class
End Namespace

