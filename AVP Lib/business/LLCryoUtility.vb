Imports AVPLib.Communication.TerminalDriver
Imports AVPLib.Driver
Imports AVPLib.ConstEnum
Namespace Business
    Public Class LLCryoUtility
        Const MAX_CRYO_PARAM As Integer = 5
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
        Public Shared Sub GetFirstStageTemperature(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter GetFirstStageTemperature")
            Try
                Dim strMessage As String = Name + "." + "$J;"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetFirstStageTemperature")
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
        ''' Get second stage temperature
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Sub GetSecondStageTemperature(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter GetSecondStageTemperature")
            Try
                Dim strMessage As String = Name + "." + "$K:"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetSecondStageTemperature")
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
        Public Shared Sub GetPumpStatus(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter GetPumpStatus")
            Try
                Dim strMessage As String = Name + "." + "$A?2"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetPumpStatus")
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
        Public Shared Sub GetRegenStatus(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter GetRegenStatus")
            Try
                Dim strMessage As String = Name + "." + "$O>"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRegenStatus")
        End Sub

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
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' OpenLLSlowVent
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function OpenLLSlowVent(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter OpenLLSlowVent")
            Dim strErrMsg As String = String.Empty

            Try
                If (RobotConfigurationValues.LL_SLOW_VENT_INSTALLED) Then
                    Dim objLLVentValve As VentValveDriver = Nothing

                    If (Equipment = ConstEnum.LoadLockA_STR) Then
                        objLLVentValve = DriverManager.GetDriver(DriverConst.LoadLockA_LLSlowVent)
                    End If

                    If (objLLVentValve IsNot Nothing) Then
                        If objLLVentValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLVentValve.IsDeviceActive() Then
                            strErrMsg = Equipment & " Can't Open Slow Vent Valve Due To Solenoid 2 Is Not Online."
                            Exit Try
                        End If

                        If (Not objLLVentValve.OpenVentValve()) Then
                            strErrMsg = "Open Loadlock Slow Vent Valve Failed."
                        End If
                    End If
                End If
                
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave OpenLLSlowVent")
            Return strErrMsg

        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' CloseLLSlowVent
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CloseLLSlowVent(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseLLSlowVent")
            Dim strErrMsg As String = String.Empty
            Try
                If (RobotConfigurationValues.LL_SLOW_VENT_INSTALLED) Then
                    Dim objLLVentValve As VentValveDriver = Nothing

                    If (Equipment = ConstEnum.LoadLockA_STR) Then
                        objLLVentValve = DriverManager.GetDriver(DriverConst.LoadLockA_LLSlowVent)
                    End If

                    If (objLLVentValve IsNot Nothing) Then
                        If objLLVentValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLVentValve.IsDeviceActive() Then
                            strErrMsg = Equipment & " Can't Close Slow Vent Valve Due To Solenoid 2 Is Not Online."
                            Exit Try
                        End If

                        If (Not objLLVentValve.CloseVentValve()) Then
                            strErrMsg = "Close Loadlock Slow Vent Valve Failed."
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseLLSlowVent")
            Return strErrMsg

        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' OpenLLFastVent
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function OpenLLFastVent(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter OpenLLFastVent")
            Dim strErrMsg As String = String.Empty

            Try
                Dim objLLVentValve As VentValveDriver = Nothing

                If (Equipment = ConstEnum.LoadLockA_STR) Then
                    objLLVentValve = DriverManager.GetDriver(DriverConst.LoadLockA_LLFastVent)
                End If

                If (objLLVentValve IsNot Nothing) Then
                    If objLLVentValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLVentValve.IsDeviceActive() Then
                        strErrMsg = Equipment & " Can't Open Fast Vent Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objLLVentValve.OpenVentValve()) Then
                        strErrMsg = "Open Loadlock Fast Vent Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenLLFastVent")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' CloseLLFastVent
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CloseLLFastVent(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseLLFastVent")

            Dim strErrMsg As String = String.Empty
            Try
                Dim objLLVentValve As VentValveDriver = Nothing

                If (Equipment = ConstEnum.LoadLockA_STR) Then
                    objLLVentValve = DriverManager.GetDriver(DriverConst.LoadLockA_LLFastVent)
                End If

                If (objLLVentValve IsNot Nothing) Then
                    If objLLVentValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLVentValve.IsDeviceActive() Then
                        strErrMsg = Equipment & " Can't Close Fast Vent Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objLLVentValve.CloseVentValve()) Then
                        strErrMsg = "Close Loadlock Fast Vent Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseLLFastVent")

            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-14</date>
        ''' </author>
        ''' <summary>
        ''' OpenLLSlowRough
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function OpenLLSlowRough(ByVal Equipment As String, Optional ByVal isManual As Boolean = True) As String
            AVPLib.Log.coreLogger.Info("Enter OpenLLSlowRough")
            Dim strErrMsg As String = String.Empty
            Try
                If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                    Dim objRough As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Equipment)
                    Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(Equipment)
                    If (objRough Is Nothing) Then
                        AVPLib.Log.avpLogger.Error("Rough is not setup")
                    Else
                        If (objRough.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                            strErrMsg = AVPLib.Utils.chamberID2ChamberName(Equipment) & ConstEnum.MECHANICAL_PUMP_CG_DISCONNECTED
                        End If

                        If (Not objRough.CheckOpenValveCondition(Equipment)) AndAlso _
                        objLoadLock.OverideModeStatus = DataManagerment.Equipment.WorkingStatuses.Off Then
                            strErrMsg = ConstEnum.STR_ROUGH_PUMP_IN_USE & objRough.GetEquipmentIsUsing()                   
                        ElseIf (objRough.MakeRoughLineInUseNoWait(Equipment, isManual)) Then
                            Dim objLLRoughValve As RoughValveDriver = Nothing

                            If (Equipment = ConstEnum.LoadLockA_STR) Then
                                objLLRoughValve = DriverManager.GetDriver(DriverConst.LoadLockA_LLSlowRough)
                            End If

                            If (objLLRoughValve IsNot Nothing) Then
                                If objLLRoughValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLRoughValve.IsDeviceActive() Then
                                    strErrMsg = Equipment & " Can't Open Slow Rough Valve Due To Solenoid 2 Is Not Online."
                                    Exit Try
                                End If

                                If (Not objLLRoughValve.OpenRoughValve()) Then
                                    strErrMsg = "Open Loadlock Slow Rough Valve Failed."
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenLLSlowRough")

            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' CloseLLSlowRough
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CloseLLSlowRough(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseLLSlowRough")
            Dim strErrMsg As String = String.Empty
            Try
                If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                    Dim objLLRoughValve As RoughValveDriver = Nothing

                    If (Equipment = ConstEnum.LoadLockA_STR) Then
                        objLLRoughValve = DriverManager.GetDriver(DriverConst.LoadLockA_LLSlowRough)
                    End If

                    If (objLLRoughValve IsNot Nothing) Then
                        If objLLRoughValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLRoughValve.IsDeviceActive() Then
                            strErrMsg = Equipment & " Can't Close Slow Rough Valve Due To Solenoid 2 Is Not Online."
                            Exit Try
                        End If

                        If (Not objLLRoughValve.CloseRoughValve()) Then
                            strErrMsg = "Close Loadlock Slow Rough Valve Failed."
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseLLSlowRough")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' OpenLLFastRough
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function OpenLLFastRough(ByVal Equipment As String, Optional ByVal isManual As Boolean = True, Optional ByVal IsCheckSafety As Boolean = True) As String
            AVPLib.Log.coreLogger.Info("Enter OpenLLFastRough")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objRough As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Equipment)
                Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(Equipment)
                If (objRough Is Nothing) Then
                    AVPLib.Log.avpLogger.Error("Rough is not setup")
                Else

                    If (objRough.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        strErrMsg = AVPLib.Utils.chamberID2ChamberName(Equipment) & ConstEnum.MECHANICAL_PUMP_CG_DISCONNECTED
                    End If

                    If (IsCheckSafety AndAlso Not objRough.CheckOpenValveCondition(Equipment) AndAlso _
                    objLoadLock.OverideModeStatus = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        strErrMsg = ConstEnum.STR_ROUGH_PUMP_IN_USE & objRough.GetEquipmentIsUsing()                       
                    ElseIf (objRough.MakeRoughLineInUseNoWait(Equipment, isManual)) Then
                        Dim objLLRoughValve As RoughValveDriver = Nothing

                        If (Equipment = ConstEnum.LoadLockA_STR) Then
                            objLLRoughValve = DriverManager.GetDriver(DriverConst.LoadLockA_LLFastRough)
                        End If

                        If (objLLRoughValve IsNot Nothing) Then
                            If objLLRoughValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLRoughValve.IsDeviceActive() Then
                                strErrMsg = Equipment & " Can't Open Fast Rough Valve Due To Solenoid 2 Is Not Online."
                                Exit Try
                            End If

                            If (Not objLLRoughValve.OpenRoughValve()) Then
                                strErrMsg = "Open Loadlock Fast Rough Valve Failed."
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenLLFastRough")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Only Use open rough when pumpdown with rough only completed
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function OpenLLFastRoughNoSafety(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter OpenLLFastRough")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objRough As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Equipment)
                Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(Equipment)
                If (objRough Is Nothing) Then
                    AVPLib.Log.avpLogger.Error("Rough is not setup")
                Else

                    If (objRough.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        strErrMsg = AVPLib.Utils.chamberID2ChamberName(Equipment) & ConstEnum.MECHANICAL_PUMP_CG_DISCONNECTED
                    End If

                    If (objRough.MakeRoughLineInUseNoWait(Equipment, False)) Then
                        Dim objLLRoughValve As RoughValveDriver = Nothing

                        If (Equipment = ConstEnum.LoadLockA_STR) Then
                            objLLRoughValve = DriverManager.GetDriver(DriverConst.LoadLockA_LLFastRough)
                        End If

                        'KHOI HA, check loadlock door before open LL rough valve
                        If Not (IsLLdoorClosed(Equipment)) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("DoorWasNotClose"), Equipment)
                            Exit Try
                        End If

                        If (objLLRoughValve IsNot Nothing) Then
                            If (Not objLLRoughValve.OpenRoughValve()) Then
                                strErrMsg = "Open Loadlock Fast Rough Valve Failed."
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenLLFastRough")
            Return strErrMsg
        End Function
        Public Shared Function IsLLdoorClosed(ByVal EquipmentName As String) As Boolean
            Dim blResult As Boolean = False
            Try
                Dim objLLElevator As DataManagerment.LLElevator = Nothing
                If EquipmentName = AVPLib.ConstEnum.LoadLockA_STR Then
                    objLLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString)
                End If

                'only check and alarm
                If (Not objLLElevator.DCStatus = DataManagerment.Equipment.WorkingStatuses.Off) Then
                    Exit Try
                Else
                    blResult = True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' CloseLLFastRough
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CloseLLFastRough(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseLLFastRough")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objLLRoughValve As RoughValveDriver = Nothing

                If (Equipment = ConstEnum.LoadLockA_STR) Then
                    objLLRoughValve = DriverManager.GetDriver(DriverConst.LoadLockA_LLFastRough)
                End If

                If (objLLRoughValve IsNot Nothing) Then
                    If objLLRoughValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLRoughValve.IsDeviceActive() Then
                        strErrMsg = Equipment & " Can't Close Fast Rough Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objLLRoughValve.CloseRoughValve()) Then
                        strErrMsg = "Close Loadlock Fast Rough Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseLLFastRough")
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
        Private Shared Function IsLLIGDisconnected(ByVal sEquipment As String, Optional ByRef ErrorMsg As String = "") As Boolean
            Dim blResult As Boolean = False
            Dim objLL As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(sEquipment)
            If (objLL IsNot Nothing AndAlso objLL.IG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                ErrorMsg = Utils.chamberID2ChamberName(sEquipment) & ConstEnum.IG_DISCONNECTED
                blResult = True
            Else
                ErrorMsg = String.Empty
                blResult = False
            End If
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-07-05 </date>
        ''' </author>
        ''' <summary>
        ''' Switch IG Filament 1
        ''' </summary>
        Public Shared Function SwitchIGFilament1(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter SwitchIGFilament1")
            Dim strErrMsg As String = String.Empty
            Try

                If (IsLLIGDisconnected(Equipment, strErrMsg)) Then
                    Exit Try
                End If

                Dim objLLIG As IGDriver = DriverManager.GetDriver(DriverConst.LoadLockA_IonGauge)

                If (objLLIG IsNot Nothing) Then
                    If (Not objLLIG.SwitchIGFilament1()) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("SwitchIGFilamentFailed"), _
                                    "1 Loadlock IG")
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
        Public Shared Function SwitchIGFilament2(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter SwitchIGFilament2")
            Dim strErrMsg As String = String.Empty
            Try

                If (IsLLIGDisconnected(Equipment, strErrMsg)) Then
                    Exit Try
                End If

                Dim objLLIG As IGDriver = DriverManager.GetDriver(DriverConst.LoadLockA_IonGauge)

                If (objLLIG IsNot Nothing) Then
                    If (Not objLLIG.SwitchIGFilament2()) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("SwitchIGFilamentFailed"), _
                                    "2 Loadlock IG")
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SwitchIGFilament2")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' OpenLLbigcgIG
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function TurnOnIG(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter TurnOnIG")
            Dim strErrMsg As String = String.Empty
            Try

                If (IsLLIGDisconnected(Equipment, strErrMsg)) Then
                    Exit Try
                End If

                Dim objLLIG As IGDriver = Nothing

                If (Equipment = ConstEnum.LoadLockA_STR) Then
                    objLLIG = DriverManager.GetDriver(DriverConst.LoadLockA_IonGauge)
                End If

                If (objLLIG IsNot Nothing) Then
                    If (Not objLLIG.TurnOnIG()) Then
                        strErrMsg = "Turn On Loadlock IG Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOnIG")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' CloseLLbigcgIG
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function TurnOffIG(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter TurnOffIG")
            Dim strErrMsg As String = String.Empty
            Try

                If (IsLLIGDisconnected(Equipment, strErrMsg)) Then
                    Exit Try
                End If

                Dim objLLIG As IGDriver = Nothing

                If (Equipment = ConstEnum.LoadLockA_STR) Then
                    objLLIG = DriverManager.GetDriver(DriverConst.LoadLockA_IonGauge)
                End If

                If (objLLIG IsNot Nothing) Then
                    If (Not objLLIG.TurnOffIG()) Then
                        strErrMsg = "Turn Off Loadlock IG Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOffIG")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Truc Le</name>
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

                If (IsLLIGDisconnected(Equipment, strErrMsg)) Then
                    Exit Try
                End If

                Dim objLLIG As IGDriver = Nothing

                If (Equipment = ConstEnum.LoadLockA_STR) Then
                    objLLIG = DriverManager.GetDriver(DriverConst.LoadLockA_IonGauge)
                End If

                If (objLLIG IsNot Nothing) Then
                    ''Turn RO Off then RO On if mode is Kepware, only turn on IG Degas if mode is RSTi
                    If (Not objLLIG.TurnOnIGDegas()) Then
                        strErrMsg = "Turn On Loadlock IGDegas Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnIGDegas_On")
            Return strErrMsg
        End Function

        Public Shared Function TurnIGDegas_Off(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter TurnIGDegas_Off")
            Dim strErrMsg As String = String.Empty
            Try

                If (IsLLIGDisconnected(Equipment, strErrMsg)) Then
                    Exit Try
                End If

                Dim objLLIG As IGDriver = Nothing

                If (Equipment = ConstEnum.LoadLockA_STR) Then
                    objLLIG = DriverManager.GetDriver(DriverConst.LoadLockA_IonGauge)
                End If

                If (objLLIG IsNot Nothing) Then
                    If (Not objLLIG.TurnOnIGDegas()) Then
                        strErrMsg = "Turn Off Loadlock IGDegas Failed."
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
        ''' CloseLLFastRough
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CloseLLTurboForeLineValve(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseLLTurboForeLineValve")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objLLTurboValve As TurboForeLineValveDriver = Nothing

                If (Equipment = ConstEnum.LoadLockA_STR) Then
                    objLLTurboValve = DriverManager.GetDriver(DriverConst.LoadLockA_TurboForelineValve)
                End If

                If (objLLTurboValve IsNot Nothing) Then
                    If objLLTurboValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLTurboValve.IsDeviceActive() Then
                        strErrMsg = Equipment & " Can't Close Turbo ForeLine Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objLLTurboValve.CloseTurboForeLineValve()) Then
                        strErrMsg = "Close Load Lock Turbo ForeLine Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseLLTurboForeLineValve")
            Return strErrMsg
        End Function

        Public Shared Function OpenLLTurboForeLineValve(ByVal Equipment As String, Optional ByVal isCheckSafety As Boolean = False, Optional ByVal isManual As Boolean = False) As String
            AVPLib.Log.coreLogger.Info("Enter OpenLLTurboForeLineValve")
            Dim strErrMsg As String = String.Empty
            Try

                If (isCheckSafety) Then

                    Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Equipment)
                    If (roughpumpMachine IsNot Nothing) Then
                        If Not roughpumpMachine.CheckOpenValveCondition(Equipment) Then
                            strErrMsg = ConstEnum.STR_ROUGH_PUMP_IN_USE & roughpumpMachine.GetEquipmentIsUsing()
                            'only show message when open valve by manual
                            If (isManual) Then
                                Exit Try
                            End If
                        End If

                        If (roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                            Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                            If (objTM IsNot Nothing AndAlso objTM.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                                strErrMsg = " TM Rough valve is Opened."
                                Exit Try
                            End If
                        End If

                        If (roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                            Dim objLoadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)
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

                End If

                Dim objLLTurboValve As TurboForeLineValveDriver = Nothing

                If (Equipment = ConstEnum.LoadLockA_STR) Then
                    objLLTurboValve = DriverManager.GetDriver(DriverConst.LoadLockA_TurboForelineValve)
                End If

                If (objLLTurboValve IsNot Nothing) Then
                    If objLLTurboValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLTurboValve.IsDeviceActive() Then
                        strErrMsg = Equipment & " Can't Open Turbo ForeLine Valve Due To Solenoid 2 Is Not Online."
                        Exit Try
                    End If

                    If (Not objLLTurboValve.OpenTurboForeLineValve()) Then
                        strErrMsg = "Open Load Lock Turbo ForeLine Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenLLTurboForeLineValve")
            Return strErrMsg
        End Function
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

        Private Shared Function IsAllTurboOn(ByVal EquipmentName As String, ByRef ErrorMessage As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter IsAllTurboOn")
            Dim blResult As Boolean = False
            Try
                Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(EquipmentName)
                Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)
                If (roughpumpMachine IsNot Nothing) Then
                    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                        Dim objTMTurbo As DataManagerment.Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.TMPumpPackage.ToString)
                        If objTMTurbo IsNot Nothing AndAlso objTMTurbo.TurboStatus AndAlso objTMTurbo.TurboUptoSpeed Then
                            If Not objLoadLock.TurboForelineCGRelay = DataManagerment.Equipment.WorkingStatuses.On Then
                                ErrorMessage = ConstEnum.Equipments.LoadLockA.ToString & " Foreline CG Relay Was Not On."
                                Exit Try
                            End If
                        ElseIf objTMTurbo IsNot Nothing Then
                            ErrorMessage = "TM Foreline is Open."
                            Exit Try
                        End If
                    End If

                    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                        Dim objLLATurbo As DataManagerment.Turbo = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAPumpPackage.ToString)
                        If Not (objLLATurbo IsNot Nothing AndAlso ((objLLATurbo.TurboStatus AndAlso objLLATurbo.TurboUptoSpeed) OrElse objLoadLock.TurboForelineCGRelay)) Then
                            ErrorMessage = ConstEnum.Equipments.LoadLockA.ToString & " Foreline CG Relay Was Not On."
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

        Public Shared Function OpenLLTurboForeLineValveNoWait(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter OpenLLTurboForeLineValveNoWait")
            Dim strErrMsg As String = String.Empty
            Try
                'TM rough
                Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Equipment)
                If (roughpumpMachine IsNot Nothing) Then
                    If (roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                        Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                        If (objTM IsNot Nothing AndAlso objTM.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            strErrMsg = " TM Rough valve is Opened."
                            Exit Try
                        End If
                    End If
                    'LLA
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

                        If Not roughpumpMachine.VacSwitchStatus = DataManagerment.Equipment.WorkingStatuses.On Then
                            strErrMsg = ConstEnum.Equipments.LoadLockA.ToString & " Mechanical Pump CG Relay Is Not On"
                            Exit Try
                        End If

                        If Not roughpumpMachine.CG <= VentPumdownLib.LLPumpdownConfig.TMMechanicalPumpOnPressure Then
                            strErrMsg = ConstEnum.Equipments.LoadLockA.ToString & " Mechanical Pump CG not reach Cross Over pressure."
                            Exit Try
                        End If

                        If Not roughpumpMachine.RoughPumpStatus = DataManagerment.Equipment.WorkingStatuses.On Then
                            strErrMsg = ConstEnum.Equipments.LoadLockA.ToString & " Mechanical Pump Is Not On."
                            Exit Try
                        End If
                    End If
                End If

                Dim objLLTurboValve As TurboForeLineValveDriver = Nothing

                If (Equipment = ConstEnum.LoadLockA_STR) Then
                    objLLTurboValve = DriverManager.GetDriver(DriverConst.LoadLockA_TurboForelineValve)
                End If

                If (objLLTurboValve IsNot Nothing) Then
                    If objLLTurboValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLTurboValve.IsDeviceActive() Then
                        strErrMsg = Equipment & " Can't Open Turbo ForeLine Valve Due To Solenoid 3 Is Not Online."
                        Exit Try
                    End If

                    If (Not objLLTurboValve.OpenTurboForeLineValve()) Then
                        strErrMsg = "Open Load Lock Turbo ForeLine Valve Failed."
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenLLTurboForeLineValveNoWait")
            Return strErrMsg
        End Function

        Public Shared Function OpenLLFastRoughNoWait(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter OpenLLFastRough")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objRough As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(Equipment)
                Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(Equipment)
                If (objRough Is Nothing) Then
                    AVPLib.Log.avpLogger.Error("Rough is not setup")
                Else

                    If (objRough.CG_Communication = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        strErrMsg = AVPLib.Utils.chamberID2ChamberName(Equipment) & ConstEnum.MECHANICAL_PUMP_CG_DISCONNECTED
                    End If

                    If Not IsNotForelineValveOpened(Equipment, strErrMsg) Then
                        Exit Try
                    End If

                    If (objRough.MakeRoughLineInUseNoWait(Equipment, False)) Then
                        Dim objLLRoughValve As RoughValveDriver = Nothing

                        If (Equipment = ConstEnum.LoadLockA_STR) Then
                            objLLRoughValve = DriverManager.GetDriver(DriverConst.LoadLockA_LLFastRough)
                        End If

                        'KHOI HA, check loadlock door before open LL rough valve
                        If Not (IsLLdoorClosed(Equipment)) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("DoorWasNotClose"), Equipment)
                            Exit Try
                        End If

                        If (objLLRoughValve IsNot Nothing) Then
                            If (Not objLLRoughValve.OpenRoughValve()) Then
                                strErrMsg = "Open Loadlock Fast Rough Valve Failed."
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenLLFastRough")
            Return strErrMsg
        End Function

#End Region
    End Class
End Namespace

