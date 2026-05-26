Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class Chamber1Panel

#Region "Class Constants & Variables"
    Private TimeWait As Integer = 60
    Private TimeWaiting As Integer = 0
    Private ValveRingClicked As Boolean = False
    Private HivacValveStatus As String = BinaryStatusControl.DisplayStatus.Off.ToString()
    Friend Shared m_Current_Status_Fixture As String = AVPLib.IBEConfigurationValues.DEVICE_CONTINUOUS
#End Region
    ''' <author>
    '''    	<name>Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Check Current_Status_Fixture
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Current_Status_Fixture() As String
        Get
            Return m_Current_Status_Fixture
        End Get
        Set(ByVal value As String)
            m_Current_Status_Fixture = value
        End Set
    End Property
#Region "Public Methods"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub CheckPermission(ByVal PERMISSION_Code As String)
        If AVPLib.ContainerData.Permission(PERMISSION_Code) Then
            ActiveForm()
        Else
            InactiveForm()
        End If
    End Sub

    Dim m_Loaded As Boolean = False
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Property of Loaded
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Loaded() As Boolean
        Get
            Return m_Loaded
        End Get
        Set(ByVal value As Boolean)
            m_Loaded = value
        End Set
    End Property

    Dim m_MachineHandle As Boolean = False
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Property of Machine Handle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MachineHandle() As Boolean
        Get
            Return m_MachineHandle
        End Get
        Set(ByVal value As Boolean)
            m_MachineHandle = value
        End Set
    End Property

    Dim m_MachineHandleClick As Boolean = False
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Property of Machine Handle Click
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MachineHandleClick() As Boolean
        Get
            Return m_MachineHandleClick
        End Get
        Set(ByVal value As Boolean)
            m_MachineHandleClick = value
        End Set
    End Property
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbcConnectionStatus As New StatusIGCGButton(btnReConnect)

            Dim sbcPlasmaControl As New StatusBinaryStatusControl(PlasmaControl)
            Dim sbcTemperature As New StatusTextBox(txtTemperture)
            Dim sbcWaferInFixture As New StatusBinaryStatusControl(FixtureControl)
            Dim sbcValveControlArgon As New StatusBinaryStatusControl(ValveControlArgon)
            Dim sbcValveControlFlowCoolHe As New StatusBinaryStatusControl(ValveControlFlowCoolHe)
            Dim sbcValveControlForeline As New StatusBinaryStatusControl(ValveControlForeline)
            Dim sbcValveControlPBN As New StatusBinaryStatusControl(ValveControlPBN)
            Dim sbcValveControlRough As New StatusBinaryStatusControl(ValveControlRough)
            Dim sbcValveControlVent As New StatusBinaryStatusControl(ValveControlVent)

            Dim sbcValveRoughLine As New StatusBinaryStatusControl(ValveRoughLine)
            Dim sbcValveGasPump As New StatusBinaryStatusControl(ticGasPump)

            Dim sbcValveCryoPump As New StatusBinaryStatusControl(ValveControlCryoPump)
            Dim sbcValveSupplyArgon As New StatusBinaryStatusControl(ValveSupplyArgon)
            Dim sbcValveSupplyFlowCoolHe As New StatusBinaryStatusControl(ValveSupplyFlowCoolHe)
            Dim sbcValveSupplyPBN As New StatusBinaryStatusControl(ValveSupplyPBN)
            Dim sbcValveWaterPump As New StatusBinaryStatusControl(ValveWaterPump)

            Dim sTooltipFixutreOnClamp As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuFixtureOnClamp)
            Dim sTooltipFixtureHomeAllAxis As New StatusToolStripMenuItemChamber3(Me.mnuFixtureHomeAllAxis)
            Dim sTooltipFixtureHomeRotationAxis As New StatusToolStripMenuItemChamber3(Me.mnuFixtureHomeRotationAxis)
            Dim sTooltipFixutreHomeTiltAxis As New StatusToolStripMenuItemChamber3(Me.mnuFixtureHomeTiltAxis)
            Dim sTooltipFixutreStartRotationAxis As New StatusToolStripMenuItemChamber3(Me.mnuFixtureStartRotationAxis)
            Dim sTooltipFixutreStopAllAxis As New StatusToolStripMenuItemChamber3(Me.mnuFixtureStopAllAxis)
            Dim sTooltipFixtureOpenWaterValve As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuFixtureOpenWaterValve)
            Dim sTooltipFixtureOpenFlowCool As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuFixtureOpenFlowCool)

            Dim sTooltipMachineOnline As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineOnline)
            Dim sTooltipMachinePumpDown As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachinePumpDown)
            Dim sTooltipMachineVent As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineVent)
            Dim sTooltipMachineCryo As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineCryoOn)
            Dim sTooltipMachineCryoPump As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineCryoPumpRegen)
            Dim sTooltipMachineCryoAuto As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineCryoAutoRegen)

            Dim svoValveRing As New StatusBinaryStatusControl(ValveRingControl)
            Dim svoScreenMachine As New StatusThirdStatusControl(ScreenMachine)
            Dim sbsValveMesa As New StatusRoundRectangleControl(ValveControlMesa)

            'Status object for the Button Tootip Machine
            Dim stImgBtnMachineOnline As New StatusImageButton(btnTooltipMachine)
            stImgBtnMachineOnline.ImageToolOnline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(1)
            stImgBtnMachineOnline.ImageToolOffline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(0)
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(Me.rfpwRFPowerSupply.Status)
            m_stoStatusObject.AddChild(Me.spsSuppressorPowerSupply.Status)
            m_stoStatusObject.AddChild(Me.spsBeamPowerSupply.Status)
            m_stoStatusObject.AddChild(Me.dpsBodyPowerSupply.Status)
            m_stoStatusObject.AddChild(Me.ChamberInterlocks.Status)
            m_stoStatusObject.AddChild(Me.cgcFLCG.Status)
            m_stoStatusObject.AddChild(Me.cgcRLCG.Status)
            m_stoStatusObject.AddChild(Me.BaCenterControl.Status)
            m_stoStatusObject.AddChild(Me.cgcMG.Status)
            m_stoStatusObject.AddChild(Me.ftcFixtureControlContinuous.Status)
            m_stoStatusObject.AddChild(Me.ftcFixtureControlStatic.Status)
            m_stoStatusObject.AddChild(Me.ftcFixtureControlSweep.Status)
            m_stoStatusObject.AddChild(Me.gccGasController.Status)
            m_stoStatusObject.AddChild(Me.prmProcessMonitor.Status)
            m_stoStatusObject.AddChild(Me.prcRunProcessRecipe.Status)
            m_stoStatusObject.AddChild(svoValveRing)
            m_stoStatusObject.AddChild(sbsValveMesa)
            m_stoStatusObject.AddChild(sbcValveControlArgon)
            m_stoStatusObject.AddChild(sbcValveControlFlowCoolHe)
            m_stoStatusObject.AddChild(sbcValveControlForeline)
            m_stoStatusObject.AddChild(sbcValveControlPBN)
            m_stoStatusObject.AddChild(sbcValveControlRough)
            m_stoStatusObject.AddChild(sbcValveControlVent)
            m_stoStatusObject.AddChild(svoScreenMachine)
            m_stoStatusObject.AddChild(sbcValveRoughLine)
            m_stoStatusObject.AddChild(sbcValveGasPump)

            m_stoStatusObject.AddChild(sbcValveCryoPump)
            m_stoStatusObject.AddChild(sbcValveSupplyArgon)
            m_stoStatusObject.AddChild(sbcValveSupplyFlowCoolHe)
            m_stoStatusObject.AddChild(sbcValveSupplyPBN)
            m_stoStatusObject.AddChild(sbcValveWaterPump)

            m_stoStatusObject.AddChild(sTooltipFixutreOnClamp)
            m_stoStatusObject.AddChild(sTooltipFixtureHomeAllAxis)
            m_stoStatusObject.AddChild(sTooltipFixtureHomeRotationAxis)
            m_stoStatusObject.AddChild(sTooltipFixutreHomeTiltAxis)
            m_stoStatusObject.AddChild(sTooltipFixutreStartRotationAxis)
            m_stoStatusObject.AddChild(sTooltipFixutreStopAllAxis)
            m_stoStatusObject.AddChild(sTooltipFixtureOpenFlowCool)
            m_stoStatusObject.AddChild(sTooltipFixtureOpenWaterValve)

            m_stoStatusObject.AddChild(sTooltipMachineOnline)
            m_stoStatusObject.AddChild(sTooltipMachinePumpDown)
            m_stoStatusObject.AddChild(sTooltipMachineVent)
            m_stoStatusObject.AddChild(sTooltipMachineCryo)
            m_stoStatusObject.AddChild(sTooltipMachineCryoAuto)
            m_stoStatusObject.AddChild(sTooltipMachineCryoPump)

            m_stoStatusObject.AddChild(sbcWaferInFixture)
            m_stoStatusObject.AddChild(sbcPlasmaControl)
            ' add status Object of tooltipMachine
            m_stoStatusObject.AddChild(stImgBtnMachineOnline)
            m_stoStatusObject.AddChild(sbcTemperature)
            m_stoStatusObject.AddChild(Me.usrStatusPanel.Status)
            m_stoStatusObject.AddChild(PowerStatusPanel.Status)
            m_stoStatusObject.AddChild(sbcConnectionStatus)


        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private method"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.usrStatusPanel.Enabled = True
            Me.PowerStatusPanel.Enabled = True
            Me.spsBeamPowerSupply.Enabled = True
            Me.dpsBodyPowerSupply.Enabled = True
            Me.rfpwRFPowerSupply.Enabled = True
            Me.spsSuppressorPowerSupply.Enabled = True
            Me.ChamberInterlocks.Enabled = True
            Me.prcRunProcessRecipe.Enabled = True
            Me.prmProcessMonitor.Enabled = True
            Me.gccGasController.Enabled = True
            Me.cgcFLCG.Enabled = True
            Me.cgcRLCG.Enabled = True
            Me.cgcMG.Enabled = True
            Me.BaCenterControl.Enabled = True
            Me.ftcFixtureControlContinuous.Enabled = True
            Me.btnTooltipFixture.Enabled = True
            Me.btnTooltipMachine.Enabled = True

            If Me.mnuMachineOnline.Text = "Online" Then
                Online_OfflineValveStatus(True, False)
            Else
                Online_OfflineValveStatus(False, False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-24</date>
    ''' </author>
    ''' <summary>
    ''' OfflineValveStatus
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub Online_OfflineValveStatus(ByVal blnEnableStatus As Boolean, ByVal blnIsMenuOnlineClick As Boolean)
        Me.ValveControlForeline.Enabled = blnEnableStatus
        Me.ValveControlRough.Enabled = blnEnableStatus
        Me.ValveControlVent.Enabled = blnEnableStatus
        Me.ValveControlFlowCoolHe.Enabled = blnEnableStatus
        Me.ValveControlArgon.Enabled = blnEnableStatus
        Me.ValveControlPBN.Enabled = blnEnableStatus
        Me.ValveRingControl.Enabled = blnEnableStatus
        Me.ValveControlCryoPump.Enabled = blnEnableStatus
        Me.ValveSupplyArgon.Enabled = blnEnableStatus
        Me.ValveSupplyFlowCoolHe.Enabled = blnEnableStatus
        Me.ValveSupplyPBN.Enabled = blnEnableStatus
        Me.ValveWaterPump.Enabled = blnEnableStatus
        Me.ScreenMachine.Enabled = blnEnableStatus
        If blnIsMenuOnlineClick Then
            If blnEnableStatus Then  'Offline
                '  Me.LabTitle.Text = " (Offline)"
                Me.lblChamberType.Text = Me.lblChamberType.Tag & OFFLINE_PM
            Else
                ' Me.LabTitle.Text = " (Online)"
                Me.lblChamberType.Text = Me.lblChamberType.Tag & ONLINE_PM
            End If
        End If
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            Me.usrStatusPanel.Enabled = False
            Me.spsBeamPowerSupply.Enabled = False
            Me.dpsBodyPowerSupply.Enabled = False
            Me.PowerStatusPanel.Enabled = False
            Me.rfpwRFPowerSupply.Enabled = False
            Me.spsSuppressorPowerSupply.Enabled = False
            Me.ChamberInterlocks.Enabled = False
            Me.prcRunProcessRecipe.Enabled = False
            Me.prmProcessMonitor.Enabled = False
            Me.gccGasController.Enabled = False
            Me.cgcFLCG.Enabled = False
            Me.cgcRLCG.Enabled = False
            Me.cgcMG.Enabled = False
            Me.BaCenterControl.Enabled = False
            Me.ftcFixtureControlContinuous.Enabled = False
            Me.btnTooltipFixture.Enabled = False
            Me.btnTooltipMachine.Enabled = False
            Me.ValveControlForeline.Enabled = False
            Me.ValveControlRough.Enabled = False
            Me.ValveControlVent.Enabled = False
            Me.ValveControlFlowCoolHe.Enabled = False
            Me.ValveControlArgon.Enabled = False
            Me.ValveControlPBN.Enabled = False
            Me.ValveRingControl.Enabled = False
            Me.ScreenMachine.Enabled = False
            Me.ValveControlCryoPump.Enabled = False
            Me.ValveSupplyArgon.Enabled = False
            Me.ValveSupplyFlowCoolHe.Enabled = False
            Me.ValveSupplyPBN.Enabled = False
            Me.ValveWaterPump.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on valve
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ValveControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveControlForeline.Click, _
                                                                                                       ValveControlVent.Click, _
                                                                                                       ValveControlRough.Click, _
                                                                                                       ValveControlPBN.Click, _
                                                                                                       ValveControlFlowCoolHe.Click, _
                                                                                                       ValveControlArgon.Click, _
                                                                                                       ValveSupplyFlowCoolHe.Click, _
                                                                                                       ValveSupplyArgon.Click, _
                                                                                                       ValveControlCryoPump.Click, _
                                                                                                       ValveSupplyPBN.Click, _
                                                                                                       ValveWaterPump.Click, _
                                                                                                       ticGasPump.Click
        AVPLib.Log.guiLogger.Info("Enter ValveControl_Click")
        Try
            Dim strMessageText As String
            Dim strValue As String
            Dim ValveControl As AVP_Robot_Project.ValveControl = CType(sender, AVP_Robot_Project.ValveControl)

            Dim Message As String = ValveControl.Name
            Dim strLogMessage As String = String.Empty

            If (ValveControl.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(Message + STRING_CLOSE)
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
                strLogMessage = "Close"
            Else
                strMessageText = AVPLib.ContainerData.GetMessageText(Message + STRING_OPEN)
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
                strLogMessage = "Open"
            End If
            If (Utils.ShowAVPMessageBox(strMessageText, "Valve", MessageBoxIcon.Question) = DialogResult.OK) Then
                m_stoStatusObject.RequestStatus(ValveControl.Name, strValue)
                'Not good as this
                Dim strValveName As String = String.Empty
                strValveName = Replace(ValveControl.Name, "ValveControl", "")
                strValveName = Replace(strValveName, "Valve", "")
                strValveName = Replace(strValveName, "ticGasPump", "Rough Pump")
                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Name)

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] " + strLogMessage + " " + strValveName + " Valve")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ValveControl_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on ring valve
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ValveRingControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveRingControl.Click
        AVPLib.Log.guiLogger.Info("Enter ValveRingControl_Click")
        Try
            Dim strMessageText As String
            Dim strValue As String
            Dim ValveControl As AVP_Robot_Project.ValveRingControl = CType(sender, AVP_Robot_Project.ValveRingControl)

            Dim Message As String = ValveControl.Name
            Dim strLogMessage As String = String.Empty

            If (ValveControl.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(Message + STRING_CLOSE)
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
                strLogMessage = "Close Hivac Valve"
            Else
                strMessageText = AVPLib.ContainerData.GetMessageText(Message + STRING_OPEN)
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
                strLogMessage = "Open Hivac Valve"
            End If
            If (Utils.ShowAVPMessageBox(strMessageText, "Valve", MessageBoxIcon.Question) = DialogResult.OK) Then
                m_stoStatusObject.RequestStatus(ValveControl.Name, strValue)
                'Me.tmWaitingForHivacValveChange.Enabled = True
                Me.HivacValveStatus = IIf(ValveControl.Status = 1, BinaryStatusControl.DisplayStatus.On.ToString(STRING_G), BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G))

                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Name)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "]" + strChamberName + "] " + strLogMessage)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ValveRingControl_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on ring valve
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ScreenMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScreenMachine.Click
        AVPLib.Log.guiLogger.Info("Enter ScreenMachine_Click")
        Try
            Dim strMessageText As String
            Dim strValue As String
            Dim ScrenMachine As AVP_Robot_Project.ScreenMachine = CType(sender, AVP_Robot_Project.ScreenMachine)
            Dim Message As String = ScrenMachine.Name
            Dim strLogMessage As String = String.Empty

            If (ScrenMachine.Status = ThirdStatusControl.DisplayStatus.Unknown) Then
                Exit Sub
            End If
            If (ScrenMachine.Status = ThirdStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(Message + STRING_CLOSE)
                strValue = ThirdStatusControl.DisplayStatus.Off.ToString(STRING_G)
                strLogMessage = "Close Shutter"
            Else
                strMessageText = AVPLib.ContainerData.GetMessageText(Message + STRING_OPEN)
                strValue = ThirdStatusControl.DisplayStatus.On.ToString(STRING_G)
                strLogMessage = "Open Shutter"
            End If
            If (Utils.ShowAVPMessageBox(strMessageText, "Shutter", MessageBoxIcon.Question) = DialogResult.OK) Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, strLogMessage)
                m_stoStatusObject.RequestStatus(ScrenMachine.Name, strValue)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ScreenMachine_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on ring valve
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTooltipFixture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTooltipFixture.Click
        AVPLib.Log.guiLogger.Info("Enter btnTooltipFixture_Click")
        Try
            Loaded = True
            Dim pos As New System.Drawing.Point(Me.btnTooltipFixture.Location)
            pos.Y += Me.btnTooltipFixture.Height
            pos = Me.PointToScreen(pos)
            Me.cmstooltipFixture.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnTooltipFixture_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on ring valve
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub btnTooltipMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter btnTooltipMachine_Click")
        Try
            Loaded = True
            Dim pos As New System.Drawing.Point(Me.btnTooltipMachine.Location)
            pos.Y += Me.btnTooltipMachine.Height
            pos = Me.PointToScreen(pos)
            Me.cmsTooltipMachine.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnTooltipMachine_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu valve status
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTooltipValveStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTooltipValveStatus.Click
        AVPLib.Log.guiLogger.Info("Enter btnTooltipMachine_Click")
        Try
            Loaded = True
            Dim pos As New System.Drawing.Point(Me.btnTooltipValveStatus.Location)
            pos.Y += Me.btnTooltipValveStatus.Height
            pos = Me.PointToScreen(pos)
            Me.cmsTooltipValveStatus.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnTooltipMachine_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle Click Tooltip valve status
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmsTooltipValveStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFixtureOpenWaterValve.Click, mnuFixtureOpenFlowCool.Click
        AVPLib.Log.guiLogger.Info("Enter mnuTooltipFixture_Click")
        Dim strMessageText As String = String.Empty
        Try
            Dim Tooltip As System.Windows.Forms.ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
            Dim Message As String = Tooltip.Name
            Dim strValue As String = STR_ON
            Dim strOpen As String = AVPLib.IBEConfigurationValues.DEVICE_STATUS_OPEN
            Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Name)

            If Tooltip.Name = AVP_Robot_Project.ConstantAndEnum.MNU_FIXTURE_OPEN_WATER_VALVE Then
                strValue = IIf((ConstantAndEnum.OPEN_WATER_VALVE = Tooltip.Text), STR_ON, STR_OFF)
                If strValue = STR_ON Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("WaterValveOpen")
                    If (Utils.ShowAVPMessageBox(strMessageText, OPEN_WATER_VALVE, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, strValue)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Open Water Valve")
                    End If
                Else
                    strMessageText = AVPLib.ContainerData.GetMessageText("WaterValveClose")
                    If (Utils.ShowAVPMessageBox(strMessageText, CLOSE_WATER_VALVE, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, strValue)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Close Water Valve")
                    End If
                End If
            ElseIf Tooltip.Name = AVP_Robot_Project.ConstantAndEnum.MNU_FIXTURE_OPEN_FLOW_COOL Then
                strValue = IIf((ConstantAndEnum.OPEN_FLOW_COOL = Tooltip.Text), STR_ON, STR_OFF)
                If strValue = STR_ON Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("FlowCoolPumpOpen")
                    If (Utils.ShowAVPMessageBox(strMessageText, OPEN_FLOW_COOL, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, strValue)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Open FlowCool Pump Power Valve")
                    End If
                Else
                    strMessageText = AVPLib.ContainerData.GetMessageText("FlowCoolPumpClose")
                    If (Utils.ShowAVPMessageBox(strMessageText, CLOSE_FLOW_COOL, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, strValue)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Close FlowCool Pump Power")
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuTooltipFixture_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle Click Tooltip Fixture
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuTooltipFixture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFixtureStopAllAxis.Click, mnuFixtureStartRotationAxis.Click, mnuFixtureOnClamp.Click, mnuFixtureHomeTiltAxis.Click, mnuFixtureHomeRotationAxis.Click, mnuFixtureHomeAllAxis.Click
        AVPLib.Log.guiLogger.Info("Enter mnuTooltipFixture_Click")
        Dim strMessageText As String = String.Empty
        Try
            Dim Tooltip As System.Windows.Forms.ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
            Dim Message As String = Tooltip.Name
            Dim strValue As String = STR_ON
            Dim strOpen As String = AVPLib.IBEConfigurationValues.DEVICE_STATUS_OPEN
            Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Name)

            If Tooltip.Name = AVP_Robot_Project.ConstantAndEnum.MNU_FIXTURE_HOME_ALL_AXIS Then
                strMessageText = AVPLib.ContainerData.GetMessageText("HomeAllAxisChamberPanel")
                If (Utils.ShowAVPMessageBox(strMessageText, HOME_ALL_AXIS, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(Message, strValue)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Home All Axis")
                End If
            ElseIf Tooltip.Name = AVP_Robot_Project.ConstantAndEnum.MNU_FIXTURE_ON_CLAMP Then
                strMessageText = AVPLib.ContainerData.GetMessageText("OnClampChamberPanel")
                If Tooltip.Text = ConstantAndEnum.CLAMP_UP Then
                    If (Utils.ShowAVPMessageBox(strMessageText, CLAMP_UP, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, AVPLib.ConstEnum.STR_ONCLAMP)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Clamp Up")
                    End If
                ElseIf Tooltip.Text = ConstantAndEnum.CLAMP_DOWN Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("UnClampChamberPanel")
                    If (Utils.ShowAVPMessageBox(strMessageText, CLAMP_DOWN, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, AVPLib.ConstEnum.STR_UNCLAMP)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] UnClamp")
                    End If
                End If
            ElseIf Tooltip.Name = MNU_FIXTURE_STOP_ALL_AXIS Then
                strMessageText = AVPLib.ContainerData.GetMessageText("StopAllAxisChamberPanel")
                If (Utils.ShowAVPMessageBox(strMessageText, STOP_ALL_AXIS, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(Message, strValue)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Stop All Axis")
                End If
            ElseIf Tooltip.Name = MNU_FIXTURE_HOME_TILT_AXIS Then
                strMessageText = AVPLib.ContainerData.GetMessageText("HomeTiltAxisChamberPanel")
                If (Utils.ShowAVPMessageBox(strMessageText, HOME_TILT_AXIS, MessageBoxIcon.Question) = DialogResult.OK) Then
                    Dim dbValue As Double = AVPLib.ContainerData.GetPressureConfig("Rotation_Tilt_Angle")
                    m_stoStatusObject.RequestStatus(Message, dbValue)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Home Tilt Axis")
                End If
            ElseIf Tooltip.Name = MNU_FIXTURE_HOME_ROTATION_AXIS Then
                strMessageText = AVPLib.ContainerData.GetMessageText("HomeRotationAxisChamberPanel")
                If (Utils.ShowAVPMessageBox(strMessageText, HOME_ROTATION_AXIS, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(Message, AVPLib.IBEConfigurationValues.DEVICE_HOME)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Home Rotation Axis")
                End If
            ElseIf Tooltip.Name = MNU_FIXTURE_START_ROTATION_AXIS Then
                strMessageText = AVPLib.ContainerData.GetMessageText("StartRotationAxisChamberPanel")
                If (Utils.ShowAVPMessageBox(strMessageText, START_ROTATION_AXIS, MessageBoxIcon.Question) = DialogResult.OK) Then
                    If Current_Status_Fixture = AVPLib.IBEConfigurationValues.DEVICE_SWEEP Then
                        m_stoStatusObject.RequestStatus(Message, AVPLib.IBEConfigurationValues.DEVICE_SWEEP)
                    ElseIf Current_Status_Fixture = AVPLib.IBEConfigurationValues.DEVICE_STATIC Then
                        m_stoStatusObject.RequestStatus(Message, AVPLib.IBEConfigurationValues.DEVICE_STATIC)
                    ElseIf Current_Status_Fixture = AVPLib.IBEConfigurationValues.DEVICE_CONTINUOUS Then
                        m_stoStatusObject.RequestStatus(Message, AVPLib.IBEConfigurationValues.DEVICE_CONTINUOUS)
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Start Rotation Axis")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuTooltipFixture_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' mnuTooltipFixture_EnabledChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuTooltipFixture_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuFixtureStopAllAxis.EnabledChanged, mnuFixtureStartRotationAxis.EnabledChanged, mnuFixtureOnClamp.EnabledChanged, mnuFixtureHomeTiltAxis.EnabledChanged, mnuFixtureHomeRotationAxis.EnabledChanged, mnuFixtureHomeAllAxis.EnabledChanged
        AVPLib.Log.guiLogger.Info("Enter mnuTooltipFixture_EnabledChanged")
        Try
            Dim strClosed As String = AVPLib.IBEConfigurationValues.DEVICE_STATUS_CLOSED
            If Loaded = False Then
                Return
            End If
            Dim Tooltip As System.Windows.Forms.ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)

            Dim Message As String = Me.Name + Tooltip.Name
            If Tooltip.Name = AVP_Robot_Project.ConstantAndEnum.MNU_FIXTURE_HOME_ALL_AXIS Then 'mnufixturehomeallaxis
                'ChangeStatusTooltipFixture(Nothing, Nothing, Nothing)
            ElseIf Tooltip.Name = AVP_Robot_Project.ConstantAndEnum.MNU_FIXTURE_ON_CLAMP Then '"mnuFixtureOnClamp" 
                'ChangeStatusTooltipFixture(strClosed, Nothing, Nothing)
            ElseIf Tooltip.Name = AVP_Robot_Project.ConstantAndEnum.MNU_FIXTURE_UN_CLAMP Then '"mnuFixtureUnClamp" 
                'ChangeStatusTooltipFixture(Nothing, strClosed, Nothing)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuTooltipFixture_EnabledChanged")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-08</date>
    ''' </author>
    ''' <summary>
    ''' Handle button ReConnect to IBE
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Overrides Sub btnReConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter btnReConnect_Click")
        Try
            If Me.btnReConnect.Status = ButtonIGCGControl.DisplayStatus.Off Then
                btnReConnect.Enabled = False
                btnReConnect.Status = ButtonIGCGControl.DisplayStatus.Unknow
                m_stoStatusObject.RequestStatus(Me.btnReConnect.Name, STR_ON)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnReConnect_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle Click Tooltip Machine
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuTooltipMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuMachineVent.Click, _
        mnuMachinePumpDown.Click, _
        mnuMachineOnline.Click, _
        mnuMachineCryoPumpRegen.Click, _
        mnuMachineCryoOn.Click, _
        mnuMachineCryoAutoRegen.Click

        AVPLib.Log.guiLogger.Info("Enter mnuTooltipMachine_Click")
        Dim strMessageText As String = String.Empty

        Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Name)

        Try
            If Loaded = False Then
                AVPLib.Log.guiLogger.Info("Leave mnuTooltipMachine_Click")
                Return
            End If

            Dim Tooltip As System.Windows.Forms.ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)

            Dim Message As String = Tooltip.Name

            If Tooltip.Name = Me.mnuMachineOnline.Name Then
                If Tooltip.Text = STRING_OFFLINE Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("OfflineChamberPanel")
                    If (Utils.ShowAVPMessageBox(strMessageText, STRING_OFFLINE, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Bring Chamber Offline")
                    End If
                ElseIf Me.mnuMachineOnline.Text = STRING_ONLINE Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("OnlineChamberPanel")
                    If (Utils.ShowAVPMessageBox(strMessageText, STRING_ONLINE, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Bring Chamber Online")
                    End If
                End If
            ElseIf Tooltip.Name = Me.mnuMachinePumpDown.Name Then
                If Tooltip.Text = STRING_STOP_PUMP_DOWN Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("StopPumpDownChamberPanel")
                    If (Utils.ShowAVPMessageBox(strMessageText, STRING_STOP_PUMP_DOWN, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Stop Pump Down")
                    End If
                Else
                    strMessageText = AVPLib.ContainerData.GetMessageText("StartPumpDownChamberPanel")
                    If (Utils.ShowAVPMessageBox(strMessageText, STRING_START_PUMP_DOWN, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Start Pump Down")
                    End If
                End If
            ElseIf Tooltip.Name = Me.mnuMachineVent.Name Then
                If Tooltip.Text = STRING_STOP_VENT Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("StopVentChamberPanel")
                    If (Utils.ShowAVPMessageBox(strMessageText, STRING_STOP_VENT, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Stop Vent")
                    End If
                Else
                    strMessageText = AVPLib.ContainerData.GetMessageText("StartVentChamberPanel")
                    If (Utils.ShowAVPMessageBox(strMessageText, STRING_START_VENT, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Start Vent")
                    End If
                End If
            ElseIf Tooltip.Name = Me.mnuMachineCryoOn.Name Then
                If Utils.CheckHivacValveOpen_BeforeCryo(Me.Parent.Name) Then
                    Exit Sub
                End If
                If Tooltip.Text = STRING_CRYO_OFF Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("CryoOffChamberPanel")
                    If (Utils.ShowAVPMessageBox(strMessageText, STRING_CRYO_OFF, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Turn Cryo Off")
                    End If
                Else
                    strMessageText = AVPLib.ContainerData.GetMessageText("CryoOnChamberPanel")
                    If (Utils.ShowAVPMessageBox(strMessageText, STRING_CRYO_ON, MessageBoxIcon.Question) = DialogResult.OK) Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Turn Cryo On")
                    End If
                End If
            ElseIf Tooltip.Name = mnuMachineCryoAutoRegen.Name Then
                strMessageText = AVPLib.ContainerData.GetMessageText("CryoAutoRegen")
                If (Utils.ShowAVPMessageBox(strMessageText, CRYO_AUTO_PUMP_REGEN, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(Message, STR_ON)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Start Cryo Regen")
                End If
            ElseIf Tooltip.Name = Me.mnuMachineCryoPumpRegen.Name Then
                strMessageText = AVPLib.ContainerData.GetMessageText("CryoPumpRegen")
                If (Utils.ShowAVPMessageBox(strMessageText, STRING_CRYO_PUMP_REGEN, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(Message, STR_OFF)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Stop Cryo Regen")
                End If
            End If
            '''<end of Truc add code>
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuTooltipMachine_Click")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle Text Changed Tooltip Machine
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuMachineOnline_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuMachineVent.TextChanged, mnuMachinePumpDown.TextChanged, mnuMachineOnline.TextChanged
        AVPLib.Log.guiLogger.Info("Enter mnuMachineOnline_TextChanged")
        Try
            If Loaded = False Then
                Return
            End If
            Dim Tooltip As System.Windows.Forms.ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
            If Tooltip.Name = Me.mnuMachineOnline.Name Then
                If Tooltip.Text = STRING_OFFLINE Then
                    Me.mnuMachinePumpDown.Enabled = False
                    Me.mnuMachineVent.Enabled = False
                Else
                    Me.mnuMachinePumpDown.Enabled = True
                    Me.mnuMachineVent.Enabled = True
                End If
                'Me.mnuMachineOnline.Enabled = False
            End If

            If MachineHandleClick = True Then
                MachineHandleClick = False
                AVPLib.Log.guiLogger.Info("Leave mnuMachineOnline_TextChanged")
                Return
            End If


            Dim Message As String = Me.Name + Tooltip.Name
            If Tooltip.Name = Me.mnuMachineOnline.Name Then
                Me.mnuMachinePumpDown.Enabled = True
                Me.mnuMachineVent.Enabled = True
                Me.mnuMachineOnline.Text = STRING_ONLINE

                Me.ValveControlArgon.Enabled = True
                Me.ValveControlFlowCoolHe.Enabled = True
                Me.ValveControlForeline.Enabled = True
                Me.ValveControlPBN.Enabled = True
                Me.ValveControlRough.Enabled = True
                Me.ValveControlVent.Enabled = True
                Me.ValveRingControl.Enabled = True
            ElseIf Tooltip.Name = Me.mnuMachinePumpDown.Name Then
                Me.mnuMachineOnline.Enabled = True
                Me.mnuMachineVent.Enabled = True
                Me.mnuMachinePumpDown.Text = AVP_Robot_Project.ConstantAndEnum.PUMP_DOWN
            ElseIf Tooltip.Name = Me.mnuMachineVent.Name Then
                Me.mnuMachineOnline.Enabled = True
                Me.mnuMachinePumpDown.Enabled = True
                Me.mnuMachineVent.Text = AVP_Robot_Project.ConstantAndEnum.VENT
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuMachineOnline_TextChanged")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-23</date>
    ''' </author>
    ''' <summary>
    ''' Timer1_Tick
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmWaitingForHivacValveChange_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmWaitingForHivacValveChange.Tick
        AVPLib.Log.guiLogger.Info("Enter Timer1_Tick")
        Try
            TimeWaiting += 1
            Dim ValveRingControlStatus As String = Me.ValveRingControl.Status.ToString()
            If HivacValveStatus <> ValveRingControlStatus Then
                Me.tmWaitingForHivacValveChange.Enabled = False
                TimeWaiting = 0
            ElseIf TimeWaiting >= TimeWait Then
                Me.tmWaitingForHivacValveChange.Enabled = False
                TimeWaiting = 0
                Dim Message As String = IIf(STR_ON = HivacValveStatus, AVP_Robot_Project.ConstantAndEnum.HIVAC_VALVE_CONTROL_OPEN_FAIL, AVP_Robot_Project.ConstantAndEnum.HIVAC_VALVE_CONTROL_CLOSE_FAIL)
                Dim MessageText As String = AVPLib.ContainerData.GetMessageText(Message)
                'MessageBox.Show(MessageText, AVP_Robot_Project.ConstantAndEnum.HIVAC_VALVE, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Utils.ShowAVPMessageBox(MessageText, AVP_Robot_Project.ConstantAndEnum.HIVAC_VALVE, MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                           AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                           "[Main Screen] " + "Waiting time for open/close Hivac valve is overload")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Timer1_Tick")
    End Sub
#End Region

End Class
