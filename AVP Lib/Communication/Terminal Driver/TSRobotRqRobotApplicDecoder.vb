Namespace Communication.TerminalDriver
    Public Class TSRobotRqRobotApplicDecoder
        Inherits TSDecoder

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-18 </date>
        ''' </author>
        ''' <summary>
        ''' Decode reply message from Robot is a result of command RQ ROBOT APPLIC
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)
            ' Response: "ROBOT APPLIC application-number"
            Const RESPONSE_PREFIX As String = "ROBOT APPLIC "
            Dim ListValues As New ArrayList()
            Try
                If MessageValue.IndexOf(RESPONSE_PREFIX) >= 0 Then

                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)

                    Dim strArray As String() = MessageValue.Split(New Char() {" "c})
                    ListValues.Add(strArray(2))
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