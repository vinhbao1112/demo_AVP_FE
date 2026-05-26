Imports AVPLib.ConstEnum
Imports AVPLib.SystemModule
Imports System.Xml
Imports HRecipeLibrary

Public Class RobotConfiguration
    Const INVALID_MESSAGE As String = " in SystemConfig.xml file is invalid. Use default value = "
    Const STR_TRUE As String = "true"
    Public Shared lstPM As New List(Of String)
#Region "Functions"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' GetRobotConfig
    ''' </summary>
    ''' <param name="ConfigDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRobotConfig(ByVal root As System.Xml.XmlNode, ByRef xDoc As Xml.XmlDocument) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetRobotConfig")
        Dim map As New Hashtable()
        Try
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            Dim value As Object = Nothing
            Dim key As String = Nothing
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                Dim nodeConfigList As System.Xml.XmlNodeList = node.ChildNodes
                key = nodeConfigList.Item(0).InnerText
                If (nodeConfigList.Count >= 3) Then
                    Dim objSystemModule As SystemModule = Nothing
                    If node.Name = "Module" Then
                        ReadModuleNode(objSystemModule, nodeConfigList, map, xDoc)
                    End If
                ElseIf IsNumeric(nodeConfigList.Item(1).InnerText) Then

                    value = nodeConfigList.Item(1).InnerText

                Else
                    If (key.Contains(".")) Then ''for case SuppressorPowerSupplyControl.txtPowerRightMin,...
                        If key.ToLower.Contains(MAX_STR) Then
                            AVPLib.Log.coreLogger.Error("Key Max value of " + key + " in RobotConfig.xml file is invalid. Use default value = " + MAX_DEFAULT_VALUE_OF_CHAMBER.ToString())
                            value = MAX_DEFAULT_VALUE_OF_CHAMBER
                        ElseIf key.ToLower.Contains(MIN_STR) Then
                            AVPLib.Log.coreLogger.Error("Key Min value of " + key + " in RobotConfig.xml file is invalid. Use default value = " + MIN_DEFAULT_VALUE_OF_CHAMBER.ToString())
                            value = MIN_DEFAULT_VALUE_OF_CHAMBER
                        End If
                    End If
                End If
                If value IsNot Nothing Then
                    map.Add(key, value)
                End If
            Next
#If AVP_PLATFORM = "CX" Then
            'Add delta pic station loction
            map.Add(ConstEnum.DELTA_PICK_STATION, SYSTEM_CONFIG_STATION_LOCATION_VALUES.DELTA_PICK_STATION_LOCATION_INIT)
#End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetRobotConfig")
        Return map
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Read Module Node in SystemConfig.xml file
    ''' </summary>
    ''' <remarks></remarks>
    Shared Sub ReadModuleNode(ByVal objSystemModule As SystemModule, ByVal nodeconfigList As Xml.XmlNodeList, _
                              ByRef map As Hashtable, ByRef xDoc As Xml.XmlDocument)
        AVPLib.Log.coreLogger.Info("Enter ReadModuleNode")

        Try
            Dim key As String = String.Empty
            objSystemModule = New SystemModule
            For j As Integer = 0 To nodeconfigList.Count - 1
                Dim nodechild As Xml.XmlNode = nodeconfigList.Item(j)
                Select Case nodechild.Name
                    Case "Name"
                        key = nodechild.InnerText
                        Dim servername As String = key
                        If key = Equipments.LoadLockA.ToString() Then
                            servername = Equipments.LLAElevator.ToString()
                        End If
                        Dim ser As Server = AVPLib.DataManagerment.ConfigurationManager.ConfigItemList.Item(servername)
                        If ser IsNot Nothing Then
                            objSystemModule.IsVisible = ser.IsInstalled
                        Else
                            objSystemModule.IsVisible = False
                        End If
                        If ser Is Nothing Then
                            Exit Select
                        ElseIf String.IsNullOrEmpty(ser.Type) AndAlso key.StartsWith(ConstEnum.LoadLock) Then
                            ser.Type = ConstEnum.LoadLock
                        End If
                        '//
                        If Not String.IsNullOrEmpty(objSystemModule.Type) Then
                            If ser.Type = ConstEnum.IBEType.AVP_IBE.ToString() Or ser.Type = ConstEnum.IBEType.VEECO_IBE.ToString() Then
                                objSystemModule.Type = ModuleType.IBE
                                'set Veeco IBE or AVP IBE
                                objSystemModule.IBE_Type = [Enum].Parse(GetType(ConstEnum.IBEType), ser.Type, True)
                            Else
                                objSystemModule.Type = [Enum].Parse(GetType(SystemModule.ModuleType), ser.Type, True)
                            End If
                        End If
                        If objSystemModule.IsVisible = False Then
                            AVPLib.Log.coreLogger.Info("Leave ReadModuleNode")
                            Exit Sub  ''if don't install -> don't read any more config
                        End If
                    Case "Description"
                        objSystemModule.Name = nodechild.InnerText
                        'Case "StationLocation"
                        '    If Not Integer.TryParse(nodechild.InnerText, objSystemModule.StationLocation) Then
                        '        AVPLib.Log.coreLogger.Error("Key " + key + INVALID_MESSAGE + "1".ToString())
                        '        objSystemModule.StationLocation = 1
                        '    End If
                    Case "GemModuleName"
                        objSystemModule.ModuleName = nodechild.InnerText
                    Case "Robot_Version"
                        If Not Double.TryParse(nodechild.InnerText, RobotConfigurationValues.ROBOT_VERSION_CONFIG) Then
                            AVPLib.Log.coreLogger.Error("Key " + key + INVALID_MESSAGE + "1".ToString())
                            RobotConfigurationValues.ROBOT_VERSION_CONFIG = 7.0
                        End If
                    Case "ROR_Litter"
                        If Not Double.TryParse(nodechild.InnerText, objSystemModule.Litter_Value) Then
                            AVPLib.Log.coreLogger.Error("Key " + key + INVALID_MESSAGE + "1".ToString())
                            objSystemModule.Litter_Value = 0
                        End If
                    Case ConstEnum.IonGaugeEmissionCurrent
                        If Not Double.TryParse(nodechild.InnerText, objSystemModule.IonGaugeEmissionCurrent) Then
                            AVPLib.Log.coreLogger.Error("Key " + key + INVALID_MESSAGE + "1".ToString())
                            objSystemModule.IonGaugeEmissionCurrent = 1.0
                        End If
                    Case ConstEnum.IonGaugeFirmwareModel
                        If Not Double.TryParse(nodechild.InnerText, objSystemModule.IonGaugeFirmwareModel) Then
                            AVPLib.Log.coreLogger.Error("Key " + key + INVALID_MESSAGE + "1".ToString())
                            objSystemModule.IonGaugeFirmwareModel = 1.0
                        End If
                    Case ConstEnum.IonGaugeType
                        If (Not String.IsNullOrEmpty(nodechild.InnerText)) Then
                            objSystemModule.IonGaugeType = nodechild.InnerText
                        End If
                    Case ConstEnum.Filament
                        If Not Double.TryParse(nodechild.InnerText, objSystemModule.Filament) Then
                            AVPLib.Log.coreLogger.Error("Key " + key + INVALID_MESSAGE + "1".ToString())
                            objSystemModule.Filament = 1.0
                        End If
                    Case "Aligner_At_Station"
                        If Not Integer.TryParse(nodechild.InnerText, RobotConfigurationValues.ALIGNER_AT_STATION) Then
                            AVPLib.Log.coreLogger.Error("Key " + key + INVALID_MESSAGE + "1".ToString())
                            RobotConfigurationValues.ALIGNER_AT_STATION = 1
                        End If
                        ''if Aligner At Station is not at LLA -> reset to LLA
                        If Not RobotConfigurationValues.ALINER_VISIBLE Then
                            RobotConfigurationValues.ALIGNER_AT_STATION = 0
                        ElseIf Not (RobotConfigurationValues.ALIGNER_AT_STATION = 1) Then
                            RobotConfigurationValues.ALIGNER_AT_STATION = 1
                        End If
                    Case "PacketMode"
                        If nodechild.InnerText = Boolean.FalseString Then
                            RobotConfigurationValues.ALIGNER_AT_PACKET_MODE = False
                        Else
                            RobotConfigurationValues.ALIGNER_AT_PACKET_MODE = True
                        End If
                    Case "SensorPositionAtDegree"
                        Dim iAngle As Integer = 0
                        If Not Integer.TryParse(nodechild.InnerText, iAngle) Then
                            RobotConfigurationValues.ALIGNER_SENSOR_POSITION_AT_DEGREE = 90
                        Else
                            If (iAngle <> 0) AndAlso (iAngle <> 90) AndAlso (iAngle <> 180) AndAlso (iAngle <> 270) Then
                                RobotConfigurationValues.ALIGNER_SENSOR_POSITION_AT_DEGREE = 90
                            Else
                                RobotConfigurationValues.ALIGNER_SENSOR_POSITION_AT_DEGREE = iAngle
                            End If
                        End If
                    Case "WaferSize"
                        Dim iWaferSize As Integer = 6
                        If Integer.TryParse(nodechild.InnerText, iWaferSize) Then
                            RobotConfigurationValues.WAFER_SIZE = iWaferSize
                        End If
                    Case "ActiveCCD"
                        Dim iActiveCCD As Integer = 1
                        If Integer.TryParse(nodechild.InnerText, iActiveCCD) Then
                            RobotConfigurationValues.ACTIVE_CCD = iActiveCCD
                        End If
                    Case "WaferType"
                        If (Not String.IsNullOrEmpty(nodechild.InnerText)) Then
                            RobotConfigurationValues.WAFER_TYPE = nodechild.InnerText
                        End If
                    Case "RunDataFileFormat"
                        If (Not String.IsNullOrEmpty(nodechild.InnerText)) Then
                            RobotConfigurationValues.RUN_DATA_FILE_FORMAT = nodechild.InnerText
                        End If
                    Case "SubSystemList"

                        Dim subsysNodelist As Xml.XmlNodeList = nodechild.ChildNodes
                        Dim ConfigHashTable As Hashtable = New Hashtable()
                        Dim LoadPMConfigSuccess As Boolean = ReadServerConfiguration_FromPMConfig(objSystemModule, key, xDoc, ConfigHashTable)

                        For Each item As Xml.XmlNode In subsysNodelist
                            Dim strSubSystemName As String = item.ChildNodes.Item(0).InnerText
                            Dim strSubSystemValue As String = item.ChildNodes.Item(1).InnerText
                            Select Case strSubSystemName
                                'Case PM_TAG_CONFIG.NumberOfSlot.ToString()
                                '    If Integer.TryParse(strSubSystemValue, objSystemModule.MaxNumberOfSlot) = False Then
                                '        objSystemModule.MaxNumberOfSlot = 1
                                '    End If
                                Case PM_TAG_CONFIG.Grid_SerialNumber.ToString()
                                    objSystemModule.Grid_SerialNumber = strSubSystemValue
                                Case PM_TAG_CONFIG.Grid_ID.ToString()
                                    objSystemModule.Grid_ID = strSubSystemValue
                                Case PM_TAG_CONFIG.Grid_RebuildLevel.ToString()
                                    If Not Integer.TryParse(strSubSystemValue, objSystemModule.Grid_RebuildLevel) Then
                                        objSystemModule.Grid_RebuildLevel = 0
                                    End If
                                Case PM_TAG_CONFIG.Etch_Rate.ToString()
                                    If Double.TryParse(strSubSystemValue, objSystemModule.Etch_Rate) = False Then
                                        objSystemModule.Etch_Rate = 1
                                    End If
                                Case PM_TAG_CONFIG.SL_AutoLoad_Unload_DelayTime.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.SL_AutoLoad_Unload_Delay_Time) Then
                                        objSystemModule.SL_AutoLoad_Unload_Delay_Time = ConstEnum.SL_AUTO_LOAD_DELAY_TIME
                                    End If
                                Case PM_TAG_CONFIG.Max_KWH_SourceUsage.ToString()
                                    If Double.TryParse(strSubSystemValue, objSystemModule.Max_KWH_Source) = False Then
                                        objSystemModule.Max_KWH_Source = 0
                                    End If
                                    '2013-10-07 Tin Pham Added---------------------------------------------------
                                Case PM_TAG_CONFIG.Max_KWH_SourceUsage1.ToString()
                                    If Double.TryParse(strSubSystemValue, objSystemModule.Max_KWH_Source1) = False Then
                                        objSystemModule.Max_KWH_Source1 = 0
                                    End If
                                Case PM_TAG_CONFIG.Max_KWH_SourceUsage2.ToString()
                                    If Double.TryParse(strSubSystemValue, objSystemModule.Max_KWH_Source2) = False Then
                                        objSystemModule.Max_KWH_Source2 = 0
                                    End If
                                Case PM_TAG_CONFIG.Max_KWH_SourceUsage3.ToString()
                                    If Double.TryParse(strSubSystemValue, objSystemModule.Max_KWH_Source3) = False Then
                                        objSystemModule.Max_KWH_Source3 = 0
                                    End If
                                Case PM_TAG_CONFIG.Max_KWH_SourceUsage4.ToString()
                                    If Double.TryParse(strSubSystemValue, objSystemModule.Max_KWH_Source4) = False Then
                                        objSystemModule.Max_KWH_Source4 = 0
                                    End If
                                    '----------------------------------------------------------------------------
                                Case PM_TAG_CONFIG.PVD_Chuck_At_PumpDown_Postion.ToString()
                                    If Not Single.TryParse(strSubSystemValue, objSystemModule.PVD_Chuck_At_PumpDown_Postion) Then
                                        objSystemModule.PVD_Chuck_At_PumpDown_Postion = 1.4
                                    End If
                                    'get device net
                                Case PM_TAG_CONFIG.PM_DeviceNet.ToString()
                                    objSystemModule.PM_DeviceNet = IIf(strSubSystemValue = "1", True, False)
                                    'get real device
                                Case PM_TAG_CONFIG.Real_Device_Enable.ToString()
                                    objSystemModule.Real_Device_Enable = IIf(strSubSystemValue = "1", True, False)
                                    'get cryo, waterpump installed
                                Case PM_TAG_CONFIG.SL_ATM_Pressure.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.SL_ATM_Pressure) Then
                                        objSystemModule.SL_ATM_Pressure = ConstEnum.DOUBLE_CG_ATM
                                    End If
                                Case PM_TAG_CONFIG.SL_VAC_CG_Pressure.ToString()
                                    If Not (Double.TryParse(strSubSystemValue, objSystemModule.SL_VAC_CG_Pressure)) Then
                                        objSystemModule.SL_VAC_CG_Pressure = ConstEnum.DOUBLE_IG_VACUUM
                                    End If
                                    '#03/09/2011 
                                    '#0001335: [SL_RFE_EndUser_Mar 1 ,2011]Source usage warning/and limit before and during process run. 
                                    '#Begin fix:

                                Case PM_TAG_CONFIG.SourceUsage.ToString()
                                    Double.TryParse(strSubSystemValue, objSystemModule.SourceUsageTime)
                                    '2013-01-10 Tin Pham added ------------------
                                Case PM_TAG_CONFIG.TargetKWHAlarmLimit.ToString()
                                    If objSystemModule.Type = ModuleType.PVD4 OrElse objSystemModule.Type = ModuleType.PVD5T Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.Alarm_KWH)
                                    End If
                                Case PM_TAG_CONFIG.TargetKWHAlarmLimit1.ToString()
                                    If objSystemModule.Type = ModuleType.PVD4 OrElse objSystemModule.Type = ModuleType.PVD5T Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.Alarm_KWH1)
                                    End If
                                Case PM_TAG_CONFIG.TargetKWHAlarmLimit2.ToString()
                                    If objSystemModule.Type = ModuleType.PVD4 OrElse objSystemModule.Type = ModuleType.PVD5T Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.Alarm_KWH2)
                                    End If
                                Case PM_TAG_CONFIG.TargetKWHAlarmLimit3.ToString()
                                    If objSystemModule.Type = ModuleType.PVD4 OrElse objSystemModule.Type = ModuleType.PVD5T Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.Alarm_KWH3)
                                    End If
                                Case PM_TAG_CONFIG.TargetKWHAlarmLimit4.ToString()
                                    If objSystemModule.Type = ModuleType.PVD4 OrElse objSystemModule.Type = ModuleType.PVD5T Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.Alarm_KWH4)
                                    End If
                                Case PM_TAG_CONFIG.TargetKWHWarningLimit.ToString()
                                    If objSystemModule.Type = ModuleType.PVD4 OrElse objSystemModule.Type = ModuleType.PVD5T Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.Warning_KWH)
                                    End If
                                Case PM_TAG_CONFIG.TargetKWHWarningLimit1.ToString()
                                    If objSystemModule.Type = ModuleType.PVD4 OrElse objSystemModule.Type = ModuleType.PVD5T Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.Warning_KWH1)
                                    End If
                                Case PM_TAG_CONFIG.TargetKWHWarningLimit2.ToString()
                                    If objSystemModule.Type = ModuleType.PVD4 OrElse objSystemModule.Type = ModuleType.PVD5T Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.Warning_KWH2)
                                    End If
                                Case PM_TAG_CONFIG.TargetKWHWarningLimit3.ToString()
                                    If objSystemModule.Type = ModuleType.PVD4 OrElse objSystemModule.Type = ModuleType.PVD5T Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.Warning_KWH3)
                                    End If
                                Case PM_TAG_CONFIG.TargetKWHWarningLimit4.ToString()
                                    If objSystemModule.Type = ModuleType.PVD4 OrElse objSystemModule.Type = ModuleType.PVD5T Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.Warning_KWH4)
                                    End If
                                    '---------------------------------------------
                                Case PM_TAG_CONFIG.SourceUsageWarning.ToString()
                                    If LoadPMConfigSuccess = False Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.SourceUsageTimeWarning)
                                    End If
                                Case PM_TAG_CONFIG.SourceUsageLimit.ToString()
                                    If LoadPMConfigSuccess = False Then
                                        Double.TryParse(strSubSystemValue, objSystemModule.SourceUsageTimeLimit)
                                    End If
                                    '#End fix.

                                    ''' Shields/Quartz
                                Case PM_TAG_CONFIG.Max_KWH_ShieldsQuartz.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.Max_KWH_ShieldsQuartz) Then
                                        objSystemModule.Max_KWH_ShieldsQuartz = 0
                                    End If
                                Case PM_TAG_CONFIG.ShieldsQuartzWarning.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.ShieldsQuartzWarning) Then
                                        objSystemModule.ShieldsQuartzWarning = 22000
                                    End If
                                Case PM_TAG_CONFIG.ShieldsQuartzLimit.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.ShieldsQuartzLimit) Then
                                        objSystemModule.ShieldsQuartzLimit = 25000
                                    End If
                                Case PM_TAG_CONFIG.Max_KWH_ShieldsQuartz1.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.Max_KWH_ShieldsQuartz1) Then
                                        objSystemModule.Max_KWH_ShieldsQuartz1 = 0
                                    End If
                                Case PM_TAG_CONFIG.ShieldsQuartzWarning1.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.ShieldsQuartzWarning1) Then
                                        objSystemModule.ShieldsQuartzWarning1 = 22000
                                    End If
                                Case PM_TAG_CONFIG.ShieldsQuartzLimit1.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.ShieldsQuartzLimit1) Then
                                        objSystemModule.ShieldsQuartzLimit1 = 25000
                                    End If
                                Case PM_TAG_CONFIG.Max_KWH_ShieldsQuartz2.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.Max_KWH_ShieldsQuartz2) Then
                                        objSystemModule.Max_KWH_ShieldsQuartz2 = 0
                                    End If
                                Case PM_TAG_CONFIG.ShieldsQuartzWarning2.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.ShieldsQuartzWarning2) Then
                                        objSystemModule.ShieldsQuartzWarning2 = 22000
                                    End If
                                Case PM_TAG_CONFIG.ShieldsQuartzLimit2.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.ShieldsQuartzLimit2) Then
                                        objSystemModule.ShieldsQuartzLimit2 = 25000
                                    End If
                                Case PM_TAG_CONFIG.Max_KWH_ShieldsQuartz3.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.Max_KWH_ShieldsQuartz3) Then
                                        objSystemModule.Max_KWH_ShieldsQuartz3 = 0
                                    End If
                                Case PM_TAG_CONFIG.ShieldsQuartzWarning3.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.ShieldsQuartzWarning3) Then
                                        objSystemModule.ShieldsQuartzWarning3 = 22000
                                    End If
                                Case PM_TAG_CONFIG.ShieldsQuartzLimit3.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.ShieldsQuartzLimit3) Then
                                        objSystemModule.ShieldsQuartzLimit3 = 25000
                                    End If
                                Case PM_TAG_CONFIG.Max_KWH_ShieldsQuartz4.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.Max_KWH_ShieldsQuartz4) Then
                                        objSystemModule.Max_KWH_ShieldsQuartz4 = 0
                                    End If
                                Case PM_TAG_CONFIG.ShieldsQuartzWarning4.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.ShieldsQuartzWarning4) Then
                                        objSystemModule.ShieldsQuartzWarning4 = 22000
                                    End If
                                Case PM_TAG_CONFIG.ShieldsQuartzLimit4.ToString()
                                    If Not Double.TryParse(strSubSystemValue, objSystemModule.ShieldsQuartzLimit4) Then
                                        objSystemModule.ShieldsQuartzLimit4 = 25000
                                    End If
                                    '''End -----------

                                Case PM_TAG_CONFIG.IdleThreshold.ToString()
                                    Double.TryParse(strSubSystemValue, objSystemModule.IdleThreshold)
                                Case PM_TAG_CONFIG.WarmUpRecipe.ToString()
                                    objSystemModule.WarmUpRecipe = strSubSystemValue
                                Case PM_TAG_CONFIG.LastExecution.ToString()
                                    If Not Date.TryParse(strSubSystemValue, objSystemModule.LastExecution) Then
                                        objSystemModule.LastExecution = #1/1/1990 1:00:00 AM#
                                    End If

                                Case PM_TAG_CONFIG.UseLotSystemID.ToString()
                                    objSystemModule.UseLotSystemID = IIf(strSubSystemValue = "1", True, False)
                                Case PM_TAG_CONFIG.LoggingInterval.ToString()
                                    Integer.TryParse(strSubSystemValue, objSystemModule.LoggingInterval)
                                Case PM_TAG_CONFIG.UseSystemWarmUp.ToString()
                                    objSystemModule.UseSystemWarmUp = IIf(strSubSystemValue = "1", True, False)

                                Case PM_TAG_CONFIG.Target_Material.ToString()
                                    objSystemModule.Target_Material = strSubSystemValue
                                    ConfigHashTable.Add(PM_TAG_CONFIG.Target_Material.ToString(), strSubSystemValue)
                                    '2013-01-18 Tin Pham added
                                Case PM_TAG_CONFIG.Target_Material1.ToString()
                                    objSystemModule.Target_Material1 = strSubSystemValue
                                    ConfigHashTable.Add(PM_TAG_CONFIG.Target_Material1.ToString(), strSubSystemValue)
                                Case PM_TAG_CONFIG.Target_Material2.ToString()
                                    objSystemModule.Target_Material2 = strSubSystemValue
                                    ConfigHashTable.Add(PM_TAG_CONFIG.Target_Material2.ToString(), strSubSystemValue)
                                Case PM_TAG_CONFIG.Target_Material3.ToString()
                                    objSystemModule.Target_Material3 = strSubSystemValue
                                    ConfigHashTable.Add(PM_TAG_CONFIG.Target_Material3.ToString(), strSubSystemValue)
                                Case PM_TAG_CONFIG.Target_Material4.ToString()
                                    objSystemModule.Target_Material4 = strSubSystemValue
                                    ConfigHashTable.Add(PM_TAG_CONFIG.Target_Material4.ToString(), strSubSystemValue)
                                    '-------------------------
                                Case PM_TAG_CONFIG.ROR_Litter.ToString()
                                Case PM_TAG_CONFIG.Clamp_Installed.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.Clamp_Installed.ToString(), _
                                                            strSubSystemValue, objSystemModule.ClampInstalled, LoadPMConfigSuccess)

                                Case PM_TAG_CONFIG.Shutter_Visible.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.Shutter_Visible.ToString(), _
                                                           strSubSystemValue, objSystemModule.ShutterVisible, LoadPMConfigSuccess)

                                Case PM_TAG_CONFIG.MG.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.MG.ToString(), _
                                                            strSubSystemValue, objSystemModule.MGVisible, False)

                                Case PM_TAG_CONFIG.CG.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.CG.ToString(), _
                                                            strSubSystemValue, objSystemModule.CGVisible, False)

                                Case PM_TAG_CONFIG.DCTargetPowerSupply.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.DCTargetPowerSupply.ToString(), strSubSystemValue, _
                                                            objSystemModule.DCTargetPowerVisible, LoadPMConfigSuccess)

                                Case PM_TAG_CONFIG.RFTargetPowerSupply.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.RFTargetPowerSupply.ToString(), strSubSystemValue, _
                                                            objSystemModule.RFTargetPowerVisible, LoadPMConfigSuccess)
                                    If item.LastChild.Name = "SysVal" Then
                                        ReadPresetConfig(item.LastChild, objSystemModule.TargetPresetValue, False)
                                    End If

                                Case PM_TAG_CONFIG.BiasPowerSupply.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.BiasPowerSupply.ToString(), strSubSystemValue, _
                                                            objSystemModule.BiasPowerVisible, False)
                                    If item.LastChild.Name = "SysVal" Then
                                        ReadPresetConfig(item.LastChild, objSystemModule.BiasPresetValue, False)
                                    End If
                                Case PM_TAG_CONFIG.IBESourceValue.ToString()
                                    If item.LastChild.Name = "SysVal" Then
                                        ReadIBESourceValue(item.LastChild, objSystemModule.IBESourceValue)
                                    End If
                                Case PM_TAG_CONFIG.ParallelMagnet.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.ParallelMagnet.ToString(), strSubSystemValue, _
                                                            objSystemModule.ParallelMagnetVisible, LoadPMConfigSuccess)

                                Case PM_TAG_CONFIG.ChamberInterlock.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.ChamberLid_Installed.ToString(), _
                                                item.SelectNodes(PM_TAG_CONFIG.ChamberLid_Installed.ToString()).Item(0).InnerText, _
                                                objSystemModule.ChamberInterlock_LidSensorVisible, LoadPMConfigSuccess)
                                    SetSystemModuleProperty(PM_TAG_CONFIG.LidWater_Installed.ToString(), _
                                    item.SelectNodes(PM_TAG_CONFIG.LidWater_Installed.ToString()).Item(0).InnerText, _
                                    objSystemModule.ChamberInterlock_LidWaterVisible, LoadPMConfigSuccess)

                                    SetSystemModuleProperty(PM_TAG_CONFIG.TargetWater_Installed.ToString(), _
                                                                                                item.SelectNodes(PM_TAG_CONFIG.TargetWater_Installed.ToString()).Item(0).InnerText, _
                                                                                                objSystemModule.ChamberInterlock_TargetWaterVisible, LoadPMConfigSuccess)
                                    SetSystemModuleProperty(PM_TAG_CONFIG.TurboForeline_Installed.ToString(), _
                                                                                                item.SelectNodes(PM_TAG_CONFIG.TurboForeline_Installed.ToString()).Item(0).InnerText, _
                                                                                                objSystemModule.ChamberInterlock_TurboForelineVisible, LoadPMConfigSuccess)
                                    SetSystemModuleProperty(PM_TAG_CONFIG.TurboWater_Installed.ToString(), _
                                                                                                item.SelectNodes(PM_TAG_CONFIG.TurboWater_Installed.ToString()).Item(0).InnerText, _
                                                                                                objSystemModule.ChamberInterlock_TurboWaterVisible, LoadPMConfigSuccess)
                                    ''
                                    If item.SelectNodes(PM_TAG_CONFIG.TargetMBWater_Installed.ToString()) IsNot Nothing AndAlso _
                                     item.SelectNodes(PM_TAG_CONFIG.TargetMBWater_Installed.ToString()).Item(0) IsNot Nothing Then
                                        SetSystemModuleProperty(PM_TAG_CONFIG.TargetMBWater_Installed.ToString(), _
                                                                item.SelectNodes(PM_TAG_CONFIG.TargetMBWater_Installed.ToString()).Item(0).InnerText, _
                                                                objSystemModule.ChamberInterlock_TargetMBWaterVisible, LoadPMConfigSuccess)
                                    End If
                                    If item.SelectNodes(PM_TAG_CONFIG.ClampWater_Installed.ToString()) IsNot Nothing AndAlso _
                                     item.SelectNodes(PM_TAG_CONFIG.ClampWater_Installed.ToString()).Item(0) IsNot Nothing Then
                                        SetSystemModuleProperty(PM_TAG_CONFIG.ClampWater_Installed.ToString(), _
                                                             item.SelectNodes(PM_TAG_CONFIG.ClampWater_Installed.ToString()).Item(0).InnerText, _
                                                             objSystemModule.ChamberInterlock_ClampWaterVisible, LoadPMConfigSuccess)
                                    End If
                                    If item.SelectNodes(PM_TAG_CONFIG.SubMBWater_Installed.ToString()) IsNot Nothing AndAlso _
                                      item.SelectNodes(PM_TAG_CONFIG.SubMBWater_Installed.ToString()).Item(0) IsNot Nothing Then
                                        SetSystemModuleProperty(PM_TAG_CONFIG.SubMBWater_Installed.ToString(), _
                                                        item.SelectNodes(PM_TAG_CONFIG.SubMBWater_Installed.ToString()).Item(0).InnerText, _
                                                        objSystemModule.ChamberInterlock_SubMBWaterVisible, LoadPMConfigSuccess)
                                    End If



                                Case PM_TAG_CONFIG.PumpingPackage.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.Cryo_Installed.ToString(), strSubSystemValue, _
                                                            objSystemModule.CryoVisible, LoadPMConfigSuccess)
                                    If item.ChildNodes.Item(2).Name = PM_TAG_CONFIG.TurboPump_Installed.ToString() Then
                                        SetSystemModuleProperty(PM_TAG_CONFIG.TurboPump_Installed.ToString(), item.ChildNodes.Item(2).InnerText, _
                                                                 objSystemModule.TurboPumpVisible, LoadPMConfigSuccess)
                                    End If
                                    If item.ChildNodes.Item(3).Name = PM_TAG_CONFIG.Water_Pump_Installed.ToString() Then
                                        SetSystemModuleProperty(PM_TAG_CONFIG.WaterPump_Installed.ToString(), item.ChildNodes.Item(3).InnerText, _
                                                                 objSystemModule.WaterPumpVisible, LoadPMConfigSuccess)
                                    End If
                                Case PM_TAG_CONFIG.VatValveController.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.VatValveController.ToString(), strSubSystemValue, _
                                                            objSystemModule.VatValveControllerVisible, LoadPMConfigSuccess)

                                Case PM_TAG_CONFIG.GasController.ToString()
                                    If Not LoadPMConfigSuccess Then
                                        If strSubSystemValue = DEVICE_VISIBLE Then
                                            Dim gasLineNode As Xml.XmlNodeList = item.ChildNodes.Item(2).ChildNodes
                                            CountGasLine(gasLineNode, objSystemModule, 0, objSystemModule.Gas1Name, _
                                                         objSystemModule.Gas1SupplyPresent, objSystemModule.Gas1ShutoffPresent)
                                            CountGasLine(gasLineNode, objSystemModule, 1, objSystemModule.Gas2Name, _
                                                         objSystemModule.Gas2SupplyPresent, objSystemModule.gas2ShutoffPresent)
                                            CountGasLine(gasLineNode, objSystemModule, 2, objSystemModule.Gas3Name, _
                                                         objSystemModule.Gas3SupplyPresent, objSystemModule.gas3ShutoffPresent)
                                            CountGasLine(gasLineNode, objSystemModule, 3, objSystemModule.Gas4Name, _
                                                         objSystemModule.Gas4SupplyPresent, objSystemModule.gas4ShutoffPresent)
                                            CountGasLine(gasLineNode, objSystemModule, 4, objSystemModule.Gas5Name, _
                                                         objSystemModule.Gas5SupplyPresent, objSystemModule.gas5ShutoffPresent)
                                        ElseIf Not strSubSystemValue = DEVICE_VISIBLE Then
                                            objSystemModule.Gas1Name = "Gas 1"
                                            AVPLib.Log.coreLogger.Error("Key GasController" + INVALID_MESSAGE + DEVICE_VISIBLE.ToString())
                                        End If
                                    End If
                                Case PM_TAG_CONFIG.Magnatron.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.Magnatron.ToString(), strSubSystemValue, _
                                                            objSystemModule.MagnatronVisible, LoadPMConfigSuccess)
                                Case PM_TAG_CONFIG.AutoZero.ToString()
                                    SetSystemModuleProperty(PM_TAG_CONFIG.AutoZero.ToString(), strSubSystemValue, _
                                                            objSystemModule.AutoZeroVatValveVisible, LoadPMConfigSuccess)
                            End Select
                        Next
                        Dim HRecipeConfig As New HRecipeLibrary.HRecipe(objSystemModule.Type.ToString(), ConfigHashTable)
                        ContainerData.AddHRecipeToList(key, HRecipeConfig)
                End Select
            Next

            Select Case key
                Case Equipments.Chamber1.ToString()
                    objSystemModule.StationLocation = SYSTEM_CONFIG_STATION_LOCATION_VALUES.PM1_STATION_LOCATION_INIT
                Case Equipments.Chamber2.ToString()
                    objSystemModule.StationLocation = SYSTEM_CONFIG_STATION_LOCATION_VALUES.PM2_STATION_LOCATION_INIT
                Case Equipments.Chamber3.ToString()
                    objSystemModule.StationLocation = SYSTEM_CONFIG_STATION_LOCATION_VALUES.PM3_STATION_LOCATION_INIT
                Case Equipments.LoadLockA.ToString()
                    objSystemModule.StationLocation = SYSTEM_CONFIG_STATION_LOCATION_VALUES.LLA_STATION_LOCATION_INIT
                Case Equipments.Aligner.ToString()
                    objSystemModule.StationLocation = SYSTEM_CONFIG_STATION_LOCATION_VALUES.ALIGNER_STATION_LOCATION_INIT
                Case Equipments.Robot.ToString()
                    objSystemModule.StationLocation = SYSTEM_CONFIG_STATION_LOCATION_VALUES.ROBOT_STATION_LOCATION_INIT
            End Select
            map.Add(key, objSystemModule)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave ReadModuleNode")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Read PVD Configuration and save back to local AVP Config
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Function ReadServerConfiguration_FromPMConfig(ByRef objSystemModule As SystemModule, _
                                                                  ByVal ServerName As String, ByVal xDoc As Xml.XmlDocument, ByVal ConfigHashTable As Hashtable) As Boolean
        AVPLib.Log.coreLogger.Info("Enter ReadServerConfiguration_Visible")
        Try
            Dim PMConfigDoc As New Xml.XmlDocument
            If objSystemModule.Name = Equipments.LoadLockA.ToString() Then
                ServerName = Equipments.LLAElevator.ToString()
            End If

            Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ServerName)
            Dim strPMConfigFilePath As String = serverConfig.ConfigFolder
            Dim strPMConfigFilePathOnFE As String = ContainerDAO.FPath_PMConfigFiles & "\" & ServerName

            If serverConfig Is Nothing Then
                'AVPLib.Log.avpLogger.Error(ServerName + " is not installed or ConfigurationServer is not correct!")
                Return False
            ElseIf serverConfig.IsInstalled Then
                ''IBE
                If serverConfig.Type = ConstEnum.IBEType.AVP_IBE.ToString() Then ''read IBE config
                    strPMConfigFilePath &= "\" & ContainerDAO.FIBEConfigName
                    strPMConfigFilePathOnFE &= "\" & ContainerDAO.FIBEConfigName
                ElseIf serverConfig.Type = ConstEnum.IBEType.VEECO_IBE.ToString() Then
                    'TODO: PMConfigDoc???
                    Return False
                    ''PVD4
                ElseIf serverConfig.Type = ConstEnum.PVD4.ToString() Then
                    strPMConfigFilePath &= "\" & ContainerDAO.FCORONAConfigName
                    strPMConfigFilePathOnFE &= "\" & ContainerDAO.FCORONAConfigName
                    ''PVD5T
                ElseIf serverConfig.Type = ConstEnum.PVD5T.ToString() Then
                    strPMConfigFilePath &= "\" & ContainerDAO.PVD5TConfigName
                    strPMConfigFilePathOnFE &= "\" & ContainerDAO.PVD5TConfigName
                Else ''PM is PVD
                    strPMConfigFilePath &= "\" & ContainerDAO.FPVDConfigName
                    strPMConfigFilePathOnFE &= "\" & ContainerDAO.FPVDConfigName
                End If

                PMConfigDoc = BinarySerialize.Open_DatFileConfig(strPMConfigFilePath)

                If PMConfigDoc Is Nothing Then
                    PMConfigDoc = BinarySerialize.Open_DatFileConfig(strPMConfigFilePathOnFE)

                    If PMConfigDoc Is Nothing Then
                        lstPM.Add(objSystemModule.Name)
                        AVPLib.Log.avpLogger.Error("Can not access PM Config File - " & serverConfig.ConfigFolder & "\" & ContainerDAO.FPVDConfigName)
                        Return False
                    End If
                Else
                    If Not Utils.CopyFile(strPMConfigFilePath, strPMConfigFilePathOnFE) Then
                        AVPLib.Log.avpLogger.Error(String.Format("Failed to copy PM config file from {0} to {1}", strPMConfigFilePath, strPMConfigFilePathOnFE))
                    End If
                End If

                objSystemModule.IsVisible = serverConfig.IsInstalled
            Else
                AVPLib.Log.avpLogger.Error(ServerName + " is not installed!")
                Return False
            End If

            Dim listCalFactor As Hashtable = GetCalFactConfig(serverConfig.ConfigFolder & "\" & ContainerDAO.FCalFactFile)
            If listCalFactor Is Nothing Then
                listCalFactor = GetCalFactConfig()
                AVPLib.Log.avpLogger.Error("Can not access PM CalFact File - " & serverConfig.ConfigFolder & "\" & ContainerDAO.FCalFactFile)
            End If

            Dim selectedNode As Xml.XmlNode = Nothing
            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/" & _
                                                          PM_TAG_CONFIG.PP_PumpDownAfterCycleComplete.ToString())
            If selectedNode IsNot Nothing Then
                objSystemModule.PumpPurge = IIf(selectedNode.InnerText = "1", True, False)
            End If

            ''Alarm KWH--->PVD
            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/TargetKWHAlarmLimit")
            If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                ''this value is read only -> don't save to AVP config, if fail in loading -> value is 0
                Double.TryParse(selectedNode.InnerText, objSystemModule.Alarm_KWH)
            End If
            ''Alarm Source Usage--->IBE
            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/SourceUsageAlarmLimit")
            If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                ''this value is read only -> don't save to AVP config, if fail in loading -> value is 0
                Double.TryParse(selectedNode.InnerText, objSystemModule.SourceUsageTimeLimit)
            End If

            ''Warning KWH--->PVD
            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/TargetKWHWarningLimit")
            If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                ''this value is read only -> don't save to AVP config, if fail in loading -> value is 0
                Double.TryParse(selectedNode.InnerText, objSystemModule.Warning_KWH)
            End If
            ''Warning Source Usage-->IBE
            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/SourceUsageWarningLimit")
            If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                ''this value is read only -> don't save to AVP config, if fail in loading -> value is 0
                Double.TryParse(selectedNode.InnerText, objSystemModule.SourceUsageTimeWarning)
            End If

            ''Target To Home Distance-->PVD4
            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/TargetToHomeDistance")
            If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                ''this value is read only -> don't save to AVP config, if fail in loading -> value is 0
                Double.TryParse(selectedNode.InnerText, objSystemModule.TargetToHomeDistance)
                'LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_TABLE_POS_RIGHT_MAX, selectedNode.InnerText, xDoc)
            End If

            ''Chuck Minimum Distance In TSDMode-->PVD4
            'selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/ChuckMinimumDistanceInTSDMode")
            'If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
            '    LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_TABLE_POS_RIGHT_MIN, selectedNode.InnerText, xDoc)
            'End If

            ''IBE System Interlock Gas Minimum
            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/SystemInterlockGas1Minimum")
            If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                ''this value is read only -> don't save to AVP config, if fail in loading -> value is 0
                Double.TryParse(selectedNode.InnerText, objSystemModule.SystemInterlockGas1Minimum)
            End If
            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/SystemInterlockGas2Minimum")
            If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                ''this value is read only -> don't save to AVP config, if fail in loading -> value is 0
                Double.TryParse(selectedNode.InnerText, objSystemModule.SystemInterlockGas2Minimum)
            End If
            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/SystemInterlockGas3Minimum")
            If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                ''this value is read only -> don't save to AVP config, if fail in loading -> value is 0
                Double.TryParse(selectedNode.InnerText, objSystemModule.SystemInterlockGas3Minimum)
            End If
            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/SystemInterlockGas4Minimum")
            If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                ''this value is read only -> don't save to AVP config, if fail in loading -> value is 0
                Double.TryParse(selectedNode.InnerText, objSystemModule.SystemInterlockGas4Minimum)
            End If

            selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/SystemConfig")
            Dim strParallelMagnetType As String = String.Empty
            ''read PVD Config
            For Each xmlnode As Xml.XmlNode In selectedNode.ChildNodes
                Select Case xmlnode.Name
                    Case PM_TAG_CONFIG.NumberOfSlot.ToString
                        Integer.TryParse(xmlnode.InnerText, objSystemModule.MaxNumberOfSlot)
                        ConfigHashTable.Add(PM_TAG_CONFIG.NumberOfSlot.ToString(), objSystemModule.MaxNumberOfSlot.ToString())
                        LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_STATIC_POSITION_SP, objSystemModule.MaxNumberOfSlot, xDoc)
                    Case PM_TAG_CONFIG.IsDeviceNetSystem.ToString()
                        objSystemModule.PM_DeviceNet = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.ROR_Litter.ToString()
                        If Double.TryParse(xmlnode.InnerText, objSystemModule.Litter_Value) = False Then
                            objSystemModule.Litter_Value = 0
                        End If
                    Case PM_TAG_CONFIG.Clamp_Installed.ToString()
                        objSystemModule.ClampInstalled = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.ANC_Installed.ToString()
                        objSystemModule.ANCInstalled = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.ANC_Installed.ToString(), objSystemModule.ANCInstalled.ToString())
                    Case PM_TAG_CONFIG.Main_Gas_ShutOff_Valve_Installed.ToString()
                        objSystemModule.Main_Gas_Valve_Installed = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Water_Valve_Installed.ToString()
                        objSystemModule.WaterValveInstalled = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Internal_Shutter_Sensor_Installed.ToString()
                        objSystemModule.InternalShutterInstalled = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.DiverterGasValveInstalled.ToString()
                        objSystemModule.DiverterGasValveVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If ContainerDAO.Enable_ANYIBE_Mode AndAlso serverConfig.Type = IBEType.AVP_IBE AndAlso objSystemModule.DiverterGasValveVisible Then
                            RobotConfigurationValues.AnyIBE_DiverterValve_Installed = True
                        End If
                        ConfigHashTable.Add(PM_TAG_CONFIG.DiverterGasValveInstalled.ToString(), objSystemModule.DiverterGasValveVisible.ToString())
                    Case PM_TAG_CONFIG.Cryo_Installed.ToString()
                        objSystemModule.CryoVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Cryo_Installed.ToString(), objSystemModule.CryoVisible.ToString())
                    Case PM_TAG_CONFIG.Turbo_Installed.ToString()
                        objSystemModule.TurboPumpVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Turbo_Installed.ToString(), objSystemModule.TurboPumpVisible.ToString())
                        If xmlnode.Attributes("WhichModel") IsNot Nothing Then
                            Dim strModel As String = xmlnode.Attributes("WhichModel").Value
                            If Not String.IsNullOrEmpty(strModel) Then
                                objSystemModule.TurboPumpModel = CType([Enum].Parse(GetType(TurboPump_Model), strModel), TurboPump_Model)
                            End If
                        End If
                        '2013-01-02 Tin Pham added
                    Case PM_TAG_CONFIG.Target1_Installed.ToString()
                        objSystemModule.TargetVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Target1_Installed.ToString(), objSystemModule.TargetVisible.ToString())
                    Case PM_TAG_CONFIG.Target2_Installed.ToString()
                        objSystemModule.Target2Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Target2_Installed.ToString(), objSystemModule.Target2Visible.ToString())
                    Case PM_TAG_CONFIG.Target3_Installed.ToString()
                        objSystemModule.Target3Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Target3_Installed.ToString(), objSystemModule.Target3Visible.ToString())
                    Case PM_TAG_CONFIG.Target4_Installed.ToString()
                        objSystemModule.Target4Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Target4_Installed.ToString(), objSystemModule.Target4Visible.ToString())
                    Case PM_TAG_CONFIG.Target5_Installed.ToString()
                        objSystemModule.Target5Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Target5_Installed.ToString(), objSystemModule.Target5Visible.ToString())
                        '-------------------------
                        ''2013-03-05
                    Case PM_TAG_CONFIG.Shutter1_Installed.ToString()
                        objSystemModule.ShutterVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Shutter2_Installed.ToString()
                        objSystemModule.Shutter2Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Shutter3_Installed.ToString()
                        objSystemModule.Shutter3Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Shutter4_Installed.ToString()
                        objSystemModule.Shutter4Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Shutter5_Installed.ToString()
                        objSystemModule.Shutter5Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Chiller_Installed.ToString()
                        objSystemModule.ChillerVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Chiller_Installed.ToString(), objSystemModule.ChillerVisible.ToString())
                        If xmlnode.InnerText = Boolean.TrueString Then
                            If xmlnode.Attributes("WhichModel") IsNot Nothing Then
                                objSystemModule.ChillerModel = CType(xmlnode.Attributes("WhichModel").Value.ToString(), String)
                            End If
                        End If
                    Case PM_TAG_CONFIG.Endpoint_Unit_Installed.ToString()
                        objSystemModule.EndPointUnitVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If ContainerDAO.Enable_ANYIBE_Mode AndAlso serverConfig.Type = IBEType.AVP_IBE AndAlso objSystemModule.EndPointUnitVisible Then
                            RobotConfigurationValues.AnyIBE_EP_Installed = True
                        End If
                    Case PM_TAG_CONFIG.FlowCool_Installed.ToString()
                        If objSystemModule.Type = ModuleType.IBE Then
                            objSystemModule.MGVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                            If objSystemModule.Type = ModuleType.IBE Then
                                objSystemModule.FlowcoolGasInstall = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                                If xmlnode.InnerText = Boolean.TrueString Then
                                    objSystemModule.FlowcoolGasName = xmlnode.Attributes("Name").Value.ToString()
                                    objSystemModule.FlowcoolGasType = xmlnode.Attributes("CalibrationFactorId").Value.ToString()
                                    ConfigHashTable.Add(PM_TAG_CONFIG.FlowCool_Installed.ToString() & "_CalibrationFactorId", objSystemModule.FlowcoolGasType.ToString())
                                    ConfigHashTable.Add(PM_TAG_CONFIG.FlowCool_Installed.ToString() & "_Name", objSystemModule.FlowcoolGasName.ToString())

                                    objSystemModule.FlowcoolGasSupplyPresent = CType(xmlnode.Attributes("HasSupplyValve").Value.ToString(), Boolean)
                                    ConfigHashTable.Add(PM_TAG_CONFIG.FlowCoolGasEnable.ToString() & "_HasSupplyValve", objSystemModule.FlowcoolGasSupplyPresent.ToString())
                                    objSystemModule.FlowcoolGasShutoffPresent = CType(xmlnode.Attributes("HasShutOffValve").Value.ToString(), Boolean)
                                    ConfigHashTable.Add(PM_TAG_CONFIG.FlowCoolGasEnable.ToString() & "_HasShutOffValve", objSystemModule.FlowcoolGasSupplyPresent.ToString())
                                Else
                                    objSystemModule.FlowcoolGasName = String.Empty
                                    objSystemModule.FlowcoolGasType = String.Empty
                                End If

                                '#08/02/2011 
                                '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                                '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                                '# If any param that does not have min/max, we will have to add it's min/max.
                                '#Begin fix:
                                Dim strMaxSP As String = xmlnode.Attributes(STR_RANGEVALUE_TAG).Value
                                strMaxSP = ConvertValueWithCalFactor(strMaxSP, objSystemModule.FlowcoolGasType, listCalFactor)
                                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_FLOWCOOL_GAS_MAX_SP, strMaxSP, xDoc)
                                '#End fix.
                            End If
                        End If

                        '<Get interlock config>
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.ChamberLid_Installed.ToString()
                        objSystemModule.ChamberInterlock_LidSensorVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.LidWater_Installed.ToString()
                        objSystemModule.ChamberInterlock_LidWaterVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.TargetWater_Installed.ToString()
                        objSystemModule.ChamberInterlock_TargetWaterVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.TurboForeline_Installed.ToString()
                        objSystemModule.ChamberInterlock_TurboForelineVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.TurboWater_Installed.ToString()
                        objSystemModule.ChamberInterlock_TurboWaterVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.TargetMBWater_Installed.ToString()
                        objSystemModule.ChamberInterlock_TargetMBWaterVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.ClampWater_Installed.ToString()
                        objSystemModule.ChamberInterlock_ClampWaterVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.SubMBWater_Installed.ToString()
                        objSystemModule.ChamberInterlock_SubMBWaterVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)

                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.Target_Matchbox_Water_Installed.ToString()
                        objSystemModule.Target_Matchbox_Water_Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.Bias_Matchbox_Water_Installed.ToString()
                        objSystemModule.Bias_Matchbox_Water_Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.Target13Water_Installed.ToString()
                        objSystemModule.Interlock_Target13Water_Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.Target24Water_Installed.ToString()
                        objSystemModule.Interlock_Target24Water_Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.SubstrateTableWater_Installed.ToString()
                        objSystemModule.Interlock_SubstrateTableWater_Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.FixtureWaterBug_Installed.ToString()
                        objSystemModule.ChamberInterlock_FixtureWaterBugVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.FixtureWater_Installed.ToString()
                        objSystemModule.ChamberInterlock_FixtureWaterVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        '2013-07-31 Tin Pham ------------

                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.AirPressure_Installed.ToString()
                        objSystemModule.Interlock_AirPressure_Visible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        '<End Get interlock config>

                    Case PM_TAG_CONFIG.Parallel_Magnet_Installed.ToString() ' "Parallel_Magnet_Installed"
                        objSystemModule.ParallelMagnetVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Parallel_Magnet_Installed.ToString(), objSystemModule.ParallelMagnetVisible.ToString())
                        If xmlnode.Attributes("WhichModel") IsNot Nothing Then
                            strParallelMagnetType = xmlnode.Attributes("WhichModel").Value
                        End If
                    Case PM_TAG_CONFIG.Magnatron_Installed.ToString() ' "Magnatron_Installed"
                        objSystemModule.MagnatronVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)

                    Case PM_TAG_CONFIG.Vat_Valve_Installed.ToString() ' "Vat_Valve_Installed"
                        objSystemModule.VatValveControllerVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Vat_Valve_Installed.ToString(), objSystemModule.VatValveControllerVisible.ToString())

                    Case PM_TAG_CONFIG.Water_Pump_Installed.ToString()
                        objSystemModule.WaterPumpVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If xmlnode.InnerText = Boolean.TrueString Then
                            If xmlnode.Attributes("RegenParamSupport") IsNot Nothing Then
                                objSystemModule.RegenParamSupport = CType(xmlnode.Attributes("RegenParamSupport").Value.ToString(), Boolean)
                            End If
                        End If
                        'get IG support Filament
                    Case PM_TAG_CONFIG.IGType.ToString()
                        Dim strIGtype As String = xmlnode.InnerText
                        objSystemModule.IGFilamentVisible = IsSupportIGFilament(strIGtype)

                    Case PM_TAG_CONFIG.Shutter_Installed.ToString()
                        objSystemModule.ShutterVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Shutter_Installed.ToString(), objSystemModule.ShutterVisible.ToString())
                    Case PM_TAG_CONFIG.ShutterOnFixture.ToString()
                        objSystemModule.ShutterOnFixtureUsedByGalilVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If xmlnode.Attributes("UsedByGalil") IsNot Nothing Then
                            Dim strModel As String = xmlnode.Attributes("UsedByGalil").Value
                            objSystemModule.ShutterOnFixtureUsedByGalilVisible = IIf(strModel.ToLower = STR_TRUE, True, False)
                        End If
                    Case PM_TAG_CONFIG.HasPBNBodyDischargeVoltage.ToString()
                        objSystemModule.SupportPBNBodyDischargeVoltage = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.FilamentType.ToString()
                        objSystemModule.Filament_Installed = IIf(xmlnode.InnerText.ToLower = "2", True, False)
                    Case PM_TAG_CONFIG.Target_Power_Supply_RF_Installed.ToString(), _
                        PM_TAG_CONFIG.RF_Power_Supply_Installed.ToString() '"Target_Power_Supply_RF_Installed"
                        objSystemModule.RFTargetPowerVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Target_Power_Supply_RF_Installed.ToString(), objSystemModule.RFTargetPowerVisible.ToString())
                        Dim strModel As String = xmlnode.Attributes("WhichModel").Value
                        If Not String.IsNullOrEmpty(strModel) Then
                            objSystemModule.RFTargetPowerModel = CType([Enum].Parse(GetType(Power_Supply_Model), strModel), Power_Supply_Model)
                        Else
                            AVPLib.Log.avpLogger.Error("Can not read Attribute Model of RF Target Power Supply in PM Config")
                        End If

                        '#08/02/2011 
                        '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                        '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                        '# If any param that does not have min/max, we will have to add it's min/max.
                        '#Begin fix:
                        If xmlnode.Attributes(STR_MAX_SP_TAG) IsNot Nothing Then
                            Dim strMaxSP As String = xmlnode.Attributes(STR_MAX_SP_TAG).Value
                            If objSystemModule.Type = ModuleType.PVD Then
                                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD_RF_POWER_MAX_SP, strMaxSP, xDoc)
                            ElseIf objSystemModule.Type = ModuleType.IBE Then
                                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_RF_POWER_MAX_SP, strMaxSP, xDoc)
                            ElseIf objSystemModule.Type = ModuleType.PVD4 Then
                                If objSystemModule.RFTargetPowerVisible AndAlso objSystemModule.DCTargetPowerVisible = False Then
                                    LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_TARGET_POWER_MAX_SP, strMaxSP, xDoc)
                                End If
                            ElseIf objSystemModule.Type = ModuleType.PVD5T Then
                                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD5T_RF_TARGET_POWER_MAX_SP, strMaxSP, xDoc)
                            End If
                        End If
                        '#End fix.

                    Case PM_TAG_CONFIG.Target_Power_Supply_DC_Installed.ToString() '"Target_Power_Supply_DC_Installed"
                        objSystemModule.DCTargetPowerVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Target_Power_Supply_DC_Installed.ToString(), objSystemModule.DCTargetPowerVisible.ToString())
                        Dim strModel As String = xmlnode.Attributes("WhichModel").Value
                        If Not String.IsNullOrEmpty(strModel) Then
                            objSystemModule.DCTargetPowerModel = CType([Enum].Parse(GetType(Power_Supply_Model), strModel), Power_Supply_Model)
                            ConfigHashTable.Add(PM_TAG_CONFIG.Target_Power_Supply_DC_Installed.ToString() & "_WhichModel", objSystemModule.DCTargetPowerModel.ToString())
                        Else
                            AVPLib.Log.avpLogger.Error("Can not read Attribute Model of DC Target Power Supply in PM Config")
                        End If

                        '#08/02/2011 
                        '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                        '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                        '# If any param that does not have min/max, we will have to add it's min/max.
                        '#Begin fix:
                        If xmlnode.Attributes(STR_MAX_SP_TAG) IsNot Nothing Then
                            Dim strMaxSP As String = xmlnode.Attributes(STR_MAX_SP_TAG).Value
                            If objSystemModule.Type = ModuleType.PVD Then
                                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD_DC_POWER_MAX_SP, strMaxSP, xDoc)
                            ElseIf objSystemModule.Type = ModuleType.PVD4 Then
                                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_TARGET_DC_POWER_MAX_SP, strMaxSP, xDoc)
                            ElseIf objSystemModule.Type = ModuleType.PVD5T Then
                                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD5T_TARGET_DC_POWER_MAX_SP, strMaxSP, xDoc)
                            End If
                        End If
                        '#End fix.
                        ' Mechanical Pump Serial
                    Case PM_TAG_CONFIG.MPSerial_Installed.ToString()
                        objSystemModule.MPumpSerialVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.MPSerial_Installed.ToString(), objSystemModule.MPumpSerialVisible.ToString())
                        ' Bias Power supply
                    Case PM_TAG_CONFIG.Bias_Power_Supply_Installed.ToString()
                        objSystemModule.BiasPowerVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Bias_Power_Supply_Installed.ToString(), objSystemModule.BiasPowerVisible.ToString())
                        Dim strModel As String = xmlnode.Attributes("WhichModel").Value
                        If Not String.IsNullOrEmpty(strModel) Then
                            objSystemModule.BiasPowerModel = CType([Enum].Parse(GetType(Power_Supply_Model), strModel), Power_Supply_Model)
                        Else
                            AVPLib.Log.avpLogger.Error("Can not read Attribute Model of Bias Power Supply in PM Config")
                        End If

                        '#08/02/2011 
                        '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                        '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                        '# If any param that does not have min/max, we will have to add it's min/max.
                        '#Begin fix:
                        If xmlnode.Attributes(STR_MAX_SP_TAG) IsNot Nothing Then
                            Dim strMaxSP As String = xmlnode.Attributes(STR_MAX_SP_TAG).Value
                            If objSystemModule.Type = ModuleType.PVD Then
                                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD_BIAS_POWER_MAX_SP, strMaxSP, xDoc)
                            ElseIf objSystemModule.Type = ModuleType.PVD4 Then
                                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_BIAS_POWER_MAX_SP, strMaxSP, xDoc)
                            End If
                        End If
                        '#End fix.

                    Case PM_TAG_CONFIG.Gas1MFCEnable.ToString()
                        objSystemModule.Gas1Install = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If xmlnode.InnerText = Boolean.TrueString Then
                            objSystemModule.Gas1SupplyPresent = CType(xmlnode.Attributes("HasSupplyValve").Value.ToString(), Boolean)
                            ConfigHashTable.Add(PM_TAG_CONFIG.Gas1MFCEnable.ToString() & "_HasSupplyValve", objSystemModule.Gas1SupplyPresent.ToString())
                            objSystemModule.Gas1ShutoffPresent = CType(xmlnode.Attributes("HasShutOffValve").Value.ToString(), Boolean)
                            ConfigHashTable.Add(PM_TAG_CONFIG.Gas1MFCEnable.ToString() & "_HasShutOffValve", objSystemModule.Gas1ShutoffPresent.ToString())
                            If objSystemModule.Gas1SupplyPresent Or objSystemModule.Gas1ShutoffPresent Then
                                objSystemModule.Gas1Name = xmlnode.Attributes("Name").Value.ToString()
                                objSystemModule.Gas1Type = xmlnode.Attributes("CalibrationFactorId").Value.ToString()
                                ConfigHashTable.Add(PM_TAG_CONFIG.Gas1MFCEnable.ToString() & "_CalibrationFactorId", objSystemModule.Gas1Type.ToString())
                            Else
                                objSystemModule.Gas1Name = String.Empty
                            End If
                        Else
                            objSystemModule.Gas1SupplyPresent = False
                            objSystemModule.Gas1ShutoffPresent = False
                            objSystemModule.Gas1Name = String.Empty
                        End If

                        '#08/02/2011 
                        '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                        '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                        '# If any param that does not have min/max, we will have to add it's min/max.
                        '#Begin fix:
                        Dim strMaxSP As String = xmlnode.Attributes(STR_RANGEVALUE_TAG).Value
                        strMaxSP = ConvertValueWithCalFactor(strMaxSP, objSystemModule.Gas1Type, listCalFactor)
                        If objSystemModule.Type = ModuleType.PVD Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD_GAS1_MAX_SP, strMaxSP, xDoc)
                        ElseIf objSystemModule.Type = ModuleType.IBE Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_GAS1_MAX_SP, strMaxSP, xDoc)
                        ElseIf objSystemModule.Type = ModuleType.PVD4 Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_GAS1_MAX_SP, strMaxSP, xDoc)
                        End If
                        '#End fix.


                    Case PM_TAG_CONFIG.Gas2MFCEnable.ToString()
                        objSystemModule.Gas2Install = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If xmlnode.InnerText = Boolean.TrueString Then
                            objSystemModule.Gas2SupplyPresent = CType(xmlnode.Attributes("HasSupplyValve").Value.ToString(), Boolean)
                            ConfigHashTable.Add(PM_TAG_CONFIG.Gas2MFCEnable.ToString() & "_HasSupplyValve", objSystemModule.Gas2SupplyPresent.ToString())
                            objSystemModule.gas2ShutoffPresent = CType(xmlnode.Attributes("HasShutOffValve").Value.ToString(), Boolean)
                            ConfigHashTable.Add(PM_TAG_CONFIG.Gas2MFCEnable.ToString() & "_HasShutOffValve", objSystemModule.gas2ShutoffPresent.ToString())
                            If objSystemModule.Gas2SupplyPresent Or objSystemModule.gas2ShutoffPresent Then
                                objSystemModule.Gas2Name = xmlnode.Attributes("Name").Value.ToString()
                                objSystemModule.Gas2Type = xmlnode.Attributes("CalibrationFactorId").Value.ToString()
                                ConfigHashTable.Add(PM_TAG_CONFIG.Gas2MFCEnable.ToString() & "_CalibrationFactorId", objSystemModule.Gas2Type.ToString())
                            Else
                                objSystemModule.Gas2Name = String.Empty
                            End If
                        Else
                            objSystemModule.Gas2SupplyPresent = False
                            objSystemModule.gas2ShutoffPresent = False
                            objSystemModule.Gas2Name = String.Empty
                        End If

                        '#08/02/2011 
                        '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                        '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                        '# If any param that does not have min/max, we will have to add it's min/max.
                        '#Begin fix:
                        Dim strMaxSP As String = xmlnode.Attributes(STR_RANGEVALUE_TAG).Value
                        strMaxSP = ConvertValueWithCalFactor(strMaxSP, objSystemModule.Gas2Type, listCalFactor)
                        If objSystemModule.Type = ModuleType.PVD Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD_GAS2_MAX_SP, strMaxSP, xDoc)
                        ElseIf objSystemModule.Type = ModuleType.IBE Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_GAS2_MAX_SP, strMaxSP, xDoc)
                        ElseIf objSystemModule.Type = ModuleType.PVD4 Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_GAS2_MAX_SP, strMaxSP, xDoc)
                        End If
                        '#End fix.

                    Case PM_TAG_CONFIG.Gas3MFCEnable.ToString()
                        objSystemModule.Gas3Install = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If xmlnode.InnerText = Boolean.TrueString Then
                            objSystemModule.Gas3SupplyPresent = CType(xmlnode.Attributes("HasSupplyValve").Value.ToString(), Boolean)
                            objSystemModule.gas3ShutoffPresent = CType(xmlnode.Attributes("HasShutOffValve").Value.ToString(), Boolean)
                            ConfigHashTable.Add(PM_TAG_CONFIG.Gas3MFCEnable.ToString() & "_HasSupplyValve", objSystemModule.Gas3SupplyPresent.ToString())
                            ConfigHashTable.Add(PM_TAG_CONFIG.Gas3MFCEnable.ToString() & "_HasShutOffValve", objSystemModule.gas3ShutoffPresent.ToString())

                            If objSystemModule.Gas3SupplyPresent Or objSystemModule.gas3ShutoffPresent Then
                                objSystemModule.Gas3Name = xmlnode.Attributes("Name").Value.ToString()
                                objSystemModule.Gas3Type = xmlnode.Attributes("CalibrationFactorId").Value.ToString()
                                ConfigHashTable.Add(PM_TAG_CONFIG.Gas3MFCEnable.ToString() & "_CalibrationFactorId", objSystemModule.Gas3Type.ToString())
                            Else
                                objSystemModule.Gas3Name = String.Empty
                            End If
                        Else
                            objSystemModule.Gas3SupplyPresent = False
                            objSystemModule.gas3ShutoffPresent = False
                            objSystemModule.Gas3Name = String.Empty
                        End If

                        '#08/02/2011 
                        '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                        '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                        '# If any param that does not have min/max, we will have to add it's min/max.
                        '#Begin fix:
                        Dim strMaxSP As String = xmlnode.Attributes(STR_RANGEVALUE_TAG).Value
                        strMaxSP = ConvertValueWithCalFactor(strMaxSP, objSystemModule.Gas3Type, listCalFactor)
                        If objSystemModule.Type = ModuleType.PVD Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD_GAS3_MAX_SP, strMaxSP, xDoc)
                        ElseIf objSystemModule.Type = ModuleType.IBE Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_GAS3_MAX_SP, strMaxSP, xDoc)
                        ElseIf objSystemModule.Type = ModuleType.PVD4 Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_GAS3_MAX_SP, strMaxSP, xDoc)
                        End If
                        '#End fix.

                    Case PM_TAG_CONFIG.Gas4MFCEnable.ToString()
                        objSystemModule.Gas4Install = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If xmlnode.InnerText = Boolean.TrueString Then
                            objSystemModule.Gas4SupplyPresent = CType(xmlnode.Attributes("HasSupplyValve").Value.ToString(), Boolean)
                            objSystemModule.gas4ShutoffPresent = CType(xmlnode.Attributes("HasShutOffValve").Value.ToString(), Boolean)
                            ConfigHashTable.Add(PM_TAG_CONFIG.Gas4MFCEnable.ToString() & "_HasSupplyValve", objSystemModule.Gas4SupplyPresent.ToString())
                            ConfigHashTable.Add(PM_TAG_CONFIG.Gas4MFCEnable.ToString() & "_HasShutOffValve", objSystemModule.gas4ShutoffPresent.ToString())
                            If objSystemModule.Gas4SupplyPresent Or objSystemModule.gas4ShutoffPresent Then
                                objSystemModule.Gas4Name = xmlnode.Attributes("Name").Value.ToString()
                                objSystemModule.Gas4Type = xmlnode.Attributes("CalibrationFactorId").Value.ToString()
                                ConfigHashTable.Add(PM_TAG_CONFIG.Gas4MFCEnable.ToString() & "_CalibrationFactorId", objSystemModule.Gas4Type.ToString())
                            Else
                                objSystemModule.Gas4Name = String.Empty
                            End If
                        Else
                            objSystemModule.Gas4SupplyPresent = False
                            objSystemModule.gas4ShutoffPresent = False
                            objSystemModule.Gas4Name = String.Empty
                        End If

                        '#08/02/2011 
                        '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                        '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                        '# If any param that does not have min/max, we will have to add it's min/max.
                        '#Begin fix:
                        Dim strMaxSP As String = xmlnode.Attributes(STR_RANGEVALUE_TAG).Value
                        strMaxSP = ConvertValueWithCalFactor(strMaxSP, objSystemModule.Gas4Type, listCalFactor)
                        If objSystemModule.Type = ModuleType.PVD Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD_GAS4_MAX_SP, strMaxSP, xDoc)
                        ElseIf objSystemModule.Type = ModuleType.IBE Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_GAS4_MAX_SP, strMaxSP, xDoc)
                        ElseIf objSystemModule.Type = ModuleType.PVD4 Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_GAS4_MAX_SP, strMaxSP, xDoc)
                        End If
                        '#End fix.

                    Case PM_TAG_CONFIG.Gas5MFCEnable.ToString()
                        objSystemModule.Gas5Install = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If xmlnode.InnerText = Boolean.TrueString Then
                            objSystemModule.Gas5SupplyPresent = CType(xmlnode.Attributes("HasSupplyValve").Value.ToString(), Boolean)
                            objSystemModule.gas5ShutoffPresent = CType(xmlnode.Attributes("HasShutOffValve").Value.ToString(), Boolean)
                            ConfigHashTable.Add(PM_TAG_CONFIG.Gas5MFCEnable.ToString() & "_HasSupplyValve", objSystemModule.Gas5SupplyPresent.ToString())
                            ConfigHashTable.Add(PM_TAG_CONFIG.Gas5MFCEnable.ToString() & "_HasShutOffValve", objSystemModule.gas5ShutoffPresent.ToString())
                            If objSystemModule.Gas5SupplyPresent Or objSystemModule.gas5ShutoffPresent Then
                                objSystemModule.Gas5Name = xmlnode.Attributes("Name").Value.ToString()
                                objSystemModule.Gas5Type = xmlnode.Attributes("CalibrationFactorId").Value.ToString()
                                ConfigHashTable.Add(PM_TAG_CONFIG.Gas5MFCEnable.ToString() & "_CalibrationFactorId", objSystemModule.Gas5Type.ToString())
                            Else
                                objSystemModule.Gas5Name = String.Empty
                            End If
                        Else
                            objSystemModule.Gas5SupplyPresent = False
                            objSystemModule.gas5ShutoffPresent = False
                            objSystemModule.Gas5Name = String.Empty
                        End If

                        '#08/02/2011 
                        '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                        '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                        '# If any param that does not have min/max, we will have to add it's min/max.
                        '#Begin fix:
                        Dim strMaxSP As String = xmlnode.Attributes(STR_RANGEVALUE_TAG).Value
                        strMaxSP = ConvertValueWithCalFactor(strMaxSP, objSystemModule.Gas5Type, listCalFactor)
                        If objSystemModule.Type = ModuleType.PVD Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD_GAS5_MAX_SP, strMaxSP, xDoc)
                        ElseIf objSystemModule.Type = ModuleType.IBE Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_GAS5_MAX_SP, strMaxSP, xDoc)
                        ElseIf objSystemModule.Type = ModuleType.PVD4 Then
                            LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.CORONA_GAS5_MAX_SP, strMaxSP, xDoc)
                        End If
                        'Injection_Valve_Installed
                    Case PM_TAG_CONFIG.Injection_Valve_Installed.ToString()
                        objSystemModule.GasInjectionInstall = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Injection_Valve_Installed.ToString(), objSystemModule.GasInjectionInstall.ToString())
                        If xmlnode.InnerText = Boolean.TrueString Then
                            objSystemModule.IsSupportMainSecondDistributionValves = xmlnode.Attributes("SupportMainSecondDistributionValves").Value.ToString()
                            ConfigHashTable.Add(PM_TAG_CONFIG.SupportMainSecondDistributionValves.ToString(), objSystemModule.IsSupportMainSecondDistributionValves.ToString())
                        End If

                        ' IGIsoValveInstalled
                    Case PM_TAG_CONFIG.IGIsoValveInstalled.ToString()
                        objSystemModule.IGIsoValveInstalled = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.IGIsoValveInstalled.ToString(), objSystemModule.IGIsoValveInstalled.ToString())

                        'PBNGas_Installed
                    Case PM_TAG_CONFIG.PBNGas_Installed.ToString()
                        objSystemModule.PBNGasInstall = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If xmlnode.InnerText = Boolean.TrueString Then
                            objSystemModule.PBNGasName = xmlnode.Attributes("Name").Value.ToString()
                            objSystemModule.PBNGasType = xmlnode.Attributes("CalibrationFactorId").Value.ToString()
                            ConfigHashTable.Add(PM_TAG_CONFIG.PBNGas_Installed.ToString() & "_Name", objSystemModule.PBNGasName.ToString())
                            ConfigHashTable.Add(PM_TAG_CONFIG.PBNGas_Installed.ToString() & "_CalibrationFactorId", objSystemModule.PBNGasType.ToString())
                            objSystemModule.PBNGasSupplyPresent = CType(xmlnode.Attributes("HasSupplyValve").Value.ToString(), Boolean)
                            ConfigHashTable.Add(PM_TAG_CONFIG.PBNGasEnable.ToString() & "_HasSupplyValve", objSystemModule.PBNGasSupplyPresent.ToString())
                            objSystemModule.PBNGasShutoffPresent = CType(xmlnode.Attributes("HasShutOffValve").Value.ToString(), Boolean)
                            ConfigHashTable.Add(PM_TAG_CONFIG.PBNGasEnable.ToString() & "_HasShutOffValve", objSystemModule.PBNGasShutoffPresent.ToString())
                        Else
                            objSystemModule.PBNGasName = String.Empty
                            objSystemModule.PBNGasType = xmlnode.Attributes("CalibrationFactorId").Value.ToString()
                        End If

                        '#08/02/2011 
                        '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                        '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                        '# If any param that does not have min/max, we will have to add it's min/max.
                        '#Begin fix:
                        Dim strMaxSP As String = xmlnode.Attributes(STR_RANGEVALUE_TAG).Value
                        strMaxSP = ConvertValueWithCalFactor(strMaxSP, objSystemModule.PBNGasType, listCalFactor)
                        LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_PBN_GAS_MAX_SP, strMaxSP, xDoc)

                    Case PM_TAG_CONFIG.MaxBeamVoltageSP.ToString()
                        LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_BEAM_VOLTAGE_MAX_SP, xmlnode.InnerText, xDoc)
                    Case PM_TAG_CONFIG.MaxSuppressorVoltageSP.ToString()
                        LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_SUPPRESSOR_VOLTAGE_MAX_SP, xmlnode.InnerText, xDoc)
                        '#End fix.
                    Case PM_TAG_CONFIG.TiltAngleReferenceAsLegacy.ToString()
                        objSystemModule.TiltAngleReferenceAsLegacy = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.VerifyTiltSensorAtPosition.ToString()
                        objSystemModule.VerifyTiltSensorAtPosition = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        If xmlnode.InnerText = Boolean.TrueString Then
                            objSystemModule.VerifiedAngle = xmlnode.Attributes("VerifiedAngle").Value.ToString()
                        End If
                    Case PM_TAG_CONFIG.Heater_Zone1_Installed.ToString()
                        objSystemModule.HeaterZone1Installed = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Heater_Zone2_Installed.ToString()
                        objSystemModule.HeaterZone2Installed = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)

                    Case PM_TAG_CONFIG.FilMetricDevice_Installed.ToString()
                        objSystemModule.FilMetricDevice_Installed = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.FilMetricDevice_Installed.ToString(), objSystemModule.FilMetricDevice_Installed.ToString())
                    Case PM_TAG_CONFIG.Wafer_Lift_Installed.ToString()
                        objSystemModule.WaferLiftInstalled = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Chuck_Position_TSD_Ref.ToString()
                        objSystemModule.ChuckPositionTSDRef = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.Chuck_Position_TSD_Ref.ToString(), objSystemModule.ChuckPositionTSDRef.ToString())
                        'Interlock
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.SourceWater_Installed.ToString()
                        objSystemModule.ChamberInterlock_SourceWaterVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.PanelInterlock_Installed.ToString()
                        objSystemModule.ChamberInterlock_PanelInterlockVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.AirPressure_Installed.ToString(), PM_TAG_CONFIG.AirPressure_Interlock_Installed.ToString(), PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.AirPressure_Installed.ToString() 'just for IBD
                        objSystemModule.ChamberInterlock_AirPressureVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.ChamberPressure_Installed.ToString()
                        objSystemModule.ChamberInterlock_ChamberPressureVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Interlock_.ToString() & PM_TAG_CONFIG.ForelinePressure_Installed.ToString()
                        objSystemModule.ChamberInterlock_ForelinePressureVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        'Tilt Sweep Mod. Support IBE
                    Case PM_TAG_CONFIG.SupportTiltSweepMode.ToString()
                        objSystemModule.SupportTiltSweepMode = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.SupportTiltSweepMode.ToString(), objSystemModule.SupportTiltSweepMode.ToString())
                    Case PM_TAG_CONFIG.Fast_Tilt_Installed.ToString()
                        objSystemModule.FastTiltInstalled = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.BackTilt_Installed.ToString()
                        objSystemModule.BackTiltInstalled = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                        ConfigHashTable.Add(PM_TAG_CONFIG.BackTilt_Installed.ToString(), objSystemModule.BackTiltInstalled.ToString())
                    Case PM_TAG_CONFIG.Source_Magnet_Power_Supply_Installed.ToString()
                        objSystemModule.SourceMagnetVisible = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                    Case PM_TAG_CONFIG.Shared_Mechanical_Pump.ToString()
                        RobotConfigurationValues.SHARED_MP_WITH_PM = IIf(xmlnode.InnerText.ToLower = STR_TRUE, True, False)
                End Select
            Next

            '#08/02/2011 
            '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
            '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
            '# If any param that does not have min/max, we will have to add it's min/max.
            '#Begin fix: for Parallel Magnet.

            If objSystemModule.Type = ModuleType.PVD Then  'hard code parallel magnet type.
                If strParallelMagnetType = "BOP-20/20" Then
                    strParallelMagnetType = "BOP20_20MaxCurrent"
                ElseIf strParallelMagnetType = "BOP-50/8" Then
                    strParallelMagnetType = "BOP50_8MaxCurrent"
                End If
                selectedNode = PMConfigDoc.SelectSingleNode(String.Format("/Configuration/Parameters/{0}", strParallelMagnetType))
                If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                    LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.PVD_PARALLEL_MAGNET_MAX_SP, _
                                                                                selectedNode.InnerText, xDoc)
                End If
            ElseIf objSystemModule.Type = ModuleType.IBE Then
                ''
                Try
                    selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/Fixture_Tilt_High_Limit")
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error("Can not load /Configuration/Parameters/Fixture_Tilt_High_Limit")
                End Try

                If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                    If objSystemModule.Type = ModuleType.IBE Then
                        LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_TILE_ANGLE_MAX_SP, _
                                                                                    selectedNode.InnerText, xDoc)
                        LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_TILE_SWEEP_START_ANGLE_MAX_SP, _
                                                                                    selectedNode.InnerText, xDoc)
                        LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_TILE_SWEEP_END_ANGLE_MAX_SP, _
                                                                                    selectedNode.InnerText, xDoc)
                    End If
                End If

                Try
                    selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/Fixture_Tilt_Low_Limit")
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error("Can not load /Configuration/Parameters/Fixture_Tilt_Low_Limit")
                End Try

                If selectedNode IsNot Nothing AndAlso IsNumeric(selectedNode.InnerText) Then
                    If objSystemModule.Type = ModuleType.IBE Then
                        LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_TILE_ANGLE_MIN_SP, _
                                                                                    selectedNode.InnerText, xDoc)
                        LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_TILE_SWEEP_START_ANGLE_MIN_SP, _
                                                                                    selectedNode.InnerText, xDoc)
                        LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_TILE_SWEEP_END_ANGLE_MIN_SP, _
                                                                                    selectedNode.InnerText, xDoc)
                    End If
                End If

            End If
            '#End fix
            'Load Min Max value from IBE GUIConfigParameter.xml
            If objSystemModule.Type = ModuleType.IBE Then
                Dim PMGUIConfigParameterDoc As New Xml.XmlDocument
                PMGUIConfigParameterDoc = BinarySerialize.Open_DatFileConfig(serverConfig.ConfigFolder & "\" & ContainerDAO.FIBEGUIConfigParameterName)

                If PMGUIConfigParameterDoc Is Nothing Then
                    AVPLib.Log.avpLogger.Error("Can not access IBE GUIConfigParameter File - " & serverConfig.ConfigFolder & "\" & ContainerDAO.FIBEGUIConfigParameterName)
                    Return False
                End If

                'Load IBE_BEAM_CURRENT_SP Max value
                selectedNode = PMGUIConfigParameterDoc.SelectSingleNode("/Configuration/Parameters/txtBeamCurrentSPMax")
                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_BEAM_CURRENT_SP, selectedNode.InnerText, ContainerDAO.SystemConfigDoc)

                'Load IBE_BEAM_VOLTAGE_MAX_SP Max value
                selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/" & _
                                                          PM_TAG_CONFIG.MaxBeamVoltageSP.ToString())
                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_BEAM_VOLTAGE_MAX_SP, selectedNode.InnerText, ContainerDAO.SystemConfigDoc)

                'Load IBE_SUPPRESSOR_VOLTAGE_MAX_SP Max value
                selectedNode = PMConfigDoc.SelectSingleNode("/Configuration/Parameters/" & _
                                                          PM_TAG_CONFIG.MaxSuppressorVoltageSP.ToString())
                LoadValueConfigFromPMConfig(ServerName, PM_MIN_MAX_NAME_ITEM.IBE_SUPPRESSOR_VOLTAGE_MAX_SP, selectedNode.InnerText, ContainerDAO.SystemConfigDoc)
            End If

            'Save Back to AVP
            SaveBackToAvpConfig(ServerName, xDoc, objSystemModule)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return True
        AVPLib.Log.coreLogger.Info("Leave ReadServerConfiguration_Visible")
    End Function
    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2021-11-11 </date>
    ''' </author>
    ''' <summary>
    ''' Is Support IG Filament PM
    ''' </summary>
    Private Shared Function IsSupportIGFilament(ByVal strType As String) As Boolean
        Dim result As Boolean = False
        Try
            Select Case strType
                Case "1", "3"
                    result = True
                Case "2", "4"
                    result = False
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-07 </date>
    ''' </author>
    ''' <summary>
    ''' Read PVD Configuration and save back to local AVP Config
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub LoadValueConfigFromPMConfig(ByVal strChamberName As String, ByVal strName As String, _
        ByVal strValue As String, ByRef xDoc As Xml.XmlDocument)
        Try
            Dim arrName As String() = strName.Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries)
            For Each strNameItem As String In arrName
                Dim node As Xml.XmlNode = xDoc.SelectSingleNode(String.Format(ConstEnum.XPATH_ROBOT & "/MessageText[Key = '{0}']/Value", strChamberName & "." & strNameItem))
                If node IsNot Nothing Then
                    node.InnerText = strValue
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Save PVD Config back to local AVP Config
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub SaveBackToAvpConfig(ByVal ServerName As String, ByRef xDoc As Xml.XmlDocument, ByVal objSystemModule As SystemModule)
        AVPLib.Log.coreLogger.Info("Enter SaveBackToAvpConfig")
        Dim root As System.Xml.XmlNode = xDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
        Try
            Dim ChamberNode As Xml.XmlNode = Nothing
            For Each node As Xml.XmlNode In root.ChildNodes
                Dim str As String = node.FirstChild.InnerText
                If node.FirstChild.InnerText = ServerName Then
                    ChamberNode = node.LastChild ''select node SubSystemList
                    Exit For
                End If
            Next

            Dim subsysNodelist As Xml.XmlNodeList = ChamberNode.ChildNodes
            For Each item As Xml.XmlNode In subsysNodelist
                Dim strSubSystemName As String = item.ChildNodes.Item(0).InnerText
                Select Case strSubSystemName
                    Case PM_TAG_CONFIG.MG.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.MGVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                    Case PM_TAG_CONFIG.TargetKWHAlarmLimit.ToString()
                        If objSystemModule.Type <> ModuleType.PVD4 And objSystemModule.Type <> ModuleType.PVD5T Then
                            item.ChildNodes.Item(1).InnerText = objSystemModule.Alarm_KWH.ToString()
                        End If
                    Case PM_TAG_CONFIG.TargetKWHWarningLimit.ToString()
                        If objSystemModule.Type <> ModuleType.PVD4 And objSystemModule.Type <> ModuleType.PVD5T Then
                            item.ChildNodes.Item(1).InnerText = objSystemModule.Warning_KWH.ToString()
                        End If
                    Case PM_TAG_CONFIG.ROR_Litter.ToString()
                        item.ChildNodes.Item(1).InnerText = objSystemModule.Litter_Value.ToString()
                    Case PM_TAG_CONFIG.Clamp_Installed.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.ClampInstalled, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                    Case PM_TAG_CONFIG.Shutter_Visible.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.ShutterVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                    Case PM_TAG_CONFIG.DCTargetPowerSupply.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.DCTargetPowerVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                    Case PM_TAG_CONFIG.RFTargetPowerSupply.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.RFTargetPowerVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                    Case PM_TAG_CONFIG.BiasPowerSupply.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.BiasPowerVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                    Case PM_TAG_CONFIG.ParallelMagnet.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.ParallelMagnetVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                    Case PM_TAG_CONFIG.PM_DeviceNet.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.PM_DeviceNet, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                    Case PM_TAG_CONFIG.ChamberInterlock.ToString()
                        item.SelectNodes(PM_TAG_CONFIG.ChamberLid_Installed.ToString()).Item(0).InnerText = IIf(objSystemModule.ChamberInterlock_LidSensorVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        item.SelectNodes(PM_TAG_CONFIG.LidWater_Installed.ToString()).Item(0).InnerText = IIf(objSystemModule.ChamberInterlock_LidWaterVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        item.SelectNodes(PM_TAG_CONFIG.TargetWater_Installed.ToString()).Item(0).InnerText = IIf(objSystemModule.ChamberInterlock_TargetWaterVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        item.SelectNodes(PM_TAG_CONFIG.TurboForeline_Installed.ToString()).Item(0).InnerText = IIf(objSystemModule.ChamberInterlock_TurboForelineVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        item.SelectNodes(PM_TAG_CONFIG.TurboWater_Installed.ToString()).Item(0).InnerText = IIf(objSystemModule.ChamberInterlock_TurboWaterVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)                        '
                        If item.SelectNodes(PM_TAG_CONFIG.TargetMBWater_Installed.ToString()) IsNot Nothing AndAlso _
                        item.SelectNodes(PM_TAG_CONFIG.TargetMBWater_Installed.ToString()).Item(0) IsNot Nothing Then
                            item.SelectNodes(PM_TAG_CONFIG.TargetMBWater_Installed.ToString()).Item(0).InnerText = IIf(objSystemModule.ChamberInterlock_TargetMBWaterVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        End If
                        If item.SelectNodes(PM_TAG_CONFIG.ClampWater_Installed.ToString()) IsNot Nothing AndAlso _
                                                item.SelectNodes(PM_TAG_CONFIG.ClampWater_Installed.ToString()).Item(0) IsNot Nothing Then
                            item.SelectNodes(PM_TAG_CONFIG.ClampWater_Installed.ToString()).Item(0).InnerText = IIf(objSystemModule.ChamberInterlock_ClampWaterVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        End If
                        If item.SelectNodes(PM_TAG_CONFIG.SubMBWater_Installed.ToString()) IsNot Nothing AndAlso _
                                                                       item.SelectNodes(PM_TAG_CONFIG.SubMBWater_Installed.ToString()).Item(0) IsNot Nothing Then
                            item.SelectNodes(PM_TAG_CONFIG.SubMBWater_Installed.ToString()).Item(0).InnerText = IIf(objSystemModule.ChamberInterlock_SubMBWaterVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        End If
                    Case PM_TAG_CONFIG.PumpingPackage.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.CryoVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        item.ChildNodes.Item(2).InnerText = IIf(objSystemModule.TurboPumpVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                    Case PM_TAG_CONFIG.VatValveController.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.VatValveControllerVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                    Case PM_TAG_CONFIG.GasController.ToString()
                        Dim gasLineNode As Xml.XmlNodeList = item.ChildNodes.Item(2).ChildNodes
                        gasLineNode.Item(0).Attributes("Name").Value = objSystemModule.Gas1Name
                        gasLineNode.Item(0).Attributes("IsShutoffPresent").Value = IIf(objSystemModule.Gas1ShutoffPresent, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        gasLineNode.Item(0).Attributes("IsSupplyPresent").Value = IIf(objSystemModule.Gas1SupplyPresent, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                        gasLineNode.Item(1).Attributes("Name").Value = objSystemModule.Gas2Name
                        gasLineNode.Item(1).Attributes("IsShutoffPresent").Value = IIf(objSystemModule.gas2ShutoffPresent, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        gasLineNode.Item(1).Attributes("IsSupplyPresent").Value = IIf(objSystemModule.Gas2SupplyPresent, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                        gasLineNode.Item(2).Attributes("Name").Value = objSystemModule.Gas3Name
                        gasLineNode.Item(2).Attributes("IsShutoffPresent").Value = IIf(objSystemModule.gas3ShutoffPresent, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        gasLineNode.Item(2).Attributes("IsSupplyPresent").Value = IIf(objSystemModule.Gas3SupplyPresent, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                        gasLineNode.Item(3).Attributes("Name").Value = objSystemModule.Gas4Name
                        gasLineNode.Item(3).Attributes("IsShutoffPresent").Value = IIf(objSystemModule.gas4ShutoffPresent, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        gasLineNode.Item(3).Attributes("IsSupplyPresent").Value = IIf(objSystemModule.Gas4SupplyPresent, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                        gasLineNode.Item(4).Attributes("Name").Value = objSystemModule.Gas5Name
                        gasLineNode.Item(4).Attributes("IsShutoffPresent").Value = IIf(objSystemModule.gas5ShutoffPresent, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                        gasLineNode.Item(4).Attributes("IsSupplyPresent").Value = IIf(objSystemModule.Gas5SupplyPresent, DEVICE_VISIBLE, DEVICE_INVISIBLE)

                    Case PM_TAG_CONFIG.Magnatron.ToString()
                        item.ChildNodes.Item(1).InnerText = IIf(objSystemModule.MagnatronVisible, DEVICE_VISIBLE, DEVICE_INVISIBLE)
                End Select
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, xDoc)
        AVPLib.Log.coreLogger.Info("Leave SaveBackToAvpConfig")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-28 </date>
    ''' </author>
    ''' <summary>
    ''' Read Preset Config
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub ReadPresetConfig(ByVal SysValNode As Xml.XmlNode, ByRef hstPresetValue As Hashtable, ByVal LoadPVDConfigSuccess As Boolean)
        AVPLib.Log.coreLogger.Info("Enter ReadPresetConfig")
        Try
            If LoadPVDConfigSuccess Then
                Exit Sub
            End If
            For Each node As Xml.XmlNode In SysValNode.ChildNodes
                Dim objPreset As New SystemModule.PresetTable
                If node.Name = "Preset" Then
                    objPreset.ID = node.Attributes(PRESET_ID_STR).Value
                    objPreset.C1 = node.Attributes(PRESET_C1_STR).Value
                    objPreset.C2 = node.Attributes(PRESET_C2_STR).Value
                    hstPresetValue.Add(objPreset.ID, objPreset)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave ReadPresetConfig")
    End Sub

    Private Shared Sub ReadIBESourceValue(ByVal SysValNode As Xml.XmlNode, ByRef hstSourceValue As Hashtable)
        AVPLib.Log.coreLogger.Info("Enter ReadPresetConfig")
        Try
            For Each node As Xml.XmlNode In SysValNode.ChildNodes
                Dim strName As String = node.Attributes("Name").Value
                Dim strValue As String = node.Attributes("value").Value
                If Not String.IsNullOrEmpty(strName) AndAlso _
                Not String.IsNullOrEmpty(strValue) Then
                    hstSourceValue.Add(strName, strValue)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave ReadPresetConfig")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-28 </date>
    ''' </author>
    ''' <summary>
    ''' Count Gas Line base on Index of nodelist
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub SetSystemModuleProperty(ByVal strkey As String, _
                                               ByVal strSubSystemValue As String, _
                                               ByRef blnPropertyWillBeSet As Boolean, _
                                               ByVal PVDConfigLoadSuccess As Boolean)
        AVPLib.Log.coreLogger.Info("Enter SetSystemModuleProperty")
        Try
            If PVDConfigLoadSuccess Then
                Exit Sub
            End If
            If strSubSystemValue = DEVICE_VISIBLE Then
                blnPropertyWillBeSet = True
            ElseIf strSubSystemValue = DEVICE_INVISIBLE Then
                blnPropertyWillBeSet = False
            Else
                AVPLib.Log.coreLogger.Error("Key " + strkey + INVALID_MESSAGE + CHAMBER_VISIBLE_DEFAULT_VALUE.ToString())
                blnPropertyWillBeSet = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SetSystemModuleProperty")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-28 </date>
    ''' </author>
    ''' <summary>
    ''' Count Gas Line base on Index of nodelist
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub CountGasLine(ByVal gasLineNode As Xml.XmlNodeList, _
                                ByRef objSystemModule As SystemModule, _
                                ByVal intIndexNode As Integer, _
                                ByRef strGasNameWillBeSet As String, _
                                ByRef blSupplyValvePresent As Boolean, _
                                ByRef blShutoffValvePresent As Boolean)
        AVPLib.Log.coreLogger.Info("Enter CountGasLine")
        Try
            blSupplyValvePresent = False
            blShutoffValvePresent = False
            If gasLineNode.Item(intIndexNode).Attributes("IsShutoffPresent").Value = DEVICE_VISIBLE AndAlso _
                                              Not (gasLineNode.Item(intIndexNode).Attributes("Name").Value = String.Empty) Then
                strGasNameWillBeSet = gasLineNode.Item(intIndexNode).Attributes("Name").Value
                blShutoffValvePresent = True
            End If

            If gasLineNode.Item(intIndexNode).Attributes("IsSupplyPresent").Value = DEVICE_VISIBLE AndAlso _
                                              Not (gasLineNode.Item(intIndexNode).Attributes("Name").Value = String.Empty) Then
                strGasNameWillBeSet = gasLineNode.Item(intIndexNode).Attributes("Name").Value
                blSupplyValvePresent = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave CountGasLine")
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-09-04</date>
    ''' </author>
    ''' <summary>
    ''' GetChamberConfig
    ''' </summary>
    ''' <param name="ConfigDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChamberConfig(ByVal root As System.Xml.XmlNode) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetChamberConfig")
        Dim map As New Hashtable()
        Try
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            Dim value As Object = Nothing
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                Dim nodeConfigList As System.Xml.XmlNodeList = node.ChildNodes
                If (nodeConfigList.Count >= 2) Then
                    Dim key As String = nodeConfigList.Item(0).InnerText
                    value = nodeConfigList.Item(1).InnerText
                    map.Add(key, value)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetChamberConfig")
        Return map
    End Function

    Public Shared Function GetDegasWaitTimeConfig(ByVal root As System.Xml.XmlNode) As Boolean
        AVPLib.Log.coreLogger.Info("Enter GetDegasWaitTimeConfig")
        Try
            If root Is Nothing Then
                Return False
            End If
            Integer.TryParse(root.FirstChild.InnerText, RobotConfigurationValues.LLA_IGDEGAS_WAIT_TIME_IN_SECONDS)
            Integer.TryParse(root.LastChild.InnerText, RobotConfigurationValues.TM_IGDEGAS_WAIT_TIME_IN_SECONDS)
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetDegasWaitTimeConfig")
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' GetPath
    ''' </summary>
    ''' <param name="PathDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPath(ByVal PathDoc As System.Xml.XmlDocument) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetPath")
        Dim map As New Hashtable()
        Try
            Dim root As System.Xml.XmlNode = PathDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                Dim nodeConfigList As System.Xml.XmlNodeList = node.ChildNodes
                Try
                    Dim key As String = nodeConfigList.Item(0).InnerText
                    Dim value As String = nodeConfigList.Item(1).InnerText
                    map.Add(key, value)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetPath")
        Return map
    End Function

#Region "Gas CalFact"
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-11-07</date>
    ''' </author>
    ''' <summary>
    '''  ConvertValueWithCalFactor
    ''' </summary>
    Private Shared Function GetCalFactConfig(Optional ByVal filename As String = "") As Hashtable
        AVPLib.Log.avpLogger.Info("Enter GetCalFactConfig()")
        Dim CalFactMap As New Hashtable()
        Try
            Dim xmlDoc As New XmlDocument()
            If filename = "" Then
                xmlDoc.Load(ContainerDAO.FPath_CalFactFile)
            Else
                xmlDoc = BinarySerialize.Open_DatFileConfig(filename)
            End If
            ' Root node
            Dim root As XmlNode = xmlDoc.DocumentElement

            If root IsNot Nothing Then
                ' Assign all values to object
                For Each child As XmlNode In root.ChildNodes
                    If Not CalFactMap.ContainsKey(child.Name) Then
                        CalFactMap.Add(child.Name, child.InnerText)
                    Else
                        AVPLib.Log.avpLogger.Debug(child.Name & " is already existed in CalFactMap")
                    End If
                Next
            Else
                AVPLib.Log.avpLogger.Error("Cal fact xml file is empty")
            End If
        Catch Ex As Exception
            CalFactMap = Nothing
            AVPLib.Log.avpLogger.Error(Ex.Message)
        End Try
        AVPLib.Log.avpLogger.Info("Leave GetCalFactConfig()")
        Return CalFactMap
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-11-07</date>
    ''' </author>
    ''' <summary>
    '''  ConvertValueWithCalFactor
    ''' </summary>
    Private Shared Function ConvertValueWithCalFactor(ByVal strValue As String, ByVal strGasName As String, ByVal lstCalFact As Hashtable) As String
        AVPLib.Log.avpLogger.Info("Enter ConvertValueWithCalFactor()")
        Dim strResult As String = strValue

        Try
            Dim dValue As Double = Double.Parse(strValue)
            Dim dKFactor As Double = getCalFact(strGasName, lstCalFact)
            strResult = (dValue * dKFactor).ToString()
        Catch Ex As Exception
            AVPLib.Log.avpLogger.Error(Ex.Message)
        End Try
        AVPLib.Log.avpLogger.Info("Leave ConvertValueWithCalFactor()")

        Return strResult
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-11-07</date>
    ''' </author>
    ''' <summary>
    '''  Get CalFact value
    ''' </summary>
    Private Shared Function getCalFact(ByVal gasName As String, ByVal lstCalFact As Hashtable) As Double
        AVPLib.Log.avpLogger.Info("Enter getCalFact()")
        Dim val As Double = 0
        Try
            If lstCalFact Is Nothing Then
                Return 1
            End If

            If Not lstCalFact.Contains(gasName) Then
                Return 1
            End If

            Dim calFactValue As String = DirectCast(lstCalFact(gasName), String)
            If String.IsNullOrEmpty(calFactValue) Then
                Return 1
            End If

            If Not Double.TryParse(calFactValue, val) Then
                Return 1
            End If
        Catch Ex As Exception
            AVPLib.Log.avpLogger.Error(Ex.Message)
        End Try

        AVPLib.Log.avpLogger.Info("Leave getCalFact()")
        Return val
    End Function
#End Region

#End Region
End Class
