Public Class ConfigurationLib
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' GetMessageConfig
    ''' </summary>
    ''' <param name="ConfigurationServerDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetConfigurationServer(ByVal ConfigurationServerDoc As System.Xml.XmlDocument) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetConfigurationServer")
        Dim map As New Hashtable()
        Try
            Dim root As System.Xml.XmlNode = ConfigurationServerDoc.FirstChild
            Dim nodeListServerGroup As System.Xml.XmlNodeList = root.ChildNodes
            Dim nameAttr As Xml.XmlAttribute = Nothing
            Dim strKepServer = ConstEnum.Equipments.KepServer.ToString()
            Dim strDeviceNetAdapter As String = "DeviceNetAdapter"
            Dim attInstall As Xml.XmlAttribute = Nothing

            ''because do not use InstallCX on UserConfig.xml
            'so rem old function and create new function to setup init variable
            'GetNode_InstallCX(root)

            Dim iMaxChamberInstall As Integer = 3 'default for CX4
          

            For Each nodeServerGroup As Xml.XmlNode In root.ChildNodes
                If (nodeServerGroup.Name = ConstEnum.TerminalServer) Then
                    For Each nodeServer As Xml.XmlNode In nodeServerGroup.ChildNodes
                        AddConnection(map, nodeServer)
                    Next
                ElseIf (nodeServerGroup.Name = strKepServer) Then
                    nameAttr = nodeServerGroup.Attributes.ItemOf(ConstEnum.Name)
                    If (nameAttr IsNot Nothing) Then
                        map.Add(strKepServer, New Server(nameAttr.Value, String.Empty, String.Empty, True, False, String.Empty, String.Empty))
                    Else
                        Log.dataManagementLogger.Error("Attribute " & ConstEnum.Name & " is not found in the xml node " & strKepServer)
                    End If

                ElseIf (nodeServerGroup.Name = strDeviceNetAdapter) Then
                    attInstall = nodeServerGroup.Attributes.ItemOf("IsInstall")
                    If attInstall IsNot Nothing Then
                        RobotConfigurationValues.IS_KEPWARE_INSTALLED = Not Boolean.Parse(attInstall.Value)
                    End If

                ElseIf (nodeServerGroup.Name = ConstEnum.ChamberInstall) Then

                    If (nodeServerGroup.ChildNodes.Count < iMaxChamberInstall) Then
                        iMaxChamberInstall = nodeServerGroup.ChildNodes.Count
                    End If

                    For index As Integer = 0 To iMaxChamberInstall - 1
                        Dim nodeServer As Xml.XmlNode = nodeServerGroup.ChildNodes(index)
                        AddConnection(map, nodeServer)
                    Next
                ElseIf nodeServerGroup.Name = ConstEnum.KepServerDevice Then
                    For Each nodeServer As Xml.XmlNode In nodeServerGroup.ChildNodes
                        AddKepServerDevice(nodeServer)
                    Next
                Else
                    Log.dataManagementLogger.Error("Unknown tag " & nodeServerGroup.Name & " found")
                End If
            Next
            'Get the debug mode from ConfigurationServer.xml
            GetNode_DebugMode(root)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetConfigurationServer")
        Return map
    End Function

    'Private Shared Sub GetNode_InstallCX(ByVal root As Xml.XmlNode)
    '    Try
    '        Dim nodeInstall As Xml.XmlNode = root.SelectSingleNode("Install_CX")
    '        If nodeInstall IsNot Nothing Then
    '            Dim strInstallCX As String = nodeInstall.InnerText.ToUpper()
    '            If strInstallCX = "CX5" Then
    '                RobotConfigurationValues.INSTALLED_CX4 = False
    '                RobotConfigurationValues.INSTALLED_CX5 = True
    '            ElseIf strInstallCX = "CX4" Then
    '                RobotConfigurationValues.INSTALLED_CX4 = True
    '                RobotConfigurationValues.INSTALLED_CX5 = False
    '            End If
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub
    
    Private Shared Sub GetNode_DebugMode(ByVal root As Xml.XmlNode)
        Try
            Dim nodeInstall As Xml.XmlNode = root.SelectSingleNode("DEBUG_MODE")
            If nodeInstall IsNot Nothing Then
                Dim strInstallCX As String = nodeInstall.InnerText.ToUpper()
                If strInstallCX = "0" Then
                    RobotConfigurationValues.DEBUGMODE = False
                ElseIf strInstallCX = "1" Then
                    RobotConfigurationValues.DEBUGMODE = True
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Nguyen Tien Dat </name>
    '''    	<date> 2009-28-04</date>
    ''' </author>
    ''' <summary>
    ''' Add server info (IP address, Port) to the global server info connection tables.
    ''' </summary>
    ''' <param name="mapConnections"></param>
    ''' <param name="conNode"></param>
    ''' <remarks></remarks>
    Private Shared Sub AddConnection(ByVal mapConnections As Hashtable, ByVal conNode As Xml.XmlNode)
        Dim nameAttr As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.Name)
        Dim ipAddressAttr As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.EthernetIP)
        Dim portAttr As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.Port)
        Dim IsInstallAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.ISINSTALLED)
        Dim IsManualDoorElevatorAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.ISMANUALDOOR)
        Dim Version As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.Version)
        Dim IsSensorInstalled As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.IsSensorInstalled)
        Dim ConfigFolderAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.CONFIG_FOLDER)
        Dim RecipeFolderAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.RECIPE_FOLDER)
        Dim DataRunFolderAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.DATA_RUN_FOLDER)
        Dim DataRunFilenameAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.DATA_RUN_FILENAME)
        Dim RateOfRiseFolderAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.ROR_FOLDER)
        Dim RateOfRiseFilenameAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.ROR_FILENAME)
        Dim DataRunOutputFolderAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.DATA_RUN_OUTPUT_FOLDER)


        Dim typeAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.TYPE_OF_PM)
        Dim configFolder As String = String.Empty
        Dim recipeFolder As String = String.Empty
        Dim typeofPM As String = String.Empty
        Dim IsManualDoorElevator As Boolean = False
        Dim sVersion As String = String.Empty
        Dim svr As Server
        ' Device net app
        If nameAttr.Value = "DeviceNetApp" Then
            If Boolean.TryParse(IsInstallAtt.Value, RobotConfigurationValues.DEVICENETAPP_VISIBLE) = False Then
                RobotConfigurationValues.DEVICENETAPP_VISIBLE = False
                Exit Sub
            End If
        End If
        ' water pump
        If nameAttr.Value = "TMWaterPump" Then
            If Boolean.TryParse(IsInstallAtt.Value, RobotConfigurationValues.TMWATERPUM_VISIBLE) = False Then
                RobotConfigurationValues.TMWATERPUM_VISIBLE = False
                Exit Sub
            End If
        End If
        ' aligner
        If nameAttr.Value = "Aligner" Then
            If Boolean.TryParse(IsInstallAtt.Value, RobotConfigurationValues.ALINER_VISIBLE) = False Then
                RobotConfigurationValues.ALINER_VISIBLE = False
                Exit Sub
            End If
        End If

        ' Mechanical Pump 1
        If nameAttr.Value = "RoughPumpMachine1" Then
            If Boolean.TryParse(IsInstallAtt.Value, RobotConfigurationValues.MPUMP1_SERIAL_VISIBLE) = False Then
                RobotConfigurationValues.MPUMP1_SERIAL_VISIBLE = False
                Exit Sub
            End If
        End If

        ' Mechanical Pump 2
        If nameAttr.Value = "RoughPumpMachine2" Then
            If Boolean.TryParse(IsInstallAtt.Value, RobotConfigurationValues.MPUMP2_SERIAL_VISIBLE) = False Then
                RobotConfigurationValues.MPUMP2_SERIAL_VISIBLE = False
                Exit Sub
            End If
        End If

        'If nameAttr.Value = "RoughPumpMachine1" Then
        '    If Boolean.TryParse(IsInstallAtt.Value, RobotConfigurationValues.ROUGH_1_INSTALLED) = False Then
        '        RobotConfigurationValues.ROUGH_1_INSTALLED = True
        '    End If
        '    Exit Sub
        'End If
        'If nameAttr.Value = "RoughPumpMachine2" Then
        '    If Boolean.TryParse(IsInstallAtt.Value, RobotConfigurationValues.ROUGH_2_INSTALLED) = False Then
        '        RobotConfigurationValues.ROUGH_2_INSTALLED = False
        '    End If
        '    Exit Sub
        'End If

        If nameAttr.Value = "LLAPumpPackage" Then
            If (typeAtt IsNot Nothing) AndAlso typeAtt.Value.ToString() = "Turbo" Then
                RobotConfigurationValues.LLA_TURBO_VISIBLE = True
                RobotConfigurationValues.LLA_CRYO_VISIBLE = False
            ElseIf (typeAtt IsNot Nothing) AndAlso typeAtt.Value.ToString() = "Cryo" Then
                RobotConfigurationValues.LLA_CRYO_VISIBLE = True
                RobotConfigurationValues.LLA_TURBO_VISIBLE = False
            Else
                RobotConfigurationValues.LLA_TURBO_VISIBLE = False
                RobotConfigurationValues.LLA_CRYO_VISIBLE = False
                RobotConfigurationValues.LLA_HIVAC_INSTALLED = False
            End If
            Dim bInstall As Boolean = True
            If Boolean.TryParse(IsInstallAtt.Value, bInstall) = False Then
                Exit Sub
            End If
            If Not bInstall Then
                RobotConfigurationValues.LLA_TURBO_VISIBLE = False
                RobotConfigurationValues.LLA_CRYO_VISIBLE = False
                RobotConfigurationValues.LLA_HIVAC_INSTALLED = False
            End If
        End If

        If nameAttr.Value = "TMPumpPackage" Then
            If (typeAtt IsNot Nothing) AndAlso typeAtt.Value.ToString() = "Turbo" Then
                RobotConfigurationValues.TMTURBO_VISIBLE = True
                RobotConfigurationValues.TMCRYO_VISIBLE = False
            ElseIf (typeAtt IsNot Nothing) AndAlso typeAtt.Value.ToString() = "Cryo" Then
                RobotConfigurationValues.TMCRYO_VISIBLE = True
                RobotConfigurationValues.TMTURBO_VISIBLE = False
            Else
                RobotConfigurationValues.TMTURBO_VISIBLE = False
                RobotConfigurationValues.TMCRYO_VISIBLE = False
                RobotConfigurationValues.TM_HIVAC_INSTALLED = False
            End If
            Dim bInstall As Boolean = True
            If Boolean.TryParse(IsInstallAtt.Value, bInstall) = False Then
                Exit Sub
            End If
            If Not bInstall Then
                RobotConfigurationValues.TMCRYO_VISIBLE = False
                RobotConfigurationValues.TMTURBO_VISIBLE = False
                RobotConfigurationValues.TM_HIVAC_INSTALLED = False
            End If
        End If

        If IsSensorInstalled IsNot Nothing AndAlso IsSensorInstalled.Name = ConstEnum.IsSensorInstalled Then
            If Boolean.TryParse(IsSensorInstalled.Value, RobotConfigurationValues.ROBOT_SENSOR_INSTALLED) = False Then
                RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False
                Exit Sub
            End If
        End If

        If (nameAttr Is Nothing) Then
            Log.dataManagementLogger.Error("Attribute " & ConstEnum.Name & " is not found in " & conNode.Name)
            Return
        End If
        If (ipAddressAttr Is Nothing) Then
            Log.dataManagementLogger.Error("Attribute " & ConstEnum.EthernetIP & " is not found in " & conNode.Name)
            Return
        End If
        If (portAttr Is Nothing) Then
            Log.dataManagementLogger.Error("Attribute " & ConstEnum.Port & " is not found in " & conNode.Name)
            Return
        End If
        If (IsInstallAtt Is Nothing) Then
            Log.dataManagementLogger.Error("Attribute " & ConstEnum.ISINSTALLED & " is not found in " & conNode.Name)
            Return
        End If

        If (IsManualDoorElevatorAtt IsNot Nothing) Then
            IsManualDoorElevator = CType(IsManualDoorElevatorAtt.Value, Boolean)
        End If

        If (typeAtt IsNot Nothing) Then
            typeofPM = typeAtt.Value.ToString()
        End If
        If (ConfigFolderAtt IsNot Nothing) Then
            configFolder = ConfigFolderAtt.Value.ToString()
        End If
        If (RecipeFolderAtt IsNot Nothing) Then
            recipeFolder = RecipeFolderAtt.Value.ToString()
        End If

        If (Version IsNot Nothing) Then
            sVersion = Version.Value.ToString()
        End If

        svr = New Server(nameAttr.Value, _
                          ipAddressAttr.Value, _
                          portAttr.Value, _
                          CType(IsInstallAtt.Value, Boolean), _
                          IsManualDoorElevator, _
                          configFolder, recipeFolder, typeofPM, sVersion)

        mapConnections.Add(nameAttr.Value, svr)
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-02</date>
    ''' </author>
    ''' <summary>
    ''' NOTE READ KEPSERVERDEVICE AFTER READ LL/TM CONFIG
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub AddKepServerDevice(ByVal conNode As Xml.XmlNode)
        AVPLib.Log.avpLogger.Info("Enter AddKepServerDevice")
        Try
            Dim nameAttr As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.Name)
            Dim IsInstallAtt As Xml.XmlAttribute = conNode.Attributes.ItemOf(ConstEnum.ISINSTALLED)

            Select Case nameAttr.InnerText
                Case "LLATurbo"
                    RobotConfigurationValues.LLA_TURBO_VISIBLE = False
                Case "TMTurbo"
                    If Boolean.TryParse(IsInstallAtt.Value, RobotConfigurationValues.TMTURBO_VISIBLE) = False Then
                        RobotConfigurationValues.TMTURBO_VISIBLE = False
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.Message.ToString)
        End Try
        AVPLib.Log.avpLogger.Info("Leave AddKepServerDevice")
    End Sub
End Class

