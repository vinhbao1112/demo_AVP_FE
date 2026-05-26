<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TargetPowerSupply
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTargetPower = New AVP_Robot_Project.SL_Textbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTargetVoltage = New AVP_Robot_Project.SL_Textbox
        Me.txtTargetCurrent = New AVP_Robot_Project.SL_Textbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTargetCurrentRight = New System.Windows.Forms.TextBox
        Me.lblDCPulse = New System.Windows.Forms.Label
        Me.txtTargetDCPulse = New AVP_Robot_Project.SL_Textbox
        Me.txtTargetVoltageRight = New System.Windows.Forms.TextBox
        Me.txtTargetPowerRight = New AVP_Robot_Project.PVDTextbox
        Me.bicDCPulse = New AVP_Robot_Project.ButtonIGCGControl
        Me.txtKWH = New AVP_Robot_Project.SL_Textbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRampTime = New AVP_Robot_Project.SL_Textbox
        Me.txtRampTimeRight = New System.Windows.Forms.TextBox
        Me.lblMagnatron = New System.Windows.Forms.Label
        Me.txtMagnatronStatus = New AVP_Robot_Project.SL_Textbox
        Me.btnRotationStart = New AVP_Robot_Project.ButtonIGCGControl
        Me.bicRotating = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Power (Watts)"
        '
        'txtTargetPower
        '
        Me.txtTargetPower.AccessibleName = "Power"
        Me.txtTargetPower.AutoSendKeyTabWhenFinishInput = False
        Me.txtTargetPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetPower.Clickable = True
        Me.txtTargetPower.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetPower.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetPower.GasName = ""
        Me.txtTargetPower.GetDefaultMinMax = False
        Me.txtTargetPower.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtTargetPower.IsIntergerNumber = False
        Me.txtTargetPower.IsNumericTextbox = False
        Me.txtTargetPower.IsReadBack = True
        Me.txtTargetPower.IsTurboPumpTextbox = False
        Me.txtTargetPower.Location = New System.Drawing.Point(172, 34)
        Me.txtTargetPower.LogSource = ""
        Me.txtTargetPower.Name = "txtTargetPower"
        Me.txtTargetPower.PermissionCode = ""
        Me.txtTargetPower.ReadOnly = True
        Me.txtTargetPower.ShowUnitFormat = False
        Me.txtTargetPower.Size = New System.Drawing.Size(70, 24)
        Me.txtTargetPower.SourceOfMessageBox = ""
        Me.txtTargetPower.TabIndex = 9
        Me.txtTargetPower.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTargetPower.UnitTypeUsed = ""
        Me.txtTargetPower.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtTargetPower.UseClickEventInForm = False
        Me.txtTargetPower.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtTargetPower.UseScientificFormat = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 19)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Voltage (Volts)"
        '
        'txtTargetVoltage
        '
        Me.txtTargetVoltage.AccessibleName = "Voltage"
        Me.txtTargetVoltage.AutoSendKeyTabWhenFinishInput = False
        Me.txtTargetVoltage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetVoltage.Clickable = True
        Me.txtTargetVoltage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetVoltage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetVoltage.GasName = ""
        Me.txtTargetVoltage.GetDefaultMinMax = False
        Me.txtTargetVoltage.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtTargetVoltage.IsIntergerNumber = False
        Me.txtTargetVoltage.IsNumericTextbox = False
        Me.txtTargetVoltage.IsReadBack = True
        Me.txtTargetVoltage.IsTurboPumpTextbox = False
        Me.txtTargetVoltage.Location = New System.Drawing.Point(172, 60)
        Me.txtTargetVoltage.LogSource = ""
        Me.txtTargetVoltage.Name = "txtTargetVoltage"
        Me.txtTargetVoltage.PermissionCode = ""
        Me.txtTargetVoltage.ReadOnly = True
        Me.txtTargetVoltage.ShowUnitFormat = False
        Me.txtTargetVoltage.Size = New System.Drawing.Size(70, 24)
        Me.txtTargetVoltage.SourceOfMessageBox = ""
        Me.txtTargetVoltage.TabIndex = 12
        Me.txtTargetVoltage.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTargetVoltage.UnitTypeUsed = ""
        Me.txtTargetVoltage.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtTargetVoltage.UseClickEventInForm = False
        Me.txtTargetVoltage.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtTargetVoltage.UseScientificFormat = True
        '
        'txtTargetCurrent
        '
        Me.txtTargetCurrent.AccessibleName = "Current"
        Me.txtTargetCurrent.AutoSendKeyTabWhenFinishInput = False
        Me.txtTargetCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetCurrent.Clickable = True
        Me.txtTargetCurrent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetCurrent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetCurrent.GasName = ""
        Me.txtTargetCurrent.GetDefaultMinMax = False
        Me.txtTargetCurrent.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtTargetCurrent.IsIntergerNumber = False
        Me.txtTargetCurrent.IsNumericTextbox = False
        Me.txtTargetCurrent.IsReadBack = True
        Me.txtTargetCurrent.IsTurboPumpTextbox = False
        Me.txtTargetCurrent.Location = New System.Drawing.Point(172, 86)
        Me.txtTargetCurrent.LogSource = ""
        Me.txtTargetCurrent.Name = "txtTargetCurrent"
        Me.txtTargetCurrent.PermissionCode = ""
        Me.txtTargetCurrent.ReadOnly = True
        Me.txtTargetCurrent.ShowUnitFormat = False
        Me.txtTargetCurrent.Size = New System.Drawing.Size(70, 24)
        Me.txtTargetCurrent.SourceOfMessageBox = ""
        Me.txtTargetCurrent.TabIndex = 12
        Me.txtTargetCurrent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTargetCurrent.UnitTypeUsed = ""
        Me.txtTargetCurrent.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtTargetCurrent.UseClickEventInForm = False
        Me.txtTargetCurrent.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtTargetCurrent.UseScientificFormat = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 19)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Current (Amps)"
        '
        'txtTargetCurrentRight
        '
        Me.txtTargetCurrentRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtTargetCurrentRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTargetCurrentRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetCurrentRight.Location = New System.Drawing.Point(244, 86)
        Me.txtTargetCurrentRight.Name = "txtTargetCurrentRight"
        Me.txtTargetCurrentRight.ReadOnly = True
        Me.txtTargetCurrentRight.Size = New System.Drawing.Size(70, 24)
        Me.txtTargetCurrentRight.TabIndex = 13
        Me.txtTargetCurrentRight.Visible = False
        '
        'lblDCPulse
        '
        Me.lblDCPulse.AutoSize = True
        Me.lblDCPulse.BackColor = System.Drawing.Color.Transparent
        Me.lblDCPulse.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDCPulse.Location = New System.Drawing.Point(5, 167)
        Me.lblDCPulse.Name = "lblDCPulse"
        Me.lblDCPulse.Size = New System.Drawing.Size(72, 19)
        Me.lblDCPulse.TabIndex = 14
        Me.lblDCPulse.Text = "DC Pulse"
        '
        'txtTargetDCPulse
        '
        Me.txtTargetDCPulse.AccessibleName = "DC Pulse"
        Me.txtTargetDCPulse.AutoSendKeyTabWhenFinishInput = False
        Me.txtTargetDCPulse.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetDCPulse.Clickable = True
        Me.txtTargetDCPulse.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetDCPulse.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetDCPulse.GasName = ""
        Me.txtTargetDCPulse.GetDefaultMinMax = False
        Me.txtTargetDCPulse.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtTargetDCPulse.IsIntergerNumber = False
        Me.txtTargetDCPulse.IsNumericTextbox = False
        Me.txtTargetDCPulse.IsReadBack = True
        Me.txtTargetDCPulse.IsTurboPumpTextbox = False
        Me.txtTargetDCPulse.Location = New System.Drawing.Point(172, 164)
        Me.txtTargetDCPulse.LogSource = ""
        Me.txtTargetDCPulse.Name = "txtTargetDCPulse"
        Me.txtTargetDCPulse.PermissionCode = ""
        Me.txtTargetDCPulse.ReadOnly = True
        Me.txtTargetDCPulse.ShowUnitFormat = False
        Me.txtTargetDCPulse.Size = New System.Drawing.Size(70, 24)
        Me.txtTargetDCPulse.SourceOfMessageBox = ""
        Me.txtTargetDCPulse.TabIndex = 12
        Me.txtTargetDCPulse.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTargetDCPulse.UnitTypeUsed = ""
        Me.txtTargetDCPulse.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtTargetDCPulse.UseClickEventInForm = False
        Me.txtTargetDCPulse.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtTargetDCPulse.UseScientificFormat = True
        '
        'txtTargetVoltageRight
        '
        Me.txtTargetVoltageRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtTargetVoltageRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTargetVoltageRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetVoltageRight.Location = New System.Drawing.Point(244, 60)
        Me.txtTargetVoltageRight.Name = "txtTargetVoltageRight"
        Me.txtTargetVoltageRight.ReadOnly = True
        Me.txtTargetVoltageRight.Size = New System.Drawing.Size(70, 24)
        Me.txtTargetVoltageRight.TabIndex = 13
        Me.txtTargetVoltageRight.Visible = False
        '
        'txtTargetPowerRight
        '
        Me.txtTargetPowerRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtTargetPowerRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTargetPowerRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetPowerRight.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtTargetPowerRight.Location = New System.Drawing.Point(244, 34)
        Me.txtTargetPowerRight.Name = "txtTargetPowerRight"
        Me.txtTargetPowerRight.ReadOnly = True
        Me.txtTargetPowerRight.Size = New System.Drawing.Size(70, 24)
        Me.txtTargetPowerRight.TabIndex = 13
        Me.txtTargetPowerRight.UseBackGroundWorkerToUpdateMinMax = True
        '
        'bicDCPulse
        '
        Me.bicDCPulse.BackColor = System.Drawing.Color.Transparent
        Me.bicDCPulse.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.bicDCPulse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicDCPulse.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicDCPulse.ColorText_OffStatus = System.Drawing.Color.Black
        Me.bicDCPulse.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicDCPulse.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicDCPulse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicDCPulse.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.bicDCPulse.ErrorText = ""
        Me.bicDCPulse.FlatAppearance.BorderSize = 0
        Me.bicDCPulse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicDCPulse.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicDCPulse.ForeColor = System.Drawing.Color.Black
        Me.bicDCPulse.Location = New System.Drawing.Point(244, 164)
        Me.bicDCPulse.Name = "bicDCPulse"
        Me.bicDCPulse.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.bicDCPulse.OffText = "Pulse"
        Me.bicDCPulse.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_On
        Me.bicDCPulse.OnText = "Normal"
        Me.bicDCPulse.Size = New System.Drawing.Size(74, 24)
        Me.bicDCPulse.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicDCPulse.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.bicDCPulse.TabIndex = 15
        Me.bicDCPulse.Text = "Pulse"
        Me.bicDCPulse.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Horizontal_Button_Red
        Me.bicDCPulse.UnKnownText = ""
        Me.bicDCPulse.UseVisualStyleBackColor = False
        '
        'txtKWH
        '
        Me.txtKWH.AccessibleName = "DC Pulse"
        Me.txtKWH.AutoSendKeyTabWhenFinishInput = False
        Me.txtKWH.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtKWH.Clickable = True
        Me.txtKWH.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtKWH.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtKWH.GasName = ""
        Me.txtKWH.GetDefaultMinMax = False
        Me.txtKWH.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtKWH.IsIntergerNumber = False
        Me.txtKWH.IsNumericTextbox = False
        Me.txtKWH.IsReadBack = True
        Me.txtKWH.IsTurboPumpTextbox = False
        Me.txtKWH.Location = New System.Drawing.Point(172, 190)
        Me.txtKWH.LogSource = ""
        Me.txtKWH.Name = "txtKWH"
        Me.txtKWH.PermissionCode = ""
        Me.txtKWH.ReadOnly = True
        Me.txtKWH.ShowUnitFormat = False
        Me.txtKWH.Size = New System.Drawing.Size(70, 24)
        Me.txtKWH.SourceOfMessageBox = ""
        Me.txtKWH.TabIndex = 12
        Me.txtKWH.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtKWH.UnitTypeUsed = ""
        Me.txtKWH.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtKWH.UseClickEventInForm = False
        Me.txtKWH.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtKWH.UseScientificFormat = True
        Me.txtKWH.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 19)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Ramp Time (Secs)"
        '
        'txtRampTime
        '
        Me.txtRampTime.AccessibleName = "Current"
        Me.txtRampTime.AutoSendKeyTabWhenFinishInput = False
        Me.txtRampTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRampTime.Clickable = True
        Me.txtRampTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRampTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRampTime.GasName = ""
        Me.txtRampTime.GetDefaultMinMax = False
        Me.txtRampTime.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtRampTime.IsIntergerNumber = False
        Me.txtRampTime.IsNumericTextbox = False
        Me.txtRampTime.IsReadBack = True
        Me.txtRampTime.IsTurboPumpTextbox = False
        Me.txtRampTime.Location = New System.Drawing.Point(172, 112)
        Me.txtRampTime.LogSource = ""
        Me.txtRampTime.Name = "txtRampTime"
        Me.txtRampTime.PermissionCode = ""
        Me.txtRampTime.ReadOnly = True
        Me.txtRampTime.ShowUnitFormat = False
        Me.txtRampTime.Size = New System.Drawing.Size(70, 24)
        Me.txtRampTime.SourceOfMessageBox = ""
        Me.txtRampTime.TabIndex = 12
        Me.txtRampTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRampTime.UnitTypeUsed = ""
        Me.txtRampTime.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtRampTime.UseClickEventInForm = False
        Me.txtRampTime.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtRampTime.UseScientificFormat = True
        '
        'txtRampTimeRight
        '
        Me.txtRampTimeRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtRampTimeRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRampTimeRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRampTimeRight.Location = New System.Drawing.Point(244, 112)
        Me.txtRampTimeRight.Name = "txtRampTimeRight"
        Me.txtRampTimeRight.ReadOnly = True
        Me.txtRampTimeRight.Size = New System.Drawing.Size(70, 24)
        Me.txtRampTimeRight.TabIndex = 13
        '
        'lblMagnatron
        '
        Me.lblMagnatron.AutoSize = True
        Me.lblMagnatron.BackColor = System.Drawing.Color.Transparent
        Me.lblMagnatron.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMagnatron.Location = New System.Drawing.Point(5, 141)
        Me.lblMagnatron.Name = "lblMagnatron"
        Me.lblMagnatron.Size = New System.Drawing.Size(84, 19)
        Me.lblMagnatron.TabIndex = 21
        Me.lblMagnatron.Text = "Magnetron"
        '
        'txtMagnatronStatus
        '
        Me.txtMagnatronStatus.AccessibleName = "Current"
        Me.txtMagnatronStatus.AutoSendKeyTabWhenFinishInput = False
        Me.txtMagnatronStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMagnatronStatus.Clickable = True
        Me.txtMagnatronStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMagnatronStatus.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMagnatronStatus.GasName = ""
        Me.txtMagnatronStatus.GetDefaultMinMax = False
        Me.txtMagnatronStatus.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtMagnatronStatus.IsIntergerNumber = False
        Me.txtMagnatronStatus.IsNumericTextbox = False
        Me.txtMagnatronStatus.IsReadBack = True
        Me.txtMagnatronStatus.IsTurboPumpTextbox = False
        Me.txtMagnatronStatus.Location = New System.Drawing.Point(172, 138)
        Me.txtMagnatronStatus.LogSource = ""
        Me.txtMagnatronStatus.Name = "txtMagnatronStatus"
        Me.txtMagnatronStatus.PermissionCode = ""
        Me.txtMagnatronStatus.ReadOnly = True
        Me.txtMagnatronStatus.ShowUnitFormat = False
        Me.txtMagnatronStatus.Size = New System.Drawing.Size(70, 24)
        Me.txtMagnatronStatus.SourceOfMessageBox = ""
        Me.txtMagnatronStatus.TabIndex = 22
        Me.txtMagnatronStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMagnatronStatus.UnitTypeUsed = ""
        Me.txtMagnatronStatus.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtMagnatronStatus.UseClickEventInForm = False
        Me.txtMagnatronStatus.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtMagnatronStatus.UseScientificFormat = True
        '
        'btnRotationStart
        '
        Me.btnRotationStart.BackColor = System.Drawing.Color.Transparent
        Me.btnRotationStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnRotationStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRotationStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRotationStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRotationStart.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnRotationStart.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnRotationStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRotationStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnRotationStart.ErrorText = ""
        Me.btnRotationStart.FlatAppearance.BorderSize = 0
        Me.btnRotationStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRotationStart.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRotationStart.ForeColor = System.Drawing.Color.Black
        Me.btnRotationStart.Location = New System.Drawing.Point(244, 138)
        Me.btnRotationStart.Name = "btnRotationStart"
        Me.btnRotationStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnRotationStart.OffText = "On/Off"
        Me.btnRotationStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_On
        Me.btnRotationStart.OnText = "On/Off"
        Me.btnRotationStart.Size = New System.Drawing.Size(70, 24)
        Me.btnRotationStart.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnRotationStart.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.btnRotationStart.TabIndex = 23
        Me.btnRotationStart.Text = "On/Off"
        Me.btnRotationStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnRotationStart.UnKnownText = ""
        Me.btnRotationStart.UseVisualStyleBackColor = False
        '
        'bicRotating
        '
        Me.bicRotating.BackColor = System.Drawing.Color.Transparent
        Me.bicRotating.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicRotating.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicRotating.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicRotating.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicRotating.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicRotating.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicRotating.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicRotating.ErrorText = ""
        Me.bicRotating.FlatAppearance.BorderSize = 0
        Me.bicRotating.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicRotating.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicRotating.ForeColor = System.Drawing.Color.White
        Me.bicRotating.Location = New System.Drawing.Point(139, 142)
        Me.bicRotating.Name = "bicRotating"
        Me.bicRotating.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicRotating.OffText = ""
        Me.bicRotating.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicRotating.OnText = ""
        Me.bicRotating.Size = New System.Drawing.Size(20, 20)
        Me.bicRotating.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicRotating.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.bicRotating.TabIndex = 24
        Me.bicRotating.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicRotating.UnKnownText = ""
        Me.bicRotating.UseVisualStyleBackColor = False
        Me.bicRotating.Visible = False
        '
        'TargetPowerSupply
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.bicRotating)
        Me.Controls.Add(Me.btnRotationStart)
        Me.Controls.Add(Me.txtMagnatronStatus)
        Me.Controls.Add(Me.lblMagnatron)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bicDCPulse)
        Me.Controls.Add(Me.lblDCPulse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTargetPower)
        Me.Controls.Add(Me.txtTargetPowerRight)
        Me.Controls.Add(Me.txtTargetVoltageRight)
        Me.Controls.Add(Me.txtRampTimeRight)
        Me.Controls.Add(Me.txtTargetCurrentRight)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtKWH)
        Me.Controls.Add(Me.txtRampTime)
        Me.Controls.Add(Me.txtTargetDCPulse)
        Me.Controls.Add(Me.txtTargetCurrent)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTargetVoltage)
        Me.DoubleBuffered = True
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "TargetPowerSupply"
        Me.Size = New System.Drawing.Size(325, 215)
        Me.Text = "Target Power Supply"
        Me.Controls.SetChildIndex(Me.txtTargetVoltage, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtTargetCurrent, 0)
        Me.Controls.SetChildIndex(Me.txtTargetDCPulse, 0)
        Me.Controls.SetChildIndex(Me.txtRampTime, 0)
        Me.Controls.SetChildIndex(Me.txtKWH, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtTargetCurrentRight, 0)
        Me.Controls.SetChildIndex(Me.txtRampTimeRight, 0)
        Me.Controls.SetChildIndex(Me.txtTargetVoltageRight, 0)
        Me.Controls.SetChildIndex(Me.txtTargetPowerRight, 0)
        Me.Controls.SetChildIndex(Me.txtTargetPower, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblDCPulse, 0)
        Me.Controls.SetChildIndex(Me.bicDCPulse, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.lblMagnatron, 0)
        Me.Controls.SetChildIndex(Me.txtMagnatronStatus, 0)
        Me.Controls.SetChildIndex(Me.btnRotationStart, 0)
        Me.Controls.SetChildIndex(Me.bicRotating, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTargetPower As SL_Textbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTargetVoltage As SL_Textbox
    Friend WithEvents txtTargetCurrent As SL_Textbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTargetCurrentRight As System.Windows.Forms.TextBox
    Friend WithEvents lblDCPulse As System.Windows.Forms.Label
    Friend WithEvents txtTargetDCPulse As SL_Textbox
    Friend WithEvents txtTargetVoltageRight As System.Windows.Forms.TextBox
    Friend WithEvents txtTargetPowerRight As AVP_Robot_Project.PVDTextbox
    Friend WithEvents bicDCPulse As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents txtKWH As SL_Textbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRampTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRampTimeRight As System.Windows.Forms.TextBox
    Friend WithEvents lblMagnatron As System.Windows.Forms.Label
    Friend WithEvents txtMagnatronStatus As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnRotationStart As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents bicRotating As AVP_Robot_Project.ButtonIGCGControl

End Class
