<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TurboControl
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
        Me.pnlHeader = New System.Windows.Forms.Panel
        Me.btnComStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblTurboStatus = New System.Windows.Forms.Label
        Me.lblHeader = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblPressure = New System.Windows.Forms.Label
        Me.pnlRelay = New System.Windows.Forms.Panel
        Me.btnRelay = New AVP_Robot_Project.SL_CustomButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnTurbo = New AVP_Robot_Project.SL_CustomButton
        Me.btnForeline = New AVP_Robot_Project.SL_CustomButton
        Me.pnlCom = New System.Windows.Forms.Panel
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlRelay.SuspendLayout()
        Me.pnlCom.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Text = "Cryo"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.Transparent
        Me.pnlHeader.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgMsgBoxHeader
        Me.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlHeader.Controls.Add(Me.pnlCom)
        Me.pnlHeader.Controls.Add(Me.lblTurboStatus)
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(190, 27)
        Me.pnlHeader.TabIndex = 12
        '
        'btnComStatus
        '
        Me.btnComStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnComStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.FlatAppearance.BorderSize = 0
        Me.btnComStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnComStatus.ForeColor = System.Drawing.Color.White
        Me.btnComStatus.Location = New System.Drawing.Point(42, 5)
        Me.btnComStatus.Name = "btnComStatus"
        Me.btnComStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnComStatus.Size = New System.Drawing.Size(17, 17)
        Me.btnComStatus.TabIndex = 34
        Me.btnComStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnComStatus.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 27)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "COM."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTurboStatus
        '
        Me.lblTurboStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblTurboStatus.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTurboStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboStatus.ForeColor = System.Drawing.Color.Yellow
        Me.lblTurboStatus.Location = New System.Drawing.Point(82, 0)
        Me.lblTurboStatus.Name = "lblTurboStatus"
        Me.lblTurboStatus.Size = New System.Drawing.Size(45, 27)
        Me.lblTurboStatus.TabIndex = 33
        Me.lblTurboStatus.Text = "Ramp"
        Me.lblTurboStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHeader
        '
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(82, 27)
        Me.lblHeader.TabIndex = 7
        Me.lblHeader.Text = "TM Turbo"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lblPressure)
        Me.Panel2.Controls.Add(Me.pnlRelay)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(190, 30)
        Me.Panel2.TabIndex = 13
        '
        'lblPressure
        '
        Me.lblPressure.BackColor = System.Drawing.Color.Transparent
        Me.lblPressure.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblPressure.ForeColor = System.Drawing.Color.Lime
        Me.lblPressure.Location = New System.Drawing.Point(96, 0)
        Me.lblPressure.Name = "lblPressure"
        Me.lblPressure.Size = New System.Drawing.Size(71, 28)
        Me.lblPressure.TabIndex = 10
        Me.lblPressure.Text = "5.0E-05"
        Me.lblPressure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlRelay
        '
        Me.pnlRelay.BackColor = System.Drawing.Color.Transparent
        Me.pnlRelay.Controls.Add(Me.btnRelay)
        Me.pnlRelay.Location = New System.Drawing.Point(170, 0)
        Me.pnlRelay.Name = "pnlRelay"
        Me.pnlRelay.Size = New System.Drawing.Size(16, 28)
        Me.pnlRelay.TabIndex = 35
        '
        'btnRelay
        '
        Me.btnRelay.AccessibleName = "Relay"
        Me.btnRelay.BackColor = System.Drawing.Color.Transparent
        Me.btnRelay.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRelay.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRelay.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnRelay.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.FlatAppearance.BorderSize = 0
        Me.btnRelay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRelay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelay.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelay.ForeColor = System.Drawing.Color.White
        Me.btnRelay.Location = New System.Drawing.Point(3, 9)
        Me.btnRelay.MessageBoxText = Nothing
        Me.btnRelay.Name = "btnRelay"
        Me.btnRelay.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOn
        Me.btnRelay.Size = New System.Drawing.Size(10, 10)
        Me.btnRelay.TabIndex = 289
        Me.btnRelay.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnRelay.UseClickedEventInForm = True
        Me.btnRelay.UseVisualStyleBackColor = False
        Me.btnRelay.ValueToBeSend = ""
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 28)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "PRESSURE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnTurbo
        '
        Me.btnTurbo.AccessibleDescription = "Turbo On Off"
        Me.btnTurbo.AccessibleName = "TurboOnOff"
        Me.btnTurbo.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTurbo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurbo.Clickable = True
        Me.btnTurbo.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurbo.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTurbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurbo.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTurbo.ErrorText = "Turbo"
        Me.btnTurbo.FlatAppearance.BorderSize = 0
        Me.btnTurbo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurbo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnTurbo.ForeColor = System.Drawing.Color.Black
        Me.btnTurbo.Location = New System.Drawing.Point(10, 61)
        Me.btnTurbo.MessageBoxText = Nothing
        Me.btnTurbo.Name = "btnTurbo"
        Me.btnTurbo.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTurbo.OffText = "Turbo"
        Me.btnTurbo.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTurbo.OnText = "Turbo"
        Me.btnTurbo.Size = New System.Drawing.Size(83, 27)
        Me.btnTurbo.TabIndex = 14
        Me.btnTurbo.Text = "Turbo"
        Me.btnTurbo.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnTurbo.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTurbo.UnKnownText = "Turbo"
        Me.btnTurbo.UseChangeValueToSend_BaseOnStatus = True
        Me.btnTurbo.UseVisualStyleBackColor = True
        Me.btnTurbo.ValueToBeSend = "On"
        '
        'btnForeline
        '
        Me.btnForeline.AccessibleName = "ForelineOpenClose"
        Me.btnForeline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnForeline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnForeline.Clickable = True
        Me.btnForeline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnForeline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnForeline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnForeline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnForeline.ErrorText = "Foreline"
        Me.btnForeline.FlatAppearance.BorderSize = 0
        Me.btnForeline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnForeline.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnForeline.ForeColor = System.Drawing.Color.Black
        Me.btnForeline.Location = New System.Drawing.Point(97, 61)
        Me.btnForeline.MessageBoxText = Nothing
        Me.btnForeline.Name = "btnForeline"
        Me.btnForeline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnForeline.OffText = "Foreline"
        Me.btnForeline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnForeline.OnText = "Foreline"
        Me.btnForeline.Size = New System.Drawing.Size(83, 27)
        Me.btnForeline.TabIndex = 15
        Me.btnForeline.Text = "Foreline"
        Me.btnForeline.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnForeline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnForeline.UnKnownText = "Foreline"
        Me.btnForeline.UseChangeValueToSend_BaseOnStatus = True
        Me.btnForeline.UseVisualStyleBackColor = True
        Me.btnForeline.ValueToBeSend = "On"
        '
        'pnlCom
        '
        Me.pnlCom.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgCommunication
        Me.pnlCom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlCom.Controls.Add(Me.btnComStatus)
        Me.pnlCom.Controls.Add(Me.Label1)
        Me.pnlCom.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCom.Location = New System.Drawing.Point(125, 0)
        Me.pnlCom.Name = "pnlCom"
        Me.pnlCom.Size = New System.Drawing.Size(65, 27)
        Me.pnlCom.TabIndex = 35
        '
        'TurboControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.btnForeline)
        Me.Controls.Add(Me.btnTurbo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderVisible = False
        Me.Name = "TurboControl"
        Me.Size = New System.Drawing.Size(190, 95)
        Me.Text = "Cryo"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.pnlHeader, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.btnTurbo, 0)
        Me.Controls.SetChildIndex(Me.btnForeline, 0)
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlRelay.ResumeLayout(False)
        Me.pnlCom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPressure As System.Windows.Forms.Label
    'Friend WithEvents btnHome As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents pnlRelay As System.Windows.Forms.Panel
    Friend WithEvents lblTurboStatus As System.Windows.Forms.Label
    Friend WithEvents btnTurbo As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnForeline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnComStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnRelay As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents pnlCom As System.Windows.Forms.Panel

End Class
