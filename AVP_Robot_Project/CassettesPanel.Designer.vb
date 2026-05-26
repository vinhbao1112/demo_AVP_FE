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
        Me.MesaValveLLA = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.MesaValvePM1 = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.MesaValvePM2 = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.MesaValvePM3 = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.MesaValvePM4 = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.MesaValvePM5 = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.MesaValveLLB = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.HivacValveLLA = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.HivacValveLLB = New AVP_Robot_Project.RoundRectangleStatusControl
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
        Me.IgcgChamber1 = New AVP_Robot_Project.IGCGControl
        Me.IgcgChamber2 = New AVP_Robot_Project.IGCGControl
        Me.IgcgChamber3 = New AVP_Robot_Project.IGCGControl
        Me.IgcgChamber5 = New AVP_Robot_Project.IGCGControl
        Me.IgcgChamber4 = New AVP_Robot_Project.IGCGControl
        Me.btnMechineTool = New System.Windows.Forms.Button
        Me.ibsHivacButton = New AVP_Robot_Project.ImageHivacTMTransferModule
        Me.TMCtl = New AVP_Robot_Project.TMControl
        Me.GasLineVentValveLLB = New AVP_Robot_Project.TransparentImageControl
        Me.RoughPumpControl = New AVP_Robot_Project.ValveControl
        Me.crcLLBCryo = New AVP_Robot_Project.CryoControl
        Me.crcLLACryo = New AVP_Robot_Project.CryoControl
        Me.crcTMCryo = New AVP_Robot_Project.CryoControl
        Me.lccLoadLockB = New AVP_Robot_Project.LockCassetteControl
        Me.btnRightTool = New System.Windows.Forms.Button
        Me.GasLineVentValveLLA = New AVP_Robot_Project.TransparentImageControl
        Me.btnTool = New System.Windows.Forms.Button
        Me.btnLeftTool = New System.Windows.Forms.Button
        Me.ValveRough = New AVP_Robot_Project.ValveControl
        Me.ValveVent = New AVP_Robot_Project.ValveControl
        Me.ValveLLBFastVent = New AVP_Robot_Project.ValveControl
        Me.ValveLLASlowRough = New AVP_Robot_Project.ValveControl
        Me.ValveLLBFastRough = New AVP_Robot_Project.ValveControl
        Me.lccLoadLockA = New AVP_Robot_Project.LockCassetteControl
        Me.ValveLLAFastRough = New AVP_Robot_Project.ValveControl
        Me.ValveLLBSlowRough = New AVP_Robot_Project.ValveControl
        Me.stwSemiautoTransferWafer = New AVP_Robot_Project.SemiautoTranferWaferControl
        Me.ValveLLBSlowVent = New AVP_Robot_Project.ValveControl
        Me.ValveLLAFastVent = New AVP_Robot_Project.ValveControl
        Me.ValveLLASlowVent = New AVP_Robot_Project.ValveControl
        Me.GasLineRoughValveLLA = New AVP_Robot_Project.TransparentImageControl
        Me.GasLineNitrogen = New AVP_Robot_Project.TransparentImageControl
        Me.GasLineRoughValveLLB = New AVP_Robot_Project.TransparentImageControl
        Me.MesaValvePM6 = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.Robot_Body = New AVP_Robot_Project.RobotBody
        Me.IgcgChamber6 = New AVP_Robot_Project.IGCGControl
        Me.crcTMWaterPump = New AVP_Robot_Project.WaterPump
        Me.btnTMProtectedMode = New AVP_Robot_Project.SL_CustomButton
        Me.LLAIgStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.LLBIgStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnCancelMove = New AVP_Robot_Project.SL_CustomButton
        Me.ticHandOriginal = New AVP_Robot_Project.RobotHand
        Me.LLALeg = New AVP_Robot_Project.LoadLockLeg
        Me.LLBLeg = New AVP_Robot_Project.LoadLockLeg
        Me.CX_PM1 = New AVP_Robot_Project.PMControl
        Me.CX_PM2 = New AVP_Robot_Project.PMControl
        Me.CX_PM3 = New AVP_Robot_Project.PMControl
        Me.CX_PM4 = New AVP_Robot_Project.PMControl
        Me.CX_PM5 = New AVP_Robot_Project.PMControl
        Me.CX_PM6 = New AVP_Robot_Project.PMControl
        Me.tabGroup = New System.Windows.Forms.CustomTabControl
        Me.tabCycleWafer = New System.Windows.Forms.TabPage
        Me.atwAutoTransferWafer = New AVP_Robot_Project.AutoTransferWaferControl
        Me.tabSerialCommand = New System.Windows.Forms.TabPage
        Me.sccSerialCommand = New AVP_Robot_Project.SerialCommandControl
        Me.tabCycle = New System.Windows.Forms.TabPage
        Me.ctwcCycleWafer = New AVP_Robot_Project.CycleTransferWaferControl
        Me.lblFlashing = New AVP_Robot_Project.FlashingLabel     
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
        'MesaValveLLA
        '
        Me.MesaValveLLA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MesaValveLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValveLLA.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX7
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
        Me.MesaValvePM1.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX7
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
        Me.MesaValvePM2.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX7
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
        Me.MesaValvePM3.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX7
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
        'MesaValvePM4
        '
        Me.MesaValvePM4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MesaValvePM4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValvePM4.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX7
        Me.MesaValvePM4.FixedSize = False
        Me.MesaValvePM4.Location = New System.Drawing.Point(546, 174)
        Me.MesaValvePM4.Name = "MesaValvePM4"
        Me.MesaValvePM4.Size = New System.Drawing.Size(59, 58)
        Me.MesaValvePM4.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Opened
        Me.MesaValvePM4.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        Me.MesaValvePM4.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.LLA
        Me.MesaValvePM4.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.PM4
        Me.MesaValvePM4.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.LLA
        Me.MesaValvePM4.TabIndex = 60
        '
        'MesaValvePM5
        '
        Me.MesaValvePM5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MesaValvePM5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValvePM5.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX7
        Me.MesaValvePM5.FixedSize = False
        Me.MesaValvePM5.Location = New System.Drawing.Point(593, 234)
        Me.MesaValvePM5.Name = "MesaValvePM5"
        Me.MesaValvePM5.Size = New System.Drawing.Size(17, 70)
        Me.MesaValvePM5.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Unknown
        Me.MesaValvePM5.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        Me.MesaValvePM5.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.LLA
        Me.MesaValvePM5.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.PM1
        Me.MesaValvePM5.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.LLA
        Me.MesaValvePM5.TabIndex = 61
        '
        'MesaValveLLB
        '
        Me.MesaValveLLB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MesaValveLLB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValveLLB.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX7
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
        'HivacValveLLA
        '
        Me.HivacValveLLA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.HivacValveLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HivacValveLLA.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX7
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
        Me.HivacValveLLB.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX7
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
        Me.lblStatusText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.lblCoreMessageBoxText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.lblFastRoughtValve.Location = New System.Drawing.Point(900, 348)
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
        Me.lblLLBFastRough.Location = New System.Drawing.Point(710, 436)
        Me.lblLLBFastRough.Name = "lblLLBFastRough"
        Me.lblLLBFastRough.Size = New System.Drawing.Size(65, 19)
        Me.lblLLBFastRough.TabIndex = 132
        Me.lblLLBFastRough.Text = "LLB FR"
        '
        'lblLLAFastRough
        '
        Me.lblLLAFastRough.AutoSize = True
        Me.lblLLAFastRough.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLAFastRough.ForeColor = System.Drawing.Color.White
        Me.lblLLAFastRough.Location = New System.Drawing.Point(859, 527)
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
        Me.lblLLAFastVent.Location = New System.Drawing.Point(230, 436)
        Me.lblLLAFastVent.Name = "lblLLAFastVent"
        Me.lblLLAFastVent.Size = New System.Drawing.Size(63, 19)
        Me.lblLLAFastVent.TabIndex = 134
        Me.lblLLAFastVent.Text = "LLA FV"
        '
        'lblLLBFastVent
        '
        Me.lblLLBFastVent.AutoSize = True
        Me.lblLLBFastVent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLBFastVent.ForeColor = System.Drawing.Color.White
        Me.lblLLBFastVent.Location = New System.Drawing.Point(95, 543)
        Me.lblLLBFastVent.Name = "lblLLBFastVent"
        Me.lblLLBFastVent.Size = New System.Drawing.Size(64, 19)
        Me.lblLLBFastVent.TabIndex = 135
        Me.lblLLBFastVent.Text = "LLB FV"
        '
        'lblLLBSlowRough
        '
        Me.lblLLBSlowRough.AutoSize = True
        Me.lblLLBSlowRough.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLBSlowRough.ForeColor = System.Drawing.Color.White
        Me.lblLLBSlowRough.Location = New System.Drawing.Point(710, 379)
        Me.lblLLBSlowRough.Name = "lblLLBSlowRough"
        Me.lblLLBSlowRough.Size = New System.Drawing.Size(65, 19)
        Me.lblLLBSlowRough.TabIndex = 136
        Me.lblLLBSlowRough.Text = "LLB SR"
        '
        'lblLLASlowVent
        '
        Me.lblLLASlowVent.AutoSize = True
        Me.lblLLASlowVent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLASlowVent.ForeColor = System.Drawing.Color.White
        Me.lblLLASlowVent.Location = New System.Drawing.Point(230, 376)
        Me.lblLLASlowVent.Name = "lblLLASlowVent"
        Me.lblLLASlowVent.Size = New System.Drawing.Size(63, 19)
        Me.lblLLASlowVent.TabIndex = 137
        Me.lblLLASlowVent.Text = "LLA SV"
        '
        'lblLLBSlowVent
        '
        Me.lblLLBSlowVent.AutoSize = True
        Me.lblLLBSlowVent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLBSlowVent.ForeColor = System.Drawing.Color.White
        Me.lblLLBSlowVent.Location = New System.Drawing.Point(95, 481)
        Me.lblLLBSlowVent.Name = "lblLLBSlowVent"
        Me.lblLLBSlowVent.Size = New System.Drawing.Size(64, 19)
        Me.lblLLBSlowVent.TabIndex = 138
        Me.lblLLBSlowVent.Text = "LLB SV"
        '
        'lblLLASlowRough
        '
        Me.lblLLASlowRough.AutoSize = True
        Me.lblLLASlowRough.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLASlowRough.ForeColor = System.Drawing.Color.White
        Me.lblLLASlowRough.Location = New System.Drawing.Point(856, 467)
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
        Me.lblRoughPumpInUse.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoughPumpInUse.ForeColor = System.Drawing.Color.White
        Me.lblRoughPumpInUse.Location = New System.Drawing.Point(966, 660)
        Me.lblRoughPumpInUse.Name = "lblRoughPumpInUse"
        Me.lblRoughPumpInUse.Size = New System.Drawing.Size(266, 55)
        Me.lblRoughPumpInUse.TabIndex = 157
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
        'IgcgChamber5
        '
        Me.IgcgChamber5.BackColor = System.Drawing.Color.Transparent
        Me.IgcgChamber5.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.IgcgChamber5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.IgcgChamber5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgcgChamber5.ForeColor = System.Drawing.Color.DarkBlue
        Me.IgcgChamber5.HeaderHeight = 60
        Me.IgcgChamber5.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.IgcgChamber5.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.IgcgChamber5.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.IgcgChamber5.HeaderVisible = True
        Me.IgcgChamber5.Headerwidth = 49
        Me.IgcgChamber5.IGCGValue = "OFF"
        Me.IgcgChamber5.Location = New System.Drawing.Point(742, 253)
        Me.IgcgChamber5.Name = "IgcgChamber5"
        Me.IgcgChamber5.Size = New System.Drawing.Size(120, 27)
        Me.IgcgChamber5.TabIndex = 34
        Me.IgcgChamber5.Text = "PM5"
        '
        'IgcgChamber4
        '
        Me.IgcgChamber4.BackColor = System.Drawing.Color.Transparent
        Me.IgcgChamber4.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.IgcgChamber4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.IgcgChamber4.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgcgChamber4.ForeColor = System.Drawing.Color.DarkBlue
        Me.IgcgChamber4.HeaderHeight = 60
        Me.IgcgChamber4.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.IgcgChamber4.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.IgcgChamber4.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.IgcgChamber4.HeaderVisible = True
        Me.IgcgChamber4.Headerwidth = 49
        Me.IgcgChamber4.IGCGValue = "OFF"
        Me.IgcgChamber4.Location = New System.Drawing.Point(648, 83)
        Me.IgcgChamber4.Name = "IgcgChamber4"
        Me.IgcgChamber4.Size = New System.Drawing.Size(120, 27)
        Me.IgcgChamber4.TabIndex = 34
        Me.IgcgChamber4.Text = "PM4"
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
        'GasLineVentValveLLB
        '
        Me.GasLineVentValveLLB.Cursor = System.Windows.Forms.Cursors.Default
        Me.GasLineVentValveLLB.Enabled = False
        Me.GasLineVentValveLLB.Image = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_VentValveLLB
        Me.GasLineVentValveLLB.ImageSize = New System.Drawing.Size(200, 140)
        Me.GasLineVentValveLLB.IsChamberPic = False
        Me.GasLineVentValveLLB.IsStretch = False
        Me.GasLineVentValveLLB.Location = New System.Drawing.Point(600, 352)
        Me.GasLineVentValveLLB.Name = "GasLineVentValveLLB"
        Me.GasLineVentValveLLB.Size = New System.Drawing.Size(380, 74)
        Me.GasLineVentValveLLB.TabIndex = 119
        Me.GasLineVentValveLLB.TextColor = System.Drawing.Color.Wheat
        Me.GasLineVentValveLLB.TextInImage = ""
        Me.GasLineVentValveLLB.TextLocation = New System.Drawing.Point(0, 0)
        '
        'RoughPumpControl
        '
        Me.RoughPumpControl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RoughPumpControl.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughPumpControl.Location = New System.Drawing.Point(970, 536)
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
        Me.crcLLBCryo.Location = New System.Drawing.Point(770, 630)
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
        Me.crcLLACryo.Location = New System.Drawing.Point(50, 630)
        Me.crcLLACryo.Name = "crcLLACryo"
        Me.crcLLACryo.Size = New System.Drawing.Size(199, 88)
        Me.crcLLACryo.TabIndex = 108
        Me.crcLLACryo.Text = "LLA Cryo"
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
        'lccLoadLockB
        '
        Me.lccLoadLockB.AlignStyle = AVP_Robot_Project.LockCassetteControl.DisplayStyle.Right
        Me.lccLoadLockB.BackColor = System.Drawing.Color.Transparent
        Me.lccLoadLockB.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BackGroundMessagbox
        Me.lccLoadLockB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lccLoadLockB.HeaderBackColor = System.Drawing.Color.SpringGreen
        Me.lccLoadLockB.HeaderVisible = False
        Me.lccLoadLockB.Location = New System.Drawing.Point(560, 527)
        Me.lccLoadLockB.Name = "lccLoadLockB"
        Me.lccLoadLockB.NumSlot = 25
        Me.lccLoadLockB.Size = New System.Drawing.Size(275, 220)
        Me.lccLoadLockB.TabIndex = 14
        Me.lccLoadLockB.Text = "LLB"
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
        'GasLineVentValveLLA
        '
        Me.GasLineVentValveLLA.Cursor = System.Windows.Forms.Cursors.Default
        Me.GasLineVentValveLLA.Enabled = False
        Me.GasLineVentValveLLA.Image = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_VentValveLLA
        Me.GasLineVentValveLLA.ImageSize = New System.Drawing.Size(140, 140)
        Me.GasLineVentValveLLA.IsChamberPic = False
        Me.GasLineVentValveLLA.IsStretch = False
        Me.GasLineVentValveLLA.Location = New System.Drawing.Point(32, 354)
        Me.GasLineVentValveLLA.Name = "GasLineVentValveLLA"
        Me.GasLineVentValveLLA.Size = New System.Drawing.Size(365, 73)
        Me.GasLineVentValveLLA.TabIndex = 119
        Me.GasLineVentValveLLA.TextColor = System.Drawing.Color.Wheat
        Me.GasLineVentValveLLA.TextInImage = ""
        Me.GasLineVentValveLLA.TextLocation = New System.Drawing.Point(0, 0)
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
        'ValveRough
        '
        Me.ValveRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveRough.Location = New System.Drawing.Point(894, 317)
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
        Me.ValveVent.Location = New System.Drawing.Point(80, 315)
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
        'ValveLLBFastVent
        '
        Me.ValveLLBFastVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLBFastVent.Location = New System.Drawing.Point(107, 508)
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
        'ValveLLASlowRough
        '
        Me.ValveLLASlowRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLASlowRough.Location = New System.Drawing.Point(868, 431)
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
        'ValveLLBFastRough
        '
        Me.ValveLLBFastRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLBFastRough.Location = New System.Drawing.Point(722, 403)
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
        'lccLoadLockA
        '
        Me.lccLoadLockA.AlignStyle = AVP_Robot_Project.LockCassetteControl.DisplayStyle.Left
        Me.lccLoadLockA.BackColor = System.Drawing.Color.Transparent
        Me.lccLoadLockA.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BackGroundMessagbox
        Me.lccLoadLockA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lccLoadLockA.HeaderBackColor = System.Drawing.Color.SteelBlue
        Me.lccLoadLockA.HeaderVisible = False
        Me.lccLoadLockA.Location = New System.Drawing.Point(252, 527)
        Me.lccLoadLockA.Name = "lccLoadLockA"
        Me.lccLoadLockA.NumSlot = 25
        Me.lccLoadLockA.Size = New System.Drawing.Size(275, 220)
        Me.lccLoadLockA.TabIndex = 15
        Me.lccLoadLockA.Text = "LLA"
        '
        'ValveLLAFastRough
        '
        Me.ValveLLAFastRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLAFastRough.Location = New System.Drawing.Point(868, 491)
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
        'ValveLLBSlowRough
        '
        Me.ValveLLBSlowRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLBSlowRough.Location = New System.Drawing.Point(722, 343)
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
        'ValveLLBSlowVent
        '
        Me.ValveLLBSlowVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLBSlowVent.Location = New System.Drawing.Point(107, 448)
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
        'ValveLLAFastVent
        '
        Me.ValveLLAFastVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveLLAFastVent.Location = New System.Drawing.Point(239, 403)
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
        Me.ValveLLASlowVent.Location = New System.Drawing.Point(239, 343)
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
        'GasLineRoughValveLLA
        '
        Me.GasLineRoughValveLLA.Cursor = System.Windows.Forms.Cursors.Default
        Me.GasLineRoughValveLLA.Enabled = False
        Me.GasLineRoughValveLLA.Image = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_RoughValveLLB
        Me.GasLineRoughValveLLA.ImageSize = New System.Drawing.Size(320, 120)
        Me.GasLineRoughValveLLA.IsChamberPic = False
        Me.GasLineRoughValveLLA.IsStretch = False
        Me.GasLineRoughValveLLA.Location = New System.Drawing.Point(442, 443)
        Me.GasLineRoughValveLLA.Name = "GasLineRoughValveLLA"
        Me.GasLineRoughValveLLA.Size = New System.Drawing.Size(538, 80)
        Me.GasLineRoughValveLLA.TabIndex = 125
        Me.GasLineRoughValveLLA.TextColor = System.Drawing.Color.Wheat
        Me.GasLineRoughValveLLA.TextInImage = ""
        Me.GasLineRoughValveLLA.TextLocation = New System.Drawing.Point(0, 0)
        '
        'GasLineNitrogen
        '
        Me.GasLineNitrogen.Enabled = False
        Me.GasLineNitrogen.Image = Global.AVP_Robot_Project.My.Resources.Resources.MainModule
        Me.GasLineNitrogen.ImageSize = New System.Drawing.Size(1000, 374)
        Me.GasLineNitrogen.IsChamberPic = False
        Me.GasLineNitrogen.IsStretch = True
        Me.GasLineNitrogen.Location = New System.Drawing.Point(0, 306)
        Me.GasLineNitrogen.Name = "GasLineNitrogen"
        Me.GasLineNitrogen.Size = New System.Drawing.Size(1100, 426)
        Me.GasLineNitrogen.TabIndex = 91
        Me.GasLineNitrogen.TextColor = System.Drawing.Color.Wheat
        Me.GasLineNitrogen.TextInImage = ""
        Me.GasLineNitrogen.TextLocation = New System.Drawing.Point(0, 0)
        '
        'GasLineRoughValveLLB
        '
        Me.GasLineRoughValveLLB.Cursor = System.Windows.Forms.Cursors.Default
        Me.GasLineRoughValveLLB.Enabled = False
        Me.GasLineRoughValveLLB.Image = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_RoughValveLLA
        Me.GasLineRoughValveLLB.ImageSize = New System.Drawing.Size(140, 120)
        Me.GasLineRoughValveLLB.IsChamberPic = False
        Me.GasLineRoughValveLLB.IsStretch = False
        Me.GasLineRoughValveLLB.Location = New System.Drawing.Point(24, 448)
        Me.GasLineRoughValveLLB.Name = "GasLineRoughValveLLB"
        Me.GasLineRoughValveLLB.Size = New System.Drawing.Size(552, 90)
        Me.GasLineRoughValveLLB.TabIndex = 125
        Me.GasLineRoughValveLLB.TextColor = System.Drawing.Color.Wheat
        Me.GasLineRoughValveLLB.TextInImage = ""
        Me.GasLineRoughValveLLB.TextLocation = New System.Drawing.Point(0, 0)
        '
        'MesaValvePM6
        '
        Me.MesaValvePM6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MesaValvePM6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MesaValvePM6.CXStyle = AVP_Robot_Project.RoundRectangleStatusControl.CX_Style.CX7
        Me.MesaValvePM6.FixedSize = False
        Me.MesaValvePM6.Location = New System.Drawing.Point(1133, 238)
        Me.MesaValvePM6.Name = "MesaValvePM6"
        Me.MesaValvePM6.Size = New System.Drawing.Size(59, 58)
        Me.MesaValvePM6.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Opened
        Me.MesaValvePM6.Style_CX5 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        Me.MesaValvePM6.Style_CX6 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX6.LLA
        Me.MesaValvePM6.Style_CX7 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX7.PM4
        Me.MesaValvePM6.Style_CX8 = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStyle_CX8.LLA
        Me.MesaValvePM6.TabIndex = 60
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
        'IgcgChamber6
        '
        Me.IgcgChamber6.BackColor = System.Drawing.Color.Transparent
        Me.IgcgChamber6.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.IgcgChamber6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.IgcgChamber6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IgcgChamber6.ForeColor = System.Drawing.Color.DarkBlue
        Me.IgcgChamber6.HeaderHeight = 60
        Me.IgcgChamber6.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.IgcgChamber6.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.IgcgChamber6.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.IgcgChamber6.HeaderVisible = True
        Me.IgcgChamber6.Headerwidth = 49
        Me.IgcgChamber6.IGCGValue = "OFF"
        Me.IgcgChamber6.Location = New System.Drawing.Point(1007, 238)
        Me.IgcgChamber6.Name = "IgcgChamber6"
        Me.IgcgChamber6.Size = New System.Drawing.Size(120, 27)
        Me.IgcgChamber6.TabIndex = 34
        Me.IgcgChamber6.Text = "PM6"
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
        'btnTMProtectedMode
        '
        Me.btnTMProtectedMode.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnTMProtectedMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMProtectedMode.Clickable = True
        Me.btnTMProtectedMode.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMProtectedMode.ColorText_OffStatus = System.Drawing.SystemColors.ControlText
        Me.btnTMProtectedMode.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnTMProtectedMode.ColorText_UnknowStatus = System.Drawing.Color.Black
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
        Me.btnTMProtectedMode.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnTMProtectedMode.UnKnownText = ""
        Me.btnTMProtectedMode.UseClickedEventInForm = True
        Me.btnTMProtectedMode.UseVisualStyleBackColor = True
        Me.btnTMProtectedMode.ValueToBeSend = ""
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
        'btnCancelMove
        '
        Me.btnCancelMove.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCancelMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelMove.Clickable = True
        Me.btnCancelMove.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnCancelMove.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCancelMove.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnCancelMove.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnCancelMove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelMove.Enabled = False
        Me.btnCancelMove.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCancelMove.ErrorText = ""
        Me.btnCancelMove.FlatAppearance.BorderSize = 0
        Me.btnCancelMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelMove.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelMove.ForeColor = System.Drawing.Color.Black
        Me.btnCancelMove.Location = New System.Drawing.Point(1159, 280)
        Me.btnCancelMove.Name = "btnCancelMove"
        Me.btnCancelMove.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCancelMove.OffText = ""
        Me.btnCancelMove.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCancelMove.OnText = ""
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
        'ticHandOriginal
        '
        Me.ticHandOriginal.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Arm_At_Home
        Me.ticHandOriginal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ticHandOriginal.CXStyle = AVP_Robot_Project.RobotHand.CX_Style.CX7
        Me.ticHandOriginal.Image = Global.AVP_Robot_Project.My.Resources.Resources.HandOriginal
        Me.ticHandOriginal.ImageSize = New System.Drawing.Size(140, 140)
        Me.ticHandOriginal.IsChamberPic = False
        Me.ticHandOriginal.IsStretch = False
        Me.ticHandOriginal.Location = New System.Drawing.Point(405, 173)
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
        'LLALeg
        '
        Me.LLALeg.BackColor = System.Drawing.Color.Transparent
        Me.LLALeg.BackgroundImage = CType(resources.GetObject("LLALeg.BackgroundImage"), System.Drawing.Image)
        Me.LLALeg.Cassette_Location = New System.Drawing.Point(30, 30)
        Me.LLALeg.CassettePresent = True
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
        'LLBLeg
        '
        Me.LLBLeg.BackColor = System.Drawing.Color.Transparent
        Me.LLBLeg.BackgroundImage = CType(resources.GetObject("LLBLeg.BackgroundImage"), System.Drawing.Image)
        Me.LLBLeg.Cassette_Location = New System.Drawing.Point(20, 30)
        Me.LLBLeg.CassettePresent = True
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
        'CX_PM4
        '
        Me.CX_PM4.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM4.BackgroundImage = CType(resources.GetObject("CX_PM4.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM4.CX_Supported = AVP_Robot_Project.PMControl.Support_CX.Support_CX7
        Me.CX_PM4.HasShutter = False
        Me.CX_PM4.LabelDisconnect_Location = New System.Drawing.Point(39, 63)
        Me.CX_PM4.Location = New System.Drawing.Point(545, 78)
        Me.CX_PM4.Name = "CX_PM4"
        Me.CX_PM4.PlasmaIsOn = False
        Me.CX_PM4.PM_IN_SCREEN = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.CX_PM4.PM_Type = AVP_Robot_Project.PMControl.PMPosition.IBE_PM4
        Me.CX_PM4.Show_Disconnected = False
        Me.CX_PM4.ShowWafer_Border_ToEdit = False
        Me.CX_PM4.ShutterLocation = New System.Drawing.Point(15, 28)
        Me.CX_PM4.ShutterStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off
        Me.CX_PM4.Size = New System.Drawing.Size(150, 150)
        Me.CX_PM4.TabIndex = 158
        Me.CX_PM4.WaferID = ""
        Me.CX_PM4.WaferLocation = New System.Drawing.Point(61, 19)
        Me.CX_PM4.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
        '
        'CX_PM5
        '
        Me.CX_PM5.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM5.BackgroundImage = CType(resources.GetObject("CX_PM5.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM5.CX_Supported = AVP_Robot_Project.PMControl.Support_CX.Support_CX7
        Me.CX_PM5.HasShutter = False
        Me.CX_PM5.LabelDisconnect_Location = New System.Drawing.Point(30, 40)
        Me.CX_PM5.Location = New System.Drawing.Point(601, 223)
        Me.CX_PM5.Name = "CX_PM5"
        Me.CX_PM5.PlasmaIsOn = False
        Me.CX_PM5.PM_IN_SCREEN = AVP_Robot_Project.PMControl.Support_Screen.TM
        Me.CX_PM5.PM_Type = AVP_Robot_Project.PMControl.PMPosition.PVD_PM5
        Me.CX_PM5.Show_Disconnected = False
        Me.CX_PM5.ShowWafer_Border_ToEdit = False
        Me.CX_PM5.ShutterLocation = New System.Drawing.Point(15, 28)
        Me.CX_PM5.ShutterStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off
        Me.CX_PM5.Size = New System.Drawing.Size(184, 99)
        Me.CX_PM5.TabIndex = 158
        Me.CX_PM5.WaferID = ""
        Me.CX_PM5.WaferLocation = New System.Drawing.Point(60, 11)
        Me.CX_PM5.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
        '
        'CX_PM6
        '
        Me.CX_PM6.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM6.BackgroundImage = CType(resources.GetObject("CX_PM6.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM6.CX_Supported = AVP_Robot_Project.PMControl.Support_CX.Support_CX7
        Me.CX_PM6.HasShutter = False
        Me.CX_PM6.LabelDisconnect_Location = New System.Drawing.Point(39, 63)
        Me.CX_PM6.Location = New System.Drawing.Point(1133, 443)
        Me.CX_PM6.Name = "CX_PM6"
        Me.CX_PM6.PlasmaIsOn = False
        Me.CX_PM6.PM_IN_SCREEN = AVP_Robot_Project.PMControl.Support_Screen.ProcessScreen
        Me.CX_PM6.PM_Type = AVP_Robot_Project.PMControl.PMPosition.PVD_PM5
        Me.CX_PM6.Show_Disconnected = False
        Me.CX_PM6.ShowWafer_Border_ToEdit = False
        Me.CX_PM6.ShutterLocation = New System.Drawing.Point(15, 28)
        Me.CX_PM6.ShutterStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off
        Me.CX_PM6.Size = New System.Drawing.Size(184, 99)
        Me.CX_PM6.TabIndex = 158
        Me.CX_PM6.WaferID = ""
        Me.CX_PM6.WaferLocation = New System.Drawing.Point(60, 11)
        Me.CX_PM6.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
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
        'lblFlashing
        '
        Me.lblFlashing.Color1 = System.Drawing.Color.Yellow
        Me.lblFlashing.Color2 = System.Drawing.Color.Yellow
        Me.lblFlashing.FlashingInterval = 2000
        Me.lblFlashing.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlashing.ForeColor = System.Drawing.Color.Yellow
        Me.lblFlashing.Location = New System.Drawing.Point(1011, 424)
        Me.lblFlashing.Name = "lblFlashing"
        Me.lblFlashing.Size = New System.Drawing.Size(247, 106)
        Me.lblFlashing.TabIndex = 246
        Me.lblFlashing.Text = "Flashing Label"
        Me.lblFlashing.Visible = False
        '
        'CassettesPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.lblFlashing)
        Me.Controls.Add(Me.ticHandOriginal)
        Me.Controls.Add(Me.btnLeftTool)
        Me.Controls.Add(Me.btnRightTool)
        Me.Controls.Add(Me.btnCancelMove)
        Me.Controls.Add(Me.LLBIgStatus)
        Me.Controls.Add(Me.LLAIgStatus)
        Me.Controls.Add(Me.btnTMProtectedMode)
        Me.Controls.Add(Me.crcTMWaterPump)
        Me.Controls.Add(Me.btnTool)
        Me.Controls.Add(Me.btnMechineTool)
        Me.Controls.Add(Me.stwSemiautoTransferWafer)
        Me.Controls.Add(Me.lblRoughPumpInUse)
        Me.Controls.Add(Me.IgcgChamber1)
        Me.Controls.Add(Me.IgcgChamber2)
        Me.Controls.Add(Me.IgcgChamber3)
        Me.Controls.Add(Me.IgcgChamber5)
        Me.Controls.Add(Me.MesaValvePM1)
        Me.Controls.Add(Me.MesaValvePM2)
        Me.Controls.Add(Me.MesaValvePM3)
        Me.Controls.Add(Me.MesaValvePM4)
        Me.Controls.Add(Me.IgcgChamber4)
        Me.Controls.Add(Me.MesaValvePM5)
        Me.Controls.Add(Me.MesaValveLLA)
        Me.Controls.Add(Me.MesaValveLLB)
        Me.Controls.Add(Me.awcAligner)
        Me.Controls.Add(Me.Robot_Body)
        Me.Controls.Add(Me.GasLineVentValveLLB)
        Me.Controls.Add(Me.IgcgChamber6)
        Me.Controls.Add(Me.MesaValvePM6)
        Me.Controls.Add(Me.GasLineRoughValveLLB)
        Me.Controls.Add(Me.GasLineRoughValveLLA)
        Me.Controls.Add(Me.GasLineVentValveLLA)
        Me.Controls.Add(Me.LLALeg)
        Me.Controls.Add(Me.LLBLeg)
        Me.Controls.Add(Me.CX_PM1)
        Me.Controls.Add(Me.CX_PM2)
        Me.Controls.Add(Me.CX_PM3)
        Me.Controls.Add(Me.CX_PM4)
        Me.Controls.Add(Me.CX_PM5)
        Me.Controls.Add(Me.ibsHivacButton)
        Me.Controls.Add(Me.TMCtl)
        Me.Controls.Add(Me.RoughPumpControl)
        Me.Controls.Add(Me.crcLLBCryo)
        Me.Controls.Add(Me.crcLLACryo)
        Me.Controls.Add(Me.lblLLASlowVent)
        Me.Controls.Add(Me.lblLLBSlowVent)
        Me.Controls.Add(Me.lblLLBFastVent)
        Me.Controls.Add(Me.lblLLAFastRough)
        Me.Controls.Add(Me.lblFastVentValve)
        Me.Controls.Add(Me.tabGroup)
        Me.Controls.Add(Me.lccLoadLockB)
        Me.Controls.Add(Me.lblLLBFastRough)
        Me.Controls.Add(Me.lblLLAFastVent)
        Me.Controls.Add(Me.CX_PM6)
        Me.Controls.Add(Me.ValveRough)
        Me.Controls.Add(Me.ValveVent)
        Me.Controls.Add(Me.ValveLLBFastVent)
        Me.Controls.Add(Me.ValveLLASlowRough)
        Me.Controls.Add(Me.ValveLLBFastRough)
        Me.Controls.Add(Me.ValveLLAFastRough)
        Me.Controls.Add(Me.ValveLLBSlowRough)
        Me.Controls.Add(Me.ValveLLBSlowVent)
        Me.Controls.Add(Me.ValveLLAFastVent)
        Me.Controls.Add(Me.ValveLLASlowVent)
        Me.Controls.Add(Me.crcTMCryo)
        Me.Controls.Add(Me.lblLLASlowRough)
        Me.Controls.Add(Me.lblLLBSlowRough)
        Me.Controls.Add(Me.lblFastRoughtValve)
        Me.Controls.Add(Me.lccLoadLockA)
        Me.Controls.Add(Me.HivacValveLLB)
        Me.Controls.Add(Me.HivacValveLLA)
        Me.Controls.Add(Me.GasLineNitrogen)
        Me.Controls.Add(Me.lblStatusText)
        Me.Controls.Add(Me.lblCoreMessageBoxText)
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
    Friend WithEvents IgcgChamber4 As AVP_Robot_Project.IGCGControl
    Friend WithEvents IgcgChamber5 As AVP_Robot_Project.IGCGControl
    Friend WithEvents stwSemiautoTransferWafer As AVP_Robot_Project.SemiautoTranferWaferControl
    Friend WithEvents atwAutoTransferWafer As AVP_Robot_Project.AutoTransferWaferControl
    Friend WithEvents sccSerialCommand As AVP_Robot_Project.SerialCommandControl
    Friend WithEvents lccLoadLockB As AVP_Robot_Project.LockCassetteControl

    Friend WithEvents HivacValveLLB As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents HivacValveLLA As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValveLLA As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValvePM1 As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValvePM2 As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValvePM3 As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValvePM4 As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents MesaValvePM5 As AVP_Robot_Project.RoundRectangleStatusControl
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
    Friend WithEvents GasLineVentValveLLA As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents ibsHivacButton As AVP_Robot_Project.ImageHivacTMTransferModule
    Friend WithEvents GasLineRoughValveLLB As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents GasLineVentValveLLB As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents GasLineRoughValveLLA As AVP_Robot_Project.TransparentImageControl
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
    Friend WithEvents GasLineNitrogen As AVP_Robot_Project.TransparentImageControl
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
    Friend WithEvents CX_PM4 As AVP_Robot_Project.PMControl
    Friend WithEvents CX_PM5 As AVP_Robot_Project.PMControl
    Friend WithEvents CX_PM6 As AVP_Robot_Project.PMControl
    Friend WithEvents MesaValvePM6 As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents Robot_Body As AVP_Robot_Project.RobotBody
    Friend WithEvents IgcgChamber6 As AVP_Robot_Project.IGCGControl
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
    Friend WithEvents lblFlashing As AVP_Robot_Project.FlashingLabel
End Class
