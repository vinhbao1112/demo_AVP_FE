Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class PopUpPanel
    Private m_strChamberHandle As String = String.Empty

#Region "Properties"
    Public Property PopUpTitle() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    Public Property ChamberHandle() As String
        Get
            Return m_strChamberHandle
        End Get
        Set(ByVal value As String)
            m_strChamberHandle = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        m_stoStatusObject = New StatusObject()
        ' Add any initialization after the InitializeComponent() call.
        Try
            btnOnline.Clickable = True
            btnOnline.ValueToBeSend = ""

            btnOffline.Clickable = True
            btnOffline.ValueToBeSend = ""

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Private methods"
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbIGDegas As New StatusPVD_PopUpButton(btnIGDegas)
            Dim stbCryoOnOff As New StatusPVD_PopUpButton(btnCryoOn)
            Dim stbAutoVent As New StatusPVD_PopUpButton(btnAutoVent)
            Dim stbAutoRegen As New StatusPVD_PopUpButton(btnAutoRegenOn)
            Dim stbAutoPumpDown As New StatusPVD_PopUpButton(btnAutoPumpDown)

            Dim stCryoRegenHour As New StatusPVD_PopUpTextBox(txtCryoRegenHour)
            Dim stCryoLifeTime As New StatusPVD_PopUpTextBox(txtCryoLifeTimeHour)
            Dim stWaterRegenHour As New StatusPVD_PopUpTextBox(txtWaterPumpRegenHour)
            Dim stWaterLifeTime As New StatusPVD_PopUpTextBox(txtWaterPumpLifeTimeHour)

            Dim sbtOnlineStatus As New StatusPVD_PopUpButton(btnOnline)
            Dim sbtOfflineStatus As New StatusPVD_PopUpButton(btnOffline)
            Dim sbtMaintenanceStatus As New StatusPVD_PopUpButton(btnMaintenance)
            Dim sbtPumpPurge As New StatusPVD_PopUpButton(btnPumpPurge)
            Dim sbtShutDownPowerStatus As New StatusPVD_PopUpButton(btnShutDownPower)
            Dim sbtWPRegenOn As New StatusPVD_PopUpButton(btnWPRegenOn)
            Dim sbtWPRegenOff As New StatusPVD_PopUpButton(btnWPRegenOff)
            Dim sbtWaterPumpOn As New StatusPVD_PopUpButton(btnWaterPumpOn)
            Dim sbtWaterPumpOff As New StatusPVD_PopUpButton(btnWaterPumpOff)
            Dim stbRegenStatus As New StatusPVD_PopUpTextBox(txtRegenStatus)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbRegenStatus)
            m_stoStatusObject.AddChild(stbIGDegas)
            m_stoStatusObject.AddChild(stbCryoOnOff)
            m_stoStatusObject.AddChild(stbAutoVent)
            m_stoStatusObject.AddChild(stbAutoRegen)
            m_stoStatusObject.AddChild(stbAutoPumpDown)

            m_stoStatusObject.AddChild(stCryoRegenHour)
            m_stoStatusObject.AddChild(stCryoLifeTime)
            m_stoStatusObject.AddChild(stWaterRegenHour)
            m_stoStatusObject.AddChild(stWaterLifeTime)

            m_stoStatusObject.AddChild(sbtOnlineStatus)
            m_stoStatusObject.AddChild(sbtOfflineStatus)
            m_stoStatusObject.AddChild(sbtMaintenanceStatus)
            m_stoStatusObject.AddChild(sbtPumpPurge)
            m_stoStatusObject.AddChild(sbtShutDownPowerStatus)
            m_stoStatusObject.AddChild(sbtWPRegenOn)
            m_stoStatusObject.AddChild(sbtWPRegenOff)
            m_stoStatusObject.AddChild(sbtWaterPumpOn)
            m_stoStatusObject.AddChild(sbtWaterPumpOff)

            btnOnline.ParentStatusObj = m_stoStatusObject
            btnOffline.ParentStatusObj = m_stoStatusObject

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function CheckIsolationValve(ByVal ChamberName As String, ByVal actionName As String) As Boolean
        Dim IsPMIsoValveClose As Boolean = AVPLib.Utils.IsChamberSlitValveClose(ChamberName)
        Dim strLogMessage As String = "[" + AVPLib.Utils.chamberID2ChamberName(ChamberName) + "] Check Slit valve failed before Start " & actionName
        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, strLogMessage)
        If Not IsPMIsoValveClose Then
            Utils.ShowAVPMessageBox("Slit Valve is not close", AVPLib.Utils.chamberID2ChamberName(ChamberName), MessageBoxIcon.Stop)
            Return False
        End If
        Return True
    End Function

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        btnAutoVent.Click, btnAutoPumpDown.Click, btnIGDegas.Click, btnShutDownPower.Click, btnPumpPurge.Click, btnFastRegen.Click
        AVPLib.Log.guiLogger.Info("Enter Button_Click")
        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
        Dim strChamberName As String = String.Empty
        Try
            strValue = IIf(button.Status = SL_CustomButton.DisplayStatus.On, STR_ON, STR_OFF)
            strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + button.Name + "." + strValue)
            strChamberName = AVPLib.Utils.chamberID2ChamberName(ChamberHandle)
            Dim strSourceLogMessage As String = "[" + strChamberName + "]"

            If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                ''for button Vent/Abort Vent
                If button.Name = btnAutoVent.Name Then
                    If button.Status = SL_CustomButton.DisplayStatus.On Then
                        ''Stop Vent
                        m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   strSourceLogMessage + " Click Button Abort Vent")
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then
                        ''Start Vent
                        If CheckIsolationValve(ChamberHandle, VENT) Then
                            'if IsolationValve is OK
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                       strSourceLogMessage + " Click Button Start Vent")
                        End If
                    End If

                    ''for button PumpDown/Abort PumpDown======================
                ElseIf button.Name = btnAutoPumpDown.Name Then
                    If button.Status = SL_CustomButton.DisplayStatus.On Then
                        m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   strSourceLogMessage + " Click Button Abort Pump Down")
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then
                        If CheckIsolationValve(ChamberHandle, PUMP_DOWN) Then
                            'if IsolationValve is OK
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                       strSourceLogMessage + " Click Button Start Pump Down")
                        End If
                    End If

                    ''for button IGDegas============================
                ElseIf button.Name = btnIGDegas.Name Then
                    If button.Status = SL_CustomButton.DisplayStatus.On Then
                        m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   strSourceLogMessage + " Click Button Abort IG Degas")
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then
                        m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   strSourceLogMessage + " Click Button to Start IG Degas")
                    End If

                    ''for button PumpPurge============================
                ElseIf button.Name = btnPumpPurge.Name Then
                    If button.Status = SL_CustomButton.DisplayStatus.On Then
                        m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                           strSourceLogMessage + " Click Button Abort Pump Purge")
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then
                        m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                           strSourceLogMessage + " Click Button to Start Pump Purge")
                    End If
                    ''ShutDown Power============================
                ElseIf button.Name = btnShutDownPower.Name Then
                    m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                               strSourceLogMessage + " Click Button Shut Down Power")

                    ''Fast Regen========================================
                ElseIf button.Name = btnFastRegen.Name Then
                    If button.Status = SL_CustomButton.DisplayStatus.On Then
                        m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                               strSourceLogMessage + " Click Button Abort Fast Regen")

                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then
                        m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                               strSourceLogMessage + " Click Button Fast Regen")

                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Button_Click")
    End Sub

    Public Sub General_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
       btnCryoOn.Click, btnCryoOff.Click, btnAutoRegenOn.Click, btnAutoRegenOff.Click, _
      btnWaterPumpOff.Click, btnWaterPumpOn.Click, btnWPRegenOn.Click, btnWPRegenOff.Click
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim buttonName As String = button.Name
            Dim chamberName As String = AVPLib.Utils.chamberID2ChamberName(ChamberHandle)

            Dim Source As String = "PVD" & "." & button.Name
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)
            Utils.LogUserEvent(sender, chamberName)

            If Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                ''Cryo On/Off
                If buttonName = btnCryoOn.Name Then
                    If Utils.CheckHivacValveOpen_BeforeCryo(ChamberHandle) Then
                        Utils.LogUserEvent("Check Hivac Valve failed before Set Cryo On", chamberName)
                        Exit Sub
                    End If
                    m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                ElseIf buttonName = btnCryoOff.Name Then
                    If Utils.CheckHivacValveOpen_BeforeCryo(ChamberHandle) Then
                        Utils.LogUserEvent("Check Hivac Valve failed before Set Cryo Off", chamberName)
                        Exit Sub
                    End If
                    m_stoStatusObject.RequestStatus(button.Name, STR_OFF)

                    ''Auto Regen On/Off===================================
                ElseIf buttonName = btnAutoRegenOn.Name Then
                    If Utils.CheckHivacValveOpen_BeforeCryo(ChamberHandle) Then
                        Utils.LogUserEvent("Check Hivac Valve failed before Set Cryo Regen", chamberName)
                        Exit Sub
                    End If
                    m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                ElseIf buttonName = btnAutoRegenOff.Name Then
                    If Utils.CheckHivacValveOpen_BeforeCryo(ChamberHandle) Then
                        Utils.LogUserEvent("Check Hivac Valve failed before Abort Cryo Regen", chamberName)
                        Exit Sub
                    End If
                    m_stoStatusObject.RequestStatus(button.Name, STR_OFF)

                    ''Water Pump On/Off=================================
                ElseIf buttonName = btnWaterPumpOn.Name Then
                    m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                ElseIf buttonName = btnWaterPumpOff.Name Then
                    m_stoStatusObject.RequestStatus(button.Name, STR_OFF)

                    ''Water Pump Regen On/Off===========================
                ElseIf buttonName = btnWPRegenOn.Name Then
                    m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                ElseIf buttonName = btnWPRegenOff.Name Then
                    m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub Online_Offline_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                                 btnOnline.Click, btnOffline.Click
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strValue As String = String.Empty
            Dim buttonName As String = button.Name
            Dim Source As String = String.Empty
            If button.Name = btnOnline.Name Then
                strValue = STR_ON
                Source = AVPLib.ContainerData.GetMessageText("OnlineChamberPanel")
            Else
                strValue = STR_OFF
                Source = AVPLib.ContainerData.GetMessageText("OfflineChamberPanel")
            End If

            'Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim chamberName As String = AVPLib.Utils.chamberID2ChamberName(ChamberHandle)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + chamberName + "." + button.Name + "] Click ")

            If Utils.ShowAVPMessageBox(Source, chamberName, MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                m_stoStatusObject.RequestStatus(button.Name, strValue)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnOnline_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnline.StatusChange
        If String.IsNullOrEmpty(ChamberHandle) Then
            Exit Sub ''for initialize
        End If
        Dim objPVDPanel As PVDPanel = ContainerForm.ChamberPanel(ChamberHandle)
        If btnOnline.Status = SL_CustomButton.DisplayStatus.On Then
            btnOffline.Status = SL_CustomButton.DisplayStatus.Off
            objPVDPanel.IsOnline = True
            Action_for_Online_Offline(SL_CustomButton.DisplayStatus.On, False)
            If objPVDPanel IsNot Nothing Then
                objPVDPanel.lblChamberType.Text = objPVDPanel.lblChamberType.Tag & ConstantAndEnum.ONLINE_PM
            End If
            Panel3.Enabled = (btnOnline.Status = SL_CustomButton.DisplayStatus.Off)

        ElseIf btnOnline.Status = SL_CustomButton.DisplayStatus.Off Then
            Dim objPVD As AVPLib.DataManagerment.PVDChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objPVDPanel.Name)
            ''set maintanence mode
            If objPVD.ControlStatus = AVPLib.DataManagerment.Equipment.ControlStatuses.MAINTENANCE Then
                objPVDPanel.IsOnline = False
                objPVDPanel.IsMaintenanceMode = True
                objPVDPanel.IsEditable_InMaintenanceMode = objPVD.EditableIn_MaintenanceMode
                btnMaintenance.Visible = True
                btnOffline.Visible = False
                btnOnline.Visible = False
                Action_for_Online_Offline(SL_CustomButton.DisplayStatus.Off, True)
                Panel3.Enabled = objPVD.EditableIn_MaintenanceMode

            ElseIf objPVD.ControlStatus = AVPLib.DataManagerment.Equipment.ControlStatuses.OFFLINE Then
                btnMaintenance.Visible = False
                btnOffline.Visible = True
                btnOnline.Visible = True
                btnOffline.Status = SL_CustomButton.DisplayStatus.On
                objPVDPanel.IsOnline = False
                objPVDPanel.IsMaintenanceMode = False
                Action_for_Online_Offline(SL_CustomButton.DisplayStatus.Off, True)
                If objPVDPanel IsNot Nothing Then
                    objPVDPanel.lblChamberType.Text = objPVDPanel.lblChamberType.Tag & ConstantAndEnum.OFFLINE_PM
                End If
                Panel3.Enabled = (btnOnline.Status = SL_CustomButton.DisplayStatus.Off)
            End If
        End If
    End Sub

    Private Sub Action_for_Online_Offline(ByVal intIndexOfImage As Integer, ByVal blnValveEnableStatus As Boolean)
        AVPLib.Log.guiLogger.Info("Enter Action_for_Online_Offline")
        Try
            Dim PanelChamber As ChamberPanel = ContainerForm.ChamberPanel(ChamberHandle)
            PanelChamber.btnTooltipMachine.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
            If PanelChamber.ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                If CType(PanelChamber, PVDPanel).RFTargetPowerSupplyVisible Then
                    CType(PanelChamber, Chamber1RFPVDPanel).Online_OfflineValveStatus(blnValveEnableStatus, True)
                    CType(PanelChamber, Chamber1RFPVDPanel).btnPVDTooltipMachine.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
                ElseIf CType(PanelChamber, PVDPanel).DCTargetPowerSupplyVisible Then
                    CType(PanelChamber, Chamber1DCPVDPanel).Online_OfflineValveStatus(blnValveEnableStatus, True)
                    CType(PanelChamber, Chamber1DCPVDPanel).btnPVDTooltipMachine.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
                Else 'not DC or RF
                    CType(PanelChamber, PVDPanel).Online_OfflineValveStatus(blnValveEnableStatus, True)
                    CType(PanelChamber, PVDPanel).btnPVDTooltipMachine.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Action_for_Online_Offline")
    End Sub

    Private Sub btnCryoOnOff_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCryoOn.StatusChange
        If btnCryoOn.Status = SL_CustomButton.DisplayStatus.Off Then
            btnCryoOff.Status = SL_CustomButton.DisplayStatus.On
        ElseIf btnCryoOn.Status = SL_CustomButton.DisplayStatus.On Then
            btnCryoOff.Status = SL_CustomButton.DisplayStatus.Off
        ElseIf btnCryoOn.Status = SL_CustomButton.DisplayStatus.Unknow Then
            btnCryoOff.Status = SL_CustomButton.DisplayStatus.Unknow
        End If
    End Sub

    Private Sub btnAutoRegen_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoRegenOn.StatusChange
        If btnAutoRegenOn.Status = SL_CustomButton.DisplayStatus.Off Then
            btnAutoRegenOff.Status = SL_CustomButton.DisplayStatus.On
        ElseIf btnAutoRegenOn.Status = SL_CustomButton.DisplayStatus.On Then
            btnAutoRegenOff.Status = SL_CustomButton.DisplayStatus.Off
        ElseIf btnAutoRegenOn.Status = SL_CustomButton.DisplayStatus.Unknow Then
            btnAutoRegenOff.Status = SL_CustomButton.DisplayStatus.Unknow
        End If
    End Sub

    Private Sub btnWaterPumpOn_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaterPumpOn.StatusChange
        If btnWaterPumpOn.Status = SL_CustomButton.DisplayStatus.Off Then
            btnWaterPumpOff.Status = SL_CustomButton.DisplayStatus.On
        ElseIf btnWaterPumpOn.Status = SL_CustomButton.DisplayStatus.On Then
            btnWaterPumpOff.Status = SL_CustomButton.DisplayStatus.Off
        ElseIf btnWaterPumpOn.Status = SL_CustomButton.DisplayStatus.Unknow Then
            btnWaterPumpOff.Status = SL_CustomButton.DisplayStatus.Unknow
        End If
    End Sub

    Private Sub btnWPRegenOn_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWPRegenOn.StatusChange
        If btnWPRegenOn.Status = SL_CustomButton.DisplayStatus.Off Then
            btnWPRegenOff.Status = SL_CustomButton.DisplayStatus.On
        ElseIf btnWPRegenOn.Status = SL_CustomButton.DisplayStatus.On Then
            btnWPRegenOff.Status = SL_CustomButton.DisplayStatus.Off
        ElseIf btnWPRegenOn.Status = SL_CustomButton.DisplayStatus.Unknow Then
            btnWPRegenOff.Status = SL_CustomButton.DisplayStatus.Unknow
        End If
    End Sub

    Private Sub btnAutoPumpDown_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutoPumpDown.StatusChange
        If btnAutoPumpDown.Status = SL_CustomButton.DisplayStatus.On Then
            ManageEnableOfChamberControl(True, False, False, False, False)
        ElseIf btnAutoPumpDown.Status = SL_CustomButton.DisplayStatus.Off Then
            ManageEnableOfChamberControl(True, True, True, True, True)
        End If
    End Sub

    Private Sub btnAutoVent_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutoVent.StatusChange   
        If btnAutoVent.Status = SL_CustomButton.DisplayStatus.On Then
            ManageEnableOfChamberControl(False, True, False, False, False)
        ElseIf btnAutoVent.Status = SL_CustomButton.DisplayStatus.Off Then
            ManageEnableOfChamberControl(True, True, True, True, True)
        End If
    End Sub


    Private Sub ManageEnableOfChamberControl(ByVal blnAutoPumpDownEnable As Boolean, _
                                                            ByVal blnAutoVentEnable As Boolean, _
                                                            ByVal blnIGDegasEnable As Boolean, _
                                                            ByVal blnPumpPurgeEnable As Boolean, _
                                                            ByVal blnShowDownPowerEnable As Boolean)
        btnAutoPumpDown.Enabled = blnAutoPumpDownEnable
        btnAutoVent.Enabled = blnAutoVentEnable
        btnIGDegas.Enabled = blnIGDegasEnable
        btnPumpPurge.Enabled = blnPumpPurgeEnable
        btnShutDownPower.Enabled = blnShowDownPowerEnable
    End Sub
#End Region

End Class