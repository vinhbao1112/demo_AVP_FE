Imports System.Text.RegularExpressions
Namespace Communication.TerminalDriver
    Public Class TSRobotRqPosStnDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Ngo  Cao Dinh </name>
        '''    	<date> 2008-12-15 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Decode retracted status
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)

            Dim ListValues As New ArrayList
            'POS STN ex/re-location station slot up/dn-location
            'POS STN [ex/re-location] [station] [slot] [up/dn-location]
            Const STR_EX As String = "EX"
            Const STR_RE As String = "RE"

            Const ExtendRetractGroupName As String = "ExtendRetract"
            Const StationGroupName As String = "Station"
            Const UpDownGroupName As String = "UpDown"

            Const MessagePattern As String = "^POS\s+STN\s+(?<" & ExtendRetractGroupName & ">\w+)\s+(?<" & StationGroupName & ">[0-9]+)\s+\S+\s+(?<" & UpDownGroupName & ">\w+).*"

            Try
                Dim messageMatch As Match = Regex.Match(MessageValue, MessagePattern, RegexOptions.IgnoreCase)

                If messageMatch.Success Then
                    'station
                    Dim ReqStation As Integer = -1
                    If messageMatch.Groups(UpDownGroupName).Value.ToUpper() = AVPLib.ConstEnum.RobotArmStatus.DN.ToString() Then
                        ListValues.Add(AVPLib.ConstEnum.RobotArmStatus.DN)
                    ElseIf messageMatch.Groups(UpDownGroupName).Value.ToUpper() = AVPLib.ConstEnum.RobotArmStatus.UP.ToString() Then
                        ListValues.Add(AVPLib.ConstEnum.RobotArmStatus.UP)
                    Else
                        ListValues.Add(AVPLib.ConstEnum.RobotArmStatus.UNKNOWN)
                        AVPLib.Log.terminalServerRobotLogger.Debug(String.Format("Failed, incorrect in response for RQ POS STN ALL: {0}", messageMatch.Groups(UpDownGroupName).Value))
                    End If

                    If Not (Integer.TryParse(messageMatch.Groups(StationGroupName).Value, ReqStation)) Then
                        AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect in response {0} for RQ POS STN ALL: {1}", messageMatch.Groups(StationGroupName).Value, MessageValue))
                    Else
                        Dim extendRetractValue As String = messageMatch.Groups(ExtendRetractGroupName).Value

                        'Response field size: 2 
                        'The current station number being addressed. The return value will be 0, if no station is addressed.
                        Select Case ReqStation ''real position to GUI position
                            Case RobotConfigurationValues.ROBOT_STATION_NO
                                ListValues.Add(AVPLib.ConstEnum.Positions.Original)

                            Case RobotConfigurationValues.LLA_STATION_NO
                                If extendRetractValue = STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_LLA_Extract)
                                ElseIf extendRetractValue = STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.LoadLockA)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                End If

                            Case RobotConfigurationValues.PM1_STATION_NO
                                If extendRetractValue = STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_Chamber1_Extract)
                                ElseIf extendRetractValue = STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Chamber1)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                End If

                            Case RobotConfigurationValues.PM2_STATION_NO
                                If extendRetractValue = STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_Chamber2_Extract)
                                ElseIf extendRetractValue = STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Chamber2)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                End If

                            Case RobotConfigurationValues.PM3_STATION_NO
                                If extendRetractValue = STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_Chamber3_Extract)
                                ElseIf extendRetractValue = STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Chamber3)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                End If

                            Case RobotConfigurationValues.ALIGNER_STATION_NO
                                If extendRetractValue = STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Aligner_Extract)
                                ElseIf extendRetractValue = STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_Aligner_Retract)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                End If

                            Case RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO
                                If extendRetractValue = STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Aligner_Extract_DeltaPick)
                                ElseIf extendRetractValue = STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_Aligner_Retract_DeltaPick)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                End If
                        End Select

                        If extendRetractValue = STR_EX Then
                            ListValues.Add(AVPLib.ConstEnum.RobotEXREStatus.EX)
                        ElseIf extendRetractValue = STR_RE Then
                            ListValues.Add(AVPLib.ConstEnum.RobotEXREStatus.RE)
                        Else
                            ListValues.Add(AVPLib.ConstEnum.RobotEXREStatus.UNKNOWN)
                            AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect in response {0} for RQ POS STN ALL: {1}", extendRetractValue, MessageValue))
                        End If
                    End If
                Else
                    AVPLib.Log.terminalServerRobotLogger.Error("Failed, incorrect response for RQ POS STN ALL  " & MessageValue)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If ListValues.Count = 0 Then
                    ListValues.Add(AVPLib.ConstEnum.Positions.Original)
                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                    ListValues.Add(AVPLib.ConstEnum.RobotEXREStatus.UNKNOWN)
                End If
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave Decode")
            Return ListValues
        End Function
#End Region
    End Class
End Namespace
