<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CGGaugesFrm
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
        Me.btnTurnIGOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnTurnIGOn = New AVP_Robot_Project.SL_CustomButton
        Me.btnPumpOff = New AVP_Robot_Project.SL_CustomButton
        Me.btnPumpOn = New AVP_Robot_Project.SL_CustomButton
        Me.btnVAC = New AVP_Robot_Project.SL_CustomButton
        Me.btnATM = New AVP_Robot_Project.SL_CustomButton
        Me.grbCG = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCGPress = New AVP_Robot_Project.SL_Textbox
        Me.btnRelease = New AVP_Robot_Project.SL_CustomButton
        Me.btnIGFilament2 = New AVP_Robot_Project.SL_CustomButton
        Me.btnIGFilament1 = New AVP_Robot_Project.SL_CustomButton
        Me.FormContainer.SuspendLayout()
        Me.grbCG.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.btnIGFilament2)
        Me.FormContainer.Controls.Add(Me.btnIGFilament1)
        Me.FormContainer.Controls.Add(Me.grbCG)
        Me.FormContainer.Controls.Add(Me.btnRelease)
        Me.FormContainer.Controls.Add(Me.btnTurnIGOff)
        Me.FormContainer.Controls.Add(Me.btnTurnIGOn)
        Me.FormContainer.Controls.Add(Me.btnPumpOff)
        Me.FormContainer.Controls.Add(Me.btnPumpOn)
        Me.FormContainer.Controls.Add(Me.btnVAC)
        Me.FormContainer.Controls.Add(Me.btnATM)
        Me.FormContainer.Size = New System.Drawing.Size(331, 284)
        '
        'grbCG
        '
        Me.grbCG.BackColor = System.Drawing.Color.Transparent
        Me.grbCG.Controls.Add(Me.Label3)
        Me.grbCG.Controls.Add(Me.txtCGPress)
        Me.grbCG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grbCG.Location = New System.Drawing.Point(0, 229)
        Me.grbCG.Name = "grbCG"
        Me.grbCG.Size = New System.Drawing.Size(331, 55)
        Me.grbCG.TabIndex = 93
        Me.grbCG.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 19)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "CG Pressure (Torr)"
        '
        'btnIGFilament2
        '
        Me.btnIGFilament2.AccessibleDescription = ""
        Me.btnIGFilament2.AccessibleName = "btnIGFilament2"
        Me.btnIGFilament2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnIGFilament2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIGFilament2.Clickable = True
        Me.btnIGFilament2.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnIGFilament2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIGFilament2.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnIGFilament2.FlatAppearance.BorderSize = 0
        Me.btnIGFilament2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIGFilament2.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnIGFilament2.ForeColor = System.Drawing.Color.Black
        Me.btnIGFilament2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIGFilament2.IsSingleFunction = True
        Me.btnIGFilament2.Location = New System.Drawing.Point(193, 10)
        Me.btnIGFilament2.MessageBox_IsNot_BaseOn_Status = True
        Me.btnIGFilament2.MessageBoxText = "Switch to filament 2"
        Me.btnIGFilament2.Name = "btnIGFilament2"
        Me.btnIGFilament2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnIGFilament2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnIGFilament2.Size = New System.Drawing.Size(110, 27)
        Me.btnIGFilament2.TabIndex = 101
        Me.btnIGFilament2.Text = "IG Filament 2"
        Me.btnIGFilament2.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnIGFilament2.UseChangeValueToSend_BaseOnStatus = True
        Me.btnIGFilament2.UseVisualStyleBackColor = True
        Me.btnIGFilament2.ValueToBeSend = "On"
        Me.btnIGFilament2.ValueToSend_WhenStatusOn = "On"
        Me.btnIGFilament2.ValueToSend_WhenStatusUnknown = "Off"
        '
        'btnIGFilament1
        '
        Me.btnIGFilament1.AccessibleDescription = ""
        Me.btnIGFilament1.AccessibleName = "btnIGFilament1"
        Me.btnIGFilament1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnIGFilament1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIGFilament1.Clickable = True
        Me.btnIGFilament1.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnIGFilament1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIGFilament1.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnIGFilament1.FlatAppearance.BorderSize = 0
        Me.btnIGFilament1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIGFilament1.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnIGFilament1.ForeColor = System.Drawing.Color.Black
        Me.btnIGFilament1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIGFilament1.IsSingleFunction = True
        Me.btnIGFilament1.Location = New System.Drawing.Point(31, 10)
        Me.btnIGFilament1.MessageBox_IsNot_BaseOn_Status = True
        Me.btnIGFilament1.MessageBoxText = "Switch to filament 1"
        Me.btnIGFilament1.Name = "btnIGFilament1"
        Me.btnIGFilament1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnIGFilament1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnIGFilament1.Size = New System.Drawing.Size(110, 27)
        Me.btnIGFilament1.TabIndex = 100
        Me.btnIGFilament1.Text = "IG Filament 1"
        Me.btnIGFilament1.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnIGFilament1.UseChangeValueToSend_BaseOnStatus = True
        Me.btnIGFilament1.UseVisualStyleBackColor = True
        Me.btnIGFilament1.ValueToBeSend = "On"
        Me.btnIGFilament1.ValueToSend_WhenStatusOn = "On"
        Me.btnIGFilament1.ValueToSend_WhenStatusUnknown = "Off"
        '
        'txtCGPress
        '
        Me.txtCGPress.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCGPress.Clickable = False
        Me.txtCGPress.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCGPress.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCGPress.IsReadBack = True
        Me.txtCGPress.Location = New System.Drawing.Point(191, 19)
        Me.txtCGPress.MinimumValueHighlightedGreen = 0
        Me.txtCGPress.Name = "txtCGPress"
        Me.txtCGPress.ReadOnly = True
        Me.txtCGPress.Size = New System.Drawing.Size(110, 24)
        Me.txtCGPress.TabIndex = 0
        Me.txtCGPress.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCGPress.UseScientificFormat = True
        '
        'btnRelease
        '
        Me.btnRelease.AccessibleDescription = ""
        Me.btnRelease.AccessibleName = ""
        Me.btnRelease.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRelease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRelease.Clickable = True
        Me.btnRelease.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRelease.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRelease.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRelease.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnRelease.FlatAppearance.BorderSize = 0
        Me.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelease.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRelease.ForeColor = System.Drawing.Color.Black
        Me.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRelease.IsSingleFunction = True
        Me.btnRelease.Location = New System.Drawing.Point(94, 190)
        Me.btnRelease.LogSource = "Turn Off Mechanical Pump"
        Me.btnRelease.MessageBox_IsNot_BaseOn_Status = True
        Me.btnRelease.MessageBoxText = "Turn Off Mechanical Pump"
        Me.btnRelease.Name = "btnRelease"
        Me.btnRelease.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRelease.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnRelease.Size = New System.Drawing.Size(155, 27)
        Me.btnRelease.TabIndex = 94
        Me.btnRelease.Text = "Release MP Control"
        Me.btnRelease.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnRelease.UseChangeValueToSend_BaseOnStatus = True
        Me.btnRelease.UseClickedEventInForm = True
        Me.btnRelease.UseVisualStyleBackColor = True
        Me.btnRelease.ValueToBeSend = "On"
        Me.btnRelease.ValueToSend_WhenStatusOn = "On"
        Me.btnRelease.ValueToSend_WhenStatusUnknown = "Off"
        Me.btnRelease.Visible = False
        '
        'btnTurnIGOff
        '
        Me.btnTurnIGOff.AccessibleDescription = ""
        Me.btnTurnIGOff.AccessibleName = "btnTurnIGOff"
        Me.btnTurnIGOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTurnIGOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurnIGOff.Clickable = True
        Me.btnTurnIGOff.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurnIGOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTurnIGOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurnIGOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTurnIGOff.FlatAppearance.BorderSize = 0
        Me.btnTurnIGOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurnIGOff.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnTurnIGOff.ForeColor = System.Drawing.Color.Black
        Me.btnTurnIGOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTurnIGOff.IsSingleFunction = True
        Me.btnTurnIGOff.Location = New System.Drawing.Point(193, 54)
        Me.btnTurnIGOff.MessageBox_IsNot_BaseOn_Status = True
        Me.btnTurnIGOff.MessageBoxText = "Turn Off IG"
        Me.btnTurnIGOff.Name = "btnTurnIGOff"
        Me.btnTurnIGOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTurnIGOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTurnIGOff.Size = New System.Drawing.Size(110, 27)
        Me.btnTurnIGOff.TabIndex = 92
        Me.btnTurnIGOff.Text = "IG Off"
        Me.btnTurnIGOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTurnIGOff.UseChangeValueToSend_BaseOnStatus = True
        Me.btnTurnIGOff.UseVisualStyleBackColor = True
        Me.btnTurnIGOff.ValueToBeSend = "On"
        Me.btnTurnIGOff.ValueToSend_WhenStatusOn = "On"
        Me.btnTurnIGOff.ValueToSend_WhenStatusUnknown = "Off"
        Me.btnTurnIGOff.Visible = False
        '
        'btnTurnIGOn
        '
        Me.btnTurnIGOn.AccessibleDescription = ""
        Me.btnTurnIGOn.AccessibleName = "btnTurnIGOn"
        Me.btnTurnIGOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTurnIGOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurnIGOn.Clickable = True
        Me.btnTurnIGOn.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTurnIGOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTurnIGOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTurnIGOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTurnIGOn.FlatAppearance.BorderSize = 0
        Me.btnTurnIGOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurnIGOn.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnTurnIGOn.ForeColor = System.Drawing.Color.Black
        Me.btnTurnIGOn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTurnIGOn.IsSingleFunction = True
        Me.btnTurnIGOn.Location = New System.Drawing.Point(31, 54)
        Me.btnTurnIGOn.MessageBox_IsNot_BaseOn_Status = True
        Me.btnTurnIGOn.MessageBoxText = "Turn On IG"
        Me.btnTurnIGOn.Name = "btnTurnIGOn"
        Me.btnTurnIGOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTurnIGOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTurnIGOn.Size = New System.Drawing.Size(110, 27)
        Me.btnTurnIGOn.TabIndex = 91
        Me.btnTurnIGOn.Text = "IG On"
        Me.btnTurnIGOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTurnIGOn.UseChangeValueToSend_BaseOnStatus = True
        Me.btnTurnIGOn.UseVisualStyleBackColor = True
        Me.btnTurnIGOn.ValueToBeSend = "On"
        Me.btnTurnIGOn.ValueToSend_WhenStatusOn = "On"
        Me.btnTurnIGOn.ValueToSend_WhenStatusUnknown = "Off"
        Me.btnTurnIGOn.Visible = False
        '
        'btnPumpOff
        '
        Me.btnPumpOff.AccessibleDescription = ""
        Me.btnPumpOff.AccessibleName = "btnPumpOff"
        Me.btnPumpOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPumpOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPumpOff.Clickable = True
        Me.btnPumpOff.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnPumpOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPumpOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPumpOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnPumpOff.FlatAppearance.BorderSize = 0
        Me.btnPumpOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPumpOff.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnPumpOff.ForeColor = System.Drawing.Color.Black
        Me.btnPumpOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPumpOff.IsSingleFunction = True
        Me.btnPumpOff.Location = New System.Drawing.Point(193, 150)
        Me.btnPumpOff.LogSource = "Turn Off Mechanical Pump"
        Me.btnPumpOff.MessageBox_IsNot_BaseOn_Status = True
        Me.btnPumpOff.MessageBoxText = "Turn Off Mechanical Pump"
        Me.btnPumpOff.Name = "btnPumpOff"
        Me.btnPumpOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPumpOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnPumpOff.Size = New System.Drawing.Size(110, 27)
        Me.btnPumpOff.TabIndex = 90
        Me.btnPumpOff.Text = "Pump Off"
        Me.btnPumpOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnPumpOff.UseChangeValueToSend_BaseOnStatus = True
        Me.btnPumpOff.UseVisualStyleBackColor = True
        Me.btnPumpOff.ValueToBeSend = "On"
        Me.btnPumpOff.ValueToSend_WhenStatusOn = "On"
        Me.btnPumpOff.ValueToSend_WhenStatusUnknown = "Off"
        '
        'btnPumpOn
        '
        Me.btnPumpOn.AccessibleDescription = ""
        Me.btnPumpOn.AccessibleName = "btnPumpOn"
        Me.btnPumpOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPumpOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPumpOn.Clickable = True
        Me.btnPumpOn.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnPumpOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPumpOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPumpOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnPumpOn.FlatAppearance.BorderSize = 0
        Me.btnPumpOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPumpOn.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnPumpOn.ForeColor = System.Drawing.Color.Black
        Me.btnPumpOn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPumpOn.IsSingleFunction = True
        Me.btnPumpOn.Location = New System.Drawing.Point(31, 150)
        Me.btnPumpOn.LogSource = "Turn On Mechanical Pump"
        Me.btnPumpOn.MessageBox_IsNot_BaseOn_Status = True
        Me.btnPumpOn.MessageBoxText = "Turn On Mechanical Pump"
        Me.btnPumpOn.Name = "btnPumpOn"
        Me.btnPumpOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPumpOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnPumpOn.Size = New System.Drawing.Size(110, 27)
        Me.btnPumpOn.TabIndex = 89
        Me.btnPumpOn.Text = "Pump On"
        Me.btnPumpOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnPumpOn.UseChangeValueToSend_BaseOnStatus = True
        Me.btnPumpOn.UseVisualStyleBackColor = True
        Me.btnPumpOn.ValueToBeSend = "On"
        Me.btnPumpOn.ValueToSend_WhenStatusOn = "On"
        Me.btnPumpOn.ValueToSend_WhenStatusUnknown = "Off"
        '
        'btnVAC
        '
        Me.btnVAC.AccessibleDescription = ""
        Me.btnVAC.AccessibleName = "btnVAC"
        Me.btnVAC.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnVAC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVAC.Clickable = True
        Me.btnVAC.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnVAC.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnVAC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVAC.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnVAC.FlatAppearance.BorderSize = 0
        Me.btnVAC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVAC.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnVAC.ForeColor = System.Drawing.Color.Black
        Me.btnVAC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVAC.IsSingleFunction = True
        Me.btnVAC.Location = New System.Drawing.Point(193, 102)
        Me.btnVAC.LogSource = "Set CG VAC"
        Me.btnVAC.MessageBox_IsNot_BaseOn_Status = True
        Me.btnVAC.MessageBoxText = "Set CG VAC"
        Me.btnVAC.Name = "btnVAC"
        Me.btnVAC.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnVAC.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnVAC.Size = New System.Drawing.Size(110, 27)
        Me.btnVAC.TabIndex = 88
        Me.btnVAC.Text = "Set CG VAC"
        Me.btnVAC.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnVAC.UseChangeValueToSend_BaseOnStatus = True
        Me.btnVAC.UseVisualStyleBackColor = True
        Me.btnVAC.ValueToBeSend = "On"
        Me.btnVAC.ValueToSend_WhenStatusOn = "On"
        Me.btnVAC.ValueToSend_WhenStatusUnknown = "Off"
        '
        'btnATM
        '
        Me.btnATM.AccessibleDescription = ""
        Me.btnATM.AccessibleName = "btnATM"
        Me.btnATM.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnATM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnATM.Clickable = True
        Me.btnATM.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnATM.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnATM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnATM.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnATM.FlatAppearance.BorderSize = 0
        Me.btnATM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnATM.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnATM.ForeColor = System.Drawing.Color.Black
        Me.btnATM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnATM.IsSingleFunction = True
        Me.btnATM.Location = New System.Drawing.Point(31, 102)
        Me.btnATM.LogSource = "Set CG ATM"
        Me.btnATM.MessageBox_IsNot_BaseOn_Status = True
        Me.btnATM.MessageBoxText = "Set CG ATM"
        Me.btnATM.Name = "btnATM"
        Me.btnATM.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnATM.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnATM.Size = New System.Drawing.Size(110, 27)
        Me.btnATM.TabIndex = 87
        Me.btnATM.Text = "Set CG ATM"
        Me.btnATM.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnATM.UseChangeValueToSend_BaseOnStatus = True
        Me.btnATM.UseVisualStyleBackColor = True
        Me.btnATM.ValueToBeSend = "On"
        Me.btnATM.ValueToSend_WhenStatusOn = "On"
        Me.btnATM.ValueToSend_WhenStatusUnknown = "Off"
        '
        'CGGaugesFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 329)
        Me.Name = "CGGaugesFrm"
        Me.Text = "CGGaugesFrm"
        Me.FormContainer.ResumeLayout(False)
        Me.grbCG.ResumeLayout(False)
        Me.grbCG.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTurnIGOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTurnIGOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnPumpOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnPumpOn As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnVAC As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnATM As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents grbCG As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCGPress As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnRelease As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnIGFilament2 As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnIGFilament1 As AVP_Robot_Project.SL_CustomButton
End Class
