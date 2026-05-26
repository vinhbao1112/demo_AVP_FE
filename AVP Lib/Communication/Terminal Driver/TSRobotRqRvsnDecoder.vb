Namespace Communication.TerminalDriver
    Public Class TSRobotRqRvsnDecoder
        Inherits TSDecoder

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Decode reply message from Robot is a result of command RQ RVSN
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)
            ' Response: "RVSN part-number revision-number"
            Const RESPONSE_PREFIX As String = "RVSN "
            Const RESULT_ARRAY_LEN As Integer = 3
            Dim ListValues As New ArrayList()
            Try
                If MessageValue.IndexOf(RESPONSE_PREFIX) >= 0 Then

                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)

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
    End Class
End Namespace