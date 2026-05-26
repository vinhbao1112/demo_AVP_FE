<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProcessPanel))
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPM1MotionInitialize = New System.Windows.Forms.Label
        Me.lblPM2MotionInitialize = New System.Windows.Forms.Label
        Me.lblPM3MotionInitialize = New System.Windows.Forms.Label
        Me.awcAligner = New AVPControls.AVPAlignerControl
        Me.lblStatusText = New System.Windows.Forms.Label
        Me.cmsChamber = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuReturn = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuResume = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuReturnNow = New System.Windows.Forms.ToolStripMenuItem
        Me.TransparentImageAligner = New AVP_Robot_Project.TransparentImageControl
        Me.TMCtl = New AVP_Robot_Project.TMControl
        Me.lpcLoadLockA = New AVP_Robot_Project.LockProcessControl
        Me.btnMakeAllOnline = New AVPControls.AVPButton
        Me.cbcChamber4 = New AVP_Robot_Project.ChamberControl
        Me.cbcChamber3 = New AVP_Robot_Project.ChamberControl
        Me.cbcChamber5 = New AVP_Robot_Project.ChamberControl
        Me.cbcChamber1 = New AVP_Robot_Project.ChamberControl
        Me.wccWaferCount = New AVP_Robot_Project.WaferCountControl
        Me.cbcChamber2 = New AVP_Robot_Project.ChamberControl
        Me.Robot_Body = New AVPControls.RobotBodyControl
        Me.CX_PM1 = New AVP_Robot_Project.PMControl
        Me.CX_PM2 = New AVP_Robot_Project.PMControl
        Me.CX_PM3 = New AVP_Robot_Project.PMControl
        Me.LLALeg = New AVP_Robot_Project.LoadLockLeg
        Me.picBackGround = New System.Windows.Forms.PictureBox
        Me.btnClearAllWafer = New AVPControls.AVPButton
        Me.lblFlashing = New AVPControls.FlashingLabel
        Me.lblPM2MotionStatus = New System.Windows.Forms.Label
        Me.lblPM1MotionStatus = New System.Windows.Forms.Label
        Me.lblPM3MotionStatus = New System.Windows.Forms.Label
        Me.lblLoadLockADoor = New AVPControls.FlashingLabel
        Me.MesaValveLLA = New AVP_Robot_Project.SlitValve
        Me.MesaValvePM1 = New AVP_Robot_Project.SlitValve
        Me.MesaValvePM2 = New AVP_Robot_Project.SlitValve
        Me.MesaValvePM3 = New AVP_Robot_Project.SlitValve
        Me.RobotHand = New AVPControls.RobotArmControl
        Me.lblAlignerEECM = New System.Windows.Forms.Label
        Me.lblAlignerEECA = New System.Windows.Forms.Label
        Me.lblAlignAngle = New System.Windows.Forms.Label
        Me.lblComunicationLED_TurboTM = New System.Windows.Forms.Label
        Me.btnTurboTM = New AVP_Robot_Project.SL_CustomButton
        Me.PumpTM = New AVP_Robot_Project.PumpChamber
        Me.HivacValveTM = New AVP_Robot_Project.SlitValve
        Me.HivacValveLLA = New AVP_Robot_Project.SlitValve
        Me.lblComunicationLED_TurboLLA = New System.Windows.Forms.Label
        Me.btnTurboLLA = New AVP_Robot_Project.SL_CustomButton
        Me.PumpLLA = New AVP_Robot_Project.PumpChamber
        Me.runNoControl = New AVP_Robot_Project.RunNoControl
        Me.ctrTMTurboCom = New AVPControls.LEDControl
        Me.ctrLLATurboCom = New AVPControls.LEDControl
        CType(Me.awcAligner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsChamber.SuspendLayout()
        CType(Me.Robot_Body, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBackGround, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RobotHand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ctrTMTurboCom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ctrLLATurboCom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1280, 50)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PROCESS VIEW"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPM1MotionInitialize
        '
        Me.lblPM1MotionInitialize.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM1MotionInitialize.ForeColor = System.Drawing.Color.Yellow
        Me.lblPM1MotionInitialize.Location = New System.Drawing.Point(349, 220)
        Me.lblPM1MotionInitialize.Name = "lblPM1MotionInitialize"
        Me.lblPM1MotionInitialize.Size = New System.Drawing.Size(109, 16)
        Me.lblPM1MotionInitialize.TabIndex = 245
        Me.lblPM1MotionInitialize.Text = "Motion Initializing"
        '
        'lblPM2MotionInitialize
        '
        Me.lblPM2MotionInitialize.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM2MotionInitialize.ForeColor = System.Drawing.Color.Yellow
        Me.lblPM2MotionInitialize.Location = New System.Drawing.Point(750, 48)
        Me.lblPM2MotionInitialize.Name = "lblPM2MotionInitialize"
        Me.lblPM2MotionInitialize.Size = New System.Drawing.Size(109, 16)
        Me.lblPM2MotionInitialize.TabIndex = 245
        Me.lblPM2MotionInitialize.Text = "Motion Initializing"
        '
        'lblPM3MotionInitialize
        '
        Me.lblPM3MotionInitialize.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM3MotionInitialize.ForeColor = System.Drawing.Color.Yellow
        Me.lblPM3MotionInitialize.Location = New System.Drawing.Point(791, 220)
        Me.lblPM3MotionInitialize.Name = "lblPM3MotionInitialize"
        Me.lblPM3MotionInitialize.Size = New System.Drawing.Size(109, 16)
        Me.lblPM3MotionInitialize.TabIndex = 245
        Me.lblPM3MotionInitialize.Text = "Motion Initializing"
        '
        'awcAligner
        '
        Me.awcAligner.AnimationInterval = 100
        Me.awcAligner.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.awcAligner.BackColor = System.Drawing.SystemColors.ControlDark
        Me.awcAligner.Cursor = System.Windows.Forms.Cursors.Hand
        Me.awcAligner.Location = New System.Drawing.Point(623, 435)
        Me.awcAligner.Name = "awcAligner"
        Me.awcAligner.Size = New System.Drawing.Size(35, 35)
        Me.awcAligner.TabIndex = 80
        '
        'lblStatusText
        '
        Me.lblStatusText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatusText.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusText.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusText.ForeColor = System.Drawing.Color.White
        Me.lblStatusText.Location = New System.Drawing.Point(20, 779)
        Me.lblStatusText.Name = "lblStatusText"
        Me.lblStatusText.Size = New System.Drawing.Size(1155, 20)
        Me.lblStatusText.TabIndex = 97
        Me.lblStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmsChamber
        '
        Me.cmsChamber.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReturn, Me.mnuResume, Me.mnuReturnNow})
        Me.cmsChamber.Name = "cmsChamber"
        Me.cmsChamber.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsChamber.ShowImageMargin = False
        Me.cmsChamber.Size = New System.Drawing.Size(156, 70)
        '
        'mnuReturn
        '
        Me.mnuReturn.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuReturn.Name = "mnuReturn"
        Me.mnuReturn.Size = New System.Drawing.Size(155, 22)
        Me.mnuReturn.Text = "Mark For Return"
        '
        'mnuResume
        '
        Me.mnuResume.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuResume.Name = "mnuResume"
        Me.mnuResume.Size = New System.Drawing.Size(155, 22)
        Me.mnuResume.Text = "Resume"
        '
        'mnuReturnNow
        '
        Me.mnuReturnNow.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuReturnNow.Name = "mnuReturnNow"
        Me.mnuReturnNow.Size = New System.Drawing.Size(155, 22)
        Me.mnuReturnNow.Text = "Return Wafer"
        '
        'TransparentImageAligner
        '
        Me.TransparentImageAligner.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TransparentImageAligner.Image = Nothing
        Me.TransparentImageAligner.ImageSize = New System.Drawing.Size(140, 140)
        Me.TransparentImageAligner.IsChamberPic = False
        Me.TransparentImageAligner.IsStretch = True
        Me.TransparentImageAligner.Location = New System.Drawing.Point(352, 488)
        Me.TransparentImageAligner.Name = "TransparentImageAligner"
        Me.TransparentImageAligner.Size = New System.Drawing.Size(38, 34)
        Me.TransparentImageAligner.TabIndex = 89
        Me.TransparentImageAligner.TextColor = System.Drawing.Color.Wheat
        Me.TransparentImageAligner.TextInImage = ""
        Me.TransparentImageAligner.TextLocation = New System.Drawing.Point(0, 0)
        Me.TransparentImageAligner.Visible = False
        '
        'TMCtl
        '
        Me.TMCtl.BackColor = System.Drawing.Color.Transparent
        Me.TMCtl.Display_In = AVP_Robot_Project.TMControl.AVPScreens.ProcessPanel
        Me.TMCtl.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMCtl.HeaderFont = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMCtl.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.TMCtl.HeaderText = "TM - Offline"
        Me.TMCtl.HeaderText_Offline = "TM - Offline"
        Me.TMCtl.HeaderText_Online = "TM - Online"
        Me.TMCtl.HeaderTextColor = System.Drawing.Color.White
        Me.TMCtl.HeaderVisible = False
        Me.TMCtl.IsOnline = False
        Me.TMCtl.Location = New System.Drawing.Point(561, 550)
        Me.TMCtl.Name = "TMCtl"
        Me.TMCtl.Size = New System.Drawing.Size(160, 57)
        Me.TMCtl.TabIndex = 153
        Me.TMCtl.Text = "TM - Offline"
        Me.TMCtl.UseBorderStyle = True
        '
        'lpcLoadLockA
        '
        Me.lpcLoadLockA.AlignStyle = AVP_Robot_Project.LockProcessControl.DisplayStyle.Left
        Me.lpcLoadLockA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lpcLoadLockA.BackColor = System.Drawing.Color.Transparent
        Me.lpcLoadLockA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lpcLoadLockA.CheckingPermission = False
        Me.lpcLoadLockA.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lpcLoadLockA.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lpcLoadLockA.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.lpcLoadLockA.HeaderText = "LLA - Offline"
        Me.lpcLoadLockA.HeaderText_Off = "LLA - Offline"
        Me.lpcLoadLockA.HeaderText_On = "LLA - Online"
        Me.lpcLoadLockA.HeaderTextColor = System.Drawing.Color.White
        Me.lpcLoadLockA.HeaderVisible = True
        Me.lpcLoadLockA.IsInCycleMode = False
        Me.lpcLoadLockA.Location = New System.Drawing.Point(217, 550)
        Me.lpcLoadLockA.LotID = ""
        Me.lpcLoadLockA.Name = "lpcLoadLockA"
        Me.lpcLoadLockA.ProcessStatus = AVP_Robot_Project.ProcessStatuses.[STOP]
        Me.lpcLoadLockA.SeqID = ""
        Me.lpcLoadLockA.Size = New System.Drawing.Size(342, 226)
        Me.lpcLoadLockA.TabIndex = 8
        Me.lpcLoadLockA.Tag = "Load Lock A"
        Me.lpcLoadLockA.Text = "LLA - Offline"
        Me.lpcLoadLockA.UseBorderStyle = True
        '
        'btnMakeAllOnline
        '
        Me.btnMakeAllOnline.BackColor = System.Drawing.Color.Transparent
        Me.btnMakeAllOnline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMakeAllOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMakeAllOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMakeAllOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMakeAllOnline.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMakeAllOnline.ForeColor = System.Drawing.Color.Black
        Me.btnMakeAllOnline.Location = New System.Drawing.Point(596, 675)
        Me.btnMakeAllOnline.Name = "btnMakeAllOnline"
        Me.btnMakeAllOnline.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMakeAllOnline.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnMakeAllOnline.Size = New System.Drawing.Size(90, 50)
        Me.btnMakeAllOnline.TabIndex = 104
        Me.btnMakeAllOnline.Text = "Make All Online"
        Me.btnMakeAllOnline.UseVisualStyleBackColor = False
        '
        'cbcChamber4
        '
        Me.cbcChamber4.BackColor = System.Drawing.Color.Transparent
        Me.cbcChamber4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cbcChamber4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcChamber4.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.cbcChamber4.HeaderHeight = 28
        Me.cbcChamber4.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.cbcChamber4.HeaderText = "Chamber 4"
        Me.cbcChamber4.HeaderTextColor = System.Drawing.Color.White
        Me.cbcChamber4.HeaderVisible = True
        Me.cbcChamber4.IGCGValue = "OFF"
        Me.cbcChamber4.Location = New System.Drawing.Point(992, 201)
        Me.cbcChamber4.Name = "cbcChamber4"
        Me.cbcChamber4.Size = New System.Drawing.Size(312, 145)
        Me.cbcChamber4.TabIndex = 11
        Me.cbcChamber4.Text = "Chamber 4"
        Me.cbcChamber4.UseBorderStyle = True
        '
        'cbcChamber3
        '
        Me.cbcChamber3.BackColor = System.Drawing.Color.Transparent
        Me.cbcChamber3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cbcChamber3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbcChamber3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcChamber3.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.cbcChamber3.HeaderHeight = 28
        Me.cbcChamber3.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.cbcChamber3.HeaderText = "Chamber 3"
        Me.cbcChamber3.HeaderTextColor = System.Drawing.Color.White
        Me.cbcChamber3.HeaderVisible = True
        Me.cbcChamber3.IGCGValue = "OFF"
        Me.cbcChamber3.Location = New System.Drawing.Point(967, 202)
        Me.cbcChamber3.Name = "cbcChamber3"
        Me.cbcChamber3.Size = New System.Drawing.Size(312, 145)
        Me.cbcChamber3.TabIndex = 3
        Me.cbcChamber3.Text = "Chamber 3"
        Me.cbcChamber3.UseBorderStyle = True
        '
        'cbcChamber5
        '
        Me.cbcChamber5.BackColor = System.Drawing.Color.Transparent
        Me.cbcChamber5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cbcChamber5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcChamber5.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.cbcChamber5.HeaderHeight = 28
        Me.cbcChamber5.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.cbcChamber5.HeaderText = "Chamber 5"
        Me.cbcChamber5.HeaderTextColor = System.Drawing.Color.White
        Me.cbcChamber5.HeaderVisible = True
        Me.cbcChamber5.IGCGValue = "OFF"
        Me.cbcChamber5.Location = New System.Drawing.Point(992, 349)
        Me.cbcChamber5.Name = "cbcChamber5"
        Me.cbcChamber5.Size = New System.Drawing.Size(312, 145)
        Me.cbcChamber5.TabIndex = 11
        Me.cbcChamber5.Text = "Chamber 5"
        Me.cbcChamber5.UseBorderStyle = True
        '
        'cbcChamber1
        '
        Me.cbcChamber1.BackColor = System.Drawing.Color.Transparent
        Me.cbcChamber1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cbcChamber1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbcChamber1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcChamber1.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.cbcChamber1.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.cbcChamber1.HeaderText = "Chamber 1"
        Me.cbcChamber1.HeaderTextColor = System.Drawing.Color.White
        Me.cbcChamber1.HeaderVisible = True
        Me.cbcChamber1.IGCGValue = "OFF"
        Me.cbcChamber1.Location = New System.Drawing.Point(0, 202)
        Me.cbcChamber1.Name = "cbcChamber1"
        Me.cbcChamber1.Size = New System.Drawing.Size(312, 145)
        Me.cbcChamber1.TabIndex = 2
        Me.cbcChamber1.Text = "Chamber 1"
        Me.cbcChamber1.UseBorderStyle = True
        '
        'wccWaferCount
        '
        Me.wccWaferCount.BackColor = System.Drawing.Color.Transparent
        Me.wccWaferCount.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.wccWaferCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.wccWaferCount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wccWaferCount.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.wccWaferCount.HeaderHeight = 28
        Me.wccWaferCount.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.wccWaferCount.HeaderText = "Wafer Count"
        Me.wccWaferCount.HeaderTextColor = System.Drawing.Color.Black
        Me.wccWaferCount.HeaderVisible = True
        Me.wccWaferCount.Location = New System.Drawing.Point(979, 714)
        Me.wccWaferCount.Name = "wccWaferCount"
        Me.wccWaferCount.Size = New System.Drawing.Size(120, 62)
        Me.wccWaferCount.TabIndex = 7
        Me.wccWaferCount.Text = "Wafer Count"
        Me.wccWaferCount.UseBorderStyle = True
        Me.wccWaferCount.Visible = False
        '
        'cbcChamber2
        '
        Me.cbcChamber2.BackColor = System.Drawing.Color.Transparent
        Me.cbcChamber2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cbcChamber2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbcChamber2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcChamber2.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.cbcChamber2.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.cbcChamber2.HeaderText = "Chamber 2"
        Me.cbcChamber2.HeaderTextColor = System.Drawing.Color.White
        Me.cbcChamber2.HeaderVisible = True
        Me.cbcChamber2.IGCGValue = "OFF"
        Me.cbcChamber2.Location = New System.Drawing.Point(0, 55)
        Me.cbcChamber2.Name = "cbcChamber2"
        Me.cbcChamber2.Size = New System.Drawing.Size(312, 145)
        Me.cbcChamber2.TabIndex = 2
        Me.cbcChamber2.Text = "Chamber 2"
        Me.cbcChamber2.UseBorderStyle = True
        '
        'Robot_Body
        '
        Me.Robot_Body.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.Robot_Body.BackColor = System.Drawing.Color.Transparent
        Me.Robot_Body.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Robot_Body.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Robot_Body.InScreen = AVPControls.AVPDataLib.AVPScreens.ProcessScreen
        Me.Robot_Body.Location = New System.Drawing.Point(555, 269)
        Me.Robot_Body.Name = "Robot_Body"
        Me.Robot_Body.Size = New System.Drawing.Size(170, 202)
        Me.Robot_Body.TabIndex = 157
        '
        'CX_PM1
        '
        Me.CX_PM1.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM1.BackgroundImage = CType(resources.GetObject("CX_PM1.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM1.DockPosition = AVP_Robot_Project.PMControl.ChamberDockPositions.PM1
        Me.CX_PM1.LabelDisconnect_Location = New System.Drawing.Point(10, 40)
        Me.CX_PM1.Location = New System.Drawing.Point(352, 261)
        Me.CX_PM1.Name = "CX_PM1"
        Me.CX_PM1.ShowWafer_Border_ToEdit = True
        Me.CX_PM1.ShutterLocation = New System.Drawing.Point(28, 292)
        Me.CX_PM1.Size = New System.Drawing.Size(187, 187)
        Me.CX_PM1.TabIndex = 154
        Me.CX_PM1.TotalTargetInstalled = CType(0, Short)
        Me.CX_PM1.WaferID = ""
        Me.CX_PM1.WaferLocation = New System.Drawing.Point(123, 76)
        '
        'CX_PM2
        '
        Me.CX_PM2.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM2.BackgroundImage = CType(resources.GetObject("CX_PM2.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM2.DockPosition = AVP_Robot_Project.PMControl.ChamberDockPositions.PM2
        Me.CX_PM2.LabelDisconnect_Location = New System.Drawing.Point(20, 63)
        Me.CX_PM2.Location = New System.Drawing.Point(546, 66)
        Me.CX_PM2.Name = "CX_PM2"
        Me.CX_PM2.ShowWafer_Border_ToEdit = True
        Me.CX_PM2.ShutterLocation = New System.Drawing.Point(28, 292)
        Me.CX_PM2.Size = New System.Drawing.Size(187, 187)
        Me.CX_PM2.TabIndex = 154
        Me.CX_PM2.TotalTargetInstalled = CType(0, Short)
        Me.CX_PM2.WaferID = ""
        Me.CX_PM2.WaferLocation = New System.Drawing.Point(76, 123)
        '
        'CX_PM3
        '
        Me.CX_PM3.BackColor = System.Drawing.Color.Transparent
        Me.CX_PM3.BackgroundImage = CType(resources.GetObject("CX_PM3.BackgroundImage"), System.Drawing.Image)
        Me.CX_PM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CX_PM3.DockPosition = AVP_Robot_Project.PMControl.ChamberDockPositions.PM3
        Me.CX_PM3.LabelDisconnect_Location = New System.Drawing.Point(2, 40)
        Me.CX_PM3.Location = New System.Drawing.Point(740, 261)
        Me.CX_PM3.Name = "CX_PM3"
        Me.CX_PM3.ShowWafer_Border_ToEdit = True
        Me.CX_PM3.ShutterLocation = New System.Drawing.Point(28, 292)
        Me.CX_PM3.Size = New System.Drawing.Size(187, 187)
        Me.CX_PM3.TabIndex = 154
        Me.CX_PM3.TotalTargetInstalled = CType(0, Short)
        Me.CX_PM3.WaferID = ""
        Me.CX_PM3.WaferLocation = New System.Drawing.Point(29, 76)
        '
        'LLALeg
        '
        Me.LLALeg.BackColor = System.Drawing.Color.Transparent
        Me.LLALeg.BackgroundImage = CType(resources.GetObject("LLALeg.BackgroundImage"), System.Drawing.Image)
        Me.LLALeg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.LLALeg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LLALeg.Location = New System.Drawing.Point(597, 488)
        Me.LLALeg.Name = "LLALeg"
        Me.LLALeg.Size = New System.Drawing.Size(87, 59)
        Me.LLALeg.TabIndex = 155
        '
        'picBackGround
        '
        Me.picBackGround.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picBackGround.Image = Global.AVP_Robot_Project.My.Resources.Resources.BackGround
        Me.picBackGround.Location = New System.Drawing.Point(0, 0)
        Me.picBackGround.Name = "picBackGround"
        Me.picBackGround.Size = New System.Drawing.Size(1272, 756)
        Me.picBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBackGround.TabIndex = 98
        Me.picBackGround.TabStop = False
        '
        'btnClearAllWafer
        '
        Me.btnClearAllWafer.BackColor = System.Drawing.Color.Transparent
        Me.btnClearAllWafer.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClearAllWafer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearAllWafer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearAllWafer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearAllWafer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAllWafer.ForeColor = System.Drawing.Color.Black
        Me.btnClearAllWafer.Location = New System.Drawing.Point(596, 726)
        Me.btnClearAllWafer.Name = "btnClearAllWafer"
        Me.btnClearAllWafer.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClearAllWafer.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnClearAllWafer.Size = New System.Drawing.Size(90, 50)
        Me.btnClearAllWafer.TabIndex = 159
        Me.btnClearAllWafer.Text = "Return All Wafers"
        Me.btnClearAllWafer.UseVisualStyleBackColor = False
        '
        'lblFlashing
        '
        Me.lblFlashing.Color1 = System.Drawing.Color.Yellow
        Me.lblFlashing.Color2 = System.Drawing.Color.Yellow
        Me.lblFlashing.FlashingInterval = 2000
        Me.lblFlashing.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlashing.ForeColor = System.Drawing.Color.Yellow
        Me.lblFlashing.Location = New System.Drawing.Point(318, 41)
        Me.lblFlashing.Name = "lblFlashing"
        Me.lblFlashing.Size = New System.Drawing.Size(247, 22)
        Me.lblFlashing.TabIndex = 247
        Me.lblFlashing.Text = "Flashing Label"
        Me.lblFlashing.Visible = False
        '
        'lblPM2MotionStatus
        '
        Me.lblPM2MotionStatus.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM2MotionStatus.ForeColor = System.Drawing.Color.Gold
        Me.lblPM2MotionStatus.Location = New System.Drawing.Point(597, 48)
        Me.lblPM2MotionStatus.Name = "lblPM2MotionStatus"
        Me.lblPM2MotionStatus.Size = New System.Drawing.Size(136, 15)
        Me.lblPM2MotionStatus.TabIndex = 305
        Me.lblPM2MotionStatus.Text = "PM2: Homing All Axis"
        Me.lblPM2MotionStatus.Visible = False
        '
        'lblPM1MotionStatus
        '
        Me.lblPM1MotionStatus.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM1MotionStatus.ForeColor = System.Drawing.Color.Gold
        Me.lblPM1MotionStatus.Location = New System.Drawing.Point(349, 242)
        Me.lblPM1MotionStatus.Name = "lblPM1MotionStatus"
        Me.lblPM1MotionStatus.Size = New System.Drawing.Size(136, 15)
        Me.lblPM1MotionStatus.TabIndex = 304
        Me.lblPM1MotionStatus.Text = "PM1: Homing All Axis"
        Me.lblPM1MotionStatus.Visible = False
        '
        'lblPM3MotionStatus
        '
        Me.lblPM3MotionStatus.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.lblPM3MotionStatus.ForeColor = System.Drawing.Color.Gold
        Me.lblPM3MotionStatus.Location = New System.Drawing.Point(791, 242)
        Me.lblPM3MotionStatus.Name = "lblPM3MotionStatus"
        Me.lblPM3MotionStatus.Size = New System.Drawing.Size(136, 15)
        Me.lblPM3MotionStatus.TabIndex = 306
        Me.lblPM3MotionStatus.Text = "PM3: Homing All Axis"
        Me.lblPM3MotionStatus.Visible = False
        '
        'lblLoadLockADoor
        '
        Me.lblLoadLockADoor.Color1 = System.Drawing.Color.Yellow
        Me.lblLoadLockADoor.Color2 = System.Drawing.Color.Yellow
        Me.lblLoadLockADoor.FlashingInterval = 2000
        Me.lblLoadLockADoor.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadLockADoor.ForeColor = System.Drawing.Color.Yellow
        Me.lblLoadLockADoor.Location = New System.Drawing.Point(507, 528)
        Me.lblLoadLockADoor.Name = "lblLoadLockADoor"
        Me.lblLoadLockADoor.Size = New System.Drawing.Size(83, 22)
        Me.lblLoadLockADoor.TabIndex = 307
        Me.lblLoadLockADoor.Text = "Door Open"
        Me.lblLoadLockADoor.Visible = False
        '
        'MesaValveLLA
        '
        Me.MesaValveLLA.BackgroundImage = CType(resources.GetObject("MesaValveLLA.BackgroundImage"), System.Drawing.Image)
        Me.MesaValveLLA.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.LLA
        Me.MesaValveLLA.Location = New System.Drawing.Point(598, 437)
        Me.MesaValveLLA.Name = "MesaValveLLA"
        Me.MesaValveLLA.Size = New System.Drawing.Size(84, 84)
        Me.MesaValveLLA.TabIndex = 308
        '
        'MesaValvePM1
        '
        Me.MesaValvePM1.BackgroundImage = CType(resources.GetObject("MesaValvePM1.BackgroundImage"), System.Drawing.Image)
        Me.MesaValvePM1.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.PM1
        Me.MesaValvePM1.Location = New System.Drawing.Point(505, 311)
        Me.MesaValvePM1.Name = "MesaValvePM1"
        Me.MesaValvePM1.Size = New System.Drawing.Size(84, 84)
        Me.MesaValvePM1.TabIndex = 309
        '
        'MesaValvePM2
        '
        Me.MesaValvePM2.BackgroundImage = CType(resources.GetObject("MesaValvePM2.BackgroundImage"), System.Drawing.Image)
        Me.MesaValvePM2.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.PM2
        Me.MesaValvePM2.Location = New System.Drawing.Point(598, 219)
        Me.MesaValvePM2.Name = "MesaValvePM2"
        Me.MesaValvePM2.Size = New System.Drawing.Size(84, 84)
        Me.MesaValvePM2.TabIndex = 310
        '
        'MesaValvePM3
        '
        Me.MesaValvePM3.BackgroundImage = CType(resources.GetObject("MesaValvePM3.BackgroundImage"), System.Drawing.Image)
        Me.MesaValvePM3.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.PM3
        Me.MesaValvePM3.Location = New System.Drawing.Point(690, 312)
        Me.MesaValvePM3.Name = "MesaValvePM3"
        Me.MesaValvePM3.Size = New System.Drawing.Size(84, 84)
        Me.MesaValvePM3.TabIndex = 311
        '
        'RobotHand
        '
        Me.RobotHand.ArmExtendAngle = 10.0!
        Me.RobotHand.ArmHeight = 3.025023!
        Me.RobotHand.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.RobotHand.BackColor = System.Drawing.SystemColors.ControlDark
        Me.RobotHand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RobotHand.Location = New System.Drawing.Point(442, 157)
        Me.RobotHand.Name = "RobotHand"
        Me.RobotHand.Size = New System.Drawing.Size(396, 396)
        Me.RobotHand.TabIndex = 313
        Me.RobotHand.UndefinedStationType = AVPControls.AVPDataLib.AVPChamberTypes.PVD4
        Me.RobotHand.WaferDiameter = 35
        '
        'lblAlignerEECM
        '
        Me.lblAlignerEECM.AutoSize = True
        Me.lblAlignerEECM.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlignerEECM.ForeColor = System.Drawing.Color.Yellow
        Me.lblAlignerEECM.Location = New System.Drawing.Point(509, 494)
        Me.lblAlignerEECM.Name = "lblAlignerEECM"
        Me.lblAlignerEECM.Size = New System.Drawing.Size(41, 15)
        Me.lblAlignerEECM.TabIndex = 315
        Me.lblAlignerEECM.Text = "Ecc M."
        Me.lblAlignerEECM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAlignerEECM.Visible = False
        '
        'lblAlignerEECA
        '
        Me.lblAlignerEECA.AutoSize = True
        Me.lblAlignerEECA.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlignerEECA.ForeColor = System.Drawing.Color.Yellow
        Me.lblAlignerEECA.Location = New System.Drawing.Point(509, 475)
        Me.lblAlignerEECA.Name = "lblAlignerEECA"
        Me.lblAlignerEECA.Size = New System.Drawing.Size(37, 15)
        Me.lblAlignerEECA.TabIndex = 314
        Me.lblAlignerEECA.Text = "Ecc A."
        Me.lblAlignerEECA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAlignerEECA.Visible = False
        '
        'lblAlignAngle
        '
        Me.lblAlignAngle.AutoSize = True
        Me.lblAlignAngle.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlignAngle.ForeColor = System.Drawing.Color.Yellow
        Me.lblAlignAngle.Location = New System.Drawing.Point(509, 456)
        Me.lblAlignAngle.Name = "lblAlignAngle"
        Me.lblAlignAngle.Size = New System.Drawing.Size(36, 15)
        Me.lblAlignAngle.TabIndex = 315
        Me.lblAlignAngle.Text = "Align"
        Me.lblAlignAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAlignAngle.Visible = False
        '
        'lblComunicationLED_TurboTM
        '
        Me.lblComunicationLED_TurboTM.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED_TurboTM.Location = New System.Drawing.Point(835, 511)
        Me.lblComunicationLED_TurboTM.Name = "lblComunicationLED_TurboTM"
        Me.lblComunicationLED_TurboTM.Size = New System.Drawing.Size(7, 11)
        Me.lblComunicationLED_TurboTM.TabIndex = 317
        Me.lblComunicationLED_TurboTM.Visible = False
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
        Me.btnTurboTM.Location = New System.Drawing.Point(716, 250)
        Me.btnTurboTM.MessageBoxText = Nothing
        Me.btnTurboTM.Name = "btnTurboTM"
        Me.btnTurboTM.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnTurboTM.OffText = "OFF"
        Me.btnTurboTM.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTurboTM.OnText = "ON"
        Me.btnTurboTM.Size = New System.Drawing.Size(38, 20)
        Me.btnTurboTM.TabIndex = 316
        Me.btnTurboTM.Text = "OFF"
        Me.btnTurboTM.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTurboTM.UnKnownText = "Ramp"
        Me.btnTurboTM.UseClickedEventInForm = True
        Me.btnTurboTM.UseVisualStyleBackColor = False
        Me.btnTurboTM.ValueToBeSend = ""
        '
        'PumpTM
        '
        Me.PumpTM.BackgroundImage = CType(resources.GetObject("PumpTM.BackgroundImage"), System.Drawing.Image)
        Me.PumpTM.Location = New System.Drawing.Point(705, 225)
        Me.PumpTM.Name = "PumpTM"
        Me.PumpTM.Size = New System.Drawing.Size(67, 67)
        Me.PumpTM.TabIndex = 319
        '
        'HivacValveTM
        '
        Me.HivacValveTM.BackgroundImage = CType(resources.GetObject("HivacValveTM.BackgroundImage"), System.Drawing.Image)
        Me.HivacValveTM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HivacValveTM.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.HivacTM
        Me.HivacValveTM.Location = New System.Drawing.Point(689, 258)
        Me.HivacValveTM.Name = "HivacValveTM"
        Me.HivacValveTM.Size = New System.Drawing.Size(50, 50)
        Me.HivacValveTM.TabIndex = 318
        '
        'HivacValveLLA
        '
        Me.HivacValveLLA.BackgroundImage = CType(resources.GetObject("HivacValveLLA.BackgroundImage"), System.Drawing.Image)
        Me.HivacValveLLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HivacValveLLA.DockPosition = AVP_Robot_Project.SlitValve.SlitValvePositions.HivacLLA
        Me.HivacValveLLA.Location = New System.Drawing.Point(665, 492)
        Me.HivacValveLLA.Name = "HivacValveLLA"
        Me.HivacValveLLA.Size = New System.Drawing.Size(50, 50)
        Me.HivacValveLLA.TabIndex = 322
        '
        'lblComunicationLED_TurboLLA
        '
        Me.lblComunicationLED_TurboLLA.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED_TurboLLA.Location = New System.Drawing.Point(822, 511)
        Me.lblComunicationLED_TurboLLA.Name = "lblComunicationLED_TurboLLA"
        Me.lblComunicationLED_TurboLLA.Size = New System.Drawing.Size(7, 11)
        Me.lblComunicationLED_TurboLLA.TabIndex = 321
        Me.lblComunicationLED_TurboLLA.Visible = False
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
        Me.btnTurboLLA.Location = New System.Drawing.Point(700, 508)
        Me.btnTurboLLA.MessageBoxText = Nothing
        Me.btnTurboLLA.Name = "btnTurboLLA"
        Me.btnTurboLLA.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnTurboLLA.OffText = "OFF"
        Me.btnTurboLLA.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTurboLLA.OnText = "ON"
        Me.btnTurboLLA.Size = New System.Drawing.Size(38, 20)
        Me.btnTurboLLA.TabIndex = 320
        Me.btnTurboLLA.Text = "OFF"
        Me.btnTurboLLA.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTurboLLA.UnKnownText = "Ramp"
        Me.btnTurboLLA.UseClickedEventInForm = True
        Me.btnTurboLLA.UseVisualStyleBackColor = False
        Me.btnTurboLLA.ValueToBeSend = ""
        '
        'PumpLLA
        '
        Me.PumpLLA.BackgroundImage = CType(resources.GetObject("PumpLLA.BackgroundImage"), System.Drawing.Image)
        Me.PumpLLA.DockPosition = AVP_Robot_Project.PumpChamber.PumpDockPositions.LoadLock
        Me.PumpLLA.Location = New System.Drawing.Point(690, 483)
        Me.PumpLLA.Name = "PumpLLA"
        Me.PumpLLA.Size = New System.Drawing.Size(67, 67)
        Me.PumpLLA.TabIndex = 323
        '
        'runNoControl
        '
        Me.runNoControl.BackColor = System.Drawing.Color.Transparent
        Me.runNoControl.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.runNoControl.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.runNoControl.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.runNoControl.HeaderText = "Run No."
        Me.runNoControl.HeaderTextColor = System.Drawing.Color.Black
        Me.runNoControl.HeaderVisible = True
        Me.runNoControl.Location = New System.Drawing.Point(581, 611)
        Me.runNoControl.Name = "runNoControl"
        Me.runNoControl.Size = New System.Drawing.Size(120, 62)
        Me.runNoControl.TabIndex = 316
        Me.runNoControl.Text = "Run No."
        Me.runNoControl.UseBorderStyle = True
        '
        'ctrTMTurboCom
        '
        Me.ctrTMTurboCom.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.ctrTMTurboCom.BackColor = System.Drawing.Color.DimGray
        Me.ctrTMTurboCom.Location = New System.Drawing.Point(735, 231)
        Me.ctrTMTurboCom.Name = "ctrTMTurboCom"
        Me.ctrTMTurboCom.Size = New System.Drawing.Size(15, 15)
        Me.ctrTMTurboCom.Status = AVPControls.AVPDataLib.DisplayStatus.[Error]
        Me.ctrTMTurboCom.TabIndex = 372
        '
        'ctrLLATurboCom
        '
        Me.ctrLLATurboCom.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.ctrLLATurboCom.BackColor = System.Drawing.Color.DimGray
        Me.ctrLLATurboCom.Location = New System.Drawing.Point(735, 493)
        Me.ctrLLATurboCom.Name = "ctrLLATurboCom"
        Me.ctrLLATurboCom.Size = New System.Drawing.Size(15, 15)
        Me.ctrLLATurboCom.Status = AVPControls.AVPDataLib.DisplayStatus.[Error]
        Me.ctrLLATurboCom.TabIndex = 373
        '
        'ProcessPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.RobotHand)
        Me.Controls.Add(Me.ctrLLATurboCom)
        Me.Controls.Add(Me.ctrTMTurboCom)
        Me.Controls.Add(Me.runNoControl)
        Me.Controls.Add(Me.HivacValveLLA)
        Me.Controls.Add(Me.lblComunicationLED_TurboLLA)
        Me.Controls.Add(Me.btnTurboLLA)
        Me.Controls.Add(Me.PumpLLA)
        Me.Controls.Add(Me.lblComunicationLED_TurboTM)
        Me.Controls.Add(Me.lblAlignAngle)
        Me.Controls.Add(Me.HivacValveTM)
        Me.Controls.Add(Me.btnTurboTM)
        Me.Controls.Add(Me.lblAlignerEECM)
        Me.Controls.Add(Me.PumpTM)
        Me.Controls.Add(Me.lblAlignerEECA)
        Me.Controls.Add(Me.LLALeg)
        Me.Controls.Add(Me.MesaValvePM2)
        Me.Controls.Add(Me.MesaValvePM3)
        Me.Controls.Add(Me.MesaValvePM1)
        Me.Controls.Add(Me.MesaValveLLA)
        Me.Controls.Add(Me.lblPM1MotionStatus)
        Me.Controls.Add(Me.lblPM3MotionStatus)
        Me.Controls.Add(Me.lblLoadLockADoor)
        Me.Controls.Add(Me.lblPM2MotionStatus)
        Me.Controls.Add(Me.lblFlashing)
        Me.Controls.Add(Me.lblStatusText)
        Me.Controls.Add(Me.TMCtl)
        Me.Controls.Add(Me.TransparentImageAligner)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClearAllWafer)
        Me.Controls.Add(Me.btnMakeAllOnline)
        Me.Controls.Add(Me.awcAligner)
        Me.Controls.Add(Me.cbcChamber3)
        Me.Controls.Add(Me.cbcChamber1)
        Me.Controls.Add(Me.lpcLoadLockA)
        Me.Controls.Add(Me.cbcChamber2)
        Me.Controls.Add(Me.lblPM1MotionInitialize)
        Me.Controls.Add(Me.Robot_Body)
        Me.Controls.Add(Me.wccWaferCount)
        Me.Controls.Add(Me.CX_PM2)
        Me.Controls.Add(Me.lblPM2MotionInitialize)
        Me.Controls.Add(Me.CX_PM1)
        Me.Controls.Add(Me.lblPM3MotionInitialize)
        Me.Controls.Add(Me.CX_PM3)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ProcessPanel"
        Me.Size = New System.Drawing.Size(1280, 800)
        CType(Me.awcAligner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsChamber.ResumeLayout(False)
        CType(Me.Robot_Body, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBackGround, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RobotHand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ctrTMTurboCom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ctrLLATurboCom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbcChamber1 As AVP_Robot_Project.ChamberControl
    Friend WithEvents cbcChamber3 As AVP_Robot_Project.ChamberControl
    Friend WithEvents wccWaferCount As AVP_Robot_Project.WaferCountControl
    Friend WithEvents cbcChamber5 As AVP_Robot_Project.ChamberControl
    Friend WithEvents awcAligner As AVPControls.AVPAlignerControl
    Friend WithEvents cbcChamber2 As AVP_Robot_Project.ChamberControl
    Friend WithEvents cbcChamber4 As AVP_Robot_Project.ChamberControl
    Friend WithEvents lblStatusText As System.Windows.Forms.Label
    Friend WithEvents picBackGround As System.Windows.Forms.PictureBox
    Friend WithEvents cmsChamber As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResume As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransparentImageAligner As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents btnMakeAllOnline As AVPControls.AVPButton
    Friend WithEvents lpcLoadLockA As AVP_Robot_Project.LockProcessControl
    Friend WithEvents mnuReturnNow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TMCtl As AVP_Robot_Project.TMControl
    Friend WithEvents CX_PM1 As AVP_Robot_Project.PMControl
    Friend WithEvents CX_PM2 As AVP_Robot_Project.PMControl
    Friend WithEvents CX_PM3 As AVP_Robot_Project.PMControl
    Friend WithEvents LLALeg As AVP_Robot_Project.LoadLockLeg
    Friend WithEvents Robot_Body As AVPControls.RobotBodyControl
    Friend WithEvents btnClearAllWafer As AVPControls.AVPButton
    Friend WithEvents lblFlashing As AVPControls.FlashingLabel
    Friend WithEvents lblPM1MotionInitialize As System.Windows.Forms.Label
    Friend WithEvents lblPM2MotionInitialize As System.Windows.Forms.Label
    Friend WithEvents lblPM3MotionInitialize As System.Windows.Forms.Label
    Friend WithEvents lblPM2MotionStatus As System.Windows.Forms.Label
    Friend WithEvents lblPM1MotionStatus As System.Windows.Forms.Label
    Friend WithEvents lblPM3MotionStatus As System.Windows.Forms.Label
    Friend WithEvents lblLoadLockADoor As AVPControls.FlashingLabel
    Friend WithEvents MesaValveLLA As AVP_Robot_Project.SlitValve
    Friend WithEvents MesaValvePM1 As AVP_Robot_Project.SlitValve
    Friend WithEvents MesaValvePM2 As AVP_Robot_Project.SlitValve
    Friend WithEvents MesaValvePM3 As AVP_Robot_Project.SlitValve
    Friend WithEvents RobotHand As AVPControls.RobotArmControl
    Friend WithEvents lblAlignerEECM As System.Windows.Forms.Label
    Friend WithEvents lblAlignerEECA As System.Windows.Forms.Label
    Friend WithEvents lblAlignAngle As System.Windows.Forms.Label
    Friend WithEvents lblComunicationLED_TurboTM As System.Windows.Forms.Label
    Friend WithEvents btnTurboTM As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents PumpTM As AVP_Robot_Project.PumpChamber
    Friend WithEvents HivacValveTM As AVP_Robot_Project.SlitValve
    Friend WithEvents HivacValveLLA As AVP_Robot_Project.SlitValve
    Friend WithEvents lblComunicationLED_TurboLLA As System.Windows.Forms.Label
    Friend WithEvents btnTurboLLA As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents PumpLLA As AVP_Robot_Project.PumpChamber
    Friend WithEvents runNoControl As AVP_Robot_Project.RunNoControl
    Friend WithEvents ctrTMTurboCom As AVPControls.LEDControl
    Friend WithEvents ctrLLATurboCom As AVPControls.LEDControl
End Class
