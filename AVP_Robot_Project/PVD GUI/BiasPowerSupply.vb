Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class BiasPowerSupply
    Public Enum PowerSupplyType
        BiasPowerSupply
        RFTargetPowerSupply
    End Enum
    Private m_blnIsOnline As Boolean = False
    Private m_blnIsBiasPowerSupply As Boolean = True
#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtForwardPowerRight.Enabled = (Not m_blnIsOnline)
            txtC1Right.Enabled = Not m_blnIsOnline
            txtC2Right.Enabled = Not m_blnIsOnline
            txtPresetsRight.Enabled = Not m_blnIsOnline
            btnAuto.Enabled = Not m_blnIsOnline
            btnRecall.Enabled = Not m_blnIsOnline
            btnStore.Enabled = Not m_blnIsOnline
            txtVoltageRight.Enabled = (Not m_blnIsOnline)

            If Not m_blnIsOnline Then ''if not online->set enable/disable rule
                If String.IsNullOrEmpty(txtVoltageRight.Text) Then
                    txtForwardPowerRight.Enabled = True
                Else
                    txtForwardPowerRight.Enabled = IIf(CDbl(txtVoltageRight.Text) <= 0, True, False)
                End If
                If String.IsNullOrEmpty(txtForwardPowerRight.Text) Then
                    txtVoltageRight.Enabled = True
                Else
                    txtVoltageRight.Enabled = IIf(CDbl(txtForwardPowerRight.Text) <= 0, True, False)
                End If
            End If
        End Set
    End Property

    Public Property IsBiasPowerSupply() As Boolean
        Get
            Return m_blnIsBiasPowerSupply
        End Get
        Set(ByVal value As Boolean)
            m_blnIsBiasPowerSupply = value
            If m_blnIsBiasPowerSupply Then
                txtVoltageRight.Visible = True
            Else
                txtVoltageRight.Visible = False
            End If
        End Set
    End Property
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbForwardPower As New StatusTextBox(Me.txtForwardPower)
            Dim stbForwardPowerRight As New StatusTextBox(Me.txtForwardPowerRight)

            Dim stbReflectedPower As New StatusTextBox(Me.txtReflectedPower)
            Dim stbVoltage As New StatusTextBox(Me.txtVoltage)
            Dim stbKWH As New StatusTextBox(Me.txtKWH)

            Dim stbC1 As New StatusTextBox(Me.txtC1)
            Dim stbC1Right As New StatusTextBox(Me.txtC1Right)

            Dim stbC2 As New StatusTextBox(Me.txtC2)
            Dim stbC2Right As New StatusTextBox(Me.txtC2Right)

            Dim stbMatch As New StatusTextBox(Me.txtMatch)
            Dim stbPresets As New StatusTextBox(Me.txtPresets)
            Dim stbPresetsRight As New StatusTextBox(Me.txtPresetsRight)
            Dim sbcStatus As New StatusIGCGButton(Me.Header)
            Dim sbcAuto As New StatusIGCGButton(Me.btnAuto)
            Dim sbcRecall As New StatusIGCGButton(Me.btnRecall)
            Dim sbcStore As New StatusIGCGButton(Me.btnStore)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbcAuto)
            m_stoStatusObject.AddChild(sbcRecall)
            m_stoStatusObject.AddChild(sbcStore)
            m_stoStatusObject.AddChild(stbForwardPower)
            m_stoStatusObject.AddChild(stbForwardPowerRight)
            m_stoStatusObject.AddChild(stbReflectedPower)
            m_stoStatusObject.AddChild(stbVoltage)
            m_stoStatusObject.AddChild(stbC1)
            m_stoStatusObject.AddChild(stbC1Right)
            m_stoStatusObject.AddChild(stbC2)
            m_stoStatusObject.AddChild(stbC2Right)
            m_stoStatusObject.AddChild(stbMatch)
            m_stoStatusObject.AddChild(stbPresets)
            m_stoStatusObject.AddChild(stbPresetsRight)
            m_stoStatusObject.AddChild(sbcStatus)
            m_stoStatusObject.AddChild(stbKWH)
            If IsBiasPowerSupply Then
                Dim stbVoltageRight As New StatusTextBox(Me.txtVoltageRight)
                m_stoStatusObject.AddChild(stbVoltageRight)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub txtTargetPowerRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtForwardPowerRight.Click, _
                                                                  txtC1Right.Click, txtC2Right.Click, txtPresetsRight.Click, txtVoltageRight.Click
        Try
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            Dim Source As String = Me.Parent.Name & "." & PVD + "." + m_stoStatusObject.Name + "." + TextBox.Name

            Dim frm As New NumPad()
            Dim Min As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN)
            Dim Max As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX)
            Dim Title As String = AVPLib.ContainerData.GetMessageText(PVD + "." + TextBox.Name)
            Dim Value As String = TextBox.Text

            Dim InputRes As MsgBoxResult = frm.GetUserInput(Value, -1, -1, Min, Max, Title)

            If frm.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, frm.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, frm.NewMax)
                '#07/07/2011 
                '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                '# If any param that does not have min/max, we will have to add it's min/max.
                '#Begin fix: read min/max value in child node of "FromIBEConfig" or "FromPVDConfig"
                If TypeOf (TextBox) Is PVDTextbox Then
                    Dim tempTextBox As PVDTextbox = CType(sender, PVDTextbox)
                    If tempTextBox.UseBackGroundWorkerToUpdateMinMax Then
                        tempTextBox.UpdateMinMaxValueToPM(Source, frm.NewMin, frm.NewMax)
                    End If
                End If
                '#End fix
            End If

            If InputRes = MsgBoxResult.Ok Then
                TextBox.Text = Value
                If (TextBox Is txtVoltageRight) And IsBiasPowerSupply Then ''this rule apply for Bias only
                    If String.IsNullOrEmpty(Value) Then
                        txtForwardPowerRight.Enabled = True
                    Else
                        txtForwardPowerRight.Enabled = IIf(CDbl(Value) > 0, False, True)
                    End If
                ElseIf TextBox Is txtForwardPowerRight And IsBiasPowerSupply Then ''this rule apply for Bias only
                    If String.IsNullOrEmpty(Value) Then
                        txtVoltageRight.Enabled = True
                    Else
                        txtVoltageRight.Enabled = IIf(CDbl(Value) > 0, False, True)
                    End If
                End If
                'Not good as this
                Dim strTxtBoxName As String = String.Empty
                strTxtBoxName = Replace(TextBox.Name, "txt", "")
                strTxtBoxName = Replace(strTxtBoxName, "Right", "")
                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-" + Me.Text + "] Change " + strTxtBoxName + " to " + Value)

                'do not send request status for preset
                If Not TextBox.Name = "txtPresetsRight" Then
                    m_stoStatusObject.RequestStatus(TextBox.Name, TextBox.Text)
                End If
                Dim ChamberModule As AVPLib.SystemModule = _
                                     AVPLib.ContainerData.GetRobotConfig(Me.Parent.Name) ''get preset config file
                If Me.Name = BIAS_POWER_SUPPLY_STR AndAlso _
                (ChamberModule.BiasPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_1250 Or _
                ChamberModule.BiasPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_2000) OrElse _
                   (Me.Name = RFTARGET_POWER_SUPPLY_STR) AndAlso _
                   (ChamberModule.RFTargetPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_1250 Or _
                    ChamberModule.RFTargetPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_2000) Then
                    Exit Try
                End If

                Try
                    'change to scientific format
                    Dim strRetValue As String = TextBox.Text
                    If strRetValue.Length > 0 And sender Is txtPresetsRight Then
                        ' Load C1, C2
                        Dim PresetValue As AVPLib.SystemModule.PresetTable = Nothing

                        If Me.Name = BIAS_POWER_SUPPLY_STR Then
                            PresetValue = ChamberModule.BiasPresetValue.Item(CInt(txtPresetsRight.Text).ToString())
                        Else
                            PresetValue = ChamberModule.TargetPresetValue.Item(CInt(txtPresetsRight.Text).ToString())
                        End If

                        txtC1Right.Text = Double.Parse(PresetValue.C1)
                        txtC2Right.Text = Double.Parse(PresetValue.C2)
                    End If

                    TextBox.Text = strRetValue
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Private Sub btnAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto.Click
        Dim strMessageText As String = String.Empty
        Dim strChamberName As String = String.Empty
        Try
            strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
            PVDSupport.ReadMessageText(sender, Me.Parent, strMessageText)

            If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = DialogResult.OK Then
                Dim strLogMessage As String = String.Empty
                Dim strSourceLogMessage As String = String.Empty
                strSourceLogMessage = "[" + strChamberName + "-" + Me.Text + "]"

                If CType(sender, ButtonIGCGControl).Status = DisplayStatus.On Then
                    strLogMessage = "Turn Match to Manual"
                    m_stoStatusObject.RequestStatus(btnAuto.Name, STR_OFF)

                Else
                    strLogMessage = "Turn Match to Auto"
                    m_stoStatusObject.RequestStatus(btnAuto.Name, STR_ON)
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   strSourceLogMessage + " " + strLogMessage)

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnRecall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecall.Click
        Dim strMessageText As String = String.Empty
        Dim strChamberName As String = String.Empty
        Try
            strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
            PVDSupport.ReadMessageText(sender, Me.Parent, strMessageText)

            If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = DialogResult.OK Then

                Dim strLogMessage As String = String.Empty
                Dim strSourceLogMessage As String = String.Empty

                strLogMessage = "Recall"
                strSourceLogMessage = "[" + strChamberName + "-" + Me.Text + "]"

                Dim ChamberModule As AVPLib.SystemModule = _
                                     AVPLib.ContainerData.GetRobotConfig(Me.Parent.Name) ''get preset config file
                Dim PresetValue As AVPLib.SystemModule.PresetTable = Nothing
                If Me.Name = BIAS_POWER_SUPPLY_STR AndAlso _
                 (ChamberModule.BiasPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_1250 Or _
                 ChamberModule.BiasPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_2000) Then
                    ''just send command to PVD 
                    m_stoStatusObject.RequestStatus(btnRecall.Name, txtPresetsRight.Text)
                    Exit Sub
                ElseIf Me.Name = BIAS_POWER_SUPPLY_STR Then
                    ''get, set value to AVP
                    PresetValue = ChamberModule.BiasPresetValue.Item(CInt(txtPresetsRight.Text).ToString())

                ElseIf (Me.Name = RFTARGET_POWER_SUPPLY_STR) AndAlso _
                (ChamberModule.RFTargetPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_1250 Or _
                  ChamberModule.RFTargetPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_2000) Then
                    ''just send command to PVD
                    m_stoStatusObject.RequestStatus(btnRecall.Name, txtPresetsRight.Text)
                    Exit Sub
                ElseIf Me.Name = RFTARGET_POWER_SUPPLY_STR Then
                    ''get, set value to AVP
                    PresetValue = ChamberModule.TargetPresetValue.Item(CInt(txtPresetsRight.Text).ToString())
                End If

                txtC1Right.Text = Double.Parse(PresetValue.C1) ', AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                txtC2Right.Text = Double.Parse(PresetValue.C2) ', AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                m_stoStatusObject.RequestStatus(txtC1Right.Name, txtC1Right.Text)
                m_stoStatusObject.RequestStatus(txtC2Right.Name, txtC2Right.Text)

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   strSourceLogMessage + "Recall Preset")
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   strSourceLogMessage + " Change C1 to: " + txtC1Right.Text)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   strSourceLogMessage + " Change C2 to: " + txtC2Right.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStore.Click
        Dim strMessageText As String = String.Empty
        Dim strChamberName As String = String.Empty
        Try
            strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
            PVDSupport.ReadMessageText(sender, Me.Parent, strMessageText)

            If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = DialogResult.OK Then
                Dim strLogMessage As String = String.Empty
                Dim strSourceLogMessage As String = String.Empty

                strLogMessage = "Store"
                strSourceLogMessage = "[" + strChamberName + "-" + Me.Text + "]"

                Dim ChamberModule As AVPLib.SystemModule = _
                              AVPLib.ContainerData.GetRobotConfig(Me.Parent.Name) ''get preset config file

                Dim PresetValue As AVPLib.SystemModule.PresetTable = Nothing

                If Me.Name = BIAS_POWER_SUPPLY_STR AndAlso _
                 (ChamberModule.BiasPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_1250 Or _
                 ChamberModule.BiasPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_2000) Then
                    ''just send command to PVD
                    m_stoStatusObject.RequestStatus(btnStore.Name, txtPresetsRight.Text)
                    Exit Sub
                ElseIf Me.Name = BIAS_POWER_SUPPLY_STR Then
                    PresetValue = ChamberModule.BiasPresetValue.Item(CInt(txtPresetsRight.Text).ToString())

                ElseIf Me.Name = RFTARGET_POWER_SUPPLY_STR AndAlso _
                    (ChamberModule.RFTargetPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_1250 Or _
                     ChamberModule.RFTargetPowerModel = AVPLib.SystemModule.Power_Supply_Model.ENI_2000) Then
                    ''just send command to PVD
                    m_stoStatusObject.RequestStatus(btnStore.Name, txtPresetsRight.Text)
                    Exit Sub
                ElseIf Me.Name = RFTARGET_POWER_SUPPLY_STR Then
                    PresetValue = ChamberModule.TargetPresetValue.Item(CInt(txtPresetsRight.Text).ToString())
                End If

                PresetValue.C1 = txtC1Right.Text
                PresetValue.C2 = txtC2Right.Text
                AVPLib.Utils.SavePresetValue(ChamberModule, PresetValue, _
                                              Me.Name, ChamberModule.TargetPresetValue, ChamberModule.BiasPresetValue)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeEvent, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   strSourceLogMessage + " " + strLogMessage)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub StartProcessing() ''reset editbox to empty
        Me.txtForwardPowerRight.Text = String.Empty
        Me.txtC1Right.Text = String.Empty
        Me.txtC2Right.Text = String.Empty
        Me.txtPresetsRight.Text = String.Empty
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
#End Region


End Class
