Imports AVPLib.ConstEnum

Public Class TimeoutLib
    ''' <author>
    '''    	<name>Ngo Cao Dinh</name>
    '''    	<date> 2008-11-27</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get timeout config from xml file
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
                    Dim nodePolling As System.Xml.XmlNode = nodeListPolling.Item(e)
                    Dim Name As String = nodePolling.Attributes.ItemOf("Name").Value
                    Dim Interval As Integer = 0
                    If IsNumeric((nodePolling.Attributes.ItemOf("Timeout").Value)) Then
                        If (Integer.Parse(nodePolling.Attributes.ItemOf("Timeout").Value)) >= TIMEOUT_DEFAULT_VAL Then
                            Interval = Integer.Parse(nodePolling.Attributes.ItemOf("Timeout").Value)
                        Else
                            AVPLib.Log.coreLogger.Error("Invalid Timeout value with " + Name + " -> Use default value:" & TIMEOUT_DEFAULT_VAL.ToString())
                            Interval = TIMEOUT_DEFAULT_VAL
                        End If
                    Else
                        AVPLib.Log.coreLogger.Error("Invalid Timeout value " + Name + " -> Use default value:" & TIMEOUT_DEFAULT_VAL.ToString())
                        Interval = TIMEOUT_DEFAULT_VAL
                    End If
                    map.Add(Name, Interval)
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

    Public Shared Function GetConfigFromCode() As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetConfig From Code")
        Dim map As New Hashtable()
        Try
            map.Add(ConstEnum.Equipments.LLAPumpPackage.ToString(), SYSTEM_CONFIG_TIMEOUT_VALUES.LLA_CRYO_TIMEOUT) 'LLA_CRYO
            map.Add(ConstEnum.Equipments.TMPumpPackage.ToString(), SYSTEM_CONFIG_TIMEOUT_VALUES.TM_CRYO_TIMEOUT)   'TM_CRYO
            map.Add(ConstEnum.Equipments.TMWaterPump.ToString(), SYSTEM_CONFIG_TIMEOUT_VALUES.TM_WATER_PUMP_TIMEOUT)   'TM_WATER_PUMP
            map.Add(ConstEnum.Equipments.LLAElevator.ToString(), SYSTEM_CONFIG_TIMEOUT_VALUES.LLA_ELEVATOR_TIMEOUT)  'LLA_ELEVATOR
            map.Add(ConstEnum.Equipments.Robot.ToString(), SYSTEM_CONFIG_TIMEOUT_VALUES.ROBOT_TIMEOUT)   'ROBOT
            map.Add(ConstEnum.Equipments.Aligner.ToString(), SYSTEM_CONFIG_TIMEOUT_VALUES.ALIGNER_TIMEOUT)   'ALGINER
            map.Add(ConstEnum.LLELEVATOR_TIMEOUT, SYSTEM_CONFIG_TIMEOUT_VALUES.LL_ELEVATOR_REQUEST_STATUS_TIMEOUT)    'LL_EVELATOR_REQUEST_STATUS
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetConfig")
        Return map
    End Function
End Class
