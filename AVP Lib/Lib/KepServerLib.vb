Public Class KepServerLib
    Const Alarm_Orange_Status As String = "Alarm.OrangeStatus"
    Const Alarm_Blue_Status As String = "Alarm.BlueStatus"

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' GetConfigurationKepServer--> for IO Panel 
    ''' </summary>
    ''' <param name="KepServerDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetKepServer(ByVal root As System.Xml.XmlNode) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetKepServer")
        Dim ListGroup As New ArrayList()
        Try
            'Dim root As System.Xml.XmlNode = KepServerDoc.FirstChild
            Dim nodeListServerGroup As System.Xml.XmlNodeList = root.ChildNodes

            For groupIdx As Integer = 0 To nodeListServerGroup.Count - 1
                Dim nodeServerGroup As System.Xml.XmlNode = nodeListServerGroup.Item(groupIdx)
                Dim nodeListItem As System.Xml.XmlNodeList = nodeServerGroup.ChildNodes

                Dim ListItems As ArrayList = New ArrayList()
                For itemIdx As Integer = 0 To nodeListItem.Count - 1
                    Dim nodeItem As System.Xml.XmlNode = nodeListItem.Item(itemIdx)
                    If (nodeItem.Name = "Item") Then
                        Dim attrDisplayGroup As Xml.XmlAttribute = nodeItem.Attributes.ItemOf("DisplayGroup")
                        Dim attrPropertyName As Xml.XmlAttribute = nodeItem.Attributes.ItemOf("PropertyName")
                        Dim attrKepServerName As Xml.XmlAttribute = nodeItem.Attributes.ItemOf("KepServerName")
                        Dim attrDataType As Xml.XmlAttribute = nodeItem.Attributes.ItemOf("DataType")
                        Dim attrDesc As Xml.XmlAttribute = nodeItem.Attributes.ItemOf("Desc")
                        Dim DisplayGroup As String = IIf(attrDisplayGroup Is Nothing, "TM.TMC", attrDisplayGroup.Value)
                        Dim PropertyName As String = IIf(attrPropertyName Is Nothing, String.Empty, attrPropertyName.Value)
                        Dim KepServerName As String = IIf(attrKepServerName Is Nothing, String.Empty, attrKepServerName.Value)
                        Dim DataType As String = IIf(attrDataType Is Nothing, String.Empty, attrDataType.Value)
                        Dim Desc As String = IIf(attrDesc Is Nothing, String.Empty, attrDesc.Value)

                        ''check for light alarm
                        If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = ConstEnum.FOURLIGHTALARM Then
                            If PropertyName.Contains(Alarm_Orange_Status) Then
                                KepServerName = "TM.TMC.RO.System_Warning"
                            End If

                            If PropertyName.Contains(Alarm_Blue_Status) Then
                                KepServerName = "TM.TMC.RO.System_Idle"
                            End If
                        Else
                            If PropertyName.Contains(Alarm_Blue_Status) Then
                                Continue For
                            End If
                        End If

                        ListItems.Add(New KepServerItem(DisplayGroup, PropertyName, KepServerName, DataType, Desc))
                    End If
                Next

                Dim GroupName As String = nodeServerGroup.Attributes.ItemOf("Name").Value
                Dim IsActive As Boolean = Boolean.Parse(nodeServerGroup.Attributes.ItemOf("IsActive").Value)
                Dim DeadBand As Integer = Integer.Parse(nodeServerGroup.Attributes.ItemOf("DeadBand").Value)
                Dim UpdateRate As Integer = Integer.Parse(nodeServerGroup.Attributes.ItemOf("UpdateRate").Value)

                ListGroup.Add(New KepServerGroup(GroupName, IsActive, DeadBand, UpdateRate, ListItems))
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetKepServer")
        Return ListGroup
    End Function


    Public Shared Function GetConfigurableKepServer(ByVal root As System.Xml.XmlNode, ByRef actions As Hashtable, ByRef statuses As Hashtable) As Boolean
        Const Action_Node_Type As String = "Action"
        Const Status_Node_Type As String = "Status"
        AVPLib.Log.coreLogger.Info("Enter GetConfigurableKepServer")
        Dim bRet As Boolean = False
        actions = New Hashtable()
        statuses = New Hashtable()
        Try
            'Dim root As System.Xml.XmlNode = configurableKepServerDoc.FirstChild
            For Each node As Xml.XmlNode In root.ChildNodes
                If (node.Name = Action_Node_Type) Or (node.Name = Status_Node_Type) Then
                    Dim atrName As Xml.XmlAttribute = node.Attributes.ItemOf("Name")
                    Dim atrValue As Xml.XmlAttribute = node.Attributes.ItemOf("Value")
                    If (Not atrName Is Nothing) And (Not atrValue Is Nothing) Then

                        ''check for light alarm
                        If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = ConstEnum.FOURLIGHTALARM Then
                            If atrName.Value.Contains(Alarm_Orange_Status) Then
                                atrValue.Value = atrValue.Value.Replace("System_Idle", "System_Warning")
                            End If

                            If atrName.Value.Contains(Alarm_Blue_Status) Then
                                atrValue.Value = atrValue.Value.Replace("System_Warning", "System_Idle")
                            End If
                        Else
                            If atrName.Value.Contains(Alarm_Blue_Status) Then
                                Continue For
                            End If
                        End If

                        If node.Name = Action_Node_Type Then
                            actions.Add(atrName.Value, atrValue.Value)
                        ElseIf node.Name = Status_Node_Type Then
                            ' reverse position.
                            statuses.Add(atrValue.Value, atrName.Value)
                        End If
                    End If
                End If
            Next
            bRet = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetConfigurableKepServer")
        Return bRet
    End Function
End Class
