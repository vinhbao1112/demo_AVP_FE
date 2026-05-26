'''NEW OBJECT
'''CALL ADD DEVICE TO LIST
''' CALL INITIALIZE
''' POLLING TO GET DATA
''' DISPOSE
Imports avplib.driver
Namespace DeviceNet
    Public Class DNSScanner
        Inherits DeviceNetThread
#Region "Private Variable"
        'connect to Device Net DLL
        Private m_objDnetController As New DeviceNetController()
        'object configuration parameter
        Private m_ScannerConfiguration As ScannerConfiguration = Nothing
        'share memory pointer
        Private m_iSharedMemoryOffsetPointer As UInt16 = 0
        'The name assigned to the interface card during hardware installation (stored in registry).
        Private m_strCardName As [String] = [String].Empty
        Private m_hCardHandle As Int32 = 0
        ' Is Already Scanning
        Private m_bScanning As [Boolean] = False
        ' Previous Bus Status
        Private m_iPrevBusStatus As Int32 = 0

        'read config file and add it to list of DNS device
        Private Shared m_lstDeviceNetDevice As Hashtable = Nothing
        'read config file and add it to list off valves
        Private Shared m_lstValveDriver As Hashtable = Nothing
        'read config file and add it to list off block
        Private Shared m_hstBlockDeviceDriver As Hashtable = Nothing 'MacID as key, DeviceRSTiDriver as value

        Private m_isSystemLoading As Boolean = True

        Private Shared m_objSolenoidBlock(2) As AVPLib.Driver.SolenoidDriver
        Private Shared m_IsInstallSolenoidBlock3 As Boolean = False
#End Region
#Region "Property"
        'Block of Driver base on MacID
        Public Shared ReadOnly Property RSTiBlockDriver() As Hashtable
            Get
                Return m_hstBlockDeviceDriver
            End Get
        End Property

        Public Property CardName() As [String]
            Get
                Return m_strCardName
            End Get
            Set(ByVal value As [String])
                m_strCardName = value
            End Set
        End Property

        Public Shared Function objSolenoidBlock(ByVal MacID As Integer) As SolenoidDriver

            Select Case MacID
                Case DriverConst.Solenoid_Block_1_MacID
                    Return m_objSolenoidBlock(0)
                Case DriverConst.Solenoid_Block_2_MacID
                    Return m_objSolenoidBlock(1)
                Case DriverConst.Solenoid_Block_3_MacID
                    Return m_objSolenoidBlock(2)
                Case Else
                    Return Nothing
            End Select
        End Function

        Public Shared Property IsInstallSolenoidBlock3() As Boolean
            Get
                Return m_IsInstallSolenoidBlock3
            End Get
            Set(ByVal value As Boolean)
                m_IsInstallSolenoidBlock3 = value
            End Set
        End Property

        Public Shared Function GetDeviceNetDriver(ByVal Name As String) As DeviceNetDriver
            Return IIf(m_lstDeviceNetDevice IsNot Nothing, m_lstDeviceNetDevice.Item(Name), Nothing)
        End Function

#End Region
        Public Sub New()
            MyBase.New("DeviceNetScanner")
            AVPLib.Log.coreLogger.Info("Enter New Object")

            isBackgroundThread = False

            m_iSharedMemoryOffsetPointer = &H1000

            ' Init the configuration structure for Scanner
            m_ScannerConfiguration = New ScannerConfiguration()

            m_lstDeviceNetDevice = New Hashtable()

            ' Init all Valves, All DO
            Dim maxSolenoiBlock As Integer = 2
            If (IsInstallSolenoidBlock3) Then
                maxSolenoiBlock = 3
            End If

            For i As Int32 = 0 To maxSolenoiBlock - 1
                AVPLib.Log.coreLogger.Info("Init SolenoidBlock " & i)
                m_objSolenoidBlock(i) = New AVPLib.Driver.SolenoidDriver("Valves")
                m_objSolenoidBlock(i).DnetController = m_objDnetController
                m_objSolenoidBlock(i).DeviceNetScanner = Me
            Next i

            AVPLib.Log.coreLogger.Info("Leave New Object")
        End Sub
        '
        Public Sub AddDeviceNetDriver(ByVal DeviceNetObj As DriverObject)
            If (m_lstDeviceNetDevice Is Nothing) Then
                m_lstDeviceNetDevice = New Hashtable()
            End If

            m_lstDeviceNetDevice.Add(DeviceNetObj.DriverName, DeviceNetObj)
        End Sub
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' Store more Block Device Driver 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddDeviceNetDriver(ByVal DeviceNetObj As DriverObject, ByVal MacID As String)
            If m_hstBlockDeviceDriver Is Nothing Then
                m_hstBlockDeviceDriver = New Hashtable
            End If
            m_hstBlockDeviceDriver.Add(MacID, DeviceNetObj)
        End Sub
        Public Sub AddValveDriver(ByVal DeviceNetObj As DriverObject)
            If (m_lstValveDriver Is Nothing) Then
                m_lstValveDriver = New Hashtable()
            End If
            m_lstValveDriver.Add(DeviceNetObj.DriverName, DeviceNetObj)
        End Sub
        '' <summary>
        '' Initilaize function
        '' </summary>
        '' <returns></returns>
        Public Function Initialize() As [Boolean]
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                'If MyBase.Initialize() Then
                ' Load DeviceNet driver
                If Not m_objDnetController.LoadDeviceNetDriver() Then
                    AVPLib.Log.coreLogger.[Error]("Load device net controller failed.")
                    Return False
                End If

                ' Init MacID
                m_ScannerConfiguration.MacId = 0

                'DO NOT GET CONFIG FILE
                If String.IsNullOrEmpty(Me.CardName) Then
                    AVPLib.Log.coreLogger.[Error]("Scanner card name is empty.")
                    m_objDnetController.UnloadDeviceNetDriver()
                    Return False
                End If

                'DO NOT OPEN CARD DNS WIGH CARD NAME AND GER CARD HANDLE
                If Not m_objDnetController.OpenCard(m_hCardHandle, Me.CardName) Then
                    AVPLib.Log.coreLogger.[Error]("Open Card Failed.")
                    m_objDnetController.UnloadDeviceNetDriver()
                    Return False
                End If

                'DeviceNet Scanner Baud Rate (0=125K, 1=250K, 2=500K) 
                '<DnetScannerBaudRate desc=""DeviceNet Scanner Baud Rate (0=125K, 1=250K, 2=500K)"" visible=""True"">0</DnetScannerBaudRate>"
                Dim cfgBaudRate As Int32 = ContainerDAO.GetDeviceNetBaudRate()
                If cfgBaudRate < 0 OrElse cfgBaudRate > 2 Then
                    ' BaudRate can only be 0,1,2
                    cfgBaudRate = 0
                End If

                ' Setup the configuration [0: 125K] - [1: 250K] - [2: 500K] 
                m_ScannerConfiguration.BaudRate = CUShort(cfgBaudRate)
                m_ScannerConfiguration.Io1Interval = 0
                m_ScannerConfiguration.ScanInterval = 100
                ' As fast as possible
                m_ScannerConfiguration.Flags = 0

                ' Bring Scanner Online
                If Not m_objDnetController.Online(m_hCardHandle, m_ScannerConfiguration) Then
                    AVPLib.Log.coreLogger.[Error]("Go Online Failed.")
                    CleanUp()
                    Return False
                End If

                ' Start Scanning
                If Not m_objDnetController.StartScan(m_hCardHandle) Then
                    AVPLib.Log.coreLogger.[Error]("Start Scan Failed.")
                    CleanUp()
                    Return False
                End If

                ' Mark that the scanner has scanned
                m_bScanning = True

                ' Wait for Bus Online
                Dim iBusStatus As Int32 = 0
                Dim span As Int64 = 60000 '1 min
                Dim start As Int64 = Environment.TickCount
                Do
                    If (Environment.TickCount - start >= span) Then
                        Utils.Create_Core_MessageBox("Devicenet is unable to go online.")
                        Exit Do
                    End If
                    iBusStatus = m_objDnetController.GetBusStatus(m_hCardHandle)
                    If iBusStatus = 0 Then
                        AVPLib.Log.coreLogger.[Error]("GetBusStatus failed.")
                        ' Has Error
                        CleanUp()
                        Return False
                    End If

                    ' Sleep 0.1s
                    System.Threading.Thread.Sleep(100)
                Loop While (iBusStatus And &H1) = 0

                '--------------------------------------------------------------------------------------------------------
                'FOR EACH DNS ON DNS LIST -> INITIALIZE
                If (m_lstDeviceNetDevice IsNot Nothing And m_lstDeviceNetDevice.Count > 0) Then
                    For Each Item As DictionaryEntry In m_lstDeviceNetDevice
                        Dim objDeviceNetDriver As DeviceNetDriver = Item.Value
                        objDeviceNetDriver.DeviceNetScanner = Me
                        objDeviceNetDriver.CardHandle = m_hCardHandle
                        objDeviceNetDriver.DnetController = m_objDnetController
                        If Not objDeviceNetDriver.Initialize() Then
                            AVPLib.Log.coreLogger.[Error]("Can not initialize " + objDeviceNetDriver.DriverName)
                            'Do not quit the loop here, continue to add other devices
                        Else
                        End If
                    Next
                End If

                '--------------------------------------------------------------------------------------------------------
                'FOR EACH DN RSTI ON DN RSTI LIST -> INITIALIZE
                If RobotConfigurationValues.IS_KEPWARE_INSTALLED = False Then
                    If (m_hstBlockDeviceDriver IsNot Nothing And m_hstBlockDeviceDriver.Count > 0) Then
                        For Each Item As DictionaryEntry In m_hstBlockDeviceDriver
                            Dim objDeviceNetDriver As DeviceNetDriver = Item.Value
                            objDeviceNetDriver.DeviceNetScanner = Me
                            objDeviceNetDriver.CardHandle = m_hCardHandle
                            objDeviceNetDriver.DnetController = m_objDnetController
                            If Not objDeviceNetDriver.Initialize() Then
                                AVPLib.Log.coreLogger.[Error]("Can not initialize " + objDeviceNetDriver.DriverName)
                                'Do not quit the loop here, continue to add other devices
                            Else
                            End If
                        Next
                    End If
                End If

                '------------------------------------------------------------------------------------------------------------
                ' Init All Valves, all DO
                m_objSolenoidBlock(0).CardHandle = m_hCardHandle
                m_objSolenoidBlock(0).MacID = DriverConst.Solenoid_Block_1_MacID
                If Not m_objSolenoidBlock(0).Initialize() Then
                    AVPLib.Log.coreLogger.[Error]("Init solenoidBlock 0 Failed.")
                    'Do not return here, continue to add other devices
                End If

                ' Init All Valves, all DO
                m_objSolenoidBlock(1).CardHandle = m_hCardHandle
                m_objSolenoidBlock(1).MacID = DriverConst.Solenoid_Block_2_MacID
                If Not m_objSolenoidBlock(1).Initialize() Then
                    AVPLib.Log.coreLogger.[Error]("Init solenoidBlock 1 Failed.")
                    'Do not return here, continue to add other devices
                End If

                If (IsInstallSolenoidBlock3) Then
                    ' Init All Valves, all DO
                    m_objSolenoidBlock(2).CardHandle = m_hCardHandle
                    m_objSolenoidBlock(2).MacID = DriverConst.Solenoid_Block_3_MacID
                    If Not m_objSolenoidBlock(2).Initialize() Then
                        AVPLib.Log.coreLogger.[Error]("Init solenoidBlock 1 Failed.")
                        'Do not return here, continue to add other devices
                    End If
                End If

                AVPLib.Log.coreLogger.[Error]("Init Valve device.")
                '' Init All Valve Drivers
                'If (m_lstValveDriver IsNot Nothing And m_lstValveDriver.Count > 0) Then
                '    For Each Item As DictionaryEntry In m_lstValveDriver
                '        Dim objValveDriver As DeviceNetValveDriver = Item.Value
                '        If Not objValveDriver.Initialize() Then
                '            AVPLib.Log.coreLogger.[Error]("Can not initialize " + objValveDriver.DriverName)
                '            'Do not quit the loop here, continue to add other devices
                '        Else
                '        End If
                '    Next
                'End If

                ' Starting Polling.
                Me.Start()
                Return True
            Catch ex As Exception
                AVPLib.Log.coreLogger.[Error](ex.Message)
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
            Return False
        End Function

        ''' <summary>
        ''' Thread for pulling data
        ''' </summary>
        Protected Overrides Sub OnDoWork()
            Try

                CollectCGRelayThread.StartCollectCGRelay()
                CollectValveStatusThread.StartCollectValveStatus()

                'kepware is not installed-> thread collect block is started
                If RobotConfigurationValues.IS_KEPWARE_INSTALLED = False Then
                    CollectBlockDeviceStatusThread.StartCollectBlockDevices()
                End If

                While False = HasTerminateRequest()
                    Dim awokenByTerminate As [Boolean] = SuspendIfNeeded()
                    If awokenByTerminate Then
                        Return
                    End If

                    ' Get data of all Device Net EQ
                    Me.PollAllDnetDevice()
                End While

            Finally
            End Try
        End Sub

        ''' <summary>
        ''' Log the friendly bus status
        ''' </summary>
        Private Sub LogBusStatus(ByVal iBusStatus As Int32)
            ' Log
            AVPLib.Log.coreLogger.[Error]("Bus Status = " & iBusStatus.ToString())

            ' Detail the Bus Status
            If (iBusStatus And &H1) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus On-Line")
            End If

            If (iBusStatus And &H2) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus Warning")
            End If

            If (iBusStatus And &H4) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus Off")
            End If

            If (iBusStatus And &H8) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus Network Activity Detected")
            End If

            If (iBusStatus And &H10) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus Transmit failed due to ACK error")
            End If

            If (iBusStatus And &H20) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus Transmit failed due to time-out")
            End If

            If (iBusStatus And &H40) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus Receive overrun")
            End If

            If (iBusStatus And &H80) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus Message lost")
            End If

            If (iBusStatus And &H100) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus CAN Communication Error")
            End If

            If (iBusStatus And &H200) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus Power Present")
            End If

            If (iBusStatus And &H1000) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus 125K")
            End If

            If (iBusStatus And &H2000) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus 250K")
            End If

            If (iBusStatus And &H4000) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus 500K")
            End If

            If (iBusStatus And &H8000) <> 0 Then
                AVPLib.Log.coreLogger.Debug("DNS Bus Scanner Active")
            End If
        End Sub

        ''' <summary>
        ''' Polling the value of all DeviceNet equipment
        ''' </summary>
        Private Sub PollAllDnetDevice()
            If (Not Me.HasTerminateRequest) Then
                ' Check thus bus status before polling
                Dim iBusStatus As Int32 = m_objDnetController.GetBusStatus(m_hCardHandle)
                If iBusStatus = 0 Then
                    ' Has Error
                    AVPLib.Log.coreLogger.[Error]("Can not get Bus Status")
                End If

                If m_iPrevBusStatus <> iBusStatus Then
                    ' Store
                    m_iPrevBusStatus = iBusStatus

                    ' Log the Bus Status
                    LogBusStatus(iBusStatus)
                End If

                If (m_lstDeviceNetDevice IsNot Nothing AndAlso m_lstDeviceNetDevice.Count > 0) Then
                    For Each Item As DictionaryEntry In m_lstDeviceNetDevice
                        Dim objDeviceNetDriver As DeviceNetDriver = Item.Value
                        If (objDeviceNetDriver IsNot Nothing) Then
                            objDeviceNetDriver.Poll()
                        End If

                        If Me.HasTerminateRequest() Then
                            AVPLib.Log.coreLogger.[Error]("Error, in stopping mode")
                            Return
                        End If
                    Next
                End If


                ' Sleep for a while
                If Me.IsStoping(500) Then
                    AVPLib.Log.coreLogger.[Error]("Error, in stopping mode")
                    Return
                End If
            Else
                AVPLib.Log.coreLogger.[Error]("Error, in stopping mode")
            End If
        End Sub

        ''' <summary>
        ''' Alocate the memory
        ''' </summary>
        ''' <param name="nNumberOfBytes"></param>
        ''' <returns></returns>
        Public Function GetMemoryOffset(ByVal iNumberOfBytes As UInt16) As UInt16
            Dim iOffset As UInt16

            iOffset = m_iSharedMemoryOffsetPointer
            m_iSharedMemoryOffsetPointer += iNumberOfBytes

            Return iOffset
        End Function

        ''' <summary>
        ''' Clean Up the scanner
        ''' </summary>
        Public Sub CleanUp()
            ' If deviceNet app, do not need to clean up
            If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                Exit Sub
            End If

            ' Stop scanning
            If m_bScanning Then
                If Not m_objDnetController.StopScan(m_hCardHandle) Then
                    AVPLib.Log.coreLogger.[Error]("Can not stop scanning!")
                End If
            End If

            ' Sleep for a while
            System.Threading.Thread.Sleep(2000)

            ' Offline card
            If Not m_objDnetController.Offline(m_hCardHandle) Then
                AVPLib.Log.coreLogger.[Error]("Can not offline!")
            End If

            ' Sleep for a while
            System.Threading.Thread.Sleep(1000)

            ' Close card
            If Not m_objDnetController.CloseCard(m_hCardHandle) Then
                AVPLib.Log.coreLogger.[Error]("Can not close card!")
            End If

            ' Sleep for a while
            System.Threading.Thread.Sleep(1000)

            ' Unload driver
            If Not m_objDnetController.UnloadDeviceNetDriver() Then
                AVPLib.Log.coreLogger.[Error]("Can not free DeviceNet driver!")
            End If

            ' Sleep for 6s for unloading driver
            System.Threading.Thread.Sleep(6000)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then

                ' Sleep for a while for state updating completely
                System.Threading.Thread.Sleep(1000)

                CollectCGRelayThread.StopCollectCGRelay()
                CollectValveStatusThread.StopCollectValveStatus()

                If RobotConfigurationValues.IS_KEPWARE_INSTALLED = False Then
                    CollectBlockDeviceStatusThread.StopCollectBlockDevices()
                End If

                If (m_lstDeviceNetDevice IsNot Nothing AndAlso m_lstDeviceNetDevice.Count > 0) Then
                    For Each Item As DictionaryEntry In m_lstDeviceNetDevice
                        Dim objDeviceNetDriver As DriverObject = Item.Value
                        If (objDeviceNetDriver IsNot Nothing) Then
                            objDeviceNetDriver.Dispose()
                        End If
                    Next
                End If

                ' Stop the polling thread
                Me.Terminate()

                ' Clean Up the DeviceNet system
                ' Wait for a 5 for state stopped completely
                Me.Join(5000)
                '''////////////////////////////////////////////////////////////
                ' TODO: Add more code here to clean up every thing before down
                '''////////////////////////////////////////////////////////////

                CleanUp()
            End If

            MyBase.Dispose(disposing)
        End Sub

        Private Class CollectCGRelayThread
            Inherits SuspendableThread

            Public Sub New()
                MyBase.New()
            End Sub
            Protected Overrides Sub OnDoWork()

                ' default 3 seconds
                Const iDelayTime As Int32 = 2 's
                ' Second Unit.
                Try
                    ' Initial delay time.

                    If IsStoping(iDelayTime * 1000) Then
                        Return
                    End If

                    While False = HasTerminateRequest()

                        Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                        If (awokenByTerminate) Then
                            Exit While
                        End If

                        If (m_lstDeviceNetDevice IsNot Nothing AndAlso m_lstDeviceNetDevice.Count > 0) Then
                            For Each Item As DictionaryEntry In m_lstDeviceNetDevice
                                Dim objDeviceNetDriver As DeviceNetDriver = Item.Value
                                If (objDeviceNetDriver IsNot Nothing AndAlso TypeOf (objDeviceNetDriver) Is DeviceNetCGDriver) Then
                                    CType(objDeviceNetDriver, DeviceNetCGDriver).UpdateGetCGRelay()
                                End If

                                If Me.HasTerminateRequest() Then
                                    AVPLib.Log.coreLogger.[Error]("Error, in stopping mode")
                                    Return
                                End If
                            Next
                        End If

                        ' Sleep for a while, then resume checking.
                        If IsStoping(500) Then
                            Return
                        End If
                    End While
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Error(ex.Message)
                End Try
            End Sub

            Private Shared m_CollectCGRelayThread As CollectCGRelayThread = Nothing
            ''' <summary>
            ''' Start Safety Interlock Loop
            ''' </summary>
            ''' <returns></returns>
            Public Shared Sub StartCollectCGRelay()
                ' Lazy Initialization
                If m_CollectCGRelayThread Is Nothing Then
                    m_CollectCGRelayThread = New CollectCGRelayThread()
                End If
                m_CollectCGRelayThread.Start()
            End Sub
            ''' <summary>
            ''' Stop Safety Interlock Loop
            ''' </summary>
            ''' <returns></returns>
            Public Shared Sub StopCollectCGRelay()
                If m_CollectCGRelayThread IsNot Nothing Then
                    m_CollectCGRelayThread.TerminateAndWait()
                    m_CollectCGRelayThread.Dispose()
                End If
            End Sub
        End Class

        Private Class CollectValveStatusThread
            Inherits SuspendableThread

            Public Sub New()
                MyBase.New()
            End Sub
            Protected Overrides Sub OnDoWork()

                ' default 3 seconds
                Const iDelayTime As Int32 = 2 's
                ' Second Unit.
                Try
                    ' Initial delay time.

                    If IsStoping(iDelayTime * 1000) Then
                        Return
                    End If

                    While False = HasTerminateRequest()

                        Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                        If (awokenByTerminate) Then
                            Exit While
                        End If

                        Dim maxSolenoidBlock As Integer = 2
                        If (IsInstallSolenoidBlock3) Then
                            maxSolenoidBlock = 3
                        End If

                        For index As Integer = 0 To maxSolenoidBlock - 1
                            m_objSolenoidBlock(index).SyncData()
                        Next

                        If (m_lstValveDriver IsNot Nothing AndAlso m_lstValveDriver.Count > 0) Then
                            For Each Item As DictionaryEntry In m_lstValveDriver
                                Dim objValveDriver As DeviceNetValveDriver = Item.Value
                                If (objValveDriver IsNot Nothing) Then
                                    objValveDriver.Poll()
                                End If

                                If Me.HasTerminateRequest() Then
                                    AVPLib.Log.coreLogger.[Error]("Error, in stopping mode")
                                    Return
                                End If
                            Next
                        End If

                        ' Sleep for a while, then resume checking.
                        If IsStoping(500) Then
                            Return
                        End If
                    End While
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Error(ex.Message)
                End Try
            End Sub

            Private Shared m_CollectValveStatusThread As CollectValveStatusThread = Nothing
            ''' <summary>
            ''' Start Safety Interlock Loop
            ''' </summary>
            ''' <returns></returns>
            Public Shared Sub StartCollectValveStatus()
                ' Lazy Initialization
                If m_CollectValveStatusThread Is Nothing Then
                    m_CollectValveStatusThread = New CollectValveStatusThread()
                End If
                m_CollectValveStatusThread.Start()
            End Sub
            ''' <summary>
            ''' Stop Safety Interlock Loop
            ''' </summary>
            ''' <returns></returns>
            Public Shared Sub StopCollectValveStatus()
                If m_CollectValveStatusThread IsNot Nothing Then
                    m_CollectValveStatusThread.TerminateAndWait()
                    m_CollectValveStatusThread.Dispose()
                End If
            End Sub

        End Class

        Private Class CollectBlockDeviceStatusThread
            Inherits SuspendableThread

            Public Sub New()
                MyBase.New()
            End Sub
            Protected Overrides Sub OnDoWork()
                ' default 3 seconds
                Const iDelayTime As Int32 = 2 's
                ' Second Unit.
                Try
                    ' Initial delay time.

                    If IsStoping(iDelayTime * 1000) Then
                        Return
                    End If

                    While False = HasTerminateRequest()

                        Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                        If (awokenByTerminate) Then
                            Exit While
                        End If


                        If (m_lstValveDriver IsNot Nothing AndAlso m_lstValveDriver.Count > 0) Then
                            For Each blockItem As DictionaryEntry In m_hstBlockDeviceDriver

                                If Me.HasTerminateRequest() Then
                                    AVPLib.Log.coreLogger.[Error]("Error, in stopping mode")
                                    Return
                                End If

                                Dim objblockRSTI As DeviceRSTiDriver = blockItem.Value
                                objblockRSTI.Poll()
                            Next

                        End If

                        ' Sleep for a while, then resume checking.
                        If IsStoping(500) Then
                            Return
                        End If
                    End While
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Error(ex.Message)
                End Try
            End Sub

            Private Shared m_CollectBlockDevicesThread As CollectBlockDeviceStatusThread = Nothing
            ''' <summary>
            ''' Start Safety Interlock Loop
            ''' </summary>
            ''' <returns></returns>
            Public Shared Sub StartCollectBlockDevices()
                ' Lazy Initialization
                If m_CollectBlockDevicesThread Is Nothing Then
                    m_CollectBlockDevicesThread = New CollectBlockDeviceStatusThread()
                End If
                m_CollectBlockDevicesThread.Start()
            End Sub
            ''' <summary>
            ''' Stop Safety Interlock Loop
            ''' </summary>
            ''' <returns></returns>
            Public Shared Sub StopCollectBlockDevices()
                If m_CollectBlockDevicesThread IsNot Nothing Then
                    m_CollectBlockDevicesThread.TerminateAndWait()
                    m_CollectBlockDevicesThread.Dispose()
                End If
            End Sub

        End Class
    End Class
End Namespace
