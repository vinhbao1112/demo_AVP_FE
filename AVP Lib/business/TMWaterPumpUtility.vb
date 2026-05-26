Imports AVPLib.Communication.TerminalDriver
Imports AVPLib.ConstEnum
Namespace Business
    Public Class WaterPumpUtility
#Region "Public methods"
        Public Shared Sub StartFastRegen(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter StartRegen")
            Try
                Dim strMessage As String = Name + "." + "$N2n"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRegen")
        End Sub
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
                If (objChamber1 IsNot Nothing) AndAlso _
                    (Not (objTransferModule.SplitValve2Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then
                    If (bIsRobotRetracted) Then
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
                If (objChamber2 IsNot Nothing) AndAlso _
                   (Not (objTransferModule.SplitValve3Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then
                    If (bIsRobotRetracted) Then
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
                If (objChamber3 IsNot Nothing) AndAlso _
                    (Not (objTransferModule.SplitValve4Status = DataManagerment.Equipment.WorkingStatuses.Off)) Then
                    If (bIsRobotRetracted) Then
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
                If (objLoadLockA IsNot Nothing) AndAlso _
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
                If (objLoadLockA IsNot Nothing) And (objTransferModule.SplitValve1Status <> DataManagerment.Equipment.WorkingStatuses.Off) Then ''LLA
                    ChamberUtility.UnknownSlitValve(Equipments.LoadLockA.ToString())
                    strErrMsg = String.Format(ContainerData.GetMessageText("RobotLLASlitValveMustBeClosed"), AVPLib.ConstEnum.TM_STR)
                End If
                If (objChamber1 IsNot Nothing) And (objTransferModule.SplitValve2Status <> DataManagerment.Equipment.WorkingStatuses.Off) Then
                    ChamberUtility.UnknownSlitValve(Equipments.Chamber1.ToString())
                    If strErrMsg = String.Empty Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("EquipmentSlitValveStatusClosed"), _
                                                             AVPLib.RobotConfigurationValues.CHAMBER1_NAME)
                    End If
                End If
                If (objChamber2 IsNot Nothing) And (objTransferModule.SplitValve3Status <> DataManagerment.Equipment.WorkingStatuses.Off) Then
                    ChamberUtility.UnknownSlitValve(Equipments.Chamber2.ToString())
                    If strErrMsg = String.Empty Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("EquipmentSlitValveStatusClosed"), _
                                                             AVPLib.RobotConfigurationValues.CHAMBER2_NAME)
                    End If
                End If
                If (objChamber3 IsNot Nothing) And (objTransferModule.SplitValve4Status <> DataManagerment.Equipment.WorkingStatuses.Off) Then
                    ChamberUtility.UnknownSlitValve(Equipments.Chamber3.ToString())
                    If strErrMsg = String.Empty Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("EquipmentSlitValveStatusClosed"), _
                                                             AVPLib.RobotConfigurationValues.CHAMBER3_NAME)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseAllSlitValve")
            Return strErrMsg
        End Function
        Public Shared Function TurnOffIG(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseTurnTMIG")
            Dim strErrMsg As String = String.Empty
            Try
                Dim strMessage As String = Equipment + ".Ion"
                strErrMsg = String.Format(ContainerData.GetMessageText("KepserverError"), strMessage)

                Return Utils.WriteCommandKepServer(strMessage, False)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseTurnTMIG")
            Return strErrMsg
        End Function
        Public Shared Function TurnOnIG(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter OpenTurnTMIG")
            Dim strErrMsg As String = String.Empty

            Try
                Dim strMessage As String = Equipment + ".Ion"
                strErrMsg = String.Format(ContainerData.GetMessageText("KepserverError"), strMessage)

                Return Utils.WriteCommandKepServer(strMessage, True)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenTurnTMIG")
            Return strErrMsg
        End Function
        'Public Shared Function CloseHiVacValve(ByVal Equipment As String) As String
        '    AVPLib.Log.coreLogger.Info("Enter CloseHiVacValve")
        '    Dim strErrMsg As String = String.Empty
        '    Try
        '        Dim strMessage As String = Equipment + "." + "TMHiVac"
        '        strErrMsg = String.Format(ContainerData.GetMessageText("KepserverError"), strMessage)

        '        Return Utils.WriteCommandKepServer(strMessage, False)
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    AVPLib.Log.coreLogger.Info("Leave CloseHiVacValve")
        '    Return strErrMsg
        'End Function
        'Public Shared Function OpenHiVacValve(ByVal Equipment As String) As String
        '    AVPLib.Log.coreLogger.Info("Enter OpenHiVacValve")
        '    Dim strErrMsg As String = String.Empty
        '    Try
        '        'check condition before opening hivac
        '        Dim transferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
        '        Dim strCheckResult = transferModule.checkCondition2OpenTMHiVac()
        '        If Not (String.IsNullOrEmpty(strCheckResult)) Then
        '            Return strCheckResult
        '        End If

        '        Dim objCryo As DataManagerment.TMCryo = Nothing
        '        objCryo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.TMCryo.ToString())
        '        If (objCryo IsNot Nothing) AndAlso (objCryo.IsCommunicating = False) Then
        '            strErrMsg = "Can not open TM Hivac because of Cryo TimeOut."
        '            Return strErrMsg
        '        End If

        '        Dim strMessage As String = Equipment + "." + "TMHiVac"
        '        strErrMsg = String.Format(ContainerData.GetMessageText("KepserverError"), strMessage)

        '        Return Utils.WriteCommandKepServer(strMessage, True)
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    AVPLib.Log.coreLogger.Info("Leave OpenHiVacValve")
        '    Return strErrMsg
        'End Function
        'Public Shared Function OpenRoughValve(ByVal Equipment As String) As String
        '    AVPLib.Log.coreLogger.Info("Enter OpenRoughValve")
        '    Dim strErrMsg As String = String.Empty
        '    Try
        '        Dim strMessage As String = Equipment + "." + "Rough"
        '        strErrMsg = String.Format(ContainerData.GetMessageText("KepserverError"), strMessage)

        '        Return Utils.WriteCommandKepServer(strMessage, True)
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    AVPLib.Log.coreLogger.Info("Leave OpenRoughValve")
        '    Return strErrMsg
        'End Function
        'Public Shared Function CloseRoughValve(ByVal Equipment As String) As String
        '    AVPLib.Log.coreLogger.Info("Enter CloseRoughValve")
        '    Dim strErrMsg As String = String.Empty
        '    Try
        '        Dim strMessage As String = Equipment + "." + "Rough"
        '        strErrMsg = String.Format(ContainerData.GetMessageText("KepserverError"), strMessage)

        '        Return Utils.WriteCommandKepServer(strMessage, False)
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    AVPLib.Log.coreLogger.Info("Leave CloseRoughValve")
        '    Return strErrMsg
        'End Function
        'Public Shared Function CloseVentValve(ByVal Equipment As String) As String
        '    AVPLib.Log.coreLogger.Info("Enter CloseVentValve")
        '    Dim strErrMsg As String = String.Empty
        '    Try
        '        Dim strMessage As String = Equipment + "." + "Vent"
        '        strErrMsg = String.Format(ContainerData.GetMessageText("KepserverError"), strMessage)

        '        Return Utils.WriteCommandKepServer(strMessage, False)
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    AVPLib.Log.coreLogger.Info("Leave CloseVentValve")
        '    Return strErrMsg
        'End Function
        'Public Shared Function OpenVentValve(ByVal Equipment As String) As String
        '    AVPLib.Log.coreLogger.Info("Enter OpenVentValve")
        '    Dim strErrMsg As String = String.Empty
        '    Try
        '        Dim strMessage As String = Equipment + "." + "Vent"
        '        strErrMsg = String.Format(ContainerData.GetMessageText("KepserverError"), strMessage)

        '        Return Utils.WriteCommandKepServer(strMessage, True)
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    AVPLib.Log.coreLogger.Info("Leave OpenVentValve")
        '    Return strErrMsg
        'End Function
#End Region
    End Class
End Namespace

