Imports AVPLib
Imports AVPLib.DataManagerment
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls

Public Class SystemSetupShieldQuartz
    Protected m_strChamberName As String = String.Empty
    Protected m_parentStatusObject As StatusObject

    ' Varible use for log, store text of textbox before changed in form
    Protected m_mapValueChanged As New Hashtable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Property"

    Public Property ParentStatusObject() As StatusObject
        Get
            Return m_parentStatusObject
        End Get
        Set(ByVal value As StatusObject)
            m_parentStatusObject = value
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

#Region "Events"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Enable/Disable max textbox
    ''' </summary>
    Private Sub EnableMax(ByVal isEnabled)
        Me.txtT1Max.Enabled = isEnabled
        Me.txtT2Max.Enabled = isEnabled
        Me.txtT3Max.Enabled = isEnabled
        Me.txtT4Max.Enabled = isEnabled
        Me.txtT5Max.Enabled = isEnabled
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    Private Sub SystemSetupShieldQuartz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If ContainerForm.SystemSetup.rbUseAbsoluteKWH.Checked Then
                EnableMax(False)
            Else
                EnableMax(True)
            End If

            Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.ChamberName)
            Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.ChamberName)

            If objChamber Is Nothing OrElse chamberConfig Is Nothing Then
                Return
            End If

            Me.txtT1Limit.Text = chamberConfig.ShieldsQuartzLimit.ToString()
            Me.txtT1Warning.Text = chamberConfig.ShieldsQuartzWarning.ToString()
            Me.txtT1Max.Text = chamberConfig.Max_KWH_ShieldsQuartz.ToString()

            Me.txtT2Limit.Text = chamberConfig.ShieldsQuartzLimit1.ToString()
            Me.txtT2Warning.Text = chamberConfig.ShieldsQuartzWarning1.ToString()
            Me.txtT2Max.Text = chamberConfig.Max_KWH_ShieldsQuartz1.ToString()

            Me.txtT3Limit.Text = chamberConfig.ShieldsQuartzLimit2.ToString()
            Me.txtT3Warning.Text = chamberConfig.ShieldsQuartzWarning2.ToString()
            Me.txtT3Max.Text = chamberConfig.Max_KWH_ShieldsQuartz2.ToString()

            Me.txtT4Limit.Text = chamberConfig.ShieldsQuartzLimit3.ToString()
            Me.txtT4Warning.Text = chamberConfig.ShieldsQuartzWarning3.ToString()
            Me.txtT4Max.Text = chamberConfig.Max_KWH_ShieldsQuartz3.ToString()

            Me.txtT5Limit.Text = chamberConfig.ShieldsQuartzLimit4.ToString()
            Me.txtT5Warning.Text = chamberConfig.ShieldsQuartzWarning4.ToString()
            Me.txtT5Max.Text = chamberConfig.Max_KWH_ShieldsQuartz4.ToString()

            If ContainerForm.ChamberPanel(objChamber.Name).ChamberType = SystemModule.ModuleType.PVD4 Then
                Me.txtT1ShieldsQuartz.Text = CType(objChamber, DataManagerment.CoronaChamber).Target1_Shield_Quart.ToString("0.0000")
                Me.txtT2ShieldsQuartz.Text = CType(objChamber, DataManagerment.CoronaChamber).Target2_Shield_Quart.ToString("0.0000")
                Me.txtT3ShieldsQuartz.Text = CType(objChamber, DataManagerment.CoronaChamber).Target3_Shield_Quart.ToString("0.0000")
                Me.txtT4ShieldsQuartz.Text = CType(objChamber, DataManagerment.CoronaChamber).Target4_Shield_Quart.ToString("0.0000")
                Me.pnlT1.Enabled = chamberConfig.TargetVisible
                Me.pnlT2.Enabled = chamberConfig.Target2Visible
                Me.pnlT3.Enabled = chamberConfig.Target3Visible
                Me.pnlT4.Enabled = chamberConfig.Target4Visible
            ElseIf ContainerForm.ChamberPanel(objChamber.Name).ChamberType = SystemModule.ModuleType.PVD5T Then
                Me.txtT1ShieldsQuartz.Text = CType(objChamber, DataManagerment.PVD5TChamber).Target1_Shield_Quart.ToString("0.0000")
                Me.txtT2ShieldsQuartz.Text = CType(objChamber, DataManagerment.PVD5TChamber).Target2_Shield_Quart.ToString("0.0000")
                Me.txtT3ShieldsQuartz.Text = CType(objChamber, DataManagerment.PVD5TChamber).Target3_Shield_Quart.ToString("0.0000")
                Me.txtT4ShieldsQuartz.Text = CType(objChamber, DataManagerment.PVD5TChamber).Target4_Shield_Quart.ToString("0.0000")
                Me.txtT5ShieldsQuartz.Text = CType(objChamber, DataManagerment.PVD5TChamber).Target5_Shield_Quart.ToString("0.0000")

                Me.pnlT1.Enabled = chamberConfig.TargetVisible
                Me.pnlT2.Enabled = chamberConfig.Target2Visible
                Me.pnlT3.Enabled = chamberConfig.Target3Visible
                Me.pnlT4.Enabled = chamberConfig.Target4Visible
                Me.pnlT5.Enabled = chamberConfig.Target5Visible
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Click Event for Shields/Quartz text box
    ''' </summary>
    Private Sub ShieldsQuartz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                            txtT1ShieldsQuartz.Click, txtT2ShieldsQuartz.Click, txtT3ShieldsQuartz.Click, txtT4ShieldsQuartz.Click, txtT5ShieldsQuartz.Click
        Try
            Dim Source As String = "SystemSetup.ShieldsQuartz"
            If Not (GetUserInput(Source, sender, True) = MsgBoxResult.Ok) Then
                Exit Try
            End If
            Dim objChamber As DataManagerment.Chamber = Nothing
            Dim objController As Business.ChamberController = Nothing
            Dim txt As TextBox = CType(sender, TextBox)
            Dim strPM As String = AVPLib.Utils.chamberID2ChamberName(ChamberName)
            Dim LogShields As String = AVPLib.Utils.chamberID2ChamberName(Me.ChamberName) & "_" & AVPLib.Utils.GetChamberType(Me.ChamberName) & "_" & txt.AccessibleDescription
            objChamber = DataManagerment.EquipmentManager.GetEquipment(Me.ChamberName)
            objController = Business.ControllerManager.GetController(ChamberName)
            '''check obj exist
            If objChamber Is Nothing OrElse objController Is Nothing Then
                Exit Try
            End If
            'log action
            Dim oldValue As String = GetStoredValue(txt.Name)
            Utils.LogUserEvent(String.Format("Reset {0} {1}{2} to {3}", Utils.GetLogName(sender), strPM, IIf(String.IsNullOrEmpty(oldValue), "", " from " & oldValue), txt.Text), "System Setup")

            'check connection befor reset
            If objChamber.ConnectionStatus = DataManagerment.Equipment.WorkingStatuses.Off Then
                AVPLib.Utils.ThrowAlarm("Failed to reset value when " & strPM & " is disconnected", AVPLib.ConstEnum.GEM_ALARM_SYSTEM)
                txt.Text = oldValue
                Exit Try
            End If
            Utils.CheckChangeValue(LogShields, oldValue, txt.Text)
            If objChamber.EquipmentType() = SystemModule.ModuleType.PVD5T Then
                ''shield1,2,3,4,5
                Select Case CType(sender, TextBox).Name
                    Case txtT1ShieldsQuartz.Name
                        CType(objController.Myself, Business.PVD5TController).DoResetShieldxKWH(1, txt.Text)
                    Case txtT2ShieldsQuartz.Name
                        CType(objController.Myself, Business.PVD5TController).DoResetShieldxKWH(2, txt.Text)
                    Case txtT3ShieldsQuartz.Name
                        CType(objController.Myself, Business.PVD5TController).DoResetShieldxKWH(3, txt.Text)
                    Case txtT4ShieldsQuartz.Name
                        CType(objController.Myself, Business.PVD5TController).DoResetShieldxKWH(4, txt.Text)
                    Case txtT5ShieldsQuartz.Name
                        CType(objController.Myself, Business.PVD5TController).DoResetShieldxKWH(5, txt.Text)
                End Select
            Else
                ''shield1,2,3,4
                Select Case CType(sender, TextBox).Name
                    Case txtT1ShieldsQuartz.Name
                        CType(objController.Myself, Business.CoronaController).DoResetShieldxKWH(1, txt.Text)
                    Case txtT2ShieldsQuartz.Name
                        CType(objController.Myself, Business.CoronaController).DoResetShieldxKWH(2, txt.Text)
                    Case txtT3ShieldsQuartz.Name
                        CType(objController.Myself, Business.CoronaController).DoResetShieldxKWH(3, txt.Text)
                    Case txtT4ShieldsQuartz.Name
                        CType(objController.Myself, Business.CoronaController).DoResetShieldxKWH(4, txt.Text)
                End Select
            End If
            'End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Click Event for Warning text box
    ''' </summary>
    Protected Sub Warning_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT1Warning.Click, txtT4Warning.Click, txtT3Warning.Click, txtT2Warning.Click, txtT5Warning.Click
        Try
            Dim txt As TextBox = CType(sender, TextBox)
            If Not (GetUserInput("SystemSetup.WarningShieldsQuartz", sender, True) = MsgBoxResult.Ok) Then
                Exit Try
            End If
            Dim oldValue As String = GetStoredValue(txt.Name)
            Dim LogShields As String = AVPLib.Utils.chamberID2ChamberName(Me.ChamberName) & "_" & AVPLib.Utils.GetChamberType(Me.ChamberName) & "_" & txt.AccessibleDescription
            If SaveDataToAVPConfig(sender, txt.Text) Then
                Utils.CheckChangeValue(LogShields, oldValue, txt.Text)
                Utils.LogUserEvent(sender, "System Setup", AVPLib.Utils.chamberID2ChamberName(Me.ChamberName), "", Me.GetStoredValue(txt.Name), txt.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Click Event for Max text box
    ''' </summary>
    Protected Sub Max_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT4Max.Click, txtT3Max.Click, txtT2Max.Click, txtT1Max.Click, txtT5Max.Click
        Try
            Dim txt As TextBox = CType(sender, TextBox)
            Dim oldValue As String = GetStoredValue(txt.Name)
            Dim LogShields As String = AVPLib.Utils.chamberID2ChamberName(Me.ChamberName) & "_" & AVPLib.Utils.GetChamberType(Me.ChamberName) & "_" & txt.AccessibleDescription
            If Not (GetUserInput("SystemSetup.MaxShieldsQuartz", sender, True) = MsgBoxResult.Ok) Then
                Exit Try
            End If

            If SaveDataToAVPConfig(sender, txt.Text) Then
                Utils.CheckChangeValue(LogShields, oldValue, txt.Text)
                Utils.LogUserEvent(sender, "System Setup", AVPLib.Utils.chamberID2ChamberName(Me.ChamberName), "", Me.GetStoredValue(txt.Name), txt.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Click Event for Limit text box
    ''' </summary>
    Protected Sub Limit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT4Limit.Click, txtT3Limit.Click, txtT2Limit.Click, txtT1Limit.Click, txtT5Limit.Click
        Try
            Dim txt As TextBox = CType(sender, TextBox)
            Dim oldValue As String = GetStoredValue(txt.Name)
            Dim LogShields As String = AVPLib.Utils.chamberID2ChamberName(Me.ChamberName) & "_" & AVPLib.Utils.GetChamberType(Me.ChamberName) & "_" & txt.AccessibleDescription
            If Not (GetUserInput("SystemSetup.LimitShieldsQuartz", sender, True) = MsgBoxResult.Ok) Then
                Exit Try
            End If

            If SaveDataToAVPConfig(sender, txt.Text) Then
                Utils.LogUserEvent(sender, "System Setup", AVPLib.Utils.chamberID2ChamberName(Me.ChamberName), "", Me.GetStoredValue(txt.Name), txt.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Save data to config
    ''' </summary>
    Protected Overridable Function SaveDataToAVPConfig(ByVal sender As System.Object, ByVal value As String) As Boolean
        Dim res As Boolean = False
        Try
            Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.ChamberName)

            Select Case CType(sender, TextBox).Name
                Case Me.txtT1Limit.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzLimit.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.ShieldsQuartzLimit = Double.Parse(value)
                    End If
                Case Me.txtT1Warning.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzWarning.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.ShieldsQuartzWarning = Double.Parse(value)
                    End If
                Case Me.txtT1Max.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.Max_KWH_ShieldsQuartz.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.Max_KWH_ShieldsQuartz = Double.Parse(value)
                    End If
                Case Me.txtT2Limit.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzLimit1.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.ShieldsQuartzLimit1 = Double.Parse(value)
                    End If
                Case Me.txtT2Warning.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzWarning1.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.ShieldsQuartzWarning1 = Double.Parse(value)
                    End If
                Case Me.txtT2Max.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.Max_KWH_ShieldsQuartz1.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.Max_KWH_ShieldsQuartz1 = Double.Parse(value)
                    End If
                Case Me.txtT3Limit.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzLimit2.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.ShieldsQuartzLimit2 = Double.Parse(value)
                    End If
                Case Me.txtT3Warning.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzWarning2.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.ShieldsQuartzWarning2 = Double.Parse(value)
                    End If
                Case Me.txtT3Max.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.Max_KWH_ShieldsQuartz2.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.Max_KWH_ShieldsQuartz2 = Double.Parse(value)
                    End If
                Case Me.txtT4Limit.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzLimit3.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.ShieldsQuartzLimit3 = Double.Parse(value)
                    End If
                Case Me.txtT4Warning.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzWarning3.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.ShieldsQuartzWarning3 = Double.Parse(value)
                    End If
                Case Me.txtT4Max.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.Max_KWH_ShieldsQuartz3.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.Max_KWH_ShieldsQuartz3 = Double.Parse(value)
                    End If
                Case Me.txtT5Limit.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzLimit4.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.ShieldsQuartzLimit4 = Double.Parse(value)
                    End If
                Case Me.txtT5Warning.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzWarning4.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.ShieldsQuartzWarning4 = Double.Parse(value)
                    End If
                Case Me.txtT5Max.Name
                    res = AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.Max_KWH_ShieldsQuartz4.ToString(), value, Me.ChamberName)
                    If res Then
                        chamberConfig.Max_KWH_ShieldsQuartz4 = Double.Parse(value)
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return res
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Input value for text box
    ''' </summary>
    Protected Function GetUserInput(ByVal Source As String, ByVal TargetControl As System.Object, ByVal AllowDecimal As Boolean, Optional ByVal IsScientificFormat As Boolean = False) As MsgBoxResult
        Dim UserResponse As MsgBoxResult = MsgBoxResult.Cancel
        Try
            Dim needToCheckMaxMin As Boolean = True
            Dim Target As String = String.Empty
            Dim Min As Single = 0
            Dim Max As Single = 0
            Dim logName As String = Utils.GetLogName(TargetControl)

            Dim f As New NumPad()
            Dim Value As String = String.Empty
            If TypeOf (TargetControl) Is TextBox Then
                Value = CType(TargetControl, TextBox).Text
                Target = Source & "."
                Min = AVPLib.ContainerData.GetRobotConfig(Target + STRING_MIN)
                Max = AVPLib.ContainerData.GetRobotConfig(Target + STRING_MAX)
            Else
                Exit Function
            End If

            UserResponse = f.GetUserInput(Value, -1, -1, Min, Max, "Enter your " & logName & " value", 0, _
                                needToCheckMaxMin, AllowDecimal)
            If UserResponse = MsgBoxResult.Ok Then
                If TypeOf (TargetControl) Is TextBox Then
                    StoreValueBeforeChange(TargetControl)
                    CType(TargetControl, TextBox).Text = IIf(IsScientificFormat, Utils.ConvertDoubleToScientificFormat(Value), Value)
                End If
            End If

            If f.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Target + STRING_MIN, f.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Target + STRING_MAX, f.NewMax)

                If Min <> f.NewMin Then
                    Utils.LogUserEvent(Nothing, "System Setup", AVPLib.Utils.chamberID2ChamberName(ChamberName), "MIN of " & logName, Min, f.NewMin)
                End If

                If Max <> f.NewMax Then
                    Utils.LogUserEvent(Nothing, "System Setup", AVPLib.Utils.chamberID2ChamberName(ChamberName), "MAX of " & logName, Max, f.NewMax)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return UserResponse
    End Function

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

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Indicate the form has stored value before user changed
    ''' </summary>
    Protected Function HasChangedValue(ByVal key As String) As Boolean
        Dim hasChanged As Boolean = False
        If m_mapValueChanged.ContainsKey(key) Then
            hasChanged = True
        End If
        Return hasChanged
    End Function

    Public Function SetupTargetShieldQuartz(chamberType As SystemModule.ModuleType)
        If chamberType <> SystemModule.ModuleType.PVD5T Then
            pnlT5.Visible = False
            Label21.Visible = False
            Me.ClientSize = New System.Drawing.Size(830, 309)
        End If
    End Function
#End Region

End Class