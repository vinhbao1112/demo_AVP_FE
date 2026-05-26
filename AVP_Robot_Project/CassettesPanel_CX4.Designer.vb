<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CassettesPanel
    Inherits AVP_Robot_Project.StatusPanel

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CassettesPanel))
        Me.lblPM1MotionInitialize = New System.Windows.Forms.Label()
        Me.lblPM2MotionInitialize = New System.Windows.Forms.Label()
        Me.lblPM3MotionInitialize = New System.Windows.Forms.Label()
        Me.cmsChamber = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCreateWafer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteWafer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSrcForMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDstForMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUpdateWaferInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsTool = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuHome = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAlign = New System.Windows.Forms.ToolStripMenuItem()
        Me.awcAligner = New AVPControls.AVPAlignerControl()
        Me.lblStatusText = New System.Windows.Forms.Label()
        Me.lblCoreMessageBoxText = New System.Windows.Forms.Label()
        Me.lblFastRoughtValve = New System.Windows.Forms.Label()
        Me.lblFastVentValve = New System.Windows.Forms.Label()
        Me.lblLLAFastRough = New System.Windows.Forms.Label()
        Me.lblLLAFastVent = New System.Windows.Forms.Label()
        Me.lblLLASlowVent = New System.Windows.Forms.Label()
        Me.lblLLASlowRough = New System.Windows.Forms.Label()
        Me.cmsMechineTool = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMechineOnline = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMechineOffline = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMechinePumpDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMechineStopPumpDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMechineVent = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMechineStopVent = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsLeftTool = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuLeftOnline = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLeftOffline = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLeftPumpDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLeftStopPumpDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLeftVent = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLeftStopVent = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsRightTool = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuRightOnline = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRightOffline = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRightPumpDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRightStopPumpDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRightVent = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRightStopVent = New System.Windows.Forms.ToolStripMenuItem()
        Me.clearStatusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblRoughPumpInUse = New System.Windows.Forms.Label()
        Me.LLAIgStatus = New AVP_Robot_Project.ButtonIGCGControl()
        Me.tabGroup = New System.Windows.Forms.CustomTabControl()
        Me.tabCycleWafer = New System.Windows.Forms.TabPage()
        Me.atwAutoTransferWafer = New AVP_Robot_Project.AutoTransferWaferControl()
        Me.tabAligner = New System.Windows.Forms.TabPage()
        Me.TMAlignerControl = New AVP_Robot_Project.AlignerControl()
        Me.tabSelfAligner = New System.Windows.Forms.TabPage()
        Me.saSelfAligner = New AVP_Robot_Project.SelfAlignerControl()
        Me.tabSerialCommand = New System.Windows.Forms.TabPage()
        Me.sccSerialCommand = New AVP_Robot_Project.SerialCommandControl()
        Me.tabCycle = New System.Windows.Forms.TabPage()
        Me.ctwcCycleWafer = New AVP_Robot_Project.CycleTransferWaferControl()
        Me.lblTMNameOfSequenceRunning = New System.Windows.Forms.Label()
        Me.lblLLANameOfSequenceRunning = New System.Windows.Forms.Label()
        Me.lblFlashing = New AVPControls.FlashingLabel()
        Me.lblPump1 = New System.Windows.Forms.Label()
        Me.lblPump2 = New System.Windows.Forms.Label()
        Me.lblRoughLineTM = New System.Windows.Forms.Label()
        Me.lblVentLineLLA = New System.Windows.Forms.Label()
        Me.lblVentLineTM = New System.Windows.Forms.Label()
        Me.lblRoughPumpInUse_2 = New System.Windows.Forms.Label()
        Me.txtTurboIGTM = New System.Windows.Forms.TextBox()
        Me.txtTurboIGLLA = New System.Windows.Forms.TextBox()
        Me.txtRoughLineTM = New System.Windows.Forms.TextBox()
        Me.lblTurboForlineLLA = New System.Windows.Forms.Label()
        Me.lblTurboForlineTM = New System.Windows.Forms.Label()
        Me.lblComunicationLED_TurboLLA = New System.Windows.Forms.Label()
        Me.lblComunicationLED_TurboTM = New System.Windows.Forms.Label()
        Me.lblSlowVentLineLLA = New System.Windows.Forms.Label()
        Me.lblAlignerEECA = New System.Windows.Forms.Label()
        Me.lblAlignerEECM = New System.Windows.Forms.Label()
        Me.lblPM1MotionStatus = New System.Windows.Forms.Label()
        Me.lblPM2MotionStatus = New System.Windows.Forms.Label()
        Me.lblPM3MotionStatus = New System.Windows.Forms.Label()
        Me.crcLLACryo = New AVP_Robot_Project.CryoControl()
        Me.lccLoadLockA = New AVP_Robot_Project.LockCassetteControl()
        Me.stwSemiautoTransferWafer = New AVP_Robot_Project.SemiautoTranferWaferControl()
        Me.IgcgChamber1 = New AVP_Robot_Project.IGCGControl()
        Me.TMCtl = New AVP_Robot_Project.TMControl()
        Me.IgcgChamber3 = New AVP_Robot_Project.IGCGControl()
        Me.IgcgChamber2 = New AVP_Robot_Project.IGCGControl()
        Me.Robot_Body = New AVPControls.RobotBodyControl()
        Me.crcTMCryo = New AVP_Robot_Project.CryoControl()
        Me.crcTMWaterPump = New AVP_Robot_Project.WaterPump()
        Me.RobotHand = New AVPControls.RobotArmControl()
        Me.crcLLTurbo = New AVP_Robot_Project.TurboControl()
        Me.btnSystemSetupTestingSetup = New System.Windows.Forms.Button()
        Me.lblAlignAngle = New System.Windows.Forms.Label()
        Me.TMSwitchIGFilament = New System.Windows.Forms.TextBox()
        Me.LLASwitchIGFilament = New System.Windows.Forms.TextBox()
        Me.btnCycleATM = New System.Windows.Forms.Button()
        Me.ValveLLAFastRough = New AVP_Robot_Project.ValveControl()
        Me.Gasline_LL_SlowVent = New AVPControls.AnimationControl()
        Me.Gasline_LL_SV_N2 = New AVPControls.AnimationControl()
        Me.Gasline_LL_FastVent = New AVPControls.AnimationControl()
        Me.Gasline_LL_FV_N2 = New AVPControls.AnimationControl()
        Me.HivacValveLLA = New AVP_Robot_Project.SlitValve()
        Me.LLALeg = New AVP_Robot_Project.LoadLockLeg()
        Me.Gasline_PressureFR = New AVP_Robot_Project.TransparentImageControl()
        Me.Gasline_PressureLL_FL = New AVP_Robot_Project.TransparentImageControl()
        Me.btnUpdateManualTransfer = New System.Windows.Forms.Button()
        Me.Gasline_LL_Vent = New AVPControls.AnimationControl()
        Me.Gasline_TM_FR_Out = New AVPControls.AnimationControl()
        Me.Gasline_TM_FL_2 = New AVPControls.AnimationControl()
        Me.Gasline_TM_FV_N2 = New AVPControls.AnimationControl()
        Me.Gasline_PressureTM_FL = New AVP_Robot_Project.TransparentImageControl()
        Me.Gasline_TM_FL_3 = New AVPControls.AnimationControl()
        Me.btnTurboRelayIndicator_LLA = New AVP_Robot_Project.SL_CustomButton()
        Me.Gasline_TM_FL_4 = New AVPControls.AnimationControl()
        Me.btnTurboLLA = New AVP_Robot_Project.SL_CustomButton()
        Me.Gasline_TM_FL_FR = New AVPControls.AnimationControl()
        Me.Gasline_TM_FL_End1 = New AVPControls.AnimationControl()
        Me.PumpLLA = New AVP_Robot_Project.PumpChamber()
        Me.Gasline_LL_FL_221 = New AVPControls.AnimationControl()
        Me.btnTurboRelayIndicator_TM = New AVP_Robot_Project.SL_CustomButton()
        Me.MesaValvePM2 = New AVP_Robot_Project.SlitValve()
        Me.MesaValveLLA = New AVP_Robot_Project.SlitValve()
        Me.MesaValvePM3 = New AVP_Robot_Project.SlitValve()
        Me.btnTurboTM = New AVP_Robot_Project.SL_CustomButton()
        Me.Gasline_TM_FL_1 = New AVPControls.AnimationControl()
        Me.Gasline_LL_FR_221 = New AVPControls.AnimationControl()
        Me.MesaValvePM1 = New AVP_Robot_Project.SlitValve()
        Me.Gasline_LL_FL_1 = New AVPControls.AnimationControl()
        Me.Gasline_LL_Pump_PartEnd = New AVPControls.AnimationControl()
        Me.Gasline_LL_FR_1 = New AVPControls.AnimationControl()
        Me.Gasline_TM_FL_End2 = New AVPControls.AnimationControl()
        Me.Gasline_LL_FL_222 = New AVPControls.AnimationControl()
        Me.Gasline_TM_Pump_PartEnd = New AVPControls.AnimationControl()
        Me.Gasline_LL_SR_221 = New AVPControls.AnimationControl()
        Me.Gasline_LL_SR_1 = New AVPControls.AnimationControl()
        Me.Gasline_LL_Foreline = New AVPControls.AnimationControl()
        Me.Gasline_LL_Pump_Part4 = New AVPControls.AnimationControl()
        Me.Gasline_TM_Pump_Part4 = New AVPControls.AnimationControl()
        Me.PumpTM = New AVP_Robot_Project.PumpChamber()
        Me.Gasline_LL_FastRough = New AVPControls.AnimationControl()
        Me.Gasline_TM_Foreline = New AVPControls.AnimationControl()
        Me.Gasline_LL_FL_21 = New AVPControls.AnimationControl()
        Me.Gasline_LL_FR_222 = New AVPControls.AnimationControl()
        Me.HivacValveTM = New AVP_Robot_Project.SlitValve()
        Me.Gasline_LL_Pump_Part3 = New AVPControls.AnimationControl()
        Me.Gasline_LL_FR_21 = New AVPControls.AnimationControl()
        Me.Gasline_LL_Rough = New AVPControls.AnimationControl()
        Me.Gasline_TM_Pump_Part3 = New AVPControls.AnimationControl()
        Me.Gasline_LL_SR_21 = New AVPControls.AnimationControl()
        Me.Gasline_LL_Pump_Part2 = New AVPControls.AnimationControl()
        Me.Gasline_LL_SR_222 = New AVPControls.AnimationControl()
        Me.Gasline_TM_Pump_Part2 = New AVPControls.AnimationControl()
        Me.btnMechineTool = New System.Windows.Forms.Button()
        Me.Gasline_LL_SlowRough = New AVPControls.AnimationControl()
        Me.btnFakeProcessCompleteChime = New AVP_Robot_Project.SL_CustomButton()
        Me.ValveLLATurbo = New AVP_Robot_Project.ValveControl()
        Me.Gasline_LL_Pump_Part1 = New AVPControls.AnimationControl()
        Me.btnCancelMove = New AVP_Robot_Project.SL_CustomButton()
        Me.Gasline_TM_Pump_Part1 = New AVPControls.AnimationControl()
        Me.btnTMProtectedMode = New AVP_Robot_Project.SL_CustomButton()
        Me.ibsHivacButton = New AVP_Robot_Project.ImageHivacTMTransferModule()
        Me.btnRelayIndicatorPump2 = New AVP_Robot_Project.SL_CustomButton()
        Me.btnRelayIndicatorPump1 = New AVP_Robot_Project.SL_CustomButton()
        Me.btnTool = New System.Windows.Forms.Button()
        Me.btnLeftTool = New System.Windows.Forms.Button()
        Me.ValveTMTurbo = New AVP_Robot_Project.ValveControl()
        Me.RoughPumpControl = New AVP_Robot_Project.ValveControl()
        Me.RoughPumpControl2 = New AVP_Robot_Project.ValveControl()
        Me.btnRightTool = New System.Windows.Forms.Button()
        Me.ValveLLASlowRough = New AVP_Robot_Project.ValveControl()
        Me.ValveRough = New AVP_Robot_Project.ValveControl()
        Me.CX_PM3 = New AVP_Robot_Project.PMControl()
        Me.ValveLLAFastVent = New AVP_Robot_Project.ValveControl()
        Me.CX_PM1 = New AVP_Robot_Project.PMControl()
        Me.ValveLLASlowVent = New AVP_Robot_Project.ValveControl()
        Me.CX_PM2 = New AVP_Robot_Project.PMControl()
        Me.ValveVent = New AVP_Robot_Project.ValveControl()
        Me.Gasline_TM_FastVent = New AVPControls.AnimationControl()
        Me.Gasline_TM_FastRough = New AVPControls.AnimationControl()
        Me.ctrLLATurboCom = New AVPControls.LEDControl()
        Me.ctrTMTurboCom = New AVPControls.LEDControl()
        Me.lblturboRampingPercent = New System.Windows.Forms.Label()
        Me.lblTMturboRampingPercent = New System.Windows.Forms.Label()
        Me.btnCommunicationMP2 = New AVPControls.LEDControl()
        Me.btnCommunicationMP1 = New AVPControls.LEDControl()
        Me.lblComunicationLED_LLpump = New System.Windows.Forms.Label()
        Me.lblComunicationLED_TMPump = New System.Windows.Forms.Label()
        Me.lblWaitingMPOnTM = New System.Windows.Forms.Label()
        Me.lblWaitingMPOnLL = New System.Windows.Forms.Label()
        Me.cmsChamber.SuspendLayout()
        Me.cmsTool.SuspendLayout()
        CType(Me.awcAligner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsMechineTool.SuspendLayout()
        Me.cmsLeftTool.SuspendLayout()
        Me.cmsRightTool.SuspendLayout()
        Me.tabGroup.SuspendLayout()
        Me.tabCycleWafer.SuspendLayout()
        Me.tabAligner.SuspendLayout()
        Me.tabSelfAligner.SuspendLayout()
        Me.tabSerialCommand.SuspendLayout()
        Me.tabCycle.SuspendLayout()
        CType(Me.Robot_Body, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RobotHand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_SlowVent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_SV_N2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FastVent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FV_N2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_Vent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FR_Out, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FL_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FV_N2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FL_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FL_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FL_FR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FL_End1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FL_221, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FL_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FR_221, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FL_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_Pump_PartEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FR_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FL_End2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FL_222, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_Pump_PartEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_SR_221, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_SR_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_Foreline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_Pump_Part4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_Pump_Part4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FastRough, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_Foreline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FL_21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FR_222, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_Pump_Part3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_FR_21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_Rough, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_Pump_Part3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_SR_21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_Pump_Part2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_SR_222, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_Pump_Part2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_SlowRough, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_LL_Pump_Part1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_Pump_Part1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FastVent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gasline_TM_FastRough, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ctrLLATurboCom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ctrTMTurboCom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCommunicationMP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCommunicationMP1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPM1MotionInitialize
        '
        Me.lblPM1MotionInitialize.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM1MotionInitialize.ForeColor = System.Drawing.Color.Yellow
        Me.lblPM1MotionInitialize.Location = New System.Drawing.Point(211, 130)
        Me.lblPM1MotionInitialize.Name = "lblPM1MotionInitialize"
        Me.lblPM1MotionInitialize.Size = New System.Drawing.Size(109, 16)
        Me.lblPM1MotionInitialize.TabIndex = 245
        Me.lblPM1MotionInitialize.Text = "Motion Initializing"
        '
        'lblPM2MotionInitialize
        '
        Me.lblPM2MotionInitialize.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM2MotionInitialize.ForeColor = System.Drawing.Color.Yellow
        Me.lblPM2MotionInitialize.Location = New System.Drawing.Point(264, 53)
        Me.lblPM2MotionInitialize.Name = "lblPM2MotionInitialize"
        Me.lblPM2MotionInitialize.Size = New System.Drawing.Size(109, 16)
        Me.lblPM2MotionInitialize.TabIndex = 245
        Me.lblPM2MotionInitialize.Text = "Motion Initializing"
        '
        'lblPM3MotionInitialize
        '
        Me.lblPM3MotionInitialize.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM3MotionInitialize.ForeColor = System.Drawing.Color.Yellow
        Me.lblPM3MotionInitialize.Location = New System.Drawing.Point(670, 135)
        Me.lblPM3MotionInitialize.Name = "lblPM3MotionInitialize"
        Me.lblPM3MotionInitialize.Size = New System.Drawing.Size(109, 16)
        Me.lblPM3MotionInitialize.TabIndex = 245
        Me.lblPM3MotionInitialize.Text = "Motion Initializing"
        '
        'cmsChamber
        '
        Me.cmsChamber.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsChamber.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCreateWafer, Me.mnuDeleteWafer, Me.mnuSrcForMove, Me.mnuDstForMove, Me.mnuUpdateWaferInfoToolStripMenuItem})
        Me.cmsChamber.Name = "cmsChamber"
        Me.cmsChamber.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsChamber.ShowImageMargin = False
        Me.cmsChamber.Size = New System.Drawing.Size(240, 164)
        '
        'mnuCreateWafer
        '
        Me.mnuCreateWafer.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuCreateWafer.Name = "mnuCreateWafer"
        Me.mnuCreateWafer.Size = New System.Drawing.Size(239, 32)
        Me.mnuCreateWafer.Text = "Create Wafer"
        '
        'mnuDeleteWafer
        '
        Me.mnuDeleteWafer.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuDeleteWafer.Name = "mnuDeleteWafer"
        Me.mnuDeleteWafer.Size = New System.Drawing.Size(239, 32)
        Me.mnuDeleteWafer.Text = "Delete Wafer"
        '
        'mnuSrcForMove
        '
        Me.mnuSrcForMove.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSrcForMove.Name = "mnuSrcForMove"
        Me.mnuSrcForMove.Size = New System.Drawing.Size(239, 32)
        Me.mnuSrcForMove.Text = "Src For Move"
        '
        'mnuDstForMove
        '
        Me.mnuDstForMove.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuDstForMove.Name = "mnuDstForMove"
        Me.mnuDstForMove.Size = New System.Drawing.Size(239, 32)
        Me.mnuDstForMove.Text = "Dst For Move"
        '
        'mnuUpdateWaferInfoToolStripMenuItem
        '
        Me.mnuUpdateWaferInfoToolStripMenuItem.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuUpdateWaferInfoToolStripMenuItem.Name = "mnuUpdateWaferInfoToolStripMenuItem"
        Me.mnuUpdateWaferInfoToolStripMenuItem.Size = New System.Drawing.Size(239, 32)
        Me.mnuUpdateWaferInfoToolStripMenuItem.Text = "Update Wafer Info"
        '
        'cmsTool
        '
        Me.cmsTool.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHome, Me.mnuAlign})
        Me.cmsTool.Name = "cmsTool"
        Me.cmsTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsTool.ShowImageMargin = False
        Me.cmsTool.Size = New System.Drawing.Size(118, 68)
        '
        'mnuHome
        '
        Me.mnuHome.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuHome.Name = "mnuHome"
        Me.mnuHome.Size = New System.Drawing.Size(117, 32)
        Me.mnuHome.Text = "Home"
        '
        'mnuAlign
        '
        Me.mnuAlign.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuAlign.Name = "mnuAlign"
        Me.mnuAlign.Size = New System.Drawing.Size(117, 32)
        Me.mnuAlign.Text = "Align"
        Me.mnuAlign.Visible = False
        '
        'awcAligner
        '
        Me.awcAligner.AnimationInterval = 100
        Me.awcAligner.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.awcAligner.BackColor = System.Drawing.SystemColors.ControlDark
        Me.awcAligner.Cursor = System.Windows.Forms.Cursors.Hand
        Me.awcAligner.Location = New System.Drawing.Point(483, 377)
        Me.awcAligner.Name = "awcAligner"
        Me.awcAligner.Size = New System.Drawing.Size(35, 35)
        Me.awcAligner.TabIndex = 79
        '
        'lblStatusText
        '
        Me.lblStatusText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatusText.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusText.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusText.ForeColor = System.Drawing.Color.White
        Me.lblStatusText.Location = New System.Drawing.Point(30, 744)
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
        Me.lblCoreMessageBoxText.Location = New System.Drawing.Point(33, 744)
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
        Me.lblFastRoughtValve.Location = New System.Drawing.Point(720, 373)
        Me.lblFastRoughtValve.Name = "lblFastRoughtValve"
        Me.lblFastRoughtValve.Size = New System.Drawing.Size(60, 19)
        Me.lblFastRoughtValve.TabIndex = 130
        Me.lblFastRoughtValve.Text = "TM FR"
        '
        'lblFastVentValve
        '
        Me.lblFastVentValve.AutoSize = True
        Me.lblFastVentValve.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFastVentValve.ForeColor = System.Drawing.Color.White
        Me.lblFastVentValve.Location = New System.Drawing.Point(232, 394)
        Me.lblFastVentValve.Name = "lblFastVentValve"
        Me.lblFastVentValve.Size = New System.Drawing.Size(59, 19)
        Me.lblFastVentValve.TabIndex = 131
        Me.lblFastVentValve.Text = "TM FV"
        '
        'lblLLAFastRough
        '
        Me.lblLLAFastRough.AutoSize = True
        Me.lblLLAFastRough.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLAFastRough.ForeColor = System.Drawing.Color.White
        Me.lblLLAFastRough.Location = New System.Drawing.Point(720, 469)
        Me.lblLLAFastRough.Name = "lblLLAFastRough"
        Me.lblLLAFastRough.Size = New System.Drawing.Size(64, 19)
        Me.lblLLAFastRough.TabIndex = 133
        Me.lblLLAFastRough.Text = "LLA FR"
        '
        'lblLLAFastVent
        '
        Me.lblLLAFastVent.AutoSize = True
        Me.lblLLAFastVent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLAFastVent.ForeColor = System.Drawing.Color.White
        Me.lblLLAFastVent.Location = New System.Drawing.Point(231, 466)
        Me.lblLLAFastVent.Name = "lblLLAFastVent"
        Me.lblLLAFastVent.Size = New System.Drawing.Size(63, 19)
        Me.lblLLAFastVent.TabIndex = 134
        Me.lblLLAFastVent.Text = "LLA FV"
        '
        'lblLLASlowVent
        '
        Me.lblLLASlowVent.AutoSize = True
        Me.lblLLASlowVent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLASlowVent.ForeColor = System.Drawing.Color.White
        Me.lblLLASlowVent.Location = New System.Drawing.Point(231, 516)
        Me.lblLLASlowVent.Name = "lblLLASlowVent"
        Me.lblLLASlowVent.Size = New System.Drawing.Size(63, 19)
        Me.lblLLASlowVent.TabIndex = 137
        Me.lblLLASlowVent.Text = "LLA SV"
        '
        'lblLLASlowRough
        '
        Me.lblLLASlowRough.AutoSize = True
        Me.lblLLASlowRough.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLASlowRough.ForeColor = System.Drawing.Color.White
        Me.lblLLASlowRough.Location = New System.Drawing.Point(721, 516)
        Me.lblLLASlowRough.Name = "lblLLASlowRough"
        Me.lblLLASlowRough.Size = New System.Drawing.Size(64, 19)
        Me.lblLLASlowRough.TabIndex = 139
        Me.lblLLASlowRough.Text = "LLA SR"
        '
        'cmsMechineTool
        '
        Me.cmsMechineTool.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsMechineTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMechineOnline, Me.mnuMechineOffline, Me.mnuMechinePumpDown, Me.mnuMechineStopPumpDown, Me.mnuMechineVent, Me.mnuMechineStopVent})
        Me.cmsMechineTool.Name = "cmsMechineTool"
        Me.cmsMechineTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsMechineTool.ShowImageMargin = False
        Me.cmsMechineTool.Size = New System.Drawing.Size(229, 196)
        '
        'mnuMechineOnline
        '
        Me.mnuMechineOnline.Name = "mnuMechineOnline"
        Me.mnuMechineOnline.Size = New System.Drawing.Size(228, 32)
        Me.mnuMechineOnline.Text = "Online"
        '
        'mnuMechineOffline
        '
        Me.mnuMechineOffline.Name = "mnuMechineOffline"
        Me.mnuMechineOffline.Size = New System.Drawing.Size(228, 32)
        Me.mnuMechineOffline.Text = "Offline"
        '
        'mnuMechinePumpDown
        '
        Me.mnuMechinePumpDown.Name = "mnuMechinePumpDown"
        Me.mnuMechinePumpDown.Size = New System.Drawing.Size(228, 32)
        Me.mnuMechinePumpDown.Text = "Pump Down"
        '
        'mnuMechineStopPumpDown
        '
        Me.mnuMechineStopPumpDown.Name = "mnuMechineStopPumpDown"
        Me.mnuMechineStopPumpDown.Size = New System.Drawing.Size(228, 32)
        Me.mnuMechineStopPumpDown.Text = "Stop Pump Down"
        '
        'mnuMechineVent
        '
        Me.mnuMechineVent.Name = "mnuMechineVent"
        Me.mnuMechineVent.Size = New System.Drawing.Size(228, 32)
        Me.mnuMechineVent.Text = "Vent"
        '
        'mnuMechineStopVent
        '
        Me.mnuMechineStopVent.Name = "mnuMechineStopVent"
        Me.mnuMechineStopVent.Size = New System.Drawing.Size(228, 32)
        Me.mnuMechineStopVent.Text = "Stop Vent"
        '
        'cmsLeftTool
        '
        Me.cmsLeftTool.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsLeftTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLeftOnline, Me.mnuLeftOffline, Me.mnuLeftPumpDown, Me.mnuLeftStopPumpDown, Me.mnuLeftVent, Me.mnuLeftStopVent})
        Me.cmsLeftTool.Name = "cmsLeftTool"
        Me.cmsLeftTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsLeftTool.ShowImageMargin = False
        Me.cmsLeftTool.Size = New System.Drawing.Size(229, 196)
        '
        'mnuLeftOnline
        '
        Me.mnuLeftOnline.Name = "mnuLeftOnline"
        Me.mnuLeftOnline.Size = New System.Drawing.Size(228, 32)
        Me.mnuLeftOnline.Text = "Online"
        '
        'mnuLeftOffline
        '
        Me.mnuLeftOffline.Name = "mnuLeftOffline"
        Me.mnuLeftOffline.Size = New System.Drawing.Size(228, 32)
        Me.mnuLeftOffline.Text = "Offline"
        '
        'mnuLeftPumpDown
        '
        Me.mnuLeftPumpDown.Name = "mnuLeftPumpDown"
        Me.mnuLeftPumpDown.Size = New System.Drawing.Size(228, 32)
        Me.mnuLeftPumpDown.Text = "Pump Down"
        '
        'mnuLeftStopPumpDown
        '
        Me.mnuLeftStopPumpDown.Name = "mnuLeftStopPumpDown"
        Me.mnuLeftStopPumpDown.Size = New System.Drawing.Size(228, 32)
        Me.mnuLeftStopPumpDown.Text = "Stop Pump Down"
        '
        'mnuLeftVent
        '
        Me.mnuLeftVent.Name = "mnuLeftVent"
        Me.mnuLeftVent.Size = New System.Drawing.Size(228, 32)
        Me.mnuLeftVent.Text = "Vent"
        '
        'mnuLeftStopVent
        '
        Me.mnuLeftStopVent.Name = "mnuLeftStopVent"
        Me.mnuLeftStopVent.Size = New System.Drawing.Size(228, 32)
        Me.mnuLeftStopVent.Text = "Stop Vent"
        '
        'cmsRightTool
        '
        Me.cmsRightTool.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsRightTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRightOnline, Me.mnuRightOffline, Me.mnuRightPumpDown, Me.mnuRightStopPumpDown, Me.mnuRightVent, Me.mnuRightStopVent})
        Me.cmsRightTool.Name = "cmsRightTool"
        Me.cmsRightTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsRightTool.ShowImageMargin = False
        Me.cmsRightTool.Size = New System.Drawing.Size(229, 196)
        '
        'mnuRightOnline
        '
        Me.mnuRightOnline.Name = "mnuRightOnline"
        Me.mnuRightOnline.Size = New System.Drawing.Size(228, 32)
        Me.mnuRightOnline.Text = "Online"
        '
        'mnuRightOffline
        '
        Me.mnuRightOffline.Name = "mnuRightOffline"
        Me.mnuRightOffline.Size = New System.Drawing.Size(228, 32)
        Me.mnuRightOffline.Text = "Offline"
        '
        'mnuRightPumpDown
        '
        Me.mnuRightPumpDown.Name = "mnuRightPumpDown"
        Me.mnuRightPumpDown.Size = New System.Drawing.Size(228, 32)
        Me.mnuRightPumpDown.Text = "Pump Down"
        '
        'mnuRightStopPumpDown
        '
        Me.mnuRightStopPumpDown.Name = "mnuRightStopPumpDown"
        Me.mnuRightStopPumpDown.Size = New System.Drawing.Size(228, 32)
        Me.mnuRightStopPumpDown.Text = "Stop Pump Down"
        '
        'mnuRightVent
        '
        Me.mnuRightVent.Name = "mnuRightVent"
        Me.mnuRightVent.Size = New System.Drawing.Size(228, 32)
        Me.mnuRightVent.Text = "Vent"
        '
        'mnuRightStopVent
        '
        Me.mnuRightStopVent.Name = "mnuRightStopVent"
        Me.mnuRightStopVent.Size = New System.Drawing.Size(228, 32)
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
        Me.lblRoughPumpInUse.Location = New System.Drawing.Point(1000, 702)
        Me.lblRoughPumpInUse.Name = "lblRoughPumpInUse"
        Me.lblRoughPumpInUse.Size = New System.Drawing.Size(169, 40)
        Me.lblRoughPumpInUse.TabIndex = 157
        '
        'LLAIgStatus
        '
        Me.LLAIgStatus.BackColor = System.Drawing.Color.Transparent
        Me.LLAIgStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LLAIgStatus.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.LLAIgStatus.ErrorImage = Nothing
        Me.LLAIgStatus.FlatAppearance.BorderSize = 0
        Me.LLAIgStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LLAIgStatus.ForeColor = System.Drawing.Color.White
        Me.LLAIgStatus.Location = New System.Drawing.Point(1152, 597)
        Me.LLAIgStatus.Name = "LLAIgStatus"
        Me.LLAIgStatus.OffImage = Nothing
        Me.LLAIgStatus.OnImage = Nothing
        Me.LLAIgStatus.Size = New System.Drawing.Size(61, 38)
        Me.LLAIgStatus.TabIndex = 242
        Me.LLAIgStatus.Text = "LLA IG Status"
        Me.LLAIgStatus.TextLocation = New System.Drawing.Point(0, 0)
        Me.LLAIgStatus.TextLocIsFix = True
        Me.LLAIgStatus.UnknownImage = Nothing
        Me.LLAIgStatus.UseVisualStyleBackColor = True
        Me.LLAIgStatus.Visible = False
        '
        'tabGroup
        '
        Me.tabGroup.CommunicationDisconnectedColor = System.Drawing.Color.Gray
        Me.tabGroup.CommunicationErrorColor = System.Drawing.Color.Red
        Me.tabGroup.Controls.Add(Me.tabCycleWafer)
        Me.tabGroup.Controls.Add(Me.tabAligner)
        Me.tabGroup.Controls.Add(Me.tabSelfAligner)
        Me.tabGroup.Controls.Add(Me.tabSerialCommand)
        Me.tabGroup.Controls.Add(Me.tabCycle)
        Me.tabGroup.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabGroup.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabGroup.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabGroup.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabGroup.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabGroup.DisplayStyleProvider.FocusTrack = False
        Me.tabGroup.DisplayStyleProvider.HotTrack = True
        Me.tabGroup.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabGroup.DisplayStyleProvider.Opacity = 1.0!
        Me.tabGroup.DisplayStyleProvider.Overlap = 0
        Me.tabGroup.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabGroup.DisplayStyleProvider.Radius = 10
        Me.tabGroup.DisplayStyleProvider.ShowTabCloser = False
        Me.tabGroup.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabGroup.HotTrack = True
        Me.tabGroup.Location = New System.Drawing.Point(815, 15)
        Me.tabGroup.Name = "tabGroup"
        Me.tabGroup.SelectedIndex = 0
        Me.tabGroup.Size = New System.Drawing.Size(464, 211)
        Me.tabGroup.TabIndex = 162
        '
        'tabCycleWafer
        '
        Me.tabCycleWafer.Controls.Add(Me.atwAutoTransferWafer)
        Me.tabCycleWafer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCycleWafer.Location = New System.Drawing.Point(0, 25)
        Me.tabCycleWafer.Name = "tabCycleWafer"
        Me.tabCycleWafer.Size = New System.Drawing.Size(464, 186)
        Me.tabCycleWafer.TabIndex = 1
        Me.tabCycleWafer.Text = "ROBOT "
        Me.tabCycleWafer.UseVisualStyleBackColor = True
        '
        'atwAutoTransferWafer
        '
        Me.atwAutoTransferWafer.BackColor = System.Drawing.Color.Transparent
        Me.atwAutoTransferWafer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.atwAutoTransferWafer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.atwAutoTransferWafer.Enabled = False
        Me.atwAutoTransferWafer.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.atwAutoTransferWafer.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.atwAutoTransferWafer.HeaderHeight = 28
        Me.atwAutoTransferWafer.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.atwAutoTransferWafer.HeaderText = "CYCLE WAFER"
        Me.atwAutoTransferWafer.HeaderTextColor = System.Drawing.Color.Black
        Me.atwAutoTransferWafer.HeaderVisible = False
        Me.atwAutoTransferWafer.IsOnline = False
        Me.atwAutoTransferWafer.Location = New System.Drawing.Point(0, 0)
        Me.atwAutoTransferWafer.Margin = New System.Windows.Forms.Padding(4)
        Me.atwAutoTransferWafer.Name = "atwAutoTransferWafer"
        Me.atwAutoTransferWafer.Size = New System.Drawing.Size(464, 186)
        Me.atwAutoTransferWafer.TabIndex = 17
        Me.atwAutoTransferWafer.Text = "CYCLE WAFER"
        Me.atwAutoTransferWafer.UseBorderStyle = True
        '
        'tabAligner
        '
        Me.tabAligner.Controls.Add(Me.TMAlignerControl)
        Me.tabAligner.Location = New System.Drawing.Point(0, 25)
        Me.tabAligner.Name = "tabAligner"
        Me.tabAligner.Size = New System.Drawing.Size(464, 186)
        Me.tabAligner.TabIndex = 5
        Me.tabAligner.Text = "ALIGNER "
        Me.tabAligner.UseVisualStyleBackColor = True
        '
        'TMAlignerControl
        '
        Me.TMAlignerControl.BackColor = System.Drawing.Color.Transparent
        Me.TMAlignerControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TMAlignerControl.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.TMAlignerControl.HeaderHeight = 28
        Me.TMAlignerControl.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.TMAlignerControl.HeaderText = "AlignerControl1"
        Me.TMAlignerControl.HeaderTextColor = System.Drawing.Color.Black
        Me.TMAlignerControl.HeaderVisible = False
        Me.TMAlignerControl.Location = New System.Drawing.Point(0, 0)
        Me.TMAlignerControl.Margin = New System.Windows.Forms.Padding(4)
        Me.TMAlignerControl.Name = "TMAlignerControl"
        Me.TMAlignerControl.Size = New System.Drawing.Size(464, 186)
        Me.TMAlignerControl.TabIndex = 0
        Me.TMAlignerControl.Text = "AlignerControl1"
        Me.TMAlignerControl.UseBorderStyle = True
        '
        'tabSelfAligner
        '
        Me.tabSelfAligner.Controls.Add(Me.saSelfAligner)
        Me.tabSelfAligner.Location = New System.Drawing.Point(0, 25)
        Me.tabSelfAligner.Name = "tabSelfAligner"
        Me.tabSelfAligner.Size = New System.Drawing.Size(464, 186)
        Me.tabSelfAligner.TabIndex = 4
        Me.tabSelfAligner.Text = "SELF ALIGN "
        Me.tabSelfAligner.UseVisualStyleBackColor = True
        '
        'saSelfAligner
        '
        Me.saSelfAligner.BackColor = System.Drawing.Color.Transparent
        Me.saSelfAligner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.saSelfAligner.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.saSelfAligner.HeaderHeight = 28
        Me.saSelfAligner.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.saSelfAligner.HeaderText = "SelfAlignerControl"
        Me.saSelfAligner.HeaderTextColor = System.Drawing.Color.Black
        Me.saSelfAligner.HeaderVisible = False
        Me.saSelfAligner.IsOnline = False
        Me.saSelfAligner.IsStartSelfAlign = False
        Me.saSelfAligner.Location = New System.Drawing.Point(0, 0)
        Me.saSelfAligner.Margin = New System.Windows.Forms.Padding(4)
        Me.saSelfAligner.Name = "saSelfAligner"
        Me.saSelfAligner.Size = New System.Drawing.Size(464, 186)
        Me.saSelfAligner.TabIndex = 0
        Me.saSelfAligner.Text = "SelfAlignerControl"
        Me.saSelfAligner.UseBorderStyle = True
        '
        'tabSerialCommand
        '
        Me.tabSerialCommand.Controls.Add(Me.sccSerialCommand)
        Me.tabSerialCommand.Location = New System.Drawing.Point(0, 25)
        Me.tabSerialCommand.Name = "tabSerialCommand"
        Me.tabSerialCommand.Size = New System.Drawing.Size(464, 186)
        Me.tabSerialCommand.TabIndex = 2
        Me.tabSerialCommand.Text = "SERIAL COMM"
        Me.tabSerialCommand.UseVisualStyleBackColor = True
        '
        'sccSerialCommand
        '
        Me.sccSerialCommand.BackColor = System.Drawing.Color.Transparent
        Me.sccSerialCommand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.sccSerialCommand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sccSerialCommand.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sccSerialCommand.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.sccSerialCommand.HeaderHeight = 28
        Me.sccSerialCommand.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.sccSerialCommand.HeaderText = "SERIAL COMMAND"
        Me.sccSerialCommand.HeaderTextColor = System.Drawing.Color.Black
        Me.sccSerialCommand.HeaderVisible = False
        Me.sccSerialCommand.IsOnline = False
        Me.sccSerialCommand.Location = New System.Drawing.Point(0, 0)
        Me.sccSerialCommand.Margin = New System.Windows.Forms.Padding(4)
        Me.sccSerialCommand.Name = "sccSerialCommand"
        Me.sccSerialCommand.Size = New System.Drawing.Size(464, 186)
        Me.sccSerialCommand.TabIndex = 19
        Me.sccSerialCommand.Text = "SERIAL COMMAND"
        Me.sccSerialCommand.UseBorderStyle = True
        '
        'tabCycle
        '
        Me.tabCycle.BackColor = System.Drawing.Color.Transparent
        Me.tabCycle.Controls.Add(Me.ctwcCycleWafer)
        Me.tabCycle.Location = New System.Drawing.Point(0, 25)
        Me.tabCycle.Name = "tabCycle"
        Me.tabCycle.Size = New System.Drawing.Size(464, 186)
        Me.tabCycle.TabIndex = 3
        Me.tabCycle.Text = "CYCLE"
        Me.tabCycle.UseVisualStyleBackColor = True
        '
        'ctwcCycleWafer
        '
        Me.ctwcCycleWafer.BackColor = System.Drawing.Color.Transparent
        Me.ctwcCycleWafer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ctwcCycleWafer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctwcCycleWafer.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.ctwcCycleWafer.HeaderHeight = 28
        Me.ctwcCycleWafer.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.ctwcCycleWafer.HeaderText = "CycleTransferWaferControl1"
        Me.ctwcCycleWafer.HeaderTextColor = System.Drawing.Color.Black
        Me.ctwcCycleWafer.HeaderVisible = False
        Me.ctwcCycleWafer.IsLLAShowPopup = True
        Me.ctwcCycleWafer.IsOnline = False
        Me.ctwcCycleWafer.Location = New System.Drawing.Point(0, 0)
        Me.ctwcCycleWafer.Margin = New System.Windows.Forms.Padding(4)
        Me.ctwcCycleWafer.Name = "ctwcCycleWafer"
        Me.ctwcCycleWafer.Size = New System.Drawing.Size(464, 186)
        Me.ctwcCycleWafer.TabIndex = 0
        Me.ctwcCycleWafer.Text = "CycleTransferWaferControl1"
        Me.ctwcCycleWafer.UseBorderStyle = True
        '
        'lblTMNameOfSequenceRunning
        '
        Me.lblTMNameOfSequenceRunning.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblTMNameOfSequenceRunning.ForeColor = System.Drawing.Color.Red
        Me.lblTMNameOfSequenceRunning.Location = New System.Drawing.Point(850, 316)
        Me.lblTMNameOfSequenceRunning.Name = "lblTMNameOfSequenceRunning"
        Me.lblTMNameOfSequenceRunning.Size = New System.Drawing.Size(297, 33)
        Me.lblTMNameOfSequenceRunning.TabIndex = 245
        Me.lblTMNameOfSequenceRunning.Text = "lblTMNameOfSequenceRunning"
        '
        'lblLLANameOfSequenceRunning
        '
        Me.lblLLANameOfSequenceRunning.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblLLANameOfSequenceRunning.ForeColor = System.Drawing.Color.Red
        Me.lblLLANameOfSequenceRunning.Location = New System.Drawing.Point(850, 354)
        Me.lblLLANameOfSequenceRunning.Name = "lblLLANameOfSequenceRunning"
        Me.lblLLANameOfSequenceRunning.Size = New System.Drawing.Size(297, 33)
        Me.lblLLANameOfSequenceRunning.TabIndex = 245
        Me.lblLLANameOfSequenceRunning.Text = "lblLLANameOfSequenceRunning"
        '
        'lblFlashing
        '
        Me.lblFlashing.Color1 = System.Drawing.Color.Yellow
        Me.lblFlashing.Color2 = System.Drawing.Color.Yellow
        Me.lblFlashing.FlashingInterval = 2000
        Me.lblFlashing.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlashing.ForeColor = System.Drawing.Color.Yellow
        Me.lblFlashing.Location = New System.Drawing.Point(850, 237)
        Me.lblFlashing.Name = "lblFlashing"
        Me.lblFlashing.Size = New System.Drawing.Size(297, 74)
        Me.lblFlashing.TabIndex = 246
        Me.lblFlashing.Text = "Flashing Label"
        Me.lblFlashing.Visible = False
        '
        'lblPump1
        '
        Me.lblPump1.AutoSize = True
        Me.lblPump1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPump1.ForeColor = System.Drawing.Color.White
        Me.lblPump1.Location = New System.Drawing.Point(1003, 610)
        Me.lblPump1.Name = "lblPump1"
        Me.lblPump1.Size = New System.Drawing.Size(87, 19)
        Me.lblPump1.TabIndex = 266
        Me.lblPump1.Text = "TM's Pump"
        '
        'lblPump2
        '
        Me.lblPump2.AutoSize = True
        Me.lblPump2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPump2.ForeColor = System.Drawing.Color.White
        Me.lblPump2.Location = New System.Drawing.Point(844, 610)
        Me.lblPump2.Name = "lblPump2"
        Me.lblPump2.Size = New System.Drawing.Size(81, 19)
        Me.lblPump2.TabIndex = 267
        Me.lblPump2.Text = "LL's Pump"
        '
        'lblRoughLineTM
        '
        Me.lblRoughLineTM.AutoSize = True
        Me.lblRoughLineTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoughLineTM.ForeColor = System.Drawing.Color.White
        Me.lblRoughLineTM.Location = New System.Drawing.Point(1196, 488)
        Me.lblRoughLineTM.Name = "lblRoughLineTM"
        Me.lblRoughLineTM.Size = New System.Drawing.Size(81, 19)
        Me.lblRoughLineTM.TabIndex = 270
        Me.lblRoughLineTM.Text = "LL's Pump"
        Me.lblRoughLineTM.Visible = False
        '
        'lblVentLineLLA
        '
        Me.lblVentLineLLA.AutoSize = True
        Me.lblVentLineLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentLineLLA.ForeColor = System.Drawing.Color.White
        Me.lblVentLineLLA.Location = New System.Drawing.Point(195, 493)
        Me.lblVentLineLLA.Name = "lblVentLineLLA"
        Me.lblVentLineLLA.Size = New System.Drawing.Size(29, 19)
        Me.lblVentLineLLA.TabIndex = 272
        Me.lblVentLineLLA.Text = "N2"
        '
        'lblVentLineTM
        '
        Me.lblVentLineTM.AutoSize = True
        Me.lblVentLineTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentLineTM.ForeColor = System.Drawing.Color.White
        Me.lblVentLineTM.Location = New System.Drawing.Point(195, 421)
        Me.lblVentLineTM.Name = "lblVentLineTM"
        Me.lblVentLineTM.Size = New System.Drawing.Size(29, 19)
        Me.lblVentLineTM.TabIndex = 274
        Me.lblVentLineTM.Text = "N2"
        '
        'lblRoughPumpInUse_2
        '
        Me.lblRoughPumpInUse_2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoughPumpInUse_2.ForeColor = System.Drawing.Color.White
        Me.lblRoughPumpInUse_2.Location = New System.Drawing.Point(825, 702)
        Me.lblRoughPumpInUse_2.Name = "lblRoughPumpInUse_2"
        Me.lblRoughPumpInUse_2.Size = New System.Drawing.Size(169, 40)
        Me.lblRoughPumpInUse_2.TabIndex = 275
        '
        'txtTurboIGTM
        '
        Me.txtTurboIGTM.BackColor = System.Drawing.Color.Black
        Me.txtTurboIGTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTurboIGTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTurboIGTM.ForeColor = System.Drawing.Color.Lime
        Me.txtTurboIGTM.Location = New System.Drawing.Point(679, 32)
        Me.txtTurboIGTM.Name = "txtTurboIGTM"
        Me.txtTurboIGTM.ReadOnly = True
        Me.txtTurboIGTM.Size = New System.Drawing.Size(75, 26)
        Me.txtTurboIGTM.TabIndex = 276
        Me.txtTurboIGTM.Text = "7.6E+02"
        Me.txtTurboIGTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTurboIGLLA
        '
        Me.txtTurboIGLLA.BackColor = System.Drawing.Color.Black
        Me.txtTurboIGLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTurboIGLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTurboIGLLA.ForeColor = System.Drawing.Color.Lime
        Me.txtTurboIGLLA.Location = New System.Drawing.Point(609, 419)
        Me.txtTurboIGLLA.Name = "txtTurboIGLLA"
        Me.txtTurboIGLLA.ReadOnly = True
        Me.txtTurboIGLLA.Size = New System.Drawing.Size(75, 26)
        Me.txtTurboIGLLA.TabIndex = 278
        Me.txtTurboIGLLA.Text = "7.6E+02"
        Me.txtTurboIGLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRoughLineTM
        '
        Me.txtRoughLineTM.BackColor = System.Drawing.Color.Black
        Me.txtRoughLineTM.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtRoughLineTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtRoughLineTM.ForeColor = System.Drawing.Color.Lime
        Me.txtRoughLineTM.Location = New System.Drawing.Point(1200, 511)
        Me.txtRoughLineTM.Name = "txtRoughLineTM"
        Me.txtRoughLineTM.ReadOnly = True
        Me.txtRoughLineTM.Size = New System.Drawing.Size(75, 26)
        Me.txtRoughLineTM.TabIndex = 279
        Me.txtRoughLineTM.Text = "7.6E+02"
        Me.txtRoughLineTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRoughLineTM.Visible = False
        '
        'lblTurboForlineLLA
        '
        Me.lblTurboForlineLLA.AutoSize = True
        Me.lblTurboForlineLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboForlineLLA.ForeColor = System.Drawing.Color.White
        Me.lblTurboForlineLLA.Location = New System.Drawing.Point(681, 422)
        Me.lblTurboForlineLLA.Name = "lblTurboForlineLLA"
        Me.lblTurboForlineLLA.Size = New System.Drawing.Size(62, 19)
        Me.lblTurboForlineLLA.TabIndex = 139
        Me.lblTurboForlineLLA.Text = "LLA FL"
        '
        'lblTurboForlineTM
        '
        Me.lblTurboForlineTM.AutoSize = True
        Me.lblTurboForlineTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboForlineTM.ForeColor = System.Drawing.Color.White
        Me.lblTurboForlineTM.Location = New System.Drawing.Point(706, 70)
        Me.lblTurboForlineTM.Name = "lblTurboForlineTM"
        Me.lblTurboForlineTM.Size = New System.Drawing.Size(58, 19)
        Me.lblTurboForlineTM.TabIndex = 139
        Me.lblTurboForlineTM.Text = "TM FL"
        '
        'lblComunicationLED_TurboLLA
        '
        Me.lblComunicationLED_TurboLLA.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED_TurboLLA.Location = New System.Drawing.Point(578, 537)
        Me.lblComunicationLED_TurboLLA.Name = "lblComunicationLED_TurboLLA"
        Me.lblComunicationLED_TurboLLA.Size = New System.Drawing.Size(7, 11)
        Me.lblComunicationLED_TurboLLA.TabIndex = 284
        Me.lblComunicationLED_TurboLLA.Visible = False
        '
        'lblComunicationLED_TurboTM
        '
        Me.lblComunicationLED_TurboTM.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED_TurboTM.Location = New System.Drawing.Point(592, 537)
        Me.lblComunicationLED_TurboTM.Name = "lblComunicationLED_TurboTM"
        Me.lblComunicationLED_TurboTM.Size = New System.Drawing.Size(7, 11)
        Me.lblComunicationLED_TurboTM.TabIndex = 286
        Me.lblComunicationLED_TurboTM.Visible = False
        '
        'lblSlowVentLineLLA
        '
        Me.lblSlowVentLineLLA.AutoSize = True
        Me.lblSlowVentLineLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlowVentLineLLA.ForeColor = System.Drawing.Color.White
        Me.lblSlowVentLineLLA.Location = New System.Drawing.Point(195, 541)
        Me.lblSlowVentLineLLA.Name = "lblSlowVentLineLLA"
        Me.lblSlowVentLineLLA.Size = New System.Drawing.Size(29, 19)
        Me.lblSlowVentLineLLA.TabIndex = 289
        Me.lblSlowVentLineLLA.Text = "N2"
        '
        'lblAlignerEECA
        '
        Me.lblAlignerEECA.AutoSize = True
        Me.lblAlignerEECA.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlignerEECA.ForeColor = System.Drawing.Color.Yellow
        Me.lblAlignerEECA.Location = New System.Drawing.Point(378, 447)
        Me.lblAlignerEECA.Name = "lblAlignerEECA"
        Me.lblAlignerEECA.Size = New System.Drawing.Size(37, 15)
        Me.lblAlignerEECA.TabIndex = 299
        Me.lblAlignerEECA.Text = "Ecc A."
        Me.lblAlignerEECA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAlignerEECA.Visible = False
        '
        'lblAlignerEECM
        '
        Me.lblAlignerEECM.AutoSize = True
        Me.lblAlignerEECM.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlignerEECM.ForeColor = System.Drawing.Color.Yellow
        Me.lblAlignerEECM.Location = New System.Drawing.Point(378, 466)
        Me.lblAlignerEECM.Name = "lblAlignerEECM"
        Me.lblAlignerEECM.Size = New System.Drawing.Size(41, 15)
        Me.lblAlignerEECM.TabIndex = 300
        Me.lblAlignerEECM.Text = "Ecc M."
        Me.lblAlignerEECM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAlignerEECM.Visible = False
        '
        'lblPM1MotionStatus
        '
        Me.lblPM1MotionStatus.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM1MotionStatus.ForeColor = System.Drawing.Color.Gold
        Me.lblPM1MotionStatus.Location = New System.Drawing.Point(211, 185)
        Me.lblPM1MotionStatus.Name = "lblPM1MotionStatus"
        Me.lblPM1MotionStatus.Size = New System.Drawing.Size(136, 15)
        Me.lblPM1MotionStatus.TabIndex = 301
        Me.lblPM1MotionStatus.Text = "PM1: Homing All Axis"
        Me.lblPM1MotionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPM1MotionStatus.Visible = False
        '
        'lblPM2MotionStatus
        '
        Me.lblPM2MotionStatus.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM2MotionStatus.ForeColor = System.Drawing.Color.Gold
        Me.lblPM2MotionStatus.Location = New System.Drawing.Point(264, 38)
        Me.lblPM2MotionStatus.Name = "lblPM2MotionStatus"
        Me.lblPM2MotionStatus.Size = New System.Drawing.Size(136, 15)
        Me.lblPM2MotionStatus.TabIndex = 302
        Me.lblPM2MotionStatus.Text = "PM2: Homing All Axis"
        Me.lblPM2MotionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPM2MotionStatus.Visible = False
        '
        'lblPM3MotionStatus
        '
        Me.lblPM3MotionStatus.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM3MotionStatus.ForeColor = System.Drawing.Color.Gold
        Me.lblPM3MotionStatus.Location = New System.Drawing.Point(651, 185)
        Me.lblPM3MotionStatus.Name = "lblPM3MotionStatus"
        Me.lblPM3MotionStatus.Size = New System.Drawing.Size(136, 15)
        Me.lblPM3MotionStatus.TabIndex = 303
        Me.lblPM3MotionStatus.Text = "PM3: Homing All Axis"
        Me.lblPM3MotionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPM3MotionStatus.Visible = False
        '
        'crcLLACryo
        '
        Me.crcLLACryo.BackColor = System.Drawing.Color.Transparent
        Me.crcLLACryo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.crcLLACryo.ButtonVisible = True
        Me.crcLLACryo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcLLACryo.HeaderFont = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcLLACryo.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.crcLLACryo.HeaderText = "LLA Cryo"
        Me.crcLLACryo.HeaderTextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.crcLLACryo.HeaderVisible = False
        Me.crcLLACryo.Is_CryO_On_Status = False
        Me.crcLLACryo.Is_CryO_Regen_Status = False
        Me.crcLLACryo.IsOnline = False
        Me.crcLLACryo.Location = New System.Drawing.Point(176, 651)
        Me.crcLLACryo.Margin = New System.Windows.Forms.Padding(4)
        Me.crcLLACryo.Name = "crcLLACryo"
        Me.crcLLACryo.Size = New System.Drawing.Size(190, 90)
        Me.crcLLACryo.TabIndex = 108
        Me.crcLLACryo.Text = "LLA Cryo"
        Me.crcLLACryo.UseBorderStyle = True
        '
        'lccLoadLockA
        '
        Me.lccLoadLockA.AlignStyle = AVP_Robot_Project.LockCassetteControl.DisplayStyle.Left
        Me.lccLoadLockA.BackColor = System.Drawing.Color.Transparent
        Me.lccLoadLockA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lccLoadLockA.HeaderBackColor = System.Drawing.Color.SteelBlue
        Me.lccLoadLockA.HeaderVisible = False
        Me.lccLoadLockA.IsCassetteInUsed = False
        Me.lccLoadLockA.Location = New System.Drawing.Point(370, 511)
        Me.lccLoadLockA.Margin = New System.Windows.Forms.Padding(4)
        Me.lccLoadLockA.Name = "lccLoadLockA"
        Me.lccLoadLockA.Size = New System.Drawing.Size(178, 230)
        Me.lccLoadLockA.TabIndex = 15
        Me.lccLoadLockA.Text = "LLA"
        '
        'stwSemiautoTransferWafer
        '
        Me.stwSemiautoTransferWafer.BackColor = System.Drawing.Color.Transparent
        Me.stwSemiautoTransferWafer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.stwSemiautoTransferWafer.Dest_Is_Aligner = False
        Me.stwSemiautoTransferWafer.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stwSemiautoTransferWafer.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.stwSemiautoTransferWafer.HeaderHeight = 28
        Me.stwSemiautoTransferWafer.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.stwSemiautoTransferWafer.HeaderText = "TRANSFER WAFER"
        Me.stwSemiautoTransferWafer.HeaderTextColor = System.Drawing.Color.Black
        Me.stwSemiautoTransferWafer.HeaderVisible = False
        Me.stwSemiautoTransferWafer.Location = New System.Drawing.Point(1159, 392)
        Me.stwSemiautoTransferWafer.Margin = New System.Windows.Forms.Padding(4)
        Me.stwSemiautoTransferWafer.Name = "stwSemiautoTransferWafer"
        Me.stwSemiautoTransferWafer.Size = New System.Drawing.Size(120, 82)
        Me.stwSemiautoTransferWafer.TabIndex = 16
        Me.stwSemiautoTransferWafer.Text = "TRANSFER WAFER"
        Me.stwSemiautoTransferWafer.UseBorderStyle = True
        Me.stwSemiautoTransferWafer.Visible = False
        '
        'IgcgChamber1
        '
        Me.IgcgChamber1.BackColor = System.Drawing.Color.Transparent
        Me.IgcgChamber1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.IgcgChamber1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IgcgChamber1.Font = New System.Drawing.Font("Times New Roman", 14.25!)
        Me.IgcgChamber1.ForeColor = System.Drawing.Color.DarkBlue
        Me.IgcgChamber1.HeaderFont = New System.Drawing.Font("Times New Roman", 14.25!)
        Me.IgcgChamber1.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.IgcgChamber1.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.IgcgChamber1.HeaderText = "PM1"
        Me.IgcgChamber1.HeaderTextColor = System.Drawing.Color.White
        Me.IgcgChamber1.HeaderVisible = True
        Me.IgcgChamber1.Headerwidth = 55
        Me.IgcgChamber1.IGCGValue = "OFF"
        Me.IgcgChamber1.Location = New System.Drawing.Point(214, 155)
        Me.IgcgChamber1.Margin = New System.Windows.Forms.Padding(4)
        Me.IgcgChamber1.Name = "IgcgChamber1"
        Me.IgcgChamber1.Size = New System.Drawing.Size(125, 27)
        Me.IgcgChamber1.TabIndex = 12
        Me.IgcgChamber1.Text = "PM1"
        Me.IgcgChamber1.UseBorderStyle = True
        '
        'TMCtl
        '
        Me.TMCtl.BackColor = System.Drawing.Color.Transparent
        Me.TMCtl.Display_In = AVP_Robot_Project.TMControl.AVPScreens.TMPanel
        Me.TMCtl.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMCtl.HeaderFont = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMCtl.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.TMCtl.HeaderText = "TM"
        Me.TMCtl.HeaderText_Offline = Nothing
        Me.TMCtl.HeaderText_Online = Nothing
        Me.TMCtl.HeaderTextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TMCtl.HeaderVisible = False
        Me.TMCtl.IsOnline = False
        Me.TMCtl.Location = New System.Drawing.Point(1, 15)
        Me.TMCtl.Margin = New System.Windows.Forms.Padding(4)
        Me.TMCtl.Name = "TMCtl"
        Me.TMCtl.Size = New System.Drawing.Size(190, 125)
        Me.TMCtl.TabIndex = 156
        Me.TMCtl.Text = "TM"
        Me.TMCtl.UseBorderStyle = True
        '
        'IgcgChamber3
        '
        Me.IgcgChamber3.BackColor = System.Drawing.Color.Transparent
        Me.IgcgChamber3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.IgcgChamber3.Font = New System.Drawing.Font("Times New Roman", 14.25!)
        Me.IgcgChamber3.ForeColor = System.Drawing.Color.DarkBlue
        Me.IgcgChamber3.HeaderFont = New System.Drawing.Font("Times New Roman", 14.25!)
        Me.IgcgChamber3.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.IgcgChamber3.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.IgcgChamber3.HeaderText = "PM3"
        Me.IgcgChamber3.HeaderTextColor = System.Drawing.Color.White
        Me.IgcgChamber3.HeaderVisible = True
        Me.IgcgChamber3.Headerwidth = 55
        Me.IgcgChamber3.IGCGValue = "OFF"
        Me.IgcgChamber3.Location = New System.Drawing.Point(662, 155)
        Me.IgcgChamber3.Margin = New System.Windows.Forms.Padding(4)
        Me.IgcgChamber3.Name = "IgcgChamber3"
        Me.IgcgChamber3.Size = New System.Drawing.Size(125, 27)
        Me.IgcgChamber3.TabIndex = 13
        Me.IgcgChamber3.Text = "PM3"
        Me.IgcgChamber3.UseBorderStyle = True
        '
        'IgcgChamber2
        '
        Me.IgcgChamber2.BackColor = System.Drawing.Color.Transparent
        Me.IgcgChamber2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.IgcgChamber2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IgcgChamber2.Font = New System.Drawing.Font("Times New Roman", 14.25!)
        Me.IgcgChamber2.ForeColor = System.Drawing.Color.DarkBlue
        Me.IgcgChamber2.HeaderFont = New System.Drawing.Font("Times New Roman", 14.25!)
        Me.IgcgChamber2.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.IgcgChamber2.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.IgcgChamber2.HeaderText = "PM2"
        Me.IgcgChamber2.HeaderTextColor = System.Drawing.Color.White
        Me.IgcgChamber2.HeaderVisible = True
        Me.IgcgChamber2.Headerwidth = 55
        Me.IgcgChamber2.IGCGValue = "OFF"
        Me.IgcgChamber2.Location = New System.Drawing.Point(270, 8)
        Me.IgcgChamber2.Margin = New System.Windows.Forms.Padding(4)
        Me.IgcgChamber2.Name = "IgcgChamber2"
        Me.IgcgChamber2.Size = New System.Drawing.Size(125, 27)
        Me.IgcgChamber2.TabIndex = 12
        Me.IgcgChamber2.Text = "PM2"
        Me.IgcgChamber2.UseBorderStyle = True
        '
        'Robot_Body
        '
        Me.Robot_Body.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.Robot_Body.BackColor = System.Drawing.Color.Transparent
        Me.Robot_Body.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Robot_Body.Location = New System.Drawing.Point(415, 211)
        Me.Robot_Body.Name = "Robot_Body"
        Me.Robot_Body.Size = New System.Drawing.Size(170, 202)
        Me.Robot_Body.TabIndex = 345
        '
        'crcTMCryo
        '
        Me.crcTMCryo.BackColor = System.Drawing.Color.Transparent
        Me.crcTMCryo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.crcTMCryo.ButtonVisible = True
        Me.crcTMCryo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcTMCryo.HeaderFont = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcTMCryo.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.crcTMCryo.HeaderText = "TM Cryo"
        Me.crcTMCryo.HeaderTextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.crcTMCryo.HeaderVisible = False
        Me.crcTMCryo.Is_CryO_On_Status = False
        Me.crcTMCryo.Is_CryO_Regen_Status = False
        Me.crcTMCryo.IsOnline = False
        Me.crcTMCryo.Location = New System.Drawing.Point(1, 143)
        Me.crcTMCryo.Margin = New System.Windows.Forms.Padding(4)
        Me.crcTMCryo.Name = "crcTMCryo"
        Me.crcTMCryo.Size = New System.Drawing.Size(190, 90)
        Me.crcTMCryo.TabIndex = 140
        Me.crcTMCryo.Text = "TM Cryo"
        Me.crcTMCryo.UseBorderStyle = True
        '
        'crcTMWaterPump
        '
        Me.crcTMWaterPump.BackColor = System.Drawing.Color.Transparent
        Me.crcTMWaterPump.ButtonVisible = True
        Me.crcTMWaterPump.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcTMWaterPump.HeaderFont = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcTMWaterPump.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.crcTMWaterPump.HeaderText = "WaterPump"
        Me.crcTMWaterPump.HeaderTextColor = System.Drawing.Color.White
        Me.crcTMWaterPump.HeaderVisible = False
        Me.crcTMWaterPump.IsOnline = False
        Me.crcTMWaterPump.Location = New System.Drawing.Point(1, 236)
        Me.crcTMWaterPump.Margin = New System.Windows.Forms.Padding(4)
        Me.crcTMWaterPump.Name = "crcTMWaterPump"
        Me.crcTMWaterPump.Size = New System.Drawing.Size(190, 90)
        Me.crcTMWaterPump.TabIndex = 163
        Me.crcTMWaterPump.Text = "WaterPump"
        Me.crcTMWaterPump.UseBorderStyle = True
        '
        'RobotHand
        '
        Me.RobotHand.ArmExtendAngle = 10.0!
        Me.RobotHand.ArmHeight = 3.025023!
        Me.RobotHand.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.RobotHand.BackColor = System.Drawing.SystemColors.ControlDark
        Me.RobotHand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RobotHand.InScreen = AVPControls.AVPDataLib.AVPScreens.MaintenanceScreen
        Me.RobotHand.Location = New System.Drawing.Point(301, 98)
        Me.RobotHand.Name = "RobotHand"
        Me.RobotHand.Size = New System.Drawing.Size(396, 396)
        Me.RobotHand.TabIndex = 340
        Me.RobotHand.UndefinedStationType = AVPControls.AVPDataLib.AVPChamberTypes.PVD4
        Me.RobotHand.WaferDiameter = 35
        '
        'crcLLTurbo
        '
        Me.crcLLTurbo.BackColor = System.Drawing.Color.Transparent
        Me.crcLLTurbo.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crcLLTurbo.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.crcLLTurbo.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.crcLLTurbo.HeaderText = "TurboControl1"
        Me.crcLLTurbo.HeaderTextColor = System.Drawing.Color.White
        Me.crcLLTurbo.HeaderVisible = False
        Me.crcLLTurbo.IsOnline = False
        Me.crcLLTurbo.Location = New System.Drawing.Point(635, 646)
        Me.crcLLTurbo.Margin = New System.Windows.Forms.Padding(4)
        Me.crcLLTurbo.Name = "crcLLTurbo"
        Me.crcLLTurbo.Size = New System.Drawing.Size(190, 95)
        Me.crcLLTurbo.TabIndex = 341
        Me.crcLLTurbo.Text = "TurboControl1"
        Me.crcLLTurbo.Title = "LLA Turbo"
        Me.crcLLTurbo.UseBorderStyle = True
        Me.crcLLTurbo.Visible = False
        '
        'btnSystemSetupTestingSetup
        '
        Me.btnSystemSetupTestingSetup.Location = New System.Drawing.Point(1035, 749)
        Me.btnSystemSetupTestingSetup.Name = "btnSystemSetupTestingSetup"
        Me.btnSystemSetupTestingSetup.Size = New System.Drawing.Size(158, 23)
        Me.btnSystemSetupTestingSetup.TabIndex = 344
        Me.btnSystemSetupTestingSetup.Text = "testing setup in system setup"
        Me.btnSystemSetupTestingSetup.UseVisualStyleBackColor = True
        Me.btnSystemSetupTestingSetup.Visible = False
        '
        'lblAlignAngle
        '
        Me.lblAlignAngle.AutoSize = True
        Me.lblAlignAngle.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlignAngle.ForeColor = System.Drawing.Color.Yellow
        Me.lblAlignAngle.Location = New System.Drawing.Point(378, 428)
        Me.lblAlignAngle.Name = "lblAlignAngle"
        Me.lblAlignAngle.Size = New System.Drawing.Size(36, 15)
        Me.lblAlignAngle.TabIndex = 346
        Me.lblAlignAngle.Text = "Align"
        Me.lblAlignAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAlignAngle.Visible = False
        '
        'TMSwitchIGFilament
        '
        Me.TMSwitchIGFilament.BackColor = System.Drawing.Color.Black
        Me.TMSwitchIGFilament.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TMSwitchIGFilament.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TMSwitchIGFilament.ForeColor = System.Drawing.Color.Lime
        Me.TMSwitchIGFilament.Location = New System.Drawing.Point(554, 678)
        Me.TMSwitchIGFilament.Name = "TMSwitchIGFilament"
        Me.TMSwitchIGFilament.ReadOnly = True
        Me.TMSwitchIGFilament.Size = New System.Drawing.Size(75, 26)
        Me.TMSwitchIGFilament.TabIndex = 366
        Me.TMSwitchIGFilament.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TMSwitchIGFilament.Visible = False
        '
        'LLASwitchIGFilament
        '
        Me.LLASwitchIGFilament.BackColor = System.Drawing.Color.Black
        Me.LLASwitchIGFilament.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LLASwitchIGFilament.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LLASwitchIGFilament.ForeColor = System.Drawing.Color.Lime
        Me.LLASwitchIGFilament.Location = New System.Drawing.Point(554, 710)
        Me.LLASwitchIGFilament.Name = "LLASwitchIGFilament"
        Me.LLASwitchIGFilament.ReadOnly = True
        Me.LLASwitchIGFilament.Size = New System.Drawing.Size(75, 26)
        Me.LLASwitchIGFilament.TabIndex = 365
        Me.LLASwitchIGFilament.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LLASwitchIGFilament.Visible = False
        '
        'btnCycleATM
        '
        Me.btnCycleATM.Location = New System.Drawing.Point(957, 749)
        Me.btnCycleATM.Name = "btnCycleATM"
        Me.btnCycleATM.Size = New System.Drawing.Size(72, 23)
        Me.btnCycleATM.TabIndex = 369
        Me.btnCycleATM.Text = "Cycle ATM"
        Me.btnCycleATM.UseVisualStyleBackColor = True
        Me.btnCycleATM.Visible = False
        '
        'ValveLLAFastRough
        '
        Me.ValveLLAFastRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLAFastRough.IsCheckSafetyBeforeClick = False
        Me.ValveLLAFastRough.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveLLAFastRough.Location = New System.Drawing.Point(728, 485)
        Me.ValveLLAFastRough.Margin = New System.Windows.Forms.Padding(4)
        Me.ValveLLAFastRough.Name = "ValveLLAFastRough"
        Me.ValveLLAFastRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveLLAFastRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLAFastRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveLLAFastRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLAFastRough.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveLLAFastRough.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLAFastRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLAFastRough.TabIndex = 111
        Me.ValveLLAFastRough.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLAFastRough.TextLocIsFix = True
        Me.ValveLLAFastRough.TextValue = ""
        Me.ValveLLAFastRough.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveLLAFastRough.Unit = ""
        Me.ValveLLAFastRough.UnknownImage = Nothing
        Me.ValveLLAFastRough.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLAFastRough.UseClickedEventInForm = True
        Me.ValveLLAFastRough.UsingScientificFormat = True
        '
        'Gasline_LL_SlowVent
        '
        Me.Gasline_LL_SlowVent.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_SlowVent.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_SlowVent.Location = New System.Drawing.Point(281, 507)
        Me.Gasline_LL_SlowVent.Name = "Gasline_LL_SlowVent"
        Me.Gasline_LL_SlowVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_SlowVent
        Me.Gasline_LL_SlowVent.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_SlowVent_On
        Me.Gasline_LL_SlowVent.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_SlowVent_On_1
        Me.Gasline_LL_SlowVent.Size = New System.Drawing.Size(23, 50)
        Me.Gasline_LL_SlowVent.TabIndex = 343
        '
        'Gasline_LL_SV_N2
        '
        Me.Gasline_LL_SV_N2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_SV_N2.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_SV_N2.Location = New System.Drawing.Point(222, 542)
        Me.Gasline_LL_SV_N2.Name = "Gasline_LL_SV_N2"
        Me.Gasline_LL_SV_N2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_Part
        Me.Gasline_LL_SV_N2.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_Part_On
        Me.Gasline_LL_SV_N2.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_Part_On_1
        Me.Gasline_LL_SV_N2.Size = New System.Drawing.Size(19, 15)
        Me.Gasline_LL_SV_N2.TabIndex = 343
        '
        'Gasline_LL_FastVent
        '
        Me.Gasline_LL_FastVent.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FastVent.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FastVent.Location = New System.Drawing.Point(281, 495)
        Me.Gasline_LL_FastVent.Name = "Gasline_LL_FastVent"
        Me.Gasline_LL_FastVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_FastVent
        Me.Gasline_LL_FastVent.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_FastVent_On
        Me.Gasline_LL_FastVent.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_FastVent_On_1
        Me.Gasline_LL_FastVent.Size = New System.Drawing.Size(15, 15)
        Me.Gasline_LL_FastVent.TabIndex = 343
        '
        'Gasline_LL_FV_N2
        '
        Me.Gasline_LL_FV_N2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FV_N2.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FV_N2.Location = New System.Drawing.Point(222, 495)
        Me.Gasline_LL_FV_N2.Name = "Gasline_LL_FV_N2"
        Me.Gasline_LL_FV_N2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_Part
        Me.Gasline_LL_FV_N2.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_Part_On
        Me.Gasline_LL_FV_N2.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_Part_On_1
        Me.Gasline_LL_FV_N2.Size = New System.Drawing.Size(19, 15)
        Me.Gasline_LL_FV_N2.TabIndex = 343
        '
        'HivacValveLLA
        '
        Me.HivacValveLLA.BackgroundImage = CType(resources.GetObject("HivacValveLLA.BackgroundImage"), System.Drawing.Image)
        Me.HivacValveLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HivacValveLLA.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.HivacLLA
        Me.HivacValveLLA.Location = New System.Drawing.Point(523, 428)
        Me.HivacValveLLA.Name = "HivacValveLLA"
        Me.HivacValveLLA.Size = New System.Drawing.Size(50, 50)
        Me.HivacValveLLA.TabIndex = 311
        '
        'LLALeg
        '
        Me.LLALeg.BackColor = System.Drawing.Color.Transparent
        Me.LLALeg.BackgroundImage = CType(resources.GetObject("LLALeg.BackgroundImage"), System.Drawing.Image)
        Me.LLALeg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.LLALeg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LLALeg.Leg_In_Screen = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.LLALeg.Location = New System.Drawing.Point(456, 430)
        Me.LLALeg.Name = "LLALeg"
        Me.LLALeg.Size = New System.Drawing.Size(87, 59)
        Me.LLALeg.TabIndex = 160
        '
        'Gasline_PressureFR
        '
        Me.Gasline_PressureFR.Image = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_PressureConnect
        Me.Gasline_PressureFR.ImageSize = New System.Drawing.Size(140, 140)
        Me.Gasline_PressureFR.IsChamberPic = False
        Me.Gasline_PressureFR.IsStretch = False
        Me.Gasline_PressureFR.Location = New System.Drawing.Point(1232, 537)
        Me.Gasline_PressureFR.Margin = New System.Windows.Forms.Padding(4)
        Me.Gasline_PressureFR.Name = "Gasline_PressureFR"
        Me.Gasline_PressureFR.Size = New System.Drawing.Size(10, 44)
        Me.Gasline_PressureFR.TabIndex = 339
        Me.Gasline_PressureFR.TextColor = System.Drawing.Color.Wheat
        Me.Gasline_PressureFR.TextInImage = ""
        Me.Gasline_PressureFR.TextLocation = New System.Drawing.Point(0, 0)
        Me.Gasline_PressureFR.Visible = False
        '
        'Gasline_PressureLL_FL
        '
        Me.Gasline_PressureLL_FL.Image = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_PressureConnect
        Me.Gasline_PressureLL_FL.ImageSize = New System.Drawing.Size(140, 140)
        Me.Gasline_PressureLL_FL.IsChamberPic = False
        Me.Gasline_PressureLL_FL.IsStretch = False
        Me.Gasline_PressureLL_FL.Location = New System.Drawing.Point(673, 445)
        Me.Gasline_PressureLL_FL.Margin = New System.Windows.Forms.Padding(4)
        Me.Gasline_PressureLL_FL.Name = "Gasline_PressureLL_FL"
        Me.Gasline_PressureLL_FL.Size = New System.Drawing.Size(10, 6)
        Me.Gasline_PressureLL_FL.TabIndex = 337
        Me.Gasline_PressureLL_FL.TextColor = System.Drawing.Color.Wheat
        Me.Gasline_PressureLL_FL.TextInImage = ""
        Me.Gasline_PressureLL_FL.TextLocation = New System.Drawing.Point(0, 0)
        '
        'btnUpdateManualTransfer
        '
        Me.btnUpdateManualTransfer.BackColor = System.Drawing.SystemColors.Control
        Me.btnUpdateManualTransfer.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUpdateManualTransfer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdateManualTransfer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdateManualTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateManualTransfer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateManualTransfer.Location = New System.Drawing.Point(1131, 339)
        Me.btnUpdateManualTransfer.Name = "btnUpdateManualTransfer"
        Me.btnUpdateManualTransfer.Size = New System.Drawing.Size(149, 36)
        Me.btnUpdateManualTransfer.TabIndex = 9
        Me.btnUpdateManualTransfer.Text = "UpdateManualTransfer"
        Me.btnUpdateManualTransfer.UseVisualStyleBackColor = False
        Me.btnUpdateManualTransfer.Visible = False
        '
        'Gasline_LL_Vent
        '
        Me.Gasline_LL_Vent.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_Vent.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_Vent.Location = New System.Drawing.Point(296, 489)
        Me.Gasline_LL_Vent.Name = "Gasline_LL_Vent"
        Me.Gasline_LL_Vent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_Vent
        Me.Gasline_LL_Vent.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_Vent_On
        Me.Gasline_LL_Vent.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_Vent_On_1
        Me.Gasline_LL_Vent.Size = New System.Drawing.Size(176, 21)
        Me.Gasline_LL_Vent.TabIndex = 343
        '
        'Gasline_TM_FR_Out
        '
        Me.Gasline_TM_FR_Out.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FR_Out.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FR_Out.Location = New System.Drawing.Point(767, 401)
        Me.Gasline_TM_FR_Out.Name = "Gasline_TM_FR_Out"
        Me.Gasline_TM_FR_Out.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_1
        Me.Gasline_TM_FR_Out.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_1_On
        Me.Gasline_TM_FR_Out.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_1_On_1
        Me.Gasline_TM_FR_Out.Size = New System.Drawing.Size(153, 15)
        Me.Gasline_TM_FR_Out.TabIndex = 343
        '
        'Gasline_TM_FL_2
        '
        Me.Gasline_TM_FL_2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FL_2.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FL_2.Location = New System.Drawing.Point(788, 98)
        Me.Gasline_TM_FL_2.Name = "Gasline_TM_FL_2"
        Me.Gasline_TM_FL_2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part2
        Me.Gasline_TM_FL_2.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part2_On
        Me.Gasline_TM_FL_2.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part2_On_1
        Me.Gasline_TM_FL_2.Size = New System.Drawing.Size(21, 259)
        Me.Gasline_TM_FL_2.TabIndex = 343
        '
        'Gasline_TM_FV_N2
        '
        Me.Gasline_TM_FV_N2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FV_N2.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FV_N2.Location = New System.Drawing.Point(223, 424)
        Me.Gasline_TM_FV_N2.Name = "Gasline_TM_FV_N2"
        Me.Gasline_TM_FV_N2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_Part
        Me.Gasline_TM_FV_N2.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_Part_On
        Me.Gasline_TM_FV_N2.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_Part_On_1
        Me.Gasline_TM_FV_N2.Size = New System.Drawing.Size(19, 15)
        Me.Gasline_TM_FV_N2.TabIndex = 343
        '
        'Gasline_PressureTM_FL
        '
        Me.Gasline_PressureTM_FL.Image = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_PressureConnect
        Me.Gasline_PressureTM_FL.ImageSize = New System.Drawing.Size(140, 140)
        Me.Gasline_PressureTM_FL.IsChamberPic = False
        Me.Gasline_PressureTM_FL.IsStretch = False
        Me.Gasline_PressureTM_FL.Location = New System.Drawing.Point(693, 57)
        Me.Gasline_PressureTM_FL.Margin = New System.Windows.Forms.Padding(4)
        Me.Gasline_PressureTM_FL.Name = "Gasline_PressureTM_FL"
        Me.Gasline_PressureTM_FL.Size = New System.Drawing.Size(10, 44)
        Me.Gasline_PressureTM_FL.TabIndex = 336
        Me.Gasline_PressureTM_FL.TextColor = System.Drawing.Color.Wheat
        Me.Gasline_PressureTM_FL.TextInImage = ""
        Me.Gasline_PressureTM_FL.TextLocation = New System.Drawing.Point(0, 0)
        '
        'Gasline_TM_FL_3
        '
        Me.Gasline_TM_FL_3.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FL_3.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FL_3.Location = New System.Drawing.Point(794, 357)
        Me.Gasline_TM_FL_3.Name = "Gasline_TM_FL_3"
        Me.Gasline_TM_FL_3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part3
        Me.Gasline_TM_FL_3.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part3_On
        Me.Gasline_TM_FL_3.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part3_On_1
        Me.Gasline_TM_FL_3.Size = New System.Drawing.Size(15, 47)
        Me.Gasline_TM_FL_3.TabIndex = 343
        '
        'btnTurboRelayIndicator_LLA
        '
        Me.btnTurboRelayIndicator_LLA.AccessibleName = "TurboLLA"
        Me.btnTurboRelayIndicator_LLA.BackColor = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_LLA.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnTurboRelayIndicator_LLA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboRelayIndicator_LLA.Clickable = True
        Me.btnTurboRelayIndicator_LLA.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_LLA.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnTurboRelayIndicator_LLA.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnTurboRelayIndicator_LLA.FlatAppearance.BorderSize = 0
        Me.btnTurboRelayIndicator_LLA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnTurboRelayIndicator_LLA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnTurboRelayIndicator_LLA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboRelayIndicator_LLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurboRelayIndicator_LLA.ForeColor = System.Drawing.Color.White
        Me.btnTurboRelayIndicator_LLA.Location = New System.Drawing.Point(596, 419)
        Me.btnTurboRelayIndicator_LLA.MessageBoxText = Nothing
        Me.btnTurboRelayIndicator_LLA.Name = "btnTurboRelayIndicator_LLA"
        Me.btnTurboRelayIndicator_LLA.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnTurboRelayIndicator_LLA.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOn
        Me.btnTurboRelayIndicator_LLA.Size = New System.Drawing.Size(10, 10)
        Me.btnTurboRelayIndicator_LLA.TabIndex = 285
        Me.btnTurboRelayIndicator_LLA.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnTurboRelayIndicator_LLA.UseClickedEventInForm = True
        Me.btnTurboRelayIndicator_LLA.UseVisualStyleBackColor = False
        Me.btnTurboRelayIndicator_LLA.ValueToBeSend = ""
        '
        'Gasline_TM_FL_4
        '
        Me.Gasline_TM_FL_4.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FL_4.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FL_4.Location = New System.Drawing.Point(794, 404)
        Me.Gasline_TM_FL_4.Name = "Gasline_TM_FL_4"
        Me.Gasline_TM_FL_4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part3
        Me.Gasline_TM_FL_4.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part3_On_1
        Me.Gasline_TM_FL_4.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part3_On
        Me.Gasline_TM_FL_4.Size = New System.Drawing.Size(15, 47)
        Me.Gasline_TM_FL_4.TabIndex = 343
        '
        'btnTurboLLA
        '
        Me.btnTurboLLA.AccessibleName = "TurboLLA"
        Me.btnTurboLLA.BackColor = System.Drawing.Color.Transparent
        Me.btnTurboLLA.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnTurboLLA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboLLA.Clickable = True
        Me.btnTurboLLA.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurboLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurboLLA.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTurboLLA.FlatAppearance.BorderSize = 0
        Me.btnTurboLLA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboLLA.Font = New System.Drawing.Font("Times New Roman", 7.0!)
        Me.btnTurboLLA.ForeColor = System.Drawing.Color.White
        Me.btnTurboLLA.Location = New System.Drawing.Point(561, 446)
        Me.btnTurboLLA.MessageBoxText = Nothing
        Me.btnTurboLLA.Name = "btnTurboLLA"
        Me.btnTurboLLA.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnTurboLLA.OffText = "OFF"
        Me.btnTurboLLA.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTurboLLA.OnText = "ON"
        Me.btnTurboLLA.Size = New System.Drawing.Size(38, 20)
        Me.btnTurboLLA.TabIndex = 255
        Me.btnTurboLLA.Text = "OFF"
        Me.btnTurboLLA.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTurboLLA.UnKnownText = "Ramp"
        Me.btnTurboLLA.UseClickedEventInForm = True
        Me.btnTurboLLA.UseVisualStyleBackColor = False
        Me.btnTurboLLA.ValueToBeSend = ""
        '
        'Gasline_TM_FL_FR
        '
        Me.Gasline_TM_FL_FR.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FL_FR.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FL_FR.Location = New System.Drawing.Point(920, 404)
        Me.Gasline_TM_FL_FR.Name = "Gasline_TM_FL_FR"
        Me.Gasline_TM_FL_FR.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2
        Me.Gasline_TM_FL_FR.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2_On
        Me.Gasline_TM_FL_FR.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2_On_1
        Me.Gasline_TM_FL_FR.Size = New System.Drawing.Size(164, 9)
        Me.Gasline_TM_FL_FR.TabIndex = 343
        '
        'Gasline_TM_FL_End1
        '
        Me.Gasline_TM_FL_End1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FL_End1.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FL_End1.Location = New System.Drawing.Point(794, 451)
        Me.Gasline_TM_FL_End1.Name = "Gasline_TM_FL_End1"
        Me.Gasline_TM_FL_End1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd
        Me.Gasline_TM_FL_End1.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd_On
        Me.Gasline_TM_FL_End1.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd_On_1
        Me.Gasline_TM_FL_End1.Size = New System.Drawing.Size(15, 47)
        Me.Gasline_TM_FL_End1.TabIndex = 343
        '
        'PumpLLA
        '
        Me.PumpLLA.BackgroundImage = CType(resources.GetObject("PumpLLA.BackgroundImage"), System.Drawing.Image)
        Me.PumpLLA.DockPosition = AVP_Robot_Project.PumpChamber.PumpDockPositions.LoadLock
        Me.PumpLLA.Location = New System.Drawing.Point(548, 420)
        Me.PumpLLA.Name = "PumpLLA"
        Me.PumpLLA.Size = New System.Drawing.Size(67, 67)
        Me.PumpLLA.TabIndex = 313
        '
        'Gasline_LL_FL_221
        '
        Me.Gasline_LL_FL_221.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FL_221.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FL_221.Location = New System.Drawing.Point(920, 451)
        Me.Gasline_LL_FL_221.Name = "Gasline_LL_FL_221"
        Me.Gasline_LL_FL_221.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2
        Me.Gasline_LL_FL_221.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2_On
        Me.Gasline_LL_FL_221.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2_On_1
        Me.Gasline_LL_FL_221.Size = New System.Drawing.Size(164, 9)
        Me.Gasline_LL_FL_221.TabIndex = 343
        '
        'btnTurboRelayIndicator_TM
        '
        Me.btnTurboRelayIndicator_TM.AccessibleName = "TurboLLA"
        Me.btnTurboRelayIndicator_TM.BackColor = System.Drawing.Color.Transparent
        Me.btnTurboRelayIndicator_TM.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnTurboRelayIndicator_TM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboRelayIndicator_TM.Clickable = True
        Me.btnTurboRelayIndicator_TM.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurboRelayIndicator_TM.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnTurboRelayIndicator_TM.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnTurboRelayIndicator_TM.FlatAppearance.BorderSize = 0
        Me.btnTurboRelayIndicator_TM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnTurboRelayIndicator_TM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnTurboRelayIndicator_TM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboRelayIndicator_TM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurboRelayIndicator_TM.ForeColor = System.Drawing.Color.White
        Me.btnTurboRelayIndicator_TM.Location = New System.Drawing.Point(680, 21)
        Me.btnTurboRelayIndicator_TM.MessageBoxText = Nothing
        Me.btnTurboRelayIndicator_TM.Name = "btnTurboRelayIndicator_TM"
        Me.btnTurboRelayIndicator_TM.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnTurboRelayIndicator_TM.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOn
        Me.btnTurboRelayIndicator_TM.Size = New System.Drawing.Size(10, 10)
        Me.btnTurboRelayIndicator_TM.TabIndex = 285
        Me.btnTurboRelayIndicator_TM.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnTurboRelayIndicator_TM.UseClickedEventInForm = True
        Me.btnTurboRelayIndicator_TM.UseVisualStyleBackColor = False
        Me.btnTurboRelayIndicator_TM.ValueToBeSend = ""
        '
        'MesaValvePM2
        '
        Me.MesaValvePM2.BackgroundImage = CType(resources.GetObject("MesaValvePM2.BackgroundImage"), System.Drawing.Image)
        Me.MesaValvePM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValvePM2.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.PM2
        Me.MesaValvePM2.Location = New System.Drawing.Point(458, 161)
        Me.MesaValvePM2.Name = "MesaValvePM2"
        Me.MesaValvePM2.Size = New System.Drawing.Size(84, 84)
        Me.MesaValvePM2.TabIndex = 305
        '
        'MesaValveLLA
        '
        Me.MesaValveLLA.BackgroundImage = CType(resources.GetObject("MesaValveLLA.BackgroundImage"), System.Drawing.Image)
        Me.MesaValveLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValveLLA.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.LLA
        Me.MesaValveLLA.Location = New System.Drawing.Point(458, 379)
        Me.MesaValveLLA.Name = "MesaValveLLA"
        Me.MesaValveLLA.Size = New System.Drawing.Size(84, 84)
        Me.MesaValveLLA.TabIndex = 307
        '
        'MesaValvePM3
        '
        Me.MesaValvePM3.BackgroundImage = CType(resources.GetObject("MesaValvePM3.BackgroundImage"), System.Drawing.Image)
        Me.MesaValvePM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValvePM3.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.PM3
        Me.MesaValvePM3.Location = New System.Drawing.Point(550, 254)
        Me.MesaValvePM3.Name = "MesaValvePM3"
        Me.MesaValvePM3.Size = New System.Drawing.Size(84, 84)
        Me.MesaValvePM3.TabIndex = 306
        '
        'btnTurboTM
        '
        Me.btnTurboTM.AccessibleName = "TurboTM"
        Me.btnTurboTM.BackColor = System.Drawing.Color.Transparent
        Me.btnTurboTM.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnTurboTM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboTM.Clickable = True
        Me.btnTurboTM.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurboTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurboTM.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTurboTM.FlatAppearance.BorderSize = 0
        Me.btnTurboTM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboTM.Font = New System.Drawing.Font("Times New Roman", 7.0!)
        Me.btnTurboTM.ForeColor = System.Drawing.Color.White
        Me.btnTurboTM.Location = New System.Drawing.Point(579, 190)
        Me.btnTurboTM.MessageBoxText = Nothing
        Me.btnTurboTM.Name = "btnTurboTM"
        Me.btnTurboTM.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnTurboTM.OffText = "OFF"
        Me.btnTurboTM.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTurboTM.OnText = "ON"
        Me.btnTurboTM.Size = New System.Drawing.Size(38, 20)
        Me.btnTurboTM.TabIndex = 257
        Me.btnTurboTM.Text = "OFF"
        Me.btnTurboTM.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTurboTM.UnKnownText = "Ramp"
        Me.btnTurboTM.UseClickedEventInForm = True
        Me.btnTurboTM.UseVisualStyleBackColor = False
        Me.btnTurboTM.ValueToBeSend = ""
        '
        'Gasline_TM_FL_1
        '
        Me.Gasline_TM_FL_1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FL_1.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FL_1.Location = New System.Drawing.Point(757, 98)
        Me.Gasline_TM_FL_1.Name = "Gasline_TM_FL_1"
        Me.Gasline_TM_FL_1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part1
        Me.Gasline_TM_FL_1.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part1_On
        Me.Gasline_TM_FL_1.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_Part1_On_1
        Me.Gasline_TM_FL_1.Size = New System.Drawing.Size(31, 15)
        Me.Gasline_TM_FL_1.TabIndex = 343
        '
        'Gasline_LL_FR_221
        '
        Me.Gasline_LL_FR_221.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FR_221.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FR_221.Location = New System.Drawing.Point(920, 498)
        Me.Gasline_LL_FR_221.Name = "Gasline_LL_FR_221"
        Me.Gasline_LL_FR_221.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2
        Me.Gasline_LL_FR_221.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2_On
        Me.Gasline_LL_FR_221.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2_On_1
        Me.Gasline_LL_FR_221.Size = New System.Drawing.Size(164, 9)
        Me.Gasline_LL_FR_221.TabIndex = 343
        '
        'MesaValvePM1
        '
        Me.MesaValvePM1.BackgroundImage = CType(resources.GetObject("MesaValvePM1.BackgroundImage"), System.Drawing.Image)
        Me.MesaValvePM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValvePM1.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.PM1
        Me.MesaValvePM1.Location = New System.Drawing.Point(365, 253)
        Me.MesaValvePM1.Name = "MesaValvePM1"
        Me.MesaValvePM1.Size = New System.Drawing.Size(84, 84)
        Me.MesaValvePM1.TabIndex = 304
        '
        'Gasline_LL_FL_1
        '
        Me.Gasline_LL_FL_1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FL_1.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FL_1.Location = New System.Drawing.Point(728, 448)
        Me.Gasline_LL_FL_1.Name = "Gasline_LL_FL_1"
        Me.Gasline_LL_FL_1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_LL
        Me.Gasline_LL_FL_1.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_LL_On
        Me.Gasline_LL_FL_1.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_LL_On_1
        Me.Gasline_LL_FL_1.Size = New System.Drawing.Size(192, 15)
        Me.Gasline_LL_FL_1.TabIndex = 343
        '
        'Gasline_LL_Pump_PartEnd
        '
        Me.Gasline_LL_Pump_PartEnd.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_Pump_PartEnd.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_Pump_PartEnd.Location = New System.Drawing.Point(920, 401)
        Me.Gasline_LL_Pump_PartEnd.Name = "Gasline_LL_Pump_PartEnd"
        Me.Gasline_LL_Pump_PartEnd.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Corner
        Me.Gasline_LL_Pump_PartEnd.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Corner_On
        Me.Gasline_LL_Pump_PartEnd.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Corner_On_1
        Me.Gasline_LL_Pump_PartEnd.Size = New System.Drawing.Size(24, 24)
        Me.Gasline_LL_Pump_PartEnd.TabIndex = 343
        '
        'Gasline_LL_FR_1
        '
        Me.Gasline_LL_FR_1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FR_1.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FR_1.Location = New System.Drawing.Point(767, 495)
        Me.Gasline_LL_FR_1.Name = "Gasline_LL_FR_1"
        Me.Gasline_LL_FR_1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_1
        Me.Gasline_LL_FR_1.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_1_On
        Me.Gasline_LL_FR_1.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_1_On_1
        Me.Gasline_LL_FR_1.Size = New System.Drawing.Size(153, 15)
        Me.Gasline_LL_FR_1.TabIndex = 343
        '
        'Gasline_TM_FL_End2
        '
        Me.Gasline_TM_FL_End2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FL_End2.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FL_End2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd2
        Me.Gasline_TM_FL_End2.Location = New System.Drawing.Point(794, 357)
        Me.Gasline_TM_FL_End2.Name = "Gasline_TM_FL_End2"
        Me.Gasline_TM_FL_End2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd2
        Me.Gasline_TM_FL_End2.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd2_On
        Me.Gasline_TM_FL_End2.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd2_On_1
        Me.Gasline_TM_FL_End2.Size = New System.Drawing.Size(126, 59)
        Me.Gasline_TM_FL_End2.TabIndex = 343
        '
        'Gasline_LL_FL_222
        '
        Me.Gasline_LL_FL_222.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FL_222.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FL_222.Location = New System.Drawing.Point(1084, 448)
        Me.Gasline_LL_FL_222.Name = "Gasline_LL_FL_222"
        Me.Gasline_LL_FL_222.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_3
        Me.Gasline_LL_FL_222.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_3_On
        Me.Gasline_LL_FL_222.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_3_On_1
        Me.Gasline_LL_FL_222.Size = New System.Drawing.Size(12, 15)
        Me.Gasline_LL_FL_222.TabIndex = 343
        '
        'Gasline_TM_Pump_PartEnd
        '
        Me.Gasline_TM_Pump_PartEnd.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_Pump_PartEnd.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_Pump_PartEnd.Location = New System.Drawing.Point(1084, 401)
        Me.Gasline_TM_Pump_PartEnd.Name = "Gasline_TM_Pump_PartEnd"
        Me.Gasline_TM_Pump_PartEnd.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Corner
        Me.Gasline_TM_Pump_PartEnd.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Corner_On
        Me.Gasline_TM_Pump_PartEnd.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Corner_On_1
        Me.Gasline_TM_Pump_PartEnd.Size = New System.Drawing.Size(24, 24)
        Me.Gasline_TM_Pump_PartEnd.TabIndex = 343
        '
        'Gasline_LL_SR_221
        '
        Me.Gasline_LL_SR_221.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_SR_221.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_SR_221.Location = New System.Drawing.Point(920, 545)
        Me.Gasline_LL_SR_221.Name = "Gasline_LL_SR_221"
        Me.Gasline_LL_SR_221.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2
        Me.Gasline_LL_SR_221.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2_On
        Me.Gasline_LL_SR_221.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_2_On_1
        Me.Gasline_LL_SR_221.Size = New System.Drawing.Size(164, 9)
        Me.Gasline_LL_SR_221.TabIndex = 343
        '
        'Gasline_LL_SR_1
        '
        Me.Gasline_LL_SR_1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_SR_1.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_SR_1.Location = New System.Drawing.Point(767, 542)
        Me.Gasline_LL_SR_1.Name = "Gasline_LL_SR_1"
        Me.Gasline_LL_SR_1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_1
        Me.Gasline_LL_SR_1.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_1_On
        Me.Gasline_LL_SR_1.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_1_On_1
        Me.Gasline_LL_SR_1.Size = New System.Drawing.Size(153, 15)
        Me.Gasline_LL_SR_1.TabIndex = 343
        '
        'Gasline_LL_Foreline
        '
        Me.Gasline_LL_Foreline.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_Foreline.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_Foreline.Location = New System.Drawing.Point(607, 448)
        Me.Gasline_LL_Foreline.Name = "Gasline_LL_Foreline"
        Me.Gasline_LL_Foreline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_Foreline_1
        Me.Gasline_LL_Foreline.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_Foreline_1_On
        Me.Gasline_LL_Foreline.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_Foreline_1_On_1
        Me.Gasline_LL_Foreline.Size = New System.Drawing.Size(82, 15)
        Me.Gasline_LL_Foreline.TabIndex = 343
        '
        'Gasline_LL_Pump_Part4
        '
        Me.Gasline_LL_Pump_Part4.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_Pump_Part4.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_Pump_Part4.Location = New System.Drawing.Point(932, 424)
        Me.Gasline_LL_Pump_Part4.Name = "Gasline_LL_Pump_Part4"
        Me.Gasline_LL_Pump_Part4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart
        Me.Gasline_LL_Pump_Part4.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On
        Me.Gasline_LL_Pump_Part4.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On_1
        Me.Gasline_LL_Pump_Part4.Size = New System.Drawing.Size(9, 48)
        Me.Gasline_LL_Pump_Part4.TabIndex = 343
        '
        'Gasline_TM_Pump_Part4
        '
        Me.Gasline_TM_Pump_Part4.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_Pump_Part4.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_Pump_Part4.Location = New System.Drawing.Point(1096, 424)
        Me.Gasline_TM_Pump_Part4.Name = "Gasline_TM_Pump_Part4"
        Me.Gasline_TM_Pump_Part4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart
        Me.Gasline_TM_Pump_Part4.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On
        Me.Gasline_TM_Pump_Part4.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On_1
        Me.Gasline_TM_Pump_Part4.Size = New System.Drawing.Size(9, 48)
        Me.Gasline_TM_Pump_Part4.TabIndex = 343
        '
        'PumpTM
        '
        Me.PumpTM.BackgroundImage = CType(resources.GetObject("PumpTM.BackgroundImage"), System.Drawing.Image)
        Me.PumpTM.Location = New System.Drawing.Point(565, 167)
        Me.PumpTM.Name = "PumpTM"
        Me.PumpTM.Size = New System.Drawing.Size(67, 67)
        Me.PumpTM.TabIndex = 312
        '
        'Gasline_LL_FastRough
        '
        Me.Gasline_LL_FastRough.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FastRough.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FastRough.Location = New System.Drawing.Point(703, 495)
        Me.Gasline_LL_FastRough.Name = "Gasline_LL_FastRough"
        Me.Gasline_LL_FastRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_FastRough_1
        Me.Gasline_LL_FastRough.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_FastRough_1_On
        Me.Gasline_LL_FastRough.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_FastRough_1_On_1
        Me.Gasline_LL_FastRough.Size = New System.Drawing.Size(25, 15)
        Me.Gasline_LL_FastRough.TabIndex = 343
        '
        'Gasline_TM_Foreline
        '
        Me.Gasline_TM_Foreline.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_Foreline.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_Foreline.Location = New System.Drawing.Point(610, 98)
        Me.Gasline_TM_Foreline.Name = "Gasline_TM_Foreline"
        Me.Gasline_TM_Foreline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_TM_Foreline_1
        Me.Gasline_TM_Foreline.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_TM_Foreline_1_On
        Me.Gasline_TM_Foreline.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_TM_Foreline_1_On_1
        Me.Gasline_TM_Foreline.Size = New System.Drawing.Size(108, 90)
        Me.Gasline_TM_Foreline.TabIndex = 343
        '
        'Gasline_LL_FL_21
        '
        Me.Gasline_LL_FL_21.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FL_21.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FL_21.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1
        Me.Gasline_LL_FL_21.Location = New System.Drawing.Point(920, 448)
        Me.Gasline_LL_FL_21.Name = "Gasline_LL_FL_21"
        Me.Gasline_LL_FL_21.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1
        Me.Gasline_LL_FL_21.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1_On
        Me.Gasline_LL_FL_21.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1_On_1
        Me.Gasline_LL_FL_21.Size = New System.Drawing.Size(12, 15)
        Me.Gasline_LL_FL_21.TabIndex = 343
        '
        'Gasline_LL_FR_222
        '
        Me.Gasline_LL_FR_222.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FR_222.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FR_222.Location = New System.Drawing.Point(1084, 495)
        Me.Gasline_LL_FR_222.Name = "Gasline_LL_FR_222"
        Me.Gasline_LL_FR_222.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_3
        Me.Gasline_LL_FR_222.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_3_On
        Me.Gasline_LL_FR_222.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_3_On_1
        Me.Gasline_LL_FR_222.Size = New System.Drawing.Size(12, 15)
        Me.Gasline_LL_FR_222.TabIndex = 343
        '
        'HivacValveTM
        '
        Me.HivacValveTM.BackgroundImage = CType(resources.GetObject("HivacValveTM.BackgroundImage"), System.Drawing.Image)
        Me.HivacValveTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HivacValveTM.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.HivacTM
        Me.HivacValveTM.Location = New System.Drawing.Point(549, 199)
        Me.HivacValveTM.Name = "HivacValveTM"
        Me.HivacValveTM.Size = New System.Drawing.Size(50, 50)
        Me.HivacValveTM.TabIndex = 308
        '
        'Gasline_LL_Pump_Part3
        '
        Me.Gasline_LL_Pump_Part3.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_Pump_Part3.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_Pump_Part3.Location = New System.Drawing.Point(932, 472)
        Me.Gasline_LL_Pump_Part3.Name = "Gasline_LL_Pump_Part3"
        Me.Gasline_LL_Pump_Part3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart
        Me.Gasline_LL_Pump_Part3.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On
        Me.Gasline_LL_Pump_Part3.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On_1
        Me.Gasline_LL_Pump_Part3.Size = New System.Drawing.Size(9, 48)
        Me.Gasline_LL_Pump_Part3.TabIndex = 343
        '
        'Gasline_LL_FR_21
        '
        Me.Gasline_LL_FR_21.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_FR_21.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_FR_21.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1
        Me.Gasline_LL_FR_21.Location = New System.Drawing.Point(920, 495)
        Me.Gasline_LL_FR_21.Name = "Gasline_LL_FR_21"
        Me.Gasline_LL_FR_21.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1
        Me.Gasline_LL_FR_21.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1_On
        Me.Gasline_LL_FR_21.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1_On_1
        Me.Gasline_LL_FR_21.Size = New System.Drawing.Size(12, 15)
        Me.Gasline_LL_FR_21.TabIndex = 343
        '
        'Gasline_LL_Rough
        '
        Me.Gasline_LL_Rough.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_Rough.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_Rough.Location = New System.Drawing.Point(527, 489)
        Me.Gasline_LL_Rough.Name = "Gasline_LL_Rough"
        Me.Gasline_LL_Rough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_Rough_1
        Me.Gasline_LL_Rough.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_Rough_1_On
        Me.Gasline_LL_Rough.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_Rough_1_On_1
        Me.Gasline_LL_Rough.Size = New System.Drawing.Size(176, 21)
        Me.Gasline_LL_Rough.TabIndex = 343
        '
        'Gasline_TM_Pump_Part3
        '
        Me.Gasline_TM_Pump_Part3.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_Pump_Part3.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_Pump_Part3.Location = New System.Drawing.Point(1096, 472)
        Me.Gasline_TM_Pump_Part3.Name = "Gasline_TM_Pump_Part3"
        Me.Gasline_TM_Pump_Part3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart
        Me.Gasline_TM_Pump_Part3.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On
        Me.Gasline_TM_Pump_Part3.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On_1
        Me.Gasline_TM_Pump_Part3.Size = New System.Drawing.Size(9, 48)
        Me.Gasline_TM_Pump_Part3.TabIndex = 343
        '
        'Gasline_LL_SR_21
        '
        Me.Gasline_LL_SR_21.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_SR_21.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_SR_21.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1
        Me.Gasline_LL_SR_21.Location = New System.Drawing.Point(920, 542)
        Me.Gasline_LL_SR_21.Name = "Gasline_LL_SR_21"
        Me.Gasline_LL_SR_21.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1
        Me.Gasline_LL_SR_21.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1_On
        Me.Gasline_LL_SR_21.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_2_1_On_1
        Me.Gasline_LL_SR_21.Size = New System.Drawing.Size(12, 15)
        Me.Gasline_LL_SR_21.TabIndex = 343
        '
        'Gasline_LL_Pump_Part2
        '
        Me.Gasline_LL_Pump_Part2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_Pump_Part2.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_Pump_Part2.Location = New System.Drawing.Point(932, 519)
        Me.Gasline_LL_Pump_Part2.Name = "Gasline_LL_Pump_Part2"
        Me.Gasline_LL_Pump_Part2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart
        Me.Gasline_LL_Pump_Part2.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On
        Me.Gasline_LL_Pump_Part2.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On_1
        Me.Gasline_LL_Pump_Part2.Size = New System.Drawing.Size(9, 48)
        Me.Gasline_LL_Pump_Part2.TabIndex = 343
        '
        'Gasline_LL_SR_222
        '
        Me.Gasline_LL_SR_222.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_SR_222.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_SR_222.Location = New System.Drawing.Point(1084, 542)
        Me.Gasline_LL_SR_222.Name = "Gasline_LL_SR_222"
        Me.Gasline_LL_SR_222.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_3
        Me.Gasline_LL_SR_222.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_3_On
        Me.Gasline_LL_SR_222.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_3_On_1
        Me.Gasline_LL_SR_222.Size = New System.Drawing.Size(12, 15)
        Me.Gasline_LL_SR_222.TabIndex = 343
        '
        'Gasline_TM_Pump_Part2
        '
        Me.Gasline_TM_Pump_Part2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_Pump_Part2.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_Pump_Part2.Location = New System.Drawing.Point(1096, 519)
        Me.Gasline_TM_Pump_Part2.Name = "Gasline_TM_Pump_Part2"
        Me.Gasline_TM_Pump_Part2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart
        Me.Gasline_TM_Pump_Part2.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On
        Me.Gasline_TM_Pump_Part2.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_PumpPart_On_1
        Me.Gasline_TM_Pump_Part2.Size = New System.Drawing.Size(9, 48)
        Me.Gasline_TM_Pump_Part2.TabIndex = 343
        '
        'btnMechineTool
        '
        Me.btnMechineTool.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnMechineTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMechineTool.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMechineTool.FlatAppearance.BorderSize = 0
        Me.btnMechineTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMechineTool.Location = New System.Drawing.Point(427, 383)
        Me.btnMechineTool.Name = "btnMechineTool"
        Me.btnMechineTool.Size = New System.Drawing.Size(30, 28)
        Me.btnMechineTool.TabIndex = 129
        Me.btnMechineTool.UseVisualStyleBackColor = True
        '
        'Gasline_LL_SlowRough
        '
        Me.Gasline_LL_SlowRough.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_SlowRough.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_SlowRough.Location = New System.Drawing.Point(695, 507)
        Me.Gasline_LL_SlowRough.Name = "Gasline_LL_SlowRough"
        Me.Gasline_LL_SlowRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_SlowRough_1
        Me.Gasline_LL_SlowRough.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_SlowRough_1_On
        Me.Gasline_LL_SlowRough.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_LL_SlowRough_1_On_1
        Me.Gasline_LL_SlowRough.Size = New System.Drawing.Size(33, 50)
        Me.Gasline_LL_SlowRough.TabIndex = 343
        '
        'btnFakeProcessCompleteChime
        '
        Me.btnFakeProcessCompleteChime.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnFakeProcessCompleteChime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFakeProcessCompleteChime.Clickable = True
        Me.btnFakeProcessCompleteChime.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnFakeProcessCompleteChime.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnFakeProcessCompleteChime.ColorText_OnStatus = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnFakeProcessCompleteChime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFakeProcessCompleteChime.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnFakeProcessCompleteChime.FlatAppearance.BorderSize = 0
        Me.btnFakeProcessCompleteChime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFakeProcessCompleteChime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFakeProcessCompleteChime.ForeColor = System.Drawing.Color.Black
        Me.btnFakeProcessCompleteChime.Location = New System.Drawing.Point(1154, 306)
        Me.btnFakeProcessCompleteChime.MessageBoxText = Nothing
        Me.btnFakeProcessCompleteChime.Name = "btnFakeProcessCompleteChime"
        Me.btnFakeProcessCompleteChime.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnFakeProcessCompleteChime.OffText = "Fake Process"
        Me.btnFakeProcessCompleteChime.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnFakeProcessCompleteChime.OnText = "Fake Process"
        Me.btnFakeProcessCompleteChime.Size = New System.Drawing.Size(125, 31)
        Me.btnFakeProcessCompleteChime.TabIndex = 244
        Me.btnFakeProcessCompleteChime.Text = "Fake Process"
        Me.btnFakeProcessCompleteChime.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnFakeProcessCompleteChime.UseClickedEventInForm = True
        Me.btnFakeProcessCompleteChime.UseVisualStyleBackColor = True
        Me.btnFakeProcessCompleteChime.ValueToBeSend = ""
        Me.btnFakeProcessCompleteChime.Visible = False
        '
        'ValveLLATurbo
        '
        Me.ValveLLATurbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLATurbo.IsCheckSafetyBeforeClick = False
        Me.ValveLLATurbo.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveLLATurbo.Location = New System.Drawing.Point(689, 439)
        Me.ValveLLATurbo.Margin = New System.Windows.Forms.Padding(4)
        Me.ValveLLATurbo.Name = "ValveLLATurbo"
        Me.ValveLLATurbo.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveLLATurbo.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLATurbo.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveLLATurbo.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLATurbo.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveLLATurbo.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLATurbo.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLATurbo.TabIndex = 247
        Me.ValveLLATurbo.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLATurbo.TextLocIsFix = True
        Me.ValveLLATurbo.TextValue = ""
        Me.ValveLLATurbo.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveLLATurbo.Unit = ""
        Me.ValveLLATurbo.UnknownImage = Nothing
        Me.ValveLLATurbo.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLATurbo.UseClickedEventInForm = True
        Me.ValveLLATurbo.UsingScientificFormat = True
        '
        'Gasline_LL_Pump_Part1
        '
        Me.Gasline_LL_Pump_Part1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_LL_Pump_Part1.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_LL_Pump_Part1.Location = New System.Drawing.Point(929, 567)
        Me.Gasline_LL_Pump_Part1.Name = "Gasline_LL_Pump_Part1"
        Me.Gasline_LL_Pump_Part1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Pump
        Me.Gasline_LL_Pump_Part1.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Pump_On
        Me.Gasline_LL_Pump_Part1.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Pump_On_1
        Me.Gasline_LL_Pump_Part1.Size = New System.Drawing.Size(15, 61)
        Me.Gasline_LL_Pump_Part1.TabIndex = 343
        '
        'btnCancelMove
        '
        Me.btnCancelMove.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancelMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelMove.Clickable = True
        Me.btnCancelMove.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnCancelMove.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCancelMove.ColorText_OnStatus = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnCancelMove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelMove.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancelMove.FlatAppearance.BorderSize = 0
        Me.btnCancelMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelMove.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelMove.ForeColor = System.Drawing.Color.Black
        Me.btnCancelMove.Location = New System.Drawing.Point(1154, 272)
        Me.btnCancelMove.MessageBoxText = Nothing
        Me.btnCancelMove.Name = "btnCancelMove"
        Me.btnCancelMove.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancelMove.OffText = "Cancel Move"
        Me.btnCancelMove.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancelMove.OnText = "Cancel Move"
        Me.btnCancelMove.Size = New System.Drawing.Size(125, 31)
        Me.btnCancelMove.TabIndex = 244
        Me.btnCancelMove.Text = "Cancel Move"
        Me.btnCancelMove.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancelMove.UseClickedEventInForm = True
        Me.btnCancelMove.UseVisualStyleBackColor = True
        Me.btnCancelMove.ValueToBeSend = ""
        '
        'Gasline_TM_Pump_Part1
        '
        Me.Gasline_TM_Pump_Part1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_Pump_Part1.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_Pump_Part1.Location = New System.Drawing.Point(1093, 567)
        Me.Gasline_TM_Pump_Part1.Name = "Gasline_TM_Pump_Part1"
        Me.Gasline_TM_Pump_Part1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Pump
        Me.Gasline_TM_Pump_Part1.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Pump_On
        Me.Gasline_TM_Pump_Part1.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_RoughLine_Pump_On_1
        Me.Gasline_TM_Pump_Part1.Size = New System.Drawing.Size(15, 61)
        Me.Gasline_TM_Pump_Part1.TabIndex = 343
        '
        'btnTMProtectedMode
        '
        Me.btnTMProtectedMode.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMProtectedMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMProtectedMode.Clickable = True
        Me.btnTMProtectedMode.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMProtectedMode.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTMProtectedMode.ColorText_UnknowStatus = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnTMProtectedMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTMProtectedMode.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTMProtectedMode.FlatAppearance.BorderSize = 0
        Me.btnTMProtectedMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTMProtectedMode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTMProtectedMode.ForeColor = System.Drawing.Color.Black
        Me.btnTMProtectedMode.Location = New System.Drawing.Point(1154, 238)
        Me.btnTMProtectedMode.MessageBoxText = Nothing
        Me.btnTMProtectedMode.Name = "btnTMProtectedMode"
        Me.btnTMProtectedMode.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMProtectedMode.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTMProtectedMode.Size = New System.Drawing.Size(125, 31)
        Me.btnTMProtectedMode.TabIndex = 241
        Me.btnTMProtectedMode.Text = "Override Mode"
        Me.btnTMProtectedMode.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMProtectedMode.UseClickedEventInForm = True
        Me.btnTMProtectedMode.UseVisualStyleBackColor = True
        Me.btnTMProtectedMode.ValueToBeSend = ""
        '
        'ibsHivacButton
        '
        Me.ibsHivacButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ibsHivacButton.Location = New System.Drawing.Point(683, 616)
        Me.ibsHivacButton.Margin = New System.Windows.Forms.Padding(4)
        Me.ibsHivacButton.Name = "ibsHivacButton"
        Me.ibsHivacButton.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SlitValve_Close
        Me.ibsHivacButton.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.SlitValve_Open
        Me.ibsHivacButton.Size = New System.Drawing.Size(84, 19)
        Me.ibsHivacButton.Status = AVP_Robot_Project.ThirdStatusControl.DisplayStatus.Unknown
        Me.ibsHivacButton.TabIndex = 123
        Me.ibsHivacButton.UnknowImage = Global.AVP_Robot_Project.My.Resources.Resources.SlitValve_Unknown
        Me.ibsHivacButton.Visible = False
        '
        'btnRelayIndicatorPump2
        '
        Me.btnRelayIndicatorPump2.AccessibleName = "TurboLLA"
        Me.btnRelayIndicatorPump2.BackColor = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRelayIndicatorPump2.Clickable = True
        Me.btnRelayIndicatorPump2.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRelayIndicatorPump2.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump2.FlatAppearance.BorderSize = 0
        Me.btnRelayIndicatorPump2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelayIndicatorPump2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelayIndicatorPump2.ForeColor = System.Drawing.Color.White
        Me.btnRelayIndicatorPump2.Location = New System.Drawing.Point(842, 634)
        Me.btnRelayIndicatorPump2.MessageBoxText = Nothing
        Me.btnRelayIndicatorPump2.Name = "btnRelayIndicatorPump2"
        Me.btnRelayIndicatorPump2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOn
        Me.btnRelayIndicatorPump2.Size = New System.Drawing.Size(10, 10)
        Me.btnRelayIndicatorPump2.TabIndex = 283
        Me.btnRelayIndicatorPump2.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump2.UseClickedEventInForm = True
        Me.btnRelayIndicatorPump2.UseVisualStyleBackColor = False
        Me.btnRelayIndicatorPump2.ValueToBeSend = ""
        '
        'btnRelayIndicatorPump1
        '
        Me.btnRelayIndicatorPump1.AccessibleName = "TurboLLA"
        Me.btnRelayIndicatorPump1.BackColor = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRelayIndicatorPump1.Clickable = True
        Me.btnRelayIndicatorPump1.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRelayIndicatorPump1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRelayIndicatorPump1.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump1.FlatAppearance.BorderSize = 0
        Me.btnRelayIndicatorPump1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelayIndicatorPump1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelayIndicatorPump1.ForeColor = System.Drawing.Color.White
        Me.btnRelayIndicatorPump1.Location = New System.Drawing.Point(1006, 634)
        Me.btnRelayIndicatorPump1.MessageBoxText = Nothing
        Me.btnRelayIndicatorPump1.Name = "btnRelayIndicatorPump1"
        Me.btnRelayIndicatorPump1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOn
        Me.btnRelayIndicatorPump1.Size = New System.Drawing.Size(10, 10)
        Me.btnRelayIndicatorPump1.TabIndex = 283
        Me.btnRelayIndicatorPump1.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump1.UseClickedEventInForm = True
        Me.btnRelayIndicatorPump1.UseVisualStyleBackColor = False
        Me.btnRelayIndicatorPump1.ValueToBeSend = ""
        '
        'btnTool
        '
        Me.btnTool.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTool.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTool.FlatAppearance.BorderSize = 0
        Me.btnTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTool.Location = New System.Drawing.Point(72, 567)
        Me.btnTool.Name = "btnTool"
        Me.btnTool.Size = New System.Drawing.Size(30, 28)
        Me.btnTool.TabIndex = 76
        Me.btnTool.UseVisualStyleBackColor = True
        Me.btnTool.Visible = False
        '
        'btnLeftTool
        '
        Me.btnLeftTool.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnLeftTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLeftTool.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLeftTool.FlatAppearance.BorderSize = 0
        Me.btnLeftTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLeftTool.Location = New System.Drawing.Point(6, 567)
        Me.btnLeftTool.Name = "btnLeftTool"
        Me.btnLeftTool.Size = New System.Drawing.Size(30, 28)
        Me.btnLeftTool.TabIndex = 127
        Me.btnLeftTool.UseVisualStyleBackColor = True
        Me.btnLeftTool.Visible = False
        '
        'ValveTMTurbo
        '
        Me.ValveTMTurbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveTMTurbo.IsCheckSafetyBeforeClick = False
        Me.ValveTMTurbo.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveTMTurbo.Location = New System.Drawing.Point(718, 89)
        Me.ValveTMTurbo.Margin = New System.Windows.Forms.Padding(4)
        Me.ValveTMTurbo.Name = "ValveTMTurbo"
        Me.ValveTMTurbo.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveTMTurbo.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveTMTurbo.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveTMTurbo.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveTMTurbo.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveTMTurbo.Size = New System.Drawing.Size(39, 33)
        Me.ValveTMTurbo.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveTMTurbo.TabIndex = 250
        Me.ValveTMTurbo.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveTMTurbo.TextLocIsFix = True
        Me.ValveTMTurbo.TextValue = ""
        Me.ValveTMTurbo.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveTMTurbo.Unit = ""
        Me.ValveTMTurbo.UnknownImage = Nothing
        Me.ValveTMTurbo.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveTMTurbo.UseClickedEventInForm = True
        Me.ValveTMTurbo.UsingScientificFormat = True
        '
        'RoughPumpControl
        '
        Me.RoughPumpControl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RoughPumpControl.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughPumpControl.IsCheckSafetyBeforeClick = False
        Me.RoughPumpControl.IsCheckSafetyIsolationValveBeforeClick = False
        Me.RoughPumpControl.Location = New System.Drawing.Point(1000, 628)
        Me.RoughPumpControl.Margin = New System.Windows.Forms.Padding(4)
        Me.RoughPumpControl.Name = "RoughPumpControl"
        Me.RoughPumpControl.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Rough_Pump_Off
        Me.RoughPumpControl.OffState_ColorText = System.Drawing.Color.White
        Me.RoughPumpControl.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Rough_Pump_On
        Me.RoughPumpControl.OnState_ColorText = System.Drawing.Color.White
        Me.RoughPumpControl.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.RoughPumpControl.Size = New System.Drawing.Size(126, 70)
        Me.RoughPumpControl.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.RoughPumpControl.TabIndex = 126
        Me.RoughPumpControl.TextLocation = New System.Drawing.Point(20, 33)
        Me.RoughPumpControl.TextLocIsFix = False
        Me.RoughPumpControl.TextValue = "7.6E+02"
        Me.RoughPumpControl.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.RoughPumpControl.Unit = ""
        Me.RoughPumpControl.UnknownImage = Nothing
        Me.RoughPumpControl.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.RoughPumpControl.UseClickedEventInForm = True
        Me.RoughPumpControl.UsingScientificFormat = False
        '
        'RoughPumpControl2
        '
        Me.RoughPumpControl2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RoughPumpControl2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughPumpControl2.IsCheckSafetyBeforeClick = False
        Me.RoughPumpControl2.IsCheckSafetyIsolationValveBeforeClick = False
        Me.RoughPumpControl2.Location = New System.Drawing.Point(836, 628)
        Me.RoughPumpControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.RoughPumpControl2.Name = "RoughPumpControl2"
        Me.RoughPumpControl2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Rough_Pump_Off
        Me.RoughPumpControl2.OffState_ColorText = System.Drawing.Color.White
        Me.RoughPumpControl2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Rough_Pump_On
        Me.RoughPumpControl2.OnState_ColorText = System.Drawing.Color.White
        Me.RoughPumpControl2.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.RoughPumpControl2.Size = New System.Drawing.Size(126, 70)
        Me.RoughPumpControl2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.RoughPumpControl2.TabIndex = 251
        Me.RoughPumpControl2.TextLocation = New System.Drawing.Point(20, 33)
        Me.RoughPumpControl2.TextLocIsFix = False
        Me.RoughPumpControl2.TextValue = "7.6E+02"
        Me.RoughPumpControl2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.RoughPumpControl2.Unit = ""
        Me.RoughPumpControl2.UnknownImage = Nothing
        Me.RoughPumpControl2.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.RoughPumpControl2.UseClickedEventInForm = True
        Me.RoughPumpControl2.UsingScientificFormat = True
        '
        'btnRightTool
        '
        Me.btnRightTool.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnRightTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRightTool.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRightTool.FlatAppearance.BorderSize = 0
        Me.btnRightTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRightTool.Location = New System.Drawing.Point(39, 567)
        Me.btnRightTool.Name = "btnRightTool"
        Me.btnRightTool.Size = New System.Drawing.Size(30, 28)
        Me.btnRightTool.TabIndex = 128
        Me.btnRightTool.UseVisualStyleBackColor = True
        Me.btnRightTool.Visible = False
        '
        'ValveLLASlowRough
        '
        Me.ValveLLASlowRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLASlowRough.IsCheckSafetyBeforeClick = False
        Me.ValveLLASlowRough.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveLLASlowRough.Location = New System.Drawing.Point(728, 533)
        Me.ValveLLASlowRough.Margin = New System.Windows.Forms.Padding(4)
        Me.ValveLLASlowRough.Name = "ValveLLASlowRough"
        Me.ValveLLASlowRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveLLASlowRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLASlowRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveLLASlowRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLASlowRough.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveLLASlowRough.Size = New System.Drawing.Size(39, 33)
        Me.ValveLLASlowRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLASlowRough.TabIndex = 111
        Me.ValveLLASlowRough.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLASlowRough.TextLocIsFix = True
        Me.ValveLLASlowRough.TextValue = ""
        Me.ValveLLASlowRough.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveLLASlowRough.Unit = ""
        Me.ValveLLASlowRough.UnknownImage = Nothing
        Me.ValveLLASlowRough.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLASlowRough.UseClickedEventInForm = True
        Me.ValveLLASlowRough.UsingScientificFormat = True
        '
        'ValveRough
        '
        Me.ValveRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveRough.IsCheckSafetyBeforeClick = False
        Me.ValveRough.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveRough.Location = New System.Drawing.Point(728, 392)
        Me.ValveRough.Margin = New System.Windows.Forms.Padding(4)
        Me.ValveRough.Name = "ValveRough"
        Me.ValveRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveRough.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveRough.Size = New System.Drawing.Size(39, 33)
        Me.ValveRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveRough.TabIndex = 111
        Me.ValveRough.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveRough.TextLocIsFix = True
        Me.ValveRough.TextValue = ""
        Me.ValveRough.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveRough.Unit = ""
        Me.ValveRough.UnknownImage = Nothing
        Me.ValveRough.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveRough.UseClickedEventInForm = True
        Me.ValveRough.UsingScientificFormat = True
        '
        'CX_PM3
        '
        Me.CX_PM3.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM3.BackgroundImage = CType(resources.GetObject("CX_PM3.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CX_PM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM3.DockPosition = AVP_Robot_Project.PMControl.ChamberDockPositions.PM3
        Me.CX_PM3.LabelDisconnect_Location = New System.Drawing.Point(50, 70)
        Me.CX_PM3.Location = New System.Drawing.Point(600, 203)
        Me.CX_PM3.Name = "CX_PM3"
        Me.CX_PM3.PM_IN_SCREEN = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.CX_PM3.Show_Disconnected = True
        Me.CX_PM3.ShowWafer_Border_ToEdit = True
        Me.CX_PM3.ShutterLocation = New System.Drawing.Point(28, 292)
        Me.CX_PM3.Size = New System.Drawing.Size(187, 187)
        Me.CX_PM3.TabIndex = 158
        Me.CX_PM3.TotalTargetInstalled = CType(0, Short)
        Me.CX_PM3.WaferID = ""
        Me.CX_PM3.WaferLocation = New System.Drawing.Point(29, 76)
        '
        'ValveLLAFastVent
        '
        Me.ValveLLAFastVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLAFastVent.IsCheckSafetyBeforeClick = False
        Me.ValveLLAFastVent.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveLLAFastVent.Location = New System.Drawing.Point(241, 485)
        Me.ValveLLAFastVent.Margin = New System.Windows.Forms.Padding(4)
        Me.ValveLLAFastVent.Name = "ValveLLAFastVent"
        Me.ValveLLAFastVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveLLAFastVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLAFastVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveLLAFastVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLAFastVent.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveLLAFastVent.Size = New System.Drawing.Size(40, 33)
        Me.ValveLLAFastVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLAFastVent.TabIndex = 111
        Me.ValveLLAFastVent.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLAFastVent.TextLocIsFix = True
        Me.ValveLLAFastVent.TextValue = ""
        Me.ValveLLAFastVent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveLLAFastVent.Unit = ""
        Me.ValveLLAFastVent.UnknownImage = Nothing
        Me.ValveLLAFastVent.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLAFastVent.UseClickedEventInForm = True
        Me.ValveLLAFastVent.UsingScientificFormat = True
        '
        'CX_PM1
        '
        Me.CX_PM1.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM1.BackgroundImage = CType(resources.GetObject("CX_PM1.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM1.DockPosition = AVP_Robot_Project.PMControl.ChamberDockPositions.PM1
        Me.CX_PM1.LabelDisconnect_Location = New System.Drawing.Point(50, 70)
        Me.CX_PM1.Location = New System.Drawing.Point(212, 203)
        Me.CX_PM1.Name = "CX_PM1"
        Me.CX_PM1.PM_IN_SCREEN = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.CX_PM1.Show_Disconnected = True
        Me.CX_PM1.ShowWafer_Border_ToEdit = True
        Me.CX_PM1.ShutterLocation = New System.Drawing.Point(28, 292)
        Me.CX_PM1.Size = New System.Drawing.Size(187, 187)
        Me.CX_PM1.TabIndex = 158
        Me.CX_PM1.TotalTargetInstalled = CType(0, Short)
        Me.CX_PM1.WaferID = ""
        Me.CX_PM1.WaferLocation = New System.Drawing.Point(123, 76)
        '
        'ValveLLASlowVent
        '
        Me.ValveLLASlowVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLASlowVent.IsCheckSafetyBeforeClick = False
        Me.ValveLLASlowVent.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveLLASlowVent.Location = New System.Drawing.Point(241, 533)
        Me.ValveLLASlowVent.Margin = New System.Windows.Forms.Padding(4)
        Me.ValveLLASlowVent.Name = "ValveLLASlowVent"
        Me.ValveLLASlowVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveLLASlowVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLASlowVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveLLASlowVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLASlowVent.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveLLASlowVent.Size = New System.Drawing.Size(40, 33)
        Me.ValveLLASlowVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveLLASlowVent.TabIndex = 111
        Me.ValveLLASlowVent.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveLLASlowVent.TextLocIsFix = True
        Me.ValveLLASlowVent.TextValue = ""
        Me.ValveLLASlowVent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveLLASlowVent.Unit = ""
        Me.ValveLLASlowVent.UnknownImage = Nothing
        Me.ValveLLASlowVent.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveLLASlowVent.UseClickedEventInForm = True
        Me.ValveLLASlowVent.UsingScientificFormat = True
        '
        'CX_PM2
        '
        Me.CX_PM2.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM2.BackgroundImage = CType(resources.GetObject("CX_PM2.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM2.DockPosition = AVP_Robot_Project.PMControl.ChamberDockPositions.PM2
        Me.CX_PM2.LabelDisconnect_Location = New System.Drawing.Point(50, 70)
        Me.CX_PM2.Location = New System.Drawing.Point(406, 8)
        Me.CX_PM2.Name = "CX_PM2"
        Me.CX_PM2.PM_IN_SCREEN = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.CX_PM2.Show_Disconnected = True
        Me.CX_PM2.ShowWafer_Border_ToEdit = True
        Me.CX_PM2.ShutterLocation = New System.Drawing.Point(28, 292)
        Me.CX_PM2.Size = New System.Drawing.Size(187, 187)
        Me.CX_PM2.TabIndex = 158
        Me.CX_PM2.TotalTargetInstalled = CType(0, Short)
        Me.CX_PM2.WaferID = "A01"
        Me.CX_PM2.WaferLocation = New System.Drawing.Point(76, 123)
        '
        'ValveVent
        '
        Me.ValveVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveVent.IsCheckSafetyBeforeClick = False
        Me.ValveVent.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveVent.Location = New System.Drawing.Point(242, 414)
        Me.ValveVent.Margin = New System.Windows.Forms.Padding(4)
        Me.ValveVent.Name = "ValveVent"
        Me.ValveVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveVent.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveVent.Size = New System.Drawing.Size(39, 33)
        Me.ValveVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveVent.TabIndex = 111
        Me.ValveVent.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveVent.TextLocIsFix = True
        Me.ValveVent.TextValue = ""
        Me.ValveVent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveVent.Unit = ""
        Me.ValveVent.UnknownImage = Nothing
        Me.ValveVent.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveVent.UseClickedEventInForm = True
        Me.ValveVent.UsingScientificFormat = True
        '
        'Gasline_TM_FastVent
        '
        Me.Gasline_TM_FastVent.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FastVent.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FastVent.Location = New System.Drawing.Point(281, 358)
        Me.Gasline_TM_FastVent.Name = "Gasline_TM_FastVent"
        Me.Gasline_TM_FastVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_TM_Vent
        Me.Gasline_TM_FastVent.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_TM_Vent_On
        Me.Gasline_TM_FastVent.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_TM_Vent_On_1
        Me.Gasline_TM_FastVent.Size = New System.Drawing.Size(157, 80)
        Me.Gasline_TM_FastVent.TabIndex = 343
        '
        'Gasline_TM_FastRough
        '
        Me.Gasline_TM_FastRough.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Gasline_TM_FastRough.BackColor = System.Drawing.Color.Transparent
        Me.Gasline_TM_FastRough.Location = New System.Drawing.Point(562, 358)
        Me.Gasline_TM_FastRough.Name = "Gasline_TM_FastRough"
        Me.Gasline_TM_FastRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_TM_Rough
        Me.Gasline_TM_FastRough.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_TM_Rough_On
        Me.Gasline_TM_FastRough.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_CX4_TM_Rough_On_1
        Me.Gasline_TM_FastRough.Size = New System.Drawing.Size(166, 58)
        Me.Gasline_TM_FastRough.TabIndex = 343
        '
        'ctrLLATurboCom
        '
        Me.ctrLLATurboCom.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.ctrLLATurboCom.BackColor = System.Drawing.Color.DimGray
        Me.ctrLLATurboCom.Location = New System.Drawing.Point(592, 430)
        Me.ctrLLATurboCom.Name = "ctrLLATurboCom"
        Me.ctrLLATurboCom.Size = New System.Drawing.Size(15, 15)
        Me.ctrLLATurboCom.Status = AVPControls.AVPDataLib.DisplayStatus.[Error]
        Me.ctrLLATurboCom.TabIndex = 370
        '
        'ctrTMTurboCom
        '
        Me.ctrTMTurboCom.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.ctrTMTurboCom.BackColor = System.Drawing.Color.DimGray
        Me.ctrTMTurboCom.Location = New System.Drawing.Point(594, 173)
        Me.ctrTMTurboCom.Name = "ctrTMTurboCom"
        Me.ctrTMTurboCom.Size = New System.Drawing.Size(15, 15)
        Me.ctrTMTurboCom.Status = AVPControls.AVPDataLib.DisplayStatus.[Error]
        Me.ctrTMTurboCom.TabIndex = 371
        '
        'lblturboRampingPercent
        '
        Me.lblturboRampingPercent.AutoSize = True
        Me.lblturboRampingPercent.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblturboRampingPercent.ForeColor = System.Drawing.Color.Yellow
        Me.lblturboRampingPercent.Location = New System.Drawing.Point(567, 477)
        Me.lblturboRampingPercent.Name = "lblturboRampingPercent"
        Me.lblturboRampingPercent.Size = New System.Drawing.Size(24, 15)
        Me.lblturboRampingPercent.TabIndex = 372
        Me.lblturboRampingPercent.Text = "0%"
        Me.lblturboRampingPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTMturboRampingPercent
        '
        Me.lblTMturboRampingPercent.AutoSize = True
        Me.lblTMturboRampingPercent.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTMturboRampingPercent.ForeColor = System.Drawing.Color.Yellow
        Me.lblTMturboRampingPercent.Location = New System.Drawing.Point(591, 147)
        Me.lblTMturboRampingPercent.Name = "lblTMturboRampingPercent"
        Me.lblTMturboRampingPercent.Size = New System.Drawing.Size(24, 15)
        Me.lblTMturboRampingPercent.TabIndex = 372
        Me.lblTMturboRampingPercent.Text = "0%"
        Me.lblTMturboRampingPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCommunicationMP2
        '
        Me.btnCommunicationMP2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.btnCommunicationMP2.BackColor = System.Drawing.Color.DimGray
        Me.btnCommunicationMP2.Location = New System.Drawing.Point(926, 663)
        Me.btnCommunicationMP2.Name = "btnCommunicationMP2"
        Me.btnCommunicationMP2.Size = New System.Drawing.Size(15, 15)
        Me.btnCommunicationMP2.Status = AVPControls.AVPDataLib.DisplayStatus.[Error]
        Me.btnCommunicationMP2.TabIndex = 370
        '
        'btnCommunicationMP1
        '
        Me.btnCommunicationMP1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.btnCommunicationMP1.BackColor = System.Drawing.Color.DimGray
        Me.btnCommunicationMP1.Location = New System.Drawing.Point(1090, 663)
        Me.btnCommunicationMP1.Name = "btnCommunicationMP1"
        Me.btnCommunicationMP1.Size = New System.Drawing.Size(15, 15)
        Me.btnCommunicationMP1.Status = AVPControls.AVPDataLib.DisplayStatus.[Error]
        Me.btnCommunicationMP1.TabIndex = 370
        '
        'lblComunicationLED_LLpump
        '
        Me.lblComunicationLED_LLpump.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED_LLpump.Location = New System.Drawing.Point(576, 570)
        Me.lblComunicationLED_LLpump.Name = "lblComunicationLED_LLpump"
        Me.lblComunicationLED_LLpump.Size = New System.Drawing.Size(7, 11)
        Me.lblComunicationLED_LLpump.TabIndex = 284
        Me.lblComunicationLED_LLpump.Visible = False
        '
        'lblComunicationLED_TMPump
        '
        Me.lblComunicationLED_TMPump.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED_TMPump.Location = New System.Drawing.Point(599, 570)
        Me.lblComunicationLED_TMPump.Name = "lblComunicationLED_TMPump"
        Me.lblComunicationLED_TMPump.Size = New System.Drawing.Size(7, 11)
        Me.lblComunicationLED_TMPump.TabIndex = 284
        Me.lblComunicationLED_TMPump.Visible = False
        '
        'lblWaitingMPOnTM
        '
        Me.lblWaitingMPOnTM.AutoSize = True
        Me.lblWaitingMPOnTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaitingMPOnTM.ForeColor = System.Drawing.Color.White
        Me.lblWaitingMPOnTM.Location = New System.Drawing.Point(978, 591)
        Me.lblWaitingMPOnTM.Name = "lblWaitingMPOnTM"
        Me.lblWaitingMPOnTM.Size = New System.Drawing.Size(0, 19)
        Me.lblWaitingMPOnTM.TabIndex = 266
        '
        'lblWaitingMPOnLL
        '
        Me.lblWaitingMPOnLL.AutoSize = True
        Me.lblWaitingMPOnLL.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaitingMPOnLL.ForeColor = System.Drawing.Color.White
        Me.lblWaitingMPOnLL.Location = New System.Drawing.Point(813, 591)
        Me.lblWaitingMPOnLL.Name = "lblWaitingMPOnLL"
        Me.lblWaitingMPOnLL.Size = New System.Drawing.Size(0, 19)
        Me.lblWaitingMPOnLL.TabIndex = 267
        '
        'CassettesPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.RobotHand)
        Me.Controls.Add(Me.btnCommunicationMP1)
        Me.Controls.Add(Me.btnCommunicationMP2)
        Me.Controls.Add(Me.lblturboRampingPercent)
        Me.Controls.Add(Me.lblFastRoughtValve)
        Me.Controls.Add(Me.btnCycleATM)
        Me.Controls.Add(Me.TMSwitchIGFilament)
        Me.Controls.Add(Me.lblTMturboRampingPercent)
        Me.Controls.Add(Me.LLASwitchIGFilament)
        Me.Controls.Add(Me.ctrLLATurboCom)
        Me.Controls.Add(Me.btnSystemSetupTestingSetup)
        Me.Controls.Add(Me.ValveLLAFastRough)
        Me.Controls.Add(Me.Gasline_LL_SlowVent)
        Me.Controls.Add(Me.ctrTMTurboCom)
        Me.Controls.Add(Me.Gasline_LL_SV_N2)
        Me.Controls.Add(Me.Gasline_LL_FastVent)
        Me.Controls.Add(Me.Gasline_LL_FV_N2)
        Me.Controls.Add(Me.IgcgChamber1)
        Me.Controls.Add(Me.IgcgChamber3)
        Me.Controls.Add(Me.crcLLTurbo)
        Me.Controls.Add(Me.HivacValveLLA)
        Me.Controls.Add(Me.LLALeg)
        Me.Controls.Add(Me.Gasline_PressureFR)
        Me.Controls.Add(Me.Gasline_PressureLL_FL)
        Me.Controls.Add(Me.btnUpdateManualTransfer)
        Me.Controls.Add(Me.Gasline_LL_Vent)
        Me.Controls.Add(Me.Gasline_TM_FR_Out)
        Me.Controls.Add(Me.Gasline_TM_FL_2)
        Me.Controls.Add(Me.Gasline_TM_FV_N2)
        Me.Controls.Add(Me.Gasline_PressureTM_FL)
        Me.Controls.Add(Me.Gasline_TM_FL_3)
        Me.Controls.Add(Me.btnTurboRelayIndicator_LLA)
        Me.Controls.Add(Me.Gasline_TM_FL_4)
        Me.Controls.Add(Me.btnTurboLLA)
        Me.Controls.Add(Me.Gasline_TM_FL_FR)
        Me.Controls.Add(Me.Gasline_TM_FL_End1)
        Me.Controls.Add(Me.PumpLLA)
        Me.Controls.Add(Me.lblComunicationLED_TurboLLA)
        Me.Controls.Add(Me.Gasline_LL_FL_221)
        Me.Controls.Add(Me.btnTurboRelayIndicator_TM)
        Me.Controls.Add(Me.MesaValvePM2)
        Me.Controls.Add(Me.MesaValveLLA)
        Me.Controls.Add(Me.lblComunicationLED_LLpump)
        Me.Controls.Add(Me.MesaValvePM3)
        Me.Controls.Add(Me.btnTurboTM)
        Me.Controls.Add(Me.Gasline_TM_FL_1)
        Me.Controls.Add(Me.lblComunicationLED_TurboTM)
        Me.Controls.Add(Me.lblComunicationLED_TMPump)
        Me.Controls.Add(Me.Gasline_LL_FR_221)
        Me.Controls.Add(Me.crcLLACryo)
        Me.Controls.Add(Me.MesaValvePM1)
        Me.Controls.Add(Me.Gasline_LL_FL_1)
        Me.Controls.Add(Me.Gasline_LL_Pump_PartEnd)
        Me.Controls.Add(Me.Gasline_LL_FR_1)
        Me.Controls.Add(Me.Gasline_TM_FL_End2)
        Me.Controls.Add(Me.lblPM2MotionStatus)
        Me.Controls.Add(Me.Gasline_LL_FL_222)
        Me.Controls.Add(Me.Gasline_TM_Pump_PartEnd)
        Me.Controls.Add(Me.Gasline_LL_SR_221)
        Me.Controls.Add(Me.Gasline_LL_SR_1)
        Me.Controls.Add(Me.Gasline_LL_Foreline)
        Me.Controls.Add(Me.Gasline_LL_Pump_Part4)
        Me.Controls.Add(Me.lccLoadLockA)
        Me.Controls.Add(Me.lblPM3MotionStatus)
        Me.Controls.Add(Me.Gasline_TM_Pump_Part4)
        Me.Controls.Add(Me.PumpTM)
        Me.Controls.Add(Me.Gasline_LL_FastRough)
        Me.Controls.Add(Me.Gasline_TM_Foreline)
        Me.Controls.Add(Me.Gasline_LL_FL_21)
        Me.Controls.Add(Me.Gasline_LL_FR_222)
        Me.Controls.Add(Me.HivacValveTM)
        Me.Controls.Add(Me.lblSlowVentLineLLA)
        Me.Controls.Add(Me.Gasline_LL_Pump_Part3)
        Me.Controls.Add(Me.txtTurboIGLLA)
        Me.Controls.Add(Me.Gasline_LL_FR_21)
        Me.Controls.Add(Me.lblPM1MotionStatus)
        Me.Controls.Add(Me.Gasline_LL_Rough)
        Me.Controls.Add(Me.Gasline_TM_Pump_Part3)
        Me.Controls.Add(Me.lblPump2)
        Me.Controls.Add(Me.lblPump1)
        Me.Controls.Add(Me.Gasline_LL_SR_21)
        Me.Controls.Add(Me.Gasline_LL_Pump_Part2)
        Me.Controls.Add(Me.Gasline_LL_SR_222)
        Me.Controls.Add(Me.lblTurboForlineTM)
        Me.Controls.Add(Me.lblRoughLineTM)
        Me.Controls.Add(Me.Gasline_TM_Pump_Part2)
        Me.Controls.Add(Me.txtTurboIGTM)
        Me.Controls.Add(Me.lblWaitingMPOnLL)
        Me.Controls.Add(Me.btnMechineTool)
        Me.Controls.Add(Me.lblWaitingMPOnTM)
        Me.Controls.Add(Me.lblVentLineLLA)
        Me.Controls.Add(Me.lblVentLineTM)
        Me.Controls.Add(Me.Gasline_LL_SlowRough)
        Me.Controls.Add(Me.txtRoughLineTM)
        Me.Controls.Add(Me.btnFakeProcessCompleteChime)
        Me.Controls.Add(Me.ValveLLATurbo)
        Me.Controls.Add(Me.Gasline_LL_Pump_Part1)
        Me.Controls.Add(Me.btnCancelMove)
        Me.Controls.Add(Me.lblFlashing)
        Me.Controls.Add(Me.lblLLANameOfSequenceRunning)
        Me.Controls.Add(Me.LLAIgStatus)
        Me.Controls.Add(Me.Gasline_TM_Pump_Part1)
        Me.Controls.Add(Me.btnTMProtectedMode)
        Me.Controls.Add(Me.TMCtl)
        Me.Controls.Add(Me.stwSemiautoTransferWafer)
        Me.Controls.Add(Me.ibsHivacButton)
        Me.Controls.Add(Me.btnRelayIndicatorPump2)
        Me.Controls.Add(Me.btnRelayIndicatorPump1)
        Me.Controls.Add(Me.btnTool)
        Me.Controls.Add(Me.btnLeftTool)
        Me.Controls.Add(Me.ValveTMTurbo)
        Me.Controls.Add(Me.RoughPumpControl)
        Me.Controls.Add(Me.RoughPumpControl2)
        Me.Controls.Add(Me.awcAligner)
        Me.Controls.Add(Me.lblLLAFastRough)
        Me.Controls.Add(Me.tabGroup)
        Me.Controls.Add(Me.IgcgChamber2)
        Me.Controls.Add(Me.btnRightTool)
        Me.Controls.Add(Me.lblTMNameOfSequenceRunning)
        Me.Controls.Add(Me.lblFastVentValve)
        Me.Controls.Add(Me.crcTMCryo)
        Me.Controls.Add(Me.crcTMWaterPump)
        Me.Controls.Add(Me.lblLLASlowVent)
        Me.Controls.Add(Me.ValveLLASlowRough)
        Me.Controls.Add(Me.lblCoreMessageBoxText)
        Me.Controls.Add(Me.lblLLAFastVent)
        Me.Controls.Add(Me.CX_PM3)
        Me.Controls.Add(Me.lblStatusText)
        Me.Controls.Add(Me.ValveLLAFastVent)
        Me.Controls.Add(Me.lblTurboForlineLLA)
        Me.Controls.Add(Me.CX_PM1)
        Me.Controls.Add(Me.ValveRough)
        Me.Controls.Add(Me.ValveLLASlowVent)
        Me.Controls.Add(Me.CX_PM2)
        Me.Controls.Add(Me.lblLLASlowRough)
        Me.Controls.Add(Me.ValveVent)
        Me.Controls.Add(Me.lblRoughPumpInUse_2)
        Me.Controls.Add(Me.lblRoughPumpInUse)
        Me.Controls.Add(Me.lblPM2MotionInitialize)
        Me.Controls.Add(Me.Robot_Body)
        Me.Controls.Add(Me.Gasline_TM_FastVent)
        Me.Controls.Add(Me.lblPM1MotionInitialize)
        Me.Controls.Add(Me.lblPM3MotionInitialize)
        Me.Controls.Add(Me.Gasline_TM_FastRough)
        Me.Controls.Add(Me.lblAlignAngle)
        Me.Controls.Add(Me.lblAlignerEECM)
        Me.Controls.Add(Me.lblAlignerEECA)
        Me.Name = "CassettesPanel"
        Me.Size = New System.Drawing.Size(1280, 775)
        Me.cmsChamber.ResumeLayout(False)
        Me.cmsTool.ResumeLayout(False)
        CType(Me.awcAligner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsMechineTool.ResumeLayout(False)
        Me.cmsLeftTool.ResumeLayout(False)
        Me.cmsRightTool.ResumeLayout(False)
        Me.tabGroup.ResumeLayout(False)
        Me.tabCycleWafer.ResumeLayout(False)
        Me.tabAligner.ResumeLayout(False)
        Me.tabSelfAligner.ResumeLayout(False)
        Me.tabSerialCommand.ResumeLayout(False)
        Me.tabCycle.ResumeLayout(False)
        CType(Me.Robot_Body, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RobotHand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_SlowVent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_SV_N2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FastVent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FV_N2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_Vent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FR_Out, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FL_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FV_N2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FL_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FL_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FL_FR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FL_End1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FL_221, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FL_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FR_221, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FL_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_Pump_PartEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FR_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FL_End2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FL_222, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_Pump_PartEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_SR_221, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_SR_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_Foreline, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_Pump_Part4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_Pump_Part4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FastRough, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_Foreline, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FL_21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FR_222, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_Pump_Part3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_FR_21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_Rough, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_Pump_Part3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_SR_21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_Pump_Part2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_SR_222, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_Pump_Part2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_SlowRough, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_LL_Pump_Part1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_Pump_Part1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FastVent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gasline_TM_FastRough, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ctrLLATurboCom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ctrTMTurboCom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCommunicationMP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCommunicationMP1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IgcgChamber1 As AVP_Robot_Project.IGCGControl
    Friend WithEvents IgcgChamber2 As AVP_Robot_Project.IGCGControl
    Friend WithEvents IgcgChamber3 As AVP_Robot_Project.IGCGControl
    Friend WithEvents stwSemiautoTransferWafer As AVP_Robot_Project.SemiautoTranferWaferControl
    Friend WithEvents atwAutoTransferWafer As AVP_Robot_Project.AutoTransferWaferControl
    Friend WithEvents sccSerialCommand As AVP_Robot_Project.SerialCommandControl
    Friend WithEvents cmsChamber As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCreateWafer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteWafer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSrcForMove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDstForMove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTool As System.Windows.Forms.Button
    Friend WithEvents cmsTool As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuHome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAlign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents awcAligner As AVPControls.AVPAlignerControl
    Friend WithEvents lblStatusText As System.Windows.Forms.Label
    Friend WithEvents lblCoreMessageBoxText As System.Windows.Forms.Label
    Friend WithEvents btnUpdateManualTransfer As System.Windows.Forms.Button
    Friend WithEvents mnuUpdateWaferInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents crcLLACryo As AVP_Robot_Project.CryoControl
    Friend WithEvents ValveVent As AVP_Robot_Project.ValveControl
    Friend WithEvents ibsHivacButton As AVP_Robot_Project.ImageHivacTMTransferModule
    Friend WithEvents ValveLLASlowVent As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLAFastVent As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveRough As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLASlowRough As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveLLAFastRough As AVP_Robot_Project.ValveControl
    Friend WithEvents RoughPumpControl As AVP_Robot_Project.ValveControl
    Friend WithEvents btnLeftTool As System.Windows.Forms.Button
    Friend WithEvents btnRightTool As System.Windows.Forms.Button
    Friend WithEvents btnMechineTool As System.Windows.Forms.Button
    Friend WithEvents lblFastRoughtValve As System.Windows.Forms.Label
    Friend WithEvents lblFastVentValve As System.Windows.Forms.Label
    Friend WithEvents lblLLAFastRough As System.Windows.Forms.Label
    Friend WithEvents lblLLAFastVent As System.Windows.Forms.Label
    Friend WithEvents lblLLASlowVent As System.Windows.Forms.Label
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
    Friend WithEvents TMCtl As AVP_Robot_Project.TMControl
    Friend WithEvents lblRoughPumpInUse As System.Windows.Forms.Label
    Friend WithEvents CX_PM1 As AVP_Robot_Project.PMControl
    Friend WithEvents CX_PM2 As AVP_Robot_Project.PMControl
    Friend WithEvents CX_PM3 As AVP_Robot_Project.PMControl
    Friend WithEvents Robot_Body As AVPControls.RobotBodyControl
    Friend WithEvents LLALeg As AVP_Robot_Project.LoadLockLeg
    Friend WithEvents tabGroup As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabCycleWafer As System.Windows.Forms.TabPage
    Friend WithEvents tabSerialCommand As System.Windows.Forms.TabPage
    Friend WithEvents crcTMWaterPump As AVP_Robot_Project.WaterPump
    Friend WithEvents btnTMProtectedMode As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents LLAIgStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents tabCycle As System.Windows.Forms.TabPage
    Friend WithEvents ctwcCycleWafer As AVP_Robot_Project.CycleTransferWaferControl
    Friend WithEvents btnCancelMove As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnFakeProcessCompleteChime As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents ValveLLATurbo As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveTMTurbo As AVP_Robot_Project.ValveControl
    Friend WithEvents RoughPumpControl2 As AVP_Robot_Project.ValveControl
    Friend WithEvents btnTurboLLA As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTurboTM As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblPump1 As System.Windows.Forms.Label
    Friend WithEvents lblPump2 As System.Windows.Forms.Label
    Friend WithEvents lblRoughLineTM As System.Windows.Forms.Label
    Friend WithEvents lblVentLineLLA As System.Windows.Forms.Label
    Friend WithEvents lblVentLineTM As System.Windows.Forms.Label
    Friend WithEvents lblRoughPumpInUse_2 As System.Windows.Forms.Label
    Friend WithEvents txtTurboIGTM As System.Windows.Forms.TextBox
    Friend WithEvents txtTurboIGLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtRoughLineTM As System.Windows.Forms.TextBox
    Friend WithEvents lblTurboForlineLLA As System.Windows.Forms.Label
    Friend WithEvents lblTurboForlineTM As System.Windows.Forms.Label
    Friend WithEvents btnRelayIndicatorPump1 As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnRelayIndicatorPump2 As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblComunicationLED_TurboLLA As System.Windows.Forms.Label
    Friend WithEvents btnTurboRelayIndicator_LLA As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTurboRelayIndicator_TM As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblComunicationLED_TurboTM As System.Windows.Forms.Label
    Friend WithEvents lblTMNameOfSequenceRunning As System.Windows.Forms.Label
    Friend WithEvents lblLLANameOfSequenceRunning As System.Windows.Forms.Label
    Friend WithEvents lblFlashing As AVPControls.FlashingLabel
    Friend WithEvents lblPM1MotionInitialize As System.Windows.Forms.Label
    Friend WithEvents lblPM2MotionInitialize As System.Windows.Forms.Label
    Friend WithEvents lblPM3MotionInitialize As System.Windows.Forms.Label
    Friend WithEvents lblSlowVentLineLLA As System.Windows.Forms.Label
    Friend WithEvents lblAlignerEECA As System.Windows.Forms.Label
    Friend WithEvents lblAlignerEECM As System.Windows.Forms.Label
    Friend WithEvents lblPM1MotionStatus As System.Windows.Forms.Label
    Friend WithEvents lblPM2MotionStatus As System.Windows.Forms.Label
    Friend WithEvents lblPM3MotionStatus As System.Windows.Forms.Label
    Friend WithEvents MesaValvePM1 As AVP_Robot_Project.SlitValve
    Friend WithEvents MesaValvePM2 As AVP_Robot_Project.SlitValve
    Friend WithEvents MesaValvePM3 As AVP_Robot_Project.SlitValve
    Friend WithEvents MesaValveLLA As AVP_Robot_Project.SlitValve
    Friend WithEvents HivacValveTM As AVP_Robot_Project.SlitValve
    Friend WithEvents HivacValveLLA As AVP_Robot_Project.SlitValve
    Friend WithEvents PumpTM As AVP_Robot_Project.PumpChamber
    Friend WithEvents PumpLLA As AVP_Robot_Project.PumpChamber
    Friend WithEvents Gasline_PressureTM_FL As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents Gasline_PressureLL_FL As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents Gasline_PressureFR As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents RobotHand As AVPControls.RobotArmControl
    Friend WithEvents crcLLTurbo As AVP_Robot_Project.TurboControl
    Friend WithEvents tabSelfAligner As System.Windows.Forms.TabPage
    Friend WithEvents saSelfAligner As AVP_Robot_Project.SelfAlignerControl
    Friend WithEvents Gasline_LL_FV_N2 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_SV_N2 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_SlowVent As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_FastVent As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_Vent As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FV_N2 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FastVent As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FastRough As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FR_Out As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FL_2 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FL_3 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FL_4 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FL_End1 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FL_End2 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FL_FR As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_FL_221 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_FR_221 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_SR_221 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_FL_222 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_FR_222 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_SR_222 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_FL_21 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_FR_21 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_SR_21 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_FL_1 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_FL_1 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_FR_1 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_SR_1 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_Pump_PartEnd As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_Pump_Part4 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_Pump_Part3 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_Pump_Part2 As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_Pump_Part1 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_Pump_PartEnd As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_Pump_Part4 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_Pump_Part3 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_Pump_Part2 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_Pump_Part1 As AVPControls.AnimationControl
    Friend WithEvents Gasline_TM_Foreline As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_Foreline As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_FastRough As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_Rough As AVPControls.AnimationControl
    Friend WithEvents Gasline_LL_SlowRough As AVPControls.AnimationControl
    Friend WithEvents btnSystemSetupTestingSetup As System.Windows.Forms.Button
    Friend WithEvents lblAlignAngle As System.Windows.Forms.Label
    Friend WithEvents TMSwitchIGFilament As System.Windows.Forms.TextBox
    Friend WithEvents LLASwitchIGFilament As System.Windows.Forms.TextBox
    Friend WithEvents btnCycleATM As System.Windows.Forms.Button
    Friend WithEvents ctrLLATurboCom As AVPControls.LEDControl
    Friend WithEvents ctrTMTurboCom As AVPControls.LEDControl
    Friend WithEvents lblturboRampingPercent As System.Windows.Forms.Label
    Friend WithEvents lblTMturboRampingPercent As System.Windows.Forms.Label
    Friend WithEvents btnCommunicationMP2 As AVPControls.LEDControl
    Friend WithEvents btnCommunicationMP1 As AVPControls.LEDControl
    Friend WithEvents lblComunicationLED_LLpump As System.Windows.Forms.Label
    Friend WithEvents lblComunicationLED_TMPump As System.Windows.Forms.Label
    Friend WithEvents lblWaitingMPOnTM As System.Windows.Forms.Label
    Friend WithEvents lblWaitingMPOnLL As System.Windows.Forms.Label
    Friend WithEvents tabAligner As System.Windows.Forms.TabPage
    Friend WithEvents TMAlignerControl As AVP_Robot_Project.AlignerControl
End Class
