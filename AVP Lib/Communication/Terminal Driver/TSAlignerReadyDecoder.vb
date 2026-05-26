Namespace Communication.TerminalDriver
    Public Class TSAlignerReadyDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-28</date>
        ''' </author>
        ''' <summary>
        ''' Decode reply message from Aligner is ready or error
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)

            Dim ListValues As New ArrayList()
            Try
                If MessageValue = "_RDY" Then
                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                Else
                    If (MessageValue.IndexOf(ConstEnum.ALIGNER_ERR_MSG) > -1) _
                            OrElse (MessageValue.IndexOf(ConstEnum.ALIGNER_MONITOR_ERR_MSG) > -1) Then
                        'Error
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.ERROR)
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                    End If
                    ' Just log the incorrect response|error message not alarm.
                    AVPLib.Log.terminalServerRobotLogger.Error("Incorrect response or error received " & MessageValue)
                    'ListValues.Add(Utils.GetMessageError(MessageValue))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave Decode")
            Return ListValues
        End Function
#End Region
    End Class
End Namespace