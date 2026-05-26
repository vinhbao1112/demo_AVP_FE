Imports System.Timers
Imports AVPLib.Communication.TerminalDriver
Imports AVPLib.DataManagerment
Imports AVPLib.Communication
Imports System.Text

Namespace Driver
    Public Class SerialTurboDriver
        Inherits DriverObject
        Implements IPumpPackageDriver

#Region "Class Constants & Variables"

        Public Enum ControlMode
            Serial = 0
            Remote = 1
        End Enum

        Const COMMUNICATION_TIMEOUT As Integer = 3000  '3 seconds
        Const POLLING_INTERVAL As Integer = 500  '0.5 seconds

        Private m_tmrPollingTimer As Timer
        Private m_nTimeOut As Int32 = COMMUNICATION_TIMEOUT
        Dim m_bHasStopRequest As Boolean = False
        Private m_SerialLock As New Object

        Private m_eCommunicationStatus As Equipment.WorkingStatuses = Equipment.WorkingStatuses.Unknown
        Private m_nCommErrorCounter As Integer = 0

        Private m_nTurboDrivingSpeed As Integer = 0
        'Private m_nTurboTargetSpeed As Integer = 963 ' The default value is max value
        Private m_fRampingPercent As Single = 0

        Private m_bTurboPumpStatus As Integer = 0
        Private m_bTurboError As Boolean = False
        Private m_bTurboStatus As Boolean = False
        Private m_bTurboUpToSpeed As Boolean = False

        Private m_bInitialized As Boolean = False
        Private m_nInitCount As Integer = 0

        Public Enum PumpStatusType
            [Stop] = 0
            [Normal] = 5
            [Error] = 6
        End Enum

        Const CMD_TURN_ON As String = "00011"
        Const CMD_TURN_OFF As String = "00010"
        Const CMD_SET_CONTROL_MODE As String = "0081"
        Const CMD_REQUEST_PUMP_STATUS As String = "2050"
        Const CMD_REQUEST_DRIVING_FREQUENCY As String = "2030"
        Const CMD_REQUEST_TARGET_FREQUENCY As String = "1200"
        Const ACK_RESPONSE_MSG_LENGTH As Integer = 1      ' 1
        Const LOGIC_RESPONSE_MSG_LENGTH As Integer = 5      ' 4+1
        Const NUMERIC_RESPONSE_MSG_LENGTH As Integer = 10   ' 4+6


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
        Public Sub New(ByVal sDriverName As String, ByVal lSetPointFrequency As Single)
            MyBase.new(sDriverName)
            m_tmrPollingTimer = New Timer
            AddHandler m_tmrPollingTimer.Elapsed, AddressOf Polling
            m_tmrPollingTimer.Interval = POLLING_INTERVAL
            m_tmrPollingTimer.Enabled = True
            Me.TurboSetPointFrequency = lSetPointFrequency
        End Sub
#End Region

#Region "Properties"

        Public Property TurboPumpStatus() As Integer
            Get
                Return m_bTurboPumpStatus
            End Get
            Set(ByVal value As Integer)
                m_bTurboPumpStatus = value
            End Set
        End Property

        Public Property TurboError() As Boolean
            Get
                Return m_bTurboError
            End Get
            Set(ByVal value As Boolean)
                m_bTurboError = value
                UpdateStatus("TurboError", m_bTurboError)
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

        Public Property TurboUpToSpeed() As Boolean
            Get
                Return m_bTurboUpToSpeed
            End Get
            Set(ByVal value As Boolean)
                m_bTurboUpToSpeed = value
                UpdateStatus("TurboUptoSpeed", m_bTurboUpToSpeed)
            End Set
        End Property

        Public Property TurboRampingPercent() As Single
            Get
                Return m_fRampingPercent
            End Get
            Set(ByVal value As Single)
                m_fRampingPercent = value
                If TurboPumpStatus <> PumpStatusType.Stop AndAlso _
                    TurboPumpStatus <> PumpStatusType.Normal AndAlso _
                    TurboPumpStatus <> PumpStatusType.Error Then
                    UpdateStatus("RampingPercent", m_fRampingPercent)
                End If
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
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Turn off Turbo
        ''' </summary>
        Public Function TurnOff() As Boolean Implements IPumpPackageDriver.TurnOff
            AVPLib.Log.coreLogger.Info("Enter TurnOff")
            Dim bResult As Boolean = False
            Try
                Dim strMessage As String = CMD_TURN_OFF
                Dim strResponse As String = String.Empty
                If SendCmdToDevice(strMessage, strResponse) Then
                    If strResponse.Length = ACK_RESPONSE_MSG_LENGTH AndAlso strResponse(0) = Chr(&H6) Then
                        bResult = True
                    Else
                        AVPLib.Log.avpLogger.Error("Turn off turbo error.")
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOff")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Turn on Turbo
        ''' </summary>
        Public Function TurnOn() As Boolean Implements IPumpPackageDriver.TurnOn
            AVPLib.Log.coreLogger.Info("Enter TurnOn")
            Dim bResult As Boolean = False
            Try
                Dim strMessage As String = CMD_TURN_ON
                Dim strResponse As String = String.Empty
                If SendCmdToDevice(strMessage, strResponse) Then
                    If strResponse.Length = ACK_RESPONSE_MSG_LENGTH AndAlso strResponse(0) = Chr(&H6) Then
                        bResult = True
                    Else
                        AVPLib.Log.avpLogger.Error("Turn on turbo error.")
                    End If
                End If
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

                If Not m_bInitialized Then
                    ' Try to set turbo control mode to serial before start polling
                    If SetControlMode(ControlMode.Serial) Then
                        m_bInitialized = True
                    Else
                        m_nInitCount += 1
                        If m_nInitCount > 10 Then
                            m_bInitialized = True
                        End If
                    End If
                Else
                    'Polling data
                    If Not HasStopRequest Then
                        GetPumpStatus()
                    End If

                    'GetTargetFrequency() must be placed before GetDrivingFrequency()
                    'because Ramping Percentage is calculated in GetDrivingFrequency()
                    If Not HasStopRequest Then
                        GetTargetFrequency()
                    End If

                    If Not HasStopRequest Then
                        GetDrivingFrequency()
                    End If
                End If

                If Not HasStopRequest Then
                    m_tmrPollingTimer.Enabled = True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Pulling")
        End Sub

        Public Function SetControlMode(ByVal eMode As ControlMode) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SetControlMode")
            Dim bResult As Boolean = False
            Try
                Dim nTurboPumpStatus As Integer = 0
                Dim strMessage As String = CMD_SET_CONTROL_MODE
                Dim strResponse As String = String.Empty
                If eMode = ControlMode.Serial Then
                    strMessage += "0"
                Else
                    strMessage += "1"
                End If

                If SendCmdToDevice(strMessage, strResponse) Then
                    If strResponse.Length = ACK_RESPONSE_MSG_LENGTH AndAlso strResponse(0) = Chr(&H6) Then
                        bResult = True
                    Else
                        AVPLib.Log.avpLogger.Error("Turbo Set Control Mode error.")
                    End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetControlMode")
            Return bResult
        End Function
#End Region

#Region "Private Methods"
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22</date>
        ''' </author>
        ''' <summary>
        ''' Get Rotation Percentage
        ''' </summary>
        Public Function GetPumpStatus() As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetRotationPercentage")
            Dim bResult As Boolean = False
            Try
                Dim nTurboPumpStatus As Integer = 0
                Dim strMessage As String = CMD_REQUEST_PUMP_STATUS
                Dim strResponse As String = String.Empty
                If SendCmdToDevice(strMessage, strResponse) Then
                    If strResponse.Length = NUMERIC_RESPONSE_MSG_LENGTH AndAlso strResponse.StartsWith(CMD_REQUEST_PUMP_STATUS) Then
                        Dim strValue = strResponse.Substring(4)
                        If Integer.TryParse(strValue, nTurboPumpStatus) Then
                            TurboPumpStatus = nTurboPumpStatus
                            TurboStatus = (nTurboPumpStatus <> PumpStatusType.Stop AndAlso nTurboPumpStatus <> PumpStatusType.Error)
                            TurboUpToSpeed = (nTurboPumpStatus = PumpStatusType.Normal)
                            TurboError = (nTurboPumpStatus = PumpStatusType.Error)
                            bResult = True
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRotationPercentage")
            Return bResult
        End Function

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
                Dim nDrivingSpeed As Integer = 0
                Dim strMessage As String = CMD_REQUEST_DRIVING_FREQUENCY
                Dim strResponse As String = String.Empty
                If SendCmdToDevice(strMessage, strResponse) Then
                    If strResponse.Length = NUMERIC_RESPONSE_MSG_LENGTH AndAlso strResponse.StartsWith(CMD_REQUEST_DRIVING_FREQUENCY) Then
                        Dim strValue = strResponse.Substring(4)
                        If Integer.TryParse(strValue, nDrivingSpeed) Then
                            m_nTurboDrivingSpeed = nDrivingSpeed
                            TurboRampingPercent = GetRampingPercentage()
                            bResult = True
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetDrivingFrequency")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22</date>
        ''' </author>
        ''' <summary>
        ''' Get Rotation Percentage
        ''' </summary>
        Public Function GetTargetFrequency() As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetTargetFrequency")
            Dim bResult As Boolean = False
            Try
                Dim nTargetSpeed As Integer = 963
                Dim strMessage As String = CMD_REQUEST_TARGET_FREQUENCY
                Dim strResponse As String = String.Empty
                If SendCmdToDevice(strMessage, strResponse) Then
                    If strResponse.Length = NUMERIC_RESPONSE_MSG_LENGTH AndAlso strResponse.StartsWith(CMD_REQUEST_TARGET_FREQUENCY) Then
                        Dim strValue = strResponse.Substring(4)
                        If Integer.TryParse(strValue, nTargetSpeed) Then
                            Me.TurboSetPointFrequency = nTargetSpeed
                            bResult = True
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetTargetFrequency")
            Return bResult
        End Function

        Private Function GetRampingPercentage() As Single
            Dim fPercent As Single = 0.0F
            If Me.TurboSetPointFrequency <> 0 Then
                fPercent = (m_nTurboDrivingSpeed * 100.0F) / Me.TurboSetPointFrequency
            End If
            Return fPercent
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22</date>
        ''' </author>
        ''' <summary>
        ''' Send message to device and wait for response
        ''' </summary>
        Protected Function SendCmdToDevice(ByVal strCommand As String, ByRef strResponse As String) As Boolean
            Dim buffer As Byte() = BuildCommand(strCommand)
            Dim arrResponse As Byte() = Nothing
            Dim bResult As Boolean = True
            Try
                If buffer Is Nothing Then
                    ' Logged in BuildCommand function
                    bResult = False
                    Exit Try
                End If
                SyncLock m_SerialLock
                    If Not SendCmdToDevice(buffer, arrResponse, Me.TimeOut) Then
                        bResult = False
                        Exit Try
                    End If
                    'Get data
                    strResponse = ASCIIEncoding.ASCII.GetString(arrResponse, 2, arrResponse.Length - 5)
                End SyncLock
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                bResult = False
            End Try
            Return bResult
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
                        If arrResponse IsNot Nothing AndAlso IsValidResponse(arrResponse) Then
                            bRet = True
                            UpdateCommunicationStatus(True)
                        Else
                            UpdateCommunicationStatus(False)
                        End If
                    ElseIf conn.CurrentState = Communication.Connection.States.Disconnected Then
                        UpdateCommunicationStatus(False)
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

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22</date>
        ''' </author>
        ''' <summary>
        ''' Build command for Varian Turbo
        ''' in: <WIN>+<COM>+[<DATA>]
        ''' out: <STX>+<ADDR>+<WIN>+<COM>+[<DATA>]+<ETX>+<CRC>
        ''' </summary>
        Private Function BuildCommand(ByVal strMsg As String) As Byte()
            Dim nMsgLength As Integer = strMsg.Length
            Dim buffer As Byte() = New Byte(nMsgLength + 4) {}
            Try
                '<STX> (Start of transmission) = 0x02
                buffer(0) = &H2
                '<ADDR> (Unit address) = 0x80 (for RS 232)
                buffer(1) = &H80

                For i As Integer = 0 To (nMsgLength - 1)
                    buffer(i + 2) = Convert.ToByte(strMsg(i))
                Next

                '<ETX> (End of transmission) = 0x03
                buffer(nMsgLength + 2) = &H3

                Dim chkSum As Byte = 0
                'From <ADDR> to <ETX>
                For i As Integer = 1 To (nMsgLength + 2)
                    chkSum = chkSum Xor buffer(i)
                Next

                Dim strChkSum = chkSum.ToString("X2") ' Convert to Upper-Case Hexadecimal Format

                buffer(nMsgLength + 3) = Convert.ToByte(strChkSum(0))
                buffer(nMsgLength + 4) = Convert.ToByte(strChkSum(1))
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return Nothing
            End Try
            Return buffer
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22</date>
        ''' </author>
        ''' <summary>
        ''' Check if response message is valid
        ''' </summary>
        Private Function IsValidResponse(ByVal arrResponse As Byte()) As Boolean
            Try
                Dim nMsgLength As Integer = arrResponse.Length

                'Message must contain at least 6 bytes
                If nMsgLength < 6 Then
                    Return False
                End If

                ' Check <STX> signature
                If arrResponse(0) <> &H2 Then
                    Return False
                End If

                ' Check <ETX> signature
                If arrResponse(nMsgLength - 3) <> &H3 Then
                    Return False
                End If

                Dim chkSum As Byte = 0
                'Calculate checksum from <ADDR> to <ETX>
                For i As Integer = 1 To (nMsgLength - 3)
                    chkSum = chkSum Xor arrResponse(i)
                Next

                ' Check checksum
                Dim strChkSum = chkSum.ToString("X2") ' Convert to Upper-Case Hexadecimal Format
                If arrResponse(nMsgLength - 2) <> Convert.ToByte(strChkSum(0)) Then
                    Return False
                End If
                If arrResponse(nMsgLength - 1) <> Convert.ToByte(strChkSum(1)) Then
                    Return False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try

            Return True
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

#End Region


    End Class
End Namespace
