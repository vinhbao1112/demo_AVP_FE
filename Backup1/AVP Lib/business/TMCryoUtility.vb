Imports AVPLib.Communication.TerminalDriver
Imports avplib.Driver
Imports AVPLib.ConstEnum
Imports AVPLib.Driver.DriverConst
Namespace Business
    Public Class TMCryoUtility
        Const MAX_CRYO_PARAM As Integer = 5
        Const MPCommunicationTimeOut As Int64 = 60 '60s
#Region "Public methods"
        Private Shared Function AppendValueInParam(ByVal value As String) As String
            Try
                For i As Integer = 1 To MAX_CRYO_PARAM - value.Length
                    value = "0" & value
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return value
        End Function

        Public Shared Sub RequestPumpRestartDelay(ByVal Name As String, ByVal Value As String)
            AVPLib.Log.coreLogger.Info("Enter RequestPumpRestartDelay")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P0" & AppendValueInParam(Value)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Name & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RequestPumpRestartDelay")
        End Sub

        Public Shared Sub RequestExtendedPurgeTime(ByVal Name As String, ByVal Value As String)
            AVPLib.Log.coreLogger.Info("Enter RequestExtendedPurgeTime")
            Try
                Dim cs As New CheckSum

                Dim strMessage As String = "P1" & AppendValueInParam(Value)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Name & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RequestExtendedPurgeTime")
        End Sub

        Public Shared Sub RequestRepurgeCycles(ByVal Name As String, ByVal Value As String)
            AVPLib.Log.coreLogger.Info("Enter RequestRepurgeCycles")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P2" & AppendValueInParam(Value)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Name & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RequestRepurgeCycles")
        End Sub

        Public Shared Sub RequestRoughToPressure(ByVal Name As String, ByVal Value As String)
            AVPLib.Log.coreLogger.Info("Enter RequestRoughToPressure")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P3" & AppendValueInParam(Value)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Name & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RequestRoughToPressure")
        End Sub

        Public Shared Sub RequestRateOfRise(ByVal Name As String, ByVal Value As String)
            AVPLib.Log.coreLogger.Info("Enter RequestRateOfRise")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P4" & AppendValueInParam(Value)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Name & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RequestRateOfRise")
        End Sub

        Public Shared Sub RequestStartUpTemp(ByVal Name As String, ByVal Value As String)
            AVPLib.Log.coreLogger.Info("Enter RequestStartUpTemp")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P6" & AppendValueInParam(Value)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Name & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RequestStartUpTemp")
        End Sub


        Public Shared Sub StartFastRegen(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter StartRegen")
            Try
                Dim strMessage As String = Name + "." + "$N22"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRegen")
        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Stop Regen
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Sub StartRegen(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter StartRegen")
            Try
                Dim strMessage As String = Name + "." + "$N1n"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRegen")
        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Stop Regen
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Sub StopRegen(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter StopRegen")
            Try
                Dim strMessage As String = Name + "." + "$N0o"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopRegen")
        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Turn Pump Off
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Sub TurnPumpOff(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter TurnPumpOff")
            Try
                Dim strMessage As String = Name + "." + "$A0`"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnPumpOff")
        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Turn Pump On
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Sub TurnPumpOn(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter TurnPumpOn")
            Try
                Dim strMessage As String = Name + "." + "$A1c"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnPumpOn")
        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get first stage temperature
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Function GetFirstStageTemperature(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetFirstStageTemperature")
            Try
                Dim strMessage As String = Name + "." + "$J;"
                AVPLib.Log.coreLogger.Info("Leave TurnPumpOn")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetFirstStageTemperature")
        End Function
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get second stage temperature
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Function GetSecondStageTemperature(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetSecondStageTemperature")
            Try
                Dim strMessage As String = Name + "." + "$K:"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetSecondStageTemperature")
        End Function
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get Regen status
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Function GetPumpStatus(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetPumpStatus")
            Try
                Dim strMessage As String = Name + "." + "$A?2"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetPumpStatus")
        End Function

        Public Shared Sub GetRegenHour(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter GetRegenHour")
            Try
                Dim strMessage As String = Name + "." + "$aP"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRegenHour")
        End Sub

        Public Shared Sub GetLifeTimeHour(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter GetLifeTimeHour")
            Try
                Dim strMessage As String = Name + "." + "$Y?J"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetLifeTimeHour")
        End Sub

        Public Shared Function GetPumpRestartDelay(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetPumpRestartDelay")
            Try
                Dim strMessage As String = Name + "." + "$P0?m"
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetPumpRestartDelay")
            Return False
        End Function

        Public Shared Function GetExtendedPurgeTime(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetExtendedPurgeTime")
            Try
                Dim strMessage As String = Name + "." + "$P1?3"
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetExtendedPurgeTime")
            Return False
        End Function

        Public Shared Function GetRepurgeCycles(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetRepurgeCycles")
            Try
                Dim strMessage As String = Name + "." + "$P2?2"
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRepurgeCycles")
            Return False
        End Function

        Public Shared Function GetRoughToPressure(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetRoughToPressure")
            Try
                Dim strMessage As String = Name + "." + "$P3?1"
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRoughToPressure")
            Return False
        End Function

        Public Shared Function GetRateOfRise(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetRateOfRise")
            Try
                Dim strMessage As String = Name + "." + "$P4?0"
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRateOfRise")
            Return False
        End Function

        Public Shared Function GetStartUpTemp(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetStartUpTemp")
            Try
                Dim strMessage As String = Name + "." + "$P6?6"
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetStartUpTemp")
            Return False
        End Function


        Public Shared Sub GetPullingStatus(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter GetPullingStatus")
            Try
                Dim strMessage As String = Name + "." + "$S16"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetPullingStatus")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get Regen status
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Function GetRegenStatus(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetRegenStatus")
            Try
                Dim strMessage As String = Name + "." + "$O>"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRegenStatus")
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Close all slit valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function CloseAllSlitValve(ByVal waitTimeInMilliseconds As Integer, ByVal abortedEvent As Threading.ManualResetEvent) As String
            AVPLib.Log.coreLogger.Info("Enter CloseAllSlitValve")
            Dim objChamber1 As DataManagerment.Chamber = CType(DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString()), DataManagerment.Chamber)
            Dim objChamber2 As DataManagerment.Chamber = CType(DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString()), DataManagerment.Chamber)
            Dim objChamber3 As DataManagerment.Chamber = CType(DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString()), DataManagerment.Chamber)
            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
            Dim objLoadLockA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
            Dim strErrMsg As String = String.Empty
            Const ErrAborted As String = "Close All Slit Valves Is Cancelled."
            Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            Try
                ' Check Robot Retracted.
                Dim bIsRobotRetracted As Boolean = RobotUtility.IsRobotRetract()
                Dim strErrRetracted As String = String.Empty
                If Not bIsRobotRetracted Then
                    strErrRetracted = String.Format(ContainerData.GetMessageText("RobotWasNotRetract"), "Close All Slit Valves")
                End If
                If abortedEvent.WaitOne(0, True) Then
                    Return ErrAborted
                End If
                ' Close Slit Valve 1.
                If (objChamber1 IsNot Nothing) AndAlso
                                            (Not (objTransferModule.SplitValve2Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then
                    If (bIsRobotRetracted) Then
                        strErrMsg = Utils.IsRobotStationOKToOpenCloseSlitValve(ConstEnum.Equipments.Chamber1.ToString(), AVPLib.RobotConfigurationValues.CHAMBER1_NAME, False)
                        If strErrMsg <> String.Empty Then
                            Return strErrMsg
                        End If

                        strErrMsg = ChamberUtility.OpenCloseSlitValve(Equipments.Chamber1.ToString(), False)
                    Else
                        strErrMsg = strErrRetracted
                    End If
                    If strErrMsg <> String.Empty Then
                        Return strErrMsg
                    End If
                End If
                If abortedEvent.WaitOne(0, True) Then
                    Return ErrAborted
                End If
                ' Close Slit Valve 2.
                If (objChamber2 IsNot Nothing) AndAlso
                       (Not (objTransferModule.SplitValve3Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then
                    If (bIsRobotRetracted) Then
                        strErrMsg = Utils.IsRobotStationOKToOpenCloseSlitValve(ConstEnum.Equipments.Chamber2.ToString(), AVPLib.RobotConfigurationValues.CHAMBER2_NAME, False)
                        If strErrMsg <> String.Empty Then
                            Return strErrMsg
                        End If

                        strErrMsg = ChamberUtility.OpenCloseSlitValve(Equipments.Chamber2.ToString(), False)
                    Else
                        strErrMsg = strErrRetracted
                    End If
                    If strErrMsg <> String.Empty Then
                        Return strErrMsg
                    End If
                End If
                If abortedEvent.WaitOne(0, True) Then
                    Return ErrAborted
                End If
                ' Close Slit Valve 3.
                If (objChamber3 IsNot Nothing) AndAlso
                        (Not (objTransferModule.SplitValve4Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then
                    If (bIsRobotRetracted) Then
                        strErrMsg = Utils.IsRobotStationOKToOpenCloseSlitValve(ConstEnum.Equipments.Chamber3.ToString(), AVPLib.RobotConfigurationValues.CHAMBER3_NAME, False)
                        If strErrMsg <> String.Empty Then
                            Return strErrMsg
                        End If

                        strErrMsg = ChamberUtility.OpenCloseSlitValve(Equipments.Chamber3.ToString(), False)
                    Else
                        strErrMsg = strErrRetracted
                    End If
                    If strErrMsg <> String.Empty Then
                        Return strErrMsg
                    End If
                End If
                If abortedEvent.WaitOne(0, True) Then
                    Return ErrAborted
                End If

                If abortedEvent.WaitOne(0, True) Then
                        Return ErrAborted
                    End If
                ' Close Slit Valve LLA.
                If (objLoadLockA IsNot Nothing) AndAlso
                   (Not (objTransferModule.SplitValve1Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then
                    If (bIsRobotRetracted) Then
                        strErrMsg = ChamberUtility.OpenCloseSlitValve(Equipments.LoadLockA.ToString(), False)
                    Else
                        strErrMsg = strErrRetracted
                    End If
                    If strErrMsg <> String.Empty Then
                        Return strErrMsg
                    End If
                End If
                If abortedEvent.WaitOne(0, True) Then
                    Return ErrAborted
                End If
                ' Verify Valves Status.
                Dim span As Int64 = waitTimeInMilliseconds
                Dim start As Int64 = Environment.TickCount
                While (Environment.TickCount - start <= span)
                    If abortedEvent.WaitOne(0, False) Then
                        Return ErrAborted
                    End If
                    ' Check Condition.
                    Dim IsSplitValveLLAClose As Boolean = True
                    Dim IsSplitValvePM1Close As Boolean = True
                    Dim IsSplitValvePM2Close As Boolean = True
                    Dim IsSplitValvePM3Close As Boolean = True
                    IsSplitValveLLAClose = IIf(objLoadLockA Is Nothing, True, objTransferModule.SplitValve1Status = DataManagerment.Equipment.WorkingStatuses.Off)
                        IsSplitValvePM1Close = IIf(objChamber1 Is Nothing, True, objTransferModule.SplitValve2Status = DataManagerment.Equipment.WorkingStatuses.Off)
                        IsSplitValvePM2Close = IIf(objChamber2 Is Nothing, True, objTransferModule.SplitValve3Status = DataManagerment.Equipment.WorkingStatuses.Off)
                        IsSplitValvePM3Close = IIf(objChamber3 Is Nothing, True, objTransferModule.SplitValve4Status = DataManagerment.Equipment.WorkingStatuses.Off)
                    If IsSplitValveLLAClose And IsSplitValvePM1Close And IsSplitValvePM2Close And IsSplitValvePM3Close Then
                        ' It's Ok.
                        Return String.Empty
                    End If
                    If abortedEvent.WaitOne(100, False) Then
                        Return ErrAborted
                    End If
                End While
                ' Time Out Happens.
                Threading.Thread.Sleep(2000)
                'Van Le change to Check SlitValveStatus is not off
                If (objLoadLockA IsNot Nothing) And (
                        Not (objTransferModule.SplitValve1Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then ''LLA
                    ChamberUtility.UnknownSlitValve(Equipments.LoadLockA.ToString())
                    strErrMsg = String.Format(ContainerData.GetMessageText("RobotLLASlitValveMustBeClosed"), AVPLib.ConstEnum.TM_STR)
                End If
                If (objChamber1 IsNot Nothing) And ( _
                        Not (objTransferModule.SplitValve2Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then
                        ChamberUtility.UnknownSlitValve(Equipments.Chamber1.ToString())
                        If strErrMsg = String.Empty Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("EquipmentSlitValveStatusClosed"),
                                                             AVPLib.RobotConfigurationValues.CHAMBER1_NAME)
                        End If
                    End If
                    If (objChamber2 IsNot Nothing) And (
                        Not (objTransferModule.SplitValve3Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then
                        ChamberUtility.UnknownSlitValve(Equipments.Chamber2.ToString())
                        If strErrMsg = String.Empty Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("EquipmentSlitValveStatusClosed"),
                                                             AVPLib.RobotConfigurationValues.CHAMBER2_NAME)
                        End If
                    End If
                    If (objChamber3 IsNot Nothing) And (
                            Not (objTransferModule.SplitValve4Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then
                        ChamberUtility.UnknownSlitValve(Equipments.Chamber3.ToString())
                        If strErrMsg = String.Empty Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("EquipmentSlitValveStatusClosed"),
                                                                 AVPLib.RobotConfigurationValues.CHAMBER3_NAME)
                        End If
                    End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseAllSlitValve")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Turn off TMIG 
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function TurnOffIG(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseTurnTMIG")
            Dim strErrMsg As String = String.Empty
            Try

                If (IsTMIGDisconnected(strErrMsg)) Then
                    Exit Try
                End If

                Dim objTMIG As IGDriver = DriverManager.GetDriver(DriverConst.CassettesModule_IonGauge)
                If (objTMIG IsNot Nothing) Then
                    If (Not objTMIG.TurnOffIG()) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("TurnIGCGFailed"), _
                                     "Off TM IG")
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseTurnTMIG")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Turn on TMIG
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function TurnOnIG(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter OpenTurnTMIG")
            Dim strErrMsg As String = String.Empty

            Try

                If (IsTMIGDisconnected(strErrMsg)) Then
                    Exit Try
                End If

                Dim objTMIG As IGDriver = DriverManager.GetDriver(DriverConst.CassettesModule_IonGauge)
                If (objTMIG IsNot Nothing) Then
                    If (Not objTMIG.TurnOnIG()) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("TurnIGCGFailed"), _
                                     "On TM IG")
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenTurnTMIG")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-07-05 </date>
        ''' </author>
        ''' <summary>
        ''' Switch IG Filament 1
        ''' </summary>
        Public Shared Function SwitchIGFilament1() As String
            AVPLib.Log.coreLogger.Info("Enter SwitchIGFilament1")
            Dim strErrMsg As String = String.Empty

            Try

                If (IsTMIGDisconnected(strErrMsg)) Then
                    Exit Try
                End If

                Dim objTMIG As IGDriver = DriverManager.GetDriver(DriverConst.CassettesModule_IonGauge)
                If (objTMIG IsNot Nothing) Then
                    If (Not objTMIG.SwitchIGFilament1) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("SwitchIGFilamentFailed"), _
                                     "1 TM IG")
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SwitchIGFilament1")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-07-05 </date>
        ''' </author>
        ''' <summary>
        ''' Switch IG Filament 2
        ''' </summary>
        Public Shared Function SwitchIGFilament2() As String
            AVPLib.Log.coreLogger.Info("Enter SwitchIGFilament2")
            Dim strErrMsg As String = String.Empty

            Try

                If (IsTMIGDisconnected(strErrMsg)) Then
                    Exit Try
                End If

                Dim objTMIG As IGDriver = DriverManager.GetDriver(DriverConst.CassettesModule_IonGauge)
                If (objTMIG IsNot Nothing) Then
                    If (Not objTMIG.SwitchIGFilament2()) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("SwitchIGFilamentFailed"), _
                                     "2 TM IG")
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SwitchIGFilament2")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Turn on TMIG
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function TurnIGDegas_On(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter TurnIGDegas_On")
            Dim strErrMsg As String = String.Empty
            Try
                If (IsTMIGDisconnected(strErrMsg)) Then
                    Exit Try
                End If

                Dim objTMIG As IGDriver = DriverManager.GetDriver(DriverConst.CassettesModule_IonGauge)
                If (objTMIG IsNot Nothing) Then
                    ''Turn RO Off then RO On if mode is Kepware, only turn on IG Degas if mode is RSTi
                    If (Not objTMIG.TurnOnIGDegas()) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("TurnIGCGFailed"), _
                                     "On TM IGDegas")
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnIGDegas_On")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-07-04</date>
        ''' </author>
        ''' <summary>
        ''' Check Device status
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Function IsTMIGDisconnected(Optional ByRef ErrorMsg As String = "") As Boolean
            Dim blResult As Boolean = False
            Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
            If (objTM IsNot Nothing AndAlso objTM.IG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                ErrorMsg = Utils.chamberID2ChamberName(ConstEnum.Equipments.CassettesModule.ToString) & IG_DISCONNECTED
                blResult = True
            Else
                ErrorMsg = String.Empty
                blResult = False
            End If
        End Function
        Public Shared Function IsMPumpCommunicationCond(ByVal ParamArray arg() As Object) As Boolean
            Dim blResult As Boolean = False
            Try
                'check length of array parameter
                If (arg.Length < 1) Then
                    Exit Try
                End If

                'get parameter
                Dim strEquimentName As String = arg(0)
                Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetEquipment(strEquimentName)
                If (strEquimentName = Equipments.RoughPumpMachine1.ToString() AndAlso RobotConfigurationValues.MPUMP1_SERIAL_VISIBLE) OrElse _
                        (strEquimentName = Equipments.RoughPumpMachine2.ToString() AndAlso RobotConfigurationValues.MPUMP2_SERIAL_VISIBLE) Then

                    Dim conn As AVPLib.Communication.TerminalServerConnection = AVPLib.Communication.ConnectionManager.GetConnection(strEquimentName)
                    Return (conn.Open() AndAlso MechanicalPumpUtility.GetCommunicationStatus(strEquimentName))
                Else 'alway return true if hivac isnot installed
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try

            Return blResult
        End Function

        Public Shared Function TurnIGDegas_Off(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter TurnIGDegas_Off")
            Dim strErrMsg As String = String.Empty
            Try

                If (IsTMIGDisconnected(strErrMsg)) Then
                    Exit Try
                End If

                Dim objTMIG As IGDriver = DriverManager.GetDriver(DriverConst.CassettesModule_IonGauge)
                If (objTMIG IsNot Nothing) Then
                    If (Not objTMIG.TurnOffIGDegas()) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("TurnIGCGFailed"), _
                                     "Off TM IGDegas")
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnIGDegas_Off")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Close HiVacValve
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function CloseHiVacValve(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseHiVacValve")
            Dim strErrMsg As String = String.Empty
            Try
                If (RobotConfigurationValues.TM_HIVAC_INSTALLED) Then
                    Dim objTMHivacValve As HivacValveDriver = DriverManager.GetDriver(DriverConst.CassettesModule_TMHiVac)
                    If (objTMHivacValve IsNot Nothing) Then
                        If objTMHivacValve.eCommunicationType = CommType.DeviceNet AndAlso Not objTMHivacValve.IsDeviceActive() Then
                            strErrMsg = "TM Can't Close Hivac Valve Due To Solenoid 1 Is Not Online."
                            Exit Try
                        End If

                        If (Not objTMHivacValve.CloseHivacValve()) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("OpenCloseValveFailed"), _
                                         "TM Hivac Valve")
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseHiVacValve")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Open HiVacValve()
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function OpenHiVacValve(ByVal Equipment As String, Optional ByVal isCheckSafety As Boolean = True, Optional ByVal dbCGMultiFactor As Double = 1) As String
            AVPLib.Log.coreLogger.Info("Enter OpenHiVacValve")
            Dim strErrMsg As String = String.Empty
            Try
                If (RobotConfigurationValues.TM_HIVAC_INSTALLED) Then
                    'check condition before opening hivac
                    If isCheckSafety Then
                        Dim transferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                        Dim strCheckResult = transferModule.checkCondition2OpenTMHiVac(dbCGMultiFactor)
                        If Not (String.IsNullOrEmpty(strCheckResult)) Then
                            Return strCheckResult
                        End If

                        If RobotConfigurationValues.TMCRYO_VISIBLE OrElse RobotConfigurationValues.TMTURBO_VISIBLE Then
                            Dim objTMPumpPackageCtrl As PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
                            If (objTMPumpPackageCtrl IsNot Nothing) AndAlso (objTMPumpPackageCtrl.IsCommunicationOK = False) Then
                                strErrMsg = String.Format("Can not open TM Hivac because of {0} TimeOut.", objTMPumpPackageCtrl.DisplayName)
                                Return strErrMsg
                            End If
                        End If
                    End If

                    Dim objTMHivacValve As HivacValveDriver = DriverManager.GetDriver(DriverConst.CassettesModule_TMHiVac)
                    If (objTMHivacValve IsNot Nothing) Then
                        If objTMHivacValve.eCommunicationType = CommType.DeviceNet AndAlso Not objTMHivacValve.IsDeviceActive() Then
                            strErrMsg = "TM Can't Open Hivac Valve Due To Solenoid 1 Is Not Online."
                            Exit Try
                        End If

                        If (Not objTMHivacValve.OpenHivacValve()) Then
                            strErrMsg = "Open TM Hivac Valve Failed"
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenHiVacValve")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-14</date>
        ''' </author>
        ''' <summary>
        ''' Open rough valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function OpenRoughValve(ByVal Equipment As String, Optional ByVal isManual As Boolean = True) As String
            AVPLib.Log.coreLogger.Info("Enter OpenRoughValve")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objRough As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Equipment)
                Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Equipment)
                If (objRough Is Nothing) Then
                    AVPLib.Log.avpLogger.Error("Rough is not setup")
                Else

                    If (objRough.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        strErrMsg = AVPLib.Utils.chamberID2ChamberName(Equipment) & MECHANICAL_PUMP_CG_DISCONNECTED
                    End If

                    If (Not objRough.CheckOpenValveCondition(Equipment) AndAlso _
                    objTransferModule.OverideModeStatus = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        strErrMsg = ConstEnum.STR_ROUGH_PUMP_IN_USE & objRough.GetEquipmentIsUsing()                      
                    ElseIf (objRough.MakeRoughLineInUseNoWait(Equipment, isManual)) Then
                        Dim objTMRoughValve As RoughValveDriver = DriverManager.GetDriver(DriverConst.CassettesModule_Rough)
                        If (objTMRoughValve IsNot Nothing) Then
                            If objTMRoughValve.eCommunicationType = CommType.DeviceNet AndAlso Not objTMRoughValve.IsDeviceActive() Then
                                strErrMsg = "TM Can't Open Rough Valve Due To Solenoid 2 Is Not Online."
                                Exit Try
                            End If

                            If (Not objTMRoughValve.OpenRoughValve()) Then
                                strErrMsg = "Open Rough Valve Failed"
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenRoughValve")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Close rough valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function CloseRoughValve(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseRoughValve")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objTMRoughValve As RoughValveDriver = DriverManager.GetDriver(DriverConst.CassettesModule_Rough)
                If (objTMRoughValve IsNot Nothing) Then
                    If objTMRoughValve.eCommunicationType = CommType.DeviceNet AndAlso Not objTMRoughValve.IsDeviceActive() Then
                        strErrMsg = "TM Can't Close Rough Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objTMRoughValve.CloseRoughValve()) Then
                        strErrMsg = "Close Rough Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseRoughValve")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Close vent valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function CloseVentValve(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseVentValve")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objTMVentValve As VentValveDriver = DriverManager.GetDriver(DriverConst.CassettesModule_Vent)
                If (objTMVentValve IsNot Nothing) Then
                    If objTMVentValve.eCommunicationType = CommType.DeviceNet AndAlso Not objTMVentValve.IsDeviceActive() Then
                        strErrMsg = "TM Can't Close Vent Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objTMVentValve.CloseVentValve()) Then
                        strErrMsg = "Close Vent Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseVentValve")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Open vent valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function OpenVentValve(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter OpenVentValve")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objTMVentValve As VentValveDriver = DriverManager.GetDriver(DriverConst.CassettesModule_Vent)
                If (objTMVentValve IsNot Nothing) Then
                    If objTMVentValve.eCommunicationType = CommType.DeviceNet AndAlso Not objTMVentValve.IsDeviceActive() Then
                        strErrMsg = "TM Can't Open Vent Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objTMVentValve.OpenVentValve()) Then
                        strErrMsg = "Open Vent Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenVentValve")
            Return strErrMsg
        End Function

        Public Shared Function CloseTMTurboForeLineValve(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseTMTurboForeLineValve")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objTMTurboValve As TurboForeLineValveDriver = Nothing

                objTMTurboValve = DriverManager.GetDriver(DriverConst.CassettesModule_TurboForelineValve)


                If (objTMTurboValve IsNot Nothing) Then
                    If objTMTurboValve.eCommunicationType = CommType.DeviceNet AndAlso Not objTMTurboValve.IsDeviceActive() Then
                        strErrMsg = "TM Can't Close Turbo ForeLine Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objTMTurboValve.CloseTurboForeLineValve()) Then
                        strErrMsg = "Close TM Turbo ForeLine Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseTMTurboForeLineValve")
            Return strErrMsg
        End Function

        Public Shared Function OpenTMTurboForeLineValve(ByVal Equipment As String, Optional ByVal isCheckSafety As Boolean = False, Optional ByVal isManual As Boolean = False) As String
            AVPLib.Log.coreLogger.Info("Enter OpenTMTurboForeLineValve")
            Dim strErrMsg As String = String.Empty
            Try
                If (isCheckSafety) Then
                    Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Equipment)
                    If roughpumpMachine IsNot Nothing AndAlso (Not roughpumpMachine.CheckOpenValveCondition(Equipment)) Then
                        strErrMsg = ConstEnum.STR_ROUGH_PUMP_IN_USE & roughpumpMachine.GetEquipmentIsUsing()
                        'only show message when open valve by manual
                        If (isManual) Then
                            Exit Try
                        End If
                    End If

                    Dim obj_TM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Equipment)
                    If (obj_TM IsNot Nothing AndAlso obj_TM.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                        strErrMsg = "TM Rough Valve is Opened."
                        'Utils.Create_Core_MessageBox(strErrMsg)
                        Exit Try
                    End If

                    'Check not other turbo foreline valve is open
                    If Not (IsNotForelineValveOpened(Equipment, strErrMsg)) Then
                        ' if have other valve is opened
                        ' check all turbo  is on
                        If (Not IsAllTurboOn(Equipment, strErrMsg)) Then
                            Exit Try
                        Else
                            strErrMsg = String.Empty
                        End If
                    End If

                    '0001008: [Khoi Ha - 06/20/2012] - In this configuration. 
                    'Should not allow user to open LL soft or fast rough when TM foreline valve is
                    Dim isNeedCheckLLRough As Boolean = False
                    Dim objLoadlock As DataManagerment.LoadLock = Nothing
                    Dim LoadlockName As String = String.Empty

                    'IF LLA = ROUGH ONLY
                    If Not RobotConfigurationValues.LLA_HIVAC_INSTALLED Then
                        isNeedCheckLLRough = True
                        LoadlockName = ConstEnum.Equipments.LoadLockA.ToString
                    End If

                    If (isNeedCheckLLRough) Then
                        'Check Fast Rough
                        objLoadlock = DataManagerment.EquipmentManager.GetEquipment(LoadlockName)
                        If (objLoadlock IsNot Nothing AndAlso objLoadlock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            strErrMsg = objLoadlock.Name & " Fast Rough Valve is Opened."
                            Exit Try
                        End If

                        If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                            If (objLoadlock IsNot Nothing AndAlso objLoadlock.SlowRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                                strErrMsg = objLoadlock.Name & " Slow Rough Valve is Opened."
                                Exit Try
                            End If
                        End If
                    End If
                End If


                Dim objTMTurboValve As TurboForeLineValveDriver = Nothing

                objTMTurboValve = DriverManager.GetDriver(DriverConst.CassettesModule_TurboForelineValve)

                If (objTMTurboValve IsNot Nothing) Then
                    If objTMTurboValve.eCommunicationType = CommType.DeviceNet AndAlso Not objTMTurboValve.IsDeviceActive() Then
                        strErrMsg = "TM Can't Open Turbo ForeLine Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objTMTurboValve.OpenTurboForeLineValve()) Then
                        strErrMsg = "Open TM Turbo ForeLine Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenTMTurboForeLineValve")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2021-10-24</date>
        ''' </author>
        ''' <summary>
        ''' Check not Foreline valve open 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function IsNotForelineValveOpened(ByVal EquipmentName As String, ByRef ErrorMessage As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter IsNotForelineValveOpened")
            Dim blResult As Boolean = False
            Try
                Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(EquipmentName)
                If (roughpumpMachine IsNot Nothing) Then
                    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                        Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                        If (objTM IsNot Nothing AndAlso objTM.TurboForeLineValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            ErrorMessage = "TM Turbo Foreline valve is Opened."
                            Exit Try
                        End If
                    End If

                    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                        Dim objLoadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)
                        If (objLoadlock IsNot Nothing AndAlso objLoadlock.TurboForeLineValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            ErrorMessage = ConstEnum.Equipments.LoadLockA.ToString & " Turbo Foreline valve is Opened."
                            Exit Try
                        End If
                    End If
                End If

                blResult = True
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Enter IsNotForelineValveOpened")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2021-10-24</date>
        ''' </author>
        ''' <summary>
        ''' Check all turbo on
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function IsAllTurboOn(ByVal EquipmentName As String, ByRef ErrorMessage As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter IsAllTurboOn")
            Dim blResult As Boolean = False
            Try
                Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(EquipmentName)
                If (roughpumpMachine IsNot Nothing) Then
                    Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                        Dim objTMTurbo As DataManagerment.Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.TMPumpPackage.ToString)
                        If Not (objTMTurbo IsNot Nothing AndAlso ((objTMTurbo.TurboStatus AndAlso objTMTurbo.TurboUptoSpeed) OrElse objTM.TurboForelineCGRelay)) Then
                            ErrorMessage = "TM Foreline CG Relay Was Not On."
                            Exit Try
                        End If
                    End If

                    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                        Dim objLLATurbo As DataManagerment.Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAPumpPackage.ToString)
                        If objLLATurbo IsNot Nothing AndAlso objLLATurbo.TurboStatus AndAlso objLLATurbo.TurboUptoSpeed Then
                            If Not objTM.TurboForelineCGRelay = DataManagerment.Equipment.WorkingStatuses.On Then
                                ErrorMessage = "TM Foreline CG Relay Was Not On."
                                Exit Try
                            End If
                        ElseIf objLLATurbo IsNot Nothing Then
                            ErrorMessage = ConstEnum.Equipments.LoadLockA.ToString & " Foreline is Open."
                            Exit Try
                        End If
                    End If
                End If

                blResult = True
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Enter IsAllTurboOn")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2012-06-1</date>
        ''' </author>
        ''' <summary>
        ''' Turn On/Off Mechanical Pump
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function OpenCloseMechanicalPump(ByVal Equipment As String, ByVal RoughPumpName As String, ByVal blIsOpen As Boolean, Optional ByVal IsCheckSafety As Boolean = False) As String
            AVPLib.Log.coreLogger.Info("Enter OpenCloseMechanicalPump1")
            Dim strErrMsg As String = String.Empty
            Try

                If (IsCheckSafety AndAlso blIsOpen = False) Then
                    Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetEquipment(RoughPumpName)
                    If (roughpumpMachine IsNot Nothing) Then
                        If (roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                            Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                            If (objTM IsNot Nothing AndAlso objTM.TurboForeLineValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                                strErrMsg = "TM Turbo Foreline valve is Opened."
                                'Utils.Create_Core_MessageBox(strErrMsg)
                                Exit Try
                            End If

                            If (objTM IsNot Nothing AndAlso objTM.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                                strErrMsg = "TM Rough valve is Opened."
                                'Utils.Create_Core_MessageBox(strErrMsg)
                                Exit Try
                            End If
                        End If

                        If (roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                            Dim objLoadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)
                            If (objLoadlock IsNot Nothing AndAlso objLoadlock.TurboForeLineValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                                strErrMsg = ConstEnum.Equipments.LoadLockA.ToString & " Turbo Foreline valve is Opened."
                                'Utils.Create_Core_MessageBox(strErrMsg)
                                Exit Try
                            End If

                            If (objLoadlock IsNot Nothing AndAlso objLoadlock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                                strErrMsg = ConstEnum.Equipments.LoadLockA.ToString & "Fast Rough valve is Opened."
                                'Utils.Create_Core_MessageBox(strErrMsg)
                                Exit Try
                            End If

                            If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                                If (objLoadlock IsNot Nothing AndAlso objLoadlock.SlowRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                                    strErrMsg = ConstEnum.Equipments.LoadLockA.ToString & "Slow Rough valve is Opened."
                                    'Utils.Create_Core_MessageBox(strErrMsg)
                                    Exit Try
                                End If
                            End If

                        End If
                    End If
                End If
                Dim PumpStatus As String = IIf(RoughPumpName = ConstEnum.Equipments.RoughPumpMachine1.ToString, "RoughPump1Status", "RoughPump2Status")
                Dim strMessage As String = Equipment + "." + PumpStatus
                strErrMsg = String.Format(ContainerData.GetMessageText("KepserverError"), strMessage)

                'Return Utils.WriteCommandKepServer(strMessage, blIsOpen)
                Dim objRSTiDriver As Driver.AdapterDriver = Driver.DriverManager.GetDriver(strMessage)
                If (objRSTiDriver IsNot Nothing) Then
                    If blIsOpen Then
                        strErrMsg = IIf(objRSTiDriver.TurnBitOn(strMessage), String.Empty, "Turn On " & PumpStatus & " Failed.")
                    Else
                        strErrMsg = IIf(objRSTiDriver.TurnBitOff(strMessage), String.Empty, "Turn Off " & PumpStatus & " Failed.")
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenCloseMechanicalPump1")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Tinh Le  </name>
        '''    	<date> 2023-19-04 </date>
        ''' </author>
        ''' <summary>
        ''' WaitAndTurnOnMechanicalPumpSerial
        ''' </summary>
        Public Shared Function TurnOnMechanicalPumpSerial(ByVal RoughPumpName As String) As String
            Dim strErrMsg As String = String.Empty
            Try
                If RoughPumpName = Equipments.RoughPumpMachine1.ToString AndAlso RobotConfigurationValues.MPUMP1_SERIAL_VISIBLE OrElse _
                                            RoughPumpName = Equipments.RoughPumpMachine2.ToString AndAlso RobotConfigurationValues.MPUMP2_SERIAL_VISIBLE Then
                    If Not MechanicalPumpUtility.TurnPumpOn(RoughPumpName) Then
                        strErrMsg = "Failed To Turn On " & RoughPumpName & "."
                    End If
                    Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetEquipment(RoughPumpName)
                    roughpumpMachine.WaitingMPOn = String.Empty
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return strErrMsg
        End Function
        Public Shared Function Turn_Process_Complete_Chime(ByVal IsTurnOn As Boolean) As Boolean
            Dim blResult As Boolean = True
            Try
                If AVPLib.ContainerDAO.ProcessChimeInstalled Then
                    Dim strMessage As String = ConstEnum.Equipments.CassettesModule.ToString + "." + "Process_Complete_Chime"
                    'blResult = (Utils.WriteCommandKepServer(strMessage, IsTurnOn) = String.Empty)
                    Dim objRSTiDriver As Driver.AdapterDriver = Driver.DriverManager.GetDriver(strMessage)
                    If (objRSTiDriver IsNot Nothing) Then
                        If IsTurnOn Then
                            blResult = objRSTiDriver.TurnBitOn(strMessage)
                        Else
                            blResult = objRSTiDriver.TurnBitOff(strMessage)
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                blResult = False
            End Try
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Van Le  </name>
        '''    	<date> 2014-09-04 </date>
        ''' </author>
        ''' <summary>
        ''' SetConvertionGaugePressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function SetConvertionGaugePressure(ByVal Equipment As String, ByVal strCmd As String) As String
            AVPLib.Log.coreLogger.Info("Enter SetConvertionGaugePressure")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objCGPressure As CGDriver = DriverManager.GetDriver(Equipment & "." & ConstEnum.CG)
                If objCGPressure IsNot Nothing Then
                    If (Not objCGPressure.SetValue(strCmd)) Then
                        strErrMsg = "Set CG Pressure Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetConvertionGaugePressure")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2014-09-08 </date>
        ''' </author>
        ''' <summary>
        ''' SetMechanicalPumpCGPressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function SetTurboForelineCGPressure(ByVal Equipment As String, ByVal strCmd As String) As String
            AVPLib.Log.coreLogger.Info("Enter SetTurboForelineCGPressure")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objTurbo As TurboForeLineDriver = DriverManager.GetDriver(Equipment & "." & "TurboForelineCG")

                If objTurbo IsNot Nothing Then
                    If (Not objTurbo.SetValue(strCmd)) Then
                        strErrMsg = "Set" & Equipment & " Turbo Foreline CG Pressure Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetTurboForelineCGPressure")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2014-09-08 </date>
        ''' </author>
        ''' <summary>
        ''' SetMechanicalPumpCGPressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function SetMechanicalPumpCGPressure(ByVal RoughPumpName As String, ByVal strCmd As String) As String
            AVPLib.Log.coreLogger.Info("Enter SetMechanicalPumpCGPressure")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objMechanicalPumpCG As MPumpCGDriver = Nothing
                Select Case (RoughPumpName)
                    Case ConstEnum.Equipments.RoughPumpMachine1.ToString
                        objMechanicalPumpCG = DriverManager.GetDriver("RoughPumpMachine1.CG")
                    Case ConstEnum.Equipments.RoughPumpMachine2.ToString
                        objMechanicalPumpCG = DriverManager.GetDriver("RoughPumpMachine2.CG")
                End Select

                If objMechanicalPumpCG IsNot Nothing Then
                    If (Not objMechanicalPumpCG.SetValue(strCmd)) Then
                        strErrMsg = "Set " & RoughPumpName & "  CG Pressure Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetMechanicalPumpCGPressure")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name>Tinh Le</name>
        '''    	<date> 2018-11-23 </date>
        ''' </author>
        ''' <summary>
        ''' SetMechanicalPumpCGTripPoint
        ''' </summary>
        Public Shared Function SetMechanicalPumpCGTripPoint(ByVal strCmd As String) As String
            AVPLib.Log.coreLogger.Info("Enter SetMechanicalPumpCGTripPoint")
            Dim strErrMsg As String = String.Empty
            Try
                If AVPLib.RobotConfigurationValues.ROUGH_PUMP1_INSTALLED Then
                    Dim objCGDriveMP1 As MPumpCGDriver = DriverManager.GetDriver(RoughPumpMachine1_CG)
                    If objCGDriveMP1 IsNot Nothing AndAlso objCGDriveMP1.eCommunicationType = CommType.DeviceNet Then
                        If (Not objCGDriveMP1.SetValue(strCmd)) Then
                            strErrMsg = "Set Mechanical Pump 1 CG Trip Point Failed."
                        End If
                    End If
                End If

                If AVPLib.RobotConfigurationValues.ROUGH_PUMP2_INSTALLED Then
                    Dim objCGDriveMP2 As MPumpCGDriver = DriverManager.GetDriver(RoughPumpMachine2_CG)
                    If objCGDriveMP2 IsNot Nothing AndAlso objCGDriveMP2.eCommunicationType = CommType.DeviceNet Then
                        If (Not objCGDriveMP2.SetValue(strCmd)) Then
                            If strErrMsg <> String.Empty Then
                                strErrMsg = "Set Mechanical Pump 1 and Mechanical Pump 2 CG Trip Point Failed."
                            Else
                                strErrMsg = "Set Mechanical Pump 2 CG Trip Point Failed."
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetMechanicalPumpCGTripPoint")
            Return strErrMsg
        End Function
#End Region
        Public Shared Function OpenTMTurboForeLineValveNoWait(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter OpenTMTurboForeLineValve")
            Dim strErrMsg As String = String.Empty
            Try
                Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Equipment)
                If (roughpumpMachine IsNot Nothing) Then
                    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                        Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                        If (objTM IsNot Nothing AndAlso objTM.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            strErrMsg = " TM Rough valve is Opened."
                            Exit Try
                        End If
                    End If

                    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                        Dim objLoadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)

                        If objLoadlock.IsRoughInstalled Then
                            If (objLoadlock IsNot Nothing AndAlso objLoadlock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                                strErrMsg = ConstEnum.Equipments.LoadLockA.ToString & " Fast Rough valve is Opened."
                                Exit Try
                            End If

                            If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                                If (objLoadlock IsNot Nothing AndAlso objLoadlock.SlowRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                                    strErrMsg = ConstEnum.Equipments.LoadLockA.ToString & " Slow Rough valve is Opened."
                                    Exit Try
                                End If
                            End If
                        End If
                    End If
                End If

                Dim objTMTurboValve As TurboForeLineValveDriver = Nothing

                objTMTurboValve = DriverManager.GetDriver(DriverConst.CassettesModule_TurboForelineValve)

                If (objTMTurboValve IsNot Nothing) Then
                    If objTMTurboValve.eCommunicationType = CommType.DeviceNet AndAlso Not objTMTurboValve.IsDeviceActive() Then
                        strErrMsg = "TM Can't Open Turbo ForeLine Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objTMTurboValve.OpenTurboForeLineValve()) Then
                        strErrMsg = "Open TM Turbo ForeLine Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenTMTurboForeLineValve")
            Return strErrMsg
        End Function

        Public Shared Function OpenRoughValveNoWait(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter OpenRoughValveNoWait")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objRough As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Equipment)
                Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(Equipment)
                If (objRough Is Nothing) Then
                    AVPLib.Log.avpLogger.Error("Rough is not setup")
                Else

                    If (objRough.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        strErrMsg = AVPLib.Utils.chamberID2ChamberName(Equipment) & MECHANICAL_PUMP_CG_DISCONNECTED
                    End If

                    If (objRough.IsUsed(ConstEnum.Equipments.LoadLockA.ToString) AndAlso RobotConfigurationValues.LLA_TURBO_VISIBLE) Then
                        Dim objLL As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)

                        If (objLL IsNot Nothing AndAlso objLL.TurboForeLineValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Foreline valve of " & Utils.chamberID2ChamberName(objLL.Name))
                            Exit Try
                        End If
                    End If

                    If (objRough.IsUsed(ConstEnum.Equipments.CassettesModule.ToString) AndAlso RobotConfigurationValues.TMTURBO_VISIBLE) Then
                        Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)

                        If (objTM IsNot Nothing AndAlso objTM.TurboForeLineValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Foreline valve of " & AVPLib.Utils.chamberID2ChamberName(objTM.Name))
                            Exit Try
                        End If
                    End If

                    If (objRough.MakeRoughLineInUseNoWait(Equipment, False)) Then
                        Dim objTMRoughValve As RoughValveDriver = DriverManager.GetDriver(DriverConst.CassettesModule_Rough)
                        If (objTMRoughValve IsNot Nothing) Then
                            If objTMRoughValve.eCommunicationType = CommType.DeviceNet AndAlso Not objTMRoughValve.IsDeviceActive() Then
                                strErrMsg = "TM Can't Open Rough Valve Due To Solenoid 2 Is Not Online."
                                Exit Try
                            End If

                            If (Not objTMRoughValve.OpenRoughValve()) Then
                                strErrMsg = "Open Rough Valve Failed"
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenRoughValveNoWait")
            Return strErrMsg
        End Function
    End Class
End Namespace
