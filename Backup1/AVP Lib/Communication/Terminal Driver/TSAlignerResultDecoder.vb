Namespace Communication.TerminalDriver
    Public Class TSAlignerResultDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Decode reply message from Aligner is a result of command RSLT
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)
            Const DATA_PREFIX As String = "DATA "
            Const RESULT_ARRAY_LEN As Integer = 6
            Dim ListValues As New ArrayList()
            Try
                ' TO ANYONE: PLEASE READ AND UNDERSTAND CODE BEFORE MAKING ANY MODIFICATIONS
                If MessageValue.IndexOf(DATA_PREFIX) >= 0 Then

                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)

                    Dim strArray As String() = MessageValue.Split(New Char() {" "c})
                    If (strArray.Length <> RESULT_ARRAY_LEN) And (strArray.Length <> (RESULT_ARRAY_LEN + 1)) Then
                        AVPLib.Log.terminalServerRobotLogger.Error("Failed, incorrect response for RSLT  " & MessageValue)
                    Else
                        Dim RSLTAngularLocation As Integer = -1
                        If Not (Integer.TryParse(strArray(1), RSLTAngularLocation)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect RSLTAngularLocation {0} in response {1} for RSLT", strArray(1), MessageValue))
                        End If
                        ListValues.Add(RSLTAngularLocation) 'RSLTAngularLocation
                        AVPLib.Log.schedulerLogger.Debug("RSLT: RSLTAngularLocation = " & RSLTAngularLocation)
                        ListValues.Add(CSng(RSLTAngularLocation / 10)) 'RSLTAngularLocationDeg for displaying on GUI.

                        Dim RSLTEccentricityAngle As Integer = -1
                        If Not (Integer.TryParse(strArray(2), RSLTEccentricityAngle)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect RSLTEccentricityAngle {0} in response {1} for RSLT", strArray(2), MessageValue))
                        End If
                        ListValues.Add(RSLTEccentricityAngle) 'RSLTEccentricityAngle
                        AVPLib.Log.schedulerLogger.Debug("RSLT: RSLTEccentricityAngle = " & RSLTEccentricityAngle)
                        ListValues.Add(CSng(RSLTEccentricityAngle / 10)) 'RSLTEccentricityAngleDeg for displaying on GUI.

                        Dim RSLTMaxEccentricity As Integer = -1
                        If Not (Integer.TryParse(strArray(3), RSLTMaxEccentricity)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect RSLTMaxEccentricity {0} in response {1} for RSLT", strArray(3), MessageValue))
                        End If
                        ListValues.Add(RSLTMaxEccentricity) 'RSLTMaxEccentricity 
                        AVPLib.Log.schedulerLogger.Debug("RSLT: RSLTMaxEccentricity = " & RSLTMaxEccentricity)
                        ListValues.Add(CSng(RSLTMaxEccentricity / 10)) 'RSLTMaxEccentricityMils for displaying on GUI.

                        Dim RSLTAvgCCD As Integer = -1
                        If Not (Integer.TryParse(strArray(4), RSLTAvgCCD)) Then
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect RSLTAvgCCD {0} in response {1} for RSLT", strArray(4), MessageValue))
                        End If
                        ListValues.Add(RSLTAvgCCD)
                        AVPLib.Log.schedulerLogger.Debug("RSLT: RSLTAvgCCD = " & RSLTAvgCCD)
                        Dim RSLTReScanNeed As Boolean = True
                        If (strArray(5).ToString = "N") Then
                            RSLTReScanNeed = False
                        End If
                        ListValues.Add(RSLTReScanNeed)
                        AVPLib.Log.schedulerLogger.Debug("RSLT: RSLTReScanNeed = " & RSLTReScanNeed)
                        Dim RSLTTypeCode As Integer = -1
                        If (strArray.Length = (RESULT_ARRAY_LEN + 1)) Then
                            If Not (Integer.TryParse(strArray(6), RSLTTypeCode)) Then
                                AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect RSLTTypeCode {0} in response {1} for RSLT", strArray(6), MessageValue))
                            End If
                        End If
                        ListValues.Add(RSLTTypeCode)
                        AVPLib.Log.schedulerLogger.Debug("RSLT: RSLTTypeCode = " & RSLTTypeCode)
                    End If
                Else
                    If (MessageValue.IndexOf(ConstEnum.ALIGNER_ERR_MSG) > -1) OrElse (MessageValue.IndexOf(ConstEnum.ALIGNER_MONITOR_ERR_MSG) > -1) Then
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
