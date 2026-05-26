Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class PVD5TBiasPowerSupply

    Private m_Target1Install As Boolean = False
    Private m_Target2Install As Boolean = False
    Private m_Target3Install As Boolean = False
    Private m_Target4Install As Boolean = False
    Private m_Target5Install As Boolean = False
    Private m_MagnatronInstalled As Boolean = False
    Private m_blnIsOnline As Boolean = False
    Private m_blnIsBiasPowerSupply As Boolean = False
    Private m_blnIsDCTarget As Boolean = False
    Private m_strChamberName As String = String.Empty
    Private m_blnIsDCTargetPowerSupply As Boolean = False
    Private m_SerenPowerPopup As SerenPopUp
    Private m_lstSpecialType_PowerSupply As List(Of String) = Nothing
    Private m_lstSpecialType_DCPowerSupply As List(Of String) = Nothing
    Private m_ISShowPulse As Boolean = True
    Private m_activeTarget As PVD4TargetControl.TargetIndexs = PVD4TargetControl.TargetIndexs.None
    Private m_strType_Of_DC As AVPLib.SystemModule.Power_Supply_Model = AVPLib.SystemModule.Power_Supply_Model.ENI_1250

    Public Event TargetSwitched(ByVal targetSelectedIndex As PVD4TargetControl.TargetIndexs)
    Public Event HeaderStatusChange(ByVal sender As Object, ByVal e As EventArgs)

    Public Property ChamberName() As String
        Get
            Return m_strChamberName
        End Get
        Set(ByVal value As String)
            m_strChamberName = value
            m_SerenPowerPopup.ChamberName = value
        End Set
    End Property

    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            For Each ctrl As Control In Me.pnPower.Controls
                Utils.CreateStatusTree_4Panel(ctrl, m_stoStatusObject)
            Next
            For Each ctrl As Control In Me.pnTarget.Controls
                Utils.CreateStatusTree_4Panel(ctrl, m_stoStatusObject)
            Next

            Dim sbcStatus As New StatusIGCGButton(Me.Header)
            m_stoStatusObject.AddChild(sbcStatus)

            m_stoStatusObject.AddChild(m_SerenPowerPopup.Status)
            m_stoStatusObject.RemoveChild(txtMatch.Name)
            Dim stttxtMatch As New StatusTextBox(txtMatch)
            m_stoStatusObject.AddChild(stttxtMatch)
            txtMatch.ParentStatusObj = m_stoStatusObject
            m_stoStatusObject.RemoveChild(btnTarget1Switch.Name)
            m_stoStatusObject.RemoveChild(btnTarget2Switch.Name)
            m_stoStatusObject.RemoveChild(btnTarget3Switch.Name)
            m_stoStatusObject.RemoveChild(btnTarget4Switch.Name)
            m_stoStatusObject.RemoveChild(btnTarget5Switch.Name)
            Dim sbc1Status As New StatusCoronaTargetSwitch(Me.btnTarget1Switch)
            Dim sbc2Status As New StatusCoronaTargetSwitch(Me.btnTarget2Switch)
            Dim sbc3Status As New StatusCoronaTargetSwitch(Me.btnTarget3Switch)
            Dim sbc4Status As New StatusCoronaTargetSwitch(Me.btnTarget4Switch)
            Dim sbc5Status As New StatusCoronaTargetSwitch(Me.btnTarget5Switch)
            m_stoStatusObject.AddChild(sbc1Status)
            m_stoStatusObject.AddChild(sbc2Status)
            m_stoStatusObject.AddChild(sbc3Status)
            m_stoStatusObject.AddChild(sbc4Status)
            m_stoStatusObject.AddChild(sbc5Status)
            btnTarget1Switch.ParentStatusObj = m_stoStatusObject
            btnTarget2Switch.ParentStatusObj = m_stoStatusObject
            btnTarget3Switch.ParentStatusObj = m_stoStatusObject
            btnTarget4Switch.ParentStatusObj = m_stoStatusObject
            btnTarget5Switch.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            If m_SerenPowerPopup IsNot Nothing Then
                m_SerenPowerPopup.IsOnline = m_blnIsOnline
            End If
            txtForwardPowerRight.Enabled = Not (m_blnIsOnline)
            txtDCForwardPowerRight.Enabled = Not (m_blnIsOnline)
            txtVoltageRight.Enabled = Not (m_blnIsOnline)
            txtC1Right.Enabled = Not (m_blnIsOnline)
            txtC2Right.Enabled = Not (m_blnIsOnline)
            btnAuto.Enabled = Not (m_blnIsOnline)
            txtPulseFrequencyRight.Enabled = Not (m_blnIsOnline)
            txtRampTimeRight.Enabled = Not (m_blnIsOnline)
            txtPulseWidthRight.Enabled = Not (m_blnIsOnline)
            btnPulse.Enabled = Not (m_blnIsOnline)
            btnContact.Enabled = Not (m_blnIsOnline)
            If Target1Install Then
                btnTarget1Switch.Enabled = Not (m_blnIsOnline)
                btnMag1RotationStart.Enabled = Not (m_blnIsOnline)
            End If
            If Target2Install Then
                btnTarget2Switch.Enabled = Not (m_blnIsOnline)
                btnMag2RotationStart.Enabled = Not (m_blnIsOnline)
            End If
            If Target3Install Then
                btnTarget3Switch.Enabled = Not (m_blnIsOnline)
                btnMag3RotationStart.Enabled = Not (m_blnIsOnline)
            End If
            If Target4Install Then
                btnTarget4Switch.Enabled = Not (m_blnIsOnline)
                btnMag4RotationStart.Enabled = Not (m_blnIsOnline)
            End If
            If Target5Install Then
                btnTarget5Switch.Enabled = Not (m_blnIsOnline)
                btnMag5RotationStart.Enabled = Not (m_blnIsOnline)
            End If
        End Set
    End Property

#Region "Init for DC Target"
    Public Sub TypeOfDC(ByVal Type_Of_DC As String)
        m_strType_Of_DC = Type_Of_DC
        If m_lstSpecialType_DCPowerSupply.IndexOf(Type_Of_DC) = -1 Then
            ISShowPulse = False
        Else
            ISShowPulse = True
        End If
    End Sub

    Public Property ISShowPulse() As Boolean
        Get
            Return m_ISShowPulse
        End Get
        Set(ByVal value As Boolean)
            m_ISShowPulse = value
            If value = False Then
                lblRampTime.Top = lblPulseFrequency.Top
                txtRampTime.Top = txtPulseFrequency.Top
                txtRampTimeRight.Top = txtPulseFrequencyRight.Top
                lblArcCounter.Top = lblPulseWidth.Top
                txtArcCounter.Top = txtPulseWidth.Top
                lblMagnatron.Top = lblArcCounter.Bottom + 8
                txtMagnatron.Top = txtArcCounter.Bottom + 1
                lblPulseFrequency.Visible = False
                txtPulseFrequency.Visible = False
                txtPulseFrequencyRight.Visible = False
                lblPulseWidth.Visible = False
                txtPulseWidth.Visible = False
                txtPulseWidthRight.Visible = False
                lblPulseMode.Visible = False
                txtPulseMode.Visible = False
                btnPulse.Visible = False
            Else
                lblPulseMode.Visible = False
                txtPulseMode.Visible = False
                btnPulse.Visible = False
                lblArcCounter.Visible = False
                txtArcCounter.Visible = False
                lblMagnatron.Top = lblPulseMode.Top
                txtMagnatron.Top = txtPulseMode.Top
                txtArcCounter.Location = txtRampTime.Location
            End If
        End Set
    End Property

    Public WriteOnly Property PSType() As String
        Set(ByVal value As String)
            If value = "DCTarget" Then
                lblReflectedPower.Visible = False
                txtReflectedPower.Visible = False
                lblC1.Visible = False
                txtForwardPowerRight.Visible = False
                txtC1.Visible = False
                txtC1Right.Visible = False
                lblC2.Visible = False
                txtC2.Visible = False
                txtC2Right.Visible = False
                txtMatch.Visible = False
                lblMatch.Visible = False
                btnAuto.Visible = False
                lblTargetCurrent.Visible = True
                txtTargetCurrent.Visible = True
                txtDCForwardPowerRight.Visible = True
                txtDCForwardPowerRight.Left = txtForwardPowerRight.Left
                txtDCForwardPowerRight.Top = txtForwardPowerRight.Top
                lblTargetCurrent.Left = lblReflectedPower.Left
                lblTargetCurrent.Top = lblReflectedPower.Top
                txtTargetCurrent.Left = txtReflectedPower.Left
                txtTargetCurrent.Top = txtReflectedPower.Top
                lblPulseFrequency.Top = lblC1.Top
                lblPulseFrequency.Left = lblC1.Left
                lblPulseWidth.Left = lblC2.Left
                lblPulseWidth.Top = lblC2.Top
                lblRampTime.Left = lblMatch.Left
                lblRampTime.Top = lblMatch.Top
                lblMagnatron.Top = lblArcCounter.Bottom + 8
                txtMagnatron.Top = txtArcCounter.Bottom + 1
                txtPulseFrequency.Top = txtC1.Top
                txtPulseFrequencyRight.Top = txtC1.Top
                txtPulseWidth.Top = txtC2.Top
                txtPulseWidthRight.Top = txtC2.Top
                txtRampTime.Top = txtMatch.Top
                txtRampTimeRight.Top = txtMatch.Top
                lblPulseFrequency.Visible = True
                lblPulseWidth.Visible = True
                lblRampTime.Visible = True
                lblPulseMode.Visible = True
                txtPulseFrequency.Visible = True
                txtPulseFrequencyRight.Visible = True
                txtPulseWidth.Visible = True
                txtPulseWidthRight.Visible = True
                txtRampTime.Visible = True
                txtRampTimeRight.Visible = True
                btnPulse.Visible = True
                txtPulseMode.Visible = True
                lblPulseMode.Visible = True
                IsDCTargetPowerSupply = True
                lblArcCounter.Visible = True
                txtArcCounter.Visible = True
                lbErrorMes.Top = 206
                txtForwardPower.Visible = False
                txtDCForwardPower.Visible = True
                txtDCVoltage.Visible = True
                txtVoltage.Visible = False
                lblMagnatron.Visible = MagnatronInstalled
                txtMagnatron.Visible = MagnatronInstalled
                'Me.Size = New System.Drawing.Size(325, 322)
            End If
        End Set
    End Property
#End Region
    Public Property IsBiasPowerSupply() As Boolean
        Get
            Return m_blnIsBiasPowerSupply
        End Get
        Set(ByVal value As Boolean)
            m_blnIsBiasPowerSupply = value
            If m_SerenPowerPopup IsNot Nothing Then
                m_SerenPowerPopup.IsBiasPowerSupply = m_blnIsBiasPowerSupply
            End If
            btnTarget1Switch.Visible = Not value
            btnTarget2Switch.Visible = Not value
            btnTarget3Switch.Visible = Not value
            btnTarget4Switch.Visible = Not value
            btnTarget5Switch.Visible = Not value
            btnContact.Visible = value
            txtGrounded.Visible = value
            pnTarget.Visible = Not value
            lblChuckContactPosition.Visible = value
            'txtVoltageRight.Visible = value
            txtVoltageRight.IsReadBack = Not value
            If value Then
                lbErrorMes.Location = New System.Drawing.Point(2, 178)
            Else
                lbErrorMes.Location = New System.Drawing.Point(2, 151)
            End If

        End Set
    End Property

    Public Property IsDCTargetPowerSupply() As Boolean
        Get
            Return m_blnIsDCTargetPowerSupply
        End Get
        Set(ByVal value As Boolean)
            m_blnIsDCTargetPowerSupply = value
        End Set
    End Property


    Private Sub btnAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto.Click
        If btnAuto.Clickable Then
            Dim strMessageText As String = String.Empty
            Dim strChamberName As String = String.Empty
            Dim dlgResult As DialogResult = Nothing
            Dim eStatus As SL_CustomButton.DisplayStatus = SL_CustomButton.DisplayStatus.Unknow
            Try
                strChamberName = AVPLib.Utils.chamberID2ChamberName(ChamberName)
                Dim Source As String = btnAuto.TypeOfChamberSupport.ToString() & "." & btnAuto.Name & "." & btnAuto.Status.ToString
                strMessageText = AVPLib.ContainerData.GetMessageText(Source)

                eStatus = btnAuto.Status
                If eStatus = SL_CustomButton.DisplayStatus.Unknow Then
                    dlgResult = Utils.ShowAVPMessageBoxWith_AutoManualCancelConfirm(strMessageText, strChamberName, MessageBoxIcon.Information)
                    If dlgResult = Windows.Forms.DialogResult.OK Then
                        eStatus = SL_CustomButton.DisplayStatus.Off
                    ElseIf dlgResult = Windows.Forms.DialogResult.No Then
                        eStatus = SL_CustomButton.DisplayStatus.On
                    End If
                Else
                    dlgResult = Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information)
                End If

                If dlgResult <> DialogResult.Cancel Then
                    Dim strLogMessage As String = String.Empty
                    Dim strSourceLogMessage As String = String.Empty
                    strSourceLogMessage = "[" + strChamberName + "-" + Me.Text + "]"

                    If eStatus = SL_CustomButton.DisplayStatus.On Then
                        strLogMessage = "Turn Match to Manual"
                        m_stoStatusObject.RequestStatus(btnAuto.AccessibleName, STR_OFF)

                    Else
                        strLogMessage = "Turn Match to Auto"
                        m_stoStatusObject.RequestStatus(btnAuto.AccessibleName, STR_ON)
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                       strSourceLogMessage + " " + strLogMessage)

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End If
    End Sub

#Region "Remove code"
    'Private Sub btnStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim strMessageText As String = String.Empty
    '    Dim strChamberName As String = String.Empty
    '    Try
    '        strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
    '        Dim Source As String = btnStore.TypeOfChamberSupport.ToString() & "." & btnStore.Name
    '        strMessageText = AVPLib.ContainerData.GetMessageText(Source)

    '        If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = DialogResult.OK Then
    '            Dim strLogMessage As String = String.Empty
    '            Dim strSourceLogMessage As String = String.Empty

    '            strLogMessage = "Store"
    '            strSourceLogMessage = "[" + strChamberName + "-" + Me.Text + "]"

    '            Dim ChamberModule As AVPLib.SystemModule = _
    '                          AVPLib.ContainerData.GetRobotConfig(Me.Parent.Name) ''get preset config file

    '            Dim PresetValue As AVPLib.SystemModule.PresetTable = Nothing

    '            If Me.Name = BIAS_POWER_SUPPLY_STR AndAlso _
    '             (ChamberModule.BiasPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_1250 Or _
    '             ChamberModule.BiasPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_2000) Then
    '                ''just send command to CORONA
    '                m_stoStatusObject.RequestStatus(btnStore.AccessibleName, txtPresetsRight.Text)
    '                Exit Sub
    '            ElseIf Me.Name = BIAS_POWER_SUPPLY_STR Then
    '                PresetValue = ChamberModule.BiasPresetValue.Item(CInt(txtPresetsRight.Text).ToString())

    '            ElseIf Me.Name = RFTARGET_POWER_SUPPLY_STR AndAlso _
    '                (ChamberModule.RFTargetPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_1250 Or _
    '                 ChamberModule.RFTargetPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_2000) Then
    '                ''just send command to CORONA
    '                m_stoStatusObject.RequestStatus(btnStore.AccessibleName, txtPresetsRight.Text)
    '                Exit Sub
    '            ElseIf Me.Name = RFTARGET_POWER_SUPPLY_STR Then
    '                PresetValue = ChamberModule.TargetPresetValue.Item(CInt(txtPresetsRight.Text).ToString())
    '            End If

    '            PresetValue.C1 = txtC1Right.Text
    '            PresetValue.C2 = txtC2Right.Text
    '            AVPLib.Utils.SavePresetValue(ChamberModule, PresetValue, _
    '                                          Me.Name, ChamberModule.TargetPresetValue, ChamberModule.BiasPresetValue)
    '            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeEvent, AVPLib.ContainerData.LogSource.AVPMainScreen, _
    '                                               strSourceLogMessage + " " + strLogMessage)
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub

    'Private Sub btnRecall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim strMessageText As String = String.Empty
    '    Dim strChamberName As String = String.Empty
    '    Try
    '        strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
    '        Dim Source As String = btnStore.TypeOfChamberSupport.ToString() & "." & btnRecall.Name
    '        strMessageText = AVPLib.ContainerData.GetMessageText(Source)

    '        If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = DialogResult.OK Then

    '            Dim strLogMessage As String = String.Empty
    '            Dim strSourceLogMessage As String = String.Empty

    '            strLogMessage = "Recall"
    '            strSourceLogMessage = "[" + strChamberName + "-" + Me.Text + "]"

    '            Dim ChamberModule As AVPLib.SystemModule = _
    '                                 AVPLib.ContainerData.GetRobotConfig(Me.Parent.Name) ''get preset config file
    '            Dim PresetValue As AVPLib.SystemModule.PresetTable = Nothing
    '            If Me.Name = BIAS_POWER_SUPPLY_STR AndAlso _
    '             (ChamberModule.BiasPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_1250 Or _
    '             ChamberModule.BiasPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_2000) Then
    '                ''just send command to CORONA
    '                m_stoStatusObject.RequestStatus(btnRecall.AccessibleName, txtPresetsRight.Text)
    '                Exit Sub
    '            ElseIf Me.Name = BIAS_POWER_SUPPLY_STR Then
    '                ''get, set value to AVP
    '                PresetValue = ChamberModule.BiasPresetValue.Item(CInt(txtPresetsRight.Text).ToString())

    '            ElseIf (Me.Name = RFTARGET_POWER_SUPPLY_STR) AndAlso _
    '            (ChamberModule.RFTargetPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_1250 Or _
    '              ChamberModule.RFTargetPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_2000) Then
    '                ''just send command to CORONA
    '                m_stoStatusObject.RequestStatus(btnRecall.AccessibleName, txtPresetsRight.Text)
    '                Exit Sub
    '            ElseIf Me.Name = RFTARGET_POWER_SUPPLY_STR Then
    '                ''get, set value to AVP
    '                PresetValue = ChamberModule.TargetPresetValue.Item(CInt(txtPresetsRight.Text).ToString())
    '            End If

    '            txtC1Right.Text = Double.Parse(PresetValue.C1) ', AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
    '            txtC2Right.Text = Double.Parse(PresetValue.C2) ', AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
    '            m_stoStatusObject.RequestStatus(txtC1Right.AccessibleName, txtC1Right.Text)
    '            m_stoStatusObject.RequestStatus(txtC2Right.AccessibleName, txtC2Right.Text)

    '            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
    '                                               strSourceLogMessage + "Recall Preset")
    '            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
    '                                               strSourceLogMessage + " Change C1 to: " + txtC1Right.Text)
    '            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
    '                                               strSourceLogMessage + " Change C2 to: " + txtC2Right.Text)
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub
#End Region

    Friend Overrides Sub Header_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If IsDCTargetPowerSupply Then
                Exit Sub
            End If
            Dim ChamberModule As AVPLib.SystemModule =
                                AVPLib.ContainerData.GetRobotConfig(ChamberName) ''get preset config file
            If (Me.Name = BIAS_POWER_SUPPLY_STR AndAlso m_lstSpecialType_PowerSupply.Contains(ChamberModule.BiasPowerModel)) OrElse
                        (Me.Name = RFTARGET_POWER_SUPPLY_STR) AndAlso m_lstSpecialType_PowerSupply.Contains(ChamberModule.RFTargetPowerModel) Then
                Exit Sub
            End If
            m_SerenPowerPopup.ShowDialog(Me)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.AutoSizeMode = AutoScaleMode.None

        'just for DC
        m_lstSpecialType_DCPowerSupply = New List(Of String)
        With m_lstSpecialType_DCPowerSupply
            .Add(AVPLib.SystemModule.Power_Supply_Model.AE_PULSE_DC)
            .Add(AVPLib.SystemModule.Power_Supply_Model.ENI_RPG_50_100)
            .Add(AVPLib.SystemModule.Power_Supply_Model.ENI_RPG50)
            .Add(AVPLib.SystemModule.Power_Supply_Model.ENI_RPG100)
        End With

        m_lstSpecialType_PowerSupply = New List(Of String)
        m_lstSpecialType_PowerSupply.Add(AVPLib.SystemModule.Power_Supply_Model.ENI_1250)
        m_lstSpecialType_PowerSupply.Add(AVPLib.SystemModule.Power_Supply_Model.ENI_2000)
        m_lstSpecialType_PowerSupply.Add(AVPLib.SystemModule.Power_Supply_Model.MKS_3513)
        m_SerenPowerPopup = New SerenPopUp(Me)
        'AddHandler m_SerenPowerPopup.TextboxClick, AddressOf 
        ' Add any initialization after the InitializeComponent() call.
        AddHandler m_SerenPowerPopup.AutoButtonClick, AddressOf btnAuto_Click
    End Sub

    Private Sub txtErrorMessage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtErrorMessage.TextChanged
        Try
            m_SerenPowerPopup.lbTextError.Text = txtErrorMessage.Text
            lbErrorMes.Text = txtErrorMessage.Text
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtMatch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMatch.TextChanged
        If txtMatch.Text = "Auto" Then
            Me.txtC2Right.Enabled = False
            Me.txtC1Right.Enabled = False
        Else
            Me.txtC2Right.Enabled = True
            Me.txtC1Right.Enabled = True
        End If
    End Sub

    Private Sub txtForwardPowerRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtForwardPowerRight.Click
        Try
            If txtForwardPowerRight.Clickable Then
                Dim chamberName As String = String.Empty
                Dim Source_Title As String = String.Empty
                Dim Source As String = txtForwardPowerRight.GetSource()
                Source_Title = IIf(txtForwardPowerRight.AccessibleDescription <> String.Empty, txtForwardPowerRight.TypeOfChamberSupport.ToString() & "." & txtForwardPowerRight.AccessibleDescription, txtForwardPowerRight.TypeOfChamberSupport.ToString() & "." & txtForwardPowerRight.Name)
                Dim frm As New NumPad
                Dim Min As Double
                Dim Max As Double
                If txtForwardPowerRight.GetDefaultMinMax = True Then
                    Min = MINDEFAULT
                    Max = MAXDEFAULT
                Else
                    Min = Double.Parse(AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN).ToString())
                    Max = Double.Parse(AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX).ToString())
                End If
                Dim Title As String = AVPLib.ContainerData.GetMessageText(Source_Title)
                Dim strPreviousValue As String = txtForwardPowerRight.Text
                If String.IsNullOrEmpty(Title) Then
                    Title = AVPLib.ContainerData.GetMessageText(Source)
                End If
                Dim value As String = txtForwardPowerRight.Text
                Title = String.Format(Title, txtForwardPowerRight.AccessibleName)
                Dim InputRes As MsgBoxResult = frm.GetUserInput(value, -1, -1, Min, Max, Title)

                If frm.IsMaxMinModified Then
                    txtForwardPowerRight.UpdateMinMaxValue(Source, frm.NewMin.ToString(), frm.NewMax.ToString())

                    If Min <> frm.NewMin Then
                        Utils.LogUserEvent(String.Format("Changed MIN of {0} from {1} to {2}", Utils.GetLogName(sender), Min, frm.NewMin), Utils.GetPMContainer(sender))
                    End If

                    If Max <> frm.NewMax Then
                        Utils.LogUserEvent(String.Format("Changed MAX of {0} from {1} to {2}", Utils.GetLogName(sender), Max, frm.NewMax), Utils.GetPMContainer(sender))
                    End If
                End If

                If InputRes = MsgBoxResult.Ok Then
                    ' Log
                    Utils.LogUserEvent(sender, "", "", "", txtForwardPowerRight.Text, value)
                    txtForwardPowerRight.Text = value
                    Dim strname As String = txtForwardPowerRight.AccessibleName.Replace(" ", "")
                    m_stoStatusObject.RequestStatus(strname, value)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Function ActiveTarget() As Integer
        If btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.On Then
            Return 1
        ElseIf btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.On Then
            Return 2
        ElseIf btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.On Then
            Return 3
        ElseIf btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.On Then
            Return 4
        ElseIf btnTarget5Switch.Status = SL_CustomButton.DisplayStatus.On Then
            Return 5
        End If
    End Function

    Private Sub btnContact_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContact.StatusChange
        Try
            If btnContact.Status = SL_CustomButton.DisplayStatus.On Then
                txtGrounded.Text = "Grounded"
                btnContact.Text = "Float"
            ElseIf btnContact.Status = SL_CustomButton.DisplayStatus.Off Then
                txtGrounded.Text = "Float"
                btnContact.Text = "Ground"
            Else
                txtGrounded.Text = ""
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContact.Click
        Dim strMessageText As String = String.Empty
        Dim strChamberName As String = String.Empty
        Try
            strChamberName = AVPLib.Utils.chamberID2ChamberName(ChamberName)
            Dim Source As String = btnContact.TypeOfChamberSupport.ToString() & "." & btnContact.Name & "." & btnContact.Status.ToString
            strMessageText = AVPLib.ContainerData.GetMessageText(Source)

            If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = DialogResult.OK Then
                Dim strLogMessage As String = String.Empty
                Dim strSourceLogMessage As String = String.Empty
                strSourceLogMessage = "[" + strChamberName + "-" + Me.Text + "]"

                If btnContact.Status = SL_CustomButton.DisplayStatus.On Then
                    strLogMessage = "Turn Ground to Float"
                    m_stoStatusObject.RequestStatus(btnContact.AccessibleName, STR_OFF)

                Else
                    strLogMessage = "Turn Float to Ground"
                    m_stoStatusObject.RequestStatus(btnContact.AccessibleName, STR_ON)
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                   strSourceLogMessage + " " + strLogMessage)

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Property Target1Install() As Boolean
        Get
            Return m_Target1Install
        End Get
        Set(ByVal value As Boolean)
            m_Target1Install = value
            Panel1.Visible = value
        End Set
    End Property
    Public Property Target2Install() As Boolean
        Get
            Return m_Target2Install
        End Get
        Set(ByVal value As Boolean)
            m_Target2Install = value
            Panel2.Visible = value
        End Set
    End Property
    Public Property Target3Install() As Boolean
        Get
            Return m_Target3Install
        End Get
        Set(ByVal value As Boolean)
            m_Target3Install = value
            Panel3.Visible = value
        End Set
    End Property
    Public Property Target4Install() As Boolean
        Get
            Return m_Target4Install
        End Get
        Set(ByVal value As Boolean)
            m_Target4Install = value
            Panel4.Visible = value
        End Set
    End Property
    Public Property Target5Install() As Boolean
        Get
            Return m_Target5Install
        End Get
        Set(ByVal value As Boolean)
            m_Target5Install = value
            Panel5.Visible = value
        End Set
    End Property
    Public Property MagnatronInstalled() As Boolean
        Get
            Return m_MagnatronInstalled
        End Get
        Set(ByVal value As Boolean)
            m_MagnatronInstalled = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-06-25</date>
    ''' </author>
    ''' <summary>
    ''' Arrange Target
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ArrangTarget()
        If Not Target1Install Then
            Panel5.Location = Panel4.Location
            Panel4.Location = Panel3.Location
            Panel3.Location = Panel2.Location
            Panel2.Location = Panel1.Location
        End If
        If Not Target2Install Then
            Panel5.Location = Panel4.Location
            Panel4.Location = Panel3.Location
            Panel3.Location = Panel2.Location
        End If
        If Not Target3Install Then
            Panel5.Location = Panel4.Location
            Panel4.Location = Panel3.Location
        End If
        If Not Target4Install Then
            Panel5.Location = Panel4.Location
        End If
    End Sub

    Private Sub btnTarget4Switch_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarget4Switch.StatusChange, btnTarget3Switch.StatusChange, btnTarget2Switch.StatusChange, btnTarget1Switch.StatusChange, btnTarget5Switch.StatusChange
        If btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.Off _
          AndAlso btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.Off _
          AndAlso btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.Off _
          AndAlso btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.Off _
          AndAlso btnTarget5Switch.Status = SL_CustomButton.DisplayStatus.Off Then
            txtForwardPowerRight.Clickable = False
            txtC1Right.Clickable = False
            txtC2Right.Clickable = False
            txtDCForwardPowerRight.Clickable = False
            btnAuto.Clickable = False
            btnPulse.Clickable = False
        Else
            txtForwardPowerRight.Clickable = True
            txtC1Right.Clickable = True
            txtC2Right.Clickable = True
            txtDCForwardPowerRight.Clickable = True
            btnAuto.Clickable = True
            btnPulse.Clickable = True
        End If

        ' Raise event when active target changed
        Dim targetIndex As PVD4TargetControl.TargetIndexs = PVD4TargetControl.TargetIndexs.None
        If btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.On Then
            targetIndex = PVD4TargetControl.TargetIndexs.Target1
            btnMag1RotationStart.Visible = MagnatronInstalled
            btnMag1RotationStart.Top = txtArcCounter.Bottom + 2
            btnMag2RotationStart.Visible = False
            btnMag3RotationStart.Visible = False
            btnMag4RotationStart.Visible = False
            btnMag5RotationStart.Visible = False
        ElseIf btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.On Then
            targetIndex = PVD4TargetControl.TargetIndexs.Target2
            btnMag2RotationStart.Visible = MagnatronInstalled
            btnMag2RotationStart.Top = txtArcCounter.Bottom + 2
            btnMag1RotationStart.Visible = False
            btnMag3RotationStart.Visible = False
            btnMag4RotationStart.Visible = False
            btnMag5RotationStart.Visible = False
        ElseIf btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.On Then
            targetIndex = PVD4TargetControl.TargetIndexs.Target3
            btnMag3RotationStart.Visible = MagnatronInstalled
            btnMag3RotationStart.Top = txtArcCounter.Bottom + 2
            btnMag2RotationStart.Visible = False
            btnMag1RotationStart.Visible = False
            btnMag4RotationStart.Visible = False
            btnMag5RotationStart.Visible = False
        ElseIf btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.On Then
            targetIndex = PVD4TargetControl.TargetIndexs.Target4
            btnMag4RotationStart.Visible = MagnatronInstalled
            btnMag4RotationStart.Top = txtArcCounter.Bottom + 2
            btnMag2RotationStart.Visible = False
            btnMag3RotationStart.Visible = False
            btnMag1RotationStart.Visible = False
            btnMag5RotationStart.Visible = False
        ElseIf btnTarget5Switch.Status = SL_CustomButton.DisplayStatus.On Then
            targetIndex = PVD4TargetControl.TargetIndexs.Target5
            btnMag5RotationStart.Visible = MagnatronInstalled
            btnMag5RotationStart.Top = txtArcCounter.Bottom + 2
            btnMag4RotationStart.Visible = False
            btnMag3RotationStart.Visible = False
            btnMag3RotationStart.Visible = False
            btnMag1RotationStart.Visible = False
        End If

        If targetIndex <> m_activeTarget Then
            m_activeTarget = targetIndex
            RaiseEvent TargetSwitched(m_activeTarget)
        End If
    End Sub

    Private Sub Header_StatusChange(sender As Object, e As EventArgs) Handles Header.StatusChange
        RaiseEvent HeaderStatusChange(sender, e)
    End Sub
End Class
