Imports System.Runtime.CompilerServices
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls
Imports AVPLib
Imports AVPLib.ConstEnum
Imports Microsoft.VisualBasic.CompilerServices

Public Class CORONAPopUpPanel
    Private m_strChamberHandle As String = String.Empty

    Public Property ChamberHandle() As String
        Get
            Return m_strChamberHandle
        End Get
        Set(ByVal value As String)
            m_strChamberHandle = value
        End Set
    End Property
    Private m_strChamberType As SystemModule.ModuleType = SystemModule.ModuleType.PVD4
    Public Property ChamberType() As SystemModule.ModuleType
        Get
            Return m_strChamberType
        End Get
        Set(ByVal value As SystemModule.ModuleType)
            m_strChamberType = value
        End Set
    End Property
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbPDC As New StatusCoronaButton(btnPDC)
            Dim stbCryoOnOff As New StatusCoronaButton(btnCryoOn)
            Dim stbAutoVent As New StatusCoronaButton(btnAutoVent)
            Dim stbAutoRegen As New StatusCoronaButton(btnAutoRegenOn)
            Dim stbAutoPumpDown As New StatusCoronaButton(btnAutoPumpDown)
            Dim stbIGDegas As New StatusCoronaButton(btnIGDegas)

            Dim stCryoRegenHour As New StatusPVD_PopUpTextBox(txtCryoRegenHour)
            Dim stCryoLifeTime As New StatusPVD_PopUpTextBox(txtCryoLifeTimeHour)
            Dim stWaterRegenHour As New StatusPVD_PopUpTextBox(txtWaterPumpRegenHour)
            Dim stWaterLifeTime As New StatusPVD_PopUpTextBox(txtWaterPumpLifeTimeHour)

            Dim sbtOnlineStatus As New StatusCoronaButton(btnOnline)
            Dim sbtOfflineStatus As New StatusCoronaButton(btnOffline)
            Dim sbtMaintenanceStatus As New StatusCoronaButton(btnMaintenance)
            Dim sbtPumpPurge As New StatusCoronaButton(btnPumpPurge)
            Dim sbtRORStatus As New StatusCoronaButton(btnROR)
            Dim sbtWPRegenOn As New StatusCoronaButton(btnWPRegenOn)
            Dim sbtShutDownPower As New StatusCoronaButton(btnShutDownPower)
            Dim sbtWPRegenOff As New StatusCoronaButton(btnWPRegenOff)
            Dim sbtWaterPumpOn As New StatusCoronaButton(btnWaterPumpOn)
            Dim sbtWaterPumpOff As New StatusCoronaButton(btnWaterPumpOff)
            Dim stbRegenStatus As New StatusPVD_PopUpTextBox(txtRegenStatus)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbRegenStatus)
            m_stoStatusObject.AddChild(stbPDC)
            m_stoStatusObject.AddChild(stbCryoOnOff)
            m_stoStatusObject.AddChild(stbAutoVent)
            m_stoStatusObject.AddChild(stbAutoRegen)
            m_stoStatusObject.AddChild(stbAutoPumpDown)
            m_stoStatusObject.AddChild(stbIGDegas)
            m_stoStatusObject.AddChild(sbtShutDownPower)

            m_stoStatusObject.AddChild(stCryoRegenHour)
            m_stoStatusObject.AddChild(stCryoLifeTime)
            m_stoStatusObject.AddChild(stWaterRegenHour)
            m_stoStatusObject.AddChild(stWaterLifeTime)

            m_stoStatusObject.AddChild(sbtOnlineStatus)
            m_stoStatusObject.AddChild(sbtOfflineStatus)
            m_stoStatusObject.AddChild(sbtMaintenanceStatus)
            m_stoStatusObject.AddChild(sbtPumpPurge)
            m_stoStatusObject.AddChild(sbtRORStatus)
            m_stoStatusObject.AddChild(sbtWPRegenOn)
            m_stoStatusObject.AddChild(sbtWPRegenOff)
            m_stoStatusObject.AddChild(sbtWaterPumpOn)
            m_stoStatusObject.AddChild(sbtWaterPumpOff)

            btnOnline.ParentStatusObj = m_stoStatusObject
            btnOffline.ParentStatusObj = m_stoStatusObject
            btnMaintenance.ParentStatusObj = m_stoStatusObject
            btnPumpPurge.ParentStatusObj = m_stoStatusObject
            btnAutoPumpDown.ParentStatusObj = m_stoStatusObject
            btnAutoVent.ParentStatusObj = m_stoStatusObject
            btnIGDegas.ParentStatusObj = m_stoStatusObject
            btnShutDownPower.ParentStatusObj = m_stoStatusObject

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

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

    Public Sub General_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
       btnCryoOn.Click, btnCryoOff.Click, btnAutoRegenOn.Click, btnAutoRegenOff.Click, _
       btnWaterPumpOff.Click, btnWaterPumpOn.Click, btnWPRegenOn.Click, btnWPRegenOff.Click
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strValue As String = String.Empty
            Dim buttonName As String = button.Name
            'If button.Status = SL_CustomButton.DisplayStatus.On Then
            '    strValue = STR_OFF
            'Else
            '    strValue = STR_ON
            'End If

            If buttonName = btnCryoOff.Name Or buttonName = btnAutoRegenOff.Name Or _
               buttonName = btnWPRegenOff.Name Or buttonName = btnWaterPumpOff.Name Then
                strValue = STR_OFF
            Else
                strValue = STR_ON
            End If

            Dim Source As String = "PVD4" & "." & button.Name
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)

            Dim chamberName As String = String.Empty

            chamberName = AVPLib.Utils.chamberID2ChamberName(m_stoStatusObject.Name)
            If String.IsNullOrEmpty(chamberName) OrElse Not m_stoStatusObject.Name.StartsWith(AVPLib.ConstEnum.Chamber) Then
                chamberName = AVPLib.Utils.chamberID2ChamberName(m_stoStatusObject.Parent.Name)
            End If
            Utils.LogUserEvent(sender, chamberName)
            If Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                If buttonName = btnAutoRegenOn.Name Then
                    If Utils.CheckHivacValveOpen_BeforeCryo(ChamberHandle) Then
                        Utils.LogUserEvent("Check Hivac Valve failed before Set Cryo Regen", chamberName)
                        Exit Sub
                    End If
                End If
                m_stoStatusObject.RequestStatus(button.Name, strValue)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub SetOnlineOfflinePopUp(ByVal blnIsOnline As Boolean)
        'grbChamber.Enabled = Not blnIsOnline
        grbWaterPump.Enabled = Not blnIsOnline
        grbCryo.Enabled = Not blnIsOnline
    End Sub

    Private Sub btnOnline_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnline.StatusChange
        If String.IsNullOrEmpty(ChamberHandle) Then
            Exit Sub ''for initialize
        End If

        If ChamberType = SystemModule.ModuleType.PVD4 Then
            Dim objCoronaPanel As CoronaPanel = ContainerForm.ChamberPanel(ChamberHandle)
            If btnOnline.Status = SL_CustomButton.DisplayStatus.On Then
                btnOffline.Status = SL_CustomButton.DisplayStatus.Off
                objCoronaPanel.IsOnline = True
                Action_for_Online_Offline(SL_CustomButton.DisplayStatus.On, False)
                If objCoronaPanel IsNot Nothing Then
                    objCoronaPanel.lblChamberType.Text = objCoronaPanel.lblChamberType.Tag & ConstantAndEnum.ONLINE_PM
                End If
                PopUpPanel.Enabled = (btnOnline.Status = SL_CustomButton.DisplayStatus.Off)

            ElseIf btnOnline.Status = SL_CustomButton.DisplayStatus.Off Then
                Dim objCorona As AVPLib.DataManagerment.CoronaChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objCoronaPanel.Name)
                ''set maintanence mode
                If objCorona.ControlStatus = AVPLib.DataManagerment.Equipment.ControlStatuses.MAINTENANCE Then
                    objCoronaPanel.SetMaintenanceMode(objCorona.EditableIn_MaintenanceMode, True)
                    objCoronaPanel.IsOnline = False
                    objCoronaPanel.IsMaintenanceMode = True
                    objCoronaPanel.IsEditable_InMaintenanceMode = objCorona.EditableIn_MaintenanceMode
                    btnMaintenance.Visible = True
                    btnOffline.Visible = False
                    btnOnline.Visible = False
                    Action_for_Online_Offline(SL_CustomButton.DisplayStatus.Off, True)
                    If objCoronaPanel IsNot Nothing Then
                        objCoronaPanel.lblChamberType.Text = objCoronaPanel.lblChamberType.Tag & "(" & ConstantAndEnum.STRING_MAINTENANCE & ")"
                    End If
                    PopUpPanel.Enabled = objCorona.EditableIn_MaintenanceMode

                ElseIf objCorona.ControlStatus = AVPLib.DataManagerment.Equipment.ControlStatuses.OFFLINE Then
                    btnMaintenance.Visible = False
                    btnOffline.Visible = True
                    btnOnline.Visible = True
                    btnOffline.Status = SL_CustomButton.DisplayStatus.On
                    objCoronaPanel.IsOnline = False
                    objCoronaPanel.IsMaintenanceMode = False
                    Action_for_Online_Offline(SL_CustomButton.DisplayStatus.Off, True)
                    If objCoronaPanel IsNot Nothing Then
                        objCoronaPanel.lblChamberType.Text = objCoronaPanel.lblChamberType.Tag & ConstantAndEnum.OFFLINE_PM
                    End If
                    PopUpPanel.Enabled = (btnOnline.Status = SL_CustomButton.DisplayStatus.Off)
                    objCoronaPanel.SetMaintenanceMode(True, False)
                End If
            End If
        ElseIf ChamberType = SystemModule.ModuleType.PVD5T Then
            Dim objPanel As PVD5TPanel = ContainerForm.ChamberPanel(ChamberHandle)
            If btnOnline.Status = SL_CustomButton.DisplayStatus.On Then
                btnOffline.Status = SL_CustomButton.DisplayStatus.Off
                objPanel.IsOnline = True
                Action_for_Online_Offline(SL_CustomButton.DisplayStatus.On, False)
                If objPanel IsNot Nothing Then
                    objPanel.lblChamberType.Text = objPanel.lblChamberType.Tag & ConstantAndEnum.ONLINE_PM
                End If
                PopUpPanel.Enabled = (btnOnline.Status = SL_CustomButton.DisplayStatus.Off)

            ElseIf btnOnline.Status = SL_CustomButton.DisplayStatus.Off Then
                Dim objCorona As AVPLib.DataManagerment.PVD5TChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objPanel.Name)
                ''set maintanence mode
                If objCorona.ControlStatus = AVPLib.DataManagerment.Equipment.ControlStatuses.MAINTENANCE Then
                    objPanel.SetMaintenanceMode(objCorona.EditableIn_MaintenanceMode, True)
                    objPanel.IsOnline = False
                    objPanel.IsMaintenanceMode = True
                    objPanel.IsEditable_InMaintenanceMode = objCorona.EditableIn_MaintenanceMode
                    btnMaintenance.Visible = True
                    btnOffline.Visible = False
                    btnOnline.Visible = False
                    Action_for_Online_Offline(SL_CustomButton.DisplayStatus.Off, True)
                    If objPanel IsNot Nothing Then
                        objPanel.lblChamberType.Text = objPanel.lblChamberType.Tag & "(" & ConstantAndEnum.STRING_MAINTENANCE & ")"
                    End If
                    PopUpPanel.Enabled = objCorona.EditableIn_MaintenanceMode

                ElseIf objCorona.ControlStatus = AVPLib.DataManagerment.Equipment.ControlStatuses.OFFLINE Then
                    btnMaintenance.Visible = False
                    btnOffline.Visible = True
                    btnOnline.Visible = True
                    btnOffline.Status = SL_CustomButton.DisplayStatus.On
                    objPanel.IsOnline = False
                    objPanel.IsMaintenanceMode = False
                    Action_for_Online_Offline(SL_CustomButton.DisplayStatus.Off, True)
                    If objPanel IsNot Nothing Then
                        objPanel.lblChamberType.Text = objPanel.lblChamberType.Tag & ConstantAndEnum.OFFLINE_PM
                    End If
                    PopUpPanel.Enabled = (btnOnline.Status = SL_CustomButton.DisplayStatus.Off)
                    objPanel.SetMaintenanceMode(True, False)
                End If
            End If
        End If

    End Sub

    Private Sub Action_for_Online_Offline(ByVal intIndexOfImage As Integer, ByVal blnValveEnableStatus As Boolean)
        AVPLib.Log.guiLogger.Info("Enter Action_for_Online_Offline")
        Try
            Dim PanelChamber As ChamberPanel = ContainerForm.ChamberPanel(ChamberHandle)
            PanelChamber.btnTooltipMachine.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
            If PanelChamber.ChamberType = AVPLib.SystemModule.ModuleType.PVD4 Then
                CType(PanelChamber, CoronaPanel).CoronaChamber.btnCtxMenu.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
            ElseIf PanelChamber.ChamberType = SystemModule.ModuleType.PVD5T Then
                CType(PanelChamber, PVD5TPanel).CoronaChamber.btnCtxMenu.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Action_for_Online_Offline")
    End Sub

    Public Sub ManageEnableOfChamberControl(ByVal blnAutoPumpDownEnable As Boolean, _
                                                           ByVal blnAutoVentEnable As Boolean, _
                                                           ByVal blnIGDegasEnable As Boolean, _
                                                           ByVal blnPumpPurgeEnable As Boolean, _
                                                           ByVal blnShutDownPowerEnable As Boolean)

        Dim isAllEnable As Boolean = blnAutoPumpDownEnable And blnAutoVentEnable And _
                                     blnIGDegasEnable And blnPumpPurgeEnable And _
                                     blnShutDownPowerEnable

        Dim isAnySequenceRunning As Boolean = (btnAutoPumpDown.Status = SL_CustomButton.DisplayStatus.On Or _
                                               btnAutoVent.Status = SL_CustomButton.DisplayStatus.On Or _
                                               btnIGDegas.Status = SL_CustomButton.DisplayStatus.On Or _
                                               btnPumpPurge.Status = SL_CustomButton.DisplayStatus.On Or _
                                               btnShutDownPower.Status = SL_CustomButton.DisplayStatus.On)

        If isAllEnable AndAlso isAnySequenceRunning Then
            Return
        End If

        btnAutoPumpDown.Enabled = blnAutoPumpDownEnable
        btnAutoVent.Enabled = blnAutoVentEnable
        btnIGDegas.Enabled = blnIGDegasEnable
        btnPumpPurge.Enabled = blnPumpPurgeEnable
        btnShutDownPower.Enabled = blnShutDownPowerEnable
    End Sub

    Private Sub btnShutDownPower_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShutDownPower.StatusChange
        If btnShutDownPower.Status = DisplayStatus.On Then
            btnShutDownPower.Clickable = False
        Else
            btnShutDownPower.Clickable = True
        End If
    End Sub
End Class