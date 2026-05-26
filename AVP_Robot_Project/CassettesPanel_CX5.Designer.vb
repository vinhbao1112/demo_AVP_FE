<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CassettesPanel
    Inherits AVP_Robot_Project.StatusPanel

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CassettesPanel))
        Me.lblPM1MotionInitialize = New System.Windows.Forms.Label
        Me.lblPM2MotionInitialize = New System.Windows.Forms.Label
        Me.lblPM3MotionInitialize = New System.Windows.Forms.Label
        Me.MesaValveLLA = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.MesaValvePM1 = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.MesaValvePM2 = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.MesaValvePM3 = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.MesaValveLLB = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.HivacValveLLA = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.HivacValveLLB = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.HivacValveTM = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.cmsChamber = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCreateWafer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDeleteWafer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSrcForMove = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDstForMove = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUpdateWaferInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsTool = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuHome = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAlign = New System.Windows.Forms.ToolStripMenuItem
        Me.awcAligner = New AVP_Robot_Project.AlignerWaferControl
        Me.lblStatusText = New System.Windows.Forms.Label
        Me.lblCoreMessageBoxText = New System.Windows.Forms.Label
        Me.lblFastRoughtValve = New System.Windows.Forms.Label
        Me.lblFastVentValve = New System.Windows.Forms.Label
        Me.lblLLBFastRough = New System.Windows.Forms.Label
        Me.lblLLAFastRough = New System.Windows.Forms.Label
        Me.lblLLAFastVent = New System.Windows.Forms.Label
        Me.lblLLBFastVent = New System.Windows.Forms.Label
        Me.lblLLBSlowRough = New System.Windows.Forms.Label
        Me.lblLLASlowVent = New System.Windows.Forms.Label
        Me.lblLLBSlowVent = New System.Windows.Forms.Label
        Me.lblLLASlowRough = New System.Windows.Forms.Label
        Me.cmsMechineTool = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMechineOnline = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMechineOffline = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMechinePumpDown = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMechineStopPumpDown = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMechineVent = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMechineStopVent = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsLeftTool = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuLeftOnline = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLeftOffline = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLeftPumpDown = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLeftStopPumpDown = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLeftVent = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLeftStopVent = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsRightTool = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuRightOnline = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRightOffline = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRightPumpDown = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRightStopPumpDown = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRightVent = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRightStopVent = New System.Windows.Forms.ToolStripMenuItem
        Me.clearStatusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblRoughPumpInUse = New System.Windows.Forms.Label
        Me.LLAIgStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.LLBIgStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.tabGroup = New System.Windows.Forms.CustomTabControl
        Me.tabCycleWafer = New System.Windows.Forms.TabPage
        Me.atwAutoTransferWafer = New AVP_Robot_Project.AutoTransferWaferControl
        Me.tabSerialCommand = New System.Windows.Forms.TabPage
        Me.sccSerialCommand = New AVP_Robot_Project.SerialCommandControl
        Me.tabCycle = New System.Windows.Forms.TabPage
        Me.ctwcCycleWafer = New AVP_Robot_Project.CycleTransferWaferControl
        Me.lblTMNameOfSequenceRunning = New System.Windows.Forms.Label
        Me.lblLLANameOfSequenceRunning = New System.Windows.Forms.Label
        Me.lblLLBNameOfSequenceRunning = New System.Windows.Forms.Label
        Me.lblFlashing = New AVP_Robot_Project.FlashingLabel
        Me.lblPump1 = New System.Windows.Forms.Label
        Me.lblPump2 = New System.Windows.Forms.Label
        Me.lblRoughLineLLB = New System.Windows.Forms.Label
        Me.lblRoughLineLLA = New System.Windows.Forms.Label
        Me.lblRoughLineTM = New System.Windows.Forms.Label
        Me.lblVentLineLLA = New System.Windows.Forms.Label
        Me.lblVentLineLLB = New System.Windows.Forms.Label
        Me.lblVentLineTM = New System.Windows.Forms.Label
        Me.lblRoughPumpInUse_2 = New System.Windows.Forms.Label
        Me.txtTurboIGTM = New System.Windows.Forms.TextBox
        Me.txtTurboIGLLB = New System.Windows.Forms.TextBox
        Me.txtTurboIGLLA = New System.Windows.Forms.TextBox
        Me.txtRoughLineTM = New System.Windows.Forms.TextBox
        Me.txtRoughLineLLB = New System.Windows.Forms.TextBox
        Me.txtRoughLineLLA = New System.Windows.Forms.TextBox
        Me.lblTurboForlineLLA = New System.Windows.Forms.Label
        Me.lblTurboForlineLLB = New System.Windows.Forms.Label
        Me.lblTurboForlineTM = New System.Windows.Forms.Label
        Me.lblComunicationLED_TurboLLA = New System.Windows.Forms.Label
        Me.lblComunicationLED_TurboLLB = New System.Windows.Forms.Label
        Me.btnTurboRelayIndicator_LLA = New AVP_Robot_Project.SL_CustomButton
        Me.btnTurboRelayIndicator_TM = New AVP_Robot_Project.SL_CustomButton
        Me.btnTurboRelayIndicator_LLB = New AVP_Robot_Project.SL_CustomButton
        Me.btnRelayIndicatorPump2 = New AVP_Robot_Project.SL_CustomButton
        Me.btnRelayIndicatorPump1 = New AVP_Robot_Project.SL_CustomButton
        Me.GasRoughLine = New AVP_Robot_Project.TransparentImageControl
        Me.btnTurboTM = New AVP_Robot_Project.SL_CustomButton
        Me.btnTurboLLB = New AVP_Robot_Project.SL_CustomButton
        Me.btnTurboLLA = New AVP_Robot_Project.SL_CustomButton
        Me.TurboPumpTM = New AVP_Robot_Project.TransparentImageControl
        Me.ValveTMTurbo = New AVP_Robot_Project.ValveControl
        Me.ValveLLBTurbo = New AVP_Robot_Project.ValveControl
        Me.ValveLLATurbo = New AVP_Robot_Project.ValveControl
        Me.GasLineTurboValveLLB = New AVP_Robot_Project.TransparentImageControl
        Me.GasLineTurboValveLLA = New AVP_Robot_Project.TransparentImageControl
        Me.btnMechineTool = New System.Windows.Forms.Button
        Me.GasLineTurboTM = New AVP_Robot_Project.TransparentImageControl
        Me.btnLeftTool = New System.Windows.Forms.Button
        Me.btnRightTool = New System.Windows.Forms.Button
        Me.btnCancelMove = New AVP_Robot_Project.SL_CustomButton
        Me.btnFakeProcessCompleteChime = New AVP_Robot_Project.SL_CustomButton
        Me.RoughPumpControl2 = New AVP_Robot_Project.ValveControl
        Me.ticHandOriginal = New AVP_Robot_Project.RobotHand
        Me.btnTMProtectedMode = New AVP_Robot_Project.SL_CustomButton
        Me.crcTMWaterPump = New AVP_Robot_Project.WaterPump
        Me.btnTool = New System.Windows.Forms.Button
        Me.stwSemiautoTransferWafer = New AVP_Robot_Project.SemiautoTranferWaferControl
        Me.IgcgChamber1 = New AVP_Robot_Project.IGCGControl
        Me.IgcgChamber2 = New AVP_Robot_Project.IGCGControl
        Me.IgcgChamber3 = New AVP_Robot_Project.IGCGControl
        Me.Robot_Body = New AVP_Robot_Project.RobotBody
        Me.CX_PM1 = New AVP_Robot_Project.PMControl
        Me.CX_PM2 = New AVP_Robot_Project.PMControl
        Me.CX_PM3 = New AVP_Robot_Project.PMControl
        Me.ibsHivacButton = New AVP_Robot_Project.ImageHivacTMTransferModule
        Me.TMCtl = New AVP_Robot_Project.TMControl
        Me.crcLLBCryo = New AVP_Robot_Project.CryoControl
        Me.crcLLACryo = New AVP_Robot_Project.CryoControl
        Me.lccLoadLockB = New AVP_Robot_Project.LockCassetteControl
        Me.RoughPumpControl = New AVP_Robot_Project.ValveControl
        Me.ValveLLASlowRough = New AVP_Robot_Project.ValveControl
        Me.ValveRough = New AVP_Robot_Project.ValveControl
        Me.ValveVent = New AVP_Robot_Project.ValveControl
        Me.ValveLLAFastRough = New AVP_Robot_Project.ValveControl
        Me.ValveLLBFastRough = New AVP_Robot_Project.ValveControl
        Me.ValveLLBSlowRough = New AVP_Robot_Project.ValveControl
        Me.crcTMCryo = New AVP_Robot_Project.CryoControl
        Me.lccLoadLockA = New AVP_Robot_Project.LockCassetteControl
        Me.ValveLLBFastVent = New AVP_Robot_Project.ValveControl
        Me.ValveLLAFastVent = New AVP_Robot_Project.ValveControl
        Me.ValveLLASlowVent = New AVP_Robot_Project.ValveControl
        Me.GasLineNitrogen = New AVP_Robot_Project.TransparentImageControl
        Me.ValveLLBSlowVent = New AVP_Robot_Project.ValveControl
        Me.GasLineRoughValveLLA = New AVP_Robot_Project.TransparentImageControl
        Me.GasLineRoughValveLLB = New AVP_Robot_Project.TransparentImageControl
        Me.GasLineVentValveLLB = New AVP_Robot_Project.TransparentImageControl
        Me.TurboPumpLLB = New AVP_Robot_Project.TransparentImageControl
        Me.TurboPumpLLA = New AVP_Robot_Project.TransparentImageControl
        Me.LLBLeg = New AVP_Robot_Project.LoadLockLeg
        Me.LLALeg = New AVP_Robot_Project.LoadLockLeg
        Me.GasLineVentValveLLA = New AVP_Robot_Project.TransparentImageControl
        Me.lblComunicationLED_TurboTM = New System.Windows.Forms.Label
        Me.cmsChamber.SuspendLayout()
        Me.cmsTool.SuspendLayout()
        Me.cmsMechineTool.SuspendLayout()
        Me.cmsLeftTool.SuspendLayout()
        Me.cmsRightTool.SuspendLayout()
        Me.tabGroup.SuspendLayout()
        Me.tabCycleWafer.SuspendLayout()
        Me.tabSerialCommand.SuspendLayout()
        Me.tabCycle.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPM1MotionInitialize
        '
        Me.lblPM1MotionInitialize.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM1MotionInitialize.ForeColor = System.Drawing.Color.Yellow
        Me.lblPM1MotionInitialize.Location = New System.Drawing.Point(100, 493)
        Me.lblPM1MotionInitialize.Name = "lblPM1MotionInitialize"
        Me.lblPM1MotionInitialize.Size = New System.Drawing.Size(266, 33)
        Me.lblPM1MotionInitialize.Visible = True
        Me.lblPM1MotionInitialize.TabIndex = 245
        '
        'lblPM2MotionInitialize
        '
        Me.lblPM2MotionInitialize.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM2MotionInitialize.ForeColor = System.Drawing.Color.Yellow
        Me.lblPM2MotionInitialize.Location = New System.Drawing.Point(100, 493)
        Me.lblPM2MotionInitialize.Name = "lblPM2MotionInitialize"
        Me.lblPM2MotionInitialize.Size = New System.Drawing.Size(266, 33)
        Me.lblPM2MotionInitialize.Visible = True
        Me.lblPM2MotionInitialize.TabIndex = 245
        '
        'lblPM3MotionInitialize
        '
        Me.lblPM3MotionInitialize.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM3MotionInitialize.ForeColor = System.Drawing.Color.Yellow
        Me.lblPM3MotionInitialize.Location = New System.Drawing.Point(100, 493)
        Me.lblPM3MotionInitialize.Name = "lblPM3MotionInitialize"
        Me.lblPM3MotionInitialize.Size = New System.Drawing.Size(266, 33)
        Me.lblPM3MotionInitialize.Visible = True
        Me.lblPM3MotionInitialize.TabIndex = 245
        '
        'MesaValveLLA
        '
        Me.MesaValveLLA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MesaValveLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValveLLA.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX5
        Me.MesaValveLLA.FixedSize = False
        Me.MesaValveLLA.Location = New System.Drawing.Point(405, 355)
        Me.MesaValveLLA.Name = "MesaValveLLA"
        Me.MesaValveLLA.Size = New System.Drawing.Size(67, 41)
        Me.MesaValveLLA.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Unknown
        Me.MesaValveLLA.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        Me.MesaValveLLA.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.LLA
        Me.MesaValveLLA.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.LLA
        Me.MesaValveLLA.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.LLA
        Me.MesaValveLLA.TabIndex = 45
        '
        'MesaValvePM1
        '
        Me.MesaValvePM1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MesaValvePM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValvePM1.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX5
        Me.MesaValvePM1.FixedSize = False
        Me.MesaValvePM1.Location = New System.Drawing.Point(399, 234)
        Me.MesaValvePM1.Name = "MesaValvePM1"
        Me.MesaValvePM1.Size = New System.Drawing.Size(17, 70)
        Me.MesaValvePM1.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Unknown
        Me.MesaValvePM1.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        Me.MesaValvePM1.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.LLA
        Me.MesaValvePM1.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.PM1
        Me.MesaValvePM1.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.LLA
        Me.MesaValvePM1.TabIndex = 57
        '
        'MesaValvePM2
        '
        Me.MesaValvePM2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MesaValvePM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValvePM2.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX5
        Me.MesaValvePM2.FixedSize = False
        Me.MesaValvePM2.Location = New System.Drawing.Point(405, 174)
        Me.MesaValvePM2.Name = "MesaValvePM2"
        Me.MesaValvePM2.Size = New System.Drawing.Size(61, 54)
        Me.MesaValvePM2.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Unknown
        Me.MesaValvePM2.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        Me.MesaValvePM2.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.LLA
        Me.MesaValvePM2.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.PM2
        Me.MesaValvePM2.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.LLA
        Me.MesaValvePM2.TabIndex = 58
        '
        'MesaValvePM3
        '
        Me.MesaValvePM3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MesaValvePM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValvePM3.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX5
        Me.MesaValvePM3.FixedSize = False
        Me.MesaValvePM3.Location = New System.Drawing.Point(468, 169)
        Me.MesaValvePM3.Name = "MesaValvePM3"
        Me.MesaValvePM3.Size = New System.Drawing.Size(80, 17)
        Me.MesaValvePM3.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Unknown
        Me.MesaValvePM3.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        Me.MesaValvePM3.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.LLA
        Me.MesaValvePM3.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.PM3
        Me.MesaValvePM3.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.LLA
        Me.MesaValvePM3.TabIndex = 59
        '
        'MesaValveLLB
        '
        Me.MesaValveLLB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MesaValveLLB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValveLLB.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX5
        Me.MesaValveLLB.FixedSize = False
        Me.MesaValveLLB.Location = New System.Drawing.Point(528, 356)
        Me.MesaValveLLB.Name = "MesaValveLLB"
        Me.MesaValveLLB.Size = New System.Drawing.Size(70, 38)
        Me.MesaValveLLB.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Closed
        Me.MesaValveLLB.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        Me.MesaValveLLB.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.LLA
        Me.MesaValveLLB.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.LLB
        Me.MesaValveLLB.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.LLA
        Me.MesaValveLLB.TabIndex = 44
        '
        'HivacValveTM
        '
        Me.HivacValveTM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.HivacValveTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HivacValveTM.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX5
        Me.HivacValveTM.FixedSize = False
        Me.HivacValveTM.Location = New System.Drawing.Point(338, 373)
        Me.HivacValveTM.Name = "HivacValveTM"
        Me.HivacValveTM.Size = New System.Drawing.Size(53, 60)
        Me.HivacValveTM.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Opened
        Me.HivacValveTM.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.HIVAC_TM
        Me.HivacValveTM.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.HIVAC_LLB
        Me.HivacValveTM.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.HIVAC_LLA
        Me.HivacValveTM.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.HIVAC_LLA
        Me.HivacValveTM.TabIndex = 62
        '
        'HivacValveLLA
        '
        Me.HivacValveLLA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.HivacValveLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HivacValveLLA.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX5
        Me.HivacValveLLA.FixedSize = False
        Me.HivacValveLLA.Location = New System.Drawing.Point(338, 373)
        Me.HivacValveLLA.Name = "HivacValveLLA"
        Me.HivacValveLLA.Size = New System.Drawing.Size(53, 60)
        Me.HivacValveLLA.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Opened
        Me.HivacValveLLA.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        Me.HivacValveLLA.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.HIVAC_LLB
        Me.HivacValveLLA.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.HIVAC_LLA
        Me.HivacValveLLA.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.HIVAC_LLA
        Me.HivacValveLLA.TabIndex = 62
        '
        'HivacValveLLB
        '
        Me.HivacValveLLB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.HivacValveLLB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HivacValveLLB.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX5
        Me.HivacValveLLB.FixedSize = False
        Me.HivacValveLLB.Location = New System.Drawing.Point(610, 371)
        Me.HivacValveLLB.Name = "HivacValveLLB"
        Me.HivacValveLLB.Size = New System.Drawing.Size(53, 60)
        Me.HivacValveLLB.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Opened
        Me.HivacValveLLB.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        Me.HivacValveLLB.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.LLA
        Me.HivacValveLLB.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.HIVAC_LLB
        Me.HivacValveLLB.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.HIVAC_LLB
        Me.HivacValveLLB.TabIndex = 63
        '
        'cmsChamber
        '
        Me.cmsChamber.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsChamber.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCreateWafer, Me.mnuDeleteWafer, Me.mnuSrcForMove, Me.mnuDstForMove, Me.mnuUpdateWaferInfoToolStripMenuItem})
        Me.cmsChamber.Name = "cmsChamber"
        Me.cmsChamber.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsChamber.ShowImageMargin = False
        Me.cmsChamber.Size = New System.Drawing.Size(261, 164)
        '
        'mnuCreateWafer
        '
        Me.mnuCreateWafer.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuCreateWafer.Name = "mnuCreateWafer"
        Me.mnuCreateWafer.Size = New System.Drawing.Size(260, 32)
        Me.mnuCreateWafer.Text = "Create Wafer"
        '
        'mnuDeleteWafer
        '
        Me.mnuDeleteWafer.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuDeleteWafer.Name = "mnuDeleteWafer"
        Me.mnuDeleteWafer.Size = New System.Drawing.Size(260, 32)
        Me.mnuDeleteWafer.Text = "Delete Wafer"
        '
        'mnuSrcForMove
        '
        Me.mnuSrcForMove.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSrcForMove.Name = "mnuSrcForMove"
        Me.mnuSrcForMove.Size = New System.Drawing.Size(260, 32)
        Me.mnuSrcForMove.Text = "Src For Move"
        '
        'mnuDstForMove
        '
        Me.mnuDstForMove.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuDstForMove.Name = "mnuDstForMove"
        Me.mnuDstForMove.Size = New System.Drawing.Size(260, 32)
        Me.mnuDstForMove.Text = "Dst For Move"
        '
        'mnuUpdateWaferInfoToolStripMenuItem
        '
        Me.mnuUpdateWaferInfoToolStripMenuItem.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuUpdateWaferInfoToolStripMenuItem.Name = "mnuUpdateWaferInfoToolStripMenuItem"
        Me.mnuUpdateWaferInfoToolStripMenuItem.Size = New System.Drawing.Size(260, 32)
        Me.mnuUpdateWaferInfoToolStripMenuItem.Text = "Update Wafer Info"
        '
        'cmsTool
        '
        Me.cmsTool.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHome, Me.mnuAlign})
        Me.cmsTool.Name = "cmsTool"
        Me.cmsTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsTool.ShowImageMargin = False
        Me.cmsTool.Size = New System.Drawing.Size(137, 68)
        '
        'mnuHome
        '
        Me.mnuHome.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuHome.Name = "mnuHome"
        Me.mnuHome.Size = New System.Drawing.Size(136, 32)
        Me.mnuHome.Text = "Home"
        '
        'mnuAlign
        '
        Me.mnuAlign.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuAlign.Name = "mnuAlign"
        Me.mnuAlign.Size = New System.Drawing.Size(136, 32)
        Me.mnuAlign.Text = "Align"
        Me.mnuAlign.Visible = False
        '
        'awcAligner
        '
        Me.awcAligner.BackColor = System.Drawing.SystemColors.ControlText
        Me.awcAligner.Cursor = System.Windows.Forms.Cursors.Hand
        Me.awcAligner.Location = New System.Drawing.Point(428, 335)
        Me.awcAligner.Name = "awcAligner"
        Me.awcAligner.Size = New System.Drawing.Size(35, 32)
        Me.awcAligner.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.awcAligner.TabIndex = 79
        '
        'lblStatusText
        '
        Me.lblStatusText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatusText.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusText.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusText.ForeColor = System.Drawing.Color.White
        Me.lblStatusText.Location = New System.Drawing.Point(33, 725)
        Me.lblStatusText.Name = "lblStatusText"
        Me.lblStatusText.Size = New System.Drawing.Size(1098, 31)
        Me.lblStatusText.TabIndex = 103
        Me.lblStatusText.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblCoreMessageBoxText
        '
        Me.lblCoreMessageBoxText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCoreMessageBoxText.BackColor = System.Drawing.Color.Transparent
        Me.lblCoreMessageBoxText.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoreMessageBoxText.ForeColor = System.Drawing.Color.White
        Me.lblCoreMessageBoxText.Location = New System.Drawing.Point(33, 725)
        Me.lblCoreMessageBoxText.Name = "lblCoreMessageBoxText"
        Me.lblCoreMessageBoxText.Size = New System.Drawing.Size(18, 31)
        Me.lblCoreMessageBoxText.TabIndex = 103
        Me.lblCoreMessageBoxText.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblCoreMessageBoxText.Visible = False
        '
        'lblFastRoughtValve
        '
        Me.lblFastRoughtValve.AutoSize = True
        Me.lblFastRoughtValve.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFastRoughtValve.ForeColor = System.Drawing.Color.White
        Me.lblFastRoughtValve.Location = New System.Drawing.Point(706, 147)
        Me.lblFastRoughtValve.Name = "lblFastRoughtValve"
        Me.lblFastRoughtValve.Size = New System.Drawing.Size(30, 19)
        Me.lblFastRoughtValve.TabIndex = 130
        Me.lblFastRoughtValve.Text = "FR"
        '
        'lblFastVentValve
        '
        Me.lblFastVentValve.AutoSize = True
        Me.lblFastVentValve.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFastVentValve.ForeColor = System.Drawing.Color.White
        Me.lblFastVentValve.Location = New System.Drawing.Point(85, 350)
        Me.lblFastVentValve.Name = "lblFastVentValve"
        Me.lblFastVentValve.Size = New System.Drawing.Size(29, 19)
        Me.lblFastVentValve.TabIndex = 131
        Me.lblFastVentValve.Text = "FV"
        '
        'lblLLBFastRough
        '
        Me.lblLLBFastRough.AutoSize = True
        Me.lblLLBFastRough.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLBFastRough.ForeColor = System.Drawing.Color.White
        Me.lblLLBFastRough.Location = New System.Drawing.Point(721, 430)
        Me.lblLLBFastRough.Name = "lblLLBFastRough"
        Me.lblLLBFastRough.Size = New System.Drawing.Size(30, 19)
        Me.lblLLBFastRough.TabIndex = 132
        Me.lblLLBFastRough.Text = "FR"
        '
        'lblLLAFastRough
        '
        Me.lblLLAFastRough.AutoSize = True
        Me.lblLLAFastRough.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLAFastRough.ForeColor = System.Drawing.Color.White
        Me.lblLLAFastRough.Location = New System.Drawing.Point(248, 430)
        Me.lblLLAFastRough.Name = "lblLLAFastRough"
        Me.lblLLAFastRough.Size = New System.Drawing.Size(30, 19)
        Me.lblLLAFastRough.TabIndex = 133
        Me.lblLLAFastRough.Text = "FR"
        '
        'lblLLAFastVent
        '
        Me.lblLLAFastVent.AutoSize = True
        Me.lblLLAFastVent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLAFastVent.ForeColor = System.Drawing.Color.White
        Me.lblLLAFastVent.Location = New System.Drawing.Point(95, 549)
        Me.lblLLAFastVent.Name = "lblLLAFastVent"
        Me.lblLLAFastVent.Size = New System.Drawing.Size(29, 19)
        Me.lblLLAFastVent.TabIndex = 134
        Me.lblLLAFastVent.Text = "FV"
        '
        'lblLLBFastVent
        '
        Me.lblLLBFastVent.AutoSize = True
        Me.lblLLBFastVent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLBFastVent.ForeColor = System.Drawing.Color.White
        Me.lblLLBFastVent.Location = New System.Drawing.Point(859, 536)
        Me.lblLLBFastVent.Name = "lblLLBFastVent"
        Me.lblLLBFastVent.Size = New System.Drawing.Size(29, 19)
        Me.lblLLBFastVent.TabIndex = 135
        Me.lblLLBFastVent.Text = "FV"
        '
        'lblLLBSlowRough
        '
        Me.lblLLBSlowRough.AutoSize = True
        Me.lblLLBSlowRough.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLBSlowRough.ForeColor = System.Drawing.Color.White
        Me.lblLLBSlowRough.Location = New System.Drawing.Point(721, 317)
        Me.lblLLBSlowRough.Name = "lblLLBSlowRough"
        Me.lblLLBSlowRough.Size = New System.Drawing.Size(30, 19)
        Me.lblLLBSlowRough.TabIndex = 136
        Me.lblLLBSlowRough.Text = "SR"
        '
        'lblLLASlowVent
        '
        Me.lblLLASlowVent.AutoSize = True
        Me.lblLLASlowVent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLASlowVent.ForeColor = System.Drawing.Color.White
        Me.lblLLASlowVent.Location = New System.Drawing.Point(95, 417)
        Me.lblLLASlowVent.Name = "lblLLASlowVent"
        Me.lblLLASlowVent.Size = New System.Drawing.Size(29, 19)
        Me.lblLLASlowVent.TabIndex = 137
        Me.lblLLASlowVent.Text = "SV"
        '
        'lblLLBSlowVent
        '
        Me.lblLLBSlowVent.AutoSize = True
        Me.lblLLBSlowVent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLBSlowVent.ForeColor = System.Drawing.Color.White
        Me.lblLLBSlowVent.Location = New System.Drawing.Point(859, 408)
        Me.lblLLBSlowVent.Name = "lblLLBSlowVent"
        Me.lblLLBSlowVent.Size = New System.Drawing.Size(29, 19)
        Me.lblLLBSlowVent.TabIndex = 138
        Me.lblLLBSlowVent.Text = "SV"
        '
        'lblLLASlowRough
        '
        Me.lblLLASlowRough.AutoSize = True
        Me.lblLLASlowRough.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLASlowRough.ForeColor = System.Drawing.Color.White
        Me.lblLLASlowRough.Location = New System.Drawing.Point(248, 317)
        Me.lblLLASlowRough.Name = "lblLLASlowRough"
        Me.lblLLASlowRough.Size = New System.Drawing.Size(30, 19)
        Me.lblLLASlowRough.TabIndex = 139
        Me.lblLLASlowRough.Text = "SR"
        '
        'cmsMechineTool
        '
        Me.cmsMechineTool.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsMechineTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMechineOnline, Me.mnuMechineOffline, Me.mnuMechinePumpDown, Me.mnuMechineStopPumpDown, Me.mnuMechineVent, Me.mnuMechineStopVent})
        Me.cmsMechineTool.Name = "cmsMechineTool"
        Me.cmsMechineTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsMechineTool.ShowImageMargin = False
        Me.cmsMechineTool.Size = New System.Drawing.Size(248, 196)
        '
        'mnuMechineOnline
        '
        Me.mnuMechineOnline.Name = "mnuMechineOnline"
        Me.mnuMechineOnline.Size = New System.Drawing.Size(247, 32)
        Me.mnuMechineOnline.Text = "Online"
        '
        'mnuMechineOffline
        '
        Me.mnuMechineOffline.Name = "mnuMechineOffline"
        Me.mnuMechineOffline.Size = New System.Drawing.Size(247, 32)
        Me.mnuMechineOffline.Text = "Offline"
        '
        'mnuMechinePumpDown
        '
        Me.mnuMechinePumpDown.Name = "mnuMechinePumpDown"
        Me.mnuMechinePumpDown.Size = New System.Drawing.Size(247, 32)
        Me.mnuMechinePumpDown.Text = "Pump Down"
        '
        'mnuMechineStopPumpDown
        '
        Me.mnuMechineStopPumpDown.Name = "mnuMechineStopPumpDown"
        Me.mnuMechineStopPumpDown.Size = New System.Drawing.Size(247, 32)
        Me.mnuMechineStopPumpDown.Text = "Stop Pump Down"
        '
        'mnuMechineVent
        '
        Me.mnuMechineVent.Name = "mnuMechineVent"
        Me.mnuMechineVent.Size = New System.Drawing.Size(247, 32)
        Me.mnuMechineVent.Text = "Vent"
        '
        'mnuMechineStopVent
        '
        Me.mnuMechineStopVent.Name = "mnuMechineStopVent"
        Me.mnuMechineStopVent.Size = New System.Drawing.Size(247, 32)
        Me.mnuMechineStopVent.Text = "Stop Vent"
        '
        'cmsLeftTool
        '
        Me.cmsLeftTool.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsLeftTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLeftOnline, Me.mnuLeftOffline, Me.mnuLeftPumpDown, Me.mnuLeftStopPumpDown, Me.mnuLeftVent, Me.mnuLeftStopVent})
        Me.cmsLeftTool.Name = "cmsLeftTool"
        Me.cmsLeftTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsLeftTool.ShowImageMargin = False
        Me.cmsLeftTool.Size = New System.Drawing.Size(248, 196)
        '
        'mnuLeftOnline
        '
        Me.mnuLeftOnline.Name = "mnuLeftOnline"
        Me.mnuLeftOnline.Size = New System.Drawing.Size(247, 32)
        Me.mnuLeftOnline.Text = "Online"
        '
        'mnuLeftOffline
        '
        Me.mnuLeftOffline.Name = "mnuLeftOffline"
        Me.mnuLeftOffline.Size = New System.Drawing.Size(247, 32)
        Me.mnuLeftOffline.Text = "Offline"
        '
        'mnuLeftPumpDown
        '
        Me.mnuLeftPumpDown.Name = "mnuLeftPumpDown"
        Me.mnuLeftPumpDown.Size = New System.Drawing.Size(247, 32)
        Me.mnuLeftPumpDown.Text = "Pump Down"
        '
        'mnuLeftStopPumpDown
        '
        Me.mnuLeftStopPumpDown.Name = "mnuLeftStopPumpDown"
        Me.mnuLeftStopPumpDown.Size = New System.Drawing.Size(247, 32)
        Me.mnuLeftStopPumpDown.Text = "Stop Pump Down"
        '
        'mnuLeftVent
        '
        Me.mnuLeftVent.Name = "mnuLeftVent"
        Me.mnuLeftVent.Size = New System.Drawing.Size(247, 32)
        Me.mnuLeftVent.Text = "Vent"
        '
        'mnuLeftStopVent
        '
        Me.mnuLeftStopVent.Name = "mnuLeftStopVent"
        Me.mnuLeftStopVent.Size = New System.Drawing.Size(247, 32)
        Me.mnuLeftStopVent.Text = "Stop Vent"
        '
        'cmsRightTool
        '
        Me.cmsRightTool.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsRightTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRightOnline, Me.mnuRightOffline, Me.mnuRightPumpDown, Me.mnuRightStopPumpDown, Me.mnuRightVent, Me.mnuRightStopVent})
        Me.cmsRightTool.Name = "cmsRightTool"
        Me.cmsRightTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsRightTool.ShowImageMargin = False
        Me.cmsRightTool.Size = New System.Drawing.Size(248, 196)
        '
        'mnuRightOnline
        '
        Me.mnuRightOnline.Name = "mnuRightOnline"
        Me.mnuRightOnline.Size = New System.Drawing.Size(247, 32)
        Me.mnuRightOnline.Text = "Online"
        '
        'mnuRightOffline
        '
        Me.mnuRightOffline.Name = "mnuRightOffline"
        Me.mnuRightOffline.Size = New System.Drawing.Size(247, 32)
        Me.mnuRightOffline.Text = "Offline"
        '
        'mnuRightPumpDown
        '
        Me.mnuRightPumpDown.Name = "mnuRightPumpDown"
        Me.mnuRightPumpDown.Size = New System.Drawing.Size(247, 32)
        Me.mnuRightPumpDown.Text = "Pump Down"
        '
        'mnuRightStopPumpDown
        '
        Me.mnuRightStopPumpDown.Name = "mnuRightStopPumpDown"
        Me.mnuRightStopPumpDown.Size = New System.Drawing.Size(247, 32)
        Me.mnuRightStopPumpDown.Text = "Stop Pump Down"
        '
        'mnuRightVent
        '
        Me.mnuRightVent.Name = "mnuRightVent"
        Me.mnuRightVent.Size = New System.Drawing.Size(247, 32)
        Me.mnuRightVent.Text = "Vent"
        '
        'mnuRightStopVent
        '
        Me.mnuRightStopVent.Name = "mnuRightStopVent"
        Me.mnuRightStopVent.Size = New System.Drawing.Size(247, 32)
        Me.mnuRightStopVent.Text = "Stop Vent"
        '
        'clearStatusTimer
        '
        Me.clearStatusTimer.Interval = 1000
        '
        'lblRoughPumpInUse
        '
        Me.lblRoughPumpInUse.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoughPumpInUse.ForeColor = System.Drawing.Color.White
        Me.lblRoughPumpInUse.Location = New System.Drawing.Point(966, 660)
        Me.lblRoughPumpInUse.Name = "lblRoughPumpInUse"
        Me.lblRoughPumpInUse.Size = New System.Drawing.Size(169, 55)
        Me.lblRoughPumpInUse.TabIndex = 157
        '
        'LLAIgStatus
        '
        Me.LLAIgStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LLAIgStatus.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.LLAIgStatus.ColorText_OffStatus = System.Drawing.Color.White
        Me.LLAIgStatus.ColorText_OnStatus = System.Drawing.Color.Black
        Me.LLAIgStatus.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.LLAIgStatus.ErrorImage = Nothing
        Me.LLAIgStatus.ErrorText = ""
        Me.LLAIgStatus.FlatAppearance.BorderSize = 0
        Me.LLAIgStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LLAIgStatus.ForeColor = System.Drawing.Color.White
        Me.LLAIgStatus.Location = New System.Drawing.Point(1014, 453)
        Me.LLAIgStatus.Name = "LLAIgStatus"
        Me.LLAIgStatus.OffImage = Nothing
        Me.LLAIgStatus.OffText = ""
        Me.LLAIgStatus.OnImage = Nothing
        Me.LLAIgStatus.OnText = ""
        Me.LLAIgStatus.Size = New System.Drawing.Size(61, 38)
        Me.LLAIgStatus.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.LLAIgStatus.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.LLAIgStatus.TabIndex = 242
        Me.LLAIgStatus.Text = "ButtonIGCGControl1"
        Me.LLAIgStatus.UnknownImage = Nothing
        Me.LLAIgStatus.UnKnownText = ""
        Me.LLAIgStatus.UseVisualStyleBackColor = True
        Me.LLAIgStatus.Visible = False
        '
        'LLBIgStatus
        '
        Me.LLBIgStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LLBIgStatus.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.LLBIgStatus.ColorText_OffStatus = System.Drawing.Color.White
        Me.LLBIgStatus.ColorText_OnStatus = System.Drawing.Color.Black
        Me.LLBIgStatus.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.LLBIgStatus.ErrorImage = Nothing
        Me.LLBIgStatus.ErrorText = ""
        Me.LLBIgStatus.FlatAppearance.BorderSize = 0
        Me.LLBIgStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LLBIgStatus.ForeColor = System.Drawing.Color.White
        Me.LLBIgStatus.Location = New System.Drawing.Point(1070, 448)
        Me.LLBIgStatus.Name = "LLBIgStatus"
        Me.LLBIgStatus.OffImage = Nothing
        Me.LLBIgStatus.OffText = ""
        Me.LLBIgStatus.OnImage = Nothing
        Me.LLBIgStatus.OnText = ""
        Me.LLBIgStatus.Size = New System.Drawing.Size(61, 38)
        Me.LLBIgStatus.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.LLBIgStatus.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.LLBIgStatus.TabIndex = 243
        Me.LLBIgStatus.Text = "ButtonIGCGControl1"
        Me.LLBIgStatus.UnknownImage = Nothing
        Me.LLBIgStatus.UnKnownText = ""
        Me.LLBIgStatus.UseVisualStyleBackColor = True
        Me.LLBIgStatus.Visible = False
        '
        'tabGroup
        '
        Me.tabGroup.Controls.Add(Me.tabCycleWafer)
        Me.tabGroup.Controls.Add(Me.tabSerialCommand)
        Me.tabGroup.Controls.Add(Me.tabCycle)
        Me.tabGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabGroup.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabGroup.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabGroup.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlText
        Me.tabGroup.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabGroup.DisplayStyleProvider.FocusTrack = False
        Me.tabGroup.DisplayStyleProvider.HotTrack = True
        Me.tabGroup.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabGroup.DisplayStyleProvider.Opacity = 1.0!
        Me.tabGroup.DisplayStyleProvider.Overlap = 0
        Me.tabGroup.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabGroup.DisplayStyleProvider.Radius = 10
        Me.tabGroup.DisplayStyleProvider.ShowTabCloser = False
        Me.tabGroup.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabGroup.HotTrack = True
        Me.tabGroup.Location = New System.Drawing.Point(779, 15)
        Me.tabGroup.Name = "tabGroup"
        Me.tabGroup.SelectedIndex = 0
        Me.tabGroup.Size = New System.Drawing.Size(495, 217)
        Me.tabGroup.TabIndex = 162
        '
        'tabCycleWafer
        '
        Me.tabCycleWafer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabCycleWafer.Controls.Add(Me.atwAutoTransferWafer)
        Me.tabCycleWafer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCycleWafer.Location = New System.Drawing.Point(4, 29)
        Me.tabCycleWafer.Name = "tabCycleWafer"
        Me.tabCycleWafer.Size = New System.Drawing.Size(487, 184)
        Me.tabCycleWafer.TabIndex = 1
        Me.tabCycleWafer.Text = "ROBOT "
        Me.tabCycleWafer.UseVisualStyleBackColor = True
        '
        'atwAutoTransferWafer
        '
        Me.atwAutoTransferWafer.BackColor = System.Drawing.Color.Transparent
        Me.atwAutoTransferWafer.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.atwAutoTransferWafer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.atwAutoTransferWafer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.atwAutoTransferWafer.Enabled = False
        Me.atwAutoTransferWafer.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.atwAutoTransferWafer.HeaderHeight = 28
        Me.atwAutoTransferWafer.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.atwAutoTransferWafer.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.atwAutoTransferWafer.HeaderTextColor = System.Drawing.Color.Black
        Me.atwAutoTransferWafer.HeaderVisible = False
        Me.atwAutoTransferWafer.Headerwidth = 60
        Me.atwAutoTransferWafer.IsOnline = False
        Me.atwAutoTransferWafer.Location = New System.Drawing.Point(0, 0)
        Me.atwAutoTransferWafer.Name = "atwAutoTransferWafer"
        Me.atwAutoTransferWafer.Size = New System.Drawing.Size(485, 182)
        Me.atwAutoTransferWafer.TabIndex = 17
        Me.atwAutoTransferWafer.Text = "CYCLE WAFER"
        '
        'tabSerialCommand
        '
        Me.tabSerialCommand.Controls.Add(Me.sccSerialCommand)
        Me.tabSerialCommand.Location = New System.Drawing.Point(4, 29)
        Me.tabSerialCommand.Name = "tabSerialCommand"
        Me.tabSerialCommand.Size = New System.Drawing.Size(487, 184)
        Me.tabSerialCommand.TabIndex = 2
        Me.tabSerialCommand.Text = "SERIAL COMMAND"
        Me.tabSerialCommand.UseVisualStyleBackColor = True
        '
        'sccSerialCommand
        '
        Me.sccSerialCommand.BackColor = System.Drawing.Color.Transparent
        Me.sccSerialCommand.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.sccSerialCommand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.sccSerialCommand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sccSerialCommand.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sccSerialCommand.HeaderHeight = 28
        Me.sccSerialCommand.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.sccSerialCommand.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.sccSerialCommand.HeaderTextColor = System.Drawing.Color.Black
        Me.sccSerialCommand.HeaderVisible = False
        Me.sccSerialCommand.Headerwidth = 60
        Me.sccSerialCommand.IsOnline = False
        Me.sccSerialCommand.Location = New System.Drawing.Point(0, 0)
        Me.sccSerialCommand.Name = "sccSerialCommand"
        Me.sccSerialCommand.Size = New System.Drawing.Size(487, 184)
        Me.sccSerialCommand.TabIndex = 19
        Me.sccSerialCommand.Text = "SERIAL COMMAND"
        '
        'tabCycle
        '
        Me.tabCycle.Controls.Add(Me.ctwcCycleWafer)
        Me.tabCycle.Location = New System.Drawing.Point(4, 29)
        Me.tabCycle.Name = "tabCycle"
        Me.tabCycle.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCycle.Size = New System.Drawing.Size(487, 184)
        Me.tabCycle.TabIndex = 3
        Me.tabCycle.Text = "CYCLE"
        Me.tabCycle.UseVisualStyleBackColor = True
        '
        'ctwcCycleWafer
        '
        Me.ctwcCycleWafer.BackColor = System.Drawing.Color.Transparent
        Me.ctwcCycleWafer.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.ctwcCycleWafer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ctwcCycleWafer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctwcCycleWafer.HeaderHeight = 28
        Me.ctwcCycleWafer.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.ctwcCycleWafer.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.ctwcCycleWafer.HeaderTextColor = System.Drawing.Color.Black
        Me.ctwcCycleWafer.HeaderVisible = False
        Me.ctwcCycleWafer.Headerwidth = 60
        Me.ctwcCycleWafer.IsOnline = False
        Me.ctwcCycleWafer.Location = New System.Drawing.Point(3, 3)
        Me.ctwcCycleWafer.Name = "ctwcCycleWafer"
        Me.ctwcCycleWafer.Size = New System.Drawing.Size(481, 178)
        Me.ctwcCycleWafer.TabIndex = 0
        Me.ctwcCycleWafer.Text = "CycleTransferWaferControl1"
        'lblTMNameOfSequenceRunning
        '
        Me.lblTMNameOfSequenceRunning.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblTMNameOfSequenceRunning.ForeColor = System.Drawing.Color.Red
        Me.lblTMNameOfSequenceRunning.Location = New System.Drawing.Point(1020, 449)
        Me.lblTMNameOfSequenceRunning.Name = "lblTMNameOfSequenceRunning"
        Me.lblTMNameOfSequenceRunning.Size = New System.Drawing.Size(266, 33)
        Me.lblTMNameOfSequenceRunning.TabIndex = 245
        '
        'lblLLANameOfSequenceRunning
        '
        Me.lblLLANameOfSequenceRunning.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblLLANameOfSequenceRunning.ForeColor = System.Drawing.Color.Red
        Me.lblLLANameOfSequenceRunning.Location = New System.Drawing.Point(1020, 493)
        Me.lblLLANameOfSequenceRunning.Name = "lblLLANameOfSequenceRunning"
        Me.lblLLANameOfSequenceRunning.Size = New System.Drawing.Size(266, 33)
        Me.lblLLANameOfSequenceRunning.TabIndex = 245
        '
        'lblLLBNameOfSequenceRunning
        '
        Me.lblLLBNameOfSequenceRunning.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblLLBNameOfSequenceRunning.ForeColor = System.Drawing.Color.Red
        Me.lblLLBNameOfSequenceRunning.Location = New System.Drawing.Point(1020, 537)
        Me.lblLLBNameOfSequenceRunning.Name = "lblLLBNameOfSequenceRunning"
        Me.lblLLBNameOfSequenceRunning.Size = New System.Drawing.Size(266, 33)
        Me.lblLLBNameOfSequenceRunning.TabIndex = 245
        '
        'lblFlashing
        '
        Me.lblFlashing.Color1 = System.Drawing.Color.Yellow
        Me.lblFlashing.Color2 = System.Drawing.Color.Yellow
        Me.lblFlashing.FlashingInterval = 2000
        Me.lblFlashing.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlashing.ForeColor = System.Drawing.Color.Yellow
        Me.lblFlashing.Location = New System.Drawing.Point(1020, 324)
        Me.lblFlashing.Name = "lblFlashing"
        Me.lblFlashing.Size = New System.Drawing.Size(247, 74)
        Me.lblFlashing.TabIndex = 246
        Me.lblFlashing.Text = "Flashing Label"
        Me.lblFlashing.Visible = False
        '
        'lblPump1
        '
        Me.lblPump1.AutoSize = True
        Me.lblPump1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPump1.ForeColor = System.Drawing.Color.White
        Me.lblPump1.Location = New System.Drawing.Point(979, 605)
        Me.lblPump1.Name = "lblPump1"
        Me.lblPump1.Size = New System.Drawing.Size(88, 19)
        Me.lblPump1.TabIndex = 266
        Me.lblPump1.Text = "TM's Pump"
        '
        'lblPump2
        '
        Me.lblPump2.AutoSize = True
        Me.lblPump2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPump2.ForeColor = Color.FromArgb(0, 255, 0)
        Me.lblPump2.Location = New System.Drawing.Point(1152, 622)
        Me.lblPump2.Name = "lblPump2"
        Me.lblPump2.Size = New System.Drawing.Size(88, 19)
        Me.lblPump2.TabIndex = 267
        Me.lblPump2.Text = "LL's Pump"
        '
        'lblRoughLineLLB
        '
        Me.lblRoughLineLLB.AutoSize = True
        Me.lblRoughLineLLB.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoughLineLLB.ForeColor = System.Drawing.Color.White
        Me.lblRoughLineLLB.Location = New System.Drawing.Point(906, 310)
        Me.lblRoughLineLLB.Name = "lblRoughLineLLB"
        Me.lblRoughLineLLB.Size = New System.Drawing.Size(88, 19)
        Me.lblRoughLineLLB.TabIndex = 268
        Me.lblRoughLineLLB.Text = "TM's Pump"
        '
        'lblRoughLineLLA
        '
        Me.lblRoughLineLLA.AutoSize = True
        Me.lblRoughLineLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoughLineLLA.ForeColor = System.Drawing.Color.White
        Me.lblRoughLineLLA.Location = New System.Drawing.Point(30, 310)
        Me.lblRoughLineLLA.Name = "lblRoughLineLLA"
        Me.lblRoughLineLLA.Size = New System.Drawing.Size(66, 19)
        Me.lblRoughLineLLA.TabIndex = 269
        Me.lblRoughLineLLA.Text = "TM's Pump"
        '
        'lblRoughLineTM
        '
        Me.lblRoughLineTM.AutoSize = True
        Me.lblRoughLineTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoughLineTM.ForeColor = System.Drawing.Color.White
        Me.lblRoughLineTM.Location = New System.Drawing.Point(696, 58)
        Me.lblRoughLineTM.Name = "lblRoughLineTM"
        Me.lblRoughLineTM.Size = New System.Drawing.Size(66, 19)
        Me.lblRoughLineTM.TabIndex = 270
        Me.lblRoughLineTM.Text = "LL's Pump"
        '
        'lblVentLineLLA
        '
        Me.lblVentLineLLA.AutoSize = True
        Me.lblVentLineLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentLineLLA.ForeColor = System.Drawing.Color.White
        Me.lblVentLineLLA.Location = New System.Drawing.Point(3, 489)
        Me.lblVentLineLLA.Name = "lblVentLineLLA"
        Me.lblVentLineLLA.Size = New System.Drawing.Size(29, 19)
        Me.lblVentLineLLA.TabIndex = 272
        Me.lblVentLineLLA.Text = "N2"
        '
        'lblVentLineLLB
        '
        Me.lblVentLineLLB.AutoSize = True
        Me.lblVentLineLLB.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentLineLLB.ForeColor = System.Drawing.Color.White
        Me.lblVentLineLLB.Location = New System.Drawing.Point(991, 487)
        Me.lblVentLineLLB.Name = "lblVentLineLLB"
        Me.lblVentLineLLB.Size = New System.Drawing.Size(29, 19)
        Me.lblVentLineLLB.TabIndex = 273
        Me.lblVentLineLLB.Text = "N2"
        '
        'lblVentLineTM
        '
        Me.lblVentLineTM.AutoSize = True
        Me.lblVentLineTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentLineTM.ForeColor = System.Drawing.Color.White
        Me.lblVentLineTM.Location = New System.Drawing.Point(234, 123)
        Me.lblVentLineTM.Name = "lblVentLineTM"
        Me.lblVentLineTM.Size = New System.Drawing.Size(29, 19)
        Me.lblVentLineTM.TabIndex = 274
        Me.lblVentLineTM.Text = "N2"
        '
        'lblRoughPumpInUse_2
        '
        Me.lblRoughPumpInUse_2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoughPumpInUse_2.ForeColor = System.Drawing.Color.White
        Me.lblRoughPumpInUse_2.Location = New System.Drawing.Point(913, 513)
        Me.lblRoughPumpInUse_2.Name = "lblRoughPumpInUse_2"
        Me.lblRoughPumpInUse_2.Size = New System.Drawing.Size(169, 55)
        Me.lblRoughPumpInUse_2.TabIndex = 275
        '
        'txtTurboIGTM
        '
        Me.txtTurboIGTM.BackColor = System.Drawing.SystemColors.Control
        Me.txtTurboIGTM.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtTurboIGTM.Location = New System.Drawing.Point(688, 169)
        Me.txtTurboIGTM.Name = "txtTurboIGTM"
        Me.txtTurboIGTM.ReadOnly = True
        Me.txtTurboIGTM.Size = New System.Drawing.Size(75, 26)
        Me.txtTurboIGTM.TabIndex = 276
        Me.txtTurboIGTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTurboIGLLB
        '
        Me.txtTurboIGLLB.BackColor = System.Drawing.SystemColors.Control
        Me.txtTurboIGLLB.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtTurboIGLLB.Location = New System.Drawing.Point(646, 366)
        Me.txtTurboIGLLB.Name = "txtTurboIGLLB"
        Me.txtTurboIGLLB.ReadOnly = True
        Me.txtTurboIGLLB.Size = New System.Drawing.Size(75, 26)
        Me.txtTurboIGLLB.TabIndex = 277
        Me.txtTurboIGLLB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTurboIGLLA
        '
        Me.txtTurboIGLLA.BackColor = System.Drawing.SystemColors.Control
        Me.txtTurboIGLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtTurboIGLLA.Location = New System.Drawing.Point(308, 366)
        Me.txtTurboIGLLA.Name = "txtTurboIGLLA"
        Me.txtTurboIGLLA.ReadOnly = True
        Me.txtTurboIGLLA.Size = New System.Drawing.Size(75, 26)
        Me.txtTurboIGLLA.TabIndex = 278
        Me.txtTurboIGLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRoughLineTM
        '
        Me.txtRoughLineTM.BackColor = System.Drawing.SystemColors.Control
        Me.txtRoughLineTM.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtRoughLineTM.Location = New System.Drawing.Point(705, 83)
        Me.txtRoughLineTM.Name = "txtRoughLineTM"
        Me.txtRoughLineTM.ReadOnly = True
        Me.txtRoughLineTM.Size = New System.Drawing.Size(75, 26)
        Me.txtRoughLineTM.TabIndex = 279
        Me.txtRoughLineTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRoughLineLLB
        '
        Me.txtRoughLineLLB.BackColor = System.Drawing.SystemColors.Control
        Me.txtRoughLineLLB.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtRoughLineLLB.Location = New System.Drawing.Point(913, 334)
        Me.txtRoughLineLLB.Name = "txtRoughLineLLB"
        Me.txtRoughLineLLB.ReadOnly = True
        Me.txtRoughLineLLB.Size = New System.Drawing.Size(75, 26)
        Me.txtRoughLineLLB.TabIndex = 280
        Me.txtRoughLineLLB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRoughLineLLA
        '
        Me.txtRoughLineLLA.BackColor = System.Drawing.SystemColors.Control
        Me.txtRoughLineLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtRoughLineLLA.Location = New System.Drawing.Point(37, 334)
        Me.txtRoughLineLLA.Name = "txtRoughLineLLA"
        Me.txtRoughLineLLA.ReadOnly = True
        Me.txtRoughLineLLA.Size = New System.Drawing.Size(75, 26)
        Me.txtRoughLineLLA.TabIndex = 281
        Me.txtRoughLineLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTurboForlineLLA
        '
        Me.lblTurboForlineLLA.AutoSize = True
        Me.lblTurboForlineLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboForlineLLA.ForeColor = System.Drawing.Color.White
        Me.lblTurboForlineLLA.Location = New System.Drawing.Point(145, 394)
        Me.lblTurboForlineLLA.Name = "lblTurboForlineLLA"
        Me.lblTurboForlineLLA.Size = New System.Drawing.Size(28, 19)
        Me.lblTurboForlineLLA.TabIndex = 139
        Me.lblTurboForlineLLA.Text = "FL"
        '
        'lblTurboForlineLLB
        '
        Me.lblTurboForlineLLB.AutoSize = True
        Me.lblTurboForlineLLB.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboForlineLLB.ForeColor = System.Drawing.Color.White
        Me.lblTurboForlineLLB.Location = New System.Drawing.Point(181, 424)
        Me.lblTurboForlineLLB.Name = "lblTurboForlineLLB"
        Me.lblTurboForlineLLB.Size = New System.Drawing.Size(28, 19)
        Me.lblTurboForlineLLB.TabIndex = 139
        Me.lblTurboForlineLLB.Text = "FL"
        '
        'lblTurboForlineTM
        '
        Me.lblTurboForlineTM.AutoSize = True
        Me.lblTurboForlineTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboForlineTM.ForeColor = System.Drawing.Color.White
        Me.lblTurboForlineTM.Location = New System.Drawing.Point(662, 103)
        Me.lblTurboForlineTM.Name = "lblTurboForlineTM"
        Me.lblTurboForlineTM.Size = New System.Drawing.Size(28, 19)
        Me.lblTurboForlineTM.TabIndex = 139
        Me.lblTurboForlineTM.Text = "FL"
        '
        'lblComunicationLED_TurboLLA
        '
        Me.lblComunicationLED_TurboLLA.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED_TurboLLA.Location = New System.Drawing.Point(238, 461)
        Me.lblComunicationLED_TurboLLA.Name = "lblComunicationLED_TurboLLA"
        Me.lblComunicationLED_TurboLLA.Size = New System.Drawing.Size(8, 12)
        Me.lblComunicationLED_TurboLLA.TabIndex = 284
        '
        'lblComunicationLED_TurboLLB
        '
        Me.lblComunicationLED_TurboLLB.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED_TurboLLB.Location = New System.Drawing.Point(701, 461)
        Me.lblComunicationLED_TurboLLB.Name = "lblComunicationLED_TurboLLB"
        Me.lblComunicationLED_TurboLLB.Size = New System.Drawing.Size(8, 12)
        Me.lblComunicationLED_TurboLLB.TabIndex = 284
        '
        'btnTurboRelayIndicator_LLA
        '
        Me.btnTurboRelayIndicator_LLA.AccessibleName = "TurboLLA"
        Me.btnTurboRelayIndicator_LLA.BackColor = System.Drawing.Color.Transparent
        Me.btnTurboRelayIndicator_LLA.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnTurboRelayIndicator_LLA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboRelayIndicator_LLA.Clickable = True
        Me.btnTurboRelayIndicator_LLA.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_LLA.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnTurboRelayIndicator_LLA.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_LLA.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_LLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurboRelayIndicator_LLA.DenyKeyEnter = False
        Me.btnTurboRelayIndicator_LLA.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnTurboRelayIndicator_LLA.ErrorText = ""
        Me.btnTurboRelayIndicator_LLA.FlatAppearance.BorderSize = 0
        Me.btnTurboRelayIndicator_LLA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboRelayIndicator_LLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurboRelayIndicator_LLA.ForeColor = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_LLA.Location = New System.Drawing.Point(369, 353)
        Me.btnTurboRelayIndicator_LLA.Name = "btnTurboRelayIndicator_LLA"
        Me.btnTurboRelayIndicator_LLA.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnTurboRelayIndicator_LLA.OffText = ""
        Me.btnTurboRelayIndicator_LLA.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnTurboRelayIndicator_LLA.OnText = ""
        Me.btnTurboRelayIndicator_LLA.Size = New System.Drawing.Size(10, 10)
        Me.btnTurboRelayIndicator_LLA.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[Off]
        Me.btnTurboRelayIndicator_LLA.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnTurboRelayIndicator_LLA.TabIndex = 285
        Me.btnTurboRelayIndicator_LLA.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnTurboRelayIndicator_LLA.UnKnownText = ""
        Me.btnTurboRelayIndicator_LLA.UseClickedEventInForm = True
        Me.btnTurboRelayIndicator_LLA.UseVisualStyleBackColor = False
        Me.btnTurboRelayIndicator_LLA.ValueToBeSend = ""
        '
        'btnTurboRelayIndicator_TM
        '
        Me.btnTurboRelayIndicator_TM.AccessibleName = "TurboLLA"
        Me.btnTurboRelayIndicator_TM.BackColor = System.Drawing.Color.Transparent
        Me.btnTurboRelayIndicator_TM.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnTurboRelayIndicator_TM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboRelayIndicator_TM.Clickable = True
        Me.btnTurboRelayIndicator_TM.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_TM.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnTurboRelayIndicator_TM.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_TM.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_TM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurboRelayIndicator_TM.DenyKeyEnter = False
        Me.btnTurboRelayIndicator_TM.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnTurboRelayIndicator_TM.ErrorText = ""
        Me.btnTurboRelayIndicator_TM.FlatAppearance.BorderSize = 0
        Me.btnTurboRelayIndicator_TM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboRelayIndicator_TM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurboRelayIndicator_TM.ForeColor = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_TM.Location = New System.Drawing.Point(746, 156)
        Me.btnTurboRelayIndicator_TM.Name = "btnTurboRelayIndicator_TM"
        Me.btnTurboRelayIndicator_TM.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnTurboRelayIndicator_TM.OffText = ""
        Me.btnTurboRelayIndicator_TM.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnTurboRelayIndicator_TM.OnText = ""
        Me.btnTurboRelayIndicator_TM.Size = New System.Drawing.Size(10, 10)
        Me.btnTurboRelayIndicator_TM.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[Off]
        Me.btnTurboRelayIndicator_TM.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnTurboRelayIndicator_TM.TabIndex = 285
        Me.btnTurboRelayIndicator_TM.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnTurboRelayIndicator_TM.UnKnownText = ""
        Me.btnTurboRelayIndicator_TM.UseClickedEventInForm = True
        Me.btnTurboRelayIndicator_TM.UseVisualStyleBackColor = False
        Me.btnTurboRelayIndicator_TM.ValueToBeSend = ""
        '
        'btnTurboRelayIndicator_LLB
        '
        Me.btnTurboRelayIndicator_LLB.AccessibleName = "TurboLLA"
        Me.btnTurboRelayIndicator_LLB.BackColor = System.Drawing.Color.Transparent
        Me.btnTurboRelayIndicator_LLB.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnTurboRelayIndicator_LLB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboRelayIndicator_LLB.Clickable = True
        Me.btnTurboRelayIndicator_LLB.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_LLB.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnTurboRelayIndicator_LLB.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_LLB.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_LLB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurboRelayIndicator_LLB.DenyKeyEnter = False
        Me.btnTurboRelayIndicator_LLB.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnTurboRelayIndicator_LLB.ErrorText = ""
        Me.btnTurboRelayIndicator_LLB.FlatAppearance.BorderSize = 0
        Me.btnTurboRelayIndicator_LLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboRelayIndicator_LLB.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurboRelayIndicator_LLB.ForeColor = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_LLB.Location = New System.Drawing.Point(707, 353)
        Me.btnTurboRelayIndicator_LLB.Name = "btnTurboRelayIndicator_LLB"
        Me.btnTurboRelayIndicator_LLB.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnTurboRelayIndicator_LLB.OffText = ""
        Me.btnTurboRelayIndicator_LLB.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnTurboRelayIndicator_LLB.OnText = ""
        Me.btnTurboRelayIndicator_LLB.Size = New System.Drawing.Size(10, 10)
        Me.btnTurboRelayIndicator_LLB.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[Off]
        Me.btnTurboRelayIndicator_LLB.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnTurboRelayIndicator_LLB.TabIndex = 285
        Me.btnTurboRelayIndicator_LLB.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnTurboRelayIndicator_LLB.UnKnownText = ""
        Me.btnTurboRelayIndicator_LLB.UseClickedEventInForm = True
        Me.btnTurboRelayIndicator_LLB.UseVisualStyleBackColor = False
        Me.btnTurboRelayIndicator_LLB.ValueToBeSend = ""
        '
        'btnRelayIndicatorPump2
        '
        Me.btnRelayIndicatorPump2.AccessibleName = "TurboLLA"
        Me.btnRelayIndicatorPump2.BackColor = System.Drawing.Color.Transparent
        Me.btnRelayIndicatorPump2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnRelayIndicatorPump2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRelayIndicatorPump2.Clickable = True
        Me.btnRelayIndicatorPump2.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump2.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnRelayIndicatorPump2.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump2.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRelayIndicatorPump2.DenyKeyEnter = False
        Me.btnRelayIndicatorPump2.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnRelayIndicatorPump2.ErrorText = ""
        Me.btnRelayIndicatorPump2.FlatAppearance.BorderSize = 0
        Me.btnRelayIndicatorPump2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelayIndicatorPump2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelayIndicatorPump2.ForeColor = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump2.Location = New System.Drawing.Point(1224, 608)
        Me.btnRelayIndicatorPump2.Name = "btnRelayIndicatorPump2"
        Me.btnRelayIndicatorPump2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnRelayIndicatorPump2.OffText = ""
        Me.btnRelayIndicatorPump2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnRelayIndicatorPump2.OnText = ""
        Me.btnRelayIndicatorPump2.Size = New System.Drawing.Size(10, 10)
        Me.btnRelayIndicatorPump2.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[Off]
        Me.btnRelayIndicatorPump2.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnRelayIndicatorPump2.TabIndex = 283
        Me.btnRelayIndicatorPump2.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnRelayIndicatorPump2.UnKnownText = ""
        Me.btnRelayIndicatorPump2.UseClickedEventInForm = True
        Me.btnRelayIndicatorPump2.UseVisualStyleBackColor = False
        Me.btnRelayIndicatorPump2.ValueToBeSend = ""
        '
        'btnRelayIndicatorPump1
        '
        Me.btnRelayIndicatorPump1.AccessibleName = "TurboLLA"
        Me.btnRelayIndicatorPump1.BackColor = System.Drawing.Color.Transparent
        Me.btnRelayIndicatorPump1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnRelayIndicatorPump1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRelayIndicatorPump1.Clickable = True
        Me.btnRelayIndicatorPump1.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump1.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnRelayIndicatorPump1.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump1.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRelayIndicatorPump1.DenyKeyEnter = False
        Me.btnRelayIndicatorPump1.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnRelayIndicatorPump1.ErrorText = ""
        Me.btnRelayIndicatorPump1.FlatAppearance.BorderSize = 0
        Me.btnRelayIndicatorPump1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelayIndicatorPump1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelayIndicatorPump1.ForeColor = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump1.Location = New System.Drawing.Point(1083, 608)
        Me.btnRelayIndicatorPump1.Name = "btnRelayIndicatorPump1"
        Me.btnRelayIndicatorPump1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnRelayIndicatorPump1.OffText = ""
        Me.btnRelayIndicatorPump1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnRelayIndicatorPump1.OnText = ""
        Me.btnRelayIndicatorPump1.Size = New System.Drawing.Size(10, 10)
        Me.btnRelayIndicatorPump1.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[Off]
        Me.btnRelayIndicatorPump1.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnRelayIndicatorPump1.TabIndex = 283
        Me.btnRelayIndicatorPump1.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnRelayIndicatorPump1.UnKnownText = ""
        Me.btnRelayIndicatorPump1.UseClickedEventInForm = True
        Me.btnRelayIndicatorPump1.UseVisualStyleBackColor = False
        Me.btnRelayIndicatorPump1.ValueToBeSend = ""
        '
        'GasRoughLine
        '
        Me.GasRoughLine.Enabled = False
        Me.GasRoughLine.Image = Global.AVP_Robot_Project.My.Resources.Resources.MainModule
        Me.GasRoughLine.ImageSize = New System.Drawing.Size(1000, 374)
        Me.GasRoughLine.IsChamberPic = False
        Me.GasRoughLine.IsStretch = True
        Me.GasRoughLine.Location = New System.Drawing.Point(572, 63)
        Me.GasRoughLine.Name = "GasRoughLine"
        Me.GasRoughLine.Size = New System.Drawing.Size(178, 130)
        Me.GasRoughLine.TabIndex = 282
        Me.GasRoughLine.TextColor = System.Drawing.Color.Wheat
        Me.GasRoughLine.TextInImage = ""
        Me.GasRoughLine.TextLocation = New System.Drawing.Point(0, 0)
        '
        'btnTurboTM
        '
        Me.btnTurboTM.AccessibleName = "TurboTM"
        Me.btnTurboTM.BackColor = System.Drawing.Color.Transparent
        Me.btnTurboTM.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnTurboTM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboTM.Clickable = True
        Me.btnTurboTM.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurboTM.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnTurboTM.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnTurboTM.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnTurboTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurboTM.DenyKeyEnter = False
        Me.btnTurboTM.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnTurboTM.ErrorText = ""
        Me.btnTurboTM.FlatAppearance.BorderSize = 0
        Me.btnTurboTM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboTM.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurboTM.ForeColor = System.Drawing.Color.White
        Me.btnTurboTM.Location = New System.Drawing.Point(634, 292)
        Me.btnTurboTM.Name = "btnTurboTM"
        Me.btnTurboTM.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnTurboTM.OffText = "OFF"
        Me.btnTurboTM.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower
        Me.btnTurboTM.OnText = "ON"
        Me.btnTurboTM.Size = New System.Drawing.Size(48, 26)
        Me.btnTurboTM.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnTurboTM.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnTurboTM.TabIndex = 257
        Me.btnTurboTM.Text = "OFF"
        Me.btnTurboTM.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.ButtonYellow
        Me.btnTurboTM.UnKnownText = ""
        Me.btnTurboTM.UseClickedEventInForm = True
        Me.btnTurboTM.UseVisualStyleBackColor = False
        Me.btnTurboTM.ValueToBeSend = ""
        '
        'btnTurboLLB
        '
        Me.btnTurboLLB.AccessibleName = "TurboLLB"
        Me.btnTurboLLB.BackColor = System.Drawing.Color.Transparent
        Me.btnTurboLLB.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnTurboLLB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboLLB.Clickable = True
        Me.btnTurboLLB.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurboLLB.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnTurboLLB.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnTurboLLB.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnTurboLLB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurboLLB.DenyKeyEnter = False
        Me.btnTurboLLB.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnTurboLLB.ErrorText = ""
        Me.btnTurboLLB.FlatAppearance.BorderSize = 0
        Me.btnTurboLLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboLLB.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurboLLB.ForeColor = System.Drawing.Color.White
        Me.btnTurboLLB.Location = New System.Drawing.Point(711, 269)
        Me.btnTurboLLB.Name = "btnTurboLLB"
        Me.btnTurboLLB.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnTurboLLB.OffText = "OFF"
        Me.btnTurboLLB.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower
        Me.btnTurboLLB.OnText = "ON"
        Me.btnTurboLLB.Size = New System.Drawing.Size(50, 26)
        Me.btnTurboLLB.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnTurboLLB.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnTurboLLB.TabIndex = 256
        Me.btnTurboLLB.Text = "OFF"
        Me.btnTurboLLB.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.ButtonYellow
        Me.btnTurboLLB.UnKnownText = ""
        Me.btnTurboLLB.UseClickedEventInForm = True
        Me.btnTurboLLB.UseVisualStyleBackColor = False
        Me.btnTurboLLB.ValueToBeSend = ""
        '
        'btnTurboLLA
        '
        Me.btnTurboLLA.AccessibleName = "TurboLLA"
        Me.btnTurboLLA.BackColor = System.Drawing.Color.Transparent
        Me.btnTurboLLA.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnTurboLLA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboLLA.Clickable = True
        Me.btnTurboLLA.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurboLLA.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnTurboLLA.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnTurboLLA.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnTurboLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurboLLA.DenyKeyEnter = False
        Me.btnTurboLLA.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnTurboLLA.ErrorText = ""
        Me.btnTurboLLA.FlatAppearance.BorderSize = 0
        Me.btnTurboLLA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboLLA.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurboLLA.ForeColor = System.Drawing.Color.White
        Me.btnTurboLLA.Location = New System.Drawing.Point(650, 248)
        Me.btnTurboLLA.Name = "btnTurboLLA"
        Me.btnTurboLLA.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnTurboLLA.OffText = "OFF"
        Me.btnTurboLLA.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower
        Me.btnTurboLLA.OnText = "ON"
        Me.btnTurboLLA.Size = New System.Drawing.Size(50, 26)
        Me.btnTurboLLA.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnTurboLLA.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnTurboLLA.TabIndex = 255
        Me.btnTurboLLA.Text = "OFF"
        Me.btnTurboLLA.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.ButtonYellow
        Me.btnTurboLLA.UnKnownText = ""
        Me.btnTurboLLA.UseClickedEventInForm = True
        Me.btnTurboLLA.UseVisualStyleBackColor = False
        Me.btnTurboLLA.ValueToBeSend = ""
        '
        'TurboPumpTM
        '
        Me.TurboPumpTM.Image = Global.AVP_Robot_Project.My.Resources.Resources.Pump_Off
        Me.TurboPumpTM.ImageSize = New System.Drawing.Size(100, 74)
        Me.TurboPumpTM.IsChamberPic = False
        Me.TurboPumpTM.IsStretch = True
        Me.TurboPumpTM.Location = New System.Drawing.Point(580, 103)
        Me.TurboPumpTM.Name = "TurboPumpTM"
        Me.TurboPumpTM.Size = New System.Drawing.Size(120, 85)
        Me.TurboPumpTM.TabIndex = 254
        Me.TurboPumpTM.TextColor = System.Drawing.Color.Wheat
        Me.TurboPumpTM.TextInImage = ""
        Me.TurboPumpTM.TextLocation = New System.Drawing.Point(0, 0)
        '
        'ValveTMTurbo
        '
        Me.ValveTMTurbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveTMTurbo.Location = New System.Drawing.Point(700, 194)
        Me.ValveTMTurbo.Name = "ValveTMTurbo"
        Me.ValveTMTurbo.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveTMTurbo.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveTMTurbo.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveTMTurbo.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveTMTurbo.Size = New System.Drawing.Size(39, 33)
        Me.ValveTMTurbo.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveTMTurbo.TabIndex = 250
        Me.ValveTMTurbo.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveTMTurbo.TextLocIsFix = True
        Me.ValveTMTurbo.TextValue = ""
        '
        'ValveLLBTurbo
        '
        Me.ValveLLBTurbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLBTurbo.Location = New System.Drawing.Point(711, 363)
        Me.ValveLLBTurbo.Name = "ValveLLBTurbo"
        Me.ValveLLBTurbo.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveLLBTurbo.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLBTurbo.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveLLBTurbo.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLBTurbo.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLBTurbo.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLBTurbo.TabIndex = 248
        Me.ValveLLBTurbo.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLBTurbo.TextLocIsFix = True
        Me.ValveLLBTurbo.TextValue = ""
        '
        'ValveLLATurbo
        '
        Me.ValveLLATurbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLATurbo.Location = New System.Drawing.Point(293, 364)
        Me.ValveLLATurbo.Name = "ValveLLATurbo"
        Me.ValveLLATurbo.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveLLATurbo.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLATurbo.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveLLATurbo.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLATurbo.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLATurbo.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLATurbo.TabIndex = 247
        Me.ValveLLATurbo.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLATurbo.TextLocIsFix = True
        Me.ValveLLATurbo.TextValue = ""
        '
        'GasLineTurboValveLLB
        '
        Me.GasLineTurboValveLLB.Enabled = False
        Me.GasLineTurboValveLLB.Image = Global.AVP_Robot_Project.My.Resources.Resources.MainModule
        Me.GasLineTurboValveLLB.ImageSize = New System.Drawing.Size(1000, 374)
        Me.GasLineTurboValveLLB.IsChamberPic = False
        Me.GasLineTurboValveLLB.IsStretch = True
        Me.GasLineTurboValveLLB.Location = New System.Drawing.Point(725, 373)
        Me.GasLineTurboValveLLB.Name = "GasLineTurboValveLLB"
        Me.GasLineTurboValveLLB.Size = New System.Drawing.Size(100, 9)
        Me.GasLineTurboValveLLB.TabIndex = 246
        Me.GasLineTurboValveLLB.TextColor = System.Drawing.Color.Wheat
        Me.GasLineTurboValveLLB.TextInImage = ""
        Me.GasLineTurboValveLLB.TextLocation = New System.Drawing.Point(0, 0)
        '
        'GasLineTurboValveLLA
        '
        Me.GasLineTurboValveLLA.Enabled = False
        Me.GasLineTurboValveLLA.Image = Global.AVP_Robot_Project.My.Resources.Resources.MainModule
        Me.GasLineTurboValveLLA.ImageSize = New System.Drawing.Size(1000, 374)
        Me.GasLineTurboValveLLA.IsChamberPic = False
        Me.GasLineTurboValveLLA.IsStretch = True
        Me.GasLineTurboValveLLA.Location = New System.Drawing.Point(170, 359)
        Me.GasLineTurboValveLLA.Name = "GasLineTurboValveLLA"
        Me.GasLineTurboValveLLA.Size = New System.Drawing.Size(100, 9)
        Me.GasLineTurboValveLLA.TabIndex = 245
        Me.GasLineTurboValveLLA.TextColor = System.Drawing.Color.Wheat
        Me.GasLineTurboValveLLA.TextInImage = ""
        Me.GasLineTurboValveLLA.TextLocation = New System.Drawing.Point(0, 0)
        '
        'btnMechineTool
        '
        Me.btnMechineTool.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnMechineTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMechineTool.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMechineTool.FlatAppearance.BorderSize = 0
        Me.btnMechineTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMechineTool.Location = New System.Drawing.Point(489, 364)
        Me.btnMechineTool.Name = "btnMechineTool"
        Me.btnMechineTool.Size = New System.Drawing.Size(30, 28)
        Me.btnMechineTool.TabIndex = 129
        Me.btnMechineTool.UseVisualStyleBackColor = True
        '
        'GasLineTurboTM
        '
        Me.GasLineTurboTM.Enabled = False
        Me.GasLineTurboTM.Image = Global.AVP_Robot_Project.My.Resources.Resources.MainModule
        Me.GasLineTurboTM.ImageSize = New System.Drawing.Size(1000, 374)
        Me.GasLineTurboTM.IsChamberPic = False
        Me.GasLineTurboTM.IsStretch = True
        Me.GasLineTurboTM.Location = New System.Drawing.Point(1013, 194)
        Me.GasLineTurboTM.Name = "GasLineTurboTM"
        Me.GasLineTurboTM.Size = New System.Drawing.Size(178, 130)
        Me.GasLineTurboTM.TabIndex = 249
        Me.GasLineTurboTM.TextColor = System.Drawing.Color.Wheat
        Me.GasLineTurboTM.TextInImage = ""
        Me.GasLineTurboTM.TextLocation = New System.Drawing.Point(0, 0)
        '
        'btnLeftTool
        '
        Me.btnLeftTool.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnLeftTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLeftTool.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLeftTool.FlatAppearance.BorderSize = 0
        Me.btnLeftTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLeftTool.Location = New System.Drawing.Point(354, 430)
        Me.btnLeftTool.Name = "btnLeftTool"
        Me.btnLeftTool.Size = New System.Drawing.Size(30, 28)
        Me.btnLeftTool.TabIndex = 127
        Me.btnLeftTool.UseVisualStyleBackColor = True
        Me.btnLeftTool.Visible = False
        '
        'btnRightTool
        '
        Me.btnRightTool.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnRightTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRightTool.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRightTool.FlatAppearance.BorderSize = 0
        Me.btnRightTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRightTool.Location = New System.Drawing.Point(623, 429)
        Me.btnRightTool.Name = "btnRightTool"
        Me.btnRightTool.Size = New System.Drawing.Size(30, 28)
        Me.btnRightTool.TabIndex = 128
        Me.btnRightTool.UseVisualStyleBackColor = True
        Me.btnRightTool.Visible = False
        '
        'btnCancelMove
        '
        Me.btnCancelMove.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCancelMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelMove.Clickable = True
        Me.btnCancelMove.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnCancelMove.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCancelMove.ColorText_OnStatus = System.Drawing.Color.FromArgb(105, 99, 50)
        Me.btnCancelMove.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnCancelMove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelMove.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCancelMove.ErrorText = ""
        Me.btnCancelMove.FlatAppearance.BorderSize = 0
        Me.btnCancelMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelMove.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelMove.ForeColor = System.Drawing.Color.Black
        Me.btnCancelMove.Location = New System.Drawing.Point(1159, 280)
        Me.btnCancelMove.Name = "btnCancelMove"
        Me.btnCancelMove.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCancelMove.OffText = "Cancel Move"
        Me.btnCancelMove.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCancelMove.OnText = "Cancel Move"
        Me.btnCancelMove.Size = New System.Drawing.Size(125, 31)
        Me.btnCancelMove.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnCancelMove.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnCancelMove.TabIndex = 244
        Me.btnCancelMove.Text = "Cancel Move"
        Me.btnCancelMove.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCancelMove.UnKnownText = ""
        Me.btnCancelMove.UseClickedEventInForm = True
        Me.btnCancelMove.UseVisualStyleBackColor = True
        Me.btnCancelMove.ValueToBeSend = ""
        '
        'btnFakeProcessCompleteChime
        '
        Me.btnFakeProcessCompleteChime.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnFakeProcessCompleteChime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFakeProcessCompleteChime.Clickable = True
        Me.btnFakeProcessCompleteChime.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnFakeProcessCompleteChime.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnFakeProcessCompleteChime.ColorText_OnStatus = System.Drawing.Color.FromArgb(105, 99, 50)
        Me.btnFakeProcessCompleteChime.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnFakeProcessCompleteChime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFakeProcessCompleteChime.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnFakeProcessCompleteChime.ErrorText = ""
        Me.btnFakeProcessCompleteChime.FlatAppearance.BorderSize = 0
        Me.btnFakeProcessCompleteChime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFakeProcessCompleteChime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFakeProcessCompleteChime.ForeColor = System.Drawing.Color.Black
        Me.btnFakeProcessCompleteChime.Location = New System.Drawing.Point(1159, 290)
        Me.btnFakeProcessCompleteChime.Name = "btnFakeProcessCompleteChime"
        Me.btnFakeProcessCompleteChime.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnFakeProcessCompleteChime.OffText = "Fake Process"
        Me.btnFakeProcessCompleteChime.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnFakeProcessCompleteChime.OnText = "Fake Process"
        Me.btnFakeProcessCompleteChime.Size = New System.Drawing.Size(125, 31)
        Me.btnFakeProcessCompleteChime.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnFakeProcessCompleteChime.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnFakeProcessCompleteChime.TabIndex = 244
        Me.btnFakeProcessCompleteChime.Text = "Fake Process"
        Me.btnFakeProcessCompleteChime.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnFakeProcessCompleteChime.UnKnownText = ""
        Me.btnFakeProcessCompleteChime.UseClickedEventInForm = True
        Me.btnFakeProcessCompleteChime.UseVisualStyleBackColor = True
        Me.btnFakeProcessCompleteChime.ValueToBeSend = ""
        Me.btnFakeProcessCompleteChime.Visible = False
        '
        'RoughPumpControl2
        '
        Me.RoughPumpControl2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RoughPumpControl2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughPumpControl2.Location = New System.Drawing.Point(975, 627)
        Me.RoughPumpControl2.Name = "RoughPumpControl2"
        Me.RoughPumpControl2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rough_Pump_Off
        Me.RoughPumpControl2.OffState_ColorText = System.Drawing.Color.White
        Me.RoughPumpControl2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rough_Pump_On
        Me.RoughPumpControl2.OnState_ColorText = System.Drawing.Color.DarkBlue
        Me.RoughPumpControl2.Size = New System.Drawing.Size(133, 85)
        Me.RoughPumpControl2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.RoughPumpControl2.TabIndex = 251
        Me.RoughPumpControl2.TextLocation = New System.Drawing.Point(0, 0)
        Me.RoughPumpControl2.TextLocIsFix = True
        Me.RoughPumpControl2.TextValue = "0"
        '
        'ticHandOriginal
        '
        Me.ticHandOriginal.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Arm_At_Home
        Me.ticHandOriginal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ticHandOriginal.CXStyle = AVP_Robot_Project.RobotHand.CX_Style.CX7
        Me.ticHandOriginal.Image = Global.AVP_Robot_Project.My.Resources.Resources.HandOriginal
        Me.ticHandOriginal.ImageSize = New System.Drawing.Size(140, 140)
        Me.ticHandOriginal.IsChamberPic = False
        Me.ticHandOriginal.IsStretch = False
        Me.ticHandOriginal.Location = New System.Drawing.Point(610, 280)
        Me.ticHandOriginal.Name = "ticHandOriginal"
        Me.ticHandOriginal.PositionRobot = AVPLib.ConstEnum.Positions.Robot
        Me.ticHandOriginal.Size = New System.Drawing.Size(210, 215)
        Me.ticHandOriginal.TabIndex = 80
        Me.ticHandOriginal.TextColor = System.Drawing.Color.Wheat
        Me.ticHandOriginal.TextInImage = ""
        Me.ticHandOriginal.TextLocation = New System.Drawing.Point(0, 0)
        Me.ticHandOriginal.WaferID = ""
        Me.ticHandOriginal.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
        '
        'btnTMProtectedMode
        '
        Me.btnTMProtectedMode.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnTMProtectedMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMProtectedMode.Clickable = True
        Me.btnTMProtectedMode.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMProtectedMode.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTMProtectedMode.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnTMProtectedMode.ColorText_UnknowStatus = System.Drawing.Color.FromArgb(105, 99, 50)
        Me.btnTMProtectedMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTMProtectedMode.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnTMProtectedMode.ErrorText = ""
        Me.btnTMProtectedMode.FlatAppearance.BorderSize = 0
        Me.btnTMProtectedMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTMProtectedMode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTMProtectedMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTMProtectedMode.Location = New System.Drawing.Point(863, 238)
        Me.btnTMProtectedMode.Name = "btnTMProtectedMode"
        Me.btnTMProtectedMode.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnTMProtectedMode.OffText = ""
        Me.btnTMProtectedMode.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnTMProtectedMode.OnText = ""
        Me.btnTMProtectedMode.Size = New System.Drawing.Size(125, 31)
        Me.btnTMProtectedMode.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnTMProtectedMode.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnTMProtectedMode.TabIndex = 241
        Me.btnTMProtectedMode.Text = "Override Mode"
        Me.btnTMProtectedMode.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnTMProtectedMode.UnKnownText = ""
        Me.btnTMProtectedMode.UseClickedEventInForm = True
        Me.btnTMProtectedMode.UseVisualStyleBackColor = True
        Me.btnTMProtectedMode.ValueToBeSend = ""
        '
        'crcTMWaterPump
        '
        Me.crcTMWaterPump.BackColor = System.Drawing.SystemColors.ControlDark
        Me.crcTMWaterPump.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.WhitePanel
        Me.crcTMWaterPump.ButtonVisible = True
        Me.crcTMWaterPump.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcTMWaterPump.HeaderHeight = 28
        Me.crcTMWaterPump.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.crcTMWaterPump.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.crcTMWaterPump.HeaderTextColor = System.Drawing.Color.White
        Me.crcTMWaterPump.HeaderVisible = False
        Me.crcTMWaterPump.Headerwidth = 60
        Me.crcTMWaterPump.IsOnline = False
        Me.crcTMWaterPump.Location = New System.Drawing.Point(1051, 317)
        Me.crcTMWaterPump.Name = "crcTMWaterPump"
        Me.crcTMWaterPump.Size = New System.Drawing.Size(181, 89)
        Me.crcTMWaterPump.TabIndex = 163
        Me.crcTMWaterPump.Text = "WaterPump"
        '
        'btnTool
        '
        Me.btnTool.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTool.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTool.FlatAppearance.BorderSize = 0
        Me.btnTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTool.Location = New System.Drawing.Point(200, 292)
        Me.btnTool.Name = "btnTool"
        Me.btnTool.Size = New System.Drawing.Size(30, 28)
        Me.btnTool.TabIndex = 76
        Me.btnTool.UseVisualStyleBackColor = True
        Me.btnTool.Visible = False
        '
        'stwSemiautoTransferWafer
        '
        Me.stwSemiautoTransferWafer.BackColor = System.Drawing.Color.Transparent
        Me.stwSemiautoTransferWafer.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.stwSemiautoTransferWafer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.stwSemiautoTransferWafer.Dest_Is_Aligner = False
        Me.stwSemiautoTransferWafer.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stwSemiautoTransferWafer.HeaderHeight = 28
        Me.stwSemiautoTransferWafer.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.stwSemiautoTransferWafer.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.stwSemiautoTransferWafer.HeaderTextColor = System.Drawing.Color.Black
        Me.stwSemiautoTransferWafer.HeaderVisible = False
        Me.stwSemiautoTransferWafer.Headerwidth = 60
        Me.stwSemiautoTransferWafer.Location = New System.Drawing.Point(1106, 564)
        Me.stwSemiautoTransferWafer.Name = "stwSemiautoTransferWafer"
        Me.stwSemiautoTransferWafer.Size = New System.Drawing.Size(120, 82)
        Me.stwSemiautoTransferWafer.TabIndex = 16
        Me.stwSemiautoTransferWafer.Text = "TRANSFER WAFER"
        Me.stwSemiautoTransferWafer.Visible = False
        '
        'IgcgChamber1
        '
        Me.IgcgChamber1.BackColor = System.Drawing.Color.Transparent
        Me.IgcgChamber1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.WhitePanel
        Me.IgcgChamber1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.IgcgChamber1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgcgChamber1.ForeColor = System.Drawing.Color.DarkBlue
        Me.IgcgChamber1.HeaderHeight = 60
        Me.IgcgChamber1.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[Error]
        Me.IgcgChamber1.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.IgcgChamber1.HeaderTextColor = System.Drawing.Color.Black
        Me.IgcgChamber1.HeaderVisible = True
        Me.IgcgChamber1.Headerwidth = 49
        Me.IgcgChamber1.IGCGValue = "OFF"
        Me.IgcgChamber1.Location = New System.Drawing.Point(200, 193)
        Me.IgcgChamber1.Name = "IgcgChamber1"
        Me.IgcgChamber1.Size = New System.Drawing.Size(120, 27)
        Me.IgcgChamber1.TabIndex = 12
        Me.IgcgChamber1.Text = "PM1"
        '
        'IgcgChamber2
        '
        Me.IgcgChamber2.BackColor = System.Drawing.Color.Transparent
        Me.IgcgChamber2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.WhitePanel
        Me.IgcgChamber2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.IgcgChamber2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgcgChamber2.ForeColor = System.Drawing.Color.DarkBlue
        Me.IgcgChamber2.HeaderHeight = 60
        Me.IgcgChamber2.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.IgcgChamber2.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.IgcgChamber2.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.IgcgChamber2.HeaderVisible = True
        Me.IgcgChamber2.Headerwidth = 49
        Me.IgcgChamber2.IGCGValue = "OFF"
        Me.IgcgChamber2.Location = New System.Drawing.Point(307, 48)
        Me.IgcgChamber2.Name = "IgcgChamber2"
        Me.IgcgChamber2.Size = New System.Drawing.Size(120, 27)
        Me.IgcgChamber2.TabIndex = 12
        Me.IgcgChamber2.Text = "PM2"
        '
        'IgcgChamber3
        '
        Me.IgcgChamber3.BackColor = System.Drawing.Color.Transparent
        Me.IgcgChamber3.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.IgcgChamber3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.IgcgChamber3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgcgChamber3.ForeColor = System.Drawing.Color.DarkBlue
        Me.IgcgChamber3.HeaderHeight = 60
        Me.IgcgChamber3.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.IgcgChamber3.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.IgcgChamber3.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.IgcgChamber3.HeaderVisible = True
        Me.IgcgChamber3.Headerwidth = 49
        Me.IgcgChamber3.IGCGValue = "OFF"
        Me.IgcgChamber3.Location = New System.Drawing.Point(455, 14)
        Me.IgcgChamber3.Name = "IgcgChamber3"
        Me.IgcgChamber3.Size = New System.Drawing.Size(120, 27)
        Me.IgcgChamber3.TabIndex = 13
        Me.IgcgChamber3.Text = "PM3"
        '
        'Robot_Body
        '
        Me.Robot_Body.Aligner_At_Station = 1
        Me.Robot_Body.BackColor = System.Drawing.Color.Transparent
        Me.Robot_Body.BackgroundImage = CType(resources.GetObject("Robot_Body.BackgroundImage"), System.Drawing.Image)
        Me.Robot_Body.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Robot_Body.CX_Supported = AVP_Robot_Project.PMControl.Support_CX.Support_CX7
        Me.Robot_Body.LLAInstalled = True
        Me.Robot_Body.LLBInstalled = True
        Me.Robot_Body.Location = New System.Drawing.Point(402, 171)
        Me.Robot_Body.Name = "Robot_Body"
        Me.Robot_Body.PM_IN_SCREEN = AVP_Robot_Project.PMControl.Support_Screen.ProcessScreen
        Me.Robot_Body.PM1Installed = True
        Me.Robot_Body.PM2Installed = True
        Me.Robot_Body.PM3Installed = True
        Me.Robot_Body.PM4Installed = True
        Me.Robot_Body.PM5Installed = True
        Me.Robot_Body.PM6Installed = True
        Me.Robot_Body.SensorLLA_Position = New System.Drawing.Point(55, 148)
        Me.Robot_Body.SensorLLB_Position = New System.Drawing.Point(135, 148)
        Me.Robot_Body.SensorPM1_Position = New System.Drawing.Point(20, 90)
        Me.Robot_Body.SensorPM2_Position = New System.Drawing.Point(45, 35)
        Me.Robot_Body.SensorPM3_Position = New System.Drawing.Point(98, 20)
        Me.Robot_Body.SensorPM4_Position = New System.Drawing.Point(148, 35)
        Me.Robot_Body.SensorPM5_Position = New System.Drawing.Point(171, 89)
        Me.Robot_Body.SensorPM6_Position = New System.Drawing.Point(196, 114)
        Me.Robot_Body.Size = New System.Drawing.Size(205, 226)
        Me.Robot_Body.TabIndex = 159
        '
        'CX_PM1
        '
        Me.CX_PM1.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM1.BackgroundImage = CType(resources.GetObject("CX_PM1.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM1.CX_Supported = AVP_Robot_Project.PMControl.Support_CX.Support_CX7
        Me.CX_PM1.HasShutter = False
        Me.CX_PM1.LabelDisconnect_Location = New System.Drawing.Point(40, 40)
        Me.CX_PM1.Location = New System.Drawing.Point(279, 223)
        Me.CX_PM1.Name = "CX_PM1"
        Me.CX_PM1.PlasmaIsOn = False
        Me.CX_PM1.PM_IN_SCREEN = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.CX_PM1.PM_Type = AVP_Robot_Project.PMControl.PMPosition.IBE_PM1
        Me.CX_PM1.Show_Disconnected = False
        Me.CX_PM1.ShowWafer_Border_ToEdit = False
        Me.CX_PM1.ShutterLocation = New System.Drawing.Point(15, 28)
        Me.CX_PM1.ShutterStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off
        Me.CX_PM1.Size = New System.Drawing.Size(131, 94)
        Me.CX_PM1.TabIndex = 158
        Me.CX_PM1.WaferID = ""
        Me.CX_PM1.WaferLocation = New System.Drawing.Point(21, 19)
        Me.CX_PM1.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
        '
        'CX_PM2
        '
        Me.CX_PM2.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM2.BackgroundImage = CType(resources.GetObject("CX_PM2.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM2.CX_Supported = AVP_Robot_Project.PMControl.Support_CX.Support_CX7
        Me.CX_PM2.HasShutter = False
        Me.CX_PM2.LabelDisconnect_Location = New System.Drawing.Point(20, 63)
        Me.CX_PM2.Location = New System.Drawing.Point(319, 78)
        Me.CX_PM2.Name = "CX_PM2"
        Me.CX_PM2.PlasmaIsOn = False
        Me.CX_PM2.PM_IN_SCREEN = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.CX_PM2.PM_Type = AVP_Robot_Project.PMControl.PMPosition.IBE_PM2
        Me.CX_PM2.Show_Disconnected = False
        Me.CX_PM2.ShowWafer_Border_ToEdit = False
        Me.CX_PM2.ShutterLocation = New System.Drawing.Point(15, 28)
        Me.CX_PM2.ShutterStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off
        Me.CX_PM2.Size = New System.Drawing.Size(143, 151)
        Me.CX_PM2.TabIndex = 158
        Me.CX_PM2.WaferID = ""
        Me.CX_PM2.WaferLocation = New System.Drawing.Point(31, 37)
        Me.CX_PM2.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
        '
        'CX_PM3
        '
        Me.CX_PM3.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM3.BackgroundImage = CType(resources.GetObject("CX_PM3.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM3.CX_Supported = AVP_Robot_Project.PMControl.Support_CX.Support_CX7
        Me.CX_PM3.HasShutter = False
        Me.CX_PM3.LabelDisconnect_Location = New System.Drawing.Point(0, 40)
        Me.CX_PM3.Location = New System.Drawing.Point(463, 49)
        Me.CX_PM3.Name = "CX_PM3"
        Me.CX_PM3.PlasmaIsOn = False
        Me.CX_PM3.PM_IN_SCREEN = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.CX_PM3.PM_Type = AVP_Robot_Project.PMControl.PMPosition.IBE_PM3
        Me.CX_PM3.Show_Disconnected = False
        Me.CX_PM3.ShowWafer_Border_ToEdit = False
        Me.CX_PM3.ShutterLocation = New System.Drawing.Point(15, 28)
        Me.CX_PM3.ShutterStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off
        Me.CX_PM3.Size = New System.Drawing.Size(91, 129)
        Me.CX_PM3.TabIndex = 158
        Me.CX_PM3.WaferID = ""
        Me.CX_PM3.WaferLocation = New System.Drawing.Point(45, 37)
        Me.CX_PM3.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
        '
        'ibsHivacButton
        '
        Me.ibsHivacButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ibsHivacButton.Location = New System.Drawing.Point(465, 218)
        Me.ibsHivacButton.Name = "ibsHivacButton"
        Me.ibsHivacButton.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Split_Valve3_Closed_Red
        Me.ibsHivacButton.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Split_Valve3_Opened_Green
        Me.ibsHivacButton.Size = New System.Drawing.Size(82, 23)
        Me.ibsHivacButton.Status = AVP_Robot_Project.ThirdStatusControl.DisplayStatus.Unknown
        Me.ibsHivacButton.TabIndex = 123
        Me.ibsHivacButton.UnknowImage = Global.AVP_Robot_Project.My.Resources.Resources.Split_Valve3_Unknown_Red
        Me.ibsHivacButton.Visible = False
        '
        'TMCtl
        '
        Me.TMCtl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TMCtl.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.WhitePanel
        Me.TMCtl.Display_In = AVP_Robot_Project.TMControl.AVPScreens.TMPanel
        Me.TMCtl.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMCtl.HeaderHeight = 28
        Me.TMCtl.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.TMCtl.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.TMCtl.HeaderText_Offline = Nothing
        Me.TMCtl.HeaderText_Online = Nothing
        Me.TMCtl.HeaderTextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TMCtl.HeaderVisible = False
        Me.TMCtl.Headerwidth = 60
        Me.TMCtl.IsOnline = False
        Me.TMCtl.Location = New System.Drawing.Point(10, 15)
        Me.TMCtl.Name = "TMCtl"
        Me.TMCtl.Size = New System.Drawing.Size(190, 125)
        Me.TMCtl.TabIndex = 156
        Me.TMCtl.Text = "TM"
        '
        'crcLLBCryo
        '
        Me.crcLLBCryo.BackColor = System.Drawing.Color.Transparent
        Me.crcLLBCryo.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.WhitePanel
        Me.crcLLBCryo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.crcLLBCryo.ButtonVisible = True
        Me.crcLLBCryo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcLLBCryo.HeaderHeight = 28
        Me.crcLLBCryo.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.crcLLBCryo.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.crcLLBCryo.HeaderTextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.crcLLBCryo.HeaderVisible = False
        Me.crcLLBCryo.Headerwidth = 60
        Me.crcLLBCryo.IsOnline = False
        Me.crcLLBCryo.Location = New System.Drawing.Point(770, 610)
        Me.crcLLBCryo.Name = "crcLLBCryo"
        Me.crcLLBCryo.Size = New System.Drawing.Size(199, 88)
        Me.crcLLBCryo.TabIndex = 109
        Me.crcLLBCryo.Text = "LLB Cryo"
        '
        'crcLLACryo
        '
        Me.crcLLACryo.BackColor = System.Drawing.Color.Transparent
        Me.crcLLACryo.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.WhitePanel
        Me.crcLLACryo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.crcLLACryo.ButtonVisible = True
        Me.crcLLACryo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcLLACryo.HeaderHeight = 28
        Me.crcLLACryo.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.crcLLACryo.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.crcLLACryo.HeaderTextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.crcLLACryo.HeaderVisible = False
        Me.crcLLACryo.Headerwidth = 60
        Me.crcLLACryo.IsOnline = False
        Me.crcLLACryo.Location = New System.Drawing.Point(53, 610)
        Me.crcLLACryo.Name = "crcLLACryo"
        Me.crcLLACryo.Size = New System.Drawing.Size(199, 88)
        Me.crcLLACryo.TabIndex = 108
        Me.crcLLACryo.Text = "LLA Cryo"
        '
        'lccLoadLockB
        '
        Me.lccLoadLockB.AlignStyle = AVP_Robot_Project.LockCassetteControl.DisplayStyle.Right
        Me.lccLoadLockB.BackColor = System.Drawing.Color.Transparent
        Me.lccLoadLockB.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BackGroundMessagbox
        Me.lccLoadLockB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lccLoadLockB.HeaderBackColor = System.Drawing.Color.SpringGreen
        Me.lccLoadLockB.HeaderVisible = False
        Me.lccLoadLockB.IsLLOnline = False
        Me.lccLoadLockB.Location = New System.Drawing.Point(555, 527)
        Me.lccLoadLockB.Name = "lccLoadLockB"
        Me.lccLoadLockB.NumSlot = 25
        Me.lccLoadLockB.Size = New System.Drawing.Size(184, 220)
        Me.lccLoadLockB.TabIndex = 14
        Me.lccLoadLockB.Text = "LLB"
        '
        'RoughPumpControl
        '
        Me.RoughPumpControl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RoughPumpControl.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughPumpControl.Location = New System.Drawing.Point(1114, 627)
        Me.RoughPumpControl.Name = "RoughPumpControl"
        Me.RoughPumpControl.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rough_Pump_Off
        Me.RoughPumpControl.OffState_ColorText = System.Drawing.Color.White
        Me.RoughPumpControl.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rough_Pump_On
        Me.RoughPumpControl.OnState_ColorText = System.Drawing.Color.DarkBlue
        Me.RoughPumpControl.Size = New System.Drawing.Size(133, 85)
        Me.RoughPumpControl.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.RoughPumpControl.TabIndex = 126
        Me.RoughPumpControl.TextLocation = New System.Drawing.Point(0, 0)
        Me.RoughPumpControl.TextLocIsFix = True
        Me.RoughPumpControl.TextValue = "0"
        '
        'ValveLLASlowRough
        '
        Me.ValveLLASlowRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLASlowRough.Location = New System.Drawing.Point(263, 335)
        Me.ValveLLASlowRough.Name = "ValveLLASlowRough"
        Me.ValveLLASlowRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveLLASlowRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLASlowRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveLLASlowRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLASlowRough.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLASlowRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLASlowRough.TabIndex = 111
        Me.ValveLLASlowRough.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLASlowRough.TextLocIsFix = True
        Me.ValveLLASlowRough.TextValue = ""
        '
        'ValveRough
        '
        Me.ValveRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveRough.Location = New System.Drawing.Point(700, 116)
        Me.ValveRough.Name = "ValveRough"
        Me.ValveRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveRough.Size = New System.Drawing.Size(39, 33)
        Me.ValveRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveRough.TabIndex = 111
        Me.ValveRough.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveRough.TextLocIsFix = True
        Me.ValveRough.TextValue = ""
        '
        'ValveVent
        '
        Me.ValveVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveVent.Location = New System.Drawing.Point(307, 135)
        Me.ValveVent.Name = "ValveVent"
        Me.ValveVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveVent.Size = New System.Drawing.Size(39, 33)
        Me.ValveVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveVent.TabIndex = 111
        Me.ValveVent.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveVent.TextLocIsFix = True
        Me.ValveVent.TextValue = ""
        '
        'ValveLLAFastRough
        '
        Me.ValveLLAFastRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLAFastRough.Location = New System.Drawing.Point(263, 394)
        Me.ValveLLAFastRough.Name = "ValveLLAFastRough"
        Me.ValveLLAFastRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveLLAFastRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLAFastRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveLLAFastRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLAFastRough.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLAFastRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLAFastRough.TabIndex = 111
        Me.ValveLLAFastRough.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLAFastRough.TextLocIsFix = True
        Me.ValveLLAFastRough.TextValue = ""
        '
        'ValveLLBFastRough
        '
        Me.ValveLLBFastRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLBFastRough.Location = New System.Drawing.Point(736, 394)
        Me.ValveLLBFastRough.Name = "ValveLLBFastRough"
        Me.ValveLLBFastRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveLLBFastRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLBFastRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveLLBFastRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLBFastRough.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLBFastRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLBFastRough.TabIndex = 111
        Me.ValveLLBFastRough.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLBFastRough.TextLocIsFix = True
        Me.ValveLLBFastRough.TextValue = ""
        '
        'ValveLLBSlowRough
        '
        Me.ValveLLBSlowRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLBSlowRough.Location = New System.Drawing.Point(736, 334)
        Me.ValveLLBSlowRough.Name = "ValveLLBSlowRough"
        Me.ValveLLBSlowRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveLLBSlowRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLBSlowRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveLLBSlowRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLBSlowRough.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLBSlowRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLBSlowRough.TabIndex = 111
        Me.ValveLLBSlowRough.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLBSlowRough.TextLocIsFix = True
        Me.ValveLLBSlowRough.TextValue = ""
        '
        'crcTMCryo
        '
        Me.crcTMCryo.BackColor = System.Drawing.Color.Transparent
        Me.crcTMCryo.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.WhitePanel
        Me.crcTMCryo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.crcTMCryo.ButtonVisible = True
        Me.crcTMCryo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcTMCryo.HeaderHeight = 28
        Me.crcTMCryo.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.crcTMCryo.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.crcTMCryo.HeaderTextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.crcTMCryo.HeaderVisible = False
        Me.crcTMCryo.Headerwidth = 60
        Me.crcTMCryo.IsOnline = False
        Me.crcTMCryo.Location = New System.Drawing.Point(10, 154)
        Me.crcTMCryo.Name = "crcTMCryo"
        Me.crcTMCryo.Size = New System.Drawing.Size(199, 88)
        Me.crcTMCryo.TabIndex = 140
        Me.crcTMCryo.Text = "TM Cryo"
        '
        'lccLoadLockA
        '
        Me.lccLoadLockA.AlignStyle = AVP_Robot_Project.LockCassetteControl.DisplayStyle.Left
        Me.lccLoadLockA.BackColor = System.Drawing.Color.Transparent
        Me.lccLoadLockA.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BackGroundMessagbox
        Me.lccLoadLockA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lccLoadLockA.HeaderBackColor = System.Drawing.Color.SteelBlue
        Me.lccLoadLockA.HeaderVisible = False
        Me.lccLoadLockA.IsLLOnline = False
        Me.lccLoadLockA.Location = New System.Drawing.Point(260, 527)
        Me.lccLoadLockA.Name = "lccLoadLockA"
        Me.lccLoadLockA.NumSlot = 25
        Me.lccLoadLockA.Size = New System.Drawing.Size(192, 220)
        Me.lccLoadLockA.TabIndex = 15
        Me.lccLoadLockA.Text = "LLA"
        '
        'ValveLLBFastVent
        '
        Me.ValveLLBFastVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLBFastVent.Location = New System.Drawing.Point(868, 490)
        Me.ValveLLBFastVent.Name = "ValveLLBFastVent"
        Me.ValveLLBFastVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveLLBFastVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLBFastVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveLLBFastVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLBFastVent.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLBFastVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLBFastVent.TabIndex = 111
        Me.ValveLLBFastVent.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLBFastVent.TextLocIsFix = True
        Me.ValveLLBFastVent.TextValue = ""
        '
        'ValveLLAFastVent
        '
        Me.ValveLLAFastVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLAFastVent.Location = New System.Drawing.Point(107, 513)
        Me.ValveLLAFastVent.Name = "ValveLLAFastVent"
        Me.ValveLLAFastVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveLLAFastVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLAFastVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveLLAFastVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLAFastVent.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLAFastVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLAFastVent.TabIndex = 111
        Me.ValveLLAFastVent.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLAFastVent.TextLocIsFix = True
        Me.ValveLLAFastVent.TextValue = ""
        '
        'ValveLLASlowVent
        '
        Me.ValveLLASlowVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLASlowVent.Location = New System.Drawing.Point(107, 448)
        Me.ValveLLASlowVent.Name = "ValveLLASlowVent"
        Me.ValveLLASlowVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveLLASlowVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLASlowVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveLLASlowVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLASlowVent.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLASlowVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLASlowVent.TabIndex = 111
        Me.ValveLLASlowVent.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLASlowVent.TextLocIsFix = True
        Me.ValveLLASlowVent.TextValue = ""
        '
        'GasLineNitrogen
        '
        Me.GasLineNitrogen.Enabled = False
        Me.GasLineNitrogen.Image = Global.AVP_Robot_Project.My.Resources.Resources.MainModule
        Me.GasLineNitrogen.ImageSize = New System.Drawing.Size(1000, 374)
        Me.GasLineNitrogen.IsChamberPic = False
        Me.GasLineNitrogen.IsStretch = True
        Me.GasLineNitrogen.Location = New System.Drawing.Point(22, 248)
        Me.GasLineNitrogen.Name = "GasLineNitrogen"
        Me.GasLineNitrogen.Size = New System.Drawing.Size(178, 130)
        Me.GasLineNitrogen.TabIndex = 91
        Me.GasLineNitrogen.TextColor = System.Drawing.Color.Wheat
        Me.GasLineNitrogen.TextInImage = ""
        Me.GasLineNitrogen.TextLocation = New System.Drawing.Point(0, 0)
        '
        'ValveLLBSlowVent
        '
        Me.ValveLLBSlowVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLBSlowVent.Location = New System.Drawing.Point(868, 430)
        Me.ValveLLBSlowVent.Name = "ValveLLBSlowVent"
        Me.ValveLLBSlowVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveLLBSlowVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLBSlowVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveLLBSlowVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLBSlowVent.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLBSlowVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLBSlowVent.TabIndex = 111
        Me.ValveLLBSlowVent.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLBSlowVent.TextLocIsFix = True
        Me.ValveLLBSlowVent.TextValue = ""
        '
        'GasLineRoughValveLLA
        '
        Me.GasLineRoughValveLLA.Cursor = System.Windows.Forms.Cursors.Default
        Me.GasLineRoughValveLLA.Enabled = False
        Me.GasLineRoughValveLLA.Image = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_VentValveLLA
        Me.GasLineRoughValveLLA.ImageSize = New System.Drawing.Size(140, 140)
        Me.GasLineRoughValveLLA.IsChamberPic = False
        Me.GasLineRoughValveLLA.IsStretch = False
        Me.GasLineRoughValveLLA.Location = New System.Drawing.Point(57, 348)
        Me.GasLineRoughValveLLA.Name = "GasLineRoughValveLLA"
        Me.GasLineRoughValveLLA.Size = New System.Drawing.Size(365, 73)
        Me.GasLineRoughValveLLA.TabIndex = 119
        Me.GasLineRoughValveLLA.TextColor = System.Drawing.Color.Wheat
        Me.GasLineRoughValveLLA.TextInImage = ""
        Me.GasLineRoughValveLLA.TextLocation = New System.Drawing.Point(0, 0)
        '
        'GasLineRoughValveLLB
        '
        Me.GasLineRoughValveLLB.Cursor = System.Windows.Forms.Cursors.Default
        Me.GasLineRoughValveLLB.Enabled = False
        Me.GasLineRoughValveLLB.Image = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_VentValveLLB
        Me.GasLineRoughValveLLB.ImageSize = New System.Drawing.Size(245, 142)
        Me.GasLineRoughValveLLB.IsChamberPic = False
        Me.GasLineRoughValveLLB.IsStretch = False
        Me.GasLineRoughValveLLB.Location = New System.Drawing.Point(613, 343)
        Me.GasLineRoughValveLLB.Name = "GasLineRoughValveLLB"
        Me.GasLineRoughValveLLB.Size = New System.Drawing.Size(380, 74)
        Me.GasLineRoughValveLLB.TabIndex = 119
        Me.GasLineRoughValveLLB.TextColor = System.Drawing.Color.Wheat
        Me.GasLineRoughValveLLB.TextInImage = ""
        Me.GasLineRoughValveLLB.TextLocation = New System.Drawing.Point(0, 0)
        '
        'GasLineVentValveLLB
        '
        Me.GasLineVentValveLLB.Cursor = System.Windows.Forms.Cursors.Default
        Me.GasLineVentValveLLB.Enabled = False
        Me.GasLineVentValveLLB.Image = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_RoughValveLLB
        Me.GasLineVentValveLLB.ImageSize = New System.Drawing.Size(320, 120)
        Me.GasLineVentValveLLB.IsChamberPic = False
        Me.GasLineVentValveLLB.IsStretch = False
        Me.GasLineVentValveLLB.Location = New System.Drawing.Point(442, 443)
        Me.GasLineVentValveLLB.Name = "GasLineVentValveLLB"
        Me.GasLineVentValveLLB.Size = New System.Drawing.Size(538, 80)
        Me.GasLineVentValveLLB.TabIndex = 125
        Me.GasLineVentValveLLB.TextColor = System.Drawing.Color.Wheat
        Me.GasLineVentValveLLB.TextInImage = ""
        Me.GasLineVentValveLLB.TextLocation = New System.Drawing.Point(0, 0)
        '
        'TurboPumpLLB
        '
        Me.TurboPumpLLB.Enabled = False
        Me.TurboPumpLLB.Image = Global.AVP_Robot_Project.My.Resources.Resources.Pump_Off
        Me.TurboPumpLLB.ImageSize = New System.Drawing.Size(100, 74)
        Me.TurboPumpLLB.IsChamberPic = False
        Me.TurboPumpLLB.IsStretch = True
        Me.TurboPumpLLB.Location = New System.Drawing.Point(688, 443)
        Me.TurboPumpLLB.Name = "TurboPumpLLB"
        Me.TurboPumpLLB.Size = New System.Drawing.Size(120, 85)
        Me.TurboPumpLLB.TabIndex = 253
        Me.TurboPumpLLB.TextColor = System.Drawing.Color.Wheat
        Me.TurboPumpLLB.TextInImage = ""
        Me.TurboPumpLLB.TextLocation = New System.Drawing.Point(0, 0)
        '
        'TurboPumpLLA
        '
        Me.TurboPumpLLA.Enabled = False
        Me.TurboPumpLLA.Image = Global.AVP_Robot_Project.My.Resources.Resources.Pump_Off
        Me.TurboPumpLLA.ImageSize = New System.Drawing.Size(100, 74)
        Me.TurboPumpLLA.IsChamberPic = False
        Me.TurboPumpLLA.IsStretch = True
        Me.TurboPumpLLA.Location = New System.Drawing.Point(226, 443)
        Me.TurboPumpLLA.Name = "TurboPumpLLA"
        Me.TurboPumpLLA.Size = New System.Drawing.Size(120, 85)
        Me.TurboPumpLLA.TabIndex = 252
        Me.TurboPumpLLA.TextColor = System.Drawing.Color.Wheat
        Me.TurboPumpLLA.TextInImage = ""
        Me.TurboPumpLLA.TextLocation = New System.Drawing.Point(0, 0)
        '
        'LLBLeg
        '
        Me.LLBLeg.BackColor = System.Drawing.Color.Transparent
        Me.LLBLeg.BackgroundImage = CType(resources.GetObject("LLBLeg.BackgroundImage"), System.Drawing.Image)
        Me.LLBLeg.Cassette_Location = New System.Drawing.Point(20, 30)
        Me.LLBLeg.CassettePresent = False
        Me.LLBLeg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LLBLeg.EQ_LoadLock = AVPLib.ConstEnum.Equipments.LoadLockB
        Me.LLBLeg.Leg_In_Screen = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.LLBLeg.LegLocation = New System.Drawing.Point(18, 105)
        Me.LLBLeg.LegStatus = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.LLBLeg.LoadLockType = AVP_Robot_Project.LoadLockLeg.Load_Lock_Type.Type_1
        Me.LLBLeg.Location = New System.Drawing.Point(529, 351)
        Me.LLBLeg.Name = "LLBLeg"
        Me.LLBLeg.QuestionMark_Location = New System.Drawing.Point(88, 27)
        Me.LLBLeg.QuestionMark_Visible = False
        Me.LLBLeg.Size = New System.Drawing.Size(166, 115)
        Me.LLBLeg.TabIndex = 161
        '
        'LLALeg
        '
        Me.LLALeg.BackColor = System.Drawing.Color.Transparent
        Me.LLALeg.BackgroundImage = CType(resources.GetObject("LLALeg.BackgroundImage"), System.Drawing.Image)
        Me.LLALeg.Cassette_Location = New System.Drawing.Point(30, 30)
        Me.LLALeg.CassettePresent = False
        Me.LLALeg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LLALeg.EQ_LoadLock = AVPLib.ConstEnum.Equipments.LoadLockA
        Me.LLALeg.Leg_In_Screen = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.LLALeg.LegLocation = New System.Drawing.Point(0, 105)
        Me.LLALeg.LegStatus = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.LLALeg.LoadLockType = AVP_Robot_Project.LoadLockLeg.Load_Lock_Type.Type_1
        Me.LLALeg.Location = New System.Drawing.Point(341, 352)
        Me.LLALeg.Name = "LLALeg"
        Me.LLALeg.QuestionMark_Location = New System.Drawing.Point(88, 27)
        Me.LLALeg.QuestionMark_Visible = False
        Me.LLALeg.Size = New System.Drawing.Size(145, 117)
        Me.LLALeg.TabIndex = 160
        '
        'GasLineVentValveLLA
        '
        Me.GasLineVentValveLLA.Cursor = System.Windows.Forms.Cursors.Default
        Me.GasLineVentValveLLA.Enabled = False
        Me.GasLineVentValveLLA.Image = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_RoughValveLLA
        Me.GasLineVentValveLLA.ImageSize = New System.Drawing.Size(140, 120)
        Me.GasLineVentValveLLA.IsChamberPic = False
        Me.GasLineVentValveLLA.IsStretch = False
        Me.GasLineVentValveLLA.Location = New System.Drawing.Point(24, 448)
        Me.GasLineVentValveLLA.Name = "GasLineVentValveLLA"
        Me.GasLineVentValveLLA.Size = New System.Drawing.Size(552, 90)
        Me.GasLineVentValveLLA.TabIndex = 125
        Me.GasLineVentValveLLA.TextColor = System.Drawing.Color.Wheat
        Me.GasLineVentValveLLA.TextInImage = ""
        Me.GasLineVentValveLLA.TextLocation = New System.Drawing.Point(0, 0)
        '
        'lblComunicationLED_TurboTM
        '
        Me.lblComunicationLED_TurboTM.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED_TurboTM.Location = New System.Drawing.Point(632, 372)
        Me.lblComunicationLED_TurboTM.Name = "lblComunicationLED_TurboTM"
        Me.lblComunicationLED_TurboTM.Size = New System.Drawing.Size(8, 12)
        Me.lblComunicationLED_TurboTM.TabIndex = 286
        '
        'CassettesPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.lblComunicationLED_TurboTM)
        Me.Controls.Add(Me.btnTurboRelayIndicator_LLA)
        Me.Controls.Add(Me.btnTurboRelayIndicator_TM)
        Me.Controls.Add(Me.btnTurboRelayIndicator_LLB)
        Me.Controls.Add(Me.lblComunicationLED_TurboLLB)
        Me.Controls.Add(Me.lblComunicationLED_TurboLLA)
        Me.Controls.Add(Me.btnRelayIndicatorPump2)
        Me.Controls.Add(Me.btnRelayIndicatorPump1)
        Me.Controls.Add(Me.GasRoughLine)
        Me.Controls.Add(Me.txtRoughLineLLA)
        Me.Controls.Add(Me.txtTurboIGLLA)
        Me.Controls.Add(Me.txtTurboIGTM)
        Me.Controls.Add(Me.lblRoughPumpInUse_2)
        Me.Controls.Add(Me.lblVentLineTM)
        Me.Controls.Add(Me.txtRoughLineTM)
        Me.Controls.Add(Me.lblVentLineLLB)
        Me.Controls.Add(Me.txtTurboIGLLB)
        Me.Controls.Add(Me.lblVentLineLLA)
        Me.Controls.Add(Me.lblRoughLineLLA)
        Me.Controls.Add(Me.txtRoughLineLLB)
        Me.Controls.Add(Me.lblRoughLineLLB)
        Me.Controls.Add(Me.lblPump2)
        Me.Controls.Add(Me.btnTurboTM)
        Me.Controls.Add(Me.lblRoughLineTM)
        Me.Controls.Add(Me.btnTurboLLB)
        Me.Controls.Add(Me.btnTurboLLA)
        Me.Controls.Add(Me.HivacValveTM)
        Me.Controls.Add(Me.TurboPumpTM)
        Me.Controls.Add(Me.lblPump1)
        Me.Controls.Add(Me.ValveTMTurbo)
        Me.Controls.Add(Me.ValveLLBTurbo)
        Me.Controls.Add(Me.ValveLLATurbo)
        Me.Controls.Add(Me.GasLineTurboValveLLB)
        Me.Controls.Add(Me.GasLineTurboValveLLA)
        Me.Controls.Add(Me.btnMechineTool)
        Me.Controls.Add(Me.GasLineTurboTM)
        Me.Controls.Add(Me.btnLeftTool)
        Me.Controls.Add(Me.btnRightTool)
        Me.Controls.Add(Me.btnCancelMove)
        Me.Controls.Add(Me.btnFakeProcessCompleteChime)
        Me.Controls.Add(Me.lblFlashing)
        Me.Controls.Add(Me.lblLLBNameOfSequenceRunning)
        Me.Controls.Add(Me.lblLLANameOfSequenceRunning)
        Me.Controls.Add(Me.lblTMNameOfSequenceRunning)
        Me.Controls.Add(Me.RoughPumpControl2)
        Me.Controls.Add(Me.LLBIgStatus)
        Me.Controls.Add(Me.ticHandOriginal)
        Me.Controls.Add(Me.LLAIgStatus)
        Me.Controls.Add(Me.btnTMProtectedMode)
        Me.Controls.Add(Me.crcTMWaterPump)
        Me.Controls.Add(Me.btnTool)
        Me.Controls.Add(Me.stwSemiautoTransferWafer)
        Me.Controls.Add(Me.lblRoughPumpInUse)
        Me.Controls.Add(Me.IgcgChamber1)
        Me.Controls.Add(Me.IgcgChamber2)
        Me.Controls.Add(Me.IgcgChamber3)
        Me.Controls.Add(Me.MesaValvePM1)
        Me.Controls.Add(Me.MesaValvePM2)
        Me.Controls.Add(Me.MesaValvePM3)
        Me.Controls.Add(Me.MesaValveLLA)
        Me.Controls.Add(Me.MesaValveLLB)
        Me.Controls.Add(Me.awcAligner)
        Me.Controls.Add(Me.Robot_Body)
        Me.Controls.Add(Me.CX_PM1)
        Me.Controls.Add(Me.CX_PM2)
        Me.Controls.Add(Me.CX_PM3)
        Me.Controls.Add(Me.ibsHivacButton)
        Me.Controls.Add(Me.TMCtl)
        Me.Controls.Add(Me.crcLLBCryo)
        Me.Controls.Add(Me.crcLLACryo)
        Me.Controls.Add(Me.lblFastVentValve)
        Me.Controls.Add(Me.tabGroup)
        Me.Controls.Add(Me.lccLoadLockB)
        Me.Controls.Add(Me.RoughPumpControl)
        Me.Controls.Add(Me.lblLLAFastRough)
        Me.Controls.Add(Me.lblLLASlowVent)
        Me.Controls.Add(Me.ValveLLASlowRough)
        Me.Controls.Add(Me.lblLLBSlowVent)
        Me.Controls.Add(Me.lblLLBFastRough)
        Me.Controls.Add(Me.ValveRough)
        Me.Controls.Add(Me.ValveVent)
        Me.Controls.Add(Me.ValveLLAFastRough)
        Me.Controls.Add(Me.ValveLLBFastRough)
        Me.Controls.Add(Me.lblLLBFastVent)
        Me.Controls.Add(Me.ValveLLBSlowRough)
        Me.Controls.Add(Me.crcTMCryo)
        Me.Controls.Add(Me.lblLLAFastVent)
        Me.Controls.Add(Me.lccLoadLockA)
        Me.Controls.Add(Me.ValveLLBFastVent)
        Me.Controls.Add(Me.lblLLBSlowRough)
        Me.Controls.Add(Me.lblFastRoughtValve)
        Me.Controls.Add(Me.lblLLASlowRough)
        Me.Controls.Add(Me.lblStatusText)
        Me.Controls.Add(Me.lblCoreMessageBoxText)
        Me.Controls.Add(Me.ValveLLAFastVent)
        Me.Controls.Add(Me.ValveLLASlowVent)
        Me.Controls.Add(Me.lblTurboForlineLLA)
        Me.Controls.Add(Me.GasLineNitrogen)
        Me.Controls.Add(Me.ValveLLBSlowVent)
        Me.Controls.Add(Me.GasLineRoughValveLLA)
        Me.Controls.Add(Me.GasLineRoughValveLLB)
        Me.Controls.Add(Me.lblTurboForlineLLB)
        Me.Controls.Add(Me.GasLineVentValveLLB)
        Me.Controls.Add(Me.TurboPumpLLB)
        Me.Controls.Add(Me.TurboPumpLLA)
        Me.Controls.Add(Me.HivacValveLLA)

        Me.Controls.Add(Me.lblTurboForlineTM)
        Me.Controls.Add(Me.HivacValveLLB)
        Me.Controls.Add(Me.LLBLeg)
        Me.Controls.Add(Me.LLALeg)
        Me.Controls.Add(Me.GasLineVentValveLLA)
        Me.Controls.Add(Me.lblPM1MotionInitialize)
        Me.Controls.Add(Me.lblPM2MotionInitialize)
        Me.Controls.Add(Me.lblPM3MotionInitialize)
        Me.Name = "CassettesPanel"
        Me.Size = New System.Drawing.Size(1272, 756)
        Me.cmsChamber.ResumeLayout(False)
        Me.cmsTool.ResumeLayout(False)
        Me.cmsMechineTool.ResumeLayout(False)
        Me.cmsLeftTool.ResumeLayout(False)
        Me.cmsRightTool.ResumeLayout(False)
        Me.tabGroup.ResumeLayout(False)
        Me.tabCycleWafer.ResumeLayout(False)
        Me.tabSerialCommand.ResumeLayout(False)
        Me.tabCycle.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IgcgChamber1 As AVP_Robot_Project.IGCGControl
    Friend WithEvents IgcgChamber2 As AVP_Robot_Project.IGCGControl
    Friend WithEvents IgcgChamber3 As AVP_Robot_Project.IGCGControl
    Friend WithEvents stwSemiautoTransferWafer As AVP_Robot_Project.SemiautoTranferWaferControl
    Friend WithEvents atwAutoTransferWafer As AVP_Robot_Project.AutoTransferWaferControl
    Friend WithEvents sccSerialCommand As AVP_Robot_Project.SerialCommandControl
    Friend WithEvents lccLoadLockB As AVP_Robot_Project.LockCassetteControl

    Friend WithEvents HivacValveLLB As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents HivacValveLLA As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents HivacValveTM As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValveLLA As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValvePM1 As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValvePM2 As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValvePM3 As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValveLLB As AVP_Robot_Project.RoundRectangleStatusControl

    Friend WithEvents cmsChamber As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCreateWafer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteWafer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSrcForMove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDstForMove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTool As System.Windows.Forms.Button
    Friend WithEvents cmsTool As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuHome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAlign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents awcAligner As AVP_Robot_Project.AlignerWaferControl
    Friend WithEvents lblStatusText As System.Windows.Forms.Label
    Friend WithEvents lblCoreMessageBoxText As System.Windows.Forms.Label
    Friend WithEvents mnuUpdateWaferInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents crcLLBCryo As AVP_Robot_Project.CryoControl
    Friend WithEvents crcLLACryo As AVP_Robot_Project.CryoControl
    Friend WithEvents ValveVent As AVP_Robot_Project.ValveControl
    Friend WithEvents GasLineRoughValveLLA As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents ibsHivacButton As AVP_Robot_Project.ImageHivacTMTransferModule
    Friend WithEvents GasLineVentValveLLA As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents GasLineRoughValveLLB As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents GasLineVentValveLLB As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents ValveLLASlowVent As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLAFastVent As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLBSlowVent As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLBFastVent As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveRough As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLBSlowRough As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLBFastRough As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLASlowRough As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLAFastRough As AVP_Robot_Project.ValveControl
    Friend WithEvents RoughPumpControl As AVP_Robot_Project.ValveControl
    Friend WithEvents btnLeftTool As System.Windows.Forms.Button
    Friend WithEvents btnRightTool As System.Windows.Forms.Button
    Friend WithEvents btnMechineTool As System.Windows.Forms.Button
    Friend WithEvents lblFastRoughtValve As System.Windows.Forms.Label
    Friend WithEvents lblFastVentValve As System.Windows.Forms.Label
    Friend WithEvents lblLLBFastRough As System.Windows.Forms.Label
    Friend WithEvents lblLLAFastRough As System.Windows.Forms.Label
    Friend WithEvents lblLLAFastVent As System.Windows.Forms.Label
    Friend WithEvents lblLLBFastVent As System.Windows.Forms.Label
    Friend WithEvents lblLLBSlowRough As System.Windows.Forms.Label
    Friend WithEvents lblLLASlowVent As System.Windows.Forms.Label
    Friend WithEvents lblLLBSlowVent As System.Windows.Forms.Label
    Friend WithEvents lblLLASlowRough As System.Windows.Forms.Label
    Friend WithEvents cmsMechineTool As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMechineOnline As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMechineOffline As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMechinePumpDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMechineStopPumpDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMechineVent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMechineStopVent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsLeftTool As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuLeftOnline As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLeftOffline As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLeftPumpDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLeftStopPumpDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLeftVent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLeftStopVent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsRightTool As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuRightOnline As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRightOffline As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRightPumpDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRightStopPumpDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRightVent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRightStopVent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents crcTMCryo As AVP_Robot_Project.CryoControl
    Friend WithEvents clearStatusTimer As System.Windows.Forms.Timer
    Friend WithEvents lccLoadLockA As AVP_Robot_Project.LockCassetteControl
    Friend WithEvents ticHandOriginal As AVP_Robot_Project.RobotHand
    Friend WithEvents TMCtl As AVP_Robot_Project.TMControl
    Friend WithEvents lblRoughPumpInUse As System.Windows.Forms.Label
    Friend WithEvents CX_PM1 As AVP_Robot_Project.PMControl
    Friend WithEvents CX_PM2 As AVP_Robot_Project.PMControl
    Friend WithEvents CX_PM3 As AVP_Robot_Project.PMControl
    Friend WithEvents Robot_Body As AVP_Robot_Project.RobotBody
    Friend WithEvents LLALeg As AVP_Robot_Project.LoadLockLeg
    Friend WithEvents LLBLeg As AVP_Robot_Project.LoadLockLeg
    Friend WithEvents tabGroup As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabCycleWafer As System.Windows.Forms.TabPage
    Friend WithEvents tabSerialCommand As System.Windows.Forms.TabPage
    Friend WithEvents crcTMWaterPump As AVP_Robot_Project.WaterPump
    Friend WithEvents btnTMProtectedMode As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents LLAIgStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents LLBIgStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents tabCycle As System.Windows.Forms.TabPage
    Friend WithEvents ctwcCycleWafer As AVP_Robot_Project.CycleTransferWaferControl
    Friend WithEvents btnCancelMove As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnFakeProcessCompleteChime As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents GasLineNitrogen As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents GasLineTurboValveLLA As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents GasLineTurboValveLLB As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents ValveLLATurbo As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLBTurbo As AVP_Robot_Project.ValveControl
    Friend WithEvents GasLineTurboTM As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents ValveTMTurbo As AVP_Robot_Project.ValveControl
    Friend WithEvents RoughPumpControl2 As AVP_Robot_Project.ValveControl
    Friend WithEvents TurboPumpLLA As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents TurboPumpLLB As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents TurboPumpTM As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents btnTurboLLA As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTurboLLB As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTurboTM As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblPump1 As System.Windows.Forms.Label
    Friend WithEvents lblPump2 As System.Windows.Forms.Label
    Friend WithEvents lblRoughLineLLB As System.Windows.Forms.Label
    Friend WithEvents lblRoughLineLLA As System.Windows.Forms.Label
    Friend WithEvents lblRoughLineTM As System.Windows.Forms.Label
    Friend WithEvents lblVentLineLLA As System.Windows.Forms.Label
    Friend WithEvents lblVentLineLLB As System.Windows.Forms.Label
    Friend WithEvents lblVentLineTM As System.Windows.Forms.Label
    Friend WithEvents lblRoughPumpInUse_2 As System.Windows.Forms.Label
    Friend WithEvents txtTurboIGTM As System.Windows.Forms.TextBox
    Friend WithEvents txtTurboIGLLB As System.Windows.Forms.TextBox
    Friend WithEvents txtTurboIGLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtRoughLineTM As System.Windows.Forms.TextBox
    Friend WithEvents txtRoughLineLLB As System.Windows.Forms.TextBox
    Friend WithEvents txtRoughLineLLA As System.Windows.Forms.TextBox
    Friend WithEvents GasRoughLine As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents lblTurboForlineLLA As System.Windows.Forms.Label
    Friend WithEvents lblTurboForlineLLB As System.Windows.Forms.Label
    Friend WithEvents lblTurboForlineTM As System.Windows.Forms.Label
    Friend WithEvents btnRelayIndicatorPump1 As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnRelayIndicatorPump2 As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblComunicationLED_TurboLLA As System.Windows.Forms.Label
    Friend WithEvents lblComunicationLED_TurboLLB As System.Windows.Forms.Label
    Friend WithEvents btnTurboRelayIndicator_LLB As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTurboRelayIndicator_LLA As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTurboRelayIndicator_TM As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblComunicationLED_TurboTM As System.Windows.Forms.Label
    Friend WithEvents lblTMNameOfSequenceRunning As System.Windows.Forms.Label
    Friend WithEvents lblLLANameOfSequenceRunning As System.Windows.Forms.Label
    Friend WithEvents lblLLBNameOfSequenceRunning As System.Windows.Forms.Label
    Friend WithEvents lblFlashing As AVP_Robot_Project.FlashingLabel
    Friend WithEvents lblPM1MotionInitialize As System.Windows.Forms.Label
    Friend WithEvents lblPM2MotionInitialize As System.Windows.Forms.Label
    Friend WithEvents lblPM3MotionInitialize As System.Windows.Forms.Label
End Class