Imports AVPLib.DataManagerment
Namespace Communication.TerminalDriver
    Public Class ElevatorTransaction
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
        '''   	<Name> Ngo Cao Dinh </Name>
        '''   	<Date> 2008-11-13</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Run ElevatorTransaction
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Run(ByVal Message As String, _
                 ByVal bOverrideTimeOut As Boolean, _
                 ByVal newTimeOut As Integer) As Boolean
            AVPLib.Log.terminalServerLogger.Debug("Enter Run")
            AVPLib.Log.terminalServerRobotLogger.Debug("-->ELEVATOR=" + Message)

            Dim blnResult As Boolean = True
            Try
                SyncLock m_CommandLock
                    Utils.LogMessageCheckPullingLLElevator(AVPLib.ContainerData.TypeEvent, "ElevatorTransaction.Run", " Sent: " + Message)
                    Dim tscCommand As TSCommand = TSCommandManager.Run(Message, Timeout)
                    If (tscCommand IsNot Nothing) Then
                        If (tscCommand.Connection.CurrentState = Connection.States.Disconnected) Then
                            Utils.LogMessageCheckPullingLLElevator(AVPLib.ContainerData.TypeAlarm, "ElevatorTransaction.Run", " Sent: " + Message + " Received: OperationStatus, IsCommunicating error")
                            Me.HandleUnconnected(tscCommand)
                            '0006498: [KhoiHa- 02/11/2015][VCO23]After recycle power LL Elevator, do Map function failed. Seem we missed download some parameters
                            InitializeWhenReconnected()
                            '------------------------------------
                            blnResult = False
                        Else
                            If (tscCommand.GetType().Name = "TSSingleReplyCommand") Then
                                Dim tssCommand As TSSingleReplyCommand = CType(tscCommand, TSSingleReplyCommand)
                                Dim strReply As String = tssCommand.ReplyValue

                                AVPLib.Log.terminalServerRobotLogger.Debug("<--ELEVATOR=" + strReply)

                                If (String.IsNullOrEmpty(strReply)) Then
                                    Utils.LogMessageCheckPullingLLElevator(AVPLib.ContainerData.TypeAlarm, "ElevatorTransaction.Run", " Sent: " + Message + " Received: Timeout and IsCommunicating error")
                                    Me.HandleTimeout(tssCommand)
                                    blnResult = False
                                Else
                                    Utils.LogMessageCheckPullingLLElevator(AVPLib.ContainerData.TypeEvent, "ElevatorTransaction.Run", " Sent: " + Message + " Received: " + strReply)
                                    'get ALL INTERLOG 
                                    'SEND:00,R,INTLCK,ALL
                                    'RECEIVE: 4 message
                                    '00,X,INTLCK,CASS,PRESENT,DIS
                                    '00,X,INTLCK,BRKPNT,R,EX,ENB
                                    '00,X,INTLCK,DOOR,COVERED,ENB
                                    '00,X,INTLCK,SAFETY,MOTION,ENB
                                    If (Message.Contains("00,R,INTLCK,ALL")) Then
                                        Dim packageMessage As String = strReply

                                        While packageMessage <> String.Empty
                                            packageMessage = tssCommand.Connection.ReceiveMessage(3000, Message)
                                            strReply = strReply & "#" & packageMessage
                                        End While
                                    End If
                                    Dim strEquipmentName As String = tssCommand.GetEquipmentName()
                                    Dim decoder As TSDecoder = Activator.CreateInstance(Type.GetType("AVPLib.Communication.TerminalDriver." + tssCommand.DecoderName))
                                    decoder.EquipmentName = strEquipmentName
                                    Dim arrPropertyNames As New ArrayList()
                                    Dim arrDecodedValues As ArrayList = decoder.Decode(strReply)
                                    If (arrDecodedValues.Count > 0) Then
                                        Dim arrProperties As String() = tssCommand.EquipmentProperty.Split(",")
                                        For Each PropertyName As String In arrProperties
                                            arrPropertyNames.Add(PropertyName)
                                        Next

                                        EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrDecodedValues)
                                        ''raise event to GEM
                                        If (Message.Contains("00,R,MI")) Then
                                            If strEquipmentName = ConstEnum.Equipments.LLAElevator.ToString() Then
                                                AVPLib.Business.AVPSecsGemLib.TriggerEvent(ConstEnum.LoadLockA_STR, "MappingCompleted")
                                            End If
                                        End If
                                        blnResult = True
                                    Else
                                        'Unexpected reply
                                        blnResult = False
                                    End If
                                    If isOverTransactionTimeoutLimit() Then
                                        RaiseReconnectStatusEvent(New ReconnectEventArgs(tscCommand.GetEquipmentName()))
                                    End If
                                    ResetTransactionTimeoutCount()
                                End If
                            End If
                        End If
                        If (Message.IndexOf(".Serial") > 0) Then
                            Dim strEquipmentName As String = tscCommand.GetEquipmentName()
                            Dim arrPropertyNames As New ArrayList()
                            arrPropertyNames.Add("ResponseMessage")
                            Dim arrValues As New ArrayList()
                            If (blnResult) Then
                                If (tscCommand.GetType().Name = "TSNoReplyCommand") Then
                                    arrValues.Add("Sending successfully")
                                    EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrValues)
                                End If
                            Else
                                arrValues.Add("Sending failed")
                                EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrValues)
                            End If
                        End If
                    End If
                End SyncLock

                'If (blnResult) Then
                '    ResetTransactionTimeoutCount()
                'End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Debug("Leave Run")
            Return blnResult
        End Function
#End Region

#Region "Ptivate method"
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
            Dim strEquipmentName As String = Command.GetEquipmentName()
            Dim arrPropertyNames As New ArrayList()
            Dim arrPropertyValues As New ArrayList()

            arrPropertyNames.Add("OperationStatus")
            arrPropertyValues.Add(Equipment.OperationStatuses.ERROR)

            arrPropertyNames.Add("IsCommunicating")
            arrPropertyValues.Add(False)

            EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrPropertyValues)
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
        End Sub
#End Region
    End Class
End Namespace

