Imports AVPLib.Communication.TerminalDriver
Imports AVPLib.Driver
Namespace Business
    Public Class LoadLockUtility
#Region "Public methods"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' OpenLLHivac
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function OpenLLHivac(ByVal Equipment As String, Optional ByVal isCheckSafety As Boolean = True, Optional ByVal dbCGMultiFactor As Double = 1) As String
            AVPLib.Log.coreLogger.Info("Enter OpenLLHivac")
            Dim strErrMsg As String = String.Empty
            Try
                ''' if ROUGH ONLY -> do nothing
                If Equipment = ConstEnum.LoadLockA_STR AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED Then
                    Dim loadlock As DataManagerment.LoadLock = Nothing
                    If isCheckSafety Then
                        ' Make sure LLCryo Is On Before Opening Hivac.
                        Dim objPumpPackageCtrl As PumpPackageController = Nothing
                        If Equipment = ConstEnum.LoadLockA_STR Then
                            objPumpPackageCtrl = Business.ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString())
                            loadlock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
                        End If

                        'Check condition before opening Hivac
                        If (loadlock IsNot Nothing) Then
                            Dim strCheckResult = loadlock.CheckCondition2OpenLLHiVac(dbCGMultiFactor)
                            If Not (String.IsNullOrEmpty(strCheckResult)) Then
                                Return strCheckResult
                            End If
                        End If

                        If objPumpPackageCtrl.EquipmentName = ConstEnum.Equipments.LLAPumpPackage.ToString() Then
                            If (objPumpPackageCtrl IsNot Nothing) AndAlso (objPumpPackageCtrl.IsCommunicationOK = False) Then
                                strErrMsg = String.Format("Can not open LoadLock Hivac because of {0} TimeOut.", objPumpPackageCtrl.DisplayName)
                                Return strErrMsg
                            End If

                            If (objPumpPackageCtrl IsNot Nothing) AndAlso (objPumpPackageCtrl.IsPumpPackageOK(strErrMsg) = False) Then
                                Return strErrMsg
                            End If
                        End If
                    End If

                    Dim objLLHivacValve As HivacValveDriver = Nothing
                    objLLHivacValve = DriverManager.GetDriver(Equipment & ".LLHiVac")

                    'If (Equipment = ConstEnum.LoadLockA_STR) Then
                    '    objLLHivacValve = DriverManager.GetDriver(DriverConst.LLA_Hivac_Valve)
                    'ElseIf (Equipment = ConstEnum.LoadLockA_STR) Then
                    '    objLLHivacValve = DriverManager.GetDriver(DriverConst.LLB_Hivac_Valve)
                    'End If

                    If (objLLHivacValve IsNot Nothing) Then
                        If objLLHivacValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLHivacValve.IsDeviceActive() Then
                            strErrMsg = Equipment & " Can't Open Hivac Valve Due To Solenoid 1 Is Not Online."
                            Exit Try
                        End If

                        If (Not objLLHivacValve.OpenHivacValve()) Then
                            strErrMsg = "Open Loadlock Hivac Valve Failed."
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenLLHivac")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' CloseLLHivac
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CloseLLHivac(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter CloseLLHivac")
            Dim strErrMsg As String = String.Empty
            Try
                If Equipment = ConstEnum.LoadLockA_STR AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED Then
                    Dim objLLHivacValve As HivacValveDriver = Nothing
                    objLLHivacValve = DriverManager.GetDriver(Equipment & ".LLHiVac")

                    'If (Equipment = ConstEnum.LoadLockA_STR) Then
                    '    objLLHivacValve = DriverManager.GetDriver(Equipment & ".LLHiVac")
                    'ElseIf (Equipment = ConstEnum.LoadLockA_STR) Then
                    '    objLLHivacValve = DriverManager.GetDriver(DriverConst.LLB_Hivac_Valve)
                    'End If

                    If (objLLHivacValve IsNot Nothing) Then
                        If objLLHivacValve.eCommunicationType = CommType.DeviceNet AndAlso Not objLLHivacValve.IsDeviceActive() Then
                            strErrMsg = Equipment & " Can't Close Hivac Valve Due To Solenoid 1 Is Not Online."
                            Exit Try
                        End If

                        If (Not objLLHivacValve.CloseHivacValve()) Then
                            strErrMsg = "Close Loadlock Hivac Valve Failed."
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseLLHivac")
            Return strErrMsg
        End Function
#End Region
    End Class
End Namespace

