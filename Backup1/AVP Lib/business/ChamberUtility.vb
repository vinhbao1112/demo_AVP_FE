Imports avplib.Driver
Namespace Business
    Public Class ChamberUtility
#Region "Public method"
        Public Shared Function IsLLRoughValveClosed(ByVal sEquipmentsName) As String

            Dim strResult As String = String.Empty
            'special for Rough Only
            'if LLA -> check rough valve open -> alarm
            If (sEquipmentsName = ConstEnum.Equipments.LoadLockA.ToString()) Then
                Dim objLoadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(sEquipmentsName)
                If (objLoadlock IsNot Nothing AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED = False) Then
                    If (objLoadlock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                        strResult = sEquipmentsName + " Fast Rough valve is not closed."
                    ElseIf (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED AndAlso objLoadlock.SlowRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                        strResult = sEquipmentsName + " Slow Rough valve is not closed."
                    End If
                End If
            End If
            Return strResult
        End Function

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-01</date>
        ''' </author>
        ''' <summary>
        ''' OpenCloseSlitValve
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function OpenCloseSlitValve(ByVal Equipment As String, _
                                                  ByVal bOpen As Boolean, _
                                                  Optional ByVal strSplitValve As String = "") As String
            AVPLib.Log.coreLogger.Info("Enter OpenCloseSlitValve")
            Dim strErrMsg As String = String.Empty

            Try
                Dim objIsolationValve As IsolationValveDriver = Nothing
                Dim strValveID As String = String.Empty

                If (strSplitValve = String.Empty) Then
                    Select Case Equipment
                        Case ConstEnum.Equipments.Chamber1.ToString()
                            strValveID = DriverConst.CassettesModule_SplitValvePM1
                        Case ConstEnum.Equipments.Chamber2.ToString()
                            strValveID = DriverConst.CassettesModule_SplitValvePM2
                        Case ConstEnum.Equipments.Chamber3.ToString()
                            strValveID = DriverConst.CassettesModule_SplitValvePM3
                        Case ConstEnum.Equipments.LoadLockA.ToString()
                            strValveID = DriverConst.CassettesModule_SplitValveLLA
                        Case ConstEnum.Equipments.CassettesModule.ToString()
                            'strValveID = strSplitValve ' from the calling function
                            'don't know this case
                        Case Else
                    End Select
                Else
                    strValveID = Equipment & "." & strSplitValve
                End If

                objIsolationValve = DriverManager.GetDriver(strValveID)
                If (objIsolationValve IsNot Nothing) Then
                    If objIsolationValve.eCommunicationType = CommType.DeviceNet AndAlso Not objIsolationValve.IsDeviceActive() Then
                        strErrMsg = Utils.chamberID2ChamberName(GetChamberName(strSplitValve)) & " Can't " & IIf(bOpen, "Open", "Close") & " Slit Valve Due To Solenoid 1 Is Not Online."
                        Exit Try
                    End If
                    If (bOpen) Then
                        If Equipment = ConstEnum.Equipments.CassettesModule.ToString() Then
                            Equipment = GetChamberName(strSplitValve)
                        End If
                        If Not CheckPressureDifferent(Equipment, String.IsNullOrEmpty(strSplitValve), strErrMsg) Then
                            Exit Try
                        End If
                        If (Not objIsolationValve.OpenIsolationValve()) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("OpenCloseValveFailed"), strValveID)
                        End If
                    Else
                        If (Not objIsolationValve.CloseIsolationValve()) Then
                            strErrMsg = String.Format(ContainerData.GetMessageText("OpenCloseValveFailed"), strValveID)
                        End If
                    End If
                Else
                    AVPLib.Log.avpLogger.Error(strValveID & ":Instance does not exist.")
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave OpenCloseSlitValve")
            Return strErrMsg
        End Function

        Private Shared Function CheckPressureDifferent(ByVal equipment As String, ByVal isAutoTransfer As Boolean, ByRef strPressureError As String) As Boolean
            Dim result As Boolean = False
            Try
                Dim isCycleATM As Boolean = False
                Dim objLoadLockCtrl As LoadLockController = Business.ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString())
                Dim objavpCtrlJob As AVPControlJob = AVPCore.Instance.JobManager.GetControlJob(objLoadLockCtrl.CtrlJobId)
                If (objavpCtrlJob IsNot Nothing) Then
                    isCycleATM = objavpCtrlJob.IsCycleInATMMode
                End If

                Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                If objTransferModule.OverideModeStatus = DataManagerment.Equipment.WorkingStatuses.On AndAlso Not isAutoTransfer Then
                    Return True
                End If

                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
                result = objTMController.CheckCG10DifferenceFromStation(equipment, False, isCycleATM, strPressureError, False)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return result
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-05-21</date>
        ''' </author>
        ''' <summary>
        ''' UnknownSlitValve
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function UnknownSlitValve(ByVal Equipment As String, Optional ByVal strSplitValve As String = "") As String
            AVPLib.Log.coreLogger.Info("Enter UnknownSlitValve")
            Dim strErrMsg As String = String.Empty

            Try
                Dim objIsolationValve As IsolationValveDriver = Nothing
                Dim strValveID As String = String.Empty

                If (strSplitValve = String.Empty) Then
                    Select Case Equipment
                        Case ConstEnum.Equipments.Chamber1.ToString()
                            strValveID = DriverConst.CassettesModule_SplitValvePM1
                        Case ConstEnum.Equipments.Chamber2.ToString()
                            strValveID = DriverConst.CassettesModule_SplitValvePM2
                        Case ConstEnum.Equipments.Chamber3.ToString()
                            strValveID = DriverConst.CassettesModule_SplitValvePM3
                        Case ConstEnum.Equipments.LoadLockA.ToString()
                            strValveID = DriverConst.CassettesModule_SplitValveLLA
                        Case ConstEnum.Equipments.CassettesModule.ToString()
                            'strValveID = strSplitValve ' from the calling function
                            'don't know this case
                        Case Else
                    End Select
                Else
                    strValveID = Equipment & "." & strSplitValve
                End If

                objIsolationValve = DriverManager.GetDriver(strValveID)
                If (objIsolationValve IsNot Nothing) Then
                    If (Not objIsolationValve.UnknownIsolationValve()) Then
                        strErrMsg = String.Format(ContainerData.GetMessageText("OpenCloseValveFailed"), strValveID)
                    End If
                Else
                    AVPLib.Log.avpLogger.Error(strValveID & ":Instance does not exist.")
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave UnknownSlitValve")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-05-21</date>
        ''' </author>
        ''' <summary>
        ''' GetChamberName
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetChamberName(ByVal strSplitValveName As String) As String
            AVPLib.Log.coreLogger.Info("Enter GetChamberName")
            Dim strChamberName As String = String.Empty

            Try
                Select Case strSplitValveName
                    Case ConstEnum.SPLIT_VALVE_LLA
                        strChamberName = ConstEnum.Equipments.LoadLockA.ToString()
                    Case ConstEnum.SPLIT_VALVE_PM1
                        strChamberName = ConstEnum.Equipments.Chamber1.ToString()
                    Case ConstEnum.SPLIT_VALVE_PM2
                        strChamberName = ConstEnum.Equipments.Chamber2.ToString()
                    Case ConstEnum.SPLIT_VALVE_PM3
                        strChamberName = ConstEnum.Equipments.Chamber3.ToString()
                    Case Else
                End Select

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave GetChamberName")
            Return strChamberName
        End Function

        ''' <author>
        '''    	<name>Tinh Le</name>
        '''    	<date> 2018-11-29 </date>
        ''' </author>
        ''' <summary>
        ''' SetCGTripPoint
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function SetCGTripPoint(ByVal Equipment As String, ByVal strCmd As String) As String
            AVPLib.Log.coreLogger.Info("Enter SetCGTripPoint")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objCGDriver As CGDriver = DriverManager.GetDriver(Equipment & "." & ConstEnum.CG)
                If objCGDriver IsNot Nothing AndAlso objCGDriver.eCommunicationType = CommType.DeviceNet Then
                    If (Not objCGDriver.SetValue(strCmd)) Then
                        strErrMsg = String.Format("Set {0} CG Trip Point Failed.", Equipment)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetCGTripPoint")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name>Tinh Le</name>
        '''    	<date> 2018-11-29 </date>
        ''' </author>
        ''' <summary>
        ''' SetTurboCGTripPoint
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function SetTurboCGTripPoint(ByVal Equipment As String, ByVal strCmd As String) As String
            AVPLib.Log.coreLogger.Info("Enter SetTurboCGTripPoint")
            Dim strErrMsg As String = String.Empty
            Try
                Dim objTurboCGDriver As TurboForeLineDriver = DriverManager.GetDriver(Equipment & ".TurboForelineCG")
                If objTurboCGDriver IsNot Nothing AndAlso objTurboCGDriver.eCommunicationType = CommType.DeviceNet Then
                    If (Not objTurboCGDriver.SetValue(strCmd)) Then
                        strErrMsg = String.Format("Set {0} Turbo Foreline CG Trip Point Failed.", Equipment)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetTurboCGTripPoint")
            Return strErrMsg
        End Function
#End Region
    End Class
End Namespace