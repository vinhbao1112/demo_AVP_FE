<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_PopUpPanel
    Inherits AVPControls.AVPPopupForm

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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.grbWaterPump = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtWaterPump = New AVP_Robot_Project.SL_Textbox
        Me.btnWaterPumpOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnWaterPumpOnOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnCryoRegenValve = New AVP_Robot_Project.SL_CustomButton
        Me.btnAutoPowerDown = New AVP_Robot_Project.SL_CustomButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.grbCryo = New System.Windows.Forms.GroupBox
        Me.txtRegenStatus = New AVP_Robot_Project.SL_Textbox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCryo = New AVP_Robot_Project.SL_Textbox
        Me.btnCryoOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnCryoOnOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnRoughValveClose = New AVP_Robot_Project.SL_CustomButton
        Me.btnCryoPurgeOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnRoughValveOpen = New AVP_Robot_Project.SL_CustomButton
        Me.btnCryoPurge = New AVP_Robot_Project.SL_CustomButton
        Me.btnAutoRegenOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnAutoRegen = New AVP_Robot_Project.SL_CustomButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.grbChamber = New System.Windows.Forms.GroupBox
        Me.btnAutoVentGeneral = New AVP_Robot_Project.SL_CustomButton
        Me.btnAutoPumpDownGeneral = New AVP_Robot_Project.SL_CustomButton
        Me.btnPumpdownCurve = New AVP_Robot_Project.SL_CustomButton
        Me.btnIGDegas = New AVP_Robot_Project.SL_CustomButton
        Me.btnPumpPurge = New AVP_Robot_Project.SL_CustomButton
        Me.btnRateOfRise = New AVP_Robot_Project.SL_CustomButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.SLSystemPanel = New System.Windows.Forms.Panel
        Me.btnOffline = New AVP_Robot_Project.SL_CustomButton
        Me.btnMaintenance = New AVP_Robot_Project.SL_CustomButton
        Me.btnOnline = New AVP_Robot_Project.SL_CustomButton
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.FormContainer.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grbWaterPump.SuspendLayout()
        Me.grbCryo.SuspendLayout()
        Me.grbChamber.SuspendLayout()
        Me.SLSystemPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.Panel2)
        Me.FormContainer.Size = New System.Drawing.Size(840, 366)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.grbWaterPump)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.grbCryo)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.grbChamber)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.SLSystemPanel)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(840, 366)
        Me.Panel2.TabIndex = 40
        '
        'grbWaterPump
        '
        Me.grbWaterPump.Controls.Add(Me.Label4)
        Me.grbWaterPump.Controls.Add(Me.txtWaterPump)
        Me.grbWaterPump.Controls.Add(Me.btnWaterPumpOff)
        Me.grbWaterPump.Controls.Add(Me.btnWaterPumpOnOff)
        Me.grbWaterPump.Controls.Add(Me.btnCryoRegenValve)
        Me.grbWaterPump.Controls.Add(Me.btnAutoPowerDown)
        Me.grbWaterPump.Dock = System.Windows.Forms.DockStyle.Left
        Me.grbWaterPump.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbWaterPump.Location = New System.Drawing.Point(574, 50)
        Me.grbWaterPump.Name = "grbWaterPump"
        Me.grbWaterPump.Size = New System.Drawing.Size(258, 311)
        Me.grbWaterPump.TabIndex = 79
        Me.grbWaterPump.TabStop = False
        Me.grbWaterPump.Text = "Water Pump"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(200, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 19)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "(K)"
        '
        'txtWaterPump
        '
        Me.txtWaterPump.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtWaterPump.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtWaterPump.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtWaterPump.IsReadBack = True
        Me.txtWaterPump.Location = New System.Drawing.Point(67, 23)
        Me.txtWaterPump.Name = "txtWaterPump"
        Me.txtWaterPump.ReadOnly = True
        Me.txtWaterPump.Size = New System.Drawing.Size(126, 24)
        Me.txtWaterPump.TabIndex = 37
        Me.txtWaterPump.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtWaterPump.UseScientificFormat = True
        '
        'btnWaterPumpOff
        '
        Me.btnWaterPumpOff.AccessibleName = "Water Pump Off"
        Me.btnWaterPumpOff.BackColor = System.Drawing.Color.Transparent
        Me.btnWaterPumpOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnWaterPumpOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWaterPumpOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWaterPumpOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnWaterPumpOff.FlatAppearance.BorderSize = 0
        Me.btnWaterPumpOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWaterPumpOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWaterPumpOff.ForeColor = System.Drawing.Color.Black
        Me.btnWaterPumpOff.Location = New System.Drawing.Point(136, 68)
        Me.btnWaterPumpOff.LogSource = "Water Pump On"
        Me.btnWaterPumpOff.MessageBoxText = Nothing
        Me.btnWaterPumpOff.Name = "btnWaterPumpOff"
        Me.btnWaterPumpOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnWaterPumpOff.OffText = "Off"
        Me.btnWaterPumpOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnWaterPumpOff.OnText = "Off"
        Me.btnWaterPumpOff.Size = New System.Drawing.Size(105, 35)
        Me.btnWaterPumpOff.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnWaterPumpOff.TabIndex = 36
        Me.btnWaterPumpOff.Text = "Off"
        Me.btnWaterPumpOff.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnWaterPumpOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnWaterPumpOff.UseClickedEventInForm = True
        Me.btnWaterPumpOff.UseVisualStyleBackColor = False
        Me.btnWaterPumpOff.ValueToBeSend = "Off"
        '
        'btnWaterPumpOnOff
        '
        Me.btnWaterPumpOnOff.AccessibleName = "Water Pump On"
        Me.btnWaterPumpOnOff.BackColor = System.Drawing.Color.Transparent
        Me.btnWaterPumpOnOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnWaterPumpOnOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWaterPumpOnOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOnOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWaterPumpOnOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnWaterPumpOnOff.FlatAppearance.BorderSize = 0
        Me.btnWaterPumpOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWaterPumpOnOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWaterPumpOnOff.ForeColor = System.Drawing.Color.Black
        Me.btnWaterPumpOnOff.Location = New System.Drawing.Point(16, 68)
        Me.btnWaterPumpOnOff.LogSource = "Water Pump Off"
        Me.btnWaterPumpOnOff.MessageBoxText = Nothing
        Me.btnWaterPumpOnOff.Name = "btnWaterPumpOnOff"
        Me.btnWaterPumpOnOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnWaterPumpOnOff.OffText = "On"
        Me.btnWaterPumpOnOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnWaterPumpOnOff.OnText = "On"
        Me.btnWaterPumpOnOff.Size = New System.Drawing.Size(105, 35)
        Me.btnWaterPumpOnOff.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnWaterPumpOnOff.TabIndex = 36
        Me.btnWaterPumpOnOff.Text = "On"
        Me.btnWaterPumpOnOff.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnWaterPumpOnOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnWaterPumpOnOff.UseClickedEventInForm = True
        Me.btnWaterPumpOnOff.UseVisualStyleBackColor = False
        Me.btnWaterPumpOnOff.ValueToBeSend = "On"
        '
        'btnCryoRegenValve
        '
        Me.btnCryoRegenValve.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoRegenValve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoRegenValve.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCryoRegenValve.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoRegenValve.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnCryoRegenValve.FlatAppearance.BorderSize = 0
        Me.btnCryoRegenValve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoRegenValve.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCryoRegenValve.ForeColor = System.Drawing.Color.Black
        Me.btnCryoRegenValve.Location = New System.Drawing.Point(136, 118)
        Me.btnCryoRegenValve.MessageBoxText = Nothing
        Me.btnCryoRegenValve.Name = "btnCryoRegenValve"
        Me.btnCryoRegenValve.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoRegenValve.OffText = "Open Cryo Regen Valve"
        Me.btnCryoRegenValve.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnCryoRegenValve.OnText = "Close Cryo Regen Valve"
        Me.btnCryoRegenValve.Size = New System.Drawing.Size(105, 35)
        Me.btnCryoRegenValve.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnCryoRegenValve.TabIndex = 73
        Me.btnCryoRegenValve.Text = "Open Cryo Regen Valve"
        Me.btnCryoRegenValve.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnCryoRegenValve.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnCryoRegenValve.UseClickedEventInForm = True
        Me.btnCryoRegenValve.UseVisualStyleBackColor = True
        Me.btnCryoRegenValve.ValueToBeSend = ""
        Me.btnCryoRegenValve.Visible = False
        '
        'btnAutoPowerDown
        '
        Me.btnAutoPowerDown.BackColor = System.Drawing.Color.Transparent
        Me.btnAutoPowerDown.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoPowerDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoPowerDown.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoPowerDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoPowerDown.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnAutoPowerDown.FlatAppearance.BorderSize = 0
        Me.btnAutoPowerDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoPowerDown.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoPowerDown.ForeColor = System.Drawing.Color.Black
        Me.btnAutoPowerDown.Location = New System.Drawing.Point(16, 118)
        Me.btnAutoPowerDown.LogSource = "Water Pump Auto Power"
        Me.btnAutoPowerDown.MessageBoxText = Nothing
        Me.btnAutoPowerDown.Name = "btnAutoPowerDown"
        Me.btnAutoPowerDown.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoPowerDown.OffText = "Auto Power Down On"
        Me.btnAutoPowerDown.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnAutoPowerDown.OnText = "Auto Power Down Off"
        Me.btnAutoPowerDown.Size = New System.Drawing.Size(105, 35)
        Me.btnAutoPowerDown.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnAutoPowerDown.TabIndex = 36
        Me.btnAutoPowerDown.Text = "Auto Power Down On"
        Me.btnAutoPowerDown.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnAutoPowerDown.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnAutoPowerDown.UseClickedEventInForm = True
        Me.btnAutoPowerDown.UseVisualStyleBackColor = False
        Me.btnAutoPowerDown.ValueToBeSend = "On"
        Me.btnAutoPowerDown.Visible = False
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(564, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 311)
        Me.Label3.TabIndex = 78
        '
        'grbCryo
        '
        Me.grbCryo.Controls.Add(Me.txtRegenStatus)
        Me.grbCryo.Controls.Add(Me.Label10)
        Me.grbCryo.Controls.Add(Me.Label7)
        Me.grbCryo.Controls.Add(Me.txtCryo)
        Me.grbCryo.Controls.Add(Me.btnCryoOff)
        Me.grbCryo.Controls.Add(Me.btnCryoOnOff)
        Me.grbCryo.Controls.Add(Me.btnRoughValveClose)
        Me.grbCryo.Controls.Add(Me.btnCryoPurgeOff)
        Me.grbCryo.Controls.Add(Me.btnRoughValveOpen)
        Me.grbCryo.Controls.Add(Me.btnCryoPurge)
        Me.grbCryo.Controls.Add(Me.btnAutoRegenOff)
        Me.grbCryo.Controls.Add(Me.btnAutoRegen)
        Me.grbCryo.Dock = System.Windows.Forms.DockStyle.Left
        Me.grbCryo.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbCryo.Location = New System.Drawing.Point(230, 50)
        Me.grbCryo.Name = "grbCryo"
        Me.grbCryo.Size = New System.Drawing.Size(334, 311)
        Me.grbCryo.TabIndex = 77
        Me.grbCryo.TabStop = False
        Me.grbCryo.Text = "Cryo"
        '
        'txtRegenStatus
        '
        Me.txtRegenStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRegenStatus.Clickable = False
        Me.txtRegenStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRegenStatus.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRegenStatus.IsReadBack = True
        Me.txtRegenStatus.Location = New System.Drawing.Point(96, 56)
        Me.txtRegenStatus.Name = "txtRegenStatus"
        Me.txtRegenStatus.ReadOnly = True
        Me.txtRegenStatus.Size = New System.Drawing.Size(228, 24)
        Me.txtRegenStatus.TabIndex = 80
        Me.txtRegenStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRegenStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRegenStatus.UseScientificFormat = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 17)
        Me.Label10.TabIndex = 79
        Me.Label10.Text = "Regen Status"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(248, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 19)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "(K)"
        '
        'txtCryo
        '
        Me.txtCryo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCryo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCryo.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCryo.IsReadBack = True
        Me.txtCryo.Location = New System.Drawing.Point(97, 23)
        Me.txtCryo.Name = "txtCryo"
        Me.txtCryo.ReadOnly = True
        Me.txtCryo.Size = New System.Drawing.Size(135, 24)
        Me.txtCryo.TabIndex = 37
        Me.txtCryo.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCryo.UseScientificFormat = True
        '
        'btnCryoOff
        '
        Me.btnCryoOff.AccessibleName = "Cryo Off"
        Me.btnCryoOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCryoOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnCryoOff.FlatAppearance.BorderSize = 0
        Me.btnCryoOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCryoOff.ForeColor = System.Drawing.Color.Black
        Me.btnCryoOff.Location = New System.Drawing.Point(177, 91)
        Me.btnCryoOff.LogSource = "Cryo On"
        Me.btnCryoOff.MessageBoxText = Nothing
        Me.btnCryoOff.Name = "btnCryoOff"
        Me.btnCryoOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoOff.OffText = "Off"
        Me.btnCryoOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnCryoOff.OnText = "Off"
        Me.btnCryoOff.Size = New System.Drawing.Size(147, 35)
        Me.btnCryoOff.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnCryoOff.TabIndex = 73
        Me.btnCryoOff.Text = "Off"
        Me.btnCryoOff.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnCryoOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnCryoOff.UseVisualStyleBackColor = True
        Me.btnCryoOff.ValueToBeSend = "Off"
        '
        'btnCryoOnOff
        '
        Me.btnCryoOnOff.AccessibleName = "Cryo On"
        Me.btnCryoOnOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoOnOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoOnOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCryoOnOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoOnOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnCryoOnOff.FlatAppearance.BorderSize = 0
        Me.btnCryoOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoOnOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCryoOnOff.ForeColor = System.Drawing.Color.Black
        Me.btnCryoOnOff.Location = New System.Drawing.Point(9, 91)
        Me.btnCryoOnOff.LogSource = "Cryo Off"
        Me.btnCryoOnOff.MessageBoxText = Nothing
        Me.btnCryoOnOff.Name = "btnCryoOnOff"
        Me.btnCryoOnOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoOnOff.OffText = "On"
        Me.btnCryoOnOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnCryoOnOff.OnText = "On"
        Me.btnCryoOnOff.Size = New System.Drawing.Size(148, 35)
        Me.btnCryoOnOff.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnCryoOnOff.TabIndex = 73
        Me.btnCryoOnOff.Text = "On"
        Me.btnCryoOnOff.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnCryoOnOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnCryoOnOff.UseClickedEventInForm = True
        Me.btnCryoOnOff.UseVisualStyleBackColor = True
        Me.btnCryoOnOff.ValueToBeSend = "On"
        '
        'btnRoughValveClose
        '
        Me.btnRoughValveClose.AccessibleName = "Rough Valve Close"
        Me.btnRoughValveClose.BackColor = System.Drawing.Color.Transparent
        Me.btnRoughValveClose.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRoughValveClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRoughValveClose.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRoughValveClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRoughValveClose.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnRoughValveClose.FlatAppearance.BorderSize = 0
        Me.btnRoughValveClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRoughValveClose.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRoughValveClose.ForeColor = System.Drawing.Color.Black
        Me.btnRoughValveClose.Location = New System.Drawing.Point(177, 238)
        Me.btnRoughValveClose.MessageBoxText = Nothing
        Me.btnRoughValveClose.Name = "btnRoughValveClose"
        Me.btnRoughValveClose.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRoughValveClose.OffText = "Rough Valve Close"
        Me.btnRoughValveClose.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnRoughValveClose.OnText = "Rough Valve Close"
        Me.btnRoughValveClose.Size = New System.Drawing.Size(147, 35)
        Me.btnRoughValveClose.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnRoughValveClose.TabIndex = 36
        Me.btnRoughValveClose.Text = "Rough Valve Close"
        Me.btnRoughValveClose.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnRoughValveClose.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnRoughValveClose.UseVisualStyleBackColor = False
        Me.btnRoughValveClose.ValueToBeSend = "Off"
        '
        'btnCryoPurgeOff
        '
        Me.btnCryoPurgeOff.AccessibleName = "Purge Valve Close"
        Me.btnCryoPurgeOff.BackColor = System.Drawing.Color.Transparent
        Me.btnCryoPurgeOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoPurgeOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoPurgeOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCryoPurgeOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoPurgeOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnCryoPurgeOff.FlatAppearance.BorderSize = 0
        Me.btnCryoPurgeOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoPurgeOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCryoPurgeOff.ForeColor = System.Drawing.Color.Black
        Me.btnCryoPurgeOff.Location = New System.Drawing.Point(177, 189)
        Me.btnCryoPurgeOff.MessageBoxText = Nothing
        Me.btnCryoPurgeOff.Name = "btnCryoPurgeOff"
        Me.btnCryoPurgeOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoPurgeOff.OffText = "Purge Valve Close"
        Me.btnCryoPurgeOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnCryoPurgeOff.OnText = "Purge Valve Close"
        Me.btnCryoPurgeOff.Size = New System.Drawing.Size(147, 35)
        Me.btnCryoPurgeOff.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnCryoPurgeOff.TabIndex = 36
        Me.btnCryoPurgeOff.Text = "Purge Valve Close"
        Me.btnCryoPurgeOff.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnCryoPurgeOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnCryoPurgeOff.UseVisualStyleBackColor = False
        Me.btnCryoPurgeOff.ValueToBeSend = "Off"
        '
        'btnRoughValveOpen
        '
        Me.btnRoughValveOpen.AccessibleName = "Rough Valve Open"
        Me.btnRoughValveOpen.BackColor = System.Drawing.Color.Transparent
        Me.btnRoughValveOpen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRoughValveOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRoughValveOpen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRoughValveOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRoughValveOpen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnRoughValveOpen.FlatAppearance.BorderSize = 0
        Me.btnRoughValveOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRoughValveOpen.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRoughValveOpen.ForeColor = System.Drawing.Color.Black
        Me.btnRoughValveOpen.Location = New System.Drawing.Point(9, 238)
        Me.btnRoughValveOpen.MessageBoxText = Nothing
        Me.btnRoughValveOpen.Name = "btnRoughValveOpen"
        Me.btnRoughValveOpen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRoughValveOpen.OffText = "Rough Valve Open"
        Me.btnRoughValveOpen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnRoughValveOpen.OnText = "Rough Valve Open"
        Me.btnRoughValveOpen.Size = New System.Drawing.Size(148, 35)
        Me.btnRoughValveOpen.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnRoughValveOpen.TabIndex = 36
        Me.btnRoughValveOpen.Text = "Rough Valve Open"
        Me.btnRoughValveOpen.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnRoughValveOpen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnRoughValveOpen.UseClickedEventInForm = True
        Me.btnRoughValveOpen.UseVisualStyleBackColor = False
        Me.btnRoughValveOpen.ValueToBeSend = "On"
        '
        'btnCryoPurge
        '
        Me.btnCryoPurge.AccessibleName = "Purge Valve Open"
        Me.btnCryoPurge.BackColor = System.Drawing.Color.Transparent
        Me.btnCryoPurge.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoPurge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoPurge.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCryoPurge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoPurge.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnCryoPurge.FlatAppearance.BorderSize = 0
        Me.btnCryoPurge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoPurge.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCryoPurge.ForeColor = System.Drawing.Color.Black
        Me.btnCryoPurge.Location = New System.Drawing.Point(9, 189)
        Me.btnCryoPurge.MessageBoxText = Nothing
        Me.btnCryoPurge.Name = "btnCryoPurge"
        Me.btnCryoPurge.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoPurge.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnCryoPurge.Size = New System.Drawing.Size(148, 35)
        Me.btnCryoPurge.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnCryoPurge.TabIndex = 36
        Me.btnCryoPurge.Text = "Purge Valve Open"
        Me.btnCryoPurge.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnCryoPurge.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnCryoPurge.UseClickedEventInForm = True
        Me.btnCryoPurge.UseVisualStyleBackColor = False
        Me.btnCryoPurge.ValueToBeSend = "On"
        '
        'btnAutoRegenOff
        '
        Me.btnAutoRegenOff.AccessibleName = "Auto Regen Off"
        Me.btnAutoRegenOff.BackColor = System.Drawing.Color.Transparent
        Me.btnAutoRegenOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoRegenOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoRegenOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoRegenOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoRegenOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnAutoRegenOff.FlatAppearance.BorderSize = 0
        Me.btnAutoRegenOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoRegenOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoRegenOff.ForeColor = System.Drawing.Color.Black
        Me.btnAutoRegenOff.Location = New System.Drawing.Point(177, 140)
        Me.btnAutoRegenOff.LogSource = "Cryo Regen On"
        Me.btnAutoRegenOff.MessageBoxText = Nothing
        Me.btnAutoRegenOff.Name = "btnAutoRegenOff"
        Me.btnAutoRegenOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoRegenOff.OffText = "Auto Regen Off"
        Me.btnAutoRegenOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnAutoRegenOff.OnText = "Auto Regen Off"
        Me.btnAutoRegenOff.Size = New System.Drawing.Size(147, 35)
        Me.btnAutoRegenOff.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnAutoRegenOff.TabIndex = 36
        Me.btnAutoRegenOff.Text = "Auto Regen Off"
        Me.btnAutoRegenOff.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnAutoRegenOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnAutoRegenOff.UseVisualStyleBackColor = False
        Me.btnAutoRegenOff.ValueToBeSend = "Off"
        '
        'btnAutoRegen
        '
        Me.btnAutoRegen.AccessibleName = "Auto Regen On"
        Me.btnAutoRegen.BackColor = System.Drawing.Color.Transparent
        Me.btnAutoRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoRegen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnAutoRegen.FlatAppearance.BorderSize = 0
        Me.btnAutoRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoRegen.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoRegen.ForeColor = System.Drawing.Color.Black
        Me.btnAutoRegen.Location = New System.Drawing.Point(9, 140)
        Me.btnAutoRegen.LogSource = "Cryo Regen Off"
        Me.btnAutoRegen.MessageBoxText = Nothing
        Me.btnAutoRegen.Name = "btnAutoRegen"
        Me.btnAutoRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoRegen.OffText = "Auto Regen On"
        Me.btnAutoRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnAutoRegen.OnText = "Auto Regen On"
        Me.btnAutoRegen.Size = New System.Drawing.Size(148, 35)
        Me.btnAutoRegen.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnAutoRegen.TabIndex = 36
        Me.btnAutoRegen.Text = "Auto Regen On"
        Me.btnAutoRegen.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnAutoRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnAutoRegen.UseClickedEventInForm = True
        Me.btnAutoRegen.UseVisualStyleBackColor = False
        Me.btnAutoRegen.ValueToBeSend = "On"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(220, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 311)
        Me.Label2.TabIndex = 76
        '
        'grbChamber
        '
        Me.grbChamber.Controls.Add(Me.btnAutoVentGeneral)
        Me.grbChamber.Controls.Add(Me.btnAutoPumpDownGeneral)
        Me.grbChamber.Controls.Add(Me.btnPumpdownCurve)
        Me.grbChamber.Controls.Add(Me.btnIGDegas)
        Me.grbChamber.Controls.Add(Me.btnPumpPurge)
        Me.grbChamber.Controls.Add(Me.btnRateOfRise)
        Me.grbChamber.Dock = System.Windows.Forms.DockStyle.Left
        Me.grbChamber.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbChamber.Location = New System.Drawing.Point(5, 50)
        Me.grbChamber.Name = "grbChamber"
        Me.grbChamber.Size = New System.Drawing.Size(215, 311)
        Me.grbChamber.TabIndex = 75
        Me.grbChamber.TabStop = False
        Me.grbChamber.Text = "Chamber"
        '
        'btnAutoVentGeneral
        '
        Me.btnAutoVentGeneral.BackColor = System.Drawing.Color.Transparent
        Me.btnAutoVentGeneral.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoVentGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoVentGeneral.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoVentGeneral.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoVentGeneral.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnAutoVentGeneral.FlatAppearance.BorderSize = 0
        Me.btnAutoVentGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoVentGeneral.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoVentGeneral.ForeColor = System.Drawing.Color.Black
        Me.btnAutoVentGeneral.Location = New System.Drawing.Point(11, 82)
        Me.btnAutoVentGeneral.MessageBoxText = Nothing
        Me.btnAutoVentGeneral.Name = "btnAutoVentGeneral"
        Me.btnAutoVentGeneral.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoVentGeneral.OffText = "Auto Vent"
        Me.btnAutoVentGeneral.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnAutoVentGeneral.OnText = "Abort Auto Vent"
        Me.btnAutoVentGeneral.Size = New System.Drawing.Size(190, 35)
        Me.btnAutoVentGeneral.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnAutoVentGeneral.TabIndex = 36
        Me.btnAutoVentGeneral.Text = "Auto Vent"
        Me.btnAutoVentGeneral.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnAutoVentGeneral.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnAutoVentGeneral.UseClickedEventInForm = True
        Me.btnAutoVentGeneral.UseVisualStyleBackColor = False
        Me.btnAutoVentGeneral.ValueToBeSend = "On"
        '
        'btnAutoPumpDownGeneral
        '
        Me.btnAutoPumpDownGeneral.BackColor = System.Drawing.Color.Transparent
        Me.btnAutoPumpDownGeneral.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoPumpDownGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoPumpDownGeneral.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoPumpDownGeneral.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoPumpDownGeneral.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnAutoPumpDownGeneral.FlatAppearance.BorderSize = 0
        Me.btnAutoPumpDownGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoPumpDownGeneral.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoPumpDownGeneral.ForeColor = System.Drawing.Color.Black
        Me.btnAutoPumpDownGeneral.Location = New System.Drawing.Point(11, 30)
        Me.btnAutoPumpDownGeneral.MessageBoxText = Nothing
        Me.btnAutoPumpDownGeneral.Name = "btnAutoPumpDownGeneral"
        Me.btnAutoPumpDownGeneral.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoPumpDownGeneral.OffText = "Auto Pump Down"
        Me.btnAutoPumpDownGeneral.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnAutoPumpDownGeneral.OnText = "Abort Auto Pump Down"
        Me.btnAutoPumpDownGeneral.Size = New System.Drawing.Size(190, 35)
        Me.btnAutoPumpDownGeneral.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnAutoPumpDownGeneral.TabIndex = 36
        Me.btnAutoPumpDownGeneral.Text = "Auto Pump Down"
        Me.btnAutoPumpDownGeneral.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnAutoPumpDownGeneral.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnAutoPumpDownGeneral.UseClickedEventInForm = True
        Me.btnAutoPumpDownGeneral.UseVisualStyleBackColor = False
        Me.btnAutoPumpDownGeneral.ValueToBeSend = "On"
        '
        'btnPumpdownCurve
        '
        Me.btnPumpdownCurve.BackColor = System.Drawing.Color.Transparent
        Me.btnPumpdownCurve.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPumpdownCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPumpdownCurve.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPumpdownCurve.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPumpdownCurve.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnPumpdownCurve.FlatAppearance.BorderSize = 0
        Me.btnPumpdownCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPumpdownCurve.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPumpdownCurve.ForeColor = System.Drawing.Color.Black
        Me.btnPumpdownCurve.Location = New System.Drawing.Point(11, 261)
        Me.btnPumpdownCurve.MessageBoxText = Nothing
        Me.btnPumpdownCurve.Name = "btnPumpdownCurve"
        Me.btnPumpdownCurve.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPumpdownCurve.OffText = "Pumpdown Curve"
        Me.btnPumpdownCurve.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnPumpdownCurve.OnText = "Abort Pumpdown Curve"
        Me.btnPumpdownCurve.Size = New System.Drawing.Size(190, 35)
        Me.btnPumpdownCurve.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnPumpdownCurve.TabIndex = 36
        Me.btnPumpdownCurve.Text = "Pumpdown Curve"
        Me.btnPumpdownCurve.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnPumpdownCurve.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnPumpdownCurve.UseClickedEventInForm = True
        Me.btnPumpdownCurve.UseVisualStyleBackColor = False
        Me.btnPumpdownCurve.ValueToBeSend = "On"
        '
        'btnIGDegas
        '
        Me.btnIGDegas.BackColor = System.Drawing.Color.Transparent
        Me.btnIGDegas.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnIGDegas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIGDegas.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnIGDegas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIGDegas.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnIGDegas.FlatAppearance.BorderSize = 0
        Me.btnIGDegas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIGDegas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIGDegas.ForeColor = System.Drawing.Color.Black
        Me.btnIGDegas.Location = New System.Drawing.Point(11, 238)
        Me.btnIGDegas.MessageBoxText = Nothing
        Me.btnIGDegas.Name = "btnIGDegas"
        Me.btnIGDegas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnIGDegas.OffText = "IG Degas"
        Me.btnIGDegas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnIGDegas.OnText = "Abort IG Degas"
        Me.btnIGDegas.Size = New System.Drawing.Size(190, 35)
        Me.btnIGDegas.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnIGDegas.TabIndex = 36
        Me.btnIGDegas.Text = "IG Degas"
        Me.btnIGDegas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnIGDegas.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnIGDegas.UseClickedEventInForm = True
        Me.btnIGDegas.UseVisualStyleBackColor = False
        Me.btnIGDegas.ValueToBeSend = "On"
        '
        'btnPumpPurge
        '
        Me.btnPumpPurge.BackColor = System.Drawing.Color.Transparent
        Me.btnPumpPurge.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPumpPurge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPumpPurge.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPumpPurge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPumpPurge.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnPumpPurge.FlatAppearance.BorderSize = 0
        Me.btnPumpPurge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPumpPurge.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPumpPurge.ForeColor = System.Drawing.Color.Black
        Me.btnPumpPurge.Location = New System.Drawing.Point(11, 186)
        Me.btnPumpPurge.MessageBoxText = Nothing
        Me.btnPumpPurge.Name = "btnPumpPurge"
        Me.btnPumpPurge.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPumpPurge.OffText = "Pump Purge"
        Me.btnPumpPurge.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnPumpPurge.OnText = "Abort Pump Purge"
        Me.btnPumpPurge.Size = New System.Drawing.Size(190, 35)
        Me.btnPumpPurge.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnPumpPurge.TabIndex = 36
        Me.btnPumpPurge.Text = "Pump Purge"
        Me.btnPumpPurge.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnPumpPurge.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnPumpPurge.UseClickedEventInForm = True
        Me.btnPumpPurge.UseVisualStyleBackColor = False
        Me.btnPumpPurge.ValueToBeSend = "On"
        '
        'btnRateOfRise
        '
        Me.btnRateOfRise.BackColor = System.Drawing.Color.Transparent
        Me.btnRateOfRise.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRateOfRise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRateOfRise.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRateOfRise.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRateOfRise.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnRateOfRise.FlatAppearance.BorderSize = 0
        Me.btnRateOfRise.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRateOfRise.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRateOfRise.ForeColor = System.Drawing.Color.Black
        Me.btnRateOfRise.Location = New System.Drawing.Point(11, 134)
        Me.btnRateOfRise.MessageBoxText = Nothing
        Me.btnRateOfRise.Name = "btnRateOfRise"
        Me.btnRateOfRise.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRateOfRise.OffText = "Rate Of Rise"
        Me.btnRateOfRise.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnRateOfRise.OnText = "Abort Rate Of Rise"
        Me.btnRateOfRise.Size = New System.Drawing.Size(190, 35)
        Me.btnRateOfRise.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnRateOfRise.TabIndex = 36
        Me.btnRateOfRise.Text = "Rate Of Rise"
        Me.btnRateOfRise.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnRateOfRise.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnRateOfRise.UseClickedEventInForm = True
        Me.btnRateOfRise.UseVisualStyleBackColor = False
        Me.btnRateOfRise.ValueToBeSend = "On"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(0, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 311)
        Me.Label1.TabIndex = 74
        '
        'SLSystemPanel
        '
        Me.SLSystemPanel.Controls.Add(Me.btnOffline)
        Me.SLSystemPanel.Controls.Add(Me.btnMaintenance)
        Me.SLSystemPanel.Controls.Add(Me.btnOnline)
        Me.SLSystemPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.SLSystemPanel.Location = New System.Drawing.Point(0, 0)
        Me.SLSystemPanel.Name = "SLSystemPanel"
        Me.SLSystemPanel.Size = New System.Drawing.Size(840, 50)
        Me.SLSystemPanel.TabIndex = 80
        '
        'btnOffline
        '
        Me.btnOffline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOffline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOffline.Clickable = True
        Me.btnOffline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOffline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOffline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnOffline.FlatAppearance.BorderSize = 0
        Me.btnOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOffline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnOffline.ForeColor = System.Drawing.Color.Black
        Me.btnOffline.Location = New System.Drawing.Point(429, 9)
        Me.btnOffline.MessageBoxText = Nothing
        Me.btnOffline.Name = "btnOffline"
        Me.btnOffline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOffline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOffline.Size = New System.Drawing.Size(147, 35)
        Me.btnOffline.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[On]
        Me.btnOffline.TabIndex = 73
        Me.btnOffline.Text = "Offline"
        Me.btnOffline.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnOffline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnOffline.UseClickedEventInForm = True
        Me.btnOffline.UseVisualStyleBackColor = True
        Me.btnOffline.ValueToBeSend = "Off"
        '
        'btnMaintenance
        '
        Me.btnMaintenance.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMaintenance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMaintenance.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnMaintenance.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnMaintenance.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMaintenance.FlatAppearance.BorderSize = 0
        Me.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaintenance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMaintenance.ForeColor = System.Drawing.Color.White
        Me.btnMaintenance.Location = New System.Drawing.Point(79, 9)
        Me.btnMaintenance.MessageBoxText = Nothing
        Me.btnMaintenance.Name = "btnMaintenance"
        Me.btnMaintenance.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMaintenance.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMaintenance.Size = New System.Drawing.Size(190, 35)
        Me.btnMaintenance.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[Error]
        Me.btnMaintenance.TabIndex = 74
        Me.btnMaintenance.Text = "Maintenance"
        Me.btnMaintenance.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnMaintenance.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMaintenance.UseVisualStyleBackColor = True
        Me.btnMaintenance.ValueToBeSend = "On"
        Me.btnMaintenance.Visible = False
        '
        'btnOnline
        '
        Me.btnOnline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOnline.Clickable = True
        Me.btnOnline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOnline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnOnline.FlatAppearance.BorderSize = 0
        Me.btnOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnOnline.ForeColor = System.Drawing.Color.Black
        Me.btnOnline.Location = New System.Drawing.Point(260, 9)
        Me.btnOnline.MessageBoxText = Nothing
        Me.btnOnline.Name = "btnOnline"
        Me.btnOnline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOnline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOnline.Size = New System.Drawing.Size(148, 35)
        Me.btnOnline.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnOnline.TabIndex = 73
        Me.btnOnline.Text = "Online"
        Me.btnOnline.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnOnline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnOnline.UseClickedEventInForm = True
        Me.btnOnline.UseVisualStyleBackColor = True
        Me.btnOnline.ValueToBeSend = "On"
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 361)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(840, 5)
        Me.Panel3.TabIndex = 80
        '
        'SL_PopUpPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(850, 411)
        Me.Name = "SL_PopUpPanel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generals"
        Me.FormContainer.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.grbWaterPump.ResumeLayout(False)
        Me.grbWaterPump.PerformLayout()
        Me.grbCryo.ResumeLayout(False)
        Me.grbCryo.PerformLayout()
        Me.grbChamber.ResumeLayout(False)
        Me.SLSystemPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAutoPowerDown As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAutoVentGeneral As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAutoPumpDownGeneral As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnRateOfRise As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCryoRegenValve As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grbChamber As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grbWaterPump As System.Windows.Forms.GroupBox
    Friend WithEvents txtWaterPump As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnWaterPumpOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnWaterPumpOnOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents SLSystemPanel As System.Windows.Forms.Panel
    Friend WithEvents btnOffline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnOnline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnIGDegas As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnPumpPurge As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents grbCryo As System.Windows.Forms.GroupBox
    Friend WithEvents txtCryo As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnCryoOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnCryoOnOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnRoughValveClose As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnCryoPurgeOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnRoughValveOpen As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnCryoPurge As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAutoRegenOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAutoRegen As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRegenStatus As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnPumpdownCurve As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnMaintenance As AVP_Robot_Project.SL_CustomButton

End Class
