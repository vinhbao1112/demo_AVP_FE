<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LockCassetteControl
	Inherits AVP_Robot_Project.StatusBoard

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
        Me.psgPressureGraph = New AVP_Robot_Project.PressureGraph
        Me.btnGoToSlot = New AVPControls.AVPButton
        Me.btnHome = New AVPControls.AVPButton
        Me.btnOpen = New AVPControls.AVPButton
        Me.btnMap = New AVPControls.AVPButton
        Me.btnReset = New AVPControls.AVPButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlRelay = New System.Windows.Forms.Panel
        Me.btnRelay = New AVP_Robot_Project.SL_CustomButton
        Me.cscDC = New AVP_Robot_Project.CircleStatusControl
        Me.lblPressure = New System.Windows.Forms.Label
        Me.lblTorr = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.pnlCom = New System.Windows.Forms.Panel
        Me.btnComStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.lblOnline = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblComunicationLED = New System.Windows.Forms.Label
        Me.lblCommunication = New System.Windows.Forms.Label
        Me.btnClose = New AVPControls.AVPButton
        Me.Panel1.SuspendLayout()
        Me.pnlRelay.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlCom.SuspendLayout()
        Me.SuspendLayout()
        '
        'psgPressureGraph
        '
        Me.psgPressureGraph.AlignStyle = AVP_Robot_Project.PressureGraph.DisplayStyle.Right
        Me.psgPressureGraph.BackColor = System.Drawing.Color.Gainsboro
        Me.psgPressureGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.psgPressureGraph.Cursor = System.Windows.Forms.Cursors.Hand
        Me.psgPressureGraph.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.psgPressureGraph.Location = New System.Drawing.Point(7, 62)
        Me.psgPressureGraph.Name = "psgPressureGraph"
        Me.psgPressureGraph.Size = New System.Drawing.Size(62, 160)
        Me.psgPressureGraph.TabIndex = 21
        '
        'btnGoToSlot
        '
        Me.btnGoToSlot.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnGoToSlot.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoToSlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGoToSlot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGoToSlot.FlatAppearance.BorderSize = 0
        Me.btnGoToSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGoToSlot.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGoToSlot.ForeColor = System.Drawing.Color.Black
        Me.btnGoToSlot.Location = New System.Drawing.Point(73, 61)
        Me.btnGoToSlot.Name = "btnGoToSlot"
        Me.btnGoToSlot.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoToSlot.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnGoToSlot.Size = New System.Drawing.Size(98, 30)
        Me.btnGoToSlot.TabIndex = 22
        Me.btnGoToSlot.Text = "GO TO SLOT"
        Me.btnGoToSlot.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnHome.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHome.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHome.FlatAppearance.BorderSize = 0
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHome.ForeColor = System.Drawing.Color.Black
        Me.btnHome.Location = New System.Drawing.Point(73, 94)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHome.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnHome.Size = New System.Drawing.Size(98, 30)
        Me.btnHome.TabIndex = 23
        Me.btnHome.Text = "HOME"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnOpen
        '
        Me.btnOpen.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnOpen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpen.FlatAppearance.BorderSize = 0
        Me.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpen.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.ForeColor = System.Drawing.Color.Black
        Me.btnOpen.Location = New System.Drawing.Point(73, 160)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOpen.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOpen.Size = New System.Drawing.Size(98, 30)
        Me.btnOpen.TabIndex = 25
        Me.btnOpen.Text = "OPEN"
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'btnMap
        '
        Me.btnMap.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnMap.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMap.FlatAppearance.BorderSize = 0
        Me.btnMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMap.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMap.ForeColor = System.Drawing.Color.Black
        Me.btnMap.Location = New System.Drawing.Point(73, 127)
        Me.btnMap.Name = "btnMap"
        Me.btnMap.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMap.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnMap.Size = New System.Drawing.Size(98, 30)
        Me.btnMap.TabIndex = 24
        Me.btnMap.Text = "MAP"
        Me.btnMap.UseVisualStyleBackColor = False
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.FlatAppearance.BorderSize = 0
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReset.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.Black
        Me.btnReset.Location = New System.Drawing.Point(54, 176)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(20, 30)
        Me.btnReset.TabIndex = 26
        Me.btnReset.Text = "RESET"
        Me.btnReset.UseVisualStyleBackColor = False
        Me.btnReset.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.pnlRelay)
        Me.Panel1.Controls.Add(Me.lblPressure)
        Me.Panel1.Controls.Add(Me.lblTorr)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Lime
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(177, 30)
        Me.Panel1.TabIndex = 31
        '
        'pnlRelay
        '
        Me.pnlRelay.BackColor = System.Drawing.Color.Transparent
        Me.pnlRelay.Controls.Add(Me.btnRelay)
        Me.pnlRelay.Controls.Add(Me.cscDC)
        Me.pnlRelay.Location = New System.Drawing.Point(4, 0)
        Me.pnlRelay.Name = "pnlRelay"
        Me.pnlRelay.Size = New System.Drawing.Size(13, 28)
        Me.pnlRelay.TabIndex = 34
        '
        'btnRelay
        '
        Me.btnRelay.AccessibleName = "LLRelay"
        Me.btnRelay.BackColor = System.Drawing.Color.Transparent
        Me.btnRelay.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRelay.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnRelay.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.FlatAppearance.BorderSize = 0
        Me.btnRelay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRelay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelay.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelay.ForeColor = System.Drawing.Color.White
        Me.btnRelay.Location = New System.Drawing.Point(1, 9)
        Me.btnRelay.MessageBoxText = Nothing
        Me.btnRelay.Name = "btnRelay"
        Me.btnRelay.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOn
        Me.btnRelay.Size = New System.Drawing.Size(10, 10)
        Me.btnRelay.TabIndex = 286
        Me.btnRelay.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.UseClickedEventInForm = True
        Me.btnRelay.UseVisualStyleBackColor = False
        Me.btnRelay.ValueToBeSend = ""
        '
        'cscDC
        '
        Me.cscDC.Location = New System.Drawing.Point(11, 0)
        Me.cscDC.Name = "cscDC"
        Me.cscDC.PMVisible = True
        Me.cscDC.Size = New System.Drawing.Size(8, 8)
        Me.cscDC.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.cscDC.TabIndex = 32
        Me.cscDC.Visible = False
        '
        'lblPressure
        '
        Me.lblPressure.AutoSize = True
        Me.lblPressure.BackColor = System.Drawing.Color.Transparent
        Me.lblPressure.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblPressure.ForeColor = System.Drawing.Color.Lime
        Me.lblPressure.Location = New System.Drawing.Point(18, 6)
        Me.lblPressure.Name = "lblPressure"
        Me.lblPressure.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblPressure.Size = New System.Drawing.Size(83, 17)
        Me.lblPressure.TabIndex = 31
        Me.lblPressure.Text = "PRESSURE"
        Me.lblPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTorr
        '
        Me.lblTorr.AutoSize = True
        Me.lblTorr.BackColor = System.Drawing.Color.Transparent
        Me.lblTorr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTorr.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblTorr.ForeColor = System.Drawing.Color.Lime
        Me.lblTorr.Location = New System.Drawing.Point(97, 5)
        Me.lblTorr.Name = "lblTorr"
        Me.lblTorr.Padding = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.lblTorr.Size = New System.Drawing.Size(84, 19)
        Me.lblTorr.TabIndex = 28
        Me.lblTorr.Text = "0.00mTorr"
        Me.lblTorr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.pnlCom)
        Me.Panel2.Controls.Add(Me.lblOnline)
        Me.Panel2.Controls.Add(Me.lblTitle)
        Me.Panel2.Controls.Add(Me.lblComunicationLED)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(177, 27)
        Me.Panel2.TabIndex = 32
        '
        'pnlCom
        '
        Me.pnlCom.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgCommunication
        Me.pnlCom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlCom.Controls.Add(Me.btnComStatus)
        Me.pnlCom.Controls.Add(Me.lblCommunication)
        Me.pnlCom.Location = New System.Drawing.Point(0, 0)
        Me.pnlCom.Name = "pnlCom"
        Me.pnlCom.Size = New System.Drawing.Size(65, 27)
        Me.pnlCom.TabIndex = 38
        '
        'btnComStatus
        '
        Me.btnComStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnComStatus.CausesValidation = False
        Me.btnComStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnComStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.FlatAppearance.BorderSize = 0
        Me.btnComStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnComStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComStatus.ForeColor = System.Drawing.Color.White
        Me.btnComStatus.Location = New System.Drawing.Point(7, 6)
        Me.btnComStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnComStatus.Name = "btnComStatus"
        Me.btnComStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnComStatus.Size = New System.Drawing.Size(15, 15)
        Me.btnComStatus.TabIndex = 37
        Me.btnComStatus.TabStop = False
        Me.btnComStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnComStatus.UseVisualStyleBackColor = False
        '
        'lblCommunication
        '
        Me.lblCommunication.AutoSize = True
        Me.lblCommunication.BackColor = System.Drawing.Color.Transparent
        Me.lblCommunication.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCommunication.ForeColor = System.Drawing.Color.White
        Me.lblCommunication.Location = New System.Drawing.Point(24, 6)
        Me.lblCommunication.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCommunication.Name = "lblCommunication"
        Me.lblCommunication.Size = New System.Drawing.Size(39, 15)
        Me.lblCommunication.TabIndex = 30
        Me.lblCommunication.Text = "COM."
        Me.lblCommunication.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOnline
        '
        Me.lblOnline.AutoSize = True
        Me.lblOnline.BackColor = System.Drawing.Color.Transparent
        Me.lblOnline.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblOnline.ForeColor = System.Drawing.Color.Yellow
        Me.lblOnline.Location = New System.Drawing.Point(65, 4)
        Me.lblOnline.Name = "lblOnline"
        Me.lblOnline.Size = New System.Drawing.Size(66, 18)
        Me.lblOnline.TabIndex = 32
        Me.lblOnline.Text = "(Offline)"
        Me.lblOnline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(127, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(50, 27)
        Me.lblTitle.TabIndex = 31
        Me.lblTitle.Text = "LLB"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblComunicationLED
        '
        Me.lblComunicationLED.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED.Location = New System.Drawing.Point(-16, 0)
        Me.lblComunicationLED.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblComunicationLED.Name = "lblComunicationLED"
        Me.lblComunicationLED.Size = New System.Drawing.Size(19, 12)
        Me.lblComunicationLED.TabIndex = 29
        Me.lblComunicationLED.Visible = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(73, 193)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnClose.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreenDown
        Me.btnClose.Size = New System.Drawing.Size(98, 30)
        Me.btnClose.TabIndex = 25
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'LockCassetteControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.psgPressureGraph)
        Me.Controls.Add(Me.btnGoToSlot)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnMap)
        Me.Controls.Add(Me.btnClose)
        Me.DoubleBuffered = True
        Me.HeaderVisible = False
        Me.Name = "LockCassetteControl"
        Me.Size = New System.Drawing.Size(177, 230)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.btnMap, 0)
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.btnOpen, 0)
        Me.Controls.SetChildIndex(Me.btnHome, 0)
        Me.Controls.SetChildIndex(Me.btnGoToSlot, 0)
        Me.Controls.SetChildIndex(Me.psgPressureGraph, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lblHeader, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlRelay.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlCom.ResumeLayout(False)
        Me.pnlCom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents psgPressureGraph As AVP_Robot_Project.PressureGraph
    Friend WithEvents btnGoToSlot As AVPControls.AVPButton
    Friend WithEvents btnHome As AVPControls.AVPButton
    Friend WithEvents btnOpen As AVPControls.AVPButton
    Friend WithEvents btnMap As AVPControls.AVPButton
    Friend WithEvents btnReset As AVPControls.AVPButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblPressure As System.Windows.Forms.Label
    Friend WithEvents lblTorr As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblCommunication As System.Windows.Forms.Label
    Friend WithEvents lblComunicationLED As System.Windows.Forms.Label
    Friend WithEvents cscDC As AVP_Robot_Project.CircleStatusControl
    Friend WithEvents btnClose As AVPControls.AVPButton
    Friend WithEvents pnlRelay As System.Windows.Forms.Panel
    Friend WithEvents lblOnline As System.Windows.Forms.Label
    Friend WithEvents btnComStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnRelay As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents pnlCom As System.Windows.Forms.Panel

End Class
