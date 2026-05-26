Namespace Communication.TerminalDriver
    Public Class TSRobotRqStnDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Decode reply message from Aligner is a result of command RQ STN x ALL
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)
            Const STN_PREFIX As String = "STN "
            Const RESULT_ARRAY_LEN As Integer = 8
            Dim ListValues As New ArrayList()
            Try
                If MessageValue.IndexOf(STN_PREFIX) >= 0 Then

                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)

                    Dim strArray As String() = MessageValue.Split(New Char() {" "c})
                    If (strArray.Length <> RESULT_ARRAY_LEN) Then
                        AVPLib.Log.terminalServerRobotLogger.Error("Failed, incorrect response for RQ STN x ALL  " & MessageValue)
                    Else
                        Dim ReqAlStn_R As Integer = -1
                        If Not (Integer.TryParse(strArray(2), ReqAlStn_R)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect ReqAlStn_R {0} in response {1} for RQ STN x ALL", strArray(2), MessageValue))
                        End If
                        ListValues.Add(ReqAlStn_R)

                        Dim ReqAlStn_Traw As Integer = -1
                        If Not (Integer.TryParse(strArray(3), ReqAlStn_Traw)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect ReqAlStn_Traw {0} in response {1} for RQ STN x ALL", strArray(3), MessageValue))
                        End If
                        ListValues.Add(ReqAlStn_Traw)

                        Dim ReqAlStn_Z As Integer = -1
                        If Not (Integer.TryParse(strArray(4), ReqAlStn_Z)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect ReqAlStn_Z {0} in response {1} for RQ STN x ALL", strArray(4), MessageValue))
                        End If
                        ListValues.Add(ReqAlStn_Z)

                        Dim ReqLOWER As Integer = -1
                        If Not (Integer.TryParse(strArray(5), ReqLOWER)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect ReqLOWER {0} in response {1} for RQ STN x ALL", strArray(5), MessageValue))
                        End If
                        ListValues.Add(ReqLOWER)

                        Dim ReqNSLOTS As Integer = -1
                        If Not (Integer.TryParse(strArray(6), ReqNSLOTS)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect ReqNSLOTS {0} in response {1} for RSLT", strArray(6), MessageValue))
                        End If
                        ListValues.Add(ReqNSLOTS)

                        Dim ReqPITCH As Integer = -1
                        If Not (Integer.TryParse(strArray(7), ReqPITCH)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect ReqPITCH {0} in response {1} for RSLT", strArray(7), MessageValue))
                        End If
                        ListValues.Add(ReqPITCH)

                        Dim ReqSTATION As Integer = -1
                        If Not (Integer.TryParse(strArray(1), ReqSTATION)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect ReqSTATION {0} in response {1} for RSLT", strArray(1), MessageValue))
                        End If
                        ListValues.Add(ReqSTATION)
                    End If
                Else
                    If (MessageValue.IndexOf(ConstEnum.ALIGNER_ERR_MSG) > -1) Then
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