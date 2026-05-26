Namespace Communication.TerminalDriver
    Public Class TSRobotRqAccDecoder
        Inherits TSDecoder

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Decode reply message from Robot is a result of command RQ (HACC|PACC|WACC) ALL
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)
            ' Response: "(HACC|PACC|WACC) r-acceleration t-acceleration z-acceleration"
            Const RESPONSE_PREFIX As String = "ACC "
            Const RESULT_ARRAY_LEN As Integer = 4
            Dim ListValues As New ArrayList()
            Try
                If MessageValue.IndexOf(RESPONSE_PREFIX) >= 0 Then

                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)

                    Dim strArray As String() = MessageValue.Split(New Char() {" "c})
                    If (strArray.Length <> RESULT_ARRAY_LEN) Then
                        AVPLib.Log.terminalServerRobotLogger.Error("Failed, incorrect response for RQ (HACC|PACC|WACC) ALL " & MessageValue)
                    Else
                        ' R-accleration
                        Dim rAcceleration As Integer = -1
                        If Not Integer.TryParse(strArray(1), rAcceleration) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect R-acceleration {0} in response {1} for RQ (HACC|PACC|WACC) ALL", strArray(1), MessageValue))
                        End If
                        ListValues.Add(rAcceleration)

                        ' T-acceleration
                        Dim tAcceleration As Integer = -1
                        If Not Integer.TryParse(strArray(2), tAcceleration) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect T-acceleration {0} in response {1} for RQ (HACC|PACC|WACC) ALL", strArray(2), MessageValue))
                        End If
                        ListValues.Add(tAcceleration)

                        ' Z-acceleration
                        Dim zAcceleration As Integer = -1
                        If Not Integer.TryParse(strArray(3), zAcceleration) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect Z-acceleration {0} in response {1} for RQ (HACC|PACC|WACC) ALL", strArray(3), MessageValue))
                        End If
                        ListValues.Add(zAcceleration)
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