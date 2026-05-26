Imports RSTiApdater
Imports AVPLib.Driver.DriverConst
Imports System.Xml
Imports AVPLib.ConstEnum
Imports AVPLib
Namespace Driver
    Public Class DriverManager
#Region "Varialbe and Property"
        Private Shared m_DriverList As Hashtable
        Private Shared m_DeviceNetServer As AVPLib.DeviceNet.DNSScanner = Nothing
        Private Shared m_PumpPackageList As Hashtable
        Private Shared m_DeviceNetApp As AVPLib.Business.DeviceNetAppController = Nothing

        ' For init DeviceNetApp
        Private Shared m_xmlIO As XmlDocument
        Private Shared m_ListAllDevice As Dictionary(Of String, PropertyObject) = Nothing
        Private Shared m_htbMacID As Hashtable = Nothing
        ' For DeviceNet Config. Will send this config to deviceNet app for initializing.
        Public Shared Property xmlIO() As XmlDocument
            Get
                Return m_xmlIO
            End Get
            Set(ByVal value As XmlDocument)
                m_xmlIO = value
            End Set
        End Property

        '''' <author>
        ''''    <name> Dung Pham </name>
        ''''    <date> 2020-03-10 </date>
        '''' </author>
        '''' <summary>
        '''' get ListAllDevice
        '''' </summary>
        Public Shared ReadOnly Property ListAllDevice() As Dictionary(Of String, PropertyObject)
            Get
                Return m_ListAllDevice
            End Get
        End Property

#End Region
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Initialize All Driver
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Initialize(ByVal ProjectName As String)
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                'new list of driver
                m_DriverList = New Hashtable()

                m_PumpPackageList = New Hashtable()
                m_htbMacID = New Hashtable()
                m_ListAllDevice = New Dictionary(Of String, PropertyObject)()

                'create all driver and add it to device net server if it is device net
                CreateDriver(ProjectName)

                If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                    ' Build XML DeviceNetString for DeviceNetApp
                    m_xmlIO = BuildDriverConfigXMLString(ProjectName)
                Else
                    'init device net server (start) 
                    If (m_DeviceNetServer IsNot Nothing) Then
                        If (Not m_DeviceNetServer.Initialize()) Then
                            AVPLib.Log.avpLogger.Error("Init DeviceNet Scanner failed!")
                        End If
                    End If
                End If
                ' new driver MP serial mechanical pump 1
                If RobotConfigurationValues.MPUMP1_SERIAL_VISIBLE Then
                    CreateSerialMechanicalPumpDriver(ConstEnum.Equipments.RoughPumpMachine1.ToString())
                End If
                ' new driver MP serial mechanical pump 2
                If RobotConfigurationValues.MPUMP2_SERIAL_VISIBLE Then
                    CreateSerialMechanicalPumpDriver(ConstEnum.Equipments.RoughPumpMachine2.ToString())
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Read Config file and initialize driver, add it to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function CreateDriver(ByVal ProjectName As String) As Boolean
            AVPLib.Log.avpLogger.Info("Leave CreateDriver")
            Dim blResult As Boolean = False
            Try
                Dim xmlDoc As System.Xml.XmlDocument = ContainerDAO.DriverConfigDoc()
                Dim root As System.Xml.XmlNode = xmlDoc.FirstChild
                For Each ProjectGroup As System.Xml.XmlNode In root.ChildNodes
                    Dim ProjectNameNode As Xml.XmlAttribute = ProjectGroup.Attributes.ItemOf(ConstEnum.Name)
                    If (ProjectNameNode IsNot Nothing AndAlso ProjectNameNode.Value = ProjectName) Then

                        For Each xmlDriver As System.Xml.XmlNode In ProjectGroup.ChildNodes
                            If (xmlDriver.Name = "Driver") Then
                                AddDriver(xmlDriver)
                            ElseIf (xmlDriver.Name = "BlockDevice") Then
                                'add block driver RSTiA and register RSTiA for IO Tab
                                AddBlockDriver(xmlDriver)
                            End If
                        Next

                        AVPLib.Log.avpLogger.Info("Leave CreateDriver")
                        Return True
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.avpLogger.Info("Leave CreateDriver")
            Return False
        End Function
        Protected Shared Function CreateSerialMechanicalPumpDriver(ByVal strDeviceName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DriverManager.GetDriver")
            Dim objResult As Boolean = False
            Dim obj As ProxyDriverObject = Nothing

            Try
                obj = New MPumpCGDriver(strDeviceName, CommType.Serial, DeviceType.MPumpCG)
                If (obj IsNot Nothing) Then
                    m_DriverList.Add(strDeviceName, obj)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.GetDriver")
            Return objResult
        End Function
        Protected Shared Function BuildRSTiAdapterInfo(ByVal Node As System.Xml.XmlNode, ByVal strMacID As String) As RSTIAdapterInfo
            Dim objRSTiAdapterInfo As RSTIAdapterInfo = New RSTIAdapterInfo()
            Try
                Const TypeAttribute As String = "Type"
                Const SizeAttribute As String = "Size"
                Const MaxRawValueAttribute As String = "MaxRawValue"
                Const MinRawValueAttribute As String = "MinRawValue"
                Const MaxElectricAttribute As String = "MaxElectric"
                Const MinElectricAttribute As String = "MinElectric"
                Const MaxScaleAttribute As String = "MaxScale"
                Const MinScaleAttribute As String = "MinScale"
                Const slipt As String = "#"
                Dim listSlotID As ArrayList = New ArrayList()

                objRSTiAdapterInfo.MacID = strMacID

                'Parse RSTiModel
                Dim hashRSTiModel As New Hashtable
                Dim nodeRSTiModel As Xml.XmlNode = Node.SelectSingleNode("/DriverConfiguration/Project/RSTiModel")

                For Each childNodeRSTiModel As Xml.XmlNode In nodeRSTiModel.ChildNodes
                    If childNodeRSTiModel Is Nothing OrElse childNodeRSTiModel.Attributes.Count < 4 Then
                        Continue For
                    End If
                    With childNodeRSTiModel
                        Dim modelSettings As New Hashtable
                        modelSettings.Add(TypeAttribute, .Attributes(TypeAttribute).Value)
                        modelSettings.Add(SizeAttribute, .Attributes(SizeAttribute).Value)
                        modelSettings.Add(MaxRawValueAttribute, .Attributes(MaxRawValueAttribute).Value)
                        modelSettings.Add(MinRawValueAttribute, .Attributes(MinRawValueAttribute).Value)
                        If (.Attributes(MaxElectricAttribute) IsNot Nothing AndAlso .Attributes(MinElectricAttribute) IsNot Nothing) Then
                            Dim maxElectric As Double
                            Dim minElectric As Double
                            If Utils.GetElectricValue(.Attributes(MaxElectricAttribute).Value, maxElectric) _
                            AndAlso Utils.GetElectricValue(.Attributes(MinElectricAttribute).Value, minElectric) Then
                                modelSettings.Add(MaxElectricAttribute, maxElectric)
                                modelSettings.Add(MinElectricAttribute, minElectric)
                            End If
                        End If
                        hashRSTiModel.Add(.InnerText, modelSettings)
                    End With
                Next

                'Parse ChannelScale
                Dim hashChannelScale As New Hashtable
                Dim nodeChannelScale As Xml.XmlNode = Node.SelectSingleNode("/DriverConfiguration/Project/ChannelScale")

                For Each childnodeChannelScale As Xml.XmlNode In nodeChannelScale.ChildNodes
                    If childnodeChannelScale Is Nothing OrElse childnodeChannelScale.Attributes.Count < 2 Then
                        Continue For
                    End If
                    With childnodeChannelScale
                        Dim scaleSettings As New Hashtable
                        scaleSettings.Add(MaxScaleAttribute, .Attributes(MaxScaleAttribute).Value)
                        scaleSettings.Add(MinScaleAttribute, .Attributes(MinScaleAttribute).Value)
                        If (.Attributes(MaxElectricAttribute) IsNot Nothing AndAlso .Attributes(MinElectricAttribute) IsNot Nothing) Then
                            Dim maxElectric As Double
                            Dim minElectric As Double
                            If Utils.GetElectricValue(.Attributes(MaxElectricAttribute).Value, maxElectric) _
                            AndAlso Utils.GetElectricValue(.Attributes(MinElectricAttribute).Value, minElectric) Then
                                scaleSettings.Add(MaxElectricAttribute, maxElectric)
                                scaleSettings.Add(MinElectricAttribute, minElectric)
                            End If
                        End If
                        hashChannelScale.Add(.InnerText, scaleSettings)
                    End With
                Next

                'Parse BlockDevice
                For Each childnode As Xml.XmlNode In Node.ChildNodes
                    If childnode Is Nothing OrElse childnode.Attributes.Count < 5 Then
                        Continue For
                    End If
                    With childnode
                        Dim attName As Xml.XmlAttribute = .Attributes("Name")
                        Dim attDeviceType As Xml.XmlAttribute = .Attributes("DeviceType")
                        Dim attModelID As Xml.XmlAttribute = .Attributes("ModelID")
                        Dim attSlotID As Xml.XmlAttribute = .Attributes("SlotID")
                        Dim attChannelID As Xml.XmlAttribute = .Attributes("ChannelID")

                        If attName IsNot Nothing Then
                            AddListMacID(strMacID, attName.Value)
                        End If

                        ''check for light alarm
                        If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = ConstEnum.FOURLIGHTALARM Then
                            If attName.Value.Contains("Alarm.OrangeStatus") Then
                                attChannelID.Value = "6"
                            End If

                            If attName.Value.Contains("Alarm.BlueStatus") Then
                                attChannelID.Value = "8"
                            End If
                        Else
                            If attName.Value.Contains("Alarm.BlueStatus") Then
                                Continue For
                            End If
                        End If

                        'create RSTi Object
                        Dim objRSTiObject As New RSTiObject(attName.Value.ToString())
                        objRSTiObject.DeviceNetType = DirectCast([Enum].Parse(GetType(Driver.DeviceType), attDeviceType.Value.ToString()), Driver.DeviceType) '
                        objRSTiObject.ModelID = attModelID.Value.ToString()
                        objRSTiObject.ChannelID = attChannelID.Value.ToString()
                        objRSTiObject.SlotID = attSlotID.Value.ToString()
                        objRSTiObject.MacID = strMacID

                        'also get Type, Size, MaxRawValue, MinRawValue
                        Dim arrListModeID As Hashtable = Nothing
                        If hashRSTiModel IsNot Nothing AndAlso hashRSTiModel.ContainsKey(objRSTiObject.ModelID) Then
                            arrListModeID = hashRSTiModel.Item(objRSTiObject.ModelID)
                            If arrListModeID.Count >= 4 Then
                                objRSTiObject.Type = arrListModeID(TypeAttribute) 'type
                                objRSTiObject.MaxRawValue = arrListModeID(MaxRawValueAttribute) 'MaxRawValue
                                objRSTiObject.MinRawValue = arrListModeID(MinRawValueAttribute) 'MinRawValue

                                'Create new RSTIAdapterSlotInfo
                                Dim uiSlotID As UInt16 = 0
                                Dim iSize As Integer = 0
                                UInt16.TryParse(attSlotID.Value, uiSlotID)
                                If listSlotID.IndexOf(uiSlotID) = -1 Then
                                    listSlotID.Add(uiSlotID)
                                    Dim objRSTIAdapterSlotInfo As RSTIAdapterSlotInfo = New RSTIAdapterSlotInfo()

                                    objRSTIAdapterSlotInfo.PhysicPosition = uiSlotID
                                    Integer.TryParse(arrListModeID(SizeAttribute), iSize)
                                    objRSTIAdapterSlotInfo.Size = iSize

                                    If arrListModeID(TypeAttribute) = RSTI_ADAPTER_INPUT_ANALOG_CHANNEL Then
                                        objRSTIAdapterSlotInfo.Type = RSTIAdapterSlotInfo.SlotType.Analog
                                        objRSTiAdapterInfo.AddSlotToAdapter(objRSTIAdapterSlotInfo, True)
                                    ElseIf arrListModeID(TypeAttribute) = RSTI_ADAPTER_OUTPUT_ANALOG_CHANNEL Then
                                        objRSTIAdapterSlotInfo.Type = RSTIAdapterSlotInfo.SlotType.Analog
                                        objRSTiAdapterInfo.AddSlotToAdapter(objRSTIAdapterSlotInfo, False)
                                    ElseIf arrListModeID(TypeAttribute) = RSTI_ADAPTER_INPUT_DISCRETE_CHANNEL Then
                                        objRSTIAdapterSlotInfo.Type = RSTIAdapterSlotInfo.SlotType.Discrete
                                        objRSTiAdapterInfo.AddSlotToAdapter(objRSTIAdapterSlotInfo, True)
                                    ElseIf arrListModeID(TypeAttribute) = RSTI_ADAPTER_OUTPUT_DISCRETE_CHANNEL Then
                                        objRSTIAdapterSlotInfo.Type = RSTIAdapterSlotInfo.SlotType.Discrete
                                        objRSTiAdapterInfo.AddSlotToAdapter(objRSTIAdapterSlotInfo, False)
                                    End If
                                End If
                            End If
                        End If

                        'also get MaxScale, MinScale
                        If hashChannelScale IsNot Nothing AndAlso hashChannelScale.ContainsKey(objRSTiObject.PropertyName) Then
                            Dim arrListChanelScale As Hashtable = hashChannelScale.Item(objRSTiObject.PropertyName)
                            If arrListChanelScale.Count >= 2 Then
                                objRSTiObject.MaxScale = arrListChanelScale(MaxScaleAttribute)
                                objRSTiObject.MinScale = arrListChanelScale(MinScaleAttribute)

                                If objRSTiObject.Type = RSTI_ADAPTER_INPUT_ANALOG_CHANNEL OrElse objRSTiObject.Type = RSTI_ADAPTER_OUTPUT_ANALOG_CHANNEL Then
                                    If arrListChanelScale.ContainsKey(MinElectricAttribute) AndAlso arrListChanelScale.ContainsKey(MaxElectricAttribute) Then
                                        If arrListModeID IsNot Nothing AndAlso arrListModeID.ContainsKey(MinElectricAttribute) AndAlso arrListModeID.ContainsKey(MaxElectricAttribute) Then
                                            Dim modelMinElectric As Double = arrListModeID(MinElectricAttribute)
                                            Dim modelMaxElectric As Double = arrListModeID(MaxElectricAttribute)
                                            Dim channelMinElectric As Double = arrListChanelScale(MinElectricAttribute)
                                            Dim channelMaxElectric As Double = arrListChanelScale(MaxElectricAttribute)

                                            Dim realChannelMinRawValue As Double = objRSTiObject.MinRawValue + (channelMinElectric - modelMinElectric) * (objRSTiObject.MaxRawValue - objRSTiObject.MinRawValue) / (modelMaxElectric - modelMinElectric)
                                            Dim realChannelMaxRawValue As Double = objRSTiObject.MinRawValue + (channelMaxElectric - modelMinElectric) * (objRSTiObject.MaxRawValue - objRSTiObject.MinRawValue) / (modelMaxElectric - modelMinElectric)

                                            objRSTiObject.MinRawValue = realChannelMinRawValue
                                            objRSTiObject.MaxRawValue = realChannelMaxRawValue
                                        End If
                                    End If
                                End If

                            End If
                        End If

                        'add more property to object objRSTiObject
                        AddChannelDeviceNetDriver(strMacID, objRSTiObject)

                        'add IO Tab driver RSTiA
                        RegisterRSTiForTabIO(objRSTiObject)
                    End With
                Next

                'RSTIAdapterInfo call method
                objRSTiAdapterInfo.InputSlots.TrimExcess()
                objRSTiAdapterInfo.OutputSlots.TrimExcess()
                objRSTiAdapterInfo.CalculateSignalSize()
                objRSTiAdapterInfo.ArrangePacket()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message.ToString)
            End Try
            Return objRSTiAdapterInfo
        End Function

        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' Add Block RSTI Driver
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function AddBlockDriver(ByVal Node As System.Xml.XmlNode) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DriverManager.GetDriver")
            Dim blResult As Boolean = False
            Dim attMacID As Xml.XmlAttribute = Node.Attributes("MacID")
            Dim strMacID As String = String.Empty
            If attMacID IsNot Nothing Then
                strMacID = attMacID.Value
            End If
            Try
                Dim objRSTiAdapterInfo As RSTIAdapterInfo = BuildRSTiAdapterInfo(Node, strMacID)

                AddRSTiAdapterInfo(strMacID, objRSTiAdapterInfo, m_PumpPackageList)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.GetDriver")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function AddChannelDeviceNetDriver(ByVal sMacID As String, ByVal objRSTiObject As RSTiObject) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DriverManager.AddChannelDeviceNetDriver")
            Dim objResult As Boolean = False
            If objRSTiObject Is Nothing Then
                Return False
            End If
            Try
                Dim objAdapterDriver As AdapterDriver = Nothing

                If m_DriverList.Contains(sMacID) Then
                    objAdapterDriver = m_DriverList.Item(sMacID)
                    CType(objAdapterDriver, AdapterDriver).AddChannelRSTi(objRSTiObject)
                    objResult = True
                Else
                    Dim comtype As CommType = CommType.Kepware 'as default
                    If RobotConfigurationValues.IS_KEPWARE_INSTALLED = False Then
                        comtype = CommType.DeviceNet
                    End If

                    objAdapterDriver = New Driver.AdapterDriver(comtype, objRSTiObject)
                    objAdapterDriver.AddChannelRSTi(objRSTiObject)
                    m_DriverList.Add(sMacID, objAdapterDriver)
                    If (m_DeviceNetServer Is Nothing) Then
                        m_DeviceNetServer = New AVPLib.DeviceNet.DNSScanner()
                        m_DeviceNetServer.CardName = ContainerDAO.GetDeviceNetCardName()
                        AVPLib.Log.coreLogger.Info("m_DeviceNetServer.CardName = " & m_DeviceNetServer.CardName)
                    End If
                    m_DeviceNetServer.AddDeviceNetDriver(objAdapterDriver.proxyObject, sMacID)
                    objResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.AddChannelDeviceNetDriver")
            Return objResult
        End Function
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-12-27</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function AddRSTiAdapterInfo(ByVal sMacID As String, ByVal objRSTiAdapterInfo As RSTIAdapterInfo, ByVal objPumpPackageList As Hashtable) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DriverManager.AddRSTiAdapterInfo")
            Dim objResult As Boolean = False
            If objRSTiAdapterInfo Is Nothing Then
                Return False
            End If
            Try
                Dim objAdapterDriver As AdapterDriver = Nothing

                If m_DriverList.Contains(sMacID) Then
                    objAdapterDriver = m_DriverList.Item(sMacID)
                    CType(objAdapterDriver, AdapterDriver).AddAdapterInfoRSTi(objRSTiAdapterInfo, objPumpPackageList)
                    objResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.AddRSTiAdapterInfo")
            Return objResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' New Kepware and add to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function AddDriver(ByVal Node As System.Xml.XmlNode) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DriverManager.GetDriver")
            Dim blResult As Boolean = False
            Try
                If (Node Is Nothing OrElse Node.Attributes.Count < 4) Then
                    blResult = False
                    GoTo exitFunc
                End If

                Dim attName As Xml.XmlAttribute = Node.Attributes("Name")
                Dim attInstall As Xml.XmlAttribute = Node.Attributes("IsInstalled")
                Dim attCommType As Xml.XmlAttribute = Node.Attributes("CommType")
                Dim attDeviceType As Xml.XmlAttribute = Node.Attributes("DeviceType")
                Dim attMacID As Xml.XmlAttribute = Node.Attributes("MacID")
                Dim attModel As Xml.XmlAttribute = Node.Attributes("Model")

                If RobotConfigurationValues.SHARED_MP_WITH_PM AndAlso attName.Value = RoughPumpMachine1_CG OrElse attName.Value = RoughPumpMachine2_CG Then
                    attInstall.Value = "False"
                End If

                'apply -> Isolation Valve
                Dim attOpenBitIndex As Xml.XmlAttribute = Node.Attributes("OpenBitIndex")
                Dim attCloseBitIndex As Xml.XmlAttribute = Node.Attributes("CloseBitIndex")
                'Apply -> other valve
                Dim attBitIndex As Xml.XmlAttribute = Node.Attributes("BitIndex")
                If (attInstall IsNot Nothing) Then
                    Dim blInstalled As Boolean = Convert.ToBoolean(attInstall.Value)

                    If attName.Value.Contains("PumpPackage") Then
                        Dim isInstalledRSTi As Boolean = (blInstalled AndAlso (attCommType.Value = CommType.DeviceNet.ToString OrElse attCommType.Value = CommType.RSTi_Serial.ToString))
                        m_PumpPackageList.Add(attName.Value, isInstalledRSTi)
                    End If

                    If (blInstalled) Then
                        Select Case attCommType.Value
                            Case CommType.DeviceNet.ToString
                                If (attBitIndex IsNot Nothing AndAlso
                                attCloseBitIndex Is Nothing AndAlso attOpenBitIndex Is Nothing) Then
                                    'add valve driver with only one bit index
                                    AddDeviceNetDriver(attName.Value, attDeviceType.Value,
                                                        attMacID.Value, attBitIndex.Value)
                                ElseIf (attBitIndex Is Nothing AndAlso
                                attCloseBitIndex Is Nothing AndAlso attOpenBitIndex Is Nothing) Then
                                    If attDeviceType.Value = DeviceType.Turbo.ToString Then
                                        'add Device RSTi For Turbo
                                        AddDeviceNetTurboDriver(attName.Value, attDeviceType.Value)
                                    Else
                                        'add other Device Net Driver
                                        AddDeviceNetDriver(attName.Value, attDeviceType.Value, attMacID.Value)
                                    End If
                                ElseIf (attOpenBitIndex IsNot Nothing _
                                AndAlso attCloseBitIndex IsNot Nothing AndAlso attBitIndex Is Nothing) Then
                                    'add valve driver with Open and Close bit index
                                    AddDeviceNetDriver(attName.Value, attDeviceType.Value,
                                                        attMacID.Value, attOpenBitIndex.Value, attCloseBitIndex.Value)
                                End If


                                If Not String.IsNullOrEmpty(attMacID.Value) Then
                                    AddListMacID(attMacID.Value, attName.Value)
                                End If

                            Case CommType.Kepware.ToString
                                AddKepwareDriver(attName.Value, attDeviceType.Value)
                                'type RSTi_Serial Or Serial
                            Case CommType.RSTi_Serial.ToString, CommType.Serial.ToString
                                Dim commType = DirectCast([Enum].Parse(GetType(CommType), attCommType.Value), CommType)
                                AddSerialDriver(attName.Value, attDeviceType.Value, commType, attModel.Value)
                        End Select
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
exitFunc:
            AVPLib.Log.coreLogger.Info("Leave DriverManager.GetDriver")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' New Kepware and add to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function AddKepwareDriver(ByVal sName As String, ByVal sDeviceType As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DriverManager.GetDriver")
            Dim objResult As Boolean = False
            Try
                'Create Driver
                'DeviceType & Driver
                'Pass 4 params
                Dim obj As ProxyDriverObject = Nothing
                Dim strDeviceType As String = sDeviceType & "Driver"
                If (sDeviceType = DeviceType.Turbo.ToString OrElse sDeviceType = DeviceType.Cryo.ToString) Then
                    strDeviceType = "PumpPackageDriver"
                End If

                obj = Activator.CreateInstance(
                        Type.GetType("AVPLib.Driver." & strDeviceType),
                        sName, CommType.Kepware, DeviceTypeTextConverter(sDeviceType))

                If (obj IsNot Nothing) Then
                    m_DriverList.Add(sName, obj)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.GetDriver")
            Return objResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' New DeviceNet Driver and add to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function AddDeviceNetDriver(ByVal sName As String,
                                                ByVal sDeviceType As String,
                                                ByVal MacID As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DriverManager.AddDeviceNetDriver")
            Dim objResult As Boolean = False
            Try
                'Create Driver
                'DeviceType & Driver
                'Pass 4 params
                Dim obj As ProxyDriverObject = Activator.CreateInstance(
                Type.GetType("AVPLib.Driver." & sDeviceType & "Driver"),
                sName, CommType.DeviceNet, DeviceTypeTextConverter(sDeviceType), MacID)

                If (obj IsNot Nothing) Then
                    m_DriverList.Add(sName, obj)
                    If (m_DeviceNetServer Is Nothing) Then
                        m_DeviceNetServer = New AVPLib.DeviceNet.DNSScanner()
                        m_DeviceNetServer.CardName = ContainerDAO.GetDeviceNetCardName()
                        'AVPLib.DeviceNet.DNSScanner.IsInstallSolenoidBlock3 = RobotConfigurationValues.LLA_HIVAC_INSTALLED
                        AVPLib.Log.coreLogger.Info("m_DeviceNetServer.CardName = " & m_DeviceNetServer.CardName)
                    End If
                    m_DeviceNetServer.AddDeviceNetDriver(obj.proxyObject)

                    ' Register Pressure for IO tab
                    RegisterPressureForTabIO(sName, MacID)

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.AddDeviceNetDriver")
            Return objResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' New DeviceNet Driver and add to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function AddDeviceNetDriver(ByVal sName As String,
                                                ByVal sDeviceType As String,
                                                ByVal MacID As String,
                                                ByVal BitIndex As String,
                                                Optional ByVal CloseBitIndex As String = "") As Boolean
            AVPLib.Log.coreLogger.Info("Enter DriverManager.AddDeviceNetDriver")
            Dim objResult As Boolean = False
            Try
                Dim obj As ProxyDriverObject = Nothing
                If (CloseBitIndex = "") Then
                    obj = Activator.CreateInstance(
                                    Type.GetType("AVPLib.Driver." & sDeviceType & "Driver"),
                                    sName, CommType.DeviceNet, DeviceTypeTextConverter(sDeviceType), MacID, BitIndex)

                    ' Register valve for IO tab
                    RegisterSolenoidForTabIO(sName, MacID, BitIndex)
                Else
                    obj = Activator.CreateInstance(
                                    Type.GetType("AVPLib.Driver." & sDeviceType & "Driver"),
                                    sName, CommType.DeviceNet, DeviceTypeTextConverter(sDeviceType), MacID, BitIndex, CloseBitIndex)
                    ' Register valve for IO tab bit Open
                    RegisterSolenoidOpenBitIndexForTabIO(sName, MacID, BitIndex)
                    ' Register valve for IO tab bit Close
                    RegisterSolenoidClosedBitIndexForTabIO(sName, MacID, CloseBitIndex)
                End If


                If (obj IsNot Nothing) Then
                    m_DriverList.Add(sName, obj)
                    If (m_DeviceNetServer Is Nothing) Then
                        m_DeviceNetServer = New AVPLib.DeviceNet.DNSScanner()
                        m_DeviceNetServer.CardName = ContainerDAO.GetDeviceNetCardName()
                        AVPLib.Log.coreLogger.Info("m_DeviceNetServer.CardName = " & m_DeviceNetServer.CardName)
                    End If
                    m_DeviceNetServer.AddValveDriver(obj.proxyObject)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.AddDeviceNetDriver")
            Return objResult
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-02-13</date>
        ''' </author>
        ''' <summary>
        ''' New Device RSTi Driver for turbo and add to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function AddDeviceNetTurboDriver(ByVal sName As String,
                                                ByVal sDeviceType As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DriverManager.AddDeviceNetDriver")
            Dim objResult As Boolean = False
            Try
                'Create Driver
                'DeviceType & Driver
                'Pass 4 params
                Dim obj As ProxyDriverObject = Activator.CreateInstance(
                Type.GetType("AVPLib.Driver.PumpPackageDriver"),
                sName, CommType.DeviceNet, DeviceTypeTextConverter(sDeviceType))

                If (obj IsNot Nothing) Then
                    m_DriverList.Add(sName, obj)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.AddDeviceNetDriver")
            Return objResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' New Serial Driver and add to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function AddSerialDriver(ByVal sName As String, ByVal sDeviceType As String,
                                                ByVal sCommType As CommType, ByVal sModel As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DriverManager.GetDriver")
            Dim objResult As Boolean = False
            Dim obj As ProxyDriverObject = Nothing

            Try
                Select Case sDeviceType
                    Case DeviceType.Cryo.ToString
                        obj = New PumpPackageDriver(sName, CommType.Serial, DeviceType.Cryo)

                    Case DeviceType.Turbo.ToString
                        obj = New PumpPackageDriver(sName, sCommType, DeviceType.Turbo, sModel)

                    Case DeviceType.CG.ToString

                    Case DeviceType.HivacValve.ToString

                    Case DeviceType.IG.ToString

                    Case DeviceType.IsolationValve.ToString

                    Case DeviceType.MPumpCG.ToString

                    Case DeviceType.PumpPackage.ToString

                    Case DeviceType.RoughValve.ToString

                    Case DeviceType.Sensor.ToString

                    Case DeviceType.TurboForeLine.ToString

                    Case DeviceType.VentValve.ToString
                End Select

                If (obj IsNot Nothing) Then
                    m_DriverList.Add(sName, obj)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.GetDriver")
            Return objResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Read Config file and initialize driver, add it to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetDriver(ByVal sName As String) As ProxyDriverObject
            AVPLib.Log.coreLogger.Info("Enter DriverManager.GetDriver")
            Dim objResult As ProxyDriverObject = Nothing
            Try
                If (m_DriverList IsNot Nothing AndAlso m_DriverList.Count > 0) Then
                    objResult = m_DriverList.Item(sName)
                End If
                ''search block to get driver
                If objResult Is Nothing Then
                    If DeviceNet.DNSScanner.RSTiBlockDriver IsNot Nothing Then
                        For Each entry As DictionaryEntry In DeviceNet.DNSScanner.RSTiBlockDriver
                            If entry.Value.GetType().Name = "Kepware4RSTiDriver" Then
                                Return m_DriverList.Item(entry.Key)
                            End If
                            'MacID as key, DeviceRSTiDriver as value
                            Dim objBlockRSTiDriver As DriverObject = entry.Value
                            'search all channel which has sName
                            If (RobotConfigurationValues.DEVICENETAPP_VISIBLE AndAlso CType(objBlockRSTiDriver, DeviceNetAppRSTiDriver).ListOfChannelRSTi.ContainsKey(sName)) _
                                OrElse CType(objBlockRSTiDriver, DeviceRSTiDriver).ListOfChannelRSTi.ContainsKey(sName) Then
                                'return AdapterDriver
                                Return m_DriverList.Item(entry.Key)
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.GetDriver")
            Return objResult
        End Function

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-18</date>
        ''' </author>
        ''' <summary>
        ''' Get driver by macid
        ''' </summary>
        Public Shared Function GetDriver(ByVal macID As Integer) As ProxyDriverObject
            AVPLib.Log.coreLogger.Info("Enter DriverManager.GetDriver")
            Dim objResult As ProxyDriverObject = Nothing

            Try
                Dim macIdName = macID.ToString()
                If m_htbMacID.ContainsKey(macIdName) Then
                    objResult = DriverManager.GetDriver(m_htbMacID(macIdName))

                    If objResult Is Nothing AndAlso m_DriverList.Contains(macIdName) OrElse objResult.eCommunicationType <> CommType.DeviceNet Then
                        objResult = m_DriverList.Item(macIdName)
                    End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave DriverManager.GetDriver")
            Return objResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Initialize All Driver
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Dispose()
            AVPLib.Log.coreLogger.Info("Enter DriverManager.Dispose")
            Try
                For Each drv As ProxyDriverObject In m_DriverList.Values
                    drv.Dispose()
                Next
                m_DriverList.Clear()
                m_DeviceNetServer.Dispose()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DriverManager.Dispose")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Initialize All Driver
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared Function DeviceTypeTextConverter(ByVal str As String) As DeviceType
            Select Case str
                Case DeviceType.CG.ToString()
                    Return DeviceType.CG
                Case DeviceType.HivacValve.ToString()
                    Return DeviceType.HivacValve
                Case DeviceType.IG.ToString()
                    Return DeviceType.IG
                Case DeviceType.IsolationValve.ToString()
                    Return DeviceType.IsolationValve
                Case DeviceType.MPumpCG.ToString()
                    Return DeviceType.MPumpCG
                Case DeviceType.Cryo.ToString()
                    Return DeviceType.Cryo
                Case DeviceType.Turbo.ToString()
                    Return DeviceType.Turbo
                Case DeviceType.RoughValve.ToString()
                    Return DeviceType.RoughValve
                Case DeviceType.Sensor.ToString()
                    Return DeviceType.Sensor
                Case DeviceType.TurboForeLine.ToString()
                    Return DeviceType.TurboForeLine
                Case DeviceType.VentValve.ToString()
                    Return DeviceType.VentValve
                Case Else
                    Return Nothing
            End Select
        End Function

        Protected Shared Function BuildDriverConfigXMLString(ByVal ProjectName As String) As XmlDocument
            AVPLib.Log.coreLogger.Info("Enter BuildDriverConfigXMLString")

            Dim xml As XmlDocument = New XmlDocument()

            Try
                Dim xmlDoc As System.Xml.XmlDocument = ContainerDAO.DriverConfigDoc()
                Dim root As System.Xml.XmlNode = xmlDoc.FirstChild
                Dim stsSolenoidPreviousMacID As List(Of String) = New List(Of String)

                ' Get DeviceNetCardName and DeviceNetBaudRate
                Dim xmlDeviceNetConfig As System.Xml.XmlElement = xml.CreateElement("DeviceNetConfig")
                xmlDeviceNetConfig.SetAttribute("ScannnerCardName", ContainerDAO.GetDeviceNetCardName())
                xmlDeviceNetConfig.SetAttribute("BaudRate", ContainerDAO.GetDeviceNetBaudRate())
                xml.AppendChild(xmlDeviceNetConfig)

                'Set password to exit devicenet App
                If Not String.IsNullOrEmpty(RobotConfigurationValues.PASSWORD_EXIT_DEVICENETAPP) Then
                    Dim xmlPass As XmlElement = xml.CreateElement(ConstEnum.STR_PASSWORD_EXIT_DEVICENET_APP)
                    xmlPass.SetAttribute("Value", RobotConfigurationValues.PASSWORD_EXIT_DEVICENETAPP)
                    xmlDeviceNetConfig.AppendChild(xmlPass)
                End If

                For Each ProjectGroup As System.Xml.XmlNode In root.ChildNodes
                    Dim ProjectNameNode As Xml.XmlAttribute = ProjectGroup.Attributes.ItemOf(ConstEnum.Name)
                    If (ProjectNameNode IsNot Nothing AndAlso ProjectNameNode.Value = ProjectName) Then

                        For Each xmlDriver As System.Xml.XmlNode In ProjectGroup.ChildNodes
                            If (xmlDriver.Name = "Driver") Then
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

                                If RobotConfigurationValues.SHARED_MP_WITH_PM AndAlso attName.Value = RoughPumpMachine1_CG OrElse attName.Value = RoughPumpMachine2_CG Then
                                    attInstall.Value = "False"
                                End If
                                ' If equipment not installed, skip
                                If attInstall.InnerText = "False" Then
                                    Continue For
                                End If

                                ' Solenoid
                                Select Case attDeviceType.InnerText
                                    Case DeviceType.RoughValve.ToString(), DeviceType.VentValve.ToString(), DeviceType.HivacValve.ToString(),
                                            DeviceType.IsolationValve.ToString()
                                        If attCommType.InnerText = "DeviceNet" AndAlso Not stsSolenoidPreviousMacID.Contains(attMacID.InnerText) Then
                                            Dim xmlSolenoid As System.Xml.XmlElement = xml.CreateElement("Solenoid")
                                            xmlSolenoid.SetAttribute("MacID", attMacID.InnerText)
                                            xmlDeviceNetConfig.AppendChild(xmlSolenoid)

                                            ' Store Slolenoid MacID
                                            stsSolenoidPreviousMacID.Add(attMacID.InnerText)
                                        End If
                                End Select

                                ' IG
                                If attDeviceType.InnerText = "IG" Then
                                    Dim SystemDevice As SystemModule = Nothing
                                    Dim strEmission As String = String.Empty
                                    Dim strFilament As String = String.Empty

                                    ' Get Emission and Filament
                                    If attName.InnerText.Contains("LoadLockA") Then
                                        SystemDevice = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.LoadLockA.ToString())
                                    ElseIf attName.InnerText.Contains("CassettesModule") Then
                                        SystemDevice = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Robot.ToString())
                                    End If
                                    If SystemDevice IsNot Nothing Then
                                        strEmission = SystemDevice.IonGaugeEmissionCurrent.ToString()
                                        strFilament = SystemDevice.Filament.ToString()

                                        Dim xmlIG As System.Xml.XmlElement = xml.CreateElement("IG")
                                        xmlIG.SetAttribute("MacID", attMacID.InnerText)
                                        xmlIG.SetAttribute("FilamentType", strFilament)
                                        xmlIG.SetAttribute("AutoCurrentEmission", strEmission)
                                        xmlDeviceNetConfig.AppendChild(xmlIG)
                                    End If
                                End If

                                ' CG
                                Select Case attDeviceType.InnerText
                                    Case DeviceType.CG.ToString(), DeviceType.MPumpCG.ToString(), DeviceType.TurboForeLine.ToString()
                                        Dim xmlCG As System.Xml.XmlElement = xml.CreateElement("CG")
                                        xmlCG.SetAttribute("MacID", attMacID.InnerText)
                                        xmlDeviceNetConfig.AppendChild(xmlCG)
                                End Select
                            ElseIf xmlDriver.Name = "BlockDevice" AndAlso Not RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                                Dim atMacID As Xml.XmlAttribute = xmlDriver.Attributes("MacID")
                                If Not String.IsNullOrEmpty(atMacID.Value) Then
                                    Dim objRSTiAdaterInfo As RSTIAdapterInfo = BuildRSTiAdapterInfo(xmlDriver, atMacID.Value)

                                    Dim xmlRSTi As System.Xml.XmlElement = xml.CreateElement("RSTi")
                                    xmlRSTi.SetAttribute("MacID", atMacID.Value)
                                    For Each slotInfo As RSTIAdapterSlotInfo In objRSTiAdaterInfo.InputSlots
                                        Dim xmlInputSlot As System.Xml.XmlElement = xml.CreateElement("Slot")
                                        xmlInputSlot.SetAttribute("Num", slotInfo.PhysicPosition.ToString())

                                        If slotInfo.Type = RSTIAdapterSlotInfo.SlotType.Analog Then
                                            xmlInputSlot.SetAttribute("Type", "AI")
                                        ElseIf slotInfo.Type = RSTIAdapterSlotInfo.SlotType.Discrete Then
                                            xmlInputSlot.SetAttribute("Type", "DI")
                                        Else
                                            xmlInputSlot.SetAttribute("Type", RSTIAdapterSlotInfo.SlotType.Unknown.ToString())
                                        End If

                                        xmlInputSlot.SetAttribute("Size", slotInfo.Size.ToString())

                                        xmlRSTi.AppendChild(xmlInputSlot)
                                    Next

                                    For Each slotInfo As RSTIAdapterSlotInfo In objRSTiAdaterInfo.OutputSlots
                                        Dim xmlOutputSlot As System.Xml.XmlElement = xml.CreateElement("Slot")
                                        xmlOutputSlot.SetAttribute("Num", slotInfo.PhysicPosition.ToString())

                                        If slotInfo.Type = RSTIAdapterSlotInfo.SlotType.Analog Then
                                            xmlOutputSlot.SetAttribute("Type", "AO")
                                        ElseIf slotInfo.Type = RSTIAdapterSlotInfo.SlotType.Discrete Then
                                            xmlOutputSlot.SetAttribute("Type", "DO")
                                        Else
                                            xmlOutputSlot.SetAttribute("Type", RSTIAdapterSlotInfo.SlotType.Unknown.ToString())
                                        End If

                                        xmlOutputSlot.SetAttribute("Size", slotInfo.Size.ToString())

                                        xmlRSTi.AppendChild(xmlOutputSlot)
                                    Next

                                    xmlDeviceNetConfig.AppendChild(xmlRSTi)
                                End If
                            End If
                        Next
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave BuildDriverConfigXMLString")

            Return xml
        End Function

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' RegisterDeviceForTabIO
        ''' </summary>
        ''' <value></value>
        Private Shared Sub RegisterDeviceForTabIO(ByVal name As String,
                                                ByVal objReceiver As Object,
                                                ByVal strPropertyName As String)
            Try
                Dim objProp As PropertyObject = New PropertyObject()
                objProp.Init(objReceiver, strPropertyName)

                If objProp.IsOK Then
                    If m_ListAllDevice.ContainsKey(name) Then
                        m_ListAllDevice(name) = objProp
                    Else
                        m_ListAllDevice.Add(name, objProp)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' RegisterRSTiForTabIO
        ''' </summary>
        ''' <value></value>
        Private Shared Sub RegisterRSTiForTabIO(ByVal objRSTi As RSTiObject)
            Try
                If objRSTi IsNot Nothing Then
                    Dim driverName As String = objRSTi.DriverName

                    Dim objReceiver As DataManagerment.Equipment = GetObjectReciver(driverName)
                    Dim strEquimentName As String = objReceiver.Name.ToString()
                    Dim strPropertyName As String = driverName.Split(" ")(0)
                    If strEquimentName = ConstEnum.Equipments.CassettesModule.ToString() Then
                        strEquimentName = ConstEnum.STR_TRANSFER_MODULE
                    End If

                    Dim name As String = "MacID" + objRSTi.MacID + ".Slot" + Convert.ToSingle(objRSTi.SlotID).ToString("00") + ".Channel" + Convert.ToSingle(objRSTi.ChannelID).ToString("00") + " - " + strEquimentName + "." + driverName
                    RegisterDeviceForTabIO(name, objReceiver, strPropertyName)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2023-04-01 </date>
        ''' </author>
        ''' <summary>
        ''' Register Pressure For Tab IO
        ''' </summary>
        Private Shared Sub RegisterPressureForTabIO(ByVal driverName As String, ByVal MacID As String)
            Try
                If Not String.IsNullOrEmpty(driverName) Then
                    Dim objReceiver As DataManagerment.Equipment = GetObjectReciver(driverName)
                    Dim strEquimentName As String = objReceiver.Name.ToString()
                    Dim strPropertyName As String = driverName.Split(" ")(0)
                    If strEquimentName = ConstEnum.Equipments.CassettesModule.ToString() Then
                        strEquimentName = ConstEnum.STR_TRANSFER_MODULE
                    End If
                    Select Case driverName
                        'valve Vent
                        Case "Ion"
                            strPropertyName = "IG"
                        Case Else
                            AVPLib.Log.avpLogger.Info("Did not find property")
                    End Select
                    Dim name As String = "MacID" + Convert.ToSingle(MacID).ToString("00") + "." + strEquimentName + "." + driverName
                    RegisterDeviceForTabIO(name, objReceiver, strPropertyName)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2023-04-01 </date>
        ''' </author>
        ''' <summary>
        ''' RegisterSolenoidForTabIO
        ''' </summary>
        Private Shared Sub RegisterSolenoidForTabIO(ByVal driverName As String, ByVal MacID As String, ByVal BitIndex As String)
            Try
                Dim strPropertyName As String = String.Empty
                If Not String.IsNullOrEmpty(driverName) Then
                    Dim objReceiver As DataManagerment.Equipment = GetObjectReciver(driverName)
                    Select Case driverName
                        'valve Vent
                        Case "LLFastVent", "Vent"
                            strPropertyName = "FastVentValveStatus"
                        Case "LLSlowVent"
                            strPropertyName = "SlowVentValveStatus"

                            'valve Rough
                        Case "LLFastRough", "Rough"
                            strPropertyName = "FastRoughValveStatus"
                        Case "LLSlowRough"
                            strPropertyName = "SlowRoughValveStatus"

                            'valve Turbo Foreline
                        Case "TurboForelineValve"
                            strPropertyName = "TurboForeLineValveStatus"
                        Case "LLHiVac", "TMHiVac"
                            strPropertyName = "HiVacValveStatus"
                        Case Else
                            AVPLib.Log.avpLogger.Info("Did not find property")
                    End Select
                    Dim strEquimentName As String = objReceiver.Name.ToString()
                    If strEquimentName = ConstEnum.Equipments.CassettesModule.ToString() Then
                        strEquimentName = ConstEnum.STR_TRANSFER_MODULE
                    End If
                    Dim nameBitIndex As String = String.Format("MacID{0}.Solenoid{1}.Bit{2} - {3}.{4}", Convert.ToSingle(MacID).ToString("00"), MacID, Convert.ToSingle(BitIndex).ToString("00"), strEquimentName, driverName)
                    RegisterDeviceForTabIO(nameBitIndex, objReceiver, strPropertyName)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' GetObjectReciver
        ''' </summary>
        ''' <value></value>
        Public Shared Function GetObjectReciver(ByRef sName As String) As Object
            Dim obj As Object = Nothing

            Try
                Dim splitArr As String() = sName.Split(".")
                Dim parrent As String = splitArr(0)

                If splitArr.Length > 1 Then
                    sName = splitArr(1)
                End If
                obj = DataManagerment.EquipmentManager.GetEquipment(parrent)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return obj
        End Function

        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2023-04-01 </date>
        ''' </author>
        ''' <summary>
        ''' RegisterSolenoidOpenBitIndexForTabIO
        ''' </summary>
        Public Shared Function RegisterSolenoidOpenBitIndexForTabIO(ByVal sName As String, ByVal MacID As String, ByVal OpenBitIndex As String) As String
            Dim strPropertyName As String = String.Empty

            Try
                Dim driverName As String = sName
                Dim objReceiver As DataManagerment.Equipment = GetObjectReciver(driverName)
                Select Case driverName
                    'slit valve PM
                    Case "SplitValvePM1"
                        driverName = "SlitValvePM1"
                        strPropertyName = "SplitValve2OpenStatus"
                    Case "SplitValvePM2"
                        driverName = "SlitValvePM2"
                        strPropertyName = "SplitValve3OpenStatus"
                    Case "SplitValvePM3"
                        driverName = "SlitValvePM3"
                        strPropertyName = "SplitValve4OpenStatus"

                        'slit valve LL
                    Case "SplitValveLLA"
                        driverName = "SlitValveLLA"
                        strPropertyName = "SplitValve1OpenStatus"
                    Case "SplitValveLLB"
                        driverName = "SlitValveLLB"
                        strPropertyName = "SplitValve8OpenStatus"
                    Case Else
                        AVPLib.Log.avpLogger.Info("Did not find property")
                End Select

                If Not String.IsNullOrEmpty(strPropertyName) Then
                    Dim strEquimentName As String = IIf(objReceiver.Name.ToString() = ConstEnum.Equipments.CassettesModule.ToString(), ConstEnum.STR_TRANSFER_MODULE, objReceiver.Name.ToString())
                    Dim nameBitIndex As String = String.Format("MacID{0}.Solenoid{1}.Bit{2} - {3}.{4} Open", Convert.ToSingle(MacID).ToString("00"), MacID, Convert.ToSingle(OpenBitIndex).ToString("00"), strEquimentName, driverName)

                    RegisterDeviceForTabIO(nameBitIndex, objReceiver, strPropertyName)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return strPropertyName
        End Function

        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2023-04-01 </date>
        ''' </author>
        ''' <summary>
        ''' RegisterSolenoidClosedBitIndexForTabIO
        ''' </summary>
        Public Shared Function RegisterSolenoidClosedBitIndexForTabIO(ByVal sName As String, ByVal MacID As String, ByVal ClosedBitIndex As String) As String
            Dim strPropertyName As String = String.Empty

            Try
                Dim driverName As String = sName
                Dim objReceiver As DataManagerment.Equipment = GetObjectReciver(driverName)
                Select Case driverName
                    'slit valve PM
                    Case "SplitValvePM1"
                        driverName = "SlitValvePM1"
                        strPropertyName = "SplitValve2CloseStatus"
                    Case "SplitValvePM2"
                        driverName = "SlitValvePM2"
                        strPropertyName = "SplitValve3CloseStatus"
                    Case "SplitValvePM3"
                        driverName = "SlitValvePM3"
                        strPropertyName = "SplitValve4CloseStatus"

                        'slit valve LL
                    Case "SplitValveLLA"
                        driverName = "SlitValveLLA"
                        strPropertyName = "SplitValve1CloseStatus"
                    Case "SplitValveLLB"
                        driverName = "SlitValveLLB"
                        strPropertyName = "SplitValve8CloseStatus"
                    Case Else
                        AVPLib.Log.avpLogger.Info("Did not find property")
                End Select
                If Not String.IsNullOrEmpty(strPropertyName) Then
                    Dim strEquimentName As String = IIf(objReceiver.Name.ToString() = ConstEnum.Equipments.CassettesModule.ToString(), ConstEnum.STR_TRANSFER_MODULE, objReceiver.Name.ToString())
                    Dim nameBitIndex As String = String.Format("MacID{0}.Solenoid{1}.Bit{2} - {3}.{4} Closed", Convert.ToSingle(MacID).ToString("00"), MacID, Convert.ToSingle(ClosedBitIndex).ToString("00"), strEquimentName, driverName)

                    RegisterDeviceForTabIO(nameBitIndex, objReceiver, strPropertyName)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return strPropertyName
        End Function

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' IsDeviceNetActive
        ''' </summary>
        ''' <value></value>
        Public Shared Function IsDeviceNetActive(ByVal macID As Integer)
            Dim result As Boolean = False

            Try
                Dim driver As ProxyDriverObject = DriverManager.GetDriver(macID)
                result = driver IsNot Nothing AndAlso
                driver.eCommunicationType = CommType.DeviceNet AndAlso driver.IsDeviceActive()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return result
        End Function

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-11 </date>
        ''' </author>
        ''' <summary>
        ''' AddListMacID
        ''' </summary>
        ''' <value></value>
        Public Shared Function AddListMacID(ByVal key As String, ByVal value As String)
            Dim result As Boolean = False

            Try
                If Not m_htbMacID.ContainsKey(key) Then
                    m_htbMacID.Add(key, value)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return result
        End Function
    End Class
End Namespace


