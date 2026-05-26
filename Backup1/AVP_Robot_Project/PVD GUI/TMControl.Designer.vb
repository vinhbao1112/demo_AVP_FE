<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TMControl
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
        Me.txtT2 = New System.Windows.Forms.TextBox
        Me.pnlHeader = New System.Windows.Forms.Panel
        Me.pnlCom = New System.Windows.Forms.Panel
        Me.btnComStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblOnline = New System.Windows.Forms.Label
        Me.lblComunicationLED = New System.Windows.Forms.Label
        Me.lblHeader = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblPressure = New System.Windows.Forms.Label
        Me.pnlRelay = New System.Windows.Forms.Panel
        Me.btnRelay = New AVP_Robot_Project.SL_CustomButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.HivacCloseButton = New AVP_Robot_Project.ButtonIGCGControl
        Me.txtCG = New System.Windows.Forms.TextBox
        Me.txtIG = New System.Windows.Forms.TextBox
        Me.bigcgCG = New AVP_Robot_Project.ButtonIGCGControl
        Me.bigcgIG = New AVP_Robot_Project.ButtonIGCGControl
        Me.HivacOpenButton = New AVP_Robot_Project.ButtonIGCGControl
        Me.pnlHeader.SuspendLayout()
        Me.pnlCom.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlRelay.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Text = "Cryo"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'txtT2
        '
        Me.txtT2.Location = New System.Drawing.Point(238, 60)
        Me.txtT2.Name = "txtT2"
        Me.txtT2.ReadOnly = True
        Me.txtT2.Size = New System.Drawing.Size(10, 29)
        Me.txtT2.TabIndex = 9
        Me.txtT2.Visible = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.Transparent
        Me.pnlHeader.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlHeader.Controls.Add(Me.pnlCom)
        Me.pnlHeader.Controls.Add(Me.lblOnline)
        Me.pnlHeader.Controls.Add(Me.lblComunicationLED)
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(190, 27)
        Me.pnlHeader.TabIndex = 12
        '
        'pnlCom
        '
        Me.pnlCom.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgCommunication
        Me.pnlCom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlCom.Controls.Add(Me.btnComStatus)
        Me.pnlCom.Controls.Add(Me.Label1)
        Me.pnlCom.Location = New System.Drawing.Point(125, 0)
        Me.pnlCom.Name = "pnlCom"
        Me.pnlCom.Size = New System.Drawing.Size(65, 27)
        Me.pnlCom.TabIndex = 35
        '
        'btnComStatus
        '
        Me.btnComStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnComStatus.CausesValidation = False
        Me.btnComStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnComStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnComStatus.FlatAppearance.BorderSize = 0
        Me.btnComStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnComStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComStatus.ForeColor = System.Drawing.Color.White
        Me.btnComStatus.Location = New System.Drawing.Point(42, 5)
        Me.btnComStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnComStatus.Name = "btnComStatus"
        Me.btnComStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnComStatus.Size = New System.Drawing.Size(17, 17)
        Me.btnComStatus.TabIndex = 34
        Me.btnComStatus.TabStop = False
        Me.btnComStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnComStatus.UseVisualStyleBackColor = False
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
        'lblOnline
        '
        Me.lblOnline.BackColor = System.Drawing.Color.Transparent
        Me.lblOnline.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblOnline.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblOnline.ForeColor = System.Drawing.Color.Yellow
        Me.lblOnline.Location = New System.Drawing.Point(50, 0)
        Me.lblOnline.Name = "lblOnline"
        Me.lblOnline.Size = New System.Drawing.Size(70, 27)
        Me.lblOnline.TabIndex = 33
        Me.lblOnline.Text = "(Offline)"
        Me.lblOnline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblComunicationLED
        '
        Me.lblComunicationLED.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED.Location = New System.Drawing.Point(191, 8)
        Me.lblComunicationLED.Name = "lblComunicationLED"
        Me.lblComunicationLED.Size = New System.Drawing.Size(19, 12)
        Me.lblComunicationLED.TabIndex = 30
        '
        'lblHeader
        '
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblHeader.Size = New System.Drawing.Size(50, 27)
        Me.lblHeader.TabIndex = 7
        Me.lblHeader.Text = "TM"
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
        Me.lblPressure.AutoSize = True
        Me.lblPressure.BackColor = System.Drawing.Color.Transparent
        Me.lblPressure.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPressure.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblPressure.ForeColor = System.Drawing.Color.Lime
        Me.lblPressure.Location = New System.Drawing.Point(92, 5)
        Me.lblPressure.Name = "lblPressure"
        Me.lblPressure.Padding = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.lblPressure.Size = New System.Drawing.Size(78, 19)
        Me.lblPressure.TabIndex = 10
        Me.lblPressure.Text = "0.76E+03"
        Me.lblPressure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlRelay
        '
        Me.pnlRelay.BackColor = System.Drawing.Color.Transparent
        Me.pnlRelay.Controls.Add(Me.btnRelay)
        Me.pnlRelay.Location = New System.Drawing.Point(170, 1)
        Me.pnlRelay.Name = "pnlRelay"
        Me.pnlRelay.Size = New System.Drawing.Size(13, 28)
        Me.pnlRelay.TabIndex = 35
        '
        'btnRelay
        '
        Me.btnRelay.AccessibleName = "TMRelay"
        Me.btnRelay.BackColor = System.Drawing.Color.Transparent
        Me.btnRelay.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRelay.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnRelay.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.FlatAppearance.BorderSize = 0
        Me.btnRelay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRelay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelay.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelay.ForeColor = System.Drawing.Color.White
        Me.btnRelay.Location = New System.Drawing.Point(1, 8)
        Me.btnRelay.MessageBoxText = Nothing
        Me.btnRelay.Name = "btnRelay"
        Me.btnRelay.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOn
        Me.btnRelay.Size = New System.Drawing.Size(11, 11)
        Me.btnRelay.Status = SL_CustomButton.DisplayStatus.Off
        Me.btnRelay.TabIndex = 285
        Me.btnRelay.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnRelay.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgRelayOff
        Me.btnRelay.UseClickedEventInForm = True
        Me.btnRelay.UseVisualStyleBackColor = False
        Me.btnRelay.ValueToBeSend = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(17, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "PRESSURE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HivacCloseButton
        '
        Me.HivacCloseButton.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.HivacCloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.HivacCloseButton.ColorText_OffStatus = System.Drawing.Color.Black
        Me.HivacCloseButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HivacCloseButton.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.HivacCloseButton.FlatAppearance.BorderSize = 0
        Me.HivacCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.HivacCloseButton.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HivacCloseButton.ForeColor = System.Drawing.Color.Black
        Me.HivacCloseButton.Location = New System.Drawing.Point(10, 62)
        Me.HivacCloseButton.Name = "HivacCloseButton"
        Me.HivacCloseButton.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.HivacCloseButton.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.HivacCloseButton.Size = New System.Drawing.Size(170, 25)
        Me.HivacCloseButton.TabIndex = 14
        Me.HivacCloseButton.Text = "CLOSE HIVAC"
        Me.HivacCloseButton.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.HivacCloseButton.UseVisualStyleBackColor = True
        '
        'txtCG
        '
        Me.txtCG.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCG.Location = New System.Drawing.Point(0, 62)
        Me.txtCG.Name = "txtCG"
        Me.txtCG.ReadOnly = True
        Me.txtCG.Size = New System.Drawing.Size(5, 26)
        Me.txtCG.TabIndex = 15
        Me.txtCG.Visible = False
        '
        'txtIG
        '
        Me.txtIG.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIG.Location = New System.Drawing.Point(0, 82)
        Me.txtIG.Name = "txtIG"
        Me.txtIG.ReadOnly = True
        Me.txtIG.Size = New System.Drawing.Size(10, 26)
        Me.txtIG.TabIndex = 16
        Me.txtIG.Text = "OFF"
        Me.txtIG.Visible = False
        '
        'bigcgCG
        '
        Me.bigcgCG.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.bigcgCG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bigcgCG.ErrorImage = Nothing
        Me.bigcgCG.FlatAppearance.BorderSize = 0
        Me.bigcgCG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bigcgCG.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bigcgCG.ForeColor = System.Drawing.Color.Black
        Me.bigcgCG.Location = New System.Drawing.Point(0, 88)
        Me.bigcgCG.Name = "bigcgCG"
        Me.bigcgCG.OffImage = Nothing
        Me.bigcgCG.OnImage = Nothing
        Me.bigcgCG.Size = New System.Drawing.Size(10, 22)
        Me.bigcgCG.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.bigcgCG.TabIndex = 18
        Me.bigcgCG.UnknownImage = Nothing
        Me.bigcgCG.UseVisualStyleBackColor = True
        Me.bigcgCG.Visible = False
        '
        'bigcgIG
        '
        Me.bigcgIG.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.bigcgIG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bigcgIG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bigcgIG.Enabled = False
        Me.bigcgIG.ErrorImage = Nothing
        Me.bigcgIG.FlatAppearance.BorderSize = 0
        Me.bigcgIG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bigcgIG.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bigcgIG.ForeColor = System.Drawing.Color.White
        Me.bigcgIG.Location = New System.Drawing.Point(0, 62)
        Me.bigcgIG.Name = "bigcgIG"
        Me.bigcgIG.OffImage = Nothing
        Me.bigcgIG.OnImage = Nothing
        Me.bigcgIG.Size = New System.Drawing.Size(10, 22)
        Me.bigcgIG.TabIndex = 17
        Me.bigcgIG.UnknownImage = Nothing
        Me.bigcgIG.UseVisualStyleBackColor = True
        Me.bigcgIG.Visible = False
        '
        'HivacOpenButton
        '
        Me.HivacOpenButton.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.HivacOpenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.HivacOpenButton.ColorText_OffStatus = System.Drawing.Color.Black
        Me.HivacOpenButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HivacOpenButton.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.HivacOpenButton.FlatAppearance.BorderSize = 0
        Me.HivacOpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.HivacOpenButton.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HivacOpenButton.ForeColor = System.Drawing.Color.Black
        Me.HivacOpenButton.Location = New System.Drawing.Point(10, 90)
        Me.HivacOpenButton.Name = "HivacOpenButton"
        Me.HivacOpenButton.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.HivacOpenButton.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.HivacOpenButton.Size = New System.Drawing.Size(170, 25)
        Me.HivacOpenButton.TabIndex = 19
        Me.HivacOpenButton.Text = "OPEN HIVAC"
        Me.HivacOpenButton.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.HivacOpenButton.UseVisualStyleBackColor = True
        '
        'TMControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.HivacOpenButton)
        Me.Controls.Add(Me.bigcgCG)
        Me.Controls.Add(Me.bigcgIG)
        Me.Controls.Add(Me.txtIG)
        Me.Controls.Add(Me.txtCG)
        Me.Controls.Add(Me.HivacCloseButton)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.txtT2)
        Me.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderVisible = False
        Me.Name = "TMControl"
        Me.Size = New System.Drawing.Size(190, 125)
        Me.Text = "Cryo"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtT2, 0)
        Me.Controls.SetChildIndex(Me.pnlHeader, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.HivacCloseButton, 0)
        Me.Controls.SetChildIndex(Me.txtCG, 0)
        Me.Controls.SetChildIndex(Me.txtIG, 0)
        Me.Controls.SetChildIndex(Me.bigcgIG, 0)
        Me.Controls.SetChildIndex(Me.bigcgCG, 0)
        Me.Controls.SetChildIndex(Me.HivacOpenButton, 0)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlCom.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlRelay.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtT2 As System.Windows.Forms.TextBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblComunicationLED As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPressure As System.Windows.Forms.Label
    Friend WithEvents HivacCloseButton As AVP_Robot_Project.ButtonIGCGControl
    'Friend WithEvents btnHome As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents txtCG As System.Windows.Forms.TextBox
    Friend WithEvents txtIG As System.Windows.Forms.TextBox
    Friend WithEvents bigcgCG As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents bigcgIG As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents HivacOpenButton As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents pnlRelay As System.Windows.Forms.Panel
    Friend WithEvents lblOnline As System.Windows.Forms.Label
    Friend WithEvents btnComStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnRelay As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents pnlCom As System.Windows.Forms.Panel

End Class
