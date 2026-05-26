Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls
Imports AVPLib
Imports AVPLib.DataManagerment
Imports AVPLib.SystemModule

Public Class SystemSetupPopUpPanel
    Private m_objTargetPSConfig As TargetPowerSupplyCoronaConfig
    Private m_strChamberName As String = String.Empty

    ' Varible use for log, store text of textbox before changed in form
    Protected m_mapValueChanged As New Hashtable

#Region "Properties"
    Public Property TargetPSConfig() As TargetPowerSupplyCoronaConfig
        Get
            Return m_objTargetPSConfig
        End Get
        Set(ByVal value As TargetPowerSupplyCoronaConfig)
            m_objTargetPSConfig = value
        End Set
    End Property

    Public Property ChamberName() As String
        Get
            Return m_strChamberName
        End Get
        Set(ByVal value As String)
            m_strChamberName = value
        End Set
    End Property

#End Region
    
    Protected Overrides Sub DoClose()
        Try
            Select Case ChamberName
                Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM1.Text = STR_CLICK_FOR_DETAIL 'm_objTargetPSConfig.T_Limit
                    ContainerForm.SystemSetup.txtWarningKWH_PM1.Text = STR_CLICK_FOR_DETAIL ' m_objTargetPSConfig.T_Warning
                    ContainerForm.SystemSetup.txtMaxKWHPM1.Text = STR_CLICK_FOR_DETAIL
                    SetValueTextBoxTargetMaterial(ContainerForm.SystemSetup.txtTarMaterialPM1)
                Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM2.Text = STR_CLICK_FOR_DETAIL ' m_objTargetPSConfig.T_Limit
                    ContainerForm.SystemSetup.txtWarningKWH_PM2.Text = STR_CLICK_FOR_DETAIL ' m_objTargetPSConfig.T_Warning
                    ContainerForm.SystemSetup.txtMaxKWHPM2.Text = STR_CLICK_FOR_DETAIL
                    SetValueTextBoxTargetMaterial(ContainerForm.SystemSetup.txtTarMaterialPM2)
                Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM3.Text = STR_CLICK_FOR_DETAIL 'm_objTargetPSConfig.T_Limit
                    ContainerForm.SystemSetup.txtWarningKWH_PM3.Text = STR_CLICK_FOR_DETAIL 'm_objTargetPSConfig.T_Warning
                    ContainerForm.SystemSetup.txtMaxKWHPM3.Text = STR_CLICK_FOR_DETAIL
                    SetValueTextBoxTargetMaterial(ContainerForm.SystemSetup.txtTarMaterialPM3)
            End Select
            Me.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub SetValueTextBoxTargetMaterial(ByVal txtTarMaterial As TextBox)
        Dim TargetNumber As Integer = Utils.GetCurrentTargetSwitch(ChamberName)
        If TargetNumber = 1 Then
            txtTarMaterial.Text = STR_CLICK_FOR_DETAIL ' m_objTargetPSConfig.T1_Material
        ElseIf TargetNumber = 2 Then
            txtTarMaterial.Text = STR_CLICK_FOR_DETAIL 'm_objTargetPSConfig.T2_Material
        ElseIf TargetNumber = 3 Then
            txtTarMaterial.Text = STR_CLICK_FOR_DETAIL ' m_objTargetPSConfig.T3_Material
        ElseIf TargetNumber = 4 Then
            txtTarMaterial.Text = STR_CLICK_FOR_DETAIL 'm_objTargetPSConfig.T4_Material
        ElseIf TargetNumber = 5 Then
            txtTarMaterial.Text = STR_CLICK_FOR_DETAIL 'm_objTargetPSConfig.T5_Material
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_objTargetPSConfig = New TargetPowerSupplyCoronaConfig

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub SystemSetupPopUpPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_objTargetPSConfig IsNot Nothing Then
            txtT1Limit.Text = m_objTargetPSConfig.T1_Limit
            txtT2Limit.Text = m_objTargetPSConfig.T2_Limit
            txtT3Limit.Text = m_objTargetPSConfig.T3_Limit
            txtT4Limit.Text = m_objTargetPSConfig.T4_Limit
            txtT5Limit.Text = m_objTargetPSConfig.T5_Limit

            txtT1Warning.Text = m_objTargetPSConfig.T1_Warning
            txtT2Warning.Text = m_objTargetPSConfig.T2_Warning
            txtT3Warning.Text = m_objTargetPSConfig.T3_Warning
            txtT4Warning.Text = m_objTargetPSConfig.T4_Warning
            txtT5Warning.Text = m_objTargetPSConfig.T5_Warning

            txtT1TargetMaterial.Text = m_objTargetPSConfig.T1_Material
            txtT2TargetMaterial.Text = m_objTargetPSConfig.T2_Material
            txtT3TargetMaterial.Text = m_objTargetPSConfig.T3_Material
            txtT4TargetMaterial.Text = m_objTargetPSConfig.T4_Material
            txtT5TargetMaterial.Text = m_objTargetPSConfig.T5_Material

            txtT1Usage.Text = m_objTargetPSConfig.T1_Usage
            txtT2Usage.Text = m_objTargetPSConfig.T2_Usage
            txtT3Usage.Text = m_objTargetPSConfig.T3_Usage
            txtT4Usage.Text = m_objTargetPSConfig.T4_Usage
            txtT5Usage.Text = m_objTargetPSConfig.T5_Usage

            txtT1Max.Text = IIf(m_objTargetPSConfig.T1_Max = -1, 0, m_objTargetPSConfig.T1_Max)
            txtT2Max.Text = IIf(m_objTargetPSConfig.T2_Max = -1, 0, m_objTargetPSConfig.T2_Max)
            txtT3Max.Text = IIf(m_objTargetPSConfig.T3_Max = -1, 0, m_objTargetPSConfig.T3_Max)
            txtT4Max.Text = IIf(m_objTargetPSConfig.T4_Max = -1, 0, m_objTargetPSConfig.T4_Max)
            txtT5Max.Text = IIf(m_objTargetPSConfig.T5_Max = -1, 0, m_objTargetPSConfig.T5_Max)

            If ContainerForm.SystemSetup.rbUseAbsoluteKWH.Checked Then
                txtT1Max.Enabled = False
                txtT2Max.Enabled = False
                txtT3Max.Enabled = False
                txtT4Max.Enabled = False
                txtT5Max.Enabled = False
            Else
                txtT1Max.Enabled = True
                txtT2Max.Enabled = True
                txtT3Max.Enabled = True
                txtT4Max.Enabled = True
                txtT5Max.Enabled = True
            End If
        End If

        Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.ChamberName)
        Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.ChamberName)

        If objChamber Is Nothing OrElse chamberConfig Is Nothing Then
            Return
        End If

        If ContainerForm.ChamberPanel(objChamber.Name).ChamberType = SystemModule.ModuleType.PVD4 Then
            Me.Panel3.Enabled = chamberConfig.TargetVisible
            Me.Panel9.Enabled = chamberConfig.Target2Visible
            Me.Panel15.Enabled = chamberConfig.Target3Visible
            Me.Panel21.Enabled = chamberConfig.Target4Visible
            Me.Panel1.Visible = False
            Me.Label45.Visible = False
            Me.FormContainer.Size = New System.Drawing.Size(1004, 264)
            Me.Size = New System.Drawing.Size(1014, 309)
        ElseIf ContainerForm.ChamberPanel(objChamber.Name).ChamberType = SystemModule.ModuleType.PVD5T Then
            Me.Panel3.Enabled = chamberConfig.TargetVisible
            Me.Panel9.Enabled = chamberConfig.Target2Visible
            Me.Panel15.Enabled = chamberConfig.Target3Visible
            Me.Panel21.Enabled = chamberConfig.Target4Visible
            Me.Panel1.Enabled = chamberConfig.Target5Visible
        End If
    End Sub

    Private Sub txtT1Usage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT1Usage.Click, txtT2Usage.Click, txtT3Usage.Click, txtT4Usage.Click, txtT5Usage.Click
        Try
            If Not (GetUserInput(sender, True) = MsgBoxResult.Ok) Then
                Exit Try
            End If
            Dim objChamber As DataManagerment.Chamber = Nothing
            Dim objController As Business.ChamberController = Nothing
            Dim txt As TextBox = CType(sender, TextBox)
            Dim strPM As String = AVPLib.Utils.chamberID2ChamberName(ChamberName)
            Dim strShieldSource As String = strPM & "_" & AVPLib.Utils.GetChamberType(ChamberName) & "_" & txt.AccessibleDescription
            objChamber = DataManagerment.EquipmentManager.GetEquipment(Me.ChamberName)
            objController = Business.ControllerManager.GetController(ChamberName)
            '''check obj exist
            If objChamber Is Nothing OrElse objController Is Nothing Then
                Exit Try
            End If
            '''confirm user
            'Dim strMessageText As String = AVPLib.ContainerData.GetMessageText("ResetTargetSource")
            'If (Utils.ShowAVPMessageBox(strMessageText, strPM, MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK) Then
            ''log action
            Dim oldValue As String = GetStoredValue(txt.Name)
            Utils.CheckChangeValue(strShieldSource, oldValue, txt.Text)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                               AVPLib.ContainerData.LogSource.AVPMainScreen,
                                               "[System Setup] Set/Reset Target KWH/Source Usage: " & strPM)
            ''check connection befor reset
            If objChamber.ConnectionStatus = DataManagerment.Equipment.WorkingStatuses.Off Then
                AVPLib.Utils.ThrowAlarm("Failed to set/reset value when " & strPM & " is disconnected", AVPLib.ConstEnum.GEM_ALARM_SYSTEM)
                txt.Text = oldValue
                Exit Try
            End If

            If objChamber.EquipmentType = ModuleType.PVD5T Then
                ''SourceUsage1,2,3,4,5
                Select Case CType(sender, TextBox).Name
                    Case txtT1Usage.Name
                        CType(objController.Myself, Business.PVD5TController).DoResetTargetKWHx(1, txt.Text)
                    Case txtT2Usage.Name
                        CType(objController.Myself, Business.PVD5TController).DoResetTargetKWHx(2, txt.Text)
                    Case txtT3Usage.Name
                        CType(objController.Myself, Business.PVD5TController).DoResetTargetKWHx(3, txt.Text)
                    Case txtT4Usage.Name
                        CType(objController.Myself, Business.PVD5TController).DoResetTargetKWHx(4, txt.Text)
                    Case txtT5Usage.Name
                        CType(objController.Myself, Business.PVD5TController).DoResetTargetKWHx(5, txt.Text)
                End Select
            Else
                ''SourceUsage1,2,3,4
                Select Case CType(sender, TextBox).Name
                    Case txtT1Usage.Name
                        CType(objController.Myself, Business.CoronaController).DoResetTargetKWHx(1, txt.Text)
                    Case txtT2Usage.Name
                        CType(objController.Myself, Business.CoronaController).DoResetTargetKWHx(2, txt.Text)
                    Case txtT3Usage.Name
                        CType(objController.Myself, Business.CoronaController).DoResetTargetKWHx(3, txt.Text)
                    Case txtT4Usage.Name
                        CType(objController.Myself, Business.CoronaController).DoResetTargetKWHx(4, txt.Text)
                End Select
            End If
            'End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtT1Limit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    txtT1Limit.Click, txtT2Limit.Click, txtT3Limit.Click, txtT4Limit.Click, txtT5Limit.Click
        Try
            Dim Source As String = "SystemSetup.LimitKWH"
            ChangeLimit_WarningKWH(Source, sender)
            txtLimitsWarningKWH_PM_TextChanged(sender, e)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtLimitsWarningKWH_PM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim objChamber As SystemModule = Nothing
            objChamber = AVPLib.ContainerData.GetRobotConfig(ChamberName)
            Dim strPM As String = AVPLib.Utils.chamberID2ChamberName(ChamberName)
            Select Case CType(sender, TextBox).Name
                Case txtT1Limit.Name
                    objChamber.Alarm_KWH = CDbl(txtT1Limit.Text)
                    AddLotDatalog(strPM, "Limit Target1 KWH Changed To: " & txtT1Limit.Text)

                Case txtT2Limit.Name
                    objChamber.Alarm_KWH1 = CDbl(txtT2Limit.Text)
                    AddLotDatalog(strPM, "Limit Target2 KWH Changed To: " & txtT2Limit.Text)

                Case txtT3Limit.Name
                    objChamber.Alarm_KWH2 = CDbl(txtT3Limit.Text)
                    AddLotDatalog(strPM, "Limit Target3 KWH Changed To: " & txtT3Limit.Text)

                Case txtT4Limit.Name
                    objChamber.Alarm_KWH3 = CDbl(txtT4Limit.Text)
                    AddLotDatalog(strPM, "Limit Target4 KWH Changed To: " & txtT4Limit.Text)

                Case txtT5Limit.Name
                    objChamber.Alarm_KWH4 = CDbl(txtT5Limit.Text)
                    AddLotDatalog(strPM, "Limit Target5 KWH Changed To: " & txtT5Limit.Text)

                Case txtT1Warning.Name
                    objChamber.Warning_KWH = CDbl(txtT1Warning.Text)
                    AddLotDatalog(strPM, "Warning Target1 KWH Changed To: " & txtT1Warning.Text)

                Case txtT2Warning.Name
                    objChamber.Warning_KWH1 = CDbl(txtT2Warning.Text)
                    AddLotDatalog(strPM, "Warning Target2 KWH Changed To: " & txtT2Warning.Text)

                Case txtT3Warning.Name
                    objChamber.Warning_KWH2 = CDbl(txtT3Warning.Text)
                    AddLotDatalog(strPM, "Warning Target3 KWH Changed To: " & txtT3Warning.Text)

                Case txtT4Warning.Name
                    objChamber.Warning_KWH3 = CDbl(txtT4Warning.Text)
                    AddLotDatalog(strPM, "Warning Target4 KWH Changed To: " & txtT4Warning.Text)

                Case txtT5Warning.Name
                    objChamber.Warning_KWH4 = CDbl(txtT5Warning.Text)
                    AddLotDatalog(strPM, "Warning Target5 KWH Changed To: " & txtT5Warning.Text)

                Case txtT1Max.Name
                    objChamber.Max_KWH_Source = CDbl(txtT1Max.Text)
                    AddLotDatalog(strPM, "Max Target1 KWH Changed To: " & txtT1Max.Text)

                Case txtT2Max.Name
                    objChamber.Max_KWH_Source1 = CDbl(txtT2Max.Text)
                    AddLotDatalog(strPM, "Max Target2 KWH Changed To: " & txtT2Max.Text)

                Case txtT3Max.Name
                    objChamber.Max_KWH_Source2 = CDbl(txtT3Max.Text)
                    AddLotDatalog(strPM, "Max Target3 KWH Changed To: " & txtT3Max.Text)

                Case txtT4Max.Name
                    objChamber.Max_KWH_Source3 = CDbl(txtT4Max.Text)
                    AddLotDatalog(strPM, "Max Target4 KWH Changed To: " & txtT4Max.Text)

                Case txtT5Max.Name
                    objChamber.Max_KWH_Source4 = CDbl(txtT5Max.Text)
                    AddLotDatalog(strPM, "Max Target5 KWH Changed To: " & txtT5Max.Text)

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub AddLotDatalog(ByVal ChamberName As String, ByVal Info As String)
        Try
            If (AVPLib.Business.AVPCore.Instance() IsNot Nothing) Then

                Dim objLoadLockACtrl As AVPLib.Business.LoadLockController = Nothing

                Dim objCtrlJobA As AVPLib.Business.AVPControlJob = Nothing

                objLoadLockACtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                If (objLoadLockACtrl IsNot Nothing AndAlso objLoadLockACtrl.CtrlJobId <> String.Empty) Then
                    objCtrlJobA = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockACtrl.CtrlJobId)
                    If (objCtrlJobA IsNot Nothing) Then
                        AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                        LogType.Info, AVPLib.Utils.chamberID2ChamberName(ChamberName) & " " & Info, objCtrlJobA.IsAutoTransferJob)
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtT1Warning_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    txtT1Warning.Click, txtT2Warning.Click, txtT3Warning.Click, txtT4Warning.Click, txtT5Warning.Click
        Try
            Dim Source As String = "SystemSetup.WarningKWH"
            ChangeLimit_WarningKWH(Source, sender)
            txtLimitsWarningKWH_PM_TextChanged(sender, e)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtT1TargetMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    txtT1TargetMaterial.Click, txtT2TargetMaterial.Click, txtT3TargetMaterial.Click, txtT4TargetMaterial.Click, txtT5TargetMaterial.Click
        Try
            Dim Source As String = "SystemSetup.TarMaterial"
            Dim frm As New KeyPad
            Dim strPM As String = AVPLib.Utils.chamberID2ChamberName(ChamberName)
            Dim strShieldSource As String = strPM & "_" & AVPLib.Utils.GetChamberType(ChamberName)
            Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim value As String = CType(sender, TextBox).Text
            Dim oldValue As String = value
            If frm.DisplayKeypad(value, Title, False) = MsgBoxResult.Ok Then
                If value.Length > 12 Then
                    CType(sender, TextBox).Text = oldValue
                    Utils.ShowAVPMessageBox("Your input value is not valid",
                                            "Target Material Input Error",
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxButtons.OK)
                Else
                    Utils.LogUserEvent(sender, "System Setup", AVPLib.Utils.chamberID2ChamberName(ChamberName), "", CType(sender, TextBox).Text, value)
                    CType(sender, TextBox).Text = value
                    SaveDataToAVPConfig(sender, value)
                    LogUserEvent(sender, oldValue, "", strShieldSource)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub ChangeLimit_WarningKWH(ByVal Source As String, ByVal sender As Object)
        Dim frm As New NumPad
        Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
        Dim strPM As String = AVPLib.Utils.chamberID2ChamberName(ChamberName)
        Dim strShieldSource As String = strPM & "_" & AVPLib.Utils.GetChamberType(ChamberName)
        Dim value As String = CType(sender, TextBox).Text
        'Dim TargetSource As String = ChamberName & ".PVD4." & CType(sender, TextBox).Name
        Dim TargetSource As String = Source & "."
        Dim oldValue As String = value
        Dim Min As Double = Double.Parse(AVPLib.ContainerData.GetRobotConfig(TargetSource + STRING_MIN).ToString())
        Dim Max As Double = Double.Parse(AVPLib.ContainerData.GetRobotConfig(TargetSource + STRING_MAX).ToString())

        Dim InputRes As MsgBoxResult = frm.GetUserInput(value, -1, -1, Min, Max, Title)

        If frm.IsMaxMinModified Then
            AVPLib.ContainerData.SetRobotConfig(TargetSource + STRING_MIN, frm.NewMin)
            AVPLib.ContainerData.SetRobotConfig(TargetSource + STRING_MAX, frm.NewMax)

            Dim logName As String = Utils.GetLogName(sender)

            If Min <> frm.NewMin Then
                Utils.LogUserEvent(String.Format("Changed MIN of {0} from {1} to {2}", logName, Min, frm.NewMin), "System Setup", AVPLib.Utils.chamberID2ChamberName(ChamberName))
            End If

            If Max <> frm.NewMax Then
                Utils.LogUserEvent(String.Format("Changed MAX of {0} from {1} to {2}", logName, Max, frm.NewMax), "System Setup", AVPLib.Utils.chamberID2ChamberName(ChamberName))
            End If
        End If

        If InputRes = MsgBoxResult.Ok Then
            Utils.LogUserEvent(sender, "System Setup", AVPLib.Utils.chamberID2ChamberName(ChamberName), "", CType(sender, TextBox).Text, value)
            CType(sender, TextBox).Text = value
            SaveDataToAVPConfig(sender, value)
            LogUserEvent(sender, oldValue, AVPLib.Utils.chamberID2ChamberName(ChamberName), strShieldSource)
        End If

    End Sub

    Private Sub SaveDataToAVPConfig(ByVal sender As System.Object, ByVal value As String)
        Try
            Dim objPanel As AVPLib.SystemModule = Nothing
            Dim objChamber As SystemModule = Nothing
            Dim numberTarget As Integer = AVPLib.Utils.GetNumberTarget(sender)
            Select Case CType(sender, TextBox).Name
                Case txtT1TargetMaterial.Name, txtT2TargetMaterial.Name, txtT3TargetMaterial.Name, txtT4TargetMaterial.Name, txtT5TargetMaterial.Name
                    AVPLib.Utils.SaveTarXMaterial(sender, value, Me.ChamberName)
                    If numberTarget = 1 Then
                        m_objTargetPSConfig.T1_Material = value
                    ElseIf numberTarget = 2 Then
                        m_objTargetPSConfig.T2_Material = value
                    ElseIf numberTarget = 3 Then
                        m_objTargetPSConfig.T3_Material = value
                    ElseIf numberTarget = 4 Then
                        m_objTargetPSConfig.T4_Material = value
                    ElseIf numberTarget = 5 Then
                        m_objTargetPSConfig.T5_Material = value
                    End If

                Case txtT1Warning.Name, txtT2Warning.Name, txtT3Warning.Name, txtT4Warning.Name, txtT5Warning.Name
                    AVPLib.Utils.SavePMWarningLimitX(sender, value, Me.ChamberName)
                    If numberTarget = 1 Then
                        m_objTargetPSConfig.T1_Warning = value
                    ElseIf numberTarget = 2 Then
                        m_objTargetPSConfig.T2_Warning = value
                    ElseIf numberTarget = 3 Then
                        m_objTargetPSConfig.T3_Warning = value
                    ElseIf numberTarget = 4 Then
                        m_objTargetPSConfig.T4_Warning = value
                    ElseIf numberTarget = 5 Then
                        m_objTargetPSConfig.T5_Warning = value
                    End If

                Case txtT1Limit.Name, txtT2Limit.Name, txtT3Limit.Name, txtT4Limit.Name, txtT5Limit.Name
                    AVPLib.Utils.SavePMAlarmLimitX(sender, value, Me.ChamberName)
                    If numberTarget = 1 Then
                        m_objTargetPSConfig.T1_Limit = value
                    ElseIf numberTarget = 2 Then
                        m_objTargetPSConfig.T2_Limit = value
                    ElseIf numberTarget = 3 Then
                        m_objTargetPSConfig.T3_Limit = value
                    ElseIf numberTarget = 4 Then
                        m_objTargetPSConfig.T4_Limit = value
                    ElseIf numberTarget = 5 Then
                        m_objTargetPSConfig.T5_Limit = value
                    End If

                Case txtT1Max.Name, txtT2Max.Name, txtT3Max.Name, txtT4Max.Name, txtT5Max.Name
                    AVPLib.Utils.SaveMax_KWH_SourceUsageX(sender, value, Me.ChamberName)
                    If numberTarget = 1 Then
                        m_objTargetPSConfig.T1_Max = value
                    ElseIf numberTarget = 2 Then
                        m_objTargetPSConfig.T2_Max = value
                    ElseIf numberTarget = 3 Then
                        m_objTargetPSConfig.T3_Max = value
                    ElseIf numberTarget = 4 Then
                        m_objTargetPSConfig.T4_Max = value
                    ElseIf numberTarget = 5 Then
                        m_objTargetPSConfig.T5_Max = value
                    End If

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function GetUserInput(ByVal TargetControl As System.Object, ByVal AllowDecimal As Boolean, Optional ByVal IsScientificFormat As Boolean = False) As MsgBoxResult
        Dim UserResponse As MsgBoxResult = MsgBoxResult.Cancel
        Try
            Dim needToCheckMaxMin As Boolean = True
            'If Me.tabPolling.Contains(TargetControl) Then
            '    needToCheckMaxMin = True
            'End If
            Dim Source As String = String.Empty
            Dim Min As Single = 0
            Dim Max As Single = 0

            Dim f As New NumPad()
            Dim Value As String = String.Empty
            If TypeOf (TargetControl) Is TextBox Then
                Value = CType(TargetControl, TextBox).Text
                Source = ChamberName & ".PVD4." & CType(TargetControl, TextBox).Name
                Min = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN)
                Max = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX)
            Else
                Exit Function
            End If

            UserResponse = f.GetUserInput(Value, -1, -1, Min, Max, "Please input the number", 0, _
                                needToCheckMaxMin, AllowDecimal)
            If UserResponse = MsgBoxResult.Ok Then
                If TypeOf (TargetControl) Is TextBox Then
                    StoreValueBeforeChange(TargetControl)
                    CType(TargetControl, TextBox).Text = IIf(IsScientificFormat, Utils.ConvertDoubleToScientificFormat(Value), Value)
                End If
            End If

            If f.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, f.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, f.NewMax)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return UserResponse
    End Function

    Private Sub txtT1TargetMaterial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtT1TargetMaterial.TextChanged, txtT2TargetMaterial.TextChanged, txtT3TargetMaterial.TextChanged, txtT4TargetMaterial.TextChanged, txtT5TargetMaterial.TextChanged
        Try
            Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.ChamberName)

            Dim objPMPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.ChamberName)
            If objPMPanel IsNot Nothing Then
                If objPMPanel.ChamberType = ModuleType.PVD5T Then
                    Dim objPVD5T As PVD5TPanel = Nothing
                    Dim text_box As SL_Textbox = CType(sender, SL_Textbox)
                    If Me.Text.Contains(ConstEnum.PM1) Then
                        objPVD5T = ContainerForm.ChamberPanel("Chamber1")
                    ElseIf Me.Text.Contains(ConstEnum.PM2) Then
                        objPVD5T = ContainerForm.ChamberPanel("Chamber2")
                    ElseIf Me.Text.Contains(ConstEnum.PM3) Then
                        objPVD5T = ContainerForm.ChamberPanel("Chamber3")
                    End If
                    If objPVD5T IsNot Nothing Then
                        Select Case text_box.Name
                            Case txtT1TargetMaterial.Name
                                objPVD5T.CoronaTarget.T1Text = "T1-" & txtT1TargetMaterial.Text
                                chamberConfig.Target_Material = txtT1TargetMaterial.Text
                            Case txtT2TargetMaterial.Name
                                objPVD5T.CoronaTarget.T2Text = "T2-" & txtT2TargetMaterial.Text
                                chamberConfig.Target_Material1 = txtT2TargetMaterial.Text
                            Case txtT3TargetMaterial.Name
                                objPVD5T.CoronaTarget.T3Text = "T3-" & txtT3TargetMaterial.Text
                                chamberConfig.Target_Material2 = txtT3TargetMaterial.Text
                            Case txtT4TargetMaterial.Name
                                objPVD5T.CoronaTarget.T4Text = "T4-" & txtT4TargetMaterial.Text
                                chamberConfig.Target_Material3 = txtT4TargetMaterial.Text
                            Case txtT5TargetMaterial.Name
                                objPVD5T.CoronaTarget.T5Text = "T5-" & txtT5TargetMaterial.Text
                                chamberConfig.Target_Material4 = txtT5TargetMaterial.Text
                        End Select
                        objPVD5T.CoronaTarget.Repaint()
                    End If
                Else
                    Dim objCoronaPanel As CoronaPanel = Nothing
                    Dim text_box As SL_Textbox = CType(sender, SL_Textbox)
                    If Me.Text.Contains(ConstEnum.PM1) Then
                        objCoronaPanel = ContainerForm.ChamberPanel("Chamber1")
                    ElseIf Me.Text.Contains(ConstEnum.PM2) Then
                        objCoronaPanel = ContainerForm.ChamberPanel("Chamber2")
                    ElseIf Me.Text.Contains(ConstEnum.PM3) Then
                        objCoronaPanel = ContainerForm.ChamberPanel("Chamber3")
                    End If
                    If objCoronaPanel IsNot Nothing Then
                        Select Case text_box.Name
                            Case txtT1TargetMaterial.Name
                                objCoronaPanel.CoronaTarget.T1Text = "T1-" & txtT1TargetMaterial.Text
                                chamberConfig.Target_Material = txtT1TargetMaterial.Text
                            Case txtT2TargetMaterial.Name
                                objCoronaPanel.CoronaTarget.T2Text = "T2-" & txtT2TargetMaterial.Text
                                chamberConfig.Target_Material1 = txtT2TargetMaterial.Text
                            Case txtT3TargetMaterial.Name
                                objCoronaPanel.CoronaTarget.T3Text = "T3-" & txtT3TargetMaterial.Text
                                chamberConfig.Target_Material2 = txtT3TargetMaterial.Text
                            Case txtT4TargetMaterial.Name
                                objCoronaPanel.CoronaTarget.T4Text = "T4-" & txtT4TargetMaterial.Text
                                chamberConfig.Target_Material3 = txtT4TargetMaterial.Text
                        End Select
                        objCoronaPanel.CoronaTarget.Repaint()
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtT1Max_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT1Max.Click, txtT2Max.Click, txtT3Max.Click, txtT4Max.Click, txtT5Max.Click
        Try
            Dim Source As String = "SystemSetup.MaxUsage"
            ChangeLimit_WarningKWH(Source, sender)
            txtLimitsWarningKWH_PM_TextChanged(sender, e)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''     <name> Dy Do</name>
    '''     <date> 2016-04-14 </date>
    ''' </author>
    ''' <summary>
    ''' Log change of setting
    ''' </summary>
    Private Sub LogUserEvent(ByVal control As Object, Optional ByVal oldValue As String = "", Optional ByVal subLogSource As String = "", Optional ByVal subLogShields As String = "")
        Dim logSource As String = "[System Setup]"
        If subLogSource.Trim() <> "" Then
            subLogSource = subLogSource + ": "
        End If

        Dim logMessage As String = String.Empty
        Try
            If TypeOf control Is SL_Textbox Then
                Dim slTbx As SL_Textbox = CType(control, SL_Textbox)
                Dim logName As String = Utils.GetLogName(slTbx)
                If oldValue = "" Then
                    logMessage = String.Format("{0} {1}Set {2} value to {3}", logSource, subLogSource, logName, slTbx.Text)
                Else
                    If Not slTbx.Text.Equals(oldValue) Then
                        logMessage = String.Format("{0} {1}Changed {2} from {3} to {4}", logSource, subLogSource, logName, oldValue, slTbx.Text)
                    End If
                End If
                Utils.CheckChangeValue(subLogShields & "_" & logName, oldValue, slTbx.Text)
            ElseIf TypeOf control Is String Then
                logMessage = String.Format("{0} {1}{2}", logSource, subLogSource, control.ToString())
            End If

            ' Log when message is not empty
            If Not String.IsNullOrEmpty(logMessage) Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                        AVPLib.ContainerData.LogSource.AVPMainScreen, logMessage)
            End If
        Catch
        End Try
    End Sub
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Add value before change, use for log.\n
    ''' Call this function before change value of control
    ''' </summary>
    Protected Sub StoreValueBeforeChange(ByVal control As Object)
        If (m_mapValueChanged Is Nothing) Then
            m_mapValueChanged = New Hashtable()
        End If

        If TypeOf control Is SL_Textbox Then
            Dim sltbx As SL_Textbox = CType(control, SL_Textbox)

            If Not (m_mapValueChanged.ContainsKey(sltbx.Name)) Then
                m_mapValueChanged.Add(sltbx.Name, sltbx.Text)
            End If
        ElseIf TypeOf control Is TextBox Then
            Dim tbx As TextBox = CType(control, TextBox)

            If Not (m_mapValueChanged.ContainsKey(tbx.Name)) Then
                m_mapValueChanged.Add(tbx.Name, tbx.Text)
            End If
        ElseIf TypeOf control Is CheckBox Then
            Dim cbx As CheckBox = CType(control, CheckBox)

            If Not (m_mapValueChanged.ContainsKey(cbx.Name)) Then
                m_mapValueChanged.Add(cbx.Name, Not cbx.Checked)
            End If
        End If

    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get original value of setting in control before changed, use for log
    ''' </summary>
    Protected Function GetStoredValue(ByVal key As String) As Object
        Dim value As Object
        If m_mapValueChanged.ContainsKey(key) Then
            value = m_mapValueChanged(key)
            ' Remove after get, use for update new value changed
            m_mapValueChanged.Remove(key)
            Return value
        End If
        Return Nothing
    End Function

End Class