<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_Fixture
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
        Me.btnMode = New AVP_Robot_Project.SL_CustomButton
        Me.txtTiltAngleRight = New AVP_Robot_Project.SL_Textbox
        Me.txtTiltAngleLeft = New AVP_Robot_Project.SL_Textbox
        Me.txtRotationMode = New AVP_Robot_Project.SL_Textbox
        Me.txtFlowCoolGas = New AVP_Robot_Project.SL_Textbox
        Me.txtFlowCoolGasRight = New AVP_Robot_Project.SL_Textbox
        Me.ValveSupplyFlowCoolGas = New AVP_Robot_Project.ValveControl
        Me.ValveShutoffFlowCoolGas = New AVP_Robot_Project.ValveControl
        Me.GasLine_FlowCool = New AVPControls.AnimationControl
        Me.txtRotationStaticLeft = New AVP_Robot_Project.SL_Textbox
        Me.txtRotationSweepLeft = New AVP_Robot_Project.SL_Textbox
        Me.txtRotationContinuousLeft = New AVP_Robot_Project.SL_Textbox
        Me.txtRotationStaticRight = New AVP_Robot_Project.SL_Textbox
        Me.txtRotationSweepRight = New AVP_Robot_Project.SL_Textbox
        Me.txtRotationContinuousRight = New AVP_Robot_Project.SL_Textbox
        Me.Label2 = New System.Windows.Forms.Label
        Me.stHomeTilt = New AVP_Robot_Project.SmallCircleControl
        Me.Label3 = New System.Windows.Forms.Label
        Me.stHomeRotation = New AVP_Robot_Project.SmallCircleControl
        Me.Label4 = New System.Windows.Forms.Label
        Me.stStartRotation = New AVP_Robot_Project.SmallCircleControl
        Me.ImageBinaryStatusControl1 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.ImageBinaryStatusControl2 = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.txtRotationEnd = New AVP_Robot_Project.SL_Textbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnClampDown = New AVP_Robot_Project.SL_CustomButton
        Me.btnClampUp = New AVP_Robot_Project.SL_CustomButton
        Me.btnFlowCoolPump = New AVP_Robot_Project.SL_CustomButton
        Me.btnRotate = New AVP_Robot_Project.SL_CustomButton
        Me.btnShutterOpen = New AVP_Robot_Project.SL_CustomButton
        Me.btnShutterClose = New AVP_Robot_Project.SL_CustomButton
        Me.btnMotionInitialized = New AVP_Robot_Project.SL_CustomButton
        Me.Label19 = New System.Windows.Forms.Label
        Me.stTiltMoving = New AVP_Robot_Project.SmallCircleControl
        Me.slMotionInitializingStatus = New AVP_Robot_Project.SL_CustomButton
        Me.btnOpenCloseFlowCoolGas = New AVP_Robot_Project.SL_CustomButton
        Me.stTiltError = New AVP_Robot_Project.SmallCircleControl
        Me.txtRotationSweepAngleReadback = New AVP_Robot_Project.SL_Textbox
        Me.stRotationError = New AVP_Robot_Project.SmallCircleControl
        Me.txtTiltSweepRight = New AVP_Robot_Project.SL_Textbox
        Me.txtTiltMode = New AVP_Robot_Project.SL_Textbox
        Me.txtTiltEnd = New AVP_Robot_Project.SL_Textbox
        Me.btnTilt = New AVP_Robot_Project.SL_CustomButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblEnd = New System.Windows.Forms.Label
        Me.cbTiltMode = New System.Windows.Forms.CheckBox
        Me.lblHomeTilt = New System.Windows.Forms.Label
        Me.lblHomeRotaion = New System.Windows.Forms.Label
        CType(Me.GasLine_FlowCool, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Font = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(789, 27)
        Me.Header.Text = "Fixture"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'btnMode
        '
        Me.btnMode.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMode.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMode.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMode.FlatAppearance.BorderSize = 0
        Me.btnMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMode.ForeColor = System.Drawing.Color.Black
        Me.btnMode.Location = New System.Drawing.Point(258, 160)
        Me.btnMode.MessageBoxText = Nothing
        Me.btnMode.Name = "btnMode"
        Me.btnMode.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMode.OffText = "Mode"
        Me.btnMode.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMode.Size = New System.Drawing.Size(102, 26)
        Me.btnMode.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnMode.TabIndex = 72
        Me.btnMode.Text = "Mode"
        Me.btnMode.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnMode.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMode.UseVisualStyleBackColor = True
        Me.btnMode.ValueToBeSend = "On"
        '
        'txtTiltAngleRight
        '
        Me.txtTiltAngleRight.BackColor = System.Drawing.Color.White
        Me.txtTiltAngleRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTiltAngleRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTiltAngleRight.IsNumericTextbox = True
        Me.txtTiltAngleRight.Location = New System.Drawing.Point(259, 105)
        Me.txtTiltAngleRight.MinimumValueHighlightedGreen = 0
        Me.txtTiltAngleRight.Name = "txtTiltAngleRight"
        Me.txtTiltAngleRight.ReadOnly = True
        Me.txtTiltAngleRight.Size = New System.Drawing.Size(100, 24)
        Me.txtTiltAngleRight.TabIndex = 7
        Me.txtTiltAngleRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTiltAngleRight.UseBackGroundWorkerToUpdateMinMax = True
        '
        'txtTiltAngleLeft
        '
        Me.txtTiltAngleLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTiltAngleLeft.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTiltAngleLeft.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTiltAngleLeft.IsReadBack = True
        Me.txtTiltAngleLeft.Location = New System.Drawing.Point(154, 105)
        Me.txtTiltAngleLeft.MinimumValueHighlightedGreen = 0
        Me.txtTiltAngleLeft.Name = "txtTiltAngleLeft"
        Me.txtTiltAngleLeft.ReadOnly = True
        Me.txtTiltAngleLeft.Size = New System.Drawing.Size(100, 24)
        Me.txtTiltAngleLeft.TabIndex = 73
        Me.txtTiltAngleLeft.TabStop = False
        Me.txtTiltAngleLeft.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTiltAngleLeft.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtRotationMode
        '
        Me.txtRotationMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRotationMode.Clickable = False
        Me.txtRotationMode.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRotationMode.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotationMode.IsReadBack = True
        Me.txtRotationMode.Location = New System.Drawing.Point(154, 161)
        Me.txtRotationMode.MinimumValueHighlightedGreen = 0
        Me.txtRotationMode.Name = "txtRotationMode"
        Me.txtRotationMode.ReadOnly = True
        Me.txtRotationMode.Size = New System.Drawing.Size(100, 24)
        Me.txtRotationMode.TabIndex = 8
        Me.txtRotationMode.TabStop = False
        Me.txtRotationMode.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtFlowCoolGas
        '
        Me.txtFlowCoolGas.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFlowCoolGas.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFlowCoolGas.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtFlowCoolGas.IsReadBack = True
        Me.txtFlowCoolGas.Location = New System.Drawing.Point(9, 34)
        Me.txtFlowCoolGas.MinimumValueHighlightedGreen = 0
        Me.txtFlowCoolGas.Multiline = True
        Me.txtFlowCoolGas.Name = "txtFlowCoolGas"
        Me.txtFlowCoolGas.ReadOnly = True
        Me.txtFlowCoolGas.Size = New System.Drawing.Size(75, 24)
        Me.txtFlowCoolGas.TabIndex = 219
        Me.txtFlowCoolGas.TabStop = False
        Me.txtFlowCoolGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtFlowCoolGas.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtFlowCoolGasRight
        '
        Me.txtFlowCoolGasRight.BackColor = System.Drawing.Color.White
        Me.txtFlowCoolGasRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtFlowCoolGasRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtFlowCoolGasRight.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtFlowCoolGasRight.IsNumericTextbox = True
        Me.txtFlowCoolGasRight.Location = New System.Drawing.Point(149, 34)
        Me.txtFlowCoolGasRight.MinimumValueHighlightedGreen = 0
        Me.txtFlowCoolGasRight.Multiline = True
        Me.txtFlowCoolGasRight.Name = "txtFlowCoolGasRight"
        Me.txtFlowCoolGasRight.ReadOnly = True
        Me.txtFlowCoolGasRight.Size = New System.Drawing.Size(75, 24)
        Me.txtFlowCoolGasRight.TabIndex = 0
        Me.txtFlowCoolGasRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtFlowCoolGasRight.UseBackGroundWorkerToUpdateMinMax = True
        '
        'ValveSupplyFlowCoolGas
        '
        Me.ValveSupplyFlowCoolGas.AccessibleName = "Supply FlowCool Gas Valve"
        Me.ValveSupplyFlowCoolGas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupplyFlowCoolGas.IsCheckSafetyBeforeClick = False
        Me.ValveSupplyFlowCoolGas.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupplyFlowCoolGas.Location = New System.Drawing.Point(228, 47)
        Me.ValveSupplyFlowCoolGas.Name = "ValveSupplyFlowCoolGas"
        Me.ValveSupplyFlowCoolGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupplyFlowCoolGas.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyFlowCoolGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupplyFlowCoolGas.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyFlowCoolGas.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupplyFlowCoolGas.Size = New System.Drawing.Size(40, 33)
        Me.ValveSupplyFlowCoolGas.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupplyFlowCoolGas.TabIndex = 216
        Me.ValveSupplyFlowCoolGas.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupplyFlowCoolGas.TextLocIsFix = True
        Me.ValveSupplyFlowCoolGas.TextValue = ""
        Me.ValveSupplyFlowCoolGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupplyFlowCoolGas.Unit = ""
        Me.ValveSupplyFlowCoolGas.UnknownImage = Nothing
        Me.ValveSupplyFlowCoolGas.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyFlowCoolGas.UseClickedEventInForm = True
        Me.ValveSupplyFlowCoolGas.UsingScientificFormat = True
        '
        'ValveShutoffFlowCoolGas
        '
        Me.ValveShutoffFlowCoolGas.AccessibleName = "Shutoff FlowCool Gas Valve"
        Me.ValveShutoffFlowCoolGas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutoffFlowCoolGas.IsCheckSafetyBeforeClick = False
        Me.ValveShutoffFlowCoolGas.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutoffFlowCoolGas.Location = New System.Drawing.Point(385, 256)
        Me.ValveShutoffFlowCoolGas.Name = "ValveShutoffFlowCoolGas"
        Me.ValveShutoffFlowCoolGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutoffFlowCoolGas.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffFlowCoolGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutoffFlowCoolGas.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffFlowCoolGas.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutoffFlowCoolGas.Size = New System.Drawing.Size(40, 33)
        Me.ValveShutoffFlowCoolGas.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutoffFlowCoolGas.TabIndex = 217
        Me.ValveShutoffFlowCoolGas.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutoffFlowCoolGas.TextLocIsFix = True
        Me.ValveShutoffFlowCoolGas.TextValue = ""
        Me.ValveShutoffFlowCoolGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutoffFlowCoolGas.Unit = ""
        Me.ValveShutoffFlowCoolGas.UnknownImage = Nothing
        Me.ValveShutoffFlowCoolGas.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffFlowCoolGas.UseClickedEventInForm = True
        Me.ValveShutoffFlowCoolGas.UsingScientificFormat = True
        Me.ValveShutoffFlowCoolGas.Visible = False
        '
        'GasLine_FlowCool
        '
        Me.GasLine_FlowCool.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_FlowCool.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_FlowCool.Location = New System.Drawing.Point(-71, 57)
        Me.GasLine_FlowCool.Name = "GasLine_FlowCool"
        Me.GasLine_FlowCool.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline1_Supply
        Me.GasLine_FlowCool.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline1_Supply_On
        Me.GasLine_FlowCool.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline1_Supply_On_1
        Me.GasLine_FlowCool.Size = New System.Drawing.Size(352, 15)
        Me.GasLine_FlowCool.TabIndex = 227
        '
        'txtRotationStaticLeft
        '
        Me.txtRotationStaticLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRotationStaticLeft.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRotationStaticLeft.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotationStaticLeft.IsReadBack = True
        Me.txtRotationStaticLeft.Location = New System.Drawing.Point(14, 256)
        Me.txtRotationStaticLeft.MinimumValueHighlightedGreen = 0
        Me.txtRotationStaticLeft.Name = "txtRotationStaticLeft"
        Me.txtRotationStaticLeft.ReadOnly = True
        Me.txtRotationStaticLeft.Size = New System.Drawing.Size(100, 24)
        Me.txtRotationStaticLeft.TabIndex = 73
        Me.txtRotationStaticLeft.TabStop = False
        Me.txtRotationStaticLeft.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRotationStaticLeft.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtRotationStaticLeft.Visible = False
        '
        'txtRotationSweepLeft
        '
        Me.txtRotationSweepLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRotationSweepLeft.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRotationSweepLeft.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotationSweepLeft.IsReadBack = True
        Me.txtRotationSweepLeft.Location = New System.Drawing.Point(14, 286)
        Me.txtRotationSweepLeft.MinimumValueHighlightedGreen = 0
        Me.txtRotationSweepLeft.Name = "txtRotationSweepLeft"
        Me.txtRotationSweepLeft.ReadOnly = True
        Me.txtRotationSweepLeft.Size = New System.Drawing.Size(100, 24)
        Me.txtRotationSweepLeft.TabIndex = 73
        Me.txtRotationSweepLeft.TabStop = False
        Me.txtRotationSweepLeft.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRotationSweepLeft.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtRotationSweepLeft.Visible = False
        '
        'txtRotationContinuousLeft
        '
        Me.txtRotationContinuousLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRotationContinuousLeft.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRotationContinuousLeft.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotationContinuousLeft.IsReadBack = True
        Me.txtRotationContinuousLeft.Location = New System.Drawing.Point(15, 316)
        Me.txtRotationContinuousLeft.MinimumValueHighlightedGreen = 0
        Me.txtRotationContinuousLeft.Name = "txtRotationContinuousLeft"
        Me.txtRotationContinuousLeft.ReadOnly = True
        Me.txtRotationContinuousLeft.Size = New System.Drawing.Size(100, 24)
        Me.txtRotationContinuousLeft.TabIndex = 73
        Me.txtRotationContinuousLeft.TabStop = False
        Me.txtRotationContinuousLeft.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRotationContinuousLeft.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtRotationContinuousLeft.Visible = False
        '
        'txtRotationStaticRight
        '
        Me.txtRotationStaticRight.BackColor = System.Drawing.Color.White
        Me.txtRotationStaticRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRotationStaticRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotationStaticRight.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtRotationStaticRight.IsNumericTextbox = True
        Me.txtRotationStaticRight.Location = New System.Drawing.Point(120, 256)
        Me.txtRotationStaticRight.MinimumValueHighlightedGreen = 0
        Me.txtRotationStaticRight.Name = "txtRotationStaticRight"
        Me.txtRotationStaticRight.ReadOnly = True
        Me.txtRotationStaticRight.Size = New System.Drawing.Size(100, 24)
        Me.txtRotationStaticRight.TabIndex = 10
        Me.txtRotationStaticRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRotationStaticRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtRotationStaticRight.Visible = False
        '
        'txtRotationSweepRight
        '
        Me.txtRotationSweepRight.BackColor = System.Drawing.Color.White
        Me.txtRotationSweepRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRotationSweepRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotationSweepRight.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtRotationSweepRight.IsNumericTextbox = True
        Me.txtRotationSweepRight.Location = New System.Drawing.Point(259, 133)
        Me.txtRotationSweepRight.MinimumValueHighlightedGreen = 0
        Me.txtRotationSweepRight.Name = "txtRotationSweepRight"
        Me.txtRotationSweepRight.ReadOnly = True
        Me.txtRotationSweepRight.Size = New System.Drawing.Size(100, 24)
        Me.txtRotationSweepRight.TabIndex = 11
        Me.txtRotationSweepRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRotationSweepRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtRotationSweepRight.Visible = False
        '
        'txtRotationContinuousRight
        '
        Me.txtRotationContinuousRight.BackColor = System.Drawing.Color.White
        Me.txtRotationContinuousRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRotationContinuousRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotationContinuousRight.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtRotationContinuousRight.IsNumericTextbox = True
        Me.txtRotationContinuousRight.Location = New System.Drawing.Point(120, 286)
        Me.txtRotationContinuousRight.MinimumValueHighlightedGreen = 0
        Me.txtRotationContinuousRight.Name = "txtRotationContinuousRight"
        Me.txtRotationContinuousRight.ReadOnly = True
        Me.txtRotationContinuousRight.Size = New System.Drawing.Size(100, 24)
        Me.txtRotationContinuousRight.TabIndex = 12
        Me.txtRotationContinuousRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRotationContinuousRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtRotationContinuousRight.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Tilt Angle"
        '
        'stHomeTilt
        '
        Me.stHomeTilt.DefaultImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.stHomeTilt.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.stHomeTilt.HomeImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.stHomeTilt.Location = New System.Drawing.Point(18, 110)
        Me.stHomeTilt.MovingImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.stHomeTilt.Name = "stHomeTilt"
        Me.stHomeTilt.Size = New System.Drawing.Size(15, 15)
        Me.stHomeTilt.Status = AVP_Robot_Project.FourStatusControl.DisplayStatus.[Default]
        Me.stHomeTilt.TabIndex = 69
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 16)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Rotation Angle"
        '
        'stHomeRotation
        '
        Me.stHomeRotation.DefaultImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.stHomeRotation.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.stHomeRotation.HomeImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.stHomeRotation.Location = New System.Drawing.Point(18, 138)
        Me.stHomeRotation.MovingImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.stHomeRotation.Name = "stHomeRotation"
        Me.stHomeRotation.Size = New System.Drawing.Size(15, 15)
        Me.stHomeRotation.Status = AVP_Robot_Project.FourStatusControl.DisplayStatus.[Default]
        Me.stHomeRotation.TabIndex = 69
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Rotating"
        '
        'stStartRotation
        '
        Me.stStartRotation.DefaultImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.stStartRotation.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.stStartRotation.HomeImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.stStartRotation.Location = New System.Drawing.Point(18, 166)
        Me.stStartRotation.MovingImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.stStartRotation.Name = "stStartRotation"
        Me.stStartRotation.Size = New System.Drawing.Size(15, 15)
        Me.stStartRotation.Status = AVP_Robot_Project.FourStatusControl.DisplayStatus.[Default]
        Me.stStartRotation.TabIndex = 69
        '
        'ImageBinaryStatusControl1
        '
        Me.ImageBinaryStatusControl1.Enabled = False
        Me.ImageBinaryStatusControl1.Location = New System.Drawing.Point(348, 190)
        Me.ImageBinaryStatusControl1.Name = "ImageBinaryStatusControl1"
        Me.ImageBinaryStatusControl1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline1_Supply
        Me.ImageBinaryStatusControl1.OffState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline1_Supply_On
        Me.ImageBinaryStatusControl1.OnState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl1.Size = New System.Drawing.Size(140, 1)
        Me.ImageBinaryStatusControl1.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ImageBinaryStatusControl1.TabIndex = 215
        Me.ImageBinaryStatusControl1.TextLocation = New System.Drawing.Point(0, 0)
        Me.ImageBinaryStatusControl1.TextLocIsFix = True
        Me.ImageBinaryStatusControl1.TextValue = ""
        Me.ImageBinaryStatusControl1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ImageBinaryStatusControl1.UnknownImage = Nothing
        Me.ImageBinaryStatusControl1.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'ImageBinaryStatusControl2
        '
        Me.ImageBinaryStatusControl2.Enabled = False
        Me.ImageBinaryStatusControl2.Location = New System.Drawing.Point(350, 85)
        Me.ImageBinaryStatusControl2.Name = "ImageBinaryStatusControl2"
        Me.ImageBinaryStatusControl2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline1_Supply
        Me.ImageBinaryStatusControl2.OffState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline1_Supply_On
        Me.ImageBinaryStatusControl2.OnState_ColorText = System.Drawing.Color.Empty
        Me.ImageBinaryStatusControl2.Size = New System.Drawing.Size(140, 1)
        Me.ImageBinaryStatusControl2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ImageBinaryStatusControl2.TabIndex = 221
        Me.ImageBinaryStatusControl2.TextLocation = New System.Drawing.Point(0, 0)
        Me.ImageBinaryStatusControl2.TextLocIsFix = True
        Me.ImageBinaryStatusControl2.TextValue = ""
        Me.ImageBinaryStatusControl2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ImageBinaryStatusControl2.UnknownImage = Nothing
        Me.ImageBinaryStatusControl2.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'txtRotationEnd
        '
        Me.txtRotationEnd.BackColor = System.Drawing.Color.White
        Me.txtRotationEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRotationEnd.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotationEnd.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtRotationEnd.IsNumericTextbox = True
        Me.txtRotationEnd.Location = New System.Drawing.Point(364, 133)
        Me.txtRotationEnd.MinimumValueHighlightedGreen = 0
        Me.txtRotationEnd.Name = "txtRotationEnd"
        Me.txtRotationEnd.ReadOnly = True
        Me.txtRotationEnd.Size = New System.Drawing.Size(100, 24)
        Me.txtRotationEnd.TabIndex = 13
        Me.txtRotationEnd.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRotationEnd.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtRotationEnd.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(163, 331)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 16)
        Me.Label6.TabIndex = 222
        Me.Label6.Text = "(sccm)"
        '
        'btnClampDown
        '
        Me.btnClampDown.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnClampDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClampDown.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnClampDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClampDown.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnClampDown.FlatAppearance.BorderSize = 0
        Me.btnClampDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClampDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnClampDown.ForeColor = System.Drawing.Color.Black
        Me.btnClampDown.Location = New System.Drawing.Point(15, 223)
        Me.btnClampDown.MessageBoxText = Nothing
        Me.btnClampDown.Name = "btnClampDown"
        Me.btnClampDown.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClampDown.OffText = "Clamp Down"
        Me.btnClampDown.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnClampDown.OnText = "Clamp Down"
        Me.btnClampDown.Size = New System.Drawing.Size(140, 27)
        Me.btnClampDown.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[On]
        Me.btnClampDown.TabIndex = 72
        Me.btnClampDown.Text = "Clamp Down"
        Me.btnClampDown.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnClampDown.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnClampDown.UseVisualStyleBackColor = True
        Me.btnClampDown.ValueToBeSend = "On"
        '
        'btnClampUp
        '
        Me.btnClampUp.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClampUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClampUp.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnClampUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClampUp.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnClampUp.FlatAppearance.BorderSize = 0
        Me.btnClampUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClampUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnClampUp.ForeColor = System.Drawing.Color.Black
        Me.btnClampUp.Location = New System.Drawing.Point(15, 194)
        Me.btnClampUp.MessageBoxText = Nothing
        Me.btnClampUp.Name = "btnClampUp"
        Me.btnClampUp.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClampUp.OffText = "Clamp Up"
        Me.btnClampUp.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnClampUp.OnText = "Clamp Up"
        Me.btnClampUp.Size = New System.Drawing.Size(140, 27)
        Me.btnClampUp.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnClampUp.TabIndex = 72
        Me.btnClampUp.Text = "Clamp Up"
        Me.btnClampUp.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnClampUp.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnClampUp.UseVisualStyleBackColor = True
        Me.btnClampUp.ValueToBeSend = "On"
        '
        'btnFlowCoolPump
        '
        Me.btnFlowCoolPump.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnFlowCoolPump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFlowCoolPump.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnFlowCoolPump.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFlowCoolPump.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnFlowCoolPump.FlatAppearance.BorderSize = 0
        Me.btnFlowCoolPump.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFlowCoolPump.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnFlowCoolPump.ForeColor = System.Drawing.Color.Black
        Me.btnFlowCoolPump.Location = New System.Drawing.Point(283, 33)
        Me.btnFlowCoolPump.MessageBoxText = Nothing
        Me.btnFlowCoolPump.Name = "btnFlowCoolPump"
        Me.btnFlowCoolPump.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnFlowCoolPump.OffText = "FC Pump"
        Me.btnFlowCoolPump.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnFlowCoolPump.OnText = "FC Pump"
        Me.btnFlowCoolPump.Size = New System.Drawing.Size(89, 27)
        Me.btnFlowCoolPump.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnFlowCoolPump.TabIndex = 72
        Me.btnFlowCoolPump.Text = "FC Pump"
        Me.btnFlowCoolPump.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnFlowCoolPump.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnFlowCoolPump.UseClickedEventInForm = True
        Me.btnFlowCoolPump.UseVisualStyleBackColor = True
        Me.btnFlowCoolPump.ValueToBeSend = "On"
        '
        'btnRotate
        '
        Me.btnRotate.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRotate.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRotate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRotate.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnRotate.FlatAppearance.BorderSize = 0
        Me.btnRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRotate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnRotate.ForeColor = System.Drawing.Color.Black
        Me.btnRotate.Location = New System.Drawing.Point(317, 194)
        Me.btnRotate.MessageBoxText = Nothing
        Me.btnRotate.Name = "btnRotate"
        Me.btnRotate.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRotate.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnRotate.Size = New System.Drawing.Size(140, 27)
        Me.btnRotate.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnRotate.TabIndex = 72
        Me.btnRotate.Text = "Rotate"
        Me.btnRotate.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnRotate.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnRotate.UseClickedEventInForm = True
        Me.btnRotate.UseVisualStyleBackColor = True
        Me.btnRotate.ValueToBeSend = "On"
        '
        'btnShutterOpen
        '
        Me.btnShutterOpen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnShutterOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShutterOpen.Clickable = True
        Me.btnShutterOpen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnShutterOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShutterOpen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnShutterOpen.FlatAppearance.BorderSize = 0
        Me.btnShutterOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShutterOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnShutterOpen.ForeColor = System.Drawing.Color.Black
        Me.btnShutterOpen.IsSingleFunction = True
        Me.btnShutterOpen.Location = New System.Drawing.Point(166, 194)
        Me.btnShutterOpen.MessageBoxText = Nothing
        Me.btnShutterOpen.Name = "btnShutterOpen"
        Me.btnShutterOpen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnShutterOpen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnShutterOpen.Size = New System.Drawing.Size(140, 27)
        Me.btnShutterOpen.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnShutterOpen.TabIndex = 72
        Me.btnShutterOpen.Text = "Shutter Open"
        Me.btnShutterOpen.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnShutterOpen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnShutterOpen.UseVisualStyleBackColor = True
        Me.btnShutterOpen.ValueToBeSend = "On"
        '
        'btnShutterClose
        '
        Me.btnShutterClose.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnShutterClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShutterClose.Clickable = True
        Me.btnShutterClose.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnShutterClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShutterClose.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnShutterClose.FlatAppearance.BorderSize = 0
        Me.btnShutterClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShutterClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnShutterClose.ForeColor = System.Drawing.Color.Black
        Me.btnShutterClose.IsSingleFunction = True
        Me.btnShutterClose.Location = New System.Drawing.Point(166, 223)
        Me.btnShutterClose.MessageBoxText = Nothing
        Me.btnShutterClose.Name = "btnShutterClose"
        Me.btnShutterClose.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnShutterClose.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnShutterClose.Size = New System.Drawing.Size(140, 27)
        Me.btnShutterClose.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[On]
        Me.btnShutterClose.TabIndex = 72
        Me.btnShutterClose.Text = "Shutter Close"
        Me.btnShutterClose.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnShutterClose.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnShutterClose.UseVisualStyleBackColor = True
        Me.btnShutterClose.ValueToBeSend = "On"
        '
        'btnMotionInitialized
        '
        Me.btnMotionInitialized.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMotionInitialized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMotionInitialized.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMotionInitialized.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMotionInitialized.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMotionInitialized.FlatAppearance.BorderSize = 0
        Me.btnMotionInitialized.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMotionInitialized.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMotionInitialized.ForeColor = System.Drawing.Color.Black
        Me.btnMotionInitialized.Location = New System.Drawing.Point(317, 223)
        Me.btnMotionInitialized.MessageBoxText = Nothing
        Me.btnMotionInitialized.Name = "btnMotionInitialized"
        Me.btnMotionInitialized.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMotionInitialized.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMotionInitialized.Size = New System.Drawing.Size(140, 27)
        Me.btnMotionInitialized.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnMotionInitialized.TabIndex = 72
        Me.btnMotionInitialized.Text = "Initialize Motion"
        Me.btnMotionInitialized.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnMotionInitialized.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMotionInitialized.UseClickedEventInForm = True
        Me.btnMotionInitialized.UseVisualStyleBackColor = True
        Me.btnMotionInitialized.ValueToBeSend = "On"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(235, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 16)
        Me.Label19.TabIndex = 214
        Me.Label19.Text = "He"
        '
        'stTiltMoving
        '
        Me.stTiltMoving.DefaultImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.stTiltMoving.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.stTiltMoving.HomeImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.stTiltMoving.Location = New System.Drawing.Point(441, 336)
        Me.stTiltMoving.MovingImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.stTiltMoving.Name = "stTiltMoving"
        Me.stTiltMoving.Size = New System.Drawing.Size(15, 15)
        Me.stTiltMoving.Status = AVP_Robot_Project.FourStatusControl.DisplayStatus.[Default]
        Me.stTiltMoving.TabIndex = 69
        Me.stTiltMoving.Visible = False
        '
        'slMotionInitializingStatus
        '
        Me.slMotionInitializingStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.slMotionInitializingStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.slMotionInitializingStatus.ColorText_OffStatus = System.Drawing.Color.Black
        Me.slMotionInitializingStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.slMotionInitializingStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.slMotionInitializingStatus.FlatAppearance.BorderSize = 0
        Me.slMotionInitializingStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.slMotionInitializingStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.slMotionInitializingStatus.ForeColor = System.Drawing.Color.Black
        Me.slMotionInitializingStatus.Location = New System.Drawing.Point(261, 294)
        Me.slMotionInitializingStatus.MessageBoxText = Nothing
        Me.slMotionInitializingStatus.Name = "slMotionInitializingStatus"
        Me.slMotionInitializingStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.slMotionInitializingStatus.OffText = "Motion Initialized"
        Me.slMotionInitializingStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.slMotionInitializingStatus.OnText = "Motion Initialized"
        Me.slMotionInitializingStatus.Size = New System.Drawing.Size(174, 27)
        Me.slMotionInitializingStatus.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.slMotionInitializingStatus.TabIndex = 72
        Me.slMotionInitializingStatus.Text = "MotionInitiazingStatus"
        Me.slMotionInitializingStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.slMotionInitializingStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.slMotionInitializingStatus.UseClickedEventInForm = True
        Me.slMotionInitializingStatus.UseVisualStyleBackColor = True
        Me.slMotionInitializingStatus.ValueToBeSend = "On"
        Me.slMotionInitializingStatus.Visible = False
        '
        'btnOpenCloseFlowCoolGas
        '
        Me.btnOpenCloseFlowCoolGas.AccessibleName = "Shutoff/Supply FlowCool Gas"
        Me.btnOpenCloseFlowCoolGas.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenCloseFlowCoolGas.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenCloseFlowCoolGas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenCloseFlowCoolGas.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOpenCloseFlowCoolGas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenCloseFlowCoolGas.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnOpenCloseFlowCoolGas.FlatAppearance.BorderSize = 0
        Me.btnOpenCloseFlowCoolGas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenCloseFlowCoolGas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenCloseFlowCoolGas.ForeColor = System.Drawing.Color.Black
        Me.btnOpenCloseFlowCoolGas.Location = New System.Drawing.Point(85, 47)
        Me.btnOpenCloseFlowCoolGas.MessageBoxText = Nothing
        Me.btnOpenCloseFlowCoolGas.Name = "btnOpenCloseFlowCoolGas"
        Me.btnOpenCloseFlowCoolGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenCloseFlowCoolGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOpenCloseFlowCoolGas.Size = New System.Drawing.Size(63, 30)
        Me.btnOpenCloseFlowCoolGas.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnOpenCloseFlowCoolGas.TabIndex = 223
        Me.btnOpenCloseFlowCoolGas.Text = "On/Off"
        Me.btnOpenCloseFlowCoolGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnOpenCloseFlowCoolGas.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnOpenCloseFlowCoolGas.UseClickedEventInForm = True
        Me.btnOpenCloseFlowCoolGas.UseVisualStyleBackColor = False
        Me.btnOpenCloseFlowCoolGas.ValueToBeSend = "On"
        Me.btnOpenCloseFlowCoolGas.Visible = False
        '
        'stTiltError
        '
        Me.stTiltError.DefaultImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.stTiltError.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.stTiltError.HomeImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.stTiltError.Location = New System.Drawing.Point(441, 306)
        Me.stTiltError.MovingImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.stTiltError.Name = "stTiltError"
        Me.stTiltError.Size = New System.Drawing.Size(15, 15)
        Me.stTiltError.Status = AVP_Robot_Project.FourStatusControl.DisplayStatus.[Default]
        Me.stTiltError.TabIndex = 69
        '
        'txtRotationSweepAngleReadback
        '
        Me.txtRotationSweepAngleReadback.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRotationSweepAngleReadback.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRotationSweepAngleReadback.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotationSweepAngleReadback.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtRotationSweepAngleReadback.IsNumericTextbox = True
        Me.txtRotationSweepAngleReadback.IsReadBack = True
        Me.txtRotationSweepAngleReadback.Location = New System.Drawing.Point(154, 133)
        Me.txtRotationSweepAngleReadback.MinimumValueHighlightedGreen = 0
        Me.txtRotationSweepAngleReadback.Name = "txtRotationSweepAngleReadback"
        Me.txtRotationSweepAngleReadback.ReadOnly = True
        Me.txtRotationSweepAngleReadback.Size = New System.Drawing.Size(100, 24)
        Me.txtRotationSweepAngleReadback.TabIndex = 224
        Me.txtRotationSweepAngleReadback.TabStop = False
        Me.txtRotationSweepAngleReadback.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRotationSweepAngleReadback.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtRotationSweepAngleReadback.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtRotationSweepAngleReadback.Visible = False
        '
        'stRotationError
        '
        Me.stRotationError.DefaultImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.stRotationError.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.stRotationError.HomeImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.stRotationError.Location = New System.Drawing.Point(441, 277)
        Me.stRotationError.MovingImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.stRotationError.Name = "stRotationError"
        Me.stRotationError.Size = New System.Drawing.Size(15, 15)
        Me.stRotationError.Status = AVP_Robot_Project.FourStatusControl.DisplayStatus.[Default]
        Me.stRotationError.TabIndex = 226
        '
        'txtTiltSweepRight
        '
        Me.txtTiltSweepRight.BackColor = System.Drawing.Color.White
        Me.txtTiltSweepRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTiltSweepRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTiltSweepRight.IsNumericTextbox = True
        Me.txtTiltSweepRight.Location = New System.Drawing.Point(229, 327)
        Me.txtTiltSweepRight.MinimumValueHighlightedGreen = 0
        Me.txtTiltSweepRight.Name = "txtTiltSweepRight"
        Me.txtTiltSweepRight.ReadOnly = True
        Me.txtTiltSweepRight.Size = New System.Drawing.Size(100, 24)
        Me.txtTiltSweepRight.TabIndex = 79
        Me.txtTiltSweepRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTiltSweepRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtTiltSweepRight.Visible = False
        '
        'txtTiltMode
        '
        Me.txtTiltMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTiltMode.Clickable = False
        Me.txtTiltMode.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTiltMode.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTiltMode.IsReadBack = True
        Me.txtTiltMode.Location = New System.Drawing.Point(335, 327)
        Me.txtTiltMode.MinimumValueHighlightedGreen = 0
        Me.txtTiltMode.Name = "txtTiltMode"
        Me.txtTiltMode.ReadOnly = True
        Me.txtTiltMode.Size = New System.Drawing.Size(100, 24)
        Me.txtTiltMode.TabIndex = 74
        Me.txtTiltMode.TabStop = False
        Me.txtTiltMode.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTiltMode.Visible = False
        '
        'txtTiltEnd
        '
        Me.txtTiltEnd.BackColor = System.Drawing.Color.White
        Me.txtTiltEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTiltEnd.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTiltEnd.IsNumericTextbox = True
        Me.txtTiltEnd.Location = New System.Drawing.Point(364, 105)
        Me.txtTiltEnd.MinimumValueHighlightedGreen = 0
        Me.txtTiltEnd.Name = "txtTiltEnd"
        Me.txtTiltEnd.ReadOnly = True
        Me.txtTiltEnd.Size = New System.Drawing.Size(100, 24)
        Me.txtTiltEnd.TabIndex = 77
        Me.txtTiltEnd.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTiltEnd.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtTiltEnd.Visible = False
        '
        'btnTilt
        '
        Me.btnTilt.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTilt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTilt.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTilt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTilt.Enabled = False
        Me.btnTilt.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTilt.FlatAppearance.BorderSize = 0
        Me.btnTilt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTilt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnTilt.ForeColor = System.Drawing.Color.Black
        Me.btnTilt.Location = New System.Drawing.Point(375, 33)
        Me.btnTilt.MessageBoxText = Nothing
        Me.btnTilt.Name = "btnTilt"
        Me.btnTilt.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTilt.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTilt.Size = New System.Drawing.Size(89, 27)
        Me.btnTilt.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnTilt.TabIndex = 230
        Me.btnTilt.Text = "Tilt Sweep"
        Me.btnTilt.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnTilt.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTilt.UseClickedEventInForm = True
        Me.btnTilt.UseVisualStyleBackColor = True
        Me.btnTilt.ValueToBeSend = "On"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(289, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 231
        Me.Label1.Text = "Start"
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnd.Location = New System.Drawing.Point(397, 86)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(35, 16)
        Me.lblEnd.TabIndex = 232
        Me.lblEnd.Text = "End"
        '
        'cbTiltMode
        '
        Me.cbTiltMode.AutoSize = True
        Me.cbTiltMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbTiltMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbTiltMode.Location = New System.Drawing.Point(18, 81)
        Me.cbTiltMode.Name = "cbTiltMode"
        Me.cbTiltMode.Size = New System.Drawing.Size(100, 20)
        Me.cbTiltMode.TabIndex = 233
        Me.cbTiltMode.Text = "Tilt Sweep"
        Me.cbTiltMode.UseVisualStyleBackColor = True
        '
        'lblHomeTilt
        '
        Me.lblHomeTilt.AutoSize = True
        Me.lblHomeTilt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHomeTilt.Location = New System.Drawing.Point(3, 111)
        Me.lblHomeTilt.Name = "lblHomeTilt"
        Me.lblHomeTilt.Size = New System.Drawing.Size(15, 13)
        Me.lblHomeTilt.TabIndex = 234
        Me.lblHomeTilt.Text = "H"
        '
        'lblHomeRotaion
        '
        Me.lblHomeRotaion.AutoSize = True
        Me.lblHomeRotaion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHomeRotaion.Location = New System.Drawing.Point(3, 139)
        Me.lblHomeRotaion.Name = "lblHomeRotaion"
        Me.lblHomeRotaion.Size = New System.Drawing.Size(15, 13)
        Me.lblHomeRotaion.TabIndex = 234
        Me.lblHomeRotaion.Text = "H"
        '
        'SL_Fixture
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lblHomeRotaion)
        Me.Controls.Add(Me.lblHomeTilt)
        Me.Controls.Add(Me.txtRotationStaticLeft)
        Me.Controls.Add(Me.txtRotationContinuousLeft)
        Me.Controls.Add(Me.txtRotationStaticRight)
        Me.Controls.Add(Me.txtTiltSweepRight)
        Me.Controls.Add(Me.txtRotationContinuousRight)
        Me.Controls.Add(Me.cbTiltMode)
        Me.Controls.Add(Me.txtTiltMode)
        Me.Controls.Add(Me.txtRotationSweepLeft)
        Me.Controls.Add(Me.lblEnd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnMode)
        Me.Controls.Add(Me.stRotationError)
        Me.Controls.Add(Me.btnTilt)
        Me.Controls.Add(Me.btnOpenCloseFlowCoolGas)
        Me.Controls.Add(Me.txtTiltEnd)
        Me.Controls.Add(Me.txtRotationSweepAngleReadback)
        Me.Controls.Add(Me.ImageBinaryStatusControl2)
        Me.Controls.Add(Me.txtFlowCoolGas)
        Me.Controls.Add(Me.txtFlowCoolGasRight)
        Me.Controls.Add(Me.txtTiltAngleRight)
        Me.Controls.Add(Me.txtRotationMode)
        Me.Controls.Add(Me.txtRotationEnd)
        Me.Controls.Add(Me.ValveSupplyFlowCoolGas)
        Me.Controls.Add(Me.txtRotationSweepRight)
        Me.Controls.Add(Me.txtTiltAngleLeft)
        Me.Controls.Add(Me.ValveShutoffFlowCoolGas)
        Me.Controls.Add(Me.ImageBinaryStatusControl1)
        Me.Controls.Add(Me.GasLine_FlowCool)
        Me.Controls.Add(Me.btnShutterOpen)
        Me.Controls.Add(Me.btnClampUp)
        Me.Controls.Add(Me.slMotionInitializingStatus)
        Me.Controls.Add(Me.btnMotionInitialized)
        Me.Controls.Add(Me.btnRotate)
        Me.Controls.Add(Me.btnFlowCoolPump)
        Me.Controls.Add(Me.btnShutterClose)
        Me.Controls.Add(Me.btnClampDown)
        Me.Controls.Add(Me.stTiltMoving)
        Me.Controls.Add(Me.stTiltError)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.stStartRotation)
        Me.Controls.Add(Me.stHomeRotation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.stHomeTilt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label19)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.HeaderText = "Fixture"
        Me.Name = "SL_Fixture"
        Me.Size = New System.Drawing.Size(789, 729)
        Me.Text = "Fixture"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.stHomeTilt, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.stHomeRotation, 0)
        Me.Controls.SetChildIndex(Me.stStartRotation, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.stTiltError, 0)
        Me.Controls.SetChildIndex(Me.stTiltMoving, 0)
        Me.Controls.SetChildIndex(Me.btnClampDown, 0)
        Me.Controls.SetChildIndex(Me.btnShutterClose, 0)
        Me.Controls.SetChildIndex(Me.btnFlowCoolPump, 0)
        Me.Controls.SetChildIndex(Me.btnRotate, 0)
        Me.Controls.SetChildIndex(Me.btnMotionInitialized, 0)
        Me.Controls.SetChildIndex(Me.slMotionInitializingStatus, 0)
        Me.Controls.SetChildIndex(Me.btnClampUp, 0)
        Me.Controls.SetChildIndex(Me.btnShutterOpen, 0)
        Me.Controls.SetChildIndex(Me.GasLine_FlowCool, 0)
        Me.Controls.SetChildIndex(Me.ImageBinaryStatusControl1, 0)
        Me.Controls.SetChildIndex(Me.ValveShutoffFlowCoolGas, 0)
        Me.Controls.SetChildIndex(Me.txtTiltAngleLeft, 0)
        Me.Controls.SetChildIndex(Me.txtRotationSweepRight, 0)
        Me.Controls.SetChildIndex(Me.ValveSupplyFlowCoolGas, 0)
        Me.Controls.SetChildIndex(Me.txtRotationEnd, 0)
        Me.Controls.SetChildIndex(Me.txtRotationMode, 0)
        Me.Controls.SetChildIndex(Me.txtTiltAngleRight, 0)
        Me.Controls.SetChildIndex(Me.txtFlowCoolGasRight, 0)
        Me.Controls.SetChildIndex(Me.txtFlowCoolGas, 0)
        Me.Controls.SetChildIndex(Me.ImageBinaryStatusControl2, 0)
        Me.Controls.SetChildIndex(Me.txtRotationSweepAngleReadback, 0)
        Me.Controls.SetChildIndex(Me.txtTiltEnd, 0)
        Me.Controls.SetChildIndex(Me.btnOpenCloseFlowCoolGas, 0)
        Me.Controls.SetChildIndex(Me.btnTilt, 0)
        Me.Controls.SetChildIndex(Me.stRotationError, 0)
        Me.Controls.SetChildIndex(Me.btnMode, 0)
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblEnd, 0)
        Me.Controls.SetChildIndex(Me.txtRotationSweepLeft, 0)
        Me.Controls.SetChildIndex(Me.txtTiltMode, 0)
        Me.Controls.SetChildIndex(Me.cbTiltMode, 0)
        Me.Controls.SetChildIndex(Me.txtRotationContinuousRight, 0)
        Me.Controls.SetChildIndex(Me.txtTiltSweepRight, 0)
        Me.Controls.SetChildIndex(Me.txtRotationStaticRight, 0)
        Me.Controls.SetChildIndex(Me.txtRotationContinuousLeft, 0)
        Me.Controls.SetChildIndex(Me.txtRotationStaticLeft, 0)
        Me.Controls.SetChildIndex(Me.lblHomeTilt, 0)
        Me.Controls.SetChildIndex(Me.lblHomeRotaion, 0)
        CType(Me.GasLine_FlowCool, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMode As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtTiltAngleRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTiltAngleLeft As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRotationMode As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtFlowCoolGas As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtFlowCoolGasRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents ValveSupplyFlowCoolGas As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveShutoffFlowCoolGas As AVP_Robot_Project.ValveControl
    Friend WithEvents GasLine_FlowCool As AVPControls.AnimationControl
    Friend WithEvents txtRotationStaticLeft As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRotationSweepLeft As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRotationContinuousLeft As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRotationStaticRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRotationSweepRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRotationContinuousRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents stHomeTilt As AVP_Robot_Project.SmallCircleControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents stHomeRotation As AVP_Robot_Project.SmallCircleControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents stStartRotation As AVP_Robot_Project.SmallCircleControl
    Friend WithEvents ImageBinaryStatusControl1 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents ImageBinaryStatusControl2 As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents txtRotationEnd As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnClampDown As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnClampUp As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnFlowCoolPump As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnRotate As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnShutterOpen As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnShutterClose As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnMotionInitialized As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents stTiltMoving As AVP_Robot_Project.SmallCircleControl
    Friend WithEvents slMotionInitializingStatus As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnOpenCloseFlowCoolGas As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents stTiltError As AVP_Robot_Project.SmallCircleControl
    Friend WithEvents txtRotationSweepAngleReadback As AVP_Robot_Project.SL_Textbox
    Friend WithEvents stRotationError As AVP_Robot_Project.SmallCircleControl
    Friend WithEvents txtTiltMode As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTiltEnd As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTiltSweepRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnTilt As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents cbTiltMode As System.Windows.Forms.CheckBox
    Friend WithEvents lblHomeTilt As System.Windows.Forms.Label
    Friend WithEvents lblHomeRotaion As System.Windows.Forms.Label

End Class
