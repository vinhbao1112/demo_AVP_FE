Imports System.Threading
Namespace DataManagerment
    Public Class EquipmentManager
#Region "Class Constants & Variables"
        Private Shared m_htbEquipmentList As Hashtable
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current EquipmentList
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property EquipmentList() As Hashtable
            Get
                Return m_htbEquipmentList
            End Get
            Set(ByVal value As Hashtable)
                m_htbEquipmentList = value
            End Set
        End Property

#End Region

#Region "Public methods"

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Initialize all equipment persitent
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Initialize()
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                m_htbEquipmentList = New Hashtable()
                CreateEquipments()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-01-14</date>
        ''' </author>
        ''' <summary>
        ''' Load Store Gui
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function LoadStoreGui() As DBStoreGui
            AVPLib.Log.coreLogger.Info("Enter LoadStoreGui")
            Dim StoreGui As DBStoreGui = Nothing
            Try
                StoreGui = ContainerData.GetStoreGui()
                Dim smSystemModule As SystemModule = Nothing
                Dim cb As DataManagerment.Chamber = Nothing

                Dim ListValues As ArrayList = New ArrayList()
                Dim ListProperties As ArrayList = New ArrayList()

                ListProperties.Add("WaferID")
                ' Chamber1
                If RobotConfigurationValues.CHAMBER1_VISIBLE Then
                    ListValues.Clear()
                    SetWaferInside(AVPLib.ConstEnum.Equipments.Chamber1.ToString(), ListValues, ListProperties, StoreGui, cb)
                    cb = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                    Dim objPMController As Business.ChamberController = Business.ControllerManager.GetController(ConstEnum.Equipments.Chamber1.ToString())
                    objPMController.DoSetWaferStatus(String.Format("{0:00}", CType(cb.WaferStatus, Integer)))
                End If

                'chamber 2
                If RobotConfigurationValues.CHAMBER2_VISIBLE Then
                    ListValues.Clear()
                    SetWaferInside(AVPLib.ConstEnum.Equipments.Chamber2.ToString(), ListValues, ListProperties, StoreGui, cb)
                    cb = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
                    Dim objPMController As Business.ChamberController = Business.ControllerManager.GetController(ConstEnum.Equipments.Chamber2.ToString())
                    objPMController.DoSetWaferStatus(String.Format("{0:00}", CType(cb.WaferStatus, Integer)))
                End If

                'chamber 3
                If RobotConfigurationValues.CHAMBER3_VISIBLE Then
                    ListValues.Clear()
                    SetWaferInside(AVPLib.ConstEnum.Equipments.Chamber3.ToString(), ListValues, ListProperties, StoreGui, cb)
                    cb = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
                    Dim objPMController As Business.ChamberController = Business.ControllerManager.GetController(ConstEnum.Equipments.Chamber3.ToString())
                    objPMController.DoSetWaferStatus(String.Format("{0:00}", CType(cb.WaferStatus, Integer)))
                End If

                '''''''''''''''''''''''''''''''
                Dim objAligner As DataManagerment.Aligner = Nothing
                If RobotConfigurationValues.ALINER_VISIBLE Then
                    objAligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                    If objAligner IsNot Nothing Then
                        objAligner.SetWaferInfo(StoreGui.WaferAtAligner)
                    End If
                    Business.ControllerManager.SetWaferInsideAligner(IIf((StoreGui.HaveInsideWaferAligner), "On", "Off"), _
                                                                     StoreGui.WaferAtAligner, False)
                End If


                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                If objRobot IsNot Nothing Then
                    objRobot.SetWaferInfo(StoreGui.WaferAtRobot)
                End If
                Business.ControllerManager.SetWaferInsideRobot(IIf((StoreGui.HaveInsideWaferRobot), "On", "Off"), StoreGui.WaferAtRobot, False)

                Dim LoadLockAElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())

                'RaiseWaferCountToGui
                If LoadLockAElevator IsNot Nothing Then
                    Dim arrWaferOfLoadLockA As AVPLib.AVPWaferInfo() = StoreGui.LoadLockAWaferInfo
                    For i As Integer = 0 To arrWaferOfLoadLockA.Length - 1
                        Dim waferInfo As AVPWaferInfo = arrWaferOfLoadLockA(i)
                        LoadLockAElevator.SetStatusGraph(i + 1, waferInfo)
                    Next
                    Dim objLoadLockA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
                    objLoadLockA.WaferCount = StoreGui.WaferTotalOfLoadLockA
                    objLoadLockA.LotID = StoreGui.LotID_LLA
                    objLoadLockA.SequenceID = StoreGui.SequenceID_LLA
                    LoadLockAElevator.ListOfWaferInfo = StoreGui.LoadLockAWaferInfo
                    RaiseInforToLLA(StoreGui.WaferTotalOfLoadLockA, StoreGui.LotID_LLA, StoreGui.SequenceID_LLA)
                End If

                RaiseLastUsedAlignerRecipeToGui(StoreGui.LastUsedAlignerRecipe)

                Dim objChamber As Chamber = Nothing
                If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
                    objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
                    objChamber.PM_WaferCount = StoreGui.WaferCountOfChamber1
                    objChamber.IsUseMaxLimit = Not (StoreGui.UseAbsoluteKWH)
                End If
                If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
                    objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
                    objChamber.PM_WaferCount = StoreGui.WaferCountOfChamber2
                    objChamber.IsUseMaxLimit = Not (StoreGui.UseAbsoluteKWH)
                End If
                If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
                    objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
                    objChamber.PM_WaferCount = StoreGui.WaferCountOfChamber3
                    objChamber.IsUseMaxLimit = Not (StoreGui.UseAbsoluteKWH)
                End If
                ContainerData.LifeTimeWafer = StoreGui.LifeTimeWafer
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return StoreGui
            AVPLib.Log.coreLogger.Info("Leave LoadStoreGui")
        End Function

        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2020-11-10</date>
        ''' </author>
        ''' <summary>
        ''' Load robot Store Gui
        ''' </summary>
        Public Shared Function LoadRobotStoreGui() As DBStoreGui
            AVPLib.Log.coreLogger.Info("Enter LoadStoreGui")
            Dim StoreGui As DBStoreGui = Nothing
            Try
                StoreGui = ContainerData.GetStoreGui()
#If AVP_PLATFORM = "SL" Then

#ElseIf AVP_PLATFORM = "CX" Then
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                If objRobot IsNot Nothing Then
                    'HACC
                    objRobot.HaveConfigHACC = StoreGui.HaveConfigHACC
                    objRobot.R_HACC = StoreGui.R_HACC
                    objRobot.T_HACC = StoreGui.T_HACC
                    objRobot.Z_HACC = StoreGui.Z_HACC

                    'PACC
                    objRobot.HaveConfigPACC = StoreGui.HaveConfigPACC
                    objRobot.R_PACC = StoreGui.R_PACC
                    objRobot.T_PACC = StoreGui.T_PACC
                    objRobot.Z_PACC = StoreGui.Z_PACC

                    'WACC
                    objRobot.HaveConfigWACC = StoreGui.HaveConfigWACC
                    objRobot.R_WACC = StoreGui.R_WACC
                    objRobot.T_WACC = StoreGui.T_WACC
                    objRobot.Z_WACC = StoreGui.Z_WACC

                    'HVEL
                    objRobot.HaveConfigHVEL = StoreGui.HaveConfigHVEL
                    objRobot.R_HVEL = StoreGui.R_HVEL
                    objRobot.T_HVEL = StoreGui.T_HVEL
                    objRobot.Z_HVEL = StoreGui.Z_HVEL

                    'PVEL
                    objRobot.HaveConfigPVEL = StoreGui.HaveConfigPVEL
                    objRobot.R_PVEL = StoreGui.R_PVEL
                    objRobot.T_PVEL = StoreGui.T_PVEL
                    objRobot.Z_PVEL = StoreGui.Z_PVEL

                    'WVEL
                    objRobot.HaveConfigWVEL = StoreGui.HaveConfigWVEL
                    objRobot.R_WVEL = StoreGui.R_WVEL
                    objRobot.T_WVEL = StoreGui.T_WVEL
                    objRobot.Z_WVEL = StoreGui.Z_WVEL
                End If
#End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return StoreGui
            AVPLib.Log.coreLogger.Info("Leave LoadStoreGui")
        End Function
        Private Shared Sub SetWaferInside(ByVal chamberName As String, ByRef ListValues As ArrayList, ByRef ListProperties As ArrayList, _
                                          ByRef StoreGui As DBStoreGui, ByRef cb As Chamber)

            Select Case chamberName
                'chamber 3
                Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                    If StoreGui.WaferChamber3 Is Nothing Then
                        ListValues.Add(String.Empty)
                    Else
                        ListValues.Add(StoreGui.WaferChamber3.WaferID)
                    End If
                    EquipmentManager.ChangeStatus(chamberName, ListProperties, ListValues)
                    cb = DataManagerment.EquipmentManager.GetEquipment(chamberName)
                    If cb IsNot Nothing AndAlso StoreGui.Chamber3WaferInfo IsNot Nothing Then
                        For i As Integer = 0 To StoreGui.Chamber3WaferInfo.Length - 1
                            cb.SetWaferInfo(StoreGui.Chamber3WaferInfo(i), i + 1)
                            Business.ControllerManager.SetWaferInsideChamber(chamberName, _
                                                                     IIf(StoreGui.Chamber3WaferInfo(i) IsNot Nothing, "On", "Off"), _
                                                                     StoreGui.Chamber3WaferInfo(i), False, i + 1)
                        Next
                    End If
                    'chamber 2
                Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                    If StoreGui.WaferChamber2 Is Nothing Then
                        ListValues.Add(String.Empty)
                    Else
                        ListValues.Add(StoreGui.WaferChamber2.WaferID)
                    End If
                    EquipmentManager.ChangeStatus(chamberName, ListProperties, ListValues)
                    cb = DataManagerment.EquipmentManager.GetEquipment(chamberName)
                    If cb IsNot Nothing AndAlso StoreGui.Chamber2WaferInfo IsNot Nothing Then
                        For i As Integer = 0 To StoreGui.Chamber2WaferInfo.Length - 1
                            cb.SetWaferInfo(StoreGui.Chamber2WaferInfo(i), i + 1)
                            Business.ControllerManager.SetWaferInsideChamber(chamberName, _
                                                                     IIf(StoreGui.Chamber2WaferInfo(i) IsNot Nothing, "On", "Off"), _
                                                                     StoreGui.Chamber2WaferInfo(i), False, i + 1)
                        Next
                    End If
                    'chamber 1
                Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                    If StoreGui.WaferChamber1 Is Nothing Then
                        ListValues.Add(String.Empty)
                    Else
                        ListValues.Add(StoreGui.WaferChamber1.WaferID)
                    End If
                    EquipmentManager.ChangeStatus(chamberName, ListProperties, ListValues)
                    cb = DataManagerment.EquipmentManager.GetEquipment(chamberName)
                    If cb IsNot Nothing AndAlso StoreGui.Chamber1WaferInfo IsNot Nothing Then
                        For i As Integer = 0 To StoreGui.Chamber1WaferInfo.Length - 1
                            cb.SetWaferInfo(StoreGui.Chamber1WaferInfo(i), i + 1)
                            Business.ControllerManager.SetWaferInsideChamber(chamberName, _
                                                                     IIf(StoreGui.Chamber1WaferInfo(i) IsNot Nothing, "On", "Off"), _
                                                                     StoreGui.Chamber1WaferInfo(i), False, i + 1)
                        Next
                    End If

            End Select

        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Nguyen Bao Trieu</Name>
        '''   	<Date>2008-11-12</Date>
        '''		<Description></Description>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-15</Date>
        '''		<Description>Fix bugs</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create equipments
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub CreateEquipments()
            AVPLib.Log.coreLogger.Info("Enter CreateEquipments")
            Try
                Dim chamber As Chamber = Nothing
                Dim intMaxOfPM As Integer = 3 'default for CX4
               
                For i As Integer = 1 To intMaxOfPM
                    Dim objModule As SystemModule = Nothing
                    Dim strName As String = ConstEnum.Chamber & i.ToString()
                    If AVPLib.ContainerData.IsChamberVisible(strName, objModule) Then
                        ''IBE
                        If objModule.Type = SystemModule.ModuleType.IBE Then
                            chamber = New IBEChamber
                            chamber.Name = strName
                            chamber.EquipmentType = SystemModule.ModuleType.IBE
                            m_htbEquipmentList.Add(chamber.Name, chamber)
                            ''PVD
                        ElseIf objModule.Type = SystemModule.ModuleType.PVD Then
                            chamber = New PVDChamber
                            chamber.Name = strName
                            chamber.EquipmentType = SystemModule.ModuleType.PVD
                            m_htbEquipmentList.Add(chamber.Name, chamber)
                            ''PVD4
                        ElseIf objModule.Type = SystemModule.ModuleType.PVD4 Then
                            chamber = New CoronaChamber(strName, objModule.MaxNumberOfSlot)
                            chamber.EquipmentType = SystemModule.ModuleType.PVD4
                            m_htbEquipmentList.Add(chamber.Name, chamber)
                            ''PVD5T
                        ElseIf objModule.Type = SystemModule.ModuleType.PVD5T Then
                            chamber = New PVD5TChamber(strName, objModule.MaxNumberOfSlot)
                            chamber.EquipmentType = SystemModule.ModuleType.PVD5T
                            m_htbEquipmentList.Add(chamber.Name, chamber)
                        End If
                        chamber.GEMModuleName = objModule.ModuleName
                    End If
                Next

                Dim LoadLockA As New LoadLock
                LoadLockA.Name = ConstEnum.Equipments.LoadLockA.ToString()
                AddHandler LoadLockA.WaferCountIncreased, AddressOf LoadLock_WaferCountIncreased
                m_htbEquipmentList.Add(LoadLockA.Name, LoadLockA)

                Dim LLElevatorA As New LLElevator(ConstEnum.Equipments.LLAElevator.ToString())
                m_htbEquipmentList.Add(LLElevatorA.Name, LLElevatorA)
                LoadLockA.Elevator = LLElevatorA

                If RobotConfigurationValues.LLA_CRYO_VISIBLE Then
                    Dim LLCryoA As New Cryo
                    LLCryoA.Name = ConstEnum.Equipments.LLAPumpPackage.ToString()
                    m_htbEquipmentList.Add(LLCryoA.Name, LLCryoA)
                ElseIf RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                    Dim LLATurbo As New Turbo
                    LLATurbo.Name = ConstEnum.Equipments.LLAPumpPackage.ToString()
                    m_htbEquipmentList.Add(LLATurbo.Name, LLATurbo)
                End If
                ''update gem
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(LoadLockA.Name, EMSERVICELib.VarType.SV, "LoadLockState", _
                                                    VALUELib.ValueType.U1, ConstEnum.LoadLockState.IDLE)

                If RobotConfigurationValues.ALINER_VISIBLE Then
                    Dim obAligner As New Aligner
                    obAligner.Name = ConstEnum.Equipments.Aligner.ToString()
                    obAligner.initialize()
                    m_htbEquipmentList.Add(obAligner.Name, obAligner)
                End If

                If RobotConfigurationValues.TMCRYO_VISIBLE Then
                    Dim TMCryo As New Cryo
                    TMCryo.Name = ConstEnum.Equipments.TMPumpPackage.ToString()
                    m_htbEquipmentList.Add(TMCryo.Name, TMCryo)
                ElseIf RobotConfigurationValues.TMTURBO_VISIBLE Then
                    Dim TMTurbo As New Turbo
                    TMTurbo.Name = ConstEnum.Equipments.TMPumpPackage.ToString()
                    m_htbEquipmentList.Add(TMTurbo.Name, TMTurbo)
                End If

                ' DeviceNetApp
                If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                    Dim obDeviceNetApp As New DeviceNetApp
                    obDeviceNetApp.Name = ConstEnum.Equipments.DeviceNetApp.ToString()
                    'obDeviceNetApp.initialize()
                    m_htbEquipmentList.Add(obDeviceNetApp.Name, obDeviceNetApp)
                End If

                If RobotConfigurationValues.TMWATERPUM_VISIBLE = True Then
                    Dim TMWaterPump As New WaterPump
                    TMWaterPump.Name = ConstEnum.Equipments.TMWaterPump.ToString()
                    m_htbEquipmentList.Add(TMWaterPump.Name, TMWaterPump)
                End If

                Dim transferModule As New CassettesModule
                transferModule.Name = ConstEnum.Equipments.CassettesModule.ToString()
                m_htbEquipmentList.Add(transferModule.Name, transferModule)

                'add rough pump machine to equipment list
                Dim listRough As Hashtable = ContainerDAO.RoughPumpConfigMap
                If (ContainerDAO.RoughPumpConfigMap IsNot Nothing) Then

                    For Each Item As DictionaryEntry In listRough
                        Dim EquipmentName As String = Item.Key.ToString
                        Dim RoughName As String = Item.Value.ToString
                        Dim objRoughPump As RoughPumpMachine = GetEquipment(RoughName)
                        If (objRoughPump IsNot Nothing) Then
                            objRoughPump.AddEquipmentWillBeUsed(EquipmentName)
                        Else
                            Dim objRoughPumpMachine As New RoughPumpMachine
                            objRoughPumpMachine.Name = RoughName
                            objRoughPumpMachine.AddEquipmentWillBeUsed(EquipmentName)
                            m_htbEquipmentList.Add(objRoughPumpMachine.Name, objRoughPumpMachine)
                        End If
                    Next
                End If

                Dim objRobot As New Robot
                objRobot.Name = ConstEnum.Equipments.Robot.ToString()
                m_htbEquipmentList.Add(objRobot.Name, objRobot)

                Dim objAlarm As New Alarm
                objAlarm.Name = ConstEnum.Equipments.Alarm.ToString()
                objAlarm.NumberLightAlarm = RobotConfigurationValues.NUMBER_LIGHT_ALARM
                objAlarm.NumberActiveLight = RobotConfigurationValues.NUMBER_ACTIVE_LIGHT
                m_htbEquipmentList.Add(objAlarm.Name, objAlarm)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CreateEquipments")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get equipment
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Function GetEquipment(ByVal Name As String) As Equipment
            Return EquipmentList.Item(Name)
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' Get Rough Equipment
        '''
        ''' </summary>
        ''' <param name="EquipmentName">
        ''' Equipment Using this Rough
        '''</param>
        ''' <remarks></remarks>
        Public Shared Function GetRoughPumpMachine(ByVal EquipmentName As String) As Equipment
            Try

                For Each Item As String In ContainerDAO.RoughPumpNameList
                    Dim objRoughPump As RoughPumpMachine = GetEquipment(Item)
                    If (objRoughPump IsNot Nothing AndAlso objRoughPump.CheckEquipmentUsedRough(EquipmentName)) Then
                        Return objRoughPump
                    End If
                Next

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try

            'not found
            Return Nothing
        End Function
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2009-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get equipment
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Function GetAllWaferInfor() As List(Of AVPWaferInfo)
            Dim lstwaferInfor As List(Of AVPWaferInfo) = New List(Of AVPWaferInfo)

            ' Get information on loadlock
            Dim LoadLockAElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())

            '#07/26/2011 
            '#-	CX7.  If LLB is not installed,  we cannot create a wafer @ TM screen because the “Wafer ID” drop down list 
            '# is not show when we try to select from this list.  Not sure about CX8.
            '#Begin fix.
            If LoadLockAElevator IsNot Nothing Then
                '#End fix
                Dim arrWaferOfLoadLockA As AVPLib.AVPWaferInfo() = LoadLockAElevator.ListOfWaferInfo()
                For i As Integer = 0 To arrWaferOfLoadLockA.Length - 1
                    Dim waferInfo As AVPWaferInfo = arrWaferOfLoadLockA(i)
                    If waferInfo IsNot Nothing Then
                        lstwaferInfor.Add(waferInfo)
                    End If
                Next
            End If

            ' Get information on Chambers
            Dim cb1 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
            If cb1 IsNot Nothing Then
                For i As Int16 = 1 To cb1.NumberOfWafer
                    If cb1.GetWaferInfo(i) IsNot Nothing Then
                        lstwaferInfor.Add(cb1.GetWaferInfo(i))
                    End If
                Next
            End If

            Dim cb2 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
            If cb2 IsNot Nothing Then
                For i As Int16 = 1 To cb2.NumberOfWafer
                    If cb2.GetWaferInfo(i) IsNot Nothing Then
                        lstwaferInfor.Add(cb2.GetWaferInfo(i))
                    End If
                Next
            End If

            Dim cb3 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
            If cb3 IsNot Nothing Then
                For i As Int16 = 1 To cb3.NumberOfWafer
                    If cb3.GetWaferInfo(i) IsNot Nothing Then
                        lstwaferInfor.Add(cb3.GetWaferInfo(i))
                    End If
                Next
            End If

            ' Get information on Aligner
            Dim aligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
            If aligner IsNot Nothing Then
                If aligner.GetWaferInfo() IsNot Nothing Then
                    lstwaferInfor.Add(aligner.GetWaferInfo())
                End If
            End If

            ' Get information on Robot
            Dim robot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
            If robot IsNot Nothing Then
                If robot.GetWaferInfo() IsNot Nothing Then
                    lstwaferInfor.Add(robot.GetWaferInfo())
                End If
            End If

            Return lstwaferInfor
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Change status EquipmentManager
        ''' </summary>
        ''' <param name="EquipmentName"></param>
        ''' <param name="PropertyNames"></param>
        ''' <param name="ReplyValues"></param>
        ''' <remarks></remarks>
        Public Shared Sub ChangeStatus(ByVal EquipmentName As String, ByVal PropertyNames As ArrayList, ByVal ReplyValues As ArrayList)
            AVPLib.Log.coreLogger.Info("Enter ChangeStatus")
            Try
                Dim e As Equipment = EquipmentManager.GetEquipment(EquipmentName)
                If (e IsNot Nothing) Then
                    e.ChangeStatus(PropertyNames, ReplyValues)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ChangeStatus")
        End Sub

        Public Shared Sub ChangeStatus(ByVal EquipmentName As String, ByVal PropertyName As String, ByVal ReplyValue As String)
            AVPLib.Log.coreLogger.Info("Enter ChangeStatus")
            Try
                Dim objEquipment As Equipment = EquipmentManager.GetEquipment(EquipmentName)
                If (objEquipment IsNot Nothing) Then
                    Dim ListMessage As ArrayList = MessageGenerator.CreateMessage(EquipmentName, PropertyName, ReplyValue)
                    For Each Message As String In ListMessage
                        Dim sce As New StatusChangedEventArgs()
                        sce.Message = Message
                        sce.ChamberName = EquipmentName
                        objEquipment.StatusChanged(objEquipment, sce)
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ChangeStatus")
        End Sub

#End Region

#Region "Private methods"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Handle wafer count increased
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="wfc"></param>
        ''' <remarks></remarks>
        Private Shared Sub LoadLock_WaferCountIncreased(ByVal sender As Object, ByVal wfc As WaferCountEventArgs)
            AVPLib.Log.coreLogger.Info("Enter LoadLock_WaferCountIncreased")
            Try
                Dim lla As LoadLock = CType(GetEquipment(ConstEnum.Equipments.LoadLockA.ToString()), LoadLock)
                If (lla IsNot Nothing) Then
                    RaiseInforToLLA(lla.WaferCount, String.Empty, String.Empty)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave LoadLock_WaferCountIncreased")
        End Sub

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-01-14</date>
        ''' </author>
        ''' <summary>
        ''' Raise WaferCount To Gui
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub RaiseInforToLLA(ByVal intSumWaferCount As Integer, ByVal strLotID As String, ByVal strSeqID As String)
            AVPLib.Log.coreLogger.Info("Enter RaiseWaferCountToLLA")
            Try
                AVPLib.DataManagerment.EquipmentManager.ChangeStatus("LoadLockA", "SumWaferCount", intSumWaferCount.ToString())
                If Not String.IsNullOrEmpty(strLotID) Then
                    AVPLib.DataManagerment.EquipmentManager.ChangeStatus("LoadLockA", "LotID", strLotID)
                End If
                If Not String.IsNullOrEmpty(strSeqID) Then
                    AVPLib.DataManagerment.EquipmentManager.ChangeStatus("LoadLockA", "SequenceID", strSeqID)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseWaferCountToLLA")
        End Sub

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-01-26</date>
        ''' </author>
        ''' <summary>
        ''' Raise WaferCount To Gui
        ''' </summary>
        ''' <remarks></remarks>
        'Private Shared Sub RaiseWaferCountToLoader(ByVal intSumWaferCount As Integer)
        '    AVPLib.Log.coreLogger.Info("Enter RaiseWaferCountToLoader")
        '    Try
        '        AVPLib.DataManagerment.EquipmentManager.ChangeStatus("Loader", "WaferCount", intSumWaferCount.ToString())
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    AVPLib.Log.coreLogger.Info("Leave RaiseWaferCountToLLA")
        'End Sub

        Private Shared Sub RaiseLastUsedAlignerRecipeToGui(ByVal lastUsedAlignerRecipe As String)
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrPropertyValues As New ArrayList()

                arrPropertyNames.Add("LastUsedAlignerRecipe")
                arrPropertyValues.Add(lastUsedAlignerRecipe)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus("CassettesModule", arrPropertyNames, arrPropertyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
#End Region

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

    End Class
End Namespace
