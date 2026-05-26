<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopUpPanel
    Inherits AVPControls.AVPPopupForm

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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnMaintenance = New AVP_Robot_Project.SL_CustomButton
        Me.btnOffline = New AVP_Robot_Project.SL_CustomButton
        Me.btnOnline = New AVP_Robot_Project.SL_CustomButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnShutDownPower = New AVP_Robot_Project.SL_CustomButton
        Me.btnPumpPurge = New AVP_Robot_Project.SL_CustomButton
        Me.btnIGDegas = New AVP_Robot_Project.SL_CustomButton
        Me.btnAutoVent = New AVP_Robot_Project.SL_CustomButton
        Me.btnAutoPumpDown = New AVP_Robot_Project.SL_CustomButton
        Me.grbCryo = New System.Windows.Forms.GroupBox
        Me.txtCryoLifeTimeHour = New AVP_Robot_Project.SL_Textbox
        Me.txtRegenStatus = New AVP_Robot_Project.SL_Textbox
        Me.txtCryoRegenHour = New AVP_Robot_Project.SL_Textbox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnCryoOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnCryoOn = New AVP_Robot_Project.SL_CustomButton
        Me.btnAutoRegenOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnFastRegen = New AVP_Robot_Project.SL_CustomButton
        Me.btnAutoRegenOn = New AVP_Robot_Project.SL_CustomButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.grbWaterPump = New System.Windows.Forms.GroupBox
        Me.txtWaterPumpLifeTimeHour = New AVP_Robot_Project.SL_Textbox
        Me.txtWaterPumpRegenHour = New AVP_Robot_Project.SL_Textbox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnWPRegenOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnWaterPumpOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnWPRegenOn = New AVP_Robot_Project.SL_CustomButton
        Me.btnWaterPumpOn = New AVP_Robot_Project.SL_CustomButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.FormContainer.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbCryo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.grbWaterPump.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.Panel3)
        Me.FormContainer.Controls.Add(Me.Panel2)
        Me.FormContainer.Size = New System.Drawing.Size(322, 337)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btnMaintenance)
        Me.Panel2.Controls.Add(Me.btnOffline)
        Me.Panel2.Controls.Add(Me.btnOnline)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(322, 60)
        Me.Panel2.TabIndex = 41
        '
        'btnMaintenance
        '
        Me.btnMaintenance.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnMaintenance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMaintenance.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnMaintenance.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnMaintenance.FlatAppearance.BorderSize = 0
        Me.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaintenance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMaintenance.ForeColor = System.Drawing.Color.White
        Me.btnMaintenance.Location = New System.Drawing.Point(72, 13)
        Me.btnMaintenance.MessageBoxText = Nothing
        Me.btnMaintenance.Name = "btnMaintenance"
        Me.btnMaintenance.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnMaintenance.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnMaintenance.Size = New System.Drawing.Size(188, 35)
        Me.btnMaintenance.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[Error]
        Me.btnMaintenance.TabIndex = 77
        Me.btnMaintenance.Text = "Maintenance"
        Me.btnMaintenance.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnMaintenance.UseVisualStyleBackColor = True
        Me.btnMaintenance.ValueToBeSend = "On"
        Me.btnMaintenance.Visible = False
        '
        'btnOffline
        '
        Me.btnOffline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnOffline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOffline.Clickable = True
        Me.btnOffline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnOffline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOffline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOffline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnOffline.FlatAppearance.BorderSize = 0
        Me.btnOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOffline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnOffline.ForeColor = System.Drawing.Color.Black
        Me.btnOffline.Location = New System.Drawing.Point(175, 9)
        Me.btnOffline.MessageBoxText = Nothing
        Me.btnOffline.Name = "btnOffline"
        Me.btnOffline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnOffline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnOffline.Size = New System.Drawing.Size(147, 35)
        Me.btnOffline.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[On]
        Me.btnOffline.TabIndex = 75
        Me.btnOffline.Text = "Offline"
        Me.btnOffline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnOffline.UseClickedEventInForm = True
        Me.btnOffline.UseVisualStyleBackColor = True
        Me.btnOffline.ValueToBeSend = "Off"
        '
        'btnOnline
        '
        Me.btnOnline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOnline.Clickable = True
        Me.btnOnline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnOnline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOnline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnOnline.FlatAppearance.BorderSize = 0
        Me.btnOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnOnline.ForeColor = System.Drawing.Color.Black
        Me.btnOnline.Location = New System.Drawing.Point(12, 9)
        Me.btnOnline.MessageBoxText = Nothing
        Me.btnOnline.Name = "btnOnline"
        Me.btnOnline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnOnline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnOnline.Size = New System.Drawing.Size(148, 35)
        Me.btnOnline.TabIndex = 74
        Me.btnOnline.Text = "Online"
        Me.btnOnline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnOnline.UseClickedEventInForm = True
        Me.btnOnline.UseVisualStyleBackColor = True
        Me.btnOnline.ValueToBeSend = "On"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnShutDownPower)
        Me.GroupBox1.Controls.Add(Me.btnPumpPurge)
        Me.GroupBox1.Controls.Add(Me.btnIGDegas)
        Me.GroupBox1.Controls.Add(Me.btnAutoVent)
        Me.GroupBox1.Controls.Add(Me.btnAutoPumpDown)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 272)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chamber"
        '
        'btnShutDownPower
        '
        Me.btnShutDownPower.BackColor = System.Drawing.Color.Transparent
        Me.btnShutDownPower.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnShutDownPower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShutDownPower.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnShutDownPower.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnShutDownPower.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShutDownPower.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnShutDownPower.FlatAppearance.BorderSize = 0
        Me.btnShutDownPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShutDownPower.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShutDownPower.ForeColor = System.Drawing.Color.Black
        Me.btnShutDownPower.Location = New System.Drawing.Point(62, 229)
        Me.btnShutDownPower.MessageBoxText = Nothing
        Me.btnShutDownPower.Name = "btnShutDownPower"
        Me.btnShutDownPower.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnShutDownPower.OffText = "Shut Down Power"
        Me.btnShutDownPower.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnShutDownPower.OnText = "Shut Down Power"
        Me.btnShutDownPower.Size = New System.Drawing.Size(188, 35)
        Me.btnShutDownPower.TabIndex = 76
        Me.btnShutDownPower.Text = "Shut Down Power"
        Me.btnShutDownPower.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnShutDownPower.UseClickedEventInForm = True
        Me.btnShutDownPower.UseVisualStyleBackColor = False
        Me.btnShutDownPower.ValueToBeSend = "On"
        '
        'btnPumpPurge
        '
        Me.btnPumpPurge.BackColor = System.Drawing.Color.Transparent
        Me.btnPumpPurge.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnPumpPurge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPumpPurge.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnPumpPurge.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPumpPurge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPumpPurge.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnPumpPurge.FlatAppearance.BorderSize = 0
        Me.btnPumpPurge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPumpPurge.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPumpPurge.ForeColor = System.Drawing.Color.Black
        Me.btnPumpPurge.Location = New System.Drawing.Point(62, 179)
        Me.btnPumpPurge.MessageBoxText = Nothing
        Me.btnPumpPurge.Name = "btnPumpPurge"
        Me.btnPumpPurge.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnPumpPurge.OffText = "Pump Purge"
        Me.btnPumpPurge.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnPumpPurge.OnText = "Abort Pump Purge"
        Me.btnPumpPurge.Size = New System.Drawing.Size(188, 35)
        Me.btnPumpPurge.TabIndex = 76
        Me.btnPumpPurge.Text = "Pump Purge"
        Me.btnPumpPurge.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnPumpPurge.UseClickedEventInForm = True
        Me.btnPumpPurge.UseVisualStyleBackColor = False
        Me.btnPumpPurge.ValueToBeSend = "On"
        '
        'btnIGDegas
        '
        Me.btnIGDegas.BackColor = System.Drawing.Color.Transparent
        Me.btnIGDegas.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnIGDegas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIGDegas.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnIGDegas.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnIGDegas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIGDegas.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnIGDegas.FlatAppearance.BorderSize = 0
        Me.btnIGDegas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIGDegas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIGDegas.ForeColor = System.Drawing.Color.Black
        Me.btnIGDegas.Location = New System.Drawing.Point(62, 129)
        Me.btnIGDegas.MessageBoxText = Nothing
        Me.btnIGDegas.Name = "btnIGDegas"
        Me.btnIGDegas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnIGDegas.OffText = "IG Degas"
        Me.btnIGDegas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnIGDegas.OnText = "Abort IG Degas"
        Me.btnIGDegas.Size = New System.Drawing.Size(188, 35)
        Me.btnIGDegas.TabIndex = 76
        Me.btnIGDegas.Text = "IG Degas"
        Me.btnIGDegas.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnIGDegas.UseClickedEventInForm = True
        Me.btnIGDegas.UseVisualStyleBackColor = False
        Me.btnIGDegas.ValueToBeSend = "On"
        '
        'btnAutoVent
        '
        Me.btnAutoVent.BackColor = System.Drawing.Color.Transparent
        Me.btnAutoVent.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAutoVent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoVent.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAutoVent.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoVent.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnAutoVent.FlatAppearance.BorderSize = 0
        Me.btnAutoVent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoVent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoVent.ForeColor = System.Drawing.Color.Black
        Me.btnAutoVent.Location = New System.Drawing.Point(62, 79)
        Me.btnAutoVent.MessageBoxText = Nothing
        Me.btnAutoVent.Name = "btnAutoVent"
        Me.btnAutoVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAutoVent.OffText = "Auto Vent"
        Me.btnAutoVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnAutoVent.OnText = "Abort Auto Vent"
        Me.btnAutoVent.Size = New System.Drawing.Size(188, 35)
        Me.btnAutoVent.TabIndex = 76
        Me.btnAutoVent.Text = "Auto Vent"
        Me.btnAutoVent.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnAutoVent.UseClickedEventInForm = True
        Me.btnAutoVent.UseVisualStyleBackColor = False
        Me.btnAutoVent.ValueToBeSend = "On"
        '
        'btnAutoPumpDown
        '
        Me.btnAutoPumpDown.BackColor = System.Drawing.Color.Transparent
        Me.btnAutoPumpDown.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAutoPumpDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoPumpDown.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAutoPumpDown.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoPumpDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoPumpDown.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnAutoPumpDown.FlatAppearance.BorderSize = 0
        Me.btnAutoPumpDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoPumpDown.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoPumpDown.ForeColor = System.Drawing.Color.Black
        Me.btnAutoPumpDown.Location = New System.Drawing.Point(62, 29)
        Me.btnAutoPumpDown.MessageBoxText = Nothing
        Me.btnAutoPumpDown.Name = "btnAutoPumpDown"
        Me.btnAutoPumpDown.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAutoPumpDown.OffText = "Auto Pump Down"
        Me.btnAutoPumpDown.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnAutoPumpDown.OnText = "Abort Auto Pump Down"
        Me.btnAutoPumpDown.Size = New System.Drawing.Size(188, 35)
        Me.btnAutoPumpDown.TabIndex = 76
        Me.btnAutoPumpDown.Text = "Auto Pump Down"
        Me.btnAutoPumpDown.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnAutoPumpDown.UseClickedEventInForm = True
        Me.btnAutoPumpDown.UseVisualStyleBackColor = False
        Me.btnAutoPumpDown.ValueToBeSend = "On"
        '
        'grbCryo
        '
        Me.grbCryo.BackColor = System.Drawing.Color.Transparent
        Me.grbCryo.Controls.Add(Me.txtCryoLifeTimeHour)
        Me.grbCryo.Controls.Add(Me.txtRegenStatus)
        Me.grbCryo.Controls.Add(Me.txtCryoRegenHour)
        Me.grbCryo.Controls.Add(Me.Label9)
        Me.grbCryo.Controls.Add(Me.Label5)
        Me.grbCryo.Controls.Add(Me.btnCryoOff)
        Me.grbCryo.Controls.Add(Me.btnCryoOn)
        Me.grbCryo.Controls.Add(Me.btnAutoRegenOff)
        Me.grbCryo.Controls.Add(Me.btnFastRegen)
        Me.grbCryo.Controls.Add(Me.btnAutoRegenOn)
        Me.grbCryo.Controls.Add(Me.Label6)
        Me.grbCryo.Dock = System.Windows.Forms.DockStyle.Left
        Me.grbCryo.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbCryo.Location = New System.Drawing.Point(325, 0)
        Me.grbCryo.Name = "grbCryo"
        Me.grbCryo.Size = New System.Drawing.Size(377, 272)
        Me.grbCryo.TabIndex = 43
        Me.grbCryo.TabStop = False
        Me.grbCryo.Text = "Cryo"
        Me.grbCryo.Visible = False
        '
        'txtCryoLifeTimeHour
        '
        Me.txtCryoLifeTimeHour.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCryoLifeTimeHour.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCryoLifeTimeHour.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCryoLifeTimeHour.IsReadBack = True
        Me.txtCryoLifeTimeHour.Location = New System.Drawing.Point(282, 29)
        Me.txtCryoLifeTimeHour.Name = "txtCryoLifeTimeHour"
        Me.txtCryoLifeTimeHour.ReadOnly = True
        Me.txtCryoLifeTimeHour.Size = New System.Drawing.Size(82, 24)
        Me.txtCryoLifeTimeHour.TabIndex = 38
        Me.txtCryoLifeTimeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCryoLifeTimeHour.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCryoLifeTimeHour.UseScientificFormat = True
        '
        'txtRegenStatus
        '
        Me.txtRegenStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRegenStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRegenStatus.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRegenStatus.IsReadBack = True
        Me.txtRegenStatus.Location = New System.Drawing.Point(95, 59)
        Me.txtRegenStatus.Name = "txtRegenStatus"
        Me.txtRegenStatus.ReadOnly = True
        Me.txtRegenStatus.Size = New System.Drawing.Size(269, 24)
        Me.txtRegenStatus.TabIndex = 38
        Me.txtRegenStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRegenStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRegenStatus.UseScientificFormat = True
        '
        'txtCryoRegenHour
        '
        Me.txtCryoRegenHour.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCryoRegenHour.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCryoRegenHour.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCryoRegenHour.IsReadBack = True
        Me.txtCryoRegenHour.Location = New System.Drawing.Point(95, 29)
        Me.txtCryoRegenHour.Name = "txtCryoRegenHour"
        Me.txtCryoRegenHour.ReadOnly = True
        Me.txtCryoRegenHour.Size = New System.Drawing.Size(82, 24)
        Me.txtCryoRegenHour.TabIndex = 38
        Me.txtCryoRegenHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCryoRegenHour.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCryoRegenHour.UseScientificFormat = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 19)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "Regen Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 19)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Regen Hours"
        '
        'btnCryoOff
        '
        Me.btnCryoOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCryoOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoOff.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnCryoOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCryoOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnCryoOff.FlatAppearance.BorderSize = 0
        Me.btnCryoOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCryoOff.ForeColor = System.Drawing.Color.Black
        Me.btnCryoOff.Location = New System.Drawing.Point(217, 101)
        Me.btnCryoOff.MessageBoxText = Nothing
        Me.btnCryoOff.Name = "btnCryoOff"
        Me.btnCryoOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCryoOff.OffText = "Off"
        Me.btnCryoOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnCryoOff.OnText = "Off"
        Me.btnCryoOff.Size = New System.Drawing.Size(147, 35)
        Me.btnCryoOff.TabIndex = 76
        Me.btnCryoOff.Text = "Off"
        Me.btnCryoOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnCryoOff.UseClickedEventInForm = True
        Me.btnCryoOff.UseVisualStyleBackColor = True
        Me.btnCryoOff.ValueToBeSend = "Off"
        '
        'btnCryoOn
        '
        Me.btnCryoOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCryoOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoOn.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnCryoOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCryoOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnCryoOn.FlatAppearance.BorderSize = 0
        Me.btnCryoOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCryoOn.ForeColor = System.Drawing.Color.Black
        Me.btnCryoOn.Location = New System.Drawing.Point(10, 101)
        Me.btnCryoOn.MessageBoxText = Nothing
        Me.btnCryoOn.Name = "btnCryoOn"
        Me.btnCryoOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnCryoOn.OffText = "On"
        Me.btnCryoOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnCryoOn.OnText = "On"
        Me.btnCryoOn.Size = New System.Drawing.Size(147, 35)
        Me.btnCryoOn.TabIndex = 77
        Me.btnCryoOn.Text = "On"
        Me.btnCryoOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnCryoOn.UseClickedEventInForm = True
        Me.btnCryoOn.UseVisualStyleBackColor = True
        Me.btnCryoOn.ValueToBeSend = "On"
        '
        'btnAutoRegenOff
        '
        Me.btnAutoRegenOff.BackColor = System.Drawing.Color.Transparent
        Me.btnAutoRegenOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAutoRegenOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoRegenOff.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAutoRegenOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoRegenOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoRegenOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnAutoRegenOff.FlatAppearance.BorderSize = 0
        Me.btnAutoRegenOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoRegenOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoRegenOff.ForeColor = System.Drawing.Color.Black
        Me.btnAutoRegenOff.Location = New System.Drawing.Point(217, 152)
        Me.btnAutoRegenOff.MessageBoxText = Nothing
        Me.btnAutoRegenOff.Name = "btnAutoRegenOff"
        Me.btnAutoRegenOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAutoRegenOff.OffText = "Auto Regen Off"
        Me.btnAutoRegenOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnAutoRegenOff.OnText = "Auto Regen Off"
        Me.btnAutoRegenOff.Size = New System.Drawing.Size(147, 35)
        Me.btnAutoRegenOff.TabIndex = 74
        Me.btnAutoRegenOff.Text = "Auto Regen Off"
        Me.btnAutoRegenOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnAutoRegenOff.UseClickedEventInForm = True
        Me.btnAutoRegenOff.UseVisualStyleBackColor = False
        Me.btnAutoRegenOff.ValueToBeSend = "Off"
        '
        'btnFastRegen
        '
        Me.btnFastRegen.BackColor = System.Drawing.Color.Transparent
        Me.btnFastRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnFastRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFastRegen.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnFastRegen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnFastRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFastRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnFastRegen.FlatAppearance.BorderSize = 0
        Me.btnFastRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFastRegen.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFastRegen.ForeColor = System.Drawing.Color.Black
        Me.btnFastRegen.Location = New System.Drawing.Point(10, 203)
        Me.btnFastRegen.MessageBoxText = Nothing
        Me.btnFastRegen.Name = "btnFastRegen"
        Me.btnFastRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnFastRegen.OffText = "Fast Regen"
        Me.btnFastRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnFastRegen.OnText = "Fast Regen"
        Me.btnFastRegen.Size = New System.Drawing.Size(147, 35)
        Me.btnFastRegen.TabIndex = 75
        Me.btnFastRegen.Text = "Fast Regen"
        Me.btnFastRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnFastRegen.UseClickedEventInForm = True
        Me.btnFastRegen.UseVisualStyleBackColor = False
        Me.btnFastRegen.ValueToBeSend = "On"
        '
        'btnAutoRegenOn
        '
        Me.btnAutoRegenOn.BackColor = System.Drawing.Color.Transparent
        Me.btnAutoRegenOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAutoRegenOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoRegenOn.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAutoRegenOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoRegenOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoRegenOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnAutoRegenOn.FlatAppearance.BorderSize = 0
        Me.btnAutoRegenOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoRegenOn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoRegenOn.ForeColor = System.Drawing.Color.Black
        Me.btnAutoRegenOn.Location = New System.Drawing.Point(10, 152)
        Me.btnAutoRegenOn.MessageBoxText = Nothing
        Me.btnAutoRegenOn.Name = "btnAutoRegenOn"
        Me.btnAutoRegenOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAutoRegenOn.OffText = "Auto Regen On"
        Me.btnAutoRegenOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnAutoRegenOn.OnText = "Auto Regen On"
        Me.btnAutoRegenOn.Size = New System.Drawing.Size(147, 35)
        Me.btnAutoRegenOn.TabIndex = 75
        Me.btnAutoRegenOn.Text = "Auto Regen On"
        Me.btnAutoRegenOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnAutoRegenOn.UseClickedEventInForm = True
        Me.btnAutoRegenOn.UseVisualStyleBackColor = False
        Me.btnAutoRegenOn.ValueToBeSend = "On"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(178, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 19)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "LifeTime Hours"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.grbWaterPump)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.grbCryo)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(322, 277)
        Me.Panel3.TabIndex = 44
        '
        'grbWaterPump
        '
        Me.grbWaterPump.BackColor = System.Drawing.Color.Transparent
        Me.grbWaterPump.Controls.Add(Me.txtWaterPumpLifeTimeHour)
        Me.grbWaterPump.Controls.Add(Me.txtWaterPumpRegenHour)
        Me.grbWaterPump.Controls.Add(Me.Label8)
        Me.grbWaterPump.Controls.Add(Me.btnWPRegenOff)
        Me.grbWaterPump.Controls.Add(Me.btnWaterPumpOff)
        Me.grbWaterPump.Controls.Add(Me.btnWPRegenOn)
        Me.grbWaterPump.Controls.Add(Me.btnWaterPumpOn)
        Me.grbWaterPump.Controls.Add(Me.Label7)
        Me.grbWaterPump.Dock = System.Windows.Forms.DockStyle.Left
        Me.grbWaterPump.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbWaterPump.Location = New System.Drawing.Point(710, 0)
        Me.grbWaterPump.Name = "grbWaterPump"
        Me.grbWaterPump.Size = New System.Drawing.Size(391, 272)
        Me.grbWaterPump.TabIndex = 43
        Me.grbWaterPump.TabStop = False
        Me.grbWaterPump.Text = "Water Pump"
        Me.grbWaterPump.Visible = False
        '
        'txtWaterPumpLifeTimeHour
        '
        Me.txtWaterPumpLifeTimeHour.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtWaterPumpLifeTimeHour.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtWaterPumpLifeTimeHour.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtWaterPumpLifeTimeHour.IsReadBack = True
        Me.txtWaterPumpLifeTimeHour.Location = New System.Drawing.Point(296, 30)
        Me.txtWaterPumpLifeTimeHour.Name = "txtWaterPumpLifeTimeHour"
        Me.txtWaterPumpLifeTimeHour.ReadOnly = True
        Me.txtWaterPumpLifeTimeHour.Size = New System.Drawing.Size(82, 24)
        Me.txtWaterPumpLifeTimeHour.TabIndex = 38
        Me.txtWaterPumpLifeTimeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtWaterPumpLifeTimeHour.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtWaterPumpLifeTimeHour.UseScientificFormat = True
        '
        'txtWaterPumpRegenHour
        '
        Me.txtWaterPumpRegenHour.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtWaterPumpRegenHour.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtWaterPumpRegenHour.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtWaterPumpRegenHour.IsReadBack = True
        Me.txtWaterPumpRegenHour.Location = New System.Drawing.Point(102, 30)
        Me.txtWaterPumpRegenHour.Name = "txtWaterPumpRegenHour"
        Me.txtWaterPumpRegenHour.ReadOnly = True
        Me.txtWaterPumpRegenHour.Size = New System.Drawing.Size(82, 24)
        Me.txtWaterPumpRegenHour.TabIndex = 38
        Me.txtWaterPumpRegenHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtWaterPumpRegenHour.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtWaterPumpRegenHour.UseScientificFormat = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 19)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Regen Hours"
        '
        'btnWPRegenOff
        '
        Me.btnWPRegenOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnWPRegenOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWPRegenOff.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnWPRegenOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnWPRegenOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWPRegenOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnWPRegenOff.FlatAppearance.BorderSize = 0
        Me.btnWPRegenOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWPRegenOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnWPRegenOff.ForeColor = System.Drawing.Color.Black
        Me.btnWPRegenOff.Location = New System.Drawing.Point(231, 153)
        Me.btnWPRegenOff.MessageBoxText = Nothing
        Me.btnWPRegenOff.Name = "btnWPRegenOff"
        Me.btnWPRegenOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnWPRegenOff.OffText = "Auto Regen Off"
        Me.btnWPRegenOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnWPRegenOff.OnText = "Auto Regen Off"
        Me.btnWPRegenOff.Size = New System.Drawing.Size(147, 35)
        Me.btnWPRegenOff.TabIndex = 76
        Me.btnWPRegenOff.Text = "Auto Regen Off"
        Me.btnWPRegenOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnWPRegenOff.UseClickedEventInForm = True
        Me.btnWPRegenOff.UseVisualStyleBackColor = True
        Me.btnWPRegenOff.ValueToBeSend = "Off"
        '
        'btnWaterPumpOff
        '
        Me.btnWaterPumpOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnWaterPumpOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWaterPumpOff.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWaterPumpOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnWaterPumpOff.FlatAppearance.BorderSize = 0
        Me.btnWaterPumpOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWaterPumpOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnWaterPumpOff.ForeColor = System.Drawing.Color.Black
        Me.btnWaterPumpOff.Location = New System.Drawing.Point(231, 101)
        Me.btnWaterPumpOff.MessageBoxText = Nothing
        Me.btnWaterPumpOff.Name = "btnWaterPumpOff"
        Me.btnWaterPumpOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnWaterPumpOff.OffText = "Off"
        Me.btnWaterPumpOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnWaterPumpOff.OnText = "Off"
        Me.btnWaterPumpOff.Size = New System.Drawing.Size(147, 35)
        Me.btnWaterPumpOff.TabIndex = 76
        Me.btnWaterPumpOff.Text = "Off"
        Me.btnWaterPumpOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnWaterPumpOff.UseClickedEventInForm = True
        Me.btnWaterPumpOff.UseVisualStyleBackColor = True
        Me.btnWaterPumpOff.ValueToBeSend = "Off"
        '
        'btnWPRegenOn
        '
        Me.btnWPRegenOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnWPRegenOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWPRegenOn.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnWPRegenOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnWPRegenOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWPRegenOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnWPRegenOn.FlatAppearance.BorderSize = 0
        Me.btnWPRegenOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWPRegenOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnWPRegenOn.ForeColor = System.Drawing.Color.Black
        Me.btnWPRegenOn.Location = New System.Drawing.Point(16, 153)
        Me.btnWPRegenOn.MessageBoxText = Nothing
        Me.btnWPRegenOn.Name = "btnWPRegenOn"
        Me.btnWPRegenOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnWPRegenOn.OffText = "Auto Regen On"
        Me.btnWPRegenOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnWPRegenOn.OnText = "Auto Regen On"
        Me.btnWPRegenOn.Size = New System.Drawing.Size(147, 35)
        Me.btnWPRegenOn.TabIndex = 77
        Me.btnWPRegenOn.Text = "Auto Regen On"
        Me.btnWPRegenOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnWPRegenOn.UseClickedEventInForm = True
        Me.btnWPRegenOn.UseVisualStyleBackColor = True
        Me.btnWPRegenOn.ValueToBeSend = "On"
        '
        'btnWaterPumpOn
        '
        Me.btnWaterPumpOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnWaterPumpOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWaterPumpOn.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWaterPumpOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_RedButton
        Me.btnWaterPumpOn.FlatAppearance.BorderSize = 0
        Me.btnWaterPumpOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWaterPumpOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnWaterPumpOn.ForeColor = System.Drawing.Color.Black
        Me.btnWaterPumpOn.Location = New System.Drawing.Point(16, 101)
        Me.btnWaterPumpOn.MessageBoxText = Nothing
        Me.btnWaterPumpOn.Name = "btnWaterPumpOn"
        Me.btnWaterPumpOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnWaterPumpOn.OffText = "On"
        Me.btnWaterPumpOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_GreenButton
        Me.btnWaterPumpOn.OnText = "On"
        Me.btnWaterPumpOn.Size = New System.Drawing.Size(147, 35)
        Me.btnWaterPumpOn.TabIndex = 77
        Me.btnWaterPumpOn.Text = "On"
        Me.btnWaterPumpOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnWaterPumpOn.UseClickedEventInForm = True
        Me.btnWaterPumpOn.UseVisualStyleBackColor = True
        Me.btnWaterPumpOn.ValueToBeSend = "On"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(189, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 19)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "LifeTime Hours"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(702, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(8, 272)
        Me.Label3.TabIndex = 50
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(317, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(8, 272)
        Me.Label1.TabIndex = 49
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label4.Location = New System.Drawing.Point(0, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(322, 5)
        Me.Label4.TabIndex = 51
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(5, 272)
        Me.Label2.TabIndex = 48
        '
        'PopUpPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.WhitePanel
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(332, 382)
        Me.Name = "PopUpPanel"
        Me.Text = "PVDPopUpPanel"
        Me.FormContainer.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grbCryo.ResumeLayout(False)
        Me.grbCryo.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.grbWaterPump.ResumeLayout(False)
        Me.grbWaterPump.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnOffline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnOnline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grbCryo As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents grbWaterPump As System.Windows.Forms.GroupBox
    Friend WithEvents btnIGDegas As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAutoVent As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAutoPumpDown As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtCryoRegenHour As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnCryoOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnCryoOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAutoRegenOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnFastRegen As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAutoRegenOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtWaterPumpRegenHour As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnWaterPumpOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnWaterPumpOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnShutDownPower As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnPumpPurge As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnWPRegenOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnWPRegenOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCryoLifeTimeHour As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtWaterPumpLifeTimeHour As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRegenStatus As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnMaintenance As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
