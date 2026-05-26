Imports avplib.DeviceNet
Namespace Driver
    Public Class DeviceNetDriver
        Inherits DriverObject
        Implements IDeviceStatus

#Region "Local Variable and Property"
        ' Device configuration structure
        Protected m_DeviceConfig As DeviceConfiguration = Nothing
        ' Card handle of master device
        Protected m_hCardHandle As Int32 = 0
        ' Device Net Controller Class
        Protected m_objDnetController As DeviceNetController = Nothing
        ''' Device Net Scanner is used to manage all Dnet Device
        Protected m_objDeviceNetScanner As DNSScanner = Nothing
        ' Explicit Data Message
        Protected m_ExplicitData As Byte() = Nothing
        '/// Explicit Data Message Size
        Protected m_iExplicitMsgSize As UShort = 64
        ' Explicit Data Message
        Protected m_ExplicitDataReceive As Byte() = Nothing
        ' Device Status
        Protected m_DeviceStatus As New DeviceNetStatus()
        ''' Previous status
        Private m_PrevStatus As Byte = 0
        ''' Need to config for the first time
        Private m_RequiredConfigure As [Boolean] = True
        ''' Store the current device event
        Private m_iDeviceEvent As Int32
        ''' pointer to data
        Protected m_arrBuffer As Byte() = Nothing
        ''' Is Object is clean up
        Protected m_bIsDisposing As [Boolean] = False
        ''' Explicit state
        Protected m_ExplicitState As enExplicitState = enExplicitState.explicitIdle
        Private m_objDeviceList As Dictionary(Of UInt16, DeviceConfiguration) = New Dictionary(Of UInt16, DeviceConfiguration)()

        Public WriteOnly Property MacID() As Int32
            Set(ByVal value As Int32)
                If (m_DeviceConfig Is Nothing) Then
                    m_DeviceConfig = New DeviceConfiguration
                End If
                m_DeviceConfig.MacId = value
            End Set
        End Property
        Public WriteOnly Property CardHandle() As Int32
            Set(ByVal value As Int32)
                m_hCardHandle = value
            End Set
        End Property
        Public WriteOnly Property DeviceNetScanner() As DNSScanner
            Set(ByVal value As DNSScanner)
                m_objDeviceNetScanner = value
            End Set
        End Property
        Public WriteOnly Property DnetController() As DeviceNetController
            Set(ByVal value As DeviceNetController)
                m_objDnetController = value
            End Set
        End Property
#End Region
        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="p_objMaster"></param>
        Public Sub New(ByVal sDeviceName As String)
            MyBase.new(sDeviceName)
            ' Init Device Configuration data
            m_DeviceConfig = New DeviceConfiguration()
        End Sub

        Public Overrides Function Initialize() As Boolean
            'default, must override on child class
            Return RegisterEquipment(m_hCardHandle, 2, 2, 0)
        End Function
        ''' <summary>
        ''' Get Data from the real device
        ''' </summary>
        Public Overridable Sub Poll()
            'do nothing
        End Sub

        ''' <summary>
        ''' Add device to scan list
        ''' </summary>
        ''' <param name="CardHandle"></param>
        ''' <param name="DeviceId"></param>
        ''' <param name="inputSize"></param>
        ''' <param name="outputSize"></param>
        ''' <param name="explicitSize"></param>
        ''' <returns></returns>
        Public Function RegisterEquipment(ByVal CardHandle As Int32, _
                                    ByVal inputSize As UInt16, ByVal outputSize As UInt16, _
                                    ByVal explicitSize As UInt16) As [Boolean]

            AVPLib.Log.coreLogger.Debug("Add Device " & Me.DriverName & " CardHandle " & CardHandle & " inputSize " & inputSize & _
            " OutputSize " & outputSize & " explicitSize " & explicitSize & " MacID=" & m_DeviceConfig.MacId)

            m_hCardHandle = CardHandle

            AVPLib.Log.coreLogger.Debug("CardHandle=" & CardHandle)

            m_DeviceConfig.Input1Size = inputSize
            If inputSize > 0 Then
                m_DeviceConfig.Flags = m_DeviceConfig.Flags Or DriverConst.SS_P
                m_DeviceConfig.Input1Offset = m_objDeviceNetScanner.GetMemoryOffset(inputSize)
            End If

            m_DeviceConfig.Output1Size = outputSize
            If outputSize > 0 Then
                m_DeviceConfig.Flags = m_DeviceConfig.Flags Or DriverConst.SS_P
                m_DeviceConfig.Output1Offset = m_objDeviceNetScanner.GetMemoryOffset(outputSize)
            End If

            If explicitSize > 0 Then
                m_DeviceConfig.Flags = m_DeviceConfig.Flags Or DriverConst.SS_EX
                m_DeviceConfig.ExplicitSize = explicitSize
                m_DeviceConfig.ExplicitOffset = m_objDeviceNetScanner.GetMemoryOffset(m_DeviceConfig.ExplicitSize)
            End If

            If m_objDeviceList.ContainsKey(m_DeviceConfig.MacId) Then
                m_objDeviceList.Add(m_DeviceConfig.MacId, m_DeviceConfig)
            End If
            Dim res As [Boolean] = m_objDnetController.AddDevice(m_hCardHandle, m_DeviceConfig)
            If res = False Then
                AVPLib.Log.coreLogger.DebugFormat("Error when adding the device. CardHandle ={0}, DriverName ={1}, inputSize ={2}, outputSize={3},explicitSize={4}", _
                                                  CardHandle, Me.DriverName, inputSize, outputSize, explicitSize)
            End If

            Return res
        End Function

        ''' <summary>
        ''' Check if the current device is OK or not
        ''' </summary>
        ''' <returns></returns>
        Public Function IsDeviceActive() As [Boolean] Implements IDeviceStatus.IsDeviceActive
            Return m_objDnetController.IsDeviceActive(m_DeviceStatus.StatusCode)
        End Function

        ''' <summary>
        ''' Poll the status of current equipment
        ''' </summary>
        Public Sub GetDeviceStatus()
            m_DeviceStatus = m_objDnetController.GetDeviceStatus(m_hCardHandle, m_DeviceConfig.MacId)
            If m_DeviceStatus Is Nothing Then
                AVPLib.Log.coreLogger.Debug("Error when getting the device status")
                Return
            End If

            If m_PrevStatus <> m_DeviceStatus.StatusCode Then
                If m_objDnetController.IsDeviceActive(m_PrevStatus) Then
                    AVPLib.Log.coreLogger.Debug("Device is not active")
                End If
                m_PrevStatus = m_DeviceStatus.StatusCode
            End If

            If m_objDnetController.IsDeviceActive(m_PrevStatus) AndAlso m_RequiredConfigure AndAlso IsExplicitIdle() Then
                Setup()
                m_RequiredConfigure = False
            End If
        End Sub

        ''' <summary>
        ''' Get Data from device and update to a buffer
        ''' </summary>
        ''' <returns></returns>
        Public Function ReadData() As [Boolean]

            Dim retVal As Boolean = False

                If Not m_objDnetController.IsDeviceActive(m_DeviceStatus.StatusCode) Then

                    AVPLib.Log.coreLogger.Debug("Device is not active")

                Else

                    ' Get device event flag 1
                    m_iDeviceEvent = m_objDnetController.GetDeviceEvent(m_hCardHandle, m_DeviceConfig.MacId, DriverConst.DNS_IO1_EVENT)

                    If m_iDeviceEvent = -1 Then

                        AVPLib.Log.coreLogger.Debug("not ready to read data now")

                    Else

                        ' Data is available to update
                        If (m_iDeviceEvent And DriverConst.DNS_INPUT_DATA_UPDATE) <> 0 Then

                            ' Read IO data from this device
                            m_arrBuffer = m_objDnetController.ReadDeviceIo(m_hCardHandle, m_DeviceConfig.MacId, m_DeviceConfig.Input1Size)
                            If m_arrBuffer IsNot Nothing Then
                                retVal = True
                            Else
                                AVPLib.Log.coreLogger.Debug("Error when getting data from the device.")
                            End If

                            'Process empty message
                        ElseIf (m_iDeviceEvent And DriverConst.DNS_RECEIVE_IDLE) <> 0 Then

                            m_arrBuffer = m_objDnetController.ReadDeviceIo(m_hCardHandle, m_DeviceConfig.MacId, m_DeviceConfig.Input1Size)
                            AVPLib.Log.coreLogger.Debug("Mac Id: " & m_DeviceConfig.MacId.ToString() & " receive zero-length message.")
                            retVal = False
                        End If
                    End If

                End If

            ' return
            Return retVal
        End Function

        ''' <summary>
        ''' Write data to IO device
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function WriteData() As [Boolean]
            ' Please construct m_arrBuffer array before call this function (size = m_DeviceConfig.Output1Size)
            Dim retVal As Boolean = m_objDnetController.WriteDeviceIo(m_hCardHandle, m_DeviceConfig.MacId, m_arrBuffer)
            If Not retVal Then
                AVPLib.Log.coreLogger.Debug("Error when writting data to the device.")
            End If
            Return retVal
        End Function

        ''' <summary>
        ''' Send Explicit Message
        ''' </summary>
        ''' <param name="DNservice"></param>
        ''' <param name="DNclass"></param>
        ''' <param name="DNinstance"></param>
        ''' <param name="?"></param>
        ''' <returns></returns>
        Public Function SendExplicitMessage(ByVal ServiceID As Int16, ByVal ClassID As Int16, ByVal InstanceID As Int16) As [Boolean]
            ' Please construct m_ExplicitData array before call this function (size = m_DeviceConfig.ExplicitSize as maximum)
            Dim retVal As Boolean = m_objDnetController.SendExplicitMessage(m_hCardHandle, m_DeviceConfig.MacId, ServiceID, ClassID, InstanceID, m_ExplicitData)
            If Not retVal Then
                AVPLib.Log.coreLogger.Error("Send Explicit Messsage Error.")
                Return False
            Else
                m_ExplicitState = enExplicitState.explicitSent

            End If
            Return retVal
        End Function

        Public Function SendExplicitMessageWithMessageSize(ByVal ServiceID As Int16, ByVal ClassID As Int16, ByVal InstanceID As Int16) As [Boolean]
            ' Please construct m_ExplicitData array before call this function (size = m_DeviceConfig.ExplicitSize as maximum)
            Dim retVal As Boolean = m_objDnetController.SendExplicitMessage(m_hCardHandle, m_DeviceConfig.MacId, ServiceID, ClassID, InstanceID, m_ExplicitData, m_iExplicitMsgSize)
            If Not retVal Then
                AVPLib.Log.coreLogger.Error("Send Explicit Messsage Error.")
                Return False
            Else
                m_ExplicitState = enExplicitState.explicitSent

            End If
            Return retVal
        End Function

        ''' <summary>
        ''' Config the current device
        ''' </summary>
        Public Overridable Sub Setup()
            ' Will be implement in sub-class
        End Sub

        ''' <summary>
        ''' Is Explicit Idle
        ''' </summary>
        ''' <returns></returns>
        Public Function IsExplicitIdle() As [Boolean]
            Return (m_ExplicitState = enExplicitState.explicitIdle)
        End Function

        ''' <summary>
        ''' Wait for explicit message reply
        ''' </summary>
        ''' <returns></returns>
        Public Function ReceiveExplicit() As [Boolean]
            Dim retVal As [Boolean] = False
            Dim explicitEventFlag As Int32
            Dim ServiceID As Int32 = 0


            If (m_ExplicitState = enExplicitState.explicitIdle) Then

                retVal = False

            ElseIf (m_ExplicitState = enExplicitState.explicitSent) Then

                explicitEventFlag = m_objDnetController.GetDeviceEvent(m_hCardHandle, m_DeviceConfig.MacId, 3)
                If explicitEventFlag = -1 Then
                    AVPLib.Log.coreLogger.Debug("Get Device Event Error.")
                    Return False
                End If
                If explicitEventFlag <> 0 Then
                    m_ExplicitState = enExplicitState.explicitReady
                End If

                retVal = False

            ElseIf (m_ExplicitState = enExplicitState.explicitReady) Then

                m_ExplicitDataReceive = m_objDnetController.ReceiveExplicit(m_hCardHandle, m_DeviceConfig.MacId, ServiceID)
                If m_ExplicitDataReceive Is Nothing Then
                    AVPLib.Log.coreLogger.Debug("Receive Explicit Error On MacID: " & m_DeviceConfig.MacId.ToString())
                    m_ExplicitState = enExplicitState.explicitIdle
                    Return True
                End If

                m_ExplicitState = enExplicitState.explicitReceived

                retVal = False

            ElseIf (m_ExplicitState = enExplicitState.explicitReceived) Then

                m_ExplicitState = enExplicitState.explicitIdle
                retVal = True

            End If

            ' If not receiving message, result will be always false
            Return retVal
        End Function

        ''' <summary>
        ''' Wait for explicit message reply
        ''' </summary>
        Public Function Wait4ExplicitReplyMsg(Optional ByVal iTimeout As Int32 = 0) As Boolean

            Dim rorStartTickCount As Int64 = Environment.TickCount

            While True

                If ReceiveExplicit() Then
                    Return True
                End If

                If Utils.GetTickCountDelta(rorStartTickCount) > iTimeout Then
                    Exit While
                End If

                If m_bIsDisposing Then
                    Exit While
                End If
                System.Threading.Thread.Sleep(200)

            End While

            Return False
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Public Overrides Sub Dispose()
            MyBase.Dispose()
            m_bIsDisposing = True
        End Sub
        Public Enum enExplicitState
            explicitIdle
            explicitSent
            explicitReady
            explicitReceived
        End Enum
    End Class
End Namespace
