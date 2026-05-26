Imports AVPLib.ConstEnum
Public Class PollingLib
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
    ''' GetConfig
    ''' </summary>
    ''' <param name="PollingDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetConfig(ByVal root As System.Xml.XmlNode) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetConfig")
        Dim map As New Hashtable()
        Try
            Dim nodeListPolling As System.Xml.XmlNodeList = root.ChildNodes

            For e As Integer = 0 To nodeListPolling.Count - 1
                Try
                    Dim nodePolling As System.Xml.XmlNode
                    Dim Name As String = String.Empty
                    Dim Interval As Integer = 0
                    Dim IsLog As Boolean

                    nodePolling = nodeListPolling.Item(e)
                    Name = nodePolling.Attributes.ItemOf("Name").Value 'And Integer.Parse
                    Select Case Name
                        Case ConstEnum.Equipments.LLAPumpPackage.ToString()
                            Interval = SYSTEM_CONFIG_POLLING_VALUES.LLA_CRYO_POLLING
                        Case ConstEnum.Equipments.TMPumpPackage.ToString()
                            Interval = SYSTEM_CONFIG_POLLING_VALUES.TM_CRYO_POLLING
                        Case ConstEnum.Equipments.TMWaterPump.ToString()
                            Interval = SYSTEM_CONFIG_POLLING_VALUES.TM_WATER_PUMP_POLLING
                        Case ConstEnum.Equipments.LLAElevator.ToString()
                            Interval = SYSTEM_CONFIG_POLLING_VALUES.LLA_ELEVATOR_POLLING
                        Case ConstEnum.Equipments.Robot.ToString()
                            Interval = SYSTEM_CONFIG_POLLING_VALUES.ROBOT_POLLING
                        Case ConstEnum.Equipments.Aligner.ToString()
                            Interval = SYSTEM_CONFIG_POLLING_VALUES.ALIGNER_POLLING
                        Case PVD_POLLING_STATUS_REPORT
                            Interval = SYSTEM_CONFIG_POLLING_VALUES.PVD_STATUS_REPORT_POLLING
                        Case IBE_POLLING_CMD
                            Interval = SYSTEM_CONFIG_POLLING_VALUES.IBE_POLLING_CMD_POLLING
                        Case PVD5T_POLLING_CMD
                            Interval = SYSTEM_CONFIG_POLLING_VALUES.PVD5T_POLLING_CMD_POLLING
                        Case Else
                            If IsNumeric(nodePolling.Attributes.ItemOf("Timeout").Value) Then
                                If CInt(nodePolling.Attributes.ItemOf("Timeout").Value) >= POLLING_DEFAULT_VALUE Then
                                    Interval = Integer.Parse(nodePolling.Attributes.ItemOf("Timeout").Value)
                                Else
                                    AVPLib.Log.coreLogger.Error("Invalid Timeout Value with " + Name + " -> Use default value" + POLLING_DEFAULT_VALUE.ToString())
                                    Interval = POLLING_DEFAULT_VALUE
                                End If
                            Else
                                AVPLib.Log.coreLogger.Error("Invalid Timeout Value with " + Name + " -> Use default value" + POLLING_DEFAULT_VALUE.ToString())
                                Interval = POLLING_DEFAULT_VALUE
                            End If
                    End Select

                    If UCase(nodePolling.Attributes.ItemOf("IsLog").Value) = "TRUE" Or UCase(nodePolling.Attributes.ItemOf("IsLog").Value) = "FALSE" Then
                        IsLog = Boolean.Parse(nodePolling.Attributes.ItemOf("IsLog").Value)
                    Else
                        AVPLib.Log.coreLogger.Error("Invalid IsLog Value with " + Name + " -> Use default value" + POLLING_DEFAULT_VALUE.ToString())
                        IsLog = False
                    End If
                    map.Add(Name, New Polling(Name, Interval, IsLog))
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Error(ex.Message)
                End Try
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetConfig")
        Return map
    End Function

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' SaveConfig
    ''' </summary>
    ''' <param name="PollingDoc"></param>
    ''' <param name="mapPolling"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Shared Function SaveConfig(ByVal xmlDocument As System.Xml.XmlDocument, ByVal mapPolling As Hashtable) As Boolean
    '    AVPLib.Log.coreLogger.Info("Enter SaveConfig")
    '    Try
    '        Dim root As System.Xml.XmlNode = xmlDocument.SelectSingleNode(ConstEnum.XPATH_SYSTEMPOLLING)
    '        Dim nodeListPolling As System.Xml.XmlNodeList = root.ChildNodes

    '        For e As Integer = 0 To nodeListPolling.Count - 1
    '            Try
    '                Dim nodePolling As System.Xml.XmlNode = nodeListPolling.Item(e)
    '                Dim Name As String = nodePolling.Attributes.ItemOf("Name").Value
    '                Dim Timeout As Polling = mapPolling.Item(Name)
    '                If Timeout IsNot Nothing Then
    '                    If CDbl(Timeout.Interval) >= POLLING_DEFAULT_VALUE Then
    '                        nodePolling.Attributes.ItemOf("Timeout").Value = Timeout.Interval.ToString()
    '                    Else
    '                        nodePolling.Attributes.ItemOf("Timeout").Value = POLLING_DEFAULT_VALUE
    '                    End If

    '                    nodePolling.Attributes.ItemOf("IsLog").Value = Timeout.IsLog.ToString()
    '                End If
    '            Catch ex As Exception
    '                AVPLib.Log.coreLogger.Info("Error in insert data: " & ex.Message)
    '            End Try
    '        Next

    '        'xmlDocument.Save(ContainerDAO.FPath_SystemConfig)
    '        BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, xmlDocument)
    '        AVPLib.Log.coreLogger.Info("Leave SaveConfig")
    '        Return True
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.coreLogger.Info("Leave SaveConfig")
    '    Return False
    'End Function
End Class
