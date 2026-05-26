Imports AVPLib.ConstEnum
Imports AVPSecsGemLib
Imports System.Xml

Public Class ContainerDAO
#Region "Class Constants & Variables"
    ''System WaferFlow
    Public Shared FPath_WaferFlow As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\WaferFlows\"
    'User - Group
    Public Shared FPath_User As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\User.dat"
    Private Shared FPath_Group As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\Group.dat"

    'Robot Config
    Public Shared FPath_SerialCommandEquipments As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\SerialCommandEquipments.dat"

    'Message Recipe
    Private Shared FPath_Recipe As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\Recipe.dat"
    Public Shared FPath_ChamberConfig As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private"
    Public Shared FPath_ChamberRecipe As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\Recipes"
    Public Shared FPath_GEMData_WaferFlow As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\GEMData\WAFERFLOW."
    Public Shared FPath_GEMData_Recipe As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\GEMData\RECIPE."
    Public Shared FPath_GEMData_Sequence As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\GEMData\SEQUENCE."
    Public Shared FPath_GEMData As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\GEMData\"

    'Sequence
    Public Shared FPath_MessageGuiBusiness As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\ParseMessageGuiBusiness.dat"

    Public Shared FPath_ProcessCommand As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\ProcessCommand.dat"

    Public Shared FPath_MessageEquipment As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\ParseMessageName.dat"

    Public Shared FPath_ValueMessageEquipment As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\ParseMessageValue.dat"
    Public Shared FPath_DriverConfig As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\DriverConfig.xml"
    Public Shared FPath_ConfigurationServer As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\UserConfig\ConfigurationServer.dat"
    Public Shared FPVDConfigName As String = "PVDConfig.xml"
    Public Shared FIBEConfigName As String = "IBEConfig.xml"
    Public Shared FCORONAConfigName As String = "PVD4Config.xml"
    Public Shared PVD5TConfigName As String = "PVD5TConfig.xml"
    Public Shared FCalFactFile As String = "CALFACT.xml"
    Public Shared FPath_PMConfigFiles As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\PMConfigFiles"

    Public Shared FPath_SystemConfig As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\public\SystemConfig.dat"
    Public Shared PVD5TPath_SystemConfig As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\public\PVD5TSystemConfig.dat"
    'Public Shared FPath_SystemConfig_CX7 As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\public\SystemConfig_CX7.dat"
    'Public Shared FPath_SystemConfig_CX8 As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\public\SystemConfig_CX8.dat"
    'Sequence
    Public Shared FPath_SequenceData As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\JobFiles"
    'RunningDataFile
    Public Shared FPath_TempData As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "RunningRecipes"
    'Graph 
    Public Shared FPath_GraphData_RateOfRise As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\GraphFiles\RateOfRise"
    Public Shared FPath_GraphData_RecoverPressure As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\GraphFiles\RecoverPressure"
    Public Shared FPath_GraphData_RateOfRise_SL As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\RateOfRise"
    Public Shared FPath_GraphData_PumpdownCurve_SL As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\PumpdownCurve"
    Public Shared FPath_GraphData_PDC As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\GraphFiles\PDC"
    'Wafer Run
    Public Shared FPath_RunDataOfWafer As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\DataRun"
    Public Shared FPath_LotDatalog As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\LotDatalog"
    Public Shared FPath_DataRunFolderConfigByUser As String = FPath_RunDataOfWafer
    'IBE Maintenance
    Private Shared FPath_IBEMaintenance As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\IBEServer.dat"
    Private Shared FPath_PVDMaintenance As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\PVDServer.dat"
    Public Shared FIBEGUIConfigParameterName As String = "GUIConfigParameter.xml"

    'Store Gui
    Public Shared FPath_StoreGui As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\StoreGui.xml"
    Public Shared FPath_RevisionConfig As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\RevisionConfig.xml"

    Public Shared FPath_MessageName As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\MessageName.dat"
    Public Shared FPath_MessageValue As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\MessageValue.dat"

    'State Machine
    Public Shared FPath_ProcessJob As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\StateMachine\AVPE40-ProcessJob.xml"
    Public Shared FPath_ControlJob As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\StateMachine\AVPE94-ControlJob.xml"
    Public Shared FPath_EquipmentTracking As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\StateMachine\AVPE116-EquipmentTracking.xml"

    'PM Config
    Public Shared FPath_PM_SystemConfig As String = "/Configuration/SystemConfig"
    Public Shared FPath_PM_Parameters As String = "/Configuration/Parameters"

    Public Shared FPath_CalFactFile As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\CALFACT.xml"
    Public Shared FPath_RecipeTemplate As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\SystemConfig\private\"

    Private Shared m_PVD5TSystemConfigDoc As System.Xml.XmlDocument

#Region "Xml Document"
    'WaferFlow
    Private Shared m_WaferFlowDoc As System.Xml.XmlDocument
    'Store Gui
    Private Shared m_StoreGuiDoc As System.Xml.XmlDocument

    'IBE Maintenance
    Private Shared m_IBEMaintenanceDoc As System.Xml.XmlDocument
    'PVD Maintenance
    Private Shared m_PVDMaintenanceDoc As System.Xml.XmlDocument

    'User - Group
    Private Shared m_UserDoc As System.Xml.XmlDocument
    Private Shared m_GroupDoc As System.Xml.XmlDocument

    'Message Recipe
    Private Shared m_MessageDoc As System.Xml.XmlDocument

    'Robot Config
    Private Shared m_MessageTextDoc As System.Xml.XmlDocument
    Private Shared m_ComboItemDoc As System.Xml.XmlDocument

    'Recipe
    Private Shared m_RecipeDoc As System.Xml.XmlDocument
    Private Shared m_ChamberDocMap As Hashtable
    Private Shared m_ListChamberDocMap As Hashtable

    'Sequence
    Private Shared m_SequenceDoc As System.Xml.XmlDocument
    Private Shared m_SequenceDataDocMap As Hashtable

    Private Shared m_MessageGuiBusinessDoc As System.Xml.XmlDocument

    Private Shared m_ProcessCommandDoc As System.Xml.XmlDocument

    Private Shared m_MessageEquipmentDoc As System.Xml.XmlDocument

    Private Shared m_ValueMessageEquipmentDoc As System.Xml.XmlDocument

    Private Shared m_MessageErrorDoc As System.Xml.XmlDocument

    Private Shared m_ConfigurationServerDoc As System.Xml.XmlDocument

    Private Shared m_DriverConfigDoc As System.Xml.XmlDocument

    Private Shared m_RevisionConfigDoc As System.Xml.XmlDocument
    'RoughPump congfig
    Private Shared m_RoughPumpConfigMap As Hashtable
    Private Shared m_RoughPumpList As List(Of String)

    ' Contains KepServer Tags.
    Private Shared m_KepServerDoc As System.Xml.XmlDocument

    ' Contains Configurable KepServer Tags.
    Private Shared m_ConfigurableKepServerDoc As System.Xml.XmlDocument

    ' Configurable Vent Pumpdown process.
    Private Shared m_ConfigurableVentPumpdownDoc As System.Xml.XmlDocument

    Private Shared m_InitConfigDoc As System.Xml.XmlDocument

    'Configuration
    Private Shared m_PressureConfigDoc As System.Xml.XmlDocument
    Private Shared m_SystemConfigDoc As System.Xml.XmlDocument

    'IBE Recipe Def
    Private Shared m_IBERecipeDoc As System.Xml.XmlDocument

    'State Machine
    Private Shared m_ProcessJobDoc As System.Xml.XmlDocument
    Private Shared m_ControlJobDoc As System.Xml.XmlDocument
    Private Shared m_EquipmentTrackingDoc As System.Xml.XmlDocument
#End Region
#End Region

#Region "Properties"
#Region "StateMachine"
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' WaferFlowDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property ProcessJobDoc() As System.Xml.XmlDocument
        Get
            If m_ProcessJobDoc Is Nothing Then
                LoadProcessJob()
            End If
            Return m_ProcessJobDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_ProcessJobDoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' WaferFlowDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property ControlJobDoc() As System.Xml.XmlDocument
        Get
            If m_ControlJobDoc Is Nothing Then
                LoadControlJob()
            End If
            Return m_ControlJobDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_ControlJobDoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' WaferFlowDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property EquipmentTrackingDoc() As System.Xml.XmlDocument
        Get
            If m_EquipmentTrackingDoc Is Nothing Then
                LoadEquipmentTracking()
            End If
            Return m_EquipmentTrackingDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_EquipmentTrackingDoc = value
        End Set
    End Property
#End Region

#Region "WaferFlowDoc"
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' WaferFlowDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Shared Property WaferFlowDoc() As System.Xml.XmlDocument
    '    Get
    '        If m_WaferFlowDoc Is Nothing Then
    '            LoadSystemWaferFlow()
    '        End If
    '        Return m_WaferFlowDoc
    '    End Get
    '    Set(ByVal value As System.Xml.XmlDocument)
    '        m_WaferFlowDoc = value
    '    End Set
    'End Property
#End Region

#Region "StoreGuiDoc"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' StoreGui
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Property StoreGuiDoc() As System.Xml.XmlDocument
        Get
            If m_StoreGuiDoc Is Nothing Then
                m_StoreGuiDoc = New System.Xml.XmlDocument()
                Try
                    m_StoreGuiDoc.Load(FPath_StoreGui)
                    'm_StoreGuiDoc = BinarySerialize.Open_DatFileConfig(FPath_StoreGui)
                Catch ex As Exception
                    'try to load the local file
                    m_StoreGuiDoc.LoadXml(XMLResources.StoreGui.XMLText)
                    m_StoreGuiDoc.Save(FPath_StoreGui)
                    'BinarySerialize.SaveTo_DatFileConfig(FPath_StoreGui, m_StoreGuiDoc)
                End Try
            End If
            Return m_StoreGuiDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_StoreGuiDoc = value
        End Set
    End Property
#End Region

#Region "CORONA-Corona Maintenance Doc"
    Public Shared Sub AddDBCommandItem(ByRef nameMap As Hashtable, ByRef codeMap As Hashtable, ByVal commandName As String, ByVal commandCode As String, ByVal propertyName As String, ByVal decoderName As String)
        Try
            nameMap.Add(commandName, New DBCommand(commandName, commandCode, propertyName, decoderName))
            codeMap.Add(commandCode, New DBCommand(commandName, commandCode, propertyName, decoderName))
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub GetDeviceNetAppMaintenance(ByRef nameMap As Hashtable, ByRef codeMap As Hashtable)
        Try ''use this function for DeviceNetApp
            nameMap.Clear()
            codeMap.Clear()

            Dim xmlDoc As System.Xml.XmlDocument = DriverConfigDoc()
            Dim root As System.Xml.XmlNode = xmlDoc.FirstChild
            Dim lstSolenoidMacID As List(Of String) = New List(Of String)

            Dim dicModel As Dictionary(Of String, String) = Nothing
            Dim nodeRSTiModel As Xml.XmlNode = xmlDoc.SelectSingleNode("/DriverConfiguration/Project/RSTiModel")
            If nodeRSTiModel IsNot Nothing Then
                dicModel = New Dictionary(Of String, String)
                For Each childNodeRSTiModel As Xml.XmlNode In nodeRSTiModel.ChildNodes
                    If childNodeRSTiModel Is Nothing OrElse childNodeRSTiModel.Attributes.Count < 4 Then
                        Continue For
                    End If
                    dicModel.Add(childNodeRSTiModel.InnerText, childNodeRSTiModel.Attributes("Type").Value)
                Next
            End If

            For Each ProjectGroup As System.Xml.XmlNode In root.ChildNodes
                Dim ProjectNameNode As Xml.XmlAttribute = ProjectGroup.Attributes.ItemOf("Name")
                If ProjectNameNode IsNot Nothing AndAlso ProjectNameNode.Value = "CX4" Then

                    For Each xmlDriver As System.Xml.XmlNode In ProjectGroup.ChildNodes
                        If xmlDriver.Name = "Driver" Then
                            ' Get infor
                            Dim attName As Xml.XmlAttribute = xmlDriver.Attributes("Name")
                            Dim attInstall As Xml.XmlAttribute = xmlDriver.Attributes("IsInstalled")
                            Dim attCommType As Xml.XmlAttribute = xmlDriver.Attributes("CommType")
                            Dim attDeviceType As Xml.XmlAttribute = xmlDriver.Attributes("DeviceType")
                            Dim attMacID As Xml.XmlAttribute = xmlDriver.Attributes("MacID")

                            'apply -> Isolation Valve
                            Dim attOpenBitIndex As Xml.XmlAttribute = xmlDriver.Attributes("OpenBitIndex")
                            Dim attCloseBitIndex As Xml.XmlAttribute = xmlDriver.Attributes("CloseBitIndex")
                            'Apply -> other valve
                            Dim attBitIndex As Xml.XmlAttribute = xmlDriver.Attributes("BitIndex")

                            ' If equipment not installed, skip
                            If attInstall.InnerText = "False" OrElse attCommType.InnerText <> "DeviceNet" Then
                                Continue For
                            End If

                            Select Case attDeviceType.InnerText
                                Case Driver.DeviceType.RoughValve.ToString(), Driver.DeviceType.VentValve.ToString(), Driver.DeviceType.HivacValve.ToString(), _
                                        Driver.DeviceType.IsolationValve.ToString(), Driver.DeviceType.TurboForeLineValve.ToString()
                                    If attDeviceType.InnerText = Driver.DeviceType.RoughValve.ToString() OrElse _
                                       attDeviceType.InnerText = Driver.DeviceType.VentValve.ToString() OrElse _
                                       attDeviceType.InnerText = Driver.DeviceType.TurboForeLineValve.ToString() OrElse _
                                       attDeviceType.InnerText = Driver.DeviceType.HivacValve.ToString() Then

                                        Dim iSolenoidBit As Int16 = Convert.ToInt16(attBitIndex.InnerText) - 1
                                        AddDBCommandItem(nameMap, codeMap, attName.InnerText, attMacID.InnerText & ",1,-1," & iSolenoidBit.ToString() & ",SolenoidBitOnOff", "", "")
                                    ElseIf attDeviceType.InnerText = Driver.DeviceType.IsolationValve.ToString() Then

                                        Dim iOpenBit As Int16 = Convert.ToInt16(attOpenBitIndex.InnerText) - 1
                                        Dim iCloseBit As Int16 = Convert.ToInt16(attCloseBitIndex.InnerText) - 1
                                        AddDBCommandItem(nameMap, codeMap, attName.InnerText & ".Open", attMacID.InnerText & ",1,-1," & iOpenBit.ToString() & ",SolenoidBitOnOff", "", "")
                                        AddDBCommandItem(nameMap, codeMap, attName.InnerText & ".Close", attMacID.InnerText & ",1,-1," & iCloseBit.ToString() & ",SolenoidBitOnOff", "", "")
                                    End If

                                    ' Those will receive status through RSTi
                                    If attDeviceType.InnerText <> Driver.DeviceType.IsolationValve.ToString() AndAlso attDeviceType.InnerText <> Driver.DeviceType.HivacValve.ToString() Then

                                        Dim strPropertyName As String = attName.InnerText.Replace(".", "")
                                        Dim iSolenoidBit As Int16 = Convert.ToInt16(attBitIndex.InnerText) - 1
                                        AddDBCommandItem(nameMap, codeMap, strPropertyName, attMacID.InnerText & "_BitStatus" & iSolenoidBit.ToString(), strPropertyName, "WorkingStatuses")
                                    End If

                                    If Not lstSolenoidMacID.Contains(attMacID.InnerText) Then
                                        ' Store Solenoid MacID
                                        lstSolenoidMacID.Add(attMacID.InnerText)
                                    End If

                                Case Driver.DeviceType.IG.ToString()
                                    Dim strPropertyName As String = attName.InnerText.Replace(".Ion", "Ion")
                                    AddDBCommandItem(nameMap, codeMap, attName.InnerText & ".FilamentOnOff", attMacID.InnerText & ",2,-1,-1,FilamentOnOff", "", "")
                                    AddDBCommandItem(nameMap, codeMap, attName.InnerText & ".IGDegasOnOff", attMacID.InnerText & ",2,-1,-1,IGDegasOnOff", "", "")
                                    AddDBCommandItem(nameMap, codeMap, attName.InnerText & ".IGSelectFilament", attMacID.InnerText & ",2,-1,-1,IGSelectFilament", "", "")
                                    AddDBCommandItem(nameMap, codeMap, strPropertyName & "Status", attMacID.InnerText & "_Status", strPropertyName & "Status", "WorkingStatuses")
                                    AddDBCommandItem(nameMap, codeMap, strPropertyName & "Pressure", attMacID.InnerText & "_Pressure", strPropertyName & "Pressure", "Double")
                                    AddDBCommandItem(nameMap, codeMap, strPropertyName & "Com", attMacID.InnerText & "_DeviceStatus", strPropertyName & "Com", "WorkingStatuses")
                                    AddDBCommandItem(nameMap, codeMap, strPropertyName & "Filament", attMacID.InnerText & "_Filament", strPropertyName & "Filament", "Double")

                                Case Driver.DeviceType.CG.ToString(), Driver.DeviceType.MPumpCG.ToString(), Driver.DeviceType.TurboForeLine.ToString()
                                    Dim strPropertyName As String = attName.InnerText.Replace(".", "")
                                    AddDBCommandItem(nameMap, codeMap, attName.InnerText, attMacID.InnerText & ",3,-1,-1,", "", "")
                                    AddDBCommandItem(nameMap, codeMap, strPropertyName & "Status", attMacID.InnerText & "_CGRelay", strPropertyName & "Status", "WorkingStatuses")
                                    AddDBCommandItem(nameMap, codeMap, strPropertyName & "Pressure", attMacID.InnerText & "_Pressure", strPropertyName & "Pressure", "Double")
                                    AddDBCommandItem(nameMap, codeMap, strPropertyName & "Com", attMacID.InnerText & "_DeviceStatus", strPropertyName & "Com", "WorkingStatuses")

                            End Select

                        ElseIf xmlDriver.Name = "BlockDevice" AndAlso Not RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                            Dim atMacID As Xml.XmlAttribute = xmlDriver.Attributes("MacID")
                            If Not String.IsNullOrEmpty(atMacID.Value) Then
                                If dicModel Is Nothing Then
                                    Continue For
                                End If

                                AddDBCommandItem(nameMap, codeMap, "RSTiCom", atMacID.Value & "_DeviceStatus", "RSTiCom", "WorkingStatuses")

                                For Each xmlChildBlock As System.Xml.XmlNode In xmlDriver.ChildNodes
                                    Dim attName As Xml.XmlAttribute = xmlChildBlock.Attributes("Name")
                                    Dim attDeviceType As Xml.XmlAttribute = xmlChildBlock.Attributes("DeviceType")
                                    Dim attModelID As Xml.XmlAttribute = xmlChildBlock.Attributes("ModelID")
                                    Dim attSlotID As Xml.XmlAttribute = xmlChildBlock.Attributes("SlotID")
                                    Dim attChannelID As Xml.XmlAttribute = xmlChildBlock.Attributes("ChannelID")

                                    If attName.InnerText.Contains("Alarm.ToBeDefine") Then
                                        Continue For
                                    End If

                                    If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = FOURLIGHTALARM Then

                                        If attName.InnerText.Contains("Alarm.OrangeStatus") Then
                                            attChannelID.InnerText = "6"
                                        End If

                                        If attName.InnerText.Contains("Alarm.BlueStatus") Then
                                            attChannelID.InnerText = "8"
                                        End If
                                    ElseIf attName.InnerText.Contains("Alarm.BlueStatus") Then
                                        Continue For
                                    End If

                                    Dim strPropertyName = attName.InnerText.Replace(".", "").Replace(" ", "")
                                    AddDBCommandItem(nameMap, codeMap, strPropertyName, atMacID.Value & "_Slot" & attSlotID.InnerText & "_Channel" & attChannelID.InnerText, strPropertyName, "WorkingStatuses")
                                    If dicModel.ContainsKey(attModelID.InnerText) AndAlso dicModel(attModelID.InnerText) = "DO" Then
                                        AddDBCommandItem(nameMap, codeMap, attName.InnerText, atMacID.Value & ",7," & attSlotID.InnerText & "," & attChannelID.InnerText & ",RSTiBitOnOff", "", "")
                                    End If
                                    
                                Next
                            End If
                        End If
                    Next
                End If
            Next

            If lstSolenoidMacID.Count > 0 Then
                AddDBCommandItem(nameMap, codeMap, "DeviceNetBus", "0_DeviceStatus", "DeviceNetBus", "WorkingStatuses")
                For Each macID As String In lstSolenoidMacID
                    AddDBCommandItem(nameMap, codeMap, "SolenoidBlock" & macID & "Com", macID & "_DeviceStatus", "SolenoidBlock" & macID & "Com", "WorkingStatuses")
                Next
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Public Shared Sub GetPVD5TMaintenance(ByRef nameMap As Hashtable, ByRef codeMap As Hashtable)
        Try ''use this function for pvd
            nameMap.Clear()
            codeMap.Clear()

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.REQUEST_ALL_DATA.ToString(), "M,01,18,01", "", "")
            '<--- System #1--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.KEEP_ALIVE.ToString(), "M,01,01,01", "Keep_Alive", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.OVERRIDE_MODE.ToString(), "M,01,02,01", "Override_Mode", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.ALARM_STATUS_READBACK.ToString(), "M,01,03,02", "StatusMessage", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.EVENT_STATUS_READBACK.ToString(), "M,01,04,02", "EventMessage", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.MAINTENAINCE_MODE.ToString(), "M,01,05,01", "MaintenanceMode", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET1_SET_KWH_USAGE.ToString(), "M,01,06,01", "Target1_Set_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET1_KWH_USAGE.ToString(), "M,01,06,02", "Target1_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET2_SET_KWH_USAGE.ToString(), "M,01,07,01", "Target2_Set_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET2_KWH_USAGE.ToString(), "M,01,07,02", "Target2_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET3_SET_KWH_USAGE.ToString(), "M,01,08,01", "Target3_Set_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET3_KWH_USAGE.ToString(), "M,01,08,02", "Target3_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET4_SET_KWH_USAGE.ToString(), "M,01,09,01", "Target4_Set_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET4_KWH_USAGE.ToString(), "M,01,09,02", "Target4_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET5_SET_KWH_USAGE.ToString(), "M,01,19,01", "Target5_Set_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET5_KWH_USAGE.ToString(), "M,01,19,02", "Target5_Kwh_Usage", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET_SELECT_PROGRAM.ToString(), "M,01,10,01", "Target_Select_Program", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET_SELECT_READBACK.ToString(), "M,01,10,02", "Target_Select_Readback", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET1_SET_SHIELD_QUART.ToString(), "M,01,12,01", "Target1_Set_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET1_SHIELD_QUART.ToString(), "M,01,12,02", "Target1_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET2_SET_SHIELD_QUART.ToString(), "M,01,13,01", "Target2_Set_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET2_SHIELD_QUART.ToString(), "M,01,13,02", "Target2_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET3_SET_SHIELD_QUART.ToString(), "M,01,14,01", "Target3_Set_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET3_SHIELD_QUART.ToString(), "M,01,14,02", "Target3_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET4_SET_SHIELD_QUART.ToString(), "M,01,15,01", "Target4_Set_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET4_SHIELD_QUART.ToString(), "M,01,15,02", "Target4_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET5_SET_SHIELD_QUART.ToString(), "M,01,20,01", "Target5_Set_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET5_SHIELD_QUART.ToString(), "M,01,20,02", "Target5_Shield_Quart", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PLASMA_STATUS.ToString(), "M,01,16,02", "Plasma_Status", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_PLASMA_STATUS.ToString(), "M,01,17,02", "Bias_Plasma_Status", "WorkingStatuses")
            '<--- Recipe_Processing #2--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_WAFER_ID.ToString(), "M,02,01,01", "Process_Wafer_ID", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_RECIPE_NAME.ToString(), "M,02,02,01", "Process_Recipe_Name", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CONTROL_DEVICE.ToString(), "M,02,03,01", "RecipeProcessingStatus", "")
            'AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CONTROL_DEVICE_START.ToString(), "M,02,03,01", "Process_Control_Device_Start", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CONTROL_DEVICE_STOP.ToString(), "M,02,04,01", "Process_Control_Device_Stop", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CONTROL_DEVICE_PAUSE.ToString(), "M,02,05,01", "Process_Control_Device_Pause", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CONTROL_DEVICE_CONTINUE.ToString(), "M,02,06,01", "Process_Control_Device_Continue", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CONTROL_DEVICE_END_STEP.ToString(), "M,02,07,01", "Process_Control_Device_End_Step", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CONTROL_DEVICE_ERROR.ToString(), "M,02,08,02", "Process_Control_Device_Error", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CONTROL_DEVICE_RESET_ERROR.ToString(), "M,02,08,01", "Process_Control_Device_Reset_Error", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CONTROL_SEND_RUN_DATA_FILE_NAME.ToString(), "M,02,09,01", "Process_Control_Send_Run_Data_File_Name", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CONTROL_GET_RUN_DATA_FILE_NAME.ToString(), "M,02,10,01", "Process_Control_Get_Run_Data_File_Name", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.COPYRECIPE_TO_PMFOLDER.ToString(), "M,02,11,01", "StartCopyRecipeToPMFolder", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHECK_RECIPE_TEMPLATE_VERSION.ToString(), "M,02,21,01", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SYN_COPY_RECIPE_TEMPLATE.ToString(), "M,02,22,01", "StartCopyRecipeTemplate", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET_MODE.ToString(), "M,02,27,01", "Target_Mode", "String")

            '<---<---@Process Status--->--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_REMAINING_TIME.ToString(), "M,02,12,01", "Process_Remaining_Time", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_TOTAL_TIME.ToString(), "M,02,19,01", "Process_Total_Time", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_ELAPSED_TIME.ToString(), "M,02,13,01", "Process_Elapsed_Time", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CURRENT_STEP.ToString(), "M,02,14,01", "Process_Current_Step", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_TOTAL_STEPS.ToString(), "M,02,15,01", "Process_Total_Steps", "")
            'AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_PRESSURE.ToString(), "M,02,17,01", "Process_Pressure", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CURRENT_RECIPE_LOOP.ToString(), "M,02,26,01", "CurrentRecipeLoop", "")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_MODE.ToString(), "M,02,17,01", "Process_Mode", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_REVOLUTION_COUNT.ToString(), "M,02,18,01", "Process_Revolution_Count", "String")

            '<---'' <!--Wafer Processing Status -->--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WAFER_PROCESSING_STATUS_READBACK.ToString(), "M,02,16,01", "Wafer_Processing_Status_Readback", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CURRENT_AVP_TIME.ToString(), "M,02,20,01", "Current_AVP_Time", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WAFER_DELETE.ToString(), "M,02,16,02", "Wafer_Delete", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WAFER_SLOT.ToString(), "M,02,16,03", "Wafer_Slot", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_LOT_ID.ToString(), "M,02,23,01", "", "")

            '<--- Sequences # 3--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.AUTO_PUMPDOWN_SEQ.ToString(), "M,03,01,01", "Auto_Pumpdown_Seq_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.AUTO_VENT_SEQ.ToString(), "M,03,02,01", "Auto_Vent_Seq_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PUMP_PURGE_SEQ.ToString(), "M,03,03,01", "Pump_Purge_Seq_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.MACHINE_PUMPPURGE_CURRENT_CYCLE.ToString(), "M,03,10,01", "MachinePumpPurge_Current_Cycle", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.IG_DEGAS_SEQ.ToString(), "M,03,04,01", "IG_Degas_Seq_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SHUTDOWN_POWER_SEQ.ToString(), "M,03,05,01", "Shutdown_Power_Seq_Status", "WorkingStatuses")

            '<---ROR Sequence--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RATE_OF_RISE_SEQ.ToString(), "M,03,06,01", "RateOfRise_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RATE_OF_RISE_INTERVAL_RECORDING.ToString(), "M,03,06,03", "RateOfRise_Interval", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RATE_OF_RISE_SAMPLE.ToString(), "M,03,06,04", "RateOfRise_Sample", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RATE_OF_RISE_FILENAME.ToString(), "M,03,06,05", "RateOfRise_FileName", "")

            '<---PDC Sequence--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PUMPDOWN_CURVE_SEQ.ToString(), "M,03,07,01", "PumpDown_Curve_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PUMPDOWN_CURVE_INTERVAL_RECORDING.ToString(), "M,03,07,03", "PumpDown_Curve_Interval", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PUMPDOWN_CURVE_SAMPLE.ToString(), "M,03,07,04", "PumpDown_Curve_Sample", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PUMPDOWN_CURVE_FILENAME.ToString(), "M,03,07,05", "PumpDown_Curve_FileName", "")

            '<---Initialize_Motion--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.INITIALIZE_MOTION.ToString(), "M,03,08,03", "Initialize_Motion", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.INITIALIZED_MOTION.ToString(), "M,03,08,01", "Initialized_Motion", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.AUTO_POWER_SEQ.ToString(), "M,03,09,03", "Auto_Power_Seq", "WorkingStatuses")

            '<--- Gasses # 4--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS1_SHUTOFF_VALVE.ToString(), "M,04,01,03", "Gas1_Shutoff_Valve", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS2_SHUTOFF_VALVE.ToString(), "M,04,02,03", "Gas2_Shutoff_Valve", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS3_SHUTOFF_VALVE.ToString(), "M,04,03,03", "Gas3_Shutoff_Valve", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS4_SHUTOFF_VALVE.ToString(), "M,04,04,03", "Gas4_Shutoff_Valve", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS5_SHUTOFF_VALVE.ToString(), "M,04,05,03", "Gas5_Shutoff_Valve", "WorkingStatuses")

            '<---<--Gas Mfc-->--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS1_FLOWRATE_PROGRAM.ToString(), "M,04,01,01", "Gas1_Flowrate_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS2_FLOWRATE_PROGRAM.ToString(), "M,04,02,01", "Gas2_Flowrate_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS3_FLOWRATE_PROGRAM.ToString(), "M,04,03,01", "Gas3_Flowrate_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS4_FLOWRATE_PROGRAM.ToString(), "M,04,04,01", "Gas4_Flowrate_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS5_FLOWRATE_PROGRAM.ToString(), "M,04,05,01", "Gas5_Flowrate_Program", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS1_FLOWRATE_READBACK.ToString(), "M,04,01,02", "Gas1_Flowrate_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS2_FLOWRATE_READBACK.ToString(), "M,04,02,02", "Gas2_Flowrate_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS3_FLOWRATE_READBACK.ToString(), "M,04,03,02", "Gas3_Flowrate_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS4_FLOWRATE_READBACK.ToString(), "M,04,04,02", "Gas4_Flowrate_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS5_FLOWRATE_READBACK.ToString(), "M,04,05,02", "Gas5_Flowrate_Readback", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.MAIN_DIST_VALVE.ToString(), "M,04,06,01", "Main_Dist_Valve", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SEC_DIST_VALVE.ToString(), "M,04,07,01", "Sec_Dist_Valve", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS1_MFC_DEVICENET_STATUS_READBACK.ToString(), "M,18,01,02", "Gas1MFCDevinetStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS2_MFC_DEVICENET_STATUS_READBACK.ToString(), "M,18,02,02", "Gas2MFCDevinetStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS3_MFC_DEVICENET_STATUS_READBACK.ToString(), "M,18,03,02", "Gas3MFCDevinetStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS4_MFC_DEVICENET_STATUS_READBACK.ToString(), "M,18,04,02", "Gas4MFCDevinetStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.GAS5_MFC_DEVICENET_STATUS_READBACK.ToString(), "M,18,05,02", "Gas5MFCDevinetStatus", "WorkingStatuses")

            '<--- Valves # 5--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.ROUGH_VALVE_STATUS.ToString(), "M,05,01,01", "RoughValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.VENT_VALVE_STATUS.ToString(), "M,05,02,01", "VentValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.ISOLATION_VALVE_STATUS.ToString(), "M,05,03,01", "Isolation_Valve_Status", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HIVAC_VALVE_STATUS.ToString(), "M,05,04,01", "Hivac_Valve_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FORELINE_VALVE_STATUS.ToString(), "M,05,05,01", "ForelineValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BARATRON_VALVE_STATUS.ToString(), "M,05,07,01", "Baratron_Valve_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.ROUGH_PUMP_IN_USE.ToString(), "M,05,14,01", "Rough_Pump_In_Use", "")

            '<--- Pressure # 6--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.IG_PRESSURE.ToString(), "M,06,01,02", "IG", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.IG_STATUS.ToString(), "M,06,01,03", "IGStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SWITCH_IG_FILAMENT_PROGRAM.ToString(), "M,06,01,05", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SWITCH_IG_FILAMENT_READBACK.ToString(), "M,06,01,04", "SwitchIGFilament", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.ENABLE_IG_FILAMENT_READBACK.ToString(), "M,06,01,06", "EnableIGFilament", "Integer")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CG_PRESSURE.ToString(), "M,06,02,02", "CG", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CG_RELAY_STATUS.ToString(), "M,06,02,03", "CG_Relay_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBER_CG_ATM.ToString(), "M,06,02,05", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.ENABLE_SET_CHAMBER_CG_ATM.ToString(), "M,06,02,06", "ATMChamberCGStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBER_CG_VAC.ToString(), "M,06,02,07", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.ENABLE_SET_CHAMBER_CG_VAC.ToString(), "M,06,02,08", "VACChamberCGStatus", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FORELINE_CG_PRESSURE.ToString(), "M,06,03,02", "Foreline_CG_Pressure", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FORELINE_CG_RELAY_STATUS.ToString(), "M,06,03,03", "Foreline_CG_Relay_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FORELINE_CG_ATM.ToString(), "M,06,03,05", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.ENABLE_SET_FORELINE_CG_ATM.ToString(), "M,06,03,06", "ATMForelineCGStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BARATRON_PRESSURE.ToString(), "M,06,05,02", "Baratron_Pressure", "Double")

            '<---<--Mechanical Pump CG-->--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.MECHANICAL_PUMP_CG_PRESSURE.ToString(), "M,06,06,02", "Mechanical_Pump_CG_Pressure", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.MECHANICAL_PUMP_CG_RELAY_STATUS.ToString(), "M,06,06,03", "Mechanical_Pump_CG_Relay_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.MECHANICAL_PUMP_STATUS.ToString(), "M,06,06,04", "Mechanical_Pump_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.MECHANICAL_PUMP_CG_ATM.ToString(), "M,06,06,05", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.ENABLE_SET_MECHANICAL_PUMP_CG_ATM.ToString(), "M,06,06,06", "ATMMechanicalPumpCGStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.MECHANICAL_PUMP_COM_SERIAL.ToString(), "M,06,06,07", "MPump_Serial_Communication_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.MECHANICAL_PUMP_WAITTING_ON.ToString(), "M,06,06,08", "WaitingMPON", "String")

            '<--- Interlocks # 7--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_SUBSTRATE_TABLE_WATER_STATUS.ToString(), "M,07,01,02", "Chamberinterlock_Substrate_Table_Water_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_AIR_PRESSURE_STATUS.ToString(), "M,07,02,02", "Chamberinterlock_Air_Pressure_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_DOOR_CLOSED_STATUS.ToString(), "M,07,03,02", "Chamberinterlock_Door_Closed_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_LID_CLOSED_STATUS.ToString(), "M,07,04,02", "Chamberinterlock_Lid_Closed_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_TURBO_WATER_STATUS.ToString(), "M,07,05,02", "Chamberinterlock_Turbo_Water_Status", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_TARGET_MB_WATER_STATUS.ToString(), "M,07,06,02", "Chamberinterlock_Target_MB_Water_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_BIAS_MB_WATER_STATUS.ToString(), "M,07,07,02", "Chamberinterlock_Bias_MB_Water_Status", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_TARGET1_WATER_STATUS.ToString(), "M,07,08,02", "Chamberinterlock_Target1_Water_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_TARGET2_WATER_STATUS.ToString(), "M,07,09,02", "Chamberinterlock_Target2_Water_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_TARGET3_WATER_STATUS.ToString(), "M,07,10,02", "Chamberinterlock_Target3_Water_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_TARGET4_WATER_STATUS.ToString(), "M,07,11,02", "Chamberinterlock_Target4_Water_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_TARGET5_WATER_STATUS.ToString(), "M,07,12,02", "Chamberinterlock_Target5_Water_Status", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_PS_INTERLOCK_STATUS.ToString(), "M,07,13,01", "Chamberinterlock_PS_Interlock_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_DEVICENET_COMM.ToString(), "M,07,14,02", "Chamberinterlock_Devicenet_Comm", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CHAMBERINTERLOCK_TARGET_PANELS.ToString(), "M,07,15,02", "Chamberinterlock_Target_Panels", "WorkingStatuses")

            '<--- Motion # 8--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET1_SHUTTER_STATUS.ToString(), "M,08,01,01", "Target1_Shutter_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET2_SHUTTER_STATUS.ToString(), "M,08,02,01", "Target2_Shutter_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET3_SHUTTER_STATUS.ToString(), "M,08,03,01", "Target3_Shutter_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET4_SHUTTER_STATUS.ToString(), "M,08,04,01", "Target4_Shutter_Status", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_UP_DOWN_STATUS.ToString(), "M,08,05,01", "Substrate_Table_Up_Down_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_ROTATE_STATUS.ToString(), "M,08,06,01", "Substrate_Table_Rotate_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_ROTATE_SPEED.ToString(), "M,08,09,01", "Substrate_Table_Rotate_Speed", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_ROTATE_SPEED_READBACK.ToString(), "M,08,09,02", "Substrate_Table_Rotate_Speed_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_ROTATE_POS_IN_UNIT_READBACK.ToString(), "M,08,17,02", "Substrate_Table_Rotate_Pos_In_Unit_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.NUMBER_OF_UNIT_PER_REVOLUTION_READBACK.ToString(), "M,08,18,02", "Number_Of_Unit_Per_Revolution_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_CURRENT_STATION.ToString(), "M,08,07,02", "Substrate_Current_Station", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_GOTO_SLOT.ToString(), "M,08,08,01", "Substrate_Goto_Slot", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_ROTATE_HOME.ToString(), "M,08,10,01", "Substrate_Table_Rotate_Home", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_LIFT_HOME.ToString(), "M,08,13,01", "Substrate_Table_Lift_Home", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_LIFT_UP_DOWN_STATUS.ToString(), "M,08,11,01", "Substrate_Lift_Up_Down_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_CURRENT_POSITION_PROGRAM.ToString(), "M,08,12,01", "Substrate_Table_Current_Position_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_CURRENT_POSITION_READBACK.ToString(), "M,08,12,02", "Substrate_Table_Current_Position_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.IS_MOTIONINITIALIZED.ToString(), "M,08,14,01", "Is_MotionInitalized", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_ROTATE_SEQUENCE_STATE.ToString(), "M,08,15,02", "Substrate_Table_Rotate_Sequence_State", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.ROUND_SUBSTRATE_CURRENT_STATION.ToString(), "M,08,16,02", "Round_Substrate_Current_Station", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SUBSTRATE_TABLE_UP_DOWN_MOVING.ToString(), "M,08,19,02", "Substrate_Table_Up_Down_Moving", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.MOTION_COMMUNICATION_STATUS.ToString(), "M,08,20,02", "Motion_Communication_Status", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET5_SHUTTER_STATUS.ToString(), "M,08,21,01", "Target5_Shutter_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.SELECTED_SHUTTER_PROGRAM.ToString(), "M,08,22,01", "Substrate_Goto_Shutter", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CURRENT_SHUTTER_READBACK.ToString(), "M,08,22,02", "Current_Shutter_ReadBack", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HOME_SHUTTER_STATUS.ToString(), "M,08,23,01", "Home_Shutter_Status", "WorkingStatuses")

            '<--- Turbo_Waterpump # 9--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WATER_PUMP_T_READBACK.ToString(), "M,09,01,01", "Water_Pump_T_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WATER_PUMP_STATUS.ToString(), "M,09,02,01", "Water_Pump_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WATER_PUMP_REGEN_STATUS.ToString(), "M,09,03,01", "Water_Pump_Regen_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WATER_PUMP_STATE_STATUS.ToString(), "M,09,04,01", "Water_Pump_State_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WATER_PUMP_REGEN_HOUR_READBACK.ToString(), "M,09,05,01", "Water_Pump_Regen_Hour_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WATER_PUMP_REGEN_LIFETIME_READBACK.ToString(), "M,09,06,01", "Water_Pump_Regen_Lifetime_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WATER_PUMP_P_COMMANDS.ToString(), "M,09,07,01", "Water_Pump_P_Commands", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WATER_PUMP_P_COMMAND_READBACK.ToString(), "M,09,07,02", "Water_Pump_P_Command_Readback", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.WATER_PUMP_IS_COMMUNICATING.ToString(), "M,09,10,01", "Water_Pump_Is_Communicating", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TURBO_PUMP_ON_OFF.ToString(), "M,09,08,01", "Turbo_Pump_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TURBO_PUMP_ON_OFF_RB.ToString(), "M,09,08,02", "Turbo_Pump_On_Off_Rb", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TURBO_PUMP_UPTOSPEED_RB.ToString(), "M,09,09,01", "Turbo_Pump_Uptospeed_Rb", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TURBO_PUMP_RAMPING_PERCENT_RB.ToString(), "M,09,09,02", "Turbo_Pump_Ramping_Percent_Rb", "Double")

            '<--- Vat_Valve # 10--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.VAT_VALVE_COMMUNICATION_STATUS.ToString(), "M,10,01,02", "Vat_Valve_Communication_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.VAT_VALVE_CONTROLLER_PRESSURE_PROGRAM.ToString(), "M,10,02,01", "Vat_Valve_Controller_Pressure_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.VAT_VALVE_CONTROLLER_PRESSURE_READBACK.ToString(), "M,10,02,02", "Vat_Valve_Controller_Pressure_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.VAT_VALVE_PERCENTAGE_PROGRAM.ToString(), "M,10,03,01", "Vat_Valve_Percentage_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.VAT_VALVE_PERCENTAGE_READBACK.ToString(), "M,10,03,02", "Vat_Valve_Percentage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.VAT_VALVE_CONTROLLER_AUTO_ZERO.ToString(), "M,10,04,01", "Vat_Valve_Controller_Auto_Zero", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.VAT_VALVE_CONTROLLER_TEACH.ToString(), "M,10,05,01", "Vat_Valve_Controller_Teach", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.VAT_VALVE_CONTROLLER_SIZEADJUST.ToString(), "M,10,06,01", "Vat_Valve_Controller_Sizeadjust", "WorkingStatuses")

            '<--- Magnatron # 11--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET1_MAGNATRON_ON_OFF.ToString(), "M,11,01,01", "Target1_Magnatron_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET1_MAGNATRON_ROTATE_STATUS.ToString(), "M,11,01,02", "Target1_Magnatron_Rotate_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET2_MAGNATRON_ON_OFF.ToString(), "M,11,02,01", "Target2_Magnatron_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET2_MAGNATRON_ROTATE_STATUS.ToString(), "M,11,02,02", "Target2_Magnatron_Rotate_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET3_MAGNATRON_ON_OFF.ToString(), "M,11,03,01", "Target3_Magnatron_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET3_MAGNATRON_ROTATE_STATUS.ToString(), "M,11,03,02", "Target3_Magnatron_Rotate_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET4_MAGNATRON_ON_OFF.ToString(), "M,11,04,01", "Target4_Magnatron_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET4_MAGNATRON_ROTATE_STATUS.ToString(), "M,11,04,02", "Target4_Magnatron_Rotate_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET5_MAGNATRON_ON_OFF.ToString(), "M,11,05,01", "Target5_Magnatron_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET5_MAGNATRON_ROTATE_STATUS.ToString(), "M,11,05,02", "Target5_Magnatron_Rotate_Status", "WorkingStatuses")

            '<---<!--RF Target Power Supply --> # 12--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_COMMUNICATION_STATUS.ToString(), "M,12,01,01", "RF_Target_Communication_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_POWER_READBACK.ToString(), "M,12,02,02", "RF_Target_Power_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_POWER_PROGRAM.ToString(), "M,12,02,01", "RF_Target_Power_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_REFLECTED_POWER_READBACK.ToString(), "M,12,03,02", "RF_Target_Reflected_Power_Readback", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_VOLTAGE_READBACK.ToString(), "M,12,04,02", "RF_Target_MB_Voltage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_C1_PROGRAM.ToString(), "M,12,05,01", "RF_Target_MB_C1_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_C1_READBACK.ToString(), "M,12,05,02", "RF_Target_MB_C1_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_C2_PROGRAM.ToString(), "M,12,06,01", "RF_Target_MB_C2_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_C2_READBACK.ToString(), "M,12,06,02", "RF_Target_MB_C2_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_MATCH_MODE_PROGRAM.ToString(), "M,12,07,01", "RF_Target_MB_Match_Mode_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_MATCH_MODE_READBACK.ToString(), "M,12,07,02", "RF_Target_MB_Match_Mode_Readback", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_ERROR_READBACK.ToString(), "M,12,08,02", "RF_Target_Error_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_PRESET_PROGRAM.ToString(), "M,12,09,01", "RF_Target_MB_Preset_Program", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_PRESET_READBACK.ToString(), "M,12,09,02", "RF_Target_MB_Preset_Readback", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_PRESET_STORE_PROGRAM.ToString(), "M,12,10,01", "RF_Target_MB_Preset_Store_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_PRESET_RECALL_PROGRAM.ToString(), "M,12,11,01", "RF_Target_MB_Preset_Recall_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_MAG_ERROR_READBACK.ToString(), "M,12,12,02", "RF_Target_MB_Mag_Error_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_MB_PHASE_ERROR_READBACK.ToString(), "M,12,13,02", "RF_Target_MB_Phase_Error_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_VOLTAGE_SP.ToString(), "M,12,15,02", "RF_Target_Voltage_SP", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_VOLTAGE_MIN.ToString(), "M,12,16,02", "RF_Target_Voltage_Min_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.RF_TARGET_VOLTAGE_MAX.ToString(), "M,12,17,02", "RF_Target_Voltage_Max_Readback", "Double")

            '<--- Bias_PS # 13--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_COMMUNICATION_STATUS.ToString(), "M,13,01,01", "Bias_Communication_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_POWER_READBACK.ToString(), "M,13,02,02", "Bias_Power_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_POWER_PROGRAM.ToString(), "M,13,02,01", "Bias_Power_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_REFLECTED_POWER_READBACK.ToString(), "M,13,03,02", "Bias_Reflected_Power_Readback", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_VOLTAGE_READBACK.ToString(), "M,13,04,02", "Bias_MB_Voltage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_VOLTAGE_PROGRAM.ToString(), "M,03,11,03", "Bias_MB_Voltage_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_C1_PROGRAM.ToString(), "M,13,05,01", "Bias_MB_C1_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_C1_READBACK.ToString(), "M,13,05,02", "Bias_MB_C1_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_C2_PROGRAM.ToString(), "M,13,06,01", "Bias_MB_C2_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_C2_READBACK.ToString(), "M,13,06,02", "Bias_MB_C2_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_MATCH_MODE_PROGRAM.ToString(), "M,13,07,01", "Bias_MB_Match_Mode_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_MATCH_MODE_READBACK.ToString(), "M,13,07,02", "Bias_MB_Match_Mode_Readback", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_PRESET_PROGRAM.ToString(), "M,13,09,01", "Bias_MB_Preset_Program", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_PRESET_READBACK.ToString(), "M,13,09,02", "Bias_MB_Preset_Readback", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_PRESET_STORE_PROGRAM.ToString(), "M,13,10,01", "Bias_MB_Preset_Store_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_PRESET_RECALL_PROGRAM.ToString(), "M,13,11,01", "Bias_MB_Preset_Recall_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_MAG_ERROR_READBACK.ToString(), "M,13,12,02", "Bias_MB_Mag_Error_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_MB_PHASE_ERROR_READBACK.ToString(), "M,13,13,02", "Bias_MB_Phase_Error_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_ERROR_READBACK.ToString(), "M,13,08,02", "Bias_Error_Readback", "String")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_POWER_CONTACT_ON_OFF_STATUS.ToString(), "M,13,14,01", "Bias_Power_Contact_On_Off", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_VOLTAGE_MIN.ToString(), "M,13,15,02", "Bias_Voltage_Min_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.BIAS_VOLTAGE_MAX.ToString(), "M,13,16,02", "Bias_Voltage_Max_Readback", "Double")

            '<--- DC_Target_PS # 14--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_COMMUNICATION_STATUS.ToString(), "M,14,01,01", "DC_Target_Communication_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_POWER_READBACK.ToString(), "M,14,02,02", "DC_Target_Power_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_POWER_PROGRAM.ToString(), "M,14,02,01", "DC_Target_Power_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_VOLTAGE_READBACK.ToString(), "M,14,03,02", "DC_Target_Voltage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_CURRENT_READBACK.ToString(), "M,14,04,02", "DC_Target_Current_Readback", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_PULSE_MODE_STATUS.ToString(), "M,14,05,01", "DC_Target_Pluse_Mode_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_PULSE_FREQUENCY_PROGRAM.ToString(), "M,14,06,01", "DC_Target_Pulse_Frequency_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_PULSE_FREQUENCY_READBACK.ToString(), "M,14,06,02", "DC_Target_Pulse_Frequency_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_PULSE_WIDTH_PROGRAM.ToString(), "M,14,07,01", "DC_Target_Pulse_Width_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_PULSE_WIDTH_READBACK.ToString(), "M,14,07,02", "DC_Target_Pulse_Width_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_RAMP_TIME_PROGRAM.ToString(), "M,14,08,01", "DC_Target_Ramp_Time_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_RAMP_TIME_READBACK.ToString(), "M,14,08,02", "DC_Target_Ramp_Time_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_ARC_COUNTER_READBACK.ToString(), "M,14,09,02", "DC_Target_Arc_Counter_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.DC_TARGET_VOLTAGE_SP.ToString(), "M,14,10,02", "DC_Target_Voltage_SP", "Double")

            '<--- HEATER ZONE # 15--->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE1_PROGRAM.ToString(), "M,15,01,01", "Heater_Zone1_SP", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE1_READBACK.ToString(), "M,15,01,02", "Heater_Zone1_RB", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE1_ONOFF_PROGRAM.ToString(), "M,15,01,03", "Heater1_OnOff_SP", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE1_ONOFF_READBACK.ToString(), "M,15,01,04", "Heater1_OnOff_RB", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE1_ALARM.ToString(), "M,15,01,06", "Heater1_Alarm", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE1_COMMUNICATION.ToString(), "M,15,01,07", "HeaterZone1_Communication_Status", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE2_PROGRAM.ToString(), "M,15,02,01", "Heater_Zone2_SP", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE2_READBACK.ToString(), "M,15,02,02", "Heater_Zone2_RB", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE2_ONOFF_PROGRAM.ToString(), "M,15,02,03", "Heater2_OnOff_SP", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE2_ONOFF_READBACK.ToString(), "M,15,02,04", "Heater2_OnOff_RB", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE2_ALARM.ToString(), "M,15,02,06", "Heater2_Alarm", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.HEATER_ZONE2_COMMUNICATION.ToString(), "M,15,02,07", "HeaterZone2_Communication_Status", "WorkingStatuses")

            '<-- InjectionValve -->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET1_INJECTION_VALVE_STATUS.ToString(), "M,05,08,01", "Target1_Injection_ValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET2_INJECTION_VALVE_STATUS.ToString(), "M,05,09,01", "Target2_Injection_ValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET3_INJECTION_VALVE_STATUS.ToString(), "M,05,10,01", "Target3_Injection_ValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET4_INJECTION_VALVE_STATUS.ToString(), "M,05,11,01", "Target4_Injection_ValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.TARGET5_INJECTION_VALVE_STATUS.ToString(), "M,05,13,01", "Target5_Injection_ValveStatus", "WorkingStatuses")

            '<-- IG Isolation Valve -->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.IG_ISOLATION_VALVE_STATUS.ToString(), "M,05,12,01", "IG_Isolation_ValveStatus", "WorkingStatuses")

            '<-- FilMetricDevice -->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FILMETRIC_MEASURE.ToString(), "M,16,01,01", "Filmetric_Measure", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FILMETRIC_RECIPE_SP.ToString(), "M,16,03,01", "Filmetric_Recipe_SP", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FILMETRIC_LISTRECIPE_RB.ToString(), "M,16,04,02", "Filmetric_ListRecipe_RB", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FILMETRIC_THICKNESS.ToString(), "M,16,05,02", "Filmetric_Thickness", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FILMETRIC_GOTO_BASELINE.ToString(), "M,16,08,01", "Filmetric_Goto_Baseline", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FILMETRIC_GOTO_THICKNESS.ToString(), "M,16,09,01", "Filmetric_Goto_Thickness", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.FILMETRIC_GOF.ToString(), "M,16,06,02", "Goodness_Of_Fit", "Double")

            '<!--Step Complete-->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_RECIPE_STEP_COMPLETE.ToString(), "M,02,24,01", "StepCompleted", "Double")

            '<!--Step Complete ProcessCycleATMStart-->
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.PROCESS_CYCLEATM_START.ToString(), "M,02,25,01", "ProcessCycleATMStart", "String")

            '<-- Clear All Alarm --> 
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CLEAR_ALL_ALARM_PROGRAM.ToString(), "M,17,01,01", "", "")

            '<!--Cryo-- #19>
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_T1_READBACK.ToString(), "M,19,01,02", "Cryo_T1_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_T2_READBACK.ToString(), "M,19,02,02", "Cryo_T2_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_COMMUNICATION_STATUS.ToString(), "M,19,03,02", "Cryo_CommunicationStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_REGEN.ToString(), "M,19,04,01", "CryoRegenStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_REGEN_STATUS_TEXT.ToString(), "M,19,05,02", "CryoRegenStatusText", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_REGEN_HOUR_READBACK.ToString(), "M,19,06,02", "Cryo_RegenHour_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_LIFETIME_HOUR_READBACK.ToString(), "M,19,07,02", "Cryo_LifeTimeHour_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_P_COMMANDS.ToString(), "M,19,08,01", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_P_COMMAND_READBACK.ToString(), "M,19,09,02", "Cryo_P_Command", "String")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_POWER_ONOFF.ToString(), "M,19,10,01", "", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_POWER_ONOFF_READBACK.ToString(), "M,19,11,02", "CryoPowerOnOff", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_FAST_REGEN.ToString(), "M,19,12,02", "CryoFastRegenStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.PVD5TCommands.CRYO_ROUGH_PUMP_IN_USED.ToString(), "M,19,13,02", "CryoRoughPumpInUsed", "Boolean")

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Public Shared Sub GetCoronaMaintenance(ByRef nameMap As Hashtable, ByRef codeMap As Hashtable)
        Try ''use this function for pvd
            nameMap.Clear()
            codeMap.Clear()

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.REQUEST_ALL_DATA.ToString(), "C,01,18,01", "", "")
            '<--- System #1--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.KEEP_ALIVE.ToString(), "C,01,01,01", "Keep_Alive", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.OVERRIDE_MODE.ToString(), "C,01,02,01", "Override_Mode", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.ALARM_STATUS_READBACK.ToString(), "C,01,03,02", "StatusMessage", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.EVENT_STATUS_READBACK.ToString(), "C,01,04,02", "EventMessage", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.MAINTENAINCE_MODE.ToString(), "C,01,05,01", "MaintenanceMode", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET1_SET_KWH_USAGE.ToString(), "C,01,06,01", "Target1_Set_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET1_KWH_USAGE.ToString(), "C,01,06,02", "Target1_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET2_SET_KWH_USAGE.ToString(), "C,01,07,01", "Target2_Set_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET2_KWH_USAGE.ToString(), "C,01,07,02", "Target2_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET3_SET_KWH_USAGE.ToString(), "C,01,08,01", "Target3_Set_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET3_KWH_USAGE.ToString(), "C,01,08,02", "Target3_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET4_SET_KWH_USAGE.ToString(), "C,01,09,01", "Target4_Set_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET4_KWH_USAGE.ToString(), "C,01,09,02", "Target4_Kwh_Usage", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET_SELECT_PROGRAM.ToString(), "C,01,10,01", "Target_Select_Program", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET_SELECT_READBACK.ToString(), "C,01,10,02", "Target_Select_Readback", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET1_SET_SHIELD_QUART.ToString(), "C,01,12,01", "Target1_Set_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET1_SHIELD_QUART.ToString(), "C,01,12,02", "Target1_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET2_SET_SHIELD_QUART.ToString(), "C,01,13,01", "Target2_Set_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET2_SHIELD_QUART.ToString(), "C,01,13,02", "Target2_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET3_SET_SHIELD_QUART.ToString(), "C,01,14,01", "Target3_Set_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET3_SHIELD_QUART.ToString(), "C,01,14,02", "Target3_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET4_SET_SHIELD_QUART.ToString(), "C,01,15,01", "Target4_Set_Shield_Quart", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET4_SHIELD_QUART.ToString(), "C,01,15,02", "Target4_Shield_Quart", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PLASMA_STATUS.ToString(), "C,01,16,02", "Plasma_Status", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_PLASMA_STATUS.ToString(), "C,01,17,02", "Bias_Plasma_Status", "WorkingStatuses")
            '<--- Recipe_Processing #2--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_WAFER_ID.ToString(), "C,02,01,01", "Process_Wafer_ID", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_RECIPE_NAME.ToString(), "C,02,02,01", "Process_Recipe_Name", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CONTROL_DEVICE.ToString(), "C,02,03,01", "RecipeProcessingStatus", "")
            'AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CONTROL_DEVICE_START.ToString(), "C,02,03,01", "Process_Control_Device_Start", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CONTROL_DEVICE_STOP.ToString(), "C,02,04,01", "Process_Control_Device_Stop", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CONTROL_DEVICE_PAUSE.ToString(), "C,02,05,01", "Process_Control_Device_Pause", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CONTROL_DEVICE_CONTINUE.ToString(), "C,02,06,01", "Process_Control_Device_Continue", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CONTROL_DEVICE_END_STEP.ToString(), "C,02,07,01", "Process_Control_Device_End_Step", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CONTROL_DEVICE_ERROR.ToString(), "C,02,08,02", "Process_Control_Device_Error", "WorkingStatuses")
            'AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CONTROL_DEVICE_RESET_ERROR.ToString(), "C,02,08,01", "Process_Control_Device_Reset_Error", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CONTROL_SEND_RUN_DATA_FILE_NAME.ToString(), "C,02,09,01", "Process_Control_Send_Run_Data_File_Name", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CONTROL_GET_RUN_DATA_FILE_NAME.ToString(), "C,02,10,01", "Process_Control_Get_Run_Data_File_Name", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.COPYRECIPE_TO_PMFOLDER.ToString(), "C,02,11,01", "StartCopyRecipeToPMFolder", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHECK_RECIPE_TEMPLATE_VERSION.ToString(), "C,02,21,01", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SYN_COPY_RECIPE_TEMPLATE.ToString(), "C,02,22,01", "StartCopyRecipeTemplate", "")

            '<---<---@Process Status--->--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_REMAINING_TIME.ToString(), "C,02,12,01", "Process_Remaining_Time", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_TOTAL_TIME.ToString(), "C,02,19,01", "Process_Total_Time", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_ELAPSED_TIME.ToString(), "C,02,13,01", "Process_Elapsed_Time", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CURRENT_STEP.ToString(), "C,02,14,01", "Process_Current_Step", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_TOTAL_STEPS.ToString(), "C,02,15,01", "Process_Total_Steps", "")
            'AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_PRESSURE.ToString(), "C,02,17,01", "Process_Pressure", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CURRENT_RECIPE_LOOP.ToString(), "C,02,26,01", "CurrentRecipeLoop", "")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_MODE.ToString(), "C,02,17,01", "Process_Mode", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_REVOLUTION_COUNT.ToString(), "C,02,18,01", "Process_Revolution_Count", "String")

            '<---'' <!--Wafer Processing Status -->--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WAFER_PROCESSING_STATUS_READBACK.ToString(), "C,02,16,01", "Wafer_Processing_Status_Readback", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CURRENT_AVP_TIME.ToString(), "C,02,20,01", "Current_AVP_Time", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WAFER_DELETE.ToString(), "C,02,16,02", "Wafer_Delete", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WAFER_SLOT.ToString(), "C,02,16,03", "Wafer_Slot", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_LOT_ID.ToString(), "C,02,23,01", "", "")

            '<--- Sequences # 3--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.AUTO_PUMPDOWN_SEQ.ToString(), "C,03,01,01", "Auto_Pumpdown_Seq_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.AUTO_VENT_SEQ.ToString(), "C,03,02,01", "Auto_Vent_Seq_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PUMP_PURGE_SEQ.ToString(), "C,03,03,01", "Pump_Purge_Seq_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.MACHINE_PUMPPURGE_CURRENT_CYCLE.ToString(), "C,03,10,01", "MachinePumpPurge_Current_Cycle", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.IG_DEGAS_SEQ.ToString(), "C,03,04,01", "IG_Degas_Seq_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SHUTDOWN_POWER_SEQ.ToString(), "C,03,05,01", "Shutdown_Power_Seq_Status", "WorkingStatuses")

            '<---ROR Sequence--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RATE_OF_RISE_SEQ.ToString(), "C,03,06,01", "RateOfRise_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RATE_OF_RISE_INTERVAL_RECORDING.ToString(), "C,03,06,03", "RateOfRise_Interval", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RATE_OF_RISE_SAMPLE.ToString(), "C,03,06,04", "RateOfRise_Sample", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RATE_OF_RISE_FILENAME.ToString(), "C,03,06,05", "RateOfRise_FileName", "")

            '<---PDC Sequence--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PUMPDOWN_CURVE_SEQ.ToString(), "C,03,07,01", "PumpDown_Curve_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PUMPDOWN_CURVE_INTERVAL_RECORDING.ToString(), "C,03,07,03", "PumpDown_Curve_Interval", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PUMPDOWN_CURVE_SAMPLE.ToString(), "C,03,07,04", "PumpDown_Curve_Sample", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PUMPDOWN_CURVE_FILENAME.ToString(), "C,03,07,05", "PumpDown_Curve_FileName", "")

            '<---Initialize_Motion--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.INITIALIZE_MOTION.ToString(), "C,03,08,03", "Initialize_Motion", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.INITIALIZED_MOTION.ToString(), "C,03,08,01", "Initialized_Motion", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.AUTO_POWER_SEQ.ToString(), "C,03,09,03", "Auto_Power_Seq", "WorkingStatuses")

            '<--- Gasses # 4--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS1_SHUTOFF_VALVE.ToString(), "C,04,01,03", "Gas1_Shutoff_Valve", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS2_SHUTOFF_VALVE.ToString(), "C,04,02,03", "Gas2_Shutoff_Valve", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS3_SHUTOFF_VALVE.ToString(), "C,04,03,03", "Gas3_Shutoff_Valve", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS4_SHUTOFF_VALVE.ToString(), "C,04,04,03", "Gas4_Shutoff_Valve", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS5_SHUTOFF_VALVE.ToString(), "C,04,05,03", "Gas5_Shutoff_Valve", "WorkingStatuses")

            '<---<--Gas Mfc-->--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS1_FLOWRATE_PROGRAM.ToString(), "C,04,01,01", "Gas1_Flowrate_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS2_FLOWRATE_PROGRAM.ToString(), "C,04,02,01", "Gas2_Flowrate_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS3_FLOWRATE_PROGRAM.ToString(), "C,04,03,01", "Gas3_Flowrate_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS4_FLOWRATE_PROGRAM.ToString(), "C,04,04,01", "Gas4_Flowrate_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS5_FLOWRATE_PROGRAM.ToString(), "C,04,05,01", "Gas5_Flowrate_Program", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS1_FLOWRATE_READBACK.ToString(), "C,04,01,02", "Gas1_Flowrate_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS2_FLOWRATE_READBACK.ToString(), "C,04,02,02", "Gas2_Flowrate_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS3_FLOWRATE_READBACK.ToString(), "C,04,03,02", "Gas3_Flowrate_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS4_FLOWRATE_READBACK.ToString(), "C,04,04,02", "Gas4_Flowrate_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS5_FLOWRATE_READBACK.ToString(), "C,04,05,02", "Gas5_Flowrate_Readback", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.MAIN_DIST_VALVE.ToString(), "C,04,06,01", "Main_Dist_Valve", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SEC_DIST_VALVE.ToString(), "C,04,07,01", "Sec_Dist_Valve", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS1_MFC_DEVICENET_STATUS_READBACK.ToString(), "C,18,01,02", "Gas1MFCDevinetStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS2_MFC_DEVICENET_STATUS_READBACK.ToString(), "C,18,02,02", "Gas2MFCDevinetStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS3_MFC_DEVICENET_STATUS_READBACK.ToString(), "C,18,03,02", "Gas3MFCDevinetStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS4_MFC_DEVICENET_STATUS_READBACK.ToString(), "C,18,04,02", "Gas4MFCDevinetStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.GAS5_MFC_DEVICENET_STATUS_READBACK.ToString(), "C,18,05,02", "Gas5MFCDevinetStatus", "WorkingStatuses")

            '<--- Valves # 5--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.ROUGH_VALVE_STATUS.ToString(), "C,05,01,01", "RoughValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.VENT_VALVE_STATUS.ToString(), "C,05,02,01", "VentValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.ISOLATION_VALVE_STATUS.ToString(), "C,05,03,01", "Isolation_Valve_Status", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HIVAC_VALVE_STATUS.ToString(), "C,05,04,01", "Hivac_Valve_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FORELINE_VALVE_STATUS.ToString(), "C,05,05,01", "ForelineValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BARATRON_VALVE_STATUS.ToString(), "C,05,07,01", "Baratron_Valve_Status", "WorkingStatuses")

            '<--- Pressure # 6--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.IG_PRESSURE.ToString(), "C,06,01,02", "IG", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.IG_STATUS.ToString(), "C,06,01,03", "IGStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SWITCH_IG_FILAMENT_PROGRAM.ToString(), "C,06,01,05", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SWITCH_IG_FILAMENT_READBACK.ToString(), "C,06,01,04", "SwitchIGFilament", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.ENABLE_IG_FILAMENT_READBACK.ToString(), "C,06,01,06", "EnableIGFilament", "Integer")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CG_PRESSURE.ToString(), "C,06,02,02", "CG", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CG_RELAY_STATUS.ToString(), "C,06,02,03", "CG_Relay_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBER_CG_ATM.ToString(), "C,06,02,05", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.ENABLE_SET_CHAMBER_CG_ATM.ToString(), "C,06,02,06", "ATMChamberCGStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBER_CG_VAC.ToString(), "C,06,02,07", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.ENABLE_SET_CHAMBER_CG_VAC.ToString(), "C,06,02,08", "VACChamberCGStatus", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FORELINE_CG_PRESSURE.ToString(), "C,06,03,02", "Foreline_CG_Pressure", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FORELINE_CG_RELAY_STATUS.ToString(), "C,06,03,03", "Foreline_CG_Relay_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FORELINE_CG_ATM.ToString(), "C,06,03,05", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.ENABLE_SET_FORELINE_CG_ATM.ToString(), "C,06,03,06", "ATMForelineCGStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BARATRON_PRESSURE.ToString(), "C,06,05,02", "Baratron_Pressure", "Double")

            '<---<--Mechanical Pump CG-->--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.MECHANICAL_PUMP_CG_PRESSURE.ToString(), "C,06,06,02", "Mechanical_Pump_CG_Pressure", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.MECHANICAL_PUMP_CG_RELAY_STATUS.ToString(), "C,06,06,03", "Mechanical_Pump_CG_Relay_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.MECHANICAL_PUMP_STATUS.ToString(), "C,06,06,04", "Mechanical_Pump_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.MECHANICAL_PUMP_CG_ATM.ToString(), "C,06,06,05", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.ENABLE_SET_MECHANICAL_PUMP_CG_ATM.ToString(), "C,06,06,06", "ATMMechanicalPumpCGStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.MECHANICAL_PUMP_COM_SERIAL.ToString(), "C,06,06,07", "MPump_Serial_Communication_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.MECHANICAL_PUMP_WAITTING_ON.ToString(), "C,06,06,08", "WaitingMPON", "String")

            '<--- Interlocks # 7--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_SUBSTRATE_TABLE_WATER_STATUS.ToString(), "C,07,01,02", "Chamberinterlock_Substrate_Table_Water_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_AIR_PRESSURE_STATUS.ToString(), "C,07,02,02", "Chamberinterlock_Air_Pressure_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_DOOR_CLOSED_STATUS.ToString(), "C,07,03,02", "Chamberinterlock_Door_Closed_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_LID_CLOSED_STATUS.ToString(), "C,07,04,02", "Chamberinterlock_Lid_Closed_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_TURBO_WATER_STATUS.ToString(), "C,07,05,02", "Chamberinterlock_Turbo_Water_Status", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_TARGET_MB_WATER_STATUS.ToString(), "C,07,06,02", "Chamberinterlock_Target_MB_Water_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_BIAS_MB_WATER_STATUS.ToString(), "C,07,07,02", "Chamberinterlock_Bias_MB_Water_Status", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_TARGET1_3_WATER_STATUS.ToString(), "C,07,08,02", "Chamberinterlock_Target1_3_Water_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_TARGET2_4_WATER_STATUS.ToString(), "C,07,09,02", "Chamberinterlock_Target2_4_Water_Status", "WorkingStatuses")
            
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_PS_INTERLOCK_STATUS.ToString(), "C,07,12,01", "Chamberinterlock_PS_Interlock_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_DEVICENET_COMM.ToString(), "C,07,13,02", "Chamberinterlock_Devicenet_Comm", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CHAMBERINTERLOCK_TARGET_PANELS.ToString(), "C,07,14,02", "Chamberinterlock_Target_Panels", "WorkingStatuses")

            '<--- Motion # 8--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET1_SHUTTER_STATUS.ToString(), "C,08,01,01", "Target1_Shutter_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET2_SHUTTER_STATUS.ToString(), "C,08,02,01", "Target2_Shutter_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET3_SHUTTER_STATUS.ToString(), "C,08,03,01", "Target3_Shutter_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET4_SHUTTER_STATUS.ToString(), "C,08,04,01", "Target4_Shutter_Status", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_UP_DOWN_STATUS.ToString(), "C,08,05,01", "Substrate_Table_Up_Down_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_ROTATE_STATUS.ToString(), "C,08,06,01", "Substrate_Table_Rotate_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_ROTATE_SPEED.ToString(), "C,08,09,01", "Substrate_Table_Rotate_Speed", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_ROTATE_SPEED_READBACK.ToString(), "C,08,09,02", "Substrate_Table_Rotate_Speed_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_ROTATE_POS_IN_UNIT_READBACK.ToString(), "C,08,17,02", "Substrate_Table_Rotate_Pos_In_Unit_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.NUMBER_OF_UNIT_PER_REVOLUTION_READBACK.ToString(), "C,08,18,02", "Number_Of_Unit_Per_Revolution_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_CURRENT_STATION.ToString(), "C,08,07,02", "Substrate_Current_Station", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_GOTO_SLOT.ToString(), "C,08,08,01", "Substrate_Goto_Slot", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_ROTATE_HOME.ToString(), "C,08,10,01", "Substrate_Table_Rotate_Home", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_LIFT_HOME.ToString(), "C,08,13,01", "Substrate_Table_Lift_Home", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_LIFT_UP_DOWN_STATUS.ToString(), "C,08,11,01", "Substrate_Lift_Up_Down_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_CURRENT_POSITION_PROGRAM.ToString(), "C,08,12,01", "Substrate_Table_Current_Position_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_CURRENT_POSITION_READBACK.ToString(), "C,08,12,02", "Substrate_Table_Current_Position_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.IS_MOTIONINITIALIZED.ToString(), "C,08,14,01", "Is_MotionInitalized", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_ROTATE_SEQUENCE_STATE.ToString(), "C,08,15,02", "Substrate_Table_Rotate_Sequence_State", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.ROUND_SUBSTRATE_CURRENT_STATION.ToString(), "C,08,16,02", "Round_Substrate_Current_Station", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.SUBSTRATE_TABLE_UP_DOWN_MOVING.ToString(), "C,08,19,02", "Substrate_Table_Up_Down_Moving", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.MOTION_COMMUNICATION_STATUS.ToString(), "C,08,20,02", "Motion_Communication_Status", "WorkingStatuses")


            '<--- Turbo_Waterpump # 9--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WATER_PUMP_T_READBACK.ToString(), "C,09,01,01", "Water_Pump_T_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WATER_PUMP_STATUS.ToString(), "C,09,02,01", "Water_Pump_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WATER_PUMP_REGEN_STATUS.ToString(), "C,09,03,01", "Water_Pump_Regen_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WATER_PUMP_STATE_STATUS.ToString(), "C,09,04,01", "Water_Pump_State_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WATER_PUMP_REGEN_HOUR_READBACK.ToString(), "C,09,05,01", "Water_Pump_Regen_Hour_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WATER_PUMP_REGEN_LIFETIME_READBACK.ToString(), "C,09,06,01", "Water_Pump_Regen_Lifetime_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WATER_PUMP_P_COMMANDS.ToString(), "C,09,07,01", "Water_Pump_P_Commands", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WATER_PUMP_P_COMMAND_READBACK.ToString(), "C,09,07,02", "Water_Pump_P_Command_Readback", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.WATER_PUMP_IS_COMMUNICATING.ToString(), "C,09,10,01", "Water_Pump_Is_Communicating", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TURBO_PUMP_ON_OFF.ToString(), "C,09,08,01", "Turbo_Pump_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TURBO_PUMP_ON_OFF_RB.ToString(), "C,09,08,02", "Turbo_Pump_On_Off_Rb", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TURBO_PUMP_UPTOSPEED_RB.ToString(), "C,09,09,01", "Turbo_Pump_Uptospeed_Rb", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TURBO_PUMP_RAMPING_PERCENT_RB.ToString(), "C,09,09,02", "Turbo_Pump_Ramping_Percent_Rb", "Double")

            '<--- Vat_Valve # 10--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.VAT_VALVE_COMMUNICATION_STATUS.ToString(), "C,10,01,02", "Vat_Valve_Communication_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.VAT_VALVE_CONTROLLER_PRESSURE_PROGRAM.ToString(), "C,10,02,01", "Vat_Valve_Controller_Pressure_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.VAT_VALVE_CONTROLLER_PRESSURE_READBACK.ToString(), "C,10,02,02", "Vat_Valve_Controller_Pressure_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.VAT_VALVE_PERCENTAGE_PROGRAM.ToString(), "C,10,03,01", "Vat_Valve_Percentage_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.VAT_VALVE_PERCENTAGE_READBACK.ToString(), "C,10,03,02", "Vat_Valve_Percentage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.VAT_VALVE_CONTROLLER_AUTO_ZERO.ToString(), "C,10,04,01", "Vat_Valve_Controller_Auto_Zero", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.VAT_VALVE_CONTROLLER_TEACH.ToString(), "C,10,05,01", "Vat_Valve_Controller_Teach", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.VAT_VALVE_CONTROLLER_SIZEADJUST.ToString(), "C,10,06,01", "Vat_Valve_Controller_Sizeadjust", "WorkingStatuses")

            '<--- Magnatron # 11--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET1_MAGNATRON_ON_OFF.ToString(), "C,11,01,01", "Target1_Magnatron_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET1_MAGNATRON_ROTATE_STATUS.ToString(), "C,11,01,02", "Target1_Magnatron_Rotate_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET2_MAGNATRON_ON_OFF.ToString(), "C,11,02,01", "Target2_Magnatron_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET2_MAGNATRON_ROTATE_STATUS.ToString(), "C,11,02,02", "Target2_Magnatron_Rotate_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET3_MAGNATRON_ON_OFF.ToString(), "C,11,03,01", "Target3_Magnatron_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET3_MAGNATRON_ROTATE_STATUS.ToString(), "C,11,03,02", "Target3_Magnatron_Rotate_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET4_MAGNATRON_ON_OFF.ToString(), "C,11,04,01", "Target4_Magnatron_On_Off", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET4_MAGNATRON_ROTATE_STATUS.ToString(), "C,11,04,02", "Target4_Magnatron_Rotate_Status", "WorkingStatuses")

            '<---<!--RF Target Power Supply --> # 12--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_COMMUNICATION_STATUS.ToString(), "C,12,01,01", "RF_Target_Communication_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_POWER_READBACK.ToString(), "C,12,02,02", "RF_Target_Power_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_POWER_PROGRAM.ToString(), "C,12,02,01", "RF_Target_Power_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_REFLECTED_POWER_READBACK.ToString(), "C,12,03,02", "RF_Target_Reflected_Power_Readback", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_VOLTAGE_READBACK.ToString(), "C,12,04,02", "RF_Target_MB_Voltage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_C1_PROGRAM.ToString(), "C,12,05,01", "RF_Target_MB_C1_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_C1_READBACK.ToString(), "C,12,05,02", "RF_Target_MB_C1_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_C2_PROGRAM.ToString(), "C,12,06,01", "RF_Target_MB_C2_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_C2_READBACK.ToString(), "C,12,06,02", "RF_Target_MB_C2_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_MATCH_MODE_PROGRAM.ToString(), "C,12,07,01", "RF_Target_MB_Match_Mode_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_MATCH_MODE_READBACK.ToString(), "C,12,07,02", "RF_Target_MB_Match_Mode_Readback", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_ERROR_READBACK.ToString(), "C,12,08,02", "RF_Target_Error_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_PRESET_PROGRAM.ToString(), "C,12,09,01", "RF_Target_MB_Preset_Program", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_PRESET_READBACK.ToString(), "C,12,09,02", "RF_Target_MB_Preset_Readback", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_PRESET_STORE_PROGRAM.ToString(), "C,12,10,01", "RF_Target_MB_Preset_Store_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_PRESET_RECALL_PROGRAM.ToString(), "C,12,11,01", "RF_Target_MB_Preset_Recall_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_MAG_ERROR_READBACK.ToString(), "C,12,12,02", "RF_Target_MB_Mag_Error_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_MB_PHASE_ERROR_READBACK.ToString(), "C,12,13,02", "RF_Target_MB_Phase_Error_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_VOLTAGE_SP.ToString(), "C,12,15,02", "RF_Target_Voltage_SP", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_VOLTAGE_MIN.ToString(), "C,12,16,02", "RF_Target_Voltage_Min_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.RF_TARGET_VOLTAGE_MAX.ToString(), "C,12,17,02", "RF_Target_Voltage_Max_Readback", "Double")


            '<--- Bias_PS # 13--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_COMMUNICATION_STATUS.ToString(), "C,13,01,01", "Bias_Communication_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_POWER_READBACK.ToString(), "C,13,02,02", "Bias_Power_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_POWER_PROGRAM.ToString(), "C,13,02,01", "Bias_Power_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_REFLECTED_POWER_READBACK.ToString(), "C,13,03,02", "Bias_Reflected_Power_Readback", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_VOLTAGE_READBACK.ToString(), "C,13,04,02", "Bias_MB_Voltage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_VOLTAGE_PROGRAM.ToString(), "C,03,11,03", "Bias_MB_Voltage_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_C1_PROGRAM.ToString(), "C,13,05,01", "Bias_MB_C1_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_C1_READBACK.ToString(), "C,13,05,02", "Bias_MB_C1_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_C2_PROGRAM.ToString(), "C,13,06,01", "Bias_MB_C2_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_C2_READBACK.ToString(), "C,13,06,02", "Bias_MB_C2_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_MATCH_MODE_PROGRAM.ToString(), "C,13,07,01", "Bias_MB_Match_Mode_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_MATCH_MODE_READBACK.ToString(), "C,13,07,02", "Bias_MB_Match_Mode_Readback", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_PRESET_PROGRAM.ToString(), "C,13,09,01", "Bias_MB_Preset_Program", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_PRESET_READBACK.ToString(), "C,13,09,02", "Bias_MB_Preset_Readback", "Integer")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_PRESET_STORE_PROGRAM.ToString(), "C,13,10,01", "Bias_MB_Preset_Store_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_PRESET_RECALL_PROGRAM.ToString(), "C,13,11,01", "Bias_MB_Preset_Recall_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_MAG_ERROR_READBACK.ToString(), "C,13,12,02", "Bias_MB_Mag_Error_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_MB_PHASE_ERROR_READBACK.ToString(), "C,13,13,02", "Bias_MB_Phase_Error_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_ERROR_READBACK.ToString(), "C,13,08,02", "Bias_Error_Readback", "String")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_POWER_CONTACT_ON_OFF_STATUS.ToString(), "C,13,14,01", "Bias_Power_Contact_On_Off", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_VOLTAGE_MIN.ToString(), "C,13,15,02", "Bias_Voltage_Min_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.BIAS_VOLTAGE_MAX.ToString(), "C,13,16,02", "Bias_Voltage_Max_Readback", "Double")

            '<--- DC_Target_PS # 14--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_COMMUNICATION_STATUS.ToString(), "C,14,01,01", "DC_Target_Communication_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_POWER_READBACK.ToString(), "C,14,02,02", "DC_Target_Power_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_POWER_PROGRAM.ToString(), "C,14,02,01", "DC_Target_Power_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_VOLTAGE_READBACK.ToString(), "C,14,03,02", "DC_Target_Voltage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_CURRENT_READBACK.ToString(), "C,14,04,02", "DC_Target_Current_Readback", "Double")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_PULSE_MODE_STATUS.ToString(), "C,14,05,01", "DC_Target_Pluse_Mode_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_PULSE_FREQUENCY_PROGRAM.ToString(), "C,14,06,01", "DC_Target_Pulse_Frequency_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_PULSE_FREQUENCY_READBACK.ToString(), "C,14,06,02", "DC_Target_Pulse_Frequency_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_PULSE_WIDTH_PROGRAM.ToString(), "C,14,07,01", "DC_Target_Pulse_Width_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_PULSE_WIDTH_READBACK.ToString(), "C,14,07,02", "DC_Target_Pulse_Width_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_RAMP_TIME_PROGRAM.ToString(), "C,14,08,01", "DC_Target_Ramp_Time_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_RAMP_TIME_READBACK.ToString(), "C,14,08,02", "DC_Target_Ramp_Time_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_ARC_COUNTER_READBACK.ToString(), "C,14,09,02", "DC_Target_Arc_Counter_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.DC_TARGET_VOLTAGE_SP.ToString(), "C,14,10,02", "DC_Target_Voltage_SP", "Double")

            '<--- HEATER ZONE # 15--->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE1_PROGRAM.ToString(), "C,15,01,01", "Heater_Zone1_SP", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE1_READBACK.ToString(), "C,15,01,02", "Heater_Zone1_RB", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE1_ONOFF_PROGRAM.ToString(), "C,15,01,03", "Heater1_OnOff_SP", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE1_ONOFF_READBACK.ToString(), "C,15,01,04", "Heater1_OnOff_RB", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE1_ALARM.ToString(), "C,15,01,06", "Heater1_Alarm", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE1_COMMUNICATION.ToString(), "C,15,01,07", "HeaterZone1_Communication_Status", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE2_PROGRAM.ToString(), "C,15,02,01", "Heater_Zone2_SP", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE2_READBACK.ToString(), "C,15,02,02", "Heater_Zone2_RB", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE2_ONOFF_PROGRAM.ToString(), "C,15,02,03", "Heater2_OnOff_SP", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE2_ONOFF_READBACK.ToString(), "C,15,02,04", "Heater2_OnOff_RB", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE2_ALARM.ToString(), "C,15,02,06", "Heater2_Alarm", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.HEATER_ZONE2_COMMUNICATION.ToString(), "C,15,02,07", "HeaterZone2_Communication_Status", "WorkingStatuses")

            '<-- InjectionValve -->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET1_INJECTION_VALVE_STATUS.ToString(), "C,05,08,01", "Target1_Injection_ValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET2_INJECTION_VALVE_STATUS.ToString(), "C,05,09,01", "Target2_Injection_ValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET3_INJECTION_VALVE_STATUS.ToString(), "C,05,10,01", "Target3_Injection_ValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.TARGET4_INJECTION_VALVE_STATUS.ToString(), "C,05,11,01", "Target4_Injection_ValveStatus", "WorkingStatuses")

            '<-- IG Isolation Valve -->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.IG_ISOLATION_VALVE_STATUS.ToString(), "C,05,12,01", "IG_Isolation_ValveStatus", "WorkingStatuses")

            '<-- FilMetricDevice -->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FILMETRIC_MEASURE.ToString(), "C,16,01,01", "Filmetric_Measure", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FILMETRIC_RECIPE_SP.ToString(), "C,16,03,01", "Filmetric_Recipe_SP", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FILMETRIC_LISTRECIPE_RB.ToString(), "C,16,04,02", "Filmetric_ListRecipe_RB", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FILMETRIC_THICKNESS.ToString(), "C,16,05,02", "Filmetric_Thickness", "String")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FILMETRIC_GOTO_BASELINE.ToString(), "C,16,08,01", "Filmetric_Goto_Baseline", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FILMETRIC_GOTO_THICKNESS.ToString(), "C,16,09,01", "Filmetric_Goto_Thickness", "")
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.FILMETRIC_GOF.ToString(), "C,16,06,02", "Goodness_Of_Fit", "Double")

            '<!--Step Complete-->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_RECIPE_STEP_COMPLETE.ToString(), "C,02,24,01", "StepCompleted", "Double")

            '<!--Step Complete ProcessCycleATMStart-->
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.PROCESS_CYCLEATM_START.ToString(), "C,02,25,01", "ProcessCycleATMStart", "String")

            '<-- Clear All Alarm --> 
            AddDBCommandItem(nameMap, codeMap, Business.CORONACommands.CLEAR_ALL_ALARM_PROGRAM.ToString(), "C,17,01,01", "", "")

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
    ''' <author>
    '''    	<name>Dat Cao</name>
    '''    	<date> 2012-12-14</date>
    ''' </author>
    ''' <summary>
    ''' MessageGuiBusinessDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property CoronaMaintenanceDoc() As System.Xml.XmlDocument
        Get
            If m_IBEMaintenanceDoc Is Nothing Then
                m_IBEMaintenanceDoc = New System.Xml.XmlDocument()
                Try
                    m_IBEMaintenanceDoc = BinarySerialize.Open_DatFileConfig(FPath_IBEMaintenance)
                    If m_IBEMaintenanceDoc Is Nothing Then
                        m_IBEMaintenanceDoc = New System.Xml.XmlDocument()
                        m_IBEMaintenanceDoc.LoadXml(XMLResources.IBEServer.XMLText)
                        BinarySerialize.SaveTo_DatFileConfig(FPath_IBEMaintenance, m_IBEMaintenanceDoc)
                    End If
                Catch ex As Exception
                    'try to load the local file
                    m_IBEMaintenanceDoc.LoadXml(XMLResources.IBEServer.XMLText)
                    BinarySerialize.SaveTo_DatFileConfig(FPath_IBEMaintenance, m_IBEMaintenanceDoc)
                    'm_IBEMaintenanceDoc.Save(FPath_IBEMaintenance)
                End Try

            End If
            Return m_IBEMaintenanceDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_IBEMaintenanceDoc = value
        End Set
    End Property
#End Region
#Region "IBEMaintenanceDoc"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' MessageGuiBusinessDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property IBEMaintenanceDoc() As System.Xml.XmlDocument
        Get
            If m_IBEMaintenanceDoc Is Nothing Then
                m_IBEMaintenanceDoc = New System.Xml.XmlDocument()
                Try
                    ''m_IBEMaintenanceDoc.Load(FPath_IBEMaintenance)
                    m_IBEMaintenanceDoc = BinarySerialize.Open_DatFileConfig(FPath_IBEMaintenance)
                    If m_IBEMaintenanceDoc Is Nothing Then
                        m_IBEMaintenanceDoc = New System.Xml.XmlDocument()
                        m_IBEMaintenanceDoc.LoadXml(XMLResources.IBEServer.XMLText)
                        BinarySerialize.SaveTo_DatFileConfig(FPath_IBEMaintenance, m_IBEMaintenanceDoc)
                    End If
                Catch ex As Exception
                    'try to load the local file
                    m_IBEMaintenanceDoc.LoadXml(XMLResources.IBEServer.XMLText)
                    BinarySerialize.SaveTo_DatFileConfig(FPath_IBEMaintenance, m_IBEMaintenanceDoc)
                    'm_IBEMaintenanceDoc.Save(FPath_IBEMaintenance)
                End Try

            End If
            Return m_IBEMaintenanceDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_IBEMaintenanceDoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name>le hieu truc</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' MessageGuiBusinessDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property PVDMaintenanceDoc() As System.Xml.XmlDocument
        Get
            If m_PVDMaintenanceDoc Is Nothing Then
                m_PVDMaintenanceDoc = New System.Xml.XmlDocument()
                Try
                    'm_PVDMaintenanceDoc.Load(FPath_PVDMaintenance)
                    m_PVDMaintenanceDoc = BinarySerialize.Open_DatFileConfig(FPath_PVDMaintenance)
                Catch ex As Exception
                    'try to load the local file
                    m_PVDMaintenanceDoc.LoadXml(XMLResources.PVDServer.XMLText)
                    'm_PVDMaintenanceDoc.Save(FPath_PVDMaintenance)
                    BinarySerialize.SaveTo_DatFileConfig(FPath_PVDMaintenance, m_PVDMaintenanceDoc)
                End Try

            End If
            Return m_PVDMaintenanceDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_PVDMaintenanceDoc = value
        End Set
    End Property
#End Region

#Region "Message Gui Business"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' MessageGuiBusinessDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property MessageGuiBusinessDoc() As System.Xml.XmlDocument
        Get
            If m_MessageGuiBusinessDoc Is Nothing Then
                m_MessageGuiBusinessDoc = New System.Xml.XmlDocument()
                Try
                    'm_MessageGuiBusinessDoc.Load(FPath_MessageGuiBusiness)
                    m_MessageGuiBusinessDoc = BinarySerialize.Open_DatFileConfig(AVPLib.ContainerDAO.FPath_MessageGuiBusiness)
                    If m_MessageGuiBusinessDoc Is Nothing Then
                        m_MessageGuiBusinessDoc = New System.Xml.XmlDocument()
                        m_MessageGuiBusinessDoc.LoadXml(XMLResources.ParseMessageGuiBusiness.XMLText)
                        'm_MessageGuiBusinessDoc.Save(FPath_MessageGuiBusiness)
                        BinarySerialize.SaveTo_DatFileConfig(FPath_MessageGuiBusiness, m_MessageGuiBusinessDoc)
                    End If
                Catch ex As Exception
                    'try to load the local file
                    m_MessageGuiBusinessDoc.LoadXml(XMLResources.ParseMessageGuiBusiness.XMLText)
                    'm_MessageGuiBusinessDoc.Save(FPath_MessageGuiBusiness)
                    BinarySerialize.SaveTo_DatFileConfig(FPath_MessageGuiBusiness, m_MessageGuiBusinessDoc)
                End Try
            End If
            Return m_MessageGuiBusinessDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_MessageGuiBusinessDoc = value
        End Set
    End Property
#End Region

#Region "User - Group"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Get Property User Document Xml
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property UserDoc() As System.Xml.XmlDocument
        Get
            If m_UserDoc Is Nothing Then
                m_UserDoc = New System.Xml.XmlDocument()
                Try
                    m_UserDoc = BinarySerialize.Open_DatFileConfig(FPath_User)
                    If m_UserDoc Is Nothing Then
                        m_UserDoc = New System.Xml.XmlDocument()
                        m_UserDoc.LoadXml(XMLResources.User.XMLText)
                        BinarySerialize.SaveTo_DatFileConfig(FPath_User, m_UserDoc)
                    End If
                Catch ex As Exception
                    'try to load the local file
                    m_UserDoc.LoadXml(XMLResources.User.XMLText)
                    BinarySerialize.SaveTo_DatFileConfig(FPath_User, m_UserDoc)
                End Try
            End If
            Return m_UserDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_UserDoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Get Property Group Document Xml
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property GroupDoc() As System.Xml.XmlDocument
        Get
            If m_GroupDoc Is Nothing Then
                m_GroupDoc = New System.Xml.XmlDocument()
                Try
                    m_GroupDoc = BinarySerialize.Open_DatFileConfig(FPath_Group)
                    If m_GroupDoc Is Nothing Then
                        m_GroupDoc = New System.Xml.XmlDocument()
                        m_GroupDoc.LoadXml(XMLResources.Group.XMLText)
                        BinarySerialize.SaveTo_DatFileConfig(FPath_Group, m_GroupDoc)
                    End If
                Catch ex As Exception
                    'try to load the local file
                    m_GroupDoc.LoadXml(XMLResources.Group.XMLText)
                    BinarySerialize.SaveTo_DatFileConfig(FPath_Group, m_GroupDoc)
                End Try
            End If
            Return m_GroupDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_GroupDoc = value
        End Set
    End Property
#End Region


#Region "Recipe - Chamber"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Recipe Doc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property RecipeDoc() As System.Xml.XmlDocument
        Get
            If m_RecipeDoc Is Nothing Then
                m_RecipeDoc = New System.Xml.XmlDocument()
                Try
                    m_RecipeDoc = BinarySerialize.Open_DatFileConfig(FPath_Recipe)
                    If m_RecipeDoc Is Nothing Then
                        m_RecipeDoc = New System.Xml.XmlDocument()
                        m_RecipeDoc.LoadXml(XMLResources.Recipe.XMLText)
                        BinarySerialize.SaveTo_DatFileConfig(FPath_Recipe, m_RecipeDoc)
                    End If
                Catch ex As Exception
                    'try to load the local file
                    m_RecipeDoc.LoadXml(XMLResources.Recipe.XMLText)
                    BinarySerialize.SaveTo_DatFileConfig(FPath_Recipe, m_RecipeDoc)
                End Try
            End If
            Return m_RecipeDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_RecipeDoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Chamber Doc Map
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ChamberDocMap() As Hashtable
        Get
            If m_ChamberDocMap Is Nothing Then
                RefreshChamberDocMap(True)
            End If
            Return m_ChamberDocMap
        End Get
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-09-07</date>
    ''' </author>
    ''' <summary>
    ''' Refresh Chamber Doc Map
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub RefreshChamberDocMap(ByVal blnUpdateFirstLoad As Boolean)
        m_ChamberDocMap = New Hashtable()
        '
        m_ChamberDocMap = ChamberLib.GetMapDocumentChamber(RecipeDoc, blnUpdateFirstLoad)
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' List Chamber Doc Map
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property ListChamberDocMap() As Hashtable
        Get
            If m_ListChamberDocMap Is Nothing Then
                m_ListChamberDocMap = New Hashtable()
            End If
            Return m_ListChamberDocMap
        End Get
        Set(ByVal value As Hashtable)
            m_ListChamberDocMap = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <summary>
    ''' Get Chamber Doc
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <param name="ChamberNameActive"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChamberDoc(ByVal ChamberName As String, ByVal ChamberNameActive As String) As System.Xml.XmlDocument
        Try
            Dim path_ChamberName As String = FPath_ChamberRecipe + "\" + ChamberName + "\" + ChamberNameActive

            Dim serConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ChamberName)
            If (Enable_ANYIBE_Mode() AndAlso serConfig IsNot Nothing AndAlso serConfig.Type = ConstEnum.IBEType.AVP_IBE.ToString()) Then
                path_ChamberName = FPath_ChamberRecipe + "\" + RobotConfigurationValues.ANY_IBE_CHAMBER + "\" + ChamberNameActive
            End If

            If System.IO.File.Exists(path_ChamberName) = False Then
                Return Nothing
            End If
            Dim ChamberDoc As New System.Xml.XmlDocument()
            ChamberDoc.Load(path_ChamberName)
            Return ChamberDoc
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <summary>
    ''' Get Chamber Step Doc
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <param name="ChamberNameActive"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared ReadOnly Property GetChamberStepDoc(ByVal ChamberName As String, ByVal ChamberNameActive As String) As System.Xml.XmlDocument
        Get
            Return GetChamberDoc(ChamberName, ChamberNameActive)
        End Get
    End Property
#End Region

#Region "Sequence"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' Save SaveSequenceFile to  filePath
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub SaveWFSequenceFile(ByVal Waferdoc As Xml.XmlDocument, ByVal filePath As String)
        AVPLib.Log.guiLogger.Info("Enter SaveSequenceFile")
        Try
            'Waferdoc.Save(filePath)
            BinarySerialize.SaveTo_DatFileConfig(filePath, Waferdoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SaveSequenceFile")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' Save SaveSequenceFile to  filePath
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OpenWFSequenceFile(ByVal filePath As String) As Xml.XmlDocument
        AVPLib.Log.guiLogger.Info("Enter OpenSequenceFile")
        Try
            If m_SequenceDoc Is Nothing Then
                m_SequenceDoc = New Xml.XmlDocument
            End If
            ' m_SequenceDoc.Load(filePath)
            m_SequenceDoc = BinarySerialize.Open_DatFileConfig(filePath)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave OpenSequenceFile")
        Return m_SequenceDoc
    End Function

   
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-31</date>
    ''' </author>
    ''' <summary>
    ''' Get Proerty SequenceData Document Xml
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared ReadOnly Property SequenceDataDoc(ByVal filename As String) As System.Xml.XmlDocument
        Get
            If SequenceDataDocMap.Contains(filename) Then
                Return SequenceDataDocMap.Item(filename)
            End If

            Dim SequenceData As New System.Xml.XmlDocument()
            Dim filepath As String = FPath_SequenceData + "\" + filename
            If System.IO.File.Exists(filepath) = False Then
                Return Nothing
            End If
            'SequenceData.Load(filepath)
            SequenceData = BinarySerialize.Open_DatFileConfig(filepath)
            'SequenceDataDocMap.Add(filename, SequenceData)
            Return SequenceData
        End Get
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-31</date>
    ''' </author>
    ''' <summary>
    ''' SequenceDataDocMap
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared ReadOnly Property SequenceDataDocMap() As Hashtable
        Get
            If m_SequenceDataDocMap Is Nothing Then
                m_SequenceDataDocMap = New Hashtable()
            End If
            Return m_SequenceDataDocMap
        End Get
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-31</date>
    ''' </author>
    ''' <summary>
    ''' GetListSequenceName
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetListSequenceName() As ArrayList
        Try
            Return SequenceLib.GetListSequenceName(ContainerDAO.FPath_SequenceData)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
#End Region
    Public Shared Property PVD5TSystemConfigDoc() As System.Xml.XmlDocument
        Get
            Return m_PVD5TSystemConfigDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_PVD5TSystemConfigDoc = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-06-30</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property SystemConfigDoc() As System.Xml.XmlDocument
        Get
            Return m_SystemConfigDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_SystemConfigDoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2024-01-24</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    Public Shared Property RevisionConfigDoc() As System.Xml.XmlDocument
        Get
            Return m_RevisionConfigDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_RevisionConfigDoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Get current process command doc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property ProcessCommandDoc() As System.Xml.XmlDocument
        Get
            If m_ProcessCommandDoc Is Nothing Then
                m_ProcessCommandDoc = New System.Xml.XmlDocument()
                Try
                    'm_ProcessCommandDoc.Load(FPath_ProcessCommand)
                    m_ProcessCommandDoc = BinarySerialize.Open_DatFileConfig(FPath_ProcessCommand)
                Catch ex As Exception
                    'try to load the local file
                    m_ProcessCommandDoc.LoadXml(XMLResources.ProcessCommand.XMLText)
                    'm_ProcessCommandDoc.Save(FPath_ProcessCommand)
                    BinarySerialize.SaveTo_DatFileConfig(FPath_ProcessCommand, m_ProcessCommandDoc)
                End Try
            End If
            Return m_ProcessCommandDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_ProcessCommandDoc = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Gett current meessage equipment doc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property MessageEquipmentDoc() As System.Xml.XmlDocument
        Get
            Try
                If m_MessageEquipmentDoc Is Nothing Then
                    m_MessageEquipmentDoc = New System.Xml.XmlDocument()
                    Try
                        ' m_MessageEquipmentDoc.Load(FPath_MessageEquipment)
                        m_MessageEquipmentDoc = BinarySerialize.Open_DatFileConfig(FPath_MessageEquipment)
                        If m_MessageEquipmentDoc Is Nothing Then
                            m_MessageEquipmentDoc = New System.Xml.XmlDocument()
                            m_MessageEquipmentDoc.LoadXml(XMLResources.ParseMessageName.XMLText)
                            'm_MessageEquipmentDoc.Save(FPath_MessageEquipment)
                            BinarySerialize.SaveTo_DatFileConfig(FPath_MessageEquipment, m_MessageEquipmentDoc)
                        End If
                    Catch ex As Exception
                        'try to load the local file
                        m_MessageEquipmentDoc.LoadXml(XMLResources.ParseMessageName.XMLText)
                        'm_MessageEquipmentDoc.Save(FPath_MessageEquipment)
                        BinarySerialize.SaveTo_DatFileConfig(FPath_MessageEquipment, m_MessageEquipmentDoc)
                    End Try
                End If
            Catch ex As Exception
                Return Nothing
            End Try

            Return m_MessageEquipmentDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_MessageEquipmentDoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' ValueMessageEquipmentDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property ValueMessageEquipmentDoc() As System.Xml.XmlDocument
        Get
            Try
                If m_ValueMessageEquipmentDoc Is Nothing Then
                    m_ValueMessageEquipmentDoc = New System.Xml.XmlDocument()
                    Try
                        ' m_ValueMessageEquipmentDoc.Load(FPath_ValueMessageEquipment)
                        m_ValueMessageEquipmentDoc = BinarySerialize.Open_DatFileConfig(FPath_ValueMessageEquipment)
                        If m_ValueMessageEquipmentDoc Is Nothing Then
                            m_ValueMessageEquipmentDoc = New System.Xml.XmlDocument()
                            m_ValueMessageEquipmentDoc.LoadXml(XMLResources.ParseMessageValue.XMLText)
                            'm_ValueMessageEquipmentDoc.Save(FPath_ValueMessageEquipment)
                            BinarySerialize.SaveTo_DatFileConfig(FPath_ValueMessageEquipment, m_ValueMessageEquipmentDoc)
                        End If
                    Catch ex As Exception
                        'try to load the local file
                        m_ValueMessageEquipmentDoc.LoadXml(XMLResources.ParseMessageValue.XMLText)
                        'm_ValueMessageEquipmentDoc.Save(FPath_ValueMessageEquipment)
                        BinarySerialize.SaveTo_DatFileConfig(FPath_ValueMessageEquipment, m_ValueMessageEquipmentDoc)
                    End Try
                End If
            Catch ex As Exception
                Return Nothing
            End Try

            Return m_ValueMessageEquipmentDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_ValueMessageEquipmentDoc = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' ConfigurationServerDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property ConfigurationServerDoc() As System.Xml.XmlDocument
        Get
            Try
                If m_ConfigurationServerDoc Is Nothing Then
                    m_ConfigurationServerDoc = New System.Xml.XmlDocument()
                    Try
                        'm_ConfigurationServerDoc.Load(FPath_ConfigurationServer)
                        m_ConfigurationServerDoc = BinarySerialize.Open_DatFileConfig(FPath_ConfigurationServer)
                        If m_ConfigurationServerDoc Is Nothing Then
                            m_ConfigurationServerDoc = New System.Xml.XmlDocument()
                            m_ConfigurationServerDoc.LoadXml(XMLResources.ConfigurationServer.XMLText)
                            'm_ConfigurationServerDoc.Save(FPath_ConfigurationServer)
                            BinarySerialize.SaveTo_DatFileConfig(FPath_ConfigurationServer, m_ConfigurationServerDoc)
                        End If
                    Catch ex As Exception
                        'try to load the local file
                        m_ConfigurationServerDoc.LoadXml(XMLResources.ConfigurationServer.XMLText)
                        'm_ConfigurationServerDoc.Save(FPath_ConfigurationServer)
                        BinarySerialize.SaveTo_DatFileConfig(FPath_ConfigurationServer, m_ConfigurationServerDoc)
                    End Try

                End If
            Catch ex As Exception

            End Try

            Return m_ConfigurationServerDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_ConfigurationServerDoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-11</date>
    ''' </author>
    ''' <summary>
    ''' Driver Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub LoadDriverConfigDoc()
        Try
            If m_DriverConfigDoc Is Nothing Then
                m_DriverConfigDoc = New System.Xml.XmlDocument()
                Try
                    m_DriverConfigDoc.Load(FPath_DriverConfig)
                    If m_DriverConfigDoc Is Nothing Then
                        m_DriverConfigDoc = New System.Xml.XmlDocument()
                        m_DriverConfigDoc.LoadXml(XMLResources.DriverConfig.XMLText)
                        'm_ConfigurationServerDoc.Save(FPath_ConfigurationServer)
                        BinarySerialize.SaveTo_DatFileConfig(FPath_DriverConfig, m_DriverConfigDoc)
                    End If
                Catch ex As Exception
                    'try to load the local file
                    m_DriverConfigDoc.LoadXml(XMLResources.DriverConfig.XMLText)
                    'm_ConfigurationServerDoc.Save(FPath_ConfigurationServer)
                    BinarySerialize.SaveTo_DatFileConfig(FPath_DriverConfig, m_DriverConfigDoc)
                End Try

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2024-01-24</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    Public Shared Sub LoadRevisionDriverConfigDoc()
        Try
            If m_RevisionConfigDoc Is Nothing Then
                m_RevisionConfigDoc = New System.Xml.XmlDocument()
                Try
                    If Not System.IO.File.Exists(ContainerDAO.FPath_RevisionConfig) Then
                        Dim strRevisionConfig As String = "RevisionConfig"
                        Dim xmlDoc As New XmlDocument()
                        Dim rootElement As XmlElement = xmlDoc.CreateElement(strRevisionConfig)
                        xmlDoc.AppendChild(rootElement)

                        ' save
                        xmlDoc.Save(ContainerDAO.FPath_RevisionConfig)
                    End If
                    If (System.IO.File.Exists(ContainerDAO.FPath_RevisionConfig)) Then
                        m_RevisionConfigDoc = BinarySerialize.Open_DatFileConfig(FPath_RevisionConfig)
                    End If
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-11</date>
    ''' </author>
    ''' <summary>
    ''' Rough Pump Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub LoadRoughPumpConfig()
        Try
            'load from file
            Dim RoughPumpConfigDoc As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROUGHPUMP_CONFIG)
            'new data object
            If (m_RoughPumpList IsNot Nothing) Then
                m_RoughPumpList.Clear()
            Else
                m_RoughPumpList = New List(Of String)()
            End If

            'read data config and store to data object
            If (RoughPumpConfigDoc IsNot Nothing) Then
                For Each RouughGroup As System.Xml.XmlNode In RoughPumpConfigDoc.ChildNodes
                    Dim RoughNameNode As Xml.XmlAttribute = RouughGroup.Attributes.ItemOf(ConstEnum.Name)

                    'add it to list
                    m_RoughPumpList.Add(RoughNameNode.Value.ToString)

                    If (RoughNameNode IsNot Nothing) Then
                        If (m_RoughPumpConfigMap Is Nothing) Then
                            m_RoughPumpConfigMap = New Hashtable()
                        End If
                        For Each xmlItem As System.Xml.XmlNode In RouughGroup.ChildNodes
                            If (xmlItem IsNot Nothing AndAlso xmlItem.InnerText IsNot Nothing) Then
                                m_RoughPumpConfigMap.Add(xmlItem.InnerText, RoughNameNode.Value)
                            End If
                        Next

                        AVPLib.Log.avpLogger.Info("Leave CreateDriver")
                    End If
                Next
                If (m_RoughPumpConfigMap IsNot Nothing AndAlso m_RoughPumpConfigMap.ContainsValue("RoughPumpMachine1")) Then
                    RobotConfigurationValues.ROUGH_PUMP1_INSTALLED = True
                Else
                    RobotConfigurationValues.ROUGH_PUMP1_INSTALLED = False
                End If
                If (m_RoughPumpConfigMap IsNot Nothing AndAlso m_RoughPumpConfigMap.ContainsValue("RoughPumpMachine2")) Then
                    RobotConfigurationValues.ROUGH_PUMP2_INSTALLED = True
                Else
                    RobotConfigurationValues.ROUGH_PUMP2_INSTALLED = False
                End If
            Else
                AVPLib.Log.avpLogger.Error("Can't read Rough pump config")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2015-07-27</date>
    ''' </author>
    ''' <summary>
    ''' Get number light alarm configuration
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Number_Light_Alarm() As Integer
        Dim blResult As Integer = False
        Try
            ' The XPath to the polling session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_NUMBER_LIGHT_ALARM)
            Integer.TryParse(root.InnerText, blResult)
            RobotConfigurationValues.NUMBER_LIGHT_ALARM = blResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return blResult
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-04-07 </date>
    ''' </author>
    ''' <summary>
    ''' Get number of active light configuration
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Number_Active_Light() As Integer
        Dim blResult As Integer = False
        Try
            ' The XPath to the polling session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_NUMBER_ACTIVE_LIGHT)
            Integer.TryParse(root.InnerText, blResult)
            RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = blResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return blResult
    End Function

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-08-08</date>
    ''' </author>
    ''' <summary>
    '''Is Slow Vent Rough installed
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LoadSlowRoughInstalled() As Boolean
        Dim blResult As Boolean = False
        Try
            ' The XPath to the polling session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SLOW_ROUGH_CONFIG)
            Boolean.TryParse(root.InnerText, blResult)
            RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED = blResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return blResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-08-08</date>
    ''' </author>
    ''' <summary>
    '''Is Slow Vent Rough installed
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LoadSlowVentInstalled() As Boolean
        Dim blResult As Boolean = False
        Try
            ' The XPath to the polling session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SLOW_VENT_CONFIG)
            Boolean.TryParse(root.InnerText, blResult)
            RobotConfigurationValues.LL_SLOW_VENT_INSTALLED = blResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return blResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-11</date>
    ''' </author>
    ''' <summary>
    ''' Driver Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property DriverConfigDoc() As Xml.XmlDocument
        Get
            Return m_DriverConfigDoc
        End Get
        Set(ByVal value As Xml.XmlDocument)
            m_DriverConfigDoc = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-11</date>
    ''' </author>
    ''' <summary>
    ''' Rough Pump Congfig
    ''' key = Equipment Name
    ''' value = Rough Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property RoughPumpConfigMap() As Hashtable
        Get
            Return m_RoughPumpConfigMap
        End Get
        Set(ByVal value As Hashtable)
            m_RoughPumpConfigMap = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-11</date>
    ''' </author>
    ''' <summary>
    ''' Rough Pump Name List
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property RoughPumpNameList() As List(Of String)
        Get
            Return m_RoughPumpList
        End Get
    End Property

    ''' <author>
    '''    <name> Huy Nguyen </name>
    '''    <date> 2015-07-03</date>
    ''' </author>
    ''' <summary>
    '''Get password to exit devicenet app
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PasswordExitDevicenetApp() As String
        Dim strResult As String = String.Empty
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_PASSWORD_EXIT_DEVICENET_APP)
            strResult = root.InnerText
            RobotConfigurationValues.PASSWORD_EXIT_DEVICENETAPP = strResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strResult
    End Function

#Region "Function Dao"
#Region "Log"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-23</date>
    ''' </author>
    ''' <summary>
    ''' Log Alarm Event
    ''' </summary>
    ''' <param name="LogUser"></param>
    ''' <param name="Type"></param>
    ''' <param name="Source"></param>
    ''' <param name="Description"></param>
    ''' <returns></returns>

    Public Shared Function LogAlarmEvent(ByVal LogUser As String, ByVal Type As String, ByVal Source As String, ByVal Description As String, ByVal GemAlarmName As String) As Integer
        Try
            Dim conn As System.Data.OleDb.OleDbConnection = Connection.ConnectionAccess
            If (Type = "Alarm") Then
#If AVP_PLATFORM = "CX" Then
                If Not String.IsNullOrEmpty(GemAlarmName) Then
                    Business.AVPSecsGemLib.SECSGEM_CommonAlarmSet(GemAlarmName, Source + "." + Description)
                End If
#End If
            End If
            Return Log.LogAlarmEvent(conn, LogUser, Type, Source, Description)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return 0
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-23</date>
    ''' </author>
    ''' <summary>
    ''' Load Log Alarm Event
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LoadLogAlarmEvent(ByRef LoadDataGrid_Worker As ComponentModel.BackgroundWorker, ByVal filter As String) As DataTable
        Try
            Dim listConnection As ArrayList = Connection.ConnectionListAccess
            Return Log.LoadLogAlarmEvent(LoadDataGrid_Worker, listConnection, filter)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
#End Region

#Region "User-Group"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' GetUser from UserSetupLib.GetUser
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetUser(ByVal Username As String) As DBUser
        Try
            Return UserSetupLib.GetUser(UserDoc, Username)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-06-26</date>
    ''' </author>
    ''' <summary>
    ''' GetUser from UserSetupLib.GetUser
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetListOfDefaultAccess() As Hashtable
        Try
            Return UserSetupLib.GetDefaultAccessForUser(UserDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' GetListUser
    ''' </summary>
    ''' <returns>List String</returns>
    ''' <remarks></remarks>
    Shared Function GetListUser() As ArrayList 'List String Username
        Try
            Return UserSetupLib.GetListUser(UserDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' SaveUser from UserSetupLib.SaveUser
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SaveUser(ByVal user As DBUser) As DBUser
        Try
            Return UserSetupLib.SaveUser(UserDoc, user)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' UpdateUser from UserSetupLib.UpdateUser
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function UpdateUser(ByVal user As DBUser) As DBUser
        Try
            Return UserSetupLib.UpdateUser(UserDoc, user)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' DeleteUser from UserSetupLib.DeleteUser
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function DeleteUser(ByVal user As DBUser) As DBUser
        Try
            Return UserSetupLib.DeleteUser(UserDoc, user)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' GetGroup from UserSetupLib.GetGroup
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetGroup(ByVal Id As Integer) As DBGroup
        Try
            Return UserSetupLib.GetGroup(GroupDoc, Id)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' GetListGroup
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetListGroup() As ArrayList
        Try
            Return UserSetupLib.GetListGroup(GroupDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
#End Region

#Region "Chamber"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Get List Recipe
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetListRecipe() As ArrayList
        Try
            Return ChamberLib.GetListRecipe(RecipeDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 20011-04-22</date>
    ''' </author>
    ''' <summary>
    ''' Modify : each Chamber have each Document
    ''' </summary>
    Public Shared Function GetChamber(ByVal ChamberName As String, ByVal ChamberNameActive As String) As DBChamber
        Try
            Dim chamberModule As SystemModule = Nothing
            AVPLib.ContainerData.IsChamberVisible(ChamberName, chamberModule)
            If (chamberModule IsNot Nothing) Then
                Dim ChamberParameterDoc As System.Xml.XmlDocument = ChamberDocMap.Item(ChamberName & "." & chamberModule.Type.ToString())
                Dim ChamberParameterValueDoc As System.Xml.XmlDocument = GetChamberStepDoc(ChamberName, ChamberNameActive)
                Return ChamberLib.GetChamber(ChamberName, ChamberParameterDoc, ChamberParameterValueDoc)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <summary>
    ''' GetChamberEmpty
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChamberEmpty(ByVal ChamberName As String) As DBChamber
        Try
            Dim chamberModule As SystemModule = Nothing
            AVPLib.ContainerData.IsChamberVisible(ChamberName, chamberModule)
            If (chamberModule IsNot Nothing) Then
                Dim ChamberParameterDoc As System.Xml.XmlDocument = ChamberDocMap.Item(ChamberName & "." & chamberModule.Type.ToString())
                Dim ChamberNameActive As String = ContainerData.GetRecipe(ChamberName).ChamberNameActive
                Dim ChamberParameterValueDoc As System.Xml.XmlDocument = GetChamberStepDoc(ChamberName, ChamberNameActive)
                Return ChamberLib.GetChamberEmpty(ChamberName, ChamberParameterDoc, ChamberParameterValueDoc)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <summary>
    ''' DeleteChamber
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <param name="ChamberName"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteChamber(ByVal Chamber As String, ByVal ChamberName As String)
        Try
            If (Utils.IsIBEChamber_ANYIBE(Chamber)) Then
                Utils.DeleteFile(FPath_ChamberRecipe + "\" + RobotConfigurationValues.ANY_IBE_CHAMBER + "\" + ChamberName)
            Else
                Utils.DeleteFile(FPath_ChamberRecipe + "\" + Chamber + "\" + ChamberName)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-31</date>
    ''' </author>
    ''' <summary>
    ''' UpdateChamber
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <param name="ChamberName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdateChamber(ByVal Chamber As String, ByVal ChamberName As String) As System.Xml.XmlDocument
        Try
            Return ChamberLib.UpdateChamber(RecipeDoc, Chamber, ChamberName, FPath_Recipe)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-31</date>
    ''' </author>
    ''' <summary>
    ''' SaveChamber
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveChamber(ByVal Chamber As DBChamber, ByVal FileName As String) As DBChamber
        Try
            Dim FilePath As String = String.Empty

            If (Utils.IsIBEChamber_ANYIBE(Chamber.ChamberName)) Then
                If (Not System.IO.Directory.Exists(FPath_ChamberRecipe + "\" + RobotConfigurationValues.ANY_IBE_CHAMBER)) Then
                    System.IO.Directory.CreateDirectory(FPath_ChamberRecipe + "\" + RobotConfigurationValues.ANY_IBE_CHAMBER)
                End If
                FilePath = FPath_ChamberRecipe + "\" + RobotConfigurationValues.ANY_IBE_CHAMBER + "\" + FileName
            Else
                FilePath = FPath_ChamberRecipe + "\" + Chamber.ChamberName + "\" + FileName
            End If

            Dim DBChamber As DBChamber = ChamberLib.SaveChamber(Chamber, FilePath)
            Return DBChamber
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
#End Region

#Region "Sequence"


    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Save Wafer Flow Sequence--> Call library to save
    ''' </summary>
    ''' <param name="DBListSequenceSlot"></param>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveWFSequence(ByVal currentDBSeq As AVPLib.DBWaferList, ByVal filename As String, Optional ByVal Description As String = "") As Boolean
        AVPLib.Log.guiLogger.Info("Enter SaveWFSequence")
        Dim blnsuccess As Boolean = False
        Try
            blnsuccess = SequenceLib.SaveWFSequence(currentDBSeq, filename, Description)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Enter SaveWFSequence")
        Return blnsuccess
    End Function

    ''' <author>
    '''<name>Tinh Le</name>
    '''<date> 2018/11/29</date>
    ''' </author>
    ''' <summary>
    ''' SaveCGConfig
    ''' </summary>
    Public Shared Function SaveCGConfig(ByVal mapPumpdownConfig As Hashtable) As Boolean
        Try
            Return VentPumdownLib.SavePumpdown(SystemConfigDoc, mapPumpdownConfig, CG_CONFIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Delete Sequence
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteSequence(ByVal FileName As String)
        Try
            Utils.DeleteFile(FPath_SequenceData + "\" + FileName)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
#End Region

#Region "Function Message"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-20</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get polling config
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPollingConfig() As Hashtable
        Dim map As New Hashtable()
        Try
            ' The XPath to the polling session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEMPOLLING)

            map = PollingLib.GetConfig(root)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return map
    End Function
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' SavePollingConfig
    ''' </summary>
    ''' <param name="mapPollingConfig"></param>
    ''' <remarks></remarks>
    'Public Shared Function SavePollingConfig(ByVal mapPollingConfig As Hashtable) As Boolean
    '    Try
    '        Return PollingLib.SaveConfig(SystemConfigDoc, mapPollingConfig)
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    Return False
    'End Function

    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' SavePressureConfig
    ''' </summary>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Public Shared Function SavePressureConfig(ByVal mapPerssureConfig As Hashtable) As Boolean
        Try
            Return PressureConfigurationLib.SavePressure(SystemConfigDoc, mapPerssureConfig)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    Public Shared Function SaveTransferPressureSetpointConfig(ByVal mapPerssureConfig As Hashtable) As Boolean
        Try
            Return PressureConfigurationLib.SaveTransferPressureSetpoint(SystemConfigDoc, mapPerssureConfig)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    Public Shared Function SaveCryoRegenHourLimit() As Boolean
        Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_CRYO_REGEN_HOUR_LIMIT)
        Dim bXmlDocChanged As Boolean = False
        Try
            If root IsNot Nothing Then
                root.InnerText = AVPLib.RobotConfigurationValues.CRYO_REGEN_HOURS_LIMIT.ToString()
                bXmlDocChanged = True
            End If

            If bXmlDocChanged Then
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function


    Public Shared Function SaveDegasWaitTime(ByVal LLADegasWaitTime As String, ByVal TMDegasWaitTime As String) As Boolean
        Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_DEGAS_WAIT_TIME)
        Dim bXmlDocChanged As Boolean = False
        Try
            Dim LLADegasWaitTimeNode As Xml.XmlNode = root.FirstChild.FirstChild
            If Not String.IsNullOrEmpty(LLADegasWaitTime) Then
                LLADegasWaitTimeNode.InnerText = LLADegasWaitTime
                bXmlDocChanged = True
            End If

            Dim TMDegasWaitTimeNode As Xml.XmlNode = root.LastChild
            If Not String.IsNullOrEmpty(TMDegasWaitTime) Then
                TMDegasWaitTimeNode.InnerText = TMDegasWaitTime
                bXmlDocChanged = True
            End If
            If bXmlDocChanged Then
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    Public Shared Function SaveRORLitterValue(ByVal LLARORLitter As String, ByVal TMRORLitter As String) As Boolean
        Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
        Dim bxmlDocChanged As Boolean = False
        Try
            For Each item As Xml.XmlNode In root.ChildNodes

                If item.FirstChild.InnerText = ConstEnum.LoadLockA_STR And Not String.IsNullOrEmpty(LLARORLitter) Then
                    item.LastChild.InnerText = LLARORLitter
                    bxmlDocChanged = True
                    Continue For
                End If

                If item.FirstChild.InnerText = "Robot" And Not String.IsNullOrEmpty(TMRORLitter) Then
                    item.LastChild.InnerText = TMRORLitter
                    bxmlDocChanged = True
                    Continue For
                End If
            Next

            If bxmlDocChanged Then
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
                Return True
            End If
        Catch ex As Exception

        End Try

    End Function


    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-09 </date>
    ''' </author>
    ''' <summary>
    ''' Save AllowCheckingECCLimit value to System Config
    ''' </summary>
    Public Shared Function SaveAllowCheckingECCLimit(ByVal value As Boolean) As Boolean
        Return SaveSystemConfigTag(ConstEnum.XPATH_ALLOW_CHECKING_ECC_LIMIT, value)
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-09 </date>
    ''' </author>
    ''' <summary>
    ''' Save ECC_M_Limit value to System Config
    ''' </summary>
    Public Shared Function SaveECC_M_Limit(ByVal value As Integer) As Boolean
        Return SaveSystemConfigTag(ConstEnum.XPATH_ECC_M_LIMIT, value)
    End Function

    ''' <author>
    '''     <name> Dung Pham </name>
    '''     <date> 2017-07-11 </date>
    ''' </author>
    ''' <summary>
    ''' Save SystemCleanUpDataRunTimeInDays, AutoArchiveSystemConfigFile
    ''' </summary>
    Public Shared Function SaveAutoPurgeDayConfig(ByVal isEnabled As Boolean, ByVal valueDay As String) As Boolean
        Dim isSuccess As Boolean = False

        Try
            isSuccess = UpdateSystemConfigTag(XPATH_AUTO_ARCHIVE_SYSTEM_CONFIG_FILE, isEnabled)
            isSuccess = UpdateSystemConfigTag(XPATH_SYSTEM_CLEANUP_DATARUN_TIME, valueDay) AndAlso isSuccess

            If isSuccess Then
                isSuccess = SaveSystemConfigToFile()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return isSuccess
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-09 </date>
    ''' </author>
    ''' <summary>
    ''' Save ManualDefineGEMWaferID value to System Config
    ''' </summary>
    Public Shared Function SaveSupportManualDefineGEMWaferID(ByVal value As Boolean) As Boolean
        Return SaveSystemConfigTag(ConstEnum.XPATH_MANUALDEFINE_GEMWAFERID, value)
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-10 </date>
    ''' </author>
    ''' <summary>
    ''' Save system config tag
    ''' </summary>
    Public Shared Function SaveSystemConfigTag(ByVal tagConfigXPath As String, ByVal value As Object) As Boolean
        Dim result As Boolean = False
        Try
            Dim tagNode As Xml.XmlNode = SystemConfigDoc.SelectSingleNode(tagConfigXPath)
            If tagNode IsNot Nothing Then
                tagNode.InnerText = Convert.ToString(value)

                ' Save to file
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
                result = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-10 </date>
    ''' </author>
    ''' <summary>
    ''' Update system config tag value to xml document with save to file
    ''' </summary>
    Public Shared Function UpdateSystemConfigTag(ByVal tagConfigXPath As String, ByVal value As Object) As Boolean
        Dim result As Boolean = False
        Try
            Dim tagNode As Xml.XmlNode = SystemConfigDoc.SelectSingleNode(tagConfigXPath)
            If tagNode IsNot Nothing Then
                tagNode.InnerText = Convert.ToString(value)
                result = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-10 </date>
    ''' </author>
    ''' <summary>
    ''' Save System Config document to file
    ''' </summary>
    Public Shared Function SaveSystemConfigToFile() As Boolean
        Dim result As Boolean = False
        Try
            ' Save to file
            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
            result = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    Public Shared Function SaveLLElevatorConfig(ByVal LLElevatorConfig As Hashtable, ByVal LLElevatorName As String) As Boolean
        Dim bXmlDocChanged As Boolean = False
        Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_LL_ELEVATOR_CONFIG)
        Dim nodeListLLElevatorConfig As System.Xml.XmlNodeList = root.ChildNodes
        For idx As Integer = 0 To nodeListLLElevatorConfig.Count - 1
            Try
                Dim LLConfigNode As System.Xml.XmlNode = nodeListLLElevatorConfig.Item(idx)
                If LLElevatorName = LLConfigNode.Name Then
                    For i As Integer = 0 To LLConfigNode.ChildNodes.Count - 1
                        Dim Name As String = LLConfigNode.ChildNodes.Item(i).Attributes.ItemOf("Name").InnerText
                        If (LLElevatorConfig.ContainsKey(Name)) Then
                            Dim val As Integer = LLElevatorConfig.Item(Name)
                            Dim oldValue As String = LLConfigNode.ChildNodes.Item(i).Attributes.ItemOf("Value").Value.ToString()
                            Dim IsItemSettingChanged As Boolean = IIf(val.ToString() = oldValue, False, True)
                            If IsItemSettingChanged Then
                                bXmlDocChanged = True
                                LLConfigNode.ChildNodes.Item(i).Attributes.ItemOf("Value").Value = val
                            End If
                        End If
                    Next
                    If (bXmlDocChanged) Then
                        'SystemConfigDoc.Save(ContainerDAO.FPath_SystemConfig)
                        BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
                    End If
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Info("Error in insert data: " & ex.Message)
            End Try
        Next
        Return False
    End Function

    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' SavePumpdownConfigLL
    ''' </summary>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Public Shared Function SavePumpdownConfigLL(ByVal mapPumpdownConfig As Hashtable) As Boolean
        Try
            Return VentPumdownLib.SavePumpdown(SystemConfigDoc, mapPumpdownConfig, LLPUMPDOWN_CONFIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function
    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' SavePumpdownConfigTM
    ''' </summary>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Public Shared Function SavePumpdownConfigTM(ByVal mapPumpdownConfig As Hashtable) As Boolean
        Try
            Return VentPumdownLib.SavePumpdown(SystemConfigDoc, mapPumpdownConfig, TMPUMPDOWN_CONFIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function
    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' SaveVentLL
    ''' </summary>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Public Shared Function SaveVentLL(ByVal mapPumpdownConfig As Hashtable) As Boolean
        Try
            Return VentPumdownLib.SavePumpdown(SystemConfigDoc, mapPumpdownConfig, LLVENT_CONFIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function
    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' SaveVentTM
    ''' </summary>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Public Shared Function SaveVentTM(ByVal mapPumpdownConfig As Hashtable) As Boolean
        Try
            Return VentPumdownLib.SavePumpdown(SystemConfigDoc, mapPumpdownConfig, TMVENT_CONFIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name>Ngo Cao Dinh</name>
    '''    	<date> 2008-11-20</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get timeout config
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTimeoutConfig() As Hashtable
        Dim map As New Hashtable()
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEMTIMEOUT)
            ' map = TimeoutLib.GetConfig(root)
            map = TimeoutLib.GetConfigFromCode()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return map
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-06-03</date>
    ''' </author>
    ''' <summary>
    ''' Get ToolID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetToolID() As String
        Dim strToolID As String = String.Empty
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_TOOLID)
            strToolID = root.InnerText
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strToolID
    End Function

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2019-01-4</date>
    ''' </author>
    ''' <summary>
    ''' Save ToolID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub SaveToolID(ByVal strToolID As String)
        Try

            Dim ToolID As Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_TOOLID)
            If ToolID IsNot Nothing Then
                ToolID.InnerText = strToolID
            End If

            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, SystemConfigDoc)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Function GetSoundOnDuringAlarm() As Boolean
        Dim blnResult As Boolean = False
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SOUND_ON_DURING_ALARM)
            Boolean.TryParse(root.InnerText, blnResult)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blnResult
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-06-03</date>
    ''' </author>
    ''' <summary>
    ''' Get ToolID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSystemWaitForCheckSensor() As Integer
        Dim intWaitTime As Integer = 0
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEM_WAIT_FOR_CHECK_SENSOR)
            If Integer.TryParse(root.InnerText, intWaitTime) = False Then
                intWaitTime = 0
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return intWaitTime
    End Function

    Public Shared Function SetSystemWaitForCheckSensor(ByVal waitTime As Int32) As Boolean
        Dim bRes As Boolean = False
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEM_WAIT_FOR_CHECK_SENSOR)
            root.InnerText = waitTime.ToString()
            BinarySerialize.SaveTo_DatFileConfig(FPath_SystemConfig, SystemConfigDoc)
            RobotConfigurationValues.SYSTEM_WAIT_FOR_CHECK_SENSOR_IN_SECONDS = waitTime
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    Public Shared Function GetSystemIDLE_Time() As Double
        Dim dSystemIDLE As Double = 0
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEMIDLE_TIME)
            If Double.TryParse(root.InnerText, dSystemIDLE) = False Then
                dSystemIDLE = 0
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return dSystemIDLE
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-12-03</date>
    ''' </author>
    ''' <summary>
    ''' Get option for auto logout
    ''' Option 1. Admin logout only
    ''' Option 2. Logout all user except operator
    ''' Option 3. Logout all all user
    ''' Default is option 1
    ''' </summary>
    Public Shared Function GetAutoLogoutOption() As Integer
        Dim iLogoutOption As Integer = 1

        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_LOGOUT_OPTION)
            If Not Integer.TryParse(root.InnerText, iLogoutOption) Then
                iLogoutOption = 1
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return iLogoutOption
    End Function

    ''' <author>
    '''    	<name> Do Nguyen Dy </name>
    '''    	<date> 2015-1-07</date>
    ''' </author>
    ''' <summary>
    ''' Set SystemIDLE_Time ( Auto LogOut TimeOut )
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetSystemIDLE_Time(ByVal waitTime As Int32) As Boolean
        Dim bRes As Boolean = False
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEMIDLE_TIME)
            root.InnerText = waitTime.ToString()
            BinarySerialize.SaveTo_DatFileConfig(FPath_SystemConfig, SystemConfigDoc)
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2017-10-05 </date>
    ''' </author>
    ''' <summary>
    ''' SetConfigFilament
    ''' </summary>
    Public Shared Function SetConfigFilament(ByVal name As String, ByVal numFilament As Int32) As Boolean
        Dim bRes As Boolean = False
        Try
            Dim path As String = String.Empty

            If name = LoadLockA_STR Then
                path = ConstEnum.XPATH_LLA_FILAMENT
            Else
                path = ConstEnum.XPATH_TM_FILAMENT
            End If

            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(path)
            root.InnerText = numFilament.ToString()
            BinarySerialize.SaveTo_DatFileConfig(FPath_SystemConfig, SystemConfigDoc)
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    Public Shared Function GetSystemCleanUpTime() As Double
        Dim dSystemIDLE As Double = 0
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEM_CLEANUP_TIME)
            If Double.TryParse(root.InnerText, dSystemIDLE) = False Then
                dSystemIDLE = 0
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return dSystemIDLE
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2018-11-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get System Clean Up DataRun Time
    ''' </summary>
    Public Shared Function GetSystemCleanUpDataRunTime() As Double
        Dim dSystemDataRun As Double = 0
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEM_CLEANUP_DATARUN_TIME)
            If Double.TryParse(root.InnerText, dSystemDataRun) = False Then
                dSystemDataRun = 365
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Math.Abs(dSystemDataRun)
    End Function

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2018-12-20 </date>
    ''' </author>
    ''' <summary>
    ''' Get Reset Robot Interlock Command
    ''' </summary>
    Public Shared Function GetResetRobotInterlockCommand() As Boolean
        Dim bResult As Boolean = False
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_RESET_ROBOT_INTERLOCK_COMMAND)
            If Boolean.TryParse(root.InnerText, bResult) = False Then
                bResult = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return bResult
    End Function
    ''' <author>
    '''    	<name> Tinh Le</name>
    '''    	<date> 2023-14-02 </date>
    ''' </author>
    ''' <summary>
    ''' Get One Main Cryo Controller Installed
    ''' </summary>
    Public Shared Function GetOneMainCryoControllerInstalled() As Boolean
        Dim bResult As Boolean = False
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ONE_MAIN_CRYO_CONTROLLER_INSTALLED)
            If Boolean.TryParse(root.InnerText, bResult) = False Then
                bResult = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return bResult
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-06-03</date>
    ''' </author>
    ''' <summary>
    ''' Get ToolID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRunDataFolderConfig() As String
        Dim strRunDataPath As String = String.Empty
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_RUN_DATA_FOLDER)
            If (root Is Nothing) OrElse (root.InnerText.EndsWith(".\DataFiles\DataRun")) Then
                Return String.Empty
            End If
            strRunDataPath = root.InnerText
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strRunDataPath
    End Function
    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-04-22</date>
    ''' </author>
    ''' <summary>
    ''' Get Folder System Config
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetFolderSystemConfig() As String
        Dim strRunDataPath As String = String.Empty
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEM_CONFIG_FOLDER)
            If (root IsNot Nothing) Then
                strRunDataPath = root.InnerText
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strRunDataPath
    End Function

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-06-16</date>
    ''' </author>
    ''' <summary>
    ''' GetAutoArchiveStatusValue
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetAutoArchiveStatusValue(ByVal strPath As String) As String
        Dim strRunDataPath As String = String.Empty
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(strPath)
            If (root IsNot Nothing) Then
                strRunDataPath = root.InnerText
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strRunDataPath
    End Function

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' Device net card name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeviceNetCardName() As String
        Dim strResult As String = String.Empty
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_DEVICENET_CARDNAME)
            If (root IsNot Nothing) Then
                strResult = root.InnerText
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' Device net card name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeviceNetBaudRate() As Int32
        Dim iResult As Int32 = 0 'as default
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_DEVICENET_BAUDRATE)
            If (root IsNot Nothing) Then
                Single.TryParse(root.InnerText, iResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return iResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' read systemconfig/public
    ''' ger enable/disable ANYIBE mode for CX5
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Enable_ANYIBE_Mode() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ENABLE_ANYIBE_MODE)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' read config process chime
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessChimeInstalled() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ENABLE_PROCESS_CHIME)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' read systemconfig/public
    ''' ger enable/disable ANYIBE mode for CX5
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DefaultOnlineControlState() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_DEFAULT_CONTROL_STATE)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
    ''' <author>
    '''    	<name> TRUC LE </name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' read systemconfig/public
    ''' ger enable/disable ANYIBE mode for CX5
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AllowPopUpTerminalMessage() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ALLOW_POPUP_TERMINALMESSAGE)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for Autovent when processing complete
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AutoVentWhenProcessingConpleted() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_AUTOVENT_WHENPROCESSINGCOMPLETED)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
        ''' <author>
        '''    	<name>Tinh Le</name>
        '''    	<date> 2022-09-12</date>
        ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for Delay time after process complete
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DelayTimeAfterProcessComplete() As String
        Dim strResult As String = String.Empty
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_DELAYTIME_AFTERPROCESSCOMPLETE)
            If (root IsNot Nothing) Then
                strResult = root.InnerText
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2021-11-11</date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' get value enble run no
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EnableRunNo() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ENABLE_RUN_NO)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
    ''' <author>
    '''    	<name> Tinh Le</name>
    '''    	<date> 2022-12-04</date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' get value TMTurboSetPoinFrequency
    ''' </summary>
    Public Shared Function TMTurboSetPoinFrequency() As Double
        Dim strResult As Double = 0
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_TM_TURBO_SP_FREQUENCY)
            If (root IsNot Nothing) Then
                Double.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
    ''' <author>
    '''    	<name> Tinh Le</name>
    '''    	<date> 2022-12-04</date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' get value LLATurboSetPoinFrequency
    ''' </summary>
    Public Shared Function LLATurboSetPoinFrequency() As Double
        Dim strResult As Double = 0
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_LLA_TURBO_SP_FREQUENCY)
            If (root IsNot Nothing) Then
                Double.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function

    ''' <author>
    '''    	<name> Duc Pham </name>
    '''    	<date> 2018-11-22</date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for read Enable Quick Sequence Editor value
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReadEnableQuickSequenceEditor() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ENABLE_QUICK_SEQUECE_EDITOR)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-11-17</date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for read Enable Quick Sequence Editor value
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReadShowReworkFiles() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SHOW_REWORK_FILES)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-04-22 </date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for Auto Archive System Config File Daily
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AutoArchiveSystemConfigFile() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_AUTO_ARCHIVE_SYSTEM_CONFIG_FILE)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function

    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2013-10-15</date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SupportRequestDataChanged() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_DATACHANGE)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function

    ''' <author>
    '''    	<name> Truc Lee </name>
    '''    	<date> 2013-10-15</date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SupportManualDefineGEMWaferID() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_MANUALDEFINE_GEMWAFERID)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-05-25 </date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AllowCheckingECCLimit() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ALLOW_CHECKING_ECC_LIMIT)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-05-25 </date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ECC_M_Limit() As Integer
        Dim iResult As Integer = 0
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ECC_M_LIMIT)
            If (root IsNot Nothing) Then
                Integer.TryParse(root.InnerText, iResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return iResult
    End Function

    ''' <author>
    '''    	<name>Hai Tran</name>
    '''    	<date>2017-02-08</date>
    ''' </author>
    ''' <summary>
    ''' Returns value config of CheckWaferSlideOut.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckWaferSlideOut() As Boolean
        Dim result As Boolean = True
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_CHECK_WAFER_SLIDE_OUT)
            If (root IsNot Nothing) Then
                result = Boolean.Parse(root.InnerText)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-06</date>
    ''' <summary>
    ''' Returns value config of EnableReworkFeature.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EnableReworkFeature() As Boolean
        Dim result As Boolean = False
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ENABLED_REWORK_FEATURE)
            If (root IsNot Nothing) Then
                result = Boolean.Parse(root.InnerText)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>Dung Pham</author>
    ''' <date>2021-10-05</date>
    ''' <summary>
    ''' Returns value config of EnableReworkFeature.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TotalGasFlowLimit() As Double
        Dim result As Double = 0

        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_TOTAL_GAS_FLOW_LIMIT)
            If (root IsNot Nothing) Then
                Double.TryParse(root.InnerText, result)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return result
    End Function

    ''' <author>
    '''    	<name> Truc Le </name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' Read Auto Export Data Log to CSV from Config file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AutoExportDataLogToCSV() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_AUTOEXPORT_DATALOG_TOCSV)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-07-20</date>
    ''' </author>
    ''' <summary>
    ''' Get Lot data log
    ''' </summary>
    ''' <returns> data log path config</returns>
    ''' <remarks></remarks>
    Public Shared Function GetLotDatalogFolderConfig() As String
        Dim strRunDataPath As String = String.Empty
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_LOTDATALOG_FOLDER)
            If (root Is Nothing) OrElse (root.InnerText.EndsWith(".\DataFiles\LotDatalog")) Then
                Return String.Empty
            End If
            strRunDataPath = root.InnerText
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strRunDataPath
    End Function
    ''' <author>
    '''    	<name>Ngo Cao Dinh</name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get elevator initializtion configuration
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInitConfig() As Hashtable
        Dim mapInits As New Hashtable()
        Try
            ' The XPath to the Initialize session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_INITIALIZATION)
            'mapInits = InitLib.GetConfig(root)
            mapInits = InitLib.GetConfigFromCode(root)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return mapInits
    End Function

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get message config
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessageConfig() As Hashtable
        Dim map As Hashtable = Nothing
        Try
            map = MessageEquipmentLib.GetMessageConfig(MessageEquipmentDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return map
    End Function
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' GetValueMessageConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetValueMessageConfig() As Hashtable
        Dim map As Hashtable = Nothing
        Try
            map = ValueMessageEquipmentLib.GetMessageConfig(ValueMessageEquipmentDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return map
    End Function
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' GetErrorMessageConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetErrorMessageConfig() As Hashtable
        Dim map As Hashtable = Nothing
        Try
            ' The XPath to the MessageError session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEMMESSAGEERROR)

            map = MessageErrorLib.GetMessageConfig(root)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return map
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' GetMessageConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetConfigurationServer() As Hashtable
        Dim map As Hashtable = Nothing
        Try
            map = ConfigurationLib.GetConfigurationServer(ConfigurationServerDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return map
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' GetKepServer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetKepServer() As ArrayList
        Dim ListGroup As New ArrayList()
        Try
            ' The XPath to the KepserverStatus session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_KEPSERVERTAGSDEF)

            ListGroup = KepServerLib.GetKepServer(root)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return ListGroup
    End Function

    Public Shared Function GetConfigurableKepServer(ByRef actions As Hashtable, ByRef statuses As Hashtable) As Boolean
        Try
            ' The XPath to the KepserverStatus session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_KEPSERVERTAGSSTATUS)
            Return KepServerLib.GetConfigurableKepServer(root, actions, statuses)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-05-17</date>
    ''' </author>
    ''' <summary>
    ''' Write the new kep server tag to  System config file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetKepServerTagDescription(ByVal Group As String, ByVal strKepServerName As String, ByVal Tag_Des As String, ByVal NeedSave As Boolean) As Boolean
        Try
            Const TM_TMC As String = "TM.TMC"
            If Group.StartsWith(TM_TMC) Then
                Group = TM_TMC
            End If
            ' The XPath to the KepserverStatus session
            Dim groupNode As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_KEPSERVERTAGSDEF & "/" & "Group[@Name='" & Group & "']")
            If (groupNode IsNot Nothing) Then
                Dim node As System.Xml.XmlNode = groupNode.SelectSingleNode("Item[@KepServerName = '" & strKepServerName & "']")
                If (node IsNot Nothing) Then
                    node.Attributes("Desc").Value = Tag_Des
                    If NeedSave Then
                        ' SystemConfigDoc.Save(ContainerDAO.FPath_SystemConfig)
                        BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
                    End If
                Else
                    AVPLib.Log.avpLogger.Error("The Tag " & strKepServerName & " Is Not Found.")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function
    ''Truc Le 
    ''This function build a dictionary for SystemConfig.xml
    ''if user delete some tags in this file -> AVP will restore them
    Public Shared Function GetDictionarySystemRestore() As Dictionary(Of String, Object)
        Dim myDicSystemRestore As New Dictionary(Of String, Object)
        Try
            myDicSystemRestore.Add(NUMBER_OF_SLOT, ConstEnum.LLELEVATORCONFIG_NumberOfSlot)
            myDicSystemRestore.Add(TRAVEL_LENGTH, ConstEnum.LLELEVATORCONFIG_TravelLength)
            myDicSystemRestore.Add(PITCH, ConstEnum.LLELEVATORCONFIG_Pitch)
            myDicSystemRestore.Add(BASE_OFFSET, ConstEnum.LLELEVATORCONFIG_BaseOffset)
            myDicSystemRestore.Add(FIND_BIAS, ConstEnum.LLELEVATORCONFIG_FindBias)
            '
            myDicSystemRestore.Add("SCFNS_Value", ConstEnum.LLELEVATORVC_SCFNS_Value)
            myDicSystemRestore.Add("SCFPT_Value", ConstEnum.LLELEVATORVC_SCFPT_Value)
            myDicSystemRestore.Add("SCFCT_Value", ConstEnum.LLELEVATORVC_SCFCT_Value)
            myDicSystemRestore.Add("SFB_Value", ConstEnum.LLELEVATORVC_SFB_Value)
            myDicSystemRestore.Add("SCFLM_Value", ConstEnum.LLELEVATORVC_SCFLM_Value)

            myDicSystemRestore.Add("LLVENTCONFIG_LLMesaValveOpenCloseTimeOut", ConstEnum.LLVENTCONFIG_LLMesaValveOpenCloseTimeOut)
            myDicSystemRestore.Add("LLVENTCONFIG_IGOnOffTimeOut", ConstEnum.LLVENTCONFIG_IGOnOffTimeOut)
            myDicSystemRestore.Add("LLVENTCONFIG_LLHivacOpenCloseTimeOut", ConstEnum.LLVENTCONFIG_LLHivacOpenCloseTimeOut)
            myDicSystemRestore.Add("LLVENTCONFIG_LLASlowVentTimeOut", ConstEnum.LLVENTCONFIG_LLASlowVentTimeOut)
            myDicSystemRestore.Add("LLVENTCONFIG_LLASlowVentPressure", ConstEnum.LLVENTCONFIG_LLASlowVentPressure)
            myDicSystemRestore.Add("LLVENTCONFIG_LLAFastVentTimeOut", ConstEnum.LLVENTCONFIG_LLAFastVentTimeOut)
            myDicSystemRestore.Add("LLVENTCONFIG_LLAVentPressure", ConstEnum.LLVENTCONFIG_LLAVentPressure)
            myDicSystemRestore.Add("LLVENTCONFIG_LLVentValveOpenCloseTimeOut", ConstEnum.LLVENTCONFIG_LLVentValveOpenCloseTimeOut)
            myDicSystemRestore.Add("LLVENTCONFIG_LLVent_Delay_Time", ConstEnum.LLVENTCONFIG_LLVent_Delay_Time)

            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_LLMesaValveOpenCloseTimeOut", ConstEnum.LLPUMPDOWNCONFIG_LLMesaValveOpenCloseTimeOut)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_IGOnOffTimeOut", ConstEnum.LLPUMPDOWNCONFIG_IGOnOffTimeOut)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_LLHivacOpenCloseTimeOut", ConstEnum.LLPUMPDOWNCONFIG_LLHivacOpenCloseTimeOut)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_TMMechanicalPumpOnPressure", ConstEnum.LLPUMPDOWNCONFIG_TMMechanicalPumpOnPressure)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_LLASlowRoughPressure", ConstEnum.LLPUMPDOWNCONFIG_LLASlowRoughPressure)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_LLASlowRoughPressureTimeOut", ConstEnum.LLPUMPDOWNCONFIG_LLASlowRoughPressureTimeOut)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_LLAFastRoughPressure", ConstEnum.LLPUMPDOWNCONFIG_LLAFastRoughPressure)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_LLAFastRoughPressureTimeOut", ConstEnum.LLPUMPDOWNCONFIG_LLAFastRoughPressureTimeOut)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_LLACryoColdTemp", ConstEnum.LLPUMPDOWNCONFIG_LLACryoColdTemp)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_IGOnDelay", ConstEnum.LLPUMPDOWNCONFIG_IGOnDelay)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_LLRoughValveOpenCloseTimeOut", ConstEnum.LLPUMPDOWNCONFIG_LLRoughValveOpenCloseTimeOut)
            myDicSystemRestore.Add("LLPUMPDOWNCONFIG_LLPumpDown_Delay_Time", ConstEnum.LLPUMPDOWNCONFIG_LLPumpDown_Delay_Time)

            myDicSystemRestore.Add("TMVENTCONFIG_TMMesaValvesOpenCloseTimeOut", ConstEnum.TMVENTCONFIG_TMMesaValvesOpenCloseTimeOut)
            myDicSystemRestore.Add("TMVENTCONFIG_IGOnOffWaitTime", ConstEnum.TMVENTCONFIG_IGOnOffWaitTime)
            myDicSystemRestore.Add("TMVENTCONFIG_TMHivacOpenCloseTimeOut", ConstEnum.TMVENTCONFIG_TMHivacOpenCloseTimeOut)
            myDicSystemRestore.Add("TMVENTCONFIG_TMVentPressure", ConstEnum.TMVENTCONFIG_TMVentPressure)
            myDicSystemRestore.Add("TMVENTCONFIG_TMVentTimeOut", ConstEnum.TMVENTCONFIG_TMVentTimeOut)
            myDicSystemRestore.Add("TMVENTCONFIG_TMVentValveOpenCloseTimeOut", ConstEnum.TMVENTCONFIG_TMVentValveOpenCloseTimeOut)
            myDicSystemRestore.Add("TMVENTCONFIG_TMVent_Delay_Time", ConstEnum.TMVENTCONFIG_TMVent_Delay_Time)

            myDicSystemRestore.Add("TMPUMPDOWNCONFIG_TMMesaValvesOpenCloseTimeOut", ConstEnum.TMPUMPDOWNCONFIG_TMMesaValvesOpenCloseTimeOut)
            myDicSystemRestore.Add("TMPUMPDOWNCONFIG_IGOnOffTimeOut", ConstEnum.TMPUMPDOWNCONFIG_IGOnOffTimeOut)
            myDicSystemRestore.Add("TMPUMPDOWNCONFIG_TMHivacOpenCloseTimeOut", ConstEnum.TMPUMPDOWNCONFIG_TMHivacOpenCloseTimeOut)
            myDicSystemRestore.Add("TMPUMPDOWNCONFIG_TMMechanicalPumpOnPressure", ConstEnum.TMPUMPDOWNCONFIG_TMMechanicalPumpOnPressure)
            myDicSystemRestore.Add("TMPUMPDOWNCONFIG_TMRoughPressure", ConstEnum.TMPUMPDOWNCONFIG_TMRoughPressure)
            myDicSystemRestore.Add("TMPUMPDOWNCONFIG_TMRoughTimeOut", ConstEnum.TMPUMPDOWNCONFIG_TMRoughTimeOut)
            myDicSystemRestore.Add("TMPUMPDOWNCONFIG_TMCryoColdTemp", ConstEnum.TMPUMPDOWNCONFIG_TMCryoColdTemp)
            myDicSystemRestore.Add("TMPUMPDOWNCONFIG_IGOnDelay", ConstEnum.TMPUMPDOWNCONFIG_IGOnDelay)
            myDicSystemRestore.Add("TMPUMPDOWNCONFIG_TMPumdown_Delay_Time", ConstEnum.TMPUMPDOWNCONFIG_TMPumdown_Delay_Time)

            myDicSystemRestore.Add("CassettesModuleTransferSetPoint", ConstEnum.TRANSFERSETPOINT_CassettesModuleTransferSetPoint)
            myDicSystemRestore.Add("LoadLockATransferSetPoint", ConstEnum.TRANSFERSETPOINT_LoadLockATransferSetPoint)
            myDicSystemRestore.Add("ChamberTransferSetPoint", ConstEnum.TRANSFERSETPOINT_ChamberTransferSetPoint)
            myDicSystemRestore.Add("PressureDifferentialPercent", ConstEnum.TRANSFERSETPOINT_PressureDifferentialPercent)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return myDicSystemRestore
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-03</date>
    ''' </author>
    ''' <summary>
    ''' GetKepServer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub GetIBEMaintenance(ByRef nameMap As Hashtable, ByRef codeMap As Hashtable)
        Try ''use this function for pvd
            nameMap.Clear()
            codeMap.Clear()
            AddDBCommandItem(nameMap, codeMap, "REQUEST_ALL_DATA", "1,01,01,52,01,01", "", "")

            AddDBCommandItem(nameMap, codeMap, "CHECK_RECIPE_TEMPLATE_VERSION", "1,01,01,53,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "COPYRECIPE_TEMPLATE", "1,01,01,54,01,01", "StartCopyRecipeTemplate", "")
            AddDBCommandItem(nameMap, codeMap, "COPYRECIPE_TO_PMFOLDER", "1,01,01,51,01,01", "StartCopyRecipeToPMFolder", "")
            AddDBCommandItem(nameMap, codeMap, "MAINTENAINCE_MODE", "1,01,01,50,01,01", "MaintenanceMode", "")
            AddDBCommandItem(nameMap, codeMap, "ROUGH_PUMP_POWER", "1,02,01,01,01,01", "RoughPumpStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "TURBO_PUMP_GATE_VALVE", "1,02,01,02,01,03", "HiVacValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "TURBO_PUMP_POWER", "1,02,01,02,01,01", "TurboPowerStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "CRYO_POWER", "1,02,01,04,01,01", "CryoPumpStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "ROUGH_VALVE", "1,02,01,05,01,01", "RoughValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "VENT_VALVE", "1,02,01,06,01,01", "VentValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.IGISOLATION_VALVE.ToString(), "1,06,01,01,01,01", "IGIsolationValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.GASDIVERTER_VALVE.ToString(), "1,06,01,02,01,01", "DiverterValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FORELINE_VALVE", "1,02,01,07,01,01", "ForelineValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "AUTO_PUMP_DOWN", "1,02,01,13,01,01", "PumpDownStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "AUTO_VENT", "1,02,01,14,01,01", "VentStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "ISOLATION_VALVE", "1,02,01,15,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "PUMP_PURGE", "1,05,01,10,01,01", "PumpPurgeStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "MachinePumpPurge_Current_Cycle", "1,05,01,10,01,02", "MachinePumpPurge_Current_Cycle", "String")
            AddDBCommandItem(nameMap, codeMap, "ION_GAUGE_DEGAS", "1,02,01,08,01,03", "IGDegasStatus", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, "SPLITVALVE_STATUS", "1,12,25,01,01,0x", "SlitValveStatus", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, "RATE_OF_RISE_STATUS", "1,02,01,20,01,01", "RateOfRise_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "RATE_OF_RISE_SAMPLE", "1,02,04,20,01,01", "RateOfRise_Sample", "")
            AddDBCommandItem(nameMap, codeMap, "RATE_OF_RISE_FILENAME", "1,02,03,20,01,01", "RateOfRise_FileName", "")
            AddDBCommandItem(nameMap, codeMap, "RATE_OF_RISE_INTERVAL_RECORDING", "1,02,02,20,01,01", "RateOfRise_Interval", "")

            AddDBCommandItem(nameMap, codeMap, "PUMPDOWN_CURVE_STATUS", "1,02,01,21,01,01", "PumpDown_Curve_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "PUMPDOWN_CURVE_SAMPLE", "1,02,04,21,01,01", "PumpDown_Curve_Sample", "")
            AddDBCommandItem(nameMap, codeMap, "PUMPDOWN_CURVE_FILENAME", "1,02,03,21,01,01", "PumpDown_Curve_FileName", "")
            AddDBCommandItem(nameMap, codeMap, "PUMPDOWN_CURVE_INTERVAL_RECORDING", "1,02,02,21,01,01", "PumpDown_Curve_Interval", "")
            ' <!--Cryo-->
            AddDBCommandItem(nameMap, codeMap, "CRYO_PUMP_TEMPERTURE_T1", "1,02,01,04,01,10", "Cryo_Pump_Temperture_T1", "Double")
            AddDBCommandItem(nameMap, codeMap, "CRYO_PUMP_TEMPERTURE_T2", "1,02,01,04,01,02", "Cryo_Pump_Temperture_T2", "Double")
            AddDBCommandItem(nameMap, codeMap, "CRYO_PUMP_GATE_VALVE", "1,02,01,04,01,03", "ValveCryoPumpGateStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "CRYO_REGEN_VALVE", "1,02,01,04,01,04", "CryoPumpRegenStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "CRYO_PURGE_VALVE", "1,02,01,04,01,05", "CryoPumpPurgeStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "CRYO_AUTO_REGEN", "1,02,01,04,01,06", "CryoAutoRegenStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "CRYO_AUTO_REGEN_STATUS_TEXT", "1,02,01,04,01,08", "CryoAutoRegenStatusText", "String")
            AddDBCommandItem(nameMap, codeMap, "CRYO_AUTO_POWER_DOWN", "1,02,01,04,01,07", "CryoAutoPowerDownStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "CRYO_P_COMMANDS", "1,02,01,04,01,09", "Cryo_P_Command", "String")
            AddDBCommandItem(nameMap, codeMap, "CRYO_COMMUNICATE", "1,02,01,04,01,11", "CryoCommmunicateStateReadBackStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "CRYO_REGEN_HOUR_READBACK", "1,02,01,04,01,12", "CryoLastFullRegenReadBack", "Double")
            AddDBCommandItem(nameMap, codeMap, "CRYO_LIFETIME_HOUR_READBACK", "1,02,01,04,01,13", "CryoElapsedTimeReadBack", "Double")
            AddDBCommandItem(nameMap, codeMap, "RAMPING_PERCENT_TURBO", "1,02,01,02,01,02", "RampingPercentTurbo", "String")

            ' <!--Status Panel-->
            AddDBCommandItem(nameMap, codeMap, "INITIALIZE_MOTION", "1,03,01,14,01,01", "Initialize_Motion_readback", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "INITIALIZING_MOTION", "1,03,01,13,01,01", "Initializing_Motion_readback", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "GAS_OK", "1,05,01,24,01,01", "Process_Gas_Readback", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "BEAM_OK", "1,05,01,25,01,01", "Ion_Beam_Readback", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "PBN_OK", "1,05,01,26,01,01", "PBN_OK_Readback", "WorkingStatuses")
            '<!--Fixture Panel-->
            '<!-- Flowcool He Gas, Valve-->
            AddDBCommandItem(nameMap, codeMap, "FLOWCOOL_GAS_ON_STATUS", "1,05,01,09,01,11", "FlowCoolGasOnStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FLOWCOOL_MFC_SHUTOFF_VALVE", "1,03,01,10,01,01", "FlowCoolHeValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FLOWCOOL_MFC_SUPPLY_VALVE", "1,03,01,10,01,02", "ValveSupplyFlowCoolHeStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FLOWCOOL_MFC_TARGET_FLOWRATE", "1,03,01,10,01,03", "GasController_FlowCoolHe_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "FLOWCOOL_MFC_ACTUAL_FLOWRATE", "1,03,01,10,01,04", "GasController_FlowCoolHe_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_ROTATION_MODE", "1,03,01,08,01,05", "Fixture_Rotation_Mode_Readback", "String")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_TILT_ANGLE", "1,03,01,09,01,01", "Fixture_TiltAngle_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "TILT_AT_ANGLE_SENSOR", "1,03,01,09,01,12", "TiltAtAngleSensor", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, "FIXTURE_STATIC_ROTATION_ANGLE_READBACK", "1,03,01,08,01,09", "StaticFixture_Rotation_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_STATIC_ROTATION_ANGLE", "1,03,01,08,01,01", "StaticFixture_Rotation_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_ROTATION_START_ANGLE_READBACK", "1,03,01,08,02,06", "SweepFixture_Rotation_Start_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_ROTATION_START_ANGLE", "1,03,01,08,01,06", "SweepFixture_Rotation_Start_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_ROTATION_END_ANGLE", "1,03,01,08,01,07", "SweepFixture_Rotation_End_Program", "Double")

            AddDBCommandItem(nameMap, codeMap, "FIXTURE_SWEEP_TILT_ANGLE", "1,03,01,09,01,15", "", "")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_SWEEP_TILT_START_ANGLE", "1,03,01,09,01,16", "Fixture_TiltStartAngle_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_SWEEP_TILT_END_ANGEL", "1,03,01,09,01,17", "Fixture_TiltEndAngle_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_SWEEP_TILT_MODE", "1,03,01,09,01,18", "Fixture_Tilt_Mode", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_TILT_SWEEPING", "1,03,01,09,01,19", "Fixture_Tilt_Sweeping", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, "FIXTURE_CONTINUOUS_ROTATION_RPM", "1,03,01,08,01,08", "ContinuousFixture_Rotation_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_CONTINUOUS_ROTATION_RPM_READBACK", "1,03,01,08,01,10", "ContinuousFixture_Rotation_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_TILT_HOME", "1,03,01,09,01,02", "FixtureTiltHomeStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_ROTATION_MOVING", "1,03,01,08,01,03", "FixtureRotationMovingStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_ROTATION_HOME", "1,03,01,08,01,02", "FixtureRotationHomeStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_TILT_MOVING", "1,03,01,09,01,03", "FixtureTiltMovingStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_TILT_ERROR", "1,03,01,09,01,04", "FixtureErrorStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_ROTATION_ENCODER_ERROR", "1,03,01,08,01,14", "FixtureEncoderErrorStatus", "String")

            AddDBCommandItem(nameMap, codeMap, "WAFER_IN_FIXTURE", "1,03,01,12,01,01", "Wafer_InFixture_Readback", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, "FIXTURE_HOME_ROTATION_AXIS", "1,03,01,08,02,05", "Fixture_Home_Rotation_Program", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_UNPROTECTED", "1,01,01,05,01,01", "Fixture_Unprotected_Readback", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_WATER_VALVE", "1,03,01,02,01,01", "FixtureWaterValveStatus", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, "SHUTTER_DIRECTION", "1,03,01,27,01,01", "ShutterDirection", "String")

            AddDBCommandItem(nameMap, codeMap, "SHUTTER_POSITION", "1,05,01,01,01,01", "ShutterPositionStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "INTERNAL_SHUTTER_STATUS", "1,05,01,32,01,02", "InternalShutterStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "INTERNAL_SHUTTER_OFF_STATUS", "1,05,01,33,01,02", "InternalShutterOffStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_FLOWCOOL_PUMP_POWER", "1,03,01,01,01,01", "FixtureFlowCoolPumpStatus", "WorkingStatuses")
            '<!--End Fixture Control-->
            ' <!--Pop Up Panel-->
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CONTROL_GET_RUN_DATA_FILE_NAME", "1,05,01,22,01,18", "ProcessControl_GetRunDataFileName", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "CURRENT_AVP_TIME", "1,05,01,22,01,19", "Current_AVP_Time", "String")
            '<!--Power Panel-->
            AddDBCommandItem(nameMap, codeMap, "SOURCE_AC_POWER", "1,05,01,02,01,01", "ACPower_readback", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "SOURCE_RF_POWER", "1,05,01,03,01,01", "RFPower_readback", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "SOURCE_GRID_POWER", "1,05,01,04,01,01", "GridPower_readback", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "SOURCE_PBN_POWER", "1,05,01,05,01,01", "PBNPower_readback", "WorkingStatuses")

            ' <!-- BeamPowerSupply-->
            AddDBCommandItem(nameMap, codeMap, "AUTO_BEAM", "1,05,01,16,01,01", "BeamPowerSupply_AutoBeam", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "BEAM_VOLTAGE_PROGRAM", "1,05,01,12,01,01", "BeamPowerSupply_Voltage_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "BEAM_VOLTAGE_READBACK", "1,05,01,12,01,02", "BeamPowerSupply_Voltage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "BEAM_CURRENT_PROGRAM", "1,05,01,13,01,01", "BeamPowerSupply_Current_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "BEAM_CURRENT_READBACK", "1,05,01,13,01,02", "BeamPowerSupply_Current_Readback", "Double")
            '<!-- SuppressorPowerSupply-->
            AddDBCommandItem(nameMap, codeMap, "SUPP_VOLTAGE_PROGRAM", "1,05,01,14,01,01", "SuppressorPowerSupply_Voltage_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "SUPP_VOLTAGE_READBACK", "1,05,01,14,01,02", "SuppressorPowerSupply_Voltage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "SUPP_CURRENT_READBACK", "1,05,01,15,01,02", "SuppressorPowerSupply_Current_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "SUPP_CURRENT_PROGRAM", "1,05,01,15,01,01", "SuppressorPowerSupply_Current_Program", "Double")
            '  <!-- Body- Discharge PowerSupply-->
            AddDBCommandItem(nameMap, codeMap, "PBN_BODY_CURRENT_READBACK", "1,05,01,17,01,02", "BodyPowerSupply_Current_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "PBN_BODY_VOLTAGE_READBACK", "1,05,01,17,01,03", "BodyPowerSupply_Voltage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "PBN_DISCHARGE_VOLTAGE_READBACK", "1,05,01,17,01,04", "DischargePowerSupply_Voltage_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "PBN_BODY_CURRENT_ERROR_TOL", "1,05,01,17,01,07", "", "")
            AddDBCommandItem(nameMap, codeMap, "PBN_BODY_CURRENT_WARNING_TOL", "1,05,01,17,01,08", "", "")
            AddDBCommandItem(nameMap, codeMap, "PBN_BODY_CURRENT_ERROR_TIME", "1,05,01,17,01,09", "", "")
            AddDBCommandItem(nameMap, codeMap, "PBN_BODY_CURRENT_WARNING_TIME", "1,05,01,17,01,10", "", "")
            AddDBCommandItem(nameMap, codeMap, "K_FACTOR_PROGRAM", "1,05,01,19,01,01", "BodyPowerSupply_KFactor_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "K_FACTOR_READBACK", "1,05,01,19,01,02", "BodyPowerSupply_KFactor_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "PBN_FILAMENT_CURRENT_READBACK", "1,05,01,18,01,02", "DischargePowerSupply_Current_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "ANC_PROBE_VOLTAGE_READBACK", "1,05,01,32,01,01", "ANC_Probe_Voltage_Readback", "Double")
            ' 	<!--new in sl-->
            AddDBCommandItem(nameMap, codeMap, "SOURCE_MANUAL_AUTO_POWER", "1,05,01,06,01,01", "SourceManual_Auto_readback", "WorkingStatuses")
            '  <!-- RFPowerSupply-->
            AddDBCommandItem(nameMap, codeMap, "INCIDENT_RF_PROGRAM", "1,05,01,20,01,01", "RFPowerSupply_ForwardPower_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "FORWARD_RF_READBACK", "1,05,01,20,01,02", "RFPowerSupply_ForwardPower_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "REFLECTED_RF_PROGRAM", "1,05,01,21,01,01", "RFPowerSupply_ReflectedPower_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "REFLECTED_RF_READBACK", "1,05,01,21,01,02", "RFPowerSupply_ReflectedPower", "Double")
            ' <!-- Process Status-->
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CONTROL_NAME", "1,05,01,22,01,02", "Recipe", "String")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_ELAPSED_TIME", "1,05,01,22,01,05", "ElapsedTime", "String")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CURRENT_STEP", "1,05,01,22,01,03", "ProcessMonitor_ProcessStep", "String")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_TOTAL_STEPS", "1,05,01,22,01,04", "ProcessMonitor_TotalStep", "String")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_REMAINING_TIME", "1,05,01,22,01,06", "RemainingTime", "String")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_WAFER_ID", "1,05,01,22,01,10", "WaferID", "String")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_EPDRecipe", "1,05,01,22,01,12", "EPDRecipe", "String")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_PROCESS_TIME", "1,05,01,22,01,20", "ProcessMonitor_ProcessTime", "String")
            AddDBCommandItem(nameMap, codeMap, "SOURCE_USAGE_RESET", "1,05,01,33,01,03", "ResetSourceUsage", "String")
            AddDBCommandItem(nameMap, codeMap, "SOURCE_USAGE_TIMESET", "1,05,01,33,01,01", "SourceUsageTimeCurrent", "Double")
            AddDBCommandItem(nameMap, codeMap, "QUART_KWH", "1,05,01,33,01,05", "Shields_Quart_KWH", "Double")
            ' <!--SOURCE USAGE Warning Limit-->
            AddDBCommandItem(nameMap, codeMap, "SOURCE_USAGE_WARNING", "1,05,01,33,01,07", "", "")
            ' <!--SOURCE USAGE Alarm Limit-->
            AddDBCommandItem(nameMap, codeMap, "SOURCE_USAGE_LIMIT", "1,05,01,33,01,06", "", "")
            ' <!--MAX_SOURCE_USAGE Alarm Limit-->
            AddDBCommandItem(nameMap, codeMap, "MAX_SOURCE_USAGE", "1,05,01,33,01,08", "", "")
            ' <!--SET PBN MINUTES-->
            AddDBCommandItem(nameMap, codeMap, "PBN_TIMESET", "1,05,01,33,01,19", "PBNTimeCurrent", "Double")

            '   <!--Pressure-->
            AddDBCommandItem(nameMap, codeMap, "ION_GAUGE_PRESSURE", "1,02,01,08,01,01", "IG", "Double")

            '  <!--Process Recipe -->  
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CONTROL_DEVICE_ERROR", "1,05,01,22,01,01,-1", "ProcessMonitor_DeviceError_Readback", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CONTROL_DEVICE_STOP", "1,05,01,22,01,01,00", "ProcessMonitor_DeviceStop_Readback", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CONTROL_DEVICE_START", "1,05,01,22,01,01,01", "ProcessMonitor_DeviceStart_Readback", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CONTROL_DEVICE_PAUSE", "1,05,01,22,01,01,02", "ProcessMonitor_DevicePause_Readback", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CONTROL_DEVICE_CONTINUE", "1,05,01,22,01,01,03", "ProcessMonitor_DeviceContinue_Readback", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CONTROL_DEVICE_RESET_ERROR", "1,05,01,22,01,01,04", "", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CONTROL_DEVICE_END_STEP", "1,05,01,22,01,01,05", "", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CONTROL_SEND_RUN_DATA_FILE_NAME", "1,05,01,22,01,17", "", "")
            ' <!--Chamber Interlock-->
            AddDBCommandItem(nameMap, codeMap, "VACUUM_PRESSURE_INTK", "1,02,01,11,01,01", "ChamberInterlocks_ChamberPress_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "SOURCE_WATER_INTERLOCK", "1,05,01,23,01,01", "ChamberInterlocks_SourceWater_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_WATER_INTERLOCK", "1,03,01,02,01,02", "ChamberInterlocks_FixtureWater_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_WATER_BUG_INTERLOCK", "1,03,01,24,01,02", "ChamberInterlocks_FixtureWaterBug_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "PANEL_INTERLOCK", "1,01,01,09,01,01", "ChamberInterlocks_PanelInterlock_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FORELINE_PRESSURE_INTK", "1,02,01,12,01,01", "ChamberInterlocks_Foreline_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "TURBO_WATER_INTERLOCK", "1,02,01,02,01,04", "ChamberInterlocks_TurboWater_Status", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "AIR_PRESSURE_INTK", "1,02,01,10,01,01", "ChamberInterlocks_AirPressure_Status", "WorkingStatuses")

            '<!--Convectron Gauge -->
            AddDBCommandItem(nameMap, codeMap, "PIRANI_CHAMBER_ROUGH_PRESSURE", "1,02,01,09,01,01", "CG", "Double")
            AddDBCommandItem(nameMap, codeMap, "MPCG_RELAY_INDICATOR", "1,02,01,09,03,02", "MPCG_RelayIndicatorStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "MP_COMMUNICATING", "1,02,01,09,01,02", "MP_Communicating", "WorkingStatuses")
            '<!--Foreline CG -->
            AddDBCommandItem(nameMap, codeMap, "PIRANI_FORELINE_PRESSURE", "1,02,01,07,02,01", "CGCFLCG_Information", "Double")
            AddDBCommandItem(nameMap, codeMap, "TURBO_FORELINE_COMMUNICATING", "1,02,01,07,02,02", "TurboForeline_Communicating", "WorkingStatuses")
            '<!--Rough Pump CG -->
            AddDBCommandItem(nameMap, codeMap, "PIRANI_ROUGH_PUMP_PRESSURE", "1,02,01,09,03,01", "CGCRLCG_Information", "Double")
            AddDBCommandItem(nameMap, codeMap, "FLOWCOOL_PRESSURE", "1,03,01,11,03,01", "CGCMG_Information", "Double")
            AddDBCommandItem(nameMap, codeMap, "MANOMETER_COMMUNICATING", "1,03,01,11,03,02", "CGCMG_Communicating", "WorkingStatuses")

            ' <!--Wafer Processing Status -->
            AddDBCommandItem(nameMap, codeMap, "WAFER_PROCESSING_STATUS_READBACK", "1,03,01,21,01,01", "WaferStatus", "Integer")
            AddDBCommandItem(nameMap, codeMap, "EVENT_STATUS_READBACK", "1,01,01,07,01,01", "EventMessage", "")
            AddDBCommandItem(nameMap, codeMap, "ALARM_STATUS_READBACK", "1,01,01,08,01,01", "StatusMessage", "")

            ' <!-- Gas Valve -->
            '<!--PBN Gas-->  
            AddDBCommandItem(nameMap, codeMap, "PBN_GAS_SHUTOFF_VALVE", "1,05,01,09,01,01", "PBNValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "PBN_GAS_SUPPLY_VALVE", "1,05,01,09,01,02", "ValveSupplyPBNStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "PBN_GAS_FLOWRATE_READBACK", "1,05,01,09,01,04", "GasController_PBN_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "PBN_GAS_FLOWRATE_PROGRAM", "1,05,01,09,01,03", "GasController_PBN_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "AUTOBEAM_PBN_GAS_FLOWRATE_PROGRAM", "1,05,01,08,06,20", "GasController_AutoBeam_PBN_Program", "Double")

            AddDBCommandItem(nameMap, codeMap, "GAS1_SHUTOFF_VALVE", "1,05,01,08,01,01", "Gas1ShutOffValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "GAS2_SHUTOFF_VALVE", "1,05,01,08,02,01", "Gas2ShutOffValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "GAS3_SHUTOFF_VALVE", "1,05,01,08,03,01", "Gas3ShutOffValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "GAS4_SHUTOFF_VALVE", "1,05,01,08,04,01", "Gas4ShutOffValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "GAS5_SHUTOFF_VALVE", "1,05,01,08,05,01", "Gas5ShutOffValveStatus", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, "GAS1_SUPPLY_VALVE", "1,05,01,08,01,02", "Gas1SupplyValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "GAS2_SUPPLY_VALVE", "1,05,01,08,02,02", "Gas2SupplyValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "GAS3_SUPPLY_VALVE", "1,05,01,08,03,02", "Gas3SupplyValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "GAS4_SUPPLY_VALVE", "1,05,01,08,04,02", "Gas4SupplyValveStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "GAS5_SUPPLY_VALVE", "1,05,01,08,05,02", "Gas5SupplyValveStatus", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, "GAS1_FLOWRATE_PROGRAM", "1,05,01,08,01,03", "GasController_Gas1_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS2_FLOWRATE_PROGRAM", "1,05,01,08,02,03", "GasController_Gas2_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "AUTOBEAM_GAS1_FLOWRATE_PROGRAM", "1,05,01,08,01,20", "GasController_AutoBeam_Gas1_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "AUTOBEAM_GAS2_FLOWRATE_PROGRAM", "1,05,01,08,02,20", "GasController_AutoBeam_Gas2_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "AUTOBEAM_GAS3_FLOWRATE_PROGRAM", "1,05,01,08,03,20", "GasController_AutoBeam_Gas3_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "AUTOBEAM_GAS4_FLOWRATE_PROGRAM", "1,05,01,08,04,20", "GasController_AutoBeam_Gas4_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS3_FLOWRATE_PROGRAM", "1,05,01,08,03,03", "GasController_Gas3_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS4_FLOWRATE_PROGRAM", "1,05,01,08,04,03", "GasController_Gas4_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS5_FLOWRATE_PROGRAM", "1,05,01,08,05,03", "GasController_Gas5_Program", "Double")

            AddDBCommandItem(nameMap, codeMap, "GAS1_FLOWRATE_READBACK", "1,05,01,08,01,04", "GasController_Gas1_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS2_FLOWRATE_READBACK", "1,05,01,08,02,04", "GasController_Gas2_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS3_FLOWRATE_READBACK", "1,05,01,08,03,04", "GasController_Gas3_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS4_FLOWRATE_READBACK", "1,05,01,08,04,04", "GasController_Gas4_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS5_FLOWRATE_READBACK", "1,05,01,08,05,04", "GasController_Gas5_Readback", "Double")

            ' <!--Shield Usage--> 
            AddDBCommandItem(nameMap, codeMap, "COVER_FIXTURE_SHIELD_USAGE", "1,05,01,33,01,11", "CoverFixtureShieldUsageReadback", "Double")
            AddDBCommandItem(nameMap, codeMap, "TOP_FIXTURE_SHIELD_USAGE", "1,05,01,33,01,12", "TopFixtureShieldUsageReadback", "Double")
            AddDBCommandItem(nameMap, codeMap, "WAFER_CLAMP_USAGE", "1,05,01,33,01,13", "WaferClampUsageReadback", "Double")
            AddDBCommandItem(nameMap, codeMap, "SHUTTER_USAGE", "1,05,01,33,01,14", "ShutterUsageReadback", "Double")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_ROTATION_MOTOR_USAGE", "1,05,01,33,01,15", "FixtureRotationMotorUsageReadback", "Double")
            AddDBCommandItem(nameMap, codeMap, "LINER_SOURCE_USAGE_READBACK", "1,05,01,33,01,16", "LinerSourceUsageReadback", "Double")
            AddDBCommandItem(nameMap, codeMap, "CRYO_USAGE_READBACK", "1,05,01,33,01,17", "CryoUsageReadback", "Double")
            AddDBCommandItem(nameMap, codeMap, "WATER_JOURNAL", "1,05,01,33,01,18", "WaterJournalReadback", "Double")

            '<!--End Process Module-->
            '<!--Will be remove later-->
            '<!--Command CommandName="WATER_PUMP_REGEN" ,"1,0x,0x,0x,0x,67" ,"WaterPumpRegen","WorkingStatuses")
            ' AddDBCommandItem(nameMap, codeMap,"WATER_PUMP" ,"1,0x,0x,0x,0x,66" ,"WaterPump","WorkingStatuses"/-->
            '<!--Command CommandName="CRYO_PUMP_TEMPERTURE" ,"1,02,01,04,01,02" ,"Cryo_Pump_Temperture","Double"/-->
            ' <!--Command CommandName="FIXTURE_TILT_ANGLE_READBACK" ,"1,03,01,09,01,05" ,"Fixture_TiltAngle_Readback","Double"/-->
            '<!--Command CommandName="FIXTURE_COOLING_WATER" ,"1,0x,0x,0x,01,65" ,"Fixture_Cooling_Water_Readback","Double"/-->
            ' <!--Command CommandName="FIXTURE_START_ROTATION_AXIS" ,"1,03,01,08,01,05" ,"Fixture_Start_Rotation_Readback","WorkingStatuses"/-->
            AddDBCommandItem(nameMap, codeMap, "MOTION_TO_SERVICE_POSITION", "1,03,01,23,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "MAGNETIC_CHUCK_POWER", "1,03,01,15,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "MAGNETIC_CHUCK_PHASE", "1,03,01,15,01,02", "", "")
            AddDBCommandItem(nameMap, codeMap, "MAGNETIC_CHUCK_AMPLITUDE", "1,03,01,15,01,03", "", "")
            AddDBCommandItem(nameMap, codeMap, "MAGNETIC_CHUCK_FREQUENCY", "1,03,01,15,01,04", "", "")
            AddDBCommandItem(nameMap, codeMap, "MAGNETIC_CHUCK_WAVE_TYPE", "1,03,01,15,01,05", "", "")
            AddDBCommandItem(nameMap, codeMap, "HOT_CHUCK_POWER", "1,03,01,17,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "HOT_CHUCK_GET_TEMPERATURE", "1,03,01,17,01,02", "", "")
            AddDBCommandItem(nameMap, codeMap, "HOT_CHUCK_SET_TEMPERATURE", "1,03,01,17,01,04", "", "")
            AddDBCommandItem(nameMap, codeMap, "STATIC_COOLING_EXHAUST_VALVE", "1,03,01,25,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "STATIC_COOLING_SUPPLY_VALVE", "1,03,01,25,01,02", "", "")
            AddDBCommandItem(nameMap, codeMap, "STATIC_COOLING_TARGET_FLOW", "1,03,01,25,01,03", "", "")
            AddDBCommandItem(nameMap, codeMap, "STATIC_COOLING_ACTUAL_FLOW", "1,03,01,25,01,04", "", "")
            AddDBCommandItem(nameMap, codeMap, "STATIC_COOLING_TARGET_PRESSURE", "1,03,01,25,01,05", "", "")
            AddDBCommandItem(nameMap, codeMap, "STATIC_COOLING_ACTUAL_PRESSURE", "1,03,01,25,01,06", "", "")
            AddDBCommandItem(nameMap, codeMap, "STATIC_COOLING_GAS_OK", "1,03,01,25,01,08", "", "")
            AddDBCommandItem(nameMap, codeMap, "STATIC_COOLING_START", "1,03,01,25,01,09", "", "")
            AddDBCommandItem(nameMap, codeMap, "STATIC_COOLING_STOP", "1,03,01,25,01,10", "", "")
            AddDBCommandItem(nameMap, codeMap, "TEC_POWER", "1,03,01,26,01,07", "", "")
            '<!--Remove-->
            AddDBCommandItem(nameMap, codeMap, "GAS_TARGET_FLOWRATE_A_PROGRAM", "x,05,01,08,01,03", "GasController_Argon_Program", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS_ACTUAL_FLOWRATE_A_READBACK", "x,05,01,08,01,04", "GasController_Argon_Readback", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS_ACTUAL_FLOWRATE_O_READBACK", "x,05,01,08,02,04", "", "")
            AddDBCommandItem(nameMap, codeMap, "GAS_TYPE", "x,05,01,08,01,05", "", "")
            AddDBCommandItem(nameMap, codeMap, "GAS_MFC_MAX_RANGE", "x,05,01,08,01,06", "", "")

            AddDBCommandItem(nameMap, codeMap, "GAS_FLOWRATE_ERROR_TOL", "1,05,01,08,01,07", "", "")
            AddDBCommandItem(nameMap, codeMap, "GAS_FLOWRATE_WARNING_TOL", "1,05,01,08,01,08", "", "")
            AddDBCommandItem(nameMap, codeMap, "GAS_FLOWRATE_ERROR_TIME", "1,05,01,08,01,09", "", "")
            AddDBCommandItem(nameMap, codeMap, "GAS_FLOWRATE_WARNING_TIME", "1,05,01,08,01,10", "", "")

            AddDBCommandItem(nameMap, codeMap, "GAS1_TYPE", "1,05,01,08,01,05", "Gas1Type", "")
            AddDBCommandItem(nameMap, codeMap, "GAS2_TYPE", "1,05,01,08,02,05", "Gas2Type", "")
            AddDBCommandItem(nameMap, codeMap, "GAS3_TYPE", "1,05,01,08,03,05", "Gas3Type", "")
            AddDBCommandItem(nameMap, codeMap, "GAS4_TYPE", "1,05,01,08,04,05", "Gas4Type", "")
            AddDBCommandItem(nameMap, codeMap, "GAS5_TYPE", "1,05,01,08,05,05", "Gas5Type", "")

            AddDBCommandItem(nameMap, codeMap, "GAS1_MAX_RANGE", "1,05,01,08,01,06", "Gas1MaxRange", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS2_MAX_RANGE", "1,05,01,08,02,06", "Gas2MaxRange", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS3_MAX_RANGE", "1,05,01,08,03,06", "Gas3MaxRange", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS4_MAX_RANGE", "1,05,01,08,04,06", "Gas4MaxRange", "Double")
            AddDBCommandItem(nameMap, codeMap, "GAS5_MAX_RANGE", "1,05,01,08,05,06", "Gas5MaxRange", "Double")

            '<!--old command fixture -->

            AddDBCommandItem(nameMap, codeMap, "FIXTURE_LOCK", "1,03,01,03,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_CLAMP", "1,03,01,07,01,01", "FixtureClampStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_ROTATION_ERROR", "1,03,01,08,01,04", "FixtureRotationErrorStatus", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_HOME_ALL_AXIS", "1,03,01,13,01,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_STOP_ALL_AXIS", "1,03,01,13,01,01,00", "", "")
            AddDBCommandItem(nameMap, codeMap, "FIXTURE_ROTATION_DWELL_TIME", "03,01,08,01,13", "", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_MODIFY_STEPTIME", "1,05,01,22,01,14", "", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_STEPTIME_TIMEOUT", "1,05,01,22,01,15", "", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_GEM_WAITFOR_STEPTIME", "1,05,01,22,01,16", "", "")
            AddDBCommandItem(nameMap, codeMap, "ELECTROSTATIC_SHUTTER_BYPASS", "1,05,01,28,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "ELECTROSTATIC_SHUTTER_TIMER", "1,05,01,28,01,02", "", "")
            AddDBCommandItem(nameMap, codeMap, "WAFER_ABORT_STATUS", "1,05,01,30,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "MAX_SUPP_CURRENT", "1,05,01,31,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "MAX_REF_RF", "1,05,01,31,01,02", "", "")
            AddDBCommandItem(nameMap, codeMap, "MIN_PBN_CURRENT", "1,05,01,31,01,03", "", "")
            AddDBCommandItem(nameMap, codeMap, "MAX_PBN_CURRENT", "1,05,01,31,01,04", "", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_ABORT_MESSAGE", "1,05,01,22,01,07", "", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_LOT_ID", "1,05,01,22,01,08", "", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CASSETTE_ID", "1,05,01,22,01,09", "", "")
            AddDBCommandItem(nameMap, codeMap, "SOURCE_GRID_ID", "1,05,01,33,01,04", "", "")
            AddDBCommandItem(nameMap, codeMap, "SOURCE_MAGNET_MODE", "1,05,01,34,01,05", "", "")
            AddDBCommandItem(nameMap, codeMap, "SOURCE_MAGNET_SPEED", "1,05,01,34,01,08", "", "")
            AddDBCommandItem(nameMap, codeMap, "SUPP_VOLTAGE_ERROR_TOL", "1,05,01,14,01,07", "", "")
            AddDBCommandItem(nameMap, codeMap, "SUPP_VOLTAGE_WARNING_TOL", "1,05,01,14,01,08", "", "")
            AddDBCommandItem(nameMap, codeMap, "SUPP_VOLTAGE_ERROR_TIME", "1,05,01,14,01,09", "", "")
            AddDBCommandItem(nameMap, codeMap, "SUPP_VOLTAGE_WARNING_TIME", "1,05,01,14,01,10", "", "")
            AddDBCommandItem(nameMap, codeMap, "BEAM_CURRENT_ERROR_TOL", "1,05,01,13,01,07", "", "")
            AddDBCommandItem(nameMap, codeMap, "BEAM_CURRENT_WARNING_TOL", "1,05,01,13,01,08", "", "")
            AddDBCommandItem(nameMap, codeMap, "BEAM_CURRENT_ERROR_TIME", "1,05,01,13,01,09", "", "")
            AddDBCommandItem(nameMap, codeMap, "BEAM_CURRENT_WARNING_TIME", "1,05,01,13,01,10", "", "")
            AddDBCommandItem(nameMap, codeMap, "BEAM_VOLTAGE_ERROR_TOL", "1,05,01,12,01,07", "", "")
            AddDBCommandItem(nameMap, codeMap, "BEAM_VOLTAGE_WARNING_TOL", "1,05,01,12,01,08", "", "")
            AddDBCommandItem(nameMap, codeMap, "BEAM_VOLTAGE_ERROR_TIME", "1,05,01,12,01,09", "", "")
            AddDBCommandItem(nameMap, codeMap, "BEAM_VOLTAGE_WARNING_TIME", "1,05,01,12,01,10", "", "")
            AddDBCommandItem(nameMap, codeMap, "ION_GAUGE_EMISSION", "1,02,01,08,01,02", "", "")
            AddDBCommandItem(nameMap, codeMap, "SLAVE_TURBO", "1,02,01,03,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "CHAMBER_HEATER", "1,02,01,16,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "PROCESS_START_PRESSURE", "1,02,01,19,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "PUMPED_DOWN_PRESSURE", "1,02,01,19,01,02", "", "")
            AddDBCommandItem(nameMap, codeMap, "ATMOSPHERE_PRESSURE", "1,02,01,19,01,03", "", "")
            AddDBCommandItem(nameMap, codeMap, "ROUGH_TIMEOUT", "1,02,01,19,01,04", "", "")
            AddDBCommandItem(nameMap, codeMap, "VENT_TIMEOUT", "1,02,01,19,01,05", "", "")
            AddDBCommandItem(nameMap, codeMap, "TURBO_VENT_DELAY", "1,02,01,19,01,06", "", "")
            AddDBCommandItem(nameMap, codeMap, "PBN_GAS_FLOWRATE_ERROR_TOL", "1,05,01,09,01,07", "", "")
            AddDBCommandItem(nameMap, codeMap, "PBN_GAS_FLOWRATE_WARNING_TOL", "1,05,01,09,01,08", "", "")
            AddDBCommandItem(nameMap, codeMap, "PBN_GAS_FLOWRATE_ERROR_TIME", "1,05,01,09,01,09", "", "")
            AddDBCommandItem(nameMap, codeMap, "PBN_GAS_FLOWRATE_WARNING_TIME", "1,05,01,09,01,10", "", "")
            AddDBCommandItem(nameMap, codeMap, "ELECTRONIC_SHUTTER", "1,05,01,07,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "KEEP_ALIVE", "1,00,00,00,00,00,00", "", "")

            ' Chiller Command
            AddDBCommandItem(nameMap, codeMap, "CHILLER_ON_OFF", "1,05,01,29,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "CHILLER_STATE", "1,05,01,29,02,01", "ChillerStateReadback", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "CHILLER_TEMP_RB", "1,05,01,29,04,01", "ChillerTemperatureReadback", "Double")
            AddDBCommandItem(nameMap, codeMap, "CHILLER_FLOWRATE_RB", "1,05,01,29,09,01", "ChillerFlowRateReadBack", "Double")
            AddDBCommandItem(nameMap, codeMap, "CHILLER_TEMP_SP", "1,05,01,29,03,01", "ChillerTemperatureSP", "Double")
            AddDBCommandItem(nameMap, codeMap, "CHILLER_COMMUNICATION", "1,05,01,29,10,01", "ChillerCommunication", "WorkingStatuses")

            AddDBCommandItem(nameMap, codeMap, "CHILLER_VENT_TEMPERATURE_MIN", "1,05,01,29,05,01", "ChillerVentTemperatureMin", "Double")
            AddDBCommandItem(nameMap, codeMap, "CHILLER_VENT_TEMPERATURE_MAX", "1,05,01,29,06,01", "ChillerVentTemperatureMax", "Double")
            AddDBCommandItem(nameMap, codeMap, "CHILLER_PROCESS_TEMPERATURE_MIN", "1,05,01,29,07,01", "ChillerProcessTemperatureMin", "Double")
            AddDBCommandItem(nameMap, codeMap, "CHILLER_PROCESS_TEMPERATURE_MAX", "1,05,01,29,08,01", "ChillerProcessTemperatureMax", "Double")

            ''' <!--Set ATM/VAC CG -->
            AddDBCommandItem(nameMap, codeMap, "PRESSURE_CG_ATM", "1,05,01,27,01,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "PRESSURE_CG_VAC", "1,05,01,27,02,01", "", "")

            AddDBCommandItem(nameMap, codeMap, "FORELINE_CG_ATM", "1,05,01,27,03,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "FORELINE_CG_VAC", "1,05,01,27,04,01", "", "")

            AddDBCommandItem(nameMap, codeMap, "ROUGH_PUMP_CG_ATM", "1,05,01,27,05,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "ROUGH_PUMP_CG_VAC", "1,05,01,27,06,01", "", "")

            AddDBCommandItem(nameMap, codeMap, "TURN_IG_ON_OFF", "1,05,01,27,07,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "ENABLE_ROUGH_CG_ATM", "1,05,01,27,01,02", "EnableRoughCGATM", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "ENABLE_FORELINE_CG_ARM", "1,05,01,27,03,02", "EnableForelineCGATM", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "ENABLE_PRESSURE_CG_ATM", "1,05,01,27,05,02", "EnablePressureCGATM", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "ENABLE_PRESSURE_CG_VAC", "1,05,01,27,06,02", "EnablePressureCGVAC", "WorkingStatuses")
            AddDBCommandItem(nameMap, codeMap, "SWITCH_IG_FILAMENT_PROGRAM", "1,05,01,27,08,01", "", "")
            AddDBCommandItem(nameMap, codeMap, "SWITCH_IG_FILAMENT_READBACK", "1,05,01,27,09,01", "SwitchIGFilament", "Double")
            AddDBCommandItem(nameMap, codeMap, "ENABLE_IG_FILAMENT_READBACK", "1,05,01,28,09,01", "EnableIGFilament", "String")

            '<-- Step Complete --> 
            AddDBCommandItem(nameMap, codeMap, "PROCESS_RECIPE_STEP_COMPLETE", "1,05,01,22,01,21", "StepCompleted", "Double")

            ' Step Complete ProcessCycleATMStart
            AddDBCommandItem(nameMap, codeMap, "PROCESS_CYCLEATM_START", "1,05,01,36,01,01", "ProcessCycleATMStart", "String")

            '' Source EM PS
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.SOURCE_EM_CURRENT_PROGRAM.ToString(), "1,05,01,37,01,01", "SourceEMCurrentSP", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.SOURCE_EM_CURRENT_READBACK.ToString(), "1,05,01,37,01,02", "SourceEMCurrentRB", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.SOURCE_EM_VOLTAGE_READBACK.ToString(), "1,05,01,37,02,01", "SourceEMVoltageRB", "Double")
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.SOURCE_EM_CURRENT_AUTO_BEAM_PROGRAM.ToString(), "1,05,01,37,03,01", "", "")
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.SOURCE_EM_COMMUNIACTION_STATUS.ToString(), "1,05,01,37,04,01", "SourceEMCommunicationStatus", "WorkingStatuses")

            ' Hidden Command
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.HIDDEN_NAME, "1,06,02,02,01,02", "HiddenName", "String")
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.HIDDEN_DATA, "1,06,02,02,02,02", "HiddenData", "String")
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.HIDDEN_PARAMS, "1,06,02,02,03,02", "HidenParams", "String")
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.HIDDEN_ENVIRONMENT, "1,06,02,02,04,02", "HidenEnvironment", "String")


            '' Claer All Alarm
            AddDBCommandItem(nameMap, codeMap, Business.IBECommands.CLEAR_ALL_ALARM_PROGRAM.ToString(), "1,07,03,01,01,01", "", "")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-03</date>
    ''' </author>
    ''' <summary>
    ''' GetKepServer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPVDMaintenance(Optional ByVal IsGetPVDMaintenanceCode As Boolean = False) As Hashtable
        Dim map As Hashtable = Nothing
        Try ''use this function for pvd
            map = MaintenanceLib.GetConfigurationServer(PVDMaintenanceDoc, _
                                                           AVPLib.ContainerData.m_PVDMaintenanceCodeMap, _
                                                           IsGetPVDMaintenanceCode)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return map
    End Function
#End Region

#Region "Configuration"

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Get Robot Configuration.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRobotConfig() As Hashtable
        Try
            ' The XPath to the timeout session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
            Return RobotConfiguration.GetRobotConfig(root, SystemConfigDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Set Robot Configuration.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub SetRobotConfig(ByVal Key As String, ByVal Value As Object)
        Try
            Dim Xpath As String = String.Format(ConstEnum.XPATH_ROBOT & "/MessageText[Key = '{0}']/Value", Key)
            Dim node As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(Xpath)

            If node Is Nothing Then
                node = SystemConfigDoc.SelectSingleNode(String.Format(ConstEnum.XPATH_ROBOT & "/Configure[Key = '{0}']/Value", Key))
                If node IsNot Nothing Then
                    node.InnerText = Value.ToString()
                    BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
                    Return
                End If
            End If

            If node Is Nothing Then 'PMConfig
                Dim str_Chamber() As String = Key.Split(".")
                Dim str_ChamberName As String = str_Chamber(0)
                Dim str_ChamberType As String = str_Chamber(1)

                Xpath = String.Format(ConstEnum.XPATH_ROBOT & "/" & str_ChamberName & "/MessageText[Key = '{0}']/Value", Key)
                Select Case str_ChamberType.ToUpper
                    Case SystemModule.ModuleType.PVD5T.ToString()
                        node = PVD5TSystemConfigDoc.SelectSingleNode(Xpath)
                    Case Else
                        Utils.ShowStatusMessage("ERROR IN LOADING MESSAGETEXT, PLEASE CHECK IT....KEY=" & Key)
                End Select

                node.InnerText = Value.ToString()

                Select Case str_ChamberType.ToUpper
                    '' PVD2R4
                    Case SystemModule.ModuleType.PVD5T.ToString()
                        BinarySerialize.SaveTo_DatFilePMConfig(AVPLib.ContainerDAO.PVD5TPath_SystemConfig, PVD5TSystemConfigDoc)
                End Select

            Else
                node.InnerText = Value.ToString()
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-12 </date>
    ''' </author>
    ''' <summary>
    ''' Update PM MinMax Value
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub UpdatePMMinMaxValue(ByVal obj As Object)
        Try
            Dim lstParam As List(Of String) = CType(obj, List(Of String))
            If lstParam Is Nothing OrElse lstParam.Count <> 4 Then
                ''invalid param
                Exit Sub
            End If

            Dim strChamber As String = lstParam.Item(0)
            Dim strKey As String = lstParam.Item(1)
            Dim strMinValue As String = lstParam.Item(2)
            Dim strMaxValue As String = lstParam.Item(3)
            Const PM_NAME_REMOVE_LENGTH As Integer = 9 ' remove "ChamberX." from key 

            Dim PMConfigDoc As New Xml.XmlDocument
            Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(strChamber)
            Dim strPMConfigFilePath As String = serverConfig.ConfigFolder

            If serverConfig Is Nothing Then
                AVPLib.Log.avpLogger.Error("Can not read ConfigurationServer from PM Folder ")
                Exit Sub
            Else
                ''IBE
                If serverConfig.Type = ConstEnum.IBEType.AVP_IBE.ToString() Then ''read IBE config
                    strPMConfigFilePath &= "\" & ContainerDAO.FIBEConfigName
                    PMConfigDoc = BinarySerialize.Open_DatFileConfig(strPMConfigFilePath)
                ElseIf serverConfig.Type = ConstEnum.IBEType.VEECO_IBE.ToString() Then
                    'Do nothing
                    Exit Sub
                    ''PVD4
                ElseIf serverConfig.Type = SystemModule.ModuleType.PVD4.ToString Then
                    strPMConfigFilePath &= "\" & ContainerDAO.FCORONAConfigName
                    PMConfigDoc = BinarySerialize.Open_DatFileConfig(strPMConfigFilePath)
                    ''PVD5T
                ElseIf serverConfig.Type = SystemModule.ModuleType.PVD5T.ToString() Then
                    strPMConfigFilePath &= "\" & ContainerDAO.PVD5TConfigName
                    PMConfigDoc = BinarySerialize.Open_DatFileConfig(strPMConfigFilePath)
                Else ''PM is PVD
                    strPMConfigFilePath &= "\" & ContainerDAO.FPVDConfigName
                    PMConfigDoc = BinarySerialize.Open_DatFileConfig(strPMConfigFilePath)
                End If

                If PMConfigDoc Is Nothing Then
                    AVPLib.Log.avpLogger.Error("Can not access PM Config File - " & strPMConfigFilePath)
                    Exit Sub
                End If
            End If

            strKey = strKey.Remove(0, PM_NAME_REMOVE_LENGTH)

            Dim xmlNode As Xml.XmlNode = Nothing

            ''PVD RF Power
            If PM_MIN_MAX_NAME_ITEM.PVD_RF_POWER_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Target_Power_Supply_RF_Installed.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_MAX_SP_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_MAX_SP_TAG).Value = strMaxValue
                End If

                ''PVD DC Power
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_DC_POWER_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Target_Power_Supply_DC_Installed.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_MAX_SP_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_MAX_SP_TAG).Value = strMaxValue
                End If

                ''PVD Bias Power
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_BIAS_POWER_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Bias_Power_Supply_Installed.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_MAX_SP_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_MAX_SP_TAG).Value = strMaxValue
                End If

                ''PVD Gas1
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_GAS1_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Gas1MFCEnable.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''PVD Gas2
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_GAS2_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Gas2MFCEnable.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''PVD Gas3
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_GAS3_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Gas3MFCEnable.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''PVD Gas4
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_GAS4_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Gas4MFCEnable.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''PVD Gas5
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_GAS5_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Gas5MFCEnable.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''PVD Parallel Magnet
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_PARALLEL_MAGNET_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Parallel_Magnet_Installed.ToString())
                If xmlNode IsNot Nothing Then
                    Dim strParallelMagnetType As String = xmlNode.Attributes("WhichModel").Value
                    If strParallelMagnetType = "BOP-20/20" Then
                        strParallelMagnetType = "BOP20_20MaxCurrent"
                    ElseIf strParallelMagnetType = "BOP-50/8" Then
                        strParallelMagnetType = "BOP50_8MaxCurrent"
                    End If
                    xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_Parameters & "/" & strParallelMagnetType)
                    If xmlNode IsNot Nothing Then
                        xmlNode.InnerText = strMaxValue
                    End If
                End If

                ''IBE RF Power
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_RF_POWER_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.RF_Power_Supply_Installed.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_MAX_SP_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_MAX_SP_TAG).Value = strMaxValue
                End If

                ''IBE Suppressor Voltage
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_SUPPRESSOR_VOLTAGE_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.MaxSuppressorVoltageSP.ToString())
                If xmlNode IsNot Nothing Then
                    xmlNode.InnerText = strMaxValue
                End If

                ''IBE Beam Voltage
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_BEAM_VOLTAGE_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.MaxBeamVoltageSP.ToString())
                If xmlNode IsNot Nothing Then
                    xmlNode.InnerText = strMaxValue
                End If

                ''IBE Gas 1
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_GAS1_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Gas1MFCEnable.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''IBE Gas 2
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_GAS2_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Gas2MFCEnable.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''IBE Gas 3
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_GAS3_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Gas3MFCEnable.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''IBE Gas 4
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_GAS4_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Gas4MFCEnable.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''IBE Gas 5
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_GAS5_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.Gas5MFCEnable.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''IBE PBN Gas
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_PBN_GAS_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.PBNGas_Installed.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''IBE FlowCool Gas
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_FLOWCOOL_GAS_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_SystemConfig & "/" & PM_TAG_CONFIG.FlowCool_Installed.ToString())
                If xmlNode IsNot Nothing AndAlso xmlNode.Attributes(STR_RANGEVALUE_TAG) IsNot Nothing Then
                    xmlNode.Attributes(STR_RANGEVALUE_TAG).Value = strMaxValue
                End If

                ''IBE Tilt Angle
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_TILE_ANGLE_MAX_SP.Contains(strKey) Then
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_Parameters & "/" & PM_TAG_CONFIG.ShutterOpenClosedSafeAngleLower.ToString())
                If xmlNode IsNot Nothing Then
                    xmlNode.InnerText = strMinValue
                End If
                xmlNode = PMConfigDoc.SelectSingleNode(FPath_PM_Parameters & "/" & PM_TAG_CONFIG.ShutterOpenClosedSafeAngleUpper.ToString())
                If xmlNode IsNot Nothing Then
                    xmlNode.InnerText = strMaxValue
                End If
            End If

            BinarySerialize.SaveTo_DatFileConfig(strPMConfigFilePath, PMConfigDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub



    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-08</date>
    ''' </author>
    ''' <summary>
    ''' GetPressureConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPressureConfig() As Hashtable
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEMPRESSURE)
            Return PressureConfigurationLib.GetPressureConfig(root)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    Public Shared Function GetTransferPressureSetpointConfig() As Hashtable
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_TRANSFER_PRESSURE_SET_POINT)
            Return PressureConfigurationLib.GetTransferPressureSetpointConfig(root)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    Public Shared Function GetLLElevatorConfig(ByVal ElevatorName) As Hashtable
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_LL_ELEVATOR_CONFIG)
            Return PressureConfigurationLib.GetLLElevatorConfig(root, ElevatorName)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' GetPressureConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPumpdownConfigLL() As Hashtable
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_VENTPUMPDOWNCONFIG)
            Return VentPumdownLib.GetVentPumpdownConfig(root, LLPUMPDOWN_CONFIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Do Xuan Dat</name>
    '''    	<date> 2009-09-4</date>
    ''' </author>
    ''' <summary>
    ''' GetChambersConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChambersConfig() As Hashtable
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_CHAMBERSCONFIG)
            Return RobotConfiguration.GetChamberConfig(root)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Do Xuan Dat</name>
    '''    	<date> 2009-09-4</date>
    ''' </author>
    ''' <summary>
    ''' GetChambersConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRobot_Animation_Config() As String
        Try
            'Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOTANIMATION)
            'If root Is Nothing Then
            '    Return RobotConfigurationValues.DELAY_ROBOT_ANIMATION.ToString()
            'End If
            'Return root.InnerText
            Return SYSTEM_CONFIG_ROBOT_ANIMATION.ROBOT_ANIMATION_VALUE.ToString()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Vo Tan Dat</name>
    '''    	<date> 2010-09-17</date>
    ''' </author>
    ''' <summary>
    ''' GetDelay_Time_KeepAlive
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDelay_Time_KeepAlive() As String
        Try
            'Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_DELAYTIME_KEEPALIVE)
            'If root Is Nothing Then
            '    Return RobotConfigurationValues.DELAY_TIME_KEEPALIVE.ToString()
            'End If
            'Return root.InnerText
            Return SYSTEM_DELAY_TIME_FOR_KEEP_ALIVE.DELAY_TIME_FOR_KEEP_ALIVE_VALUE.ToString()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' GetConnectionTimeOut
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetConnectionTimeOut() As String
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_CONNECTION_TIMEOUT)
            If root Is Nothing Then
                Return RobotConfigurationValues.CONNECTION_TIMEOUT.ToString()
            End If
            Return root.InnerText
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    Public Shared Function GetDegasWaitTime() As Xml.XmlNode
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_DEGAS_WAIT_TIME)
            If root Is Nothing Then
                Return Nothing
            End If
            Return root
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    Public Shared Function GetCryoRegenHourLimit() As Boolean
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_CRYO_REGEN_HOUR_LIMIT)
            If root Is Nothing Then
                Return False
            End If
            If Integer.TryParse(root.InnerText, RobotConfigurationValues.CRYO_REGEN_HOURS_LIMIT) Then
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function
    ''' <author>
    '''    	<name> Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' GetPressureConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPumpdownConfigTM() As Hashtable
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_VENTPUMPDOWNCONFIG)
            Return VentPumdownLib.GetVentPumpdownConfig(root, TMPUMPDOWN_CONFIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' GetPressureConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetVentConfigLL() As Hashtable
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_VENTPUMPDOWNCONFIG)
            Return VentPumdownLib.GetVentPumpdownConfig(root, LLVENT_CONFIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' GetPressureConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetVentConfigTM() As Hashtable
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_VENTPUMPDOWNCONFIG)
            Return VentPumdownLib.GetVentPumpdownConfig(root, TMVENT_CONFIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Tinh Le</name>
    '''    	<date> 2018/11/23</date>
    ''' </author>
    ''' <summary>
    ''' GetCGConfig
    ''' </summary>
    Public Shared Function GetCGConfig() As Hashtable
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_VENTPUMPDOWNCONFIG)
            Return VentPumdownLib.GetVentPumpdownConfig(root, CG_CONFIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-08</date>
    ''' </author>
    ''' <summary>
    ''' SavePressureConfig
    ''' </summary>
    ''' <param name="TransferModuleMin"></param>
    ''' <param name="TransferModuleMax"></param>
    ''' <param name="LoadLockAMin"></param>
    ''' <param name="LoadLockAMax"></param>
    ''' <param name="LoadLockBMin"></param>
    ''' <param name="LoadLockBMax"></param>
    ''' <param name="IBEMaintenanceMin"></param>
    ''' <param name="IBEMaintenanceMax"></param>
    ''' <remarks></remarks>
    Public Shared Function SavePressureConfig(ByVal TransferModuleMin As Double, ByVal TransferModuleMax As Double, _
    ByVal LoadLockAMin As Double, ByVal LoadLockAMax As Double, ByVal IBEMaintenanceMin As Double, ByVal IBEMaintenanceMax As Double) As Boolean
        Try
            Return PressureConfigurationLib.SavePressureConfig(SystemConfigDoc, TransferModuleMin, TransferModuleMax, LoadLockAMin, LoadLockAMax, IBEMaintenanceMin, IBEMaintenanceMax)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function
#End Region

#Region "Store GUI"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' Get Store Gui
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStoreGui() As DBStoreGui
        Try
            Return StoreGuiLib.GetStoreGui(StoreGuiDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' Save Store Gui
    ''' </summary>
    ''' <param name="StoreGui"></param>
    ''' <remarks></remarks>
    Public Shared Sub SaveStoreGui(ByVal StoreGui As DBStoreGui)
        Try
            StoreGuiLib.SaveStoreGui(StoreGuiDoc, StoreGui)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Public Shared Sub SaveLifeTimeWafer()
        Try
            StoreGuiLib.SaveLifeTimeWafer(StoreGuiDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub SaveWaferCountForEQ(ByVal EQName As String, ByVal WaferCount As Integer)
        Try
            StoreGuiLib.SaveWaferCountForEQ(StoreGuiDoc, EQName, WaferCount)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2017-10-27 </date>
    ''' </author>
    ''' <summary>
    ''' Save Run No. 
    ''' </summary>
    Public Shared Sub SaveRunNo(ByVal runNo As Integer)
        Try
            StoreGuiLib.SaveRunNo(StoreGuiDoc, runNo)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2017-10-27 </date>
    ''' </author>
    ''' <summary>
    ''' Get Run No. 
    ''' </summary>
    Public Shared Function GetRunNo() As Integer
        AVPLib.Log.coreLogger.Info("Enter GetRunNo")
        Dim result As Integer = 0
        Try
            Dim root As System.Xml.XmlNode = Nothing
            root = StoreGuiDoc.SelectSingleNode("/StoreGui/RunNo")
            If root IsNot Nothing Then
                Integer.TryParse(root.InnerText, result)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetRunNo")
        Return result
    End Function

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-02-27</date>
    ''' </author>
    ''' <summary>
    ''' Get Total Wafer Count and increase by one
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IncreaseTotalWaferCount() As Integer
        AVPLib.Log.coreLogger.Info("Enter IncreaseTotalWaferCount")
        Dim iResult As Integer = 0
        Try
            Dim root As System.Xml.XmlNode = Nothing
            root = StoreGuiDoc.SelectSingleNode("/StoreGui/TotalWaferCount")
            If root IsNot Nothing Then
                root.InnerText = (CInt(root.InnerText) + 1).ToString()
                iResult = CInt(root.InnerText)
                StoreGuiDoc.Save(ContainerDAO.FPath_StoreGui)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave IncreaseTotalWaferCount")
        Return iResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-02-27</date>
    ''' </author>
    ''' <summary>
    ''' Get Total wafer count 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TotalWaferCount() As Integer
        AVPLib.Log.coreLogger.Info("Enter TotalWaferCount")
        Dim iResult As Integer = 0
        Try
            Dim root As System.Xml.XmlNode = Nothing
            root = StoreGuiDoc.SelectSingleNode("/StoreGui/TotalWaferCount")
            If root IsNot Nothing Then
                iResult = CInt(root.InnerText)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave TotalWaferCount")
        Return iResult
    End Function
#End Region

#Region "State Machine"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set List of State Machine
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub LoadProcessJob()
        If m_ProcessJobDoc Is Nothing Then
            m_ProcessJobDoc = New System.Xml.XmlDocument()
            Try
                m_ProcessJobDoc.Load(FPath_ProcessJob)
                'm_ProcessJobDoc = BinarySerialize.Open_DatFileConfig(FPath_ProcessJob)
            Catch ex As Exception
                'try to load the local file
                m_ProcessJobDoc.LoadXml(XMLResources.ProcessJob.XMLText)
                m_ProcessJobDoc.Save(FPath_ProcessJob)
                'BinarySerialize.SaveTo_DatFileConfig(FPath_ProcessJob, m_ProcessJobDoc)
            End Try
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set List of State Machine
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub LoadControlJob()
        If m_ControlJobDoc Is Nothing Then
            m_ControlJobDoc = New System.Xml.XmlDocument()
            Try
                m_ControlJobDoc.Load(FPath_ControlJob)
                'm_ControlJobDoc = BinarySerialize.Open_DatFileConfig(FPath_ControlJob)
            Catch ex As Exception
                'try to load the local file
                m_ControlJobDoc.LoadXml(XMLResources.ControlJob.XMLText)
                m_ControlJobDoc.Save(FPath_ControlJob)
                'BinarySerialize.SaveTo_DatFileConfig(FPath_ControlJob, m_ControlJobDoc)
            End Try
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set List of State Machine
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub LoadEquipmentTracking()
        If m_EquipmentTrackingDoc Is Nothing Then
            m_EquipmentTrackingDoc = New System.Xml.XmlDocument()
            Try
                m_EquipmentTrackingDoc.Load(FPath_EquipmentTracking)
                'm_EquipmentTrackingDoc = BinarySerialize.Open_DatFileConfig(FPath_EquipmentTracking)
            Catch ex As Exception
                'try to load the local file
                m_EquipmentTrackingDoc.LoadXml(XMLResources.EquipmentTracking.XMLText)
                m_EquipmentTrackingDoc.Save(FPath_EquipmentTracking)
                'BinarySerialize.SaveTo_DatFileConfig(FPath_EquipmentTracking, m_EquipmentTrackingDoc)
            End Try
        End If

    End Sub

#End Region

#Region "System WaferFlow"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-13</date>
    ''' </author>
    ''' <summary>
    ''' Load file from FPath_WaferFlow
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Shared Sub LoadSystemWaferFlow()
    '    Try
    '        ' If m_WaferFlowDoc Is Nothing Then
    '        m_WaferFlowDoc = New System.Xml.XmlDocument()
    '        Try
    '            m_WaferFlowDoc = BinarySerialize.Open_DatFileConfig(FPath_WaferFlow) '.Load(FPath_WaferFlow)

    '        Catch ex As Exception
    '            'try to load the local file
    '            m_WaferFlowDoc.LoadXml(XMLResources.SystemWaferFlow.XMLText)
    '            'm_WaferFlowDoc.Save(FPath_WaferFlow)
    '            BinarySerialize.SaveTo_DatFileConfig(FPath_WaferFlow, m_WaferFlowDoc)
    '        End Try
    '        'End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-13</date>
    ''' </author>
    ''' <summary>
    ''' Save SystemWaferFlow to  FPath_WaferFlow
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub SaveSystemWaferFlow(ByVal Waferdoc As Xml.XmlDocument)
        Try
            'Waferdoc.Save(FPath_WaferFlow)
            BinarySerialize.SaveTo_DatFileConfig(FPath_WaferFlow, Waferdoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-06-30</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub LoadSystemConfigDoc()
        If m_SystemConfigDoc Is Nothing Then
            m_SystemConfigDoc = New System.Xml.XmlDocument()
            Try
                m_PVD5TSystemConfigDoc = BinarySerialize.Open_DatFileConfig(PVD5TPath_SystemConfig) 'Read config for PVD5T
                m_SystemConfigDoc = BinarySerialize.Open_DatFileConfig(FPath_SystemConfig) '.Load(FPath_SystemConfig)
                If m_SystemConfigDoc Is Nothing Then
                    m_SystemConfigDoc = New System.Xml.XmlDocument()
                    'try to load the local file
                    m_SystemConfigDoc.LoadXml(XMLResources.SystemConfig.XMLText)
                    'm_SystemConfigDoc.Save(FPath_SystemConfig)
                    BinarySerialize.SaveTo_DatFileConfig(FPath_SystemConfig, m_SystemConfigDoc)
                End If
            Catch ex As Exception
                'try to load the local file
                m_SystemConfigDoc.LoadXml(XMLResources.SystemConfig.XMLText)
                'm_SystemConfigDoc.Save(FPath_SystemConfig)
                BinarySerialize.SaveTo_DatFileConfig(FPath_SystemConfig, m_SystemConfigDoc)
            End Try
        End If
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2010-12-28</date>
    ''' </author>
    ''' <summary>
    ''' Load Source Usage for SL
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Shared Function LoadSourceUsage() As String
    '    'Try
    '    Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(XPATH_SOURCE_USAGE_CONFIG)
    '    For Each xmlnode As Xml.XmlNode In root.ChildNodes
    '        If xmlnode.FirstChild.InnerText = "SourceUsage" Then
    '            Return xmlnode.ChildNodes(1).InnerText
    '        End If
    '    Next
    '    Return String.Empty
    'End Function

    'Public Shared Function SaveSourceUsage(ByVal strValue As String) As Boolean
    '    'Try
    '    Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(XPATH_SOURCE_USAGE_CONFIG)
    '    For Each xmlnode As Xml.XmlNode In root.ChildNodes
    '        If xmlnode.FirstChild.InnerText = "SourceUsage" Then
    '            xmlnode.ChildNodes(1).InnerText = strValue
    '            ' SystemConfigDoc.Save(FPath_SystemConfig)
    '            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
    '            Return True
    '        End If
    '    Next
    '    Return False
    'End Function
#End Region

#Region "System Date Run"
    Public Shared Function GetSystemDateRun() As String
        Dim rs As String = String.Empty
        Try
            ' The XPath to the polling session
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEM_DATE_RUN)
            rs = root.InnerText.ToString()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return rs
    End Function

#End Region


    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-08 </date>
    ''' </author>
    ''' <summary>
    ''' LoadConfigMail 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub LoadConfigMail()
        AVPLib.Log.coreLogger.Info("Enter LoadConfigMail")
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_MAILINFO)

#If AVP_PLATFORM = "CX" Then
            Const STR_TRUE As String = "true"
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes

            For e As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(e)
                Dim nodeListChild As System.Xml.XmlNodeList = node.ChildNodes

                Select Case node.Name
                    Case STR_AUTO_SEND_MAIL
                        AVPLib.SendEmail.Instance.AutoSendMail = IIf(node.InnerText.ToLower = STR_TRUE, True, False)

                    Case STR_SMTP_SERVER
                        AVPLib.SendEmail.Instance.SMTPServer = node.InnerText

                    Case STR_PORT_ID
                        AVPLib.SendEmail.Instance.PortID = node.InnerText

                    Case STR_USER_NAME
                        AVPLib.SendEmail.Instance.UserName = node.InnerText

                    Case STR_PASSWORD
                        AVPLib.SendEmail.Instance.Password = EncryptionHelper.Decrypt(node.InnerText, AVPLib.SendEmail.Instance.Key4Password)

                    Case STR_EMAIL_TO
                        For i As Integer = 0 To nodeListChild.Count - 1
                            Dim nodeChild As System.Xml.XmlNode = nodeListChild.Item(i)
                            Dim key As String = nodeChild.Attributes.ItemOf(STR_NAME).Value
                            Dim objTriggerEmail As AVPLib.TriggerEmail = New AVPLib.TriggerEmail()
                            objTriggerEmail.Name = key
                            objTriggerEmail.IsAlarm = IIf(nodeChild.Attributes.ItemOf(STR_ALARM).Value.ToLower = STR_TRUE, True, False)
                            objTriggerEmail.IsScheduler = IIf(nodeChild.Attributes.ItemOf(STR_SCHEDULER).Value.ToLower = STR_TRUE, True, False)
                            objTriggerEmail.IsPressure = IIf(nodeChild.Attributes.ItemOf(STR_PRESSURE).Value.ToLower = STR_TRUE, True, False)
                            objTriggerEmail.PressureInterval = CInt(nodeChild.Attributes.ItemOf(STR_PRESSURE_INTERVAL).Value)
                            AVPLib.SendEmail.Instance.AddTrigger(key, objTriggerEmail)
                        Next

                End Select
            Next

#End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave LoadConfigMail")
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-08 </date>
    ''' </author>
    ''' <summary>
    ''' SaveConfigMail 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub SaveConfigMail()
        AVPLib.Log.coreLogger.Info("Enter SaveConfigMail")
        Try
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_MAILINFO)

#If AVP_PLATFORM = "CX" Then
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes

            For e As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(e)
                Dim nodeListChild As System.Xml.XmlNodeList = node.ChildNodes

                Select Case node.Name
                    Case STR_AUTO_SEND_MAIL
                        node.InnerText = AVPLib.SendEmail.Instance.AutoSendMail

                    Case STR_SMTP_SERVER
                        node.InnerText = AVPLib.SendEmail.Instance.SMTPServer

                    Case STR_PORT_ID
                        node.InnerText = AVPLib.SendEmail.Instance.PortID

                    Case STR_USER_NAME
                        node.InnerText = AVPLib.SendEmail.Instance.UserName

                    Case STR_PASSWORD

                        node.InnerText = EncryptionHelper.Encrypt(AVPLib.SendEmail.Instance.Password, AVPLib.SendEmail.Instance.Key4Password)

                    Case STR_EMAIL_TO
                        node.RemoveAll()
                        For Each element As DictionaryEntry In AVPLib.SendEmail.Instance.HashTriggers
                            Dim objTriggerEmail As AVPLib.TriggerEmail = element.Value
                            Dim nodeChild As System.Xml.XmlNode = SystemConfigDoc.CreateElement(STR_ITEM)

                            Dim attributeName As System.Xml.XmlAttribute = SystemConfigDoc.CreateAttribute(STR_NAME)
                            attributeName.Value = objTriggerEmail.Name

                            Dim attributeAlarm As System.Xml.XmlAttribute = SystemConfigDoc.CreateAttribute(STR_ALARM)
                            attributeAlarm.Value = objTriggerEmail.IsAlarm

                            Dim attributeScheduler As System.Xml.XmlAttribute = SystemConfigDoc.CreateAttribute(STR_SCHEDULER)
                            attributeScheduler.Value = objTriggerEmail.IsScheduler

                            Dim attributePressure As System.Xml.XmlAttribute = SystemConfigDoc.CreateAttribute(STR_PRESSURE)
                            attributePressure.Value = objTriggerEmail.IsPressure

                            Dim attributePressureInterval As System.Xml.XmlAttribute = SystemConfigDoc.CreateAttribute(STR_PRESSURE_INTERVAL)
                            attributePressureInterval.Value = objTriggerEmail.PressureInterval

                            nodeChild.Attributes.Append(attributeName)
                            nodeChild.Attributes.Append(attributeAlarm)
                            nodeChild.Attributes.Append(attributeScheduler)
                            nodeChild.Attributes.Append(attributePressure)
                            nodeChild.Attributes.Append(attributePressureInterval)

                            node.AppendChild(nodeChild)
                        Next

                End Select
            Next

            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, SystemConfigDoc)
#End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveConfigMail")
    End Sub

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for Auto Archive SystemConfig File Daily
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub SaveAutoArchiveStatusValue(ByVal strValue As String, ByVal strPath As String)
        Try
            ' path of device net config
            Dim xmldoc As System.Xml.XmlDocument = AVPLib.ContainerDAO.SystemConfigDoc
            Dim root As System.Xml.XmlNode = xmldoc.SelectSingleNode(strPath)
            If (root IsNot Nothing) Then
                root.InnerText = strValue.ToString
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, xmldoc)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-11-08</date>
    ''' </author>
    ''' <summary>
    ''' Read enable CycleATM  from Config file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EnableCycleATM() As Boolean
        Dim strResult As Boolean = False
        Try
            ' path of device net config
            Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.ENABLE_CYCLEATM)
            If (root IsNot Nothing) Then
                Boolean.TryParse(root.InnerText, strResult)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
    Public Shared Function GetPMRobotConfig(ByRef m_RobotConfigMap As Hashtable, ByVal root As System.Xml.XmlNode) As Hashtable
        Try
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                If Not (node.NodeType = XmlNodeType.Comment) Then
                    Dim nodeConfigList As System.Xml.XmlNodeList = node.ChildNodes
                    Try
                        Dim key As String = nodeConfigList.Item(0).InnerText
                        Dim value As String = nodeConfigList.Item(1).InnerText
                        m_RobotConfigMap.Add(key, value)
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error(ex.ToString())
                    End Try
                End If
            Next
            'Dim root As System.Xml.XmlNode = SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
            'Return RobotConfiguration.GetRobotConfig(root, SystemConfigDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
End Class
