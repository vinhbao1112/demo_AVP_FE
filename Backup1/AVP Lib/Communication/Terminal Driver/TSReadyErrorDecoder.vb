Namespace Communication.TerminalDriver
    Public Class TSReadyErrorDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            'Note: When we get here the message value may have the following value
            ' 1. Ready response, that's what we need.
            ' 2. Request response or Incorrect Resonse, we log them.
            Dim ListValues As New ArrayList()
            Try
                If MessageValue = "_RDY" Then
                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                Else
                    If (MessageValue.IndexOf(ConstEnum.ROBOT_ERR_MSG) > -1) Then
                        ' Error
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.ERROR)
                    Else
                        'Dat Do: 2/20/2011
                        ' Remove this because if the ERROR message reply in the middle of this sequence
                        ''' RE 01 0001 DN
                        ''' EX 01 0001 DN
                        ''' EX 01 0001 UP
                        ''' RE 01 0001 UP
                        ''' the Error could not be catched

                        'ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)

                    End If
                    ' Just log the incorrect response message not alarm.
                    AVPLib.Log.terminalServerRobotLogger.Debug("Request respond skipped or Incorrect response|Error received " & MessageValue)
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

