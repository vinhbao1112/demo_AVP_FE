Imports AVPLib.DataManagerment
Namespace Communication.TerminalDriver
    Public Class WaterPumpTransaction
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
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Run CryoTransaction
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Run(ByVal Message As String, _
                ByVal bOverrideTimeOut As Boolean, _
                ByVal newTimeOut As Integer) As Boolean
            AVPLib.Log.terminalServerLogger.Debug("Enter Run")
            AVPLib.Log.terminalServerCryoLogger.Debug("-->CRYO=" + Message)

            Try
                Dim blnResult As Boolean = True
                SyncLock m_CommandLock
                    Utils.LogMessageCheckPullingCryo(AVPLib.ContainerData.TypeEvent, "WarterPumpTransaction.Run", " Sent: " + Message)
                    Dim tscCommand As TSCommand = TSCommandManager.Run(Message, Timeout)
                    If (tscCommand IsNot Nothing) Then
                        If (tscCommand.Connection.CurrentState = Connection.States.Disconnected) Then
                            Me.HandleUnconnected(tscCommand)
                            blnResult = False
                        Else
                            If (tscCommand.GetType().Name = "TSSingleReplyCheckSumCommand") Then
                                Dim tssCommand As TSSingleReplyCheckSumCommand = CType(tscCommand, TSSingleReplyCheckSumCommand)
                                Dim strReply As String = tssCommand.ReplyValue

                                AVPLib.Log.terminalServerCryoLogger.Debug("<--CRYO=" + strReply)

                                If (String.IsNullOrEmpty(strReply)) Then
                                    Me.HandleTimeout(tssCommand)
                                    blnResult = False
                                Else
                                    Utils.LogMessageCheckPullingCryo(AVPLib.ContainerData.TypeEvent, "WarterPumpTransaction.Run", " Sent: " + Message + " Received: " + strReply)
                                    Dim cs As New CheckSum()
                                    If (cs.Check(strReply)) Then
                                        Dim strEquipmentName As String = tssCommand.GetEquipmentName()
                                        Dim decoder As TSDecoder = Activator.CreateInstance(Type.GetType("AVPLib.Communication.TerminalDriver." + tssCommand.DecoderName))
                                        Dim arrPropertyNames As New ArrayList()
                                        Dim arrDecodedValues As ArrayList = decoder.Decode(strReply)
                                        If (arrDecodedValues.Count > 0) Then
                                            Dim arrProperties As String() = tssCommand.EquipmentProperty.Split(",")
                                            For Each PropertyName As String In arrProperties
                                                arrPropertyNames.Add(PropertyName)
                                            Next
                                            EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, arrDecodedValues)
                                            blnResult = True
                                        Else
                                            'Unexpected reply
                                            blnResult = False
                                        End If
                                    Else
                                        'Check sum incorrect
                                        blnResult = False
                                    End If
                                    If isOverTransactionTimeoutLimit() Then
                                        RaiseReconnectStatusEvent(New ReconnectEventArgs(tscCommand.GetEquipmentName()))
                                    End If
                                    ResetTransactionTimeoutCount()
                                End If
                            ElseIf (tscCommand.GetType().Name = "TSSingleReplyCommand") Then
                                Dim tssCommand As TSSingleReplyCommand = CType(tscCommand, TSSingleReplyCommand)
                                Dim strReply As String = tssCommand.ReplyValue
                                If (String.IsNullOrEmpty(strReply)) Then
                                    Me.HandleTimeout(tssCommand)
                                    blnResult = False
                                Else
                                    ' No need to decode, it's ok.
                                    blnResult = True
                                    If isOverTransactionTimeoutLimit() Then
                                        RaiseReconnectStatusEvent(New ReconnectEventArgs(tscCommand.GetEquipmentName()))
                                    End If
                                    ResetTransactionTimeoutCount()
                                End If
                            End If
                        End If
                    End If
                End SyncLock

                If (blnResult) Then
                    ResetTransactionTimeoutCount()
                End If
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

