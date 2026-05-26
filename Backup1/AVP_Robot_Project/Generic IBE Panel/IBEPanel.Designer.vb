<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IBEPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IBEPanel))
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.tabProcessModule = New System.Windows.Forms.CustomTabControl
        Me.tabSource = New System.Windows.Forms.TabPage
        Me.txtSourceEMCurrentRight_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.txtSourceEMCurrent_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.lblSourceEMCurrent_SourceTab = New System.Windows.Forms.Label
        Me.txtPBNDischVolt = New AVP_Robot_Project.SL_Textbox
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblANC = New System.Windows.Forms.Label
        Me.txtANC = New AVP_Robot_Project.SL_Textbox
        Me.Label20 = New System.Windows.Forms.Label
        Me.btnSourceSaveLoad = New AVP_Robot_Project.SL_CustomButton
        Me.btnSourceAuto = New AVP_Robot_Project.SL_CustomButton
        Me.btnSourceManual = New AVP_Robot_Project.SL_CustomButton
        Me.btnAutoBeam = New AVP_Robot_Project.SL_CustomButton
        Me.txtRFPower = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNDisch = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNBody = New AVP_Robot_Project.SL_Textbox
        Me.txtKFactor = New AVP_Robot_Project.SL_Textbox
        Me.txtGas4_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNBodyVolt = New AVP_Robot_Project.SL_Textbox
        Me.txtGas3_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.txtGas1_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNGas_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.txtRFReflected = New AVP_Robot_Project.SL_Textbox
        Me.txtSuppressorCurrent = New AVP_Robot_Project.SL_Textbox
        Me.txtSuppressorVoltage = New AVP_Robot_Project.SL_Textbox
        Me.txtBeamCurrent = New AVP_Robot_Project.SL_Textbox
        Me.txtSuppressorVoltageRight = New AVP_Robot_Project.SL_Textbox
        Me.txtSuppressorCurrentRight = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNDischRight = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNBodyRight = New AVP_Robot_Project.SL_Textbox
        Me.txtGas4Right_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.txtKFactorRight = New AVP_Robot_Project.SL_Textbox
        Me.txtGas3Right_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.txtGas2Right_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.txtGas1Right_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNGasRight_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.txtRFReflectedRight = New AVP_Robot_Project.SL_Textbox
        Me.txtRFPowerRight = New AVP_Robot_Project.SL_Textbox
        Me.txtBeamCurrentRight = New AVP_Robot_Project.SL_Textbox
        Me.txtBeamVoltageRight = New AVP_Robot_Project.SL_Textbox
        Me.lblSourceGas4 = New System.Windows.Forms.Label
        Me.txtBeamVoltage = New AVP_Robot_Project.SL_Textbox
        Me.lblSourceGas2 = New System.Windows.Forms.Label
        Me.lblSourceGas3 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblSourceGas1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblSourcePBNGas = New System.Windows.Forms.Label
        Me.lblKFactor = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtGas2_SourceTab = New AVP_Robot_Project.SL_Textbox
        Me.tabProcessStatus = New System.Windows.Forms.TabPage
        Me.txtElapsedTime = New AVP_Robot_Project.SL_Textbox
        Me.txtTotalStep = New AVP_Robot_Project.SL_Textbox
        Me.txtProcessStep = New AVP_Robot_Project.SL_Textbox
        Me.txtSourceMinutes = New AVP_Robot_Project.SL_Textbox
        Me.txtStatus = New AVP_Robot_Project.SL_Textbox
        Me.txtStepTime = New AVP_Robot_Project.SL_Textbox
        Me.txtRemainingTime = New AVP_Robot_Project.SL_Textbox
        Me.txtWaferID = New AVP_Robot_Project.SL_Textbox
        Me.txtRecipe = New AVP_Robot_Project.SL_Textbox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.tabGas = New System.Windows.Forms.TabPage
        Me.ValveDiverter = New AVP_Robot_Project.ValveControl
        Me.GasLine3_Total_Below = New AVPControls.AnimationControl
        Me.GasLine2_Total_Below = New AVPControls.AnimationControl
        Me.GasLine3_Total = New AVPControls.AnimationControl
        Me.GasLine_Shutoff3 = New AVPControls.AnimationControl
        Me.GasLine2_Total = New AVPControls.AnimationControl
        Me.GasLine_Shutoff2 = New AVPControls.AnimationControl
        Me.ValveSupplyGas4 = New AVP_Robot_Project.ValveControl
        Me.ValveSupplyGas3 = New AVP_Robot_Project.ValveControl
        Me.ValveSupplyGas2 = New AVP_Robot_Project.ValveControl
        Me.ValveSupplyGas1 = New AVP_Robot_Project.ValveControl
        Me.GasLine1_Total = New AVPControls.AnimationControl
        Me.GasLine1_Total_Below = New AVPControls.AnimationControl
        Me.btnOpenCloseGas4 = New AVP_Robot_Project.SL_CustomButton
        Me.btnOpenCloseGas3 = New AVP_Robot_Project.SL_CustomButton
        Me.btnOpenCloseGas2 = New AVP_Robot_Project.SL_CustomButton
        Me.btnOpenCloseGas1 = New AVP_Robot_Project.SL_CustomButton
        Me.btnOpenClosePBNGas = New AVP_Robot_Project.SL_CustomButton
        Me.txtGas4 = New AVP_Robot_Project.SL_Textbox
        Me.txtGas3 = New AVP_Robot_Project.SL_Textbox
        Me.txtGas2 = New AVP_Robot_Project.SL_Textbox
        Me.txtGas1 = New AVP_Robot_Project.SL_Textbox
        Me.txtGas4Right = New AVP_Robot_Project.SL_Textbox
        Me.txtGas3Right = New AVP_Robot_Project.SL_Textbox
        Me.txtGas2Right = New AVP_Robot_Project.SL_Textbox
        Me.txtGas1Right = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNGasRight = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNGas = New AVP_Robot_Project.SL_Textbox
        Me.lblGas4 = New System.Windows.Forms.Label
        Me.lblGas3 = New System.Windows.Forms.Label
        Me.lblGasPBN = New System.Windows.Forms.Label
        Me.lblGas2 = New System.Windows.Forms.Label
        Me.lblGas1 = New System.Windows.Forms.Label
        Me.GasLine_Shutoff4 = New AVPControls.AnimationControl
        Me.GasLine_PBNShutoff = New AVPControls.AnimationControl
        Me.GasLine_Shutoff1 = New AVPControls.AnimationControl
        Me.GasLine_PBNSupply = New AVPControls.AnimationControl
        Me.GasLine_Supply1 = New AVPControls.AnimationControl
        Me.GasLine_Supply2 = New AVPControls.AnimationControl
        Me.GasLine_Supply4 = New AVPControls.AnimationControl
        Me.GasLine_Supply3 = New AVPControls.AnimationControl
        Me.ValveShutoffPBNGas = New AVP_Robot_Project.ValveControl
        Me.ValveShutoffGas1 = New AVP_Robot_Project.ValveControl
        Me.ValveShutoffGas4 = New AVP_Robot_Project.ValveControl
        Me.ValveShutoffGas2 = New AVP_Robot_Project.ValveControl
        Me.ValveShutoffGas3 = New AVP_Robot_Project.ValveControl
        Me.ValveSupplyPBNGas = New AVP_Robot_Project.ValveControl
        Me.GasLine_Total1 = New AVPControls.AnimationControl
        Me.tabPartID = New System.Windows.Forms.TabPage
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtWaterJournalSP = New AVP_Robot_Project.SL_Textbox
        Me.txtFixtureRotationMotorUsageSP = New AVP_Robot_Project.SL_Textbox
        Me.txtCryoUsageSP = New AVP_Robot_Project.SL_Textbox
        Me.txtLinerSP = New AVP_Robot_Project.SL_Textbox
        Me.txtShutterUsageSP = New AVP_Robot_Project.SL_Textbox
        Me.txtTopFixtureShieldUsageSP = New AVP_Robot_Project.SL_Textbox
        Me.txtWaferClampUsageSP = New AVP_Robot_Project.SL_Textbox
        Me.txtCoverFixtureShieldUsageSP = New AVP_Robot_Project.SL_Textbox
        Me.txtShieldQuartSP = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNMinutes = New AVP_Robot_Project.SL_Textbox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtSourceMinutesMaint = New AVP_Robot_Project.SL_Textbox
        Me.Label31 = New System.Windows.Forms.Label
        Me.cmbRebuildLevel = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtGridID = New AVP_Robot_Project.SL_Textbox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtGridSerialNumber = New AVP_Robot_Project.SL_Textbox
        Me.cmstooltipFixture = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuStartRotation = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHomeRotation = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCoolingWater = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUnProtected = New System.Windows.Forms.ToolStripMenuItem
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtRoughlineCG = New AVP_Robot_Project.SL_Textbox
        Me.txtForelineCG = New AVP_Robot_Project.SL_Textbox
        Me.txtMG = New AVP_Robot_Project.SL_Textbox
        Me.btnUnProtected = New AVP_Robot_Project.SL_CustomButton
        Me.SLPM = New AVP_Robot_Project.SL_Info
        Me.btnTooltipFixture = New System.Windows.Forms.Button
        Me.SLPowerPanel = New AVP_Robot_Project.SL_PowerPanel
        Me.SLIGCGControl = New AVP_Robot_Project.SL_IGCGControl
        Me.SLRLCG = New AVP_Robot_Project.SL_Info
        Me.SLFLCG = New AVP_Robot_Project.SL_Info
        Me.PBNGasLine = New AVPControls.AnimationControl
        Me.GasLine_Total = New AVPControls.AnimationControl
        Me.ValveForeline = New AVP_Robot_Project.ValveControl
        Me.ValveVent = New AVP_Robot_Project.ValveControl
        Me.ValveFixtureWater = New AVP_Robot_Project.ValveControl
        Me.GasLine_FlowCool_Supply = New AVPControls.AnimationControl
        Me.SLFixture = New AVP_Robot_Project.SL_Fixture
        Me.SLInterlocks = New AVP_Robot_Project.SL_InterlockControl
        Me.SLStatusPanel = New AVP_Robot_Project.SL_StatusPanel
        Me.RoughPump = New AVP_Robot_Project.ValveControl
        Me.RoughPump_Line = New AVPControls.AnimationControl
        Me.GasLine_Rough = New AVPControls.AnimationControl
        Me.GasLine_FixtureWater = New AVPControls.AnimationControl
        Me.GasLine_Vent = New AVPControls.AnimationControl
        Me.ValveRough = New AVP_Robot_Project.ValveControl
        Me.PressureConnector = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.SLContainerBox = New AVP_Robot_Project.SLBox
        Me.lblDisconnect = New System.Windows.Forms.Label
        Me.SL_SourceUsage = New AVP_Robot_Project.SL_Info
        Me.lblNameOfSequenceRunning = New System.Windows.Forms.Label
        Me.GasLine_Flowcool_Return = New AVPControls.AnimationControl
        Me.ValveFlowCoolReturn = New AVP_Robot_Project.ValveControl
        Me.Label25 = New System.Windows.Forms.Label
        Me.btnRelayIndicatorPump = New AVP_Robot_Project.SL_CustomButton
        Me.lblCurrentPurgeCycle = New System.Windows.Forms.Label
        Me.Foreline_Line = New AVPControls.AnimationControl
        Me.RoughLineTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ChillerControl = New AVP_Robot_Project.SL_ChillerControl
        Me.txtMPPressure = New AVP_Robot_Project.SL_Textbox
        Me.EMPowerSupply = New AVP_Robot_Project.SL_ElectromagnetPS
        Me.ValveIGIsolation = New AVP_Robot_Project.ValveControl
        Me.GasLine_Isolation = New AVPControls.AnimationControl
        Me.lblIGIsolation = New System.Windows.Forms.Label
        Me.GasLine234_Total = New AVPControls.AnimationControl
        Me.lblDiverterGas = New System.Windows.Forms.Label
        Me.tabProcessModule.SuspendLayout()
        Me.tabSource.SuspendLayout()
        Me.tabProcessStatus.SuspendLayout()
        Me.tabGas.SuspendLayout()
        CType(Me.GasLine3_Total_Below, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine2_Total_Below, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine3_Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Shutoff3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine2_Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Shutoff2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine1_Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine1_Total_Below, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Shutoff4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_PBNShutoff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Shutoff1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_PBNSupply, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Supply1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Supply2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Supply4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Supply3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Total1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPartID.SuspendLayout()
        Me.cmstooltipFixture.SuspendLayout()
        CType(Me.PBNGasLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_FlowCool_Supply, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RoughPump_Line, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Rough, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_FixtureWater, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Vent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Flowcool_Return, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Foreline_Line, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine_Isolation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GasLine234_Total, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(375, 599)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 21)
        Me.Label7.TabIndex = 222
        Me.Label7.Text = "Rough"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(804, 371)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 21)
        Me.Label8.TabIndex = 222
        Me.Label8.Text = "Vent"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(364, 126)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 21)
        Me.Label21.TabIndex = 222
        Me.Label21.Text = "Foreline"
        '
        'tabProcessModule
        '
        Me.tabProcessModule.Controls.Add(Me.tabSource)
        Me.tabProcessModule.Controls.Add(Me.tabProcessStatus)
        Me.tabProcessModule.Controls.Add(Me.tabGas)
        Me.tabProcessModule.Controls.Add(Me.tabPartID)
        Me.tabProcessModule.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabProcessModule.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabProcessModule.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabProcessModule.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabProcessModule.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabProcessModule.DisplayStyleProvider.FocusTrack = False
        Me.tabProcessModule.DisplayStyleProvider.HotTrack = True
        Me.tabProcessModule.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabProcessModule.DisplayStyleProvider.Opacity = 1.0!
        Me.tabProcessModule.DisplayStyleProvider.Overlap = 0
        Me.tabProcessModule.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabProcessModule.DisplayStyleProvider.Radius = 10
        Me.tabProcessModule.DisplayStyleProvider.ShowTabCloser = False
        Me.tabProcessModule.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabProcessModule.HotTrack = True
        Me.tabProcessModule.Location = New System.Drawing.Point(868, 36)
        Me.tabProcessModule.Name = "tabProcessModule"
        Me.tabProcessModule.SelectedIndex = 0
        Me.tabProcessModule.Size = New System.Drawing.Size(412, 478)
        Me.tabProcessModule.TabIndex = 219
        '
        'tabSource
        '
        Me.tabSource.BackColor = System.Drawing.Color.Transparent
        Me.tabSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tabSource.Controls.Add(Me.txtSourceEMCurrentRight_SourceTab)
        Me.tabSource.Controls.Add(Me.txtSourceEMCurrent_SourceTab)
        Me.tabSource.Controls.Add(Me.lblSourceEMCurrent_SourceTab)
        Me.tabSource.Controls.Add(Me.txtPBNDischVolt)
        Me.tabSource.Controls.Add(Me.Label22)
        Me.tabSource.Controls.Add(Me.lblANC)
        Me.tabSource.Controls.Add(Me.txtANC)
        Me.tabSource.Controls.Add(Me.Label20)
        Me.tabSource.Controls.Add(Me.btnSourceSaveLoad)
        Me.tabSource.Controls.Add(Me.btnSourceAuto)
        Me.tabSource.Controls.Add(Me.btnSourceManual)
        Me.tabSource.Controls.Add(Me.btnAutoBeam)
        Me.tabSource.Controls.Add(Me.txtRFPower)
        Me.tabSource.Controls.Add(Me.txtPBNDisch)
        Me.tabSource.Controls.Add(Me.txtPBNBody)
        Me.tabSource.Controls.Add(Me.txtKFactor)
        Me.tabSource.Controls.Add(Me.txtGas4_SourceTab)
        Me.tabSource.Controls.Add(Me.txtPBNBodyVolt)
        Me.tabSource.Controls.Add(Me.txtGas3_SourceTab)
        Me.tabSource.Controls.Add(Me.txtGas1_SourceTab)
        Me.tabSource.Controls.Add(Me.txtPBNGas_SourceTab)
        Me.tabSource.Controls.Add(Me.txtRFReflected)
        Me.tabSource.Controls.Add(Me.txtSuppressorCurrent)
        Me.tabSource.Controls.Add(Me.txtSuppressorVoltage)
        Me.tabSource.Controls.Add(Me.txtBeamCurrent)
        Me.tabSource.Controls.Add(Me.txtSuppressorVoltageRight)
        Me.tabSource.Controls.Add(Me.txtSuppressorCurrentRight)
        Me.tabSource.Controls.Add(Me.txtPBNDischRight)
        Me.tabSource.Controls.Add(Me.txtPBNBodyRight)
        Me.tabSource.Controls.Add(Me.txtGas4Right_SourceTab)
        Me.tabSource.Controls.Add(Me.txtKFactorRight)
        Me.tabSource.Controls.Add(Me.txtGas3Right_SourceTab)
        Me.tabSource.Controls.Add(Me.txtGas2Right_SourceTab)
        Me.tabSource.Controls.Add(Me.txtGas1Right_SourceTab)
        Me.tabSource.Controls.Add(Me.txtPBNGasRight_SourceTab)
        Me.tabSource.Controls.Add(Me.txtRFReflectedRight)
        Me.tabSource.Controls.Add(Me.txtRFPowerRight)
        Me.tabSource.Controls.Add(Me.txtBeamCurrentRight)
        Me.tabSource.Controls.Add(Me.txtBeamVoltageRight)
        Me.tabSource.Controls.Add(Me.lblSourceGas4)
        Me.tabSource.Controls.Add(Me.txtBeamVoltage)
        Me.tabSource.Controls.Add(Me.lblSourceGas2)
        Me.tabSource.Controls.Add(Me.lblSourceGas3)
        Me.tabSource.Controls.Add(Me.Label11)
        Me.tabSource.Controls.Add(Me.lblSourceGas1)
        Me.tabSource.Controls.Add(Me.Label10)
        Me.tabSource.Controls.Add(Me.lblSourcePBNGas)
        Me.tabSource.Controls.Add(Me.lblKFactor)
        Me.tabSource.Controls.Add(Me.Label6)
        Me.tabSource.Controls.Add(Me.Label5)
        Me.tabSource.Controls.Add(Me.Label4)
        Me.tabSource.Controls.Add(Me.Label3)
        Me.tabSource.Controls.Add(Me.Label2)
        Me.tabSource.Controls.Add(Me.Label1)
        Me.tabSource.Controls.Add(Me.txtGas2_SourceTab)
        Me.tabSource.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabSource.Location = New System.Drawing.Point(0, 31)
        Me.tabSource.Name = "tabSource"
        Me.tabSource.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSource.Size = New System.Drawing.Size(412, 447)
        Me.tabSource.TabIndex = 0
        Me.tabSource.Text = "Source"
        '
        'txtSourceEMCurrentRight_SourceTab
        '
        Me.txtSourceEMCurrentRight_SourceTab.AutoSendKeyTabWhenFinishInput = True
        Me.txtSourceEMCurrentRight_SourceTab.BackColor = System.Drawing.Color.White
        Me.txtSourceEMCurrentRight_SourceTab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSourceEMCurrentRight_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSourceEMCurrentRight_SourceTab.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtSourceEMCurrentRight_SourceTab.IsNumericTextbox = True
        Me.txtSourceEMCurrentRight_SourceTab.Location = New System.Drawing.Point(90, 245)
        Me.txtSourceEMCurrentRight_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtSourceEMCurrentRight_SourceTab.Multiline = True
        Me.txtSourceEMCurrentRight_SourceTab.Name = "txtSourceEMCurrentRight_SourceTab"
        Me.txtSourceEMCurrentRight_SourceTab.ReadOnly = True
        Me.txtSourceEMCurrentRight_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtSourceEMCurrentRight_SourceTab.TabIndex = 81
        Me.txtSourceEMCurrentRight_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSourceEMCurrentRight_SourceTab.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtSourceEMCurrentRight_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Three_Digits
        '
        'txtSourceEMCurrent_SourceTab
        '
        Me.txtSourceEMCurrent_SourceTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSourceEMCurrent_SourceTab.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSourceEMCurrent_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSourceEMCurrent_SourceTab.IsReadBack = True
        Me.txtSourceEMCurrent_SourceTab.Location = New System.Drawing.Point(90, 218)
        Me.txtSourceEMCurrent_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtSourceEMCurrent_SourceTab.Multiline = True
        Me.txtSourceEMCurrent_SourceTab.Name = "txtSourceEMCurrent_SourceTab"
        Me.txtSourceEMCurrent_SourceTab.ReadOnly = True
        Me.txtSourceEMCurrent_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtSourceEMCurrent_SourceTab.TabIndex = 80
        Me.txtSourceEMCurrent_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSourceEMCurrent_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Three_Digits
        '
        'lblSourceEMCurrent_SourceTab
        '
        Me.lblSourceEMCurrent_SourceTab.AutoSize = True
        Me.lblSourceEMCurrent_SourceTab.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourceEMCurrent_SourceTab.Location = New System.Drawing.Point(132, 156)
        Me.lblSourceEMCurrent_SourceTab.Name = "lblSourceEMCurrent_SourceTab"
        Me.lblSourceEMCurrent_SourceTab.Size = New System.Drawing.Size(149, 19)
        Me.lblSourceEMCurrent_SourceTab.TabIndex = 79
        Me.lblSourceEMCurrent_SourceTab.Text = "Source E.M Curr (A)"
        '
        'txtPBNDischVolt
        '
        Me.txtPBNDischVolt.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNDischVolt.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNDischVolt.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNDischVolt.IsReadBack = True
        Me.txtPBNDischVolt.Location = New System.Drawing.Point(45, 326)
        Me.txtPBNDischVolt.MinimumValueHighlightedGreen = 0
        Me.txtPBNDischVolt.Multiline = True
        Me.txtPBNDischVolt.Name = "txtPBNDischVolt"
        Me.txtPBNDischVolt.ReadOnly = True
        Me.txtPBNDischVolt.Size = New System.Drawing.Size(100, 26)
        Me.txtPBNDischVolt.TabIndex = 68
        Me.txtPBNDischVolt.TabStop = False
        Me.txtPBNDischVolt.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNDischVolt.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(-2, 181)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(189, 19)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "PBN DischargeVoltage (V)"
        '
        'lblANC
        '
        Me.lblANC.AutoSize = True
        Me.lblANC.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblANC.Location = New System.Drawing.Point(2, 384)
        Me.lblANC.Name = "lblANC"
        Me.lblANC.Size = New System.Drawing.Size(166, 19)
        Me.lblANC.TabIndex = 71
        Me.lblANC.Text = "ANC Probe Voltage (V)"
        '
        'txtANC
        '
        Me.txtANC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtANC.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtANC.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtANC.IsReadBack = True
        Me.txtANC.Location = New System.Drawing.Point(190, 380)
        Me.txtANC.MinimumValueHighlightedGreen = 0
        Me.txtANC.Multiline = True
        Me.txtANC.Name = "txtANC"
        Me.txtANC.ReadOnly = True
        Me.txtANC.Size = New System.Drawing.Size(100, 26)
        Me.txtANC.TabIndex = 70
        Me.txtANC.TabStop = False
        Me.txtANC.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtANC.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Two_Digits
        Me.txtANC.UseScientificFormat = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(2, 129)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(160, 19)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "PBN Body Voltage (V)"
        '
        'btnSourceSaveLoad
        '
        Me.btnSourceSaveLoad.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSourceSaveLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSourceSaveLoad.Clickable = True
        Me.btnSourceSaveLoad.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnSourceSaveLoad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSourceSaveLoad.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnSourceSaveLoad.FlatAppearance.BorderSize = 0
        Me.btnSourceSaveLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSourceSaveLoad.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSourceSaveLoad.ForeColor = System.Drawing.Color.Black
        Me.btnSourceSaveLoad.Location = New System.Drawing.Point(299, 364)
        Me.btnSourceSaveLoad.MessageBoxText = Nothing
        Me.btnSourceSaveLoad.Name = "btnSourceSaveLoad"
        Me.btnSourceSaveLoad.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSourceSaveLoad.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnSourceSaveLoad.Size = New System.Drawing.Size(99, 32)
        Me.btnSourceSaveLoad.TabIndex = 69
        Me.btnSourceSaveLoad.Text = "Save/Load"
        Me.btnSourceSaveLoad.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnSourceSaveLoad.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnSourceSaveLoad.UseClickedEventInForm = True
        Me.btnSourceSaveLoad.UseVisualStyleBackColor = True
        Me.btnSourceSaveLoad.ValueToBeSend = "On"
        '
        'btnSourceAuto
        '
        Me.btnSourceAuto.BackColor = System.Drawing.Color.Transparent
        Me.btnSourceAuto.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSourceAuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSourceAuto.Clickable = True
        Me.btnSourceAuto.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnSourceAuto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSourceAuto.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnSourceAuto.ErrorText = "Source Auto"
        Me.btnSourceAuto.FlatAppearance.BorderSize = 0
        Me.btnSourceAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSourceAuto.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSourceAuto.ForeColor = System.Drawing.Color.Black
        Me.btnSourceAuto.Location = New System.Drawing.Point(146, 410)
        Me.btnSourceAuto.MessageBoxText = Nothing
        Me.btnSourceAuto.Name = "btnSourceAuto"
        Me.btnSourceAuto.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSourceAuto.OffText = "Source Auto"
        Me.btnSourceAuto.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnSourceAuto.OnText = "Source Auto"
        Me.btnSourceAuto.Size = New System.Drawing.Size(121, 32)
        Me.btnSourceAuto.TabIndex = 13
        Me.btnSourceAuto.Text = "Source Auto"
        Me.btnSourceAuto.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnSourceAuto.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnSourceAuto.UnKnownText = "Source Auto"
        Me.btnSourceAuto.UseVisualStyleBackColor = False
        Me.btnSourceAuto.ValueToBeSend = "On"
        '
        'btnSourceManual
        '
        Me.btnSourceManual.BackColor = System.Drawing.Color.Transparent
        Me.btnSourceManual.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSourceManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSourceManual.Clickable = True
        Me.btnSourceManual.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnSourceManual.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSourceManual.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnSourceManual.ErrorText = "Source Manual"
        Me.btnSourceManual.FlatAppearance.BorderSize = 0
        Me.btnSourceManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSourceManual.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSourceManual.ForeColor = System.Drawing.Color.Black
        Me.btnSourceManual.Location = New System.Drawing.Point(15, 410)
        Me.btnSourceManual.MessageBoxText = Nothing
        Me.btnSourceManual.Name = "btnSourceManual"
        Me.btnSourceManual.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSourceManual.OffText = "Source Manual"
        Me.btnSourceManual.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnSourceManual.OnText = "Source Manual"
        Me.btnSourceManual.Size = New System.Drawing.Size(121, 32)
        Me.btnSourceManual.TabIndex = 12
        Me.btnSourceManual.Text = "Source Manual"
        Me.btnSourceManual.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnSourceManual.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnSourceManual.UnKnownText = "Source Manual"
        Me.btnSourceManual.UseVisualStyleBackColor = False
        Me.btnSourceManual.ValueToBeSend = "On"
        '
        'btnAutoBeam
        '
        Me.btnAutoBeam.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoBeam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoBeam.Clickable = True
        Me.btnAutoBeam.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoBeam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoBeam.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnAutoBeam.FlatAppearance.BorderSize = 0
        Me.btnAutoBeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoBeam.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoBeam.ForeColor = System.Drawing.Color.Black
        Me.btnAutoBeam.Location = New System.Drawing.Point(277, 410)
        Me.btnAutoBeam.MessageBoxText = Nothing
        Me.btnAutoBeam.Name = "btnAutoBeam"
        Me.btnAutoBeam.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoBeam.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnAutoBeam.Size = New System.Drawing.Size(121, 32)
        Me.btnAutoBeam.TabIndex = 14
        Me.btnAutoBeam.Text = "Auto Beam"
        Me.btnAutoBeam.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnAutoBeam.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnAutoBeam.UseClickedEventInForm = True
        Me.btnAutoBeam.UseVisualStyleBackColor = True
        Me.btnAutoBeam.ValueToBeSend = "On"
        '
        'txtRFPower
        '
        Me.txtRFPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRFPower.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRFPower.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRFPower.IsReadBack = True
        Me.txtRFPower.Location = New System.Drawing.Point(190, 110)
        Me.txtRFPower.MinimumValueHighlightedGreen = 0
        Me.txtRFPower.Multiline = True
        Me.txtRFPower.Name = "txtRFPower"
        Me.txtRFPower.ReadOnly = True
        Me.txtRFPower.Size = New System.Drawing.Size(100, 26)
        Me.txtRFPower.TabIndex = 68
        Me.txtRFPower.TabStop = False
        Me.txtRFPower.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRFPower.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        Me.txtRFPower.UseScientificFormat = True
        '
        'txtPBNDisch
        '
        Me.txtPBNDisch.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNDisch.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNDisch.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNDisch.IsReadBack = True
        Me.txtPBNDisch.Location = New System.Drawing.Point(190, 353)
        Me.txtPBNDisch.MinimumValueHighlightedGreen = 0
        Me.txtPBNDisch.Multiline = True
        Me.txtPBNDisch.Name = "txtPBNDisch"
        Me.txtPBNDisch.ReadOnly = True
        Me.txtPBNDisch.Size = New System.Drawing.Size(100, 26)
        Me.txtPBNDisch.TabIndex = 68
        Me.txtPBNDisch.TabStop = False
        Me.txtPBNDisch.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNDisch.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Two_Digits
        Me.txtPBNDisch.UseScientificFormat = True
        '
        'txtPBNBody
        '
        Me.txtPBNBody.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNBody.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNBody.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNBody.IsReadBack = True
        Me.txtPBNBody.Location = New System.Drawing.Point(190, 326)
        Me.txtPBNBody.MinimumValueHighlightedGreen = 0
        Me.txtPBNBody.Multiline = True
        Me.txtPBNBody.Name = "txtPBNBody"
        Me.txtPBNBody.ReadOnly = True
        Me.txtPBNBody.Size = New System.Drawing.Size(100, 26)
        Me.txtPBNBody.TabIndex = 68
        Me.txtPBNBody.TabStop = False
        Me.txtPBNBody.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNBody.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        Me.txtPBNBody.UseScientificFormat = True
        '
        'txtKFactor
        '
        Me.txtKFactor.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtKFactor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtKFactor.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtKFactor.IsReadBack = True
        Me.txtKFactor.Location = New System.Drawing.Point(190, 299)
        Me.txtKFactor.MinimumValueHighlightedGreen = 0
        Me.txtKFactor.Multiline = True
        Me.txtKFactor.Name = "txtKFactor"
        Me.txtKFactor.ReadOnly = True
        Me.txtKFactor.Size = New System.Drawing.Size(100, 26)
        Me.txtKFactor.TabIndex = 68
        Me.txtKFactor.TabStop = False
        Me.txtKFactor.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtKFactor.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtKFactor.UseScientificFormat = True
        '
        'txtGas4_SourceTab
        '
        Me.txtGas4_SourceTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas4_SourceTab.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas4_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas4_SourceTab.IsHighlightedGreen = True
        Me.txtGas4_SourceTab.IsReadBack = True
        Me.txtGas4_SourceTab.Location = New System.Drawing.Point(190, 272)
        Me.txtGas4_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtGas4_SourceTab.Multiline = True
        Me.txtGas4_SourceTab.Name = "txtGas4_SourceTab"
        Me.txtGas4_SourceTab.ReadOnly = True
        Me.txtGas4_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtGas4_SourceTab.TabIndex = 68
        Me.txtGas4_SourceTab.TabStop = False
        Me.txtGas4_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas4_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtPBNBodyVolt
        '
        Me.txtPBNBodyVolt.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNBodyVolt.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNBodyVolt.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNBodyVolt.IsReadBack = True
        Me.txtPBNBodyVolt.Location = New System.Drawing.Point(79, 299)
        Me.txtPBNBodyVolt.MinimumValueHighlightedGreen = 0
        Me.txtPBNBodyVolt.Multiline = True
        Me.txtPBNBodyVolt.Name = "txtPBNBodyVolt"
        Me.txtPBNBodyVolt.ReadOnly = True
        Me.txtPBNBodyVolt.Size = New System.Drawing.Size(100, 26)
        Me.txtPBNBodyVolt.TabIndex = 68
        Me.txtPBNBodyVolt.TabStop = False
        Me.txtPBNBodyVolt.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNBodyVolt.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas3_SourceTab
        '
        Me.txtGas3_SourceTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas3_SourceTab.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas3_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas3_SourceTab.IsHighlightedGreen = True
        Me.txtGas3_SourceTab.IsReadBack = True
        Me.txtGas3_SourceTab.Location = New System.Drawing.Point(190, 245)
        Me.txtGas3_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtGas3_SourceTab.Multiline = True
        Me.txtGas3_SourceTab.Name = "txtGas3_SourceTab"
        Me.txtGas3_SourceTab.ReadOnly = True
        Me.txtGas3_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtGas3_SourceTab.TabIndex = 68
        Me.txtGas3_SourceTab.TabStop = False
        Me.txtGas3_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas3_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas1_SourceTab
        '
        Me.txtGas1_SourceTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas1_SourceTab.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas1_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas1_SourceTab.IsHighlightedGreen = True
        Me.txtGas1_SourceTab.IsReadBack = True
        Me.txtGas1_SourceTab.Location = New System.Drawing.Point(190, 191)
        Me.txtGas1_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtGas1_SourceTab.Multiline = True
        Me.txtGas1_SourceTab.Name = "txtGas1_SourceTab"
        Me.txtGas1_SourceTab.ReadOnly = True
        Me.txtGas1_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtGas1_SourceTab.TabIndex = 68
        Me.txtGas1_SourceTab.TabStop = False
        Me.txtGas1_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas1_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtPBNGas_SourceTab
        '
        Me.txtPBNGas_SourceTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNGas_SourceTab.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNGas_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNGas_SourceTab.IsHighlightedGreen = True
        Me.txtPBNGas_SourceTab.IsReadBack = True
        Me.txtPBNGas_SourceTab.Location = New System.Drawing.Point(190, 164)
        Me.txtPBNGas_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtPBNGas_SourceTab.Multiline = True
        Me.txtPBNGas_SourceTab.Name = "txtPBNGas_SourceTab"
        Me.txtPBNGas_SourceTab.ReadOnly = True
        Me.txtPBNGas_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtPBNGas_SourceTab.TabIndex = 68
        Me.txtPBNGas_SourceTab.TabStop = False
        Me.txtPBNGas_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNGas_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtRFReflected
        '
        Me.txtRFReflected.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRFReflected.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRFReflected.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRFReflected.IsReadBack = True
        Me.txtRFReflected.Location = New System.Drawing.Point(190, 137)
        Me.txtRFReflected.MinimumValueHighlightedGreen = 0
        Me.txtRFReflected.Multiline = True
        Me.txtRFReflected.Name = "txtRFReflected"
        Me.txtRFReflected.ReadOnly = True
        Me.txtRFReflected.Size = New System.Drawing.Size(100, 26)
        Me.txtRFReflected.TabIndex = 68
        Me.txtRFReflected.TabStop = False
        Me.txtRFReflected.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRFReflected.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        Me.txtRFReflected.UseScientificFormat = True
        '
        'txtSuppressorCurrent
        '
        Me.txtSuppressorCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSuppressorCurrent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSuppressorCurrent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSuppressorCurrent.IsReadBack = True
        Me.txtSuppressorCurrent.Location = New System.Drawing.Point(190, 83)
        Me.txtSuppressorCurrent.MinimumValueHighlightedGreen = 0
        Me.txtSuppressorCurrent.Multiline = True
        Me.txtSuppressorCurrent.Name = "txtSuppressorCurrent"
        Me.txtSuppressorCurrent.ReadOnly = True
        Me.txtSuppressorCurrent.Size = New System.Drawing.Size(100, 26)
        Me.txtSuppressorCurrent.TabIndex = 68
        Me.txtSuppressorCurrent.TabStop = False
        Me.txtSuppressorCurrent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSuppressorCurrent.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        Me.txtSuppressorCurrent.UseScientificFormat = True
        '
        'txtSuppressorVoltage
        '
        Me.txtSuppressorVoltage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSuppressorVoltage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSuppressorVoltage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSuppressorVoltage.IsReadBack = True
        Me.txtSuppressorVoltage.Location = New System.Drawing.Point(190, 56)
        Me.txtSuppressorVoltage.MinimumValueHighlightedGreen = 0
        Me.txtSuppressorVoltage.Multiline = True
        Me.txtSuppressorVoltage.Name = "txtSuppressorVoltage"
        Me.txtSuppressorVoltage.ReadOnly = True
        Me.txtSuppressorVoltage.Size = New System.Drawing.Size(100, 26)
        Me.txtSuppressorVoltage.TabIndex = 68
        Me.txtSuppressorVoltage.TabStop = False
        Me.txtSuppressorVoltage.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSuppressorVoltage.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        Me.txtSuppressorVoltage.UseScientificFormat = True
        '
        'txtBeamCurrent
        '
        Me.txtBeamCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBeamCurrent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBeamCurrent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtBeamCurrent.IsReadBack = True
        Me.txtBeamCurrent.Location = New System.Drawing.Point(190, 29)
        Me.txtBeamCurrent.MinimumValueHighlightedGreen = 0
        Me.txtBeamCurrent.Multiline = True
        Me.txtBeamCurrent.Name = "txtBeamCurrent"
        Me.txtBeamCurrent.ReadOnly = True
        Me.txtBeamCurrent.Size = New System.Drawing.Size(100, 26)
        Me.txtBeamCurrent.TabIndex = 68
        Me.txtBeamCurrent.TabStop = False
        Me.txtBeamCurrent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBeamCurrent.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        Me.txtBeamCurrent.UseScientificFormat = True
        '
        'txtSuppressorVoltageRight
        '
        Me.txtSuppressorVoltageRight.AutoSendKeyTabWhenFinishInput = True
        Me.txtSuppressorVoltageRight.BackColor = System.Drawing.Color.White
        Me.txtSuppressorVoltageRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSuppressorVoltageRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSuppressorVoltageRight.IsNumericTextbox = True
        Me.txtSuppressorVoltageRight.Location = New System.Drawing.Point(299, 56)
        Me.txtSuppressorVoltageRight.MinimumValueHighlightedGreen = 0
        Me.txtSuppressorVoltageRight.Multiline = True
        Me.txtSuppressorVoltageRight.Name = "txtSuppressorVoltageRight"
        Me.txtSuppressorVoltageRight.ReadOnly = True
        Me.txtSuppressorVoltageRight.Size = New System.Drawing.Size(100, 26)
        Me.txtSuppressorVoltageRight.TabIndex = 2
        Me.txtSuppressorVoltageRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSuppressorVoltageRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtSuppressorVoltageRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        '
        'txtSuppressorCurrentRight
        '
        Me.txtSuppressorCurrentRight.AutoSendKeyTabWhenFinishInput = True
        Me.txtSuppressorCurrentRight.BackColor = System.Drawing.Color.White
        Me.txtSuppressorCurrentRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSuppressorCurrentRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSuppressorCurrentRight.IsNumericTextbox = True
        Me.txtSuppressorCurrentRight.Location = New System.Drawing.Point(299, 83)
        Me.txtSuppressorCurrentRight.MinimumValueHighlightedGreen = 0
        Me.txtSuppressorCurrentRight.Multiline = True
        Me.txtSuppressorCurrentRight.Name = "txtSuppressorCurrentRight"
        Me.txtSuppressorCurrentRight.ReadOnly = True
        Me.txtSuppressorCurrentRight.Size = New System.Drawing.Size(100, 26)
        Me.txtSuppressorCurrentRight.TabIndex = 3
        Me.txtSuppressorCurrentRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSuppressorCurrentRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        Me.txtSuppressorCurrentRight.Visible = False
        '
        'txtPBNDischRight
        '
        Me.txtPBNDischRight.BackColor = System.Drawing.Color.White
        Me.txtPBNDischRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPBNDischRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNDischRight.IsNumericTextbox = True
        Me.txtPBNDischRight.Location = New System.Drawing.Point(151, 359)
        Me.txtPBNDischRight.MinimumValueHighlightedGreen = 0
        Me.txtPBNDischRight.Multiline = True
        Me.txtPBNDischRight.Name = "txtPBNDischRight"
        Me.txtPBNDischRight.ReadOnly = True
        Me.txtPBNDischRight.Size = New System.Drawing.Size(28, 26)
        Me.txtPBNDischRight.TabIndex = 11
        Me.txtPBNDischRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNDischRight.Visible = False
        '
        'txtPBNBodyRight
        '
        Me.txtPBNBodyRight.BackColor = System.Drawing.Color.White
        Me.txtPBNBodyRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPBNBodyRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNBodyRight.IsNumericTextbox = True
        Me.txtPBNBodyRight.Location = New System.Drawing.Point(151, 328)
        Me.txtPBNBodyRight.MinimumValueHighlightedGreen = 0
        Me.txtPBNBodyRight.Multiline = True
        Me.txtPBNBodyRight.Name = "txtPBNBodyRight"
        Me.txtPBNBodyRight.ReadOnly = True
        Me.txtPBNBodyRight.Size = New System.Drawing.Size(28, 26)
        Me.txtPBNBodyRight.TabIndex = 10
        Me.txtPBNBodyRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNBodyRight.Visible = False
        '
        'txtGas4Right_SourceTab
        '
        Me.txtGas4Right_SourceTab.AutoSendKeyTabWhenFinishInput = True
        Me.txtGas4Right_SourceTab.BackColor = System.Drawing.Color.White
        Me.txtGas4Right_SourceTab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas4Right_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas4Right_SourceTab.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas4Right_SourceTab.IsNumericTextbox = True
        Me.txtGas4Right_SourceTab.Location = New System.Drawing.Point(299, 272)
        Me.txtGas4Right_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtGas4Right_SourceTab.Multiline = True
        Me.txtGas4Right_SourceTab.Name = "txtGas4Right_SourceTab"
        Me.txtGas4Right_SourceTab.ReadOnly = True
        Me.txtGas4Right_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtGas4Right_SourceTab.TabIndex = 10
        Me.txtGas4Right_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas4Right_SourceTab.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtGas4Right_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtKFactorRight
        '
        Me.txtKFactorRight.AutoSendKeyTabWhenFinishInput = True
        Me.txtKFactorRight.BackColor = System.Drawing.Color.White
        Me.txtKFactorRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtKFactorRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtKFactorRight.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtKFactorRight.IsNumericTextbox = True
        Me.txtKFactorRight.Location = New System.Drawing.Point(299, 299)
        Me.txtKFactorRight.MinimumValueHighlightedGreen = 0
        Me.txtKFactorRight.Multiline = True
        Me.txtKFactorRight.Name = "txtKFactorRight"
        Me.txtKFactorRight.ReadOnly = True
        Me.txtKFactorRight.Size = New System.Drawing.Size(100, 26)
        Me.txtKFactorRight.TabIndex = 11
        Me.txtKFactorRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtKFactorRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtKFactorRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas3Right_SourceTab
        '
        Me.txtGas3Right_SourceTab.AutoSendKeyTabWhenFinishInput = True
        Me.txtGas3Right_SourceTab.BackColor = System.Drawing.Color.White
        Me.txtGas3Right_SourceTab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas3Right_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas3Right_SourceTab.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas3Right_SourceTab.IsNumericTextbox = True
        Me.txtGas3Right_SourceTab.Location = New System.Drawing.Point(299, 245)
        Me.txtGas3Right_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtGas3Right_SourceTab.Multiline = True
        Me.txtGas3Right_SourceTab.Name = "txtGas3Right_SourceTab"
        Me.txtGas3Right_SourceTab.ReadOnly = True
        Me.txtGas3Right_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtGas3Right_SourceTab.TabIndex = 9
        Me.txtGas3Right_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas3Right_SourceTab.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtGas3Right_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas2Right_SourceTab
        '
        Me.txtGas2Right_SourceTab.AutoSendKeyTabWhenFinishInput = True
        Me.txtGas2Right_SourceTab.BackColor = System.Drawing.Color.White
        Me.txtGas2Right_SourceTab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas2Right_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas2Right_SourceTab.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas2Right_SourceTab.IsNumericTextbox = True
        Me.txtGas2Right_SourceTab.Location = New System.Drawing.Point(299, 218)
        Me.txtGas2Right_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtGas2Right_SourceTab.Multiline = True
        Me.txtGas2Right_SourceTab.Name = "txtGas2Right_SourceTab"
        Me.txtGas2Right_SourceTab.ReadOnly = True
        Me.txtGas2Right_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtGas2Right_SourceTab.TabIndex = 8
        Me.txtGas2Right_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas2Right_SourceTab.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtGas2Right_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas1Right_SourceTab
        '
        Me.txtGas1Right_SourceTab.AutoSendKeyTabWhenFinishInput = True
        Me.txtGas1Right_SourceTab.BackColor = System.Drawing.Color.White
        Me.txtGas1Right_SourceTab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas1Right_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas1Right_SourceTab.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas1Right_SourceTab.IsNumericTextbox = True
        Me.txtGas1Right_SourceTab.Location = New System.Drawing.Point(299, 191)
        Me.txtGas1Right_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtGas1Right_SourceTab.Multiline = True
        Me.txtGas1Right_SourceTab.Name = "txtGas1Right_SourceTab"
        Me.txtGas1Right_SourceTab.ReadOnly = True
        Me.txtGas1Right_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtGas1Right_SourceTab.TabIndex = 7
        Me.txtGas1Right_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas1Right_SourceTab.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtGas1Right_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtPBNGasRight_SourceTab
        '
        Me.txtPBNGasRight_SourceTab.AutoSendKeyTabWhenFinishInput = True
        Me.txtPBNGasRight_SourceTab.BackColor = System.Drawing.Color.White
        Me.txtPBNGasRight_SourceTab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPBNGasRight_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNGasRight_SourceTab.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtPBNGasRight_SourceTab.IsNumericTextbox = True
        Me.txtPBNGasRight_SourceTab.Location = New System.Drawing.Point(299, 164)
        Me.txtPBNGasRight_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtPBNGasRight_SourceTab.Multiline = True
        Me.txtPBNGasRight_SourceTab.Name = "txtPBNGasRight_SourceTab"
        Me.txtPBNGasRight_SourceTab.ReadOnly = True
        Me.txtPBNGasRight_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtPBNGasRight_SourceTab.TabIndex = 6
        Me.txtPBNGasRight_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNGasRight_SourceTab.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtPBNGasRight_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtRFReflectedRight
        '
        Me.txtRFReflectedRight.AutoSendKeyTabWhenFinishInput = True
        Me.txtRFReflectedRight.BackColor = System.Drawing.Color.White
        Me.txtRFReflectedRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRFReflectedRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRFReflectedRight.IsNumericTextbox = True
        Me.txtRFReflectedRight.Location = New System.Drawing.Point(299, 137)
        Me.txtRFReflectedRight.MinimumValueHighlightedGreen = 0
        Me.txtRFReflectedRight.Multiline = True
        Me.txtRFReflectedRight.Name = "txtRFReflectedRight"
        Me.txtRFReflectedRight.ReadOnly = True
        Me.txtRFReflectedRight.Size = New System.Drawing.Size(100, 26)
        Me.txtRFReflectedRight.TabIndex = 5
        Me.txtRFReflectedRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRFReflectedRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        Me.txtRFReflectedRight.Visible = False
        '
        'txtRFPowerRight
        '
        Me.txtRFPowerRight.AutoSendKeyTabWhenFinishInput = True
        Me.txtRFPowerRight.BackColor = System.Drawing.Color.White
        Me.txtRFPowerRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRFPowerRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRFPowerRight.IsNumericTextbox = True
        Me.txtRFPowerRight.Location = New System.Drawing.Point(299, 110)
        Me.txtRFPowerRight.MinimumValueHighlightedGreen = 0
        Me.txtRFPowerRight.Multiline = True
        Me.txtRFPowerRight.Name = "txtRFPowerRight"
        Me.txtRFPowerRight.ReadOnly = True
        Me.txtRFPowerRight.Size = New System.Drawing.Size(100, 26)
        Me.txtRFPowerRight.TabIndex = 4
        Me.txtRFPowerRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRFPowerRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtRFPowerRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        '
        'txtBeamCurrentRight
        '
        Me.txtBeamCurrentRight.AutoSendKeyTabWhenFinishInput = True
        Me.txtBeamCurrentRight.BackColor = System.Drawing.Color.White
        Me.txtBeamCurrentRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtBeamCurrentRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtBeamCurrentRight.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtBeamCurrentRight.IsNumericTextbox = True
        Me.txtBeamCurrentRight.Location = New System.Drawing.Point(299, 29)
        Me.txtBeamCurrentRight.MinimumValueHighlightedGreen = 0
        Me.txtBeamCurrentRight.Multiline = True
        Me.txtBeamCurrentRight.Name = "txtBeamCurrentRight"
        Me.txtBeamCurrentRight.ReadOnly = True
        Me.txtBeamCurrentRight.Size = New System.Drawing.Size(100, 26)
        Me.txtBeamCurrentRight.TabIndex = 1
        Me.txtBeamCurrentRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBeamCurrentRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtBeamCurrentRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        '
        'txtBeamVoltageRight
        '
        Me.txtBeamVoltageRight.AutoSendKeyTabWhenFinishInput = True
        Me.txtBeamVoltageRight.BackColor = System.Drawing.Color.White
        Me.txtBeamVoltageRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtBeamVoltageRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtBeamVoltageRight.IsNumericTextbox = True
        Me.txtBeamVoltageRight.Location = New System.Drawing.Point(299, 2)
        Me.txtBeamVoltageRight.MinimumValueHighlightedGreen = 0
        Me.txtBeamVoltageRight.Multiline = True
        Me.txtBeamVoltageRight.Name = "txtBeamVoltageRight"
        Me.txtBeamVoltageRight.ReadOnly = True
        Me.txtBeamVoltageRight.Size = New System.Drawing.Size(100, 26)
        Me.txtBeamVoltageRight.TabIndex = 0
        Me.txtBeamVoltageRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBeamVoltageRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtBeamVoltageRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        '
        'lblSourceGas4
        '
        Me.lblSourceGas4.AutoSize = True
        Me.lblSourceGas4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourceGas4.Location = New System.Drawing.Point(2, 276)
        Me.lblSourceGas4.Name = "lblSourceGas4"
        Me.lblSourceGas4.Size = New System.Drawing.Size(48, 19)
        Me.lblSourceGas4.TabIndex = 0
        Me.lblSourceGas4.Text = "Gas 4"
        '
        'txtBeamVoltage
        '
        Me.txtBeamVoltage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBeamVoltage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBeamVoltage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtBeamVoltage.IsReadBack = True
        Me.txtBeamVoltage.Location = New System.Drawing.Point(190, 2)
        Me.txtBeamVoltage.MinimumValueHighlightedGreen = 0
        Me.txtBeamVoltage.Multiline = True
        Me.txtBeamVoltage.Name = "txtBeamVoltage"
        Me.txtBeamVoltage.ReadOnly = True
        Me.txtBeamVoltage.Size = New System.Drawing.Size(100, 26)
        Me.txtBeamVoltage.TabIndex = 68
        Me.txtBeamVoltage.TabStop = False
        Me.txtBeamVoltage.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBeamVoltage.UseDigitNumber = AVP_Robot_Project.DigitsNumber.None_Digit
        Me.txtBeamVoltage.UseScientificFormat = True
        '
        'lblSourceGas2
        '
        Me.lblSourceGas2.AutoSize = True
        Me.lblSourceGas2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourceGas2.Location = New System.Drawing.Point(2, 222)
        Me.lblSourceGas2.Name = "lblSourceGas2"
        Me.lblSourceGas2.Size = New System.Drawing.Size(48, 19)
        Me.lblSourceGas2.TabIndex = 0
        Me.lblSourceGas2.Text = "Gas 2"
        '
        'lblSourceGas3
        '
        Me.lblSourceGas3.AutoSize = True
        Me.lblSourceGas3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourceGas3.Location = New System.Drawing.Point(2, 249)
        Me.lblSourceGas3.Name = "lblSourceGas3"
        Me.lblSourceGas3.Size = New System.Drawing.Size(48, 19)
        Me.lblSourceGas3.TabIndex = 0
        Me.lblSourceGas3.Text = "Gas 3"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(2, 357)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(138, 19)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "PBN Discharge (A)"
        '
        'lblSourceGas1
        '
        Me.lblSourceGas1.AutoSize = True
        Me.lblSourceGas1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourceGas1.Location = New System.Drawing.Point(2, 195)
        Me.lblSourceGas1.Name = "lblSourceGas1"
        Me.lblSourceGas1.Size = New System.Drawing.Size(48, 19)
        Me.lblSourceGas1.TabIndex = 0
        Me.lblSourceGas1.Text = "Gas 1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 330)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 19)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "PBN Body (mA)"
        '
        'lblSourcePBNGas
        '
        Me.lblSourcePBNGas.AutoSize = True
        Me.lblSourcePBNGas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourcePBNGas.Location = New System.Drawing.Point(2, 168)
        Me.lblSourcePBNGas.Name = "lblSourcePBNGas"
        Me.lblSourcePBNGas.Size = New System.Drawing.Size(119, 19)
        Me.lblSourcePBNGas.TabIndex = 0
        Me.lblSourcePBNGas.Text = "PBN Gas (sccm)"
        '
        'lblKFactor
        '
        Me.lblKFactor.AutoSize = True
        Me.lblKFactor.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKFactor.Location = New System.Drawing.Point(2, 303)
        Me.lblKFactor.Name = "lblKFactor"
        Me.lblKFactor.Size = New System.Drawing.Size(68, 19)
        Me.lblKFactor.TabIndex = 0
        Me.lblKFactor.Text = "K Factor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(2, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "RF Reflected (W)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "RF Power (W)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Suppressor Current (mA)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(164, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Suppressor Voltage (V)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Beam Current (mA)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Beam Voltage (V)"
        '
        'txtGas2_SourceTab
        '
        Me.txtGas2_SourceTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas2_SourceTab.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas2_SourceTab.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas2_SourceTab.IsHighlightedGreen = True
        Me.txtGas2_SourceTab.IsReadBack = True
        Me.txtGas2_SourceTab.Location = New System.Drawing.Point(190, 218)
        Me.txtGas2_SourceTab.MinimumValueHighlightedGreen = 0
        Me.txtGas2_SourceTab.Multiline = True
        Me.txtGas2_SourceTab.Name = "txtGas2_SourceTab"
        Me.txtGas2_SourceTab.ReadOnly = True
        Me.txtGas2_SourceTab.Size = New System.Drawing.Size(100, 26)
        Me.txtGas2_SourceTab.TabIndex = 68
        Me.txtGas2_SourceTab.TabStop = False
        Me.txtGas2_SourceTab.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas2_SourceTab.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'tabProcessStatus
        '
        Me.tabProcessStatus.BackColor = System.Drawing.Color.Transparent
        Me.tabProcessStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabProcessStatus.Controls.Add(Me.txtElapsedTime)
        Me.tabProcessStatus.Controls.Add(Me.txtTotalStep)
        Me.tabProcessStatus.Controls.Add(Me.txtProcessStep)
        Me.tabProcessStatus.Controls.Add(Me.txtSourceMinutes)
        Me.tabProcessStatus.Controls.Add(Me.txtStatus)
        Me.tabProcessStatus.Controls.Add(Me.txtStepTime)
        Me.tabProcessStatus.Controls.Add(Me.txtRemainingTime)
        Me.tabProcessStatus.Controls.Add(Me.txtWaferID)
        Me.tabProcessStatus.Controls.Add(Me.txtRecipe)
        Me.tabProcessStatus.Controls.Add(Me.Label24)
        Me.tabProcessStatus.Controls.Add(Me.Label18)
        Me.tabProcessStatus.Controls.Add(Me.Label17)
        Me.tabProcessStatus.Controls.Add(Me.Label16)
        Me.tabProcessStatus.Controls.Add(Me.Label15)
        Me.tabProcessStatus.Controls.Add(Me.Label14)
        Me.tabProcessStatus.Controls.Add(Me.Label13)
        Me.tabProcessStatus.Controls.Add(Me.Label12)
        Me.tabProcessStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabProcessStatus.Location = New System.Drawing.Point(0, 31)
        Me.tabProcessStatus.Name = "tabProcessStatus"
        Me.tabProcessStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProcessStatus.Size = New System.Drawing.Size(412, 447)
        Me.tabProcessStatus.TabIndex = 1
        Me.tabProcessStatus.Text = "Process Status"
        '
        'txtElapsedTime
        '
        Me.txtElapsedTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtElapsedTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtElapsedTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtElapsedTime.IsReadBack = True
        Me.txtElapsedTime.Location = New System.Drawing.Point(160, 138)
        Me.txtElapsedTime.MinimumValueHighlightedGreen = 0
        Me.txtElapsedTime.Multiline = True
        Me.txtElapsedTime.Name = "txtElapsedTime"
        Me.txtElapsedTime.ReadOnly = True
        Me.txtElapsedTime.Size = New System.Drawing.Size(241, 26)
        Me.txtElapsedTime.TabIndex = 69
        Me.txtElapsedTime.TabStop = False
        Me.txtElapsedTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtElapsedTime.UseScientificFormat = True
        '
        'txtTotalStep
        '
        Me.txtTotalStep.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalStep.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalStep.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalStep.IsReadBack = True
        Me.txtTotalStep.Location = New System.Drawing.Point(160, 304)
        Me.txtTotalStep.MinimumValueHighlightedGreen = 0
        Me.txtTotalStep.Multiline = True
        Me.txtTotalStep.Name = "txtTotalStep"
        Me.txtTotalStep.ReadOnly = True
        Me.txtTotalStep.Size = New System.Drawing.Size(30, 26)
        Me.txtTotalStep.TabIndex = 69
        Me.txtTotalStep.TabStop = False
        Me.txtTotalStep.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTotalStep.UseScientificFormat = True
        Me.txtTotalStep.Visible = False
        '
        'txtProcessStep
        '
        Me.txtProcessStep.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProcessStep.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtProcessStep.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtProcessStep.IsReadBack = True
        Me.txtProcessStep.Location = New System.Drawing.Point(160, 178)
        Me.txtProcessStep.MinimumValueHighlightedGreen = 0
        Me.txtProcessStep.Multiline = True
        Me.txtProcessStep.Name = "txtProcessStep"
        Me.txtProcessStep.ReadOnly = True
        Me.txtProcessStep.Size = New System.Drawing.Size(241, 26)
        Me.txtProcessStep.TabIndex = 69
        Me.txtProcessStep.TabStop = False
        Me.txtProcessStep.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtProcessStep.UseScientificFormat = True
        '
        'txtSourceMinutes
        '
        Me.txtSourceMinutes.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSourceMinutes.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSourceMinutes.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSourceMinutes.IsReadBack = True
        Me.txtSourceMinutes.Location = New System.Drawing.Point(160, 258)
        Me.txtSourceMinutes.MinimumValueHighlightedGreen = 0
        Me.txtSourceMinutes.Multiline = True
        Me.txtSourceMinutes.Name = "txtSourceMinutes"
        Me.txtSourceMinutes.ReadOnly = True
        Me.txtSourceMinutes.Size = New System.Drawing.Size(241, 26)
        Me.txtSourceMinutes.TabIndex = 69
        Me.txtSourceMinutes.TabStop = False
        Me.txtSourceMinutes.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSourceMinutes.UseScientificFormat = True
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStatus.IsReadBack = True
        Me.txtStatus.Location = New System.Drawing.Point(160, 218)
        Me.txtStatus.MinimumValueHighlightedGreen = 0
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(241, 26)
        Me.txtStatus.TabIndex = 69
        Me.txtStatus.TabStop = False
        Me.txtStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtStatus.UseScientificFormat = True
        '
        'txtStepTime
        '
        Me.txtStepTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStepTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStepTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStepTime.IsReadBack = True
        Me.txtStepTime.Location = New System.Drawing.Point(160, 337)
        Me.txtStepTime.MinimumValueHighlightedGreen = 0
        Me.txtStepTime.Multiline = True
        Me.txtStepTime.Name = "txtStepTime"
        Me.txtStepTime.ReadOnly = True
        Me.txtStepTime.Size = New System.Drawing.Size(241, 26)
        Me.txtStepTime.TabIndex = 69
        Me.txtStepTime.TabStop = False
        Me.txtStepTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtStepTime.UseScientificFormat = True
        Me.txtStepTime.Visible = False
        '
        'txtRemainingTime
        '
        Me.txtRemainingTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRemainingTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRemainingTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRemainingTime.IsReadBack = True
        Me.txtRemainingTime.Location = New System.Drawing.Point(160, 98)
        Me.txtRemainingTime.MinimumValueHighlightedGreen = 0
        Me.txtRemainingTime.Multiline = True
        Me.txtRemainingTime.Name = "txtRemainingTime"
        Me.txtRemainingTime.ReadOnly = True
        Me.txtRemainingTime.Size = New System.Drawing.Size(241, 26)
        Me.txtRemainingTime.TabIndex = 69
        Me.txtRemainingTime.TabStop = False
        Me.txtRemainingTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRemainingTime.UseScientificFormat = True
        '
        'txtWaferID
        '
        Me.txtWaferID.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtWaferID.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtWaferID.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtWaferID.IsReadBack = True
        Me.txtWaferID.Location = New System.Drawing.Point(160, 58)
        Me.txtWaferID.MinimumValueHighlightedGreen = 0
        Me.txtWaferID.Multiline = True
        Me.txtWaferID.Name = "txtWaferID"
        Me.txtWaferID.ReadOnly = True
        Me.txtWaferID.Size = New System.Drawing.Size(241, 26)
        Me.txtWaferID.TabIndex = 69
        Me.txtWaferID.TabStop = False
        Me.txtWaferID.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtWaferID.UseScientificFormat = True
        '
        'txtRecipe
        '
        Me.txtRecipe.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRecipe.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRecipe.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRecipe.IsReadBack = True
        Me.txtRecipe.Location = New System.Drawing.Point(160, 18)
        Me.txtRecipe.MinimumValueHighlightedGreen = 0
        Me.txtRecipe.Multiline = True
        Me.txtRecipe.Name = "txtRecipe"
        Me.txtRecipe.ReadOnly = True
        Me.txtRecipe.Size = New System.Drawing.Size(241, 26)
        Me.txtRecipe.TabIndex = 69
        Me.txtRecipe.TabStop = False
        Me.txtRecipe.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRecipe.UseScientificFormat = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(12, 261)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(115, 19)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Source Minutes"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(12, 221)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 19)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Status"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(12, 339)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 19)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Step Time"
        Me.Label17.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(12, 181)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 19)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Process Step"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(12, 141)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 19)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Elapsed Time"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(12, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 19)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Remaining Time"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(12, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 19)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Wafer ID"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(12, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 19)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Recipe"
        '
        'tabGas
        '
        Me.tabGas.BackColor = System.Drawing.Color.Transparent
        Me.tabGas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabGas.Controls.Add(Me.ValveDiverter)
        Me.tabGas.Controls.Add(Me.GasLine3_Total_Below)
        Me.tabGas.Controls.Add(Me.GasLine2_Total_Below)
        Me.tabGas.Controls.Add(Me.GasLine3_Total)
        Me.tabGas.Controls.Add(Me.GasLine_Shutoff3)
        Me.tabGas.Controls.Add(Me.GasLine2_Total)
        Me.tabGas.Controls.Add(Me.GasLine_Shutoff2)
        Me.tabGas.Controls.Add(Me.ValveSupplyGas4)
        Me.tabGas.Controls.Add(Me.ValveSupplyGas3)
        Me.tabGas.Controls.Add(Me.ValveSupplyGas2)
        Me.tabGas.Controls.Add(Me.ValveSupplyGas1)
        Me.tabGas.Controls.Add(Me.GasLine1_Total)
        Me.tabGas.Controls.Add(Me.GasLine1_Total_Below)
        Me.tabGas.Controls.Add(Me.btnOpenCloseGas4)
        Me.tabGas.Controls.Add(Me.btnOpenCloseGas3)
        Me.tabGas.Controls.Add(Me.btnOpenCloseGas2)
        Me.tabGas.Controls.Add(Me.btnOpenCloseGas1)
        Me.tabGas.Controls.Add(Me.btnOpenClosePBNGas)
        Me.tabGas.Controls.Add(Me.txtGas4)
        Me.tabGas.Controls.Add(Me.txtGas3)
        Me.tabGas.Controls.Add(Me.txtGas2)
        Me.tabGas.Controls.Add(Me.txtGas1)
        Me.tabGas.Controls.Add(Me.txtGas4Right)
        Me.tabGas.Controls.Add(Me.txtGas3Right)
        Me.tabGas.Controls.Add(Me.txtGas2Right)
        Me.tabGas.Controls.Add(Me.txtGas1Right)
        Me.tabGas.Controls.Add(Me.txtPBNGasRight)
        Me.tabGas.Controls.Add(Me.txtPBNGas)
        Me.tabGas.Controls.Add(Me.lblGas4)
        Me.tabGas.Controls.Add(Me.lblGas3)
        Me.tabGas.Controls.Add(Me.lblGasPBN)
        Me.tabGas.Controls.Add(Me.lblGas2)
        Me.tabGas.Controls.Add(Me.lblGas1)
        Me.tabGas.Controls.Add(Me.GasLine_Shutoff4)
        Me.tabGas.Controls.Add(Me.GasLine_PBNShutoff)
        Me.tabGas.Controls.Add(Me.GasLine_Shutoff1)
        Me.tabGas.Controls.Add(Me.GasLine_PBNSupply)
        Me.tabGas.Controls.Add(Me.GasLine_Supply1)
        Me.tabGas.Controls.Add(Me.GasLine_Supply2)
        Me.tabGas.Controls.Add(Me.GasLine_Supply4)
        Me.tabGas.Controls.Add(Me.GasLine_Supply3)
        Me.tabGas.Controls.Add(Me.ValveShutoffPBNGas)
        Me.tabGas.Controls.Add(Me.ValveShutoffGas1)
        Me.tabGas.Controls.Add(Me.ValveShutoffGas4)
        Me.tabGas.Controls.Add(Me.ValveShutoffGas2)
        Me.tabGas.Controls.Add(Me.ValveShutoffGas3)
        Me.tabGas.Controls.Add(Me.ValveSupplyPBNGas)
        Me.tabGas.Controls.Add(Me.GasLine_Total1)
        Me.tabGas.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabGas.Location = New System.Drawing.Point(0, 31)
        Me.tabGas.Name = "tabGas"
        Me.tabGas.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGas.Size = New System.Drawing.Size(412, 447)
        Me.tabGas.TabIndex = 2
        Me.tabGas.Text = "Gases"
        '
        'ValveDiverter
        '
        Me.ValveDiverter.AccessibleName = "Vent Valve"
        Me.ValveDiverter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveDiverter.IsCheckSafetyBeforeClick = False
        Me.ValveDiverter.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveDiverter.Location = New System.Drawing.Point(13, 222)
        Me.ValveDiverter.Name = "ValveDiverter"
        Me.ValveDiverter.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.DiverterValve_Off
        Me.ValveDiverter.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveDiverter.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.DiverterValve_On
        Me.ValveDiverter.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveDiverter.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveDiverter.Size = New System.Drawing.Size(30, 30)
        Me.ValveDiverter.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveDiverter.TabIndex = 237
        Me.ValveDiverter.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveDiverter.TextLocIsFix = True
        Me.ValveDiverter.TextValue = ""
        Me.ValveDiverter.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveDiverter.Unit = ""
        Me.ValveDiverter.UnknownImage = Nothing
        Me.ValveDiverter.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveDiverter.UseClickedEventInForm = True
        Me.ValveDiverter.UsingScientificFormat = True
        Me.ValveDiverter.Visible = False
        '
        'GasLine3_Total_Below
        '
        Me.GasLine3_Total_Below.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine3_Total_Below.BackColor = System.Drawing.Color.Transparent
        Me.GasLine3_Total_Below.Location = New System.Drawing.Point(21, 322)
        Me.GasLine3_Total_Below.Name = "GasLine3_Total_Below"
        Me.GasLine3_Total_Below.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_Below
        Me.GasLine3_Total_Below.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_Below_On
        Me.GasLine3_Total_Below.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_Below_On_1
        Me.GasLine3_Total_Below.Size = New System.Drawing.Size(15, 34)
        Me.GasLine3_Total_Below.TabIndex = 253
        '
        'GasLine2_Total_Below
        '
        Me.GasLine2_Total_Below.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine2_Total_Below.BackColor = System.Drawing.Color.Transparent
        Me.GasLine2_Total_Below.Location = New System.Drawing.Point(21, 249)
        Me.GasLine2_Total_Below.Name = "GasLine2_Total_Below"
        Me.GasLine2_Total_Below.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasDiverterBelow
        Me.GasLine2_Total_Below.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasDiverterBelow_On
        Me.GasLine2_Total_Below.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasDiverterBelow_On1
        Me.GasLine2_Total_Below.Size = New System.Drawing.Size(15, 27)
        Me.GasLine2_Total_Below.TabIndex = 252
        '
        'GasLine3_Total
        '
        Me.GasLine3_Total.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine3_Total.BackColor = System.Drawing.Color.Transparent
        Me.GasLine3_Total.Location = New System.Drawing.Point(21, 276)
        Me.GasLine3_Total.Name = "GasLine3_Total"
        Me.GasLine3_Total.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical
        Me.GasLine3_Total.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_On
        Me.GasLine3_Total.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_On_1
        Me.GasLine3_Total.Size = New System.Drawing.Size(15, 46)
        Me.GasLine3_Total.TabIndex = 250
        '
        'GasLine_Shutoff3
        '
        Me.GasLine_Shutoff3.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Shutoff3.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_Shutoff3.Location = New System.Drawing.Point(33, 310)
        Me.GasLine_Shutoff3.Name = "GasLine_Shutoff3"
        Me.GasLine_Shutoff3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal
        Me.GasLine_Shutoff3.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_On
        Me.GasLine_Shutoff3.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_On_1
        Me.GasLine_Shutoff3.Size = New System.Drawing.Size(18, 15)
        Me.GasLine_Shutoff3.TabIndex = 247
        '
        'GasLine2_Total
        '
        Me.GasLine2_Total.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine2_Total.BackColor = System.Drawing.Color.Transparent
        Me.GasLine2_Total.Location = New System.Drawing.Point(21, 196)
        Me.GasLine2_Total.Name = "GasLine2_Total"
        Me.GasLine2_Total.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasDiverter
        Me.GasLine2_Total.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasDiverter_On
        Me.GasLine2_Total.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasDiverter_On1
        Me.GasLine2_Total.Size = New System.Drawing.Size(15, 28)
        Me.GasLine2_Total.TabIndex = 245
        '
        'GasLine_Shutoff2
        '
        Me.GasLine_Shutoff2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Shutoff2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_Shutoff2.Location = New System.Drawing.Point(42, 230)
        Me.GasLine_Shutoff2.Name = "GasLine_Shutoff2"
        Me.GasLine_Shutoff2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas2ShutOffDiverter
        Me.GasLine_Shutoff2.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas2ShutOffDiverter_On
        Me.GasLine_Shutoff2.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas2ShutOffDiverter
        Me.GasLine_Shutoff2.Size = New System.Drawing.Size(9, 15)
        Me.GasLine_Shutoff2.TabIndex = 242
        '
        'ValveSupplyGas4
        '
        Me.ValveSupplyGas4.AccessibleName = "Supply Gas4 Valve"
        Me.ValveSupplyGas4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupplyGas4.IsCheckSafetyBeforeClick = False
        Me.ValveSupplyGas4.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupplyGas4.Location = New System.Drawing.Point(298, 380)
        Me.ValveSupplyGas4.Name = "ValveSupplyGas4"
        Me.ValveSupplyGas4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupplyGas4.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupplyGas4.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas4.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupplyGas4.Size = New System.Drawing.Size(40, 33)
        Me.ValveSupplyGas4.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupplyGas4.TabIndex = 182
        Me.ValveSupplyGas4.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupplyGas4.TextLocIsFix = True
        Me.ValveSupplyGas4.TextValue = ""
        Me.ValveSupplyGas4.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupplyGas4.Unit = ""
        Me.ValveSupplyGas4.UnknownImage = Nothing
        Me.ValveSupplyGas4.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas4.UseClickedEventInForm = True
        Me.ValveSupplyGas4.UsingScientificFormat = True
        '
        'ValveSupplyGas3
        '
        Me.ValveSupplyGas3.AccessibleName = "Supply Gas3 Valve"
        Me.ValveSupplyGas3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupplyGas3.IsCheckSafetyBeforeClick = False
        Me.ValveSupplyGas3.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupplyGas3.Location = New System.Drawing.Point(298, 301)
        Me.ValveSupplyGas3.Name = "ValveSupplyGas3"
        Me.ValveSupplyGas3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupplyGas3.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupplyGas3.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas3.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupplyGas3.Size = New System.Drawing.Size(40, 33)
        Me.ValveSupplyGas3.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupplyGas3.TabIndex = 182
        Me.ValveSupplyGas3.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupplyGas3.TextLocIsFix = True
        Me.ValveSupplyGas3.TextValue = ""
        Me.ValveSupplyGas3.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupplyGas3.Unit = ""
        Me.ValveSupplyGas3.UnknownImage = Nothing
        Me.ValveSupplyGas3.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas3.UseClickedEventInForm = True
        Me.ValveSupplyGas3.UsingScientificFormat = True
        '
        'ValveSupplyGas2
        '
        Me.ValveSupplyGas2.AccessibleName = "Supply Gas2 Valve"
        Me.ValveSupplyGas2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupplyGas2.IsCheckSafetyBeforeClick = False
        Me.ValveSupplyGas2.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupplyGas2.Location = New System.Drawing.Point(298, 221)
        Me.ValveSupplyGas2.Name = "ValveSupplyGas2"
        Me.ValveSupplyGas2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupplyGas2.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupplyGas2.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas2.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupplyGas2.Size = New System.Drawing.Size(40, 33)
        Me.ValveSupplyGas2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupplyGas2.TabIndex = 183
        Me.ValveSupplyGas2.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupplyGas2.TextLocIsFix = True
        Me.ValveSupplyGas2.TextValue = ""
        Me.ValveSupplyGas2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupplyGas2.Unit = ""
        Me.ValveSupplyGas2.UnknownImage = Nothing
        Me.ValveSupplyGas2.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas2.UseClickedEventInForm = True
        Me.ValveSupplyGas2.UsingScientificFormat = True
        '
        'ValveSupplyGas1
        '
        Me.ValveSupplyGas1.AccessibleName = "Supply Gas1 Valve"
        Me.ValveSupplyGas1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupplyGas1.IsCheckSafetyBeforeClick = False
        Me.ValveSupplyGas1.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupplyGas1.Location = New System.Drawing.Point(298, 141)
        Me.ValveSupplyGas1.Name = "ValveSupplyGas1"
        Me.ValveSupplyGas1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupplyGas1.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupplyGas1.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas1.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupplyGas1.Size = New System.Drawing.Size(40, 33)
        Me.ValveSupplyGas1.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupplyGas1.TabIndex = 185
        Me.ValveSupplyGas1.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupplyGas1.TextLocIsFix = True
        Me.ValveSupplyGas1.TextValue = ""
        Me.ValveSupplyGas1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupplyGas1.Unit = ""
        Me.ValveSupplyGas1.UnknownImage = Nothing
        Me.ValveSupplyGas1.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyGas1.UseClickedEventInForm = True
        Me.ValveSupplyGas1.UsingScientificFormat = True
        '
        'GasLine1_Total
        '
        Me.GasLine1_Total.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine1_Total.BackColor = System.Drawing.Color.Transparent
        Me.GasLine1_Total.Location = New System.Drawing.Point(21, 116)
        Me.GasLine1_Total.Name = "GasLine1_Total"
        Me.GasLine1_Total.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical
        Me.GasLine1_Total.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_On
        Me.GasLine1_Total.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_On_1
        Me.GasLine1_Total.Size = New System.Drawing.Size(15, 46)
        Me.GasLine1_Total.TabIndex = 235
        '
        'GasLine1_Total_Below
        '
        Me.GasLine1_Total_Below.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine1_Total_Below.BackColor = System.Drawing.Color.Transparent
        Me.GasLine1_Total_Below.Location = New System.Drawing.Point(21, 162)
        Me.GasLine1_Total_Below.Name = "GasLine1_Total_Below"
        Me.GasLine1_Total_Below.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_Below
        Me.GasLine1_Total_Below.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_Below_On
        Me.GasLine1_Total_Below.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_Below_On_1
        Me.GasLine1_Total_Below.Size = New System.Drawing.Size(15, 34)
        Me.GasLine1_Total_Below.TabIndex = 235
        '
        'btnOpenCloseGas4
        '
        Me.btnOpenCloseGas4.AccessibleName = "Shutoff/Supply Gas4"
        Me.btnOpenCloseGas4.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenCloseGas4.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenCloseGas4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenCloseGas4.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOpenCloseGas4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenCloseGas4.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnOpenCloseGas4.FlatAppearance.BorderSize = 0
        Me.btnOpenCloseGas4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenCloseGas4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenCloseGas4.ForeColor = System.Drawing.Color.Black
        Me.btnOpenCloseGas4.Location = New System.Drawing.Point(157, 385)
        Me.btnOpenCloseGas4.MessageBoxText = Nothing
        Me.btnOpenCloseGas4.Name = "btnOpenCloseGas4"
        Me.btnOpenCloseGas4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenCloseGas4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOpenCloseGas4.Size = New System.Drawing.Size(70, 30)
        Me.btnOpenCloseGas4.TabIndex = 217
        Me.btnOpenCloseGas4.Text = "On/Off"
        Me.btnOpenCloseGas4.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnOpenCloseGas4.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnOpenCloseGas4.UseClickedEventInForm = True
        Me.btnOpenCloseGas4.UseVisualStyleBackColor = False
        Me.btnOpenCloseGas4.ValueToBeSend = "On"
        '
        'btnOpenCloseGas3
        '
        Me.btnOpenCloseGas3.AccessibleName = "Shutoff/Supply Gas3"
        Me.btnOpenCloseGas3.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenCloseGas3.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenCloseGas3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenCloseGas3.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOpenCloseGas3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenCloseGas3.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnOpenCloseGas3.FlatAppearance.BorderSize = 0
        Me.btnOpenCloseGas3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenCloseGas3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenCloseGas3.ForeColor = System.Drawing.Color.Black
        Me.btnOpenCloseGas3.Location = New System.Drawing.Point(157, 304)
        Me.btnOpenCloseGas3.MessageBoxText = Nothing
        Me.btnOpenCloseGas3.Name = "btnOpenCloseGas3"
        Me.btnOpenCloseGas3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenCloseGas3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOpenCloseGas3.Size = New System.Drawing.Size(70, 30)
        Me.btnOpenCloseGas3.TabIndex = 217
        Me.btnOpenCloseGas3.Text = "On/Off"
        Me.btnOpenCloseGas3.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnOpenCloseGas3.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnOpenCloseGas3.UseClickedEventInForm = True
        Me.btnOpenCloseGas3.UseVisualStyleBackColor = False
        Me.btnOpenCloseGas3.ValueToBeSend = "On"
        '
        'btnOpenCloseGas2
        '
        Me.btnOpenCloseGas2.AccessibleName = "Shutoff/Supply Gas2"
        Me.btnOpenCloseGas2.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenCloseGas2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenCloseGas2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenCloseGas2.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOpenCloseGas2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenCloseGas2.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnOpenCloseGas2.FlatAppearance.BorderSize = 0
        Me.btnOpenCloseGas2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenCloseGas2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenCloseGas2.ForeColor = System.Drawing.Color.Black
        Me.btnOpenCloseGas2.Location = New System.Drawing.Point(157, 220)
        Me.btnOpenCloseGas2.MessageBoxText = Nothing
        Me.btnOpenCloseGas2.Name = "btnOpenCloseGas2"
        Me.btnOpenCloseGas2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenCloseGas2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOpenCloseGas2.Size = New System.Drawing.Size(70, 30)
        Me.btnOpenCloseGas2.TabIndex = 217
        Me.btnOpenCloseGas2.Text = "On/Off"
        Me.btnOpenCloseGas2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnOpenCloseGas2.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnOpenCloseGas2.UseClickedEventInForm = True
        Me.btnOpenCloseGas2.UseVisualStyleBackColor = False
        Me.btnOpenCloseGas2.ValueToBeSend = "On"
        '
        'btnOpenCloseGas1
        '
        Me.btnOpenCloseGas1.AccessibleName = "Shutoff/Supply Gas1"
        Me.btnOpenCloseGas1.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenCloseGas1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenCloseGas1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenCloseGas1.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOpenCloseGas1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenCloseGas1.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnOpenCloseGas1.FlatAppearance.BorderSize = 0
        Me.btnOpenCloseGas1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenCloseGas1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenCloseGas1.ForeColor = System.Drawing.Color.Black
        Me.btnOpenCloseGas1.Location = New System.Drawing.Point(157, 141)
        Me.btnOpenCloseGas1.MessageBoxText = Nothing
        Me.btnOpenCloseGas1.Name = "btnOpenCloseGas1"
        Me.btnOpenCloseGas1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenCloseGas1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOpenCloseGas1.Size = New System.Drawing.Size(70, 30)
        Me.btnOpenCloseGas1.TabIndex = 217
        Me.btnOpenCloseGas1.Text = "On/Off"
        Me.btnOpenCloseGas1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnOpenCloseGas1.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnOpenCloseGas1.UseClickedEventInForm = True
        Me.btnOpenCloseGas1.UseVisualStyleBackColor = False
        Me.btnOpenCloseGas1.ValueToBeSend = "On"
        '
        'btnOpenClosePBNGas
        '
        Me.btnOpenClosePBNGas.AccessibleName = "Shutoff/Supply PBN Gas"
        Me.btnOpenClosePBNGas.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenClosePBNGas.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenClosePBNGas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenClosePBNGas.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOpenClosePBNGas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenClosePBNGas.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnOpenClosePBNGas.FlatAppearance.BorderSize = 0
        Me.btnOpenClosePBNGas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenClosePBNGas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenClosePBNGas.ForeColor = System.Drawing.Color.Black
        Me.btnOpenClosePBNGas.Location = New System.Drawing.Point(157, 48)
        Me.btnOpenClosePBNGas.MessageBoxText = Nothing
        Me.btnOpenClosePBNGas.Name = "btnOpenClosePBNGas"
        Me.btnOpenClosePBNGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpenClosePBNGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOpenClosePBNGas.Size = New System.Drawing.Size(70, 30)
        Me.btnOpenClosePBNGas.TabIndex = 217
        Me.btnOpenClosePBNGas.Text = "On/Off"
        Me.btnOpenClosePBNGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnOpenClosePBNGas.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnOpenClosePBNGas.UseClickedEventInForm = True
        Me.btnOpenClosePBNGas.UseVisualStyleBackColor = False
        Me.btnOpenClosePBNGas.ValueToBeSend = "On"
        '
        'txtGas4
        '
        Me.txtGas4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas4.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas4.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas4.IsReadBack = True
        Me.txtGas4.Location = New System.Drawing.Point(97, 356)
        Me.txtGas4.MinimumValueHighlightedGreen = 0
        Me.txtGas4.Multiline = True
        Me.txtGas4.Name = "txtGas4"
        Me.txtGas4.ReadOnly = True
        Me.txtGas4.Size = New System.Drawing.Size(90, 26)
        Me.txtGas4.TabIndex = 213
        Me.txtGas4.TabStop = False
        Me.txtGas4.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas4.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas3
        '
        Me.txtGas3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas3.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas3.IsReadBack = True
        Me.txtGas3.Location = New System.Drawing.Point(97, 274)
        Me.txtGas3.MinimumValueHighlightedGreen = 0
        Me.txtGas3.Multiline = True
        Me.txtGas3.Name = "txtGas3"
        Me.txtGas3.ReadOnly = True
        Me.txtGas3.Size = New System.Drawing.Size(90, 26)
        Me.txtGas3.TabIndex = 213
        Me.txtGas3.TabStop = False
        Me.txtGas3.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas3.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas2
        '
        Me.txtGas2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas2.IsReadBack = True
        Me.txtGas2.Location = New System.Drawing.Point(97, 190)
        Me.txtGas2.MinimumValueHighlightedGreen = 0
        Me.txtGas2.Multiline = True
        Me.txtGas2.Name = "txtGas2"
        Me.txtGas2.ReadOnly = True
        Me.txtGas2.Size = New System.Drawing.Size(90, 26)
        Me.txtGas2.TabIndex = 213
        Me.txtGas2.TabStop = False
        Me.txtGas2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas2.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas1
        '
        Me.txtGas1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas1.IsReadBack = True
        Me.txtGas1.Location = New System.Drawing.Point(97, 111)
        Me.txtGas1.MinimumValueHighlightedGreen = 0
        Me.txtGas1.Multiline = True
        Me.txtGas1.Name = "txtGas1"
        Me.txtGas1.ReadOnly = True
        Me.txtGas1.Size = New System.Drawing.Size(90, 26)
        Me.txtGas1.TabIndex = 213
        Me.txtGas1.TabStop = False
        Me.txtGas1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas1.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas4Right
        '
        Me.txtGas4Right.BackColor = System.Drawing.Color.White
        Me.txtGas4Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas4Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas4Right.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas4Right.IsNumericTextbox = True
        Me.txtGas4Right.Location = New System.Drawing.Point(199, 356)
        Me.txtGas4Right.MinimumValueHighlightedGreen = 0
        Me.txtGas4Right.Multiline = True
        Me.txtGas4Right.Name = "txtGas4Right"
        Me.txtGas4Right.ReadOnly = True
        Me.txtGas4Right.Size = New System.Drawing.Size(90, 26)
        Me.txtGas4Right.TabIndex = 216
        Me.txtGas4Right.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas4Right.UseBackGroundWorkerToUpdateMinMax = True
        '
        'txtGas3Right
        '
        Me.txtGas3Right.BackColor = System.Drawing.Color.White
        Me.txtGas3Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas3Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas3Right.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas3Right.IsNumericTextbox = True
        Me.txtGas3Right.Location = New System.Drawing.Point(199, 274)
        Me.txtGas3Right.MinimumValueHighlightedGreen = 0
        Me.txtGas3Right.Multiline = True
        Me.txtGas3Right.Name = "txtGas3Right"
        Me.txtGas3Right.ReadOnly = True
        Me.txtGas3Right.Size = New System.Drawing.Size(90, 26)
        Me.txtGas3Right.TabIndex = 216
        Me.txtGas3Right.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas3Right.UseBackGroundWorkerToUpdateMinMax = True
        '
        'txtGas2Right
        '
        Me.txtGas2Right.BackColor = System.Drawing.Color.White
        Me.txtGas2Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas2Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas2Right.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas2Right.IsNumericTextbox = True
        Me.txtGas2Right.Location = New System.Drawing.Point(199, 190)
        Me.txtGas2Right.MinimumValueHighlightedGreen = 0
        Me.txtGas2Right.Multiline = True
        Me.txtGas2Right.Name = "txtGas2Right"
        Me.txtGas2Right.ReadOnly = True
        Me.txtGas2Right.Size = New System.Drawing.Size(90, 26)
        Me.txtGas2Right.TabIndex = 215
        Me.txtGas2Right.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas2Right.UseBackGroundWorkerToUpdateMinMax = True
        '
        'txtGas1Right
        '
        Me.txtGas1Right.BackColor = System.Drawing.Color.White
        Me.txtGas1Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas1Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas1Right.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas1Right.IsNumericTextbox = True
        Me.txtGas1Right.Location = New System.Drawing.Point(199, 111)
        Me.txtGas1Right.MinimumValueHighlightedGreen = 0
        Me.txtGas1Right.Multiline = True
        Me.txtGas1Right.Name = "txtGas1Right"
        Me.txtGas1Right.ReadOnly = True
        Me.txtGas1Right.Size = New System.Drawing.Size(90, 26)
        Me.txtGas1Right.TabIndex = 214
        Me.txtGas1Right.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas1Right.UseBackGroundWorkerToUpdateMinMax = True
        '
        'txtPBNGasRight
        '
        Me.txtPBNGasRight.BackColor = System.Drawing.Color.White
        Me.txtPBNGasRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPBNGasRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNGasRight.IsNumericTextbox = True
        Me.txtPBNGasRight.Location = New System.Drawing.Point(199, 19)
        Me.txtPBNGasRight.MinimumValueHighlightedGreen = 0
        Me.txtPBNGasRight.Multiline = True
        Me.txtPBNGasRight.Name = "txtPBNGasRight"
        Me.txtPBNGasRight.ReadOnly = True
        Me.txtPBNGasRight.Size = New System.Drawing.Size(90, 26)
        Me.txtPBNGasRight.TabIndex = 213
        Me.txtPBNGasRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtPBNGas
        '
        Me.txtPBNGas.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNGas.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNGas.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNGas.IsReadBack = True
        Me.txtPBNGas.Location = New System.Drawing.Point(97, 19)
        Me.txtPBNGas.MinimumValueHighlightedGreen = 0
        Me.txtPBNGas.Multiline = True
        Me.txtPBNGas.Name = "txtPBNGas"
        Me.txtPBNGas.ReadOnly = True
        Me.txtPBNGas.Size = New System.Drawing.Size(90, 26)
        Me.txtPBNGas.TabIndex = 213
        Me.txtPBNGas.TabStop = False
        Me.txtPBNGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNGas.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'lblGas4
        '
        Me.lblGas4.AutoSize = True
        Me.lblGas4.BackColor = System.Drawing.Color.Transparent
        Me.lblGas4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas4.Location = New System.Drawing.Point(293, 361)
        Me.lblGas4.Name = "lblGas4"
        Me.lblGas4.Size = New System.Drawing.Size(48, 16)
        Me.lblGas4.TabIndex = 50
        Me.lblGas4.Text = "Gas 4"
        '
        'lblGas3
        '
        Me.lblGas3.AutoSize = True
        Me.lblGas3.BackColor = System.Drawing.Color.Transparent
        Me.lblGas3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas3.Location = New System.Drawing.Point(293, 271)
        Me.lblGas3.Name = "lblGas3"
        Me.lblGas3.Size = New System.Drawing.Size(48, 16)
        Me.lblGas3.TabIndex = 50
        Me.lblGas3.Text = "Gas 3"
        '
        'lblGasPBN
        '
        Me.lblGasPBN.AutoSize = True
        Me.lblGasPBN.BackColor = System.Drawing.Color.Transparent
        Me.lblGasPBN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGasPBN.Location = New System.Drawing.Point(293, 24)
        Me.lblGasPBN.Name = "lblGasPBN"
        Me.lblGasPBN.Size = New System.Drawing.Size(39, 16)
        Me.lblGasPBN.TabIndex = 30
        Me.lblGasPBN.Text = "PBN"
        '
        'lblGas2
        '
        Me.lblGas2.AutoSize = True
        Me.lblGas2.BackColor = System.Drawing.Color.Transparent
        Me.lblGas2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas2.Location = New System.Drawing.Point(293, 195)
        Me.lblGas2.Name = "lblGas2"
        Me.lblGas2.Size = New System.Drawing.Size(48, 16)
        Me.lblGas2.TabIndex = 32
        Me.lblGas2.Text = "Gas 2"
        '
        'lblGas1
        '
        Me.lblGas1.AutoSize = True
        Me.lblGas1.BackColor = System.Drawing.Color.Transparent
        Me.lblGas1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas1.Location = New System.Drawing.Point(293, 116)
        Me.lblGas1.Name = "lblGas1"
        Me.lblGas1.Size = New System.Drawing.Size(48, 16)
        Me.lblGas1.TabIndex = 33
        Me.lblGas1.Text = "Gas 1"
        '
        'GasLine_Shutoff4
        '
        Me.GasLine_Shutoff4.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Shutoff4.BackColor = System.Drawing.Color.Transparent
        Me.GasLine_Shutoff4.Location = New System.Drawing.Point(21, 356)
        Me.GasLine_Shutoff4.Name = "GasLine_Shutoff4"
        Me.GasLine_Shutoff4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End
        Me.GasLine_Shutoff4.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End_On
        Me.GasLine_Shutoff4.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End_On_1
        Me.GasLine_Shutoff4.Size = New System.Drawing.Size(30, 49)
        Me.GasLine_Shutoff4.TabIndex = 235
        '
        'GasLine_PBNShutoff
        '
        Me.GasLine_PBNShutoff.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_PBNShutoff.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_PBNShutoff.Location = New System.Drawing.Point(0, 54)
        Me.GasLine_PBNShutoff.Name = "GasLine_PBNShutoff"
        Me.GasLine_PBNShutoff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_PBN_Left
        Me.GasLine_PBNShutoff.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_PBN_Left_On
        Me.GasLine_PBNShutoff.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_PBN_Left_On_1
        Me.GasLine_PBNShutoff.Size = New System.Drawing.Size(51, 15)
        Me.GasLine_PBNShutoff.TabIndex = 234
        '
        'GasLine_Shutoff1
        '
        Me.GasLine_Shutoff1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Shutoff1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_Shutoff1.Location = New System.Drawing.Point(33, 150)
        Me.GasLine_Shutoff1.Name = "GasLine_Shutoff1"
        Me.GasLine_Shutoff1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal
        Me.GasLine_Shutoff1.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_On
        Me.GasLine_Shutoff1.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_On_1
        Me.GasLine_Shutoff1.Size = New System.Drawing.Size(18, 15)
        Me.GasLine_Shutoff1.TabIndex = 235
        '
        'GasLine_PBNSupply
        '
        Me.GasLine_PBNSupply.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_PBNSupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_PBNSupply.Location = New System.Drawing.Point(90, 52)
        Me.GasLine_PBNSupply.Name = "GasLine_PBNSupply"
        Me.GasLine_PBNSupply.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_PBN_Right
        Me.GasLine_PBNSupply.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_PBN_Right_On
        Me.GasLine_PBNSupply.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_PBN_Right_On_1
        Me.GasLine_PBNSupply.Size = New System.Drawing.Size(208, 16)
        Me.GasLine_PBNSupply.TabIndex = 234
        '
        'GasLine_Supply1
        '
        Me.GasLine_Supply1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Supply1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_Supply1.Location = New System.Drawing.Point(90, 149)
        Me.GasLine_Supply1.Name = "GasLine_Supply1"
        Me.GasLine_Supply1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right
        Me.GasLine_Supply1.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right_On
        Me.GasLine_Supply1.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right_On_1
        Me.GasLine_Supply1.Size = New System.Drawing.Size(253, 16)
        Me.GasLine_Supply1.TabIndex = 236
        '
        'GasLine_Supply2
        '
        Me.GasLine_Supply2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Supply2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_Supply2.Location = New System.Drawing.Point(90, 229)
        Me.GasLine_Supply2.Name = "GasLine_Supply2"
        Me.GasLine_Supply2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right
        Me.GasLine_Supply2.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right_On
        Me.GasLine_Supply2.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right_On_1
        Me.GasLine_Supply2.Size = New System.Drawing.Size(253, 16)
        Me.GasLine_Supply2.TabIndex = 236
        '
        'GasLine_Supply4
        '
        Me.GasLine_Supply4.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Supply4.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_Supply4.Location = New System.Drawing.Point(90, 389)
        Me.GasLine_Supply4.Name = "GasLine_Supply4"
        Me.GasLine_Supply4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right
        Me.GasLine_Supply4.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right_On
        Me.GasLine_Supply4.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right_On_1
        Me.GasLine_Supply4.Size = New System.Drawing.Size(253, 16)
        Me.GasLine_Supply4.TabIndex = 236
        '
        'GasLine_Supply3
        '
        Me.GasLine_Supply3.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Supply3.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_Supply3.Location = New System.Drawing.Point(90, 309)
        Me.GasLine_Supply3.Name = "GasLine_Supply3"
        Me.GasLine_Supply3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right
        Me.GasLine_Supply3.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right_On
        Me.GasLine_Supply3.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasLine_Right_On_1
        Me.GasLine_Supply3.Size = New System.Drawing.Size(253, 16)
        Me.GasLine_Supply3.TabIndex = 236
        '
        'ValveShutoffPBNGas
        '
        Me.ValveShutoffPBNGas.AccessibleName = "Shutoff PBN Gas Valve"
        Me.ValveShutoffPBNGas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutoffPBNGas.IsCheckSafetyBeforeClick = False
        Me.ValveShutoffPBNGas.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutoffPBNGas.Location = New System.Drawing.Point(51, 44)
        Me.ValveShutoffPBNGas.Name = "ValveShutoffPBNGas"
        Me.ValveShutoffPBNGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutoffPBNGas.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffPBNGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutoffPBNGas.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffPBNGas.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutoffPBNGas.Size = New System.Drawing.Size(40, 33)
        Me.ValveShutoffPBNGas.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutoffPBNGas.TabIndex = 212
        Me.ValveShutoffPBNGas.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutoffPBNGas.TextLocIsFix = True
        Me.ValveShutoffPBNGas.TextValue = ""
        Me.ValveShutoffPBNGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutoffPBNGas.Unit = ""
        Me.ValveShutoffPBNGas.UnknownImage = Nothing
        Me.ValveShutoffPBNGas.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffPBNGas.UseClickedEventInForm = True
        Me.ValveShutoffPBNGas.UsingScientificFormat = True
        '
        'ValveShutoffGas1
        '
        Me.ValveShutoffGas1.AccessibleName = "Shutoff Gas1 Valve"
        Me.ValveShutoffGas1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutoffGas1.IsCheckSafetyBeforeClick = False
        Me.ValveShutoffGas1.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutoffGas1.Location = New System.Drawing.Point(51, 141)
        Me.ValveShutoffGas1.Name = "ValveShutoffGas1"
        Me.ValveShutoffGas1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutoffGas1.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutoffGas1.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas1.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutoffGas1.Size = New System.Drawing.Size(40, 33)
        Me.ValveShutoffGas1.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutoffGas1.TabIndex = 211
        Me.ValveShutoffGas1.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutoffGas1.TextLocIsFix = True
        Me.ValveShutoffGas1.TextValue = ""
        Me.ValveShutoffGas1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutoffGas1.Unit = ""
        Me.ValveShutoffGas1.UnknownImage = Nothing
        Me.ValveShutoffGas1.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas1.UseClickedEventInForm = True
        Me.ValveShutoffGas1.UsingScientificFormat = True
        '
        'ValveShutoffGas4
        '
        Me.ValveShutoffGas4.AccessibleName = "Shutoff Gas4 Valve"
        Me.ValveShutoffGas4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutoffGas4.IsCheckSafetyBeforeClick = False
        Me.ValveShutoffGas4.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutoffGas4.Location = New System.Drawing.Point(51, 380)
        Me.ValveShutoffGas4.Name = "ValveShutoffGas4"
        Me.ValveShutoffGas4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutoffGas4.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutoffGas4.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas4.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutoffGas4.Size = New System.Drawing.Size(40, 33)
        Me.ValveShutoffGas4.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutoffGas4.TabIndex = 209
        Me.ValveShutoffGas4.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutoffGas4.TextLocIsFix = True
        Me.ValveShutoffGas4.TextValue = ""
        Me.ValveShutoffGas4.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutoffGas4.Unit = ""
        Me.ValveShutoffGas4.UnknownImage = Nothing
        Me.ValveShutoffGas4.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas4.UseClickedEventInForm = True
        Me.ValveShutoffGas4.UsingScientificFormat = True
        '
        'ValveShutoffGas2
        '
        Me.ValveShutoffGas2.AccessibleName = "Shutoff Gas2 Valve"
        Me.ValveShutoffGas2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutoffGas2.IsCheckSafetyBeforeClick = False
        Me.ValveShutoffGas2.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutoffGas2.Location = New System.Drawing.Point(51, 221)
        Me.ValveShutoffGas2.Name = "ValveShutoffGas2"
        Me.ValveShutoffGas2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutoffGas2.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutoffGas2.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas2.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutoffGas2.Size = New System.Drawing.Size(40, 33)
        Me.ValveShutoffGas2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutoffGas2.TabIndex = 210
        Me.ValveShutoffGas2.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutoffGas2.TextLocIsFix = True
        Me.ValveShutoffGas2.TextValue = ""
        Me.ValveShutoffGas2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutoffGas2.Unit = ""
        Me.ValveShutoffGas2.UnknownImage = Nothing
        Me.ValveShutoffGas2.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas2.UseClickedEventInForm = True
        Me.ValveShutoffGas2.UsingScientificFormat = True
        '
        'ValveShutoffGas3
        '
        Me.ValveShutoffGas3.AccessibleName = "Shutoff Gas3 Valve"
        Me.ValveShutoffGas3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveShutoffGas3.IsCheckSafetyBeforeClick = False
        Me.ValveShutoffGas3.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveShutoffGas3.Location = New System.Drawing.Point(51, 301)
        Me.ValveShutoffGas3.Name = "ValveShutoffGas3"
        Me.ValveShutoffGas3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveShutoffGas3.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveShutoffGas3.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas3.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveShutoffGas3.Size = New System.Drawing.Size(40, 33)
        Me.ValveShutoffGas3.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveShutoffGas3.TabIndex = 209
        Me.ValveShutoffGas3.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveShutoffGas3.TextLocIsFix = True
        Me.ValveShutoffGas3.TextValue = ""
        Me.ValveShutoffGas3.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveShutoffGas3.Unit = ""
        Me.ValveShutoffGas3.UnknownImage = Nothing
        Me.ValveShutoffGas3.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveShutoffGas3.UseClickedEventInForm = True
        Me.ValveShutoffGas3.UsingScientificFormat = True
        '
        'ValveSupplyPBNGas
        '
        Me.ValveSupplyPBNGas.AccessibleName = "Supply PBN Gas Valve"
        Me.ValveSupplyPBNGas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveSupplyPBNGas.IsCheckSafetyBeforeClick = False
        Me.ValveSupplyPBNGas.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveSupplyPBNGas.Location = New System.Drawing.Point(366, 59)
        Me.ValveSupplyPBNGas.Name = "ValveSupplyPBNGas"
        Me.ValveSupplyPBNGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveSupplyPBNGas.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyPBNGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveSupplyPBNGas.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyPBNGas.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveSupplyPBNGas.Size = New System.Drawing.Size(40, 33)
        Me.ValveSupplyPBNGas.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveSupplyPBNGas.TabIndex = 185
        Me.ValveSupplyPBNGas.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveSupplyPBNGas.TextLocIsFix = True
        Me.ValveSupplyPBNGas.TextValue = ""
        Me.ValveSupplyPBNGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveSupplyPBNGas.Unit = ""
        Me.ValveSupplyPBNGas.UnknownImage = Nothing
        Me.ValveSupplyPBNGas.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveSupplyPBNGas.UseClickedEventInForm = True
        Me.ValveSupplyPBNGas.UsingScientificFormat = True
        Me.ValveSupplyPBNGas.Visible = False
        '
        'GasLine_Total1
        '
        Me.GasLine_Total1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Total1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GasLine_Total1.Location = New System.Drawing.Point(0, 81)
        Me.GasLine_Total1.Name = "GasLine_Total1"
        Me.GasLine_Total1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Total_First_Part
        Me.GasLine_Total1.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Total_First_Part_On
        Me.GasLine_Total1.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas_Total_First_Part_On_1
        Me.GasLine_Total1.Size = New System.Drawing.Size(36, 35)
        Me.GasLine_Total1.TabIndex = 235
        '
        'tabPartID
        '
        Me.tabPartID.BackColor = System.Drawing.Color.Transparent
        Me.tabPartID.Controls.Add(Me.Label39)
        Me.tabPartID.Controls.Add(Me.Label38)
        Me.tabPartID.Controls.Add(Me.Label37)
        Me.tabPartID.Controls.Add(Me.Label36)
        Me.tabPartID.Controls.Add(Me.Label35)
        Me.tabPartID.Controls.Add(Me.Label34)
        Me.tabPartID.Controls.Add(Me.Label33)
        Me.tabPartID.Controls.Add(Me.Label27)
        Me.tabPartID.Controls.Add(Me.Label26)
        Me.tabPartID.Controls.Add(Me.txtWaterJournalSP)
        Me.tabPartID.Controls.Add(Me.txtFixtureRotationMotorUsageSP)
        Me.tabPartID.Controls.Add(Me.txtCryoUsageSP)
        Me.tabPartID.Controls.Add(Me.txtLinerSP)
        Me.tabPartID.Controls.Add(Me.txtShutterUsageSP)
        Me.tabPartID.Controls.Add(Me.txtTopFixtureShieldUsageSP)
        Me.tabPartID.Controls.Add(Me.txtWaferClampUsageSP)
        Me.tabPartID.Controls.Add(Me.txtCoverFixtureShieldUsageSP)
        Me.tabPartID.Controls.Add(Me.txtShieldQuartSP)
        Me.tabPartID.Controls.Add(Me.txtPBNMinutes)
        Me.tabPartID.Controls.Add(Me.Label32)
        Me.tabPartID.Controls.Add(Me.txtSourceMinutesMaint)
        Me.tabPartID.Controls.Add(Me.Label31)
        Me.tabPartID.Controls.Add(Me.cmbRebuildLevel)
        Me.tabPartID.Controls.Add(Me.Label30)
        Me.tabPartID.Controls.Add(Me.Label29)
        Me.tabPartID.Controls.Add(Me.txtGridID)
        Me.tabPartID.Controls.Add(Me.Label28)
        Me.tabPartID.Controls.Add(Me.txtGridSerialNumber)
        Me.tabPartID.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPartID.Location = New System.Drawing.Point(0, 31)
        Me.tabPartID.Name = "tabPartID"
        Me.tabPartID.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPartID.Size = New System.Drawing.Size(412, 447)
        Me.tabPartID.TabIndex = 3
        Me.tabPartID.Text = "Maint."
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label39.Location = New System.Drawing.Point(6, 345)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(146, 19)
        Me.Label39.TabIndex = 272
        Me.Label39.Text = "Water Journal (Min)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(6, 319)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(208, 19)
        Me.Label38.TabIndex = 271
        Me.Label38.Text = "Fixture Rotation Motor (Min)"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(6, 293)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(130, 19)
        Me.Label37.TabIndex = 270
        Me.Label37.Text = "Cryo Usage (Min)"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label36.Location = New System.Drawing.Point(6, 267)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(137, 19)
        Me.Label36.TabIndex = 269
        Me.Label36.Text = "Liner Source (Min)"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label35.Location = New System.Drawing.Point(6, 241)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(267, 19)
        Me.Label35.TabIndex = 268
        Me.Label35.Text = "Source Usage After Un-schedule (Min)"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label34.Location = New System.Drawing.Point(6, 215)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(131, 19)
        Me.Label34.TabIndex = 267
        Me.Label34.Text = "Grid Source (Min)"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label33.Location = New System.Drawing.Point(6, 189)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(139, 19)
        Me.Label33.TabIndex = 266
        Me.Label33.Text = "Wafer Clamp (Min)"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label27.Location = New System.Drawing.Point(6, 163)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(144, 19)
        Me.Label27.TabIndex = 265
        Me.Label27.Text = "Fixture Cover (Min)"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label26.Location = New System.Drawing.Point(6, 137)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(145, 19)
        Me.Label26.TabIndex = 264
        Me.Label26.Text = "Shields Usage (Min)"
        '
        'txtWaterJournalSP
        '
        Me.txtWaterJournalSP.AccessibleDescription = ""
        Me.txtWaterJournalSP.AccessibleName = "Water Journal"
        Me.txtWaterJournalSP.AutoSendKeyTabWhenFinishInput = True
        Me.txtWaterJournalSP.BackColor = System.Drawing.Color.White
        Me.txtWaterJournalSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWaterJournalSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtWaterJournalSP.IsNumericTextbox = True
        Me.txtWaterJournalSP.Location = New System.Drawing.Point(287, 342)
        Me.txtWaterJournalSP.MinimumValueHighlightedGreen = 0
        Me.txtWaterJournalSP.Multiline = True
        Me.txtWaterJournalSP.Name = "txtWaterJournalSP"
        Me.txtWaterJournalSP.ReadOnly = True
        Me.txtWaterJournalSP.Size = New System.Drawing.Size(119, 24)
        Me.txtWaterJournalSP.TabIndex = 261
        Me.txtWaterJournalSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtWaterJournalSP.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtWaterJournalSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtFixtureRotationMotorUsageSP
        '
        Me.txtFixtureRotationMotorUsageSP.AccessibleDescription = ""
        Me.txtFixtureRotationMotorUsageSP.AccessibleName = "Fixture Rotation"
        Me.txtFixtureRotationMotorUsageSP.AutoSendKeyTabWhenFinishInput = True
        Me.txtFixtureRotationMotorUsageSP.BackColor = System.Drawing.Color.White
        Me.txtFixtureRotationMotorUsageSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtFixtureRotationMotorUsageSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtFixtureRotationMotorUsageSP.IsNumericTextbox = True
        Me.txtFixtureRotationMotorUsageSP.Location = New System.Drawing.Point(287, 316)
        Me.txtFixtureRotationMotorUsageSP.MinimumValueHighlightedGreen = 0
        Me.txtFixtureRotationMotorUsageSP.Multiline = True
        Me.txtFixtureRotationMotorUsageSP.Name = "txtFixtureRotationMotorUsageSP"
        Me.txtFixtureRotationMotorUsageSP.ReadOnly = True
        Me.txtFixtureRotationMotorUsageSP.Size = New System.Drawing.Size(119, 24)
        Me.txtFixtureRotationMotorUsageSP.TabIndex = 260
        Me.txtFixtureRotationMotorUsageSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtFixtureRotationMotorUsageSP.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtFixtureRotationMotorUsageSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtCryoUsageSP
        '
        Me.txtCryoUsageSP.AccessibleDescription = ""
        Me.txtCryoUsageSP.AccessibleName = "Cryo Usage"
        Me.txtCryoUsageSP.AutoSendKeyTabWhenFinishInput = True
        Me.txtCryoUsageSP.BackColor = System.Drawing.Color.White
        Me.txtCryoUsageSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCryoUsageSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCryoUsageSP.IsNumericTextbox = True
        Me.txtCryoUsageSP.Location = New System.Drawing.Point(287, 290)
        Me.txtCryoUsageSP.MinimumValueHighlightedGreen = 0
        Me.txtCryoUsageSP.Multiline = True
        Me.txtCryoUsageSP.Name = "txtCryoUsageSP"
        Me.txtCryoUsageSP.ReadOnly = True
        Me.txtCryoUsageSP.Size = New System.Drawing.Size(119, 24)
        Me.txtCryoUsageSP.TabIndex = 259
        Me.txtCryoUsageSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCryoUsageSP.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtCryoUsageSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtLinerSP
        '
        Me.txtLinerSP.AccessibleDescription = ""
        Me.txtLinerSP.AccessibleName = "Liner Source"
        Me.txtLinerSP.AutoSendKeyTabWhenFinishInput = True
        Me.txtLinerSP.BackColor = System.Drawing.Color.White
        Me.txtLinerSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLinerSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtLinerSP.IsNumericTextbox = True
        Me.txtLinerSP.Location = New System.Drawing.Point(287, 264)
        Me.txtLinerSP.MinimumValueHighlightedGreen = 0
        Me.txtLinerSP.Multiline = True
        Me.txtLinerSP.Name = "txtLinerSP"
        Me.txtLinerSP.ReadOnly = True
        Me.txtLinerSP.Size = New System.Drawing.Size(119, 24)
        Me.txtLinerSP.TabIndex = 258
        Me.txtLinerSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtLinerSP.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtLinerSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtShutterUsageSP
        '
        Me.txtShutterUsageSP.AccessibleDescription = ""
        Me.txtShutterUsageSP.AccessibleName = "Source Usage After"
        Me.txtShutterUsageSP.AutoSendKeyTabWhenFinishInput = True
        Me.txtShutterUsageSP.BackColor = System.Drawing.Color.White
        Me.txtShutterUsageSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtShutterUsageSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtShutterUsageSP.IsNumericTextbox = True
        Me.txtShutterUsageSP.Location = New System.Drawing.Point(287, 238)
        Me.txtShutterUsageSP.MinimumValueHighlightedGreen = 0
        Me.txtShutterUsageSP.Multiline = True
        Me.txtShutterUsageSP.Name = "txtShutterUsageSP"
        Me.txtShutterUsageSP.ReadOnly = True
        Me.txtShutterUsageSP.Size = New System.Drawing.Size(119, 24)
        Me.txtShutterUsageSP.TabIndex = 257
        Me.txtShutterUsageSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtShutterUsageSP.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtShutterUsageSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtTopFixtureShieldUsageSP
        '
        Me.txtTopFixtureShieldUsageSP.AccessibleDescription = ""
        Me.txtTopFixtureShieldUsageSP.AccessibleName = "Grid Source"
        Me.txtTopFixtureShieldUsageSP.AutoSendKeyTabWhenFinishInput = True
        Me.txtTopFixtureShieldUsageSP.BackColor = System.Drawing.Color.White
        Me.txtTopFixtureShieldUsageSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTopFixtureShieldUsageSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTopFixtureShieldUsageSP.IsNumericTextbox = True
        Me.txtTopFixtureShieldUsageSP.Location = New System.Drawing.Point(287, 212)
        Me.txtTopFixtureShieldUsageSP.MinimumValueHighlightedGreen = 0
        Me.txtTopFixtureShieldUsageSP.Multiline = True
        Me.txtTopFixtureShieldUsageSP.Name = "txtTopFixtureShieldUsageSP"
        Me.txtTopFixtureShieldUsageSP.ReadOnly = True
        Me.txtTopFixtureShieldUsageSP.Size = New System.Drawing.Size(119, 24)
        Me.txtTopFixtureShieldUsageSP.TabIndex = 256
        Me.txtTopFixtureShieldUsageSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTopFixtureShieldUsageSP.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtTopFixtureShieldUsageSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtWaferClampUsageSP
        '
        Me.txtWaferClampUsageSP.AccessibleDescription = ""
        Me.txtWaferClampUsageSP.AccessibleName = "Wafer Clamp"
        Me.txtWaferClampUsageSP.AutoSendKeyTabWhenFinishInput = True
        Me.txtWaferClampUsageSP.BackColor = System.Drawing.Color.White
        Me.txtWaferClampUsageSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWaferClampUsageSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtWaferClampUsageSP.IsNumericTextbox = True
        Me.txtWaferClampUsageSP.Location = New System.Drawing.Point(287, 186)
        Me.txtWaferClampUsageSP.MinimumValueHighlightedGreen = 0
        Me.txtWaferClampUsageSP.Multiline = True
        Me.txtWaferClampUsageSP.Name = "txtWaferClampUsageSP"
        Me.txtWaferClampUsageSP.ReadOnly = True
        Me.txtWaferClampUsageSP.Size = New System.Drawing.Size(119, 24)
        Me.txtWaferClampUsageSP.TabIndex = 255
        Me.txtWaferClampUsageSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtWaferClampUsageSP.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtWaferClampUsageSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtCoverFixtureShieldUsageSP
        '
        Me.txtCoverFixtureShieldUsageSP.AccessibleDescription = ""
        Me.txtCoverFixtureShieldUsageSP.AccessibleName = "Fixture Cover"
        Me.txtCoverFixtureShieldUsageSP.AutoSendKeyTabWhenFinishInput = True
        Me.txtCoverFixtureShieldUsageSP.BackColor = System.Drawing.Color.White
        Me.txtCoverFixtureShieldUsageSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCoverFixtureShieldUsageSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCoverFixtureShieldUsageSP.IsNumericTextbox = True
        Me.txtCoverFixtureShieldUsageSP.Location = New System.Drawing.Point(287, 160)
        Me.txtCoverFixtureShieldUsageSP.MinimumValueHighlightedGreen = 0
        Me.txtCoverFixtureShieldUsageSP.Multiline = True
        Me.txtCoverFixtureShieldUsageSP.Name = "txtCoverFixtureShieldUsageSP"
        Me.txtCoverFixtureShieldUsageSP.ReadOnly = True
        Me.txtCoverFixtureShieldUsageSP.Size = New System.Drawing.Size(119, 24)
        Me.txtCoverFixtureShieldUsageSP.TabIndex = 254
        Me.txtCoverFixtureShieldUsageSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCoverFixtureShieldUsageSP.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtCoverFixtureShieldUsageSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtShieldQuartSP
        '
        Me.txtShieldQuartSP.AccessibleDescription = ""
        Me.txtShieldQuartSP.AccessibleName = "Shield Quart"
        Me.txtShieldQuartSP.AutoSendKeyTabWhenFinishInput = True
        Me.txtShieldQuartSP.BackColor = System.Drawing.Color.White
        Me.txtShieldQuartSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtShieldQuartSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtShieldQuartSP.IsNumericTextbox = True
        Me.txtShieldQuartSP.Location = New System.Drawing.Point(287, 134)
        Me.txtShieldQuartSP.MinimumValueHighlightedGreen = 0
        Me.txtShieldQuartSP.Multiline = True
        Me.txtShieldQuartSP.Name = "txtShieldQuartSP"
        Me.txtShieldQuartSP.ReadOnly = True
        Me.txtShieldQuartSP.Size = New System.Drawing.Size(119, 24)
        Me.txtShieldQuartSP.TabIndex = 253
        Me.txtShieldQuartSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtShieldQuartSP.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtShieldQuartSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtPBNMinutes
        '
        Me.txtPBNMinutes.AccessibleDescription = ""
        Me.txtPBNMinutes.AccessibleName = "PBN Minutes"
        Me.txtPBNMinutes.AutoSendKeyTabWhenFinishInput = True
        Me.txtPBNMinutes.BackColor = System.Drawing.Color.White
        Me.txtPBNMinutes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPBNMinutes.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNMinutes.IsNumericTextbox = True
        Me.txtPBNMinutes.Location = New System.Drawing.Point(287, 108)
        Me.txtPBNMinutes.MinimumValueHighlightedGreen = 0
        Me.txtPBNMinutes.Multiline = True
        Me.txtPBNMinutes.Name = "txtPBNMinutes"
        Me.txtPBNMinutes.ReadOnly = True
        Me.txtPBNMinutes.Size = New System.Drawing.Size(119, 24)
        Me.txtPBNMinutes.TabIndex = 242
        Me.txtPBNMinutes.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNMinutes.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtPBNMinutes.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label32.Location = New System.Drawing.Point(6, 111)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(129, 19)
        Me.Label32.TabIndex = 243
        Me.Label32.Text = "PBN Usage (Min)"
        '
        'txtSourceMinutesMaint
        '
        Me.txtSourceMinutesMaint.AccessibleDescription = ""
        Me.txtSourceMinutesMaint.AccessibleName = "Source Minutes"
        Me.txtSourceMinutesMaint.AutoSendKeyTabWhenFinishInput = True
        Me.txtSourceMinutesMaint.BackColor = System.Drawing.Color.White
        Me.txtSourceMinutesMaint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSourceMinutesMaint.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSourceMinutesMaint.IsNumericTextbox = True
        Me.txtSourceMinutesMaint.Location = New System.Drawing.Point(287, 82)
        Me.txtSourceMinutesMaint.MinimumValueHighlightedGreen = 0
        Me.txtSourceMinutesMaint.Multiline = True
        Me.txtSourceMinutesMaint.Name = "txtSourceMinutesMaint"
        Me.txtSourceMinutesMaint.ReadOnly = True
        Me.txtSourceMinutesMaint.Size = New System.Drawing.Size(119, 24)
        Me.txtSourceMinutesMaint.TabIndex = 243
        Me.txtSourceMinutesMaint.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSourceMinutesMaint.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtSourceMinutesMaint.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label31.Location = New System.Drawing.Point(6, 85)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(143, 19)
        Me.Label31.TabIndex = 241
        Me.Label31.Text = "Source Usage (Min)"
        '
        'cmbRebuildLevel
        '
        Me.cmbRebuildLevel.AccessibleName = "RebuildLevel"
        Me.cmbRebuildLevel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbRebuildLevel.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.cmbRebuildLevel.FormattingEnabled = True
        Me.cmbRebuildLevel.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.cmbRebuildLevel.Location = New System.Drawing.Point(287, 55)
        Me.cmbRebuildLevel.Name = "cmbRebuildLevel"
        Me.cmbRebuildLevel.Size = New System.Drawing.Size(119, 26)
        Me.cmbRebuildLevel.TabIndex = 241
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.Location = New System.Drawing.Point(6, 59)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(103, 19)
        Me.Label30.TabIndex = 2
        Me.Label30.Text = "Rebuild Level"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label29.Location = New System.Drawing.Point(6, 33)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(61, 19)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "Grid ID"
        '
        'txtGridID
        '
        Me.txtGridID.AccessibleDescription = "TextboxClick"
        Me.txtGridID.AccessibleName = "Grid ID"
        Me.txtGridID.BackColor = System.Drawing.Color.White
        Me.txtGridID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGridID.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGridID.Location = New System.Drawing.Point(153, 29)
        Me.txtGridID.MinimumValueHighlightedGreen = 0
        Me.txtGridID.Name = "txtGridID"
        Me.txtGridID.ReadOnly = True
        Me.txtGridID.Size = New System.Drawing.Size(253, 24)
        Me.txtGridID.TabIndex = 240
        Me.txtGridID.TabStop = False
        Me.txtGridID.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGridID.UseScientificFormat = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label28.Location = New System.Drawing.Point(6, 7)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(68, 19)
        Me.Label28.TabIndex = 2
        Me.Label28.Text = "Grid S/N"
        '
        'txtGridSerialNumber
        '
        Me.txtGridSerialNumber.AccessibleDescription = "TextboxClick"
        Me.txtGridSerialNumber.AccessibleName = "Grid Serial Number"
        Me.txtGridSerialNumber.BackColor = System.Drawing.Color.White
        Me.txtGridSerialNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGridSerialNumber.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGridSerialNumber.Location = New System.Drawing.Point(153, 4)
        Me.txtGridSerialNumber.MinimumValueHighlightedGreen = 0
        Me.txtGridSerialNumber.Name = "txtGridSerialNumber"
        Me.txtGridSerialNumber.ReadOnly = True
        Me.txtGridSerialNumber.Size = New System.Drawing.Size(253, 24)
        Me.txtGridSerialNumber.TabIndex = 239
        Me.txtGridSerialNumber.TabStop = False
        Me.txtGridSerialNumber.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGridSerialNumber.UseScientificFormat = True
        '
        'cmstooltipFixture
        '
        Me.cmstooltipFixture.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmstooltipFixture.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStartRotation, Me.mnuHomeRotation, Me.mnuCoolingWater, Me.mnuUnProtected})
        Me.cmstooltipFixture.Name = "cmsMechineTool"
        Me.cmstooltipFixture.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmstooltipFixture.ShowImageMargin = False
        Me.cmstooltipFixture.Size = New System.Drawing.Size(259, 140)
        '
        'mnuStartRotation
        '
        Me.mnuStartRotation.Name = "mnuStartRotation"
        Me.mnuStartRotation.Size = New System.Drawing.Size(258, 34)
        Me.mnuStartRotation.Text = "Start Rotation Axis"
        '
        'mnuHomeRotation
        '
        Me.mnuHomeRotation.Name = "mnuHomeRotation"
        Me.mnuHomeRotation.Size = New System.Drawing.Size(258, 34)
        Me.mnuHomeRotation.Text = "Home Rotation"
        '
        'mnuCoolingWater
        '
        Me.mnuCoolingWater.Name = "mnuCoolingWater"
        Me.mnuCoolingWater.Size = New System.Drawing.Size(258, 34)
        Me.mnuCoolingWater.Text = "Cooling Water On"
        '
        'mnuUnProtected
        '
        Me.mnuUnProtected.Name = "mnuUnProtected"
        Me.mnuUnProtected.Size = New System.Drawing.Size(258, 34)
        Me.mnuUnProtected.Text = "Unprotected On"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(756, 427)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(110, 21)
        Me.Label23.TabIndex = 222
        Me.Label23.Text = "Fixture Water"
        '
        'txtRoughlineCG
        '
        Me.txtRoughlineCG.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRoughlineCG.Clickable = False
        Me.txtRoughlineCG.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRoughlineCG.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRoughlineCG.IsReadBack = True
        Me.txtRoughlineCG.Location = New System.Drawing.Point(356, 680)
        Me.txtRoughlineCG.MinimumValueHighlightedGreen = 0
        Me.txtRoughlineCG.Name = "txtRoughlineCG"
        Me.txtRoughlineCG.ReadOnly = True
        Me.txtRoughlineCG.Size = New System.Drawing.Size(76, 24)
        Me.txtRoughlineCG.TabIndex = 239
        Me.txtRoughlineCG.TabStop = False
        Me.txtRoughlineCG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRoughlineCG.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRoughlineCG.UseClickEventInForm = True
        Me.txtRoughlineCG.UseScientificFormat = True
        Me.txtRoughlineCG.Visible = False
        '
        'txtForelineCG
        '
        Me.txtForelineCG.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtForelineCG.Clickable = False
        Me.txtForelineCG.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtForelineCG.DisplayPressureFont = True
        Me.txtForelineCG.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtForelineCG.ForeColor = System.Drawing.Color.Lime
        Me.txtForelineCG.IsReadBack = True
        Me.txtForelineCG.Location = New System.Drawing.Point(367, 86)
        Me.txtForelineCG.MinimumValueHighlightedGreen = 0
        Me.txtForelineCG.Name = "txtForelineCG"
        Me.txtForelineCG.ReadOnly = True
        Me.txtForelineCG.Size = New System.Drawing.Size(76, 24)
        Me.txtForelineCG.TabIndex = 239
        Me.txtForelineCG.TabStop = False
        Me.txtForelineCG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtForelineCG.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtForelineCG.UseClickEventInForm = True
        Me.txtForelineCG.UseScientificFormat = True
        '
        'txtMG
        '
        Me.txtMG.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMG.Clickable = False
        Me.txtMG.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMG.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMG.IsReadBack = True
        Me.txtMG.Location = New System.Drawing.Point(707, 567)
        Me.txtMG.MinimumValueHighlightedGreen = 0
        Me.txtMG.Name = "txtMG"
        Me.txtMG.ReadOnly = True
        Me.txtMG.Size = New System.Drawing.Size(76, 24)
        Me.txtMG.TabIndex = 239
        Me.txtMG.TabStop = False
        Me.txtMG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMG.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMG.UseScientificFormat = True
        '
        'btnUnProtected
        '
        Me.btnUnProtected.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUnProtected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUnProtected.Clickable = True
        Me.btnUnProtected.ColorText_OffStatus = System.Drawing.SystemColors.ControlText
        Me.btnUnProtected.ColorText_UnknowStatus = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnUnProtected.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUnProtected.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnUnProtected.FlatAppearance.BorderSize = 0
        Me.btnUnProtected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnProtected.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnProtected.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUnProtected.Location = New System.Drawing.Point(1155, 3)
        Me.btnUnProtected.MessageBoxText = Nothing
        Me.btnUnProtected.Name = "btnUnProtected"
        Me.btnUnProtected.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUnProtected.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnUnProtected.Size = New System.Drawing.Size(125, 31)
        Me.btnUnProtected.TabIndex = 240
        Me.btnUnProtected.Text = "Unprotected"
        Me.btnUnProtected.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnUnProtected.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUnProtected.UseClickedEventInForm = True
        Me.btnUnProtected.UseVisualStyleBackColor = True
        Me.btnUnProtected.ValueToBeSend = ""
        '
        'SLPM
        '
        Me.SLPM.BackColor = System.Drawing.Color.Transparent
        Me.SLPM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SLPM.DisplayPressure = True
        Me.SLPM.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLPM.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.SLPM.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.SLPM.HeaderText = "Pressure"
        Me.SLPM.HeaderTextColor = System.Drawing.Color.Black
        Me.SLPM.HeaderVisible = True
        Me.SLPM.Location = New System.Drawing.Point(572, 49)
        Me.SLPM.Name = "SLPM"
        Me.SLPM.Size = New System.Drawing.Size(115, 60)
        Me.SLPM.TabIndex = 239
        Me.SLPM.Text = "Pressure"
        Me.SLPM.UseBorderStyle = True
        '
        'btnTooltipFixture
        '
        Me.btnTooltipFixture.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnTooltipFixture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTooltipFixture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTooltipFixture.FlatAppearance.BorderSize = 0
        Me.btnTooltipFixture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTooltipFixture.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTooltipFixture.Location = New System.Drawing.Point(799, 515)
        Me.btnTooltipFixture.Name = "btnTooltipFixture"
        Me.btnTooltipFixture.Size = New System.Drawing.Size(30, 28)
        Me.btnTooltipFixture.TabIndex = 232
        Me.btnTooltipFixture.UseVisualStyleBackColor = True
        Me.btnTooltipFixture.Visible = False
        '
        'SLPowerPanel
        '
        Me.SLPowerPanel.BackColor = System.Drawing.Color.Transparent
        Me.SLPowerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SLPowerPanel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLPowerPanel.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.SLPowerPanel.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.SLPowerPanel.HeaderText = "Power Panel"
        Me.SLPowerPanel.HeaderTextColor = System.Drawing.Color.Black
        Me.SLPowerPanel.HeaderVisible = True
        Me.SLPowerPanel.IsOnline = False
        Me.SLPowerPanel.Location = New System.Drawing.Point(4, 53)
        Me.SLPowerPanel.Name = "SLPowerPanel"
        Me.SLPowerPanel.Size = New System.Drawing.Size(324, 116)
        Me.SLPowerPanel.TabIndex = 234
        Me.SLPowerPanel.Text = "Power Panel"
        Me.SLPowerPanel.UseBorderStyle = True
        '
        'SLIGCGControl
        '
        Me.SLIGCGControl.BackColor = System.Drawing.Color.Transparent
        Me.SLIGCGControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SLIGCGControl.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLIGCGControl.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.SLIGCGControl.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.SLIGCGControl.HeaderText = "IG / CG"
        Me.SLIGCGControl.HeaderTextColor = System.Drawing.Color.Black
        Me.SLIGCGControl.HeaderVisible = True
        Me.SLIGCGControl.Location = New System.Drawing.Point(356, 779)
        Me.SLIGCGControl.Name = "SLIGCGControl"
        Me.SLIGCGControl.Size = New System.Drawing.Size(61, 58)
        Me.SLIGCGControl.TabIndex = 235
        Me.SLIGCGControl.Text = "IG / CG"
        Me.SLIGCGControl.UseBorderStyle = True
        Me.SLIGCGControl.Visible = False
        '
        'SLRLCG
        '
        Me.SLRLCG.BackColor = System.Drawing.Color.Transparent
        Me.SLRLCG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SLRLCG.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLRLCG.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.SLRLCG.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.SLRLCG.HeaderText = "R.L. CG"
        Me.SLRLCG.HeaderTextColor = System.Drawing.Color.Black
        Me.SLRLCG.HeaderVisible = True
        Me.SLRLCG.Location = New System.Drawing.Point(510, 780)
        Me.SLRLCG.Name = "SLRLCG"
        Me.SLRLCG.Size = New System.Drawing.Size(83, 57)
        Me.SLRLCG.TabIndex = 229
        Me.SLRLCG.Text = "R.L. CG"
        Me.SLRLCG.UseBorderStyle = True
        Me.SLRLCG.Visible = False
        '
        'SLFLCG
        '
        Me.SLFLCG.BackColor = System.Drawing.Color.Transparent
        Me.SLFLCG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SLFLCG.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLFLCG.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.SLFLCG.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.SLFLCG.HeaderText = "F.L. CG"
        Me.SLFLCG.HeaderTextColor = System.Drawing.Color.Black
        Me.SLFLCG.HeaderVisible = True
        Me.SLFLCG.Location = New System.Drawing.Point(421, 780)
        Me.SLFLCG.Name = "SLFLCG"
        Me.SLFLCG.Size = New System.Drawing.Size(83, 57)
        Me.SLFLCG.TabIndex = 229
        Me.SLFLCG.Text = "F.L. CG"
        Me.SLFLCG.UseBorderStyle = True
        Me.SLFLCG.Visible = False
        '
        'PBNGasLine
        '
        Me.PBNGasLine.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.PBNGasLine.BackColor = System.Drawing.Color.Transparent
        Me.PBNGasLine.Location = New System.Drawing.Point(705, 121)
        Me.PBNGasLine.Name = "PBNGasLine"
        Me.PBNGasLine.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas6
        Me.PBNGasLine.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas6_On
        Me.PBNGasLine.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas6_On_1
        Me.PBNGasLine.Size = New System.Drawing.Size(164, 133)
        Me.PBNGasLine.TabIndex = 299
        '
        'GasLine_Total
        '
        Me.GasLine_Total.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Total.BackColor = System.Drawing.Color.Transparent
        Me.GasLine_Total.Location = New System.Drawing.Point(703, 148)
        Me.GasLine_Total.Name = "GasLine_Total"
        Me.GasLine_Total.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas10
        Me.GasLine_Total.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas10_On
        Me.GasLine_Total.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas10_On_1
        Me.GasLine_Total.Size = New System.Drawing.Size(166, 129)
        Me.GasLine_Total.TabIndex = 300
        '
        'ValveForeline
        '
        Me.ValveForeline.AccessibleName = "Foreline Valve"
        Me.ValveForeline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveForeline.IsCheckSafetyBeforeClick = False
        Me.ValveForeline.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveForeline.Location = New System.Drawing.Point(381, 148)
        Me.ValveForeline.Name = "ValveForeline"
        Me.ValveForeline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveForeline.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveForeline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveForeline.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveForeline.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveForeline.Size = New System.Drawing.Size(40, 33)
        Me.ValveForeline.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveForeline.TabIndex = 226
        Me.ValveForeline.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveForeline.TextLocIsFix = True
        Me.ValveForeline.TextValue = ""
        Me.ValveForeline.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveForeline.Unit = ""
        Me.ValveForeline.UnknownImage = Nothing
        Me.ValveForeline.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveForeline.UseClickedEventInForm = True
        Me.ValveForeline.UsingScientificFormat = True
        '
        'ValveVent
        '
        Me.ValveVent.AccessibleName = "Vent Valve"
        Me.ValveVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveVent.IsCheckSafetyBeforeClick = False
        Me.ValveVent.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveVent.Location = New System.Drawing.Point(807, 389)
        Me.ValveVent.Name = "ValveVent"
        Me.ValveVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveVent.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveVent.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveVent.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveVent.Size = New System.Drawing.Size(40, 33)
        Me.ValveVent.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveVent.TabIndex = 207
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
        'ValveFixtureWater
        '
        Me.ValveFixtureWater.AccessibleName = "Fixture Wafer Valve"
        Me.ValveFixtureWater.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveFixtureWater.IsCheckSafetyBeforeClick = False
        Me.ValveFixtureWater.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveFixtureWater.Location = New System.Drawing.Point(776, 445)
        Me.ValveFixtureWater.Name = "ValveFixtureWater"
        Me.ValveFixtureWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveFixtureWater.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveFixtureWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveFixtureWater.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveFixtureWater.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveFixtureWater.Size = New System.Drawing.Size(40, 33)
        Me.ValveFixtureWater.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveFixtureWater.TabIndex = 207
        Me.ValveFixtureWater.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveFixtureWater.TextLocIsFix = True
        Me.ValveFixtureWater.TextValue = ""
        Me.ValveFixtureWater.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveFixtureWater.Unit = ""
        Me.ValveFixtureWater.UnknownImage = Nothing
        Me.ValveFixtureWater.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveFixtureWater.UseClickedEventInForm = True
        Me.ValveFixtureWater.UsingScientificFormat = True
        '
        'GasLine_FlowCool_Supply
        '
        Me.GasLine_FlowCool_Supply.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_FlowCool_Supply.BackColor = System.Drawing.Color.Transparent
        Me.GasLine_FlowCool_Supply.Location = New System.Drawing.Point(666, 526)
        Me.GasLine_FlowCool_Supply.Name = "GasLine_FlowCool_Supply"
        Me.GasLine_FlowCool_Supply.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasHe
        Me.GasLine_FlowCool_Supply.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasHe_On
        Me.GasLine_FlowCool_Supply.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasHe_On_1
        Me.GasLine_FlowCool_Supply.Size = New System.Drawing.Size(133, 61)
        Me.GasLine_FlowCool_Supply.TabIndex = 303
        '
        'SLFixture
        '
        Me.SLFixture.BackColor = System.Drawing.Color.Transparent
        Me.SLFixture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SLFixture.FixtureAngleAtLoadState = True
        Me.SLFixture.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLFixture.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.SLFixture.HeaderText = "Fixture"
        Me.SLFixture.HeaderTextColor = System.Drawing.Color.Black
        Me.SLFixture.HeaderVisible = True
        Me.SLFixture.IsOnline = False
        Me.SLFixture.Location = New System.Drawing.Point(799, 515)
        Me.SLFixture.Name = "SLFixture"
        Me.SLFixture.Size = New System.Drawing.Size(481, 252)
        Me.SLFixture.TabIndex = 218
        Me.SLFixture.Text = "Fixture"
        Me.SLFixture.TypeOfIBEChamber = AVPLib.ConstEnum.AllChamberType.AVP_IBE
        Me.SLFixture.UseBorderStyle = True
        '
        'SLInterlocks
        '
        Me.SLInterlocks.AirPressureVisible = False
        Me.SLInterlocks.BackColor = System.Drawing.Color.Transparent
        Me.SLInterlocks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SLInterlocks.ChamPressVisible = False
        Me.SLInterlocks.FixtureWaterBugVisible = False
        Me.SLInterlocks.FixtureWaterVisible = False
        Me.SLInterlocks.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLInterlocks.ForeLineVisible = False
        Me.SLInterlocks.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.SLInterlocks.HeaderText = "Interlocks"
        Me.SLInterlocks.HeaderTextColor = System.Drawing.Color.Black
        Me.SLInterlocks.HeaderVisible = True
        Me.SLInterlocks.Location = New System.Drawing.Point(4, 444)
        Me.SLInterlocks.Name = "SLInterlocks"
        Me.SLInterlocks.PanelVisible = False
        Me.SLInterlocks.Size = New System.Drawing.Size(324, 162)
        Me.SLInterlocks.SourceVisible = False
        Me.SLInterlocks.TabIndex = 216
        Me.SLInterlocks.Text = "Interlocks"
        Me.SLInterlocks.TurboWaterVisible = False
        Me.SLInterlocks.UseBorderStyle = True
        '
        'SLStatusPanel
        '
        Me.SLStatusPanel.BackColor = System.Drawing.Color.Transparent
        Me.SLStatusPanel.BackgroundImage = CType(resources.GetObject("SLStatusPanel.BackgroundImage"), System.Drawing.Image)
        Me.SLStatusPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SLStatusPanel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLStatusPanel.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.SLStatusPanel.HeaderText = "Status Panel"
        Me.SLStatusPanel.HeaderTextColor = System.Drawing.Color.Black
        Me.SLStatusPanel.HeaderVisible = True
        Me.SLStatusPanel.Location = New System.Drawing.Point(4, 174)
        Me.SLStatusPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.SLStatusPanel.Name = "SLStatusPanel"
        Me.SLStatusPanel.Size = New System.Drawing.Size(324, 265)
        Me.SLStatusPanel.TabIndex = 221
        Me.SLStatusPanel.Text = "Status Panel"
        Me.SLStatusPanel.UseBorderStyle = True
        '
        'RoughPump
        '
        Me.RoughPump.AccessibleName = "Rough Pump"
        Me.RoughPump.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RoughPump.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.RoughPump.IsCheckSafetyBeforeClick = False
        Me.RoughPump.IsCheckSafetyIsolationValveBeforeClick = False
        Me.RoughPump.Location = New System.Drawing.Point(320, 667)
        Me.RoughPump.Name = "RoughPump"
        Me.RoughPump.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.MechanicalPump_Off
        Me.RoughPump.OffState_ColorText = System.Drawing.Color.White
        Me.RoughPump.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.MechanicalPump_On
        Me.RoughPump.OnState_ColorText = System.Drawing.Color.White
        Me.RoughPump.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.RoughPump.Size = New System.Drawing.Size(126, 70)
        Me.RoughPump.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.RoughPump.TabIndex = 146
        Me.RoughPump.TextLocation = New System.Drawing.Point(55, 38)
        Me.RoughPump.TextLocIsFix = False
        Me.RoughPump.TextValue = ""
        Me.RoughPump.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.RoughPump.Unit = ""
        Me.RoughPump.UnknownImage = Nothing
        Me.RoughPump.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.RoughPump.UseClickedEventInForm = True
        Me.RoughPump.UsingScientificFormat = True
        '
        'RoughPump_Line
        '
        Me.RoughPump_Line.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.RoughPump_Line.BackColor = System.Drawing.Color.Transparent
        Me.RoughPump_Line.Location = New System.Drawing.Point(334, 152)
        Me.RoughPump_Line.Name = "RoughPump_Line"
        Me.RoughPump_Line.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasRoughPump_2
        Me.RoughPump_Line.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasRoughPump_On
        Me.RoughPump_Line.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_GasRoughPump_On_1
        Me.RoughPump_Line.Size = New System.Drawing.Size(50, 516)
        Me.RoughPump_Line.TabIndex = 296
        '
        'GasLine_Rough
        '
        Me.GasLine_Rough.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Rough.BackColor = System.Drawing.Color.Transparent
        Me.GasLine_Rough.Location = New System.Drawing.Point(424, 547)
        Me.GasLine_Rough.Name = "GasLine_Rough"
        Me.GasLine_Rough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Rough_Line_Off
        Me.GasLine_Rough.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Rough_Line_On
        Me.GasLine_Rough.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Rough_Line_On_1
        Me.GasLine_Rough.Size = New System.Drawing.Size(46, 47)
        Me.GasLine_Rough.TabIndex = 298
        '
        'GasLine_FixtureWater
        '
        Me.GasLine_FixtureWater.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_FixtureWater.BackColor = System.Drawing.Color.Transparent
        Me.GasLine_FixtureWater.Location = New System.Drawing.Point(706, 453)
        Me.GasLine_FixtureWater.Name = "GasLine_FixtureWater"
        Me.GasLine_FixtureWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_General_Return_Valve
        Me.GasLine_FixtureWater.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_General_Return_Valve_On
        Me.GasLine_FixtureWater.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_General_Return_Valve_On_1
        Me.GasLine_FixtureWater.Size = New System.Drawing.Size(119, 16)
        Me.GasLine_FixtureWater.TabIndex = 302
        '
        'GasLine_Vent
        '
        Me.GasLine_Vent.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Vent.BackColor = System.Drawing.Color.Transparent
        Me.GasLine_Vent.Location = New System.Drawing.Point(731, 397)
        Me.GasLine_Vent.Name = "GasLine_Vent"
        Me.GasLine_Vent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline_Vent_Valve
        Me.GasLine_Vent.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline_Vent_Valve_On
        Me.GasLine_Vent.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline_Vent_Valve_On_1
        Me.GasLine_Vent.Size = New System.Drawing.Size(130, 15)
        Me.GasLine_Vent.TabIndex = 301
        '
        'ValveRough
        '
        Me.ValveRough.AccessibleName = "Rough Valve"
        Me.ValveRough.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveRough.IsCheckSafetyBeforeClick = False
        Me.ValveRough.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveRough.Location = New System.Drawing.Point(384, 566)
        Me.ValveRough.Name = "ValveRough"
        Me.ValveRough.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveRough.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveRough.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveRough.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveRough.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveRough.Size = New System.Drawing.Size(40, 33)
        Me.ValveRough.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveRough.TabIndex = 207
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
        'PressureConnector
        '
        Me.PressureConnector.Location = New System.Drawing.Point(435, 110)
        Me.PressureConnector.Name = "PressureConnector"
        Me.PressureConnector.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.GasLine_CG_Off
        Me.PressureConnector.OffState_ColorText = System.Drawing.Color.Empty
        Me.PressureConnector.OnImage = Nothing
        Me.PressureConnector.OnState_ColorText = System.Drawing.Color.Empty
        Me.PressureConnector.Size = New System.Drawing.Size(8, 47)
        Me.PressureConnector.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.PressureConnector.TabIndex = 305
        Me.PressureConnector.TextLocation = New System.Drawing.Point(0, 0)
        Me.PressureConnector.TextLocIsFix = True
        Me.PressureConnector.TextValue = ""
        Me.PressureConnector.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.PressureConnector.UnknownImage = Nothing
        Me.PressureConnector.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'SLContainerBox
        '
        Me.SLContainerBox.BackColor = System.Drawing.Color.Transparent
        Me.SLContainerBox.BackgroundImage = CType(resources.GetObject("SLContainerBox.BackgroundImage"), System.Drawing.Image)
        Me.SLContainerBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.SLContainerBox.FullyInstalled = True
        Me.SLContainerBox.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.SLContainerBox.HeaderHeight = 32
        Me.SLContainerBox.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.SLContainerBox.HeaderText = "Header"
        Me.SLContainerBox.HeaderTextColor = System.Drawing.Color.White
        Me.SLContainerBox.HeaderVisible = False
        Me.SLContainerBox.Location = New System.Drawing.Point(377, 85)
        Me.SLContainerBox.Name = "SLContainerBox"
        Me.SLContainerBox.NoCryoInstalled = False
        Me.SLContainerBox.NoWaterPumpInstalled = False
        Me.SLContainerBox.ShutterInstalled = False
        Me.SLContainerBox.Size = New System.Drawing.Size(362, 595)
        Me.SLContainerBox.TabIndex = 230
        Me.SLContainerBox.Text = "Header"
        Me.SLContainerBox.TypeOfIBEChamber = AVPLib.ConstEnum.AllChamberType.VEECO_IBE
        '
        'lblDisconnect
        '
        Me.lblDisconnect.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblDisconnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDisconnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDisconnect.Font = New System.Drawing.Font("Times New Roman", 36.0!)
        Me.lblDisconnect.ForeColor = System.Drawing.Color.Red
        Me.lblDisconnect.Location = New System.Drawing.Point(398, 293)
        Me.lblDisconnect.Name = "lblDisconnect"
        Me.lblDisconnect.Size = New System.Drawing.Size(449, 119)
        Me.lblDisconnect.TabIndex = 241
        Me.lblDisconnect.Text = "DISCONNECTED"
        Me.lblDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDisconnect.Visible = False
        '
        'SL_SourceUsage
        '
        Me.SL_SourceUsage.BackColor = System.Drawing.Color.Transparent
        Me.SL_SourceUsage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SL_SourceUsage.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.SL_SourceUsage.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.SL_SourceUsage.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.SL_SourceUsage.HeaderText = "Source Min"
        Me.SL_SourceUsage.HeaderTextColor = System.Drawing.Color.Black
        Me.SL_SourceUsage.HeaderVisible = True
        Me.SL_SourceUsage.Location = New System.Drawing.Point(696, 49)
        Me.SL_SourceUsage.Name = "SL_SourceUsage"
        Me.SL_SourceUsage.Size = New System.Drawing.Size(115, 60)
        Me.SL_SourceUsage.TabIndex = 242
        Me.SL_SourceUsage.Text = "Source Min"
        Me.SL_SourceUsage.UseBorderStyle = True
        '
        'lblNameOfSequenceRunning
        '
        Me.lblNameOfSequenceRunning.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblNameOfSequenceRunning.ForeColor = System.Drawing.Color.Red
        Me.lblNameOfSequenceRunning.Location = New System.Drawing.Point(334, 50)
        Me.lblNameOfSequenceRunning.Name = "lblNameOfSequenceRunning"
        Me.lblNameOfSequenceRunning.Size = New System.Drawing.Size(235, 33)
        Me.lblNameOfSequenceRunning.TabIndex = 243
        '
        'GasLine_Flowcool_Return
        '
        Me.GasLine_Flowcool_Return.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Flowcool_Return.BackColor = System.Drawing.Color.Transparent
        Me.GasLine_Flowcool_Return.Location = New System.Drawing.Point(672, 504)
        Me.GasLine_Flowcool_Return.Name = "GasLine_Flowcool_Return"
        Me.GasLine_Flowcool_Return.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_General_Return_Valve
        Me.GasLine_Flowcool_Return.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_General_Return_Valve_On
        Me.GasLine_Flowcool_Return.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_General_Return_Valve_On_1
        Me.GasLine_Flowcool_Return.Size = New System.Drawing.Size(119, 16)
        Me.GasLine_Flowcool_Return.TabIndex = 302
        '
        'ValveFlowCoolReturn
        '
        Me.ValveFlowCoolReturn.AccessibleName = "Fixture Wafer Valve"
        Me.ValveFlowCoolReturn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveFlowCoolReturn.IsCheckSafetyBeforeClick = False
        Me.ValveFlowCoolReturn.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveFlowCoolReturn.Location = New System.Drawing.Point(742, 496)
        Me.ValveFlowCoolReturn.Name = "ValveFlowCoolReturn"
        Me.ValveFlowCoolReturn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveFlowCoolReturn.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveFlowCoolReturn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveFlowCoolReturn.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveFlowCoolReturn.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveFlowCoolReturn.Size = New System.Drawing.Size(40, 33)
        Me.ValveFlowCoolReturn.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveFlowCoolReturn.TabIndex = 207
        Me.ValveFlowCoolReturn.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveFlowCoolReturn.TextLocIsFix = True
        Me.ValveFlowCoolReturn.TextValue = ""
        Me.ValveFlowCoolReturn.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveFlowCoolReturn.Unit = ""
        Me.ValveFlowCoolReturn.UnknownImage = Nothing
        Me.ValveFlowCoolReturn.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveFlowCoolReturn.UseClickedEventInForm = True
        Me.ValveFlowCoolReturn.UsingScientificFormat = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(710, 479)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(89, 21)
        Me.Label25.TabIndex = 222
        Me.Label25.Text = "FC Return"
        '
        'btnRelayIndicatorPump
        '
        Me.btnRelayIndicatorPump.AccessibleName = "TurboLLA"
        Me.btnRelayIndicatorPump.BackColor = System.Drawing.Color.Transparent
        Me.btnRelayIndicatorPump.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRelayIndicatorPump.Clickable = True
        Me.btnRelayIndicatorPump.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnRelayIndicatorPump.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump.FlatAppearance.BorderSize = 0
        Me.btnRelayIndicatorPump.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelayIndicatorPump.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelayIndicatorPump.ForeColor = System.Drawing.Color.White
        Me.btnRelayIndicatorPump.Location = New System.Drawing.Point(430, 672)
        Me.btnRelayIndicatorPump.MessageBoxText = Nothing
        Me.btnRelayIndicatorPump.Name = "btnRelayIndicatorPump"
        Me.btnRelayIndicatorPump.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOn
        Me.btnRelayIndicatorPump.Size = New System.Drawing.Size(10, 10)
        Me.btnRelayIndicatorPump.TabIndex = 284
        Me.btnRelayIndicatorPump.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnRelayIndicatorPump.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelayIndicatorPump.UseClickedEventInForm = True
        Me.btnRelayIndicatorPump.UseVisualStyleBackColor = False
        Me.btnRelayIndicatorPump.ValueToBeSend = ""
        '
        'lblCurrentPurgeCycle
        '
        Me.lblCurrentPurgeCycle.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblCurrentPurgeCycle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCurrentPurgeCycle.Location = New System.Drawing.Point(604, 115)
        Me.lblCurrentPurgeCycle.Name = "lblCurrentPurgeCycle"
        Me.lblCurrentPurgeCycle.Size = New System.Drawing.Size(171, 31)
        Me.lblCurrentPurgeCycle.TabIndex = 244
        '
        'Foreline_Line
        '
        Me.Foreline_Line.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.Foreline_Line.BackColor = System.Drawing.Color.Transparent
        Me.Foreline_Line.Location = New System.Drawing.Point(421, 152)
        Me.Foreline_Line.Name = "Foreline_Line"
        Me.Foreline_Line.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Foreline_Line_Off
        Me.Foreline_Line.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Foreline_Line_On
        Me.Foreline_Line.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Foreline_Line_On_1
        Me.Foreline_Line.Size = New System.Drawing.Size(39, 22)
        Me.Foreline_Line.TabIndex = 297
        '
        'RoughLineTimer
        '
        Me.RoughLineTimer.Interval = 300
        '
        'ChillerControl
        '
        Me.ChillerControl.BackColor = System.Drawing.Color.Transparent
        Me.ChillerControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ChillerControl.ChillerModel = ""
        Me.ChillerControl.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChillerControl.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.ChillerControl.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.ChillerControl.HeaderText = "Chiller"
        Me.ChillerControl.HeaderTextColor = System.Drawing.Color.Black
        Me.ChillerControl.HeaderVisible = True
        Me.ChillerControl.Headerwidth = 85
        Me.ChillerControl.IsOnline = False
        Me.ChillerControl.Location = New System.Drawing.Point(480, 682)
        Me.ChillerControl.Name = "ChillerControl"
        Me.ChillerControl.Size = New System.Drawing.Size(256, 60)
        Me.ChillerControl.TabIndex = 295
        Me.ChillerControl.Text = "Chiller"
        Me.ChillerControl.UseBorderStyle = True
        '
        'txtMPPressure
        '
        Me.txtMPPressure.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtMPPressure.Clickable = False
        Me.txtMPPressure.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMPPressure.DisplayPressureFont = True
        Me.txtMPPressure.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMPPressure.ForeColor = System.Drawing.Color.Lime
        Me.txtMPPressure.IsReadBack = True
        Me.txtMPPressure.Location = New System.Drawing.Point(360, 701)
        Me.txtMPPressure.MinimumValueHighlightedGreen = 0
        Me.txtMPPressure.Name = "txtMPPressure"
        Me.txtMPPressure.ReadOnly = True
        Me.txtMPPressure.Size = New System.Drawing.Size(76, 24)
        Me.txtMPPressure.TabIndex = 388
        Me.txtMPPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMPPressure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMPPressure.UseScientificFormat = True
        '
        'EMPowerSupply
        '
        Me.EMPowerSupply.BackColor = System.Drawing.Color.Transparent
        Me.EMPowerSupply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.EMPowerSupply.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EMPowerSupply.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.EMPowerSupply.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.EMPowerSupply.HeaderText = "Electromagnet Power Supply"
        Me.EMPowerSupply.HeaderTextColor = System.Drawing.Color.Black
        Me.EMPowerSupply.HeaderVisible = True
        Me.EMPowerSupply.IsOnline = False
        Me.EMPowerSupply.Location = New System.Drawing.Point(4, 742)
        Me.EMPowerSupply.Margin = New System.Windows.Forms.Padding(2)
        Me.EMPowerSupply.Name = "EMPowerSupply"
        Me.EMPowerSupply.Size = New System.Drawing.Size(324, 86)
        Me.EMPowerSupply.TabIndex = 389
        Me.EMPowerSupply.Text = "Electromagnet Power Supply"
        Me.EMPowerSupply.UseBorderStyle = True
        '
        'ValveIGIsolation
        '
        Me.ValveIGIsolation.AccessibleName = "Isolation Valve"
        Me.ValveIGIsolation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ValveIGIsolation.IsCheckSafetyBeforeClick = False
        Me.ValveIGIsolation.IsCheckSafetyIsolationValveBeforeClick = False
        Me.ValveIGIsolation.Location = New System.Drawing.Point(630, 111)
        Me.ValveIGIsolation.Name = "ValveIGIsolation"
        Me.ValveIGIsolation.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Closed
        Me.ValveIGIsolation.OffState_ColorText = System.Drawing.Color.Empty
        Me.ValveIGIsolation.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.New_Valve_Opened
        Me.ValveIGIsolation.OnState_ColorText = System.Drawing.Color.Empty
        Me.ValveIGIsolation.SafetyValveType = AVP_Robot_Project.ValveControl.SafetyInterlockValve.None
        Me.ValveIGIsolation.Size = New System.Drawing.Size(40, 33)
        Me.ValveIGIsolation.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.ValveIGIsolation.TabIndex = 390
        Me.ValveIGIsolation.TextLocation = New System.Drawing.Point(0, 0)
        Me.ValveIGIsolation.TextLocIsFix = True
        Me.ValveIGIsolation.TextValue = ""
        Me.ValveIGIsolation.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.ValveIGIsolation.Unit = ""
        Me.ValveIGIsolation.UnknownImage = Nothing
        Me.ValveIGIsolation.UnknownState_ColorText = System.Drawing.Color.Empty
        Me.ValveIGIsolation.UseClickedEventInForm = True
        Me.ValveIGIsolation.UsingScientificFormat = True
        '
        'GasLine_Isolation
        '
        Me.GasLine_Isolation.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine_Isolation.BackColor = System.Drawing.Color.Transparent
        Me.GasLine_Isolation.Location = New System.Drawing.Point(582, 109)
        Me.GasLine_Isolation.Name = "GasLine_Isolation"
        Me.GasLine_Isolation.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline_Isolation_Valve
        Me.GasLine_Isolation.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline_Isolation_Valve_On
        Me.GasLine_Isolation.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gasline_Isolation_Valve_On1
        Me.GasLine_Isolation.Size = New System.Drawing.Size(117, 112)
        Me.GasLine_Isolation.TabIndex = 391
        '
        'lblIGIsolation
        '
        Me.lblIGIsolation.AutoSize = True
        Me.lblIGIsolation.BackColor = System.Drawing.Color.Transparent
        Me.lblIGIsolation.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIGIsolation.ForeColor = System.Drawing.Color.White
        Me.lblIGIsolation.Location = New System.Drawing.Point(769, 316)
        Me.lblIGIsolation.Name = "lblIGIsolation"
        Me.lblIGIsolation.Size = New System.Drawing.Size(59, 21)
        Me.lblIGIsolation.TabIndex = 392
        Me.lblIGIsolation.Text = "IG Iso"
        '
        'GasLine234_Total
        '
        Me.GasLine234_Total.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.GasLine234_Total.BackColor = System.Drawing.Color.Transparent
        Me.GasLine234_Total.Location = New System.Drawing.Point(714, 297)
        Me.GasLine234_Total.Name = "GasLine234_Total"
        Me.GasLine234_Total.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas234
        Me.GasLine234_Total.OnImage0 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas234_On
        Me.GasLine234_Total.OnImage1 = Global.AVP_Robot_Project.My.Resources.Resources.SL_Gas234_On1
        Me.GasLine234_Total.Size = New System.Drawing.Size(154, 15)
        Me.GasLine234_Total.TabIndex = 393
        Me.GasLine234_Total.Visible = False
        '
        'lblDiverterGas
        '
        Me.lblDiverterGas.AutoSize = True
        Me.lblDiverterGas.BackColor = System.Drawing.Color.Transparent
        Me.lblDiverterGas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiverterGas.ForeColor = System.Drawing.Color.Yellow
        Me.lblDiverterGas.Location = New System.Drawing.Point(751, 279)
        Me.lblDiverterGas.Name = "lblDiverterGas"
        Me.lblDiverterGas.Size = New System.Drawing.Size(47, 19)
        Me.lblDiverterGas.TabIndex = 394
        Me.lblDiverterGas.Text = "CIBE"
        Me.lblDiverterGas.Visible = False
        '
        'IBEPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.lblDiverterGas)
        Me.Controls.Add(Me.lblDisconnect)
        Me.Controls.Add(Me.GasLine234_Total)
        Me.Controls.Add(Me.lblIGIsolation)
        Me.Controls.Add(Me.GasLine_Isolation)
        Me.Controls.Add(Me.ValveIGIsolation)
        Me.Controls.Add(Me.EMPowerSupply)
        Me.Controls.Add(Me.txtMPPressure)
        Me.Controls.Add(Me.txtMG)
        Me.Controls.Add(Me.GasLine_FlowCool_Supply)
        Me.Controls.Add(Me.ValveVent)
        Me.Controls.Add(Me.ValveFixtureWater)
        Me.Controls.Add(Me.ValveFlowCoolReturn)
        Me.Controls.Add(Me.GasLine_Flowcool_Return)
        Me.Controls.Add(Me.GasLine_FixtureWater)
        Me.Controls.Add(Me.GasLine_Vent)
        Me.Controls.Add(Me.GasLine_Total)
        Me.Controls.Add(Me.PBNGasLine)
        Me.Controls.Add(Me.GasLine_Rough)
        Me.Controls.Add(Me.Foreline_Line)
        Me.Controls.Add(Me.RoughPump_Line)
        Me.Controls.Add(Me.ChillerControl)
        Me.Controls.Add(Me.tabProcessModule)
        Me.Controls.Add(Me.lblCurrentPurgeCycle)
        Me.Controls.Add(Me.btnRelayIndicatorPump)
        Me.Controls.Add(Me.lblNameOfSequenceRunning)
        Me.Controls.Add(Me.SL_SourceUsage)
        Me.Controls.Add(Me.btnUnProtected)
        Me.Controls.Add(Me.SLPM)
        Me.Controls.Add(Me.txtForelineCG)
        Me.Controls.Add(Me.btnTooltipFixture)
        Me.Controls.Add(Me.txtRoughlineCG)
        Me.Controls.Add(Me.SLPowerPanel)
        Me.Controls.Add(Me.SLIGCGControl)
        Me.Controls.Add(Me.SLRLCG)
        Me.Controls.Add(Me.SLFLCG)
        Me.Controls.Add(Me.ValveForeline)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SLFixture)
        Me.Controls.Add(Me.SLInterlocks)
        Me.Controls.Add(Me.SLStatusPanel)
        Me.Controls.Add(Me.RoughPump)
        Me.Controls.Add(Me.ValveRough)
        Me.Controls.Add(Me.PressureConnector)
        Me.Controls.Add(Me.SLContainerBox)
        Me.Name = "IBEPanel"
        Me.Size = New System.Drawing.Size(1280, 903)
        Me.Controls.SetChildIndex(Me.SLContainerBox, 0)
        Me.Controls.SetChildIndex(Me.PressureConnector, 0)
        Me.Controls.SetChildIndex(Me.ValveRough, 0)
        Me.Controls.SetChildIndex(Me.RoughPump, 0)
        Me.Controls.SetChildIndex(Me.SLStatusPanel, 0)
        Me.Controls.SetChildIndex(Me.SLInterlocks, 0)
        Me.Controls.SetChildIndex(Me.SLFixture, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.ValveForeline, 0)
        Me.Controls.SetChildIndex(Me.SLFLCG, 0)
        Me.Controls.SetChildIndex(Me.SLRLCG, 0)
        Me.Controls.SetChildIndex(Me.SLIGCGControl, 0)
        Me.Controls.SetChildIndex(Me.SLPowerPanel, 0)
        Me.Controls.SetChildIndex(Me.txtRoughlineCG, 0)
        Me.Controls.SetChildIndex(Me.btnTooltipFixture, 0)
        Me.Controls.SetChildIndex(Me.txtForelineCG, 0)
        Me.Controls.SetChildIndex(Me.SLPM, 0)
        Me.Controls.SetChildIndex(Me.btnUnProtected, 0)
        Me.Controls.SetChildIndex(Me.SL_SourceUsage, 0)
        Me.Controls.SetChildIndex(Me.lblNameOfSequenceRunning, 0)
        Me.Controls.SetChildIndex(Me.btnRelayIndicatorPump, 0)
        Me.Controls.SetChildIndex(Me.lblCurrentPurgeCycle, 0)
        Me.Controls.SetChildIndex(Me.tabProcessModule, 0)
        Me.Controls.SetChildIndex(Me.ChillerControl, 0)
        Me.Controls.SetChildIndex(Me.RoughPump_Line, 0)
        Me.Controls.SetChildIndex(Me.Foreline_Line, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Rough, 0)
        Me.Controls.SetChildIndex(Me.PBNGasLine, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Total, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Vent, 0)
        Me.Controls.SetChildIndex(Me.GasLine_FixtureWater, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Flowcool_Return, 0)
        Me.Controls.SetChildIndex(Me.ValveFlowCoolReturn, 0)
        Me.Controls.SetChildIndex(Me.ValveFixtureWater, 0)
        Me.Controls.SetChildIndex(Me.ValveVent, 0)
        Me.Controls.SetChildIndex(Me.GasLine_FlowCool_Supply, 0)
        Me.Controls.SetChildIndex(Me.txtMG, 0)
        Me.Controls.SetChildIndex(Me.txtMPPressure, 0)
        Me.Controls.SetChildIndex(Me.EMPowerSupply, 0)
        Me.Controls.SetChildIndex(Me.ValveIGIsolation, 0)
        Me.Controls.SetChildIndex(Me.GasLine_Isolation, 0)
        Me.Controls.SetChildIndex(Me.lblIGIsolation, 0)
        Me.Controls.SetChildIndex(Me.GasLine234_Total, 0)
        Me.Controls.SetChildIndex(Me.lblDisconnect, 0)
        Me.Controls.SetChildIndex(Me.lblDiverterGas, 0)
        Me.tabProcessModule.ResumeLayout(False)
        Me.tabSource.ResumeLayout(False)
        Me.tabSource.PerformLayout()
        Me.tabProcessStatus.ResumeLayout(False)
        Me.tabProcessStatus.PerformLayout()
        Me.tabGas.ResumeLayout(False)
        Me.tabGas.PerformLayout()
        CType(Me.GasLine3_Total_Below, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine2_Total_Below, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine3_Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Shutoff3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine2_Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Shutoff2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine1_Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine1_Total_Below, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Shutoff4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_PBNShutoff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Shutoff1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_PBNSupply, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Supply1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Supply2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Supply4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Supply3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Total1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPartID.ResumeLayout(False)
        Me.tabPartID.PerformLayout()
        Me.cmstooltipFixture.ResumeLayout(False)
        CType(Me.PBNGasLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_FlowCool_Supply, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RoughPump_Line, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Rough, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_FixtureWater, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Vent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Flowcool_Return, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Foreline_Line, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine_Isolation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GasLine234_Total, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RoughPump As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveSupplyGas3 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveSupplyGas2 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveSupplyGas1 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveSupplyPBNGas As AVP_Robot_Project.ValveControl
    Friend WithEvents SLInterlocks As AVP_Robot_Project.SL_InterlockControl
    Friend WithEvents SLFixture As AVP_Robot_Project.SL_Fixture
    Friend WithEvents tabProcessModule As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabSource As System.Windows.Forms.TabPage
    Friend WithEvents tabProcessStatus As System.Windows.Forms.TabPage
    Friend WithEvents tabGas As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblKFactor As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SLStatusPanel As AVP_Robot_Project.SL_StatusPanel
    Friend WithEvents lblGas3 As System.Windows.Forms.Label
    Friend WithEvents lblGasPBN As System.Windows.Forms.Label
    Friend WithEvents lblGas2 As System.Windows.Forms.Label
    Friend WithEvents lblGas1 As System.Windows.Forms.Label
    Friend WithEvents ValveShutoffPBNGas As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveShutoffGas1 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveShutoffGas2 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveShutoffGas3 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveRough As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveVent As AVP_Robot_Project.ValveControl
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ValveForeline As AVP_Robot_Project.ValveControl
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents SLFLCG As AVP_Robot_Project.SL_Info
    Friend WithEvents txtRFPower As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNDisch As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNBody As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtKFactor As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRFReflected As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSuppressorCurrent As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSuppressorVoltage As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBeamCurrent As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSuppressorVoltageRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRFPowerRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBeamCurrentRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBeamVoltageRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBeamVoltage As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNDischRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNBodyRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtKFactorRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRFReflectedRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtElapsedTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtProcessStep As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtStatus As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtStepTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRemainingTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtWaferID As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRecipe As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas3 As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas2 As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas1 As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNGas As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas3Right As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas2Right As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas1Right As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNGasRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents SLContainerBox As AVP_Robot_Project.SLBox
    Friend WithEvents SLRLCG As AVP_Robot_Project.SL_Info
    Friend WithEvents txtGas1_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNGas_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSuppressorCurrentRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas1Right_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNGasRight_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblSourceGas1 As System.Windows.Forms.Label
    Friend WithEvents lblSourcePBNGas As System.Windows.Forms.Label
    Friend WithEvents txtGas2_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas2Right_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblSourceGas2 As System.Windows.Forms.Label
    Friend WithEvents cmstooltipFixture As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCoolingWater As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUnProtected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTooltipFixture As System.Windows.Forms.Button
    Friend WithEvents SLPowerPanel As AVP_Robot_Project.SL_PowerPanel
    Friend WithEvents SLIGCGControl As AVP_Robot_Project.SL_IGCGControl
    Friend WithEvents mnuStartRotation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHomeRotation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAutoBeam As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtTotalStep As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ValveFixtureWater As AVP_Robot_Project.ValveControl
    Friend WithEvents SLPM As AVP_Robot_Project.SL_Info
    Friend WithEvents txtRoughlineCG As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtForelineCG As AVP_Robot_Project.SL_Textbox
    Friend WithEvents PressureConnector As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents btnSourceAuto As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnSourceManual As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtMG As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnUnProtected As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtSourceMinutes As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblDisconnect As System.Windows.Forms.Label
    Friend WithEvents btnOpenClosePBNGas As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnOpenCloseGas3 As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnOpenCloseGas2 As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnOpenCloseGas1 As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnSourceSaveLoad As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents SL_SourceUsage As AVP_Robot_Project.SL_Info
    Friend WithEvents lblNameOfSequenceRunning As System.Windows.Forms.Label
    Friend WithEvents ValveFlowCoolReturn As AVP_Robot_Project.ValveControl
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnRelayIndicatorPump As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblCurrentPurgeCycle As System.Windows.Forms.Label
    Friend WithEvents btnOpenCloseGas4 As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtGas4 As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas4Right As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblGas4 As System.Windows.Forms.Label
    Friend WithEvents ValveShutoffGas4 As AVP_Robot_Project.ValveControl
    Friend WithEvents ValveSupplyGas4 As AVP_Robot_Project.ValveControl
    Friend WithEvents txtGas4_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas3_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas4Right_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas3Right_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblSourceGas4 As System.Windows.Forms.Label
    Friend WithEvents lblSourceGas3 As System.Windows.Forms.Label
    Friend WithEvents tabPartID As System.Windows.Forms.TabPage
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtGridSerialNumber As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtGridID As AVP_Robot_Project.SL_Textbox
    Friend WithEvents cmbRebuildLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtPBNMinutes As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtSourceMinutesMaint As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents RoughLineTimer As System.Windows.Forms.Timer
    Friend WithEvents ChillerControl As AVP_Robot_Project.SL_ChillerControl
    Friend WithEvents RoughPump_Line As AVPControls.AnimationControl
    Friend WithEvents Foreline_Line As AVPControls.AnimationControl
    Friend WithEvents GasLine_Rough As AVPControls.AnimationControl
    Friend WithEvents PBNGasLine As AVPControls.AnimationControl
    Friend WithEvents GasLine_Total As AVPControls.AnimationControl
    Friend WithEvents GasLine_Vent As AVPControls.AnimationControl
    Friend WithEvents GasLine_FixtureWater As AVPControls.AnimationControl
    Friend WithEvents GasLine_FlowCool_Supply As AVPControls.AnimationControl
    Friend WithEvents GasLine_Flowcool_Return As AVPControls.AnimationControl
    Friend WithEvents GasLine_PBNSupply As AVPControls.AnimationControl
    Friend WithEvents GasLine_PBNShutoff As AVPControls.AnimationControl
    Friend WithEvents GasLine1_Total_Below As AVPControls.AnimationControl
    Friend WithEvents GasLine1_Total As AVPControls.AnimationControl
    Friend WithEvents GasLine_Total1 As AVPControls.AnimationControl
    Friend WithEvents GasLine_Shutoff1 As AVPControls.AnimationControl
    Friend WithEvents GasLine_Supply1 As AVPControls.AnimationControl
    Friend WithEvents GasLine_Shutoff4 As AVPControls.AnimationControl
    Friend WithEvents GasLine_Supply4 As AVPControls.AnimationControl
    Friend WithEvents GasLine_Supply3 As AVPControls.AnimationControl
    Friend WithEvents GasLine_Supply2 As AVPControls.AnimationControl
    Friend WithEvents txtPBNDischVolt As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNBodyVolt As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtWaterJournalSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtFixtureRotationMotorUsageSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtCryoUsageSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtLinerSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtShutterUsageSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTopFixtureShieldUsageSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtWaferClampUsageSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtCoverFixtureShieldUsageSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtShieldQuartSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtANC As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblANC As System.Windows.Forms.Label
    Friend WithEvents txtMPPressure As AVP_Robot_Project.SL_Textbox
    Friend WithEvents EMPowerSupply As AVP_Robot_Project.SL_ElectromagnetPS
    Friend WithEvents txtSourceEMCurrentRight_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSourceEMCurrent_SourceTab As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblSourceEMCurrent_SourceTab As System.Windows.Forms.Label
    Friend WithEvents ValveIGIsolation As AVP_Robot_Project.ValveControl
    Friend WithEvents GasLine_Isolation As AVPControls.AnimationControl
    Friend WithEvents GasLine_Shutoff2 As AVPControls.AnimationControl
    Friend WithEvents GasLine_Shutoff3 As AVPControls.AnimationControl
    Friend WithEvents lblIGIsolation As System.Windows.Forms.Label
    Friend WithEvents GasLine234_Total As AVPControls.AnimationControl
    Friend WithEvents GasLine3_Total As AVPControls.AnimationControl
    Friend WithEvents ValveDiverter As AVP_Robot_Project.ValveControl
    Friend WithEvents GasLine3_Total_Below As AVPControls.AnimationControl
    Friend WithEvents GasLine2_Total_Below As AVPControls.AnimationControl
    Friend WithEvents GasLine2_Total As AVPControls.AnimationControl
    Friend WithEvents lblDiverterGas As System.Windows.Forms.Label
End Class
