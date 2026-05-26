Imports System.Timers
Imports AVPLib.Communication.TerminalDriver
Imports AVPLib.DataManagerment
Imports AVPLib.Communication
Imports System.Text
Namespace Driver
    Public Class SerialMPumpCGDriver
        Inherits DriverObject
        Implements ICGDriver
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
            m_tmrPollingTimer = New Timer
            AddHandler m_tmrPollingTimer.Elapsed, AddressOf Polling
            m_tmrPollingTimer.Interval = POLLING_INTERVAL
            m_tmrPollingTimer.Enabled = True
            Me.EquipmentName = sDriverName
        End Sub

#Region "Class Constants & Variables"

        Public Enum ControlMode
            Serial = 0
            Remote = 1
        End Enum

        Const COMMUNICATION_TIMEOUT As Integer = 2000  '3 seconds
        Const POLLING_INTERVAL As Integer = 500  '1 seconds

        Private m_tmrPollingTimer As Timer
        Private m_nTimeOut As Int32 = COMMUNICATION_TIMEOUT
        Dim m_bHasStopRequest As Boolean = False

        Const MAX_COMM_ERROR As Integer = 2
        Const STR_ON_CMD As Integer = 0
        Private m_nCommErrorCounter As Integer = 0
        Private m_eCommunicationStatus As Equipment.WorkingStatuses = Equipment.WorkingStatuses.Unknown
#End Region

#Region "Properties"
        Public Property IsCommunicationStatus() As Equipment.WorkingStatuses
            Get
                Return m_eCommunicationStatus
            End Get
            Set(ByVal value As Equipment.WorkingStatuses)
                m_eCommunicationStatus = value
                UpdateStatus("IsCommunicating", m_eCommunicationStatus)
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

        Public ReadOnly Property CGPressure() As Single Implements ICGDriver.CGPressure
            Get

            End Get
        End Property
        Public ReadOnly Property CGRelay() As DataManagerment.Equipment.WorkingStatuses Implements ICGDriver.CGRelay
            Get
                Return IsCommunicationStatus
            End Get
        End Property
#End Region

#Region "Public method"

        Public Function SetValue(ByVal strCmd As String) As Boolean Implements ICGDriver.SetValue
            AVPLib.Log.coreLogger.Info("Enter GetDrivingFrequency")
            Dim bResult As Boolean = True
            Dim response As String = ""
            Try
                If Not SendCmdToDevice(strCmd, response, m_nTimeOut) Then
                    bResult = False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetDrivingFrequency")
            Return bResult
        End Function

        Protected Function SendCmdToDevice(ByVal strCommand As String, ByRef arrResponse As String, ByVal waitTime As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SendCmdToDevice")
            Dim bRet As Boolean = False
            Dim strMess As String = String.Empty
            Try
                Dim conn As AVPLib.Communication.TerminalServerConnection = ConnectionManager.GetConnection(Me.EquipmentName)
                If conn IsNot Nothing Then
                    conn.ClearMsgQueue()
                    bRet = conn.SendMessage(strCommand)
                    
                    If Not bRet Then
                        AVPLib.Log.avpLogger.Error("Send " & strCommand & " Faild")
                        UpdateCommunicationStatus(False)
                        Return False
                    Else
                        arrResponse = conn.ReceiveMessage(waitTime, "")
                        If String.IsNullOrEmpty(arrResponse) Then
                            AVPLib.Log.avpLogger.Error("Faild Reponse Is Empty ")
                            UpdateCommunicationStatus(False)
                            Return False
                        End If
                        UpdateCommunicationStatus(True)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendCmdToDevice")
            Return bRet
        End Function
        Public Function GetPumpStatus() As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetPumpStatus")
            Dim bResult As Boolean = False
            Try
                Dim strCmd As String = "?P"
                Dim response As String = ""
                If SendCmdToDevice(strCmd, response, m_nTimeOut) Then
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetPumpStatus")
            Return bResult
        End Function
        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2023-04-18 </date>
        ''' </author>
        ''' <summary>
        '''  Polling Turbo status
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Polling(ByVal source As Object, ByVal e As ElapsedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter Pulling")
            Try
                m_tmrPollingTimer.Enabled = False
                If Not HasStopRequest Then
                    GetPumpStatus()
                End If
                If Not HasStopRequest Then
                    m_tmrPollingTimer.Enabled = True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Pulling")
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
        '''    	<name> Tinh Le</name>
        '''    	<date> 2023-04-18 </date>
        ''' </author>
        ''' <summary>
        ''' Update Turbo Communicating Status
        ''' </summary>
        Private Sub UpdateCommunicationStatus(ByVal bSuccess As Boolean)
            If bSuccess Then
                m_nCommErrorCounter = 0
            Else
                m_nCommErrorCounter += 1
            End If
            IsCommunicationStatus = IIf(m_nCommErrorCounter < MAX_COMM_ERROR, Equipment.WorkingStatuses.On, Equipment.WorkingStatuses.Off)
        End Sub
        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2023-04-18 </date>
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
#End Region

    End Class
End Namespace