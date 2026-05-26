<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chamber1Panel
    Inherits AVP_Robot_Project.ChamberPanel

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Chamber1Panel))
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.spsSuppressorPowerSupply = New AVP_Robot_Project.SuppressorPowerSupplyControl
        Me.prcRunProcessRecipe = New AVP_Robot_Project.ProcessRecipeControl
        Me.prmProcessMonitor = New AVP_Robot_Project.ProcessMonitor
        Me.gccGasController = New AVP_Robot_Project.GasControllerControl
        Me.ftcFixtureControlContinuous = New AVP_Robot_Project.FixtureControl
        Me.ChamberInterlocks = New AVP_Robot_Project.ChamberInterlocks
        Me.rfpwRFPowerSupply = New AVP_Robot_Project.RFPowerSupply
        Me.cgcMG = New AVP_Robot_Project.CGControl
        Me.cgcRLCG = New AVP_Robot_Project.CGControl
        Me.cgcFLCG = New AVP_Robot_Project.CGControl
        Me.spsBeamPowerSupply = New AVP_Robot_Project.BeamPowerSupplyControl
        Me.dpsBodyPowerSupply = New AVP_Robot_Project.BodyPowerSupply
        Me.ftcFixtureControlSweep = New AVP_Robot_Project.FixtureControl
        Me.ftcFixtureControlStatic = New AVP_Robot_Project.FixtureControl
        Me.cmsTooltipMachine = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMachineOnline = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMachinePumpDown = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMachineVent = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMachineCryoOn = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMachineCryoPumpRegen = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMachineCryoAutoRegen = New System.Windows.Forms.ToolStripMenuItem
        Me.cmstooltipFixture = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuFixtureOnClamp = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFixtureHomeTiltAxis = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFixtureHomeRotationAxis = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFixtureStartRotationAxis = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFixtureHomeAllAxis = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFixtureStopAllAxis = New System.Windows.Forms.ToolStripMenuItem
        Me.BaCenterControl = New AVP_Robot_Project.BACenterControl
        Me.tmWaitingForHivacValveChange = New System.Windows.Forms.Timer(Me.components)
        Me.ValveControlMesa = New AVP_Robot_Project.RoundRectangleStatusControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTemperture = New System.Windows.Forms.TextBox
        Me.usrStatusPanel = New AVP_Robot_Project.usrStatusPanel
        Me.PowerStatusPanel = New AVP_Robot_Project.PowerStatusPanel
        Me.cmsTooltipValveStatus = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuFixtureOpenWaterValve = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFixtureOpenFlowCool = New System.Windows.Forms.ToolStripMenuItem
        Me.btnTooltipValveStatus = New System.Windows.Forms.Button
        Me.ticGasPump = New AVP_Robot_Project.ValveControl
        Me.ticGasLine2 = New AVP_Robot_Project.TransparentImageControl
        Me.ValveRoughLine = New AVP_Robot_Project.ValveControl
        Me.ticGasLine5 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.ticGasLine3 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.ticGasLine4 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.ticIBEBox = New AVP_Robot_Project.TransparentImageControl
        Me.PlasmaControl = New AVP_Robot_Project.ValveRingControl
        Me.ScreenMachine = New AVP_Robot_Project.ScreenMachine
        Me.TransparentImageControl2 = New AVP_Robot_Project.TransparentImageControl
        Me.FixtureControl = New AVP_Robot_Project.ValveRingControl
        Me.ValveWaterPump = New AVP_Robot_Project.ValveControl
        Me.ValveRingControl = New AVP_Robot_Project.ValveRingControl
        Me.TransparentImageControl1 = New AVP_Robot_Project.TransparentImageControl
        Me.ImageBinaryStatusControl9 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.ValveControlPBN = New AVP_Robot_Project.ValveControl
        Me.ValveControlForeline = New AVP_Robot_Project.ValveControl
        Me.ValveControlFlowCoolHe = New AVP_Robot_Project.ValveControl
        Me.ValveControlVent = New AVP_Robot_Project.ValveControl
        Me.ImageBinaryStatusControl3 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.ValveControlArgon = New AVP_Robot_Project.ValveControl
        Me.ImageBinaryStatusControl2 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.btnTooltipFixture = New System.Windows.Forms.Button
        Me.ValveControlRough = New AVP_Robot_Project.ValveControl
        Me.ValveSupplyArgon = New AVP_Robot_Project.ValveControl
        Me.ValveControlCryoPump = New AVP_Robot_Project.ValveControl
        Me.ValveSupplyFlowCoolHe = New AVP_Robot_Project.ValveControl
        Me.ValveSupplyPBN = New AVP_Robot_Project.ValveControl
        Me.ImageBinaryStatusControl4 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.picBackGround = New System.Windows.Forms.PictureBox
        Me.lblDisconnect = New System.Windows.Forms.Label
         Me.cmsTooltipMachine.SuspendLayout()
        Me.cmstooltipFixture.SuspendLayout()
        Me.cmsTooltipValveStatus.SuspendLayout()
        CType(Me.picBackGround, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(406, 212)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Foreline"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(466, 492)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Rough"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(740, 478)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Vent"
        '
        'spsSuppressorPowerSupply
        '
        Me.spsSuppressorPowerSupply.BackColor = System.Drawing.Color.Transparent
        Me.spsSuppressorPowerSupply.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.spsSuppressorPowerSupply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.spsSuppressorPowerSupply.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spsSuppressorPowerSupply.HeaderHeight = 28
        Me.spsSuppressorPowerSupply.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.spsSuppressorPowerSupply.HeaderTextColor = System.Drawing.Color.Black
        Me.spsSuppressorPowerSupply.HeaderVisible = True
        Me.spsSuppressorPowerSupply.Location = New System.Drawing.Point(0, 403)
        Me.spsSuppressorPowerSupply.Name = "spsSuppressorPowerSupply"
        Me.spsSuppressorPowerSupply.Size = New System.Drawing.Size(310, 155)
        Me.spsSuppressorPowerSupply.TabIndex = 49
        Me.spsSuppressorPowerSupply.Text = "Suppressor Power Supply"
        '
        'prcRunProcessRecipe
        '
        Me.prcRunProcessRecipe.BackColor = System.Drawing.Color.Transparent
        Me.prcRunProcessRecipe.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.prcRunProcessRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.prcRunProcessRecipe.Chamber = Nothing
        Me.prcRunProcessRecipe.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prcRunProcessRecipe.HeaderHeight = 28
        Me.prcRunProcessRecipe.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.prcRunProcessRecipe.HeaderTextColor = System.Drawing.Color.Black
        Me.prcRunProcessRecipe.HeaderVisible = True
        Me.prcRunProcessRecipe.Location = New System.Drawing.Point(870, 576)
        Me.prcRunProcessRecipe.Name = "prcRunProcessRecipe"
        Me.prcRunProcessRecipe.RecipeName = Nothing
        Me.prcRunProcessRecipe.Size = New System.Drawing.Size(200, 107)
        Me.prcRunProcessRecipe.TabIndex = 9
        Me.prcRunProcessRecipe.Text = "Run Process Recipe"
        '
        'prmProcessMonitor
        '
        Me.prmProcessMonitor.BackColor = System.Drawing.Color.Transparent
        Me.prmProcessMonitor.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.prmProcessMonitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.prmProcessMonitor.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prmProcessMonitor.HeaderHeight = 32
        Me.prmProcessMonitor.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.prmProcessMonitor.HeaderTextColor = System.Drawing.Color.Black
        Me.prmProcessMonitor.HeaderVisible = True
        Me.prmProcessMonitor.Location = New System.Drawing.Point(870, 317)
        Me.prmProcessMonitor.Name = "prmProcessMonitor"
        Me.prmProcessMonitor.Size = New System.Drawing.Size(200, 246)
        Me.prmProcessMonitor.TabIndex = 8
        Me.prmProcessMonitor.Text = "Process Monitor"
        '
        'gccGasController
        '
        Me.gccGasController.BackColor = System.Drawing.Color.Transparent
        Me.gccGasController.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.gccGasController.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gccGasController.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gccGasController.HeaderHeight = 32
        Me.gccGasController.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.gccGasController.HeaderTextColor = System.Drawing.Color.Black
        Me.gccGasController.HeaderVisible = True
        Me.gccGasController.Location = New System.Drawing.Point(870, 119)
        Me.gccGasController.Name = "gccGasController"
        Me.gccGasController.Size = New System.Drawing.Size(200, 185)
        Me.gccGasController.TabIndex = 7
        Me.gccGasController.Text = "Gas Controller"
        '
        'ftcFixtureControlContinuous
        '
        Me.ftcFixtureControlContinuous.BackColor = System.Drawing.Color.Transparent
        Me.ftcFixtureControlContinuous.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.ftcFixtureControlContinuous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ftcFixtureControlContinuous.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ftcFixtureControlContinuous.HeaderHeight = 28
        Me.ftcFixtureControlContinuous.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.ftcFixtureControlContinuous.HeaderTextColor = System.Drawing.Color.Black
        Me.ftcFixtureControlContinuous.HeaderVisible = True
        Me.ftcFixtureControlContinuous.Header.Enabled = False
        Me.ftcFixtureControlContinuous.Location = New System.Drawing.Point(586, 528)
        Me.ftcFixtureControlContinuous.Name = "ftcFixtureControlContinuous"
        Me.ftcFixtureControlContinuous.Size = New System.Drawing.Size(271, 156)
        Me.ftcFixtureControlContinuous.TabIndex = 38
        '
        'ChamberInterlocks
        '
        Me.ChamberInterlocks.BackColor = System.Drawing.Color.Transparent
        Me.ChamberInterlocks.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.ChamberInterlocks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ChamberInterlocks.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChamberInterlocks.HeaderHeight = 28
        Me.ChamberInterlocks.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.ChamberInterlocks.HeaderTextColor = System.Drawing.Color.Black
        Me.ChamberInterlocks.HeaderVisible = True
        Me.ChamberInterlocks.Location = New System.Drawing.Point(1074, 509)
        Me.ChamberInterlocks.Name = "ChamberInterlocks"
        Me.ChamberInterlocks.Size = New System.Drawing.Size(194, 210)
        Me.ChamberInterlocks.TabIndex = 3
        Me.ChamberInterlocks.Text = "Chamber Interlocks"
        '
        'rfpwRFPowerSupply
        '
        Me.rfpwRFPowerSupply.BackColor = System.Drawing.Color.Transparent
        Me.rfpwRFPowerSupply.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.rfpwRFPowerSupply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.rfpwRFPowerSupply.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rfpwRFPowerSupply.HeaderHeight = 32
        Me.rfpwRFPowerSupply.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.rfpwRFPowerSupply.HeaderTextColor = System.Drawing.Color.Black
        Me.rfpwRFPowerSupply.HeaderVisible = True
        Me.rfpwRFPowerSupply.Location = New System.Drawing.Point(0, 91)
        Me.rfpwRFPowerSupply.Name = "rfpwRFPowerSupply"
        Me.rfpwRFPowerSupply.Size = New System.Drawing.Size(310, 134)
        Me.rfpwRFPowerSupply.TabIndex = 0
        Me.rfpwRFPowerSupply.Text = "RF Power Supply"
        '
        'cgcMG
        '
        Me.cgcMG.BackColor = System.Drawing.Color.Transparent
        Me.cgcMG.BackgroundImage = CType(resources.GetObject("cgcMG.BackgroundImage"), System.Drawing.Image)
        Me.cgcMG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cgcMG.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cgcMG.HeaderHeight = 25
        Me.cgcMG.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.cgcMG.HeaderTextColor = System.Drawing.Color.Black
        Me.cgcMG.HeaderVisible = True
        Me.cgcMG.Location = New System.Drawing.Point(757, 343)
        Me.cgcMG.Name = "cgcMG"
        Me.cgcMG.Size = New System.Drawing.Size(83, 57)
        Me.cgcMG.TabIndex = 6
        Me.cgcMG.Text = "MG"
        '
        'cgcRLCG
        '
        Me.cgcRLCG.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.cgcRLCG.BackgroundImage = CType(resources.GetObject("cgcRLCG.BackgroundImage"), System.Drawing.Image)
        Me.cgcRLCG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cgcRLCG.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cgcRLCG.HeaderHeight = 25
        Me.cgcRLCG.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.cgcRLCG.HeaderTextColor = System.Drawing.Color.Black
        Me.cgcRLCG.HeaderVisible = True
        Me.cgcRLCG.Location = New System.Drawing.Point(362, 489)
        Me.cgcRLCG.Name = "cgcRLCG"
        Me.cgcRLCG.Size = New System.Drawing.Size(83, 57)
        Me.cgcRLCG.TabIndex = 5
        Me.cgcRLCG.Text = "R.L. CG"
        '
        'cgcFLCG
        '
        Me.cgcFLCG.BackColor = System.Drawing.Color.Transparent
        Me.cgcFLCG.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.cgcFLCG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cgcFLCG.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cgcFLCG.HeaderHeight = 25
        Me.cgcFLCG.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.cgcFLCG.HeaderTextColor = System.Drawing.Color.Black
        Me.cgcFLCG.HeaderVisible = True
        Me.cgcFLCG.Location = New System.Drawing.Point(362, 91)
        Me.cgcFLCG.Name = "cgcFLCG"
        Me.cgcFLCG.Size = New System.Drawing.Size(83, 57)
        Me.cgcFLCG.TabIndex = 4
        Me.cgcFLCG.Text = "F.L. CG"
        '
        'spsBeamPowerSupply
        '
        Me.spsBeamPowerSupply.BackColor = System.Drawing.Color.Transparent
        Me.spsBeamPowerSupply.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.spsBeamPowerSupply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.spsBeamPowerSupply.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spsBeamPowerSupply.HeaderHeight = 28
        Me.spsBeamPowerSupply.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.spsBeamPowerSupply.HeaderTextColor = System.Drawing.Color.Black
        Me.spsBeamPowerSupply.HeaderVisible = True
        Me.spsBeamPowerSupply.Location = New System.Drawing.Point(0, 238)
        Me.spsBeamPowerSupply.Name = "spsBeamPowerSupply"
        Me.spsBeamPowerSupply.Size = New System.Drawing.Size(310, 152)
        Me.spsBeamPowerSupply.TabIndex = 1
        Me.spsBeamPowerSupply.Text = "Beam Power Supply"
        '
        'dpsBodyPowerSupply
        '
        Me.dpsBodyPowerSupply.BackColor = System.Drawing.Color.Transparent
        Me.dpsBodyPowerSupply.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.dpsBodyPowerSupply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.dpsBodyPowerSupply.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpsBodyPowerSupply.HeaderHeight = 32
        Me.dpsBodyPowerSupply.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.dpsBodyPowerSupply.HeaderTextColor = System.Drawing.Color.Black
        Me.dpsBodyPowerSupply.HeaderVisible = True
        Me.dpsBodyPowerSupply.Location = New System.Drawing.Point(0, 571)
        Me.dpsBodyPowerSupply.Name = "dpsBodyPowerSupply"
        Me.dpsBodyPowerSupply.Size = New System.Drawing.Size(310, 145)
        Me.dpsBodyPowerSupply.TabIndex = 2
        Me.dpsBodyPowerSupply.Text = "Body - Filament Power Supply"
        '
        'ftcFixtureControlSweep
        '
        Me.ftcFixtureControlSweep.BackColor = System.Drawing.Color.Transparent
        Me.ftcFixtureControlSweep.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.ftcFixtureControlSweep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ftcFixtureControlSweep.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ftcFixtureControlSweep.HeaderHeight = 30
        Me.ftcFixtureControlSweep.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.ftcFixtureControlSweep.HeaderTextColor = System.Drawing.Color.Black
        Me.ftcFixtureControlSweep.HeaderVisible = True
        Me.ftcFixtureControlSweep.Header.Enabled = False
        Me.ftcFixtureControlSweep.Location = New System.Drawing.Point(586, 528)
        Me.ftcFixtureControlSweep.Name = "ftcFixtureControlSweep"
        Me.ftcFixtureControlSweep.Size = New System.Drawing.Size(275, 156)
        Me.ftcFixtureControlSweep.TabIndex = 38
        Me.ftcFixtureControlSweep.Visible = False
        '
        'ftcFixtureControlStatic
        '
        Me.ftcFixtureControlStatic.BackColor = System.Drawing.Color.Transparent
        Me.ftcFixtureControlStatic.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.ftcFixtureControlStatic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ftcFixtureControlStatic.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ftcFixtureControlStatic.HeaderHeight = 28
        Me.ftcFixtureControlStatic.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.ftcFixtureControlStatic.HeaderTextColor = System.Drawing.Color.Black
        Me.ftcFixtureControlStatic.HeaderVisible = True
        Me.ftcFixtureControlStatic.Header.Enabled = False
        Me.ftcFixtureControlStatic.Location = New System.Drawing.Point(586, 528)
        Me.ftcFixtureControlStatic.Name = "ftcFixtureControlStatic"
        Me.ftcFixtureControlStatic.Size = New System.Drawing.Size(271, 156)
        Me.ftcFixtureControlStatic.TabIndex = 11
        Me.ftcFixtureControlStatic.Visible = False
        '
        'cmsTooltipMachine
        '
        Me.cmsTooltipMachine.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsTooltipMachine.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMachineOnline, Me.mnuMachinePumpDown, Me.mnuMachineVent, Me.mnuMachineCryoOn, Me.mnuMachineCryoPumpRegen, Me.mnuMachineCryoAutoRegen})
        Me.cmsTooltipMachine.Name = "cmsMechineTool"
        Me.cmsTooltipMachine.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsTooltipMachine.ShowImageMargin = False
        Me.cmsTooltipMachine.Size = New System.Drawing.Size(179, 136)
        '
        'mnuMachineOnline
        '
        Me.mnuMachineOnline.Name = "mnuMachineOnline"
        Me.mnuMachineOnline.Size = New System.Drawing.Size(178, 22)
        Me.mnuMachineOnline.Text = "Online"
        '
        'mnuMachinePumpDown
        '
        Me.mnuMachinePumpDown.Name = "mnuMachinePumpDown"
        Me.mnuMachinePumpDown.Size = New System.Drawing.Size(178, 22)
        Me.mnuMachinePumpDown.Text = "Pump Down"
        '
        'mnuMachineVent
        '
        Me.mnuMachineVent.Name = "mnuMachineVent"
        Me.mnuMachineVent.Size = New System.Drawing.Size(178, 22)
        Me.mnuMachineVent.Text = "Vent"
        '
        'mnuMachineCryoOn
        '
        Me.mnuMachineCryoOn.Name = "mnuMachineCryoOn"
        Me.mnuMachineCryoOn.Size = New System.Drawing.Size(178, 22)
        Me.mnuMachineCryoOn.Text = "Cryo On"
        Me.mnuMachineCryoOn.Visible = False
        '
        'mnuMachineCryoPumpRegen
        '
        Me.mnuMachineCryoPumpRegen.Name = "mnuMachineCryoPumpRegen"
        Me.mnuMachineCryoPumpRegen.Size = New System.Drawing.Size(178, 22)
        Me.mnuMachineCryoPumpRegen.Text = "Cryo Pump Regen"
        Me.mnuMachineCryoPumpRegen.Visible = False
        '
        'mnuMachineCryoAutoRegen
        '
        Me.mnuMachineCryoAutoRegen.Name = "mnuMachineCryoAutoRegen"
        Me.mnuMachineCryoAutoRegen.Size = New System.Drawing.Size(178, 22)
        Me.mnuMachineCryoAutoRegen.Text = "Cryo Auto Regen"
        Me.mnuMachineCryoAutoRegen.Visible = False
        '
        'cmstooltipFixture
        '
        Me.cmstooltipFixture.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmstooltipFixture.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFixtureOnClamp, Me.mnuFixtureHomeTiltAxis, Me.mnuFixtureHomeRotationAxis, Me.mnuFixtureStartRotationAxis, Me.mnuFixtureHomeAllAxis, Me.mnuFixtureStopAllAxis})
        Me.cmstooltipFixture.Name = "cmsMechineTool"
        Me.cmstooltipFixture.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmstooltipFixture.ShowImageMargin = False
        Me.cmstooltipFixture.Size = New System.Drawing.Size(192, 136)
        '
        'mnuFixtureOnClamp
        '
        Me.mnuFixtureOnClamp.Name = "mnuFixtureOnClamp"
        Me.mnuFixtureOnClamp.Size = New System.Drawing.Size(191, 22)
        Me.mnuFixtureOnClamp.Text = "Clamp Up"
        '
        'mnuFixtureHomeTiltAxis
        '
        Me.mnuFixtureHomeTiltAxis.Name = "mnuFixtureHomeTiltAxis"
        Me.mnuFixtureHomeTiltAxis.Size = New System.Drawing.Size(191, 22)
        Me.mnuFixtureHomeTiltAxis.Text = "Home Tilt Axis"
        '
        'mnuFixtureHomeRotationAxis
        '
        Me.mnuFixtureHomeRotationAxis.Name = "mnuFixtureHomeRotationAxis"
        Me.mnuFixtureHomeRotationAxis.Size = New System.Drawing.Size(191, 22)
        Me.mnuFixtureHomeRotationAxis.Text = "Home Rotation Axis"
        '
        'mnuFixtureStartRotationAxis
        '
        Me.mnuFixtureStartRotationAxis.Name = "mnuFixtureStartRotationAxis"
        Me.mnuFixtureStartRotationAxis.Size = New System.Drawing.Size(191, 22)
        Me.mnuFixtureStartRotationAxis.Text = "Start Rotation Axis"
        '
        'mnuFixtureHomeAllAxis
        '
        Me.mnuFixtureHomeAllAxis.Name = "mnuFixtureHomeAllAxis"
        Me.mnuFixtureHomeAllAxis.Size = New System.Drawing.Size(191, 22)
        Me.mnuFixtureHomeAllAxis.Text = "Home All Axis"
        '
        'mnuFixtureStopAllAxis
        '
        Me.mnuFixtureStopAllAxis.Name = "mnuFixtureStopAllAxis"
        Me.mnuFixtureStopAllAxis.Size = New System.Drawing.Size(191, 22)
        Me.mnuFixtureStopAllAxis.Text = "Stop All Axis"
        '
        'BaCenterControl
        '
        Me.BaCenterControl.BackColor = System.Drawing.Color.Transparent
        Me.BaCenterControl.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.BaCenterControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BaCenterControl.HeaderBackColor = System.Drawing.Color.SpringGreen
        Me.BaCenterControl.HeaderVisible = False
        Me.BaCenterControl.Location = New System.Drawing.Point(494, 546)
        Me.BaCenterControl.Name = "BaCenterControl"
        Me.BaCenterControl.Size = New System.Drawing.Size(82, 138)
        Me.BaCenterControl.TabIndex = 102
        Me.BaCenterControl.Text = "BaCenterControl1"
        '
        'tmWaitingForHivacValveChange
        '
        '
        'ValveControlMesa
        '
        Me.ValveControlMesa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ValveControlMesa.Location = New System.Drawing.Point(454, 296)
        Me.ValveControlMesa.Name = "ValveControlMesa"
        Me.ValveControlMesa.Size = New System.Drawing.Size(51, 32)
        Me.ValveControlMesa.Status = AVP_Robot_Project.RoundRectangleStatusControl.DisplayStatus.Unknown
        Me.ValveControlMesa.CXStyle = RoundRectangleStatusControl.CX_Style.CX6
        Me.ValveControlMesa.TabIndex = 105
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(553, 495)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Cryo Pump Valve"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(779, 433)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "FlowCool He"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(655, 475)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Temperature"
        Me.Label4.Visible = False
        '
        'txtTemperture
        '
        Me.txtTemperture.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTemperture.Location = New System.Drawing.Point(661, 491)
        Me.txtTemperture.Name = "txtTemperture"
        Me.txtTemperture.ReadOnly = True
        Me.txtTemperture.Size = New System.Drawing.Size(72, 22)
        Me.txtTemperture.TabIndex = 129
        Me.txtTemperture.Visible = False
        '
        'usrStatusPanel
        '
        Me.usrStatusPanel.BackColor = System.Drawing.Color.Transparent
        Me.usrStatusPanel.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.usrStatusPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.usrStatusPanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usrStatusPanel.HeaderHeight = 28
        Me.usrStatusPanel.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.usrStatusPanel.HeaderTextColor = System.Drawing.Color.Black
        Me.usrStatusPanel.HeaderVisible = True
        Me.usrStatusPanel.Location = New System.Drawing.Point(1074, 317)
        Me.usrStatusPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.usrStatusPanel.Name = "usrStatusPanel"
        Me.usrStatusPanel.Size = New System.Drawing.Size(194, 171)
        Me.usrStatusPanel.TabIndex = 130
        Me.usrStatusPanel.Text = "Status"
        '
        'PowerStatusPanel
        '
        Me.PowerStatusPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PowerStatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PowerStatusPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerStatusPanel.Location = New System.Drawing.Point(2, 515)
        Me.PowerStatusPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.PowerStatusPanel.Name = "PowerStatusPanel"
        Me.PowerStatusPanel.Size = New System.Drawing.Size(300, 35)
        Me.PowerStatusPanel.TabIndex = 131
        '
        'cmsTooltipValveStatus
        '
        Me.cmsTooltipValveStatus.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsTooltipValveStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFixtureOpenWaterValve, Me.mnuFixtureOpenFlowCool})
        Me.cmsTooltipValveStatus.Name = "cmsMechineTool"
        Me.cmsTooltipValveStatus.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsTooltipValveStatus.ShowImageMargin = False
        Me.cmsTooltipValveStatus.Size = New System.Drawing.Size(245, 48)
        '
        'mnuFixtureOpenWaterValve
        '
        Me.mnuFixtureOpenWaterValve.Name = "mnuFixtureOpenWaterValve"
        Me.mnuFixtureOpenWaterValve.Size = New System.Drawing.Size(244, 22)
        Me.mnuFixtureOpenWaterValve.Text = "Open Water Valve"
        '
        'mnuFixtureOpenFlowCool
        '
        Me.mnuFixtureOpenFlowCool.Name = "mnuFixtureOpenFlowCool"
        Me.mnuFixtureOpenFlowCool.Size = New System.Drawing.Size(244, 22)
        Me.mnuFixtureOpenFlowCool.Text = "Open Flow Cool Pump Power"
        '
        'btnTooltipValveStatus
        '
        Me.btnTooltipValveStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTooltipValveStatus.FlatAppearance.BorderSize = 0
        Me.btnTooltipValveStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTooltipValveStatus.Image = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnTooltipValveStatus.Location = New System.Drawing.Point(544, 390)
        Me.btnTooltipValveStatus.Name = "btnTooltipValveStatus"
        Me.btnTooltipValveStatus.Size = New System.Drawing.Size(24, 23)
        Me.btnTooltipValveStatus.TabIndex = 101
        Me.btnTooltipValveStatus.UseVisualStyleBackColor = True
        '
        'ticGasPump
        '
        Me.ticGasPump.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ticGasPump.Location = New System.Drawing.Point(347, 634)
        Me.ticGasPump.Name = "ticGasPump"
        Me.ticGasPump.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Pump_Off
        Me.ticGasPump.OffState_ColorText = System.Drawing.Color.Empty
        Me.ticGasPump.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Pump_On
        Me.ticGasPump.OnState_ColorText = System.Drawing.Color.Empty
        Me.ticGasPump.Size = New System.Drawing.Size(124, 80)
        Me.ticGasPump.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ticGasPump.TabIndex = 132
        Me.ticGasPump.TextValue = ""
        '
        'ticGasLine2
        '
        Me.ticGasLine2.BackColor = System.Drawing.Color.Transparent
        Me.ticGasLine2.Enabled = False
        Me.ticGasLine2.Image = Global.AVP_Robot_Project.My.Resources.Resources.Gaseline_1
        Me.ticGasLine2.ImageSize = New System.Drawing.Size(100, 60)
        Me.ticGasLine2.IsChamberPic = False
        Me.ticGasLine2.IsStretch = True
        Me.ticGasLine2.Location = New System.Drawing.Point(495, 415)
        Me.ticGasLine2.Name = "ticGasLine2"
        Me.ticGasLine2.Size = New System.Drawing.Size(127, 78)
        Me.ticGasLine2.TabIndex = 126
        Me.ticGasLine2.TextColor = System.Drawing.Color.Wheat
        Me.ticGasLine2.TextInImage = ""
        Me.ticGasLine2.TextLocation = New System.Drawing.Point(0, 0)
        '
        'ValveRoughLine
        '
        Me.ValveRoughLine.Cursor = System.Windows.Forms.Cursors.Default
        Me.ValveRoughLine.Enabled = False
        Me.ValveRoughLine.Location = New System.Drawing.Point(350, 190)
        Me.ValveRoughLine.Name = "ValveRoughLine"
        Me.ValveRoughLine.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rough_line_Off
        Me.ValveRoughLine.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveRoughLine.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rough_Line_On
        Me.ValveRoughLine.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveRoughLine.Size = New System.Drawing.Size(121, 447)
        Me.ValveRoughLine.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveRoughLine.TabIndex = 132
        Me.ValveRoughLine.TextValue = ""
        '
        'ticGasLine5
        '
        Me.ticGasLine5.Enabled = False
        Me.ticGasLine5.Location = New System.Drawing.Point(601, 187)
        Me.ticGasLine5.Name = "ticGasLine5"
        Me.ticGasLine5.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gaseline_3
        Me.ticGasLine5.OffState_ColorText = System.Drawing.Color.Empty
        Me.ticGasLine5.OnImage = Nothing
        Me.ticGasLine5.OnState_ColorText = System.Drawing.Color.Empty
        Me.ticGasLine5.Size = New System.Drawing.Size(230, 135)
        Me.ticGasLine5.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ticGasLine5.TabIndex = 127
        Me.ticGasLine5.TextValue = ""
        '
        'ticGasLine3
        '
        Me.ticGasLine3.Enabled = False
        Me.ticGasLine3.Location = New System.Drawing.Point(613, 460)
        Me.ticGasLine3.Name = "ticGasLine3"
        Me.ticGasLine3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl2_OffImage
        Me.ticGasLine3.OffState_ColorText = System.Drawing.Color.Empty
        Me.ticGasLine3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl2_OnImage
        Me.ticGasLine3.OnState_ColorText = System.Drawing.Color.Empty
        Me.ticGasLine3.Size = New System.Drawing.Size(228, 7)
        Me.ticGasLine3.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ticGasLine3.TabIndex = 125
        Me.ticGasLine3.TextValue = ""
        '
        'ticGasLine4
        '
        Me.ticGasLine4.Enabled = False
        Me.ticGasLine4.Location = New System.Drawing.Point(624, 412)
        Me.ticGasLine4.Name = "ticGasLine4"
        Me.ticGasLine4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl2_OffImage
        Me.ticGasLine4.OffState_ColorText = System.Drawing.Color.Empty
        Me.ticGasLine4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl2_OnImage
        Me.ticGasLine4.OnState_ColorText = System.Drawing.Color.Empty
        Me.ticGasLine4.Size = New System.Drawing.Size(245, 10)
        Me.ticGasLine4.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ticGasLine4.TabIndex = 124
        Me.ticGasLine4.TextValue = ""
        '
        'ticIBEBox
        '
        Me.ticIBEBox.BackColor = System.Drawing.Color.Transparent
        Me.ticIBEBox.Enabled = False
        Me.ticIBEBox.Image = Global.AVP_Robot_Project.My.Resources.Resources.IBE
        Me.ticIBEBox.ImageSize = New System.Drawing.Size(350, 280)
        Me.ticIBEBox.IsChamberPic = False
        Me.ticIBEBox.IsStretch = True
        Me.ticIBEBox.Location = New System.Drawing.Point(412, 196)
        Me.ticIBEBox.Name = "ticIBEBox"
        Me.ticIBEBox.Size = New System.Drawing.Size(345, 282)
        Me.ticIBEBox.TabIndex = 122
        Me.ticIBEBox.TextColor = System.Drawing.Color.Wheat
        Me.ticIBEBox.TextInImage = ""
        Me.ticIBEBox.TextLocation = New System.Drawing.Point(0, 0)
        '
        'PlasmaControl
        '
        Me.PlasmaControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.PlasmaControl.Location = New System.Drawing.Point(647, 310)
        Me.PlasmaControl.Name = "PlasmaControl"
        Me.PlasmaControl.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Plasma_Status_blue
        Me.PlasmaControl.OffState_ColorText = System.Drawing.Color.Empty
        Me.PlasmaControl.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Plasma_Status_pink
        Me.PlasmaControl.OnState_ColorText = System.Drawing.Color.Empty
        Me.PlasmaControl.Size = New System.Drawing.Size(104, 113)
        Me.PlasmaControl.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.PlasmaControl.TabIndex = 58
        Me.PlasmaControl.TextValue = ""
        '
        'ScreenMachine
        '
        Me.ScreenMachine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ScreenMachine.Location = New System.Drawing.Point(576, 323)
        Me.ScreenMachine.Name = "ScreenMachine"
        Me.ScreenMachine.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.shutter_black
        Me.ScreenMachine.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.shutter_yellow
        Me.ScreenMachine.Size = New System.Drawing.Size(30, 72)
        Me.ScreenMachine.Status = AVP_Robot_Project.ThirdStatusControl.DisplayStatus.Off
        Me.ScreenMachine.TabIndex = 59
        Me.ScreenMachine.UnknowImage = Global.AVP_Robot_Project.My.Resources.Resources.shutter_transparent
        '
        'TransparentImageControl2
        '
        Me.TransparentImageControl2.BackColor = System.Drawing.Color.Transparent
        Me.TransparentImageControl2.Enabled = False
        Me.TransparentImageControl2.Image = Global.AVP_Robot_Project.My.Resources.Resources.HeadHivac
        Me.TransparentImageControl2.ImageSize = New System.Drawing.Size(70, 90)
        Me.TransparentImageControl2.IsChamberPic = False
        Me.TransparentImageControl2.IsStretch = True
        Me.TransparentImageControl2.Location = New System.Drawing.Point(487, 133)
        Me.TransparentImageControl2.Name = "TransparentImageControl2"
        Me.TransparentImageControl2.Size = New System.Drawing.Size(87, 117)
        Me.TransparentImageControl2.TabIndex = 121
        Me.TransparentImageControl2.TextColor = System.Drawing.Color.Wheat
        Me.TransparentImageControl2.TextInImage = ""
        Me.TransparentImageControl2.TextLocation = New System.Drawing.Point(0, 0)
        '
        'FixtureControl
        '
        Me.FixtureControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.FixtureControl.Location = New System.Drawing.Point(507, 318)
        Me.FixtureControl.Name = "FixtureControl"
        Me.FixtureControl.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.fixture_without_wafer
        Me.FixtureControl.OffState_ColorText = System.Drawing.Color.Empty
        Me.FixtureControl.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.fixture_with_wafer
        Me.FixtureControl.OnState_ColorText = System.Drawing.Color.Empty
        Me.FixtureControl.Size = New System.Drawing.Size(70, 71)
        Me.FixtureControl.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.FixtureControl.TabIndex = 58
        Me.FixtureControl.TextValue = ""
        '
        'ValveWaterPump
        '
        Me.ValveWaterPump.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveWaterPump.Location = New System.Drawing.Point(516, 178)
        Me.ValveWaterPump.Name = "ValveWaterPump"
        Me.ValveWaterPump.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BlueButton
        Me.ValveWaterPump.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveWaterPump.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.bigcgIG_OnImage
        Me.ValveWaterPump.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveWaterPump.Size = New System.Drawing.Size(35, 22)
        Me.ValveWaterPump.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveWaterPump.TabIndex = 44
        Me.ValveWaterPump.TextValue = ""
        '
        'ValveRingControl
        '
        Me.ValveRingControl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveRingControl.Location = New System.Drawing.Point(495, 210)
        Me.ValveRingControl.Name = "ValveRingControl"
        Me.ValveRingControl.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.HivacValve_Off
        Me.ValveRingControl.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveRingControl.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.HivacValve
        Me.ValveRingControl.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveRingControl.Size = New System.Drawing.Size(88, 46)
        Me.ValveRingControl.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveRingControl.TabIndex = 58
        Me.ValveRingControl.TextValue = ""
        '
        'TransparentImageControl1
        '
        Me.TransparentImageControl1.BackColor = System.Drawing.Color.Transparent
        Me.TransparentImageControl1.Enabled = False
        Me.TransparentImageControl1.Image = Global.AVP_Robot_Project.My.Resources.Resources.PicNextRoughLineOn
        Me.TransparentImageControl1.ImageSize = New System.Drawing.Size(70, 90)
        Me.TransparentImageControl1.IsChamberPic = False
        Me.TransparentImageControl1.IsStretch = False
        Me.TransparentImageControl1.Location = New System.Drawing.Point(448, 190)
        Me.TransparentImageControl1.Name = "TransparentImageControl1"
        Me.TransparentImageControl1.Size = New System.Drawing.Size(55, 12)
        Me.TransparentImageControl1.TabIndex = 121
        Me.TransparentImageControl1.TextColor = System.Drawing.Color.Wheat
        Me.TransparentImageControl1.TextInImage = ""
        Me.TransparentImageControl1.TextLocation = New System.Drawing.Point(0, 0)
        '
        'ImageBinaryStatusControl9
        '
        Me.ImageBinaryStatusControl9.Enabled = False
        Me.ImageBinaryStatusControl9.Location = New System.Drawing.Point(816, 235)
        Me.ImageBinaryStatusControl9.Name = "ImageBinaryStatusControl9"
        Me.ImageBinaryStatusControl9.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl2_OffImage
        Me.ImageBinaryStatusControl9.OffState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl9.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl2_OnImage
        Me.ImageBinaryStatusControl9.OnState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl9.Size = New System.Drawing.Size(52, 11)
        Me.ImageBinaryStatusControl9.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ImageBinaryStatusControl9.TabIndex = 113
        Me.ImageBinaryStatusControl9.TextValue = ""
        '
        'ValveControlPBN
        '
        Me.ValveControlPBN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveControlPBN.Location = New System.Drawing.Point(827, 176)
        Me.ValveControlPBN.Name = "ValveControlPBN"
        Me.ValveControlPBN.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveControlPBN.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlPBN.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveControlPBN.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlPBN.Size = New System.Drawing.Size(39, 33)
        Me.ValveControlPBN.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveControlPBN.TabIndex = 48
        Me.ValveControlPBN.TextValue = ""
        '
        'ValveControlForeline
        '
        Me.ValveControlForeline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveControlForeline.Location = New System.Drawing.Point(411, 180)
        Me.ValveControlForeline.Name = "ValveControlForeline"
        Me.ValveControlForeline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveControlForeline.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlForeline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveControlForeline.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlForeline.Size = New System.Drawing.Size(39, 33)
        Me.ValveControlForeline.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveControlForeline.TabIndex = 42
        Me.ValveControlForeline.TextValue = ""
        '
        'ValveControlFlowCoolHe
        '
        Me.ValveControlFlowCoolHe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveControlFlowCoolHe.Location = New System.Drawing.Point(809, 398)
        Me.ValveControlFlowCoolHe.Name = "ValveControlFlowCoolHe"
        Me.ValveControlFlowCoolHe.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveControlFlowCoolHe.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlFlowCoolHe.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveControlFlowCoolHe.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlFlowCoolHe.Size = New System.Drawing.Size(39, 33)
        Me.ValveControlFlowCoolHe.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveControlFlowCoolHe.TabIndex = 46
        Me.ValveControlFlowCoolHe.TextValue = ""
        '
        'ValveControlVent
        '
        Me.ValveControlVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveControlVent.Location = New System.Drawing.Point(737, 446)
        Me.ValveControlVent.Name = "ValveControlVent"
        Me.ValveControlVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveControlVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveControlVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlVent.Size = New System.Drawing.Size(39, 33)
        Me.ValveControlVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveControlVent.TabIndex = 44
        Me.ValveControlVent.TextValue = ""
        '
        'ImageBinaryStatusControl3
        '
        Me.ImageBinaryStatusControl3.Enabled = False
        Me.ImageBinaryStatusControl3.Location = New System.Drawing.Point(866, 189)
        Me.ImageBinaryStatusControl3.Name = "ImageBinaryStatusControl3"
        Me.ImageBinaryStatusControl3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl2_OffImage
        Me.ImageBinaryStatusControl3.OffState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl2_OnImage
        Me.ImageBinaryStatusControl3.OnState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl3.Size = New System.Drawing.Size(228, 7)
        Me.ImageBinaryStatusControl3.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ImageBinaryStatusControl3.TabIndex = 52
        Me.ImageBinaryStatusControl3.TextValue = ""
        '
        'ValveControlArgon
        '
        Me.ValveControlArgon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveControlArgon.Location = New System.Drawing.Point(827, 222)
        Me.ValveControlArgon.Name = "ValveControlArgon"
        Me.ValveControlArgon.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveControlArgon.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlArgon.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveControlArgon.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlArgon.Size = New System.Drawing.Size(39, 33)
        Me.ValveControlArgon.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveControlArgon.TabIndex = 47
        Me.ValveControlArgon.TextValue = ""
        '
        'ImageBinaryStatusControl2
        '
        Me.ImageBinaryStatusControl2.Enabled = False
        Me.ImageBinaryStatusControl2.Location = New System.Drawing.Point(865, 235)
        Me.ImageBinaryStatusControl2.Name = "ImageBinaryStatusControl2"
        Me.ImageBinaryStatusControl2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl2_OffImage
        Me.ImageBinaryStatusControl2.OffState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl2_OnImage
        Me.ImageBinaryStatusControl2.OnState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl2.Size = New System.Drawing.Size(228, 7)
        Me.ImageBinaryStatusControl2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ImageBinaryStatusControl2.TabIndex = 51
        Me.ImageBinaryStatusControl2.TextValue = ""
        '
        'btnTooltipFixture
        '
        Me.btnTooltipFixture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTooltipFixture.FlatAppearance.BorderSize = 0
        Me.btnTooltipFixture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTooltipFixture.Image = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnTooltipFixture.Location = New System.Drawing.Point(830, 530)
        Me.btnTooltipFixture.Name = "btnTooltipFixture"
        Me.btnTooltipFixture.Size = New System.Drawing.Size(24, 23)
        Me.btnTooltipFixture.TabIndex = 101
        Me.btnTooltipFixture.UseVisualStyleBackColor = True
        '
        'ValveControlRough
        '
        Me.ValveControlRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveControlRough.Location = New System.Drawing.Point(465, 462)
        Me.ValveControlRough.Name = "ValveControlRough"
        Me.ValveControlRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveControlRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveControlRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlRough.Size = New System.Drawing.Size(39, 33)
        Me.ValveControlRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveControlRough.TabIndex = 43
        Me.ValveControlRough.TextValue = ""
        '
        'ValveSupplyArgon
        '
        Me.ValveSupplyArgon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupplyArgon.Location = New System.Drawing.Point(1074, 222)
        Me.ValveSupplyArgon.Name = "ValveSupplyArgon"
        Me.ValveSupplyArgon.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveSupplyArgon.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyArgon.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveSupplyArgon.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyArgon.Size = New System.Drawing.Size(39, 33)
        Me.ValveSupplyArgon.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupplyArgon.TabIndex = 47
        Me.ValveSupplyArgon.TextValue = ""
        '
        'ValveControlCryoPump
        '
        Me.ValveControlCryoPump.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveControlCryoPump.Location = New System.Drawing.Point(607, 463)
        Me.ValveControlCryoPump.Name = "ValveControlCryoPump"
        Me.ValveControlCryoPump.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveControlCryoPump.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlCryoPump.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveControlCryoPump.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveControlCryoPump.Size = New System.Drawing.Size(39, 33)
        Me.ValveControlCryoPump.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveControlCryoPump.TabIndex = 43
        Me.ValveControlCryoPump.TextValue = ""
        Me.ValveControlCryoPump.Visible = False
        '
        'ValveSupplyFlowCoolHe
        '
        Me.ValveSupplyFlowCoolHe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupplyFlowCoolHe.Location = New System.Drawing.Point(1074, 271)
        Me.ValveSupplyFlowCoolHe.Name = "ValveSupplyFlowCoolHe"
        Me.ValveSupplyFlowCoolHe.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveSupplyFlowCoolHe.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyFlowCoolHe.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveSupplyFlowCoolHe.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyFlowCoolHe.Size = New System.Drawing.Size(39, 33)
        Me.ValveSupplyFlowCoolHe.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupplyFlowCoolHe.TabIndex = 48
        Me.ValveSupplyFlowCoolHe.TextValue = ""
        '
        'ValveSupplyPBN
        '
        Me.ValveSupplyPBN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupplyPBN.Location = New System.Drawing.Point(1074, 176)
        Me.ValveSupplyPBN.Name = "ValveSupplyPBN"
        Me.ValveSupplyPBN.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Closed
        Me.ValveSupplyPBN.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyPBN.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Valve_Opened
        Me.ValveSupplyPBN.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyPBN.Size = New System.Drawing.Size(39, 33)
        Me.ValveSupplyPBN.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupplyPBN.TabIndex = 47
        Me.ValveSupplyPBN.TextValue = ""
        '
        'ImageBinaryStatusControl4
        '
        Me.ImageBinaryStatusControl4.Location = New System.Drawing.Point(848, 284)
        Me.ImageBinaryStatusControl4.Name = "ImageBinaryStatusControl4"
        Me.ImageBinaryStatusControl4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl4_OffImage
        Me.ImageBinaryStatusControl4.OffState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.ImageBinaryStatusControl4_OnImage
        Me.ImageBinaryStatusControl4.OnState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl4.Size = New System.Drawing.Size(252, 135)
        Me.ImageBinaryStatusControl4.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ImageBinaryStatusControl4.TabIndex = 53
        Me.ImageBinaryStatusControl4.TextValue = ""
        '
        'picBackGround
        '
        Me.picBackGround.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picBackGround.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BackGround
        Me.picBackGround.Location = New System.Drawing.Point(0, 85)
        Me.picBackGround.Name = "picBackGround"
        Me.picBackGround.Size = New System.Drawing.Size(1280, 939)
        Me.picBackGround.TabIndex = 133
        Me.picBackGround.TabStop = False
        '
        'lblDisconnect
        '
        Me.lblDisconnect.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblDisconnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDisconnect.Font = New System.Drawing.Font("Times New Roman", 36.0!)
        Me.lblDisconnect.ForeColor = System.Drawing.Color.Red
        Me.lblDisconnect.Location = New System.Drawing.Point(371, 303)
        Me.lblDisconnect.Name = "lblDisconnect"
        Me.lblDisconnect.Size = New System.Drawing.Size(449, 119)
        Me.lblDisconnect.TabIndex = 180
        Me.lblDisconnect.Text = "DISCONNECTED"
        Me.lblDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDisconnect.Visible = False
        '
        'Chamber1Panel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.Controls.Add(Me.lblDisconnect)
        Me.Controls.Add(Me.PowerStatusPanel)
        Me.Controls.Add(Me.spsSuppressorPowerSupply)
        Me.Controls.Add(Me.ChamberInterlocks)
        Me.Controls.Add(Me.btnTooltipValveStatus)
        Me.Controls.Add(Me.ticGasPump)
        Me.Controls.Add(Me.ticGasLine2)
        Me.Controls.Add(Me.ValveRoughLine)
        Me.Controls.Add(Me.txtTemperture)
        Me.Controls.Add(Me.ticGasLine5)
        Me.Controls.Add(Me.ticGasLine3)
        Me.Controls.Add(Me.ticGasLine4)
        Me.Controls.Add(Me.ticIBEBox)
        Me.Controls.Add(Me.PlasmaControl)
        Me.Controls.Add(Me.ValveControlMesa)
        Me.Controls.Add(Me.ScreenMachine)
        Me.Controls.Add(Me.TransparentImageControl2)
        Me.Controls.Add(Me.FixtureControl)
        Me.Controls.Add(Me.ValveWaterPump)
        Me.Controls.Add(Me.ValveRingControl)
        Me.Controls.Add(Me.TransparentImageControl1)
        Me.Controls.Add(Me.ImageBinaryStatusControl9)
        Me.Controls.Add(Me.lblStatusText)
        Me.Controls.Add(Me.ValveControlPBN)
        Me.Controls.Add(Me.ValveControlForeline)
        Me.Controls.Add(Me.ValveControlFlowCoolHe)
        Me.Controls.Add(Me.ValveControlVent)
        Me.Controls.Add(Me.ImageBinaryStatusControl3)
        Me.Controls.Add(Me.ValveControlArgon)
        Me.Controls.Add(Me.ImageBinaryStatusControl2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BaCenterControl)
        Me.Controls.Add(Me.btnTooltipFixture)
        Me.Controls.Add(Me.ValveControlRough)
        Me.Controls.Add(Me.cgcFLCG)
        Me.Controls.Add(Me.rfpwRFPowerSupply)
        Me.Controls.Add(Me.dpsBodyPowerSupply)
        Me.Controls.Add(Me.ValveControlCryoPump)
        Me.Controls.Add(Me.usrStatusPanel)
        Me.Controls.Add(Me.ftcFixtureControlSweep)
        Me.Controls.Add(Me.spsBeamPowerSupply)
        Me.Controls.Add(Me.ftcFixtureControlContinuous)
        Me.Controls.Add(Me.ValveSupplyArgon)
        Me.Controls.Add(Me.ValveSupplyFlowCoolHe)
        Me.Controls.Add(Me.ImageBinaryStatusControl4)
        Me.Controls.Add(Me.ValveSupplyPBN)
        Me.Controls.Add(Me.ftcFixtureControlStatic)
        Me.Controls.Add(Me.cgcRLCG)
        Me.Controls.Add(Me.cgcMG)
        Me.Controls.Add(Me.gccGasController)
        Me.Controls.Add(Me.prcRunProcessRecipe)
        Me.Controls.Add(Me.prmProcessMonitor)
        Me.Controls.Add(Me.picBackGround)
        Me.Name = "Chamber1Panel"
        Me.Controls.SetChildIndex(Me.picBackGround, 0)
        Me.Controls.SetChildIndex(Me.prmProcessMonitor, 0)
        Me.Controls.SetChildIndex(Me.prcRunProcessRecipe, 0)
        Me.Controls.SetChildIndex(Me.gccGasController, 0)
        Me.Controls.SetChildIndex(Me.cgcMG, 0)
        Me.Controls.SetChildIndex(Me.cgcRLCG, 0)
        Me.Controls.SetChildIndex(Me.ftcFixtureControlStatic, 0)
        Me.Controls.SetChildIndex(Me.ValveSupplyPBN, 0)
        Me.Controls.SetChildIndex(Me.ImageBinaryStatusControl4, 0)
        Me.Controls.SetChildIndex(Me.ValveSupplyFlowCoolHe, 0)
        Me.Controls.SetChildIndex(Me.ValveSupplyArgon, 0)
        Me.Controls.SetChildIndex(Me.ftcFixtureControlContinuous, 0)
        Me.Controls.SetChildIndex(Me.spsBeamPowerSupply, 0)
        Me.Controls.SetChildIndex(Me.ftcFixtureControlSweep, 0)
        Me.Controls.SetChildIndex(Me.usrStatusPanel, 0)
        Me.Controls.SetChildIndex(Me.ValveControlCryoPump, 0)
        Me.Controls.SetChildIndex(Me.dpsBodyPowerSupply, 0)
        Me.Controls.SetChildIndex(Me.rfpwRFPowerSupply, 0)
        Me.Controls.SetChildIndex(Me.cgcFLCG, 0)
        Me.Controls.SetChildIndex(Me.ValveControlRough, 0)
        Me.Controls.SetChildIndex(Me.btnTooltipFixture, 0)
        Me.Controls.SetChildIndex(Me.BaCenterControl, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.ImageBinaryStatusControl2, 0)
        Me.Controls.SetChildIndex(Me.ValveControlArgon, 0)
        Me.Controls.SetChildIndex(Me.ImageBinaryStatusControl3, 0)
        Me.Controls.SetChildIndex(Me.ValveControlVent, 0)
        Me.Controls.SetChildIndex(Me.ValveControlFlowCoolHe, 0)
        Me.Controls.SetChildIndex(Me.ValveControlForeline, 0)
        Me.Controls.SetChildIndex(Me.ValveControlPBN, 0)
        Me.Controls.SetChildIndex(Me.ImageBinaryStatusControl9, 0)
        Me.Controls.SetChildIndex(Me.TransparentImageControl1, 0)
        Me.Controls.SetChildIndex(Me.ValveRingControl, 0)
        Me.Controls.SetChildIndex(Me.ValveWaterPump, 0)
        Me.Controls.SetChildIndex(Me.FixtureControl, 0)
        Me.Controls.SetChildIndex(Me.TransparentImageControl2, 0)
        Me.Controls.SetChildIndex(Me.ScreenMachine, 0)
        Me.Controls.SetChildIndex(Me.ValveControlMesa, 0)
        Me.Controls.SetChildIndex(Me.PlasmaControl, 0)
        Me.Controls.SetChildIndex(Me.ticIBEBox, 0)
        Me.Controls.SetChildIndex(Me.ticGasLine4, 0)
        Me.Controls.SetChildIndex(Me.ticGasLine3, 0)
        Me.Controls.SetChildIndex(Me.ticGasLine5, 0)
        Me.Controls.SetChildIndex(Me.txtTemperture, 0)
        Me.Controls.SetChildIndex(Me.ValveRoughLine, 0)
        Me.Controls.SetChildIndex(Me.ticGasLine2, 0)
        Me.Controls.SetChildIndex(Me.ticGasPump, 0)
        Me.Controls.SetChildIndex(Me.btnTooltipValveStatus, 0)
        Me.Controls.SetChildIndex(Me.ChamberInterlocks, 0)
        Me.Controls.SetChildIndex(Me.spsSuppressorPowerSupply, 0)
        Me.Controls.SetChildIndex(Me.PowerStatusPanel, 0)
        Me.Controls.SetChildIndex(Me.lblDisconnect, 0)
        Me.Size = New System.Drawing.Size(1280, 1024)
        Me.cmsTooltipMachine.ResumeLayout(False)
        Me.cmstooltipFixture.ResumeLayout(False)
        Me.cmsTooltipValveStatus.ResumeLayout(False)
        CType(Me.picBackGround, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cgcFLCG As AVP_Robot_Project.CGControl
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cgcRLCG As AVP_Robot_Project.CGControl
    Friend WithEvents cgcMG As AVP_Robot_Project.CGControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChamberInterlocks As AVP_Robot_Project.ChamberInterlocks
    Friend WithEvents ftcFixtureControlContinuous As AVP_Robot_Project.FixtureControl
    Friend WithEvents gccGasController As AVP_Robot_Project.GasControllerControl
    Friend WithEvents prcRunProcessRecipe As AVP_Robot_Project.ProcessRecipeControl
    Friend WithEvents ValveControlForeline As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveControlRough As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveControlVent As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveControlFlowCoolHe As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveControlArgon As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveControlPBN As AVP_Robot_Project.ValveControl
    Friend WithEvents ImageBinaryStatusControl1 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents spsSuppressorPowerSupply As AVP_Robot_Project.SuppressorPowerSupplyControl
    Friend WithEvents rfpwRFPowerSupply As AVP_Robot_Project.RFPowerSupply
    Friend WithEvents prmProcessMonitor As AVP_Robot_Project.ProcessMonitor
    Friend WithEvents ImageBinaryStatusControl2 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ImageBinaryStatusControl3 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ImageBinaryStatusControl4 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents spsBeamPowerSupply As AVP_Robot_Project.BeamPowerSupplyControl
    Friend WithEvents dpsBodyPowerSupply As AVP_Robot_Project.BodyPowerSupply
    Friend WithEvents ScreenMachine As AVP_Robot_Project.ScreenMachine
    Friend WithEvents ftcFixtureControlSweep As AVP_Robot_Project.FixtureControl
    Friend WithEvents ftcFixtureControlStatic As AVP_Robot_Project.FixtureControl
    Friend WithEvents btnTooltipFixture As System.Windows.Forms.Button
    Friend WithEvents mnuMachineCryoOn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmstooltipFixture As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuFixtureOnClamp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFixtureHomeTiltAxis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFixtureHomeRotationAxis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFixtureStartRotationAxis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFixtureHomeAllAxis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFixtureStopAllAxis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMachineCryoPumpRegen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BaCenterControl As AVP_Robot_Project.BACenterControl
    Friend WithEvents tmWaitingForHivacValveChange As System.Windows.Forms.Timer
    Friend WithEvents ValveControlMesa As AVP_Robot_Project.RoundRectangleStatusControl
    Friend WithEvents FixtureControl As AVP_Robot_Project.ValveRingControl
    Friend WithEvents PlasmaControl As AVP_Robot_Project.ValveRingControl
    Friend WithEvents ValveSupplyArgon As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveSupplyFlowCoolHe As AVP_Robot_Project.ValveControl
    Friend WithEvents ImageBinaryStatusControl9 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ValveControlCryoPump As AVP_Robot_Project.ValveControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ValveSupplyPBN As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveWaterPump As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveRingControl As AVP_Robot_Project.ValveRingControl
    Friend WithEvents ticIBEBox As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents ticGasLine4 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ticGasLine3 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ticGasLine2 As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents TransparentImageControl2 As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents ticGasLine5 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents mnuMachineCryoAutoRegen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTemperture As System.Windows.Forms.TextBox
    Friend WithEvents usrStatusPanel As AVP_Robot_Project.usrStatusPanel
    Friend WithEvents PowerStatusPanel As AVP_Robot_Project.PowerStatusPanel
    Friend WithEvents ticGasPump As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveRoughLine As AVP_Robot_Project.ValveControl
    Friend WithEvents TransparentImageControl1 As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents btnTooltipValveStatus As System.Windows.Forms.Button
    Friend WithEvents cmsTooltipValveStatus As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuFixtureOpenWaterValve As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFixtureOpenFlowCool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picBackGround As System.Windows.Forms.PictureBox
    Friend WithEvents lblDisconnect As System.Windows.Forms.Label
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.TitleText = "  "
        Me.ButtonReConnectLocation = New Point(1184, 53)
        Me.ButtonTooltipMachineLocation = New Point(463, 369)
        Me.AlarmTextLocation = New Point(20, 50)
        Me.StatusTextLocation = New Point(22, 726)
        Me.TitleTextLocation = New Point(0, 0)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    
End Class
