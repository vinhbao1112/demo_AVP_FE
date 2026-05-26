Imports AVPLib.DataManagerment

Namespace Communication.TerminalDriver
    Public Class AlignerTransaction
        Inherits Transaction
        Private m_CommandLock As New Object
#Region "Public method"
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
        ''' Run an aligner command in a transaction
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Run(ByVal Message As String, _
                ByVal bOverrideTimeOut As Boolean, _
                ByVal newTimeOut As Integer) As Boolean
            AVPLib.Log.terminalServerLogger.Debug("Enter Run")
            AVPLib.Log.terminalServerRobotLogger.Debug("-->ALIGNER=" + Message)
            Try
                Dim blnResult As Boolean = True
                SyncLock m_CommandLock
                    Dim nTimeOut As Integer = IIf(bOverrideTimeOut, newTimeOut, Me.Timeout)
                    Dim tscCommand As TSCommand = TSCommandManager.Run(Message, nTimeOut)
                    If (tscCommand IsNot Nothing) Then
                        If (tscCommand.Connection.CurrentState = Connection.States.Disconnected) Then
                            AVPLib.Log.terminalServerRobotLogger.Error("Sent: " + Message + " Received: OperationStatus, IsCommunicating error")
                            Me.HandleUnconnected(tscCommand)
                            Me.InitializeWhenReconnected()
                            Me.HandleSerialCommandFailed(tscCommand, Message, "Disconnection")
                            blnResult = False
                        Else
                            If (tscCommand.GetType().Name = "TSSingleReplyCommand") Then
                                Dim tssCommand As TSSingleReplyCommand = CType(tscCommand, TSSingleReplyCommand)
                                Dim strReply As String = tssCommand.ReplyValue

                                AVPLib.Log.terminalServerRobotLogger.Debug("<--ALIGNER=" + strReply)

                                If (String.IsNullOrEmpty(strReply)) Then
                                    AVPLib.Log.terminalServerRobotLogger.Error("Sent: " + Message + " Received: Timeout and IsCommunicating error")
                                    Me.HandleTimeout(tssCommand)
                                    Me.HandleSerialCommandFailed(tscCommand, Message, "Time out")
                                    blnResult = False
                                Else
                                    If AVPLib.ContainerData.GetPolling("Aligner").IsLog Then
                                        AVPLib.Log.terminalServerRobotLogger.Info("Sent: " + Message + " Received: " + strReply)
                                    End If
                                    Dim strEquipmentName As String = tssCommand.GetEquipmentName()
                                    Dim decoder As TSDecoder = Activator.CreateInstance(Type.GetType("AVPLib.Communication.TerminalDriver." + tssCommand.DecoderName))

                                    Dim arrDecodedValues As ArrayList = Nothing
                                    ' Getting reply messages until _RDY is received
                                    If (tssCommand.ReplyValue.CompareTo("_RDY") = 0) OrElse (tssCommand.ReplyValue.EndsWith(":")) Then
                                        arrDecodedValues = decoder.Decode(strReply)
                                    Else
                                        arrDecodedValues = decoder.Decode(strReply)

                                        While ((strReply.CompareTo("_RDY") <> 0) AndAlso (strReply.EndsWith(":") = False))
                                            strReply = tssCommand.Connection.ReceiveMessage(Timeout, Message)

                                            If (Message.Contains("Aligner.Serial")) Then
                                                Dim strTemp As String = arrDecodedValues(0)
                                                strTemp = strTemp & "#" & strReply
                                                arrDecodedValues.RemoveAt(0)
                                                arrDecodedValues.Add(strTemp)
                                            End If

                                            If (String.IsNullOrEmpty(strReply)) Then
                                                Me.HandleTimeout(tssCommand)
                                                Me.HandleSerialCommandFailed(tscCommand, Message, "Time out")
                                                blnResult = False

                                                AVPLib.Log.terminalServerLogger.Info("Leave Run")
                                                Return blnResult
                                            End If

                                            AVPLib.Log.terminalServerRobotLogger.Debug("<--ALIGNER=" + strReply)
                                            If (arrDecodedValues Is Nothing) Or (arrDecodedValues.Count = 0) Then
                                                arrDecodedValues = decoder.Decode(strReply)
                                            End If
                                        End While
                                    End If

                                    Dim arrPropertyNames As New ArrayList()
                                    ' Creating changed properties list
                                    If (arrDecodedValues.Count > 0) Then
                                        Dim strEOM1 As String = vbLf & vbCr
                                        If (Message.Contains("Aligner.Serial") AndAlso strReply.IndexOf(strEOM1) > 0) Then
                                            Dim strTemp As String = arrDecodedValues(0)
                                            strTemp = strTemp.Replace(strEOM1, "#")
                                            arrDecodedValues.RemoveAt(0)
                                            arrDecodedValues.Add(strTemp)
                                        End If

                                        Dim arrProperties As String() = tssCommand.EquipmentProperty.Split(",")
                                        For Each PropertyName As String In arrProperties
                                            arrPropertyNames.Add(PropertyName)
                                        Next
                                        blnResult = True
                                        If tssCommand.DecoderName = "TSAlignerReadyDecoder" Then
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
                                    EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrDecodedValues)
                                    'Connection is OK,re-init if need
                                    If isOverTransactionTimeoutLimit() Then
                                        RaiseReconnectStatusEvent(New ReconnectEventArgs(tscCommand.GetEquipmentName()))
                                    End If
                                    ResetTransactionTimeoutCount()
                                End If
                            End If
                        End If
                    End If
                End SyncLock

                'If (blnResult) Then
                '    ResetTransactionTimeoutCount()
                'End If

                AVPLib.Log.terminalServerLogger.Debug("Leave Run")
                Return blnResult
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Debug("Leave Run")
        End Function

        Public Overrides Sub RaiseReconnectStatusEvent(ByVal e As ReconnectEventArgs)
            MyBase.RaiseReconnectStatusEvent(e)
        End Sub
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
            AVPLib.Log.terminalServerRobotLogger.Debug("Message=" + Message)
            AVPLib.Log.terminalServerRobotLogger.Debug("MessageFailed=" + MessageFailed)
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
#End Region
    End Class
End Namespace

