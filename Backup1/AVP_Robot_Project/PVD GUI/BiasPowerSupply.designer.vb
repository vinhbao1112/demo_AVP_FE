<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BiasPowerSupply
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
        Me.txtForwardPower = New AVP_Robot_Project.SL_Textbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtReflectedPower = New AVP_Robot_Project.SL_Textbox
        Me.txtVoltage = New AVP_Robot_Project.SL_Textbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPresetsRight = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtC2 = New AVP_Robot_Project.SL_Textbox
        Me.txtC2Right = New System.Windows.Forms.TextBox
        Me.txtForwardPowerRight = New AVP_Robot_Project.PVDTextbox
        Me.btnAuto = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnStore = New AVP_Robot_Project.ButtonIGCGControl
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtC1 = New AVP_Robot_Project.SL_Textbox
        Me.txtMatch = New AVP_Robot_Project.SL_Textbox
        Me.txtPresets = New AVP_Robot_Project.SL_Textbox
        Me.btnRecall = New AVP_Robot_Project.ButtonIGCGControl
        Me.txtC1Right = New System.Windows.Forms.TextBox
        Me.txtKWH = New AVP_Robot_Project.SL_Textbox
        Me.txtVoltageRight = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Forward Power (Watts)"
        '
        'txtForwardPower
        '
        Me.txtForwardPower.AccessibleName = "Forward Power"
        Me.txtForwardPower.AutoSendKeyTabWhenFinishInput = False
        Me.txtForwardPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtForwardPower.Clickable = True
        Me.txtForwardPower.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtForwardPower.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtForwardPower.GasName = ""
        Me.txtForwardPower.IsNumericTextbox = False
        Me.txtForwardPower.IsReadBack = True
        Me.txtForwardPower.IsTurboPumpTextbox = False
        Me.txtForwardPower.Location = New System.Drawing.Point(173, 33)
        Me.txtForwardPower.Name = "txtForwardPower"
        Me.txtForwardPower.ReadOnly = True
        Me.txtForwardPower.ShowUnitFormat = False
        Me.txtForwardPower.Size = New System.Drawing.Size(70, 24)
        Me.txtForwardPower.TabIndex = 9
        Me.txtForwardPower.UnitTypeUsed = ""
        Me.txtForwardPower.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtForwardPower.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtForwardPower.UseScientificFormat = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 19)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Reflected Power (Watts)"
        '
        'txtReflectedPower
        '
        Me.txtReflectedPower.AccessibleName = "Reflected Power"
        Me.txtReflectedPower.AutoSendKeyTabWhenFinishInput = False
        Me.txtReflectedPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtReflectedPower.Clickable = True
        Me.txtReflectedPower.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtReflectedPower.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtReflectedPower.GasName = ""
        Me.txtReflectedPower.IsNumericTextbox = False
        Me.txtReflectedPower.IsReadBack = True
        Me.txtReflectedPower.IsTurboPumpTextbox = False
        Me.txtReflectedPower.Location = New System.Drawing.Point(173, 58)
        Me.txtReflectedPower.Name = "txtReflectedPower"
        Me.txtReflectedPower.ReadOnly = True
        Me.txtReflectedPower.ShowUnitFormat = False
        Me.txtReflectedPower.Size = New System.Drawing.Size(70, 24)
        Me.txtReflectedPower.TabIndex = 12
        Me.txtReflectedPower.UnitTypeUsed = ""
        Me.txtReflectedPower.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtReflectedPower.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtReflectedPower.UseScientificFormat = True
        '
        'txtVoltage
        '
        Me.txtVoltage.AccessibleName = "Voltage"
        Me.txtVoltage.AutoSendKeyTabWhenFinishInput = False
        Me.txtVoltage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVoltage.Clickable = True
        Me.txtVoltage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtVoltage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtVoltage.GasName = ""
        Me.txtVoltage.IsNumericTextbox = False
        Me.txtVoltage.IsReadBack = True
        Me.txtVoltage.IsTurboPumpTextbox = False
        Me.txtVoltage.Location = New System.Drawing.Point(173, 83)
        Me.txtVoltage.Name = "txtVoltage"
        Me.txtVoltage.ReadOnly = True
        Me.txtVoltage.ShowUnitFormat = False
        Me.txtVoltage.Size = New System.Drawing.Size(70, 24)
        Me.txtVoltage.TabIndex = 12
        Me.txtVoltage.UnitTypeUsed = ""
        Me.txtVoltage.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtVoltage.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtVoltage.UseScientificFormat = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 19)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Voltage (Volts)"
        '
        'txtPresetsRight
        '
        Me.txtPresetsRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtPresetsRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPresetsRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPresetsRight.Location = New System.Drawing.Point(245, 183)
        Me.txtPresetsRight.Name = "txtPresetsRight"
        Me.txtPresetsRight.ReadOnly = True
        Me.txtPresetsRight.Size = New System.Drawing.Size(70, 24)
        Me.txtPresetsRight.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 19)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "C1 (%)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 19)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "C2 (%)"
        '
        'txtC2
        '
        Me.txtC2.AccessibleName = "C2"
        Me.txtC2.AutoSendKeyTabWhenFinishInput = False
        Me.txtC2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtC2.Clickable = True
        Me.txtC2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtC2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC2.GasName = ""
        Me.txtC2.IsNumericTextbox = False
        Me.txtC2.IsReadBack = True
        Me.txtC2.IsTurboPumpTextbox = False
        Me.txtC2.Location = New System.Drawing.Point(173, 133)
        Me.txtC2.Name = "txtC2"
        Me.txtC2.ReadOnly = True
        Me.txtC2.ShowUnitFormat = False
        Me.txtC2.Size = New System.Drawing.Size(70, 24)
        Me.txtC2.TabIndex = 12
        Me.txtC2.UnitTypeUsed = ""
        Me.txtC2.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtC2.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtC2.UseScientificFormat = True
        '
        'txtC2Right
        '
        Me.txtC2Right.BackColor = System.Drawing.SystemColors.Window
        Me.txtC2Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtC2Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC2Right.Location = New System.Drawing.Point(245, 133)
        Me.txtC2Right.Name = "txtC2Right"
        Me.txtC2Right.ReadOnly = True
        Me.txtC2Right.Size = New System.Drawing.Size(70, 24)
        Me.txtC2Right.TabIndex = 13
        '
        'txtForwardPowerRight
        '
        Me.txtForwardPowerRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtForwardPowerRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtForwardPowerRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtForwardPowerRight.Location = New System.Drawing.Point(245, 33)
        Me.txtForwardPowerRight.Name = "txtForwardPowerRight"
        Me.txtForwardPowerRight.ReadOnly = True
        Me.txtForwardPowerRight.Size = New System.Drawing.Size(70, 24)
        Me.txtForwardPowerRight.TabIndex = 13
        Me.txtForwardPowerRight.UseBackGroundWorkerToUpdateMinMax = True
        '
        'btnAuto
        '
        Me.btnAuto.BackColor = System.Drawing.Color.Transparent
        Me.btnAuto.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAuto.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAuto.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAuto.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnAuto.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnAuto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAuto.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnAuto.ErrorText = ""
        Me.btnAuto.FlatAppearance.BorderSize = 0
        Me.btnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAuto.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAuto.ForeColor = System.Drawing.Color.Black
        Me.btnAuto.Location = New System.Drawing.Point(245, 158)
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAuto.OffText = "Auto"
        Me.btnAuto.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnAuto.OnText = "Manual"
        Me.btnAuto.Size = New System.Drawing.Size(70, 24)
        Me.btnAuto.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnAuto.StyleOfButton = ButtonStyle.Horizontal
        Me.btnAuto.TabIndex = 15
        Me.btnAuto.Text = "Auto"
        Me.btnAuto.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnAuto.UnKnownText = ""
        Me.btnAuto.UseVisualStyleBackColor = False
        '
        'btnStore
        '
        Me.btnStore.BackColor = System.Drawing.Color.Transparent
        Me.btnStore.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnStore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStore.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnStore.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnStore.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnStore.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnStore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStore.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnStore.ErrorText = ""
        Me.btnStore.FlatAppearance.BorderSize = 0
        Me.btnStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStore.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStore.ForeColor = System.Drawing.Color.Black
        Me.btnStore.Location = New System.Drawing.Point(245, 209)
        Me.btnStore.Name = "btnStore"
        Me.btnStore.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnStore.OffText = ""
        Me.btnStore.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnStore.OnText = ""
        Me.btnStore.Size = New System.Drawing.Size(70, 24)
        Me.btnStore.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnStore.StyleOfButton = ButtonStyle.Horizontal
        Me.btnStore.TabIndex = 15
        Me.btnStore.Text = "Store"
        Me.btnStore.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnStore.UnKnownText = ""
        Me.btnStore.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 19)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Match"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 19)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Presets"
        '
        'txtC1
        '
        Me.txtC1.AccessibleName = "C1"
        Me.txtC1.AutoSendKeyTabWhenFinishInput = False
        Me.txtC1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtC1.Clickable = True
        Me.txtC1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtC1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC1.GasName = ""
        Me.txtC1.IsNumericTextbox = False
        Me.txtC1.IsReadBack = True
        Me.txtC1.IsTurboPumpTextbox = False
        Me.txtC1.Location = New System.Drawing.Point(173, 108)
        Me.txtC1.Name = "txtC1"
        Me.txtC1.ReadOnly = True
        Me.txtC1.ShowUnitFormat = False
        Me.txtC1.Size = New System.Drawing.Size(70, 24)
        Me.txtC1.TabIndex = 12
        Me.txtC1.UnitTypeUsed = ""
        Me.txtC1.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtC1.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtC1.UseScientificFormat = True
        '
        'txtMatch
        '
        Me.txtMatch.AccessibleName = "Match"
        Me.txtMatch.AutoSendKeyTabWhenFinishInput = False
        Me.txtMatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMatch.Clickable = True
        Me.txtMatch.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMatch.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMatch.GasName = ""
        Me.txtMatch.IsNumericTextbox = False
        Me.txtMatch.IsReadBack = True
        Me.txtMatch.IsTurboPumpTextbox = False
        Me.txtMatch.Location = New System.Drawing.Point(173, 158)
        Me.txtMatch.Name = "txtMatch"
        Me.txtMatch.ReadOnly = True
        Me.txtMatch.ShowUnitFormat = False
        Me.txtMatch.Size = New System.Drawing.Size(70, 24)
        Me.txtMatch.TabIndex = 12
        Me.txtMatch.UnitTypeUsed = ""
        Me.txtMatch.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtMatch.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtMatch.UseScientificFormat = True
        '
        'txtPresets
        '
        Me.txtPresets.AccessibleName = "Preset"
        Me.txtPresets.AutoSendKeyTabWhenFinishInput = False
        Me.txtPresets.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPresets.Clickable = True
        Me.txtPresets.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPresets.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPresets.GasName = ""
        Me.txtPresets.IsNumericTextbox = False
        Me.txtPresets.IsReadBack = True
        Me.txtPresets.IsTurboPumpTextbox = False
        Me.txtPresets.Location = New System.Drawing.Point(173, 183)
        Me.txtPresets.Name = "txtPresets"
        Me.txtPresets.ReadOnly = True
        Me.txtPresets.ShowUnitFormat = False
        Me.txtPresets.Size = New System.Drawing.Size(70, 24)
        Me.txtPresets.TabIndex = 12
        Me.txtPresets.UnitTypeUsed = ""
        Me.txtPresets.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtPresets.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtPresets.UseScientificFormat = True
        '
        'btnRecall
        '
        Me.btnRecall.BackColor = System.Drawing.Color.Transparent
        Me.btnRecall.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnRecall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRecall.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRecall.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRecall.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnRecall.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnRecall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRecall.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnRecall.ErrorText = ""
        Me.btnRecall.FlatAppearance.BorderSize = 0
        Me.btnRecall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecall.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecall.ForeColor = System.Drawing.Color.Black
        Me.btnRecall.Location = New System.Drawing.Point(173, 209)
        Me.btnRecall.Name = "btnRecall"
        Me.btnRecall.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnRecall.OffText = ""
        Me.btnRecall.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnRecall.OnText = ""
        Me.btnRecall.Size = New System.Drawing.Size(70, 24)
        Me.btnRecall.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnRecall.StyleOfButton = ButtonStyle.Horizontal
        Me.btnRecall.TabIndex = 15
        Me.btnRecall.Text = "Recall"
        Me.btnRecall.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnRecall.UnKnownText = ""
        Me.btnRecall.UseVisualStyleBackColor = False
        '
        'txtC1Right
        '
        Me.txtC1Right.BackColor = System.Drawing.SystemColors.Window
        Me.txtC1Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtC1Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtC1Right.Location = New System.Drawing.Point(245, 108)
        Me.txtC1Right.Name = "txtC1Right"
        Me.txtC1Right.ReadOnly = True
        Me.txtC1Right.Size = New System.Drawing.Size(70, 24)
        Me.txtC1Right.TabIndex = 13
        '
        'txtKWH
        '
        Me.txtKWH.AccessibleName = "Preset"
        Me.txtKWH.AutoSendKeyTabWhenFinishInput = False
        Me.txtKWH.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtKWH.Clickable = True
        Me.txtKWH.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtKWH.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtKWH.GasName = ""
        Me.txtKWH.IsNumericTextbox = False
        Me.txtKWH.IsReadBack = True
        Me.txtKWH.IsTurboPumpTextbox = False
        Me.txtKWH.Location = New System.Drawing.Point(87, 209)
        Me.txtKWH.Name = "txtKWH"
        Me.txtKWH.ReadOnly = True
        Me.txtKWH.ShowUnitFormat = False
        Me.txtKWH.Size = New System.Drawing.Size(70, 24)
        Me.txtKWH.TabIndex = 12
        Me.txtKWH.UnitTypeUsed = ""
        Me.txtKWH.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtKWH.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtKWH.UseScientificFormat = True
        Me.txtKWH.Visible = False
        '
        'txtVoltageRight
        '
        Me.txtVoltageRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtVoltageRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtVoltageRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtVoltageRight.Location = New System.Drawing.Point(245, 83)
        Me.txtVoltageRight.Name = "txtVoltageRight"
        Me.txtVoltageRight.ReadOnly = True
        Me.txtVoltageRight.Size = New System.Drawing.Size(70, 24)
        Me.txtVoltageRight.TabIndex = 16
        '
        'BiasPowerSupply
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtVoltageRight)
        Me.Controls.Add(Me.txtReflectedPower)
        Me.Controls.Add(Me.btnRecall)
        Me.Controls.Add(Me.btnStore)
        Me.Controls.Add(Me.btnAuto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtForwardPower)
        Me.Controls.Add(Me.txtC1Right)
        Me.Controls.Add(Me.txtForwardPowerRight)
        Me.Controls.Add(Me.txtC2Right)
        Me.Controls.Add(Me.txtPresetsRight)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtKWH)
        Me.Controls.Add(Me.txtPresets)
        Me.Controls.Add(Me.txtMatch)
        Me.Controls.Add(Me.txtC2)
        Me.Controls.Add(Me.txtC1)
        Me.Controls.Add(Me.txtVoltage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Name = "BiasPowerSupply"
        Me.Size = New System.Drawing.Size(325, 242)
        Me.Text = "Bias Power Supply"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtVoltage, 0)
        Me.Controls.SetChildIndex(Me.txtC1, 0)
        Me.Controls.SetChildIndex(Me.txtC2, 0)
        Me.Controls.SetChildIndex(Me.txtMatch, 0)
        Me.Controls.SetChildIndex(Me.txtPresets, 0)
        Me.Controls.SetChildIndex(Me.txtKWH, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtPresetsRight, 0)
        Me.Controls.SetChildIndex(Me.txtC2Right, 0)
        Me.Controls.SetChildIndex(Me.txtForwardPowerRight, 0)
        Me.Controls.SetChildIndex(Me.txtC1Right, 0)
        Me.Controls.SetChildIndex(Me.txtForwardPower, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.btnAuto, 0)
        Me.Controls.SetChildIndex(Me.btnStore, 0)
        Me.Controls.SetChildIndex(Me.btnRecall, 0)
        Me.Controls.SetChildIndex(Me.txtReflectedPower, 0)
        Me.Controls.SetChildIndex(Me.txtVoltageRight, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtForwardPower As SL_Textbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReflectedPower As SL_Textbox
    Friend WithEvents txtVoltage As SL_Textbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPresetsRight As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtC2 As SL_Textbox
    Friend WithEvents txtC2Right As System.Windows.Forms.TextBox
    Friend WithEvents txtForwardPowerRight As AVP_Robot_Project.PVDTextbox
    Friend WithEvents btnAuto As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnStore As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtC1 As SL_Textbox
    Friend WithEvents txtMatch As SL_Textbox
    Friend WithEvents txtPresets As SL_Textbox
    Friend WithEvents btnRecall As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents txtC1Right As System.Windows.Forms.TextBox
    Friend WithEvents txtKWH As SL_Textbox
    Friend WithEvents txtVoltageRight As System.Windows.Forms.TextBox

End Class
