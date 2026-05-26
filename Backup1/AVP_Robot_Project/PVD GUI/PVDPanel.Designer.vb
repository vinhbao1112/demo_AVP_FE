<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDPanel
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
        Me.mnuMachineCryoOn = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMachineCryoRegen = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMachineShutDownPower = New System.Windows.Forms.ToolStripMenuItem
        Me.ChuckControl = New AVP_Robot_Project.ChuckControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRoughLineCG = New AVP_Robot_Project.SL_Textbox
        Me.txtForeLineCG = New AVP_Robot_Project.SL_Textbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ChamberInterlock = New AVP_Robot_Project.PVDChamberInterlock
        Me.ParallelMagnet = New AVP_Robot_Project.ParallelMagnet
        Me.BiasPowerSupply = New AVP_Robot_Project.BiasPowerSupply
        Me.GasController = New AVP_Robot_Project.PVDGasController
        Me.GasLine_Vent = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.GasLine_Baratron = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.Baratron = New AVP_Robot_Project.PVDBACenterControl
        Me.btnPVDTooltipMachine = New System.Windows.Forms.Button
        Me.ValveTurbo_Isolation = New AVP_Robot_Project.ValveControl
        Me.TurboPump = New AVP_Robot_Project.PVDTurboPump
        Me.ValveShutOff4 = New AVP_Robot_Project.ValveControl
        Me.CGInformation = New AVP_Robot_Project.PVDCGControl
        Me.ValveShutOff5 = New AVP_Robot_Project.ValveControl
        Me.ValveRough = New AVP_Robot_Project.ValveControl
        Me.btnHivacValve = New AVP_Robot_Project.ButtonIGCGControl
        Me.GasLine_RoughPump = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.Cryo = New AVP_Robot_Project.PVDCryoControl
        Me.MGInformation = New AVP_Robot_Project.PVDCGControl
        Me.ValveSupply1 = New AVP_Robot_Project.ValveControl
        Me.ValveShutOff1 = New AVP_Robot_Project.ValveControl
        Me.VatValveController = New AVP_Robot_Project.VatValveController
        Me.ValveBaratron = New AVP_Robot_Project.ValveControl
        Me.ValveSupply2 = New AVP_Robot_Project.ValveControl
        Me.GasLine_VatValve = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.ValveShutOff3 = New AVP_Robot_Project.ValveControl
        Me.ValveShutOff2 = New AVP_Robot_Project.ValveControl
        Me.ValveSupply3 = New AVP_Robot_Project.ValveControl
        Me.ValveSupply4 = New AVP_Robot_Project.ValveControl
        Me.ValveVent = New AVP_Robot_Project.ValveControl
        Me.GasLine_Turbo_Isolation = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.ValveSupply5 = New AVP_Robot_Project.ValveControl
        Me.RoughPump = New AVP_Robot_Project.ValveControl
        Me.ProcessMonitor = New AVP_Robot_Project.PVDProcessMonitor
        Me.GasLine_ShutOff1 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.GasLine_ShutOff3 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.GasLine_ShutOff4 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.GasLine_ShutOff2 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.GasLine_Supply1 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.GasLine_Supply2 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.GasLine_Supply3 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.GasLine_Supply5 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.GasLine_Supply4 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.GasLine_Total = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.lblDisconnect = New System.Windows.Forms.Label
        Me.btnWPCryo = New System.Windows.Forms.Button
        Me.cmsWPCryo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMachineFastRegen = New System.Windows.Forms.ToolStripMenuItem
        Me.GasLine_ShutOff5 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.TarControl = New AVP_Robot_Project.PVDTarControl
        Me.btnOverrideMode = New AVP_Robot_Project.ButtonIGCGControl
        Me.GasLine_Water = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.ValveWater = New AVP_Robot_Project.ValveControl
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblRoughPumpInUse = New System.Windows.Forms.Label
        Me.ValveMainGas = New AVP_Robot_Project.ValveControl
        Me.lblMainGas = New System.Windows.Forms.Label
        Me.lblNameOfSequenceRunning = New System.Windows.Forms.Label
        Me.lblCurrentPurgeCycle = New System.Windows.Forms.Label
        Me.cmsWPCryo.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMachineCryoOn
        '
        Me.mnuMachineCryoOn.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuMachineCryoOn.Name = "mnuMachineCryoOn"
        Me.mnuMachineCryoOn.Size = New System.Drawing.Size(184, 34)
        Me.mnuMachineCryoOn.Text = "Cryo On"
        '
        'mnuMachineCryoRegen
        '
        Me.mnuMachineCryoRegen.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuMachineCryoRegen.Name = "mnuMachineCryoRegen"
        Me.mnuMachineCryoRegen.Size = New System.Drawing.Size(184, 34)
        Me.mnuMachineCryoRegen.Text = "Cryo Regen"
        '
        'mnuMachineShutDownPower
        '
        Me.mnuMachineShutDownPower.Name = "mnuMachineShutDownPower"
        Me.mnuMachineShutDownPower.Size = New System.Drawing.Size(179, 22)
        Me.mnuMachineShutDownPower.Text = "Shut Down Power"
        '
        'ChuckControl
        '
        Me.ChuckControl.BackColor = System.Drawing.Color.Transparent
        Me.ChuckControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ChuckControl.ClampInstall = False
        Me.ChuckControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChuckControl.Location = New System.Drawing.Point(396, 131)
        Me.ChuckControl.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ChuckControl.Name = "ChuckControl"
        Me.ChuckControl.ShutterStatus = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ChuckControl.Size = New System.Drawing.Size(420, 412)
        Me.ChuckControl.TabIndex = 144
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(820, 401)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 19)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Vent"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(887, 366)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 19)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Baratron"
        '
        'txtRoughLineCG
        '
        Me.txtRoughLineCG.AutoSendEventHandler = False
        Me.txtRoughLineCG.AutoSendKeyTabWhenFinishInput = False
        Me.txtRoughLineCG.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRoughLineCG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoughLineCG.Clickable = True
        Me.txtRoughLineCG.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRoughLineCG.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRoughLineCG.GasName = ""
        Me.txtRoughLineCG.GetDefaultMinMax = False
        Me.txtRoughLineCG.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtRoughLineCG.IsIntergerNumber = False
        Me.txtRoughLineCG.IsNumericTextbox = False
        Me.txtRoughLineCG.IsReadBack = True
        Me.txtRoughLineCG.IsTurboPumpTextbox = False
        Me.txtRoughLineCG.Location = New System.Drawing.Point(863, 497)
        Me.txtRoughLineCG.LogSource = ""
        Me.txtRoughLineCG.Name = "txtRoughLineCG"
        Me.txtRoughLineCG.PermissionCode = ""
        Me.txtRoughLineCG.ReadOnly = True
        Me.txtRoughLineCG.ShowUnitFormat = False
        Me.txtRoughLineCG.Size = New System.Drawing.Size(72, 24)
        Me.txtRoughLineCG.SourceOfMessageBox = ""
        Me.txtRoughLineCG.TabIndex = 176
        Me.txtRoughLineCG.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRoughLineCG.UnitTypeUsed = ""
        Me.txtRoughLineCG.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtRoughLineCG.UseClickEventInForm = True
        Me.txtRoughLineCG.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtRoughLineCG.UseScientificFormat = True
        Me.txtRoughLineCG.Visible = False
        '
        'txtForeLineCG
        '
        Me.txtForeLineCG.AutoSendEventHandler = False
        Me.txtForeLineCG.AutoSendKeyTabWhenFinishInput = False
        Me.txtForeLineCG.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtForeLineCG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtForeLineCG.Clickable = True
        Me.txtForeLineCG.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtForeLineCG.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtForeLineCG.GasName = ""
        Me.txtForeLineCG.GetDefaultMinMax = False
        Me.txtForeLineCG.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtForeLineCG.IsIntergerNumber = False
        Me.txtForeLineCG.IsNumericTextbox = False
        Me.txtForeLineCG.IsReadBack = True
        Me.txtForeLineCG.IsTurboPumpTextbox = False
        Me.txtForeLineCG.Location = New System.Drawing.Point(758, 460)
        Me.txtForeLineCG.LogSource = ""
        Me.txtForeLineCG.Name = "txtForeLineCG"
        Me.txtForeLineCG.PermissionCode = ""
        Me.txtForeLineCG.ReadOnly = True
        Me.txtForeLineCG.ShowUnitFormat = False
        Me.txtForeLineCG.Size = New System.Drawing.Size(86, 24)
        Me.txtForeLineCG.SourceOfMessageBox = ""
        Me.txtForeLineCG.TabIndex = 176
        Me.txtForeLineCG.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtForeLineCG.UnitTypeUsed = ""
        Me.txtForeLineCG.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtForeLineCG.UseClickEventInForm = True
        Me.txtForeLineCG.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtForeLineCG.UseScientificFormat = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(804, 526)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 19)
        Me.Label3.TabIndex = 156
        Me.Label3.Text = "Foreline"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(510, 550)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 19)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "Rough"
        '
        'ChamberInterlock
        '
        Me.ChamberInterlock.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ChamberInterlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ChamberInterlock.ClampWaterVisible = False
        Me.ChamberInterlock.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChamberInterlock.HeaderHeight = 28
        Me.ChamberInterlock.HeaderStatus = DisplayStatus.[On]
        Me.ChamberInterlock.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.ChamberInterlock.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.ChamberInterlock.HeaderVisible = True
        Me.ChamberInterlock.Headerwidth = 60
        Me.ChamberInterlock.IsOnline = False
        Me.ChamberInterlock.LidSensorVisible = False
        Me.ChamberInterlock.LidWaterVisible = False
        Me.ChamberInterlock.Location = New System.Drawing.Point(0, 504)
        Me.ChamberInterlock.Name = "ChamberInterlock"
        Me.ChamberInterlock.Size = New System.Drawing.Size(325, 215)
        Me.ChamberInterlock.SubMBWaterVisible = False
        Me.ChamberInterlock.TabIndex = 138
        Me.ChamberInterlock.TargetMBWaterVisible = False
        Me.ChamberInterlock.TargetWaterVisible = False
        Me.ChamberInterlock.Text = "Chamber Interlock"
        Me.ChamberInterlock.TurboForelineVisible = False
        Me.ChamberInterlock.TurboWaterVisible = False
        '
        'ParallelMagnet
        '
        Me.ParallelMagnet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ParallelMagnet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ParallelMagnet.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParallelMagnet.HeaderHeight = 30
        Me.ParallelMagnet.HeaderStatus = DisplayStatus.[On]
        Me.ParallelMagnet.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.ParallelMagnet.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.ParallelMagnet.HeaderVisible = True
        Me.ParallelMagnet.Headerwidth = 60
        Me.ParallelMagnet.IsOnline = False
        Me.ParallelMagnet.Location = New System.Drawing.Point(957, 267)
        Me.ParallelMagnet.Name = "ParallelMagnet"
        Me.ParallelMagnet.Size = New System.Drawing.Size(325, 135)
        Me.ParallelMagnet.TabIndex = 137
        Me.ParallelMagnet.Text = "Parallel Magnet"
        '
        'BiasPowerSupply
        '
        Me.BiasPowerSupply.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.BiasPowerSupply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BiasPowerSupply.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BiasPowerSupply.HeaderHeight = 30
        Me.BiasPowerSupply.HeaderStatus = DisplayStatus.Off
        Me.BiasPowerSupply.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.BiasPowerSupply.HeaderTextColor = System.Drawing.Color.White
        Me.BiasPowerSupply.HeaderVisible = True
        Me.BiasPowerSupply.Headerwidth = 60
        Me.BiasPowerSupply.IsBiasPowerSupply = True
        Me.BiasPowerSupply.IsOnline = False
        Me.BiasPowerSupply.Location = New System.Drawing.Point(0, 259)
        Me.BiasPowerSupply.Name = "BiasPowerSupply"
        Me.BiasPowerSupply.Size = New System.Drawing.Size(325, 246)
        Me.BiasPowerSupply.TabIndex = 136
        Me.BiasPowerSupply.Text = "Bias Power Supply"
        '
        'GasController
        '
        Me.GasController.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GasController.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GasController.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GasController.Gas1Name = "Argon"
        Me.GasController.Gas2Name = "He"
        Me.GasController.Gas3Name = "Oxygen"
        Me.GasController.Gas4Name = "Nitrogen"
        Me.GasController.Gas5Name = "FlowCool"
        Me.GasController.HeaderHeight = 28
        Me.GasController.HeaderStatus = DisplayStatus.[On]
        Me.GasController.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.GasController.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.GasController.HeaderVisible = True
        Me.GasController.Headerwidth = 60
        Me.GasController.IsOnline = False
        Me.GasController.Location = New System.Drawing.Point(957, 45)
        Me.GasController.Name = "GasController"
        Me.GasController.Size = New System.Drawing.Size(275, 178)
        Me.GasController.TabIndex = 172
        Me.GasController.Text = "Gases Controller"
        '
        'GasLine_Vent
        '
        Me.GasLine_Vent.Enabled = False
        Me.GasLine_Vent.Location = New System.Drawing.Point(559, 389)
        Me.GasLine_Vent.Name = "GasLine_Vent"
        Me.GasLine_Vent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_Vent_Off
        Me.GasLine_Vent.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Vent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_Vent
        Me.GasLine_Vent.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Vent.Size = New System.Drawing.Size(308, 9)
        Me.GasLine_Vent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_Vent.TabIndex = 51
        Me.GasLine_Vent.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_Vent.TextLocIsFix = True
        Me.GasLine_Vent.TextValue = ""
        Me.GasLine_Vent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_Vent.UnknownImage = Nothing
        Me.GasLine_Vent.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'GasLine_Baratron
        '
        Me.GasLine_Baratron.Enabled = False
        Me.GasLine_Baratron.Location = New System.Drawing.Point(559, 358)
        Me.GasLine_Baratron.Name = "GasLine_Baratron"
        Me.GasLine_Baratron.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_Baratron_Off
        Me.GasLine_Baratron.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Baratron.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_Baratron
        Me.GasLine_Baratron.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Baratron.Size = New System.Drawing.Size(368, 9)
        Me.GasLine_Baratron.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_Baratron.TabIndex = 125
        Me.GasLine_Baratron.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_Baratron.TextLocIsFix = True
        Me.GasLine_Baratron.TextValue = ""
        Me.GasLine_Baratron.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_Baratron.UnknownImage = Nothing
        Me.GasLine_Baratron.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'Baratron
        '
        Me.Baratron.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Baratron.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Baratron.HeaderBackColor = System.Drawing.Color.SpringGreen
        Me.Baratron.HeaderVisible = False
        Me.Baratron.IsOnline = False
        Me.Baratron.Location = New System.Drawing.Point(343, 378)
        Me.Baratron.Name = "Baratron"
        Me.Baratron.Size = New System.Drawing.Size(88, 150)
        Me.Baratron.TabIndex = 145
        Me.Baratron.Text = "PvdbaCenterControl1"
        '
        'btnPVDTooltipMachine
        '
        Me.btnPVDTooltipMachine.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnPVDTooltipMachine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPVDTooltipMachine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPVDTooltipMachine.FlatAppearance.BorderSize = 0
        Me.btnPVDTooltipMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPVDTooltipMachine.Location = New System.Drawing.Point(407, 314)
        Me.btnPVDTooltipMachine.Name = "btnPVDTooltipMachine"
        Me.btnPVDTooltipMachine.Size = New System.Drawing.Size(30, 28)
        Me.btnPVDTooltipMachine.TabIndex = 178
        Me.btnPVDTooltipMachine.UseVisualStyleBackColor = True
        '
        'ValveTurbo_Isolation
        '
        Me.ValveTurbo_Isolation.AccessibleName = "Foreline"
        Me.ValveTurbo_Isolation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveTurbo_Isolation.IsCheckSafetyBeforeClick = False
        Me.ValveTurbo_Isolation.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveTurbo_Isolation.Location = New System.Drawing.Point(805, 490)
        Me.ValveTurbo_Isolation.Name = "ValveTurbo_Isolation"
        Me.ValveTurbo_Isolation.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveTurbo_Isolation.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveTurbo_Isolation.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveTurbo_Isolation.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveTurbo_Isolation.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveTurbo_Isolation.Size = New System.Drawing.Size(39, 33)
        Me.ValveTurbo_Isolation.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveTurbo_Isolation.TabIndex = 175
        Me.ValveTurbo_Isolation.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveTurbo_Isolation.TextLocIsFix = True
        Me.ValveTurbo_Isolation.TextValue = ""
        Me.ValveTurbo_Isolation.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveTurbo_Isolation.UnknownImage = Nothing
        Me.ValveTurbo_Isolation.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveTurbo_Isolation.UseClickedEventInForm = True
        '
        'TurboPump
        '
        Me.TurboPump.AlignStyle = AVP_Robot_Project.PVDTurboPump.DisplayStyle.Left
        Me.TurboPump.BackColor = System.Drawing.Color.Transparent
        Me.TurboPump.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Turbo_Pump
        Me.TurboPump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TurboPump.ButtonVisible = False
        Me.TurboPump.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TurboPump.HeaderHeight = 32
        Me.TurboPump.HeaderStatus = DisplayStatus.Off
        Me.TurboPump.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.TurboPump.HeaderTextColor = System.Drawing.Color.White
        Me.TurboPump.HeaderVisible = True
        Me.TurboPump.Headerwidth = 60
        Me.TurboPump.IsOnline = False
        Me.TurboPump.Location = New System.Drawing.Point(648, 404)
        Me.TurboPump.Name = "TurboPump"
        Me.TurboPump.Size = New System.Drawing.Size(100, 122)
        Me.TurboPump.TabIndex = 166
        Me.TurboPump.Text = "TURBO PUMP"
        Me.TurboPump.Visible = False
        '
        'ValveShutOff4
        '
        Me.ValveShutOff4.AccessibleName = "Shutoff Gas4"
        Me.ValveShutOff4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutOff4.IsCheckSafetyBeforeClick = False
        Me.ValveShutOff4.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutOff4.Location = New System.Drawing.Point(353, 285)
        Me.ValveShutOff4.Name = "ValveShutOff4"
        Me.ValveShutOff4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutOff4.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutOff4.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff4.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutOff4.Size = New System.Drawing.Size(39, 33)
        Me.ValveShutOff4.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutOff4.TabIndex = 164
        Me.ValveShutOff4.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutOff4.TextLocIsFix = True
        Me.ValveShutOff4.TextValue = ""
        Me.ValveShutOff4.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutOff4.UnknownImage = Nothing
        Me.ValveShutOff4.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff4.UseClickedEventInForm = True
        '
        'CGInformation
        '
        Me.CGInformation.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.CGInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CGInformation.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CGInformation.HeaderHeight = 25
        Me.CGInformation.HeaderStatus = DisplayStatus.[On]
        Me.CGInformation.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.CGInformation.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.CGInformation.HeaderVisible = True
        Me.CGInformation.Headerwidth = 60
        Me.CGInformation.Location = New System.Drawing.Point(343, 571)
        Me.CGInformation.Name = "CGInformation"
        Me.CGInformation.Size = New System.Drawing.Size(82, 55)
        Me.CGInformation.TabIndex = 161
        Me.CGInformation.Text = "MP"
        Me.CGInformation.Visible = False
        '
        'ValveShutOff5
        '
        Me.ValveShutOff5.AccessibleName = "Shutoff Gas5"
        Me.ValveShutOff5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutOff5.IsCheckSafetyBeforeClick = False
        Me.ValveShutOff5.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutOff5.Location = New System.Drawing.Point(917, 198)
        Me.ValveShutOff5.Name = "ValveShutOff5"
        Me.ValveShutOff5.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutOff5.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff5.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutOff5.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff5.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutOff5.Size = New System.Drawing.Size(39, 33)
        Me.ValveShutOff5.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutOff5.TabIndex = 164
        Me.ValveShutOff5.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutOff5.TextLocIsFix = True
        Me.ValveShutOff5.TextValue = ""
        Me.ValveShutOff5.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutOff5.UnknownImage = Nothing
        Me.ValveShutOff5.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff5.UseClickedEventInForm = True
        '
        'ValveRough
        '
        Me.ValveRough.AccessibleName = "Rough"
        Me.ValveRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveRough.IsCheckSafetyBeforeClick = False
        Me.ValveRough.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveRough.Location = New System.Drawing.Point(477, 549)
        Me.ValveRough.Name = "ValveRough"
        Me.ValveRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Vertical_Valve
        Me.ValveRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Vertical_Valve_On
        Me.ValveRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveRough.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveRough.Size = New System.Drawing.Size(29, 49)
        Me.ValveRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveRough.TabIndex = 158
        Me.ValveRough.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveRough.TextLocIsFix = True
        Me.ValveRough.TextValue = ""
        Me.ValveRough.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveRough.UnknownImage = Nothing
        Me.ValveRough.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveRough.UseClickedEventInForm = True
        '
        'btnHivacValve
        '
        Me.btnHivacValve.AccessibleName = "HiVac"
        Me.btnHivacValve.BackColor = System.Drawing.Color.Transparent
        Me.btnHivacValve.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Vertical_Button_Off
        Me.btnHivacValve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHivacValve.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnHivacValve.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnHivacValve.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnHivacValve.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnHivacValve.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHivacValve.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPower_Off
        Me.btnHivacValve.ErrorText = ""
        Me.btnHivacValve.FlatAppearance.BorderSize = 0
        Me.btnHivacValve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHivacValve.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHivacValve.ForeColor = System.Drawing.Color.White
        Me.btnHivacValve.Location = New System.Drawing.Point(607, 418)
        Me.btnHivacValve.Name = "btnHivacValve"
        Me.btnHivacValve.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Vertical_Button_Off
        Me.btnHivacValve.OffText = "CLOSE"
        Me.btnHivacValve.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Vertical_Button_On
        Me.btnHivacValve.OnText = "OPEN"
        Me.btnHivacValve.Size = New System.Drawing.Size(38, 75)
        Me.btnHivacValve.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnHivacValve.StyleOfButton = AVP_Robot_Project.ButtonStyle.Vertical
        Me.btnHivacValve.TabIndex = 153
        Me.btnHivacValve.Text = "CLOSE"
        Me.btnHivacValve.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Vertical_Button_Unknown
        Me.btnHivacValve.UnKnownText = ""
        Me.btnHivacValve.UseVisualStyleBackColor = False
        '
        'GasLine_RoughPump
        '
        Me.GasLine_RoughPump.Location = New System.Drawing.Point(424, 535)
        Me.GasLine_RoughPump.Name = "GasLine_RoughPump"
        Me.GasLine_RoughPump.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_CG_Off
        Me.GasLine_RoughPump.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_RoughPump.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_CG
        Me.GasLine_RoughPump.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_RoughPump.Size = New System.Drawing.Size(80, 127)
        Me.GasLine_RoughPump.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_RoughPump.TabIndex = 159
        Me.GasLine_RoughPump.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_RoughPump.TextLocIsFix = True
        Me.GasLine_RoughPump.TextValue = ""
        Me.GasLine_RoughPump.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_RoughPump.UnknownImage = Nothing
        Me.GasLine_RoughPump.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'Cryo
        '
        Me.Cryo.AlignStyle = AVP_Robot_Project.PVDCryoControl.DisplayStyle.Left
        Me.Cryo.BackColor = System.Drawing.Color.Transparent
        Me.Cryo.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Turbo_Pump
        Me.Cryo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cryo.ButtonVisible = False
        Me.Cryo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cryo.HeaderHeight = 25
        Me.Cryo.HeaderStatus = DisplayStatus.Off
        Me.Cryo.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.Cryo.HeaderTextColor = System.Drawing.Color.White
        Me.Cryo.HeaderVisible = True
        Me.Cryo.Headerwidth = 60
        Me.Cryo.IsOnline = False
        Me.Cryo.Location = New System.Drawing.Point(658, 713)
        Me.Cryo.Name = "Cryo"
        Me.Cryo.Size = New System.Drawing.Size(100, 122)
        Me.Cryo.TabIndex = 165
        Me.Cryo.Text = "CRYO"
        Me.Cryo.Visible = False
        '
        'MGInformation
        '
        Me.MGInformation.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MGInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MGInformation.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MGInformation.HeaderHeight = 25
        Me.MGInformation.HeaderStatus = DisplayStatus.[On]
        Me.MGInformation.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.MGInformation.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.MGInformation.HeaderVisible = True
        Me.MGInformation.Headerwidth = 60
        Me.MGInformation.Location = New System.Drawing.Point(870, 244)
        Me.MGInformation.Name = "MGInformation"
        Me.MGInformation.Size = New System.Drawing.Size(82, 58)
        Me.MGInformation.TabIndex = 160
        Me.MGInformation.Text = "MG"
        '
        'ValveSupply1
        '
        Me.ValveSupply1.AccessibleName = "Supply Gas1"
        Me.ValveSupply1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupply1.IsCheckSafetyBeforeClick = False
        Me.ValveSupply1.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupply1.Location = New System.Drawing.Point(1235, 66)
        Me.ValveSupply1.Name = "ValveSupply1"
        Me.ValveSupply1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupply1.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupply1.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply1.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupply1.Size = New System.Drawing.Size(39, 33)
        Me.ValveSupply1.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupply1.TabIndex = 152
        Me.ValveSupply1.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupply1.TextLocIsFix = True
        Me.ValveSupply1.TextValue = ""
        Me.ValveSupply1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupply1.UnknownImage = Nothing
        Me.ValveSupply1.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply1.UseClickedEventInForm = True
        '
        'ValveShutOff1
        '
        Me.ValveShutOff1.AccessibleName = "Shutoff Gas1"
        Me.ValveShutOff1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutOff1.IsCheckSafetyBeforeClick = False
        Me.ValveShutOff1.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutOff1.Location = New System.Drawing.Point(917, 66)
        Me.ValveShutOff1.Name = "ValveShutOff1"
        Me.ValveShutOff1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutOff1.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutOff1.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff1.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutOff1.Size = New System.Drawing.Size(39, 33)
        Me.ValveShutOff1.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutOff1.TabIndex = 163
        Me.ValveShutOff1.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutOff1.TextLocIsFix = True
        Me.ValveShutOff1.TextValue = ""
        Me.ValveShutOff1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutOff1.UnknownImage = Nothing
        Me.ValveShutOff1.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff1.UseClickedEventInForm = True
        '
        'VatValveController
        '
        Me.VatValveController.BackColor = System.Drawing.Color.Transparent
        Me.VatValveController.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.VatValveController.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VatValveController.HeaderHeight = 32
        Me.VatValveController.HeaderStatus = DisplayStatus.Off
        Me.VatValveController.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.VatValveController.HeaderTextColor = System.Drawing.Color.White
        Me.VatValveController.HeaderVisible = True
        Me.VatValveController.Headerwidth = 60
        Me.VatValveController.IsOnline = False
        Me.VatValveController.Location = New System.Drawing.Point(608, 606)
        Me.VatValveController.Name = "VatValveController"
        Me.VatValveController.Size = New System.Drawing.Size(275, 134)
        Me.VatValveController.TabIndex = 149
        Me.VatValveController.Text = "Vat Valve Controller"
        '
        'ValveBaratron
        '
        Me.ValveBaratron.AccessibleName = "Baratron"
        Me.ValveBaratron.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveBaratron.IsCheckSafetyBeforeClick = False
        Me.ValveBaratron.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveBaratron.Location = New System.Drawing.Point(849, 346)
        Me.ValveBaratron.Name = "ValveBaratron"
        Me.ValveBaratron.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveBaratron.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveBaratron.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveBaratron.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveBaratron.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveBaratron.Size = New System.Drawing.Size(39, 33)
        Me.ValveBaratron.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveBaratron.TabIndex = 148
        Me.ValveBaratron.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveBaratron.TextLocIsFix = True
        Me.ValveBaratron.TextValue = ""
        Me.ValveBaratron.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveBaratron.UnknownImage = Nothing
        Me.ValveBaratron.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveBaratron.UseClickedEventInForm = True
        '
        'ValveSupply2
        '
        Me.ValveSupply2.AccessibleName = "Supply Gas1"
        Me.ValveSupply2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupply2.IsCheckSafetyBeforeClick = False
        Me.ValveSupply2.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupply2.Location = New System.Drawing.Point(1235, 100)
        Me.ValveSupply2.Name = "ValveSupply2"
        Me.ValveSupply2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupply2.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupply2.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply2.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupply2.Size = New System.Drawing.Size(39, 33)
        Me.ValveSupply2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupply2.TabIndex = 152
        Me.ValveSupply2.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupply2.TextLocIsFix = True
        Me.ValveSupply2.TextValue = ""
        Me.ValveSupply2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupply2.UnknownImage = Nothing
        Me.ValveSupply2.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply2.UseClickedEventInForm = True
        '
        'GasLine_VatValve
        '
        Me.GasLine_VatValve.Location = New System.Drawing.Point(621, 505)
        Me.GasLine_VatValve.Name = "GasLine_VatValve"
        Me.GasLine_VatValve.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLineCG2_Off
        Me.GasLine_VatValve.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_VatValve.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLineCG2
        Me.GasLine_VatValve.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_VatValve.Size = New System.Drawing.Size(10, 100)
        Me.GasLine_VatValve.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_VatValve.TabIndex = 154
        Me.GasLine_VatValve.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_VatValve.TextLocIsFix = True
        Me.GasLine_VatValve.TextValue = ""
        Me.GasLine_VatValve.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_VatValve.UnknownImage = Nothing
        Me.GasLine_VatValve.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'ValveShutOff3
        '
        Me.ValveShutOff3.AccessibleName = "Shutoff Gas3"
        Me.ValveShutOff3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutOff3.IsCheckSafetyBeforeClick = False
        Me.ValveShutOff3.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutOff3.Location = New System.Drawing.Point(917, 131)
        Me.ValveShutOff3.Name = "ValveShutOff3"
        Me.ValveShutOff3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutOff3.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutOff3.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff3.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutOff3.Size = New System.Drawing.Size(39, 33)
        Me.ValveShutOff3.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutOff3.TabIndex = 163
        Me.ValveShutOff3.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutOff3.TextLocIsFix = True
        Me.ValveShutOff3.TextValue = ""
        Me.ValveShutOff3.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutOff3.UnknownImage = Nothing
        Me.ValveShutOff3.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff3.UseClickedEventInForm = True
        '
        'ValveShutOff2
        '
        Me.ValveShutOff2.AccessibleName = "Shutoff Gas2"
        Me.ValveShutOff2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutOff2.IsCheckSafetyBeforeClick = False
        Me.ValveShutOff2.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutOff2.Location = New System.Drawing.Point(917, 100)
        Me.ValveShutOff2.Name = "ValveShutOff2"
        Me.ValveShutOff2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutOff2.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutOff2.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff2.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutOff2.Size = New System.Drawing.Size(39, 33)
        Me.ValveShutOff2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutOff2.TabIndex = 163
        Me.ValveShutOff2.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutOff2.TextLocIsFix = True
        Me.ValveShutOff2.TextValue = ""
        Me.ValveShutOff2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutOff2.UnknownImage = Nothing
        Me.ValveShutOff2.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutOff2.UseClickedEventInForm = True
        '
        'ValveSupply3
        '
        Me.ValveSupply3.AccessibleName = "Supply Gas1"
        Me.ValveSupply3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupply3.IsCheckSafetyBeforeClick = False
        Me.ValveSupply3.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupply3.Location = New System.Drawing.Point(1234, 131)
        Me.ValveSupply3.Name = "ValveSupply3"
        Me.ValveSupply3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupply3.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupply3.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply3.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupply3.Size = New System.Drawing.Size(40, 33)
        Me.ValveSupply3.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupply3.TabIndex = 152
        Me.ValveSupply3.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupply3.TextLocIsFix = True
        Me.ValveSupply3.TextValue = ""
        Me.ValveSupply3.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupply3.UnknownImage = Nothing
        Me.ValveSupply3.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply3.UseClickedEventInForm = True
        '
        'ValveSupply4
        '
        Me.ValveSupply4.AccessibleName = "Supply Gas1"
        Me.ValveSupply4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupply4.IsCheckSafetyBeforeClick = False
        Me.ValveSupply4.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupply4.Location = New System.Drawing.Point(917, 165)
        Me.ValveSupply4.Name = "ValveSupply4"
        Me.ValveSupply4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupply4.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupply4.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply4.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupply4.Size = New System.Drawing.Size(39, 33)
        Me.ValveSupply4.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupply4.TabIndex = 152
        Me.ValveSupply4.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupply4.TextLocIsFix = True
        Me.ValveSupply4.TextValue = ""
        Me.ValveSupply4.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupply4.UnknownImage = Nothing
        Me.ValveSupply4.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply4.UseClickedEventInForm = True
        '
        'ValveVent
        '
        Me.ValveVent.AccessibleName = "Vent"
        Me.ValveVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveVent.IsCheckSafetyBeforeClick = False
        Me.ValveVent.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveVent.Location = New System.Drawing.Point(777, 377)
        Me.ValveVent.Name = "ValveVent"
        Me.ValveVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveVent.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveVent.Size = New System.Drawing.Size(39, 33)
        Me.ValveVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveVent.TabIndex = 148
        Me.ValveVent.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveVent.TextLocIsFix = True
        Me.ValveVent.TextValue = ""
        Me.ValveVent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveVent.UnknownImage = Nothing
        Me.ValveVent.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveVent.UseClickedEventInForm = True
        '
        'GasLine_Turbo_Isolation
        '
        Me.GasLine_Turbo_Isolation.Location = New System.Drawing.Point(750, 480)
        Me.GasLine_Turbo_Isolation.Name = "GasLine_Turbo_Isolation"
        Me.GasLine_Turbo_Isolation.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_Isolation_Off
        Me.GasLine_Turbo_Isolation.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Turbo_Isolation.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline_Isolation
        Me.GasLine_Turbo_Isolation.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Turbo_Isolation.Size = New System.Drawing.Size(114, 32)
        Me.GasLine_Turbo_Isolation.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_Turbo_Isolation.TabIndex = 154
        Me.GasLine_Turbo_Isolation.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_Turbo_Isolation.TextLocIsFix = True
        Me.GasLine_Turbo_Isolation.TextValue = ""
        Me.GasLine_Turbo_Isolation.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_Turbo_Isolation.UnknownImage = Nothing
        Me.GasLine_Turbo_Isolation.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'ValveSupply5
        '
        Me.ValveSupply5.AccessibleName = "Supply Gas1"
        Me.ValveSupply5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupply5.IsCheckSafetyBeforeClick = False
        Me.ValveSupply5.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupply5.Location = New System.Drawing.Point(1234, 198)
        Me.ValveSupply5.Name = "ValveSupply5"
        Me.ValveSupply5.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupply5.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply5.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupply5.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply5.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupply5.Size = New System.Drawing.Size(39, 33)
        Me.ValveSupply5.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupply5.TabIndex = 152
        Me.ValveSupply5.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupply5.TextLocIsFix = True
        Me.ValveSupply5.TextValue = ""
        Me.ValveSupply5.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupply5.UnknownImage = Nothing
        Me.ValveSupply5.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupply5.UseClickedEventInForm = True
        '
        'RoughPump
        '
        Me.RoughPump.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RoughPump.IsCheckSafetyBeforeClick = False
        Me.RoughPump.IsCheckSafetyIsolationValveBeforeClick = False
        Me.RoughPump.Location = New System.Drawing.Point(478, 628)
        Me.RoughPump.Name = "RoughPump"
        Me.RoughPump.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Rough_Pump_Off
        Me.RoughPump.OffState_ColorText = System.Drawing.Color.Empty
        Me.RoughPump.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Rough_Pump_On
        Me.RoughPump.OnState_ColorText = System.Drawing.Color.Empty
        Me.RoughPump.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.RoughPump.Size = New System.Drawing.Size(125, 82)
        Me.RoughPump.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.RoughPump.TabIndex = 150
        Me.RoughPump.TextLocation = New System.Drawing.Point(0, 0)
        Me.RoughPump.TextLocIsFix = True
        Me.RoughPump.TextValue = ""
        Me.RoughPump.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.RoughPump.UnknownImage = Nothing
        Me.RoughPump.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.RoughPump.UseClickedEventInForm = True
        '
        'ProcessMonitor
        '
        Me.ProcessMonitor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ProcessMonitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ProcessMonitor.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProcessMonitor.HeaderHeight = 28
        Me.ProcessMonitor.HeaderStatus = DisplayStatus.[On]
        Me.ProcessMonitor.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.ProcessMonitor.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.ProcessMonitor.HeaderVisible = True
        Me.ProcessMonitor.Headerwidth = 60
        Me.ProcessMonitor.Location = New System.Drawing.Point(957, 446)
        Me.ProcessMonitor.Name = "ProcessMonitor"
        Me.ProcessMonitor.Size = New System.Drawing.Size(325, 184)
        Me.ProcessMonitor.TabIndex = 141
        Me.ProcessMonitor.Text = "Process Monitor"
        '
        'GasLine_ShutOff1
        '
        Me.GasLine_ShutOff1.Enabled = False
        Me.GasLine_ShutOff1.Location = New System.Drawing.Point(814, 78)
        Me.GasLine_ShutOff1.Name = "GasLine_ShutOff1"
        Me.GasLine_ShutOff1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply_Off
        Me.GasLine_ShutOff1.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_ShutOff1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply
        Me.GasLine_ShutOff1.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_ShutOff1.Size = New System.Drawing.Size(105, 10)
        Me.GasLine_ShutOff1.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_ShutOff1.TabIndex = 168
        Me.GasLine_ShutOff1.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_ShutOff1.TextLocIsFix = True
        Me.GasLine_ShutOff1.TextValue = ""
        Me.GasLine_ShutOff1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_ShutOff1.UnknownImage = Nothing
        Me.GasLine_ShutOff1.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'GasLine_ShutOff3
        '
        Me.GasLine_ShutOff3.Enabled = False
        Me.GasLine_ShutOff3.Location = New System.Drawing.Point(814, 144)
        Me.GasLine_ShutOff3.Name = "GasLine_ShutOff3"
        Me.GasLine_ShutOff3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply_Off
        Me.GasLine_ShutOff3.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_ShutOff3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply
        Me.GasLine_ShutOff3.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_ShutOff3.Size = New System.Drawing.Size(104, 10)
        Me.GasLine_ShutOff3.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_ShutOff3.TabIndex = 169
        Me.GasLine_ShutOff3.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_ShutOff3.TextLocIsFix = True
        Me.GasLine_ShutOff3.TextValue = ""
        Me.GasLine_ShutOff3.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_ShutOff3.UnknownImage = Nothing
        Me.GasLine_ShutOff3.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'GasLine_ShutOff4
        '
        Me.GasLine_ShutOff4.Enabled = False
        Me.GasLine_ShutOff4.Location = New System.Drawing.Point(329, 297)
        Me.GasLine_ShutOff4.Name = "GasLine_ShutOff4"
        Me.GasLine_ShutOff4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_Flowcool_ShutOff_Off
        Me.GasLine_ShutOff4.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_ShutOff4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_Flowcool_ShutOff_On
        Me.GasLine_ShutOff4.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_ShutOff4.Size = New System.Drawing.Size(70, 9)
        Me.GasLine_ShutOff4.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_ShutOff4.TabIndex = 168
        Me.GasLine_ShutOff4.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_ShutOff4.TextLocIsFix = True
        Me.GasLine_ShutOff4.TextValue = ""
        Me.GasLine_ShutOff4.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_ShutOff4.UnknownImage = Nothing
        Me.GasLine_ShutOff4.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'GasLine_ShutOff2
        '
        Me.GasLine_ShutOff2.Enabled = False
        Me.GasLine_ShutOff2.Location = New System.Drawing.Point(814, 111)
        Me.GasLine_ShutOff2.Name = "GasLine_ShutOff2"
        Me.GasLine_ShutOff2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply_Off
        Me.GasLine_ShutOff2.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_ShutOff2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply
        Me.GasLine_ShutOff2.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_ShutOff2.Size = New System.Drawing.Size(103, 10)
        Me.GasLine_ShutOff2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_ShutOff2.TabIndex = 168
        Me.GasLine_ShutOff2.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_ShutOff2.TextLocIsFix = True
        Me.GasLine_ShutOff2.TextValue = ""
        Me.GasLine_ShutOff2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_ShutOff2.UnknownImage = Nothing
        Me.GasLine_ShutOff2.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'GasLine_Supply1
        '
        Me.GasLine_Supply1.Enabled = False
        Me.GasLine_Supply1.Location = New System.Drawing.Point(957, 78)
        Me.GasLine_Supply1.Name = "GasLine_Supply1"
        Me.GasLine_Supply1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply_Off
        Me.GasLine_Supply1.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Supply1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline2_Supply
        Me.GasLine_Supply1.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Supply1.Size = New System.Drawing.Size(278, 16)
        Me.GasLine_Supply1.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_Supply1.TabIndex = 168
        Me.GasLine_Supply1.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_Supply1.TextLocIsFix = True
        Me.GasLine_Supply1.TextValue = ""
        Me.GasLine_Supply1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_Supply1.UnknownImage = Nothing
        Me.GasLine_Supply1.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'GasLine_Supply2
        '
        Me.GasLine_Supply2.Enabled = False
        Me.GasLine_Supply2.Location = New System.Drawing.Point(957, 110)
        Me.GasLine_Supply2.Name = "GasLine_Supply2"
        Me.GasLine_Supply2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply_Off
        Me.GasLine_Supply2.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Supply2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline2_Supply
        Me.GasLine_Supply2.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Supply2.Size = New System.Drawing.Size(278, 15)
        Me.GasLine_Supply2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_Supply2.TabIndex = 168
        Me.GasLine_Supply2.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_Supply2.TextLocIsFix = True
        Me.GasLine_Supply2.TextValue = ""
        Me.GasLine_Supply2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_Supply2.UnknownImage = Nothing
        Me.GasLine_Supply2.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'GasLine_Supply3
        '
        Me.GasLine_Supply3.Enabled = False
        Me.GasLine_Supply3.Location = New System.Drawing.Point(957, 144)
        Me.GasLine_Supply3.Name = "GasLine_Supply3"
        Me.GasLine_Supply3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply_Off
        Me.GasLine_Supply3.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Supply3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline2_Supply
        Me.GasLine_Supply3.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Supply3.Size = New System.Drawing.Size(278, 15)
        Me.GasLine_Supply3.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_Supply3.TabIndex = 168
        Me.GasLine_Supply3.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_Supply3.TextLocIsFix = True
        Me.GasLine_Supply3.TextValue = ""
        Me.GasLine_Supply3.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_Supply3.UnknownImage = Nothing
        Me.GasLine_Supply3.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'GasLine_Supply5
        '
        Me.GasLine_Supply5.Enabled = False
        Me.GasLine_Supply5.Location = New System.Drawing.Point(957, 210)
        Me.GasLine_Supply5.Name = "GasLine_Supply5"
        Me.GasLine_Supply5.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply_Off
        Me.GasLine_Supply5.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Supply5.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline2_Supply
        Me.GasLine_Supply5.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Supply5.Size = New System.Drawing.Size(278, 13)
        Me.GasLine_Supply5.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_Supply5.TabIndex = 168
        Me.GasLine_Supply5.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_Supply5.TextLocIsFix = True
        Me.GasLine_Supply5.TextValue = ""
        Me.GasLine_Supply5.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_Supply5.UnknownImage = Nothing
        Me.GasLine_Supply5.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'GasLine_Supply4
        '
        Me.GasLine_Supply4.Enabled = False
        Me.GasLine_Supply4.Location = New System.Drawing.Point(616, 163)
        Me.GasLine_Supply4.Name = "GasLine_Supply4"
        Me.GasLine_Supply4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_Flowcool_Off
        Me.GasLine_Supply4.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Supply4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_Flowcool_On
        Me.GasLine_Supply4.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Supply4.Size = New System.Drawing.Size(301, 143)
        Me.GasLine_Supply4.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_Supply4.TabIndex = 170
        Me.GasLine_Supply4.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_Supply4.TextLocIsFix = True
        Me.GasLine_Supply4.TextValue = ""
        Me.GasLine_Supply4.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_Supply4.UnknownImage = Nothing
        Me.GasLine_Supply4.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'GasLine_Total
        '
        Me.GasLine_Total.Enabled = False
        Me.GasLine_Total.Location = New System.Drawing.Point(588, 79)
        Me.GasLine_Total.Name = "GasLine_Total"
        Me.GasLine_Total.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_withoutMainGas
        Me.GasLine_Total.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Total.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_withoutMainGasOn
        Me.GasLine_Total.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Total.Size = New System.Drawing.Size(237, 144)
        Me.GasLine_Total.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_Total.TabIndex = 168
        Me.GasLine_Total.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_Total.TextLocIsFix = True
        Me.GasLine_Total.TextValue = ""
        Me.GasLine_Total.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_Total.UnknownImage = Nothing
        Me.GasLine_Total.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'lblDisconnect
        '
        Me.lblDisconnect.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblDisconnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDisconnect.Font = New System.Drawing.Font("Times New Roman", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisconnect.ForeColor = System.Drawing.Color.Red
        Me.lblDisconnect.Location = New System.Drawing.Point(425, 460)
        Me.lblDisconnect.Name = "lblDisconnect"
        Me.lblDisconnect.Size = New System.Drawing.Size(449, 119)
        Me.lblDisconnect.TabIndex = 179
        Me.lblDisconnect.Text = "DISCONNECTED"
        Me.lblDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDisconnect.Visible = False
        '
        'btnWPCryo
        '
        Me.btnWPCryo.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnWPCryo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWPCryo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWPCryo.FlatAppearance.BorderSize = 0
        Me.btnWPCryo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWPCryo.Location = New System.Drawing.Point(650, 498)
        Me.btnWPCryo.Name = "btnWPCryo"
        Me.btnWPCryo.Size = New System.Drawing.Size(30, 28)
        Me.btnWPCryo.TabIndex = 180
        Me.btnWPCryo.UseVisualStyleBackColor = True
        Me.btnWPCryo.Visible = False
        '
        'cmsWPCryo
        '
        Me.cmsWPCryo.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsWPCryo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMachineCryoOn, Me.mnuMachineCryoRegen, Me.mnuMachineFastRegen})
        Me.cmsWPCryo.Name = "cmsWPCryo"
        Me.cmsWPCryo.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsWPCryo.ShowImageMargin = False
        Me.cmsWPCryo.Size = New System.Drawing.Size(185, 106)
        '
        'mnuMachineFastRegen
        '
        Me.mnuMachineFastRegen.Name = "mnuMachineFastRegen"
        Me.mnuMachineFastRegen.Size = New System.Drawing.Size(184, 34)
        Me.mnuMachineFastRegen.Text = "Fast Regen"
        '
        'GasLine_ShutOff5
        '
        Me.GasLine_ShutOff5.Enabled = False
        Me.GasLine_ShutOff5.Location = New System.Drawing.Point(813, 208)
        Me.GasLine_ShutOff5.Name = "GasLine_ShutOff5"
        Me.GasLine_ShutOff5.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply_Off
        Me.GasLine_ShutOff5.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_ShutOff5.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Gasline1_Supply
        Me.GasLine_ShutOff5.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_ShutOff5.Size = New System.Drawing.Size(104, 10)
        Me.GasLine_ShutOff5.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_ShutOff5.TabIndex = 170
        Me.GasLine_ShutOff5.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_ShutOff5.TextLocIsFix = True
        Me.GasLine_ShutOff5.TextValue = ""
        Me.GasLine_ShutOff5.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_ShutOff5.UnknownImage = Nothing
        Me.GasLine_ShutOff5.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'TarControl
        '
        Me.TarControl.BackColor = System.Drawing.Color.Transparent
        Me.TarControl.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tar
        Me.TarControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TarControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TarControl.HeaderHeight = 25
        Me.TarControl.HeaderStatus = DisplayStatus.Off
        Me.TarControl.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.TarControl.HeaderTextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TarControl.HeaderVisible = False
        Me.TarControl.Headerwidth = 60
        Me.TarControl.IsOnline = False
        Me.TarControl.Location = New System.Drawing.Point(414, 136)
        Me.TarControl.Name = "TarControl"
        Me.TarControl.Size = New System.Drawing.Size(183, 58)
        Me.TarControl.TabIndex = 182
        Me.TarControl.TargetInstalled = True
        Me.TarControl.Text = "PvdTarControl1"
        '
        'btnOverrideMode
        '
        Me.btnOverrideMode.AccessibleName = "OverrideMode"
        Me.btnOverrideMode.BackColor = System.Drawing.Color.Transparent
        Me.btnOverrideMode.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnOverrideMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOverrideMode.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnOverrideMode.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOverrideMode.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnOverrideMode.ColorText_UnknowStatus = System.Drawing.Color.White
        Me.btnOverrideMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOverrideMode.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnOverrideMode.ErrorText = ""
        Me.btnOverrideMode.FlatAppearance.BorderSize = 0
        Me.btnOverrideMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOverrideMode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOverrideMode.ForeColor = System.Drawing.Color.Black
        Me.btnOverrideMode.Location = New System.Drawing.Point(957, 713)
        Me.btnOverrideMode.Name = "btnOverrideMode"
        Me.btnOverrideMode.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnOverrideMode.OffText = ""
        Me.btnOverrideMode.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnOverrideMode.OnText = ""
        Me.btnOverrideMode.Size = New System.Drawing.Size(133, 25)
        Me.btnOverrideMode.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnOverrideMode.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.btnOverrideMode.TabIndex = 183
        Me.btnOverrideMode.Text = "Override Mode"
        Me.btnOverrideMode.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnOverrideMode.UnKnownText = ""
        Me.btnOverrideMode.UseVisualStyleBackColor = False
        '
        'GasLine_Water
        '
        Me.GasLine_Water.Enabled = False
        Me.GasLine_Water.Location = New System.Drawing.Point(617, 330)
        Me.GasLine_Water.Name = "GasLine_Water"
        Me.GasLine_Water.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_Vent_Off
        Me.GasLine_Water.OffState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Water.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_Vent
        Me.GasLine_Water.OnState_ColorText = System.Drawing.Color.Empty
        Me.GasLine_Water.Size = New System.Drawing.Size(126, 10)
        Me.GasLine_Water.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.GasLine_Water.TabIndex = 184
        Me.GasLine_Water.TextLocation = New System.Drawing.Point(0, 0)
        Me.GasLine_Water.TextLocIsFix = True
        Me.GasLine_Water.TextValue = ""
        Me.GasLine_Water.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.GasLine_Water.UnknownImage = Nothing
        Me.GasLine_Water.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'ValveWater
        '
        Me.ValveWater.AccessibleName = "Baratron"
        Me.ValveWater.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveWater.IsCheckSafetyBeforeClick = False
        Me.ValveWater.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveWater.Location = New System.Drawing.Point(743, 319)
        Me.ValveWater.Name = "ValveWater"
        Me.ValveWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveWater.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveWater.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveWater.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveWater.Size = New System.Drawing.Size(46, 33)
        Me.ValveWater.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveWater.TabIndex = 185
        Me.ValveWater.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveWater.TextLocIsFix = True
        Me.ValveWater.TextValue = ""
        Me.ValveWater.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveWater.UnknownImage = Nothing
        Me.ValveWater.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveWater.UseClickedEventInForm = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(783, 324)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 19)
        Me.Label5.TabIndex = 156
        Me.Label5.Text = "Water"
        '
        'lblRoughPumpInUse
        '
        Me.lblRoughPumpInUse.BackColor = System.Drawing.Color.Transparent
        Me.lblRoughPumpInUse.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoughPumpInUse.ForeColor = System.Drawing.Color.White
        Me.lblRoughPumpInUse.Location = New System.Drawing.Point(223, 722)
        Me.lblRoughPumpInUse.Name = "lblRoughPumpInUse"
        Me.lblRoughPumpInUse.Size = New System.Drawing.Size(373, 36)
        Me.lblRoughPumpInUse.TabIndex = 186
        Me.lblRoughPumpInUse.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ValveMainGas
        '
        Me.ValveMainGas.AccessibleName = "MainGas"
        Me.ValveMainGas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveMainGas.IsCheckSafetyBeforeClick = False
        Me.ValveMainGas.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveMainGas.Location = New System.Drawing.Point(641, 150)
        Me.ValveMainGas.Name = "ValveMainGas"
        Me.ValveMainGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveMainGas.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveMainGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveMainGas.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveMainGas.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveMainGas.Size = New System.Drawing.Size(39, 33)
        Me.ValveMainGas.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveMainGas.TabIndex = 187
        Me.ValveMainGas.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveMainGas.TextLocIsFix = True
        Me.ValveMainGas.TextValue = ""
        Me.ValveMainGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveMainGas.UnknownImage = Nothing
        Me.ValveMainGas.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveMainGas.UseClickedEventInForm = True
        '
        'lblMainGas
        '
        Me.lblMainGas.AutoSize = True
        Me.lblMainGas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMainGas.ForeColor = System.Drawing.Color.White
        Me.lblMainGas.Location = New System.Drawing.Point(701, 178)
        Me.lblMainGas.Name = "lblMainGas"
        Me.lblMainGas.Size = New System.Drawing.Size(76, 19)
        Me.lblMainGas.TabIndex = 156
        Me.lblMainGas.Text = "Main Gas"
        '
        'lblNameOfSequenceRunning
        '
        Me.lblNameOfSequenceRunning.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblNameOfSequenceRunning.ForeColor = System.Drawing.Color.Red
        Me.lblNameOfSequenceRunning.Location = New System.Drawing.Point(330, 95)
        Me.lblNameOfSequenceRunning.Name = "lblNameOfSequenceRunning"
        Me.lblNameOfSequenceRunning.Size = New System.Drawing.Size(266, 33)
        Me.lblNameOfSequenceRunning.TabIndex = 244
        '
        'lblCurrentPurgeCycle
        '
        Me.lblCurrentPurgeCycle.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblCurrentPurgeCycle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCurrentPurgeCycle.Location = New System.Drawing.Point(618, 95)
        Me.lblCurrentPurgeCycle.Name = "lblCurrentPurgeCycle"
        Me.lblCurrentPurgeCycle.Size = New System.Drawing.Size(171, 33)
        Me.lblCurrentPurgeCycle.TabIndex = 244
        '
        'PVDPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.lblCurrentPurgeCycle)
        Me.Controls.Add(Me.lblNameOfSequenceRunning)
        Me.Controls.Add(Me.ValveMainGas)
        Me.Controls.Add(Me.lblDisconnect)
        Me.Controls.Add(Me.ValveWater)
        Me.Controls.Add(Me.GasLine_Water)
        Me.Controls.Add(Me.btnOverrideMode)
        Me.Controls.Add(Me.TarControl)
        Me.Controls.Add(Me.btnWPCryo)
        Me.Controls.Add(Me.ValveSupply4)
        Me.Controls.Add(Me.ValveSupply5)
        Me.Controls.Add(Me.ValveSupply3)
        Me.Controls.Add(Me.ValveSupply2)
        Me.Controls.Add(Me.ValveSupply1)
        Me.Controls.Add(Me.GasLine_Total)
        Me.Controls.Add(Me.ChamberInterlock)
        Me.Controls.Add(Me.GasController)
        Me.Controls.Add(Me.GasLine_ShutOff3)
        Me.Controls.Add(Me.ParallelMagnet)
        Me.Controls.Add(Me.GasLine_Vent)
        Me.Controls.Add(Me.GasLine_Baratron)
        Me.Controls.Add(Me.Baratron)
        Me.Controls.Add(Me.btnPVDTooltipMachine)
        Me.Controls.Add(Me.txtForeLineCG)
        Me.Controls.Add(Me.txtRoughLineCG)
        Me.Controls.Add(Me.ValveTurbo_Isolation)
        Me.Controls.Add(Me.TurboPump)
        Me.Controls.Add(Me.ValveShutOff4)
        Me.Controls.Add(Me.CGInformation)
        Me.Controls.Add(Me.ValveShutOff5)
        Me.Controls.Add(Me.ValveRough)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnHivacValve)
        Me.Controls.Add(Me.GasLine_RoughPump)
        Me.Controls.Add(Me.Cryo)
        Me.Controls.Add(Me.MGInformation)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblMainGas)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ValveShutOff1)
        Me.Controls.Add(Me.VatValveController)
        Me.Controls.Add(Me.ValveBaratron)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GasLine_VatValve)
        Me.Controls.Add(Me.ValveShutOff3)
        Me.Controls.Add(Me.ValveShutOff2)
        Me.Controls.Add(Me.ValveVent)
        Me.Controls.Add(Me.GasLine_Turbo_Isolation)
        Me.Controls.Add(Me.RoughPump)
        Me.Controls.Add(Me.GasLine_Supply5)
        Me.Controls.Add(Me.GasLine_Supply3)
        Me.Controls.Add(Me.GasLine_ShutOff1)
        Me.Controls.Add(Me.GasLine_ShutOff5)
        Me.Controls.Add(Me.GasLine_Supply4)
        Me.Controls.Add(Me.GasLine_ShutOff2)
        Me.Controls.Add(Me.ChuckControl)
        Me.Controls.Add(Me.ProcessMonitor)
        Me.Controls.Add(Me.BiasPowerSupply)
        Me.Controls.Add(Me.GasLine_Supply2)
        Me.Controls.Add(Me.GasLine_Supply1)
        Me.Controls.Add(Me.lblRoughPumpInUse)
        Me.Controls.Add(Me.GasLine_ShutOff4)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "PVDPanel"
        Me.StatusTextLocation = New System.Drawing.Point(22, 770)
        Me.Controls.SetChildIndex(Me.GasLine_ShutOff4, 0)
        Me.Controls.SetChildIndex(Me.lblRoughPumpInUse, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Supply1, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Supply2, 0)
        Me.Controls.SetChildIndex(Me.BiasPowerSupply, 0)
        Me.Controls.SetChildIndex(Me.ProcessMonitor, 0)
        Me.Controls.SetChildIndex(Me.ChuckControl, 0)
        Me.Controls.SetChildIndex(Me.GasLine_ShutOff2, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Supply4, 0)
        Me.Controls.SetChildIndex(Me.GasLine_ShutOff5, 0)
        Me.Controls.SetChildIndex(Me.GasLine_ShutOff1, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Supply3, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Supply5, 0)
        Me.Controls.SetChildIndex(Me.RoughPump, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Turbo_Isolation, 0)
        Me.Controls.SetChildIndex(Me.ValveVent, 0)
        Me.Controls.SetChildIndex(Me.ValveShutOff2, 0)
        Me.Controls.SetChildIndex(Me.ValveShutOff3, 0)
        Me.Controls.SetChildIndex(Me.GasLine_VatValve, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.ValveBaratron, 0)
        Me.Controls.SetChildIndex(Me.VatValveController, 0)
        Me.Controls.SetChildIndex(Me.ValveShutOff1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblMainGas, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.MGInformation, 0)
        Me.Controls.SetChildIndex(Me.Cryo, 0)
        Me.Controls.SetChildIndex(Me.GasLine_RoughPump, 0)
        Me.Controls.SetChildIndex(Me.btnHivacValve, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ValveRough, 0)
        Me.Controls.SetChildIndex(Me.ValveShutOff5, 0)
        Me.Controls.SetChildIndex(Me.CGInformation, 0)
        Me.Controls.SetChildIndex(Me.ValveShutOff4, 0)
        Me.Controls.SetChildIndex(Me.TurboPump, 0)
        Me.Controls.SetChildIndex(Me.ValveTurbo_Isolation, 0)
        Me.Controls.SetChildIndex(Me.txtRoughLineCG, 0)
        Me.Controls.SetChildIndex(Me.txtForeLineCG, 0)
        Me.Controls.SetChildIndex(Me.btnPVDTooltipMachine, 0)
        Me.Controls.SetChildIndex(Me.Baratron, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Baratron, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Vent, 0)
        Me.Controls.SetChildIndex(Me.ParallelMagnet, 0)
        Me.Controls.SetChildIndex(Me.GasLine_ShutOff3, 0)
        Me.Controls.SetChildIndex(Me.GasController, 0)
        Me.Controls.SetChildIndex(Me.ChamberInterlock, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Total, 0)
        Me.Controls.SetChildIndex(Me.ValveSupply1, 0)
        Me.Controls.SetChildIndex(Me.ValveSupply2, 0)
        Me.Controls.SetChildIndex(Me.ValveSupply3, 0)
        Me.Controls.SetChildIndex(Me.ValveSupply5, 0)
        Me.Controls.SetChildIndex(Me.ValveSupply4, 0)
        Me.Controls.SetChildIndex(Me.btnWPCryo, 0)
        Me.Controls.SetChildIndex(Me.TarControl, 0)
        Me.Controls.SetChildIndex(Me.btnOverrideMode, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Water, 0)
        Me.Controls.SetChildIndex(Me.ValveWater, 0)
        Me.Controls.SetChildIndex(Me.lblDisconnect, 0)
        Me.Controls.SetChildIndex(Me.ValveMainGas, 0)
        Me.Controls.SetChildIndex(Me.lblNameOfSequenceRunning, 0)
        Me.Controls.SetChildIndex(Me.lblCurrentPurgeCycle, 0)
        Me.cmsWPCryo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageBinaryStatusControl1 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents mnuMachineCryoOn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMachineCryoRegen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMachineShutDownPower As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChuckControl As AVP_Robot_Project.ChuckControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MGInformation As AVP_Robot_Project.PVDCGControl
    Friend WithEvents CGInformation As AVP_Robot_Project.PVDCGControl
    Friend WithEvents GasLine_ShutOff1 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents TurboPump As AVP_Robot_Project.PVDTurboPump
    Friend WithEvents ValveShutOff4 As AVP_Robot_Project.ValveControl
    Friend WithEvents Cryo As AVP_Robot_Project.PVDCryoControl
    Friend WithEvents GasLine_ShutOff2 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ValveShutOff5 As AVP_Robot_Project.ValveControl
    Friend WithEvents GasLine_RoughPump As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ValveRough As AVP_Robot_Project.ValveControl
    Friend WithEvents btnHivacValve As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents GasLine_Vent As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents GasLine_Baratron As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ValveSupply1 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveShutOff1 As AVP_Robot_Project.ValveControl
    Friend WithEvents VatValveController As AVP_Robot_Project.VatValveController
    Friend WithEvents ValveBaratron As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveSupply2 As AVP_Robot_Project.ValveControl
    Friend WithEvents GasLine_VatValve As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ValveShutOff3 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveShutOff2 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveSupply3 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveSupply4 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveVent As AVP_Robot_Project.ValveControl
    Friend WithEvents Baratron As AVP_Robot_Project.PVDBACenterControl
    Friend WithEvents ValveSupply5 As AVP_Robot_Project.ValveControl
    Friend WithEvents RoughPump As AVP_Robot_Project.ValveControl
    Friend WithEvents ParallelMagnet As AVP_Robot_Project.ParallelMagnet
    Friend WithEvents BiasPowerSupply As AVP_Robot_Project.BiasPowerSupply
    Friend WithEvents ProcessMonitor As AVP_Robot_Project.PVDProcessMonitor
    Friend WithEvents ChamberInterlock As AVP_Robot_Project.PVDChamberInterlock
    Friend WithEvents GasLine_ShutOff3 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents GasLine_Supply4 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents GasController As AVP_Robot_Project.PVDGasController
    Friend WithEvents GasLine_Turbo_Isolation As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ValveTurbo_Isolation As AVP_Robot_Project.ValveControl
    Friend WithEvents txtRoughLineCG As SL_Textbox
    Friend WithEvents txtForeLineCG As SL_Textbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPVDTooltipMachine As System.Windows.Forms.Button
    Friend WithEvents GasLine_Supply1 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents GasLine_Supply2 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents GasLine_Supply3 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents GasLine_Supply5 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents GasLine_ShutOff4 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents GasLine_Total As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents lblDisconnect As System.Windows.Forms.Label
    Friend WithEvents btnWPCryo As System.Windows.Forms.Button
    Friend WithEvents cmsWPCryo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TarControl As AVP_Robot_Project.PVDTarControl
    Friend WithEvents btnOverrideMode As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents GasLine_Water As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ValveWater As AVP_Robot_Project.ValveControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents mnuMachineFastRegen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRoughPumpInUse As System.Windows.Forms.Label
    Friend WithEvents ValveMainGas As AVP_Robot_Project.ValveControl
    Friend WithEvents lblMainGas As System.Windows.Forms.Label
    Friend WithEvents lblNameOfSequenceRunning As System.Windows.Forms.Label
    Friend WithEvents GasLine_ShutOff5 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents lblCurrentPurgeCycle As System.Windows.Forms.Label

End Class
