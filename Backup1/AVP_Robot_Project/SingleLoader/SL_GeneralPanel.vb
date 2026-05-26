Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class SL_PopUpPanel
    Private m_strChamberHandle As String = String.Empty
    Private m_IBE_Type As AllChamberType = AllChamberType.AVP_IBE
    Private m_NoWaterPumpInstalled As Boolean = False
    Private m_NoCryoInstalled As Boolean = False
    Private m_NoCryoAndWPInstalled As Boolean = False
    Private m_iPosXDecrease As Integer = 0

#Region "Properties"
    'Config IBE Type to show or hide button
    Public Property IBE_Type() As AllChamberType
        Get
            Return m_IBE_Type
        End Get
        Set(ByVal value As AllChamberType)
            m_IBE_Type = value
            If m_IBE_Type = AllChamberType.AVP_IBE Then
                m_iPosXDecrease = 20
                btnIGDegas.Visible = True
                '#05/13/2011 
                '#-	AVP/IBE.  Disable ROR/PDC button since all these function is under DIAG
                '#Begin fix
                btnPumpPurge.Visible = False
                btnRateOfRise.Visible = False
                btnPumpdownCurve.Visible = False
                m_iPosXDecrease = 0
                '#End fix
                btnAutoVentGeneral.Location = New Point(11, 112 - m_iPosXDecrease)
                btnAutoPumpDownGeneral.Location = New Point(11, 63 - m_iPosXDecrease)
                btnIGDegas.Location = New Point(11, 161 - m_iPosXDecrease)
                btnRateOfRise.Location = New Point(11, 210 - m_iPosXDecrease)
                btnPumpdownCurve.Location = New Point(11, 259 - m_iPosXDecrease)
            Else
                btnAutoVentGeneral.Location = New Point(11, 112)
                btnAutoPumpDownGeneral.Location = New Point(11, 63)
                btnRateOfRise.Location = New Point(11, 161)
                btnIGDegas.Visible = False
                btnPumpPurge.Visible = False
                btnPumpdownCurve.Visible = False

                Label10.Visible = False
                txtRegenStatus.Visible = False
                btnCryoOnOff.Location = New Point(btnCryoOnOff.Location.X, btnCryoOnOff.Location.Y - 23)
                btnCryoOff.Location = New Point(btnCryoOff.Location.X, btnCryoOff.Location.Y - 23)
                btnAutoRegen.Location = New Point(btnAutoRegen.Location.X, btnAutoRegen.Location.Y - 23)
                btnAutoRegenOff.Location = New Point(btnAutoRegenOff.Location.X, btnAutoRegenOff.Location.Y - 23)
                btnCryoPurge.Location = New Point(btnCryoPurge.Location.X, btnCryoPurge.Location.Y - 23)
                btnCryoPurgeOff.Location = New Point(btnCryoPurgeOff.Location.X, btnCryoPurgeOff.Location.Y - 23)
                btnRoughValveOpen.Location = New Point(btnRoughValveOpen.Location.X, btnRoughValveOpen.Location.Y - 23)
                btnRoughValveClose.Location = New Point(btnRoughValveClose.Location.X, btnRoughValveClose.Location.Y - 23)
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-02-21</date>
    ''' </author>
    ''' <summary>
    ''' Get/set chamber have install Water Pump or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NoWaterPumpInstalled() As Boolean
        Get
            Return m_NoWaterPumpInstalled
        End Get
        Set(ByVal value As Boolean)
            m_NoWaterPumpInstalled = value
            If value Then
                btnOnline.Location = New Point(148, 9)
                btnOffline.Location = New Point(317, 9)
                Me.Size = New Size(604, 411)
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-02-21</date>
    ''' </author>
    ''' <summary>
    ''' Get/set chamber have install Cryo or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NoCryoInstalled() As Boolean
        Get
            Return m_NoCryoInstalled
        End Get
        Set(ByVal value As Boolean)
            m_NoCryoInstalled = value
            If value Then
                btnOnline.Location = New Point(126, 9)
                btnOffline.Location = New Point(295, 9)
                Me.Size = New Size(549, 411)
                grbCryo.Visible = False
            End If
        End Set
    End Property

    Public Property NoCryoAndWPInstalled() As Boolean
        Get
            Return m_NoCryoAndWPInstalled
        End Get
        Set(ByVal value As Boolean)
            m_NoCryoAndWPInstalled = value
            If value Then
                btnOnline.Location = New Point(12, 6)
                btnOffline.Location = New Point(190, 6)
                Me.Size = New Size(349, 411)
                Me.grbChamber.Size = New Size(323, 262)
                btnAutoPumpDownGeneral.Left += 55
                btnAutoVentGeneral.Left = btnAutoPumpDownGeneral.Left
                btnRateOfRise.Left = btnAutoPumpDownGeneral.Left
                btnPumpPurge.Left = btnAutoPumpDownGeneral.Left
                btnIGDegas.Left = btnAutoPumpDownGeneral.Left
                btnPumpdownCurve.Left = btnAutoPumpDownGeneral.Left
                grbCryo.Visible = False
                grbWaterPump.Visible = False
            End If
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
#End Region

#Region "Private methods"

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
         btnRateOfRise.Click, btnAutoVentGeneral.Click, btnAutoPumpDownGeneral.Click, btnIGDegas.Click, btnPumpPurge.Click, btnPumpdownCurve.Click
        SL_Support.ButtonClick(sender, Me.Name, m_stoStatusObject)
    End Sub

    Public Sub General_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
         btnWaterPumpOnOff.Click, btnCryoPurge.Click, btnAutoRegen.Click, btnCryoRegenValve.Click, _
        btnAutoPowerDown.Click, btnCryoOnOff.Click, btnCryoOff.Click, btnWaterPumpOff.Click, btnRoughValveClose.Click, _
        btnRoughValveOpen.Click, btnAutoRegenOff.Click, btnCryoPurgeOff.Click
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strValue As String = String.Empty
            Dim buttonName As String = button.Name

            If buttonName = btnCryoOff.Name Or buttonName = btnAutoRegenOff.Name Or buttonName = btnCryoPurgeOff.Name Or _
                buttonName = btnRoughValveClose.Name Or buttonName = btnWaterPumpOff.Name Then
                strValue = STR_OFF
            Else
                strValue = STR_ON
            End If

            Dim Source As String = STR_IBE & "." & Me.Name & "." & button.Name & "." & strValue
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)

            Dim chamberName As String = String.Empty
            chamberName = AVPLib.Utils.chamberID2ChamberName(m_stoStatusObject.Name)
            If String.IsNullOrEmpty(chamberName) OrElse Not m_stoStatusObject.Name.StartsWith(AVPLib.ConstEnum.Chamber) Then
                chamberName = AVPLib.Utils.chamberID2ChamberName(m_stoStatusObject.Parent.Name)
            End If

            If Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                Utils.LogUserEvent(sender, chamberName)

                If buttonName = btnAutoRegen.Name Then
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

    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbPumpPurge As New SL_StatusButton(btnPumpPurge)
            Dim stbIGDegas As New SL_StatusButton(btnIGDegas)
            Dim stbWaterPump As New SL_StatusButton(btnWaterPumpOnOff)
            Dim stbROR As New SL_StatusButton(btnRateOfRise)
            Dim stbCryoRegen As New SL_StatusButton(btnCryoRegenValve)
            Dim stbCryoPurge As New SL_StatusButton(btnCryoPurge)
            Dim stbCryoOnOff As New SL_StatusButton(btnCryoOnOff)
            Dim stbAutoVent As New SL_StatusButton(btnAutoVentGeneral)
            Dim stbAutoRegen As New SL_StatusButton(btnAutoRegen)
            Dim stbAutoPumpDown As New SL_StatusButton(btnAutoPumpDownGeneral)
            Dim stbAutoPowerDown As New SL_StatusButton(btnAutoPowerDown)
            Dim stCryo As New SL_StatusTextBox(txtCryo)
            Dim stWaterPump As New SL_StatusTextBox(txtWaterPump)
            Dim stbRoughValve As New SL_StatusButton(btnRoughValveOpen)
            Dim sbtOnlineStatus As New SL_StatusButton(btnOnline)
            Dim sbtOfflineStatus As New SL_StatusButton(btnOffline)
            Dim sbtMaintenanceStatus As New SL_StatusButton(btnMaintenance)
            Dim stbRegenStatus As New SL_StatusTextBox(txtRegenStatus)
            Dim sbnPDC As New SL_StatusButton(btnPumpdownCurve)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbPumpPurge)
            m_stoStatusObject.AddChild(stbIGDegas)
            m_stoStatusObject.AddChild(stbWaterPump)
            m_stoStatusObject.AddChild(stbROR)
            m_stoStatusObject.AddChild(stbCryoRegen)
            m_stoStatusObject.AddChild(stbCryoPurge)
            m_stoStatusObject.AddChild(stbCryoOnOff)
            m_stoStatusObject.AddChild(stbAutoVent)
            m_stoStatusObject.AddChild(stbAutoRegen)
            m_stoStatusObject.AddChild(stbAutoPumpDown)
            m_stoStatusObject.AddChild(stbAutoPowerDown)
            m_stoStatusObject.AddChild(stCryo)
            m_stoStatusObject.AddChild(stWaterPump)
            m_stoStatusObject.AddChild(stbRoughValve)
            m_stoStatusObject.AddChild(sbtOnlineStatus)
            m_stoStatusObject.AddChild(sbtOfflineStatus)
            m_stoStatusObject.AddChild(sbtMaintenanceStatus)
            m_stoStatusObject.AddChild(stbRegenStatus)
            m_stoStatusObject.AddChild(sbnPDC)

            btnOnline.ParentStatusObj = m_stoStatusObject
            btnOffline.ParentStatusObj = m_stoStatusObject

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overrides Sub DoClose()
        Try
            Me.Close()
            Dim ibepanel As IBEPanel = ContainerForm.ChamberPanel(Me.ChamberHandle)
            If ibepanel IsNot Nothing Then
                ibepanel.Refresh()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnCryoOnOff_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCryoOnOff.StatusChange
        If btnCryoOnOff.Status = SL_CustomButton.DisplayStatus.Off Then
            btnCryoOff.Status = SL_CustomButton.DisplayStatus.On
        ElseIf btnCryoOnOff.Status = SL_CustomButton.DisplayStatus.On Then
            btnCryoOff.Status = SL_CustomButton.DisplayStatus.Off
        ElseIf btnCryoOnOff.Status = SL_CustomButton.DisplayStatus.Unknow Then
            btnCryoOff.Status = SL_CustomButton.DisplayStatus.Unknow
        End If
    End Sub

    Private Sub btnWaterPumpOnOff_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaterPumpOnOff.StatusChange
        If btnWaterPumpOnOff.Status = SL_CustomButton.DisplayStatus.Off Then
            btnWaterPumpOff.Status = SL_CustomButton.DisplayStatus.On
        ElseIf btnWaterPumpOnOff.Status = SL_CustomButton.DisplayStatus.On Then
            btnWaterPumpOff.Status = SL_CustomButton.DisplayStatus.Off
        ElseIf btnWaterPumpOnOff.Status = SL_CustomButton.DisplayStatus.Unknow Then
            btnWaterPumpOff.Status = SL_CustomButton.DisplayStatus.Unknow
        End If
    End Sub

    Private Sub btnAutoRegen_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoRegen.StatusChange
        If btnAutoRegen.Status = SL_CustomButton.DisplayStatus.Off Then
            btnAutoRegenOff.Status = SL_CustomButton.DisplayStatus.On
        ElseIf btnAutoRegen.Status = SL_CustomButton.DisplayStatus.On Then
            btnAutoRegenOff.Status = SL_CustomButton.DisplayStatus.Off
        ElseIf btnAutoRegen.Status = SL_CustomButton.DisplayStatus.Unknow Then
            btnAutoRegenOff.Status = SL_CustomButton.DisplayStatus.Unknow
        End If
    End Sub

    Private Sub btnCryoPurge_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCryoPurge.StatusChange
        If btnCryoPurge.Status = SL_CustomButton.DisplayStatus.Off Then
            btnCryoPurgeOff.Status = SL_CustomButton.DisplayStatus.On
        ElseIf btnCryoPurge.Status = SL_CustomButton.DisplayStatus.On Then
            btnCryoPurgeOff.Status = SL_CustomButton.DisplayStatus.Off
        ElseIf btnCryoPurge.Status = SL_CustomButton.DisplayStatus.Unknow Then
            btnCryoPurgeOff.Status = SL_CustomButton.DisplayStatus.Unknow
        End If
    End Sub

    Private Sub btnRoughValveOpen_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoughValveOpen.StatusChange
        If btnRoughValveOpen.Status = SL_CustomButton.DisplayStatus.Off Then
            btnRoughValveClose.Status = SL_CustomButton.DisplayStatus.On
        ElseIf btnRoughValveOpen.Status = SL_CustomButton.DisplayStatus.On Then
            btnRoughValveClose.Status = SL_CustomButton.DisplayStatus.Off
        ElseIf btnRoughValveOpen.Status = SL_CustomButton.DisplayStatus.Unknow Then
            btnRoughValveClose.Status = SL_CustomButton.DisplayStatus.Unknow
        End If
    End Sub

    Private Sub btnOnline_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnline.StatusChange
        Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(ChamberHandle)
        If btnOnline.Status = SL_CustomButton.DisplayStatus.On Then
            btnOffline.Status = SL_CustomButton.DisplayStatus.Off
            btnMaintenance.Status = SL_CustomButton.DisplayStatus.Off
            btnMaintenance.Visible = False
            If objIBEPanel IsNot Nothing Then
                objIBEPanel.lblChamberType.Text = objIBEPanel.lblChamberType.Tag & ConstantAndEnum.ONLINE_PM
                objIBEPanel.SLContainerBox.btnGeneral.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(SL_CustomButton.DisplayStatus.On)
                objIBEPanel.Refresh()
            End If
        ElseIf btnOnline.Status = SL_CustomButton.DisplayStatus.Off Then
            If objIBEPanel IsNot Nothing Then
                Dim objIBE As AVPLib.DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objIBEPanel.Name)
                If objIBE.ControlStatus = AVPLib.DataManagerment.Equipment.ControlStatuses.MAINTENANCE Then
                    objIBEPanel.SetMaintenanceMode(objIBE.EditableIn_MaintenanceMode, True)
                    btnMaintenance.Visible = True
                    btnOffline.Visible = False
                    btnOnline.Visible = False
                    objIBEPanel.lblChamberType.Text = objIBEPanel.lblChamberType.Tag & " (" & ConstantAndEnum.STRING_MAINTENANCE & ")"

                ElseIf objIBE.ControlStatus = AVPLib.DataManagerment.Equipment.ControlStatuses.OFFLINE Then
                    btnMaintenance.Visible = False
                    btnOffline.Visible = True
                    btnOnline.Visible = True
                    btnOffline.Status = SL_CustomButton.DisplayStatus.On
                    objIBEPanel.lblChamberType.Text = objIBEPanel.lblChamberType.Tag & ConstantAndEnum.OFFLINE_PM
                    objIBEPanel.SetMaintenanceMode(True, False)

                End If

                objIBEPanel.SLContainerBox.btnGeneral.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(SL_CustomButton.DisplayStatus.Off)
                objIBEPanel.Refresh()
            End If
        End If

    End Sub
#End Region

#Region "Public methods"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        btnOnline.Clickable = True
        btnOnline.ValueToBeSend = ""

        btnOffline.Clickable = True
        btnOffline.ValueToBeSend = ""

    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-02-22</date>
    ''' </author>
    ''' <summary>
    ''' Disable/Enable control when online/offline
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetOnlineOfflinePopUp(ByVal blnIsOnline As Boolean)
        grbChamber.Enabled = Not blnIsOnline
        grbWaterPump.Enabled = Not blnIsOnline
        grbCryo.Enabled = Not blnIsOnline
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-22-23</date>
    ''' </author>
    ''' <summary>
    ''' Set default status to show on GUI when PM disconnect.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaultStatus()
        'All textbox
        txtCryo.Text = String.Empty
        txtWaterPump.Text = String.Empty

        btnOnline.Status = SL_CustomButton.DisplayStatus.Off
        btnOffline.Status = SL_CustomButton.DisplayStatus.On
        'group chamber
        btnAutoVentGeneral.Status = SL_CustomButton.DisplayStatus.Off
        btnAutoPumpDownGeneral.Status = SL_CustomButton.DisplayStatus.Off
        btnRateOfRise.Status = SL_CustomButton.DisplayStatus.Off
        btnPumpPurge.Status = SL_CustomButton.DisplayStatus.Off
        btnIGDegas.Status = SL_CustomButton.DisplayStatus.Off
        btnPumpdownCurve.Status = SL_CustomButton.DisplayStatus.Off
        'group cryo
        btnCryoOnOff.Status = SL_CustomButton.DisplayStatus.Off
        btnCryoOff.Status = SL_CustomButton.DisplayStatus.On
        btnAutoRegen.Status = SL_CustomButton.DisplayStatus.Off
        btnAutoRegenOff.Status = SL_CustomButton.DisplayStatus.On
        btnCryoPurge.Status = SL_CustomButton.DisplayStatus.Off
        btnCryoPurgeOff.Status = SL_CustomButton.DisplayStatus.On
        btnRoughValveOpen.Status = SL_CustomButton.DisplayStatus.Off
        btnRoughValveClose.Status = SL_CustomButton.DisplayStatus.On
        'group Water Pump
        btnWaterPumpOnOff.Status = SL_CustomButton.DisplayStatus.Off
        btnWaterPumpOff.Status = SL_CustomButton.DisplayStatus.On
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-09-08</date>
    ''' </author>
    ''' <summary>
    '''  Enable Disable Chamber Button. Using for fix bug: Make sure that only sequence is running at the time
    ''' </summary>
    Public Sub EnableDisableChamberButton(ByVal blnPumpdownButtonEnabled As Boolean, ByVal blnVentButtonEnabled As Boolean, _
            ByVal blnIGDegasButtonEnabled As Boolean, ByVal blnRateOfRaiseButtonEnabled As Boolean, _
            ByVal blnPumpdownCurveButtonEnable As Boolean)
        btnAutoPumpDownGeneral.Enabled = blnPumpdownButtonEnabled
        btnAutoVentGeneral.Enabled = blnVentButtonEnabled
        btnIGDegas.Enabled = blnIGDegasButtonEnabled
        btnRateOfRise.Enabled = blnRateOfRaiseButtonEnabled
        btnPumpdownCurve.Enabled = blnPumpdownCurveButtonEnable
    End Sub

    Private Sub btnOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnline.Click, btnOffline.Click
        AVPLib.Log.guiLogger.Info("Enter btnOnline.Click")
        Try
            Utils.LogUserEvent(sender)
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strMessageText As String = String.Empty
            If button.Name = btnOnline.Name Then
                m_stoStatusObject.RequestStatus(button.Name, button.ValueToBeSend)
            ElseIf button.Name = btnOffline.Name Then
                m_stoStatusObject.RequestStatus(button.Name, button.ValueToBeSend)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOnline.Click")
    End Sub
#End Region

#Region "Event"
    '#04/15/2011 
    '#All PVD/IBE/TM Pop up menu must be movable to other location while active.
    '#Begin fix:
    'Private Sub lblTitle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitle.MouseDown
    '    mouseOffset = New Point(e.Location.X, e.Location.Y)
    '    isDragDrop = True
    'End Sub

    'Private Sub lblTitle_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitle.MouseMove
    '    If isDragDrop Then
    '        Dim point As Point = Me.Location
    '        Me.Location = New Point(point.X + (e.Location.X - mouseOffset.X), point.Y + (e.Location.Y - mouseOffset.Y))
    '        Me.Opacity = 0.5
    '    End If
    'End Sub

    'Private Sub lblTitle_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitle.MouseUp
    '    If e.Button = Windows.Forms.MouseButtons.Left AndAlso isDragDrop Then
    '        isDragDrop = False
    '        Me.Opacity = 1
    '    End If
    'End Sub
    '#End fix.
#End Region

End Class
