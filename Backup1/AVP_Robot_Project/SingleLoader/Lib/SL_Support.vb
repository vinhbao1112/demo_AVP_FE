Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls

Public Class SL_Support
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-04-08 </date>
    ''' </author>
    ''' <summary>
    ''' Read Message Text
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub ReadMessageText(ByVal sender As Object, _
                                      ByRef strMessageText As String)
        strMessageText = String.Empty

        Dim button As ButtonIGCGControl = CType(sender, ButtonIGCGControl)
        Try
            If button.Name = "...." And (button.Status = ButtonIGCGControl.DisplayStatus.Unknow) Then ''only for SL
                strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE + "." + button.Name + "." + STRING_CLOSE)

            ElseIf (button.Status = ButtonIGCGControl.DisplayStatus.Unknow And button.Name = "....") Then
                strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE + "." + button.Name + "." + UNKNOWN)

            ElseIf (button.Status = ButtonIGCGControl.DisplayStatus.Unknow And button.Name = "....") Then
                strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE + "." + button.Name + "." + UNKNOWN)

            ElseIf (button.Status = BinaryStatusControl.DisplayStatus.On) Or (button.Status = ButtonIGCGControl.DisplayStatus.Unknow) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE + "." + button.Name + "." + STRING_OPEN)

            ElseIf (button.Status = BinaryStatusControl.DisplayStatus.Off) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE + "." + button.Name + "." + STRING_CLOSE)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' handles all button on PVD Panel
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub NormalButtonClick(ByVal strLogMessage As String, ByVal sender As Object, _
                            ByVal strMasterPanelName As String, ByVal stoStatusObject As StatusObject)

        AVPLib.Log.guiLogger.Info("Enter Button_Click")

        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Dim button As Button = CType(sender, Button)

        Try
            strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE & "." & strMasterPanelName & "." & button.Name) 'SL.ProcessControl.btnSelect

            Dim strSourceLogMessage As String = String.Empty

            strSourceLogMessage = "[" + strMasterPanelName + "]"
            Dim chamberName As String = String.Empty
            chamberName = AVPLib.Utils.chamberID2ChamberName(stoStatusObject.Name)
            If String.IsNullOrEmpty(chamberName) OrElse Not stoStatusObject.Name.StartsWith(AVPLib.ConstEnum.Chamber) Then
                chamberName = AVPLib.Utils.chamberID2ChamberName(stoStatusObject.Parent.Name)
            End If
            If Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information) = DialogResult.OK Then

                stoStatusObject.RequestStatus(button.Name, "")
                Utils.LogUserEvent(sender, chamberName)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Button_Click")
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2010-12-24 </date>
    ''' </author>
    ''' <summary>
    ''' handles all button for SL to send value: on, off, unknown
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub ButtonClick(ByVal sender As Object, _
                        ByVal strMasterPanelName As String, ByVal stoStatusObject As StatusObject)
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strValue As String = String.Empty
            If button.Status = SL_CustomButton.DisplayStatus.Off Then
                strValue = STR_ON
            Else
                strValue = STR_OFF
            End If
            Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(stoStatusObject.Parent.Name)
            If objIBEPanel Is Nothing Then 'try to get Obj IBE Panel, some control has parent is IBE Panel
                objIBEPanel = ContainerForm.ChamberPanel(stoStatusObject.Name)
                If objIBEPanel Is Nothing Then
                    Exit Try
                End If
            End If

            Dim chamberName As String = String.Empty
            chamberName = AVPLib.Utils.chamberID2ChamberName(objIBEPanel.Name)
            'Case button MotionInitialized and Autobeam
            If objIBEPanel.SLContainerBox.btnMesaValve.Status <> SL_CustomButton.DisplayStatus.Off AndAlso _
                            button.Status <> SL_CustomButton.DisplayStatus.On AndAlso _
                            objIBEPanel.btnUnProtected.Status <> SL_CustomButton.DisplayStatus.On AndAlso _
                            (button.Name = objIBEPanel.SLFixture.btnMotionInitialized.Name Or _
                            button.Name = objIBEPanel.btnAutoBeam.Name) Then
                Utils.ShowAVPMessageBox("Slit valve is not closed", chamberName, MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                Exit Sub

            ElseIf objIBEPanel.SLContainerBox.btnMesaValve.Status <> SL_CustomButton.DisplayStatus.Off AndAlso _
                        button.Status <> SL_CustomButton.DisplayStatus.On AndAlso _
                        button.Name = "btnAutoVentGeneral" Then
                ''for btn Auto Vent -> check Slit valve before autovent
                Utils.ShowAVPMessageBox("Slit valve is not closed", chamberName, MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                Exit Sub
            End If
            'Case button Rotate with mode Home of Fixture
            If objIBEPanel.SLFixture.txtRotationMode.Text = AVP_Robot_Project.ConstantAndEnum.FixtureMode.Home.ToString() AndAlso _
                button.Name = objIBEPanel.SLFixture.btnRotate.Name Then
                strValue = STR_OTHER
            End If

            ' In case Motion Initialize.
            If button.Name = objIBEPanel.SLFixture.btnMotionInitialized.Name Then
                If button.Status = DisplayStatus.Off OrElse button.Status = DisplayStatus.On Then
                    ' Start motion initialize.
                    strValue = STR_ON
                Else
                    ' Stop motion initialize.
                    strValue = STR_OFF
                End If
            End If

            Dim Source As String = STR_IBE & "." & strMasterPanelName & "." & button.Name & "." & strValue
            If button.Name = objIBEPanel.btnAutoBeam.Name Or button.Name = objIBEPanel.btnUnProtected.Name Then
                Source = STR_IBE & "." & button.Name & "." & strValue
            End If
            If button.Name = "btnUnProtected" Then
                Source = STR_IBE & "_" & STR_AVP & "." & button.Name & "." & strValue
            End If
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)

            Utils.LogUserEvent(sender, chamberName)

            If Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                If button.Name = "btnAutoBeam" AndAlso objIBEPanel.TypeOfIBE = AllChamberType.AVP_IBE _
                    AndAlso button.Status <> SL_CustomButton.DisplayStatus.On Then
                    Dim strConditionAutoBeamError As String = String.Empty

                    'Check condition before Auto Beam
                    If Not CheckConditionBeforeAutoBeam(objIBEPanel.Name, strConditionAutoBeamError) Then
                        AVPLib.Utils.ThrowAlarm(AVPLib.Utils.chamberID2ChamberName(objIBEPanel.Name) & ": " & strConditionAutoBeamError)
                        Exit Try
                    End If

                    ''special case for AVP_IBE AutoBeam, wait for 3 gas have value
                    If Not String.IsNullOrEmpty(objIBEPanel.txtPBNGasRight_SourceTab.Text) Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtPBNGasRight_SourceTab.Name, objIBEPanel.txtPBNGasRight_SourceTab.Text)
                    End If
                    If (objIBEPanel.Gas1ShutoffVisible OrElse objIBEPanel.Gas1SupplyVisible) AndAlso Not String.IsNullOrEmpty(objIBEPanel.txtGas1Right_SourceTab.Text) Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtGas1Right_SourceTab.Name, objIBEPanel.txtGas1Right_SourceTab.Text)
                    End If
                    If (objIBEPanel.Gas2ShutoffVisible OrElse objIBEPanel.Gas2SupplyVisible) AndAlso Not String.IsNullOrEmpty(objIBEPanel.txtGas2Right_SourceTab.Text) Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtGas2Right_SourceTab.Name, objIBEPanel.txtGas2Right_SourceTab.Text)
                    End If
                    If (objIBEPanel.Gas3ShutoffVisible OrElse objIBEPanel.Gas3SupplyVisible) AndAlso Not String.IsNullOrEmpty(objIBEPanel.txtGas3Right_SourceTab.Text) Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtGas3Right_SourceTab.Name, objIBEPanel.txtGas3Right_SourceTab.Text)
                    End If
                    If (objIBEPanel.Gas4ShutoffVisible OrElse objIBEPanel.Gas4SupplyVisible) AndAlso Not String.IsNullOrEmpty(objIBEPanel.txtGas4Right_SourceTab.Text) Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtGas4Right_SourceTab.Name, objIBEPanel.txtGas4Right_SourceTab.Text)
                    End If
                    System.Threading.Thread.Sleep(100) ''wait for 100ms

                    'Send necessary infos for start autobeam
                    If Not String.IsNullOrEmpty(objIBEPanel.txtBeamVoltageRight.Text) Then
                        objIBEPanel.txtBeamVoltageRight.Text = Double.Parse(objIBEPanel.txtBeamVoltageRight.Text).ToString("0")
                        stoStatusObject.RequestStatus(objIBEPanel.txtBeamVoltageRight.Name, objIBEPanel.txtBeamVoltageRight.Text)
                    End If
                    System.Threading.Thread.Sleep(100) ''wait for 100ms
                    If Not String.IsNullOrEmpty(objIBEPanel.txtBeamCurrentRight.Text) Then
                        objIBEPanel.txtBeamCurrentRight.Text = Double.Parse(objIBEPanel.txtBeamCurrentRight.Text).ToString("0")
                        stoStatusObject.RequestStatus(objIBEPanel.txtBeamCurrentRight.Name, Utils.Contvert_mA2A(objIBEPanel.txtBeamCurrentRight.Text))
                    End If
                    System.Threading.Thread.Sleep(100) ''wait for 100ms
                    If Not String.IsNullOrEmpty(objIBEPanel.txtSuppressorVoltageRight.Text) Then
                        objIBEPanel.txtSuppressorVoltageRight.Text = Double.Parse(objIBEPanel.txtSuppressorVoltageRight.Text).ToString("0")
                        stoStatusObject.RequestStatus(objIBEPanel.txtSuppressorVoltageRight.Name, objIBEPanel.txtSuppressorVoltageRight.Text)
                    End If
                    System.Threading.Thread.Sleep(100) ''wait for 100ms
                    If Not String.IsNullOrEmpty(objIBEPanel.txtRFPowerRight.Text) Then
                        objIBEPanel.txtRFPowerRight.Text = Double.Parse(objIBEPanel.txtRFPowerRight.Text).ToString("0")
                        stoStatusObject.RequestStatus(objIBEPanel.txtRFPowerRight.Name, objIBEPanel.txtRFPowerRight.Text)
                    End If
                    System.Threading.Thread.Sleep(100) ''wait for 100ms
                    If Not String.IsNullOrEmpty(objIBEPanel.txtKFactorRight.Text) Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtKFactorRight.Name, objIBEPanel.txtKFactorRight.Text)
                    End If
                    System.Threading.Thread.Sleep(100) ''wait for 100ms

                    If Not String.IsNullOrEmpty(objIBEPanel.txtSourceEMCurrentRight_SourceTab.Text) Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtSourceEMCurrentRight_SourceTab.Name, objIBEPanel.txtSourceEMCurrentRight_SourceTab.Text)
                    End If
                    System.Threading.Thread.Sleep(100) ''wait for 100ms

                ElseIf (button.Name = "btnRateOfRise" OrElse button.Name = "btnPumpdownCurve") AndAlso strValue = STR_ON Then
                    If objIBEPanel.TypeOfIBE = AllChamberType.AVP_IBE Then
                        Dim frmInfo As SL_ROR_PDC_Info
                        If button.Name = "btnRateOfRise" Then
                            frmInfo = New SL_ROR_PDC_Info(DiagnosticType.Rate_Of_Rise)
                        Else
                            frmInfo = New SL_ROR_PDC_Info(DiagnosticType.PumpDown_Curve)
                        End If
                        frmInfo.ShowDialog()
                        If Not frmInfo.IsStartProcess Then
                            Exit Try
                        End If
                    End If
                End If
                stoStatusObject.RequestStatus(button.Name, strValue)
                'for cycle and unprotected button of Process Panel
                If button.Name = "btnCycle" Then
                    If button.Status = SL_CustomButton.DisplayStatus.On Then
                        button.Status = SL_CustomButton.DisplayStatus.Off
                    Else
                        button.Status = SL_CustomButton.DisplayStatus.On
                    End If
                ElseIf button.Name = "btnUnProtected" Then
                    If button.Status = SL_CustomButton.DisplayStatus.On Then
                        objIBEPanel.btnUnProtected.Status = SL_CustomButton.DisplayStatus.Off
                        objIBEPanel.bUnProtectedClicked = False
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then
                        objIBEPanel.btnUnProtected.Status = SL_CustomButton.DisplayStatus.On
                        objIBEPanel.bUnProtectedClicked = True
                    End If
                    '#02/25/2011 
                    '#0001245: [SL_RFE_KhoiHa_Feb 14,2011]Motion initialize status flashing on/off 
                    '#Begin fix
                    'ElseIf button.Name = objIBEPanel.SLFixture.btnMotionInitialized.Name Then
                    '    If button.Status = SL_CustomButton.DisplayStatus.On Then
                    '        objIBEPanel.IsWaitingInitializeMotionOff = True
                    '    End If
                    '#End fix
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-01 </date>
    ''' </author>
    ''' <summary>
    ''' Open Close both Shutoff, Supply Gas valve at the same time
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub OpenCloseBothShutoffSupplyValve(ByVal sender As Object, _
                            ByVal strMasterPanelName As String, ByVal stoStatusObject As StatusObject)
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strValue As String = String.Empty
            Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(stoStatusObject.Parent.Name)
            If objIBEPanel Is Nothing Then 'try to get Obj IBE Panel, some control has parent is IBE Panel
                objIBEPanel = ContainerForm.ChamberPanel(stoStatusObject.Name)
                If objIBEPanel Is Nothing Then
                    Exit Try
                End If
                End If

            Dim Source As String = STR_IBE & "." & button.Name
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)

            Dim dlgRes As DialogResult = Utils.ShowAVPMessageBox(strMessageText, strMasterPanelName, MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel) 'MessageBoxButtons.YesNoCancel)
            If dlgRes = DialogResult.OK Then
                strValue = STR_ON
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strMasterPanelName + "] Open " + button.AccessibleName)
            ElseIf dlgRes = DialogResult.No Then
                strValue = STR_OFF
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strMasterPanelName + "] Close " + button.AccessibleName)
            Else
                Exit Try
            End If
            Select Case button.Name
                Case objIBEPanel.btnOpenClosePBNGas.Name
                    stoStatusObject.RequestStatus(objIBEPanel.ValveShutoffPBNGas.Name, strValue)
                    stoStatusObject.RequestStatus(objIBEPanel.ValveSupplyPBNGas.Name, strValue)
                    'Send SP gas when open valve
                    If strValue = STR_ON Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtPBNGasRight.Name, objIBEPanel.txtPBNGasRight.Text)
                    End If
                Case objIBEPanel.btnOpenCloseGas1.Name
                    stoStatusObject.RequestStatus(objIBEPanel.ValveShutoffGas1.Name, strValue)
                    stoStatusObject.RequestStatus(objIBEPanel.ValveSupplyGas1.Name, strValue)
                    'Send SP gas when open valve
                    If strValue = STR_ON Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtGas1Right.Name, objIBEPanel.txtGas1Right.Text)
                    End If
                Case objIBEPanel.btnOpenCloseGas2.Name
                    stoStatusObject.RequestStatus(objIBEPanel.ValveShutoffGas2.Name, strValue)
                    stoStatusObject.RequestStatus(objIBEPanel.ValveSupplyGas2.Name, strValue)
                    'Send SP gas when open valve
                    If strValue = STR_ON Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtGas2Right.Name, objIBEPanel.txtGas2Right.Text)
                    End If
                Case objIBEPanel.btnOpenCloseGas3.Name
                    stoStatusObject.RequestStatus(objIBEPanel.ValveShutoffGas3.Name, strValue)
                    stoStatusObject.RequestStatus(objIBEPanel.ValveSupplyGas3.Name, strValue)
                    'Send SP gas when open valve
                    If strValue = STR_ON Then
                        stoStatusObject.RequestStatus(objIBEPanel.txtGas3Right.Name, objIBEPanel.txtGas3Right.Text)
                    End If
                Case objIBEPanel.SLFixture.btnOpenCloseFlowCoolGas.Name
                    stoStatusObject.RequestStatus(objIBEPanel.SLFixture.ValveShutoffFlowCoolGas.Name, strValue)
                    stoStatusObject.RequestStatus(objIBEPanel.SLFixture.ValveSupplyFlowCoolGas.Name, strValue)
                    'Send SP gas when open valve
                    If strValue = STR_ON Then
                        stoStatusObject.RequestStatus(objIBEPanel.SLFixture.txtFlowCoolGasRight.Name, objIBEPanel.SLFixture.txtFlowCoolGasRight.Text)
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' handles all Valve Click on Single Loader Panel
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub ValveClick(ByVal sender As Object, ByVal e As System.EventArgs, _
                         ByVal strMasterPanelName As String, ByVal strValveName As String, ByVal stoStatusObject As StatusObject, Optional ByVal valueToBeSent As String = "")
        AVPLib.Log.guiLogger.Info("Enter ValveControl_Click")
        Try
            Dim strMessageText As String
            Dim strValue As String
            Dim ValveControl As AVP_Robot_Project.ValveControl = CType(sender, AVP_Robot_Project.ValveControl)
            Dim Message As String = ValveControl.Name
            Dim messageLog As String = String.Empty
            If Not String.IsNullOrEmpty(valueToBeSent) Then
                If valueToBeSent = STR_ON Then
                    strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE + "." + Message + "." + STRING_OPEN)
                    strValue = STR_ON
                    messageLog = "Open " & ValveControl.AccessibleName & " of " & strMasterPanelName
                Else
                    strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE + "." + Message + "." + STRING_CLOSE)
                    strValue = STR_OFF
                    messageLog = "Close " & ValveControl.AccessibleName & " of " & strMasterPanelName
                End If
            Else
                If (ValveControl.Status = BinaryStatusControl.DisplayStatus.Off) Then
                    strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE + "." + Message + "." + STRING_OPEN)
                    strValue = STR_ON
                    messageLog = "Open " & ValveControl.AccessibleName & " of " & strMasterPanelName
                Else
                    strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE + "." + Message + "." + STRING_CLOSE)
                    strValue = STR_OFF
                    messageLog = "Close " & ValveControl.AccessibleName & " of " & strMasterPanelName
                End If
            End If

            Dim objTransferModule As AVPLib.DataManagerment.CassettesModule = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.CassettesModule.ToString()) 'for CX
            Dim strCheckResult As String = String.Empty
            If ValveControl.Name = VALVE_VENT Or ValveControl.Name = VALVE_ROUGH Then
                'Check Vent Valve, Rough Vale can't open in the same time at process module
            ElseIf ValveControl.Name = VENT_VALVE OrElse ValveControl.Name = ROUGH_VALVE Then
                Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(stoStatusObject.Name)
                If objIBEPanel Is Nothing Then
                    AVPLib.Log.avpLogger.Error("Can't get IBE Panel Obj from : " & strMasterPanelName)
                    Exit Try
                End If
                If Not (objIBEPanel.btnUnProtected.Status = SL_CustomButton.DisplayStatus.On) AndAlso _
                     ValveControl.Status = BinaryStatusControl.DisplayStatus.Off Then
                    If ValveControl.Name = VENT_VALVE Then

                        'Dat Cao rem this code because BACK END (IBE) handled
                        'If (objIBEPanel.SLContainerBox.ValveTurboHivac.Status <> SL_CustomButton.DisplayStatus.Off) Then
                        '    strCheckResult = String.Format(AVPLib.ContainerData.GetMessageText("HivacValveDidNotClose"), "Turbo")
                        'ElseIf (objIBEPanel.SLContainerBox.ValveCryoHivac.Status <> SL_CustomButton.DisplayStatus.Off) Then
                        '    strCheckResult = String.Format(AVPLib.ContainerData.GetMessageText("HivacValveDidNotClose"), "Cryo")
                        'End If

                        If objIBEPanel.ValveRough.Status = BinaryStatusControl.DisplayStatus.On Then
                            strCheckResult = AVPLib.ContainerData.GetMessageText("RoughValveIsNotClosed")
                        ElseIf objIBEPanel.SLContainerBox.btnMesaValve.Status <> SL_CustomButton.DisplayStatus.Off Then
                            strCheckResult = AVPLib.ContainerData.GetMessageText("IsolationValveIsNotClosed")
                        End If
                    ElseIf ValveControl.Name = ROUGH_VALVE Then
                        If objIBEPanel.ValveVent.Status = BinaryStatusControl.DisplayStatus.On Then
                            strCheckResult = AVPLib.ContainerData.GetMessageText("VentValveIsNotClosed")
                        End If
                    End If
                End If
            ElseIf ValveControl.Name = "ValveSupplyFlowCoolGas" OrElse ValveControl.Name = "ValveShutoffFlowCoolGas" Then
                '#03/26/2012
                '# - Currently when  user enter flowcool sp > 0,  ibe automatically turn on flowcool/open return/open supply/etc�.  
                '# Fixture need to clamp up & a wafer must present in fixture to allow this action.   Similar condition need to 
                '# apply when user try to open flowcool supply or return valve.
                '#Begin fix:
                Dim objIBE As AVPLib.DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(stoStatusObject.Parent.Name)
                If strValue = STR_ON AndAlso objIBE IsNot Nothing AndAlso objIBE.Fixture_Unprotected_Readback = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off Then
                    Dim strErrMessage = "Can Not Open " & ValveControl.AccessibleName & ". "
                    If Not objIBE.FixtureClampStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On Then
                        strCheckResult = strErrMessage & AVPLib.ContainerData.GetMessageText("FIXTURE_CLAMP_IS_NOT_UP")
                    ElseIf Not objIBE.WaferInside = AVPLib.DataManagerment.Equipment.WorkingStatuses.On Then
                        strCheckResult = strErrMessage & String.Format(AVPLib.ContainerData.GetMessageText( _
                             "NO_WAFER_IN_PM"), AVPLib.Utils.chamberID2ChamberName(objIBE.Name))
                    End If
                End If
                'End fix
            End If

            If Not (String.IsNullOrEmpty(strCheckResult)) Then
                Utils.ShowAVPMessageBox(strCheckResult, strMasterPanelName, MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                Exit Sub
            End If

            If Utils.ShowAVPMessageBox(strMessageText, strMasterPanelName, MessageBoxIcon.Question) = DialogResult.OK Then
                stoStatusObject.RequestStatus(ValveControl.Name, strValue)
                Utils.LogUserEvent(sender)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ValveControl_Click")
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-03-08 </date>
    ''' </author>
    ''' <summary>
    ''' CheckConditionBeforeAutoBeam
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Function CheckConditionBeforeAutoBeam(ByVal strChamberName, ByRef strError) As Boolean
        Try
            '# 10/16/2012
            '#  1.	CX7 (R&D) system with IBE @ pm3.  See notes below
            '# Begin fix: Rem all code below. No need to check condition. Keep this function to reserve.

            'Dim objIBE As AVPLib.DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(strChamberName)
            'Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(strChamberName)
            'Dim chamber As AVPLib.SystemModule = CType(AVPLib.ContainerData.GetRobotConfig(CStr(strChamberName)), AVPLib.SystemModule)
            'Dim blnTurboHivacOpened As Boolean = objIBE.HiVacValveStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On
            'Dim blnCryoHivacOpened As Boolean = False

            ''Is process running
            'If objIBE.RunProcessStatus = enumProcessStatus.eStart Then
            '    strError = AVPLib.ContainerData.GetMessageText("UNABLE_RUN_AUTO_BEAM_PROCESS_RUNNING")
            '    Return False
            'End If

            'If chamber.CryoVisible Then
            '    blnCryoHivacOpened = objIBE.ValveCryoPumpGateStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On
            'End If
            'Dim blnHivacOpened As Boolean = blnTurboHivacOpened Or blnCryoHivacOpened

            ''Is Tubo HiVac or Cryo Hivac Open?
            'If Not blnHivacOpened Then
            '    strError = AVPLib.ContainerData.GetMessageText("UNABLE_RUN_AUTO_BEAM_HIVAC_CLOSED")
            '    Return False
            'End If

            ''Is IG off
            'If objIBE.IGStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off Then
            '    strError = AVPLib.ContainerData.GetMessageText("UNABLE_RUN_AUTO_BEAM_IG_OFF")
            '    Return False
            'End If

            '' Autobeam or autobeam during Process run.    Alarm if user try to run recipe or autobeam with beam current > 0,  pbn = 0
            'If objIBE.BeamPowerSupply_Current_Program > 0 AndAlso objIBE.GasController_PBN_Program <= 0 Then
            '    strError = AVPLib.ContainerData.GetMessageText("INVALID_AUTO_BEAM_DATA_PBN_GAS_ZERO")
            '    Return False
            'End If

            ''Is All Interlock made?
            'If Not ((objIBE.ChamberInterlocks_FixtureWater_Status = AVPLib.DataManagerment.Equipment.WorkingStatuses.On) _
            '         AndAlso (objIBE.ChamberInterlocks_SourceWater_Status = AVPLib.DataManagerment.Equipment.WorkingStatuses.On) _
            '         AndAlso (objIBE.ChamberInterlocks_PanelInterlock_Status = AVPLib.DataManagerment.Equipment.WorkingStatuses.On) _
            '         AndAlso (objIBE.ChamberInterlocks_ChamberPress_Status = AVPLib.DataManagerment.Equipment.WorkingStatuses.On) _
            '         AndAlso (objIBE.ChamberInterlocks_Foreline_Status = AVPLib.DataManagerment.Equipment.WorkingStatuses.On) _
            '         AndAlso (objIBE.ChamberInterlocks_AirPressure_Status = AVPLib.DataManagerment.Equipment.WorkingStatuses.On) _
            '         AndAlso (objIBE.ChamberInterlocks_TurboWater_Status = AVPLib.DataManagerment.Equipment.WorkingStatuses.On)) Then

            '    strError = AVPLib.ContainerData.GetMessageText("ALL_INTERLOCKS_ARE_NOT_MADE")
            '    Return False
            'End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return True
    End Function
End Class
