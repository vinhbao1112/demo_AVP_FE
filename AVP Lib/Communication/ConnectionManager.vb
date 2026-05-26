Imports System.Diagnostics
Imports System.IO

Namespace Communication
    Public Class ConnectionManager

#Region "Class Constants & Variables"
        Private Const CONNECTIONNUM As Integer = 13
        Private Shared m_htbConnections As Hashtable
#End Region

#Region "Public Method"

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Initialize()
            AVPLib.Log.terminalServerLogger.Info("Enter Initialize")

            Try
                m_htbConnections = New Hashtable
                CreateConnectionList()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave Initialize")
        End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Close all connection and remove them out of hashtable
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Dispose()
            Try
                Dim ConnectionElement As DictionaryEntry
                Dim CurrentConnection As Connection
                For Each ConnectionElement In m_htbConnections
                    CurrentConnection = CType(ConnectionElement.Value, Connection)
                    CurrentConnection.Close()
                Next ConnectionElement
                m_htbConnections.Clear()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Close all connection and remove them out of hashtable
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetConnection(ByVal EquipmentName As String) As Connection
            AVPLib.Log.terminalServerLogger.Info("Enter GetConnection")

            Dim result As Connection = Nothing
            Try
                If (m_htbConnections.ContainsKey(EquipmentName)) Then
                    result = m_htbConnections.Item(EquipmentName)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave GetConnection")
            Return result
        End Function
#End Region

#Region "Private Method"
        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-28-04</date>
        ''' </author>
        ''' <summary>
        ''' Create a new connection based on its identifier(Equipment Name).
        ''' </summary>
        ''' <param name="equipmentName"></param>
        ''' <remarks></remarks>
        Private Shared Function CreateConnection(ByVal equipmentName As String, ByVal strIpAddress As String, ByVal nPort As Integer, Optional ByVal strType As String = "") As Connection
            Dim connection As Connection = Nothing
            If (equipmentName = ConstEnum.Equipments.KepServer.ToString()) Then
                connection = New KEPServerConnection()
            ElseIf (equipmentName.IndexOf(ConstEnum.Chamber) >= 0) Then ''create IBE connection
                Dim chamberModule As AVPLib.SystemModule = Nothing
                If (AVPLib.ContainerData.IsChamberVisible(equipmentName, chamberModule)) Then
                    Dim ibeConn As PMServerConnection = New PMServerConnection(chamberModule.Type, strIpAddress, nPort)
                    ibeConn.EquipmentName = equipmentName
                    If chamberModule.IBE_Type = ConstEnum.IBEType.VEECO_IBE Then
                        ibeConn.IsKeepAliveMode = False ''default AVP_IBE/PVD = True
                    End If
                    connection = ibeConn
                End If
            ElseIf equipmentName = ConstEnum.Equipments.DeviceNetApp.ToString() Then
                Dim deviceNetAppConn As PMServerConnection = New PMServerConnection(SystemModule.ModuleType.DeviceNetApp, strIpAddress, nPort)
                deviceNetAppConn.EquipmentName = equipmentName
                connection = deviceNetAppConn
            ElseIf equipmentName.Contains("PumpPackage") AndAlso strType = "Turbo" Then
                Dim binConn As BinConnection = New BinConnection()
                binConn.EquipmentName = equipmentName
                binConn.IPAddress = strIpAddress
                binConn.Port = nPort
                connection = binConn
            Else
                Dim terminalConn As TerminalServerConnection = New TerminalServerConnection()
                terminalConn.EquipmentName = equipmentName
                terminalConn.IPAddress = strIpAddress
                terminalConn.Port = nPort

                If (strType.IndexOf(ConstEnum.Cryo) > -1) _
                    OrElse (equipmentName.Contains("Elevator")) _
                        OrElse (equipmentName.Contains("WaterPump") _
                        OrElse (equipmentName.Contains("RoughPumpMachine"))) Then
                    terminalConn.SentSuffix = vbCr
                Else
                    terminalConn.SentSuffix = vbLf & vbCr
                End If

                connection = terminalConn
            End If
            Return connection
        End Function

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-28-04</date>
        ''' </author>
        ''' <summary>
        ''' Add a new connection to ConnectionManager with its identifier(Equipment Name).
        ''' </summary>
        ''' <param name="equipmentName"></param>
        ''' <remarks></remarks>
        Private Shared Sub AddConnection(ByVal equip As ConstEnum.Equipments, ByVal tbConnections As Hashtable)
            Dim serverInfo As Server = Nothing
            Dim serverPort As Int32 = 0
            Dim strEquipment As String = equip.ToString()
            serverInfo = DataManagerment.ConfigurationManager.GetConfigItem(strEquipment)
            If (serverInfo IsNot Nothing) Then
                If (equip = ConstEnum.Equipments.KepServer) Then
                    If RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                        Dim conn As Connection = CreateConnection(strEquipment, String.Empty, 0)
                        tbConnections.Add(strEquipment, conn)
                        conn.Open()
                    End If
                Else
                    If Not (String.IsNullOrEmpty(serverInfo.EthernetIP)) Then
                        If (Int32.TryParse(serverInfo.Port, serverPort)) Then
                            Try
                                Dim conn As Connection = CreateConnection(strEquipment, serverInfo.EthernetIP, serverInfo.Port, serverInfo.Type)
                                If (conn IsNot Nothing) Then
                                    tbConnections.Add(strEquipment, conn)
                                    conn.Open()
                                Else
                                    AVPLib.Log.coreLogger.Error("Could not create a connection for the equipment " & strEquipment)
                                End If
                            Catch ex As Exception
                                AVPLib.Log.coreLogger.Error(ex.ToString())
                            End Try
                        Else
                            AVPLib.Log.coreLogger.Error(String.Format("invalid port number {0} for equipment " & strEquipment, serverInfo.Port))
                        End If
                    Else
                        AVPLib.Log.coreLogger.Error("IP address for equipment " & strEquipment & " is empty")
                    End If
                End If
            Else
                AVPLib.Log.coreLogger.Error("No server info for the equipment " & strEquipment)
            End If
        End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>       
        ''' <summary>
        ''' Create all connection to all equipments
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub CreateConnectionList()
            AVPLib.Log.terminalServerLogger.Info("Enter CreateConnectionList")
            Try
                ' KepServer is always the first guy.
                AddConnection(ConstEnum.Equipments.KepServer, m_htbConnections)
                ' Turn Off Alarm Light.
                Utils.TurnAlarm_RedLightOnOff(True, True)
                '-------------------------
                ' LoadLockA
                AddConnection(ConstEnum.Equipments.LLAElevator, m_htbConnections)

                'If RobotConfigurationValues.LLA_CRYO_VISIBLE Then
                ' LLA Cryo
                If RobotConfigurationValues.LLA_CRYO_VISIBLE Or RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                    AddConnection(ConstEnum.Equipments.LLAPumpPackage, m_htbConnections)
                End If

                'ElseIf RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                '    AddConnection(ConstEnum.Equipments.LLATurbo, m_htbConnections)
                'End If

                ' TMWaterPump visible
                If (AVPLib.RobotConfigurationValues.TMWATERPUM_VISIBLE) Then
                    'add water pump c
                    AddConnection(ConstEnum.Equipments.TMWaterPump, m_htbConnections)
                End If

                ' TM mechanical Pump
                If AVPLib.RobotConfigurationValues.MPUMP1_SERIAL_VISIBLE Then
                    AddConnection(ConstEnum.Equipments.RoughPumpMachine1, m_htbConnections)
                End If

                ' LL mechanical Pump
                If AVPLib.RobotConfigurationValues.MPUMP2_SERIAL_VISIBLE Then
                    AddConnection(ConstEnum.Equipments.RoughPumpMachine2, m_htbConnections)
                End If

                ' Robot
                AddConnection(ConstEnum.Equipments.Robot, m_htbConnections)

                ' TM Cryo
                'If (AVPLib.RobotConfigurationValues.TMCRYO_VISIBLE) Then
                If RobotConfigurationValues.TMCRYO_VISIBLE Or RobotConfigurationValues.TMTURBO_VISIBLE Then
                    AddConnection(ConstEnum.Equipments.TMPumpPackage, m_htbConnections)
                End If

                'ElseIf RobotConfigurationValues.TMTURBO_VISIBLE Then
                'AddConnection(ConstEnum.Equipments.TMTurbo, m_htbConnections)
                'End If

                ' Aligner
                If RobotConfigurationValues.ALINER_VISIBLE Then
                    AddConnection(ConstEnum.Equipments.Aligner, m_htbConnections)
                End If

                ' Chamber1 visible
                If (AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE) Then
                    AddConnection(ConstEnum.Equipments.Chamber1, m_htbConnections)
                End If
                ' Chamber2 visible
                If (AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE) Then
                    AddConnection(ConstEnum.Equipments.Chamber2, m_htbConnections)
                End If
                ' Chamber3 visible
                If (AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE) Then
                    AddConnection(ConstEnum.Equipments.Chamber3, m_htbConnections)
                End If

                ' DeviceNetApp
                If (AVPLib.RobotConfigurationValues.DEVICENETAPP_VISIBLE) Then
                    Dim pName As Process() = Process.GetProcessesByName("DeviceNetApp")

                    If (pName.Length = 0) Then
                        If (Not File.Exists("DeviceNetApp.exe")) Then
                            AVPLib.Log.coreLogger.Error("Can't not run DeviceNet App")
                            Exit Sub
                        End If

                        Dim deviceNetApp As New Process()
                        deviceNetApp.StartInfo.FileName = "DeviceNetApp.exe"
                        deviceNetApp.Start()
                        deviceNetApp.WaitForExit(3000)
                    End If

                    AddConnection(ConstEnum.Equipments.DeviceNetApp, m_htbConnections)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave CreateConnectionList")
        End Sub
#End Region
    End Class

End Namespace
