Namespace Driver
    Public Class DriverUtility
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' Update Data Status to EQ and GUI
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateDataStatus(ByVal EQName As String, ByVal sPropertyName As String, ByVal value As Object)
            AVPLib.Log.coreLogger.Info("Enter UpdateDataStatus")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add(sPropertyName)
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(EQName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdateDataStatus")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Read and register kepware 
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub ReadKepwareConfig(ByVal XPATH_KepServerTag As String)
            AVPLib.Log.avpLogger.Info("Enter KepwareIsolationValveDriver.ReadKepwareConfig")
            Try
                Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_KepServerTag)

                For Each Item As System.Xml.XmlNode In root.ChildNodes
                    If (Item.Attributes.Count = 2) Then
                        Dim attName As Xml.XmlAttribute = Item.Attributes(0)
                        Dim attValue As Xml.XmlAttribute = Item.Attributes(1)
                        If (Item.Name = "Action") Then
                            AddKepwareAction(attName.Value, attValue.Value)
                        ElseIf (Item.Name = "Status") Then
                            AddKepwareStatus(attName.Value, attValue.Value)
                        End If
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave KepwareIsolationValveDriver.ReadKepwareConfig")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Read and register kepware 
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub RegisterKepwareReadback(ByVal sGroupName As String, ByVal XPATH_KepServerReadbackTag As String)
            AVPLib.Log.avpLogger.Info("Enter KepwareIsolationValveDriver.RegisterKepwareReadback")
            Try
                Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_KepServerReadbackTag)

                For Each Item As System.Xml.XmlNode In root.ChildNodes
                    If (Item.Attributes.Count = 5) Then
                        Dim attName As Xml.XmlAttribute = Item.Attributes(0)
                        Dim attPropertyName As Xml.XmlAttribute = Item.Attributes(1)
                        Dim attKepServerName As Xml.XmlAttribute = Item.Attributes(2)
                        Dim attDataType As Xml.XmlAttribute = Item.Attributes(3)
                        Dim attDesc As Xml.XmlAttribute = Item.Attributes(4)
                        If (Item.Name = "Item") Then
                            AddKepwareReadback(sGroupName, attName.Value, attPropertyName.Value, _
                            attKepServerName.Value, attDataType.Value, attDesc.Value)
                        End If
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave KepwareIsolationValveDriver.RegisterKepwareReadback")
        End Sub
        Private Shared Sub AddKepwareStatus(ByVal sName As String, ByVal sValue As String)
            If RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                Dim Kepserver As AVPLib.Communication.KEPServerConnection = _
                CType(Communication.ConnectionManager.GetConnection(AVPLib.ConstEnum.Equipments.KepServer.ToString()), _
                Communication.KEPServerConnection)
                Kepserver.AddStatusKepserTag(sValue, sName)
            End If
        End Sub
        Private Shared Sub AddKepwareAction(ByVal sName As String, ByVal sValue As String)
            If RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                Dim Kepserver As AVPLib.Communication.KEPServerConnection = _
                CType(Communication.ConnectionManager.GetConnection(AVPLib.ConstEnum.Equipments.KepServer.ToString()), _
                Communication.KEPServerConnection)
                Kepserver.AddActionKepserTag(sName, sValue)
            End If
        End Sub
        Private Shared Sub AddKepwareReadback(ByVal sGroupName As String, ByVal sName As String, ByVal sPropertyName As String, _
                                    ByVal sKepServerName As String, ByVal sDataType As String, _
                                    ByVal sDesc As String)
            If RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                Dim Kepserver As AVPLib.Communication.KEPServerConnection = _
                CType(Communication.ConnectionManager.GetConnection(AVPLib.ConstEnum.Equipments.KepServer.ToString()), _
                Communication.KEPServerConnection)

                Kepserver.AddKepserItem(sGroupName, sName, sPropertyName, sKepServerName, sDataType, sDesc)
            End If
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update CG Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateCGPressure(ByVal ToolName As String, ByVal value As Single)
            AVPLib.Log.coreLogger.Info("Enter UpdatePressure")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("CG")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdatePressure")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update CG Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateTurboForeLineCGPressure(ByVal ToolName As String, ByVal value As Single)
            AVPLib.Log.coreLogger.Info("Enter UpdatePressure")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("TurboForelineCG")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdatePressure")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update IG communication
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateIGCommunication(ByVal ToolName As String, ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateIGCommunication")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("IG_Communication")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdatePressure")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update IG communication
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateCGCommunication(ByVal ToolName As String, ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateIGCommunication")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("CG_Communication")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdatePressure")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update IG communication
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateTurboForelineCG_Communication(ByVal ToolName As String, ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateIGCommunication")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("TurboForelineCG_Communication")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdatePressure")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update CG Relay, value =  workingstaus.On/Off
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateCGRelay(ByVal ToolName As String, ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateCGRelay")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("VacSwitchStatus")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdateCGRelay")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update CG Relay, value =  workingstaus.On/Off
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateTurboForeLineCGRelay(ByVal ToolName As String, ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateCGRelay")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("TurboForelineCGRelay")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdateCGRelay")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update Hivac Vavle Status to GUI and property
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateHivacValveStatus(ByVal ToolName As String, ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateHivacValveStatus")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("HiVacValveStatus")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdateHivacValveStatus")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update IG Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateIGPressure(ByVal ToolName As String, ByVal value As Single)
            AVPLib.Log.coreLogger.Info("Enter UpdateIGPressure")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("IG")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdateIGPressure")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update IG status, = On/Off
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateIGStatus(ByVal ToolName As String, ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateIGStatus")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("IGStatus")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdateIGStatus")
        End Sub
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-07-05 </date>
        ''' </author>
        ''' <summary>
        ''' Update Switch IG Filament, Filament = 1 or 2
        ''' </summary>
        Public Shared Sub UpdateSwitchIGFilament(ByVal ToolName As String, ByVal value As Integer)
            AVPLib.Log.coreLogger.Info("Enter UpdateSwitchIGFilament")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("SwitchIGFilament")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdateSwitchIGFilament")
        End Sub
        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2024-03-01 </date>
        ''' </author>
        ''' <summary>
        ''' Update Revision No Values
        ''' </summary>
        Public Shared Sub UpdateRevisionNoValues(ByVal ToolName As String, ByVal value As String)
            AVPLib.Log.coreLogger.Info("Enter UpdateRevisionNoValues")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("RevisionNoValues")
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)
                Utils.SaveToRevisionConfigFile(value, ToolName + "_IG")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdateRevisionNoValues")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update IsolationValve status
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateIsolationValveStatus(ByVal DriverName As String, _
                                                    ByVal ToolName As String, _
                                                    ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateIsolationValveStatus")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()

                Select Case DriverName
                    Case DriverConst.CassettesModule_SplitValveLLA
                        PropertyNames.Add("SplitValve1Status")
                    Case DriverConst.CassettesModule_SplitValvePM1
                        PropertyNames.Add("SplitValve2Status")
                    Case DriverConst.CassettesModule_SplitValvePM2
                        PropertyNames.Add("SplitValve3Status")
                    Case DriverConst.CassettesModule_SplitValvePM3
                        PropertyNames.Add("SplitValve4Status")

                End Select

                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdateIsolationValveStatus")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update RoughValve status
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateRoughValveStatus(ByVal DriverName As String, _
                                                ByVal ToolName As String, _
                                                ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateRoughValveStatus")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()

                Select Case DriverName
                    Case DriverConst.CassettesModule_Rough
                        PropertyNames.Add("FastRoughValveStatus")
                    Case DriverConst.LoadLockA_LLFastRough
                        PropertyNames.Add("FastRoughValveStatus")
                    Case DriverConst.LoadLockA_LLSlowRough
                        PropertyNames.Add("SlowRoughValveStatus")
                    Case Else
                        GoTo ExitFunction
                End Select

                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
ExitFunction:
            AVPLib.Log.coreLogger.Info("Leave UpdateRoughValveStatus")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update Sensor status
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateSensorStatus(ByVal DriverName As String, _
                                            ByVal ToolName As String, _
                                            ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateSensorStatus")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()

                Select Case DriverName
                    Case DriverConst.CassettesModule_SensorLLAStatus
                        PropertyNames.Add("SensorLLAStatus")
                    Case DriverConst.CassettesModule_SensorPM1Status
                        PropertyNames.Add("SensorPM1Status")
                    Case DriverConst.CassettesModule_SensorPM2Status
                        PropertyNames.Add("SensorPM2Status")
                    Case DriverConst.CassettesModule_SensorPM3Status
                        PropertyNames.Add("SensorPM3Status")
                    Case Else
                        GoTo ExitFunction
                End Select

                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
ExitFunction:
            AVPLib.Log.coreLogger.Info("Leave UpdateSensorStatus")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update VentValve status
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateTurboForeLineValveStatus(ByVal ToolName As String, _
                                                        ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateTurboForeLineValveStatus")
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("TurboForeLineValveStatus")

                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
ExitFunction:
            AVPLib.Log.coreLogger.Info("Leave UpdateTurboForeLineValveStatus")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update VentValve status
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub UpdateVentValveStatus(ByVal DriverName As String, _
                                        ByVal ToolName As String, _
                                        ByVal value As DataManagerment.Equipment.WorkingStatuses)
            AVPLib.Log.coreLogger.Info("Enter UpdateVentValveStatus")
            Dim blResult As Boolean = True
            Try
                Dim PropertyNames As ArrayList = New ArrayList()

                Select Case DriverName
                    Case DriverConst.CassettesModule_Vent
                        PropertyNames.Add("FastVentValveStatus")
                    Case DriverConst.LoadLockA_LLFastVent
                        PropertyNames.Add("FastVentValveStatus")
                    Case DriverConst.LoadLockA_LLSlowVent
                        PropertyNames.Add("SlowVentValveStatus")
                    Case Else
                        GoTo ExitFunction
                End Select

                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(value)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ToolName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
ExitFunction:
            AVPLib.Log.coreLogger.Info("Leave UpdateVentValveStatus")
        End Sub
    End Class
End Namespace

