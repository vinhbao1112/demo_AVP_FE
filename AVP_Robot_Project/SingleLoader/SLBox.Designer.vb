<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SLBox
    Inherits AVP_Robot_Project.PVDStatusBoard

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
        Me.txtWaterPump = New AVP_Robot_Project.SL_Textbox
        Me.btnWaterPumpOn = New AVP_Robot_Project.SL_CustomButton
        Me.btnMesaValve = New AVP_Robot_Project.SL_CustomButton
        Me.txtT2 = New AVP_Robot_Project.SL_Textbox
        Me.lblT2 = New System.Windows.Forms.Label
        Me.btnCryoOn = New AVP_Robot_Project.SL_CustomButton
        Me.btnCryoStatus = New AVP_Robot_Project.SL_CustomButton
        Me.ValveTurboHivac = New AVP_Robot_Project.SL_ValveControl
        Me.ValveCryoHivac = New AVP_Robot_Project.SL_ValveControl
        Me.Shutter = New AVP_Robot_Project.SL_ValveControl
        Me.btnGeneral = New System.Windows.Forms.Button
        Me.SourcePlasma = New AVP_Robot_Project.SL_ValveControl
        Me.Wafer = New AVP_Robot_Project.IBE_WaferInside
        Me.lblT1 = New System.Windows.Forms.Label
        Me.txtT1 = New AVP_Robot_Project.SL_Textbox
        Me.lblTiltAtAngleSensor = New AVP_Robot_Project.AVPLabel
        Me.btnTiltSensor = New AVP_Robot_Project.SL_CustomButton
        Me.lblOff = New AVP_Robot_Project.AVPLabel
        Me.lblOn = New AVP_Robot_Project.AVPLabel
        Me.lblInternalShutter = New AVP_Robot_Project.AVPLabel
        Me.stInternalShutterOff = New AVP_Robot_Project.SL_CustomButton
        Me.stInternalShutter = New AVP_Robot_Project.SL_CustomButton
        Me.RotationFixture = New AVPControls.AVPFixtureControl
        Me.picBoxPlasma = New AVPControls.AnimationControl
        Me.ShutterControl = New AVPControls.AVPShutterControl
        Me.txtRampingPercent = New AVP_Robot_Project.AVPLabel
        CType(Me.RotationFixture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxPlasma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShutterControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.FlatAppearance.BorderSize = 0
        '
        'txtWaterPump
        '
        Me.txtWaterPump.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtWaterPump.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtWaterPump.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtWaterPump.IsNumericTextbox = True
        Me.txtWaterPump.IsReadBack = True
        Me.txtWaterPump.Location = New System.Drawing.Point(228, 67)
        Me.txtWaterPump.Name = "txtWaterPump"
        Me.txtWaterPump.ReadOnly = True
        Me.txtWaterPump.ShowUnitFormat = True
        Me.txtWaterPump.Size = New System.Drawing.Size(67, 24)
        Me.txtWaterPump.TabIndex = 199
        Me.txtWaterPump.TabStop = False
        Me.txtWaterPump.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtWaterPump.UnitTypeUsed = "K"
        '
        'btnWaterPumpOn
        '
        Me.btnWaterPumpOn.AccessibleName = "OverrideMode"
        Me.btnWaterPumpOn.BackColor = System.Drawing.Color.Transparent
        Me.btnWaterPumpOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnWaterPumpOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWaterPumpOn.Clickable = True
        Me.btnWaterPumpOn.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnWaterPumpOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWaterPumpOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnWaterPumpOn.ErrorText = "Error"
        Me.btnWaterPumpOn.FlatAppearance.BorderSize = 0
        Me.btnWaterPumpOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWaterPumpOn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWaterPumpOn.ForeColor = System.Drawing.Color.Black
        Me.btnWaterPumpOn.Location = New System.Drawing.Point(99, 29)
        Me.btnWaterPumpOn.LogSource = "Turbo"
        Me.btnWaterPumpOn.MessageBoxText = Nothing
        Me.btnWaterPumpOn.Name = "btnWaterPumpOn"
        Me.btnWaterPumpOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnWaterPumpOn.OffText = "Off"
        Me.btnWaterPumpOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnWaterPumpOn.OnText = "On"
        Me.btnWaterPumpOn.Size = New System.Drawing.Size(67, 25)
        Me.btnWaterPumpOn.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnWaterPumpOn.TabIndex = 196
        Me.btnWaterPumpOn.Text = "Off"
        Me.btnWaterPumpOn.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnWaterPumpOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnWaterPumpOn.UnKnownText = "Ramp"
        Me.btnWaterPumpOn.UseClickedEventInForm = True
        Me.btnWaterPumpOn.UseVisualStyleBackColor = False
        Me.btnWaterPumpOn.ValueToBeSend = ""
        '
        'btnMesaValve
        '
        Me.btnMesaValve.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_SplitValve_Blue
        Me.btnMesaValve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMesaValve.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMesaValve.Enabled = False
        Me.btnMesaValve.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_SplitValve_Red
        Me.btnMesaValve.FlatAppearance.BorderSize = 0
        Me.btnMesaValve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMesaValve.ForeColor = System.Drawing.Color.White
        Me.btnMesaValve.Location = New System.Drawing.Point(8, 241)
        Me.btnMesaValve.MessageBoxText = Nothing
        Me.btnMesaValve.Name = "btnMesaValve"
        Me.btnMesaValve.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_SplitValve_Blue
        Me.btnMesaValve.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_SplitValve_Green
        Me.btnMesaValve.Size = New System.Drawing.Size(73, 55)
        Me.btnMesaValve.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnMesaValve.TabIndex = 202
        Me.btnMesaValve.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnMesaValve.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_SplitValve_Yellow
        Me.btnMesaValve.UseVisualStyleBackColor = True
        Me.btnMesaValve.ValueToBeSend = ""
        '
        'txtT2
        '
        Me.txtT2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtT2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtT2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtT2.IsNumericTextbox = True
        Me.txtT2.IsReadBack = True
        Me.txtT2.Location = New System.Drawing.Point(205, 538)
        Me.txtT2.Name = "txtT2"
        Me.txtT2.ReadOnly = True
        Me.txtT2.ShowUnitFormat = True
        Me.txtT2.Size = New System.Drawing.Size(67, 24)
        Me.txtT2.TabIndex = 199
        Me.txtT2.TabStop = False
        Me.txtT2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtT2.UnitTypeUsed = "K"
        Me.txtT2.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'lblT2
        '
        Me.lblT2.AutoSize = True
        Me.lblT2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT2.Location = New System.Drawing.Point(224, 516)
        Me.lblT2.Name = "lblT2"
        Me.lblT2.Size = New System.Drawing.Size(27, 19)
        Me.lblT2.TabIndex = 201
        Me.lblT2.Text = "T2"
        '
        'btnCryoOn
        '
        Me.btnCryoOn.AccessibleName = "OverrideMode"
        Me.btnCryoOn.BackColor = System.Drawing.Color.Transparent
        Me.btnCryoOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnCryoOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnCryoOn.ErrorText = "Error"
        Me.btnCryoOn.FlatAppearance.BorderSize = 0
        Me.btnCryoOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoOn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCryoOn.ForeColor = System.Drawing.Color.White
        Me.btnCryoOn.Location = New System.Drawing.Point(205, 564)
        Me.btnCryoOn.LogSource = "Cryo"
        Me.btnCryoOn.MessageBoxText = Nothing
        Me.btnCryoOn.Name = "btnCryoOn"
        Me.btnCryoOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnCryoOn.OffText = "Off"
        Me.btnCryoOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnCryoOn.OnText = "On"
        Me.btnCryoOn.Size = New System.Drawing.Size(64, 26)
        Me.btnCryoOn.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnCryoOn.TabIndex = 196
        Me.btnCryoOn.Text = "Off"
        Me.btnCryoOn.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnCryoOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnCryoOn.UnKnownText = "Reg"
        Me.btnCryoOn.UseVisualStyleBackColor = False
        Me.btnCryoOn.ValueToBeSend = ""
        '
        'btnCryoStatus
        '
        Me.btnCryoStatus.AccessibleName = "OverrideMode"
        Me.btnCryoStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnCryoStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.HeaderPanel_Off
        Me.btnCryoStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoStatus.Clickable = True
        Me.btnCryoStatus.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnCryoStatus.ColorText_UnknowStatus = System.Drawing.Color.White
        Me.btnCryoStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.HeaderPanel_Off
        Me.btnCryoStatus.FlatAppearance.BorderSize = 0
        Me.btnCryoStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCryoStatus.ForeColor = System.Drawing.Color.White
        Me.btnCryoStatus.Location = New System.Drawing.Point(275, 509)
        Me.btnCryoStatus.MessageBoxText = Nothing
        Me.btnCryoStatus.Name = "btnCryoStatus"
        Me.btnCryoStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.HeaderPanel_Off
        Me.btnCryoStatus.OffText = "Cryo"
        Me.btnCryoStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.HeaderPanel
        Me.btnCryoStatus.OnText = "Cryo"
        Me.btnCryoStatus.Size = New System.Drawing.Size(23, 86)
        Me.btnCryoStatus.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnCryoStatus.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Vertical
        Me.btnCryoStatus.TabIndex = 196
        Me.btnCryoStatus.Text = "Cryo"
        Me.btnCryoStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnCryoStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.HeaderPanel_Off
        Me.btnCryoStatus.UnKnownText = "Cryo"
        Me.btnCryoStatus.UseVisualStyleBackColor = False
        Me.btnCryoStatus.ValueToBeSend = ""
        '
        'ValveTurboHivac
        '
        Me.ValveTurboHivac.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_HivacValve_Off
        Me.ValveTurboHivac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ValveTurboHivac.Clickable = True
        Me.ValveTurboHivac.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.ValveTurboHivac.ColorText_OffStatus = System.Drawing.Color.White
        Me.ValveTurboHivac.ColorText_OnStatus = System.Drawing.Color.Black
        Me.ValveTurboHivac.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.ValveTurboHivac.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveTurboHivac.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_HivacValve_Unknown
        Me.ValveTurboHivac.ErrorText = ""
        Me.ValveTurboHivac.ForeColor = System.Drawing.Color.White
        Me.ValveTurboHivac.HasDiffClickFunc = False
        Me.ValveTurboHivac.Location = New System.Drawing.Point(79, 99)
        Me.ValveTurboHivac.Name = "ValveTurboHivac"
        Me.ValveTurboHivac.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_HivacValve_Off
        Me.ValveTurboHivac.OffText = ""
        Me.ValveTurboHivac.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_HivacValve
        Me.ValveTurboHivac.OnText = ""
        Me.ValveTurboHivac.Size = New System.Drawing.Size(213, 59)
        Me.ValveTurboHivac.Status = AVP_Robot_Project.SL_ValveControl.DisplayStatus.Off
        Me.ValveTurboHivac.StyleOfButton = AVP_Robot_Project.SL_ValveControl.ButtonStyle.Horizontal
        Me.ValveTurboHivac.TabIndex = 204
        Me.ValveTurboHivac.TextLocation = New System.Drawing.Point(74, 35)
        Me.ValveTurboHivac.TextValue = ""
        Me.ValveTurboHivac.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveTurboHivac.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_HivacValve_Unknown
        Me.ValveTurboHivac.UnKnownText = ""
        Me.ValveTurboHivac.UsingTheSameMsgboxWithName = ""
        Me.ValveTurboHivac.ValueToBeSend = "On"
        '
        'ValveCryoHivac
        '
        Me.ValveCryoHivac.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_HivacValve_Off__Cryo
        Me.ValveCryoHivac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ValveCryoHivac.Clickable = True
        Me.ValveCryoHivac.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.ValveCryoHivac.ColorText_OffStatus = System.Drawing.Color.White
        Me.ValveCryoHivac.ColorText_OnStatus = System.Drawing.Color.Black
        Me.ValveCryoHivac.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.ValveCryoHivac.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveCryoHivac.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_HivacValve_Unknown__Cryo
        Me.ValveCryoHivac.ErrorText = ""
        Me.ValveCryoHivac.ForeColor = System.Drawing.Color.White
        Me.ValveCryoHivac.HasDiffClickFunc = False
        Me.ValveCryoHivac.Location = New System.Drawing.Point(103, 462)
        Me.ValveCryoHivac.Name = "ValveCryoHivac"
        Me.ValveCryoHivac.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_HivacValve_Off__Cryo
        Me.ValveCryoHivac.OffText = ""
        Me.ValveCryoHivac.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_HivacValve_Cryo
        Me.ValveCryoHivac.OnText = ""
        Me.ValveCryoHivac.Size = New System.Drawing.Size(166, 46)
        Me.ValveCryoHivac.Status = AVP_Robot_Project.SL_ValveControl.DisplayStatus.Off
        Me.ValveCryoHivac.StyleOfButton = AVP_Robot_Project.SL_ValveControl.ButtonStyle.Horizontal
        Me.ValveCryoHivac.TabIndex = 204
        Me.ValveCryoHivac.TextLocation = New System.Drawing.Point(74, 35)
        Me.ValveCryoHivac.TextValue = ""
        Me.ValveCryoHivac.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveCryoHivac.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_HivacValve_Unknown__Cryo
        Me.ValveCryoHivac.UnKnownText = ""
        Me.ValveCryoHivac.UsingTheSameMsgboxWithName = ""
        Me.ValveCryoHivac.ValueToBeSend = "On"
        '
        'Shutter
        '
        Me.Shutter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Shutter.Clickable = True
        Me.Shutter.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.Shutter.ColorText_OffStatus = System.Drawing.Color.White
        Me.Shutter.ColorText_OnStatus = System.Drawing.Color.Black
        Me.Shutter.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.Shutter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shutter.ErrorImage = Nothing
        Me.Shutter.ErrorText = ""
        Me.Shutter.ForeColor = System.Drawing.Color.Black
        Me.Shutter.HasDiffClickFunc = False
        Me.Shutter.Location = New System.Drawing.Point(42, 626)
        Me.Shutter.Name = "Shutter"
        Me.Shutter.OffImage = Nothing
        Me.Shutter.OffText = ""
        Me.Shutter.OnImage = Nothing
        Me.Shutter.OnText = ""
        Me.Shutter.Size = New System.Drawing.Size(39, 39)
        Me.Shutter.Status = AVP_Robot_Project.SL_ValveControl.DisplayStatus.[On]
        Me.Shutter.StyleOfButton = AVP_Robot_Project.SL_ValveControl.ButtonStyle.Horizontal
        Me.Shutter.TabIndex = 205
        Me.Shutter.TextLocation = New System.Drawing.Point(74, 35)
        Me.Shutter.TextValue = ""
        Me.Shutter.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.Shutter.UnknownImage = Nothing
        Me.Shutter.UnKnownText = ""
        Me.Shutter.UsingTheSameMsgboxWithName = ""
        Me.Shutter.ValueToBeSend = "On"
        Me.Shutter.Visible = False
        '
        'btnGeneral
        '
        Me.btnGeneral.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGeneral.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGeneral.FlatAppearance.BorderSize = 0
        Me.btnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGeneral.Location = New System.Drawing.Point(20, 426)
        Me.btnGeneral.Name = "btnGeneral"
        Me.btnGeneral.Size = New System.Drawing.Size(30, 28)
        Me.btnGeneral.TabIndex = 198
        Me.btnGeneral.UseVisualStyleBackColor = True
        '
        'SourcePlasma
        '
        Me.SourcePlasma.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Source_Off
        Me.SourcePlasma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.SourcePlasma.Clickable = False
        Me.SourcePlasma.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.SourcePlasma.ColorText_OffStatus = System.Drawing.Color.White
        Me.SourcePlasma.ColorText_OnStatus = System.Drawing.Color.Black
        Me.SourcePlasma.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.SourcePlasma.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.SourcePlasma.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Source_Off
        Me.SourcePlasma.ErrorText = ""
        Me.SourcePlasma.ForeColor = System.Drawing.Color.White
        Me.SourcePlasma.HasDiffClickFunc = False
        Me.SourcePlasma.Location = New System.Drawing.Point(269, 214)
        Me.SourcePlasma.Name = "SourcePlasma"
        Me.SourcePlasma.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Source_Off
        Me.SourcePlasma.OffText = ""
        Me.SourcePlasma.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Source_On
        Me.SourcePlasma.OnText = ""
        Me.SourcePlasma.Size = New System.Drawing.Size(93, 152)
        Me.SourcePlasma.Status = AVP_Robot_Project.SL_ValveControl.DisplayStatus.Off
        Me.SourcePlasma.StyleOfButton = AVP_Robot_Project.SL_ValveControl.ButtonStyle.Horizontal
        Me.SourcePlasma.TabIndex = 205
        Me.SourcePlasma.TextLocation = New System.Drawing.Point(74, 35)
        Me.SourcePlasma.TextValue = ""
        Me.SourcePlasma.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.SourcePlasma.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Source_Ramp
        Me.SourcePlasma.UnKnownText = ""
        Me.SourcePlasma.UsingTheSameMsgboxWithName = ""
        Me.SourcePlasma.ValueToBeSend = "On"
        '
        'Wafer
        '
        Me.Wafer.BackColor = System.Drawing.Color.Transparent
        Me.Wafer.Location = New System.Drawing.Point(3, 489)
        Me.Wafer.Name = "Wafer"
        Me.Wafer.Size = New System.Drawing.Size(79, 40)
        Me.Wafer.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.Wafer.TabIndex = 206
        Me.Wafer.Visible = False
        Me.Wafer.WaferID = "A01"
        '
        'lblT1
        '
        Me.lblT1.AutoSize = True
        Me.lblT1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT1.Location = New System.Drawing.Point(38, 513)
        Me.lblT1.Name = "lblT1"
        Me.lblT1.Size = New System.Drawing.Size(27, 19)
        Me.lblT1.TabIndex = 201
        Me.lblT1.Text = "T1"
        Me.lblT1.Visible = False
        '
        'txtT1
        '
        Me.txtT1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtT1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtT1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtT1.IsNumericTextbox = True
        Me.txtT1.IsReadBack = True
        Me.txtT1.Location = New System.Drawing.Point(205, 513)
        Me.txtT1.Name = "txtT1"
        Me.txtT1.ReadOnly = True
        Me.txtT1.ShowUnitFormat = True
        Me.txtT1.Size = New System.Drawing.Size(67, 24)
        Me.txtT1.TabIndex = 199
        Me.txtT1.TabStop = False
        Me.txtT1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtT1.UnitTypeUsed = "K"
        Me.txtT1.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'lblTiltAtAngleSensor
        '
        Me.lblTiltAtAngleSensor.BackColor = System.Drawing.Color.Transparent
        Me.lblTiltAtAngleSensor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTiltAtAngleSensor.ForeColor = System.Drawing.Color.Black
        Me.lblTiltAtAngleSensor.IsFontStyleDouble = False
        Me.lblTiltAtAngleSensor.Location = New System.Drawing.Point(56, 438)
        Me.lblTiltAtAngleSensor.Name = "lblTiltAtAngleSensor"
        Me.lblTiltAtAngleSensor.RotateAngle = 1
        Me.lblTiltAtAngleSensor.Size = New System.Drawing.Size(140, 20)
        Me.lblTiltAtAngleSensor.TabIndex = 289
        Me.lblTiltAtAngleSensor.Text_In_Label = "Tilt Sensor @"
        Me.lblTiltAtAngleSensor.TranslateTransformX = 0
        Me.lblTiltAtAngleSensor.TranslateTransformY = 0
        Me.lblTiltAtAngleSensor.Visible = False
        '
        'btnTiltSensor
        '
        Me.btnTiltSensor.BackColor = System.Drawing.Color.Transparent
        Me.btnTiltSensor.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black_SLBox
        Me.btnTiltSensor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTiltSensor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnTiltSensor.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.btnTiltSensor.FlatAppearance.BorderSize = 0
        Me.btnTiltSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTiltSensor.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTiltSensor.ForeColor = System.Drawing.Color.White
        Me.btnTiltSensor.Location = New System.Drawing.Point(198, 444)
        Me.btnTiltSensor.MessageBoxText = Nothing
        Me.btnTiltSensor.Name = "btnTiltSensor"
        Me.btnTiltSensor.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black_SLBox
        Me.btnTiltSensor.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green_SLBox
        Me.btnTiltSensor.Size = New System.Drawing.Size(15, 15)
        Me.btnTiltSensor.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnTiltSensor.TabIndex = 290
        Me.btnTiltSensor.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnTiltSensor.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.btnTiltSensor.UseVisualStyleBackColor = False
        Me.btnTiltSensor.ValueToBeSend = "On"
        Me.btnTiltSensor.Visible = False
        '
        'lblOff
        '
        Me.lblOff.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOff.ForeColor = System.Drawing.Color.White
        Me.lblOff.IsFontStyleDouble = False
        Me.lblOff.Location = New System.Drawing.Point(224, 212)
        Me.lblOff.Name = "lblOff"
        Me.lblOff.RotateAngle = 90
        Me.lblOff.Size = New System.Drawing.Size(23, 51)
        Me.lblOff.TabIndex = 322
        Me.lblOff.Text_In_Label = "Closed"
        Me.lblOff.TranslateTransformX = 20
        Me.lblOff.TranslateTransformY = 0
        '
        'lblOn
        '
        Me.lblOn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOn.ForeColor = System.Drawing.Color.White
        Me.lblOn.IsFontStyleDouble = False
        Me.lblOn.Location = New System.Drawing.Point(224, 391)
        Me.lblOn.Name = "lblOn"
        Me.lblOn.RotateAngle = 90
        Me.lblOn.Size = New System.Drawing.Size(23, 38)
        Me.lblOn.TabIndex = 321
        Me.lblOn.Text_In_Label = "Open"
        Me.lblOn.TranslateTransformX = 20
        Me.lblOn.TranslateTransformY = 0
        '
        'lblInternalShutter
        '
        Me.lblInternalShutter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInternalShutter.ForeColor = System.Drawing.Color.White
        Me.lblInternalShutter.IsFontStyleDouble = False
        Me.lblInternalShutter.Location = New System.Drawing.Point(224, 283)
        Me.lblInternalShutter.Name = "lblInternalShutter"
        Me.lblInternalShutter.RotateAngle = 90
        Me.lblInternalShutter.Size = New System.Drawing.Size(23, 85)
        Me.lblInternalShutter.TabIndex = 320
        Me.lblInternalShutter.Text_In_Label = "Int. S Sensor"
        Me.lblInternalShutter.TranslateTransformX = 20
        Me.lblInternalShutter.TranslateTransformY = 0
        '
        'stInternalShutterOff
        '
        Me.stInternalShutterOff.BackColor = System.Drawing.Color.Transparent
        Me.stInternalShutterOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black_SLBox
        Me.stInternalShutterOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.stInternalShutterOff.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.stInternalShutterOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.stInternalShutterOff.FlatAppearance.BorderSize = 0
        Me.stInternalShutterOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.stInternalShutterOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stInternalShutterOff.ForeColor = System.Drawing.Color.White
        Me.stInternalShutterOff.Location = New System.Drawing.Point(229, 263)
        Me.stInternalShutterOff.MessageBoxText = Nothing
        Me.stInternalShutterOff.Name = "stInternalShutterOff"
        Me.stInternalShutterOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black_SLBox
        Me.stInternalShutterOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green_SLBox
        Me.stInternalShutterOff.Size = New System.Drawing.Size(14, 14)
        Me.stInternalShutterOff.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.stInternalShutterOff.TabIndex = 319
        Me.stInternalShutterOff.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.stInternalShutterOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.stInternalShutterOff.UseVisualStyleBackColor = False
        Me.stInternalShutterOff.ValueToBeSend = "On"
        '
        'stInternalShutter
        '
        Me.stInternalShutter.BackColor = System.Drawing.Color.Transparent
        Me.stInternalShutter.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black_SLBox
        Me.stInternalShutter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.stInternalShutter.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.stInternalShutter.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.stInternalShutter.FlatAppearance.BorderSize = 0
        Me.stInternalShutter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.stInternalShutter.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stInternalShutter.ForeColor = System.Drawing.Color.White
        Me.stInternalShutter.Location = New System.Drawing.Point(229, 374)
        Me.stInternalShutter.MessageBoxText = Nothing
        Me.stInternalShutter.Name = "stInternalShutter"
        Me.stInternalShutter.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black_SLBox
        Me.stInternalShutter.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green_SLBox
        Me.stInternalShutter.Size = New System.Drawing.Size(14, 14)
        Me.stInternalShutter.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.stInternalShutter.TabIndex = 318
        Me.stInternalShutter.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.stInternalShutter.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.stInternalShutter.UseVisualStyleBackColor = False
        Me.stInternalShutter.ValueToBeSend = "On"
        '
        'RotationFixture
        '
        Me.RotationFixture.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.RotationFixture.BackColor = System.Drawing.SystemColors.ControlDark
        Me.RotationFixture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.RotationFixture.IsPositiveDirection = True
        Me.RotationFixture.Location = New System.Drawing.Point(0, 150)
        Me.RotationFixture.Name = "RotationFixture"
        Me.RotationFixture.RotationMode = AVPControls.AVPDataLib.AVPControlStyleModes.ControlOnly
        Me.RotationFixture.Size = New System.Drawing.Size(232, 232)
        Me.RotationFixture.TabIndex = 361
        '
        'picBoxPlasma
        '
        Me.picBoxPlasma.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.picBoxPlasma.BackColor = System.Drawing.Color.Transparent
        Me.picBoxPlasma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picBoxPlasma.IsFitSize = False
        Me.picBoxPlasma.IsTransparent = True
        Me.picBoxPlasma.Location = New System.Drawing.Point(157, 253)
        Me.picBoxPlasma.Name = "picBoxPlasma"
        Me.picBoxPlasma.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Plasma
        Me.picBoxPlasma.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Plasma_1
        Me.picBoxPlasma.Size = New System.Drawing.Size(57, 96)
        Me.picBoxPlasma.TabIndex = 360
        Me.picBoxPlasma.Visible = False
        '
        'ShutterControl
        '
        Me.ShutterControl.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX5
        Me.ShutterControl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ShutterControl.Location = New System.Drawing.Point(157, 248)
        Me.ShutterControl.Name = "ShutterControl"
        Me.ShutterControl.Size = New System.Drawing.Size(60, 194)
        Me.ShutterControl.Status = AVPControls.AVPDataLib.DisplayStatus.[On]
        Me.ShutterControl.TabIndex = 362
        '
        'txtRampingPercent
        '
        Me.txtRampingPercent.BackColor = System.Drawing.Color.Transparent
        Me.txtRampingPercent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRampingPercent.ForeColor = System.Drawing.Color.Yellow
        Me.txtRampingPercent.IsFontStyleDouble = False
        Me.txtRampingPercent.Location = New System.Drawing.Point(99, 73)
        Me.txtRampingPercent.Name = "txtRampingPercent"
        Me.txtRampingPercent.RotateAngle = 0
        Me.txtRampingPercent.Size = New System.Drawing.Size(67, 23)
        Me.txtRampingPercent.TabIndex = 363
        Me.txtRampingPercent.Text_In_Label = ""
        Me.txtRampingPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtRampingPercent.TranslateTransformX = 0
        Me.txtRampingPercent.TranslateTransformY = 0
        Me.txtRampingPercent.Visible = False
        '
        'SLBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_ProcessModel
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.txtRampingPercent)
        Me.Controls.Add(Me.ShutterControl)
        Me.Controls.Add(Me.RotationFixture)
        Me.Controls.Add(Me.picBoxPlasma)
        Me.Controls.Add(Me.lblOff)
        Me.Controls.Add(Me.lblOn)
        Me.Controls.Add(Me.lblInternalShutter)
        Me.Controls.Add(Me.stInternalShutterOff)
        Me.Controls.Add(Me.stInternalShutter)
        Me.Controls.Add(Me.btnTiltSensor)
        Me.Controls.Add(Me.btnGeneral)
        Me.Controls.Add(Me.lblTiltAtAngleSensor)
        Me.Controls.Add(Me.Shutter)
        Me.Controls.Add(Me.Wafer)
        Me.Controls.Add(Me.SourcePlasma)
        Me.Controls.Add(Me.btnMesaValve)
        Me.Controls.Add(Me.txtT1)
        Me.Controls.Add(Me.txtT2)
        Me.Controls.Add(Me.ValveCryoHivac)
        Me.Controls.Add(Me.lblT1)
        Me.Controls.Add(Me.lblT2)
        Me.Controls.Add(Me.txtWaterPump)
        Me.Controls.Add(Me.btnCryoOn)
        Me.Controls.Add(Me.btnCryoStatus)
        Me.Controls.Add(Me.btnWaterPumpOn)
        Me.Controls.Add(Me.ValveTurboHivac)
        Me.HeaderVisible = False
        Me.Name = "SLBox"
        Me.Size = New System.Drawing.Size(364, 605)
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.ValveTurboHivac, 0)
        Me.Controls.SetChildIndex(Me.btnWaterPumpOn, 0)
        Me.Controls.SetChildIndex(Me.btnCryoStatus, 0)
        Me.Controls.SetChildIndex(Me.btnCryoOn, 0)
        Me.Controls.SetChildIndex(Me.txtWaterPump, 0)
        Me.Controls.SetChildIndex(Me.lblT2, 0)
        Me.Controls.SetChildIndex(Me.lblT1, 0)
        Me.Controls.SetChildIndex(Me.ValveCryoHivac, 0)
        Me.Controls.SetChildIndex(Me.txtT2, 0)
        Me.Controls.SetChildIndex(Me.txtT1, 0)
        Me.Controls.SetChildIndex(Me.btnMesaValve, 0)
        Me.Controls.SetChildIndex(Me.SourcePlasma, 0)
        Me.Controls.SetChildIndex(Me.Wafer, 0)
        Me.Controls.SetChildIndex(Me.Shutter, 0)
        Me.Controls.SetChildIndex(Me.lblTiltAtAngleSensor, 0)
        Me.Controls.SetChildIndex(Me.btnGeneral, 0)
        Me.Controls.SetChildIndex(Me.btnTiltSensor, 0)
        Me.Controls.SetChildIndex(Me.stInternalShutter, 0)
        Me.Controls.SetChildIndex(Me.stInternalShutterOff, 0)
        Me.Controls.SetChildIndex(Me.lblInternalShutter, 0)
        Me.Controls.SetChildIndex(Me.lblOn, 0)
        Me.Controls.SetChildIndex(Me.lblOff, 0)
        Me.Controls.SetChildIndex(Me.picBoxPlasma, 0)
        Me.Controls.SetChildIndex(Me.RotationFixture, 0)
        Me.Controls.SetChildIndex(Me.ShutterControl, 0)
        Me.Controls.SetChildIndex(Me.txtRampingPercent, 0)
        CType(Me.RotationFixture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxPlasma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShutterControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnWaterPumpOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtWaterPump As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnMesaValve As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtT2 As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblT2 As System.Windows.Forms.Label
    Friend WithEvents btnCryoOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnCryoStatus As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents ValveTurboHivac As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents ValveCryoHivac As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents Shutter As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents btnGeneral As System.Windows.Forms.Button
    Friend WithEvents SourcePlasma As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents Wafer As AVP_Robot_Project.IBE_WaferInside
    Friend WithEvents lblT1 As System.Windows.Forms.Label
    Friend WithEvents txtT1 As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblTiltAtAngleSensor As AVP_Robot_Project.AVPLabel
    Friend WithEvents btnTiltSensor As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblOff As AVP_Robot_Project.AVPLabel
    Friend WithEvents lblOn As AVP_Robot_Project.AVPLabel
    Friend WithEvents lblInternalShutter As AVP_Robot_Project.AVPLabel
    Friend WithEvents stInternalShutterOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents stInternalShutter As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents picBoxPlasma As AVPControls.AnimationControl
    Friend WithEvents RotationFixture As AVPControls.AVPFixtureControl
    Friend WithEvents ShutterControl As AVPControls.AVPShutterControl
    Friend WithEvents txtRampingPercent As AVP_Robot_Project.AVPLabel

End Class
