<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CryoPopUpPanel
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtCryo_LifeTimeHours = New AVP_Robot_Project.SL_Textbox
        Me.txtCryoRegenStatus = New AVP_Robot_Project.SL_Textbox
        Me.txtCryo_RegenHours = New AVP_Robot_Project.SL_Textbox
        Me.lblLifeTimeHours = New System.Windows.Forms.Label
        Me.lblRegenStatus = New System.Windows.Forms.Label
        Me.lblRegenHours = New System.Windows.Forms.Label
        Me.btnFastRegen = New AVP_Robot_Project.SL_CustomButton
        Me.btnCryoRegen = New AVP_Robot_Project.SL_CustomButton
        Me.btnCryoOn = New AVP_Robot_Project.SL_CustomButton
        Me.lblPadding = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtExtendedPurgeTimeRB = New AVP_Robot_Project.SL_Textbox
        Me.txtPumpRestartDelayRB = New AVP_Robot_Project.SL_Textbox
        Me.txtRepurgeCyclesRB = New AVP_Robot_Project.SL_Textbox
        Me.txtRoughtToPressureRB = New AVP_Robot_Project.SL_Textbox
        Me.txtRateOfRiseRB = New AVP_Robot_Project.SL_Textbox
        Me.txtStartUpTempRB = New AVP_Robot_Project.SL_Textbox
        Me.txtExtendedPurgeTime = New AVP_Robot_Project.SL_Textbox
        Me.txtPumpRestartDelay = New AVP_Robot_Project.SL_Textbox
        Me.txtRepurgeCycles = New AVP_Robot_Project.SL_Textbox
        Me.txtRoughToPressure = New AVP_Robot_Project.SL_Textbox
        Me.txtRateOfRise = New AVP_Robot_Project.SL_Textbox
        Me.txtStartUpTemp = New AVP_Robot_Project.SL_Textbox
        Me.FormContainer.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.TableLayoutPanel1)
        Me.FormContainer.Controls.Add(Me.Label2)
        Me.FormContainer.Controls.Add(Me.GroupBox2)
        Me.FormContainer.Controls.Add(Me.lblPadding)
        Me.FormContainer.Controls.Add(Me.Label1)
        Me.FormContainer.Size = New System.Drawing.Size(538, 355)
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtCryo_LifeTimeHours)
        Me.GroupBox2.Controls.Add(Me.txtCryoRegenStatus)
        Me.GroupBox2.Controls.Add(Me.txtCryo_RegenHours)
        Me.GroupBox2.Controls.Add(Me.lblLifeTimeHours)
        Me.GroupBox2.Controls.Add(Me.lblRegenStatus)
        Me.GroupBox2.Controls.Add(Me.lblRegenHours)
        Me.GroupBox2.Controls.Add(Me.btnFastRegen)
        Me.GroupBox2.Controls.Add(Me.btnCryoRegen)
        Me.GroupBox2.Controls.Add(Me.btnCryoOn)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(528, 146)
        Me.GroupBox2.TabIndex = 78
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cryo"
        '
        'txtCryo_LifeTimeHours
        '
        Me.txtCryo_LifeTimeHours.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCryo_LifeTimeHours.Clickable = False
        Me.txtCryo_LifeTimeHours.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCryo_LifeTimeHours.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCryo_LifeTimeHours.IsReadBack = True
        Me.txtCryo_LifeTimeHours.Location = New System.Drawing.Point(402, 29)
        Me.txtCryo_LifeTimeHours.Name = "txtCryo_LifeTimeHours"
        Me.txtCryo_LifeTimeHours.ReadOnly = True
        Me.txtCryo_LifeTimeHours.Size = New System.Drawing.Size(104, 24)
        Me.txtCryo_LifeTimeHours.TabIndex = 78
        Me.txtCryo_LifeTimeHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCryo_LifeTimeHours.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCryo_LifeTimeHours.UseScientificFormat = True
        '
        'txtCryoRegenStatus
        '
        Me.txtCryoRegenStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCryoRegenStatus.Clickable = False
        Me.txtCryoRegenStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCryoRegenStatus.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCryoRegenStatus.IsReadBack = True
        Me.txtCryoRegenStatus.Location = New System.Drawing.Point(138, 64)
        Me.txtCryoRegenStatus.Name = "txtCryoRegenStatus"
        Me.txtCryoRegenStatus.ReadOnly = True
        Me.txtCryoRegenStatus.Size = New System.Drawing.Size(368, 24)
        Me.txtCryoRegenStatus.TabIndex = 78
        Me.txtCryoRegenStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCryoRegenStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCryoRegenStatus.UseScientificFormat = True
        '
        'txtCryo_RegenHours
        '
        Me.txtCryo_RegenHours.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCryo_RegenHours.Clickable = False
        Me.txtCryo_RegenHours.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCryo_RegenHours.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCryo_RegenHours.IsReadBack = True
        Me.txtCryo_RegenHours.Location = New System.Drawing.Point(138, 29)
        Me.txtCryo_RegenHours.Name = "txtCryo_RegenHours"
        Me.txtCryo_RegenHours.ReadOnly = True
        Me.txtCryo_RegenHours.Size = New System.Drawing.Size(125, 24)
        Me.txtCryo_RegenHours.TabIndex = 78
        Me.txtCryo_RegenHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCryo_RegenHours.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCryo_RegenHours.UseScientificFormat = True
        '
        'lblLifeTimeHours
        '
        Me.lblLifeTimeHours.AutoSize = True
        Me.lblLifeTimeHours.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLifeTimeHours.Location = New System.Drawing.Point(271, 33)
        Me.lblLifeTimeHours.Name = "lblLifeTimeHours"
        Me.lblLifeTimeHours.Size = New System.Drawing.Size(113, 17)
        Me.lblLifeTimeHours.TabIndex = 77
        Me.lblLifeTimeHours.Text = "LifeTime Hours"
        '
        'lblRegenStatus
        '
        Me.lblRegenStatus.AutoSize = True
        Me.lblRegenStatus.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegenStatus.Location = New System.Drawing.Point(22, 67)
        Me.lblRegenStatus.Name = "lblRegenStatus"
        Me.lblRegenStatus.Size = New System.Drawing.Size(95, 17)
        Me.lblRegenStatus.TabIndex = 77
        Me.lblRegenStatus.Text = "Regen Status"
        '
        'lblRegenHours
        '
        Me.lblRegenHours.AutoSize = True
        Me.lblRegenHours.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegenHours.Location = New System.Drawing.Point(24, 33)
        Me.lblRegenHours.Name = "lblRegenHours"
        Me.lblRegenHours.Size = New System.Drawing.Size(96, 17)
        Me.lblRegenHours.TabIndex = 77
        Me.lblRegenHours.Text = "Regen Hours"
        '
        'btnFastRegen
        '
        Me.btnFastRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnFastRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFastRegen.Clickable = True
        Me.btnFastRegen.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnFastRegen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnFastRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFastRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnFastRegen.FlatAppearance.BorderSize = 0
        Me.btnFastRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFastRegen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnFastRegen.ForeColor = System.Drawing.Color.Black
        Me.btnFastRegen.Location = New System.Drawing.Point(373, 98)
        Me.btnFastRegen.LogSource = "Cryo Fast Regen"
        Me.btnFastRegen.MessageBoxText = Nothing
        Me.btnFastRegen.Name = "btnFastRegen"
        Me.btnFastRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnFastRegen.OffText = "Fast Regen"
        Me.btnFastRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnFastRegen.OnText = "Fast Regen"
        Me.btnFastRegen.Size = New System.Drawing.Size(100, 35)
        Me.btnFastRegen.TabIndex = 76
        Me.btnFastRegen.Text = "Fast Regen"
        Me.btnFastRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnFastRegen.UseClickedEventInForm = True
        Me.btnFastRegen.UseVisualStyleBackColor = True
        Me.btnFastRegen.ValueToBeSend = "On"
        '
        'btnCryoRegen
        '
        Me.btnCryoRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoRegen.Clickable = True
        Me.btnCryoRegen.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnCryoRegen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCryoRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnCryoRegen.FlatAppearance.BorderSize = 0
        Me.btnCryoRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoRegen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCryoRegen.ForeColor = System.Drawing.Color.Black
        Me.btnCryoRegen.Location = New System.Drawing.Point(214, 98)
        Me.btnCryoRegen.LogSource = "Cryo Regen"
        Me.btnCryoRegen.MessageBoxText = Nothing
        Me.btnCryoRegen.Name = "btnCryoRegen"
        Me.btnCryoRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoRegen.OffText = "Regen"
        Me.btnCryoRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnCryoRegen.OnText = "Regen"
        Me.btnCryoRegen.Size = New System.Drawing.Size(100, 35)
        Me.btnCryoRegen.TabIndex = 76
        Me.btnCryoRegen.Text = "Regen"
        Me.btnCryoRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnCryoRegen.UseClickedEventInForm = True
        Me.btnCryoRegen.UseVisualStyleBackColor = True
        Me.btnCryoRegen.ValueToBeSend = "On"
        '
        'btnCryoOn
        '
        Me.btnCryoOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoOn.Clickable = True
        Me.btnCryoOn.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnCryoOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCryoOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnCryoOn.FlatAppearance.BorderSize = 0
        Me.btnCryoOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCryoOn.ForeColor = System.Drawing.Color.Black
        Me.btnCryoOn.Location = New System.Drawing.Point(55, 97)
        Me.btnCryoOn.LogSource = "Cryo Status"
        Me.btnCryoOn.MessageBoxText = Nothing
        Me.btnCryoOn.Name = "btnCryoOn"
        Me.btnCryoOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCryoOn.OffText = "On"
        Me.btnCryoOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnCryoOn.OnText = "On"
        Me.btnCryoOn.Size = New System.Drawing.Size(100, 35)
        Me.btnCryoOn.TabIndex = 76
        Me.btnCryoOn.Text = "On"
        Me.btnCryoOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnCryoOn.UseClickedEventInForm = True
        Me.btnCryoOn.UseVisualStyleBackColor = True
        Me.btnCryoOn.ValueToBeSend = "On"
        '
        'lblPadding
        '
        Me.lblPadding.BackColor = System.Drawing.Color.Transparent
        Me.lblPadding.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPadding.Location = New System.Drawing.Point(0, 0)
        Me.lblPadding.Name = "lblPadding"
        Me.lblPadding.Size = New System.Drawing.Size(5, 355)
        Me.lblPadding.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Location = New System.Drawing.Point(533, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 355)
        Me.Label1.TabIndex = 79
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(5, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(528, 5)
        Me.Label2.TabIndex = 80
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.91209!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.08791!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtExtendedPurgeTimeRB, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPumpRestartDelayRB, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRepurgeCyclesRB, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRoughtToPressureRB, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRateOfRiseRB, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtStartUpTempRB, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtExtendedPurgeTime, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPumpRestartDelay, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRepurgeCycles, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRoughToPressure, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRateOfRise, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtStartUpTemp, 2, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 151)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(528, 200)
        Me.TableLayoutPanel1.TabIndex = 81
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(221, 30)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "Start Up Temp (DegK)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(221, 30)
        Me.Label17.TabIndex = 75
        Me.Label17.Text = "Extended Purge Time (minutes)"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(221, 30)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Pump Restart Delay (minutes)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(221, 30)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Repurge Cycles (count)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(221, 30)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Rough To Pressure (mTorr)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(221, 30)
        Me.Label8.TabIndex = 79
        Me.Label8.Text = "Rate Of Rise (mTorr/minute)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtExtendedPurgeTimeRB
        '
        Me.txtExtendedPurgeTimeRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtExtendedPurgeTimeRB.Clickable = False
        Me.txtExtendedPurgeTimeRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtExtendedPurgeTimeRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtExtendedPurgeTimeRB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtExtendedPurgeTimeRB.IsReadBack = True
        Me.txtExtendedPurgeTimeRB.Location = New System.Drawing.Point(236, 6)
        Me.txtExtendedPurgeTimeRB.Name = "txtExtendedPurgeTimeRB"
        Me.txtExtendedPurgeTimeRB.ReadOnly = True
        Me.txtExtendedPurgeTimeRB.Size = New System.Drawing.Size(128, 24)
        Me.txtExtendedPurgeTimeRB.TabIndex = 81
        Me.txtExtendedPurgeTimeRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtExtendedPurgeTimeRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtExtendedPurgeTimeRB.UseScientificFormat = True
        '
        'txtPumpRestartDelayRB
        '
        Me.txtPumpRestartDelayRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPumpRestartDelayRB.Clickable = False
        Me.txtPumpRestartDelayRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPumpRestartDelayRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPumpRestartDelayRB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPumpRestartDelayRB.IsReadBack = True
        Me.txtPumpRestartDelayRB.Location = New System.Drawing.Point(236, 39)
        Me.txtPumpRestartDelayRB.Name = "txtPumpRestartDelayRB"
        Me.txtPumpRestartDelayRB.ReadOnly = True
        Me.txtPumpRestartDelayRB.Size = New System.Drawing.Size(128, 24)
        Me.txtPumpRestartDelayRB.TabIndex = 82
        Me.txtPumpRestartDelayRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPumpRestartDelayRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPumpRestartDelayRB.UseScientificFormat = True
        '
        'txtRepurgeCyclesRB
        '
        Me.txtRepurgeCyclesRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRepurgeCyclesRB.Clickable = False
        Me.txtRepurgeCyclesRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRepurgeCyclesRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRepurgeCyclesRB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRepurgeCyclesRB.IsReadBack = True
        Me.txtRepurgeCyclesRB.Location = New System.Drawing.Point(236, 72)
        Me.txtRepurgeCyclesRB.Name = "txtRepurgeCyclesRB"
        Me.txtRepurgeCyclesRB.ReadOnly = True
        Me.txtRepurgeCyclesRB.Size = New System.Drawing.Size(128, 24)
        Me.txtRepurgeCyclesRB.TabIndex = 83
        Me.txtRepurgeCyclesRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRepurgeCyclesRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRepurgeCyclesRB.UseScientificFormat = True
        '
        'txtRoughtToPressureRB
        '
        Me.txtRoughtToPressureRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRoughtToPressureRB.Clickable = False
        Me.txtRoughtToPressureRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRoughtToPressureRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRoughtToPressureRB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRoughtToPressureRB.IsReadBack = True
        Me.txtRoughtToPressureRB.Location = New System.Drawing.Point(236, 105)
        Me.txtRoughtToPressureRB.Name = "txtRoughtToPressureRB"
        Me.txtRoughtToPressureRB.ReadOnly = True
        Me.txtRoughtToPressureRB.Size = New System.Drawing.Size(128, 24)
        Me.txtRoughtToPressureRB.TabIndex = 84
        Me.txtRoughtToPressureRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRoughtToPressureRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRoughtToPressureRB.UseScientificFormat = True
        '
        'txtRateOfRiseRB
        '
        Me.txtRateOfRiseRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRateOfRiseRB.Clickable = False
        Me.txtRateOfRiseRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRateOfRiseRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRateOfRiseRB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRateOfRiseRB.IsReadBack = True
        Me.txtRateOfRiseRB.Location = New System.Drawing.Point(236, 138)
        Me.txtRateOfRiseRB.Name = "txtRateOfRiseRB"
        Me.txtRateOfRiseRB.ReadOnly = True
        Me.txtRateOfRiseRB.Size = New System.Drawing.Size(128, 24)
        Me.txtRateOfRiseRB.TabIndex = 85
        Me.txtRateOfRiseRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRateOfRiseRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRateOfRiseRB.UseScientificFormat = True
        '
        'txtStartUpTempRB
        '
        Me.txtStartUpTempRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStartUpTempRB.Clickable = False
        Me.txtStartUpTempRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStartUpTempRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStartUpTempRB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStartUpTempRB.IsReadBack = True
        Me.txtStartUpTempRB.Location = New System.Drawing.Point(236, 171)
        Me.txtStartUpTempRB.Name = "txtStartUpTempRB"
        Me.txtStartUpTempRB.ReadOnly = True
        Me.txtStartUpTempRB.Size = New System.Drawing.Size(128, 24)
        Me.txtStartUpTempRB.TabIndex = 86
        Me.txtStartUpTempRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtStartUpTempRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtStartUpTempRB.UseScientificFormat = True
        '
        'txtExtendedPurgeTime
        '
        Me.txtExtendedPurgeTime.BackColor = System.Drawing.Color.White
        Me.txtExtendedPurgeTime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtExtendedPurgeTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtExtendedPurgeTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtExtendedPurgeTime.IsNumericTextbox = True
        Me.txtExtendedPurgeTime.IsReadBack = False
        Me.txtExtendedPurgeTime.Location = New System.Drawing.Point(373, 6)
        Me.txtExtendedPurgeTime.Name = "txtExtendedPurgeTime"
        Me.txtExtendedPurgeTime.ReadOnly = True
        Me.txtExtendedPurgeTime.Size = New System.Drawing.Size(149, 24)
        Me.txtExtendedPurgeTime.TabIndex = 87
        Me.txtExtendedPurgeTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtExtendedPurgeTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtPumpRestartDelay
        '
        Me.txtPumpRestartDelay.BackColor = System.Drawing.Color.White
        Me.txtPumpRestartDelay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPumpRestartDelay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPumpRestartDelay.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPumpRestartDelay.IsNumericTextbox = True
        Me.txtPumpRestartDelay.IsReadBack = False
        Me.txtPumpRestartDelay.Location = New System.Drawing.Point(373, 39)
        Me.txtPumpRestartDelay.Name = "txtPumpRestartDelay"
        Me.txtPumpRestartDelay.ReadOnly = True
        Me.txtPumpRestartDelay.Size = New System.Drawing.Size(149, 24)
        Me.txtPumpRestartDelay.TabIndex = 88
        Me.txtPumpRestartDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPumpRestartDelay.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtRepurgeCycles
        '
        Me.txtRepurgeCycles.BackColor = System.Drawing.Color.White
        Me.txtRepurgeCycles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRepurgeCycles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRepurgeCycles.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRepurgeCycles.IsNumericTextbox = True
        Me.txtRepurgeCycles.IsReadBack = False
        Me.txtRepurgeCycles.Location = New System.Drawing.Point(373, 72)
        Me.txtRepurgeCycles.Name = "txtRepurgeCycles"
        Me.txtRepurgeCycles.ReadOnly = True
        Me.txtRepurgeCycles.Size = New System.Drawing.Size(149, 24)
        Me.txtRepurgeCycles.TabIndex = 89
        Me.txtRepurgeCycles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRepurgeCycles.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtRoughToPressure
        '
        Me.txtRoughToPressure.BackColor = System.Drawing.Color.White
        Me.txtRoughToPressure.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRoughToPressure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRoughToPressure.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRoughToPressure.IsNumericTextbox = True
        Me.txtRoughToPressure.IsReadBack = False
        Me.txtRoughToPressure.Location = New System.Drawing.Point(373, 105)
        Me.txtRoughToPressure.Name = "txtRoughToPressure"
        Me.txtRoughToPressure.ReadOnly = True
        Me.txtRoughToPressure.Size = New System.Drawing.Size(149, 24)
        Me.txtRoughToPressure.TabIndex = 90
        Me.txtRoughToPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRoughToPressure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtRateOfRise
        '
        Me.txtRateOfRise.BackColor = System.Drawing.Color.White
        Me.txtRateOfRise.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRateOfRise.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRateOfRise.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRateOfRise.IsNumericTextbox = True
        Me.txtRateOfRise.IsReadBack = False
        Me.txtRateOfRise.Location = New System.Drawing.Point(373, 138)
        Me.txtRateOfRise.Name = "txtRateOfRise"
        Me.txtRateOfRise.ReadOnly = True
        Me.txtRateOfRise.Size = New System.Drawing.Size(149, 24)
        Me.txtRateOfRise.TabIndex = 91
        Me.txtRateOfRise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRateOfRise.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtStartUpTemp
        '
        Me.txtStartUpTemp.BackColor = System.Drawing.Color.White
        Me.txtStartUpTemp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtStartUpTemp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStartUpTemp.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStartUpTemp.IsNumericTextbox = True
        Me.txtStartUpTemp.IsReadBack = False
        Me.txtStartUpTemp.Location = New System.Drawing.Point(373, 171)
        Me.txtStartUpTemp.Name = "txtStartUpTemp"
        Me.txtStartUpTemp.ReadOnly = True
        Me.txtStartUpTemp.Size = New System.Drawing.Size(149, 24)
        Me.txtStartUpTemp.TabIndex = 92
        Me.txtStartUpTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtStartUpTemp.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'CryoPopUpPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(548, 400)
        Me.Name = "CryoPopUpPanel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TMPopUpPanel"
        Me.FormContainer.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFastRegen As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnCryoRegen As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnCryoOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblPadding As System.Windows.Forms.Label
    Friend WithEvents lblRegenHours As System.Windows.Forms.Label
    Friend WithEvents txtCryo_LifeTimeHours As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtCryo_RegenHours As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblLifeTimeHours As System.Windows.Forms.Label
    Friend WithEvents lblRegenStatus As System.Windows.Forms.Label
    Friend WithEvents txtCryoRegenStatus As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtExtendedPurgeTimeRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPumpRestartDelayRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRepurgeCyclesRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRoughtToPressureRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRateOfRiseRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtStartUpTempRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtExtendedPurgeTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPumpRestartDelay As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRepurgeCycles As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRoughToPressure As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRateOfRise As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtStartUpTemp As AVP_Robot_Project.SL_Textbox
End Class
