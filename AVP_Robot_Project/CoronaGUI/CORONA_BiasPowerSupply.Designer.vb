<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CORONA_BiasPowerSupply
    Inherits AVP_Robot_Project.PVDStatusBoard

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
        Me.lblForwardPower = New System.Windows.Forms.Label
        Me.txtForwardPower = New AVP_Robot_Project.SL_Textbox
        Me.lblReflectedPower = New System.Windows.Forms.Label
        Me.txtReflectedPower = New AVP_Robot_Project.SL_Textbox
        Me.txtVoltage = New AVP_Robot_Project.SL_Textbox
        Me.lblVoltage = New System.Windows.Forms.Label
        Me.lblC1 = New System.Windows.Forms.Label
        Me.lblC2 = New System.Windows.Forms.Label
        Me.txtC2 = New AVP_Robot_Project.SL_Textbox
        Me.lblMatch = New System.Windows.Forms.Label
        Me.txtC1 = New AVP_Robot_Project.SL_Textbox
        Me.txtMatch = New AVP_Robot_Project.SL_Textbox
        Me.txtKWH = New AVP_Robot_Project.SL_Textbox
        Me.txtForwardPowerRight = New AVP_Robot_Project.SL_Textbox
        Me.txtC1Right = New AVP_Robot_Project.SL_Textbox
        Me.txtC2Right = New AVP_Robot_Project.SL_Textbox
        Me.btnAuto = New AVP_Robot_Project.SL_CustomButton
        Me.txtTargetCurrent = New AVP_Robot_Project.SL_Textbox
        Me.lblTargetCurrent = New System.Windows.Forms.Label
        Me.txtDCForwardPowerRight = New AVP_Robot_Project.SL_Textbox
        Me.lbErrorMes = New System.Windows.Forms.Label
        Me.txtPulseFrequency = New AVP_Robot_Project.SL_Textbox
        Me.txtPulseFrequencyRight = New AVP_Robot_Project.SL_Textbox
        Me.lblPulseFrequency = New System.Windows.Forms.Label
        Me.txtPulseWidth = New AVP_Robot_Project.SL_Textbox
        Me.txtPulseWidthRight = New AVP_Robot_Project.SL_Textbox
        Me.lblPulseWidth = New System.Windows.Forms.Label
        Me.txtRampTime = New AVP_Robot_Project.SL_Textbox
        Me.txtRampTimeRight = New AVP_Robot_Project.SL_Textbox
        Me.lblRampTime = New System.Windows.Forms.Label
        Me.lblPulseMode = New System.Windows.Forms.Label
        Me.btnPulse = New AVP_Robot_Project.SL_CustomButton
        Me.txtErrorMessage = New AVP_Robot_Project.SL_Textbox
        Me.btnContact = New AVP_Robot_Project.SL_CustomButton
        Me.btnTarget4Switch = New AVP_Robot_Project.SL_CustomButton
        Me.btnTarget3Switch = New AVP_Robot_Project.SL_CustomButton
        Me.btnTarget2Switch = New AVP_Robot_Project.SL_CustomButton
        Me.btnTarget1Switch = New AVP_Robot_Project.SL_CustomButton
        Me.txtVoltageRight = New AVP_Robot_Project.SL_Textbox
        Me.txtGrounded = New AVP_Robot_Project.SL_Textbox
        Me.pnTarget = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnPower = New System.Windows.Forms.Panel
        Me.txtMagnatron = New AVP_Robot_Project.SL_Textbox
        Me.btnMag4RotationStart = New AVP_Robot_Project.SL_CustomButton
        Me.btnMag3RotationStart = New AVP_Robot_Project.SL_CustomButton
        Me.btnMag2RotationStart = New AVP_Robot_Project.SL_CustomButton
        Me.btnMag1RotationStart = New AVP_Robot_Project.SL_CustomButton
        Me.lblMagnatron = New System.Windows.Forms.Label
        Me.lblArcCounter = New System.Windows.Forms.Label
        Me.txtArcCounter = New AVP_Robot_Project.SL_Textbox
        Me.txtPulseMode = New AVP_Robot_Project.SL_Textbox
        Me.lblChuckContactPosition = New System.Windows.Forms.Label
        Me.txtDCForwardPower = New AVP_Robot_Project.SL_Textbox
        Me.txtDCVoltage = New AVP_Robot_Project.SL_Textbox
        Me.pnTarget.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnPower.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(325, 27)
        Me.Header.Text = "Bias Power Supply"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'lblForwardPower
        '
        Me.lblForwardPower.AutoSize = True
        Me.lblForwardPower.BackColor = System.Drawing.Color.Transparent
        Me.lblForwardPower.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForwardPower.Location = New System.Drawing.Point(2, 1)
        Me.lblForwardPower.Name = "lblForwardPower"
        Me.lblForwardPower.Size = New System.Drawing.Size(162, 19)
        Me.lblForwardPower.TabIndex = 8
        Me.lblForwardPower.Text = "Forward Power (Watts)"
        '
        'txtForwardPower
        '
        Me.txtForwardPower.AccessibleName = "Forward Power"
        Me.txtForwardPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtForwardPower.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtForwardPower.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtForwardPower.IsReadBack = True
        Me.txtForwardPower.Location = New System.Drawing.Point(171, 1)
        Me.txtForwardPower.Name = "txtForwardPower"
        Me.txtForwardPower.ReadOnly = True
        Me.txtForwardPower.Size = New System.Drawing.Size(78, 24)
        Me.txtForwardPower.TabIndex = 9
        Me.txtForwardPower.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtForwardPower.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'lblReflectedPower
        '
        Me.lblReflectedPower.AutoSize = True
        Me.lblReflectedPower.BackColor = System.Drawing.Color.Transparent
        Me.lblReflectedPower.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReflectedPower.Location = New System.Drawing.Point(1, 26)
        Me.lblReflectedPower.Name = "lblReflectedPower"
        Me.lblReflectedPower.Size = New System.Drawing.Size(172, 19)
        Me.lblReflectedPower.TabIndex = 11
        Me.lblReflectedPower.Text = "Reflected Power (Watts)"
        '
        'txtReflectedPower
        '
        Me.txtReflectedPower.AccessibleName = "Reflected Power"
        Me.txtReflectedPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtReflectedPower.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtReflectedPower.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtReflectedPower.IsReadBack = True
        Me.txtReflectedPower.Location = New System.Drawing.Point(171, 26)
        Me.txtReflectedPower.Name = "txtReflectedPower"
        Me.txtReflectedPower.ReadOnly = True
        Me.txtReflectedPower.Size = New System.Drawing.Size(78, 24)
        Me.txtReflectedPower.TabIndex = 12
        Me.txtReflectedPower.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtReflectedPower.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtVoltage
        '
        Me.txtVoltage.AccessibleName = "Voltage"
        Me.txtVoltage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVoltage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtVoltage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtVoltage.IsReadBack = True
        Me.txtVoltage.Location = New System.Drawing.Point(171, 51)
        Me.txtVoltage.Name = "txtVoltage"
        Me.txtVoltage.ReadOnly = True
        Me.txtVoltage.Size = New System.Drawing.Size(78, 24)
        Me.txtVoltage.TabIndex = 12
        Me.txtVoltage.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtVoltage.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'lblVoltage
        '
        Me.lblVoltage.AutoSize = True
        Me.lblVoltage.BackColor = System.Drawing.Color.Transparent
        Me.lblVoltage.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoltage.Location = New System.Drawing.Point(2, 51)
        Me.lblVoltage.Name = "lblVoltage"
        Me.lblVoltage.Size = New System.Drawing.Size(108, 19)
        Me.lblVoltage.TabIndex = 11
        Me.lblVoltage.Text = "Voltage (Volts)"
        '
        'lblC1
        '
        Me.lblC1.AutoSize = True
        Me.lblC1.BackColor = System.Drawing.Color.Transparent
        Me.lblC1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblC1.Location = New System.Drawing.Point(2, 76)
        Me.lblC1.Name = "lblC1"
        Me.lblC1.Size = New System.Drawing.Size(95, 19)
        Me.lblC1.TabIndex = 14
        Me.lblC1.Text = "C1/Tune (%)"
        '
        'lblC2
        '
        Me.lblC2.AutoSize = True
        Me.lblC2.BackColor = System.Drawing.Color.Transparent
        Me.lblC2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblC2.Location = New System.Drawing.Point(2, 101)
        Me.lblC2.Name = "lblC2"
        Me.lblC2.Size = New System.Drawing.Size(96, 19)
        Me.lblC2.TabIndex = 14
        Me.lblC2.Text = "C2/Load (%)"
        '
        'txtC2
        '
        Me.txtC2.AccessibleName = "C2"
        Me.txtC2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtC2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtC2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC2.IsReadBack = True
        Me.txtC2.Location = New System.Drawing.Point(171, 101)
        Me.txtC2.Name = "txtC2"
        Me.txtC2.ReadOnly = True
        Me.txtC2.Size = New System.Drawing.Size(78, 24)
        Me.txtC2.TabIndex = 12
        Me.txtC2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtC2.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'lblMatch
        '
        Me.lblMatch.AutoSize = True
        Me.lblMatch.BackColor = System.Drawing.Color.Transparent
        Me.lblMatch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatch.Location = New System.Drawing.Point(2, 126)
        Me.lblMatch.Name = "lblMatch"
        Me.lblMatch.Size = New System.Drawing.Size(53, 19)
        Me.lblMatch.TabIndex = 14
        Me.lblMatch.Text = "Match"
        '
        'txtC1
        '
        Me.txtC1.AccessibleName = "C1"
        Me.txtC1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtC1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtC1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC1.IsReadBack = True
        Me.txtC1.Location = New System.Drawing.Point(171, 76)
        Me.txtC1.Name = "txtC1"
        Me.txtC1.ReadOnly = True
        Me.txtC1.Size = New System.Drawing.Size(78, 24)
        Me.txtC1.TabIndex = 12
        Me.txtC1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtC1.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtMatch
        '
        Me.txtMatch.AccessibleName = "Match"
        Me.txtMatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMatch.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMatch.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMatch.IsReadBack = True
        Me.txtMatch.Location = New System.Drawing.Point(171, 126)
        Me.txtMatch.Name = "txtMatch"
        Me.txtMatch.ReadOnly = True
        Me.txtMatch.Size = New System.Drawing.Size(78, 24)
        Me.txtMatch.TabIndex = 12
        Me.txtMatch.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtMatch.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtKWH
        '
        Me.txtKWH.AccessibleName = "Preset"
        Me.txtKWH.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtKWH.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtKWH.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtKWH.IsReadBack = True
        Me.txtKWH.Location = New System.Drawing.Point(250, 447)
        Me.txtKWH.Name = "txtKWH"
        Me.txtKWH.ReadOnly = True
        Me.txtKWH.Size = New System.Drawing.Size(70, 24)
        Me.txtKWH.TabIndex = 12
        Me.txtKWH.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtKWH.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtKWH.Visible = False
        '
        'txtForwardPowerRight
        '
        Me.txtForwardPowerRight.AccessibleDescription = "TextboxClick"
        Me.txtForwardPowerRight.AccessibleName = "Forward Power"
        Me.txtForwardPowerRight.BackColor = System.Drawing.Color.White
        Me.txtForwardPowerRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtForwardPowerRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtForwardPowerRight.IsNumericTextbox = True
        Me.txtForwardPowerRight.IsReadBack = False
        Me.txtForwardPowerRight.Location = New System.Drawing.Point(250, 1)
        Me.txtForwardPowerRight.Name = "txtForwardPowerRight"
        Me.txtForwardPowerRight.ReadOnly = True
        Me.txtForwardPowerRight.Size = New System.Drawing.Size(70, 24)
        Me.txtForwardPowerRight.TabIndex = 9
        Me.txtForwardPowerRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtForwardPowerRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtForwardPowerRight.UseClickEventInForm = True
        Me.txtForwardPowerRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtC1Right
        '
        Me.txtC1Right.AccessibleDescription = "TextboxClick"
        Me.txtC1Right.AccessibleName = "C1"
        Me.txtC1Right.BackColor = System.Drawing.Color.White
        Me.txtC1Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtC1Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC1Right.IsNumericTextbox = True
        Me.txtC1Right.IsReadBack = False
        Me.txtC1Right.Location = New System.Drawing.Point(250, 76)
        Me.txtC1Right.Name = "txtC1Right"
        Me.txtC1Right.ReadOnly = True
        Me.txtC1Right.Size = New System.Drawing.Size(70, 24)
        Me.txtC1Right.TabIndex = 9
        Me.txtC1Right.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtC1Right.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtC2Right
        '
        Me.txtC2Right.AccessibleDescription = "TextboxClick"
        Me.txtC2Right.AccessibleName = "C2"
        Me.txtC2Right.BackColor = System.Drawing.Color.White
        Me.txtC2Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtC2Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC2Right.IsNumericTextbox = True
        Me.txtC2Right.IsReadBack = False
        Me.txtC2Right.Location = New System.Drawing.Point(250, 101)
        Me.txtC2Right.Name = "txtC2Right"
        Me.txtC2Right.ReadOnly = True
        Me.txtC2Right.Size = New System.Drawing.Size(70, 24)
        Me.txtC2Right.TabIndex = 9
        Me.txtC2Right.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtC2Right.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'btnAuto
        '
        Me.btnAuto.AccessibleDescription = "Auto Mode"
        Me.btnAuto.AccessibleName = "Auto"
        Me.btnAuto.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAuto.Clickable = True
        Me.btnAuto.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAuto.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAuto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAuto.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnAuto.FlatAppearance.BorderSize = 0
        Me.btnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAuto.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAuto.ForeColor = System.Drawing.Color.Black
        Me.btnAuto.Location = New System.Drawing.Point(250, 126)
        Me.btnAuto.MessageBoxText = Nothing
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAuto.OffText = "Auto"
        Me.btnAuto.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAuto.OnText = "Manual"
        Me.btnAuto.Size = New System.Drawing.Size(70, 24)
        Me.btnAuto.TabIndex = 16
        Me.btnAuto.Text = "Auto"
        Me.btnAuto.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnAuto.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnAuto.UseClickedEventInForm = True
        Me.btnAuto.UseVisualStyleBackColor = True
        Me.btnAuto.ValueToBeSend = "On"
        '
        'txtTargetCurrent
        '
        Me.txtTargetCurrent.AccessibleName = "Preset"
        Me.txtTargetCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetCurrent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetCurrent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetCurrent.IsReadBack = True
        Me.txtTargetCurrent.Location = New System.Drawing.Point(171, 205)
        Me.txtTargetCurrent.Name = "txtTargetCurrent"
        Me.txtTargetCurrent.ReadOnly = True
        Me.txtTargetCurrent.Size = New System.Drawing.Size(78, 24)
        Me.txtTargetCurrent.TabIndex = 12
        Me.txtTargetCurrent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtTargetCurrent.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Two_Digits
        Me.txtTargetCurrent.Visible = False
        '
        'lblTargetCurrent
        '
        Me.lblTargetCurrent.AutoSize = True
        Me.lblTargetCurrent.BackColor = System.Drawing.Color.Transparent
        Me.lblTargetCurrent.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetCurrent.Location = New System.Drawing.Point(2, 207)
        Me.lblTargetCurrent.Name = "lblTargetCurrent"
        Me.lblTargetCurrent.Size = New System.Drawing.Size(134, 19)
        Me.lblTargetCurrent.TabIndex = 14
        Me.lblTargetCurrent.Text = "Target Current (A)"
        Me.lblTargetCurrent.Visible = False
        '
        'txtDCForwardPowerRight
        '
        Me.txtDCForwardPowerRight.AccessibleDescription = "TextboxClick"
        Me.txtDCForwardPowerRight.AccessibleName = "DC Forward Power"
        Me.txtDCForwardPowerRight.BackColor = System.Drawing.Color.White
        Me.txtDCForwardPowerRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtDCForwardPowerRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtDCForwardPowerRight.IsNumericTextbox = True
        Me.txtDCForwardPowerRight.IsReadBack = False
        Me.txtDCForwardPowerRight.Location = New System.Drawing.Point(250, 205)
        Me.txtDCForwardPowerRight.Name = "txtDCForwardPowerRight"
        Me.txtDCForwardPowerRight.ReadOnly = True
        Me.txtDCForwardPowerRight.Size = New System.Drawing.Size(70, 24)
        Me.txtDCForwardPowerRight.TabIndex = 9
        Me.txtDCForwardPowerRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtDCForwardPowerRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtDCForwardPowerRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Two_Digits
        Me.txtDCForwardPowerRight.Visible = False
        '
        'lbErrorMes
        '
        Me.lbErrorMes.BackColor = System.Drawing.Color.Transparent
        Me.lbErrorMes.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbErrorMes.ForeColor = System.Drawing.Color.Red
        Me.lbErrorMes.Location = New System.Drawing.Point(2, 181)
        Me.lbErrorMes.Name = "lbErrorMes"
        Me.lbErrorMes.Size = New System.Drawing.Size(321, 25)
        Me.lbErrorMes.TabIndex = 17
        '
        'txtPulseFrequency
        '
        Me.txtPulseFrequency.AccessibleName = "Preset"
        Me.txtPulseFrequency.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPulseFrequency.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPulseFrequency.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPulseFrequency.IsReadBack = True
        Me.txtPulseFrequency.Location = New System.Drawing.Point(171, 237)
        Me.txtPulseFrequency.Name = "txtPulseFrequency"
        Me.txtPulseFrequency.ReadOnly = True
        Me.txtPulseFrequency.Size = New System.Drawing.Size(78, 24)
        Me.txtPulseFrequency.TabIndex = 12
        Me.txtPulseFrequency.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtPulseFrequency.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPulseFrequency.Visible = False
        '
        'txtPulseFrequencyRight
        '
        Me.txtPulseFrequencyRight.AccessibleDescription = "TextboxClick"
        Me.txtPulseFrequencyRight.AccessibleName = "Pulse Frequency"
        Me.txtPulseFrequencyRight.BackColor = System.Drawing.Color.White
        Me.txtPulseFrequencyRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPulseFrequencyRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPulseFrequencyRight.IsNumericTextbox = True
        Me.txtPulseFrequencyRight.IsReadBack = False
        Me.txtPulseFrequencyRight.Location = New System.Drawing.Point(250, 237)
        Me.txtPulseFrequencyRight.Name = "txtPulseFrequencyRight"
        Me.txtPulseFrequencyRight.ReadOnly = True
        Me.txtPulseFrequencyRight.Size = New System.Drawing.Size(70, 24)
        Me.txtPulseFrequencyRight.TabIndex = 9
        Me.txtPulseFrequencyRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtPulseFrequencyRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPulseFrequencyRight.Visible = False
        '
        'lblPulseFrequency
        '
        Me.lblPulseFrequency.AutoSize = True
        Me.lblPulseFrequency.BackColor = System.Drawing.Color.Transparent
        Me.lblPulseFrequency.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPulseFrequency.Location = New System.Drawing.Point(2, 239)
        Me.lblPulseFrequency.Name = "lblPulseFrequency"
        Me.lblPulseFrequency.Size = New System.Drawing.Size(160, 19)
        Me.lblPulseFrequency.TabIndex = 14
        Me.lblPulseFrequency.Text = "Pulse Frequency (kHz)"
        Me.lblPulseFrequency.Visible = False
        '
        'txtPulseWidth
        '
        Me.txtPulseWidth.AccessibleName = "Preset"
        Me.txtPulseWidth.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPulseWidth.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPulseWidth.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPulseWidth.IsReadBack = True
        Me.txtPulseWidth.Location = New System.Drawing.Point(171, 267)
        Me.txtPulseWidth.Name = "txtPulseWidth"
        Me.txtPulseWidth.ReadOnly = True
        Me.txtPulseWidth.Size = New System.Drawing.Size(78, 24)
        Me.txtPulseWidth.TabIndex = 12
        Me.txtPulseWidth.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtPulseWidth.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPulseWidth.Visible = False
        '
        'txtPulseWidthRight
        '
        Me.txtPulseWidthRight.AccessibleDescription = "TextboxClick"
        Me.txtPulseWidthRight.AccessibleName = "Pulse Width"
        Me.txtPulseWidthRight.BackColor = System.Drawing.Color.White
        Me.txtPulseWidthRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPulseWidthRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPulseWidthRight.IsNumericTextbox = True
        Me.txtPulseWidthRight.IsReadBack = False
        Me.txtPulseWidthRight.Location = New System.Drawing.Point(250, 267)
        Me.txtPulseWidthRight.Name = "txtPulseWidthRight"
        Me.txtPulseWidthRight.ReadOnly = True
        Me.txtPulseWidthRight.Size = New System.Drawing.Size(70, 24)
        Me.txtPulseWidthRight.TabIndex = 9
        Me.txtPulseWidthRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtPulseWidthRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPulseWidthRight.Visible = False
        '
        'lblPulseWidth
        '
        Me.lblPulseWidth.AutoSize = True
        Me.lblPulseWidth.BackColor = System.Drawing.Color.Transparent
        Me.lblPulseWidth.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPulseWidth.Location = New System.Drawing.Point(2, 269)
        Me.lblPulseWidth.Name = "lblPulseWidth"
        Me.lblPulseWidth.Size = New System.Drawing.Size(118, 19)
        Me.lblPulseWidth.TabIndex = 14
        Me.lblPulseWidth.Text = "Pulse Width (ns)"
        Me.lblPulseWidth.Visible = False
        '
        'txtRampTime
        '
        Me.txtRampTime.AccessibleName = "Preset"
        Me.txtRampTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRampTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRampTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRampTime.IsReadBack = True
        Me.txtRampTime.Location = New System.Drawing.Point(171, 297)
        Me.txtRampTime.Name = "txtRampTime"
        Me.txtRampTime.ReadOnly = True
        Me.txtRampTime.Size = New System.Drawing.Size(78, 24)
        Me.txtRampTime.TabIndex = 12
        Me.txtRampTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtRampTime.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtRampTime.Visible = False
        '
        'txtRampTimeRight
        '
        Me.txtRampTimeRight.AccessibleDescription = "TextboxClick"
        Me.txtRampTimeRight.AccessibleName = "Ramp Time"
        Me.txtRampTimeRight.BackColor = System.Drawing.Color.White
        Me.txtRampTimeRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRampTimeRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRampTimeRight.IsNumericTextbox = True
        Me.txtRampTimeRight.IsReadBack = False
        Me.txtRampTimeRight.Location = New System.Drawing.Point(250, 297)
        Me.txtRampTimeRight.Name = "txtRampTimeRight"
        Me.txtRampTimeRight.ReadOnly = True
        Me.txtRampTimeRight.Size = New System.Drawing.Size(70, 24)
        Me.txtRampTimeRight.TabIndex = 9
        Me.txtRampTimeRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtRampTimeRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtRampTimeRight.Visible = False
        '
        'lblRampTime
        '
        Me.lblRampTime.AutoSize = True
        Me.lblRampTime.BackColor = System.Drawing.Color.Transparent
        Me.lblRampTime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRampTime.Location = New System.Drawing.Point(2, 299)
        Me.lblRampTime.Name = "lblRampTime"
        Me.lblRampTime.Size = New System.Drawing.Size(132, 19)
        Me.lblRampTime.TabIndex = 14
        Me.lblRampTime.Text = "Ramp Time (Secs)"
        Me.lblRampTime.Visible = False
        '
        'lblPulseMode
        '
        Me.lblPulseMode.AutoSize = True
        Me.lblPulseMode.BackColor = System.Drawing.Color.Transparent
        Me.lblPulseMode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPulseMode.Location = New System.Drawing.Point(2, 151)
        Me.lblPulseMode.Name = "lblPulseMode"
        Me.lblPulseMode.Size = New System.Drawing.Size(89, 19)
        Me.lblPulseMode.TabIndex = 14
        Me.lblPulseMode.Text = "Pulse Mode"
        Me.lblPulseMode.Visible = False
        '
        'btnPulse
        '
        Me.btnPulse.AccessibleDescription = "Pulse Mode"
        Me.btnPulse.AccessibleName = "PulseMode"
        Me.btnPulse.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPulse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPulse.Clickable = True
        Me.btnPulse.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnPulse.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPulse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPulse.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnPulse.FlatAppearance.BorderSize = 0
        Me.btnPulse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPulse.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnPulse.ForeColor = System.Drawing.Color.Black
        Me.btnPulse.Location = New System.Drawing.Point(250, 151)
        Me.btnPulse.MessageBoxText = Nothing
        Me.btnPulse.Name = "btnPulse"
        Me.btnPulse.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPulse.OffText = "Pulse"
        Me.btnPulse.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPulse.OnText = "Normal"
        Me.btnPulse.Size = New System.Drawing.Size(70, 24)
        Me.btnPulse.TabIndex = 16
        Me.btnPulse.Text = "Pulse"
        Me.btnPulse.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnPulse.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnPulse.UseChangeValueToSend_BaseOnStatus = True
        Me.btnPulse.UseVisualStyleBackColor = True
        Me.btnPulse.ValueToBeSend = "On"
        Me.btnPulse.Visible = False
        '
        'txtErrorMessage
        '
        Me.txtErrorMessage.AccessibleName = "Preset"
        Me.txtErrorMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtErrorMessage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtErrorMessage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtErrorMessage.IsReadBack = True
        Me.txtErrorMessage.Location = New System.Drawing.Point(164, 447)
        Me.txtErrorMessage.Name = "txtErrorMessage"
        Me.txtErrorMessage.ReadOnly = True
        Me.txtErrorMessage.Size = New System.Drawing.Size(17, 24)
        Me.txtErrorMessage.TabIndex = 12
        Me.txtErrorMessage.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtErrorMessage.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtErrorMessage.Visible = False
        '
        'btnContact
        '
        Me.btnContact.AccessibleDescription = "Bias Contact"
        Me.btnContact.AccessibleName = "Contact"
        Me.btnContact.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnContact.Clickable = True
        Me.btnContact.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnContact.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnContact.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContact.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnContact.FlatAppearance.BorderSize = 0
        Me.btnContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContact.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnContact.ForeColor = System.Drawing.Color.Black
        Me.btnContact.IsNotValve = True
        Me.btnContact.Location = New System.Drawing.Point(250, 151)
        Me.btnContact.MessageBoxText = Nothing
        Me.btnContact.Name = "btnContact"
        Me.btnContact.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnContact.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnContact.Size = New System.Drawing.Size(70, 24)
        Me.btnContact.TabIndex = 16
        Me.btnContact.Text = "Contact"
        Me.btnContact.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnContact.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnContact.UseChangeValueToSend_BaseOnStatus = True
        Me.btnContact.UseClickedEventInForm = True
        Me.btnContact.UseVisualStyleBackColor = True
        Me.btnContact.ValueToBeSend = "On"
        '
        'btnTarget4Switch
        '
        Me.btnTarget4Switch.AccessibleDescription = "Target4"
        Me.btnTarget4Switch.AccessibleName = "Target4Switch"
        Me.btnTarget4Switch.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTarget4Switch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTarget4Switch.Clickable = True
        Me.btnTarget4Switch.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTarget4Switch.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTarget4Switch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTarget4Switch.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTarget4Switch.FlatAppearance.BorderSize = 0
        Me.btnTarget4Switch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTarget4Switch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnTarget4Switch.ForeColor = System.Drawing.Color.Black
        Me.btnTarget4Switch.IsNotValve = True
        Me.btnTarget4Switch.Location = New System.Drawing.Point(1, 2)
        Me.btnTarget4Switch.MessageBoxText = Nothing
        Me.btnTarget4Switch.Name = "btnTarget4Switch"
        Me.btnTarget4Switch.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTarget4Switch.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTarget4Switch.Size = New System.Drawing.Size(76, 26)
        Me.btnTarget4Switch.TabIndex = 21
        Me.btnTarget4Switch.Text = "Target 4"
        Me.btnTarget4Switch.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnTarget4Switch.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTarget4Switch.UseVisualStyleBackColor = True
        Me.btnTarget4Switch.ValueToBeSend = "4"
        '
        'btnTarget3Switch
        '
        Me.btnTarget3Switch.AccessibleDescription = "Target3"
        Me.btnTarget3Switch.AccessibleName = "Target3Switch"
        Me.btnTarget3Switch.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTarget3Switch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTarget3Switch.Clickable = True
        Me.btnTarget3Switch.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTarget3Switch.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTarget3Switch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTarget3Switch.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTarget3Switch.FlatAppearance.BorderSize = 0
        Me.btnTarget3Switch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTarget3Switch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnTarget3Switch.ForeColor = System.Drawing.Color.Black
        Me.btnTarget3Switch.IsNotValve = True
        Me.btnTarget3Switch.Location = New System.Drawing.Point(1, 1)
        Me.btnTarget3Switch.MessageBoxText = Nothing
        Me.btnTarget3Switch.Name = "btnTarget3Switch"
        Me.btnTarget3Switch.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTarget3Switch.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTarget3Switch.Size = New System.Drawing.Size(76, 26)
        Me.btnTarget3Switch.TabIndex = 22
        Me.btnTarget3Switch.Text = "Target 3"
        Me.btnTarget3Switch.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnTarget3Switch.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTarget3Switch.UseVisualStyleBackColor = True
        Me.btnTarget3Switch.ValueToBeSend = "3"
        '
        'btnTarget2Switch
        '
        Me.btnTarget2Switch.AccessibleDescription = "Target2"
        Me.btnTarget2Switch.AccessibleName = "Target2Switch"
        Me.btnTarget2Switch.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTarget2Switch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTarget2Switch.Clickable = True
        Me.btnTarget2Switch.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTarget2Switch.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTarget2Switch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTarget2Switch.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTarget2Switch.FlatAppearance.BorderSize = 0
        Me.btnTarget2Switch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTarget2Switch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnTarget2Switch.ForeColor = System.Drawing.Color.Black
        Me.btnTarget2Switch.IsNotValve = True
        Me.btnTarget2Switch.Location = New System.Drawing.Point(1, 2)
        Me.btnTarget2Switch.MessageBoxText = Nothing
        Me.btnTarget2Switch.Name = "btnTarget2Switch"
        Me.btnTarget2Switch.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTarget2Switch.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTarget2Switch.Size = New System.Drawing.Size(76, 26)
        Me.btnTarget2Switch.TabIndex = 19
        Me.btnTarget2Switch.Text = "Target 2"
        Me.btnTarget2Switch.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnTarget2Switch.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTarget2Switch.UseVisualStyleBackColor = True
        Me.btnTarget2Switch.ValueToBeSend = "2"
        '
        'btnTarget1Switch
        '
        Me.btnTarget1Switch.AccessibleDescription = "Target1"
        Me.btnTarget1Switch.AccessibleName = "Target1Switch"
        Me.btnTarget1Switch.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTarget1Switch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTarget1Switch.Clickable = True
        Me.btnTarget1Switch.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTarget1Switch.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTarget1Switch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTarget1Switch.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTarget1Switch.FlatAppearance.BorderSize = 0
        Me.btnTarget1Switch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTarget1Switch.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnTarget1Switch.ForeColor = System.Drawing.Color.Black
        Me.btnTarget1Switch.IsNotValve = True
        Me.btnTarget1Switch.Location = New System.Drawing.Point(1, 2)
        Me.btnTarget1Switch.MessageBoxText = Nothing
        Me.btnTarget1Switch.Name = "btnTarget1Switch"
        Me.btnTarget1Switch.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTarget1Switch.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTarget1Switch.Size = New System.Drawing.Size(76, 26)
        Me.btnTarget1Switch.TabIndex = 20
        Me.btnTarget1Switch.Text = "Target 1"
        Me.btnTarget1Switch.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnTarget1Switch.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTarget1Switch.UseVisualStyleBackColor = True
        Me.btnTarget1Switch.ValueToBeSend = "1"
        '
        'txtVoltageRight
        '
        Me.txtVoltageRight.AccessibleDescription = "TextboxClick"
        Me.txtVoltageRight.AccessibleName = "Voltage"
        Me.txtVoltageRight.BackColor = System.Drawing.Color.White
        Me.txtVoltageRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtVoltageRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtVoltageRight.IsNumericTextbox = True
        Me.txtVoltageRight.IsReadBack = False
        Me.txtVoltageRight.Location = New System.Drawing.Point(250, 51)
        Me.txtVoltageRight.Name = "txtVoltageRight"
        Me.txtVoltageRight.ReadOnly = True
        Me.txtVoltageRight.Size = New System.Drawing.Size(70, 24)
        Me.txtVoltageRight.TabIndex = 9
        Me.txtVoltageRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtVoltageRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGrounded
        '
        Me.txtGrounded.AccessibleName = "Grounded"
        Me.txtGrounded.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrounded.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGrounded.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGrounded.IsReadBack = True
        Me.txtGrounded.Location = New System.Drawing.Point(171, 151)
        Me.txtGrounded.Name = "txtGrounded"
        Me.txtGrounded.ReadOnly = True
        Me.txtGrounded.Size = New System.Drawing.Size(78, 24)
        Me.txtGrounded.TabIndex = 23
        Me.txtGrounded.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtGrounded.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'pnTarget
        '
        Me.pnTarget.Controls.Add(Me.Panel4)
        Me.pnTarget.Controls.Add(Me.Panel2)
        Me.pnTarget.Controls.Add(Me.Panel3)
        Me.pnTarget.Controls.Add(Me.Panel1)
        Me.pnTarget.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnTarget.Location = New System.Drawing.Point(0, 27)
        Me.pnTarget.Name = "pnTarget"
        Me.pnTarget.Size = New System.Drawing.Size(325, 33)
        Me.pnTarget.TabIndex = 24
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnTarget4Switch)
        Me.Panel4.Location = New System.Drawing.Point(243, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(78, 30)
        Me.Panel4.TabIndex = 31
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnTarget2Switch)
        Me.Panel2.Location = New System.Drawing.Point(84, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(78, 30)
        Me.Panel2.TabIndex = 31
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnTarget3Switch)
        Me.Panel3.Location = New System.Drawing.Point(164, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(78, 30)
        Me.Panel3.TabIndex = 31
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnTarget1Switch)
        Me.Panel1.Location = New System.Drawing.Point(4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(78, 30)
        Me.Panel1.TabIndex = 30
        '
        'pnPower
        '
        Me.pnPower.Controls.Add(Me.txtMagnatron)
        Me.pnPower.Controls.Add(Me.btnMag4RotationStart)
        Me.pnPower.Controls.Add(Me.btnMag3RotationStart)
        Me.pnPower.Controls.Add(Me.btnMag2RotationStart)
        Me.pnPower.Controls.Add(Me.btnMag1RotationStart)
        Me.pnPower.Controls.Add(Me.lblMagnatron)
        Me.pnPower.Controls.Add(Me.lblArcCounter)
        Me.pnPower.Controls.Add(Me.txtArcCounter)
        Me.pnPower.Controls.Add(Me.txtPulseMode)
        Me.pnPower.Controls.Add(Me.lblChuckContactPosition)
        Me.pnPower.Controls.Add(Me.txtReflectedPower)
        Me.pnPower.Controls.Add(Me.lbErrorMes)
        Me.pnPower.Controls.Add(Me.txtKWH)
        Me.pnPower.Controls.Add(Me.txtErrorMessage)
        Me.pnPower.Controls.Add(Me.lblC2)
        Me.pnPower.Controls.Add(Me.lblRampTime)
        Me.pnPower.Controls.Add(Me.txtGrounded)
        Me.pnPower.Controls.Add(Me.lblPulseWidth)
        Me.pnPower.Controls.Add(Me.lblReflectedPower)
        Me.pnPower.Controls.Add(Me.lblForwardPower)
        Me.pnPower.Controls.Add(Me.lblPulseFrequency)
        Me.pnPower.Controls.Add(Me.txtVoltage)
        Me.pnPower.Controls.Add(Me.lblTargetCurrent)
        Me.pnPower.Controls.Add(Me.txtC1)
        Me.pnPower.Controls.Add(Me.txtRampTimeRight)
        Me.pnPower.Controls.Add(Me.btnContact)
        Me.pnPower.Controls.Add(Me.txtPulseWidthRight)
        Me.pnPower.Controls.Add(Me.txtC2)
        Me.pnPower.Controls.Add(Me.txtPulseFrequencyRight)
        Me.pnPower.Controls.Add(Me.btnAuto)
        Me.pnPower.Controls.Add(Me.txtDCForwardPowerRight)
        Me.pnPower.Controls.Add(Me.txtMatch)
        Me.pnPower.Controls.Add(Me.txtRampTime)
        Me.pnPower.Controls.Add(Me.lblPulseMode)
        Me.pnPower.Controls.Add(Me.txtPulseWidth)
        Me.pnPower.Controls.Add(Me.lblVoltage)
        Me.pnPower.Controls.Add(Me.txtPulseFrequency)
        Me.pnPower.Controls.Add(Me.txtTargetCurrent)
        Me.pnPower.Controls.Add(Me.txtC2Right)
        Me.pnPower.Controls.Add(Me.txtC1Right)
        Me.pnPower.Controls.Add(Me.txtVoltageRight)
        Me.pnPower.Controls.Add(Me.lblMatch)
        Me.pnPower.Controls.Add(Me.txtForwardPowerRight)
        Me.pnPower.Controls.Add(Me.lblC1)
        Me.pnPower.Controls.Add(Me.btnPulse)
        Me.pnPower.Controls.Add(Me.txtForwardPower)
        Me.pnPower.Controls.Add(Me.txtDCForwardPower)
        Me.pnPower.Controls.Add(Me.txtDCVoltage)
        Me.pnPower.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnPower.Location = New System.Drawing.Point(0, 60)
        Me.pnPower.Name = "pnPower"
        Me.pnPower.Size = New System.Drawing.Size(325, 237)
        Me.pnPower.TabIndex = 25
        '
        'txtMagnatron
        '
        Me.txtMagnatron.AccessibleName = "Magnatron"
        Me.txtMagnatron.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMagnatron.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMagnatron.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMagnatron.IsReadBack = True
        Me.txtMagnatron.Location = New System.Drawing.Point(171, 327)
        Me.txtMagnatron.Name = "txtMagnatron"
        Me.txtMagnatron.ReadOnly = True
        Me.txtMagnatron.Size = New System.Drawing.Size(78, 24)
        Me.txtMagnatron.TabIndex = 65
        Me.txtMagnatron.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtMagnatron.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtMagnatron.Visible = False
        '
        'btnMag4RotationStart
        '
        Me.btnMag4RotationStart.AccessibleDescription = "Magnatron 4"
        Me.btnMag4RotationStart.AccessibleName = "Magnatron4"
        Me.btnMag4RotationStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag4RotationStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMag4RotationStart.Clickable = True
        Me.btnMag4RotationStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnMag4RotationStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMag4RotationStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMag4RotationStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMag4RotationStart.FlatAppearance.BorderSize = 0
        Me.btnMag4RotationStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMag4RotationStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMag4RotationStart.ForeColor = System.Drawing.Color.Black
        Me.btnMag4RotationStart.IsNotValve = True
        Me.btnMag4RotationStart.Location = New System.Drawing.Point(250, 387)
        Me.btnMag4RotationStart.MessageBoxText = Nothing
        Me.btnMag4RotationStart.Name = "btnMag4RotationStart"
        Me.btnMag4RotationStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag4RotationStart.OffText = "On/Off"
        Me.btnMag4RotationStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMag4RotationStart.OnText = "On/Off"
        Me.btnMag4RotationStart.Size = New System.Drawing.Size(70, 24)
        Me.btnMag4RotationStart.TabIndex = 64
        Me.btnMag4RotationStart.Text = "On/Off"
        Me.btnMag4RotationStart.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMag4RotationStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMag4RotationStart.UseChangeValueToSend_BaseOnStatus = True
        Me.btnMag4RotationStart.UseVisualStyleBackColor = True
        Me.btnMag4RotationStart.ValueToBeSend = "On"
        Me.btnMag4RotationStart.Visible = False
        '
        'btnMag3RotationStart
        '
        Me.btnMag3RotationStart.AccessibleDescription = "Magnatron 3"
        Me.btnMag3RotationStart.AccessibleName = "Magnatron3"
        Me.btnMag3RotationStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag3RotationStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMag3RotationStart.Clickable = True
        Me.btnMag3RotationStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnMag3RotationStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMag3RotationStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMag3RotationStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMag3RotationStart.FlatAppearance.BorderSize = 0
        Me.btnMag3RotationStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMag3RotationStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMag3RotationStart.ForeColor = System.Drawing.Color.Black
        Me.btnMag3RotationStart.IsNotValve = True
        Me.btnMag3RotationStart.Location = New System.Drawing.Point(250, 357)
        Me.btnMag3RotationStart.MessageBoxText = Nothing
        Me.btnMag3RotationStart.Name = "btnMag3RotationStart"
        Me.btnMag3RotationStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag3RotationStart.OffText = "On/Off"
        Me.btnMag3RotationStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMag3RotationStart.OnText = "On/Off"
        Me.btnMag3RotationStart.Size = New System.Drawing.Size(70, 24)
        Me.btnMag3RotationStart.TabIndex = 63
        Me.btnMag3RotationStart.Text = "On/Off"
        Me.btnMag3RotationStart.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMag3RotationStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMag3RotationStart.UseChangeValueToSend_BaseOnStatus = True
        Me.btnMag3RotationStart.UseVisualStyleBackColor = True
        Me.btnMag3RotationStart.ValueToBeSend = "On"
        Me.btnMag3RotationStart.Visible = False
        '
        'btnMag2RotationStart
        '
        Me.btnMag2RotationStart.AccessibleDescription = "Magnatron 2"
        Me.btnMag2RotationStart.AccessibleName = "Magnatron2"
        Me.btnMag2RotationStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag2RotationStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMag2RotationStart.Clickable = True
        Me.btnMag2RotationStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnMag2RotationStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMag2RotationStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMag2RotationStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMag2RotationStart.FlatAppearance.BorderSize = 0
        Me.btnMag2RotationStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMag2RotationStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMag2RotationStart.ForeColor = System.Drawing.Color.Black
        Me.btnMag2RotationStart.IsNotValve = True
        Me.btnMag2RotationStart.Location = New System.Drawing.Point(250, 417)
        Me.btnMag2RotationStart.MessageBoxText = Nothing
        Me.btnMag2RotationStart.Name = "btnMag2RotationStart"
        Me.btnMag2RotationStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag2RotationStart.OffText = "On/Off"
        Me.btnMag2RotationStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMag2RotationStart.OnText = "On/Off"
        Me.btnMag2RotationStart.Size = New System.Drawing.Size(70, 24)
        Me.btnMag2RotationStart.TabIndex = 62
        Me.btnMag2RotationStart.Text = "On/Off"
        Me.btnMag2RotationStart.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMag2RotationStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMag2RotationStart.UseChangeValueToSend_BaseOnStatus = True
        Me.btnMag2RotationStart.UseVisualStyleBackColor = True
        Me.btnMag2RotationStart.ValueToBeSend = "On"
        Me.btnMag2RotationStart.Visible = False
        '
        'btnMag1RotationStart
        '
        Me.btnMag1RotationStart.AccessibleDescription = "Magnatron 1"
        Me.btnMag1RotationStart.AccessibleName = "Magnatron1"
        Me.btnMag1RotationStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag1RotationStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMag1RotationStart.Clickable = True
        Me.btnMag1RotationStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnMag1RotationStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMag1RotationStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMag1RotationStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMag1RotationStart.FlatAppearance.BorderSize = 0
        Me.btnMag1RotationStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMag1RotationStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMag1RotationStart.ForeColor = System.Drawing.Color.Black
        Me.btnMag1RotationStart.IsNotValve = True
        Me.btnMag1RotationStart.Location = New System.Drawing.Point(250, 327)
        Me.btnMag1RotationStart.MessageBoxText = Nothing
        Me.btnMag1RotationStart.Name = "btnMag1RotationStart"
        Me.btnMag1RotationStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag1RotationStart.OffText = "On/Off"
        Me.btnMag1RotationStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMag1RotationStart.OnText = "On/Off"
        Me.btnMag1RotationStart.Size = New System.Drawing.Size(70, 24)
        Me.btnMag1RotationStart.TabIndex = 61
        Me.btnMag1RotationStart.Text = "On/Off"
        Me.btnMag1RotationStart.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMag1RotationStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMag1RotationStart.UseChangeValueToSend_BaseOnStatus = True
        Me.btnMag1RotationStart.UseVisualStyleBackColor = True
        Me.btnMag1RotationStart.ValueToBeSend = "On"
        Me.btnMag1RotationStart.Visible = False
        '
        'lblMagnatron
        '
        Me.lblMagnatron.AutoSize = True
        Me.lblMagnatron.BackColor = System.Drawing.Color.Transparent
        Me.lblMagnatron.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMagnatron.Location = New System.Drawing.Point(1, 329)
        Me.lblMagnatron.Name = "lblMagnatron"
        Me.lblMagnatron.Size = New System.Drawing.Size(84, 19)
        Me.lblMagnatron.TabIndex = 30
        Me.lblMagnatron.Text = "Magnetron"
        Me.lblMagnatron.Visible = False
        '
        'lblArcCounter
        '
        Me.lblArcCounter.AutoSize = True
        Me.lblArcCounter.BackColor = System.Drawing.Color.Transparent
        Me.lblArcCounter.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArcCounter.Location = New System.Drawing.Point(2, 179)
        Me.lblArcCounter.Name = "lblArcCounter"
        Me.lblArcCounter.Size = New System.Drawing.Size(91, 19)
        Me.lblArcCounter.TabIndex = 29
        Me.lblArcCounter.Text = "Arc Counter"
        Me.lblArcCounter.Visible = False
        '
        'txtArcCounter
        '
        Me.txtArcCounter.AccessibleName = "ArcCounter"
        Me.txtArcCounter.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtArcCounter.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtArcCounter.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtArcCounter.IsReadBack = True
        Me.txtArcCounter.Location = New System.Drawing.Point(171, 176)
        Me.txtArcCounter.Name = "txtArcCounter"
        Me.txtArcCounter.ReadOnly = True
        Me.txtArcCounter.Size = New System.Drawing.Size(78, 24)
        Me.txtArcCounter.TabIndex = 28
        Me.txtArcCounter.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtArcCounter.UseScientificFormat = True
        Me.txtArcCounter.Visible = False
        '
        'txtPulseMode
        '
        Me.txtPulseMode.AccessibleName = "PulseMode"
        Me.txtPulseMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPulseMode.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPulseMode.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPulseMode.IsReadBack = True
        Me.txtPulseMode.Location = New System.Drawing.Point(171, 151)
        Me.txtPulseMode.Name = "txtPulseMode"
        Me.txtPulseMode.ReadOnly = True
        Me.txtPulseMode.Size = New System.Drawing.Size(78, 24)
        Me.txtPulseMode.TabIndex = 27
        Me.txtPulseMode.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtPulseMode.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPulseMode.Visible = False
        '
        'lblChuckContactPosition
        '
        Me.lblChuckContactPosition.AutoSize = True
        Me.lblChuckContactPosition.BackColor = System.Drawing.Color.Transparent
        Me.lblChuckContactPosition.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChuckContactPosition.Location = New System.Drawing.Point(2, 151)
        Me.lblChuckContactPosition.Name = "lblChuckContactPosition"
        Me.lblChuckContactPosition.Size = New System.Drawing.Size(165, 19)
        Me.lblChuckContactPosition.TabIndex = 24
        Me.lblChuckContactPosition.Text = "Chuck Contact Position"
        '
        'txtDCForwardPower
        '
        Me.txtDCForwardPower.AccessibleName = "Forward Power"
        Me.txtDCForwardPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDCForwardPower.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtDCForwardPower.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtDCForwardPower.IsReadBack = True
        Me.txtDCForwardPower.Location = New System.Drawing.Point(171, 1)
        Me.txtDCForwardPower.Name = "txtDCForwardPower"
        Me.txtDCForwardPower.ReadOnly = True
        Me.txtDCForwardPower.Size = New System.Drawing.Size(78, 24)
        Me.txtDCForwardPower.TabIndex = 25
        Me.txtDCForwardPower.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtDCForwardPower.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtDCForwardPower.Visible = False
        '
        'txtDCVoltage
        '
        Me.txtDCVoltage.AccessibleName = "Voltage"
        Me.txtDCVoltage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDCVoltage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtDCVoltage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtDCVoltage.IsReadBack = True
        Me.txtDCVoltage.Location = New System.Drawing.Point(171, 51)
        Me.txtDCVoltage.Name = "txtDCVoltage"
        Me.txtDCVoltage.ReadOnly = True
        Me.txtDCVoltage.Size = New System.Drawing.Size(78, 24)
        Me.txtDCVoltage.TabIndex = 26
        Me.txtDCVoltage.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtDCVoltage.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtDCVoltage.Visible = False
        '
        'CORONA_BiasPowerSupply
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.pnPower)
        Me.Controls.Add(Me.pnTarget)
        Me.DoubleBuffered = True
        Me.Name = "CORONA_BiasPowerSupply"
        Me.Size = New System.Drawing.Size(325, 301)
        Me.Text = "Bias Power Supply"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.pnTarget, 0)
        Me.Controls.SetChildIndex(Me.pnPower, 0)
        Me.pnTarget.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnPower.ResumeLayout(False)
        Me.pnPower.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblForwardPower As System.Windows.Forms.Label
    Friend WithEvents txtForwardPower As SL_Textbox
    Friend WithEvents lblReflectedPower As System.Windows.Forms.Label
    Friend WithEvents txtReflectedPower As SL_Textbox
    Friend WithEvents txtVoltage As SL_Textbox
    Friend WithEvents lblVoltage As System.Windows.Forms.Label
    Friend WithEvents lblC1 As System.Windows.Forms.Label
    Friend WithEvents lblC2 As System.Windows.Forms.Label
    Friend WithEvents txtC2 As SL_Textbox
    Friend WithEvents lblMatch As System.Windows.Forms.Label
    Friend WithEvents txtC1 As SL_Textbox
    Friend WithEvents txtMatch As SL_Textbox
    Friend WithEvents txtKWH As SL_Textbox
    Friend WithEvents txtForwardPowerRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtC1Right As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtC2Right As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnAuto As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtTargetCurrent As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblTargetCurrent As System.Windows.Forms.Label
    Friend WithEvents txtDCForwardPowerRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lbErrorMes As System.Windows.Forms.Label
    Friend WithEvents txtPulseFrequency As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPulseFrequencyRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblPulseFrequency As System.Windows.Forms.Label
    Friend WithEvents txtPulseWidth As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPulseWidthRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblPulseWidth As System.Windows.Forms.Label
    Friend WithEvents txtRampTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRampTimeRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblRampTime As System.Windows.Forms.Label
    Friend WithEvents lblPulseMode As System.Windows.Forms.Label
    Friend WithEvents btnPulse As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtErrorMessage As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnContact As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTarget4Switch As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTarget3Switch As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTarget2Switch As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTarget1Switch As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtVoltageRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGrounded As AVP_Robot_Project.SL_Textbox
    Friend WithEvents pnTarget As System.Windows.Forms.Panel
    Friend WithEvents pnPower As System.Windows.Forms.Panel
    Friend WithEvents lblChuckContactPosition As System.Windows.Forms.Label
    Friend WithEvents txtDCForwardPower As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtDCVoltage As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPulseMode As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblArcCounter As System.Windows.Forms.Label
    Friend WithEvents txtArcCounter As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblMagnatron As System.Windows.Forms.Label
    Friend WithEvents btnMag1RotationStart As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnMag2RotationStart As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnMag3RotationStart As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnMag4RotationStart As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtMagnatron As AVP_Robot_Project.SL_Textbox

End Class