<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AVPRobotMain
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AVPRobotMain))
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.pnlCenter = New System.Windows.Forms.Panel
        Me.tabMain = New System.Windows.Forms.CustomTabControl
        Me.tabPM1 = New System.Windows.Forms.TabPage
        Me.tabPM2 = New System.Windows.Forms.TabPage
        Me.tabPM3 = New System.Windows.Forms.TabPage
        Me.tabTM = New System.Windows.Forms.TabPage
        Me.tabCycleATM = New System.Windows.Forms.TabPage
        Me.tabDiag = New System.Windows.Forms.TabPage
        Me.tabIO = New System.Windows.Forms.TabPage
        Me.tabSecsGem = New System.Windows.Forms.TabPage
        Me.tabEditor = New System.Windows.Forms.CustomTabControl
        Me.tabRecipe = New System.Windows.Forms.TabPage
        Me.tabWaferFlow = New System.Windows.Forms.TabPage
        Me.tabSequence = New System.Windows.Forms.TabPage
        Me.tabDataLog = New System.Windows.Forms.CustomTabControl
        Me.tabDTLog = New System.Windows.Forms.TabPage
        Me.tabWR = New System.Windows.Forms.TabPage
        Me.tabAlarmStatistic = New System.Windows.Forms.TabPage
        Me.TabLotDatalog = New System.Windows.Forms.TabPage
        Me.tabSetup = New System.Windows.Forms.CustomTabControl
        Me.tabSystem = New System.Windows.Forms.TabPage
        Me.tabUserSetup = New System.Windows.Forms.TabPage
        Me.pnlPMConnection = New AVP_Robot_Project.ConnectPMPanel
        Me.PnlHeader = New AVPControls.AVPPanel
        Me.AVPLoginPanel = New AVPControls.AppLoginPanel
        Me.AVPDatetimePanel = New AVPControls.AppDatetimePanel
        Me.AVPCommunicationPanel = New AVPControls.AppHostCommunicationPanel
        Me.AVPInfoPanel = New AVPControls.AppInfoPanel
        Me.pnlAlarm = New AVPControls.AVPPanel
        Me.pnlAlarmLight = New AVPControls.AVPPanel
        Me.aplAlarm = New AVP_Robot_Project.AlarmPanel
        Me.btnClearAllAlarm = New AVP_Robot_Project.ButtonIGCGControl
        Me.pnlAlarmStatus = New AVPControls.AVPPanel
        Me.StackLight = New AVPControls.StackLightControl
        Me.pnlRedLight = New AVP_Robot_Project.YellowLightPanel
        Me.pnlBlueLight = New AVP_Robot_Project.YellowLightPanel
        Me.pnlGreenLight = New AVP_Robot_Project.YellowLightPanel
        Me.pnlYellowLight = New AVP_Robot_Project.YellowLightPanel
        Me.AVPLogo = New AVPControls.AppLogoPanel
        Me.lblAlarmTextMain = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PnlBottom = New AVPControls.AVPPanel
        Me.btnMaintenance = New AVPControls.AVPButton
        Me.btnProcess = New AVPControls.AVPButton
        Me.btnEditor = New AVPControls.AVPButton
        Me.btnSetup = New AVPControls.AVPButton
        Me.btnDataLog = New AVPControls.AVPButton
        Me.tmrTopRightClock = New System.Windows.Forms.Timer(Me.components)
        Me.cmsSetup = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuUserSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSystem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRecipe = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSequence = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuWaferFlow = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsEditor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImgLisTooltipMachine = New System.Windows.Forms.ImageList(Me.components)
        Me.tabIODeviceNet = New System.Windows.Forms.TabPage
        Me.pnlMain.SuspendLayout()
        Me.pnlCenter.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabEditor.SuspendLayout()
        Me.tabDataLog.SuspendLayout()
        Me.tabSetup.SuspendLayout()
        Me.PnlHeader.SuspendLayout()
        Me.pnlAlarm.SuspendLayout()
        Me.pnlAlarmLight.SuspendLayout()
        Me.pnlAlarmStatus.SuspendLayout()
        CType(Me.StackLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBottom.SuspendLayout()
        Me.cmsSetup.SuspendLayout()
        Me.cmsEditor.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlCenter)
        Me.pnlMain.Controls.Add(Me.PnlHeader)
        Me.pnlMain.Controls.Add(Me.PnlBottom)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1280, 746)
        Me.pnlMain.TabIndex = 3
        '
        'pnlCenter
        '
        Me.pnlCenter.BackColor = System.Drawing.SystemColors.ControlText
        Me.pnlCenter.Controls.Add(Me.tabMain)
        Me.pnlCenter.Controls.Add(Me.tabEditor)
        Me.pnlCenter.Controls.Add(Me.tabDataLog)
        Me.pnlCenter.Controls.Add(Me.tabSetup)
        Me.pnlCenter.Controls.Add(Me.pnlPMConnection)
        Me.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCenter.Location = New System.Drawing.Point(0, 121)
        Me.pnlCenter.Name = "pnlCenter"
        Me.pnlCenter.Size = New System.Drawing.Size(1280, 524)
        Me.pnlCenter.TabIndex = 2
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabPM1)
        Me.tabMain.Controls.Add(Me.tabPM2)
        Me.tabMain.Controls.Add(Me.tabPM3)
        Me.tabMain.Controls.Add(Me.tabTM)
        Me.tabMain.Controls.Add(Me.tabCycleATM)
        Me.tabMain.Controls.Add(Me.tabDiag)
        Me.tabMain.Controls.Add(Me.tabIO)
        Me.tabMain.Controls.Add(Me.tabSecsGem)
        Me.tabMain.Controls.Add(Me.tabIODeviceNet)
        Me.tabMain.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabMain.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabMain.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabMain.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabMain.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabMain.DisplayStyleProvider.FocusTrack = False
        Me.tabMain.DisplayStyleProvider.HotTrack = True
        Me.tabMain.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabMain.DisplayStyleProvider.Opacity = 1.0!
        Me.tabMain.DisplayStyleProvider.Overlap = 0
        Me.tabMain.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabMain.DisplayStyleProvider.Radius = 10
        Me.tabMain.DisplayStyleProvider.ShowTabCloser = False
        Me.tabMain.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabMain.HotTrack = True
        Me.tabMain.Location = New System.Drawing.Point(32, 349)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1013, 134)
        Me.tabMain.TabIndex = 151
        '
        'tabPM1
        '
        Me.tabPM1.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPM1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPM1.Location = New System.Drawing.Point(0, 36)
        Me.tabPM1.Margin = New System.Windows.Forms.Padding(4)
        Me.tabPM1.Name = "tabPM1"
        Me.tabPM1.Size = New System.Drawing.Size(1013, 98)
        Me.tabPM1.TabIndex = 4
        Me.tabPM1.Text = " PM1   "
        Me.tabPM1.UseVisualStyleBackColor = True
        '
        'tabPM2
        '
        Me.tabPM2.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPM2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPM2.Location = New System.Drawing.Point(0, 36)
        Me.tabPM2.Name = "tabPM2"
        Me.tabPM2.Size = New System.Drawing.Size(1013, 98)
        Me.tabPM2.TabIndex = 5
        Me.tabPM2.Text = "  PM2  "
        Me.tabPM2.UseVisualStyleBackColor = True
        '
        'tabPM3
        '
        Me.tabPM3.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPM3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPM3.Location = New System.Drawing.Point(0, 36)
        Me.tabPM3.Name = "tabPM3"
        Me.tabPM3.Size = New System.Drawing.Size(1013, 98)
        Me.tabPM3.TabIndex = 6
        Me.tabPM3.Text = "  PM3  "
        Me.tabPM3.UseVisualStyleBackColor = True
        '
        'tabTM
        '
        Me.tabTM.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabTM.Location = New System.Drawing.Point(0, 36)
        Me.tabTM.Name = "tabTM"
        Me.tabTM.Size = New System.Drawing.Size(1013, 98)
        Me.tabTM.TabIndex = 3
        Me.tabTM.Text = "TM"
        Me.tabTM.UseVisualStyleBackColor = True
        '
        'tabCycleATM
        '
        Me.tabCycleATM.Location = New System.Drawing.Point(0, 36)
        Me.tabCycleATM.Name = "tabCycleATM"
        Me.tabCycleATM.Size = New System.Drawing.Size(1013, 98)
        Me.tabCycleATM.TabIndex = 11
        Me.tabCycleATM.Text = "Cycle ATM "
        Me.tabCycleATM.UseVisualStyleBackColor = True
        '
        'tabDiag
        '
        Me.tabDiag.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabDiag.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDiag.Location = New System.Drawing.Point(0, 36)
        Me.tabDiag.Name = "tabDiag"
        Me.tabDiag.Size = New System.Drawing.Size(1013, 98)
        Me.tabDiag.TabIndex = 0
        Me.tabDiag.Text = "Diag"
        Me.tabDiag.UseVisualStyleBackColor = True
        '
        'tabIO
        '
        Me.tabIO.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabIO.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabIO.Location = New System.Drawing.Point(0, 36)
        Me.tabIO.Name = "tabIO"
        Me.tabIO.Size = New System.Drawing.Size(1013, 98)
        Me.tabIO.TabIndex = 1
        Me.tabIO.Text = "IO"
        Me.tabIO.UseVisualStyleBackColor = True
        '
        'tabSecsGem
        '
        Me.tabSecsGem.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabSecsGem.Location = New System.Drawing.Point(0, 36)
        Me.tabSecsGem.Name = "tabSecsGem"
        Me.tabSecsGem.Padding = New System.Windows.Forms.Padding(2)
        Me.tabSecsGem.Size = New System.Drawing.Size(1013, 98)
        Me.tabSecsGem.TabIndex = 10
        Me.tabSecsGem.Text = "GEM Control"
        Me.tabSecsGem.UseVisualStyleBackColor = True
        '
        'tabEditor
        '
        Me.tabEditor.Controls.Add(Me.tabRecipe)
        Me.tabEditor.Controls.Add(Me.tabWaferFlow)
        Me.tabEditor.Controls.Add(Me.tabSequence)
        Me.tabEditor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabEditor.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabEditor.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabEditor.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlText
        Me.tabEditor.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabEditor.DisplayStyleProvider.FocusTrack = False
        Me.tabEditor.DisplayStyleProvider.HotTrack = True
        Me.tabEditor.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabEditor.DisplayStyleProvider.Opacity = 1.0!
        Me.tabEditor.DisplayStyleProvider.Overlap = 0
        Me.tabEditor.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabEditor.DisplayStyleProvider.Radius = 10
        Me.tabEditor.DisplayStyleProvider.ShowTabCloser = False
        Me.tabEditor.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabEditor.HotTrack = True
        Me.tabEditor.Location = New System.Drawing.Point(369, 209)
        Me.tabEditor.Name = "tabEditor"
        Me.tabEditor.SelectedIndex = 0
        Me.tabEditor.Size = New System.Drawing.Size(444, 134)
        Me.tabEditor.TabIndex = 151
        '
        'tabRecipe
        '
        Me.tabRecipe.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabRecipe.Location = New System.Drawing.Point(0, 36)
        Me.tabRecipe.Name = "tabRecipe"
        Me.tabRecipe.Size = New System.Drawing.Size(444, 98)
        Me.tabRecipe.TabIndex = 0
        Me.tabRecipe.Text = "  Recipe  "
        Me.tabRecipe.UseVisualStyleBackColor = True
        '
        'tabWaferFlow
        '
        Me.tabWaferFlow.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabWaferFlow.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabWaferFlow.Location = New System.Drawing.Point(0, 36)
        Me.tabWaferFlow.Name = "tabWaferFlow"
        Me.tabWaferFlow.Size = New System.Drawing.Size(444, 98)
        Me.tabWaferFlow.TabIndex = 1
        Me.tabWaferFlow.Text = "  Wafer Flow  "
        Me.tabWaferFlow.UseVisualStyleBackColor = True
        '
        'tabSequence
        '
        Me.tabSequence.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabSequence.Location = New System.Drawing.Point(0, 36)
        Me.tabSequence.Name = "tabSequence"
        Me.tabSequence.Size = New System.Drawing.Size(444, 98)
        Me.tabSequence.TabIndex = 2
        Me.tabSequence.Text = "  Sequence  "
        Me.tabSequence.UseVisualStyleBackColor = True
        '
        'tabDataLog
        '
        Me.tabDataLog.Controls.Add(Me.tabDTLog)
        Me.tabDataLog.Controls.Add(Me.tabWR)
        Me.tabDataLog.Controls.Add(Me.tabAlarmStatistic)
        Me.tabDataLog.Controls.Add(Me.TabLotDatalog)
        Me.tabDataLog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabDataLog.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabDataLog.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabDataLog.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlText
        Me.tabDataLog.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabDataLog.DisplayStyleProvider.FocusTrack = False
        Me.tabDataLog.DisplayStyleProvider.HotTrack = True
        Me.tabDataLog.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabDataLog.DisplayStyleProvider.Opacity = 1.0!
        Me.tabDataLog.DisplayStyleProvider.Overlap = 0
        Me.tabDataLog.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabDataLog.DisplayStyleProvider.Radius = 10
        Me.tabDataLog.DisplayStyleProvider.ShowTabCloser = False
        Me.tabDataLog.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDataLog.HotTrack = True
        Me.tabDataLog.Location = New System.Drawing.Point(625, 69)
        Me.tabDataLog.Name = "tabDataLog"
        Me.tabDataLog.SelectedIndex = 0
        Me.tabDataLog.Size = New System.Drawing.Size(625, 134)
        Me.tabDataLog.TabIndex = 151
        '
        'tabDTLog
        '
        Me.tabDTLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabDTLog.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDTLog.Location = New System.Drawing.Point(0, 36)
        Me.tabDTLog.Name = "tabDTLog"
        Me.tabDTLog.Size = New System.Drawing.Size(625, 98)
        Me.tabDTLog.TabIndex = 0
        Me.tabDTLog.Text = "  Data Log  "
        Me.tabDTLog.UseVisualStyleBackColor = True
        '
        'tabWR
        '
        Me.tabWR.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabWR.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabWR.Location = New System.Drawing.Point(0, 36)
        Me.tabWR.Name = "tabWR"
        Me.tabWR.Size = New System.Drawing.Size(625, 98)
        Me.tabWR.TabIndex = 1
        Me.tabWR.Text = "   Wafer Run  "
        Me.tabWR.UseVisualStyleBackColor = True
        '
        'tabAlarmStatistic
        '
        Me.tabAlarmStatistic.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabAlarmStatistic.Location = New System.Drawing.Point(0, 36)
        Me.tabAlarmStatistic.Name = "tabAlarmStatistic"
        Me.tabAlarmStatistic.Size = New System.Drawing.Size(625, 98)
        Me.tabAlarmStatistic.TabIndex = 3
        Me.tabAlarmStatistic.Text = "Pareto Chart"
        Me.tabAlarmStatistic.UseVisualStyleBackColor = True
        '
        'TabLotDatalog
        '
        Me.TabLotDatalog.Cursor = System.Windows.Forms.Cursors.Default
        Me.TabLotDatalog.Location = New System.Drawing.Point(0, 36)
        Me.TabLotDatalog.Name = "TabLotDatalog"
        Me.TabLotDatalog.Size = New System.Drawing.Size(625, 98)
        Me.TabLotDatalog.TabIndex = 2
        Me.TabLotDatalog.Text = "Lot Transcript "
        Me.TabLotDatalog.UseVisualStyleBackColor = True
        '
        'tabSetup
        '
        Me.tabSetup.Controls.Add(Me.tabSystem)
        Me.tabSetup.Controls.Add(Me.tabUserSetup)
        Me.tabSetup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabSetup.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabSetup.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabSetup.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlText
        Me.tabSetup.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabSetup.DisplayStyleProvider.FocusTrack = False
        Me.tabSetup.DisplayStyleProvider.HotTrack = True
        Me.tabSetup.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabSetup.DisplayStyleProvider.Opacity = 1.0!
        Me.tabSetup.DisplayStyleProvider.Overlap = 0
        Me.tabSetup.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabSetup.DisplayStyleProvider.Radius = 10
        Me.tabSetup.DisplayStyleProvider.ShowTabCloser = False
        Me.tabSetup.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSetup.HotTrack = True
        Me.tabSetup.Location = New System.Drawing.Point(165, 69)
        Me.tabSetup.Name = "tabSetup"
        Me.tabSetup.SelectedIndex = 0
        Me.tabSetup.Size = New System.Drawing.Size(340, 134)
        Me.tabSetup.TabIndex = 151
        '
        'tabSystem
        '
        Me.tabSystem.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabSystem.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSystem.Location = New System.Drawing.Point(0, 36)
        Me.tabSystem.Name = "tabSystem"
        Me.tabSystem.Size = New System.Drawing.Size(340, 98)
        Me.tabSystem.TabIndex = 1
        Me.tabSystem.Text = "   System   "
        Me.tabSystem.UseVisualStyleBackColor = True
        '
        'tabUserSetup
        '
        Me.tabUserSetup.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabUserSetup.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabUserSetup.Location = New System.Drawing.Point(0, 36)
        Me.tabUserSetup.Name = "tabUserSetup"
        Me.tabUserSetup.Size = New System.Drawing.Size(340, 98)
        Me.tabUserSetup.TabIndex = 0
        Me.tabUserSetup.Text = "   User Setup   "
        Me.tabUserSetup.UseVisualStyleBackColor = True
        '
        'pnlPMConnection
        '
        Me.pnlPMConnection.BackColor = System.Drawing.Color.Transparent
        Me.pnlPMConnection.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgTopPanel
        Me.pnlPMConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlPMConnection.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlPMConnection.Location = New System.Drawing.Point(1079, 0)
        Me.pnlPMConnection.Name = "pnlPMConnection"
        Me.pnlPMConnection.PM1Visible = False
        Me.pnlPMConnection.PM2Visible = False
        Me.pnlPMConnection.PM3Visible = False
        Me.pnlPMConnection.Size = New System.Drawing.Size(200, 35)
        Me.pnlPMConnection.TabIndex = 150
        '
        'PnlHeader
        '
        Me.PnlHeader.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgTopPanel
        Me.PnlHeader.Controls.Add(Me.AVPLoginPanel)
        Me.PnlHeader.Controls.Add(Me.AVPDatetimePanel)
        Me.PnlHeader.Controls.Add(Me.AVPCommunicationPanel)
        Me.PnlHeader.Controls.Add(Me.AVPInfoPanel)
        Me.PnlHeader.Controls.Add(Me.pnlAlarm)
        Me.PnlHeader.Controls.Add(Me.AVPLogo)
        Me.PnlHeader.Controls.Add(Me.lblAlarmTextMain)
        Me.PnlHeader.Controls.Add(Me.PictureBox3)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(1280, 121)
        Me.PnlHeader.TabIndex = 0
        '
        'AVPLoginPanel
        '
        Me.AVPLoginPanel.BackColor = System.Drawing.Color.Transparent
        Me.AVPLoginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AVPLoginPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AVPLoginPanel.Location = New System.Drawing.Point(798, 6)
        Me.AVPLoginPanel.MaximumSize = New System.Drawing.Size(356, 76)
        Me.AVPLoginPanel.MinimumSize = New System.Drawing.Size(356, 76)
        Me.AVPLoginPanel.Name = "AVPLoginPanel"
        Me.AVPLoginPanel.Size = New System.Drawing.Size(356, 76)
        Me.AVPLoginPanel.TabIndex = 160
        '
        'AVPDatetimePanel
        '
        Me.AVPDatetimePanel.BackColor = System.Drawing.Color.Transparent
        Me.AVPDatetimePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AVPDatetimePanel.Date = ""
        Me.AVPDatetimePanel.Location = New System.Drawing.Point(589, 6)
        Me.AVPDatetimePanel.MaximumSize = New System.Drawing.Size(207, 76)
        Me.AVPDatetimePanel.MinimumSize = New System.Drawing.Size(207, 76)
        Me.AVPDatetimePanel.Name = "AVPDatetimePanel"
        Me.AVPDatetimePanel.Size = New System.Drawing.Size(207, 76)
        Me.AVPDatetimePanel.TabIndex = 159
        Me.AVPDatetimePanel.Time = ""
        '
        'AVPCommunicationPanel
        '
        Me.AVPCommunicationPanel.BackColor = System.Drawing.Color.Transparent
        Me.AVPCommunicationPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AVPCommunicationPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AVPCommunicationPanel.Location = New System.Drawing.Point(380, 6)
        Me.AVPCommunicationPanel.MaximumSize = New System.Drawing.Size(207, 76)
        Me.AVPCommunicationPanel.MinimumSize = New System.Drawing.Size(207, 76)
        Me.AVPCommunicationPanel.Name = "AVPCommunicationPanel"
        Me.AVPCommunicationPanel.Size = New System.Drawing.Size(207, 76)
        Me.AVPCommunicationPanel.TabIndex = 158
        '
        'AVPInfoPanel
        '
        Me.AVPInfoPanel.BackColor = System.Drawing.Color.Transparent
        Me.AVPInfoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AVPInfoPanel.Location = New System.Drawing.Point(171, 6)
        Me.AVPInfoPanel.MaximumSize = New System.Drawing.Size(207, 76)
        Me.AVPInfoPanel.MinimumSize = New System.Drawing.Size(207, 76)
        Me.AVPInfoPanel.Name = "AVPInfoPanel"
        Me.AVPInfoPanel.Size = New System.Drawing.Size(207, 76)
        Me.AVPInfoPanel.TabIndex = 157
        '
        'pnlAlarm
        '
        Me.pnlAlarm.BackColor = System.Drawing.Color.Transparent
        Me.pnlAlarm.Controls.Add(Me.pnlAlarmLight)
        Me.pnlAlarm.Controls.Add(Me.pnlAlarmStatus)
        Me.pnlAlarm.Location = New System.Drawing.Point(1158, 8)
        Me.pnlAlarm.Name = "pnlAlarm"
        Me.pnlAlarm.Size = New System.Drawing.Size(120, 105)
        Me.pnlAlarm.TabIndex = 156
        '
        'pnlAlarmLight
        '
        Me.pnlAlarmLight.Controls.Add(Me.aplAlarm)
        Me.pnlAlarmLight.Controls.Add(Me.btnClearAllAlarm)
        Me.pnlAlarmLight.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAlarmLight.EnableFormLevelDoubleBuffering = True
        Me.pnlAlarmLight.Location = New System.Drawing.Point(0, 0)
        Me.pnlAlarmLight.Name = "pnlAlarmLight"
        Me.pnlAlarmLight.Size = New System.Drawing.Size(71, 105)
        Me.pnlAlarmLight.TabIndex = 151
        '
        'aplAlarm
        '
        Me.aplAlarm.AlarmImage = Global.AVP_Robot_Project.My.Resources.Resources.BgAlarmOn
        Me.aplAlarm.BackColor = System.Drawing.Color.Transparent
        Me.aplAlarm.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgAlarmOff
        Me.aplAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.aplAlarm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.aplAlarm.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aplAlarm.Location = New System.Drawing.Point(0, 0)
        Me.aplAlarm.Name = "aplAlarm"
        Me.aplAlarm.NormalImage = Global.AVP_Robot_Project.My.Resources.Resources.BgAlarmOff
        Me.aplAlarm.Size = New System.Drawing.Size(70, 70)
        Me.aplAlarm.TabIndex = 0
        '
        'btnClearAllAlarm
        '
        Me.btnClearAllAlarm.BackColor = System.Drawing.Color.Transparent
        Me.btnClearAllAlarm.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.ClearAll
        Me.btnClearAllAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearAllAlarm.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnClearAllAlarm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearAllAlarm.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.ClearAll
        Me.btnClearAllAlarm.FlatAppearance.BorderSize = 0
        Me.btnClearAllAlarm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnClearAllAlarm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnClearAllAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearAllAlarm.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAllAlarm.ForeColor = System.Drawing.Color.Black
        Me.btnClearAllAlarm.Location = New System.Drawing.Point(0, 76)
        Me.btnClearAllAlarm.Name = "btnClearAllAlarm"
        Me.btnClearAllAlarm.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.ClearAll
        Me.btnClearAllAlarm.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.ClearAll
        Me.btnClearAllAlarm.Size = New System.Drawing.Size(71, 29)
        Me.btnClearAllAlarm.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.On
        Me.btnClearAllAlarm.TabIndex = 150
        Me.btnClearAllAlarm.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.ClearAll
        Me.btnClearAllAlarm.UseVisualStyleBackColor = False
        '
        'pnlAlarmStatus
        '
        Me.pnlAlarmStatus.BackColor = System.Drawing.Color.Transparent
        Me.pnlAlarmStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlAlarmStatus.Controls.Add(Me.StackLight)
        Me.pnlAlarmStatus.Controls.Add(Me.pnlRedLight)
        Me.pnlAlarmStatus.Controls.Add(Me.pnlBlueLight)
        Me.pnlAlarmStatus.Controls.Add(Me.pnlGreenLight)
        Me.pnlAlarmStatus.Controls.Add(Me.pnlYellowLight)
        Me.pnlAlarmStatus.EnableFormLevelDoubleBuffering = True
        Me.pnlAlarmStatus.Location = New System.Drawing.Point(71, 0)
        Me.pnlAlarmStatus.Name = "pnlAlarmStatus"
        Me.pnlAlarmStatus.Size = New System.Drawing.Size(46, 102)
        Me.pnlAlarmStatus.TabIndex = 9
        '
        'StackLight
        '
        Me.StackLight.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.StackLight.BackColor = System.Drawing.Color.Transparent
        Me.StackLight.Location = New System.Drawing.Point(0, 0)
        Me.StackLight.Name = "StackLight"
        Me.StackLight.Size = New System.Drawing.Size(46, 102)
        Me.StackLight.TabIndex = 14
        '
        'pnlRedLight
        '
        Me.pnlRedLight.AlarmImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.pnlRedLight.BackColor = System.Drawing.Color.Red
        Me.pnlRedLight.BackgroundImage = CType(resources.GetObject("pnlRedLight.BackgroundImage"), System.Drawing.Image)
        Me.pnlRedLight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlRedLight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlRedLight.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRedLight.LightPanelType = AVP_Robot_Project.YellowLightPanel.LightPanel.RedLight
        Me.pnlRedLight.Location = New System.Drawing.Point(0, 10)
        Me.pnlRedLight.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlRedLight.Name = "pnlRedLight"
        Me.pnlRedLight.NormalImage = Global.AVP_Robot_Project.My.Resources.Resources.DarkPanel
        Me.pnlRedLight.Size = New System.Drawing.Size(46, 10)
        Me.pnlRedLight.TabIndex = 8
        Me.pnlRedLight.UseVisualStyleBackColor = False
        Me.pnlRedLight.Visible = False
        '
        'pnlBlueLight
        '
        Me.pnlBlueLight.AlarmImage = Global.AVP_Robot_Project.My.Resources.Resources.ButtonYellow
        Me.pnlBlueLight.BackColor = System.Drawing.Color.Blue
        Me.pnlBlueLight.BackgroundImage = CType(resources.GetObject("pnlBlueLight.BackgroundImage"), System.Drawing.Image)
        Me.pnlBlueLight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlBlueLight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBlueLight.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBlueLight.LightPanelType = AVP_Robot_Project.YellowLightPanel.LightPanel.BlueLight
        Me.pnlBlueLight.Location = New System.Drawing.Point(0, 82)
        Me.pnlBlueLight.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBlueLight.Name = "pnlBlueLight"
        Me.pnlBlueLight.NormalImage = Global.AVP_Robot_Project.My.Resources.Resources.DarkPanel
        Me.pnlBlueLight.Size = New System.Drawing.Size(46, 10)
        Me.pnlBlueLight.TabIndex = 13
        Me.pnlBlueLight.UseVisualStyleBackColor = False
        Me.pnlBlueLight.Visible = False
        '
        'pnlGreenLight
        '
        Me.pnlGreenLight.AlarmImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.pnlGreenLight.BackColor = System.Drawing.Color.Lime
        Me.pnlGreenLight.BackgroundImage = CType(resources.GetObject("pnlGreenLight.BackgroundImage"), System.Drawing.Image)
        Me.pnlGreenLight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlGreenLight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlGreenLight.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGreenLight.LightPanelType = AVP_Robot_Project.YellowLightPanel.LightPanel.GreenLight
        Me.pnlGreenLight.Location = New System.Drawing.Point(0, 92)
        Me.pnlGreenLight.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlGreenLight.Name = "pnlGreenLight"
        Me.pnlGreenLight.NormalImage = Global.AVP_Robot_Project.My.Resources.Resources.DarkPanel
        Me.pnlGreenLight.Size = New System.Drawing.Size(46, 10)
        Me.pnlGreenLight.TabIndex = 7
        Me.pnlGreenLight.UseVisualStyleBackColor = False
        Me.pnlGreenLight.Visible = False
        '
        'pnlYellowLight
        '
        Me.pnlYellowLight.AlarmImage = Global.AVP_Robot_Project.My.Resources.Resources.ButtonYellow
        Me.pnlYellowLight.BackColor = System.Drawing.Color.Yellow
        Me.pnlYellowLight.BackgroundImage = CType(resources.GetObject("pnlYellowLight.BackgroundImage"), System.Drawing.Image)
        Me.pnlYellowLight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlYellowLight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlYellowLight.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlYellowLight.LightPanelType = AVP_Robot_Project.YellowLightPanel.LightPanel.YellowLight
        Me.pnlYellowLight.Location = New System.Drawing.Point(0, 0)
        Me.pnlYellowLight.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlYellowLight.Name = "pnlYellowLight"
        Me.pnlYellowLight.NormalImage = Global.AVP_Robot_Project.My.Resources.Resources.DarkPanel
        Me.pnlYellowLight.Size = New System.Drawing.Size(46, 10)
        Me.pnlYellowLight.TabIndex = 6
        Me.pnlYellowLight.UseVisualStyleBackColor = False
        Me.pnlYellowLight.Visible = False
        '
        'AVPLogo
        '
        Me.AVPLogo.Location = New System.Drawing.Point(6, 7)
        Me.AVPLogo.MaximumSize = New System.Drawing.Size(161, 107)
        Me.AVPLogo.MinimumSize = New System.Drawing.Size(161, 107)
        Me.AVPLogo.Name = "AVPLogo"
        Me.AVPLogo.Size = New System.Drawing.Size(161, 107)
        Me.AVPLogo.TabIndex = 155
        '
        'lblAlarmTextMain
        '
        Me.lblAlarmTextMain.BackColor = System.Drawing.Color.Honeydew
        Me.lblAlarmTextMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAlarmTextMain.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlarmTextMain.ForeColor = System.Drawing.Color.Red
        Me.lblAlarmTextMain.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblAlarmTextMain.Location = New System.Drawing.Point(174, 86)
        Me.lblAlarmTextMain.Name = "lblAlarmTextMain"
        Me.lblAlarmTextMain.Size = New System.Drawing.Size(975, 26)
        Me.lblAlarmTextMain.TabIndex = 7
        Me.lblAlarmTextMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LoginBox
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(171, 84)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(981, 30)
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'PnlBottom
        '
        Me.PnlBottom.BackColor = System.Drawing.Color.Transparent
        Me.PnlBottom.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgBottomPanel
        Me.PnlBottom.Controls.Add(Me.btnMaintenance)
        Me.PnlBottom.Controls.Add(Me.btnProcess)
        Me.PnlBottom.Controls.Add(Me.btnEditor)
        Me.PnlBottom.Controls.Add(Me.btnSetup)
        Me.PnlBottom.Controls.Add(Me.btnDataLog)
        Me.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlBottom.Location = New System.Drawing.Point(0, 645)
        Me.PnlBottom.Name = "PnlBottom"
        Me.PnlBottom.Size = New System.Drawing.Size(1280, 101)
        Me.PnlBottom.TabIndex = 1
        '
        'btnMaintenance
        '
        Me.btnMaintenance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMaintenance.FlatAppearance.BorderSize = 0
        Me.btnMaintenance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnMaintenance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaintenance.Image = Global.AVP_Robot_Project.My.Resources.Resources.BtnMaintenance
        Me.btnMaintenance.Location = New System.Drawing.Point(560, 11)
        Me.btnMaintenance.Name = "btnMaintenance"
        Me.btnMaintenance.NormalImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnMaintenance
        Me.btnMaintenance.PressedImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnMaintenanceDown
        Me.btnMaintenance.Selectable = True
        Me.btnMaintenance.Size = New System.Drawing.Size(160, 76)
        Me.btnMaintenance.TabIndex = 3
        Me.btnMaintenance.TabStop = False
        Me.btnMaintenance.UseVisualStyleBackColor = True
        '
        'btnProcess
        '
        Me.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcess.FlatAppearance.BorderSize = 0
        Me.btnProcess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnProcess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcess.Image = Global.AVP_Robot_Project.My.Resources.Resources.BtnProcessDown
        Me.btnProcess.IsSelected = True
        Me.btnProcess.Location = New System.Drawing.Point(48, 11)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.NormalImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnProcess
        Me.btnProcess.PressedImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnProcessDown
        Me.btnProcess.Selectable = True
        Me.btnProcess.Size = New System.Drawing.Size(160, 76)
        Me.btnProcess.TabIndex = 1
        Me.btnProcess.TabStop = False
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnEditor
        '
        Me.btnEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnEditor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditor.FlatAppearance.BorderSize = 0
        Me.btnEditor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnEditor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditor.Image = Global.AVP_Robot_Project.My.Resources.Resources.BtnEditor
        Me.btnEditor.Location = New System.Drawing.Point(304, 11)
        Me.btnEditor.Name = "btnEditor"
        Me.btnEditor.NormalImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnEditor
        Me.btnEditor.PressedImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnEditorDown
        Me.btnEditor.Selectable = True
        Me.btnEditor.Size = New System.Drawing.Size(160, 76)
        Me.btnEditor.TabIndex = 2
        Me.btnEditor.TabStop = False
        Me.btnEditor.UseVisualStyleBackColor = True
        '
        'btnSetup
        '
        Me.btnSetup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSetup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSetup.FlatAppearance.BorderSize = 0
        Me.btnSetup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSetup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetup.Image = Global.AVP_Robot_Project.My.Resources.Resources.BtnSetup
        Me.btnSetup.Location = New System.Drawing.Point(816, 11)
        Me.btnSetup.Name = "btnSetup"
        Me.btnSetup.NormalImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnSetup
        Me.btnSetup.PressedImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnSetupDown
        Me.btnSetup.Selectable = True
        Me.btnSetup.Size = New System.Drawing.Size(160, 76)
        Me.btnSetup.TabIndex = 4
        Me.btnSetup.TabStop = False
        Me.btnSetup.UseVisualStyleBackColor = True
        '
        'btnDataLog
        '
        Me.btnDataLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDataLog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDataLog.FlatAppearance.BorderSize = 0
        Me.btnDataLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDataLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDataLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDataLog.Image = Global.AVP_Robot_Project.My.Resources.Resources.BtnDataLog
        Me.btnDataLog.Location = New System.Drawing.Point(1072, 11)
        Me.btnDataLog.Name = "btnDataLog"
        Me.btnDataLog.NormalImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnDataLog
        Me.btnDataLog.PressedImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnDataLogDown
        Me.btnDataLog.Selectable = True
        Me.btnDataLog.Size = New System.Drawing.Size(160, 76)
        Me.btnDataLog.TabIndex = 5
        Me.btnDataLog.TabStop = False
        Me.btnDataLog.UseVisualStyleBackColor = True
        '
        'tmrTopRightClock
        '
        Me.tmrTopRightClock.Enabled = True
        '
        'cmsSetup
        '
        Me.cmsSetup.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsSetup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUserSetup, Me.mnuSystem})
        Me.cmsSetup.Name = "cmsEditor"
        Me.cmsSetup.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsSetup.ShowImageMargin = False
        Me.cmsSetup.Size = New System.Drawing.Size(179, 72)
        '
        'mnuUserSetup
        '
        Me.mnuUserSetup.Name = "mnuUserSetup"
        Me.mnuUserSetup.Size = New System.Drawing.Size(178, 34)
        Me.mnuUserSetup.Text = "User Setup"
        '
        'mnuSystem
        '
        Me.mnuSystem.Name = "mnuSystem"
        Me.mnuSystem.Size = New System.Drawing.Size(178, 34)
        Me.mnuSystem.Text = "System"
        '
        'mnuRecipe
        '
        Me.mnuRecipe.Name = "mnuRecipe"
        Me.mnuRecipe.Size = New System.Drawing.Size(191, 34)
        Me.mnuRecipe.Text = "Recipe"
        '
        'mnuSequence
        '
        Me.mnuSequence.Name = "mnuSequence"
        Me.mnuSequence.Size = New System.Drawing.Size(191, 34)
        Me.mnuSequence.Text = "Sequence"
        '
        'mnuWaferFlow
        '
        Me.mnuWaferFlow.Name = "mnuWaferFlow"
        Me.mnuWaferFlow.Size = New System.Drawing.Size(191, 34)
        Me.mnuWaferFlow.Text = "Wafer  Flow"
        '
        'cmsEditor
        '
        Me.cmsEditor.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsEditor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRecipe, Me.mnuSequence, Me.mnuWaferFlow})
        Me.cmsEditor.Name = "cmsEditor"
        Me.cmsEditor.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsEditor.ShowImageMargin = False
        Me.cmsEditor.Size = New System.Drawing.Size(192, 106)
        '
        'ImgLisTooltipMachine
        '
        Me.ImgLisTooltipMachine.ImageStream = CType(resources.GetObject("ImgLisTooltipMachine.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLisTooltipMachine.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLisTooltipMachine.Images.SetKeyName(0, "Tool.bmp")
        Me.ImgLisTooltipMachine.Images.SetKeyName(1, "ToolOnline.bmp")
        '
        'tabIODeviceNet
        '
        Me.tabIODeviceNet.Location = New System.Drawing.Point(0, 36)
        Me.tabIODeviceNet.Name = "tabIODeviceNet"
        Me.tabIODeviceNet.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIODeviceNet.Size = New System.Drawing.Size(1013, 98)
        Me.tabIODeviceNet.TabIndex = 12
        Me.tabIODeviceNet.Text = "IO"
        Me.tabIODeviceNet.UseVisualStyleBackColor = True
        '
        'AVPRobotMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1280, 746)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1278, 736)
        Me.Name = "AVPRobotMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AVP Technology, LLC"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlCenter.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabEditor.ResumeLayout(False)
        Me.tabDataLog.ResumeLayout(False)
        Me.tabSetup.ResumeLayout(False)
        Me.PnlHeader.ResumeLayout(False)
        Me.pnlAlarm.ResumeLayout(False)
        Me.pnlAlarmLight.ResumeLayout(False)
        Me.pnlAlarmStatus.ResumeLayout(False)
        CType(Me.StackLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBottom.ResumeLayout(False)
        Me.cmsSetup.ResumeLayout(False)
        Me.cmsEditor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlBottom As AVPControls.AVPPanel
    Friend WithEvents btnSetup As AVPControls.AVPButton
    Friend WithEvents btnDataLog As AVPControls.AVPButton
    Friend WithEvents btnMaintenance As AVPControls.AVPButton
    Friend WithEvents btnProcess As AVPControls.AVPButton
    Friend WithEvents btnEditor As AVPControls.AVPButton
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents PnlHeader As AVPControls.AVPPanel
    Friend WithEvents tmrTopRightClock As System.Windows.Forms.Timer
    Friend WithEvents pnlCenter As System.Windows.Forms.Panel
    Friend WithEvents aplAlarm As AVP_Robot_Project.AlarmPanel
    Friend WithEvents cmsSetup As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuUserSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSystem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblAlarmTextMain As System.Windows.Forms.Label
    Friend WithEvents mnuRecipe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSequence As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWaferFlow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsEditor As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImgLisTooltipMachine As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAlarmStatus As AVPControls.AVPPanel
    Friend WithEvents pnlRedLight As AVP_Robot_Project.YellowLightPanel
    Friend WithEvents pnlGreenLight As AVP_Robot_Project.YellowLightPanel
    Friend WithEvents pnlYellowLight As AVP_Robot_Project.YellowLightPanel
    Friend WithEvents btnClearAllAlarm As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents pnlPMConnection As AVP_Robot_Project.ConnectPMPanel
    Friend WithEvents tabSetup As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabUserSetup As System.Windows.Forms.TabPage
    Friend WithEvents tabSystem As System.Windows.Forms.TabPage
    Friend WithEvents tabMain As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabDiag As System.Windows.Forms.TabPage
    Friend WithEvents tabIO As System.Windows.Forms.TabPage
    Friend WithEvents tabTM As System.Windows.Forms.TabPage
    Friend WithEvents tabEditor As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabRecipe As System.Windows.Forms.TabPage
    Friend WithEvents tabWaferFlow As System.Windows.Forms.TabPage
    Friend WithEvents tabSequence As System.Windows.Forms.TabPage
    Friend WithEvents tabDataLog As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabDTLog As System.Windows.Forms.TabPage
    Friend WithEvents tabWR As System.Windows.Forms.TabPage
    Friend WithEvents tabPM1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPM2 As System.Windows.Forms.TabPage
    Friend WithEvents tabPM3 As System.Windows.Forms.TabPage
    Friend WithEvents tabSecsGem As System.Windows.Forms.TabPage
    Friend WithEvents TabLotDatalog As System.Windows.Forms.TabPage
    Friend WithEvents tabAlarmStatistic As System.Windows.Forms.TabPage
    Friend WithEvents pnlBlueLight As AVP_Robot_Project.YellowLightPanel
    Friend WithEvents StackLight As AVPControls.StackLightControl
    Friend WithEvents AVPLogo As AVPControls.AppLogoPanel
    Friend WithEvents pnlAlarm As AVPControls.AVPPanel
    Friend WithEvents AVPInfoPanel As AVPControls.AppInfoPanel
    Friend WithEvents AVPCommunicationPanel As AVPControls.AppHostCommunicationPanel
    Friend WithEvents AVPDatetimePanel As AVPControls.AppDatetimePanel
    Friend WithEvents AVPLoginPanel As AVPControls.AppLoginPanel
    Friend WithEvents pnlAlarmLight As AVPControls.AVPPanel
    Friend WithEvents tabCycleATM As System.Windows.Forms.TabPage
    Friend WithEvents tabIODeviceNet As System.Windows.Forms.TabPage

End Class
