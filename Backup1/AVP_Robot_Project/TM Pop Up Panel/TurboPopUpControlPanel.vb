Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVPControls

Public Class TurboPopUpControlPanel
    Public blnGoOnline As Boolean = False

    'Info design - 1 LL install
    Private TITLE_LABLE_WITH_ONE_LL_SIZE As New Size(750, 40)
    Private BUTTON_CANCEL_WITH_ONE_LL_LOCATION As New Point(750, 0)
    Private LL_WITH_ONE_LL_LOCATION As New Point(405, 40)
    Private FORM_WITH_ONE_LL_SIZE As New Size(805, 399)
    'Info design - 0 LL install
    Private TITLE_LABLE_WITH_NO_LL_SIZE As New Size(355, 40)
    Private BUTTON_CANCEL_WITH_NO_LL_LOCATION As New Point(355, 0)
    Private FORM_WITH_NO_LL_SIZE As New Size(407, 399)

#Region "Properties"
    Public Property PopUpTitle() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

#End Region

#Region "Private methods"
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbtTMOnlineStatus As New StatusTM_PopUpButton(btnTMOnline)
            Dim sbtTMOfflineStatus As New StatusTM_PopUpButton(btnTMOffline)
            Dim sbtTMAutoPumpDown As New StatusTM_PopUpButton(btnTMAutoPumpDown)
            Dim sbtTMAutoVent As New StatusTM_PopUpButton(btnTMAutoVent)
            Dim sbtTMCryoOn As New StatusTM_PopUpButton(btnTMCryoOn)
            Dim sbtTMCryoRegen As New StatusTM_PopUpButton(btnTMCryoRegen)
            Dim sbtTMFastRegen As New StatusTM_PopUpButton(btnTMFastRegen)
            Dim sbtTMIGDegas As New StatusTM_PopUpButton(btnTMIGDegas)

            Dim sbtLLAOnlineStatus As New StatusTM_PopUpButton(btnLLAOnline)
            Dim sbtLLAOfflineStatus As New StatusTM_PopUpButton(btnLLAOffline)
            Dim sbtLLAAutoPumpDown As New StatusTM_PopUpButton(btnLLAAutoPumpDown)
            Dim sbtLLAAutoVent As New StatusTM_PopUpButton(btnLLAAutoVent)
            Dim sbtLLACryoOn As New StatusTM_PopUpButton(btnLLACryoOn)
            Dim sbtLLACryoRegen As New StatusTM_PopUpButton(btnLLACryoRegen)
            Dim sbtLLAFastRegen As New StatusTM_PopUpButton(btnLLACryoFastRegen)
            Dim sbtLLAIGDegas As New StatusTM_PopUpButton(btnLLAIGDegas)

            Dim stbTMRegenHour As New StatusTM_PopUpTextbox(txtTMCryo_RegenHours)
            Dim stbTMLifeTimeHour As New StatusTM_PopUpTextbox(txtTMCryo_LifeTimeHours)
            Dim stbLLARegenHour As New StatusTM_PopUpTextbox(txtLLACryo_RegenHours)
            Dim stbLLALifeTimeHour As New StatusTM_PopUpTextbox(txtLLACryo_LifeTimeHours)
            Dim stbTMCryoRegenStatus As New StatusTM_PopUpTextbox(txtTMCryoRegenStatus)
            Dim stbLLACryoRegenStatus As New StatusTM_PopUpTextbox(txtLLACryoRegenStatus)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbTMRegenHour)
            m_stoStatusObject.AddChild(stbTMLifeTimeHour)
            m_stoStatusObject.AddChild(stbLLARegenHour)
            m_stoStatusObject.AddChild(stbLLALifeTimeHour)

            m_stoStatusObject.AddChild(sbtTMOnlineStatus)
            m_stoStatusObject.AddChild(sbtTMOfflineStatus)
            m_stoStatusObject.AddChild(sbtLLAOnlineStatus)
            m_stoStatusObject.AddChild(sbtLLAOfflineStatus)

            m_stoStatusObject.AddChild(sbtTMAutoPumpDown)
            m_stoStatusObject.AddChild(sbtTMAutoVent)
            m_stoStatusObject.AddChild(sbtTMCryoOn)
            m_stoStatusObject.AddChild(sbtTMCryoRegen)
            m_stoStatusObject.AddChild(sbtTMFastRegen)
            m_stoStatusObject.AddChild(sbtTMIGDegas)
            m_stoStatusObject.AddChild(sbtLLAIGDegas)

            m_stoStatusObject.AddChild(sbtLLAAutoPumpDown)
            m_stoStatusObject.AddChild(sbtLLAAutoVent)
            m_stoStatusObject.AddChild(sbtLLACryoOn)
            m_stoStatusObject.AddChild(sbtLLACryoRegen)
            m_stoStatusObject.AddChild(sbtLLAFastRegen)

            m_stoStatusObject.AddChild(stbTMCryoRegenStatus)
            m_stoStatusObject.AddChild(stbLLACryoRegenStatus)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            btnTMOnline.Clickable = True
            btnTMOnline.ValueToBeSend = ""

            btnLLAOnline.Clickable = True
            btnLLAOnline.ValueToBeSend = ""

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

#Region "Online button"
    Friend Sub btnTMOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMOnline.Click, btnLLAOnline.Click
        AVPLib.Log.guiLogger.Info("Enter btnTMOnline_Click")
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strMessageText As String = String.Empty
            If blnGoOnline Then
                If button.Name = btnTMOnline.Name Then
                    m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring TM online")
                ElseIf button.Name = btnLLAOnline.Name Then
                    m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring LLA online")
                End If
                Exit Sub
            End If
            If button.Name = btnTMOnline.Name Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOnlineOfCassettesPanel"), ONLINETM)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring TM online")
                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                    'ContainerForm.CassettesPanel.SetTMOnline(True)
                    m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
                End If

            ElseIf button.Name = btnLLAOnline.Name Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOnlineOfCassettesPanel"), ONLINELOADLOCKA)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring LLA online")
                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                    'ContainerForm.CassettesPanel.SetLLAOnline(True)
                    m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnTMOnline_Click")
    End Sub

    Private Sub btnTMOffline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMOffline.Click, btnLLAOffline.Click
        AVPLib.Log.guiLogger.Info("Enter btnTMOffline_Click")
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strMessageText As String = String.Empty
            If button.Name = btnTMOffline.Name Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOfflineOfCassettesPanel"), ONLINETM)
                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                    'ContainerForm.CassettesPanel.SetTMOnline(False)
                    m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring TM offline")
                End If

            ElseIf button.Name = btnLLAOffline.Name Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOfflineOfCassettesPanel"), ONLINELOADLOCKA)
                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                    'ContainerForm.CassettesPanel.LeftValveStatus(True)
                    'ContainerForm.CassettesPanel.SetLLAOnline(False)
                    m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring LLA offline")
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnTMOffline_Click")
    End Sub

    Private Sub btnLLAOnline_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLLAOnline.StatusChange
        If btnLLAOnline.Status = SL_CustomButton.DisplayStatus.On Then
            btnLLAOffline.Status = SL_CustomButton.DisplayStatus.Off
            btnLLAAutoPumpDown.Enabled = False
            btnLLAAutoVent.Enabled = False
            btnLLAIGDegas.Enabled = False
            btnLLACryoFastRegen.Enabled = False
            btnLLACryoOn.Enabled = False
            btnLLACryoRegen.Enabled = False
        ElseIf btnLLAOnline.Status = SL_CustomButton.DisplayStatus.Off Then
            btnLLAOffline.Status = SL_CustomButton.DisplayStatus.On
            If btnLLAAutoVent.Status = SL_CustomButton.DisplayStatus.Off Then
                btnLLAAutoPumpDown.Enabled = True
            End If
            If btnLLAAutoPumpDown.Status = SL_CustomButton.DisplayStatus.Off Then
                btnLLAAutoVent.Enabled = True
            End If
            If btnLLAIGDegas.Status = SL_CustomButton.DisplayStatus.Off Then
                btnLLAIGDegas.Enabled = True
            End If
            btnLLACryoFastRegen.Enabled = True
            btnLLACryoOn.Enabled = True
            btnLLACryoRegen.Enabled = True
        End If
    End Sub

    Private Sub btntmOnline_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTMOnline.StatusChange
        If btnTMOnline.Status = SL_CustomButton.DisplayStatus.On Then
            btnTMOffline.Status = SL_CustomButton.DisplayStatus.Off
            btnTMAutoPumpDown.Enabled = False
            btnTMAutoVent.Enabled = False
            btnTMIGDegas.Enabled = False
            btnTMFastRegen.Enabled = False
            btnTMCryoOn.Enabled = False
            btnTMCryoRegen.Enabled = False
            ContainerForm.ProcessPanel.TMCtl.lblHeader.ForeColor = Color.Black
            ContainerForm.ProcessPanel.TMCtl.lblHeader.Text = ContainerForm.ProcessPanel.TMCtl.HeaderText_Online
            ContainerForm.ProcessPanel.TMCtl.pnlHeader.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        ElseIf btnTMOnline.Status = SL_CustomButton.DisplayStatus.Off Then
            btnTMOffline.Status = SL_CustomButton.DisplayStatus.On
            btnTMAutoPumpDown.Enabled = True
            btnTMAutoVent.Enabled = True
            If btnTMIGDegas.Status = SL_CustomButton.DisplayStatus.Off Then
                btnTMIGDegas.Enabled = True
            End If
            btnTMFastRegen.Enabled = True
            btnTMCryoOn.Enabled = True
            btnTMCryoRegen.Enabled = True
            ContainerForm.ProcessPanel.TMCtl.lblHeader.ForeColor = Color.White
            ContainerForm.ProcessPanel.TMCtl.lblHeader.Text = ContainerForm.ProcessPanel.TMCtl.HeaderText_Offline
            ContainerForm.ProcessPanel.TMCtl.pnlHeader.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        End If
    End Sub
#End Region

#Region "Vent, Pump Down"
    'Public Sub Enable_Disable_TM_Vent_PumpDown(ByVal EnableVent As Boolean, ByVal EnablePumpDown As Boolean)
    '    If EnableVent Then
    '        btnTMAutoPumpDown.Enabled = Not (EnableVent)
    '        btnTMOnline.Enabled = Not (EnableVent)
    '        btnTMOffline.Enabled = Not (EnableVent)
    '    End If
    '    If EnablePumpDown Then
    '        btnTMAutoVent.Enabled = Not (EnablePumpDown)
    '        btnTMOnline.Enabled = Not (EnablePumpDown)
    '        btnTMOffline.Enabled = Not (EnablePumpDown)
    '    End If
    'End Sub
    Public Sub TMAutoPumdown()
        If btnTMAutoPumpDown.Status = SL_CustomButton.DisplayStatus.On Then ''Abort Pump Down
            m_stoStatusObject.RequestStatus(btnTMAutoPumpDown.Name, STR_OFF)
            ' Pulse Event
            ContainerForm.CassettesPanel.PumpDown(False, True, STR_OFF)
            ContainerForm.CassettesPanel.m_evtTMVentPumpdownInProgress.Reset()
        ElseIf btnTMAutoPumpDown.Status = SL_CustomButton.DisplayStatus.Off Then '' Pump Down
            m_stoStatusObject.RequestStatus(btnTMAutoPumpDown.Name, STR_ON)
            ' Pulse Event
            ContainerForm.CassettesPanel.PumpDown(False, True, STR_ON)
            ContainerForm.CassettesPanel.m_evtTMVentPumpdownInProgress.Set()
        End If
    End Sub
    Public Sub LLAAutoPumpdown()
        If btnLLAAutoPumpDown.Status = SL_CustomButton.DisplayStatus.On Then ''Abort Pump Down
            m_stoStatusObject.RequestStatus(btnLLAAutoPumpDown.Name, STR_OFF)
            ' Pulse Event
            ContainerForm.CassettesPanel.PumpDown(True, False, STR_OFF)
            ContainerForm.CassettesPanel.m_evtLLAVentPumpdownInProgress.Reset()
        ElseIf btnLLAAutoPumpDown.Status = SL_CustomButton.DisplayStatus.Off Then
            m_stoStatusObject.RequestStatus(btnLLAAutoPumpDown.Name, STR_ON)
            ' Pulse Event
            ContainerForm.CassettesPanel.PumpDown(True, False, STR_ON)
            ContainerForm.CassettesPanel.m_evtLLAVentPumpdownInProgress.Set()
        End If
    End Sub
    Private Sub btnPumpDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMAutoPumpDown.Click, btnLLAAutoPumpDown.Click
        AVPLib.Log.guiLogger.Info("Enter btnPumpDown_Click")
        Dim strMessageText As String = String.Empty
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Select Case button.Name
                Case btnTMAutoPumpDown.Name
                    If button.Status = SL_CustomButton.DisplayStatus.On Then ''Abort Pump Down
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopPumpDownOfCassettesPanel"), ONLINETM)
                        If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.PumpDown(False, True, STR_OFF)
                            ContainerForm.CassettesPanel.m_evtTMVentPumpdownInProgress.Reset()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Abort TM Pump down")
                        End If
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then '' Pump Down
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuPumpDownOfCassettesPanel"), ONLINETM)
                        If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.PumpDown(False, True, STR_ON)
                            ContainerForm.CassettesPanel.m_evtTMVentPumpdownInProgress.Set()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Start TM Pump down")
                        End If
                    End If

                Case btnLLAAutoPumpDown.Name
                    If button.Status = SL_CustomButton.DisplayStatus.On Then ''Abort Pump Down
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopPumpDownOfCassettesPanel"), ONLINELOADLOCKA)
                        If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.PumpDown(True, False, STR_OFF)
                            ContainerForm.CassettesPanel.m_evtLLAVentPumpdownInProgress.Reset()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Abort LLA Pump down")
                        End If
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuPumpDownOfCassettesPanel"), ONLINELOADLOCKA)
                        If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.PumpDown(True, False, STR_ON)
                            ContainerForm.CassettesPanel.m_evtLLAVentPumpdownInProgress.Set()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Start LLA Pump down")
                        End If
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnPumpDown_Click")
    End Sub

    Private Sub btnVent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMAutoVent.Click, btnLLAAutoVent.Click
        AVPLib.Log.guiLogger.Info("Enter btnVent_Click")
        Dim strMessageText As String = String.Empty
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Select Case button.Name
                Case btnTMAutoVent.Name
                    If button.Status = SL_CustomButton.DisplayStatus.On Then ''Abort Pump Down
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopVentOfCassettesPanel"), ONLINETM)
                        If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.Vent(False, True, STR_OFF)
                            ContainerForm.CassettesPanel.m_evtTMVentPumpdownInProgress.Reset()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Abort TM Vent")
                        End If
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then '' Pump Down
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuVentOfCassettesPanel"), ONLINETM)
                        If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.Vent(False, True, STR_ON)
                            ContainerForm.CassettesPanel.m_evtTMVentPumpdownInProgress.Set()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Start TM Vent")
                        End If
                    End If

                Case btnLLAAutoVent.Name
                    If button.Status = SL_CustomButton.DisplayStatus.On Then ''Abort Pump Down
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopVentOfCassettesPanel"), ONLINELOADLOCKA)
                        If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.Vent(True, False, STR_OFF)
                            ContainerForm.CassettesPanel.m_evtLLAVentPumpdownInProgress.Reset()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Abort LLA Vent")
                        End If
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuVentOfCassettesPanel"), ONLINELOADLOCKA)
                        If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.Vent(True, False, STR_ON)
                            ContainerForm.CassettesPanel.m_evtLLAVentPumpdownInProgress.Set()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Start LLA Vent")
                        End If
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnVent_Click")
    End Sub

    Private Sub btnTMAutoPumpDown_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTMAutoPumpDown.StatusChange
        If btnTMAutoPumpDown.Status = SL_CustomButton.DisplayStatus.On Then
            btnTMAutoVent.Enabled = False
            btnTMIGDegas.Enabled = False
        Else
            If btnTMOnline.Status = SL_CustomButton.DisplayStatus.Off Then
                btnTMAutoVent.Enabled = True
                btnTMIGDegas.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnTMAutoVent_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTMAutoVent.StatusChange, btnTMIGDegas.StatusChange
        If btnTMAutoVent.Status = SL_CustomButton.DisplayStatus.On Then
            btnTMAutoPumpDown.Enabled = False
            btnTMIGDegas.Enabled = False
        Else
            If btnTMOnline.Status = SL_CustomButton.DisplayStatus.Off Then
                btnTMAutoPumpDown.Enabled = True
                btnTMIGDegas.Enabled = True
            End If
        End If

    End Sub

    Private Sub btnLLAAutoPumpDown_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLLAAutoPumpDown.StatusChange
        If btnLLAAutoPumpDown.Status = SL_CustomButton.DisplayStatus.On Then
            btnLLAAutoVent.Enabled = False
            btnLLAIGDegas.Enabled = False
        Else
            If btnLLAOnline.Status = SL_CustomButton.DisplayStatus.Off Then
                btnLLAAutoVent.Enabled = True
                btnLLAIGDegas.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnLLAAutoVent_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLLAAutoVent.StatusChange, btnLLAIGDegas.StatusChange
        If btnLLAAutoVent.Status = SL_CustomButton.DisplayStatus.On Then
            btnLLAAutoPumpDown.Enabled = False
            btnLLAIGDegas.Enabled = False
        Else
            If btnLLAOnline.Status = SL_CustomButton.DisplayStatus.Off Then
                btnLLAAutoPumpDown.Enabled = True
                btnLLAIGDegas.Enabled = True
            End If
        End If
    End Sub

#End Region

#Region "All Cryo button"
    Private Sub btnTMCryoOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMCryoOn.Click, btnLLACryoOn.Click
        AVPLib.Log.guiLogger.Info("Enter btnTMCryoOn_Click")
        If sender Is btnTMCryoOn Then
            ContainerForm.CassettesPanel.crcTMCryo.btnOn_Click(sender, e)
        ElseIf sender Is btnLLACryoOn Then
            ContainerForm.CassettesPanel.crcLLACryo.btnOn_Click(sender, e)
        End If
        AVPLib.Log.guiLogger.Info("Leave btnTMCryoOn_Click")
    End Sub

    Private Sub btnTMCryoRegen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMCryoRegen.Click, btnLLACryoRegen.Click
        AVPLib.Log.guiLogger.Info("Enter btnTMCryoRegen_Click")
        If sender Is btnTMCryoRegen Then
            ContainerForm.CassettesPanel.crcTMCryo.btnRegen_Click(sender, e)
        ElseIf sender Is btnLLACryoRegen Then
            ContainerForm.CassettesPanel.crcLLACryo.btnRegen_Click(sender, e)
        End If
        AVPLib.Log.guiLogger.Info("Leave btnTMCryoRegen_Click")
    End Sub

    Private Sub btnTMFastRegen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMFastRegen.Click, btnLLACryoFastRegen.Click
        AVPLib.Log.guiLogger.Info("Enter btnTMCryoRegen_Click")
        If sender Is btnTMFastRegen Then
            ContainerForm.CassettesPanel.crcTMCryo.btnFastRegen_Click(sender, e)
        ElseIf sender Is btnLLACryoFastRegen Then
            ContainerForm.CassettesPanel.crcLLACryo.btnFastRegen_Click(sender, e)
        End If
        AVPLib.Log.guiLogger.Info("Leave btnTMCryoRegen_Click")
    End Sub

#End Region

#Region "Events"
    Private Sub btnIGDegas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLLAIGDegas.Click, btnTMIGDegas.Click
        AVPLib.Log.guiLogger.Info("Enter btnIGDegas_Click")
        Dim strMessageText As String = AVPLib.ContainerData.GetMessageText("MenuIGDegasOfCassettesPanel")
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Select Case button.Name
                Case btnLLAIGDegas.Name
                    strMessageText = String.Format(strMessageText, ONLINELOADLOCKA)
                    If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring IG Degas of " & ONLINELOADLOCKA)
                Case btnTMIGDegas.Name
                    strMessageText = String.Format(strMessageText, ONLINETM)
                    If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring IG Degas of " & ONLINETM)
            End Select
            'button.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnIGDegas_Click")
    End Sub

#End Region

#Region "Public methods"
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-26</date>
    ''' </author>
    ''' <summary>
    ''' Show TM pop up with LLA installed.  
    ''' </summary>
    ''' <param name="IsLLAInstalled"></param>
    ''' <param name="IsLLBInstalled"></param>
    ''' <remarks></remarks>
    Public Sub ConfigShowGUI(ByVal IsLLAInstalled As Boolean)
        If Not IsLLAInstalled Then
            gbLLA.Visible = False
            Me.Size = FORM_WITH_NO_LL_SIZE
        Else
            gbLLA.Location = LL_WITH_ONE_LL_LOCATION
            Me.Size = FORM_WITH_ONE_LL_SIZE
        End If
    End Sub
#End Region

End Class
