Imports System.Text.RegularExpressions
Namespace DataManagerment
    Public Class TSRobotUpDownExtractRetractedDecoder

#Region "Public method"
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2011-2-17 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Decode below message from ROBOT
        ''' RE 01 0001 DN
        ''' EX 01 0001 DN
        ''' EX 01 0001 UP
        ''' RE 01 0001 UP
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub DecodeAndChangeStatus(ByVal strEquipmentName As String, _
                                                ByVal MessageValue As String)
            AVPLib.Log.terminalServerLogger.Info("Enter DecodeAndChangeStatus")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)

            Const ExtendRetractGroupName As String = "ExtendRetract"
            Const StationGroupName As String = "Station"
            Const UpDownGroupName As String = "UpDown"

            ' Case 1: RE 08 0001 UP
            Const MessagePattern1 As String = "(?<" & ExtendRetractGroupName & ">(RE|EX))\s+(?<" & StationGroupName & ">[0-9]+)\s+\S+\s+(?<" & UpDownGroupName & ">(DN|UP))$"

            ' Case 2: 08 0001 RE UP
            Const MessagePattern2 As String = "(?<" & StationGroupName & ">[0-9]+)\s+\S+\s+(?<" & ExtendRetractGroupName & ">(RE|EX))\s+(?<" & UpDownGroupName & ">(DN|UP))$"

            Dim ListValues As New ArrayList
            'Dim strRegularExp = "(RE|EX)\s+(\d+)\s+(\d+)\s+(DN|UP)$"
            'match these case
            'RE 02 0001 DN
            'POS STN RE 02 0001 DN 

            Try
                Dim mtcMatch As Match = Regex.Match(MessageValue, MessagePattern1)
                ' Try for Pattern 2 if Pattern is not matched.
                If Not mtcMatch.Success Then
                    mtcMatch = Regex.Match(MessageValue, MessagePattern2)
                End If
                If (mtcMatch.Success) Then

                    If mtcMatch.Groups(UpDownGroupName).Value = AVPLib.ConstEnum.RobotArmStatus.DN.ToString() Then
                        ListValues.Add(AVPLib.ConstEnum.RobotArmStatus.DN)
                    ElseIf mtcMatch.Groups(UpDownGroupName).Value = AVPLib.ConstEnum.RobotArmStatus.UP.ToString() Then
                        ListValues.Add(AVPLib.ConstEnum.RobotArmStatus.UP)
                    Else
                        'Ignore the error message
                        ' AVPLib.Log.terminalServerRobotLogger.Error(String.Format("Failed, incorrect in response for RQ POS STN ALL: {0}", MessageValue))
                    End If
                    'station ID
                    Dim ReqStation As Integer = -1
                    If (Integer.TryParse(mtcMatch.Groups(StationGroupName).Value, ReqStation)) Then
                        'Response field size: 2 
                        'The current station number being addressed. The return value will be 0, if no station is addressed.
                        Select Case ReqStation ''real position to GUI position
                            Case RobotConfigurationValues.ROBOT_STATION_NO
                                ListValues.Add(AVPLib.ConstEnum.Positions.Original)
                            Case RobotConfigurationValues.LLA_STATION_NO
                                If mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_LLA_Extract)
                                ElseIf mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.LoadLockA)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                    AVPLib.Log.terminalServerRobotLogger.Error("Fail to parse message:" + MessageValue)
                                End If
                            Case RobotConfigurationValues.PM1_STATION_NO
                                If mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_Chamber1_Extract)
                                ElseIf mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Chamber1)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                    AVPLib.Log.terminalServerRobotLogger.Error("Fail to parse message:" + MessageValue)
                                End If
                            Case RobotConfigurationValues.PM2_STATION_NO
                                If mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_Chamber2_Extract)
                                ElseIf mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Chamber2)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                    AVPLib.Log.terminalServerRobotLogger.Error("Fail to parse message:" + MessageValue)
                                End If
                            Case RobotConfigurationValues.PM3_STATION_NO
                                If mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_Chamber3_Extract)
                                ElseIf mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Chamber3)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                    AVPLib.Log.terminalServerRobotLogger.Error("Fail to parse message:" + MessageValue)
                                End If
                            Case RobotConfigurationValues.ALIGNER_STATION_NO
                                If mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Aligner_Extract)
                                ElseIf mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_Aligner_Retract)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                    AVPLib.Log.terminalServerRobotLogger.Error("Fail to parse message:" + MessageValue)
                                End If
                            Case RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO
                                If mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_EX Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Aligner_Extract_DeltaPick)
                                ElseIf mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_RE Then
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Arm_At_Aligner_Retract_DeltaPick)
                                Else
                                    ListValues.Add(AVPLib.ConstEnum.Positions.Unknown)
                                    AVPLib.Log.terminalServerRobotLogger.Error("Fail to parse message:" + MessageValue)
                                End If
                        End Select

                        If mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_EX Then
                            ListValues.Add(AVPLib.ConstEnum.RobotEXREStatus.EX)
                        ElseIf mtcMatch.Groups(ExtendRetractGroupName).Value = ConstEnum.STR_RE Then
                            ListValues.Add(AVPLib.ConstEnum.RobotEXREStatus.RE)
                        Else
                            ListValues.Add(AVPLib.ConstEnum.RobotEXREStatus.UNKNOWN)
                        End If

                        If ListValues.Count > 0 Then
                            ' Special command: hard code for this
                            ' Properties CurrentPosition, ErrorMessage
                            Dim arrPropertyNames As New ArrayList()
                            arrPropertyNames.Add("CurrentArmStatus")
                            arrPropertyNames.Add("CurrentPosition")
                            arrPropertyNames.Add("ExternRetractStatus")
                            arrPropertyNames.Add("ErrorMessage")
                            EquipmentManager.ChangeStatus(strEquipmentName, arrPropertyNames, ListValues)
                        End If

                    End If
                Else
                    'Just ignore the message if it is not as our expected
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave DecodeAndChangeStatus")

        End Sub
#End Region
    End Class
End Namespace