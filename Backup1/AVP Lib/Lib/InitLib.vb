Public Class InitLib
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
    ''' Get elevator,Robot,Aligner initialaztion config from xml file
    ''' </summary>
    ''' <param name="ConfigDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetConfig(ByVal root As System.Xml.XmlNode) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetConfig")
        Dim mapInit As New Hashtable()
        Try
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For e As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(e)
                Dim nodeInits As System.Xml.XmlNodeList = node.ChildNodes
                Dim ListNodeInits As ArrayList = New ArrayList()
                For i As Integer = 0 To nodeInits.Count - 1
                    Dim nodeInit As System.Xml.XmlNode = nodeInits.Item(i)
                    If Not nodeInit.NodeType = Xml.XmlNodeType.Comment Then
                        Dim NameInit As String = nodeInit.Attributes.ItemOf("Name").Value
                        ListNodeInits.Add(NameInit)
                    End If
                Next
                mapInit.Add(node.Name, ListNodeInits)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetConfig")
        Return mapInit
    End Function

    Public Shared Function GetConfigFromCode(ByVal root As System.Xml.XmlNode) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetConfig")
        Dim mapInit As New Hashtable()
        Try
            'Add IBE Command Pulling
            mapInit.Add(ConstEnum.STR_IBE, SYSTEM_CONFIG_INIT_VALUES.IBE_PULLING_COMMAND_ARRAY)
#If AVP_PLATFORM = "CX" Then
            'Add LL Elevator
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            If nodeList.Count < ConstEnum.MaxELEVATOR_VC_CONFIG Then
                ContainerData.Search_And_Append_System_Values("Elevator_VC_Config", root)
            End If
            For e As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(e)
                Dim nodeInits As System.Xml.XmlNodeList = node.ChildNodes
                Dim ListNodeInits As ArrayList = New ArrayList()
                Dim strValue As String = String.Empty
                If node.Name.Contains("Elevator") Then
                    If node.ChildNodes.Count < ConstEnum.MaxLLELEVATOR_VC_CONFIG Then
                        ContainerData.Search_And_Append_System_Values("LLElevator_VC", node)
                    End If
                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_ER_INIT)
                    If Not node.Name.Contains("Elevator_VC2") Then ''VC4,VC6
                        ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_EC_N_INIT)

                        'add mode
                        If node.Name.Contains("Elevator_VC6") Then
                            ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_SPS_MODE)
                            ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_INTLCK_CASS_PRESENT_DIS_INIT)
                        End If

                        For i As Integer = 0 To node.ChildNodes.Count - 1
                            If node.ChildNodes(i).Attributes.Item(0).Name = ConstEnum.SCFNS_VALUE Then
                                strValue = node.ChildNodes(i).Attributes.ItemOf(ConstEnum.SCFNS_VALUE).Value
                                If Not String.IsNullOrEmpty(strValue) AndAlso strValue.ToUpper = Boolean.TrueString.ToUpper Then
                                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_CF_NS_INIT & strValue)
                                End If
                            End If

                            If node.ChildNodes(i).Attributes.Item(0).Name = ConstEnum.SCFLM_VALUE Then
                                strValue = node.ChildNodes(i).Attributes.ItemOf(ConstEnum.SCFLM_VALUE).Value
                                If Not String.IsNullOrEmpty(strValue) AndAlso strValue.ToUpper = Boolean.TrueString.ToUpper Then
                                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_CF_LM_INIT & strValue)
                                End If
                            End If

                            If node.ChildNodes(i).Attributes.Item(0).Name = ConstEnum.SCFPT_VALUE Then
                                strValue = node.ChildNodes(i).Attributes.ItemOf(ConstEnum.SCFPT_VALUE).Value
                                If Not String.IsNullOrEmpty(strValue) AndAlso strValue.ToUpper = Boolean.TrueString.ToUpper Then
                                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_CF_PT_INIT & strValue)
                                End If
                            End If

                            If node.ChildNodes(i).Attributes.Item(0).Name = ConstEnum.SCFCT_VALUE Then
                                strValue = node.ChildNodes(i).Attributes.ItemOf(ConstEnum.SCFCT_VALUE).Value
                                If Not String.IsNullOrEmpty(strValue) AndAlso strValue.ToUpper = Boolean.TrueString.ToUpper Then
                                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_CF_CT_INIT & strValue)
                                End If
                            End If

                            If node.ChildNodes(i).Attributes.Item(0).Name = ConstEnum.SFB_VALUE Then
                                strValue = node.ChildNodes(i).Attributes.ItemOf(ConstEnum.SFB_VALUE).Value
                                If Not String.IsNullOrEmpty(strValue) AndAlso strValue.ToUpper = Boolean.TrueString.ToUpper Then
                                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_FB_INIT & strValue)
                                End If
                            End If
                        Next
                    Else ''special for VC2
                        For i As Integer = 0 To node.ChildNodes.Count - 1
                            If node.ChildNodes(i).Attributes.Item(0).Name = ConstEnum.SCFNS_VALUE Then
                                strValue = node.ChildNodes(i).Attributes.ItemOf(ConstEnum.SCFNS_VALUE).Value
                                If Not String.IsNullOrEmpty(strValue) AndAlso strValue.ToUpper = Boolean.TrueString.ToUpper Then
                                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_VC2_00_S_CF_NS_INIT & strValue)
                                End If
                            End If
                            If node.ChildNodes(i).Attributes.Item(0).Name = ConstEnum.SCFLM_VALUE Then
                                strValue = node.ChildNodes(i).Attributes.ItemOf(ConstEnum.SCFLM_VALUE).Value
                                If Not String.IsNullOrEmpty(strValue) AndAlso strValue.ToUpper = Boolean.TrueString.ToUpper Then
                                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_VC2_00_S_CF_LM_INIT & strValue)
                                End If
                            End If
                            If node.ChildNodes(i).Attributes.Item(0).Name = ConstEnum.SCFPT_VALUE Then
                                strValue = node.ChildNodes(i).Attributes.ItemOf(ConstEnum.SCFPT_VALUE).Value
                                If Not String.IsNullOrEmpty(strValue) AndAlso strValue.ToUpper = Boolean.TrueString.ToUpper Then
                                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_VC2_00_S_CF_PT_INIT & strValue)
                                End If
                            End If
                            If node.ChildNodes(i).Attributes.Item(0).Name = ConstEnum.SCFCT_VALUE Then
                                strValue = node.ChildNodes(i).Attributes.ItemOf(ConstEnum.SCFCT_VALUE).Value
                                If Not String.IsNullOrEmpty(strValue) AndAlso strValue.ToUpper = Boolean.TrueString.ToUpper Then
                                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_VC2_00_S_CF_CT_INIT & strValue)
                                End If
                            End If
                            If node.ChildNodes(i).Attributes.Item(0).Name = ConstEnum.SFB_VALUE Then
                                strValue = node.ChildNodes(i).Attributes.ItemOf(ConstEnum.SFB_VALUE).Value
                                If Not String.IsNullOrEmpty(strValue) AndAlso strValue.ToUpper = Boolean.TrueString.ToUpper Then
                                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_VC2_00_S_FB_INIT & strValue)
                                End If
                            End If
                        Next

                    End If

                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_ER_INIT)
                    ListNodeInits.Add(SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_A_HM_INIT)
                Else
                    For i As Integer = 0 To nodeInits.Count - 1
                        Dim nodeInit As System.Xml.XmlNode = nodeInits.Item(i)
                        If Not nodeInit.NodeType = Xml.XmlNodeType.Comment Then
                            Dim NameInit As String = nodeInit.Attributes.ItemOf("Name").Value
                            ListNodeInits.Add(NameInit)
                        End If
                    Next
                End If
                mapInit.Add(node.Name, ListNodeInits)
            Next

            'Add Robot, Aligner Command
            mapInit.Add(ConstEnum.Equipments.Robot.ToString(), SYSTEM_CONFIG_INIT_VALUES.ROBOT_COMMAND_ARRAY)
            If (RobotConfigurationValues.ALIGNER_AT_PACKET_MODE) Then
                mapInit.Add(ConstEnum.Equipments.Aligner.ToString(), SYSTEM_CONFIG_INIT_VALUES.ALIGNER_COMMAND_ARRAY)
            Else
                mapInit.Add(ConstEnum.Equipments.Aligner.ToString(), SYSTEM_CONFIG_INIT_VALUES.ALIGNER_MONITOR_COMMAND_ARRAY)
            End If
#End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetConfig")
        Return mapInit
    End Function
End Class
