Imports System.Timers
Imports AVPLib.Communication.TerminalDriver
Imports AVPLib.DataManagerment
Imports AVPLib.Communication
Imports System.Text

Namespace Driver
    Public Class SerialLeboldMAGTurboDriver
        Inherits DriverObject
        Implements IPumpPackageDriver

#Region "Class Constants & Variables"

        Public Enum ControlMode
            Serial = 0
            Remote = 1
        End Enum

        Const COMMUNICATION_TIMEOUT As Integer = 3000  '3 seconds
        Const POLLING_INTERVAL As Integer = 1000  '1 seconds

        Private m_tmrPollingTimer As Timer
        Private m_nTimeOut As Int32 = COMMUNICATION_TIMEOUT
        Dim m_bHasStopRequest As Boolean = False

        Private m_nTurboDrivingSpeed As Integer = 0
        Private m_fRampingPercent As Single = 0

        Const ACTUAL_FREQUENCY_POLLING_REQ As Integer = 3
        Const TURN_ON_OFF_CMD As Integer = 0
        Const REQUESTED_COMMAND As String = "0001"
        Const WRITE_COMMAND As String = "0000"
        Private m_bTurboStatus As Boolean = False
        Private m_bTurboPumpStatus As Integer = 0
        Private m_bTurboUpToSpeed As Boolean = False
        Private m_nCommErrorCounter As Integer = 0
        Private m_eCommunicationStatus As Equipment.WorkingStatuses = Equipment.WorkingStatuses.Unknown
        Private m_bIsTurningOn As Boolean = False
#End Region

#Region "Constructors & Dispose"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Contrucctor
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String, ByVal bSetPointFrequency As Double)
            MyBase.new(sDriverName)
            m_tmrPollingTimer = New Timer
            AddHandler m_tmrPollingTimer.Elapsed, AddressOf Polling
            m_tmrPollingTimer.Interval = POLLING_INTERVAL
            m_tmrPollingTimer.Enabled = True

            Me.EquipmentName = sDriverName
            Me.TurboSetPointFrequency = bSetPointFrequency
            ''Default comunication is true
            ''UpdateStatus("IsTurboCommunicating", True)
        End Sub
#End Region

#Region "Properties"

        Public Property TurboUpToSpeed() As Boolean
            Get
                Return m_bTurboUpToSpeed
            End Get
            Set(ByVal value As Boolean)
                m_bTurboUpToSpeed = value
                UpdateStatus("TurboUptoSpeed", m_bTurboUpToSpeed)
            End Set
        End Property

        Public Property TurboPumpStatus() As Integer
            Get
                Return m_bTurboPumpStatus
            End Get
            Set(ByVal value As Integer)
                m_bTurboPumpStatus = value
            End Set
        End Property

        Public Property TurboStatus() As Boolean
            Get
                Return m_bTurboStatus
            End Get
            Set(ByVal value As Boolean)
                m_bTurboStatus = value
                UpdateStatus("TurboStatus", m_bTurboStatus)
            End Set
        End Property

        Public Property TurboRampingPercent() As Single
            Get
                Return m_fRampingPercent
            End Get
            Set(ByVal value As Single)
                m_fRampingPercent = value
                UpdateStatus("RampingPercent", m_fRampingPercent)
            End Set
        End Property


        Public Property HasStopRequest() As Boolean
            Get
                Return m_bHasStopRequest
            End Get
            Set(ByVal value As Boolean)
                m_bHasStopRequest = value
            End Set
        End Property
#End Region

#Region "IPumpackageInterface"
        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2021-12-24 </date>
        ''' </author>
        ''' <summary>
        ''' Turn off Turbo
        ''' </summary>
        Public Function TurnOff() As Boolean Implements IPumpPackageDriver.TurnOff
            AVPLib.Log.coreLogger.Info("Enter TurnOff")
            Dim bResult As Boolean = False
            Try
                AVPLib.Log.avpLogger.Debug("Enter DeviceNetTurboDriver.TurnOff")
                AVPLib.Log.avpLogger.Debug("Enter DeviceNetTurboDriver.TurnOn")

                Dim command As Byte() = BuildControlCommand(TURN_ON_OFF_CMD, WRITE_COMMAND, False)
                Dim response As Byte() = Nothing
                Dim MAX_RETRY_SEND_CMD As Integer = 2

                For i As Integer = 0 To MAX_RETRY_SEND_CMD
                    If SendCmdToDevice(command, response, m_nTimeOut) Then
                        TurboStatus = False
                        bResult = True
                        Exit For
                    End If
                Next

                If Not bResult Then
                    UpdateCommunicationStatus(False)
                End If
                m_bIsTurningOn = False
                AVPLib.Log.avpLogger.Debug("Leave DeviceNetTurboDriver.TurnOff")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOff")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2021-12-24 </date>
        ''' </author>
        ''' <summary>
        ''' Turn on Turbo
        ''' </summary>
        Public Function TurnOn() As Boolean Implements IPumpPackageDriver.TurnOn
            AVPLib.Log.coreLogger.Info("Enter TurnOn")
            Dim bResult As Boolean = False
            Try
                AVPLib.Log.avpLogger.Debug("Enter DeviceNetTurboDriver.TurnOn")

                Dim command As Byte() = BuildControlCommand(TURN_ON_OFF_CMD, WRITE_COMMAND, True)
                Dim response As Byte() = Nothing
                m_bIsTurningOn = True
                Dim MAX_RETRY_SEND_CMD As Integer = 2

                For i As Integer = 0 To MAX_RETRY_SEND_CMD
                    If SendCmdToDevice(command, response, m_nTimeOut) Then
                        TurboStatus = True
                        bResult = True
                        Exit For
                    End If
                Next

                If Not bResult Then
                    UpdateCommunicationStatus(False)
                    m_bIsTurningOn = False
                End If

                AVPLib.Log.avpLogger.Debug("Leave DeviceNetTurboDriver.TurnOn")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOn")
            Return bResult
        End Function

#Region "Cryo functions - Not implement in Turbo driver"
        Public Function StartFastRegen() As Boolean Implements IPumpPackageDriver.StartFastRegen
            AVPLib.Log.coreLogger.Error("StartFastRegen does not suppport by Turbo")
            Return False
        End Function

        Public Function StartRegen() As Boolean Implements IPumpPackageDriver.StartRegen
            AVPLib.Log.coreLogger.Error("StartRegen does not suppport by Turbo")
            Return False
        End Function

        Public Function StopRegen() As Boolean Implements IPumpPackageDriver.StopRegen
            AVPLib.Log.coreLogger.Error("StopRegen does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetExtendedPurgeTime(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetExtendedPurgeTime
            AVPLib.Log.coreLogger.Error("CryoSetExtendedPurgeTime does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetPumpRestartDelay(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetPumpRestartDelay
            AVPLib.Log.coreLogger.Error("CryoSetPumpRestartDelay does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetRateOfRise(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRateOfRise
            AVPLib.Log.coreLogger.Error("CryoSetRateOfRise does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetRepurgeCycles(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRepurgeCycles
            AVPLib.Log.coreLogger.Error("CryoSetRepurgeCycles does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetRoughToPressure(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRoughToPressure
            AVPLib.Log.coreLogger.Error("CryoSetRoughToPressure does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetStartUpTemp(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetStartUpTemp
            AVPLib.Log.coreLogger.Error("CryoSetStartUpTemp does not suppport by Turbo")
            Return False
        End Function
#End Region

#End Region


#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Message received timeout
        ''' </summary>
        ''' <remarks></remarks>
        Public Property TimeOut() As Int32
            Get
                Return m_nTimeOut
            End Get
            Set(ByVal value As Int32)
                m_nTimeOut = value
            End Set
        End Property
#End Region

#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        '''  Polling Turbo status
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Polling(ByVal source As Object, ByVal e As ElapsedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter Pulling")
            Dim EquipmentName As String = Me.EquipmentName
            Try
                m_tmrPollingTimer.Enabled = False

                If Not HasStopRequest Then
                    GetDrivingFrequency()
                End If

                If Not HasStopRequest Then
                    m_tmrPollingTimer.Enabled = True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Pulling")
        End Sub

#End Region

#Region "Private Methods"

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22</date>
        ''' </author>
        ''' <summary>
        ''' Get Rotation Percentage
        ''' </summary>
        Public Function GetDrivingFrequency() As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetDrivingFrequency")
            Dim bResult As Boolean = False
            Try
                Dim command As Byte() = BuildCommand(ACTUAL_FREQUENCY_POLLING_REQ, REQUESTED_COMMAND)
                Dim response As Byte() = Nothing
                If SendCmdToDevice(command, response, m_nTimeOut) Then

                    If Not ValidateReplyMessageCheckSum(response) Then
                        AVPLib.Log.coreLogger.Error("Leave GetDrivingFrequency")
                        UpdateCommunicationStatus(False)
                        Return False
                    End If

                    Dim data As String = GetReplyMessageData(response)
                    m_nTurboDrivingSpeed = Convert.ToUInt16(data)
                    TurboRampingPercent = GetRampingPercentage()
                    UpdateCommunicationStatus(True)
                Else
                    m_nTurboDrivingSpeed = 0
                    TurboRampingPercent = 0
                    UpdateCommunicationStatus(False)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetDrivingFrequency")
            Return bResult
        End Function

        Private Function GetRampingPercentage() As Single
            Dim fPercent As Single = 0.0F
            Try
                fPercent = (m_nTurboDrivingSpeed * 100.0F) / Me.TurboSetPointFrequency
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return fPercent
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22</date>
        ''' </author>
        ''' <summary>
        ''' Send message to device and wait for response
        ''' </summary>
        Protected Function SendCmdToDevice(ByVal strCommand As Byte(), ByRef arrResponse As Byte(), ByVal waitTime As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SendCmdToDevice")
            Dim bRet As Boolean = False
            Try
                Dim conn As AVPLib.Communication.BinConnection = ConnectionManager.GetConnection(Me.EquipmentName)
                If conn IsNot Nothing Then
                    Dim connOldState As Communication.Connection.States = conn.CurrentState
                    conn.ClearMsgQueue()
                    If conn.SendBytes(strCommand) Then
                        arrResponse = conn.ReceiveBytes(waitTime)
                        If arrResponse IsNot Nothing Then
                            bRet = True
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            If Not bRet Then
                AVPLib.Log.avpLogger.Error(String.Format( _
                        AVPLib.ContainerData.GetMessageText("CommunicationError"), EquipmentName))
            End If

            AVPLib.Log.coreLogger.Info("Leave SendCmdToDevice")
            Return bRet
        End Function

        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2021-12-27</date>
        ''' </author>
        ''' <summary>
        ''' Build command for Lebold Turbo
        ''' </summary>
        Private Function BuildCommand(ByVal command As Integer, ByVal accessCommand As String) As Byte()
            Dim buffer As Byte() = New Byte(23) {}
            Try
                buffer(0) = Convert.ToByte(2)
                buffer(1) = Convert.ToByte(22)
                buffer(2) = 0

                Dim para As String = Convert.ToString(command, 2)
                If para.Length < 11 Then
                    For i As Integer = para.Length - 1 To 10
                        para = "0" + para
                    Next
                End If

                buffer(4) = Convert.ToByte(para.Substring(3), 2)
                buffer(3) = Convert.ToByte(accessCommand + para.Substring(0, 4), 2)

                buffer(5) = 0

                buffer(6) = 0

                buffer(7) = 0
                buffer(8) = 0
                buffer(9) = 0
                buffer(10) = 0

                If m_bIsTurningOn Then
                    buffer(11) = Convert.ToByte(4)
                    buffer(12) = Convert.ToByte(1)
                Else
                    buffer(11) = 0
                    buffer(12) = 0
                End If

                buffer(13) = 0
                buffer(14) = 0
                buffer(15) = 0
                buffer(16) = 0
                buffer(17) = 0
                buffer(18) = 0
                buffer(19) = 0
                buffer(20) = 0
                buffer(21) = 0
                buffer(22) = 0

                Dim chkSum As Byte = 0
                For i As Integer = 0 To buffer.Length - 2
                    chkSum = chkSum Xor buffer(i)
                Next

                buffer(23) = chkSum

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return Nothing
            End Try
            Return buffer
        End Function

        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2021-12-27</date>
        ''' </author>
        ''' <summary>
        ''' Build control command for Lebold Turbo
        ''' </summary>
        Private Function BuildControlCommand(ByVal command As Integer, ByVal accessCommand As String, ByVal isStart As Boolean) As Byte()
            Dim buffer As Byte() = New Byte(23) {}
            Try
                buffer(0) = Convert.ToByte(2)
                buffer(1) = Convert.ToByte(22)
                buffer(2) = 0

                Dim para As String = Convert.ToString(command, 2)
                If para.Length < 11 Then
                    For i As Integer = para.Length - 1 To 10
                        para = "0" + para
                    Next
                End If

                buffer(4) = Convert.ToByte(para.Substring(3), 2)
                buffer(3) = Convert.ToByte(accessCommand + para.Substring(0, 4), 2)

                buffer(5) = 0

                buffer(6) = 0

                buffer(7) = 0
                buffer(8) = 0
                buffer(9) = 0
                buffer(10) = 0

                buffer(11) = Convert.ToByte(4)

                If isStart Then
                    buffer(12) = Convert.ToByte(1)
                Else
                    buffer(12) = 0
                End If

                buffer(13) = 0
                buffer(14) = 0
                buffer(15) = 0
                buffer(16) = 0
                buffer(17) = 0
                buffer(18) = 0
                buffer(19) = 0
                buffer(20) = 0
                buffer(21) = 0
                buffer(22) = 0

                Dim chkSum As Byte = 0
                For i As Integer = 0 To buffer.Length - 2
                    chkSum = chkSum Xor buffer(i)
                Next

                buffer(23) = chkSum

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return Nothing
            End Try
            Return buffer
        End Function


        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2021-12-27</date>
        ''' </author>
        ''' <summary>
        ''' Check if response message is valid
        ''' </summary>
        Private Function ValidateReplyMessageCheckSum(ByVal rawReplyMessage As Byte()) As Boolean
            Try
                If rawReplyMessage.Length <> 24 Then
                    AVPLib.Log.coreLogger.Info("Enter Pulling")
                    Return False
                Else
                    Dim chkSum As Byte = 0
                    For i As Integer = 0 To rawReplyMessage.Length - 2
                        chkSum = chkSum Xor rawReplyMessage(i)
                    Next

                    If rawReplyMessage(rawReplyMessage.Length - 1) = chkSum Then
                        Return True
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
        End Function

        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2021-12-27</date>
        ''' </author>
        ''' <summary>
        ''' Check if response message is valid
        ''' </summary>
        Private Function GetReplyMessageData(ByVal rawReplyMessage As Byte()) As String
            Try
                Dim data As Byte() = New Byte(3) {}
                data(0) = rawReplyMessage(7)
                data(1) = rawReplyMessage(8)
                data(2) = rawReplyMessage(9)
                data(3) = rawReplyMessage(10)
                Array.Reverse(data)

                Dim dataStatus As Byte() = New Byte(0) {}
                dataStatus(0) = rawReplyMessage(11)
                Dim status = New BitArray(dataStatus)
                'TurboStatus = IIf((rawReplyMessage(11) And 1) <> 0, True, False)
                TurboUpToSpeed = IIf((status(2) And 1) <> 0, True, False)

                Return BitConverter.ToUInt16(data, 0).ToString()

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return String.Empty
            End Try

            Return String.Empty
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22</date>
        ''' </author>
        ''' <summary>
        ''' Update a turbo property
        ''' </summary>
        Private Sub UpdateStatus(ByVal PropertyName As String, ByVal ReplyValue As Object)
            Dim arrPropertyNames As New ArrayList()
            Dim arrDecodedValues As New ArrayList()
            arrPropertyNames.Add(PropertyName)
            arrDecodedValues.Add(ReplyValue)
            EquipmentManager.ChangeStatus(EquipmentName, arrPropertyNames, arrDecodedValues)
        End Sub

        Public Overrides Sub Dispose()
            'turn on stop request
            m_bHasStopRequest = True

            'stop timer
            If (m_tmrPollingTimer IsNot Nothing) Then
                m_tmrPollingTimer.Enabled = False
                'remove handler
                RemoveHandler m_tmrPollingTimer.Elapsed, AddressOf Polling
            End If

        End Sub

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-05-25</date>
        ''' </author>
        ''' <summary>
        ''' Update Turbo Communicating Status
        ''' </summary>
        Private Sub UpdateCommunicationStatus(ByVal bSuccess As Boolean)
            Const MAX_COMM_ERROR As Integer = 5
            Dim eCommunicationStatus As Equipment.WorkingStatuses = Equipment.WorkingStatuses.Unknown
            If bSuccess Then
                m_nCommErrorCounter = 0
            Else
                m_nCommErrorCounter += 1
            End If
            eCommunicationStatus = IIf(m_nCommErrorCounter < MAX_COMM_ERROR, Equipment.WorkingStatuses.On, Equipment.WorkingStatuses.Off)
            If eCommunicationStatus <> m_eCommunicationStatus Then
                UpdateStatus("IsTurboCommunicating", eCommunicationStatus = Equipment.WorkingStatuses.On)
                m_eCommunicationStatus = eCommunicationStatus
            End If
        End Sub

#End Region

    End Class
End Namespace

