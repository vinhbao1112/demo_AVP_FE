Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


Namespace Communication
	Public Class TerminalServerConnection
		Inherits Connection

#Region "Class Constants & Variables"

        Private Const MAX_BUFFER_SIZE As Integer = 1024

        Private m_EquipmentName As String
        Private m_Suffix As String = String.Empty
        Protected m_TcpClient As TcpClient = Nothing
        Private m_SyncLock As New Object
        Private m_bAutoOpenConnection As Boolean = True

        Private m_unexpectedMessageQueue As New Queue
        Protected m_MessageQueue As New Queue
        Private m_blnIsTimeout = False
        Private m_SendTime As Int64
        Private m_blnAligner As Boolean = False
        Private m_Timeout As Integer = 0

        Private SpecialMessages As String = "Robot.HLLO,LLAElevator.00,R,ER"

        Private m_Reader As TerminalServerConnectionMessageReader = Nothing
        Private m_UnexpectedMsgHandler As UnexpectedMessagesHandler = Nothing

        Private m_strData As String = String.Empty
        Private m_intTickCountToResetError As Int64 = 0

        ''' <summary>
        ''' Is a thead used to handle unexpected message from equipment
        ''' It will fire a message to GUI to show alarm and send back a reset 
        ''' message to Elevator if it is an error message from Elevator
        ''' </summary>
        Private Class UnexpectedMessagesHandler
            Inherits SuspendableThread

            Private m_Connection As TerminalServerConnection = Nothing

            Public Sub New(ByVal thisConnection As TerminalServerConnection)
                m_Connection = thisConnection
            End Sub

            Protected Overrides Sub OnDoWork()
                AVPLib.Log.schedulerLogger.Debug(m_Connection.EquipmentName & ": A THREAD FOR UnexpectedMessagesHandler IS COMING ALIVE.")
                Try
                While (False = HasTerminateRequest())
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (awokenByTerminate) Then
                        Exit While
                    End If
                        Dim strMessage As String = String.Empty
                        Dim blDataAvailable = False
                        ' Lock on the queue
                        SyncLock m_Connection.m_unexpectedMessageQueue.SyncRoot
                            If (m_Connection.m_unexpectedMessageQueue.Count > 0) Then
                                strMessage = CType(m_Connection.m_unexpectedMessageQueue.Dequeue(), String)
                                blDataAvailable = True
                            End If
                        End SyncLock

                        If blDataAvailable Then
                            strMessage = m_Connection.EquipmentName + "." + strMessage
                            Dim MessageError As ArrayList = ContainerData.CheckMessageError(strMessage)
                            If MessageError IsNot Nothing AndAlso MessageError.Count > 0 Then
                                Dim ReplyValues As ArrayList = New ArrayList()
                                For Each msgError As Object In MessageError
                                    If msgError.ToString() = "True" Or msgError.ToString() = "False" Then
                                        Continue For
                                    End If
                                    ReplyValues.Add(msgError)
                                Next
                                Dim PropertyNames As ArrayList = New ArrayList()
                                Dim Equipment As String = m_Connection.EquipmentName
                                PropertyNames.Add(ConstEnum.GUI_ERROR_REPORT)
                                ' Fire alarm to GUI
                                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Equipment, PropertyNames, ReplyValues)
                            End If
                        Else
                            SleepButAlertabletoTerminateRequest(500)
                        End If
                    End While
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error(ex.ToString())
                    End Try
		 AVPLib.Log.schedulerLogger.Debug(m_Connection.EquipmentName & ": A THREAD FOR UnexpectedMessagesHandler IS EXITING.")
            End Sub
        End Class

        Private Class TerminalServerConnectionMessageReader
            Inherits SuspendableThread
            Private m_Connection As TerminalServerConnection = Nothing
            Private m_strData As String = String.Empty

            Public Sub New(ByVal thisConnection As TerminalServerConnection)
                m_Connection = thisConnection
            End Sub

            Protected Overrides Sub OnDoWork()
                AVPLib.Log.schedulerLogger.Debug(m_Connection.EquipmentName & ": A THREAD FOR TerminalServerConnectionMessageReader IS COMING ALIVE.")
                Try
                    ' Main loop processing.
                    While (False = HasTerminateRequest())
                        Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                        If (awokenByTerminate) Then
                            Exit While
                        End If
                        Dim nwsStream As NetworkStream = m_Connection.m_TcpClient.GetStream()
                        If nwsStream.DataAvailable Then
                            Dim arrBuffer() As Byte = New Byte(MAX_BUFFER_SIZE) {}
                            Dim intReadBytes As Integer = 0
                            intReadBytes = nwsStream.Read(arrBuffer, 0, MAX_BUFFER_SIZE)
                            While ((intReadBytes > 0) And (False = HasTerminateRequest()))
                                m_Connection.OnDataReceived(arrBuffer, intReadBytes)
                                If nwsStream.DataAvailable Then
                                    intReadBytes = nwsStream.Read(arrBuffer, 0, MAX_BUFFER_SIZE)
                                Else
                                    intReadBytes = 0
                                End If
                            End While
                        Else
                            SleepButAlertabletoTerminateRequest(100)
                        End If
                    End While
                Catch ex As Exception
                    m_Connection.m_CurrentState = States.Disconnected
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
                AVPLib.Log.schedulerLogger.Debug(m_Connection.EquipmentName & ": THE THREAD FOR TerminalServerConnectionMessageReader IS EXITING.")
            End Sub
        End Class
#End Region

#Region "Properties"
        ''' <author>
        '''   <name>Cao anh Kiet</name>
        '''   <date>2008-12-04</date>
        ''' </author>
        ''' <summary>
        ''' Equipment Name
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EquipmentName() As String
            Get
                Return m_EquipmentName
            End Get
            Set(ByVal value As String)
                m_EquipmentName = value
            End Set
        End Property

        ''' <author>
        '''   <name>Cao anh Kiet</name>
        '''   <date>2008-12-04</date>
        ''' </author>
        ''' <summary>
        ''' Sent Suffix
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SentSuffix() As String
            Get
                Return m_Suffix
            End Get
            Set(ByVal value As String)
                m_Suffix = value
            End Set
        End Property

#End Region

#Region "Pubic Method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        '''   <Modifier>
        '''   	<Name>Diep Chi Cuong</Name>
        '''   	<Date>2008-11-13</Date>
        '''		<Description>Implementing this method</Description>
        '''   </Modifier>
        ''' </Modifiers>
        ''' <summary>
        ''' Send a message
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Overrides Function SendMessage(ByVal strMessage As String) As Boolean
            AVPLib.Log.terminalServerLogger.Info("Enter SendMessage")

            Dim stream As NetworkStream = Nothing
            Try
                If Open() Then
                    stream = m_TcpClient.GetStream()
                    If Not String.IsNullOrEmpty(SentSuffix) Then
                        strMessage += SentSuffix
                    End If
                    Dim length As Integer = ASCIIEncoding.ASCII.GetByteCount(strMessage)
                    Dim btMessage As Byte() = ASCIIEncoding.ASCII.GetBytes(strMessage)

                    ' Clear queue before sending for preventing mismatch messages will be received after.
                    SyncLock m_MessageQueue.SyncRoot
                        If (m_MessageQueue.Count > 0) Then
                            m_MessageQueue.Clear()
                        End If
                    End SyncLock

                    stream.Write(ASCIIEncoding.ASCII.GetBytes(strMessage), 0, length)
                    AVPLib.Log.terminalServerLogger.Info("Leave SendMessage")
                    Return True
                End If
            Catch ex As Exception
                m_CurrentState = States.Disconnected
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave SendMessage")
            Return False
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        '''   <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        '''   </Modifier>
        ''' </Modifiers>
        ''' <summary>
        ''' Receive a message
        ''' </summary>
        ''' <param name="Timeout">how many miliseconds to wait for response</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ReceiveMessage(ByVal Timeout As Integer, ByVal strMessage As String) As String
            AVPLib.Log.terminalServerLogger.Info("Enter ReceiveMessage")
            Try
                If Open() Then
                    Dim start As Int64 = Environment.TickCount
                    Dim current As Int64 = start
                    Dim blnIsMessageEmpty As Boolean = True
                    Dim msgMessage As Message = Nothing
                    While (current - start) <= Timeout
                        SyncLock m_MessageQueue.SyncRoot
                            If (m_MessageQueue.Count > 0) Then
                                msgMessage = CType(m_MessageQueue.Dequeue(), Message)
                                blnIsMessageEmpty = False
                            End If
                        End SyncLock
                        If blnIsMessageEmpty Then
                            Thread.Sleep(50)
                        Else
                            Return msgMessage.Text
                        End If
                        current = Environment.TickCount
                    End While
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave ReceiveMessage")
            Return String.Empty
        End Function

        ''' <Name>Nguyen Tan Dung</Name>
        ''' <Date> 2011 </Date>
        ''' <summary>
        ''' Clear Message Queue
        ''' </summary>
        Public Overridable Sub ClearMsgQueue()
            SyncLock m_MessageQueue.SyncRoot
                m_MessageQueue.Clear()
            End SyncLock
        End Sub

        '''   	<Name>Diep Chi Cuong</Name>
        '''   	<Date>2008-11-13</Date>
        '''		<Description>Implementing this method</Description>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-25</Date>
        '''		<Description>Trying reconnecting after losing previous connection</Description>
        '''   </Modifier>
        ''' </Modifiers>
        ''' <summary>
        '''  Open connection
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Open() As Boolean
            AVPLib.Log.terminalServerLogger.Debug("Enter Open")
            Try
                If String.IsNullOrEmpty(m_IPAddress) Then
                    Return False
                End If

                If Not m_bAutoOpenConnection Then
                    Return False
                End If

                If m_TcpClient IsNot Nothing Then
                    If IsConnected(m_TcpClient.Client) AndAlso m_TcpClient.Connected Then
                        AVPLib.Log.terminalServerLogger.Info("Leave Open")
                        Return True
                    End If
                End If

                SyncLock m_SyncLock
                    If Not m_bAutoOpenConnection Then
                        Return False
                    End If

                If m_TcpClient Is Nothing Then
                    m_TcpClient = New TcpClient()
                Else
                    If Not IsConnected(m_TcpClient.Client) Then
                        If (m_Reader IsNot Nothing) Then
                            m_Reader.TerminateAndWait()
                            m_Reader = Nothing
                        End If
                        If (m_UnexpectedMsgHandler IsNot Nothing) Then
                            m_UnexpectedMsgHandler.TerminateAndWait()
                            m_UnexpectedMsgHandler = Nothing
                        End If
                        '
                        Try
                            m_TcpClient.GetStream().Close()
                            AVPLib.Log.schedulerLogger.Debug(EquipmentName & " has closed the socket at IPAddress - " & IPAddress & ", Port - " & Port)
                        Catch ex As Exception
                            AVPLib.Log.avpLogger.Error(ex.Message)
                        End Try
                        m_TcpClient.Close()
                        m_TcpClient = Nothing
                        m_CurrentState = States.Disconnected
                        m_TcpClient = New TcpClient()
                    End If
                End If

                If m_TcpClient.Connected = False Then
                    AVPLib.Log.schedulerLogger.Debug(EquipmentName & " is connecting at IPAddress - " & IPAddress & ", Port - " & Port)
                    Dim result As IAsyncResult = m_TcpClient.BeginConnect(m_IPAddress, m_Port, Nothing, Nothing)
                    Dim bSuccess As Boolean = result.AsyncWaitHandle.WaitOne(CONNECT_TIME_OUT, False)
                        If m_TcpClient Is Nothing Then
                            m_CurrentState = States.Disconnected
                            m_TcpClient = Nothing
                            Return False
                        End If
                        If (Not m_TcpClient.Connected) OrElse (Not bSuccess) Then
                        m_TcpClient.Close()
                        m_CurrentState = States.Disconnected
                        m_TcpClient = Nothing
                        Return False
                    End If

                    If Not (m_CurrentState = States.Connected) Then
                        m_CurrentState = States.Connected
                    End If

                    If (m_Reader Is Nothing) Then
                        m_Reader = New TerminalServerConnectionMessageReader(Me)
                        m_Reader.Start()
                    End If
                    If (m_UnexpectedMsgHandler Is Nothing) Then
                        ' Handling error messages for other equipments not Aligner.
                        If Not (EquipmentName.IndexOf("Cryo") > -1) Then
                            m_UnexpectedMsgHandler = New UnexpectedMessagesHandler(Me)
                            m_UnexpectedMsgHandler.Start()
                        End If
                    End If
                End If
                End SyncLock

                AVPLib.Log.terminalServerLogger.Info("Leave Open")
                Return True
            Catch ex As Exception
                m_CurrentState = States.Disconnected
                AVPLib.Log.avpLogger.ErrorFormat("Can not create the connection to Equipment={0} IP={1}, Port={2}", m_EquipmentName, m_IPAddress, m_Port)
            End Try
            AVPLib.Log.terminalServerLogger.Debug("Leave Open")
            Return False
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        '''   <Modifier>
        '''   	<Name>Diep Chi Cuong</Name>
        '''   	<Date>2008-11-13</Date>
        '''		<Description>Implementing this method</Description>
        '''   </Modifier>
        ''' </Modifiers>
        ''' <summary>
        ''' Close connection
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Close() As Boolean
            AVPLib.Log.terminalServerLogger.Info("Enter Close")
            Try
                m_bAutoOpenConnection = False
                SyncLock m_SyncLock
                If (m_TcpClient Is Nothing) Then
                    Return False
                End If
                If (m_UnexpectedMsgHandler IsNot Nothing) Then
                    m_UnexpectedMsgHandler.Terminate()
                    m_UnexpectedMsgHandler = Nothing
                End If
                If (m_Reader IsNot Nothing) Then
                    m_Reader.Terminate()
                    m_Reader = Nothing
                End If
                If m_TcpClient.Connected Then
                    m_TcpClient.GetStream().Close()
                End If
                m_TcpClient.Close()
                m_TcpClient = Nothing
                m_CurrentState = States.Disconnected
                End SyncLock

                AVPLib.Log.terminalServerLogger.Info("Leave Close")
                Return True
            Catch ex As Exception
                m_CurrentState = States.Disconnected
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave Close")
            Return False
        End Function
#End Region

#Region "Private methods"

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011 </date>
        ''' </author>
        ''' <summary>
        ''' Handle received buffer
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overridable Sub OnDataReceived(ByVal arrBuffer As Byte(), ByVal nLength As Integer)
            AVPLib.Log.terminalServerLogger.Info("Enter OnDataReceived")
            Try
                If m_EquipmentName.Contains("Aligner") _
                                  AndAlso AVPLib.RobotConfigurationValues.ALIGNER_AT_PACKET_MODE = False Then

                    AddMonitorAlignerMessage(arrBuffer, nLength)
                Else
                    AddMessage(arrBuffer, nLength)

                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave OnDataReceived")
        End Sub

        Private Sub AddMessage(ByVal arrBuffer As Byte(), ByVal nLength As Integer)
            Dim strEOM1 As String = vbLf & vbCr
            Dim strEOM2 As String = vbCr
            Dim pos1 As Integer
            Dim pos2 As Integer
            Try
                m_strData += ASCIIEncoding.ASCII.GetString(arrBuffer, 0, nLength)
                pos1 = m_strData.IndexOf(strEOM1)
                pos2 = m_strData.IndexOf(strEOM2)
                While (pos2 >= 0)
                    Dim strText As String = ""
                    If pos1 >= 0 Then
                        strText = m_strData.Substring(0, pos1)
                        m_strData = m_strData.Remove(0, pos1 + 2)
                        pos1 = m_strData.IndexOf(strEOM1)
                        pos2 = m_strData.IndexOf(strEOM2)
                    ElseIf pos2 >= 0 Then
                        strText = m_strData.Substring(0, pos2)
                        m_strData = m_strData.Remove(0, pos2 + 1)
                        pos2 = m_strData.IndexOf(strEOM2)
                    End If

                    Dim msgMessage As New Message()
                    msgMessage.Text = strText.Trim()
                    msgMessage.Time = Environment.TickCount

                    If (msgMessage.Text.IndexOf(ConstEnum.ALIGNER_ERR_MSG) > -1) OrElse _
                    (msgMessage.Text.IndexOf(ConstEnum.ROBOT_ERR_MSG) > -1) OrElse _
                    ((msgMessage.Text.IndexOf(ConstEnum.LL_ERR_MSG) > -1) And (msgMessage.Text <> ConstEnum.LL_NO_ERR_MSG)) Then
                        HandleUnexpectedMessage(msgMessage.Text)
                    End If
                    SyncLock m_MessageQueue.SyncRoot
                        m_MessageQueue.Enqueue(msgMessage)
                    End SyncLock

                    '0008734: [TamHuynh - 11/20/2015] Send Command ECHO OFF base on messages un-handle
                    Dim strMessage As String = String.Empty

                    'LLElevator
                    If EquipmentName.Contains(ConstEnum.Equipments.LLAElevator.ToString()) AndAlso _
                       msgMessage.Text.IndexOf(ConstEnum.ELEVATOR_COMMAND_COMUNICTION_ALIVE) > -1 Then

                        strMessage = EquipmentName & "." & SYSTEM_CONFIG_INIT_VALUES.LL_ELEVATOR_00_S_EC_N_INIT

                        ThreadPool.QueueUserWorkItem(AddressOf RunTransaction, strMessage)
                    End If

                    'Robot
                    If EquipmentName.Contains(ConstEnum.Equipments.Robot.ToString()) AndAlso _
                       msgMessage.Text.IndexOf(ConstEnum.ROBOT_COMMAND_COMUNICTION_ALIVE) > -1 Then

                        strMessage = EquipmentName & "." & SYSTEM_CONFIG_INIT_VALUES.ROBOT_COMMAND_ARRAY(1)

                        ThreadPool.QueueUserWorkItem(AddressOf RunTransaction, strMessage)
                    End If

                    'Aligner
                    If EquipmentName.Contains(ConstEnum.Equipments.Aligner.ToString()) AndAlso _
                       msgMessage.Text.IndexOf(ConstEnum.ALIGNER_COMMAND_COMUNICTION_ALIVE) > -1 Then

                        If (RobotConfigurationValues.ALIGNER_AT_PACKET_MODE) Then
                            strMessage = EquipmentName & "." & SYSTEM_CONFIG_INIT_VALUES.ALIGNER_COMMAND_ARRAY(0)
                        Else
                            strMessage = EquipmentName & "." & SYSTEM_CONFIG_INIT_VALUES.ALIGNER_MONITOR_COMMAND_ARRAY(0)
                        End If

                        ThreadPool.QueueUserWorkItem(AddressOf RunTransaction, strMessage)
                    End If

                    '0008729: [TamHuynh - 11/19/2015] Send ResetError to Elevator in un-handle message
                    If (msgMessage.Text.IndexOf(ConstEnum.LL_ERR_MSG) > -1) And (msgMessage.Text <> ConstEnum.LL_NO_ERR_MSG) Then
                        If (m_intTickCountToResetError = 0) Then
                            m_intTickCountToResetError = Environment.TickCount
                        Else
                            If (Utils.GetTickCountDelta(m_intTickCountToResetError) > 2000) Then
                                AVPLib.Business.LLElevatorUtility.Reset(EquipmentName)
                                m_intTickCountToResetError = 0
                            End If
                        End If
                    End If
                End While

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Private Sub RunTransaction(ByVal strMessage As Object)
            Try
                AVPLib.Business.LLElevatorUtility.RunTransaction(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Private Sub AddMonitorAlignerMessage(ByVal arrBuffer As Byte(), ByVal nLength As Integer)

            Dim arrKey1() As Byte = New Byte(3) {10, 13, 58, 32}    ''Response message is end of \n\r:
            Dim arrKey2() As Byte = New Byte(1) {58, 32}            ''Response mess is end of :
            Dim strEOM1 As String = ASCIIEncoding.ASCII.GetString(arrKey1)
            Dim strEOM2 As String = ASCIIEncoding.ASCII.GetString(arrKey2)

            Dim pos1 As Integer
            Dim pos2 As Integer
            Try
                m_strData += ASCIIEncoding.ASCII.GetString(arrBuffer, 0, nLength)
                pos1 = m_strData.IndexOf(strEOM1)
                pos2 = m_strData.IndexOf(strEOM2)
                While (pos2 >= 0)
                    Dim strText As String = ""
                    If pos1 >= 0 Then

                        strText = m_strData.Substring(0, pos1 + 3)
                        m_strData = m_strData.Remove(0, pos1 + 4)
                        pos1 = m_strData.IndexOf(strEOM1)
                        pos2 = m_strData.IndexOf(strEOM2)
                    Else
                        If m_strData = strEOM2 Then

                            strText = m_strData.Substring(0, pos2 + 1)
                            m_strData = m_strData.Remove(0, pos2 + 2)
                            pos1 = m_strData.IndexOf(strEOM1)
                            pos2 = m_strData.IndexOf(strEOM2)

                        Else
                            If (m_strData.Length > pos2 + 1) Then
                                pos1 = m_strData.IndexOf(strEOM1, pos2 + 1)
                                pos2 = m_strData.IndexOf(strEOM1, pos2 + 1)
                            Else
                                Exit While
                            End If


                        End If

                    End If

                    Dim msgMessage As New Message()
                    msgMessage.Text = strText.Trim()
                    msgMessage.Time = Environment.TickCount

                    If (msgMessage.Text.IndexOf(ConstEnum.ALIGNER_ERR_MSG) > -1) OrElse _
                    (msgMessage.Text.IndexOf(ConstEnum.ALIGNER_MONITOR_ERR_MSG) > -1) OrElse _
                    (msgMessage.Text.IndexOf(ConstEnum.ROBOT_ERR_MSG) > -1) OrElse _
                    ((msgMessage.Text.IndexOf(ConstEnum.LL_ERR_MSG) > -1) And (msgMessage.Text <> ConstEnum.LL_NO_ERR_MSG)) Then
                        HandleUnexpectedMessage(msgMessage.Text)
                    End If
                    SyncLock m_MessageQueue.SyncRoot
                        m_MessageQueue.Enqueue(msgMessage)
                    End SyncLock
                End While

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009 </date>
        ''' </author>
        ''' <summary>
        ''' Just put to the unexpected message queue. A thead will proces this message queue
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub HandleUnexpectedMessage(ByVal Message As String)
            AVPLib.Log.terminalServerLogger.Info("Enter HandleUnexpectedMessage")
            AVPLib.Log.terminalServerLogger.Info("Message=" + Message)
            ' Lock on the queue
            SyncLock m_unexpectedMessageQueue.SyncRoot
                ' Put the message to the queue
                m_unexpectedMessageQueue.Enqueue(Message)
            End SyncLock
            AVPLib.Log.terminalServerLogger.Info("Leave HandleUnexpectedMessage")
        End Sub
#End Region
    End Class
End Namespace
