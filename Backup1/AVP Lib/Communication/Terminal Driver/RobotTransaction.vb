Imports AVPLib.DataManagerment

Namespace Communication.TerminalDriver
    Public Class RobotTransaction
        Inherits Transaction
        Private m_CommandLock As New Object
        
#Region "Public method"
        'Public Shared Start As DateTime = DateTime.Now
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-13 </Date>
        '''		<Description> implement </Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Run RobotTransaction
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Run(ByVal Message As String, _
                ByVal bOverrideTimeOut As Boolean, _
                ByVal newTimeOut As Integer) As Boolean
            AVPLib.Log.terminalServerLogger.Debug("Enter Run")
            AVPLib.Log.terminalServerRobotLogger.Debug("-->ROBOT=" + Message)

            Try
                Dim blnResult As Boolean = True
                SyncLock m_CommandLock
                    Utils.LogMessageCheckPullingRobot(AVPLib.ContainerData.TypeEvent, "RobotTransaction.Run", " Sent: " + Message)
                    Dim nTimeOut As Integer = IIf(bOverrideTimeOut, newTimeOut, Me.Timeout)
                    Dim tscCommand As TSCommand = TSCommandManager.Run(Message, nTimeOut)
                    If (tscCommand IsNot Nothing) Then
                        If (tscCommand.Connection.CurrentState = Connection.States.Disconnected) Then
                            Utils.LogMessageCheckPullingRobot(AVPLib.ContainerData.TypeAlarm, "RobotTransaction.Run", " Sent: " + Message + " Received: Disconnected, IsCommunicating error")
                            Me.HandleUnconnected(tscCommand)
                            Me.HandleSerialCommandFailed(tscCommand, Message, "Disconnection")
                            Me.InitializeWhenReconnected()
                            blnResult = False
                        Else
                            If (tscCommand.GetType().Name = "TSSingleReplyCommand") Then
                                Dim tssCommand As TSSingleReplyCommand = CType(tscCommand, TSSingleReplyCommand)
                                Dim strReply As String = tssCommand.ReplyValue

                                AVPLib.Log.terminalServerRobotLogger.Debug("<--ROBOT=" + strReply)

                                If (String.IsNullOrEmpty(strReply)) Then
                                    Utils.LogMessageCheckPullingRobot(AVPLib.ContainerData.TypeAlarm, "RobotTransaction.Run", " Sent: " + Message + " Received: Timeout and IsCommunicating error")

                                    Me.HandleTimeout(tssCommand)

                                    Me.HandleSerialCommandFailed(tscCommand, Message, "Time out")
                                    blnResult = False
                                Else
                                    Dim strEquipmentName As String = tssCommand.GetEquipmentName()
                                    Dim decoder As TSDecoder = Activator.CreateInstance(Type.GetType("AVPLib.Communication.TerminalDriver." + tssCommand.DecoderName))
                                    Dim arrDecodedValues As ArrayList = Nothing
                                    ' Getting reply messages until _RDY is received
                                    If (tssCommand.ReplyValue.CompareTo("_RDY") = 0) Then ' Got _RDY message in the first place.
                                        arrDecodedValues = decoder.Decode(strReply)
                                    Else ' Multiple responds with "_RDY" ending message.
                                        'Special processing for PICK and Place, it will return multiple message
                                        ''' RE 01 0001 DN
                                        ''' EX 01 0001 DN
                                        ''' EX 01 0001 UP
                                        ''' RE 01 0001 UP
                                        ' we need to catch it and update the GUI accordingly
                                        ' Updated by Dat Do 2011/2/17
                                        TSRobotUpDownExtractRetractedDecoder.DecodeAndChangeStatus(strEquipmentName, strReply)
                                        ' End Updated by Dat Do 2011/2/17

                                        arrDecodedValues = decoder.Decode(strReply)
                                        While (strReply.CompareTo("_RDY") <> 0)
                                            strReply = tssCommand.Connection.ReceiveMessage(Timeout, Message)
                                            ' Updated by Dat Cao 2011/07/13
                                            ' add Environment.NewLine after message but it not work when add to Textbox
                                            ' i add "," to message and i parse it when message put into Textbox
                                            If (Message.Contains("Robot.Serial")) Then
                                                Dim strTemp As String = arrDecodedValues(0)
                                                strTemp = strTemp & "#" & strReply
                                                arrDecodedValues.RemoveAt(0)
                                                arrDecodedValues.Add(strTemp)

                                                If (strReply.IndexOf(ConstEnum.ROBOT_ERR_MSG) > -1) Then
                                                    'ERROR
                                                    Me.HandleSerialCommandError(tscCommand, strReply)
                                                    blnResult = False
                                                    Return blnResult
                                                End If
                                            End If

                                            'Special processing for PICK and Place, it will return multiple message
                                            ''' RE 01 0001 DN
                                            ''' EX 01 0001 DN
                                            ''' EX 01 0001 UP
                                            ''' RE 01 0001 UP
                                            ' we need to catch it and update the GUI accordingly
                                            ' Updated by Dat Do 2011/2/17
                                            TSRobotUpDownExtractRetractedDecoder.DecodeAndChangeStatus(strEquipmentName, strReply)
                                            ' End Updated by Dat Do 2011/2/17

                                            If (String.IsNullOrEmpty(strReply)) Then
                                                Me.HandleTimeout(tssCommand)
                                                Me.HandleSerialCommandFailed(tscCommand, Message, "Time out")
                                                blnResult = False
                                                Return blnResult
                                            End If
                                            AVPLib.Log.terminalServerRobotLogger.Debug("<--ROBOT=" + strReply)
                                            If (arrDecodedValues Is Nothing) OrElse (arrDecodedValues.Count = 0) Then
                                                arrDecodedValues = decoder.Decode(strReply)
                                            End If
                                        End While
                                    End If

                                    Dim arrPropertyNames As New ArrayList()
                                    ' Creating changed properties list
                                    If (arrDecodedValues.Count > 0) Then
                                        Dim arrProperties As String() = tssCommand.EquipmentProperty.Split(",")
                                        For Each PropertyName As String In arrProperties
                                            arrPropertyNames.Add(PropertyName)
                                        Next
                                        blnResult = True
                                        If tssCommand.DecoderName = "TSReadyErrorDecoder" Then
                                            If arrDecodedValues.Count = 1 Then
                                                Dim CmdResult As Equipment.OperationStatuses = arrDecodedValues(0)
                                                If CmdResult = Equipment.OperationStatuses.ERROR Then
                                                    blnResult = False
                                                End If
                                            End If
                                        End If
                                    Else
                                        'Unexpected reply
                                        blnResult = False
                                    End If

                                    'send and receive message success -> reset transaction timeout count                                   
                                    If isOverTransactionTimeoutLimit() Then
                                        RaiseReconnectStatusEvent(New ReconnectEventArgs(tssCommand.GetEquipmentName()))
                                    End If
                                    ResetTransactionTimeoutCount()

                                    EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrDecodedValues)

                                    ' Update for System config.
                                    If tssCommand.DecoderName = "TSRobotRqStnDecoder" Then
                                        arrPropertyNames.Clear()
                                        arrPropertyNames.Add("ConfigValues")

                                        Dim sb As New System.Text.StringBuilder
                                        Dim stn As String = "_STN" & arrDecodedValues(7).ToString()
                                        sb.AppendFormat("R_STN{0}={1};T_STN{0}={2};Z_STN{0}={3};LOWER_STN{0}={4};PITCH_STN{0}={5}", _
                                            arrDecodedValues(7), arrDecodedValues(1), arrDecodedValues(2), arrDecodedValues(3), arrDecodedValues(4), arrDecodedValues(5))

                                        Dim arrvalues As New ArrayList
                                        arrvalues.Add(sb.ToString())

                                        EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrvalues)

                                        arrvalues.Clear()
                                    ElseIf tssCommand.DecoderName = "TSRobotRqAccDecoder" OrElse tssCommand.DecoderName = "TSRobotRqVelDecoder" Then
                                        arrPropertyNames.Clear()
                                        arrPropertyNames.Add("ConfigValues")

                                        Dim cmd As String = Message.Replace("Robot.RQ ", "").Replace(" ALL", "")
                                        Dim sb As New System.Text.StringBuilder
                                        sb.AppendFormat("R_{0}={1};T_{0}={2};Z_{0}={3}", cmd, arrDecodedValues(1), arrDecodedValues(2), arrDecodedValues(3))

                                        Dim arrvalues As New ArrayList
                                        arrvalues.Add(sb.ToString())

                                        EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrvalues)

                                        arrvalues.Clear()
                                    End If

                                    arrPropertyNames.Clear()

                                End If
                            End If
                        End If
                    End If
                End SyncLock

                AVPLib.Log.terminalServerLogger.Debug("Leave Run")
                Return blnResult
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Debug("Leave Run")
        End Function
#End Region

#Region "Ptivate method"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-24</date>
        ''' </author>
        ''' <summary>
        ''' Handle serial command failed
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Private Sub HandleSerialCommandFailed(ByVal Command As TSCommand, ByVal Message As String, ByVal MessageFailed As String)
            AVPLib.Log.terminalServerLogger.Info("Enter HandleSerialCommandFailed")

            Try
                If (Message.IndexOf(".Serial") > 0) Then
                    Dim strEquipmentName As String = Command.GetEquipmentName()
                    Dim arrPropertyNames As New ArrayList()
                    arrPropertyNames.Add("ResponseMessage")
                    Dim arrValues As New ArrayList()
                    arrValues.Add(MessageFailed)
                    EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrValues)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave HandleSerialCommandFailed")
        End Sub
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-24</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> </Name>
        '''   	<Date> </Date>
        '''		<Description> </Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' If robot lost connection, IsCommunicating change to false
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Private Sub HandleUnconnected(ByVal Command As TSCommand)
            AVPLib.Log.terminalServerLogger.Info("Enter HandleUnconnected")

            Try
                Dim strEquipmentName As String = Command.GetEquipmentName()
                Dim arrPropertyNames As New ArrayList()
                Dim arrPropertyValues As New ArrayList()

                arrPropertyNames.Add("OperationStatus")
                arrPropertyValues.Add(Equipment.OperationStatuses.ERROR)

                arrPropertyNames.Add("IsCommunicating")
                arrPropertyValues.Add(False)

                EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrPropertyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave HandleUnconnected")
        End Sub
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-24</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> </Name>
        '''   	<Date> </Date>
        '''		<Description> </Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Handle reply message are timeout
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Private Sub HandleTimeout(ByVal Command As TSCommand)
            AVPLib.Log.terminalServerLogger.Info("Enter HandleTimeout")

            Try
                If TransactionTimeoutCount = m_TransactionTimeoutLimit Then
                    Dim strEquipmentName As String = Command.GetEquipmentName()
                    Dim arrPropertyNames As New ArrayList()
                    Dim arrPropertyValues As New ArrayList()

                    arrPropertyNames.Add("OperationStatus")
                    arrPropertyValues.Add(Equipment.OperationStatuses.ERROR)

                    arrPropertyNames.Add("ErrorMessage")
                    arrPropertyValues.Add(Utils.GetMessageError("ErrTimeout"))

                    arrPropertyNames.Add("IsCommunicating")
                    arrPropertyValues.Add(False)

                    EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrPropertyValues)
                End If

                CalculateTransactionTimeOut()

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave HandleTimeout")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-01-31</date>
        ''' </author>
        ''' <Modifiers>
        '''</Modifiers>
        ''' <summary>
        ''' process Robot.Serial command Error 
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Private Sub HandleSerialCommandError(ByVal Command As TSCommand, ByVal ErrorMsgReply As String)
            AVPLib.Log.terminalServerLogger.Info("Enter HandleTimeout")

            Try
                Dim strEquipmentName As String = Command.GetEquipmentName()
                Dim arrPropertyNames As New ArrayList()
                Dim arrPropertyValues As New ArrayList()

                arrPropertyNames.Add("OperationStatus")
                arrPropertyValues.Add(Equipment.OperationStatuses.ERROR)

                arrPropertyNames.Add("ErrorMessage")
                arrPropertyValues.Add(Utils.GetMessageError(ErrorMsgReply))

                EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrPropertyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave HandleTimeout")
        End Sub
#End Region
    End Class
End Namespace

