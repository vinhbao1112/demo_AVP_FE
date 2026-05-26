Namespace Communication.TerminalDriver
    Public Class TSAlignerAliveDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-10-14</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue" + MessageValue)
            Const CORRECT_RESPONSE As String = "MYID ALGN"
            Const RESPONSE_PREFIX As String = "SOFT "
            Const RESULT_ARRAY_LEN As Integer = 3
            Dim ListValues As New ArrayList()
            Try
                If MessageValue.IndexOf(CORRECT_RESPONSE) >= 0 Then
                    ListValues.Add(True)
                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                Else
                    ListValues.Add(True)
                    If (MessageValue.IndexOf(ConstEnum.ALIGNER_ERR_MSG) > -1) _
                                OrElse (MessageValue.IndexOf(ConstEnum.ALIGNER_MONITOR_ERR_MSG) > -1) Then
                        ' Error
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.ERROR)
                        ' Just log the incorrect response|error message not alarm.
                        AVPLib.Log.terminalServerRobotLogger.Error("Aligner has error message id: " & MessageValue)
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                    End If
                End If

                If MessageValue.IndexOf(RESPONSE_PREFIX) >= 0 Then
                    Dim strArray As String() = MessageValue.Split(New Char() {" "c})
                    If (strArray.Length <> RESULT_ARRAY_LEN) Then
                        AVPLib.Log.terminalServerRobotLogger.Error("Failed, incorrect response for RQ RVSN " & MessageValue)
                    Else
                        ListValues.Add(strArray(1))
                        ListValues.Add(strArray(2))
                    End If
                Else
                    ' Just log the incorrect response|error message not alarm.
                    AVPLib.Log.terminalServerRobotLogger.Error("Incorrect response or error received " & MessageValue)
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

