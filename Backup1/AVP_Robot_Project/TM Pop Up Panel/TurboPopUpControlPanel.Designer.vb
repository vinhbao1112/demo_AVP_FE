<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TurboPopUpControlPanel
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
        Me.gbTM = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtTMCryo_LifeTimeHours = New AVP_Robot_Project.SL_Textbox
        Me.txtTMCryoRegenStatus = New AVP_Robot_Project.SL_Textbox
        Me.txtTMCryo_RegenHours = New AVP_Robot_Project.SL_Textbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnTMFastRegen = New AVP_Robot_Project.SL_CustomButton
        Me.btnTMCryoRegen = New AVP_Robot_Project.SL_CustomButton
        Me.btnTMCryoOn = New AVP_Robot_Project.SL_CustomButton
        Me.btnTMIGDegas = New AVP_Robot_Project.SL_CustomButton
        Me.btnTMAutoVent = New AVP_Robot_Project.SL_CustomButton
        Me.btnTMAutoPumpDown = New AVP_Robot_Project.SL_CustomButton
        Me.btnTMOnline = New AVP_Robot_Project.SL_CustomButton
        Me.btnTMOffline = New AVP_Robot_Project.SL_CustomButton
        Me.gbLLA = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtLLACryoRegenStatus = New AVP_Robot_Project.SL_Textbox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtLLACryo_LifeTimeHours = New AVP_Robot_Project.SL_Textbox
        Me.txtLLACryo_RegenHours = New AVP_Robot_Project.SL_Textbox
        Me.btnLLACryoFastRegen = New AVP_Robot_Project.SL_CustomButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnLLACryoRegen = New AVP_Robot_Project.SL_CustomButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnLLACryoOn = New AVP_Robot_Project.SL_CustomButton
        Me.btnLLAIGDegas = New AVP_Robot_Project.SL_CustomButton
        Me.btnLLAAutoVent = New AVP_Robot_Project.SL_CustomButton
        Me.btnLLAAutoPumpDown = New AVP_Robot_Project.SL_CustomButton
        Me.btnLLAOnline = New AVP_Robot_Project.SL_CustomButton
        Me.btnLLAOffline = New AVP_Robot_Project.SL_CustomButton
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.FormContainer.SuspendLayout()
        Me.gbTM.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbLLA.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.gbLLA)
        Me.FormContainer.Controls.Add(Me.Label1)
        Me.FormContainer.Controls.Add(Me.gbTM)
        Me.FormContainer.Size = New System.Drawing.Size(1190, 354)
        '
        'gbTM
        '
        Me.gbTM.BackColor = System.Drawing.Color.Transparent
        Me.gbTM.Controls.Add(Me.GroupBox2)
        Me.gbTM.Controls.Add(Me.btnTMIGDegas)
        Me.gbTM.Controls.Add(Me.btnTMAutoVent)
        Me.gbTM.Controls.Add(Me.btnTMAutoPumpDown)
        Me.gbTM.Controls.Add(Me.btnTMOnline)
        Me.gbTM.Controls.Add(Me.btnTMOffline)
        Me.gbTM.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbTM.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTM.Location = New System.Drawing.Point(0, 0)
        Me.gbTM.Name = "gbTM"
        Me.gbTM.Size = New System.Drawing.Size(387, 354)
        Me.gbTM.TabIndex = 42
        Me.gbTM.TabStop = False
        Me.gbTM.Text = "TM"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTMCryo_LifeTimeHours)
        Me.GroupBox2.Controls.Add(Me.txtTMCryoRegenStatus)
        Me.GroupBox2.Controls.Add(Me.txtTMCryo_RegenHours)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnTMFastRegen)
        Me.GroupBox2.Controls.Add(Me.btnTMCryoRegen)
        Me.GroupBox2.Controls.Add(Me.btnTMCryoOn)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(3, 210)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(381, 141)
        Me.GroupBox2.TabIndex = 78
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cryo"
        '
        'txtTMCryo_LifeTimeHours
        '
        Me.txtTMCryo_LifeTimeHours.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTMCryo_LifeTimeHours.Clickable = False
        Me.txtTMCryo_LifeTimeHours.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTMCryo_LifeTimeHours.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTMCryo_LifeTimeHours.IsReadBack = True
        Me.txtTMCryo_LifeTimeHours.Location = New System.Drawing.Point(294, 31)
        Me.txtTMCryo_LifeTimeHours.Name = "txtTMCryo_LifeTimeHours"
        Me.txtTMCryo_LifeTimeHours.ReadOnly = True
        Me.txtTMCryo_LifeTimeHours.Size = New System.Drawing.Size(82, 24)
        Me.txtTMCryo_LifeTimeHours.TabIndex = 78
        Me.txtTMCryo_LifeTimeHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTMCryo_LifeTimeHours.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTMCryo_LifeTimeHours.UseScientificFormat = True
        '
        'txtTMCryoRegenStatus
        '
        Me.txtTMCryoRegenStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTMCryoRegenStatus.Clickable = False
        Me.txtTMCryoRegenStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTMCryoRegenStatus.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTMCryoRegenStatus.IsReadBack = True
        Me.txtTMCryoRegenStatus.Location = New System.Drawing.Point(93, 64)
        Me.txtTMCryoRegenStatus.Name = "txtTMCryoRegenStatus"
        Me.txtTMCryoRegenStatus.ReadOnly = True
        Me.txtTMCryoRegenStatus.Size = New System.Drawing.Size(281, 24)
        Me.txtTMCryoRegenStatus.TabIndex = 78
        Me.txtTMCryoRegenStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTMCryoRegenStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTMCryoRegenStatus.UseScientificFormat = True
        '
        'txtTMCryo_RegenHours
        '
        Me.txtTMCryo_RegenHours.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTMCryo_RegenHours.Clickable = False
        Me.txtTMCryo_RegenHours.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTMCryo_RegenHours.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTMCryo_RegenHours.IsReadBack = True
        Me.txtTMCryo_RegenHours.Location = New System.Drawing.Point(93, 31)
        Me.txtTMCryo_RegenHours.Name = "txtTMCryo_RegenHours"
        Me.txtTMCryo_RegenHours.ReadOnly = True
        Me.txtTMCryo_RegenHours.Size = New System.Drawing.Size(96, 24)
        Me.txtTMCryo_RegenHours.TabIndex = 78
        Me.txtTMCryo_RegenHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTMCryo_RegenHours.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTMCryo_RegenHours.UseScientificFormat = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(193, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 17)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "LifeTime Hours"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 17)
        Me.Label10.TabIndex = 77
        Me.Label10.Text = "Regen Status"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 17)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Regen Hours"
        '
        'btnTMFastRegen
        '
        Me.btnTMFastRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMFastRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMFastRegen.Clickable = True
        Me.btnTMFastRegen.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMFastRegen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTMFastRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTMFastRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTMFastRegen.FlatAppearance.BorderSize = 0
        Me.btnTMFastRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTMFastRegen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnTMFastRegen.ForeColor = System.Drawing.Color.Black
        Me.btnTMFastRegen.Location = New System.Drawing.Point(274, 98)
        Me.btnTMFastRegen.MessageBoxText = Nothing
        Me.btnTMFastRegen.Name = "btnTMFastRegen"
        Me.btnTMFastRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMFastRegen.OffText = "Fast Regen"
        Me.btnTMFastRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTMFastRegen.OnText = "Fast Regen"
        Me.btnTMFastRegen.Size = New System.Drawing.Size(100, 35)
        Me.btnTMFastRegen.TabIndex = 76
        Me.btnTMFastRegen.Text = "Fast Regen"
        Me.btnTMFastRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTMFastRegen.UseClickedEventInForm = True
        Me.btnTMFastRegen.UseVisualStyleBackColor = True
        Me.btnTMFastRegen.ValueToBeSend = "On"
        '
        'btnTMCryoRegen
        '
        Me.btnTMCryoRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMCryoRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMCryoRegen.Clickable = True
        Me.btnTMCryoRegen.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMCryoRegen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTMCryoRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTMCryoRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTMCryoRegen.FlatAppearance.BorderSize = 0
        Me.btnTMCryoRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTMCryoRegen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnTMCryoRegen.ForeColor = System.Drawing.Color.Black
        Me.btnTMCryoRegen.Location = New System.Drawing.Point(141, 98)
        Me.btnTMCryoRegen.MessageBoxText = Nothing
        Me.btnTMCryoRegen.Name = "btnTMCryoRegen"
        Me.btnTMCryoRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMCryoRegen.OffText = "Regen"
        Me.btnTMCryoRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTMCryoRegen.OnText = "Regen"
        Me.btnTMCryoRegen.Size = New System.Drawing.Size(100, 35)
        Me.btnTMCryoRegen.TabIndex = 76
        Me.btnTMCryoRegen.Text = "Regen"
        Me.btnTMCryoRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTMCryoRegen.UseClickedEventInForm = True
        Me.btnTMCryoRegen.UseVisualStyleBackColor = True
        Me.btnTMCryoRegen.ValueToBeSend = "On"
        '
        'btnTMCryoOn
        '
        Me.btnTMCryoOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMCryoOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMCryoOn.Clickable = True
        Me.btnTMCryoOn.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMCryoOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTMCryoOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTMCryoOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTMCryoOn.FlatAppearance.BorderSize = 0
        Me.btnTMCryoOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTMCryoOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnTMCryoOn.ForeColor = System.Drawing.Color.Black
        Me.btnTMCryoOn.Location = New System.Drawing.Point(8, 98)
        Me.btnTMCryoOn.MessageBoxText = Nothing
        Me.btnTMCryoOn.Name = "btnTMCryoOn"
        Me.btnTMCryoOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMCryoOn.OffText = "On"
        Me.btnTMCryoOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTMCryoOn.OnText = "On"
        Me.btnTMCryoOn.Size = New System.Drawing.Size(100, 35)
        Me.btnTMCryoOn.TabIndex = 76
        Me.btnTMCryoOn.Text = "On"
        Me.btnTMCryoOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTMCryoOn.UseClickedEventInForm = True
        Me.btnTMCryoOn.UseVisualStyleBackColor = True
        Me.btnTMCryoOn.ValueToBeSend = "On"
        '
        'btnTMIGDegas
        '
        Me.btnTMIGDegas.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMIGDegas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMIGDegas.Clickable = True
        Me.btnTMIGDegas.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMIGDegas.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTMIGDegas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTMIGDegas.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTMIGDegas.FlatAppearance.BorderSize = 0
        Me.btnTMIGDegas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTMIGDegas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnTMIGDegas.ForeColor = System.Drawing.Color.Black
        Me.btnTMIGDegas.Location = New System.Drawing.Point(9, 145)
        Me.btnTMIGDegas.MessageBoxText = Nothing
        Me.btnTMIGDegas.Name = "btnTMIGDegas"
        Me.btnTMIGDegas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMIGDegas.OffText = "IG Degas"
        Me.btnTMIGDegas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTMIGDegas.OnText = "IG Degas"
        Me.btnTMIGDegas.Size = New System.Drawing.Size(143, 35)
        Me.btnTMIGDegas.TabIndex = 76
        Me.btnTMIGDegas.Text = "IG Degas"
        Me.btnTMIGDegas.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTMIGDegas.UseClickedEventInForm = True
        Me.btnTMIGDegas.UseVisualStyleBackColor = True
        Me.btnTMIGDegas.ValueToBeSend = "On"
        '
        'btnTMAutoVent
        '
        Me.btnTMAutoVent.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMAutoVent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMAutoVent.Clickable = True
        Me.btnTMAutoVent.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMAutoVent.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTMAutoVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTMAutoVent.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTMAutoVent.FlatAppearance.BorderSize = 0
        Me.btnTMAutoVent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTMAutoVent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnTMAutoVent.ForeColor = System.Drawing.Color.Black
        Me.btnTMAutoVent.Location = New System.Drawing.Point(234, 89)
        Me.btnTMAutoVent.MessageBoxText = Nothing
        Me.btnTMAutoVent.Name = "btnTMAutoVent"
        Me.btnTMAutoVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMAutoVent.OffText = "Auto Vent"
        Me.btnTMAutoVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTMAutoVent.OnText = "Abort Auto Vent"
        Me.btnTMAutoVent.Size = New System.Drawing.Size(143, 35)
        Me.btnTMAutoVent.TabIndex = 76
        Me.btnTMAutoVent.Text = "Auto Vent"
        Me.btnTMAutoVent.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTMAutoVent.UseClickedEventInForm = True
        Me.btnTMAutoVent.UseVisualStyleBackColor = True
        Me.btnTMAutoVent.ValueToBeSend = "On"
        '
        'btnTMAutoPumpDown
        '
        Me.btnTMAutoPumpDown.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMAutoPumpDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMAutoPumpDown.Clickable = True
        Me.btnTMAutoPumpDown.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMAutoPumpDown.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTMAutoPumpDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTMAutoPumpDown.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTMAutoPumpDown.FlatAppearance.BorderSize = 0
        Me.btnTMAutoPumpDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTMAutoPumpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnTMAutoPumpDown.ForeColor = System.Drawing.Color.Black
        Me.btnTMAutoPumpDown.Location = New System.Drawing.Point(9, 89)
        Me.btnTMAutoPumpDown.MessageBoxText = Nothing
        Me.btnTMAutoPumpDown.Name = "btnTMAutoPumpDown"
        Me.btnTMAutoPumpDown.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMAutoPumpDown.OffText = "Auto Pump Down"
        Me.btnTMAutoPumpDown.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTMAutoPumpDown.OnText = "Abort Pump Down"
        Me.btnTMAutoPumpDown.Size = New System.Drawing.Size(143, 35)
        Me.btnTMAutoPumpDown.TabIndex = 76
        Me.btnTMAutoPumpDown.Text = "Auto Pump Down"
        Me.btnTMAutoPumpDown.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTMAutoPumpDown.UseClickedEventInForm = True
        Me.btnTMAutoPumpDown.UseVisualStyleBackColor = True
        Me.btnTMAutoPumpDown.ValueToBeSend = "On"
        '
        'btnTMOnline
        '
        Me.btnTMOnline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMOnline.Clickable = True
        Me.btnTMOnline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMOnline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTMOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTMOnline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTMOnline.FlatAppearance.BorderSize = 0
        Me.btnTMOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTMOnline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnTMOnline.ForeColor = System.Drawing.Color.Black
        Me.btnTMOnline.Location = New System.Drawing.Point(9, 33)
        Me.btnTMOnline.MessageBoxText = Nothing
        Me.btnTMOnline.Name = "btnTMOnline"
        Me.btnTMOnline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMOnline.OffText = "Online"
        Me.btnTMOnline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTMOnline.OnText = "Online"
        Me.btnTMOnline.Size = New System.Drawing.Size(143, 35)
        Me.btnTMOnline.TabIndex = 76
        Me.btnTMOnline.Text = "Online"
        Me.btnTMOnline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTMOnline.UseClickedEventInForm = True
        Me.btnTMOnline.UseVisualStyleBackColor = True
        Me.btnTMOnline.ValueToBeSend = "On"
        '
        'btnTMOffline
        '
        Me.btnTMOffline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTMOffline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTMOffline.Clickable = True
        Me.btnTMOffline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTMOffline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTMOffline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTMOffline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTMOffline.FlatAppearance.BorderSize = 0
        Me.btnTMOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTMOffline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnTMOffline.ForeColor = System.Drawing.Color.Black
        Me.btnTMOffline.Location = New System.Drawing.Point(234, 33)
        Me.btnTMOffline.MessageBoxText = Nothing
        Me.btnTMOffline.Name = "btnTMOffline"
        Me.btnTMOffline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTMOffline.OffText = "Offline"
        Me.btnTMOffline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTMOffline.OnText = "Offline"
        Me.btnTMOffline.Size = New System.Drawing.Size(143, 35)
        Me.btnTMOffline.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[On]
        Me.btnTMOffline.TabIndex = 77
        Me.btnTMOffline.Text = "Offline"
        Me.btnTMOffline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTMOffline.UseClickedEventInForm = True
        Me.btnTMOffline.UseVisualStyleBackColor = True
        Me.btnTMOffline.ValueToBeSend = "Off"
        '
        'gbLLA
        '
        Me.gbLLA.BackColor = System.Drawing.Color.Transparent
        Me.gbLLA.Controls.Add(Me.GroupBox4)
        Me.gbLLA.Controls.Add(Me.btnLLAIGDegas)
        Me.gbLLA.Controls.Add(Me.btnLLAAutoVent)
        Me.gbLLA.Controls.Add(Me.btnLLAAutoPumpDown)
        Me.gbLLA.Controls.Add(Me.btnLLAOnline)
        Me.gbLLA.Controls.Add(Me.btnLLAOffline)
        Me.gbLLA.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbLLA.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLLA.Location = New System.Drawing.Point(395, 0)
        Me.gbLLA.Name = "gbLLA"
        Me.gbLLA.Size = New System.Drawing.Size(384, 354)
        Me.gbLLA.TabIndex = 43
        Me.gbLLA.TabStop = False
        Me.gbLLA.Text = "LLA"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtLLACryoRegenStatus)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtLLACryo_LifeTimeHours)
        Me.GroupBox4.Controls.Add(Me.txtLLACryo_RegenHours)
        Me.GroupBox4.Controls.Add(Me.btnLLACryoFastRegen)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.btnLLACryoRegen)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.btnLLACryoOn)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(3, 210)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(378, 141)
        Me.GroupBox4.TabIndex = 78
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cryo"
        '
        'txtLLACryoRegenStatus
        '
        Me.txtLLACryoRegenStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtLLACryoRegenStatus.Clickable = False
        Me.txtLLACryoRegenStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtLLACryoRegenStatus.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtLLACryoRegenStatus.IsReadBack = True
        Me.txtLLACryoRegenStatus.Location = New System.Drawing.Point(92, 64)
        Me.txtLLACryoRegenStatus.Name = "txtLLACryoRegenStatus"
        Me.txtLLACryoRegenStatus.ReadOnly = True
        Me.txtLLACryoRegenStatus.Size = New System.Drawing.Size(281, 24)
        Me.txtLLACryoRegenStatus.TabIndex = 80
        Me.txtLLACryoRegenStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtLLACryoRegenStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtLLACryoRegenStatus.UseScientificFormat = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 17)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "Regen Status"
        '
        'txtLLACryo_LifeTimeHours
        '
        Me.txtLLACryo_LifeTimeHours.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtLLACryo_LifeTimeHours.Clickable = False
        Me.txtLLACryo_LifeTimeHours.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtLLACryo_LifeTimeHours.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtLLACryo_LifeTimeHours.IsReadBack = True
        Me.txtLLACryo_LifeTimeHours.Location = New System.Drawing.Point(292, 31)
        Me.txtLLACryo_LifeTimeHours.Name = "txtLLACryo_LifeTimeHours"
        Me.txtLLACryo_LifeTimeHours.ReadOnly = True
        Me.txtLLACryo_LifeTimeHours.Size = New System.Drawing.Size(82, 24)
        Me.txtLLACryo_LifeTimeHours.TabIndex = 78
        Me.txtLLACryo_LifeTimeHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtLLACryo_LifeTimeHours.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtLLACryo_LifeTimeHours.UseScientificFormat = True
        '
        'txtLLACryo_RegenHours
        '
        Me.txtLLACryo_RegenHours.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtLLACryo_RegenHours.Clickable = False
        Me.txtLLACryo_RegenHours.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtLLACryo_RegenHours.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtLLACryo_RegenHours.IsReadBack = True
        Me.txtLLACryo_RegenHours.Location = New System.Drawing.Point(91, 31)
        Me.txtLLACryo_RegenHours.Name = "txtLLACryo_RegenHours"
        Me.txtLLACryo_RegenHours.ReadOnly = True
        Me.txtLLACryo_RegenHours.Size = New System.Drawing.Size(96, 24)
        Me.txtLLACryo_RegenHours.TabIndex = 78
        Me.txtLLACryo_RegenHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtLLACryo_RegenHours.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtLLACryo_RegenHours.UseScientificFormat = True
        '
        'btnLLACryoFastRegen
        '
        Me.btnLLACryoFastRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLACryoFastRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLLACryoFastRegen.Clickable = True
        Me.btnLLACryoFastRegen.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnLLACryoFastRegen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnLLACryoFastRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLLACryoFastRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnLLACryoFastRegen.FlatAppearance.BorderSize = 0
        Me.btnLLACryoFastRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLLACryoFastRegen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLLACryoFastRegen.ForeColor = System.Drawing.Color.Black
        Me.btnLLACryoFastRegen.Location = New System.Drawing.Point(271, 98)
        Me.btnLLACryoFastRegen.MessageBoxText = Nothing
        Me.btnLLACryoFastRegen.Name = "btnLLACryoFastRegen"
        Me.btnLLACryoFastRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLACryoFastRegen.OffText = "Fast Regen"
        Me.btnLLACryoFastRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLLACryoFastRegen.OnText = "Fast Regen"
        Me.btnLLACryoFastRegen.Size = New System.Drawing.Size(100, 35)
        Me.btnLLACryoFastRegen.TabIndex = 76
        Me.btnLLACryoFastRegen.Text = "Fast Regen"
        Me.btnLLACryoFastRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnLLACryoFastRegen.UseClickedEventInForm = True
        Me.btnLLACryoFastRegen.UseVisualStyleBackColor = True
        Me.btnLLACryoFastRegen.ValueToBeSend = "On"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(191, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 17)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "LifeTime Hours"
        '
        'btnLLACryoRegen
        '
        Me.btnLLACryoRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLACryoRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLLACryoRegen.Clickable = True
        Me.btnLLACryoRegen.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnLLACryoRegen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnLLACryoRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLLACryoRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnLLACryoRegen.FlatAppearance.BorderSize = 0
        Me.btnLLACryoRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLLACryoRegen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLLACryoRegen.ForeColor = System.Drawing.Color.Black
        Me.btnLLACryoRegen.Location = New System.Drawing.Point(142, 98)
        Me.btnLLACryoRegen.MessageBoxText = Nothing
        Me.btnLLACryoRegen.Name = "btnLLACryoRegen"
        Me.btnLLACryoRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLACryoRegen.OffText = "Regen"
        Me.btnLLACryoRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLLACryoRegen.OnText = "Regen"
        Me.btnLLACryoRegen.Size = New System.Drawing.Size(100, 35)
        Me.btnLLACryoRegen.TabIndex = 76
        Me.btnLLACryoRegen.Text = "Regen"
        Me.btnLLACryoRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnLLACryoRegen.UseClickedEventInForm = True
        Me.btnLLACryoRegen.UseVisualStyleBackColor = True
        Me.btnLLACryoRegen.ValueToBeSend = "On"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 17)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Regen Hours"
        '
        'btnLLACryoOn
        '
        Me.btnLLACryoOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLACryoOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLLACryoOn.Clickable = True
        Me.btnLLACryoOn.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnLLACryoOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnLLACryoOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLLACryoOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnLLACryoOn.FlatAppearance.BorderSize = 0
        Me.btnLLACryoOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLLACryoOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLLACryoOn.ForeColor = System.Drawing.Color.Black
        Me.btnLLACryoOn.Location = New System.Drawing.Point(13, 98)
        Me.btnLLACryoOn.MessageBoxText = Nothing
        Me.btnLLACryoOn.Name = "btnLLACryoOn"
        Me.btnLLACryoOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLACryoOn.OffText = "On"
        Me.btnLLACryoOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLLACryoOn.OnText = "On"
        Me.btnLLACryoOn.Size = New System.Drawing.Size(100, 35)
        Me.btnLLACryoOn.TabIndex = 76
        Me.btnLLACryoOn.Text = "On"
        Me.btnLLACryoOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnLLACryoOn.UseClickedEventInForm = True
        Me.btnLLACryoOn.UseVisualStyleBackColor = True
        Me.btnLLACryoOn.ValueToBeSend = "On"
        '
        'btnLLAIGDegas
        '
        Me.btnLLAIGDegas.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLAIGDegas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLLAIGDegas.Clickable = True
        Me.btnLLAIGDegas.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnLLAIGDegas.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnLLAIGDegas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLLAIGDegas.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnLLAIGDegas.FlatAppearance.BorderSize = 0
        Me.btnLLAIGDegas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLLAIGDegas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLLAIGDegas.ForeColor = System.Drawing.Color.Black
        Me.btnLLAIGDegas.Location = New System.Drawing.Point(21, 145)
        Me.btnLLAIGDegas.MessageBoxText = Nothing
        Me.btnLLAIGDegas.Name = "btnLLAIGDegas"
        Me.btnLLAIGDegas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLAIGDegas.OffText = "IG Degas"
        Me.btnLLAIGDegas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLLAIGDegas.OnText = "IG Degas"
        Me.btnLLAIGDegas.Size = New System.Drawing.Size(143, 35)
        Me.btnLLAIGDegas.TabIndex = 76
        Me.btnLLAIGDegas.Text = "IG Degas"
        Me.btnLLAIGDegas.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnLLAIGDegas.UseClickedEventInForm = True
        Me.btnLLAIGDegas.UseVisualStyleBackColor = True
        Me.btnLLAIGDegas.ValueToBeSend = "On"
        '
        'btnLLAAutoVent
        '
        Me.btnLLAAutoVent.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLAAutoVent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLLAAutoVent.Clickable = True
        Me.btnLLAAutoVent.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnLLAAutoVent.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnLLAAutoVent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLLAAutoVent.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnLLAAutoVent.FlatAppearance.BorderSize = 0
        Me.btnLLAAutoVent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLLAAutoVent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLLAAutoVent.ForeColor = System.Drawing.Color.Black
        Me.btnLLAAutoVent.Location = New System.Drawing.Point(231, 89)
        Me.btnLLAAutoVent.MessageBoxText = Nothing
        Me.btnLLAAutoVent.Name = "btnLLAAutoVent"
        Me.btnLLAAutoVent.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLAAutoVent.OffText = "Auto Vent"
        Me.btnLLAAutoVent.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLLAAutoVent.OnText = "Abort Auto Vent"
        Me.btnLLAAutoVent.Size = New System.Drawing.Size(143, 35)
        Me.btnLLAAutoVent.TabIndex = 76
        Me.btnLLAAutoVent.Text = "Auto Vent"
        Me.btnLLAAutoVent.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnLLAAutoVent.UseClickedEventInForm = True
        Me.btnLLAAutoVent.UseVisualStyleBackColor = True
        Me.btnLLAAutoVent.ValueToBeSend = "On"
        '
        'btnLLAAutoPumpDown
        '
        Me.btnLLAAutoPumpDown.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLAAutoPumpDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLLAAutoPumpDown.Clickable = True
        Me.btnLLAAutoPumpDown.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnLLAAutoPumpDown.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnLLAAutoPumpDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLLAAutoPumpDown.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnLLAAutoPumpDown.FlatAppearance.BorderSize = 0
        Me.btnLLAAutoPumpDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLLAAutoPumpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLLAAutoPumpDown.ForeColor = System.Drawing.Color.Black
        Me.btnLLAAutoPumpDown.Location = New System.Drawing.Point(21, 89)
        Me.btnLLAAutoPumpDown.MessageBoxText = Nothing
        Me.btnLLAAutoPumpDown.Name = "btnLLAAutoPumpDown"
        Me.btnLLAAutoPumpDown.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLAAutoPumpDown.OffText = "Auto Pump Down"
        Me.btnLLAAutoPumpDown.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLLAAutoPumpDown.OnText = "Abort Pump Down"
        Me.btnLLAAutoPumpDown.Size = New System.Drawing.Size(143, 35)
        Me.btnLLAAutoPumpDown.TabIndex = 76
        Me.btnLLAAutoPumpDown.Text = "Auto Pump Down"
        Me.btnLLAAutoPumpDown.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnLLAAutoPumpDown.UseClickedEventInForm = True
        Me.btnLLAAutoPumpDown.UseVisualStyleBackColor = True
        Me.btnLLAAutoPumpDown.ValueToBeSend = "On"
        '
        'btnLLAOnline
        '
        Me.btnLLAOnline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLAOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLLAOnline.Clickable = True
        Me.btnLLAOnline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnLLAOnline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnLLAOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLLAOnline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnLLAOnline.FlatAppearance.BorderSize = 0
        Me.btnLLAOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLLAOnline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLLAOnline.ForeColor = System.Drawing.Color.Black
        Me.btnLLAOnline.Location = New System.Drawing.Point(21, 33)
        Me.btnLLAOnline.MessageBoxText = Nothing
        Me.btnLLAOnline.Name = "btnLLAOnline"
        Me.btnLLAOnline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLAOnline.OffText = "Online"
        Me.btnLLAOnline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLLAOnline.OnText = "Online"
        Me.btnLLAOnline.Size = New System.Drawing.Size(143, 35)
        Me.btnLLAOnline.TabIndex = 76
        Me.btnLLAOnline.Text = "Online"
        Me.btnLLAOnline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnLLAOnline.UseClickedEventInForm = True
        Me.btnLLAOnline.UseVisualStyleBackColor = True
        Me.btnLLAOnline.ValueToBeSend = "On"
        '
        'btnLLAOffline
        '
        Me.btnLLAOffline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLLAOffline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLLAOffline.Clickable = True
        Me.btnLLAOffline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnLLAOffline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnLLAOffline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLLAOffline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnLLAOffline.FlatAppearance.BorderSize = 0
        Me.btnLLAOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLLAOffline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLLAOffline.ForeColor = System.Drawing.Color.Black
        Me.btnLLAOffline.Location = New System.Drawing.Point(231, 33)
        Me.btnLLAOffline.MessageBoxText = Nothing
        Me.btnLLAOffline.Name = "btnLLAOffline"
        Me.btnLLAOffline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLLAOffline.OffText = "Offline"
        Me.btnLLAOffline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLLAOffline.OnText = "Offline"
        Me.btnLLAOffline.Size = New System.Drawing.Size(143, 35)
        Me.btnLLAOffline.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[On]
        Me.btnLLAOffline.TabIndex = 77
        Me.btnLLAOffline.Text = "Offline"
        Me.btnLLAOffline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnLLAOffline.UseClickedEventInForm = True
        Me.btnLLAOffline.UseVisualStyleBackColor = True
        Me.btnLLAOffline.ValueToBeSend = "Off"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox6.Location = New System.Drawing.Point(3, 205)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(378, 141)
        Me.GroupBox6.TabIndex = 78
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Cryo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 17)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "Regen Status"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(193, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 17)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "LifeTime Hours"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 17)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Regen Hours"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(387, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(8, 354)
        Me.Label1.TabIndex = 46
        '
        'TurboPopUpControlPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1200, 399)
        Me.Name = "TurboPopUpControlPanel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TMPopUpPanel"
        Me.FormContainer.ResumeLayout(False)
        Me.gbTM.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbLLA.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTM As System.Windows.Forms.GroupBox
    Friend WithEvents btnTMAutoVent As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTMAutoPumpDown As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTMOnline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTMOffline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTMFastRegen As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTMCryoRegen As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTMCryoOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents gbLLA As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLLACryoFastRegen As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnLLACryoRegen As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnLLACryoOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnLLAAutoVent As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnLLAAutoPumpDown As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnLLAOnline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnLLAOffline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTMIGDegas As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnLLAIGDegas As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTMCryo_LifeTimeHours As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTMCryo_RegenHours As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLLACryo_LifeTimeHours As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtLLACryo_RegenHours As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTMCryoRegenStatus As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtLLACryoRegenStatus As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
