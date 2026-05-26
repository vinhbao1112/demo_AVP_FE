Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVPControls

Public Class CryoPopUpPanel
    Public blnGoOnline As Boolean = False
    Public m_RegenParamSupport As Boolean = False

    'Info design - 1 LL install
    Private TITLE_LABLE_WITH_ONE_LL_SIZE As New Size(750, 40)
    Private BUTTON_CANCEL_WITH_ONE_LL_LOCATION As New Point(750, 0)
    Private LL_WITH_ONE_LL_LOCATION As New Point(405, 40)
    Private FORM_WITH_ONE_LL_SIZE As New Size(805, 399)
    'Info design - 0 LL install
    Private TITLE_LABLE_WITH_NO_LL_SIZE As New Size(355, 40)
    Private BUTTON_CANCEL_WITH_NO_LL_LOCATION As New Point(355, 0)
    Private FORM_WITH_NO_LL_SIZE As New Size(407, 399)
    Private m_strPanelHandle As String = String.Empty
    Private m_blnDeviceOnline As Boolean = False
    Private m_TypeOfCryoPanel As CryoPanelType = CryoPanelType.CryoPanel
    Private m_ChamberType As String = String.Empty
    Public Event ButtonPump_StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event ButtonRegen_StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event ButtonFastRegen_StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Private FakeButtonRegen As SL_CustomButton
    Private FakeButtonFastRegen As SL_CustomButton
    Private m_regenStatus As DisplayStatus
    Private m_fastRegenStatus As DisplayStatus

    Public Enum CryoPanelType
        CryoPanel
        WaterPumpPanel
    End Enum
#Region "Properties"

    Public Property DeviceOnline() As Boolean
        Get
            Return m_blnDeviceOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnDeviceOnline = value

            txtExtendedPurgeTime.Enabled = Not m_blnDeviceOnline
            txtPumpRestartDelay.Enabled = Not m_blnDeviceOnline
            txtRepurgeCycles.Enabled = Not m_blnDeviceOnline
            txtRoughToPressure.Enabled = Not m_blnDeviceOnline
            txtRateOfRise.Enabled = Not m_blnDeviceOnline
            txtStartUpTemp.Enabled = Not m_blnDeviceOnline

            btnCryoOn.Enabled = Not m_blnDeviceOnline
            btnCryoRegen.Enabled = Not m_blnDeviceOnline
            btnFastRegen.Enabled = Not m_blnDeviceOnline

        End Set
    End Property

    Public Property ChamberType() As String
        Get
            Return m_ChamberType
        End Get
        Set(ByVal value As String)
            m_ChamberType = value
            If value = "IBE" Then
                txtCryo_RegenHours.Visible = False
                txtCryo_LifeTimeHours.Visible = False
                lblLifeTimeHours.Visible = False
                lblRegenHours.Visible = False
                btnCryoRegen.Left = btnFastRegen.Left
                btnFastRegen.Visible = False
                GroupBox2.Height = 110
                txtCryoRegenStatus.Top = txtCryo_RegenHours.Top
                lblRegenStatus.Top = lblRegenHours.Top
                btnCryoOn.Top -= 30
                btnCryoRegen.Top -= 30
                btnFastRegen.Top -= 30
                Me.Height -= 30
            ElseIf value = "PVD4" Then
                txtCryo_RegenHours.Visible = True
                txtCryo_LifeTimeHours.Visible = True
                lblLifeTimeHours.Visible = True
                lblRegenHours.Visible = True
                btnCryoOn.Visible = True
                btnCryoRegen.Visible = True
                btnFastRegen.Visible = False
            Else
                txtCryo_RegenHours.Visible = True
                txtCryo_LifeTimeHours.Visible = True
                lblLifeTimeHours.Visible = True
                lblRegenHours.Visible = True
                btnCryoOn.Visible = True
                btnCryoRegen.Visible = True
                btnFastRegen.Visible = True
                GroupBox2.Height = 144
            End If
        End Set
    End Property

    Public Property RegenParamSupport() As Boolean
        Get
            Return m_RegenParamSupport
        End Get
        Set(ByVal value As Boolean)
            m_RegenParamSupport = value
            If m_RegenParamSupport = False Then
                TableLayoutPanel1.Visible = False
                Me.Height = GroupBox2.Height + Me.HeaderHeight + 5
            End If
        End Set
    End Property

    Public Property TypeOfCryoPanel() As CryoPanelType
        Get
            Return m_TypeOfCryoPanel
        End Get
        Set(ByVal value As CryoPanelType)
            m_TypeOfCryoPanel = value
            If value = CryoPanelType.WaterPumpPanel Then
                txtCryo_RegenHours.AccessibleName = "Water"
                btnFastRegen.Visible = False
                btnCryoRegen.Left = btnFastRegen.Left
                txtCryoRegenStatus.Visible = False
                lblRegenStatus.Visible = False
                GroupBox2.Height = 110
                GroupBox2.Text = "Water Pump"
                btnCryoOn.Top -= 30
                btnCryoRegen.Top -= 30
                btnFastRegen.Top -= 30
                Me.Height -= 30
                Me.Text = AVPLib.Utils.chamberID2ChamberName(PanelHandle) & " WaterPump"
            End If
        End Set
    End Property

    Public Property PanelHandle() As String
        Get
            Return m_strPanelHandle
        End Get
        Set(ByVal value As String)
            m_strPanelHandle = value
            txtCryo_RegenHours.Tag = value
        End Set
    End Property

    Public Property PopUpTitle() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-07-21</date>
    ''' <summary>
    ''' Gets or sets regen status.
    ''' </summary>
    Public Property RegenStatus() As DisplayStatus
        Get
            Return m_regenStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_regenStatus <> value Then
                m_regenStatus = value
                UpdateRegenButtons()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-07-21</date>
    ''' <summary>
    ''' Gets or sets fast regen status.
    ''' </summary>
    Public Property FastRegenStatus() As DisplayStatus
        Get
            Return m_fastRegenStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_fastRegenStatus <> value Then
                m_fastRegenStatus = value
                UpdateRegenButtons()
            End If
        End Set
    End Property

#End Region

#Region "Private methods"
    Protected Overrides Function CheckPermission() As Boolean
        Try
            Return AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_001)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Function

    Protected Overrides Sub CreateStatusTree()
        Try

            Dim sbtCryoOn As New StatusCryo_PopUpButton(btnCryoOn)
            Dim sbtCryoRegen As New StatusCryo_PopUpButton(FakeButtonRegen)
            Dim sbtFastRegen As New StatusCryo_PopUpButton(FakeButtonFastRegen)
            ' Dim sbtIGDegas As New StatusCryo_PopUpButton(btnIGDegas)

            Dim stbRegenHour As New StatusCryoRegenHour_PopUpTextbox(txtCryo_RegenHours)
            Dim stbLifeTimeHour As New StatusCryo_PopUpTextbox(txtCryo_LifeTimeHours)
            Dim stbCryoRegenStatus As New StatusCryo_PopUpTextbox(txtCryoRegenStatus)

            Dim stbROR As New StatusCryo_PopUpTextbox(txtRateOfRise)
            Dim stbRORRB As New StatusCryo_PopUpTextbox(txtRateOfRiseRB)

            Dim stbExtendedPurgeTime As New StatusCryo_PopUpTextbox(txtExtendedPurgeTime)
            Dim stbExtendedPurgeTimeRB As New StatusCryo_PopUpTextbox(txtExtendedPurgeTimeRB)

            Dim stbPumpRestartDelay As New StatusCryo_PopUpTextbox(txtPumpRestartDelay)
            Dim stbPumpRestartDelayRB As New StatusCryo_PopUpTextbox(txtPumpRestartDelayRB)

            Dim stbRepurgeCycles As New StatusCryo_PopUpTextbox(txtRepurgeCycles)
            Dim stbRepurgeCyclesRB As New StatusCryo_PopUpTextbox(txtRepurgeCyclesRB)

            Dim stbRoughToPressure As New StatusCryo_PopUpTextbox(txtRoughToPressure)
            Dim stbRoughToPressureRB As New StatusCryo_PopUpTextbox(txtRoughtToPressureRB)

            Dim stbStartUpTemp As New StatusCryo_PopUpTextbox(txtStartUpTemp)
            Dim stbStartUpTempRB As New StatusCryo_PopUpTextbox(txtStartUpTempRB)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbRegenHour)
            m_stoStatusObject.AddChild(stbLifeTimeHour)
            m_stoStatusObject.AddChild(stbCryoRegenStatus)

            m_stoStatusObject.AddChild(sbtCryoOn)
            m_stoStatusObject.AddChild(sbtCryoRegen)
            m_stoStatusObject.AddChild(sbtFastRegen)

            m_stoStatusObject.AddChild(stbROR)
            m_stoStatusObject.AddChild(stbRORRB)
            m_stoStatusObject.AddChild(stbExtendedPurgeTime)
            m_stoStatusObject.AddChild(stbExtendedPurgeTimeRB)
            m_stoStatusObject.AddChild(stbPumpRestartDelay)
            m_stoStatusObject.AddChild(stbPumpRestartDelayRB)
            m_stoStatusObject.AddChild(stbRepurgeCycles)
            m_stoStatusObject.AddChild(stbRepurgeCyclesRB)
            m_stoStatusObject.AddChild(stbRoughToPressure)
            m_stoStatusObject.AddChild(stbRoughToPressureRB)
            m_stoStatusObject.AddChild(stbStartUpTemp)
            m_stoStatusObject.AddChild(stbStartUpTempRB)

            txtRateOfRise.ParentStatusObj = m_stoStatusObject
            txtExtendedPurgeTime.ParentStatusObj = m_stoStatusObject
            txtPumpRestartDelay.ParentStatusObj = m_stoStatusObject
            txtRepurgeCycles.ParentStatusObj = m_stoStatusObject
            txtRoughToPressure.ParentStatusObj = m_stoStatusObject
            txtStartUpTemp.ParentStatusObj = m_stoStatusObject

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        txtRateOfRise.PermissionCode = AVPLib.ConstEnum.PERMISSION_001
        txtExtendedPurgeTime.PermissionCode = AVPLib.ConstEnum.PERMISSION_001
        txtPumpRestartDelay.PermissionCode = AVPLib.ConstEnum.PERMISSION_001
        txtRepurgeCycles.PermissionCode = AVPLib.ConstEnum.PERMISSION_001
        txtRoughToPressure.PermissionCode = AVPLib.ConstEnum.PERMISSION_001
        txtStartUpTemp.PermissionCode = AVPLib.ConstEnum.PERMISSION_001
        ' Add any initialization after the InitializeComponent() call.
        txtCryo_RegenHours.AccessibleName = "Cryo"

        Try
            FakeButtonRegen = New SL_CustomButton()
            FakeButtonRegen.Name = btnCryoRegen.Name

            FakeButtonFastRegen = New SL_CustomButton()
            FakeButtonFastRegen.Name = btnFastRegen.Name

            AddHandler FakeButtonRegen.StatusChange, AddressOf UpdateRegenStatus
            AddHandler FakeButtonFastRegen.StatusChange, AddressOf UpdateRegenStatus
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub



#Region "All Cryo button"
    Private Sub btnCryoOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCryoOn.Click
        AVPLib.Log.guiLogger.Info("Enter btnCryoOn_Click")
        Try
            If CheckPermission() = False Then
                Exit Sub
            End If
            If PanelHandle = CASSETTESPANEL_STR Then
                ContainerForm.CassettesPanel.crcTMCryo.btnOn_Click(sender, e)
                Exit Try
            ElseIf PanelHandle = ConstEnum.Equipments.LoadLockA.ToString() Then
                ContainerForm.CassettesPanel.crcLLACryo.btnOn_Click(sender, e)
                Exit Try
            End If
            ''routing to object handle
            Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(PanelHandle) ''PanelHandle=Chamber1, Chamber2...
            If objPanel Is Nothing Then
                Exit Try
            End If
            If objPanel.ChamberType = SystemModule.ModuleType.IBE Then
                Dim objIBEpanel As IBEPanel = CType(objPanel, IBEPanel)
                If btnCryoOn.Status = SL_CustomButton.DisplayStatus.Off Then
                    objIBEpanel.PopUpPanel.General_Button_Click(objIBEpanel.PopUpPanel.btnCryoOnOff, Nothing)
                Else
                    objIBEpanel.PopUpPanel.General_Button_Click(objIBEpanel.PopUpPanel.btnCryoOff, Nothing)
                End If
            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD Then
                Dim objPVDpanel As PVDPanel = CType(objPanel, PVDPanel)
                If Me.TypeOfCryoPanel = CryoPanelType.CryoPanel Then
                    If btnCryoOn.Status = SL_CustomButton.DisplayStatus.Off Then
                        objPVDpanel.PVDPopUpPanel.General_Button_Click(objPVDpanel.PVDPopUpPanel.btnCryoOn, Nothing)
                    Else
                        objPVDpanel.PVDPopUpPanel.General_Button_Click(objPVDpanel.PVDPopUpPanel.btnCryoOff, Nothing)
                    End If
                Else
                    If btnCryoOn.Status = SL_CustomButton.DisplayStatus.Off Then
                        objPVDpanel.PVDPopUpPanel.General_Button_Click(objPVDpanel.PVDPopUpPanel.btnWaterPumpOn, Nothing)
                    Else
                        objPVDpanel.PVDPopUpPanel.General_Button_Click(objPVDpanel.PVDPopUpPanel.btnWaterPumpOff, Nothing)
                    End If
                End If
            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                Dim objCoronapanel As CoronaPanel = CType(objPanel, CoronaPanel)
                If Me.TypeOfCryoPanel = CryoPanelType.CryoPanel Then
                    If btnCryoOn.Status = SL_CustomButton.DisplayStatus.Off Then
                        objCoronapanel.PopUpPanel.General_Button_Click(objCoronapanel.PopUpPanel.btnCryoOn, Nothing)
                    Else
                        objCoronapanel.PopUpPanel.General_Button_Click(objCoronapanel.PopUpPanel.btnCryoOff, Nothing)
                    End If
                Else
                    If btnCryoOn.Status = SL_CustomButton.DisplayStatus.Off Then
                        objCoronapanel.PopUpPanel.General_Button_Click(objCoronapanel.PopUpPanel.btnWaterPumpOn, Nothing)
                    Else
                        objCoronapanel.PopUpPanel.General_Button_Click(objCoronapanel.PopUpPanel.btnWaterPumpOff, Nothing)
                    End If
                End If
            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then
                Dim objPVD5Tpanel As PVD5TPanel = CType(objPanel, PVD5TPanel)
                If Me.TypeOfCryoPanel = CryoPanelType.CryoPanel Then
                    If btnCryoOn.Status = SL_CustomButton.DisplayStatus.Off Then
                        objPVD5Tpanel.PopUpPanel.General_Button_Click(objPVD5Tpanel.PopUpPanel.btnCryoOn, Nothing)
                    Else
                        objPVD5Tpanel.PopUpPanel.General_Button_Click(objPVD5Tpanel.PopUpPanel.btnCryoOff, Nothing)
                    End If
                Else
                    If btnCryoOn.Status = SL_CustomButton.DisplayStatus.Off Then
                        objPVD5Tpanel.PopUpPanel.General_Button_Click(objPVD5Tpanel.PopUpPanel.btnWaterPumpOn, Nothing)
                    Else
                        objPVD5Tpanel.PopUpPanel.General_Button_Click(objPVD5Tpanel.PopUpPanel.btnWaterPumpOff, Nothing)
                    End If
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnCryoOn_Click")
    End Sub

    Private Sub btnCryoRegen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCryoRegen.Click
        AVPLib.Log.guiLogger.Info("Enter btnCryoRegen_Click")
        Try
            If CheckPermission() = False OrElse Not btnCryoRegen.Clickable Then
                Exit Sub
            End If
            If PanelHandle = CASSETTESPANEL_STR Then
                ContainerForm.CassettesPanel.crcTMCryo.btnRegen_Click(sender, e)
                Exit Try
            ElseIf PanelHandle = ConstEnum.Equipments.LoadLockA.ToString() Then
                ContainerForm.CassettesPanel.crcLLACryo.btnRegen_Click(sender, e)
                Exit Try
            End If
            ''routing to original object handle
            Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(PanelHandle) ''PanelHandle=Chamber1, Chamber2...
            If objPanel Is Nothing Then
                Exit Try
            End If
            ''if this is IBEPanel
            If objPanel.ChamberType = SystemModule.ModuleType.IBE Then
                Dim objIBEpanel As IBEPanel = CType(objPanel, IBEPanel)
                If btnCryoRegen.Status = SL_CustomButton.DisplayStatus.Off Then
                    objIBEpanel.PopUpPanel.General_Button_Click(objIBEpanel.PopUpPanel.btnAutoRegen, Nothing)
                Else
                    objIBEpanel.PopUpPanel.General_Button_Click(objIBEpanel.PopUpPanel.btnAutoRegenOff, Nothing)
                End If
                ''if this is PVDPanel
            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD Then
                Dim objPVDpanel As PVDPanel = CType(objPanel, PVDPanel)
                If Me.TypeOfCryoPanel = CryoPanelType.CryoPanel Then
                    If btnCryoRegen.Status = SL_CustomButton.DisplayStatus.Off Then
                        objPVDpanel.PVDPopUpPanel.General_Button_Click(objPVDpanel.PVDPopUpPanel.btnAutoRegenOn, Nothing)
                    Else
                        objPVDpanel.PVDPopUpPanel.General_Button_Click(objPVDpanel.PVDPopUpPanel.btnAutoRegenOff, Nothing)
                    End If
                Else
                    If btnCryoRegen.Status = SL_CustomButton.DisplayStatus.Off Then
                        objPVDpanel.PVDPopUpPanel.General_Button_Click(objPVDpanel.PVDPopUpPanel.btnWPRegenOn, Nothing)
                    Else
                        objPVDpanel.PVDPopUpPanel.General_Button_Click(objPVDpanel.PVDPopUpPanel.btnWPRegenOff, Nothing)
                    End If
                End If
            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                Dim objCoronapanel As CoronaPanel = CType(objPanel, CoronaPanel)
                If Me.TypeOfCryoPanel = CryoPanelType.CryoPanel Then
                    If btnCryoRegen.Status = SL_CustomButton.DisplayStatus.Off Then
                        objCoronapanel.PopUpPanel.General_Button_Click(objCoronapanel.PopUpPanel.btnAutoRegenOn, Nothing)
                    Else
                        objCoronapanel.PopUpPanel.General_Button_Click(objCoronapanel.PopUpPanel.btnAutoRegenOff, Nothing)
                    End If
                Else
                    If btnCryoRegen.Status = SL_CustomButton.DisplayStatus.Off Then
                        objCoronapanel.PopUpPanel.General_Button_Click(objCoronapanel.PopUpPanel.btnWPRegenOn, Nothing)
                    Else
                        objCoronapanel.PopUpPanel.General_Button_Click(objCoronapanel.PopUpPanel.btnWPRegenOff, Nothing)
                    End If
                End If
            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then
                Dim objPVD5Tpanel As PVD5TPanel = CType(objPanel, PVD5TPanel)
                If Me.TypeOfCryoPanel = CryoPanelType.CryoPanel Then
                    If btnCryoRegen.Status = SL_CustomButton.DisplayStatus.Off Then
                        objPVD5Tpanel.PopUpPanel.General_Button_Click(objPVD5Tpanel.PopUpPanel.btnAutoRegenOn, Nothing)
                    Else
                        objPVD5Tpanel.PopUpPanel.General_Button_Click(objPVD5Tpanel.PopUpPanel.btnAutoRegenOff, Nothing)
                    End If
                Else
                    If btnCryoRegen.Status = SL_CustomButton.DisplayStatus.Off Then
                        objPVD5Tpanel.PopUpPanel.General_Button_Click(objPVD5Tpanel.PopUpPanel.btnWPRegenOn, Nothing)
                    Else
                        objPVD5Tpanel.PopUpPanel.General_Button_Click(objPVD5Tpanel.PopUpPanel.btnWPRegenOff, Nothing)
                    End If
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnCryoRegen_Click")
    End Sub

    Private Sub btnFastRegen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFastRegen.Click
        AVPLib.Log.guiLogger.Info("Enter btnFastRegen_Click")
        Try
            If CheckPermission() = False OrElse Not btnFastRegen.Clickable Then
                Exit Sub
            End If
            If PanelHandle = CASSETTESPANEL_STR Then
                ContainerForm.CassettesPanel.crcTMCryo.btnFastRegen_Click(sender, e)
                Exit Try
            ElseIf PanelHandle = ConstEnum.Equipments.LoadLockA.ToString() Then
                ContainerForm.CassettesPanel.crcLLACryo.btnFastRegen_Click(sender, e)
                Exit Try

            End If
            ''routing to original object handle
            Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(PanelHandle) ''PanelHandle=Chamber1, Chamber2...
            If objPanel Is Nothing Then
                Exit Try
            End If

            Dim strPMName As String = AVPLib.Utils.chamberID2ChamberName(PanelHandle)
            ''this button only in PVDPanel, check for sure
            Dim strMessageText As String = String.Empty

            If Utils.CheckHivacValveOpen_BeforeCryo(PanelHandle) Then
                Utils.LogUserEvent("Check Hivac Valve failed before Set Fast Regen", strPMName)
                Exit Sub
            End If

            If btnFastRegen.Status = SL_CustomButton.DisplayStatus.On Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("TransferAbortFastRegen"), strPMName)
                If (Utils.ShowAVPMessageBox(strMessageText, strPMName, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(btnFastRegen.Name, STR_OFF)
                    Utils.LogUserEvent("Click Button Abort Fast Regen", strPMName)
                End If

            ElseIf btnFastRegen.Status = SL_CustomButton.DisplayStatus.Off Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("TransferStartFastRegen"), strPMName)
                If (Utils.ShowAVPMessageBox(strMessageText, strPMName, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(btnFastRegen.Name, STR_ON)
                    Utils.LogUserEvent("Click Button Fast Regen", strPMName)

                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnFastRegen_Click")
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-07-21</date>
    ''' <summary>
    ''' Update regen buttons: Disable Fast Regen button when Regen button ON, and vice versa.
    ''' </summary>
    Private Sub UpdateRegenButtons()
        Try
            If FastRegenStatus = DisplayStatus.On Then
                If btnFastRegen.Visible Then
                    btnCryoRegen.Status = DisplayStatus.Off
                    btnFastRegen.Status = DisplayStatus.On
                Else
                    btnCryoRegen.Status = DisplayStatus.On
                    btnFastRegen.Status = DisplayStatus.Off
                End If
            Else
                btnCryoRegen.Status = RegenStatus
                btnFastRegen.Status = FastRegenStatus
            End If
            btnFastRegen.Clickable = (btnCryoRegen.Status <> DisplayStatus.On)
            btnCryoRegen.Clickable = (btnFastRegen.Status <> DisplayStatus.On)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Events"
    Private Sub btnCryoOn_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCryoOn.StatusChange
        RaiseEvent ButtonPump_StatusChanged(sender, e)
    End Sub

    Private Sub btnCryoRegen_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCryoRegen.StatusChange
        RaiseEvent ButtonRegen_StatusChanged(sender, e)
    End Sub

    Private Sub btnFastRegen_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFastRegen.StatusChange
        RaiseEvent ButtonFastRegen_StatusChanged(sender, e)
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-07-21</date>
    ''' <summary>
    ''' Update regen status.
    ''' </summary>
    Private Sub UpdateRegenStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            RegenStatus = FakeButtonRegen.Status
            FastRegenStatus = FakeButtonFastRegen.Status
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

End Class
