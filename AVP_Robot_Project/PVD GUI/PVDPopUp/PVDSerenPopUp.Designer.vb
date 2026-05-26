<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDSerenPopUp
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
        Me.gbTripPoint1 = New System.Windows.Forms.GroupBox
        Me.txtErrorMessageTemp = New AVP_Robot_Project.PVDTextbox
        Me.txtReflectedPower = New AVP_Robot_Project.SL_Textbox
        Me.txtForwardPower = New AVP_Robot_Project.SL_Textbox
        Me.txtForwardPowerRight = New AVP_Robot_Project.PVDTextbox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbTextError = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblPadding = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbTripPoint2 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPhase = New AVP_Robot_Project.SL_Textbox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMag = New AVP_Robot_Project.SL_Textbox
        Me.txtVoltageRight = New System.Windows.Forms.TextBox
        Me.btnAuto = New AVP_Robot_Project.ButtonIGCGControl
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtC1Right = New System.Windows.Forms.TextBox
        Me.txtC2Right = New System.Windows.Forms.TextBox
        Me.txtPresetsRight = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPresets = New AVP_Robot_Project.SL_Textbox
        Me.txtMatch = New AVP_Robot_Project.SL_Textbox
        Me.txtC2 = New AVP_Robot_Project.SL_Textbox
        Me.txtC1 = New AVP_Robot_Project.SL_Textbox
        Me.txtVoltage = New AVP_Robot_Project.SL_Textbox
        Me.FormContainer.SuspendLayout()
        Me.gbTripPoint1.SuspendLayout()
        Me.gbTripPoint2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.gbTripPoint2)
        Me.FormContainer.Controls.Add(Me.gbTripPoint1)
        Me.FormContainer.Controls.Add(Me.lblPadding)
        Me.FormContainer.Controls.Add(Me.Label1)
        Me.FormContainer.Size = New System.Drawing.Size(494, 332)
        '
        'gbTripPoint1
        '
        Me.gbTripPoint1.BackColor = System.Drawing.Color.Transparent
        Me.gbTripPoint1.Controls.Add(Me.txtErrorMessageTemp)
        Me.gbTripPoint1.Controls.Add(Me.txtReflectedPower)
        Me.gbTripPoint1.Controls.Add(Me.txtForwardPower)
        Me.gbTripPoint1.Controls.Add(Me.txtForwardPowerRight)
        Me.gbTripPoint1.Controls.Add(Me.Label2)
        Me.gbTripPoint1.Controls.Add(Me.lbTextError)
        Me.gbTripPoint1.Controls.Add(Me.Label10)
        Me.gbTripPoint1.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbTripPoint1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTripPoint1.Location = New System.Drawing.Point(5, 0)
        Me.gbTripPoint1.Name = "gbTripPoint1"
        Me.gbTripPoint1.Size = New System.Drawing.Size(484, 111)
        Me.gbTripPoint1.TabIndex = 78
        Me.gbTripPoint1.TabStop = False
        Me.gbTripPoint1.Text = "Power Supply"
        '
        'txtErrorMessageTemp
        '
        Me.txtErrorMessageTemp.BackColor = System.Drawing.SystemColors.Window
        Me.txtErrorMessageTemp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtErrorMessageTemp.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtErrorMessageTemp.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtErrorMessageTemp.Location = New System.Drawing.Point(30, 78)
        Me.txtErrorMessageTemp.Name = "txtErrorMessageTemp"
        Me.txtErrorMessageTemp.ReadOnly = True
        Me.txtErrorMessageTemp.Size = New System.Drawing.Size(127, 24)
        Me.txtErrorMessageTemp.TabIndex = 35
        Me.txtErrorMessageTemp.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtErrorMessageTemp.Visible = False
        '
        'txtReflectedPower
        '
        Me.txtReflectedPower.AccessibleName = "Reflected Power"
        Me.txtReflectedPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtReflectedPower.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtReflectedPower.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtReflectedPower.IsReadBack = True
        Me.txtReflectedPower.Location = New System.Drawing.Point(201, 53)
        Me.txtReflectedPower.Name = "txtReflectedPower"
        Me.txtReflectedPower.ReadOnly = True
        Me.txtReflectedPower.Size = New System.Drawing.Size(127, 24)
        Me.txtReflectedPower.TabIndex = 31
        Me.txtReflectedPower.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtReflectedPower.UseScientificFormat = True
        '
        'txtForwardPower
        '
        Me.txtForwardPower.AccessibleName = "Forward Power"
        Me.txtForwardPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtForwardPower.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtForwardPower.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtForwardPower.IsReadBack = True
        Me.txtForwardPower.Location = New System.Drawing.Point(201, 28)
        Me.txtForwardPower.Name = "txtForwardPower"
        Me.txtForwardPower.ReadOnly = True
        Me.txtForwardPower.Size = New System.Drawing.Size(127, 24)
        Me.txtForwardPower.TabIndex = 22
        Me.txtForwardPower.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtForwardPower.UseScientificFormat = True
        '
        'txtForwardPowerRight
        '
        Me.txtForwardPowerRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtForwardPowerRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtForwardPowerRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtForwardPowerRight.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtForwardPowerRight.Location = New System.Drawing.Point(341, 28)
        Me.txtForwardPowerRight.Name = "txtForwardPowerRight"
        Me.txtForwardPowerRight.ReadOnly = True
        Me.txtForwardPowerRight.Size = New System.Drawing.Size(127, 24)
        Me.txtForwardPowerRight.TabIndex = 34
        Me.txtForwardPowerRight.UseBackGroundWorkerToUpdateMinMax = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 19)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Forward Power (Watts)"
        '
        'lbTextError
        '
        Me.lbTextError.BackColor = System.Drawing.Color.Transparent
        Me.lbTextError.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTextError.ForeColor = System.Drawing.Color.Red
        Me.lbTextError.Location = New System.Drawing.Point(26, 82)
        Me.lbTextError.Name = "lbTextError"
        Me.lbTextError.Size = New System.Drawing.Size(442, 29)
        Me.lbTextError.TabIndex = 25
        Me.lbTextError.Text = "   "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(26, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(172, 19)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Reflected Power (Watts)"
        '
        'lblPadding
        '
        Me.lblPadding.BackColor = System.Drawing.Color.Transparent
        Me.lblPadding.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPadding.Location = New System.Drawing.Point(0, 0)
        Me.lblPadding.Name = "lblPadding"
        Me.lblPadding.Size = New System.Drawing.Size(5, 332)
        Me.lblPadding.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Location = New System.Drawing.Point(489, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 332)
        Me.Label1.TabIndex = 79
        '
        'gbTripPoint2
        '
        Me.gbTripPoint2.BackColor = System.Drawing.Color.Transparent
        Me.gbTripPoint2.Controls.Add(Me.Label9)
        Me.gbTripPoint2.Controls.Add(Me.txtPhase)
        Me.gbTripPoint2.Controls.Add(Me.Label8)
        Me.gbTripPoint2.Controls.Add(Me.txtMag)
        Me.gbTripPoint2.Controls.Add(Me.txtVoltageRight)
        Me.gbTripPoint2.Controls.Add(Me.btnAuto)
        Me.gbTripPoint2.Controls.Add(Me.Label5)
        Me.gbTripPoint2.Controls.Add(Me.Label4)
        Me.gbTripPoint2.Controls.Add(Me.Label7)
        Me.gbTripPoint2.Controls.Add(Me.Label6)
        Me.gbTripPoint2.Controls.Add(Me.txtC1Right)
        Me.gbTripPoint2.Controls.Add(Me.txtC2Right)
        Me.gbTripPoint2.Controls.Add(Me.txtPresetsRight)
        Me.gbTripPoint2.Controls.Add(Me.Label3)
        Me.gbTripPoint2.Controls.Add(Me.txtPresets)
        Me.gbTripPoint2.Controls.Add(Me.txtMatch)
        Me.gbTripPoint2.Controls.Add(Me.txtC2)
        Me.gbTripPoint2.Controls.Add(Me.txtC1)
        Me.gbTripPoint2.Controls.Add(Me.txtVoltage)
        Me.gbTripPoint2.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbTripPoint2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTripPoint2.Location = New System.Drawing.Point(5, 111)
        Me.gbTripPoint2.Name = "gbTripPoint2"
        Me.gbTripPoint2.Size = New System.Drawing.Size(484, 214)
        Me.gbTripPoint2.TabIndex = 82
        Me.gbTripPoint2.TabStop = False
        Me.gbTripPoint2.Text = "Match Box"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(26, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 19)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Phase (mV)"
        '
        'txtPhase
        '
        Me.txtPhase.AccessibleName = "Voltage"
        Me.txtPhase.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPhase.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPhase.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPhase.IsReadBack = True
        Me.txtPhase.Location = New System.Drawing.Point(201, 56)
        Me.txtPhase.Name = "txtPhase"
        Me.txtPhase.ReadOnly = True
        Me.txtPhase.Size = New System.Drawing.Size(127, 24)
        Me.txtPhase.TabIndex = 64
        Me.txtPhase.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPhase.UseScientificFormat = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(26, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 19)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Mag (mV)"
        '
        'txtMag
        '
        Me.txtMag.AccessibleName = "Voltage"
        Me.txtMag.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMag.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMag.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMag.IsReadBack = True
        Me.txtMag.Location = New System.Drawing.Point(201, 30)
        Me.txtMag.Name = "txtMag"
        Me.txtMag.ReadOnly = True
        Me.txtMag.Size = New System.Drawing.Size(127, 24)
        Me.txtMag.TabIndex = 62
        Me.txtMag.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMag.UseScientificFormat = True
        '
        'txtVoltageRight
        '
        Me.txtVoltageRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtVoltageRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtVoltageRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtVoltageRight.Location = New System.Drawing.Point(341, 82)
        Me.txtVoltageRight.Name = "txtVoltageRight"
        Me.txtVoltageRight.ReadOnly = True
        Me.txtVoltageRight.Size = New System.Drawing.Size(127, 24)
        Me.txtVoltageRight.TabIndex = 60
        '
        'btnAuto
        '
        Me.btnAuto.BackColor = System.Drawing.Color.Transparent
        Me.btnAuto.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAuto.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAuto.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAuto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAuto.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnAuto.FlatAppearance.BorderSize = 0
        Me.btnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAuto.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAuto.ForeColor = System.Drawing.Color.Black
        Me.btnAuto.Location = New System.Drawing.Point(341, 160)
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAuto.OffText = "Auto"
        Me.btnAuto.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAuto.OnText = "Manual"
        Me.btnAuto.Size = New System.Drawing.Size(127, 24)
        Me.btnAuto.TabIndex = 59
        Me.btnAuto.Text = "Auto"
        Me.btnAuto.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnAuto.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 19)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Presets"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 19)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Match"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 19)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "C2 (%)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 19)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "C1 (%)"
        '
        'txtC1Right
        '
        Me.txtC1Right.BackColor = System.Drawing.SystemColors.Window
        Me.txtC1Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtC1Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC1Right.Location = New System.Drawing.Point(341, 108)
        Me.txtC1Right.Name = "txtC1Right"
        Me.txtC1Right.ReadOnly = True
        Me.txtC1Right.Size = New System.Drawing.Size(127, 24)
        Me.txtC1Right.TabIndex = 54
        '
        'txtC2Right
        '
        Me.txtC2Right.BackColor = System.Drawing.SystemColors.Window
        Me.txtC2Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtC2Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC2Right.Location = New System.Drawing.Point(341, 134)
        Me.txtC2Right.Name = "txtC2Right"
        Me.txtC2Right.ReadOnly = True
        Me.txtC2Right.Size = New System.Drawing.Size(127, 24)
        Me.txtC2Right.TabIndex = 52
        '
        'txtPresetsRight
        '
        Me.txtPresetsRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtPresetsRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPresetsRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPresetsRight.Location = New System.Drawing.Point(341, 186)
        Me.txtPresetsRight.Name = "txtPresetsRight"
        Me.txtPresetsRight.ReadOnly = True
        Me.txtPresetsRight.Size = New System.Drawing.Size(127, 24)
        Me.txtPresetsRight.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 19)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Voltage (Volts)"
        '
        'txtPresets
        '
        Me.txtPresets.AccessibleName = "Preset"
        Me.txtPresets.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPresets.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPresets.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPresets.IsReadBack = True
        Me.txtPresets.Location = New System.Drawing.Point(201, 186)
        Me.txtPresets.Name = "txtPresets"
        Me.txtPresets.ReadOnly = True
        Me.txtPresets.Size = New System.Drawing.Size(127, 24)
        Me.txtPresets.TabIndex = 48
        Me.txtPresets.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPresets.UseScientificFormat = True
        '
        'txtMatch
        '
        Me.txtMatch.AccessibleName = "Match"
        Me.txtMatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMatch.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMatch.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMatch.IsReadBack = True
        Me.txtMatch.Location = New System.Drawing.Point(201, 160)
        Me.txtMatch.Name = "txtMatch"
        Me.txtMatch.ReadOnly = True
        Me.txtMatch.Size = New System.Drawing.Size(127, 24)
        Me.txtMatch.TabIndex = 47
        Me.txtMatch.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMatch.UseScientificFormat = True
        '
        'txtC2
        '
        Me.txtC2.AccessibleName = "C2"
        Me.txtC2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtC2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtC2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC2.IsReadBack = True
        Me.txtC2.Location = New System.Drawing.Point(201, 134)
        Me.txtC2.Name = "txtC2"
        Me.txtC2.ReadOnly = True
        Me.txtC2.Size = New System.Drawing.Size(127, 24)
        Me.txtC2.TabIndex = 51
        Me.txtC2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtC2.UseScientificFormat = True
        '
        'txtC1
        '
        Me.txtC1.AccessibleName = "C1"
        Me.txtC1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtC1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtC1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC1.IsReadBack = True
        Me.txtC1.Location = New System.Drawing.Point(201, 108)
        Me.txtC1.Name = "txtC1"
        Me.txtC1.ReadOnly = True
        Me.txtC1.Size = New System.Drawing.Size(127, 24)
        Me.txtC1.TabIndex = 49
        Me.txtC1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtC1.UseScientificFormat = True
        '
        'txtVoltage
        '
        Me.txtVoltage.AccessibleName = "Voltage"
        Me.txtVoltage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVoltage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtVoltage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtVoltage.IsReadBack = True
        Me.txtVoltage.Location = New System.Drawing.Point(201, 82)
        Me.txtVoltage.Name = "txtVoltage"
        Me.txtVoltage.ReadOnly = True
        Me.txtVoltage.Size = New System.Drawing.Size(127, 24)
        Me.txtVoltage.TabIndex = 50
        Me.txtVoltage.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtVoltage.UseScientificFormat = True
        '
        'PVDSerenPopUp
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.WhitePanel
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(504, 377)
        Me.Name = "PVDSerenPopUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TMPopUpPanel"
        Me.FormContainer.ResumeLayout(False)
        Me.gbTripPoint1.ResumeLayout(False)
        Me.gbTripPoint1.PerformLayout()
        Me.gbTripPoint2.ResumeLayout(False)
        Me.gbTripPoint2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTripPoint1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPadding As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbTripPoint2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReflectedPower As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtForwardPower As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtForwardPowerRight As AVP_Robot_Project.PVDTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbTextError As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPhase As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMag As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtVoltageRight As System.Windows.Forms.TextBox
    Friend WithEvents btnAuto As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtC1Right As System.Windows.Forms.TextBox
    Friend WithEvents txtC2Right As System.Windows.Forms.TextBox
    Friend WithEvents txtPresetsRight As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPresets As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtMatch As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtC2 As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtC1 As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtVoltage As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtErrorMessageTemp As AVP_Robot_Project.PVDTextbox
End Class
