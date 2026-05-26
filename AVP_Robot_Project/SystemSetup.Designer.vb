<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemSetup
    Inherits AVP_Robot_Project.PVDStatusPanel

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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Label37 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.tabSystem = New System.Windows.Forms.CustomTabControl
        Me.tabGeneralSetting = New System.Windows.Forms.TabPage
        Me.pnlGeneralSetting = New System.Windows.Forms.Panel
        Me.gbxDegasWaitTime = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtSystemCleanUpDataRunTimeInDays = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtInfoName = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.btnArchiveNow = New System.Windows.Forms.Button
        Me.btnApplyGeneralSetting = New System.Windows.Forms.Button
        Me.cbxEnableQuickSequenceEditor = New System.Windows.Forms.CheckBox
        Me.lblAutoArchiveStatus = New System.Windows.Forms.Label
        Me.cbxAllowCheckingECCLimit = New System.Windows.Forms.CheckBox
        Me.cbAutoArchiveSystemConfigFile = New System.Windows.Forms.CheckBox
        Me.txtArchiveConfigFile = New System.Windows.Forms.TextBox
        Me.cbxManualDefineGEMWaferID = New System.Windows.Forms.CheckBox
        Me.btnArchiveConfigFile = New System.Windows.Forms.Button
        Me.txtDeltaPickECCLimits = New System.Windows.Forms.TextBox
        Me.cbAutoVentWhenProcessCompleted = New System.Windows.Forms.CheckBox
        Me.grpResetScheduler = New System.Windows.Forms.GroupBox
        Me.btnResetLLAScheduler = New System.Windows.Forms.Button
        Me.tabPressureSetpoint = New System.Windows.Forms.TabPage
        Me.pnlPressureSetPoint = New System.Windows.Forms.Panel
        Me.gbxPressure = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtEtchRatePM2 = New System.Windows.Forms.TextBox
        Me.txtEtchRatePM3 = New System.Windows.Forms.TextBox
        Me.txtEtchRatePM1 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtRateOfRiseVolTM = New System.Windows.Forms.TextBox
        Me.txtRateOfRiseVolLLA = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblLLAForelineCG = New System.Windows.Forms.Label
        Me.lblTMForelineCG = New System.Windows.Forms.Label
        Me.lblMPPressure = New System.Windows.Forms.Label
        Me.txtLLAForelineCGTripPoint = New System.Windows.Forms.TextBox
        Me.txtTMForelineCGTripPoint = New System.Windows.Forms.TextBox
        Me.txtMPCGTripPoint = New System.Windows.Forms.TextBox
        Me.txtTMCGTripPoint = New System.Windows.Forms.TextBox
        Me.txtLLACGTripPoint = New System.Windows.Forms.TextBox
        Me.lbCGTripPoint = New System.Windows.Forms.Label
        Me.txtTransferPM3 = New System.Windows.Forms.TextBox
        Me.txtTransferPM2 = New System.Windows.Forms.TextBox
        Me.txtTransferPM1 = New System.Windows.Forms.TextBox
        Me.txtSlowVentLLA = New System.Windows.Forms.TextBox
        Me.txtSlowRoughLLA = New System.Windows.Forms.TextBox
        Me.txtCrossOverTM = New System.Windows.Forms.TextBox
        Me.txtCrossOverLLA = New System.Windows.Forms.TextBox
        Me.txtTransferTM = New System.Windows.Forms.TextBox
        Me.txtTransferLLA = New System.Windows.Forms.TextBox
        Me.txtVentTM = New System.Windows.Forms.TextBox
        Me.txtVentLLA = New System.Windows.Forms.TextBox
        Me.lblSlowVent = New System.Windows.Forms.Label
        Me.lblSlowRough = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblTMPressure = New System.Windows.Forms.Label
        Me.lblPM3Pressure = New System.Windows.Forms.Label
        Me.lblLLAPressure = New System.Windows.Forms.Label
        Me.lblPM2Pressure = New System.Windows.Forms.Label
        Me.lblPM1Pressure = New System.Windows.Forms.Label
        Me.gbxRegenHourLimit = New System.Windows.Forms.GroupBox
        Me.txtCryoPumpHour = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbxCGTransferDiff = New System.Windows.Forms.GroupBox
        Me.txtCGDifferentialPercent = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnApplyPressureSetpoint = New System.Windows.Forms.Button
        Me.tabElevatorSetting = New System.Windows.Forms.TabPage
        Me.pnlElevatorSetting = New System.Windows.Forms.Panel
        Me.gbxRobot = New System.Windows.Forms.GroupBox
        Me.txtApplyStatus = New System.Windows.Forms.TextBox
        Me.txtRobotVersion = New System.Windows.Forms.TextBox
        Me.btnRequestRobotInfo = New System.Windows.Forms.Button
        Me.RobotConfig = New AVPControls.RobotConfigPanel
        Me.btnLoadConfigRobot = New System.Windows.Forms.Button
        Me.btnStoreConfigRobot = New System.Windows.Forms.Button
        Me.gbxLLASetting = New System.Windows.Forms.GroupBox
        Me.btnLoadConfigLLA = New System.Windows.Forms.Button
        Me.btnStoreConfigLLA = New System.Windows.Forms.Button
        Me.txtFindBiasLLA = New System.Windows.Forms.TextBox
        Me.txtBaseOffsetLLA = New System.Windows.Forms.TextBox
        Me.txtPitchLLA = New System.Windows.Forms.TextBox
        Me.txtTravelLengthLLA = New System.Windows.Forms.TextBox
        Me.txtNumberOfSlotsLLA = New System.Windows.Forms.TextBox
        Me.Label69 = New System.Windows.Forms.Label
        Me.Label70 = New System.Windows.Forms.Label
        Me.Label66 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.Label68 = New System.Windows.Forms.Label
        Me.btnCancelElevatorSetting = New System.Windows.Forms.Button
        Me.btnApplyElevatorSetting = New System.Windows.Forms.Button
        Me.TabTargetKwh = New System.Windows.Forms.TabPage
        Me.pnlKWH = New System.Windows.Forms.Panel
        Me.grboxModuleName = New System.Windows.Forms.GroupBox
        Me.txtModuleNamePM1 = New System.Windows.Forms.TextBox
        Me.txtModuleNamePM2 = New System.Windows.Forms.TextBox
        Me.txtModuleNamePM3 = New System.Windows.Forms.TextBox
        Me.gbxLifetimeWafer = New System.Windows.Forms.GroupBox
        Me.txtLifeTimeWafer = New System.Windows.Forms.TextBox
        Me.gbxShieldsQuartz = New System.Windows.Forms.GroupBox
        Me.lblPM3_ShQuUnit = New System.Windows.Forms.Label
        Me.lblPM2_ShQuUnit = New System.Windows.Forms.Label
        Me.lblPM1_ShQuUnit = New System.Windows.Forms.Label
        Me.txtShieldsPM3 = New System.Windows.Forms.TextBox
        Me.txtShieldsPM2 = New System.Windows.Forms.TextBox
        Me.txtShieldPM1 = New System.Windows.Forms.TextBox
        Me.lblPM3Type2 = New System.Windows.Forms.Label
        Me.lblPM2Type2 = New System.Windows.Forms.Label
        Me.lblPM1Type2 = New System.Windows.Forms.Label
        Me.lblMaxShields = New System.Windows.Forms.Label
        Me.lblWarningShields = New System.Windows.Forms.Label
        Me.lblLimitsShields = New System.Windows.Forms.Label
        Me.txtMaxShieldsPM3 = New System.Windows.Forms.TextBox
        Me.txtMaxShieldsPM2 = New System.Windows.Forms.TextBox
        Me.txtMaxShieldsPM1 = New System.Windows.Forms.TextBox
        Me.txtWarningShieldsPM3 = New System.Windows.Forms.TextBox
        Me.txtWarningShieldsPM2 = New System.Windows.Forms.TextBox
        Me.txtWarningShieldsPM1 = New System.Windows.Forms.TextBox
        Me.txtLimitShieldsPM3 = New System.Windows.Forms.TextBox
        Me.txtLimitShieldsPM2 = New System.Windows.Forms.TextBox
        Me.txtLimitShieldsPM1 = New System.Windows.Forms.TextBox
        Me.lblPM3Shields = New System.Windows.Forms.Label
        Me.lblPM2Shields = New System.Windows.Forms.Label
        Me.lblPM1Shields = New System.Windows.Forms.Label
        Me.gbxUsage = New System.Windows.Forms.GroupBox
        Me.lblPM3_UsageUnit = New System.Windows.Forms.Label
        Me.lblPM2_UsageUnit = New System.Windows.Forms.Label
        Me.lblPM1_UsageUnit = New System.Windows.Forms.Label
        Me.txtMaxKWHPM3 = New System.Windows.Forms.TextBox
        Me.txtMaxKWHPM2 = New System.Windows.Forms.TextBox
        Me.txtMaxKWHPM1 = New System.Windows.Forms.TextBox
        Me.txtWarningKWH_PM3 = New System.Windows.Forms.TextBox
        Me.txtWarningKWH_PM2 = New System.Windows.Forms.TextBox
        Me.txtWarningKWH_PM1 = New System.Windows.Forms.TextBox
        Me.txtLimitsKWH_PM3 = New System.Windows.Forms.TextBox
        Me.txtLimitsKWH_PM2 = New System.Windows.Forms.TextBox
        Me.txtLimitsKWH_PM1 = New System.Windows.Forms.TextBox
        Me.txtUsageKWH_PM3 = New System.Windows.Forms.TextBox
        Me.txtUsageKWH_PM2 = New System.Windows.Forms.TextBox
        Me.txtUsageKWH_PM1 = New System.Windows.Forms.TextBox
        Me.lblPM3Type1 = New System.Windows.Forms.Label
        Me.gbxWaferCounts = New System.Windows.Forms.GroupBox
        Me.txtWaferCountPM2 = New System.Windows.Forms.TextBox
        Me.txtWaferCountPM3 = New System.Windows.Forms.TextBox
        Me.txtWaferCountPM1 = New System.Windows.Forms.TextBox
        Me.lblWaferCounts = New System.Windows.Forms.Label
        Me.lblPM2Type1 = New System.Windows.Forms.Label
        Me.lblPM1Type1 = New System.Windows.Forms.Label
        Me.gbxTargetMaterial = New System.Windows.Forms.GroupBox
        Me.txtTarMaterialPM3 = New System.Windows.Forms.TextBox
        Me.txtTarMaterialPM2 = New System.Windows.Forms.TextBox
        Me.txtTarMaterialPM1 = New System.Windows.Forms.TextBox
        Me.lblTargetMaterial = New System.Windows.Forms.Label
        Me.lblMaxUsage = New System.Windows.Forms.Label
        Me.lblWarningUsage = New System.Windows.Forms.Label
        Me.lblLimitsUsage = New System.Windows.Forms.Label
        Me.lblPM3 = New System.Windows.Forms.Label
        Me.lblPM2 = New System.Windows.Forms.Label
        Me.lblPM1 = New System.Windows.Forms.Label
        Me.gbxCalculationType = New System.Windows.Forms.GroupBox
        Me.rbUseMaxKWH = New System.Windows.Forms.RadioButton
        Me.rbUseAbsoluteKWH = New System.Windows.Forms.RadioButton
        Me.tabTimeOut = New System.Windows.Forms.TabPage
        Me.pnlTimeOut = New System.Windows.Forms.Panel
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txtTransferSetPointWaitTimeInSeconds = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtAutoLog = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.btnApplyTimeOut = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtDegasWaitTimeLLA = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtLLContinueVent = New System.Windows.Forms.TextBox
        Me.txtLLDelayTimeTurnOnIG = New System.Windows.Forms.TextBox
        Me.txtLLVentValveTO = New System.Windows.Forms.TextBox
        Me.txtLLContinuePumpDown = New System.Windows.Forms.TextBox
        Me.txtLLRoughValveTO = New System.Windows.Forms.TextBox
        Me.txtLLAFastVentTO = New System.Windows.Forms.TextBox
        Me.txtLLAFastRoughTO = New System.Windows.Forms.TextBox
        Me.txtLLASlowVentTO = New System.Windows.Forms.TextBox
        Me.txtLLASlowRoughTO = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtDegasWaitTimeTM = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTMDelayTimeTurnOnIG = New System.Windows.Forms.TextBox
        Me.txtTMVentValveTO = New System.Windows.Forms.TextBox
        Me.txtTMContinuePumpDown = New System.Windows.Forms.TextBox
        Me.txtTMContinueVent = New System.Windows.Forms.TextBox
        Me.txtTMRoughTO = New System.Windows.Forms.TextBox
        Me.txtTMVentTO = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtHivacTO = New System.Windows.Forms.TextBox
        Me.txtIGOnOffTO = New System.Windows.Forms.TextBox
        Me.txtMesaValveTO = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSystemCheckSensor = New System.Windows.Forms.TextBox
        Me.Label59 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.tabAutoSendMail = New System.Windows.Forms.TabPage
        Me.pnlEmailAlert = New System.Windows.Forms.Panel
        Me.btnApplyEmailSetting = New System.Windows.Forms.Button
        Me.chkAutoSendEmail = New System.Windows.Forms.CheckBox
        Me.gbAccountInfomation = New System.Windows.Forms.GroupBox
        Me.btnCustomEmailMessage = New System.Windows.Forms.Button
        Me.btnAddNewEmail = New System.Windows.Forms.Button
        Me.pnlEmail = New System.Windows.Forms.Panel
        Me.dgvEmailUser = New System.Windows.Forms.DataGridView
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.btnTestingSetup = New System.Windows.Forms.Button
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.txtSMTPServer = New System.Windows.Forms.TextBox
        Me.Label65 = New System.Windows.Forms.Label
        Me.Label76 = New System.Windows.Forms.Label
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtDelayTimeAfterProcessComplete = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSystem.SuspendLayout()
        Me.tabGeneralSetting.SuspendLayout()
        Me.pnlGeneralSetting.SuspendLayout()
        Me.gbxDegasWaitTime.SuspendLayout()
        Me.grpResetScheduler.SuspendLayout()
        Me.tabPressureSetpoint.SuspendLayout()
        Me.pnlPressureSetPoint.SuspendLayout()
        Me.gbxPressure.SuspendLayout()
        Me.gbxRegenHourLimit.SuspendLayout()
        Me.gbxCGTransferDiff.SuspendLayout()
        Me.tabElevatorSetting.SuspendLayout()
        Me.pnlElevatorSetting.SuspendLayout()
        Me.gbxRobot.SuspendLayout()
        Me.gbxLLASetting.SuspendLayout()
        Me.TabTargetKwh.SuspendLayout()
        Me.pnlKWH.SuspendLayout()
        Me.grboxModuleName.SuspendLayout()
        Me.gbxLifetimeWafer.SuspendLayout()
        Me.gbxShieldsQuartz.SuspendLayout()
        Me.gbxUsage.SuspendLayout()
        Me.gbxWaferCounts.SuspendLayout()
        Me.gbxTargetMaterial.SuspendLayout()
        Me.gbxCalculationType.SuspendLayout()
        Me.tabTimeOut.SuspendLayout()
        Me.pnlTimeOut.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabAutoSendMail.SuspendLayout()
        Me.pnlEmailAlert.SuspendLayout()
        Me.gbAccountInfomation.SuspendLayout()
        Me.pnlEmail.SuspendLayout()
        CType(Me.dgvEmailUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(468, 175)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(36, 19)
        Me.Label31.TabIndex = 30
        Me.Label31.Text = "torr"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(468, 126)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(36, 19)
        Me.Label32.TabIndex = 29
        Me.Label32.Text = "torr"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(468, 77)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(36, 19)
        Me.Label33.TabIndex = 28
        Me.Label33.Text = "torr"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(468, 28)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 19)
        Me.Label34.TabIndex = 27
        Me.Label34.Text = "torr"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(279, 119)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(179, 26)
        Me.NumericUpDown1.TabIndex = 4
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(58, 28)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(195, 19)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "Mechanical Pump CG (1)"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(280, 282)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(179, 49)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Apply"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(58, 77)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(141, 19)
        Me.Label38.TabIndex = 0
        Me.Label38.Text = "Load Lock CG (1)"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(58, 126)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(195, 19)
        Me.Label39.TabIndex = 3
        Me.Label39.Text = "Mechanical Pump CG (2)"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.TextBox1.Location = New System.Drawing.Point(279, 217)
        Me.TextBox1.MaxLength = 10
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(179, 26)
        Me.TextBox1.TabIndex = 26
        Me.TextBox1.Text = "0"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.TextBox2.Location = New System.Drawing.Point(279, 168)
        Me.TextBox2.MaxLength = 10
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(179, 26)
        Me.TextBox2.TabIndex = 26
        Me.TextBox2.Text = "0"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(58, 175)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(141, 19)
        Me.Label40.TabIndex = 3
        Me.Label40.Text = "Load Lock CG (2)"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.TextBox3.Location = New System.Drawing.Point(279, 70)
        Me.TextBox3.MaxLength = 10
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(179, 26)
        Me.TextBox3.TabIndex = 26
        Me.TextBox3.Text = "0"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(58, 224)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(152, 19)
        Me.Label41.TabIndex = 6
        Me.Label41.Text = "Cryo Pressure (T2)"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.TextBox4.Location = New System.Drawing.Point(279, 21)
        Me.TextBox4.MaxLength = 10
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(179, 26)
        Me.TextBox4.TabIndex = 26
        Me.TextBox4.Text = "0"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(468, 221)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(21, 19)
        Me.Label42.TabIndex = 6
        Me.Label42.Text = "K"
        '
        'tabSystem
        '
        Me.tabSystem.Controls.Add(Me.tabGeneralSetting)
        Me.tabSystem.Controls.Add(Me.tabPressureSetpoint)
        Me.tabSystem.Controls.Add(Me.tabElevatorSetting)
        Me.tabSystem.Controls.Add(Me.TabTargetKwh)
        Me.tabSystem.Controls.Add(Me.tabTimeOut)
        Me.tabSystem.Controls.Add(Me.tabAutoSendMail)
        Me.tabSystem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabSystem.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabSystem.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabSystem.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlText
        Me.tabSystem.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabSystem.DisplayStyleProvider.FocusTrack = False
        Me.tabSystem.DisplayStyleProvider.HotTrack = True
        Me.tabSystem.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabSystem.DisplayStyleProvider.Opacity = 1.0!
        Me.tabSystem.DisplayStyleProvider.Overlap = 0
        Me.tabSystem.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabSystem.DisplayStyleProvider.Radius = 10
        Me.tabSystem.DisplayStyleProvider.ShowTabCloser = False
        Me.tabSystem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabSystem.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSystem.HotTrack = True
        Me.tabSystem.ItemSize = New System.Drawing.Size(200, 24)
        Me.tabSystem.Location = New System.Drawing.Point(0, 0)
        Me.tabSystem.Name = "tabSystem"
        Me.tabSystem.SelectedIndex = 0
        Me.tabSystem.Size = New System.Drawing.Size(1280, 756)
        Me.tabSystem.TabIndex = 27
        '
        'tabGeneralSetting
        '
        Me.tabGeneralSetting.Controls.Add(Me.pnlGeneralSetting)
        Me.tabGeneralSetting.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabGeneralSetting.Location = New System.Drawing.Point(0, 29)
        Me.tabGeneralSetting.Name = "tabGeneralSetting"
        Me.tabGeneralSetting.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGeneralSetting.Size = New System.Drawing.Size(1280, 727)
        Me.tabGeneralSetting.TabIndex = 7
        Me.tabGeneralSetting.Text = "General Setting"
        Me.tabGeneralSetting.UseVisualStyleBackColor = True
        '
        'pnlGeneralSetting
        '
        Me.pnlGeneralSetting.Controls.Add(Me.gbxDegasWaitTime)
        Me.pnlGeneralSetting.Controls.Add(Me.grpResetScheduler)
        Me.pnlGeneralSetting.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlGeneralSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGeneralSetting.Location = New System.Drawing.Point(3, 3)
        Me.pnlGeneralSetting.Name = "pnlGeneralSetting"
        Me.pnlGeneralSetting.Size = New System.Drawing.Size(1274, 721)
        Me.pnlGeneralSetting.TabIndex = 35
        '
        'gbxDegasWaitTime
        '
        Me.gbxDegasWaitTime.Controls.Add(Me.txtDelayTimeAfterProcessComplete)
        Me.gbxDegasWaitTime.Controls.Add(Me.Label22)
        Me.gbxDegasWaitTime.Controls.Add(Me.Label19)
        Me.gbxDegasWaitTime.Controls.Add(Me.txtSystemCleanUpDataRunTimeInDays)
        Me.gbxDegasWaitTime.Controls.Add(Me.Label15)
        Me.gbxDegasWaitTime.Controls.Add(Me.txtInfoName)
        Me.gbxDegasWaitTime.Controls.Add(Me.Label27)
        Me.gbxDegasWaitTime.Controls.Add(Me.btnArchiveNow)
        Me.gbxDegasWaitTime.Controls.Add(Me.btnApplyGeneralSetting)
        Me.gbxDegasWaitTime.Controls.Add(Me.cbxEnableQuickSequenceEditor)
        Me.gbxDegasWaitTime.Controls.Add(Me.lblAutoArchiveStatus)
        Me.gbxDegasWaitTime.Controls.Add(Me.cbxAllowCheckingECCLimit)
        Me.gbxDegasWaitTime.Controls.Add(Me.cbAutoArchiveSystemConfigFile)
        Me.gbxDegasWaitTime.Controls.Add(Me.txtArchiveConfigFile)
        Me.gbxDegasWaitTime.Controls.Add(Me.cbxManualDefineGEMWaferID)
        Me.gbxDegasWaitTime.Controls.Add(Me.btnArchiveConfigFile)
        Me.gbxDegasWaitTime.Controls.Add(Me.txtDeltaPickECCLimits)
        Me.gbxDegasWaitTime.Controls.Add(Me.cbAutoVentWhenProcessCompleted)
        Me.gbxDegasWaitTime.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxDegasWaitTime.Location = New System.Drawing.Point(8, 19)
        Me.gbxDegasWaitTime.Name = "gbxDegasWaitTime"
        Me.gbxDegasWaitTime.Size = New System.Drawing.Size(1255, 484)
        Me.gbxDegasWaitTime.TabIndex = 50
        Me.gbxDegasWaitTime.TabStop = False
        Me.gbxDegasWaitTime.Text = "General Setting"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(389, 345)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(37, 17)
        Me.Label19.TabIndex = 68
        Me.Label19.Text = "days"
        '
        'txtSystemCleanUpDataRunTimeInDays
        '
        Me.txtSystemCleanUpDataRunTimeInDays.AccessibleDescription = "System Clean Up Data Run Time In Days"
        Me.txtSystemCleanUpDataRunTimeInDays.AccessibleName = "SystemCleanUpDataRunTimeInDays"
        Me.txtSystemCleanUpDataRunTimeInDays.BackColor = System.Drawing.SystemColors.Window
        Me.txtSystemCleanUpDataRunTimeInDays.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSystemCleanUpDataRunTimeInDays.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSystemCleanUpDataRunTimeInDays.Location = New System.Drawing.Point(296, 341)
        Me.txtSystemCleanUpDataRunTimeInDays.Name = "txtSystemCleanUpDataRunTimeInDays"
        Me.txtSystemCleanUpDataRunTimeInDays.Size = New System.Drawing.Size(85, 25)
        Me.txtSystemCleanUpDataRunTimeInDays.TabIndex = 67
        Me.txtSystemCleanUpDataRunTimeInDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 345)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(276, 17)
        Me.Label15.TabIndex = 66
        Me.Label15.Text = "Auto Purge Archive/DataRun Files After "
        '
        'txtInfoName
        '
        Me.txtInfoName.AccessibleDescription = ""
        Me.txtInfoName.BackColor = System.Drawing.SystemColors.Window
        Me.txtInfoName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtInfoName.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtInfoName.Location = New System.Drawing.Point(192, 50)
        Me.txtInfoName.Name = "txtInfoName"
        Me.txtInfoName.ReadOnly = True
        Me.txtInfoName.Size = New System.Drawing.Size(377, 25)
        Me.txtInfoName.TabIndex = 54
        Me.txtInfoName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(14, 54)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(101, 17)
        Me.Label27.TabIndex = 53
        Me.Label27.Text = "System Name "
        '
        'btnArchiveNow
        '
        Me.btnArchiveNow.BackColor = System.Drawing.SystemColors.Info
        Me.btnArchiveNow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnArchiveNow.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchiveNow.Location = New System.Drawing.Point(13, 293)
        Me.btnArchiveNow.Name = "btnArchiveNow"
        Me.btnArchiveNow.Size = New System.Drawing.Size(119, 37)
        Me.btnArchiveNow.TabIndex = 50
        Me.btnArchiveNow.Text = "Archive Now"
        Me.btnArchiveNow.UseVisualStyleBackColor = False
        '
        'btnApplyGeneralSetting
        '
        Me.btnApplyGeneralSetting.BackColor = System.Drawing.SystemColors.Info
        Me.btnApplyGeneralSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplyGeneralSetting.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApplyGeneralSetting.Location = New System.Drawing.Point(470, 394)
        Me.btnApplyGeneralSetting.Name = "btnApplyGeneralSetting"
        Me.btnApplyGeneralSetting.Size = New System.Drawing.Size(179, 51)
        Me.btnApplyGeneralSetting.TabIndex = 26
        Me.btnApplyGeneralSetting.Text = "Apply"
        Me.btnApplyGeneralSetting.UseVisualStyleBackColor = False
        '
        'cbxEnableQuickSequenceEditor
        '
        Me.cbxEnableQuickSequenceEditor.AccessibleDescription = ""
        Me.cbxEnableQuickSequenceEditor.AutoSize = True
        Me.cbxEnableQuickSequenceEditor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbxEnableQuickSequenceEditor.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbxEnableQuickSequenceEditor.Location = New System.Drawing.Point(14, 222)
        Me.cbxEnableQuickSequenceEditor.Name = "cbxEnableQuickSequenceEditor"
        Me.cbxEnableQuickSequenceEditor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbxEnableQuickSequenceEditor.Size = New System.Drawing.Size(228, 21)
        Me.cbxEnableQuickSequenceEditor.TabIndex = 48
        Me.cbxEnableQuickSequenceEditor.Text = "Enable Quick Sequence Editor"
        Me.cbxEnableQuickSequenceEditor.UseVisualStyleBackColor = True
        '
        'lblAutoArchiveStatus
        '
        Me.lblAutoArchiveStatus.AutoSize = True
        Me.lblAutoArchiveStatus.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutoArchiveStatus.Location = New System.Drawing.Point(189, 261)
        Me.lblAutoArchiveStatus.Name = "lblAutoArchiveStatus"
        Me.lblAutoArchiveStatus.Size = New System.Drawing.Size(104, 17)
        Me.lblAutoArchiveStatus.TabIndex = 47
        Me.lblAutoArchiveStatus.Text = "Archive Status"
        '
        'cbxAllowCheckingECCLimit
        '
        Me.cbxAllowCheckingECCLimit.AccessibleDescription = "Delta Pick ECC Limits"
        Me.cbxAllowCheckingECCLimit.AutoSize = True
        Me.cbxAllowCheckingECCLimit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbxAllowCheckingECCLimit.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbxAllowCheckingECCLimit.Location = New System.Drawing.Point(14, 93)
        Me.cbxAllowCheckingECCLimit.Name = "cbxAllowCheckingECCLimit"
        Me.cbxAllowCheckingECCLimit.Size = New System.Drawing.Size(177, 21)
        Me.cbxAllowCheckingECCLimit.TabIndex = 46
        Me.cbxAllowCheckingECCLimit.Text = "Delta Pick ECC Limits"
        Me.cbxAllowCheckingECCLimit.UseVisualStyleBackColor = True
        '
        'cbAutoArchiveSystemConfigFile
        '
        Me.cbAutoArchiveSystemConfigFile.AutoSize = True
        Me.cbAutoArchiveSystemConfigFile.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbAutoArchiveSystemConfigFile.Location = New System.Drawing.Point(14, 259)
        Me.cbAutoArchiveSystemConfigFile.Name = "cbAutoArchiveSystemConfigFile"
        Me.cbAutoArchiveSystemConfigFile.Size = New System.Drawing.Size(114, 21)
        Me.cbAutoArchiveSystemConfigFile.TabIndex = 0
        Me.cbAutoArchiveSystemConfigFile.Text = "Auto Archive"
        Me.cbAutoArchiveSystemConfigFile.UseVisualStyleBackColor = True
        '
        'txtArchiveConfigFile
        '
        Me.txtArchiveConfigFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtArchiveConfigFile.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchiveConfigFile.Location = New System.Drawing.Point(189, 299)
        Me.txtArchiveConfigFile.Name = "txtArchiveConfigFile"
        Me.txtArchiveConfigFile.ReadOnly = True
        Me.txtArchiveConfigFile.Size = New System.Drawing.Size(394, 25)
        Me.txtArchiveConfigFile.TabIndex = 48
        '
        'cbxManualDefineGEMWaferID
        '
        Me.cbxManualDefineGEMWaferID.AccessibleDescription = "Support User Define Wafer ID"
        Me.cbxManualDefineGEMWaferID.AutoSize = True
        Me.cbxManualDefineGEMWaferID.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbxManualDefineGEMWaferID.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbxManualDefineGEMWaferID.Location = New System.Drawing.Point(14, 179)
        Me.cbxManualDefineGEMWaferID.Name = "cbxManualDefineGEMWaferID"
        Me.cbxManualDefineGEMWaferID.Size = New System.Drawing.Size(224, 21)
        Me.cbxManualDefineGEMWaferID.TabIndex = 47
        Me.cbxManualDefineGEMWaferID.Text = "Support User Define Wafer ID"
        Me.cbxManualDefineGEMWaferID.UseVisualStyleBackColor = True
        '
        'btnArchiveConfigFile
        '
        Me.btnArchiveConfigFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnArchiveConfigFile.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchiveConfigFile.Location = New System.Drawing.Point(588, 299)
        Me.btnArchiveConfigFile.Name = "btnArchiveConfigFile"
        Me.btnArchiveConfigFile.Size = New System.Drawing.Size(74, 25)
        Me.btnArchiveConfigFile.TabIndex = 49
        Me.btnArchiveConfigFile.Text = "Browser"
        Me.btnArchiveConfigFile.UseVisualStyleBackColor = True
        '
        'txtDeltaPickECCLimits
        '
        Me.txtDeltaPickECCLimits.AccessibleDescription = "Delta Pick ECC Limits Time"
        Me.txtDeltaPickECCLimits.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeltaPickECCLimits.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtDeltaPickECCLimits.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtDeltaPickECCLimits.Location = New System.Drawing.Point(192, 91)
        Me.txtDeltaPickECCLimits.Name = "txtDeltaPickECCLimits"
        Me.txtDeltaPickECCLimits.ReadOnly = True
        Me.txtDeltaPickECCLimits.Size = New System.Drawing.Size(377, 25)
        Me.txtDeltaPickECCLimits.TabIndex = 45
        Me.txtDeltaPickECCLimits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbAutoVentWhenProcessCompleted
        '
        Me.cbAutoVentWhenProcessCompleted.AutoSize = True
        Me.cbAutoVentWhenProcessCompleted.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbAutoVentWhenProcessCompleted.Location = New System.Drawing.Point(14, 136)
        Me.cbAutoVentWhenProcessCompleted.Name = "cbAutoVentWhenProcessCompleted"
        Me.cbAutoVentWhenProcessCompleted.Size = New System.Drawing.Size(358, 21)
        Me.cbAutoVentWhenProcessCompleted.TabIndex = 0
        Me.cbAutoVentWhenProcessCompleted.Text = "Auto Vent LoadLock When Processing Completed"
        Me.cbAutoVentWhenProcessCompleted.UseVisualStyleBackColor = True
        '
        'grpResetScheduler
        '
        Me.grpResetScheduler.Controls.Add(Me.btnResetLLAScheduler)
        Me.grpResetScheduler.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.grpResetScheduler.Location = New System.Drawing.Point(8, 521)
        Me.grpResetScheduler.Name = "grpResetScheduler"
        Me.grpResetScheduler.Size = New System.Drawing.Size(1255, 144)
        Me.grpResetScheduler.TabIndex = 47
        Me.grpResetScheduler.TabStop = False
        Me.grpResetScheduler.Text = "Admin Reset Scheduler"
        Me.grpResetScheduler.Visible = False
        '
        'btnResetLLAScheduler
        '
        Me.btnResetLLAScheduler.BackColor = System.Drawing.SystemColors.Info
        Me.btnResetLLAScheduler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResetLLAScheduler.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetLLAScheduler.Location = New System.Drawing.Point(472, 52)
        Me.btnResetLLAScheduler.Name = "btnResetLLAScheduler"
        Me.btnResetLLAScheduler.Size = New System.Drawing.Size(179, 56)
        Me.btnResetLLAScheduler.TabIndex = 26
        Me.btnResetLLAScheduler.Text = "Admin Reset Scheduler LLA"
        Me.btnResetLLAScheduler.UseVisualStyleBackColor = False
        '
        'tabPressureSetpoint
        '
        Me.tabPressureSetpoint.BackColor = System.Drawing.Color.Transparent
        Me.tabPressureSetpoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabPressureSetpoint.Controls.Add(Me.pnlPressureSetPoint)
        Me.tabPressureSetpoint.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPressureSetpoint.Location = New System.Drawing.Point(0, 29)
        Me.tabPressureSetpoint.Name = "tabPressureSetpoint"
        Me.tabPressureSetpoint.Size = New System.Drawing.Size(1280, 727)
        Me.tabPressureSetpoint.TabIndex = 4
        Me.tabPressureSetpoint.Text = "Pressure Setpoint "
        Me.tabPressureSetpoint.UseVisualStyleBackColor = True
        '
        'pnlPressureSetPoint
        '
        Me.pnlPressureSetPoint.Controls.Add(Me.gbxPressure)
        Me.pnlPressureSetPoint.Controls.Add(Me.gbxRegenHourLimit)
        Me.pnlPressureSetPoint.Controls.Add(Me.gbxCGTransferDiff)
        Me.pnlPressureSetPoint.Controls.Add(Me.btnApplyPressureSetpoint)
        Me.pnlPressureSetPoint.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlPressureSetPoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPressureSetPoint.Location = New System.Drawing.Point(0, 0)
        Me.pnlPressureSetPoint.Name = "pnlPressureSetPoint"
        Me.pnlPressureSetPoint.Size = New System.Drawing.Size(1280, 727)
        Me.pnlPressureSetPoint.TabIndex = 44
        '
        'gbxPressure
        '
        Me.gbxPressure.Controls.Add(Me.Label14)
        Me.gbxPressure.Controls.Add(Me.txtEtchRatePM2)
        Me.gbxPressure.Controls.Add(Me.txtEtchRatePM3)
        Me.gbxPressure.Controls.Add(Me.txtEtchRatePM1)
        Me.gbxPressure.Controls.Add(Me.Label13)
        Me.gbxPressure.Controls.Add(Me.txtRateOfRiseVolTM)
        Me.gbxPressure.Controls.Add(Me.txtRateOfRiseVolLLA)
        Me.gbxPressure.Controls.Add(Me.Label7)
        Me.gbxPressure.Controls.Add(Me.lblLLAForelineCG)
        Me.gbxPressure.Controls.Add(Me.lblTMForelineCG)
        Me.gbxPressure.Controls.Add(Me.lblMPPressure)
        Me.gbxPressure.Controls.Add(Me.txtLLAForelineCGTripPoint)
        Me.gbxPressure.Controls.Add(Me.txtTMForelineCGTripPoint)
        Me.gbxPressure.Controls.Add(Me.txtMPCGTripPoint)
        Me.gbxPressure.Controls.Add(Me.txtTMCGTripPoint)
        Me.gbxPressure.Controls.Add(Me.txtLLACGTripPoint)
        Me.gbxPressure.Controls.Add(Me.lbCGTripPoint)
        Me.gbxPressure.Controls.Add(Me.txtTransferPM3)
        Me.gbxPressure.Controls.Add(Me.txtTransferPM2)
        Me.gbxPressure.Controls.Add(Me.txtTransferPM1)
        Me.gbxPressure.Controls.Add(Me.txtSlowVentLLA)
        Me.gbxPressure.Controls.Add(Me.txtSlowRoughLLA)
        Me.gbxPressure.Controls.Add(Me.txtCrossOverTM)
        Me.gbxPressure.Controls.Add(Me.txtCrossOverLLA)
        Me.gbxPressure.Controls.Add(Me.txtTransferTM)
        Me.gbxPressure.Controls.Add(Me.txtTransferLLA)
        Me.gbxPressure.Controls.Add(Me.txtVentTM)
        Me.gbxPressure.Controls.Add(Me.txtVentLLA)
        Me.gbxPressure.Controls.Add(Me.lblSlowVent)
        Me.gbxPressure.Controls.Add(Me.lblSlowRough)
        Me.gbxPressure.Controls.Add(Me.Label5)
        Me.gbxPressure.Controls.Add(Me.Label10)
        Me.gbxPressure.Controls.Add(Me.Label12)
        Me.gbxPressure.Controls.Add(Me.lblTMPressure)
        Me.gbxPressure.Controls.Add(Me.lblPM3Pressure)
        Me.gbxPressure.Controls.Add(Me.lblLLAPressure)
        Me.gbxPressure.Controls.Add(Me.lblPM2Pressure)
        Me.gbxPressure.Controls.Add(Me.lblPM1Pressure)
        Me.gbxPressure.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxPressure.Location = New System.Drawing.Point(50, 25)
        Me.gbxPressure.Name = "gbxPressure"
        Me.gbxPressure.Size = New System.Drawing.Size(1181, 340)
        Me.gbxPressure.TabIndex = 53
        Me.gbxPressure.TabStop = False
        Me.gbxPressure.Text = "Pressure"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(424, 181)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 17)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "(Default 1)"
        '
        'txtEtchRatePM2
        '
        Me.txtEtchRatePM2.AccessibleDescription = "Etch Rate PM2"
        Me.txtEtchRatePM2.BackColor = System.Drawing.SystemColors.Window
        Me.txtEtchRatePM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtEtchRatePM2.Enabled = False
        Me.txtEtchRatePM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEtchRatePM2.Location = New System.Drawing.Point(402, 249)
        Me.txtEtchRatePM2.Name = "txtEtchRatePM2"
        Me.txtEtchRatePM2.ReadOnly = True
        Me.txtEtchRatePM2.Size = New System.Drawing.Size(120, 25)
        Me.txtEtchRatePM2.TabIndex = 68
        Me.txtEtchRatePM2.Text = "0"
        Me.txtEtchRatePM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEtchRatePM3
        '
        Me.txtEtchRatePM3.AccessibleDescription = "Etch Rate PM3"
        Me.txtEtchRatePM3.BackColor = System.Drawing.SystemColors.Window
        Me.txtEtchRatePM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtEtchRatePM3.Enabled = False
        Me.txtEtchRatePM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEtchRatePM3.Location = New System.Drawing.Point(402, 292)
        Me.txtEtchRatePM3.Name = "txtEtchRatePM3"
        Me.txtEtchRatePM3.ReadOnly = True
        Me.txtEtchRatePM3.Size = New System.Drawing.Size(120, 25)
        Me.txtEtchRatePM3.TabIndex = 67
        Me.txtEtchRatePM3.Text = "0"
        Me.txtEtchRatePM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEtchRatePM1
        '
        Me.txtEtchRatePM1.AccessibleDescription = "PEtch Rate PM1"
        Me.txtEtchRatePM1.BackColor = System.Drawing.SystemColors.Window
        Me.txtEtchRatePM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtEtchRatePM1.Enabled = False
        Me.txtEtchRatePM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEtchRatePM1.Location = New System.Drawing.Point(402, 206)
        Me.txtEtchRatePM1.Name = "txtEtchRatePM1"
        Me.txtEtchRatePM1.ReadOnly = True
        Me.txtEtchRatePM1.Size = New System.Drawing.Size(120, 25)
        Me.txtEtchRatePM1.TabIndex = 66
        Me.txtEtchRatePM1.Text = "0"
        Me.txtEtchRatePM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(399, 163)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 17)
        Me.Label13.TabIndex = 69
        Me.Label13.Text = "Etch Rate Control"
        '
        'txtRateOfRiseVolTM
        '
        Me.txtRateOfRiseVolTM.AccessibleDescription = "TM Rate Of Rise Volume"
        Me.txtRateOfRiseVolTM.BackColor = System.Drawing.SystemColors.Window
        Me.txtRateOfRiseVolTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRateOfRiseVolTM.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtRateOfRiseVolTM.Location = New System.Drawing.Point(1010, 120)
        Me.txtRateOfRiseVolTM.Name = "txtRateOfRiseVolTM"
        Me.txtRateOfRiseVolTM.ReadOnly = True
        Me.txtRateOfRiseVolTM.Size = New System.Drawing.Size(120, 25)
        Me.txtRateOfRiseVolTM.TabIndex = 63
        Me.txtRateOfRiseVolTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRateOfRiseVolLLA
        '
        Me.txtRateOfRiseVolLLA.AccessibleDescription = "LLA Rate Of Rise Volume"
        Me.txtRateOfRiseVolLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRateOfRiseVolLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRateOfRiseVolLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtRateOfRiseVolLLA.Location = New System.Drawing.Point(1010, 77)
        Me.txtRateOfRiseVolLLA.Name = "txtRateOfRiseVolLLA"
        Me.txtRateOfRiseVolLLA.ReadOnly = True
        Me.txtRateOfRiseVolLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtRateOfRiseVolLLA.TabIndex = 61
        Me.txtRateOfRiseVolLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(984, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(193, 17)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Rate Of Rise Volume (Liter)"
        '
        'lblLLAForelineCG
        '
        Me.lblLLAForelineCG.AutoSize = True
        Me.lblLLAForelineCG.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLAForelineCG.Location = New System.Drawing.Point(724, 253)
        Me.lblLLAForelineCG.Name = "lblLLAForelineCG"
        Me.lblLLAForelineCG.Size = New System.Drawing.Size(97, 17)
        Me.lblLLAForelineCG.TabIndex = 59
        Me.lblLLAForelineCG.Text = "LLA Foreline"
        '
        'lblTMForelineCG
        '
        Me.lblTMForelineCG.AutoSize = True
        Me.lblTMForelineCG.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTMForelineCG.Location = New System.Drawing.Point(726, 210)
        Me.lblTMForelineCG.Name = "lblTMForelineCG"
        Me.lblTMForelineCG.Size = New System.Drawing.Size(92, 17)
        Me.lblTMForelineCG.TabIndex = 58
        Me.lblTMForelineCG.Text = "TM Foreline"
        '
        'lblMPPressure
        '
        Me.lblMPPressure.AutoSize = True
        Me.lblMPPressure.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMPPressure.Location = New System.Drawing.Point(727, 167)
        Me.lblMPPressure.Name = "lblMPPressure"
        Me.lblMPPressure.Size = New System.Drawing.Size(91, 17)
        Me.lblMPPressure.TabIndex = 57
        Me.lblMPPressure.Text = "Mech. Pump"
        '
        'txtLLAForelineCGTripPoint
        '
        Me.txtLLAForelineCGTripPoint.AccessibleDescription = "LLA CG Trip Point"
        Me.txtLLAForelineCGTripPoint.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLAForelineCGTripPoint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLAForelineCGTripPoint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtLLAForelineCGTripPoint.Location = New System.Drawing.Point(851, 249)
        Me.txtLLAForelineCGTripPoint.Name = "txtLLAForelineCGTripPoint"
        Me.txtLLAForelineCGTripPoint.ReadOnly = True
        Me.txtLLAForelineCGTripPoint.Size = New System.Drawing.Size(120, 25)
        Me.txtLLAForelineCGTripPoint.TabIndex = 56
        Me.txtLLAForelineCGTripPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTMForelineCGTripPoint
        '
        Me.txtTMForelineCGTripPoint.AccessibleDescription = "LLA CG Trip Point"
        Me.txtTMForelineCGTripPoint.BackColor = System.Drawing.SystemColors.Window
        Me.txtTMForelineCGTripPoint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTMForelineCGTripPoint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTMForelineCGTripPoint.Location = New System.Drawing.Point(851, 206)
        Me.txtTMForelineCGTripPoint.Name = "txtTMForelineCGTripPoint"
        Me.txtTMForelineCGTripPoint.ReadOnly = True
        Me.txtTMForelineCGTripPoint.Size = New System.Drawing.Size(120, 25)
        Me.txtTMForelineCGTripPoint.TabIndex = 55
        Me.txtTMForelineCGTripPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMPCGTripPoint
        '
        Me.txtMPCGTripPoint.AccessibleDescription = "MP CG Trip Point"
        Me.txtMPCGTripPoint.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPCGTripPoint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMPCGTripPoint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtMPCGTripPoint.Location = New System.Drawing.Point(851, 163)
        Me.txtMPCGTripPoint.Name = "txtMPCGTripPoint"
        Me.txtMPCGTripPoint.ReadOnly = True
        Me.txtMPCGTripPoint.Size = New System.Drawing.Size(120, 25)
        Me.txtMPCGTripPoint.TabIndex = 54
        Me.txtMPCGTripPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTMCGTripPoint
        '
        Me.txtTMCGTripPoint.AccessibleDescription = "TM CG Trip Point"
        Me.txtTMCGTripPoint.BackColor = System.Drawing.SystemColors.Window
        Me.txtTMCGTripPoint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTMCGTripPoint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTMCGTripPoint.Location = New System.Drawing.Point(851, 120)
        Me.txtTMCGTripPoint.Name = "txtTMCGTripPoint"
        Me.txtTMCGTripPoint.ReadOnly = True
        Me.txtTMCGTripPoint.Size = New System.Drawing.Size(120, 25)
        Me.txtTMCGTripPoint.TabIndex = 52
        Me.txtTMCGTripPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLLACGTripPoint
        '
        Me.txtLLACGTripPoint.AccessibleDescription = "LLA CG Trip Point"
        Me.txtLLACGTripPoint.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLACGTripPoint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLACGTripPoint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtLLACGTripPoint.Location = New System.Drawing.Point(849, 77)
        Me.txtLLACGTripPoint.Name = "txtLLACGTripPoint"
        Me.txtLLACGTripPoint.ReadOnly = True
        Me.txtLLACGTripPoint.Size = New System.Drawing.Size(120, 25)
        Me.txtLLACGTripPoint.TabIndex = 50
        Me.txtLLACGTripPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbCGTripPoint
        '
        Me.lbCGTripPoint.AutoSize = True
        Me.lbCGTripPoint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCGTripPoint.Location = New System.Drawing.Point(840, 42)
        Me.lbCGTripPoint.Name = "lbCGTripPoint"
        Me.lbCGTripPoint.Size = New System.Drawing.Size(138, 17)
        Me.lbCGTripPoint.TabIndex = 53
        Me.lbCGTripPoint.Text = "CG Trip Point(Torr)"
        '
        'txtTransferPM3
        '
        Me.txtTransferPM3.AccessibleDescription = "PM3 Transfer Pressure"
        Me.txtTransferPM3.BackColor = System.Drawing.SystemColors.Window
        Me.txtTransferPM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTransferPM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTransferPM3.Location = New System.Drawing.Point(253, 292)
        Me.txtTransferPM3.Name = "txtTransferPM3"
        Me.txtTransferPM3.ReadOnly = True
        Me.txtTransferPM3.Size = New System.Drawing.Size(120, 25)
        Me.txtTransferPM3.TabIndex = 26
        Me.txtTransferPM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTransferPM2
        '
        Me.txtTransferPM2.AccessibleDescription = "PM2 Transfer Pressure"
        Me.txtTransferPM2.BackColor = System.Drawing.SystemColors.Window
        Me.txtTransferPM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTransferPM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTransferPM2.Location = New System.Drawing.Point(253, 249)
        Me.txtTransferPM2.Name = "txtTransferPM2"
        Me.txtTransferPM2.ReadOnly = True
        Me.txtTransferPM2.Size = New System.Drawing.Size(120, 25)
        Me.txtTransferPM2.TabIndex = 24
        Me.txtTransferPM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTransferPM1
        '
        Me.txtTransferPM1.AccessibleDescription = "PM1 Transfer Pressure"
        Me.txtTransferPM1.BackColor = System.Drawing.SystemColors.Window
        Me.txtTransferPM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTransferPM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTransferPM1.Location = New System.Drawing.Point(253, 206)
        Me.txtTransferPM1.Name = "txtTransferPM1"
        Me.txtTransferPM1.ReadOnly = True
        Me.txtTransferPM1.Size = New System.Drawing.Size(120, 25)
        Me.txtTransferPM1.TabIndex = 22
        Me.txtTransferPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSlowVentLLA
        '
        Me.txtSlowVentLLA.AccessibleDescription = "LLA Slow Vent Pressure"
        Me.txtSlowVentLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtSlowVentLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSlowVentLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtSlowVentLLA.Location = New System.Drawing.Point(700, 77)
        Me.txtSlowVentLLA.Name = "txtSlowVentLLA"
        Me.txtSlowVentLLA.ReadOnly = True
        Me.txtSlowVentLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtSlowVentLLA.TabIndex = 10
        Me.txtSlowVentLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSlowRoughLLA
        '
        Me.txtSlowRoughLLA.AccessibleDescription = "LLA Slow Rough Pressure"
        Me.txtSlowRoughLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtSlowRoughLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSlowRoughLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtSlowRoughLLA.Location = New System.Drawing.Point(551, 77)
        Me.txtSlowRoughLLA.Name = "txtSlowRoughLLA"
        Me.txtSlowRoughLLA.ReadOnly = True
        Me.txtSlowRoughLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtSlowRoughLLA.TabIndex = 9
        Me.txtSlowRoughLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCrossOverTM
        '
        Me.txtCrossOverTM.AccessibleDescription = "TM Cross Over Pressure"
        Me.txtCrossOverTM.BackColor = System.Drawing.SystemColors.Window
        Me.txtCrossOverTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCrossOverTM.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCrossOverTM.Location = New System.Drawing.Point(402, 120)
        Me.txtCrossOverTM.Name = "txtCrossOverTM"
        Me.txtCrossOverTM.ReadOnly = True
        Me.txtCrossOverTM.Size = New System.Drawing.Size(120, 25)
        Me.txtCrossOverTM.TabIndex = 20
        Me.txtCrossOverTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCrossOverLLA
        '
        Me.txtCrossOverLLA.AccessibleDescription = "LLA Cross Over Pressure"
        Me.txtCrossOverLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtCrossOverLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCrossOverLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCrossOverLLA.Location = New System.Drawing.Point(402, 77)
        Me.txtCrossOverLLA.Name = "txtCrossOverLLA"
        Me.txtCrossOverLLA.ReadOnly = True
        Me.txtCrossOverLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtCrossOverLLA.TabIndex = 8
        Me.txtCrossOverLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTransferTM
        '
        Me.txtTransferTM.AccessibleDescription = "TM Transfer Pressure"
        Me.txtTransferTM.BackColor = System.Drawing.SystemColors.Window
        Me.txtTransferTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTransferTM.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTransferTM.Location = New System.Drawing.Point(253, 120)
        Me.txtTransferTM.Name = "txtTransferTM"
        Me.txtTransferTM.ReadOnly = True
        Me.txtTransferTM.Size = New System.Drawing.Size(120, 25)
        Me.txtTransferTM.TabIndex = 19
        Me.txtTransferTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTransferLLA
        '
        Me.txtTransferLLA.AccessibleDescription = "LLA Transfer Pressure"
        Me.txtTransferLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTransferLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTransferLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTransferLLA.Location = New System.Drawing.Point(253, 77)
        Me.txtTransferLLA.Name = "txtTransferLLA"
        Me.txtTransferLLA.ReadOnly = True
        Me.txtTransferLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtTransferLLA.TabIndex = 7
        Me.txtTransferLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtVentTM
        '
        Me.txtVentTM.AccessibleDescription = "TM Vent Pressure"
        Me.txtVentTM.BackColor = System.Drawing.SystemColors.Window
        Me.txtVentTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtVentTM.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtVentTM.Location = New System.Drawing.Point(104, 120)
        Me.txtVentTM.Name = "txtVentTM"
        Me.txtVentTM.ReadOnly = True
        Me.txtVentTM.Size = New System.Drawing.Size(120, 25)
        Me.txtVentTM.TabIndex = 18
        Me.txtVentTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtVentLLA
        '
        Me.txtVentLLA.AccessibleDescription = "LLA Vent Pressure"
        Me.txtVentLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtVentLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtVentLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtVentLLA.Location = New System.Drawing.Point(104, 77)
        Me.txtVentLLA.Name = "txtVentLLA"
        Me.txtVentLLA.ReadOnly = True
        Me.txtVentLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtVentLLA.TabIndex = 6
        Me.txtVentLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSlowVent
        '
        Me.lblSlowVent.AutoSize = True
        Me.lblSlowVent.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlowVent.Location = New System.Drawing.Point(703, 42)
        Me.lblSlowVent.Name = "lblSlowVent"
        Me.lblSlowVent.Size = New System.Drawing.Size(115, 17)
        Me.lblSlowVent.TabIndex = 34
        Me.lblSlowVent.Text = "Slow Vent (Torr)"
        '
        'lblSlowRough
        '
        Me.lblSlowRough.AutoSize = True
        Me.lblSlowRough.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlowRough.Location = New System.Drawing.Point(547, 42)
        Me.lblSlowRough.Name = "lblSlowRough"
        Me.lblSlowRough.Size = New System.Drawing.Size(128, 17)
        Me.lblSlowRough.TabIndex = 33
        Me.lblSlowRough.Text = "Slow Rough (Torr)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(398, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 17)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Cross Over (Torr)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(260, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 17)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Transfer (Torr)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(124, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 17)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Vent (Torr)"
        '
        'lblTMPressure
        '
        Me.lblTMPressure.AutoSize = True
        Me.lblTMPressure.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTMPressure.Location = New System.Drawing.Point(32, 123)
        Me.lblTMPressure.Name = "lblTMPressure"
        Me.lblTMPressure.Size = New System.Drawing.Size(33, 17)
        Me.lblTMPressure.TabIndex = 8
        Me.lblTMPressure.Text = "TM"
        '
        'lblPM3Pressure
        '
        Me.lblPM3Pressure.AutoSize = True
        Me.lblPM3Pressure.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM3Pressure.Location = New System.Drawing.Point(32, 295)
        Me.lblPM3Pressure.Name = "lblPM3Pressure"
        Me.lblPM3Pressure.Size = New System.Drawing.Size(40, 17)
        Me.lblPM3Pressure.TabIndex = 22
        Me.lblPM3Pressure.Text = "PM3"
        '
        'lblLLAPressure
        '
        Me.lblLLAPressure.AutoSize = True
        Me.lblLLAPressure.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLAPressure.Location = New System.Drawing.Point(32, 80)
        Me.lblLLAPressure.Name = "lblLLAPressure"
        Me.lblLLAPressure.Size = New System.Drawing.Size(39, 17)
        Me.lblLLAPressure.TabIndex = 6
        Me.lblLLAPressure.Text = "LLA"
        '
        'lblPM2Pressure
        '
        Me.lblPM2Pressure.AutoSize = True
        Me.lblPM2Pressure.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM2Pressure.Location = New System.Drawing.Point(32, 252)
        Me.lblPM2Pressure.Name = "lblPM2Pressure"
        Me.lblPM2Pressure.Size = New System.Drawing.Size(40, 17)
        Me.lblPM2Pressure.TabIndex = 21
        Me.lblPM2Pressure.Text = "PM2"
        '
        'lblPM1Pressure
        '
        Me.lblPM1Pressure.AutoSize = True
        Me.lblPM1Pressure.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM1Pressure.Location = New System.Drawing.Point(32, 209)
        Me.lblPM1Pressure.Name = "lblPM1Pressure"
        Me.lblPM1Pressure.Size = New System.Drawing.Size(40, 17)
        Me.lblPM1Pressure.TabIndex = 20
        Me.lblPM1Pressure.Text = "PM1"
        '
        'gbxRegenHourLimit
        '
        Me.gbxRegenHourLimit.Controls.Add(Me.txtCryoPumpHour)
        Me.gbxRegenHourLimit.Controls.Add(Me.Label3)
        Me.gbxRegenHourLimit.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.gbxRegenHourLimit.ForeColor = System.Drawing.Color.Black
        Me.gbxRegenHourLimit.Location = New System.Drawing.Point(470, 405)
        Me.gbxRegenHourLimit.Name = "gbxRegenHourLimit"
        Me.gbxRegenHourLimit.Size = New System.Drawing.Size(255, 105)
        Me.gbxRegenHourLimit.TabIndex = 46
        Me.gbxRegenHourLimit.TabStop = False
        Me.gbxRegenHourLimit.Text = "Cryo Regen Hour Limit"
        '
        'txtCryoPumpHour
        '
        Me.txtCryoPumpHour.AccessibleDescription = "Cryo Regen Hour Limit"
        Me.txtCryoPumpHour.BackColor = System.Drawing.SystemColors.Window
        Me.txtCryoPumpHour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCryoPumpHour.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCryoPumpHour.Location = New System.Drawing.Point(35, 46)
        Me.txtCryoPumpHour.Name = "txtCryoPumpHour"
        Me.txtCryoPumpHour.Size = New System.Drawing.Size(160, 25)
        Me.txtCryoPumpHour.TabIndex = 31
        Me.txtCryoPumpHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(201, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 22)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "h"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbxCGTransferDiff
        '
        Me.gbxCGTransferDiff.Controls.Add(Me.txtCGDifferentialPercent)
        Me.gbxCGTransferDiff.Controls.Add(Me.Label2)
        Me.gbxCGTransferDiff.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.gbxCGTransferDiff.ForeColor = System.Drawing.Color.Black
        Me.gbxCGTransferDiff.Location = New System.Drawing.Point(50, 405)
        Me.gbxCGTransferDiff.Name = "gbxCGTransferDiff"
        Me.gbxCGTransferDiff.Size = New System.Drawing.Size(255, 105)
        Me.gbxCGTransferDiff.TabIndex = 45
        Me.gbxCGTransferDiff.TabStop = False
        Me.gbxCGTransferDiff.Text = "CG Transfer Difference"
        '
        'txtCGDifferentialPercent
        '
        Me.txtCGDifferentialPercent.AccessibleDescription = "CG Differential Percent"
        Me.txtCGDifferentialPercent.BackColor = System.Drawing.SystemColors.Window
        Me.txtCGDifferentialPercent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCGDifferentialPercent.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtCGDifferentialPercent.Location = New System.Drawing.Point(35, 46)
        Me.txtCGDifferentialPercent.Name = "txtCGDifferentialPercent"
        Me.txtCGDifferentialPercent.Size = New System.Drawing.Size(160, 25)
        Me.txtCGDifferentialPercent.TabIndex = 31
        Me.txtCGDifferentialPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(201, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 22)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "%"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnApplyPressureSetpoint
        '
        Me.btnApplyPressureSetpoint.BackColor = System.Drawing.SystemColors.Info
        Me.btnApplyPressureSetpoint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplyPressureSetpoint.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApplyPressureSetpoint.Location = New System.Drawing.Point(546, 541)
        Me.btnApplyPressureSetpoint.Name = "btnApplyPressureSetpoint"
        Me.btnApplyPressureSetpoint.Size = New System.Drawing.Size(179, 49)
        Me.btnApplyPressureSetpoint.TabIndex = 31
        Me.btnApplyPressureSetpoint.Text = "Apply"
        Me.btnApplyPressureSetpoint.UseVisualStyleBackColor = False
        '
        'tabElevatorSetting
        '
        Me.tabElevatorSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabElevatorSetting.Controls.Add(Me.pnlElevatorSetting)
        Me.tabElevatorSetting.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabElevatorSetting.Location = New System.Drawing.Point(0, 29)
        Me.tabElevatorSetting.Name = "tabElevatorSetting"
        Me.tabElevatorSetting.Size = New System.Drawing.Size(1280, 727)
        Me.tabElevatorSetting.TabIndex = 5
        Me.tabElevatorSetting.Text = "Elevator /Robot Setting "
        Me.tabElevatorSetting.UseVisualStyleBackColor = True
        '
        'pnlElevatorSetting
        '
        Me.pnlElevatorSetting.Controls.Add(Me.gbxRobot)
        Me.pnlElevatorSetting.Controls.Add(Me.gbxLLASetting)
        Me.pnlElevatorSetting.Controls.Add(Me.btnCancelElevatorSetting)
        Me.pnlElevatorSetting.Controls.Add(Me.btnApplyElevatorSetting)
        Me.pnlElevatorSetting.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlElevatorSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlElevatorSetting.Location = New System.Drawing.Point(0, 0)
        Me.pnlElevatorSetting.Name = "pnlElevatorSetting"
        Me.pnlElevatorSetting.Size = New System.Drawing.Size(1280, 727)
        Me.pnlElevatorSetting.TabIndex = 26
        '
        'gbxRobot
        '
        Me.gbxRobot.Controls.Add(Me.txtApplyStatus)
        Me.gbxRobot.Controls.Add(Me.txtRobotVersion)
        Me.gbxRobot.Controls.Add(Me.btnRequestRobotInfo)
        Me.gbxRobot.Controls.Add(Me.RobotConfig)
        Me.gbxRobot.Controls.Add(Me.btnLoadConfigRobot)
        Me.gbxRobot.Controls.Add(Me.btnStoreConfigRobot)
        Me.gbxRobot.Location = New System.Drawing.Point(548, 7)
        Me.gbxRobot.Name = "gbxRobot"
        Me.gbxRobot.Size = New System.Drawing.Size(542, 645)
        Me.gbxRobot.TabIndex = 58
        Me.gbxRobot.TabStop = False
        Me.gbxRobot.Text = "Robot"
        '
        'txtApplyStatus
        '
        Me.txtApplyStatus.Location = New System.Drawing.Point(376, 603)
        Me.txtApplyStatus.Name = "txtApplyStatus"
        Me.txtApplyStatus.Size = New System.Drawing.Size(92, 35)
        Me.txtApplyStatus.TabIndex = 23
        Me.txtApplyStatus.Visible = False
        '
        'txtRobotVersion
        '
        Me.txtRobotVersion.Location = New System.Drawing.Point(269, 606)
        Me.txtRobotVersion.Name = "txtRobotVersion"
        Me.txtRobotVersion.Size = New System.Drawing.Size(92, 35)
        Me.txtRobotVersion.TabIndex = 23
        Me.txtRobotVersion.Visible = False
        '
        'btnRequestRobotInfo
        '
        Me.btnRequestRobotInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRequestRobotInfo.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnRequestRobotInfo.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnRequestRobotInfo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnRequestRobotInfo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnRequestRobotInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequestRobotInfo.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRequestRobotInfo.Image = Global.AVP_Robot_Project.My.Resources.Resources.refresh
        Me.btnRequestRobotInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRequestRobotInfo.Location = New System.Drawing.Point(183, 609)
        Me.btnRequestRobotInfo.Name = "btnRequestRobotInfo"
        Me.btnRequestRobotInfo.Size = New System.Drawing.Size(80, 29)
        Me.btnRequestRobotInfo.TabIndex = 22
        Me.btnRequestRobotInfo.Text = "Refresh"
        Me.btnRequestRobotInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRequestRobotInfo.UseVisualStyleBackColor = True
        '
        'RobotConfig
        '
        Me.RobotConfig.AutoSize = True
        Me.RobotConfig.BackColor = System.Drawing.Color.Transparent
        Me.RobotConfig.Location = New System.Drawing.Point(18, 23)
        Me.RobotConfig.MinimumSize = New System.Drawing.Size(490, 560)
        Me.RobotConfig.Name = "RobotConfig"
        Me.RobotConfig.Size = New System.Drawing.Size(505, 582)
        Me.RobotConfig.TabIndex = 19
        '
        'btnLoadConfigRobot
        '
        Me.btnLoadConfigRobot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLoadConfigRobot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoadConfigRobot.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnLoadConfigRobot.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnLoadConfigRobot.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnLoadConfigRobot.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnLoadConfigRobot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadConfigRobot.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadConfigRobot.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_comit
        Me.btnLoadConfigRobot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoadConfigRobot.Location = New System.Drawing.Point(91, 609)
        Me.btnLoadConfigRobot.Name = "btnLoadConfigRobot"
        Me.btnLoadConfigRobot.Size = New System.Drawing.Size(87, 29)
        Me.btnLoadConfigRobot.TabIndex = 18
        Me.btnLoadConfigRobot.Text = "History"
        Me.btnLoadConfigRobot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLoadConfigRobot.UseVisualStyleBackColor = True
        '
        'btnStoreConfigRobot
        '
        Me.btnStoreConfigRobot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStoreConfigRobot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStoreConfigRobot.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnStoreConfigRobot.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnStoreConfigRobot.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnStoreConfigRobot.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnStoreConfigRobot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStoreConfigRobot.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStoreConfigRobot.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_update
        Me.btnStoreConfigRobot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStoreConfigRobot.Location = New System.Drawing.Point(6, 609)
        Me.btnStoreConfigRobot.Name = "btnStoreConfigRobot"
        Me.btnStoreConfigRobot.Size = New System.Drawing.Size(80, 29)
        Me.btnStoreConfigRobot.TabIndex = 17
        Me.btnStoreConfigRobot.Text = "Store"
        Me.btnStoreConfigRobot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStoreConfigRobot.UseVisualStyleBackColor = True
        '
        'gbxLLASetting
        '
        Me.gbxLLASetting.Controls.Add(Me.btnLoadConfigLLA)
        Me.gbxLLASetting.Controls.Add(Me.btnStoreConfigLLA)
        Me.gbxLLASetting.Controls.Add(Me.txtFindBiasLLA)
        Me.gbxLLASetting.Controls.Add(Me.txtBaseOffsetLLA)
        Me.gbxLLASetting.Controls.Add(Me.txtPitchLLA)
        Me.gbxLLASetting.Controls.Add(Me.txtTravelLengthLLA)
        Me.gbxLLASetting.Controls.Add(Me.txtNumberOfSlotsLLA)
        Me.gbxLLASetting.Controls.Add(Me.Label69)
        Me.gbxLLASetting.Controls.Add(Me.Label70)
        Me.gbxLLASetting.Controls.Add(Me.Label66)
        Me.gbxLLASetting.Controls.Add(Me.Label67)
        Me.gbxLLASetting.Controls.Add(Me.Label68)
        Me.gbxLLASetting.Location = New System.Drawing.Point(215, 7)
        Me.gbxLLASetting.Name = "gbxLLASetting"
        Me.gbxLLASetting.Size = New System.Drawing.Size(316, 317)
        Me.gbxLLASetting.TabIndex = 57
        Me.gbxLLASetting.TabStop = False
        Me.gbxLLASetting.Text = "LLA"
        '
        'btnLoadConfigLLA
        '
        Me.btnLoadConfigLLA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLoadConfigLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoadConfigLLA.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnLoadConfigLLA.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnLoadConfigLLA.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnLoadConfigLLA.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnLoadConfigLLA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadConfigLLA.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadConfigLLA.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_comit
        Me.btnLoadConfigLLA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoadConfigLLA.Location = New System.Drawing.Point(92, 281)
        Me.btnLoadConfigLLA.Name = "btnLoadConfigLLA"
        Me.btnLoadConfigLLA.Size = New System.Drawing.Size(87, 29)
        Me.btnLoadConfigLLA.TabIndex = 60
        Me.btnLoadConfigLLA.Text = "History"
        Me.btnLoadConfigLLA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLoadConfigLLA.UseVisualStyleBackColor = True
        '
        'btnStoreConfigLLA
        '
        Me.btnStoreConfigLLA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStoreConfigLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStoreConfigLLA.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnStoreConfigLLA.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control
        Me.btnStoreConfigLLA.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnStoreConfigLLA.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnStoreConfigLLA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStoreConfigLLA.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStoreConfigLLA.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_update
        Me.btnStoreConfigLLA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStoreConfigLLA.Location = New System.Drawing.Point(7, 281)
        Me.btnStoreConfigLLA.Name = "btnStoreConfigLLA"
        Me.btnStoreConfigLLA.Size = New System.Drawing.Size(80, 29)
        Me.btnStoreConfigLLA.TabIndex = 59
        Me.btnStoreConfigLLA.Text = "Store"
        Me.btnStoreConfigLLA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStoreConfigLLA.UseVisualStyleBackColor = True
        '
        'txtFindBiasLLA
        '
        Me.txtFindBiasLLA.AccessibleDescription = "LLA Find Bias"
        Me.txtFindBiasLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtFindBiasLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtFindBiasLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtFindBiasLLA.Location = New System.Drawing.Point(150, 219)
        Me.txtFindBiasLLA.Name = "txtFindBiasLLA"
        Me.txtFindBiasLLA.ReadOnly = True
        Me.txtFindBiasLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtFindBiasLLA.TabIndex = 15
        Me.txtFindBiasLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBaseOffsetLLA
        '
        Me.txtBaseOffsetLLA.AccessibleDescription = "LLA Base Offset"
        Me.txtBaseOffsetLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtBaseOffsetLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtBaseOffsetLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtBaseOffsetLLA.Location = New System.Drawing.Point(150, 175)
        Me.txtBaseOffsetLLA.Name = "txtBaseOffsetLLA"
        Me.txtBaseOffsetLLA.ReadOnly = True
        Me.txtBaseOffsetLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtBaseOffsetLLA.TabIndex = 12
        Me.txtBaseOffsetLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPitchLLA
        '
        Me.txtPitchLLA.AccessibleDescription = "LLA Pitch"
        Me.txtPitchLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtPitchLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPitchLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtPitchLLA.Location = New System.Drawing.Point(150, 131)
        Me.txtPitchLLA.Name = "txtPitchLLA"
        Me.txtPitchLLA.ReadOnly = True
        Me.txtPitchLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtPitchLLA.TabIndex = 9
        Me.txtPitchLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTravelLengthLLA
        '
        Me.txtTravelLengthLLA.AccessibleDescription = "LLA Travel Length"
        Me.txtTravelLengthLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTravelLengthLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTravelLengthLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTravelLengthLLA.Location = New System.Drawing.Point(150, 87)
        Me.txtTravelLengthLLA.Name = "txtTravelLengthLLA"
        Me.txtTravelLengthLLA.ReadOnly = True
        Me.txtTravelLengthLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtTravelLengthLLA.TabIndex = 6
        Me.txtTravelLengthLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumberOfSlotsLLA
        '
        Me.txtNumberOfSlotsLLA.AccessibleDescription = "LLA Number of Slots"
        Me.txtNumberOfSlotsLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumberOfSlotsLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtNumberOfSlotsLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtNumberOfSlotsLLA.Location = New System.Drawing.Point(150, 43)
        Me.txtNumberOfSlotsLLA.Name = "txtNumberOfSlotsLLA"
        Me.txtNumberOfSlotsLLA.ReadOnly = True
        Me.txtNumberOfSlotsLLA.Size = New System.Drawing.Size(120, 25)
        Me.txtNumberOfSlotsLLA.TabIndex = 3
        Me.txtNumberOfSlotsLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(20, 222)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(70, 17)
        Me.Label69.TabIndex = 10
        Me.Label69.Text = "Find Bias"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(20, 178)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(85, 17)
        Me.Label70.TabIndex = 9
        Me.Label70.Text = "Base Offset"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(20, 134)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(41, 17)
        Me.Label66.TabIndex = 8
        Me.Label66.Text = "Pitch"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(20, 90)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(101, 17)
        Me.Label67.TabIndex = 7
        Me.Label67.Text = "Travel Length"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(20, 46)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(113, 17)
        Me.Label68.TabIndex = 6
        Me.Label68.Text = "Number of Slots"
        '
        'btnCancelElevatorSetting
        '
        Me.btnCancelElevatorSetting.BackColor = System.Drawing.SystemColors.Info
        Me.btnCancelElevatorSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelElevatorSetting.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelElevatorSetting.Location = New System.Drawing.Point(698, 661)
        Me.btnCancelElevatorSetting.Name = "btnCancelElevatorSetting"
        Me.btnCancelElevatorSetting.Size = New System.Drawing.Size(179, 49)
        Me.btnCancelElevatorSetting.TabIndex = 17
        Me.btnCancelElevatorSetting.Text = "Cancel"
        Me.btnCancelElevatorSetting.UseVisualStyleBackColor = False
        '
        'btnApplyElevatorSetting
        '
        Me.btnApplyElevatorSetting.BackColor = System.Drawing.SystemColors.Info
        Me.btnApplyElevatorSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplyElevatorSetting.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApplyElevatorSetting.Location = New System.Drawing.Point(404, 661)
        Me.btnApplyElevatorSetting.Name = "btnApplyElevatorSetting"
        Me.btnApplyElevatorSetting.Size = New System.Drawing.Size(179, 49)
        Me.btnApplyElevatorSetting.TabIndex = 17
        Me.btnApplyElevatorSetting.Text = "Apply"
        Me.btnApplyElevatorSetting.UseVisualStyleBackColor = False
        '
        'TabTargetKwh
        '
        Me.TabTargetKwh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabTargetKwh.Controls.Add(Me.pnlKWH)
        Me.TabTargetKwh.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TabTargetKwh.Location = New System.Drawing.Point(0, 29)
        Me.TabTargetKwh.Name = "TabTargetKwh"
        Me.TabTargetKwh.Size = New System.Drawing.Size(1280, 727)
        Me.TabTargetKwh.TabIndex = 6
        Me.TabTargetKwh.Text = "Target /Source /Shielding Limits "
        Me.TabTargetKwh.UseVisualStyleBackColor = True
        '
        'pnlKWH
        '
        Me.pnlKWH.Controls.Add(Me.grboxModuleName)
        Me.pnlKWH.Controls.Add(Me.gbxLifetimeWafer)
        Me.pnlKWH.Controls.Add(Me.gbxShieldsQuartz)
        Me.pnlKWH.Controls.Add(Me.gbxUsage)
        Me.pnlKWH.Controls.Add(Me.gbxCalculationType)
        Me.pnlKWH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlKWH.Location = New System.Drawing.Point(0, 0)
        Me.pnlKWH.Name = "pnlKWH"
        Me.pnlKWH.Size = New System.Drawing.Size(1280, 727)
        Me.pnlKWH.TabIndex = 0
        '
        'grboxModuleName
        '
        Me.grboxModuleName.Controls.Add(Me.txtModuleNamePM1)
        Me.grboxModuleName.Controls.Add(Me.txtModuleNamePM2)
        Me.grboxModuleName.Controls.Add(Me.txtModuleNamePM3)
        Me.grboxModuleName.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grboxModuleName.Location = New System.Drawing.Point(825, 199)
        Me.grboxModuleName.Name = "grboxModuleName"
        Me.grboxModuleName.Size = New System.Drawing.Size(383, 186)
        Me.grboxModuleName.TabIndex = 63
        Me.grboxModuleName.TabStop = False
        Me.grboxModuleName.Text = "SECS/GEM Module Name"
        '
        'txtModuleNamePM1
        '
        Me.txtModuleNamePM1.AccessibleDescription = "PM1 Module Name"
        Me.txtModuleNamePM1.AccessibleName = "Chamber1"
        Me.txtModuleNamePM1.BackColor = System.Drawing.SystemColors.Window
        Me.txtModuleNamePM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtModuleNamePM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtModuleNamePM1.ForeColor = System.Drawing.Color.Black
        Me.txtModuleNamePM1.Location = New System.Drawing.Point(26, 48)
        Me.txtModuleNamePM1.Name = "txtModuleNamePM1"
        Me.txtModuleNamePM1.ReadOnly = True
        Me.txtModuleNamePM1.Size = New System.Drawing.Size(330, 25)
        Me.txtModuleNamePM1.TabIndex = 1
        Me.txtModuleNamePM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtModuleNamePM2
        '
        Me.txtModuleNamePM2.AccessibleDescription = "PM2 Module Name"
        Me.txtModuleNamePM2.AccessibleName = "Chamber2"
        Me.txtModuleNamePM2.BackColor = System.Drawing.SystemColors.Window
        Me.txtModuleNamePM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtModuleNamePM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtModuleNamePM2.ForeColor = System.Drawing.Color.Black
        Me.txtModuleNamePM2.Location = New System.Drawing.Point(26, 90)
        Me.txtModuleNamePM2.Name = "txtModuleNamePM2"
        Me.txtModuleNamePM2.ReadOnly = True
        Me.txtModuleNamePM2.Size = New System.Drawing.Size(330, 25)
        Me.txtModuleNamePM2.TabIndex = 1
        Me.txtModuleNamePM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtModuleNamePM3
        '
        Me.txtModuleNamePM3.AccessibleDescription = "PM3 Module Name"
        Me.txtModuleNamePM3.AccessibleName = "Chamber3"
        Me.txtModuleNamePM3.BackColor = System.Drawing.SystemColors.Window
        Me.txtModuleNamePM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtModuleNamePM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtModuleNamePM3.ForeColor = System.Drawing.Color.Black
        Me.txtModuleNamePM3.Location = New System.Drawing.Point(26, 133)
        Me.txtModuleNamePM3.Name = "txtModuleNamePM3"
        Me.txtModuleNamePM3.ReadOnly = True
        Me.txtModuleNamePM3.Size = New System.Drawing.Size(330, 25)
        Me.txtModuleNamePM3.TabIndex = 1
        Me.txtModuleNamePM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbxLifetimeWafer
        '
        Me.gbxLifetimeWafer.Controls.Add(Me.txtLifeTimeWafer)
        Me.gbxLifetimeWafer.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxLifetimeWafer.ForeColor = System.Drawing.Color.Black
        Me.gbxLifetimeWafer.Location = New System.Drawing.Point(913, 391)
        Me.gbxLifetimeWafer.Name = "gbxLifetimeWafer"
        Me.gbxLifetimeWafer.Size = New System.Drawing.Size(295, 70)
        Me.gbxLifetimeWafer.TabIndex = 62
        Me.gbxLifetimeWafer.TabStop = False
        Me.gbxLifetimeWafer.Text = "Lifetime Wafer"
        '
        'txtLifeTimeWafer
        '
        Me.txtLifeTimeWafer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLifeTimeWafer.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtLifeTimeWafer.Location = New System.Drawing.Point(140, 32)
        Me.txtLifeTimeWafer.Name = "txtLifeTimeWafer"
        Me.txtLifeTimeWafer.ReadOnly = True
        Me.txtLifeTimeWafer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLifeTimeWafer.Size = New System.Drawing.Size(120, 25)
        Me.txtLifeTimeWafer.TabIndex = 13
        Me.txtLifeTimeWafer.Text = "0"
        Me.txtLifeTimeWafer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbxShieldsQuartz
        '
        Me.gbxShieldsQuartz.Controls.Add(Me.lblPM3_ShQuUnit)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblPM2_ShQuUnit)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblPM1_ShQuUnit)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtShieldsPM3)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtShieldsPM2)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtShieldPM1)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblPM3Type2)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblPM2Type2)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblPM1Type2)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblMaxShields)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblWarningShields)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblLimitsShields)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtMaxShieldsPM3)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtMaxShieldsPM2)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtMaxShieldsPM1)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtWarningShieldsPM3)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtWarningShieldsPM2)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtWarningShieldsPM1)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtLimitShieldsPM3)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtLimitShieldsPM2)
        Me.gbxShieldsQuartz.Controls.Add(Me.txtLimitShieldsPM1)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblPM3Shields)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblPM2Shields)
        Me.gbxShieldsQuartz.Controls.Add(Me.lblPM1Shields)
        Me.gbxShieldsQuartz.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxShieldsQuartz.Location = New System.Drawing.Point(69, 199)
        Me.gbxShieldsQuartz.Name = "gbxShieldsQuartz"
        Me.gbxShieldsQuartz.Size = New System.Drawing.Size(747, 186)
        Me.gbxShieldsQuartz.TabIndex = 61
        Me.gbxShieldsQuartz.TabStop = False
        Me.gbxShieldsQuartz.Text = "Shields/Quartz"
        '
        'lblPM3_ShQuUnit
        '
        Me.lblPM3_ShQuUnit.AutoSize = True
        Me.lblPM3_ShQuUnit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM3_ShQuUnit.Location = New System.Drawing.Point(691, 141)
        Me.lblPM3_ShQuUnit.Name = "lblPM3_ShQuUnit"
        Me.lblPM3_ShQuUnit.Size = New System.Drawing.Size(46, 16)
        Me.lblPM3_ShQuUnit.TabIndex = 3
        Me.lblPM3_ShQuUnit.Text = "(kwh)"
        '
        'lblPM2_ShQuUnit
        '
        Me.lblPM2_ShQuUnit.AutoSize = True
        Me.lblPM2_ShQuUnit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM2_ShQuUnit.Location = New System.Drawing.Point(691, 98)
        Me.lblPM2_ShQuUnit.Name = "lblPM2_ShQuUnit"
        Me.lblPM2_ShQuUnit.Size = New System.Drawing.Size(46, 16)
        Me.lblPM2_ShQuUnit.TabIndex = 3
        Me.lblPM2_ShQuUnit.Text = "(kwh)"
        '
        'lblPM1_ShQuUnit
        '
        Me.lblPM1_ShQuUnit.AutoSize = True
        Me.lblPM1_ShQuUnit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM1_ShQuUnit.Location = New System.Drawing.Point(691, 56)
        Me.lblPM1_ShQuUnit.Name = "lblPM1_ShQuUnit"
        Me.lblPM1_ShQuUnit.Size = New System.Drawing.Size(46, 16)
        Me.lblPM1_ShQuUnit.TabIndex = 3
        Me.lblPM1_ShQuUnit.Text = "(kwh)"
        '
        'txtShieldsPM3
        '
        Me.txtShieldsPM3.AccessibleDescription = "PM3 Shields/Quartz"
        Me.txtShieldsPM3.BackColor = System.Drawing.SystemColors.Control
        Me.txtShieldsPM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtShieldsPM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtShieldsPM3.Location = New System.Drawing.Point(139, 137)
        Me.txtShieldsPM3.Name = "txtShieldsPM3"
        Me.txtShieldsPM3.ReadOnly = True
        Me.txtShieldsPM3.Size = New System.Drawing.Size(120, 25)
        Me.txtShieldsPM3.TabIndex = 2
        Me.txtShieldsPM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtShieldsPM2
        '
        Me.txtShieldsPM2.AccessibleDescription = "PM2 Shields/Quartz"
        Me.txtShieldsPM2.BackColor = System.Drawing.SystemColors.Control
        Me.txtShieldsPM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtShieldsPM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtShieldsPM2.Location = New System.Drawing.Point(139, 94)
        Me.txtShieldsPM2.Name = "txtShieldsPM2"
        Me.txtShieldsPM2.ReadOnly = True
        Me.txtShieldsPM2.Size = New System.Drawing.Size(120, 25)
        Me.txtShieldsPM2.TabIndex = 2
        Me.txtShieldsPM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtShieldPM1
        '
        Me.txtShieldPM1.AccessibleDescription = "PM1 Shields/Quartz"
        Me.txtShieldPM1.BackColor = System.Drawing.SystemColors.Control
        Me.txtShieldPM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtShieldPM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtShieldPM1.Location = New System.Drawing.Point(139, 52)
        Me.txtShieldPM1.Name = "txtShieldPM1"
        Me.txtShieldPM1.ReadOnly = True
        Me.txtShieldPM1.Size = New System.Drawing.Size(120, 25)
        Me.txtShieldPM1.TabIndex = 3
        Me.txtShieldPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPM3Type2
        '
        Me.lblPM3Type2.AutoSize = True
        Me.lblPM3Type2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM3Type2.ForeColor = System.Drawing.Color.Blue
        Me.lblPM3Type2.Location = New System.Drawing.Point(64, 140)
        Me.lblPM3Type2.Name = "lblPM3Type2"
        Me.lblPM3Type2.Size = New System.Drawing.Size(48, 17)
        Me.lblPM3Type2.TabIndex = 43
        Me.lblPM3Type2.Text = "(PVD)"
        '
        'lblPM2Type2
        '
        Me.lblPM2Type2.AutoSize = True
        Me.lblPM2Type2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM2Type2.ForeColor = System.Drawing.Color.Blue
        Me.lblPM2Type2.Location = New System.Drawing.Point(64, 97)
        Me.lblPM2Type2.Name = "lblPM2Type2"
        Me.lblPM2Type2.Size = New System.Drawing.Size(48, 17)
        Me.lblPM2Type2.TabIndex = 42
        Me.lblPM2Type2.Text = "(PVD)"
        '
        'lblPM1Type2
        '
        Me.lblPM1Type2.AutoSize = True
        Me.lblPM1Type2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM1Type2.ForeColor = System.Drawing.Color.Blue
        Me.lblPM1Type2.Location = New System.Drawing.Point(64, 55)
        Me.lblPM1Type2.Name = "lblPM1Type2"
        Me.lblPM1Type2.Size = New System.Drawing.Size(48, 17)
        Me.lblPM1Type2.TabIndex = 41
        Me.lblPM1Type2.Text = "(PVD)"
        '
        'lblMaxShields
        '
        Me.lblMaxShields.AutoSize = True
        Me.lblMaxShields.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaxShields.Location = New System.Drawing.Point(605, 25)
        Me.lblMaxShields.Name = "lblMaxShields"
        Me.lblMaxShields.Size = New System.Drawing.Size(38, 17)
        Me.lblMaxShields.TabIndex = 40
        Me.lblMaxShields.Text = "Max"
        '
        'lblWarningShields
        '
        Me.lblWarningShields.AutoSize = True
        Me.lblWarningShields.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarningShields.Location = New System.Drawing.Point(454, 25)
        Me.lblWarningShields.Name = "lblWarningShields"
        Me.lblWarningShields.Size = New System.Drawing.Size(62, 17)
        Me.lblWarningShields.TabIndex = 39
        Me.lblWarningShields.Text = "Warning"
        '
        'lblLimitsShields
        '
        Me.lblLimitsShields.AutoSize = True
        Me.lblLimitsShields.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLimitsShields.Location = New System.Drawing.Point(315, 25)
        Me.lblLimitsShields.Name = "lblLimitsShields"
        Me.lblLimitsShields.Size = New System.Drawing.Size(50, 17)
        Me.lblLimitsShields.TabIndex = 38
        Me.lblLimitsShields.Text = "Limits"
        '
        'txtMaxShieldsPM3
        '
        Me.txtMaxShieldsPM3.BackColor = System.Drawing.Color.White
        Me.txtMaxShieldsPM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMaxShieldsPM3.Enabled = False
        Me.txtMaxShieldsPM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxShieldsPM3.Location = New System.Drawing.Point(565, 137)
        Me.txtMaxShieldsPM3.Name = "txtMaxShieldsPM3"
        Me.txtMaxShieldsPM3.ReadOnly = True
        Me.txtMaxShieldsPM3.Size = New System.Drawing.Size(120, 25)
        Me.txtMaxShieldsPM3.TabIndex = 31
        Me.txtMaxShieldsPM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaxShieldsPM2
        '
        Me.txtMaxShieldsPM2.BackColor = System.Drawing.Color.White
        Me.txtMaxShieldsPM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMaxShieldsPM2.Enabled = False
        Me.txtMaxShieldsPM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxShieldsPM2.Location = New System.Drawing.Point(565, 94)
        Me.txtMaxShieldsPM2.Name = "txtMaxShieldsPM2"
        Me.txtMaxShieldsPM2.ReadOnly = True
        Me.txtMaxShieldsPM2.Size = New System.Drawing.Size(120, 25)
        Me.txtMaxShieldsPM2.TabIndex = 29
        Me.txtMaxShieldsPM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaxShieldsPM1
        '
        Me.txtMaxShieldsPM1.BackColor = System.Drawing.Color.White
        Me.txtMaxShieldsPM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMaxShieldsPM1.Enabled = False
        Me.txtMaxShieldsPM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxShieldsPM1.Location = New System.Drawing.Point(565, 52)
        Me.txtMaxShieldsPM1.Name = "txtMaxShieldsPM1"
        Me.txtMaxShieldsPM1.ReadOnly = True
        Me.txtMaxShieldsPM1.Size = New System.Drawing.Size(120, 25)
        Me.txtMaxShieldsPM1.TabIndex = 27
        Me.txtMaxShieldsPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWarningShieldsPM3
        '
        Me.txtWarningShieldsPM3.BackColor = System.Drawing.SystemColors.Window
        Me.txtWarningShieldsPM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWarningShieldsPM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWarningShieldsPM3.ForeColor = System.Drawing.Color.Black
        Me.txtWarningShieldsPM3.Location = New System.Drawing.Point(423, 137)
        Me.txtWarningShieldsPM3.Name = "txtWarningShieldsPM3"
        Me.txtWarningShieldsPM3.ReadOnly = True
        Me.txtWarningShieldsPM3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWarningShieldsPM3.Size = New System.Drawing.Size(120, 25)
        Me.txtWarningShieldsPM3.TabIndex = 36
        Me.txtWarningShieldsPM3.Text = "0"
        Me.txtWarningShieldsPM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWarningShieldsPM2
        '
        Me.txtWarningShieldsPM2.BackColor = System.Drawing.SystemColors.Window
        Me.txtWarningShieldsPM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWarningShieldsPM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWarningShieldsPM2.ForeColor = System.Drawing.Color.Black
        Me.txtWarningShieldsPM2.Location = New System.Drawing.Point(423, 94)
        Me.txtWarningShieldsPM2.Name = "txtWarningShieldsPM2"
        Me.txtWarningShieldsPM2.ReadOnly = True
        Me.txtWarningShieldsPM2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWarningShieldsPM2.Size = New System.Drawing.Size(120, 25)
        Me.txtWarningShieldsPM2.TabIndex = 33
        Me.txtWarningShieldsPM2.Text = "0"
        Me.txtWarningShieldsPM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWarningShieldsPM1
        '
        Me.txtWarningShieldsPM1.BackColor = System.Drawing.SystemColors.Window
        Me.txtWarningShieldsPM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWarningShieldsPM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWarningShieldsPM1.ForeColor = System.Drawing.Color.Black
        Me.txtWarningShieldsPM1.Location = New System.Drawing.Point(423, 52)
        Me.txtWarningShieldsPM1.Name = "txtWarningShieldsPM1"
        Me.txtWarningShieldsPM1.ReadOnly = True
        Me.txtWarningShieldsPM1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWarningShieldsPM1.Size = New System.Drawing.Size(120, 25)
        Me.txtWarningShieldsPM1.TabIndex = 26
        Me.txtWarningShieldsPM1.Text = "0"
        Me.txtWarningShieldsPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLimitShieldsPM3
        '
        Me.txtLimitShieldsPM3.BackColor = System.Drawing.SystemColors.Window
        Me.txtLimitShieldsPM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLimitShieldsPM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimitShieldsPM3.ForeColor = System.Drawing.Color.Black
        Me.txtLimitShieldsPM3.Location = New System.Drawing.Point(281, 137)
        Me.txtLimitShieldsPM3.Name = "txtLimitShieldsPM3"
        Me.txtLimitShieldsPM3.ReadOnly = True
        Me.txtLimitShieldsPM3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLimitShieldsPM3.Size = New System.Drawing.Size(120, 25)
        Me.txtLimitShieldsPM3.TabIndex = 24
        Me.txtLimitShieldsPM3.Text = "0"
        Me.txtLimitShieldsPM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLimitShieldsPM2
        '
        Me.txtLimitShieldsPM2.BackColor = System.Drawing.SystemColors.Window
        Me.txtLimitShieldsPM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLimitShieldsPM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimitShieldsPM2.ForeColor = System.Drawing.Color.Black
        Me.txtLimitShieldsPM2.Location = New System.Drawing.Point(281, 94)
        Me.txtLimitShieldsPM2.Name = "txtLimitShieldsPM2"
        Me.txtLimitShieldsPM2.ReadOnly = True
        Me.txtLimitShieldsPM2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLimitShieldsPM2.Size = New System.Drawing.Size(120, 25)
        Me.txtLimitShieldsPM2.TabIndex = 23
        Me.txtLimitShieldsPM2.Text = "0"
        Me.txtLimitShieldsPM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLimitShieldsPM1
        '
        Me.txtLimitShieldsPM1.BackColor = System.Drawing.SystemColors.Window
        Me.txtLimitShieldsPM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLimitShieldsPM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimitShieldsPM1.ForeColor = System.Drawing.Color.Black
        Me.txtLimitShieldsPM1.Location = New System.Drawing.Point(281, 52)
        Me.txtLimitShieldsPM1.Name = "txtLimitShieldsPM1"
        Me.txtLimitShieldsPM1.ReadOnly = True
        Me.txtLimitShieldsPM1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLimitShieldsPM1.Size = New System.Drawing.Size(120, 25)
        Me.txtLimitShieldsPM1.TabIndex = 21
        Me.txtLimitShieldsPM1.Text = "0"
        Me.txtLimitShieldsPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPM3Shields
        '
        Me.lblPM3Shields.AutoSize = True
        Me.lblPM3Shields.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM3Shields.Location = New System.Drawing.Point(26, 140)
        Me.lblPM3Shields.Name = "lblPM3Shields"
        Me.lblPM3Shields.Size = New System.Drawing.Size(40, 17)
        Me.lblPM3Shields.TabIndex = 8
        Me.lblPM3Shields.Text = "PM3"
        '
        'lblPM2Shields
        '
        Me.lblPM2Shields.AutoSize = True
        Me.lblPM2Shields.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM2Shields.Location = New System.Drawing.Point(26, 97)
        Me.lblPM2Shields.Name = "lblPM2Shields"
        Me.lblPM2Shields.Size = New System.Drawing.Size(40, 17)
        Me.lblPM2Shields.TabIndex = 7
        Me.lblPM2Shields.Text = "PM2"
        '
        'lblPM1Shields
        '
        Me.lblPM1Shields.AutoSize = True
        Me.lblPM1Shields.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM1Shields.Location = New System.Drawing.Point(26, 55)
        Me.lblPM1Shields.Name = "lblPM1Shields"
        Me.lblPM1Shields.Size = New System.Drawing.Size(40, 17)
        Me.lblPM1Shields.TabIndex = 6
        Me.lblPM1Shields.Text = "PM1"
        '
        'gbxUsage
        '
        Me.gbxUsage.Controls.Add(Me.lblPM3_UsageUnit)
        Me.gbxUsage.Controls.Add(Me.lblPM2_UsageUnit)
        Me.gbxUsage.Controls.Add(Me.lblPM1_UsageUnit)
        Me.gbxUsage.Controls.Add(Me.txtMaxKWHPM3)
        Me.gbxUsage.Controls.Add(Me.txtMaxKWHPM2)
        Me.gbxUsage.Controls.Add(Me.txtMaxKWHPM1)
        Me.gbxUsage.Controls.Add(Me.txtWarningKWH_PM3)
        Me.gbxUsage.Controls.Add(Me.txtWarningKWH_PM2)
        Me.gbxUsage.Controls.Add(Me.txtWarningKWH_PM1)
        Me.gbxUsage.Controls.Add(Me.txtLimitsKWH_PM3)
        Me.gbxUsage.Controls.Add(Me.txtLimitsKWH_PM2)
        Me.gbxUsage.Controls.Add(Me.txtLimitsKWH_PM1)
        Me.gbxUsage.Controls.Add(Me.txtUsageKWH_PM3)
        Me.gbxUsage.Controls.Add(Me.txtUsageKWH_PM2)
        Me.gbxUsage.Controls.Add(Me.txtUsageKWH_PM1)
        Me.gbxUsage.Controls.Add(Me.lblPM3Type1)
        Me.gbxUsage.Controls.Add(Me.gbxWaferCounts)
        Me.gbxUsage.Controls.Add(Me.lblPM2Type1)
        Me.gbxUsage.Controls.Add(Me.lblPM1Type1)
        Me.gbxUsage.Controls.Add(Me.gbxTargetMaterial)
        Me.gbxUsage.Controls.Add(Me.lblMaxUsage)
        Me.gbxUsage.Controls.Add(Me.lblWarningUsage)
        Me.gbxUsage.Controls.Add(Me.lblLimitsUsage)
        Me.gbxUsage.Controls.Add(Me.lblPM3)
        Me.gbxUsage.Controls.Add(Me.lblPM2)
        Me.gbxUsage.Controls.Add(Me.lblPM1)
        Me.gbxUsage.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxUsage.Location = New System.Drawing.Point(69, 8)
        Me.gbxUsage.Name = "gbxUsage"
        Me.gbxUsage.Size = New System.Drawing.Size(1139, 186)
        Me.gbxUsage.TabIndex = 56
        Me.gbxUsage.TabStop = False
        Me.gbxUsage.Text = "Usage"
        '
        'lblPM3_UsageUnit
        '
        Me.lblPM3_UsageUnit.AutoSize = True
        Me.lblPM3_UsageUnit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM3_UsageUnit.Location = New System.Drawing.Point(691, 141)
        Me.lblPM3_UsageUnit.Name = "lblPM3_UsageUnit"
        Me.lblPM3_UsageUnit.Size = New System.Drawing.Size(46, 16)
        Me.lblPM3_UsageUnit.TabIndex = 2
        Me.lblPM3_UsageUnit.Text = "(kwh)"
        '
        'lblPM2_UsageUnit
        '
        Me.lblPM2_UsageUnit.AutoSize = True
        Me.lblPM2_UsageUnit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM2_UsageUnit.Location = New System.Drawing.Point(691, 98)
        Me.lblPM2_UsageUnit.Name = "lblPM2_UsageUnit"
        Me.lblPM2_UsageUnit.Size = New System.Drawing.Size(46, 16)
        Me.lblPM2_UsageUnit.TabIndex = 2
        Me.lblPM2_UsageUnit.Text = "(kwh)"
        '
        'lblPM1_UsageUnit
        '
        Me.lblPM1_UsageUnit.AutoSize = True
        Me.lblPM1_UsageUnit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM1_UsageUnit.Location = New System.Drawing.Point(691, 56)
        Me.lblPM1_UsageUnit.Name = "lblPM1_UsageUnit"
        Me.lblPM1_UsageUnit.Size = New System.Drawing.Size(46, 16)
        Me.lblPM1_UsageUnit.TabIndex = 2
        Me.lblPM1_UsageUnit.Text = "(kwh)"
        '
        'txtMaxKWHPM3
        '
        Me.txtMaxKWHPM3.AccessibleDescription = "PM3 Max Limits"
        Me.txtMaxKWHPM3.BackColor = System.Drawing.Color.White
        Me.txtMaxKWHPM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMaxKWHPM3.Enabled = False
        Me.txtMaxKWHPM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtMaxKWHPM3.Location = New System.Drawing.Point(565, 137)
        Me.txtMaxKWHPM3.Name = "txtMaxKWHPM3"
        Me.txtMaxKWHPM3.ReadOnly = True
        Me.txtMaxKWHPM3.Size = New System.Drawing.Size(120, 25)
        Me.txtMaxKWHPM3.TabIndex = 3
        Me.txtMaxKWHPM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaxKWHPM2
        '
        Me.txtMaxKWHPM2.AccessibleDescription = "PM2 Max Limits"
        Me.txtMaxKWHPM2.BackColor = System.Drawing.Color.White
        Me.txtMaxKWHPM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMaxKWHPM2.Enabled = False
        Me.txtMaxKWHPM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtMaxKWHPM2.Location = New System.Drawing.Point(565, 94)
        Me.txtMaxKWHPM2.Name = "txtMaxKWHPM2"
        Me.txtMaxKWHPM2.ReadOnly = True
        Me.txtMaxKWHPM2.Size = New System.Drawing.Size(120, 25)
        Me.txtMaxKWHPM2.TabIndex = 3
        Me.txtMaxKWHPM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaxKWHPM1
        '
        Me.txtMaxKWHPM1.AccessibleDescription = "PM1 Max Limits"
        Me.txtMaxKWHPM1.BackColor = System.Drawing.Color.White
        Me.txtMaxKWHPM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMaxKWHPM1.Enabled = False
        Me.txtMaxKWHPM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtMaxKWHPM1.Location = New System.Drawing.Point(565, 52)
        Me.txtMaxKWHPM1.Name = "txtMaxKWHPM1"
        Me.txtMaxKWHPM1.ReadOnly = True
        Me.txtMaxKWHPM1.Size = New System.Drawing.Size(120, 25)
        Me.txtMaxKWHPM1.TabIndex = 3
        Me.txtMaxKWHPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWarningKWH_PM3
        '
        Me.txtWarningKWH_PM3.AccessibleDescription = "PM3 Warning"
        Me.txtWarningKWH_PM3.BackColor = System.Drawing.SystemColors.Window
        Me.txtWarningKWH_PM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWarningKWH_PM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtWarningKWH_PM3.ForeColor = System.Drawing.Color.Black
        Me.txtWarningKWH_PM3.Location = New System.Drawing.Point(423, 137)
        Me.txtWarningKWH_PM3.Name = "txtWarningKWH_PM3"
        Me.txtWarningKWH_PM3.ReadOnly = True
        Me.txtWarningKWH_PM3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWarningKWH_PM3.Size = New System.Drawing.Size(120, 25)
        Me.txtWarningKWH_PM3.TabIndex = 5
        Me.txtWarningKWH_PM3.Text = "0"
        Me.txtWarningKWH_PM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWarningKWH_PM2
        '
        Me.txtWarningKWH_PM2.AccessibleDescription = "PM2 Warning"
        Me.txtWarningKWH_PM2.BackColor = System.Drawing.SystemColors.Window
        Me.txtWarningKWH_PM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWarningKWH_PM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtWarningKWH_PM2.ForeColor = System.Drawing.Color.Black
        Me.txtWarningKWH_PM2.Location = New System.Drawing.Point(423, 94)
        Me.txtWarningKWH_PM2.Name = "txtWarningKWH_PM2"
        Me.txtWarningKWH_PM2.ReadOnly = True
        Me.txtWarningKWH_PM2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWarningKWH_PM2.Size = New System.Drawing.Size(120, 25)
        Me.txtWarningKWH_PM2.TabIndex = 5
        Me.txtWarningKWH_PM2.Text = "0"
        Me.txtWarningKWH_PM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWarningKWH_PM1
        '
        Me.txtWarningKWH_PM1.AccessibleDescription = "PM1 Warning"
        Me.txtWarningKWH_PM1.BackColor = System.Drawing.SystemColors.Window
        Me.txtWarningKWH_PM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWarningKWH_PM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtWarningKWH_PM1.ForeColor = System.Drawing.Color.Black
        Me.txtWarningKWH_PM1.Location = New System.Drawing.Point(423, 52)
        Me.txtWarningKWH_PM1.Name = "txtWarningKWH_PM1"
        Me.txtWarningKWH_PM1.ReadOnly = True
        Me.txtWarningKWH_PM1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWarningKWH_PM1.Size = New System.Drawing.Size(120, 25)
        Me.txtWarningKWH_PM1.TabIndex = 3
        Me.txtWarningKWH_PM1.Text = "0"
        Me.txtWarningKWH_PM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLimitsKWH_PM3
        '
        Me.txtLimitsKWH_PM3.AccessibleDescription = "PM3 Limits"
        Me.txtLimitsKWH_PM3.BackColor = System.Drawing.SystemColors.Window
        Me.txtLimitsKWH_PM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLimitsKWH_PM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtLimitsKWH_PM3.ForeColor = System.Drawing.Color.Black
        Me.txtLimitsKWH_PM3.Location = New System.Drawing.Point(281, 137)
        Me.txtLimitsKWH_PM3.Name = "txtLimitsKWH_PM3"
        Me.txtLimitsKWH_PM3.ReadOnly = True
        Me.txtLimitsKWH_PM3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLimitsKWH_PM3.Size = New System.Drawing.Size(120, 25)
        Me.txtLimitsKWH_PM3.TabIndex = 1
        Me.txtLimitsKWH_PM3.Text = "0"
        Me.txtLimitsKWH_PM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLimitsKWH_PM2
        '
        Me.txtLimitsKWH_PM2.AccessibleDescription = "PM2 Limits"
        Me.txtLimitsKWH_PM2.BackColor = System.Drawing.SystemColors.Window
        Me.txtLimitsKWH_PM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLimitsKWH_PM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtLimitsKWH_PM2.ForeColor = System.Drawing.Color.Black
        Me.txtLimitsKWH_PM2.Location = New System.Drawing.Point(281, 94)
        Me.txtLimitsKWH_PM2.Name = "txtLimitsKWH_PM2"
        Me.txtLimitsKWH_PM2.ReadOnly = True
        Me.txtLimitsKWH_PM2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLimitsKWH_PM2.Size = New System.Drawing.Size(120, 25)
        Me.txtLimitsKWH_PM2.TabIndex = 1
        Me.txtLimitsKWH_PM2.Text = "0"
        Me.txtLimitsKWH_PM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLimitsKWH_PM1
        '
        Me.txtLimitsKWH_PM1.AccessibleDescription = "PM1 Limits"
        Me.txtLimitsKWH_PM1.BackColor = System.Drawing.SystemColors.Window
        Me.txtLimitsKWH_PM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLimitsKWH_PM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtLimitsKWH_PM1.ForeColor = System.Drawing.Color.Black
        Me.txtLimitsKWH_PM1.Location = New System.Drawing.Point(281, 52)
        Me.txtLimitsKWH_PM1.Name = "txtLimitsKWH_PM1"
        Me.txtLimitsKWH_PM1.ReadOnly = True
        Me.txtLimitsKWH_PM1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLimitsKWH_PM1.Size = New System.Drawing.Size(120, 25)
        Me.txtLimitsKWH_PM1.TabIndex = 1
        Me.txtLimitsKWH_PM1.Text = "0"
        Me.txtLimitsKWH_PM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUsageKWH_PM3
        '
        Me.txtUsageKWH_PM3.AccessibleDescription = "PM3 Usage"
        Me.txtUsageKWH_PM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtUsageKWH_PM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtUsageKWH_PM3.Location = New System.Drawing.Point(139, 137)
        Me.txtUsageKWH_PM3.Name = "txtUsageKWH_PM3"
        Me.txtUsageKWH_PM3.ReadOnly = True
        Me.txtUsageKWH_PM3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUsageKWH_PM3.Size = New System.Drawing.Size(120, 25)
        Me.txtUsageKWH_PM3.TabIndex = 1
        Me.txtUsageKWH_PM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUsageKWH_PM2
        '
        Me.txtUsageKWH_PM2.AccessibleDescription = "PM2 Usage"
        Me.txtUsageKWH_PM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtUsageKWH_PM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtUsageKWH_PM2.Location = New System.Drawing.Point(139, 94)
        Me.txtUsageKWH_PM2.Name = "txtUsageKWH_PM2"
        Me.txtUsageKWH_PM2.ReadOnly = True
        Me.txtUsageKWH_PM2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUsageKWH_PM2.Size = New System.Drawing.Size(120, 25)
        Me.txtUsageKWH_PM2.TabIndex = 1
        Me.txtUsageKWH_PM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUsageKWH_PM1
        '
        Me.txtUsageKWH_PM1.AccessibleDescription = "PM1 Usage"
        Me.txtUsageKWH_PM1.BackColor = System.Drawing.SystemColors.Control
        Me.txtUsageKWH_PM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtUsageKWH_PM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtUsageKWH_PM1.Location = New System.Drawing.Point(139, 52)
        Me.txtUsageKWH_PM1.Name = "txtUsageKWH_PM1"
        Me.txtUsageKWH_PM1.ReadOnly = True
        Me.txtUsageKWH_PM1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUsageKWH_PM1.Size = New System.Drawing.Size(120, 25)
        Me.txtUsageKWH_PM1.TabIndex = 1
        Me.txtUsageKWH_PM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPM3Type1
        '
        Me.lblPM3Type1.AutoSize = True
        Me.lblPM3Type1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM3Type1.ForeColor = System.Drawing.Color.Blue
        Me.lblPM3Type1.Location = New System.Drawing.Point(64, 140)
        Me.lblPM3Type1.Name = "lblPM3Type1"
        Me.lblPM3Type1.Size = New System.Drawing.Size(48, 17)
        Me.lblPM3Type1.TabIndex = 22
        Me.lblPM3Type1.Text = "(PVD)"
        '
        'gbxWaferCounts
        '
        Me.gbxWaferCounts.Controls.Add(Me.txtWaferCountPM2)
        Me.gbxWaferCounts.Controls.Add(Me.txtWaferCountPM3)
        Me.gbxWaferCounts.Controls.Add(Me.txtWaferCountPM1)
        Me.gbxWaferCounts.Controls.Add(Me.lblWaferCounts)
        Me.gbxWaferCounts.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxWaferCounts.Location = New System.Drawing.Point(940, 7)
        Me.gbxWaferCounts.Name = "gbxWaferCounts"
        Me.gbxWaferCounts.Size = New System.Drawing.Size(172, 172)
        Me.gbxWaferCounts.TabIndex = 61
        Me.gbxWaferCounts.TabStop = False
        '
        'txtWaferCountPM2
        '
        Me.txtWaferCountPM2.BackColor = System.Drawing.Color.White
        Me.txtWaferCountPM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWaferCountPM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtWaferCountPM2.Location = New System.Drawing.Point(27, 87)
        Me.txtWaferCountPM2.Name = "txtWaferCountPM2"
        Me.txtWaferCountPM2.ReadOnly = True
        Me.txtWaferCountPM2.Size = New System.Drawing.Size(120, 25)
        Me.txtWaferCountPM2.TabIndex = 2
        Me.txtWaferCountPM2.Text = "0"
        Me.txtWaferCountPM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWaferCountPM3
        '
        Me.txtWaferCountPM3.BackColor = System.Drawing.Color.White
        Me.txtWaferCountPM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWaferCountPM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtWaferCountPM3.Location = New System.Drawing.Point(26, 130)
        Me.txtWaferCountPM3.Name = "txtWaferCountPM3"
        Me.txtWaferCountPM3.ReadOnly = True
        Me.txtWaferCountPM3.Size = New System.Drawing.Size(120, 25)
        Me.txtWaferCountPM3.TabIndex = 2
        Me.txtWaferCountPM3.Text = "0"
        Me.txtWaferCountPM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWaferCountPM1
        '
        Me.txtWaferCountPM1.BackColor = System.Drawing.Color.White
        Me.txtWaferCountPM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWaferCountPM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtWaferCountPM1.Location = New System.Drawing.Point(26, 45)
        Me.txtWaferCountPM1.Name = "txtWaferCountPM1"
        Me.txtWaferCountPM1.ReadOnly = True
        Me.txtWaferCountPM1.Size = New System.Drawing.Size(120, 25)
        Me.txtWaferCountPM1.TabIndex = 2
        Me.txtWaferCountPM1.Text = "0"
        Me.txtWaferCountPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblWaferCounts
        '
        Me.lblWaferCounts.AutoSize = True
        Me.lblWaferCounts.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaferCounts.Location = New System.Drawing.Point(36, 18)
        Me.lblWaferCounts.Name = "lblWaferCounts"
        Me.lblWaferCounts.Size = New System.Drawing.Size(97, 17)
        Me.lblWaferCounts.TabIndex = 40
        Me.lblWaferCounts.Text = "Wafer Counts"
        '
        'lblPM2Type1
        '
        Me.lblPM2Type1.AutoSize = True
        Me.lblPM2Type1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM2Type1.ForeColor = System.Drawing.Color.Blue
        Me.lblPM2Type1.Location = New System.Drawing.Point(64, 97)
        Me.lblPM2Type1.Name = "lblPM2Type1"
        Me.lblPM2Type1.Size = New System.Drawing.Size(48, 17)
        Me.lblPM2Type1.TabIndex = 21
        Me.lblPM2Type1.Text = "(PVD)"
        '
        'lblPM1Type1
        '
        Me.lblPM1Type1.AutoSize = True
        Me.lblPM1Type1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM1Type1.ForeColor = System.Drawing.Color.Blue
        Me.lblPM1Type1.Location = New System.Drawing.Point(64, 55)
        Me.lblPM1Type1.Name = "lblPM1Type1"
        Me.lblPM1Type1.Size = New System.Drawing.Size(48, 17)
        Me.lblPM1Type1.TabIndex = 20
        Me.lblPM1Type1.Text = "(PVD)"
        '
        'gbxTargetMaterial
        '
        Me.gbxTargetMaterial.Controls.Add(Me.txtTarMaterialPM3)
        Me.gbxTargetMaterial.Controls.Add(Me.txtTarMaterialPM2)
        Me.gbxTargetMaterial.Controls.Add(Me.txtTarMaterialPM1)
        Me.gbxTargetMaterial.Controls.Add(Me.lblTargetMaterial)
        Me.gbxTargetMaterial.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxTargetMaterial.Location = New System.Drawing.Point(762, 7)
        Me.gbxTargetMaterial.Name = "gbxTargetMaterial"
        Me.gbxTargetMaterial.Size = New System.Drawing.Size(172, 172)
        Me.gbxTargetMaterial.TabIndex = 59
        Me.gbxTargetMaterial.TabStop = False
        '
        'txtTarMaterialPM3
        '
        Me.txtTarMaterialPM3.AccessibleDescription = "PM3 Target Material"
        Me.txtTarMaterialPM3.BackColor = System.Drawing.SystemColors.Window
        Me.txtTarMaterialPM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTarMaterialPM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTarMaterialPM3.ForeColor = System.Drawing.Color.Black
        Me.txtTarMaterialPM3.Location = New System.Drawing.Point(26, 130)
        Me.txtTarMaterialPM3.Name = "txtTarMaterialPM3"
        Me.txtTarMaterialPM3.ReadOnly = True
        Me.txtTarMaterialPM3.Size = New System.Drawing.Size(120, 25)
        Me.txtTarMaterialPM3.TabIndex = 1
        Me.txtTarMaterialPM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTarMaterialPM2
        '
        Me.txtTarMaterialPM2.AccessibleDescription = "PM2 Target Material"
        Me.txtTarMaterialPM2.BackColor = System.Drawing.SystemColors.Window
        Me.txtTarMaterialPM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTarMaterialPM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTarMaterialPM2.ForeColor = System.Drawing.Color.Black
        Me.txtTarMaterialPM2.Location = New System.Drawing.Point(26, 87)
        Me.txtTarMaterialPM2.Name = "txtTarMaterialPM2"
        Me.txtTarMaterialPM2.ReadOnly = True
        Me.txtTarMaterialPM2.Size = New System.Drawing.Size(120, 25)
        Me.txtTarMaterialPM2.TabIndex = 1
        Me.txtTarMaterialPM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTarMaterialPM1
        '
        Me.txtTarMaterialPM1.AccessibleDescription = "PM1 Target Material"
        Me.txtTarMaterialPM1.BackColor = System.Drawing.SystemColors.Window
        Me.txtTarMaterialPM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTarMaterialPM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtTarMaterialPM1.ForeColor = System.Drawing.Color.Black
        Me.txtTarMaterialPM1.Location = New System.Drawing.Point(26, 45)
        Me.txtTarMaterialPM1.Name = "txtTarMaterialPM1"
        Me.txtTarMaterialPM1.ReadOnly = True
        Me.txtTarMaterialPM1.Size = New System.Drawing.Size(120, 25)
        Me.txtTarMaterialPM1.TabIndex = 1
        Me.txtTarMaterialPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTargetMaterial
        '
        Me.lblTargetMaterial.AutoSize = True
        Me.lblTargetMaterial.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetMaterial.Location = New System.Drawing.Point(29, 18)
        Me.lblTargetMaterial.Name = "lblTargetMaterial"
        Me.lblTargetMaterial.Size = New System.Drawing.Size(111, 17)
        Me.lblTargetMaterial.TabIndex = 19
        Me.lblTargetMaterial.Text = "Target Material"
        '
        'lblMaxUsage
        '
        Me.lblMaxUsage.AutoSize = True
        Me.lblMaxUsage.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaxUsage.Location = New System.Drawing.Point(605, 25)
        Me.lblMaxUsage.Name = "lblMaxUsage"
        Me.lblMaxUsage.Size = New System.Drawing.Size(38, 17)
        Me.lblMaxUsage.TabIndex = 19
        Me.lblMaxUsage.Text = "Max"
        '
        'lblWarningUsage
        '
        Me.lblWarningUsage.AutoSize = True
        Me.lblWarningUsage.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarningUsage.Location = New System.Drawing.Point(454, 25)
        Me.lblWarningUsage.Name = "lblWarningUsage"
        Me.lblWarningUsage.Size = New System.Drawing.Size(62, 17)
        Me.lblWarningUsage.TabIndex = 18
        Me.lblWarningUsage.Text = "Warning"
        '
        'lblLimitsUsage
        '
        Me.lblLimitsUsage.AutoSize = True
        Me.lblLimitsUsage.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLimitsUsage.Location = New System.Drawing.Point(315, 25)
        Me.lblLimitsUsage.Name = "lblLimitsUsage"
        Me.lblLimitsUsage.Size = New System.Drawing.Size(50, 17)
        Me.lblLimitsUsage.TabIndex = 17
        Me.lblLimitsUsage.Text = "Limits"
        '
        'lblPM3
        '
        Me.lblPM3.AutoSize = True
        Me.lblPM3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM3.Location = New System.Drawing.Point(26, 140)
        Me.lblPM3.Name = "lblPM3"
        Me.lblPM3.Size = New System.Drawing.Size(40, 17)
        Me.lblPM3.TabIndex = 8
        Me.lblPM3.Text = "PM3"
        '
        'lblPM2
        '
        Me.lblPM2.AutoSize = True
        Me.lblPM2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM2.Location = New System.Drawing.Point(26, 97)
        Me.lblPM2.Name = "lblPM2"
        Me.lblPM2.Size = New System.Drawing.Size(40, 17)
        Me.lblPM2.TabIndex = 7
        Me.lblPM2.Text = "PM2"
        '
        'lblPM1
        '
        Me.lblPM1.AutoSize = True
        Me.lblPM1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM1.Location = New System.Drawing.Point(26, 55)
        Me.lblPM1.Name = "lblPM1"
        Me.lblPM1.Size = New System.Drawing.Size(40, 17)
        Me.lblPM1.TabIndex = 6
        Me.lblPM1.Text = "PM1"
        '
        'gbxCalculationType
        '
        Me.gbxCalculationType.Controls.Add(Me.rbUseMaxKWH)
        Me.gbxCalculationType.Controls.Add(Me.rbUseAbsoluteKWH)
        Me.gbxCalculationType.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxCalculationType.ForeColor = System.Drawing.Color.Black
        Me.gbxCalculationType.Location = New System.Drawing.Point(69, 391)
        Me.gbxCalculationType.Name = "gbxCalculationType"
        Me.gbxCalculationType.Size = New System.Drawing.Size(836, 70)
        Me.gbxCalculationType.TabIndex = 20
        Me.gbxCalculationType.TabStop = False
        Me.gbxCalculationType.Text = "Calculation Type"
        '
        'rbUseMaxKWH
        '
        Me.rbUseMaxKWH.AutoSize = True
        Me.rbUseMaxKWH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbUseMaxKWH.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.rbUseMaxKWH.Location = New System.Drawing.Point(50, 33)
        Me.rbUseMaxKWH.Name = "rbUseMaxKWH"
        Me.rbUseMaxKWH.Size = New System.Drawing.Size(132, 21)
        Me.rbUseMaxKWH.TabIndex = 19
        Me.rbUseMaxKWH.TabStop = True
        Me.rbUseMaxKWH.Text = "Use Max Limits"
        Me.rbUseMaxKWH.UseVisualStyleBackColor = True
        '
        'rbUseAbsoluteKWH
        '
        Me.rbUseAbsoluteKWH.AutoSize = True
        Me.rbUseAbsoluteKWH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbUseAbsoluteKWH.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.rbUseAbsoluteKWH.Location = New System.Drawing.Point(50, 33)
        Me.rbUseAbsoluteKWH.Name = "rbUseAbsoluteKWH"
        Me.rbUseAbsoluteKWH.Size = New System.Drawing.Size(160, 21)
        Me.rbUseAbsoluteKWH.TabIndex = 19
        Me.rbUseAbsoluteKWH.TabStop = True
        Me.rbUseAbsoluteKWH.Text = "Use Absolute Limits"
        Me.rbUseAbsoluteKWH.UseVisualStyleBackColor = True
        '
        'tabTimeOut
        '
        Me.tabTimeOut.Controls.Add(Me.pnlTimeOut)
        Me.tabTimeOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabTimeOut.Location = New System.Drawing.Point(0, 29)
        Me.tabTimeOut.Name = "tabTimeOut"
        Me.tabTimeOut.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTimeOut.Size = New System.Drawing.Size(1280, 727)
        Me.tabTimeOut.TabIndex = 9
        Me.tabTimeOut.Text = "TimeOut"
        Me.tabTimeOut.UseVisualStyleBackColor = True
        '
        'pnlTimeOut
        '
        Me.pnlTimeOut.Controls.Add(Me.GroupBox7)
        Me.pnlTimeOut.Controls.Add(Me.btnApplyTimeOut)
        Me.pnlTimeOut.Controls.Add(Me.GroupBox5)
        Me.pnlTimeOut.Controls.Add(Me.GroupBox6)
        Me.pnlTimeOut.Controls.Add(Me.GroupBox2)
        Me.pnlTimeOut.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pnlTimeOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTimeOut.Location = New System.Drawing.Point(3, 3)
        Me.pnlTimeOut.Name = "pnlTimeOut"
        Me.pnlTimeOut.Size = New System.Drawing.Size(1274, 721)
        Me.pnlTimeOut.TabIndex = 20
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtTransferSetPointWaitTimeInSeconds)
        Me.GroupBox7.Controls.Add(Me.Label28)
        Me.GroupBox7.Controls.Add(Me.txtAutoLog)
        Me.GroupBox7.Controls.Add(Me.Label36)
        Me.GroupBox7.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(875, 24)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(381, 107)
        Me.GroupBox7.TabIndex = 21
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "General Configuration (Mins)"
        '
        'txtTransferSetPointWaitTimeInSeconds
        '
        Me.txtTransferSetPointWaitTimeInSeconds.AccessibleDescription = "Transfer set point Wait Time"
        Me.txtTransferSetPointWaitTimeInSeconds.BackColor = System.Drawing.SystemColors.Window
        Me.txtTransferSetPointWaitTimeInSeconds.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTransferSetPointWaitTimeInSeconds.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransferSetPointWaitTimeInSeconds.Location = New System.Drawing.Point(250, 70)
        Me.txtTransferSetPointWaitTimeInSeconds.Name = "txtTransferSetPointWaitTimeInSeconds"
        Me.txtTransferSetPointWaitTimeInSeconds.ReadOnly = True
        Me.txtTransferSetPointWaitTimeInSeconds.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTransferSetPointWaitTimeInSeconds.Size = New System.Drawing.Size(91, 25)
        Me.txtTransferSetPointWaitTimeInSeconds.TabIndex = 6
        Me.txtTransferSetPointWaitTimeInSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(32, 73)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(197, 17)
        Me.Label28.TabIndex = 5
        Me.Label28.Text = "Transfer Set Point Wait Time"
        '
        'txtAutoLog
        '
        Me.txtAutoLog.AccessibleDescription = "Auto LogOut TimeOut"
        Me.txtAutoLog.BackColor = System.Drawing.SystemColors.Window
        Me.txtAutoLog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtAutoLog.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutoLog.Location = New System.Drawing.Point(250, 39)
        Me.txtAutoLog.Name = "txtAutoLog"
        Me.txtAutoLog.ReadOnly = True
        Me.txtAutoLog.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAutoLog.Size = New System.Drawing.Size(91, 25)
        Me.txtAutoLog.TabIndex = 4
        Me.txtAutoLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(32, 42)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(158, 17)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "Auto LogOut TimeOut"
        '
        'btnApplyTimeOut
        '
        Me.btnApplyTimeOut.BackColor = System.Drawing.SystemColors.Info
        Me.btnApplyTimeOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplyTimeOut.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApplyTimeOut.Location = New System.Drawing.Point(539, 551)
        Me.btnApplyTimeOut.Name = "btnApplyTimeOut"
        Me.btnApplyTimeOut.Size = New System.Drawing.Size(179, 49)
        Me.btnApplyTimeOut.TabIndex = 24
        Me.btnApplyTimeOut.Text = "Apply"
        Me.btnApplyTimeOut.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtDegasWaitTimeLLA)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.txtLLContinueVent)
        Me.GroupBox5.Controls.Add(Me.txtLLDelayTimeTurnOnIG)
        Me.GroupBox5.Controls.Add(Me.txtLLVentValveTO)
        Me.GroupBox5.Controls.Add(Me.txtLLContinuePumpDown)
        Me.GroupBox5.Controls.Add(Me.txtLLRoughValveTO)
        Me.GroupBox5.Controls.Add(Me.txtLLAFastVentTO)
        Me.GroupBox5.Controls.Add(Me.txtLLAFastRoughTO)
        Me.GroupBox5.Controls.Add(Me.txtLLASlowVentTO)
        Me.GroupBox5.Controls.Add(Me.txtLLASlowRoughTO)
        Me.GroupBox5.Controls.Add(Me.Label45)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(15, 147)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1241, 221)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Load Lock Configuration (Secs)"
        '
        'txtDegasWaitTimeLLA
        '
        Me.txtDegasWaitTimeLLA.AccessibleDescription = "LLA Degas Wait Time"
        Me.txtDegasWaitTimeLLA.BackColor = System.Drawing.SystemColors.Window
        Me.txtDegasWaitTimeLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtDegasWaitTimeLLA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDegasWaitTimeLLA.Location = New System.Drawing.Point(1110, 43)
        Me.txtDegasWaitTimeLLA.Name = "txtDegasWaitTimeLLA"
        Me.txtDegasWaitTimeLLA.ReadOnly = True
        Me.txtDegasWaitTimeLLA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDegasWaitTimeLLA.Size = New System.Drawing.Size(91, 25)
        Me.txtDegasWaitTimeLLA.TabIndex = 15
        Me.txtDegasWaitTimeLLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(893, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(161, 17)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "LLA Degas Wait Times"
        '
        'txtLLContinueVent
        '
        Me.txtLLContinueVent.AccessibleDescription = "LL Continue To Vent"
        Me.txtLLContinueVent.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLContinueVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLContinueVent.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLContinueVent.Location = New System.Drawing.Point(739, 147)
        Me.txtLLContinueVent.Name = "txtLLContinueVent"
        Me.txtLLContinueVent.ReadOnly = True
        Me.txtLLContinueVent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLLContinueVent.Size = New System.Drawing.Size(91, 25)
        Me.txtLLContinueVent.TabIndex = 2
        Me.txtLLContinueVent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLLDelayTimeTurnOnIG
        '
        Me.txtLLDelayTimeTurnOnIG.AccessibleDescription = "Delay Time Before Turn On IG"
        Me.txtLLDelayTimeTurnOnIG.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLDelayTimeTurnOnIG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLDelayTimeTurnOnIG.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLDelayTimeTurnOnIG.Location = New System.Drawing.Point(301, 182)
        Me.txtLLDelayTimeTurnOnIG.Name = "txtLLDelayTimeTurnOnIG"
        Me.txtLLDelayTimeTurnOnIG.ReadOnly = True
        Me.txtLLDelayTimeTurnOnIG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLLDelayTimeTurnOnIG.Size = New System.Drawing.Size(91, 25)
        Me.txtLLDelayTimeTurnOnIG.TabIndex = 2
        Me.txtLLDelayTimeTurnOnIG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLLVentValveTO
        '
        Me.txtLLVentValveTO.AccessibleDescription = "LL Vent Valve Open Close TimeOut"
        Me.txtLLVentValveTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLVentValveTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLVentValveTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLVentValveTO.Location = New System.Drawing.Point(739, 112)
        Me.txtLLVentValveTO.Name = "txtLLVentValveTO"
        Me.txtLLVentValveTO.ReadOnly = True
        Me.txtLLVentValveTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLLVentValveTO.Size = New System.Drawing.Size(91, 25)
        Me.txtLLVentValveTO.TabIndex = 2
        Me.txtLLVentValveTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLLContinuePumpDown
        '
        Me.txtLLContinuePumpDown.AccessibleDescription = "LL Continue To Rough"
        Me.txtLLContinuePumpDown.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLContinuePumpDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLContinuePumpDown.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLContinuePumpDown.Location = New System.Drawing.Point(301, 147)
        Me.txtLLContinuePumpDown.Name = "txtLLContinuePumpDown"
        Me.txtLLContinuePumpDown.ReadOnly = True
        Me.txtLLContinuePumpDown.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLLContinuePumpDown.Size = New System.Drawing.Size(91, 25)
        Me.txtLLContinuePumpDown.TabIndex = 2
        Me.txtLLContinuePumpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLLRoughValveTO
        '
        Me.txtLLRoughValveTO.AccessibleDescription = "LL Rough Valve Open Close TimeOut"
        Me.txtLLRoughValveTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLRoughValveTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLRoughValveTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLRoughValveTO.Location = New System.Drawing.Point(301, 112)
        Me.txtLLRoughValveTO.Name = "txtLLRoughValveTO"
        Me.txtLLRoughValveTO.ReadOnly = True
        Me.txtLLRoughValveTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLLRoughValveTO.Size = New System.Drawing.Size(91, 25)
        Me.txtLLRoughValveTO.TabIndex = 2
        Me.txtLLRoughValveTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLLAFastVentTO
        '
        Me.txtLLAFastVentTO.AccessibleDescription = "LLA Fast Vent TimeOut"
        Me.txtLLAFastVentTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLAFastVentTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLAFastVentTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLAFastVentTO.Location = New System.Drawing.Point(739, 77)
        Me.txtLLAFastVentTO.Name = "txtLLAFastVentTO"
        Me.txtLLAFastVentTO.ReadOnly = True
        Me.txtLLAFastVentTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLLAFastVentTO.Size = New System.Drawing.Size(91, 25)
        Me.txtLLAFastVentTO.TabIndex = 2
        Me.txtLLAFastVentTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLLAFastRoughTO
        '
        Me.txtLLAFastRoughTO.AccessibleDescription = "LLA Fast Rough Pressure TimeOut"
        Me.txtLLAFastRoughTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLAFastRoughTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLAFastRoughTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLAFastRoughTO.Location = New System.Drawing.Point(301, 77)
        Me.txtLLAFastRoughTO.Name = "txtLLAFastRoughTO"
        Me.txtLLAFastRoughTO.ReadOnly = True
        Me.txtLLAFastRoughTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLLAFastRoughTO.Size = New System.Drawing.Size(91, 25)
        Me.txtLLAFastRoughTO.TabIndex = 2
        Me.txtLLAFastRoughTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLLASlowVentTO
        '
        Me.txtLLASlowVentTO.AccessibleDescription = "LLA Slow Vent TimeOut"
        Me.txtLLASlowVentTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLASlowVentTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLASlowVentTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLASlowVentTO.Location = New System.Drawing.Point(739, 43)
        Me.txtLLASlowVentTO.Name = "txtLLASlowVentTO"
        Me.txtLLASlowVentTO.ReadOnly = True
        Me.txtLLASlowVentTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLLASlowVentTO.Size = New System.Drawing.Size(91, 25)
        Me.txtLLASlowVentTO.TabIndex = 2
        Me.txtLLASlowVentTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLLASlowRoughTO
        '
        Me.txtLLASlowRoughTO.AccessibleDescription = "LLA Slow Rough Pressure TimeOut"
        Me.txtLLASlowRoughTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtLLASlowRoughTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLASlowRoughTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLASlowRoughTO.Location = New System.Drawing.Point(301, 43)
        Me.txtLLASlowRoughTO.Name = "txtLLASlowRoughTO"
        Me.txtLLASlowRoughTO.ReadOnly = True
        Me.txtLLASlowRoughTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLLASlowRoughTO.Size = New System.Drawing.Size(91, 25)
        Me.txtLLASlowRoughTO.TabIndex = 2
        Me.txtLLASlowRoughTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(13, 185)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(212, 17)
        Me.Label45.TabIndex = 0
        Me.Label45.Text = "Delay Time Before Turn On IG"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(13, 150)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(159, 17)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "LL Continue To Rough"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(451, 150)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(146, 17)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "LL Continue To Vent"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(13, 115)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(259, 17)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "LL Rough Valve Open Close TimeOut"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(451, 115)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(246, 17)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "LL Vent Valve Open Close TimeOut"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(13, 80)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(243, 17)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "LLA Fast Rough Pressure TimeOut"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(451, 80)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(167, 17)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "LLA Fast Vent TimeOut"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(13, 46)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(245, 17)
        Me.Label35.TabIndex = 0
        Me.Label35.Text = "LLA Slow Rough Pressure TimeOut"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(451, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "LLA Slow Vent TimeOut"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtDegasWaitTimeTM)
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.txtTMDelayTimeTurnOnIG)
        Me.GroupBox6.Controls.Add(Me.txtTMVentValveTO)
        Me.GroupBox6.Controls.Add(Me.txtTMContinuePumpDown)
        Me.GroupBox6.Controls.Add(Me.txtTMContinueVent)
        Me.GroupBox6.Controls.Add(Me.txtTMRoughTO)
        Me.GroupBox6.Controls.Add(Me.txtTMVentTO)
        Me.GroupBox6.Controls.Add(Me.Label49)
        Me.GroupBox6.Controls.Add(Me.Label46)
        Me.GroupBox6.Controls.Add(Me.Label47)
        Me.GroupBox6.Controls.Add(Me.Label50)
        Me.GroupBox6.Controls.Add(Me.Label48)
        Me.GroupBox6.Controls.Add(Me.Label51)
        Me.GroupBox6.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(15, 385)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1241, 143)
        Me.GroupBox6.TabIndex = 21
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Transfer Module Configuration (Secs)"
        '
        'txtDegasWaitTimeTM
        '
        Me.txtDegasWaitTimeTM.AccessibleDescription = "TM Degas Wait Time"
        Me.txtDegasWaitTimeTM.BackColor = System.Drawing.SystemColors.Window
        Me.txtDegasWaitTimeTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtDegasWaitTimeTM.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDegasWaitTimeTM.Location = New System.Drawing.Point(1110, 38)
        Me.txtDegasWaitTimeTM.Name = "txtDegasWaitTimeTM"
        Me.txtDegasWaitTimeTM.ReadOnly = True
        Me.txtDegasWaitTimeTM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDegasWaitTimeTM.Size = New System.Drawing.Size(91, 25)
        Me.txtDegasWaitTimeTM.TabIndex = 4
        Me.txtDegasWaitTimeTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(893, 41)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(156, 17)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "TM Degas Wait Times"
        '
        'txtTMDelayTimeTurnOnIG
        '
        Me.txtTMDelayTimeTurnOnIG.AccessibleDescription = "Delay Time Before Turn On IG"
        Me.txtTMDelayTimeTurnOnIG.BackColor = System.Drawing.SystemColors.Window
        Me.txtTMDelayTimeTurnOnIG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTMDelayTimeTurnOnIG.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTMDelayTimeTurnOnIG.Location = New System.Drawing.Point(301, 109)
        Me.txtTMDelayTimeTurnOnIG.Name = "txtTMDelayTimeTurnOnIG"
        Me.txtTMDelayTimeTurnOnIG.ReadOnly = True
        Me.txtTMDelayTimeTurnOnIG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTMDelayTimeTurnOnIG.Size = New System.Drawing.Size(91, 25)
        Me.txtTMDelayTimeTurnOnIG.TabIndex = 2
        Me.txtTMDelayTimeTurnOnIG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTMVentValveTO
        '
        Me.txtTMVentValveTO.AccessibleDescription = "TM Vent Valve Open Close TimeOut"
        Me.txtTMVentValveTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTMVentValveTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTMVentValveTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTMVentValveTO.Location = New System.Drawing.Point(739, 106)
        Me.txtTMVentValveTO.Name = "txtTMVentValveTO"
        Me.txtTMVentValveTO.ReadOnly = True
        Me.txtTMVentValveTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTMVentValveTO.Size = New System.Drawing.Size(91, 25)
        Me.txtTMVentValveTO.TabIndex = 2
        Me.txtTMVentValveTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTMContinuePumpDown
        '
        Me.txtTMContinuePumpDown.AccessibleDescription = "TM Continue To Rough"
        Me.txtTMContinuePumpDown.BackColor = System.Drawing.SystemColors.Window
        Me.txtTMContinuePumpDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTMContinuePumpDown.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTMContinuePumpDown.Location = New System.Drawing.Point(301, 75)
        Me.txtTMContinuePumpDown.Name = "txtTMContinuePumpDown"
        Me.txtTMContinuePumpDown.ReadOnly = True
        Me.txtTMContinuePumpDown.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTMContinuePumpDown.Size = New System.Drawing.Size(91, 25)
        Me.txtTMContinuePumpDown.TabIndex = 2
        Me.txtTMContinuePumpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTMContinueVent
        '
        Me.txtTMContinueVent.AccessibleDescription = "TM Continue To Vent"
        Me.txtTMContinueVent.BackColor = System.Drawing.SystemColors.Window
        Me.txtTMContinueVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTMContinueVent.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTMContinueVent.Location = New System.Drawing.Point(739, 72)
        Me.txtTMContinueVent.Name = "txtTMContinueVent"
        Me.txtTMContinueVent.ReadOnly = True
        Me.txtTMContinueVent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTMContinueVent.Size = New System.Drawing.Size(91, 25)
        Me.txtTMContinueVent.TabIndex = 2
        Me.txtTMContinueVent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTMRoughTO
        '
        Me.txtTMRoughTO.AccessibleDescription = "TM Rough TimeOut"
        Me.txtTMRoughTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTMRoughTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTMRoughTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTMRoughTO.Location = New System.Drawing.Point(301, 41)
        Me.txtTMRoughTO.Name = "txtTMRoughTO"
        Me.txtTMRoughTO.ReadOnly = True
        Me.txtTMRoughTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTMRoughTO.Size = New System.Drawing.Size(91, 25)
        Me.txtTMRoughTO.TabIndex = 2
        Me.txtTMRoughTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTMVentTO
        '
        Me.txtTMVentTO.AccessibleDescription = "TM Vent TimeOut"
        Me.txtTMVentTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTMVentTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTMVentTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTMVentTO.Location = New System.Drawing.Point(739, 38)
        Me.txtTMVentTO.Name = "txtTMVentTO"
        Me.txtTMVentTO.ReadOnly = True
        Me.txtTMVentTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTMVentTO.Size = New System.Drawing.Size(91, 25)
        Me.txtTMVentTO.TabIndex = 2
        Me.txtTMVentTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(451, 75)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(152, 17)
        Me.Label49.TabIndex = 0
        Me.Label49.Text = "TM Continue To Vent"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(13, 78)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(165, 17)
        Me.Label46.TabIndex = 0
        Me.Label46.Text = "TM Continue To Rough"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(13, 112)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(212, 17)
        Me.Label47.TabIndex = 0
        Me.Label47.Text = "Delay Time Before Turn On IG"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(451, 109)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(252, 17)
        Me.Label50.TabIndex = 0
        Me.Label50.Text = "TM Vent Valve Open Close TimeOut"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(13, 44)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(143, 17)
        Me.Label48.TabIndex = 0
        Me.Label48.Text = "TM Rough TimeOut"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(451, 41)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(130, 17)
        Me.Label51.TabIndex = 0
        Me.Label51.Text = "TM Vent TimeOut"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtHivacTO)
        Me.GroupBox2.Controls.Add(Me.txtIGOnOffTO)
        Me.GroupBox2.Controls.Add(Me.txtMesaValveTO)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtSystemCheckSensor)
        Me.GroupBox2.Controls.Add(Me.Label59)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(841, 107)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "General Configuration (Secs)"
        '
        'txtHivacTO
        '
        Me.txtHivacTO.AccessibleDescription = "HiVac Open/Closed TimeOut"
        Me.txtHivacTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtHivacTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtHivacTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHivacTO.Location = New System.Drawing.Point(739, 39)
        Me.txtHivacTO.Name = "txtHivacTO"
        Me.txtHivacTO.ReadOnly = True
        Me.txtHivacTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHivacTO.Size = New System.Drawing.Size(91, 25)
        Me.txtHivacTO.TabIndex = 2
        Me.txtHivacTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIGOnOffTO
        '
        Me.txtIGOnOffTO.AccessibleDescription = "IG On/Off TimeOut"
        Me.txtIGOnOffTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtIGOnOffTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtIGOnOffTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIGOnOffTO.Location = New System.Drawing.Point(301, 72)
        Me.txtIGOnOffTO.Name = "txtIGOnOffTO"
        Me.txtIGOnOffTO.ReadOnly = True
        Me.txtIGOnOffTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIGOnOffTO.Size = New System.Drawing.Size(91, 25)
        Me.txtIGOnOffTO.TabIndex = 2
        Me.txtIGOnOffTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMesaValveTO
        '
        Me.txtMesaValveTO.AccessibleDescription = "Mesa Valve Open/Closed TimeOut"
        Me.txtMesaValveTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtMesaValveTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMesaValveTO.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesaValveTO.Location = New System.Drawing.Point(301, 39)
        Me.txtMesaValveTO.Name = "txtMesaValveTO"
        Me.txtMesaValveTO.ReadOnly = True
        Me.txtMesaValveTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMesaValveTO.Size = New System.Drawing.Size(91, 25)
        Me.txtMesaValveTO.TabIndex = 2
        Me.txtMesaValveTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(451, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(200, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "HiVac Open/Closed TimeOut"
        '
        'txtSystemCheckSensor
        '
        Me.txtSystemCheckSensor.AccessibleDescription = "System Wait For Check Sensor"
        Me.txtSystemCheckSensor.BackColor = System.Drawing.SystemColors.Window
        Me.txtSystemCheckSensor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSystemCheckSensor.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSystemCheckSensor.Location = New System.Drawing.Point(739, 72)
        Me.txtSystemCheckSensor.Name = "txtSystemCheckSensor"
        Me.txtSystemCheckSensor.ReadOnly = True
        Me.txtSystemCheckSensor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSystemCheckSensor.Size = New System.Drawing.Size(91, 25)
        Me.txtSystemCheckSensor.TabIndex = 2
        Me.txtSystemCheckSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(451, 78)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(211, 17)
        Me.Label59.TabIndex = 0
        Me.Label59.Text = "System Wait For Check Sensor"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 17)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "IG On/Off TimeOut"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(238, 17)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Mesa Valve Open/Closed TimeOut"
        '
        'tabAutoSendMail
        '
        Me.tabAutoSendMail.Controls.Add(Me.pnlEmailAlert)
        Me.tabAutoSendMail.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabAutoSendMail.Location = New System.Drawing.Point(0, 29)
        Me.tabAutoSendMail.Name = "tabAutoSendMail"
        Me.tabAutoSendMail.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAutoSendMail.Size = New System.Drawing.Size(1280, 727)
        Me.tabAutoSendMail.TabIndex = 8
        Me.tabAutoSendMail.Text = "Email Alert"
        Me.tabAutoSendMail.UseVisualStyleBackColor = True
        '
        'pnlEmailAlert
        '
        Me.pnlEmailAlert.Controls.Add(Me.btnApplyEmailSetting)
        Me.pnlEmailAlert.Controls.Add(Me.chkAutoSendEmail)
        Me.pnlEmailAlert.Controls.Add(Me.gbAccountInfomation)
        Me.pnlEmailAlert.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pnlEmailAlert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEmailAlert.Location = New System.Drawing.Point(3, 3)
        Me.pnlEmailAlert.Name = "pnlEmailAlert"
        Me.pnlEmailAlert.Size = New System.Drawing.Size(1274, 721)
        Me.pnlEmailAlert.TabIndex = 21
        '
        'btnApplyEmailSetting
        '
        Me.btnApplyEmailSetting.BackColor = System.Drawing.SystemColors.Info
        Me.btnApplyEmailSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplyEmailSetting.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApplyEmailSetting.Location = New System.Drawing.Point(561, 643)
        Me.btnApplyEmailSetting.Name = "btnApplyEmailSetting"
        Me.btnApplyEmailSetting.Size = New System.Drawing.Size(179, 49)
        Me.btnApplyEmailSetting.TabIndex = 25
        Me.btnApplyEmailSetting.Text = "Apply"
        Me.btnApplyEmailSetting.UseVisualStyleBackColor = False
        '
        'chkAutoSendEmail
        '
        Me.chkAutoSendEmail.AutoSize = True
        Me.chkAutoSendEmail.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoSendEmail.Location = New System.Drawing.Point(157, 20)
        Me.chkAutoSendEmail.Name = "chkAutoSendEmail"
        Me.chkAutoSendEmail.Size = New System.Drawing.Size(171, 28)
        Me.chkAutoSendEmail.TabIndex = 23
        Me.chkAutoSendEmail.Text = "Auto send email"
        Me.chkAutoSendEmail.UseVisualStyleBackColor = True
        '
        'gbAccountInfomation
        '
        Me.gbAccountInfomation.Controls.Add(Me.btnCustomEmailMessage)
        Me.gbAccountInfomation.Controls.Add(Me.btnAddNewEmail)
        Me.gbAccountInfomation.Controls.Add(Me.pnlEmail)
        Me.gbAccountInfomation.Controls.Add(Me.GroupBox8)
        Me.gbAccountInfomation.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAccountInfomation.Location = New System.Drawing.Point(200, 54)
        Me.gbAccountInfomation.Name = "gbAccountInfomation"
        Me.gbAccountInfomation.Size = New System.Drawing.Size(886, 572)
        Me.gbAccountInfomation.TabIndex = 21
        Me.gbAccountInfomation.TabStop = False
        '
        'btnCustomEmailMessage
        '
        Me.btnCustomEmailMessage.BackColor = System.Drawing.Color.Transparent
        Me.btnCustomEmailMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCustomEmailMessage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCustomEmailMessage.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnCustomEmailMessage.Location = New System.Drawing.Point(692, 159)
        Me.btnCustomEmailMessage.Name = "btnCustomEmailMessage"
        Me.btnCustomEmailMessage.Size = New System.Drawing.Size(189, 32)
        Me.btnCustomEmailMessage.TabIndex = 27
        Me.btnCustomEmailMessage.Text = "Custom Email Message"
        Me.btnCustomEmailMessage.UseVisualStyleBackColor = False
        '
        'btnAddNewEmail
        '
        Me.btnAddNewEmail.BackColor = System.Drawing.Color.Transparent
        Me.btnAddNewEmail.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.add_user
        Me.btnAddNewEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAddNewEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddNewEmail.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNewEmail.Location = New System.Drawing.Point(6, 159)
        Me.btnAddNewEmail.Name = "btnAddNewEmail"
        Me.btnAddNewEmail.Size = New System.Drawing.Size(51, 32)
        Me.btnAddNewEmail.TabIndex = 25
        Me.btnAddNewEmail.UseVisualStyleBackColor = False
        '
        'pnlEmail
        '
        Me.pnlEmail.Controls.Add(Me.dgvEmailUser)
        Me.pnlEmail.Location = New System.Drawing.Point(6, 194)
        Me.pnlEmail.Name = "pnlEmail"
        Me.pnlEmail.Size = New System.Drawing.Size(875, 372)
        Me.pnlEmail.TabIndex = 21
        '
        'dgvEmailUser
        '
        Me.dgvEmailUser.AllowUserToAddRows = False
        Me.dgvEmailUser.AllowUserToDeleteRows = False
        Me.dgvEmailUser.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvEmailUser.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEmailUser.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvEmailUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvEmailUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmailUser.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEmailUser.ColumnHeadersHeight = 25
        Me.dgvEmailUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvEmailUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvEmailUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEmailUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvEmailUser.EnableHeadersVisualStyles = False
        Me.dgvEmailUser.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgvEmailUser.Location = New System.Drawing.Point(0, 0)
        Me.dgvEmailUser.Name = "dgvEmailUser"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmailUser.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEmailUser.RowHeadersWidth = 20
        Me.dgvEmailUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvEmailUser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvEmailUser.Size = New System.Drawing.Size(875, 372)
        Me.dgvEmailUser.TabIndex = 3
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnTestingSetup)
        Me.GroupBox8.Controls.Add(Me.txtPort)
        Me.GroupBox8.Controls.Add(Me.txtSMTPServer)
        Me.GroupBox8.Controls.Add(Me.Label65)
        Me.GroupBox8.Controls.Add(Me.Label76)
        Me.GroupBox8.Controls.Add(Me.txtUserName)
        Me.GroupBox8.Controls.Add(Me.Label6)
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Controls.Add(Me.txtPassword)
        Me.GroupBox8.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(6, 17)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(875, 141)
        Me.GroupBox8.TabIndex = 20
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Account Infomation"
        '
        'btnTestingSetup
        '
        Me.btnTestingSetup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTestingSetup.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestingSetup.Location = New System.Drawing.Point(345, 103)
        Me.btnTestingSetup.Name = "btnTestingSetup"
        Me.btnTestingSetup.Size = New System.Drawing.Size(189, 32)
        Me.btnTestingSetup.TabIndex = 3
        Me.btnTestingSetup.Text = "Test Account Setting"
        Me.btnTestingSetup.UseVisualStyleBackColor = True
        '
        'txtPort
        '
        Me.txtPort.AccessibleDescription = ""
        Me.txtPort.BackColor = System.Drawing.SystemColors.Window
        Me.txtPort.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPort.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPort.Location = New System.Drawing.Point(143, 72)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.ReadOnly = True
        Me.txtPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPort.Size = New System.Drawing.Size(210, 25)
        Me.txtPort.TabIndex = 2
        Me.txtPort.Text = "587"
        '
        'txtSMTPServer
        '
        Me.txtSMTPServer.AccessibleDescription = ""
        Me.txtSMTPServer.BackColor = System.Drawing.SystemColors.Window
        Me.txtSMTPServer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSMTPServer.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMTPServer.Location = New System.Drawing.Point(143, 37)
        Me.txtSMTPServer.Name = "txtSMTPServer"
        Me.txtSMTPServer.ReadOnly = True
        Me.txtSMTPServer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSMTPServer.Size = New System.Drawing.Size(210, 25)
        Me.txtSMTPServer.TabIndex = 2
        Me.txtSMTPServer.Text = "smtp.gmail.com"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(32, 77)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(36, 17)
        Me.Label65.TabIndex = 0
        Me.Label65.Text = "Port"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.Location = New System.Drawing.Point(31, 42)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(96, 17)
        Me.Label76.TabIndex = 0
        Me.Label76.Text = "SMTP server"
        '
        'txtUserName
        '
        Me.txtUserName.AccessibleDescription = ""
        Me.txtUserName.BackColor = System.Drawing.SystemColors.Window
        Me.txtUserName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtUserName.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(632, 37)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUserName.Size = New System.Drawing.Size(210, 25)
        Me.txtUserName.TabIndex = 2
        Me.txtUserName.Text = "ctc_alert@sampleMail.com"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(544, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(544, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name"
        '
        'txtPassword
        '
        Me.txtPassword.AccessibleDescription = ""
        Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPassword.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(632, 72)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.ReadOnly = True
        Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPassword.Size = New System.Drawing.Size(210, 25)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.Text = "123456"
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'txtDelayTimeAfterProcessComplete
        '
        Me.txtDelayTimeAfterProcessComplete.AccessibleDescription = "Auto Vent LL Delay Time"
        Me.txtDelayTimeAfterProcessComplete.BackColor = System.Drawing.SystemColors.Window
        Me.txtDelayTimeAfterProcessComplete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtDelayTimeAfterProcessComplete.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelayTimeAfterProcessComplete.Location = New System.Drawing.Point(392, 134)
        Me.txtDelayTimeAfterProcessComplete.Name = "txtDelayTimeAfterProcessComplete"
        Me.txtDelayTimeAfterProcessComplete.Size = New System.Drawing.Size(85, 25)
        Me.txtDelayTimeAfterProcessComplete.TabIndex = 69
        Me.txtDelayTimeAfterProcessComplete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(481, 138)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 17)
        Me.Label22.TabIndex = 70
        Me.Label22.Text = "Minutes"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SystemSetup
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.tabSystem)
        Me.Name = "SystemSetup"
        Me.Size = New System.Drawing.Size(1280, 756)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSystem.ResumeLayout(False)
        Me.tabGeneralSetting.ResumeLayout(False)
        Me.pnlGeneralSetting.ResumeLayout(False)
        Me.gbxDegasWaitTime.ResumeLayout(False)
        Me.gbxDegasWaitTime.PerformLayout()
        Me.grpResetScheduler.ResumeLayout(False)
        Me.tabPressureSetpoint.ResumeLayout(False)
        Me.pnlPressureSetPoint.ResumeLayout(False)
        Me.gbxPressure.ResumeLayout(False)
        Me.gbxPressure.PerformLayout()
        Me.gbxRegenHourLimit.ResumeLayout(False)
        Me.gbxRegenHourLimit.PerformLayout()
        Me.gbxCGTransferDiff.ResumeLayout(False)
        Me.gbxCGTransferDiff.PerformLayout()
        Me.tabElevatorSetting.ResumeLayout(False)
        Me.pnlElevatorSetting.ResumeLayout(False)
        Me.gbxRobot.ResumeLayout(False)
        Me.gbxRobot.PerformLayout()
        Me.gbxLLASetting.ResumeLayout(False)
        Me.gbxLLASetting.PerformLayout()
        Me.TabTargetKwh.ResumeLayout(False)
        Me.pnlKWH.ResumeLayout(False)
        Me.grboxModuleName.ResumeLayout(False)
        Me.grboxModuleName.PerformLayout()
        Me.gbxLifetimeWafer.ResumeLayout(False)
        Me.gbxLifetimeWafer.PerformLayout()
        Me.gbxShieldsQuartz.ResumeLayout(False)
        Me.gbxShieldsQuartz.PerformLayout()
        Me.gbxUsage.ResumeLayout(False)
        Me.gbxUsage.PerformLayout()
        Me.gbxWaferCounts.ResumeLayout(False)
        Me.gbxWaferCounts.PerformLayout()
        Me.gbxTargetMaterial.ResumeLayout(False)
        Me.gbxTargetMaterial.PerformLayout()
        Me.gbxCalculationType.ResumeLayout(False)
        Me.gbxCalculationType.PerformLayout()
        Me.tabTimeOut.ResumeLayout(False)
        Me.pnlTimeOut.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabAutoSendMail.ResumeLayout(False)
        Me.pnlEmailAlert.ResumeLayout(False)
        Me.pnlEmailAlert.PerformLayout()
        Me.gbAccountInfomation.ResumeLayout(False)
        Me.pnlEmail.ResumeLayout(False)
        CType(Me.dgvEmailUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabSystem As System.Windows.Forms.CustomTabControl
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents tabPressureSetpoint As System.Windows.Forms.TabPage
    Friend WithEvents tabElevatorSetting As System.Windows.Forms.TabPage
    Friend WithEvents TabTargetKwh As System.Windows.Forms.TabPage
    Friend WithEvents txtTransferPM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtTransferPM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTransferPM1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSlowVentLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtSlowRoughLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtCrossOverLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtTransferLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtVentLLA As System.Windows.Forms.TextBox
    Friend WithEvents btnApplyPressureSetpoint As System.Windows.Forms.Button
    Friend WithEvents txtBaseOffsetLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtPitchLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtTravelLengthLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberOfSlotsLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtFindBiasLLA As System.Windows.Forms.TextBox
    Friend WithEvents btnApplyElevatorSetting As System.Windows.Forms.Button
    Friend WithEvents txtCrossOverTM As System.Windows.Forms.TextBox
    Friend WithEvents txtTransferTM As System.Windows.Forms.TextBox
    Friend WithEvents txtVentTM As System.Windows.Forms.TextBox
    Friend WithEvents pnlPressureSetPoint As System.Windows.Forms.Panel
    Friend WithEvents pnlElevatorSetting As System.Windows.Forms.Panel
    Friend WithEvents pnlKWH As System.Windows.Forms.Panel
    Friend WithEvents txtUsageKWH_PM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtUsageKWH_PM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtUsageKWH_PM1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTarMaterialPM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtTarMaterialPM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTarMaterialPM1 As System.Windows.Forms.TextBox
    Friend WithEvents txtLimitsKWH_PM1 As System.Windows.Forms.TextBox
    Friend WithEvents txtLimitsKWH_PM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtLimitsKWH_PM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtWarningKWH_PM1 As System.Windows.Forms.TextBox
    Friend WithEvents txtWarningKWH_PM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtWarningKWH_PM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtWaferCountPM1 As System.Windows.Forms.TextBox
    Friend WithEvents txtWaferCountPM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtWaferCountPM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtLifeTimeWafer As System.Windows.Forms.TextBox
    Friend WithEvents txtShieldsPM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtShieldsPM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtShieldPM1 As System.Windows.Forms.TextBox
    Friend WithEvents lblPM1_UsageUnit As System.Windows.Forms.Label
    Friend WithEvents lblPM1_ShQuUnit As System.Windows.Forms.Label
    Friend WithEvents lblPM3_UsageUnit As System.Windows.Forms.Label
    Friend WithEvents lblPM2_UsageUnit As System.Windows.Forms.Label
    Friend WithEvents lblPM3_ShQuUnit As System.Windows.Forms.Label
    Friend WithEvents lblPM2_ShQuUnit As System.Windows.Forms.Label
    Friend WithEvents txtMaxKWHPM1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxKWHPM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxKWHPM2 As System.Windows.Forms.TextBox
    Friend WithEvents gbxCalculationType As System.Windows.Forms.GroupBox
    Friend WithEvents rbUseMaxKWH As System.Windows.Forms.RadioButton
    Friend WithEvents rbUseAbsoluteKWH As System.Windows.Forms.RadioButton
    Friend WithEvents txtCGDifferentialPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbxCGTransferDiff As System.Windows.Forms.GroupBox
    Friend WithEvents tabGeneralSetting As System.Windows.Forms.TabPage
    Friend WithEvents txtRateOfRiseVolLLA As System.Windows.Forms.TextBox
    Friend WithEvents txtDegasWaitTimeLLA As System.Windows.Forms.TextBox
    Friend WithEvents btnApplyGeneralSetting As System.Windows.Forms.Button
    Friend WithEvents txtRateOfRiseVolTM As System.Windows.Forms.TextBox
    Friend WithEvents txtDegasWaitTimeTM As System.Windows.Forms.TextBox
    Friend WithEvents gbxRegenHourLimit As System.Windows.Forms.GroupBox
    Friend WithEvents txtCryoPumpHour As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbAutoVentWhenProcessCompleted As System.Windows.Forms.CheckBox
    Friend WithEvents pnlGeneralSetting As System.Windows.Forms.Panel
    Friend WithEvents txtEtchRatePM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtEtchRatePM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtEtchRatePM1 As System.Windows.Forms.TextBox
    Friend WithEvents btnResetLLAScheduler As System.Windows.Forms.Button
    Friend WithEvents grpResetScheduler As System.Windows.Forms.GroupBox
    Friend WithEvents cbAutoArchiveSystemConfigFile As System.Windows.Forms.CheckBox
    Friend WithEvents btnArchiveConfigFile As System.Windows.Forms.Button
    Friend WithEvents txtArchiveConfigFile As System.Windows.Forms.TextBox
    Friend WithEvents gbxDegasWaitTime As System.Windows.Forms.GroupBox
    Friend WithEvents lblAutoArchiveStatus As System.Windows.Forms.Label
    Friend WithEvents gbxPressure As System.Windows.Forms.GroupBox
    Friend WithEvents lblSlowVent As System.Windows.Forms.Label
    Friend WithEvents lblSlowRough As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTMPressure As System.Windows.Forms.Label
    Friend WithEvents lblPM3Pressure As System.Windows.Forms.Label
    Friend WithEvents lblLLAPressure As System.Windows.Forms.Label
    Friend WithEvents lblPM2Pressure As System.Windows.Forms.Label
    Friend WithEvents lblPM1Pressure As System.Windows.Forms.Label
    Friend WithEvents gbxLLASetting As System.Windows.Forms.GroupBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents gbxUsage As System.Windows.Forms.GroupBox
    Friend WithEvents lblPM3Type1 As System.Windows.Forms.Label
    Friend WithEvents gbxWaferCounts As System.Windows.Forms.GroupBox
    Friend WithEvents lblWaferCounts As System.Windows.Forms.Label
    Friend WithEvents lblPM2Type1 As System.Windows.Forms.Label
    Friend WithEvents lblPM1Type1 As System.Windows.Forms.Label
    Friend WithEvents gbxTargetMaterial As System.Windows.Forms.GroupBox
    Friend WithEvents lblTargetMaterial As System.Windows.Forms.Label
    Friend WithEvents lblMaxUsage As System.Windows.Forms.Label
    Friend WithEvents lblWarningUsage As System.Windows.Forms.Label
    Friend WithEvents lblLimitsUsage As System.Windows.Forms.Label
    Friend WithEvents lblPM3 As System.Windows.Forms.Label
    Friend WithEvents lblPM2 As System.Windows.Forms.Label
    Friend WithEvents lblPM1 As System.Windows.Forms.Label
    Friend WithEvents gbxShieldsQuartz As System.Windows.Forms.GroupBox
    Friend WithEvents lblPM3Type2 As System.Windows.Forms.Label
    Friend WithEvents lblPM2Type2 As System.Windows.Forms.Label
    Friend WithEvents lblPM1Type2 As System.Windows.Forms.Label
    Friend WithEvents lblMaxShields As System.Windows.Forms.Label
    Friend WithEvents lblWarningShields As System.Windows.Forms.Label
    Friend WithEvents lblLimitsShields As System.Windows.Forms.Label
    Friend WithEvents txtMaxShieldsPM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxShieldsPM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxShieldsPM1 As System.Windows.Forms.TextBox
    Friend WithEvents txtWarningShieldsPM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtWarningShieldsPM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtWarningShieldsPM1 As System.Windows.Forms.TextBox
    Friend WithEvents txtLimitShieldsPM3 As System.Windows.Forms.TextBox
    Friend WithEvents txtLimitShieldsPM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLimitShieldsPM1 As System.Windows.Forms.TextBox
    Friend WithEvents lblPM3Shields As System.Windows.Forms.Label
    Friend WithEvents lblPM2Shields As System.Windows.Forms.Label
    Friend WithEvents lblPM1Shields As System.Windows.Forms.Label
    Friend WithEvents gbxLifetimeWafer As System.Windows.Forms.GroupBox
    Friend WithEvents tabAutoSendMail As System.Windows.Forms.TabPage
    Friend WithEvents pnlEmailAlert As System.Windows.Forms.Panel
    Friend WithEvents btnApplyEmailSetting As System.Windows.Forms.Button
    Friend WithEvents chkAutoSendEmail As System.Windows.Forms.CheckBox
    Friend WithEvents gbAccountInfomation As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddNewEmail As System.Windows.Forms.Button
    Friend WithEvents pnlEmail As System.Windows.Forms.Panel
    Friend WithEvents dgvEmailUser As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTestingSetup As System.Windows.Forms.Button
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtSMTPServer As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents tabTimeOut As System.Windows.Forms.TabPage
    Friend WithEvents pnlTimeOut As System.Windows.Forms.Panel
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAutoLog As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents btnApplyTimeOut As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLLContinueVent As System.Windows.Forms.TextBox
    Friend WithEvents txtLLDelayTimeTurnOnIG As System.Windows.Forms.TextBox
    Friend WithEvents txtLLVentValveTO As System.Windows.Forms.TextBox
    Friend WithEvents txtLLContinuePumpDown As System.Windows.Forms.TextBox
    Friend WithEvents txtLLRoughValveTO As System.Windows.Forms.TextBox
    Friend WithEvents txtLLAFastVentTO As System.Windows.Forms.TextBox
    Friend WithEvents txtLLAFastRoughTO As System.Windows.Forms.TextBox
    Friend WithEvents txtLLASlowVentTO As System.Windows.Forms.TextBox
    Friend WithEvents txtLLASlowRoughTO As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTMDelayTimeTurnOnIG As System.Windows.Forms.TextBox
    Friend WithEvents txtTMVentValveTO As System.Windows.Forms.TextBox
    Friend WithEvents txtTMContinuePumpDown As System.Windows.Forms.TextBox
    Friend WithEvents txtTMContinueVent As System.Windows.Forms.TextBox
    Friend WithEvents txtTMRoughTO As System.Windows.Forms.TextBox
    Friend WithEvents txtTMVentTO As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHivacTO As System.Windows.Forms.TextBox
    Friend WithEvents txtIGOnOffTO As System.Windows.Forms.TextBox
    Friend WithEvents txtMesaValveTO As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSystemCheckSensor As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grboxModuleName As System.Windows.Forms.GroupBox
    Friend WithEvents txtModuleNamePM1 As System.Windows.Forms.TextBox
    Friend WithEvents txtModuleNamePM2 As System.Windows.Forms.TextBox
    Friend WithEvents txtModuleNamePM3 As System.Windows.Forms.TextBox
    Friend WithEvents cbxAllowCheckingECCLimit As System.Windows.Forms.CheckBox
    Friend WithEvents cbxManualDefineGEMWaferID As System.Windows.Forms.CheckBox
    Friend WithEvents txtDeltaPickECCLimits As System.Windows.Forms.TextBox
    Friend WithEvents btnCustomEmailMessage As System.Windows.Forms.Button
    Friend WithEvents btnArchiveNow As System.Windows.Forms.Button
    Friend WithEvents gbxRobot As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoadConfigRobot As System.Windows.Forms.Button
    Friend WithEvents btnStoreConfigRobot As System.Windows.Forms.Button
    Friend WithEvents btnLoadConfigLLA As System.Windows.Forms.Button
    Friend WithEvents btnStoreConfigLLA As System.Windows.Forms.Button
    Friend WithEvents RobotConfig As AVPControls.RobotConfigPanel
    Friend WithEvents txtRobotVersion As System.Windows.Forms.TextBox
    Friend WithEvents btnRequestRobotInfo As System.Windows.Forms.Button
    Friend WithEvents cbxEnableQuickSequenceEditor As System.Windows.Forms.CheckBox
    Friend WithEvents lblLLAForelineCG As System.Windows.Forms.Label
    Friend WithEvents lblTMForelineCG As System.Windows.Forms.Label
    Friend WithEvents lblMPPressure As System.Windows.Forms.Label
    Friend WithEvents txtLLAForelineCGTripPoint As System.Windows.Forms.TextBox
    Friend WithEvents txtTMForelineCGTripPoint As System.Windows.Forms.TextBox
    Friend WithEvents txtMPCGTripPoint As System.Windows.Forms.TextBox
    Friend WithEvents txtTMCGTripPoint As System.Windows.Forms.TextBox
    Friend WithEvents txtLLACGTripPoint As System.Windows.Forms.TextBox
    Friend WithEvents lbCGTripPoint As System.Windows.Forms.Label
    Friend WithEvents txtInfoName As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTransferSetPointWaitTimeInSeconds As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtSystemCleanUpDataRunTimeInDays As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnCancelElevatorSetting As System.Windows.Forms.Button
    Friend WithEvents txtApplyStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtDelayTimeAfterProcessComplete As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class