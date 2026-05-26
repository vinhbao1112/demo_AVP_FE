Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVPControls

Public Class TMPopUpPanel
    Public blnGoOnline As Boolean = False

    'Info design - 1 LL install
    Private LL_WITH_ONE_LL_LOCATION As New Point(342, 40)
    Private FORM_WITH_ONE_LL_SIZE As New Size(678, 241)
    'Info design - 0 LL install
    Private FORM_WITH_NO_LL_SIZE As New Size(336, 241)

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

            'btnLLAOffline.Left = btnLLAOnline.Left + btnLLAOnline.Width + 40
            'btnTMOffline.Left = btnTMOnline.Left + btnTMOnline.Width + 40
            'btnLLAAutoVent.Left = btnLLAOffline.Left
            'btnTMAutoVent.Left = btnTMOffline.Left

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

#Region "Online button"
    Public Sub Make_Online(ByVal button As SL_CustomButton, Optional ByVal isCheckAlarm As Boolean = True)
        Dim strMessageText As String = String.Empty
        If blnGoOnline Then
            If button.Name = btnTMOnline.Name Then
                m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK & IIf(isCheckAlarm = False, "_False", ""))
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring TM online")
            ElseIf button.Name = btnLLAOnline.Name Then
                m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK & IIf(isCheckAlarm = False, "_False", ""))
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring LLA online")
            End If
            Exit Sub
        End If
        If button.Name = btnTMOnline.Name Then
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring TM online")
            m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK & IIf(isCheckAlarm = False, "_False", ""))
        ElseIf button.Name = btnLLAOnline.Name Then
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring LLA online")
            m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK & IIf(isCheckAlarm = False, "_False", ""))
        End If
    End Sub


    Friend Sub btnTMOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMOnline.Click, btnLLAOnline.Click
        AVPLib.Log.guiLogger.Info("Enter btnTMOnline_Click")
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Make_Online(button, True)

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
                
                'ContainerForm.CassettesPanel.SetTMOnline(False)
                m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring TM offline")


            ElseIf button.Name = btnLLAOffline.Name Then
                  'ContainerForm.CassettesPanel.LeftValveStatus(True)
                'ContainerForm.CassettesPanel.SetLLAOnline(False)
                m_stoStatusObject.RequestStatus(button.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring LLA offline")

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
            If btnLLAAutoVent.Status = SL_CustomButton.DisplayStatus.Off AndAlso btnLLAIGDegas.Status = SL_CustomButton.DisplayStatus.Off Then
                btnLLAAutoPumpDown.Enabled = True
            End If
            If btnLLAAutoPumpDown.Status = SL_CustomButton.DisplayStatus.Off AndAlso btnLLAIGDegas.Status = SL_CustomButton.DisplayStatus.Off Then
                btnLLAAutoVent.Enabled = True
            End If
            If btnLLAAutoPumpDown.Status = SL_CustomButton.DisplayStatus.Off AndAlso btnLLAAutoVent.Status = SL_CustomButton.DisplayStatus.Off Then
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
            If btnTMAutoVent.Status = SL_CustomButton.DisplayStatus.Off AndAlso btnTMIGDegas.Status = SL_CustomButton.DisplayStatus.Off Then
                btnTMAutoPumpDown.Enabled = True
            End If
            If btnTMAutoPumpDown.Status = SL_CustomButton.DisplayStatus.Off AndAlso btnTMIGDegas.Status = SL_CustomButton.DisplayStatus.Off Then
                btnTMAutoVent.Enabled = True
            End If
            If btnTMAutoPumpDown.Status = SL_CustomButton.DisplayStatus.Off AndAlso btnTMAutoVent.Status = SL_CustomButton.DisplayStatus.Off Then
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
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopPumpDownOfCassettesPanel"), TM_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, TM_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                            ' Pulse Event
                            'ContainerForm.CassettesPanel.PumpDown(False, False, True, STR_OFF)
                            ContainerForm.CassettesPanel.m_evtTMVentPumpdownInProgress.Reset()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Abort TM Pump down")
                        End If
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then '' Pump Down
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuPumpDownOfCassettesPanel"), TM_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, TM_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                            ' Pulse Event
                            'ContainerForm.CassettesPanel.PumpDown(False, False, True, STR_ON)
                            ContainerForm.CassettesPanel.m_evtTMVentPumpdownInProgress.Set()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Start TM Pump down")
                        End If
                    End If

                Case btnLLAAutoPumpDown.Name
                    If button.Status = SL_CustomButton.DisplayStatus.On Then ''Abort Pump Down
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopPumpDownOfCassettesPanel"), LLA_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, LLA_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                            ' Pulse Event
                            'ContainerForm.CassettesPanel.PumpDown(True, False, False, STR_OFF)
                            ContainerForm.CassettesPanel.m_evtLLAVentPumpdownInProgress.Reset()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Abort LLA Pump down")
                        End If
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuPumpDownOfCassettesPanel"), LLA_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, LLA_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                            ' Pulse Event
                            'ContainerForm.CassettesPanel.PumpDown(True, False, False, STR_ON)
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
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopVentOfCassettesPanel"), TM_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, TM_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.Vent(False, True, STR_OFF)
                            ContainerForm.CassettesPanel.m_evtTMVentPumpdownInProgress.Reset()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Abort TM Vent")
                        End If
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then '' Pump Down
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuVentOfCassettesPanel"), TM_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, TM_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.Vent(False, True, STR_ON)
                            ContainerForm.CassettesPanel.m_evtTMVentPumpdownInProgress.Set()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Start TM Vent")
                        End If
                    End If

                Case btnLLAAutoVent.Name
                    If button.Status = SL_CustomButton.DisplayStatus.On Then ''Abort Pump Down
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopVentOfCassettesPanel"), LLA_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, LLA_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                            ' Pulse Event
                            ContainerForm.CassettesPanel.Vent(True, False, STR_OFF)
                            ContainerForm.CassettesPanel.m_evtLLAVentPumpdownInProgress.Reset()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Abort LLA Vent")
                        End If
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then
                        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuVentOfCassettesPanel"), LLA_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, LLA_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
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

    Private Sub btnTMAutoVent_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTMAutoVent.StatusChange
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

    Private Sub btnTMIGDegas_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTMIGDegas.StatusChange
        If btnTMIGDegas.Status = DisplayStatus.On Then
            btnTMAutoPumpDown.Enabled = False
            btnTMAutoVent.Enabled = False
        Else
            If btnTMOnline.Status = DisplayStatus.Off Then
                btnTMAutoPumpDown.Enabled = True
                btnTMAutoVent.Enabled = True
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

    Private Sub btnLLAAutoVent_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLLAAutoVent.StatusChange
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

    Private Sub btnLLAIGDegas_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLLAIGDegas.StatusChange
        If btnLLAIGDegas.Status = DisplayStatus.On Then
            btnLLAAutoPumpDown.Enabled = False
            btnLLAAutoVent.Enabled = False
        Else
            If btnLLAOnline.Status = DisplayStatus.Off Then
                btnLLAAutoPumpDown.Enabled = True
                btnLLAAutoVent.Enabled = True
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
                    If button.Status = SL_CustomButton.DisplayStatus.On Then ''Abort IG Degas
                        strMessageText = String.Format(strMessageText, LLA_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, LLA_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                        End If
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring IG Degas of " & ONLINELOADLOCKA)
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then '' IG Degas
                        strMessageText = String.Format(strMessageText, LLA_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, LLA_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                        End If
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring IG Degas of " & ONLINELOADLOCKA)
                    End If
                Case btnTMIGDegas.Name
                    If button.Status = SL_CustomButton.DisplayStatus.On Then ''Abort IG Degas
                        strMessageText = String.Format(strMessageText, TM_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, TM_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                        End If
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring IG Degas of " & ONLINETM)
                    ElseIf button.Status = SL_CustomButton.DisplayStatus.Off Then '' IG Degas
                        strMessageText = String.Format(strMessageText, TM_STR)
                        If (Utils.ShowAVPMessageBox(strMessageText, TM_STR, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                            m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                        End If
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Bring IG Degas of " & ONLINETM)
                    End If
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
    Public Sub ConfigShowGUI()
        gbLLA.Location = LL_WITH_ONE_LL_LOCATION
        Me.Size = FORM_WITH_ONE_LL_SIZE

        '0001082: [ Khoi Ha - 06/27/2012 ] LLx menu. IG degas should not visible on rough only configuration.

        Dim loadLockA As DataManagerment.LoadLock = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
        If (loadLockA IsNot Nothing AndAlso Not loadLockA.IsIGInstalled()) Then
            btnLLAIGDegas.Visible = False
        End If
    End Sub
#End Region

    Private Sub TMPopUpPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not AVPLib.RobotConfigurationValues.TMCRYO_VISIBLE Then
            btnTMCryoOn.Enabled = False
            btnTMCryoRegen.Enabled = False
            btnTMFastRegen.Enabled = False
        End If

        If Not AVPLib.RobotConfigurationValues.LLA_CRYO_VISIBLE Then
            btnLLACryoOn.Enabled = False
            btnLLACryoRegen.Enabled = False
            btnLLACryoFastRegen.Enabled = False
        End If
    End Sub
End Class
