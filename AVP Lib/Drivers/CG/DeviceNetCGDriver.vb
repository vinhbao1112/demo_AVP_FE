Namespace Driver
    Public Class DeviceNetCGDriver
        Inherits DeviceNetDriver
        Implements ICGDriver

        ''' Byte array containing the pressure value
        Protected m_arrPressVal() As Byte = Nothing

        ''' Pressure value read from device
        Protected m_fPressure As Single = 0
        Protected m_Communication As Boolean = False
        ''' CG relay
        Protected m_CGRelay As DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Off
        ''' GP275 or GP354
        Protected m_deviceNetCGType As DeviceNetIGCGType
        'limit of CG relay, if CGPressure < Limit -> CGRelay On
        Protected m_CGRelayLimit As Single = 0.08
        Protected m_IsInitialized As Boolean = False
        Protected m_IsUpdateCommunicationError As Boolean = False
        Protected m_IsCalibrating As Boolean = False
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Get CG from real device
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Poll()
            ' Will be implemented in sub-class
        End Sub

        ''' <summary>
        ''' GP 354 or GP275
        ''' </summary>
        Public Property DNCGType() As DeviceNetIGCGType
            Get
                Return m_deviceNetCGType
            End Get
            Set(ByVal value As DeviceNetIGCGType)
                m_deviceNetCGType = value
            End Set
        End Property

        Public Overridable Sub UpdateDeviceCommunication()
            Dim old_comm As Boolean = m_Communication
            m_Communication = IsDeviceActive()
            If (old_comm <> m_Communication Or Not m_IsUpdateCommunicationError) Then
                If (m_Communication) Then
                    DriverUtility.UpdateCGCommunication(EquipmentName, AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                Else
                    DriverUtility.UpdateCGCommunication(EquipmentName, AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    m_fPressure = 0.0
                End If
                m_IsUpdateCommunicationError = True
            End If
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Get CG Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetCGRelay() As DataManagerment.Equipment.WorkingStatuses
            If Not m_IsCalibrating Then
            m_ExplicitData = New Byte(0) {}
            m_ExplicitData(0) = 13
            If (SendExplicitMessage(&HE, &H35, &H1)) Then

                Dim timeout As Int32 = 10000 '10s
                Wait4ExplicitReplyMsg(timeout)

                If (m_ExplicitDataReceive IsNot Nothing AndAlso m_ExplicitDataReceive.Length > 0) Then
                    Dim iResult As Integer = m_ExplicitDataReceive(0)
                    If (iResult = 0) Then
                        m_CGRelay = DataManagerment.Equipment.WorkingStatuses.Off
                    Else
                        m_CGRelay = DataManagerment.Equipment.WorkingStatuses.On
                    End If
                End If
            End If
            End If
            'AVPLib.Log.coreLogger.Error(Me.DriverName & " CGRelay=" & m_CGRelay.ToString)
            Return m_CGRelay
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update to GUI
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub UpdateGetCGRelay()
            Dim oldCGRelay As DataManagerment.Equipment.WorkingStatuses = m_CGRelay
            GetCGRelay()
            If (oldCGRelay <> m_CGRelay Or Not m_IsInitialized) Then
                DriverUtility.UpdateCGRelay(EquipmentName, m_CGRelay)
                m_IsInitialized = True
            End If
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Get CG Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Function EnableDisibleLowTripPoint(ByVal bEnable As Boolean) As Boolean
            m_ExplicitData = New Byte(1) {}
            m_ExplicitData(0) = 6
            m_ExplicitData(1) = IIf(bEnable = True, 1, 0)
            If (SendExplicitMessage(&H10, &H35, &H1)) Then

                Dim timeout As Int32 = 10000 '10s
                Wait4ExplicitReplyMsg(timeout)

                AVPLib.Log.coreLogger.Error(Me.DriverName & " EnableDisibleLowTripPoint=TRUE")
                Return True
            End If
            AVPLib.Log.coreLogger.Error(Me.DriverName & " EnableDisibleLowTripPoint=TRUE")
            Return False
        End Function
        
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Get CG Relay
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CGRelay() As DataManagerment.Equipment.WorkingStatuses Implements ICGDriver.CGRelay
            Get
                Return m_CGRelay
            End Get
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' 'limit of CG relay, if CGPressure < Limit -> CGRelay On
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CGRelayLimit() As Single
            Get
                Return m_CGRelayLimit
            End Get
            Set(ByVal value As Single)
                m_CGRelayLimit = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Get CG Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CGPressure() As Single Implements ICGDriver.CGPressure
            Get
                Return m_fPressure
            End Get
        End Property

        ''' <author>
        '''    	<name>Tinh Le</name>
        '''    	<date> 2018-29-11</date>
        ''' </author>
        ''' <summary>
        ''' Trip Point Value
        ''' </summary>
        Private m_TripPointValue As Single = 0.0F
        Public WriteOnly Property TripPointValue() As Single
            Set(ByVal value As Single)
                m_TripPointValue = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Initialize
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Function Intialize(ByVal CardHandle As Int32) As Boolean
            Return RegisterEquipment(CardHandle, 5, 0, 0)
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Initialize
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CleanUp()
            m_bIsDisposing = True
        End Sub

        ''' <summary>
        ''' New object IG device net
        ''' default IG device net type is GP 354
        ''' </summary>
        Public Sub New(ByVal sDriverName As String, _
                    ByVal iMacID As UShort, _
                    Optional ByVal eDeviceNetCGType As DeviceNetIGCGType = DeviceNetIGCGType.GP275)
            MyBase.new(sDriverName)
            m_DeviceConfig.MacId = iMacID
            m_deviceNetCGType = eDeviceNetCGType
        End Sub

        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub

        ''' <author>
        '''    	<name> Van Le</name>
        '''    	<date> 2014-09-04 </date>
        ''' </author>
        ''' <summary>
        ''' Set Value
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Function SetValue(ByVal strCmd As String) As Boolean Implements ICGDriver.SetValue
            Dim bResult As Boolean = False
            Try
                If strCmd = ConstEnum.DEVICENET_SET_ATM Then

                    ' Suspend polling CG Relay
                    m_IsCalibrating = True

                    ' Sleep a while to make sure polling paused
                    Threading.Thread.Sleep(2000)

                    ' Build message & send
                    m_iExplicitMsgSize = 4
                    m_ExplicitData = New Byte(3) {}
                    m_ExplicitData(0) = 0
                    m_ExplicitData(1) = 0
                    m_ExplicitData(2) = 62
                    m_ExplicitData(3) = 68
                    bResult = SendExplicitMessageWithMessageSize(&H4C, &H31, &H1)

                    ' Wait reply message if sending OK
                    If bResult Then
                        Wait4ExplicitReplyMsg(10000)
                    End If

                    ' Resume polling CG relay
                    m_IsCalibrating = False

                ElseIf strCmd = ConstEnum.DEVICENET_SET_VAC Then

                    ' Suspend polling CG Relay
                    m_IsCalibrating = True

                    ' Sleep a while to make sure polling paused
                    Threading.Thread.Sleep(2000)

                    ' Build message & send
                    m_IsCalibrating = True
                    m_iExplicitMsgSize = 4
                    m_ExplicitData = New Byte(3) {}
                    m_ExplicitData(0) = 111
                    m_ExplicitData(1) = 18
                    m_ExplicitData(2) = 131
                    m_ExplicitData(3) = 58
                    bResult = SendExplicitMessageWithMessageSize(&H4B, &H31, &H1)

                    ' Wait reply message if sending OK
                    If bResult Then
                        Wait4ExplicitReplyMsg(10000)
                    End If
                ElseIf strCmd.StartsWith(ConstEnum.SET_TRIP_POINT) Then
                    Dim value As String = strCmd.Substring(strCmd.IndexOf(" ") + 1)
                    TripPointValue = CType(value, Single)
                    bResult = SetCGTripPoint()

                    ' Wait reply message if sending OK
                    If bResult Then
                        Wait4ExplicitReplyMsg(10000)
                    End If
                End If

                ' Resume polling CG relay
                m_IsCalibrating = False
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            Return bResult
        End Function

        Public Overrides Sub Setup()
            Try
                ' Suspend polling CG Relay
                m_IsCalibrating = True
                m_ExplicitData = New Byte(1) {}

                m_iExplicitMsgSize = 2
                m_ExplicitData(0) = 6
                m_ExplicitData(1) = 1
                SendExplicitMessage(&H10, &H35, &H1)
                Wait4ExplicitReplyMsg()
                SetCGTripPoint()
                Wait4ExplicitReplyMsg()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try

            m_IsCalibrating = False
        End Sub
        Private Function SetCGTripPoint() As Boolean
            Dim result As Boolean = False
            Try
                Dim byteSetvalue As Byte() = BitConverter.GetBytes(m_TripPointValue)
                m_iExplicitMsgSize = 5
                m_ExplicitData = New Byte(4) {}
                m_ExplicitData(0) = 5
                m_ExplicitData(1) = byteSetvalue(0)
                m_ExplicitData(2) = byteSetvalue(1)
                m_ExplicitData(3) = byteSetvalue(2)
                m_ExplicitData(4) = byteSetvalue(3)
                result = SendExplicitMessage(&H10, &H35, &H1)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try

            Return result
        End Function
    End Class
End Namespace